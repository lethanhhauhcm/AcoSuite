<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllstatUpload
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
        Me.cmdManualUpload = New System.Windows.Forms.Button()
        Me.dgrBookDate = New System.Windows.Forms.DataGridView()
        CType(Me.dgrBookDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdManualUpload
        '
        Me.cmdManualUpload.Location = New System.Drawing.Point(137, 229)
        Me.cmdManualUpload.Name = "cmdManualUpload"
        Me.cmdManualUpload.Size = New System.Drawing.Size(220, 32)
        Me.cmdManualUpload.TabIndex = 0
        Me.cmdManualUpload.Text = "Manual Upload"
        Me.cmdManualUpload.UseVisualStyleBackColor = True
        '
        'dgrBookDate
        '
        Me.dgrBookDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrBookDate.Location = New System.Drawing.Point(12, 12)
        Me.dgrBookDate.Name = "dgrBookDate"
        Me.dgrBookDate.Size = New System.Drawing.Size(468, 205)
        Me.dgrBookDate.TabIndex = 1
        '
        'AllstatUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.dgrBookDate)
        Me.Controls.Add(Me.cmdManualUpload)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AllstatUpload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Reward :. Allstat Upload"
        CType(Me.dgrBookDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdManualUpload As System.Windows.Forms.Button
    Friend WithEvents dgrBookDate As System.Windows.Forms.DataGridView
End Class
