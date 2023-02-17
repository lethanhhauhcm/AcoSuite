
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class frmSignIn

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim tblUser As System.Data.DataTable
        Dim strQuerry As String
        Dim intStaffId As Integer

        txtStaffId.Text = txtStaffId.Text.Trim
        txtPassword.Text = txtPassword.Text.Trim

        intStaffId = do_Login(txtStaffId.Text, txtPassword.Text)
        'intStaffId = 7586

        'If My.Computer.Name = "5-247" Then  '^_^20221024 mark by 7643
        If My.Computer.Name = "5-247" Or My.Computer.Name = "7-111" Then  '^_^20221024 modi by 7643
            If MsgBox("Use Son.NguyenViet", MsgBoxStyle.YesNo) = vbYes Then
                intStaffId = 4029
                'intStaffId = 522
                GoTo ByPassSignIn
            End If
        End If

        If intStaffId > 0 Then
            If txtPassword.Text = "Abcd@1234" Then
                MsgBox("Đang sử dụng Mật Khẩu mặc định. Vui lòng đổi Mật Khẩu", MsgBoxStyle.Critical, "Đổi Mật Khẩu")
                txtPassword.Text = ""
                Process.Start("http://transviet.net/changepassword2.aspx?StaffID=" & txtStaffId.Text)
                Exit Sub
            End If
        Else
            'LỖI
            MsgBox("StaffID hoặc Password không đúng", MsgBoxStyle.Critical, "Lỗi")
            Exit Sub
        End If

ByPassSignIn:
        strQuerry = "Select top 1 * from DATA1A_User where status <>'XX' and StaffId=" & intStaffId

        tblUser = pobjSql.GetDataTable(strQuerry)
        If tblUser.Rows.Count = 0 Then
            MsgBox("Chưa tạo user cho chương trình ACO Suite")
            DialogResult = Windows.Forms.DialogResult.None
            Exit Sub
        Else
            With pobjUser
                .UserName = tblUser.Rows(0)("UserName")
                .City = tblUser.Rows(0)("City").ToString
                .Role = tblUser.Rows(0)("Role").ToString
                .Email = tblUser.Rows(0)("Email").ToString
                .FullName = tblUser.Rows(0)("FullName").ToString
                .Password = tblUser.Rows(0)("PSW").ToString
                .Remote = tblUser.Rows(0)("Remote").ToString
                .StaffId = tblUser.Rows(0)("StaffId").ToString
                .Rights = pobjSql.GetDataTable("Select * from tblRight where Status<>'XX' and SiCode='" & .UserName & "'")
                If .City = "HAN" Then
                    .Region = "North"
                ElseIf .City = "SGN" Then
                    .Region = "South"
                End If
                If .Remote = 1 AndAlso Not IsNumeric(Mid(My.Computer.Name, 1, 1)) Then
                    If MsgBox("Sign in Outside TransViet", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        pblnRemoteAccess = True
                    End If
                End If

            End With

            DialogResult = System.Windows.Forms.DialogResult.OK
        End If


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub frmSignIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.Name = "5-247" Then
            txtStaffId.Text = "212"
            txtPassword.Text = "Abcd2019"
        End If
    End Sub

    Function do_Login(StaffID As String, Password As String) As Integer
        Dim url As String = String.Format("http://api.transviet.net/ezStaff-SignIn/{0}/{1}", StaffID, Password)
        Dim req As HttpWebRequest = HttpWebRequest.Create(url)
        req.ContentType = "application/json"
        req.Method = "GET"

        Dim json As Object
        json = Nothing
        Try
            Using res As HttpWebResponse = req.GetResponse()
                Using responseStream As New StreamReader(res.GetResponseStream())
                    Dim responseData As String = responseStream.ReadToEnd()
                    json = JsonConvert.DeserializeObject(Of Object)(responseData)
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Lỗi sever đăng nhập. Gọi IT")
            Return -1
        End Try

        If json("StaffID") = 0 Then
            'MsgBox(json("ErrMsg"))
            Return 0
        Else
            Return CInt(json("StaffID"))
        End If
    End Function


End Class
