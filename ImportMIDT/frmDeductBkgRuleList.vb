Public Class frmDeductBkgRuleList
    Private mblnFirstLoadCompleted As Boolean
    Private Sub frmDeductBkgRuleList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear()
        Search()
        mblnFirstLoadCompleted = True
    End Sub
    Private Function Clear() As Boolean
        txtOffcId.Text = ""
        txtSignIn.Text = ""
        cboStatus.Text = "OK"
        cboDateType.SelectedIndex = -1
        Return True
    End Function
    Private Function Search() As Boolean
        '^_^20221031 mark by 7643 -b-
        'Dim strQuerry As String = "Select RecID, convert (varchar,FromDate,106) as FromDate" _
        '    & ",convert(varchar,ToDate,106) as ToDate" _
        '    & ", Pct, Status, Fstuser, FstUpdate, LstUser, LstUpdate " _
        '    & " from Data1a_DeductBkgRule where Region='" & pobjUser.Region & "'"
        '^_^20221031 mark by 7643 -e-
        '^_^20221031 modi by 7643 -b-
        Dim strQuerry As String = "Select RecID, convert (varchar,FromDate,106) as FromDate" _
            & ",convert(varchar,ToDate,106) as ToDate" _
            & ", Pct, Segment, TimeFrame, Status, Fstuser, FstUpdate, LstUser, LstUpdate " _
            & " from Data1a_DeductBkgRule where Region='" & pobjUser.Region & "'"
        '^_^20221031 modi by 7643 -e-

        AddEqualConditionCombo(strQuerry, cboStatus)

        Select Case cboDateType.Text
            Case "ValidOn"
                strQuerry = strQuerry & " and '" & CreateFromDate(dtpValidDate.Value) _
                    & "' between FromDate and ToDate"
            Case "ValidFrom"
                strQuerry = strQuerry & " and '" & CreateFromDate(dtpValidDate.Value) _
                    & "'= FromDate"
            Case "ValidTo"
                strQuerry = strQuerry & " and '" & CreateToDate(dtpValidDate.Value) _
                    & "' = ToDate"
        End Select

        If txtOffcId.Text <> "" Then
            strQuerry = strQuerry & " and RecId in (Select DeductionId" _
                & " from Data1a_DeductBkgRule_D where OffcId like '%" _
                & txtOffcId.Text & "%')"
        End If

        If txtSignIn.Text <> "" Then
            strQuerry = strQuerry & " and RecId in (Select DeductionId" _
                & " from Data1a_DeductBkgRule_D where SignIn like '%" _
                & txtSignIn.Text & "%')"
        End If

        pobjSql.LoadDataGridView(dgDeductionRule, strQuerry)
        dgDeductionRule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgDeductionRule.Columns("Pct").Width = 30
        dgDeductionRule.Columns("RecId").Width = 40
        Return True
    End Function
    Private Function CheckInputValues() As Boolean
        Return True
    End Function
    Private Sub lbkSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSearch.LinkClicked
        Search()
    End Sub

    Private Sub lbkClear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkClear.LinkClicked
        Clear()
    End Sub

    Private Sub dgDeductionRule_SelectionChanged(sender As Object, e As EventArgs) Handles dgDeductionRule.SelectionChanged
        If mblnFirstLoadCompleted Then
            With dgDeductionRule.CurrentRow
                Select Case .Cells("Status").Value
                    Case "EX", "XX"
                        lbkDelete.Visible = False
                        lbkEdit.Visible = False
                End Select
                pobjSql.LoadDataGridView(dgrOffcSignIn, "Select OffcId,SignIn from Data1a_DeductBkgRule_D" _
                                         & " where DeductionId=" & .Cells("RecId").Value)
            End With
        End If
    End Sub

    Private Sub lbkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkNew.LinkClicked
        Dim frmNew As New frmDeductBkgRuleEdit(True)
        If frmNew.ShowDialog = DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub lbkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkEdit.LinkClicked
        Dim frmEdit As New frmDeductBkgRuleEdit(False, dgDeductionRule.CurrentRow)
        If frmEdit.ShowDialog = DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        If CDate(pobjSql.GetScalarAsString("select top 1 convert" _
                                    & "(varchar,bookdate,106) from AllStatsSI" _
                                    & " order by BookDate desc")) _
                                    >= dgDeductionRule.CurrentRow.Cells("FromDate").Value Then

            MsgBox("Allstats Data had been loaded. Unable to delete")
            Exit Sub
        End If
        If pobjSql.DeleteGridViewRow(dgDeductionRule, "Update Data1a_DeductBkgRule" _
            & " set Status='XX',LstUpdate=GetDate(),LstUser='" _
            & pobjUser.UserName & "' where RecId=" _
            & dgDeductionRule.CurrentRow.Cells("RecId").Value) Then
            Search()
        End If

    End Sub

    Private Sub lbkClone_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkClone.LinkClicked
        Dim frmEdit As New frmDeductBkgRuleEdit(True, dgDeductionRule.CurrentRow)
        If frmEdit.ShowDialog = DialogResult.OK Then
            Search()
        End If
    End Sub
End Class