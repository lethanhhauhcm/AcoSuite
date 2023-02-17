'20220513 modi by 7643
'20220518 modi by 7643
'20220526 modi by 7643
Imports System.IO
Imports Microsoft.Office.Interop

Public Class Management
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#Region "Functions"

#End Region
#Region "Events"
    Private Sub Management_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim arrParameters() As String = Environment.GetCommandLineArgs()
        'If Environment.GetCommandLineArgs.Length > 0 AndAlso UCase(Environment.GetCommandLineArgs(1)) = "R" Then
        '    blnRemoteAccess = True
        'End If

        If Not pobjSql.ConnectMidtDatabaseWeb Then
            MsgBox("Unable to connect Sql")
            GoTo Quit
        End If
        pobjSql1A.ConnectionString = CnStr_TVW
        If Not pobjSql1A.Connect Then
            MsgBox("Unable to connect Sql 1A")
            GoTo Quit
        End If

        '^_^20221007 add by 7643 -b-
        If My.Computer.Name = "7-111" Then
            frmSignIn.txtStaffId.Text = "7643"
            frmSignIn.txtPassword.Text = "kehuydiet"
        End If
        '^_^20221007 add by 7643

        If frmSignIn.ShowDialog <> Windows.Forms.DialogResult.OK Then
            GoTo Quit
        ElseIf pobjUser.Password = Md5Encrypt(pstrDefaultPassword) _
            AndAlso frmChangePassword.ShowDialog <> Windows.Forms.DialogResult.OK Then
            GoTo Quit

        End If

        GenComboValueMain()  '^_^20221109 add by 7643

        SetMenuStatus(MenuStrip1, pobjUser)

        '20220518 add by 7643 -b-
        If pobjUser.Role = "Admin" Then
            pacBO_DC_Cust.Enabled = True
        End If
        '20220518 add by 7643 -e-

        'If pobjUser.Role = "Admin" Then
        '    barUserManager.Enabled = False
        'Else
        '    barUserManager.Enabled = True
        'End If

        'Me.Text = Me.Text & "-" & pobjUser.UserName & "-" & pobjUser.City & "-" & pobjUser.StaffId  '^_^20221207 mark by 7643
        Me.Text = Me.Text & "-" & pobjUser.UserName & "-" & pobjUser.City & "-" & pobjUser.StaffId & "-" & System.Windows.Forms.Application.ProductVersion  '^_^20221207 modi by 7643

        If pobjUser.UserName = "khanhnm" Then
            barDeleteCustomer.Visible = True
            barDeleteCustomer.Enabled = True
            barNMK.Visible = True
        End If
        Exit Sub
Quit:
        Me.Dispose()
    End Sub
    Private Sub Management_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If pobjSql.Connection.State = ConnectionState.Open Then
            pobjSql.Disconnect()
        End If
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles barMIDT.Click

    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'If BarLogIn.Text = "Login" Then
        '    DangNhap.ShowDialog()
        '    BarLogIn.Text = "Log Out"
        'Else
        '    BarLogIn.Text = "Login"
        '    BarChangePassword.Enabled = False
        '    BarCreateUser.Enabled = False
        '    BarSaleLog.Enabled = False
        'End If
    End Sub
    Private Sub mnuAllstats_Click(sender As Object, e As EventArgs) Handles barAllstats.Click
        frmAllStats.ShowDialog()
    End Sub
    Private Sub padRewards_Click(sender As Object, e As EventArgs) Handles padRewards.Click
        frmRewards.ShowDialog()
    End Sub
    Private Sub mnuUserManager_Click(sender As Object, e As EventArgs) Handles barUserManager.Click
        frmUserManagement.ShowDialog()
    End Sub
    Private Sub barPolicy_Click(sender As Object, e As EventArgs) Handles barPolicy.Click
        CSTM1.ShowDialog()
    End Sub

    Private Sub BarUpdateCSTM_Click(sender As Object, e As EventArgs) Handles barOffer.Click
        frmIncentiveOffer.ShowDialog()
        frmIncentiveOffer.Dispose()
    End Sub

    Private Sub BarCalc_Click(sender As Object, e As EventArgs) Handles BarCalculation.Click
        frmIncentiveCalc.ShowDialog()
    End Sub

    Private Sub ProductListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles barProductList.Click
        frmProductList.ShowDialog()
    End Sub

    Private Sub ProductCostsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles barProductCosts.Click
        Dim frmCost As New frmProductCosts("COST")
        frmCost.ShowDialog()
    End Sub

    Private Sub barPackaging_Click(sender As Object, e As EventArgs) Handles barProductPackages.Click
        frmProductPackages.ShowDialog()
    End Sub

    Private Sub barMidtImport_Click(sender As Object, e As EventArgs) Handles barMidtImport.Click
        frmImportMIDT.ShowDialog()
    End Sub

    'Private Sub barChangePSW_Click(sender As Object, e As EventArgs) Handles barChangePSW.Click
    '    Dim frm As New DoiMatKhau
    '    frm.TopLevel = True
    '    frm.ShowDialog()
    'End Sub

