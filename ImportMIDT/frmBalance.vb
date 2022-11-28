Public Class frmBalance
    Private mblFirstLoadCompleted As Boolean
    Private Sub frmBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadComboVal(cboShortName, "Select distinct ShortName as value" _
            & ",AccountNameGB as Display from Data1a_Customers where Status<>'XX'" _
            & " and Region='" & pobjUser.Region & "' order by AccountNameGB")

        Reset()
        Search()
        mblFirstLoadCompleted = True
    End Sub
    Private Function Reset() As Boolean
        cboShortName.SelectedIndex = -1
        cboStatus.SelectedIndex = 0
        cboView.SelectedIndex = 1
        cboFOP.SelectedIndex = -1
        Return True
    End Function

    Private Function Search() As Boolean
        Dim strQuerry As String = ""
        Select Case cboView.Text
            Case "LastBalance"
                strQuerry = "select b.ShortName,c.AccountNameGB,Sum(VND) as VND,b.Status" _
                    & " From DATA1A_Balance b" _
                    & " left join DATA1A_Customers c on b.ShortName=c.ShortName" _
                    & " And c.Status<>'XX'" _
                    & " where b.status='OK'" _
                    & " group by b.ShortName, b.status,c.AccountNameGB" _
                    & " order by b.ShortName"

            Case "Transactions"
                strQuerry = "select  b.RecId, b.ShortName,c.AccountNameGB" _
                    & ", VND,BookYear,BookMonth, FOP, TrxDate, Description, b.Status" _
                    & ", b.FstUser, b.LstUser, b.FstUpdate, b.LstUpdate,ChargeID" _
                    & " From DATA1A_Balance b" _
                    & " left join DATA1A_Customers c on b.ShortName=c.ShortName" _
                    & " And c.Status<>'XX'" _
                    & " left join Data1A_ProductCharges pc on b.ChargeId=pc.RecId" _
                    & " where b.status<>'XX'"

                If cboShortName.Text <> "" Then
                    strQuerry = strQuerry & " and b.ShortName='" & cboShortName.SelectedValue & "'"
                End If

                AddEqualConditionCombo(strQuerry, cboStatus, "b.Status")
                AddEqualConditionCombo(strQuerry, cboFOP)
                strQuerry = strQuerry & " order by b.ShortName,b.RecId"

        End Select
        pobjSql.LoadDataGridView(dgrBalance, strQuerry)
        dgrBalance.Columns("VND").DefaultCellStyle.Format = "#,###,##0"
        Return True
    End Function

    Private Sub lbkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkEdit.LinkClicked
        If dgrBalance.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Dim frmPayment As New frmPayment(dgrBalance.CurrentRow)
        If frmPayment.ShowDialog = DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub lbkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkNew.LinkClicked
        Dim frmPayment As New frmPayment()
        If frmPayment.ShowDialog = DialogResult.OK Then
            Search()

        End If
    End Sub

    Private Sub lbkSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSearch.LinkClicked
        Search()
    End Sub

    Private Sub lbkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkReset.LinkClicked
        Reset()
    End Sub

    Private Sub dgrBalance_SelectionChanged(sender As Object, e As EventArgs) Handles dgrBalance.SelectionChanged
        If cboView.Text = "LastBalance" Then
            lbkDelete.Visible = False
            lbkEdit.Visible = False
            lbkNew.Visible = False
        ElseIf Not dgrBalance.CurrentRow Is Nothing Then
            Try
                With dgrBalance.CurrentRow
                    If .Cells("Status").Value = "OK" _
                        AndAlso ("CSH_BTF").Contains(.Cells("FOP").Value) Then
                        lbkDelete.Visible = True
                        lbkEdit.Visible = True
                    Else
                        lbkDelete.Visible = False
                        lbkEdit.Visible = False
                    End If
                End With
            Catch ex As Exception

            End Try


        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        Dim lstQuerries As New List(Of String)

        If MsgBox("Delete by mistake?", vbYesNo) = MsgBoxResult.Yes Then
            Exit Sub
        End If
        lstQuerries.Add("Update DATA1A_Balance set Status='XX',LstUpdate=getdate(),LstUser='" _
                            & pobjUser.UserName & "' where Recid=" & dgrBalance.CurrentRow.Cells("RecId").Value)
        If dgrBalance.CurrentRow.Cells("ChargeId").Value > 0 Then
            lstQuerries.Add("Update Data1A_ProductCharges set Status='OK',LstUpdate=getdate(),LstUser='" _
                            & pobjUser.UserName & "' where Recid=" & dgrBalance.CurrentRow.Cells("RecId").Value)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unable to update")
        End If
    End Sub

    Private Sub lbkListCustomerNoBalance_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkListCustomerNoBalance.LinkClicked
        Dim tblCustomer As DataTable

        tblCustomer = pobjSql.GetDataTable("Select distinct p.ShortName,c.AccountNameGB" _
                            & " from Data1A_ProductCharges p" _
                            & " left join DATA1A_Customers c" _
                            & " on p.ShortName=c.ShortName" _
                            & " where p.Status='OK' AND C.Status='OK'" _
                            & " and p.ShortName not in (select distinct ShortName" _
                            & " from DATA1A_Balance where Status='OK' and fop='COF')" _
                            & " ORDER BY P.ShortName")
        Dim frmCustomers As New frmShowTableContent(tblCustomer, "Customers with No Balance")
        frmCustomers.ShowDialog()
    End Sub
End Class