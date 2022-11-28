<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncentiveCalc
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
        Me.LblCalculate = New System.Windows.Forms.LinkLabel
        Me.GridIncentive = New System.Windows.Forms.DataGridView
        Me.txtFrm = New System.Windows.Forms.DateTimePicker
        Me.TxtThru = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.GridIncentive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblCalculate
        '
        Me.LblCalculate.AutoSize = True
        Me.LblCalculate.Location = New System.Drawing.Point(252, 3)
        Me.LblCalculate.Name = "LblCalculate"
        Me.LblCalculate.Size = New System.Drawing.Size(51, 13)
        Me.LblCalculate.TabIndex = 4
        Me.LblCalculate.TabStop = True
        Me.LblCalculate.Text = "Calculate"
        '
        'GridIncentive
        '
        Me.GridIncentive.AllowUserToAddRows = False
        Me.GridIncentive.AllowUserToDeleteRows = False
        Me.GridIncentive.BackgroundColor = System.Drawing.Color.MintCream
        Me.GridIncentive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridIncentive.Location = New System.Drawing.Point(3, 24)
        Me.GridIncentive.Name = "GridIncentive"
        Me.GridIncentive.RowHeadersVisible = False
        Me.GridIncentive.Size = New System.Drawing.Size(713, 453)
        Me.GridIncentive.TabIndex = 5
        '
        'txtFrm
        '
        Me.txtFrm.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFrm.Location = New System.Drawing.Point(39, 2)
        Me.txtFrm.Name = "txtFrm"
        Me.txtFrm.Size = New System.Drawing.Size(86, 20)
        Me.txtFrm.TabIndex = 7
        '
        'TxtThru
        '
        Me.TxtThru.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtThru.Location = New System.Drawing.Point(162, 2)
        Me.TxtThru.Name = "TxtThru"
        Me.TxtThru.Size = New System.Drawing.Size(84, 20)
        Me.TxtThru.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(131, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Thru"
        '
        'IncentiveCalc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 478)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtThru)
        Me.Controls.Add(Me.txtFrm)
        Me.Controls.Add(Me.GridIncentive)
        Me.Controls.Add(Me.LblCalculate)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IncentiveCalc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACO Vietnam :: AllStats Report :. Incentive Calculation"
        CType(Me.GridIncentive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblCalculate As System.Windows.Forms.LinkLabel
    Friend WithEvents GridIncentive As System.Windows.Forms.DataGridView
    Friend WithEvents txtFrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtThru As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
