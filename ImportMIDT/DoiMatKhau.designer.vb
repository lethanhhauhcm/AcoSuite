<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DoiMatKhau
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
        Me.txtOldPass = New System.Windows.Forms.TextBox()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.txtConfNewPass = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtOldPass
        '
        Me.txtOldPass.Location = New System.Drawing.Point(143, 6)
        Me.txtOldPass.Name = "txtOldPass"
        Me.txtOldPass.Size = New System.Drawing.Size(129, 20)
        Me.txtOldPass.TabIndex = 1
        Me.txtOldPass.UseSystemPasswordChar = True
        Me.txtOldPass.UseWaitCursor = True
        '
        'txtNewPass
        '
        Me.txtNewPass.Location = New System.Drawing.Point(143, 32)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Size = New System.Drawing.Size(129, 20)
        Me.txtNewPass.TabIndex = 2
        Me.txtNewPass.UseSystemPasswordChar = True
        '
        'txtConfNewPass
        '
        Me.txtConfNewPass.Location = New System.Drawing.Point(143, 58)
        Me.txtConfNewPass.Name = "txtConfNewPass"
        Me.txtConfNewPass.Size = New System.Drawing.Size(129, 20)
        Me.txtConfNewPass.TabIndex = 3
        Me.txtConfNewPass.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mật khẩu mới"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nhập lại mật khẩu mới"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Mật khẩu hiện tại"
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(143, 84)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(129, 23)
        Me.btnConfirm.TabIndex = 4
        Me.btnConfirm.Text = "Xác nhận thay đổi"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'DoiMatKhau
        '
        Me.AcceptButton = Me.btnConfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(277, 112)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtConfNewPass)
        Me.Controls.Add(Me.txtNewPass)
        Me.Controls.Add(Me.txtOldPass)
        Me.Location = New System.Drawing.Point(0, 50)
        Me.Name = "DoiMatKhau"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Đổi mật khẩu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOldPass As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPass As System.Windows.Forms.TextBox
    Friend WithEvents txtConfNewPass As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
End Class
