Public Class frmGiftInOutList

    Private mstrInOut As String

    Public Sub New(strInOut As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrInOut = strInOut
    End Sub
    Private Sub frmGiftInOutList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pobjSql.LoadComboVal(cboGiftName, "Select RecId as Value, Val as Display from Data1a_Misc where Cat='GiftDefinition" _
                             & pobjUser.City & "' order by Display")
        pobjSql.LoadCombo(cboRequester, "Select distinct FstUser Value from Data1a_GiftInOut where Status<>'XX'" _
                             & " order by Value")
        btnClear.PerformClick()
        Search()
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String

        strQuerry = "Select g.RecId,InOut, Val as GiftName,m.RecId as GiftId,Quantity,Reason " _
            & ",Status,FstUser as Requester,g.FstUpdate,LstUpdate,ApprovedBy,ApprovedDate,NbrOfPrintOut" _
            & " from Data1a_GiftInOut g left join Data1a_Misc m on g.GiftId=m.RecId" _
            & " where Status<>'XX' and m.Cat='GiftDefinition" & pobjUser.City & "'"

        Select Case mstrInOut
            Case "IN", "OUT"
                strQuerry = strQuerry & " and Inout='" & mstrInOut & "'"
            Case "PRT", "APP"
                strQuerry = strQuerry & " and Inout='OUT'"
        End Select

        If cboGiftName.SelectedIndex > -1 Then
            strQuerry = strQuerry & " and GiftId=" & cboGiftName.SelectedValue
        End If

        AddEqualConditionCombo(strQuerry, cboStatus)
        AddEqualConditionCombo(strQuerry, cboRequester, "FstUser")

        Select Case chkPrinted.CheckState
            Case CheckState.Checked
                strQuerry = strQuerry & " and NbrOfPrintOut > 0"
            Case CheckState.Unchecked
                strQuerry = strQuerry & " and NbrOfPrintOut = 0"
        End Select
        strQuerry = strQuerry & " and LstUpdate between '" & CreateFromDate(dtpFromDate.Value) _
            & "' and '" & CreateToDate(dtpToDate.Value) & "'"

        strQuerry = strQuerry & " order by LstUpdate"
        pobjSql.LoadDataGridView(dgGift, strQuerry)
        HideGridColumns(dgGift, "RecId|InOut|ApprovedDate|ApprovedBy|GiftId")
        If mstrInOut = "IN" Then
            dgGift.Columns("Reason").HeaderText = "PO"

        End If
        Return True
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        dtpFromDate.Value = Now.AddDays(-30)
        cboGiftName.SelectedIndex = -1
        Select Case mstrInOut
            Case "IN"
                cboStatus.SelectedIndex = cboStatus.FindStringExact("OK")
                cboRequester.SelectedIndex = -1
                cboRequester.Enabled = False
            Case "PRT"
                cboStatus.SelectedIndex = cboStatus.FindStringExact("OK")
                cboRequester.SelectedIndex = -1
                cboRequester.Enabled = False
                btnNew.Enabled = False
            Case "OUT"
                cboStatus.SelectedIndex = -1
                cboRequester.SelectedIndex = cboStatus.FindStringExact(pobjUser.UserName)

            Case "APP"
                cboStatus.SelectedIndex = cboStatus.FindStringExact("QQ")
                cboRequester.SelectedIndex = -1
                btnNew.Enabled = False
        End Select
        chkPrinted.CheckState = CheckState.Indeterminate
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub dgGift_SelectionChanged(sender As Object, e As EventArgs) Handles dgGift.SelectionChanged
        If dgGift.RowCount > 0 Then
            If dgGift.CurrentRow.Cells("Status").Value = "QQ" Then
                btnDelete.Enabled = True
                btnEdit.Enabled = True
                btnApprove.Enabled = (mstrInOut = "APP")
                btnPrint.Enabled = False
            Else
                btnDelete.Enabled = False
                btnEdit.Enabled = False
                btnApprove.Enabled = False
                btnPrint.Enabled=(dgGift.CurrentRow.Cells("Status").Value = "OK")
            End If

            lblAvailable.Text = "Available:" _
                & pobjSql.GetScalarAsString("Select Sum (Quantity * (case InOut When 'In' then 1 else -1 end))" _
                                            & " from Data1a_GiftInOut" _
                                            & " where Status<>'XX' and GiftId=" _
                                            & dgGift.CurrentRow.Cells("GiftId").Value)
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmEdit As New frmGiftInOutItemEdit(mstrInOut)
        If frmEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim frmEdit As New frmGiftInOutItemEdit(mstrInOut, dgGift.CurrentRow)
        If frmEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If pobjSql.DeleteGridViewRow(dgGift, "Update Data1a_GiftInOut Set Status='XX', LstUpdate=GetDate()" _
                                     & ",LstUser='" & pobjUser.UserName & "' where RecId=" _
                                     & dgGift.CurrentRow.Cells("RecId").Value) Then
            Search()
        End If
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If pobjSql.ExecuteNonQuerry("Update Data1a_GiftInOut Set Status='OK', ApprovedDate=GetDate()" _
                                     & ",ApprovedBy='" & pobjUser.UserName & "' where RecId=" _
                                     & dgGift.CurrentRow.Cells("RecId").Value) Then
            Search()
        Else
            MsgBox("Unable to Approve!")
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim objExcel As Microsoft.Office.Interop.Excel.Application
        Dim objWbk As Microsoft.Office.Interop.Excel.Workbook
        Dim objWsh As Microsoft.Office.Interop.Excel.Worksheet

        objExcel = CreateObject("Excel.Application")
        objWbk = objExcel.Workbooks.Open(Application.StartupPath & "\GiftOrderPrint.xlt")
        objWsh = objWbk.ActiveSheet

        With dgGift.CurrentRow
            'objExcel.Visible = True
            'blnPrinted = objExcel.Dialogs(Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogPrintPreview).Show
            objWsh.Range("B3").Value = .Cells("RecId").Value
            objWsh.Range("B4").Value = .Cells("GiftName").Value
            objWsh.Range("B5").Value = .Cells("Quantity").Value
            objWsh.Range("B6").Value = .Cells("Reason").Value
            objWsh.Range("B7").Value = .Cells("FstUpdate").Value
            objWsh.Range("B8").Value = .Cells("ApprovedDate").Value
            objWsh.Range("A15").Value = .Cells("Requester").Value
            objWsh.Range("B15").Value = .Cells("ApprovedBy").Value
            objWsh.PrintOutEx()
            pobjSql.ExecuteNonQuerry("Update Data1a_GiftInout Set NbrOfPrintOut=NbrOfPrintOut+1 where Recid=" _
                                     & .Cells("RecId").Value)
        End With

    End Sub
End Class