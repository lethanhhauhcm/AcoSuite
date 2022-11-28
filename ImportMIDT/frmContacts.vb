Public Class frmContacts
    Private mstrShortName As String
    Private mstrAccessRole As String
#Region "Ham"
    Public Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strMsQuerry As String

        strMsQuerry = "Select *, isnull(substring(DOB,7,4)+'/'+substring(DOB,5,2)+substring(DOB,1,4),'') as DateOfBirth" _
                        & " from DATA1A_Contacts where Status<>'XX'" ' and CustShortName='" & cboShortName.Text & "'"

        AddEqualConditionCombo(strMsQuerry, cboShortName, "CustShortName")
        AddEqualConditionCombo(strMsQuerry, cboGender)
        AddEqualConditionCombo(strMsQuerry, cboDecisionRole)
        AddEqualConditionCombo(strMsQuerry, cboAttitude)
        AddEqualConditionCombo(strMsQuerry, cboLocationName)
        AddEqualConditionCombo(strMsQuerry, cboPriority)
        Select Case chkPendingSECO.CheckState
            Case CheckState.Checked
                strMsQuerry = strMsQuerry & " and substring(SecoId,1,5)='SECO '"
            Case CheckState.Unchecked
                strMsQuerry = strMsQuerry & " and substring(SecoId,1,5)<>'SECO '"
        End Select
        If cboOffcId.Text <> "" Then
            strMsQuerry = strMsQuerry & " and ContactId in (Select ContactId from DATA1A_SignIn1As" _
                & " where Status<>'XX' and OffcId='" & cboOffcId.Text & "')"
        End If
        If txtSignIn.Text <> "" Then
            strMsQuerry = strMsQuerry & " and ContactId in (Select ContactId from DATA1A_SignIn1As" _
                & " where Status<>'XX' and SignIn='" & txtSignIn.Text & "')"
        End If
        strMsQuerry = strMsQuerry & " order by FullNameGB"
        daConditions = New SqlClient.SqlDataAdapter(strMsQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "DATA1A_Contacts")
        dgrContact.DataSource = dsConditions.Tables("DATA1A_Contacts")
        dgrContact.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgrContact.Columns("DOB").Visible = False
        dgrContact.Columns("Comments").Visible = False
        dgrContact.AutoResizeColumns()
        dsConditions.Dispose()
        daConditions.Dispose()
        Return True
    End Function

#End Region
#Region "Su kien"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Public Sub New(strShortName As String, strAccessRole As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrShortName = strShortName
        mstrAccessRole = strAccessRole
        Me.Text = Me.Text & "-" & strShortName
        Dim strOffcQuerry As String
        Dim strLocationQuerry As String

        Select Case strAccessRole

        End Select

        strOffcQuerry = "Select OffcId as value from DATA1A_OIDs where status<>'XX' and GDS='1A'"
        strLocationQuerry = "Select LocationName as value from DATA1A_Locations where status<>'XX'"

        If strAccessRole = "SECO" Then
            btnNew.Visible = False
            btnEdit.Visible = False
            btnExpire.Visible = False
            chkPendingSECO.CheckState = CheckState.Checked
            lbkDeleteErroredRecord.Visible = False
        Else
            strOffcQuerry = strOffcQuerry & " and ShortName='" & strShortName & "' order by OffcId"
            strLocationQuerry = strLocationQuerry & "and ShortName='" & strShortName & "' order by LocationName"
            chkPendingSECO.CheckState = CheckState.Indeterminate
        End If

        pobjSql.LoadCombo(cboOffcId, strOffcQuerry)
        pobjSql.LoadCombo(cboLocationName, strLocationQuerry)
        cboOffcId.SelectedIndex = -1
        cboLocationName.SelectedIndex = -1

    End Sub

    Private Sub frmContactList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadCombo(cboShortName, "Select distinct ShortName as Value from DATA1A_Customers where Status<>'XX'")
        cboShortName.Text = mstrShortName
        Search()
    End Sub

    Private Function Clear() As Boolean
        cboGender.SelectedIndex = -1
        cboOffcId.SelectedIndex = -1
        cboLocationName.SelectedIndex = -1
        cboDecisionRole.SelectedIndex = -1
        cboAttitude.SelectedIndex = -1
        If mstrAccessRole = "SECO" Then
            chkPendingSECO.CheckState = CheckState.Checked
        Else
            chkPendingSECO.CheckState = CheckState.Indeterminate
        End If

        cboShortName.SelectedIndex = -1
        txtSignIn.Text = ""
        Return True
    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmEdit As New frmContactEdit(, mstrShortName)
        frmEdit.ShowDialog()
        Search()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim frmEdit As New frmContactEdit(dgrContact.CurrentRow)
        If frmEdit.ShowDialog = DialogResult.OK Then
            Search()
        End If

    End Sub
