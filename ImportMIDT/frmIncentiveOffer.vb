Public Class frmIncentiveOffer
    
    Private Sub frmIncentiveOffer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strRegion As String = IIf(pobjUser.City = "SGN", "South", "North")
        AddFromDatesMonthly(cboValidFrom, 12, 1)
        AddToDatesQuartely(cboValidTo)
        pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' order by ShortName")
        pobjSql.LoadCombo(cboPIC, "Select distinct PIC as Value from DATA1A_Customers where Status='OK' and Region='" & strRegion & "'")
        Clear()
        Search()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "Select RecID, OfferId, ShortName, Object, TimeFrame, Status" _
                                    & ", Convert(varchar, validfrom ,6) as ValidFrom" _
                                    & ", Convert(varchar, validto ,6) as ValidTo" _
                                    & ", OriRecID, ManualCheckRequired" _
                                    & ", FstUpdate, LstUpdate, FstUser, LstUser" _
                                    & ",ApprovedBy, ApprovedDate,CalcUpTo,CalcUpTo4Tkt" _
                                    & " from [Data1A_IncentiveOffer] where Status<>'XX'" _
                                    & " and ShortName in (Select ShortName from DATA1A_Customers" _
                                    & " where Status='OK' and Region='" & pobjUser.Region & "')"

        AddEqualConditionCombo(strQuerry, cboShortName)
        AddEqualConditionCombo(strQuerry, cboStatus)
        AddEqualConditionCombo(strQuerry, cboObject)
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

        strQuerry = strQuerry & " order by ShortName,ValidFrom,ValidTo,TimeFrame,Status"
        pobjSql.LoadDataGridView(dgOffer, strQuerry)

        With dgOffer            
            .Columns("RecId").Width = 40
            .Columns("OfferId").Width = 50
            .Columns("OriRecID").Width = 60
            .Columns("Object").Width = 80
            .Columns("TimeFrame").Width = 60
            .Columns("Status").Width = 40
            .Columns("ValidFrom").Width = 60
            .Columns("ValidTo").Width = 60
            .Columns("FstUser").Width = 60
            .Columns("LstUser").Width = 60
        End With

        Return True
    End Function
    Private Function Clear() As Boolean
        cboShortName.SelectedIndex = -1
        cboPIC.SelectedIndex = -1
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
        Dim frmNewOffer As New frmIncentiveOfferEdit
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
                With dgOffer.CurrentRow
                    If pobjSql.IsIncentiveCalculatedByDate(.Cells("ValidFrom").Value, .Cells("TimeFrame").Value _
                                                           , strShortName) Then
                        MsgBox("Invalid ValidFrom. Incentives had been calculated for customer" & strShortName)
                    ElseIf pobjSql.IsIncentiveCalculatedByDate(.Cells("ValidTo").Value, .Cells("TimeFrame").Value _
                                   , strShortName) Then
                        MsgBox("Invalid ValidTo. Incentives had been calculated for customer" & strShortName)
                    End If


                    Dim strDupCheck As String = "Select top 1 RecId from Data1a_IncentiveOffer where Status='--' and Object='" _
                                         & .Cells("Object").Value _
                                         & "' and ShortName='" & strShortName _
                                         & "' and TimeFrame='" & .Cells("TimeFrame").Value _
                                         & "' and ('" & CreateFromDate(.Cells("ValidFrom").Value) _
                                         & "' between ValidFrom and ValidTo" _
                                         & " or '" & CreateFromDate(.Cells("ValidTo").Value) _
                                         & "' between ValidFrom and ValidTo)"

                    Dim strDupOfferId As String = pobjSql.GetScalarAsString(strDupCheck)

                    If strDupOfferId <> "" Then
                        MsgBox("Duplicate/Overlap with RecId " & strDupOfferId & " for customer " & strShortName)
                    Else
                        lstQuerries.Add("Insert into Data1A_IncentiveOffer (OfferId,ShortName,Object, TimeFrame, Status" _
                                & ", ValidFrom, ValidTo, OriRecID,ManualCheckRequired, FstUser)" _
                                & " values ((Select isnull(Max(OfferId),0)+1 from Data1A_IncentiveOffer),'" _
                                & strShortName & "','" & .Cells("Object").Value & "','" & .Cells("TimeFrame").Value _
                                & "','--','" & CreateFromDate(.Cells("ValidFrom").Value) _
                                & "','" & CreateFromDate(.Cells("ValidTo").Value) _
                                & "',0,'" & .Cells("ManualCheckRequired").Value & "','" & pobjUser.UserName & "')")
                        If Not pobjSql.UpdateListOfQuerries(lstQuerries, True) Then
                            MsgBox("Unable to copy to Customer " & strShortName)
                            Continue For
                        End If
                        intNewOfferId = pobjSql.GetScalarAsString("Select Offerid from Data1A_IncentiveOffer where RecId=" _
                                                                  & pobjSql.LastInsertedId.ToString)
                        lstQuerries.Clear()

                        With dgFormula
                            For i = 0 To dgFormula.RowCount - 1
                                lstQuerries.Add("Insert into DATA1A_MISC (CAT,VAL,VAL1) values ('OfferFormula','" _
                                                & intNewOfferId & "','" & .Rows(i).Cells("RecId").Value & "')")
                            Next
                            If Not pobjSql.UpdateListOfQuerries(lstQuerries, True) Then
                                MsgBox("Unable to copy to Customer " & strShortName)
                                Continue For
                            End If
                        End With
                    End If
                End With
                
            Next
        End If
        frmCustomerSelection.Dispose()
        Search()
    End Sub
    Private Function CopyOffer(intOfferId As Integer, strCustShortName As String _
                               , dteFromDate As Date, dteToDate As Date) As Boolean

        Return True
    End Function
    Private Sub lbkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkEdit.LinkClicked
        Dim strNewId As String = pobjSql.GetScalarAsString("Select RecId from Data1a_IncentiveOffer where OriRecID=" _
                                                           & dgOffer.CurrentRow.Cells("RecId").Value _
                                                           & " and Status<>'XX'")
        If strNewId <> "" Then
            MsgBox("Unable to Edit. This record is/will be replaced by RecId " & strNewId)
            Exit Sub
        End If

        Dim frmNewOffer As New frmIncentiveOfferEdit(dgOffer.CurrentRow)
        If frmNewOffer.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked

        If pobjSql.GetScalarAsString("Select PIC from Data1a_Customers where Status='OK' and ShortName='" _
                                     & dgOffer.CurrentRow.Cells("ShortName").Value & "'") <> pobjUser.UserName Then
            MsgBox("You are not PIC for this Customer")
            Exit Sub
        End If

        With dgOffer.CurrentRow
            Dim strQuerry As String = "Update Data1A_IncentiveOffer Set Status='XX',LstUpdate=GetDate()" _
                                    & ",LstUser='" & pobjUser.UserName _
                                    & "' where RecId=" & .Cells("RecId").Value _
                                    & " and Status='" & .Cells("Status").Value & "'"

            Select Case .Cells("Status").Value
                Case "--", "RJ", ""
                    pobjSql.DeleteGridViewRow(dgOffer, strQuerry)
                Case "OK"
                    If pobjSql.IsIncentiveCalculated(.Cells("ValidFrom").Value, .Cells("ValidTo").Value) Then
                        If MsgBox("Incentive have been calculated!Do You want to Delete?") = MsgBoxResult.Ok Then
                            If pobjSql.DeleteGridViewRow(dgOffer, strQuerry) Then
                                If frmIncentiveCalc.DeleteIncentiveCalc(pobjUser.Region, .Cells("ValidFrom").Value, .Cells("ValidTo").Value _
                                                                        , .Cells("ShortName").Value) Then
                                    MsgBox("Offer deleted")
                                Else
                                    pobjSql.ExecuteNonQuerry("Update Data1A_IncentiveOffer Set Status='OK',LstUpdate=GetDate()" _
                                        & ",LstUser='" & pobjUser.UserName _
                                        & "' where RecId=" & .Cells("RecId").Value _
                                        & " and Status='XX'")
                                    MsgBox("Unable to Delete Offer")
                                End If
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If

                    End If

            End Select
            Search()
        End With
    End Sub

    Private Sub lbkApprove_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkApprove.LinkClicked
        Dim lstQuerries As New List(Of String)
        Dim i, mYear, mMonthFrom, mMonthTo As Integer  '^_^20220708 add by 7643

        If Not pobjUser.HasRight("Action", "Incentive", "ApproveOffer") Then
            MsgBox("You do not have right to take this action")
            Exit Sub
        End If
        With dgOffer.CurrentRow
            'If pobjSql.IsIncentiveCalculatedByDate(.Cells("ValidFrom").Value, .Cells("ValidTo").Value _  '^_^20220807 mark by 7643
            If pobjSql.IsIncentiveCalculatedByDate(.Cells("ValidFrom").Value, .Cells("TimeFrame").Value _  '^_^20220807 modi by 7643
                                                   , .Cells("ShortName").Value) Then
                If MsgBox("Incentive for this customer will be recalculated! Do you want to continue?") Then

                    If Not frmIncentiveCalc.DeleteIncentiveCalc(pobjUser.Region, .Cells("ValidFrom").Value _
                                                                , .Cells("ValidTo").Value _
                                                            , .Cells("ShortName").Value) Then
                        MsgBox("Không xóa được Incentive. Đề nghị báo lỗi ngay!")
                        Exit Sub
                    End If

                    '^_^20220708 mark by 7643 -b-
                    'If Not frmIncentiveCalc.CalculateIncentive(pobjUser.Region, Year(.Cells("ValidFrom").Value) _
                    '                                           , Month(.Cells("ValidFrom").Value) _
                    '                                           , Month(.Cells("ValidTo").Value) _
                    '                                        , .Cells("ShortName").Value) Then
                    '    MsgBox("Không tính lại được Incentive. Đề nghị báo lỗi ngay!")
                    '    Exit Sub
                    'End If
                    '^_^20220708 mark by 7643 -e-
                    '^_^20220708 modi by 7643 -b-
                    For i = 0 To Year(.Cells("ValidTo").Value) - Year(.Cells("ValidFrom").Value)
                        mYear = Year(.Cells("ValidFrom").Value) + i
                        mMonthFrom = IIf(mYear = Year(.Cells("ValidFrom").Value), Month(.Cells("ValidFrom").Value), 1)
                        mMonthTo = IIf(mYear = Year(.Cells("ValidTo").Value), Month(.Cells("ValidTo").Value), 12)
                        If Not frmIncentiveCalc.CalculateIncentive(pobjUser.Region, mYear _
                                                               , mMonthFrom _
                                                               , mMonthTo _
                                                            , .Cells("ShortName").Value) Then
                            MsgBox("Không tính lại được Incentive. Đề nghị báo lỗi ngay!")
                            Exit Sub
                        End If
                    Next
                    '^_^20220708 modi by 7643 -e-
                Else
                    Exit Sub
                End If

            End If

            If .Cells("Status").Value = "--" Then
                lstQuerries.Add("update Data1A_IncentiveOffer set Status='OK'" _
                                          & ",ApprovedDate=getdate(),ApprovedBy='" & pobjUser.UserName _
                                          & "' where RecId=" & .Cells("RecId").Value)
                lstQuerries.Add("update Data1A_IncentiveOffer set Status='EX'" _
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
        If Not pobjUser.HasRight("Action", "Incentive", "ApproveOffer") Then
            MsgBox("You do not have right to take this action")
            Exit Sub
        End If
        With dgOffer.CurrentRow
            If .Cells("Status").Value = "--" Then
                pobjSql.ExecuteNonQuerry("update Data1A_IncentiveOffer set Status='RJ' where RecId=" & .Cells("RecId").Value)
            End If
            Search()
        End With
    End Sub

    Private Sub dgOffer_SelectionChanged(sender As Object, e As EventArgs) Handles dgOffer.SelectionChanged
        If dgOffer.RowCount > 0 Then
            pobjSql.LoadDataGridView(dgFormula, "select * from Data1a_IncentiveFormula where RecId in " _
                                     & "(Select VAL1 from DATA1A_MISC where CAT='OfferFormula' and Val='" _
                                     & dgOffer.CurrentRow.Cells("OfferId").Value & "') order by VND,Unit,ObjectTarget")
            dgFormula.Columns("VND").DefaultCellStyle.Format = "N0"
            lbkCopy2Others.Visible = True
            lbkCloneWzNewValidity.Visible = True
            lbkDelete.Visible = True
        End If
    End Sub

    Private Sub lbkCloneWzNewValidity_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkCloneWzNewValidity.LinkClicked

        With dgOffer.CurrentRow
            Dim frmCopy As New frmCloneWzNewValidity(.Cells("ShortName").Value)
            frmCopy.ShowDialog()
            If frmCopy.DialogResult = Windows.Forms.DialogResult.OK Then
                MsgBox("Done")
                Search()
            End If
        End With

    End Sub

    
End Class