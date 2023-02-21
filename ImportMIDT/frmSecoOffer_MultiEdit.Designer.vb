<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecoOffer_MultiEdit
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblExpDate = New System.Windows.Forms.Label()
        Me.dtpExpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEffDate = New System.Windows.Forms.Label()
        Me.dtpEffDate = New System.Windows.Forms.DateTimePicker()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.FromTheUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToTheUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PricePerUser = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PriceCombo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblExpDate
        '
        Me.lblExpDate.AutoSize = True
        Me.lblExpDate.Location = New System.Drawing.Point(12, 42)
        Me.lblExpDate.Name = "lblExpDate"
        Me.lblExpDate.Size = New System.Drawing.Size(51, 13)
        Me.lblExpDate.TabIndex = 36
        Me.lblExpDate.Text = "Exp Date"
        '
        'dtpExpDate
        '
        Me.dtpExpDate.CustomFormat = "MMM-yyyy"
        Me.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpDate.Location = New System.Drawing.Point(69, 38)
        Me.dtpExpDate.Name = "dtpExpDate"
        Me.dtpExpDate.ShowUpDown = True
        Me.dtpExpDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpExpDate.TabIndex = 1
        '
        'lblEffDate
        '
        Me.lblEffDate.AutoSize = True
        Me.lblEffDate.Location = New System.Drawing.Point(17, 16)
        Me.lblEffDate.Name = "lblEffDate"
        Me.lblEffDate.Size = New System.Drawing.Size(46, 13)
        Me.lblEffDate.TabIndex = 35
        Me.lblEffDate.Text = "Eff Date"
        '
        'dtpEffDate
        '
        Me.dtpEffDate.CustomFormat = "MMM-yyyy"
        Me.dtpEffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffDate.Location = New System.Drawing.Point(69, 12)
        Me.dtpEffDate.Name = "dtpEffDate"
        Me.dtpEffDate.ShowUpDown = True
        Me.dtpEffDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpEffDate.TabIndex = 0
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(69, 64)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(300, 20)
        Me.txtNote.TabIndex = 2
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(33, 67)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(30, 13)
        Me.lblNote.TabIndex = 38
        Me.lblNote.Text = "Note"
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(12, 246)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(42, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dgvDetail
        '
        Me.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FromTheUser, Me.ToTheUser, Me.PricePerUser, Me.PriceCombo})
        Me.dgvDetail.Location = New System.Drawing.Point(12, 90)
        Me.dgvDetail.Name = "dgvDetail"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgvDetail.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDetail.RowTemplate.DefaultCellStyle.Format = "N0"
        Me.dgvDetail.Size = New System.Drawing.Size(413, 150)
        Me.dgvDetail.TabIndex = 3
        '
        'FromTheUser
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "1"
        Me.FromTheUser.DefaultCellStyle = DataGridViewCellStyle1
        Me.FromTheUser.HeaderText = "FromTheUser"
        Me.FromTheUser.Name = "FromTheUser"
        Me.FromTheUser.Width = 96
        '
        'ToTheUser
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "1"
        Me.ToTheUser.DefaultCellStyle = DataGridViewCellStyle2
        Me.ToTheUser.HeaderText = "ToTheUser"
        Me.ToTheUser.Name = "ToTheUser"
        Me.ToTheUser.Width = 86
        '
        'PricePerUser
        '
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.PricePerUser.DefaultCellStyle = DataGridViewCellStyle3
        Me.PricePerUser.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.PricePerUser.HeaderText = "PricePerUser"
        Me.PricePerUser.Name = "PricePerUser"
        Me.PricePerUser.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PricePerUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PricePerUser.Width = 94
        '
        'PriceCombo
        '
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.PriceCombo.DefaultCellStyle = DataGridViewCellStyle4
        Me.PriceCombo.HeaderText = "PriceCombo"
        Me.PriceCombo.Name = "PriceCombo"
        Me.PriceCombo.Width = 89
        '
        'frmSecoOffer_MultiEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 276)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.lblExpDate)
        Me.Controls.Add(Me.dtpExpDate)
        Me.Controls.Add(Me.lblEffDate)
        Me.Controls.Add(Me.dtpEffDate)
        Me.Name = "frmSecoOffer_MultiEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SecoOffer_MultiEdit"
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblExpDate As Label
    Friend WithEvents dtpExpDate As DateTimePicker
    Friend WithEvents lblEffDate As Label
    Friend WithEvents dtpEffDate As DateTimePicker
    Friend WithEvents txtNote As TextBox
    Friend WithEvents lblNote As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents FromTheUser As DataGridViewTextBoxColumn
    Friend WithEvents ToTheUser As DataGridViewTextBoxColumn
    Friend WithEvents PricePerUser As DataGridViewComboBoxColumn
    Friend WithEvents PriceCombo As DataGridViewTextBoxColumn
End Class
