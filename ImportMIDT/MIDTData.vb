Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports System.IO

Public Class MIDTData
    'Private cn As String = "Data Source=172.16.2.6;Initial Catalog=Mktg_MIDT;User ID=reporter; password=reporter"
    'Private con As SqlConnection
    Private eProcess As Process
    Private TableName As String

    Function BuildTable(ByVal cmd As String) As System.Data.DataTable
        Dim dtl As New System.Data.DataTable
        Dim adt As New SqlDataAdapter(cmd, pobjSql.Connection)
        adt.Fill(dtl)
        Return dtl
    End Function

    Private Sub BuildControl(ByVal cmd As String, ByVal clbControl As CheckedListBox, DisplayMember As String)
        Dim dtl As System.Data.DataTable = BuildTable(cmd)
        clbControl.DataSource = dtl
        clbControl.DisplayMember = DisplayMember
    End Sub

    Private Function getCondition(DefindOD As String) As String
        Dim strResult As String = ""
        Dim FlagType As Integer = 0
        For Each itemChecked In clbCityOD.CheckedItems
            If strResult = "" Then
                strResult = "'" & itemChecked.item("city").ToString & "'"
            Else
                strResult = strResult & "," & "'" & itemChecked.item("city").ToString & "'"
            End If
        Next

        If strResult = "" Then
            For Each itemChecked In clbCountry.CheckedItems
                If strResult = "" Then
                    strResult = "'" & itemChecked.item("Country").ToString & "'"
                Else
                    strResult = strResult & "," & "'" & itemChecked.item("Country").ToString & "'"
                End If
            Next
        Else
            If FlagType = 0 Then
                FlagType = 1
            End If
        End If

        If strResult = "" Then
            For Each itemChecked In clbArea.CheckedItems
                If strResult = "" Then
                    strResult = "'" & itemChecked.item("Area").ToString & "'"
                Else
                    strResult = strResult & "," & "'" & itemChecked.item("Area").ToString & "'"
                End If
            Next
        Else
            If FlagType = 0 Then
                FlagType = 2
            End If
        End If

        If strResult <> "" Then
            If FlagType = 0 Then
                FlagType = 3
            End If
        End If

        If FlagType = 0 Then
            strResult = ""
        ElseIf FlagType = 1 Then
            strResult = DefindOD & "_city in (" & strResult & ")"
        ElseIf FlagType = 2 Then
            strResult = DefindOD & "_country in (" & strResult & ")"
        ElseIf FlagType = 3 Then
            strResult = DefindOD & "_area in (" & strResult & ")"
        End If

        Return strResult
    End Function

    Private Sub MIDTData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'con = New SqlConnection(cn)
        'con.Open()
        
        BuildControl("select city from citycode where Country='VN' order by city", clbCity, "city")
        BuildControl("select distinct area from citycode order by area", clbArea, "Area")
        BuildControl("select val as GDS from midt_misc where CAT='GDS'", clbGDS, "GDS")
    End Sub

    Private Sub btnRetrieveAgents_Click(sender As Object, e As EventArgs) Handles btnRetrieveAgents.Click
        Try
            BuildControl("select distinct agentName from mktg_midt.dbo.##" & TableName & " order by agentName", clbAgents, "agentName")
        Catch ex As Exception
            MsgBox("You must get data first")
        End Try
    End Sub

    Private Sub btnRetrieveAirlines_Click(sender As Object, e As EventArgs) Handles btnRetrieveAirlines.Click
        Try
            BuildControl("select distinct Carrier from mktg_midt.dbo.##" & TableName & " order by Carrier", clbAirlines, "Carrier")
        Catch ex As Exception
            MsgBox("You must get data first")
        End Try
    End Sub

    Private Sub chkNorth_CheckedChanged(sender As Object, e As EventArgs) Handles chkNorth.CheckedChanged
        Dim strCities As String = ""
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Select val from data1a_MISC where CAT='NorthVN'"
        strCities = cmd.ExecuteScalar
        Dim cValue As Boolean = False
        If chkNorth.Checked = True Then
            cValue = True
        Else
            cValue = False
        End If
        For i As Integer = 0 To clbCity.Items.Count - 1
            If InStr(strCities, clbCity.GetItemText(clbCity.Items(i)).ToString) <> 0 Then
                clbCity.SetItemChecked(i, cValue)
            End If
        Next
        'For i As Integer = 0 To clbCity.Items.Count - 1
        '    Select Case clbCity.GetItemText(clbCity.Items(i)).ToString
        '        Case "HAN", "HPH"
        '            clbCity.SetItemChecked(i, cValue)
        '    End Select
        'Next
    End Sub

    Private Sub chkSouth_CheckedChanged(sender As Object, e As EventArgs) Handles chkSouth.CheckedChanged
        Dim strCities As String = ""
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Select val from data1a_MISC where CAT='SouthVN'"
        strCities = cmd.ExecuteScalar
        Dim cValue As Boolean = False
        If chkSouth.Checked = True Then
            cValue = True
        Else
            cValue = False
        End If
        For i As Integer = 0 To clbCity.Items.Count - 1
            If InStr(strCities, clbCity.GetItemText(clbCity.Items(i)).ToString) <> 0 Then
                clbCity.SetItemChecked(i, cValue)
            End If
        Next
    End Sub

    Private Sub chkOther_CheckedChanged(sender As Object, e As EventArgs) Handles chkOther.CheckedChanged
        Dim strCities As String = ""
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Select val from Data1a_MISC where CAT='NorthVN'"
        strCities = cmd.ExecuteScalar
        Dim cValue As Boolean = False
        If chkOther.Checked = True Then
            cValue = True
        Else
            cValue = False
        End If
        For i As Integer = 0 To clbCity.Items.Count - 1
            If InStr(strCities, clbCity.GetItemText(clbCity.Items(i)).ToString) <> 0 Then
                clbCity.SetItemChecked(i, cValue)
            End If
        Next
    End Sub

    Private Sub lnkArea_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCity.LinkClicked
        If lnkCity.Text = "ALL" Then
            chkSouth.Checked = True
            chkNorth.Checked = True
            chkOther.Checked = True
            lnkCity.Text = "NONE"
        Else
            chkSouth.Checked = False
            chkNorth.Checked = False
            chkOther.Checked = False
            lnkCity.Text = "ALL"
        End If
    End Sub

    Private Sub lnkGDS_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGDS.LinkClicked
        If lnkGDS.Text = "ALL" Then
            For i As Integer = 0 To clbGDS.Items.Count - 1
                clbGDS.SetItemChecked(i, True)
            Next
            lnkGDS.Text = "NONE"
        Else
            For i As Integer = 0 To clbGDS.Items.Count - 1
                clbGDS.SetItemChecked(i, False)
            Next
            lnkGDS.Text = "ALL"
        End If
    End Sub

    Private Sub lnkAgents_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAgents.LinkClicked
        If clbAgents.Items.Count > 0 Then
            If lnkAgents.Text = "All Agents" Then
                For i As Integer = 0 To clbAgents.Items.Count - 1
                    clbAgents.SetItemChecked(i, True)
                Next
                lnkAgents.Text = "None Agents"
            Else
                For i As Integer = 0 To clbAgents.Items.Count - 1
                    clbAgents.SetItemChecked(i, False)
                Next
                lnkAgents.Text = "All Agents"
            End If
        Else
            MsgBox("You must push ""retrieve agents button"" to get agents name!")
        End If
    End Sub

    Private Sub lnkAirlines_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAirlines.LinkClicked
        If clbAirlines.Items.Count > 0 Then
            If lnkAirlines.Text = "All Airlines" Then
                For i As Integer = 0 To clbAirlines.Items.Count - 1
                    clbAirlines.SetItemChecked(i, True)
                Next
                lnkAirlines.Text = "None Airlines"
            Else
                For i As Integer = 0 To clbAirlines.Items.Count - 1
                    clbAirlines.SetItemChecked(i, False)
                Next
                lnkAirlines.Text = "All Airlines"
            End If
        Else
            MsgBox("You must push ""retrieve airlines button"" to get airlines code!")
        End If
    End Sub

    Private Sub clbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbArea.SelectedIndexChanged
        Dim strArea As String = "''"
        For Each itemChecked In clbArea.CheckedItems
            strArea = strArea & ",'" & itemChecked.item("area").ToString & "'"
        Next
        BuildControl("select distinct country from citycode where area in(" & strArea & ") order by country", clbCountry, "country")
    End Sub

    Private Sub clbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbCountry.SelectedIndexChanged
        Dim strCountry As String = "''"
        For Each itemChecked In clbCountry.CheckedItems
            strCountry = strCountry & ",'" & itemChecked.item("country").ToString & "'"
        Next
        BuildControl("select distinct city from citycode where country in(" & strCountry & ") order by city", clbCityOD, "city")
    End Sub

    Private Sub btnOrg_Click(sender As Object, e As EventArgs) Handles btnOrg.Click
        txtOrg.Text = getCondition("org")
    End Sub

    Private Sub btnDest_Click(sender As Object, e As EventArgs) Handles btnDest.Click
        txtDest.Text = getCondition("des")
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDest.Text = ""
        txtOrg.Text = ""
    End Sub

    Private Function getQuery() As String
        Dim strResult As String = ""
        Dim strAgents As String = ""
        Dim strAirlines As String = ""
        
        'lấy theo agents
        If lnkAgents.Text = "None Agents" Then
        Else
            For Each itemChecked In clbAgents.CheckedItems
                If strAgents = "" Then
                    strAgents = "'" & itemChecked.item("agentName").ToString & "'"
                Else
                    strAgents = strAgents & ",'" & itemChecked.item("agentName").ToString & "'"
                End If
            Next
            If strAgents <> "" Then
                strResult = strResult & " and AgentName in(" & strAgents & ")"
            End If
        End If

        'lấy theo airlines
        If lnkAirlines.Text = "None Airlines" Then
        Else
            For Each itemChecked In clbAirlines.CheckedItems
                If strAirlines = "" Then
                    strAirlines = "'" & itemChecked.item("Carrier").ToString & "'"
                Else
                    strAirlines = strAirlines & ",'" & itemChecked.item("Carrier").ToString & "'"
                End If
            Next
            If strAirlines <> "" Then
                strResult = strResult & " and Carrier in(" & strAirlines & ")"
            End If
        End If

        'lấy theo Org_City
        If txtOrg.Text <> "" Then
            strResult = strResult & " and " & txtOrg.Text
        End If

        'lấy theo Dest_City
        If txtDest.Text <> "" Then
            strResult = strResult & " and " & txtDest.Text
        End If
        Return strResult
    End Function

    Private Sub btnRunReport_Click(sender As Object, e As EventArgs) Handles btnRunReport.Click
        Cursor.Current = Cursors.WaitCursor
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        Dim strResult As String = ""
        Dim strGDS As String = ""
        Dim strCity As String = ""
        Dim strJoinTables As String
        Dim strGroupBy As String = " group by "

        'lấy theo GDS
        If lnkGDS.Text = "NONE" Then
        Else
            For Each itemChecked In clbGDS.CheckedItems
                If strGDS = "" Then
                    strGDS = "'" & itemChecked.item("GDS").ToString & "'"
                Else
                    strGDS = strGDS & ",'" & itemChecked.item("GDS").ToString & "'"
                End If
            Next
            If strGDS <> "" Then
                strResult = strResult & " and GDS in(" & strGDS & ")"
            End If
        End If

        'lấy theo city
        If lnkCity.Text = "NONE" Then
        Else
            For Each itemChecked In clbCity.CheckedItems
                If strCity = "" Then
                    strCity = "'" & itemChecked.item("city").ToString & "'"
                Else
                    strCity = strCity & ",'" & itemChecked.item("city").ToString & "'"
                End If
            Next
            If strCity <> "" Then
                strResult = strResult & " and City in(" & strCity & ")"
            End If
        End If

        Dim rgx As New System.Text.RegularExpressions.Regex("[^\w\.@-]")
        TableName = System.Environment.MachineName.Replace("-", "")
        TableName = rgx.Replace(TableName, "")
        Dim dk1b As String = ""
        If chkExcl1B.Checked = True Then
            dk1b = dk1b & " and GDS<>'1B' and Carrier<>'VN'"
        Else
            dk1b = ""
        End If
        Try
            cmd.CommandText = "Drop table ##" & TableName
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        strJoinTables = " from MKTG_MIDT.dbo.MIDT_Raw m "

        Dim strSelectFields As String = "select sum(NetBkg) as NetBkg,"
        For Each objRow As DataGridViewRow In dgrFields.Rows
            With objRow
                If .Cells("Selected").Value Then
                    strSelectFields = strSelectFields & .Cells("FieldName").Value & ","
                    strGroupBy = strGroupBy & .Cells("FieldName").Value & ","
                    If .Cells("FieldName").Value = "Segment" Then
                        strJoinTables = strJoinTables & " left join Mktg_MIDT.dbo.Data1A_CustSegments c on m.AgentName=c.shortname" _
                        & " And c.Status='OK' and c.bookyear=" _
                        & " (Select Max(BookYear) from Mktg_MIDT.dbo.Data1A_CustSegments)"
                    End If
                End If
            End With
        Next
        strGroupBy = Mid(strGroupBy, 1, strGroupBy.Length - 1)
        strSelectFields = strSelectFields & "0 as isFlag"
        'If chkLimitedFieldsOnly.Checked Then
        '    strSelectFields = "Date_b, Carrier, GDS, City, AgentName, NetBkg, Org_Country" _
        '                        & ", Des_Country, CRSCode, 0 as isFlag,Segment "
        'Else
        '    strSelectFields = "select  Date_b, Carrier, GDS, City, AgentName, NetBkg, Class, Org_City, Org_Country, Org_Area" _
        '                        & ", Des_City, Des_Country, Des_Area, CRSCode, 0 as isFlag,Segment"
        'End If


        strJoinTables = strJoinTables & " WHERE "

        If cbxViewType.Text = "Custome" Then
            If CDate(dtpFrom.Value) < "1-Jan-13" Then
                cmd.CommandText = strSelectFields & " into ##" & TableName & strJoinTables _
                            & getDuration(cbxViewType.Text) & dk1b & strResult
            Else
                cmd.CommandText = strSelectFields & " into ##" & TableName & strJoinTables _
                            & getDuration(cbxViewType.Text) & dk1b & strResult
            End If

        Else
            cmd.CommandText = strSelectFields & " into ##" & TableName & strJoinTables _
                                & getDuration(cbxViewType.Text) & dk1b & strResult
        End If
        cmd.CommandText = cmd.CommandText & strGroupBy

        cmd.CommandTimeout = 1000
        cmd.ExecuteNonQuery()
        Cursor.Current = Cursors.Default
        btnOpen_Click(sender, e)
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim filePath As String
        'filePath = "X:\Xls from SQL\MIDT_Report.xlt"
        'If chkLimitedFieldsOnly.Checked Then
        '    filePath = My.Application.Info.DirectoryPath & "\MIDT_Report_LimitedFields.xlt"
        'Else
        filePath = My.Application.Info.DirectoryPath & "\MIDT_Report.xlt"
        'End If
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandTimeout = 1000

        If pobjSql.GetScalarAsDecimal("select COL_LENGTH('" & TableName & "','Carrier')") <> 0 Then

            cmd.CommandText = "Update ##" & TableName & " set isFlag=0 where carrier<>''"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update ##" & TableName & " set isFlag=1 where carrier<>'' " & getQuery()
            cmd.ExecuteNonQuery()
        Else
            cmd.CommandText = "Update ##" & TableName & " set isFlag=1 where isflag=0 " & getQuery()
            cmd.ExecuteNonQuery()
        End If

        Try
                eProcess.Kill()
            Catch ex As Exception
            End Try


            'Dim xlsApp As New Microsoft.Office.Interop.Excel.Application
            'Dim xlsWBa As Microsoft.Office.Interop.Excel.Workbook = xlsApp.Workbooks.Open(filePath)
            'xlsWBa.Worksheets(1).range("A1").value = "##" & TableName
            'xlsWBa.Close(SaveChanges:=True)
            'xlsApp.Quit()
            'xlsApp = Nothing
            eProcess = Process.Start(filePath)
    End Sub

    Public Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub

    'Private Sub BuildControl1(ByVal cmd As String, ByVal clbControl As CheckedListBox, DisplayMember As String)
    '    Dim dtl As System.Data.DataTable = BuildTable1(cmd)
    '    clbControl.DataSource = dtl
    '    clbControl.DisplayMember = DisplayMember
    'End Sub

    Private Sub DeclareArea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'con = New SqlConnection(cn)
        'con.Open()
        'con1 = New SqlConnection(cn1)
        'con1.Open()
        BuildControl("select city from citycode where Country='VN' order by city", clbCity1, "city")
        dgrFields.Rows.Add(False, "Date_b", True)
        dgrFields.Rows.Add(True, "BookMonth", True)
        dgrFields.Rows.Add(True, "BookYear", True)
        dgrFields.Rows.Add(True, "Carrier", True)
        dgrFields.Rows.Add(True, "GDS", True)
        dgrFields.Rows.Add(True, "City", True)
        dgrFields.Rows.Add(True, "AgentName", True)
        dgrFields.Rows.Add(True, "CRSCode", True)
        dgrFields.Rows.Add(False, "Class", True)
        dgrFields.Rows.Add(False, "Org_City", True)
        dgrFields.Rows.Add(False, "Org_Country", True)
        dgrFields.Rows.Add(False, "Des_City", True)
        dgrFields.Rows.Add(False, "Des_Country", True)
        dgrFields.Rows.Add(False, "Des_Area", True)
        dgrFields.Rows.Add(False, "Segment", True)

    End Sub

    Private Function getValues() As String
        Dim strResult As String = ""
        For Each itemChecked In clbCity1.CheckedItems
            If strResult = "" Then
                strResult = itemChecked.item("City").ToString
            Else
                strResult = strResult & "_" & itemChecked.item("City").ToString
            End If
        Next
        Return strResult
    End Function

    Private Sub rdoNorth_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNorth.CheckedChanged
        For i As Integer = 0 To clbCity.Items.Count - 1
            clbCity1.SetItemChecked(i, False)
        Next
        Dim cValue As Boolean = False
        Dim Area As String = ""
        If rdoNorth.Checked = True Then
            cValue = True
            Area = "North"
        Else
            cValue = False
        End If

        Dim strCities As String = ""
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Select val1 from scm.dbo.MISC where Fstuser='MDT' and Status='OK' and val='" & Area & "'"
        strCities = cmd.ExecuteScalar
        For i As Integer = 0 To clbCity1.Items.Count - 1
            If InStr(strCities, clbCity1.GetItemText(clbCity1.Items(i)).ToString) <> 0 Then
                clbCity1.SetItemChecked(i, cValue)
            End If
        Next
    End Sub

    'Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
    '    Dim strValues As String = getValues()
    '    Dim Area As String = ""
    '    If rdoNorth.Checked = True Then
    '        Area = "North"
    '    ElseIf rdoSouth.Checked = True Then
    '        Area = "South"
    '    ElseIf rdoOthers.Checked = True Then
    '        Area = "Other"
    '    End If
    '    Dim cmd As SqlCommand = con1.CreateCommand
    '    cmd.CommandText = "Update scm.dbo.MISC set status='XX' where CAT='MIDT' and val='" & Area & "' and FstUser='MDT'"
    '    cmd.ExecuteNonQuery()
    '    cmd.CommandText = "Insert scm.dbo.MISC (CAT,val,val1,val2,FstUser,FstUpdate,Status) values" & _
    '                    "('MIDT','" & Area & "','" & strValues & "','','MDT',getdate(),'OK')"
    '    cmd.ExecuteNonQuery()
    'End Sub

    Private Sub rdoSouth_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSouth.CheckedChanged
        For i As Integer = 0 To clbCity.Items.Count - 1
            clbCity1.SetItemChecked(i, False)
        Next
        Dim cValue As Boolean = False
        Dim Area As String = ""
        If rdoSouth.Checked = True Then
            cValue = True
            Area = "South"
        Else
            cValue = False
        End If

        Dim strCities As String = ""
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Select val1 from scm.dbo.MISC where Fstuser='MDT' and Status='OK' and val='" & Area & "'"
        strCities = cmd.ExecuteScalar
        For i As Integer = 0 To clbCity1.Items.Count - 1
            If InStr(strCities, clbCity1.GetItemText(clbCity1.Items(i)).ToString) <> 0 Then
                clbCity1.SetItemChecked(i, cValue)
            End If
        Next
    End Sub

    Private Sub rdoOthers_CheckedChanged(sender As Object, e As EventArgs) Handles rdoOthers.CheckedChanged
        For i As Integer = 0 To clbCity.Items.Count - 1
            clbCity1.SetItemChecked(i, False)
        Next
        Dim cValue As Boolean = False
        Dim Area As String = ""
        If rdoOthers.Checked = True Then
            cValue = True
            Area = "Other"
        Else
            cValue = False
        End If

        Dim strCities As String = ""
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Select val1 from scm.dbo.MISC where Fstuser='MDT' and Status='OK' and val='" & Area & "'"
        strCities = cmd.ExecuteScalar
        For i As Integer = 0 To clbCity1.Items.Count - 1
            If InStr(strCities, clbCity1.GetItemText(clbCity1.Items(i)).ToString) <> 0 Then
                clbCity1.SetItemChecked(i, cValue)
            End If
        Next
    End Sub

    Function defindQuarter(Month As Integer, Year As Integer) As String
        Dim strResult As String = ""
        Dim FrmDate As String
        Dim ToDate As String
        Dim aDate As Date
        Dim bDate As Date
        Dim rMonth As Integer
        Select Case Month
            Case 1, 2, 3
                rMonth = 1
            Case 4, 5, 6
                rMonth = 4
            Case 7, 8, 9
                rMonth = 7
            Case 10, 11, 12
                rMonth = 10
        End Select
        aDate = DateSerial(Year, rMonth, 1)
        FrmDate = aDate.ToString("dd-MMM-yy")
        bDate = DateSerial(Year, rMonth + 3, 0)
        ToDate = bDate.ToString("dd-MMM-yy")
        strResult = "date_b between " & "'" & FrmDate & "'" & " and " & "'" & ToDate & "'"
        Return strResult
    End Function

    Private Sub ActiveCustomize(Active As Boolean)
        If Active = False Then
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        Else
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        End If
    End Sub

    Private Function getDuration(strType As String) As String
        Dim strResult As String = "RecID>1"
        Dim FrmDate As String
        Dim ToDate As String
        Dim aDate As Date
        Dim bDate As Date
        If strType = "This MTD" Then
            aDate = DateSerial(Date.Now.Year, Date.Now.Month, 1)
            bDate = DateSerial(Date.Now.Year, Date.Now.Month + 1, 0)
            FrmDate = aDate.ToString("dd-MMM-yy")
            ToDate = bDate.ToString("dd-MMM-yy")
            ActiveCustomize(False)
            strResult = "date_b between " & "'" & FrmDate & "'" & " and " & "'" & ToDate & "'"
        ElseIf strType = "This QTD" Then
            ActiveCustomize(False)
            strResult = defindQuarter(Date.Now.Month, Date.Now.Year)
        ElseIf strType = "This YTD" Then
            aDate = DateSerial(Date.Now.Year, 1, 1)
            bDate = DateSerial(Date.Now.Year, 12 + 1, 0)
            FrmDate = aDate.ToString("dd-MMM-yy")
            ToDate = bDate.ToString("dd-MMM-yy")
            ActiveCustomize(False)
            strResult = "date_b between " & "'" & FrmDate & "'" & " and " & "'" & ToDate & "'"
        ElseIf strType = "Last Month" Then
            aDate = DateSerial(Date.Now.Year, Date.Now.Month - 1, 1)
            bDate = DateSerial(Date.Now.Year, Date.Now.Month, 0)
            FrmDate = aDate.ToString("dd-MMM-yy")
            ToDate = bDate.ToString("dd-MMM-yy")
            ActiveCustomize(False)
            strResult = "date_b between " & "'" & FrmDate & "'" & " and " & "'" & ToDate & "'"
        ElseIf strType = "Last Quarter" Then
            ActiveCustomize(False)
            strResult = defindQuarter(Date.Now.Month, Date.Now.Year - 1)
        ElseIf strType = "Last Year" Then
            aDate = DateSerial(Date.Now.Year - 1, 1, 1)
            bDate = DateSerial(Date.Now.Year - 1, 12 + 1, 0)
            FrmDate = aDate.ToString("dd-MMM-yy")
            ToDate = bDate.ToString("dd-MMM-yy")
            ActiveCustomize(False)
            strResult = "date_b between " & "'" & FrmDate & "'" & " and " & "'" & ToDate & "'"
        ElseIf strType = "Custome" Then
            ActiveCustomize(True)
            strResult = "date_b  between '" & Format(dtpFrom.Value, "dd-MMM-yy") & "' and '" & Format(dtpTo.Value, "dd-MMM-yy") & "'"
        End If
        Return strResult
    End Function

    Private Sub cbxViewType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxViewType.SelectedIndexChanged
        If cbxViewType.Text = "Custome" Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
    End Sub

End Class
