<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAtcCalcPrice
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
        Me.llbAdd = New System.Windows.Forms.LinkLabel()
        Me.lblCPMonthFrom = New System.Windows.Forms.Label()
        Me.dtpCPMonthFrom = New System.Windows.Forms.DateTimePicker()
        Me.llbFilter = New System.Windows.Forms.LinkLabel()
        Me.dgvAtcCalcPrice = New System.Windows.Forms.DataGridView()
        Me.llbDelete = New System.Windows.Forms.LinkLabel()
        Me.dgvAtcCalcPriceDetail = New System.Windows.Forms.DataGridView()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpCPMonthTo = New System.Windows.Forms.DateTimePicker()
        Me.llbReset = New System.Windows.Forms.LinkLabel()
        Me.llbConfirm = New System.Windows.Forms.LinkLabel()
        Me.dgvAtcCalcPriceDetail_D = New System.Windows.Forms.DataGridView()
        CType(Me.dgvAtcCalcPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAtcCalcPriceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAtcCalcPriceDetail_D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'llbAdd
        '
        Me.llbAdd.AutoSize = True
        Me.llbAdd.Location = New System.Drawing.Point(12, 16)
        Me.llbAdd.Name = "llbAdd"
        Me.llbAdd.Size = New System.Drawing.Size(52, 13)
        Me.llbAdd.TabIndex = 0
        Me.llbAdd.TabStop = True
        Me.llbAdd.Text = "CalcPrice"
        '
        'lblCPMonthFrom
        '
        Me.lblCPMonthFrom.AutoSize = True
        Me.lblCPMonthFrom.Location = New System.Drawing.Point(70, 16)
        Me.lblCPMonthFrom.Name = "lblCPMonthFrom"
        Me.lblCPMonthFrom.Size = New System.Drawing.Size(74, 13)
        Me.lblCPMonthFrom.TabIndex = 1
        Me.lblCPMonthFrom.Text = "CPMonthFrom"
        '
        'dtpCPMonthFrom
        '
        Me.dtpCPMonthFrom.Checked = False
        Me.dtpCPMonthFrom.CustomFormat = "MMM yyyy"
        Me.dtpCPMonthFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPMonthFrom.Location = New System.Drawing.Point(150, 12)
        Me.dtpCPMonthFrom.Name = "dtpCPMonthFrom"
        Me.dtpCPMonthFrom.ShowCheckBox = True
        Me.dtpCPMonthFrom.ShowUpDown = True
        Me.dtpCPMonthFrom.Size = New System.Drawing.Size(90, 20)
        Me.dtpCPMonthFrom.TabIndex = 1
        '
        'llbFilter
        '
        Me.llbFilter.AutoSize = True
        Me.llbFilter.Location = New System.Drawing.Point(368, 16)
        Me.llbFilter.Name = "llbFilter"
        Me.llbFilter.Size = New System.Drawing.Size(29, 13)
        Me.llbFilter.TabIndex = 3
        Me.llbFilter.TabStop = True
        Me.llbFilter.Text = "Filter"
        '
        'dgvAtcCalcPrice
        '
        Me.dgvAtcCalcPrice.AllowUserToAddRows = False
        Me.dgvAtcCalcPrice.AllowUserToDeleteRows = False
        Me.dgvAtcCalcPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAtcCalcPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAtcCalcPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAtcCalcPrice.Location = New System.Drawing.Point(12, 38)
        Me.dgvAtcCalcPrice.Name = "dgvAtcCalcPrice"
        Me.dgvAtcCalcPrice.ReadOnly = True
        Me.dgvAtcCalcPrice.Size = New System.Drawing.Size(776, 150)
        Me.dgvAtcCalcPrice.TabIndex = 5
        '
        'llbDelete
        '
        Me.llbDelete.AutoSize = True
        Me.llbDelete.Enabled = False
        Me.llbDelete.Location = New System.Drawing.Point(12, 191)
        Me.llbDelete.Name = "llbDelete"
        Me.llbDelete.Size = New System.Drawing.Size(38, 13)
        Me.llbDelete.TabIndex = 7
        Me.llbDelete.TabStop = True
        Me.llbDelete.Text = "Delete"
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
        Me.dgvAtcCalcPriceDetail.Location = New System.Drawing.Point(12, 207)
        Me.dgvAtcCalcPriceDetail.Name = "dgvAtcCalcPriceDetail"
        Me.dgvAtcCalcPriceDetail.ReadOnly = True
        Me.dgvAtcCalcPriceDetail.Size = New System.Drawing.Size(776, 150)
        Me.dgvAtcCalcPriceDetail.TabIndex = 9
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(246, 16)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(20, 13)
        Me.lblTo.TabIndex = 9
        Me.lblTo.Text = "To"
        '
        'dtpCPMonthTo
        '
        Me.dtpCPMonthTo.Checked = False
        Me.dtpCPMonthTo.CustomFormat = "MMM yyyy"
        Me.dtpCPMonthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPMonthTo.Location = New System.Drawing.Point(272, 12)
        Me.dtpCPMonthTo.Name = "dtpCPMonthTo"
        Me.dtpCPMonthTo.ShowCheckBox = True
        Me.dtpCPMonthTo.ShowUpDown = True
        Me.dtpCPMonthTo.Size = New System.Drawing.Size(90, 20)
        Me.dtpCPMonthTo.TabIndex = 2
        '
        'llbReset
        '
        Me.llbReset.AutoSize = True
        Me.llbReset.Location = New System.Drawing.Point(403, 16)
        Me.llbReset.Name = "llbReset"
        Me.llbReset.Size = New System.Drawing.Size(35, 13)
        Me.llbReset.TabIndex = 4
        Me.llbReset.TabStop = True
        Me.llbReset.Text = "Reset"
        '
        'llbConfirm
        '
        Me.llbConfirm.AutoSize = True
        Me.llbConfirm.Location = New System.Drawing.Point(92, 191)
        Me.llbConfirm.Name = "llbConfirm"
        Me.llbConfirm.Size = New System.Drawing.Size(96, 13)
        Me.llbConfirm.TabIndex = 8
        Me.llbConfirm.TabStop = True
        Me.llbConfirm.Text = "Confirm/UnConfirm"
        '
        'dgvAtcCalcPriceDetail_D
        '
        Me.dgvAtcCalcPriceDetail_D.AllowUserToAddRows = False
        Me.dgvAtcCalcPriceDetail_D.AllowUserToDeleteRows = False
        Me.dgvAtcCalcPriceDetail_D.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAtcCalcPriceDetail_D.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAtcCalcPriceDetail_D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAtcCalcPriceDetail_D.Location = New System.Drawing.Point(12, 363)
        Me.dgvAtcCalcPriceDetail_D.Name = "dgvAtcCalcPriceDetail_D"
        Me.dgvAtcCalcPriceDetail_D.ReadOnly = True
        Me.dgvAtcCalcPriceDetail_D.Size = New System.Drawing.Size(776, 150)
        Me.dgvAtcCalcPriceDetail_D.TabIndex = 10
        '
        'frmAtcCalcPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 525)
        Me.Controls.Add(Me.dgvAtcCalcPriceDetail_D)
        Me.Controls.Add(Me.llbConfirm)
        Me.Controls.Add(Me.llbReset)
        Me.Controls.Add(Me.dtpCPMonthTo)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.dgvAtcCalcPriceDetail)
        Me.Controls.Add(Me.llbDelete)
        Me.Controls.Add(Me.dgvAtcCalcPrice)
        Me.Controls.Add(Me.llbFilter)
        Me.Controls.Add(Me.dtpCPMonthFrom)
        Me.Controls.Add(Me.lblCPMonthFrom)
        Me.Controls.Add(Me.llbAdd)
        Me.Name = "frmAtcCalcPrice"
        Me.Text = "AtcCalcPrice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvAtcCalcPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAtcCalcPriceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAtcCalcPriceDetail_D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents llbAdd As LinkLabel
    Friend WithEvents lblCPMonthFrom As Label
    Friend WithEvents dtpCPMonthFrom As DateTimePicker
    Friend WithEvents llbFilter As LinkLabel
    Friend WithEvents dgvAtcCalcPrice As DataGridView
    Friend WithEvents llbDelete As LinkLabel
    Friend WithEvents dgvAtcCalcPriceDetail As DataGridView
    Friend WithEvents lblTo As Label
    Friend WithEvents dtpCPMonthTo As DateTimePicker
    Friend WithEvents llbReset As LinkLabel
    Friend WithEvents llbConfirm As LinkLabel
    Friend WithEvents dgvAtcCalcPriceDetail_D As DataGridView
End Class
