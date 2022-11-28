<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecoInfo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgSignIn1A = New System.Windows.Forms.DataGridView()
        Me.lbkSave = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.cboProduct = New System.Windows.Forms.ComboBox()
        Me.cboEmail = New System.Windows.Forms.ComboBox()
        Me.txtDOB = New System.Windows.Forms.TextBox()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.lbkUpdateSecoID = New System.Windows.Forms.LinkLabel()
        Me.txtSecoId = New System.Windows.Forms.TextBox()
        Me.chkAdmin = New System.Windows.Forms.CheckBox()
        Me.lbkCopy = New System.Windows.Forms.LinkLabel()
        CType(Me.dgSignIn1A, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Email"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Mobile"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "DOB"
        '
        'dgSignIn1A
        '
        Me.dgSignIn1A.AllowUserToAddRows = False
        Me.dgSignIn1A.AllowUserToDeleteRows = False
        Me.dgSignIn1A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSignIn1A.Location = New System.Drawing.Point(3, 111)
        Me.dgSignIn1A.Name = "dgSignIn1A"
        Me.dgSignIn1A.ReadOnly = True
        Me.dgSignIn1A.Size = New System.Drawing.Size(477, 125)
        Me.dgSignIn1A.TabIndex = 4
        '
        'lbkSave
        '
        Me.lbkSave.AutoSize = True
        Me.lbkSave.Location = New System.Drawing.Point(0, 251)
        Me.lbkSave.Name = "lbkSave"
        Me.lbkSave.Size = New System.Drawing.Size(32, 13)
        Me.lbkSave.TabIndex = 5
        Me.lbkSave.TabStop = True
        Me.lbkSave.Text = "Save"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(38, 251)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 6
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'cboProduct
        '
        Me.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(50, 6)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(121, 21)
        Me.cboProduct.TabIndex = 0
        '
        'cboEmail
        '
        Me.cboEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmail.FormattingEnabled = True
        Me.cboEmail.Location = New System.Drawing.Point(50, 32)
        Me.cboEmail.Name = "cboEmail"
        Me.cboEmail.Size = New System.Drawing.Size(363, 21)
        Me.cboEmail.TabIndex = 1
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(50, 85)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Size = New System.Drawing.Size(100, 20)
        Me.txtDOB.TabIndex = 3
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(50, 61)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(189, 20)
        Me.txtMobile.TabIndex = 2
        '
        'lbkUpdateSecoID
        '
        Me.lbkUpdateSecoID.AutoSize = True
        Me.lbkUpdateSecoID.Location = New System.Drawing.Point(218, 251)
        Me.lbkUpdateSecoID.Name = "lbkUpdateSecoID"
        Me.lbkUpdateSecoID.Size = New System.Drawing.Size(78, 13)
        Me.lbkUpdateSecoID.TabIndex = 7
        Me.lbkUpdateSecoID.TabStop = True
        Me.lbkUpdateSecoID.Text = "UpdateSecoID"
        '
        'txtSecoId
        '
        Me.txtSecoId.Location = New System.Drawing.Point(293, 244)
        Me.txtSecoId.Name = "txtSecoId"
        Me.txtSecoId.Size = New System.Drawing.Size(187, 20)
        Me.txtSecoId.TabIndex = 8
        '
        'chkAdmin
        '
        Me.chkAdmin.AutoSize = True
        Me.chkAdmin.Location = New System.Drawing.Point(239, 88)
        Me.chkAdmin.Name = "chkAdmin"
        Me.chkAdmin.Size = New System.Drawing.Size(77, 17)
        Me.chkAdmin.TabIndex = 9
        Me.chkAdmin.Text = "AdminUser"
        Me.chkAdmin.UseVisualStyleBackColor = True
        '
        'lbkCopy
        '
        Me.lbkCopy.AutoSize = True
        Me.lbkCopy.Location = New System.Drawing.Point(419, 35)
        Me.lbkCopy.Name = "lbkCopy"
        Me.lbkCopy.Size = New System.Drawing.Size(31, 13)
        Me.lbkCopy.TabIndex = 10
        Me.lbkCopy.TabStop = True
        Me.lbkCopy.Text = "Copy"
        '
        'frmSecoInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.lbkCopy)
        Me.Controls.Add(Me.chkAdmin)
        Me.Controls.Add(Me.txtSecoId)
        Me.Controls.Add(Me.lbkUpdateSecoID)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.txtDOB)
        Me.Controls.Add(Me.cboEmail)
        Me.Controls.Add(Me.cboProduct)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkSave)
        Me.Controls.Add(Me.dgSignIn1A)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSecoInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SECO Info"
        CType(Me.dgSignIn1A, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgSignIn1A As System.Windows.Forms.DataGridView
    Friend WithEvents lbkSave As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
    Friend WithEvents cboEmail As System.Windows.Forms.ComboBox
    Friend WithEvents txtDOB As System.Windows.Forms.TextBox
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents lbkUpdateSecoID As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSecoId As System.Windows.Forms.TextBox
    Friend WithEvents chkAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents lbkCopy As System.Windows.Forms.LinkLabel
End Class
