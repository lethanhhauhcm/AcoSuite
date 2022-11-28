Imports Microsoft.Office.Interop
Public Class frmReportContactFromSignIn

    Private Sub btnGetFile_Click(sender As Object, e As EventArgs) Handles btnGetFile.Click
        Dim ofdSignIns As New OpenFileDialog
        With ofdSignIns
            .InitialDirectory = "W:\1A\DATA\"
            .Filter = "xls files|*.xlsx"
            .ShowDialog()
        End With

        If ofdSignIns.FileName <> "" Then
            txtPath.Text = ofdSignIns.FileName
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim objExcel As New Excel.Application
        Dim objWbk As Excel.Workbook
        Dim objWsh As Excel.Worksheet
        Dim i As Integer
        Dim intLastRow As Integer
        Dim strSelectedFields As String = ""
        Dim strQuerry As String
        Dim strLastColumn As String

        If txtPath.Text = "" Then
            MsgBox("No input file selected!")
            Exit Sub
        End If
        For Each objCheckedItem In clbFields.CheckedItems
            strSelectedFields = strSelectedFields & "c." & objCheckedItem.ToString & ","
        Next
        strSelectedFields = Replace(strSelectedFields, "c.AccountNameGB", "d.AccountNameGB")
        If strSelectedFields = "" Then
            Exit Sub
        Else
            strSelectedFields = Mid(strSelectedFields, 1, strSelectedFields.Length - 1)
        End If

        objWbk = objExcel.Workbooks.Open(txtPath.Text, , True)
        objWsh = objWbk.ActiveSheet
        strLastColumn = Chr(Asc("B") + strSelectedFields.Split(",").Length)

        objWsh.Range("C1", strLastColumn & "1").Value = strSelectedFields.Split(",")

        objExcel.Visible = True

        strQuerry = "Select " & strSelectedFields & " from DATA1A_Contacts c" _
            & " left join DATA1A_Customers d on c.CustShortName=d.shortname  " _
            & " where c.Status='OK' and d.Status='OK'" _
            & " and ContactId=(Select top 1 ContactId from DATA1A_SignIn1As where Status='OK'"
        
        intLastRow = objWsh.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row

        With objWsh
            If .Range("A1").Value <> "OfficeID" Or .Range("B1").Value <> "SignInCode" Then
                MsgBox("Invalid file format")
                Exit Sub
            End If
            For i = 2 To intLastRow

                If .Range("A" & i).Value Is Nothing Then
                    Exit Sub
                Else
                    Dim tblContactInfo As DataTable = pobjSql.GetDataTable(strQuerry _
                                                            & "and OffcId='" & .Range("A" & i).Value _
                                                            & "' and SignIn='" & .Range("B" & i).Value & "')")
                    If tblContactInfo.Rows.Count > 0 Then
                        .Range("C" & i, strLastColumn & i).Value = tblContactInfo.Rows(0).ItemArray
                    End If

                End If
            Next
        End With
        MsgBox("Completed")
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmReportContactFromSignIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tblFieldNames As New System.Data.DataTable
        Dim i As Integer
        tblFieldNames = pobjSql.GetDataTable("select Column_name from Information_schema.columns where Table_name ='DATA1A_Contacts'")

        clbFields.Items.Add("AccountNameGB")

        For i = 0 To tblFieldNames.Rows.Count - 1
            clbFields.Items.Add(tblFieldNames.Rows(i)(0))
        Next
        clbFields.SetItemChecked(0, True)
        clbFields.SetItemChecked(3, True)
        clbFields.SetItemChecked(6, True)


        btnGetFile.PerformClick()
    End Sub
End Class