Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Data.SqlClient
Imports System
Imports System.Data.OleDb
Public Class FrmMIDTDaily
    Private Sub FrmMIDTDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFromdate.CustomFormat = "dd-MM-yyyy"
        dtpTodate.CustomFormat = "dd-MM-yyyy"
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim AppXls As Microsoft.Office.Interop.Excel.Application, WkBook As Microsoft.Office.Interop.Excel.Workbook, WkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim DDAN = System.Windows.Forms.Application.StartupPath
        AppXls = CreateObject("Excel.Application")
        AppXls.Visible = True
        WkBook = AppXls.Workbooks.Open(DDAN & "\Daily CBI by Market.xlt", , , , , , , , , True)
        WkSheet = WkBook.Worksheets(1)
        WkSheet.Cells.Range("B1").Value = dtpFromdate.Value.ToString("MM/dd/yyyy")
        WkSheet.Cells.Range("C1").Value = dtpTodate.Value.ToString("MM/dd/yyyy")
        Dim strSavedFile As String = "d:\Daily CBI by Market - VN" & dtpFromdate.Value.ToString("dd") & "-" & dtpTodate.Value.ToString("dd-MM-yyyy") & ".xlt"
        WkBook.SaveAs(strSavedFile, Excel.XlFileFormat.xlWorkbookNormal)
        MsgBox("Exported file " & strSavedFile)
        AppXls.Quit()
        AppXls = Nothing
        On Error GoTo 0
    End Sub
End Class