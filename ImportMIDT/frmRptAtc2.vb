Public Class frmRptAtc2
    Private Sub frmRptAtc2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboRegion.SelectedIndex = 0
        dtpFromMonth.Value = New Date(dtpFromMonth.Value.Year, dtpFromMonth.Value.Month, 1)
        dtpToMonth.Value = New Date(dtpToMonth.Value.Year, dtpToMonth.Value.Month, 1)
    End Sub

    Private Sub cboRegion_Validated(sender As Object, e As EventArgs) Handles cboRegion.Validated
        cboValidated(cboRegion)
    End Sub

    Private Sub btnRunRPT_Click(sender As Object, e As EventArgs) Handles btnRunRPT.Click
        Dim mYear, mMonth As Integer
        Dim mToMonth As Date
        Dim mExcel As New Microsoft.Office.Interop.Excel.Application
        Dim mFile As String

        mYear = dtpToMonth.Value.Year
        mMonth = dtpToMonth.Value.Month
        mToMonth = New Date(mYear, mMonth, Date.DaysInMonth(mYear, mMonth))
        If dtpFromMonth.Value > mToMonth Then
            MsgBox("FromMonth cannot later than ToMonth")
            dtpFromMonth.Focus()
            Exit Sub
        End If

        mFile = Application.StartupPath & "\ATCBilling2.xltm"
        If Not IO.File.Exists(mFile) Then
            MsgBox("Template unavailable!")
            Exit Sub
        End If

        pb01.Value = 1
        pb01.Maximum = 5
        pb01.Step = 1
        Try
            pb01.PerformStep()
            mExcel = CreateObject("Excel.Application")
            mExcel.Workbooks.Open(mFile)

            pb01.PerformStep()
            mExcel.ActiveSheet.cells(1, 3).value = dtpFromMonth.Value
            mExcel.ActiveSheet.cells(2, 3).value = mToMonth
            mExcel.ActiveSheet.cells(3, 3).value = cboRegion.Text
            mExcel.ActiveSheet.cells(4, 3).value = "OK"

            pb01.PerformStep()
            mFile = "D:\ATCBilling2_" & Format(Now, "yyyyMMddhhmmss") & ".xlsx"
            mExcel.DisplayAlerts = False
            mExcel.ActiveWorkbook.SaveAs(mFile, 51)
            mExcel.DisplayAlerts = True
        Finally
            pb01.PerformStep()
            mExcel.ActiveWorkbook.Close()
            mExcel.Quit()
        End Try

        pb01.PerformStep()
        If IO.File.Exists(mFile) Then Process.Start(mFile)
    End Sub
End Class