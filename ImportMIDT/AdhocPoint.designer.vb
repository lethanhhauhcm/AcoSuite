<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdhocPoint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtEmail = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblSeacrch = New System.Windows.Forms.LinkLabel
        Me.GridPoint = New System.Windows.Forms.DataGridView
        Me.GridInfor = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPoint = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRMK = New System.Windows.Forms.TextBox
        Me.LblAdd = New System.Windows.Forms.LinkLabel
        Me.LblDelete = New System.Windows.Forms.LinkLabel
        Me.LblChangeStar = New System.Windows.Forms.LinkLabel
        Me.CmbStar = New System.Windows.Forms.ComboBox
        Me.txtBookDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbCat = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.GridPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridInfor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(42, 3)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(348, 20)
        Me.TxtEmail.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "eMail"
        '
        'LblSeacrch
        '
        Me.LblSeacrch.AutoSize = True
        Me.LblSeacrch.Location = New System.Drawing.Point(396, 6)
        Me.LblSeacrch.Name = "LblSeacrch"
        Me.LblSeacrch.Size = New System.Drawing.Size(41, 13)
        Me.LblSeacrch.TabIndex = 6
        Me.LblSeacrch.TabStop = True
        Me.LblSeacrch.Text = "Search"
        '
        'GridPoint
        '
        Me.GridPoint.AllowUserToAddRows = False
        Me.GridPoint.AllowUserToDeleteRows = False
        Me.GridPoint.BackgroundColor = System.Drawing.Color.DodgerBlue
        Me.GridPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPoint.Location = New System.Drawing.Point(0, 119)
        Me.GridPoint.Name = "GridPoint"
        Me.GridPoint.RowHeadersVisible = False
        Me.GridPoint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridPoint.Size = New System.Drawing.Size(780, 347)
        Me.GridPoint.TabIndex = 7
        '
        'GridInfor
        '
        Me.GridInfor.AllowUserToAddRows = False
        Me.GridInfor.AllowUserToDeleteRows = False
        Me.GridInfor.BackgroundColor = System.Drawing.Color.LightSkyBlue
        Me.GridInfor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridInfor.Location = New System.Drawing.Point(0, 49)
        Me.GridInfor.Name = "GridInfor"
        Me.GridInfor.RowHeadersVisible = False
        Me.GridInfor.Size = New System.Drawing.Size(780, 69)
        Me.GridInfor.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Point"
        '
        'TxtPoint
        '
        Me.TxtPoint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPoint.Location = New System.Drawing.Point(42, 26)
        Me.TxtPoint.Name = "TxtPoint"
        Me.TxtPoint.Size = New System.Drawing.Size(50, 20)
        Me.TxtPoint.TabIndex = 5
        Me.TxtPoint.Text = "0"
        Me.TxtPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(349, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Remark"
        '
        'txtRMK
        '
        Me.txtRMK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRMK.Location = New System.Drawing.Point(399, 26)
        Me.txtRMK.Name = "txtRMK"
        Me.txtRMK.Size = New System.Drawing.Size(251, 20)
        Me.txtRMK.TabIndex = 5
        '
        'LblAdd
        '
        Me.LblAdd.AutoSize = True
        Me.LblAdd.Enabled = False
        Me.LblAdd.Location = New System.Drawing.Point(656, 29)
        Me.LblAdd.Name = "LblAdd"
        Me.LblAdd.Size = New System.Drawing.Size(26, 13)
        Me.LblAdd.TabIndex = 6
        Me.LblAdd.TabStop = True
        Me.LblAdd.Text = "Add"
        '
        'LblDelete
        '
        Me.LblDelete.AutoSize = True
        Me.LblDelete.Location = New System.Drawing.Point(4, 475)
        Me.LblDelete.Name = "LblDelete"
        Me.LblDelete.Size = New System.Drawing.Size(38, 13)
        Me.LblDelete.TabIndex = 6
        Me.LblDelete.TabStop = True
        Me.LblDelete.Text = "Delete"
        Me.LblDelete.Visible = False
        '
        'LblChangeStar
        '
        Me.LblChangeStar.AutoSize = True
        Me.LblChangeStar.Location = New System.Drawing.Point(712, 475)
        Me.LblChangeStar.Name = "LblChangeStar"
        Me.LblChangeStar.Size = New System.Drawing.Size(63, 13)
        Me.LblChangeStar.TabIndex = 8
        Me.LblChangeStar.TabStop = True
        Me.LblChangeStar.Text = "ChangeStar"
        '
        'CmbStar
        '
        Me.CmbStar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStar.FormattingEnabled = True
        Me.CmbStar.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.CmbStar.Location = New System.Drawing.Point(668, 472)
        Me.CmbStar.Name = "CmbStar"
        Me.CmbStar.Size = New System.Drawing.Size(38, 21)
        Me.CmbStar.TabIndex = 9
        '
        'txtBookDate
        '
        Me.txtBookDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtBookDate.Location = New System.Drawing.Point(134, 26)
        Me.txtBookDate.Name = "txtBookDate"
        Me.txtBookDate.Size = New System.Drawing.Size(89, 20)
        Me.txtBookDate.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(98, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Date"
        '
        'CmbCat
        '
        Me.CmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCat.FormattingEnabled = True
        Me.CmbCat.Location = New System.Drawing.Point(258, 25)
        Me.CmbCat.Name = "CmbCat"
        Me.CmbCat.Size = New System.Drawing.Size(83, 21)
        Me.CmbCat.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(229, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Cat"
        '
        'AdhocPoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 496)
        Me.Controls.Add(Me.CmbCat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBookDate)
        Me.Controls.Add(Me.CmbStar)
        Me.Controls.Add(Me.LblChangeStar)
        Me.Controls.Add(Me.GridInfor)
        Me.Controls.Add(Me.GridPoint)
        Me.Controls.Add(Me.LblDelete)
        Me.Controls.Add(Me.LblAdd)
        Me.Controls.Add(Me.LblSeacrch)
        Me.Controls.Add(Me.txtRMK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPoint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.Label7)
        Me.Location = New System.Drawing.Point(0, 50)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdhocPoint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Reward :. Adhoc Point Updater"
        CType(Me.GridPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridInfor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblSeacrch As System.Windows.Forms.LinkLabel
    Friend WithEvents GridPoint As System.Windows.Forms.DataGridView
    Friend WithEvents GridInfor As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRMK As System.Windows.Forms.TextBox
    Friend WithEvents LblAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents LblDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents LblChangeStar As System.Windows.Forms.LinkLabel
    Friend WithEvents CmbStar As System.Windows.Forms.ComboBox
    Friend WithEvents txtBookDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
