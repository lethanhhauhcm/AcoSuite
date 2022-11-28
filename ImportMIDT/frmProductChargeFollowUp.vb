Public Class frmProductChargeFollowUp
    Private mblFirstLoadCompleted As Boolean
    Private Sub frmProductChargeFollowUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadComboVal(cboShortName, "Select distinct p.ShortName as value" _
            & ",c.AccountNameGB as Display from  Data1a_ProductCharges p " _
            & " left join Data1a_Customers c on c.ShortName=p.ShortName and c.Status<>'XX'" _
            & " order by AccountNameGB")
        pobjSql.LoadCombo(cboProductName, "Select distinct ProductName as value from Data1a_ProductCharges" _
                          & " order by ProductName")
        Reset()
        Search()
        mblFirstLoadCompleted = True
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "select p.RecId,p.ShortName,AccountNameGB" _
            & ", BookMonth, BookYear, Cur, Amount, Vat" _
            & ", p.ProductName, ProductCount,PaidDate,p.Status, OfferID, PriceID" _
            & " from Data1A_ProductCharges p " _
            & " left join Data1a_Customers c on c.ShortName=p.ShortName And c.Status<>'XX'" _
            & " where p.Status<>'XX'"

        If cboShortName.Text <> "" Then
            strQuerry = strQuerry & " and p.ShortName='" & cboShortName.SelectedValue & "'"
        End If

        AddEqualConditionCombo(strQuerry, cboProductName)
        AddEqualConditionCombo(strQuerry, cboBookYear)
        AddEqualConditionCombo(strQuerry, cboBookMonth)
        AddEqualConditionCombo(strQuerry, cboStatus, "p.Status")
        strQuerry = strQuerry & " order by AccountNameGB,BookYear,BookMonth"

        pobjSql.LoadDataGridView(dgrProductCharges, strQuerry)
        dgrProductCharges.Columns("RecId").Width = 40
        dgrProductCharges.Columns("ProductCount").Width = 40
        dgrProductCharges.Columns("AccountNameGB").Width = 140
        dgrProductCharges.Columns("BookMonth").Width = 60
        dgrProductCharges.Columns("BookYear").Width = 60
        dgrProductCharges.Columns("Cur").Width = 40
        dgrProductCharges.Columns("Amount").Width = 80
        dgrProductCharges.Columns("VAT").Width = 60
        lblRecordCount.Text = dgrProductCharges.Rows.Count & " records"
        Return True
    End Function

    Private Sub lbkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkReset.LinkClicked
        Reset()
    End Sub
    Private Sub Reset()
        cboShortName.SelectedIndex = -1
        cboProductName.SelectedIndex = -1
        cboBookYear.SelectedIndex = -1
        cboBookMonth.SelectedIndex = -1
        cboStatus.SelectedIndex = 0
    End Sub
    Private Sub cboShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged _
        , cboProductName.SelectedIndexChanged, cboStatus.SelectedIndexChanged _
        , cboBookYear.SelectedIndexChanged, cboBookMonth.SelectedIndexChanged
        If mblFirstLoadCompleted Then
            Search()
            lblLastBalance.Text = "Last Balance:" & GetLastBalance(cboShortName.SelectedValue).ToString
            'If lblLastBalance.Text.Contains("-") Then
            '    lblLastBalance.ForeColor = Color.Red
            'End If
        End If

    End Sub
    Private Function GetLastBalance(strCustShortName As String) As Decimal
        Dim decResidualAmt As Decimal = pobjSql.GetScalarAsDecimal("select Sum(VND) " _
                    & " From DATA1A_Balance " _
                    & " where status='OK' and ShortName='" & strCustShortName & "'")
        Dim decUnPaid As Decimal = pobjSql.GetScalarAsDecimal("select Sum(Amount) " _
                    & " From [Data1A_ProductCharges] " _
                    & " where status='OK' and ShortName='" & strCustShortName & "'")

        Return decResidualAmt - decUnPaid
    End Function
    Private Sub lbkSetPaidDate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSetPaidDate.LinkClicked
        Dim lstQuerries As New List(Of String)
        With dgrProductCharges.CurrentRow
            If .Cells("Amount").Value + .Cells("VAT").Value _
                > pobjSql.GetScalarAsDecimal("Select isnull(sum(VND),0) from Data1a_Balance" _
                                            & " where Status='OK' and ShortName='" _
                                            & .Cells("ShortName").Value & "'") Then
                MsgBox("Insufficient Balance")
                Exit Sub
            End If
            lstQuerries.Add("Update [Data1A_ProductCharges] set Status='RR'" _
                        & ",PaidDate=getdate(),LstUser='" & pobjUser.UserName _
                        & "',LstUpdate=getdate() where RecId=" & .Cells("RecId").Value)

            lstQuerries.Add("insert into DATA1A_Balance (ShortName, VND, FOP, TrxDate" _
                        & ", Description, Status, FstUser,ChargeId) values ('" & .Cells("ShortName").Value _
                        & "', -" & (.Cells("Amount").Value + .Cells("VAT").Value) _
                        & ",'---',getdate()" _
                        & ",'AutoDeduct','OK','" & pobjUser.UserName _
                        & "'," & .Cells("RecId").Value & ")")
        End With

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unable to update")
        End If
    End Sub


    Private Sub dgrProductCharges_SelectionChanged(sender As Object, e As EventArgs) Handles dgrProductCharges.SelectionChanged
        If dgrProductCharges.CurrentRow Is Nothing Then
            lbkSetPaidDate.Visible = False
        ElseIf dgrProductCharges.CurrentRow.Cells("Status").Value = "OK" Then
            lbkSetPaidDate.Visible = True
        Else
            lbkSetPaidDate.Visible = False
        End If
    End Sub

    Private Sub lbkAutoSetAsPaid_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAutoSetAsPaid.LinkClicked
        Dim lstQuerries As New List(Of String)
        Dim tblPendingCharges As DataTable
        Dim strShortName As String = String.Empty
        Dim decBalance As Decimal
        Dim decChargeAnt As Decimal

        Dim strQuerry As String = "select b.VND, p.* from Data1A_ProductCharges p" _
            & " left join (select ShortName, sum(vnd) as VND" _
            & " From DATA1A_Balance " _
            & " where status='OK' " _
            & " group by ShortName having sum(vnd)>0) b on p.ShortName=b.ShortName" _
            & " where b.VND IS NOT NULL AND p.Status='OK'" _
            & " order by ShortName,BookYear,BookMonth"
        tblPendingCharges = pobjSql.GetDataTable(strQuerry)
        For Each objRow As DataRow In tblPendingCharges.Rows
            If objRow("ShortName") <> strShortName Then
                strShortName = objRow("ShortName")
                decBalance = objRow("VND")
            End If
            decChargeAnt = objRow("Amount") + objRow("VAT")
            If decBalance >= decChargeAnt Then
                lstQuerries.AddRange(pobjSql.CreateBalanceQuerries(objRow("RecId") _
                                        , decChargeAnt, objRow("ShortName")))
                decBalance = decBalance - decChargeAnt
            Else
                Continue For
            End If
        Next
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unable to update")
        End If
    End Sub
End Class