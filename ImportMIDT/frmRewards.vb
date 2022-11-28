Imports SharedFunctions.MySharedFunctions
Imports SharedFunctions.MySharedFunctionsWzConn
Public Class frmRewards
    Dim Cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
    Dim Cmd_web As SqlClient.SqlCommand = Conn_Web.CreateCommand
    Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Cmd_web.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MMM-yy"
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern = "HH:mm"
        If Conn_Web.State = ConnectionState.Closed Then
            Conn_Web.ConnectionString = CnStr_TVW
            Conn_Web.Open()
        End If
        
        SetMenuStatus(MenuStrip1, pobjUser)
        pubVarBackColor = GetColorForToday()

        
    End Sub

    Private Sub CmdLogInOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.txtLogInSIcode.Text = Replace(Me.txtLogInSIcode.Text, "'", "")
        'If Me.txtLogInSIcode.Text.Length < 3 Then Exit Sub
        'Dim tmpSIcode As String = "", tmpPSW As String = "", tmpNewPSW = GenDefaultPSW(Me.txtLogInSIcode.Text, "R12")
        'Dim PhaidoiPSW As Boolean = False
        'pobjUser.UserName = Replace(Me.txtLogInSIcode.Text, "--", "")
        'PhaidoiPSW = False
        'If DateDiff(DateInterval.Day, pobjUser.CreateDate, Now) > 2 Then
        '    If Me.txtLogInPSW.Text = tmpNewPSW Or Me.txtLogInPSW.Text = "Abcd1234" Or Me.txtLogInPSW.Text = "" Then
        '        PhaidoiPSW = True
        '    End If
        'End If
        'If pobjUser.UID = 0 Or pobjUser.PSW <> HashToFixedLen(Me.txtLogInPSW.Text) Then
        '    pobjUser.UserName = ""
        '    MsgBox("Invalid SI Code or Password", MsgBoxStyle.Critical, msgTitle)
        '    Me.GrpLogIn.Visible = True
        'ElseIf PhaidoiPSW Then
        '    Me.BarChangePSW.Enabled = True
        '    Me.GrpLogIn.Visible = False
        '    MsgBox("You Have To Change Default Password Before Continue", MsgBoxStyle.Critical, msgTitle)
        'Else
        '    SaveSetting("car", "dangkiem", "Type", pobjUser.UserName)
        '    cmd.CommandText = ChangeStatus_ByDK("tblUser", "ON", "where SICode='" & pobjUser.UserName & "'")
        '    cmd.ExecuteNonQuery()
        '    LogInOut(pobjUser.UserName)
        'End If
    End Sub
    
    
    Private Sub BarUserManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarUserManager.Click
        Me.GrpUserManager.Top = 20
        Me.GrpUserManager.Left = 10
        Me.GrpUserManager.Visible = True
        Me.CmbUserType.Text = "BKR"
    End Sub
    

    Private Sub CmbUserType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbUserType.SelectedIndexChanged
        
        Me.CmbTitle.DataSource = GetDataTable("select VAL from MISC where cat='POSITION'", Conn_Web)
        Me.CmbTitle.DisplayMember = "VAL"
        Me.LblUserName.Text = "eMail"
        Me.TxtSICode.Width = 200
        Me.Label8.Left = 268
        Me.TxtSIName.Left = 318

        Me.PnlBkrInfor.Visible = True

    End Sub
    Private Sub TxtSICode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSICode.LostFocus
        Dim tmpSIname As String = "", tmpTbl As DataTable
        Me.LblSave.Visible = False
        Me.lblChangeMail.Visible = False
        Me.CmdCreateUser.Enabled = False
        Me.CmdDeleteUser.Enabled = False


        ' decheck xem SI ton tai chua de xem tao hay Edit, bo qua yeu to City
        If Me.CmbUserType.Text = "BKR" Then
            tmpSIname = ScalarToString("tblUser", "SIName", "email='" & Me.TxtSICode.Text & "' and status <>'XX'", Conn_Web)
        ElseIf Me.CmbUserType.Text = "AGT" Then

        End If

        If tmpSIname = "" Then 'SI chua tung ton tai
            Me.CmdCreateUser.Enabled = True
        Else ' SI da ton tai, check tiep theo City cua admin
            Me.CmdCreateUser.Enabled = False
            If Me.CmbUserType.Text = "ACO" Then
                tmpSIname = ScalarToString("tblUser", "SIName", "SICode='" & Me.TxtSICode.Text & "' and city='" & pobjUser.City & "' and status <>'XX'", pobjSql.Connection)
            ElseIf Me.CmbUserType.Text = "BKR" Then
                tmpSIname = ScalarToString("tblUser", "SIName", "email='" & Me.TxtSICode.Text & "'and city='" & pobjUser.City & "' and status <>'XX'", Conn_Web)
            ElseIf Me.CmbUserType.Text = "AGT" Then

            End If
            If tmpSIname = "" Then Exit Sub ' ko phai cung city Admin
            Me.TxtSIName.Text = tmpSIname
            Me.CmdDeleteUser.Enabled = True

        End If
        Me.TxtSIName.Enabled = Me.CmdCreateUser.Enabled
        If Me.CmbUserType.Text = "BKR" And tmpSIname <> "" Then
            tmpTbl = GetDataTable("Select * from tbluser where Email='" & Me.TxtSICode.Text & "'", Conn_Web)
            Me.TxtMobile.Text = tmpTbl.Rows(0)("mobile")
            Me.TxtAddr.Text = tmpTbl.Rows(0)("Address")
            Me.CmbSex.Text = tmpTbl.Rows(0)("sex")
            Me.CmbTitle.Text = tmpTbl.Rows(0)("Position")
            If Not IsDBNull(tmpTbl.Rows(0)("Birthday")) Then
                Me.TxtDOB.Value = tmpTbl.Rows(0)("Birthday")
            End If
            Me.txtUserID.Text = tmpTbl.Rows(0)("RecID")
            Me.LblSave.Visible = True
            Me.lblChangeMail.Visible = True
        End If
    End Sub


    Private Sub CmdUserManagementDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDeleteUser.Click
        Dim myAnswer As Int16, strDK As String = String.Format(" where SIcode='{0}'", Me.TxtSICode.Text)
        Dim strSQL As String
        myAnswer = MsgBox("Wanna Delete This User Permanently?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, msgTitle)
        If Me.CmbUserType.Text = "ACO" Then
            If myAnswer = vbNo Then Exit Sub
            strSQL = UpdateLogFile("tblUser", "Del User", Me.TxtSICode.Text, Me.TxtSIName.Text, "", "", "")
            strSQL = strSQL & "; Delete from tblUser " & strDK
            strSQL = strSQL & "; delete from tblright " & strDK
            MsgBox(Me.TxtSICode.Text & " Has Been Deleted!", MsgBoxStyle.Information, msgTitle)
            Cmd.CommandText = strSQL
            Cmd.ExecuteNonQuery()
        ElseIf Me.CmbUserType.Text = "BKR" Then
            Cmd.CommandText = UpdateLogFile("tblUser", "Del User", Me.TxtSICode.Text, Me.TxtSIName.Text, "", "", "")
            Cmd.ExecuteNonQuery()
            Cmd_web.CommandText = "update tblUser set status='XX', lstUser='" & pobjUser.UserName & "', LstUpdate=getdate() where RecID=" & Me.txtUserID.Text
            Cmd_web.ExecuteNonQuery()
        End If
    End Sub
    Private Function InvalidPhone_Email() As Boolean
        If Me.TxtMobile.Text.Substring(0, 4) = "849" And Me.TxtMobile.Text.Length <> 11 Then Return True
        If Me.TxtMobile.Text.Substring(0, 4) = "841" And Me.TxtMobile.Text.Length <> 12 Then Return True
        If InStr(Me.TxtSICode.Text, "@") = 0 Then Return True
        Return False
    End Function
    Private Sub CmdUserManagementCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCreateUser.Click
        Dim tmpNewPSW As String = GenDefaultPSW(Me.TxtSICode.Text, "RWD")


        If InvalidPhone_Email() Then
            MsgBox("Invalid Mobile/Email Format", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        End If

        Cmd.CommandText = "insert into tbluser (City, FstUser, SIname, PSW, Sex, Position, Mobile, Email, Address, Birthday) " & _
                " values (@City, @FstUser, @SIName, @PSW, @Sex, @Position, @Mobile, @Email, @Address, @Birthday)"
            Cmd.Parameters.Clear()
            Cmd.Parameters.Add("@FstUser", SqlDbType.VarChar).Value = pobjUser.UserName
            Cmd.Parameters.Add("@SIname", SqlDbType.VarChar).Value = Me.TxtSIName.Text
            Cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = pobjUser.City
            Cmd.Parameters.Add("@PSW", SqlDbType.VarChar).Value = HashToFixedLen(tmpNewPSW)
            Cmd.Parameters.Add("@Sex", SqlDbType.VarChar).Value = Me.CmbSex.Text
            Cmd.Parameters.Add("@Position", SqlDbType.VarChar).Value = Me.CmbTitle.Text
            Cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = Me.TxtMobile.Text
            Cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Me.TxtSICode.Text
            Cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Me.TxtAddr.Text
            Cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = Me.TxtDOB.Value.Date
            Cmd.ExecuteNonQuery()

        MsgBox("User " & Me.TxtSICode.Text & " Has Been Created. Initial PSW is " & tmpNewPSW & ". Ask Him/Her to Change PSW", MsgBoxStyle.Information, msgTitle)
    End Sub

    Private Sub BarGiftManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarGiftManager.Click
        frmGiftManager.ShowDialog()
    End Sub
    Private Sub LblUserMapping_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblUserMapping.LinkClicked
        Dim f As New UserMapping(Me.TxtSICode.Text, "Staff")
        f.ShowDialog()
    End Sub

    Private Sub CmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClose.Click
        Me.GrpUserManager.Visible = False
    End Sub

    Private Sub BarAdhPointUpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarAdhPointUpdater.Click
        AdhocPoint.ShowDialog()
    End Sub
    Private Sub LblSave_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblSave.LinkClicked
        Cmd_web.CommandText = "update tbluser set Sex=@Sex, Position=@Position, Mobile=@Mobile, Address=@Address, Birthday=@Birthday " & _
            " where recid=" & Me.txtUserID.Text
        Cmd_web.Parameters.Clear()
        Cmd_web.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = Me.CmbSex.Text
        Cmd_web.Parameters.Add("@Position", SqlDbType.VarChar).Value = Me.CmbTitle.Text
        Cmd_web.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = Me.TxtMobile.Text
        Cmd_web.Parameters.Add("@Address", SqlDbType.VarChar).Value = Me.TxtAddr.Text
        Cmd_web.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = Me.TxtDOB.Value.Date
        Cmd_web.ExecuteNonQuery()
        MsgBox("User Infor Has Been Updated", MsgBoxStyle.Information, msgTitle)
    End Sub

    Private Sub BarQuickView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarQuickView.Click
        QuickView.ShowDialog()
    End Sub

    Private Sub BarPointManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarPointManager.Click
        AllstatUpload.ShowDialog()
    End Sub
    Private Sub LblVeriry_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblVeriry.LinkClicked
        Me.GrpVerify.Visible = True
        Me.GrpUserManager.Visible = False
        Me.GrpVerify.Top = 4
        Me.GrpVerify.Left = 4
        Me.GrpVerify.Width = 767
        Me.GrpVerify.Height = 444
        loadGridNewMember()
    End Sub
    Private Sub LoadGridNewMember()
        Me.GridNewMember.DataSource = GetDataTable("Select RecID, SIname, Mobile, Email, BirthDay, '' as Office, '' as SIcode from tblUser where status='QQ' and city='" & pobjUser.City & "'", Conn_Web)
        Me.GridNewMember.Columns(0).Visible = True
        For i As Int16 = 0 To Me.GridNewMember.RowCount - 1
            Me.GridNewMember.Item("Office", i).Value = ScalarToString("UserMapping", "Office", "UserID=" & Me.GridNewMember.Item("RecID", i).Value, Conn_Web)
            Me.GridNewMember.Item("SIcode", i).Value = ScalarToString("UserMapping", "SICode", "UserID=" & Me.GridNewMember.Item("RecID", i).Value, Conn_Web)
        Next
    End Sub
    Private Sub GridNewMember_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridNewMember.CellContentClick
        Me.LblAccept.Visible = True
        Me.LblRejectNewMember.Visible = True
        lbkEdit.Visible = True
    End Sub

    Private Sub LblCloseMemberVerify_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblCloseMemberVerify.LinkClicked
        Me.GrpVerify.Visible = False
        Me.GrpUserManager.Visible = True
    End Sub

    Private Sub LblAccept_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblAccept.LinkClicked
        Dim tmpID As Integer, OFC As String, SI As String
        OFC = Me.GridNewMember.CurrentRow.Cells("Office").Value
        SI = Me.GridNewMember.CurrentRow.Cells("SIcode").Value

        tmpID = ScalarToInt("Allstatssi", "top 1 RecID", "Office='" & OFC & "' and Left(SIcode,6)='" & SI & "'", pobjSql.Connection)
        If tmpID = 0 Or SI.Length <> 6 Then
            MsgBox("Invalid Office or SIcode", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        End If
        tmpID = ScalarToInt("UserMapping", "RecID", "Office='" & OFC & "' and Left(SIcode,6)='" & SI & "' AND status='OK'", Conn_Web)
        If tmpID > 0 Then
            MsgBox("This Office/SIcode Already Exists", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        End If
        Cmd_web.CommandText = ChangeStatus_ByID("tblUser", "OK", Me.GridNewMember.CurrentRow.Cells("RecID").Value) & ";" & _
            ChangeStatus_ByDK("UserMapping", "OK", "UserID=" & Me.GridNewMember.CurrentRow.Cells("RecID").Value)
        Cmd_web.ExecuteNonQuery()
        LoadGridNewMember()
    End Sub

    Private Sub LblRejectNewMember_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblRejectNewMember.LinkClicked
        Cmd_web.CommandText = ChangeStatus_ByID("tblUser", "XX", Me.GridNewMember.CurrentRow.Cells("RecID").Value) & ";" & _
            ChangeStatus_ByDK("UserMapping", "XX", "UserID=" & Me.GridNewMember.CurrentRow.Cells("RecID").Value)
        Cmd_web.ExecuteNonQuery()
        loadGridNewMember()
    End Sub
    Private Sub BarNewsUpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarNewsUpdater.Click
        NewsUpdater.ShowDialog()
    End Sub
    Private Sub BarOrderHandler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarOrderHandler.Click
        frmOrderHandler.ShowDialog()
    End Sub

    Private Sub BarPromoManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarPromoManager.Click
        PromoManager.ShowDialog()
    End Sub

    Private Sub lblChangeMail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblChangeMail.LinkClicked
        Dim tmpRecNo As Integer
        Cmd_web.CommandText = "select RecID from tblUser where status='OK' and RecID<>" & CInt(Me.txtUserID.Text) & " and email='" & Me.TxtSICode.Text & "'"
        tmpRecNo = Cmd_web.ExecuteScalar
        If tmpRecNo > 0 Then
            MsgBox("This Email Has Been Exist", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        End If
        Cmd_web.CommandText = "update tbluser set email='" & Me.TxtSICode.Text & "' where recid=" & CInt(Me.txtUserID.Text)
        Cmd_web.ExecuteNonQuery()
        Me.lblChangeMail.Visible = False
        MsgBox("Email Has Been Changed", MsgBoxStyle.Information, msgTitle)
    End Sub

    Private Sub BarAgentOIDMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarAgentOIDMapping.Click
        Agent.ShowDialog()
    End Sub

    Private Sub LblOwner_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblOwner.LinkClicked
        Dim f As New UserMapping(Me.TxtSICode.Text, "OWNER")
        f.ShowDialog()
    End Sub

    Private Sub lbkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkEdit.LinkClicked
        Dim frmEdit As New frmRewardsUserEdit(GridNewMember.CurrentRow)
        If frmEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
            LoadGridNewMember()
            frmEdit.Dispose()
        End If
    End Sub
End Class
