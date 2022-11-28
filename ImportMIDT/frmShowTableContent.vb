Public Class frmShowTableContent



    Public Sub New(tblInput As DataTable, strMsg As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dgrInput.DataSource = tblInput
        Me.Text = strMsg
    End Sub
End Class