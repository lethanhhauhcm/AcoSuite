<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MIDTData
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lnkGDS = New System.Windows.Forms.LinkLabel()
        Me.clbGDS = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.clbCity = New System.Windows.Forms.CheckedListBox()
        Me.lnkCity = New System.Windows.Forms.LinkLabel()
        Me.chkOther = New System.Windows.Forms.CheckBox()
        Me.chkSouth = New System.Windows.Forms.CheckBox()
        Me.chkNorth = New System.Windows.Forms.CheckBox()
        Me.cbxViewType = New System.Windows.Forms.ComboBox()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkExclUA = New System.Windows.Forms.CheckBox()
        Me.chkExcl1B = New System.Windows.Forms.CheckBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tpgAgents = New System.Windows.Forms.TabPage()
        Me.clbAgents = New System.Windows.Forms.CheckedListBox()
        Me.lnkAgents = New System.Windows.Forms.LinkLabel()
        Me.btnRetrieveAgents = New System.Windows.Forms.Button()
        Me.tpgAL = New System.Windows.Forms.TabPage()
        Me.lnkAirlines = New System.Windows.Forms.LinkLabel()
        Me.btnRetrieveAirlines = New System.Windows.Forms.Button()
        Me.clbAirlines = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.txtDest = New System.Windows.Forms.TextBox()
        Me.txtOrg = New System.Windows.Forms.TextBox()
        Me.btnDest = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnOrg = New System.Windows.Forms.Button()
        Me.clbCityOD = New System.Windows.Forms.CheckedListBox()
        Me.clbCountry = New System.Windows.Forms.CheckedListBox()
        Me.clbArea = New System.Windows.Forms.CheckedListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.clbCity1 = New System.Windows.Forms.CheckedListBox()
        Me.rdoOthers = New System.Windows.Forms.RadioButton()
        Me.rdoSouth = New System.Windows.Forms.RadioButton()
        Me.rdoNorth = New System.Windows.Forms.RadioButton()
        Me.dgrFields = New System.Windows.Forms.DataGridView()
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBy = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tpgAgents.SuspendLayout()
        Me.tpgAL.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgrFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(999, 622)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgrFields)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.cbxViewType)
        Me.TabPage3.Controls.Add(Me.btnRunReport)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.chkExclUA)
        Me.TabPage3.Controls.Add(Me.chkExcl1B)
        Me.TabPage3.Controls.Add(Me.dtpTo)
        Me.TabPage3.Controls.Add(Me.dtpFrom)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(991, 596)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "MIDT Report"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lnkGDS)
        Me.GroupBox1.Controls.Add(Me.clbGDS)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 38)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GDS"
        '
        'lnkGDS
        '
        Me.lnkGDS.AutoSize = True
        Me.lnkGDS.Location = New System.Drawing.Point(4, 16)
        Me.lnkGDS.Name = "lnkGDS"
        Me.lnkGDS.Size = New System.Drawing.Size(26, 13)
        Me.lnkGDS.TabIndex = 0
        Me.lnkGDS.TabStop = True
        Me.lnkGDS.Text = "ALL"
        '
        'clbGDS
        '
        Me.clbGDS.CheckOnClick = True
        Me.clbGDS.ColumnWidth = 35
        Me.clbGDS.FormattingEnabled = True
        Me.clbGDS.HorizontalScrollbar = True
        Me.clbGDS.Location = New System.Drawing.Point(64, 13)
        Me.clbGDS.MultiColumn = True
        Me.clbGDS.Name = "clbGDS"
        Me.clbGDS.Size = New System.Drawing.Size(274, 19)
        Me.clbGDS.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.clbCity)
        Me.GroupBox2.Controls.Add(Me.lnkCity)
        Me.GroupBox2.Controls.Add(Me.chkOther)
        Me.GroupBox2.Controls.Add(Me.chkSouth)
        Me.GroupBox2.Controls.Add(Me.chkNorth)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 172)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Area"
        '
        'clbCity
        '
        Me.clbCity.CheckOnClick = True
        Me.clbCity.ColumnWidth = 50
        Me.clbCity.FormattingEnabled = True
        Me.clbCity.Location = New System.Drawing.Point(64, 12)
        Me.clbCity.MultiColumn = True
        Me.clbCity.Name = "clbCity"
        Me.clbCity.Size = New System.Drawing.Size(274, 154)
        Me.clbCity.TabIndex = 4
        '
        'lnkCity
        '
        Me.lnkCity.AutoSize = True
        Me.lnkCity.Location = New System.Drawing.Point(4, 60)
        Me.lnkCity.Name = "lnkCity"
        Me.lnkCity.Size = New System.Drawing.Size(26, 13)
        Me.lnkCity.TabIndex = 3
        Me.lnkCity.TabStop = True
        Me.lnkCity.Text = "ALL"
        '
        'chkOther
        '
        Me.chkOther.AutoSize = True
        Me.chkOther.Location = New System.Drawing.Point(6, 43)
        Me.chkOther.Name = "chkOther"
        Me.chkOther.Size = New System.Drawing.Size(52, 17)
        Me.chkOther.TabIndex = 2
        Me.chkOther.Text = "Other"
        Me.chkOther.UseVisualStyleBackColor = True
        '
        'chkSouth
        '
        Me.chkSouth.AutoSize = True
        Me.chkSouth.Location = New System.Drawing.Point(6, 27)
        Me.chkSouth.Name = "chkSouth"
        Me.chkSouth.Size = New System.Drawing.Size(54, 17)
        Me.chkSouth.TabIndex = 1
        Me.chkSouth.Text = "South"
        Me.chkSouth.UseVisualStyleBackColor = True
        '
        'chkNorth
        '
        Me.chkNorth.AutoSize = True
        Me.chkNorth.Location = New System.Drawing.Point(6, 12)
        Me.chkNorth.Name = "chkNorth"
        Me.chkNorth.Size = New System.Drawing.Size(52, 17)
        Me.chkNorth.TabIndex = 0
        Me.chkNorth.Text = "North"
        Me.chkNorth.UseVisualStyleBackColor = True
        '
        'cbxViewType
        '
        Me.cbxViewType.FormattingEnabled = True
        Me.cbxViewType.Items.AddRange(New Object() {"This MTD", "This QTD", "This YTD", "Last Month", "Last Quarter", "Last Year", "Custome"})
        Me.cbxViewType.Location = New System.Drawing.Point(3, 3)
        Me.cbxViewType.Name = "cbxViewType"
        Me.cbxViewType.Size = New System.Drawing.Size(104, 21)
        Me.cbxViewType.TabIndex = 39
        '
        'btnRunReport
        '
        Me.btnRunReport.Location = New System.Drawing.Point(209, 25)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(75, 23)
        Me.btnRunReport.TabIndex = 38
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(108, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(2, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "From"
        '
        'chkExclUA
        '
        Me.chkExclUA.AutoSize = True
        Me.chkExclUA.Location = New System.Drawing.Point(209, 6)
        Me.chkExclUA.Name = "chkExclUA"
        Me.chkExclUA.Size = New System.Drawing.Size(98, 17)
        Me.chkExclUA.TabIndex = 37
        Me.chkExclUA.Text = "Excl. UA Office"
        Me.chkExclUA.UseVisualStyleBackColor = True
        '
        'chkExcl1B
        '
        Me.chkExcl1B.AutoSize = True
        Me.chkExcl1B.Location = New System.Drawing.Point(113, 6)
        Me.chkExcl1B.Name = "chkExcl1B"
        Me.chkExcl1B.Size = New System.Drawing.Size(101, 17)
        Me.chkExcl1B.TabIndex = 36
        Me.chkExcl1B.Text = "Excl. VN on 1B "
        Me.chkExcl1B.UseVisualStyleBackColor = True
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd-MMM-yy"
        Me.dtpTo.Enabled = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(129, 27)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(74, 20)
        Me.dtpTo.TabIndex = 35
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd-MMM-yy"
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(33, 27)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(74, 20)
        Me.dtpFrom.TabIndex = 33
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TabControl2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(991, 596)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Filter"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.tpgAgents)
        Me.TabControl2.Controls.Add(Me.tpgAL)
        Me.TabControl2.Location = New System.Drawing.Point(5, 6)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(992, 210)
        Me.TabControl2.TabIndex = 28
        '
        'tpgAgents
        '
        Me.tpgAgents.Controls.Add(Me.clbAgents)
        Me.tpgAgents.Controls.Add(Me.lnkAgents)
        Me.tpgAgents.Controls.Add(Me.btnRetrieveAgents)
        Me.tpgAgents.Location = New System.Drawing.Point(4, 22)
        Me.tpgAgents.Name = "tpgAgents"
        Me.tpgAgents.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAgents.Size = New System.Drawing.Size(984, 184)
        Me.tpgAgents.TabIndex = 0
        Me.tpgAgents.Text = "Agents"
        Me.tpgAgents.UseVisualStyleBackColor = True
        '
        'clbAgents
        '
        Me.clbAgents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbAgents.CheckOnClick = True
        Me.clbAgents.FormattingEnabled = True
        Me.clbAgents.Location = New System.Drawing.Point(0, 30)
        Me.clbAgents.MultiColumn = True
        Me.clbAgents.Name = "clbAgents"
        Me.clbAgents.Size = New System.Drawing.Size(984, 169)
        Me.clbAgents.TabIndex = 0
        '
        'lnkAgents
        '
        Me.lnkAgents.AutoSize = True
        Me.lnkAgents.Location = New System.Drawing.Point(106, 8)
        Me.lnkAgents.Name = "lnkAgents"
        Me.lnkAgents.Size = New System.Drawing.Size(54, 13)
        Me.lnkAgents.TabIndex = 29
        Me.lnkAgents.TabStop = True
        Me.lnkAgents.Text = "All Agents"
        '
        'btnRetrieveAgents
        '
        Me.btnRetrieveAgents.Location = New System.Drawing.Point(3, 4)
        Me.btnRetrieveAgents.Name = "btnRetrieveAgents"
        Me.btnRetrieveAgents.Size = New System.Drawing.Size(97, 23)
        Me.btnRetrieveAgents.TabIndex = 23
        Me.btnRetrieveAgents.Text = "Retrieve Agents"
        Me.btnRetrieveAgents.UseVisualStyleBackColor = True
        '
        'tpgAL
        '
        Me.tpgAL.Controls.Add(Me.lnkAirlines)
        Me.tpgAL.Controls.Add(Me.btnRetrieveAirlines)
        Me.tpgAL.Controls.Add(Me.clbAirlines)
        Me.tpgAL.Location = New System.Drawing.Point(4, 22)
        Me.tpgAL.Name = "tpgAL"
        Me.tpgAL.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAL.Size = New System.Drawing.Size(984, 184)
        Me.tpgAL.TabIndex = 1
        Me.tpgAL.Text = "Airlines"
        Me.tpgAL.UseVisualStyleBackColor = True
        '
        'lnkAirlines
        '
        Me.lnkAirlines.AutoSize = True
        Me.lnkAirlines.Location = New System.Drawing.Point(106, 8)
        Me.lnkAirlines.Name = "lnkAirlines"
        Me.lnkAirlines.Size = New System.Drawing.Size(54, 13)
        Me.lnkAirlines.TabIndex = 32
        Me.lnkAirlines.TabStop = True
        Me.lnkAirlines.Text = "All Airlines"
        '
        'btnRetrieveAirlines
        '
        Me.btnRetrieveAirlines.Location = New System.Drawing.Point(3, 3)
        Me.btnRetrieveAirlines.Name = "btnRetrieveAirlines"
        Me.btnRetrieveAirlines.Size = New System.Drawing.Size(97, 23)
        Me.btnRetrieveAirlines.TabIndex = 31
        Me.btnRetrieveAirlines.Text = "Retrieve Airlines"
        Me.btnRetrieveAirlines.UseVisualStyleBackColor = True
        '
        'clbAirlines
        '
        Me.clbAirlines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbAirlines.CheckOnClick = True
        Me.clbAirlines.ColumnWidth = 40
        Me.clbAirlines.FormattingEnabled = True
        Me.clbAirlines.Location = New System.Drawing.Point(0, 28)
        Me.clbAirlines.MultiColumn = True
        Me.clbAirlines.Name = "clbAirlines"
        Me.clbAirlines.Size = New System.Drawing.Size(982, 154)
        Me.clbAirlines.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnOpen)
        Me.GroupBox3.Controls.Add(Me.txtDest)
        Me.GroupBox3.Controls.Add(Me.txtOrg)
        Me.GroupBox3.Controls.Add(Me.btnDest)
        Me.GroupBox3.Controls.Add(Me.btnClear)
        Me.GroupBox3.Controls.Add(Me.btnOrg)
        Me.GroupBox3.Controls.Add(Me.clbCityOD)
        Me.GroupBox3.Controls.Add(Me.clbCountry)
        Me.GroupBox3.Controls.Add(Me.clbArea)
        Me.GroupBox3.Location = New System.Drawing.Point(-1, 221)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(998, 378)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "O and D"
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Location = New System.Drawing.Point(937, 299)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(53, 77)
        Me.btnOpen.TabIndex = 32
        Me.btnOpen.Text = "Run Report"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtDest
        '
        Me.txtDest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDest.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDest.Location = New System.Drawing.Point(86, 339)
        Me.txtDest.Multiline = True
        Me.txtDest.Name = "txtDest"
        Me.txtDest.ReadOnly = True
        Me.txtDest.Size = New System.Drawing.Size(850, 39)
        Me.txtDest.TabIndex = 4
        '
        'txtOrg
        '
        Me.txtOrg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrg.BackColor = System.Drawing.Color.AliceBlue
        Me.txtOrg.Location = New System.Drawing.Point(86, 299)
        Me.txtOrg.Multiline = True
        Me.txtOrg.Name = "txtOrg"
        Me.txtOrg.ReadOnly = True
        Me.txtOrg.Size = New System.Drawing.Size(850, 39)
        Me.txtOrg.TabIndex = 4
        '
        'btnDest
        '
        Me.btnDest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDest.Location = New System.Drawing.Point(4, 353)
        Me.btnDest.Name = "btnDest"
        Me.btnDest.Size = New System.Drawing.Size(75, 23)
        Me.btnDest.TabIndex = 3
        Me.btnDest.Text = "Dest"
        Me.btnDest.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(4, 326)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnOrg
        '
        Me.btnOrg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOrg.Location = New System.Drawing.Point(4, 299)
        Me.btnOrg.Name = "btnOrg"
        Me.btnOrg.Size = New System.Drawing.Size(75, 23)
        Me.btnOrg.TabIndex = 3
        Me.btnOrg.Text = "Org"
        Me.btnOrg.UseVisualStyleBackColor = True
        '
        'clbCityOD
        '
        Me.clbCityOD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbCityOD.CheckOnClick = True
        Me.clbCityOD.ColumnWidth = 45
        Me.clbCityOD.FormattingEnabled = True
        Me.clbCityOD.HorizontalScrollbar = True
        Me.clbCityOD.Location = New System.Drawing.Point(207, 40)
        Me.clbCityOD.MultiColumn = True
        Me.clbCityOD.Name = "clbCityOD"
        Me.clbCityOD.Size = New System.Drawing.Size(785, 259)
        Me.clbCityOD.TabIndex = 2
        '
        'clbCountry
        '
        Me.clbCountry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.clbCountry.CheckOnClick = True
        Me.clbCountry.ColumnWidth = 45
        Me.clbCountry.FormattingEnabled = True
        Me.clbCountry.HorizontalScrollbar = True
        Me.clbCountry.Location = New System.Drawing.Point(6, 40)
        Me.clbCountry.MultiColumn = True
        Me.clbCountry.Name = "clbCountry"
        Me.clbCountry.Size = New System.Drawing.Size(195, 259)
        Me.clbCountry.TabIndex = 1
        '
        'clbArea
        '
        Me.clbArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbArea.CheckOnClick = True
        Me.clbArea.ColumnWidth = 45
        Me.clbArea.FormattingEnabled = True
        Me.clbArea.HorizontalScrollbar = True
        Me.clbArea.Location = New System.Drawing.Point(6, 16)
        Me.clbArea.MultiColumn = True
        Me.clbArea.Name = "clbArea"
        Me.clbArea.Size = New System.Drawing.Size(986, 19)
        Me.clbArea.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnConfirm)
        Me.TabPage2.Controls.Add(Me.clbCity1)
        Me.TabPage2.Controls.Add(Me.rdoOthers)
        Me.TabPage2.Controls.Add(Me.rdoSouth)
        Me.TabPage2.Controls.Add(Me.rdoNorth)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(991, 596)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Area Setting"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(271, 0)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 7
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'clbCity1
        '
        Me.clbCity1.CheckOnClick = True
        Me.clbCity1.ColumnWidth = 45
        Me.clbCity1.FormattingEnabled = True
        Me.clbCity1.Location = New System.Drawing.Point(6, 26)
        Me.clbCity1.MultiColumn = True
        Me.clbCity1.Name = "clbCity1"
        Me.clbCity1.Size = New System.Drawing.Size(340, 94)
        Me.clbCity1.TabIndex = 6
        '
        'rdoOthers
        '
        Me.rdoOthers.AutoSize = True
        Me.rdoOthers.Location = New System.Drawing.Point(122, 3)
        Me.rdoOthers.Name = "rdoOthers"
        Me.rdoOthers.Size = New System.Drawing.Size(51, 17)
        Me.rdoOthers.TabIndex = 3
        Me.rdoOthers.Text = "Other"
        Me.rdoOthers.UseVisualStyleBackColor = True
        '
        'rdoSouth
        '
        Me.rdoSouth.AutoSize = True
        Me.rdoSouth.Location = New System.Drawing.Point(63, 3)
        Me.rdoSouth.Name = "rdoSouth"
        Me.rdoSouth.Size = New System.Drawing.Size(53, 17)
        Me.rdoSouth.TabIndex = 4
        Me.rdoSouth.Text = "South"
        Me.rdoSouth.UseVisualStyleBackColor = True
        '
        'rdoNorth
        '
        Me.rdoNorth.AutoSize = True
        Me.rdoNorth.Location = New System.Drawing.Point(6, 3)
        Me.rdoNorth.Name = "rdoNorth"
        Me.rdoNorth.Size = New System.Drawing.Size(51, 17)
        Me.rdoNorth.TabIndex = 5
        Me.rdoNorth.Text = "North"
        Me.rdoNorth.UseVisualStyleBackColor = True
        '
        'dgrFields
        '
        Me.dgrFields.AllowUserToAddRows = False
        Me.dgrFields.AllowUserToDeleteRows = False
        Me.dgrFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrFields.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.FieldName, Me.GroupBy})
        Me.dgrFields.Location = New System.Drawing.Point(352, 54)
        Me.dgrFields.Name = "dgrFields"
        Me.dgrFields.RowHeadersVisible = False
        Me.dgrFields.Size = New System.Drawing.Size(383, 338)
        Me.dgrFields.TabIndex = 1
        '
        'Selected
        '
        Me.Selected.HeaderText = "Selected"
        Me.Selected.Name = "Selected"
        '
        'FieldName
        '
        Me.FieldName.HeaderText = "FieldName"
        Me.FieldName.Name = "FieldName"
        Me.FieldName.ReadOnly = True
        '
        'GroupBy
        '
        Me.GroupBy.HeaderText = "GroupBy"
        Me.GroupBy.Name = "GroupBy"
        Me.GroupBy.ReadOnly = True
        '
        'MIDTData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 625)
        Me.Controls.Add(Me.TabControl1)
        Me.Location = New System.Drawing.Point(0, 50)
        Me.Name = "MIDTData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ACO Viet Nam :: MIDT Report"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.tpgAgents.ResumeLayout(False)
        Me.tpgAgents.PerformLayout()
        Me.tpgAL.ResumeLayout(False)
        Me.tpgAL.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgrFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents lnkAgents As System.Windows.Forms.LinkLabel
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tpgAgents As System.Windows.Forms.TabPage
    Friend WithEvents clbAgents As System.Windows.Forms.CheckedListBox
    Friend WithEvents tpgAL As System.Windows.Forms.TabPage
    Friend WithEvents clbAirlines As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnRetrieveAgents As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDest As System.Windows.Forms.TextBox
    Friend WithEvents txtOrg As System.Windows.Forms.TextBox
    Friend WithEvents btnDest As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnOrg As System.Windows.Forms.Button
    Friend WithEvents clbCityOD As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbCountry As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbArea As System.Windows.Forms.CheckedListBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents clbCity1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents rdoOthers As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSouth As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNorth As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cbxViewType As System.Windows.Forms.ComboBox
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkExclUA As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcl1B As System.Windows.Forms.CheckBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lnkGDS As System.Windows.Forms.LinkLabel
    Friend WithEvents clbGDS As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents clbCity As System.Windows.Forms.CheckedListBox
    Friend WithEvents lnkCity As System.Windows.Forms.LinkLabel
    Friend WithEvents chkOther As System.Windows.Forms.CheckBox
    Friend WithEvents chkSouth As System.Windows.Forms.CheckBox
    Friend WithEvents chkNorth As System.Windows.Forms.CheckBox
    Friend WithEvents lnkAirlines As System.Windows.Forms.LinkLabel
    Friend WithEvents btnRetrieveAirlines As System.Windows.Forms.Button
    Friend WithEvents dgrFields As DataGridView
    Friend WithEvents Selected As DataGridViewCheckBoxColumn
    Friend WithEvents FieldName As DataGridViewTextBoxColumn
    Friend WithEvents GroupBy As DataGridViewCheckBoxColumn
End Class
