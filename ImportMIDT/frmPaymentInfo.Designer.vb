<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentInfo
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAccountOwner = New System.Windows.Forms.Label()
        Me.txtCustShortName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.txtBranchName = New System.Windows.Forms.TextBox()
        Me.txtBankAccountNbr = New System.Windows.Forms.TextBox()
        Me.txtAccountOwner = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 103)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 194
        Me.Label16.Text = "AccountNbr"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 193
        Me.Label14.Text = "BankName"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 192
        Me.Label13.Text = "Emails"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "BranchName"
        '
        'lblAccountOwner
        '
        Me.lblAccountOwner.AutoSize = True
        Me.lblAccountOwner.Location = New System.Drawing.Point(12, 125)
        Me.lblAccountOwner.Name = "lblAccountOwner"
        Me.lblAccountOwner.Size = New System.Drawing.Size(78, 13)
        Me.lblAccountOwner.TabIndex = 196
        Me.lblAccountOwner.Text = "AccountOwner"
        '
        'txtCustShortName
        '
        Me.txtCustShortName.Enabled = False
        Me.txtCustShortName.Location = New System.Drawing.Point(99, 2)
        Me.txtCustShortName.MaxLength = 8
        Me.txtCustShortName.Name = "txtCustShortName"
        Me.txtCustShortName.Size = New System.Drawing.Size(120, 20)
        Me.txtCustShortName.TabIndex = 197
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 198
        Me.Label3.Text = "ShortName"
        '
        'txtRecId
        '
        Me.txtRecId.Location = New System.Drawing.Point(360, 2)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.ReadOnly = True
        Me.txtRecId.Size = New System.Drawing.Size(120, 20)
        Me.txtRecId.TabIndex = 199
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(318, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 200
        Me.Label10.Text = "RecId"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(99, 30)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(381, 20)
        Me.txtEmail.TabIndex = 0
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(99, 56)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(381, 20)
        Me.txtBankName.TabIndex = 1
        '
        'txtBranchName
        '
        Me.txtBranchName.Location = New System.Drawing.Point(99, 78)
        Me.txtBranchName.Name = "txtBranchName"
        Me.txtBranchName.Size = New System.Drawing.Size(381, 20)
        Me.txtBranchName.TabIndex = 2
        '
        'txtBankAccountNbr
        '
        Me.txtBankAccountNbr.Location = New System.Drawing.Point(99, 100)
        Me.txtBankAccountNbr.Name = "txtBankAccountNbr"
        Me.txtBankAccountNbr.Size = New System.Drawing.Size(381, 20)
        Me.txtBankAccountNbr.TabIndex = 3
        '
        'txtAccountOwner
        '
        Me.txtAccountOwner.Location = New System.Drawing.Point(99, 122)
        Me.txtAccountOwner.Name = "txtAccountOwner"
        Me.txtAccountOwner.Size = New System.Drawing.Size(381, 20)
        Me.txtAccountOwner.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(124, 148)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 20)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(280, 148)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 20)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmPaymentInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 173)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtAccountOwner)
        Me.Controls.Add(Me.txtBankAccountNbr)
        Me.Controls.Add(Me.txtBranchName)
        Me.Controls.Add(Me.txtBankName)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCustShortName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblAccountOwner)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Name = "frmPaymentInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PaymentInfo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAccountOwner As System.Windows.Forms.Label
    Friend WithEvents txtCustShortName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtBranchName As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountNbr As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountOwner As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
