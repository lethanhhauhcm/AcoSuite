<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSTMn
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
        Me.GridCSTM = New System.Windows.Forms.DataGridView
        Me.LblAssign = New System.Windows.Forms.LinkLabel
        Me.OptXX = New System.Windows.Forms.RadioButton
        Me.OptQQ = New System.Windows.Forms.RadioButton
        Me.OptOK = New System.Windows.Forms.RadioButton
        Me.LblApprove = New System.Windows.Forms.LinkLabel
        Me.LstAgt = New System.Windows.Forms.CheckedListBox
        CType(Me.GridCSTM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridCSTM
        '
        Me.GridCSTM.AllowUserToAddRows = False
        Me.GridCSTM.AllowUserToDeleteRows = False
        Me.GridCSTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCSTM.Location = New System.Drawing.Point(1, 1)
        Me.GridCSTM.Name = "GridCSTM"
        Me.GridCSTM.RowHeadersVisible = False
        Me.GridCSTM.Size = New System.Drawing.Size(453, 474)
        Me.GridCSTM.TabIndex = 6
        '
        'LblAssign
        '
        Me.LblAssign.AutoSize = True
        Me.LblAssign.Enabled = False
        Me.LblAssign.Location = New System.Drawing.Point(670, 456)
        Me.LblAssign.Name = "LblAssign"
        Me.LblAssign.Size = New System.Drawing.Size(38, 13)
        Me.LblAssign.TabIndex = 8
        Me.LblAssign.TabStop = True
        Me.LblAssign.Text = "Assign"
        '
        'OptXX
        '
        Me.OptXX.AutoSize = True
        Me.OptXX.Enabled = False
        Me.OptXX.Location = New System.Drawing.Point(462, 454)
        Me.OptXX.Name = "OptXX"
        Me.OptXX.Size = New System.Drawing.Size(39, 17)
        Me.OptXX.TabIndex = 9
        Me.OptXX.TabStop = True
        Me.OptXX.Text = "XX"
        Me.OptXX.UseVisualStyleBackColor = True
        '
        'OptQQ
        '
        Me.OptQQ.AutoSize = True
        Me.OptQQ.Checked = True
        Me.OptQQ.Enabled = False
        Me.OptQQ.Location = New System.Drawing.Point(507, 454)
        Me.OptQQ.Name = "OptQQ"
        Me.OptQQ.Size = New System.Drawing.Size(41, 17)
        Me.OptQQ.TabIndex = 9
        Me.OptQQ.TabStop = True
        Me.OptQQ.Text = "QQ"
        Me.OptQQ.UseVisualStyleBackColor = True
        '
        'OptOK
        '
        Me.OptOK.AutoSize = True
        Me.OptOK.Enabled = False
        Me.OptOK.Location = New System.Drawing.Point(554, 454)
        Me.OptOK.Name = "OptOK"
        Me.OptOK.Size = New System.Drawing.Size(40, 17)
        Me.OptOK.TabIndex = 9
        Me.OptOK.TabStop = True
        Me.OptOK.Text = "OK"
        Me.OptOK.UseVisualStyleBackColor = True
        '
        'LblApprove
        '
        Me.LblApprove.AutoSize = True
        Me.LblApprove.Enabled = False
        Me.LblApprove.Location = New System.Drawing.Point(600, 456)
        Me.LblApprove.Name = "LblApprove"
        Me.LblApprove.Size = New System.Drawing.Size(47, 13)
        Me.LblApprove.TabIndex = 8
        Me.LblApprove.TabStop = True
        Me.LblApprove.Text = "Approve"
        '
        'LstAgt
        '
        Me.LstAgt.CheckOnClick = True
        Me.LstAgt.FormattingEnabled = True
        Me.LstAgt.Location = New System.Drawing.Point(460, 1)
        Me.LstAgt.Name = "LstAgt"
        Me.LstAgt.Size = New System.Drawing.Size(257, 439)
        Me.LstAgt.TabIndex = 7
        '
        'CSTMn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 478)
        Me.Controls.Add(Me.LstAgt)
        Me.Controls.Add(Me.LblAssign)
        Me.Controls.Add(Me.OptOK)
        Me.Controls.Add(Me.OptQQ)
        Me.Controls.Add(Me.OptXX)
        Me.Controls.Add(Me.LblApprove)
        Me.Controls.Add(Me.GridCSTM)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CSTMn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Commercial Offer :. Offer Updater"
        CType(Me.GridCSTM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridCSTM As System.Windows.Forms.DataGridView
    Friend WithEvents LblAssign As System.Windows.Forms.LinkLabel
    Friend WithEvents OptXX As System.Windows.Forms.RadioButton
    Friend WithEvents OptQQ As System.Windows.Forms.RadioButton
    Friend WithEvents OptOK As System.Windows.Forms.RadioButton
    Friend WithEvents LblApprove As System.Windows.Forms.LinkLabel
    Friend WithEvents LstAgt As System.Windows.Forms.CheckedListBox
End Class
