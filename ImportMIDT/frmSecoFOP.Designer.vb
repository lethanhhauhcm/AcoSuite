<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecoFOP
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
        Me.lbkClear = New System.Windows.Forms.LinkLabel()
        Me.lbkSearch = New System.Windows.Forms.LinkLabel()
        Me.cboPIC = New System.Windows.Forms.ComboBox()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgCustomers = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDateType = New System.Windows.Forms.ComboBox()
        Me.dtpValidity = New System.Windows.Forms.DateTimePicker()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.chkSecoOfferExist = New System.Windows.Forms.CheckBox()
        Me.cboFOP = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.cboNewShortName = New System.Windows.Forms.ComboBox()
        Me.cboNewFOP = New System.Windows.Forms.ComboBox()
        Me.dtpNewFromDate = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbkClear
        '
        Me.lbkClear.AutoSize = True
        Me.lbkClear.Location = New System.Drawing.Point(923, 35)
        Me.lbkClear.Name = "lbkClear"
        Me.lbkClear.Size = New System.Drawing.Size(31, 13)
        Me.lbkClear.TabIndex = 160
        Me.lbkClear.TabStop = True
        Me.lbkClear.Text = "Clear"
        '
        'lbkSearch
        '
        Me.lbkSearch.AutoSize = True
        Me.lbkSearch.Location = New System.Drawing.Point(923, 18)
        Me.lbkSearch.Name = "lbkSearch"
        Me.lbkSearch.Size = New System.Drawing.Size(41, 13)
        Me.lbkSearch.TabIndex = 159
        Me.lbkSearch.TabStop = True
        Me.lbkSearch.Text = "Search"
        '
        'cboPIC
        '
        Me.cboPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPIC.FormattingEnabled = True
        Me.cboPIC.Location = New System.Drawing.Point(77, 27)
        Me.cboPIC.Name = "cboPIC"
        Me.cboPIC.Size = New System.Drawing.Size(120, 21)
        Me.cboPIC.TabIndex = 155
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Items.AddRange(New Object() {"South", "North"})
        Me.cboRegion.Location = New System.Drawing.Point(12, 27)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(59, 21)
        Me.cboRegion.TabIndex = 154
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 158
        Me.Label3.Text = "Region"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "PIC"
        '
        'dgCustomers
        '
        Me.dgCustomers.AllowUserToAddRows = False
        Me.dgCustomers.AllowUserToDeleteRows = False
        Me.dgCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomers.Location = New System.Drawing.Point(7, 57)
        Me.dgCustomers.Name = "dgCustomers"
        Me.dgCustomers.ReadOnly = True
        Me.dgCustomers.Size = New System.Drawing.Size(995, 469)
        Me.dgCustomers.TabIndex = 156
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(469, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Valid"
        '
        'cboDateType
        '
        Me.cboDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDateType.FormattingEnabled = True
        Me.cboDateType.Items.AddRange(New Object() {"OnDate", "FromDate", "ToDate"})
        Me.cboDateType.Location = New System.Drawing.Point(472, 27)
        Me.cboDateType.Name = "cboDateType"
        Me.cboDateType.Size = New System.Drawing.Size(94, 21)
        Me.cboDateType.TabIndex = 162
        '
        'dtpValidity
        '
        Me.dtpValidity.CustomFormat = "dd MMM yy"
        Me.dtpValidity.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpValidity.Location = New System.Drawing.Point(572, 28)
        Me.dtpValidity.Name = "dtpValidity"
        Me.dtpValidity.Size = New System.Drawing.Size(86, 20)
        Me.dtpValidity.TabIndex = 163
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(9, 539)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 164
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'chkSecoOfferExist
        '
        Me.chkSecoOfferExist.AutoSize = True
        Me.chkSecoOfferExist.Location = New System.Drawing.Point(676, 30)
        Me.chkSecoOfferExist.Name = "chkSecoOfferExist"
        Me.chkSecoOfferExist.Size = New System.Drawing.Size(96, 17)
        Me.chkSecoOfferExist.TabIndex = 167
        Me.chkSecoOfferExist.Text = "SecoOfferExist"
        Me.chkSecoOfferExist.ThreeState = True
        Me.chkSecoOfferExist.UseVisualStyleBackColor = True
        '
        'cboFOP
        '
        Me.cboFOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOP.FormattingEnabled = True
        Me.cboFOP.Items.AddRange(New Object() {"DeductIncentive", "DirectPayment"})
        Me.cboFOP.Location = New System.Drawing.Point(346, 27)
        Me.cboFOP.Name = "cboFOP"
        Me.cboFOP.Size = New System.Drawing.Size(120, 21)
        Me.cboFOP.TabIndex = 168
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(343, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 169
        Me.Label4.Text = "FOP"
        '
        'cboShortName
        '
        Me.cboShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(203, 26)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(137, 21)
        Me.cboShortName.TabIndex = 170
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(200, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "ShortName"
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(722, 544)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 172
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'cboNewShortName
        '
        Me.cboNewShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewShortName.FormattingEnabled = True
        Me.cboNewShortName.Location = New System.Drawing.Point(282, 536)
        Me.cboNewShortName.Name = "cboNewShortName"
        Me.cboNewShortName.Size = New System.Drawing.Size(137, 21)
        Me.cboNewShortName.TabIndex = 174
        '
        'cboNewFOP
        '
        Me.cboNewFOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewFOP.FormattingEnabled = True
        Me.cboNewFOP.Items.AddRange(New Object() {"DeductIncentive", "DirectPayment"})
        Me.cboNewFOP.Location = New System.Drawing.Point(425, 537)
        Me.cboNewFOP.Name = "cboNewFOP"
        Me.cboNewFOP.Size = New System.Drawing.Size(120, 21)
        Me.cboNewFOP.TabIndex = 173
        '
        'dtpNewFromDate
        '
        Me.dtpNewFromDate.CustomFormat = "dd MMM yy"
        Me.dtpNewFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNewFromDate.Location = New System.Drawing.Point(551, 539)
        Me.dtpNewFromDate.Name = "dtpNewFromDate"
        Me.dtpNewFromDate.Size = New System.Drawing.Size(86, 20)
        Me.dtpNewFromDate.TabIndex = 175
        '
        'frmSecoFOP
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
        Me.Controls.Add(Me.chkSecoOfferExist)
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
        Me.Name = "frmSecoFOP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SecoFOP"
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbkClear As LinkLabel
    Friend WithEvents lbkSearch As LinkLabel
    Friend WithEvents cboPIC As ComboBox
    Friend WithEvents cboRegion As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgCustomers As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cboDateType As ComboBox
    Friend WithEvents dtpValidity As DateTimePicker
    Friend WithEvents lbkDelete As LinkLabel
    Friend WithEvents chkSecoOfferExist As CheckBox
    Friend WithEvents cboFOP As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboShortName As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lbkAdd As LinkLabel
    Friend WithEvents cboNewShortName As ComboBox
    Friend WithEvents cboNewFOP As ComboBox
    Friend WithEvents dtpNewFromDate As DateTimePicker
End Class
