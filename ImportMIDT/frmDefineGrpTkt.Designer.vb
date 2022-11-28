<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDefineGrpTkt
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
        Me.dgrGrpDefinition = New System.Windows.Forms.DataGridView()
        Me.lbkUpdate = New System.Windows.Forms.LinkLabel()
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkAllSecRequired = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAL = New System.Windows.Forms.TextBox()
        Me.txtRBD = New System.Windows.Forms.TextBox()
        Me.lbkApply = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgrGrpDefinition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgrGrpDefinition
        '
        Me.dgrGrpDefinition.AllowUserToAddRows = False
        Me.dgrGrpDefinition.AllowUserToDeleteRows = False
        Me.dgrGrpDefinition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrGrpDefinition.Location = New System.Drawing.Point(0, 40)
        Me.dgrGrpDefinition.Name = "dgrGrpDefinition"
        Me.dgrGrpDefinition.ReadOnly = True
        Me.dgrGrpDefinition.Size = New System.Drawing.Size(917, 192)
        Me.dgrGrpDefinition.TabIndex = 0
        '
        'lbkUpdate
        '
        Me.lbkUpdate.AutoSize = True
        Me.lbkUpdate.Location = New System.Drawing.Point(238, 19)
        Me.lbkUpdate.Name = "lbkUpdate"
        Me.lbkUpdate.Size = New System.Drawing.Size(42, 13)
        Me.lbkUpdate.TabIndex = 110
        Me.lbkUpdate.TabStop = True
        Me.lbkUpdate.Text = "Update"
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(206, 18)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 109
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Airline"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "RBD"
        '
        'chkAllSecRequired
        '
        Me.chkAllSecRequired.AutoSize = True
        Me.chkAllSecRequired.Location = New System.Drawing.Point(101, 18)
        Me.chkAllSecRequired.Name = "chkAllSecRequired"
        Me.chkAllSecRequired.Size = New System.Drawing.Size(99, 17)
        Me.chkAllSecRequired.TabIndex = 113
        Me.chkAllSecRequired.Text = "AllSecRequired"
        Me.chkAllSecRequired.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(98, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "AllSecRequired"
        '
        'txtAL
        '
        Me.txtAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAL.Location = New System.Drawing.Point(3, 15)
        Me.txtAL.Name = "txtAL"
        Me.txtAL.Size = New System.Drawing.Size(32, 20)
        Me.txtAL.TabIndex = 116
        '
        'txtRBD
        '
        Me.txtRBD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRBD.Location = New System.Drawing.Point(57, 16)
        Me.txtRBD.Name = "txtRBD"
        Me.txtRBD.Size = New System.Drawing.Size(27, 20)
        Me.txtRBD.TabIndex = 117
        '
        'lbkApply
        '
        Me.lbkApply.AutoSize = True
        Me.lbkApply.Location = New System.Drawing.Point(0, 239)
        Me.lbkApply.Name = "lbkApply"
        Me.lbkApply.Size = New System.Drawing.Size(33, 13)
        Me.lbkApply.TabIndex = 118
        Me.lbkApply.TabStop = True
        Me.lbkApply.Text = "Apply"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(292, 19)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 119
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OK", "XX"})
        Me.cboStatus.Location = New System.Drawing.Point(538, 15)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(47, 21)
        Me.cboStatus.TabIndex = 120
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(535, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "FilterByStatus"
        '
        'frmDefineGrpTkt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 261)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkApply)
        Me.Controls.Add(Me.txtRBD)
        Me.Controls.Add(Me.txtAL)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkAllSecRequired)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbkUpdate)
        Me.Controls.Add(Me.lbkAdd)
        Me.Controls.Add(Me.dgrGrpDefinition)
        Me.Name = "frmDefineGrpTkt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DefineGrpTkt"
        CType(Me.dgrGrpDefinition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgrGrpDefinition As DataGridView
    Friend WithEvents lbkUpdate As LinkLabel
    Friend WithEvents lbkAdd As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents chkAllSecRequired As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAL As TextBox
    Friend WithEvents txtRBD As TextBox
    Friend WithEvents lbkApply As LinkLabel
    Friend WithEvents lbkDelete As LinkLabel
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label4 As Label
End Class
