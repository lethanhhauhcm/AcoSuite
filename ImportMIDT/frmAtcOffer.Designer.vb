<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAtcOffer
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
        Me.dgvAtcOffer = New System.Windows.Forms.DataGridView()
        Me.llbAdd = New System.Windows.Forms.LinkLabel()
        Me.llbEdit = New System.Windows.Forms.LinkLabel()
        Me.llbDelete = New System.Windows.Forms.LinkLabel()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.llbFilter = New System.Windows.Forms.LinkLabel()
        Me.dgvAtcOfferDetail = New System.Windows.Forms.DataGridView()
        Me.llbCopy = New System.Windows.Forms.LinkLabel()
        Me.lblEffDateFrom = New System.Windows.Forms.Label()
        Me.dtpEffDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpEffDateTo = New System.Windows.Forms.DateTimePicker()
        Me.llbReset = New System.Windows.Forms.LinkLabel()
        CType(Me.dgvAtcOffer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAtcOfferDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAtcOffer
        '
        Me.dgvAtcOffer.AllowUserToAddRows = False
        Me.dgvAtcOffer.AllowUserToDeleteRows = False
        Me.dgvAtcOffer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAtcOffer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAtcOffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAtcOffer.Location = New System.Drawing.Point(12, 39)
        Me.dgvAtcOffer.Name = "dgvAtcOffer"
        Me.dgvAtcOffer.ReadOnly = True
        Me.dgvAtcOffer.Size = New System.Drawing.Size(971, 150)
        Me.dgvAtcOffer.TabIndex = 6
        '
        'llbAdd
        '
        Me.llbAdd.AutoSize = True
        Me.llbAdd.Location = New System.Drawing.Point(12, 15)
        Me.llbAdd.Name = "llbAdd"
        Me.llbAdd.Size = New System.Drawing.Size(26, 13)
        Me.llbAdd.TabIndex = 0
        Me.llbAdd.TabStop = True
        Me.llbAdd.Text = "Add"
        '
        'llbEdit
        '
        Me.llbEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llbEdit.AutoSize = True
        Me.llbEdit.Enabled = False
        Me.llbEdit.Location = New System.Drawing.Point(12, 192)
        Me.llbEdit.Name = "llbEdit"
        Me.llbEdit.Size = New System.Drawing.Size(25, 13)
        Me.llbEdit.TabIndex = 7
        Me.llbEdit.TabStop = True
        Me.llbEdit.Text = "Edit"
        '
        'llbDelete
        '
        Me.llbDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llbDelete.AutoSize = True
        Me.llbDelete.Enabled = False
        Me.llbDelete.Location = New System.Drawing.Point(43, 192)
        Me.llbDelete.Name = "llbDelete"
        Me.llbDelete.Size = New System.Drawing.Size(38, 13)
        Me.llbDelete.TabIndex = 8
        Me.llbDelete.TabStop = True
        Me.llbDelete.Text = "Delete"
        '
        'cboCustomer
        '
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(137, 12)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(80, 21)
        Me.cboCustomer.TabIndex = 1
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Location = New System.Drawing.Point(80, 15)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(51, 13)
        Me.lblCustomer.TabIndex = 22
        Me.lblCustomer.Text = "Customer"
        '
        'llbFilter
        '
        Me.llbFilter.AutoSize = True
        Me.llbFilter.Location = New System.Drawing.Point(513, 15)
        Me.llbFilter.Name = "llbFilter"
        Me.llbFilter.Size = New System.Drawing.Size(29, 13)
        Me.llbFilter.TabIndex = 4
        Me.llbFilter.TabStop = True
        Me.llbFilter.Text = "Filter"
        '
        'dgvAtcOfferDetail
        '
        Me.dgvAtcOfferDetail.AllowUserToAddRows = False
        Me.dgvAtcOfferDetail.AllowUserToDeleteRows = False
        Me.dgvAtcOfferDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAtcOfferDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAtcOfferDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAtcOfferDetail.Location = New System.Drawing.Point(12, 208)
        Me.dgvAtcOfferDetail.Name = "dgvAtcOfferDetail"
        Me.dgvAtcOfferDetail.ReadOnly = True
        Me.dgvAtcOfferDetail.Size = New System.Drawing.Size(971, 150)
        Me.dgvAtcOfferDetail.TabIndex = 10
        '
        'llbCopy
        '
        Me.llbCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llbCopy.AutoSize = True
        Me.llbCopy.Enabled = False
        Me.llbCopy.Location = New System.Drawing.Point(87, 192)
        Me.llbCopy.Name = "llbCopy"
        Me.llbCopy.Size = New System.Drawing.Size(31, 13)
        Me.llbCopy.TabIndex = 9
        Me.llbCopy.TabStop = True
        Me.llbCopy.Text = "Copy"
        '
        'lblEffDateFrom
        '
        Me.lblEffDateFrom.AutoSize = True
        Me.lblEffDateFrom.Location = New System.Drawing.Point(223, 15)
        Me.lblEffDateFrom.Name = "lblEffDateFrom"
        Me.lblEffDateFrom.Size = New System.Drawing.Size(66, 13)
        Me.lblEffDateFrom.TabIndex = 23
        Me.lblEffDateFrom.Text = "EffDateFrom"
        '
        'dtpEffDateFrom
        '
        Me.dtpEffDateFrom.Checked = False
        Me.dtpEffDateFrom.CustomFormat = "MMM yyyy"
        Me.dtpEffDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffDateFrom.Location = New System.Drawing.Point(295, 12)
        Me.dtpEffDateFrom.Name = "dtpEffDateFrom"
        Me.dtpEffDateFrom.ShowCheckBox = True
        Me.dtpEffDateFrom.ShowUpDown = True
        Me.dtpEffDateFrom.Size = New System.Drawing.Size(89, 20)
        Me.dtpEffDateFrom.TabIndex = 2
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(390, 15)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(20, 13)
        Me.lblTo.TabIndex = 25
        Me.lblTo.Text = "To"
        '
        'dtpEffDateTo
        '
        Me.dtpEffDateTo.Checked = False
        Me.dtpEffDateTo.CustomFormat = "MMM yyyy"
        Me.dtpEffDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffDateTo.Location = New System.Drawing.Point(416, 12)
        Me.dtpEffDateTo.Name = "dtpEffDateTo"
        Me.dtpEffDateTo.ShowCheckBox = True
        Me.dtpEffDateTo.ShowUpDown = True
        Me.dtpEffDateTo.Size = New System.Drawing.Size(91, 20)
        Me.dtpEffDateTo.TabIndex = 3
        '
        'llbReset
        '
        Me.llbReset.AutoSize = True
        Me.llbReset.Location = New System.Drawing.Point(548, 15)
        Me.llbReset.Name = "llbReset"
        Me.llbReset.Size = New System.Drawing.Size(35, 13)
        Me.llbReset.TabIndex = 5
        Me.llbReset.TabStop = True
        Me.llbReset.Text = "Reset"
        '
        'frmAtcOffer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 377)
        Me.Controls.Add(Me.llbReset)
        Me.Controls.Add(Me.dtpEffDateTo)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.dtpEffDateFrom)
        Me.Controls.Add(Me.lblEffDateFrom)
        Me.Controls.Add(Me.llbCopy)
        Me.Controls.Add(Me.dgvAtcOfferDetail)
        Me.Controls.Add(Me.llbFilter)
        Me.Controls.Add(Me.cboCustomer)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.llbDelete)
        Me.Controls.Add(Me.llbEdit)
        Me.Controls.Add(Me.llbAdd)
        Me.Controls.Add(Me.dgvAtcOffer)
        Me.Name = "frmAtcOffer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "AtcOffer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvAtcOffer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAtcOfferDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAtcOffer As DataGridView
    Friend WithEvents llbAdd As LinkLabel
    Friend WithEvents llbEdit As LinkLabel
    Friend WithEvents llbDelete As LinkLabel
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents llbFilter As LinkLabel
    Friend WithEvents dgvAtcOfferDetail As DataGridView
    Friend WithEvents llbCopy As LinkLabel
    Friend WithEvents lblEffDateFrom As Label
    Friend WithEvents dtpEffDateFrom As DateTimePicker
    Friend WithEvents lblTo As Label
    Friend WithEvents dtpEffDateTo As DateTimePicker
    Friend WithEvents llbReset As LinkLabel
End Class
