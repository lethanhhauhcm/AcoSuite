'20220526 add by 7643
Imports System.Globalization
Imports Microsoft.VisualBasic.Devices

Public Class frmSecoOffer
    Private FChangeNum As Integer
    Private FDate, FEffDate, FExpDate As String
    Private FAddPower, FDeletePower As Boolean
    Private FPrice As Double

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

    Private Function CheckCustDup(xCustomer As String) As Boolean
        Dim mSQL As String,
            mDataTable As New DataTable

        mSQL = "select pl.RecID,pl.Customer,format(pl.EffDate,'MM/yyyy') EffDate,format(pl.ExpDate,'MM/yyyy') ExpDate " & vbLf &
               "from DATA1A_PriceList pl " & vbLf &
               "where pl.Customer='" & xCustomer & "' and format(pl.EffDate,'yyyyMM')<='" & Strings.Left(FExpDate, 6) & "' " &
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

        Return True
    End Function

    Private Function CheckValue() As Boolean
        Dim mSQL, mStr As String,
            mDataTable As DataTable,
            mTmpNumOfUser, mFromTheUser, mToTheUser, i, j As Integer

        If dtpEffDate.Value.ToString("yyyyMM") > dtpExpDate.Value.ToString("yyyyMM") Then
            MsgBox("EffDate can't be newer than ExpDate!")
            Return False
        End If

        '^_^20220815 mark by 7643 -b-
        'mSQL = "select pl.RecID,pl.Customer,format(pl.EffDate,'MM/yyyy') EffDate,format(pl.ExpDate,'MM/yyyy') ExpDate " & vbLf &
        '       "from DATA1A_PriceList pl " & vbLf &
        '       "where pl.Customer='" & cboCustomer.Text & "' and format(pl.EffDate,'yyyyMM')<='" & Strings.Left(FExpDate, 6) & "' " &
        '         "and format(pl.ExpDate,'yyyyMM')>='" & Strings.Left(FEffDate, 6) & "' and pl.status='OK' " &
        '         "and pl.City ='" & pobjUser.City & "' and pl.RecID<>'" & txtRecID.Text & "' "
        'mDataTable = pobjSql.GetDataTable(mSQL)
        'If mDataTable.Rows.Count > 0 Then
        '    MsgBox("RecID: " & mDataTable.Rows(0)("RecID") & vbLf &
        '           "Customer:" & mDataTable.Rows(0)("Customer") & vbLf &
        '           "EffDate: " & mDataTable.Rows(0)("EffDate") & vbLf &
        '           "ExpDate: " & mDataTable.Rows(0)("ExpDate") & vbLf &
        '           "Is duplicate!")
        '    Return False
        'End If

        'If ScalarToString("DATA1A_Customers c", "RecID",
        '                  "c.status<>'XX' and c.Region='" & pobjUser.Region & "' and c.ShortName='" & cboCustomer.Text & "' " &
        '                  IIf(pobjUser.Role = "User", "and c.PIC='" & pobjUser.UserName & "' ", "") & "", pobjSql.Connection) = "" Then
        '    MsgBox("Customer not available!")
        '    Return False
        'End If
        '^_^20220815 mark by 7643 -e-
        '^_^20220815 modi by 7643 -b-
        If txtRecID.Text = "" Then
            If lstCustomer.Visible = False Then
                If Not CheckCustDup(cboCustomer.Text) Then Return False

                If ScalarToString("DATA1A_Customers c", "RecID",
                          "c.status<>'XX' and c.Region='" & pobjUser.Region & "' and c.ShortName='" & cboCustomer.Text & "' " &
                          IIf(pobjUser.Role = "User", "and c.PIC='" & pobjUser.UserName & "' ", "") & "", pobjSql.Connection) = "" Then
                    MsgBox("Customer not available!")
                    Return False
                End If
            Else
                For i = 0 To lstCustomer.SelectedItems.Count - 1
                    If Not CheckCustDup(lstCustomer.SelectedItems(i)("value")) Then Return False
                Next
            End If
        End If
        '^_^20220815 modi by 7643 -e-

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

        For i = 0 To dgvIDetail.Rows.Count - 2
            For j = i + 1 To dgvIDetail.Rows.Count - 2
                If dgvIDetail.Rows(i).Cells("ToTheUser").Value >= dgvIDetail.Rows(j).Cells("FromTheUser").Value And
                    dgvIDetail.Rows(i).Cells("FromTheUser").Value <= dgvIDetail.Rows(j).Cells("ToTheUser").Value Then
                    MsgBox("NumOfUser is duplicate!")
                    Return False
                End If

                'If dgvIDetail.Rows(i).Cells("PricePerUser").Value = dgvIDetail.Rows(j).Cells("PricePerUser").Value And
                '    dgvIDetail.Rows(i).Cells("PriceCombo").Value = dgvIDetail.Rows(j).Cells("PriceCombo").Value And
                '    dgvIDetail.Rows(j).Cells("ToTheUser").Value <> 9999 Then
                '    MsgBox("Price is duplicate!")
                '    Return False
                'End If
            Next
        Next

        Return True
    End Function

    Private Sub InsertMain(xPriceID As String, xCustomer As String)
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
                          "values('" & mFstDate & "','" & mFstUser & "','OK','" & xPriceID & "'," &
                                 "'" & xCustomer & "'," &
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

    Private Sub InsertDetail(xPriceID As String)
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
                               "values('" & mFstDate & "','" & mFstUser & "','OK','" & xPriceID & "'," & mFromTheUser & "," &
                                      "" & mToTheUser & "," & mPricePerUser & "," & mPriceCombo & ",'" & pobjUser.City & "'," &
                                      "" & FChangeNum.ToString & mLstValue & ")"
        Next

        i -= 1
        If dgvIDetail.Rows(i).Cells("ToTheUser").Value < 9999 Then
            mFromTheUser = (dgvIDetail.Rows(i).Cells("ToTheUser").Value + 1).ToString
            cmd.CommandText &= IIf(cmd.CommandText <> "", ";", "") &
                               "insert into DATA1A_PriceListDetail(FstDate,FstUser,Status,PriceID,FromTheUser," &
                                                                      "ToTheUser,PricePerUser,PriceCombo,City,ChangeNum) " & vbLf &
                               "values('" & FDate & "','" & pobjUser.UserName & "','OK','" & xPriceID & "'," & mFromTheUser & "," &
                                      "9999," & FPrice & ",0,'" & pobjUser.City & "'," &
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
            Try
                mRecID &= IIf(mRecID <> "", ",", "") & CStr(xDgv.Rows(i).Cells("RecID").Value)
            Catch
            End Try
        Next

        If mRecID <> "" And FDeletePower Then
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
            mEditPower = pobjUser.Role <> "User" OrElse pobjUser.HasRight("Action", "Seco", "EditSecoOffer")

            If mEditPower Then
                mEffDate = Format(dgvMain.CurrentRow.Cells("EffDate").Value, "yyyyMM")
                mExpDate = Format(dgvMain.CurrentRow.Cells("ExpDate").Value, "yyyyMM")
                mSQL = "select CP.RecID " & vbLf &
                        "from DATA1A_CalcPrice CP " &
                          "left join DATA1A_CalcPriceDetail CPD on CP.CPID=CPD.CPID And CPD.status='OK' " &
                            "and CPD.City ='" & pobjUser.City & "' " & vbLf &
                        "where CP.status='OK' and CP.City='" & pobjUser.City & "' " &
                          "And (format(CP.CPMonth,'yyyyMM') between '" & mEffDate & "' And '" & mExpDate & "') " &
                          "And CPD.Customer='" & dgvMain.CurrentRow.Cells("Customer").Value & "' and cpd.PriceID=" & dgvMain.CurrentRow.Cells("PriceID").Value
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
            cboCustomer.Enabled = True
            lstCustomer.Visible = False  '^_^20220815 add by 7643
            LoadDgv(dgvIDetail)

            FChangeNum = 0
        ElseIf xAction = FAction.Edit Then
            DefaultControl(tpInput, dgvMain)
            cboCustomer.Enabled = False
            cboCustomer.Text = dgvMain.CurrentRow.Cells("Customer").Value
            lstCustomer.Visible = False  '^_^20220815 add by 7643
            If Not FDeletePower Then
                mCustomer = dgvMain.CurrentRow.Cells("Customer").Value
                mEffDate = Format(dgvMain.CurrentRow.Cells("EffDate").Value, "yyyyMM")
                mExpDate = Format(dgvMain.CurrentRow.Cells("ExpDate").Value, "yyyyMM")
                mSQL = "select top 1 cp.CPMonth " & vbLf &
                       "from DATA1A_CalcPrice cp " &
                         "left join DATA1A_CalcPriceDetail cpd on cp.CPID=cpd.CPID And cpd.Status='OK' " &
                           "and cpd.City ='" & pobjUser.City & "' " & vbLf &
                       "where cpd.Customer='" & mCustomer & "' and cp.Status='OK' and cp.City='" & pobjUser.City & "' " &
                         "And format(cp.CPMonth,'yyyyMM') between '" & mEffDate & "' and '" & mExpDate & "' " &
                         "and cpd.PriceID = " & dgvMain.CurrentRow.Cells("PriceID").Value & vbLf &
                       "order by cp.CPMonth desc"
                mDt = pobjSql.GetDataTable(mSQL)
                If mDt.Rows.Count > 0 Then
                    mMinEffDate = mDt.Rows(0)("CPMonth")
                Else
                    mMinEffDate = dgvMain.CurrentRow.Cells("EffDate").Value
                End If

                mMinEffDate = mMinEffDate.AddMonths(1)
                dtpEffDate.MinDate = mMinEffDate.Year.ToString & "/" & mMinEffDate.Month.ToString & "/01"
            End If
            LoadDgv(dgvIDetail, dgvMain.CurrentRow.Cells("PriceID").Value, dgvMain.CurrentRow.Cells("ChangeNum").Value)

            FChangeNum = IIf(FDeletePower, dgvMain.CurrentRow.Cells("ChangeNum").Value + 1, 0)
        ElseIf xAction = FAction.Copy Then
            DefaultControl(tpInput, dgvMain)
            txtRecID.Text = ""
            txtPriceID.Text = ""
            cboCustomer.Enabled = True
            lstCustomer.Visible = True  '^_^20220815 add by 7643

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
        mSQL = "Select convert(numeric(21, 0),cpu.Price) Price " & vbLf &
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

    '^_^20221024 add by 7643 -b-
    Private Sub LoadComboBox()
        Dim mSQL As String

        '^_^20220826 mark by 7643 -b-
        'mSQL = "select distinct c.ShortName value " & vbLf &
        '       "from MKTG_MIDT..DATA1A_Customers c " & vbLf &
        '       "where c.status<>'XX' and c.Region='" & pobjUser.Region & "' and c.ShortName<>'' " &
        '         IIf(pobjUser.Role <> "Admin", "and c.PIC='" & pobjUser.UserName & "' ", "") & "" & vbLf &
        '       "order by value"
        '^_^20220826 mark by 7643 -e-
        '"where pl.EffDate<='" & Strings.Left(dtpExpDate.Value.ToString("yyyyMM"), 6) & "' " &
        '^_^20220826 modi by 7643 -b-
        '^_^20230130 mark by 7643 -b-
        'mSQL = "select distinct c.ShortName value " &
        '       "from MKTG_MIDT..DATA1A_Customers c " &
        '       "where c.status<>'XX' and c.Region='" & pobjUser.Region & "' and c.ShortName<>'' " &
        '         IIf(pobjUser.Role <> "Admin", "and c.PIC='" & pobjUser.UserName & "' ", "") &
        '       "except " &
        '       "select pl.Customer " &
        '       "from DATA1A_PriceList pl " &
        '       "where pl.EffDate<='" & Format(dtpExpDate.Value, "01-MMM-yyyy") & "' " &
        '         "and pl.ExpDate>='" & Format(dtpEffDate.Value, "01-MMM-yyyy") & "' and pl.status ='OK' and pl.City ='" & pobjUser.City & "' " &
        '         "and pl.RecID <>'" & txtRecID.Text & "' " &
        '       "order by value"
        ''^_^20220826 modi by 7643 -e-
        'pobjSql.LoadCombo(cboCustomer, mSQL)
        'pobjSql.LoadListbox(lstCustomer, mSQL)  '^_^20220815 add by 7643
        '^_^20230130 mark by 7643 -e-

        mSQL = "select distinct c.ShortName value " &
               "from MKTG_MIDT..DATA1A_Customers c " &
               "where c.status<>'XX' and c.Region='" & pobjUser.Region & "' and c.ShortName<>'' " &
                 IIf(pobjUser.Role = "User", "and c.PIC='" & pobjUser.UserName & "' ", "") &
               "order by value"
        pobjSql.LoadCombo(cboCustomer_2, "select '' value union all " & mSQL)

        mSQL = "select 'All' value " &
               "union all " &
               "select distinct u.UserName value " &
               "from MKTG_MIDT..DATA1A_User u " &
               "where u.status='OK' and u.City='" & pobjUser.City & "' order by value"
        pobjSql.LoadCombo(cboUser, mSQL)
    End Sub
    '^_^20221024 add by 7643 -e-
