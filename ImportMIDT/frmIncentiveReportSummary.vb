Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class frmIncentiveReportSummary

    Private Sub frmIncentiveReportSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DatePart(DateInterval.Quarter, Now) = 1 Then
            cboQuarter.Text = 4
            cboYear.Text = Now.Year - 1
        Else
            cboQuarter.Text = DatePart(DateInterval.Quarter, Now) - 1
            cboYear.Text = Now.Year
        End If
    End Sub
    Private Function Report(strObject As String, objWsh As Worksheet, strRegion As String) As Boolean
        Dim strQuerry As String
        Dim tblIncentive As System.Data.DataTable
        Dim strFields As String
        Dim strTables As String
        Dim strConditions As String
        Dim strGroupBy As String
        Dim intFromMonth As Integer = cboQuarter.Text * 3 - 2
        Dim intToMonth As Integer = cboQuarter.Text * 3
        Dim i As Integer, j As Integer
        Dim strSumIncentive As String
        Dim strSumAdhoc As String
        Dim strSumMinusIncentive As String
        Dim intLastRow As Integer
        Dim intHalfYear As Integer = IIf(cboQuarter.Text > 2, 2, 1)
        strQuerry = ""

        If strObject = "Customer" Then
            strFields = "Select c.shortname,c.AccountNameGB,0 as Contactid,'' as ContactName" _
                    & ",'" & strObject & "' as Object"
            strTables = " from DATA1A_Customers c"

        Else
            strFields = "Select c.shortname,c.AccountNameGB,c1.contactid,isnull(c1.FullNameGB,'') as ContactName" _
                    & ",'" & strObject & "' as Object"
            strTables = " from DATA1A_Customers c" _
                    & " Left join DATA1A_Contacts c1 on c.ShortName=c1.CustShortname " _
                    & "  and c1.Status<>'XX' and c1.ContactId<>0"
        End If
        strConditions = " where c.Status='OK' and c.Region='" & strRegion & "'"

        'strGroupBy = " group by c.shortname,c1.ContactId,c.AccountNameGB,c1.FullNameGB "

        For i = intFromMonth To intToMonth
            CreateQuerry4Seg(strFields, strTables, strConditions, strGroupBy, cboYear.Text, "Month" _
                             , i, strObject)
        Next

        'Tinh BKG cho Quy
        CreateQuerry4Seg(strFields, strTables, strConditions, strGroupBy, cboYear.Text, "Quarter" _
        , cboQuarter.Text, strObject)

        'Tinh BKG cho nua nam

        If cboQuarter.Text = 2 Or cboQuarter.Text = 4 Then
            CreateQuerry4Seg(strFields, strTables, strConditions, strGroupBy, cboYear.Text, "HalfYear" _
                             , cboQuarter.Text / 2, strObject)
        Else
            CreateEmptyColumns4Seg(strFields, cboYear.Text, "HalfYear", (cboQuarter.Text + 1) / 2)
        End If

        'Tinh BKG cho ca nam
        If cboQuarter.Text = 4 Then
            CreateQuerry4Seg(strFields, strTables, strConditions, strGroupBy, cboYear.Text, "Year", 1, strObject)
        Else
            CreateEmptyColumns4Seg(strFields, cboYear.Text, "Year", 1)
        End If

        'Tinh TKT cho thang
        'For i = intFromMonth To intToMonth
        '    CreateQuerry4Tkt(strFields, strTables, strConditions, strGroupBy, cboYear.Text, "Month", i, strObject)
        'Next

        ''Tinh TKT cho Quy
        'CreateQuerry4Tkt(strFields, strTables, strConditions, strGroupBy, cboYear.Text, "Quarter" _
        '                 , cboQuarter.Text, strObject)

        ''Tinh TKT cho nua nam

        'If cboQuarter.Text = 2 Or cboQuarter.Text = 4 Then
        '    CreateQuerry4Tkt(strFields, strTables, strConditions, strGroupBy, cboYear.Text, "HalfYear" _
        '                     , cboQuarter.Text / 2, strObject)
        'Else
        '    CreateEmptyColumns4Tkt(strFields, cboYear.Text, "HalfYear", (cboQuarter.Text + 1) / 2)
        'End If

        ''Tinh TKT cho ca nam
        'If cboQuarter.Text = 4 Then
        '    CreateQuerry4Tkt(strFields, strTables, strConditions, strGroupBy, cboYear.Text, "Year", 1, strObject)
        'Else
        '    CreateEmptyColumns4Tkt(strFields, cboYear.Text, "Year", 1)
        'End If

        strFields = strFields & ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"

        'Tinh tong Incentive
        If strObject = "Customer" Then
            strSumIncentive = "(select isnull(sum(vnd),0) from Data1A_IncentiveCalc" _
                        & " where shortname=C.shortname and object='" & strObject _
                        & "' And ContactId=0 And IncType<>'AUTO-'" _
                        & " and CalcYear = " & cboYear.Text & " and CalcQuarter=" & cboQuarter.Text & ")"
        Else
            strSumIncentive = "(select isnull(sum(vnd),0) from Data1A_IncentiveCalc" _
                        & " where shortname=C.shortname and object='" & strObject _
                        & "' And ContactId=C1.ContactId And IncType<>'AUTO-'" _
                        & " and CalcYear = " & cboYear.Text & " and CalcQuarter=" & cboQuarter.Text & ")"
        End If

        strFields = strFields & "," & strSumIncentive & " as TotalInc"

        'Tinh tong Adhoc
        If strObject = "Customer" Then
            strSumAdhoc = "(select isnull(sum(vnd),0) from Data1A_IncentiveAdhoc" _
            & " where shortname=c.shortname" _
            & " And object='" & strObject _
            & "' And contactid=0 And Status='OK' and BookYear=" & cboYear.Text _
            & " and CalcQuarter=" & cboQuarter.Text & ")"
        Else
            strSumAdhoc = "(select isnull(sum(vnd),0) from Data1A_IncentiveAdhoc" _
            & " where shortname=c.shortname" _
            & " And object='" & strObject _
            & "' And contactid=c1.contactid And Status='OK' and BookYear=" & cboYear.Text _
            & " and CalcQuarter=" & cboQuarter.Text & ")"
        End If

        strFields = strFields & "," & strSumAdhoc & " as Adhoc"

        'Tinh tong Incentive + Adhoc
        strFields = strFields & ",0 as TotalAfterAdhoc"

        'Tinh tong tru Incentive ky truoc
        If strObject = "Customer" Then
            strSumMinusIncentive = "(select isnull(sum(vnd),0) from Data1A_IncentiveCalc" _
                        & " where shortname=c.shortname" _
                        & " And object='" & strObject _
                        & "' And ContactId=0 And IncType='AUTO-'" _
                        & " and CalcYear = " & cboYear.Text & " and CalcQuarter=" & cboQuarter.Text & ")"
            strFields = strFields & "," & strSumMinusIncentive & " as MinusIncentive"
        Else
            strSumMinusIncentive = "(select isnull(sum(vnd),0) from Data1A_IncentiveCalc" _
                        & " where shortname=c.shortname" _
                        & " And object='" & strObject _
                        & "' And ContactId=c1.ContactId And IncType='AUTO-'" _
                        & " and CalcYear = " & cboYear.Text & " and CalcQuarter=" & cboQuarter.Text & ")"
            strFields = strFields & "," & strSumMinusIncentive & " as MinusIncentive"
        End If

        strQuerry = strFields & ",0 as SecoFee" & strTables & strConditions & strGroupBy _
                            & " ORDER BY c.shortname"

        If strObject = "Contact" Then
            strQuerry = strQuerry & ",c1.contactid"
        End If

        tblIncentive = pobjSql.GetDataTable(strQuerry)
        If tblIncentive.Rows.Count > 0 Then

            With objWsh
                For i = 0 To tblIncentive.Columns.Count - 1
                    .Cells(1, i + 1) = tblIncentive.Columns(i).ColumnName
                Next
                For j = intFromMonth To intToMonth
                    .Cells(1, 24 + (j - intFromMonth) * 3) = "OfferIdTktM" & j
                    .Cells(1, 25 + (j - intFromMonth) * 3) = "CountTktM" & j
                    .Cells(1, 26 + (j - intFromMonth) * 3) = "VndTktM" & j
                Next
                .Range("AG1").Value = "OfferIdTktQ" & cboQuarter.Text
                .Range("AH1").Value = "CountTktQ" & cboQuarter.Text
                .Range("AI1").Value = "VndTktQ" & cboQuarter.Text

                .Range("AJ1").Value = "OfferIdTktHY"
                .Range("AK1").Value = "CountTktHY"
                .Range("AL1").Value = "VndTktHY"

                .Range("AM1").Value = "OfferIdTktY" & cboYear.Text
                .Range("AN1").Value = "CountTktY" & cboYear.Text
                .Range("AO1").Value = "VndTktY" & cboYear.Text

                .Range("AP1").Value = "TotalInc"
                .Range("AQ1").Value = "Adhoc"
                .Range("AR1").Value = "TotalAfterAdhoc"
                .Range("AS1").Value = "MinusIncentive"
                .Range("AT1").Value = " SecoFee"

                .Range("AU1").Value = "TotalPayable"
                .Range("AV1").Value = "Per Seg"

                For i = 0 To tblIncentive.Rows.Count - 1
                    objWsh.Range("A" & i + 2 & ":AT" & i + 2).Value = tblIncentive.Rows(i).ItemArray
                    Dim tblTkt As System.Data.DataTable
                    Dim strRange As String

                    'Fill gia tri TKT Monthly
                    For j = intFromMonth To intToMonth
                        tblTkt = GetTkt(cboYear.Text, "Month", intFromMonth, strObject _
                           , objWsh.Range("A" & i + 2).Value, objWsh.Range("c" & i + 2).Value)
                        .Cells(1, 24 + (j - intFromMonth) * 3) = "OfferIdTktM" & j
                        .Cells(1, 25 + (j - intFromMonth) * 3) = "CountTktM" & j
                        .Cells(1, 26 + (j - intFromMonth) * 3) = "VndTktM" & j
                        Select Case j
                            Case 1, 4, 7, 10
                                strRange = "X" & i + 2 & ":Z" & i + 2
                            Case 2, 5, 8, 11
                                strRange = "AA" & i + 2 & ":AC" & i + 2
                            Case 3, 6, 9, 11
                                strRange = "AD" & i + 2 & ":AF" & i + 2
                        End Select

                        If tblTkt.Rows.Count = 0 Then
                            objWsh.Range(strRange).Value = {0, 0, 0}
                        Else
                            objWsh.Range(strRange).Value = tblTkt.Rows(0).ItemArray
                        End If
                    Next

                    'Fill gia tri TKT Quarterly
                    tblTkt = GetTkt(cboYear.Text, "Quarter", cboQuarter.Text, strObject _
                       , objWsh.Range("A" & i + 2).Value, objWsh.Range("c" & i + 2).Value)
                    If tblTkt.Rows.Count = 0 Then
                        objWsh.Range("AG" & i + 2 & ":AI" & i + 2).Value = {"0", "0", "0"}
                    Else
                        objWsh.Range("AG" & i + 2 & ":AI" & i + 2).Value = tblTkt.Rows(0).ItemArray
                    End If

                    'Fill gia tri TKT HalfYear
                    tblTkt = GetTkt(cboYear.Text, "HalfYear", intHalfYear, strObject _
                       , objWsh.Range("A" & i + 2).Value, objWsh.Range("c" & i + 2).Value)
                    If tblTkt.Rows.Count = 0 Then
                        objWsh.Range("AJ" & i + 2 & ":AL" & i + 2).Value = {"0", "0", "0"}
                    Else
                        objWsh.Range("AJ" & i + 2 & ":AL" & i + 2).Value = tblTkt.Rows(0).ItemArray
                    End If

                    'Fill gia tri TKT Year
                    tblTkt = GetTkt(cboYear.Text, "Year", 1, strObject _
                       , objWsh.Range("A" & i + 2).Value, objWsh.Range("c" & i + 2).Value)
                    If tblTkt.Rows.Count = 0 Then
                        objWsh.Range("AM" & i + 2 & ":AO" & i + 2).Value = {"0", "0", "0"}
                    Else
                        objWsh.Range("AM" & i + 2 & ":AO" & i + 2).Value = tblTkt.Rows(0).ItemArray
                    End If

                Next

                .Range("AR" & i + 2).Value = .Range("AQ" & i + 2).Value + .Range("AP" & i + 2).Value

                .Range("AU2").Value = "=Sum(AR" & 2 & ":AT" & 2
                .Range("AV2").FormulaR1C1 = "=RC[-1]/RC[-32]"
                .Range("AU2:AV2").Select()
                intLastRow = .Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                .Range("AU2:AV2").AutoFill(.Range("AU2", "AV" & intLastRow))
                .Columns("A:AV").AUTOFIT()

                If strObject = "Customer" Then

                    intLastRow = intLastRow + 1
                    Dim lngTotalBkg As Long
                    Dim LngTotalBkgNonHX As Long
                    Dim decTotalInc As Decimal

                    lngTotalBkg = pobjSql.GetScalarAsString("Select isnull(Sum (Bkg),0)" _
                                                    & " from Data1a_IncentiveSumBkg" _
                                                    & " where Source='ALL' and Object='Customer'" _
                                                    & " and Region='" & strRegion & "'" _
                                                    & " and CalcYear=" & cboYear.Text & " and CalcQuarter=" & cboQuarter.Text _
                                                    & " and timeframe='month'")
                    LngTotalBkgNonHX = pobjSql.GetScalarAsString("Select isnull(Sum (Bkg),0)" _
                                        & " from Data1a_IncentiveSumBkg" _
                                        & " where Source='ALLSTATS' and Object='Customer' and Region='" & strRegion & "'" _
                                        & " and CalcYear=" & cboYear.Text & " and CalcQuarter=" & cboQuarter.Text)
                    decTotalInc = pobjSql.GetScalarAsString("Select Sum (VND)" _
                                        & " from Data1a_IncentiveCalc" _
                                        & " where Region='" & strRegion _
                                        & "' And CalcYear = " & cboYear.Text & " And CalcQuarter = " & cboQuarter.Text)

                    decTotalInc = decTotalInc + pobjSql.GetScalarAsString("Select isnull(Sum (VND),0)" _
                                        & " from Data1a_IncentiveAdhoc" _
                                        & " where BookYear = " & cboYear.Text & " And CalcQuarter = " & cboQuarter.Text _
                                        & " and ShortName in (Select ShortName from DATA1A_Customers where Status<>'XX'" _
                                        & " and Region='" & strRegion & "')")


                    .Range("A" & intLastRow).Value = "Total Segments (including HX)"
                    .Range("C" & intLastRow).Value = lngTotalBkg
                    .Range("A" & intLastRow + 1).Value = "Total Segments (excluding HX)"
                    .Range("C" & intLastRow + 1).Value = LngTotalBkgNonHX

                    .Range("AV" & intLastRow).Value = "Per Seg incl HX"
                    .Range("AV" & intLastRow + 1).Value = decTotalInc / lngTotalBkg
                    .Range("AV" & intLastRow + 2).Value = "Per Seg excl HX"
                    .Range("AV" & intLastRow + 3).Value = decTotalInc / LngTotalBkgNonHX
                End If

                .Columns("AV:AV").NumberFormat = "0"

            End With
        End If

        Return True
    End Function
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        MsgBox("Report may take over 15 minutes")
        Dim objExcel As New Microsoft.Office.Interop.Excel.Application
        Dim objWsh As Excel.Worksheet
        Dim objWbk As Excel._Workbook
        Dim lstQuerries As New List(Of String)
        Dim dteStart As Date = Now
        objExcel.Visible = False
        objWbk = objExcel.Workbooks.Add
        objWsh = objWbk.ActiveSheet
        objWsh.Name = "Contact"
        Report("Contact", objWsh, pobjUser.Region)

        objWbk.Worksheets.Add()
        objWsh = objWbk.ActiveSheet
        objWsh.Name = "Customer"
        Report("Customer", objWsh, pobjUser.Region)
        objExcel.Visible = True
        MsgBox("Run time in minutes:" & DateDiff(DateInterval.Minute, dteStart, Now))
        LogReport("AcoSuite", "IncentiveSumary", pobjUser.UserName, pobjUser.City)
        Me.Dispose()
    End Sub
    Private Function CreateQuerry4Seg(ByRef strFields As String, ByRef strTables As String, ByRef strConditions As String _
                                  , ByRef strGroupBy As String, intYear As Integer, strTimeFrame As String _
                                  , intPeriod As String, strObject As String) As Boolean

        Dim strIncTable As String = String.Empty
        Dim strBkgTable As String = String.Empty
        Select Case strTimeFrame
            Case "Month"
                strIncTable = "IncBkgM" & intPeriod
                strBkgTable = "BkgM" & intPeriod
            Case "Quarter"
                strIncTable = "IncBkgQ" & intPeriod
                strBkgTable = "BkgQ" & intPeriod
            Case "HalfYear"
                strIncTable = "IncBkgH" & intPeriod
                strBkgTable = "BkgH" & intPeriod
            Case "Year"
                strIncTable = "IncBkgY"
                strBkgTable = "BkgY" & intPeriod
        End Select
        strFields = strFields & ",isnull(" & strIncTable & ".Offerid,'') as Offerid" & strIncTable _
                    & ",isnull(" & strIncTable & ".Bkg,0) as Bkg" & strIncTable _
                    & ",isnull(" & strIncTable & ".VND,0) as VND" & strIncTable

        If strObject = "Customer" Then
            strTables = strTables & " left join (select ShortName,Object,ContactId,SUM(isnull(Bkg,0)) as Bkg,SUM(isnull(VND,0)) as VND,OfferId,FormulaId from Data1A_IncentiveCalc " _
                    & " where BookYear =" & intYear & " And  TimeFrame='" & strTimeFrame _
                    & "' and Period =" & intPeriod _
                    & " And Unit='segment' and IncType='AUTO' " _
                    & " and Object='" & strObject & "' group by ShortName,ContactId,Object,OfferId,FormulaId" _
                    & ")" & strIncTable & " on c.shortname=" & strIncTable & ".ShortName " _
                    & " and " & strIncTable & ".ContactId=0"
        Else
            strTables = strTables & " left join (select ShortName,Object,ContactId,SUM(isnull(Bkg,0)) as Bkg,SUM(isnull(VND,0)) as VND,OfferId,FormulaId from Data1A_IncentiveCalc " _
                    & " where BookYear =" & intYear & " And  TimeFrame='" & strTimeFrame _
                    & "' and Period =" & intPeriod _
                    & " And Unit='segment' and IncType='AUTO' " _
                    & " and Object='" & strObject & "' group by ShortName,ContactId,Object,OfferId,FormulaId" _
                    & ")" & strIncTable & " on c.shortname=" & strIncTable & ".ShortName " _
                    & " and c1.ContactId=" & strIncTable & ".ContactId "
        End If

        Return True
    End Function
    Private Function CreateQuerry4Tkt(ByRef strFields As String, ByRef strTables As String, ByRef strConditions As String _
                                  , ByRef strGroupBy As String, intYear As Integer, strTimeFrame As String _
                                  , intPeriod As String, strObject As String) As Boolean

        Dim strIncTable As String = String.Empty
        Dim strBkgTable As String = String.Empty
        Select Case strTimeFrame
            Case "Month"
                strIncTable = "IncTktM" & intPeriod
                strBkgTable = "TktM" & intPeriod
            Case "Quarter"
                strIncTable = "IncTktQ" & intPeriod
                strBkgTable = "TktQ" & intPeriod
            Case "HalfYear"
                strIncTable = "IncTktH" & intPeriod
                strBkgTable = "TktH" & intPeriod
            Case "Year"
                strIncTable = "IncTktY"
                strBkgTable = "TktY" & intPeriod
        End Select
        Dim strSelectBkgOffcId As String

        'strSelectBkgOffcId = " isnull((select top 1 bkgOffcid from Data1A_IncentiveFormula where unit='ticket' and recid in " _
        '                    & "(select Val1 from Data1A_misc where cat='Offerformula' and Val in" _
        '                    & "(Select OfferId from Data1A_IncentiveOffer ot where ot.status<>'xx' " _
        '                    & " and ot.shortname=s.shortname and s.ValidDate between ot.ValidFrom and ot.validto" _
        '                    & " and s.object=ot.object and s.timeframe=ot.timeframe))),'All') "

        strFields = strFields & ",isnull(" & strIncTable & ".Offerid,'') as OfferId" & strIncTable _
                    & ",sum(isnull(" & strIncTable & ".Bkg,0)) as Seg" & strIncTable _
                    & ",SUM(isnull(" & strIncTable & ".VND,0)) as VND" & strIncTable

        If strObject = "Customer" Then
            strTables = strTables & " left join (SELECT ShortName,ContactId,Sum(Bkg) as bkg, Sum(VND) as VND,FormulaId" _
                    & " from Data1A_IncentiveCalc " _
                    & " where ContactId=0" _
                    & " And BookYear =" & intYear & " And TimeFrame='" & strTimeFrame _
                    & "' and Period =" & intPeriod _
                    & " and Unit='Ticket'" _
                    & " and Object='" & strObject & "'" _
                    & " Group By Shortname,ContactId,OfferId" _
                    & ") " & strIncTable _
                    & " on c.shortname=" & strIncTable & ".ShortName " _
                    & " and " & strIncTable & ".ContactId=0"
        Else
            strTables = strTables & " left join (SELECT ShortName,ContactId,Sum(Bkg) as bkg, Sum(VND) as VND,FormulaId" _
                    & " from Data1A_IncentiveCalc " _
                    & " where ContactId<>0" _
                    & " And BookYear =" & intYear & " And TimeFrame='" & strTimeFrame _
                    & "' and Period =" & intPeriod _
                    & " and Unit='Ticket'" _
                    & " and Object='" & strObject & "'" _
                    & " Group By Shortname,ContactId,OfferId" _
                    & ") " & strIncTable _
                    & " on c.shortname=" & strIncTable & ".ShortName " _
                    & " and c1.ContactId=" & strIncTable & ".ContactId "

        End If


        Return True
    End Function
    Private Function CreateEmptyColumns4Seg(ByRef strFields As String, intYear As Integer, strTimeFrame As String _
                                  , intPeriod As String) As Boolean

        Dim strIncTable As String = String.Empty
        Dim strBkgTable As String = String.Empty
        Select Case strTimeFrame
            Case "Month"
                strIncTable = "IncBkgM" & intPeriod
                strBkgTable = "BkgM" & intPeriod
            Case "Quarter"
                strIncTable = "IncBkgQ" & intPeriod
                strBkgTable = "BkgQ" & intPeriod
            Case "HalfYear"
                strIncTable = "IncBkgH" & intPeriod
                strBkgTable = "BkgH" & intPeriod
            Case "Year"
                strIncTable = "IncBkgY"
                strBkgTable = "BkgY" & intPeriod
        End Select

        strFields = strFields & ",0 as OfferId" & strIncTable _
                    & ",0 as Seg" & strIncTable _
                    & ",0 as VND" & strIncTable
        Return True
    End Function
    Private Function CreateEmptyColumns4Tkt(ByRef strFields As String, intYear As Integer, strTimeFrame As String _
                                  , intPeriod As String) As Boolean

        Dim strIncTable As String = String.Empty
        Dim strBkgTable As String = String.Empty
        Select Case strTimeFrame
            Case "Month"
                strIncTable = "IncTktM" & intPeriod
                strBkgTable = "TktM" & intPeriod
            Case "Quarter"
                strIncTable = "IncTktQ" & intPeriod
                strBkgTable = "TktQ" & intPeriod
            Case "HalfYear"
                strIncTable = "IncTktH" & intPeriod
                strBkgTable = "TktH" & intPeriod
            Case "Year"
                strIncTable = "IncTktY"
                strBkgTable = "TktY" & intPeriod
        End Select

        strFields = strFields & ",0 as OfferId" & strIncTable _
                    & ",0 as Seg" & strIncTable _
                    & ",0 as VND" & strIncTable
        Return True
    End Function
    Private Function GetTkt(intYear As Integer, strTimeFrame As String _
                               , intPeriod As String, strObject As String _
                               , strShortName As String, intContactId As Integer
                               ) As System.Data.DataTable
        Dim tblTkt As System.Data.DataTable
        Dim strQuerry As String
        strQuerry = "SELECT OfferId,Sum(Bkg) as bkg, Sum(VND) as VND" _
                    & " from Data1A_IncentiveCalc " _
                    & " where Shortname='" & strShortName & "' And ContactId=" & intContactId _
                    & " And BookYear =" & intYear & " And TimeFrame='" & strTimeFrame _
                    & "' and Period =" & intPeriod _
                    & " and Unit='Ticket'" _
                    & " and Object='" & strObject & "'" _
                    & " Group By ContactId,OfferId"
        tblTkt = pobjSql.GetDataTable(strQuerry)
        Return tblTkt
    End Function
End Class