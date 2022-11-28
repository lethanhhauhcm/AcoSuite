<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustSegmentation
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
        Me.lbkLocations = New System.Windows.Forms.LinkLabel()
        Me.lbkOfficeIDs = New System.Windows.Forms.LinkLabel()
        Me.lbkPaymentInfo = New System.Windows.Forms.LinkLabel()
        Me.txtShortName = New System.Windows.Forms.TextBox()
        Me.cboCombineSegment = New System.Windows.Forms.ComboBox()
        Me.cboSubSegment = New System.Windows.Forms.ComboBox()
        Me.cboKeySegment = New System.Windows.Forms.ComboBox()
        Me.cboPIC = New System.Windows.Forms.ComboBox()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgCustomers = New System.Windows.Forms.DataGridView()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lbkSearch = New System.Windows.Forms.LinkLabel()
        Me.lbkClear = New System.Windows.Forms.LinkLabel()
        Me.lbkUpdate = New System.Windows.Forms.LinkLabel()
        Me.txtBookYear = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCurrentCombineSegment = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbkMultiUpdate = New System.Windows.Forms.LinkLabel()
        Me.MultiSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbkLocations
        '
        Me.lbkLocations.AutoSize = True
        Me.lbkLocations.Location = New System.Drawing.Point(875, 561)
        Me.lbkLocations.Name = "lbkLocations"
        Me.lbkLocations.Size = New System.Drawing.Size(53, 13)
        Me.lbkLocations.TabIndex = 141
        Me.lbkLocations.TabStop = True
        Me.lbkLocations.Text = "Locations"
        '
        'lbkOfficeIDs
        '
        Me.lbkOfficeIDs.AutoSize = True
        Me.lbkOfficeIDs.Location = New System.Drawing.Point(875, 578)
        Me.lbkOfficeIDs.Name = "lbkOfficeIDs"
        Me.lbkOfficeIDs.Size = New System.Drawing.Size(51, 13)
        Me.lbkOfficeIDs.TabIndex = 144
        Me.lbkOfficeIDs.TabStop = True
        Me.lbkOfficeIDs.Text = "OfficeIDs"
        '
        'lbkPaymentInfo
        '
        Me.lbkPaymentInfo.AutoSize = True
        Me.lbkPaymentInfo.Location = New System.Drawing.Point(875, 596)
        Me.lbkPaymentInfo.Name = "lbkPaymentInfo"
        Me.lbkPaymentInfo.Size = New System.Drawing.Size(66, 13)
        Me.lbkPaymentInfo.TabIndex = 151
        Me.lbkPaymentInfo.TabStop = True
        Me.lbkPaymentInfo.Text = "PaymentInfo"
        '
        'txtShortName
        '
        Me.txtShortName.Location = New System.Drawing.Point(248, 18)
        Me.txtShortName.Name = "txtShortName"
        Me.txtShortName.Size = New System.Drawing.Size(95, 20)
        Me.txtShortName.TabIndex = 123
        '
        'cboCombineSegment
        '
        Me.cboCombineSegment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCombineSegment.FormattingEnabled = True
        Me.cboCombineSegment.Location = New System.Drawing.Point(627, 18)
        Me.cboCombineSegment.Name = "cboCombineSegment"
        Me.cboCombineSegment.Size = New System.Drawing.Size(157, 21)
        Me.cboCombineSegment.TabIndex = 126
        '
        'cboSubSegment
        '
        Me.cboSubSegment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubSegment.FormattingEnabled = True
        Me.cboSubSegment.Location = New System.Drawing.Point(493, 18)
        Me.cboSubSegment.Name = "cboSubSegment"
        Me.cboSubSegment.Size = New System.Drawing.Size(128, 21)
        Me.cboSubSegment.TabIndex = 125
        '
        'cboKeySegment
        '
        Me.cboKeySegment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKeySegment.FormattingEnabled = True
        Me.cboKeySegment.Items.AddRange(New Object() {"Managed Business", "Online", "Retail"})
        Me.cboKeySegment.Location = New System.Drawing.Point(351, 18)
        Me.cboKeySegment.Name = "cboKeySegment"
        Me.cboKeySegment.Size = New System.Drawing.Size(135, 21)
        Me.cboKeySegment.TabIndex = 124
        '
        'cboPIC
        '
        Me.cboPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPIC.FormattingEnabled = True
        Me.cboPIC.Location = New System.Drawing.Point(122, 18)
        Me.cboPIC.Name = "cboPIC"
        Me.cboPIC.Size = New System.Drawing.Size(120, 21)
        Me.cboPIC.TabIndex = 122
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Items.AddRange(New Object() {"South", "North"})
        Me.cboRegion.Location = New System.Drawing.Point(54, 18)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(59, 21)
        Me.cboRegion.TabIndex = 121
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(624, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 140
        Me.Label6.Text = "Combine Segment"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(348, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "KeySegment"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(490, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Sub-Segmemt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "Region"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "ShortName"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(119, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "PIC"
        '
        'dgCustomers
        '
        Me.dgCustomers.AllowUserToAddRows = False
        Me.dgCustomers.AllowUserToDeleteRows = False
        Me.dgCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MultiSelect})
        Me.dgCustomers.Location = New System.Drawing.Point(1, 48)
        Me.dgCustomers.Name = "dgCustomers"
        Me.dgCustomers.Size = New System.Drawing.Size(995, 492)
        Me.dgCustomers.TabIndex = 134
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(389, 592)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(91, 20)
        Me.btnEdit.TabIndex = 130
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(262, 592)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(91, 20)
        Me.btnNew.TabIndex = 129
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(516, 592)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(103, 20)
        Me.btnDelete.TabIndex = 131
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(655, 592)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 20)
        Me.btnCancel.TabIndex = 132
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lbkSearch
        '
        Me.lbkSearch.AutoSize = True
        Me.lbkSearch.Location = New System.Drawing.Point(917, 9)
        Me.lbkSearch.Name = "lbkSearch"
        Me.lbkSearch.Size = New System.Drawing.Size(41, 13)
        Me.lbkSearch.TabIndex = 152
        Me.lbkSearch.TabStop = True
        Me.lbkSearch.Text = "Search"
        '
        'lbkClear
        '
        Me.lbkClear.AutoSize = True
        Me.lbkClear.Location = New System.Drawing.Point(917, 26)
        Me.lbkClear.Name = "lbkClear"
        Me.lbkClear.Size = New System.Drawing.Size(31, 13)
        Me.lbkClear.TabIndex = 153
        Me.lbkClear.TabStop = True
        Me.lbkClear.Text = "Clear"
        '
        'lbkUpdate
        '
        Me.lbkUpdate.AutoSize = True
        Me.lbkUpdate.Location = New System.Drawing.Point(217, 544)
        Me.lbkUpdate.Name = "lbkUpdate"
        Me.lbkUpdate.Size = New System.Drawing.Size(42, 13)
        Me.lbkUpdate.TabIndex = 154
        Me.lbkUpdate.TabStop = True
        Me.lbkUpdate.Text = "Update"
        '
        'txtBookYear
        '
        Me.txtBookYear.Location = New System.Drawing.Point(1, 18)
        Me.txtBookYear.Name = "txtBookYear"
        Me.txtBookYear.Size = New System.Drawing.Size(40, 20)
        Me.txtBookYear.TabIndex = 155
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(-2, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "BookYear"
        '
        'cboCurrentCombineSegment
        '
        Me.cboCurrentCombineSegment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrentCombineSegment.FormattingEnabled = True
        Me.cboCurrentCombineSegment.Location = New System.Drawing.Point(1, 541)
        Me.cboCurrentCombineSegment.Name = "cboCurrentCombineSegment"
        Me.cboCurrentCombineSegment.Size = New System.Drawing.Size(197, 21)
        Me.cboCurrentCombineSegment.TabIndex = 157
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OK", "XX"})
        Me.cboStatus.Location = New System.Drawing.Point(794, 18)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(44, 21)
        Me.cboStatus.TabIndex = 158
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(791, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 159
        Me.Label8.Text = "Status"
        '
        'lbkMultiUpdate
        '
        Me.lbkMultiUpdate.AutoSize = True
        Me.lbkMultiUpdate.Location = New System.Drawing.Point(326, 544)
        Me.lbkMultiUpdate.Name = "lbkMultiUpdate"
        Me.lbkMultiUpdate.Size = New System.Drawing.Size(64, 13)
        Me.lbkMultiUpdate.TabIndex = 160
        Me.lbkMultiUpdate.TabStop = True
        Me.lbkMultiUpdate.Text = "MultiUpdate"
        '
        'MultiSelect
        '
        Me.MultiSelect.HeaderText = "MultiSelect"
        Me.MultiSelect.Name = "MultiSelect"
        Me.MultiSelect.ReadOnly = True
        Me.MultiSelect.Width = 65
        '
        'frmCustSegmentation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.lbkMultiUpdate)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboCurrentCombineSegment)
        Me.Controls.Add(Me.txtBookYear)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbkUpdate)
        Me.Controls.Add(Me.lbkClear)
        Me.Controls.Add(Me.lbkSearch)
        Me.Controls.Add(Me.lbkLocations)
        Me.Controls.Add(Me.lbkOfficeIDs)
        Me.Controls.Add(Me.lbkPaymentInfo)
        Me.Controls.Add(Me.txtShortName)
        Me.Controls.Add(Me.cboCombineSegment)
        Me.Controls.Add(Me.cboSubSegment)
        Me.Controls.Add(Me.cboKeySegment)
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
        Me.Name = "frmCustSegmentation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CustSegmentation"
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbkLocations As LinkLabel
    Friend WithEvents lbkOfficeIDs As LinkLabel
    Friend WithEvents lbkPaymentInfo As LinkLabel
    Friend WithEvents txtShortName As TextBox
    Friend WithEvents cboCombineSegment As ComboBox
    Friend WithEvents cboSubSegment As ComboBox
    Friend WithEvents cboKeySegment As ComboBox
    Friend WithEvents cboPIC As ComboBox
    Friend WithEvents cboRegion As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgCustomers As DataGridView
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lbkSearch As LinkLabel
    Friend WithEvents lbkClear As LinkLabel
    Friend WithEvents lbkUpdate As LinkLabel
    Friend WithEvents txtBookYear As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboCurrentCombineSegment As ComboBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lbkMultiUpdate As LinkLabel
    Friend WithEvents MultiSelect As DataGridViewCheckBoxColumn
End Class