#End Region

    Private Sub frmSecoOffer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPageChange(tpLst)
        LoadComboBox()

        FAddPower = pobjUser.Role <> "User" OrElse cboCustomer_2.Items.Count > 1
        llbAdd.Enabled = FAddPower

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
        LoadCustomer(True)
        DefaultValue(FAction.Add)
        tpInput.Tag = "Add"
    End Sub

    Private Sub llbOK_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbOK.LinkClicked
        Dim mPriceID As String,
            i As Integer

        FEffDate = dtpEffDate.Value.ToString("yyyyMM") & "01"
        FExpDate = dtpExpDate.Value.ToString("yyyyMM") & DateTime.DaysInMonth(dtpExpDate.Value.Year, dtpExpDate.Value.Month).ToString
        FDate = Format(Now, "yyyyMMdd hh:mm:ss")

        If Not CheckValue() Then Exit Sub

        FPrice = ScalarToString("DATA1A_PricePerUser", "max(Price) MPrice", "Status='OK'", pobjSql.Connection)
        '^_^20220815 mark by 7643 -b-
        'mPriceID = Integer.Parse(IIf(txtPriceID.Text <> "", txtPriceID.Text, DefaultID("PriceID", "DATA1A_PriceList", pobjSql)))

        'LTrans = pobjSql.Connection.BeginTransaction
        'cmd.Transaction = LTrans
        'Try
        '    InsertMain(mPriceID.ToString)
        '    If txtRecID.Text <> "" Then UpdateMain()
        '    If dgvIDetail.Rows.Count > 1 Then
        '        InsertDetail(mPriceID.ToString)
        '        If txtRecID.Text <> "" Then UpdateDetail(dgvIDetail)
        '    End If

        '    LTrans.Commit()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    LTrans.Rollback()
        'End Try
        '^_^20220815 mark by 7643 -e-
        '^_^20220815 modi by 7643 -b-
        If lstCustomer.Visible = False Then
            mPriceID = CInt(IIf(txtPriceID.Text <> "" And txtPriceID.Text <> "0", txtPriceID.Text, DefaultID("PriceID", "DATA1A_PriceList", pobjSql)))

            LTrans = pobjSql.Connection.BeginTransaction
            cmd.Transaction = LTrans
            Try
                InsertMain(mPriceID, cboCustomer.Text)
                If txtRecID.Text <> "" Then UpdateMain()
                If dgvIDetail.Rows.Count > 1 Then
                    InsertDetail(mPriceID.ToString)
                    If txtRecID.Text <> "" Then UpdateDetail(dgvIDetail)
                End If

                LTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.Message)
                LTrans.Rollback()
            End Try
        Else
            LTrans = pobjSql.Connection.BeginTransaction
            cmd.Transaction = LTrans
            Try
                For i = 0 To lstCustomer.SelectedItems.Count - 1
                    cmd.CommandText = "select isnull(max(PriceID),0) MPriceID from DATA1A_PriceList"
                    mPriceID = cmd.ExecuteScalar + 1

                    InsertMain(mPriceID.ToString, lstCustomer.SelectedItems(i)("value"))
                    If txtRecID.Text <> "" Then UpdateMain()
                    If dgvIDetail.Rows.Count > 1 Then
                        InsertDetail(mPriceID.ToString)
                        If txtRecID.Text <> "" Then UpdateDetail(dgvIDetail)
                    End If

                Next

                LTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.Message)
                LTrans.Rollback()
            End Try
        End If
        '^_^20220815 modi by 7643 -e-

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
        '^_^20230203 add by 7643 -b-
        Dim mMultiEdit As frmSecoOffer_MultiEdit
        Dim i, j, mPriceID As Integer
        Dim mSQL, mCust, mCPMonth, mCusts, mStr, mDate, mRecID, mEffDate, mUser As String
        Dim mReturn As New DataTable
        Dim mFound As Boolean
        Dim mPriceListDetail As New List(Of String)
        '^_^20230203 add by 7643 -e-

        If dgvMain.SelectedRows.Count < 2 Then  '^_^20230203 add by 7643
            mPriceID = dgvMain.CurrentRow.Cells("PriceID").Value
            mRecID = dgvMain.CurrentRow.Cells("RecID").Value
            If Not FDeletePower Then
                If MsgBox("This row had used in CalcPrice, will be add new stage!", vbYesNo) = vbNo Then
                    Exit Sub
                Else
                    mPriceID = 0
                    'mRecID = ""
                    tpInput.Tag = "Edit2"
                End If
            End If
            TabPageChange(tpInput)
            'LoadCustomer(False)
            DefaultValue(FAction.Edit)
            'txtRecID.Text = mRecID
            txtPriceID.Text = mPriceID
            tpInput.Tag = "Edit"
            '^_^20230203 add by 7643 -b-
        Else
            mMultiEdit = New frmSecoOffer_MultiEdit
            mMultiEdit.FdgvTemp = dgvMain

            mMultiEdit.FLstCalcPrice.Clear()
            For i = 0 To dgvMain.SelectedRows.Count - 1
                mCust = dgvMain.SelectedRows(i).Cells("Customer").Value
                mSQL = String.Format("select cpd.RecID,cp.CPMonth " &
                                     "from DATA1A_CalcPriceDetail cpd left join DATA1A_CalcPrice cp on cpd.CPID=cp.CPID And cp.Status='OK' and cp.City=cpd.City " &
                                     "where cpd.Status='OK' and cpd.City='{0}' and cpd.Customer='{1}' and cp.CPMonth between '{2}' and '{3}' and cpd.PriceID={4}",
                                     {pobjUser.City, mCust, Format(dgvMain.SelectedRows(i).Cells("EffDate").Value, "yyyyMMdd"),
                                        Format(dgvMain.SelectedRows(i).Cells("ExpDate").Value, "yyyyMMdd"), dgvMain.SelectedRows(i).Cells("PriceID").Value})
                mReturn = GetDataTable(mSQL, pobjSql.Connection)
                For j = 0 To mReturn.Rows.Count - 1
                    mFound = False
                    mCPMonth = Format(mReturn.Rows(j)("CPMonth"), "yyyyMMdd")
                    For t = 0 To mMultiEdit.FLstCalcPrice.Count - 1
                        If mMultiEdit.FLstCalcPrice(t).Split(vbTab)(0) = mCPMonth Then
                            mMultiEdit.FLstCalcPrice(t) = mMultiEdit.FLstCalcPrice(t) & "," & mCust
                            mFound = True
                            Exit For
                        End If
                    Next

                    If Not mFound Then mMultiEdit.FLstCalcPrice.Add(mCPMonth & vbTab & mCust)
                Next
            Next
            mMultiEdit.FLstCalcPrice.Sort()

            mCusts = ""
            For i = 0 To mMultiEdit.FLstCalcPrice.Count - 1
                mStr = mMultiEdit.FLstCalcPrice(i).Split(vbTab)(1)
                For j = 0 To mStr.Split(",").Length - 1
                    mCust = mStr.Split(",")(j)
                    If Not mCusts.Contains(mCust) Then mCusts &= IIf(mCusts <> "", ",", "") & mCust
                Next
            Next
            If mCusts <> "" Then
                MsgBox(mCusts & " has been calculated price, can not edit SecoOfferDetail!")
                mMultiEdit.lblEffDate.Visible = False
                mMultiEdit.dtpEffDate.Visible = False
                mMultiEdit.dtpEffDate.Value = Date.ParseExact(mMultiEdit.FLstCalcPrice(0).Split(vbTab)(0), "yyyyMMdd", Nothing)
                mMultiEdit.dtpExpDate.MinDate = Date.ParseExact(mMultiEdit.FLstCalcPrice(mMultiEdit.FLstCalcPrice.Count - 1).Split(vbTab)(0), "yyyyMMdd", Nothing)
                mMultiEdit.dgvDetail.Visible = False
            End If

            mMultiEdit.ShowDialog()
            If mMultiEdit.DialogResult = DialogResult.OK Then
                Try
                    BeginTrans()

                    mDate = Format(Now, "yyyyMMdd hh:mm:ss")
                    mUser = pobjUser.UserName
                    For i = 0 To dgvMain.SelectedRows.Count - 1
                        'Insert main
                        mEffDate = IIf(mMultiEdit.FLstCalcPrice.Count > 0, Format(dgvMain.SelectedRows(i).Cells("EffDate").Value, "yyyyMM01"), mMultiEdit.FEffDate)
                        mRecID = dgvMain.SelectedRows(i).Cells("RecID").Value
                        mPriceID = dgvMain.SelectedRows(i).Cells("PriceID").Value
                        cmd.CommandText = String.Format("insert into DATA1A_PriceList(FstDate,FstUser,LstDate,LstUser,PriceID,Customer,Note,City,EffDate,ExpDate," &
                                                            "ChangeNum) " &
                                                        "select FstDate,FstUser,'{0}','{1}',PriceID,Customer,'{2}',City,'{3}','{4}',ChangeNum+1 " &
                                                        "from DATA1A_PriceList " &
                                                        "where RecID={5}",
                                                        {mDate, mUser, mMultiEdit.txtNote.Text, mEffDate, mMultiEdit.FExpDate, mRecID})
                        cmd.ExecuteNonQuery()

                        'Delete main
                        cmd.CommandText = String.Format("update DATA1A_PriceList set Status='MO' where RecID={0}", {mRecID})
                        cmd.ExecuteNonQuery()

                        'Insert detaill
                        If mMultiEdit.FLstCalcPrice.Count > 0 Then
                            cmd.CommandText = String.Format("insert into DATA1A_PriceListDetail(FstDate,FstUser,LstDate,LstUser,PriceID,FromTheUser,ToTheUser," &
                                                                "PricePerUser,PriceCombo,City,ChangeNum) " &
                                                            "select FstDate,FstUser,'{0}','{1}',PriceID,FromTheUser,ToTheUser,PricePerUser,PriceCombo,City," &
                                                                "ChangeNum+1 " &
                                                            "from DATA1A_PriceListDetail " &
                                                            "where Status='OK' and PriceID={2}",
                                                            {mDate, mUser, mPriceID})
                            cmd.ExecuteNonQuery()
                        Else
                            For j = 0 To mMultiEdit.dgvDetail.Rows.Count - 2
                                cmd.CommandText = String.Format("insert into DATA1A_PriceListDetail(FstDate,FstUser,LstDate,LstUser,PriceID,FromTheUser,ToTheUser," &
                                                                    "PricePerUser,PriceCombo,City,ChangeNum) " &
                                                                "values('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},'{9}',{10})",
                                                                {Format(dgvMain.SelectedRows(i).Cells("FstDate").Value, "yyyyMMdd hh:mm:ss"),
                                                                    dgvMain.SelectedRows(i).Cells("FstUser").Value,
                                                                    mDate, mUser, mPriceID, CInt(mMultiEdit.dgvDetail.Rows(j).Cells("FromTheUser").Value),
                                                                    CInt(mMultiEdit.dgvDetail.Rows(j).Cells("ToTheUser").Value),
                                                                    CInt(mMultiEdit.dgvDetail.Rows(j).Cells("PricePerUser").Value),
                                                                    CInt(mMultiEdit.dgvDetail.Rows(j).Cells("PriceCombo").Value),
                                                                    pobjUser.City, dgvMain.SelectedRows(i).Cells("ChangeNum").Value + 1})
                                cmd.ExecuteNonQuery()
                            Next
                        End If

                        'Delete detail
                        cmd.CommandText = String.Format("update DATA1A_PriceListDetail set Status='MO' where PriceID={0} And Status='OK' and LstDate<'{1}'",
                                                        {mPriceID, mDate})
                        cmd.ExecuteNonQuery()
                    Next

                    CommitTrans()
                    LoadDgv(dgvMain)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    RollbackTrans()
                End Try
            End If
        End If
        '^_^20230203 add by 7643 -e-
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

    Private Sub dgvMain_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvMain.DataSourceChanged
        ButtomState()
    End Sub

    Private Sub llbReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbReset.LinkClicked
        DefaultControl(tpLst)
        cboUser.SelectedValue = pobjUser.UserName
        LoadDgv(dgvMain)
    End Sub

    Private Sub dtpEffDate_Validated(sender As Object, e As EventArgs) Handles dtpEffDate.Validated
        Dim mSQL As String  '^_^20220826 add by 7643

        sender.Value = New DateTime(sender.Value.Year, sender.Value.Month, 1)

        '^_^20220826 add by 7643 -b-
        If txtRecID.Text = "" Then
            mSQL = "select distinct c.ShortName value " & vbLf &
                   "from MKTG_MIDT..DATA1A_Customers c " & vbLf &
                   "where c.status<>'XX' and c.Region='" & pobjUser.Region & "' and c.ShortName<>'' " &
                     IIf(pobjUser.Role <> "Admin", "and c.PIC='" & pobjUser.UserName & "' ", "") & "" & vbLf &
                   "except" & vbLf &
                   "select pl.Customer " & vbLf &
                   "from DATA1A_PriceList pl " & vbLf &
                   "where format(pl.EffDate,'yyyyMM')<='" & Strings.Left(dtpExpDate.Value.ToString("yyyyMM"), 6) & "' " & vbLf &
                     "and Format(pl.ExpDate,'yyyyMM')>='" & Strings.Left(dtpEffDate.Value.ToString("yyyyMM"), 6) & "' and pl.status ='OK' " & vbLf &
                     "and pl.City ='" & pobjUser.City & "' and pl.RecID <>'" & txtRecID.Text & "'" & vbLf &
                   "order by value"
            pobjSql.LoadCombo(cboCustomer, mSQL)
            pobjSql.LoadListbox(lstCustomer, mSQL)
        End If
        '^_^20220826 add by 7643 -e-
    End Sub

    Private Sub LoadCustomer(xAdd As Boolean)
        '^_^20230130 add by 7643 -b-
        Dim mSQL As String

        If tcMain.TabPages(0).Name.ToLower = "tpinput" Then
            mSQL = "select distinct c.ShortName value " &
               "from MKTG_MIDT..DATA1A_Customers c " &
               "where c.status<>'XX' and c.Region='" & pobjUser.Region & "' and c.ShortName<>'' " &
                 IIf(pobjUser.Role <> "Admin", "and c.PIC='" & pobjUser.UserName & "' ", "")
            If xAdd Then
                mSQL &= "except " &
                   "select pl.Customer " &
                   "from DATA1A_PriceList pl " &
                   "where pl.EffDate<='" & Format(dtpExpDate.Value, "01-MMM-yyyy") & "' " &
                     "and pl.ExpDate>='" & Format(dtpEffDate.Value, "01-MMM-yyyy") & "' and pl.status ='OK' and pl.City ='" & pobjUser.City & "' " &
                     "and pl.RecID <>'" & txtRecID.Text & "' "
            End If
            mSQL &= "order by value"
            pobjSql.LoadCombo(cboCustomer, mSQL)
            pobjSql.LoadListbox(lstCustomer, mSQL)
        End If
        '^_^20230130 add by 7643 -e-
    End Sub

    Private Sub dgvDetail_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgvDetail.SortCompare, dgvIDetail.SortCompare, dgvHDetail.SortCompare
        dgvIntSort(e)
    End Sub

    Private Sub cboCustomer_2_Validated(sender As Object, e As EventArgs) Handles cboCustomer_2.Validated
        cboValidated(sender)
    End Sub

    Private Sub llbCopy_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCopy.LinkClicked
        TabPageChange(tpInput)
        LoadCustomer(True)
        DefaultValue(FAction.Copy)
        tpInput.Tag = "Copy"
    End Sub

    Private Sub llbHistory_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbHistory.LinkClicked
        TabPageChange(tpHistory)
        LoadDgv(dgvHMain, dgvMain.CurrentRow.Cells("PriceID").Value, dgvMain.CurrentRow.Cells("ChangeNum").Value)
    End Sub

    Private Sub dgvIDetail_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvIDetail.RowValidating
        If dgvIDetail.CurrentRow.IsNewRow Then Exit Sub

        If dgvIDetail.CurrentRow.Cells("FromTheUser").Value.ToString = "" OrElse dgvIDetail.CurrentRow.Cells("FromTheUser").Value = 0 Then dgvIDetail.CurrentRow.Cells("FromTheUser").Value = 1
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
    End Sub
End Class