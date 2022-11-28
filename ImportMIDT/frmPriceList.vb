'20220526 add by 7643
Imports System.Globalization
Public Class frmPriceList
    Private FChangeNum As Integer
    Private FDate, FEffDate, FExpDate As String
    Private FAddPower, FDeletePower As Boolean
    Private Enum FAction
        Add
        Edit
        Copy
    End Enum

#Region "Custom Method"
    Private Sub LoadDgv(xDgv As DataGridView, Optional xPriceId As Integer = 0, Optional xChangeNum As Integer = 0)
        Dim mSQL, mStatus, mEffDate_2, mExpDate_2 As String

        mSQL = ""
        If xDgv.Name = "dgvMain" Or xDgv.Name = "dgvHMain" Then
            mSQL = "select pl.RecID,pl.PriceID,pl.Customer,pl.Status,pl.EffDate,pl.ExpDate,pl.Note,pl.FstDate,pl.FstUser,pl.LstDate," &
                          "pl.LstUser,pl.ChangeNum " & vbLf &
                   "from DATA1A_PriceList pl " &
                     "left join MKTG_MIDT..DATA1A_Customers c on pl.Customer=c.ShortName And c.Status='OK' " &
                       "and c.Region ='" & pobjUser.Region & "' " & vbLf &
                   "where pl.City='" & pobjUser.City & "' "

            If xDgv.Name = "dgvMain" Then
                mEffDate_2 = dtpEffDate_2.Value.ToString("yyyyMM")
                mExpDate_2 = dtpExpDate_2.Value.ToString("yyyyMM")
                mSQL &= IIf(cboCustomer_2.Text <> "", "and pl.Customer='" & cboCustomer_2.SelectedValue & "' ", "") &
                        IIf(txtNote_2.Text <> "", "and pl.Note like N'%" & txtNote_2.Text & "%' ", "") &
                        IIf(cboEffDate.Text <> "", "and format(pl.EffDate,'yyyyMM')" & cboEffDate.Text & "'" & mEffDate_2 & "' ", "") &
                        IIf(cboExpDate.Text <> "", "and format(pl.ExpDate,'yyyyMM')" & cboExpDate.Text & "'" & mExpDate_2 & "' ", "") &
                        IIf(cboUser.SelectedValue = "All", "", "and c.PIC='" & cboUser.SelectedValue & "' ")

                mStatus = IIf(chkStatus.Checked, ",'XX'", "")
            ElseIf xDgv.Name = "dgvHMain" Then
                mSQL &= "and pl.PriceID=" & xPriceId.ToString & " "
                mStatus = ",'MO'"
            End If

            mSQL &= "and pl.Status in ('OK'" & mStatus & ") " & vbLf &
                    "order by pl.Customer" & IIf(xDgv.Name = "dgvHMain", ",pl.ChangeNum", "") & ",pl.EffDate"
        ElseIf xDgv.Name = "dgvDetail" Or xDgv.Name = "dgvIDetail" Or xDgv.Name = "dgvHDetail" Then
            mSQL = "select pld.RecID,pld.FromTheUser,pld.ToTheUser,pld.PricePerUser PricePerUser2,pld.PriceCombo,pld.Status," &
                          "pld.FstDate,pld.FstUser,pld.LstDate,pld.LstUser,pld.ChangeNum " & vbLf &
                   "from DATA1A_PriceListDetail pld " & vbLf &
                   "where pld.City='" & pobjUser.City & "' and pld.PriceID=" & xPriceId.ToString & " " &
                     "and pld.ChangeNum = " & xChangeNum.ToString & " "

            If xDgv.Name = "dgvDetail" Then
                mStatus = IIf(chkStatus.Checked, ",'XX'", "")
            ElseIf xDgv.Name = "dgvIDetail" Then
                mStatus = ""
            ElseIf xDgv.Name = "dgvHDetail" Then
                mStatus = ",'MO'"
            End If

            mSQL &= "and pld.Status in ('OK'" & mStatus & ") " & vbLf &
                    "order by pld.FromTheUser,pld.ToTheUser"
        End If

        pobjSql.LoadDataGridView(xDgv, mSQL)
        FormatDgv(xDgv)
    End Sub

    Private Sub FormatDgv(xDgv As DataGridView)
        xDgv.Columns("ChangeNum").Visible = False
        xDgv.Columns("FstDate").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"
        xDgv.Columns("LstDate").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"
        If xDgv.Name = "dgvMain" Or xDgv.Name = "dgvHMain" Then
            xDgv.Columns("EffDate").DefaultCellStyle.Format = "MM/yyyy"
            xDgv.Columns("ExpDate").DefaultCellStyle.Format = "MM/yyyy"
        ElseIf xDgv.Name = "dgvDetail" Or xDgv.Name = "dgvIDetail" Or xDgv.Name = "dgvHDetail" Then
            xDgv.Columns("FromTheUser").DefaultCellStyle.Format = DgvNumberFormat(xDgv, "FromTheUser")
            xDgv.Columns("ToTheUser").DefaultCellStyle.Format = DgvNumberFormat(xDgv, "ToTheUser")
            xDgv.Columns("PricePerUser").DisplayIndex = 3
            xDgv.Columns("PricePerUser").DataPropertyName = "PricePerUser2"
            xDgv.Columns("PricePerUser2").Visible = False
            xDgv.Columns("PricePerUser").DefaultCellStyle.Format = DgvNumberFormat(xDgv, "PricePerUser")
            xDgv.Columns("PriceCombo").DefaultCellStyle.Format = DgvNumberFormat(xDgv, "PriceCombo")
            xDgv.Sort(xDgv.Columns("FromTheUser"), ComponentModel.ListSortDirection.Ascending)

            If xDgv.Name = "dgvIDetail" Then
                xDgv.Columns("RecID").Visible = False
                xDgv.Columns("Status").Visible = False
                xDgv.Columns("FstDate").Visible = False
                xDgv.Columns("FstUser").Visible = False
                xDgv.Columns("LstDate").Visible = False
                xDgv.Columns("LstUser").Visible = False
            End If
        End If
    End Sub

    Private Sub cell_KeyDown(sender As Object, e As KeyPressEventArgs)
        If dgvIDetail.CurrentRow.Cells("FromTheUser").Selected Or dgvIDetail.CurrentRow.Cells("ToTheUser").Selected Or
           dgvIDetail.CurrentRow.Cells("PriceCombo").Selected Then
            PressInteger(e)
        End If
    End Sub

    Private Function CheckValue() As Boolean
        Dim mSQL, mStr As String,
            mDataTable As DataTable,
            mTmpNumOfUser, mFromTheUser, mToTheUser, i As Integer

        If dtpEffDate.Value.ToString("yyyyMM") > dtpExpDate.Value.ToString("yyyyMM") Then
            MsgBox("EffDate can't be newer than ExpDate!")
            Return False
        End If

        mSQL = "select pl.RecID,pl.Customer,format(pl.EffDate,'MM/yyyy') EffDate,format(pl.ExpDate,'MM/yyyy') ExpDate " & vbLf &
               "from DATA1A_PriceList pl " & vbLf &
               "where pl.Customer='" & cboCustomer.Text & "' and format(pl.EffDate,'yyyyMM')<='" & Strings.Left(FExpDate, 6) & "' " &
                 "and format(pl.ExpDate,'yyyyMM')>='" & Strings.Left(FEffDate, 6) & "' and pl.status='OK' " &
                 "and pl.City ='" & pobjUser.City & "' and pl.RecID<>'" & txtRecID.Text & "' "
        mDataTable = pobjSql.GetDataTable(mSQL)
        If mDataTable.Rows.Count > 0 Then
            MsgBox("RecID: " & mDataTable.Rows(0)("RecID") & vbLf &
                   "Customer:" & mDataTable.Rows(0)("Customer") & vbLf &
                   "EffDate: " & mDataTable.Rows(0)("EffDate") & vbLf &
                   "ExpDate: " & mDataTable.Rows(0)("ExpDate") & vbLf &
                   "Is duplicate!")
            Return False
        End If

        mTmpNumOfUser = 0
        mStr = ""
        For i = 0 To dgvIDetail.Rows.Count - 2
            If dgvIDetail.Rows(i).Cells("FromTheUser").Value - mTmpNumOfUser > 1 Then
                mFromTheUser = mTmpNumOfUser + 1
                mToTheUser = dgvIDetail.Rows(i).Cells("FromTheUser").Value - 1
                mStr &= IIf(mStr <> "", vbLf, "") & mFromTheUser.ToString & "->" & mToTheUser.ToString
            End If

            mTmpNumOfUser = dgvIDetail.Rows(i).Cells("ToTheUser").Value
        Next
        If mStr <> "" Then
            MsgBox("The user: " & vbLf & mStr & vbLf & "don't have price!")
            Return False
        End If

        Return True
    End Function

    Private Sub InsertMain()
        Dim mLstCol, mFstUser, mFstDate, mLstValue As String

        If txtRecID.Text = "" Or Not FDeletePower Then
            mLstCol = ""
            mLstValue = ""
            mFstDate = FDate
            mFstUser = pobjUser.UserName
        Else
            mLstCol = ",LstDate,LstUser"
            mLstValue = ",'" & FDate & "','" & pobjUser.UserName & "'"
            mFstDate = Format(dgvMain.CurrentRow.Cells("FstDate").Value, "yyyyMMdd hh:mm:ss")
            mFstUser = dgvMain.CurrentRow.Cells("FstUser").Value
        End If

        cmd.CommandText = "insert into DATA1A_PriceList(FstDate,FstUser,Status,PriceID,Customer," &
                                                           "Note,City,EffDate,ExpDate,ChangeNum" & mLstCol & ") " & vbLf &
                          "values('" & mFstDate & "','" & mFstUser & "','OK','" & txtPriceID.Text & "'," &
                                 "'" & cboCustomer.SelectedValue & "'," &
                                 "N'" & txtNote.Text & "','" & pobjUser.City & "','" & FEffDate & "','" & FExpDate & "'," &
                                 "" & FChangeNum.ToString & mLstValue & ")"
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub UpdateMain(Optional xIsDelete As Boolean = False)
        Dim mNewExpDate As String
        cmd.CommandText = "update DATA1A_PriceList " & vbLf &
                          "set "
        If xIsDelete Then
            cmd.CommandText &= "status='XX',LstDate='" & FDate & "',LstUser='" & pobjUser.UserName & "' "
        Else
            If FDeletePower Then
                cmd.CommandText &= "status='MO' "
            Else
                mNewExpDate = Format(dtpEffDate.Value.AddMonths(-1), "yyyyMM") &
                              DateTime.DaysInMonth(Year(dtpEffDate.Value.AddMonths(-1)), Month(dtpEffDate.Value.AddMonths(-1))).ToString
                cmd.CommandText &= "ExpDate='" & mNewExpDate & "',LstDate='" & FDate & "',LstUser='" & pobjUser.UserName & "' "
            End If
        End If
        cmd.CommandText &= vbLf & "where RecID=" & dgvMain.CurrentRow.Cells("RecID").Value.ToString & ""
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertDetail()
        Dim mLstCol, mFstUser, mFstDate, mLstValue, mFromTheUser, mToTheUser, mPricePerUser, mPriceCombo As String
        Dim i As Integer

        cmd.CommandText = ""
        mPricePerUser = "0"
        mPriceCombo = "0"
        For i = 0 To dgvIDetail.Rows.Count - 2
            If dgvIDetail.Rows(i).Cells("RecID").Value.ToString = "" Or Not FDeletePower Then
                mLstCol = ""
                mLstValue = ""
                mFstDate = FDate
                mFstUser = pobjUser.UserName
            Else
                mLstCol = ",LstDate,LstUser"
                mLstValue = ",'" & FDate & "','" & pobjUser.UserName & "'"
                mFstDate = Format(dgvIDetail.Rows(i).Cells("FstDate").Value, "yyyyMMdd hh:mm:ss")
                mFstUser = dgvIDetail.Rows(i).Cells("FstUser").Value
            End If

            mFromTheUser = dgvIDetail.Rows(i).Cells("FromTheUser").Value.ToString
            mToTheUser = dgvIDetail.Rows(i).Cells("ToTheUser").Value.ToString
            mPricePerUser = dgvIDetail.Rows(i).Cells("PricePerUser").Value.ToString
            mPriceCombo = dgvIDetail.Rows(i).Cells("PriceCombo").Value.ToString

            cmd.CommandText &= IIf(cmd.CommandText <> "", ";", "") &
                               "insert into DATA1A_PriceListDetail(FstDate,FstUser,Status,PriceID,FromTheUser," &
                                                                      "ToTheUser,PricePerUser,PriceCombo,City,ChangeNum" & mLstCol & ") " & vbLf &
                               "values('" & mFstDate & "','" & mFstUser & "','OK','" & txtPriceID.Text & "'," & mFromTheUser & "," &
                                      "" & mToTheUser & "," & mPricePerUser & "," & mPriceCombo & ",'" & pobjUser.City & "'," &
                                      "" & FChangeNum.ToString & mLstValue & ")"
        Next

        i -= 1
        If dgvIDetail.Rows(i).Cells("ToTheUser").Value < 9999 Then
            mFromTheUser = (dgvIDetail.Rows(i).Cells("ToTheUser").Value + 1).ToString
            cmd.CommandText &= IIf(cmd.CommandText <> "", ";", "") &
                               "insert into DATA1A_PriceListDetail(FstDate,FstUser,Status,PriceID,FromTheUser," &
                                                                      "ToTheUser,PricePerUser,PriceCombo,City,ChangeNum) " & vbLf &
                               "values('" & FDate & "','" & pobjUser.UserName & "','OK','" & txtPriceID.Text & "'," & mFromTheUser & "," &
                                      "9999," & mPricePerUser & "," & mPriceCombo & ",'" & pobjUser.City & "'," &
                                      "" & FChangeNum.ToString & ")"
        End If

        cmd.ExecuteNonQuery()
    End Sub

    Private Sub UpdateDetail(xDgv As DataGridView)
        Dim mRecID As String,
            i, mRow, j As Integer,
            mFound As Boolean

        mRecID = ""
        mRow = IIf(xDgv.Name = "dgvIDetail", xDgv.Rows.Count - 2, xDgv.Rows.Count - 1)
        If xDgv.Name = "dgvIDetail" Then
            mRow = xDgv.Rows.Count - 2

            For i = 0 To dgvDetail.Rows.Count - 1
                mFound = False
                For j = 0 To mRow
                    If dgvDetail.Rows(i).Cells("RecID").Value.ToString = xDgv.Rows(j).Cells("RecID").Value.ToString Then
                        mFound = True
                        Exit For
                    End If
                Next

                If Not mFound Then mRecID &= IIf(mRecID <> "", ",", "") & dgvDetail.Rows(i).Cells("RecID").Value.ToString
            Next
        Else
            mRow = xDgv.Rows.Count - 1
        End If

        For i = 0 To mRow
            If xDgv.Rows(i).Cells("RecID").Value.ToString <> "" Then mRecID &= IIf(mRecID <> "", ",", "") &
                                                                               xDgv.Rows(i).Cells("RecID").Value.ToString
        Next

        If mRecID <> "" Then
            cmd.CommandText = "update DATA1A_PriceListDetail " & vbLf &
                              "set "
            cmd.CommandText &= IIf(xDgv.Name = "dgvDetail", "status='XX',LstDate='" & FDate & "',LstUser='" & pobjUser.UserName & "' ",
                                                            "status='MO' ") & vbLf &
                               "where RecID in (" & mRecID & ")"
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub TabPageChange(xtabpage As TabPage)
        tcMain.TabPages.Clear()
        tcMain.TabPages.Add(xtabpage)
    End Sub

    Private Sub ButtomState()
        Dim mSQL, mEffDate, mExpDate, mPriceID As String
        Dim mEditPower, mHistoryPower As Boolean

        mEditPower = False
        FDeletePower = False
        If dgvMain.Rows.Count > 0 Then
            mEditPower = pobjUser.Role <> "User" Or cboCustomer_2.FindString(dgvMain.CurrentRow.Cells("Customer").Value) <> -1

            If mEditPower Then
                mEffDate = Format(dgvMain.CurrentRow.Cells("EffDate").Value, "yyyyMM")
                mExpDate = Format(dgvMain.CurrentRow.Cells("ExpDate").Value, "yyyyMM")
                mSQL = "select CP.RecID " & vbLf &
                        "from DATA1A_CalcPrice CP " &
                          "left join DATA1A_CalcPriceDetail CPD on CP.CPID=CPD.CPID And CPD.status='OK' " &
                            "and CPD.City ='" & pobjUser.City & "' " & vbLf &
                        "where CP.status='OK' and CP.City='" & pobjUser.City & "' and CP.ConfirmStatus='Y' " &
                          "And (format(CP.CPMonth,'yyyyMM') between '" & mEffDate & "' And '" & mExpDate & "') " &
                          "And CPD.Customer='" & dgvMain.CurrentRow.Cells("Customer").Value & "' and CPD.ErrDesc=''"
                FDeletePower = pobjSql.GetScalarAsString(mSQL) = ""
            End If
        End If
        llbEdit.Enabled = mEditPower
        llbDelete.Enabled = FDeletePower

        llbCopy.Enabled = dgvMain.Rows.Count > 0 And FAddPower

        mHistoryPower = False
        If dgvMain.Rows.Count > 0 Then
            mPriceID = dgvMain.CurrentRow.Cells("PriceID").Value.ToString
            mSQL = "select pl.RecID " & vbLf &
                   "from DATA1A_PriceList pl " & vbLf &
                   "where pl.Status='MO' and pl.City='" & pobjUser.City & "' and pl.PriceID=" & mPriceID & ""
            mHistoryPower = pobjSql.GetScalarAsString(mSQL) <> ""
        End If
        llbHistory.Enabled = mHistoryPower

        If dgvMain.Rows.Count > 0 Then
            LoadDgv(dgvDetail, dgvMain.CurrentRow.Cells("PriceID").Value, dgvMain.CurrentRow.Cells("ChangeNum").Value)
        Else
            LoadDgv(dgvDetail)
        End If
    End Sub

    Private Sub DefaultValue(xAction As FAction)
        Dim mMinEffDate As Date,
            mSQL, mCustomer, mEffDate, mExpDate As String,
            mDt As New DataTable,
            i As Integer

        dtpEffDate.MinDate = DateTimePicker.MinimumDateTime
        If xAction = FAction.Add Then
            DefaultControl(tpInput)
            txtPriceID.Text = DefaultID("PriceID", "DATA1A_PriceList", pobjSql)
            cboCustomer.Enabled = True
            LoadDgv(dgvIDetail)

            FChangeNum = 0
        ElseIf xAction = FAction.Edit Then
            DefaultControl(tpInput, dgvMain)
            cboCustomer.Enabled = False
            If Not FDeletePower Then
                mCustomer = dgvMain.CurrentRow.Cells("Customer").Value
                mEffDate = Format(dgvMain.CurrentRow.Cells("EffDate").Value, "yyyyMM")
                mExpDate = Format(dgvMain.CurrentRow.Cells("ExpDate").Value, "yyyyMM")
                mSQL = "select top 1 cp.CPMonth " & vbLf &
                       "from DATA1A_CalcPrice cp " &
                         "left join DATA1A_CalcPriceDetail cpd on cp.CPID=cpd.CPID And cpd.Status='OK' " &
                           "and cpd.City ='" & pobjUser.City & "' " & vbLf &
                       "where cpd.Customer='" & mCustomer & "' and cp.Status='OK' and cp.City='" & pobjUser.City & "' " &
                         "And format(cp.CPMonth,'yyyyMM') between '" & mEffDate & "' and '" & mExpDate & "'" & vbLf &
                       "order by cp.CPMonth desc"
                mDt = pobjSql.GetDataTable(mSQL)
                If mDt.Rows.Count > 0 Then
                    mMinEffDate = mDt.Rows(0)("CPMonth")
                Else
                    mMinEffDate = dgvMain.CurrentRow.Cells("EffDate").Value
                End If

                mEffDate = mMinEffDate.AddMonths(1)
                dtpEffDate.MinDate = mMinEffDate.Year.ToString & "/" & mMinEffDate.Month.ToString & "/01"
            End If
            LoadDgv(dgvIDetail, dgvMain.CurrentRow.Cells("PriceID").Value, dgvMain.CurrentRow.Cells("ChangeNum").Value)

            FChangeNum = IIf(FDeletePower, dgvMain.CurrentRow.Cells("ChangeNum").Value + 1, 0)
        ElseIf xAction = FAction.Copy Then
            DefaultControl(tpInput, dgvMain)
            txtRecID.Text = ""
            txtPriceID.Text = DefaultID("PriceID", "DATA1A_PriceList", pobjSql)
            cboCustomer.Enabled = True

            LoadDgv(dgvIDetail, dgvMain.CurrentRow.Cells("PriceID").Value, dgvMain.CurrentRow.Cells("ChangeNum").Value)
            For i = 0 To dgvIDetail.Rows.Count - 2
                dgvIDetail.Rows(i).Cells("RecID").Value = vbNull
            Next

            FChangeNum = 0
        End If
    End Sub

    Private Sub AddDgvCbo(xDgv As DataGridView)
        Dim mSQL As String
        Dim mCboPricePerUser As DataGridViewComboBoxColumn
        Dim mDt As DataTable

        mCboPricePerUser = New DataGridViewComboBoxColumn
        mCboPricePerUser.HeaderText = "PricePerUser"
        mCboPricePerUser.Name = "PricePerUser"
        mCboPricePerUser.DefaultCellStyle.Format = "N0"
        mSQL = "select convert(numeric(21,0),cpu.Price) Price " & vbLf &
               "from DATA1A_PricePerUser cpu" & vbLf &
               "where cpu.status='OK' and cpu.City='" & pobjUser.City & "' " & vbLf &
               "order by cpu.Price"
        mDt = pobjSql.GetDataTable(mSQL)
        mCboPricePerUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        For i = 0 To mDt.Rows.Count - 1
            mCboPricePerUser.Items.Add(mDt.Rows(i)(0))
        Next

        xDgv.Columns.Add(mCboPricePerUser)
    End Sub
