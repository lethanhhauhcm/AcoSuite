Public Class frmCostRelatedReports
    Private Sub lbkRun_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkRun.LinkClicked
        Dim strQuerry As String
        Dim intFromDate As Integer = Format(dtpFromDate.Value, "yyyyMMdd")
        Dim intToDate As Integer = Format(dtpToDate.Value, "yyyyMMdd")
        Dim tblResult As DataTable

        If dtpFromDate.Value.Date > dtpToDate.Value Then
            MsgBox("Invalid FromDate/ToDate")
            Exit Sub
        End If

        Select Case cboReportType.Text
            Case ""
                MsgBox("Need to select Report Type")
                Exit Sub
            Case "ATC"
                strQuerry = "SELECT [TrxYear],[TrxMonth], ShortName, m.OffcId,sum(m.Trx) as Trx" _
                        & ", Product" _
                        & " FROM [DATA1A_ATC2] m" _
                        & " left join DATA1A_OIDs o on m.OffcId=o.OffcId and o.Status='OK'" _
                        & " WHERE  [Trxdate] between " & intFromDate & " and " & intToDate _
                        & " group by ShortName, m.OffcId,TrxYear,TrxMonth,Product" _
                        & " order by ShortName, m.OffcId,TrxYear,TrxMonth,Product"

            Case "IMR"
                strQuerry = "SELECT BookYear,BookMonth, ShortName, m.OffcId,count(m.RecID) as Trx" _
                        & " FROM DATA1A_AIR m" _
                        & " left join DATA1A_OIDs o on m.OffcId=o.OffcId and o.Status='OK'" _
                        & " WHERE AirType='im'" _
                        & " and [Trxdate] between " & intFromDate & " and " & intToDate _
                        & " group by ShortName, m.OffcId,BookYear,BookMonth"
            Case "MasterPricer"

            Case "MasterPricerExpert"
                strQuerry = "SELECT BookYear,BookMonth, ShortName, m.OffcId,sum(TrxCounter) as Trx" _
                        & " FROM DATA1A_MasterPricer m" _
                        & " left join DATA1A_OIDs o on m.OffcId=o.OffcId and o.Status='OK'" _
                        & " WHERE ProductCode='FRTMPE'" _
                        & " and [Trxdate] between " & intFromDate & " and " & intToDate _
                        & " group by ShortName, m.OffcId,BookYear,BookMonth"

            Case "MasterPricerFareFamily"
                strQuerry = "SELECT BookYear,BookMonth, ShortName, m.OffcId,sum(TrxCounter) as Trx" _
                        & " FROM DATA1A_MasterPricer m" _
                        & " left join DATA1A_OIDs o on m.OffcId=o.OffcId and o.Status='OK'" _
                        & " WHERE ProductCode='FRTMYS'" _
                        & " and [Trxdate] between " & intFromDate & " and " & intToDate _
                        & " group by ShortName, m.OffcId,BookYear,BookMonth"

            Case "WebServicesTransaction"
                strQuerry = "SELECT BookYear,BookMonth, ShortName, m.OffcId,TrxFamily,sum(TrxCounter) as Trx" _
                        & " FROM DATA1A_WBS m" _
                        & " left join DATA1A_OIDs o on m.OffcId=o.OffcId and o.Status='OK'" _
                        & " WHERE [Trxdate] between " & intFromDate & " and " & intToDate _
                        & " group by ShortName, m.OffcId,BookYear,BookMonth,TrxFamily"
        End Select

        tblResult = pobjSql.GetDataTable(strQuerry)
        If Table2Excel(tblResult, cboReportType.Text) Then
            MsgBox("Report Completed")
            Me.Dispose()
        End If

    End Sub
End Class