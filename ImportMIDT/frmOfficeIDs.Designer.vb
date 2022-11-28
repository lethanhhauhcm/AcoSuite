<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOfficeIDs
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
        Me.dgrOffcID = New System.Windows.Forms.DataGridView()
        Me.cboGDS = New System.Windows.Forms.ComboBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.lbkEdit = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.chkTMC = New System.Windows.Forms.CheckBox()
        Me.txtOtaName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgrOffcID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgrOffcID
        '
        Me.dgrOffcID.AllowUserToAddRows = False
        Me.dgrOffcID.AllowUserToDeleteRows = False
        Me.dgrOffcID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgrOffcID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrOffcID.Location = New System.Drawing.Point(12, 61)
        Me.dgrOffcID.Name = "dgrOffcID"
        Me.dgrOffcID.ReadOnly = True
        Me.dgrOffcID.Size = New System.Drawing.Size(738, 400)
        Me.dgrOffcID.TabIndex = 104
        '
        'cboGDS
        '
        Me.cboGDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGDS.Enabled = False
        Me.cboGDS.FormattingEnabled = True
        Me.cboGDS.Items.AddRange(New Object() {"1A", "1B", "1G", "1S", "1P"})
        Me.cboGDS.Location = New System.Drawing.Point(10, 10)
        Me.cboGDS.Name = "cboGDS"
        Me.cboGDS.Size = New System.Drawing.Size(58, 21)
        Me.cboGDS.TabIndex = 105
        '
        'txtCode
        '
        Me.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCode.Enabled = False
        Me.txtCode.Location = New System.Drawing.Point(74, 10)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 106
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(352, 32)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 107
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'lbkEdit
        '
        Me.lbkEdit.AutoSize = True
        Me.lbkEdit.Location = New System.Drawing.Point(396, 32)
        Me.lbkEdit.Name = "lbkEdit"
        Me.lbkEdit.Size = New System.Drawing.Size(25, 13)
        Me.lbkEdit.TabIndex = 108
        Me.lbkEdit.TabStop = True
        Me.lbkEdit.Text = "Edit"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(434, 32)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 109
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'cboShortName
        '
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(351, 8)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(121, 21)
        Me.cboShortName.TabIndex = 110
        '
        'chkTMC
        '
        Me.chkTMC.AutoSize = True
        Me.chkTMC.Enabled = False
        Me.chkTMC.Location = New System.Drawing.Point(180, 12)
        Me.chkTMC.Name = "chkTMC"
        Me.chkTMC.Size = New System.Drawing.Size(49, 17)
        Me.chkTMC.TabIndex = 111
        Me.chkTMC.Text = "TMC"
        Me.chkTMC.UseVisualStyleBackColor = True
        '
        'txtOtaName
        '
        Me.txtOtaName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOtaName.Location = New System.Drawing.Point(74, 32)
        Me.txtOtaName.Name = "txtOtaName"
        Me.txtOtaName.Size = New System.Drawing.Size(272, 20)
        Me.txtOtaName.TabIndex = 112
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "OTA Name"
        '
        'frmOfficeIDs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 473)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOtaName)
        Me.Controls.Add(Me.chkTMC)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkEdit)
        Me.Controls.Add(Me.lbkAdd)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.cboGDS)
        Me.Controls.Add(Me.dgrOffcID)
        Me.Name = "frmOfficeIDs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OfficeIDs"
        CType(Me.dgrOffcID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgrOffcID As System.Windows.Forms.DataGridView
    Friend WithEvents cboGDS As System.Windows.Forms.ComboBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lbkAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkEdit As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents cboShortName As System.Windows.Forms.ComboBox
    Friend WithEvents chkTMC As System.Windows.Forms.CheckBox
    Friend WithEvents txtOtaName As TextBox
    Friend WithEvents Label1 As Label
End Class
