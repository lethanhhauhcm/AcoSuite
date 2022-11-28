<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowMessage
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
        Me.lbl01 = New System.Windows.Forms.Label()
        Me.btn01 = New System.Windows.Forms.Button()
        Me.btn02 = New System.Windows.Forms.Button()
        Me.btn03 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl01
        '
        Me.lbl01.AutoSize = True
        Me.lbl01.Location = New System.Drawing.Point(12, 9)
        Me.lbl01.Name = "lbl01"
        Me.lbl01.Size = New System.Drawing.Size(39, 13)
        Me.lbl01.TabIndex = 0
        Me.lbl01.Text = "Label1"
        '
        'btn01
        '
        Me.btn01.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn01.Location = New System.Drawing.Point(12, 25)
        Me.btn01.Name = "btn01"
        Me.btn01.Size = New System.Drawing.Size(75, 23)
        Me.btn01.TabIndex = 1
        Me.btn01.Text = "Button1"
        Me.btn01.UseVisualStyleBackColor = True
        '
        'btn02
        '
        Me.btn02.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.btn02.Location = New System.Drawing.Point(93, 25)
        Me.btn02.Name = "btn02"
        Me.btn02.Size = New System.Drawing.Size(75, 23)
        Me.btn02.TabIndex = 2
        Me.btn02.Text = "Button2"
        Me.btn02.UseVisualStyleBackColor = True
        '
        'btn03
        '
        Me.btn03.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btn03.Location = New System.Drawing.Point(174, 25)
        Me.btn03.Name = "btn03"
        Me.btn03.Size = New System.Drawing.Size(75, 23)
        Me.btn03.TabIndex = 3
        Me.btn03.Text = "Button3"
        Me.btn03.UseVisualStyleBackColor = True
        '
        'frmShowMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(258, 55)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn03)
        Me.Controls.Add(Me.btn02)
        Me.Controls.Add(Me.btn01)
        Me.Controls.Add(Me.lbl01)
        Me.Name = "frmShowMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmShowMessage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl01 As Label
    Friend WithEvents btn01 As Button
    Friend WithEvents btn02 As Button
    Friend WithEvents btn03 As Button
End Class
