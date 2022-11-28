Public Class frmChangePassword

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If Not CheckInputValue() Then
            Exit Sub
        End If

        If pobjSql.GetScalarAsString("Select top 1 RecId from DATA1A_User where Status<>'XX' and Username='" & pobjUser.UserName _
                                     & "' and PSW='" & Md5Encrypt(txtOldPass.Text) & "'") > 0 Then
            If pobjSql.ExecuteNonQuerry("Update DATA1A_User set PSW='" & Md5Encrypt(txtNewPass.Text) _
                                     & "' where Status<>'XX' and Username='" & pobjUser.UserName _
                                     & "' and PSW='" & Md5Encrypt(txtOldPass.Text) & "'") Then
                MsgBox("Password change completed")
                DialogResult = Windows.Forms.DialogResult.OK
                Me.Dispose()
            Else
                MsgBox("Password change NOT completed")
                Exit Sub
            End If
        Else
            MsgBox("Invalid UserName/Password")
            Exit Sub
        End If
    End Sub
    Private Function CheckInputValue() As Boolean
        If txtNewPass.Text.Length < 3 Then
            MsgBox("Invalid New Password")
            Return False
        End If
        If txtNewPass.Text <> txtConfNewPass.Text Then
            MsgBox("New Passwords are NOT identical!")
            Return False
        End If
        Return True
    End Function
End Class