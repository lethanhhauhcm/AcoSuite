<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectProduct
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
        Me.cboProductName = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboProductName
        '
        Me.cboProductName.FormattingEnabled = True
        Me.cboProductName.Items.AddRange(New Object() {"ATC", "MPE", "SECO 1", "SECO 2", "SECO 3", "SECO 4"})
        Me.cboProductName.Location = New System.Drawing.Point(46, 60)
        Me.cboProductName.Name = "cboProductName"
        Me.cboProductName.Size = New System.Drawing.Size(193, 21)
        Me.cboProductName.TabIndex = 17
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(97, 177)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmSelectProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.cboProductName)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmSelectProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelectProduct"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboProductName As ComboBox
    Friend WithEvents btnOK As Button
End Class
