Public Class frmSelectProduct
    Private mstrProductName As String
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        mstrProductName = cboProductName.Text
        DialogResult = DialogResult.OK
    End Sub
    Public Property ProductName As String
        Get
            Return mstrProductName
        End Get
        Set(value As String)
            mstrProductName = value
        End Set
    End Property

    Private Sub frmSelectProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboProductName.SelectedIndex = 0
    End Sub
End Class