Imports System.Diagnostics.Process
Imports System.IO
Imports Microsoft.Office.Interop  '^_^20221121 add by 7643
Module mdlSubAndFunc
    '^_^20221011 add by 7643 -b-
    Private FProgressForm As Form
    '^_^20221109 add by 7643 -b-
    Private MyCust As New clsCustomer
    Private strSQL As String
    Public CutOverDatePSP As Date
    '^_^20221109 add by 7643 -e-
    Dim FTrans As SqlClient.SqlTransaction  '^_^20230112 add by 7643

    Public Sub PressInteger(e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back)) Then e.Handled = True
    End Sub

    Public Function CboValueValidating(xCbo As ComboBox, xTable As String, xFilter As String) As Boolean
        Dim mID As Integer

        If xCbo.Text = "" Then
            xCbo.SelectedIndex = 0

            Return True
        End If

        mID = ScalarToInt(xTable, "RecID", xFilter, pobjSql.Connection)
        If mID = 0 Then
            MsgBox("Value unavailable!")
            Return False
        Else
            xCbo.SelectedValue = mID
        End If

        Return True
    End Function

    Public Sub ChangeTab(xTabControl As TabControl, xTabPage As TabPage)
        xTabControl.TabPages.Clear()
        xTabControl.TabPages.Add(xTabPage)
    End Sub

    Public Sub IniProgress(xTitle As String, xMax As Integer)
        Dim mProgress As New ProgressBar

        FProgressForm = New Form
        FProgressForm.Text = xTitle
        FProgressForm.Size = New Size(800, 60)
        FProgressForm.StartPosition = FormStartPosition.CenterScreen

        mProgress = New ProgressBar
        mProgress.Parent = FProgressForm
        mProgress.Dock = DockStyle.Fill
        mProgress.Value = mProgress.Minimum
        mProgress.Maximum = xMax
        mProgress.Step = 1
    End Sub

    Public Sub RunProgress()
        Dim mPb As New ProgressBar

        mPb = CType(FProgressForm.Controls(0), ProgressBar)
        mPb.PerformStep()
        FProgressForm.Show()

        If mPb.Value = mPb.Maximum Then FProgressForm.Close()
    End Sub
    '^_^20221011 add by 7643 -e-

    '^_^20221109 add by 7643 -b-
    Public Function Insert_GhiNoKhach(ByVal SQL_Exec As String, ByVal InvCurr As String, ByVal InvDate As Date, ByVal InvAmt As Decimal, ByVal pStatus As String, ByVal note As String, ByVal DueDate As Date, ByVal BSR As Decimal, pCustID As Integer) As String
        Dim KQ As Integer
        MyCust.CustID = pCustID
        strSQL = "insert DATA1A_GhiNoKhach (custID, custShortname, DebType, InvCurr, Invdate, InvAmt, Status, NOte, DueDate, "
        strSQL = strSQL & " BSR, FstUser) values ('"
        strSQL = strSQL & MyCust.Recid & "','"
        strSQL = strSQL & MyCust.ShortName & "','"
        strSQL = strSQL & "PSP" & "','"
        strSQL = strSQL & InvCurr & "','"
        strSQL = strSQL & Format(InvDate, "yyyyMMdd") & "','"
        strSQL = strSQL & InvAmt & "','"
        strSQL = strSQL & pStatus & "','"
        strSQL = strSQL & Replace(note, "--", "") & "','"
        strSQL = strSQL & Format(DueDate, "dd-MMM-yy") & " 23:59',"
        strSQL = strSQL & BSR & ",'"
        strSQL = strSQL & pobjUser.UserName & "')"
        Try
            If SQL_Exec = "S" Then
                Return strSQL
            Else
                cmd.Connection = pobjSql.Connection
                cmd.CommandText = strSQL & "; SELECT SCOPE_IDENTITY() AS [RecID]"
                KQ = cmd.ExecuteScalar
                Return KQ.ToString
            End If
        Catch ex As Exception
            Append2TextFile(ex.Message & vbNewLine & cmd.CommandText)
            Return 0
        End Try

    End Function
    Public Sub LoadCmb_VAL(ByVal cmb As ComboBox, ByVal pQry As String _
                           , Optional Conx As SqlClient.SqlConnection = Nothing)
        If InStr(pQry.ToUpper, "ORDER BY") = 0 Then
            pQry = pQry & " order by DIS"
        End If
        cmb.DataSource = GetDataTable(pQry, Conx)
        cmb.ValueMember = "VAL"
        cmb.DisplayMember = "DIS"
    End Sub
    Public Sub LoadCmb_MSC(ByVal cmb As ComboBox, ByVal pCat As String)
        Dim dTable As DataTable
        If pCat.Length < 16 Then
            dTable = GetDataTable("select VAL from DATA1A_MISC where CAT='" & pCat & "' order by val ")
        Else
            If InStr(pCat.ToUpper, "ORDER BY") = 0 Then pCat = pCat & " order by VAL"
            dTable = GetDataTable(pCat)
        End If
        cmb.Items.Clear()
        For i As Int32 = 0 To dTable.Rows.Count - 1
            cmb.Items.Add(dTable.Rows(i)("VAL"))
        Next
        If cmb.Items.Count > 0 Then cmb.Text = cmb.Items(0).ToString
    End Sub
    Public Sub GenComboValueMain()
        CutOverDatePSP = ScalarToDate("DATA1A_MISC", "VAL1", "CAT='CUTOVER' and VAL='PSP' ", pobjSql.Connection)
    End Sub
    Public Sub CheckRightForALLForm(ByVal frm As Form)
        Dim Ctrl As Control
        pobjUser.CurrObj = frm.Name
        If pobjUser.URights = "" Then Exit Sub
        For i As Int16 = 0 To pobjUser.URights.Split("|").Length - 1
            Ctrl = findControl(pobjUser.URights.Split("|")(i), frm)
            Ctrl.Enabled = False
        Next
    End Sub
    Private Function findControl(ByVal pName As String, ByVal pCtrl As Control) As Control
        Dim ReturnControl As Control = Nothing
        For Each Ctrl_i As Control In pCtrl.Controls
            If Ctrl_i.Name.ToUpper = pName.ToUpper Then
                ReturnControl = Ctrl_i
                Exit For
            ElseIf Ctrl_i.Controls.Count > 0 Then
                ReturnControl = findControl(pName, Ctrl_i)
                If ReturnControl IsNot Nothing Then Exit For
            End If
        Next
        Return ReturnControl
    End Function
    Public Function ForEX_12(strCity As String, ByVal DOS As Date, ByVal pCurr As String, ByVal pType As String, ByVal pAL As String _
                             , Optional ByVal parQuay As String = "**") As clsROE
        Dim objROE As New clsROE
        Dim surCharge As Decimal
        Dim dTable As DataTable
        dTable = GetDataTable("select * from DATA1A_ForEx where Currency='" & pCurr & "' and City='" & strCity & "' and Status='OK' order by EffectDate DESC, recid desc ")
        For i As Int16 = 0 To dTable.Rows.Count - 1
            If dTable.Rows(i)("EffectDate") <= DOS And
                (dTable.Rows(i)("ApplyROEto") = "YY" Or InStr(dTable.Rows(i)("ApplyROEto"), pAL) > 0 _
                 Or pAL = "YY" Or InStr(dTable.Rows(i)("ApplySCto"), pAL) > 0) Then
                objROE.Amount = dTable.Rows(i)(pType)
                objROE.Id = dTable.Rows(i)("RecId")

                If pType = "RECID" Then Exit For
                surCharge = dTable.Rows(i)("SurCharge")
                If pType = "BBR" Then surCharge = -surCharge
                If (parQuay <> "**" And InStr(dTable.Rows(i)("ApplySCto"), parQuay) > 0) Or
                    InStr(dTable.Rows(i)("ApplySCto"), pAL) > 0 Then
                    objROE.Amount = objROE.Amount + surCharge
                End If
                Exit For
            End If
        Next
        Return objROE
    End Function

    Public Function Insert_KhachTra(ByVal SQL_Exec As String, ByVal orgDate As Date, ByVal Curr As String, ByVal FOP As String, ByVal OrgDocs As String, ByVal orgAmt As Decimal, ByVal note As String, ByVal Payer As String, ByVal ROE As Decimal, ByVal Description As String, ByVal pPmtType As String, pCustID As Integer) As String
        Dim KQ As Integer
        MyCust.CustID = pCustID
        strSQL = "insert DATA1A_Khachtra (custID, custshortname, Orgdate, OrgCurr, FOP,PmtType, "
        strSQL = strSQL & "OrgAmt, receiveby, Note, custname, ROE, description, FstUser) values ("
        strSQL = strSQL & MyCust.CustID & ",'"
        strSQL = strSQL & MyCust.ShortName & "','"
        strSQL = strSQL & Format(orgDate, "yyyyMMdd HH:mm") & "','"
        strSQL = strSQL & Curr & "','"
        strSQL = strSQL & FOP & "','"
        strSQL = strSQL & pPmtType & "',"
        strSQL = strSQL & orgAmt & ",'"
        strSQL = strSQL & "BO-BackOFC" & "','"
        strSQL = strSQL & note & " ','"
        strSQL = strSQL & Replace(Payer, "--", "") & "',"
        strSQL = strSQL & ROE & " ,'"
        strSQL = strSQL & Replace(Description, "--", "") & "','"
        strSQL = strSQL & pobjUser.UserName & "')"
        If SQL_Exec = "S" Then
            Return strSQL
        Else
            cmd.Connection = pobjSql.Connection
            cmd.CommandText = strSQL & "; SELECT SCOPE_IDENTITY() AS [RecID]"
            KQ = cmd.ExecuteScalar
            Return KQ.ToString
        End If
    End Function

    Public Function Insert_ApplyPayment(ByVal SQL_Exec As String, ByVal GhiNoID As Integer, ByVal KhachTraID As Integer, ByVal AmtInDebCurr As Decimal, ByVal Curr As String, ByVal ROE As Decimal, ByVal CrdDoc As String, ByVal Note As String) As String
        Dim KQ As Integer
        strSQL = "insert into DATA1A_ApplyPayment (GhiNoID, KhachTraID,  AmtInDebCurr, Currency, ROE, CrdDocs, Note, FstUser) Values ("
        strSQL = strSQL & GhiNoID & ","
        strSQL = strSQL & KhachTraID & ","
        strSQL = strSQL & AmtInDebCurr & ",'"
        strSQL = strSQL & Curr & "',"
        strSQL = strSQL & ROE & ",'"
        strSQL = strSQL & CrdDoc & "','"
        strSQL = strSQL & Replace(Note, "--", "") & "','"
        strSQL = strSQL & pobjUser.UserName & "')"
        If SQL_Exec = "S" Then
            Return strSQL
        Else
            cmd.CommandText = strSQL & "; SELECT SCOPE_IDENTITY() AS [RecID]"
            KQ = cmd.ExecuteScalar
            Return KQ.ToString
        End If
    End Function
    '^_^20221109 add by 7643 -e-

    '^_^20221031 add by 7643 -b-
    Public Sub IntegerValidating(xTxt As TextBox, e As System.ComponentModel.CancelEventArgs)
        Dim mTest As Integer

        If xTxt.Text = "" Then xTxt.Text = "0"

        Try
            mTest = Integer.Parse(xTxt.Text)
        Catch ex As Exception
            MsgBox("This field only apply Integer!")
            e.Cancel = True
        End Try
    End Sub
    '^_^20221031 add by 7643 -e-

    Public Function GetDataTable(ByVal pStrCmd As String, Optional ByVal pConn As SqlClient.SqlConnection = Nothing) As DataTable
        Dim tblResults As New DataTable
        If pConn Is Nothing Then
            Dim adapter As New SqlClient.SqlDataAdapter(pStrCmd, pobjSql.Connection)
            adapter.Fill(tblResults)
        Else
            Dim adapter As New SqlClient.SqlDataAdapter(pStrCmd, pConn)
            adapter.Fill(tblResults)
        End If
        Return tblResults
    End Function

    Public Function CorrectDateInput(ByVal vfrm As String, ByVal vto As String) As Boolean
        On Error GoTo ErrHandler
        CorrectDateInput = False
        If CInt(Left(vfrm, 2)) < 13 And CInt(Left(vfrm, 2)) > 0 And
            CInt(Left(vto, 2)) < 13 And CInt(Left(vto, 2)) > 0 Then
            If CInt(Right(vfrm, 2)) > 3 And CInt(Right(vfrm, 2)) < 99 And
                CInt(Right(vto, 2)) < 99 And CInt(Right(vto, 2)) > 3 Then
                If DateSerial(Right(vto, 2), Left(vto, 2), 1) >= DateSerial(Right(vfrm, 2), Left(vfrm, 2), 1) Then
                    CorrectDateInput = True
                End If
            End If
        End If
        Exit Function
