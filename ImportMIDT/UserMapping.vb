Public Class UserMapping
    Private UserName As String, WhoIs As String
    Dim cmd As SqlClient.SqlCommand = Conn_Web.CreateCommand
    Sub New(ByVal pUser As String, pUserOnwner As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        UserName = pUser
        WhoIs = pUserOnwner
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub UserMapping_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub UserMapping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtEmail.Text = UserName
        Me.BackColor = pubVarBackColor
        If WhoIs = "OWNER" Then Me.CmbSI.Visible = False
    End Sub
    Private Sub TxtEmail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEmail.LostFocus
        Me.TxtUserID.Text = ScalarToInt("tblUser", "RecID", "upper(email)='" & Me.TxtEmail.Text.ToUpper & "' and status <>'XX'", Conn_Web)
        If CInt(Me.TxtUserID.Text) = 0 Then Exit Sub
        cmd.CommandText = "select SiName from TblUser where recid=" & CInt(Me.TxtUserID.Text)
        Me.TxtSIName.Text = cmd.ExecuteScalar
        LoadGridUser(Me.TxtUserID.Text)
        If WhoIs = "OWNER" Then
            LoadGridOwner(TxtUserID.Text)
        End If
    End Sub
    Private Sub LoadGridUser(ByVal pUID As Integer)
        'Me.GridUser.DataSource = pobjSql.GetDataTable("select RecID, UserID, SiCode, Office from [42.117.5.86].amadeusvn.dbo.UserMapping where status='OK' and Userid=" & pUID)
        Me.GridUser.DataSource = GetDataTable("select RecID, UserID, SiCode, Office from UserMapping where status='OK' and Userid=" & pUID, Conn_Web)
        Me.GridUser.Columns(0).Visible = False
        Me.LblDeleteUser.Visible = False
        
    End Sub
    Private Sub txtOID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOID.LostFocus
        Me.CmbSI.DataSource = GetDataTable("select SIcode from OID_SI where Office='" & Me.txtOID.Text & "'", Conn_Web)
        Me.CmbSI.DisplayMember = "SICode"
    End Sub
    Private Sub LblUpdate_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblUpdateUser.LinkClicked
        Dim strDK As String
        If Me.TxtUserID.Text = "" Then Exit Sub
        If CInt(Me.TxtUserID.Text) = 0 Then Exit Sub
        strDK = String.Format("UserID={0} and Office='{1}' and SIcode='{2}' and status='OK'", CInt(Me.TxtUserID.Text), Me.txtOID.Text, Me.CmbSI.Text)
        Dim RecNo As Integer = ScalarToInt("UserMapping", "RecID", strDK, Conn_Web)
        If RecNo > 0 Then Exit Sub
        cmd.CommandText = "insert UserMapping (UserID, SICode, Office, Status, FstUser) values (@UserID, @SICode, @Office, @Status, @FstUser)"
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = CInt(Me.TxtUserID.Text)
        cmd.Parameters.Add("@SICode", SqlDbType.VarChar).Value = Me.CmbSI.Text
        cmd.Parameters.Add("@Office", SqlDbType.VarChar).Value = Me.txtOID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OK"
        cmd.Parameters.Add("@FstUser", SqlDbType.VarChar).Value = pobjUser.UserName
        cmd.ExecuteNonQuery()
        LoadGridUser(CInt(Me.TxtUserID.Text))
    End Sub

    Private Sub GridUser_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridUser.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        Me.LblDeleteUser.Visible = True
    End Sub

    Private Sub LblDelete_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblDeleteUser.LinkClicked
        cmd.CommandText = ChangeStatus_ByID("UserMapping", "XX", Me.GridUser.CurrentRow.Cells("RecID").Value)
        cmd.ExecuteNonQuery()
        LoadGridUser(CInt(Me.TxtUserID.Text))
    End Sub

    Private Sub CmbSI_VisibleChanged(sender As Object, e As EventArgs) Handles CmbSI.VisibleChanged
        Me.Label2.Visible = Me.CmbSI.Visible
        'Me.Label3.Visible = Me.CmbSI.Visible
        'Me.TxtUserID.Visible = Me.CmbSI.Visible
        Me.LblAddThisSICode.Visible = Me.CmbSI.Visible
        Me.LblUpdateUser.Visible = Me.CmbSI.Visible
        Me.LblDeleteUser.Visible = Me.CmbSI.Visible
        Me.GridUser.Visible = Me.CmbSI.Visible
        Me.LblUpdateOwner.Visible = Not Me.CmbSI.Visible
        Me.LblDeleteOwner.Visible = Not Me.CmbSI.Visible
        Me.GridOwner.Visible = Not Me.CmbSI.Visible
        Me.TxtAgency.Visible = Not Me.CmbSI.Visible
    End Sub

    Private Sub LblUpdateOwner_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblUpdateOwner.LinkClicked
        Dim strDK As String
        If Me.TxtUserID.Text = "" Then Exit Sub
        If CInt(Me.TxtUserID.Text) = 0 Then Exit Sub
        strDK = String.Format("UserID={0} and Office='{1}' and status='OK'", CInt(Me.TxtUserID.Text), Me.txtOID.Text)
        Dim RecNo As Integer = ScalarToInt("AllStatsReportMapping", "RecID", strDK, Conn_Web)
        If RecNo > 0 Then Exit Sub

        Dim strSqlServer As String = "" '= IIf(pobjSql.ConnectionString.Contains("172.16.2.6"), "[172.16.2.6].", "")
        Dim strCheckUserOID As String = "select Recid from " & strSqlServer & "Mktg_MIDT.dbo.data1a_oids WHERE STATUS='OK' " _
                                        & " and OffcId ='" & txtOID.Text _
                                        & "' and ShortName in" _
                                        & "(select custshortname from " & strSqlServer & "Mktg_MIDT.dbo.data1a_contacts" _
                                        & " where status='ok' and rewardsaccount='" & TxtEmail.Text & "')"
        If pobjSql.GetScalarAsString(strCheckUserOID) = "" Then
            MsgBox("Rewards User does NOT belong to this Office ID")
            Exit Sub
        End If

        cmd.CommandText = "insert AllStatsReportMapping (UserID, Office, FstUser, Agency) values (@UserID, @Office, @FstUser, @Agency)"
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = CInt(Me.TxtUserID.Text)
        cmd.Parameters.Add("@Office", SqlDbType.VarChar).Value = Me.txtOID.Text
        cmd.Parameters.Add("@Agency", SqlDbType.VarChar).Value = Me.TxtAgency.Text
        cmd.Parameters.Add("@FstUser", SqlDbType.VarChar).Value = pobjUser.UserName
        cmd.ExecuteNonQuery()
        LoadGridOwner(CInt(Me.TxtUserID.Text))
    End Sub

    Private Sub LblDeleteOwner_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblDeleteOwner.LinkClicked
        cmd.CommandText = ChangeStatus_ByID("AllStatsReportMapping", "XX", Me.GridOwner.CurrentRow.Cells("RecID").Value)
        cmd.ExecuteNonQuery()
        LoadGridOwner(CInt(Me.TxtUserID.Text))

    End Sub
    Private Sub LoadGridOwner(ByVal pUID As Integer)
        Me.GridOwner.DataSource = GetDataTable("select RecID, UserID, Agency, Office from AllStatsReportMapping where status='OK' and Userid=" & pUID, Conn_Web)
        Me.GridOwner.Columns(0).Visible = False
        Me.LblDeleteOwner.Visible = False
    End Sub

    Private Sub GridOwner_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridOwner.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        Me.LblDeleteOwner.Visible = True

    End Sub

End Class