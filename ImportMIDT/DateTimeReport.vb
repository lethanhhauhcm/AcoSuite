Imports System.Data.SqlClient
Imports System.IO
Imports ExcelDataReader

Public Class DateTimeReport
    Public TenReport As String
    Public Sub TruyenThamSo(s As String)
        TenReport = s
    End Sub
    Private Sub ReportSECOUserList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbbWhere.SelectedIndex = 0
        Show.Checked = True
        FromDate.CustomFormat = "MMM-yyyy"
        ToDate.CustomFormat = "MMM-yyyy"
        If TenReport = "SECO" Or TenReport = "Agency" Then
            GroupOfficeID.Enabled = False
            If TenReport = "Agency" Then
                cbbWhere.Enabled = False
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmdSql As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
        Dim query As String = ""
        Dim ToMonth As Date = Date.Parse(Month(FromDate.Value).ToString() & "/1/" + Year(FromDate.Value).ToString())
        Dim EndMonth As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Date.Parse(Month(ToDate.Value).ToString() & "/1/" + Year(ToDate.Value).ToString())))
        Dim RunMonth = ToMonth
        Dim MangTime As Date() = New Date(40) {}
        Dim status As String = ", '' as Status "
        'Process.Start(Application.StartupPath & "\SecoUserList.xltm")
        Dim AppXls As Microsoft.Office.Interop.Excel.Application, WkBook As Microsoft.Office.Interop.Excel.Workbook, WkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim mFrom, mTo As String  '^_^20230213 add by 7643

        '^_^20230213 add by 7643 -b-
        If TenReport = "ATC" And Format(ToDate.Value, "yyyyMM") >= Format(Now, "yyyyMM") Then
            MsgBox("The ATC Report cannot run until today or in future!")
            Exit Sub
        End If
        '^_^20230213 add by 7643 -e-
        AppXls = CreateObject("Excel.Application")
        AppXls.Visible = True

        Dim k As Integer = 0
        While RunMonth <= EndMonth
            MangTime(k) = RunMonth
            RunMonth = DateAdd(DateInterval.Month, 1, RunMonth)
            k = k + 1
        End While

        If Confirm.Checked = True Then
            status = ",'RR' as Status "
        End If

        If TenReport = "SECO" Then
            query = "delete SECO_Billing where cast(cast(Year as varchar) + '-' + cast(Month as varchar) + '-1' as date)  " &
                "between cast('" & ToMonth & "' as date) and cast('" & EndMonth & "' as date) and isnull(status,'') <> 'RR' "
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()
            For i = 0 To k - 1
                query = "insert into SECO_Billing(CustomerShortName ,NoSeCoUsers, FreeSecoUser, UnitPrice, Month, Year,Status)" &
                        "select * from (select isnull(c.ShortName,'(Blank)') as ShortName, count(UserId) as NoUser , case when pc.Formula = 'First' then pc.NbrOfUnit else 0 end as Free, case when pc.NbrOfUnit <> 0 and pc.Formula = 'First' then pc.AmountForAfter else pc.Amount end as UnitPrice , " &
                        "Month(u.AccessDate) as month, Year(u.AccessDate) as year " & status &
                        "from DATA1A_secouserRaw u left join DATA1A_OIDs c on u.OffcId=c.OffcId and c.Status<>'XX' " &
                        "left join [Data1A_ProductOffer] po on c.ShortName = po.ShortName and po.Status <> 'XX' and po.ProductName = 'SECO' " &
                        "left join DATA1A_MISC m on m.CAT='ProductOfferPrice' and m.Val= po.OfferId " &
                        "left join DATA1A_ProductCosts pc on pc.CostPrice='PRICE' and pc.RecID = m.VAL1 " &
                        "where capturedate = (select MAX (capturedate) from DATA1A_secouserRaw) " &
                        "and u.Status='OK' and cast(u.AccessDate as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date)))" &
                        "group by c.ShortName, pc.Amount, pc.Formula, pc.NbrOfUnit, pc.AmountForAfter, Month(u.AccessDate), Year(u.AccessDate)) b1 " &
                        "where not exists(select * from SECO_billing where CustomerShortName = b1.ShortName and b1.month = month and b1.year = year) "
                cmdSql.CommandText = query
                cmdSql.ExecuteNonQuery()
            Next
            WkBook = AppXls.Workbooks.Open(Application.StartupPath & "\SecoBilledReport.xltm")

        ElseIf TenReport = "MasterPricer" Then
            query = "delete MasterPricer_Billing where cast(cast(Year as varchar) + '-' + cast(Month as varchar) + '-1' as date)  " &
                "between cast('" & ToMonth & "' as date) and cast('" & EndMonth & "' as date) and isnull(status,'') <> 'RR'; " &
                "delete MasterPricer_BillingItem where cast(cast(Year as varchar) + '-' + cast(Month as varchar) + '-1' as date)  " &
                "between cast('" & ToMonth & "' as date) and cast('" & EndMonth & "' as date) and isnull(status,'') <> 'RR'; "
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            For i = 0 To k - 1
                '^_^20230214 mark by 7643 -b-
                'query = "insert into MasterPricer_billingItem(CustomerShortName, OffcID, NetBooking, MPETrx, MPTrx, month, year, DateReport, status) " &
                '        "SELECT isnull(o.ShortName,'(Blank)'), m.OffcId, g.Qty as NetBooking, MPEtrx, MPTrx, m.month, m.year, getdate() " & status &
                '        "from (select OffcId, SUM(m.trxcounter) as MPTrx, month(cast(cast(m.Trxdate as char) as date)) as month, year(cast(cast(m.Trxdate as char) as date)) as year from DATA1A_MasterPricer m where cast(cast(m.Trxdate as char) as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) " &
                '        "and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) and m.ProductCode not in ('FRTMPE','FRTMYS') " &
                '        "group by OffcId, month(cast(cast(m.Trxdate as char) as date)), year(cast(cast(m.Trxdate as char) as date))) m LEFT JOIN DATA1A_OIDs o ON m.OffcId=o.OffcId and o.Status='OK'  " &
                '        "left join (select Agency, Office ,sum(Qty) as Qty from GetNetBooking(" & Month(MangTime(i)) & "," & Year(MangTime(i)) & "," & Month(MangTime(i)) & "," & Year(MangTime(i)) & ") group by Agency, Office) g  on g.Office = o.OffcId " &
                '        "left join (select OffcId, SUM(m.trxcounter) as MPETrx, month(cast(cast(m.Trxdate as char) as date)) as month, year(cast(cast(m.Trxdate as char) as date)) as year from DATA1A_MasterPricer m where cast(cast(m.Trxdate as char) as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) " &
                '        "and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) and m.ProductCode in ('FRTMPE','FRTMYS') " &
                '        "group by OffcId, month(cast(cast(m.Trxdate as char) as date)), year(cast(cast(m.Trxdate as char) as date))) m2 on m2.OffcId = o.OffcId and m.month = m2.month and m.year = m2.year " &
                '        "where not exists (select 1 from MasterPricer_billingItem b where b.OffcID = m.OffcId and b.month = m.month and b.year = m.year) order by o.ShortName " &
                '        "and not exists (select 1 from ExceptForReportNonSECO e where m.OffcId = e.OffcId and o.ShortName = e.ShortName ) "
                '^_^20230214 mark by 7643 -e-
                '^_^20230214 modi by 7643 -b-
                query = "insert into MasterPricer_billingItem(CustomerShortName, OffcID, NetBooking, MPETrx, MPTrx, month, year, DateReport, status) " &
                        "SELECT isnull(o.ShortName,'(Blank)'), m.OffcId, g.Qty as NetBooking, MPEtrx, MPTrx, m.month, m.year, getdate() " & status &
                        "from (select OffcId, SUM(m.trxcounter) as MPTrx, month(cast(cast(m.Trxdate as char) as date)) as month, year(cast(cast(m.Trxdate as char) as date)) as year from DATA1A_MasterPricer m where cast(cast(m.Trxdate as char) as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) " &
                        "and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) and m.ProductCode not in ('FRTMPE','FRTMYS') " &
                        "group by OffcId, month(cast(cast(m.Trxdate as char) as date)), year(cast(cast(m.Trxdate as char) as date))) m LEFT JOIN DATA1A_OIDs o ON m.OffcId=o.OffcId and o.Status='OK'  " &
                        "left join (select Agency, Office ,sum(Qty) as Qty from GetNetBooking(" & Month(MangTime(i)) & "," & Year(MangTime(i)) & "," & Month(MangTime(i)) & "," & Year(MangTime(i)) & ") group by Agency, Office) g  on g.Office = o.OffcId " &
                        "left join (select OffcId, SUM(m.trxcounter) as MPETrx, month(cast(cast(m.Trxdate as char) as date)) as month, year(cast(cast(m.Trxdate as char) as date)) as year from DATA1A_MasterPricer m where cast(cast(m.Trxdate as char) as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) " &
                        "and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) and m.ProductCode in ('FRTMPE','FRTMYS') " &
                        "group by OffcId, month(cast(cast(m.Trxdate as char) as date)), year(cast(cast(m.Trxdate as char) as date))) m2 on m2.OffcId = o.OffcId and m.month = m2.month and m.year = m2.year " &
                        "where not exists (select 1 from MasterPricer_billingItem b where b.OffcID = m.OffcId and b.month = m.month and b.year = m.year) " &
                        "and not exists (select 1 from ExceptForReportNonSECO e where m.OffcId = e.OffcId and o.ShortName = e.ShortName ) order by o.ShortName "
                '^_^20230214 modi by 7643 -e-
                cmdSql.CommandText = query
                cmdSql.ExecuteNonQuery()

                query = "insert into MasterPricer_billing(CustomerShortName, NetBooking, MPETrx, MPTrx, minAmount, UnitPrices, month, year, DateReport, status) " &
                        "select Customershortname, sum(isnull(NetBooking,0)), sum(isnull(MPETrx,0)), sum(isnull(MPTrx,0)), pc.MinAmount, pc.Amount, month, year, getdate() " & status &
                        "from MasterPricer_billingItem o " &
                        "left join [Data1A_ProductOffer] po on o.Customershortname = po.ShortName and po.Status <> 'XX' and po.ProductName = 'MP' " &
                        "left join DATA1A_MISC mi on mi.CAT='ProductOfferPrice' and mi.Val= po.OfferId " &
                        "left join DATA1A_ProductCosts pc on pc.CostPrice='PRICE' and pc.RecID = mi.VAL1 " &
                        "where cast(cast(o.year as char) + '-' + cast(o.month as char) + '-1' as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) " &
                        " and not exists (select 1 from MasterPricer_billing b where b.CustomerShortName = o.Customershortname and b.month = o.month and b.year = o.year) " &
                        "group by Customershortname, month, year, pc.MinAmount, pc.Amount"
                cmdSql.CommandText = query
                cmdSql.ExecuteNonQuery()
            Next
            WkBook = AppXls.Workbooks.Open(Application.StartupPath & "\MasterPricerBuylling.xltm")

        ElseIf TenReport = "ATC" Then
            query = "delete ATC_billingItems where cast(cast(Year as varchar) + '-' + cast(Month as varchar) + '-1' as date)  " &
                "between cast('" & ToMonth & "' as date) and cast('" & EndMonth & "' as date) and isnull(status,'') <> 'RR'; " &
                "delete ATC_billing where cast(cast(Year as varchar) + '-' + cast(Month as varchar) + '-1' as date)  " &
                "between cast('" & ToMonth & "' as date) and cast('" & EndMonth & "' as date) and isnull(status,'') <> 'RR'; "
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            For i = 0 To k - 1
                '^_^20230110 mark by 7643 -b-
                'query = "insert into ATC_billingItems(ShortName, OffcID, Tkno, Trx, month, year, DateImport, Status ) " &
                '        "select c.ShortName,u.OffcId, u.Tkno, u.Trx, u.TrxMonth, u.TrxYear, getdate() " & status &
                '        "from (select a.OffcId,count(distinct Tkno) as Tkno, sum(Trx) as Trx, TrxMonth, TrxYear " &
                '        "from DATA1A_ATC2 a " &
                '        "where cast(cast(TrxDate as varchar) as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) " &
                '        "group by a.OffcId,TrxMonth, TrxYear having sum(Trx) > 0 ) u left join DATA1A_OIDs c on u.OffcId=c.OffcId and c.Status<>'XX' " &
                '        "where not exists (select 1 from ExceptForReportNonSECO e where u.OffcId = e.OffcId and c.ShortName = e.ShortName) " &
                '        "and not exists (select 1 from ATC_billingItems b where b.OffcID = a.OffcId and b.month = a.TrxMonth and b.year = a.TrxYear)"
                'cmdSql.CommandText = query
                'cmdSql.ExecuteNonQuery()
                '^_^20230110 mark by 7643 -e-
                '^_^20230110 modi by 7643 -b-
                '^_^20230213 mark by 7643 -b-
                'query = "insert into ATC_billingItems(ShortName, OffcID, Tkno, Trx, month, year, DateImport, Status ) " &
                '        "select c.ShortName,u.OffcId, u.Tkno, u.Trx, u.TrxMonth, u.TrxYear, getdate() " & status &
                '        "from (select a.OffcId,count(distinct case when a.ProductCode in ('FRTRATM','FRTRATW') then Tkno else null end) as Tkno, sum(Trx) as Trx, TrxMonth, TrxYear " &
                '        "from DATA1A_ATC2 a " &
                '        "where cast(cast(TrxDate as varchar) as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) " &
                '        "group by a.OffcId,TrxMonth, TrxYear having sum(Trx) > 0 ) u left join DATA1A_OIDs c on u.OffcId=c.OffcId and c.Status<>'XX' " &
                '        "where not exists (select 1 from ExceptForReportNonSECO e where u.OffcId = e.OffcId and c.ShortName = e.ShortName) " &
                '        "and not exists (select 1 from ATC_billingItems b where b.OffcID = u.OffcId and b.month = u.TrxMonth and b.year = u.TrxYear)"
                '^_^20230213 mark by 7643 -e-
                '^_^20230213 modi by 7643 -b-
                mFrom = "cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date)"
                mTo = "dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date)))"
                query = "insert into ATC_billingItems(ShortName, OffcID, Tkno, Trx, month, year, DateImport, Status,Booking ) " &
                        "select c.ShortName,u.OffcId, u.Tkno, u.Trx, u.TrxMonth, u.TrxYear, getdate() " & status &
                            ",isnull(ass.Booking,0)+isnull(hx.Booking,0)+isnull(drr.Booking,0) Booking " &
                        "from (select a.OffcId,count(distinct case when a.ProductCode in ('FRTRATM','FRTRATW') then Tkno else null end) as Tkno, sum(Trx) as Trx, " &
                                "TrxMonth, TrxYear " &
                              "from DATA1A_ATC2 a " &
                              "where cast(cast(TrxDate as varchar) as date) between " & mFrom & " and " & mTo & " " &
                              "group by a.OffcId,TrxMonth, TrxYear having sum(Trx) > 0 ) u left join DATA1A_OIDs c on u.OffcId=c.OffcId and c.Status<>'XX' " &
                            "outer apply (select sum(add1-Can1) Booking " &
                                         "from AllstatsSI ass " &
                                         "where u.OffcID=ass.Office And ass.BookDate between " & mFrom & " and " & mTo & " And ass.NoIncentive ='N')ass " &
                            "outer apply (select sum(can1*-1) Booking " &
                                         "from HX " &
                                         "where u.OffcID=hx.Office And hx.BookDate between " & mFrom & " and " & mTo & " And hx.Incentified='true')hx " &
                            "outer apply (select sum(can1*-1) Booking " &
                                         "from Data1a_DeductBkgRuleResult drr " &
                                         "where u.OffcID=drr.Office And drr.BookDate between " & mFrom & " and " & mTo & ")drr " &
                        "where Not exists (select 1 from ExceptForReportNonSECO e where u.OffcId = e.OffcId And c.ShortName = e.ShortName) " &
                            "And Not exists (select 1 from ATC_billingItems b where b.OffcID = u.OffcId And b.month = u.TrxMonth And b.year = u.TrxYear)"
                '^_^20230213 modi by 7643 -e-
                cmdSql.CommandText = query
                cmdSql.ExecuteNonQuery()
                '^_^20230110 modi by 7643 -e-

                '^_^20230213 mark by 7643 -b-
                'query = "insert into ATC_billing(ShortName, TKNo, TktPrice, Trx, TrxPrice, tktFree, tktBlock, TrxFreeOn1tkt, month, year, DateImport, Status) " &
                '        "select c.ShortName, sum(TKno) as TKno, case when b.Formula = 'First' then b.AmountForAfter else b.Amount end as tktPrice, sum(Trx) as Trx, " &
                '        "b1.Amount, case when b.Formula = 'First' then b.NbrOfUnit else 0 end as tktFree, case when b.Formula = 'Block' then b.NbrOfUnit else 0 end as tktBlock,b1.MinAmount, c.month, c.year, getdate() " & status &
                '        "from ATC_billingItems c left join [Data1A_ProductOffer] po on c.ShortName = po.ShortName and po.Status <> 'XX' and po.ProductName = 'ATC' " &
                '        "left join (select m.VAL,pc.Amount, pc.AmountForAfter, pc.Formula, pc.NbrOfUnit " &
                '        "from DATA1A_MISC m left join DATA1A_ProductCosts pc on pc.CostPrice='PRICE' and pc.RecID = m.VAL1 " &
                '        "where m.CAT='ProductOfferPrice' and pc.Unit = 'Ticket') as b on b.Val = po.OfferId " &
                '        "left join (select m.VAL,pc.Amount, pc.MinAmount " &
                '        "from DATA1A_MISC m left join DATA1A_ProductCosts pc on pc.CostPrice='PRICE' and pc.RecID = m.VAL1 " &
                '        "where m.CAT='ProductOfferPrice' and pc.Unit = 'Transaction') as b1 on b1.Val = po.OfferId " &
                '        "where cast(cast(c.year as char) + '-' + cast(c.month as char) + '-1' as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) " &
                '        "and not exists (select 1 from ATC_billing b where b.ShortName = c.ShortName and b.month = c.month and b.year = c.year) " &
                '        "group by c.ShortName, b.Formula, b.AmountForAfter, b.Amount, b1.Amount, b.NbrOfUnit,b1.MinAmount, c.month, c.year "
                '^_^20230213 mark by 7643 -e-
                '^_^20230213 modi by 7643 -b-
                query = "insert into ATC_billing(ShortName, TKNo, TktPrice, Trx, TrxPrice, tktFree, tktBlock, TrxFreeOn1tkt, month, year, DateImport, Status,Booking) " &
                        "select c.ShortName,c.TKno,c.TicketPrice,c.Trx,c.ExcessiveTrxPrice,isnull(aod.FreeTicket,0) FreeTicket,c.tktBlock,c.TrxFreeOn1tkt,c.month," &
                            "c.year,c.DateImport,c.Status,c.Booking " &
                        "from (select c.ShortName,sum(TKno) TKno,ao.TicketPrice,sum(Trx) Trx,ao.ExcessiveTrxPrice,1 tktBlock,10 TrxFreeOn1tkt,c.month," &
                                "c.year,getdate() DateImport,'' Status,sum(c.Booking) Booking,ao.RecID AtcOfferID " &
                              "from ATC_billingItems c " &
                                "left join Data1A_ProductOffer po on c.ShortName=po.ShortName And po.Status<>'XX' and po.ProductName='ATC' " &
                                "left join (select m.VAL " &
                                           "from DATA1A_MISC m left join DATA1A_ProductCosts pc on pc.CostPrice='PRICE' and pc.RecID=m.VAL1 " &
                                           "where m.CAT='ProductOfferPrice' and pc.Unit='Ticket')b on b.Val=po.OfferId " &
                                "outer apply (select top 1 RecID " &
                                             "from DATA1A_Customers cus " &
                                             "where c.ShortName=cus.ShortName And cus.Status='OK' order by RecID desc)cus " &
                                "left join DATA1A_AtcOffer ao on cus.RecID=ao.CustID And ao.ExpDate>=" & mFrom & " and ao.EffDate<=" & mTo & " And ao.Status='OK' " &
                              "where cast(cast(c.year as char)+'-'+cast(c.month as char)+'-1' as date) between " & mFrom & " and " & mTo & " " &
                                "And Not exists (select 1 from ATC_billing b where b.ShortName=c.ShortName And b.month=c.month And b.year=c.year) " &
                              "group by c.ShortName,ao.TicketPrice,ao.ExcessiveTrxPrice,c.month,c.year,ao.RecID)c " &
                        "outer apply(select top 1 FreeTicket " &
                                    "from DATA1A_AtcOfferDetail aod " &
                                    "where c.AtcOfferID=aod.AtcOfferID And aod.BookingRequest<=c.Booking And aod.Status='OK' order by BookingRequest desc)aod"
                '^_^20230213 modi by 7643 -e-
                cmdSql.CommandText = query
                cmdSql.ExecuteNonQuery()
            Next
            WkBook = AppXls.Workbooks.Open(Application.StartupPath & "\ATCBilling.xltm")

        ElseIf TenReport = "WBS" Then
            query = "delete WBS_BillingItems where cast(cast(Year as varchar) + '-' + cast(Month as varchar) + '-1' as date)  " &
                "between cast('" & ToMonth & "' as date) and cast('" & EndMonth & "' as date) and isnull(status,'') <> 'RR'; " &
                "delete WBS_Billing where cast(cast(Year as varchar) + '-' + cast(Month as varchar) + '-1' as date)  " &
                "between cast('" & ToMonth & "' as date) and cast('" & EndMonth & "' as date) and isnull(status,'') <> 'RR'; "
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            For i = 0 To k - 1
                query = "insert into WBS_BillingItems(ShortName, OffcID, NetBooking, Trx, month, year, DateImport, Status ) " &
                        "SELECT isnull(o.ShortName,'(Blank)'), m.OffcId, g.Qty as NetBooking, sum(TrxCounter) as TrxCounter, BookMonth, BookYear, getdate() " & status &
                        "from DATA1A_WBS m LEFT JOIN DATA1A_OIDs o ON m.OffcId=o.OffcId and o.Status = 'OK' " &
                        "left join (select Agency, Office ,sum(Qty) as Qty from GetNetBooking(" & Month(MangTime(i)) & "," & Year(MangTime(i)) & "," & Month(MangTime(i)) & "," & Year(MangTime(i)) & ") group by Agency, Office) g  on g.Office = o.OffcId " &
                        "where cast(cast(m.Trxdate as char) as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) " &
                        "and not exists (select 1 from ExceptForReportNonSECO e where m.OffcId = e.OffcId and o.ShortName = e.ShortName) " &
                        "and not exists (select 1 from WBS_BillingItems b where b.OffcID = m.OffcId and b.month = m.Bookmonth and b.year = m.Bookyear)" &
                        "group by o.ShortName, m.OffcId, g.Qty, BookMonth, BookYear "

                cmdSql.CommandText = query
                cmdSql.ExecuteNonQuery()

                query = "insert into WBS_Billing(ShortName, NetBooking, Trx, FreeTrxOn1Net, UnitPrices, month, year, DateImport, Status) " &
                        "select o.ShortName, sum(NetBooking), sum(Trx), pc.MinAmount, pc.Amount, month ,year, getdate() " & status &
                        "from WBS_BillingItems o left join [Data1A_ProductOffer] po on o.ShortName = po.ShortName and po.Status <> 'XX' and po.ProductName = 'WBS' " &
                        "left join DATA1A_MISC mi on mi.CAT='ProductOfferPrice' and mi.Val= po.OfferId " &
                        "left join DATA1A_ProductCosts pc on pc.CostPrice='PRICE' and pc.RecID = mi.VAL1 " &
                        "where cast(cast(o.year as char) + '-' + cast(o.month as char) + '-1' as date) between cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date) and dateadd(day,-1,dateadd(month,1,cast('" & Year(MangTime(i)) & "' + '-' + '" & Month(MangTime(i)) & "' + '-1' as date))) " &
                        "and not exists (select 1 from WBS_Billing b where b.ShortName = o.ShortName and b.month = o.month and b.year = o.year) " &
                        "group by o.ShortName, year, month, pc.MinAmount, pc.Amount "
                cmdSql.CommandText = query
                cmdSql.ExecuteNonQuery()
            Next
            WkBook = AppXls.Workbooks.Open(Application.StartupPath & "\WBSBilling.xltm")

        ElseIf TenReport = "Agency" Then
            query = "IF OBJECT_ID('ReportAgency') IS NOT NULL begin drop table ReportAgency end"
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            Dim NoOfMonth = DateDiff(DateInterval.Month, ToMonth, EndMonth) + 1
            query = "select b1.*, Seco.NoSeCoUsers as NoOfUsage, Seco.UnitPrice, Seco.Cur, Seco.disCount, Seco.NoOfmonth, total into ReportAgency " &
                    "From (select *from ( select distinct ShortName from DATA1A_OIDs " &
                    "where ShortName in (select CustomerShortName from SECO_billing where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' " &
                    "union Select ShortName from ATC_billing where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' " &
                    "union Select CustomerShortName from MasterPricer_Billing where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' " &
                    "union Select ShortName from WBS_Billing where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' )) b1 " &
                    ",(Select 1 As STT,'' as TH union select 2,'Selling Platform Connect (SECO)' union select 3,'Amadeus Ticket Changer (ATC)' " &
                    "union select 4,'Tickets' union select 5,'Excessive Transaction' union select 6,'Master Pricer  (MP & MPE) - Excessive Transactions' " &
                    "union select 7,'Webservices - Excessive Transactions') b2 ) b1 " &
                    "left join (select CustomershortName, sum(case when NoSeCoUsers > FreeSeCoUser then NoSeCoUsers - FreeSeCoUser else 0 end) as NoSeCoUsers, UnitPrice ,cast(null as varchar(10)) as Cur, '' as disCount, " & NoOfMonth.ToString() & " as NoOfmonth, Sum(total) as total from SECO_billing " &
                    "where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' group by CustomershortName,UnitPrice) Seco " &
                    "on b1.ShortName = seco.CustomerShortName and b1.STT = 2 order by b1.ShortName, b1.STT"
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            query = "update ReportAgency set NoOfUsage = b2.NoOfUsage, UnitPrice = b2.tktPrice, total = b2.tktCharge " &
                    "From ReportAgency b1 left Join " &
                    "(Select ShortName, sum(TKno - tktFree) As NoOfUsage, tktPrice , Sum(tktCharge) As tktCharge from ATC_billing " &
                    "where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' " &
                    "group by ShortName,tktPrice) b2 " &
                    "on b1.ShortName = b2.ShortName where b1.STT = 4"
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            query = "update ReportAgency set NoOfUsage = b2.NoOfUsage, UnitPrice = b2.TrxPrice, total = b2.TrxCharge " &
                    "From ReportAgency b1 left Join " &
                    "(select ShortName, sum(case when TrxFreeOn1tkt * TKno < Trx then Trx - TrxFreeOn1tkt * TKno else 0 end) as NoOfUsage, TrxPrice , Sum(TrxCharge) as TrxCharge from ATC_billing " &
                    "where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' " &
                    "group by ShortName,TrxPrice) b2 " &
                    "on b1.ShortName = b2.ShortName where b1.STT = 5"
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            query = "update ReportAgency set NoOfUsage = b2.NoOfUsage, UnitPrice = b2.UnitPrices, total = b2.Total " &
                    "From ReportAgency b1 left Join " &
                    "(select CustomerShortName, sum(ExcessiveTrx) as NoOfUsage, UnitPrices , Sum(Total) as Total from MasterPricer_Billing " &
                    "where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' " &
                    "group by CustomerShortName,UnitPrices) b2 " &
                    "on b1.ShortName = b2.CustomerShortName where b1.STT = 6"
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            query = "update ReportAgency set NoOfUsage = b2.NoOfUsage, UnitPrice = b2.UnitPrices, total = b2.Total " &
                    "From ReportAgency b1 left Join " &
                    "(select ShortName, sum(ExcessiveTrx) as NoOfUsage, UnitPrices , Sum(Total) as Total from WBS_Billing " &
                    "where cast(cast(year as char) + '-' + cast(month as char) + '-1' as date) between '" & ToMonth & "' and '" & EndMonth & "' " &
                    "group by ShortName,UnitPrices) b2 " &
                    "on b1.ShortName = b2.ShortName where b1.STT = 7"
            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            query = "update ReportAgency set Cur = case when UnitPrice >= 5000 then 'VND' else 'USD' end where UnitPrice is not null ; " &
                    "update ReportAgency set TH = ShortName where STT = 1"

            cmdSql.CommandText = query
            cmdSql.ExecuteNonQuery()

            WkBook = AppXls.Workbooks.Open(Application.StartupPath & "\AgencyBilling.xltm")
        End If
        WkSheet = WkBook.Worksheets("RPT")
        If TenReport <> "Agency" Then
            If Show.Checked = True Then
                WkSheet.Range("C4").Value = "P"
            Else
                WkSheet.Range("C4").Value = "X"
                WkSheet.Range("D4").Value = "X"
                WkSheet.Range("D1").Value = FromDate.Value.ToString("dd-MMM-yyyy")
                WkSheet.Range("D2").Value = ToDate.Value.ToString("dd-MMM-yyyy")
                WkSheet.Range("D3").Value = cbbWhere.Text
            End If
            WkSheet.Range("C3").Value = cbbWhere.Text
            WkSheet.Range("E1").Value = k
            WkSheet.Range("E1").Font.ColorIndex = 2
            WkSheet.Range("C1").Value = FromDate.Value.ToString("dd-MMM-yyyy")
            WkSheet.Range("C2").Value = ToDate.Value.ToString("dd-MMM-yyyy")
        Else
            WkSheet.Range("C3").Value = FromDate.Value.ToString("dd-MMM-yyyy")
            WkSheet.Range("C4").Value = ToDate.Value.ToString("dd-MMM-yyyy")
        End If
    End Sub



    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Dim tb As Data.DataTable = New Data.DataTable()
    '    Dim i As Integer = 3
    '    Dim Stream As FileStream
    '    Dim cmdSql As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
    '    Dim query As String = ""
    '    Dim excelReader As ExcelDataReader.IExcelDataReader
    '    Stream = File.Open("D:\importseco.xlsx", FileMode.Open, FileAccess.Read)
    '    excelReader = ExcelReaderFactory.CreateOpenXmlReader(Stream)
    '    Dim Result As DataSet
    '    Result = excelReader.AsDataSet()
    '    If Result IsNot Nothing And Result.Tables.Count > 0 Then
    '        tb = Result.Tables(0)
    '        Do While tb.Rows(i)(3).ToString <> ""
    '            cmdSql.Parameters.Clear()
    '            query = "insert into ImportSeco values(@Agency, @Free, @Price)"
    '            cmdSql.CommandText = query
    '            cmdSql.Parameters.Add("@Agency", SqlDbType.VarChar).Value = tb.Rows(i)(3).ToString()
    '            cmdSql.Parameters.Add("@Free", SqlDbType.VarChar).Value = tb.Rows(i)(4).ToString()
    '            cmdSql.Parameters.Add("@Price", SqlDbType.Int).Value = Integer.Parse(tb.Rows(i)(5).ToString())
    '            cmdSql.ExecuteNonQuery()
    '            i += 1
    '        Loop
    '    End If
    '    Stream.Close()
    'End Sub
End Class