<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentiveCalc
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
        Me.cboQuarter = New System.Windows.Forms.ComboBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbkSumBkgTkt = New System.Windows.Forms.LinkLabel()
        Me.lbkCalcIncentives = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'cboQuarter
        '
        Me.cboQuarter.FormattingEnabled = True
        Me.cboQuarter.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboQuarter.Location = New System.Drawing.Point(70, 31)
        Me.cboQuarter.Name = "cboQuarter"
        Me.cboQuarter.Size = New System.Drawing.Size(51, 21)
        Me.cboQuarter.TabIndex = 0
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"2016", "2017"})
        Me.cboYear.Location = New System.Drawing.Point(127, 31)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(121, 21)
        Me.cboYear.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(67, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Quarter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(124, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Year"
        '
        'lbkSumBkgTkt
        '
        Me.lbkSumBkgTkt.AutoSize = True
        Me.lbkSumBkgTkt.Location = New System.Drawing.Point(67, 74)
        Me.lbkSumBkgTkt.Name = "lbkSumBkgTkt"
        Me.lbkSumBkgTkt.Size = New System.Drawing.Size(63, 13)
        Me.lbkSumBkgTkt.TabIndex = 6
        Me.lbkSumBkgTkt.TabStop = True
        Me.lbkSumBkgTkt.Text = "SumBkgTkt"
        '
        'lbkCalcIncentives
        '
        Me.lbkCalcIncentives.AutoSize = True
        Me.lbkCalcIncentives.Location = New System.Drawing.Point(164, 74)
        Me.lbkCalcIncentives.Name = "lbkCalcIncentives"
        Me.lbkCalcIncentives.Size = New System.Drawing.Size(72, 13)
        Me.lbkCalcIncentives.TabIndex = 7
        Me.lbkCalcIncentives.TabStop = True
        Me.lbkCalcIncentives.Text = "CalcIncentive"
        '
        'frmIncentiveCalc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.lbkCalcIncentives)
        Me.Controls.Add(Me.lbkSumBkgTkt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.cboQuarter)
        Me.Name = "frmIncentiveCalc"
        Me.Text = "IncentiveCalc"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboQuarter As System.Windows.Forms.ComboBox
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbkSumBkgTkt As LinkLabel
    Friend WithEvents lbkCalcIncentives As LinkLabel
End Class
