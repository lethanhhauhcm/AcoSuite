Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports SharedFunctions.MySharedFunctions
Public Class DoiMatKhau

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click


        Dim intUserCount As Integer = CInt(pobjSql.GetScalarAsString("select Count(*) from DATA1A_User where PSW='" _
                                                               & HashToFixedLen(txtOldPass.Text) & "'" & _
                                                               " and username='" & pobjUser.UserName & "' "))
        If intUserCount > 0 Then
            If txtNewPass.Text = txtConfNewPass.Text Then
                pobjSql.ExecuteNonQuerry("Update DATA1A_User set PSW='" & HashToFixedLen(txtNewPass.Text) & "' " & _
                                            "where username='" & pobjUser.UserName & "'")

                MsgBox("Đã đổi mật khẩu thành công")
                Me.Dispose()
            Else
                MsgBox("Xác nhận mật khẩu không chính xác")
            End If
        Else
            MsgBox("Mật khẩu hiện tại không chính xác")
        End If
    End Sub


End Class