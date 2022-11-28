<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRewardsUserEdit
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
        Me.txtBirthDay = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.txtSiName = New System.Windows.Forms.TextBox()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtOffcId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSiCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtBirthDay
        '
        Me.txtBirthDay.Location = New System.Drawing.Point(128, 140)
        Me.txtBirthDay.Name = "txtBirthDay"
        Me.txtBirthDay.ReadOnly = True
        Me.txtBirthDay.Size = New System.Drawing.Size(100, 20)
        Me.txtBirthDay.TabIndex = 105
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(128, 114)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(286, 20)
        Me.txtEmail.TabIndex = 95
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(128, 86)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.ReadOnly = True
        Me.txtMobile.Size = New System.Drawing.Size(286, 20)
        Me.txtMobile.TabIndex = 93
        '
        'txtSiName
        '
        Me.txtSiName.Location = New System.Drawing.Point(128, 54)
        Me.txtSiName.MaxLength = 16
        Me.txtSiName.Name = "txtSiName"
        Me.txtSiName.ReadOnly = True
        Me.txtSiName.Size = New System.Drawing.Size(100, 20)
        Me.txtSiName.TabIndex = 92
        '
        'txtRecId
        '
        Me.txtRecId.Location = New System.Drawing.Point(128, 18)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.ReadOnly = True
        Me.txtRecId.Size = New System.Drawing.Size(100, 20)
        Me.txtRecId.TabIndex = 104
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "RecId"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "Email"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "BirthDay"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Mobile"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(137, 234)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 20)
        Me.btnSave.TabIndex = 96
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "SiName"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(352, 234)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 20)
        Me.btnCancel.TabIndex = 97
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtOffcId
        '
        Me.txtOffcId.Location = New System.Drawing.Point(128, 166)
        Me.txtOffcId.Name = "txtOffcId"
        Me.txtOffcId.Size = New System.Drawing.Size(100, 20)
        Me.txtOffcId.TabIndex = 106
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(50, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "OffcId"
        '
        'txtSiCode
        '
        Me.txtSiCode.Location = New System.Drawing.Point(128, 192)
        Me.txtSiCode.Name = "txtSiCode"
        Me.txtSiCode.Size = New System.Drawing.Size(100, 20)
        Me.txtSiCode.TabIndex = 108
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "SiCode"
        '
        'frmRewardsUserEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.txtSiCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtOffcId)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBirthDay)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.txtSiName)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmRewardsUserEdit"
        Me.Text = "frmRewardsUserEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBirthDay As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents txtSiName As System.Windows.Forms.TextBox
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtOffcId As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSiCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
