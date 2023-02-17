<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCustomerEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtShortName = New System.Windows.Forms.TextBox()
        Me.cboAmadeusSize = New System.Windows.Forms.ComboBox()
        Me.cboMarketSize = New System.Windows.Forms.ComboBox()
        Me.cboAccountStatus = New System.Windows.Forms.ComboBox()
        Me.cboPIC = New System.Windows.Forms.ComboBox()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.txtAccountNameGB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAccountNameVN = New System.Windows.Forms.TextBox()
        Me.cboProvince = New System.Windows.Forms.ComboBox()
        Me.txtWeb = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grbAccountTypes = New System.Windows.Forms.GroupBox()
        Me.chkCorporation = New System.Windows.Forms.CheckBox()
        Me.cboAirlines = New System.Windows.Forms.CheckBox()
        Me.chkTourOperator = New System.Windows.Forms.CheckBox()
        Me.chkTravelAgency = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDataApiToken = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCustAddress = New System.Windows.Forms.TextBox()
        Me.lblCustAddress = New System.Windows.Forms.Label()
        Me.txtCustTaxCode = New System.Windows.Forms.TextBox()
        Me.lblCustTaxCode = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.chkPPD = New System.Windows.Forms.CheckBox()
        Me.grbAccountTypes.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(145, 392)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 20)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(307, 392)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 20)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtShortName
        '
        Me.txtShortName.Location = New System.Drawing.Point(139, 2)
        Me.txtShortName.MaxLength = 8
        Me.txtShortName.Name = "txtShortName"
        Me.txtShortName.Size = New System.Drawing.Size(120, 20)
        Me.txtShortName.TabIndex = 0
        '
        'cboAmadeusSize
        '
        Me.cboAmadeusSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAmadeusSize.FormattingEnabled = True
        Me.cboAmadeusSize.Items.AddRange(New Object() {"Large", "Medium", "Small", "Micro"})
        Me.cboAmadeusSize.Location = New System.Drawing.Point(260, 135)
        Me.cboAmadeusSize.Name = "cboAmadeusSize"
        Me.cboAmadeusSize.Size = New System.Drawing.Size(87, 21)
        Me.cboAmadeusSize.TabIndex = 8
        '
        'cboMarketSize
        '
        Me.cboMarketSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarketSize.FormattingEnabled = True
        Me.cboMarketSize.Items.AddRange(New Object() {"Large", "Medium", "Small", "Micro"})
        Me.cboMarketSize.Location = New System.Drawing.Point(139, 135)
        Me.cboMarketSize.Name = "cboMarketSize"
        Me.cboMarketSize.Size = New System.Drawing.Size(87, 21)
        Me.cboMarketSize.TabIndex = 7
        '
        'cboAccountStatus
        '
        Me.cboAccountStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountStatus.FormattingEnabled = True
        Me.cboAccountStatus.Items.AddRange(New Object() {"Lead", "Prospect", "Customer", "Lost", "Suspended"})
        Me.cboAccountStatus.Location = New System.Drawing.Point(260, 108)
        Me.cboAccountStatus.Name = "cboAccountStatus"
        Me.cboAccountStatus.Size = New System.Drawing.Size(87, 21)
        Me.cboAccountStatus.TabIndex = 6
        '
        'cboPIC
        '
        Me.cboPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPIC.FormattingEnabled = True
        Me.cboPIC.Location = New System.Drawing.Point(139, 108)
        Me.cboPIC.Name = "cboPIC"
        Me.cboPIC.Size = New System.Drawing.Size(120, 21)
        Me.cboPIC.TabIndex = 5
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Items.AddRange(New Object() {"South", "North"})
        Me.cboRegion.Location = New System.Drawing.Point(139, 79)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(87, 21)
        Me.cboRegion.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(656, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 123
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(470, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 122
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 13)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "MarketSize/AmadeusSize"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Region/Province"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "ShortName"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "PIC/AccountStatus"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(15, 292)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(545, 98)
        Me.txtComments.TabIndex = 10
        '
        'txtAccountNameGB
        '
        Me.txtAccountNameGB.Location = New System.Drawing.Point(139, 28)
        Me.txtAccountNameGB.Name = "txtAccountNameGB"
        Me.txtAccountNameGB.Size = New System.Drawing.Size(421, 20)
        Me.txtAccountNameGB.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "AccountNameGB"
        '
        'txtAccountNameVN
        '
        Me.txtAccountNameVN.Location = New System.Drawing.Point(139, 53)
        Me.txtAccountNameVN.Name = "txtAccountNameVN"
        Me.txtAccountNameVN.Size = New System.Drawing.Size(421, 20)
        Me.txtAccountNameVN.TabIndex = 2
        '
        'cboProvince
        '
        Me.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvince.FormattingEnabled = True
        Me.cboProvince.Location = New System.Drawing.Point(260, 79)
        Me.cboProvince.Name = "cboProvince"
        Me.cboProvince.Size = New System.Drawing.Size(300, 21)
        Me.cboProvince.TabIndex = 4
        '
        'txtWeb
        '
        Me.txtWeb.Location = New System.Drawing.Point(139, 162)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Size = New System.Drawing.Size(421, 20)
        Me.txtWeb.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Web"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "AccountNameVN"
        '
        'txtRecId
        '
        Me.txtRecId.Location = New System.Drawing.Point(440, 2)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.ReadOnly = True
        Me.txtRecId.Size = New System.Drawing.Size(120, 20)
        Me.txtRecId.TabIndex = 131
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(398, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "RecId"
        '
        'grbAccountTypes
        '
        Me.grbAccountTypes.Controls.Add(Me.chkCorporation)
        Me.grbAccountTypes.Controls.Add(Me.cboAirlines)
        Me.grbAccountTypes.Controls.Add(Me.chkTourOperator)
        Me.grbAccountTypes.Controls.Add(Me.chkTravelAgency)
        Me.grbAccountTypes.Location = New System.Drawing.Point(566, 2)
        Me.grbAccountTypes.Name = "grbAccountTypes"
        Me.grbAccountTypes.Size = New System.Drawing.Size(116, 145)
        Me.grbAccountTypes.TabIndex = 133
        Me.grbAccountTypes.TabStop = False
        Me.grbAccountTypes.Text = "AccountTypes"
        '
        'chkCorporation
        '
        Me.chkCorporation.AutoSize = True
        Me.chkCorporation.Location = New System.Drawing.Point(3, 81)
        Me.chkCorporation.Name = "chkCorporation"
        Me.chkCorporation.Size = New System.Drawing.Size(80, 17)
        Me.chkCorporation.TabIndex = 4
        Me.chkCorporation.Text = "Corporation"
        Me.chkCorporation.UseVisualStyleBackColor = True
        '
        'cboAirlines
        '
        Me.cboAirlines.AutoSize = True
        Me.cboAirlines.Location = New System.Drawing.Point(3, 62)
        Me.cboAirlines.Name = "cboAirlines"
        Me.cboAirlines.Size = New System.Drawing.Size(59, 17)
        Me.cboAirlines.TabIndex = 2
        Me.cboAirlines.Text = "Airlines"
        Me.cboAirlines.UseVisualStyleBackColor = True
        '
        'chkTourOperator
        '
        Me.chkTourOperator.AutoSize = True
        Me.chkTourOperator.Location = New System.Drawing.Point(3, 39)
        Me.chkTourOperator.Name = "chkTourOperator"
        Me.chkTourOperator.Size = New System.Drawing.Size(89, 17)
        Me.chkTourOperator.TabIndex = 1
        Me.chkTourOperator.Text = "TourOperator"
        Me.chkTourOperator.UseVisualStyleBackColor = True
        '
        'chkTravelAgency
        '
        Me.chkTravelAgency.AutoSize = True
        Me.chkTravelAgency.Location = New System.Drawing.Point(3, 16)
        Me.chkTravelAgency.Name = "chkTravelAgency"
        Me.chkTravelAgency.Size = New System.Drawing.Size(95, 17)
        Me.chkTravelAgency.TabIndex = 0
        Me.chkTravelAgency.Text = "Travel Agency"
        Me.chkTravelAgency.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(307, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(120, 20)
        Me.TextBox1.TabIndex = 134
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(265, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 135
        Me.Label11.Text = "RecId"
        '
        'txtDataApiToken
        '
        Me.txtDataApiToken.Location = New System.Drawing.Point(139, 188)
        Me.txtDataApiToken.Name = "txtDataApiToken"
        Me.txtDataApiToken.ReadOnly = True
        Me.txtDataApiToken.Size = New System.Drawing.Size(421, 20)
        Me.txtDataApiToken.TabIndex = 136
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 137
        Me.Label12.Text = "DataApiToken"
        '
        'txtCustAddress
        '
        Me.txtCustAddress.Location = New System.Drawing.Point(139, 214)
        Me.txtCustAddress.MaxLength = 8
        Me.txtCustAddress.Name = "txtCustAddress"
        Me.txtCustAddress.Size = New System.Drawing.Size(421, 20)
        Me.txtCustAddress.TabIndex = 138
        '
        'lblCustAddress
        '
        Me.lblCustAddress.AutoSize = True
        Me.lblCustAddress.Location = New System.Drawing.Point(12, 221)
        Me.lblCustAddress.Name = "lblCustAddress"
        Me.lblCustAddress.Size = New System.Drawing.Size(66, 13)
        Me.lblCustAddress.TabIndex = 139
        Me.lblCustAddress.Text = "CustAddress"
        '
        'txtCustTaxCode
        '
        Me.txtCustTaxCode.Location = New System.Drawing.Point(139, 240)
        Me.txtCustTaxCode.Name = "txtCustTaxCode"
        Me.txtCustTaxCode.Size = New System.Drawing.Size(120, 20)
        Me.txtCustTaxCode.TabIndex = 140
        '
        'lblCustTaxCode
        '
        Me.lblCustTaxCode.AutoSize = True
        Me.lblCustTaxCode.Location = New System.Drawing.Point(12, 247)
        Me.lblCustTaxCode.Name = "lblCustTaxCode"
        Me.lblCustTaxCode.Size = New System.Drawing.Size(71, 13)
        Me.lblCustTaxCode.TabIndex = 141
        Me.lblCustTaxCode.Text = "CustTaxCode"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(139, 266)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(421, 20)
        Me.txtEmail.TabIndex = 142
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(12, 273)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 143
        Me.lblEmail.Text = "Email"
        '
        'chkPPD
        '
        Me.chkPPD.AutoSize = True
        Me.chkPPD.Location = New System.Drawing.Point(566, 164)
        Me.chkPPD.Name = "chkPPD"
        Me.chkPPD.Size = New System.Drawing.Size(48, 17)
        Me.chkPPD.TabIndex = 144
        Me.chkPPD.Text = "PPD"
        Me.chkPPD.UseVisualStyleBackColor = True
        '
        'frmCustomerEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 430)
        Me.Controls.Add(Me.chkPPD)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtCustTaxCode)
        Me.Controls.Add(Me.lblCustTaxCode)
        Me.Controls.Add(Me.txtCustAddress)
        Me.Controls.Add(Me.lblCustAddress)
        Me.Controls.Add(Me.txtDataApiToken)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.grbAccountTypes)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtWeb)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboProvince)
        Me.Controls.Add(Me.txtAccountNameVN)
        Me.Controls.Add(Me.txtAccountNameGB)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtShortName)
        Me.Controls.Add(Me.cboAmadeusSize)
        Me.Controls.Add(Me.cboMarketSize)
        Me.Controls.Add(Me.cboAccountStatus)
        Me.Controls.Add(Me.cboPIC)
        Me.Controls.Add(Me.cboRegion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmCustomerEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CustomerEdit"
        Me.grbAccountTypes.ResumeLayout(False)
        Me.grbAccountTypes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtShortName As System.Windows.Forms.TextBox
    Friend WithEvents cboAmadeusSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboMarketSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboAccountStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboPIC As System.Windows.Forms.ComboBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNameGB As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNameVN As System.Windows.Forms.TextBox
    Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
    Friend WithEvents txtWeb As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grbAccountTypes As System.Windows.Forms.GroupBox
    Friend WithEvents cboAirlines As System.Windows.Forms.CheckBox
    Friend WithEvents chkTourOperator As System.Windows.Forms.CheckBox
    Friend WithEvents chkTravelAgency As System.Windows.Forms.CheckBox
    Friend WithEvents chkCorporation As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDataApiToken As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCustAddress As TextBox
    Friend WithEvents lblCustAddress As Label
    Friend WithEvents txtCustTaxCode As TextBox
    Friend WithEvents lblCustTaxCode As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents chkPPD As CheckBox
End Class
