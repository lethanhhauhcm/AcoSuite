<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentiveFOP
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
        Me.dtpNewFromDate = New System.Windows.Forms.DateTimePicker()
        Me.cboNewShortName = New System.Windows.Forms.ComboBox()
        Me.cboNewFOP = New System.Windows.Forms.ComboBox()
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFOP = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.dtpValidity = New System.Windows.Forms.DateTimePicker()
        Me.cboDateType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbkClear = New System.Windows.Forms.LinkLabel()
        Me.lbkSearch = New System.Windows.Forms.LinkLabel()
        Me.cboPIC = New System.Windows.Forms.ComboBox()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgCustomers = New System.Windows.Forms.DataGridView()
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpNewFromDate
        '
        Me.dtpNewFromDate.CustomFormat = "dd MMM yy"
        Me.dtpNewFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNewFromDate.Location = New System.Drawing.Point(551, 535)
        Me.dtpNewFromDate.Name = "dtpNewFromDate"
        Me.dtpNewFromDate.Size = New System.Drawing.Size(86, 20)
        Me.dtpNewFromDate.TabIndex = 195
        '
        'cboNewShortName
        '
        Me.cboNewShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewShortName.FormattingEnabled = True
        Me.cboNewShortName.Location = New System.Drawing.Point(282, 532)
        Me.cboNewShortName.Name = "cboNewShortName"
        Me.cboNewShortName.Size = New System.Drawing.Size(137, 21)
        Me.cboNewShortName.TabIndex = 194
        '
        'cboNewFOP
        '
        Me.cboNewFOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewFOP.FormattingEnabled = True
        Me.cboNewFOP.Items.AddRange(New Object() {"CSH", "DEP", "BTF", "BLC"})
        Me.cboNewFOP.Location = New System.Drawing.Point(425, 533)
        Me.cboNewFOP.Name = "cboNewFOP"
        Me.cboNewFOP.Size = New System.Drawing.Size(120, 21)
        Me.cboNewFOP.TabIndex = 193
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(722, 540)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 192
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'cboShortName
        '
        Me.cboShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(203, 22)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(137, 21)
        Me.cboShortName.TabIndex = 190
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(200, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 191
        Me.Label5.Text = "ShortName"
        '
        'cboFOP
        '
        Me.cboFOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOP.FormattingEnabled = True
        Me.cboFOP.Items.AddRange(New Object() {"CSH", "DEP", "BTF", "BLC"})
        Me.cboFOP.Location = New System.Drawing.Point(346, 23)
        Me.cboFOP.Name = "cboFOP"
        Me.cboFOP.Size = New System.Drawing.Size(120, 21)
        Me.cboFOP.TabIndex = 188
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(343, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 189
        Me.Label4.Text = "FOP"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(9, 535)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 186
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'dtpValidity
        '
        Me.dtpValidity.CustomFormat = "dd MMM yy"
        Me.dtpValidity.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpValidity.Location = New System.Drawing.Point(572, 24)
        Me.dtpValidity.Name = "dtpValidity"
        Me.dtpValidity.Size = New System.Drawing.Size(86, 20)
        Me.dtpValidity.TabIndex = 185
        '
        'cboDateType
        '
        Me.cboDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDateType.FormattingEnabled = True
        Me.cboDateType.Items.AddRange(New Object() {"OnDate", "FromDate", "ToDate"})
        Me.cboDateType.Location = New System.Drawing.Point(472, 23)
        Me.cboDateType.Name = "cboDateType"
        Me.cboDateType.Size = New System.Drawing.Size(94, 21)
        Me.cboDateType.TabIndex = 184
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(469, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 183
        Me.Label2.Text = "Valid"
        '
        'lbkClear
        '
        Me.lbkClear.AutoSize = True
        Me.lbkClear.Location = New System.Drawing.Point(923, 31)
        Me.lbkClear.Name = "lbkClear"
        Me.lbkClear.Size = New System.Drawing.Size(31, 13)
        Me.lbkClear.TabIndex = 182
        Me.lbkClear.TabStop = True
        Me.lbkClear.Text = "Clear"
        '
        'lbkSearch
        '
        Me.lbkSearch.AutoSize = True
        Me.lbkSearch.Location = New System.Drawing.Point(923, 14)
        Me.lbkSearch.Name = "lbkSearch"
        Me.lbkSearch.Size = New System.Drawing.Size(41, 13)
        Me.lbkSearch.TabIndex = 181
        Me.lbkSearch.TabStop = True
        Me.lbkSearch.Text = "Search"
        '
        'cboPIC
        '
        Me.cboPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPIC.FormattingEnabled = True
        Me.cboPIC.Location = New System.Drawing.Point(77, 23)
        Me.cboPIC.Name = "cboPIC"
        Me.cboPIC.Size = New System.Drawing.Size(120, 21)
        Me.cboPIC.TabIndex = 177
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Items.AddRange(New Object() {"South", "North"})
        Me.cboRegion.Location = New System.Drawing.Point(12, 23)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(59, 21)
        Me.cboRegion.TabIndex = 176
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Region"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "PIC"
        '
        'dgCustomers
        '
        Me.dgCustomers.AllowUserToAddRows = False
        Me.dgCustomers.AllowUserToDeleteRows = False
        Me.dgCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomers.Location = New System.Drawing.Point(7, 53)
        Me.dgCustomers.Name = "dgCustomers"
        Me.dgCustomers.ReadOnly = True
        Me.dgCustomers.Size = New System.Drawing.Size(995, 469)
        Me.dgCustomers.TabIndex = 178
        '
        'frmIncentiveFOP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.dtpNewFromDate)
        Me.Controls.Add(Me.cboNewShortName)
        Me.Controls.Add(Me.cboNewFOP)
        Me.Controls.Add(Me.lbkAdd)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboFOP)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.dtpValidity)
        Me.Controls.Add(Me.cboDateType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbkClear)
        Me.Controls.Add(Me.lbkSearch)
        Me.Controls.Add(Me.cboPIC)
        Me.Controls.Add(Me.cboRegion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgCustomers)
        Me.Name = "frmIncentiveFOP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IncentiveFOP"
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpNewFromDate As DateTimePicker
    Friend WithEvents cboNewShortName As ComboBox
    Friend WithEvents cboNewFOP As ComboBox
    Friend WithEvents lbkAdd As LinkLabel
    Friend WithEvents cboShortName As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboFOP As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lbkDelete As LinkLabel
    Friend WithEvents dtpValidity As DateTimePicker
    Friend WithEvents cboDateType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lbkClear As LinkLabel
    Friend WithEvents lbkSearch As LinkLabel
    Friend WithEvents cboPIC As ComboBox
    Friend WithEvents cboRegion As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgCustomers As DataGridView
End Class
