<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecoPpd
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
        Me.tcSecoPpd = New System.Windows.Forms.TabControl()
        Me.tpList = New System.Windows.Forms.TabPage()
        Me.dgvSecoPpdDetail_D = New System.Windows.Forms.DataGridView()
        Me.dgvSecoPpdDetail = New System.Windows.Forms.DataGridView()
        Me.llbExportXls = New System.Windows.Forms.LinkLabel()
        Me.llbDelete = New System.Windows.Forms.LinkLabel()
        Me.dgvSecoPpd = New System.Windows.Forms.DataGridView()
        Me.llbCalcSecoPpd = New System.Windows.Forms.LinkLabel()
        Me.tpInput = New System.Windows.Forms.TabPage()
        Me.llbSave = New System.Windows.Forms.LinkLabel()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.txtTotalUser = New System.Windows.Forms.TextBox()
        Me.lblTotalUser = New System.Windows.Forms.Label()
        Me.dgvSecoPpdDetail_D2 = New System.Windows.Forms.DataGridView()
        Me.dgvSecoPpdDetail2 = New System.Windows.Forms.DataGridView()
        Me.llbCalcSecoPpd2 = New System.Windows.Forms.LinkLabel()
        Me.lstCustomer = New System.Windows.Forms.ListBox()
        Me.lblSecoPpdYear = New System.Windows.Forms.Label()
        Me.dtpSecoPpdYear = New System.Windows.Forms.DateTimePicker()
        Me.llbCancel = New System.Windows.Forms.LinkLabel()
        Me.tcSecoPpd.SuspendLayout()
        Me.tpList.SuspendLayout()
        CType(Me.dgvSecoPpdDetail_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSecoPpdDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSecoPpd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInput.SuspendLayout()
        CType(Me.dgvSecoPpdDetail_D2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSecoPpdDetail2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcSecoPpd
        '
        Me.tcSecoPpd.Controls.Add(Me.tpList)
        Me.tcSecoPpd.Controls.Add(Me.tpInput)
        Me.tcSecoPpd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSecoPpd.Location = New System.Drawing.Point(0, 0)
        Me.tcSecoPpd.Name = "tcSecoPpd"
        Me.tcSecoPpd.SelectedIndex = 0
        Me.tcSecoPpd.Size = New System.Drawing.Size(800, 550)
        Me.tcSecoPpd.TabIndex = 0
        '
        'tpList
        '
        Me.tpList.BackColor = System.Drawing.SystemColors.Control
        Me.tpList.Controls.Add(Me.dgvSecoPpdDetail_D)
        Me.tpList.Controls.Add(Me.dgvSecoPpdDetail)
        Me.tpList.Controls.Add(Me.llbExportXls)
        Me.tpList.Controls.Add(Me.llbDelete)
        Me.tpList.Controls.Add(Me.dgvSecoPpd)
        Me.tpList.Controls.Add(Me.llbCalcSecoPpd)
        Me.tpList.Location = New System.Drawing.Point(4, 22)
        Me.tpList.Name = "tpList"
        Me.tpList.Padding = New System.Windows.Forms.Padding(3)
        Me.tpList.Size = New System.Drawing.Size(792, 524)
        Me.tpList.TabIndex = 0
        Me.tpList.Text = "List"
        '
        'dgvSecoPpdDetail_D
        '
        Me.dgvSecoPpdDetail_D.AllowUserToAddRows = False
        Me.dgvSecoPpdDetail_D.AllowUserToDeleteRows = False
        Me.dgvSecoPpdDetail_D.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSecoPpdDetail_D.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSecoPpdDetail_D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSecoPpdDetail_D.Location = New System.Drawing.Point(6, 363)
        Me.dgvSecoPpdDetail_D.Name = "dgvSecoPpdDetail_D"
        Me.dgvSecoPpdDetail_D.ReadOnly = True
        Me.dgvSecoPpdDetail_D.Size = New System.Drawing.Size(780, 150)
        Me.dgvSecoPpdDetail_D.TabIndex = 5
        '
        'dgvSecoPpdDetail
        '
        Me.dgvSecoPpdDetail.AllowUserToAddRows = False
        Me.dgvSecoPpdDetail.AllowUserToDeleteRows = False
        Me.dgvSecoPpdDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSecoPpdDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSecoPpdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSecoPpdDetail.Location = New System.Drawing.Point(6, 188)
        Me.dgvSecoPpdDetail.Name = "dgvSecoPpdDetail"
        Me.dgvSecoPpdDetail.ReadOnly = True
        Me.dgvSecoPpdDetail.Size = New System.Drawing.Size(780, 169)
        Me.dgvSecoPpdDetail.TabIndex = 4
        '
        'llbExportXls
        '
        Me.llbExportXls.AutoSize = True
        Me.llbExportXls.Location = New System.Drawing.Point(77, 172)
        Me.llbExportXls.Name = "llbExportXls"
        Me.llbExportXls.Size = New System.Drawing.Size(51, 13)
        Me.llbExportXls.TabIndex = 3
        Me.llbExportXls.TabStop = True
        Me.llbExportXls.Text = "ExportXls"
        '
        'llbDelete
        '
        Me.llbDelete.AutoSize = True
        Me.llbDelete.Location = New System.Drawing.Point(6, 172)
        Me.llbDelete.Name = "llbDelete"
        Me.llbDelete.Size = New System.Drawing.Size(38, 13)
        Me.llbDelete.TabIndex = 2
        Me.llbDelete.TabStop = True
        Me.llbDelete.Text = "Delete"
        '
        'dgvSecoPpd
        '
        Me.dgvSecoPpd.AllowUserToAddRows = False
        Me.dgvSecoPpd.AllowUserToDeleteRows = False
        Me.dgvSecoPpd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSecoPpd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSecoPpd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSecoPpd.Location = New System.Drawing.Point(6, 19)
        Me.dgvSecoPpd.Name = "dgvSecoPpd"
        Me.dgvSecoPpd.ReadOnly = True
        Me.dgvSecoPpd.Size = New System.Drawing.Size(780, 150)
        Me.dgvSecoPpd.TabIndex = 1
        '
        'llbCalcSecoPpd
        '
        Me.llbCalcSecoPpd.AutoSize = True
        Me.llbCalcSecoPpd.Location = New System.Drawing.Point(6, 3)
        Me.llbCalcSecoPpd.Name = "llbCalcSecoPpd"
        Me.llbCalcSecoPpd.Size = New System.Drawing.Size(72, 13)
        Me.llbCalcSecoPpd.TabIndex = 0
        Me.llbCalcSecoPpd.TabStop = True
        Me.llbCalcSecoPpd.Text = "CalcSecoPpd"
        '
        'tpInput
        '
        Me.tpInput.BackColor = System.Drawing.SystemColors.Control
        Me.tpInput.Controls.Add(Me.llbSave)
        Me.tpInput.Controls.Add(Me.txtTotalAmount)
        Me.tpInput.Controls.Add(Me.lblTotalAmount)
        Me.tpInput.Controls.Add(Me.txtTotalUser)
        Me.tpInput.Controls.Add(Me.lblTotalUser)
        Me.tpInput.Controls.Add(Me.dgvSecoPpdDetail_D2)
        Me.tpInput.Controls.Add(Me.dgvSecoPpdDetail2)
        Me.tpInput.Controls.Add(Me.llbCalcSecoPpd2)
        Me.tpInput.Controls.Add(Me.lstCustomer)
        Me.tpInput.Controls.Add(Me.lblSecoPpdYear)
        Me.tpInput.Controls.Add(Me.dtpSecoPpdYear)
        Me.tpInput.Controls.Add(Me.llbCancel)
        Me.tpInput.Location = New System.Drawing.Point(4, 22)
        Me.tpInput.Name = "tpInput"
        Me.tpInput.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInput.Size = New System.Drawing.Size(792, 524)
        Me.tpInput.TabIndex = 1
        Me.tpInput.Text = "Input"
        '
        'llbSave
        '
        Me.llbSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llbSave.AutoSize = True
        Me.llbSave.Location = New System.Drawing.Point(6, 503)
        Me.llbSave.Name = "llbSave"
        Me.llbSave.Size = New System.Drawing.Size(32, 13)
        Me.llbSave.TabIndex = 12
        Me.llbSave.TabStop = True
        Me.llbSave.Text = "Save"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAmount.Location = New System.Drawing.Point(289, 480)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAmount.TabIndex = 11
        Me.txtTotalAmount.Text = "0"
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(216, 483)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(67, 13)
        Me.lblTotalAmount.TabIndex = 10
        Me.lblTotalAmount.Text = "TotalAmount"
        '
        'txtTotalUser
        '
        Me.txtTotalUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalUser.Location = New System.Drawing.Point(69, 480)
        Me.txtTotalUser.Name = "txtTotalUser"
        Me.txtTotalUser.ReadOnly = True
        Me.txtTotalUser.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalUser.TabIndex = 9
        Me.txtTotalUser.Text = "0"
        Me.txtTotalUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalUser
        '
        Me.lblTotalUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalUser.AutoSize = True
        Me.lblTotalUser.Location = New System.Drawing.Point(10, 483)
        Me.lblTotalUser.Name = "lblTotalUser"
        Me.lblTotalUser.Size = New System.Drawing.Size(53, 13)
        Me.lblTotalUser.TabIndex = 8
        Me.lblTotalUser.Text = "TotalUser"
        '
        'dgvSecoPpdDetail_D2
        '
        Me.dgvSecoPpdDetail_D2.AllowUserToAddRows = False
        Me.dgvSecoPpdDetail_D2.AllowUserToDeleteRows = False
        Me.dgvSecoPpdDetail_D2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSecoPpdDetail_D2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSecoPpdDetail_D2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSecoPpdDetail_D2.Location = New System.Drawing.Point(6, 324)
        Me.dgvSecoPpdDetail_D2.Name = "dgvSecoPpdDetail_D2"
        Me.dgvSecoPpdDetail_D2.ReadOnly = True
        Me.dgvSecoPpdDetail_D2.Size = New System.Drawing.Size(780, 150)
        Me.dgvSecoPpdDetail_D2.TabIndex = 7
        '
        'dgvSecoPpdDetail2
        '
        Me.dgvSecoPpdDetail2.AllowUserToAddRows = False
        Me.dgvSecoPpdDetail2.AllowUserToDeleteRows = False
        Me.dgvSecoPpdDetail2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSecoPpdDetail2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSecoPpdDetail2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSecoPpdDetail2.Location = New System.Drawing.Point(6, 168)
        Me.dgvSecoPpdDetail2.Name = "dgvSecoPpdDetail2"
        Me.dgvSecoPpdDetail2.ReadOnly = True
        Me.dgvSecoPpdDetail2.Size = New System.Drawing.Size(780, 150)
        Me.dgvSecoPpdDetail2.TabIndex = 6
        '
        'llbCalcSecoPpd2
        '
        Me.llbCalcSecoPpd2.AutoSize = True
        Me.llbCalcSecoPpd2.Location = New System.Drawing.Point(6, 152)
        Me.llbCalcSecoPpd2.Name = "llbCalcSecoPpd2"
        Me.llbCalcSecoPpd2.Size = New System.Drawing.Size(72, 13)
        Me.llbCalcSecoPpd2.TabIndex = 5
        Me.llbCalcSecoPpd2.TabStop = True
        Me.llbCalcSecoPpd2.Text = "CalcSecoPpd"
        '
        'lstCustomer
        '
        Me.lstCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.lstCustomer.FormattingEnabled = True
        Me.lstCustomer.Location = New System.Drawing.Point(8, 54)
        Me.lstCustomer.MultiColumn = True
        Me.lstCustomer.Name = "lstCustomer"
        Me.lstCustomer.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstCustomer.Size = New System.Drawing.Size(778, 95)
        Me.lstCustomer.TabIndex = 4
        '
        'lblSecoPpdYear
        '
        Me.lblSecoPpdYear.AutoSize = True
        Me.lblSecoPpdYear.Location = New System.Drawing.Point(13, 32)
        Me.lblSecoPpdYear.Name = "lblSecoPpdYear"
        Me.lblSecoPpdYear.Size = New System.Drawing.Size(73, 13)
        Me.lblSecoPpdYear.TabIndex = 3
        Me.lblSecoPpdYear.Text = "SecoPpdYear"
        '
        'dtpSecoPpdYear
        '
        Me.dtpSecoPpdYear.CustomFormat = "yyyy"
        Me.dtpSecoPpdYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSecoPpdYear.Location = New System.Drawing.Point(92, 28)
        Me.dtpSecoPpdYear.Name = "dtpSecoPpdYear"
        Me.dtpSecoPpdYear.ShowUpDown = True
        Me.dtpSecoPpdYear.Size = New System.Drawing.Size(52, 20)
        Me.dtpSecoPpdYear.TabIndex = 2
        '
        'llbCancel
        '
        Me.llbCancel.AutoSize = True
        Me.llbCancel.Location = New System.Drawing.Point(6, 3)
        Me.llbCancel.Name = "llbCancel"
        Me.llbCancel.Size = New System.Drawing.Size(40, 13)
        Me.llbCancel.TabIndex = 1
        Me.llbCancel.TabStop = True
        Me.llbCancel.Text = "Cancel"
        '
        'frmSecoPpd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 550)
        Me.Controls.Add(Me.tcSecoPpd)
        Me.Name = "frmSecoPpd"
        Me.Text = "SecoPpd"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcSecoPpd.ResumeLayout(False)
        Me.tpList.ResumeLayout(False)
        Me.tpList.PerformLayout()
        CType(Me.dgvSecoPpdDetail_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSecoPpdDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSecoPpd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInput.ResumeLayout(False)
        Me.tpInput.PerformLayout()
        CType(Me.dgvSecoPpdDetail_D2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSecoPpdDetail2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcSecoPpd As TabControl
    Friend WithEvents tpList As TabPage
    Friend WithEvents tpInput As TabPage
    Friend WithEvents dgvSecoPpdDetail_D As DataGridView
    Friend WithEvents dgvSecoPpdDetail As DataGridView
    Friend WithEvents llbExportXls As LinkLabel
    Friend WithEvents llbDelete As LinkLabel
    Friend WithEvents dgvSecoPpd As DataGridView
    Friend WithEvents llbCalcSecoPpd As LinkLabel
    Friend WithEvents lblSecoPpdYear As Label
    Friend WithEvents dtpSecoPpdYear As DateTimePicker
    Friend WithEvents llbCancel As LinkLabel
    Friend WithEvents lstCustomer As ListBox
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents txtTotalUser As TextBox
    Friend WithEvents lblTotalUser As Label
    Friend WithEvents dgvSecoPpdDetail_D2 As DataGridView
    Friend WithEvents dgvSecoPpdDetail2 As DataGridView
    Friend WithEvents llbCalcSecoPpd2 As LinkLabel
    Friend WithEvents llbSave As LinkLabel
End Class
