Imports System.Data.DataTable
Public Class frmProductBillingCalc4SECO

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim arrSeco As String() = {"SECO 1", "SECO 2", "SECO 3", "SECO 4"}

        Dim strShortName As String = String.Empty
        Dim strFromDate As String
        Dim strToDate As String


        If Not IsNumeric(cboBookMonth.Text) Or Not IsNumeric(cboBookYear.Text) Then
            MsgBox("Invalid Input BookMonth/Year")
            Exit Sub
        End If
        strFromDate = CreateFromDate(DateSerial(cboBookYear.Text, cboBookMonth.Text, 1))
        strToDate = CreateToDate(CDate(strFromDate).AddMonths(1).AddMinutes(-1))

        For Each strSecoPackage As String In arrSeco
            'If IsChargeCalculated(cboBookMonth.Text, cboBookYear.Text, , strSecoPackage) Then
            '    If MsgBox("Charges for " & cboBookMonth.Text & "/" & cboBookYear.Text & " had been calculated." _
            '               & "Do you want to Recalculate?") = MsgBoxResult.Ok Then
            '        DeleteCharges(cboBookMonth.Text, cboBookYear.Text, strShortName, strSecoPackage)
            '    Else
            '        Exit Sub
            '    End If
            'End If

            If CalcSecoCharges(strFromDate, strToDate, strShortName, strSecoPackage) Then
                MsgBox("Charges calculation for " & strSecoPackage _
                       & " from " & strFromDate & " to " & strToDate & " is completed")
            End If
        Next

        Me.Dispose()

    End Sub

    Private Function CalcOneTimeCharge(intBookMonth As Integer, intBookYear As Integer, Optional strShortName As String = "" _
                                    , Optional strProductFilter As String = "") As Boolean
        Dim strFromDate As String = CreateFromDate(DateSerial(intBookYear, intBookMonth, 1))
        Dim strToDate As String = CreateToDate(CDate(strFromDate).AddMonths(1).AddMinutes(-1))

        Dim strOfferQuerry As String = "Select * from data1a_ProductOffer o" _
                                        & " left join Data1a_Misc m on m.Val=o.RecId " _
                                        & " left join Data1a_ProductCosts c on c.RecId=m.Val1 " _
                                        & " where o.Status<>'xx'" _
                                        & " and o.Region='" & pobjUser.Region _
                                        & " and Occurrence='OneTime'" _
                                        & "' and o.ValidFrom between '" & strFromDate & "' and '" & strToDate _
                                        & "' and c.Status<>'XX'" & strProductFilter & " ORDER BY o.ShortName,c.NbrOfUnit"

        If strShortName <> "" Then
            strOfferQuerry = strOfferQuerry & " and o.ShortName='" & strShortName & "'"
        End If
        'Chua lam xong vi chua co vi du
        Return True
    End Function
    Public Function DeleteCharges(intBookMonth As Integer, intBookYear As Integer, Optional strShortName As String = "" _
                                    , Optional strProductFilter As String = "") As Boolean
        Dim strQuerry As String = "Update Data1a_ProductCharges set Status='XX',LstUpdate=getdate(), LstUser='" & pobjUser.UserName _
                                  & "' where BookMonth=" & intBookMonth & " and BookYear=" & intBookYear & strProductFilter
        If strShortName <> "" Then
            strQuerry = strQuerry & " and ShortName='" & strShortName & "'"
        End If

        If pobjSql.ExecuteNonQuerry(strQuerry) Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function IsChargeCalculated(intBookMonth As Integer, intBookYear As Integer, Optional strShortName As String = "" _
                                    , Optional strProductName As String = "") As Boolean
        Dim strQuerry As String = "Select top 1 RecId from Data1a_ProductCharges where Status<>'XX'" _
                                  & " and BookMonth=" & intBookMonth _
                                  & " and BookYear=" & intBookYear
        If strShortName <> "" Then
            strQuerry = strQuerry & " and ShortName='" & strShortName & "'"
        End If

        If strProductName <> "" Then
            strQuerry = strQuerry & " and ProductName='" & strProductName & "'"
        End If

        If pobjSql.GetScalarAsString(strQuerry) <> "" Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function CalcMonthlyChargeSeco(intBookMonth As Integer, intBookYear As Integer _
                                    , strCustShortName As String, Optional strProductFilter As String = "") As Boolean
        Dim i As Integer
        Dim strValidDate As String = CreateFromDate(DateSerial(intBookYear, intBookMonth, 1))
        Dim strBookYearMonth As String = cboBookYear.Text & cboBookMonth.Text.PadLeft(2, "0")
        Dim lstInsertCharges As New List(Of String)

        Dim strShortNameList As String = "Select distinct ShortName" _
                                        & " from data1a_ProductOffer o" _
                                        & " where o.Status<>'xx'" _
                                        & " and o.Region='" & pobjUser.Region _
                                        & "' and '" & strValidDate & "' between o.ValidFrom and o.ValidTo"
        If strShortNameList <> "" Then
            strShortNameList = strShortNameList & " and ShortName='" & strCustShortName & "'"
        End If

        If strProductFilter <> "" Then
            strShortNameList = strShortNameList & strProductFilter
        End If

        Dim tblShortName As DataTable = pobjSql.GetDataTable(strShortNameList)
        For i = 0 To tblShortName.Rows.Count - 1
            CalcMonthlyChargeSecoByShortName(intBookMonth, intBookYear, tblShortName.Rows(i)("ShortName"), strProductFilter)
        Next
        Return True
    End Function

    Private Function CalcMonthlyChargeSecoByShortName(intBookMonth As Integer, intBookYear As Integer, Optional strShortName As String = "" _
                                    , Optional strProductFilter As String = "") As Boolean
        Dim i As Integer
        Dim strValidDate As String = CreateFromDate(DateSerial(intBookYear, intBookMonth, 1))
        Dim strBookYearMonth As String = cboBookYear.Text & cboBookMonth.Text.PadLeft(2, "0")
        Dim lstInsertCharges As New List(Of String)


        Dim strOfferQuerry As String = "Select * ,c.RecId as PriceId" _
                                        & ",(case formula when 'first' then 1 else 2 end) as priority" _
                                        & " from data1a_ProductOffer o" _
                                        & " left join Data1a_Misc m on m.Val=o.OfferId " _
                                        & " left join Data1a_ProductCosts c on c.RecId=m.Val1 " _
                                        & " where o.Status<>'xx'" _
                                        & " and o.Region='" & pobjUser.Region _
                                        & "' and '" & strValidDate & "' between o.ValidFrom and o.ValidTo" _
                                        & " and o.ShortName='" & strShortName _
                                        & "' and Occurrence='Monthly'" _
                                        & " and substring(o.ProductName,1,4)='SECO'" _
                                        & " and c.Status<>'XX'" & strProductFilter _
                                        & " and m.cat='ProductOfferPrice'" _
                                        & " ORDER BY o.ShortName asc,Priority asc,c.NbrOfUnit desc"

        Dim tblOffer As DataTable = pobjSql.GetDataTable(strOfferQuerry)

        For i = 0 To tblOffer.Rows.Count - 1
            Dim strSecoQuerry As String = "Select * from Data1a_ProductRights where Status='OK' and Region='" & pobjUser.Region _
                                            & "' and substring(Product,1,4)='SECO' and ShortName='" & tblOffer.Rows(i)("ShortName") _
                                            & "' and  (Year(ValidFrom)*100+Month(ValidFrom)<=" & strBookYearMonth _
                                            & ") and (ValidTo is null or (Year(ValidTo)*100+Month(ValidTo)>=" & strBookYearMonth & "))"
            Dim tblSeco As DataTable = pobjSql.GetDataTable(strSecoQuerry)

            If tblSeco.Rows.Count > 0 Then

                Dim decChargeAmt As Decimal
                Dim strDesc As String
                Dim intOccurence As Integer
                Dim intResidual As Integer
                Dim decVat As Decimal = 0

                Dim j As Integer
                If tblOffer.Rows(i)("Priority") = 1 Then 'Tinh cac khoan charge ap dung nhom Product ban dau
                    intOccurence = 1
                    decChargeAmt = tblOffer.Rows(i)("Amount")
                    If decChargeAmt < tblOffer.Rows(i)("MinAmount") Then
                        decChargeAmt = tblOffer.Rows(i)("MinAmount")
                    End If
                    decVat = CalcVat(tblOffer.Rows(i)("GetInvoice"), decChargeAmt)

                    strDesc = "First " & tblOffer.Rows(i)("NbrOfUnit") & " " & tblOffer.Rows(i)("Unit")
                    lstInsertCharges.Add("Insert into  Data1A_ProductCharges (Region, ShortName, ContactId, CalcType, Object, ProductName" _
                                         & ", Cur, Amount,Vat, OfferID, PriceID, BookMonth, BookYear, [Desc], Status,FstUser) values ('" _
                                         & tblOffer.Rows(i)("Region") & "','" & tblOffer.Rows(i)("ShortName") _
                                         & "',0,'Auto','" & tblOffer.Rows(i)("Object") & "','" & tblOffer.Rows(i)("ProductName") _
                                         & "','" & tblOffer.Rows(i)("Cur") & "'," & decChargeAmt & "," & decVat _
                                         & "," & tblOffer.Rows(i)("OfferId") & "," & tblOffer.Rows(i)("PriceId") _
                                         & "," & intBookMonth & "," & intBookMonth _
                                         & ",'" & strDesc & "','OK','" & pobjUser.UserName & "')")
                    i = tblOffer.Rows(i)("NbrOfUnit") * intOccurence - 1
                Else
                    intOccurence = tblSeco.Rows.Count \ tblOffer.Rows(i)("NbrOfUnit")
                    intResidual = tblSeco.Rows.Count Mod tblOffer.Rows(i)("NbrOfUnit")
                    If intResidual > 0 Then
                        For j = i + 1 To tblOffer.Rows.Count - 1
                            If tblOffer.Rows(j)("NbrOfUnit") < tblOffer.Rows(i)("NbrOfUnit") Then
                                intOccurence = intOccurence + 1
                            End If
                        Next
                    End If

                    For j = 1 To intOccurence
                        strDesc = "Block " & tblOffer.Rows(i)("NbrOfUnit") & " " & tblOffer.Rows(i)("Unit")
                        decChargeAmt = tblOffer.Rows(i)("Amount")
                        If decChargeAmt < tblOffer.Rows(i)("MinAmount") Then
                            decChargeAmt = tblOffer.Rows(i)("MinAmount")
                        End If
                        decVat = CalcVat(tblOffer.Rows(i)("GetInvoice"), decChargeAmt)
                        lstInsertCharges.Add("Insert into  Data1A_ProductCharges (Region, ShortName, ContactId, CalcType, Object, ProductName" _
                                         & ", Cur, Amount,Vat, OfferID, PriceID, BookMonth, BookYear, [Desc], Status,FstUser) values ('" _
                                         & tblOffer.Rows(i)("Region") & "','" & tblOffer.Rows(i)("ShortName") _
                                         & "',0,'Auto','" & tblOffer.Rows(i)("Object") & "','" & tblOffer.Rows(i)("ProductName") _
                                         & "','" & tblOffer.Rows(i)("Cur") & "'," & decChargeAmt & "," & decVat _
                                         & "," & tblOffer.Rows(i)("OfferId") & "," & tblOffer.Rows(i)("PriceId") _
                                         & "," & intBookMonth & "," & intBookYear _
                                         & ",'" & strDesc & "','OK','" & pobjUser.UserName & "')")
                    Next
                    i = (tblOffer.Rows(i)("NbrOfUnit") * intOccurence) - 1
                End If
            End If
        Next



        If pobjSql.UpdateListOfQuerries(lstInsertCharges) Then
            Return True
        Else
            MsgBox("Unable to calculate Monthly SECO charge!")
            Return False
        End If

    End Function
    Public Function CalcSecoCharges(strFromDate As String, strToDate As String _
                                    , Optional strShortName As String = "" _
                                    , Optional strProductName As String = "") As Boolean

        Dim tblOffers As DataTable = GetProductOffers(strFromDate, strToDate, strProductName, strShortName)

        For Each objRow As DataRow In tblOffers.Rows
            Dim tblSecoUser As DataTable = pobjSql.GetDataTable("Select * from Data1A_ProductRights" _
                                            & " where Status<>'xx' and Product='" & objRow("ProductName") _
                                            & "' and (ValidTo >='" & strFromDate _
                                            & " ' or ValidTo is Null) " _
                                            & " and ValidFrom <='" & strToDate _
                                            & "' and ShortName='" & objRow("ShortName") & "'")
            If tblSecoUser.Rows.Count = 0 Then
                Dim strError As String = "No SECO User found for " & objRow("ShortName")
                'MsgBox(strError)
                Append2TextFile(vbNewLine & strError)
                Continue For
            End If
            Dim intCountOfBlock As Integer
            Dim decCharge As Decimal = 0
            Dim decVat As Decimal
            Dim strChargedUpTo As String = ""
            Dim intMpeAllowance As Integer
            Dim intAtcAllowance As Integer

            Dim lstQuerries As New List(Of String)
            Select Case objRow("Formula")
                Case "Block"
                    intCountOfBlock = tblSecoUser.Rows.Count / objRow("NbrOfUnit")
                    If tblSecoUser.Rows.Count Mod objRow("NbrOfUnit") > 0 Then
                        intCountOfBlock = intCountOfBlock + 1
                    End If
                Case "First"
                    intCountOfBlock = 1
                Case Else
                    MsgBox("Chua tinh duoc gia")
                    Return False

            End Select
            decCharge = intCountOfBlock * objRow("Amount")

            If decCharge < objRow("MinAmount") Then
                decCharge = objRow("MinAmount")
            End If

            If objRow("GetInvoice") Then
                decVat = decCharge * 0.1
            Else
                decVat = 0
            End If

            Select Case objRow("Occurrence")
                Case "Monthly"
                    strChargedUpTo = CreateFromDate(CDate(strFromDate).AddMonths(1).AddDays(-1))

                    If strProductName <> "SECO 1" Then
                        intAtcAllowance = 5 * tblSecoUser.Rows.Count
                        intMpeAllowance = 25 * tblSecoUser.Rows.Count
                        lstQuerries.Add("Insert into [Data1A_ProductUsage] (ProductName, Source, Region" _
                                & ", ShortName, UsageCount, BookYear, TimeFrame, Period" _
                                & ", Status, FstUser) values ('ATC','MinusBySeco','" _
                                & pobjUser.Region & "','" & objRow("ShortName") _
                                & "'," & intAtcAllowance & "," & CDate(strFromDate).Year _
                                & ",'Month'," & CDate(strFromDate).Month _
                                & ",'OK','" & pobjUser.UserName & "')")
                        lstQuerries.Add("Insert into [Data1A_ProductUsage] (ProductName, Source, Region" _
                            & ", ShortName, UsageCount, BookYear, TimeFrame, Period" _
                            & ", Status, FstUser) values ('MPE','MinusBySeco','" _
                            & pobjUser.Region & "','" & objRow("ShortName") _
                            & "'," & intMpeAllowance & "," & CDate(strFromDate).Year _
                            & ",'Month'," & CDate(strFromDate).Month _
                            & ",'OK','" & pobjUser.UserName & "')")
                    End If
                Case "Quarterly"
                    MsgBox("Chua tinh duoc Quartly. Please aks NMK to process")
                    strChargedUpTo = CreateFromDate(CDate(strFromDate).AddMonths(3).AddDays(-1))

            End Select

            lstQuerries.Add("insert into Data1A_ProductCharges (Region, ShortName" _
                            & ", CalcType, Object, ProductName, Cur, Amount, Vat, OfferID" _
                            & ", PriceID, BookMonth, BookYear, Status,FstUser,ProductCount) values ('" _
                            & pobjUser.Region & "','" & objRow("ShortName") _
                            & "','AUTO','Customer','" & objRow("ProductName") _
                            & "','" & objRow("Cur") & "'," & decCharge _
                            & "," & decVat & "," & objRow("OfferId") _
                            & "," & objRow("PriceId") & "," & CDate(strFromDate).Month _
                            & "," & CDate(strFromDate).Year _
                            & ",'OK','" & pobjUser.UserName _
                            & "'," & intCountOfBlock & ")")
            lstQuerries.Add("Update Data1A_ProductOffer Set ChargedUpTo='" _
                            & strChargedUpTo & "' where RecId=" & objRow("RecId"))


            If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
                MsgBox("Unable to calc SECO charge for offerID " & objRow("OfferID"))
            End If
        Next


        'If Not CalcOneTimeCharge(intBookMonth, intBookYear, strShortName) Then
        '    MsgBox("Unable to calculate OneTime Charges ")
        '    Return False
        'ElseIf Not CalcMonthlyChargeSeco(intBookMonth, intBookYear, strShortName, strProductFilter) Then
        '    MsgBox("Unable to calculate Monthly Charges for SECO")
        '    Return False
        'End If


        Return True
    End Function

    Private Sub frmProductBillingCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Now.Month = 1 Then
            cboBookMonth.Text = 12
            cboBookYear.Text = Now.Year - 1
        Else
            cboBookMonth.Text = Now.Month - 1
            cboBookYear.Text = Now.Year
        End If

    End Sub
End Class