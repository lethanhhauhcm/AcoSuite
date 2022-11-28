Public Class frmAgentEdit
    Public Sub New(drAgent As DataGridViewRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        With drAgent
            txtCrsCode.Text = .Cells("CrsCode").Value
            txtAgentName.Text = .Cells("AgentName").Value
            txtCity.Text = .Cells("City").Value
        End With
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerries As New List(Of String)
        lstQuerries.Add("Update [MIDT_Raw] set City='" & txtCity.Text & "', AgentName='" & txtAgentName.Text _
                                  & "' where (AgentName='' or AgentName='?') and CrsCode='" & txtCrsCode.Text & "'")
        lstQuerries.Add("Update [MIDT_AgentName] set City='" & txtCity.Text & "', AgentName='" & txtAgentName.Text _
                                  & "' where (AgentName='' or AgentName='?') and CrsCode='" & txtCrsCode.Text & "'")
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Me.Dispose()
        Else
            MsgBox("Unable to update AgentName")
        End If

    End Sub

    Private Function CheckInputValues() As Boolean
        If Not pobjSql.CitiesExist(txtCity.Text) Then
            MsgBox("Invalid City")
            Return False
        End If
        Select Case txtAgentName.TextLength
            Case 0, Is > 8
                Return False
        End Select

        Return True
    End Function
    
End Class