Public Class frmSelectCustomer
    Private mobjCustomer As clsCustomer

    Private Sub frmSelectCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(strFilterQuerry As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pobjSql.LoadDataGridView(dgCustomer, strFilterQuerry)
        mobjCustomer = New clsCustomer
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dgCustomer.RowCount > 0 Then
            With dgCustomer.CurrentRow
                mobjCustomer.Recid = .Cells("RecId").Value
                mobjCustomer.ShortName = .Cells("ShortName").Value
                mobjCustomer.FullNameGB = .Cells("AccountNameGB").Value
                mobjCustomer.FullNameVN = .Cells("AccountNameVN").Value
                mobjCustomer.Region = .Cells("Region").Value
                mobjCustomer.PIC = .Cells("PIC").Value
            End With
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        End If
        
    End Sub
    Public Property Customer As clsCustomer
        Get
            Return mobjCustomer
        End Get
        Set(value As clsCustomer)
            mobjCustomer = value
        End Set
    End Property
End Class