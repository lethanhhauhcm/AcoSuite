Imports System.IO
Public Class frmGiftManager
    Dim cmd As SqlClient.SqlCommand = Conn_Web.CreateCommand
    Private Sub GiftManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub GiftManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = pubVarBackColor
        LoadGridGift()
        Me.CmbCat.DataSource = GetDataTable("select VAL from MISC where cat='GIFTCAT'", Conn_Web)
        Me.CmbCat.DisplayMember = "VAL"
    End Sub
    Private Sub LoadGridGift()
        Dim strSQL As String = "Select RecID, Ten, PointRQ, ValidThru, City, Mota, HinhAnhID, stock, Price, RMK from GiftList where status='OK' and "
        strSQL = strSQL & "City in ('ALL','" & pobjUser.City & "') and validThru>'" & Format(Now, "dd-MMM-yy") & "'"
        Me.GridGift.DataSource = GetDataTable(strSQL, Conn_Web)
        Me.GridGift.Columns(0).Visible = False
        Me.GridGift.Columns("HinhAnhID").Visible = False
        Me.GridGift.Columns(2).Width = 56
        Me.GridGift.Columns(3).Width = 75
        Me.GridGift.Columns("City").Width = 32
        Me.GridGift.Columns("Stock").Width = 32
        Me.GridGift.Columns("Price").Width = 64
        Me.GridGift.Columns("PointRQ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridGift.Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridGift.Columns("Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridGift.Columns("Price").DefaultCellStyle.Format = "#,##0"
        Me.LblDelete.Visible = False
    End Sub

    Private Sub LblDelete_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblDelete.LinkClicked
        cmd.CommandText = ChangeStatus_ByID("GiftList", "XX", Me.GridGift.CurrentRow.Cells("RecID").Value)
        cmd.ExecuteNonQuery()
        LoadGridGift()
    End Sub

    Private Sub LblUpdate_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblUpdate.LinkClicked
        Dim tmpPoint As Integer
        Try
            tmpPoint = CInt(Me.TxtStock.Text)
            tmpPoint = CInt(Me.TxtPoint.Text)
        Catch ex As Exception
            Exit Sub
        End Try
        If Me.TxtName.Text = "" Or Me.TxtMota.Text = "" Or Me.TxtValid.Value < Now Then
            MsgBox("Invalid Input", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        ElseIf Me.TxtImage.Text = "" Then
            MsgBox("You must select picture for Gift", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        End If
        cmd.CommandText = "insert HinhAnh (HinhAnh) values (@HinhAnh); SELECT SCOPE_IDENTITY() AS [RecID]"
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@HinhAnh", SqlDbType.Binary).Value = ImageToBytes(Me.TxtImage.Text)
        tmpPoint = cmd.ExecuteScalar
        cmd.CommandText = "insert GiftList (Ten, MoTa, HinhAnhID, PointRQ, ValidThru, FstUser, City, Stock, Price, RMK, Cat)" & _
            " values (@Ten, @MoTa, @HinhAnhID, @PointRQ, @ValidThru, @FstUser, @City, @Stock, @Price, @RMK, @Cat)"
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = Me.TxtName.Text
        cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = Me.TxtMota.Text
        cmd.Parameters.Add("@HinhAnhID", SqlDbType.Int).Value = tmpPoint
        cmd.Parameters.Add("@PointRQ", SqlDbType.Int).Value = CInt(Me.TxtPoint.Text)
        cmd.Parameters.Add("@ValidThru", SqlDbType.VarChar).Value = Me.TxtValid.Value.Date
        cmd.Parameters.Add("@FstUser", SqlDbType.VarChar).Value = pobjUser.UserName
        cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = IIf(Me.ChkALLACO.Checked, "ALL", pobjUser.City)
        cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = CInt(Me.TxtStock.Text)
        cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = CDec(Me.TxtPrice.Text)
        cmd.Parameters.Add("@RMK", SqlDbType.VarChar).Value = Me.TxtRMK.Text
        cmd.Parameters.Add("@Cat", SqlDbType.VarChar).Value = Me.CmbCat.Text
        cmd.ExecuteNonQuery()
        LoadGridGift()
    End Sub

    Private Sub GridGift_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridGift.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        Me.LblDelete.Visible = True
        Dim tblAnh As DataTable = GetDataTable("select HinhAnh from HinhAnh where recid=" & Me.GridGift.CurrentRow.Cells("HinhAnhID").Value, Conn_Web)
        Dim pictureBytes As New MemoryStream(CType(tblAnh.Rows(0)("HinhAnh"), Byte()))
        Me.PictBox.Image = Image.FromStream(pictureBytes)
    End Sub

    Private Sub CmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBrowse.Click
        Dim KQ As String
        Me.OpenFileDialog1.ShowDialog()
        KQ = Me.OpenFileDialog1.FileName
        Me.TxtImage.Text = KQ
    End Sub

    Private Sub TxtPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrice.LostFocus
        Dim tmpDec As Decimal
        Try
            tmpDec = CDec(Me.TxtPrice.Text)
            Me.TxtPrice.Text = Format(tmpDec, "#,##0")
        Catch ex As Exception
            Me.TxtPrice.Focus()
        End Try
    End Sub
End Class