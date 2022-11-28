Imports Microsoft.Office.Interop
Public Class frmRewardsAdhocPointReport

    Private Sub frmRewardsAdhocPointReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboVND.SelectedIndex = 0
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim i As Integer
        Dim strFromDate As String = CreateFromDate(dtpFrom.Value)
        Dim strToDate As String = CreateToDate(dtpTo.Value)
        Dim strTempTable As String = pobjUser.UserName & Format(Now, "yyMMMddmmss")
        Dim strShortname As String = "(SELECT Shortname from Data1a_OIDS where Status='OK' and OFFCID=" _
                                     & "(select top 1 Office FROM  amadeusvn.dbo.USERMAPPING M " _
                                    & " Where M.STATUS='OK' AND M.USERID=P.USERID)) AS SHORTNAME"
        Dim strQuerry As String = "SELECT ROW_NUMBER() over (order by BookDate) as Seq " _
            & ",CONVERT(VARCHAR,p.LstUpdate,6) as BookDate," & strShortname _
            & ",SIName, P.UserId,rmk" _
            & ",Point,p.FstUser" _
            & " into " & strTempTable _
            & " FROM amadeusvn.dbo.[Point_D] p " _
            & " left join amadeusvn.dbo.tblUser u on p.UserID=u.RecID" _
            & " where Cat='adhoc' and p.Status='ok' and u.status='ok'" _
            & " and p.LstUpdate between '" & strFromDate & "' and '" & strToDate & "'"

        pobjSql.ExecuteNonQuerry(strQuerry)

        If cboRegion.Text <> "" Then
            strQuerry = "delete " & strTempTable & " where ShortName not in (Select ShortName from Data1a_Customers where Status='OK' " _
                & " and Region='" & cboRegion.Text & "')"
            pobjSql.ExecuteNonQuerry(strQuerry)
        End If
        strQuerry = "select * from " & strTempTable & " order by bookdate, ShortName, SIName"
        Dim tblAdhoc As System.Data.DataTable = pobjSql.GetDataTable(strQuerry)

        If tblAdhoc.Rows.Count = 0 Then
            MsgBox("No Records for selected Period")
        Else
            Dim objExcel As New Excel.Application
            Dim objWbk As Excel.Workbook = objExcel.Workbooks.Open(My.Application.Info.DirectoryPath _
                                                                   & "\RewardsAdhocPointReport.xltx")
            Dim objWsh As Excel.Worksheet = objWbk.ActiveSheet
            objExcel.Visible = True

            With objWsh
                .Range("G8", "I8").Merge()
                .Range("G8", "I8").Value = "Từ ngày " & dtpFrom.Value.Date.ToShortDateString _
                    & " đến ngày " & dtpTo.Value.Date.ToShortDateString
                For i = 0 To tblAdhoc.Rows.Count - 1
                    .Range("A" & i + 11, "H" & i + 11).Value = tblAdhoc.Rows(i).ItemArray
                Next

                i = i + 10 + tblAdhoc.Rows.Count
                .Range("B" & i, "D" & i).Merge()
                .Range("B" & i, "D" & i).Value = "TỔNG CỘNG"
                .Range("H" & i).FormulaR1C1 = "=SUM(R[-" & tblAdhoc.Rows.Count + 1 & "]C:R[-1]C)"

                .Range("G" & i + 1, "I" & i + 1).Merge()
                .Range("G" & i + 1, "I" & i + 1).Value = "Ngày " & Now.Day & " tháng " & Now.Month & " năm " & Now.Year

                .Range("G" & i + 2, "I" & i + 2).Merge()
                .Range("G" & i + 2, "I" & i + 2).Value = "Người báo cáo"

                .Range("G" & i + 6, "I" & i + 6).Merge()
                .Range("G" & i + 6, "I" & i + 6).Value = pobjUser.FullName
            End With
        End If
        LogReport("AcoSuite", "AdhocPointReport", pobjUser.UserName, pobjUser.City)
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
End Class