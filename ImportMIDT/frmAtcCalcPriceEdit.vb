Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmAtcCalcPriceEdit
    Public FReissueTicketPriceDetail As New List(Of String)
    Private FOCPMonth As Date

    Private Sub llbCalcPrice_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCalcPrice.LinkClicked
        If dgvAtcCalcPriceDetail.Rows.Count > 0 Then
            If MsgBox("This month had calculated,calculate again?", vbYesNo) = vbNo Then Exit Sub
        End If

        CalcPrice()
    End Sub

    Private Sub CalcPrice()
        Dim mSQL, mCPMonthFrom, mCPMonthTo As String
        Dim mReturn As New DataTable
        Dim i, j, mTotalExcessiveTrx, mTotalRefundTrx, mTotalInvolTrx, mTotalReissueTicket, mNumberOfTicket, mTotalFreeReissueTicket As Integer
        Dim mReissueAmount, mTotalExcessiveAmount, mTotalRefundAmount, mTotalInvolAmount, mTotalReissueAmount, mTotalAmount, mAmount As Double
        Dim mNumberCols As New List(Of String)

        mCPMonthFrom = Format(dtpCPMonth.Value, "yyyyMM01")
        mCPMonthTo = Format(dtpCPMonth.Value, "yyyyMM" & Date.DaysInMonth(dtpCPMonth.Value.Year, dtpCPMonth.Value.Month))
        mSQL = String.Format("select RecID,CustID,ShortName,AtcOfferID,case when STrx>ReissueTicket*10 then STrx-ReissueTicket*10 else 0 end ExcessiveTrx," &
                                "ExcessiveTrxPrice,case when STrx>ReissueTicket*10 then (STrx-ReissueTicket*10)*ExcessiveTrxPrice else 0 end ExcessiveAmount,RefundTrx," &
                                "RefundTrxPrice,RefundTrx*RefundTrxPrice RefundAmount,InvolTrx,InvolTrxPrice,InvolTrx*InvolTrxPrice InvolAmount,ReissueTicket," &
                                "ReissueAmount,Amount,ErrDesc,AtcCpCode " &
                             "from " &
                             "( " &
                                "select 0 RecID,cus.RecID CustID,cus.ShortName,isnull(aor.RecID,0) AtcOfferID,sum(atc2.Trx) STrx," &
                                    "count(distinct case when atc2.ProductCode in ('FRTRATM','FRTRATW') then atc2.Tkno else null end) ReissueTicket," &
                                    "isnull(aor.ExcessiveTrxPrice,0) ExcessiveTrxPrice," &
                                    "sum(case when atc2.ProductCode in ('FRTRATR','FRTRACR') then atc2.Trx else 0 end) RefundTrx," &
                                    "isnull(aor.RefundTrxPrice,0) RefundTrxPrice,sum(case when atc2.ProductCode='FRTRATN' then atc2.Trx else 0 end) InvolTrx," &
                                    "isnull(aor.InvolTrxPrice,0) InvolTrxPrice,0 ReissueAmount,0 Amount,'' ErrDesc," &
                                    "'ATC'+cus.ShortName+format(getdate(),'yyyyMMdd') AtcCpCode " &
                                "from DATA1A_ATC2 atc2 " &
                                    "inner join DATA1A_OIDs oid on atc2.OffcId=oid.OffcId And oid.Status='OK' " &
                                    "inner join DATA1A_Customers cus on oid.ShortName=cus.ShortName And cus.Status='OK' and Region='{0}' " &
                                    "left join DATA1A_AtcOffer aor on cus.RecID=aor.custID " &
                                        "And cast(atc2.TrxYear as varchar(4)) + cast(atc2.TrxMonth as varchar(2)) between " &
                                            "format(aor.EffDate,'yyyyMM') and format(aor.ExpDate,'yyyyMM') " &
                                        "And aor.Status='OK' and aor.City='{1}' " &
                                "where atc2.TrxDate between '{2}' and '{3}' " &
                                "group by cus.RecID,cus.ShortName,aor.RecID,aor.ExcessiveTrxPrice,aor.RefundTrxPrice,aor.InvolTrxPrice " &
                                ")a " &
                             "order by a.ShortName",
                             {pobjUser.Region, pobjUser.City, mCPMonthFrom, mCPMonthTo})
        pobjSql.LoadDataGridView(dgvAtcCalcPriceDetail, mSQL)

        dgvAtcCalcPriceDetail.Columns("CustID").Visible = False
        For i = 2 To 14
            mNumberCols.Add(dgvAtcCalcPriceDetail.Columns(i).Name)
        Next
        FormatNumber(dgvAtcCalcPriceDetail, mNumberCols)

        FReissueTicketPriceDetail.Clear()
        For i = 0 To dgvAtcCalcPriceDetail.Rows.Count - 1
            If dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveTrx").Value < 0 Then dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveTrx").Value = 0
            If dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveAmount").Value < 0 Then dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveAmount").Value = 0
            mReissueAmount = 0
            If dgvAtcCalcPriceDetail.Rows(i).Cells("AtcOfferID").Value = 0 Then
                dgvAtcCalcPriceDetail.Rows(i).Cells("ErrDesc").Value = "Do Not have AtcOffer data!"
            Else
                'mSQL = String.Format("select FromTheTicket,ToTheTicket,PricePerTicket " &
                '                     "from DATA1A_ReissueTicketPrice " &
                '                     "where AtcOfferID={0} And Status='OK' and City='{1}' " &
                '                     "order by FromTheTicket,ToTheTicket",
                '                     {dgvAtcCalcPriceDetail.Rows(i).Cells("AtcOfferID").Value, pobjUser.City})
                'mReturn = pobjSql.GetDataTable(mSQL)
                'If dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueTicket").Value > mReturn.Rows(mReturn.Rows.Count - 1)("ToTheTicket") Then
                '    dgvAtcCalcPriceDetail.Rows(i).Cells("ErrDesc").Value = "From the ReissueTicket " & mReturn.Rows(mReturn.Rows.Count - 1)("ToTheTicket") + 1 &
                '                                                            " do not have price!"
                'Else
                '    For j = 0 To mReturn.Rows.Count - 1
                '        If dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueTicket").Value < mReturn.Rows(j)("FromTheTicket") Then Exit For
                '        If dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueTicket").Value >= mReturn.Rows(j)("ToTheTicket") Then
                '            mNumberOfTicket = mReturn.Rows(j)("ToTheTicket") - mReturn.Rows(j)("FromTheTicket") + 1
                '        Else
                '            mNumberOfTicket = dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueTicket").Value - mReturn.Rows(j)("FromTheTicket") + 1
                '        End If

                '        mAmount = mNumberOfTicket * mReturn.Rows(j)("PricePerTicket")
                '        mReissueAmount = mReissueAmount + mAmount
                '        FReissueTicketPriceDetail.Add("0" & vbLf & dgvAtcCalcPriceDetail.Rows(i).Cells("CustID").Value & vbLf & mNumberOfTicket & vbLf &
                '                                      mReturn.Rows(j)("PricePerTicket") & vbLf & mAmount)
                '    Next
                'End If
            End If

            dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueAmount").Value = mReissueAmount
            dgvAtcCalcPriceDetail.Rows(i).Cells("Amount").Value = dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveAmount").Value +
                                                                  dgvAtcCalcPriceDetail.Rows(i).Cells("RefundAmount").Value +
                                                                  dgvAtcCalcPriceDetail.Rows(i).Cells("InvolAmount").Value +
                                                                  dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueAmount").Value

            mTotalExcessiveTrx = mTotalExcessiveTrx + dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveTrx").Value
            mTotalExcessiveAmount = mTotalExcessiveAmount + dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveAmount").Value
            mTotalRefundTrx = mTotalRefundTrx + dgvAtcCalcPriceDetail.Rows(i).Cells("RefundTrx").Value
            mTotalRefundAmount = mTotalRefundAmount + dgvAtcCalcPriceDetail.Rows(i).Cells("RefundAmount").Value
            mTotalInvolTrx = mTotalInvolTrx + dgvAtcCalcPriceDetail.Rows(i).Cells("InvolTrx").Value
            mTotalInvolAmount = mTotalInvolAmount + dgvAtcCalcPriceDetail.Rows(i).Cells("InvolAmount").Value
            mTotalInvolTrx = mTotalInvolTrx + dgvAtcCalcPriceDetail.Rows(i).Cells("InvolTrx").Value
            mTotalInvolAmount = mTotalInvolAmount + dgvAtcCalcPriceDetail.Rows(i).Cells("InvolAmount").Value
            mTotalReissueTicket = mTotalReissueTicket + dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueTicket").Value
            mTotalReissueAmount = mTotalReissueAmount + dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueAmount").Value
            mTotalAmount = mTotalAmount + dgvAtcCalcPriceDetail.Rows(i).Cells("Amount").Value
        Next

        txtTotalExcessiveTrx.Text = mTotalExcessiveTrx
        txtTotalExcessiveAmount.Text = mTotalExcessiveAmount
        txtTotalRefundTrx.Text = mTotalRefundTrx
        txtTotalRefundAmount.Text = mTotalRefundAmount
        txtTotalInvolTrx.Text = mTotalInvolTrx
        txtTotalInvolAmount.Text = mTotalInvolAmount
        txtTotalReissueTicket.Text = mTotalReissueTicket
        txtTotalReissueAmount.Text = mTotalReissueAmount
        txtTotalAmount.Text = mTotalAmount

        LoadReissueTicketPriceDetail()
    End Sub

    Private Sub dgvAtcCalcPriceDetail_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvAtcCalcPriceDetail.DataSourceChanged
        If dgvAtcCalcPriceDetail.Rows.Count > 0 Then
            llbExportAbnormalData.Enabled = True
        Else
            dgvAtcCalcPriceDetail_D.Rows.Clear()
            llbExportAbnormalData.Enabled = False
        End If
    End Sub

    Private Sub dgvAtcCalcPriceDetail_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAtcCalcPriceDetail.SelectionChanged
        If dgvAtcCalcPriceDetail.CurrentRow.Cells("ReissueAmount").Value > 0 Then
            LoadReissueTicketPriceDetail()
        Else
            dgvAtcCalcPriceDetail_D.Rows.Clear()
        End If
    End Sub

    Private Sub LoadReissueTicketPriceDetail()
        Dim i As Integer
        Dim mArrStr() As String
        Dim mReturn As New DataTable

        dgvAtcCalcPriceDetail_D.Rows.Clear()
        For i = 0 To FReissueTicketPriceDetail.Count - 1
            mArrStr = FReissueTicketPriceDetail(i).Split(vbLf)
            If mArrStr(1) = dgvAtcCalcPriceDetail.CurrentRow.Cells("CustID").Value Then
                dgvAtcCalcPriceDetail_D.Rows.Add(CInt(mArrStr(2)), CInt(mArrStr(3)), CInt(mArrStr(4)))
            End If
        Next
    End Sub

    Private Sub llbExportAbnormalData_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbExportAbnormalData.LinkClicked
        Dim i, j As Integer
        Dim mError As Boolean
        Dim mFileName As String
        Dim mExcel As New Excel.Application

        mError = False
        For i = 0 To dgvAtcCalcPriceDetail.Rows.Count - 1
            If dgvAtcCalcPriceDetail.Rows(i).Cells("ErrDesc").Value <> "" Then
                mError = True
                Exit For
            End If
        Next

        If Not mError Then
            MsgBox("Don't have abnormal data!")
            Exit Sub
        End If

        Try
            mExcel.Workbooks.Add()

            mExcel.ActiveSheet.columns(1).numberformat = "@"
            For i = 0 To dgvAtcCalcPriceDetail.Columns.GetColumnCount(0) - 1
                If i >= 3 And i <= dgvAtcCalcPriceDetail.Columns.GetColumnCount(0) - 3 Then mExcel.ActiveSheet.columns(i - 1).numberformat = "#,##0"
                If i >= 2 Then mExcel.ActiveSheet.cells(1, i - 1).value = dgvAtcCalcPriceDetail.Columns(i).Name
            Next

            For i = 0 To dgvAtcCalcPriceDetail.Rows.Count - 1
                If dgvAtcCalcPriceDetail.Rows(i).Cells("ErrDesc").Value <> "" Then
                    For j = 0 To dgvAtcCalcPriceDetail.Columns.GetColumnCount(0) - 1
                        If j >= 2 Then mExcel.ActiveSheet.cells(i + 2, j - 1).value = dgvAtcCalcPriceDetail.Rows(i).Cells(j).Value
                    Next
                End If
            Next

            For i = mExcel.ActiveSheet.usedrange.rows.count To 2 Step -1
                If mExcel.ActiveSheet.cells(i, 1).value Is Nothing Then mExcel.ActiveSheet.rows(i).Delete
            Next

            mExcel.ActiveSheet.usedrange.EntireColumn.AutoFit

            mFileName = "D:\AtcCalcPrice_" & Now.ToString("yyyyMMddhhmmss") & ".xlsx"
            mExcel.ActiveSheet.saveas(mFileName)
            MsgBox("Export " & mFileName & " complete!")
        Finally
            mExcel.Workbooks.Close()
            mExcel.Quit()
        End Try
    End Sub

    Private Sub llbSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSave.LinkClicked
        Dim mTrans As SqlClient.SqlTransaction
        Dim mError As Boolean
        Dim mPara(), mAtcCalcPriceID, mWhere, mPara2(), mAtcCalcPriceDetailID, mArrStr() As String
        Dim i, j As Integer

        mError = False
        For i = 0 To dgvAtcCalcPriceDetail.Rows.Count - 1
            If dgvAtcCalcPriceDetail.Rows(i).Cells("ErrDesc").Value <> "" Then
                mError = True
                Exit For
            End If
        Next

        If mError Then
            If MsgBox("Have abnormal data,are you sure to save!", vbYesNo) = vbNo Then Exit Sub
        End If

        mWhere = String.Format("RecID<>{0} and format(CPMonth,'MMM yyyy')='{1}' and Status='OK' and City='{2}'",
                               {txtRecID.Text, Format(dtpCPMonth.Value, "MMM yyyy"), pobjUser.City})
        If ScalarToInt("DATA1A_AtcCalcPrice", "RecID", mWhere, pobjSql.Connection) <> 0 Then
            MsgBox("This month had calculated price!")
            Exit Sub
        End If

        cmd.Connection = pobjSql.Connection
        mTrans = pobjSql.Connection.BeginTransaction
        cmd.Transaction = mTrans
        Try
            ReDim mPara(13)
            mPara(0) = Format(dtpCPMonth.Value, "yyyyMMdd")
            mPara(1) = txtTotalExcessiveTrx.Text
            mPara(2) = txtTotalExcessiveAmount.Text
            mPara(3) = txtTotalRefundTrx.Text
            mPara(4) = txtTotalRefundAmount.Text
            mPara(5) = txtTotalInvolTrx.Text
            mPara(6) = txtTotalInvolAmount.Text
            mPara(7) = txtTotalReissueTicket.Text
            mPara(8) = txtTotalReissueAmount.Text
            mPara(9) = txtTotalAmount.Text
            mPara(10) = Format(Now, "yyyyMMdd hh:mm:ss")
            mPara(11) = pobjUser.UserName

            If txtRecID.Text = 0 Then
                mPara(12) = pobjUser.City
                cmd.CommandText = String.Format("insert into DATA1A_AtcCalcPrice(CPMonth,TotalExcessiveTrx,TotalExcessiveAmount,TotalRefundTrx,TotalRefundAmount," &
                                                                                "TotalInvolTrx,TotalInvolAmount,TotalReissueTicket,TotalReissueAmount,TotalAmount," &
                                                                                "FstUpdate,FstUser,City) " &
                                                 "values('{0}',{1},{2},{3},{4}," &
                                                        "{5},{6},{7},{8},{9}," &
                                                        "'{10}','{11}','{12}')",
                                                mPara)
                cmd.ExecuteNonQuery()

                cmd.CommandText = "select SCOPE_IDENTITY()"
                mAtcCalcPriceID = cmd.ExecuteScalar
            Else
                mPara(12) = txtRecID.Text
                cmd.CommandText = String.Format("update DATA1A_AtcCalcPrice " &
                                                "set CPMonth='{0}',TotalExcessiveTrx={1},TotalExcessiveAmount={2},TotalRefundTrx={3},TotalRefundAmount={4}," &
                                                    "TotalInvolTrx={5},TotalInvolAmount={6},TotalReissueTicket={7},TotalReissueAmount={8},TotalAmount={9}," &
                                                    "LstUpdate='{10}',LstUser='{11}' " &
                                                "where RecID={12}",
                                                mPara)
                cmd.ExecuteNonQuery()

                mAtcCalcPriceID = txtRecID.Text
            End If

            ReDim mPara2(3)
            mPara2(0) = mPara(10)
            mPara2(1) = pobjUser.UserName
            mPara2(2) = mAtcCalcPriceID
            cmd.CommandText = String.Format("update DATA1A_AtcCalcPriceDetail set LstUpdate='{0}',LstUser='{1}',Status='XX' where AtcCalcPriceID={2} ", mPara2)
            cmd.ExecuteNonQuery()

            ReDim mPara2(3)
            mPara2(0) = mPara(10)
            mPara2(1) = pobjUser.UserName
            mPara2(2) = mAtcCalcPriceID
            cmd.CommandText = String.Format("update DATA1A_ReissueTicketPriceDetail set LstUpdate='{0}',LstUser='{1}',Status='XX' where AtcCalcPriceID={2} ", mPara2)
            cmd.ExecuteNonQuery()

            For i = 0 To dgvAtcCalcPriceDetail.Rows.Count - 1
                ReDim mPara2(20)
                mPara2(0) = mAtcCalcPriceID
                mPara2(1) = dgvAtcCalcPriceDetail.Rows(i).Cells("CustID").Value
                mPara2(2) = dgvAtcCalcPriceDetail.Rows(i).Cells("AtcOfferID").Value
                mPara2(3) = dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveTrx").Value
                mPara2(4) = dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveTrxPrice").Value
                mPara2(5) = dgvAtcCalcPriceDetail.Rows(i).Cells("ExcessiveAmount").Value
                mPara2(6) = dgvAtcCalcPriceDetail.Rows(i).Cells("RefundTrx").Value
                mPara2(7) = dgvAtcCalcPriceDetail.Rows(i).Cells("RefundTrxPrice").Value
                mPara2(8) = dgvAtcCalcPriceDetail.Rows(i).Cells("RefundAmount").Value
                mPara2(9) = dgvAtcCalcPriceDetail.Rows(i).Cells("InvolTrx").Value
                mPara2(10) = dgvAtcCalcPriceDetail.Rows(i).Cells("InvolTrxPrice").Value
                mPara2(11) = dgvAtcCalcPriceDetail.Rows(i).Cells("InvolAmount").Value
                mPara2(12) = dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueTicket").Value
                mPara2(13) = dgvAtcCalcPriceDetail.Rows(i).Cells("ReissueAmount").Value
                mPara2(14) = dgvAtcCalcPriceDetail.Rows(i).Cells("Amount").Value
                mPara2(15) = dgvAtcCalcPriceDetail.Rows(i).Cells("ErrDesc").Value
                mPara2(16) = dgvAtcCalcPriceDetail.Rows(i).Cells("AtcCpCode").Value
                mPara2(17) = mPara(10)
                mPara2(18) = pobjUser.UserName

                If dgvAtcCalcPriceDetail.Rows(i).Cells("RecID").Value = 0 Then
                    mPara2(19) = pobjUser.City

                    cmd.CommandText = String.Format("insert into DATA1A_AtcCalcPriceDetail(AtcCalcPriceID,CustID,AtcOfferID,ExcessiveTrx,ExcessiveTrxPrice," &
                                                                                          "ExcessiveAmount,RefundTrx,RefundTrxPrice,RefundAmount,InvolTrx," &
                                                                                          "InvolTrxPrice,InvolAmount,ReissueTicket,ReissueAmount,Amount," &
                                                                                          "ErrDesc,AtcCpCode,FstUpdate,FstUser,City) " &
                                                    "values({0},{1},{2},{3},{4}," &
                                                           "{5},{6},{7},{8},{9}," &
                                                           "{10},{11},{12},{13},{14}," &
                                                           "'{15}','{16}','{17}','{18}','{19}')",
                                                    mPara2)
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "select SCOPE_IDENTITY()"
                    mAtcCalcPriceDetailID = cmd.ExecuteScalar
                Else
                    ReDim mPara2(3)
                    mPara2(0) = mPara(10)
                    mPara2(1) = pobjUser.UserName
                    mPara2(2) = dgvAtcCalcPriceDetail.Rows(i).Cells("RecID").Value

                    cmd.CommandText = String.Format("update DATA1A_AtcCalcPriceDetail set LstUpdate='{0}',LstUser='{1}',Status='OK' where RecID={2} ",
                                                    mPara2)
                    cmd.ExecuteNonQuery()

                    mAtcCalcPriceDetailID = dgvAtcCalcPriceDetail.Rows(i).Cells("RecID").Value
                End If

                For j = 0 To FReissueTicketPriceDetail.Count - 1
                    mArrStr = FReissueTicketPriceDetail(j).Split(vbLf)
                    If mArrStr(1) = dgvAtcCalcPriceDetail.Rows(i).Cells("CustID").Value Then
                        If mArrStr(0) = "0" Then
                            ReDim mPara2(8)
                            mPara2(0) = mAtcCalcPriceID
                            mPara2(1) = mAtcCalcPriceDetailID
                            mPara2(2) = mArrStr(2)
                            mPara2(3) = mArrStr(3)
                            mPara2(4) = mArrStr(4)
                            mPara2(5) = pobjUser.City
                            mPara2(6) = mPara(10)
                            mPara2(7) = pobjUser.UserName

                            cmd.CommandText = String.Format("insert into DATA1A_ReissueTicketPriceDetail(AtcCalcPriceID,AtcCalcPriceDetailID,NumberOfTicket," &
                                                                                                            "PricePerTicket,Amount," &
                                                                                                        "City,FstUpdate,FstUser) " &
                                                        "values({0},{1},{2},{3},{4}," &
                                                               "'{5}','{6}','{7}')",
                                                        mPara2)
                        Else
                            ReDim mPara2(3)
                            mPara2(0) = mPara(10)
                            mPara2(1) = pobjUser.UserName
                            mPara2(2) = mArrStr(0)

                            cmd.CommandText = String.Format("update DATA1A_ReissueTicketPriceDetail set FstUpdate='{0}',FstUser='{1}',Status='OK' where RecID={2}",
                                                            mPara2)
                        End If

                        cmd.ExecuteNonQuery()
                    End If
                Next
            Next

            mTrans.Commit()
        Catch ex As Exception
            MsgBox(ex.Message)
            mTrans.Rollback()
            Exit Sub
        End Try

        DialogResult = DialogResult.OK
    End Sub

    Private Sub dtpCPMonth_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtpCPMonth.Validating
        If dgvAtcCalcPriceDetail.Rows.Count > 0 Then
            If MsgBox("Change CPMonth will calculate price again, change CPMonth?", vbYesNo) = vbNo Then
                dtpCPMonth.Value = FOCPMonth
                Exit Sub
            End If

            CalcPrice()
        End If
    End Sub

    Private Sub dtpCPMonth_Enter(sender As Object, e As EventArgs) Handles dtpCPMonth.Enter
        FOCPMonth = dtpCPMonth.Value
    End Sub
End Class