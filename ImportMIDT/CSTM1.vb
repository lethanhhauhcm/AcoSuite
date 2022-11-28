Public Class CSTM1
    Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
    Private TimeFrame As String = "Month"
    Private Sub CSTM1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If InStr(MyRole, "CMCLOFFR") > 0 Then
            Me.LblUpdate.Enabled = True
            Me.LblDelete.Enabled = True
        End If
        If InStr(MyRole, "SUPERVSR") > 0 Then Me.LblApprove.Enabled = True
        LoadGridCSTM()
    End Sub
    Private Sub LoadGridCSTM()
        Dim dAdapter As SqlClient.SqlDataAdapter
        Dim dSet As New Data.DataSet
        Dim StrSQL As String
        StrSQL = "select * from CSTM1 where "
        Me.LblExtend.Visible = False
        If Me.OptQQ.Checked Then StrSQL = StrSQL & " status='QQ' "
        If Me.OptXX.Checked Then StrSQL = StrSQL & " status='XX' "
        If Me.OptExp.Checked Then StrSQL = StrSQL & " status='OK' and validThru <getdate()"
        If Me.OptCurrent.Checked Then StrSQL = StrSQL & " status='OK' and validThru >getdate()"
        dAdapter = New SqlClient.SqlDataAdapter(StrSQL, pobjSql.Connection)
        Me.GridCSTM.Columns.Clear()
        dAdapter.Fill(dSet, "TamB")
        Me.GridCSTM.DataSource = dSet.Tables("tamB")
        Me.GridCSTM.Columns(0).Visible = False
        Me.LblDelete.Visible = False
        Me.LblApprove.Visible = False
        Me.GridCSTM.Columns("CommOffer").Width = 64
        Me.GridCSTM.Columns("Target").Width = 56
        Me.GridCSTM.Columns("TimeFrame").Width = 56
        Me.GridCSTM.Columns("Status").Width = 36
        Me.GridCSTM.Columns("ValidFrom").Width = 64
        Me.GridCSTM.Columns("MinToRQAdh").Width = 75
        Me.GridCSTM.Columns("FstUser").Width = 50
        Me.GridCSTM.Columns("LstUser").Width = 50
        Me.GridCSTM.Columns("VND").Width = 75
        Me.GridCSTM.Columns("Target").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridCSTM.Columns("VND").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridCSTM.Columns("VND").DefaultCellStyle.Format = "#,###"
        Me.GridCSTM.Columns("Target").DefaultCellStyle.Format = "#,###"
        Me.GridCSTM.Columns("MinToRQAdh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridCSTM.Columns("MinToRQAdh").DefaultCellStyle.Format = "#,###"


    End Sub
    Private Function TrungTen(ByVal pTu As String, ByVal pDen As String, ByVal pOfferName As String) As Boolean
        Dim ExistID As Integer
        cmd.CommandText = "select recid from cstm1 where status <>'XX' and commoffer='" & pOfferName & "' and (('" & pTu & "' between validfrom and validthru) or ('" & _
            pDen & "' between validfrom and validthru))"
        ExistID = cmd.ExecuteScalar
        If ExistID > 0 Then
            MsgBox("Duplicate or OverLap Input", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Amadeus Vietnam")
            Return True
        End If
        cmd.CommandText = "select recid from cstm1 where status <>'XX' and commoffer='" & pOfferName & "' and '" & pTu & "'< validfrom and '" & _
            pDen & "' > validthru"
        ExistID = cmd.ExecuteScalar
        If ExistID > 0 Then
            MsgBox("Duplicate or OverLap Input", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Amadeus Vietnam")
            Return True
        End If
        Return False
    End Function
    Private Function IllogicInput() As Boolean

        If Me.OptMonth.Checked Then
            If CDec(Me.TxtVND.Text) > 36000 Or CInt(Me.TxtTarger.Text) > 1600 Then Return True
        Else
            If CDec(Me.TxtVND.Text) < 1000000 Or CInt(Me.TxtTarger.Text) < 1600 Then Return True
        End If
        Return False
    End Function
    Private Sub LblUpdate_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblUpdate.LinkClicked
        Dim tu As String = Format(Me.TxtFrom.Value, "dd-MMM-yy")
        Dim den As String = Format(Me.TxtThru.Value, "dd-MMM-yy") & " 23:59"
        Dim OfferName As String = TimeFrame.Substring(0, 1) & Me.CmbName.Text
        If TrungTen(tu, den, OfferName) Then Exit Sub
        'If IllogicInput() Then Exit Sub
        cmd.CommandText = "insert CSTM1 (TimeFrame, CommOffer, Target, VND, MinToRQAdh, ValidFrom, ValidThru, " & _
            "FstUser) values ('" & TimeFrame & "','" & OfferName & "'," & CDec(Me.TxtTarger.Text) & "," & CDec(Me.TxtVND.Text) & _
            "," & CDec(Me.TxtMinAdh.Text) & ",'" & tu & "','" & den & "','" & SICode & "')"
        cmd.ExecuteNonQuery()
        LoadGridCSTM()
    End Sub

    Private Sub GridCSTM_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridCSTM.CellContentClick
        Me.LblApprove.Visible = False
        Me.LblDelete.Visible = False
        If Me.OptExp.Checked Then Me.LblExtend.Visible = True
        If Me.GridCSTM.CurrentRow.Cells("Status").Value = "QQ" Then Me.LblApprove.Visible = True
        If InStr("OK_QQ", Me.GridCSTM.CurrentRow.Cells("Status").Value) > 0 Then Me.LblDelete.Visible = True
    End Sub

    Private Sub LblApprove_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblApprove.LinkClicked
        cmd.CommandText = "update cstm1 set status='OK', ApprovedBy='" & SICode & "@" & Now & "' where recid=" & _
            Me.GridCSTM.CurrentRow.Cells("recID").Value
        cmd.ExecuteNonQuery()
        LoadGridCSTM()
    End Sub

    Private Sub LblDelete_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblDelete.LinkClicked
        If Me.GridCSTM.CurrentRow.Cells("Status").Value = "QQ" Then
            cmd.CommandText = "delete from cstm1 where recid=" & Me.GridCSTM.CurrentRow.Cells("recID").Value
        Else
            cmd.CommandText = "update cstm1 set status='XX', LstUser='" & SICode & "', LstUpdate=getdate() where recid=" & _
                Me.GridCSTM.CurrentRow.Cells("recID").Value
        End If
        cmd.ExecuteNonQuery()
        LoadGridCSTM()
    End Sub
    Private Sub TxtMTarger_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        TxtTarger.LostFocus, TxtVND.LostFocus, TxtMinAdh.LostFocus
        Dim txt As TextBox = CType(sender, TextBox)
        Dim aa As Decimal
        Try
            aa = CDec(txt.Text)
            txt.Text = Format(aa, "#,##0")
        Catch ex As Exception
            txt.Focus()
        End Try
    End Sub

    Private Sub OptQQ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptQQ.Click, OptCurrent.Click, OptXX.Click, OptExp.Click
        LoadGridCSTM()
    End Sub

    Private Sub OptMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        OptMonth.CheckedChanged, OptQuarter.CheckedChanged, OptHalfYear.CheckedChanged, OptYear.CheckedChanged
        If Me.OptMonth.Checked Then
            Me.LblVND.Text = "VND/Bkg"
        Else
            Me.LblVND.Text = "VND"
        End If
    End Sub

    Private Sub OptHalfYear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        OptMonth.Click, OptQuarter.Click, OptHalfYear.Click, OptYear.Click
        Dim opt As RadioButton = CType(sender, RadioButton)
        TimeFrame = opt.Text
    End Sub
    Private Sub LblExtend_VisibleChanged(sender As Object, e As EventArgs) Handles LblExtend.VisibleChanged
        Me.TxtNewValid.Visible = Me.LblExtend.Visible
        Me.Label4.Visible = Me.LblExtend.Visible
    End Sub
    Private Sub LblExtend_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblExtend.LinkClicked
        If Me.TxtNewValid.Value <= Me.GridCSTM.CurrentRow.Cells("validThru").Value Then Exit Sub
        Dim den As String = Format(Me.TxtNewValid.Value, "dd-MMM-yy") & " 23:59"
        cmd.CommandText = "insert Cstm1 (CommOffer, TimeFrame, Target, VND, MinToRQAdh, ValidFrom, ValidThru, FstUser, " & _
            "FstUpdate, LstUpdate, ApprovedBy, Status, LstUser) select CommOffer, TimeFrame, Target, VND, MinToRQAdh, " & _
            "ValidFrom, FstUpdate, LstUpdate, ApprovedBy, 'XX', '" & SICode & "' from CSTM where recid=" & _
            Me.GridCSTM.CurrentRow.Cells("recID").Value
        cmd.CommandText = cmd.CommandText & "; update cstm1 set status='QQ', validthru='" & den & "',FstUser='" & SICode & _
            "', Fstupdate=getdate() where recid=" & Me.GridCSTM.CurrentRow.Cells("recID").Value
        cmd.ExecuteNonQuery()
        LoadGridCSTM()
    End Sub
End Class