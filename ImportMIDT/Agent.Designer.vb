<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Agent
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtShortName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtFullName = New System.Windows.Forms.TextBox
        Me.LblAdd = New System.Windows.Forms.LinkLabel
        Me.GridAgent = New System.Windows.Forms.DataGridView
        Me.LstOID = New System.Windows.Forms.CheckedListBox
        Me.LblSave = New System.Windows.Forms.LinkLabel
        Me.LblDelete = New System.Windows.Forms.LinkLabel
        Me.LblAssign = New System.Windows.Forms.LinkLabel
        Me.LblShowUnAssign = New System.Windows.Forms.LinkLabel
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPIC = New System.Windows.Forms.TextBox
        Me.TxtOID = New System.Windows.Forms.TextBox
        Me.LblSearch = New System.Windows.Forms.LinkLabel
        Me.LblFilter = New System.Windows.Forms.LinkLabel
        Me.txtOIDtoAdd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.GridAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ShortName"
        '
        'TxtShortName
        '
        Me.TxtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtShortName.Location = New System.Drawing.Point(60, 6)
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(91, 20)
        Me.TxtShortName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "FullName"
        '
        'TxtFullName
        '
        Me.TxtFullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFullName.Location = New System.Drawing.Point(206, 6)
        Me.TxtFullName.Name = "TxtFullName"
        Me.TxtFullName.Size = New System.Drawing.Size(252, 20)
        Me.TxtFullName.TabIndex = 1
        '
        'LblAdd
        '
        Me.LblAdd.AutoSize = True
        Me.LblAdd.Enabled = False
        Me.LblAdd.Location = New System.Drawing.Point(653, 9)
        Me.LblAdd.Name = "LblAdd"
        Me.LblAdd.Size = New System.Drawing.Size(26, 13)
        Me.LblAdd.TabIndex = 2
        Me.LblAdd.TabStop = True
        Me.LblAdd.Text = "Add"
        '
        'GridAgent
        '
        Me.GridAgent.BackgroundColor = System.Drawing.Color.Azure
        Me.GridAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAgent.Location = New System.Drawing.Point(4, 32)
        Me.GridAgent.Name = "GridAgent"
        Me.GridAgent.ReadOnly = True
        Me.GridAgent.RowHeadersVisible = False
        Me.GridAgent.Size = New System.Drawing.Size(550, 439)
        Me.GridAgent.TabIndex = 3
        '
        'LstOID
        '
        Me.LstOID.FormattingEnabled = True
        Me.LstOID.Location = New System.Drawing.Point(558, 32)
        Me.LstOID.Name = "LstOID"
        Me.LstOID.Size = New System.Drawing.Size(222, 439)
        Me.LstOID.TabIndex = 4
        '
        'LblSave
        '
        Me.LblSave.AutoSize = True
        Me.LblSave.Enabled = False
        Me.LblSave.Location = New System.Drawing.Point(685, 9)
        Me.LblSave.Name = "LblSave"
        Me.LblSave.Size = New System.Drawing.Size(32, 13)
        Me.LblSave.TabIndex = 5
        Me.LblSave.TabStop = True
        Me.LblSave.Text = "Save"
        '
        'LblDelete
        '
        Me.LblDelete.AutoSize = True
        Me.LblDelete.Enabled = False
        Me.LblDelete.Location = New System.Drawing.Point(1, 474)
        Me.LblDelete.Name = "LblDelete"
        Me.LblDelete.Size = New System.Drawing.Size(38, 13)
        Me.LblDelete.TabIndex = 6
        Me.LblDelete.TabStop = True
        Me.LblDelete.Text = "Delete"
        '
        'LblAssign
        '
        Me.LblAssign.AutoSize = True
        Me.LblAssign.Enabled = False
        Me.LblAssign.Location = New System.Drawing.Point(555, 474)
        Me.LblAssign.Name = "LblAssign"
        Me.LblAssign.Size = New System.Drawing.Size(38, 13)
        Me.LblAssign.TabIndex = 7
        Me.LblAssign.TabStop = True
        Me.LblAssign.Text = "Assign"
        '
        'LblShowUnAssign
        '
        Me.LblShowUnAssign.AutoSize = True
        Me.LblShowUnAssign.Location = New System.Drawing.Point(679, 474)
        Me.LblShowUnAssign.Name = "LblShowUnAssign"
        Me.LblShowUnAssign.Size = New System.Drawing.Size(101, 13)
        Me.LblShowUnAssign.TabIndex = 8
        Me.LblShowUnAssign.TabStop = True
        Me.LblShowUnAssign.Text = "ShowUnAssign OID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(461, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "PIC"
        '
        'TxtPIC
        '
        Me.TxtPIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPIC.Location = New System.Drawing.Point(487, 6)
        Me.TxtPIC.Name = "TxtPIC"
        Me.TxtPIC.Size = New System.Drawing.Size(38, 20)
        Me.TxtPIC.TabIndex = 10
        '
        'TxtOID
        '
        Me.TxtOID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOID.Location = New System.Drawing.Point(60, 472)
        Me.TxtOID.Name = "TxtOID"
        Me.TxtOID.Size = New System.Drawing.Size(74, 20)
        Me.TxtOID.TabIndex = 11
        '
        'LblSearch
        '
        Me.LblSearch.AutoSize = True
        Me.LblSearch.Location = New System.Drawing.Point(219, 474)
        Me.LblSearch.Name = "LblSearch"
        Me.LblSearch.Size = New System.Drawing.Size(72, 13)
        Me.LblSearch.TabIndex = 12
        Me.LblSearch.TabStop = True
        Me.LblSearch.Text = "SearchByOID"
        '
        'LblFilter
        '
        Me.LblFilter.AutoSize = True
        Me.LblFilter.Location = New System.Drawing.Point(174, 474)
        Me.LblFilter.Name = "LblFilter"
        Me.LblFilter.Size = New System.Drawing.Size(29, 13)
        Me.LblFilter.TabIndex = 14
        Me.LblFilter.TabStop = True
        Me.LblFilter.Text = "Filter"
        '
        'txtOIDtoAdd
        '
        Me.txtOIDtoAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOIDtoAdd.Enabled = False
        Me.txtOIDtoAdd.Location = New System.Drawing.Point(558, 6)
        Me.txtOIDtoAdd.Name = "txtOIDtoAdd"
        Me.txtOIDtoAdd.Size = New System.Drawing.Size(89, 20)
        Me.txtOIDtoAdd.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(528, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "OID"
        '
        'Agent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 496)
        Me.Controls.Add(Me.txtOIDtoAdd)
        Me.Controls.Add(Me.LblFilter)
        Me.Controls.Add(Me.LblSearch)
        Me.Controls.Add(Me.TxtOID)
        Me.Controls.Add(Me.TxtPIC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblShowUnAssign)
        Me.Controls.Add(Me.LblAssign)
        Me.Controls.Add(Me.LblDelete)
        Me.Controls.Add(Me.LblSave)
        Me.Controls.Add(Me.LstOID)
        Me.Controls.Add(Me.GridAgent)
        Me.Controls.Add(Me.LblAdd)
        Me.Controls.Add(Me.TxtFullName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtShortName)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Agent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Customer Update"
        CType(Me.GridAgent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtShortName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtFullName As System.Windows.Forms.TextBox
    Friend WithEvents LblAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents GridAgent As System.Windows.Forms.DataGridView
    Friend WithEvents LstOID As System.Windows.Forms.CheckedListBox
    Friend WithEvents LblSave As System.Windows.Forms.LinkLabel
    Friend WithEvents LblDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents LblAssign As System.Windows.Forms.LinkLabel
    Friend WithEvents LblShowUnAssign As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPIC As System.Windows.Forms.TextBox
    Friend WithEvents TxtOID As System.Windows.Forms.TextBox
    Friend WithEvents LblSearch As System.Windows.Forms.LinkLabel
    Friend WithEvents LblFilter As System.Windows.Forms.LinkLabel
    Friend WithEvents txtOIDtoAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
