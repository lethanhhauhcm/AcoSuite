Public Class frmProductCostEdit
    Private mstrCostPrice As String
    Public Sub New(strCostPrice As String, Optional dgrInput As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrCostPrice = strCostPrice
        If dgrInput Is Nothing Then
            pobjSql.LoadCombo(cboProductName, "Select ProductName as Value from DATA1A_Products where status<>'XX' order by ProductName")
            dtpTo.Value = "31-Dec-2020"
        Else
            txtRecId.Text = dgrInput.Cells("Recid").Value
            cboProductName.Items.Add(dgrInput.Cells("ProductName").Value)
            cboProductName.Text = dgrInput.Cells("ProductName").Value
            cboCur.Text = dgrInput.Cells("Cur").Value
            txtAmount.Text = dgrInput.Cells("Amount").Value
            cboFormula.Text = dgrInput.Cells("Formula").Value
            txtNbrOfUnit.Text = dgrInput.Cells("NbrOfUnit").Value
            cboUnit.Text = dgrInput.Cells("Unit").Value
            cboCondition.Text = dgrInput.Cells("Conditions").Value
            txtMinAmount.Text = dgrInput.Cells("MinAmount").Value
            cboOccurrence.Text = dgrInput.Cells("Occurrence").Value
            dtpFrom.Value = dgrInput.Cells("ValidFrom").Value
            dtpTo.Value = dgrInput.Cells("ValidTo").Value
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerries As New List(Of String)
        'Dim strPassword As String

        If Not CheckInputValue() Then
            Exit Sub
        End If

        lstQuerries.Add("Insert into DATA1A_ProductCosts (Region,ProductName,CostPrice,[Cur],[Amount], [AmountForAfter] ,Formula, NbrOfUnit, Unit" _
                        & " , Conditions, MinAmount" _
                        & ", Occurrence, ValidFrom, ValidTo, Status, FstUser) values ('" & pobjUser.Region & "','" _
                        & cboProductName.Text & "','" & mstrCostPrice & "','" & cboCur.Text & "'," & txtAmount.Text _
                        & "," & If(txtAmountAfter.Text = "", 0, txtAmountAfter.Text) & ",'" & cboFormula.Text & "','" & txtNbrOfUnit.Text & "','" & cboUnit.Text _
                        & "','" & cboCondition.Text & "'," & txtMinAmount.Text _
                         & ",'" & cboOccurrence.Text _
                        & "','" & CreateFromDate(dtpFrom.Value) & "','" & CreateToDate(dtpTo.Value) _
                        & "','OK','" & pobjUser.UserName & "')")
        If txtRecId.Text <> "" Then
            lstQuerries.Add("update DATA1A_ProductCosts set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                & "' where Recid=" & txtRecId.Text)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Me.Dispose()
        Else
            MsgBox(pobjSql.UpdtErr)
        End If

    End Sub
    Private Function CheckInputValue() As Boolean
        Dim strFromDate As String = CreateFromDate(dtpFrom.Value)
        Dim strToDate As String = CreateToDate(dtpTo.Value)
        Dim strDateCondition As String = "between '" & strFromDate & "' and '" & strToDate & "'"

        If mstrCostPrice = "COST" Then
            Dim strCheckOverlappedDates As String = "Select count RecId from DATA1A_ProductCosts where status<>'XX'" _
                                                & " and ProductName='" & cboProductName.Text & "' and CostPrice='COST'" _
                                                & " and  (ValidFrom " & strDateCondition & " or ValidTo " & strDateCondition & ")"
            If txtRecId.Text = "" AndAlso pobjSql.GetScalarAsString(strCheckOverlappedDates) <> "" Then
                MsgBox("Overlapped Dates with existing record for the same ProductName")
                Return False
            End If
        End If

        If cboProductName.Text.Length < 3 Then
            MsgBox("Invalid ProductName")
            Return False
        End If

        If DateDiff(DateInterval.Day, CDate(strToDate), CDate(strFromDate)) > 0 Then
            MsgBox("From Date must before/on To Date")
            Return False
        End If

        If Not IsNumeric(txtNbrOfUnit.Text) Or Not IsNumeric(txtMinAmount.Text) Then
            MsgBox("Invalid NbrOfUnit/MinAmount")
            Return False
        End If

        If cboOccurrence.Text.Length < 2 Then
            MsgBox("Invalid Occurrence")
            Return False
        End If

        If cboCur.Text = "" Then
            MsgBox("Invalid Currency")
            Return False
        End If

        If cboUnit.Text = "" Then
            MsgBox("Invalid Product Unit")
            Return False
        End If
        If cboFormula.Text = "" Then
            MsgBox("Invalid Formula")
            Return False
        End If
        If cboCondition.Text = "" Then
            MsgBox("Invalid Formula")
            Return False
        End If
        Return True
    End Function

    Private Sub frmProductCostEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAmountAfter.Enabled = False
    End Sub

    Private Sub cboFormula_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFormula.SelectedIndexChanged
        If cboFormula.Text = "Block" Then
            txtAmountAfter.Enabled = False
            txtAmountAfter.Text = ""
            If txtAmount.Text = "(Giá áp dụng cho MinAmout đầu tiên)" Then
                txtAmount.Text = ""
            End If
        Else txtAmountAfter.Enabled = True
            If txtAmount.Text = "" Then
                txtAmount.Text = "(Giá áp dụng cho MinAmout đầu tiên)"
            End If
            txtAmountAfter.Text = "(Giá áp dụng cho những cái về sau)"
        End If
    End Sub

    Private Sub txtAmount_Enter(sender As Object, e As EventArgs) Handles txtAmount.Enter
        If txtAmount.Text = "(Giá áp dụng cho MinAmout đầu tiên)" Then
            txtAmount.Text = ""
        End If
    End Sub

    Private Sub txtAmount_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        If txtAmount.Text = "" And cboFormula.Text = "First" Then
            txtAmount.Text = "(Giá áp dụng cho MinAmout đầu tiên)"
        End If
    End Sub

    Private Sub txtAmountAfter_Enter(sender As Object, e As EventArgs) Handles txtAmountAfter.Enter
        If txtAmountAfter.Text = "(Giá áp dụng cho những cái về sau)" Then
            txtAmountAfter.Text = ""
        End If
    End Sub

    Private Sub txtAmountAfter_Leave(sender As Object, e As EventArgs) Handles txtAmountAfter.Leave
        If txtAmountAfter.Text = "" Then
            txtAmountAfter.Text = "(Giá áp dụng cho những cái về sau)"
        End If
    End Sub
End Class



