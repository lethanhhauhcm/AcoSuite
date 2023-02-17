Public Class AdhocPoint
    Dim cmd As SqlClient.SqlCommand = Conn_Web.CreateCommand
    Private Sub AdhocPoint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub LoadGridPoint()
        Me.LblDelete.Visible = False
        If Me.GridInfor.RowCount <> 1 Then
            Me.LblAdd.Visible = False
            Exit Sub
        End If
        Me.GridPoint.DataSource = GetDataTable("select * from Point_d where UserId=" & Me.GridInfor.Item("recID", 0).Value, Conn_Web)
        Me.GridPoint.Columns(0).Visible = False
        Me.GridPoint.Columns(1).Width = 75
        Me.GridPoint.Columns(2).Width = 56
        Me.GridPoint.Columns(3).Width = 56
        Me.GridPoint.Columns(4).Width = 56
        Me.GridPoint.Columns(5).Width = 128
        Me.GridPoint.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.LblAdd.Visible = True
    End Sub
    Private Sub GridPoint_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridPoint.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If Me.GridPoint.CurrentRow.Cells("Cat").Value = "ADHOC" Then
            Me.LblDelete.Visible = True
        Else
            Me.LblDelete.Visible = False
        End If
    End Sub

    Private Sub LblDelete_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblDelete.LinkClicked
        cmd.CommandText = ChangeStatus_ByID("Point_D", "XX", Me.GridPoint.CurrentRow.Cells("RecID").Value)
        cmd.ExecuteNonQuery()
        LoadGridPoint()
    End Sub

    Private Sub LblAdd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblAdd.LinkClicked
        Dim tmpPoint As Int16
        Try
            tmpPoint = CInt(Me.TxtPoint.Text)
        Catch ex As Exception
            Exit Sub
        End Try
        If Me.txtRMK.Text = "" Or tmpPoint = 0 Then Exit Sub
        cmd.Parameters.Clear()
        'cmd.CommandText = "insert Point_D (BookDate, userID, Cat, RMK, Point, FstUser) values (@BookDate, @UserID, @Cat, @RMK, @Point, @FstUser)"  '^_^20221129 mark by 7643
        cmd.CommandText = "insert Point_D (BookDate, userID, Cat, RMK, Point, FstUser,ExpDate) values (@BookDate, @UserID, @Cat, @RMK, @Point, @FstUser,@ExpDate)"  '^_^20221129 modi by 7643
        cmd.Parameters.Add("@BookDate", SqlDbType.DateTime).Value = Me.txtBookDate.Value.Date
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Me.GridInfor.Item("RecID", 0).Value
        cmd.Parameters.Add("@Point", SqlDbType.Int).Value = tmpPoint
        cmd.Parameters.Add("@Cat", SqlDbType.VarChar).Value = Me.CmbCat.Text
        cmd.Parameters.Add("@RMK", SqlDbType.VarChar).Value = Me.txtRMK.Text
        cmd.Parameters.Add("@FstUser", SqlDbType.VarChar).Value = pobjUser.UserName
        cmd.Parameters.Add("@ExpDate", SqlDbType.Date).Value = IIf(cmd.Parameters("@Point").Value > 0, DateAdd("yyyy", 2, cmd.Parameters("@BookDate").Value), DBNull.Value)  '^_^20221129 add by 7643
        cmd.ExecuteNonQuery()
        LoadGridPoint()
    End Sub
    Private Sub LblSeacrch_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblSeacrch.LinkClicked
        Dim strSQL As String
        strSQL = "select RecID, SIName, Mobile, Birthday, '' as Office, '' as SIcode from tbluser where upper(email)='" & _
            Me.TxtEmail.Text.ToUpper & "' and city in ('ALL','" & pobjUser.City & "')"
        Me.GridInfor.DataSource = GetDataTable(strSQL, Conn_Web)
        If Me.GridInfor.RowCount = 0 Then Exit Sub
        Me.GridInfor.Columns(0).Visible = False
        Me.GridInfor.Columns(1).Width = 128
        Me.GridInfor.Columns(2).Width = 80
        Me.GridInfor.Columns(3).Width = 75
        Me.GridInfor.Columns(5).Width = 64

        Me.LblAdd.Enabled = True
        Me.GridInfor.Item("Office", 0).Value = ScalarToString("UserMapping", "Office", "Userid=" & Me.GridInfor.Item("RecID", 0).Value, Conn_Web)
        Me.GridInfor.Item("SICode", 0).Value = ScalarToString("UserMapping", "SICode", "Userid=" & Me.GridInfor.Item("RecID", 0).Value, Conn_Web)
        Me.LblChangeStar.Enabled = Me.LblAdd.Enabled
        LoadGridPoint()
    End Sub
    Private Sub GridInfor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridInfor.CellContentClick
        If e.RowIndex = 0 Then Me.LblAdd.Visible = True
    End Sub

    Private Sub LblChangeStar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblChangeStar.LinkClicked
        cmd.CommandText = "update tblUser set CurrentStar=" & Me.CmbStar.Text & " where Recid=" & Me.GridInfor.Item("RecID", 0).Value
        cmd.ExecuteNonQuery()
        Me.LblChangeStar.Enabled = False
    End Sub

    Private Sub AdhocPoint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = pubVarBackColor
        Me.CmbCat.DataSource = GetDataTable("Select VAL from MISC where cat='ADHPOINT'", Conn_Web)
        Me.CmbCat.DisplayMember = "VAL"
    End Sub
End Class