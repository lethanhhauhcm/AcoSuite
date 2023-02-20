﻿Public Class frmSecoOffer_MultiEdit
    Public FdgvTemp As New DataGridView
    Public FEffDate, FExpDate As String
    Private Sub frmSecoOffer_MultiEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mSQL As String
        Dim mPricePerUser As DataGridViewComboBoxColumn

        dtpEffDate.Value = DateSerial(Now.Year, Now.Month, 1)
        dtpExpDate.Value = DateSerial(Now.Year, Now.Month, 1)

        mPricePerUser = dgvDetail.Columns(2)
        mSQL = String.Format("select Price Value from DATA1A_PricePerUser where Status='OK' and City='{0}' order by Price", {pobjUser.City})
        pobjSql.LoaddgvCombo(mPricePerUser, mSQL)
    End Sub

    Private Sub frmSecoOffer_MultiEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim i As Integer
        Dim mSQL, mCustomer As String
        Dim mReturn As DataTable

        If DialogResult <> DialogResult.OK Then Exit Sub

        'Check value
        If dtpEffDate.Value > dtpExpDate.Value Then
            MsgBox("EffDate can not be later than ExpDate!")
            e.Cancel = True
            Exit Sub
        End If

        FEffDate = Format(dtpEffDate.Value, "yyyyMM01")
        FExpDate = Format(dtpExpDate.Value, "yyyyMM" & CStr(Date.DaysInMonth(dtpExpDate.Value.Year, dtpExpDate.Value.Month)))
        mReturn = New DataTable
        mCustomer = ""
        For i = 0 To FdgvTemp.SelectedRows.Count - 1
            mSQL = String.Format("select RecID " &
                                 "from DATA1A_PriceList " &
                                 "where Status='OK' and City='{0}' and PriceID<>{1} and Customer='{2}' and ExpDate>='{3}' and EffDate<='{4}'",
                                 {pobjUser.City, CStr(FdgvTemp.SelectedRows(i).Cells("PriceID").Value), FdgvTemp.SelectedRows(i).Cells("Customer").Value, FEffDate,
                                    FExpDate})
            mReturn = GetDataTable(mSQL, pobjSql.Connection)
            If mReturn.Rows.Count > 0 Then mCustomer &= IIf(mCustomer = "", "", ",") & FdgvTemp.SelectedRows(i).Cells("Customer").Value
        Next
        If mCustomer <> "" Then
            MsgBox("EffDate of " & mCustomer & " is duplicated!")
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub dgvDetail_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvDetail.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf cell_KeyDown
    End Sub

    Private Sub cell_KeyDown(sender As Object, e As KeyPressEventArgs)
        PressInteger(e)
    End Sub

    Private Sub dgvDetail_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellValidated
        If dgvDetail.CurrentRow.IsNewRow Then Exit Sub

        If (dgvDetail.CurrentRow.Cells(0).Selected Or dgvDetail.CurrentRow.Cells(1).Selected) AndAlso
            (dgvDetail.CurrentCell.Value = Nothing OrElse CInt(dgvDetail.CurrentCell.Value) = 0) Then
            dgvDetail.CurrentCell.Value = "1"
        ElseIf (dgvDetail.CurrentRow.Cells(3).Selected) AndAlso dgvDetail.CurrentCell.Value = Nothing Then
            dgvDetail.CurrentCell.Value = "0"
        End If
    End Sub

    Private Sub dgvDetail_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvDetail.RowValidating
        Dim i As Integer

        If dgvDetail.CurrentRow.IsNewRow Then Exit Sub

        If CInt(dgvDetail.CurrentRow.Cells(0).Value) > CInt(dgvDetail.CurrentRow.Cells(1).Value) Then
            MsgBox("FromTheUser can not be larger than ToTheUser!")
            e.Cancel = True
            Exit Sub
        End If

        For i = 0 To dgvDetail.Rows.Count - 2
            If dgvDetail.CurrentRow.Index = i Then Continue For

            If CInt(dgvDetail.CurrentRow.Cells(0).Value) <= CInt(dgvDetail.Rows(i).Cells(1).Value) And
                CInt(dgvDetail.CurrentRow.Cells(1).Value) >= CInt(dgvDetail.Rows(i).Cells(0).Value) Then
                MsgBox("User number is duplicated!")
                e.Cancel = True
                Exit Sub
            End If
        Next

        If CInt(dgvDetail.CurrentRow.Cells(2).Value) > "0" And CInt(dgvDetail.CurrentRow.Cells(3).Value) > "0" Then
            MsgBox("PricePerUser and PriceCombo only apply one!")
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub dgvDetail_Validated(sender As Object, e As EventArgs) Handles dgvDetail.Validated
        Dim i, mToTheUser, mCount As Integer

        dgvDetail.Sort(dgvDetail.Columns(0), ComponentModel.ListSortDirection.Ascending)

        mToTheUser = 0
        mCount = dgvDetail.Rows.Count
        For i = 0 To mCount - 2
            If CInt(dgvDetail.Rows(i).Cells("FromTheUser").Value) > mToTheUser + 1 Then
                dgvDetail.Rows.Add(CStr(mToTheUser + 1), CStr(CInt(dgvDetail.Rows(i).Cells("FromTheUser").Value) - 1), Nothing, "0")
            End If

            mToTheUser = CInt(dgvDetail.Rows(i).Cells("ToTheUser").Value)
        Next

        If mToTheUser < 9999 Then dgvDetail.Rows.Add(CStr(mToTheUser + 1), 9999, Nothing, "0")

        dgvDetail.Sort(dgvDetail.Columns("FromTheUser"), ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub dgvDetail_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgvDetail.SortCompare
        dgvIntSort(e)
    End Sub
End Class