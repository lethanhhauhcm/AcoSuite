Public Class frmSelectDateRange

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dtpFrom.Value > dtpTo.Value Then
            MsgBox("From Date must on/before To Date")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class