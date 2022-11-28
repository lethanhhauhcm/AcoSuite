<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerList
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
        Me.dgCustomers = New System.Windows.Forms.DataGridView()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.cboPIC = New System.Windows.Forms.ComboBox()
        Me.cboAccountStatus = New System.Windows.Forms.ComboBox()
        Me.cboMarketSize = New System.Windows.Forms.ComboBox()
        Me.cboAmadeusSize = New System.Windows.Forms.ComboBox()
        Me.txtShortName = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lbkLocations = New System.Windows.Forms.LinkLabel()
        Me.lblContacts = New System.Windows.Forms.LinkLabel()
        Me.grbAccountTypes = New System.Windows.Forms.GroupBox()
        Me.chkCorporation = New System.Windows.Forms.CheckBox()
        Me.chkAirlines = New System.Windows.Forms.CheckBox()
        Me.chkTourOperator = New System.Windows.Forms.CheckBox()
        Me.chkTravelAgency = New System.Windows.Forms.CheckBox()
        Me.lbkOfficeIDs = New System.Windows.Forms.LinkLabel()
        Me.lbkIataCodes = New System.Windows.Forms.LinkLabel()
        Me.txtAccountNameGB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOffcId = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbkBillingInfo = New System.Windows.Forms.LinkLabel()
        Me.lbkPaymentInfo = New System.Windows.Forms.LinkLabel()
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbAccountTypes.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgCustomers
        '
        Me.dgCustomers.AllowUserToAddRows = False
        Me.dgCustomers.AllowUserToDeleteRows = False
        Me.dgCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomers.Location = New System.Drawing.Point(1, 55)
        Me.dgCustomers.Name = "dgCustomers"
        Me.dgCustomers.ReadOnly = True
        Me.dgCustomers.Size = New System.Drawing.Size(868, 413)
        Me.dgCustomers.TabIndex = 103
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(389, 599)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(91, 20)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(262, 599)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(91, 20)
        Me.btnNew.TabIndex = 8
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(516, 599)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(103, 20)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(655, 599)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 20)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(1, 474)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(868, 115)
        Me.txtComments.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(94, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "PIC"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "ShortName"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-2, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Region"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(576, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "MarketSize"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(483, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "AccountStatus"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(669, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "AmadeusSize"
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Items.AddRange(New Object() {"South", "North"})
        Me.cboRegion.Location = New System.Drawing.Point(1, 25)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(87, 21)
        Me.cboRegion.TabIndex = 0
        '
        'cboPIC
        '
        Me.cboPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPIC.FormattingEnabled = True
        Me.cboPIC.Location = New System.Drawing.Point(97, 25)
        Me.cboPIC.Name = "cboPIC"
        Me.cboPIC.Size = New System.Drawing.Size(120, 21)
        Me.cboPIC.TabIndex = 1
        '
        'cboAccountStatus
        '
        Me.cboAccountStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountStatus.FormattingEnabled = True
        Me.cboAccountStatus.Items.AddRange(New Object() {"Lead", "Prospect", "Customer", "Lost", "Suspended"})
        Me.cboAccountStatus.Location = New System.Drawing.Point(486, 25)
        Me.cboAccountStatus.Name = "cboAccountStatus"
        Me.cboAccountStatus.Size = New System.Drawing.Size(87, 21)
        Me.cboAccountStatus.TabIndex = 3
        '
        'cboMarketSize
        '
        Me.cboMarketSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarketSize.FormattingEnabled = True
        Me.cboMarketSize.Items.AddRange(New Object() {"Large", "Medium", "Small", "Micro"})
        Me.cboMarketSize.Location = New System.Drawing.Point(579, 25)
        Me.cboMarketSize.Name = "cboMarketSize"
        Me.cboMarketSize.Size = New System.Drawing.Size(87, 21)
        Me.cboMarketSize.TabIndex = 4
        '
        'cboAmadeusSize
        '
        Me.cboAmadeusSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAmadeusSize.FormattingEnabled = True
        Me.cboAmadeusSize.Items.AddRange(New Object() {"Large", "Medium", "Small", "Micro"})
        Me.cboAmadeusSize.Location = New System.Drawing.Point(672, 25)
        Me.cboAmadeusSize.Name = "cboAmadeusSize"
        Me.cboAmadeusSize.Size = New System.Drawing.Size(87, 21)
        Me.cboAmadeusSize.TabIndex = 5
        '
        'txtShortName
        '
        Me.txtShortName.Location = New System.Drawing.Point(223, 25)
        Me.txtShortName.Name = "txtShortName"
        Me.txtShortName.Size = New System.Drawing.Size(120, 20)
        Me.txtShortName.TabIndex = 2
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(889, 28)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(91, 20)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(889, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(91, 20)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lbkLocations
        '
        Me.lbkLocations.AutoSize = True
        Me.lbkLocations.Location = New System.Drawing.Point(875, 568)
        Me.lbkLocations.Name = "lbkLocations"
        Me.lbkLocations.Size = New System.Drawing.Size(53, 13)
        Me.lbkLocations.TabIndex = 110
        Me.lbkLocations.TabStop = True
        Me.lbkLocations.Text = "Locations"
        '
        'lblContacts
        '
        Me.lblContacts.AutoSize = True
        Me.lblContacts.Location = New System.Drawing.Point(875, 534)
        Me.lblContacts.Name = "lblContacts"
        Me.lblContacts.Size = New System.Drawing.Size(49, 13)
        Me.lblContacts.TabIndex = 111
        Me.lblContacts.TabStop = True
        Me.lblContacts.Text = "Contacts"
        '
        'grbAccountTypes
        '
        Me.grbAccountTypes.Controls.Add(Me.chkCorporation)
        Me.grbAccountTypes.Controls.Add(Me.chkAirlines)
        Me.grbAccountTypes.Controls.Add(Me.chkTourOperator)
        Me.grbAccountTypes.Controls.Add(Me.chkTravelAgency)
        Me.grbAccountTypes.Location = New System.Drawing.Point(875, 55)
        Me.grbAccountTypes.Name = "grbAccountTypes"
        Me.grbAccountTypes.Size = New System.Drawing.Size(116, 145)
        Me.grbAccountTypes.TabIndex = 112
        Me.grbAccountTypes.TabStop = False
        Me.grbAccountTypes.Text = "AccountTypes"
        '
        'chkCorporation
        '
        Me.chkCorporation.AutoSize = True
        Me.chkCorporation.Location = New System.Drawing.Point(3, 85)
        Me.chkCorporation.Name = "chkCorporation"
        Me.chkCorporation.Size = New System.Drawing.Size(80, 17)
        Me.chkCorporation.TabIndex = 3
        Me.chkCorporation.Text = "Corporation"
        Me.chkCorporation.UseVisualStyleBackColor = True
        '
        'chkAirlines
        '
        Me.chkAirlines.AutoSize = True
        Me.chkAirlines.Location = New System.Drawing.Point(3, 62)
        Me.chkAirlines.Name = "chkAirlines"
        Me.chkAirlines.Size = New System.Drawing.Size(59, 17)
        Me.chkAirlines.TabIndex = 2
        Me.chkAirlines.Text = "Airlines"
        Me.chkAirlines.UseVisualStyleBackColor = True
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
        'lbkOfficeIDs
        '
        Me.lbkOfficeIDs.AutoSize = True
        Me.lbkOfficeIDs.Location = New System.Drawing.Point(875, 585)
        Me.lbkOfficeIDs.Name = "lbkOfficeIDs"
        Me.lbkOfficeIDs.Size = New System.Drawing.Size(51, 13)
        Me.lbkOfficeIDs.TabIndex = 113
        Me.lbkOfficeIDs.TabStop = True
        Me.lbkOfficeIDs.Text = "OfficeIDs"
        '
        'lbkIataCodes
        '
        Me.lbkIataCodes.AutoSize = True
        Me.lbkIataCodes.Location = New System.Drawing.Point(875, 551)
        Me.lbkIataCodes.Name = "lbkIataCodes"
        Me.lbkIataCodes.Size = New System.Drawing.Size(55, 13)
        Me.lbkIataCodes.TabIndex = 114
        Me.lbkIataCodes.TabStop = True
        Me.lbkIataCodes.Text = "IataCodes"
        '
        'txtAccountNameGB
        '
        Me.txtAccountNameGB.Location = New System.Drawing.Point(351, 25)
        Me.txtAccountNameGB.Name = "txtAccountNameGB"
        Me.txtAccountNameGB.Size = New System.Drawing.Size(129, 20)
        Me.txtAccountNameGB.TabIndex = 115
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(348, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "AccountNameGB"
        '
        'txtOffcId
        '
        Me.txtOffcId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOffcId.Location = New System.Drawing.Point(764, 25)
        Me.txtOffcId.Name = "txtOffcId"
        Me.txtOffcId.Size = New System.Drawing.Size(105, 20)
        Me.txtOffcId.TabIndex = 117
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(761, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "OffcId"
        '
        'lbkBillingInfo
        '
        Me.lbkBillingInfo.AutoSize = True
        Me.lbkBillingInfo.Location = New System.Drawing.Point(875, 517)
        Me.lbkBillingInfo.Name = "lbkBillingInfo"
        Me.lbkBillingInfo.Size = New System.Drawing.Size(52, 13)
        Me.lbkBillingInfo.TabIndex = 119
        Me.lbkBillingInfo.TabStop = True
        Me.lbkBillingInfo.Text = "BillingInfo"
        '
        'lbkPaymentInfo
        '
        Me.lbkPaymentInfo.AutoSize = True
        Me.lbkPaymentInfo.Location = New System.Drawing.Point(875, 603)
        Me.lbkPaymentInfo.Name = "lbkPaymentInfo"
        Me.lbkPaymentInfo.Size = New System.Drawing.Size(66, 13)
        Me.lbkPaymentInfo.TabIndex = 120
        Me.lbkPaymentInfo.TabStop = True
        Me.lbkPaymentInfo.Text = "PaymentInfo"
        '
        'frmCustomerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 623)
        Me.Controls.Add(Me.lbkPaymentInfo)
        Me.Controls.Add(Me.lbkBillingInfo)
        Me.Controls.Add(Me.txtOffcId)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAccountNameGB)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbkIataCodes)
        Me.Controls.Add(Me.lbkOfficeIDs)
        Me.Controls.Add(Me.grbAccountTypes)
        Me.Controls.Add(Me.lblContacts)
        Me.Controls.Add(Me.lbkLocations)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClear)
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
        Me.Controls.Add(Me.dgCustomers)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtComments)
        Me.Name = "frmCustomerList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CustomerList"
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbAccountTypes.ResumeLayout(False)
        Me.grbAccountTypes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgCustomers As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents cboPIC As System.Windows.Forms.ComboBox
    Friend WithEvents cboAccountStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboMarketSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboAmadeusSize As System.Windows.Forms.ComboBox
    Friend WithEvents txtShortName As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lbkLocations As System.Windows.Forms.LinkLabel
    Friend WithEvents lblContacts As System.Windows.Forms.LinkLabel
    Friend WithEvents grbAccountTypes As System.Windows.Forms.GroupBox
    Friend WithEvents chkAirlines As System.Windows.Forms.CheckBox
    Friend WithEvents chkTourOperator As System.Windows.Forms.CheckBox
    Friend WithEvents chkTravelAgency As System.Windows.Forms.CheckBox
    Friend WithEvents lbkOfficeIDs As System.Windows.Forms.LinkLabel
    Friend WithEvents chkCorporation As System.Windows.Forms.CheckBox
    Friend WithEvents lbkIataCodes As System.Windows.Forms.LinkLabel
    Friend WithEvents txtAccountNameGB As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOffcId As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbkBillingInfo As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkPaymentInfo As System.Windows.Forms.LinkLabel
End Class
