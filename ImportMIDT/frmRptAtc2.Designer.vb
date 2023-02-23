<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRptAtc2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblFromMonth = New System.Windows.Forms.Label()
        Me.dtpFromMonth = New System.Windows.Forms.DateTimePicker()
        Me.dtpToMonth = New System.Windows.Forms.DateTimePicker()
        Me.lblToMonth = New System.Windows.Forms.Label()
        Me.btnRunRPT = New System.Windows.Forms.Button()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.pb01 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'lblFromMonth
        '
        Me.lblFromMonth.AutoSize = True
        Me.lblFromMonth.Location = New System.Drawing.Point(12, 16)
        Me.lblFromMonth.Name = "lblFromMonth"
        Me.lblFromMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblFromMonth.TabIndex = 0
        Me.lblFromMonth.Text = "Month"
        '
        'dtpFromMonth
        '
        Me.dtpFromMonth.CustomFormat = "MMM-yy"
        Me.dtpFromMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromMonth.Location = New System.Drawing.Point(59, 12)
        Me.dtpFromMonth.Name = "dtpFromMonth"
        Me.dtpFromMonth.ShowUpDown = True
        Me.dtpFromMonth.Size = New System.Drawing.Size(80, 20)
        Me.dtpFromMonth.TabIndex = 1
        '
        'dtpToMonth
        '
        Me.dtpToMonth.CustomFormat = "MMM-yy"
        Me.dtpToMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToMonth.Location = New System.Drawing.Point(171, 12)
        Me.dtpToMonth.Name = "dtpToMonth"
        Me.dtpToMonth.ShowUpDown = True
        Me.dtpToMonth.Size = New System.Drawing.Size(80, 20)
        Me.dtpToMonth.TabIndex = 3
        '
        'lblToMonth
        '
        Me.lblToMonth.AutoSize = True
        Me.lblToMonth.Location = New System.Drawing.Point(145, 16)
        Me.lblToMonth.Name = "lblToMonth"
        Me.lblToMonth.Size = New System.Drawing.Size(20, 13)
        Me.lblToMonth.TabIndex = 2
        Me.lblToMonth.Text = "To"
        '
        'btnRunRPT
        '
        Me.btnRunRPT.AutoSize = True
        Me.btnRunRPT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRunRPT.Location = New System.Drawing.Point(12, 65)
        Me.btnRunRPT.Name = "btnRunRPT"
        Me.btnRunRPT.Size = New System.Drawing.Size(59, 23)
        Me.btnRunRPT.TabIndex = 5
        Me.btnRunRPT.Text = "RunRPT"
        Me.btnRunRPT.UseVisualStyleBackColor = True
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(12, 41)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(41, 13)
        Me.lblRegion.TabIndex = 5
        Me.lblRegion.Text = "Region"
        '
        'cboRegion
        '
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Items.AddRange(New Object() {"", "North", "South"})
        Me.cboRegion.Location = New System.Drawing.Point(59, 38)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(50, 21)
        Me.cboRegion.TabIndex = 4
        '
        'pb01
        '
        Me.pb01.Location = New System.Drawing.Point(77, 65)
        Me.pb01.Name = "pb01"
        Me.pb01.Size = New System.Drawing.Size(174, 23)
        Me.pb01.TabIndex = 6
        '
        'frmRptAtc2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 97)
        Me.Controls.Add(Me.pb01)
        Me.Controls.Add(Me.cboRegion)
        Me.Controls.Add(Me.lblRegion)
        Me.Controls.Add(Me.btnRunRPT)
        Me.Controls.Add(Me.dtpToMonth)
        Me.Controls.Add(Me.lblToMonth)
        Me.Controls.Add(Me.dtpFromMonth)
        Me.Controls.Add(Me.lblFromMonth)
        Me.Name = "frmRptAtc2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BillingAtc2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFromMonth As Label
    Friend WithEvents dtpFromMonth As DateTimePicker
    Friend WithEvents dtpToMonth As DateTimePicker
    Friend WithEvents lblToMonth As Label
    Friend WithEvents btnRunRPT As Button
    Friend WithEvents lblRegion As Label
    Friend WithEvents cboRegion As ComboBox
    Friend WithEvents pb01 As ProgressBar
End Class
