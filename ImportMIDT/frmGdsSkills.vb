Public Class frmGdsSkills
    Private mblnFirstLoad As Boolean
    Private Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strQuerry As String = "Select * from DATA1A_GdsSkills where status<>'XX'"

        strQuerry = strQuerry & " and Contactid=" & cboContactId.SelectedValue

        strQuerry = strQuerry & " order by GDS,Skills"
        daConditions = New SqlClient.SqlDataAdapter(strQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_GdsSkills")
        DataGridView1.DataSource = dsConditions.Tables("DATA1A_GdsSkills")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'DataGridView1.Columns("Description").Visible = False
        DataGridView1.AutoResizeColumns()
        dsConditions.Dispose()
        daConditions.Dispose()

        Return True
    End Function
    Private Sub SwitchEditStatus(blnAllow As Boolean)
        cboGDS.Enabled = blnAllow
        cboSkills.Enabled = blnAllow
    End Sub
    Private Function CheckInputValue(blnNew As Boolean) As Boolean
        If Not CheckFormatComboBox(cboGDS, , 2, 2) Then
            Return False
        End If

        If Not CheckFormatComboBox(cboSkills, , 1, 16) Then
            Return False
        End If

        Return True
    End Function
    Public Sub New(Optional drContact As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mblnFirstLoad = True
        If Not drContact Is Nothing Then
            pobjSql.LoadCombo(cboContactId, "Select ContactId as Value from DATA1A_Contacts" _
                                 & " where Status<>'XX' and CustShortName='" & drContact.Cells("CustShortName").Value & "'")
            mblnFirstLoad = False
            cboContactId.Text = drContact.Cells("ContactId").Value
            'cboContactId.SelectedText = drContact.Cells("FullNameGb").Value
            'cboContactId.SelectedValue = drContact.Cells("ContactId").Value
        End If
        'cboContact.SelectedIndex = cboContact.FindStringExact(drContact.Cells("CustShortName").Value)

    End Sub
    Private Sub cboContactId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContactId.SelectedIndexChanged
        If Not mblnFirstLoad Then
            Search()
        End If

    End Sub

    Private Sub frmGdsSkills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        With DataGridView1.CurrentRow
            cboGDS.Text = .Cells("GDS").Value

            SwitchEditStatus(False)
            lbkAdd.Text = "Add"
            lbkEdit.Text = "Edit"
        End With

    End Sub

    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        If lbkAdd.Text = "Add" Then
            SwitchEditStatus(True)
            cboSkills.Text = ""
            cboGDS.Text = ""
            lbkAdd.Text = "Save"
        ElseIf CheckInputValue(True) AndAlso pobjSql.ExecuteNonQuerry("Insert Into DATA1A_GdsSkills (ContactId,Gds, Skills,Status, FstUser) values (" _
                                     & cboContactId.SelectedValue & ",'" & cboGDS.Text & "','" & cboSkills.Text _
                                     & "','OK','" & pobjUser.UserName & "')") Then
            lbkAdd.Text = "Add"
            SwitchEditStatus(False)
            Search()
        End If

    End Sub

    Private Sub lbkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkEdit.LinkClicked
        If lbkEdit.Text = "Edit" Then
            SwitchEditStatus(True)
            lbkEdit.Text = "Save"
        ElseIf CheckInputValue(True) Then
            Dim lstQuerries As New List(Of String)
            lstQuerries.Add("Insert Into DATA1A_GdsSkills (ContactId,GDS, Skills, Status, FstUser) values (" _
                                    & cboContactId.SelectedValue & ",'" & cboGDS.Text & "','" & cboSkills.Text _
                                    & "','OK','" & pobjUser.UserName & "')")

            lstQuerries.Add("Update DATA1A_GdsSkills set Status='XX',LstUpdate=getdate(),LstUser='" _
                            & pobjUser.UserName & "' where RecId=" & DataGridView1.CurrentRow.Cells("RecId").Value)

            If pobjSql.UpdateListOfQuerries(lstQuerries) Then
                lbkEdit.Text = "Edit"
                SwitchEditStatus(False)
                Search()
            Else
                MsgBox("Unale to Update OffcId")
                Exit Sub
            End If

        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        Dim lstQuerries As New List(Of String)

        lstQuerries.Add("Update DATA1A_GdsSkills set Status='XX',LstUpdate=getdate(),LstUser='" _
                        & pobjUser.UserName & "' where RecId=" & DataGridView1.CurrentRow.Cells("RecId").Value)

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unale to Delete OffcId")
            Exit Sub
        End If
    End Sub

    
End Class
