'20220518 modi by 7643
'^_^20230306 modi by 7643
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Data.SqlClient
Imports System
Imports System.Data.OleDb
Public Class frmImportMIDT
    Private mstrFilePath As String
    Private mlstInsert As New List(Of String)
    Private mintRecordCount As Integer
    Private mintTotalNbrOfRecords As Integer
    Private Function Txt2SqlBulkCopy(strFileName As String) As Boolean
        Dim i As Long = 0
        Dim sr As StreamReader = New StreamReader(strFileName)
        Dim strLine As String = sr.ReadLine()
        Dim blnResult As Boolean

        Dim strArray As String() = strLine.Split(",")
        Dim tblMidt As System.Data.DataTable = New System.Data.DataTable()
        Dim row As DataRow
        'Dim mStrArr() As String  '^_^20230306 add by 7643

        If strArray.Length <> 15 Then  '^_^20230306 mark by 7643
            'If strArray.Length <> 22 Then  '^_^20230306 modi by 7643
            MsgBox("Invalid format")
            Return False
        End If

        For Each s As String In strArray  '^_^20230306 mark by 7643
            'For i = 0 To 14  '^_^20230306 modi by 7643
            tblMidt.Columns.Add(New DataColumn())
        Next

        Do While Not sr.EndOfStream
            strLine = sr.ReadLine()
            If strLine <> "" Then
                i = i + 1
                If i > 0 Then
                    row = tblMidt.NewRow()
                    row.ItemArray = Split(Mid(strLine, 2, strLine.Length - 2), Chr(34) & "," & Chr(34))  '^_^20230306 mark by 7643
                    '^_^20230306 modi by 7643 -b-
                    'mStrArr = Split(Mid(strLine, 2, strLine.Length - 2), Chr(34) & "," & Chr(34))
                    'row.ItemArray = {mStrArr(1), mStrArr(2), mStrArr(0), mStrArr(4), mStrArr(8), mStrArr(7), mStrArr(4), mStrArr(14), mStrArr(3)}
                    '^_^20230306 modi by 7643 -e-
                    If IsDBNull(row.Item(2)) Then
                        MsgBox("")
                    End If
                    tblMidt.Rows.Add(row)
                    'If i = 10 Then
                    '    Exit Do
                    'End If
                End If
            End If
        Loop

        pobjSql.ExecuteNonQuerry("delete MidtNewTemp")
        Dim objSqlBulk As SqlBulkCopy = New SqlBulkCopy(pobjSql.Connection, SqlBulkCopyOptions.TableLock, Nothing)
        Try
            objSqlBulk.DestinationTableName = "MidtNewTemp"
            objSqlBulk.BatchSize = tblMidt.Rows.Count
            objSqlBulk.WriteToServer(tblMidt)
            blnResult = True
        Catch ex As Exception
            MsgBox("Unable to CONVERT Text to SQL" & vbNewLine & ex.Message)
            blnResult = False
        Finally
            objSqlBulk.Close()
        End Try

        Return blnResult
    End Function
    Private Function MidtNewTemp2Live() As Boolean
        Dim lstQuerries As New List(Of String)

        'Dim strQuerry As String

        lstQuerries.Add("delete [Mktg_MIDT].[dbo].[MIDT_Raw]" _
                    & " where Date_b=(select top 1 (cast([YEAR]+ '-' + [MONTH] + '-01' as smalldatetime)) from midtnewtemp)")
        lstQuerries.Add("update midtnewtemp set Netbkg=replace(netbkg,',','')")

        lstQuerries.Add("insert into MIDT_Raw (Date_b, Carrier, GDS, NetBkg, CRSCode, ARCIATA,AccountName, Class" _
                    & ", Org_city,Des_city) select cast([YEAR]+ '-' + [MONTH] + '-01' as smalldatetime),Airline" _
                    & ", case crscode when '02' then '1S' WHEN '03' THEN '1G' WHEN '04' THEN '1A'" _
                    & " WHEN '07' THEN '1P' WHEN '08' THEN '1B' ELSE CRSCODE END" _
                    & ",NetBkg,CrsOffcCode,Iata,AccountName,SUBSTRING(Class,1,1),DepApt,ArrApt from MidtNewTemp")

        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Unable to update MIDT into SQL")
            Return False
        End If
        Return True
    End Function
    Private Function InsertTable2Sql(tblMidt As System.Data.DataTable) As Boolean
        'Dim trcSql As SqlClient.SqlTransaction
        Dim i As Integer
        Dim strQuerry As String = ""

        Dim cmdSql As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand

        Try
            Dim blnMidtNew As Boolean
            Dim intStartRow As Integer


            Select Case tblMidt.Columns.Count
                Case 15
                    blnMidtNew = True
                    intStartRow = 0
                    tblMidt.Columns(0).ColumnName = "Year"
                    tblMidt.Columns(1).ColumnName = "Month"
                    tblMidt.Columns(4).ColumnName = "AccountName"
                    tblMidt.Columns(5).ColumnName = "Iata"
                    tblMidt.Columns(6).ColumnName = "OID"
                    tblMidt.Columns(8).ColumnName = "Car"
                    tblMidt.Columns(9).ColumnName = "Arrival"
                    tblMidt.Columns(10).ColumnName = "Departure"
                    tblMidt.Columns(11).ColumnName = "Cls"
                    tblMidt.Columns(12).ColumnName = "GDS"
                    tblMidt.Columns(14).ColumnName = "NetBkg"
                Case 19
                    blnMidtNew = False
                    intStartRow = 4
                    tblMidt.Columns(1).ColumnName = "Year"
                    tblMidt.Columns(2).ColumnName = "Month"
                    tblMidt.Columns(3).ColumnName = "Car"
                    tblMidt.Columns(4).ColumnName = "OID"
                    tblMidt.Columns(6).ColumnName = "GDS"
                    tblMidt.Columns(7).ColumnName = "Iata"
                    tblMidt.Columns(8).ColumnName = "AccountName"
                    tblMidt.Columns(18).ColumnName = "NetBkg"
                Case Else
                    MsgBox("In correct file format!")
                    Return False
            End Select
            mintTotalNbrOfRecords = tblMidt.Rows.Count - intStartRow
            If Not CheckDuplicate(tblMidt.Rows(intStartRow)("Month"), tblMidt.Rows(intStartRow)("Year"), blnMidtNew) Then
                MsgBox("MIDT for this month had been updated in the past")
                Return False
            End If

            'trcSql = pobjSql.Connection.BeginTransaction
            'cmdSql.Transaction = trcSql
            mintRecordCount = 0
            Timer1.Start()

            For i = intStartRow To tblMidt.Rows.Count - 1
                My.Application.DoEvents()
                mintRecordCount = mintRecordCount + 1

                strQuerry = "insert into MIDT_Raw (Date_b, Carrier, GDS, NetBkg, CRSCode, ARCIATA,AccountName, Class" _
                    & ", Org_city,Des_city) values('"

                With tblMidt
                    If Not IsDBNull(tblMidt.Rows(i)("Year")) Then
                        strQuerry = strQuerry & ConvertMidtDateText2String(tblMidt.Rows(i)("Year"), tblMidt.Rows(i)("Month")) _
                        & "','" & tblMidt.Rows(i)("Car") _
                        & "','" & ConvertMidtGdsCode(tblMidt.Rows(i)("GDS")) _
                        & "'," & tblMidt.Rows(i)("NetBkg") & ",'" & tblMidt.Rows(i)("OID") _
                        & "','" & tblMidt.Rows(i)("Iata") & "','" & tblMidt.Rows(i)("AccountName")

                        If blnMidtNew Then
                            strQuerry = strQuerry & "','" & Mid(tblMidt.Rows(i)("Cls"), 1, 1) _
                                & "','" & tblMidt.Rows(i)("Departure") & "','" & tblMidt.Rows(i)("Arrival") & "')"
                        Else
                            strQuerry = strQuerry & "','','','')"
                        End If
                        cmdSql.CommandText = strQuerry
                        cmdSql.ExecuteNonQuery()
                    End If
                End With
            Next
            Timer1.Stop()
            'trcSql.Commit()
            Return True
        Catch ex As Exception
            Dim strUpdtErr As String = ex.Message & vbCrLf & strQuerry
            'trcSql.Rollback()
            Append2TextFile(strUpdtErr)
            MsgBox(strUpdtErr)

            Return False
        End Try

        Return True

    End Function
    Private Sub mnuImport_Click(sender As Object, e As EventArgs) Handles barImport.Click

    End Sub
    Private Function UpdateSqlMIDT() As Boolean
        Dim lstQuerries As New List(Of String)
        lstQuerries.Add("Update MIDT_Raw set org_country=isnull((select top 1 Country from CityCode c where c.Airport=org_city),'')" _
                                & ",org_area=isnull((select top 1 area from CityCode c where c.Airport=org_city),'')" _
                                & ", des_country=isnull((select top 1 Country from CityCode c where c.Airport=des_city),'')" _
                                & ",des_area=isnull((select top 1 area from CityCode c where c.Airport=des_city),'')" _
                                & ", AgentName=isnull((select top 1 ShortName from DATA1A_OIDs a " _
                                & " where a.Status='OK' and a.OffcId=MIDT_Raw.CrsCode and a.GDS=MIDT_Raw.GDS),'')" _
                                & " where City=''")
        lstQuerries.Add("Update MIDT_Raw set City=isnull((select top 1 Case Region when 'North' then 'HAN' else 'SGN' end" _
                        & " from DATA1A_Customers c where c.Status='OK' and c.ShortName=AgentName),'')  where City=''")
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function UpdateAgentNameCity() As Boolean
        Dim tblCrsCode As System.Data.DataTable = pobjSql.GetDataTable("Select distinct CrsCode from MIDT_RAW" _
                                                                        & " where City=''")
        Dim lstQuerries As New List(Of String)

        For Each objRow As DataRow In tblCrsCode.Rows
            lstQuerries.Add("Update MIDT_RAW" _
                            & " set AgentName=isnull((Select top 1 AgentName from Midt_raw where AgentName<>'' and CrsCode='" _
                            & objRow("CrsCode") & "' order by Recid desc),'')" _
                            & ", City=isnull((Select top 1 City from Midt_raw where City<>'' and CrsCode='" _
                            & objRow("CrsCode") & "' order by Recid desc),'')" _
                            & " where AgentName='' and CrsCode='" & objRow("CrsCode") & "'")

        Next

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub mnuUpdateAgt_Click(sender As Object, e As EventArgs) Handles barUpdateAgt.Click


    End Sub
    Private Sub ClearOdlValues()
        mstrFilePath = ""
        mlstInsert.Clear()
    End Sub
    Private Function ReadCsvFile(strFilePath As String) As Boolean
        Dim objXL As New Excel.Application
        Dim i As Integer ', j As Integer, k As Integer
        Dim intLastRow As Integer
        Dim intLastColumn As Integer
        Dim intStartRow As Integer
        Dim objWbk As Workbook
        Dim objWsh As Worksheet
        Dim blnMidtNew As Boolean
        Dim strYearColumn As String
        Dim strMonthColumn As String
        Dim strAccountNameColumn As String
        Dim strIataColumn As String
        Dim strCrsCodeColumn As String
        Dim strCarColumn As String
        Dim strDepartureColumn As String = String.Empty
        Dim strArrivalColumn As String = String.Empty
        Dim strClsColumn As String = String.Empty
        Dim strGdsCodeColumn As String
        Dim strNetBkgColumn As String


        objWbk = objXL.Workbooks.Open(strFilePath)
        objWsh = objWbk.ActiveSheet
        objXL.Visible = True

        intLastRow = objWsh.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row
        intLastColumn = objWsh.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column
        Select Case intLastColumn
            Case 15
                blnMidtNew = True
                intStartRow = 2
                strYearColumn = "A"
                strMonthColumn = "B"
                strAccountNameColumn = "E"
                strIataColumn = "F"
                strCrsCodeColumn = "G"
                strCarColumn = "I"
                strDepartureColumn = "K"
                strArrivalColumn = "J"
                strClsColumn = "L"
                strGdsCodeColumn = "M"
                strNetBkgColumn = "O"
            Case 20
                blnMidtNew = False
                intStartRow = 5
                strYearColumn = "C"
                strMonthColumn = "D"
                strAccountNameColumn = "J"
                strIataColumn = "I"
                strCrsCodeColumn = "F"
                strCarColumn = "E"
                'strDepartureColumn = "K"
                'strArrivalColumn = "J"
                'strClsColumn = "L"
                strGdsCodeColumn = "H"
                strNetBkgColumn = "T"
            Case Else
                MsgBox("In correct file format!")
                Return False
        End Select
        With objWsh
            If Not CheckDuplicate(.Range(strMonthColumn & intStartRow).Value, .Range(strYearColumn & intStartRow).Value, blnMidtNew) Then
                MsgBox("MIDT for this month had been updated in the past")
                Return False
            End If

            For i = intStartRow To intLastRow
                Dim strQuerry As String = "insert into MIDT_Raw (Date_b, Carrier, GDS, NetBkg, CRSCode, ARCIATA, Class" _
                & ", Org_city,Des_city) values('"

                strQuerry = strQuerry & ConvertMidtDateText2String(.Range(strYearColumn & intStartRow).Value, .Range(strMonthColumn & intStartRow).Value) _
                    & "','" & .Range(strCarColumn & intStartRow).Value _
                    & "','" & ConvertMidtGdsCode(.Range(strGdsCodeColumn & intStartRow).Value) _
                    & "'," & .Range(strNetBkgColumn & intStartRow).Value & ",'" & .Range(strCrsCodeColumn & intStartRow).Value _
                    & "','" & .Range(strIataColumn & intStartRow).Value

                If blnMidtNew Then
                    strQuerry = strQuerry & "','" & .Range(strClsColumn & intStartRow).Value _
                        & "','" & .Range(strDepartureColumn & intStartRow).Value & "','" & .Range(strArrivalColumn & intStartRow).Value
                End If

                strQuerry = strQuerry & "')"

                mlstInsert.Add(strQuerry)
            Next
        End With
        objWbk.Close(False)
        objXL.Quit()

        Return True
    End Function
    Private Function CheckDuplicate(intMonth As Integer, intYear As Integer, blnMidtNew As Boolean) As Boolean
        Dim strRecId As String = pobjSql.GetScalarAsString("select top 1 Recid from MIDT_Raw where Date_b='" _
                                          & DateTime2Text(DateSerial(intYear, intMonth, 1)) & "'")

        If strRecId = "" Then
            Return True
        ElseIf blnMidtNew Then
            If pobjSql.ExecuteNonQuerry("Delete [MIDT_Raw] where Date_b='" & ConvertMidtDateText2String(intYear, intMonth) & "'") Then
                Return True
            Else
                Return False
            End If

        Else
            Return False
        End If

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblStatus.Text = mintRecordCount & "/" & mintTotalNbrOfRecords
        'Me.Refresh()
    End Sub

    Private Sub frmImportMIDT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If Environment.GetCommandLineArgs.Length > 1 AndAlso UCase(Environment.GetCommandLineArgs(1)) = "HAN" Then
        '    pstrCity = "HAN"
        'Else
        '    pstrCity = "SGN"
        'End If

        'If Not pobjSql.ConnectMidtDatabase() Then
        '    MsgBox("Unable to connect SQL")
        '    Me.Dispose()
        'End If
    End Sub

    Private Sub barDataNoShortNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles barDataNoShortNameToolStripMenuItem.Click



    End Sub

    Private Sub barSumByMonth_Click(sender As Object, e As EventArgs) Handles barSumByMonth.Click
        Dim frmSelect As New frmSelectMonthYear
        Dim tblUnknownMidtOIDs As System.Data.DataTable

        If frmSelect.ShowDialog <> DialogResult.OK Then
            Exit Sub
        End If

        tblUnknownMidtOIDs = GetUnidentifiedOIDsInMidt(frmSelect.BookYear, frmSelect.BookMonth _
                                                             , pobjUser.Region)

        If tblUnknownMidtOIDs.Rows.Count > 0 Then
            Dim frmShow As New frmShowTableContent(tblUnknownMidtOIDs _
                                                   , "Unable to Sum MIDT due to Unidentified Offc ID")
            frmShow.ShowDialog()
            Exit Sub
        End If
        If Not SumMidtByMonth(frmSelect.BookYear, frmSelect.BookMonth) Then
            Exit Sub
        End If

    End Sub



    Public Function formatTable(tblFirst As System.Data.DataTable) As System.Data.DataTable
        If tblFirst.Rows(4)(0).ToString() = "" Then
            tblFirst.Columns.RemoveAt(0)
        End If
        Dim tblResult = tblFirst.Clone()
        For i = 2 To tblFirst.Rows.Count - 1
            If tblFirst.Rows(i)(0).ToString <> "" Then
                tblResult.Rows.Add(tblFirst.Rows(i).ItemArray)
            End If
        Next
        tblResult.Columns(0).ColumnName = "Date"
        tblResult.Columns(1).ColumnName = "CountryCode"
        tblResult.Columns(2).ColumnName = "ProviderCode"
        tblResult.Columns(3).ColumnName = "GDSOfficeCode"
        tblResult.Columns(4).ColumnName = "GDSName"
        tblResult.Columns(5).ColumnName = "GDSCode"
        tblResult.Columns(6).ColumnName = "OriginalARC"
        tblResult.Columns(7).ColumnName = "AccountName"
        tblResult.Columns(8).ColumnName = "GDSOfficeName"
        tblResult.Columns(9).ColumnName = "TradeName"
        tblResult.Columns(10).ColumnName = "AddLine1"
        tblResult.Columns(11).ColumnName = "AddLine2"
        tblResult.Columns(12).ColumnName = "AddLine3"
        tblResult.Columns(13).ColumnName = "City"
        tblResult.Columns(14).ColumnName = "PostalCode"
        tblResult.Columns(15).ColumnName = "ActiveAdd"
        tblResult.Columns(16).ColumnName = "ActiveCancel"
        tblResult.Columns(17).ColumnName = "PassiveAdd"
        tblResult.Columns(18).ColumnName = "PassiveCancel"
        tblResult.Columns(19).ColumnName = "LateCancelBill"
        tblResult.Columns(20).ColumnName = "CBINet"
        Return tblResult
    End Function
    Private Sub ImportMonthlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles padImportMonthly.Click
        Dim dteStart As Date = Now

        Dim ofdMidt As New OpenFileDialog

        ClearOdlValues()

        With ofdMidt
            .Filter = "CSV Files|*.csv"
            '.Filter = "Office Files|*.xlsx;*.xls;*.csv"
            '.FilterIndex = 2
            If .ShowDialog = DialogResult.OK Then
                mstrFilePath = .FileName
            End If
        End With

        If mstrFilePath <> "" Then
            If Not Txt2SqlBulkCopy(mstrFilePath) Then
                Exit Sub
            ElseIf Not MidtNewTemp2Live() Then
                Exit Sub
            ElseIf Not UpdateSqlMIDT() Then
                Exit Sub
            End If

            MsgBox("Total processed time in seconds:" & DateDiff(DateInterval.Second, dteStart, Now))
            Exit Sub
        End If
    End Sub

    Public Function CheckValueAndbutton(tblResult As System.Data.DataTable) As Integer
        Dim cmdSql As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
        Dim query As String = ""
        Dim n As Int16
        Dim mStr As String  '20220518 add by 7643
        'Xóa dữ liệu > 1 năm trong quá khứ
        query = "delete CBI_ReportDailybyMarket where BookDate < dateadd(year,-1,getdate()) "
        cmdSql.CommandText = query
        cmdSql.ExecuteNonQuery()

        'If GetDataTable(String.Format("select * from CBI_ReportDailybyMarket where BookDate = '{0}' ", tblResult.Rows(0)("Date").ToString())).Rows.Count > 0 Then  '20220518 mark by 7643
        '20220518 modi by 7643 -b-
        mStr = Date.Parse((tblResult.Rows(0)("Date").ToString())).ToString("yyyyMMdd")
        If GetDataTable(String.Format("select * from CBI_ReportDailybyMarket where BookDate = '{0}' ", mStr)).Rows.Count > 0 Then
            '20220518 modi by 7643 -e-
            Dim result As DialogResult = MessageBox.Show("Dữ liệu đã được cập nhật. Bạn có muốn cập nhật lại không?", "caption", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Exit Function
            Else n = 1
            End If
        End If

        'Delete trước khi import
        query = "delete CBI_ReportDailybyMarket where BookDate = @BookDate"
        cmdSql.CommandText = query
        cmdSql.Parameters.Add("@BookDate", SqlDbType.DateTime).Value = DateTime.Parse(tblResult.Rows(0)("Date").ToString())
        For i = 0 To tblResult.Rows.Count - 1
            'Check thoi gian qua khu > 1 nam
            If tblResult.Rows(i)("Date") <= DateAdd(DateInterval.Year, -1, Date.Now()) Then
            Else
                'Insert
                cmdSql.Parameters.Clear()
                query = "Insert into CBI_ReportDailybyMarket(BookDate,Country,ProviderCode,GDSOfficeCode,GDSName,GDSCode,OriginalARC,AccountName,GDSOfficename,TradeName,AddLine1,AddLine2,AddLine3,CityOfAgency,PostalCode,ActiveAddBook,ActiveCancelBook,PassiveAddBook,PassiveCancelBook,LateCancelBill,CBINetBook) 
                     Select @FstUpdate,@Country,@ProviderCode,@GDSOfficeCode,@GDSName,@GDSCode,@OriginalARC,@AccountName,@GDSOfficename,@TradeName,@AddLine1,@AddLine2,@AddLine3,@CityOfAgency,@PostalCode,@ActiveAddBook,@ActiveCancelBook,@PassiveAddBook,@PassiveCancelBook,@LateCancelBill,@CBINetBook  
                     Where not exists (select 1 from CBI_ReportDailybyMarket where BookDate = @FstUpdate and Country = @Country and ProviderCode = @ProviderCode and GDSOfficeCode = @GDSOfficeCode and GDSCode = @GDSCode) "
                cmdSql.CommandText = query
                cmdSql.Parameters.Add("@FstUpdate", SqlDbType.DateTime).Value = DateTime.Parse(tblResult.Rows(i)("Date").ToString())
                cmdSql.Parameters.Add("@Country", SqlDbType.VarChar).Value = tblResult.Rows(i)("CountryCode").ToString()
                cmdSql.Parameters.Add("@ProviderCode", SqlDbType.VarChar).Value = tblResult.Rows(i)("ProviderCode").ToString()
                cmdSql.Parameters.Add("@GDSOfficeCode", SqlDbType.VarChar).Value = tblResult.Rows(i)("GDSOfficeCode").ToString()
                cmdSql.Parameters.Add("@GDSName", SqlDbType.VarChar).Value = tblResult.Rows(i)("GDSName").ToString()
                cmdSql.Parameters.Add("@GDSCode", SqlDbType.VarChar).Value = tblResult.Rows(i)("GDSCode").ToString()
                cmdSql.Parameters.Add("@OriginalARC", SqlDbType.VarChar).Value = tblResult.Rows(i)("OriginalARC").ToString()
                cmdSql.Parameters.Add("@AccountName", SqlDbType.VarChar).Value = tblResult.Rows(i)("AccountName").ToString()
                cmdSql.Parameters.Add("@GDSOfficename", SqlDbType.VarChar).Value = tblResult.Rows(i)("GDSOfficename").ToString()
                cmdSql.Parameters.Add("@TradeName", SqlDbType.VarChar).Value = tblResult.Rows(i)("TradeName").ToString()
                cmdSql.Parameters.Add("@AddLine1", SqlDbType.VarChar).Value = tblResult.Rows(i)("AddLine1").ToString()
                cmdSql.Parameters.Add("@AddLine2", SqlDbType.VarChar).Value = tblResult.Rows(i)("AddLine2").ToString()
                cmdSql.Parameters.Add("@AddLine3", SqlDbType.VarChar).Value = tblResult.Rows(i)("AddLine3").ToString()
                cmdSql.Parameters.Add("@CityOfAgency", SqlDbType.VarChar).Value = tblResult.Rows(i)("City").ToString()
                cmdSql.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = tblResult.Rows(i)("PostalCode").ToString()
                cmdSql.Parameters.Add("@ActiveAddBook", SqlDbType.Int).Value = Integer.Parse(tblResult.Rows(i)("ActiveAdd").ToString())
                cmdSql.Parameters.Add("@ActiveCancelBook", SqlDbType.Int).Value = Integer.Parse(tblResult.Rows(i)("ActiveCancel").ToString())
                cmdSql.Parameters.Add("@PassiveAddBook", SqlDbType.Int).Value = Integer.Parse(tblResult.Rows(i)("PassiveAdd").ToString())
                cmdSql.Parameters.Add("@PassiveCancelBook", SqlDbType.Int).Value = Integer.Parse(tblResult.Rows(i)("PassiveCancel").ToString())
                cmdSql.Parameters.Add("@LateCancelBill", SqlDbType.Int).Value = Integer.Parse(tblResult.Rows(i)("LateCancelBill").ToString())
                cmdSql.Parameters.Add("@CBINetBook", SqlDbType.Int).Value = Integer.Parse(tblResult.Rows(i)("CBINet").ToString())
                cmdSql.ExecuteNonQuery()
            End If
        Next
        MsgBox("Đã import")
        If n = 1 Then
            MsgBox(String.Format("Dữ liệu ngày {0} đã được cập nhật", Date.Parse((tblResult.Rows(0)("Date").ToString())).ToString("dd/MM")))
        End If

    End Function
    Private Sub ImportDailyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles padImportDaily.Click
        Dim dteStart As Date = Now
        Dim ofdMidt As New OpenFileDialog
        ClearOdlValues()
        With ofdMidt
            .Filter = "Office Files|*.xlsx;*.xls"
            If .ShowDialog = DialogResult.OK Then
                mstrFilePath = .FileName
            End If
        End With
        If mstrFilePath <> "" Then
            Dim tblResult As System.Data.DataTable
            Dim objTv = New thuvien()
            lblStatus.Text = "Reading Data file"
            tblResult = objTv.f_ConvertExcelToTable(mstrFilePath, "")

            tblResult = formatTable(tblResult)
            CheckValueAndbutton(tblResult)
            lblStatus.Text = "Mapping Customer Short Name. Please wait for around 2 minutes ..."
            Me.Refresh()
            If Not MapCustShortName4MidtDaily() Then
                MsgBox("Có lỗi không xác định được CustomerShortName cho MIDT Daily")
            End If
            lblStatus.Text = ""
            MsgBox("Total processed time in seconds:" & DateDiff(DateInterval.Second, dteStart, Now))

        End If
    End Sub
    Private Function MapCustShortName4MidtDaily() As Boolean
        Dim strQuerry As String = "SELECT distinct m.GDS,GDSOfficeCode,o.ShortName, c.Region" _
                                & " FROM CBI_ReportDailybyMarket m" _
                                & " left join DATA1A_OIDs o on m.GDS=o.GDS and m.GDSOfficeCode=o.OffcId" _
                                & " left join DATA1A_Customers c on c.ShortName=o.ShortName " _
                                & " where o.Status='ok' and c.Status='ok' and m.custshortname='' and not(o.ShortName is null) order by GDS,GDSOfficeCode"
        Dim tblShortNames As System.Data.DataTable = pobjSql.GetDataTable(strQuerry)

        For Each objRow As DataRow In tblShortNames.Rows
            If Not pobjSql.ExecuteNonQuerry("Update CBI_ReportDailybyMarket set Region='" & objRow("Region") _
                                             & "', CustShortName='" & objRow("ShortName") _
                                             & "' where CustShortName='' and GDS='" & objRow("GDS") _
                                             & "' and GDSOfficeCode='" & objRow("GDSOfficeCode") & "'") Then
                MsgBox("Không cập nhật được Short Name cho GDS/PCC:" & objRow("GDS") & " " & objRow("GDSOfficeCode"))
            End If
        Next

        Return True
    End Function

    Private Sub barNoShortNameMidtMontly_Click(sender As Object, e As EventArgs) Handles barNoShortNameMidtMontly.Click
        Dim tblNoShortName As System.Data.DataTable
        tblNoShortName = pobjSql.GetDataTable("Select * from MIDT_Raw where AgentName=''")

        If tblNoShortName.Rows.Count = 0 Then
            MsgBox("No Data Found!")
        Else
            Dim objExcel As New Excel.Application
            Dim objWbk As Workbook = objExcel.Workbooks.Add
            Dim objWsh As Worksheet = objWbk.ActiveSheet
            Dim i As Integer = 1
            Dim intExclColumnIndex As Integer

            For Each objColumn As DataColumn In tblNoShortName.Columns
                intExclColumnIndex = intExclColumnIndex + 1
                objWsh.Cells(1, intExclColumnIndex) = objColumn.ColumnName
                'objWsh.Columns(Chr(intExclColumnIndex + 64)).NumberFormat = "@"
            Next

            For Each objRow As DataRow In tblNoShortName.Rows
                i = i + 1
                objWsh.Range("A" & i, "R" & i).NumberFormat = "@"
                objWsh.Range("A" & i, "R" & i).Value = objRow.ItemArray
            Next
            objExcel.Visible = True
        End If
    End Sub

    Private Sub barNoShortNameMidtDaily_Click(sender As Object, e As EventArgs) Handles barNoShortNameMidtDaily.Click
        Dim tblNoShortName As System.Data.DataTable
        tblNoShortName = pobjSql.GetDataTable("Select * from CBI_ReportDailybyMarket where CustShortName='' ORDER BY GdsName,GDSOfficeCode,BookDate")

        If tblNoShortName.Rows.Count = 0 Then
            MsgBox("No Data Found!")
        Else
            Dim objExcel As New Excel.Application
            Dim objWbk As Workbook = objExcel.Workbooks.Add
            Dim objWsh As Worksheet = objWbk.ActiveSheet
            Dim i As Integer = 1
            Dim intExclColumnIndex As Integer

            For Each objColumn As DataColumn In tblNoShortName.Columns
                intExclColumnIndex = intExclColumnIndex + 1
                objWsh.Cells(1, intExclColumnIndex) = objColumn.ColumnName
                'objWsh.Columns(Chr(intExclColumnIndex + 64)).NumberFormat = "@"
            Next
            'objExcel.Visible = True
            For Each objRow As DataRow In tblNoShortName.Rows
                i = i + 1
                objWsh.Range("A" & i, "AA" & i).NumberFormat = "@"
                objWsh.Range("A" & i, "AA" & i).Value = objRow.ItemArray
            Next
            objExcel.Visible = True
        End If
    End Sub

    Private Sub UpdateCustMidtMontly_Click(sender As Object, e As EventArgs) Handles UpdateCustMidtMontly.Click
        Dim lstQuerries As New List(Of String)
        lstQuerries.Add("Update MIDT_Raw set AgentName=isnull((select top 1 ShortName from DATA1A_OIDs a " _
                                & " where a.Status='OK' and a.OffcId=MIDT_Raw.CrsCode and a.GDS=MIDT_Raw.gds),'')" _
                                & " where City=''")
        lstQuerries.Add("Update MIDT_Raw set City=isnull((select top 1 Case Region when 'North' then 'HAN' else 'SGN' end" _
                        & " from DATA1A_Customers c where c.Status='OK' and c.ShortName=AgentName),'')  where City=''")
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Completed")
        Else
            MsgBox("Uncompleted")
        End If
    End Sub

    Private Sub UpdateCustMidtDaily_Click(sender As Object, e As EventArgs) Handles UpdateCustMidtDaily.Click
        If Not MapCustShortName4MidtDaily() Then
            MsgBox("Có lỗi không xác định được CustomerShortName cho MIDT Daily")
            Exit Sub
        Else
            MsgBox("Completed!")
        End If
    End Sub
End Class