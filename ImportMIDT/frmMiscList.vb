Public Class frmMiscList
    Private mobjField As clsMiscField
    Private mstrCat As String
    Public Sub New(strCat As String, objField As clsMiscField)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrCat = strCat
        mobjField = objField

        If objField.MaxLength <> 0 Then
            txtNewValue.MaxLength = objField.MaxLength
        End If

    End Sub

    Private Sub frmMiscList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "Select RecId, " & mobjField.ColumnName & " as " & mobjField.FieldName _
                                    & ",FstUpdate from data1a_misc where Cat='" & mstrCat & "'"
        pobjSql.LoadDataGridView(dgrMisc, strQuerry)
        Return True
    End Function

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        If dgrMisc.CurrentRow Is Nothing Then Exit Sub
        If pobjSql.ExecuteNonQuerry("delete from DATA1A_MISC where RecId=" & dgrMisc.CurrentRow.Cells("Recid").Value) Then
            Search()
        End If
    End Sub

    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        If Not CheckInputValues() Then Exit Sub
        If pobjSql.ExecuteNonQuerry("Insert into DATA1A_MISC (CAT," & mobjField.ColumnName & ") values ('" _
                                    & mstrCat & "','" & txtNewValue.Text & "')") Then
            Search()
            txtNewValue.Text = ""
        Else
            MsgBox("Unable to insert new record into Database")
        End If
    End Sub
    Private Function CheckInputValues() As Boolean
        If mobjField.MinLength <> 0 AndAlso txtNewValue.TextLength < mobjField.MinLength Then
            MsgBox("Invalid Min Length for" & mobjField.FieldName)
            Return False
        ElseIf mobjField.Numeric AndAlso Not IsNumeric(txtNewValue.Text) Then
            MsgBox(mobjField.FieldName & " must be in numeric!")
            Return False
        End If

        Return True
    End Function
End Class