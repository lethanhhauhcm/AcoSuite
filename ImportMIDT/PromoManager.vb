Public Class PromoManager
    Private cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
    Private Sub PromoManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = pubVarBackColor
        LoadGridCurrentPromo()
        LoadGridMember()
        LoadGridAL()
    End Sub
    Private Sub LoadGridCurrentPromo()
        Me.GridCurrentPromo.DataSource = GetDataTable("select recID, Frm, Thru, ALL_AL, ALL_member, HeSo, Status, Campaign from Promo where status='OK'", pobjSql.Connection)
        Me.GridCurrentPromo.Columns(0).Visible = False
        Me.GridCurrentPromo.Columns(5).Width = 32
        Me.GridCurrentPromo.Columns(6).Width = 32
        For i As Int16 = 1 To 4
            Me.GridCurrentPromo.Columns(i).Width = 64
        Next
        Me.LblDelete.Visible = False
        Me.GridPromoD.Visible = False
    End Sub
    Private Sub LoadGridMember()
        Dim dTable As DataTable = GetDataTable("select recid, Email+ ' (' + SIname  +')' as Member from tbluser where status='OK' order by email", Conn_Web)
        Me.LstMember.DataSource = dTable
        Me.LstMember.DisplayMember = "Member"
        Me.LstMember.ValueMember = "RecID"
    End Sub
    Private Sub LoadGridAL()
        Dim dTable As DataTable = GetDataTable("select ALCode from lib.dbo.AirlineList where docCode<>'000'", Conn_Web)
        Me.LstAL.DataSource = dTable
        Me.LstAL.DisplayMember = "ALCode"
        Me.LstAL.ValueMember = "ALCode"
    End Sub
    Private Sub ChkAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAL.CheckedChanged
        Me.LstAL.Visible = Not Me.ChkAL.Checked
    End Sub

    Private Sub ChkMember_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMember.CheckedChanged
        Me.LstMember.Visible = Not Me.ChkMember.Checked
    End Sub
    Private Sub lblUpdate_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblUpdate.LinkClicked
        Dim PromoId As Integer

        If Me.txtThru.Value < Me.txtFrom.Value Or Me.txtCampaign.Text = "" Then Exit Sub
        If txtFrom.Value.Date < Now.Date Then
            MsgBox("Must valid from today!")
            Exit Sub
        End If
        Try
            PromoId = CInt(Me.txtCoef.Text)
        Catch ex As Exception
            Exit Sub
        End Try
        cmd.CommandText = "insert Promo (Frm, Thru, ALL_AL, ALL_Member, FstUser, HeSo, Campaign)" & _
            " values (@Frm, @Thru, @ALL_AL, @ALL_Member, @FstUser, @HeSo, @Campaign)" & _
            "; SELECT SCOPE_IDENTITY() AS [RecID]"
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@Frm", SqlDbType.DateTime).Value = Me.txtFrom.Value.Date
        cmd.Parameters.Add("@Thru", SqlDbType.DateTime).Value = Me.txtThru.Value.Date
        cmd.Parameters.Add("@ALL_AL", SqlDbType.Bit).Value = Me.ChkAL.Checked
        cmd.Parameters.Add("@ALL_Member", SqlDbType.Bit).Value = Me.ChkMember.Checked
        cmd.Parameters.Add("@FstUser", SqlDbType.VarChar).Value = pobjUser.UserName
        cmd.Parameters.Add("@HeSo", SqlDbType.Decimal).Value = CDec(Me.txtCoef.Text)
        cmd.Parameters.Add("@Campaign", SqlDbType.VarChar).Value = Me.txtCampaign.Text
        PromoId = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@VAL", SqlDbType.VarChar)
        cmd.Parameters.Add("@PromoID", SqlDbType.Int).Value = PromoId
        If Not Me.ChkAL.Checked Then
            For Each dRowViewi As DataRowView In Me.LstAL.CheckedItems
                cmd.CommandText = "insert Promo_D (PromoID, CAT, VAL) values (@promoID,'AL',@VAL)"
                cmd.Parameters("@VAL").Value = dRowViewi("ALCode")
                cmd.ExecuteNonQuery()
            Next
        End If
        If Not Me.ChkMember.Checked Then
            For Each dRowView As DataRowView In Me.LstMember.CheckedItems
                cmd.CommandText = "insert Promo_D (PromoID, CAT, VAL) values (@promoID,'MEMBER',@VAL)"
                cmd.Parameters("@VAL").Value = dRowView("recID")
                cmd.ExecuteNonQuery()
            Next
        End If
        LoadGridCurrentPromo()
        Me.TabControl1.SelectTab("TabPage2")
    End Sub

    Private Sub LblDelete_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblDelete.LinkClicked
        cmd.CommandText = ChangeStatus_ByID("Promo", "XX", Me.GridCurrentPromo.CurrentRow.Cells("recID").Value)
        cmd.ExecuteNonQuery()
        LoadGridCurrentPromo()
    End Sub

    Private Sub GridCurrentPromo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridCurrentPromo.CellContentClick
        Me.LblDelete.Visible = True
        If Me.GridCurrentPromo.CurrentRow.Cells("ALL_AL").Value = 0 Or Me.GridCurrentPromo.CurrentRow.Cells("ALL_Member").Value = 0 Then
            Me.GridPromoD.DataSource = GetDataTable("Select Cat, VAL from Promo_D where PromoID=" & Me.GridCurrentPromo.CurrentRow.Cells("recID").Value, pobjSql.Connection)
            Me.GridPromoD.Visible = True
        Else
            Me.GridPromoD.Visible = False
        End If
    End Sub
End Class