#End Region

    Private Sub barMIDTChangeData_Click(sender As Object, e As EventArgs) Handles barMIDTChangeData.Click
        frmChangeData.ShowDialog()
    End Sub

    Private Sub barCustomers_Click(sender As Object, e As EventArgs) Handles barCustomers.Click
        Dim frmCustomers As New frmCustomerList(pobjUser.UserName)
        frmCustomers.ShowDialog()
    End Sub


    Private Sub barSaleLog_Click(sender As Object, e As EventArgs) Handles barSaleLog.Click
        frmSaleLog.ShowDialog()
    End Sub

    Private Sub barMasterPricer_Click(sender As Object, e As EventArgs) Handles barMasterPricer.Click

    End Sub

    Private Sub barLocations_Click(sender As Object, e As EventArgs) Handles barLocations.Click
        Process.Start(Application.StartupPath & "\CustomerLocations.xltm")
    End Sub

    Private Sub barSecoUser_Click(sender As Object, e As EventArgs) Handles barSecoUserImport.Click
        Dim dteStart As Date = Now
        Dim i As Integer = 0
        Dim ofdRawFile As New OpenFileDialog

        With ofdRawFile
            .Filter = "csv Files|*.csv"
            If .ShowDialog <> DialogResult.OK Then
                Exit Sub
            Else
                Dim strCaptureDate As String = Format(File.GetCreationTime(.FileName), "dd-MMM-yyyy hh:mm")
                Dim lstQuerries As New List(Of String)
                Dim objFile As System.IO.StreamReader = Nothing
                Dim intRecordCount As Integer
                Try
                    objFile = New System.IO.StreamReader(.FileName)
                    If Not objFile.ReadLine.Contains("FILTERS: FILTER_ORGANIZATION=ACO-VN") Then
                        MsgBox("Invalid file content")
                        Exit Sub
                    End If
                    objFile.ReadLine()

                    lstQuerries.Add("Update DATA1A_SecoUserRaw Set Status='XX'")

                    Do While Not objFile.EndOfStream
                        Dim arrBreaks As String() = objFile.ReadLine().Split("|")
                        Dim strQuerry As String
                        intRecordCount = intRecordCount + 1
                        If arrBreaks.Length = 11 Then
                            Dim arrOffcSignIn As String() = Split(arrBreaks(10).Replace("(default)", ""), ", ")
                            For i = 0 To arrOffcSignIn.Length - 1
                                strQuerry = "insert into [DATA1A_SecoUserRaw] (Login, UserID, LastName, FirstName, Email, Locked, Activated" _
                                    & ", AccessDate, CreationDate, ActivationDate, OffcId, SignIn, Counter, Status, FstUser, CaptureDate) Values ('" _
                                    & arrBreaks(0) & "','" & arrBreaks(1) & "','" & arrBreaks(2) & "','" & arrBreaks(3) & "','" & arrBreaks(4) _
                                    & "','" & arrBreaks(5) & "','" & arrBreaks(6) & "','" & arrBreaks(7) & "','" & arrBreaks(8) & "','" & arrBreaks(9) _
                                    & "','" & Mid(arrOffcSignIn(i), 1, 9) & "','" & Mid(arrOffcSignIn(i), 11) & "'," & IIf(i = 0, 1, 0) _
                                    & ",'OK','" & pobjUser.UserName & "','" & strCaptureDate & "')"
                                lstQuerries.Add(strQuerry)
                            Next
                        Else
                            MsgBox("Error:" & arrBreaks.Length)
                        End If
                    Loop

                Catch ex As Exception
                    MsgBox(ex.Message)

                Finally
                    objFile.Dispose()
                    objFile.Close()
                End Try



                If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
                    MsgBox("Unable to import " & .FileName)
                    Exit Sub
                End If
                MsgBox(String.Format("Processed {0} records in {1} seconds", intRecordCount - 2, DateDiff(DateInterval.Second, dteStart, Now)))
            End If

        End With

    End Sub

    Private Sub barFinalizeAllstats_Click(sender As Object, e As EventArgs) Handles barFinalizeAllstats.Click
        frmFinalizeAllStats.ShowDialog()
    End Sub

    Private Sub barFormula_Click(sender As Object, e As EventArgs) Handles barFormula.Click
        frmIncentiveFormula.ShowDialog()
    End Sub

    Private Sub barAdhocAdjustment_Click(sender As Object, e As EventArgs) Handles barAdhocAdjustment.Click
        frmIncentiveAdhoc.ShowDialog()
    End Sub

    Private Sub barFromSignInList_Click(sender As Object, e As EventArgs) Handles barFromSignInList.Click
        frmReportContactFromSignIn.ShowDialog()
    End Sub

    Private Sub barRewardAdhocPoint_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub barAllWzSignIn_Click(sender As Object, e As EventArgs) Handles barAllWzSignIn.Click
        Process.Start(Application.StartupPath & "\ContactWzSignIn.xltm")
    End Sub

    Private Sub barATCImport_Click(sender As Object, e As EventArgs) Handles barAtcImport.Click

    End Sub

    Private Sub barBspTicket_Click(sender As Object, e As EventArgs) Handles barBspTicket.Click
        'LogReport("AcoSuite", "BSP Ticket report", pobjUser.UserName, pobjUser.City)
        Process.Start(Application.StartupPath & "\BSP Ticket report.xlt")
    End Sub

    Private Sub BarRewardsAgencyOwner_Click(sender As Object, e As EventArgs) Handles barRewardsAgencyOwner.Click
        LogReport("AcoSuite", "RewardsAgencyOwner", pobjUser.UserName, pobjUser.City)
        Process.Start(Application.StartupPath & "\RewardsAgencyOwner.xltm")
    End Sub

    Private Sub barRewardsAdhocPoint_Click(sender As Object, e As EventArgs) Handles barRewardsAdhocPoint.Click

        frmRewardsAdhocPointReport.ShowDialog()
    End Sub

    Private Sub barRewardsUserList_Click(sender As Object, e As EventArgs) Handles barRewardsUserList.Click
        LogReport("AcoSuite", "RewardsUserList", pobjUser.UserName, pobjUser.City)
        Process.Start(Application.StartupPath & "\RewardsUserList.xltm")
    End Sub

    Private Sub barRewardsGiftAccepted_Click(sender As Object, e As EventArgs) Handles barRewardsGiftAccepted.Click
        Dim i As Integer
        Dim tblGiftAccepted As System.Data.DataTable
        Dim strQuerry As String
        Dim strFromDate As String
        Dim strToDate As String
        Dim frmSelectDate As New frmSelectDateRange
        If frmSelectDate.ShowDialog = Windows.Forms.DialogResult.OK Then
            strFromDate = CreateFromDate(frmSelectDate.dtpFrom.Value)
            strToDate = CreateToDate(frmSelectDate.dtpTo.Value)
        Else
            Exit Sub
        End If
        strQuerry = "Select Row_Number() OVER (ORDER BY g.LstUpdate),d.OrderID, g.LstUpdate as AcceptDate" _
                    & ",d.GiftName,d.Note, u.SIName " _
                    & ",(select shortname from Data1a_OIDs where GDS='1A' and Status='OK' AND OffcId=" _
                    & "(select top 1 Office from amadeusvn.dbo.UserMapping where Status='ok' and UserID=d.UserID)) as Customer" _
                    & ",d.PointRQ,l.Price,d.SL,d.SL*l.Price" _
                    & " from amadeusvn.dbo.OrderGift g " _
                    & " left join amadeusvn.dbo.OrderDetail d on g.RecID=d.OrderID" _
                    & " left join amadeusvn.dbo.tblUser u on d.UserID=u.RecID" _
                    & " left join amadeusvn.dbo.GiftList l on l.RecID=d.GiftID" _
                    & " where g.LstUpdate between '" & strFromDate & "' and '" & strToDate _
                    & "' and g.Status='ok' " _
                    & " and u.Status='OK' and u.City='" & pobjUser.City & "'"

        tblGiftAccepted = pobjSql.GetDataTable(strQuerry)
        If tblGiftAccepted.Rows.Count > 0 Then
            Dim objExcel As New Microsoft.Office.Interop.Excel.Application
            Dim objWsh As Excel.Worksheet
            Dim objWbk As Excel._Workbook
            Dim lstQuerries As New List(Of String)

            objExcel.Visible = True
            objWbk = objExcel.Workbooks.Add
            objWsh = objWbk.ActiveSheet
            With objWsh
                objWsh.Range("A1:k1").Merge()
                objWsh.Range("A1:k1").Value = "GIFTS ACCEPTED FROM " & strFromDate & " TO " & strToDate
                objWsh.Range("A3").Value = "No."
                objWsh.Range("B3").Value = "OrderId"
                objWsh.Range("C3").Value = "AcceptDate"
                objWsh.Range("D3").Value = "GiftName"
                objWsh.Range("E3").Value = "Note"
                objWsh.Range("F3").Value = "Contact"
                objWsh.Range("G3").Value = "Customer"
                objWsh.Range("H3").Value = "Point"
                objWsh.Range("I3").Value = "Price"
                objWsh.Range("J3").Value = "Qty"
                objWsh.Range("k3").Value = "Value"

                For i = 0 To tblGiftAccepted.Rows.Count - 1
                    objWsh.Range("A" & i + 4 & ":K" & i + 4).Value = tblGiftAccepted.Rows(i).ItemArray
                Next

                Dim intTotalLine As Integer = objWsh.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Address.Split("$")(2)
                .Range("I" & intTotalLine + 1).Value = "TOTAL"
                .Range("K" & intTotalLine + 1).FormulaR1C1 = "=SUM(R[-" & (intTotalLine - 3) & "]C:R[-1]C)"
                .Columns("H:K").NumberFormat = "#,##0"
                .Range("A3:" & objWsh.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Address).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                .Columns("A:K").EntireColumn.AutoFit()

                .Range("D" & intTotalLine + 2).Value = "Proposed by"
                .Range("F" & intTotalLine + 2).Value = "Checked by"
                .Range("H" & intTotalLine + 2).Value = "Approved by"

            End With
            LogReport("AcoSuite", "RewardsGiftAccepted", pobjUser.UserName, pobjUser.City)
        End If
    End Sub

    Private Sub barNoContactSignIn_Click(sender As Object, e As EventArgs) Handles barNoContactSignIn.Click
        LogReport("AcoSuite", "NoContactSignIn", pobjUser.UserName, pobjUser.City)
        Process.Start(Application.StartupPath & "\NoContactSignIn.xltm")
    End Sub

    Private Sub barALLContact_Click(sender As Object, e As EventArgs) Handles barALL.Click
        LogReport("AcoSuite", "ContactList", pobjUser.UserName, pobjUser.City)
        Process.Start(Application.StartupPath & "\ContactList.xltm")
    End Sub

    Private Sub barBreakdown_Click(sender As Object, e As EventArgs) Handles barBreakdown.Click
        frmIncentiveReport.ShowDialog()
    End Sub

    Private Sub barSummary_Click(sender As Object, e As EventArgs) Handles barSummary.Click
        frmIncentiveReportSummary.ShowDialog()
    End Sub


    Private Sub barDeleteCustomer_Click(sender As Object, e As EventArgs) Handles barDeleteCustomer.Click
        frmDeleteCustomer.ShowDialog()
    End Sub

    Private Sub barRights_Click(sender As Object, e As EventArgs) Handles barProductRights.Click
        frmProductRights.ShowDialog()
    End Sub

    Private Sub barInsuranceDataImport_Click(sender As Object, e As EventArgs) Handles barInsuranceDataImport.Click
        Dim dteStart As Date = Now
        Dim i As Integer = 0
        Dim j As Integer
        Dim ofdRawFile As New OpenFileDialog

        With ofdRawFile
            .Filter = "XLS Files|20*.xls"
            If .ShowDialog <> DialogResult.OK Then
                Exit Sub
            ElseIf Not IsNumeric(Mid(.SafeFileName, 1, 6)) Then
                MsgBox("Invalid file name!")
                Exit Sub
            Else
                Dim intYear As Integer = Mid(.SafeFileName, 1, 4)
                Dim intMonth As Integer = Mid(.SafeFileName, 5, 2)
                Dim strBookDate As String = CreateFromDate(DateSerial(intYear, intMonth, 1))

                If CInt(pobjSql.GetScalarAsString("Select count (*) from [DATA1A_Insurance] where BookYear=" & intYear _
                                             & " and BookMonth=" & intMonth)) > 0 Then
                    MsgBox("Data had been imported in the past!")
                    Exit Sub
                End If

                Dim objExcel As New Microsoft.Office.Interop.Excel.Application
                Dim objWsh As Excel.Worksheet
                Dim objWbk As Excel._Workbook
                Dim lstQuerries As New List(Of String)
                Dim strQuerry As String

                objWbk = objExcel.Workbooks.Open(.FileName, , True)
                objWsh = objWbk.ActiveSheet
                If objWsh.Range("B3").Value <> "Monthly Amadeus Insurance Bookings Billed per Office and Product for ACOs" Then
                    MsgBox("Incorrect File content format")
                    Exit Sub
                End If
                For i = 10 To objWsh.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                    If objWsh.Range("B" & i).Value = "Grand Totals :" Then
                        Exit For
                    ElseIf objWsh.Range("B" & i).Value Is Nothing Then
                        Continue For
                    ElseIf objWsh.Range("B" & i).Value.ToString.Contains("Totals :") Then
                        Continue For
                    Else
                        With objWsh
                            strQuerry = "insert into [DATA1A_Insurance] (BookDate, BookYear,BookMonth" _
                                & ", OffcId,IataCode,OfficeName,Provider,TABKPBN,Total, FstUser,FileName) values ('" _
                                & strBookDate & "'," & intYear & "," & intMonth _
                                & ",'" & .Range("B" & i).Value & "','" & .Range("D" & i).Value _
                                & "','" & .Range("E" & i).Value & "','" & .Range("G" & i).Value _
                                & "'," & .Range("I" & i).Value & "," & .Range("J" & i).Value _
                                & ",'" & pobjUser.UserName & "','" & ofdRawFile.SafeFileName & "')"
                            lstQuerries.Add(strQuerry)
                        End With

                    End If
                Next
                If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
                    MsgBox("Unable to import " & .FileName)
                    Exit Sub
                End If

                objExcel.Quit()
            End If

        End With

        MsgBox(String.Format("Processed {0} records in {1} seconds", i - 2, DateDiff(DateInterval.Second, dteStart, Now)))
    End Sub

    Private Sub barInsuranceReport_Click(sender As Object, e As EventArgs) Handles barInsuranceReport.Click
        LogReport("AcoSuite", "InsuranceReport", pobjUser.UserName, pobjUser.City)
        Process.Start(Application.StartupPath & "\InsuranceReport.xlsm")
    End Sub

    Private Sub BarProductAccess_Click(sender As Object, e As EventArgs) Handles BarProductAccess.Click
        LogReport("AcoSuite", "ProductAccessReport", pobjUser.UserName, pobjUser.City)
        Process.Start(Application.StartupPath & "\ProductAccessReport.xlsm")
    End Sub

    Private Sub barSeatHunterActivities_Click(sender As Object, e As EventArgs) Handles barSeatHunterActivities.Click
        Process.Start(Application.StartupPath & "\SeatHunterActivitiesReport.xlsm")
    End Sub

    Private Sub barGiftDefinition_Click(sender As Object, e As EventArgs) Handles barGiftDefinition.Click
        frmGiftDefinition.ShowDialog()
    End Sub

    Private Sub barStockUpdate_Click(sender As Object, e As EventArgs) Handles barStockUpdate.Click
        Dim frmGiftInOut As New frmGiftInOutList("IN")
        frmGiftInOut.ShowDialog()
    End Sub

    Private Sub barGiftOrder_Click(sender As Object, e As EventArgs) Handles barGiftOrder.Click
        Dim frmGiftInOut As New frmGiftInOutList("OUT")
        frmGiftInOut.ShowDialog()
    End Sub

    Private Sub barGiftApproval_Click(sender As Object, e As EventArgs) Handles barGiftApproval.Click
        Dim frmGiftInOut As New frmGiftInOutList("APP")
        frmGiftInOut.ShowDialog()
    End Sub

    Private Sub barPrintGiftOrder_Click(sender As Object, e As EventArgs) Handles barPrintGiftOrder.Click
        Dim frmGiftInOut As New frmGiftInOutList("PRT")
        frmGiftInOut.ShowDialog()
    End Sub

    Private Sub barGiftInReport_Click(sender As Object, e As EventArgs) Handles barGiftInReport.Click
        Dim strQuerry As String
        Dim tblGift As DataTable

        strQuerry = "Select g.RecId,m.RecId as GiftId,m.Val as GiftName,Quantity,Reason as PO,LstUpdate" _
            & " from Data1a_GiftInOut g left join Data1a_Misc m  on g.GiftId=m.RecId" _
            & " where Region='" & pobjUser.Region & "' and Status<>'XX' and Inout='In'" _
            & " order by LstUpdate"

        tblGift = pobjSql.GetDataTable(strQuerry)
        If tblGift.Rows.Count > 0 Then
            Table2Excel(tblGift)
        End If
    End Sub

    Private Sub barGiftOutReport_Click(sender As Object, e As EventArgs) Handles barGiftOutReport.Click
        Dim strQuerry As String
        Dim tblGift As DataTable

        strQuerry = "Select g.RecId as OrderId,m.RecId as GiftId,m.Val as GiftName,Quantity,Reason,LstUpdate" _
            & " from Data1a_GiftInOut g left join Data1a_Misc m  on g.GiftId=m.RecId" _
            & " where Region='" & pobjUser.Region & "' and Status='OK' and Inout='OUT'" _
            & " order by LstUpdate"

        tblGift = pobjSql.GetDataTable(strQuerry)
        If tblGift.Rows.Count > 0 Then
            Table2Excel(tblGift)
        End If
    End Sub

    Private Sub barAvailableStock_Click(sender As Object, e As EventArgs) Handles barAvailableStock.Click
        Dim strQuerry As String
        Dim tblGift As DataTable

        strQuerry = "Select Val as GiftName, isnull(Sum (Quantity * (case InOut When 'In' then 1 else -1 end)),0) as Available" _
                    & " from Data1a_GiftInOut g left join data1a_Misc m on g.GiftId=m.RecId" _
                    & " where Region='" & pobjUser.Region & "' and Status='OK'" _
                    & "group by g.giftid, val  order by GiftName "

        tblGift = pobjSql.GetDataTable(strQuerry)
        If tblGift.Rows.Count > 0 Then
            Table2Excel(tblGift)
        End If
    End Sub

    Private Sub barProductPrice_Click(sender As Object, e As EventArgs) Handles barProductPrices.Click
        Dim frmCost As New frmProductCosts("PRICE")
        frmCost.ShowDialog()
    End Sub

    Private Sub barProductOffers_Click(sender As Object, e As EventArgs) Handles barProductOffers.Click
        frmProductOffer.ShowDialog()
    End Sub

    Private Sub barSecoUpdate_Click(sender As Object, e As EventArgs) Handles barSecoUpdate.Click
        Dim frmContact As New frmContacts("", "SECO")
        frmContact.ShowDialog()
    End Sub

    Private Sub barCheckErrors_Click(sender As Object, e As EventArgs)
        Dim strQuerry As String
        Dim tblSECO As DataTable

        strQuerry = "select s.* ,'No matched ContactId' as Error" _
            & " from DATA1A_SecoUserRaw s" _
            & " where s.status='ok'" _
            & " and s.userid not in (select val from data1a_misc where cat='bypasssecocheck')" _
            & " and s.userid not in (select secoid from data1a_contacts where status='ok')" _
            & " order by s.OffcId"

        tblSECO = pobjSql.GetDataTable(strQuerry)
        If tblSECO.Rows.Count > 0 Then
            Table2Excel(tblSECO)
        End If

    End Sub

    Private Sub barListUsers_Click(sender As Object, e As EventArgs)
        Process.Start(Application.StartupPath & "\SecoUserList.xltm")
    End Sub

    Private Sub barBillingCalc_Click(sender As Object, e As EventArgs) Handles barCalcCharges.Click

    End Sub

    Private Sub barMonthlyChargeReport_Click(sender As Object, e As EventArgs)
        Dim frmSelectMonth As New frmSelectMonthYear
        If frmSelectMonth.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strQuerry As String
            Dim tblSECO As DataTable

            strQuerry = "select RecID, Region, ShortName, CalcType, Object, ProductName, Cur, Amount,VAT,Amount+VAT as Total, OfferID, PriceID" _
                & ", BookMonth, BookYear, [Desc] " _
                & " from Data1A_ProductCharges " _
                & " where status='ok' and BookMonth=" & frmSelectMonth.BookMonth _
                & " and BookYear=" & frmSelectMonth.BookYear _
                & " order by ShortName"

            tblSECO = pobjSql.GetDataTable(strQuerry)
            If tblSECO.Rows.Count > 0 Then
                Table2Excel(tblSECO)
            End If

        End If
    End Sub

    Private Sub BarOfferList_Click(sender As Object, e As EventArgs) Handles BarOfferList.Click
        Dim objExcel As New Microsoft.Office.Interop.Excel.Application
        Dim objWsh As Excel.Worksheet
        Dim objWbk As Excel._Workbook
        Dim strQuerry As String = "select OfferId,Shortname, Object, timeframe, Status" _
                                    & ", Validfrom, Validto,unit, Objecttarget, VND" _
                                    & ", customertarget, customertimeframe" _
                                    & " from Data1A_IncentiveOffer o" _
                                    & " left join DATA1A_MISC m on o.OfferId=m.VAL" _
                                    & " left join Data1A_IncentiveFormula f on f.RecID=m.VAL1" _
                                    & " where m.CAT='OfferFormula' and o.status<>'xx'" _
                                    & " and o.ShortName in" _
                                    & " (select ShortName from DATA1A_Customers where Status<>'xx'" _
                                    & " and Region='" & pobjUser.Region _
                                    & "') order by OfferId"
        Dim tblOffers As DataTable
        objExcel.Visible = True
        objWbk = objExcel.Workbooks.Add
        objWsh = objWbk.ActiveSheet
        objWsh.Name = "Offers"

        tblOffers = pobjSql.GetDataTable(strQuerry)
        Table2Excel(tblOffers)
        Me.Dispose()
    End Sub

    Private Sub barFareDownload_Click(sender As Object, e As EventArgs) Handles barFareDownload.Click
        'frmFareDownload.ShowDialog()
    End Sub

    Private Sub barStopInc4OfficeId_Click(sender As Object, e As EventArgs) Handles barStopInc4OfficeId.Click
        Dim frmMisc As New frmMiscDate4OffcId("StopIncentive4OffcId", "NoIncentiveOID")
        frmMisc.ShowDialog()
    End Sub

    Private Sub barNoCost4OffcId_Click(sender As Object, e As EventArgs) Handles barNoCost4OffcId.Click
        Dim frmMisc As New frmMiscDate4OffcId("NoCost4OffcId", "NoCost4OffcId")
        frmMisc.ShowDialog()
    End Sub

    Private Sub barCharges4SECO_Click(sender As Object, e As EventArgs) Handles barCharges4SECO.Click
        frmProductBillingCalc4SECO.ShowDialog()
    End Sub


    Private Sub barProductUsage_Click(sender As Object, e As EventArgs) Handles barProductUsage.Click
        frmProductUsage.ShowDialog()
    End Sub

    Private Sub barSecoCharges_Click(sender As Object, e As EventArgs) Handles barSecoCharges.Click
        Dim objExcel As New Microsoft.Office.Interop.Excel.Application
        Dim objWsh As Excel.Worksheet
        Dim objWbk As Excel._Workbook
        Dim frmSelect As New frmSelectMonthYear
        'frmSelect.ShowDialog()

        If Not frmSelect.ShowDialog = DialogResult.OK Then
            Exit Sub
        End If

        Dim strQuerry As String = "select s.ShortName, ProductName, ProductCount, Cur, Amount, Vat, OfferID" _
                                    & ", PriceID, BookMonth, BookYear,PaidDate" _
                                    & " from Data1A_ProductCharges s" _
                                    & " left join DATA1A_Customers c on s.ShortName=c.ShortName" _
                                    & " where c.status<>'xx' and s.Status<>'XX'" _
                                    & " and BookYear=" & frmSelect.BookYear _
                                    & " and BookMonth=" & frmSelect.BookMonth _
                                    & " and s.Region='" & pobjUser.Region _
                                    & "' order by s.ShortName"
        Dim tblSeco As DataTable
        objExcel.Visible = True
        objWbk = objExcel.Workbooks.Add
        objWsh = objWbk.ActiveSheet
        objWsh.Name = "Seco"

        tblSeco = pobjSql.GetDataTable(strQuerry)
        Table2Excel(tblSeco)
        Me.Dispose()
    End Sub

    Private Sub barProductChargeFollowUp_Click(sender As Object, e As EventArgs) Handles barProductChargeFollowUp.Click
        frmProductChargeFollowUp.ShowDialog()
    End Sub

    Private Sub barMissingProductOffer_Click(sender As Object, e As EventArgs) Handles barMissingProductOffer.Click
        Dim objExcel As New Microsoft.Office.Interop.Excel.Application
        Dim objWsh As Excel.Worksheet
        Dim objWbk As Excel._Workbook
        Dim frmSelect As New frmSelectMonthYear
        Dim frmProduct As New frmSelectProduct
        Dim strQuerry As String

        If Not frmSelect.ShowDialog = DialogResult.OK _
            Or Not frmProduct.ShowDialog = DialogResult.OK Then
            Exit Sub
        End If

        Select Case frmProduct.ProductName
            Case "ATC", "MPE"
                strQuerry = "select u.ProductName, u.ShortName, u.UsageCount-u2.UsageCount as UsageCount" _
                    & ", u.BookYear, u.TimeFrame, u.Period" _
                    & " from Data1A_ProductUsage u" _
                    & " left join Data1A_ProductUsage u2 on u.ProductName=u2.ProductName" _
                    & " And u.ShortName=u2.ShortName" _
                    & " And u.BookYear=u2.BookYear And u.TimeFrame=u2.TimeFrame" _
                    & " And u.Period=u2.Period" _
                    & " where u.Status='OK' and u.Source='AUTO+'" _
                    & " and u.BookYear=" & frmSelect.BookYear _
                    & " and u.Period=" & frmSelect.BookMonth _
                    & " and u.Region='" & pobjUser.Region _
                    & "' and u.ProductName ='" & frmProduct.ProductName _
                    & "' and u.ShortName not in " _
                    & " (select shortname from Data1a_ProductOffer" _
                    & " where ProductName='" & frmProduct.ProductName _
                    & "' and ValidFrom<='" & frmSelect.EndDate _
                    & "' and ValidTo>='" & frmSelect.StartDate & "')" _
                    & " and u2.Status='OK' and u2.Source='MinusBySeco'" _
                    & " and u.UsageCount>u2.UsageCount" _
                    & " order by u.ShortName"
            Case Else
                strQuerry = "select ProductName, ShortName, UsageCount, BookYear" _
                    & ", TimeFrame, Period" _
                    & " from Data1A_ProductUsage " _
                    & " where Status='OK' and Source='AUTO+'" _
                    & " and BookYear=" & frmSelect.BookYear _
                    & " and Period=" & frmSelect.BookMonth _
                    & " and Region='" & pobjUser.Region _
                    & "' and ProductName ='" & frmProduct.ProductName _
                    & "' and ShortName not in " _
                    & " (select shortname from Data1a_ProductOffer" _
                    & " where ProductName='" & frmProduct.ProductName _
                    & "' and ValidFrom<='" & frmSelect.EndDate _
                    & "' and ValidTo>='" & frmSelect.StartDate & "')" _
                    & " order by ShortName"
        End Select

        Dim tblSeco As DataTable
        objExcel.Visible = True
        objWbk = objExcel.Workbooks.Add
        objWsh = objWbk.ActiveSheet
        objWsh.Name = "MissingProductOffer"

        tblSeco = pobjSql.GetDataTable(strQuerry)
        Table2Excel(tblSeco)
        Me.Dispose()
    End Sub

    Private Sub barAtcUsage_Click(sender As Object, e As EventArgs) Handles barAtcBySignIn.Click
        Process.Start(My.Application.Info.DirectoryPath & "\AtcBySignIn.xltm")
    End Sub

    Private Sub barBAIB_Click(sender As Object, e As EventArgs) Handles barBAIB.Click
        Dim frmMisc As New frmMiscDate4OffcId("StopIncentive4BAIB", "NoIncentiveBAIB")
        frmMisc.ShowDialog()
    End Sub

    Private Sub barReceivables_Click(sender As Object, e As EventArgs) Handles barBalance.Click
        frmBalance.ShowDialog()

    End Sub

    Private Sub barDefineGrpTkt_Click(sender As Object, e As EventArgs) Handles barDefineGrpTkt.Click
        frmDefineGrpTkt.ShowDialog()

    End Sub

    Private Sub barManualDeductBkg_Click(sender As Object, e As EventArgs) Handles barManualDeductBkg.Click
        frmDeductBkgRuleList.ShowDialog()
    End Sub

    Private Sub barCustSegmentation_Click(sender As Object, e As EventArgs) Handles barCustSegmentation.Click
        frmCustSegmentation.ShowDialog()
    End Sub

    Private Sub barRewards_Click(sender As Object, e As EventArgs) Handles barRewards.Click

    End Sub

    Private Sub barSecoFOP_Click(sender As Object, e As EventArgs) Handles barSecoFOP.Click
        frmSecoFOP.ShowDialog()

    End Sub

    Private Sub barSumBkg_Click(sender As Object, e As EventArgs) Handles barSumBkg.Click

    End Sub

    Private Sub barCostRelated_Click(sender As Object, e As EventArgs) Handles barCostRelated.Click
        frmCostRelatedReports.ShowDialog()
    End Sub

    Private Sub barBypassSecoCheck_Click(sender As Object, e As EventArgs) Handles barBypassSecoCheck.Click
        frmBypassSecoCheck.ShowDialog()
    End Sub

    Private Sub barOfficeIDs_Click(sender As Object, e As EventArgs) Handles barOfficeIDs.Click
        Process.Start(Application.StartupPath & "\OIDS.xltm")
    End Sub

    Private Sub barBillingInfo_Click(sender As Object, e As EventArgs) Handles barBillingInfo.Click
        Process.Start(Application.StartupPath & "\BillingInfo.xlsm")
    End Sub

    Private Sub barCustomerList_Click(sender As Object, e As EventArgs) Handles barCustomerList.Click
        Process.Start(Application.StartupPath & "\Customers.xlsm")
    End Sub

    Private Sub barIataCode_Click(sender As Object, e As EventArgs) Handles barIataCode.Click
        Process.Start(Application.StartupPath & "\IataCodes.xlsm")
    End Sub

    Private Sub barLocation_Click(sender As Object, e As EventArgs) Handles barLocation.Click
        Process.Start(Application.StartupPath & "\Locations.xlsm")
    End Sub

    Private Sub barPaymentInfo_Click(sender As Object, e As EventArgs) Handles barPaymentInfo.Click
        Process.Start(Application.StartupPath & "\PaymentInfo.xlsm")
    End Sub

    Private Sub barSegmentation_Click(sender As Object, e As EventArgs) Handles barSegmentation.Click
        Process.Start(Application.StartupPath & "\CustomerSegmentation.xlsm")
    End Sub

    Private Sub barPayment2Customers_Click(sender As Object, e As EventArgs) Handles barPayment2Customers.Click
        frmPayment2Customers.ShowDialog()
    End Sub

    Private Sub barIncentiveFOP_Click(sender As Object, e As EventArgs) Handles barIncentiveFOP.Click
        frmIncentiveFOP.ShowDialog()
    End Sub

    Private Sub barAtcMonthly_Click(sender As Object, e As EventArgs) Handles barAtcMonthly.Click
        Dim ofdRawFile As New OpenFileDialog
        Dim intYear As Integer
        Dim dteStart As Date = Now
        Dim i As Integer
        Dim strTrxDate As String

        With ofdRawFile
            .Filter = "XLS Files|*.xls"
            If .ShowDialog <> DialogResult.OK Then
                Exit Sub
            Else
                Dim objExcel As New Microsoft.Office.Interop.Excel.Application
                Dim objWsh As Excel.Worksheet
                Dim objWbk As Excel._Workbook
                Dim lstQuerries As New List(Of String)
                Dim strQuerry As String

                objWbk = objExcel.Workbooks.Open(.FileName, , True)
                objWsh = objWbk.ActiveSheet
                If objWsh.Range("F2").Value IsNot Nothing AndAlso objWsh.Range("F2").Value.ToString.StartsWith("Data for") Then
                    intYear = objWsh.Range("F2").Value.ToString.Split("/")(1)
                    strTrxDate = Format(DateSerial(intYear, objWsh.Range("B6").Value, 1), "dd MMM yy HH:mm")
                Else
                    MsgBox("Incorrect FILE format")
                    Exit Sub
                End If
                If pobjSql.GetScalarAsString("Select TOP 1 RecId from [DATA1A_ATC] where TrxYear=" & intYear _
                                             & " and TrxMonth=" & objWsh.Range("B6").Value) <> "" Then
                    MsgBox("Data was imported in the past!")
                    Exit Sub
                End If
                For i = 6 To objWsh.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                    If objWsh.Range("B" & i).Value = "Total" Then
                        Exit For
                    Else
                        With objWsh
                            strQuerry = "insert into DATA1A_ATC (TrxYear,TrxMonth, OffcId" _
                                & ", ProductCode,Trx, FstUser,TrxDate) values (" & intYear & "," _
                                & .Range("B" & i).Value & ",'" & .Range("E" & i).Value & "','" _
                                & .Range("F" & i).Value & "'," & .Range("G" & i).Value _
                                & ",'" & pobjUser.UserName & "','" & strTrxDate & "')"
                            lstQuerries.Add(strQuerry)
                        End With

                    End If
                Next
                If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
                    MsgBox("Unable to import " & .FileName)
                    Exit Sub
                End If

                objExcel.Quit()
            End If

        End With

        MsgBox(String.Format("Processed {0} records in {1} seconds", i - 2, DateDiff(DateInterval.Second, dteStart, Now)))


    End Sub

    Private Sub barAtcDaily_Click(sender As Object, e As EventArgs) Handles barAtcDaily.Click
        Dim ofdRawFile As New OpenFileDialog
        Dim dteStart As Date = Now
        Dim i As Integer
        Dim strTrxDate As String

        With ofdRawFile
            .Filter = "XLSX Files|*.xlsx"
            If .ShowDialog <> DialogResult.OK Then
                Exit Sub
            Else
                Dim objExcel As New Microsoft.Office.Interop.Excel.Application
                Dim objWsh As Excel.Worksheet
                Dim objWbk As Excel._Workbook
                Dim lstQuerries As New List(Of String)
                Dim strQuerry As String
                Dim intTrxCount As Integer

                objWbk = objExcel.Workbooks.Open(.FileName, , True)
                objWsh = objWbk.ActiveSheet
                If objWsh.Range("b4").Value IsNot Nothing AndAlso objWsh.Range("b4").Value.ToString.StartsWith("Daily ATC") Then
                    strTrxDate = Split(objWsh.Range("H2").Value, ":")(1).Trim
                Else
                    MsgBox("Incorrect FILE format")
                    Exit Sub
                End If
                If pobjSql.GetScalarAsString("Select TOP 1 RecId from [DATA1A_AtcDaily] where TrxDate='" _
                                             & strTrxDate & "'") <> "" Then
                    MsgBox("Data was imported in the past!")
                    Exit Sub
                End If
                For i = 7 To objWsh.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                    If objWsh.Range("B" & i).Value.ToString = "Total" Then
                        Exit For
                    Else
                        With objWsh
                            Select Case .Range("E" & i).Value
                                Case "TTP"
                                    intTrxCount = .Range("G" & i).Value
                                Case Else
                                    intTrxCount = .Range("F" & i).Value
                            End Select

                            strQuerry = "insert into DATA1A_AtcDaily (OffcId" _
                                & ", TrxCode,Trx, FstUser,TrxDate) values ('" _
                                & .Range("C" & i).Value & "','" & .Range("E" & i).Value _
                                & "'," & intTrxCount & ",'" & pobjUser.UserName & "','" & strTrxDate & "')"
                            lstQuerries.Add(strQuerry)
                        End With

                    End If
                Next
                If Not pobjSql.UpdateListOfQuerries(lstQuerries) Then
                    MsgBox("Unable to import " & .FileName)
                    Exit Sub
                End If

                objExcel.Quit()
            End If

        End With

        MsgBox(String.Format("Processed {0} records in {1} seconds", i - 6, DateDiff(DateInterval.Second, dteStart, Now)))


    End Sub

    Private Sub barAtcReissue_Click(sender As Object, e As EventArgs) Handles barAtcReissue.Click
        Process.Start(My.Application.Info.DirectoryPath & "\AtcReissue.xlt")
    End Sub

    Private Sub barMpAll_Click(sender As Object, e As EventArgs) Handles barMP.Click
        Dim frm As New DateTimeReport
        frm.TruyenThamSo("MasterPricer")
        frm.ShowDialog()
    End Sub

    Private Sub barMPE_Click(sender As Object, e As EventArgs) Handles barSeco.Click
        Dim frm As New DateTimeReport
        frm.TruyenThamSo("SECO")
        frm.ShowDialog()
    End Sub

    Private Sub barWebServices_Click(sender As Object, e As EventArgs)
        Process.Start(Application.StartupPath & "\WBS.xlsm")
    End Sub

    Private Sub barNMK_Click(sender As Object, e As EventArgs) Handles barNMK.Click
        'Dim tblUser As DataTable = pobjSql.GetDataTable("select * from Data1a_User where Status<>'xx' and StaffId=0")
        'Dim tblStaff As DataTable
        'pobjSqlWeb.ConnectionString = CnStr_AOP
        'pobjSqlWeb.Connect()

        'For Each objRow As DataRow In tblUser.Rows
        '    tblStaff = pobjSqlWeb.GetDataTable("select * from tblHR_NhanVien where Status='OK' and HR_City='" _
        '                & objRow("City") & "' and TenVietTat='" & objRow("FullName") & "'")
        '    If tblStaff.Rows.Count = 0 Then
        '        MsgBox("Staff ID not found for " & objRow("City") & " " & objRow("FullName"))
        '    Else

        '        pobjSql.ExecuteNonQuerry("Update Data1a_User set StaffId=" & tblStaff.Rows(0)("RecId") & " where RecId=" & objRow("RecId"))
        '    End If
        'Next
    End Sub

    Private Sub barMIDTMonthly_Click(sender As Object, e As EventArgs) Handles barMIDTMonthly.Click
        Dim frm As New MIDTData
        frm.TopLevel = True
        frm.ShowDialog()
    End Sub

    Private Sub barMIDTDaily_Click(sender As Object, e As EventArgs) Handles barMIDTDaily.Click
        '20220513 mark by 7643 -b-
        'Dim frm As New FrmMIDTDaily
        'frm.TopLevel = True
        'frm.ShowDialog()
        '20220513 mark by 7643 -e-
        Process.Start(Application.StartupPath & "\Daily CBI by Market.xltm")  '20220513 modi by 7643
    End Sub

    Private Sub SecoBilledReportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frm As New DateTimeReport
        frm.TruyenThamSo("SECO")
        frm.ShowDialog()
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        Process.Start(Application.StartupPath & "\MasterPricer.xlsm")
    End Sub

    Private Sub MPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MPEToolStripMenuItem.Click
        Process.Start(Application.StartupPath & "\MPE.xlsm")
    End Sub

    Private Sub CheckErrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckErrorToolStripMenuItem.Click
        Dim strQuerry As String
        Dim tblSECO As DataTable

        strQuerry = "select s.* ,'No matched ContactId' as Error" _
            & " from DATA1A_SecoUserRaw s" _
            & " where s.status='ok'" _
            & " and s.userid not in (select val from data1a_misc where cat='bypasssecocheck')" _
            & " and s.userid not in (select secoid from data1a_contacts where status='ok')" _
            & " order by s.OffcId"

        tblSECO = pobjSql.GetDataTable(strQuerry)
        If tblSECO.Rows.Count > 0 Then
            Table2Excel(tblSECO)
        End If
    End Sub

    Private Sub UserListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserListToolStripMenuItem.Click
        Process.Start(Application.StartupPath & "\SecoUserList.xltm")
    End Sub

    Private Sub MonthlyChargeReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyChargeReportToolStripMenuItem.Click
        Dim frmSelectMonth As New frmSelectMonthYear
        If frmSelectMonth.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strQuerry As String
            Dim tblSECO As DataTable

            strQuerry = "select RecID, Region, ShortName, CalcType, Object, ProductName, Cur, Amount,VAT,Amount+VAT as Total, OfferID, PriceID" _
                & ", BookMonth, BookYear, [Desc] " _
                & " from Data1A_ProductCharges " _
                & " where status='ok' and BookMonth=" & frmSelectMonth.BookMonth _
                & " and BookYear=" & frmSelectMonth.BookYear _
                & " order by ShortName"

            tblSECO = pobjSql.GetDataTable(strQuerry)
            If tblSECO.Rows.Count > 0 Then
                Table2Excel(tblSECO)
            End If

        End If
    End Sub

    Private Sub WebServicesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebServicesToolStripMenuItem.Click
        Process.Start(Application.StartupPath & "\WBS.xlsm")
    End Sub

    Private Sub MasterPricerToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim frm As New DateTimeReport
        frm.TruyenThamSo("MasterPricer")
        frm.ShowDialog()
    End Sub

    Private Sub SecoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frm As New DateTimeReport
        frm.TruyenThamSo("SECO")
        frm.ShowDialog()
    End Sub

    Private Sub ATCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles barATC.Click
        Dim frm As New DateTimeReport
        frm.TruyenThamSo("ATC")
        frm.ShowDialog()
    End Sub

    Private Sub barWBS_Click(sender As Object, e As EventArgs) Handles barWBS.Click
        Dim frm As New DateTimeReport
        frm.TruyenThamSo("WBS")
        frm.ShowDialog()
    End Sub

    Private Sub barAgency_Click(sender As Object, e As EventArgs) Handles barAgency.Click
        Dim frm As New DateTimeReport
        frm.TruyenThamSo("Agency")
        frm.ShowDialog()
    End Sub

    Private Sub barStopIncentive4Carrier_Click(sender As Object, e As EventArgs) Handles barStopIncentive4Carrier.Click
        Dim objCarField As New clsMiscField("VAL", "Car",, 2, 2)

        Dim frmCar As New frmMiscList("NoIncentiveCar", objCarField)
        frmCar.ShowDialog()
    End Sub

    '20220526 modi by 7643 -b-
    Private Sub barSecoOffer_Click(sender As Object, e As EventArgs) Handles barSecoOffer.Click
        Dim mSecoOffer As New frmSecoOffer
        mSecoOffer.Show()
    End Sub

    Private Sub barPricePerUser_Click(sender As Object, e As EventArgs) Handles barUnitPrice.Click
        Dim mUnitPrice As New frmUnitPrice
        mUnitPrice.Show()
    End Sub

    Private Sub CalcPriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles barCalcPrice.Click
        Dim mCalcPrice As New frmCalcPrice
        mCalcPrice.Show()
    End Sub

    Private Sub barImportPriceList_Click(sender As Object, e As EventArgs)
        Dim mOfd As New OpenFileDialog,
            mExcel As New Microsoft.Office.Interop.Excel.Application,
            i, mPriceID As Integer,
            mSQL, mTable, mValue, mDate, mCustomer As String,
            mReturn As DataTable,
            mST As SqlClient.SqlTransaction

        If mOfd.ShowDialog() <> DialogResult.OK Then Exit Sub
        Try
            mExcel.Workbooks.Open(mOfd.FileName)

            mTable = "##Tmp" & Format(Now, "yyyyMMddhhmmss")
            mSQL = "create table " & mTable & "(Tmp01 varchar(max))"
            pobjSql.ExecuteNonQuerry(mSQL)

            mValue = ""
            For i = 4 To mExcel.ActiveSheet.usedrange.rows.count - 1
                mSQL = "select RecID " & vbLf &
                        "from DATA1A_PriceList " & vbLf &
                        "where Customer='" & mExcel.ActiveSheet.cells(i, 1).value & "' and Status='OK' " &
                          "and Format(EffDate,'yyyyMM')<='20301230' and format(ExpDate,'yyyyMM')>='20220101'"
                If pobjSql.GetScalarAsString(mSQL) = "" Then
                    mValue &= IIf(mValue <> "", ",", "") & "('" & mExcel.ActiveSheet.cells(i, 1).value.trim & "')"
                End If
            Next

            If mValue <> "" Then
                mSQL = "insert into " & mTable & " values " & mValue
                pobjSql.ExecuteNonQuerry(mSQL)
            End If

            mValue = ""
            mDate = Format(Now, "yyyyMMdd hh:mm:ss")
            mSQL = "select isnull(max(PriceID),0) MPriceID from DATA1A_PriceList"
            mPriceID = Integer.Parse(pobjSql.GetScalarAsString(mSQL))
            mSQL = "select * from " & mTable & " order by Tmp01"
            mReturn = pobjSql.GetDataTable(mSQL)

            cmd.Connection = pobjSql.Connection
            mST = pobjSql.Connection.BeginTransaction
            cmd.Transaction = mST
            Try
                For i = 0 To mReturn.Rows.Count - 1
                    mCustomer = mReturn.Rows(i)("Tmp01")
                    mPriceID += 1
                    cmd.CommandText = "insert into DATA1A_PriceList(FstDate,FstUser,Status,Customer,City," &
                                                            "EffDate,ExpDate,ChangeNum,PriceID,Note) " &
                           "values('" & mDate & "','" & pobjUser.UserName & "','OK','" & mCustomer & "','" & pobjUser.City & "'," &
                                  "'20220101','20301230',0," & mPriceID & ",'')"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "insert into DATA1A_PriceListDetail(FstDate,FstUser,Status,PriceID,FromTheUser," &
                                                                             "ToTheUser,PricePerUser,PriceCombo,City,ChangeNum) " &
                           "values('" & mDate & "','" & pobjUser.UserName & "','OK'," & mPriceID & ",1," &
                                  "9999,115000,0,'" & pobjUser.City & "',0)"
                    cmd.ExecuteNonQuery()
                Next

                MsgBox("Import complete!")
                mST.Commit()
            Catch ex As Exception
                MsgBox(ex.Message)
                mST.Rollback()
            End Try
        Finally
            mExcel.Quit()
        End Try
    End Sub

    Private Sub BarQuickInvoicing_Click(sender As Object, e As EventArgs) Handles BarQuickInvoicing.Click, BarPaymentFollowUp.Click, BarApplyPayments.Click
        Dim b As ToolStripItem = CType(sender, ToolStripItem)
        Dim f As New frmDC_Pax(b.Tag)
        f.ShowDialog()
    End Sub
    '20220526 modi by 7643 -e-

    Private Sub barSecoBillingReport_Click(sender As Object, e As EventArgs) Handles barSecoBillingReport.Click
        Process.Start(Application.StartupPath & "\SecoBillingReport.xltm")  '^_^20221125 add by 7643
    End Sub

    Private Sub barSecoPerCust_Click(sender As Object, e As EventArgs) Handles barSecoPerCust.Click
        Process.Start(Application.StartupPath & "\SecoPerCus.xltm")  '^_^20221125 add by 7643
    End Sub

    Private Sub barAtcOffer_Click(sender As Object, e As EventArgs) Handles barAtcOffer.Click
        '^_^20221219 add by 7643 -b-
        Dim mForm As New frmAtcOffer
        mForm.Show()
        '^_^20221219 add by 7643 -e-
    End Sub

    Private Sub BarAtcCalcPrice_Click(sender As Object, e As EventArgs) Handles BarAtcCalcPrice.Click
        '^_^20221219 add by 7643 -b-
        Dim mForm As New frmAtcCalcPrice
        mForm.Show()
        '^_^20221219 add by 7643 -e-
    End Sub

    Private Sub barATC2_Click(sender As Object, e As EventArgs) Handles barATC2.Click
        Process.Start(Application.StartupPath & "\ATCBilling2.xltm")  '^_^20230110 add by 7643
    End Sub

    Private Sub barSecoPpd_Click(sender As Object, e As EventArgs) Handles barSecoPpd.Click
        '^_^20230112 add by 7643 -b-
        Dim mSecoPpd As New frmSecoPpd
        mSecoPpd.Show()
        '^_^20230112 add by 7643 -e-
    End Sub
End Class