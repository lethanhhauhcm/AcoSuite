<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderHandler
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
        Me.GridRPT = New System.Windows.Forms.DataGridView()
        Me.LblReject = New System.Windows.Forms.LinkLabel()
        Me.LblAccept = New System.Windows.Forms.LinkLabel()
        Me.TxtNote = New System.Windows.Forms.TextBox()
        CType(Me.GridRPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridRPT
        '
        Me.GridRPT.AllowUserToAddRows = False
        Me.GridRPT.AllowUserToDeleteRows = False
        Me.GridRPT.BackgroundColor = System.Drawing.Color.DodgerBlue
        Me.GridRPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridRPT.Location = New System.Drawing.Point(1, 1)
        Me.GridRPT.Name = "GridRPT"
        Me.GridRPT.RowHeadersVisible = False
        Me.GridRPT.Size = New System.Drawing.Size(800, 468)
        Me.GridRPT.TabIndex = 1
        '
        'LblReject
        '
        Me.LblReject.AutoSize = True
        Me.LblReject.Location = New System.Drawing.Point(-2, 474)
        Me.LblReject.Name = "LblReject"
        Me.LblReject.Size = New System.Drawing.Size(38, 13)
        Me.LblReject.TabIndex = 2
        Me.LblReject.TabStop = True
        Me.LblReject.Text = "Reject"
        '
        'LblAccept
        '
        Me.LblAccept.AutoSize = True
        Me.LblAccept.Location = New System.Drawing.Point(814, 9)
        Me.LblAccept.Name = "LblAccept"
        Me.LblAccept.Size = New System.Drawing.Size(41, 13)
        Me.LblAccept.TabIndex = 2
        Me.LblAccept.TabStop = True
        Me.LblAccept.Text = "Accept"
        '
        'TxtNote
        '
        Me.TxtNote.Location = New System.Drawing.Point(42, 471)
        Me.TxtNote.Name = "TxtNote"
        Me.TxtNote.Size = New System.Drawing.Size(759, 20)
        Me.TxtNote.TabIndex = 3
        '
        'frmOrderHandler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 496)
        Me.Controls.Add(Me.TxtNote)
        Me.Controls.Add(Me.LblAccept)
        Me.Controls.Add(Me.LblReject)
        Me.Controls.Add(Me.GridRPT)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrderHandler"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :. Reward :. Order Handler"
        CType(Me.GridRPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridRPT As System.Windows.Forms.DataGridView
    Friend WithEvents LblReject As System.Windows.Forms.LinkLabel
    Friend WithEvents LblAccept As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtNote As System.Windows.Forms.TextBox
End Class
