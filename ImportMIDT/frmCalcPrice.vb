Imports System.Data.SqlClient

Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmCalcPrice
    Protected FValid As Boolean = True
    Protected FDsMain As New DataSet
    Protected FSdaMain As New SqlDataAdapter
    Protected FSQLMain, FSQLOrderMain As String
    Protected FclsTvcs As clsTvcs

    Protected FDsBody As New DataSet
    Protected FSdaBody As New SqlDataAdapter
    Protected FID, FSQLBody, FSQLOrderBody As String

    Private FCPMonth As String
    Private FExcel As New Excel.Application
    Private FCPMonthOld As DateTime
    Private FPower As Boolean

#Region "Custom Method"
    Protected Overridable Sub Env()
        FclsTvcs = pobjSql
        'llbEdit.Enabled = False
        llbDelete.Enabled = False
        Loadmain(False)
        LoadCombo()
        DefaultControl(tpSearch)

        LoadBody(0)
        DefaultControl(pnFoot, Nothing, True)
        'ChangeMainTab(tpList)

        llbConfirm.Enabled = False
        llbUnConfirm.Enabled = False
        WindowState = FormWindowState.Maximized
        'FPower = pobjUser.Role.ToUpper <> "USER"
        FPower = True
        llbAdd.Enabled = FPower
        ChangeMainTab(tpList)
    End Sub

    Protected Overridable Sub FormatDgvMain()
        dgvMain.Columns("City").Visible = False
        dgvMain.Columns("CPDate").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"
        dgvMain.Columns("CPMonth").DefaultCellStyle.Format = "MM/yyyy"
        dgvMain.Columns("ConfirmDate").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"
        dgvMain.Columns("TotalUser").DefaultCellStyle.Format = DgvNumberFormat(dgvMain, "TotalUser")
        dgvMain.Columns("TotalAmount").DefaultCellStyle.Format = DgvNumberFormat(dgvMain, "TotalAmount")
        dgvMain.Columns("FstDate").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"
        dgvMain.Columns("LstDate").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"
    End Sub

    Protected Overridable Sub Loadmain(Optional xIni As Boolean = False)
        Dim mSQL As String

        mSQL = "select RecID,CPID,CPDate,CPMonth,ConfirmStatus," &
                      "ConfirmDate,ConfirmStaff,TotalUser,TotalAmount,FstDate," &
                      "FstUser,LstDate,LstUser,Status,City " &
               "from DATA1A_CalcPrice CP " &
               "where Status='OK' and City='" & pobjUser.City & "' "
        mSQL &= IIf(txtRecID_2.Text <> "", "and RecID=" & txtRecID_2.Text & " ", "")
        mSQL &= IIf(txtCPID_2.Text <> "", "and CPID=" & txtCPID_2.Text & " ", "")
        mSQL &= IIf(chkCPDate.Checked,
                    "and CPDate" & cboCPDate.Text & "'" & dtpCPDate_2.Value.ToString("yyyyMMdd") &
                                                    "' ", "")
        mSQL &= IIf(chkCPMonth.Checked,
                    "and format(CPMonth,'yyyyMM')" & cboCPMonth.Text & "'" &
                         dtpCPMonth_2.Value.ToString("yyyyMM") & "' ", "")
        mSQL &= IIf(chkConfirm.Checked, "and ConfirmStatus='Y' ", "")
        mSQL &= IIf(chkConfirmDate.Checked,
                    "and ConfirmDate" & cboConfirmDate.Text & "'" &
                         dtpConfirmDate.Value.ToString("yyyyMMdd") & "' ", "")
        mSQL &= IIf(chkConfirmStaff.Checked, "and ConfirmStaff=' " & cboConfirmStaff.Text & "' ", "")

        FSQLMain = mSQL
        FSQLOrderMain = "order by CPMonth "

        If FSQLMain = "" Then
            Exit Sub
        End If

        mSQL = FSQLMain
        If xIni Then
            mSQL &= IIf(FSQLMain.ToUpper.Contains("WHERE"), "and ", "where ") & "1=2 "
        End If

        FDsMain = New DataSet
        FillDatagridview(FDsMain, FSdaMain, mSQL & FSQLOrderMain, dgvMain, FclsTvcs.Connection)
        FormatDgvMain()
    End Sub

    Protected Overridable Sub DefaultValue(Optional xDgv As DataGridView = Nothing)
        If xDgv Is Nothing Then
            DefaultControl(tpInput)
        Else
            DefaultControl(tpInput, xDgv)
        End If

        If xDgv Is Nothing Then
            LoadBody(0)
            DefaultControl(pnFoot, Nothing, True)
        End If

        If xDgv Is Nothing Then
            llbAmountDetail.Enabled = False
            txtCPID.Text = DefaultID("CPID", "DATA1A_CalcPrice", pobjSql)
        End If
        FCPMonth = dtpCPMonth.Value.ToString("yyyyMM")
    End Sub

    Protected Overridable Function CheckValue() As Boolean
        '
        Return True
    End Function

    Protected Overridable Sub UpdateMain()
        Dim mCPID As Integer
        Dim mCPDate, mDate As DateTime
        Dim mCPMonth As Date
        Dim mTotalUser, mTotalAmount As Double

        mCPID = Integer.Parse(txtCPID.Text)
        mCPDate = dtpCPDate.Value
        mCPMonth = dtpCPMonth.Value
        mTotalUser = Double.Parse(txtTotalUser.Text)
        mTotalAmount = Double.Parse(txtTotalAmount.Text)
        mDate = Now
        If txtRecID.Text = "" Then
            FDsMain.Tables(0).Rows.Add(Nothing, mCPID, mCPDate, mCPMonth, "N", Nothing, "", mTotalUser,
                                       mTotalAmount, mDate, pobjUser.UserName, Nothing, "", "OK",
                                       pobjUser.City)
        Else
            FDsMain.Tables(0).Rows(dgvMain.CurrentRow.Index).SetModified()
            FDsMain.Tables(0).Rows(dgvMain.CurrentRow.Index).Item("CPMonth") = mCPMonth
            FDsMain.Tables(0).Rows(dgvMain.CurrentRow.Index).Item("TotalUser") = mTotalUser
            FDsMain.Tables(0).Rows(dgvMain.CurrentRow.Index).Item("TotalAmount") = mTotalAmount
            FDsMain.Tables(0).Rows(dgvMain.CurrentRow.Index).Item("LstDate") = mDate
            FDsMain.Tables(0).Rows(dgvMain.CurrentRow.Index).Item("LstUser") = pobjUser.UserName
        End If

        CommitDataset(FDsMain, FSdaMain, {"LstDate", "LstUser"}, {mDate, pobjUser.UserName})
    End Sub

    Protected Overridable Sub DeleteMain()
        dgvMain.Rows.RemoveAt(dgvMain.CurrentRow.Index)
        CommitDataset(FDsMain, FSdaMain, {"LstDate", "LstUser"}, {Now, pobjUser.UserName})
    End Sub

    Protected Sub ChangeMainTab(xTabpage As TabPage)
        tcMain.TabPages.Clear()
        tcMain.TabPages.Add(xTabpage)
    End Sub

    Protected Overridable Sub DoMyCancel()
        FDsBody.RejectChanges()

        ChangeMainTab(tpList)
        FDsMain.RejectChanges()

        DefaultFoot()
    End Sub

    Protected Overridable Sub DoMyOK()
        UpdateBody()

        UpdateMain()
        ChangeMainTab(tpList)
        Loadmain()

        DefaultBody()
        DefaultFoot()
    End Sub

    Protected Overridable Sub DoMySelect()
        If dgvMain.CurrentRow Is Nothing Then
            Exit Sub
        End If

        If dgvMain.CurrentRow.Cells("CPID").Value IsNot Nothing Then
            FID = dgvMain.CurrentRow.Cells("CPID").Value
        End If

        'llbEdit.Enabled = True
        llbDelete.Enabled = True

        LoadBody(FID)
        DefaultControl(pnFoot, dgvMain)

        If dgvMain.CurrentRow.Cells("ConfirmStatus").Value = "Y" Then
            'llbEdit.Enabled = False
            llbDelete.Enabled = False
            llbConfirm.Enabled = False
            llbUnConfirm.Enabled = FPower
        Else
            'llbEdit.Enabled = FPower
            llbDelete.Enabled = FPower
            llbConfirm.Enabled = FPower
            llbUnConfirm.Enabled = False
        End If
    End Sub

    Protected Overridable Sub DoMyDelete()
        DeleteBody()

        DeleteMain()
        Loadmain()

        DefaultBody()
        DefaultFoot()
    End Sub

    Protected Overridable Sub LoadCombo()
        Dim mSQL As String

        mSQL = "select distinct UserName value " &
               "from DATA1A_User " &
               "where status='OK' and City='" & pobjUser.City & "'"
        pobjSql.LoadCombo(cboConfirmStaff, mSQL)
    End Sub

    Protected Overridable Sub FormatDgvBody()
        dgvBody.Columns("City").Visible = False
        dgvBody.Columns("CPID").Visible = False

        dgvBody.Columns("UserNum").DefaultCellStyle.Format = DgvNumberFormat(dgvBody, "UserNum")
        dgvBody.Columns("Amount").DefaultCellStyle.Format = DgvNumberFormat(dgvBody, "Amount")
        dgvBody.Columns("FstDate").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"
        dgvBody.Columns("LstDate").DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"
    End Sub

    Protected Overridable Sub LoadBody(xID As Integer)
        Dim mSQL As String

        '^_^20221109 mark by 7643 -b-
        'mSQL = "select RecID,CPID,Customer,UserNum,Amount," &
        '              "ErrDesc,FstDate,FstUser,LstDate,LstUser," &
        '              "Status,City " &
        '       "from DATA1A_CalcPriceDetail cpd " &
        '       "where CPID='" & xID & "' and Status='OK' and City='" & pobjUser.City & "' "
        '^_^20221109 mark by 7643 -e-
        '^_^20221109 modi by 7643 -b-
        mSQL = "select RecID,CPID,Customer,UserNum,Amount,CPCode," &
                      "ErrDesc,FstDate,FstUser,LstDate,LstUser," &
                      "Status,City,FreeUser " &  '^_^20221123 add FreeUser by 7643 
               "from DATA1A_CalcPriceDetail cpd " &
               "where CPID='" & xID & "' and Status='OK' and City='" & pobjUser.City & "' "
        '^_^20221109 modi by 7643 -e-

        FSQLBody = mSQL
        FSQLOrderBody = "order by Customer "

        If FSQLBody = "" Then
            Exit Sub
        End If

        FDsBody = New DataSet
        FillDatagridview(FDsBody, FSdaBody, FSQLBody & FSQLOrderBody, dgvBody, FclsTvcs.Connection)
        FormatDgvBody()
    End Sub

    Protected Overridable Sub UpdateBody()
        Dim mCPID As Integer
        Dim mCPDate As DateTime
        Dim mCPMonth As Date
        Dim mTotalUser, mTotalAmount As Double

        mCPID = Integer.Parse(txtCPID.Text)
        mCPDate = dtpCPDate.Value
        mCPMonth = dtpCPMonth.Value
        mTotalUser = Double.Parse(txtTotalUser.Text)
        mTotalAmount = Double.Parse(txtTotalAmount.Text)

        CommitDataset(FDsBody, FSdaBody, {"LstDate", "LstUser"}, {Now, pobjUser.UserName})
    End Sub

    Protected Overridable Sub DefaultBody()
        If dgvMain.CurrentRow IsNot Nothing Then
            LoadBody(FID)
        Else
            LoadBody(0)
        End If

        If dgvMain.CurrentRow Is Nothing Then
            llbAmountDetail2.Enabled = False
        End If
    End Sub

    Private Sub DefaultFoot()
        If dgvMain.CurrentRow IsNot Nothing Then
            DefaultControl(pnFoot, dgvMain)
        Else
            DefaultControl(pnFoot, Nothing, True)
        End If
    End Sub

    Protected Overridable Sub DeleteBody()
        For i = dgvBody.Rows.Count - 1 To 0 Step -1
            dgvBody.Rows.RemoveAt(i)
        Next

        CommitDataset(FDsBody, FSdaBody, {"LstDate", "LstUser"}, {Now, pobjUser.UserName})
    End Sub

    Private Sub PanelVisible(xVisible As Boolean)
        pnBody.Visible = xVisible
        pnFoot.Visible = xVisible
        If Not xVisible Then
            pnMain.Dock = DockStyle.Fill
        Else
            pnMain.Dock = DockStyle.Top
        End If
    End Sub

    Protected Overridable Sub DoMyBodySelect()
        If (dgvBody.CurrentRow IsNot Nothing) AndAlso (dgvBody.CurrentRow.Cells("ErrDesc").Value = "") Then
            llbAmountDetail.Enabled = True
            llbAmountDetail2.Enabled = True
        Else
            llbAmountDetail.Enabled = False
            llbAmountDetail2.Enabled = False
        End If
    End Sub

    Private Sub FormatExcel()
        FExcel.ActiveSheet.columns(1).numberformat = "@"
        FExcel.ActiveSheet.columns(2).numberformat = "@"
        FExcel.ActiveSheet.columns(3).numberformat = "#,##0"
        FExcel.ActiveSheet.columns(4).numberformat = "#,##0"
        FExcel.ActiveSheet.columns(5).numberformat = "@"
    End Sub

    Private Sub WriteHeader()
        Dim i As Integer

        For i = 1 To dgvBody.Columns.GetColumnCount(0) - 7
            FExcel.ActiveSheet.cells(1, i).value = dgvBody.Columns(i).Name
        Next
    End Sub

    Private Sub WriteDetail()
        Dim i, j As Integer

        IniProgress("Exporting!", dgvBody.Rows.Count)
        For i = 0 To dgvBody.Rows.Count - 1
            If dgvBody.Rows(i).Cells("ErrDesc").Value <> "" Then
                For j = 1 To dgvBody.Columns.GetColumnCount(0) - 7
                    FExcel.ActiveSheet.cells(i + 2, j).value = dgvBody.Rows(i).Cells(j).Value.ToString
                Next
            End If

            RunProgress()
        Next

        For i = FExcel.ActiveSheet.usedrange.rows.count To 2 Step -1
            If FExcel.ActiveSheet.cells(i, 1).value = Nothing Then
                FExcel.ActiveSheet.rows(i).EntireRow.Delete
            End If
        Next
    End Sub

    Private Sub ExportExcel()
        Dim mFileName As String

        Try
            FExcel.Workbooks.Add()

            FormatExcel()
            WriteHeader()
            WriteDetail()

            FExcel.ActiveSheet.usedrange.EntireColumn.AutoFit

            mFileName = "D:\CalcPrice_" & Now.ToString("yyyyMMddhhmmss") & ".xlsx"
            FExcel.ActiveSheet.saveas(mFileName)
            MsgBox("Export " & mFileName & " complete!")
        Finally
            FExcel.Workbooks.Close()
            FExcel.Quit()
        End Try
    End Sub

    Private Sub CalcPrice()
        Dim mSQL, mCPMonth, mErrDesc, mShortName, mUser As String
        Dim mReturn, mReturn2 As New DataTable
        Dim i, j, mUserNum, mRowCount, mToTheUser, mFromTheUser, mFreeUser As Integer  '^_^20221123 add mFreeUser by 7643
        Dim mAmount, mPricePerUser, mPriceCombo As Double
        Dim mDate As DateTime
        Dim mMsg As New frmShowMessage
        Dim mErr, mPass As Boolean
        Dim mProgress As New frmProgress
        Dim mCPCode As String  '^_^20221109 add by 7643

        For i = dgvBody.Rows.Count - 1 To 0 Step -1
            dgvBody.Rows.RemoveAt(i)
        Next

        mCPMonth = dtpCPMonth.Value.ToString("yyyyMM")
        mDate = Now
        mUser = pobjUser.UserName

        mSQL = "select OID.CustShortName ShortName,count(SUR.UserID) UserNum " &
               "from DATA1A_SecoUserRaw SUR " &
                 "left join Data1a_Contacts OID on SUR.UserID=OID.SecoID and OID.Status='OK' " &
                 "left join DATA1A_Customers CUS on OID.CustShortName=CUS.ShortName and CUS.status='OK' " &
                 "outer apply(select top 1 RecID from DATA1A_MISC dm where VAL=UserID and CAT='BypassSecoCheck')dm " &
                "where format(SUR.CreationDate,'yyyyMMdd')<='" & mCPMonth & "15' and SUR.status='OK' and SUR.counter<>0 " &
                  "and (CUS.Region='" & pobjUser.Region & "' or CUS.Region is null) and dm.recid is null " &
                "group by OID.CustShortName " &
                "order by OID.CustShortName"
        mReturn = pobjSql.GetDataTable(mSQL)

        IniProgress("Loading!", mReturn.Rows.Count)

        mErr = False
        For i = 0 To mReturn.Rows.Count - 1
            mUserNum = mReturn.Rows(i)("UserNum")
            If IsDBNull(mReturn.Rows(i)("Shortname")) Then
                mShortName = ""
            Else
                mShortName = mReturn.Rows(i)("Shortname")
            End If
            mAmount = 0
            mFreeUser = mUserNum  '^_^20221123 add by 7643
            mErrDesc = ""
            mFromTheUser = 0

            If mShortName = "" Then
                mSQL = "select SUR.UserID " &
                       "from DATA1A_SecoUserRaw SUR " &
                         "left join Data1a_Contacts OID on SUR.UserID=OID.SecoID and OID.Status='OK' " &
                         "left join DATA1A_Customers CUS on OID.CustShortName=CUS.ShortName and CUS.status='OK' " &
                         "outer apply(select top 1 RecID from DATA1A_MISC dm where VAL=UserID and CAT='BypassSecoCheck')dm " &
                        "where format(SUR.CreationDate,'yyyyMM')<='" & mCPMonth & "' and SUR.status='OK' and SUR.counter<>0 and CUS.Region is null and dm.recid is null " &
                        "order by SUR.UserID"
                mReturn2 = pobjSql.GetDataTable(mSQL)
                mRowCount = mReturn2.Rows.Count
                If mRowCount > 0 Then
                    mErrDesc = ""
                    For j = 0 To mRowCount - 1
                        mErrDesc &= IIf(mErrDesc <> "", ",", "") & mReturn2.Rows(j)("UserID")
                    Next
                    mErrDesc &= " not in any Customer"
                End If
            Else
                mSQL = "select ToTheUser,PricePerUser,PriceCombo " &
                       "from DATA1A_PriceListDetail PLD " &
                         "left join DATA1A_PriceList PL on PLD.PriceID=PL.PriceID and PL.status='OK' " &
                       "where PL.Customer='" & mShortName & "' " &
                         "and format(PL.EffDate,'yyyyMM')<='" & mCPMonth & "' " &
                         "and format(PL.ExpDate,'yyyyMM')>='" & mCPMonth & "' and PLD.status='OK' " &
                         "and PL.City='" & pobjUser.City & "' " &
                       "order by ToTheUser"
                mReturn2 = pobjSql.GetDataTable(mSQL)
                mRowCount = mReturn2.Rows.Count
                If mRowCount = 0 Then
                    mErrDesc = "Don't have SecoOffer!"
                ElseIf mUserNum > mReturn2.Rows(mRowCount - 1)("ToTheUser") Then
                    mErrDesc = "UserNum > ToTheUser!"
                Else
                    mFreeUser = 0  '^_^20221123 add by 7643
                    For j = 0 To mRowCount - 1
                        mToTheUser = mReturn2.Rows(j)("ToTheUser")
                        mPricePerUser = mReturn2.Rows(j)("PricePerUser")
                        mPriceCombo = mReturn2.Rows(j)("PriceCombo")
                        mFromTheUser = mFromTheUser + 1

                        If mUserNum >= mToTheUser Then
                            If mPriceCombo <> 0 Then
                                mAmount += mPriceCombo
                            Else
                                mAmount += (mToTheUser - mFromTheUser + 1) * mPricePerUser
                                If mPricePerUser = 0 Then mFreeUser += mToTheUser - mFromTheUser  '^_^20221123 add by 7643
                            End If
                        Else
                            If mPriceCombo <> 0 Then
                                mAmount += mPriceCombo
                            Else
                                mAmount += (mUserNum - mFromTheUser + 1) * mPricePerUser
                                If mPricePerUser = 0 Then mFreeUser += mUserNum - mFromTheUser  '^_^20221123 add by 7643
                            End If

                            Exit For
                        End If

                        mFromTheUser = mToTheUser
                    Next
                End If
            End If

            mCPCode = IIf(mShortName = "", "", "SC" & mShortName & Format(mDate, "yyMMdd"))  '^_^20221109 add by 7643

            FDsBody.Tables(0).Rows.Add(Nothing, Integer.Parse(txtCPID.Text), mShortName, mUserNum, mAmount, mCPCode, mErrDesc,  '^_^20221109 add mCPCode by 7643
                             mDate, mUser, Nothing, "", "OK", pobjUser.City, mFreeUser)  '^_^20221123 add mFreeUser by 7643

            If (mErrDesc <> "") And (Not mErr) Then
                mErr = True
            End If

            RunProgress()
        Next

        mPass = False
        If mErr Then
            mMsg.Text = "Warning"
            mMsg.lbl01.Text = "Abnormal data!"
            mMsg.btn01.Text = "Continue"
            mMsg.btn02.Text = "Check"
            mMsg.btn03.Text = "Cancel"
            mMsg.ShowDialog()
            If mMsg.DialogResult = DialogResult.OK Then
                mPass = True
            ElseIf mMsg.DialogResult = DialogResult.Ignore Then
                mPass = False
            ElseIf mMsg.DialogResult = DialogResult.Abort Then
                For i = dgvBody.Rows.Count - 1 To 0 Step -1
                    dgvBody.Rows.RemoveAt(i)
                Next
            End If
        End If

        mUserNum = 0
        mAmount = 0
        For i = 0 To dgvBody.Rows.Count - 1
            mUserNum += dgvBody.Rows(i).Cells("UserNum").Value
            mAmount += dgvBody.Rows(i).Cells("Amount").Value

            If dgvBody.Rows(i).Cells("ErrDesc").Value <> "" Then
                If Not mPass Then
                    dgvBody.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
        Next

        txtTotalUser.Text = Format(mUserNum, "#,##0")
        txtTotalAmount.Text = Format(mAmount, "#,##0")

        If (Not mPass) And (dgvBody.Rows.Count > 0) Then
            ExportExcel()
        End If
    End Sub

    Private Sub AmountDetail(xCPMonth As String)
        Dim mSQL, mShortName, mColumns(), mFormat() As String
        Dim mUserNum, i, mToTheUser, mFromTheUser, mUserNum2 As Integer
        Dim mReturn As New DataTable
        Dim mAmount, mPricePerUser, mPriceCombo As Double
        Dim mEnd As Boolean
        Dim mDgv As New frmDgv

        mColumns = {"UserNum", "PricePerUser", "PriceCombo", "Amount"}
        mFormat = {"N", "N", "N", "N"}
        IniDgv("AmountDetail", mColumns, mFormat)

        mUserNum = dgvBody.CurrentRow.Cells("UserNum").Value
        mShortName = dgvBody.CurrentRow.Cells("Customer").Value
        mFromTheUser = 0
        mEnd = False

        mSQL = "select ToTheUser,PricePerUser,PriceCombo " &
                "from DATA1A_PriceListDetail PLD " &
                    "left join DATA1A_PriceList PL on PLD.PriceID=PL.PriceID and PL.status='OK' " &
                "where PL.Customer='" & mShortName & "' " &
                    "and format(PL.EffDate,'yyyyMM')<='" & xCPMonth & "' " &
                    "and format(PL.ExpDate,'yyyyMM')>='" & xCPMonth & "' and PLD.status='OK' " &
                    "and PL.City='" & pobjUser.City & "' " &
                "order by ToTheUser"
        mReturn = pobjSql.GetDataTable(mSQL)
        For i = 0 To mReturn.Rows.Count - 1
            mToTheUser = mReturn.Rows(i)("ToTheUser")
            mPricePerUser = mReturn.Rows(i)("PricePerUser")
            mPriceCombo = mReturn.Rows(i)("PriceCombo")
            mFromTheUser = mFromTheUser + 1

            If mUserNum >= mToTheUser Then
                mUserNum2 = mToTheUser - mFromTheUser + 1

                If mPriceCombo <> 0 Then
                    mAmount = mPriceCombo
                Else
                    mAmount = mUserNum2 * mPricePerUser
                End If
            Else
                mUserNum2 = mUserNum - mFromTheUser + 1

                If mPriceCombo <> 0 Then
                    mAmount = mPriceCombo
                Else
                    mAmount = mUserNum2 * mPricePerUser
                End If
            End If

            If mUserNum <= mToTheUser Then
                mEnd = True
            End If

            CType(LDGVForm.Controls(0), DataGridView).Rows.Add(mUserNum2, mPricePerUser, mPriceCombo, mAmount)

            mFromTheUser = mToTheUser

            If mEnd Then
                Exit For
            End If
        Next
        LDGVForm.ShowDialog()
    End Sub
