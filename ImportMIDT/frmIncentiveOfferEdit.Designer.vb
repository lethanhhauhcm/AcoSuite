<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentiveOfferEdit
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
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.dgFormula = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboValidTo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboValidFrom = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTimeFrame = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboObject = New System.Windows.Forms.ComboBox()
        Me.lblRecId = New System.Windows.Forms.Label()
        Me.txtOfferId = New System.Windows.Forms.TextBox()
        Me.chkManualCheckRequired = New System.Windows.Forms.CheckBox()
        CType(Me.dgFormula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(168, 640)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 5
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'dgFormula
        '
        Me.dgFormula.AllowUserToAddRows = False
        Me.dgFormula.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFormula.Location = New System.Drawing.Point(2, 78)
        Me.dgFormula.Name = "dgFormula"
        Me.dgFormula.ReadOnly = True
        Me.dgFormula.Size = New System.Drawing.Size(691, 556)
        Me.dgFormula.TabIndex = 8
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(421, 640)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(292, 640)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(411, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "ValidTo"
        '
        'cboValidTo
        '
        Me.cboValidTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidTo.FormattingEnabled = True
        Me.cboValidTo.Location = New System.Drawing.Point(414, 42)
        Me.cboValidTo.Name = "cboValidTo"
        Me.cboValidTo.Size = New System.Drawing.Size(80, 21)
        Me.cboValidTo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(329, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "ValidFrom"
        '
        'cboValidFrom
        '
        Me.cboValidFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidFrom.FormattingEnabled = True
        Me.cboValidFrom.Location = New System.Drawing.Point(332, 42)
        Me.cboValidFrom.Name = "cboValidFrom"
        Me.cboValidFrom.Size = New System.Drawing.Size(80, 21)
        Me.cboValidFrom.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Customer"
        '
        'cboShortName
        '
        Me.cboShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(10, 43)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(121, 21)
        Me.cboShortName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(243, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "TimeFrame"
        '
        'cboTimeFrame
        '
        Me.cboTimeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimeFrame.FormattingEnabled = True
        Me.cboTimeFrame.Items.AddRange(New Object() {"Month", "Quarter", "HalfYear", "Year"})
        Me.cboTimeFrame.Location = New System.Drawing.Point(246, 43)
        Me.cboTimeFrame.Name = "cboTimeFrame"
        Me.cboTimeFrame.Size = New System.Drawing.Size(80, 21)
        Me.cboTimeFrame.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(134, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Object"
        '
        'cboObject
        '
        Me.cboObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObject.FormattingEnabled = True
        Me.cboObject.Items.AddRange(New Object() {"Customer", "Contact", "ContactGroup"})
        Me.cboObject.Location = New System.Drawing.Point(137, 43)
        Me.cboObject.Name = "cboObject"
        Me.cboObject.Size = New System.Drawing.Size(100, 21)
        Me.cboObject.TabIndex = 1
        '
        'lblRecId
        '
        Me.lblRecId.AutoSize = True
        Me.lblRecId.Location = New System.Drawing.Point(568, 13)
        Me.lblRecId.Name = "lblRecId"
        Me.lblRecId.Size = New System.Drawing.Size(39, 13)
        Me.lblRecId.TabIndex = 42
        Me.lblRecId.Text = "OfferId"
        '
        'txtOfferId
        '
        Me.txtOfferId.Enabled = False
        Me.txtOfferId.Location = New System.Drawing.Point(613, 6)
        Me.txtOfferId.Name = "txtOfferId"
        Me.txtOfferId.Size = New System.Drawing.Size(80, 20)
        Me.txtOfferId.TabIndex = 43
        '
        'chkManualCheckRequired
        '
        Me.chkManualCheckRequired.AutoSize = True
        Me.chkManualCheckRequired.Location = New System.Drawing.Point(500, 43)
        Me.chkManualCheckRequired.Name = "chkManualCheckRequired"
        Me.chkManualCheckRequired.Size = New System.Drawing.Size(135, 17)
        Me.chkManualCheckRequired.TabIndex = 44
        Me.chkManualCheckRequired.Text = "ManualCheckRequired"
        Me.chkManualCheckRequired.UseVisualStyleBackColor = True
        '
        'frmIncentiveOfferEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 673)
        Me.Controls.Add(Me.chkManualCheckRequired)
        Me.Controls.Add(Me.txtOfferId)
        Me.Controls.Add(Me.lblRecId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboObject)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTimeFrame)
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
        Me.Name = "frmIncentiveOfferEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IncentiveOfferEdit"
        CType(Me.dgFormula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents dgFormula As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboValidTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboValidFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboShortName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTimeFrame As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboObject As System.Windows.Forms.ComboBox
    Friend WithEvents lblRecId As System.Windows.Forms.Label
    Friend WithEvents txtOfferId As System.Windows.Forms.TextBox
    Friend WithEvents chkManualCheckRequired As System.Windows.Forms.CheckBox
End Class