ErrHandler:
        MsgBox("Invalid Date Input. Please Check", vbCritical + vbOKOnly, "ACO Vietnam")
    End Function
    Public Function DefineD(ByVal frmTo As Integer, ByVal ThisLast As String) As Date
        Dim Y As Integer
        Y = Date.Today.Year
        If Date.Today.Month < 4 Then
            Y = IIf(ThisLast = "This", Date.Today.Year, Date.Today.Year - 1)
            If frmTo = 1 Then
                DefineD = IIf(ThisLast = "This", DateSerial(Y, 1, 1), DateSerial(Y, 10, 1))
            Else
                DefineD = IIf(ThisLast = "This", DateSerial(Y, 3, 31), DateSerial(Y, 12, 31))
            End If

        ElseIf Date.Today.Month > 3 And Date.Today.Month < 7 Then
            If frmTo = 1 Then
                DefineD = IIf(ThisLast = "This", DateSerial(Y, 4, 1), DateSerial(Y, 1, 1))
            Else
                DefineD = IIf(ThisLast = "This", DateSerial(Y, 6, 30), DateSerial(Y, 3, 31))
            End If
        ElseIf Date.Today.Month > 6 And Date.Today.Month < 10 Then
            If frmTo = 1 Then
                DefineD = IIf(ThisLast = "This", DateSerial(Y, 7, 1), DateSerial(Y, 4, 1))
            Else
                DefineD = IIf(ThisLast = "This", DateSerial(Y, 9, 30), DateSerial(Y, 6, 30))
            End If
        Else
            If frmTo = 1 Then
                DefineD = IIf(ThisLast = "This", DateSerial(Y, 10, 1), DateSerial(Y, 7, 1))
            Else
                DefineD = IIf(ThisLast = "This", DateSerial(Y, 9, 30), DateSerial(Y, 12, 31))
            End If
        End If
    End Function
    Public Sub ShowXls(ByVal pTblName As String)
        SaveSetting("1A", "Allstat", "tmpTable", pTblName)
        Dim AppXls As Microsoft.Office.Interop.Excel.Application
        On Error Resume Next
        AppXls = GetObject(, "Excel.Application")
        If Err.Number = 0 Then
            Dim wkBook As Microsoft.Office.Interop.Excel.Workbook
            wkBook = AppXls.Workbooks.Open(My.Application.Info.DirectoryPath & "\allstat.xlt")
            'wkBook = AppXls.Workbooks.Open("D:\D_DISC\Amadeus\AllStats.net\allstat.xlt")
            If AppXls.Visible = False Then AppXls.Visible = True
        Else
            'Start("x:\midt.net\allstat.xlt")
            Start(My.Application.Info.DirectoryPath & "\allstat.xlt")
        End If
        On Error GoTo 0
    End Sub
    Public Sub ShowXlsHotel()
        Dim AppXls As Microsoft.Office.Interop.Excel.Application
        On Error Resume Next
        AppXls = GetObject(, "Excel.Application")
        If Err.Number = 0 Then
            Dim wkBook As Microsoft.Office.Interop.Excel.Workbook
            wkBook = AppXls.Workbooks.Open(My.Application.Info.DirectoryPath & "\hotel.xlt")
            If AppXls.Visible = False Then AppXls.Visible = True
        Else
            Start(My.Application.Info.DirectoryPath & "\hotel.xlt")
        End If
        On Error GoTo 0
    End Sub
    'Public Function ChangeStatus_ByID(ByVal pTable As String, ByVal pStatus As String, ByVal PID As Integer, Optional ByVal pALStatus As String = "") As String
    '    Dim KQ As String
    '    KQ = "update " & pTable & " set LstUser='" & pobjUser.UserName & "', Lstupdate=getdate(), status='" & pStatus & "'"
    '    If pALStatus <> "" Then
    '        KQ = KQ & ", StatusAL='" & pALStatus & "'"
    '    End If
    '    KQ = KQ & " where recID = " & PID
    '    Return KQ
    'End Function
    'Public Function ChangeStatus_ByDK(ByVal pTable As String, ByVal pStatus As String, ByVal pDK As String, Optional ByVal pALStatus As String = "") As String
    '    Dim KQ As String
    '    KQ = "update " & pTable & " set LstUser='" & pobjUser.UserName & "', Lstupdate=getdate(), status='" & pStatus & "'"
    '    If pALStatus <> "" Then
    '        KQ = KQ & ", StatusAL='" & pALStatus & "'"
    '    End If
    '    KQ = KQ & " where " & Finetune_pDK(pDK)
    '    Return KQ
    'End Function
    'Private Function Finetune_pDK(ByVal pDK As String) As String
    '    If pDK.Trim.Substring(0, 5).ToUpper = "WHERE" Then
    '        Return pDK.Trim.Substring(5)
    '    End If
    '    Return pDK
    'End Function
    Public Function GetColorForToday() As Color
        If Today.Date.DayOfWeek = DayOfWeek.Monday Then
            GetColorForToday = Color.LightGreen
        ElseIf Today.Date.DayOfWeek = DayOfWeek.Tuesday Then
            GetColorForToday = Color.Cyan
        ElseIf Today.Date.DayOfWeek = DayOfWeek.Wednesday Then
            GetColorForToday = Color.DeepSkyBlue
        ElseIf Today.Date.DayOfWeek = DayOfWeek.Thursday Then
            GetColorForToday = Color.DodgerBlue
        ElseIf Today.Date.DayOfWeek = DayOfWeek.Friday Then
            GetColorForToday = Color.SkyBlue
        Else
            GetColorForToday = Color.Aquamarine
        End If
    End Function
    Public Function ImageToBytes(ByVal filepath As String) As Byte()
        Dim fs As New IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
        Dim br As New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(fs.Length)
        br.Close()
        fs.Close()
        Return bytes
    End Function
    Public Function UpdateLogFile(ByVal pTbl As String, ByVal pAction As String, ByVal pF1 As String, ByVal pF2 As String, ByVal pF3 As String, ByVal pF4 As String, ByVal pF5 As String, Optional ByVal pF6 As String = "", Optional ByVal pF7 As String = "", Optional ByVal pF8 As String = "", Optional ByVal pF9 As String = "", Optional ByVal pF10 As String = "", Optional ByVal pF11 As String = "", Optional ByVal pF12 As String = "") As String
        Dim KQ As String = "insert ActionLog (TableName, doWhat, F1, F2, F3, F4, F5, F6, F7, F8, f9,f10, F11,F12,city, ActionBy) Values ('"
        KQ = KQ & pTbl & "','" & pAction & "','" & pF1 & "','" & pF2 & "','" & pF3 & "','" & pF4 & "','" & pF5 & "','" & pF6 & "','" &
                pF7 & "','" & pF8 & "','" & pF9 & "','" & pF10 & "','" & pF11 & "','" & pF12 & "','" & pobjUser.City & "','" & pobjUser.UserName & "')"
        Return KQ
    End Function
    Public Sub InHoaDon(ByVal strPath As String, ByVal parFileName As String, ByVal parViewPrint As String, ByVal parRCPNO As String, ByVal parFrm As Date, ByVal parTo As Date, ByVal ParNewValue As Decimal, ByVal pAL As String, ByVal pDomain As String, Optional ByVal ParLoaiHD As String = "")
        Dim AppXls As Microsoft.Office.Interop.Excel.Application, WkBook As Microsoft.Office.Interop.Excel.Workbook, WkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim varAL As String
        If parFileName = "" Then
            MsgBox("Please Select Invoice Type", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        End If
        varAL = Dir(strPath & "\" & parFileName)
        If varAL = "" Then
            MsgBox("Template File Not Found. Plz Check", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        End If
        On Error Resume Next
        AppXls = CreateObject("Excel.Application")
        On Error GoTo 0
        If parRCPNO <> "" Then
            varAL = parRCPNO.Substring(0, 2)
        Else
            varAL = pAL
        End If
        On Error GoTo CloseXLS
        WkBook = AppXls.Workbooks.Open(strPath & "\" & parFileName, , , , "aibiet", , , , , True)
        WkSheet = WkBook.Worksheets("Para")
        WkSheet.Cells.Range("B1").Value = parRCPNO
        WkSheet.Cells.Range("B2").Value = varAL
        WkSheet.Cells.Range("B3").Value = pobjUser.UserName
        WkSheet.Cells.Range("B4").Value = parFrm
        WkSheet.Cells.Range("B5").Value = parTo
        WkSheet.Cells.Range("B6").Value = ParNewValue
        WkSheet.Cells.Range("B7").Value = pDomain
        WkSheet.Cells.Range("B8").Value = ParLoaiHD
        WkSheet.Cells.Range("B9").Value = parViewPrint
        WkSheet.Cells.Range("B15").Value = "YES"
        If InStr("PVOF", parViewPrint) = 0 Then GoTo CloseXLS
        WkSheet = WkBook.Worksheets("RPT")
        If parViewPrint = "V" Then
            AppXls.Visible = True
            WkSheet.PrintPreview(vbNo)
        ElseIf parViewPrint = "P" Then
            AppXls.Visible = True
            WkSheet.PrintPreview(vbNo)
        ElseIf parViewPrint = "O" Then
            AppXls.Visible = False
            WkSheet.PrintOut()
            '^_^20221121 add by 7643 -b-
        ElseIf parViewPrint = "F" Then
            AppXls.Visible = True
            Dim strSavedFile As String = "d:\" & parFileName.Split(".")(0) & ".xlsx"
            WkBook.SaveAs(strSavedFile, Excel.XlFileFormat.xlWorkbookDefault,, "aibiet")
            MsgBox("Exported file " & strSavedFile)
            '^_^20221121 add by 7643 -e-
        End If
CloseXLS:
        WkBook.Close(SaveChanges:=False)
        AppXls.Quit()
        AppXls = Nothing
        On Error GoTo 0
    End Sub
    Public Function SetMenuStatus(ByRef objMenu As MenuStrip, ByRef objUser As clsUser) As Boolean

        For Each objSubMenu1 As ToolStripMenuItem In objMenu.Items
            If objSubMenu1.Name.StartsWith("pac") Then
                For Each objSubMenu2 As ToolStripMenuItem In objSubMenu1.DropDownItems
                    If objSubMenu2.Name.StartsWith("pac") Then
                        For Each objSubMenu3 As ToolStripMenuItem In objSubMenu2.DropDownItems
                            objSubMenu3.Enabled = objUser.HasRight("menu", Mid(objSubMenu2.Name, 4), objSubMenu3.Name)
                        Next
                    Else
                        objSubMenu2.Enabled = objUser.HasRight("menu", Mid(objSubMenu1.Name, 4), objSubMenu2.Name)
                    End If
                Next
            End If
        Next
        Return True
    End Function
    Public Function SumBkgByMonth4Customer(intBookYear As Integer, intBookMonth As Integer) As Boolean
        Dim lstQuerries As New List(Of String)
        Dim strSumAllStats As String
        Dim strSumHx As String
        Dim strSumBkg As String
        Dim intRegion As Integer = IIf(pobjUser.Region = "South", 1, 2)
        Dim intYearMonth As Integer = intBookYear & intBookMonth.ToString.PadLeft(2, "0")

        lstQuerries.Add("Delete Data1A_SumBkgByMonth where CustType=1 and BookYear=" & intBookYear _
                        & " and BookMonth=" & intBookMonth & " and Region=" & intRegion)
        strSumAllStats = "Insert Data1A_SumBkgByMonth (Source,Region,CustType,ShortName" _
                    & ",BookYear,BookMonth,Bkg,FstUser) " _
                    & "Select 1," & intRegion & ",1,c.ShortName," _
                    & intBookYear & "," & intBookMonth _
                    & ",ISNULL(SUM((Add1+Add2)-(Can1+can2)),0)" _
                    & ",'" & pobjUser.UserName _
                    & "' from [AllStatsSI] a " _
                    & " LEFT JOIN DATA1A_OIDs o on o.OffcId=a.Office" _
                    & " left join DATA1A_Customers c on c.ShortName=o.ShortName" _
                    & " where a.NoIncentive='N' and a.BookMonth=" & intBookMonth _
                    & " and a.BookYear =" & intBookYear _
                    & " and o.Status='ok' and o.GDS='1A'" _
                    & " and c.Status='ok' and c.Region='" & pobjUser.Region & "'"

        strSumAllStats = strSumAllStats & " group by c.ShortName,BookYear,BookMonth" _
                    & " order by c.ShortName,BookMonth"
        lstQuerries.Add(strSumAllStats)

        strSumHx = "Insert Data1A_SumBkgByMonth (Source,Region,CustType,ShortName" _
                    & ",BookYear,BookMonth,Bkg,FstUser) " _
                    & "Select 2," & intRegion & ",1,c.ShortName," _
                    & intBookYear & "," & intBookMonth _
                    & ",SUM(0-Can1),'" & pobjUser.UserName _
                    & "' from [HX] h " _
                    & " LEFT JOIN DATA1A_OIDs o on o.OffcId=h.Office" _
                    & " left join DATA1A_Customers c on c.ShortName=o.ShortName" _
                    & " where h.BookMonth=" & intBookMonth _
                    & " and h.BookYear =" & intBookYear _
                    & " and o.Status='ok' and o.GDS='1A'" _
                    & " and c.Status='ok' and c.Region='" & pobjUser.Region & "'"

        strSumHx = strSumHx & " group by c.ShortName,BookYear,BookMonth" _
                    & " order by c.ShortName,BookMonth"
        lstQuerries.Add(strSumHx)

        strSumBkg = "Insert Data1A_SumBkgByMonth (Source,Region,CustType,ShortName" _
                    & ",BookYear,BookMonth,Bkg,FstUser) " _
                    & " Select 0," & intRegion & ",CustType,ShortName" _
                    & ",BookYear,BookMonth,SUM(Bkg),'" & pobjUser.UserName _
                    & "' from Data1A_SumBkgByMonth where Source <>0" _
                    & " and CustType=1" _
                    & " and BookYear =" & intBookYear & " and BookMonth=" & intBookMonth _
                    & " and Region='" & intRegion & "'"

        strSumBkg = strSumBkg & " group by ShortName,CustType,BookYear,BookMonth"

        'tinh tong bkg thang
        lstQuerries.Add(strSumBkg)
        lstQuerries.Add("Update Data1A_SumBkgByMonth set YearMonth=" & intYearMonth _
                        & " where BookYear =" & intBookYear & " and BookMonth=" & intBookMonth)

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("SumBkg for Customer in year " & intBookYear & " month " & intBookMonth & " completed!")
        Else
            MsgBox("SumBkg for Customer in year " & intBookYear & " month " & intBookMonth & " NOT completed!")
        End If
        Return True
    End Function
    Public Function GetUnidentifiedOIDsInMidt(intBookYear As Integer, intBookMonth As Integer _
                                              , strRegion As String) As System.Data.DataTable
        Return pobjSql.GetDataTable("SELECT distinct GDS,city,AgentName" _
                                    & ",CrsCode,ArcIata,AccountName,AccountAddress" _
                                    & " FROM MIDT_RAW" _
                                    & " WHERE Year(Date_b)=" & intBookYear _
                                    & " and Month(Date_b)=" & intBookMonth _
                                    & " and City='" & pobjUser.City _
                                    & "' AND AgentName in ('','??')")
    End Function
    Public Function GetNon1aOIDsInMidt(intBookYear As Integer, intBookMonth As Integer _
                                              , strRegion As String) As System.Data.DataTable
        Return pobjSql.GetDataTable("SELECT distinct GDS,city,AgentName" _
                                    & ",CrsCode,ArcIata,AccountName,AccountAddress" _
                                    & " FROM MIDT_RAW" _
                                    & " WHERE Year(Date_b)=" & intBookYear _
                                    & " and Month(Date_b)=" & intBookMonth _
                                    & " and City='" & pobjUser.City _
                                    & "' AND AgentName NOT IN" _
                                    & " (SELECT ShortName FROM DATA1A_Customers" _
                                    & " WHERE STATUS<>'XX' and Region='" & strRegion & "')")
    End Function
    Public Function GetUnidentifiedOIDsInAllstats(intBookYear As Integer, intBookMonth As Integer _
                                              , strRegion As String) As DataTable
        Return pobjSql.GetDataTable("SELECT distinct city,agency,office FROM ALLSTATSSI" _
                    & " WHERE NOINCENTIVE='N' and BookYear=" & intBookYear _
                    & " and BookMonth=" & intBookMonth _
                    & " and City='" & pobjUser.City _
                    & "' AND OFFICE NOT IN" _
                    & " (SELECT OFFCID FROM DATA1A_OIDS WHERE STATUS<>'XX' AND GDS='1A'" _
                    & " and Shortname in (Select Shortname from Data1a_Customers " _
                    & " where Status<>'xx' and Region='" & strRegion & "'))")
    End Function
    Public Function SumMidtByMonth(intBookYear As Integer, intBookMonth As Integer) As Boolean
        Dim lstQuerries As New List(Of String)
        Dim strSumMidt As String
        Dim intRegion As Integer = IIf(pobjUser.Region = "South", 1, 2)
        Dim intYearMonth As Integer = intBookYear & intBookMonth.ToString.PadLeft(2, "0")

        lstQuerries.Add("Delete Data1A_SumMidtByMonth where BookYear=" & intBookYear _
                        & " and BookMonth=" & intBookMonth & " and Region=" & intRegion)
        strSumMidt = "Insert Data1A_SumMidtByMonth (GDS,Region,ShortName" _
                    & ",BookYear,BookMonth,YearMonth,Bkg,FstUser) " _
                    & "Select GDS," & intRegion & ",m.AgentName," _
                    & intBookYear & "," & intBookMonth & "," & intYearMonth _
                    & ",ISNULL(SUM(NetBkg),0)" _
                    & ",'" & pobjUser.UserName _
                    & "' from [MIDT_Raw] m " _
                    & " left join DATA1A_Customers c on c.ShortName=m.AgentName" _
                    & " where Month(Date_b)=" & intBookMonth _
                    & " and Year(Date_b) =" & intBookYear _
                    & " and c.Status='ok' and c.Region='" & pobjUser.Region & "'"

        strSumMidt = strSumMidt & " group by m.Gds, m.AgentName, Year(Date_b),Month(Date_b)"
        lstQuerries.Add(strSumMidt)


        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("SumMidt for in year " & intBookYear & " month " & intBookMonth & " completed!")
        Else
            MsgBox("SumMidt for year " & intBookYear & " month " & intBookMonth & " NOT completed!")
        End If
        Return True
    End Function
    Public Function LogReport(strPrg As String, strReportName As String, strUser As String, strCity As String) As Boolean
        Dim strQuerry As String = "insert into MISC_WzDate (CAT, VAL, VAL1,FstUser,City)" _
            & " values ('DoReport','" & strPrg & "','" & strReportName _
            & "','" & strUser & "','" & strCity & "')"
        Return pobjSql.ExecuteNonQuerry(strQuerry)
    End Function

    '^_^20230112 add by 7643 -b-
    Public Sub FormatNumber(xDgv As DataGridView, xCols As List(Of String))
        Dim i As Integer

        For i = 0 To xCols.Count - 1
            xDgv.Columns(xCols(i)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            xDgv.Columns(xCols(i)).DefaultCellStyle.Format = "N0"
        Next
    End Sub

    Public Sub SelectPage(xTab As TabControl, xPage As TabPage)
        xTab.TabPages.Clear()
        xTab.TabPages.Add(xPage)
    End Sub

    Public Sub LoadDataGridView2(ByRef dgInput As DataGridView, ByVal strQuerry As String, ByRef xSda As SqlClient.SqlDataAdapter, ByRef xDs As DataSet)
        xDs = New DataSet
        xSda = New SqlClient.SqlDataAdapter(strQuerry, pobjSql.Connection)
        xSda.Fill(xDs, "Result")
        dgInput.DataSource = xDs.Tables("Result")
        xDs.Dispose()
        xSda.Dispose()
    End Sub

    Public Sub BeginTrans()
        cmd.Connection = pobjSql.Connection
        FTrans = pobjSql.Connection.BeginTransaction
        cmd.Transaction = FTrans
    End Sub

    Public Sub CommitTrans()
        FTrans.Commit()
    End Sub

    Public Sub RollbackTrans()
        FTrans.Rollback()
    End Sub

    Public Sub dgvIntSort(e As DataGridViewSortCompareEventArgs)
        e.SortResult = CInt(e.CellValue1).CompareTo(CInt(e.CellValue2))
        e.Handled = True
    End Sub
    '^_^20230112 add by 7643 -e-

    '^_^20230209 add by 7643 -b-
    Public Function cboValidated(xCbo As ComboBox) As Boolean
        If xCbo.Items.Count = 0 Then
            xCbo.Text = ""
            Return False
        End If

        xCbo.SelectedIndex = IIf(xCbo.Text = "" Or xCbo.FindString(xCbo.Text) = -1, 0, xCbo.FindString(xCbo.Text))

        Return True
    End Function

    Public Sub FormatDgvNumber(xDgv As DataGridView, xCols() As String)
        Dim i As Integer

        For i = 0 To xCols.Length - 1
            xDgv.Columns(xCols(i)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            xDgv.Columns(xCols(i)).DefaultCellStyle.Format = "N0"
        Next
    End Sub

    Public Sub DefaultControldvalue(xParent As Object, xDgv As DataGridView, Optional xDgv2 As DataGridView = Nothing)
        Dim i, j, t As Integer
        Dim mControl As Control
        Dim mArrObj() As Object
        Dim mtest As String

        For i = 0 To CType(xParent, Control).Controls.Count - 1
            mControl = New Control
            mControl = CType(xParent, Control).Controls(i)
            If TypeOf mControl Is TextBox Then
                mControl.Text = xDgv.CurrentRow.Cells(Split(mControl.Name, "txt")(1)).Value
            ElseIf TypeOf mControl Is ComboBox Then
                mtest = xDgv.CurrentRow.Cells(Split(mControl.Name, "cbo")(1)).Value
                CType(mControl, ComboBox).SelectedValue = xDgv.CurrentRow.Cells(Split(mControl.Name, "cbo")(1)).Value
            ElseIf TypeOf mControl Is DateTimePicker Then
                CType(mControl, DateTimePicker).Value = xDgv.CurrentRow.Cells(Split(mControl.Name, "dtp")(1)).Value
            ElseIf TypeOf mControl Is DataGridView Then
                ReDim mArrObj(CType(mControl, DataGridView).Columns.GetColumnCount(0) - 1)
                For j = 0 To xDgv2.Rows.Count - 1
                    For t = 0 To CType(mControl, DataGridView).Columns.GetColumnCount(0) - 1
                        mArrObj(t) = xDgv2.Rows(j).Cells(CType(mControl, DataGridView).Columns(t).Name).Value
                    Next
                    CType(mControl, DataGridView).Rows.Add(mArrObj)
                Next
            End If
        Next
    End Sub
    '^_^20230209 add by 7643 -e-
End Module
