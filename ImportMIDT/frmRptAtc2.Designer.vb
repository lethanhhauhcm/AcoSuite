<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptAtc2
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
        Me.lblFromMonth = New System.Windows.Forms.Label()
        Me.dtpFromMonth = New System.Windows.Forms.DateTimePicker()
        Me.dtpToMonth = New System.Windows.Forms.DateTimePicker()
        Me.lblToMonth = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblFromMonth
        '
        Me.lblFromMonth.AutoSize = True
        Me.lblFromMonth.Location = New System.Drawing.Point(18, 16)
        Me.lblFromMonth.Name = "lblFromMonth"
        Me.lblFromMonth.Size = New System.Drawing.Size(60, 13)
        Me.lblFromMonth.TabIndex = 0
        Me.lblFromMonth.Text = "FromMonth"
        '
        'dtpFromMonth
        '
        Me.dtpFromMonth.CustomFormat = "MMM-yy"
        Me.dtpFromMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromMonth.Location = New System.Drawing.Point(84, 12)
        Me.dtpFromMonth.Name = "dtpFromMonth"
        Me.dtpFromMonth.ShowUpDown = True
        Me.dtpFromMonth.Size = New System.Drawing.Size(70, 20)
        Me.dtpFromMonth.TabIndex = 1
        '
        'dtpToMonth
        '
        Me.dtpToMonth.CustomFormat = "MMM-yy"
        Me.dtpToMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToMonth.Location = New System.Drawing.Point(84, 38)
        Me.dtpToMonth.Name = "dtpToMonth"
        Me.dtpToMonth.ShowUpDown = True
        Me.dtpToMonth.Size = New System.Drawing.Size(70, 20)
        Me.dtpToMonth.TabIndex = 3
        '
        'lblToMonth
        '
        Me.lblToMonth.AutoSize = True
        Me.lblToMonth.Location = New System.Drawing.Point(28, 42)
        Me.lblToMonth.Name = "lblToMonth"
        Me.lblToMonth.Size = New System.Drawing.Size(50, 13)
        Me.lblToMonth.TabIndex = 2
        Me.lblToMonth.Text = "ToMonth"
        '
        'frmRptAtc2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dtpToMonth)
        Me.Controls.Add(Me.lblToMonth)
        Me.Controls.Add(Me.dtpFromMonth)
        Me.Controls.Add(Me.lblFromMonth)
        Me.Name = "frmRptAtc2"
        Me.Text = "BillingAtc2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFromMonth As Label
    Friend WithEvents dtpFromMonth As DateTimePicker
    Friend WithEvents dtpToMonth As DateTimePicker
    Friend WithEvents lblToMonth As Label
End Class
