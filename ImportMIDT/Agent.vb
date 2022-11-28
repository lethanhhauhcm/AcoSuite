Public Class Agent
    Private cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
    Private Sub LblDelete_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblDelete.LinkClicked
        cmd.CommandText = "update agent set status='XX', lstUser='" & pobjUser.UserName & "', lstupdate=getdate() where recid=" & Me.GridAgent.CurrentRow.Cells("recID").Value
        cmd.ExecuteNonQuery()
        LoadGridAgent("")
    End Sub
    Private Sub LoadGridAgent(ByVal pDK As String)
        Me.LblSave.Visible = False
        Me.LblDelete.Visible = False
        Me.LblAssign.Visible = False
        Me.LblShowUnAssign.Visible = False
        Dim dAdapter As SqlClient.SqlDataAdapter
        Dim dSet As New Data.DataSet
        Dim StrSQL As String
        Dim strRegion As String
        Select Case pobjUser.City
            Case "HAN"
                strRegion = "North"
            Case Else
                strRegion = "South"
        End Select
        StrSQL = "select RecID, ShortName, AccountNameGB as FullName,PIC from DATA1A_Customers where Region='" & strRegion & "' and status<>'XX'" & pDK
        dAdapter = New SqlClient.SqlDataAdapter(StrSQL, pobjSql.Connection)
        Me.GridAgent.Columns.Clear()
        dAdapter.Fill(dSet, "TamB")
        Me.GridAgent.DataSource = dSet.Tables("tamB")
        Me.GridAgent.Columns(0).Width = 45
        Me.GridAgent.Columns(1).Width = 128
        Me.GridAgent.Columns(2).Width = 256
        Me.GridAgent.Columns(3).Width = 50
    End Sub

    Private Sub Agent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub Agent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadGridAgent("")

        Me.LblAdd.Enabled = True
        Me.LblAssign.Enabled = True
        Me.LblDelete.Enabled = True
        Me.LblSave.Enabled = True
        Me.txtOIDtoAdd.Enabled = True

    End Sub

    Private Sub GridAgent_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridAgent.CellContentClick
        Me.LblAdd.Visible = False
        Me.LblSave.Visible = True
        Me.LblDelete.Visible = True
        Me.LblAssign.Visible = True
        Me.LblShowUnAssign.Visible = True
        Me.TxtFullName.Text = Me.GridAgent.CurrentRow.Cells("FullName").Value
        Me.TxtShortName.Text = Me.GridAgent.CurrentRow.Cells("ShortName").Value
        Me.TxtPIC.Text = Me.GridAgent.CurrentRow.Cells("PIC").Value
        LoadListOID()
    End Sub
    Private Sub LoadListOID()
        Me.LstOID.DataSource = GetDataTable("select val from midt_misc where cat='AGT_OID' and val1=" & Me.GridAgent.CurrentRow.Cells("RecID").Value & " order by val")
        Me.LstOID.DisplayMember = "VAL"
        'Me.LstOID.Items.Clear()
        'cmd.CommandText = "select val from midt_misc where cat='AGT_OID' and val1=" & Me.GridAgent.CurrentRow.Cells("RecID").Value & " order by val"
        'dReader = cmd.ExecuteReader
        'Do While dReader.Read
        '    Me.LstOID.Items.Add(dReader.Item("VAL"), True)
        'Loop
        'dReader.Close()
    End Sub
    Private Sub LblAdd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblAdd.LinkClicked
        Dim tmpRec As Integer
        cmd.CommandText = "select RecID from agent where shortname='" & Me.TxtShortName.Text & "' or FullName='" & Me.TxtFullName.Text & "' and status='OK'"
        tmpRec = cmd.ExecuteScalar
        If tmpRec > 0 Then Exit Sub
        cmd.CommandText = "insert agent (shortname, fullname, fstuser) values ('" & Me.TxtShortName.Text & "',N'" & Me.TxtFullName.Text & _
            "','" & pobjUser.UserName & "')"
        cmd.ExecuteNonQuery()
        LoadGridAgent("")
    End Sub

    Private Sub LblSave_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblSave.LinkClicked
        Dim tmpRecNo As Integer
        cmd.CommandText = "update agent set fullname=N'" & Me.TxtFullName.Text & _
            "', pic='" & Me.TxtPIC.Text & "' where recid =" & Me.GridAgent.CurrentRow.Cells("recID").Value
        cmd.ExecuteNonQuery()
        If Me.txtOIDtoAdd.Text <> "" Then
            cmd.CommandText = "select RecID from Midt_misc where cat='AGT_OID' and val1='" & Me.GridAgent.CurrentRow.Cells("RecID").Value & _
                "' and VAL='" & Me.txtOIDtoAdd.Text & "'"
            tmpRecNo = cmd.ExecuteScalar
            If tmpRecNo = 0 Then
                cmd.CommandText = " insert midt_misc (cat, val1, val) values ('AGT_OID','" & Me.GridAgent.CurrentRow.Cells("RecID").Value & _
                    "','" & Me.txtOIDtoAdd.Text & "')"
                cmd.ExecuteNonQuery()
            End If
        End If
        LoadGridAgent("")
    End Sub

    Private Sub LblShowUnAssign_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblShowUnAssign.LinkClicked
        Me.LstOID.DataSource = GetDataTable("select distinct Office from allstatssi where left(office,3)='" & pobjUser.City & "' and office not in " & _
            " (select VAL from midt_misc where cat='AGT_OID')")
        Me.LstOID.DisplayMember = "Office"
        'cmd.CommandText = 
        'dReader = cmd.ExecuteReader
        'Do While dReader.Read
        '    Me.LstOID.Items.Add(dReader.Item("Office"), False)
        'Loop
        'dReader.Close()
    End Sub

    Private Sub LblAssign_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblAssign.LinkClicked
        Dim StrSQL As String, i As Int16
        StrSQL = "delete from midt_Misc where cat='AGT_OID' and val1='" & Me.GridAgent.CurrentRow.Cells("RecID").Value & "'"
        For i = 0 To Me.LstOID.Items.Count - 1
            If Me.LstOID.GetItemChecked(i) Then
                StrSQL = StrSQL & "; insert midt_misc (cat, val1, val) values ('AGT_OID','" & Me.GridAgent.CurrentRow.Cells("RecID").Value & _
                    "','" & Me.LstOID.Items(i).ToString & "')"
            End If
        Next
        cmd.CommandText = StrSQL
        cmd.ExecuteNonQuery()
        LoadGridAgent("")
    End Sub

    Private Sub LblSearch_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblSearch.LinkClicked
        Dim kq As String
        cmd.CommandText = "select VAL1 from midt_MISC where cat+VAL='AGT_OID" & Me.TxtOID.Text & "'"
        kq = cmd.ExecuteScalar
        If kq <> "" Then
            MsgBox(kq, MsgBoxStyle.Information, "Amadeus Vietnam")
        Else
            MsgBox("OID not Found", MsgBoxStyle.Critical, "Amadeus Vietnam")
        End If
    End Sub

    Private Sub LblFilter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblFilter.LinkClicked
        Dim DK As String = " And "
        Dim colName As String, Col As Integer
        On Error Resume Next
        Col = Me.GridAgent.CurrentCell.ColumnIndex
        colName = Me.GridAgent.Columns(Col).Name
        DK = DK & colName & " like '%" & Me.TxtOID.Text & "%'"
        LoadGridAgent(DK)
        On Error GoTo 0

    End Sub
End Class