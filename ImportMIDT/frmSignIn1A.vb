Public Class frmSignIn1A
    Private mblnNewLoad As Boolean

    Private Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strQuerry As String = "Select * from DATA1A_SignIn1As where status<>'XX'"

        strQuerry = strQuerry & " and Contactid=" & cboContactId.Text
        
        strQuerry = strQuerry & " order by OffcId,SignIn"
        daConditions = New SqlClient.SqlDataAdapter(strQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_SignIn1As")
        DataGridView1.DataSource = dsConditions.Tables("DATA1A_SignIn1As")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'DataGridView1.Columns("Description").Visible = False
        DataGridView1.AutoResizeColumns()
        dsConditions.Dispose()
        daConditions.Dispose()

        Return True
    End Function
    Private Sub SwitchEditStatus(blnAllow As Boolean)
        cboOffcId.Enabled = blnAllow
        txtSignIn.Enabled = blnAllow
    End Sub
    Private Function CheckInputValue(blnNew As Boolean) As Boolean
        Dim tblExistingSign As DataTable
        Dim blnDuplicate As Boolean

        If Not CheckFormatComboBox(cboOffcId, , 9, 9) Then
            Return False
        End If

        If Not CheckFormatTextBox(txtSignIn, 6, , 6) Then
            Return False
        End If

        tblExistingSign = GetDataTable("Select * from Data1a_SignIn1As where Status<>'XX'" _
                                     & " and OffcId='" & cboOffcId.Text & "' and SignIn='" & txtSignIn.Text & "'")
        If blnNew Then
            If tblExistingSign.Rows.Count > 0 Then
                blnDuplicate = True
            ElseIf tblExistingSign.Rows.Count > 1 Then
                blnDuplicate = True
            End If
        End If
        If blnDuplicate Then
            MsgBox("Duplicate Sign in!")
            Return False
        End If
        Return True
    End Function
    Public Sub New(Optional drContact As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mblnNewLoad = True
        If Not drContact Is Nothing Then
            pobjSql.LoadCombo(cboContactId, "Select ContactId as Value from DATA1A_Contacts" _
                                 & " where Status<>'XX' and CustShortName='" & drContact.Cells("CustShortName").Value & "'")
            mblnNewLoad = False

            cboContactId.Text = drContact.Cells("ContactId").Value
            'cboContactId.SelectedText = drContact.Cells("FullNameGb").Value
            'cboContactId.SelectedValue = drContact.Cells("ContactId").Value
        End If
        'cboContact.SelectedIndex = cboContact.FindStringExact(drContact.Cells("CustShortName").Value)

    End Sub
    Private Sub choContactId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContactId.SelectedIndexChanged
        If Not mblnNewLoad Then
            Search()
        End If
    End Sub

    Private Sub frmSignIn1As_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cboContactId.Text <> "" Then
            pobjSql.LoadCombo(cboOffcId, "Select OffcId as Value from DATA1A_OIDs where Status<>'XX' and ShortName=" _
                              & "(Select CustShortName from DATA1A_Contacts where Status<>'XX' and GDS='1A' and ContactId=" _
                              & cboContactId.Text & ")")
            Search()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        With DataGridView1.CurrentRow
            cboOffcId.Text = .Cells("OffcId").Value
            SwitchEditStatus(False)
            lbkAdd.Text = "Add"
            lbkEdit.Text = "Edit"
        End With

    End Sub

    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        If lbkAdd.Text = "Add" Then
            SwitchEditStatus(True)
            txtSignIn.Text = ""
            cboOffcId.Text = ""
            lbkAdd.Text = "Save"
        ElseIf CheckInputValue(True) AndAlso pobjSql.ExecuteNonQuerry("Insert Into DATA1A_SignIn1As (ContactId,OffcId, SignIn, Status, FstUser) values (" _
                                     & cboContactId.SelectedValue & ",'" & cboOffcId.Text & "','" & txtSignIn.Text _
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
        ElseIf CheckInputValue(False) Then
            Dim lstQuerries As New List(Of String)
            lstQuerries.Add("Insert Into DATA1A_SignIn1As (ContactId,OffcId, SignIn, Status, FstUser) values (" _
                                    & cboContactId.SelectedValue & ",'" & cboOffcId.Text & "','" & txtSignIn.Text _
                                    & "','OK','" & pobjUser.UserName & "')")

            lstQuerries.Add("Update DATA1A_SignIn1As set Status='XX',LstUpdate=getdate(),LstUser='" _
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

        lstQuerries.Add("Update DATA1A_SignIn1As set Status='XX',LstUpdate=getdate(),LstUser='" _
                        & pobjUser.UserName & "' where RecId=" & DataGridView1.CurrentRow.Cells("RecId").Value)

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unale to Delete OffcId")
            Exit Sub
        End If
    End Sub
End Class