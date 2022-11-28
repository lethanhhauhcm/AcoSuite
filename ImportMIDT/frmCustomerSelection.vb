Public Class frmCustomerSelection
    Private mlstCustomer As List(Of String)

    Public Sub New(strPIC As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mlstCustomer = New List(Of String)
        Dim strQuerry As String = "Select ShortName,AccountNameGB from DATA1A_Customers where Status='OK'" _
                                  & " and PIC='" & strPIC _
                                  & "' and ShortName in (Select distinct ShortName from Data1a_OIDS where Status='OK' and GDS='1A')" _
                                  & " order by ShortName"
        pobjSql.LoadDataGridView(dgCustomers, strQuerry)

        Dim dgcSelected As New DataGridViewCheckBoxColumn()
        dgcSelected.Name = "Selected"
        With dgCustomers
            .Columns.Add(dgcSelected)
        End With


    End Sub
    Private Sub frmCustomerSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        For Each objRow As DataGridViewRow In dgCustomers.Rows
            If objRow.Cells("Selected").Value Then
                mlstCustomer.Add(objRow.Cells("ShortName").Value)
            End If
        Next

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Property Customers As List(Of String)
        Get
            Return mlstCustomer
        End Get
        Set(value As List(Of String))
            mlstCustomer = value
        End Set
    End Property
End Class