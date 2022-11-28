'20220526 add by 7643
Imports System.Data.SqlClient
Public Class frmPricePerUser
    Private Enum FAction
        Add
        Edit
        Delete
    End Enum

#Region "Custom Price"
    Private Sub FormatGrid()
        dgvMain.Columns("Price").DefaultCellStyle.Format = DgvNumberFormat(dgvMain, "Price")
        dgvMain.Columns("RecID").DefaultCellStyle.Alignment = DgvIDAlignment(dgvMain, "RecID")
    End Sub

    Private Sub loadmain()
        Dim mSql As String

        mSql = "SELECT RecID,Price " &
               "FROM DATA1A_PRICEPERUSER " &
               "WHERE CITY='" & pobjUser.City & "' AND STATUS='OK' " &
               "ORDER BY PRICE"
        pobjSql.LoadDataGridView(dgvMain, mSql)
    End Sub

    Private Function CheckValue(xAction As FAction) As Boolean
        Dim i As Integer
        Dim mSQL As String

        If xAction <> FAction.Add Then
            If dgvMain.CurrentRow.Cells("Price").Value = 0 Then
                MsgBox("Can't delete default Price!")
                Return False
            Else
                mSQL = "select PLD.PricePerUser " &
                       "from DATA1A_PriceListDetail PLD left join DATA1A_PriceList PL on PLD.PriceID=PL.PriceID and PL.Status='OK' " &
                       "where PLD.PricePerUser=" & dgvMain.CurrentRow.Cells("price").Value & " and PLD.Status='OK' and PL.City='" & pobjUser.City & "'"
                If pobjSql.GetScalarAsString(mSQL) <> "" Then
                    MsgBox("PriceList has used this Price!")
                    Return False
                End If
            End If
        ElseIf xAction <> FAction.Delete Then
            For i = 0 To dgvMain.Rows.Count - 1
                If (xAction = FAction.Edit) And (i = dgvMain.CurrentRow.Index) Then Continue For

                If dgvMain.Rows(i).Cells("Price").Value = txtPrice.Text Then
                    MsgBox("Price is duplicate!")
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Private Sub AddMain()
        Dim mSQL As String

        mSQL = "insert into DATA1A_PricePerUser(Price,City,Status,FstDate,FstUser) " &
               "values(" & txtPrice.Text & ",'" & pobjUser.City & "','OK','" & Now.ToString("yyyyMMdd hh:mm:ss") & "','" & pobjUser.UserName & "')"
        pobjSql.ExecuteNonQuerry(mSQL)
    End Sub

    Private Sub EditMain()
        Dim mSQL As String

        mSQL = "update DATA1A_PricePerUser " &
               "set Price=" & txtPrice.Text & ",LstDate='" & Now.ToString("yyyyMMdd hh:mm:ss") & "',Lstuser='" & pobjUser.UserName & "' " &
               "where RecID=" & dgvMain.CurrentRow.Cells("RecID").Value.ToString & ""
        pobjSql.ExecuteNonQuerry(mSQL)
    End Sub

    Private Sub DeleteMain()
        Dim mSQL As String

        mSQL = "update DATA1A_PricePerUser " &
               "set status='XX',LstDate='" & Now.ToString("yyyyMMdd hh:mm:ss") & "',Lstuser='" & pobjUser.UserName & "' " &
               "where RecID=" & dgvMain.CurrentRow.Cells("RecID").Value.ToString & ""
        pobjSql.ExecuteNonQuerry(mSQL)
    End Sub

    Private Sub ButtomState()
        If dgvMain.CurrentRow Is Nothing Then
            txtPrice.Text = "0"
            llbEdit.Enabled = False
            llbDelete.Enabled = False
        Else
            txtPrice.Text = Format(dgvMain.CurrentRow.Cells("Price").Value, "0")
            llbEdit.Enabled = True
            llbDelete.Enabled = True
        End If
    End Sub
#End Region

    Private Sub frmPricePerUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadmain()
        FormatGrid()
    End Sub

    Private Sub llbEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbEdit.LinkClicked
        If Not CheckValue(FAction.Edit) Then Exit Sub
        If txtPrice.Text <> dgvMain.CurrentRow.Cells("Price").ToString Then EditMain()
        loadmain()
    End Sub

    Private Sub llbAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbadd.LinkClicked
        If Not CheckValue(FAction.Add) Then Exit Sub
        AddMain()
        loadmain()
    End Sub

    Private Sub txtPrice_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPrice.Validating
        If txtPrice.Text = "" Then txtPrice.Text = "0"
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        PressInteger(e)
    End Sub

    Private Sub llbDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDelete.LinkClicked
        If MsgBox("Delete this Price?", vbYesNo) = vbNo Then Exit Sub
        If Not CheckValue(FAction.Delete) Then Exit Sub
        DeleteMain()
        loadmain()
        ButtomState()
    End Sub

    Private Sub dgvMain_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMain.SelectionChanged
        ButtomState()
    End Sub
End Class