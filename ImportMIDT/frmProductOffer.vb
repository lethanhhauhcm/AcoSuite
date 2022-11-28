Public Class frmProductOffer
    Private Sub frmProductOffer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strRegion As String = IIf(pobjUser.City = "SGN", "South", "North")
        AddFromDatesMonthly(cboValidFrom, 12, 6)
        AddToDatesMonthly(cboValidTo)
        pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' order by ShortName")
        pobjSql.LoadCombo(cboPIC, "Select distinct PIC as Value from DATA1A_Customers where Status='OK' and Region='" & strRegion & "'")
        pobjSql.LoadCombo(cboProductName, "Select distinct ProductName as Value from [DATA1A_Products] where Status='OK'")
        Clear()
        Search()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "Select RecID, OfferId, ShortName, Object, ProductName, GetInvoice, Status" _
                                  & ", ValidFrom, ValidTo, OriRecID, ManualCheckRequired" _
                                  & ", ChargedUpTo" _
                                  & " from [Data1A_ProductOffer] where Status<>'XX' and Region='" & pobjUser.Region & "'"

        AddEqualConditionCombo(strQuerry, cboShortName)
        AddEqualConditionCombo(strQuerry, cboProductName)
        AddEqualConditionCombo(strQuerry, cboStatus)
        AddEqualConditionCheck(strQuerry, chkManualCheckRequired)


        If cboPIC.Text <> "" Then
            strQuerry = strQuerry & " and ShortName in " _
                & "(Select ShortName from DATA1A_Customers where Status='OK' and PIC='" & cboPIC.Text & "')"
        End If

        If cboValidFrom.Text <> "" Then
            strQuerry = strQuerry & " and '" & cboValidFrom.Text & "' between ValidFrom and ValidTo"
        End If

        If cboValidTo.Text <> "" Then
            strQuerry = strQuerry & " and '" & cboValidTo.Text & "' between ValidFrom and ValidTo"
        End If

        strQuerry = strQuerry & " order by ShortName,ValidFrom,ValidTo,Status"
        pobjSql.LoadDataGridView(dgOffer, strQuerry)


        With dgOffer
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .Columns("RecId").Width = 50
            .Columns("Status").Width = 40
            .Columns("OfferId").Width = 50
            .Columns("OriRecId").Width = 50
            '.Columns("ChargedUpTo").Visible = False
        End With

        Return True
    End Function
    Private Function Clear() As Boolean
        cboShortName.SelectedIndex = -1
        cboPIC.SelectedIndex = -1
        cboProductName.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboValidFrom.SelectedIndex = -1
        cboValidTo.SelectedIndex = -1
        chkManualCheckRequired.CheckState = CheckState.Indeterminate
        Return True
    End Function
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub lbkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkNew.LinkClicked
        Dim frmNewOffer As New frmProductOfferEdit
        If frmNewOffer.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If

    End Sub

    Private Sub lbkCopy2Others_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkCopy2Others.LinkClicked


        Dim lstCustomers As New List(Of String)
        Dim frmCustomerSelection As New frmCustomerSelection(pobjUser.UserName)
        frmCustomerSelection.ShowDialog()

        If frmCustomerSelection.DialogResult = Windows.Forms.DialogResult.OK _
            AndAlso frmCustomerSelection.Customers.Count > 0 Then


            For Each strShortName As String In frmCustomerSelection.Customers
                Dim lstQuerries As New List(Of String)
                Dim intNewOfferId As Integer
                Dim intNewRecId As Integer

                With dgOffer.CurrentRow
                    lstQuerries.Add("Insert into Data1A_ProductOffer (Region,OfferId,ShortName,Object,ProductName, Status" _
                                & ", ValidFrom, ValidTo, OriRecID,ManualCheckRequired, FstUser)" _
                                & " values ('" & pobjUser.Region & "',(Select isnull(Max(OfferId),0)+1 from Data1A_ProductOffer),'" _
                                & strShortName & "','" & .Cells("Object").Value & "','" & .Cells("ProductName").Value _
                                & "','--','" & CreateFromDate(.Cells("ValidFrom").Value) _
                                & "','" & CreateFromDate(.Cells("ValidTo").Value) _
                                & "',0,'" & .Cells("ManualCheckRequired").Value & "','" & pobjUser.UserName & "')")
                    If Not pobjSql.UpdateListOfQuerries(lstQuerries, True) Then
                        MsgBox("Unable to copy to Customer " & strShortName)
                        Continue For
                    End If
                    intNewRecId = pobjSql.LastInsertedId
                        intNewOfferId = pobjSql.GetScalarAsString("Select Offerid from Data1A_ProductOffer where RecId=" _
                                                                  & pobjSql.LastInsertedId.ToString)
                        lstQuerries.Clear()

                        With dgFormula
                        For i = 0 To dgFormula.RowCount - 1
                            lstQuerries.Add("Insert into DATA1A_MISC (CAT,VAL,VAL1) values ('ProductOfferPrice','" _
                                            & intNewOfferId & "','" & .Rows(i).Cells("RecId").Value & "')")
                        Next
                        lstQuerries.Add("Update Data1A_ProductOffer set Status='OK' where Recid=" & intNewRecId)
                        If Not pobjSql.UpdateListOfQuerries(lstQuerries, True) Then
                            MsgBox("Unable to copy to Customer " & strShortName)
                            Continue For
                        End If
                        End With

                End With

            Next
        End If
        frmCustomerSelection.Dispose()
        Search()
    End Sub

    Private Sub lbkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkEdit.LinkClicked
        Dim strNewId As String = pobjSql.GetScalarAsString("Select RecId from Data1a_ProductOffer where OriRecID=" _
                                                           & dgOffer.CurrentRow.Cells("RecId").Value)
        If strNewId <> "" Then
            MsgBox("Unable to Edit. This record is/will be replaced by RecId " & strNewId)
            Exit Sub
        End If

        Dim frmNewOffer As New frmProductOfferEdit(dgOffer.CurrentRow)
        If frmNewOffer.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked

        If pobjSql.GetScalarAsString("Select PIC from Data1a_Customers where Status='OK' and ShortName='" _
                                     & dgOffer.CurrentRow.Cells("ShortName").Value & "'") <> pobjUser.UserName And pobjUser.UserName <> "batx" Then
            MsgBox("You are not PIC for this Customer")
            Exit Sub
        End If

        With dgOffer.CurrentRow
            Dim strQuerry As String = "Update Data1A_ProductOffer Set Status='XX',LstUpdate=GetDate()" _
                                    & ",LstUser='" & pobjUser.UserName _
                                    & "' where RecId=" & .Cells("RecId").Value _
                                    & " and Status='" & .Cells("Status").Value & "'"

            pobjSql.DeleteGridViewRow(dgOffer, strQuerry)

            'If .Cells("Status").Value = "--" Or .Cells("Status").Value = "RJ" Then
            '    pobjSql.DeleteGridViewRow(dgOffer, strQuerry)
            'ElseIf .Cells("Status").Value = "OK" Then
            '    'If pobjSql.IsProductCalculated(.Cells("ValidFrom").Value, .Cells("ValidTo").Value) Then
            '    '    If MsgBox("Product have been calculated!Do You want to Delete?") = MsgBoxResult.Ok Then
            '    '        If pobjSql.DeleteGridViewRow(dgOffer, strQuerry) Then
            '    '            If frmProductCalc.DeleteProductCalc(pobjUser.Region, .Cells("ValidFrom").Value, .Cells("ValidTo").Value _
            '    '                                                    , .Cells("ShortName").Value) Then
            '    '                MsgBox("Offer deleted")
            '    '            Else
            '    '                pobjSql.ExecuteNonQuerry("Update Data1A_ProductOffer Set Status='OK',LstUpdate=GetDate()" _
            '    '                    & ",LstUser='" & pobjUser.UserName _
            '    '                    & "' where RecId=" & .Cells("RecId").Value _
            '    '                    & " and Status='XX'")
            '    '                MsgBox("Unable to Delete Offer")
            '    '            End If
            '    '        Else
            '    '            Exit Sub
            '    '        End If
            '    '    Else
            '    '        Exit Sub
            '    '    End If

            '    'End If

            'End If
            Search()
        End With
    End Sub

    Private Sub lbkApprove_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkApprove.LinkClicked
        Dim lstQuerries As New List(Of String)
        If Not pobjUser.HasRight("Action", "Product", "ApproveOffer") Then
            MsgBox("You do not have right to take this action")
            Exit Sub
        End If
        With dgOffer.CurrentRow
            'If pobjSql.IsProductCalculatedByDate(.Cells("ValidFrom").Value, .Cells("ValidTo").Value _
            '                                       , .Cells("ShortName").Value) Then
            '    If MsgBox("Product for this customer will be recalculates! Do you want to continue?") Then

            '        If Not frmProductCalc.DeleteProductCalc(pobjUser.Region, .Cells("ValidFrom").Value, .Cells("TimeFrame").Value _
            '                                       , .Cells("ShortName").Value) Then
            '            MsgBox("Không xóa được Product. Đề nghị báo lỗi ngay!")
            '            Exit Sub
            '        End If
            '        If Not frmProductCalc.CalculateProduct(pobjUser.Region, .Cells("ValidFrom").Value, .Cells("TimeFrame").Value _
            '                                       , .Cells("ShortName").Value) Then
            '            MsgBox("Không tính lại được Product. Đề nghị báo lỗi ngay!")
            '            Exit Sub
            '        End If
            '    Else
            '        Exit Sub
            '    End If

            'End If

            If .Cells("Status").Value = "--" Then
                lstQuerries.Add("update Data1A_ProductOffer set Status='OK'" _
                                          & ",ApprovedDate=getdate(),ApprovedBy='" & pobjUser.UserName _
                                          & "' where RecId=" & .Cells("RecId").Value)
                lstQuerries.Add("update Data1A_ProductOffer set Status='EX'" _
                                          & ",lstUpdate=getdate()" _
                                          & " where RecId=" & .Cells("OriRecID").Value & " and Status='OK'")
            End If
            If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
                MsgBox("Unable to update SQL")
            End If
            Search()
        End With
    End Sub

    Private Sub lbkReject_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkReject.LinkClicked
        If Not pobjUser.HasRight("Action", "Product", "ApproveOffer") Then
            MsgBox("You do not have right to take this action")
            Exit Sub
        End If
        With dgOffer.CurrentRow
            If .Cells("Status").Value = "--" Then
                pobjSql.ExecuteNonQuerry("update Data1A_ProductOffer set Status='RJ' where RecId=" & .Cells("RecId").Value)
            End If
            Search()
        End With
    End Sub

    Private Sub dgOffer_SelectionChanged(sender As Object, e As EventArgs) Handles dgOffer.SelectionChanged
        If dgOffer.RowCount > 0 Then
            pobjSql.LoadDataGridView(dgFormula, "select RecID, ProductName, CostPrice, Cur, case when Cur = 'VND' then substring(convert(varchar,Amount),1,len(convert(varchar,Amount)) - 4) else convert(varchar,round(Amount,0)) end as Amount " _
                                     & ", case when Cur = 'VND' then substring(convert(varchar,AmountForAfter),1,len(convert(varchar,AmountForAfter)) - 4) else convert(varchar,round(AmountForAfter,0)) end as AmountForAfter, Formula" _
                                     & ", NbrOfUnit, Unit, Conditions, MinAmount, Occurrence" _
                                     & " from Data1a_ProductCosts where CostPrice='PRICE' and RecId in " _
                                     & "(Select VAL1 from DATA1A_MISC where CAT='ProductOfferPrice' and Val='" _
                                     & dgOffer.CurrentRow.Cells("OfferId").Value & "') order by Amount")
            dgFormula.Columns("Amount").DefaultCellStyle.Format = "N0"
            dgFormula.Columns("MinAmount").DefaultCellStyle.Format = "N0"
            lbkCopy2Others.Visible = True
            lbkDelete.Visible = True
        Else
            dgFormula.Refresh()
        End If

    End Sub
End Class