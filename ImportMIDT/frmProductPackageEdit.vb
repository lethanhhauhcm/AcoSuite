Public Class frmProductPackageEdit
    Public Sub New(strProductName As String, Optional dgrInput As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cboProductName.Items.Add(strProductName)
        cboProductName.Text = strProductName

        If dgrInput Is Nothing Then
            'pobjSql.LoadCombo(cboProductName, "Select ProductName as Value from DATA1A_Products where status<>'XX' order by ProductName")
            pobjSql.LoadCombo(cboSubProductName, "Select ProductName as Value from DATA1A_Products where status<>'xx'" _
                              & " and ProductType='UnBundled' order by ProductName")
            dtpTo.Value = "31-Dec-2020"
        Else
            txtRecId.Text = dgrInput.Cells("Recid").Value
            cboProductName.Text = dgrInput.Cells("ProductName").Value
            cboSubProductName.Text = dgrInput.Cells("SubProductName").Value
            txtNbrOfUnit.Text = dgrInput.Cells("NbrOfUnit").Value
            cboUnit.Text = dgrInput.Cells("Unit").Value
            cboCondition.Text = dgrInput.Cells("Conditions").Value
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

        lstQuerries.Add("Insert into DATA1A_ProductPackages (ProductName,[SubProductName],NbrOfUnit, Unit, Conditions" _
                        & ", ValidFrom, ValidTo, Status, FstUser) values ('" _
                        & cboProductName.Text & "','" & cboSubProductName.Text _
                        & "'," & txtNbrOfUnit.Text & ",'" & cboUnit.Text & "','" & cboCondition.Text _
                        & "','" & CreateFromDate(dtpFrom.Value) & "','" & CreateToDate(dtpTo.Value) _
                        & "','OK','" & pobjUser.UserName & "')")
        If txtRecId.Text <> "" Then
            lstQuerries.Add("update DATA1A_ProductPackages set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
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

        Dim strCheckOverlappedDates As String = "Select count RecId from DATA1A_ProductPackages where status<>'XX'" _
                                                & " and ProductName='" & cboProductName.Text _
                                                & "' and SubProductName='" & cboSubProductName.Text _
                                                & "' and  (ValidFrom " & strDateCondition & " or ValidTo " & strDateCondition & ")"

        If cboProductName.Text.Length < 3 Then
            MsgBox("Invalid ProductName")
            Return False
        End If
        If cboSubProductName.Text.Length < 3 Then
            MsgBox("Invalid SubProductName")
            Return False
        End If

        If txtRecId.Text = "" AndAlso pobjSql.GetScalarAsString(strCheckOverlappedDates) <> "" Then
            MsgBox("Overlapped Dates with existing record for the same ProductName")
            Return False
        End If

        If DateDiff(DateInterval.Day, CDate(strToDate), CDate(strFromDate)) > 0 Then
            MsgBox("From Date must before/on To Date")
            Return False
        End If

        If Not IsNumeric(txtNbrOfUnit.Text) Then
            MsgBox("Invalid Cost/MinCost")
            Return False
        End If

        If cboUnit.Text = "" Then
            MsgBox("Invalid Product Unit")
            Return False
        End If
        If cboCondition.Text = "" Then
            MsgBox("Invalid Formula")
            Return False
        End If
        Return True
    End Function

    Private Sub cboProductName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboProductName.SelectionChangeCommitted
        If txtRecId.Text = "" Then
            pobjSql.LoadCombo(cboSubProductName, "Select ProductName as Value from DATA1A_Products where status<>'xx'" _
                              & " and ProductType='UnBundled' order by ProductName")
        End If
    End Sub
End Class