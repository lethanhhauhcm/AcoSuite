Public Class frmOfficeIDs
    Private mstrShortName As String
    Private mblnNew As Boolean

    Private Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strQuerry As String = "Select * from DATA1A_OIDs where status<>'XX'"

        AddEqualConditionCombo(strQuerry, cboShortName)
        'AddEqualConditionText(strQuerry, txtOffcId)
        'AddEqualConditionCheck(strQuerry, chkTMC)

        strQuerry = strQuerry & " order by GDS,OffcId"
        daConditions = New SqlClient.SqlDataAdapter(strQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_OIDs")
        dgrOffcID.DataSource = dsConditions.Tables("DATA1A_OIDs")
        dgrOffcID.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'DataGridView1.Columns("Description").Visible = False
        dgrOffcID.AutoResizeColumns()
        dsConditions.Dispose()
        daConditions.Dispose()

        Return True
    End Function
    Private Sub SwitchEditStatus(blnAllow As Boolean)
        cboGDS.Enabled = blnAllow
        txtCode.Enabled = blnAllow
        chkTMC.Enabled = blnAllow
        txtOtaName.Enabled = blnAllow
    End Sub
    Private Function CheckInputValue(blnNew As Boolean) As Boolean
        If Not CheckFormatComboBox(cboGDS, , 2) Then
            Return False
        End If

        If cboGDS.Text = "1A" And txtCode.Text.Length <> 9 Then
            MsgBox("Invalid GDS/OID")
            Return False
        End If

        Dim strOldShortName As String
        If blnNew Then
            strOldShortName = pobjSql.GetScalarAsString("Select ShortName from DATA1A_OIDs where Status<>'XX' and OffcId='" _
                                     & txtCode.Text & "' and GDS='" & cboGDS.Text & "'")  '^_^20221110 add  and GDS='" & cboGDS.Text & "' by 7643
        Else
            strOldShortName = pobjSql.GetScalarAsString("Select ShortName from DATA1A_OIDs where Status<>'XX' and OffcId='" _
                                     & txtCode.Text & "' and ShortName<>'" & cboShortName.Text & "' and GDS='" & cboGDS.Text & "' and GDS='" & cboGDS.Text & "'")  '^_^20221110 add  and GDS='" & cboGDS.Text & "' by 7643
        End If

        If blnNew AndAlso strOldShortName <> "" Then
            MsgBox("OffcId is used by " & strOldShortName)
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgrOffcID.CellClick
        With dgrOffcID.CurrentRow
            cboGDS.Text = .Cells("GDS").Value
            txtCode.Text = .Cells("OffcId").Value
            chkTMC.Checked = .Cells("TMC").Value
            txtOtaName.Text = .Cells("OtaName").Value
            SwitchEditStatus(False)
            lbkAdd.Text = "Add"
            lbkAdd.Visible = True
            lbkEdit.Text = "Edit"
            lbkEdit.Visible = True
        End With

    End Sub

    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        If lbkAdd.Text = "Add" Then
            lbkEdit.Visible = False
            SwitchEditStatus(True)
            txtCode.Text = ""
            cboGDS.Text = ""
            txtOtaName.Text = ""
            chkTMC.Checked = False
            lbkAdd.Text = "Save"
            mblnNew = True
        ElseIf CheckInputValue(mblnNew) AndAlso pobjSql.ExecuteNonQuerry("Insert Into DATA1A_OIDs (ShortName, GDS, OffcId" _
                                      & ", TMC, Status, FstUser,OtaName) values ('" _
                                     & cboShortName.Text & "','" & cboGDS.Text & "','" & txtCode.Text _
                                     & "','" & IIf(chkTMC.Checked, True, False) & "','OK','" _
                                     & pobjUser.UserName & "','" & txtOtaName.Text & "')") Then
            lbkAdd.Text = "Add"
            lbkEdit.Visible = True
            SwitchEditStatus(False)
            Search()
        End If

    End Sub

    Private Sub lbkEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkEdit.LinkClicked
        If lbkEdit.Text = "Edit" Then
            SwitchEditStatus(True)
            lbkAdd.Visible = False
            lbkEdit.Text = "Save"
            mblnNew = False
        ElseIf CheckInputValue(mblnNew) Then
            Dim lstQuerries As New List(Of String)
            lstQuerries.Add("Insert Into DATA1A_OIDs (ShortName, GDS, OffcId, TMC, Status, FstUser,OtaName) values ('" _
                            & cboShortName.Text & "','" & cboGDS.Text & "','" & txtCode.Text _
                            & "','" & IIf(chkTMC.Checked, True, False) & "','OK','" & pobjUser.UserName _
                            & "','" & txtOtaName.Text & "')")

            lstQuerries.Add("Update DATA1A_OIDs set Status='XX',LstUpdate=getdate(),LstUser='" _
                            & pobjUser.UserName & "' where RecId=" & dgrOffcID.CurrentRow.Cells("RecId").Value)

            If pobjSql.UpdateListOfQuerries(lstQuerries) Then
                lbkEdit.Text = "Edit"
                lbkAdd.Visible = True
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

        lstQuerries.Add("Update DATA1A_OIDs set Status='XX',LstUpdate=getdate(),LstUser='" _
                        & pobjUser.UserName & "' where RecId=" & dgrOffcID.CurrentRow.Cells("RecId").Value)

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unale to Delete OffcId")
            Exit Sub
        End If
    End Sub
End Class