Public Class frmSelectIncentiveFormula
    Private mblnFirstLoadCompleted As Boolean
    Private mstrObject As String

    Public Sub New(strTimeFrame As String, strObject As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pstrIncentiveFormulas = ""
        mstrObject = strObject
    End Sub

    Private Sub frmSelectIncentiveFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
        mblnFirstLoadCompleted = True
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "select * from Data1a_IncentiveFormula where RecId>0"

        AddEqualConditionCombo(strQuerry, cboApplyTo)
        AddEqualConditionCombo(strQuerry, cboUnit)
        AddEqualConditionCombo(strQuerry, cboBlockOf)

        If mstrObject = "Customer" Then
            strQuerry = strQuerry & " and CustomerTarget=0"
        End If
        pobjSql.LoadDataGridView(dgFormula, strQuerry _
                                 & " order by VND,ObjectTarget")
        Dim dgcSelected As New DataGridViewCheckBoxColumn()

        dgcSelected.Name = "Selected"
        With dgFormula
            If Not .Columns.Contains("Selected") Then
                .Columns.Add(dgcSelected)
            End If
            .Columns("Selected").DisplayIndex = 0
        End With
        dgFormula.Columns("VND").DefaultCellStyle.Format = "N0"
        dgFormula.Columns("ObjectTarget").DefaultCellStyle.Format = "N0"
        dgFormula.Columns("Selected").Width = 40
        dgFormula.Columns("RecId").Width = 40
        dgFormula.Columns("VND").Width = 70
        dgFormula.Columns("ApplyTo").Width = 70
        dgFormula.Columns("Unit").Width = 60
        dgFormula.Columns("BlockOf").Width = 50
        dgFormula.Columns("ObjectTarget").Width = 80
        'ResizeDataGridViewColumns(dgFormula, -10)
        Return True
    End Function
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim i As Integer
        With dgFormula
            For i = 0 To dgFormula.RowCount - 1
                If .Rows(i).Cells("Selected").Value Then
                    pstrIncentiveFormulas = pstrIncentiveFormulas & .Rows(i).Cells("RecId").Value & ","
                End If
            Next
        End With
        If pstrIncentiveFormulas.Length > 0 Then
            pstrIncentiveFormulas = Mid(pstrIncentiveFormulas, 1, pstrIncentiveFormulas.Length - 1)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            'Me.Dispose()
        End If
    End Sub

    Private Sub lbkShowAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkShowAll.LinkClicked
        cboUnit.SelectedIndex = -1
        cboApplyTo.SelectedIndex = -1
        cboBlockOf.SelectedIndex = -1
    End Sub

    Private Sub cboUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUnit.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            search()
        End If
    End Sub

    Private Sub cboApplyTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboApplyTo.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            Search()
        End If
    End Sub

    Private Sub cboBlockOf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBlockOf.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            Search()
        End If
    End Sub
End Class