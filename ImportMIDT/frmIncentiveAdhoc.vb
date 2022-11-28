Public Class frmIncentiveAdhoc

    Private Sub frmIncentiveAdhoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strRegion As String = IIf(pobjUser.City = "SGN", "South", "North")

        pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' order by ShortName")
        pobjSql.LoadCombo(cboPIC, "Select distinct PIC as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' order by PIC")
        Clear()
        Search()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Private Function Search(Optional blnFillRelatedRecord = False) As Boolean
        Dim strQryGetContactName = "case ContactId when 0 then '' else " _
                                   & "(select FullNameGB from Data1a_Contacts where status<>'XX' and ContactId=a.ContactId)" _
                                   & " end as ContactName"
        Dim strQuerry As String
        strQuerry = "Select c.PIC, a.RecId,a.OldIncentiveId,a.ShortName,a.ContactId," & strQryGetContactName _
                    & ",IncType,VND,a.Status,BookYear,CalcQuarter,TimeFrame,Period,Reason" _
                    & ", a.FstUpdate, a.LstUpdate, a.FstUser, a.LstUser" _
                    & ", a.ApprovedBy, a.ApprovedDate,a.Unit" _
                    & " from [Data1A_IncentiveAdhoc] a " _
                    & " left join DATA1A_Customers c on a.ShortName=c.ShortName" _
                    & " where c.Status<>'XX'"


        If blnFillRelatedRecord Then
            Dim lstRecordIds As New List(Of String)
            Dim strFilterByIds As String
            lstRecordIds.Add(dgAdhoc.CurrentRow.Cells("RecId").Value)

            If dgAdhoc.CurrentRow.Cells("OldIncentiveId").Value <> 0 Then
                lstRecordIds.Add(dgAdhoc.CurrentRow.Cells("OldIncentiveId").Value)
            End If
            strFilterByIds = "in (" & Join(lstRecordIds.ToArray, ",") & ")"
            strQuerry = strQuerry & "and (a.Recid " & strFilterByIds & " or a.OldIncentiveId " & strFilterByIds & ")"
        Else
            AddEqualConditionCombo(strQuerry, cboShortName)
            AddEqualConditionCombo(strQuerry, cboStatus, "a.Status")
            AddEqualConditionCombo(strQuerry, cboTimeFrame)
            AddEqualConditionCombo(strQuerry, cboBookYear)
            AddEqualConditionCombo(strQuerry, cboCalcQuarter)
            AddEqualConditionCombo(strQuerry, cboPeriod)

            If cboPIC.Text <> "" Then
                strQuerry = strQuerry & " and PIC='" & cboPIC.Text & "'"
            End If

        End If

        strQuerry = strQuerry & " order by a.ShortName,BookYear,TimeFrame,Period,a.Status"
        pobjSql.LoadDataGridView(dgAdhoc, strQuerry)
        dgAdhoc.Columns("VND").DefaultCellStyle.Format = "N0"
        Return True
    End Function
    Private Function Clear() As Boolean
        cboShortName.SelectedIndex = -1
        cboPIC.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboTimeFrame.SelectedIndex = -1
        cboBookYear.SelectedIndex = -1
        cboCalcQuarter.SelectedIndex = -1
        Return True
    End Function
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub lbkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkNew.LinkClicked
        Dim frmNewAdhoc As New frmIncentiveAdhocEdit
        If frmNewAdhoc.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If

    End Sub

    Private Sub lbkCopy2Others_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkCopy2Others.LinkClicked

    End Sub

    Private Sub lbkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkEdit.LinkClicked

        If dgAdhoc.CurrentRow.Cells("PIC").Value <> pobjUser.UserName _
            AndAlso Not pobjUser.HasRight("Incentive", "Action", "ApproveOffer") Then
            MsgBox("You have NO right to Edit this record")
            Exit Sub
        End If

        Dim frmNewAdhoc As New frmIncentiveAdhocEdit(dgAdhoc.CurrentRow)
        If frmNewAdhoc.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        Dim blnDelete As Boolean
        Dim strValidFrom As String
        Dim strValidTo As String

        If dgAdhoc.RowCount = 0 Then Exit Sub

        With dgAdhoc.CurrentRow
            If .Cells("PIC").Value <> pobjUser.UserName _
                AndAlso Not pobjUser.HasRight("Action", "Incentive", "ApproveOffer") Then
                MsgBox("You have NO right to delete ")
            End If

            Dim strQuerry As String = "update Data1A_IncentiveAdhoc set Status='XX', LstUpdate=Getdate(),LstUser='" _
                                    & pobjUser.UserName & "' where RecId=" & .Cells("RecId").Value
            Select Case .Cells("Status").Value
                Case "--", "RJ"
                    blnDelete = True
                    strQuerry = "Delete Data1A_IncentiveAdhoc where RecId=" & .Cells("RecId").Value
                Case "OK"
                    strQuerry = "update Data1A_IncentiveAdhoc set Status='XX', LstUpdate=Getdate(),LstUser='" _
                                    & pobjUser.UserName & "' where RecId=" & .Cells("RecId").Value
                    strValidFrom = CreateFromDate4Period(.Cells("BookYear").Value, .Cells("TimeFrame").Value, .Cells("Period").Value)
                    strValidTo = CreateToDate4Period(.Cells("BookYear").Value, .Cells("TimeFrame").Value, .Cells("Period").Value)
                    If pobjSql.IsIncentiveCalculated(strValidFrom, strValidTo) Then
                        If MsgBox("Incentive HAS BEEN calculated. Do You want to delete?") = MsgBoxResult.Ok Then
                            blnDelete = True
                        Else
                            blnDelete = False
                        End If
                    Else
                        blnDelete = True
                    End If
            End Select

            If blnDelete AndAlso pobjSql.DeleteGridViewRow(dgAdhoc, strQuerry) Then
                MsgBox("Deletion completed")
            Else
                Exit Sub
            End If

            Search()
        End With
    End Sub

    Private Sub lbkApprove_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkApprove.LinkClicked
        Dim lstQuerries As New List(Of String)
        If Not pobjUser.HasRight("Action", "Incentive", "ApproveOffer") Then
            MsgBox("You do not have right to take this action")
            Exit Sub
        End If
        With dgAdhoc.CurrentRow
            If .Cells("Status").Value = "--" Then
                lstQuerries.Add("update Data1A_IncentiveAdhoc set Status='OK'" _
                                          & ",ApprovedDate=getdate(),ApprovedBy='" & pobjUser.UserName _
                                          & "' where RecId=" & .Cells("RecId").Value)
                If .Cells("OldIncentiveId").Value <> 0 Then
                    lstQuerries.Add("update Data1A_IncentiveAdhoc set Status='XX'" _
                                          & ",LstUpdate=getdate() where RecId=" & .Cells("OldIncentiveId").Value)
                End If
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
        With dgAdhoc.CurrentRow
            If .Cells("Status").Value = "--" Then
                pobjSql.ExecuteNonQuerry("update Data1A_IncentiveAdhoc set Status='RJ' where RecId=" & .Cells("RecId").Value)
            End If
            Search()
        End With
    End Sub


    Private Sub dgAdhoc_SelectionChanged(sender As Object, e As EventArgs) Handles dgAdhoc.SelectionChanged
        If dgAdhoc.RowCount > 0 Then

            Select Case dgAdhoc.CurrentRow.Cells("Status").Value
                Case "XX"
                    EnableDisableEdit(False)
                Case Else
                    EnableDisableEdit(True)
            End Select
        End If
    End Sub
    Private Sub EnableDisableEdit(blnEnable As Boolean)
        lbkApprove.Enabled = blnEnable
        lbkReject.Enabled = blnEnable
        lbkEdit.Enabled = blnEnable
    End Sub

    Private Sub lbkFilterRelatedRecords_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkFilterRelatedRecords.LinkClicked
        Search(True)
    End Sub
End Class