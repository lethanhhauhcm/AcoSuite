<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBypassSecoCheck
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
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.dgrBypassSecoCheck = New System.Windows.Forms.DataGridView()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        CType(Me.dgrBypassSecoCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(386, 239)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 0
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(454, 239)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 1
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'dgrBypassSecoCheck
        '
        Me.dgrBypassSecoCheck.AllowUserToAddRows = False
        Me.dgrBypassSecoCheck.AllowUserToDeleteRows = False
        Me.dgrBypassSecoCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrBypassSecoCheck.Location = New System.Drawing.Point(0, 0)
        Me.dgrBypassSecoCheck.Name = "dgrBypassSecoCheck"
        Me.dgrBypassSecoCheck.ReadOnly = True
        Me.dgrBypassSecoCheck.Size = New System.Drawing.Size(543, 236)
        Me.dgrBypassSecoCheck.TabIndex = 2
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(0, 239)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(147, 20)
        Me.txtUserId.TabIndex = 3
        '
        'frmBypassSecoCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 261)
        Me.Controls.Add(Me.txtUserId)
        Me.Controls.Add(Me.dgrBypassSecoCheck)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkAdd)
        Me.Name = "frmBypassSecoCheck"
        Me.Text = "BypassSecoCheck"
        CType(Me.dgrBypassSecoCheck, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbkAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents dgrBypassSecoCheck As System.Windows.Forms.DataGridView
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
End Class
