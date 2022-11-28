<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductRightEdit
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
        Me.cboContactId = New System.Windows.Forms.ComboBox()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboProduct = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dtpValidFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpValidTo = New System.Windows.Forms.DateTimePicker()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbkExpire = New System.Windows.Forms.LinkLabel()
        Me.chkIndefValidTo = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtProductId = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtContactId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Contact"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "ShortName"
        '
        'cboContactId
        '
        Me.cboContactId.FormattingEnabled = True
        Me.cboContactId.Location = New System.Drawing.Point(80, 68)
        Me.cboContactId.Name = "cboContactId"
        Me.cboContactId.Size = New System.Drawing.Size(187, 21)
        Me.cboContactId.TabIndex = 1
        '
        'cboShortName
        '
        Me.cboShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(82, 38)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(185, 21)
        Me.cboShortName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 162
        Me.Label3.Text = "Product"
        '
        'cboProduct
        '
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(80, 121)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(187, 21)
        Me.cboProduct.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "ValidFrom/To"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(84, 238)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(192, 238)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dtpValidFrom
        '
        Me.dtpValidFrom.CustomFormat = "dd MMM yy"
        Me.dtpValidFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpValidFrom.Location = New System.Drawing.Point(91, 193)
        Me.dtpValidFrom.Name = "dtpValidFrom"
        Me.dtpValidFrom.Size = New System.Drawing.Size(121, 20)
        Me.dtpValidFrom.TabIndex = 3
        '
        'dtpValidTo
        '
        Me.dtpValidTo.CustomFormat = "dd MMM yy"
        Me.dtpValidTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpValidTo.Location = New System.Drawing.Point(218, 193)
        Me.dtpValidTo.Name = "dtpValidTo"
        Me.dtpValidTo.Size = New System.Drawing.Size(121, 20)
        Me.dtpValidTo.TabIndex = 4
        '
        'txtRecId
        '
        Me.txtRecId.Enabled = False
        Me.txtRecId.Location = New System.Drawing.Point(167, 12)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.Size = New System.Drawing.Size(100, 20)
        Me.txtRecId.TabIndex = 168
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(125, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 169
        Me.Label5.Text = "RecId"
        '
        'lbkExpire
        '
        Me.lbkExpire.AutoSize = True
        Me.lbkExpire.Location = New System.Drawing.Point(88, 216)
        Me.lbkExpire.Name = "lbkExpire"
        Me.lbkExpire.Size = New System.Drawing.Size(96, 13)
        Me.lbkExpire.TabIndex = 170
        Me.lbkExpire.TabStop = True
        Me.lbkExpire.Text = "ValidTo=Yesterday"
        '
        'chkIndefValidTo
        '
        Me.chkIndefValidTo.AutoSize = True
        Me.chkIndefValidTo.Location = New System.Drawing.Point(218, 215)
        Me.chkIndefValidTo.Name = "chkIndefValidTo"
        Me.chkIndefValidTo.Size = New System.Drawing.Size(89, 17)
        Me.chkIndefValidTo.TabIndex = 171
        Me.chkIndefValidTo.Text = "Indef ValidTo"
        Me.chkIndefValidTo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "ProductID"
        '
        'txtProductId
        '
        Me.txtProductId.Location = New System.Drawing.Point(80, 150)
        Me.txtProductId.Name = "txtProductId"
        Me.txtProductId.Size = New System.Drawing.Size(187, 20)
        Me.txtProductId.TabIndex = 173
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "ContactId"
        '
        'txtContactId
        '
        Me.txtContactId.Enabled = False
        Me.txtContactId.Location = New System.Drawing.Point(80, 95)
        Me.txtContactId.Name = "txtContactId"
        Me.txtContactId.Size = New System.Drawing.Size(100, 20)
        Me.txtContactId.TabIndex = 174
        '
        'frmProductRightEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 273)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtContactId)
        Me.Controls.Add(Me.txtProductId)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkIndefValidTo)
        Me.Controls.Add(Me.lbkExpire)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.dtpValidTo)
        Me.Controls.Add(Me.dtpValidFrom)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboProduct)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboContactId)
        Me.Controls.Add(Me.cboShortName)
        Me.Name = "frmProductRightEdit"
        Me.Text = "ProductRightEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboContactId As System.Windows.Forms.ComboBox
    Friend WithEvents cboShortName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dtpValidFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpValidTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbkExpire As System.Windows.Forms.LinkLabel
    Friend WithEvents chkIndefValidTo As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProductId As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtContactId As TextBox
End Class
