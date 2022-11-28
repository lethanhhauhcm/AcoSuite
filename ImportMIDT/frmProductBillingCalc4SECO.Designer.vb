<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductBillingCalc4SECO
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cboBookYear = New System.Windows.Forms.ComboBox()
        Me.cboBookMonth = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "BookYear"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "BookMonth"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(94, 105)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cboBookYear
        '
        Me.cboBookYear.FormattingEnabled = True
        Me.cboBookYear.Items.AddRange(New Object() {"2016", "2017", "2108"})
        Me.cboBookYear.Location = New System.Drawing.Point(115, 37)
        Me.cboBookYear.Name = "cboBookYear"
        Me.cboBookYear.Size = New System.Drawing.Size(121, 21)
        Me.cboBookYear.TabIndex = 6
        '
        'cboBookMonth
        '
        Me.cboBookMonth.FormattingEnabled = True
        Me.cboBookMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboBookMonth.Location = New System.Drawing.Point(43, 37)
        Me.cboBookMonth.Name = "cboBookMonth"
        Me.cboBookMonth.Size = New System.Drawing.Size(51, 21)
        Me.cboBookMonth.TabIndex = 5
        '
        'frmProductBillingCalc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cboBookYear)
        Me.Controls.Add(Me.cboBookMonth)
        Me.Name = "frmProductBillingCalc"
        Me.Text = "ProductBillingCalc"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cboBookYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboBookMonth As System.Windows.Forms.ComboBox
End Class
