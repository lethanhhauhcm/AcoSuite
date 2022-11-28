Public Class frmContactEdit

    Private mintContactId As Integer

    Public Sub New(Optional drContact As DataGridViewRow = Nothing, Optional strShortName As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If strShortName <> "" Then
            pobjSql.LoadCombo(cboLocationName, "Select LocationName as Value from DATA1A_Locations where status<>'XX' and ShortName='" _
                          & strShortName & "' order by LocationName")
        End If

        If drContact Is Nothing Then
            txtShortName.Text = strShortName
            cboAttitude.SelectedIndex = 1
            cboDecisionRole.SelectedIndex = 2
            cboPriority.SelectedIndex = 0
        Else
            Dim strDateOfBirth As String = drContact.Cells("DOB").Value
            mintContactId = drContact.Cells("ContactId").Value
            pobjSql.LoadCombo(cboLocationName, "Select LocationName as Value from DATA1A_Locations where status<>'XX' and ShortName='" _
                          & drContact.Cells("CustShortName").Value & "' order by LocationName")
            cboLocationName.Text = drContact.Cells("LocationName").Value
            txtRecId.Text = drContact.Cells("RecId").Value
            txtShortName.Text = drContact.Cells("CustShortName").Value
            txtFullNameGB.Text = drContact.Cells("FullNameGB").Value
            txtFullNameVN.Text = drContact.Cells("FullNameVN").Value
            cboGender.Text = drContact.Cells("Gender").Value
            If strDateOfBirth <> "" Then
                cboDay.Text = Mid(strDateOfBirth, 7, 2)
                cboMonth.Text = Mid(strDateOfBirth, 5, 2)
                cboYear.Text = Mid(strDateOfBirth, 1, 4)
                cboYear.Enabled = False
                cboMonth.Enabled = False
                cboDay.Enabled = False
            End If
            cboPosition.Text = drContact.Cells("Position").Value
            cboPriority.Text = drContact.Cells("Priority").Value
            chkBooker.Checked = drContact.Cells("Booker").Value
            chkCustomerMainContact.Checked = drContact.Cells("CustomerMainContact").Value
            chkLocationMainContact.Checked = drContact.Cells("LocationMainContact").Value
            txtSecoID.Text = drContact.Cells("SecoId").Value
            txtFaceBookAccount.Text = drContact.Cells("FaceBookAccount").Value
            txtRewardsAccount.Text = drContact.Cells("RewardsAccount").Value
            txtBusinessEmail.Text = drContact.Cells("BusinessEmail").Value
            txtPersonalEmail.Text = drContact.Cells("PersonalEmail").Value
            txtMobile.Text = drContact.Cells("Mobile").Value
            txtBankName.Text = drContact.Cells("BankName").Value
            txtBankBranch.Text = drContact.Cells("BankBranch").Value
            txtBankAccountNbr.Text = drContact.Cells("BankAccountNbr").Value
            txtAccountOwner.Text = drContact.Cells("AccountOwner").Value
            cboLocationName.Text = drContact.Cells("LocationName").Value
            cboDecisionRole.Text = drContact.Cells("DecisionRole").Value
            cboAttitude.Text = drContact.Cells("Attitude").Value
            txtComments.Text = drContact.Cells("Comments").Value
            txtNationalId.Text = drContact.Cells("NationalId").Value
            txtTaxCode.Text = drContact.Cells("TaxCode").Value

            chkReceiveINV.Checked = drContact.Cells("ReceiveINV").Value  '^_^20221124 add by 7643

            txtShortName.Enabled = False
            txtFullNameGB.Enabled = False
            txtFullNameVN.Enabled = False

        End If
    End Sub

    Private Function CheckInputValues() As Boolean
        '^_^20220811 add by 7643 -b-
        Dim mDataTable As New DataTable,
            i As Integer,
            mShortName As String
        '^_^20220811 add by 7643 -e-
        If Not CheckFormatComboBox(cboPriority, True) Then
            Return False
        End If
        If Not CheckFormatTextBox(txtMobile, 14, True, 4) Then
            Return False
        End If

        If Not CheckFormatTextBox(txtFullNameGB, , , 3) Or Not CheckFormatTextBox(txtFullNameVN, , , 3) Then
            Return False
        End If

        If cboPriority.Text > 0 AndAlso cboDay.Text = "" Then
            MsgBox("DOB requires for Priority from 1")
            Return False
        End If
        If cboDay.Text <> "" Then
            Try
                DateSerial(cboYear.Text, cboMonth.Text, cboDay.Text)
            Catch ex As Exception
                MsgBox("Invalid DOB")
                Return False
            End Try
        End If

        If Not CheckFormatComboBox(cboGender, , 1) Or Not CheckFormatComboBox(cboPosition, , 1) _
            Or Not CheckFormatComboBox(cboLocationName, , 1) Or Not CheckFormatComboBox(cboDecisionRole, , 1) _
            Or Not CheckFormatComboBox(cboAttitude, , 1) Then
            Return False
        End If

        If Not CheckFormatTextBoxEmail(txtBusinessEmail, True) Or Not CheckFormatTextBoxEmail(txtPersonalEmail, True) Then
            Return False
        End If

        If txtNationalId.TextLength > 0 AndAlso Not CheckFormatTextBox(txtNationalId, 12, True, 9) Then
            Return False
        End If

        If txtTaxCode.TextLength > 0 AndAlso Not CheckFormatTextBox(txtTaxCode, 16, True, 6) Then
            Return False
        End If

        '^_^20220811 add by 7643 -b-
        If txtSecoID.Text <> "" Then
            mShortName = ""
            mDataTable = GetDataTable("Select distinct CustShortName " & vbLf &
                                      "from DATA1A_Contacts " & vbLf &
                                      "where Status='OK' and SecoID='" & txtSecoID.Text & "' and RecID<>'" & txtRecId.Text & "'",
                                      pobjSql.Connection)
            For i = 0 To mDataTable.Rows.Count - 1
                mShortName &= IIf(mShortName <> "", ",", "") & mDataTable.Rows(i)("CustShortName")
            Next

            If mShortName <> "" Then
                MsgBox(mShortName & " SecoID is duplicate!")
                Return False
            End If
        End If
        '^_^20220811 add by 7643 -e-

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerries As New List(Of String)
        txtBankAccountNbr.Text = Replace(txtBankAccountNbr.Text, " ", "")
        txtMobile.Text = Replace(txtMobile.Text, " ", "")
        If Not CheckInputValues() Then
            Exit Sub
        End If
        Dim strDOB As String = cboYear.Text & cboMonth.Text & cboDay.Text

        If txtRecId.Text = "" Then
            lstQuerries.Add("insert into DATA1A_Contacts (FullNameGB, FullNameVN, Gender, CustShortName" _
                        & ", Position, DOB, SecoID, FaceBookAccount, RewardsAccount, BusinessEmail, PersonalEmail" _
                        & ", Mobile, BankAccountNbr, BankName, BankBranch, AccountOwner, LocationName, DecisionRole, Attitude, Booker" _
                        & ", CustomerMainContact, LocationMainContact, Comments, Status,FstUser,ContactId" _
                        & ",Priority,NationalId,TaxCode,ReceiveINV) values ('" _  '^_^20221124 add ,ReceiveINV by 7643
                        & txtFullNameGB.Text & "',N'" & txtFullNameVN.Text & "','" & cboGender.Text _
                        & "','" & txtShortName.Text & "','" & cboPosition.Text & "','" & strDOB _
                        & "','" & txtSecoID.Text & "','" & txtFaceBookAccount.Text & "','" & txtRewardsAccount.Text _
                        & "','" & txtBusinessEmail.Text & "','" & txtPersonalEmail.Text & "','" & txtMobile.Text _
                        & "','" & txtBankAccountNbr.Text & "','" & txtBankName.Text & "','" & txtBankBranch.Text _
                        & "','" & txtAccountOwner.Text _
                        & "','" & cboLocationName.Text & "','" & cboDecisionRole.Text & "','" & cboAttitude.Text _
                        & "','" & chkBooker.Checked & "','" & chkCustomerMainContact.Checked & "','" & chkLocationMainContact.Checked _
                        & "','" & txtComments.Text & "','OK','" & pobjUser.UserName _
                        & "',(Select isnull(Max(ContactId),0)+1 from DATA1A_Contacts)," & cboPriority.Text _
                        & ",'" & txtNationalId.Text & "','" & txtTaxCode.Text & "','" & chkReceiveINV.Checked & "')")  '^_^20221124 add ,'" & chkReceiveINV.Checked & "' by 7643
        Else
            lstQuerries.Add("insert into DATA1A_Contacts (FullNameGB, FullNameVN, Gender, CustShortName" _
                        & ", Position, DOB, SecoID, FaceBookAccount, RewardsAccount, BusinessEmail, PersonalEmail" _
                        & ", Mobile, BankAccountNbr, BankName,BankBranch, AccountOwner, LocationName, DecisionRole, Attitude, Booker" _
                        & ", CustomerMainContact, LocationMainContact, Comments, Status,FstUser,ContactId" _
                        & ",Priority,NationalId,TaxCode,ReceiveINV) values ('" _  '^_^20221124 add ,ReceiveINV by 7643
                        & txtFullNameGB.Text & "',N'" & txtFullNameVN.Text & "','" & cboGender.Text _
                        & "','" & txtShortName.Text & "','" & cboPosition.Text & "','" & strDOB _
                        & "','" & txtSecoID.Text & "','" & txtFaceBookAccount.Text & "','" & txtRewardsAccount.Text _
                        & "','" & txtBusinessEmail.Text & "','" & txtPersonalEmail.Text & "','" & txtMobile.Text _
                        & "','" & txtBankAccountNbr.Text & "','" & txtBankName.Text & "','" & txtBankBranch.Text _
                        & "','" & txtAccountOwner.Text _
                        & "','" & cboLocationName.Text & "','" & cboDecisionRole.Text & "','" & cboAttitude.Text _
                        & "','" & chkBooker.Checked & "','" & chkCustomerMainContact.Checked & "','" & chkLocationMainContact.Checked _
                        & "',N'" & txtComments.Text & "','OK','" & pobjUser.UserName & "'," & mintContactId _
                        & "," & cboPriority.Text & ",'" & txtNationalId.Text & "','" & txtTaxCode.Text & "','" & chkReceiveINV.Checked & "')")  '^_^20221124 add ,'" & chkReceiveINV.Checked & "' by 7643
            lstQuerries.Add("Update DATA1A_Contacts set Status='XX', LstUpdate=getdate() where RecId=" & txtRecId.Text)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("Unable to update Contact")
            Exit Sub
        End If
    End Sub



    Private Sub btnGetFromRewards_Click(sender As Object, e As EventArgs) Handles btnGetFromRewards.Click
        Dim frmGetUser As New frmGetRewardsUser(txtShortName.Text)
        frmGetUser.ShowDialog()
        If frmGetUser.DialogResult = Windows.Forms.DialogResult.OK Then
            With frmGetUser.User
                txtFullNameGB.Text = .Cells("SIName").Value
                cboGender.Text = IIf(.Cells("Sex").Value = "NAM", "M", "F")
                If Not IsDBNull(.Cells("Birthday").Value) Then
                    cboDay.Text = CDate(.Cells("Birthday").Value).ToString("dd")
                    cboMonth.Text = CDate(.Cells("Birthday").Value).ToString("MM")
                    cboYear.Text = CDate(.Cells("Birthday").Value).ToString("yyyy")
                End If
                chkBooker.Checked = True
                txtPersonalEmail.Text = .Cells("Email").Value
                txtMobile.Text = .Cells("Mobile").Value
                cboPosition.Text = pobjSql.GetScalarAsString("Select VAL1 from DATA1A_MISC where cat='LOCATION' and Val='" & .Cells("Position").Value & "'")
            End With
            frmGetUser.Dispose()
        End If
    End Sub
End Class