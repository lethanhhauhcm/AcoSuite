Public Class frmAtcOfferEdit
    Public Sub New()
        Dim mSQL As String

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mSQL = String.Format("select RecID value,ShortName Display from DATA1A_Customers where Status='OK' and Region='{0}' order by ShortName", {pobjUser.Region})
        pobjSql.LoadComboVal(cboCustomer, mSQL)
        pobjSql.LoadListboxVal(lstCustomer, mSQL)
    End Sub

    Private Sub txtExcessiveTrxPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExcessiveTrxPrice.KeyPress, txtRefundTrxPrice.KeyPress, txtInvolTrxPrice.KeyPress, txtReissueTktPrice.KeyPress
        PressInteger(e)
    End Sub

    Private Sub txtExcessiveTrxPrice_Validated(sender As Object, e As EventArgs) Handles txtExcessiveTrxPrice.Validated, txtReissueTktPrice.Validated, txtRefundTrxPrice.Validated, txtInvolTrxPrice.Validated
        If CType(sender, TextBox).Text = "" Then sender.text = "0"
    End Sub

    Private Sub dgvAtcOfferDetail_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvAtcOfferDetail.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf txtExcessiveTrxPrice_KeyPress
    End Sub

    Private Sub dgvAtcOfferDetail_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAtcOfferDetail.CellValidated
        If CStr(CType(sender, DataGridView).CurrentCell.Value) = "" Then dgvAtcOfferDetail.CurrentCell.Value = "0"
    End Sub

    Private Sub llbSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSave.LinkClicked
        Dim mAtcOfferPara(), mAtcOfferDetailPara(), mUpdate, mWhere, mEffDate, mExpDate As String
        Dim i, mDaysInMonth, j, mAtcOfferID As Integer
        Dim mLstCust As New List(Of String)
        Dim mLstAtcOffer As New List(Of Integer)

        'Check
        If Format(dtpExpDate.Value, "yyyyMM") < Format(dtpEffDate.Value, "yyyyMM") Then
            MsgBox("ExpDate must be greater than or equal EffDate!")
            Exit Sub
        End If

        If Not lstCustomer.Visible Then
            mLstCust.Add(cboCustomer.SelectedValue & vbLf & cboCustomer.Text)
        Else
            For i = 0 To lstCustomer.SelectedItems.Count - 1
                mLstCust.Add(lstCustomer.SelectedItems(i)("Value") & vbLf & lstCustomer.SelectedItems(i)("Display"))
            Next
        End If

        mEffDate = Format(dtpEffDate.Value, "yyyyMM01")
        mDaysInMonth = Date.DaysInMonth(dtpExpDate.Value.Year, dtpExpDate.Value.Month)
        mExpDate = Format(dtpExpDate.Value, "yyyyMM" & mDaysInMonth)

        For i = 0 To mLstCust.Count - 1
            mWhere = String.Format("Status='OK' and CustID={0} and '{1}'<=ExpDate and EffDate<='{2}' and RecID<>{3}",
                                   {Split(mLstCust(i), vbLf)(0), mEffDate, mExpDate, txtRecID.Text})
            If ScalarToInt("DATA1A_AtcOffer", "RecID", mWhere, pobjSql.Connection) > 0 Then
                MsgBox(Split(mLstCust(i), vbLf)(1) & " AtcOffer is duplicate!")
                Exit Sub
            End If
        Next

        BeginTrans()
        Try
            If txtRecID.Text = 0 Then
                ReDim mAtcOfferPara(10)
                For i = 0 To mLstCust.Count - 1
                    'Insert AtcOffer
                    mAtcOfferPara(0) = Split(mLstCust(i), vbLf)(0)
                    mAtcOfferPara(1) = mEffDate
                    mAtcOfferPara(2) = mExpDate
                    mAtcOfferPara(3) = txtExcessiveTrxPrice.Text
                    mAtcOfferPara(4) = txtRefundTrxPrice.Text
                    mAtcOfferPara(5) = txtInvolTrxPrice.Text
                    mAtcOfferPara(6) = txtReissueTktPrice.Text
                    mAtcOfferPara(7) = pobjUser.City
                    mAtcOfferPara(8) = Format(Now, "yyyyMMdd hh:mm:ss")
                    mAtcOfferPara(9) = pobjUser.UserName
                    cmd.CommandText = String.Format("insert into DATA1A_AtcOffer(CustID,EffDate,ExpDate,ExcessiveTrxPrice,RefundTrxPrice,InvolTrxPrice," &
                                                        "ReissueTktPrice,City,FstUpdate,FstUser) " &
                                                    "values({0},'{1}','{2}',{3},{4},{5},{6},'{7}','{8}','{9}')", mAtcOfferPara)
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "select SCOPE_IDENTITY()"
                    mAtcOfferID = cmd.ExecuteScalar

                    For j = 0 To dgvAtcOfferDetail.Rows.Count - 2
                        InsertAtcOfferDetail(mAtcOfferID, j, mAtcOfferPara(8))
                    Next
                Next
            Else
                'Update AtcOffer
                ReDim mAtcOfferPara(9)
                mAtcOfferPara(0) = mEffDate
                mAtcOfferPara(1) = mExpDate
                mAtcOfferPara(2) = txtExcessiveTrxPrice.Text
                mAtcOfferPara(3) = txtRefundTrxPrice.Text
                mAtcOfferPara(4) = txtInvolTrxPrice.Text
                mAtcOfferPara(5) = txtReissueTktPrice.Text
                mAtcOfferPara(6) = Format(Now, "yyyyMMdd hh:mm:ss")
                mAtcOfferPara(7) = pobjUser.UserName
                mAtcOfferPara(8) = txtRecID.Text
                cmd.CommandText = String.Format("update DATA1A_AtcOffer " &
                                                "set EffDate='{0}',ExpDate='{1}',ExcessiveTrxPrice={2},RefundTrxPrice={3},InvolTrxPrice={4},ReissueTktPrice={5}," &
                                                    "LstUpdate='{6}',LstUser='{7}' " &
                                                "where RecID={8}", mAtcOfferPara)
                cmd.ExecuteNonQuery()

                'Updat AtcOfferDetail
                ReDim mAtcOfferDetailPara(3)
                mAtcOfferDetailPara(0) = mAtcOfferPara(6)
                mAtcOfferDetailPara(1) = mAtcOfferPara(7)
                mAtcOfferDetailPara(2) = mAtcOfferPara(8)
                cmd.CommandText = String.Format("update DATA1A_AtcOfferDetail set LstUpdate='{0}',LstUser='{1}',Status='XX' where AtcOfferID={2}",
                                                mAtcOfferDetailPara)
                cmd.ExecuteNonQuery()

                For i = 0 To dgvAtcOfferDetail.Rows.Count - 2
                    If dgvAtcOfferDetail.Rows(i).Cells("RecID").Value = 0 Then
                        InsertAtcOfferDetail(mAtcOfferPara(8), i, mAtcOfferPara(6))
                    Else
                        'Update AtcOfferDetail
                        ReDim mAtcOfferDetailPara(5)
                        mAtcOfferDetailPara(0) = CInt(dgvAtcOfferDetail.Rows(i).Cells("BookingRequest").Value)
                        mAtcOfferDetailPara(1) = CInt(dgvAtcOfferDetail.Rows(i).Cells("FreeTicket").Value)
                        mAtcOfferDetailPara(2) = mAtcOfferPara(6)
                        mAtcOfferDetailPara(3) = mAtcOfferPara(7)
                        mAtcOfferDetailPara(4) = CInt(dgvAtcOfferDetail.Rows(i).Cells("RecID").Value)

                        cmd.CommandText = String.Format("update DATA1A_AtcOfferDetail " &
                                                        "set BookingRequest={0},FreeTicket={1},LstUpdate='{2}',LstUser='{3}',Status='OK' " &
                                                        "where RecID={4}", mAtcOfferDetailPara)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            CommitTrans()
        Catch ex As Exception
            MsgBox(ex.Message)
            RollbackTrans()
            Exit Sub
        End Try

        DialogResult = DialogResult.OK
    End Sub

    Private Sub InsertAtcOfferDetail(xAtcOfferID As Integer, xIndex As Integer, xDate As String)
        Dim mAtcOfferDetailPara() As String

        ReDim mAtcOfferDetailPara(6)
        mAtcOfferDetailPara(0) = xAtcOfferID
        mAtcOfferDetailPara(1) = CInt(dgvAtcOfferDetail.Rows(xIndex).Cells("BookingRequest").Value)
        mAtcOfferDetailPara(2) = CInt(dgvAtcOfferDetail.Rows(xIndex).Cells("FreeTicket").Value)
        mAtcOfferDetailPara(3) = pobjUser.City
        mAtcOfferDetailPara(4) = xDate
        mAtcOfferDetailPara(5) = pobjUser.UserName
        cmd.CommandText = String.Format("insert into DATA1A_AtcOfferDetail(AtcOfferID,BookingRequest,FreeTicket,City,FstUpdate,FstUser) " &
                                        "values({0},{1},{2},'{3}','{4}','{5}')", mAtcOfferDetailPara)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub dgvAtcOfferDetail_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvAtcOfferDetail.RowValidating
        Dim i As Integer

        If dgvAtcOfferDetail.CurrentRow.IsNewRow Then Exit Sub

        For i = 0 To dgvAtcOfferDetail.Rows.Count - 2
            If dgvAtcOfferDetail.CurrentRow.Index = i Then Exit For

            If CInt(dgvAtcOfferDetail.Rows(i).Cells("BookingRequest").Value) = CInt(dgvAtcOfferDetail.CurrentRow.Cells("BookingRequest").Value) Then
                MsgBox("BookingRequest is duplicate!")
                e.Cancel = True
                Exit For
            End If
        Next
    End Sub

    Private Sub dgvAtcOfferDetail_Validated(sender As Object, e As EventArgs) Handles dgvAtcOfferDetail.Validated
        dgvAtcOfferDetail.Sort(dgvAtcOfferDetail.Columns("BookingRequest"), ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub cboCustomer_Validated(sender As Object, e As EventArgs) Handles cboCustomer.Validated
        cboValidated(sender)
    End Sub

    Private Sub dgvAtcOfferDetail_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgvAtcOfferDetail.SortCompare
        dgvIntSort(e)
    End Sub
End Class