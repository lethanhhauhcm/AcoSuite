Public Class frmBypassSecoCheck
    Private Sub frmBypassSecoCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Private Sub lbkAdd_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        If txtUserId.TextLength < 3 Then
            MsgBox("Invalid user id!")
            Exit Sub
        End If
        Dim strQuerry As String = "insert into DATA1A_MISC (CAT, VAL, VAL1,VAL2) values ('BypassSecoCheck','" _
            & txtUserId.Text & "','" & pobjUser.UserName & "','OK')"
        If pobjSql.ExecuteNonQuerry(strQuerry) Then
            Search()
        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        Dim strQuerry As String = "update DATA1A_MISC Set VAL2='XX',Val1='" & pobjUser.UserName _
            & "',FstUpdate=getdate() where RecId = " & dgrBypassSecoCheck.CurrentRow.Cells("RecId").Value
        If pobjSql.DeleteGridViewRow(dgrBypassSecoCheck, strQuerry) Then
            Search()
        End If
        Search()
    End Sub
    Private Function Search() As Boolean
        pobjSql.LoadDataGridView(dgrBypassSecoCheck, "select RecId,Val as UserId,Val1 as UpdateUser,Val2 as Status" _
                                 & ",FstUpdate from Data1a_Misc where cat='BypassSecoCheck' order by Val")
        Return True
    End Function
End Class