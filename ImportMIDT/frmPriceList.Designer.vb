<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPriceList
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
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpLst = New System.Windows.Forms.TabPage()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblExpDate2 = New System.Windows.Forms.Label()
        Me.lblEffDate2 = New System.Windows.Forms.Label()
        Me.lblCustomer2 = New System.Windows.Forms.Label()
        Me.cboCustomer_2 = New System.Windows.Forms.ComboBox()
        Me.dtpExpDate_2 = New System.Windows.Forms.DateTimePicker()
        Me.cboExpDate = New System.Windows.Forms.ComboBox()
        Me.lblNote_2 = New System.Windows.Forms.Label()
        Me.txtNote_2 = New System.Windows.Forms.TextBox()
        Me.llbReset = New System.Windows.Forms.LinkLabel()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.llbCopy = New System.Windows.Forms.LinkLabel()
        Me.dtpEffDate_2 = New System.Windows.Forms.DateTimePicker()
        Me.cboEffDate = New System.Windows.Forms.ComboBox()
        Me.llbHistory = New System.Windows.Forms.LinkLabel()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.llbAdd = New System.Windows.Forms.LinkLabel()
        Me.llbDelete = New System.Windows.Forms.LinkLabel()
        Me.llbEdit = New System.Windows.Forms.LinkLabel()
        Me.llbSearch = New System.Windows.Forms.LinkLabel()
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        Me.tpInput = New System.Windows.Forms.TabPage()
        Me.dgvIDetail = New System.Windows.Forms.DataGridView()
        Me.lblExpDate = New System.Windows.Forms.Label()
        Me.dtpExpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEffDate = New System.Windows.Forms.Label()
        Me.dtpEffDate = New System.Windows.Forms.DateTimePicker()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.txtPriceID = New System.Windows.Forms.TextBox()
        Me.txtRecID = New System.Windows.Forms.TextBox()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.lblPriceID = New System.Windows.Forms.Label()
        Me.lblRecID = New System.Windows.Forms.Label()
        Me.llbCancel = New System.Windows.Forms.LinkLabel()
        Me.llbOK = New System.Windows.Forms.LinkLabel()
        Me.tpHistory = New System.Windows.Forms.TabPage()
        Me.dgvHDetail = New System.Windows.Forms.DataGridView()
        Me.dgvHMain = New System.Windows.Forms.DataGridView()
        Me.llbBack = New System.Windows.Forms.LinkLabel()
        Me.tcMain.SuspendLayout()
        Me.tpLst.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInput.SuspendLayout()
        CType(Me.dgvIDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHistory.SuspendLayout()
        CType(Me.dgvHDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tpLst)
        Me.tcMain.Controls.Add(Me.tpInput)
        Me.tcMain.Controls.Add(Me.tpHistory)
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(1032, 397)
        Me.tcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcMain.TabIndex = 9
        '
        'tpLst
        '
        Me.tpLst.BackColor = System.Drawing.SystemColors.Control
        Me.tpLst.Controls.Add(Me.dgvDetail)
        Me.tpLst.Controls.Add(Me.lblUser)
        Me.tpLst.Controls.Add(Me.lblExpDate2)
        Me.tpLst.Controls.Add(Me.lblEffDate2)
        Me.tpLst.Controls.Add(Me.lblCustomer2)
        Me.tpLst.Controls.Add(Me.cboCustomer_2)
        Me.tpLst.Controls.Add(Me.dtpExpDate_2)
        Me.tpLst.Controls.Add(Me.cboExpDate)
        Me.tpLst.Controls.Add(Me.lblNote_2)
        Me.tpLst.Controls.Add(Me.txtNote_2)
        Me.tpLst.Controls.Add(Me.llbReset)
        Me.tpLst.Controls.Add(Me.cboUser)
        Me.tpLst.Controls.Add(Me.llbCopy)
        Me.tpLst.Controls.Add(Me.dtpEffDate_2)
        Me.tpLst.Controls.Add(Me.cboEffDate)
        Me.tpLst.Controls.Add(Me.llbHistory)
        Me.tpLst.Controls.Add(Me.chkStatus)
        Me.tpLst.Controls.Add(Me.llbAdd)
        Me.tpLst.Controls.Add(Me.llbDelete)
        Me.tpLst.Controls.Add(Me.llbEdit)
        Me.tpLst.Controls.Add(Me.llbSearch)
        Me.tpLst.Controls.Add(Me.dgvMain)
        Me.tpLst.Location = New System.Drawing.Point(4, 22)
        Me.tpLst.Name = "tpLst"
        Me.tpLst.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLst.Size = New System.Drawing.Size(1024, 371)
        Me.tpLst.TabIndex = 0
        Me.tpLst.Text = "List"
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToOrderColumns = True
        Me.dgvDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(6, 212)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.Size = New System.Drawing.Size(1012, 150)
        Me.dgvDetail.TabIndex = 56
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(836, 9)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 55
        Me.lblUser.Text = "User"
        '
        'lblExpDate2
        '
        Me.lblExpDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExpDate2.AutoSize = True
        Me.lblExpDate2.Location = New System.Drawing.Point(646, 36)
        Me.lblExpDate2.Name = "lblExpDate2"
        Me.lblExpDate2.Size = New System.Drawing.Size(51, 13)
        Me.lblExpDate2.TabIndex = 54
        Me.lblExpDate2.Text = "Exp Date"
        '
        'lblEffDate2
        '
        Me.lblEffDate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEffDate2.AutoSize = True
        Me.lblEffDate2.Location = New System.Drawing.Point(651, 9)
        Me.lblEffDate2.Name = "lblEffDate2"
        Me.lblEffDate2.Size = New System.Drawing.Size(46, 13)
        Me.lblEffDate2.TabIndex = 53
        Me.lblEffDate2.Text = "Eff Date"
        '
        'lblCustomer2
        '
        Me.lblCustomer2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCustomer2.AutoSize = True
        Me.lblCustomer2.Location = New System.Drawing.Point(483, 9)
        Me.lblCustomer2.Name = "lblCustomer2"
        Me.lblCustomer2.Size = New System.Drawing.Size(51, 13)
        Me.lblCustomer2.TabIndex = 52
        Me.lblCustomer2.Text = "Customer"
        '
        'cboCustomer_2
        '
        Me.cboCustomer_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCustomer_2.FormattingEnabled = True
        Me.cboCustomer_2.Items.AddRange(New Object() {""})
        Me.cboCustomer_2.Location = New System.Drawing.Point(540, 6)
        Me.cboCustomer_2.Name = "cboCustomer_2"
        Me.cboCustomer_2.Size = New System.Drawing.Size(100, 21)
        Me.cboCustomer_2.TabIndex = 51
        '
        'dtpExpDate_2
        '
        Me.dtpExpDate_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpExpDate_2.CustomFormat = "MM/yyyy"
        Me.dtpExpDate_2.Enabled = False
        Me.dtpExpDate_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpDate_2.Location = New System.Drawing.Point(749, 32)
        Me.dtpExpDate_2.Name = "dtpExpDate_2"
        Me.dtpExpDate_2.ShowUpDown = True
        Me.dtpExpDate_2.Size = New System.Drawing.Size(81, 20)
        Me.dtpExpDate_2.TabIndex = 50
        '
        'cboExpDate
        '
        Me.cboExpDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboExpDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpDate.FormattingEnabled = True
        Me.cboExpDate.Items.AddRange(New Object() {"", "=", ">", ">=", "<", "<="})
        Me.cboExpDate.Location = New System.Drawing.Point(703, 32)
        Me.cboExpDate.Name = "cboExpDate"
        Me.cboExpDate.Size = New System.Drawing.Size(40, 21)
        Me.cboExpDate.TabIndex = 49
        '
        'lblNote_2
        '
        Me.lblNote_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNote_2.AutoSize = True
        Me.lblNote_2.Location = New System.Drawing.Point(504, 36)
        Me.lblNote_2.Name = "lblNote_2"
        Me.lblNote_2.Size = New System.Drawing.Size(30, 13)
        Me.lblNote_2.TabIndex = 48
        Me.lblNote_2.Text = "Note"
        '
        'txtNote_2
        '
        Me.txtNote_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote_2.Location = New System.Drawing.Point(540, 32)
        Me.txtNote_2.Name = "txtNote_2"
        Me.txtNote_2.Size = New System.Drawing.Size(100, 20)
        Me.txtNote_2.TabIndex = 47
        '
        'llbReset
        '
        Me.llbReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbReset.AutoSize = True
        Me.llbReset.Location = New System.Drawing.Point(977, 35)
        Me.llbReset.Name = "llbReset"
        Me.llbReset.Size = New System.Drawing.Size(35, 13)
        Me.llbReset.TabIndex = 46
        Me.llbReset.TabStop = True
        Me.llbReset.Text = "Reset"
        '
        'cboUser
        '
        Me.cboUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Location = New System.Drawing.Point(871, 4)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(100, 21)
        Me.cboUser.TabIndex = 45
        '
        'llbCopy
        '
        Me.llbCopy.AutoSize = True
        Me.llbCopy.Enabled = False
        Me.llbCopy.Location = New System.Drawing.Point(10, 35)
        Me.llbCopy.Name = "llbCopy"
        Me.llbCopy.Size = New System.Drawing.Size(31, 13)
        Me.llbCopy.TabIndex = 44
        Me.llbCopy.TabStop = True
        Me.llbCopy.Text = "Copy"
        '
        'dtpEffDate_2
        '
        Me.dtpEffDate_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpEffDate_2.CustomFormat = "MM/yyyy"
        Me.dtpEffDate_2.Enabled = False
        Me.dtpEffDate_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffDate_2.Location = New System.Drawing.Point(749, 5)
        Me.dtpEffDate_2.Name = "dtpEffDate_2"
        Me.dtpEffDate_2.ShowUpDown = True
        Me.dtpEffDate_2.Size = New System.Drawing.Size(81, 20)
        Me.dtpEffDate_2.TabIndex = 43
        '
        'cboEffDate
        '
        Me.cboEffDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEffDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEffDate.FormattingEnabled = True
        Me.cboEffDate.Items.AddRange(New Object() {"", "=", ">", ">=", "<", "<="})
        Me.cboEffDate.Location = New System.Drawing.Point(703, 5)
        Me.cboEffDate.Name = "cboEffDate"
        Me.cboEffDate.Size = New System.Drawing.Size(40, 21)
        Me.cboEffDate.TabIndex = 42
        '
        'llbHistory
        '
        Me.llbHistory.AutoSize = True
        Me.llbHistory.Enabled = False
        Me.llbHistory.Location = New System.Drawing.Point(47, 35)
        Me.llbHistory.Name = "llbHistory"
        Me.llbHistory.Size = New System.Drawing.Size(39, 13)
        Me.llbHistory.TabIndex = 41
        Me.llbHistory.TabStop = True
        Me.llbHistory.Text = "History"
        '
        'chkStatus
        '
        Me.chkStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Location = New System.Drawing.Point(852, 33)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(119, 17)
        Me.chkStatus.TabIndex = 40
        Me.chkStatus.Text = "Show Deleted Data"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'llbAdd
        '
        Me.llbAdd.AutoSize = True
        Me.llbAdd.Location = New System.Drawing.Point(8, 8)
        Me.llbAdd.Name = "llbAdd"
        Me.llbAdd.Size = New System.Drawing.Size(26, 13)
        Me.llbAdd.TabIndex = 36
        Me.llbAdd.TabStop = True
        Me.llbAdd.Text = "Add"
        '
        'llbDelete
        '
        Me.llbDelete.AutoSize = True
        Me.llbDelete.Enabled = False
        Me.llbDelete.Location = New System.Drawing.Point(71, 8)
        Me.llbDelete.Name = "llbDelete"
        Me.llbDelete.Size = New System.Drawing.Size(38, 13)
        Me.llbDelete.TabIndex = 38
        Me.llbDelete.TabStop = True
        Me.llbDelete.Text = "Delete"
        '
        'llbEdit
        '
        Me.llbEdit.AutoSize = True
        Me.llbEdit.Enabled = False
        Me.llbEdit.Location = New System.Drawing.Point(40, 8)
        Me.llbEdit.Name = "llbEdit"
        Me.llbEdit.Size = New System.Drawing.Size(25, 13)
        Me.llbEdit.TabIndex = 37
        Me.llbEdit.TabStop = True
        Me.llbEdit.Text = "Edit"
        '
        'llbSearch
        '
        Me.llbSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbSearch.AutoSize = True
        Me.llbSearch.Location = New System.Drawing.Point(977, 8)
        Me.llbSearch.Name = "llbSearch"
        Me.llbSearch.Size = New System.Drawing.Size(41, 13)
        Me.llbSearch.TabIndex = 39
        Me.llbSearch.TabStop = True
        Me.llbSearch.Text = "Search"
        '
        'dgvMain
        '
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        Me.dgvMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Location = New System.Drawing.Point(6, 56)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.ReadOnly = True
        Me.dgvMain.Size = New System.Drawing.Size(1012, 150)
        Me.dgvMain.TabIndex = 0
        '
        'tpInput
        '
        Me.tpInput.BackColor = System.Drawing.SystemColors.Control
        Me.tpInput.Controls.Add(Me.dgvIDetail)
        Me.tpInput.Controls.Add(Me.lblExpDate)
        Me.tpInput.Controls.Add(Me.dtpExpDate)
        Me.tpInput.Controls.Add(Me.lblEffDate)
        Me.tpInput.Controls.Add(Me.dtpEffDate)
        Me.tpInput.Controls.Add(Me.cboCustomer)
        Me.tpInput.Controls.Add(Me.lblCustomer)
        Me.tpInput.Controls.Add(Me.txtNote)
        Me.tpInput.Controls.Add(Me.txtPriceID)
        Me.tpInput.Controls.Add(Me.txtRecID)
        Me.tpInput.Controls.Add(Me.lblNote)
        Me.tpInput.Controls.Add(Me.lblPriceID)
        Me.tpInput.Controls.Add(Me.lblRecID)
        Me.tpInput.Controls.Add(Me.llbCancel)
        Me.tpInput.Controls.Add(Me.llbOK)
        Me.tpInput.Location = New System.Drawing.Point(4, 22)
        Me.tpInput.Name = "tpInput"
        Me.tpInput.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInput.Size = New System.Drawing.Size(1024, 371)
        Me.tpInput.TabIndex = 1
        Me.tpInput.Text = "Input"
        '
        'dgvIDetail
        '
        Me.dgvIDetail.AllowUserToOrderColumns = True
        Me.dgvIDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIDetail.Location = New System.Drawing.Point(6, 212)
        Me.dgvIDetail.Name = "dgvIDetail"
        Me.dgvIDetail.Size = New System.Drawing.Size(1012, 150)
        Me.dgvIDetail.TabIndex = 57
        '
        'lblExpDate
        '
        Me.lblExpDate.AutoSize = True
        Me.lblExpDate.Location = New System.Drawing.Point(22, 154)
        Me.lblExpDate.Name = "lblExpDate"
        Me.lblExpDate.Size = New System.Drawing.Size(51, 13)
        Me.lblExpDate.TabIndex = 32
        Me.lblExpDate.Text = "Exp Date"
        '
        'dtpExpDate
        '
        Me.dtpExpDate.CustomFormat = "MM/yyyy"
        Me.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpDate.Location = New System.Drawing.Point(79, 150)
        Me.dtpExpDate.Name = "dtpExpDate"
        Me.dtpExpDate.ShowUpDown = True
        Me.dtpExpDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpExpDate.TabIndex = 12
        '
        'lblEffDate
        '
        Me.lblEffDate.AutoSize = True
        Me.lblEffDate.Location = New System.Drawing.Point(27, 128)
        Me.lblEffDate.Name = "lblEffDate"
        Me.lblEffDate.Size = New System.Drawing.Size(46, 13)
        Me.lblEffDate.TabIndex = 30
        Me.lblEffDate.Text = "Eff Date"
        '
        'dtpEffDate
        '
        Me.dtpEffDate.CustomFormat = "MM/yyyy"
        Me.dtpEffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffDate.Location = New System.Drawing.Point(79, 124)
        Me.dtpEffDate.Name = "dtpEffDate"
        Me.dtpEffDate.ShowUpDown = True
        Me.dtpEffDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpEffDate.TabIndex = 11
        '
        'cboCustomer
        '
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(79, 71)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(130, 21)
        Me.cboCustomer.TabIndex = 9
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Location = New System.Drawing.Point(22, 74)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(51, 13)
        Me.lblCustomer.TabIndex = 28
        Me.lblCustomer.Text = "Customer"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(79, 98)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(300, 20)
        Me.txtNote.TabIndex = 10
        '
        'txtPriceID
        '
        Me.txtPriceID.Location = New System.Drawing.Point(79, 45)
        Me.txtPriceID.Name = "txtPriceID"
        Me.txtPriceID.ReadOnly = True
        Me.txtPriceID.Size = New System.Drawing.Size(80, 20)
        Me.txtPriceID.TabIndex = 8
        '
        'txtRecID
        '
        Me.txtRecID.Location = New System.Drawing.Point(79, 19)
        Me.txtRecID.Name = "txtRecID"
        Me.txtRecID.ReadOnly = True
        Me.txtRecID.Size = New System.Drawing.Size(40, 20)
        Me.txtRecID.TabIndex = 7
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(43, 101)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(30, 13)
        Me.lblNote.TabIndex = 20
        Me.lblNote.Text = "Note"
        '
        'lblPriceID
        '
        Me.lblPriceID.AutoSize = True
        Me.lblPriceID.Location = New System.Drawing.Point(28, 48)
        Me.lblPriceID.Name = "lblPriceID"
        Me.lblPriceID.Size = New System.Drawing.Size(45, 13)
        Me.lblPriceID.TabIndex = 17
        Me.lblPriceID.Text = "Price ID"
        '
        'lblRecID
        '
        Me.lblRecID.AutoSize = True
        Me.lblRecID.Location = New System.Drawing.Point(35, 22)
        Me.lblRecID.Name = "lblRecID"
        Me.lblRecID.Size = New System.Drawing.Size(38, 13)
        Me.lblRecID.TabIndex = 15
        Me.lblRecID.Text = "RecID"
        '
        'llbCancel
        '
        Me.llbCancel.AutoSize = True
        Me.llbCancel.Location = New System.Drawing.Point(36, 3)
        Me.llbCancel.Name = "llbCancel"
        Me.llbCancel.Size = New System.Drawing.Size(40, 13)
        Me.llbCancel.TabIndex = 14
        Me.llbCancel.TabStop = True
        Me.llbCancel.Text = "Cancel"
        '
        'llbOK
        '
        Me.llbOK.AutoSize = True
        Me.llbOK.Location = New System.Drawing.Point(8, 3)
        Me.llbOK.Name = "llbOK"
        Me.llbOK.Size = New System.Drawing.Size(22, 13)
        Me.llbOK.TabIndex = 13
        Me.llbOK.TabStop = True
        Me.llbOK.Text = "OK"
        '
        'tpHistory
        '
        Me.tpHistory.BackColor = System.Drawing.SystemColors.Control
        Me.tpHistory.Controls.Add(Me.dgvHDetail)
        Me.tpHistory.Controls.Add(Me.dgvHMain)
        Me.tpHistory.Controls.Add(Me.llbBack)
        Me.tpHistory.Location = New System.Drawing.Point(4, 22)
        Me.tpHistory.Name = "tpHistory"
        Me.tpHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHistory.Size = New System.Drawing.Size(1024, 371)
        Me.tpHistory.TabIndex = 2
        Me.tpHistory.Text = "History"
        '
        'dgvHDetail
        '
        Me.dgvHDetail.AllowUserToAddRows = False
        Me.dgvHDetail.AllowUserToDeleteRows = False
        Me.dgvHDetail.AllowUserToOrderColumns = True
        Me.dgvHDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvHDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvHDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHDetail.Location = New System.Drawing.Point(6, 212)
        Me.dgvHDetail.Name = "dgvHDetail"
        Me.dgvHDetail.ReadOnly = True
        Me.dgvHDetail.Size = New System.Drawing.Size(1012, 150)
        Me.dgvHDetail.TabIndex = 58
        '
        'dgvHMain
        '
        Me.dgvHMain.AllowUserToAddRows = False
        Me.dgvHMain.AllowUserToDeleteRows = False
        Me.dgvHMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvHMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvHMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHMain.Location = New System.Drawing.Point(6, 19)
        Me.dgvHMain.Name = "dgvHMain"
        Me.dgvHMain.ReadOnly = True
        Me.dgvHMain.Size = New System.Drawing.Size(1012, 187)
        Me.dgvHMain.TabIndex = 57
        '
        'llbBack
        '
        Me.llbBack.AutoSize = True
        Me.llbBack.Location = New System.Drawing.Point(6, 3)
        Me.llbBack.Name = "llbBack"
        Me.llbBack.Size = New System.Drawing.Size(32, 13)
        Me.llbBack.TabIndex = 9
        Me.llbBack.TabStop = True
        Me.llbBack.Text = "Back"
        '
        'frmPriceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 397)
        Me.Controls.Add(Me.tcMain)
        Me.Name = "frmPriceList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PriceList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcMain.ResumeLayout(False)
        Me.tpLst.ResumeLayout(False)
        Me.tpLst.PerformLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInput.ResumeLayout(False)
        Me.tpInput.PerformLayout()
        CType(Me.dgvIDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHistory.ResumeLayout(False)
        Me.tpHistory.PerformLayout()
        CType(Me.dgvHDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcMain As TabControl
    Friend WithEvents tpLst As TabPage
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents lblUser As Label
    Friend WithEvents lblExpDate2 As Label
    Friend WithEvents lblEffDate2 As Label
    Friend WithEvents lblCustomer2 As Label
    Friend WithEvents cboCustomer_2 As ComboBox
    Friend WithEvents dtpExpDate_2 As DateTimePicker
    Friend WithEvents cboExpDate As ComboBox
    Friend WithEvents lblNote_2 As Label
    Friend WithEvents txtNote_2 As TextBox
    Friend WithEvents llbReset As LinkLabel
    Friend WithEvents cboUser As ComboBox
    Friend WithEvents llbCopy As LinkLabel
    Friend WithEvents dtpEffDate_2 As DateTimePicker
    Friend WithEvents cboEffDate As ComboBox
    Friend WithEvents llbHistory As LinkLabel
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents llbAdd As LinkLabel
    Friend WithEvents llbDelete As LinkLabel
    Friend WithEvents llbEdit As LinkLabel
    Friend WithEvents llbSearch As LinkLabel
    Friend WithEvents dgvMain As DataGridView
    Friend WithEvents tpInput As TabPage
    Friend WithEvents lblExpDate As Label
    Friend WithEvents dtpExpDate As DateTimePicker
    Friend WithEvents lblEffDate As Label
    Friend WithEvents dtpEffDate As DateTimePicker
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents txtNote As TextBox
    Friend WithEvents txtPriceID As TextBox
    Friend WithEvents txtRecID As TextBox
    Friend WithEvents lblNote As Label
    Friend WithEvents lblPriceID As Label
    Friend WithEvents lblRecID As Label
    Friend WithEvents llbCancel As LinkLabel
    Friend WithEvents llbOK As LinkLabel
    Friend WithEvents tpHistory As TabPage
    Friend WithEvents dgvIDetail As DataGridView
    Friend WithEvents dgvHDetail As DataGridView
    Friend WithEvents dgvHMain As DataGridView
    Friend WithEvents llbBack As LinkLabel
End Class
