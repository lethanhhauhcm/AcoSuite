<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMapping
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtSIName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOID = New System.Windows.Forms.TextBox()
        Me.CmbSI = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblUpdateUser = New System.Windows.Forms.LinkLabel()
        Me.GridUser = New System.Windows.Forms.DataGridView()
        Me.LblDeleteUser = New System.Windows.Forms.LinkLabel()
        Me.LblAddThisSICode = New System.Windows.Forms.LinkLabel()
        Me.TxtUserID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblUpdateOwner = New System.Windows.Forms.LinkLabel()
        Me.LblDeleteOwner = New System.Windows.Forms.LinkLabel()
        Me.GridOwner = New System.Windows.Forms.DataGridView()
        Me.TxtAgency = New System.Windows.Forms.TextBox()
        CType(Me.GridUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOwner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtSIName
        '
        Me.TxtSIName.Enabled = False
        Me.TxtSIName.Location = New System.Drawing.Point(302, 5)
        Me.TxtSIName.Name = "TxtSIName"
        Me.TxtSIName.Size = New System.Drawing.Size(167, 20)
        Me.TxtSIName.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(251, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "FullName"
        '
        'TxtEmail
        '
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmail.Location = New System.Drawing.Point(39, 5)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(209, 20)
        Me.TxtEmail.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "eMail"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(475, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "OID"
        '
        'txtOID
        '
        Me.txtOID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOID.Location = New System.Drawing.Point(507, 5)
        Me.txtOID.MaxLength = 9
        Me.txtOID.Name = "txtOID"
        Me.txtOID.Size = New System.Drawing.Size(79, 20)
        Me.txtOID.TabIndex = 7
        '
        'CmbSI
        '
        Me.CmbSI.FormattingEnabled = True
        Me.CmbSI.Location = New System.Drawing.Point(635, 5)
        Me.CmbSI.Name = "CmbSI"
        Me.CmbSI.Size = New System.Drawing.Size(100, 21)
        Me.CmbSI.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(584, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "SI Code"
        '
        'LblUpdateUser
        '
        Me.LblUpdateUser.AutoSize = True
        Me.LblUpdateUser.Location = New System.Drawing.Point(738, 8)
        Me.LblUpdateUser.Name = "LblUpdateUser"
        Me.LblUpdateUser.Size = New System.Drawing.Size(42, 13)
        Me.LblUpdateUser.TabIndex = 9
        Me.LblUpdateUser.TabStop = True
        Me.LblUpdateUser.Text = "Update"
        '
        'GridUser
        '
        Me.GridUser.AllowUserToAddRows = False
        Me.GridUser.AllowUserToDeleteRows = False
        Me.GridUser.BackgroundColor = System.Drawing.Color.CornflowerBlue
        Me.GridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridUser.Location = New System.Drawing.Point(2, 31)
        Me.GridUser.Name = "GridUser"
        Me.GridUser.RowHeadersVisible = False
        Me.GridUser.Size = New System.Drawing.Size(392, 439)
        Me.GridUser.TabIndex = 10
        '
        'LblDeleteUser
        '
        Me.LblDeleteUser.AutoSize = True
        Me.LblDeleteUser.Location = New System.Drawing.Point(3, 476)
        Me.LblDeleteUser.Name = "LblDeleteUser"
        Me.LblDeleteUser.Size = New System.Drawing.Size(38, 13)
        Me.LblDeleteUser.TabIndex = 11
        Me.LblDeleteUser.TabStop = True
        Me.LblDeleteUser.Text = "Delete"
        Me.LblDeleteUser.Visible = False
        '
        'LblAddThisSICode
        '
        Me.LblAddThisSICode.AutoSize = True
        Me.LblAddThisSICode.Location = New System.Drawing.Point(632, 476)
        Me.LblAddThisSICode.Name = "LblAddThisSICode"
        Me.LblAddThisSICode.Size = New System.Drawing.Size(87, 13)
        Me.LblAddThisSICode.TabIndex = 14
        Me.LblAddThisSICode.TabStop = True
        Me.LblAddThisSICode.Text = "Add This SICode"
        Me.LblAddThisSICode.Visible = False
        '
        'TxtUserID
        '
        Me.TxtUserID.Enabled = False
        Me.TxtUserID.Location = New System.Drawing.Point(302, 473)
        Me.TxtUserID.Name = "TxtUserID"
        Me.TxtUserID.Size = New System.Drawing.Size(92, 20)
        Me.TxtUserID.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 476)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "UserID"
        '
        'LblUpdateOwner
        '
        Me.LblUpdateOwner.AutoSize = True
        Me.LblUpdateOwner.Location = New System.Drawing.Point(738, 8)
        Me.LblUpdateOwner.Name = "LblUpdateOwner"
        Me.LblUpdateOwner.Size = New System.Drawing.Size(42, 13)
        Me.LblUpdateOwner.TabIndex = 16
        Me.LblUpdateOwner.TabStop = True
        Me.LblUpdateOwner.Text = "Update"
        '
        'LblDeleteOwner
        '
        Me.LblDeleteOwner.AutoSize = True
        Me.LblDeleteOwner.Location = New System.Drawing.Point(738, 476)
        Me.LblDeleteOwner.Name = "LblDeleteOwner"
        Me.LblDeleteOwner.Size = New System.Drawing.Size(38, 13)
        Me.LblDeleteOwner.TabIndex = 17
        Me.LblDeleteOwner.TabStop = True
        Me.LblDeleteOwner.Text = "Delete"
        '
        'GridOwner
        '
        Me.GridOwner.AllowUserToAddRows = False
        Me.GridOwner.AllowUserToDeleteRows = False
        Me.GridOwner.BackgroundColor = System.Drawing.Color.CornflowerBlue
        Me.GridOwner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridOwner.Location = New System.Drawing.Point(400, 31)
        Me.GridOwner.Name = "GridOwner"
        Me.GridOwner.RowHeadersVisible = False
        Me.GridOwner.Size = New System.Drawing.Size(380, 439)
        Me.GridOwner.TabIndex = 10
        '
        'TxtAgency
        '
        Me.TxtAgency.Location = New System.Drawing.Point(588, 5)
        Me.TxtAgency.Name = "TxtAgency"
        Me.TxtAgency.Size = New System.Drawing.Size(147, 20)
        Me.TxtAgency.TabIndex = 18
        '
        'UserMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 496)
        Me.Controls.Add(Me.TxtAgency)
        Me.Controls.Add(Me.LblDeleteOwner)
        Me.Controls.Add(Me.LblUpdateOwner)
        Me.Controls.Add(Me.TxtUserID)
        Me.Controls.Add(Me.LblAddThisSICode)
        Me.Controls.Add(Me.LblDeleteUser)
        Me.Controls.Add(Me.GridOwner)
        Me.Controls.Add(Me.GridUser)
        Me.Controls.Add(Me.LblUpdateUser)
        Me.Controls.Add(Me.CmbSI)
        Me.Controls.Add(Me.TxtSIName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtOID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.Label7)
        Me.Location = New System.Drawing.Point(0, 50)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserMapping"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Reward :. User Mapping"
        CType(Me.GridUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOwner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSIName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOID As System.Windows.Forms.TextBox
    Friend WithEvents CmbSI As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblUpdateUser As System.Windows.Forms.LinkLabel
    Friend WithEvents GridUser As System.Windows.Forms.DataGridView
    Friend WithEvents LblDeleteUser As System.Windows.Forms.LinkLabel
    Friend WithEvents LblAddThisSICode As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblUpdateOwner As System.Windows.Forms.LinkLabel
    Friend WithEvents LblDeleteOwner As System.Windows.Forms.LinkLabel
    Friend WithEvents GridOwner As System.Windows.Forms.DataGridView
    Friend WithEvents TxtAgency As System.Windows.Forms.TextBox
End Class