#End Region

    Private Sub frmCalcPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Env()
    End Sub

    Private Sub llbOK_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbOK.LinkClicked
        If Not CheckValue() Then
            Exit Sub
        End If

        DoMyOK()
    End Sub

    'Private Sub llbEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    ChangeMainTab(tpInput)
    '    DefaultValue(dgvMain)
    'End Sub

    Private Sub llbDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDelete.LinkClicked
        If MsgBox("Delete this row?", vbYesNo) = vbNo Then
            Exit Sub
        End If
        DoMyDelete()
    End Sub

    Private Sub dgvMain_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMain.SelectionChanged
        DoMySelect()
    End Sub

    Private Sub llbSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSearch.LinkClicked
        ChangeMainTab(tpSearch)

        PanelVisible(False)
    End Sub

    Private Sub llbReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbReset.LinkClicked
        DefaultControl(tpSearch)
    End Sub

    Private Sub llbCancel_2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCancel_2.LinkClicked
        DoMyCancel()

        PanelVisible(True)
    End Sub

    Private Sub llbSearch_2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSearch_2.LinkClicked
        ChangeMainTab(tpList)
        Loadmain()

        DefaultBody()
        DefaultFoot()
        PanelVisible(True)
    End Sub

    Private Sub llbAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbAdd.LinkClicked
        ChangeMainTab(tpInput)
        DefaultValue()
    End Sub

    Private Sub llbCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCancel.LinkClicked
        DoMyCancel()
    End Sub

    Private Sub dgvBody_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBody.SelectionChanged
        DoMyBodySelect()
    End Sub

    Private Sub llbCalcPrice_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCalcPrice.LinkClicked
        If dgvBody.Rows.Count > 0 Then
            If MsgBox("This month has calculated!" & vbLf & "Calculate again?", vbYesNo) = vbNo Then
                Exit Sub
            End If
        End If

        CalcPrice()
    End Sub

    Private Sub dtpCPMonth_Enter(sender As Object, e As EventArgs) Handles dtpCPMonth.Enter
        FCPMonthOld = dtpCPMonth.Value
    End Sub

    Private Sub txtRecID_2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecID_2.KeyPress
        PressInteger(e)
    End Sub

    Private Sub chkCPDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkCPDate.CheckedChanged
        If chkCPDate.Checked Then
            cboCPDate.Enabled = True
            dtpCPDate_2.Enabled = True
        Else
            cboCPDate.Enabled = False
            dtpCPDate_2.Enabled = False
        End If
    End Sub

    Private Sub txtCPID_2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCPID_2.KeyPress
        PressInteger(e)
    End Sub

    Private Sub chkCPMonth_CheckedChanged(sender As Object, e As EventArgs) Handles chkCPMonth.CheckedChanged
        If chkCPMonth.Checked Then
            cboCPMonth.Enabled = True
            dtpCPMonth_2.Enabled = True
        Else
            cboCPMonth.Enabled = False
            dtpCPMonth_2.Enabled = False
        End If
    End Sub

    Private Sub chkConfirmDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfirmDate.CheckedChanged
        If chkConfirmDate.Checked Then
            cboConfirmDate.Enabled = True
            dtpConfirmDate.Enabled = True
        Else
            cboConfirmDate.Enabled = False
            dtpConfirmDate.Enabled = False
        End If
    End Sub

    Private Sub chkConfirmStaff_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfirmStaff.CheckedChanged
        If chkConfirmStaff.Checked Then
            cboConfirmStaff.Enabled = True
        Else
            cboConfirmStaff.Enabled = False
        End If
    End Sub

    Private Sub DoMyConfirm(xConfirm As Boolean)
        '^_^20221109 add by 7643 -b-
        Dim t As SqlClient.SqlTransaction = pobjSql.Connection.BeginTransaction
        Dim i As Integer
        Dim mPara() As String
        '^_^20221109 add by 7643 -e-
        Dim mSQL As String

        If dgvMain.CurrentRow Is Nothing Then Exit Sub

        '^_^20221109 add by 7643 -b-
        cmd.Connection = pobjSql.Connection
        cmd.Transaction = t
        Try
            '^_^20221109 add by 7643 -e-
            If xConfirm = True Then
                '^_^20221109 mark by 7643 -b-
                'mSQL = "update DATA1A_CalcPrice set ConfirmStatus='Y',LstDate='" & Now & "',LstUser='" & pobjUser.UserName & "' " &
                '       "where RecID=" & dgvMain.CurrentRow.Cells("RecID").Value & ""
                '^_^20221109 mark by 7643 -e-
                '^_^20221109 modi by 7643 -b-
                ReDim mPara(3)
                mPara(0) = pobjUser.UserName
                mPara(1) = Format(Now, "yyyyMMdd hh:mm:ss")
                mPara(2) = dgvMain.CurrentRow.Cells("RecID").Value
                cmd.CommandText = String.Format("update DATA1A_CalcPrice set ConfirmStatus='Y',LstUser='{0}',LstDate='{1}' where RecID={2}", mPara)
                cmd.ExecuteNonQuery()

                IniProgress("Inserting FOP!", dgvBody.Rows.Count)
                For i = 0 To dgvBody.Rows.Count - 1
                    RunProgress()

                    If dgvBody.Rows(i).Cells("CPCode").Value.ToString = "" Then Continue For
                    ReDim mPara(11)
                    mPara(0) = dgvMain.CurrentRow.Cells("RecID").Value
                    mPara(1) = dgvMain.CurrentRow.Cells("CPID").Value
                    mPara(2) = "PSP"
                    mPara(3) = "VND"
                    mPara(4) = 1
                    mPara(5) = dgvBody.Rows(i).Cells("Amount").Value
                    mPara(6) = dgvBody.Rows(i).Cells("CPCode").Value
                    mPara(7) = pobjUser.UserName
                    mPara(8) = dgvBody.Rows(i).Cells("RecID").Value

                    cmd.CommandText = "select RecID from DATA1A_Customers where ShortName='" & dgvBody.Rows(i).Cells("Customer").Value & "' and status='OK'"
                    mPara(9) = cmd.ExecuteScalar
                    mPara(10) = "SECO"
                    cmd.CommandText = String.Format("insert into DATA1A_FOP(RCPID,RCPNo,FOP,Currency,ROE," &
                                                                    "Amount,Document,FstUser,RMK,CustomerID," &
                                                                    "Source) " &
                                                    "values({0},'{1}','{2}','{3}',{4}," &
                                                           "{5},'{6}','{7}','{8}',{9}," &
                                                           "'{10}')", mPara)
                    cmd.ExecuteNonQuery()
                Next
                '^_^20221109 modi by 7643 -e-
            Else
                '^_^20221109 mark by 7643 -b-
                'mSQL = "update DATA1A_CalcPrice set ConfirmStatus='N',LstDate='" & Now & "',LstUser='" & pobjUser.UserName & "' " &
                '       "where RecID=" & dgvMain.CurrentRow.Cells("RecID").Value & ""
                '^_^20221109 mark by 7643 -e-
                '^_^20221109 modi by 7643 -b-
                ReDim mPara(3)
                mPara(0) = pobjUser.UserName
                mPara(1) = Format(Now, "yyyyMMdd hh:mm:ss")
                mPara(2) = dgvMain.CurrentRow.Cells("RecID").Value
                cmd.CommandText = String.Format("update DATA1A_CalcPrice set ConfirmStatus='N',LstUser='{0}',LstDate='{1}' where RecID={2}", mPara)
                cmd.ExecuteNonQuery()

                ReDim mPara(3)
                mPara(0) = pobjUser.UserName
                mPara(1) = Format(Now, "yyyyMMdd")
                mPara(2) = dgvMain.CurrentRow.Cells("RecID").Value
                cmd.CommandText = String.Format("update DATA1A_FOP set Status='XX',LstUser='{0}',LstUpdate='{1}' where RCPID={2} and status='OK'", mPara)
                cmd.ExecuteNonQuery()
                '^_^20221109 modi by 7643 -e-
            End If

            '^_^20221110 add by 7643 -b-
            t.Commit()
        Catch ex As Exception
            t.Rollback()
            Append2TextFile(ex.Message & vbNewLine & cmd.CommandText)
            MsgBox(ex.Message & vbNewLine & cmd.CommandText)
        End Try
        '^_^20221109 add by 7643 -e-
        'pobjSql.ExecuteNonQuerry(mSQL)
    End Sub

    Private Sub llbConfirm_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbConfirm.LinkClicked
        Dim mSQL, mCPMonth As String,
            mUserNum, i, mFromTheUser, mToTheUser As Integer,
            mReturn2 As DataTable,
            mAmount, mPricePerUser, mPriceCombo As Double,
            mDiff As Boolean

        'Check
        mCPMonth = Format(dgvMain.CurrentRow.Cells("CPMonth").Value, "yyyyMM")
        mDiff = False
        For i = 0 To dgvBody.Rows.Count - 1
            mUserNum = dgvBody.Rows(i).Cells("UserNum").Value
            mAmount = 0
            mFromTheUser = 0

            mSQL = "select ToTheUser,PricePerUser,PriceCombo " &
                           "from DATA1A_PriceListDetail PLD " &
                             "left join DATA1A_PriceList PL on PLD.PriceID=PL.PriceID And PL.status='OK' " &
                           "where PL.Customer='" & dgvBody.Rows(i).Cells("Customer").Value.ToString & "' " &
                             "and format(PL.EffDate,'yyyyMM')<='" & mCPMonth & "' " &
                             "and format(PL.ExpDate,'yyyyMM')>='" & mCPMonth & "' and PLD.status='OK' " &
                             "and PL.City='" & pobjUser.City & "' " &
                           "order by ToTheUser"
            mReturn2 = pobjSql.GetDataTable(mSQL)
            For j = 0 To mReturn2.Rows.Count - 1
                mToTheUser = mReturn2.Rows(j)("ToTheUser")
                mPricePerUser = mReturn2.Rows(j)("PricePerUser")
                mPriceCombo = mReturn2.Rows(j)("PriceCombo")

                If mUserNum >= mToTheUser Then
                    If mPriceCombo <> 0 Then
                        mAmount += mPriceCombo
                    Else
                        mAmount += (mToTheUser - mFromTheUser) * mPricePerUser
                    End If
                Else
                    If mPriceCombo <> 0 Then
                        mAmount += mPriceCombo
                    Else
                        mAmount += (mUserNum - mFromTheUser) * mPricePerUser
                    End If

                    Exit For
                End If

                mFromTheUser = mToTheUser
            Next

            If mAmount <> dgvBody.Rows(i).Cells("Amount").Value Then
                If Not mDiff Then mDiff = True

                dgvBody.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next

        If mDiff AndAlso MsgBox("SecoOffer had changed!" & vbLf & "Continue confirm?", vbYesNo) = vbNo Then Exit Sub

        DoMyConfirm(True)
        Loadmain()
    End Sub

    Private Sub llbUnConfirm_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbUnConfirm.LinkClicked
        '^_^20221109 add by 7643 -b-
        If ScalarToInt("DATA1A_FOP", "RecID", "RCPID=" & dgvMain.CurrentRow.Cells("RecID").Value & " and Status='OK' and ProfID<>0", pobjSql.Connection) <> 0 Then
            MsgBox("This CalcPrice has been debited, can't unconfirm!")
            Exit Sub
        End If
        '^_^20221109 add by 7643 -e-
        DoMyConfirm(False)
        Loadmain()
    End Sub

    Private Sub dtpCPMonth_Validated(sender As Object, e As EventArgs) Handles dtpCPMonth.Validated
        Dim mSQL, mCPMonth As String

        mCPMonth = dtpCPMonth.Value.ToString("yyyyMM")

        mSQL = "select RecID " &
               "from DATA1A_CalcPrice " &
               "where status='OK' and City='" & pobjUser.City & "' and RecID<>'" & txtRecID.Text & "' and format(CPMonth,'yyyyMM')='" & mCPMonth & "'"
        'If pobjSql.GetScalarAsString(mSQL) <> "" Then
        '    MsgBox(dtpCPMonth.Value.ToString("MM/yyyy") & " already exist!")
        '    dtpCPMonth.Select()
        '    Exit Sub
        'End If

        If FCPMonth <> mCPMonth Then
            If dgvBody.Rows.Count > 0 Then
                If MsgBox("This month has calculated!" & vbLf & "Change another month and calculate again?", vbYesNo) = vbYes Then
                    CalcPrice()
                    FCPMonth = mCPMonth
                Else
                    dtpCPMonth.Value = FCPMonthOld
                End If
            End If
        End If
    End Sub

    Private Sub llbAmountDetail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbAmountDetail.LinkClicked
        AmountDetail(dtpCPMonth.Value.ToString("yyyyMM"))
    End Sub

    Private Sub llbAmountDetail2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbAmountDetail2.LinkClicked
        AmountDetail(Format(dgvMain.CurrentRow.Cells("CPMonth").Value, "yyyyMM"))
        'Dim mForm As New frmReissueTicketPriceDetail
        'Dim mSQL As String
        'Dim mReturn As New DataTable

        'mForm.Text = "AmountDetail"
        'mSQL = String.Format("select NumberOfUser,PricePerUser,Amount " &
        '                     "from DATA1A_CalcPriceDetail_D " &
        '                     "where CalcPriceDetailID={0} And Status='OK' and City='{1}' " &
        '                     "order by RecID",
        '                     {dgvBody.CurrentRow.Cells("RecID").Value, pobjUser.City})
        'mReturn = pobjSql.GetDataTable(mSQL)
        'For i = 0 To mReturn.Rows.Count - 1
        '    mForm.dgvReissueTicketPriceDetail.Rows.Add(mReturn.Rows(i)("NumberOfUser"), mReturn.Rows(i)("PricePerUser"), mReturn.Rows(i)("Amount"))
        'Next

        'mForm.ShowDialog()
    End Sub
End Class