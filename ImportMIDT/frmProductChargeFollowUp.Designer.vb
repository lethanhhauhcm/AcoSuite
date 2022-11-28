<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductChargeFollowUp
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
        Me.dgrProductCharges = New System.Windows.Forms.DataGridView()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.lbkReset = New System.Windows.Forms.LinkLabel()
        Me.cboProductName = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboBookYear = New System.Windows.Forms.ComboBox()
        Me.cboBookMonth = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbkSetPaidDate = New System.Windows.Forms.LinkLabel()
        Me.lbkAutoSetAsPaid = New System.Windows.Forms.LinkLabel()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.lblLastBalance = New System.Windows.Forms.Label()
        CType(Me.dgrProductCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgrProductCharges
        '
        Me.dgrProductCharges.AllowUserToAddRows = False
        Me.dgrProductCharges.AllowUserToDeleteRows = False
        Me.dgrProductCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrProductCharges.Location = New System.Drawing.Point(3, 50)
        Me.dgrProductCharges.Name = "dgrProductCharges"
        Me.dgrProductCharges.ReadOnly = True
        Me.dgrProductCharges.Size = New System.Drawing.Size(675, 527)
        Me.dgrProductCharges.TabIndex = 0
        '
        'cboShortName
        '
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(154, 27)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(168, 21)
        Me.cboShortName.TabIndex = 1
        '
        'lbkReset
        '
        Me.lbkReset.AutoSize = True
        Me.lbkReset.Location = New System.Drawing.Point(648, 35)
        Me.lbkReset.Name = "lbkReset"
        Me.lbkReset.Size = New System.Drawing.Size(35, 13)
        Me.lbkReset.TabIndex = 2
        Me.lbkReset.TabStop = True
        Me.lbkReset.Text = "Reset"
        '
        'cboProductName
        '
        Me.cboProductName.FormattingEnabled = True
        Me.cboProductName.Location = New System.Drawing.Point(328, 27)
        Me.cboProductName.Name = "cboProductName"
        Me.cboProductName.Size = New System.Drawing.Size(158, 21)
        Me.cboProductName.TabIndex = 4
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OK", "RR"})
        Me.cboStatus.Location = New System.Drawing.Point(492, 27)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(46, 21)
        Me.cboStatus.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(151, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Product"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(489, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Status"
        '
        'cboBookYear
        '
        Me.cboBookYear.FormattingEnabled = True
        Me.cboBookYear.Items.AddRange(New Object() {"2017", "2018"})
        Me.cboBookYear.Location = New System.Drawing.Point(544, 27)
        Me.cboBookYear.Name = "cboBookYear"
        Me.cboBookYear.Size = New System.Drawing.Size(46, 21)
        Me.cboBookYear.TabIndex = 9
        '
        'cboBookMonth
        '
        Me.cboBookMonth.FormattingEnabled = True
        Me.cboBookMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboBookMonth.Location = New System.Drawing.Point(596, 27)
        Me.cboBookMonth.Name = "cboBookMonth"
        Me.cboBookMonth.Size = New System.Drawing.Size(46, 21)
        Me.cboBookMonth.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(541, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "BookYear"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(593, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "BookMonth"
        '
        'lbkSetPaidDate
        '
        Me.lbkSetPaidDate.AutoSize = True
        Me.lbkSetPaidDate.Location = New System.Drawing.Point(12, 30)
        Me.lbkSetPaidDate.Name = "lbkSetPaidDate"
        Me.lbkSetPaidDate.Size = New System.Drawing.Size(56, 13)
        Me.lbkSetPaidDate.TabIndex = 14
        Me.lbkSetPaidDate.TabStop = True
        Me.lbkSetPaidDate.Text = "SetAsPaid"
        '
        'lbkAutoSetAsPaid
        '
        Me.lbkAutoSetAsPaid.AutoSize = True
        Me.lbkAutoSetAsPaid.Location = New System.Drawing.Point(12, 589)
        Me.lbkAutoSetAsPaid.Name = "lbkAutoSetAsPaid"
        Me.lbkAutoSetAsPaid.Size = New System.Drawing.Size(78, 13)
        Me.lbkAutoSetAsPaid.TabIndex = 15
        Me.lbkAutoSetAsPaid.TabStop = True
        Me.lbkAutoSetAsPaid.Text = "AutoSetAsPaid"
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 9)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(47, 13)
        Me.lblRecordCount.TabIndex = 16
        Me.lblRecordCount.Text = "Records"
        '
        'lblLastBalance
        '
        Me.lblLastBalance.AutoSize = True
        Me.lblLastBalance.Location = New System.Drawing.Point(487, 589)
        Me.lblLastBalance.Name = "lblLastBalance"
        Me.lblLastBalance.Size = New System.Drawing.Size(69, 13)
        Me.lblLastBalance.TabIndex = 17
        Me.lblLastBalance.Text = "LastBalance:"
        '
        'frmProductChargeFollowUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 611)
        Me.Controls.Add(Me.lblLastBalance)
        Me.Controls.Add(Me.lblRecordCount)
        Me.Controls.Add(Me.lbkAutoSetAsPaid)
        Me.Controls.Add(Me.lbkSetPaidDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboBookMonth)
        Me.Controls.Add(Me.cboBookYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.cboProductName)
        Me.Controls.Add(Me.lbkReset)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.dgrProductCharges)
        Me.Name = "frmProductChargeFollowUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProductChargeFollowUp"
        CType(Me.dgrProductCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgrProductCharges As DataGridView
    Friend WithEvents cboShortName As ComboBox
    Friend WithEvents lbkReset As LinkLabel
    Friend WithEvents cboProductName As ComboBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboBookYear As ComboBox
    Friend WithEvents cboBookMonth As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbkSetPaidDate As LinkLabel
    Friend WithEvents lbkAutoSetAsPaid As LinkLabel
    Friend WithEvents lblRecordCount As Label
    Friend WithEvents lblLastBalance As Label
End Class
