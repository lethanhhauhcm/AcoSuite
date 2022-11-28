Imports System.Data.SqlClient
Module LibStr
    Public LDGVForm As Form
    Public LTrans As SqlClient.SqlTransaction

    Public Sub FillDatagridview(ByRef xDs As DataSet, ByRef xSda As SqlDataAdapter, xSql As String, xDgv As DataGridView, xConnection As SqlConnection, Optional xFilter As String = "")
        If xSql = "" Then Exit Sub
        xSda = New SqlDataAdapter(xSql, xConnection)
        xDs.Reset()
        xSda.Fill(xDs)
        xDs.Tables(0).DefaultView.RowFilter = xFilter
        xDgv.DataSource = xDs.Tables(0)
    End Sub

    Public Sub IniDgv(xTitle As String, xColumns() As String, xFormat() As String)
        Dim mDgv As New DataGridView
        Dim i As Integer

        LDGVForm = New Form
        LDGVForm.Text = xTitle
        LDGVForm.Size = New Size(500, 600)
        LDGVForm.StartPosition = FormStartPosition.CenterScreen

        mDgv.Parent = LDGVForm
        mDgv.Dock = DockStyle.Fill
        mDgv.AllowUserToAddRows = False
        mDgv.AllowUserToDeleteRows = False
        mDgv.ReadOnly = True
        For i = 0 To xColumns.Length - 1
            mDgv.Columns.Add(xColumns(i), xColumns(i))
        Next

        For i = 0 To xFormat.Length - 1
            If xFormat(i).Contains("#,##0") Then
                mDgv.Columns(i).DefaultCellStyle.Format = DgvNumberFormat(mDgv, mDgv.Columns(i).Name)
            ElseIf xFormat(i) <> "" Then
                mDgv.Columns(i).DefaultCellStyle.Format = xFormat(i)
            End If
        Next
    End Sub

    Public Sub CommitDataset(xDs As DataSet, xSda As SqlDataAdapter, xUpdateFields() As String, xUpdateValues() As Object)
        Dim mDs As New DataSet
        Dim mScb As New SqlCommandBuilder
        Dim i As Integer

        mDs = xDs.GetChanges()
        If mDs IsNot Nothing Then
            For i = 0 To mDs.Tables(0).Rows.Count - 1
                If mDs.Tables(0).Rows(i).RowState = DataRowState.Deleted Then
                    mDs.Tables(0).Rows(i).RejectChanges()
                    mDs.Tables(0).Rows(i).SetModified()

                    mDs.Tables(0).Rows(i).Item(xUpdateFields(0)) = xUpdateValues(0)
                    mDs.Tables(0).Rows(i).Item(xUpdateFields(1)) = xUpdateValues(1)
                    mDs.Tables(0).Rows(i).Item("Status") = "XX"
                End If
            Next

            mScb = New SqlCommandBuilder(xSda)
            xSda.Update(mDs)
            xDs.AcceptChanges()
        End If
    End Sub

    Public Function DefaultID(xField As String, xTable As String, xclsTvcs As clsTvcs) As String
        Dim mSQL As String
        Dim mSeq As Integer

        mSQL = "select isnull(max(" & xField & "),0) MID " &
               "from " & xTable & " TmpTable "
        mSeq = Integer.Parse(xclsTvcs.GetScalarAsString(mSQL)) + 1

        Return mSeq.ToString
    End Function

    Public Sub DefaultControl(xControl As Control, Optional xDgv As DataGridView = Nothing, Optional xZero As Boolean = False)
        Dim i As Integer
        Dim mName As String

        If (xDgv Is Nothing) OrElse (xDgv.CurrentRow Is Nothing) Then
            For i = 0 To xControl.Controls.Count - 1
                If TypeOf xControl.Controls(i) Is TextBox Then
                    CType(xControl.Controls(i), TextBox).Text = IIf(xZero = True, "0", "")
                ElseIf TypeOf xControl.Controls(i) Is DateTimePicker Then
                    CType(xControl.Controls(i), DateTimePicker).Value = Now
                ElseIf TypeOf xControl.Controls(i) Is CheckBox Then
                    CType(xControl.Controls(i), CheckBox).Checked = False
                ElseIf (TypeOf xControl.Controls(i) Is ComboBox) AndAlso (CType(xControl.Controls(i), ComboBox).Items.Count > 0) Then
                    CType(xControl.Controls(i), ComboBox).SelectedIndex = 0
                End If
            Next
        Else
            For i = 0 To xControl.Controls.Count - 1
                mName = ""
                If TypeOf xControl.Controls(i) Is TextBox Then
                    mName = Replace(xControl.Controls(i).Name, "txt", "")
                    If xDgv.CurrentRow.Cells(mName).Value IsNot Nothing Then
                        If IsNumeric(xDgv.CurrentRow.Cells(mName).Value) Then
                            CType(xControl.Controls(i), TextBox).Text = Format(xDgv.CurrentRow.Cells(mName).Value, "#,##0")
                        Else
                            CType(xControl.Controls(i), TextBox).Text = xDgv.CurrentRow.Cells(mName).Value
                        End If
                    End If
                ElseIf TypeOf xControl.Controls(i) Is DateTimePicker Then
                    mName = Replace(xControl.Controls(i).Name, "dtp", "")
                    If xDgv.CurrentRow.Cells(mName).Value IsNot Nothing Then CType(xControl.Controls(i), DateTimePicker).Value = xDgv.CurrentRow.Cells(mName).Value
                ElseIf TypeOf xControl.Controls(i) Is CheckBox Then
                    mName = Replace(xControl.Controls(i).Name, "chk", "")
                    If xDgv.CurrentRow.Cells(mName).Value IsNot Nothing Then CType(xControl.Controls(i), CheckBox).Checked = xDgv.CurrentRow.Cells(mName).Value
                ElseIf TypeOf xControl.Controls(i) Is ComboBox Then
                    mName = Replace(xControl.Controls(i).Name, "cbo", "")
                    If (CType(xControl.Controls(i), ComboBox).Items.Count > 0) AndAlso (xDgv.CurrentRow.Cells(mName).Value IsNot Nothing) Then
                        CType(xControl.Controls(i), ComboBox).SelectedValue = xDgv.CurrentRow.Cells(mName).Value
                    End If
                End If
            Next
        End If
    End Sub

    Public Function DgvNumberFormat(xDgv As DataGridView, xField As String) As String
        xDgv.Columns(xField).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        xDgv.Columns(xField).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Return "#,##0"
    End Function

    Public Function DgvIDAlignment(xDgv As DataGridView, xField As String) As DataGridViewContentAlignment
        xDgv.Columns(xField).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Return DataGridViewContentAlignment.MiddleRight
    End Function

    Public Function GetUser() As String()
        Dim mFile, mArrStr() As String

        mFile = "D:\7643\VB Project\General\DefaultUser.txt"
        If My.Computer.FileSystem.FileExists(mFile) Then mArrStr = Split(My.Computer.FileSystem.ReadAllText(mFile), vbCrLf)

        Return mArrStr
    End Function
End Module
