<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaleLog
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
        Me.components = New System.ComponentModel.Container()
        Me.GridCust = New System.Windows.Forms.DataGridView()
        Me.TxtPre = New System.Windows.Forms.RichTextBox()
        Me.TxtPost = New System.Windows.Forms.RichTextBox()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.LblMakeAppt = New System.Windows.Forms.LinkLabel()
        Me.LblDone = New System.Windows.Forms.LinkLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cbxArea = New System.Windows.Forms.ComboBox()
        Me.dgvOfficeID = New System.Windows.Forms.DataGridView()
        Me.cbxContactBefore = New System.Windows.Forms.ComboBox()
        Me.chkNoCost = New System.Windows.Forms.CheckBox()
        Me.cbxSubj = New System.Windows.Forms.ComboBox()
        Me.txtCustShortName = New System.Windows.Forms.TextBox()
        Me.ChkByPhone = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdoPersonal = New System.Windows.Forms.RadioButton()
        Me.rdoCust = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbxContact_After = New System.Windows.Forms.ComboBox()
        Me.txtSaleCost = New System.Windows.Forms.TextBox()
        Me.chkCost = New System.Windows.Forms.CheckBox()
        Me.dtpNewEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpNewStart = New System.Windows.Forms.DateTimePicker()
        Me.LblCancel = New System.Windows.Forms.LinkLabel()
        Me.LblUpdatePrepar = New System.Windows.Forms.LinkLabel()
        Me.TxtPreView = New System.Windows.Forms.RichTextBox()
        Me.GridPendingCall = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lnkDeleteSaleLog = New System.Windows.Forms.LinkLabel()
        Me.cbxUser = New System.Windows.Forms.ComboBox()
        Me.LblRefresh = New System.Windows.Forms.LinkLabel()
        Me.ChkSelectCust = New System.Windows.Forms.CheckBox()
        Me.dtpRptTimeThru = New System.Windows.Forms.DateTimePicker()
        Me.dtpRptTimeFrm = New System.Windows.Forms.DateTimePicker()
        Me.LblSum = New System.Windows.Forms.Label()
        Me.txtPostView = New System.Windows.Forms.RichTextBox()
        Me.GridDoneCall = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lnkDelete = New System.Windows.Forms.LinkLabel()
        Me.lnkAddSetting = New System.Windows.Forms.LinkLabel()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dgvCost = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.lnkRunReport = New System.Windows.Forms.LinkLabel()
        Me.dtpDate1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpDate2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxReportType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxPIC = New System.Windows.Forms.ComboBox()
        Me.bdsCust = New System.Windows.Forms.BindingSource(Me.components)
        Me.bdsPendingCall = New System.Windows.Forms.BindingSource(Me.components)
        Me.bdsReview = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.GridCust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.GridPendingCall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.GridDoneCall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.bdsCust, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bdsPendingCall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bdsReview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridCust
        '
        Me.GridCust.AllowUserToAddRows = False
        Me.GridCust.AllowUserToDeleteRows = False
        Me.GridCust.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GridCust.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GridCust.BackgroundColor = System.Drawing.Color.MintCream
        Me.GridCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCust.Location = New System.Drawing.Point(0, 26)
        Me.GridCust.Name = "GridCust"
        Me.GridCust.RowHeadersVisible = False
        Me.GridCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridCust.Size = New System.Drawing.Size(291, 279)
        Me.GridCust.TabIndex = 0
        '
        'TxtPre
        '
        Me.TxtPre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPre.Location = New System.Drawing.Point(423, 26)
        Me.TxtPre.Name = "TxtPre"
        Me.TxtPre.Size = New System.Drawing.Size(346, 433)
        Me.TxtPre.TabIndex = 1
        Me.TxtPre.Text = ""
        '
        'TxtPost
        '
        Me.TxtPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPost.Location = New System.Drawing.Point(3, 259)
        Me.TxtPost.Name = "TxtPost"
        Me.TxtPost.Size = New System.Drawing.Size(766, 181)
        Me.TxtPost.TabIndex = 1
        Me.TxtPost.Text = ""
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "dd-MMM-yy HH:mm"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(84, 367)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(117, 20)
        Me.dtpStart.TabIndex = 3
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "dd-MMM-yy HH:mm"
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(84, 385)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(117, 20)
        Me.dtpEnd.TabIndex = 3
        '
        'LblMakeAppt
        '
        Me.LblMakeAppt.AutoSize = True
        Me.LblMakeAppt.Location = New System.Drawing.Point(235, 391)
        Me.LblMakeAppt.Name = "LblMakeAppt"
        Me.LblMakeAppt.Size = New System.Drawing.Size(56, 13)
        Me.LblMakeAppt.TabIndex = 4
        Me.LblMakeAppt.TabStop = True
        Me.LblMakeAppt.Text = "MakeAppt"
        '
        'LblDone
        '
        Me.LblDone.AutoSize = True
        Me.LblDone.Location = New System.Drawing.Point(732, 447)
        Me.LblDone.Name = "LblDone"
        Me.LblDone.Size = New System.Drawing.Size(33, 13)
        Me.LblDone.TabIndex = 4
        Me.LblDone.TabStop = True
        Me.LblDone.Text = "Done"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(0, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(780, 491)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cbxArea)
        Me.TabPage1.Controls.Add(Me.dgvOfficeID)
        Me.TabPage1.Controls.Add(Me.cbxContactBefore)
        Me.TabPage1.Controls.Add(Me.chkNoCost)
        Me.TabPage1.Controls.Add(Me.cbxSubj)
        Me.TabPage1.Controls.Add(Me.txtCustShortName)
        Me.TabPage1.Controls.Add(Me.ChkByPhone)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.GridCust)
        Me.TabPage1.Controls.Add(Me.LblMakeAppt)
        Me.TabPage1.Controls.Add(Me.dtpStart)
        Me.TabPage1.Controls.Add(Me.dtpEnd)
        Me.TabPage1.Controls.Add(Me.TxtPre)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(772, 465)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pre Call"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cbxArea
        '
        Me.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxArea.FormattingEnabled = True
        Me.cbxArea.Items.AddRange(New Object() {"South", "North"})
        Me.cbxArea.Location = New System.Drawing.Point(0, 3)
        Me.cbxArea.Name = "cbxArea"
        Me.cbxArea.Size = New System.Drawing.Size(78, 21)
        Me.cbxArea.TabIndex = 14
        '
        'dgvOfficeID
        '
        Me.dgvOfficeID.AllowUserToAddRows = False
        Me.dgvOfficeID.AllowUserToDeleteRows = False
        Me.dgvOfficeID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvOfficeID.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvOfficeID.BackgroundColor = System.Drawing.Color.LightBlue
        Me.dgvOfficeID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOfficeID.Location = New System.Drawing.Point(297, 26)
        Me.dgvOfficeID.Name = "dgvOfficeID"
        Me.dgvOfficeID.ReadOnly = True
        Me.dgvOfficeID.RowHeadersVisible = False
        Me.dgvOfficeID.Size = New System.Drawing.Size(120, 433)
        Me.dgvOfficeID.TabIndex = 13
        '
        'cbxContactBefore
        '
        Me.cbxContactBefore.FormattingEnabled = True
        Me.cbxContactBefore.Location = New System.Drawing.Point(84, 311)
        Me.cbxContactBefore.Name = "cbxContactBefore"
        Me.cbxContactBefore.Size = New System.Drawing.Size(207, 21)
        Me.cbxContactBefore.TabIndex = 12
        '
        'chkNoCost
        '
        Me.chkNoCost.AutoSize = True
        Me.chkNoCost.Location = New System.Drawing.Point(84, 421)
        Me.chkNoCost.Name = "chkNoCost"
        Me.chkNoCost.Size = New System.Drawing.Size(64, 17)
        Me.chkNoCost.TabIndex = 11
        Me.chkNoCost.Text = "No Cost"
        Me.chkNoCost.UseVisualStyleBackColor = True
        '
        'cbxSubj
        '
        Me.cbxSubj.FormattingEnabled = True
        Me.cbxSubj.Items.AddRange(New Object() {"Sales visit", "Cafe/lunch", "Gift", "Training", "Technical support"})
        Me.cbxSubj.Location = New System.Drawing.Point(84, 338)
        Me.cbxSubj.Name = "cbxSubj"
        Me.cbxSubj.Size = New System.Drawing.Size(207, 21)
        Me.cbxSubj.TabIndex = 10
        '
        'txtCustShortName
        '
        Me.txtCustShortName.Location = New System.Drawing.Point(84, 3)
        Me.txtCustShortName.Name = "txtCustShortName"
        Me.txtCustShortName.Size = New System.Drawing.Size(207, 20)
        Me.txtCustShortName.TabIndex = 9
        '
        'ChkByPhone
        '
        Me.ChkByPhone.AutoSize = True
        Me.ChkByPhone.Location = New System.Drawing.Point(207, 371)
        Me.ChkByPhone.Name = "ChkByPhone"
        Me.ChkByPhone.Size = New System.Drawing.Size(84, 17)
        Me.ChkByPhone.TabIndex = 8
        Me.ChkByPhone.Text = "Phone/Chat"
        Me.ChkByPhone.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoPersonal)
        Me.GroupBox2.Controls.Add(Me.rdoCust)
        Me.GroupBox2.Location = New System.Drawing.Point(153, 411)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(138, 32)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'rdoPersonal
        '
        Me.rdoPersonal.AutoSize = True
        Me.rdoPersonal.Location = New System.Drawing.Point(61, 9)
        Me.rdoPersonal.Name = "rdoPersonal"
        Me.rdoPersonal.Size = New System.Drawing.Size(66, 17)
        Me.rdoPersonal.TabIndex = 8
        Me.rdoPersonal.Text = "Personal"
        Me.rdoPersonal.UseVisualStyleBackColor = True
        '
        'rdoCust
        '
        Me.rdoCust.AutoSize = True
        Me.rdoCust.Checked = True
        Me.rdoCust.Location = New System.Drawing.Point(6, 9)
        Me.rdoCust.Name = "rdoCust"
        Me.rdoCust.Size = New System.Drawing.Size(49, 17)
        Me.rdoCust.TabIndex = 8
        Me.rdoCust.TabStop = True
        Me.rdoCust.Text = "Cust."
        Me.rdoCust.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 371)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Time"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 314)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Contact Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 341)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Purpose"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.cbxContact_After)
        Me.TabPage2.Controls.Add(Me.txtSaleCost)
        Me.TabPage2.Controls.Add(Me.chkCost)
        Me.TabPage2.Controls.Add(Me.dtpNewEnd)
        Me.TabPage2.Controls.Add(Me.dtpNewStart)
        Me.TabPage2.Controls.Add(Me.LblCancel)
        Me.TabPage2.Controls.Add(Me.LblUpdatePrepar)
        Me.TabPage2.Controls.Add(Me.TxtPreView)
        Me.TabPage2.Controls.Add(Me.GridPendingCall)
        Me.TabPage2.Controls.Add(Me.TxtPost)
        Me.TabPage2.Controls.Add(Me.LblDone)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(772, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "After Call"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(328, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "ContactName"
        '
        'cbxContact_After
        '
        Me.cbxContact_After.FormattingEnabled = True
        Me.cbxContact_After.Location = New System.Drawing.Point(407, 6)
        Me.cbxContact_After.Name = "cbxContact_After"
        Me.cbxContact_After.Size = New System.Drawing.Size(173, 21)
        Me.cbxContact_After.TabIndex = 12
        '
        'txtSaleCost
        '
        Me.txtSaleCost.Enabled = False
        Me.txtSaleCost.Location = New System.Drawing.Point(626, 442)
        Me.txtSaleCost.Name = "txtSaleCost"
        Me.txtSaleCost.Size = New System.Drawing.Size(100, 20)
        Me.txtSaleCost.TabIndex = 11
        Me.txtSaleCost.Text = "0"
        Me.txtSaleCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkCost
        '
        Me.chkCost.AutoSize = True
        Me.chkCost.Location = New System.Drawing.Point(573, 444)
        Me.chkCost.Name = "chkCost"
        Me.chkCost.Size = New System.Drawing.Size(47, 17)
        Me.chkCost.TabIndex = 10
        Me.chkCost.Text = "Cost"
        Me.chkCost.UseVisualStyleBackColor = True
        '
        'dtpNewEnd
        '
        Me.dtpNewEnd.CustomFormat = "dd-MMM-yy HH:mm"
        Me.dtpNewEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNewEnd.Location = New System.Drawing.Point(457, 237)
        Me.dtpNewEnd.Name = "dtpNewEnd"
        Me.dtpNewEnd.Size = New System.Drawing.Size(123, 20)
        Me.dtpNewEnd.TabIndex = 9
        '
        'dtpNewStart
        '
        Me.dtpNewStart.CustomFormat = "dd-MMM-yy HH:mm"
        Me.dtpNewStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNewStart.Location = New System.Drawing.Point(328, 237)
        Me.dtpNewStart.Name = "dtpNewStart"
        Me.dtpNewStart.Size = New System.Drawing.Size(123, 20)
        Me.dtpNewStart.TabIndex = 9
        '
        'LblCancel
        '
        Me.LblCancel.AutoSize = True
        Me.LblCancel.Location = New System.Drawing.Point(3, 447)
        Me.LblCancel.Name = "LblCancel"
        Me.LblCancel.Size = New System.Drawing.Size(81, 13)
        Me.LblCancel.TabIndex = 8
        Me.LblCancel.TabStop = True
        Me.LblCancel.Text = "Cancel Meeting"
        '
        'LblUpdatePrepar
        '
        Me.LblUpdatePrepar.AutoSize = True
        Me.LblUpdatePrepar.Location = New System.Drawing.Point(723, 239)
        Me.LblUpdatePrepar.Name = "LblUpdatePrepar"
        Me.LblUpdatePrepar.Size = New System.Drawing.Size(42, 13)
        Me.LblUpdatePrepar.TabIndex = 7
        Me.LblUpdatePrepar.TabStop = True
        Me.LblUpdatePrepar.Text = "Update"
        '
        'TxtPreView
        '
        Me.TxtPreView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPreView.Location = New System.Drawing.Point(328, 33)
        Me.TxtPreView.Name = "TxtPreView"
        Me.TxtPreView.Size = New System.Drawing.Size(442, 198)
        Me.TxtPreView.TabIndex = 6
        Me.TxtPreView.Text = ""
        '
        'GridPendingCall
        '
        Me.GridPendingCall.AllowUserToAddRows = False
        Me.GridPendingCall.AllowUserToDeleteRows = False
        Me.GridPendingCall.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GridPendingCall.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GridPendingCall.BackgroundColor = System.Drawing.Color.LightCyan
        Me.GridPendingCall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPendingCall.Location = New System.Drawing.Point(3, 3)
        Me.GridPendingCall.Name = "GridPendingCall"
        Me.GridPendingCall.ReadOnly = True
        Me.GridPendingCall.RowHeadersVisible = False
        Me.GridPendingCall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridPendingCall.Size = New System.Drawing.Size(319, 254)
        Me.GridPendingCall.TabIndex = 5
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lnkDeleteSaleLog)
        Me.TabPage3.Controls.Add(Me.cbxUser)
        Me.TabPage3.Controls.Add(Me.LblRefresh)
        Me.TabPage3.Controls.Add(Me.ChkSelectCust)
        Me.TabPage3.Controls.Add(Me.dtpRptTimeThru)
        Me.TabPage3.Controls.Add(Me.dtpRptTimeFrm)
        Me.TabPage3.Controls.Add(Me.LblSum)
        Me.TabPage3.Controls.Add(Me.txtPostView)
        Me.TabPage3.Controls.Add(Me.GridDoneCall)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(772, 465)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Review"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lnkDeleteSaleLog
        '
        Me.lnkDeleteSaleLog.AutoSize = True
        Me.lnkDeleteSaleLog.Location = New System.Drawing.Point(372, 441)
        Me.lnkDeleteSaleLog.Name = "lnkDeleteSaleLog"
        Me.lnkDeleteSaleLog.Size = New System.Drawing.Size(38, 13)
        Me.lnkDeleteSaleLog.TabIndex = 13
        Me.lnkDeleteSaleLog.TabStop = True
        Me.lnkDeleteSaleLog.Text = "Delete"
        Me.lnkDeleteSaleLog.Visible = False
        '
        'cbxUser
        '
        Me.cbxUser.FormattingEnabled = True
        Me.cbxUser.Location = New System.Drawing.Point(174, 439)
        Me.cbxUser.Name = "cbxUser"
        Me.cbxUser.Size = New System.Drawing.Size(68, 21)
        Me.cbxUser.TabIndex = 12
        '
        'LblRefresh
        '
        Me.LblRefresh.AutoSize = True
        Me.LblRefresh.Location = New System.Drawing.Point(322, 441)
        Me.LblRefresh.Name = "LblRefresh"
        Me.LblRefresh.Size = New System.Drawing.Size(44, 13)
        Me.LblRefresh.TabIndex = 11
        Me.LblRefresh.TabStop = True
        Me.LblRefresh.Text = "Refresh"
        '
        'ChkSelectCust
        '
        Me.ChkSelectCust.AutoSize = True
        Me.ChkSelectCust.Location = New System.Drawing.Point(248, 439)
        Me.ChkSelectCust.Name = "ChkSelectCust"
        Me.ChkSelectCust.Size = New System.Drawing.Size(68, 17)
        Me.ChkSelectCust.TabIndex = 10
        Me.ChkSelectCust.Text = "CustOnly"
        Me.ChkSelectCust.UseVisualStyleBackColor = True
        '
        'dtpRptTimeThru
        '
        Me.dtpRptTimeThru.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRptTimeThru.Location = New System.Drawing.Point(89, 439)
        Me.dtpRptTimeThru.Name = "dtpRptTimeThru"
        Me.dtpRptTimeThru.Size = New System.Drawing.Size(80, 20)
        Me.dtpRptTimeThru.TabIndex = 9
        '
        'dtpRptTimeFrm
        '
        Me.dtpRptTimeFrm.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRptTimeFrm.Location = New System.Drawing.Point(3, 439)
        Me.dtpRptTimeFrm.Name = "dtpRptTimeFrm"
        Me.dtpRptTimeFrm.Size = New System.Drawing.Size(80, 20)
        Me.dtpRptTimeFrm.TabIndex = 9
        '
        'LblSum
        '
        Me.LblSum.AutoSize = True
        Me.LblSum.Location = New System.Drawing.Point(3, 9)
        Me.LblSum.Name = "LblSum"
        Me.LblSum.Size = New System.Drawing.Size(39, 13)
        Me.LblSum.TabIndex = 8
        Me.LblSum.Text = "Label3"
        '
        'txtPostView
        '
        Me.txtPostView.Location = New System.Drawing.Point(416, 30)
        Me.txtPostView.Name = "txtPostView"
        Me.txtPostView.Size = New System.Drawing.Size(353, 429)
        Me.txtPostView.TabIndex = 7
        Me.txtPostView.Text = ""
        '
        'GridDoneCall
        '
        Me.GridDoneCall.AllowUserToAddRows = False
        Me.GridDoneCall.AllowUserToDeleteRows = False
        Me.GridDoneCall.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GridDoneCall.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GridDoneCall.BackgroundColor = System.Drawing.Color.LightCyan
        Me.GridDoneCall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDoneCall.Location = New System.Drawing.Point(3, 30)
        Me.GridDoneCall.Name = "GridDoneCall"
        Me.GridDoneCall.RowHeadersVisible = False
        Me.GridDoneCall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridDoneCall.Size = New System.Drawing.Size(407, 403)
        Me.GridDoneCall.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lnkDelete)
        Me.TabPage4.Controls.Add(Me.lnkAddSetting)
        Me.TabPage4.Controls.Add(Me.txtCost)
        Me.TabPage4.Controls.Add(Me.dtpTo)
        Me.TabPage4.Controls.Add(Me.dtpFrom)
        Me.TabPage4.Controls.Add(Me.dgvCost)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(772, 465)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Cost Setting"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lnkDelete
        '
        Me.lnkDelete.AutoSize = True
        Me.lnkDelete.Location = New System.Drawing.Point(279, 446)
        Me.lnkDelete.Name = "lnkDelete"
        Me.lnkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lnkDelete.TabIndex = 6
        Me.lnkDelete.TabStop = True
        Me.lnkDelete.Text = "Delete"
        '
        'lnkAddSetting
        '
        Me.lnkAddSetting.AutoSize = True
        Me.lnkAddSetting.Location = New System.Drawing.Point(524, 12)
        Me.lnkAddSetting.Name = "lnkAddSetting"
        Me.lnkAddSetting.Size = New System.Drawing.Size(26, 13)
        Me.lnkAddSetting.TabIndex = 6
        Me.lnkAddSetting.TabStop = True
        Me.lnkAddSetting.Text = "Add"
        '
        'txtCost
        '
        Me.txtCost.Location = New System.Drawing.Point(418, 6)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(100, 20)
        Me.txtCost.TabIndex = 5
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd-MM-yy "
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(350, 6)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(63, 20)
        Me.dtpTo.TabIndex = 4
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd-MM-yy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(279, 6)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(65, 20)
        Me.dtpFrom.TabIndex = 4
        '
        'dgvCost
        '
        Me.dgvCost.AllowUserToAddRows = False
        Me.dgvCost.AllowUserToDeleteRows = False
        Me.dgvCost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvCost.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCost.Location = New System.Drawing.Point(6, 3)
        Me.dgvCost.Name = "dgvCost"
        Me.dgvCost.ReadOnly = True
        Me.dgvCost.RowHeadersVisible = False
        Me.dgvCost.Size = New System.Drawing.Size(267, 459)
        Me.dgvCost.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.lnkRunReport)
        Me.TabPage5.Controls.Add(Me.dtpDate1)
        Me.TabPage5.Controls.Add(Me.dtpDate2)
        Me.TabPage5.Controls.Add(Me.Label5)
        Me.TabPage5.Controls.Add(Me.Label4)
        Me.TabPage5.Controls.Add(Me.Label6)
        Me.TabPage5.Controls.Add(Me.cbxReportType)
        Me.TabPage5.Controls.Add(Me.Label3)
        Me.TabPage5.Controls.Add(Me.cbxPIC)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(772, 465)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Report"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lnkRunReport
        '
        Me.lnkRunReport.AutoSize = True
        Me.lnkRunReport.Location = New System.Drawing.Point(493, 8)
        Me.lnkRunReport.Name = "lnkRunReport"
        Me.lnkRunReport.Size = New System.Drawing.Size(62, 13)
        Me.lnkRunReport.TabIndex = 7
        Me.lnkRunReport.TabStop = True
        Me.lnkRunReport.Text = "Run Report"
        '
        'dtpDate1
        '
        Me.dtpDate1.CustomFormat = "dd-MM-yy"
        Me.dtpDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate1.Location = New System.Drawing.Point(44, 6)
        Me.dtpDate1.Name = "dtpDate1"
        Me.dtpDate1.Size = New System.Drawing.Size(65, 20)
        Me.dtpDate1.TabIndex = 6
        '
        'dtpDate2
        '
        Me.dtpDate2.CustomFormat = "dd-MM-yy"
        Me.dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate2.Location = New System.Drawing.Point(141, 6)
        Me.dtpDate2.Name = "dtpDate2"
        Me.dtpDate2.Size = New System.Drawing.Size(65, 20)
        Me.dtpDate2.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(115, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(313, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "ReportType"
        '
        'cbxReportType
        '
        Me.cbxReportType.FormattingEnabled = True
        Me.cbxReportType.Items.AddRange(New Object() {"Content", "Cost"})
        Me.cbxReportType.Location = New System.Drawing.Point(382, 5)
        Me.cbxReportType.Name = "cbxReportType"
        Me.cbxReportType.Size = New System.Drawing.Size(105, 21)
        Me.cbxReportType.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(212, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "PIC"
        '
        'cbxPIC
        '
        Me.cbxPIC.FormattingEnabled = True
        Me.cbxPIC.Location = New System.Drawing.Point(242, 5)
        Me.cbxPIC.Name = "cbxPIC"
        Me.cbxPIC.Size = New System.Drawing.Size(65, 21)
        Me.cbxPIC.TabIndex = 0
        '
        'bdsCust
        '
        '
        'bdsPendingCall
        '
        '
        'bdsReview
        '
        '
        'frmSaleLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 496)
        Me.Controls.Add(Me.TabControl1)
        Me.Location = New System.Drawing.Point(0, 50)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaleLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TransViet :: MIDT14 :. Sales Visit Log"
        CType(Me.GridCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GridPendingCall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.GridDoneCall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgvCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.bdsCust, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bdsPendingCall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bdsReview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridCust As System.Windows.Forms.DataGridView
    Friend WithEvents TxtPre As System.Windows.Forms.RichTextBox
    Friend WithEvents TxtPost As System.Windows.Forms.RichTextBox
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblMakeAppt As System.Windows.Forms.LinkLabel
    Friend WithEvents LblDone As System.Windows.Forms.LinkLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TxtPreView As System.Windows.Forms.RichTextBox
    Friend WithEvents GridPendingCall As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPersonal As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCust As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents LblSum As System.Windows.Forms.Label
    Friend WithEvents txtPostView As System.Windows.Forms.RichTextBox
    Friend WithEvents GridDoneCall As System.Windows.Forms.DataGridView
    Friend WithEvents LblUpdatePrepar As System.Windows.Forms.LinkLabel
    Friend WithEvents LblCancel As System.Windows.Forms.LinkLabel
    Friend WithEvents dtpNewEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNewStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkByPhone As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSelectCust As System.Windows.Forms.CheckBox
    Friend WithEvents dtpRptTimeThru As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRptTimeFrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblRefresh As System.Windows.Forms.LinkLabel
    Friend WithEvents bdsCust As System.Windows.Forms.BindingSource
    Friend WithEvents bdsPendingCall As System.Windows.Forms.BindingSource
    Friend WithEvents bdsReview As System.Windows.Forms.BindingSource
    Friend WithEvents txtCustShortName As System.Windows.Forms.TextBox
    Friend WithEvents cbxUser As System.Windows.Forms.ComboBox
    Friend WithEvents txtSaleCost As System.Windows.Forms.TextBox
    Friend WithEvents chkCost As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lnkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAddSetting As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCost As System.Windows.Forms.TextBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvCost As System.Windows.Forms.DataGridView
    Friend WithEvents lnkDeleteSaleLog As System.Windows.Forms.LinkLabel
    Friend WithEvents cbxSubj As System.Windows.Forms.ComboBox
    Friend WithEvents chkNoCost As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxPIC As System.Windows.Forms.ComboBox
    Friend WithEvents lnkRunReport As System.Windows.Forms.LinkLabel
    Friend WithEvents dtpDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxReportType As System.Windows.Forms.ComboBox
    Friend WithEvents cbxContactBefore As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbxContact_After As System.Windows.Forms.ComboBox
    Friend WithEvents cbxArea As System.Windows.Forms.ComboBox
    Friend WithEvents dgvOfficeID As System.Windows.Forms.DataGridView
End Class
