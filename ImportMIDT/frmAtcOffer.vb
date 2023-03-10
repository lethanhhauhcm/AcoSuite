'^_^20221219 add by 7643
Public Class frmAtcOffer
    Private Sub frmAtcOffer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mSQL As String

        mSQL = String.Format("select RecID value,ShortName Display from DATA1A_Customers where Status='OK' and Region='{0}' order by ShortName", {pobjUser.Region})
        pobjSql.LoadComboVal(cboCustomer, mSQL)
        cboCustomer.SelectedIndex = -1

        dtpEffDateFrom.Value = Format(Now, "Jan yyyy")
        dtpEffDateTo.Value = Format(Now, "Dec yyyy")
        LoadAtcOffer()
    End Sub

    Private Sub LoadAtcOffer()
        Dim mSQL As String
        Dim mDayInMonth As Integer

        mSQL = String.Format("select aof.RecID,cus.ShortName,format(aof.EffDate,'MMM yyyy') EffDate,format(aof.ExpDate,'MMM yyyy') ExpDate,aof.ExcessiveTrxPrice," &
                                "aof.RefundTrxPrice,aof.InvolTrxPrice,aof.ReissueTktPrice,format(aof.FstUpdate,'dd MMM yyyy hh:mm:ss') FstUpdate,aof.FstUser," &
                                "format(aof.LstUpdate,'dd MMM yyyy hh:mm:ss') LstUpdate,aof.LstUser,aof.CustID Customer " &
                             "from DATA1A_AtcOffer aof inner join DATA1A_Customers cus on aof.CustID=cus.RecID And cus.Status='OK' and cus.Region='{0}' " &
                             "where aof.Status='OK' and aof.City='{1}' ", {pobjUser.Region, pobjUser.City})
        If cboCustomer.SelectedIndex >= 0 Then mSQL = mSQL & String.Format("and aof.CustID='{0}' ", {cboCustomer.SelectedValue})
        If dtpEffDateFrom.Checked Then mSQL = mSQL & String.Format("and aof.ExpDate>='{0}' ", {Format(dtpEffDateFrom.Value, "yyyyMMdd")})
        If dtpEffDateTo.Checked Then
            mDayInMonth = Date.DaysInMonth(dtpEffDateTo.Value.Year, dtpEffDateTo.Value.Month)
            mSQL = mSQL & String.Format("and aof.EffDate<='{0}' ", {Format(dtpEffDateTo.Value, "yyyyMM" & mDayInMonth)})
        End If
        mSQL = mSQL & "order by ShortName,EffDate,ExpDate "
        pobjSql.LoadDataGridView(dgvAtcOffer, mSQL)

        'Format
        dgvAtcOffer.Columns("RecID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAtcOffer.Columns("Customer").Visible = False
        FormatDgvNumber(dgvAtcOffer, {"ExcessiveTrxPrice", "RefundTrxPrice", "InvolTrxPrice", "ReissueTktPrice"})
    End Sub

    Private Sub dgvAtcOffer_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAtcOffer.SelectionChanged
        If dgvAtcOffer.CurrentRow Is Nothing Then Exit Sub

        LoadAtcOfferDetail(dgvAtcOffer.CurrentRow.Cells("RecID").Value)
    End Sub

    Private Sub LoadAtcOfferDetail(xAtcOfferID As Integer)
        Dim mSQL As String

        mSQL = String.Format("select RecID,BookingRequest,FreeTicket,format(FstUpdate,'dd MMM yyyy hh:mm:ss') FstUpdate,FstUser," &
                                "format(LstUpdate,'dd MMM yyyy hh:mm:ss') LstUpdate,LstUser " &
                             "from DATA1A_AtcOfferDetail " &
                             "where AtcOfferID={0} And Status='OK' and City='{1}' " &
                             "order by BookingRequest", {xAtcOfferID, pobjUser.City})
        pobjSql.LoadDataGridView(dgvAtcOfferDetail, mSQL)

        'Format
        dgvAtcOfferDetail.Columns("RecID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        FormatDgvNumber(dgvAtcOfferDetail, {"BookingRequest", "FreeTicket"})
    End Sub

    Private Sub dgvAtcOffer_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvAtcOffer.DataSourceChanged
        Dim mAtcOfferID As Integer

        If dgvAtcOffer.Rows.Count > 0 Then
            mAtcOfferID = dgvAtcOffer.CurrentRow.Cells("RecID").Value

            llbEdit.Enabled = True
            llbDelete.Enabled = True
            llbCopy.Enabled = True
        Else
            llbEdit.Enabled = False
            llbDelete.Enabled = False
            llbCopy.Enabled = False
        End If
        LoadAtcOfferDetail(mAtcOfferID)
    End Sub

    Private Sub llbAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbAdd.LinkClicked
        Dim mAtcOfferEdit As New frmAtcOfferEdit

        If mAtcOfferEdit.ShowDialog(Me) = DialogResult.OK Then LoadAtcOffer()
    End Sub

    Private Sub llbFilter_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbFilter.LinkClicked
        LoadAtcOffer()
    End Sub

    Private Sub llbEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbEdit.LinkClicked
        Dim mAtcOfferEdit As New frmAtcOfferEdit

        If Not CheckAtcCalcPriceDetail() Then
            MsgBox("This AtcOffer has calculated price, can't edit!")
            Exit Sub
        End If

        DefaultControldvalue(mAtcOfferEdit, dgvAtcOffer, dgvAtcOfferDetail)
        mAtcOfferEdit.cboCustomer.Enabled = False
        If mAtcOfferEdit.ShowDialog() = DialogResult.OK Then LoadAtcOffer()
    End Sub

    Function CheckAtcCalcPriceDetail() As Boolean
        Dim mWhere As String

        mWhere = String.Format("CustID={0} and AtcOfferID={1} and Status='OK' and City='{2}'",
                               {dgvAtcOffer.CurrentRow.Cells("Customer").Value, dgvAtcOffer.CurrentRow.Cells("RecID").Value, pobjUser.City})
        If ScalarToInt("DATA1A_AtcCalcPriceDetail", "RecID", mWhere, pobjSql.Connection) <> 0 Then Return False

        Return True
    End Function

    Private Sub llbDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDelete.LinkClicked
        Dim mDate As String

        If MsgBox("Do you want delete this AtcOffer?", vbYesNo) = vbNo Then Exit Sub

        If Not CheckAtcCalcPriceDetail() Then
            MsgBox("This AtcOffer has calculated price, can't delete!")
            Exit Sub
        End If

        BeginTrans()
        Try
            mDate = Format(Now, "yyyyMMdd hh:mm:ss")
            cmd.CommandText = String.Format("update DATA1A_AtcOfferDetail set Status='XX',LstUpdate='{0}',LstUser='{1}' where AtcOfferID={2}",
                                            {mDate, pobjUser.UserName, dgvAtcOffer.CurrentRow.Cells("RecID").Value})
            cmd.ExecuteNonQuery()

            cmd.CommandText = String.Format("update DATA1A_AtcOffer set Status='XX',LstUpdate='{0}',LstUser='{1}' where RecID={2}",
                                            {mDate, pobjUser.UserName, dgvAtcOffer.CurrentRow.Cells("RecID").Value})
            cmd.ExecuteNonQuery()

            CommitTrans()
        Catch ex As Exception
            MsgBox(ex.Message)
            RollbackTrans()
            Exit Sub
        End Try

        LoadAtcOffer()
    End Sub

    Private Sub llbCopy_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCopy.LinkClicked
        Dim mAtcOfferEdit As New frmAtcOfferEdit
        Dim i As Integer

        DefaultControldvalue(mAtcOfferEdit, dgvAtcOffer, dgvAtcOfferDetail)
        mAtcOfferEdit.WindowState = FormWindowState.Maximized
        mAtcOfferEdit.txtRecID.Text = "0"
        mAtcOfferEdit.cboCustomer.Visible = False
        mAtcOfferEdit.lstCustomer.Visible = True
        For i = 0 To mAtcOfferEdit.dgvAtcOfferDetail.Rows.Count - 2
            mAtcOfferEdit.dgvAtcOfferDetail.Rows(i).Cells("RecID").Value = 0
        Next
        If mAtcOfferEdit.ShowDialog() = DialogResult.OK Then LoadAtcOffer()
    End Sub

    Private Sub llbReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbReset.LinkClicked
        cboCustomer.SelectedIndex = -1
        dtpEffDateFrom.Value = Now
        dtpEffDateTo.Value = Now
        LoadAtcOffer()
    End Sub

    Private Sub cboCustomer_Validated(sender As Object, e As EventArgs) Handles cboCustomer.Validated
        cboValidated(cboCustomer)
    End Sub
End Class