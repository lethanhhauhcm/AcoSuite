Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports SharedFunctions.MySharedFunctions
Public Class DangNhap
    Private dts As DataSet
    Private cn As String = "Data Source=172.16.2.6;Initial Catalog=Mktg_MIDT;User ID=midtusers; password=sresutdim"
    Private con As SqlConnection

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'con = New SqlConnection(cn)
        'con.Open()
        'dts = New DataSet()
        'Dim cmd As SqlCommand = con.CreateCommand
        'cmd.CommandText = "Select SICode,PSW,Admin from tblUser where SICode='" & txtSICode.Text & "' and Status='OK'"
        'Dim adapter As New SqlDataAdapter(cmd)
        'adapter.Fill(dts, "User")
        'Dim dtu As New DataTable
        'dtu = dts.Tables("User")

        'If dtu.Rows.Count = 1 Then
        '    If HashToFixedLen(txtPSW.Text) = dtu.Rows(0)("PSW") Then
        '        Management.BarSaleLog.Enabled = True
        '        Management.BarChangePassword.Enabled = True
        '        SignIn = UCase(txtSICode.Text)
        '        Permission = dtu.Rows(0)("Admin")
        '        If Permission = 1 Then
        '            Management.BarCreateUser.Enabled = True
        '        Else
        '            Management.BarCreateUser.Enabled = False
        '        End If
        '        Me.Close()
        '    Else
        '        Management.BarChangePassword.Enabled = False
        '        MsgBox("Sai SICode hoặc mật mã!")
        '    End If
        'Else
        '    Management.BarChangePassword.Enabled = False
        '    MsgBox("Sai SICode hoặc mật mã!")
        'End If
        'con.Close()
    End Sub
End Class