#End Region

    Private Sub lbkSign1A_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSignIn1A.LinkClicked
        Dim frmSign1A As New frmSignIn1A(dgrContact.CurrentRow)
        frmSign1A.ShowDialog()
        Dim a As New List(Of String)

    End Sub

    Private Sub lblGdsSkills_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGdsSkills.LinkClicked
        Dim frmGdsSkill As New frmGdsSkills(dgrContact.CurrentRow)
        frmGdsSkill.ShowDialog()
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lbkOfficeIDs_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub cboShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged
        Search()
    End Sub


    Private Sub btnExpire_Click(sender As Object, e As EventArgs) Handles btnExpire.Click

    End Sub

    Private Sub lbkDeleteErroredRecord_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDeleteErroredRecord.LinkClicked
        Dim lstQuerries As New List(Of String)
        Dim tblCurrentProduct As New DataTable


        If MsgBox("Deleted records will not be restored. Continue?") <> MsgBoxResult.Ok Then
            Exit Sub
        End If
        tblCurrentProduct = pobjSql.GetDataTable("Select * from Data1a_ProductRights where Status<>'XX'" _
                                                 & " And ValidTo>Getdate() And ContactId=" _
                                                 & dgrContact.CurrentRow.Cells("ContactId").Value)
        If tblCurrentProduct.Rows.Count > 0 Then
            Dim frmShow As New frmShowTableContent(tblCurrentProduct, "Must update Product right" _
                                                   & "before deleting Contact")
            frmShow.ShowDialog()
            Exit Sub
        End If
        lstQuerries.Add("Update DATA1A_Contacts set Status='XX',LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                        & " 'where Status='OK' and ContactId=" _
                        & dgrContact.CurrentRow.Cells("ContactId").Value)
        lstQuerries.Add("Update DATA1A_SignIn1As set Status='XX' ,LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                        & "' where Status='OK' and ContactId=" _
                        & dgrContact.CurrentRow.Cells("ContactId").Value)
        lstQuerries.Add("Update DATA1A_GdsSkills set Status='XX' ,LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                        & "' where Status='OK' and ContactId=" _
                        & dgrContact.CurrentRow.Cells("ContactId").Value)
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unable to delete ErroredRecord!")
        End If
    End Sub

    Private Sub lbkRequestSECO_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkRequestSECO.LinkClicked

        With dgrContact.CurrentRow
            If (.Cells("BusinessEmail").Value & .Cells("BusinessEmail").Value) = "" Then
                MsgBox("Need to update Contact Email")
                Exit Sub
            ElseIf (.Cells("Mobile").Value) = "" Then
                MsgBox("Need to update Contact Mobile")
                Exit Sub
            ElseIf (.Cells("DOB").Value) = "" Then
                MsgBox("Need to update Contact DOB")
                Exit Sub
            End If
        End With

        Dim frmSecoInfo As New frmSecoInfo(dgrContact.CurrentRow, mstrAccessRole)
        If frmSecoInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
            Search()
        End If
    End Sub

    Private Sub dgrContact_SelectionChanged(sender As Object, e As EventArgs) Handles dgrContact.SelectionChanged
        If dgrContact.RowCount > 0 Then
            txtComments.Text = dgrContact.CurrentRow.Cells("Comments").Value
            lbkRequestSECO.Visible = (dgrContact.CurrentRow.Cells("SECOID").Value = "" _
                                      Or dgrContact.CurrentRow.Cells("SECOID").Value.ToString.StartsWith("SECO "))
        End If

        llbChangeCustomer.Enabled = True  '^_^20221102 add by 7643
    End Sub

    Private Sub lbkSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSearch.LinkClicked
        Search()
    End Sub

    Private Sub lbkClear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkClear.LinkClicked
        Clear()
    End Sub

    Private Sub llbChangeCustomer_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbChangeCustomer.LinkClicked
        '^_^20221101 add by 7643 -b-
        Dim mChangeCust As New frmChangeCustomer

        mChangeCust.FOriShortName = dgrContact.CurrentRow.Cells("CustShortName").Value
        mChangeCust.FRecID = dgrContact.CurrentRow.Cells("RecID").Value
        mChangeCust.FContactId = dgrContact.CurrentRow.Cells("ContactId").Value
        If mChangeCust.ShowDialog() = DialogResult.OK Then Search()
        '^_^20221101 add by 7643 -e-
    End Sub

    Private Sub dgrContact_DataSourceChanged(sender As Object, e As EventArgs) Handles dgrContact.DataSourceChanged
        If dgrContact.Rows.Count = 0 Then llbChangeCustomer.Enabled = False  '^_^20221101 add by 7643
    End Sub
End Class