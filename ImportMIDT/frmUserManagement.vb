Public Class frmUserManagement

#Region "Ham va phuong thuc"
    Private Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strMsQuerry As String

        strMsQuerry = "Select * from DATA1A_User" _
                       & " where Status<>'XX' and City='" & pobjUser.City & "' order by UserName"

        daConditions = New SqlClient.SqlDataAdapter(strMsQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_User")
        DataGridView1.DataSource = dsConditions.Tables("DATA1A_User")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Refresh()
        dsConditions.Dispose()
        daConditions.Dispose()
        Return True
    End Function

#End Region

#Region "Su kien"
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmUserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmUser As New frmUserEdit
        frmUser.ShowDialog()
        Search()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim frmUser As New frmUserEdit(DataGridView1.CurrentRow)
        frmUser.ShowDialog()
        Search()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strQuerry As String
        strQuerry = "update DATA1A_User set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
            & "' where Recid='" & DataGridView1.CurrentRow.Cells("RecId").Value & "'"
        pobjSql.DeleteGridViewRow(DataGridView1, strQuerry)
        Search()
    End Sub
#End Region

    'Private Sub btnResetPass_Click(sender As Object, e As EventArgs) 
    '    Dim strQuerry As String
    '    strQuerry = "update DATA1A_User set Psw='" & Md5Encrypt("Amadeus1") & "', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
    '        & "' where Recid='" & DataGridView1.CurrentRow.Cells("RecId").Value & "'"
    '    If pobjSql.ExecuteNonQuerry(strQuerry) Then
    '        MsgBox("Password reset is successfull")
    '        Search()
    '    Else
    '        MsgBox("Password reset is NOT unsuccessfull")
    '    End If
    'End Sub

    Private Sub btnRights_Click(sender As Object, e As EventArgs) Handles btnRights.Click
        Dim frmUserRights As New frmUserRights(DataGridView1.CurrentRow.Cells("UserName").Value)
        frmUserRights.ShowDialog()
    End Sub
End Class