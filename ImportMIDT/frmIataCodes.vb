Public Class frmIataCodes
    Private mstrShortName As String

    Private Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strQuerry As String = "Select * from DATA1A_IataCodes where status<>'XX'"

        AddEqualConditionCombo(strQuerry, cboShortName)
        'AddEqualConditionText(strQuerry, txtOffcId)
        'AddEqualConditionCheck(strQuerry, chkTMC)

        strQuerry = strQuerry & " order by Source,Code"
        daConditions = New SqlClient.SqlDataAdapter(strQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_IataCodes")
        DataGridView1.DataSource = dsConditions.Tables("DATA1A_IataCodes")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'DataGridView1.Columns("Description").Visible = False
        DataGridView1.AutoResizeColumns()
        dsConditions.Dispose()
        daConditions.Dispose()

        Return True
    End Function
    Private Sub SwitchEditStatus(blnAllow As Boolean)
        cboGDS.Enabled = blnAllow
        txtIataCode.Enabled = blnAllow
    End Sub
    Private Function CheckInputValue(blnNew As Boolean) As Boolean
        If Not CheckFormatComboBox(cboGDS, , 2) Then
            Return False
        End If

        If Not CheckFormatIataCode(txtIataCode.Text) Then
            MsgBox("Invalid IataCode")
            Return False
        End If

        Dim strOldShortName As String = pobjSql.GetScalarAsString("Select ShortName from DATA1A_IataCodes where Status<>'XX' and Code='" _
                                     & txtIataCode.Text & "' and ShortName<>'" & cboShortName.Text & "'")

        If blnNew AndAlso strOldShortName = cboShortName.Text Then
            MsgBox("IataCode is used by " & strOldShortName)
            Return False
        End If
        Return True
    End Function
    Public Sub New(Optional strShortName As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrShortName = strShortName
    End Sub
    Private Sub choShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged
        Search()
    End Sub

    Private Sub frmOfficeIDs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadCombo(cboShortName, "Select distinct ShortName as Value from DATA1A_Customers where Status<>'XX'")
        '" and PIC='"                          & pobjUser.UserName & "' order by ShortName")
        cboShortName.Text = mstrShortName
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        With DataGridView1.CurrentRow
            cboGDS.Text = .Cells("Source").Value
            txtIataCode.Text = .Cells("Code").Value
            SwitchEditStatus(False)
            lbkAdd.Text = "Add"
            lbkEdit.Text = "Edit"
        End With

    End Sub

    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        If lbkAdd.Text = "Add" Then
            SwitchEditStatus(True)
            txtIataCode.Text = ""
            cboGDS.Text = ""
            lbkAdd.Text = "Save"
        ElseIf CheckInputValue(True) AndAlso pobjSql.ExecuteNonQuerry("Insert Into DATA1A_IataCodes (ShortName, Source, Code, Status, FstUser) values ('" _
                                     & cboShortName.Text & "','" & cboGDS.Text & "','" & txtIataCode.Text _
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
            lstQuerries.Add("Insert Into DATA1A_IataCodes (ShortName, Source, Code, Status, FstUser) values ('" _
                            & cboShortName.Text & "','" & cboGDS.Text & "','" & txtIataCode.Text _
                            & "','OK','" & pobjUser.UserName & "')")

            lstQuerries.Add("Update DATA1A_IataCodes set Status='XX',LstUpdate=getdate(),LstUser='" _
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

        lstQuerries.Add("Update DATA1A_IataCodes set Status='XX',LstUpdate=getdate(),LstUser='" _
                        & pobjUser.UserName & "' where RecId=" & DataGridView1.CurrentRow.Cells("RecId").Value)

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unale to Delete IataCode")
            Exit Sub
        End If
    End Sub
End Class