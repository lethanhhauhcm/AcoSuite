<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductCostEdit
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
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboCur = New System.Windows.Forms.ComboBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNbrOfUnit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboOccurrence = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboProductName = New System.Windows.Forms.ComboBox()
        Me.cboFormula = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMinAmount = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.txtAmountAfter = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtRecId
        '
        Me.txtRecId.Location = New System.Drawing.Point(92, 10)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.ReadOnly = True
        Me.txtRecId.Size = New System.Drawing.Size(100, 20)
        Me.txtRecId.TabIndex = 112
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "RecId"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(96, 247)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 20)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "ProductName"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(311, 247)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 20)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboCur
        '
        Me.cboCur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCur.FormattingEnabled = True
        Me.cboCur.Items.AddRange(New Object() {"EUR", "USD", "VND"})
        Me.cboCur.Location = New System.Drawing.Point(92, 64)
        Me.cboCur.Name = "cboCur"
        Me.cboCur.Size = New System.Drawing.Size(121, 21)
        Me.cboCur.TabIndex = 1
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd MMM yy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(265, 220)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(184, 20)
        Me.dtpTo.TabIndex = 10
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd MMM yy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(92, 220)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(167, 20)
        Me.dtpFrom.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 229)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "ValidFrom/To"
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Licence", "Transaction", "Ticket", "Set-up"})
        Me.cboUnit.Location = New System.Drawing.Point(252, 122)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(110, 21)
        Me.cboUnit.TabIndex = 5
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(252, 66)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(197, 20)
        Me.txtAmount.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Cur/Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Number/Unit"
        '
        'txtNbrOfUnit
        '
        Me.txtNbrOfUnit.Location = New System.Drawing.Point(92, 118)
        Me.txtNbrOfUnit.Name = "txtNbrOfUnit"
        Me.txtNbrOfUnit.Size = New System.Drawing.Size(121, 20)
        Me.txtNbrOfUnit.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Formula"
        '
        'cboOccurrence
        '
        Me.cboOccurrence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOccurrence.FormattingEnabled = True
        Me.cboOccurrence.Items.AddRange(New Object() {"Monthly", "OneTime", "Yearly", "Once", "6Month", "12Month"})
        Me.cboOccurrence.Location = New System.Drawing.Point(92, 195)
        Me.cboOccurrence.Name = "cboOccurrence"
        Me.cboOccurrence.Size = New System.Drawing.Size(121, 21)
        Me.cboOccurrence.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 143
        Me.Label7.Text = "Occurence"
        '
        'cboProductName
        '
        Me.cboProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProductName.FormattingEnabled = True
        Me.cboProductName.Location = New System.Drawing.Point(92, 36)
        Me.cboProductName.Name = "cboProductName"
        Me.cboProductName.Size = New System.Drawing.Size(357, 21)
        Me.cboProductName.TabIndex = 0
        '
        'cboFormula
        '
        Me.cboFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormula.FormattingEnabled = True
        Me.cboFormula.Items.AddRange(New Object() {"Block", "First"})
        Me.cboFormula.Location = New System.Drawing.Point(92, 91)
        Me.cboFormula.Name = "cboFormula"
        Me.cboFormula.Size = New System.Drawing.Size(121, 21)
        Me.cboFormula.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 147
        Me.Label9.Text = "Conditions"
        '
        'txtMinAmount
        '
        Me.txtMinAmount.Location = New System.Drawing.Point(92, 169)
        Me.txtMinAmount.Name = "txtMinAmount"
        Me.txtMinAmount.Size = New System.Drawing.Size(121, 20)
        Me.txtMinAmount.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 149
        Me.Label8.Text = "MinAmount"
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Items.AddRange(New Object() {"NA", "PerSegment", "Exessive"})
        Me.cboCondition.Location = New System.Drawing.Point(92, 144)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(121, 21)
        Me.cboCondition.TabIndex = 6
        '
        'txtAmountAfter
        '
        Me.txtAmountAfter.Location = New System.Drawing.Point(252, 91)
        Me.txtAmountAfter.Name = "txtAmountAfter"
        Me.txtAmountAfter.Size = New System.Drawing.Size(197, 20)
        Me.txtAmountAfter.TabIndex = 150
        '
        'frmProductCostEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.txtAmountAfter)
        Me.Controls.Add(Me.cboCondition)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMinAmount)
        Me.Controls.Add(Me.cboFormula)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboProductName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboOccurrence)
        Me.Controls.Add(Me.cboCur)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboUnit)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNbrOfUnit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmProductCostEdit"
        Me.Text = "frmProductCostEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboCur As System.Windows.Forms.ComboBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNbrOfUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboOccurrence As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboProductName As System.Windows.Forms.ComboBox
    Friend WithEvents cboFormula As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMinAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmountAfter As TextBox
End Class
