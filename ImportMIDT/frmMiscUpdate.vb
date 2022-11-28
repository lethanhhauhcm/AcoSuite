Public Class frmMiscUpdate
    Private mlstFields As List(Of clsMiscField)
    Private mstrCatergory As String

    Private Sub frmMiscUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Public Sub New(strCatergory As String, lstFields As List(Of clsMiscField))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mlstFields = lstFields
        mstrCatergory = strCatergory

        
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String = "Select RecId"

        For Each objField As clsMiscField In mlstFields
            strQuerry = strQuerry & "," & objField.ColumnName & " as " & objField.FieldName
        Next
        strQuerry = strQuerry & " from Data1a_Misc where Cat='" & mstrCatergory & "' order by " & mlstFields(0).FieldName

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Dispose()
    End Sub
End Class