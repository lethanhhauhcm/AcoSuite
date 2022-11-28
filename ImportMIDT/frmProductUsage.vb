Public Class frmProductUsage

    Private Sub frmProductUsage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Now.Month = 1 Then
            cboBookMonth.Text = 12
            cboBookYear.Text = Now.Year - 1
        Else
            cboBookMonth.Text = Now.Month - 1
            cboBookYear.Text = Now.Year
        End If

        pobjSql.LoadCombo(cboProductName, "Select distinct ProductName as Value from DATA1A_Products" _
                          & " where Status='OK' order by ProductName")
        cboProductName.SelectedIndex = 0
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim strFromDate As String
        Dim strToDate As String


        If Not IsNumeric(cboBookMonth.Text) Or Not IsNumeric(cboBookYear.Text) Then
            MsgBox("Invalid Input BookMonth/Year")
            Exit Sub
        End If
        If cboProductName.Text = "" Then
            MsgBox("Invalid ProductName")
            Exit Sub
        End If

        CountProductMonthlyUsage(cboBookYear.Text, cboBookMonth.Text, cboProductName.Text)

    End Sub
    Private Function CountProductMonthlyUsage(intBookYear As Integer, intBookMonth As Integer _
                                              , strProductName As String) As Boolean
        Dim lstQuerries As New List(Of String)
        Dim strFromDate As String, strToDate As String
        Dim intDupCheck As Integer

        strFromDate = CreateFromDate(DateSerial(intBookYear, intBookMonth, 1))
        strToDate = CreateToDate(CDate(strFromDate).AddMonths(1).AddMinutes(-1))

        intDupCheck = pobjSql.GetScalarAsDecimal("Select top 1 RecId from Data1a_ProductUsage" _
                                     & " where Status='OK' and ProductName='" & cboProductName.Text _
                                     & "' and BookYear=" & intBookYear & " and BookMonth=" & intBookMonth)
        If intDupCheck > 0 Then
            If MsgBox("ProductUsage had been Canculcated in the past. Do you want to Recalculate?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                lstQuerries.Add("update Data1a_ProductUsage set Status='XX', LstUpdate=getdate()" _
                                & ",LstUser='" & pobjUser.UserName _
                                & "' where Status='OK' and ProductName='" & cboProductName.Text _
                                & "' and TimeFrame='Month' and BookYear=" & intBookYear _
                                & " and Period=" & intBookMonth)
                lstQuerries.Add("update Data1a_ProductUsage set Status='XX', LstUpdate=getdate()" _
                                & ",LstUser='" & pobjUser.UserName _
                                & "' where Status='OK' and Source='" & cboProductName.Text _
                                & "' and TimeFrame='Month' and BookYear=" & intBookYear _
                                & " and Period=" & intBookMonth)
            Else
                Return False
            End If
        End If

        Select Case strProductName
        '    Case "SECO 1", "SECO 2", "SECO 3", "SECO 4"
        '        Dim intFreeAtcQuerry As Integer
        '        intFreeAtcQuerry = 0 - pobjSql.GetScalarAsDecimal("Select NbrOfUnit from data1a_productpackages" _
        '                                            & " where status='OK' and SubProductName='ATC'" _
        '                                            & " and ProductName='" & strProductName & "'")

        '        lstQuerries.Add("insert data1a_productUsage (ProductName,Source,Region" _
        '                    & ",ShortName,UsageCount,BookYear,TimeFrame,Period,Status" _
        '                    & ",FstUser) select '" & strProductName & "','AUTO+','" & pobjUser.Region _
        '                    & "',shortname, count (recid)," & intBookYear & ",'Month'," & intBookMonth _
        '                    & ",'OK','" & pobjUser.UserName & "'" _
        '                    & " from data1a_productrights" _
        '                    & " where status<>'xx' and product='" & strProductName _
        '                    & "' and region='" & pobjUser.Region _
        '                    & "' and (validto is null or ValidTo >='" & strFromDate & "')" _
        '                    & " and validfrom <='" & strToDate _
        '                    & "' group by shortname")

        '        lstQuerries.Add("insert data1a_productUsage (ProductName,Source,Region" _
        '                    & ",ShortName,UsageCount,BookYear,TimeFrame,Period,Status" _
        '                    & ",FstUser) select 'ATC','" & strProductName & "','" & pobjUser.Region _
        '                    & "',shortname, sum(UsageCount * " & intFreeAtcQuerry & ")," _
        '                    & intBookYear & ",'Month'," & intBookMonth _
        '                    & ",'OK','" & pobjUser.UserName & "'" _
        '                    & " from data1a_productUsage" _
        '                    & " where status<>'xx' and Source='AUTO+' and ProductName='" & strProductName _
        '                    & "' and region='" & pobjUser.Region _
        '                    & "' and TimeFrame='Month' and BookYear=" & intBookYear _
        '                    & " and Period=" & intBookMonth _
        '                    & " group by shortname")

        '        lstQuerries.Add("insert data1a_productUsage (ProductName,Source,Region" _
        '                    & ",ShortName,UsageCount,BookYear,TimeFrame,Period,Status" _
        '                    & ",FstUser) select 'MPE','" & strProductName & "','" & pobjUser.Region _
        '                    & "',shortname, sum(UsageCount * " & intFreeAtcQuerry & ")," _
        '                    & intBookYear & ",'Month'," & intBookMonth _
        '                    & ",'OK','" & pobjUser.UserName & "'" _
        '                    & " from data1a_productUsage" _
        '                    & " where status<>'xx' and Source='AUTO+' and ProductName='" & strProductName _
        '                    & "' and region='" & pobjUser.Region _
        '                    & "' and TimeFrame='Month' and BookYear=" & intBookYear _
        '                    & " and Period=" & intBookMonth _
        '                    & " group by shortname")


            Case "ATC"
                Dim strCheckMissingOid As String = "Select * from Data1a_ATC2 where" _
                    & " Trxyear=" & intBookYear & " And TrxMonth =" & intBookMonth _
                    & " and OffcId not in (Select OffcId from Data1a_OIDs where Status='OK'" _
                    & " and GDS='1A')"
                Dim tblMissingOIDs As New DataTable
                tblMissingOIDs = pobjSql.GetDataTable(strCheckMissingOid)
                If tblMissingOIDs.Rows.Count > 0 Then
                    Dim frmShowError As New frmShowTableContent(tblMissingOIDs, "Missing OffcIDs")
                    frmShowError.ShowDialog()
                    Return False
                End If


                lstQuerries.Add("insert data1a_productUsage (ProductName,Source,Region" _
                            & ",ShortName,UsageCount,BookYear,TimeFrame,Period,Status" _
                            & ",FstUser) select '" & strProductName & "','AUTO+','" & pobjUser.Region _
                            & "',o.shortname, count  (distinct tkno)," _
                            & intBookYear & ",'Month'," & intBookMonth _
                            & ",'OK','" & pobjUser.UserName & "'" _
                            & " from data1a_ATC2 a" _
                            & " left join Data1a_OIDs o on a.OffcId=o.OffcId and o.Status='OK'" _
                            & " And o.Status='OK' and o.GDS='1A'" _
                            & " left join Data1a_Customers c on o.ShortName=c.ShortName" _
                            & " and c.Status='OK'" _
                            & " where c.region='" & pobjUser.Region _
                            & "' and Trxyear=" & intBookYear _
                            & " and TrxMonth =" & intBookMonth _
                            & " group by o.shortname")

            Case "MPE"
                lstQuerries.Add("insert data1a_productUsage (ProductName,Source,Region" _
                            & ",ShortName,UsageCount,BookYear,TimeFrame,Period,Status" _
                            & ",FstUser) select '" & strProductName & "','AUTO+','" & pobjUser.Region _
                            & "',o.shortname, Sum (TrxCounter)," & intBookYear & ",'Month'," & intBookMonth _
                            & ",'OK','" & pobjUser.UserName & "'" _
                            & " from DATA1A_MasterPricer a" _
                            & " left join Data1a_OIDs o on a.OffcId=o.OffcId" _
                            & " left join Data1a_Customers c on o.ShortName=c.ShortName" _
                            & " where o.Status='OK' and c.Status='OK'" _
                            & " and c.region='" & pobjUser.Region _
                            & "' and substring(cast(Trxdate as varchar),1,6) ='" _
                            & intBookYear & intBookMonth.ToString.PadLeft(2, "0") _
                            & "' group by o.shortname")
            Case Else
        End Select

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("ProductUsage Calculation Completed for " & strProductName)
            Return True
        Else
            MsgBox("ProductUsage Calculation NOT Completed for " & strProductName)
            Return False
        End If

    End Function
End Class