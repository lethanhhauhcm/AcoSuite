<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSTM1
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
        Me.CmbName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTarger = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblVND = New System.Windows.Forms.Label()
        Me.TxtVND = New System.Windows.Forms.TextBox()
        Me.TxtFrom = New System.Windows.Forms.DateTimePicker()
        Me.TxtThru = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblUpdate = New System.Windows.Forms.LinkLabel()
        Me.GridCSTM = New System.Windows.Forms.DataGridView()
        Me.LblDelete = New System.Windows.Forms.LinkLabel()
        Me.LblApprove = New System.Windows.Forms.LinkLabel()
        Me.OptQQ = New System.Windows.Forms.RadioButton()
        Me.OptXX = New System.Windows.Forms.RadioButton()
        Me.OptCurrent = New System.Windows.Forms.RadioButton()
        Me.OptExp = New System.Windows.Forms.RadioButton()
        Me.OptMonth = New System.Windows.Forms.RadioButton()
        Me.OptQuarter = New System.Windows.Forms.RadioButton()
        Me.OptHalfYear = New System.Windows.Forms.RadioButton()
        Me.OptYear = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMinAdh = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtNewValid = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblExtend = New System.Windows.Forms.LinkLabel()
        CType(Me.GridCSTM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbName
        '
        Me.CmbName.FormattingEnabled = True
        Me.CmbName.Items.AddRange(New Object() {"BASIC", "0200", "0250", "0300", "0350", "0400", "0450", "0500", "1000", "1500", "2000", "2500", "3000", "3500", "4000", "4500", "5000", "5500", "6000", "6500", "7000", "7500", "8000", "8500", "9000", "9500"})
        Me.CmbName.Location = New System.Drawing.Point(268, 0)
        Me.CmbName.Name = "CmbName"
        Me.CmbName.Size = New System.Drawing.Size(71, 21)
        Me.CmbName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(207, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Target"
        '
        'TxtTarger
        '
        Me.TxtTarger.Location = New System.Drawing.Point(268, 27)
        Me.TxtTarger.Name = "TxtTarger"
        Me.TxtTarger.Size = New System.Drawing.Size(71, 20)
        Me.TxtTarger.TabIndex = 3
        Me.TxtTarger.Text = "0"
        Me.TxtTarger.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CommOffer"
        '
        'LblVND
        '
        Me.LblVND.AutoSize = True
        Me.LblVND.Location = New System.Drawing.Point(348, 30)
        Me.LblVND.Name = "LblVND"
        Me.LblVND.Size = New System.Drawing.Size(54, 13)
        Me.LblVND.TabIndex = 1
        Me.LblVND.Text = "VND/Bkg"
        '
        'TxtVND
        '
        Me.TxtVND.Location = New System.Drawing.Point(399, 27)
        Me.TxtVND.Name = "TxtVND"
        Me.TxtVND.Size = New System.Drawing.Size(93, 20)
        Me.TxtVND.TabIndex = 4
        Me.TxtVND.Text = "0"
        Me.TxtVND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtFrom
        '
        Me.TxtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFrom.Location = New System.Drawing.Point(399, 1)
        Me.TxtFrom.Name = "TxtFrom"
        Me.TxtFrom.Size = New System.Drawing.Size(93, 20)
        Me.TxtFrom.TabIndex = 1
        '
        'TxtThru
        '
        Me.TxtThru.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtThru.Location = New System.Drawing.Point(573, 1)
        Me.TxtThru.Name = "TxtThru"
        Me.TxtThru.Size = New System.Drawing.Size(81, 20)
        Me.TxtThru.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(344, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Eff. From"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(498, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Eff. Thru"
        '
        'LblUpdate
        '
        Me.LblUpdate.AutoSize = True
        Me.LblUpdate.Enabled = False
        Me.LblUpdate.Location = New System.Drawing.Point(660, 30)
        Me.LblUpdate.Name = "LblUpdate"
        Me.LblUpdate.Size = New System.Drawing.Size(42, 13)
        Me.LblUpdate.TabIndex = 11
        Me.LblUpdate.TabStop = True
        Me.LblUpdate.Text = "Update"
        '
        'GridCSTM
        '
        Me.GridCSTM.AllowUserToAddRows = False
        Me.GridCSTM.AllowUserToDeleteRows = False
        Me.GridCSTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCSTM.Location = New System.Drawing.Point(3, 61)
        Me.GridCSTM.Name = "GridCSTM"
        Me.GridCSTM.RowHeadersVisible = False
        Me.GridCSTM.Size = New System.Drawing.Size(713, 393)
        Me.GridCSTM.TabIndex = 5
        '
        'LblDelete
        '
        Me.LblDelete.AutoSize = True
        Me.LblDelete.Enabled = False
        Me.LblDelete.Location = New System.Drawing.Point(1, 459)
        Me.LblDelete.Name = "LblDelete"
        Me.LblDelete.Size = New System.Drawing.Size(38, 13)
        Me.LblDelete.TabIndex = 6
        Me.LblDelete.TabStop = True
        Me.LblDelete.Text = "Delete"
        '
        'LblApprove
        '
        Me.LblApprove.AutoSize = True
        Me.LblApprove.Enabled = False
        Me.LblApprove.Location = New System.Drawing.Point(669, 461)
        Me.LblApprove.Name = "LblApprove"
        Me.LblApprove.Size = New System.Drawing.Size(47, 13)
        Me.LblApprove.TabIndex = 7
        Me.LblApprove.TabStop = True
        Me.LblApprove.Text = "Approve"
        '
        'OptQQ
        '
        Me.OptQQ.AutoSize = True
        Me.OptQQ.Checked = True
        Me.OptQQ.Location = New System.Drawing.Point(56, 457)
        Me.OptQQ.Name = "OptQQ"
        Me.OptQQ.Size = New System.Drawing.Size(55, 17)
        Me.OptQQ.TabIndex = 8
        Me.OptQQ.TabStop = True
        Me.OptQQ.Text = "Q only"
        Me.OptQQ.UseVisualStyleBackColor = True
        '
        'OptXX
        '
        Me.OptXX.AutoSize = True
        Me.OptXX.Location = New System.Drawing.Point(117, 457)
        Me.OptXX.Name = "OptXX"
        Me.OptXX.Size = New System.Drawing.Size(63, 17)
        Me.OptXX.TabIndex = 8
        Me.OptXX.Text = "XX Only"
        Me.OptXX.UseVisualStyleBackColor = True
        '
        'OptCurrent
        '
        Me.OptCurrent.AutoSize = True
        Me.OptCurrent.Location = New System.Drawing.Point(256, 457)
        Me.OptCurrent.Name = "OptCurrent"
        Me.OptCurrent.Size = New System.Drawing.Size(80, 17)
        Me.OptCurrent.TabIndex = 8
        Me.OptCurrent.Text = "CurrentOnly"
        Me.OptCurrent.UseVisualStyleBackColor = True
        '
        'OptExp
        '
        Me.OptExp.AutoSize = True
        Me.OptExp.Location = New System.Drawing.Point(186, 457)
        Me.OptExp.Name = "OptExp"
        Me.OptExp.Size = New System.Drawing.Size(64, 17)
        Me.OptExp.TabIndex = 8
        Me.OptExp.Text = "ExpOnly"
        Me.OptExp.UseVisualStyleBackColor = True
        '
        'OptMonth
        '
        Me.OptMonth.AutoSize = True
        Me.OptMonth.Checked = True
        Me.OptMonth.Location = New System.Drawing.Point(6, 9)
        Me.OptMonth.Name = "OptMonth"
        Me.OptMonth.Size = New System.Drawing.Size(55, 17)
        Me.OptMonth.TabIndex = 12
        Me.OptMonth.TabStop = True
        Me.OptMonth.Text = "Month"
        Me.OptMonth.UseVisualStyleBackColor = True
        '
        'OptQuarter
        '
        Me.OptQuarter.AutoSize = True
        Me.OptQuarter.Location = New System.Drawing.Point(78, 9)
        Me.OptQuarter.Name = "OptQuarter"
        Me.OptQuarter.Size = New System.Drawing.Size(60, 17)
        Me.OptQuarter.TabIndex = 12
        Me.OptQuarter.Text = "Quarter"
        Me.OptQuarter.UseVisualStyleBackColor = True
        '
        'OptHalfYear
        '
        Me.OptHalfYear.AutoSize = True
        Me.OptHalfYear.Location = New System.Drawing.Point(6, 31)
        Me.OptHalfYear.Name = "OptHalfYear"
        Me.OptHalfYear.Size = New System.Drawing.Size(66, 17)
        Me.OptHalfYear.TabIndex = 12
        Me.OptHalfYear.TabStop = True
        Me.OptHalfYear.Text = "HalfYear"
        Me.OptHalfYear.UseVisualStyleBackColor = True
        '
        'OptYear
        '
        Me.OptYear.AutoSize = True
        Me.OptYear.Location = New System.Drawing.Point(78, 31)
        Me.OptYear.Name = "OptYear"
        Me.OptYear.Size = New System.Drawing.Size(47, 17)
        Me.OptYear.TabIndex = 12
        Me.OptYear.TabStop = True
        Me.OptYear.Text = "Year"
        Me.OptYear.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(498, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Min2RQAdh"
        '
        'TxtMinAdh
        '
        Me.TxtMinAdh.Location = New System.Drawing.Point(573, 27)
        Me.TxtMinAdh.Name = "TxtMinAdh"
        Me.TxtMinAdh.Size = New System.Drawing.Size(81, 20)
        Me.TxtMinAdh.TabIndex = 4
        Me.TxtMinAdh.Text = "0"
        Me.TxtMinAdh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptMonth)
        Me.GroupBox1.Controls.Add(Me.OptYear)
        Me.GroupBox1.Controls.Add(Me.OptQuarter)
        Me.GroupBox1.Controls.Add(Me.OptHalfYear)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 55)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'TxtNewValid
        '
        Me.TxtNewValid.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtNewValid.Location = New System.Drawing.Point(416, 457)
        Me.TxtNewValid.Name = "TxtNewValid"
        Me.TxtNewValid.Size = New System.Drawing.Size(88, 20)
        Me.TxtNewValid.TabIndex = 14
        Me.TxtNewValid.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(348, 459)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "NewValidity"
        Me.Label4.Visible = False
        '
        'LblExtend
        '
        Me.LblExtend.AutoSize = True
        Me.LblExtend.Location = New System.Drawing.Point(510, 459)
        Me.LblExtend.Name = "LblExtend"
        Me.LblExtend.Size = New System.Drawing.Size(40, 13)
        Me.LblExtend.TabIndex = 16
        Me.LblExtend.TabStop = True
        Me.LblExtend.Text = "Extend"
        Me.LblExtend.Visible = False
        '
        'CSTM1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 478)
        Me.Controls.Add(Me.LblExtend)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtNewValid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.OptExp)
        Me.Controls.Add(Me.OptCurrent)
        Me.Controls.Add(Me.OptXX)
        Me.Controls.Add(Me.OptQQ)
        Me.Controls.Add(Me.LblApprove)
        Me.Controls.Add(Me.LblDelete)
        Me.Controls.Add(Me.GridCSTM)
        Me.Controls.Add(Me.LblUpdate)
        Me.Controls.Add(Me.TxtThru)
        Me.Controls.Add(Me.TxtFrom)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtMinAdh)
        Me.Controls.Add(Me.TxtVND)
        Me.Controls.Add(Me.TxtTarger)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbName)
        Me.Controls.Add(Me.LblVND)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CSTM1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Commercial Offer :. Policy Updater"
        CType(Me.GridCSTM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTarger As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblVND As System.Windows.Forms.Label
    Friend WithEvents TxtVND As System.Windows.Forms.TextBox
    Friend WithEvents TxtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtThru As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblUpdate As System.Windows.Forms.LinkLabel
    Friend WithEvents GridCSTM As System.Windows.Forms.DataGridView
    Friend WithEvents LblDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents LblApprove As System.Windows.Forms.LinkLabel
    Friend WithEvents OptQQ As System.Windows.Forms.RadioButton
    Friend WithEvents OptXX As System.Windows.Forms.RadioButton
    Friend WithEvents OptCurrent As System.Windows.Forms.RadioButton
    Friend WithEvents OptExp As System.Windows.Forms.RadioButton
    Friend WithEvents OptMonth As System.Windows.Forms.RadioButton
    Friend WithEvents OptQuarter As System.Windows.Forms.RadioButton
    Friend WithEvents OptHalfYear As System.Windows.Forms.RadioButton
    Friend WithEvents OptYear As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMinAdh As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNewValid As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblExtend As System.Windows.Forms.LinkLabel
End Class
