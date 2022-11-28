Public Class frmGiftDefinition

    Private Sub frmGiftDefinition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Public Function Search() As Boolean
        Dim strQuerry As String = "Select RecId, Val as GiftName, Val1 as Description, Val2 as Expired " _
                                  & " from Data1a_Misc where Cat='GiftDefinition" & pobjUser.City _
                                  & "' order by GiftName,Description"
        pobjSql.LoadDataGridView(dgGift, strQuerry)

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub dgGift_SelectionChanged(sender As Object, e As EventArgs) Handles dgGift.SelectionChanged
        If dgGift.RowCount = 0 Then
            btnExpire.Enabled = False
            btnDelete.Enabled = False
        Else
            btnExpire.Enabled = True
            btnDelete.Enabled = True
            With dgGift.CurrentRow
                If IsDBNull(.Cells("Expired").Value) Then
                    btnExpire.Text = "Expire"
                ElseIf .Cells("Expired").Value = "YES" Then

                    btnExpire.Text = "Unexpire"
                Else
                    btnExpire.Text = "Expire"
                End If
            End With
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If frmGiftDefinitionEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If dgGift.RowCount = 0 Then
            Exit Sub
        ElseIf pobjSql.GetScalarAsString("Select top 1 GiftId from Data1a_GiftInOut where GiftId=" _
                                     & dgGift.CurrentRow.Cells("RecId").Value) <> "" Then
            MsgBox("Unable to delete! GiftName is being used!")
            Exit Sub
        ElseIf pobjSql.ExecuteNonQuerry("Delete Data1a_Misc where Recid=" & dgGift.CurrentRow.Cells("RecId").Value) Then
            Search()
        Else
            MsgBox("Unable to delete!")
        End If
    End Sub

    Private Sub btnExpire_Click(sender As Object, e As EventArgs) Handles btnExpire.Click
        If dgGift.RowCount > 0 Then
            With dgGift.CurrentRow
                Dim strExpired As String = IIf(btnExpire.Text = "Expire", "YES", "NO")
                Dim strQuerry As String = "Update Data1a_Misc set Val2='" & strExpired & "' where RecId=" & .Cells("RecId").Value
                If pobjSql.ExecuteNonQuerry(strQuerry) Then
                    Search()
                Else
                    MsgBox("Unable to update Gift Definition")
                End If
            End With
        End If

    End Sub
End Class