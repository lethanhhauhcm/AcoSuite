<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContactEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFullNameVN = New System.Windows.Forms.TextBox()
        Me.txtFullNameGB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtShortName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboLocationName = New System.Windows.Forms.ComboBox()
        Me.cboAttitude = New System.Windows.Forms.ComboBox()
        Me.cboDecisionRole = New System.Windows.Forms.ComboBox()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSecoID = New System.Windows.Forms.TextBox()
        Me.txtRewardsAccount = New System.Windows.Forms.TextBox()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFaceBookAccount = New System.Windows.Forms.TextBox()
        Me.txtPersonalEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBusinessEmail = New System.Windows.Forms.TextBox()
        Me.txtBankAccountNbr = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.txtAccountOwner = New System.Windows.Forms.TextBox()
        Me.chkCustomerMainContact = New System.Windows.Forms.CheckBox()
        Me.chkLocationMainContact = New System.Windows.Forms.CheckBox()
        Me.cboPosition = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkBooker = New System.Windows.Forms.CheckBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.btnGetFromRewards = New System.Windows.Forms.Button()
        Me.txtBankBranch = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTaxCode = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNationalId = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkReceiveINV = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtRecId
        '
        Me.txtRecId.Location = New System.Drawing.Point(576, 12)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.ReadOnly = True
        Me.txtRecId.Size = New System.Drawing.Size(120, 20)
        Me.txtRecId.TabIndex = 156
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(534, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 157
        Me.Label10.Text = "RecId"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 155
        Me.Label9.Text = "FullNameVN"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 287)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "LocationName"
        '
        'txtFullNameVN
        '
        Me.txtFullNameVN.Location = New System.Drawing.Point(156, 63)
        Me.txtFullNameVN.Name = "txtFullNameVN"
        Me.txtFullNameVN.Size = New System.Drawing.Size(421, 20)
        Me.txtFullNameVN.TabIndex = 2
        '
        'txtFullNameGB
        '
        Me.txtFullNameGB.Location = New System.Drawing.Point(156, 38)
        Me.txtFullNameGB.Name = "txtFullNameGB"
        Me.txtFullNameGB.Size = New System.Drawing.Size(421, 20)
        Me.txtFullNameGB.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "FullNameGB"
        '
        'txtShortName
        '
        Me.txtShortName.Enabled = False
        Me.txtShortName.Location = New System.Drawing.Point(156, 12)
        Me.txtShortName.MaxLength = 8
        Me.txtShortName.Name = "txtShortName"
        Me.txtShortName.Size = New System.Drawing.Size(120, 20)
        Me.txtShortName.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(656, 279)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 152
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(467, 358)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 151
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "ShortName"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(6, 359)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(684, 126)
        Me.txtComments.TabIndex = 24
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(235, 491)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 20)
        Me.btnSave.TabIndex = 25
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(397, 491)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 20)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboLocationName
        '
        Me.cboLocationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationName.FormattingEnabled = True
        Me.cboLocationName.Location = New System.Drawing.Point(156, 279)
        Me.cboLocationName.Name = "cboLocationName"
        Me.cboLocationName.Size = New System.Drawing.Size(267, 21)
        Me.cboLocationName.TabIndex = 21
        '
        'cboAttitude
        '
        Me.cboAttitude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttitude.FormattingEnabled = True
        Me.cboAttitude.Items.AddRange(New Object() {"Supporter", "Neutral", "Hater"})
        Me.cboAttitude.Location = New System.Drawing.Point(261, 306)
        Me.cboAttitude.Name = "cboAttitude"
        Me.cboAttitude.Size = New System.Drawing.Size(87, 21)
        Me.cboAttitude.TabIndex = 23
        '
        'cboDecisionRole
        '
        Me.cboDecisionRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDecisionRole.FormattingEnabled = True
        Me.cboDecisionRole.Items.AddRange(New Object() {"Decision Maker", "Influencer", "Others"})
        Me.cboDecisionRole.Location = New System.Drawing.Point(156, 306)
        Me.cboDecisionRole.Name = "cboDecisionRole"
        Me.cboDecisionRole.Size = New System.Drawing.Size(87, 21)
        Me.cboDecisionRole.TabIndex = 22
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Items.AddRange(New Object() {"F", "M"})
        Me.cboGender.Location = New System.Drawing.Point(156, 89)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(87, 21)
        Me.cboGender.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 313)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "DecisionRole/Attitude"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Gender"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(278, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 167
        Me.Label4.Text = "DOB (DD/MM/YYYY)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 13)
        Me.Label11.TabIndex = 169
        Me.Label11.Text = "SecoID/RewardsAccount"
        '
        'txtSecoID
        '
        Me.txtSecoID.Location = New System.Drawing.Point(156, 144)
        Me.txtSecoID.Name = "txtSecoID"
        Me.txtSecoID.Size = New System.Drawing.Size(267, 20)
        Me.txtSecoID.TabIndex = 11
        '
        'txtRewardsAccount
        '
        Me.txtRewardsAccount.Location = New System.Drawing.Point(429, 144)
        Me.txtRewardsAccount.Name = "txtRewardsAccount"
        Me.txtRewardsAccount.Size = New System.Drawing.Size(267, 20)
        Me.txtRewardsAccount.TabIndex = 12
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(429, 173)
        Me.txtMobile.MaxLength = 16
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(267, 20)
        Me.txtMobile.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 13)
        Me.Label12.TabIndex = 172
        Me.Label12.Text = "FaceBook/Mobile"
        '
        'txtFaceBookAccount
        '
        Me.txtFaceBookAccount.Location = New System.Drawing.Point(156, 173)
        Me.txtFaceBookAccount.Name = "txtFaceBookAccount"
        Me.txtFaceBookAccount.Size = New System.Drawing.Size(267, 20)
        Me.txtFaceBookAccount.TabIndex = 13
        '
        'txtPersonalEmail
        '
        Me.txtPersonalEmail.Location = New System.Drawing.Point(429, 199)
        Me.txtPersonalEmail.Name = "txtPersonalEmail"
        Me.txtPersonalEmail.Size = New System.Drawing.Size(267, 20)
        Me.txtPersonalEmail.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 202)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 13)
        Me.Label13.TabIndex = 175
        Me.Label13.Text = "Business/PersonalEmails"
        '
        'txtBusinessEmail
        '
        Me.txtBusinessEmail.Location = New System.Drawing.Point(156, 199)
        Me.txtBusinessEmail.Name = "txtBusinessEmail"
        Me.txtBusinessEmail.Size = New System.Drawing.Size(267, 20)
        Me.txtBusinessEmail.TabIndex = 15
        '
        'txtBankAccountNbr
        '
        Me.txtBankAccountNbr.Location = New System.Drawing.Point(156, 253)
        Me.txtBankAccountNbr.Name = "txtBankAccountNbr"
        Me.txtBankAccountNbr.Size = New System.Drawing.Size(148, 20)
        Me.txtBankAccountNbr.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 228)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 13)
        Me.Label14.TabIndex = 178
        Me.Label14.Text = "BankName/BranchName"
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(156, 225)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(267, 20)
        Me.txtBankName.TabIndex = 17
        '
        'txtAccountOwner
        '
        Me.txtAccountOwner.Location = New System.Drawing.Point(429, 253)
        Me.txtAccountOwner.Name = "txtAccountOwner"
        Me.txtAccountOwner.Size = New System.Drawing.Size(270, 20)
        Me.txtAccountOwner.TabIndex = 20
        '
        'chkCustomerMainContact
        '
        Me.chkCustomerMainContact.AutoSize = True
        Me.chkCustomerMainContact.Location = New System.Drawing.Point(429, 116)
        Me.chkCustomerMainContact.Name = "chkCustomerMainContact"
        Me.chkCustomerMainContact.Size = New System.Drawing.Size(130, 17)
        Me.chkCustomerMainContact.TabIndex = 9
        Me.chkCustomerMainContact.Text = "CustomerMainContact"
        Me.chkCustomerMainContact.UseVisualStyleBackColor = True
        '
        'chkLocationMainContact
        '
        Me.chkLocationMainContact.AutoSize = True
        Me.chkLocationMainContact.Location = New System.Drawing.Point(576, 116)
        Me.chkLocationMainContact.Name = "chkLocationMainContact"
        Me.chkLocationMainContact.Size = New System.Drawing.Size(127, 17)
        Me.chkLocationMainContact.TabIndex = 10
        Me.chkLocationMainContact.Text = "LocationMainContact"
        Me.chkLocationMainContact.UseVisualStyleBackColor = True
        '
        'cboPosition
        '
        Me.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPosition.FormattingEnabled = True
        Me.cboPosition.Items.AddRange(New Object() {"Deputy Director", "Director", "Manager", "Other", "Sales", "Ticketing Manager", "Travel Consultant"})
        Me.cboPosition.Location = New System.Drawing.Point(156, 116)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(267, 21)
        Me.cboPosition.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 184
        Me.Label15.Text = "Position"
        '
        'chkBooker
        '
        Me.chkBooker.AutoSize = True
        Me.chkBooker.Checked = True
        Me.chkBooker.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBooker.Location = New System.Drawing.Point(576, 93)
        Me.chkBooker.Name = "chkBooker"
        Me.chkBooker.Size = New System.Drawing.Size(60, 17)
        Me.chkBooker.TabIndex = 7
        Me.chkBooker.Text = "Booker"
        Me.chkBooker.UseVisualStyleBackColor = True
        '
        'cboDay
        '
        Me.cboDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(429, 89)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(35, 21)
        Me.cboDay.TabIndex = 4
        '
        'cboMonth
        '
        Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(465, 90)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(35, 21)
        Me.cboMonth.TabIndex = 5
        '
        'cboYear
        '
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"1940", "1941", "1942", "1943", "1944", "1945", "1946", "1947", "1948", "1949", "1950", "1951", "1952", "1953", "1954", "1955", "1956", "1957", "1958", "1959", "1960", "1961", "1962", "1963", "1964", "1965", "1966", "1967", "1968", "1969", "1970", "1971", "1972", "1973", "1974", "1975", "1976", "1977", "1978", "1979", "1980", "1981", "1982", "1983", "1984", "1985", "1986", "1987", "1988", "1989", "1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997", "1998", "1999", "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010"})
        Me.cboYear.Location = New System.Drawing.Point(501, 89)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(60, 21)
        Me.cboYear.TabIndex = 6
        '
        'btnGetFromRewards
        '
        Me.btnGetFromRewards.Location = New System.Drawing.Point(570, 491)
        Me.btnGetFromRewards.Name = "btnGetFromRewards"
        Me.btnGetFromRewards.Size = New System.Drawing.Size(103, 20)
        Me.btnGetFromRewards.TabIndex = 27
        Me.btnGetFromRewards.Text = "GetFromRewards"
        Me.btnGetFromRewards.UseVisualStyleBackColor = True
        '
        'txtBankBranch
        '
        Me.txtBankBranch.Location = New System.Drawing.Point(429, 225)
        Me.txtBankBranch.Name = "txtBankBranch"
        Me.txtBankBranch.Size = New System.Drawing.Size(267, 20)
        Me.txtBankBranch.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 260)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 13)
        Me.Label16.TabIndex = 191
        Me.Label16.Text = "BankAccount/Owner"
        '
        'cboPriority
        '
        Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cboPriority.Location = New System.Drawing.Point(472, 305)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(87, 21)
        Me.cboPriority.TabIndex = 192
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(426, 313)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 193
        Me.Label17.Text = "Priority"
        '
        'txtTaxCode
        '
        Me.txtTaxCode.Location = New System.Drawing.Point(303, 333)
        Me.txtTaxCode.Name = "txtTaxCode"
        Me.txtTaxCode.Size = New System.Drawing.Size(120, 20)
        Me.txtTaxCode.TabIndex = 195
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(285, 336)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 13)
        Me.Label18.TabIndex = 197
        Me.Label18.Text = "/"
        '
        'txtNationalId
        '
        Me.txtNationalId.Location = New System.Drawing.Point(156, 333)
        Me.txtNationalId.Name = "txtNationalId"
        Me.txtNationalId.Size = New System.Drawing.Size(120, 20)
        Me.txtNationalId.TabIndex = 194
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 336)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 13)
        Me.Label19.TabIndex = 196
        Me.Label19.Text = "NationalID/TaxCode"
        '
        'chkReceiveINV
        '
        Me.chkReceiveINV.AutoSize = True
        Me.chkReceiveINV.Location = New System.Drawing.Point(702, 201)
        Me.chkReceiveINV.Name = "chkReceiveINV"
        Me.chkReceiveINV.Size = New System.Drawing.Size(84, 17)
        Me.chkReceiveINV.TabIndex = 198
        Me.chkReceiveINV.Text = "ReceiveINV"
        Me.chkReceiveINV.UseVisualStyleBackColor = True
        '
        'frmContactEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 523)
        Me.Controls.Add(Me.chkReceiveINV)
        Me.Controls.Add(Me.txtTaxCode)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtNationalId)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboPriority)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtBankBranch)
        Me.Controls.Add(Me.btnGetFromRewards)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.chkBooker)
        Me.Controls.Add(Me.cboPosition)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.chkLocationMainContact)
        Me.Controls.Add(Me.chkCustomerMainContact)
        Me.Controls.Add(Me.txtAccountOwner)
        Me.Controls.Add(Me.txtBankAccountNbr)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtBankName)
        Me.Controls.Add(Me.txtPersonalEmail)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtBusinessEmail)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtFaceBookAccount)
        Me.Controls.Add(Me.txtRewardsAccount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSecoID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboAttitude)
        Me.Controls.Add(Me.cboDecisionRole)
        Me.Controls.Add(Me.cboGender)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboLocationName)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFullNameVN)
        Me.Controls.Add(Me.txtFullNameGB)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtShortName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmContactEdit"
        Me.Text = "frmContactEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFullNameVN As System.Windows.Forms.TextBox
    Friend WithEvents txtFullNameGB As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtShortName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboLocationName As System.Windows.Forms.ComboBox
    Friend WithEvents cboAttitude As System.Windows.Forms.ComboBox
    Friend WithEvents cboDecisionRole As System.Windows.Forms.ComboBox
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSecoID As System.Windows.Forms.TextBox
    Friend WithEvents txtRewardsAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFaceBookAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtPersonalEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBusinessEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountNbr As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountOwner As System.Windows.Forms.TextBox
    Friend WithEvents chkCustomerMainContact As System.Windows.Forms.CheckBox
    Friend WithEvents chkLocationMainContact As System.Windows.Forms.CheckBox
    Friend WithEvents cboPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkBooker As System.Windows.Forms.CheckBox
    Friend WithEvents cboDay As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetFromRewards As System.Windows.Forms.Button
    Friend WithEvents txtBankBranch As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTaxCode As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNationalId As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents chkReceiveINV As CheckBox
End Class
