<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignIn1A
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
        Me.cboContactId = New System.Windows.Forms.ComboBox()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.lbkEdit = New System.Windows.Forms.LinkLabel()
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.cboOffcId = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtSignIn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboContactId
        '
        Me.cboContactId.FormattingEnabled = True
        Me.cboContactId.Location = New System.Drawing.Point(355, 10)
        Me.cboContactId.Name = "cboContactId"
        Me.cboContactId.Size = New System.Drawing.Size(121, 21)
        Me.cboContactId.TabIndex = 118
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(438, 34)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 117
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'lbkEdit
        '
        Me.lbkEdit.AutoSize = True
        Me.lbkEdit.Location = New System.Drawing.Point(400, 34)
        Me.lbkEdit.Name = "lbkEdit"
        Me.lbkEdit.Size = New System.Drawing.Size(25, 13)
        Me.lbkEdit.TabIndex = 116
        Me.lbkEdit.TabStop = True
        Me.lbkEdit.Text = "Edit"
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(356, 34)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 115
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'cboOffcId
        '
        Me.cboOffcId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOffcId.Enabled = False
        Me.cboOffcId.FormattingEnabled = True
        Me.cboOffcId.Location = New System.Drawing.Point(16, 26)
        Me.cboOffcId.Name = "cboOffcId"
        Me.cboOffcId.Size = New System.Drawing.Size(111, 21)
        Me.cboOffcId.TabIndex = 113
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 63)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(460, 400)
        Me.DataGridView1.TabIndex = 112
        '
        'txtSignIn
        '
        Me.txtSignIn.Enabled = False
        Me.txtSignIn.Location = New System.Drawing.Point(133, 26)
        Me.txtSignIn.MaxLength = 6
        Me.txtSignIn.Name = "txtSignIn"
        Me.txtSignIn.Size = New System.Drawing.Size(100, 20)
        Me.txtSignIn.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(296, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "ContactId"
        '
        'frmSignIn1A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 473)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboContactId)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkEdit)
        Me.Controls.Add(Me.lbkAdd)
        Me.Controls.Add(Me.txtSignIn)
        Me.Controls.Add(Me.cboOffcId)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmSignIn1A"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SignIn1A"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboContactId As System.Windows.Forms.ComboBox
    Friend WithEvents lbkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkEdit As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents cboOffcId As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtSignIn As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
