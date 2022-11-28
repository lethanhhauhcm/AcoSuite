<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayment
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.txtVND = New System.Windows.Forms.TextBox()
        Me.dtpTrxDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboFOP = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbkSave
        '
        Me.lbkSave.AutoSize = True
        Me.lbkSave.Location = New System.Drawing.Point(63, 97)
        Me.lbkSave.Name = "lbkSave"
        Me.lbkSave.Size = New System.Drawing.Size(32, 13)
        Me.lbkSave.TabIndex = 5
        Me.lbkSave.TabStop = True
        Me.lbkSave.Text = "Save"
        '
        'lbkCancel
        '
        Me.lbkCancel.AutoSize = True
        Me.lbkCancel.Location = New System.Drawing.Point(150, 97)
        Me.lbkCancel.Name = "lbkCancel"
        Me.lbkCancel.Size = New System.Drawing.Size(40, 13)
        Me.lbkCancel.TabIndex = 6
        Me.lbkCancel.TabStop = True
        Me.lbkCancel.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Customer"
        '
        'cboShortName
        '
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(64, 6)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(168, 21)
        Me.cboShortName.TabIndex = 0
        '
        'txtVND
        '
        Me.txtVND.Location = New System.Drawing.Point(132, 34)
        Me.txtVND.Name = "txtVND"
        Me.txtVND.Size = New System.Drawing.Size(100, 20)
        Me.txtVND.TabIndex = 2
        '
        'dtpTrxDate
        '
        Me.dtpTrxDate.CustomFormat = "dd MMM yy"
        Me.dtpTrxDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTrxDate.Location = New System.Drawing.Point(384, 34)
        Me.dtpTrxDate.Name = "dtpTrxDate"
        Me.dtpTrxDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpTrxDate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(333, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "TrxDate"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(66, 59)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(479, 20)
        Me.txtDescription.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Description"
        '
        'cboFOP
        '
        Me.cboFOP.FormattingEnabled = True
        Me.cboFOP.Items.AddRange(New Object() {"BTF", "CSH", "COF"})
        Me.cboFOP.Location = New System.Drawing.Point(64, 32)
        Me.cboFOP.Name = "cboFOP"
        Me.cboFOP.Size = New System.Drawing.Size(62, 21)
        Me.cboFOP.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "FOP/VND"
        '
        'txtRecId
        '
        Me.txtRecId.Enabled = False
        Me.txtRecId.Location = New System.Drawing.Point(384, 6)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.Size = New System.Drawing.Size(100, 20)
        Me.txtRecId.TabIndex = 25
        Me.txtRecId.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(318, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "RecId"
        '
        'frmPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 116)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboFOP)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpTrxDate)
        Me.Controls.Add(Me.txtVND)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbkCancel)
        Me.Controls.Add(Me.lbkSave)
        Me.Name = "frmPayment"
        Me.Text = "Payment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbkSave As LinkLabel
    Friend WithEvents lbkCancel As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents cboShortName As ComboBox
    Friend WithEvents txtVND As TextBox
    Friend WithEvents dtpTrxDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboFOP As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRecId As TextBox
    Friend WithEvents Label2 As Label
End Class
