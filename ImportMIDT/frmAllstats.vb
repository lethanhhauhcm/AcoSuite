Imports System.Diagnostics.Process
Imports Microsoft.VisualBasic.FileIO.TextFieldParser
Imports System.IO
Imports Microsoft.Office.Interop

Imports System.Globalization

Public Class frmAllStats
    Dim tmpTbl As String
    Dim strSQL As String, fName As String
    Dim d1 As Date, d2 As Date
    Private ddanTxtFile As String = "W:\1A\DATA\RawData\SI_wz_Provider\"
    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        On Error Resume Next
        Dim strQuerry As String
        strQuerry = "drop table " & tmpTbl & "; drop table ##1" & Environment.MachineName.Replace("-", "")

        AutoUploadAllstat()
        On Error Resume Next
        pobjSql.ExecuteNonQuerry(strQuerry)
        Microsoft.VisualBasic.FileSystem.Kill("c:\allstat.txt")
        On Error GoTo 0

    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dd As String = My.Application.Info.DirectoryPath
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MMM-yy"

        BarThisMonth.Checked = True
        txtFrm.Value = DateSerial(Now.Year, Now.Month, 1)
        TxtTo.Text = Today().ToString("MM-yy")
        tmpTbl = "##" & Environment.MachineName.Replace("-", "")
        InitiateAll()
        'LoadGridTarget()
        pobjSql.LoadCombo(cboShortName, "select ShortName AS value from DATA1A_Customers where status='OK' order by ShortName")
        cboShortName.SelectedIndex = -1
        AutoUploadAllstat()
    End Sub

    Private Sub ResetPadTimeInput()
        BarThisYear.Checked = False
        BarLastYear.Checked = False
        BarThisQuarter.Checked = False
        BarLastQuarter.Checked = False
        BarThisMonth.Checked = False
        BarLastMonth.Checked = False
        BarThisWeek.Checked = False
        BarCustom.Checked = False
        txtFrm.Enabled = BarCustom.Checked
        TxtTo.Enabled = BarCustom.Checked
        lblFrm.Enabled = BarCustom.Checked
        LblTo.Enabled = BarCustom.Checked
    End Sub
    Private Sub BarThisYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarThisYear.Click
        ResetPadTimeInput()
        BarThisYear.Checked = True
    End Sub
    Private Sub BarLastYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarLastYear.Click
        ResetPadTimeInput()
        BarLastYear.Checked = True
    End Sub
    Private Sub BarThisQuarter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarThisQuarter.Click
        ResetPadTimeInput()
        BarThisQuarter.Checked = True
    End Sub

    Private Sub BarLastQuarter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarLastQuarter.Click
        ResetPadTimeInput()
        BarLastQuarter.Checked = True
    End Sub

    Private Sub BarThisMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarThisMonth.Click
        ResetPadTimeInput()
        txtFrm.Value = DateSerial(Now.Year, Now.Month, 1)
        TxtTo.Value = Now
        BarThisMonth.Checked = True
    End Sub

    Private Sub BarLastMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarLastMonth.Click
        ResetPadTimeInput()
        txtFrm.Value = DateSerial(Now.Year, Now.Month, 1).AddMonths(-1)
        TxtTo.Value = DateSerial(Now.Year, Now.Month, 1).AddDays(-1)
        BarLastMonth.Checked = True
    End Sub

    Private Sub BarCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarCustom.Click
        ResetPadTimeInput()
        BarCustom.Checked = True
        txtFrm.Enabled = BarCustom.Checked
        TxtTo.Enabled = BarCustom.Checked
        lblFrm.Enabled = BarCustom.Checked
        LblTo.Enabled = BarCustom.Checked
    End Sub
    Private Sub DefineStrDK()
        'pubVarStrDK = " AL not in (select VAL from midt_MISC where cat='LCC') and "
        pubVarStrDK = ""
        If BarThisYear.Checked Then
            pubVarStrDK = pubVarStrDK & "BookYear='" & Date.Today.Year & "'"
            d1 = DateSerial(Date.Today.Year, 1, 1)
            d2 = DateAdd(DateInterval.Day, -1, Now.Date)
        ElseIf BarLastYear.Checked Then
            pubVarStrDK = pubVarStrDK & "BookYear='" & Date.Today.Year - 1 & "'"
            d1 = DateSerial(Date.Today.Year - 1, 1, 1)
            d2 = DateSerial(Date.Today.Year - 1, 12, 31)
        ElseIf BarThisMonth.Checked Then
            pubVarStrDK = pubVarStrDK & "BookYear='" & Date.Today.Year & "' and BookMonth='" & Date.Today.Month & "'"
            d1 = DateSerial(Date.Today.Year, Date.Today.Month, 1)
            d2 = DateAdd(DateInterval.Day, -1, Now.Date)
        ElseIf BarLastMonth.Checked Then
            If Date.Today.Month > 1 Then
                pubVarStrDK = pubVarStrDK & "Bookyear='" & Date.Today.Year & "' and bookmonth='" & Date.Today.Month - 1 & "'"
                d1 = DateSerial(Date.Today.Year, Date.Today.Month - 1, 1)
                d2 = DateAdd(DateInterval.Day, -1, DateSerial(Date.Today.Year, Date.Today.Month, 1))
            Else
                pubVarStrDK = pubVarStrDK & "Bookyear='" & Date.Today.Year - 1 & "' and bookmonth=12"
                d1 = DateSerial(Date.Today.Year - 1, 12, 1)
                d2 = DateSerial(Date.Today.Year - 1, 12, 31)
            End If
        ElseIf BarThisQuarter.Checked Then
            d1 = DefineD(1, "This")
            d2 = DateAdd(DateInterval.Day, -1, Now.Date)
            pubVarStrDK = pubVarStrDK & "BookDate >='" & d1 & "' and bookDate <='" & d2 & " '"
        ElseIf BarLastQuarter.Checked Then
            d1 = DefineD(1, "Last")
            d2 = DefineD(2, "Last")
            pubVarStrDK = pubVarStrDK & "BookDate >='" & d1 & "' and bookDate <='" & d2 & " '"
        ElseIf BarThisWeek.Checked Then
            d2 = DateAdd(DateInterval.Day, -1, Date.Today)
            d1 = DateAdd(DateInterval.Day, -7, d2)
            pubVarStrDK = pubVarStrDK & "BookDate >='" & d1 & "' and bookDate <='" & d2 & " '"
        ElseIf BarCustom.Checked Then
            d1 = Me.txtFrm.Value
            d2 = Me.TxtTo.Value
            pubVarStrDK = pubVarStrDK & "BookDate >='" & d1 & "' and bookDate <='" & d2 & " '"
            Me.TxtDRPT.Text = DateDiff(DateInterval.Day, d1, d2)
        End If
        Me.TxtDRPT.Text = DateDiff(DateInterval.Day, d1, d2) + 1

        If cboShortName.SelectedIndex <> -1 Then
            pubVarStrDK = pubVarStrDK & " and office in (select offcid from data1a_oids where shortname='" _
                & cboShortName.Text & "' and status='ok' and gds='1a')"
        End If
    End Sub
    Private Sub GenAgtList(ByVal parPOS As String)

        strSQL = "select distinct Office from AllStatsSI "
        If parPOS <> "ALL" Then
            strSQL = strSQL & " where left(Office,3)='" & parPOS & "'"
        End If
        strSQL = strSQL & " order by Office"
        cmd = New SqlClient.SqlCommand(strSQL, pobjSql.Connection)
        Me.ComboAgent.Items.Clear()
        Me.ComboAgent.Items.Add("ALL")
        dReader = cmd.ExecuteReader
        Do While dReader.Read
            Me.ComboAgent.Items.Add(dReader.Item("Office"))
        Loop
        dReader.Close()
    End Sub
    Private Sub InitiateAll()
        GenAgtList("ALL")

        Me.CmbPOS.Text = "ALL"
    End Sub
    Private Sub ComboPOS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPOS.SelectedIndexChanged
        GenAgtList(Me.CmbPOS.Text)
        Me.ComboAgent.Text = Me.ComboAgent.Items(0).ToString
        '        LoadGridTarget()
    End Sub
    Private Sub BarThisWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarThisWeek.Click
        ResetPadTimeInput()
        BarThisWeek.Checked = True
    End Sub



    Private Sub LstFieldList_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstFieldList.SelectedValueChanged
        Dim i As Int16, YM As Int16

        For i = 0 To Me.LstFieldList.Items.Count - 1
            If Me.LstFieldList.GetItemChecked(i) Then
                If InStr(Me.LstFieldList.Items(i).ToString, "Month") + InStr(Me.LstFieldList.Items(i).ToString, "Year") = 0 Then
                    YM = 8
                    'If Me.LstFieldList.Items(i).ToString = "Agency" Then Me.ChkAgent_Grp.Enabled = True
                    'If Me.LstFieldList.Items(i).ToString = "SICodeSix" Then Me.ChkBooker.Enabled = True
                Else
                    YM = YM + 1
                End If
            End If
        Next
        'If YM = 2 Then Me.ChkVsTarget.Enabled = True
    End Sub



    Private Sub TxtDAllStat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDAllStat.TextChanged
        If Me.TxtDAllStat.Text = Me.TxtDRPT.Text Then
            Me.TxtDAllStat.ForeColor = Color.Black
            Me.LblDAllstat.Enabled = False
        Else
            Me.TxtDAllStat.ForeColor = Color.Red
            Me.LblDAllstat.Enabled = True
        End If
    End Sub

    Private Sub TxtDHX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDHX.TextChanged
        If Me.TxtDHX.Text = Me.TxtDRPT.Text Then
            Me.TxtDHX.ForeColor = Color.Black
            Me.LblDHX.Enabled = False
        Else
            Me.TxtDHX.ForeColor = Color.Red
            Me.LblDHX.Enabled = True
        End If
    End Sub

    Private Sub LblDAllstat_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblDAllstat.LinkClicked
        FindMissingDay("Allstatssi")
    End Sub

    Private Sub LblDHX_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblDHX.LinkClicked
        FindMissingDay("HX")
    End Sub
    Private Sub FindMissingDay(ByVal pTbl As String)
        Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand, i As Int16, Msg As String = ""
        Dim dReader As SqlClient.SqlDataReader
        cmd.CommandText = "Delete from yCheckMissing"
        cmd.ExecuteNonQuery()
        For i = 0 To CInt(Me.TxtDRPT.Text) - 1
            cmd.CommandText = "insert yCheckMissing (DD) values ('" & DateAdd(DateInterval.Day, i, d1) & "')"
            cmd.ExecuteNonQuery()
        Next
        cmd.CommandText = "select DD from yCheckMissing where dd not in (select Bookdate from " & pTbl & ")"
        dReader = cmd.ExecuteReader
        Do While dReader.Read
            Msg = Msg & vbCrLf & dReader.Item("DD")
        Loop
        dReader.Close()
        MsgBox(Msg, MsgBoxStyle.Critical, "Amadeus Vietnam :: Missing Data for " & pTbl)
    End Sub

    Private Sub BarUManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim f As New UManager("UM")
        'f.ShowDialog()
    End Sub

    Private Sub BarChangePSW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim f As New UManager("CP")
        'f.ShowDialog()

    End Sub
    Private Sub BarSI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.BarSI.Text = "SignIn" Then
        '    Me.BarSI.Text = "SignOut"
        '    Dim f As New UManager("SI")
        '    f.ShowDialog()
        'Else
        '    Me.BarChangePSW.Enabled = False
        '    Me.BarUManager.Enabled = False
        '    MyRole = "*"
        '    Me.BarSI.Text = "SignIn"
        'End If
    End Sub


    Private Sub AutoUploadAllstat(Optional parFName As String = "")
        Dim dDan As String
        Dim strYYMMDD As String, dBook As Date, fName As String
        Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand

        If Not parFName.Contains("\") Then
            dDan = "W:\1A\DATA\RawData\SI_wz_Provider\"
        End If
        If parFName = "" Then
            fName = Dir(dDan & "File04_????????.xls")
        ElseIf Not parFName.Contains("\") Then
            fName = Dir(dDan & parFName)
        Else
            fName = parFName
        End If
        Do While fName <> ""
            Dim arrPathBreaks() As String = fName.Split("\")
            strYYMMDD = arrPathBreaks(arrPathBreaks.Length - 1).Split("_")(1).Replace(".xls", "")
            dBook = DateSerial(strYYMMDD.Substring(0, 4), strYYMMDD.Substring(4, 2), Strings.Right(strYYMMDD, 2))
            cmd.CommandText = "delete from allstatssi where bookdate=@bookdate"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@bookdate", SqlDbType.DateTime).Value = dBook
            cmd.CommandTimeout = 256
            cmd.ExecuteNonQuery()

            ManualUpload(dDan & fName)

            If parFName <> "" Then Exit Do
            fName = Dir()
        Loop
    End Sub
    Private Sub ReuploadManuallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FName As String = InputBox("Enter FileName You Wanna to Manually Upload", "VietNam ACO :: AllstatsUpload", "f04_" & Format(Now, "yyyyMMdd") & ".csv")
        AutoUploadAllstat(FName)
    End Sub
    Private Sub ManualUpload(pfName As String)
        Dim i As Integer
        Dim objExcel As New Excel.Application
        Dim objWbk As Excel.Workbook
        Dim objWsh As Excel.Worksheet
        Dim lstQuerries As New List(Of String)
        Dim intEndRow As Integer
        Dim strBkgDate As String = String.Empty
        '^_^20221031 add by 7643 -b-
        Dim mTrans As SqlClient.SqlTransaction
        Dim mBeginFrame, mFinalFrame As Date
        Dim mQuarterNum, mBeginMonth, mFinalMonth, mHalfYearNum, mNumDay, mSegPerDay, mSSegDesc, mSegDesc, mCan1 As Integer
        Dim mReturn As New DataTable
        Dim mAdap As New SqlClient.SqlDataAdapter
        Dim mDs As New DataSet
        '^_^20221031 add by 7643 -e-

        objWbk = objExcel.Workbooks.Open(pfName,, True)
        objWsh = objWbk.ActiveSheet

        '^_^20221031 mark by 7643 -b-
        'With objWsh
        '    intEndRow = objWsh.Range("A" & 8192).End(Excel.XlDirection.xlUp).Row
        '    If intEndRow < 2 Then
        '        MsgBox("Invalid or empty file!")
        '    Else
        '        strBkgDate = CreateFromDate(.Range("C2").Value)
        '    End If

        '    For i = 2 To intEndRow
        '        lstQuerries.Add("insert Allstatssi (BookYear, BookMonth, BookDate , Office" _
        '                        & " , Agency, SICode, AL, Add1, Can1, City)" _
        '                        & " values (" & .Range("A" & i).Value _
        '                        & "," & .Range("B" & i).Value _
        '                        & ",'" & CreateFromDate(.Range("C" & i).Value) _
        '                        & "','" & .Range("D" & i).Value & "','" & .Range("E" & i).Value _
        '                        & "','" & .Range("F" & i).Value & "','" & .Range("G" & i).Value _
        '                        & "'," & .Range("H" & i).Value & "," & .Range("I" & i).Value _
        '                        & ",'" & Mid(.Range("D" & i).Value, 1, 3) & "')")
        '    Next
        'End With

        'lstQuerries.Add("update Allstatssi set NoIncentive='Y' where NoIncentive='' " _
        '                    & " and BookDate='" & strBkgDate _
        '                    & "' and AL in (Select VAL from data1a_misc where cat='NoIncentiveCar')")

        'lstQuerries.Add("update Allstatssi set NoIncentive='Y' where NoIncentive='' " _
        '                    & " and BookDate='" & strBkgDate & "' and Office in " _
        '                    & " (Select VAL from misc_wzDate where cat='NoIncentiveOID'" _
        '                    & " and Status='OK' and '" & strBkgDate & "' between FromDate and Todate)")
        'lstQuerries.Add("update Allstatssi set NoIncentive='Y' where NoIncentive=''" _
        '                    & " and BookDate='" & strBkgDate & "' and AL in ('BA','IB') and Office in " _
        '                    & " (Select VAL from misc_wzDate where cat='NoIncentiveBAIB'" _
        '                    & " and Status='OK' and '" & strBkgDate & "' between FromDate and Todate)")

        'lstQuerries.Add("update Allstatssi set NoIncentive='N' where NoIncentive='' " _
        '                    & " and AL not in (Select VAL from data1a_misc where cat='NoIncentiveCar')")

        ''Manual Deduct Bkg
        'lstQuerries.Add("Delete Data1a_DeductBkgRuleResult where BookDate='" & strBkgDate & "'")
        'lstQuerries.Add("insert Data1a_DeductBkgRuleResult ( BookDate, Office, SIcodeSix, Can1, DeductionId,Agency" _
        '                    & ",ShortName,ContactId) " _
        '                    & "Select '" & strBkgDate & "',d.OffcId,d.SignIn" _
        '                    & ",round(cast(a.NetBkg as decimal(7,2)) *r.pct/100,0),d.DeductionId,Agency" _
        '                    & ",o.ShortName, s.ContactId" _
        '                    & " From Data1a_DeductBkgRule_D d " _
        '                    & " Left Join Data1a_DeductBkgRule r on d.Deductionid=r.recid" _
        '                    & " Left Join (select bookdate, sum(Add1-Can1) as NetBkg, office, SICode,Agency " _
        '                    & " From AllStatsSI where BookDate='" & strBkgDate _
        '                    & "' Group By Bookdate, office, SICode,Agency" _
        '                    & " having sum(Add1-Can1) > 0) a on d.offcid=a.office And d.signin = substring(a.SICode,1,6)" _
        '                    & " left join DATA1A_OIDs o on o.OffcId=d.OffcId and o.Status='OK' AND o.GDS='1A'" _
        '                    & " left join DATA1A_SignIn1As s on s.OffcId=d.OffcId and s.SignIn=d.SignIn and s.Status='OK' " _
        '                    & " where '" & strBkgDate & "' between FromDate and Todate" _
        '                    & "  and NetBkg>0 ")

        'pfName = pfName.ToLower
        '^_^20221031 mark by 7643 -e-
        Try
            '^_^20221031 mark by 7643 -b-
            'If pobjSql.UpdateListOfQuerries(lstQuerries) Then

            '    'File.Copy(pfName, pfName.Replace(" \ File", "\f"))
            '    'File.Delete(pfName)
            'Else
            '    MsgBox("Unable To upload file " & pfName)
            'End If
            '^_^20221031 mark by 7643 -e-
            '^_^20221031 modi by 7643 -b-
            mTrans = pobjSql.Connection.BeginTransaction
            cmd.Transaction = mTrans
            cmd.Connection = pobjSql.Connection

            With objWsh
                intEndRow = objWsh.Range("A" & 8192).End(Excel.XlDirection.xlUp).Row
                If intEndRow < 2 Then
                    MsgBox("Invalid or empty file!")
                Else
                    strBkgDate = CreateFromDate(.Range("C2").Value)
                End If

                For i = 2 To intEndRow
                    cmd.CommandText = "insert Allstatssi (BookYear, BookMonth, BookDate , Office" _
                                    & " , Agency, SICode, AL, Add1, Can1, City)" _
                                    & " values (" & .Range("A" & i).Value _
                                    & "," & .Range("B" & i).Value _
                                    & ",'" & CreateFromDate(.Range("C" & i).Value) _
                                    & "','" & .Range("D" & i).Value & "','" & .Range("E" & i).Value _
                                    & "','" & .Range("F" & i).Value & "','" & .Range("G" & i).Value _
                                    & "'," & .Range("H" & i).Value & "," & .Range("I" & i).Value _
                                    & ",'" & Mid(.Range("D" & i).Value, 1, 3) & "')"
                    cmd.ExecuteNonQuery()
                Next
            End With

            cmd.CommandText = "update Allstatssi set NoIncentive='Y' where NoIncentive='' " _
                                & " and BookDate='" & strBkgDate _
                                & "' and AL in (Select VAL from data1a_misc where cat='NoIncentiveCar')"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update Allstatssi set NoIncentive='Y' where NoIncentive='' " _
                                & " and BookDate='" & strBkgDate & "' and Office in " _
                                & " (Select VAL from misc_wzDate where cat='NoIncentiveOID'" _
                                & " and Status='OK' and '" & strBkgDate & "' between FromDate and Todate)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update Allstatssi set NoIncentive='Y' where NoIncentive=''" _
                                & " and BookDate='" & strBkgDate & "' and AL in ('BA','IB') and Office in " _
                                & " (Select VAL from misc_wzDate where cat='NoIncentiveBAIB'" _
                                & " and Status='OK' and '" & strBkgDate & "' between FromDate and Todate)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update Allstatssi set NoIncentive='N' where NoIncentive='' " _
                                & " and AL not in (Select VAL from data1a_misc where cat='NoIncentiveCar')"
            cmd.ExecuteNonQuery()

            'Manual Deduct Bkg
            cmd.CommandText = "Delete Data1a_DeductBkgRuleResult where BookDate='" & strBkgDate & "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Select '" & strBkgDate & "',d.OffcId,d.SignIn" _
                                & ",round(cast(isnull(a.NetBkg,0) as decimal(7,2)) *r.pct/100,0) Can1,d.DeductionId,Agency" _
                                & ",o.ShortName, s.ContactId,FromDate,ToDate,Segment,TimeFrame,pct,isnull(a.NetBkg,0) NetBkg" _
                                & " From Data1a_DeductBkgRule_D d " _
                                & " Left Join Data1a_DeductBkgRule r on d.Deductionid=r.recid" _
                                & " Left Join (select bookdate, sum(Add1-Can1) as NetBkg, office, SICode,Agency " _
                                & " From AllStatsSI where BookDate='" & strBkgDate _
                                & "' Group By Bookdate, office, SICode,Agency" _
                                & " having sum(Add1-Can1) > 0) a on d.offcid=a.office And d.signin = substring(a.SICode,1,6)" _
                                & " left join DATA1A_OIDs o on o.OffcId=d.OffcId and o.Status='OK' AND o.GDS='1A'" _
                                & " left join DATA1A_SignIn1As s on s.OffcId=d.OffcId and s.SignIn=d.SignIn and s.Status='OK' " _
                                & " where '" & strBkgDate & "' between FromDate and Todate" _
                                & "  and NetBkg>0 order by ShortName, OffcId, SignIn"
            mAdap = New SqlClient.SqlDataAdapter(cmd)
            mAdap.Fill(mDs)
            mReturn = mDs.Tables(0)
            For i = 0 To mReturn.Rows.Count - 1
                If mReturn.Rows(i).Item("Segment") = 0 Then
                    mSegDesc = 0
                    mCan1 = mReturn.Rows(i).Item("Can1")
                Else
                    If mReturn.Rows(i).Item("TimeFrame") = "Month" Then
                        mBeginFrame = DateSerial(Year(strBkgDate), Month(strBkgDate), 1)
                        mFinalFrame = DateSerial(Year(strBkgDate), Month(strBkgDate), DateTime.DaysInMonth(Year(strBkgDate), Month(strBkgDate)))
                    ElseIf mReturn.Rows(i).Item("TimeFrame") = "Quarter" Then
                        mQuarterNum = Math.Truncate((Month(strBkgDate) - 1) / 3 + 1)
                        mBeginMonth = (mQuarterNum - 1) * 3 + 1
                        mFinalMonth = mBeginMonth + 2
                        mBeginFrame = DateSerial(Year(strBkgDate), mBeginMonth, 1)
                        mFinalFrame = DateSerial(Year(strBkgDate), mFinalMonth, DateTime.DaysInMonth(Year(strBkgDate), mFinalMonth))
                    ElseIf mReturn.Rows(i).Item("TimeFrame") = "HalfYear" Then
                        mHalfYearNum = Math.Truncate((Month(strBkgDate) - 1) / 6 + 1)
                        mBeginMonth = (mHalfYearNum - 1) * 6 + 1
                        mFinalMonth = mBeginMonth + 5
                        mBeginFrame = DateSerial(Year(strBkgDate), mBeginMonth, 1)
                        mFinalFrame = DateSerial(Year(strBkgDate), mFinalMonth, DateTime.DaysInMonth(Year(strBkgDate), mFinalMonth))
                    ElseIf mReturn.Rows(i).Item("TimeFrame") = "Year" Then
                        mBeginFrame = DateSerial(Year(strBkgDate), 1, 1)
                        mFinalFrame = DateSerial(Year(strBkgDate), 12, 31)
                    End If

                    If mBeginFrame < mReturn.Rows(i).Item("FromDate") Then mBeginFrame = mReturn.Rows(i).Item("FromDate")
                    If mFinalFrame > mReturn.Rows(i).Item("ToDate") Then mFinalFrame = mReturn.Rows(i).Item("ToDate")
                    mNumDay = DateDiff("d", mBeginFrame, mFinalFrame) + 1
                    mSegPerDay = Math.Ceiling(mReturn.Rows(i).Item("Segment") / mNumDay)
                    cmd.CommandText = "select isnull(sum(SegDesc),0) SSegDesc from Data1a_DeductBkgRuleResult " &
                                      "where Bookdate between '" & mBeginFrame & "' and '" & mFinalFrame & "' and ShortName='" & mReturn.Rows(i).Item("ShortName") & "'"
                    mSSegDesc = cmd.ExecuteScalar()

                    If mSSegDesc >= mReturn.Rows(i).Item("Segment") Then
                        mSegDesc = 0
                    Else
                        mSegDesc = IIf(mReturn.Rows(i).Item("Segment") - mSSegDesc < mSegPerDay, mReturn.Rows(i).Item("Segment") - mSSegDesc, mSegPerDay)
                    End If

                    If mReturn.Rows(i).Item("NetBkg") < mSegDesc Then mSegDesc = 0
                    mCan1 = mReturn.Rows(i).Item("NetBkg") - mSegDesc
                End If

                cmd.CommandText = "insert Data1a_DeductBkgRuleResult ( BookDate, Office, SIcodeSix, Can1, DeductionId," &
                                  "                                    Agency,ShortName,ContactId,SegDesc) " &
                                  "values('" & strBkgDate & "','" & mReturn.Rows(i).Item("OffcId") & "','" & mReturn.Rows(i).Item("SignIn") & "'," & mCan1 & "," & mReturn.Rows(i).Item("DeductionId") & "," &
                                  "       '" & mReturn.Rows(i).Item("Agency") & "','" & mReturn.Rows(i).Item("ShortName") & "'," & mReturn.Rows(i).Item("ContactId") & "," & mSegDesc & ")"
                cmd.ExecuteNonQuery()
            Next

            pfName = pfName.ToLower

            mTrans.Commit()
            '^_^20221031 modi by 7643 -e-
        Catch ex As Exception
            '^_^20221031 add by 7643 -b-
            mTrans.Rollback()
            Append2TextFile(vbNewLine & ex.Message & vbNewLine & cmd.CommandText)
            MsgBox("Unable To upload file " & pfName)
            '^_^20221031 add by 7643 -e-
        End Try

    End Sub
    'Private Sub ManualUpload(pfName As String)
    '    Dim afile As FileIO.TextFieldParser = New FileIO.TextFieldParser(pfName)
    '    Dim CurrentRecord As String() = Nothing
    '    Dim i As Integer

    '    afile.TextFieldType = FileIO.FieldType.Delimited
    '    afile.Delimiters = New String() {", "}
    '    afile.HasFieldsEnclosedInQuotes = True
    '    Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand

    '    Dim t As SqlClient.SqlTransaction = pobjSql.Connection.BeginTransaction
    '    cmd.Transaction = t

    '    cmd.CommandText = "insert Allstatssi (BookYear, BookMonth, BookDate, Office, Agency" _
    '            & ", SICode, AL, Add1, Can1, City) " _
    '            & " values (@BookYear, @BookMonth, @BookDate , @Office, @Agency" _
    '            & ", @SICode, @AL, @Add1, @Can1, @City)"
    '    cmd.Parameters.Add("@BookYear", SqlDbType.Int)
    '    cmd.Parameters.Add("@BookMonth", SqlDbType.Int)
    '    cmd.Parameters.Add("@BookDate", SqlDbType.DateTime)
    '    cmd.Parameters.Add("@Office", SqlDbType.VarChar)
    '    cmd.Parameters.Add("@Agency", SqlDbType.VarChar)
    '    cmd.Parameters.Add("@SICode", SqlDbType.VarChar)
    '    cmd.Parameters.Add("@AL", SqlDbType.VarChar)
    '    cmd.Parameters.Add("@Add1", SqlDbType.Int)
    '    cmd.Parameters.Add("@Can1", SqlDbType.Int)
    '    cmd.Parameters.Add("@City", SqlDbType.VarChar)
    '    Try
    '        Do While Not afile.EndOfData
    '            Try
    '                CurrentRecord = afile.ReadFields

    '                If Not CurrentRecord(0) = "Year" Then
    '                    For i = 0 To 8
    '                        Select Case i
    '                            Case 0, 1, 7, 8
    '                                cmd.Parameters(i).Value = CInt(CurrentRecord(i))
    '                            Case Else
    '                                cmd.Parameters(i).Value = CurrentRecord(i)
    '                        End Select

    '                    Next
    '                    cmd.Parameters(9).Value = CurrentRecord(3).Substring(0, 3)
    '                    cmd.ExecuteNonQuery()
    '                End If

    '            Catch ex As FileIO.MalformedLineException
    '                Stop
    '            End Try
    '        Loop
    '        afile.Close()
    '        t.Commit()
    '    Catch ex As Exception
    '        t.Rollback()
    '        MsgBox("Error Uploading " & pfName, MsgBoxStyle.Critical, "Vietnam ACO :: Allstats :. Data Upload")
    '    Finally
    '        Dim strBkgDate As String
    '        strBkgDate = pobjSql.GetScalarAsString("Select top 1 convert(varchar, BookDate ,106) From Allstatssi order by RecId desc")

    '        cmd.CommandText = "update Allstatssi set NoIncentive='Y' where NoIncentive='' " _
    '                        & " and AL in (Select VAL from data1a_misc where cat='NoIncentiveCar')"
    '        cmd.ExecuteNonQuery()

    '        cmd.CommandText = "update Allstatssi set NoIncentive='Y' where NoIncentive='' " _
    '                        & " and BookDate='" & strBkgDate & "' and Office in " _
    '                        & " (Select VAL from misc_wzDate where cat='NoIncentiveOID'" _
    '                        & " and Status='OK' and '" & strBkgDate & "' between FromDate and Todate)"
    '        cmd.ExecuteNonQuery()

    '        cmd.CommandText = "update Allstatssi set NoIncentive='Y' where NoIncentive=''" _
    '                        & " and BookDate='" & strBkgDate & "' and AL in ('BA','IB') and Office in " _
    '                        & " (Select VAL from misc_wzDate where cat='NoIncentiveBAIB'" _
    '                        & " and Status='OK' and '" & strBkgDate & "' between FromDate and Todate)"
    '        cmd.ExecuteNonQuery()

    '        cmd.CommandText = "update Allstatssi set NoIncentive='N' where NoIncentive='' " _
    '                        & " and AL not in (Select VAL from data1a_misc where cat='NoIncentiveCar')"
    '        cmd.ExecuteNonQuery()

    '    End Try
    '    pfName = pfName.ToLower
    '    Try
    '        File.Copy(pfName, pfName.Replace("\file", "\f"))
    '        File.Delete(pfName)
    '    Catch ex As Exception

    '    End Try

    'End Sub
    Private Sub BarGoAllStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarGoAllStats.Click
        Dim StrSelectWhat As String, i As Int16, j As Int16, Maxj As Int16 = 4, LclTmpTbl As String, StrDk As String
        Dim xNoIncentive As String
        Dim xNoIncentiveHx As String
        'cmd.CommandTimeout = 2048

        If Trim(Me.CmbPOS.Text) = "" Then Me.CmbPOS.Text = "ALL"
        DefineStrDK()
        If Me.ComboAgent.Text <> "ALL" Then
            pubVarStrDK = pubVarStrDK & " and Office='" & Me.ComboAgent.Text & "'"
        End If
        If Me.TxtAirline.Text <> "YY" Then
            pubVarStrDK = pubVarStrDK & " and AL='" & Me.TxtAirline.Text & "'"
        End If
        If Me.CmbPOS.Text <> "ALL" Then
            pubVarStrDK = pubVarStrDK & " and City='" & Me.CmbPOS.Text & "'"
        End If
        StrSelectWhat = ""
        j = 0
        For i = 0 To Me.LstFieldList.Items.Count - 1
            If Me.LstFieldList.GetItemChecked(i) Then
                j = j + 1
                StrSelectWhat = StrSelectWhat & ", " & Me.LstFieldList.Items(i).ToString
            End If
            If j > Maxj Then
                MsgBox("Cant Select More Than " & Maxj.ToString, MsgBoxStyle.Exclamation, "Amadeus Vietnam :: AllStats :. Report")
                Exit Sub
            End If
        Next
        If StrSelectWhat.Length < 2 Then
            MsgBox("No Field Seleted For Report", MsgBoxStyle.Critical, "Amadeus Vietnam :: AllStats :. Report")
            Exit Sub
        End If
        If Me.ChkAgent_Grp.Checked Then
            If InStr(StrSelectWhat, "Office") = 0 Then
                StrSelectWhat = StrSelectWhat & ", Office"
            End If
        End If
        cmd.CommandText = "select count(*) from (select distinct bookdate from allstatssi where bookdate between '" & d1 & "' and '" & d2 & "') as a"
        Me.TxtDAllStat.Text = cmd.ExecuteScalar
        cmd.CommandText = "select count(*) from (select distinct Bookdate from HX where BookDate between '" & d1 & "' and '" & d2 & "') as a"
        cmd.CommandTimeout = 2048
        Me.TxtDHX.Text = cmd.ExecuteScalar

        On Error Resume Next
        cmd.CommandText = "drop table " & tmpTbl
        cmd.ExecuteNonQuery()
        On Error GoTo 0
        'cmd.CommandText = "drop table AGT_OID"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "select * into agt_OID from midt_misc where cat='AGT_OID'"
        'cmd.ExecuteNonQuery()


        strSQL = strSQL & " into " & tmpTbl & " from AllstatsSI a "
        pubVarStrDK = " where " & pubVarStrDK
        xNoIncentive = pubVarStrDK & " and NoIncentive='N' group by " & StrSelectWhat.Substring(1)
        xNoIncentiveHx = pubVarStrDK & " and Incentified='true' group by " & StrSelectWhat.Substring(1)

        StrDk = pubVarStrDK & " group by " & StrSelectWhat.Substring(1)

        If StrSelectWhat.Contains("SICodeSix") Then StrSelectWhat = StrSelectWhat & " , space(64) as Booker "

        cmd.CommandText = "Select " & StrSelectWhat.Substring(1) & ",'2_CXLD' as DType, sum(CAN1) as Qty into " & tmpTbl & " from AllstatsSI a " & StrDk
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Insert " & tmpTbl & " select " & StrSelectWhat.Substring(1) & ",'1_BKD', sum(Add1) as Qty from AllstatsSI a " & StrDk
        cmd.CommandText = cmd.CommandText & "; Insert " & tmpTbl & " select " & StrSelectWhat.Substring(1) & ",'3_NET', sum(add1-Can1) as Qty from AllstatsSI a " & StrDk
        cmd.CommandText = cmd.CommandText & "; Insert " & tmpTbl & " select " & StrSelectWhat.Substring(1) & ",'4_HX', sum(can1) as Qty from HX a " & StrDk
        cmd.CommandText = cmd.CommandText & "; Insert " & tmpTbl & " select " & StrSelectWhat.Substring(1) & ",'CXLD2', sum(Can1) as Qty from AllstatsSI a " & StrDk
        cmd.CommandText = cmd.CommandText & "; Insert " & tmpTbl & " select " & StrSelectWhat.Substring(1) & ",'CXLD2', sum(can1) as Qty from HX a " & StrDk
        cmd.CommandText = cmd.CommandText & "; Insert " & tmpTbl & " select " & StrSelectWhat.Substring(1) & ",'Net2', sum(add1-Can1) as Qty from AllstatsSI a " & xNoIncentive
        cmd.CommandText = cmd.CommandText & "; Insert " & tmpTbl & " select " & StrSelectWhat.Substring(1) & ",'Net2', sum(can1*-1) as Qty from HX a " & xNoIncentiveHx
        cmd.CommandText = cmd.CommandText & "; Insert " & tmpTbl & " select " & StrSelectWhat.Substring(1) & ",'Net2', sum(can1*-1) as Qty from Data1a_DeductBkgRuleResult a " & StrDk
        cmd.ExecuteNonQuery()
        'If Me.ChkVsTarget.Checked Then
        '    LclTmpTbl = "##1" & Environment.MachineName
        '    strSQL = "select BookYear, BookMonth, NetBkg as NoOfBkg,'Actual  ' as ActualOrTarget "
        '    strSQL = strSQL & "into " & LclTmpTbl & " from " & tmpTbl
        '    cmd.CommandText = strSQL
        '    cmd.ExecuteNonQuery()
        '    strSQL = "insert into " & LclTmpTbl & " select YearBook as BookYear, MonthBook as BookMonth, "
        '    strSQL = strSQL & " booking as NoOfBkg, '" & Me.CmbTargetType.Text.Substring(0, 1) & "_target' as PerfOrTarget "
        '    strSQL = strSQL & " from allstatstarget where Target='" & Me.CmbTargetType.Text & "'"
        '    strSQL = strSQL & " and YearBook in (select BookYear from " & LclTmpTbl & ") "
        '    strSQL = strSQL & " and MonthBook in (select BookMonth from " & LclTmpTbl & ") "
        '    strSQL = strSQL & " and POS ='" & Me.CmbPOS.Text & "'"
        '    cmd.CommandText = strSQL
        '    cmd.ExecuteNonQuery()
        '    cmd.CommandText = "drop table " & tmpTbl
        '    cmd.ExecuteNonQuery()
        '    tmpTbl = LclTmpTbl
        'Else

        If Me.ChkAgent_Grp.Checked Then
            If InStr(StrSelectWhat, "Office") > 0 Then
                cmd.CommandText = "update " & tmpTbl &
                    " set Agency=isnull((select top 1 shortname from DATA1A_OIDs where Status='OK' and DATA1A_OIDs.OffcId =" &
                    tmpTbl & ".office),'') "
                cmd.ExecuteNonQuery()
            End If
        End If
        '    If Me.ChkBooker.Checked Then
        '        strSQL = "update " & tmpTbl & " set Booker=(select top 1 RMK from midt_misc b where b.cat='Booker' and B.VAL=" & tmpTbl
        '        strSQL = strSQL & ".office and b.VAL1=" & tmpTbl & ".sicodeSix)"
        '        strSQL = strSQL & " where office+SIcodeSix in (select VAL+VAL1 from midt_misc where cat='Booker')"
        '        cmd.CommandText = strSQL
        '        cmd.ExecuteNonQuery()
        '    End If
        'End If

        ShowXls(tmpTbl)
        LogReport("AcoSuite", "Allstats", pobjUser.UserName, pobjUser.City)
    End Sub

    Private Sub BarGoATC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarGoATC.Click
        Start(My.Application.Info.DirectoryPath & "\ATC.xlt")
    End Sub

    Private Sub DetectNewSICodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetectNewSICodeToolStripMenuItem.Click
        Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand

        On Error Resume Next
        cmd.CommandText = "Drop table zXXX"
        cmd.ExecuteNonQuery()
        On Error GoTo 0
        cmd.CommandText = "select distinct OFfice,SIcodeSix into zXXX from AllstatsSI where sicode<>''"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from zXXX where office+SiCodeSix in (select val+val1 from midt_misc where cat='Booker') "
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert midt_misc (cat, val, val1) select 'Booker',office, SIcodeSix from zXXX"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Drop table zXXX"
        cmd.ExecuteNonQuery()

    End Sub

    Private Sub mnuUploadMonthly_Click(sender As Object, e As EventArgs) Handles UploadMonthlyToolStripMenuItem.Click
        Dim ofdHotel As New OpenFileDialog
        With ofdHotel
            .InitialDirectory = "W:\1A\DATA\RawData\Hotel"
            .Filter = "Csv files|*.csv"
            .ShowDialog()
        End With
        If ofdHotel.FileName <> "" Then
            Dim flHtl As FileIO.TextFieldParser = New FileIO.TextFieldParser(ofdHotel.FileName)
            Dim CurrentRecord As String() = Nothing
            Dim i As Integer
            Dim arrNameParts() As String = ofdHotel.FileName.Split("\")
            Dim strFileNameOnly As String = Mid(ofdHotel.FileName, InStrRev(ofdHotel.FileName, "\") + 1)
            Dim intMonth As Integer
            Dim intYear As Integer
            Dim blnInsert As Boolean

            flHtl.TextFieldType = FileIO.FieldType.Delimited
            flHtl.Delimiters = New String() {","}
            flHtl.HasFieldsEnclosedInQuotes = True
            Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand

            Dim t As SqlClient.SqlTransaction = pobjSql.Connection.BeginTransaction
            cmd.Transaction = t

            cmd.CommandText = "delete DATA1A_HOTEL where FileName='" & strFileNameOnly & "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert DATA1A_HOTEL (Year, Month, OffcId, IataCode, OfficeName,ChainCode, HOBKHBK, HOBKM, FileName) " & _
                " values (@Year, @Month, @OffcId, @IataCode, @OfficeName,@ChainCode, @HOBKHBK, @HOBKM,'" & strFileNameOnly & "')"
            cmd.Parameters.Add("@Year", SqlDbType.Int)
            cmd.Parameters.Add("@Month", SqlDbType.Int)
            cmd.Parameters.Add("@OffcId", SqlDbType.VarChar)
            cmd.Parameters.Add("@IataCode", SqlDbType.VarChar)
            cmd.Parameters.Add("@OfficeName", SqlDbType.VarChar)
            cmd.Parameters.Add("@ChainCode", SqlDbType.VarChar)
            cmd.Parameters.Add("@HOBKHBK", SqlDbType.Int)
            cmd.Parameters.Add("@HOBKM", SqlDbType.Int)

            Try
                Do While Not flHtl.EndOfData
                    i = i + 1
                    blnInsert = False
                    Try
                        CurrentRecord = flHtl.ReadFields
                        Select Case CurrentRecord.Length
                            Case 1
                                If CurrentRecord(0).StartsWith("Data for") Then
                                    Dim arrDates() As String = CurrentRecord(0).Split(" ")
                                    intMonth = MonthName2Number(arrDates(2))
                                    intYear = arrDates(3)
                                    cmd.Parameters("@Month").Value = intMonth
                                    cmd.Parameters("@Year").Value = intYear
                                Else
                                    Continue Do
                                End If
                            Case 7
                                If CurrentRecord(3) <> "" AndAlso Not IsNumeric(CurrentRecord(3)) Then
                                    Select Case CurrentRecord(0)
                                        Case "Office Id"
                                            Continue Do
                                        Case "Grand Totals :"
                                            Exit Do
                                        Case ""
                                            blnInsert = True
                                        Case Else
                                            blnInsert = True
                                            cmd.Parameters("@OffcId").Value = CurrentRecord(0)
                                            cmd.Parameters("@IataCode").Value = CurrentRecord(1)
                                            cmd.Parameters("@OfficeName").Value = CurrentRecord(2)
                                    End Select
                                End If
                        End Select
                        If blnInsert Then
                            cmd.Parameters("@ChainCode").Value = CurrentRecord(3)
                            cmd.Parameters("@HOBKHBK").Value = String2Int(CurrentRecord(4))
                            cmd.Parameters("@HOBKM").Value = String2Int(CurrentRecord(5))
                            cmd.ExecuteNonQuery()
                        End If
                    Catch ex As FileIO.MalformedLineException
                        Stop
                    End Try
                Loop
                flHtl.Close()
                t.Commit()
                MsgBox("Completed!")
            Catch ex As Exception
                t.Rollback()
                MsgBox("error Uploading " & ofdHotel.FileName & vbNewLine & ex.Message)
            End Try
        End If
    End Sub

    Private Sub mnuReport_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        ShowXlsHotel()
    End Sub
    Private Function MonthName2Number(strMonthName As String) As Integer
        Select Case UCase(strMonthName)
            Case "JANUARY"
                Return 1
            Case "FEBRUARY"
                Return 2
            Case "MARCH"
                Return 3
            Case "APRIL"
                Return 4
            Case "MAY"
                Return 5
            Case "JUNE"
                Return 6
            Case "JULY"
                Return 7
            Case "AUGUST"
                Return 8
            Case "SEPTEMBER"
                Return 9
            Case "OCTOBER"
                Return 10
            Case "NOVEMBER"
                Return 11
            Case "DECEMBER"
                Return 12
            Case Else
                Throw New System.Exception("invalid month name " & strMonthName)

        End Select
    End Function
    Private Function String2Int(strValue As String) As Integer
        Try
            Select Case strValue
                Case ""
                    Return 0
                Case Else
                    Return CInt(strValue)
            End Select
        Catch ex As Exception

        End Try
        Return 0

    End Function

    Private Sub barAllStats_Click(sender As Object, e As EventArgs) Handles barAllStats.Click
        'Dim FName As String = InputBox("Enter FileName You Wanna to Manually Upload", "VietNam ACO :: AllstatsUpload", "f04_" & Format(Now.AddDays(-1), "yyyyMMdd") & ".xls")
        Dim ofdFile As New OpenFileDialog
        With ofdFile
            .InitialDirectory = "W:\1A\DATA\RawData\SI_wz_Provider"
            .Filter = "Xlz files|f04_*" & ".xls"
            .ShowDialog()
            If .FileName = "" Then
                Exit Sub
            End If
            AutoUploadAllstat(.FileName)
            MsgBox("Done")
        End With

    End Sub

    Private Sub barHX_Click(sender As Object, e As EventArgs) Handles barHX.Click
        Dim ofdHx As New OpenFileDialog
        With ofdHx
            .InitialDirectory = "W:\1A\DATA\RawData\SI_wz_Provider"
            .Filter = "Xlz files|U_HX_*.xlsx"
            .ShowDialog()
            If .FileName = "" Then
                Exit Sub
            Else
                Dim objExcel As New Excel.Application
                Dim objWbk As Excel.Workbook
                Dim objWsh As Excel.Worksheet
                Dim i As Integer
                Dim intLastRow As Integer
                Dim strBookDate As String
                Dim intBookMonth As Integer
                Dim intBookYear As Integer
                Dim intBookWeek As Integer
                Dim lstInserts As New List(Of String)

                objWbk = objExcel.Workbooks.Open(.FileName, , True)
                objWsh = objWbk.ActiveSheet
                intLastRow = objWsh.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row - 1

                With objWsh
                    If .Range("B3").Value <> "DTPROCESSDATE" Then
                        MsgBox("Invalid file format")
                        Exit Sub
                    End If
                    strBookDate = Format(.Range("B4").Value, "dd-MMM-yyyy 00:00:00")

                    intBookMonth = Month(strBookDate)
                    intBookYear = Year(strBookDate)
                    intBookWeek = DatePart(DateInterval.WeekOfYear, CDate(strBookDate))
                    lstInserts.Add("Delete HX where BookDate='" & strBookDate & "'")
                    For i = 4 To intLastRow - 1

                        lstInserts.Add("Insert into HX (BookDate, AL, Office, SIcode, PaxName, PrevStatus" _
                                        & ", FltNo, ETD, ETA, Seg, RBD, City, BookMonth, BookYear" _
                                        & ", Agency, Can1) values ('" _
                                        & strBookDate & "','" & .Range("E" & i).Value _
                                        & "','" & .Range("F" & i).Value & "','" & .Range("L" & i).Value _
                                        & "','" & .Range("M" & i).Value.ToString.Trim & "','" & .Range("O" & i).Value _
                                        & "','" & .Range("Q" & i).Value & "','" & .Range("R" & i).Value _
                                        & "','" & .Range("T" & i).Value & "','" & .Range("S" & i).Value & .Range("U" & i).Value _
                                        & "','" & .Range("V" & i).Value & "','" & Mid(.Range("F" & i).Value, 1, 3) _
                                        & "'," & intBookMonth & "," & intBookYear & ",'" & .Range("G" & i).Value _
                                        & "'," & .Range("X" & i).Value & ")")
                    Next
                End With
                objExcel.Quit()
                lstInserts.Add("update HX set Incentified='False' where BookDate='" & strBookDate & "' and Office in " _
                            & " (Select VAL from misc_wzDate where cat='NoIncentiveOID'" _
                            & " and Status='OK' and '" & strBookDate & "' between FromDate and Todate)")
                lstInserts.Add("update HX set Incentified='False' where BookDate='" & strBookDate & "' and AL in ('BA','IB') and Office in " _
                            & " (Select VAL from misc_wzDate where cat='NoIncentiveBAIB'" _
                            & " and Status='OK' and '" & strBookDate & "' between FromDate and Todate)")

                lstInserts.Add("update HX set Incentified='False' where  AL in (Select VAL from data1a_misc where cat='NoIncentiveCar'" _
                                & " And BookDate='" & strBookDate & "')")

                If pobjSql.UpdateListOfQuerries(lstInserts) Then
                    MsgBox("Import completed!")
                Else
                    MsgBox("Unable to imports!")
                End If
            End If

        End With
    End Sub

    Private Sub barDeductBkg_Click(sender As Object, e As EventArgs) Handles barDeductBkg.Click

    End Sub

    Private Sub barBkgByPicReport_Click(sender As Object, e As EventArgs) Handles barBkgByPicReport.Click
        Dim objExcel As New Excel.Application
        Dim objWbk As Excel.Workbook
        Dim objWsh As Excel.Worksheet
        Dim i As Integer

        objWbk = objExcel.Workbooks.Open(Application.StartupPath & "\BkgByPIC.xlt", , , , "aibiet")
        objWsh = objWbk.Sheets("PARA")

        With objWsh
            .Range("B2").Value = Year(Now)
            .Range("B3").Value = Month(Now)
            .Range("B4").Value = pobjUser.Region
            .Range("B5").Value = "Customer"
            .Range("B15").Value = "YES"
        End With
        objExcel.Visible = True

    End Sub

    Private Sub barSumBkgByMonth_Click(sender As Object, e As EventArgs) Handles barSumBkgByMonth.Click
        Dim frmSelect As New frmSelectMonthYear
        Dim tblUnknownAllStatOIDs As DataTable

        If frmSelect.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        tblUnknownAllStatOIDs = GetUnidentifiedOIDsInAllstats(frmSelect.BookYear, frmSelect.BookMonth _
                                                             , pobjUser.Region)
        If tblUnknownAllStatOIDs.Rows.Count > 0 Then
            Dim frmShow As New frmShowTableContent(tblUnknownAllStatOIDs _
                                                   , "Unable to SumBkg due to Unidentified Offc ID")
            frmShow.ShowDialog()
            Exit Sub
        End If
        If Not SumBkgByMonth4Customer(frmSelect.BookYear, frmSelect.BookMonth) Then
            Exit Sub
        End If

    End Sub
End Class
