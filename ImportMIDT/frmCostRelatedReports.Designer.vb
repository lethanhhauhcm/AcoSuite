<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostRelatedReports
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
        Me.cboReportType = New System.Windows.Forms.ComboBox()
        Me.lbkRun = New System.Windows.Forms.LinkLabel()
        Me.lbkExit = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboReportType
        '
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Items.AddRange(New Object() {"ATC", "IMR", "MasterPricer", "MasterPricerExpert", "MasterPricerFareFamily", "WebServicesTransaction"})
        Me.cboReportType.Location = New System.Drawing.Point(114, 12)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(158, 21)
        Me.cboReportType.TabIndex = 0
        '
        'lbkRun
        '
        Me.lbkRun.AutoSize = True
        Me.lbkRun.Location = New System.Drawing.Point(12, 78)
        Me.lbkRun.Name = "lbkRun"
        Me.lbkRun.Size = New System.Drawing.Size(27, 13)
        Me.lbkRun.TabIndex = 1
        Me.lbkRun.TabStop = True
        Me.lbkRun.Text = "Run"
        '
        'lbkExit
        '
        Me.lbkExit.AutoSize = True
        Me.lbkExit.Location = New System.Drawing.Point(45, 78)
        Me.lbkExit.Name = "lbkExit"
        Me.lbkExit.Size = New System.Drawing.Size(24, 13)
        Me.lbkExit.TabIndex = 2
        Me.lbkExit.TabStop = True
        Me.lbkExit.Text = "Exit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From/To"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd MMM yy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(114, 48)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(74, 20)
        Me.dtpFromDate.TabIndex = 4
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd MMM yy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(194, 48)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(78, 20)
        Me.dtpToDate.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ReportType"
        '
        'frmCostRelatedReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 100)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbkExit)
        Me.Controls.Add(Me.lbkRun)
        Me.Controls.Add(Me.cboReportType)
        Me.Name = "frmCostRelatedReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CostRelatedReports"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboReportType As ComboBox
    Friend WithEvents lbkRun As LinkLabel
    Friend WithEvents lbkExit As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents Label2 As Label
End Class
