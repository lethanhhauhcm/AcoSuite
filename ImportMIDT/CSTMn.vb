Public Class CSTMn
    Private Agt_w As String
    Private Sub CSTMn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadGridCSTM()
        If InStr(MyRole, "CMCLOFFR") > 0 Then Me.LblAssign.Enabled = True
        If InStr(MyRole, "SUPERVSR") > 0 Then Me.LblApprove.Enabled = True
    End Sub
    Private Sub LoadGridCSTM()
        Dim dAdapter As SqlClient.SqlDataAdapter
        Dim dSet As New Data.DataSet
        Dim StrSQL As String

        StrSQL = "select * from CSTM1 where"
        StrSQL = StrSQL & " status='OK' and validThru >getdate()"
        dAdapter = New SqlClient.SqlDataAdapter(StrSQL, pobjSql.Connection)
        Me.GridCSTM.Columns.Clear()
        dAdapter.Fill(dSet, "TamB")
        Me.GridCSTM.DataSource = dSet.Tables("tamB")
        Me.GridCSTM.Columns(0).Visible = False
        Me.GridCSTM.Columns("CommOffer").Width = 64
        Me.GridCSTM.Columns("Target").Width = 56
        Me.GridCSTM.Columns("Status").Width = 36
        Me.GridCSTM.Columns("ValidFrom").Width = 64
        Me.GridCSTM.Columns("TimeFrame").Width = 64
        Me.GridCSTM.Columns("MinToRQAdh").Width = 64
        Me.GridCSTM.Columns("FstUser").Width = 50
        Me.GridCSTM.Columns("LstUser").Width = 50

        Me.GridCSTM.Columns("VND").Width = 64

        Me.GridCSTM.Columns("Target").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridCSTM.Columns("VND").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridCSTM.Columns("Target").DefaultCellStyle.Format = "#,###"
        Me.GridCSTM.Columns("VND").DefaultCellStyle.Format = "#,###"
        Me.GridCSTM.Columns("MinToRQAdh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridCSTM.Columns("MinToRQAdh").DefaultCellStyle.Format = "#,###"

    End Sub

    Private Sub GridCSTM_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridCSTM.CellContentClick
        Me.OptOK.Enabled = True
        Me.OptQQ.Enabled = True
        Me.OptXX.Enabled = True
        LoadLstAgent()
    End Sub
    Private Sub LoadLstAgent()
        Dim strSQL As String
        Me.LblApprove.Visible = False
        Me.LblAssign.Visible = False
        strSQL = " CustShortName from cstmn "
        strSQL = strSQL & " where CSTMID=" & Me.GridCSTM.CurrentRow.Cells("recID").Value
        If Me.OptQQ.Checked Then strSQL = strSQL & " and status='QQ'"
        If Me.OptXX.Checked Then strSQL = strSQL & " and status='XX'"
        If Me.OptOK.Checked Then strSQL = strSQL & " and status='OK'"
        cmd.CommandText = "select " & strSQL
        Me.LstAgt.Items.Clear()
        dReader = cmd.ExecuteReader
        Do While dReader.Read
            Me.LstAgt.Items.Add(dReader.Item("custShortName"), True)
        Loop
        dReader.Close()
        If Me.OptOK.Checked Then
            cmd.CommandText = "select ShortName from agent where status='OK' and shortname not in (select " & strSQL & ")"
            dReader = cmd.ExecuteReader
            Do While dReader.Read
                Me.LstAgt.Items.Add(dReader.Item("ShortName"), False)
            Loop
            dReader.Close()
        End If
    End Sub
    Private Sub OptQQ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        OptQQ.Click, OptOK.Click, OptXX.Click
        LoadLstAgent()
        If Me.OptQQ.Checked Then Me.LblApprove.Visible = True
        If Me.OptOK.Checked Then Me.LblAssign.Visible = True
    End Sub
    Private Sub LblAssign_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblAssign.LinkClicked
        Dim i As Int16, StrSQL As String, CustId As Integer
        StrSQL = "update cstmn set status='XX', lstUser='" & SICode & "', lstUpdate=getdate() where cstmid=" & Me.GridCSTM.CurrentRow.Cells("recID").Value
        For i = 0 To Me.LstAgt.Items.Count - 1
            If Me.LstAgt.GetItemChecked(i) Then
                cmd.CommandText = "select RecID from agent where custShortName='" & Me.LstAgt.Items(i).ToString & "' and status='OK'"
                CustId = cmd.ExecuteScalar
                StrSQL = StrSQL + "; insert cstmn (CustShortName, CSTMID, FstUser, CustID) values ('" & Me.LstAgt.Items(i).ToString & _
                "'," & Me.GridCSTM.CurrentRow.Cells("recID").Value & ",'" & SICode & "'," & CustId & ")"
            End If
        Next
        cmd.CommandText = StrSQL
        cmd.ExecuteNonQuery()
        LoadLstAgent()
    End Sub
    Private Sub LblApprove_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblApprove.LinkClicked
        Dim i As Int16, StrSQL As String = ""
        For i = 0 To Me.LstAgt.Items.Count - 1
            If Me.LstAgt.GetItemChecked(i) Then
                StrSQL = StrSQL & "; Update cstmn set status='OK', approvedBy='" & SICode & "@" & Now & "' " & _
                    " where status='QQ' and cstmid=" & Me.GridCSTM.CurrentRow.Cells("recID").Value & " and custshortname='" & _
                    Me.LstAgt.Items(i).ToString & "'"
            End If
        Next
        If StrSQL.Length > 2 Then
            cmd.CommandText = StrSQL.Substring(1)
            cmd.ExecuteNonQuery()
        End If
        LoadLstAgent()
    End Sub

    Private Sub LstAgt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstAgt.SelectedIndexChanged
        Me.LblAssign.Visible = True
    End Sub
End Class