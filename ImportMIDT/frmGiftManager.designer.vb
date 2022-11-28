<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGiftManager
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
        Me.GridGift = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.ChkALLACO = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtImage = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtPoint = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtValid = New System.Windows.Forms.DateTimePicker
        Me.CmdBrowse = New System.Windows.Forms.Button
        Me.LblUpdate = New System.Windows.Forms.LinkLabel
        Me.LblDelete = New System.Windows.Forms.LinkLabel
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.PictBox = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtStock = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtPrice = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtRMK = New System.Windows.Forms.TextBox
        Me.CmbCat = New System.Windows.Forms.ComboBox
        Me.TxtMota = New System.Windows.Forms.RichTextBox
        CType(Me.GridGift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridGift
        '
        Me.GridGift.AllowUserToAddRows = False
        Me.GridGift.AllowUserToDeleteRows = False
        Me.GridGift.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.GridGift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridGift.Location = New System.Drawing.Point(3, 115)
        Me.GridGift.Name = "GridGift"
        Me.GridGift.RowHeadersVisible = False
        Me.GridGift.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridGift.Size = New System.Drawing.Size(509, 355)
        Me.GridGift.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CAT/Name"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(152, 6)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(113, 20)
        Me.TxtName.TabIndex = 2
        '
        'ChkALLACO
        '
        Me.ChkALLACO.AutoSize = True
        Me.ChkALLACO.Location = New System.Drawing.Point(482, 78)
        Me.ChkALLACO.Name = "ChkALLACO"
        Me.ChkALLACO.Size = New System.Drawing.Size(110, 17)
        Me.ChkALLACO.TabIndex = 3
        Me.ChkALLACO.Text = "AvailCountryWide"
        Me.ChkALLACO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(443, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Picture"
        '
        'TxtImage
        '
        Me.TxtImage.Enabled = False
        Me.TxtImage.Location = New System.Drawing.Point(482, 52)
        Me.TxtImage.Name = "TxtImage"
        Me.TxtImage.Size = New System.Drawing.Size(270, 20)
        Me.TxtImage.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(267, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Point RQ"
        '
        'TxtPoint
        '
        Me.TxtPoint.Location = New System.Drawing.Point(317, 6)
        Me.TxtPoint.Name = "TxtPoint"
        Me.TxtPoint.Size = New System.Drawing.Size(39, 20)
        Me.TxtPoint.TabIndex = 2
        Me.TxtPoint.Text = "9000"
        Me.TxtPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(552, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "ValidThru"
        '
        'TxtValid
        '
        Me.TxtValid.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtValid.Location = New System.Drawing.Point(606, 6)
        Me.TxtValid.Name = "TxtValid"
        Me.TxtValid.Size = New System.Drawing.Size(87, 20)
        Me.TxtValid.TabIndex = 4
        '
        'CmdBrowse
        '
        Me.CmdBrowse.Location = New System.Drawing.Point(754, 50)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(24, 23)
        Me.CmdBrowse.TabIndex = 5
        Me.CmdBrowse.Text = "..."
        Me.CmdBrowse.UseVisualStyleBackColor = True
        '
        'LblUpdate
        '
        Me.LblUpdate.AutoSize = True
        Me.LblUpdate.Location = New System.Drawing.Point(644, 79)
        Me.LblUpdate.Name = "LblUpdate"
        Me.LblUpdate.Size = New System.Drawing.Size(42, 13)
        Me.LblUpdate.TabIndex = 6
        Me.LblUpdate.TabStop = True
        Me.LblUpdate.Text = "Update"
        '
        'LblDelete
        '
        Me.LblDelete.AutoSize = True
        Me.LblDelete.Location = New System.Drawing.Point(3, 477)
        Me.LblDelete.Name = "LblDelete"
        Me.LblDelete.Size = New System.Drawing.Size(38, 13)
        Me.LblDelete.TabIndex = 6
        Me.LblDelete.TabStop = True
        Me.LblDelete.Text = "Delete"
        Me.LblDelete.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PictBox
        '
        Me.PictBox.Location = New System.Drawing.Point(518, 115)
        Me.PictBox.Name = "PictBox"
        Me.PictBox.Size = New System.Drawing.Size(260, 201)
        Me.PictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictBox.TabIndex = 7
        Me.PictBox.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(361, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Stock"
        '
        'TxtStock
        '
        Me.TxtStock.Location = New System.Drawing.Point(398, 6)
        Me.TxtStock.Name = "TxtStock"
        Me.TxtStock.Size = New System.Drawing.Size(46, 20)
        Me.TxtStock.TabIndex = 2
        Me.TxtStock.Text = "1"
        Me.TxtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(443, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Price"
        '
        'TxtPrice
        '
        Me.TxtPrice.Location = New System.Drawing.Point(482, 6)
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Size = New System.Drawing.Size(64, 20)
        Me.TxtPrice.TabIndex = 2
        Me.TxtPrice.Text = "0"
        Me.TxtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(443, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "RMK"
        '
        'TxtRMK
        '
        Me.TxtRMK.Location = New System.Drawing.Point(483, 30)
        Me.TxtRMK.Name = "TxtRMK"
        Me.TxtRMK.Size = New System.Drawing.Size(295, 20)
        Me.TxtRMK.TabIndex = 2
        '
        'CmbCat
        '
        Me.CmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCat.FormattingEnabled = True
        Me.CmbCat.Location = New System.Drawing.Point(67, 6)
        Me.CmbCat.Name = "CmbCat"
        Me.CmbCat.Size = New System.Drawing.Size(82, 21)
        Me.CmbCat.TabIndex = 8
        '
        'TxtMota
        '
        Me.TxtMota.Location = New System.Drawing.Point(67, 32)
        Me.TxtMota.Name = "TxtMota"
        Me.TxtMota.Size = New System.Drawing.Size(377, 77)
        Me.TxtMota.TabIndex = 9
        Me.TxtMota.Text = ""
        '
        'GiftManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 496)
        Me.Controls.Add(Me.TxtMota)
        Me.Controls.Add(Me.CmbCat)
        Me.Controls.Add(Me.PictBox)
        Me.Controls.Add(Me.LblDelete)
        Me.Controls.Add(Me.LblUpdate)
        Me.Controls.Add(Me.CmdBrowse)
        Me.Controls.Add(Me.TxtValid)
        Me.Controls.Add(Me.ChkALLACO)
        Me.Controls.Add(Me.TxtImage)
        Me.Controls.Add(Me.TxtRMK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtPrice)
        Me.Controls.Add(Me.TxtStock)
        Me.Controls.Add(Me.TxtPoint)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridGift)
        Me.Location = New System.Drawing.Point(0, 50)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GiftManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Reward :. Gift Manager"
        CType(Me.GridGift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridGift As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents ChkALLACO As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtImage As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtValid As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents LblUpdate As System.Windows.Forms.LinkLabel
    Friend WithEvents LblDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtStock As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtRMK As System.Windows.Forms.TextBox
    Friend WithEvents CmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMota As System.Windows.Forms.RichTextBox
End Class
