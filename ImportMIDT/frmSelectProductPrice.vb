Public Class frmSelectProductPrice

    Private mstrProductName As String
    Public Sub New(strProductName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrProductName = strProductName

    End Sub
    Private Sub frmSelectProductPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Search()
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "select  RecID, Region, ProductName, CostPrice, Cur, case when Cur = 'VND' then substring(convert(varchar,Amount),1,len(convert(varchar,Amount)) - 4) else convert(varchar,round(Amount,0)) end as Amount, " _
                                  & "case when Cur = 'VND' then substring(convert(varchar,AmountForAfter),1,len(convert(varchar,AmountForAfter)) - 4) else convert(varchar,round(AmountForAfter,0)) end as AmountForAfter, Formula, NbrOfUnit, Unit, Conditions, MinAmount, Occurrence, " _
                                  & "ValidFrom, ValidTo, Status, FstUser, LstUser, FstUpdate, LstUpdate " _
                                  & "From Data1a_ProductCosts " _
                                  & " where Status<>'XX' and CostPrice='PRICE' and ProductName='" _
                                  & mstrProductName & "' order by Amount"

        pobjSql.LoadDataGridView(dgFormula, strQuerry)
        If Not dgFormula.Columns.Contains("Selected") Then
            Dim dgcSelected As New DataGridViewCheckBoxColumn()
            dgcSelected.Name = "Selected"
            dgFormula.Columns.Insert(0, dgcSelected)
        End If
        
        'With dgFormula
        '    .Columns.Insert(0, dgcSelected)
        'End With
        dgFormula.Columns("Amount").DefaultCellStyle.Format = "N2"
        dgFormula.Columns("MinAmount").DefaultCellStyle.Format = "N2"
        dgFormula.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFormula.Columns("MinAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        pstrSelectedIds = ""
        Dim i As Integer
        With dgFormula
            For i = 0 To dgFormula.RowCount - 1
                If .Rows(i).Cells("Selected").Value Then
                    pstrSelectedIds = pstrSelectedIds & .Rows(i).Cells("RecId").Value & ","
                End If
            Next
        End With
        If pstrSelectedIds.Length > 0 Then
            pstrSelectedIds = Mid(pstrSelectedIds, 1, pstrSelectedIds.Length - 1)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        End If
    End Sub
    
End Class