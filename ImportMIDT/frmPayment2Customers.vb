Public Class frmPayment2Customers
    Private mblFirstLoadCompleted As Boolean
    Private Sub frmProductChargeFollowUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadComboVal(cboShortName, "Select distinct p.ShortName as value" _
            & ",c.AccountNameGB as Display from  Data1a_ProductCharges p " _
            & " left join Data1a_Customers c on c.ShortName=p.ShortName and c.Status<>'XX'" _
            & " order by AccountNameGB")

        Reset()
        mblFirstLoadCompleted = True
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "select p.RecId,p.ShortName,AccountNameGB,Object" _
            & ",unit,TimeFrame,Period,VND,CalcYear,CalcQuarter" _
            & ",p.Status,PaidDate,PaidBy" _
            & " from Data1A_IncentiveCalc p " _
            & " left join Data1a_Customers c on c.ShortName=p.ShortName And c.Status<>'XX'" _
            & " where p.Status<>'XX'"

        If cboShortName.Text <> "" Then
            strQuerry = strQuerry & " and p.ShortName='" & cboShortName.SelectedValue & "'"
        End If

        AddEqualConditionCombo(strQuerry, cboObject)
        AddEqualConditionCombo(strQuerry, cboBookYear)
        AddEqualConditionCombo(strQuerry, cboTimeFrame)
        AddEqualConditionCombo(strQuerry, cboStatus, "p.Status")
        strQuerry = strQuerry & " order by AccountNameGB,CalcYear,CalcQuarter"

        pobjSql.LoadDataGridView(dgrIncentives, strQuerry)
        dgrIncentives.Columns("RecId").Width = 40
        dgrIncentives.Columns("Object").Width = 60
        dgrIncentives.Columns("Unit").Width = 60
        dgrIncentives.Columns("TimeFrame").Width = 70
        dgrIncentives.Columns("Period").Width = 40
        dgrIncentives.Columns("AccountNameGB").Width = 140
        dgrIncentives.Columns("VND").Width = 80
        dgrIncentives.Columns("CalcYear").Width = 60
        dgrIncentives.Columns("CalcQuarter").Width = 60
        dgrIncentives.Columns("Status").Width = 40
        lblRecordCount.Text = dgrIncentives.Rows.Count & " records"
        Return True
    End Function

    Private Sub lbkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkReset.LinkClicked
        Reset()
    End Sub
    Private Sub Reset()
        cboShortName.SelectedIndex = -1
        cboObject.SelectedIndex = -1
        cboBookYear.SelectedIndex = -1
        cboTimeFrame.SelectedIndex = -1
        cboQuarter.SelectedIndex = -1
        cboUnit.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
    End Sub
    Private Sub cboShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged _
        , cboObject.SelectedIndexChanged, cboStatus.SelectedIndexChanged _
        , cboBookYear.SelectedIndexChanged, cboTimeFrame.SelectedIndexChanged
        If mblFirstLoadCompleted Then
            Search()
            'lblLastBalance.Text = "Last Balance:" & GetLastBalance(cboShortName.SelectedValue).ToString
            'If lblLastBalance.Text.Contains("-") Then
            '    lblLastBalance.ForeColor = Color.Red
            'End If
        End If

    End Sub
    Private Function GetLastBalance(strCustShortName As String) As Decimal
        'Dim decResidualAmt As Decimal = pobjSql.GetScalarAsDecimal("select Sum(VND) " _
        '            & " From DATA1A_Balance " _
        '            & " where status='OK' and ShortName='" & strCustShortName & "'")
        'Dim decUnPaid As Decimal = pobjSql.GetScalarAsDecimal("select Sum(Amount) " _
        '            & " From [Data1A_ProductCharges] " _
        '            & " where status='OK' and ShortName='" & strCustShortName & "'")

        'Return decResidualAmt - decUnPaid
    End Function


    Private Sub dgrIncentives_SelectionChanged(sender As Object, e As EventArgs) Handles dgrIncentives.SelectionChanged
        If dgrIncentives.CurrentRow Is Nothing Then
            lbkSetPaidDate.Visible = False
        Else
            Select Case dgrIncentives.CurrentRow.Cells("Status").Value
                Case "OK"
                    lbkSetPaidDate.Visible = True
                    lbkSetAsUnPaid.Visible = False
                Case "RR"
                    lbkSetPaidDate.Visible = False
                    lbkSetAsUnPaid.Visible = True
                Case Else
                    lbkSetPaidDate.Visible = False
                    lbkSetAsUnPaid.Visible = False
            End Select
        End If
    End Sub
    Private Sub lbkSetPaidDate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSetPaidDate.LinkClicked
        Dim lstQuerries As New List(Of String)
        With dgrIncentives.CurrentRow
            lstQuerries.Add("Update [Data1A_IncentiveCalc] set Status='RR'" _
                        & ",PaidDate=getdate(),PaidBy='" & pobjUser.UserName _
                        & "',AccUser='" & pobjUser.UserName & "' where RecId=" & .Cells("RecId").Value)
        End With

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unable to update Payment")
        End If
    End Sub
    Private Sub lbkSetAsUnPaid_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSetAsUnPaid.LinkClicked
        Dim lstQuerries As New List(Of String)
        If txtReason.Text = "" Then
            MsgBox("You must input Reason to set a record as Unpaid!")
            Exit Sub
        End If
        With dgrIncentives.CurrentRow
            lstQuerries.Add("Update [Data1A_IncentiveCalc] set Status='OK'" _
                        & ",PaidDate=NULL,PaidBy='" _
                        & "',AccUser='" & pobjUser.UserName & "' where RecId=" & .Cells("RecId").Value)
            lstQuerries.Add("insert into ActionLog (TableName, ActionBy, doWhat, F1, F2, City)" _
                            & " values ('Data1A_IncentiveCalc','" & pobjUser.UserName & "','SetAsUnPaid','" _
                            & .Cells("RecId").Value & "','" & txtReason.Text & "','" & pobjUser.City & "')")
        End With

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unable to reset record as UnPaid")
        End If

    End Sub

    Private Sub lbkSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSearch.LinkClicked
        Search()
    End Sub
End Class