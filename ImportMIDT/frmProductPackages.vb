Public Class frmProductPackages


#Region "Ham va phuong thuc"
    Public Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strMsQuerry As String

        strMsQuerry = "Select * from DATA1A_ProductPackages" _
                       & " where Status<>'XX' and ProductName='" & cboPackages.Text _
                       & "' order by SubProductName"

        daConditions = New SqlClient.SqlDataAdapter(strMsQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_ProductPackages")
        DataGridView1.DataSource = dsConditions.Tables("DATA1A_ProductPackages")
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
        pobjSql.LoadCombo(cboPackages, "Select ProductName as Value from DATA1A_Products where status<>'xx'" _
                          & " and ProductType='Bundled' order by ProductName")
        Search()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmProduct As New frmProductPackageEdit(cboPackages.Text)
        frmProduct.ShowDialog()
        Search()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim frmUser As New frmProductPackageEdit(cboPackages.Text, DataGridView1.CurrentRow)
        frmUser.ShowDialog()
        Search()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strQuerry As String
        strQuerry = "update DATA1A_ProductPackages set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
            & "' where Recid='" & DataGridView1.CurrentRow.Cells("RecId").Value & "'"
        pobjSql.DeleteGridViewRow(DataGridView1, strQuerry)
        Search()
    End Sub
#End Region

    Private Sub cboPackages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPackages.SelectedIndexChanged
        Search()
    End Sub

    Private Sub cboPackages_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPackages.SelectionChangeCommitted

    End Sub

End Class