<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeData
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCity = New System.Windows.Forms.ComboBox()
        Me.txtNewShortName = New System.Windows.Forms.TextBox()
        Me.txtCrsCode = New System.Windows.Forms.TextBox()
        Me.txtOldCity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOldShortName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNbrOfRecords = New System.Windows.Forms.TextBox()
        Me.cboGDS = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(74, 141)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(103, 20)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(197, 141)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 20)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "GDS/CrsCode"
        '
        'cboCity
        '
        Me.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCity.FormattingEnabled = True
        Me.cboCity.Items.AddRange(New Object() {"SGN", "HAN", "DAD"})
        Me.cboCity.Location = New System.Drawing.Point(144, 88)
        Me.cboCity.Name = "cboCity"
        Me.cboCity.Size = New System.Drawing.Size(100, 21)
        Me.cboCity.TabIndex = 2
        '
        'txtNewShortName
        '
        Me.txtNewShortName.Location = New System.Drawing.Point(264, 88)
        Me.txtNewShortName.MaxLength = 8
        Me.txtNewShortName.Name = "txtNewShortName"
        Me.txtNewShortName.Size = New System.Drawing.Size(100, 20)
        Me.txtNewShortName.TabIndex = 3
        '
        'txtCrsCode
        '
        Me.txtCrsCode.Location = New System.Drawing.Point(264, 2)
        Me.txtCrsCode.Name = "txtCrsCode"
        Me.txtCrsCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCrsCode.TabIndex = 1
        '
        'txtOldCity
        '
        Me.txtOldCity.Location = New System.Drawing.Point(144, 57)
        Me.txtOldCity.MaxLength = 8
        Me.txtOldCity.Name = "txtOldCity"
        Me.txtOldCity.ReadOnly = True
        Me.txtOldCity.Size = New System.Drawing.Size(100, 20)
        Me.txtOldCity.TabIndex = 91
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "NbrOfRecords"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "NewCity/ShortName"
        '
        'txtOldShortName
        '
        Me.txtOldShortName.Location = New System.Drawing.Point(264, 57)
        Me.txtOldShortName.MaxLength = 8
        Me.txtOldShortName.Name = "txtOldShortName"
        Me.txtOldShortName.ReadOnly = True
        Me.txtOldShortName.Size = New System.Drawing.Size(100, 20)
        Me.txtOldShortName.TabIndex = 92
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "OldCity/ShortName"
        '
        'txtNbrOfRecords
        '
        Me.txtNbrOfRecords.ForeColor = System.Drawing.Color.Red
        Me.txtNbrOfRecords.Location = New System.Drawing.Point(144, 28)
        Me.txtNbrOfRecords.MaxLength = 8
        Me.txtNbrOfRecords.Name = "txtNbrOfRecords"
        Me.txtNbrOfRecords.ReadOnly = True
        Me.txtNbrOfRecords.Size = New System.Drawing.Size(100, 20)
        Me.txtNbrOfRecords.TabIndex = 94
        '
        'cboGDS
        '
        Me.cboGDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGDS.FormattingEnabled = True
        Me.cboGDS.Items.AddRange(New Object() {"1A", "1B", "1G", "1S", "1P"})
        Me.cboGDS.Location = New System.Drawing.Point(144, 2)
        Me.cboGDS.Name = "cboGDS"
        Me.cboGDS.Size = New System.Drawing.Size(100, 21)
        Me.cboGDS.TabIndex = 0
        '
        'frmChangeData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 173)
        Me.Controls.Add(Me.cboGDS)
        Me.Controls.Add(Me.txtNbrOfRecords)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtOldShortName)
        Me.Controls.Add(Me.txtOldCity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCrsCode)
        Me.Controls.Add(Me.txtNewShortName)
        Me.Controls.Add(Me.cboCity)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmChangeData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChangeData"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCity As System.Windows.Forms.ComboBox
    Friend WithEvents txtNewShortName As System.Windows.Forms.TextBox
    Friend WithEvents txtCrsCode As System.Windows.Forms.TextBox
    Friend WithEvents txtOldCity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOldShortName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNbrOfRecords As System.Windows.Forms.TextBox
    Friend WithEvents cboGDS As System.Windows.Forms.ComboBox
End Class
