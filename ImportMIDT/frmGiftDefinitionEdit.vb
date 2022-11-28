Public Class frmGiftDefinitionEdit

    Private Sub frmGiftDefinitionEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtGiftName.MaxLength = 32
        txtDescription.MaxLength = 64
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strQuerry As String

        If Not CheckInputValues() Then
            Exit Sub
        End If
        strQuerry = "Insert into Data1a_Misc (CAT,VAL,VAL1,VAL2) values ('GiftDefinition" & pobjUser.City _
            & "','" & txtGiftName.Text & "','" & txtDescription.Text & "','NO')"
        If pobjSql.ExecuteNonQuerry(strQuerry) Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        Else
            MsgBox("Unable to update GiftDefinition")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Function CheckInputValues() As Boolean
        If txtDescription.Text = "" Then
            MsgBox("Invalid Description")
            Return False
        End If
        If txtGiftName.Text = "" Then
            MsgBox("Invalid GiftName")
            Return False
        End If
        If pobjSql.GetScalarAsString("Select top 1 RecId from Data1a_Misc where Cat='GiftDefinition" & pobjUser.City _
                                     & "' and Val='" & txtGiftName.Text & "'") <> "" Then
            MsgBox("Gift Name duplication!")
            Return False
        End If
        Return True
    End Function
End Class