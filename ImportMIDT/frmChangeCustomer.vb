'^_^20221101 add by 7643
Public Class frmChangeCustomer
    Public FOriShortName As String
    Public FRecID, FContactId As Integer
    Private Sub frmChangeCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mSQL As String

        mSQL = "select ShortName value from DATA1A_Customers where Status='OK' and Region='" & pobjUser.Region & "' and ShortName<>'" & FOriShortName & "' order by ShortName"
        pobjSql.LoadCombo(cboShortName, mSQL)
    End Sub

    Private Sub cboShortName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboShortName.Validating, cboLocationName.Validating, cboOffcId.Validating
        sender.SelectedIndex = sender.FindString(sender.Text)
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim mLstStr As New List(Of String)
        Dim i As Integer

        If MsgBox("Are you sure change customer?", vbYesNo) = vbNo Then Exit Sub

        mLstStr.Add("insert into DATA1A_Contacts(ContactId,FullNameGB,FullNameVN,Gender,CustShortName,Position,DOB,SecoID,FaceBookAccount,RewardsAccount,BusinessEmail,PersonalEmail," &
                    "   Mobile,BankAccountNbr,BankName,BankBranch,AccountOwner,NationalID,TaxCode,LocationName,DecisionRole,Attitude,Priority,Booker,CustomerMainContact," &
                    "   LocationMainContact,Comments,Status,FstUser,LstUser,FstUpdate) " &
                    "select ContactId,FullNameGB,FullNameVN,Gender,'" & cboShortName.Text & "',Position,DOB,SecoID,FaceBookAccount,RewardsAccount,BusinessEmail,PersonalEmail," &
                    "   Mobile,BankAccountNbr,BankName,BankBranch,AccountOwner,NationalID,TaxCode,'" & cboLocationName.Text & "',DecisionRole,Attitude,Priority,Booker," &
                    "       CustomerMainContact," &
                    "   LocationMainContact,Comments,Status,FstUser,'" & pobjUser.UserName & "',FstUpdate " &
                    "from DATA1A_Contacts where RecID=" & FRecID)
        mLstStr.Add(ChangeStatus_ByID("DATA1A_Contacts", "XX", FRecID))

        mLstStr.Add(ChangeStatus_ByDK("DATA1A_SignIn1As", "XX", "ContactId=" & FContactId))
        For i = 0 To dgvSignIn.Rows.Count - 1
            mLstStr.Add("insert into DATA1A_SignIn1As(ContactId,OffcId,SignIn,Status,FstUser) " &
                        "values(" & FContactId & ",'" & dgvSignIn.Rows(i).Cells("OffcId").Value & "','" & dgvSignIn.Rows(i).Cells("SignIn").Value & "','OK'," &
                        "   '" & pobjUser.UserName & "')")
        Next

        pobjSql.UpdateListOfQuerries(mLstStr)
        MsgBox("Please change Reward Data of Contact " & FContactId & "!")

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Function CheckInputValue(blnNew As Boolean) As Boolean
        Dim tblExistingSign As DataTable
        Dim blnDuplicate As Boolean

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

    Private Sub llbAddGrid_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbAddGrid.LinkClicked
        Dim i As Integer

        If cboOffcId.Text = "" Then
            MsgBox("Please select OffcId!")
        ElseIf txtSignIn.Text = "" Then
            MsgBox("Please enter SignIn!")
        ElseIf CheckInputValue(True) Then

            For i = 0 To dgvSignIn.Rows.Count - 1
                If dgvSignIn.Rows(i).Cells("OffcId").Value = cboOffcId.Text And dgvSignIn.Rows(i).Cells("SignIn").Value = txtSignIn.Text Then
                    MsgBox("SignIn has added!")
                    Exit Sub
                End If
            Next
            dgvSignIn.Rows.Add(cboOffcId.Text, txtSignIn.Text)
        End If
    End Sub

    Private Sub llbDeleteGrid_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDeleteGrid.LinkClicked
        dgvSignIn.Rows.Remove(dgvSignIn.CurrentRow)
    End Sub

    Private Sub llbClearGrid_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbClearGrid.LinkClicked
        dgvSignIn.Rows.Clear()
    End Sub

    Private Sub llbState()
        If dgvSignIn.Rows.Count > 0 Then
            llbDeleteGrid.Enabled = True
            llbClearGrid.Enabled = True
        Else
            llbDeleteGrid.Enabled = False
            llbClearGrid.Enabled = False
        End If
    End Sub

    Private Sub dgvSignIn_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvSignIn.RowsAdded
        llbState()
    End Sub

    Private Sub dgvSignIn_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvSignIn.RowsRemoved
        llbState()
    End Sub

    Private Sub cboShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged
        Dim mSQL As String

        cboLocationName.ResetText()
        mSQL = "Select LocationName as Value from DATA1A_Locations where status<>'XX' and ShortName='" & cboShortName.SelectedItem("Value") & "' order by LocationName"
        pobjSql.LoadCombo(cboLocationName, mSQL)

        cboOffcId.ResetText()
        mSQL = "Select OffcId as Value from DATA1A_OIDs where Status<>'XX' and GDS='1A' and ShortName='" & cboShortName.SelectedItem("Value") & "'"
        pobjSql.LoadCombo(cboOffcId, mSQL)
    End Sub
End Class