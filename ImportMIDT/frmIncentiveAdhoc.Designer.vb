<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentiveAdhoc
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
        Me.lbkReject = New System.Windows.Forms.LinkLabel()
        Me.lbkApprove = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.lbkEdit = New System.Windows.Forms.LinkLabel()
        Me.lbkNew = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCalcQuarter = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboBookYear = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPIC = New System.Windows.Forms.ComboBox()
        Me.dgAdhoc = New System.Windows.Forms.DataGridView()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboTimeFrame = New System.Windows.Forms.ComboBox()
        Me.lbkCopy2Others = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboPeriod = New System.Windows.Forms.ComboBox()
        Me.lbkFilterRelatedRecords = New System.Windows.Forms.LinkLabel()
        CType(Me.dgAdhoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbkReject
        '
        Me.lbkReject.AutoSize = True
        Me.lbkReject.Location = New System.Drawing.Point(854, 652)
        Me.lbkReject.Name = "lbkReject"
        Me.lbkReject.Size = New System.Drawing.Size(38, 13)
        Me.lbkReject.TabIndex = 57
        Me.lbkReject.TabStop = True
        Me.lbkReject.Text = "Reject"
        '
        'lbkApprove
        '
        Me.lbkApprove.AutoSize = True
        Me.lbkApprove.Location = New System.Drawing.Point(801, 652)
        Me.lbkApprove.Name = "lbkApprove"
        Me.lbkApprove.Size = New System.Drawing.Size(47, 13)
        Me.lbkApprove.TabIndex = 56
        Me.lbkApprove.TabStop = True
        Me.lbkApprove.Text = "Approve"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(141, 652)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 55
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'lbkEdit
        '
        Me.lbkEdit.AutoSize = True
        Me.lbkEdit.Location = New System.Drawing.Point(110, 652)
        Me.lbkEdit.Name = "lbkEdit"
        Me.lbkEdit.Size = New System.Drawing.Size(25, 13)
        Me.lbkEdit.TabIndex = 54
        Me.lbkEdit.TabStop = True
        Me.lbkEdit.Text = "Edit"
        '
        'lbkNew
        '
        Me.lbkNew.AutoSize = True
        Me.lbkNew.Location = New System.Drawing.Point(1, 652)
        Me.lbkNew.Name = "lbkNew"
        Me.lbkNew.Size = New System.Drawing.Size(29, 13)
        Me.lbkNew.TabIndex = 52
        Me.lbkNew.TabStop = True
        Me.lbkNew.Text = "New"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(471, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Quarter"
        '
        'cboCalcQuarter
        '
        Me.cboCalcQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalcQuarter.FormattingEnabled = True
        Me.cboCalcQuarter.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboCalcQuarter.Location = New System.Drawing.Point(474, 24)
        Me.cboCalcQuarter.Name = "cboCalcQuarter"
        Me.cboCalcQuarter.Size = New System.Drawing.Size(34, 21)
        Me.cboCalcQuarter.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(410, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Year"
        '
        'cboBookYear
        '
        Me.cboBookYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBookYear.FormattingEnabled = True
        Me.cboBookYear.Items.AddRange(New Object() {"2016", "2017", "2018", "2019", "2020"})
        Me.cboBookYear.Location = New System.Drawing.Point(413, 24)
        Me.cboBookYear.Name = "cboBookYear"
        Me.cboBookYear.Size = New System.Drawing.Size(55, 21)
        Me.cboBookYear.TabIndex = 48
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OK", "--", "RJ"})
        Me.cboStatus.Location = New System.Drawing.Point(258, 24)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(50, 21)
        Me.cboStatus.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(128, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "PIC"
        '
        'cboPIC
        '
        Me.cboPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPIC.FormattingEnabled = True
        Me.cboPIC.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboPIC.Location = New System.Drawing.Point(131, 26)
        Me.cboPIC.Name = "cboPIC"
        Me.cboPIC.Size = New System.Drawing.Size(121, 21)
        Me.cboPIC.TabIndex = 44
        '
        'dgAdhoc
        '
        Me.dgAdhoc.AllowUserToAddRows = False
        Me.dgAdhoc.AllowUserToDeleteRows = False
        Me.dgAdhoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgAdhoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAdhoc.Location = New System.Drawing.Point(4, 53)
        Me.dgAdhoc.Name = "dgAdhoc"
        Me.dgAdhoc.ReadOnly = True
        Me.dgAdhoc.Size = New System.Drawing.Size(1012, 588)
        Me.dgAdhoc.TabIndex = 43
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(851, 24)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 41
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(754, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 39
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Customer"
        '
        'cboShortName
        '
        Me.cboShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboShortName.Location = New System.Drawing.Point(4, 26)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(121, 21)
        Me.cboShortName.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(511, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "TimeFrame"
        '
        'cboTimeFrame
        '
        Me.cboTimeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimeFrame.FormattingEnabled = True
        Me.cboTimeFrame.Items.AddRange(New Object() {"Month", "Quarter", "HalfYear", "Year"})
        Me.cboTimeFrame.Location = New System.Drawing.Point(514, 26)
        Me.cboTimeFrame.Name = "cboTimeFrame"
        Me.cboTimeFrame.Size = New System.Drawing.Size(100, 21)
        Me.cboTimeFrame.TabIndex = 58
        '
        'lbkCopy2Others
        '
        Me.lbkCopy2Others.AutoSize = True
        Me.lbkCopy2Others.Location = New System.Drawing.Point(36, 652)
        Me.lbkCopy2Others.Name = "lbkCopy2Others"
        Me.lbkCopy2Others.Size = New System.Drawing.Size(68, 13)
        Me.lbkCopy2Others.TabIndex = 53
        Me.lbkCopy2Others.TabStop = True
        Me.lbkCopy2Others.Text = "Copy2Others"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(311, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "IncType"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Adhoc", "Correction"})
        Me.ComboBox1.Location = New System.Drawing.Point(314, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(88, 21)
        Me.ComboBox1.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(617, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Period"
        '
        'cboPeriod
        '
        Me.cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriod.FormattingEnabled = True
        Me.cboPeriod.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboPeriod.Location = New System.Drawing.Point(620, 24)
        Me.cboPeriod.Name = "cboPeriod"
        Me.cboPeriod.Size = New System.Drawing.Size(34, 21)
        Me.cboPeriod.TabIndex = 62
        '
        'lbkFilterRelatedRecords
        '
        Me.lbkFilterRelatedRecords.AutoSize = True
        Me.lbkFilterRelatedRecords.Location = New System.Drawing.Point(685, 652)
        Me.lbkFilterRelatedRecords.Name = "lbkFilterRelatedRecords"
        Me.lbkFilterRelatedRecords.Size = New System.Drawing.Size(106, 13)
        Me.lbkFilterRelatedRecords.TabIndex = 64
        Me.lbkFilterRelatedRecords.TabStop = True
        Me.lbkFilterRelatedRecords.Text = "FilterRelatedRecords"
        '
        'frmIncentiveAdhoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 673)
        Me.Controls.Add(Me.lbkFilterRelatedRecords)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboPeriod)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboTimeFrame)
        Me.Controls.Add(Me.lbkReject)
        Me.Controls.Add(Me.lbkApprove)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkEdit)
        Me.Controls.Add(Me.lbkCopy2Others)
        Me.Controls.Add(Me.lbkNew)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboCalcQuarter)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboBookYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPIC)
        Me.Controls.Add(Me.dgAdhoc)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboShortName)
        Me.Name = "frmIncentiveAdhoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IncentiveAdhocAdjustment"
        CType(Me.dgAdhoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbkReject As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkApprove As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkEdit As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCalcQuarter As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboBookYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPIC As System.Windows.Forms.ComboBox
    Friend WithEvents dgAdhoc As System.Windows.Forms.DataGridView
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboShortName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTimeFrame As System.Windows.Forms.ComboBox
    Friend WithEvents lbkCopy2Others As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents lbkFilterRelatedRecords As System.Windows.Forms.LinkLabel
End Class
