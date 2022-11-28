<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFareBatchEdit
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
        Me.lbkSave = New System.Windows.Forms.LinkLabel()
        Me.lbkCancel = New System.Windows.Forms.LinkLabel()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.lblCar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCar = New System.Windows.Forms.TextBox()
        Me.txtOri = New System.Windows.Forms.TextBox()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.txtFareBasis = New System.Windows.Forms.TextBox()
        Me.txtBatchName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFareType = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDepDate = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'lbkSave
        '
        Me.lbkSave.AutoSize = True
        Me.lbkSave.Location = New System.Drawing.Point(52, 241)
        Me.lbkSave.Name = "lbkSave"
        Me.lbkSave.Size = New System.Drawing.Size(32, 13)
        Me.lbkSave.TabIndex = 7
        Me.lbkSave.TabStop = True
        Me.lbkSave.Text = "Save"
        '
        'lbkCancel
        '
        Me.lbkCancel.AutoSize = True
        Me.lbkCancel.Location = New System.Drawing.Point(180, 241)
        Me.lbkCancel.Name = "lbkCancel"
        Me.lbkCancel.Size = New System.Drawing.Size(40, 13)
        Me.lbkCancel.TabIndex = 8
        Me.lbkCancel.TabStop = True
        Me.lbkCancel.Text = "Cancel"
        '
        'txtRecId
        '
        Me.txtRecId.Location = New System.Drawing.Point(183, 2)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.ReadOnly = True
        Me.txtRecId.Size = New System.Drawing.Size(100, 20)
        Me.txtRecId.TabIndex = 2
        '
        'lblCar
        '
        Me.lblCar.AutoSize = True
        Me.lblCar.Location = New System.Drawing.Point(12, 51)
        Me.lblCar.Name = "lblCar"
        Me.lblCar.Size = New System.Drawing.Size(23, 13)
        Me.lblCar.TabIndex = 3
        Me.lblCar.Text = "Car"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ori"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Des"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "FareBasis"
        '
        'txtCar
        '
        Me.txtCar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCar.Location = New System.Drawing.Point(72, 48)
        Me.txtCar.MaxLength = 2
        Me.txtCar.Name = "txtCar"
        Me.txtCar.Size = New System.Drawing.Size(211, 20)
        Me.txtCar.TabIndex = 1
        '
        'txtOri
        '
        Me.txtOri.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOri.Location = New System.Drawing.Point(72, 102)
        Me.txtOri.MaxLength = 16
        Me.txtOri.Name = "txtOri"
        Me.txtOri.Size = New System.Drawing.Size(211, 20)
        Me.txtOri.TabIndex = 3
        '
        'txtDes
        '
        Me.txtDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes.Location = New System.Drawing.Point(72, 125)
        Me.txtDes.MaxLength = 16
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(211, 20)
        Me.txtDes.TabIndex = 4
        '
        'txtFareBasis
        '
        Me.txtFareBasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFareBasis.Location = New System.Drawing.Point(73, 174)
        Me.txtFareBasis.MaxLength = 32
        Me.txtFareBasis.Name = "txtFareBasis"
        Me.txtFareBasis.Size = New System.Drawing.Size(211, 20)
        Me.txtFareBasis.TabIndex = 6
        '
        'txtBatchName
        '
        Me.txtBatchName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchName.Location = New System.Drawing.Point(72, 28)
        Me.txtBatchName.MaxLength = 8
        Me.txtBatchName.Name = "txtBatchName"
        Me.txtBatchName.Size = New System.Drawing.Size(211, 20)
        Me.txtBatchName.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "BatchName"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "FareType"
        '
        'cboFareType
        '
        Me.cboFareType.FormattingEnabled = True
        Me.cboFareType.Items.AddRange(New Object() {"ALL", "PUB", "NEG"})
        Me.cboFareType.Location = New System.Drawing.Point(73, 73)
        Me.cboFareType.Name = "cboFareType"
        Me.cboFareType.Size = New System.Drawing.Size(121, 21)
        Me.cboFareType.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "DepDate"
        '
        'dtpDepDate
        '
        Me.dtpDepDate.CustomFormat = "dd MMM yy"
        Me.dtpDepDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDepDate.Location = New System.Drawing.Point(73, 148)
        Me.dtpDepDate.MinDate = New Date(2017, 1, 3, 0, 0, 0, 0)
        Me.dtpDepDate.Name = "dtpDepDate"
        Me.dtpDepDate.Size = New System.Drawing.Size(211, 20)
        Me.dtpDepDate.TabIndex = 5
        '
        'frmFareBatchEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.dtpDepDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboFareType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBatchName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFareBasis)
        Me.Controls.Add(Me.txtDes)
        Me.Controls.Add(Me.txtOri)
        Me.Controls.Add(Me.txtCar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblCar)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.lbkCancel)
        Me.Controls.Add(Me.lbkSave)
        Me.Name = "frmFareBatchEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FareBatchEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbkSave As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkCancel As System.Windows.Forms.LinkLabel
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents lblCar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCar As System.Windows.Forms.TextBox
    Friend WithEvents txtOri As System.Windows.Forms.TextBox
    Friend WithEvents txtDes As System.Windows.Forms.TextBox
    Friend WithEvents txtFareBasis As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFareType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDepDate As System.Windows.Forms.DateTimePicker
End Class
