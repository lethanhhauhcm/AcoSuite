<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductOfferEdit
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
        Me.chkManualCheckRequired = New System.Windows.Forms.CheckBox()
        Me.txtOfferId = New System.Windows.Forms.TextBox()
        Me.lblRecId = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboObject = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboValidTo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboValidFrom = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.dgFormula = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboProductName = New System.Windows.Forms.ComboBox()
        Me.chkGetInvoice = New System.Windows.Forms.CheckBox()
        Me.dgvOffcID = New System.Windows.Forms.DataGridView()
        CType(Me.dgFormula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOffcID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkManualCheckRequired
        '
        Me.chkManualCheckRequired.AutoSize = True
        Me.chkManualCheckRequired.Location = New System.Drawing.Point(560, 57)
        Me.chkManualCheckRequired.Name = "chkManualCheckRequired"
        Me.chkManualCheckRequired.Size = New System.Drawing.Size(135, 17)
        Me.chkManualCheckRequired.TabIndex = 61
        Me.chkManualCheckRequired.Text = "ManualCheckRequired"
        Me.chkManualCheckRequired.UseVisualStyleBackColor = True
        '
        'txtOfferId
        '
        Me.txtOfferId.Enabled = False
        Me.txtOfferId.Location = New System.Drawing.Point(612, 8)
        Me.txtOfferId.Name = "txtOfferId"
        Me.txtOfferId.Size = New System.Drawing.Size(80, 20)
        Me.txtOfferId.TabIndex = 60
        '
        'lblRecId
        '
        Me.lblRecId.AutoSize = True
        Me.lblRecId.Location = New System.Drawing.Point(567, 15)
        Me.lblRecId.Name = "lblRecId"
        Me.lblRecId.Size = New System.Drawing.Size(39, 13)
        Me.lblRecId.TabIndex = 59
        Me.lblRecId.Text = "OfferId"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(133, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Object"
        '
        'cboObject
        '
        Me.cboObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObject.FormattingEnabled = True
        Me.cboObject.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboObject.Location = New System.Drawing.Point(136, 45)
        Me.cboObject.Name = "cboObject"
        Me.cboObject.Size = New System.Drawing.Size(100, 21)
        Me.cboObject.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(471, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "ValidTo"
        '
        'cboValidTo
        '
        Me.cboValidTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidTo.FormattingEnabled = True
        Me.cboValidTo.Location = New System.Drawing.Point(474, 45)
        Me.cboValidTo.Name = "cboValidTo"
        Me.cboValidTo.Size = New System.Drawing.Size(80, 21)
        Me.cboValidTo.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(389, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "ValidFrom"
        '
        'cboValidFrom
        '
        Me.cboValidFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidFrom.FormattingEnabled = True
        Me.cboValidFrom.Location = New System.Drawing.Point(392, 45)
        Me.cboValidFrom.Name = "cboValidFrom"
        Me.cboValidFrom.Size = New System.Drawing.Size(80, 21)
        Me.cboValidFrom.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Customer"
        '
        'cboShortName
        '
        Me.cboShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboShortName.Location = New System.Drawing.Point(9, 45)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(121, 21)
        Me.cboShortName.TabIndex = 45
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(167, 642)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 50
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'dgFormula
        '
        Me.dgFormula.AllowUserToAddRows = False
        Me.dgFormula.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFormula.Location = New System.Drawing.Point(1, 80)
        Me.dgFormula.Name = "dgFormula"
        Me.dgFormula.ReadOnly = True
        Me.dgFormula.Size = New System.Drawing.Size(691, 544)
        Me.dgFormula.TabIndex = 53
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(420, 642)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 52
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(291, 642)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 51
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "ProductName"
        '
        'cboProductName
        '
        Me.cboProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProductName.FormattingEnabled = True
        Me.cboProductName.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboProductName.Location = New System.Drawing.Point(242, 45)
        Me.cboProductName.Name = "cboProductName"
        Me.cboProductName.Size = New System.Drawing.Size(144, 21)
        Me.cboProductName.TabIndex = 62
        '
        'chkGetInvoice
        '
        Me.chkGetInvoice.AutoSize = True
        Me.chkGetInvoice.Location = New System.Drawing.Point(560, 34)
        Me.chkGetInvoice.Name = "chkGetInvoice"
        Me.chkGetInvoice.Size = New System.Drawing.Size(78, 17)
        Me.chkGetInvoice.TabIndex = 64
        Me.chkGetInvoice.Text = "GetInvoice"
        Me.chkGetInvoice.UseVisualStyleBackColor = True
        '
        'dgvOffcID
        '
        Me.dgvOffcID.AllowUserToAddRows = False
        Me.dgvOffcID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOffcID.Location = New System.Drawing.Point(698, 80)
        Me.dgvOffcID.Name = "dgvOffcID"
        Me.dgvOffcID.Size = New System.Drawing.Size(192, 544)
        Me.dgvOffcID.TabIndex = 65
        '
        'frmProductOfferEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 673)
        Me.Controls.Add(Me.dgvOffcID)
        Me.Controls.Add(Me.chkGetInvoice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboProductName)
        Me.Controls.Add(Me.chkManualCheckRequired)
        Me.Controls.Add(Me.txtOfferId)
        Me.Controls.Add(Me.lblRecId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboObject)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboValidTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboValidFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.dgFormula)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmProductOfferEdit"
        Me.Text = "ProductOfferEdit"
        CType(Me.dgFormula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOffcID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkManualCheckRequired As System.Windows.Forms.CheckBox
    Friend WithEvents txtOfferId As System.Windows.Forms.TextBox
    Friend WithEvents lblRecId As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboObject As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboValidTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboValidFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboShortName As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents dgFormula As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboProductName As System.Windows.Forms.ComboBox
    Friend WithEvents chkGetInvoice As System.Windows.Forms.CheckBox
    Friend WithEvents dgvOffcID As DataGridView
End Class
