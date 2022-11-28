<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeCustomer
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
        Me.llbShortName = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.cboLocationName = New System.Windows.Forms.ComboBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.cboOffcId = New System.Windows.Forms.ComboBox()
        Me.lblOffcId = New System.Windows.Forms.Label()
        Me.lblSignIn = New System.Windows.Forms.Label()
        Me.txtSignIn = New System.Windows.Forms.TextBox()
        Me.llbAddGrid = New System.Windows.Forms.LinkLabel()
        Me.lblGridSignIn = New System.Windows.Forms.Label()
        Me.dgvSignIn = New System.Windows.Forms.DataGridView()
        Me.OffcId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SignIn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llbDeleteGrid = New System.Windows.Forms.LinkLabel()
        Me.llbClearGrid = New System.Windows.Forms.LinkLabel()
        CType(Me.dgvSignIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'llbShortName
        '
        Me.llbShortName.AutoSize = True
        Me.llbShortName.Location = New System.Drawing.Point(28, 15)
        Me.llbShortName.Name = "llbShortName"
        Me.llbShortName.Size = New System.Drawing.Size(60, 13)
        Me.llbShortName.TabIndex = 0
        Me.llbShortName.Text = "ShortName"
        '
        'cboShortName
        '
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(94, 12)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(130, 21)
        Me.cboShortName.TabIndex = 1
        '
        'btnOk
        '
        Me.btnOk.AutoSize = True
        Me.btnOk.Location = New System.Drawing.Point(172, 249)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'cboLocationName
        '
        Me.cboLocationName.FormattingEnabled = True
        Me.cboLocationName.Location = New System.Drawing.Point(94, 39)
        Me.cboLocationName.Name = "cboLocationName"
        Me.cboLocationName.Size = New System.Drawing.Size(200, 21)
        Me.cboLocationName.TabIndex = 4
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(12, 42)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(76, 13)
        Me.lblLocation.TabIndex = 3
        Me.lblLocation.Text = "LocationName"
        '
        'cboOffcId
        '
        Me.cboOffcId.FormattingEnabled = True
        Me.cboOffcId.Location = New System.Drawing.Point(94, 66)
        Me.cboOffcId.Name = "cboOffcId"
        Me.cboOffcId.Size = New System.Drawing.Size(140, 21)
        Me.cboOffcId.TabIndex = 6
        '
        'lblOffcId
        '
        Me.lblOffcId.AutoSize = True
        Me.lblOffcId.Location = New System.Drawing.Point(52, 69)
        Me.lblOffcId.Name = "lblOffcId"
        Me.lblOffcId.Size = New System.Drawing.Size(36, 13)
        Me.lblOffcId.TabIndex = 5
        Me.lblOffcId.Text = "OffcId"
        '
        'lblSignIn
        '
        Me.lblSignIn.AutoSize = True
        Me.lblSignIn.Location = New System.Drawing.Point(240, 69)
        Me.lblSignIn.Name = "lblSignIn"
        Me.lblSignIn.Size = New System.Drawing.Size(37, 13)
        Me.lblSignIn.TabIndex = 7
        Me.lblSignIn.Text = "SignIn"
        '
        'txtSignIn
        '
        Me.txtSignIn.Location = New System.Drawing.Point(283, 66)
        Me.txtSignIn.Name = "txtSignIn"
        Me.txtSignIn.Size = New System.Drawing.Size(60, 20)
        Me.txtSignIn.TabIndex = 8
        '
        'llbAddGrid
        '
        Me.llbAddGrid.AutoSize = True
        Me.llbAddGrid.Location = New System.Drawing.Point(349, 69)
        Me.llbAddGrid.Name = "llbAddGrid"
        Me.llbAddGrid.Size = New System.Drawing.Size(45, 13)
        Me.llbAddGrid.TabIndex = 9
        Me.llbAddGrid.TabStop = True
        Me.llbAddGrid.Text = "AddGrid"
        '
        'lblGridSignIn
        '
        Me.lblGridSignIn.AutoSize = True
        Me.lblGridSignIn.Location = New System.Drawing.Point(32, 93)
        Me.lblGridSignIn.Name = "lblGridSignIn"
        Me.lblGridSignIn.Size = New System.Drawing.Size(56, 13)
        Me.lblGridSignIn.TabIndex = 11
        Me.lblGridSignIn.Text = "GridSignIn"
        '
        'dgvSignIn
        '
        Me.dgvSignIn.AllowUserToAddRows = False
        Me.dgvSignIn.AllowUserToDeleteRows = False
        Me.dgvSignIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSignIn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OffcId, Me.SignIn})
        Me.dgvSignIn.Location = New System.Drawing.Point(94, 93)
        Me.dgvSignIn.Name = "dgvSignIn"
        Me.dgvSignIn.ReadOnly = True
        Me.dgvSignIn.Size = New System.Drawing.Size(249, 150)
        Me.dgvSignIn.TabIndex = 12
        '
        'OffcId
        '
        Me.OffcId.HeaderText = "OffcId"
        Me.OffcId.Name = "OffcId"
        Me.OffcId.ReadOnly = True
        Me.OffcId.Width = 140
        '
        'SignIn
        '
        Me.SignIn.HeaderText = "SignIn"
        Me.SignIn.Name = "SignIn"
        Me.SignIn.ReadOnly = True
        Me.SignIn.Width = 60
        '
        'llbDeleteGrid
        '
        Me.llbDeleteGrid.AutoSize = True
        Me.llbDeleteGrid.Enabled = False
        Me.llbDeleteGrid.Location = New System.Drawing.Point(349, 93)
        Me.llbDeleteGrid.Name = "llbDeleteGrid"
        Me.llbDeleteGrid.Size = New System.Drawing.Size(57, 13)
        Me.llbDeleteGrid.TabIndex = 13
        Me.llbDeleteGrid.TabStop = True
        Me.llbDeleteGrid.Text = "DeleteGrid"
        '
        'llbClearGrid
        '
        Me.llbClearGrid.AutoSize = True
        Me.llbClearGrid.Enabled = False
        Me.llbClearGrid.Location = New System.Drawing.Point(349, 230)
        Me.llbClearGrid.Name = "llbClearGrid"
        Me.llbClearGrid.Size = New System.Drawing.Size(50, 13)
        Me.llbClearGrid.TabIndex = 14
        Me.llbClearGrid.TabStop = True
        Me.llbClearGrid.Text = "ClearGrid"
        '
        'frmChangeCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 278)
        Me.Controls.Add(Me.llbClearGrid)
        Me.Controls.Add(Me.llbDeleteGrid)
        Me.Controls.Add(Me.dgvSignIn)
        Me.Controls.Add(Me.lblGridSignIn)
        Me.Controls.Add(Me.llbAddGrid)
        Me.Controls.Add(Me.txtSignIn)
        Me.Controls.Add(Me.lblSignIn)
        Me.Controls.Add(Me.cboOffcId)
        Me.Controls.Add(Me.lblOffcId)
        Me.Controls.Add(Me.cboLocationName)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.llbShortName)
        Me.Name = "frmChangeCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChangeCustomer"
        CType(Me.dgvSignIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents llbShortName As Label
    Friend WithEvents cboShortName As ComboBox
    Friend WithEvents btnOk As Button
    Friend WithEvents cboLocationName As ComboBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents cboOffcId As ComboBox
    Friend WithEvents lblOffcId As Label
    Friend WithEvents lblSignIn As Label
    Friend WithEvents txtSignIn As TextBox
    Friend WithEvents llbAddGrid As LinkLabel
    Friend WithEvents lblGridSignIn As Label
    Friend WithEvents dgvSignIn As DataGridView
    Friend WithEvents llbDeleteGrid As LinkLabel
    Friend WithEvents llbClearGrid As LinkLabel
    Friend WithEvents OffcId As DataGridViewTextBoxColumn
    Friend WithEvents SignIn As DataGridViewTextBoxColumn
End Class
