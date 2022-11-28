Public Class frmProductRightEdit
    Private mblnContactDeleted As Boolean
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim lstQuerries As New List(Of String)
        Dim strStatus As String
        Dim strAddQuerry As String

        If Not CheckInputValues() Then
            Exit Sub
        End If
        If dtpValidTo.Value.Date = Now.AddDays(-1).Date Then
            strStatus = "EX"
        Else
            strStatus = "OK"
        End If
        If chkIndefValidTo.Checked Then
            strAddQuerry = "Insert into Data1A_ProductRights (ShortName, ContactId, Product, ProductId, Status, ValidFrom, Fstuser, Region)" _
            & " values ('" & cboShortName.Text & "'," & cboContactId.SelectedValue & ",'" & cboProduct.Text & "','" & txtProductId.Text _
            & "','" & strStatus & "','" & CreateFromDate(dtpValidFrom.Value) & "','" & pobjUser.UserName _
            & "','" & pobjUser.Region & "')"
        Else
            strAddQuerry = "Insert into Data1A_ProductRights (ShortName, ContactId, Product,ProductId, Status, ValidFrom, ValidTo, Fstuser,Region)" _
            & " values ('" & cboShortName.Text & "'," & cboContactId.SelectedValue & ",'" & cboProduct.Text & "','" & txtProductId.Text _
            & "','" & strStatus & "','" & CreateFromDate(dtpValidFrom.Value) & "','" & CreateToDate(dtpValidTo.Value) _
            & "','" & pobjUser.UserName & "','" & pobjUser.Region & "')"
        End If
        
        lstQuerries.Add(strAddQuerry)
        If txtRecId.Text > 0 Then
            lstQuerries.Add("Update Data1A_ProductRights set Status='XX', LstUpdate=GetDate(),LstUser='" _
                            & pobjUser.UserName & "' where Recid=" & txtRecId.Text)
        End If
        If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Unable to update Product Rights")
            Exit Sub
        End If
        Me.Dispose()
    End Sub
    Private Function CheckInputValues() As Boolean
        Dim strCheckDup As String

        If cboShortName.Text = "" Then
            MsgBox("Invalid ShortName")
            Return False
        End If
        If cboContactId.Text = "" Then
            MsgBox("Invalid Contact")
            Return False
        End If
        If cboProduct.Text = "" Then
            MsgBox("Invalid Product")
            Return False
        End If

        If cboProduct.Text.StartsWith("SECO") Then
            If txtProductId.Text = "" Then
                MsgBox("Invalid ProductID")
                Return False
            ElseIf Not Month(dtpValidTo.Value) <> Month(dtpValidTo.Value.AddDays(1)) Then
                MsgBox("ValidTo must be End of Month")
                Return False
            End If
        ElseIf DateDiff(DateInterval.Day, dtpValidTo.Value, Now) > 1 Then
            MsgBox("Invalid ValidTo")
            Return False
        End If

        strCheckDup = "Select top 1 RecId from Data1a_ProductRights where Status<>'XX'" _
            & " and ShortName='" & cboShortName.Text & "' and ContactId=" & txtContactId.Text _
            & " and Product='" & cboProduct.Text & "' and ProductiD='" & txtProductId.Text _
            & "' and (ValidFrom<'" & CreateFromDate(dtpValidFrom.Value) _
            & "' and (ValidTo = Null or ValidTo>='" & CreateFromDate(dtpValidFrom.Value) & "'))"
        If Not chkIndefValidTo.Checked Then
            strCheckDup = "Select top 1 RecId from Data1a_ProductRights where Status<>'XX'" _
            & " and ShortName='" & cboShortName.Text & "' and ContactId=" & txtContactId.Text _
            & " and Product='" & cboProduct.Text & "' and ProductiD='" & txtProductId.Text _
            & "' and ((ValidFrom<'" & CreateFromDate(dtpValidFrom.Value) _
            & "' and (ValidTo = Null or ValidTo>='" & CreateFromDate(dtpValidFrom.Value) & "')) or" _
            & "('" & CreateToDate(dtpValidTo.Value) & "' >=ValidFrom))"
        End If

        If pobjSql.GetScalarAsString(strCheckDup) <> "" Then
            MsgBox("Duplicate Record Exist!")
        End If

        Return True
    End Function
    Public Sub New(Optional dgrProductRight As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from Data1a_Customers" _
                          & " where Status<>'xx' and Region='" & pobjUser.Region & "' order by ShortName")
        pobjSql.LoadComboVal(cboContactId, "Select ContactId as Value, FullNameGB as Display" _
                            & " from Data1a_Contacts where Status<>'xx' order by FullNameGB")

        pobjSql.LoadCombo(cboProduct, "Select distinct ProductName as value from Data1a_ProductCosts " _
                          & " where Status<>'xx' and CostPrice='PRICE' order by ProductName")

        If dgrProductRight Is Nothing Then
            txtRecId.Text = 0
            dtpValidTo.Value = DateSerial(Now.Year, 12, 31)
            lbkExpire.Visible = False
        Else
            With dgrProductRight
                txtRecId.Text = .Cells("RecId").Value
                cboShortName.SelectedIndex = cboShortName.FindStringExact(.Cells("ShortName").Value)
                If IsDBNull(.Cells("ContactFullNameGB").Value) Then
                    cboContactId.SelectedIndex = -1
                    mblnContactDeleted = True
                Else
                    cboContactId.SelectedIndex = cboContactId.FindStringExact(.Cells("ContactFullNameGB").Value)
                    mblnContactDeleted = False
                End If

                cboProduct.SelectedIndex = cboProduct.FindStringExact(.Cells("Product").Value)
                txtProductId.Text = .Cells("ProductId").Value
                dtpValidFrom.Value = .Cells("ValidFrom").Value
                If IsDBNull(dgrProductRight.Cells("ValidTo").Value) Then
                    chkIndefValidTo.Checked = True
                Else
                    dtpValidTo.Value = .Cells("ValidTo").Value
                End If

                cboShortName.Enabled = False
                cboContactId.Enabled = False
                cboProduct.Enabled = False
                dtpValidFrom.Enabled = False
                txtProductId.Enabled = False
            End With

        End If
    End Sub
    Private Sub cboShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged
        If cboShortName.Items.Count > 0 Then
            pobjSql.LoadComboVal(cboContactId, "Select ContactId as Value, FullNameGB as Display" _
                             & " from Data1a_Contacts where Status<>'xx' and CustShortName='" _
                             & cboShortName.Text & "' order by FullNameGB")
        End If
    End Sub

    Private Sub frmProductRightEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lbkExpire_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkExpire.LinkClicked
        dtpValidTo.Value = Now.AddDays(-1)
    End Sub

    Private Sub cboContactId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContactId.SelectedIndexChanged
        If Not mblnContactDeleted Then
            txtContactId.Text = cboContactId.SelectedValue
        End If
    End Sub
End Class