'^_^20221227 add by 7643
Public Class frmAtcCalcPrice
    Private Sub frmAtcCalcPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpCPMonthFrom.Value = Format(Now, "Jan yyyy")
        dtpCPMonthTo.Value = Format(Now, "Dec yyyy")
        LoadAtcCalcPrice()
    End Sub

    Private Sub LoadAtcCalcPrice()
        Dim mSQL, mDayInMonth As String
        Dim i As Integer
        Dim mNumberCols As New List(Of String)

        mSQL = String.Format("select RecID,format(CPMonth,'MMM yyyy') CPMonth,TotalExcessiveTrx,TotalExcessiveAmount,TotalRefundTrx,TotalRefundAmount," &
                                "TotalInvolTrx,TotalInvolAmount,TotalReissueTicket,TotalFreeReissueTicket,TotalReissueAmount,TotalAmount,Confirm,FstUpdate,FstUser," &
                                "LstUpdate,LstUser " &
                             "from DATA1A_AtcCalcPrice " &
                             "where status='OK' and City='{0}' ", {pobjUser.City})
        If dtpCPMonthFrom.Checked Then mSQL &= String.Format("and CPMonth>='{0}' ", {Format(dtpCPMonthFrom.Value, "yyyyMMdd")})
        If dtpCPMonthTo.Checked Then
            mDayInMonth = Date.DaysInMonth(dtpCPMonthTo.Value.Year, dtpCPMonthTo.Value.Month)
            mSQL &= String.Format("and CPMonth<='{0}' ", {Format(dtpCPMonthTo.Value, "yyyyMM" & mDayInMonth)})
        End If
        mSQL &= "order by CPMonth"
        pobjSql.LoadDataGridView(dgvAtcCalcPrice, mSQL)

        mNumberCols.Add(dgvAtcCalcPrice.Columns(0).Name)
        For i = 2 To 10
            mNumberCols.Add(dgvAtcCalcPrice.Columns(i).Name)
        Next
        FormatNumber(dgvAtcCalcPrice, mNumberCols)
    End Sub

    Private Sub llbFilter_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbFilter.LinkClicked
        LoadAtcCalcPrice()
    End Sub

    Private Sub dgvAtcCalcPrice_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAtcCalcPrice.SelectionChanged
        If dgvAtcCalcPrice.CurrentRow.Cells("Confirm").Value Then
            llbDelete.Enabled = False
            llbConfirm.Text = "UnConfirm"
        Else
            llbDelete.Enabled = True
            llbConfirm.Text = "Confirm"
        End If
        LoadAtcCalcPriceDetail(dgvAtcCalcPriceDetail, dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value)
    End Sub

    Private Sub LoadAtcCalcPriceDetail(xDgv As DataGridView, xAtcCalcPriceID As Integer, Optional xHaveSysCol As Boolean = True)
        Dim mSQL As String
        Dim i As Integer
        Dim mNumCols As New List(Of String)

        mSQL = "select cpd.RecID,cpd.CustID,cus.ShortName,cpd.AtcOfferID,cpd.ExcessiveTrx,cpd.ExcessiveTrxPrice,cpd.ExcessiveAmount,cpd.RefundTrx," &
                    "cpd.RefundTrxPrice,cpd.RefundAmount,cpd.InvolTrx,cpd.InvolTrxPrice,cpd.InvolAmount,cpd.ReissueTicket,cpd.FreeReissueTicket," &
                    "cpd.ReissueTicketPrice,cpd.ReissueAmount,cpd.Amount,cpd.ErrDesc,cpd.AtcCpCode "
        If xHaveSysCol Then mSQL = mSQL & ",cpd.FstUpdate,cpd.FstUser,cpd.LstUpdate,cpd.LstUser "
        mSQL = mSQL & String.Format("from DATA1A_AtcCalcPriceDetail cpd " &
                                        "left join DATA1A_Customers cus on cpd.CustID=cus.RecID And cus.Status='OK' and cus.Region='{0}' " &
                                     "where cpd.AtcCalcPriceID={1} And cpd.Status='OK' and cpd.City='{2}' " &
                                     "order by cus.ShortName ",
                                     {pobjUser.Region, xAtcCalcPriceID, pobjUser.City})
        pobjSql.LoadDataGridView(xDgv, mSQL)

        If Not xHaveSysCol Then xDgv.Columns("RecID").Visible = False
        xDgv.Columns("CustID").Visible = False
        For i = 2 To 14
            mNumCols.Add(dgvAtcCalcPriceDetail.Columns(i).Name)
        Next
        FormatNumber(dgvAtcCalcPriceDetail, mNumCols)
    End Sub

    Private Sub dgvAtcCalcPrice_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvAtcCalcPrice.DataSourceChanged
        Dim mAtcCaclPriceID As Integer

        If dgvAtcCalcPrice.Rows.Count > 0 Then
            mAtcCaclPriceID = dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value

            llbConfirm.Enabled = True
            If Not dgvAtcCalcPrice.CurrentRow.Cells("Confirm").Value Then
                llbDelete.Enabled = True
                llbConfirm.Text = "Confirm"
            Else
                llbDelete.Enabled = False
                llbConfirm.Text = "UnConfirm"
            End If
        Else
            llbDelete.Enabled = False
            llbConfirm.Enabled = False
            llbConfirm.Text = "Confirm"
        End If

        LoadAtcCalcPriceDetail(dgvAtcCalcPriceDetail, mAtcCaclPriceID)
    End Sub

    Private Sub llbAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbAdd.LinkClicked
        Dim mForm As New frmAtcCalcPriceEdit

        mForm.dtpCPMonth.Value = Format(Now, "MMM yyyy")
        LoadAtcCalcPriceDetail(mForm.dgvAtcCalcPriceDetail, 0, False)
        If mForm.ShowDialog() = DialogResult.OK Then LoadAtcCalcPrice()
    End Sub

    Private Sub llbReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbReset.LinkClicked
        dtpCPMonthFrom.Value = Format(Now, "Jan yyyy")
        dtpCPMonthTo.Value = Format(Now, "Dec yyyy")
        LoadAtcCalcPrice()
    End Sub

    Private Sub llbConfirm_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbConfirm.LinkClicked
        Dim t As SqlClient.SqlTransaction
        Dim mPara(), mPara2() As String

        If dgvAtcCalcPrice.CurrentRow.Cells("Confirm").Value Then
            If MsgBox("Unconfirm will be delete FOP data, are you sure unconfirm?", vbYesNo) = vbNo Then Exit Sub
            If ScalarToInt("DATA1A_FOP", "RecID", "RCPID=" & dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value & " and Status='OK' and ProfID<>0",
                           pobjSql.Connection) <> 0 Then
                MsgBox("This AtcCalcPrice has been debited, can't unconfirm!")
                Exit Sub
            End If
        End If

        cmd.Connection = pobjSql.Connection
        t = pobjSql.Connection.BeginTransaction
        cmd.Transaction = t
        Try
            If Not dgvAtcCalcPrice.CurrentRow.Cells("Confirm").Value Then
                ReDim mPara(3)
                mPara(0) = pobjUser.UserName
                mPara(1) = Format(Now, "yyyyMMdd hh:mm:ss")
                mPara(2) = dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value
                cmd.CommandText = String.Format("update DATA1A_AtcCalcPrice set Confirm=1,LstUser='{0}',LstUpdate='{1}' where RecID={2}", mPara)
                cmd.ExecuteNonQuery()

                For i = 0 To dgvAtcCalcPriceDetail.Rows.Count - 1
                    ReDim mPara2(12)
                    mPara2(0) = dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value
                    mPara2(1) = dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value
                    mPara2(2) = "PSP"
                    mPara2(3) = "VND"
                    mPara2(4) = 1
                    mPara2(5) = dgvAtcCalcPriceDetail.Rows(i).Cells("Amount").Value
                    mPara2(6) = dgvAtcCalcPriceDetail.Rows(i).Cells("AtcCpCode").Value
                    mPara2(7) = pobjUser.UserName
                    mPara2(8) = mPara(1)
                    mPara2(9) = dgvAtcCalcPriceDetail.Rows(i).Cells("RecID").Value
                    mPara2(10) = dgvAtcCalcPriceDetail.Rows(i).Cells("CustID").Value
                    mPara2(11) = "ATC"
                    cmd.CommandText = String.Format("insert into DATA1A_FOP(RCPID,RCPNo,FOP,Currency,ROE," &
                                                                       "Amount,Document,FstUser,FstUpdate,RMK," &
                                                                       "CustomerID,Source) " &
                                                "values({0},'{1}','{2}','{3}',{4}," &
                                                       "{5},'{6}','{7}','{8}',{9}," &
                                                       "'{10}','{11}')", mPara2)
                    cmd.ExecuteNonQuery()
                Next
            Else
                ReDim mPara(3)
                mPara(0) = pobjUser.UserName
                mPara(1) = Format(Now, "yyyyMMdd hh:mm:ss")
                mPara(2) = dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value
                cmd.CommandText = String.Format("update DATA1A_AtcCalcPrice set Confirm=0,LstUser='{0}',LstUpdate='{1}' where RecID={2}", mPara)
                cmd.ExecuteNonQuery()

                cmd.CommandText = String.Format("update DATA1A_FOP set Status='XX',LstUser='{0}',LstUpdate='{1}' where RCPID={2} and status='OK'", mPara)
                cmd.ExecuteNonQuery()
            End If

            t.Commit()
        Catch ex As Exception
            t.Rollback()
            Append2TextFile(ex.Message & vbNewLine & cmd.CommandText)
            MsgBox(ex.Message & vbNewLine & cmd.CommandText)
        End Try

        LoadAtcCalcPrice()
    End Sub

    Private Sub llbDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDelete.LinkClicked
        Dim t As SqlClient.SqlTransaction
        Dim mPara() As String

        If MsgBox("Are you sure delete this AtcCalcPrice?", vbYesNo) = vbNo Then Exit Sub

        cmd.Connection = pobjSql.Connection
        t = pobjSql.Connection.BeginTransaction
        cmd.Transaction = t
        Try
            ReDim mPara(3)
            mPara(0) = pobjUser.UserName
            mPara(1) = Format(Now, "yyyyMMdd hh:mm:ss")
            mPara(2) = dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value
            cmd.CommandText = String.Format("update DATA1A_AtcCalcPrice set Status='XX',LstUser='{0}',LstUpdate='{1}' where RecID={2}", mPara)
            cmd.ExecuteNonQuery()

            ReDim mPara(3)
            mPara(0) = pobjUser.UserName
            mPara(1) = Format(Now, "yyyyMMdd hh:mm:ss")
            mPara(2) = dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value
            cmd.CommandText = String.Format("update DATA1A_AtcCalcPriceDetail set Status='XX',LstUser='{0}',LstUpdate='{1}' where AtcCalcPriceID={2}", mPara)
            cmd.ExecuteNonQuery()

            ReDim mPara(3)
            mPara(0) = pobjUser.UserName
            mPara(1) = Format(Now, "yyyyMMdd hh:mm:ss")
            mPara(2) = dgvAtcCalcPrice.CurrentRow.Cells("RecID").Value
            cmd.CommandText = String.Format("update DATA1A_ReissueTicketPriceDetail set Status='XX',LstUser='{0}',LstUpdate='{1}' where AtcCalcPriceID={2}", mPara)
            cmd.ExecuteNonQuery()

            t.Commit()
        Catch ex As Exception
            t.Rollback()
            Append2TextFile(ex.Message & vbNewLine & cmd.CommandText)
            MsgBox(ex.Message & vbNewLine & cmd.CommandText)
        End Try

        LoadAtcCalcPrice()
    End Sub

    Private Sub dgvAtcCalcPriceDetail_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvAtcCalcPriceDetail.DataSourceChanged
        Dim mAtcCalcPriceDetailID As Integer

        If dgvAtcCalcPriceDetail.Rows.Count > 0 Then mAtcCalcPriceDetailID = dgvAtcCalcPriceDetail.CurrentRow.Cells("RecID").Value
        LoadAtcCalcPriceDetail_D(mAtcCalcPriceDetailID)
    End Sub

    Private Sub dgvAtcCalcPriceDetail_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAtcCalcPriceDetail.SelectionChanged
        LoadAtcCalcPriceDetail_D(dgvAtcCalcPriceDetail.CurrentRow.Cells("Recid").Value)
    End Sub

    Private Sub LoadAtcCalcPriceDetail_D(xAtcCalcPriceDetailID As Integer)
        Dim mSQL As String
        Dim i As Integer

        mSQL = String.Format("select RecID,Booking,FreeTicket,FstUpdate,FstUser,LstUpdate,LstUser " &
                             "from DATA1A_ReissueTicketPriceDetail_D " &
                             "where AtcCalcPriceDetailID={0} And Status='OK' and City='{1}'",
                             {xAtcCalcPriceDetailID, pobjUser.City})
        pobjSql.LoadDataGridView(dgvAtcCalcPriceDetail_D, mSQL)

        For i = 0 To dgvAtcCalcPriceDetail_D.Columns.Count - 1
            Select Case dgvAtcCalcPriceDetail_D.Columns(i).Name
                Case "RecID", "Booking", "FreeTicket"
                    dgvAtcCalcPriceDetail_D.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next
    End Sub
End Class