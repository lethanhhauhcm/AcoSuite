'^_^20230112 add by 7643
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmSecoPpd
    Private FSecoPpdYear As Integer
    Private FCustomers As New List(Of Integer)
    Private FSda As SqlClient.SqlDataAdapter
    Private FDs As New DataSet

    Private Sub frmSecoPpd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SelectPage(tcSecoPpd, tpList)
        LoadSecoPpd()
    End Sub

    Private Sub LoadSecoPpd()
        Dim mSQL As String
        Dim mCols As New List(Of String)
        Dim i As Integer

        'Load datagridview
        mSQL = String.Format("select RecID,SecoPpdYear,TotalUser,TotalAmount,FstUpdate,FstUser,LstUpdate,LstUser " &
                             "from DATA1A_SecoPpd " &
                             "where Status='OK' and City='{0}' " &
                             "order by SecoPpdYear", {pobjUser.City})
        pobjSql.LoadDataGridView(dgvSecoPpd, mSQL)

        'Format columns
        mCols.Add(dgvSecoPpd.Columns(0).Name)
        mCols.Add(dgvSecoPpd.Columns(2).Name)
        mCols.Add(dgvSecoPpd.Columns(3).Name)
        FormatNumber(dgvSecoPpd, mCols)
    End Sub

    Private Sub llbCalcSecoPpd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCalcSecoPpd.LinkClicked
        SelectPage(tcSecoPpd, tpInput)
    End Sub

    Private Sub LoadSecoPpdDetail2(xYear As String, xCusts As String)
        Dim mSQL As String
        Dim mNumberCols As New List(Of String)

        'Load datagridview
        mSQL = String.Format("select distinct cust.RecID CustID,cust.ShortName,count(sur.UserID) UserQty,0 Amount " &
                             "from DATA1A_SecoUserRaw sur " &
                                "inner join DATA1A_OIDs oid on sur.OffcId=oid.OffcId And oid.Status='OK' " &
                                "inner join DATA1A_Customers cust on oid.ShortName=cust.ShortName And cust.status='OK' and cust.Region='{0}' " &
                             "where sur.CreationDate<='{1}' and sur.status='OK' and SUR.counter<>0 " &
                                "and sur.UserID Not in (select VAL from DATA1A_MISC where CAT='BypassSecoCheck') and cust.RecID in ({2}) " &
                             "group by cust.RecID,cust.ShortName " &
                             "order by cust.ShortName",
                             {pobjUser.Region, xYear, xCusts})
        pobjSql.LoadDataGridView(dgvSecoPpdDetail2, mSQL)

        'Format columns
        dgvSecoPpdDetail2.Columns(0).Visible = False
        mNumberCols.Add(dgvSecoPpdDetail2.Columns(2).Name)
        mNumberCols.Add(dgvSecoPpdDetail2.Columns(3).Name)
        FormatNumber(dgvSecoPpdDetail2, mNumberCols)
    End Sub

    Private Sub dgvSecoPpd_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvSecoPpd.DataSourceChanged
        llbDelete.Enabled = dgvSecoPpd.Rows.Count > 0
        If dgvSecoPpd.Rows.Count = 0 Then LoadSecoPpdDetail(0)
    End Sub

    Private Sub dgvSecoPpd_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSecoPpd.SelectionChanged
        Dim mSecoPpDID As Integer

        If dgvSecoPpd.CurrentRow IsNot Nothing Then mSecoPpDID = dgvSecoPpd.CurrentRow.Cells("RecID").Value
        LoadSecoPpdDetail(mSecoPpDID)
    End Sub

    Private Sub LoadSecoPpdDetail(xSecoPpDID As Integer)
        Dim mSQL As String
        Dim mNumberCols As New List(Of String)

        'Load datagridview
        mSQL = String.Format("select spd.RecID,spd.CustID,cust.ShortName,spd.UserQty,spd.Amount,spd.FstUpdate,spd.FstUser,spd.LstUpdate,spd.LstUser " &
                             "from DATA1A_SecoPpdDetail spd left join DATA1A_Customers cust on spd.CustID=cust.RecID And cust.Status='OK' and Cust.Region='{0}' " &
                             "where spd.SecoPpDID={1} and spd.Status='OK' and spd.City='{2}' " &
                             "order by cust.ShortName",
                             {pobjUser.Region, xSecoPpDID, pobjUser.City})
        pobjSql.LoadDataGridView(dgvSecoPpdDetail, mSQL)

        'Format columns
        dgvSecoPpdDetail.Columns(1).Visible = False
        mNumberCols.Add(dgvSecoPpdDetail.Columns(0).Name)
        mNumberCols.Add(dgvSecoPpdDetail.Columns(3).Name)
        mNumberCols.Add(dgvSecoPpdDetail.Columns(4).Name)
        FormatNumber(dgvSecoPpdDetail, mNumberCols)
    End Sub

    Private Sub dgvSecoPpdDetail_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvSecoPpdDetail.DataSourceChanged
        llbExportXls.Enabled = dgvSecoPpdDetail.Rows.Count > 0
        If dgvSecoPpdDetail.Rows.Count = 0 Then LoadSecoPpdDetail_D(0)
    End Sub

    Private Sub LoadSecoPpdDetail_D(xSecoPpdDetailID As Integer)
        Dim mSQL As String
        Dim i As Integer
        Dim mNumberCols As New List(Of String)

        'Load datagridview
        mSQL = String.Format("select RecID,SecoOfferDetailID,SecoPpdMonth,UserQty,Price,Amount,FstUpdate,FstUser,LstUpdate,LstUser " &
                             "from DATA1A_SecoPpdDetail_D " &
                             "where SecoPpdDetailID={0} And Status='OK' and City='{1}' " &
                             "order by SecoPpdMonth", {xSecoPpdDetailID, pobjUser.City})
        pobjSql.LoadDataGridView(dgvSecoPpdDetail_D, mSQL)

        'Format columns
        For i = 0 To 5
            mNumberCols.Add(dgvSecoPpdDetail_D.Columns(i).Name)
        Next
        FormatNumber(dgvSecoPpdDetail_D, mNumberCols)
    End Sub

    Private Sub dgvSecoPpdDetail_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSecoPpdDetail.SelectionChanged
        Dim mSecoPpDDetailID As Integer

        If dgvSecoPpdDetail.CurrentRow IsNot Nothing Then mSecoPpDDetailID = dgvSecoPpdDetail.CurrentRow.Cells("RecID").Value
        LoadSecoPpdDetail_D(mSecoPpDDetailID)
    End Sub

    Private Sub llbDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDelete.LinkClicked
        Dim mSQL As New List(Of String)

        If MsgBox("Are you sure delete this SecoPpd data?", vbYesNo) = vbNo Then Exit Sub

        BeginTrans()
        Try
            cmd.CommandText = String.Format("update DATA1A_SecoPpdDetail_D set Status='XX' where SecoPpdID={0} and Status='OK' and City='{1}'",
                                            {dgvSecoPpd.CurrentRow.Cells("RecID").Value, pobjUser.City})
            cmd.ExecuteNonQuery()
            cmd.CommandText = String.Format("update DATA1A_SecoPpdDetail set Status='XX' where SecoPpdID={0} and Status='OK' and City='{1}'",
                                            {dgvSecoPpd.CurrentRow.Cells("RecID").Value, pobjUser.City})
            cmd.ExecuteNonQuery()
            cmd.CommandText = String.Format("update DATA1A_SecoPpd set Status='XX' where RecID={0} and Status='OK' and City='{1}'",
                                            {dgvSecoPpd.CurrentRow.Cells("RecID").Value, pobjUser.City})
            cmd.ExecuteNonQuery()

            CommitTrans()
            LoadSecoPpd()
        Catch ex As Exception
            RollbackTrans()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub llbExportXls_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbExportXls.LinkClicked
        Dim i, j As Integer
        Dim mFileName As String
        Dim mExcel As New Excel.Application

        Try
            mExcel.Workbooks.Add()

            'Format columns and write header
            For i = 0 To dgvSecoPpdDetail.Columns.GetColumnCount(0) - 1
                If i = 2 Or (i >= 6 And i <= 0) Then mExcel.ActiveSheet.columns(2).Hidden = True

                If i <> 2 Then
                    mExcel.ActiveSheet.columns(i + 1).numberformat = "#,##0"
                Else
                    mExcel.ActiveSheet.columns(i + 1).numberformat = "@"
                End If

                mExcel.ActiveSheet.cells(1, i + 1).value = dgvSecoPpdDetail.Columns(i).Name
            Next

            'Write data
            For i = 0 To dgvSecoPpdDetail.Rows.Count - 1
                For j = 0 To dgvSecoPpdDetail.Columns.GetColumnCount(0) - 1
                    mExcel.ActiveSheet.cells(i + 2, j + 1).value = dgvSecoPpdDetail.Rows(i).Cells(j).Value
                Next
            Next
            mExcel.ActiveSheet.usedrange.EntireColumn.AutoFit

            'Save file
            mFileName = "D:\SecoPpd_" & dgvSecoPpd.CurrentRow.Cells("SecoPpdYear").Value & "_" & Now.ToString("yyyyMMddhhmmss") & ".xlsx"
            mExcel.ActiveSheet.saveas(mFileName)
            MsgBox("Export " & mFileName & " complete!")
        Finally
            mExcel.Workbooks.Close()
            mExcel.Quit()
        End Try
    End Sub

    Private Sub llbCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCancel.LinkClicked
        SelectPage(tcSecoPpd, tpList)
    End Sub

    Private Sub dtpSecoPpdYear_Enter(sender As Object, e As EventArgs) Handles dtpSecoPpdYear.Enter
        FSecoPpdYear = dtpSecoPpdYear.Value.Year
    End Sub

    Private Sub dtpSecoPpdYear_Validated(sender As Object, e As EventArgs) Handles dtpSecoPpdYear.Validated
        Dim mShortNames

        mShortNames = CheckDuplicate()
        If mShortNames <> "" Then
            dtpSecoPpdYear.Value = DateSerial(FSecoPpdYear, 1, 1)
            MsgBox("Customer " & mShortNames & " and SecoPpdYear " & dtpSecoPpdYear.Value.Year & " had CalcSecoPpd!")
        End If
    End Sub

    Private Function CheckDuplicate() As String
        Dim i As Integer
        Dim mTbl, mDK, mShortNames As String

        mShortNames = ""
        For i = 0 To lstCustomer.SelectedItems.Count - 1
            mTbl = "DATA1A_SecoPpd sp left join DATA1A_SecoPpdDetail spd on sp.RecID=spd.SecoPpdID and spd.Status='OK' and sp.City=spd.City"
            mDK = String.Format("sp.Status='OK' and sp.City='{0}' and sp.SecoPpdYear='{1}' and spd.CustID={2}",
                                {pobjUser.City, dtpSecoPpdYear.Value.Year, lstCustomer.SelectedItems(i)("Value")})
            If ScalarToInt(mTbl, "sp.RecID", mDK, pobjSql.Connection) <> 0 Then
                mShortNames = mShortNames & IIf(mShortNames <> "", ",", "") & lstCustomer.SelectedItems(i)("Display")
            End If
        Next

        Return mShortNames
    End Function

    Private Sub lstCustomer_Enter(sender As Object, e As EventArgs) Handles lstCustomer.Enter
        Dim i As Integer

        FCustomers.Clear()
        For i = 0 To lstCustomer.SelectedItems.Count - 1
            FCustomers.Add(lstCustomer.SelectedItems(i)("Value"))
        Next
    End Sub

    Private Sub lstCustomer_Validated(sender As Object, e As EventArgs) Handles lstCustomer.Validated
        Dim mShortNames
        Dim i As Integer

        mShortNames = CheckDuplicate()
        If mShortNames <> "" Then
            lstCustomer.SelectedItems.Clear()
            For i = 0 To FCustomers.Count - 1
                lstCustomer.SelectedValue = FCustomers(i)
            Next

            MsgBox("Customer " & mShortNames & " and SecoPpdYear " & dtpSecoPpdYear.Value.Year & " had CalcSecoPpd!")
        End If
    End Sub

    Private Sub llbCalcSecoPpd2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCalcSecoPpd2.LinkClicked
        Dim mSQL, mCust, mPara() As String
        Dim i, j, t, mTotalUser As Integer
        Dim mNumberCols As New List(Of String)
        Dim mReturn As New DataTable
        Dim mAmount, mTotalAmount As Double

        'Calculate SecoPpdDetail
        mCust = ""
        For i = 0 To lstCustomer.SelectedItems.Count - 1
            mCust &= IIf(mCust <> "", ",", "") & lstCustomer.SelectedItems(i)("Value")
        Next
        LoadSecoPpdDetail2(Format(dtpSecoPpdYear.Value, "yyyy1215 23:59:59"), mCust)

        'Calculate SecoPpdDetail_D
        FDs.Tables(0).Rows.Clear()
        mTotalUser = 0
        mTotalAmount = 0
        For i = 0 To dgvSecoPpdDetail2.Rows.Count - 1
            ReDim mPara(8)
            mPara(0) = dgvSecoPpdDetail2.Rows(i).Cells("CustID").Value
            mPara(2) = dgvSecoPpdDetail2.Rows(i).Cells("UserQty").Value
            mPara(3) = dgvSecoPpdDetail2.Rows(i).Cells("UserQty").Value
            mPara(4) = pobjUser.City
            mPara(5) = dgvSecoPpdDetail2.Rows(i).Cells("ShortName").Value
            mPara(7) = dgvSecoPpdDetail2.Rows(i).Cells("UserQty").Value

            mAmount = 0
            For j = 1 To 12
                mPara(1) = j
                mPara(6) = dtpSecoPpdYear.Value.Year & Strings.Right("0" & j, 2)
                mSQL = String.Format("select CustID,SecoOfferDetailID,SecoPpdMonth,UserQty,Price," &
                                        "case when PriceCombo<>0 then PriceCombo else UserQty*Price end Amount " &
                                     "from " &
                                     "( " &
                                        "select {0} CustID,pld.RecID SecoOfferDetailID,{1} SecoPpdMonth," &
                                            "case when {2}>pld.ToTheUser then pld.ToTheUser-pld.FromTheUser else {3}-pld.FromTheUser end+1 UserQty," &
                                            "pld.PricePerUser Price,PriceCombo,pld.Status " &
                                        "from DATA1A_PriceList pl " &
                                            "inner join DATA1A_PriceListDetail pld on pl.PriceID=pld.PriceID And pld.Status='OK' and pld.City=pl.City " &
                                        "where pl.Status='OK' and pl.City='{4}' and pl.Customer='{5}' " &
                                            "and '{6}' between format(EffDate,'yyyyMM') and format(ExpDate,'yyyyMM') and pld.FromTheUser<={7} " &
                                     ")a", mPara)
                mReturn = pobjSql.GetDataTable(mSQL)
                For t = 0 To mReturn.Rows.Count - 1
                    FDs.Tables(0).Rows.Add(mReturn.Rows(t).ItemArray)
                    mAmount += mReturn.Rows(t)("Amount")
                Next
            Next

            dgvSecoPpdDetail2.Rows(i).Cells("UserQty").Value = dgvSecoPpdDetail2.Rows(i).Cells("UserQty").Value * 12
            dgvSecoPpdDetail2.Rows(i).Cells("Amount").Value = mAmount
            mTotalUser += dgvSecoPpdDetail2.Rows(i).Cells("UserQty").Value
            mTotalAmount += dgvSecoPpdDetail2.Rows(i).Cells("Amount").Value
        Next

        'Set total
        txtTotalUser.Text = Format(mTotalUser, "N0")
        txtTotalAmount.Text = Format(mTotalAmount, "N0")

        FDs.Tables(0).DefaultView.RowFilter = "CustID=" & dgvSecoPpdDetail2.CurrentRow.Cells("CustID").Value
    End Sub

    Private Sub dgvSecoPpdDetail2_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSecoPpdDetail2.SelectionChanged
        FDs.Tables(0).DefaultView.RowFilter = "CustID=" & dgvSecoPpdDetail2.CurrentRow.Cells("CustID").Value
    End Sub

    Private Sub llbSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSave.LinkClicked
        Dim mPara(), mDetailPara(), mDetail_DPara() As String
        Dim i, j As Integer

        If dgvSecoPpdDetail2.Rows.Count = 0 Then
            MsgBox("Have not been CalcSecoPpd!")
            Exit Sub
        End If

        BeginTrans()
        Try
            'Insert SecoPpd
            ReDim mPara(6)
            mPara(0) = dtpSecoPpdYear.Value.Year
            mPara(1) = CInt(txtTotalUser.Text)
            mPara(2) = CDec(txtTotalAmount.Text)
            mPara(3) = pobjUser.City
            mPara(4) = Format(Now, "yyyyMMdd hh:mm:ss")
            mPara(5) = pobjUser.UserName
            cmd.CommandText = String.Format("insert into DATA1A_SecoPpd(SecoPpdYear,TotalUser,TotalAmount,City,FstUpdate," &
                                                                       "FstUser) " &
                                            "values({0},{1},{2},'{3}','{4}'," &
                                                   "'{5}')",
                                            mPara)
            cmd.ExecuteNonQuery()

            'Insert SecoPpdDetail
            ReDim mDetailPara(7)
            cmd.CommandText = "select SCOPE_IDENTITY()"
            mDetailPara(0) = cmd.ExecuteScalar
            mDetailPara(4) = pobjUser.City
            mDetailPara(5) = mPara(4)
            mDetailPara(6) = mPara(5)
            For i = 0 To dgvSecoPpdDetail2.Rows.Count - 1
                mDetailPara(1) = dgvSecoPpdDetail2.Rows(i).Cells("CustID").Value
                mDetailPara(2) = dgvSecoPpdDetail2.Rows(i).Cells("UserQty").Value
                mDetailPara(3) = dgvSecoPpdDetail2.Rows(i).Cells("Amount").Value
                cmd.CommandText = String.Format("insert into DATA1A_SecoPpdDetail(SecoPpdID,CustID,UserQty,Amount,City," &
                                                                                 "FstUpdate,FstUser) " &
                                                "values({0},{1},{2},{3},'{4}'," &
                                                       "'{5}','{6}')",
                                                mDetailPara)
                cmd.ExecuteNonQuery()

                'Insert SecoPpdDetail_D
                ReDim mDetail_DPara(10)
                mDetail_DPara(0) = mDetailPara(0)
                cmd.CommandText = "select SCOPE_IDENTITY()"
                mDetail_DPara(1) = cmd.ExecuteScalar
                mDetail_DPara(7) = mDetailPara(4)
                mDetail_DPara(8) = mDetailPara(5)
                mDetail_DPara(9) = mDetailPara(6)
                FDs.Tables(0).DefaultView.RowFilter = "CustID=" & mDetailPara(1)
                For j = 0 To dgvSecoPpdDetail_D2.Rows.Count - 1
                    mDetail_DPara(2) = dgvSecoPpdDetail_D2.Rows(j).Cells("SecoOfferDetailID").Value
                    mDetail_DPara(3) = dgvSecoPpdDetail_D2.Rows(j).Cells("SecoPpdMonth").Value
                    mDetail_DPara(4) = dgvSecoPpdDetail_D2.Rows(j).Cells("UserQty").Value
                    mDetail_DPara(5) = dgvSecoPpdDetail_D2.Rows(j).Cells("Price").Value
                    mDetail_DPara(6) = dgvSecoPpdDetail_D2.Rows(j).Cells("Amount").Value
                    cmd.CommandText = String.Format("insert into DATA1A_SecoPpdDetail_D(SecoPpdID,SecoPpdDetailID,SecoOfferDetailID,SecoPpdMonth,UserQty," &
                                                                                       "Price,Amount,City,FstUpdate,FstUser) " &
                                                    "values({0},{1},{2},{3},{4}," &
                                                           "{5},{6},'{7}','{8}','{9}')",
                                                    mDetail_DPara)
                    cmd.ExecuteNonQuery()
                Next
            Next

            CommitTrans()
            ChangeTab(tcSecoPpd, tpList)
            LoadSecoPpd()
        Catch ex As Exception
            RollbackTrans()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tcSecoPpd_ControlAdded(sender As Object, e As ControlEventArgs) Handles tcSecoPpd.ControlAdded
        Dim mSQL As String
        Dim mNumCols As New List(Of String)
        Dim i As Integer

        If tcSecoPpd.TabPages(0).Name = "tpInput" Then
            dtpSecoPpdYear.Value = Now
            mSQL = String.Format("select RecID Value,ShortName Display from DATA1A_Customers where Status='OK' and Region='{0}' order by ShortName", {pobjUser.Region})
            pobjSql.LoadListboxVal(lstCustomer, mSQL)
            LoadSecoPpdDetail2("", "0")
            mSQL = "select 0 CustID,SecoOfferDetailID,SecoPpdMonth,UserQty,Price,Amount from DATA1A_SecoPpdDetail_D where RecID=0"
            LoadDataGridView2(dgvSecoPpdDetail_D2, mSQL, FSda, FDs)
            dgvSecoPpdDetail_D2.Columns(0).Visible = False
            For i = 1 To dgvSecoPpdDetail_D2.Columns.GetColumnCount(0) - 1
                mNumCols.Add(dgvSecoPpdDetail_D2.Columns(i).Name)
            Next
            FormatNumber(dgvSecoPpdDetail_D2, mNumCols)
            txtTotalUser.Text = 0
            txtTotalAmount.Text = 0
        End If
    End Sub
End Class