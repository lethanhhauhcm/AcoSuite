Public Class frmRewardsUserEdit
    Public Sub New(drUser As DataGridViewRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        With drUser
            txtRecId.Text = drUser.Cells("RecId").Value
            txtSiName.Text = drUser.Cells("SiName").Value
            txtMobile.Text = drUser.Cells("Mobile").Value
            txtEmail.Text = drUser.Cells("Email").Value
            txtBirthDay.Text = drUser.Cells("BirthDay").Value
            txtOffcId.Text = drUser.Cells("Office").Value
            txtSiCode.Text = drUser.Cells("SiCode").Value
        End With
    End Sub
    Private Function CheckInputValues() As Boolean
        If txtOffcId.TextLength <> 9 Or Not pobjSql.CitiesExist(Mid(txtOffcId.Text, 1, 3)) Then
            MsgBox("Invalid OffcID")
            Return False
        End If
        If txtSiCode.TextLength <> 6 Or Not IsNumeric(Mid(txtSiCode.Text, 1, 4)) Then
            MsgBox("Invalid SiCode")
            Return False
        End If
        Return True
    End Function
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strQuerry As String = "Update amadeusvn.dbo.UserMapping set SiCode='" & txtSiCode.Text _
                                  & "', Office='" & txtOffcId.Text _
                                  & "',LstUser='" & pobjUser.UserName & "',LstUpdate=getdate()" _
                                  & " where UserId=" & txtRecId.Text
        If pobjSql.ExecuteNonQuerry(strQuerry) Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If

    End Sub

    
End Class