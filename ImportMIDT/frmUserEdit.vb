Public Class frmUserEdit
    Private mstrPassword As String

    Private Sub frmUserEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(Optional dgrUser As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If dgrUser Is Nothing Then
            txtUserName.ReadOnly = False
            txtStaffId.ReadOnly = False
            txtCity.Text = pobjUser.City
            '            mstrPassword = Md5Encrypt(pstrDefaultPassword)
        Else
            txtRecId.Text = dgrUser.Cells("Recid").Value
            txtUserName.Text = dgrUser.Cells("UserName").Value
            txtStaffId.Text = dgrUser.Cells("StaffId").Value
            txtFullName.Text = dgrUser.Cells("FullName").Value
            txtEmail.Text = dgrUser.Cells("Email").Value
            txtCity.Text = dgrUser.Cells("City").Value
            cboRole.Text = dgrUser.Cells("Role").Value
            txtUserName.ReadOnly = True
            txtStaffId.ReadOnly = True
            'mstrPassword = dgrUser.Cells("PSW").Value
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerries As New List(Of String)
        'Dim strPassword As String

        If Not CheckInputValue() Then
            Exit Sub
        End If

        lstQuerries.Add("Insert into DATA1A_User (UserName,City,FullName,Role,Email,StaffId,FstUser,LstUser) values ('" _
                        & txtUserName.Text & "','" & txtCity.Text & "','" & txtFullName.Text & "','" & cboRole.Text _
                        & "','" & txtEmail.Text & "'," & txtStaffId.Text _
                        & ",'" & pobjUser.UserName & "','" & pobjUser.UserName & "')")
        If txtRecId.Text <> "" Then
            lstQuerries.Add("update DATA1A_User set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                & "' where Recid=" & txtRecId.Text)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Me.Dispose()
        Else
            MsgBox(pobjSql.UpdtErr)
        End If

    End Sub
    Private Function CheckInputValue() As Boolean

        If txtUserName.Text.Length < 3 Or UCase(txtUserName.Text) = "TEMPLATE" Then 'Tranh trung voi Template cho UserRight
            MsgBox("Invalid UserName")
            Return False
        End If
        If Not IsNumeric(txtStaffId.Text) Then
            MsgBox("Invalid StaffId")
            Return False
        End If
        If txtRecId.Text = "" Then
            If pobjSql.GetScalarAsString("Select top 1 RecId from DATA1A_User where status<>'XX'" _
                                                                & " and UserName='" & txtUserName.Text & "'") <> "" Then
                MsgBox("Duplicate UserName")
                Return False
            ElseIf pobjSql.GetScalarAsString("Select top 1 RecId from [LIB].[dbo].[DSNV] where status<>'XX'" _
                                                            & " and RecId" & txtStaffId.Text) <> "" Then
                MsgBox("Duplicate Staff Id")
                Return False
            End If
            '^_^20220811 mark by 7643 -b-
            'ElseIf pobjSql.GetScalarAsString("Select top 1 RecId from [LIB].[dbo].[DSNV] where status<>'XX'" _
            '                                                    & " and RecId" & txtStaffId.Text) = "" Then
            '^_^20220811 mark by 7643 -e-
            '^_^20220811 modi by 7643 -b-
        ElseIf pobjSql.GetScalarAsString("Select top 1 RecId from DATA1A_User where status<>'XX'" _
                                                            & " and StaffId=" & txtStaffId.Text) = "" Then
            '^_^20220811 modi by 7643 -e-
            MsgBox("Staff Id does NOT exist!")
            Return False

        End If


        If txtFullName.Text.Length < 8 Then
            MsgBox("Invalid FullName")
            Return False
        End If
        If txtEmail.Text.Split("@").Length <> 2 Then
            MsgBox("Invalid Email")
            Return False
        End If
        Return True
    End Function
End Class