Public Class frmIncentiveFormulaEdit

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strQuerry As String
        If Not CheckInputValues() Then Exit Sub

        strQuerry = "insert into [Data1A_IncentiveFormula] (VND,BlockOf, Unit,ApplyTo, ObjectTarget" _
            & ", CustomerTarget,CustomerTimeFrame,BkgOffcId,TktOffcId)" _
            & " values (" & txtVND.Text & "," & cboBlockOf.Text & ",'" & cboUnit.Text & "','" & cboApplyTo.Text _
            & "','" & txtObjectTarget.Text & "','" & txtCustomerTarget.Text & "','" & cboCustomerTimeFrame.Text _
            & "','" & cboBkgOffcId.Text & "','" & cboTktOffcId.Text & "')"

        If Not pobjSql.ExecuteNonQuerry(strQuerry) Then
            MsgBox("Unable to update")
            Exit Sub
        End If
        Me.Dispose()
    End Sub
    Private Function CheckInputValues() As Boolean
        If cboUnit.Text = "" Then
            MsgBox("Invalid Unit")
            Return False
        End If

        If cboApplyTo.Text = "TimeFrame" AndAlso cboBlockOf.Text <> 1 Then
            MsgBox("Conflicted values ApplyTo and BlockOf")
            Return False
        End If

        If cboBlockOf.Text = "" Then
            MsgBox("Invalid BlockOf")
            Return False
        End If

        If Not IsNumeric(txtVND.Text) Then
            MsgBox("Invalid VND")
            Return False
        ElseIf Not IsNumeric(txtObjectTarget.Text) Then
            MsgBox("Invalid ObjectTarget")
            Return False
        ElseIf Not IsNumeric(txtCustomerTarget.Text) Then
            MsgBox("Invalid MonthlyCustomerTarget")
            Return False
        ElseIf (txtVND.Text / cboBlockOf.Text) > 200000 AndAlso cboApplyTo.Text = "Unit" Then
            MsgBox("Too high incentive per Unit")
            Return False
        ElseIf cboUnit.Text = "Ticket" Then
            If cboBkgOffcId.Text = "" Then
                MsgBox("Invalid BkgOffcId")
                Return False
            ElseIf cboTktOffcId.Text = "" Then
                MsgBox("Invalid TktOffcId")
                Return False
            End If
        ElseIf cboBkgOffcId.Text <> "" Then
            MsgBox("Invalid BkgOffcId")
            Return False
        ElseIf cboTktOffcId.Text <> "" Then
            MsgBox("Invalid TktOffcId")
            Return False
        End If

        If (txtCustomerTarget.Text > 0 AndAlso cboCustomerTimeFrame.Text = "") _
            Or (txtCustomerTarget.Text = 0 AndAlso cboCustomerTimeFrame.Text <> "") Then
            MsgBox("Conflicted CustomerTarget and CustomerTimeFrame")
            Return False
        End If
        Return True
    End Function

    Private Sub frmIncentiveFormulaEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboUnit.SelectedIndex = 0
        cboApplyTo.SelectedIndex = 0
    End Sub

    Private Sub cboUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUnit.SelectedIndexChanged
        If cboUnit.Text = "Ticket" Then
            lblBkgOffcId.Visible = True
            cboBkgOffcId.Visible = True
        Else
            lblBkgOffcId.Visible = False
            cboBkgOffcId.Visible = False
        End If
    End Sub

    Private Sub cboApplyTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboApplyTo.SelectedIndexChanged
        
    End Sub
End Class