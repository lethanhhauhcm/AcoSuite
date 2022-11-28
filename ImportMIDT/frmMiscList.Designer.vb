<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMiscList
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
        Me.dgrMisc = New System.Windows.Forms.DataGridView()
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.txtNewValue = New System.Windows.Forms.TextBox()
        CType(Me.dgrMisc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgrMisc
        '
        Me.dgrMisc.AllowUserToAddRows = False
        Me.dgrMisc.AllowUserToDeleteRows = False
        Me.dgrMisc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrMisc.Location = New System.Drawing.Point(0, 0)
        Me.dgrMisc.Name = "dgrMisc"
        Me.dgrMisc.ReadOnly = True
        Me.dgrMisc.Size = New System.Drawing.Size(490, 428)
        Me.dgrMisc.TabIndex = 0
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(12, 447)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 1
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(442, 447)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 2
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'txtNewValue
        '
        Me.txtNewValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewValue.Location = New System.Drawing.Point(44, 444)
        Me.txtNewValue.Name = "txtNewValue"
        Me.txtNewValue.Size = New System.Drawing.Size(208, 20)
        Me.txtNewValue.TabIndex = 3
        '
        'frmMiscList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 473)
        Me.Controls.Add(Me.txtNewValue)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkAdd)
        Me.Controls.Add(Me.dgrMisc)
        Me.Name = "frmMiscList"
        Me.Text = "MiscList"
        CType(Me.dgrMisc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgrMisc As System.Windows.Forms.DataGridView
    Friend WithEvents lbkAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents txtNewValue As TextBox
End Class