#End Region

    Private Sub frmPriceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mSQL As String

        TabPageChange(tpLst)

        mSQL = "select distinct c.ShortName value " & vbLf &
               "from MKTG_MIDT..DATA1A_Customers c " & vbLf &
               "where c.status<>'XX' and c.Region='" & pobjUser.Region & "' and c.ShortName<>'' " &
                 IIf(pobjUser.Role = "User", "and c.PIC='" & pobjUser.UserName & "' ", "") & "" & vbLf &
               "order by value"
        pobjSql.LoadCombo(cboCustomer, mSQL)

        pobjSql.LoadCombo(cboCustomer_2, "select '' value " & vbLf &
                                         "union all " & vbLf &
                                         mSQL)
        FAddPower = pobjUser.Role <> "User" OrElse cboCustomer_2.Items.Count > 1
        llbAdd.Enabled = FAddPower

        mSQL = "select 'All' value " & vbLf &
               "union all " & vbLf &
               "select distinct u.UserName value " & vbLf &
               "from MKTG_MIDT..DATA1A_User u " & vbLf &
               "where u.status='OK' and u.City='" & pobjUser.City & "'"
        pobjSql.LoadCombo(cboUser, mSQL)
        cboUser.SelectedValue = pobjUser.UserName

        AddDgvCbo(dgvDetail)
        AddDgvCbo(dgvIDetail)
        AddDgvCbo(dgvHDetail)

        LoadDgv(dgvMain)
        If dgvMain.Rows.Count = 0 Then LoadDgv(dgvDetail)

        cmd.Connection = pobjSql.Connection
    End Sub

    Private Sub dgvMain_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMain.SelectionChanged
        ButtomState()
    End Sub

    Private Sub llbAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbAdd.LinkClicked
        TabPageChange(tpInput)
        DefaultValue(FAction.Add)
    End Sub

    Private Sub llbOK_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbOK.LinkClicked
        FEffDate = dtpEffDate.Value.ToString("yyyyMM") & "01"
        FExpDate = dtpExpDate.Value.ToString("yyyyMM") & DateTime.DaysInMonth(dtpExpDate.Value.Year, dtpExpDate.Value.Month).ToString
        FDate = Format(Now, "yyyyMMdd hh:mm:ss")

        If Not CheckValue() Then Exit Sub

        LTrans = pobjSql.Connection.BeginTransaction
        cmd.Transaction = LTrans
        Try
            InsertMain()
            If txtRecID.Text <> "" Then UpdateMain()
            If dgvIDetail.Rows.Count > 1 Then
                InsertDetail()
                UpdateDetail(dgvIDetail)
            End If

            LTrans.Commit()
        Catch ex As Exception
            MsgBox(ex.Message)
            LTrans.Rollback()
        End Try

        TabPageChange(tpLst)
        LoadDgv(dgvMain)
    End Sub

    Private Sub dgvIDetail_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvIDetail.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf cell_KeyDown
    End Sub

    Private Sub llbCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCancel.LinkClicked, llbBack.LinkClicked
        TabPageChange(tpLst)
    End Sub

    Private Sub llbEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbEdit.LinkClicked
        If Not FDeletePower AndAlso MsgBox("This row had used in CalcPrice, will be add new stage!", vbYesNo) = vbNo Then Exit Sub
        TabPageChange(tpInput)
        DefaultValue(FAction.Edit)
    End Sub

    Private Sub llbDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDelete.LinkClicked
        If MsgBox("Delete this row?", vbYesNo) = vbNo Then Exit Sub
        FDate = Format(Now, "yyyyMMdd hh:mm:ss")

        LTrans = pobjSql.Connection.BeginTransaction
        cmd.Transaction = LTrans
        Try
            UpdateMain(True)
            UpdateDetail(dgvDetail)

            LTrans.Commit()
        Catch ex As Exception
            MsgBox(ex.Message)
            LTrans.Rollback()
        End Try

        LoadDgv(dgvMain)
    End Sub

    Private Sub cboEffDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEffDate.SelectedIndexChanged
        If cboEffDate.Text <> "" Then
            dtpEffDate_2.Enabled = True
        Else
            dtpEffDate_2.Enabled = False
        End If
    End Sub

    Private Sub cboExpDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExpDate.SelectedIndexChanged
        If cboExpDate.Text <> "" Then
            dtpExpDate_2.Enabled = True
        Else
            dtpExpDate_2.Enabled = False
        End If
    End Sub

    Private Sub llbSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSearch.LinkClicked
        LoadDgv(dgvMain)
    End Sub

    Private Sub dgvHMain_SelectionChanged(sender As Object, e As EventArgs) Handles dgvHMain.SelectionChanged
        LoadDgv(dgvHDetail, dgvHMain.CurrentRow.Cells("PriceID").Value, dgvHMain.CurrentRow.Cells("ChangeNum").Value)
    End Sub

    Private Sub dgvHMain_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvHMain.DataSourceChanged
        LoadDgv(dgvHDetail, dgvHMain.CurrentRow.Cells("PriceID").Value, dgvHMain.CurrentRow.Cells("ChangeNum").Value)
    End Sub

    Private Sub dtpEffDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEffDate.ValueChanged, dtpExpDate_2.ValueChanged, dtpExpDate.ValueChanged, dtpEffDate_2.ValueChanged
        sender.Value = New DateTime(sender.Value.Year, sender.Value.Month, 1)
    End Sub

    Private Sub dgvMain_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvMain.DataSourceChanged
        ButtomState()
    End Sub

    Private Sub llbReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbReset.LinkClicked
        DefaultControl(tpLst)
        cboUser.SelectedValue = pobjUser.UserName
        LoadDgv(dgvMain)
    End Sub

    Private Sub llbCopy_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCopy.LinkClicked
        TabPageChange(tpInput)
        DefaultValue(FAction.Copy)
    End Sub

    Private Sub llbHistory_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbHistory.LinkClicked
        TabPageChange(tpHistory)
        LoadDgv(dgvHMain, dgvMain.CurrentRow.Cells("PriceID").Value, dgvMain.CurrentRow.Cells("ChangeNum").Value)
    End Sub

    Private Sub dgvIDetail_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvIDetail.RowValidating
        Dim i, mFromTheUser, mToTheUser, mCurFromTheUser, mCurToTheUser As Integer

        If dgvIDetail.CurrentRow.IsNewRow Then Exit Sub

        If dgvIDetail.CurrentRow.Cells("FromTheUser").Value.ToString = "" Then dgvIDetail.CurrentRow.Cells("FromTheUser").Value = 1
        If dgvIDetail.CurrentRow.Cells("ToTheUser").Value.ToString = "" Then dgvIDetail.CurrentRow.Cells("ToTheUser").Value = 1
        If dgvIDetail.CurrentRow.Cells("PricePerUser").Value.ToString = "" Then dgvIDetail.CurrentRow.Cells("PricePerUser").Value = 0
        If dgvIDetail.CurrentRow.Cells("PriceCombo").Value.ToString = "" Then dgvIDetail.CurrentRow.Cells("PriceCombo").Value = 0

        If dgvIDetail.CurrentRow.Cells("FromTheUser").Value > dgvIDetail.CurrentRow.Cells("ToTheUser").Value Then
            MsgBox("FromTheUser can't bigger than ToTheUser!")
            e.Cancel = True
        End If

        If dgvIDetail.CurrentRow.Cells("PricePerUser").Value <> 0 And dgvIDetail.CurrentRow.Cells("PriceCombo").Value <> 0 Then
            MsgBox("PricePerUser and PriceCombo only apply one!")
            e.Cancel = True
        End If

        mCurFromTheUser = dgvIDetail.CurrentRow.Cells("FromTheUser").Value
        mCurToTheUser = dgvIDetail.CurrentRow.Cells("ToTheUser").Value
        For i = 0 To dgvIDetail.Rows.Count - 2
            If i <> dgvIDetail.CurrentRow.Index Then
                mFromTheUser = dgvIDetail.Rows(i).Cells("FromTheUser").Value
                mToTheUser = dgvIDetail.Rows(i).Cells("ToTheUser").Value
                If mCurToTheUser >= mFromTheUser And mCurFromTheUser <= mToTheUser Then
                    MsgBox("FromTheUser: " & mFromTheUser.ToString & vbLf &
                           "ToTheUser: " & mToTheUser & vbLf &
                           "is duplicate!")
                    e.Cancel = True
                    Exit For
                End If
            End If
        Next
    End Sub
End Class