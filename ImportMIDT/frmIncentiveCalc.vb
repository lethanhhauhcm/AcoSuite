Public Class frmIncentiveCalc
    Public Function DeleteIncentiveCalc(strRegion As String, dteFromDate As Date, dteToDate As Date _
                                        , strShortName As String) As Boolean
        Dim lstQuerries As New List(Of String)
        Dim i As Integer, j As Integer
        Dim intFromQuarter As Integer
        Dim intToQuarter As Integer
        Dim strFilterShortName As String = String.Empty



        If strShortName <> "" Then
            strFilterShortName = " and ShortName='" & strShortName & "'"
        Else

        End If


        lstQuerries.Add("Update Data1A_IncentiveSumBkg set Status='XX', LstUpdate = Getdate(),LstUser='" _
                        & pobjUser.UserName & "' where Status='OK' and Region='" & strRegion _
                        & "'" & strFilterShortName _
                        & " and ValidDate between '" & CreateFromDate(dteFromDate) _
                        & "' and '" & CreateToDate(dteToDate) & "'")

        For i = dteFromDate.Year To dteToDate.Year
            If i = dteFromDate.Year Then
                intFromQuarter = ConvertMonth2Quarter(dteFromDate.Month)
            Else
                intFromQuarter = 1
            End If
            If i = dteToDate.Year Then
                intToQuarter = ConvertMonth2Quarter(dteToDate.Month)
            Else
                intToQuarter = 4
            End If
            lstQuerries.Add("Update Data1A_IncentiveCalc set Status='XX', LstUpdate = Getdate(),LstUser='" _
                        & pobjUser.UserName & "' where Status='OK' and Region='" & strRegion & "'" & strFilterShortName _
                        & " and CalcYear=" & i & " and CalcQuarter between " & intFromQuarter _
                        & " and " & intToQuarter)
        Next
        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox(String.Format("Unable to delete IncentiveCalc for {0} between {1} and {2}" _
                                 , strShortName, dteFromDate, dteToDate))
            Return False
        Else
            Return True
        End If

    End Function
    Private Function Adjust4QuarterContact(intYear As Integer, intQuarter As Integer, intMonth As Integer) As Boolean
        'Dieu chinh bkg cho Quy truoc khi thang dau tien quy sau bi am
        Dim tblCurrentBkg As System.Data.DataTable
        Dim i As Integer
        Dim intYear4LastPeriod As Integer
        Dim intHalfYear4LastPeriod As Integer
        Dim intQuarter4LastPeriod As Integer
        Dim intMonth4LastPeriod As Integer
        Dim lstQuerries As New List(Of String)
        Dim strValidDate As String = CreateFromDate(DateSerial(intYear, intMonth, 1))
        Dim strValidDate4LastPeriod As String
        Dim strQuerryMinusBkg As String

        Dim strQuerryLastVndAdhoc As String
        Dim strQuerryLastVndAdhocCustomer As String
        Dim strQuerryLastVndAutoCustomer As String
        Dim tblFormula As System.Data.DataTable

        Select Case intMonth
            Case 1
                intYear4LastPeriod = intYear - 1
                intQuarter4LastPeriod = 4
                intMonth4LastPeriod = 12
            Case 4, 7, 10
                intYear4LastPeriod = intYear
                intQuarter4LastPeriod = intQuarter - 1
                intMonth4LastPeriod = intMonth - 1
            Case Else
                intYear4LastPeriod = intYear
                intQuarter4LastPeriod = intQuarter
                intMonth4LastPeriod = intMonth - 1
        End Select

        If intMonth < 7 Then
            intHalfYear4LastPeriod = 1
        Else
            intHalfYear4LastPeriod = 2
        End If
        strValidDate4LastPeriod = CreateFromDate(DateSerial(intYear4LastPeriod, intMonth4LastPeriod, 1))

        strQuerryLastVndAdhoc = "( select SUM(a.vnd) from Data1A_IncentiveAdhoc a" _
                                & " where a.ShortName = S.ShortName And a.BookYear = S.BookYear" _
                                & " And a.TimeFrame = 'Quarter' And a.Object = S.Object" _
                                & " And a.ContactId = S.ContactId" _
                                & " and a.BookYear=" & intYear4LastPeriod & " and a.Period=" & intQuarter4LastPeriod _
                                & ") as LastVndAdhoc "

        strQuerryLastVndAdhocCustomer = "( select SUM(a.vnd) from Data1A_IncentiveAdhoc a" _
                                & " where a.ShortName = S.ShortName And a.BookYear = S.BookYear" _
                                & " And a.TimeFrame = 'Quarter' And a.Object = 'Customer'" _
                                & " and a.BookYear=" & intYear4LastPeriod & " and a.Period=" & intQuarter4LastPeriod _
                                & ") as LastVndAdhocCustomer "

        strQuerryLastVndAutoCustomer = "(select SUM(c.vnd) from Data1A_IncentiveCalc c" _
                                & " where c.ShortName = S.ShortName And c.BookYear = S.BookYear" _
                                & " And c.TimeFrame = 'Quarter' And c.Object = 'Customer'" _
                                & " and c.BookYear=" & intYear4LastPeriod & " and c.Period=" & intQuarter4LastPeriod _
                                & ") as LastVndAutoCustomer "


        strQuerryMinusBkg = "Select " & strQuerryLastVndAdhoc & "," & strQuerryLastVndAutoCustomer _
                        & "," & strQuerryLastVndAdhocCustomer _
                        & ", c.VND as LastVndAuto,c.Bkg as LastBkg,c.Bkg+s.Bkg as RevisedBkg,c.OfferId, s.*" _
                        & " from Data1A_IncentiveSumBkg s" _
                        & " LEFT JOIN Data1A_IncentiveCalc c" _
                        & " on c.ShortName= S.ShortName " _
                        & " AND c.Status='OK' and C.Object=S.Object AND C.TimeFrame='Quarter' " _
                        & " and c.BookYear=" & intYear4LastPeriod & " and c.Period=" & intMonth4LastPeriod _
                        & " where s.Status='OK' and s.Source='ALL' and s.Object='Contact' and s.TimeFrame='Month'" _
                        & " and s.BookYear =" & intYear & " and s.TimeFrame='Month' and s.Period=" & intMonth _
                        & " and s.Bkg<0" _
                        & " order by Object,Period,ContactId"
        tblCurrentBkg = pobjSql.GetDataTable(strQuerryMinusBkg)

        With tblCurrentBkg
            For i = 0 To .Rows.Count - 1
                Dim decLastVnd As Decimal
                Dim decMinusVnd As Decimal
                Dim intRevisedFormulaId As Integer
                Dim strGetRevisedVnd4Contact As String


                decLastVnd = IIf(IsDBNull(.Rows(i)("LastVndAuto")), 0, .Rows(i)("LastVndAuto")) _
                            + IIf(IsDBNull(.Rows(i)("LastVndAdhoc")), 0, .Rows(i)("LastVndAdhoc"))

                If decLastVnd > 0 Then
                    Dim strGetRevisedBkg4Customer As String

                    strGetRevisedVnd4Contact = "((case Unit when 'TimeFrame' then VND Else VND *" _
                            & .Rows(i)("RevisedBkg") & " end ) - " & decLastVnd & ") as VND"

                    strGetRevisedBkg4Customer = "(Select sum (Bkg) from Data1a_IncentiveCal c" _
                        & " where c.Object='Customer' and c.TimeFrame='Quarter'" _
                        & " and c.BookYear =" & intYear4LastPeriod & "and c.Period=" & intQuarter4LastPeriod _
                        & " and Shortname='" & .Rows(i)("ShortName") & "')"

                    tblFormula = pobjSql.GetDataTable("select top 1 f.RecId," & strGetRevisedVnd4Contact _
                            & " from Data1A_IncentiveFormula f" _
                            & " left join DATA1A_MISC m on m.VAL1=f.RecId" _
                            & " where f.Unit<>'Ticket' and f.ObjectTarget<=" _
                            & .Rows(i)("RevisedBkg") _
                            & " and f.CustomerTarget<=" & strGetRevisedBkg4Customer _
                            & " and m.Cat='OfferFormula' and m.Val=" & .Rows(i)("OfferId").ToString _
                            & " order by f.ObjectTarget desc")

                    If tblFormula.Rows.Count = 0 Then
                        decMinusVnd = 0 - decLastVnd
                        intRevisedFormulaId = 0
                    Else
                        decMinusVnd = tblFormula.Rows(0)("VND")
                        intRevisedFormulaId = tblFormula.Rows(0)("Recid")
                    End If

                    lstQuerries.Add("insert Data1A_Incentivecalc (ShortName, IncType, Object, TimeFrame" _
                                & ", CalcYear, CalcQuarter,BookYear, Period, Bkg, VND, OfferID, FormulaID" _
                                & ", FstUser,ContactId) values ('" & .Rows(i)("ShortName") _
                                & "','AUTO-','Customer','Month'," & intYear & "," & intQuarter _
                                & "," & intYear4LastPeriod & "," & intMonth4LastPeriod & "," & .Rows(i)("Bkg") _
                                & "," & decMinusVnd & "," & .Rows(i)("OfferId") & "," & intRevisedFormulaId _
                                & ",'" & pobjUser.UserName & "'," & .Rows(i)("ContactId") & ")")
                End If
            Next

            lstQuerries.Add("Update Data1A_IncentiveSumBkg set AdjustedBkg=0 where AdjustedBkg is null" _
                            & " where s.Status='OK' and Source='ALL' and Object='Customer' and TimeFrame='Month' and BookYear=" _
                            & intYear & " and Period=" & intMonth)

            If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
                MsgBox("Unable to adjust Bkg for Contact for month:" & intMonth)
                Return False
            Else
                Return True
            End If
        End With


    End Function
    Private Function Adjust4MonthContact(intYear As Integer, intQuarter As Integer, intMonth As Integer) As Boolean
        'Dieu chinh bkg cho cac thang truoc khi thang hien tai bi am
        Dim tblCurrentBkg As System.Data.DataTable
        Dim i As Integer
        Dim intYear4LastPeriod As Integer
        Dim intHalfYear4LastPeriod As Integer
        Dim intQuarter4LastPeriod As Integer
        Dim intMonth4LastPeriod As Integer
        Dim lstQuerries As New List(Of String)
        Dim strValidDate As String = CreateFromDate(DateSerial(intYear, intMonth, 1))
        Dim strValidDate4LastPeriod As String
        Dim strQuerryMinusBkg As String

        Dim strQuerryLastVndAdhoc As String
        Dim strQuerryLastVndAutoCustomer As String
        Dim tblFormula As System.Data.DataTable

        Select Case intMonth
            Case 1
                intYear4LastPeriod = intYear - 1
                intQuarter4LastPeriod = 4
                intMonth4LastPeriod = 12
            Case 4, 7, 10
                intYear4LastPeriod = intYear
                intQuarter4LastPeriod = intQuarter - 1
                intMonth4LastPeriod = intMonth - 1
            Case Else
                intYear4LastPeriod = intYear
                intQuarter4LastPeriod = intQuarter
                intMonth4LastPeriod = intMonth - 1
        End Select

        If intMonth < 7 Then
            intHalfYear4LastPeriod = 1
        Else
            intHalfYear4LastPeriod = 2
        End If
        strValidDate4LastPeriod = CreateFromDate(DateSerial(intYear4LastPeriod, intMonth4LastPeriod, 1))

        strQuerryLastVndAdhoc = "( select SUM(a.vnd) from Data1A_IncentiveAdhoc a" _
                                & " where a.ShortName = S.ShortName And a.BookYear = S.BookYear" _
                                & " And a.TimeFrame = S.TimeFrame And a.Object = S.Object" _
                                & " And a.ContactId = S.ContactId" _
                                & " and a.BookYear=" & intYear4LastPeriod & " and a.Period=" & intMonth4LastPeriod _
                                & ") as LastVndAdhoc "
        strQuerryLastVndAutoCustomer = "( select SUM(c.vnd) from Data1A_IncentiveCalc c" _
                                & " where c.Status='OK' and c.ShortName = S.ShortName And c.BookYear = S.BookYear" _
                                & " And c.TimeFrame = S.TimeFrame And c.Object = 'Customer'" _
                                & " And c.ContactId = S.ContactId" _
                                & " and c.BookYear=" & intYear4LastPeriod & " and c.Period=" & intMonth4LastPeriod _
                                & ") as LastVndAutoCustomer "
        strQuerryMinusBkg = "Select " & strQuerryLastVndAdhoc & "," & strQuerryLastVndAutoCustomer _
                        & ", c.VND as LastVndAuto,c.Bkg as LastBkg,c.Bkg+s.Bkg as RevisedBkg,c.OfferId, s.*" _
                        & " from Data1A_IncentiveSumBkg s" _
                        & " LEFT JOIN Data1A_IncentiveCalc c" _
                        & " on c.ShortName= S.ShortName AND C.BookYear=S.BookYear" _
                        & " AND c.Status='OK' and C.TimeFrame=S.TimeFrame AND C.Object=S.Object" _
                        & " and c.BookYear=" & intYear4LastPeriod & " and c.Period=" & intMonth4LastPeriod _
                        & " where s.Status='OK' and s.Source='ALL' and s.Object='Contact' and s.TimeFrame='Month'" _
                        & " and s.BookYear =" & intYear & " and s.TimeFrame='Month' and s.Period=" & intMonth _
                        & " and s.AdjustedBkg is null and s.Bkg<0" _
                        & " order by Object,Period,ContactId"
        tblCurrentBkg = pobjSql.GetDataTable(strQuerryMinusBkg)

        With tblCurrentBkg
            For i = 0 To .Rows.Count - 1
                Dim decLastVnd As Decimal
                Dim decMinusVnd As Decimal
                Dim intRevisedFormulaId As Integer
                Dim strGetRevisedVnd4Contact As String


                decLastVnd = IIf(IsDBNull(.Rows(i)("LastVndAuto")), 0, .Rows(i)("LastVndAuto")) _
                            + IIf(IsDBNull(.Rows(i)("LastVndAdhoc")), 0, .Rows(i)("LastVndAdhoc"))

                If decLastVnd > 0 Then
                    Dim strGetRevisedBkg4Customer As String

                    strGetRevisedVnd4Contact = "((case Unit when 'TimeFrame' then VND Else VND *" _
                            & .Rows(i)("RevisedBkg") & " end ) - " & decLastVnd & ") as VND"

                    strGetRevisedBkg4Customer = "(Select sum (Bkg) from Data1a_IncentiveCal c" _
                        & " where c.Object='Customer' and c.TimeFrame='Month'" _
                        & " and c.BookYear =" & intYear4LastPeriod & "and c.Period=" & intMonth4LastPeriod _
                        & " and Shortname='" & .Rows(i)("ShortName") & "')"

                    tblFormula = pobjSql.GetDataTable("select top 1 f.RecId," & strGetRevisedVnd4Contact _
                            & " from Data1A_IncentiveFormula f" _
                            & " left join DATA1A_MISC m on m.VAL1=f.RecId" _
                            & " where f.Unit<>'Ticket' and f.ObjectTarget<=" _
                            & .Rows(i)("RevisedBkg") _
                            & " and f.CustomerTarget<=" & strGetRevisedBkg4Customer _
                            & " and m.Cat='OfferFormula' and m.Val=" & .Rows(i)("OfferId").ToString _
                            & " order by f.ObjectTarget desc")

                    If tblFormula.Rows.Count = 0 Then
                        decMinusVnd = 0 - decLastVnd
                        intRevisedFormulaId = 0
                    Else
                        decMinusVnd = tblFormula.Rows(0)("VND")
                        intRevisedFormulaId = tblFormula.Rows(0)("Recid")
                    End If

                    lstQuerries.Add("insert Data1A_Incentivecalc (ShortName, IncType, Object, TimeFrame" _
                                & ", CalcYear, CalcQuarter,BookYear, Period, Bkg, VND, OfferID, FormulaID" _
                                & ", FstUser,ContactId) values ('" & .Rows(i)("ShortName") _
                                & "','AUTO-','Customer','Month'," & intYear & "," & intQuarter _
                                & "," & intYear4LastPeriod & "," & intMonth4LastPeriod & "," & .Rows(i)("Bkg") _
                                & "," & decMinusVnd & "," & .Rows(i)("OfferId") & "," & intRevisedFormulaId _
                                & ",'" & pobjUser.UserName & "'," & .Rows(i)("ContactId") & ")")
                End If
            Next

            lstQuerries.Add("Update Data1A_IncentiveSumBkg set AdjustedBkg=0 where AdjustedBkg is null" _
                            & " and Status='OK' and Source='ALL' and Object='Customer' and TimeFrame='Month' and BookYear=" _
                            & intYear & " and Period=" & intMonth)

            If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
                MsgBox("Unable to adjust Bkg for Contact for month:" & intMonth)
                Return False
            Else
                Return True
            End If
        End With

    End Function
    Private Function Adjust4ContactList(strRegion As String, intYear As Integer, intMonth As Integer _
                                    , Optional strShortName As String = "", Optional intContactId As Integer = 0) As Boolean
        Dim lstQuerries As New List(Of String)
        Dim strMinusBkgList As String
        Dim tblMinusBkgList As System.Data.DataTable
        Dim i As Integer
        Dim intYear4LastPeriod As Integer
        Dim intMonth4LastPeriod As Integer
        Dim strAdjustMinustBkg As String

        Select Case intMonth
            Case 1
                intYear4LastPeriod = intYear - 1
                intMonth4LastPeriod = 12
            Case Else
                intYear4LastPeriod = intYear
                intMonth4LastPeriod = intMonth - 1
        End Select


        strMinusBkgList = "Select s.*" _
                       & " from Data1A_IncentiveSumBkg s" _
                       & " where s.Status='OK' and s.Source='ALL' and s.Object='Contact'" _
                       & " and s.BookYear =" & intYear & " and s.TimeFrame='Month' and s.Period=" & intMonth _
                       & " and s.AdjustedBkg is null and s.Bkg<0 and Region='" & strRegion & "'"

        If strShortName <> "" Then
            strMinusBkgList = strMinusBkgList & " and ShortName='" & strShortName & "'"
        End If


        tblMinusBkgList = pobjSql.GetDataTable(strMinusBkgList)
        With tblMinusBkgList
            For i = 0 To .Rows.Count - 1
                lstQuerries.AddRange(Adjust4Contact(strRegion, intYear4LastPeriod, intMonth4LastPeriod, .Rows(i)("ShortName") _
                                                     , .Rows(i)("Bkg"), .Rows(i)("ContactId")))
            Next
        End With

        strAdjustMinustBkg = "Update Data1A_IncentiveSumBkg set AdjustedBkg=0 " _
                            & " where Status='OK' and Source='ALL' and Region='" & strRegion _
                            & "' and Object='Contact' and Bkg<0 and AdjustedBkg is null and Region='" _
                                & strRegion & "' and BookYear=" & intYear & " and TimeFrame='Month' and Period=" & intMonth

        If strShortName <> "" Then
            strAdjustMinustBkg = strAdjustMinustBkg & " and shortname='" & strShortName & "'"
        End If

        lstQuerries.Add(strAdjustMinustBkg)
        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Unable to adjust Bkg for ContactList of Year {} month {}", intYear, intMonth)
            Return False
        Else
            Return True
        End If

    End Function
    Private Function Adjust4CustomerList(strRegion As String, intYear As Integer, intMonth As Integer _
                                    , Optional strShortName As String = "") As Boolean
        Dim lstQuerries As New List(Of String)
        Dim strMinusBkgList As String
        Dim tblMinusBkgList As System.Data.DataTable
        Dim i As Integer
        Dim intYear4LastPeriod As Integer
        Dim intMonth4LastPeriod As Integer
        Dim strAdjustMinustBkg As String

        Select Case intMonth
            Case 1
                intYear4LastPeriod = intYear - 1
                intMonth4LastPeriod = 12
            Case Else
                intYear4LastPeriod = intYear
                intMonth4LastPeriod = intMonth - 1
        End Select


        strMinusBkgList = "Select s.*" _
                       & " from Data1A_IncentiveSumBkg s" _
                       & " where s.Status='OK' and s.Source='ALL' and s.Object='Customer'" _
                       & " and s.BookYear =" & intYear & " and s.TimeFrame='Month' and s.Period=" & intMonth _
                       & " and s.AdjustedBkg is null and s.Bkg<0 and Region='" & strRegion & "'"

        If strShortName <> "" Then
            strMinusBkgList = strMinusBkgList & " and ShortName='" & strShortName & "'"
        End If


        tblMinusBkgList = pobjSql.GetDataTable(strMinusBkgList)
        With tblMinusBkgList
            For i = 0 To .Rows.Count - 1
                lstQuerries.AddRange(Adjust4Customer(strRegion, intYear4LastPeriod, intMonth4LastPeriod, .Rows(i)("ShortName") _
                                                     , .Rows(i)("Bkg")))
            Next
        End With

        strAdjustMinustBkg = "Update Data1A_IncentiveSumBkg set AdjustedBkg=0 " _
                            & " where Status='OK' and Source='ALL' and Region='" & strRegion _
                            & "' and Object='Customer' and Bkg<0 and AdjustedBkg is null and Region='" _
                                & strRegion & "' and BookYear=" & intYear & " and TimeFrame='Month' and Period=" & intMonth

        If strShortName <> "" Then
            strAdjustMinustBkg = strAdjustMinustBkg & " and shortname='" & strShortName & "'"
        End If

        lstQuerries.Add(strAdjustMinustBkg)
        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Unable to adjust Bkg for CustomerList of Year {} month {}", intYear, intMonth)
            Return False
        Else
            Return True
        End If

    End Function
    Private Function Adjust4Contact(strRegion As String, intYear As Integer, intMonth As Integer _
                                    , strShortName As String, intMinusBkg As Integer _
                                    , intContactId As Integer) As List(Of String)
        Dim lstQuerries As New List(Of String)

        lstQuerries.AddRange(Adjust4ContactTimeFrame(strRegion, intYear, intMonth, strShortName, intMinusBkg _
                                                     , "Month", intContactId))

        If intMonth = 12 Then
            lstQuerries.AddRange(Adjust4ContactTimeFrame(strRegion, intYear, 1, strShortName, intMinusBkg _
                                                         , "Year", intContactId))
        End If

        If intMonth = 12 Or intMonth = 6 Then
            lstQuerries.AddRange(Adjust4ContactTimeFrame(strRegion, intYear, intMonth / 6, strShortName, intMinusBkg _
                                                          , "HalfYear", intContactId))
        End If

        If intMonth = 12 Or intMonth = 9 Or intMonth = 6 Or intMonth = 3 Then
            lstQuerries.AddRange(Adjust4ContactTimeFrame(strRegion, intYear, intMonth / 3, strShortName, intMinusBkg _
                                                         , "Quarter", intContactId))
        End If
        Return lstQuerries
    End Function
    Private Function Adjust4Customer(strRegion As String, intYear As Integer, intMonth As Integer _
                                    , strShortName As String, intMinusBkg As Integer) As List(Of String)
        Dim lstQuerries As New List(Of String)

        lstQuerries.AddRange(Adjust4CustomerTimeFrame(strRegion, intYear, intMonth, strShortName, intMinusBkg, "Month"))

        If intMonth = 12 Then
            lstQuerries.AddRange(Adjust4CustomerTimeFrame(strRegion, intYear, 1, strShortName, intMinusBkg, "Year"))
        End If

        If intMonth = 12 Or intMonth = 6 Then
            lstQuerries.AddRange(Adjust4CustomerTimeFrame(strRegion, intYear, intMonth / 6, strShortName, intMinusBkg, "HalfYear"))
        End If

        If intMonth = 12 Or intMonth = 9 Or intMonth = 6 Or intMonth = 3 Then
            lstQuerries.AddRange(Adjust4CustomerTimeFrame(strRegion, intYear, intMonth / 3, strShortName, intMinusBkg, "Quarter"))
        End If
        Return lstQuerries
    End Function
    Private Function Adjust4ContactTimeFrame(strRegion As String, intYear As Integer, intPeriod As Integer _
                                    , strShortName As String, intMinusBkg As Integer _
                                    , strTimeFrame As String, intContactId As Integer) As List(Of String)
        Dim lstQuerries As New List(Of String)
        Dim intCalcQuarter As Integer
        Dim intCalcYear As Integer
        Dim strValidDate As String
        Dim tblIncentive As System.Data.DataTable
        Dim tblFormula As System.Data.DataTable
        Dim strQuerry As String = "Select * from Data1a_IncentiveCalc" _
                                    & " where Status='OK' and IncType='AUTO' and Object='Contact' and ShortName='" & strShortName _
                                    & "' and BookYear=" & intYear & " and TimeFrame='" _
                                    & strTimeFrame & "' and Period=" & intPeriod _
                                    & " and ContactId=" & intContactId

        strValidDate = GetValidDate4Incentive(intYear, strTimeFrame, intPeriod)
        Select Case strTimeFrame
            Case "Month"
                If intPeriod = 12 Then
                    intCalcQuarter = 1
                    intCalcYear = intYear + 1
                ElseIf intPeriod = 9 Or intPeriod = 6 Or intPeriod = 3 Then
                    intCalcQuarter = ConvertMonth2Quarter(intPeriod) + 1
                    intCalcYear = intYear
                Else
                    intCalcQuarter = ConvertMonth2Quarter(intPeriod)
                    intCalcYear = intYear
                End If
            Case "Quarter"
                If intPeriod = 4 Then
                    intCalcQuarter = 1
                    intCalcYear = intYear + 1
                Else
                    intCalcQuarter = intPeriod + 1
                    intCalcYear = intYear
                End If
            Case "HalfYear"
                If intPeriod = 2 Then
                    intCalcQuarter = 1
                    intCalcYear = intYear + 1
                Else
                    intCalcQuarter = 3
                    intCalcYear = intYear
                End If

            Case "Year"
                intCalcQuarter = 1
                intCalcYear = intCalcYear + 1
        End Select

        lstQuerries.Add("Insert Data1a_IncentiveSumBkg (Source, Region, ShortName, ContactId, IncType, Object, Bkg" _
                        & ", AdjustedBkg, CalcYear, CalcQuarter, BookYear, TimeFrame, Period, ValidDate" _
                        & ",FstUser) values ('ALL','" & strRegion & "','" & strShortName & "'," & intContactId _
                        & ",'AUTO-','Contact'," _
                        & 0 & "," & intMinusBkg & "," & intCalcYear & "," & intCalcQuarter _
                        & "," & intYear & ",'" & strTimeFrame & "'," & intPeriod & ",'" & strValidDate _
                        & "','" & pobjUser.UserName & "')")

        tblIncentive = pobjSql.GetDataTable(strQuerry)
        With tblIncentive
            If .Rows.Count > 0 Then
                Dim decMinusVnd As Decimal
                Dim intRevisedFormulaId As Integer
                Dim strGetFormula As String
                Dim intBkg4Customer As Integer

                
                intBkg4Customer = pobjSql.GetScalarAsString("Select AdjustedBkg from Data1a_IncentiveSumBkg" _
                                                            & " where Status='OK' and Source='ALL' and Object='Customer'" _
                                                            & " and Shortname='" & .Rows(0)("ShortName") _
                                                            & "' and TimeFrame='" & strTimeFrame _
                                                            & "' and BookYear=" & intYear & " and Period=" & intPeriod)

                strGetFormula = "Select RecId, (Case ApplyTo When 'TimeFrame' then VND else VND *(" _
                                                & .Rows(0)("Bkg") + intMinusBkg & ") end) as VND " _
                                                & " from Data1a_IncentiveFormula" _
                                                & " where Unit<>'Ticket' and ObjectTarget<=" & .Rows(0)("Bkg") + intMinusBkg _
                                                & " and Recid in (Select Val1 from DATA1A_MISC where Cat='OfferFormula'" _
                                                & " and Val=" & .Rows(0)("OfferId") & ")" _
                                                & " and (CustomerTarget=0 or (CustomerTarget>0 and CustomerTarget<=" _
                                                & intBkg4Customer & "))" _
                                                & " order by ObjectTarget desc,CustomerTarget desc"

                tblFormula = pobjSql.GetDataTable(strGetFormula)
                If tblFormula.Rows.Count = 0 Then
                    decMinusVnd = 0 - .Rows(0)("VND")
                    intRevisedFormulaId = 0
                Else
                    decMinusVnd = tblFormula.Rows(0)("VND") - .Rows(0)("VND")
                    intRevisedFormulaId = tblFormula.Rows(0)("Recid")
                End If
                lstQuerries.Add("insert Data1A_Incentivecalc (Region,ShortName, IncType, Object, TimeFrame" _
                                & ", CalcYear, CalcQuarter,BookYear, Period, Bkg, VND, OfferID, FormulaID" _
                                & ", FstUser,ContactId) values ('" & strRegion & "','" & .Rows(0)("ShortName") _
                                & "','AUTO-','Contact','" & strTimeFrame & "'," & intYear & "," & intCalcQuarter _
                                & "," & intCalcYear & "," & intPeriod & "," & intMinusBkg _
                                & "," & decMinusVnd & "," & .Rows(0)("OfferId") & "," & intRevisedFormulaId _
                                & ",'" & pobjUser.UserName & "'," & intContactId & ")")
            End If
        End With
        Return lstQuerries
    End Function
    Private Function Adjust4CustomerTimeFrame(strRegion As String, intYear As Integer, intPeriod As Integer _
                                    , strShortName As String, intMinusBkg As Integer _
                                    , strTimeFrame As String) As List(Of String)
        Dim lstQuerries As New List(Of String)
        Dim intCalcQuarter As Integer
        Dim intCalcYear As Integer
        Dim strValidDate As String

        Dim tblIncentive As System.Data.DataTable
        Dim tblFormula As System.Data.DataTable
        Dim strQuerry As String = "Select * from Data1a_IncentiveCalc" _
                                    & " where Status='OK' and IncType='AUTO' and Object='Customer' and ShortName='" & strShortName _
                                    & "' and BookYear=" & intYear & " and TimeFrame='" _
                                    & strTimeFrame & "' and Period=" & intPeriod

        strValidDate = GetValidDate4Incentive(intYear, strTimeFrame, intPeriod)

        Select Case strTimeFrame
            Case "Month"
                If intPeriod = 12 Then
                    intCalcQuarter = 1
                    intCalcYear = intYear + 1
                ElseIf intPeriod = 9 Or intPeriod = 6 Or intPeriod = 3 Then
                    intCalcQuarter = ConvertMonth2Quarter(intPeriod) + 1
                    intCalcYear = intYear
                Else
                    intCalcQuarter = ConvertMonth2Quarter(intPeriod)
                    intCalcYear = intYear
                End If
            Case "Quarter"
                If intPeriod = 4 Then
                    intCalcQuarter = 1
                    intCalcYear = intYear + 1
                Else
                    intCalcQuarter = intPeriod + 1
                    intCalcYear = intYear
                End If

            Case "HalfYear"
                If intPeriod = 2 Then
                    intCalcQuarter = 1
                    intCalcYear = intYear + 1
                Else
                    intCalcQuarter = 3
                    intCalcYear = intYear
                End If

            Case "Year"
                intCalcQuarter = 1
                intCalcYear = intCalcYear + 1
        End Select

        lstQuerries.Add("Insert Data1a_IncentiveSumBkg (Source, Region, ShortName, ContactId, IncType, Object, Bkg" _
                        & ", AdjustedBkg, CalcYear, CalcQuarter, BookYear, TimeFrame, Period, ValidDate" _
                        & ",FstUser) values ('ALL','" & strRegion & "','" & strShortName & "',0,'AUTO-','Customer'," _
                        & 0 & "," & intMinusBkg & "," & intCalcYear & "," & intCalcQuarter _
                        & "," & intYear & ",'" & strTimeFrame & "'," & intPeriod & ",'" & strValidDate _
                        & "','" & pobjUser.UserName & "')")

        tblIncentive = pobjSql.GetDataTable(strQuerry)
        With tblIncentive
            If .Rows.Count > 0 Then
                Dim decMinusVnd As Decimal
                Dim intRevisedFormulaId As Integer
                
                Dim strGetFormula As String

                strGetFormula = "Select RecId, (Case ApplyTo When 'TimeFrame' then VND else VND *(" _
                                                & .Rows(0)("Bkg") + intMinusBkg & ") end) as VND " _
                                                & " from Data1a_IncentiveFormula" _
                                                & " where Unit<>'Ticket' and ObjectTarget<=" & .Rows(0)("Bkg") + intMinusBkg _
                                                & " and Recid in (Select Val1 from DATA1A_MISC where Cat='OfferFormula'" _
                                                & " and Val=" & .Rows(0)("OfferId") & ") order by ObjectTarget desc"

                tblFormula = pobjSql.GetDataTable(strGetFormula)
                If tblFormula.Rows.Count = 0 Then
                    decMinusVnd = 0 - .Rows(0)("VND")
                    intRevisedFormulaId = 0
                Else
                    decMinusVnd = tblFormula.Rows(0)("VND") - .Rows(0)("VND")
                    intRevisedFormulaId = tblFormula.Rows(0)("Recid")
                End If
                lstQuerries.Add("insert Data1A_Incentivecalc (Region,ShortName, IncType, Object, TimeFrame" _
                                & ", CalcYear, CalcQuarter,BookYear, Period, Bkg, VND, OfferID, FormulaID" _
                                & ", FstUser) values ('" & strRegion & "','" & .Rows(0)("ShortName") _
                                & "','AUTO-','Customer','" & strTimeFrame & "'," & intYear & "," & intCalcQuarter _
                                & "," & intCalcYear & "," & intPeriod & "," & .Rows(0)("Bkg") _
                                & "," & decMinusVnd & "," & .Rows(0)("OfferId") & "," & intRevisedFormulaId _
                                & ",'" & pobjUser.UserName & "')")
            End If
        End With
        Return lstQuerries
    End Function
    Private Function SumTkt4ContactMonth(strRegion As String, intYear As Integer, intMonth As Integer _
                                         , Optional strShortName As String = "", Optional idContactId As Integer = 0) As Boolean
        Dim strValidDate As String = CreateFromDate(DateSerial(intYear, intMonth, 1))
        Dim lstQuerries As New List(Of String)
        Dim intQuarter = ConvertMonth2Quarter(intMonth)
        Dim strOffcIdSelection
        strOffcIdSelection = "(Select OffcId from DATA1A_OIDS o1 where o1.Status='OK' and o1.ShortName=c.ShortName)"

        Dim strSumOwnBkg As String
        Dim strSumNonOwnBkg As String
        Dim strSumAllBkg As String

        strSumOwnBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame" _
                    & ",ShortName,ContactId,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,AdjustedBkg,ValidDate,FstUser) " _
                    & " Select 'TKT','" & strRegion & "','Own','Contact','Month',C.ShortName,b.ContactId," _
                    & intYear & "," & intQuarter & "," & intYear & "," & intMonth _
                    & ",Count(t.RecId),Count(t.RecId),'" & strValidDate & "','" & pobjUser.UserName _
                    & "' from [TVCS].[dbo].[BSP_TJQ] t" _
                    & " left join DATA1A_SignIn1As s on s.OffcId=t.Offc and s.SignIn=t.TktSignin" _
                    & " left join DATA1A_Contacts b on b.ContactId=s.ContactId" _
                    & " LEFT JOIN DATA1A_Customers c ON c.shortname=b.CustShortName" _
                    & " where t.SRV='S' and Year(TransDate)=" & intYear & " and Month(TransDate)=" & intMonth _
                    & " and t.BkgOffc in " & strOffcIdSelection _
                    & " and s.Status='OK'" _
                    & " and b.Status='OK'" _
                    & " and C.Status='OK' and c.Region='" & strRegion & "'"

        If strShortName <> "" Then
            strSumOwnBkg = strSumOwnBkg & " and c.ShortName='" & strShortName & "'"
        End If
        strSumOwnBkg = strSumOwnBkg & " group by C.ShortName,Year(TransDate),Month(TransDate),b.ContactId " _
                                & " order by ShortName,ContactId"

        strSumNonOwnBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame" _
                    & ",ShortName,ContactId,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,AdjustedBkg,ValidDate,FstUser) " _
                    & " Select 'TKT','" & strRegion & "','NonOwn','Contact','Month',C.ShortName,b.ContactId," _
                    & intYear & "," & intQuarter & "," & intYear & "," & intMonth _
                    & ",Count(t.RecId),Count(t.RecId),'" & strValidDate & "','" & pobjUser.UserName _
                    & "' from [TVCS].[dbo].[BSP_TJQ] t" _
                    & " left join DATA1A_SignIn1As s on s.OffcId=t.Offc and s.SignIn=t.TktSignin" _
                    & " left join DATA1A_Contacts b on b.ContactId=s.ContactId" _
                    & " LEFT JOIN DATA1A_Customers c ON c.shortname=b.CustShortName" _
                    & " where t.SRV='S' and Year(TransDate)=" & intYear & " and Month(TransDate)=" & intMonth _
                    & " and t.BkgOffc not in " & strOffcIdSelection _
                    & " and s.Status='OK'" _
                    & " and b.Status='OK'" _
                    & " and C.Status='OK' and c.Region='" & strRegion & "'"

        If strShortName <> "" Then
            strSumNonOwnBkg = strSumNonOwnBkg & " and c.ShortName='" & strShortName & "'"
        End If
        strSumNonOwnBkg = strSumNonOwnBkg & " group by C.ShortName,Year(TransDate),Month(TransDate),b.ContactId " _
                                & " order by ShortName,ContactId"

        strSumAllBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame" _
                    & ",ShortName,ContactId,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,AdjustedBkg,ValidDate,FstUser) " _
                    & " Select 'TKT','" & strRegion & "','All','Contact','Month',C.ShortName,b.ContactId," _
                    & intYear & "," & intQuarter & "," & intYear & "," & intMonth _
                    & ",Count(t.RecId),Count(t.RecId),'" & strValidDate & "','" & pobjUser.UserName _
                    & "' from [TVCS].[dbo].[BSP_TJQ] t" _
                    & " left join DATA1A_SignIn1As s on s.OffcId=t.Offc and s.SignIn=t.TktSignin" _
                    & " left join DATA1A_Contacts b on b.ContactId=s.ContactId" _
                    & " LEFT JOIN DATA1A_Customers c ON c.shortname=b.CustShortName" _
                    & " where t.SRV='S' and Year(TransDate)=" & intYear & "and Month(TransDate)=" & intMonth _
                    & " and s.Status='OK'" _
                    & " and b.Status='OK'" _
                    & " and C.Status='OK' and c.Region='" & strRegion & "'"

        If strShortName <> "" Then
            strSumAllBkg = strSumAllBkg & " and ShortName='" & strShortName & "'"
        End If
        strSumAllBkg = strSumAllBkg & " group by C.ShortName,Year(TransDate),Month(TransDate),b.ContactId " _
                                & " order by ShortName,ContactId"

        lstQuerries.Add(strSumOwnBkg)
        lstQuerries.Add(strSumNonOwnBkg)
        lstQuerries.Add(strSumAllBkg)

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Unable to count ticket for Contact for month " & intMonth)
            Return False
        Else
            Return True
        End If
    End Function

    Private Function SumBkg4ContactMonth(strRegion As String, intYear As Integer, intMonth As Integer _
                                         , Optional strShortName As String = "", Optional idContactId As Integer = 0) As Boolean
        Dim strValidDate As String = CreateFromDate(DateSerial(intYear, intMonth, 1))
        Dim lstQuerries As New List(Of String)
        Dim intQuarter = ConvertMonth2Quarter(intMonth)

        Dim strSumBkgAllstats As String
        Dim strSumBkgHx As String
        Dim strSumBkgXx As String
        Dim strSumBkgAll As String

        ''Tinh bkg thang
        strSumBkgAllstats = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                        & ",BookYear,Period,Bkg,ValidDate,FstUser,ContactId) " _
                    & "Select 'ALLSTATS','" & strRegion & "','AUTO','Contact','Month',c.CustShortName," & intYear & "," & intQuarter _
                    & ", BookYear,BookMonth,ISNULL(SUM((Add1+Add2)-(Can1+can2)),0),'" _
                    & strValidDate & "','" & pobjUser.UserName & "',c.ContactId" _
                    & " from [AllStatsSI] a " _
                    & " LEFT JOIN DATA1A_SignIn1As s on s.OffcId=a.Office  and s.SignIn= a.SICodeSix" _
                    & " left join DATA1A_Contacts c on c.ContactId=s.ContactId" _
                    & " left join DATA1A_Customers c2 on c2.ShortName=c.CustShortName" _
                    & " where a.NoIncentive='N' and a.BookMonth=" & intMonth _
                    & " and a.BookYear =" & intYear _
                    & " and s.Status='ok' " _
                    & " and c.Status='ok' " _
                    & " and c2.Status='ok' and c2.Region='" & strRegion & "'"
        If strShortName <> "" Then
            strSumBkgAllstats = strSumBkgAllstats & " and c2.ShortName='" & strShortName & "'"
        End If
        strSumBkgAllstats = strSumBkgAllstats & " group by c.CustShortName,c.ContactId,BookYear,BookMonth" _
                    & " order by c.CustShortName,BookMonth,c.ContactId"

        ''Tinh HX thang
        strSumBkgHx = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                        & ",BookYear,Period,Bkg,ValidDate,FstUser,ContactId) " _
                    & "Select 'HX','" & strRegion & "','AUTO','Contact','Month',c.CustShortName," & intYear & "," & intQuarter _
                    & ", BookYear,BookMonth,SUM(0-Can1),'" _
                    & strValidDate & "','" & pobjUser.UserName & "',c.ContactId" _
                    & " from [HX] h " _
                    & " LEFT JOIN DATA1A_SignIn1As s on s.OffcId=h.Office  and s.SignIn= h.SICodeSix" _
                    & " left join DATA1A_Contacts c on c.ContactId=s.ContactId" _
                    & " left join DATA1A_Customers c2 on c2.ShortName=c.CustShortName" _
                    & " where  h.Incentified='True' and h.BookYear =" & intYear & " and h.BookMonth=" & intMonth _
                    & " and s.Status='ok' " _
                    & " and c.Status='ok' " _
                    & " and c2.Status='ok' and c2.Region='" & strRegion & "'"
        If strShortName <> "" Then
            strSumBkgHx = strSumBkgHx & " and c2.ShortName='" & strShortName & "'"
        End If
        strSumBkgHx = strSumBkgHx & " group by c.CustShortName,c.ContactId,BookYear,BookMonth" _
                    & " order by c.CustShortName,BookMonth,c.ContactId"

        ''Tinh Xx thang
        strSumBkgXx = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                        & ",BookYear,Period,Bkg,ValidDate,FstUser,ContactId) " _
                    & "Select 'Xx','" & strRegion & "','AUTO','Contact','Month',h.CustShortName," & intYear & "," & intQuarter _
                    & ", BookYear,BookMonth,SUM(0-Can1),'" _
                    & strValidDate & "','" & pobjUser.UserName & "',H.ContactId" _
                    & " from [Data1a_DeductBkgRuleResult] h "
        If strShortName <> "" Then
            strSumBkgXx = strSumBkgXx & " and h.ShortName='" & strShortName & "'"
        End If
        strSumBkgXx = strSumBkgXx & " group by h.CustShortName,h.ContactId,BookYear,BookMonth" _
                    & " order by h.CustShortName,BookMonth,h.ContactId"

        'tinh tong bkg thang
        strSumBkgAll = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                        & ",BookYear,Period,Bkg,ValidDate,FstUser,ContactId) " _
                        & " Select 'ALL','" & strRegion & "',IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                        & ",BookYear,Period,SUM(Bkg),ValidDate,'" & pobjUser.UserName & "',ContactId" _
                        & " from Data1A_IncentiveSumBkg where Status='OK' and Source in ('ALLSTATS','HX','XX')" _
                        & " and Object='Contact' and TimeFrame='Month'" _
                        & " and BookYear =" & intYear & " and Period=" & intMonth _
                        & " and Region='" & strRegion & "'"
        If strShortName <> "" Then
            strSumBkgAll = strSumBkgAll & " and ShortName='" & strShortName & "'"
        End If
        strSumBkgAll = strSumBkgAll & " group by ShortName,IncType,Object,TimeFrame,CalcYear,CalcQuarter,BookYear,Period,ValidDate,ContactId"

        lstQuerries.Add(strSumBkgAllstats)
        lstQuerries.Add(strSumBkgHx)
        lstQuerries.Add(strSumBkgAll)

        'Update adjust bkg Thang cho truong hop so duong
        'Dim strAdjustBkg As String = "Update Data1A_IncentiveSumBkg set AdjustedBkg=Bkg" _
        '                & " where Status='OK' and Source='ALL' and Region='" & strRegion _
        '                & "' and Object='Contact' and TimeFrame='Month'" _
        '                & " and BookYear =" & intYear & " and period =" & intMonth _
        '                & " and AdjustedBkg is null and Bkg>=0"
        Dim strAdjustBkg As String = "Update Data1A_IncentiveSumBkg set AdjustedBkg=Bkg" _
                        & " where Status='OK' and Source='ALL' and Region='" & strRegion _
                        & "' and Object='Contact' and TimeFrame='Month'" _
                        & " and BookYear =" & intYear & " and period =" & intMonth _
                        & " and AdjustedBkg is null"
        If strShortName <> "" Then
            strAdjustBkg = strAdjustBkg & " and ShortName='" & strShortName & "'"
        End If
        lstQuerries.Add(strAdjustBkg)

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Uncompleted Sum Bkg for Contact for month " & intMonth)
            Return False
        Else
            Return True
        End If
    End Function
    Private Function SumTkt4ContactTimeFrame(strRegion As String, intYear As Integer, strTimeFrame As String _
                                              , intPeriod As Integer, Optional strShortName As String = "" _
                                            , Optional intContactId As Integer = 0) As Boolean
        Dim intFromMonth As Integer
        Dim intToMonth As Integer
        Dim strValidDate As String = String.Empty
        Dim lstQuerries As New List(Of String)
        Dim intCalcQuarter As Integer
        Dim strSumBkg As String
        Dim strGroupBy As String = " group by ShortName,IncType,CalcYear,BookYear,ContactId"

        strValidDate = GetValidDate4Incentive(intYear, strTimeFrame, intPeriod)
        Select Case strTimeFrame
            Case "Quarter"
                intCalcQuarter = intPeriod
                intFromMonth = intCalcQuarter * 3 - 2
                intToMonth = intCalcQuarter * 3
                strGroupBy = strGroupBy & ",CalcQuarter"
            Case "HalfYear"
                intCalcQuarter = intPeriod * 2
                intFromMonth = intPeriod * 6 - 5
                intToMonth = intPeriod * 6
            Case "Year"
                intCalcQuarter = 4
                intFromMonth = 1
                intToMonth = 12
        End Select

        strSumBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,CalcYear,CalcQuarter,BookYear,Period,ShortName,Bkg,AdjustedBkg" _
                        & ",IncType,Object,TimeFrame,FstUser,ValidDate,ContactId)" _
                        & "Select 'TKT','" & strRegion & "',CalcYear," & intCalcQuarter & ",BookYear," & intPeriod _
                        & ", ShortName,ISNULL(SUM(Bkg),0),ISNULL(SUM(AdjustedBkg),0)" _
                        & ", IncType,'Contact','" & strTimeFrame & "','" & pobjUser.UserName _
                        & "','" & strValidDate & "',ContactId" _
                        & " from [Data1A_IncentiveSumBkg] s " _
                        & " where s.Status='OK' and s.Source='TKT' and s.Region='" & strRegion _
                        & "' and s.Object='Contact' and s.TimeFrame='Month'" _
                        & " and s.BookYear =" & intYear _
                        & " and Period between " & intFromMonth & " and " & intToMonth
        If strShortName <> "" Then
            strSumBkg = strSumBkg & " and ShortName='" & strShortName & "'"
        End If
        strSumBkg = strSumBkg & strGroupBy _
                        & " order by ShortName"

        lstQuerries.Add(strSumBkg)
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Return True
        Else
            MsgBox(String.Format("Unable to calculate Ticket for Year {0}, {1} {2} ", intYear, strTimeFrame, intPeriod))
            Return False
        End If

    End Function
    Private Function SumBkg4ContactTimeFrame(strRegion As String, intYear As Integer, strTimeFrame As String _
                                              , intPeriod As Integer, Optional strShortName As String = "" _
                                            , Optional intContactId As Integer = 0) As Boolean
        Dim intFromMonth As Integer
        Dim intToMonth As Integer
        Dim strValidDate As String = String.Empty
        Dim lstQuerries As New List(Of String)
        Dim intCalcQuarter As Integer
        Dim strSumBkg As String
        Dim strGroupBy As String = " group by ShortName,CalcYear,BookYear,ContactId"

        strValidDate = GetValidDate4Incentive(intYear, strTimeFrame, intPeriod)
        Select Case strTimeFrame
            Case "Quarter"
                intCalcQuarter = intPeriod
                intFromMonth = intCalcQuarter * 3 - 2
                intToMonth = intCalcQuarter * 3
                strGroupBy = strGroupBy & ",CalcQuarter"
            Case "HalfYear"
                intCalcQuarter = intPeriod * 2
                intFromMonth = intPeriod * 6 - 5
                intToMonth = intPeriod * 6
            Case "Year"
                intCalcQuarter = 4
                intFromMonth = 1
                intToMonth = 12
        End Select

        strSumBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,CalcYear,CalcQuarter,BookYear,Period,ShortName,Bkg,AdjustedBkg" _
                        & ",IncType,Object,TimeFrame,FstUser,ValidDate,ContactId)" _
                        & "Select 'ALL','" & strRegion & "',CalcYear," & intCalcQuarter & ",BookYear," & intPeriod _
                        & ", ShortName,ISNULL(SUM(Bkg),0),ISNULL(SUM(AdjustedBkg),0)" _
                        & ",'AUTO' as IncType,'Contact','" & strTimeFrame & "','" & pobjUser.UserName _
                        & "','" & strValidDate & "',ContactId" _
                        & " from [Data1A_IncentiveSumBkg] s " _
                        & " where s.Status='OK' and s.Source='ALL' and s.Region='" & strRegion _
                        & "' and s.Object='Contact' and s.TimeFrame='Month'" _
                        & " and s.BookYear =" & intYear _
                        & " and Period between " & intFromMonth & " and " & intToMonth
        If strShortName <> "" Then
            strSumBkg = strSumBkg & " and ShortName='" & strShortName & "'"
        End If
        strSumBkg = strSumBkg & strGroupBy _
                        & " order by ShortName"

        lstQuerries.Add(strSumBkg)
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Return True
        Else
            MsgBox(String.Format("Unable to calculate bkg for Year {0}, {1} {2} ", intYear, strTimeFrame, intPeriod))
            Return False
        End If

    End Function
    Private Function SumTkt4CustomerTimeFrame(strRegion As String, intYear As Integer, strTimeFrame As String _
                                              , intPeriod As Integer, Optional strShortName As String = "") As Boolean
        Dim intFromMonth As Integer
        Dim intToMonth As Integer
        Dim strValidDate As String = String.Empty
        Dim lstQuerries As New List(Of String)
        Dim intCalcQuarter As Integer
        Dim strGroupBy As String = " group by ShortName,CalcYear,BookYear,IncType,Source"
        Dim strSumTkt As String

        strValidDate = GetValidDate4Incentive(intYear, strTimeFrame, intPeriod)
        Select Case strTimeFrame
            Case "Quarter"
                intCalcQuarter = intPeriod
                intFromMonth = intCalcQuarter * 3 - 2
                intToMonth = intCalcQuarter * 3
                strGroupBy = strGroupBy & ",CalcQuarter"
            Case "HalfYear"
                intCalcQuarter = intPeriod * 2
                intFromMonth = intPeriod * 6 - 5
                intToMonth = intPeriod * 6
            Case "Year"
                intCalcQuarter = 4
                intFromMonth = 1
                intToMonth = 12
        End Select

        strSumTkt = "Insert Data1A_IncentiveSumBkg (Source,Region,CalcYear,CalcQuarter,BookYear,Period,ShortName,Bkg,AdjustedBkg" _
                        & ",IncType,Object,TimeFrame,FstUser,ValidDate)" _
                        & "Select 'TKT','" & strRegion & "',CalcYear," & intCalcQuarter & ",BookYear," & intPeriod _
                        & ", ShortName,ISNULL(SUM(Bkg),0),ISNULL(SUM(AdjustedBkg),0)" _
                        & ",IncType,'Customer','" & strTimeFrame & "','" & pobjUser.UserName _
                        & "','" & strValidDate _
                        & "' from [Data1A_IncentiveSumBkg] s " _
                        & " where s.Status='OK' and s.Source='TKT' and s.Region='" & strRegion _
                        & "' and s.Object='Customer' and s.TimeFrame='Month'" _
                        & " and s.BookYear =" & intYear _
                        & " and Period between " & intFromMonth & " and " & intToMonth
        If strShortName <> "" Then
            strSumTkt = strSumTkt & " and s.ShortName='" & strShortName & "'"
        End If
        lstQuerries.Add(strSumTkt & strGroupBy & " order by ShortName")
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Return True
        Else
            MsgBox(String.Format("Unable to calculate bkg for Year {0}, {1} {2} ", intYear, strTimeFrame, intPeriod))
            Return False
        End If

    End Function
    Private Function SumBkg4CustomerTimeFrame(strRegion As String, intYear As Integer, strTimeFrame As String _
                                              , intPeriod As Integer, Optional strShortName As String = "") As Boolean
        Dim intFromMonth As Integer
        Dim intToMonth As Integer
        Dim strValidDate As String = String.Empty
        Dim lstQuerries As New List(Of String)
        Dim intCalcQuarter As Integer
        Dim strGroupBy As String = " group by ShortName,CalcYear,BookYear"
        Dim strQuerry As String

        strValidDate = GetValidDate4Incentive(intYear, strTimeFrame, intPeriod)
        Select Case strTimeFrame
            Case "Quarter"
                intCalcQuarter = intPeriod
                intFromMonth = intCalcQuarter * 3 - 2
                intToMonth = intCalcQuarter * 3
                strGroupBy = strGroupBy & ",CalcQuarter"
            Case "HalfYear"
                intCalcQuarter = intPeriod * 2
                intFromMonth = intPeriod * 6 - 5
                intToMonth = intPeriod * 6
            Case "Year"
                intCalcQuarter = 4
                intFromMonth = 1
                intToMonth = 12
        End Select

        strQuerry = "Insert Data1A_IncentiveSumBkg (Source,Region,CalcYear,CalcQuarter,BookYear,Period,ShortName,Bkg,AdjustedBkg" _
                    & ",IncType,Object,TimeFrame,FstUser,ValidDate)" _
                    & "Select 'ALL','" & strRegion & "',CalcYear," & intCalcQuarter & ",BookYear," & intPeriod _
                    & ", ShortName,ISNULL(SUM(Bkg),0),ISNULL(SUM(AdjustedBkg),0)" _
                    & ",'AUTO' as IncType,'Customer','" & strTimeFrame & "','" & pobjUser.UserName _
                    & "','" & strValidDate _
                    & "' from [Data1A_IncentiveSumBkg] s " _
                    & " where s.Status='OK' and s.Source='ALL' and s.Region='" & strRegion _
                    & "' and s.Object='Customer' and s.TimeFrame='Month'" _
                    & " and s.BookYear =" & intYear _
                    & " and Period between " & intFromMonth & " and " & intToMonth
        If strShortName <> "" Then
            strQuerry = strQuerry & " and s.ShortName='" & strShortName & "'"
        End If
        strQuerry = strQuerry & strGroupBy & " order by ShortName"

        lstQuerries.Add(strQuerry)
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Return True
        Else
            MsgBox(String.Format("Unable to calculate bkg for Year {0}, {1} {2} ", intYear, strTimeFrame, intPeriod))
            Return False
        End If

    End Function
    Private Function SumTkt4CustomerMonth(strRegion As String, intYear As Integer, intMonth As Integer _
                                           , Optional strShortName As String = "") As Boolean
        Dim strValidDate As String = CreateFromDate(DateSerial(intYear, intMonth, 1))
        Dim lstQuerries As New List(Of String)
        Dim strOwnBkg As String
        Dim strNonOwnBkg As String
        Dim strAllBkg As String
        Dim intQuarter As Integer = ConvertMonth2Quarter(intMonth)
        Dim strOffcIdSelection

        strOffcIdSelection = "(Select OffcId from DATA1A_OIDS o1 where o1.Status='OK' and o1.ShortName=c.ShortName)"

        strOwnBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,AdjustedBkg,ValidDate,FstUser) " _
                    & " Select 'TKT','" & strRegion & "','Own','Customer','Month',C.ShortName," _
                    & intYear & "," & intQuarter & "," & intYear & "," & intMonth _
                    & ",Count(t.RecId),Count(t.RecId),'" & strValidDate & "','" & pobjUser.UserName _
                    & "' from [TVCS].[dbo].[BSP_TJQ] t" _
                    & " left join DATA1A_OIDS o on t.Offc=o.OffcId" _
                    & " LEFT JOIN DATA1A_Customers c ON c.shortname=O.ShortName" _
                    & " where t.SRV='S' and Year(TransDate)=" & intYear & " and Month(TransDate)=" & intMonth _
                    & " and t.BkgOffc in " & strOffcIdSelection _
                    & " and t.INF ='False' and t.LowFare='False'" _
                    & " and o.Status='OK' and o.GDS='1A'" _
                    & " and C.Status='OK' and c.Region='" & strRegion & "'"

        If strShortName <> "" Then
            strOwnBkg = strOwnBkg & " and c.ShortName='" & strShortName & "'"
        End If
        strOwnBkg = strOwnBkg & " group by C.ShortName,Year(TransDate),Month(TransDate) order by c.ShortName"

        strNonOwnBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,AdjustedBkg,ValidDate,FstUser) " _
                    & " Select 'TKT','" & strRegion & "','NonOwn','Customer','Month',C.ShortName," _
                    & intYear & "," & intQuarter & "," & intYear & "," & intMonth _
                    & ",Count(t.RecId),Count(t.RecId),'" & strValidDate & "','" & pobjUser.UserName _
                    & "' from [TVCS].[dbo].[BSP_TJQ] t" _
                    & " left join DATA1A_OIDS o on t.Offc=o.OffcId" _
                    & " LEFT JOIN DATA1A_Customers c ON c.shortname=O.ShortName" _
                    & " where t.SRV='S' and Year(TransDate)=" & intYear & " and Month(TransDate)=" & intMonth _
                    & " and t.BkgOffc not in " & strOffcIdSelection _
                    & " and t.INF ='False' and t.LowFare='False'" _
                    & " and o.Status='OK' and o.GDS='1A'" _
                    & " and C.Status='OK' and c.Region='" & strRegion & "'"

        If strShortName <> "" Then
            strNonOwnBkg = strNonOwnBkg & " and c.ShortName='" & strShortName & "'"
        End If
        strNonOwnBkg = strNonOwnBkg & " group by C.ShortName,Year(TransDate),Month(TransDate) order by c.ShortName"

        strAllBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,AdjustedBkg,ValidDate,FstUser) " _
                    & " Select 'TKT','" & strRegion & "','All','Customer','Month',C.ShortName," _
                    & intYear & "," & intQuarter & "," & intYear & "," & intMonth _
                    & ",Count(t.RecId),Count(t.RecId),'" & strValidDate & "','" & pobjUser.UserName _
                    & "' from [TVCS].[dbo].[BSP_TJQ] t" _
                    & " left join DATA1A_OIDS o on t.Offc=o.OffcId" _
                    & " LEFT JOIN DATA1A_Customers c ON c.shortname=O.ShortName" _
                    & " where t.SRV='S' and Year(TransDate)=" & intYear & " and Month(TransDate)=" & intMonth _
                    & " and t.INF ='False' and t.LowFare='False'" _
                    & " and o.Status='OK' and o.GDS='1A'" _
                    & " and C.Status='OK' and c.Region='" & strRegion & "'"

        If strShortName <> "" Then
            strAllBkg = strAllBkg & " and c.ShortName='" & strShortName & "'"
        End If
        strAllBkg = strAllBkg & " group by C.ShortName,Year(TransDate),Month(TransDate) order by c.ShortName"

        'tinh tong bkg thang
        lstQuerries.Add(strOwnBkg)
        lstQuerries.Add(strNonOwnBkg)
        lstQuerries.Add(strAllBkg)

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Uncompleted Ticket Incentive calculation for month " & intMonth)
            Return False
        Else
            Return True
        End If
    End Function
    Private Function SumBkg4CustomerMonth(strRegion As String, intYear As Integer, intMonth As Integer _
                                           , Optional strShortName As String = "") As Boolean
        Dim strValidDate As String = CreateFromDate(DateSerial(intYear, intMonth, 1))
        Dim lstQuerries As New List(Of String)
        Dim strSumAllStats As String
        Dim strSumHx As String
        Dim strSumXx As String
        Dim strSumBkg As String
        Dim strAdjustBkg As String
        Dim intQuarter As Integer = ConvertMonth2Quarter(intMonth)
        ''Tinh bkg thang

        strSumAllStats = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType" _
                    & ",Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,ValidDate,FstUser) " _
                    & "Select 'ALLSTATS','" & strRegion & "','AUTO','Customer','Month',c.ShortName," _
                    & intYear & "," & intQuarter _
                    & ", BookYear,BookMonth,ISNULL(SUM((Add1+Add2)-(Can1+can2)),0),'" _
                    & strValidDate & "','" & pobjUser.UserName _
                    & "' from [AllStatsSI] a " _
                    & " LEFT JOIN DATA1A_OIDs o on o.OffcId=a.Office" _
                    & " left join DATA1A_Customers c on c.ShortName=o.ShortName" _
                    & " where a.NoIncentive='N' and a.BookMonth=" & intMonth _
                    & " and a.BookYear =" & intYear _
                    & " and o.Status='ok' and o.GDS='1A'" _
                    & " and c.Status='ok' and c.Region='" & strRegion & "'"

        If strShortName <> "" Then
            strSumAllStats = strSumAllStats & " and c.ShortName='" & strShortName & "'"
        End If
        strSumAllStats = strSumAllStats & " group by c.ShortName,BookMonth,BookYear" _
                    & " order by c.ShortName,BookMonth"
        lstQuerries.Add(strSumAllStats)

        strSumHx = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,ValidDate,FstUser) " _
                    & "Select 'HX','" & strRegion & "','AUTO','Customer','Month',c.ShortName," & intYear & "," & intQuarter _
                    & ", BookYear,BookMonth,SUM(0-Can1),'" _
                    & strValidDate & "','" & pobjUser.UserName _
                    & "' from [HX] h " _
                    & " LEFT JOIN DATA1A_OIDs o on o.OffcId=h.Office" _
                    & " left join DATA1A_Customers c on c.ShortName=o.ShortName" _
                    & " where h.Incentified='True' and h.BookMonth=" & intMonth _
                    & " and h.BookYear =" & intYear _
                    & " and o.Status='ok' and o.GDS='1A'" _
                    & " and c.Status='ok' and c.Region='" & strRegion & "'"

        If strShortName <> "" Then
            strSumHx = strSumHx & " and c.ShortName='" & strShortName & "'"
        End If
        strSumHx = strSumHx & " group by c.ShortName,BookMonth,BookYear" _
                    & " order by c.ShortName,BookMonth"
        lstQuerries.Add(strSumHx)

        strSumXx = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,ValidDate,FstUser) " _
                    & "Select 'XX','" & strRegion & "','AUTO','Customer','Month',h.ShortName," & intYear & "," & intQuarter _
                    & ", BookYear,BookMonth,SUM(0-Can1),'" _
                    & strValidDate & "','" & pobjUser.UserName _
                    & "' from Data1a_DeductBkgRuleResult h " _
                    & " where h.BookMonth=" & intMonth _
                    & " and h.BookYear =" & intYear

        If strShortName <> "" Then
            strSumXx = strSumXx & " and h.ShortName='" & strShortName & "'"
        End If
        strSumXx = strSumXx & " group by h.ShortName,BookMonth,BookYear" _
                    & " order by h.ShortName,BookMonth"
        lstQuerries.Add(strSumXx)

        strSumBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,ValidDate,FstUser) " _
                    & " Select 'ALL','" & strRegion & "',IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,SUM(Bkg),ValidDate,'" & pobjUser.UserName _
                    & "' from Data1A_IncentiveSumBkg where Status='OK' and Source in ('ALLSTATS','HX','XX')" _
                    & " and Object='Customer' and TimeFrame='Month'" _
                    & " and BookYear =" & intYear & " and Period=" & intMonth _
                    & " and Region='" & strRegion & "'"

        If strShortName <> "" Then
            strSumBkg = strSumBkg & " and ShortName='" & strShortName & "'"
        End If
        strSumBkg = strSumBkg & " group by ShortName,IncType,Object,TimeFrame,BookYear,CalcYear,CalcQuarter,Period,ValidDate"

        'tinh tong bkg thang
        lstQuerries.Add(strSumBkg)


        'Update adjust bkg Thang cho truong hop so duong
        'If pobjUser.Region = "South" Then
        strAdjustBkg = "Update Data1A_IncentiveSumBkg set AdjustedBkg=Bkg" _
                    & " where Status='OK' and Source='ALL' and Region='" _
                    & strRegion & "' and Object='Customer' and TimeFrame='Month'" _
                    & " and BookYear =" & intYear & " and period =" & intMonth _
                    & " and AdjustedBkg is null "
        '    strAdjustBkg = "Update Data1A_IncentiveSumBkg set AdjustedBkg=Bkg" _
        '                & " where Status='OK' and Source='ALL' and Region='" _
        '                & strRegion & "' and Object='Customer' and TimeFrame='Month'" _
        '                & " and BookYear =" & intYear & " and period =" & intMonth _
        '                & " and AdjustedBkg is null and Bkg>=0"
        'Else
        '    strAdjustBkg = "Update Data1A_IncentiveSumBkg set AdjustedBkg=(Bkg/50*50)" _
        '                & " where Status='OK' and Source='ALL' and Region='" _
        '                & strRegion & "' and Object='Customer' and TimeFrame='Month'" _
        '                & " and BookYear =" & intYear & " and period =" & intMonth _
        '                & " and AdjustedBkg is null and Bkg>=0"
        'End If

        If strShortName <> "" Then
            strAdjustBkg = strAdjustBkg & " and ShortName='" & strShortName & "'"
        End If
        lstQuerries.Add(strAdjustBkg)

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Uncompleted Incentive calculation for Customer for month " & intMonth)
            Return False
        Else
            Return True
        End If
    End Function
    Private Function SumBkg4ContactGrouprMonth(strRegion As String, intYear As Integer, intMonth As Integer _
                                           , Optional strShortName As String = "") As Boolean
        Dim strValidDate As String = CreateFromDate(DateSerial(intYear, intMonth, 1))
        Dim lstQuerries As New List(Of String)
        
        Dim strSumBkg As String
        Dim strAdjustBkg As String
        Dim strGetLeftOver As String = ""
        
        Dim intQuarter As Integer = ConvertMonth2Quarter(intMonth)
        ''Tinh bkg thang

        strSumBkg = "Insert Data1A_IncentiveSumBkg (Source,Region,IncType,Object,TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,Bkg,ValidDate,FstUser) " _
                    & " Select 'ALL','" & strRegion & "','ContactGroup',TimeFrame,ShortName,CalcYear,CalcQuarter" _
                    & ",BookYear,Period,SUM(Bkg),ValidDate,'" & pobjUser.UserName _
                    & "' from Data1A_IncentiveSumBkg where Status='OK' and Source in ('ALLSTATS','HX')" _
                    & " and Object='Customer' and TimeFrame='Month'" _
                    & " and BookYear =" & intYear & " and Period=" & intMonth _
                    & " and Region='" & strRegion & "'"

        If strShortName <> "" Then
            strSumBkg = strSumBkg & " and ShortName='" & strShortName & "'"
        End If
        strSumBkg = strSumBkg & " group by ShortName,IncType,Object,TimeFrame,BookYear,CalcYear,CalcQuarter,Period,ValidDate"

        'tinh tong bkg thang
        lstQuerries.Add(strSumBkg)

        If strShortName <> "" Then
            strAdjustBkg = strAdjustBkg & " and ShortName='" & strShortName & "'"
        End If
        lstQuerries.Add(strAdjustBkg)

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Uncompleted Incentive calculation for ContactGroup month " & intMonth)
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CalcBkgIncentive4Contact(intCalcYear As Integer, intCalcQuarter As Integer _
                                , Optional strShortName As String = "" _
                                , Optional intContactId As Integer = 0)
        Dim i As Integer
        'Tinh incentive thang
        For i = intCalcQuarter * 3 - 2 To intCalcQuarter * 3
            If Not CalcBkgIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                    , "Month", i, intCalcQuarter, strShortName,) Then
                Return False
            End If
        Next
        If Not CalcBkgIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                , "Quarter", intCalcQuarter, intCalcQuarter, strShortName) Then
            Return False
        End If
        Select Case intCalcQuarter
            Case 2
                If Not CalcBkgIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
            Case 4
                If Not CalcBkgIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
                If Not CalcBkgIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                        , "Year", 1, intCalcQuarter, strShortName) Then
                    Return False
                End If
        End Select
        Return True
    End Function
    Private Function CalcTktIncentive4ContactTimeFrame(strRegion As String, intYear As Integer _
                        , strTimeFrame As String, intPeriod As Integer _
                        , intCalcQuarter As Integer _
                        , Optional strShortName As String = "" _
                        , Optional intContactId As Integer = 0) As Boolean
        Dim tblOffer As DataTable
        Dim i As Integer
        Dim strQuerryOffer As String
        Dim strFromDate As String = String.Empty
        Dim strToDate As String = String.Empty
        Dim intYear4LastPeriod As Integer
        Dim intPeriod4LastPeriod As Integer
        Dim tblFormula As DataTable
        Dim lstQuerries As New List(Of String)
        Dim strFilterTktInc As String = " and o.OfferId in (Select Val From Data1A_Misc" _
                & " where Cat='OfferFormula' and Val1 in (Select RecId from Data1a_IncentiveFormula where Unit='Ticket'))"

        Select Case strTimeFrame
            Case "Month"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(1).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 12
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "Quarter"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 3 - 2, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(3).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 4
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "HalfYear"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 6 - 5, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(6).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 2
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "Year"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(12).AddDays(-1))
                intYear4LastPeriod = intYear - 1
                intPeriod4LastPeriod = 1

        End Select

        strQuerryOffer = "Select c2.ContactId, o.*, isnull(s.Bkg,0) as TktAll" _
            & ", isnull(s2.Bkg,0) as TktOwn" _
            & ", isnull(s3.Bkg,0) as TktNonOwn" _
            & " from Data1a_IncentiveOffer o" _
            & " left join Data1a_Customers c on c.ShortName=o.ShortName" _
            & " And c.Status='OK' and C.Region='" & pobjUser.Region & "'" _
            & " left join Data1a_IncentiveSumBkg s on o.ShortName=s.ShortName" _
            & " and s.Object='Contact' and s.Source='TKT' and s.IncType='All'" _
            & " And s.TimeFrame='" & strTimeFrame _
            & "' and s.BookYear=" & intYear & " and s.Period=" & intPeriod _
            & " left join Data1a_IncentiveSumBkg s2 on o.ShortName=s2.ShortName" _
            & " and s2.ContactId=s.ContactId" _
            & " and s2.Object='Contact' and s2.Source='TKT' and s2.IncType='NonOwn'" _
            & " And s2.TimeFrame='" & strTimeFrame _
            & "' and s2.BookYear=" & intYear & " and s2.Period=" & intPeriod _
            & " left join Data1a_IncentiveSumBkg s3 on o.ShortName=s3.ShortName" _
            & " and s3.Object='Contact' and s3.Source='TKT' and s3.IncType='All'" _
            & " and s3.ContactId=s.ContactId" _
            & " And s3.TimeFrame='" & strTimeFrame _
            & "' and s3.BookYear=" & intYear & " and s3.Period=" & intPeriod _
            & " left join Data1a_Contacts c2 on s.ContactId=c2.ContactId And c2.Status='OK' " _
            & " where o.Status='OK' and o.Object='Contact'" _
            & " and o.TimeFrame='" & strTimeFrame _
            & "' and '" & strFromDate & "' between ValidFrom and ValidTo" _
            & " and (CalcUpTo4Tkt is null or CalcUpTo4Tkt <'" & strFromDate & "')" _
            & strFilterTktInc

        If strShortName <> "" Then
            strQuerryOffer = strQuerryOffer & " and o.ShortName='" & strShortName & "'"
        End If
        If intContactId <> 0 Then
            strQuerryOffer = strQuerryOffer & " and o.ContactId=" & intContactId
        End If
        strQuerryOffer = strQuerryOffer & " order by o.ShortName"

        tblOffer = pobjSql.GetDataTable(strQuerryOffer)

        For i = 0 To tblOffer.Rows.Count - 1
            Dim objOffer As DataRow = tblOffer.Rows(i)
            Dim decIncentive As Decimal = 0
            Dim intFormulaId As Integer = 0
            Dim intTktCount As Integer = 0

            Select Case objOffer("TktOwn") + objOffer("TktNonOwn") + objOffer("TktAll")
                Case 0
                    decIncentive = 0
                Case Else
                    tblFormula = pobjSql.GetDataTable("Select * from Data1a_IncentiveFormula" _
                                           & " where Unit='Ticket'" _
                                           & " And RecId in (Select Val1 from Data1a_Misc where cat='OfferFormula'" _
                                           & "and val=" & objOffer("OfferId") _
                                           & ") order by ObjectTarget Desc")
                    If tblFormula.Rows.Count = 0 Then
                        decIncentive = 0
                    Else
                        For Each objFormula As DataRow In tblFormula.Rows
                            Dim blnMatchRow As Boolean
                            Dim strIncType As String = String.Empty
                            intTktCount = 0
                            Select Case objFormula("BkgOffcId")
                                Case "Own"
                                    intTktCount = objOffer("TktOwn")
                                    strIncType = "Own"
                                Case "NonOwn"
                                    intTktCount = objOffer("TktNonOwn")
                                    strIncType = "NonOwn"
                                Case "All"
                                    intTktCount = objOffer("TktAll")
                                    strIncType = "All"
                            End Select

                            If objFormula("ObjectTarget") <= intTktCount Then
                                Dim intTktCount4Customer As Integer
                                Dim intPeriod4Customer As Integer

                                intPeriod4Customer = GetPeriod4Customer(strTimeFrame _
                                        , intPeriod, objFormula("CustomerTimeFrame"))
                                intTktCount4Customer = pobjSql.GetScalarAsDecimal(
                                    "Select isnull(sum(Bkg),0) from Data1a_IncentiveSumBkg" _
                                    & " where ShortName='" & objOffer("ShortName") _
                                    & "' and Source='Tkt' and IncType='" & strIncType _
                                    & "' and TimeFrame='" & objFormula("CustomerTimeFrame") _
                                    & "' and BookYear=" & intYear & " and Period=" _
                                    & intPeriod4Customer _
                                    & " and ContactId=" & objOffer("ContactId"))
                                blnMatchRow = True
                            Else
                                Continue For
                            End If

                            If blnMatchRow Then
                                If objFormula("ApplyTo") = "TimeFrame" Then
                                    decIncentive = objFormula("VND")
                                    intFormulaId = objFormula("RecId")
                                ElseIf objFormula("ApplyTo") = "Unit" Then
                                    decIncentive = objFormula("VND") _
                                        * (intTktCount \ objFormula("BlockOf"))
                                    intFormulaId = objFormula("RecId")
                                End If
                                Exit For
                            End If
                        Next
                    End If

            End Select

            If i = tblOffer.Rows.Count - 1 Then
                lstQuerries.Add("Update Data1a_IncentiveOffer set CalcUpTo='" _
                                & strToDate & "' where Recid=" & objOffer("RecId"))
            ElseIf tblOffer.Rows(i + 1)("OfferId") <> objOffer("OfferId") Then
                lstQuerries.Add("Update Data1a_IncentiveOffer set CalcUpTo='" _
                                & strToDate & "' where Recid=" & objOffer("RecId"))
            End If

            If decIncentive <> 0 Then
                lstQuerries.Add("insert into Data1a_IncentiveCalc (Region, ShortName" _
                                & ", ContactId, IncType, Object, Unit, Bkg, VND" _
                                & ", OfferID, FormulaID, CalcYear, CalcQuarter" _
                                & ", BookYear, TimeFrame, Period, Status, FstUser" _
                                & ") values ('" & pobjUser.Region _
                                & "','" & objOffer("ShortName") & "'," & objOffer("ContactId") _
                                & ",'AUTO','Contact','Ticket'," & intTktCount _
                                & "," & decIncentive & "," & objOffer("OfferId") _
                                & "," & intFormulaId & "," & intYear _
                                & "," & intCalcQuarter & "," & intYear _
                                & ",'" & strTimeFrame & "'," & intPeriod _
                                & ",'OK','" & pobjUser.UserName & "')")
            End If
        Next

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox(String.Format("Uncompleted Contact Ticket Incentive calculation for Year {0} {1} {2}" _
                                 , intYear, strTimeFrame, intPeriod))
            Return False
        Else
            Return True
        End If
    End Function
    Private Function CalcTktIncentive4CustomerTimeFrame(strRegion As String, intYear As Integer _
                                        , strTimeFrame As String, intPeriod As Integer _
                                        , intCalcQuarter As Integer _
                                        , Optional strShortName As String = "") As Boolean
        Dim tblOffer As DataTable
        'Dim i As Integer
        Dim strQuerryOffer As String
        Dim strFromDate As String = String.Empty
        Dim strToDate As String = String.Empty
        Dim intYear4LastPeriod As Integer
        Dim intPeriod4LastPeriod As Integer
        Dim tblFormula As DataTable
        Dim lstQuerries As New List(Of String)
        Dim strFilterTktInc As String = " and o.OfferId in (Select Val From Data1A_Misc" _
                & " where Cat='OfferFormula' and Val1 in (Select RecId from Data1a_IncentiveFormula where Unit='Ticket'))"

        Select Case strTimeFrame
            Case "Month"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(1).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 12
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "Quarter"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 3 - 2, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(3).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 4
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "HalfYear"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 6 - 5, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(6).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 2
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "Year"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(12).AddDays(-1))
                intYear4LastPeriod = intYear - 1
                intPeriod4LastPeriod = 1

        End Select

        strQuerryOffer = "Select o.*, isnull(s.Bkg,0) as TktOwn" _
            & ", isnull(s2.Bkg,0) as TktNonOwn" _
            & ", isnull(s3.Bkg,0) as TktAll" _
            & " from Data1a_IncentiveOffer o" _
            & " left join Data1a_misc m on o.TimeFrame=m.Val And m.Cat='TimeFrame'" _
            & " left join Data1a_Customers c on c.ShortName=o.ShortName" _
            & " And c.Status='OK' and C.Region='" & pobjUser.Region & "'" _
            & " left join Data1a_IncentiveSumBkg s on o.ShortName=s.ShortName" _
            & " and s.Object='Customer' and s.Source='TKT' and s.IncType='Own'" _
            & " And s.TimeFrame='" & strTimeFrame _
            & "' and s.BookYear=" & intYear & " and s.Period=" & intPeriod _
            & " left join Data1a_IncentiveSumBkg s2 on o.ShortName=s2.ShortName" _
            & " and s2.Object='Customer' and s2.Source='TKT' and s2.IncType='NonOwn'" _
            & " And s2.TimeFrame='" & strTimeFrame _
            & "' and s2.BookYear=" & intYear & " and s2.Period=" & intPeriod _
            & " left join Data1a_IncentiveSumBkg s3 on o.ShortName=s3.ShortName" _
            & " and s3.Object='Customer' and s3.Source='TKT' and s3.IncType='All'" _
            & " And s3.TimeFrame='" & strTimeFrame _
            & "' and s3.BookYear=" & intYear & " and s3.Period=" & intPeriod _
            & " where o.Status='OK' and o.Object='Customer'" _
            & " and o.TimeFrame='" & strTimeFrame _
            & "' and '" & strFromDate & "' between ValidFrom and ValidTo" _
            & " and (CalcUpTo4Tkt is null or CalcUpTo4Tkt <'" & strFromDate & "')" _
            & strFilterTktInc

        If strShortName <> "" Then
            strQuerryOffer = strQuerryOffer & " and o.ShortName='" & strShortName & "'"
        End If
        strQuerryOffer = strQuerryOffer & " order by o.ShortName,m.val1"

        tblOffer = pobjSql.GetDataTable(strQuerryOffer)

        For Each objOffer As DataRow In tblOffer.Rows
            Dim decIncentive As Decimal = 0
            Dim intFormulaId As Integer = 0
            Dim intTktCount As Integer = 0

            Select Case objOffer("TktOwn") + objOffer("TktNonOwn") + objOffer("TktAll")
                Case 0
                    decIncentive = 0
                Case Else
                    tblFormula = pobjSql.GetDataTable("Select * from Data1a_IncentiveFormula" _
                                           & " where Unit='Ticket'" _
                                           & " And RecId in (Select Val1 from Data1a_Misc where cat='OfferFormula'" _
                                           & "and val=" & objOffer("OfferId") _
                                           & ") order by ObjectTarget Desc")
                    If tblFormula.Rows.Count = 0 Then
                        decIncentive = 0
                    Else
                        For Each objFormula As DataRow In tblFormula.Rows
                            Dim blnMatchRow As Boolean

                            intTktCount = 0
                            Select Case objFormula("BkgOffcId")
                                Case "Own"
                                    intTktCount = objOffer("TktOwn")
                                Case "NonOwn"
                                    intTktCount = objOffer("TktNonOwn")
                                Case "All"
                                    intTktCount = objOffer("All")
                            End Select

                            If objFormula("ObjectTarget") <= intTktCount Then
                                blnMatchRow = True
                            Else
                                Continue For
                            End If

                            If blnMatchRow Then
                                If objFormula("ApplyTo") = "TimeFrame" Then
                                    decIncentive = objFormula("VND")
                                    intFormulaId = objFormula("RecId")
                                ElseIf objFormula("ApplyTo") = "Unit" Then
                                    decIncentive = objFormula("VND") _
                                        * (intTktCount \ objFormula("BlockOf"))
                                    intFormulaId = objFormula("RecId")
                                End If
                                Exit For
                            End If
                        Next
                    End If

            End Select
            lstQuerries.Add("Update Data1a_IncentiveOffer set CalcUpTo4Tkt='" _
                                & strToDate & "' where Recid=" & objOffer("RecId"))
            If decIncentive <> 0 Then
                lstQuerries.Add("insert into Data1a_IncentiveCalc (Region, ShortName" _
                                & ", ContactId, IncType, Object, Unit, Bkg, VND" _
                                & ", OfferID, FormulaID, CalcYear, CalcQuarter" _
                                & ", BookYear, TimeFrame, Period, Status, FstUser" _
                                & ") values ('" & pobjUser.Region & "','" & objOffer("ShortName") _
                                & "',0,'AUTO','Customer','Ticket'," & intTktCount _
                                & "," & decIncentive & "," & objOffer("OfferId") _
                                & "," & intFormulaId & "," & intYear _
                                & "," & intCalcQuarter & "," & intYear _
                                & ",'" & strTimeFrame & "'," & intPeriod _
                                & ",'OK','" & pobjUser.UserName & "')")
            End If
        Next

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox(String.Format("Uncompleted Customer Ticket Incentive calculation for Year {0} {1} {2}" _
                                 , intYear, strTimeFrame, intPeriod))
            Return False
        Else
            Return True
        End If
    End Function
    'Private Function CalcTktIncentive4CustomerTimeFrame(strRegion As String, intYear As Integer, strTimeFrame As String, intPeriod As Integer _
    '                                        , Optional strShortName As String = "") As Boolean
    '    Dim lstQuerries As New List(Of String)
    '    Dim strCalcIncentive As String

    '    'Return True
    '    Dim strValidDate As String
    '    strValidDate = GetValidDate4Incentive(intYear, strTimeFrame, intPeriod)

    '    strCalcIncentive = "insert Data1A_Incentivecalc (Unit,Region,ShortName, IncType, Object, Bkg" _
    '                    & ", TimeFrame,CalcYear,CalcQuarter,BookYear, Period, VND, OfferID, FormulaID,FstUser)" _
    '                    & " select 'Ticket',s.region, s.ShortName, s.IncType, s.Object, s.AdjustedBkg, s.TimeFrame" _
    '                    & ", s.CalcYear, s.CalcQuarter, s.BookYear, s.Period" _
    '                    & ", (case f.ApplyTo when 'timeframe' then f.VND else AdjustedBkg*f.VND end) as VND" _
    '                    & ", o.OfferId, f.RecID as FormulaId,'" & pobjUser.UserName _
    '                    & "' from Data1A_IncentiveSumBkg s" _
    '                    & " left join Data1A_IncentiveOffer o" _
    '                    & " on o.OBJECT=s.Object and o.ShortName=s.ShortName " _
    '                    & " and o.TimeFrame=s.TimeFrame" _
    '                    & " left join DATA1A_MISC m on m.CAT='offerformula' and m.VAL=o.OfferId" _
    '                    & " left join Data1A_IncentiveFormula f on f.RecID=m.VAL1 and f.ObjectTarget<=AdjustedBkg" _
    '                    & " and f.BkgOffcId=s.Inctype" _
    '                    & " where s.Status='OK' and s.Source='TKT' and s.Object='Customer' and s.Region='" & strRegion _
    '                    & "' and s.BookYear=" & intYear & " and s.TimeFrame='" & strTimeFrame & "' and Period=" & intPeriod _
    '                    & " and o.Object='Customer' and o.status ='ok'" _
    '                    & " and '" & strValidDate & "' between o.ValidFrom and o.ValidTo" _
    '                    & " and f.ObjectTarget = (select MAX (ObjectTarget) from Data1A_IncentiveFormula a " _
    '                    & " where a.Unit='ticket' and a.ObjectTarget<=s.AdjustedBkg and a.BkgOffcId=s.Inctype " _
    '                    & " and cast(a.RecID as varchar)  in (select VAL1 from DATA1A_MISC where CAT='OfferFormula'" _
    '                    & " and VAL = o.offerid))" _
    '                    & " and f.Unit='ticket'"

    '    If strShortName <> "" Then
    '        strCalcIncentive = strCalcIncentive & " and s.ShortName='" & strShortName & "'"
    '    End If
    '    strCalcIncentive = strCalcIncentive & " order by s.ShortName,s.CalcQuarter,s.TimeFrame,s.Period"

    '    lstQuerries.Add(strCalcIncentive)

    '    If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
    '        MsgBox(String.Format("Uncompleted Customer Ticket Incentive calculation for Year {0} {1} {2}" _
    '                             , intYear, strTimeFrame, intPeriod))
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function
    Private Function ResetCalcDate4OfferByTimeFrame(strRegion As String, intYear As Integer _
                                            , strTimeFrame As String, intPeriod As Integer _
                                            , intCalcQuarter As Integer _
                                            , Optional strShortName As String = "") As Boolean

        Dim strQuerryOffer As String
        Dim strFromDate As String = String.Empty
        Dim strToDate As String = String.Empty
        Dim strCalcUpToDate As String = String.Empty
        Dim strShortNameFilter As String

        Select Case strTimeFrame
            Case "Month"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(1).AddDays(-1))
                strCalcUpToDate = CreateFromDate(CDate(strFromDate).AddDays(-1))

            Case "Quarter"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 3 - 2, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(3).AddDays(-1))
                strCalcUpToDate = CreateFromDate(CDate(strFromDate).AddDays(-1))

            Case "HalfYear"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 6 - 5, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(6).AddDays(-1))
                If intCalcQuarter = 1 Or intCalcQuarter = 3 Then
                    Return True
                Else
                    strCalcUpToDate = CreateFromDate(CDate(strFromDate).AddDays(-1).AddMonths(-3))
                End If
            Case "Year"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(12).AddDays(-1))
                If intCalcQuarter = 4 Then
                    strCalcUpToDate = CreateFromDate(CDate(strFromDate).AddDays(-1).AddMonths(-9))
                Else
                    Return True
                End If
        End Select

        strShortNameFilter = " and ShortName in (Select distinct ShortName from Data1a_Customers" _
            & " where Status  in ('OK','EX') and Region='" & pobjUser.Region & "') "
        strQuerryOffer = "Update Data1a_IncentiveOffer" _
            & " set CalcUpto='" & strCalcUpToDate & "',CalcUpTo4Tkt='" & strCalcUpToDate & "'" _
            & " where Status='OK' " & strShortNameFilter _
            & " and TimeFrame='" & strTimeFrame & "'" _
            & " and CalcUpTo>='" & strFromDate & "'" _
            & " and '" & strFromDate & "' between ValidFrom and ValidTo"

        If strShortName <> "" Then
            strQuerryOffer = strQuerryOffer & " and ShortName='" & strShortName & "'"
        End If
        If pobjSql.ExecuteNonQuerry(strQuerryOffer) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function CalcBkgIncentive4CustomerTimeFrame(strRegion As String, intYear As Integer, strTimeFrame As String, intPeriod As Integer _
                                        , intCalcQuarter As Integer _
                                        , Optional strShortName As String = "") As Boolean
        Dim tblOffer As DataTable
        'Dim i As Integer
        Dim strQuerryOffer As String
        Dim strFromDate As String = String.Empty
        Dim strToDate As String = String.Empty
        Dim intYear4LastPeriod As Integer
        Dim intPeriod4LastPeriod As Integer
        Dim tblFormula As DataTable
        Dim lstQuerries As New List(Of String)


        Select Case strTimeFrame
            Case "Month"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(1).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 12
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "Quarter"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 3 - 2, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(3).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 4
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "HalfYear"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 6 - 5, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(6).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 2
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "Year"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(12).AddDays(-1))
                intYear4LastPeriod = intYear - 1
                intPeriod4LastPeriod = 1

        End Select

        strQuerryOffer = "Select o.*, isnull(s.Bkg,0) as Bkg" _
            & ", isnull(s2.Bkg,0) as Bkg4LastPeriod" _
            & " from Data1a_IncentiveOffer o" _
            & " left join Data1a_misc m on o.TimeFrame=m.Val And m.Cat='TimeFrame'" _
            & " left join Data1a_Customers c on c.ShortName=o.ShortName" _
            & " And c.Status='OK' and C.Region='" & pobjUser.Region _
            & "' left join Data1a_IncentiveSumBkg s on o.ShortName=s.ShortName" _
            & " and s.Object='Customer' and s.Source='ALL' and s.TimeFrame='" & strTimeFrame _
            & "' and s.BookYear=" & intYear & " and s.Period=" & intPeriod _
            & " left join Data1a_IncentiveSumBkg s2 on o.ShortName=s2.ShortName" _
            & " and s2.Object='Customer' and s2.Source='ALL' and s2.TimeFrame='" & strTimeFrame _
            & "' and s2.BookYear=" _
            & intYear4LastPeriod & " and s2.Period=" & intPeriod4LastPeriod _
            & " where o.Status='OK' and o.Object='Customer'" _
            & " and o.TimeFrame='" & strTimeFrame _
            & "' and '" & strFromDate & "' between ValidFrom and ValidTo" _
            & " and (CalcUpTo is null or CalcUpTo <'" & strFromDate & "')"

        If strShortName <> "" Then
            strQuerryOffer = strQuerryOffer & " and o.ShortName='" & strShortName & "'"
        End If
        strQuerryOffer = strQuerryOffer & " order by o.ShortName,m.val1"

        tblOffer = pobjSql.GetDataTable(strQuerryOffer)

        For Each objOffer As DataRow In tblOffer.Rows
            Dim decIncentive As Decimal = 0
            Dim decIncLastPeriod As Decimal
            Dim decAdhLastPeriod As Decimal
            Dim intFormulaId As Integer = 0

            Select Case objOffer("Bkg")
                Case 0
                    decIncentive = 0
                Case > 0
                    tblFormula = pobjSql.GetDataTable("Select top 1 * from Data1a_IncentiveFormula" _
                                           & " where Unit='Segment'" _
                                           & " And RecId in (Select Val1 from Data1a_Misc where cat='OfferFormula'" _
                                           & "and val=" & objOffer("OfferId") _
                                           & ") and ObjectTarget <=" & objOffer("Bkg") _
                                           & " order by ObjectTarget Desc")
                    If tblFormula.Rows.Count = 0 Then
                        decIncentive = 0
                    ElseIf tblFormula.Rows(0)("ApplyTo") = "TimeFrame" Then
                        decIncentive = tblFormula.Rows(0)("VND")
                        intFormulaId = tblFormula.Rows(0)("RecId")
                    ElseIf tblFormula.Rows(0)("ApplyTo") = "Unit" Then
                        decIncentive = tblFormula.Rows(0)("VND") _
                                * (objOffer("bkg") \ tblFormula.Rows(0)("BlockOf"))
                        intFormulaId = tblFormula.Rows(0)("RecId")
                    End If
                Case < 0
                    decIncLastPeriod = pobjSql.GetScalarAsDecimal("select isnull(sum(VND),0)" _
                                & " from Data1a_IncentiveCalc where Unit='Segment'" _
                                & " And Object='Customer'" _
                                & " and ShortName='" & objOffer("ShortName") _
                                & "' and TimeFrame='" & strTimeFrame _
                                & "' and BookYear=" & intYear4LastPeriod _
                                & " and Period=" & intPeriod4LastPeriod)
                    decAdhLastPeriod = pobjSql.GetScalarAsDecimal("select isnull(sum(VND),0)" _
                                & " from Data1a_IncentiveAdhoc where Unit='Segment'" _
                                & " And Object='Customer'" _
                                & " and ShortName='" & objOffer("ShortName") _
                                & "' and TimeFrame='" & strTimeFrame _
                                & "' and BookYear=" & intYear4LastPeriod _
                                & " and Period=" & intPeriod4LastPeriod)
                    If (decIncLastPeriod + decAdhLastPeriod) < 0 Then
                        decIncentive = 0
                    ElseIf objOffer("Bkg4LastPeriod") = 0 Then
                        decIncentive = (decIncLastPeriod + decAdhLastPeriod)
                    Else
                        decIncentive = ((decIncLastPeriod + decAdhLastPeriod) _
                                / objOffer("Bkg4LastPeriod")) * objOffer("Bkg")
                    End If
            End Select
            lstQuerries.Add("Update Data1a_IncentiveOffer set CalcUpTo='" _
                                & strToDate & "' where Recid=" & objOffer("RecId"))
            If decIncentive <> 0 Then
                lstQuerries.Add("insert into Data1a_IncentiveCalc (Region, ShortName" _
                                & ", ContactId, IncType, Object, Unit, Bkg, VND" _
                                & ", OfferID, FormulaID, CalcYear, CalcQuarter" _
                                & ", BookYear, TimeFrame, Period, Status, FstUser" _
                                & ") values ('" & pobjUser.Region & "','" & objOffer("ShortName") _
                                & "',0,'AUTO','Customer','Segment'," & objOffer("Bkg") _
                                & "," & decIncentive & "," & objOffer("OfferId") _
                                & "," & intFormulaId & "," & intYear _
                                & "," & intCalcQuarter & "," & intYear _
                                & ",'" & strTimeFrame & "'," & intPeriod _
                                & ",'OK','" & pobjUser.UserName & "')")
            End If
        Next

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox(String.Format("Uncompleted Customer Incentive calculation for Year {0} {1} {2}" _
                                 , intYear, strTimeFrame, intPeriod))
            Return False
        Else
            Return True
        End If
    End Function
    Private Function CalcBkgIncentive4ContactTimeFrame(strRegion As String, intYear As Integer, strTimeFrame As String, intPeriod As Integer _
                            , intCalcQuarter As Integer _
                            , Optional strShortName As String = "" _
                            , Optional intContactId As Integer = 0) As Boolean
        Dim tblOffer As DataTable
        Dim i As Integer
        Dim strQuerryOffer As String
        Dim strFromDate As String = String.Empty
        Dim strToDate As String = String.Empty
        Dim intYear4LastPeriod As Integer
        Dim intPeriod4LastPeriod As Integer
        Dim tblFormula As DataTable
        Dim lstQuerries As New List(Of String)


        Select Case strTimeFrame
            Case "Month"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(1).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 12
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "Quarter"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 3 - 2, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(3).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 4
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "HalfYear"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod * 6 - 5, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(6).AddDays(-1))
                If intPeriod = 1 Then
                    intYear4LastPeriod = intYear - 1
                    intPeriod4LastPeriod = 2
                Else
                    intYear4LastPeriod = intYear
                    intPeriod4LastPeriod = intPeriod - 1
                End If
            Case "Year"
                strFromDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
                strToDate = CreateFromDate(CDate(strFromDate).AddMonths(12).AddDays(-1))
                intYear4LastPeriod = intYear - 1
                intPeriod4LastPeriod = 1

        End Select

        strQuerryOffer = "Select c2.ContactId, o.*, isnull(s.Bkg,0) as Bkg" _
            & ", isnull(s2.Bkg,0) as Bkg4LastPeriod" _
            & " from Data1a_IncentiveOffer o" _
            & " left join Data1a_Customers c on c.ShortName=o.ShortName" _
            & " And c.Status='OK' and C.Region='" & pobjUser.Region _
            & "' left join Data1a_IncentiveSumBkg s On o.ShortName=s.ShortName" _
            & " And s.Object='Contact' and s.Source='ALL' and s.TimeFrame='" & strTimeFrame _
            & "' and s.BookYear=" & intYear & " and s.Period=" & intPeriod _
            & " left join Data1a_Contacts c2 on c2.ContactId=s.ContactId" _
            & " left join Data1a_IncentiveSumBkg s2 on o.ShortName=s2.ShortName" _
            & " and s2.Object='Contact' and s2.Source='ALL' and s2.TimeFrame='" & strTimeFrame _
            & "' and s2.BookYear=" _
            & intYear4LastPeriod & " and s2.Period=" & intPeriod4LastPeriod _
            & " and s2.ContactId=c2.ContactId" _
            & " where o.Status='OK' and o.Object='Contact'" _
            & " and c2.Status='OK'" _
            & " and o.TimeFrame='" & strTimeFrame _
            & "' and '" & strFromDate & "' between ValidFrom and ValidTo" _
            & " and (CalcUpTo is null or CalcUpTo <'" & strFromDate & "')"

        If strShortName <> "" Then
            strQuerryOffer = strQuerryOffer & " and o.ShortName='" & strShortName & "'"
        End If
        If intContactId <> 0 Then
            strQuerryOffer = strQuerryOffer & " and c2.ContactId=" & intContactId
        End If
        strQuerryOffer = strQuerryOffer & " order by o.ShortName,o.OfferId,c2.ContactId"


        tblOffer = pobjSql.GetDataTable(strQuerryOffer)

        For i = 0 To tblOffer.Rows.Count - 1
            Dim objOffer As DataRow = tblOffer.Rows(i)
            Dim decIncentive As Decimal = 0
            Dim decIncLastPeriod As Decimal
            Dim decAdhLastPeriod As Decimal
            Dim intFormulaId As Integer = 0

            Select Case objOffer("Bkg")
                Case 0
                    decIncentive = 0
                Case > 0
                    tblFormula = pobjSql.GetDataTable("Select * from Data1a_IncentiveFormula" _
                                & " where Unit='Segment'" _
                                & " And RecId in (Select Val1 from Data1a_Misc where cat='OfferFormula'" _
                                & "and val=" & objOffer("OfferId") _
                                & ") and ObjectTarget <=" & objOffer("Bkg") _
                                & " order by ObjectTarget Desc,CustomerTarget desc")
                    If tblFormula.Rows.Count = 0 Then
                        decIncentive = 0
                    Else
                        For Each objFormula As DataRow In tblFormula.Rows
                            Dim blnMatchRow As Boolean
                            If objFormula("CustomerTarget") = 0 Then
                                blnMatchRow = True
                            Else
                                blnMatchRow = False
                                Dim intBkgCustomer As Integer
                                Dim intPeriod4CustomerTarget As Integer = 0
                                If objFormula("CustomerTimeFrame") = strTimeFrame Then
                                    intPeriod4CustomerTarget = intPeriod
                                Else
                                    intPeriod4CustomerTarget = GetPeriod4Customer(strTimeFrame _
                                                                    , intPeriod, objFormula("CustomerTimeFrame"))
                                End If
                                If intPeriod4CustomerTarget > 0 Then
                                    intBkgCustomer = pobjSql.GetScalarAsDecimal("Select top 1 isnull(AdjustedBkg,0)" _
                                    & " from Data1a_IncentiveSumBkg" _
                                    & " where Source='ALL' and ShortName='" & objOffer("ShortName") _
                                    & "' and TimeFrame='" & objFormula("CustomerTimeFrame") _
                                    & "' and object='Customer'" _
                                    & " and BookYear=" & intYear _
                                    & " and Period=" & intPeriod4CustomerTarget)
                                    If intBkgCustomer >= objFormula("CustomerTarget") Then
                                        blnMatchRow = True
                                    End If
                                End If
                            End If
                            If blnMatchRow Then

                                If objFormula("ApplyTo") = "TimeFrame" Then
                                    decIncentive = objFormula("VND")
                                    intFormulaId = objFormula("RecId")
                                ElseIf tblFormula.Rows(0)("ApplyTo") = "Unit" Then
                                    decIncentive = objFormula("VND") _
                                    * (objOffer("bkg") \ objFormula("BlockOf"))
                                    intFormulaId = objFormula("RecId")
                                End If
                                Exit For
                            End If

                        Next
                    End If
                Case < 0
                    decIncLastPeriod = pobjSql.GetScalarAsDecimal("select isnull(sum(VND),0)" _
                                & " from Data1a_IncentiveCalc where Unit='Segment'" _
                                & " And Object='Contact' and ContactId=" & objOffer("ContactId") _
                                & " and ShortName='" & objOffer("ShortName") _
                                & "' and TimeFrame='" & strTimeFrame _
                                & "' and BookYear=" & intYear4LastPeriod _
                                & " and Period=" & intPeriod4LastPeriod)
                    decAdhLastPeriod = pobjSql.GetScalarAsDecimal("select isnull(sum(VND),0)" _
                                & " from Data1a_IncentiveAdhoc where Unit='Segment'" _
                                & " And Object='Contact' and ContactId=" & objOffer("ContactId") _
                                & " and ShortName='" & objOffer("ShortName") _
                                & "' and TimeFrame='" & strTimeFrame _
                                & "' and BookYear=" & intYear4LastPeriod _
                                & " and Period=" & intPeriod4LastPeriod)
                    If (decIncLastPeriod + decAdhLastPeriod) < 0 Then
                        decIncentive = 0
                    ElseIf objOffer("Bkg4LastPeriod") = 0 Then
                        decIncentive = (decIncLastPeriod + decAdhLastPeriod)
                    Else
                        decIncentive = ((decIncLastPeriod + decAdhLastPeriod) _
                                / objOffer("Bkg4LastPeriod")) * objOffer("Bkg")
                    End If
            End Select

            If i = tblOffer.Rows.Count - 1 Then
                lstQuerries.Add("Update Data1a_IncentiveOffer set CalcUpTo='" _
                                & strToDate & "' where Recid=" & objOffer("RecId"))
            ElseIf tblOffer.Rows(i + 1)("OfferId") <> objOffer("OfferId") Then
                lstQuerries.Add("Update Data1a_IncentiveOffer set CalcUpTo='" _
                                & strToDate & "' where Recid=" & objOffer("RecId"))
            End If

            If decIncentive <> 0 Then
                lstQuerries.Add("insert into Data1a_IncentiveCalc (Region, ShortName" _
                                & ", ContactId, IncType, Object, Unit, Bkg, VND" _
                                & ", OfferID, FormulaID, CalcYear, CalcQuarter" _
                                & ", BookYear, TimeFrame, Period, Status, FstUser" _
                                & ") values ('" & pobjUser.Region _
                                & "','" & objOffer("ShortName") & "'," & objOffer("ContactId") _
                                & ",'AUTO','Contact','Segment'," & objOffer("Bkg") _
                                & "," & decIncentive & "," & objOffer("OfferId") _
                                & "," & intFormulaId & "," & intYear _
                                & "," & intCalcQuarter & "," & intYear _
                                & ",'" & strTimeFrame & "'," & intPeriod _
                                & ",'OK','" & pobjUser.UserName & "')")
            End If
        Next

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox(String.Format("Uncompleted Contact Incentive calculation for Year {0} {1} {2}" _
                                 , intYear, strTimeFrame, intPeriod))
            Return False
        Else
            Return True
        End If
    End Function
    Public Function CalculateTktIncentiveContact(strRegion As String, intYear As Integer, intFromMonth As Integer, intToMonth As Integer _
                                        , Optional strShortName As String = "", Optional intContactId As Integer = 0) As Boolean

        For i = intFromMonth To intToMonth
            Dim intCalcQuarter As Integer

            If Not SumTkt4ContactMonth(strRegion, intYear, i, strShortName, intContactId) Then
                Return False
                'ElseIf Not CalcTktIncentive4ContactTimeFrame(strRegion, intYear, "Month", i, strShortName) Then  '^_^20220807 mark by 7643
            ElseIf Not CalcTktIncentive4ContactTimeFrame(strRegion, intYear, "Month", i, intCalcQuarter, strShortName) Then  '^_^20220807 modi by 7643
                Return False
            End If

            If i = 3 Or i = 6 Or i = 9 Or i = 12 Then
                intCalcQuarter = ConvertMonth2Quarter(i)
                'Tinh bkg Quarter Customer
                If Not SumTkt4ContactTimeFrame(strRegion, intYear, "Quarter", intCalcQuarter, strShortName) Then
                    Return False
                    'ElseIf Not CalcTktIncentive4ContactTimeFrame(strRegion, intYear, "Quarter", intCalcQuarter, strShortName) Then  '^_^20220807 mark by 7643
                ElseIf Not CalcTktIncentive4ContactTimeFrame(strRegion, intYear, "Quarter", i, intCalcQuarter, strShortName) Then  '^_^20220807 modi by 7643
                    Return False
                End If

                'Tinh bkg HalfYear Customer
                If intCalcQuarter = 2 Or intCalcQuarter = 4 Then
                    If Not SumTkt4ContactTimeFrame(strRegion, intYear, "HalfYear", intCalcQuarter / 2, strShortName) Then
                        Return False
                        'ElseIf Not CalcTktIncentive4ContactTimeFrame(strRegion, intYear, "HalfYear", intCalcQuarter / 2, strShortName) Then   '^_^20220807 mark by 7643
                    ElseIf Not CalcTktIncentive4ContactTimeFrame(strRegion, intYear, "HalfYear", i, intCalcQuarter / 2, strShortName) Then   '^_^20220807 modi by 7643
                        Return False
                    End If
                End If

                'Tinh bkg year Customer
                If intCalcQuarter = 4 Then
                    If Not SumTkt4ContactTimeFrame(strRegion, intYear, "Year", 1, strShortName) Then
                        Return False
                        'ElseIf Not CalcTktIncentive4ContactTimeFrame(strRegion, intYear, "Year", 1, strShortName) Then   '^_^20220807 mark by 7643
                    ElseIf Not CalcTktIncentive4ContactTimeFrame(strRegion, intYear, "Year", 1, intCalcQuarter, strShortName) Then   '^_^20220807 modi by 7643
                        Return False
                    End If

                End If
            End If

        Next

        Return True
    End Function
    Public Function CalculateBkgIncentiveContact(strRegion As String, intYear As Integer, intFromMonth As Integer, intToMonth As Integer _
                                        , Optional strShortName As String = "", Optional intContactId As Integer = 0) As Boolean

        Dim i As Integer

        For i = intFromMonth To intToMonth
            Dim intCalcQuarter As Integer

            If Not SumBkg4ContactMonth(strRegion, intYear, i, strShortName, intContactId) Then
                Return False
            ElseIf Not Adjust4ContactList(strRegion, intYear, i, strShortName, ) Then
                Return False
                'ElseIf Not CalcBkgIncentive4Contact(strRegion, intYear, "Month", i) Then  '^_^20220807 mark by 7643
            ElseIf Not CalcBkgIncentive4Contact(intYear, i, strShortName, intContactId) Then  '^_^20220807 modi by 7643
                Return False
            End If

            If i = 3 Or i = 6 Or i = 9 Or i = 12 Then
                intCalcQuarter = ConvertMonth2Quarter(i)
                'Tinh bkg Quarter Customer
                If Not SumBkg4ContactTimeFrame(strRegion, intYear, "Quarter", intCalcQuarter, strShortName) Then
                    Return False
                    'ElseIf Not CalcBkgIncentive4Contact(strRegion, intYear, "Quarter", intCalcQuarter) Then  '^_^20220807 mark by 7643
                ElseIf Not CalcBkgIncentive4Contact(intYear, intCalcQuarter, strShortName, intContactId) Then  '^_^20220807 modi by 7643
                    Return False
                End If

                'Tinh bkg HalfYear Customer
                If intCalcQuarter = 2 Or intCalcQuarter = 4 Then
                    If Not SumBkg4ContactTimeFrame(strRegion, intYear, "HalfYear", intCalcQuarter / 2, strShortName) Then
                        Return False
                        'ElseIf Not CalcBkgIncentive4Contact(strRegion, intYear, "HalfYear", intCalcQuarter / 2) Then  '^_^20220807 mark by 7643
                    ElseIf Not CalcBkgIncentive4Contact(intYear, intCalcQuarter / 2, strShortName, intContactId) Then  '^_^20220807 modi by 7643
                        Return False
                    End If
                End If

                'Tinh bkg year Customer
                If intCalcQuarter = 4 Then
                    If Not SumBkg4ContactTimeFrame(strRegion, intYear, "Year", 1, strShortName) Then
                        Return False
                        'ElseIf Not CalcBkgIncentive4Contact(strRegion, intYear, "Year", 1) Then  '^_^20220807 mark by 7643
                    ElseIf Not CalcBkgIncentive4Contact(intYear, 1, strShortName, intContactId) Then  '^_^20220807 modi by 7643
                        Return False
                    End If

                End If
            End If

        Next

        Return True
    End Function
    Private Function CalcTktIncentive4Customer(intCalcYear As Integer, intCalcQuarter As Integer _
                                , Optional strShortName As String = "")
        Dim i As Integer
        'Tinh incentive thang
        For i = intCalcQuarter * 3 - 2 To intCalcQuarter * 3
            If Not CalcTktIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                    , "Month", i, intCalcQuarter, strShortName) Then
                Return False
            End If
        Next
        If Not CalcTktIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                , "Quarter", intCalcQuarter, intCalcQuarter, strShortName) Then
            Return False
        End If
        Select Case intCalcQuarter
            Case 2
                If Not CalcTktIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
            Case 4
                If Not CalcTktIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
                If Not CalcTktIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                        , "Year", 1, intCalcQuarter, strShortName) Then
                    Return False
                End If
        End Select
        Return True
    End Function
    Private Function CalcTktIncentive4Contact(intCalcYear As Integer, intCalcQuarter As Integer _
                                , Optional strShortName As String = "")
        Dim i As Integer
        'Tinh incentive thang
        For i = intCalcQuarter * 3 - 2 To intCalcQuarter * 3
            If Not CalcTktIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                    , "Month", i, intCalcQuarter, strShortName) Then
                Return False
            End If
        Next
        If Not CalcTktIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                , "Quarter", intCalcQuarter, intCalcQuarter, strShortName) Then
            Return False
        End If
        Select Case intCalcQuarter
            Case 2
                If Not CalcTktIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
            Case 4
                If Not CalcTktIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
                If Not CalcTktIncentive4ContactTimeFrame(pobjUser.Region, intCalcYear _
                        , "Year", 1, intCalcQuarter, strShortName) Then
                    Return False
                End If
        End Select
        Return True
    End Function
    Public Function CalculateTktIncentiveCustomer(strRegion As String, intYear As Integer, intFromMonth As Integer, intToMonth As Integer _
                                        , Optional strShortName As String = "") As Boolean

        For i = intFromMonth To intToMonth
            Dim intCalcQuarter As Integer

            If Not SumTkt4CustomerMonth(strRegion, intYear, i, strShortName) Then
                Return False
                'ElseIf Not CalcTktIncentive4CustomerTimeFrame(strRegion, intYear, "Month", i, strShortName) Then  '^_^20220807 mark by 7643
            ElseIf Not CalcTktIncentive4CustomerTimeFrame(strRegion, intYear, "Month", i, intCalcQuarter, strShortName) Then  '^_^20220807 modi by 7643
                Return False
            End If

            If i = 3 Or i = 6 Or i = 9 Or i = 12 Then
                intCalcQuarter = ConvertMonth2Quarter(i)
                'Tinh bkg Quarter Customer
                If Not SumTkt4CustomerTimeFrame(strRegion, intYear, "Quarter", intCalcQuarter, strShortName) Then
                    Return False
                    'ElseIf Not CalcTktIncentive4CustomerTimeFrame(strRegion, intYear, "Quarter", intCalcQuarter, strShortName) Then  '^_^20220807 mark by 7643
                ElseIf Not CalcTktIncentive4CustomerTimeFrame(strRegion, intYear, "Quarter", i, intCalcQuarter, strShortName) Then  '^_^20220807 modi by 7643
                    Return False
                End If

                'Tinh bkg HalfYear Customer
                If intCalcQuarter = 2 Or intCalcQuarter = 4 Then
                    If Not SumTkt4CustomerTimeFrame(strRegion, intYear, "HalfYear", intCalcQuarter / 2, strShortName) Then
                        Return False
                        'ElseIf Not CalcTktIncentive4CustomerTimeFrame(strRegion, intYear, "HalfYear", intCalcQuarter / 2, strShortName) Then  '^_^20220807 mark by 7643
                    ElseIf Not CalcTktIncentive4CustomerTimeFrame(strRegion, intYear, "HalfYear", i, intCalcQuarter / 2, strShortName) Then  '^_^20220807 modi by 7643
                        Return False
                    End If
                End If

                'Tinh bkg year Customer
                If intCalcQuarter = 4 Then
                    If Not SumTkt4CustomerTimeFrame(strRegion, intYear, "Year", 1, strShortName) Then
                        Return False
                        'ElseIf Not CalcTktIncentive4CustomerTimeFrame(strRegion, intYear, "Year", 1, strShortName) Then  '^_^20220807 mark by 7643
                    ElseIf Not CalcTktIncentive4CustomerTimeFrame(strRegion, intYear, "Year", 1, intCalcQuarter, strShortName) Then  '^_^20220807 modi by 7643
                        Return False
                    End If

                End If
            End If

        Next

        Return True
    End Function
    Public Function CalculateBkgIncentiveCustomer(strRegion As String, intYear As Integer, intFromMonth As Integer, intToMonth As Integer _
                                        , Optional strShortName As String = "") As Boolean

        For i = intFromMonth To intToMonth
            Dim intCalcQuarter As Integer

            If Not SumBkg4CustomerMonth(strRegion, intYear, i, strShortName) Then
                Return False
            ElseIf strRegion = "South" AndAlso Not Adjust4CustomerList(strRegion, intYear, i, strShortName) Then
                Return False
                'ElseIf Not CalcBkgIncentive4CustomerTimeFrame(strRegion, intYear, "Month", i, strShortName) Then  '^_^20220807 mark by 7643
            ElseIf Not CalcBkgIncentive4CustomerTimeFrame(strRegion, intYear, "Month", i, intCalcQuarter, strShortName) Then  '^_^20220807 modi by 7643
                Return False
            End If

            If i = 3 Or i = 6 Or i = 9 Or i = 12 Then
                intCalcQuarter = ConvertMonth2Quarter(i)
                'Tinh bkg Quarter Customer
                If Not SumBkg4CustomerTimeFrame(strRegion, intYear, "Quarter", intCalcQuarter, strShortName) Then
                    Return False
                    'ElseIf Not CalcBkgIncentive4CustomerTimeFrame(strRegion, intYear, "Quarter", intCalcQuarter, strShortName) Then  '^_^20220807 mark by 7643
                ElseIf Not CalcBkgIncentive4CustomerTimeFrame(strRegion, intYear, "Quarter", i, intCalcQuarter, strShortName) Then  '^_^20220807 modi by 7643
                    Return False
                End If

                'Tinh bkg HalfYear Customer
                If intCalcQuarter = 2 Or intCalcQuarter = 4 Then
                    If Not SumBkg4CustomerTimeFrame(strRegion, intYear, "HalfYear", intCalcQuarter / 2, strShortName) Then
                        Return False
                        'ElseIf Not CalcBkgIncentive4CustomerTimeFrame(strRegion, intYear, "HalfYear", intCalcQuarter / 2, strShortName) Then  '^_^20220807 mark by 7643
                    ElseIf Not CalcBkgIncentive4CustomerTimeFrame(strRegion, intYear, "HalfYear", i, intCalcQuarter / 2, strShortName) Then  '^_^20220807 modi by 7643
                        Return False
                    End If
                End If

                'Tinh bkg year Customer
                If intCalcQuarter = 4 Then
                    If Not SumBkg4CustomerTimeFrame(strRegion, intYear, "Year", 1, strShortName) Then
                        Return False
                        'ElseIf Not CalcBkgIncentive4CustomerTimeFrame(strRegion, intYear, "Year", 1, strShortName) Then  '^_^20220807 mark by 7643
                    ElseIf Not CalcBkgIncentive4CustomerTimeFrame(strRegion, intYear, "Year", i, 1, strShortName) Then  '^_^20220807 modi by 7643
                        Return False
                    End If

                End If
            End If

        Next

        Return True
    End Function
    Public Function CalculateIncentive(strRegion As String, intYear As Integer, intFromMonth As Integer, intToMonth As Integer _
                                        , Optional strShortName As String = "") As Boolean

        If Not CalculateBkgIncentiveCustomer(strRegion, intYear, intFromMonth, intToMonth, strShortName) Then
            Return False
        ElseIf Not CalculateBkgIncentiveContact(strRegion, intYear, intFromMonth, intToMonth, strShortName) Then
            Return False
        ElseIf Not CalculateTktIncentiveCustomer(strRegion, intYear, intFromMonth, intToMonth, strShortName) Then
            Return False
        ElseIf Not CalculateTktIncentiveContact(strRegion, intYear, intFromMonth, intToMonth, strShortName) Then
            Return False
        End If
        Return True
    End Function
    Private Sub btnOK_Click(sender As Object, e As EventArgs) 
        'Dim lstQuerries As New List(Of String)
        'Dim intFromMonth As Integer
        'Dim intToMonth As Integer
        'Dim strMonths As String = " in ("
        'Dim strShortName As String = String.Empty
        'Dim strCheckedMonths As String

        'If cboQuarter.Text = "" Or cboYear.Text = "" Then
        '    MsgBox("You must select Quarter and Year")
        '    Exit Sub
        'End If

        'strCheckedMonths = cboQuarter.Text * 3 & "," & cboQuarter.Text * 3 - 1 & "," & cboQuarter.Text * 3 - 2
        'Dim tblUnFinalizedDates As DataTable
        'tblUnFinalizedDates = pobjSql.GetDataTable("Select Date1 from DATA1A_MiscWzDate" _
        '    & " where Cat='FinalizeAllStats' and VAL<>'OK'" _
        '    & " and Year(Date1)=" & cboYear.Text & " and Month(Date1) in (" & strCheckedMonths _
        '    & ") order by Recid")

        'If tblUnFinalizedDates.Rows.Count > 0 Then
        '    MsgBox("You need to Finalize bookings for " & tblUnFinalizedDates.Rows.Count _
        '        & " days defore CalcIncentive")
        '    Me.Dispose()
        '    Exit Sub
        'End If

        'strShortName = "anhthu"
        'strShortName = ""

        'If pobjSql.GetScalarAsString("Select RecId from Data1A_IncentiveCalc where calcYear=" _
        '                             & cboYear.Text & " and CalcQuarter=" & cboQuarter.Text _
        '                             & " and Region='" & pobjUser.Region & "'") <> "" Then
        '    If MsgBox(String.Format("Incentive for year {0} quarter {1} had been calculated in the past!" _
        '                            & "Do you want to Recalculate?", cboYear.Text, cboQuarter.Text)) = MsgBoxResult.Ok Then
        '        Dim strDeleteBkg As String = "Delete Data1A_IncentiveSumBkg where CalcYear=" & cboYear.Text _
        '                        & " and CalcQuarter=" & cboQuarter.Text
        '        Dim strDeleteIncentive As String = "Delete Data1A_IncentiveCalc where CalcYear=" & cboYear.Text _
        '                        & " and CalcQuarter=" & cboQuarter.Text

        '        If strShortName <> "" Then
        '            strDeleteBkg = strDeleteBkg & " and ShortName='" & strShortName & "'"
        '            strDeleteIncentive = strDeleteIncentive & " and ShortName='" & strShortName & "'"
        '        End If
        '        lstQuerries.Add(strDeleteBkg)
        '        lstQuerries.Add(strDeleteIncentive)
        '        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
        '            MsgBox("Unable to delete Incentive calculation")
        '            Exit Sub
        '        End If
        '    Else
        '        Exit Sub
        '    End If


        'End If

        'intFromMonth = (cboQuarter.Text - 1) * 3 + 1
        'intToMonth = (cboQuarter.Text - 1) * 3 + 3

        ''Tinh bkg Month Customer
        ''DeleteIncentiveCalc("01 jan 2016", "31 mar 2016", strShortName)
        'If Not CalculateIncentive(pobjUser.Region, cboYear.Text, intFromMonth, intToMonth, strShortName) Then
        '    MsgBox(String.Format("Unable to calculate incentive for Year {0} from month {1} to month {2}" _
        '                         , cboYear.Text, intFromMonth, intToMonth))
        'Else
        '    Me.Dispose()
        'End If


    End Sub

    Private Sub frmIncentiveCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DatePart(DateInterval.Quarter, Now) = 1 Then
            cboQuarter.Text = 4
            cboYear.Text = Now.Year - 1
        Else
            cboQuarter.Text = DatePart(DateInterval.Quarter, Now) - 1
            cboYear.Text = Now.Year
        End If
    End Sub


    Private Function CalcBkgIncentive4Customer(intCalcYear As Integer, intCalcQuarter As Integer _
                                , Optional strShortName As String = "")
        Dim i As Integer
        'Tinh incentive thang
        For i = intCalcQuarter * 3 - 2 To intCalcQuarter * 3
            If Not CalcBkgIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                    , "Month", i, intCalcQuarter, strShortName) Then
                Return False
            End If
        Next
        If Not CalcBkgIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                , "Quarter", intCalcQuarter, intCalcQuarter, strShortName) Then
            Return False
        End If
        Select Case intCalcQuarter
            Case 2
                If Not CalcBkgIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
            Case 4
                If Not CalcBkgIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
                If Not CalcBkgIncentive4CustomerTimeFrame(pobjUser.Region, intCalcYear _
                        , "Year", 1, intCalcQuarter, strShortName) Then
                    Return False
                End If
        End Select
        Return True
    End Function
    Private Function ResetCalcDate4Offer(intCalcYear As Integer, intCalcQuarter As Integer _
                                               , Optional strShortName As String = "")
        Dim i As Integer
        'Tinh incentive thang
        For i = intCalcQuarter * 3 To intCalcQuarter * 3 - 2 Step -1
            If Not ResetCalcDate4OfferByTimeFrame(pobjUser.Region, intCalcYear _
                    , "Month", i, intCalcQuarter, strShortName) Then
                Return False
            End If
        Next
        If Not ResetCalcDate4OfferByTimeFrame(pobjUser.Region, intCalcYear _
                , "Quarter", intCalcQuarter, intCalcQuarter, strShortName) Then
            Return False
        End If
        Select Case intCalcQuarter
            Case 2
                If Not ResetCalcDate4OfferByTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
            Case 4
                If Not ResetCalcDate4OfferByTimeFrame(pobjUser.Region, intCalcYear _
                        , "HalfYear", intCalcQuarter / 2, intCalcQuarter, strShortName) Then
                    Return False
                End If
                If Not ResetCalcDate4OfferByTimeFrame(pobjUser.Region, intCalcYear _
                        , "Year", 1, intCalcQuarter, strShortName) Then
                    Return False
                End If
        End Select

        Return True
    End Function
    Private Sub lbkSumBkgTkt_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSumBkgTkt.LinkClicked
        Dim strShortName As String
        Dim strCheckedMonths As String
        Dim intContactId As Integer
        Dim strDupCheck As String = "Select top 1 RecId from Data1a_IncentiveSumBkg"
        Dim strDelete As String = "Delete Data1a_IncentiveSumBkg where CalcYear=" _
            & cboYear.Text & " And CalcQuarter=" & cboQuarter.Text
        strShortName = ""
        'strShortName = "HNHA"
        If cboQuarter.Text = "" Or cboYear.Text = "" Then
            MsgBox("You must select Quarter And Year")
            Exit Sub
        End If

        If strShortName <> "" Then
            strDupCheck = strDupCheck & " where ShortName='" & strShortName & "'"
            strDelete = strDelete & " and ShortName='" & strShortName & "'"
        End If
        If pobjSql.GetScalarAsDecimal(strDupCheck) > 0 Then
            If MsgBox("SumBkgTkt had been done in the past. Do it AGAIN?", vbOKCancel) _
            = vbOK Then
                pobjSql.ExecuteNonQuerry(strDelete)
            Else
                Exit Sub
            End If

        End If
        strCheckedMonths = cboQuarter.Text * 3 & "," & cboQuarter.Text * 3 - 1 & "," & cboQuarter.Text * 3 - 2
        Dim tblUnFinalizedDates As DataTable
        tblUnFinalizedDates = pobjSql.GetDataTable("Select Date1 from DATA1A_MiscWzDate" _
            & " where Cat='FinalizeAllStats' and VAL<>'OK'" _
            & " and Year(Date1)=" & cboYear.Text & " and Month(Date1) in (" & strCheckedMonths _
            & ") order by Recid")

        If tblUnFinalizedDates.Rows.Count > 0 Then
            MsgBox("You need to Finalize bookings for " & tblUnFinalizedDates.Rows.Count _
                & " days defore CalcIncentive")
            Me.Dispose()
            Exit Sub
        End If

        For i = cboQuarter.Text * 3 - 2 To cboQuarter.Text * 3
            If Not SumBkg4CustomerMonth(pobjUser.Region, cboYear.Text, i, strShortName) Then
                Exit Sub
            ElseIf Not SumBkg4ContactMonth(pobjUser.Region, cboYear.Text, i _
                                           , strShortName, intContactId) Then
                Exit Sub
            ElseIf Not SumTkt4CustomerMonth(pobjUser.Region, cboYear.Text, i, strShortName) Then
                Exit Sub
            ElseIf Not SumTkt4ContactMonth(pobjUser.Region, cboYear.Text, i _
                                           , strShortName, intContactId) Then
                Exit Sub
            End If

            If i = 3 Or i = 6 Or i = 9 Or i = 12 Then
                'Tinh bkg Quarter 
                If Not SumBkg4CustomerTimeFrame(pobjUser.Region, cboYear.Text, "Quarter", cboQuarter.Text, strShortName) Then
                    Exit Sub
                ElseIf Not SumBkg4ContactTimeFrame(pobjUser.Region, cboYear.Text _
                            , "Quarter", cboQuarter.Text, strShortName, intContactId) Then
                    Exit Sub
                ElseIf Not SumTkt4CustomerTimeFrame(pobjUser.Region, cboYear.Text, "Quarter", cboQuarter.Text, strShortName) Then
                    Exit Sub
                ElseIf Not SumTkt4ContactTimeFrame(pobjUser.Region, cboYear.Text, "Quarter" _
                            , cboQuarter.Text, strShortName, intContactId) Then
                    Exit Sub
                End If

                'Tinh bkg HalfYear
                If cboQuarter.Text = 2 Or cboQuarter.Text = 4 Then
                    If Not SumBkg4CustomerTimeFrame(pobjUser.Region, cboYear.Text, "HalfYear", cboQuarter.Text / 2, strShortName) Then
                        Exit Sub
                    ElseIf Not SumBkg4ContactTimeFrame(pobjUser.Region, cboYear.Text _
                            , "HalfYear", cboQuarter.Text / 2, strShortName, intContactId) Then
                        Exit Sub
                    ElseIf Not SumTkt4CustomerTimeFrame(pobjUser.Region, cboYear.Text, "HalfYear", cboQuarter.Text, strShortName) Then
                        Exit Sub
                    ElseIf Not SumTkt4ContactTimeFrame(pobjUser.Region, cboYear.Text _
                            , "HalfYear", cboQuarter.Text / 2, strShortName, intContactId) Then
                        Exit Sub
                    End If
                End If
                'Tinh bkg year 
                If cboQuarter.Text = 4 Then
                    If Not SumBkg4CustomerTimeFrame(pobjUser.Region, cboYear.Text, "Year", 1, strShortName) Then
                        Exit Sub
                    ElseIf Not SumBkg4ContactTimeFrame(pobjUser.Region, cboYear.Text _
                                , "Year", 1, strShortName, intContactId) Then
                        Exit Sub
                    ElseIf Not SumTkt4CustomerTimeFrame(pobjUser.Region, cboYear.Text, "Year", cboQuarter.Text, strShortName) Then
                        Exit Sub
                    ElseIf Not SumTkt4ContactTimeFrame(pobjUser.Region, cboYear.Text _
                                , "Year", 1, strShortName, intContactId) Then
                        Exit Sub
                    End If
                End If
            End If
        Next
        MsgBox("SumBkgTkt Completed")
    End Sub

    Private Sub lbkCalcIncentives_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkCalcIncentives.LinkClicked
        Dim strShortName As String = String.Empty
        Dim strFromDate As String
        Dim strToDate As String
        Dim strLastCalcDate As String

        'strShortName = "BTT"

        Dim lstQuerries As New List(Of String)

        strFromDate = CreateFromDate(DateSerial(cboYear.Text, cboQuarter.Text * 3 - 2, 1).AddDays(-1))
        strToDate = CreateToDate(CDate(strFromDate).AddMonths(3).AddDays(-1))
        strLastCalcDate = CreateToDate(CDate(strFromDate).AddDays(-1))

        If pobjSql.GetScalarAsString("Select RecId from Data1A_IncentiveCalc where calcYear=" _
                                     & cboYear.Text & " and CalcQuarter=" & cboQuarter.Text _
                                     & " and Region='" & pobjUser.Region & "'") <> "" Then
            If MsgBox(String.Format("Incentive for year {0} quarter {1} had been calculated in the past!" _
                                    & "Do you want to Recalculate?", cboYear.Text, cboQuarter.Text)) = MsgBoxResult.Ok Then
                Dim strDeleteIncentive As String = "Delete Data1A_IncentiveCalc where CalcYear=" & cboYear.Text _
                                & " and CalcQuarter=" & cboQuarter.Text
                If strShortName <> "" Then
                    strDeleteIncentive = strDeleteIncentive & " And ShortName ='" & strShortName & "'"
                End If
                lstQuerries.Add(strDeleteIncentive)
                If pobjSql.UpdateListOfQuerries(lstQuerries) Then
                    ResetCalcDate4Offer(cboYear.Text, cboQuarter.Text, strShortName)
                Else
                    MsgBox("Unable to delete Incentive calculation")
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If

        If Not CalcBkgIncentive4Customer(cboYear.Text, cboQuarter.Text, strShortName) Then
            MsgBox("Contact NMK for correction")
            Exit Sub
        End If

        If Not CalcBkgIncentive4Contact(cboYear.Text, cboQuarter.Text, strShortName) Then
            MsgBox("Contact NMK for correction")
            Exit Sub
        End If

        If Not CalcTktIncentive4Customer(cboYear.Text, cboQuarter.Text, strShortName) Then
            MsgBox("Contact NMK for correction")
            Exit Sub
        End If

        If Not CalcTktIncentive4Contact(cboYear.Text, cboQuarter.Text, strShortName) Then
            MsgBox("Contact NMK for correction")
            Exit Sub
        End If

    End Sub
End Class