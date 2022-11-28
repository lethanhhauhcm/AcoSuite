Imports Microsoft.Office.Interop.Outlook
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Public Class frmSaleLog
    'Private cn As String = "Data Source=172.16.2.6;Initial Catalog=Mktg_MIDT;User ID=midtusers; password=sresutdim"
    'Private con As SqlConnection

    Function BuildTable(ByVal cmd As String) As System.Data.DataTable
        Dim dtl As New System.Data.DataTable
        Dim adt As New SqlDataAdapter(cmd, pobjSql.Connection)
        adt.Fill(dtl)
        Return dtl
    End Function

    Private Sub BuildGridCust(strFindCust As String)
        Dim cmd As String
        Dim DK As String = ""
        If strFindCust <> "" Then
            DK = " and AccountNameGB like N'%" & strFindCust & "%'"
        End If
        cmd = "select Recid, ShortName, AccountNameGB, PIC from DATA1A_Customers where status='OK' " & DK & " and Region='" & cbxArea.Text & "' order by shortname"
        bdsCust.DataSource = BuildTable(cmd)
        GridCust.DataSource = bdsCust
        GridCust.Columns("RecID").Visible = False
    End Sub

    Private Sub BuildDgvCost()
        Dim cmd As String
        cmd = "Select RecID, ValidFrom, ValidThru, Cost, FstUser from SL_CostSetting where status='OK'"
        dgvCost.DataSource = BuildTable(cmd)
        GridCust.Columns("RecID").Visible = False
    End Sub

    Private Sub BuildGridPendingCall()
        Dim cmd As String
        cmd = "Select s.Recid, AccountNameGB, ShortName, Subject, FrmTime, ToTime, PreCall, OverPhone, NoCost, CustID, ContactID From SaleLog1A s left join DATA1A_Customers a on s.CustID=a.RecID" & _
            " where s.Status='NW' and S.FstUser='" & pobjUser.UserName & "'"
        bdsPendingCall.DataSource = BuildTable(cmd)
        GridPendingCall.DataSource = bdsPendingCall
        GridPendingCall.Columns("RecID").Visible = False
        GridPendingCall.Columns("FrmTime").Visible = False
        GridPendingCall.Columns("ToTime").Visible = False
        GridPendingCall.Columns("CustID").Visible = False
        GridPendingCall.Columns("ContactID").Visible = False
        GridPendingCall.Columns("ShortName").Visible = False
        GridPendingCall.ClearSelection()
    End Sub

    Private Sub BuildGridReview(CustID As Integer)
        Dim cmd As String
        Dim DK As String = ""
        If ChkSelectCust.Checked = True Then
            DK = DK & " and CustID=" & CustID
        End If
        If cbxUser.Text <> "" Then
            DK = DK & " and S.FstUser='" & cbxUser.Text & "'"
        End If
        cmd = "Select S.RecID, AccountNameGB, Subject, FrmTime, ToTime, PreCall, AfterCall, OverPhone, NoCost, S.FstUser" & _
            " From SaleLog1A s left join DATA1A_Customers a on s.CustID=a.RecID where s.Status='OK' and FrmTime between" & _
            " '" & Format(dtpRptTimeFrm.Value, "dd-MMM-yy") & "' and '" & Format(dtpRptTimeThru.Value, "dd-MMM-yy") & " 23:59' " & DK
        bdsReview.DataSource = BuildTable(cmd)
        GridDoneCall.DataSource = bdsReview
        GridDoneCall.Columns("RecID").Visible = False
    End Sub

    'Private Sub BuildGridContact(CustID As Integer)
    '    Dim cmd As String
    '    cmd = "select Recid, ContactName, Phone from DATA1A_Contacts where status='OK' and contactID=" & CustID & " order by ContactName "
    '    bdsContactList.DataSource = BuildTable(cmd)
    '    dgvContact.DataSource = bdsContactList
    '    dgvContact.Columns("RecID").Visible = False
    'End Sub

    'Tạo Remind trong outlook
    Private Sub CreatePointmentItem(ByVal requireAttendees As String, ByVal subject As String, ByVal location As String, _
    ByVal startDate As String, ByVal endDate As String, ByVal body As String)
        Dim outApp As Application
        Dim outAppoint As AppointmentItem
        Dim dStart As Date = Convert.ToDateTime(startDate)
        Dim dEnd As Date = Convert.ToDateTime(endDate)
        outApp = CreateObject("Outlook.Application")
        outAppoint = outApp.CreateItem(OlItemType.olAppointmentItem)
        With outAppoint
            If requireAttendees <> "" Then
                .MeetingStatus = OlMeetingStatus.olMeeting
                Dim oRecipts As Recipients = .Recipients
                ' Add required attendee.
                Dim oRecipt As Recipient
                oRecipt = oRecipts.Add(requireAttendees)
                oRecipt.Type = OlMeetingRecipientType.olRequired
                oRecipts.ResolveAll()
            End If

            .RequiredAttendees = requireAttendees
            .Subject = subject
            .Location = location
            .Start = Convert.ToDateTime(dStart)
            .End = Convert.ToDateTime(dEnd)
            .Body = body
            .ReminderSet = True
            If requireAttendees <> "" Then
                .Send()
            Else
                .Save()
            End If
        End With
    End Sub

    Private Sub InsertAppointment(CustID As Integer, CustShortName As String, Subject As String, FrmTime As Date, ToTime As Date, PreCall As String, _
                                 FstUser As String, FstUpdate As Date, Status As String, OverPhone As Boolean, NoCost As Boolean, ContactID As Integer)
        Dim cmd As New SqlCommand
        Dim strQuery As String
        strQuery = "Insert SaleLog1A(CustID, CustShortName, Subject, FrmTime, ToTime, Precall, FstUser, FstUpdate, Status, OverPhone, NoCost, ContactID) values" & _
                    "(@CustID, @CustShortName, @Subject, @FrmTime, @ToTime, @Precall, @FstUser, @FstUpdate, @Status, @OverPhone, @NoCost, @ContactID)"
        cmd = New SqlCommand(strQuery)
        cmd.Connection = pobjSql.Connection
        cmd.Parameters.Add("@CustID", SqlDbType.Int).Value = CustID
        cmd.Parameters.Add("@CustShortName", SqlDbType.VarChar).Value = CustShortName
        cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = Subject
        cmd.Parameters.Add("@FrmTime", SqlDbType.SmallDateTime).Value = FrmTime
        cmd.Parameters.Add("@ToTime", SqlDbType.SmallDateTime).Value = ToTime
        cmd.Parameters.Add("@Precall", SqlDbType.NVarChar).Value = PreCall
        cmd.Parameters.Add("@FstUser", SqlDbType.VarChar).Value = FstUser
        cmd.Parameters.Add("@FstUpdate", SqlDbType.SmallDateTime).Value = FstUpdate
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
        cmd.Parameters.Add("@OverPhone", SqlDbType.VarChar).Value = OverPhone
        cmd.Parameters.Add("@NoCost", SqlDbType.Bit).Value = NoCost
        cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub UpdateAppointment(FrmTime As Date, ToTime As Date, PreCall As String, _
                                 LstUser As String, LstUpdate As Date, RecID As Integer, ContactID As Integer)
        Dim cmd As New SqlCommand
        Dim strQuery As String
        strQuery = "Update SaleLog1A set FrmTime=@FrmTime,ToTime=@ToTime,Precall=@PreCall,LstUser=@LstUser," & _
                    "LstUpdate=@LstUpdate, ContactID=@ContactID where RecID=@RecID"
        cmd = New SqlCommand(strQuery)
        cmd.Connection = pobjSql.Connection
        cmd.Parameters.Add("@FrmTime", SqlDbType.SmallDateTime).Value = FrmTime
        cmd.Parameters.Add("@ToTime", SqlDbType.SmallDateTime).Value = ToTime
        cmd.Parameters.Add("@Precall", SqlDbType.NVarChar).Value = PreCall
        cmd.Parameters.Add("@LstUser", SqlDbType.VarChar).Value = LstUser
        cmd.Parameters.Add("@LstUpdate", SqlDbType.SmallDateTime).Value = LstUpdate
        cmd.Parameters.Add("@RecID", SqlDbType.Int).Value = RecID
        cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub LblMakeAppt_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblMakeAppt.LinkClicked
        Dim CustID As Integer = 0
        Dim CustShortName As String = "My appointment only"
        If bdsCust.Count > 0 Then
            Dim dtr As DataRowView = bdsCust.Current
            If rdoCust.Checked = True Then
                CustID = dtr("RecID")
                CustShortName = dtr("ShortName")
            End If
            InsertAppointment(CustID, CustShortName, cbxSubj.Text, dtpStart.Value, dtpEnd.Value, TxtPre.Text, pobjUser.UserName, Date.Now, _
                              "NW", ChkByPhone.Checked, chkNoCost.Checked, cbxContactBefore.SelectedValue)
            CreatePointmentItem("", dtr("AccountNameGB") & ": " & cbxSubj.Text, "", dtpStart.Value, dtpEnd.Value, TxtPre.Text)
            TabControl1.SelectTab(1)
        End If
        cbxSubj.Text = ""
        TxtPre.Text = ""
    End Sub

    Private Sub txtCustShortName_TextChanged(sender As Object, e As EventArgs) Handles txtCustShortName.TextChanged
        If pobjSql.Connection.State = ConnectionState.Closed Then
            pobjSql.Connection.Open()
        End If
        BuildGridCust(txtCustShortName.Text)
    End Sub

    Public Sub BuildControl(ByVal cmd As String, ByVal pValue As String, ByVal pDisplay As String, ByVal obj As Object)
        Dim dtl As DataTable = BuildTable(cmd)
        obj.DataSource = dtl
        obj.DisplayMember = pDisplay
        obj.ValueMember = pValue
    End Sub

    Private Sub SaleLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxArea.Text = "South"
        BuildGridCust("")
        BuildControl("select UserName from mktg_midt.dbo.DATA1A_User where status='OK' order by UserName", "UserName", "UserName", cbxUser)
        BuildControl("select UserName from mktg_midt.dbo.DATA1A_User where status='OK' order by UserName", "UserName", "UserName", cbxPIC)
        cbxUser.Text = pobjUser.UserName
        If UCase(pobjUser.Role) = "ADMIN" Then
            cbxUser.Enabled = True
        Else
            cbxUser.Enabled = False
            'TabControl1.TabPages.Remove(TabControl1.TabPages("TabPage4"))
        End If
        BuildDgvCost()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "TabPage2" Then
            BuildGridPendingCall()
        End If
    End Sub

    Private Sub LblDone_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblDone.LinkClicked
        Try
            Dim dtr As DataRowView = bdsPendingCall.Current
            Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
            Dim cost As Double = 0
            If txtSaleCost.Text <> "" Then
                cost = txtSaleCost.Text
            End If
            cmd.CommandText = "Update SaleLog1A set Status='OK',Cost=" & cost & ", LstUser='" & pobjUser.UserName & "', LstUpdate=getdate(), AfterCall=N'" & TxtPost.Text.Replace("'", "") & "' where RecID=" & dtr("RecID")
            cmd.ExecuteNonQuery()
            BuildGridPendingCall()
            TxtPost.Text = ""
            TxtPreView.Text = ""
        Catch ex As System.Exception
            MsgBox("You must choose one salecall to complete!")
        End Try

    End Sub

    Private Sub LblCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblCancel.LinkClicked
        Dim dtr As DataRowView = bdsPendingCall.Current
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Update SaleLog1A set Status='XX', aftercall=N'" & TxtPost.Text.Replace("'", "") & "', LstUser='" & pobjUser.UserName & "', LstUpdate=getdate() where RecID=" & dtr("RecID")
        cmd.ExecuteNonQuery()
        BuildGridPendingCall()
        TxtPost.Text = ""
        TxtPreView.Text = ""
    End Sub

    Private Sub LblUpdatePrepar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblUpdatePrepar.LinkClicked
        If bdsPendingCall.Count > 0 Then
            Dim dtr As DataRowView = bdsPendingCall.Current
            UpdateAppointment(dtpNewStart.Value, dtpNewEnd.Value, TxtPreView.Text, pobjUser.UserName, Date.Now, dtr("RecID"), cbxContact_After.SelectedValue)
            CreatePointmentItem("", dtr("AccountNameGB") & ": " & dtr("Subject"), "", dtpNewStart.Value, dtpNewEnd.Value, TxtPreView.Text)
            BuildGridPendingCall()
        End If
    End Sub

    Private Sub LblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblRefresh.LinkClicked
        Dim dtr As DataRowView = bdsCust.Current
        BuildGridReview(dtr("RecID"))
    End Sub

    Private Sub bdsPendingCall_CurrentChanged(sender As Object, e As EventArgs) Handles bdsPendingCall.CurrentChanged
        If bdsPendingCall.Count > 0 Then
            Dim dtr As DataRowView = bdsPendingCall.Current
            BuildControl("select RecID, FullNameGB from DATA1A_Contacts where status='OK' and CustShortName='" & dtr("ShortName") & "' order by FullNameGB", "RecID", "FullNameGB", cbxContact_After)
            TxtPreView.Text = dtr("PreCall")
            dtpNewStart.Value = dtr("FrmTime")
            dtpNewEnd.Value = dtr("ToTime")
            cbxContact_After.Text = ""
            cbxContact_After.SelectedValue = IIf(dtr("ContactID") = 0, "", dtr("ContactID"))
        End If
    End Sub

    Private Sub bdsReview_CurrentChanged(sender As Object, e As EventArgs) Handles bdsReview.CurrentChanged
        If bdsReview.Count > 0 Then
            Dim dtr As DataRowView = bdsReview.Current
            txtPostView.Text = dtr("AfterCall")
            If dtr("FstUser") = pobjUser.UserName Then
                lnkDeleteSaleLog.Visible = True
            Else
                lnkDeleteSaleLog.Visible = False
            End If
        End If
    End Sub

    Private Sub chkCost_CheckedChanged(sender As Object, e As EventArgs) Handles chkCost.CheckedChanged
        If chkCost.Checked = True Then
            txtSaleCost.Enabled = True
        Else
            txtSaleCost.Enabled = False
        End If
    End Sub

    Private Sub txtSaleCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSaleCost.KeyPress, txtCost.KeyPress
        Dim ValidChar As String = "0123456789." + Convert.ToChar(8).ToString()
        If ValidChar.Contains(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub lnkAddSetting_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddSetting.LinkClicked
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Insert SL_CostSetting(ValidFrom,ValidThru,Cost,Status,FstUser) values" &
                " ('" & Format(dtpFrom.Value, "dd-MMM-yy") & "','" & Format(dtpTo.Value, "dd-MMM-yy") & " 23:59'," & txtCost.Text _
                & ",'OK','" & pobjUser.UserName & "') "
        cmd.ExecuteNonQuery()
        BuildDgvCost()
    End Sub

    Private Sub lnkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelete.LinkClicked
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Update SL_CostSetting set Status='XX' where RecID=" & dgvCost.CurrentRow.Cells("RecID").Value
        cmd.ExecuteNonQuery()
        BuildDgvCost()
    End Sub

    Private Sub lnkDeleteSaleLog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDeleteSaleLog.LinkClicked
        Dim dtr As DataRowView = bdsReview.Current
        Dim cmd As SqlCommand = pobjSql.Connection.CreateCommand
        cmd.CommandText = "Update SaleLog1A set Status='XX', LstUser='" & pobjUser.UserName & "', LstUpdate=getdate() where RecID=" & dtr("RecID")
        cmd.ExecuteNonQuery()
        Dim dtr1 As DataRowView = bdsCust.Current
        BuildGridReview(dtr1("RecID"))
    End Sub

    Public Sub RunReport(ByVal strPath As String, ByVal parFileName As String, _
                         ByVal strRegion As String, strPic As String, strFromDate As String, strToDate As String)
                         
        Dim AppXls As Microsoft.Office.Interop.Excel.Application, WkBook As Microsoft.Office.Interop.Excel.Workbook,
            WkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim varAL As String
        If parFileName = "" Then
            MsgBox("Please Select File to Run", MsgBoxStyle.Critical, "1A Sale Log System")
            Exit Sub
        End If

        On Error Resume Next
        AppXls = CreateObject("Excel.Application")
        AppXls.Visible = True
        WkBook = AppXls.Workbooks.Open(strPath & "\" & parFileName, , , , "RPT1234", , , , , , True)

        WkSheet = WkBook.Worksheets("Para")
        WkSheet.Cells.Range("B1").Value = strRegion
        WkSheet.Cells.Range("B2").Value = strPic
        WkSheet.Cells.Range("B3").Value = strFromDate
        WkSheet.Cells.Range("B4").Value = strToDate
        WkSheet.Cells.Range("B10").Value = "a"
        Exit Sub

    End Sub

    Private Sub lnkRunReport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRunReport.LinkClicked
        If cbxReportType.Text = "" Then
            MsgBox("You must select Report type")
            Exit Sub
        End If
        RunReport(System.Windows.Forms.Application.StartupPath, "Salelog" & cbxReportType.Text & ".xlt" _
                  , pobjUser.City, cbxPIC.Text, Format(dtpDate1.Value, "dd-MMM-yy"), Format(dtpDate2.Value, "dd-MMM-yy"))
    End Sub

    Private Sub bdsCust_CurrentChanged(sender As Object, e As EventArgs) Handles bdsCust.CurrentChanged
        Dim dtr As DataRowView = bdsCust.Current
        BuildControl("select RecID, FullNameGB from DATA1A_Contacts where status='OK' and CustShortName='" & dtr("ShortName") & "' order by FullNameGB", "RecID", "FullNameGB", cbxContactBefore)
        Dim dtl As DataTable = GetDataTable("Select distinct gds, Offcid from DATA1A_OIDs where ShortName='" & dtr("ShortName") & "' and status='OK'")
        dgvOfficeID.DataSource = dtl
    End Sub

    Private Sub cbxArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxArea.SelectedIndexChanged
        BuildGridCust("")
    End Sub
End Class