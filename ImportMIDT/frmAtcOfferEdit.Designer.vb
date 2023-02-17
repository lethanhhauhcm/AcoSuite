<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAtcOfferEdit
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtInvolTrxPrice = New System.Windows.Forms.TextBox()
        Me.lblInvolTrxPrice = New System.Windows.Forms.Label()
        Me.txtRefundTrxPrice = New System.Windows.Forms.TextBox()
        Me.lblRefundTrxPrice = New System.Windows.Forms.Label()
        Me.txtExcessiveTrxPrice = New System.Windows.Forms.TextBox()
        Me.lblReissueTrxPrice = New System.Windows.Forms.Label()
        Me.dtpExpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExpDate = New System.Windows.Forms.Label()
        Me.dtpEffDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEffDate = New System.Windows.Forms.Label()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.txtRecID = New System.Windows.Forms.TextBox()
        Me.lblRecID = New System.Windows.Forms.Label()
        Me.llbSave = New System.Windows.Forms.LinkLabel()
        Me.dgvAtcOfferDetail = New System.Windows.Forms.DataGridView()
        Me.lstCustomer = New System.Windows.Forms.ListBox()
        Me.txtTicketPrice = New System.Windows.Forms.TextBox()
        Me.lblTicketPrice = New System.Windows.Forms.Label()
        Me.RecID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookingRequest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FreeTicket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvAtcOfferDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtInvolTrxPrice
        '
        Me.txtInvolTrxPrice.Location = New System.Drawing.Point(334, 64)
        Me.txtInvolTrxPrice.Name = "txtInvolTrxPrice"
        Me.txtInvolTrxPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtInvolTrxPrice.TabIndex = 8
        Me.txtInvolTrxPrice.Text = "0"
        Me.txtInvolTrxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInvolTrxPrice
        '
        Me.lblInvolTrxPrice.AutoSize = True
        Me.lblInvolTrxPrice.Location = New System.Drawing.Point(259, 67)
        Me.lblInvolTrxPrice.Name = "lblInvolTrxPrice"
        Me.lblInvolTrxPrice.Size = New System.Drawing.Size(69, 13)
        Me.lblInvolTrxPrice.TabIndex = 31
        Me.lblInvolTrxPrice.Text = "InvolTrxPrice"
        '
        'txtRefundTrxPrice
        '
        Me.txtRefundTrxPrice.Location = New System.Drawing.Point(334, 38)
        Me.txtRefundTrxPrice.Name = "txtRefundTrxPrice"
        Me.txtRefundTrxPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtRefundTrxPrice.TabIndex = 7
        Me.txtRefundTrxPrice.Text = "0"
        Me.txtRefundTrxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRefundTrxPrice
        '
        Me.lblRefundTrxPrice.AutoSize = True
        Me.lblRefundTrxPrice.Location = New System.Drawing.Point(247, 41)
        Me.lblRefundTrxPrice.Name = "lblRefundTrxPrice"
        Me.lblRefundTrxPrice.Size = New System.Drawing.Size(81, 13)
        Me.lblRefundTrxPrice.TabIndex = 29
        Me.lblRefundTrxPrice.Text = "RefundTrxPrice"
        '
        'txtExcessiveTrxPrice
        '
        Me.txtExcessiveTrxPrice.Location = New System.Drawing.Point(334, 12)
        Me.txtExcessiveTrxPrice.Name = "txtExcessiveTrxPrice"
        Me.txtExcessiveTrxPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtExcessiveTrxPrice.TabIndex = 6
        Me.txtExcessiveTrxPrice.Text = "0"
        Me.txtExcessiveTrxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblReissueTrxPrice
        '
        Me.lblReissueTrxPrice.AutoSize = True
        Me.lblReissueTrxPrice.Location = New System.Drawing.Point(234, 15)
        Me.lblReissueTrxPrice.Name = "lblReissueTrxPrice"
        Me.lblReissueTrxPrice.Size = New System.Drawing.Size(94, 13)
        Me.lblReissueTrxPrice.TabIndex = 27
        Me.lblReissueTrxPrice.Text = "ExcessiveTrxPrice"
        '
        'dtpExpDate
        '
        Me.dtpExpDate.CustomFormat = "MMM yyyy"
        Me.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpDate.Location = New System.Drawing.Point(70, 64)
        Me.dtpExpDate.Name = "dtpExpDate"
        Me.dtpExpDate.ShowUpDown = True
        Me.dtpExpDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpExpDate.TabIndex = 4
        '
        'lblExpDate
        '
        Me.lblExpDate.AutoSize = True
        Me.lblExpDate.Location = New System.Drawing.Point(16, 68)
        Me.lblExpDate.Name = "lblExpDate"
        Me.lblExpDate.Size = New System.Drawing.Size(48, 13)
        Me.lblExpDate.TabIndex = 23
        Me.lblExpDate.Text = "ExpDate"
        '
        'dtpEffDate
        '
        Me.dtpEffDate.CustomFormat = "MMM yyyy"
        Me.dtpEffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffDate.Location = New System.Drawing.Point(70, 38)
        Me.dtpEffDate.Name = "dtpEffDate"
        Me.dtpEffDate.ShowUpDown = True
        Me.dtpEffDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpEffDate.TabIndex = 3
        '
        'lblEffDate
        '
        Me.lblEffDate.AutoSize = True
        Me.lblEffDate.Location = New System.Drawing.Point(21, 42)
        Me.lblEffDate.Name = "lblEffDate"
        Me.lblEffDate.Size = New System.Drawing.Size(43, 13)
        Me.lblEffDate.TabIndex = 21
        Me.lblEffDate.Text = "EffDate"
        '
        'cboCustomer
        '
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(70, 90)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(80, 21)
        Me.cboCustomer.TabIndex = 5
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Location = New System.Drawing.Point(13, 93)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(51, 13)
        Me.lblCustomer.TabIndex = 19
        Me.lblCustomer.Text = "Customer"
        '
        'txtRecID
        '
        Me.txtRecID.Location = New System.Drawing.Point(70, 12)
        Me.txtRecID.Name = "txtRecID"
        Me.txtRecID.ReadOnly = True
        Me.txtRecID.Size = New System.Drawing.Size(50, 20)
        Me.txtRecID.TabIndex = 1
        Me.txtRecID.Text = "0"
        Me.txtRecID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRecID
        '
        Me.lblRecID.AutoSize = True
        Me.lblRecID.Location = New System.Drawing.Point(26, 15)
        Me.lblRecID.Name = "lblRecID"
        Me.lblRecID.Size = New System.Drawing.Size(38, 13)
        Me.lblRecID.TabIndex = 17
        Me.lblRecID.Text = "RecID"
        '
        'llbSave
        '
        Me.llbSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llbSave.AutoSize = True
        Me.llbSave.Location = New System.Drawing.Point(13, 305)
        Me.llbSave.Name = "llbSave"
        Me.llbSave.Size = New System.Drawing.Size(32, 13)
        Me.llbSave.TabIndex = 11
        Me.llbSave.TabStop = True
        Me.llbSave.Text = "Save"
        '
        'dgvAtcOfferDetail
        '
        Me.dgvAtcOfferDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAtcOfferDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAtcOfferDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAtcOfferDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RecID, Me.BookingRequest, Me.FreeTicket})
        Me.dgvAtcOfferDetail.Location = New System.Drawing.Point(16, 152)
        Me.dgvAtcOfferDetail.Name = "dgvAtcOfferDetail"
        Me.dgvAtcOfferDetail.Size = New System.Drawing.Size(503, 150)
        Me.dgvAtcOfferDetail.TabIndex = 10
        '
        'lstCustomer
        '
        Me.lstCustomer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCustomer.FormattingEnabled = True
        Me.lstCustomer.Location = New System.Drawing.Point(16, 116)
        Me.lstCustomer.MultiColumn = True
        Me.lstCustomer.Name = "lstCustomer"
        Me.lstCustomer.ScrollAlwaysVisible = True
        Me.lstCustomer.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstCustomer.Size = New System.Drawing.Size(507, 30)
        Me.lstCustomer.TabIndex = 5
        Me.lstCustomer.Visible = False
        '
        'txtTicketPrice
        '
        Me.txtTicketPrice.Location = New System.Drawing.Point(334, 90)
        Me.txtTicketPrice.Name = "txtTicketPrice"
        Me.txtTicketPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtTicketPrice.TabIndex = 9
        Me.txtTicketPrice.Text = "0"
        Me.txtTicketPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTicketPrice
        '
        Me.lblTicketPrice.AutoSize = True
        Me.lblTicketPrice.Location = New System.Drawing.Point(267, 93)
        Me.lblTicketPrice.Name = "lblTicketPrice"
        Me.lblTicketPrice.Size = New System.Drawing.Size(61, 13)
        Me.lblTicketPrice.TabIndex = 61
        Me.lblTicketPrice.Text = "TicketPrice"
        '
        'RecID
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.RecID.DefaultCellStyle = DataGridViewCellStyle1
        Me.RecID.HeaderText = "RecID"
        Me.RecID.Name = "RecID"
        Me.RecID.Visible = False
        Me.RecID.Width = 63
        '
        'BookingRequest
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.BookingRequest.DefaultCellStyle = DataGridViewCellStyle2
        Me.BookingRequest.HeaderText = "BookingRequest"
        Me.BookingRequest.Name = "BookingRequest"
        Me.BookingRequest.Width = 111
        '
        'FreeTicket
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.FreeTicket.DefaultCellStyle = DataGridViewCellStyle3
        Me.FreeTicket.HeaderText = "FreeTicket"
        Me.FreeTicket.Name = "FreeTicket"
        Me.FreeTicket.Width = 83
        '
        'frmAtcOfferEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 327)
        Me.Controls.Add(Me.txtTicketPrice)
        Me.Controls.Add(Me.lblTicketPrice)
        Me.Controls.Add(Me.lstCustomer)
        Me.Controls.Add(Me.dgvAtcOfferDetail)
        Me.Controls.Add(Me.llbSave)
        Me.Controls.Add(Me.txtInvolTrxPrice)
        Me.Controls.Add(Me.lblInvolTrxPrice)
        Me.Controls.Add(Me.txtRefundTrxPrice)
        Me.Controls.Add(Me.lblRefundTrxPrice)
        Me.Controls.Add(Me.txtExcessiveTrxPrice)
        Me.Controls.Add(Me.lblReissueTrxPrice)
        Me.Controls.Add(Me.dtpExpDate)
        Me.Controls.Add(Me.lblExpDate)
        Me.Controls.Add(Me.dtpEffDate)
        Me.Controls.Add(Me.lblEffDate)
        Me.Controls.Add(Me.cboCustomer)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.txtRecID)
        Me.Controls.Add(Me.lblRecID)
        Me.Name = "frmAtcOfferEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AtcOfferEdit"
        CType(Me.dgvAtcOfferDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtInvolTrxPrice As TextBox
    Friend WithEvents lblInvolTrxPrice As Label
    Friend WithEvents txtRefundTrxPrice As TextBox
    Friend WithEvents lblRefundTrxPrice As Label
    Friend WithEvents txtExcessiveTrxPrice As TextBox
    Friend WithEvents lblReissueTrxPrice As Label
    Friend WithEvents dtpExpDate As DateTimePicker
    Friend WithEvents lblExpDate As Label
    Friend WithEvents dtpEffDate As DateTimePicker
    Friend WithEvents lblEffDate As Label
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents txtRecID As TextBox
    Friend WithEvents lblRecID As Label
    Friend WithEvents llbSave As LinkLabel
    Friend WithEvents dgvAtcOfferDetail As DataGridView
    Friend WithEvents lstCustomer As ListBox
    Friend WithEvents txtTicketPrice As TextBox
    Friend WithEvents lblTicketPrice As Label
    Friend WithEvents RecID As DataGridViewTextBoxColumn
    Friend WithEvents BookingRequest As DataGridViewTextBoxColumn
    Friend WithEvents FreeTicket As DataGridViewTextBoxColumn
End Class
