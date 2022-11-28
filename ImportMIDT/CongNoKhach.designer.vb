<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDC_Pax
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ChotNo = New System.Windows.Forms.TabPage()
        Me.PnlInvoicing = New System.Windows.Forms.Panel()
        Me.llbInvoicingList = New System.Windows.Forms.LinkLabel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.LblUnCheckALL = New System.Windows.Forms.LinkLabel()
        Me.CmdQuickInvVND = New System.Windows.Forms.Button()
        Me.CmdQuickInvUSD = New System.Windows.Forms.Button()
        Me.txtUpto = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GridNo = New System.Windows.Forms.DataGridView()
        Me.S = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CmbInvoiceCurr = New System.Windows.Forms.ComboBox()
        Me.ThanhToan = New System.Windows.Forms.TabPage()
        Me.PnlApplyPayments = New System.Windows.Forms.Panel()
        Me.LblListDetail = New System.Windows.Forms.LinkLabel()
        Me.LbLSplitPmt = New System.Windows.Forms.LinkLabel()
        Me.TxtWriteOffNo = New System.Windows.Forms.TextBox()
        Me.txtWriteOffTra = New System.Windows.Forms.TextBox()
        Me.LckLblWriteOffNo = New System.Windows.Forms.LinkLabel()
        Me.LckLblWriteOffTra = New System.Windows.Forms.LinkLabel()
        Me.GridTraChoKhoanNao = New System.Windows.Forms.DataGridView()
        Me.CmdApply = New System.Windows.Forms.Button()
        Me.GrpCreateCN = New System.Windows.Forms.GroupBox()
        Me.LblPrint = New System.Windows.Forms.LinkLabel()
        Me.CmdAddPayment = New System.Windows.Forms.Button()
        Me.txtPmtDate = New System.Windows.Forms.DateTimePicker()
        Me.CmbPmtType = New System.Windows.Forms.ComboBox()
        Me.CmbCNFOP = New System.Windows.Forms.ComboBox()
        Me.CmbCNCurr = New System.Windows.Forms.ComboBox()
        Me.txtCNDocNo = New System.Windows.Forms.TextBox()
        Me.txtCNDescription = New System.Windows.Forms.TextBox()
        Me.txtCNAmount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPmtType = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CmbReceivedBy = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridDungTienNao = New System.Windows.Forms.DataGridView()
        Me.txtAvailable = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabROE = New System.Windows.Forms.TabPage()
        Me.GrpPmtFollowUp = New System.Windows.Forms.GroupBox()
        Me.llbExportExcel = New System.Windows.Forms.LinkLabel()
        Me.ChkSelectCustOnly = New System.Windows.Forms.CheckBox()
        Me.LblUpdateCFM_VAT = New System.Windows.Forms.LinkLabel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtCFM_VAT = New System.Windows.Forms.DateTimePicker()
        Me.GridPendingINV = New System.Windows.Forms.DataGridView()
        Me.GrpNegoCurr = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Cmb1Curr = New System.Windows.Forms.ComboBox()
        Me.CmbEQnCurr = New System.Windows.Forms.ComboBox()
        Me.TxtNegoROE = New System.Windows.Forms.TextBox()
        Me.CmbInvoiceAL = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbCustomer = New System.Windows.Forms.ComboBox()
        Me.txtCustFullName = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PadForExRule = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarInvoiceDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPurchaseDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPaymentDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarNego = New System.Windows.Forms.ToolStripMenuItem()
        Me.PadAction = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDeleteThisPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarUnlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarMarkSelectedAsUnpaid = New System.Windows.Forms.ToolStripMenuItem()
        Me.PadFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDueOnly = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarIncludeFullyUsed = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAllPaymentType = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.ChotNo.SuspendLayout()
        Me.PnlInvoicing.SuspendLayout()
        CType(Me.GridNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ThanhToan.SuspendLayout()
        Me.PnlApplyPayments.SuspendLayout()
        CType(Me.GridTraChoKhoanNao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCreateCN.SuspendLayout()
        CType(Me.GridDungTienNao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabROE.SuspendLayout()
        Me.GrpPmtFollowUp.SuspendLayout()
        CType(Me.GridPendingINV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNegoCurr.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.ChotNo)
        Me.TabControl1.Controls.Add(Me.ThanhToan)
        Me.TabControl1.Controls.Add(Me.TabROE)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 22)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(798, 515)
        Me.TabControl1.TabIndex = 0
        '
        'ChotNo
        '
        Me.ChotNo.Controls.Add(Me.PnlInvoicing)
        Me.ChotNo.Location = New System.Drawing.Point(4, 24)
        Me.ChotNo.Name = "ChotNo"
        Me.ChotNo.Padding = New System.Windows.Forms.Padding(3)
        Me.ChotNo.Size = New System.Drawing.Size(790, 487)
        Me.ChotNo.TabIndex = 1
        Me.ChotNo.Text = "Invoicing"
        Me.ChotNo.UseVisualStyleBackColor = True
        '
        'PnlInvoicing
        '
        Me.PnlInvoicing.Controls.Add(Me.llbInvoicingList)
        Me.PnlInvoicing.Controls.Add(Me.Label16)
        Me.PnlInvoicing.Controls.Add(Me.txtInvoiceDate)
        Me.PnlInvoicing.Controls.Add(Me.LblUnCheckALL)
        Me.PnlInvoicing.Controls.Add(Me.CmdQuickInvVND)
        Me.PnlInvoicing.Controls.Add(Me.CmdQuickInvUSD)
        Me.PnlInvoicing.Controls.Add(Me.txtUpto)
        Me.PnlInvoicing.Controls.Add(Me.Label8)
        Me.PnlInvoicing.Controls.Add(Me.txtDueDate)
        Me.PnlInvoicing.Controls.Add(Me.Label17)
        Me.PnlInvoicing.Controls.Add(Me.Label7)
        Me.PnlInvoicing.Controls.Add(Me.GridNo)
        Me.PnlInvoicing.Controls.Add(Me.CmbInvoiceCurr)
        Me.PnlInvoicing.Enabled = False
        Me.PnlInvoicing.Location = New System.Drawing.Point(-2, 3)
        Me.PnlInvoicing.Name = "PnlInvoicing"
        Me.PnlInvoicing.Size = New System.Drawing.Size(791, 486)
        Me.PnlInvoicing.TabIndex = 14
        '
        'llbInvoicingList
        '
        Me.llbInvoicingList.AutoSize = True
        Me.llbInvoicingList.Location = New System.Drawing.Point(8, 464)
        Me.llbInvoicingList.Name = "llbInvoicingList"
        Me.llbInvoicingList.Size = New System.Drawing.Size(74, 15)
        Me.llbInvoicingList.TabIndex = 26
        Me.llbInvoicingList.TabStop = True
        Me.llbInvoicingList.Text = "InvoicingList"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 38)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 15)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Invoice Date"
        '
        'txtInvoiceDate
        '
        Me.txtInvoiceDate.CustomFormat = "dd-MMM-yy"
        Me.txtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtInvoiceDate.Location = New System.Drawing.Point(80, 34)
        Me.txtInvoiceDate.Name = "txtInvoiceDate"
        Me.txtInvoiceDate.Size = New System.Drawing.Size(82, 21)
        Me.txtInvoiceDate.TabIndex = 24
        '
        'LblUnCheckALL
        '
        Me.LblUnCheckALL.AutoSize = True
        Me.LblUnCheckALL.Location = New System.Drawing.Point(84, 464)
        Me.LblUnCheckALL.Name = "LblUnCheckALL"
        Me.LblUnCheckALL.Size = New System.Drawing.Size(78, 15)
        Me.LblUnCheckALL.TabIndex = 23
        Me.LblUnCheckALL.TabStop = True
        Me.LblUnCheckALL.Text = "UnCheckALL"
        '
        'CmdQuickInvVND
        '
        Me.CmdQuickInvVND.Location = New System.Drawing.Point(3, 138)
        Me.CmdQuickInvVND.Name = "CmdQuickInvVND"
        Me.CmdQuickInvVND.Size = New System.Drawing.Size(158, 23)
        Me.CmdQuickInvVND.TabIndex = 22
        Me.CmdQuickInvVND.Tag = "VND"
        Me.CmdQuickInvVND.Text = "Quick Invoicing VND"
        Me.CmdQuickInvVND.UseVisualStyleBackColor = True
        '
        'CmdQuickInvUSD
        '
        Me.CmdQuickInvUSD.Location = New System.Drawing.Point(3, 109)
        Me.CmdQuickInvUSD.Name = "CmdQuickInvUSD"
        Me.CmdQuickInvUSD.Size = New System.Drawing.Size(158, 23)
        Me.CmdQuickInvUSD.TabIndex = 22
        Me.CmdQuickInvUSD.Tag = "USD"
        Me.CmdQuickInvUSD.Text = "Quick Invoicing USD"
        Me.CmdQuickInvUSD.UseVisualStyleBackColor = True
        Me.CmdQuickInvUSD.Visible = False
        '
        'txtUpto
        '
        Me.txtUpto.CustomFormat = "dd-MMM-yy"
        Me.txtUpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtUpto.Location = New System.Drawing.Point(80, 59)
        Me.txtUpto.Name = "txtUpto"
        Me.txtUpto.Size = New System.Drawing.Size(82, 21)
        Me.txtUpto.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Period Upto"
        '
        'txtDueDate
        '
        Me.txtDueDate.CustomFormat = "dd-MMM-yy"
        Me.txtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDueDate.Location = New System.Drawing.Point(79, 84)
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Size = New System.Drawing.Size(82, 21)
        Me.txtDueDate.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 15)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Due Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Invoice Currency"
        '
        'GridNo
        '
        Me.GridNo.AllowUserToAddRows = False
        Me.GridNo.AllowUserToDeleteRows = False
        Me.GridNo.BackgroundColor = System.Drawing.Color.FloralWhite
        Me.GridNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.S})
        Me.GridNo.Location = New System.Drawing.Point(166, 3)
        Me.GridNo.Name = "GridNo"
        Me.GridNo.RowHeadersVisible = False
        Me.GridNo.Size = New System.Drawing.Size(626, 480)
        Me.GridNo.TabIndex = 2
        '
        'S
        '
        Me.S.HeaderText = "S"
        Me.S.Name = "S"
        '
        'CmbInvoiceCurr
        '
        Me.CmbInvoiceCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbInvoiceCurr.FormattingEnabled = True
        Me.CmbInvoiceCurr.Location = New System.Drawing.Point(97, 5)
        Me.CmbInvoiceCurr.Name = "CmbInvoiceCurr"
        Me.CmbInvoiceCurr.Size = New System.Drawing.Size(64, 23)
        Me.CmbInvoiceCurr.TabIndex = 6
        '
        'ThanhToan
        '
        Me.ThanhToan.Controls.Add(Me.PnlApplyPayments)
        Me.ThanhToan.Location = New System.Drawing.Point(4, 24)
        Me.ThanhToan.Name = "ThanhToan"
        Me.ThanhToan.Size = New System.Drawing.Size(790, 487)
        Me.ThanhToan.TabIndex = 3
        Me.ThanhToan.Text = "Apply Payment"
        Me.ThanhToan.UseVisualStyleBackColor = True
        '
        'PnlApplyPayments
        '
        Me.PnlApplyPayments.Controls.Add(Me.LblListDetail)
        Me.PnlApplyPayments.Controls.Add(Me.LbLSplitPmt)
        Me.PnlApplyPayments.Controls.Add(Me.TxtWriteOffNo)
        Me.PnlApplyPayments.Controls.Add(Me.txtWriteOffTra)
        Me.PnlApplyPayments.Controls.Add(Me.LckLblWriteOffNo)
        Me.PnlApplyPayments.Controls.Add(Me.LckLblWriteOffTra)
        Me.PnlApplyPayments.Controls.Add(Me.GridTraChoKhoanNao)
        Me.PnlApplyPayments.Controls.Add(Me.CmdApply)
        Me.PnlApplyPayments.Controls.Add(Me.GrpCreateCN)
        Me.PnlApplyPayments.Controls.Add(Me.GridDungTienNao)
        Me.PnlApplyPayments.Controls.Add(Me.txtAvailable)
        Me.PnlApplyPayments.Controls.Add(Me.Label5)
        Me.PnlApplyPayments.Enabled = False
        Me.PnlApplyPayments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlApplyPayments.Location = New System.Drawing.Point(0, 0)
        Me.PnlApplyPayments.Name = "PnlApplyPayments"
        Me.PnlApplyPayments.Size = New System.Drawing.Size(796, 491)
        Me.PnlApplyPayments.TabIndex = 6
        '
        'LblListDetail
        '
        Me.LblListDetail.AutoSize = True
        Me.LblListDetail.Location = New System.Drawing.Point(4, 443)
        Me.LblListDetail.Name = "LblListDetail"
        Me.LblListDetail.Size = New System.Drawing.Size(62, 16)
        Me.LblListDetail.TabIndex = 33
        Me.LblListDetail.TabStop = True
        Me.LblListDetail.Text = "ListDetail"
        Me.LblListDetail.Visible = False
        '
        'LbLSplitPmt
        '
        Me.LbLSplitPmt.AutoSize = True
        Me.LbLSplitPmt.Location = New System.Drawing.Point(337, 244)
        Me.LbLSplitPmt.Name = "LbLSplitPmt"
        Me.LbLSplitPmt.Size = New System.Drawing.Size(59, 16)
        Me.LbLSplitPmt.TabIndex = 30
        Me.LbLSplitPmt.TabStop = True
        Me.LbLSplitPmt.Text = "Split Pmt"
        '
        'TxtWriteOffNo
        '
        Me.TxtWriteOffNo.Location = New System.Drawing.Point(722, 440)
        Me.TxtWriteOffNo.Name = "TxtWriteOffNo"
        Me.TxtWriteOffNo.Size = New System.Drawing.Size(65, 22)
        Me.TxtWriteOffNo.TabIndex = 17
        Me.TxtWriteOffNo.Text = "0"
        Me.TxtWriteOffNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtWriteOffNo.Visible = False
        '
        'txtWriteOffTra
        '
        Me.txtWriteOffTra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWriteOffTra.Location = New System.Drawing.Point(722, 241)
        Me.txtWriteOffTra.Name = "txtWriteOffTra"
        Me.txtWriteOffTra.Size = New System.Drawing.Size(65, 22)
        Me.txtWriteOffTra.TabIndex = 17
        Me.txtWriteOffTra.Text = "0"
        Me.txtWriteOffTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWriteOffTra.Visible = False
        '
        'LckLblWriteOffNo
        '
        Me.LckLblWriteOffNo.AutoSize = True
        Me.LckLblWriteOffNo.Location = New System.Drawing.Point(582, 443)
        Me.LckLblWriteOffNo.Name = "LckLblWriteOffNo"
        Me.LckLblWriteOffNo.Size = New System.Drawing.Size(64, 16)
        Me.LckLblWriteOffNo.TabIndex = 16
        Me.LckLblWriteOffNo.TabStop = True
        Me.LckLblWriteOffNo.Text = "WriteOff_I"
        Me.LckLblWriteOffNo.Visible = False
        '
        'LckLblWriteOffTra
        '
        Me.LckLblWriteOffTra.AutoSize = True
        Me.LckLblWriteOffTra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LckLblWriteOffTra.Location = New System.Drawing.Point(613, 244)
        Me.LckLblWriteOffTra.Name = "LckLblWriteOffTra"
        Me.LckLblWriteOffTra.Size = New System.Drawing.Size(70, 16)
        Me.LckLblWriteOffTra.TabIndex = 16
        Me.LckLblWriteOffTra.TabStop = True
        Me.LckLblWriteOffTra.Text = "WriteOff_P"
        Me.LckLblWriteOffTra.Visible = False
        '
        'GridTraChoKhoanNao
        '
        Me.GridTraChoKhoanNao.AllowUserToAddRows = False
        Me.GridTraChoKhoanNao.AllowUserToDeleteRows = False
        Me.GridTraChoKhoanNao.BackgroundColor = System.Drawing.Color.Azure
        Me.GridTraChoKhoanNao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTraChoKhoanNao.Location = New System.Drawing.Point(0, 267)
        Me.GridTraChoKhoanNao.Name = "GridTraChoKhoanNao"
        Me.GridTraChoKhoanNao.RowHeadersVisible = False
        Me.GridTraChoKhoanNao.Size = New System.Drawing.Size(788, 172)
        Me.GridTraChoKhoanNao.TabIndex = 1
        '
        'CmdApply
        '
        Me.CmdApply.Location = New System.Drawing.Point(230, 240)
        Me.CmdApply.Name = "CmdApply"
        Me.CmdApply.Size = New System.Drawing.Size(73, 24)
        Me.CmdApply.TabIndex = 2
        Me.CmdApply.Text = "Apply"
        Me.CmdApply.UseVisualStyleBackColor = True
        '
        'GrpCreateCN
        '
        Me.GrpCreateCN.Controls.Add(Me.LblPrint)
        Me.GrpCreateCN.Controls.Add(Me.CmdAddPayment)
        Me.GrpCreateCN.Controls.Add(Me.txtPmtDate)
        Me.GrpCreateCN.Controls.Add(Me.CmbPmtType)
        Me.GrpCreateCN.Controls.Add(Me.CmbCNFOP)
        Me.GrpCreateCN.Controls.Add(Me.CmbCNCurr)
        Me.GrpCreateCN.Controls.Add(Me.txtCNDocNo)
        Me.GrpCreateCN.Controls.Add(Me.txtCNDescription)
        Me.GrpCreateCN.Controls.Add(Me.txtCNAmount)
        Me.GrpCreateCN.Controls.Add(Me.Label3)
        Me.GrpCreateCN.Controls.Add(Me.Label12)
        Me.GrpCreateCN.Controls.Add(Me.Label15)
        Me.GrpCreateCN.Controls.Add(Me.txtPmtType)
        Me.GrpCreateCN.Controls.Add(Me.Label2)
        Me.GrpCreateCN.Controls.Add(Me.Label13)
        Me.GrpCreateCN.Controls.Add(Me.Label14)
        Me.GrpCreateCN.Controls.Add(Me.CmbReceivedBy)
        Me.GrpCreateCN.Controls.Add(Me.Label4)
        Me.GrpCreateCN.Location = New System.Drawing.Point(3, 6)
        Me.GrpCreateCN.Name = "GrpCreateCN"
        Me.GrpCreateCN.Size = New System.Drawing.Size(615, 99)
        Me.GrpCreateCN.TabIndex = 10
        Me.GrpCreateCN.TabStop = False
        Me.GrpCreateCN.Text = "Receive Payment / Create CN"
        '
        'LblPrint
        '
        Me.LblPrint.AutoSize = True
        Me.LblPrint.Location = New System.Drawing.Point(334, 48)
        Me.LblPrint.Name = "LblPrint"
        Me.LblPrint.Size = New System.Drawing.Size(33, 16)
        Me.LblPrint.TabIndex = 13
        Me.LblPrint.TabStop = True
        Me.LblPrint.Text = "Print"
        Me.LblPrint.Visible = False
        '
        'CmdAddPayment
        '
        Me.CmdAddPayment.Enabled = False
        Me.CmdAddPayment.Location = New System.Drawing.Point(475, 71)
        Me.CmdAddPayment.Name = "CmdAddPayment"
        Me.CmdAddPayment.Size = New System.Drawing.Size(135, 23)
        Me.CmdAddPayment.TabIndex = 12
        Me.CmdAddPayment.Text = "Add Payment"
        Me.CmdAddPayment.UseVisualStyleBackColor = True
        '
        'txtPmtDate
        '
        Me.txtPmtDate.CustomFormat = "dd-MMM-yy"
        Me.txtPmtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPmtDate.Location = New System.Drawing.Point(59, 45)
        Me.txtPmtDate.Name = "txtPmtDate"
        Me.txtPmtDate.Size = New System.Drawing.Size(123, 22)
        Me.txtPmtDate.TabIndex = 4
        '
        'CmbPmtType
        '
        Me.CmbPmtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPmtType.FormattingEnabled = True
        Me.CmbPmtType.Items.AddRange(New Object() {"PSP", "PPD", "C/N"})
        Me.CmbPmtType.Location = New System.Drawing.Point(227, 19)
        Me.CmbPmtType.Name = "CmbPmtType"
        Me.CmbPmtType.Size = New System.Drawing.Size(73, 24)
        Me.CmbPmtType.TabIndex = 1
        '
        'CmbCNFOP
        '
        Me.CmbCNFOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCNFOP.FormattingEnabled = True
        Me.CmbCNFOP.Location = New System.Drawing.Point(227, 45)
        Me.CmbCNFOP.Name = "CmbCNFOP"
        Me.CmbCNFOP.Size = New System.Drawing.Size(73, 24)
        Me.CmbCNFOP.TabIndex = 5
        '
        'CmbCNCurr
        '
        Me.CmbCNCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCNCurr.FormattingEnabled = True
        Me.CmbCNCurr.Location = New System.Drawing.Point(337, 19)
        Me.CmbCNCurr.Name = "CmbCNCurr"
        Me.CmbCNCurr.Size = New System.Drawing.Size(68, 24)
        Me.CmbCNCurr.TabIndex = 2
        '
        'txtCNDocNo
        '
        Me.txtCNDocNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCNDocNo.Location = New System.Drawing.Point(59, 19)
        Me.txtCNDocNo.Name = "txtCNDocNo"
        Me.txtCNDocNo.Size = New System.Drawing.Size(123, 22)
        Me.txtCNDocNo.TabIndex = 0
        '
        'txtCNDescription
        '
        Me.txtCNDescription.Location = New System.Drawing.Point(59, 71)
        Me.txtCNDescription.Name = "txtCNDescription"
        Me.txtCNDescription.Size = New System.Drawing.Size(346, 22)
        Me.txtCNDescription.TabIndex = 7
        '
        'txtCNAmount
        '
        Me.txtCNAmount.Location = New System.Drawing.Point(475, 19)
        Me.txtCNAmount.Name = "txtCNAmount"
        Me.txtCNAmount.Size = New System.Drawing.Size(135, 22)
        Me.txtCNAmount.TabIndex = 3
        Me.txtCNAmount.Text = "0"
        Me.txtCNAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "FOP"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Descript."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 16)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Date"
        '
        'txtPmtType
        '
        Me.txtPmtType.AutoSize = True
        Me.txtPmtType.Location = New System.Drawing.Point(188, 22)
        Me.txtPmtType.Name = "txtPmtType"
        Me.txtPmtType.Size = New System.Drawing.Size(39, 16)
        Me.txtPmtType.TabIndex = 1
        Me.txtPmtType.Text = "Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(416, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Amount"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(302, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 16)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Curr"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Doc No."
        '
        'CmbReceivedBy
        '
        Me.CmbReceivedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbReceivedBy.FormattingEnabled = True
        Me.CmbReceivedBy.Location = New System.Drawing.Point(475, 43)
        Me.CmbReceivedBy.Name = "CmbReceivedBy"
        Me.CmbReceivedBy.Size = New System.Drawing.Size(135, 24)
        Me.CmbReceivedBy.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(405, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "RCVD by"
        '
        'GridDungTienNao
        '
        Me.GridDungTienNao.AllowUserToAddRows = False
        Me.GridDungTienNao.AllowUserToDeleteRows = False
        Me.GridDungTienNao.BackgroundColor = System.Drawing.Color.LightCyan
        Me.GridDungTienNao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDungTienNao.Location = New System.Drawing.Point(0, 111)
        Me.GridDungTienNao.Name = "GridDungTienNao"
        Me.GridDungTienNao.ReadOnly = True
        Me.GridDungTienNao.RowHeadersVisible = False
        Me.GridDungTienNao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridDungTienNao.Size = New System.Drawing.Size(787, 127)
        Me.GridDungTienNao.TabIndex = 0
        '
        'txtAvailable
        '
        Me.txtAvailable.BackColor = System.Drawing.Color.White
        Me.txtAvailable.Location = New System.Drawing.Point(77, 241)
        Me.txtAvailable.Name = "txtAvailable"
        Me.txtAvailable.ReadOnly = True
        Me.txtAvailable.Size = New System.Drawing.Size(108, 22)
        Me.txtAvailable.TabIndex = 2
        Me.txtAvailable.TabStop = False
        Me.txtAvailable.Text = "0"
        Me.txtAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Available"
        '
        'TabROE
        '
        Me.TabROE.Controls.Add(Me.GrpPmtFollowUp)
        Me.TabROE.Controls.Add(Me.GrpNegoCurr)
        Me.TabROE.Location = New System.Drawing.Point(4, 24)
        Me.TabROE.Name = "TabROE"
        Me.TabROE.Size = New System.Drawing.Size(790, 487)
        Me.TabROE.TabIndex = 4
        Me.TabROE.Text = "MISC"
        Me.TabROE.UseVisualStyleBackColor = True
        '
        'GrpPmtFollowUp
        '
        Me.GrpPmtFollowUp.Controls.Add(Me.llbExportExcel)
        Me.GrpPmtFollowUp.Controls.Add(Me.ChkSelectCustOnly)
        Me.GrpPmtFollowUp.Controls.Add(Me.LblUpdateCFM_VAT)
        Me.GrpPmtFollowUp.Controls.Add(Me.Label9)
        Me.GrpPmtFollowUp.Controls.Add(Me.TxtCFM_VAT)
        Me.GrpPmtFollowUp.Controls.Add(Me.GridPendingINV)
        Me.GrpPmtFollowUp.Location = New System.Drawing.Point(267, 8)
        Me.GrpPmtFollowUp.Name = "GrpPmtFollowUp"
        Me.GrpPmtFollowUp.Size = New System.Drawing.Size(520, 476)
        Me.GrpPmtFollowUp.TabIndex = 23
        Me.GrpPmtFollowUp.TabStop = False
        Me.GrpPmtFollowUp.Text = "Pmt Follow up"
        Me.GrpPmtFollowUp.Visible = False
        '
        'llbExportExcel
        '
        Me.llbExportExcel.AutoSize = True
        Me.llbExportExcel.Location = New System.Drawing.Point(190, 456)
        Me.llbExportExcel.Name = "llbExportExcel"
        Me.llbExportExcel.Size = New System.Drawing.Size(72, 15)
        Me.llbExportExcel.TabIndex = 6
        Me.llbExportExcel.TabStop = True
        Me.llbExportExcel.Text = "ExportExcel"
        '
        'ChkSelectCustOnly
        '
        Me.ChkSelectCustOnly.AutoSize = True
        Me.ChkSelectCustOnly.Checked = True
        Me.ChkSelectCustOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSelectCustOnly.Location = New System.Drawing.Point(10, 455)
        Me.ChkSelectCustOnly.Name = "ChkSelectCustOnly"
        Me.ChkSelectCustOnly.Size = New System.Drawing.Size(137, 19)
        Me.ChkSelectCustOnly.TabIndex = 5
        Me.ChkSelectCustOnly.Text = "SelectCustomerOnly"
        Me.ChkSelectCustOnly.UseVisualStyleBackColor = True
        '
        'LblUpdateCFM_VAT
        '
        Me.LblUpdateCFM_VAT.AutoSize = True
        Me.LblUpdateCFM_VAT.Location = New System.Drawing.Point(472, 456)
        Me.LblUpdateCFM_VAT.Name = "LblUpdateCFM_VAT"
        Me.LblUpdateCFM_VAT.Size = New System.Drawing.Size(47, 15)
        Me.LblUpdateCFM_VAT.TabIndex = 4
        Me.LblUpdateCFM_VAT.TabStop = True
        Me.LblUpdateCFM_VAT.Text = "Update"
        Me.LblUpdateCFM_VAT.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(318, 456)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Date"
        '
        'TxtCFM_VAT
        '
        Me.TxtCFM_VAT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtCFM_VAT.Location = New System.Drawing.Point(382, 453)
        Me.TxtCFM_VAT.Name = "TxtCFM_VAT"
        Me.TxtCFM_VAT.Size = New System.Drawing.Size(84, 21)
        Me.TxtCFM_VAT.TabIndex = 2
        '
        'GridPendingINV
        '
        Me.GridPendingINV.AllowUserToAddRows = False
        Me.GridPendingINV.AllowUserToDeleteRows = False
        Me.GridPendingINV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPendingINV.BackgroundColor = System.Drawing.Color.MintCream
        Me.GridPendingINV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPendingINV.Location = New System.Drawing.Point(6, 20)
        Me.GridPendingINV.Name = "GridPendingINV"
        Me.GridPendingINV.RowHeadersVisible = False
        Me.GridPendingINV.Size = New System.Drawing.Size(514, 333)
        Me.GridPendingINV.TabIndex = 0
        '
        'GrpNegoCurr
        '
        Me.GrpNegoCurr.Controls.Add(Me.Label21)
        Me.GrpNegoCurr.Controls.Add(Me.Label20)
        Me.GrpNegoCurr.Controls.Add(Me.Cmb1Curr)
        Me.GrpNegoCurr.Controls.Add(Me.CmbEQnCurr)
        Me.GrpNegoCurr.Controls.Add(Me.TxtNegoROE)
        Me.GrpNegoCurr.Location = New System.Drawing.Point(1, 8)
        Me.GrpNegoCurr.Name = "GrpNegoCurr"
        Me.GrpNegoCurr.Size = New System.Drawing.Size(218, 52)
        Me.GrpNegoCurr.TabIndex = 22
        Me.GrpNegoCurr.TabStop = False
        Me.GrpNegoCurr.Text = "Nego ROE"
        Me.GrpNegoCurr.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(15, 15)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "1"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(71, 27)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(14, 15)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "="
        '
        'Cmb1Curr
        '
        Me.Cmb1Curr.FormattingEnabled = True
        Me.Cmb1Curr.Location = New System.Drawing.Point(22, 24)
        Me.Cmb1Curr.Name = "Cmb1Curr"
        Me.Cmb1Curr.Size = New System.Drawing.Size(47, 23)
        Me.Cmb1Curr.TabIndex = 2
        '
        'CmbEQnCurr
        '
        Me.CmbEQnCurr.FormattingEnabled = True
        Me.CmbEQnCurr.Location = New System.Drawing.Point(164, 24)
        Me.CmbEQnCurr.Name = "CmbEQnCurr"
        Me.CmbEQnCurr.Size = New System.Drawing.Size(45, 23)
        Me.CmbEQnCurr.TabIndex = 1
        '
        'TxtNegoROE
        '
        Me.TxtNegoROE.Location = New System.Drawing.Point(91, 24)
        Me.TxtNegoROE.Name = "TxtNegoROE"
        Me.TxtNegoROE.Size = New System.Drawing.Size(70, 21)
        Me.TxtNegoROE.TabIndex = 0
        Me.TxtNegoROE.Text = "1"
        Me.TxtNegoROE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbInvoiceAL
        '
        Me.CmbInvoiceAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbInvoiceAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbInvoiceAL.FormattingEnabled = True
        Me.CmbInvoiceAL.Location = New System.Drawing.Point(750, 21)
        Me.CmbInvoiceAL.Name = "CmbInvoiceAL"
        Me.CmbInvoiceAL.Size = New System.Drawing.Size(45, 23)
        Me.CmbInvoiceAL.TabIndex = 6
        Me.CmbInvoiceAL.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(324, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Cust."
        '
        'CmbCustomer
        '
        Me.CmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCustomer.FormattingEnabled = True
        Me.CmbCustomer.Location = New System.Drawing.Point(234, 22)
        Me.CmbCustomer.Name = "CmbCustomer"
        Me.CmbCustomer.Size = New System.Drawing.Size(190, 23)
        Me.CmbCustomer.TabIndex = 0
        '
        'txtCustFullName
        '
        Me.txtCustFullName.BackColor = System.Drawing.Color.White
        Me.txtCustFullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustFullName.Location = New System.Drawing.Point(430, 23)
        Me.txtCustFullName.Name = "txtCustFullName"
        Me.txtCustFullName.ReadOnly = True
        Me.txtCustFullName.Size = New System.Drawing.Size(232, 21)
        Me.txtCustFullName.TabIndex = 7
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PadForExRule, Me.PadAction, Me.PadFilter})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(798, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PadForExRule
        '
        Me.PadForExRule.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarInvoiceDate, Me.BarPurchaseDate, Me.BarPaymentDate, Me.BarNego})
        Me.PadForExRule.Name = "PadForExRule"
        Me.PadForExRule.Size = New System.Drawing.Size(76, 20)
        Me.PadForExRule.Text = "ForEx Rule"
        '
        'BarInvoiceDate
        '
        Me.BarInvoiceDate.CheckOnClick = True
        Me.BarInvoiceDate.Name = "BarInvoiceDate"
        Me.BarInvoiceDate.Size = New System.Drawing.Size(180, 22)
        Me.BarInvoiceDate.Text = "Invoice Date"
        '
        'BarPurchaseDate
        '
        Me.BarPurchaseDate.Name = "BarPurchaseDate"
        Me.BarPurchaseDate.Size = New System.Drawing.Size(180, 22)
        Me.BarPurchaseDate.Text = "Purchase Date"
        '
        'BarPaymentDate
        '
        Me.BarPaymentDate.Name = "BarPaymentDate"
        Me.BarPaymentDate.Size = New System.Drawing.Size(180, 22)
        Me.BarPaymentDate.Text = "Payment Date"
        '
        'BarNego
        '
        Me.BarNego.Name = "BarNego"
        Me.BarNego.Size = New System.Drawing.Size(180, 22)
        Me.BarNego.Text = "Nego"
        '
        'PadAction
        '
        Me.PadAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarDeleteThisPayment, Me.BarUnlock, Me.BarMarkSelectedAsUnpaid})
        Me.PadAction.Name = "PadAction"
        Me.PadAction.Size = New System.Drawing.Size(54, 20)
        Me.PadAction.Text = "Action"
        '
        'BarDeleteThisPayment
        '
        Me.BarDeleteThisPayment.Enabled = False
        Me.BarDeleteThisPayment.Name = "BarDeleteThisPayment"
        Me.BarDeleteThisPayment.Size = New System.Drawing.Size(286, 22)
        Me.BarDeleteThisPayment.Text = "Delete Selected Payment"
        '
        'BarUnlock
        '
        Me.BarUnlock.Name = "BarUnlock"
        Me.BarUnlock.Size = New System.Drawing.Size(286, 22)
        Me.BarUnlock.Text = "Unlock Selected/Marked as UnInvoiced"
        '
        'BarMarkSelectedAsUnpaid
        '
        Me.BarMarkSelectedAsUnpaid.Enabled = False
        Me.BarMarkSelectedAsUnpaid.Name = "BarMarkSelectedAsUnpaid"
        Me.BarMarkSelectedAsUnpaid.Size = New System.Drawing.Size(286, 22)
        Me.BarMarkSelectedAsUnpaid.Text = "Mark Current  Record as Unpaid"
        '
        'PadFilter
        '
        Me.PadFilter.CheckOnClick = True
        Me.PadFilter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarDueOnly, Me.ToolStripSeparator1, Me.BarIncludeFullyUsed, Me.BarAllPaymentType})
        Me.PadFilter.Name = "PadFilter"
        Me.PadFilter.Size = New System.Drawing.Size(45, 20)
        Me.PadFilter.Text = "Filter"
        '
        'BarDueOnly
        '
        Me.BarDueOnly.Checked = True
        Me.BarDueOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BarDueOnly.Name = "BarDueOnly"
        Me.BarDueOnly.Size = New System.Drawing.Size(180, 22)
        Me.BarDueOnly.Text = "Wz Due Only"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'BarIncludeFullyUsed
        '
        Me.BarIncludeFullyUsed.Name = "BarIncludeFullyUsed"
        Me.BarIncludeFullyUsed.Size = New System.Drawing.Size(180, 22)
        Me.BarIncludeFullyUsed.Text = "Include Fully Used"
        '
        'BarAllPaymentType
        '
        Me.BarAllPaymentType.CheckOnClick = True
        Me.BarAllPaymentType.Name = "BarAllPaymentType"
        Me.BarAllPaymentType.Size = New System.Drawing.Size(180, 22)
        Me.BarAllPaymentType.Text = "All Payment Type"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 32000
        '
        'frmDC_Pax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 537)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCustFullName)
        Me.Controls.Add(Me.CmbCustomer)
        Me.Controls.Add(Me.CmbInvoiceAL)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Location = New System.Drawing.Point(0, 56)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDC_Pax"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ACO Viet Nam ::.ACO SUITE"
        Me.TabControl1.ResumeLayout(False)
        Me.ChotNo.ResumeLayout(False)
        Me.PnlInvoicing.ResumeLayout(False)
        Me.PnlInvoicing.PerformLayout()
        CType(Me.GridNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ThanhToan.ResumeLayout(False)
        Me.PnlApplyPayments.ResumeLayout(False)
        Me.PnlApplyPayments.PerformLayout()
        CType(Me.GridTraChoKhoanNao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCreateCN.ResumeLayout(False)
        Me.GrpCreateCN.PerformLayout()
        CType(Me.GridDungTienNao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabROE.ResumeLayout(False)
        Me.GrpPmtFollowUp.ResumeLayout(False)
        Me.GrpPmtFollowUp.PerformLayout()
        CType(Me.GridPendingINV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNegoCurr.ResumeLayout(False)
        Me.GrpNegoCurr.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ChotNo As System.Windows.Forms.TabPage
    Friend WithEvents ThanhToan As System.Windows.Forms.TabPage
    Friend WithEvents GridNo As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents CmbInvoiceCurr As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbInvoiceAL As System.Windows.Forms.ComboBox
    Friend WithEvents GrpCreateCN As System.Windows.Forms.GroupBox
    Friend WithEvents txtCNDocNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCNDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCNAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCustFullName As System.Windows.Forms.TextBox
    Friend WithEvents CmbCNCurr As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbCNFOP As System.Windows.Forms.ComboBox
    Friend WithEvents txtPmtType As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GridTraChoKhoanNao As System.Windows.Forms.DataGridView
    Friend WithEvents GridDungTienNao As System.Windows.Forms.DataGridView
    Friend WithEvents CmdApply As System.Windows.Forms.Button
    Friend WithEvents PnlInvoicing As System.Windows.Forms.Panel
    Friend WithEvents PnlApplyPayments As System.Windows.Forms.Panel
    Friend WithEvents S As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CmbPmtType As System.Windows.Forms.ComboBox
    Friend WithEvents CmbReceivedBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAvailable As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPmtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PadForExRule As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarInvoiceDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarPurchaseDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarPaymentDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarNego As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PadAction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PadFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarIncludeFullyUsed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarDeleteThisPayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarUnlock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarMarkSelectedAsUnpaid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarDueOnly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabROE As System.Windows.Forms.TabPage
    Friend WithEvents txtDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents BarAllPaymentType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdAddPayment As System.Windows.Forms.Button
    Friend WithEvents LckLblWriteOffNo As System.Windows.Forms.LinkLabel
    Friend WithEvents LckLblWriteOffTra As System.Windows.Forms.LinkLabel
    Friend WithEvents CmdQuickInvVND As System.Windows.Forms.Button
    Friend WithEvents CmdQuickInvUSD As System.Windows.Forms.Button
    Friend WithEvents txtUpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblUnCheckALL As System.Windows.Forms.LinkLabel
    Friend WithEvents txtWriteOffTra As System.Windows.Forms.TextBox
    Friend WithEvents TxtWriteOffNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblPrint As System.Windows.Forms.LinkLabel
    Friend WithEvents LbLSplitPmt As System.Windows.Forms.LinkLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GrpNegoCurr As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Cmb1Curr As System.Windows.Forms.ComboBox
    Friend WithEvents CmbEQnCurr As System.Windows.Forms.ComboBox
    Friend WithEvents TxtNegoROE As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblListDetail As System.Windows.Forms.LinkLabel
    Friend WithEvents GrpPmtFollowUp As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCFM_VAT As System.Windows.Forms.DateTimePicker
    Friend WithEvents GridPendingINV As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblUpdateCFM_VAT As System.Windows.Forms.LinkLabel
    Friend WithEvents ChkSelectCustOnly As CheckBox
    Friend WithEvents llbExportExcel As LinkLabel
    Friend WithEvents llbInvoicingList As LinkLabel
End Class
