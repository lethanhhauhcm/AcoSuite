<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCalcPrice
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
        Me.pnMain = New System.Windows.Forms.Panel()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpList = New System.Windows.Forms.TabPage()
        Me.pnGrid = New System.Windows.Forms.Panel()
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        Me.pnMenu = New System.Windows.Forms.Panel()
        Me.llbEdit = New System.Windows.Forms.LinkLabel()
        Me.llbDelete = New System.Windows.Forms.LinkLabel()
        Me.llbSearch = New System.Windows.Forms.LinkLabel()
        Me.llbAdd = New System.Windows.Forms.LinkLabel()
        Me.tpInput = New System.Windows.Forms.TabPage()
        Me.llbCancel = New System.Windows.Forms.LinkLabel()
        Me.llbOK = New System.Windows.Forms.LinkLabel()
        Me.tpSearch = New System.Windows.Forms.TabPage()
        Me.llbReset = New System.Windows.Forms.LinkLabel()
        Me.llbCancel_2 = New System.Windows.Forms.LinkLabel()
        Me.llbSearch_2 = New System.Windows.Forms.LinkLabel()
        Me.pnBody = New System.Windows.Forms.Panel()
        Me.dgvBody = New System.Windows.Forms.DataGridView()
        Me.pnFoot = New System.Windows.Forms.Panel()
        Me.llbAmountDetail2 = New System.Windows.Forms.LinkLabel()
        Me.llbUnConfirm = New System.Windows.Forms.LinkLabel()
        Me.llbConfirm = New System.Windows.Forms.LinkLabel()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.txtTotalUser = New System.Windows.Forms.TextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblTotalUser = New System.Windows.Forms.Label()
        Me.txtCPID = New System.Windows.Forms.TextBox()
        Me.txtRecID = New System.Windows.Forms.TextBox()
        Me.llbAmountDetail = New System.Windows.Forms.LinkLabel()
        Me.llbCalcPrice = New System.Windows.Forms.LinkLabel()
        Me.lblCPMonth = New System.Windows.Forms.Label()
        Me.dtpCPMonth = New System.Windows.Forms.DateTimePicker()
        Me.lblCPDate = New System.Windows.Forms.Label()
        Me.dtpCPDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCPID = New System.Windows.Forms.Label()
        Me.lblRecID = New System.Windows.Forms.Label()
        Me.txtCPID_2 = New System.Windows.Forms.TextBox()
        Me.txtRecID_2 = New System.Windows.Forms.TextBox()
        Me.chkConfirmStaff = New System.Windows.Forms.CheckBox()
        Me.chkConfirm = New System.Windows.Forms.CheckBox()
        Me.cboConfirmStaff = New System.Windows.Forms.ComboBox()
        Me.cboConfirmDate = New System.Windows.Forms.ComboBox()
        Me.chkConfirmDate = New System.Windows.Forms.CheckBox()
        Me.dtpConfirmDate = New System.Windows.Forms.DateTimePicker()
        Me.cboCPMonth = New System.Windows.Forms.ComboBox()
        Me.chkCPMonth = New System.Windows.Forms.CheckBox()
        Me.dtpCPMonth_2 = New System.Windows.Forms.DateTimePicker()
        Me.cboCPDate = New System.Windows.Forms.ComboBox()
        Me.chkCPDate = New System.Windows.Forms.CheckBox()
        Me.dtpCPDate_2 = New System.Windows.Forms.DateTimePicker()
        Me.lblCPID_2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnMain.SuspendLayout()
        Me.tcMain.SuspendLayout()
        Me.tpList.SuspendLayout()
        Me.pnGrid.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnMenu.SuspendLayout()
        Me.tpInput.SuspendLayout()
        Me.tpSearch.SuspendLayout()
        Me.pnBody.SuspendLayout()
        CType(Me.dgvBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFoot.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnMain
        '
        Me.pnMain.Controls.Add(Me.tcMain)
        Me.pnMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnMain.Location = New System.Drawing.Point(0, 0)
        Me.pnMain.Name = "pnMain"
        Me.pnMain.Size = New System.Drawing.Size(800, 238)
        Me.pnMain.TabIndex = 1
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tpList)
        Me.tcMain.Controls.Add(Me.tpInput)
        Me.tcMain.Controls.Add(Me.tpSearch)
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(800, 238)
        Me.tcMain.TabIndex = 0
        '
        'tpList
        '
        Me.tpList.BackColor = System.Drawing.SystemColors.Control
        Me.tpList.Controls.Add(Me.pnGrid)
        Me.tpList.Controls.Add(Me.pnMenu)
        Me.tpList.Location = New System.Drawing.Point(4, 22)
        Me.tpList.Name = "tpList"
        Me.tpList.Padding = New System.Windows.Forms.Padding(3)
        Me.tpList.Size = New System.Drawing.Size(792, 212)
        Me.tpList.TabIndex = 0
        Me.tpList.Text = "List"
        '
        'pnGrid
        '
        Me.pnGrid.Controls.Add(Me.dgvMain)
        Me.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnGrid.Location = New System.Drawing.Point(3, 27)
        Me.pnGrid.Name = "pnGrid"
        Me.pnGrid.Size = New System.Drawing.Size(786, 182)
        Me.pnGrid.TabIndex = 6
        '
        'dgvMain
        '
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMain.Location = New System.Drawing.Point(0, 0)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.ReadOnly = True
        Me.dgvMain.Size = New System.Drawing.Size(786, 182)
        Me.dgvMain.TabIndex = 5
        Me.dgvMain.TabStop = False
        '
        'pnMenu
        '
        Me.pnMenu.Controls.Add(Me.llbAmountDetail2)
        Me.pnMenu.Controls.Add(Me.llbUnConfirm)
        Me.pnMenu.Controls.Add(Me.llbConfirm)
        Me.pnMenu.Controls.Add(Me.llbEdit)
        Me.pnMenu.Controls.Add(Me.llbDelete)
        Me.pnMenu.Controls.Add(Me.llbSearch)
        Me.pnMenu.Controls.Add(Me.llbAdd)
        Me.pnMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnMenu.Location = New System.Drawing.Point(3, 3)
        Me.pnMenu.Name = "pnMenu"
        Me.pnMenu.Size = New System.Drawing.Size(786, 24)
        Me.pnMenu.TabIndex = 5
        '
        'llbEdit
        '
        Me.llbEdit.AutoSize = True
        Me.llbEdit.Enabled = False
        Me.llbEdit.Location = New System.Drawing.Point(37, 5)
        Me.llbEdit.Name = "llbEdit"
        Me.llbEdit.Size = New System.Drawing.Size(25, 13)
        Me.llbEdit.TabIndex = 5
        Me.llbEdit.TabStop = True
        Me.llbEdit.Text = "Edit"
        '
        'llbDelete
        '
        Me.llbDelete.AutoSize = True
        Me.llbDelete.Enabled = False
        Me.llbDelete.Location = New System.Drawing.Point(68, 5)
        Me.llbDelete.Name = "llbDelete"
        Me.llbDelete.Size = New System.Drawing.Size(38, 13)
        Me.llbDelete.TabIndex = 6
        Me.llbDelete.TabStop = True
        Me.llbDelete.Text = "Delete"
        '
        'llbSearch
        '
        Me.llbSearch.AutoSize = True
        Me.llbSearch.Location = New System.Drawing.Point(145, 5)
        Me.llbSearch.Name = "llbSearch"
        Me.llbSearch.Size = New System.Drawing.Size(41, 13)
        Me.llbSearch.TabIndex = 7
        Me.llbSearch.TabStop = True
        Me.llbSearch.Text = "Search"
        '
        'llbAdd
        '
        Me.llbAdd.AutoSize = True
        Me.llbAdd.Location = New System.Drawing.Point(5, 5)
        Me.llbAdd.Name = "llbAdd"
        Me.llbAdd.Size = New System.Drawing.Size(26, 13)
        Me.llbAdd.TabIndex = 4
        Me.llbAdd.TabStop = True
        Me.llbAdd.Text = "Add"
        '
        'tpInput
        '
        Me.tpInput.BackColor = System.Drawing.SystemColors.Control
        Me.tpInput.Controls.Add(Me.txtCPID)
        Me.tpInput.Controls.Add(Me.txtRecID)
        Me.tpInput.Controls.Add(Me.llbAmountDetail)
        Me.tpInput.Controls.Add(Me.llbCalcPrice)
        Me.tpInput.Controls.Add(Me.lblCPMonth)
        Me.tpInput.Controls.Add(Me.dtpCPMonth)
        Me.tpInput.Controls.Add(Me.lblCPDate)
        Me.tpInput.Controls.Add(Me.dtpCPDate)
        Me.tpInput.Controls.Add(Me.lblCPID)
        Me.tpInput.Controls.Add(Me.lblRecID)
        Me.tpInput.Controls.Add(Me.llbCancel)
        Me.tpInput.Controls.Add(Me.llbOK)
        Me.tpInput.Location = New System.Drawing.Point(4, 22)
        Me.tpInput.Name = "tpInput"
        Me.tpInput.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInput.Size = New System.Drawing.Size(792, 212)
        Me.tpInput.TabIndex = 1
        Me.tpInput.Text = "Input"
        '
        'llbCancel
        '
        Me.llbCancel.AutoSize = True
        Me.llbCancel.Location = New System.Drawing.Point(36, 3)
        Me.llbCancel.Name = "llbCancel"
        Me.llbCancel.Size = New System.Drawing.Size(40, 13)
        Me.llbCancel.TabIndex = 1
        Me.llbCancel.TabStop = True
        Me.llbCancel.Text = "Cancel"
        '
        'llbOK
        '
        Me.llbOK.AutoSize = True
        Me.llbOK.Location = New System.Drawing.Point(8, 3)
        Me.llbOK.Name = "llbOK"
        Me.llbOK.Size = New System.Drawing.Size(22, 13)
        Me.llbOK.TabIndex = 0
        Me.llbOK.TabStop = True
        Me.llbOK.Text = "OK"
        '
        'tpSearch
        '
        Me.tpSearch.BackColor = System.Drawing.SystemColors.Control
        Me.tpSearch.Controls.Add(Me.txtCPID_2)
        Me.tpSearch.Controls.Add(Me.txtRecID_2)
        Me.tpSearch.Controls.Add(Me.chkConfirmStaff)
        Me.tpSearch.Controls.Add(Me.chkConfirm)
        Me.tpSearch.Controls.Add(Me.cboConfirmStaff)
        Me.tpSearch.Controls.Add(Me.cboConfirmDate)
        Me.tpSearch.Controls.Add(Me.chkConfirmDate)
        Me.tpSearch.Controls.Add(Me.dtpConfirmDate)
        Me.tpSearch.Controls.Add(Me.cboCPMonth)
        Me.tpSearch.Controls.Add(Me.chkCPMonth)
        Me.tpSearch.Controls.Add(Me.dtpCPMonth_2)
        Me.tpSearch.Controls.Add(Me.cboCPDate)
        Me.tpSearch.Controls.Add(Me.chkCPDate)
        Me.tpSearch.Controls.Add(Me.dtpCPDate_2)
        Me.tpSearch.Controls.Add(Me.lblCPID_2)
        Me.tpSearch.Controls.Add(Me.Label4)
        Me.tpSearch.Controls.Add(Me.llbReset)
        Me.tpSearch.Controls.Add(Me.llbCancel_2)
        Me.tpSearch.Controls.Add(Me.llbSearch_2)
        Me.tpSearch.Location = New System.Drawing.Point(4, 22)
        Me.tpSearch.Name = "tpSearch"
        Me.tpSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearch.Size = New System.Drawing.Size(792, 212)
        Me.tpSearch.TabIndex = 2
        Me.tpSearch.Text = "Search"
        '
        'llbReset
        '
        Me.llbReset.AutoSize = True
        Me.llbReset.Location = New System.Drawing.Point(153, 3)
        Me.llbReset.Name = "llbReset"
        Me.llbReset.Size = New System.Drawing.Size(35, 13)
        Me.llbReset.TabIndex = 2
        Me.llbReset.TabStop = True
        Me.llbReset.Text = "Reset"
        '
        'llbCancel_2
        '
        Me.llbCancel_2.AutoSize = True
        Me.llbCancel_2.Location = New System.Drawing.Point(53, 3)
        Me.llbCancel_2.Name = "llbCancel_2"
        Me.llbCancel_2.Size = New System.Drawing.Size(40, 13)
        Me.llbCancel_2.TabIndex = 1
        Me.llbCancel_2.TabStop = True
        Me.llbCancel_2.Text = "Cancel"
        '
        'llbSearch_2
        '
        Me.llbSearch_2.AutoSize = True
        Me.llbSearch_2.Location = New System.Drawing.Point(6, 3)
        Me.llbSearch_2.Name = "llbSearch_2"
        Me.llbSearch_2.Size = New System.Drawing.Size(41, 13)
        Me.llbSearch_2.TabIndex = 0
        Me.llbSearch_2.TabStop = True
        Me.llbSearch_2.Text = "Search"
        '
        'pnBody
        '
        Me.pnBody.Controls.Add(Me.dgvBody)
        Me.pnBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBody.Location = New System.Drawing.Point(0, 238)
        Me.pnBody.Name = "pnBody"
        Me.pnBody.Size = New System.Drawing.Size(800, 175)
        Me.pnBody.TabIndex = 3
        '
        'dgvBody
        '
        Me.dgvBody.AllowUserToAddRows = False
        Me.dgvBody.AllowUserToDeleteRows = False
        Me.dgvBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBody.Location = New System.Drawing.Point(0, 0)
        Me.dgvBody.Name = "dgvBody"
        Me.dgvBody.ReadOnly = True
        Me.dgvBody.Size = New System.Drawing.Size(800, 175)
        Me.dgvBody.TabIndex = 0
        '
        'pnFoot
        '
        Me.pnFoot.Controls.Add(Me.txtTotalAmount)
        Me.pnFoot.Controls.Add(Me.txtTotalUser)
        Me.pnFoot.Controls.Add(Me.lblTotalAmount)
        Me.pnFoot.Controls.Add(Me.lblTotalUser)
        Me.pnFoot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnFoot.Location = New System.Drawing.Point(0, 413)
        Me.pnFoot.Name = "pnFoot"
        Me.pnFoot.Size = New System.Drawing.Size(800, 37)
        Me.pnFoot.TabIndex = 4
        '
        'llbAmountDetail2
        '
        Me.llbAmountDetail2.AutoSize = True
        Me.llbAmountDetail2.Enabled = False
        Me.llbAmountDetail2.Location = New System.Drawing.Point(445, 6)
        Me.llbAmountDetail2.Name = "llbAmountDetail2"
        Me.llbAmountDetail2.Size = New System.Drawing.Size(70, 13)
        Me.llbAmountDetail2.TabIndex = 59
        Me.llbAmountDetail2.TabStop = True
        Me.llbAmountDetail2.Text = "AmountDetail"
        '
        'llbUnConfirm
        '
        Me.llbUnConfirm.AutoSize = True
        Me.llbUnConfirm.Enabled = False
        Me.llbUnConfirm.Location = New System.Drawing.Point(320, 6)
        Me.llbUnConfirm.Name = "llbUnConfirm"
        Me.llbUnConfirm.Size = New System.Drawing.Size(56, 13)
        Me.llbUnConfirm.TabIndex = 58
        Me.llbUnConfirm.TabStop = True
        Me.llbUnConfirm.Text = "UnConfirm"
        '
        'llbConfirm
        '
        Me.llbConfirm.AutoSize = True
        Me.llbConfirm.Enabled = False
        Me.llbConfirm.Location = New System.Drawing.Point(272, 6)
        Me.llbConfirm.Name = "llbConfirm"
        Me.llbConfirm.Size = New System.Drawing.Size(42, 13)
        Me.llbConfirm.TabIndex = 57
        Me.llbConfirm.TabStop = True
        Me.llbConfirm.Text = "Confirm"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Location = New System.Drawing.Point(295, 6)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAmount.TabIndex = 73
        Me.txtTotalAmount.TabStop = False
        Me.txtTotalAmount.Text = "0"
        '
        'txtTotalUser
        '
        Me.txtTotalUser.Location = New System.Drawing.Point(78, 6)
        Me.txtTotalUser.Name = "txtTotalUser"
        Me.txtTotalUser.ReadOnly = True
        Me.txtTotalUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalUser.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalUser.TabIndex = 72
        Me.txtTotalUser.TabStop = False
        Me.txtTotalUser.Text = "0"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(222, 10)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(67, 13)
        Me.lblTotalAmount.TabIndex = 71
        Me.lblTotalAmount.Text = "TotalAmount"
        '
        'lblTotalUser
        '
        Me.lblTotalUser.AutoSize = True
        Me.lblTotalUser.Location = New System.Drawing.Point(19, 10)
        Me.lblTotalUser.Name = "lblTotalUser"
        Me.lblTotalUser.Size = New System.Drawing.Size(53, 13)
        Me.lblTotalUser.TabIndex = 70
        Me.lblTotalUser.Text = "TotalUser"
        '
        'txtCPID
        '
        Me.txtCPID.Location = New System.Drawing.Point(66, 55)
        Me.txtCPID.Name = "txtCPID"
        Me.txtCPID.ReadOnly = True
        Me.txtCPID.Size = New System.Drawing.Size(50, 20)
        Me.txtCPID.TabIndex = 61
        Me.txtCPID.TabStop = False
        '
        'txtRecID
        '
        Me.txtRecID.Location = New System.Drawing.Point(66, 29)
        Me.txtRecID.Name = "txtRecID"
        Me.txtRecID.ReadOnly = True
        Me.txtRecID.Size = New System.Drawing.Size(50, 20)
        Me.txtRecID.TabIndex = 60
        Me.txtRecID.TabStop = False
        '
        'llbAmountDetail
        '
        Me.llbAmountDetail.AutoSize = True
        Me.llbAmountDetail.Enabled = False
        Me.llbAmountDetail.Location = New System.Drawing.Point(167, 3)
        Me.llbAmountDetail.Name = "llbAmountDetail"
        Me.llbAmountDetail.Size = New System.Drawing.Size(70, 13)
        Me.llbAmountDetail.TabIndex = 65
        Me.llbAmountDetail.TabStop = True
        Me.llbAmountDetail.Text = "AmountDetail"
        '
        'llbCalcPrice
        '
        Me.llbCalcPrice.AutoSize = True
        Me.llbCalcPrice.Location = New System.Drawing.Point(109, 3)
        Me.llbCalcPrice.Name = "llbCalcPrice"
        Me.llbCalcPrice.Size = New System.Drawing.Size(52, 13)
        Me.llbCalcPrice.TabIndex = 64
        Me.llbCalcPrice.TabStop = True
        Me.llbCalcPrice.Text = "CalcPrice"
        '
        'lblCPMonth
        '
        Me.lblCPMonth.AutoSize = True
        Me.lblCPMonth.Location = New System.Drawing.Point(255, 33)
        Me.lblCPMonth.Name = "lblCPMonth"
        Me.lblCPMonth.Size = New System.Drawing.Size(51, 13)
        Me.lblCPMonth.TabIndex = 69
        Me.lblCPMonth.Text = "CPMonth"
        '
        'dtpCPMonth
        '
        Me.dtpCPMonth.CustomFormat = "MM/yyyy"
        Me.dtpCPMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPMonth.Location = New System.Drawing.Point(312, 29)
        Me.dtpCPMonth.Name = "dtpCPMonth"
        Me.dtpCPMonth.ShowUpDown = True
        Me.dtpCPMonth.Size = New System.Drawing.Size(78, 20)
        Me.dtpCPMonth.TabIndex = 63
        '
        'lblCPDate
        '
        Me.lblCPDate.AutoSize = True
        Me.lblCPDate.Location = New System.Drawing.Point(16, 85)
        Me.lblCPDate.Name = "lblCPDate"
        Me.lblCPDate.Size = New System.Drawing.Size(44, 13)
        Me.lblCPDate.TabIndex = 68
        Me.lblCPDate.Text = "CPDate"
        '
        'dtpCPDate
        '
        Me.dtpCPDate.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtpCPDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCPDate.Enabled = False
        Me.dtpCPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPDate.Location = New System.Drawing.Point(66, 81)
        Me.dtpCPDate.Name = "dtpCPDate"
        Me.dtpCPDate.Size = New System.Drawing.Size(95, 20)
        Me.dtpCPDate.TabIndex = 62
        Me.dtpCPDate.TabStop = False
        '
        'lblCPID
        '
        Me.lblCPID.AutoSize = True
        Me.lblCPID.Location = New System.Drawing.Point(28, 59)
        Me.lblCPID.Name = "lblCPID"
        Me.lblCPID.Size = New System.Drawing.Size(32, 13)
        Me.lblCPID.TabIndex = 67
        Me.lblCPID.Text = "CPID"
        '
        'lblRecID
        '
        Me.lblRecID.AutoSize = True
        Me.lblRecID.Location = New System.Drawing.Point(22, 33)
        Me.lblRecID.Name = "lblRecID"
        Me.lblRecID.Size = New System.Drawing.Size(38, 13)
        Me.lblRecID.TabIndex = 66
        Me.lblRecID.Text = "RecID"
        '
        'txtCPID_2
        '
        Me.txtCPID_2.Location = New System.Drawing.Point(85, 57)
        Me.txtCPID_2.Name = "txtCPID_2"
        Me.txtCPID_2.Size = New System.Drawing.Size(110, 20)
        Me.txtCPID_2.TabIndex = 75
        '
        'txtRecID_2
        '
        Me.txtRecID_2.Location = New System.Drawing.Point(85, 31)
        Me.txtRecID_2.Name = "txtRecID_2"
        Me.txtRecID_2.Size = New System.Drawing.Size(50, 20)
        Me.txtRecID_2.TabIndex = 74
        '
        'chkConfirmStaff
        '
        Me.chkConfirmStaff.AutoSize = True
        Me.chkConfirmStaff.Location = New System.Drawing.Point(293, 110)
        Me.chkConfirmStaff.Name = "chkConfirmStaff"
        Me.chkConfirmStaff.Size = New System.Drawing.Size(83, 17)
        Me.chkConfirmStaff.TabIndex = 86
        Me.chkConfirmStaff.Text = "ConfirmStaff"
        Me.chkConfirmStaff.UseVisualStyleBackColor = True
        '
        'chkConfirm
        '
        Me.chkConfirm.AutoSize = True
        Me.chkConfirm.Location = New System.Drawing.Point(293, 58)
        Me.chkConfirm.Name = "chkConfirm"
        Me.chkConfirm.Size = New System.Drawing.Size(73, 17)
        Me.chkConfirm.TabIndex = 82
        Me.chkConfirm.Text = "Confirmed"
        Me.chkConfirm.UseVisualStyleBackColor = True
        '
        'cboConfirmStaff
        '
        Me.cboConfirmStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConfirmStaff.Enabled = False
        Me.cboConfirmStaff.FormattingEnabled = True
        Me.cboConfirmStaff.Location = New System.Drawing.Point(382, 108)
        Me.cboConfirmStaff.Name = "cboConfirmStaff"
        Me.cboConfirmStaff.Size = New System.Drawing.Size(100, 21)
        Me.cboConfirmStaff.TabIndex = 87
        Me.cboConfirmStaff.TabStop = False
        '
        'cboConfirmDate
        '
        Me.cboConfirmDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConfirmDate.Enabled = False
        Me.cboConfirmDate.FormattingEnabled = True
        Me.cboConfirmDate.Items.AddRange(New Object() {"=", ">", ">=", "<", "<="})
        Me.cboConfirmDate.Location = New System.Drawing.Point(382, 81)
        Me.cboConfirmDate.Name = "cboConfirmDate"
        Me.cboConfirmDate.Size = New System.Drawing.Size(39, 21)
        Me.cboConfirmDate.TabIndex = 84
        Me.cboConfirmDate.TabStop = False
        '
        'chkConfirmDate
        '
        Me.chkConfirmDate.AutoSize = True
        Me.chkConfirmDate.Location = New System.Drawing.Point(293, 83)
        Me.chkConfirmDate.Name = "chkConfirmDate"
        Me.chkConfirmDate.Size = New System.Drawing.Size(84, 17)
        Me.chkConfirmDate.TabIndex = 83
        Me.chkConfirmDate.Text = "ConfirmDate"
        Me.chkConfirmDate.UseVisualStyleBackColor = True
        '
        'dtpConfirmDate
        '
        Me.dtpConfirmDate.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtpConfirmDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpConfirmDate.Enabled = False
        Me.dtpConfirmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpConfirmDate.Location = New System.Drawing.Point(427, 81)
        Me.dtpConfirmDate.Name = "dtpConfirmDate"
        Me.dtpConfirmDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpConfirmDate.TabIndex = 85
        Me.dtpConfirmDate.TabStop = False
        '
        'cboCPMonth
        '
        Me.cboCPMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCPMonth.Enabled = False
        Me.cboCPMonth.FormattingEnabled = True
        Me.cboCPMonth.Items.AddRange(New Object() {"=", ">", ">=", "<", "<="})
        Me.cboCPMonth.Location = New System.Drawing.Point(362, 31)
        Me.cboCPMonth.Name = "cboCPMonth"
        Me.cboCPMonth.Size = New System.Drawing.Size(39, 21)
        Me.cboCPMonth.TabIndex = 80
        Me.cboCPMonth.TabStop = False
        '
        'chkCPMonth
        '
        Me.chkCPMonth.AutoSize = True
        Me.chkCPMonth.Location = New System.Drawing.Point(293, 33)
        Me.chkCPMonth.Name = "chkCPMonth"
        Me.chkCPMonth.Size = New System.Drawing.Size(70, 17)
        Me.chkCPMonth.TabIndex = 79
        Me.chkCPMonth.Text = "CPMonth"
        Me.chkCPMonth.UseVisualStyleBackColor = True
        '
        'dtpCPMonth_2
        '
        Me.dtpCPMonth_2.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtpCPMonth_2.CustomFormat = "MM/yyyy"
        Me.dtpCPMonth_2.Enabled = False
        Me.dtpCPMonth_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPMonth_2.Location = New System.Drawing.Point(407, 31)
        Me.dtpCPMonth_2.Name = "dtpCPMonth_2"
        Me.dtpCPMonth_2.Size = New System.Drawing.Size(78, 20)
        Me.dtpCPMonth_2.TabIndex = 81
        Me.dtpCPMonth_2.TabStop = False
        '
        'cboCPDate
        '
        Me.cboCPDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCPDate.Enabled = False
        Me.cboCPDate.FormattingEnabled = True
        Me.cboCPDate.Items.AddRange(New Object() {"=", ">", ">=", "<", "<="})
        Me.cboCPDate.Location = New System.Drawing.Point(85, 83)
        Me.cboCPDate.Name = "cboCPDate"
        Me.cboCPDate.Size = New System.Drawing.Size(39, 21)
        Me.cboCPDate.TabIndex = 77
        Me.cboCPDate.TabStop = False
        '
        'chkCPDate
        '
        Me.chkCPDate.AutoSize = True
        Me.chkCPDate.Location = New System.Drawing.Point(16, 85)
        Me.chkCPDate.Name = "chkCPDate"
        Me.chkCPDate.Size = New System.Drawing.Size(63, 17)
        Me.chkCPDate.TabIndex = 76
        Me.chkCPDate.Text = "CPDate"
        Me.chkCPDate.UseVisualStyleBackColor = True
        '
        'dtpCPDate_2
        '
        Me.dtpCPDate_2.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtpCPDate_2.CustomFormat = "dd/MM/yyyy"
        Me.dtpCPDate_2.Enabled = False
        Me.dtpCPDate_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPDate_2.Location = New System.Drawing.Point(130, 83)
        Me.dtpCPDate_2.Name = "dtpCPDate_2"
        Me.dtpCPDate_2.Size = New System.Drawing.Size(95, 20)
        Me.dtpCPDate_2.TabIndex = 78
        Me.dtpCPDate_2.TabStop = False
        '
        'lblCPID_2
        '
        Me.lblCPID_2.AutoSize = True
        Me.lblCPID_2.Location = New System.Drawing.Point(47, 61)
        Me.lblCPID_2.Name = "lblCPID_2"
        Me.lblCPID_2.Size = New System.Drawing.Size(32, 13)
        Me.lblCPID_2.TabIndex = 89
        Me.lblCPID_2.Text = "CPID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "RecID"
        '
        'frmCalcPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnBody)
        Me.Controls.Add(Me.pnFoot)
        Me.Controls.Add(Me.pnMain)
        Me.Name = "frmCalcPrice"
        Me.Text = "frmCalcPrice"
        Me.pnMain.ResumeLayout(False)
        Me.tcMain.ResumeLayout(False)
        Me.tpList.ResumeLayout(False)
        Me.pnGrid.ResumeLayout(False)
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnMenu.ResumeLayout(False)
        Me.pnMenu.PerformLayout()
        Me.tpInput.ResumeLayout(False)
        Me.tpInput.PerformLayout()
        Me.tpSearch.ResumeLayout(False)
        Me.tpSearch.PerformLayout()
        Me.pnBody.ResumeLayout(False)
        CType(Me.dgvBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFoot.ResumeLayout(False)
        Me.pnFoot.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Protected WithEvents pnMain As Panel
    Protected WithEvents tcMain As TabControl
    Protected WithEvents tpList As TabPage
    Protected WithEvents pnGrid As Panel
    Protected WithEvents dgvMain As DataGridView
    Protected WithEvents pnMenu As Panel
    Protected WithEvents llbEdit As LinkLabel
    Protected WithEvents llbDelete As LinkLabel
    Protected WithEvents llbSearch As LinkLabel
    Protected WithEvents llbAdd As LinkLabel
    Protected WithEvents tpInput As TabPage
    Protected WithEvents llbCancel As LinkLabel
    Protected WithEvents llbOK As LinkLabel
    Protected WithEvents tpSearch As TabPage
    Protected WithEvents llbReset As LinkLabel
    Protected WithEvents llbCancel_2 As LinkLabel
    Protected WithEvents llbSearch_2 As LinkLabel
    Protected WithEvents pnBody As Panel
    Protected WithEvents dgvBody As DataGridView
    Protected WithEvents pnFoot As Panel
    Friend WithEvents llbAmountDetail2 As LinkLabel
    Friend WithEvents llbUnConfirm As LinkLabel
    Friend WithEvents llbConfirm As LinkLabel
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents txtTotalUser As TextBox
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblTotalUser As Label
    Friend WithEvents txtCPID As TextBox
    Friend WithEvents txtRecID As TextBox
    Friend WithEvents llbAmountDetail As LinkLabel
    Friend WithEvents llbCalcPrice As LinkLabel
    Friend WithEvents lblCPMonth As Label
    Friend WithEvents dtpCPMonth As DateTimePicker
    Friend WithEvents lblCPDate As Label
    Friend WithEvents dtpCPDate As DateTimePicker
    Friend WithEvents lblCPID As Label
    Friend WithEvents lblRecID As Label
    Friend WithEvents txtCPID_2 As TextBox
    Friend WithEvents txtRecID_2 As TextBox
    Friend WithEvents chkConfirmStaff As CheckBox
    Friend WithEvents chkConfirm As CheckBox
    Friend WithEvents cboConfirmStaff As ComboBox
    Friend WithEvents cboConfirmDate As ComboBox
    Friend WithEvents chkConfirmDate As CheckBox
    Friend WithEvents dtpConfirmDate As DateTimePicker
    Friend WithEvents cboCPMonth As ComboBox
    Friend WithEvents chkCPMonth As CheckBox
    Friend WithEvents dtpCPMonth_2 As DateTimePicker
    Friend WithEvents cboCPDate As ComboBox
    Friend WithEvents chkCPDate As CheckBox
    Friend WithEvents dtpCPDate_2 As DateTimePicker
    Friend WithEvents lblCPID_2 As Label
    Friend WithEvents Label4 As Label
End Class
