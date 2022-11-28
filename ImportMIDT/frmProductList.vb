Public Class frmProductList
#Region "Ham va phuong thuc"
    Public Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strMsQuerry As String

        strMsQuerry = "Select * from DATA1A_Products" _
                       & " where Status<>'XX' order by ProductName"

        daConditions = New SqlClient.SqlDataAdapter(strMsQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_Products")
        DataGridView1.DataSource = dsConditions.Tables("DATA1A_Products")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Columns("Description").Visible = False
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

    Private Sub frmProductList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmProduct As New frmProductEdit
        frmProduct.ShowDialog()
        Search()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim frmUser As New frmProductEdit(DataGridView1.CurrentRow)
        frmUser.ShowDialog()
        Search()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strQuerry As String
        strQuerry = "update DATA1A_Products set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
            & "' where Recid='" & DataGridView1.CurrentRow.Cells("RecId").Value & "'"
        pobjSql.DeleteGridViewRow(DataGridView1, strQuerry)
        Search()
    End Sub
#End Region

    
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        With DataGridView1
            If .RowCount > 0 Then
                txtDescription.Text = .CurrentRow.Cells("Description").Value
            End If
        End With
    End Sub

End Class