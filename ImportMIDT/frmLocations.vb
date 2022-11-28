Public Class frmLocations
    Private mstrShortName As String
    Private Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strQuerry As String = "Select *,isnull((Select top 1 FullNameGb from DATA1A_Contacts where Status<>'XX'" _
                                  & " and LocationMainContact='True' and LocationName=DATA1A_Locations.LocationName),'') as Manager" _
                                  & " from DATA1A_Locations where status<>'XX'"

        AddEqualConditionCombo(strQuerry, cboShortName)
        'AddEqualConditionText(strQuerry, txtOffcId)
        'AddEqualConditionCheck(strQuerry, chkTMC)

        strQuerry = strQuerry & " order by MainOffc desc,LocationName"
        daConditions = New SqlClient.SqlDataAdapter(strQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_Locations")
        DataGridView1.DataSource = dsConditions.Tables("DATA1A_Locations")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Columns("Comments").Visible = False
        DataGridView1.AutoResizeColumns()
        dsConditions.Dispose()
        daConditions.Dispose()

        Return True
    End Function
    Private Sub SwitchEditStatus(blnAllow As Boolean)
        cboProvince.Enabled = blnAllow
        txtLocationName.Enabled = blnAllow
        chkMainOffc.Enabled = blnAllow
        txtAddress.Enabled = blnAllow
        txtEmails.Enabled = blnAllow
        txtTelNbrs.Enabled = blnAllow
        txtComments.Enabled = blnAllow
    End Sub
    Private Function CheckInputValue(blnNew As Boolean) As Boolean
        If Not CheckFormatComboBox(cboProvince, , 2) Then
            Return False
        End If

        If Not CheckFormatTextBox(txtLocationName, , , 3) Then
            Return False
        End If

        txtEmails.Text = Replace(txtEmails.Text, " ", "")
        If txtEmails.Text.Length > 0 AndAlso Not txtEmails.Text.Contains("@") Then
            MsgBox("Invalid Emails")
            Return False
        End If
        Return True
    End Function
    Public Sub New(Optional strShortName As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        pobjSql.LoadCombo(cboProvince, "Select Val as Value from DATA1A_MISC where CAT='VNCITIES' order by Val")
        mstrShortName = strShortName
    End Sub
    Private Sub choShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged
        Search()
    End Sub

    Private Sub frmLocations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadCombo(cboShortName, "Select distinct ShortName as Value from DATA1A_Customers where Status<>'XX'")
        '" and PIC='"                          & pobjUser.UserName & "' order by ShortName")
        cboShortName.Text = mstrShortName

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        With DataGridView1.CurrentRow
            cboProvince.Text = .Cells("Province").Value
            txtLocationName.Text = .Cells("LocationName").Value
            chkMainOffc.Checked = .Cells("MainOffc").Value
            txtAddress.Text = .Cells("Address").Value
            txtTelNbrs.Text = .Cells("TelNbrs").Value
            txtEmails.Text = .Cells("Emails").Value
            txtComments.Text = .Cells("Comments").Value
            SwitchEditStatus(False)
            lbkAdd.Text = "Add"
            lbkEdit.Text = "Edit"
        End With

    End Sub

    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        If lbkAdd.Text = "Add" Then
            SwitchEditStatus(True)
            txtLocationName.Text = ""
            If pobjUser.City = "SGN" Then
                cboProvince.Text = "TP Ho Chi Minh"
            Else
                cboProvince.Text = "Ha Noi"
            End If

            chkMainOffc.Checked = False
            txtAddress.Text = ""
            txtTelNbrs.Text = ""
            txtEmails.Text = ""
            txtComments.Text = ""
            lbkAdd.Text = "Save"
        ElseIf CheckInputValue(True) AndAlso pobjSql.ExecuteNonQuerry("Insert Into DATA1A_Locations (LocationName,ShortName, Province" _
                                                        & ", MainOffc,Address,TelNbrs,Emails,Comments, Status, FstUser) values (N'" _
                                                        & txtLocationName.Text & "','" & cboShortName.Text & "','" _
                                                        & cboProvince.Text & "','" & IIf(chkMainOffc.Checked, True, False) & "','" _
                                                        & txtAddress.Text & "','" & txtTelNbrs.Text & "','" & txtEmails.Text & "','" _
                                                         & txtComments.Text & "','OK','" & pobjUser.UserName & "')") Then
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
            lstQuerries.Add("Insert Into DATA1A_Locations (LocationName,ShortName, Province" _
                                                    & ", MainOffc,Address,TelNbrs,Emails,Comments, Status, FstUser) values (N'" _
                                                    & txtLocationName.Text & "','" & cboShortName.Text & "','" _
                                                    & cboProvince.Text & "','" & IIf(chkMainOffc.Checked, True, False) & "','" _
                                                    & txtAddress.Text & "','" & txtTelNbrs.Text & "','" & txtEmails.Text & "','" _
                                                    & txtComments.Text & "','OK','" & pobjUser.UserName & "')")

            lstQuerries.Add("Update DATA1A_Locations set Status='XX',LstUpdate=getdate(),LstUser='" _
                            & pobjUser.UserName & "' where RecId=" & DataGridView1.CurrentRow.Cells("RecId").Value)

            If pobjSql.UpdateListOfQuerries(lstQuerries) Then
                lbkEdit.Text = "Edit"
                SwitchEditStatus(False)
                Search()
            Else
                MsgBox("Unale to Update Location")
                Exit Sub
            End If

        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        Dim lstQuerries As New List(Of String)

        lstQuerries.Add("Update DATA1A_Locations set Status='XX',LstUpdate=getdate(),LstUser='" _
                        & pobjUser.UserName & "' where RecId=" & DataGridView1.CurrentRow.Cells("RecId").Value)

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unale to Delete Location")
            Exit Sub
        End If
    End Sub

End Class