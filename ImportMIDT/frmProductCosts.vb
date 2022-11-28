Public Class frmProductCosts
    Private mstrCostPrice As String

#Region "Ham va phuong thuc"
    Public Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strMsQuerry As String

        strMsQuerry = "Select * from DATA1A_ProductCosts" _
                       & " where Status<>'XX' and Region='" & pobjUser.Region _
                       & "' and CostPrice='" & mstrCostPrice & "' order by ProductName"

        daConditions = New SqlClient.SqlDataAdapter(strMsQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_ProductCosts")
        DataGridView1.DataSource = dsConditions.Tables("DATA1A_ProductCosts")
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

    Private Sub frmProductCosts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmProduct As New frmProductCostEdit(mstrCostPrice)
        frmProduct.ShowDialog()
        Search()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim frmUser As New frmProductCostEdit(mstrCostPrice, DataGridView1.CurrentRow)
        frmUser.ShowDialog()
        Search()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strQuerry As String
        strQuerry = "update DATA1A_ProductCosts set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
            & "' where Recid='" & DataGridView1.CurrentRow.Cells("RecId").Value & "'"
        pobjSql.DeleteGridViewRow(DataGridView1, strQuerry)
        Search()
    End Sub
#End Region


    Public Sub New(strCostPrice As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrCostPrice = strCostPrice
    End Sub
End Class