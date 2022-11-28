<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContacts
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
        Me.lblGdsSkills = New System.Windows.Forms.LinkLabel()
        Me.lbkSignIn1A = New System.Windows.Forms.LinkLabel()
        Me.cboAttitude = New System.Windows.Forms.ComboBox()
        Me.cboDecisionRole = New System.Windows.Forms.ComboBox()
        Me.cboOffcId = New System.Windows.Forms.ComboBox()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgrContact = New System.Windows.Forms.DataGridView()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.cboLocationName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnExpire = New System.Windows.Forms.Button()
        Me.lbkDeleteErroredRecord = New System.Windows.Forms.LinkLabel()
        Me.lbkRequestSECO = New System.Windows.Forms.LinkLabel()
        Me.chkPendingSECO = New System.Windows.Forms.CheckBox()
        Me.lbkSearch = New System.Windows.Forms.LinkLabel()
        Me.lbkClear = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSignIn = New System.Windows.Forms.TextBox()
        Me.llbChangeCustomer = New System.Windows.Forms.LinkLabel()
        CType(Me.dgrContact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGdsSkills
        '
        Me.lblGdsSkills.AutoSize = True
        Me.lblGdsSkills.Location = New System.Drawing.Point(930, 573)
        Me.lblGdsSkills.Name = "lblGdsSkills"
        Me.lblGdsSkills.Size = New System.Drawing.Size(50, 13)
        Me.lblGdsSkills.TabIndex = 135
        Me.lblGdsSkills.TabStop = True
        Me.lblGdsSkills.Text = "GdsSkills"
        '
        'lbkSignIn1A
        '
        Me.lbkSignIn1A.AutoSize = True
        Me.lbkSignIn1A.Location = New System.Drawing.Point(930, 548)
        Me.lbkSignIn1A.Name = "lbkSignIn1A"
        Me.lbkSignIn1A.Size = New System.Drawing.Size(50, 13)
        Me.lbkSignIn1A.TabIndex = 134
        Me.lbkSignIn1A.TabStop = True
        Me.lbkSignIn1A.Text = "SignIn1A"
        '
        'cboAttitude
        '
        Me.cboAttitude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttitude.FormattingEnabled = True
        Me.cboAttitude.Items.AddRange(New Object() {"Supporter", "Neutral", "Hater"})
        Me.cboAttitude.Location = New System.Drawing.Point(549, 27)
        Me.cboAttitude.Name = "cboAttitude"
        Me.cboAttitude.Size = New System.Drawing.Size(87, 21)
        Me.cboAttitude.TabIndex = 4
        '
        'cboDecisionRole
        '
        Me.cboDecisionRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDecisionRole.FormattingEnabled = True
        Me.cboDecisionRole.Items.AddRange(New Object() {"Decision Maker", "Influencer", "Others"})
        Me.cboDecisionRole.Location = New System.Drawing.Point(456, 27)
        Me.cboDecisionRole.Name = "cboDecisionRole"
        Me.cboDecisionRole.Size = New System.Drawing.Size(87, 21)
        Me.cboDecisionRole.TabIndex = 3
        '
        'cboOffcId
        '
        Me.cboOffcId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOffcId.FormattingEnabled = True
        Me.cboOffcId.Location = New System.Drawing.Point(99, 27)
        Me.cboOffcId.Name = "cboOffcId"
        Me.cboOffcId.Size = New System.Drawing.Size(120, 21)
        Me.cboOffcId.TabIndex = 1
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Items.AddRange(New Object() {"F", "M"})
        Me.cboGender.Location = New System.Drawing.Point(3, 27)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(87, 21)
        Me.cboGender.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(453, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "DecisionRole"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(546, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Attitude"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Gender"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(96, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "OffcId1A"
        '
        'dgrContact
        '
        Me.dgrContact.AllowUserToAddRows = False
        Me.dgrContact.AllowUserToDeleteRows = False
        Me.dgrContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgrContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrContact.Location = New System.Drawing.Point(3, 57)
        Me.dgrContact.Name = "dgrContact"
        Me.dgrContact.ReadOnly = True
        Me.dgrContact.Size = New System.Drawing.Size(977, 419)
        Me.dgrContact.TabIndex = 9
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(391, 595)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(91, 20)
        Me.btnEdit.TabIndex = 6
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(264, 595)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(91, 20)
        Me.btnNew.TabIndex = 5
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(506, 595)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 20)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(3, 485)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(905, 104)
        Me.txtComments.TabIndex = 10
        '
        'cboLocationName
        '
        Me.cboLocationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationName.FormattingEnabled = True
        Me.cboLocationName.Location = New System.Drawing.Point(225, 27)
        Me.cboLocationName.Name = "cboLocationName"
        Me.cboLocationName.Size = New System.Drawing.Size(227, 21)
        Me.cboLocationName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Location"
        '
        'cboShortName
        '
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(859, 4)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(121, 21)
        Me.cboShortName.TabIndex = 140
        '
        'cboPriority
        '
        Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cboPriority.Location = New System.Drawing.Point(642, 27)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(42, 21)
        Me.cboPriority.TabIndex = 141
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(639, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 142
        Me.Label6.Text = "Priority"
        '
        'btnExpire
        '
        Me.btnExpire.Location = New System.Drawing.Point(125, 595)
        Me.btnExpire.Name = "btnExpire"
        Me.btnExpire.Size = New System.Drawing.Size(103, 20)
        Me.btnExpire.TabIndex = 143
        Me.btnExpire.Text = "Expire"
        Me.btnExpire.UseVisualStyleBackColor = True
        '
        'lbkDeleteErroredRecord
        '
        Me.lbkDeleteErroredRecord.AutoSize = True
        Me.lbkDeleteErroredRecord.Location = New System.Drawing.Point(616, 599)
        Me.lbkDeleteErroredRecord.Name = "lbkDeleteErroredRecord"
        Me.lbkDeleteErroredRecord.Size = New System.Drawing.Size(107, 13)
        Me.lbkDeleteErroredRecord.TabIndex = 144
        Me.lbkDeleteErroredRecord.TabStop = True
        Me.lbkDeleteErroredRecord.Text = "DeleteErroredRecord"
        '
        'lbkRequestSECO
        '
        Me.lbkRequestSECO.AutoSize = True
        Me.lbkRequestSECO.Location = New System.Drawing.Point(729, 599)
        Me.lbkRequestSECO.Name = "lbkRequestSECO"
        Me.lbkRequestSECO.Size = New System.Drawing.Size(76, 13)
        Me.lbkRequestSECO.TabIndex = 145
        Me.lbkRequestSECO.TabStop = True
        Me.lbkRequestSECO.Text = "RequestSECO"
        '
        'chkPendingSECO
        '
        Me.chkPendingSECO.AutoSize = True
        Me.chkPendingSECO.Checked = True
        Me.chkPendingSECO.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkPendingSECO.Location = New System.Drawing.Point(358, 6)
        Me.chkPendingSECO.Name = "chkPendingSECO"
        Me.chkPendingSECO.Size = New System.Drawing.Size(94, 17)
        Me.chkPendingSECO.TabIndex = 146
        Me.chkPendingSECO.Text = "PendingSECO"
        Me.chkPendingSECO.ThreeState = True
        Me.chkPendingSECO.UseVisualStyleBackColor = True
        '
        'lbkSearch
        '
        Me.lbkSearch.AutoSize = True
        Me.lbkSearch.Location = New System.Drawing.Point(856, 35)
        Me.lbkSearch.Name = "lbkSearch"
        Me.lbkSearch.Size = New System.Drawing.Size(41, 13)
        Me.lbkSearch.TabIndex = 147
        Me.lbkSearch.TabStop = True
        Me.lbkSearch.Text = "Search"
        '
        'lbkClear
        '
        Me.lbkClear.AutoSize = True
        Me.lbkClear.Location = New System.Drawing.Point(921, 35)
        Me.lbkClear.Name = "lbkClear"
        Me.lbkClear.Size = New System.Drawing.Size(31, 13)
        Me.lbkClear.TabIndex = 148
        Me.lbkClear.TabStop = True
        Me.lbkClear.Text = "Clear"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(687, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "SignIn"
        '
        'txtSignIn
        '
        Me.txtSignIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSignIn.Location = New System.Drawing.Point(690, 28)
        Me.txtSignIn.MaxLength = 6
        Me.txtSignIn.Name = "txtSignIn"
        Me.txtSignIn.Size = New System.Drawing.Size(100, 20)
        Me.txtSignIn.TabIndex = 150
        '
        'llbChangeCustomer
        '
        Me.llbChangeCustomer.AutoSize = True
        Me.llbChangeCustomer.Location = New System.Drawing.Point(811, 599)
        Me.llbChangeCustomer.Name = "llbChangeCustomer"
        Me.llbChangeCustomer.Size = New System.Drawing.Size(88, 13)
        Me.llbChangeCustomer.TabIndex = 151
        Me.llbChangeCustomer.TabStop = True
        Me.llbChangeCustomer.Text = "ChangeCustomer"
        '
        'frmContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 623)
        Me.Controls.Add(Me.llbChangeCustomer)
        Me.Controls.Add(Me.txtSignIn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbkClear)
        Me.Controls.Add(Me.lbkSearch)
        Me.Controls.Add(Me.chkPendingSECO)
        Me.Controls.Add(Me.lbkRequestSECO)
        Me.Controls.Add(Me.lbkDeleteErroredRecord)
        Me.Controls.Add(Me.btnExpire)
        Me.Controls.Add(Me.cboPriority)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.cboLocationName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblGdsSkills)
        Me.Controls.Add(Me.lbkSignIn1A)
        Me.Controls.Add(Me.cboAttitude)
        Me.Controls.Add(Me.cboDecisionRole)
        Me.Controls.Add(Me.cboOffcId)
        Me.Controls.Add(Me.cboGender)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgrContact)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtComments)
        Me.Name = "frmContacts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contacts"
        CType(Me.dgrContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGdsSkills As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkSignIn1A As System.Windows.Forms.LinkLabel
    Friend WithEvents cboAttitude As System.Windows.Forms.ComboBox
    Friend WithEvents cboDecisionRole As System.Windows.Forms.ComboBox
    Friend WithEvents cboOffcId As System.Windows.Forms.ComboBox
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgrContact As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents cboLocationName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboShortName As System.Windows.Forms.ComboBox
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnExpire As System.Windows.Forms.Button
    Friend WithEvents lbkDeleteErroredRecord As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkRequestSECO As System.Windows.Forms.LinkLabel
    Friend WithEvents chkPendingSECO As System.Windows.Forms.CheckBox
    Friend WithEvents lbkSearch As LinkLabel
    Friend WithEvents lbkClear As LinkLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSignIn As TextBox
    Friend WithEvents llbChangeCustomer As LinkLabel
End Class
