<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateUser
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnResetPass = New System.Windows.Forms.Button()
        Me.txtSI = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.chkAdmin = New System.Windows.Forms.CheckBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.bdsView = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkClickToAddNew = New System.Windows.Forms.CheckBox()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bdsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(290, 78)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 0
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnResetPass
        '
        Me.btnResetPass.Enabled = False
        Me.btnResetPass.Location = New System.Drawing.Point(371, 78)
        Me.btnResetPass.Name = "btnResetPass"
        Me.btnResetPass.Size = New System.Drawing.Size(75, 23)
        Me.btnResetPass.TabIndex = 0
        Me.btnResetPass.Text = "Reset Pass"
        Me.btnResetPass.UseVisualStyleBackColor = True
        '
        'txtSI
        '
        Me.txtSI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSI.Location = New System.Drawing.Point(332, 26)
        Me.txtSI.MaxLength = 3
        Me.txtSI.Name = "txtSI"
        Me.txtSI.Size = New System.Drawing.Size(135, 20)
        Me.txtSI.TabIndex = 1
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(332, 52)
        Me.txtFullName.MaxLength = 30
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(196, 20)
        Me.txtFullName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(287, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SI"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(287, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "FName"
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(4, 4)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        Me.dgvView.RowHeadersVisible = False
        Me.dgvView.Size = New System.Drawing.Size(277, 469)
        Me.dgvView.TabIndex = 3
        '
        'chkAdmin
        '
        Me.chkAdmin.AutoSize = True
        Me.chkAdmin.Location = New System.Drawing.Point(473, 28)
        Me.chkAdmin.Name = "chkAdmin"
        Me.chkAdmin.Size = New System.Drawing.Size(55, 17)
        Me.chkAdmin.TabIndex = 4
        Me.chkAdmin.Text = "Admin"
        Me.chkAdmin.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(206, 479)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete User"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(453, 78)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'bdsView
        '
        '
        'chkClickToAddNew
        '
        Me.chkClickToAddNew.AutoSize = True
        Me.chkClickToAddNew.Location = New System.Drawing.Point(290, 4)
        Me.chkClickToAddNew.Name = "chkClickToAddNew"
        Me.chkClickToAddNew.Size = New System.Drawing.Size(108, 17)
        Me.chkClickToAddNew.TabIndex = 7
        Me.chkClickToAddNew.Text = "Click to Add New"
        Me.chkClickToAddNew.UseVisualStyleBackColor = True
        '
        'CreateUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 503)
        Me.Controls.Add(Me.chkClickToAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.chkAdmin)
        Me.Controls.Add(Me.dgvView)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.txtSI)
        Me.Controls.Add(Me.btnResetPass)
        Me.Controls.Add(Me.btnCreate)
        Me.Location = New System.Drawing.Point(0, 50)
        Me.Name = "CreateUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CreateUser"
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bdsView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnResetPass As System.Windows.Forms.Button
    Friend WithEvents txtSI As System.Windows.Forms.TextBox
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents chkAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents bdsView As System.Windows.Forms.BindingSource
    Friend WithEvents chkClickToAddNew As System.Windows.Forms.CheckBox
End Class
