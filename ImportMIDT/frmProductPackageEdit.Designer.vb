<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductPackageEdit
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
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNbrOfUnit = New System.Windows.Forms.TextBox()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboProductName = New System.Windows.Forms.ComboBox()
        Me.cboSubProductName = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Items.AddRange(New Object() {"NA", "PerSegment", "Exessive"})
        Me.cboCondition.Location = New System.Drawing.Point(102, 100)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(121, 21)
        Me.cboCondition.TabIndex = 156
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 171
        Me.Label9.Text = "Conditions"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(262, 128)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(150, 20)
        Me.dtpTo.TabIndex = 160
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(102, 127)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(154, 20)
        Me.dtpFrom.TabIndex = 159
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 169
        Me.Label5.Text = "ValidFrom/To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 167
        Me.Label3.Text = "Number/Unit"
        '
        'txtNbrOfUnit
        '
        Me.txtNbrOfUnit.Location = New System.Drawing.Point(102, 74)
        Me.txtNbrOfUnit.Name = "txtNbrOfUnit"
        Me.txtNbrOfUnit.Size = New System.Drawing.Size(121, 20)
        Me.txtNbrOfUnit.TabIndex = 154
        '
        'txtRecId
        '
        Me.txtRecId.Location = New System.Drawing.Point(102, 6)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.ReadOnly = True
        Me.txtRecId.Size = New System.Drawing.Size(100, 20)
        Me.txtRecId.TabIndex = 165
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 164
        Me.Label6.Text = "RecId"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(106, 154)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 20)
        Me.btnSave.TabIndex = 161
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 163
        Me.Label1.Text = "SubProductName"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(321, 154)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 20)
        Me.btnCancel.TabIndex = 162
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Licence", "Transaction", "Ticket", "Set-up"})
        Me.cboUnit.Location = New System.Drawing.Point(262, 78)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(121, 21)
        Me.cboUnit.TabIndex = 155
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "ProductName"
        '
        'cboProductName
        '
        Me.cboProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProductName.FormattingEnabled = True
        Me.cboProductName.Items.AddRange(New Object() {"Licence", "Transaction", "Ticket", "Set-up"})
        Me.cboProductName.Location = New System.Drawing.Point(102, 30)
        Me.cboProductName.Name = "cboProductName"
        Me.cboProductName.Size = New System.Drawing.Size(310, 21)
        Me.cboProductName.TabIndex = 175
        '
        'cboSubProductName
        '
        Me.cboSubProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubProductName.FormattingEnabled = True
        Me.cboSubProductName.Items.AddRange(New Object() {"Licence", "Transaction", "Ticket", "Set-up"})
        Me.cboSubProductName.Location = New System.Drawing.Point(102, 53)
        Me.cboSubProductName.Name = "cboSubProductName"
        Me.cboSubProductName.Size = New System.Drawing.Size(310, 21)
        Me.cboSubProductName.TabIndex = 176
        '
        'frmProductPackageEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 173)
        Me.Controls.Add(Me.cboSubProductName)
        Me.Controls.Add(Me.cboProductName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCondition)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboUnit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNbrOfUnit)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmProductPackageEdit"
        Me.Text = "ProductPackageEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNbrOfUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboProductName As System.Windows.Forms.ComboBox
    Friend WithEvents cboSubProductName As System.Windows.Forms.ComboBox
End Class
