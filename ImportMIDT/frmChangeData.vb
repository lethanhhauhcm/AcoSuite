Public Class frmChangeData

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim lstQuerries As New List(Of String)
        If Not CheckInputValue() Then
            Exit Sub
        End If

        lstQuerries.Add("Update Midt_Raw set City='" & cboCity.Text & "',AgentName='" & txtNewShortName.Text _
                        & "' where CrsCode='" & txtCrsCode.Text & "' and GDS='" & cboGDS.Text & "'")
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Completed")
        Else
            MsgBox(pobjSql.UpdtErr)
        End If

    End Sub

    Private Sub frmChangeData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboGDS.SelectedIndex = 0
        cboCity.SelectedIndex = 0
    End Sub

    Private Sub txtCrsCode_Leave(sender As Object, e As EventArgs) Handles txtCrsCode.Leave
        Dim strCityAgentName As String = ""
        strCityAgentName = pobjSql.GetScalarAsString("Select top 1 City+'#'+AgentName from Midt_Raw where CrsCode='" _
                                                                   & txtCrsCode.Text & "' and GDS='" & cboGDS.Text & "'")
        If strCityAgentName IsNot Nothing AndAlso strCityAgentName.Length > 5 Then
            txtOldCity.Text = Mid(strCityAgentName, 1, 3)
            txtOldShortName.Text = Mid(strCityAgentName, 5)
            txtNbrOfRecords.Text = pobjSql.GetScalarAsString("Select count (*) from midt_raw where CrsCode='" & txtCrsCode.Text _
                                                             & "' and GDS='" & cboGDS.Text & "'")
            cboCity.Text = txtOldCity.Text
            txtNewShortName.Text = ""
        End If
    End Sub
    Private Function CheckInputValue()
        Select Case txtCrsCode.Text.Length
            Case 3, 4, 9
            Case Else
                MsgBox("Invalid Crs Code")
                Return False
        End Select
        If cboCity.Text = "" Then
            MsgBox("Invalid New City")
            Return False
        End If
        If txtNewShortName.Text = "" Then
            MsgBox("Invalid ShortName")
            Return False
        End If
        Return True
    End Function

    
End Class