<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPricePerUser
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
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        Me.llbadd = New System.Windows.Forms.LinkLabel()
        Me.llbEdit = New System.Windows.Forms.LinkLabel()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.llbDelete = New System.Windows.Forms.LinkLabel()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMain
        '
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        Me.dgvMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Location = New System.Drawing.Point(0, 38)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.ReadOnly = True
        Me.dgvMain.Size = New System.Drawing.Size(267, 412)
        Me.dgvMain.TabIndex = 0
        '
        'llbadd
        '
        Me.llbadd.AutoSize = True
        Me.llbadd.Location = New System.Drawing.Point(155, 16)
        Me.llbadd.Name = "llbadd"
        Me.llbadd.Size = New System.Drawing.Size(26, 13)
        Me.llbadd.TabIndex = 2
        Me.llbadd.TabStop = True
        Me.llbadd.Text = "Add"
        '
        'llbEdit
        '
        Me.llbEdit.AutoSize = True
        Me.llbEdit.Enabled = False
        Me.llbEdit.Location = New System.Drawing.Point(187, 16)
        Me.llbEdit.Name = "llbEdit"
        Me.llbEdit.Size = New System.Drawing.Size(25, 13)
        Me.llbEdit.TabIndex = 3
        Me.llbEdit.TabStop = True
        Me.llbEdit.Text = "Edit"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(49, 12)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtPrice.TabIndex = 4
        Me.txtPrice.Text = "0"
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(12, 16)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(31, 13)
        Me.lblPrice.TabIndex = 5
        Me.lblPrice.Text = "Price"
        '
        'llbDelete
        '
        Me.llbDelete.AutoSize = True
        Me.llbDelete.Enabled = False
        Me.llbDelete.Location = New System.Drawing.Point(218, 16)
        Me.llbDelete.Name = "llbDelete"
        Me.llbDelete.Size = New System.Drawing.Size(38, 13)
        Me.llbDelete.TabIndex = 6
        Me.llbDelete.TabStop = True
        Me.llbDelete.Text = "Delete"
        '
        'frmPricePerUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 450)
        Me.Controls.Add(Me.llbDelete)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.llbEdit)
        Me.Controls.Add(Me.llbadd)
        Me.Controls.Add(Me.dgvMain)
        Me.Name = "frmPricePerUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PricePerUser"
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvMain As DataGridView
    Friend WithEvents llbadd As LinkLabel
    Friend WithEvents llbEdit As LinkLabel
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents llbDelete As LinkLabel
End Class
