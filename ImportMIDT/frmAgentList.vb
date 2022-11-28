Public Class frmAgentList

    Private Sub frmAgentUpdt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Start()
    End Sub
    Public Sub Start()

        Search()
    End Sub
    Public Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strListQuerry As String

        strListQuerry = "select CrsCode,City,AgentName" _
                        & " from [MIDT_AgentName] where recid>0 "

        If chkBlankAgt.Checked Then
            strListQuerry = strListQuerry & " and (AgentName='' or AgentName='?')"
        Else
            AddLikeConditionText(strListQuerry, txtAgentName)
        End If

        AddLikeConditionText(strListQuerry, txtCity)

        AddLikeConditionText(strListQuerry, txtCrsCode)
        If txtAccountName.Text <> "" Then
            strListQuerry = strListQuerry & " and CrsCode in (Select distinct CrsCode from MIDT_RAW where AccountName like'%" _
                & txtAccountName.Text & "%')"
        End If
        strListQuerry = strListQuerry & " order by CrsCode"

        daConditions = New SqlClient.SqlDataAdapter(strListQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "MIDT_AgentName")

        dgAgents.DataSource = dsConditions.Tables("MIDT_AgentName")
        dgAgents.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dsConditions.Dispose()
        daConditions.Dispose()
        Search = True
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSeacrh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeacrh.Click
        Search()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtCrsCode.Text = ""
        txtAgentName.Text = ""
        txtCity.Text = ""
        txtAccountName.Text = ""
        chkBlankAgt.Checked = True
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim frmAdd As New frmAgentEdit(dgAgents.CurrentRow)
        frmAdd.ShowDialog()
        Search()
    End Sub

    Private Sub chkBlankAgt_CheckedChanged(sender As Object, e As EventArgs) Handles chkBlankAgt.CheckedChanged
        txtAgentName.Enabled = Not chkBlankAgt.Checked
    End Sub

    Private Sub dgAgents_SelectionChanged(sender As Object, e As EventArgs) Handles dgAgents.SelectionChanged
        If dgAgents.Rows.Count > 0 Then
            Dim strQuerry As String = "Select distinct AccountName from MIDT_RAW where CrsCode='" _
                                      & dgAgents.CurrentRow.Cells("CrsCode").Value & "'"
            If dgAgents.CurrentRow.Cells("AgentName").Value = "" Then
                btnEdit.Enabled = True
            Else
                btnEdit.Enabled = False
            End If
            pobjSql.LoadDataGridView(dgAccountName, strQuerry)
        End If

    End Sub

    
End Class