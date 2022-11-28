Public Class frmIncentiveFormula

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmIncentiveFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strConvertVND As String = "replace(convert(varchar,convert(Money, VND),1),'.00','')"
        pobjSql.LoadCombo(cboVND, "Select distinct VND, " & strConvertVND & " AS VALUE" _
                          & " from Data1A_IncentiveFormula order by VND")
        pobjSql.LoadCombo(cboBlockOf, "Select distinct BlockOf AS VALUE" _
                          & " from Data1A_IncentiveFormula order by BlockOf")
        cboVND.SelectedIndex = -1
        cboBlockOf.SelectedIndex = -1
        Search()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        frmIncentiveFormulaEdit.ShowDialog()
        Search()
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "Select * from Data1A_IncentiveFormula where RecId>0"

        AddEqualConditionCombo(strQuerry, cboUnit)
        AddEqualConditionCombo(strQuerry, cboApplyTo)
        AddEqualConditionCombo(strQuerry, cboBlockOf)

        If cboVND.Text <> "" Then
            strQuerry = strQuerry & " and VND=" & CLng(cboVND.Text)
        End If
        strQuerry = strQuerry & " order by ApplyTo,Unit,VND,ObjectTarget"

        pobjSql.LoadDataGridView(dgFormula, strQuerry)
        dgFormula.Columns("VND").DefaultCellStyle.Format = "N0"
        dgFormula.Columns("ObjectTarget").DefaultCellStyle.Format = "N0"
        dgFormula.Columns("RecId").Width = 40
        dgFormula.Columns("VND").Width = 70
        dgFormula.Columns("BlockOf").Width = 50
        dgFormula.Columns("ApplyTo").Width = 60
        dgFormula.Columns("Unit").Width = 60
        dgFormula.Columns("ObjectTarget").Width = 70
        dgFormula.Columns("CustomerTarget").Width = 80

        Return True
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cboUnit.SelectedIndex = -1
        cboApplyTo.SelectedIndex = -1
        cboVND.SelectedIndex = -1
        cboBlockOf.SelectedIndex = -1
    End Sub

    Private Sub cboVND_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVND.SelectedIndexChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class