<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAtcCalcPriceEdit
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpCPMonth = New System.Windows.Forms.DateTimePicker()
        Me.lblCPMonth = New System.Windows.Forms.Label()
        Me.txtRecID = New System.Windows.Forms.TextBox()
        Me.lblRecID = New System.Windows.Forms.Label()
        Me.txtTotalExcessiveTrx = New System.Windows.Forms.TextBox()
        Me.lblTotalExcessiveTrx = New System.Windows.Forms.Label()
        Me.txtTotalRefundTrx = New System.Windows.Forms.TextBox()
        Me.lblTotalRefundTrx = New System.Windows.Forms.Label()
        Me.txtTotalInvolTrx = New System.Windows.Forms.TextBox()
        Me.lblTotalInvolTrx = New System.Windows.Forms.Label()
        Me.txtTotalReissueTicket = New System.Windows.Forms.TextBox()
        Me.lblTotalReissueTicket = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.llbCalcPrice = New System.Windows.Forms.LinkLabel()
        Me.txtTotalExcessiveAmount = New System.Windows.Forms.TextBox()
        Me.lblTotalExcessiveAmount = New System.Windows.Forms.Label()
        Me.txtTotalRefundAmount = New System.Windows.Forms.TextBox()
        Me.lblTotalRefundAmount = New System.Windows.Forms.Label()
        Me.txtTotalInvolAmount = New System.Windows.Forms.TextBox()
        Me.lblTotalInvolAmount = New System.Windows.Forms.Label()
        Me.txtTotalReissueAmount = New System.Windows.Forms.TextBox()
        Me.lblTotalReissueAmount = New System.Windows.Forms.Label()
        Me.dgvAtcCalcPriceDetail = New System.Windows.Forms.DataGridView()
        Me.llbExportAbnormalData = New System.Windows.Forms.LinkLabel()
        Me.llbSave = New System.Windows.Forms.LinkLabel()
        Me.dgvReissueTicketPriceDetail = New System.Windows.Forms.DataGridView()
        Me.NumberOfTicket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PricePerTicket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvAtcCalcPriceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReissueTicketPriceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpCPMonth
        '
        Me.dtpCPMonth.CustomFormat = "MMM yyyy"
        Me.dtpCPMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPMonth.Location = New System.Drawing.Point(221, 12)
        Me.dtpCPMonth.Name = "dtpCPMonth"
        Me.dtpCPMonth.ShowUpDown = True
        Me.dtpCPMonth.Size = New System.Drawing.Size(80, 20)
        Me.dtpCPMonth.TabIndex = 1
        '
        'lblCPMonth
        '
        Me.lblCPMonth.AutoSize = True
        Me.lblCPMonth.Location = New System.Drawing.Point(164, 15)
        Me.lblCPMonth.Name = "lblCPMonth"
        Me.lblCPMonth.Size = New System.Drawing.Size(51, 13)
        Me.lblCPMonth.TabIndex = 25
        Me.lblCPMonth.Text = "CPMonth"
        '
        'txtRecID
        '
        Me.txtRecID.Location = New System.Drawing.Point(69, 12)
        Me.txtRecID.Name = "txtRecID"
        Me.txtRecID.ReadOnly = True
        Me.txtRecID.Size = New System.Drawing.Size(50, 20)
        Me.txtRecID.TabIndex = 0
        Me.txtRecID.Text = "0"
        Me.txtRecID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRecID
        '
        Me.lblRecID.AutoSize = True
        Me.lblRecID.Location = New System.Drawing.Point(25, 16)
        Me.lblRecID.Name = "lblRecID"
        Me.lblRecID.Size = New System.Drawing.Size(38, 13)
        Me.lblRecID.TabIndex = 24
        Me.lblRecID.Text = "RecID"
        '
        'txtTotalExcessiveTrx
        '
        Me.txtTotalExcessiveTrx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalExcessiveTrx.Location = New System.Drawing.Point(183, 430)
        Me.txtTotalExcessiveTrx.Name = "txtTotalExcessiveTrx"
        Me.txtTotalExcessiveTrx.ReadOnly = True
        Me.txtTotalExcessiveTrx.Size = New System.Drawing.Size(50, 20)
        Me.txtTotalExcessiveTrx.TabIndex = 7
        Me.txtTotalExcessiveTrx.Text = "0"
        Me.txtTotalExcessiveTrx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalExcessiveTrx
        '
        Me.lblTotalExcessiveTrx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalExcessiveTrx.AutoSize = True
        Me.lblTotalExcessiveTrx.Location = New System.Drawing.Point(83, 433)
        Me.lblTotalExcessiveTrx.Name = "lblTotalExcessiveTrx"
        Me.lblTotalExcessiveTrx.Size = New System.Drawing.Size(94, 13)
        Me.lblTotalExcessiveTrx.TabIndex = 29
        Me.lblTotalExcessiveTrx.Text = "TotalExcessiveTrx"
        '
        'txtTotalRefundTrx
        '
        Me.txtTotalRefundTrx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalRefundTrx.Location = New System.Drawing.Point(412, 430)
        Me.txtTotalRefundTrx.Name = "txtTotalRefundTrx"
        Me.txtTotalRefundTrx.ReadOnly = True
        Me.txtTotalRefundTrx.Size = New System.Drawing.Size(50, 20)
        Me.txtTotalRefundTrx.TabIndex = 9
        Me.txtTotalRefundTrx.Text = "0"
        Me.txtTotalRefundTrx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalRefundTrx
        '
        Me.lblTotalRefundTrx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRefundTrx.AutoSize = True
        Me.lblTotalRefundTrx.Location = New System.Drawing.Point(325, 433)
        Me.lblTotalRefundTrx.Name = "lblTotalRefundTrx"
        Me.lblTotalRefundTrx.Size = New System.Drawing.Size(81, 13)
        Me.lblTotalRefundTrx.TabIndex = 31
        Me.lblTotalRefundTrx.Text = "TotalRefundTrx"
        '
        'txtTotalInvolTrx
        '
        Me.txtTotalInvolTrx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalInvolTrx.Location = New System.Drawing.Point(614, 430)
        Me.txtTotalInvolTrx.Name = "txtTotalInvolTrx"
        Me.txtTotalInvolTrx.ReadOnly = True
        Me.txtTotalInvolTrx.Size = New System.Drawing.Size(50, 20)
        Me.txtTotalInvolTrx.TabIndex = 11
        Me.txtTotalInvolTrx.Text = "0"
        Me.txtTotalInvolTrx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalInvolTrx
        '
        Me.lblTotalInvolTrx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalInvolTrx.AutoSize = True
        Me.lblTotalInvolTrx.Location = New System.Drawing.Point(539, 433)
        Me.lblTotalInvolTrx.Name = "lblTotalInvolTrx"
        Me.lblTotalInvolTrx.Size = New System.Drawing.Size(69, 13)
        Me.lblTotalInvolTrx.TabIndex = 33
        Me.lblTotalInvolTrx.Text = "TotalInvolTrx"
        '
        'txtTotalReissueTicket
        '
        Me.txtTotalReissueTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalReissueTicket.Location = New System.Drawing.Point(831, 430)
        Me.txtTotalReissueTicket.Name = "txtTotalReissueTicket"
        Me.txtTotalReissueTicket.ReadOnly = True
        Me.txtTotalReissueTicket.Size = New System.Drawing.Size(50, 20)
        Me.txtTotalReissueTicket.TabIndex = 13
        Me.txtTotalReissueTicket.Text = "0"
        Me.txtTotalReissueTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalReissueTicket
        '
        Me.lblTotalReissueTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalReissueTicket.AutoSize = True
        Me.lblTotalReissueTicket.Location = New System.Drawing.Point(726, 433)
        Me.lblTotalReissueTicket.Name = "lblTotalReissueTicket"
        Me.lblTotalReissueTicket.Size = New System.Drawing.Size(99, 13)
        Me.lblTotalReissueTicket.TabIndex = 35
        Me.lblTotalReissueTicket.Text = "TotalReissueTicket"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAmount.Location = New System.Drawing.Point(960, 456)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAmount.TabIndex = 15
        Me.txtTotalAmount.Text = "0"
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(887, 459)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(67, 13)
        Me.lblTotalAmount.TabIndex = 37
        Me.lblTotalAmount.Text = "TotalAmount"
        '
        'llbCalcPrice
        '
        Me.llbCalcPrice.AutoSize = True
        Me.llbCalcPrice.Location = New System.Drawing.Point(307, 15)
        Me.llbCalcPrice.Name = "llbCalcPrice"
        Me.llbCalcPrice.Size = New System.Drawing.Size(52, 13)
        Me.llbCalcPrice.TabIndex = 2
        Me.llbCalcPrice.TabStop = True
        Me.llbCalcPrice.Text = "CalcPrice"
        '
        'txtTotalExcessiveAmount
        '
        Me.txtTotalExcessiveAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalExcessiveAmount.Location = New System.Drawing.Point(133, 456)
        Me.txtTotalExcessiveAmount.Name = "txtTotalExcessiveAmount"
        Me.txtTotalExcessiveAmount.ReadOnly = True
        Me.txtTotalExcessiveAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalExcessiveAmount.TabIndex = 8
        Me.txtTotalExcessiveAmount.Text = "0"
        Me.txtTotalExcessiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalExcessiveAmount
        '
        Me.lblTotalExcessiveAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalExcessiveAmount.AutoSize = True
        Me.lblTotalExcessiveAmount.Location = New System.Drawing.Point(12, 459)
        Me.lblTotalExcessiveAmount.Name = "lblTotalExcessiveAmount"
        Me.lblTotalExcessiveAmount.Size = New System.Drawing.Size(115, 13)
        Me.lblTotalExcessiveAmount.TabIndex = 40
        Me.lblTotalExcessiveAmount.Text = "TotalExcessiveAmount"
        '
        'txtTotalRefundAmount
        '
        Me.txtTotalRefundAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalRefundAmount.Location = New System.Drawing.Point(362, 456)
        Me.txtTotalRefundAmount.Name = "txtTotalRefundAmount"
        Me.txtTotalRefundAmount.ReadOnly = True
        Me.txtTotalRefundAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalRefundAmount.TabIndex = 10
        Me.txtTotalRefundAmount.Text = "0"
        Me.txtTotalRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalRefundAmount
        '
        Me.lblTotalRefundAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRefundAmount.AutoSize = True
        Me.lblTotalRefundAmount.Location = New System.Drawing.Point(254, 459)
        Me.lblTotalRefundAmount.Name = "lblTotalRefundAmount"
        Me.lblTotalRefundAmount.Size = New System.Drawing.Size(102, 13)
        Me.lblTotalRefundAmount.TabIndex = 42
        Me.lblTotalRefundAmount.Text = "TotalRefundAmount"
        '
        'txtTotalInvolAmount
        '
        Me.txtTotalInvolAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalInvolAmount.Location = New System.Drawing.Point(564, 456)
        Me.txtTotalInvolAmount.Name = "txtTotalInvolAmount"
        Me.txtTotalInvolAmount.ReadOnly = True
        Me.txtTotalInvolAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalInvolAmount.TabIndex = 12
        Me.txtTotalInvolAmount.Text = "0"
        Me.txtTotalInvolAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalInvolAmount
        '
        Me.lblTotalInvolAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalInvolAmount.AutoSize = True
        Me.lblTotalInvolAmount.Location = New System.Drawing.Point(468, 459)
        Me.lblTotalInvolAmount.Name = "lblTotalInvolAmount"
        Me.lblTotalInvolAmount.Size = New System.Drawing.Size(90, 13)
        Me.lblTotalInvolAmount.TabIndex = 44
        Me.lblTotalInvolAmount.Text = "TotalInvolAmount"
        '
        'txtTotalReissueAmount
        '
        Me.txtTotalReissueAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalReissueAmount.Location = New System.Drawing.Point(781, 456)
        Me.txtTotalReissueAmount.Name = "txtTotalReissueAmount"
        Me.txtTotalReissueAmount.ReadOnly = True
        Me.txtTotalReissueAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalReissueAmount.TabIndex = 14
        Me.txtTotalReissueAmount.Text = "0"
        Me.txtTotalReissueAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalReissueAmount
        '
        Me.lblTotalReissueAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalReissueAmount.AutoSize = True
        Me.lblTotalReissueAmount.Location = New System.Drawing.Point(670, 459)
        Me.lblTotalReissueAmount.Name = "lblTotalReissueAmount"
        Me.lblTotalReissueAmount.Size = New System.Drawing.Size(105, 13)
        Me.lblTotalReissueAmount.TabIndex = 46
        Me.lblTotalReissueAmount.Text = "TotalReissueAmount"
        '
        'dgvAtcCalcPriceDetail
        '
        Me.dgvAtcCalcPriceDetail.AllowUserToAddRows = False
        Me.dgvAtcCalcPriceDetail.AllowUserToDeleteRows = False
        Me.dgvAtcCalcPriceDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAtcCalcPriceDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAtcCalcPriceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAtcCalcPriceDetail.Location = New System.Drawing.Point(12, 38)
        Me.dgvAtcCalcPriceDetail.Name = "dgvAtcCalcPriceDetail"
        Me.dgvAtcCalcPriceDetail.ReadOnly = True
        Me.dgvAtcCalcPriceDetail.Size = New System.Drawing.Size(1138, 179)
        Me.dgvAtcCalcPriceDetail.TabIndex = 4
        '
        'llbExportAbnormalData
        '
        Me.llbExportAbnormalData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llbExportAbnormalData.AutoSize = True
        Me.llbExportAbnormalData.Location = New System.Drawing.Point(12, 405)
        Me.llbExportAbnormalData.Name = "llbExportAbnormalData"
        Me.llbExportAbnormalData.Size = New System.Drawing.Size(104, 13)
        Me.llbExportAbnormalData.TabIndex = 6
        Me.llbExportAbnormalData.TabStop = True
        Me.llbExportAbnormalData.Text = "ExportAbnormalData"
        '
        'llbSave
        '
        Me.llbSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llbSave.AutoSize = True
        Me.llbSave.Location = New System.Drawing.Point(12, 479)
        Me.llbSave.Name = "llbSave"
        Me.llbSave.Size = New System.Drawing.Size(32, 13)
        Me.llbSave.TabIndex = 48
        Me.llbSave.TabStop = True
        Me.llbSave.Text = "Save"
        '
        'dgvReissueTicketPriceDetail
        '
        Me.dgvReissueTicketPriceDetail.AllowUserToAddRows = False
        Me.dgvReissueTicketPriceDetail.AllowUserToDeleteRows = False
        Me.dgvReissueTicketPriceDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReissueTicketPriceDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvReissueTicketPriceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReissueTicketPriceDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumberOfTicket, Me.PricePerTicket, Me.Amount})
        Me.dgvReissueTicketPriceDetail.Location = New System.Drawing.Point(12, 223)
        Me.dgvReissueTicketPriceDetail.Name = "dgvReissueTicketPriceDetail"
        Me.dgvReissueTicketPriceDetail.ReadOnly = True
        Me.dgvReissueTicketPriceDetail.Size = New System.Drawing.Size(1138, 179)
        Me.dgvReissueTicketPriceDetail.TabIndex = 5
        '
        'NumberOfTicket
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        Me.NumberOfTicket.DefaultCellStyle = DataGridViewCellStyle7
        Me.NumberOfTicket.HeaderText = "NumberOfTicket"
        Me.NumberOfTicket.Name = "NumberOfTicket"
        Me.NumberOfTicket.ReadOnly = True
        Me.NumberOfTicket.Width = 110
        '
        'PricePerTicket
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        Me.PricePerTicket.DefaultCellStyle = DataGridViewCellStyle8
        Me.PricePerTicket.HeaderText = "PricePerTicket"
        Me.PricePerTicket.Name = "PricePerTicket"
        Me.PricePerTicket.ReadOnly = True
        Me.PricePerTicket.Width = 102
        '
        'Amount
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N0"
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle9
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        Me.Amount.Width = 68
        '
        'frmAtcCalcPriceEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 500)
        Me.Controls.Add(Me.dgvReissueTicketPriceDetail)
        Me.Controls.Add(Me.llbSave)
        Me.Controls.Add(Me.llbExportAbnormalData)
        Me.Controls.Add(Me.txtTotalReissueAmount)
        Me.Controls.Add(Me.lblTotalReissueAmount)
        Me.Controls.Add(Me.txtTotalInvolAmount)
        Me.Controls.Add(Me.lblTotalInvolAmount)
        Me.Controls.Add(Me.txtTotalRefundAmount)
        Me.Controls.Add(Me.lblTotalRefundAmount)
        Me.Controls.Add(Me.txtTotalExcessiveAmount)
        Me.Controls.Add(Me.lblTotalExcessiveAmount)
        Me.Controls.Add(Me.llbCalcPrice)
        Me.Controls.Add(Me.dgvAtcCalcPriceDetail)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.txtTotalReissueTicket)
        Me.Controls.Add(Me.lblTotalReissueTicket)
        Me.Controls.Add(Me.txtTotalInvolTrx)
        Me.Controls.Add(Me.lblTotalInvolTrx)
        Me.Controls.Add(Me.txtTotalRefundTrx)
        Me.Controls.Add(Me.lblTotalRefundTrx)
        Me.Controls.Add(Me.txtTotalExcessiveTrx)
        Me.Controls.Add(Me.lblTotalExcessiveTrx)
        Me.Controls.Add(Me.dtpCPMonth)
        Me.Controls.Add(Me.lblCPMonth)
        Me.Controls.Add(Me.txtRecID)
        Me.Controls.Add(Me.lblRecID)
        Me.Name = "frmAtcCalcPriceEdit"
        Me.Text = "AtcCalcPriceEdit"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvAtcCalcPriceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReissueTicketPriceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpCPMonth As DateTimePicker
    Friend WithEvents lblCPMonth As Label
    Friend WithEvents txtRecID As TextBox
    Friend WithEvents lblRecID As Label
    Friend WithEvents txtTotalExcessiveTrx As TextBox
    Friend WithEvents lblTotalExcessiveTrx As Label
    Friend WithEvents txtTotalRefundTrx As TextBox
    Friend WithEvents lblTotalRefundTrx As Label
    Friend WithEvents txtTotalInvolTrx As TextBox
    Friend WithEvents lblTotalInvolTrx As Label
    Friend WithEvents txtTotalReissueTicket As TextBox
    Friend WithEvents lblTotalReissueTicket As Label
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents llbCalcPrice As LinkLabel
    Friend WithEvents txtTotalExcessiveAmount As TextBox
    Friend WithEvents lblTotalExcessiveAmount As Label
    Friend WithEvents txtTotalRefundAmount As TextBox
    Friend WithEvents lblTotalRefundAmount As Label
    Friend WithEvents txtTotalInvolAmount As TextBox
    Friend WithEvents lblTotalInvolAmount As Label
    Friend WithEvents txtTotalReissueAmount As TextBox
    Friend WithEvents lblTotalReissueAmount As Label
    Friend WithEvents dgvAtcCalcPriceDetail As DataGridView
    Friend WithEvents llbExportAbnormalData As LinkLabel
    Friend WithEvents llbSave As LinkLabel
    Friend WithEvents dgvReissueTicketPriceDetail As DataGridView
    Friend WithEvents NumberOfTicket As DataGridViewTextBoxColumn
    Friend WithEvents PricePerTicket As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
End Class
