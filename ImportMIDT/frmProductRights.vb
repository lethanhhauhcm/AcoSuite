Public Class frmProductRights

    Private Sub frmProductRights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadCombo(cboShortName, "Select ShortName as value from Data1a_Customers " _
                          & " where Status<>'xx' and Region='" & pobjUser.Region & "' order by ShortName")
        pobjSql.LoadCombo(cboProduct, "Select distinct ProductName as value from Data1a_ProductCosts " _
                          & " where Status<>'xx' and CostPrice='PRICE' order by ProductName")

        Clear()
        Search()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Function Clear() As Boolean
        cboShortName.SelectedIndex = -1
        cboContactId.SelectedIndex = -1
        cboContactId.Text = ""
        cboStatus.SelectedIndex = cboStatus.FindStringExact("OK")
        cboProduct.SelectedIndex = -1

        Return True
    End Function
    Private Function Search() As Boolean
        Dim strSelectContactName As String = "(Select FullNameGB from Data1a_Contacts where Status<>'XX' and ContactId=p.ContactId) as ContactFullNameGB"
        Dim strQuerry As String = "Select p.RecId, p.ShortName,p.ContactId," & strSelectContactName _
        & ",p.Product,p.ProductId, p.Status,convert(varchar,ValidFrom,106) as ValidFrom" _
        & ", convert(varchar, p.ValidTo, 106) As ValidTo" _
        & " from data1a_productRights p where RecId>0 and p.Region='" & pobjUser.Region & "'"

        AddEqualConditionCombo(strQuerry, cboShortName)
        If cboContactId.Text <> "" Then
            strQuerry = strQuerry & " and ContactId=" & cboContactId.SelectedValue
        End If
        AddEqualConditionCombo(strQuerry, cboStatus)
        AddEqualConditionCombo(strQuerry, cboProduct)

        pobjSql.LoadDataGridView(dgrProductRights, strQuerry)

        'dgrProductRights.Columns("ContactId").Visible = False
        Return True
    End Function

    Private Sub cboShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged
        If cboShortName.Items.Count > 0 Then
            pobjSql.LoadComboVal(cboContactId, "Select ContactId as Value, FullNameGB as Display" _
                             & " from Data1a_Contacts where Status<>'xx' and CustShortName='" _
                             & cboShortName.Text & "' order by FullNameGB")
            cboContactId.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmNew As New frmProductRightEdit
        frmNew.ShowDialog()
        Search()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgrProductRights.RowCount > 0 Then
            Dim frmNew As New frmProductRightEdit(dgrProductRights.CurrentRow)
            frmNew.ShowDialog()
            Search()
        End If
        
    End Sub
End Class