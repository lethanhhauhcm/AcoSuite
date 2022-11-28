<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPayment2Customers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.lbkSetAsUnPaid = New System.Windows.Forms.LinkLabel()
        Me.lbkSetPaidDate = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTimeFrame = New System.Windows.Forms.ComboBox()
        Me.cboBookYear = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboObject = New System.Windows.Forms.ComboBox()
        Me.lbkReset = New System.Windows.Forms.LinkLabel()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.dgrIncentives = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.cboQuarter = New System.Windows.Forms.ComboBox()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbkSearch = New System.Windows.Forms.LinkLabel()
        CType(Me.dgrIncentives, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Location = New System.Drawing.Point(11, 9)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(47, 13)
        Me.lblRecordCount.TabIndex = 32
        Me.lblRecordCount.Text = "Records"
        '
        'lbkSetAsUnPaid
        '
        Me.lbkSetAsUnPaid.AutoSize = True
        Me.lbkSetAsUnPaid.Location = New System.Drawing.Point(75, 589)
        Me.lbkSetAsUnPaid.Name = "lbkSetAsUnPaid"
        Me.lbkSetAsUnPaid.Size = New System.Drawing.Size(70, 13)
        Me.lbkSetAsUnPaid.TabIndex = 31
        Me.lbkSetAsUnPaid.TabStop = True
        Me.lbkSetAsUnPaid.Text = "SetAsUnPaid"
        '
        'lbkSetPaidDate
        '
        Me.lbkSetPaidDate.AutoSize = True
        Me.lbkSetPaidDate.Location = New System.Drawing.Point(2, 589)
        Me.lbkSetPaidDate.Name = "lbkSetPaidDate"
        Me.lbkSetPaidDate.Size = New System.Drawing.Size(56, 13)
        Me.lbkSetPaidDate.TabIndex = 30
        Me.lbkSetPaidDate.TabStop = True
        Me.lbkSetPaidDate.Text = "SetAsPaid"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(617, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "TimeFrame"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(502, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "CalcYear CalcQuarter"
        '
        'cboTimeFrame
        '
        Me.cboTimeFrame.FormattingEnabled = True
        Me.cboTimeFrame.Items.AddRange(New Object() {"HalfYear", "Month", "Quarter", "Year"})
        Me.cboTimeFrame.Location = New System.Drawing.Point(607, 23)
        Me.cboTimeFrame.Name = "cboTimeFrame"
        Me.cboTimeFrame.Size = New System.Drawing.Size(69, 21)
        Me.cboTimeFrame.TabIndex = 27
        '
        'cboBookYear
        '
        Me.cboBookYear.FormattingEnabled = True
        Me.cboBookYear.Items.AddRange(New Object() {"2017", "2018"})
        Me.cboBookYear.Location = New System.Drawing.Point(505, 23)
        Me.cboBookYear.Name = "cboBookYear"
        Me.cboBookYear.Size = New System.Drawing.Size(46, 21)
        Me.cboBookYear.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(446, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(276, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Object"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(102, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Customer"
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OK", "RR"})
        Me.cboStatus.Location = New System.Drawing.Point(449, 23)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(46, 21)
        Me.cboStatus.TabIndex = 22
        '
        'cboObject
        '
        Me.cboObject.FormattingEnabled = True
        Me.cboObject.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboObject.Location = New System.Drawing.Point(279, 23)
        Me.cboObject.Name = "cboObject"
        Me.cboObject.Size = New System.Drawing.Size(89, 21)
        Me.cboObject.TabIndex = 21
        '
        'lbkReset
        '
        Me.lbkReset.AutoSize = True
        Me.lbkReset.Location = New System.Drawing.Point(758, 26)
        Me.lbkReset.Name = "lbkReset"
        Me.lbkReset.Size = New System.Drawing.Size(35, 13)
        Me.lbkReset.TabIndex = 20
        Me.lbkReset.TabStop = True
        Me.lbkReset.Text = "Reset"
        '
        'cboShortName
        '
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(105, 23)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(168, 21)
        Me.cboShortName.TabIndex = 19
        '
        'dgrIncentives
        '
        Me.dgrIncentives.AllowUserToAddRows = False
        Me.dgrIncentives.AllowUserToDeleteRows = False
        Me.dgrIncentives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrIncentives.Location = New System.Drawing.Point(2, 50)
        Me.dgrIncentives.Name = "dgrIncentives"
        Me.dgrIncentives.ReadOnly = True
        Me.dgrIncentives.Size = New System.Drawing.Size(994, 511)
        Me.dgrIncentives.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(371, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Unit"
        '
        'cboUnit
        '
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Segment", "Ticket"})
        Me.cboUnit.Location = New System.Drawing.Point(374, 23)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(69, 21)
        Me.cboUnit.TabIndex = 34
        '
        'cboQuarter
        '
        Me.cboQuarter.FormattingEnabled = True
        Me.cboQuarter.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboQuarter.Location = New System.Drawing.Point(555, 23)
        Me.cboQuarter.Name = "cboQuarter"
        Me.cboQuarter.Size = New System.Drawing.Size(46, 21)
        Me.cboQuarter.TabIndex = 36
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(160, 586)
        Me.txtReason.MaxLength = 64
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(320, 20)
        Me.txtReason.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(157, 570)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Reason"
        '
        'lbkSearch
        '
        Me.lbkSearch.AutoSize = True
        Me.lbkSearch.Location = New System.Drawing.Point(682, 26)
        Me.lbkSearch.Name = "lbkSearch"
        Me.lbkSearch.Size = New System.Drawing.Size(41, 13)
        Me.lbkSearch.TabIndex = 39
        Me.lbkSearch.TabStop = True
        Me.lbkSearch.Text = "Search"
        '
        'frmPayment2Customers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 611)
        Me.Controls.Add(Me.lbkSearch)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.cboQuarter)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboUnit)
        Me.Controls.Add(Me.lblRecordCount)
        Me.Controls.Add(Me.lbkSetAsUnPaid)
        Me.Controls.Add(Me.lbkSetPaidDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTimeFrame)
        Me.Controls.Add(Me.cboBookYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.cboObject)
        Me.Controls.Add(Me.lbkReset)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.dgrIncentives)
        Me.Name = "frmPayment2Customers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment2Customers"
        CType(Me.dgrIncentives, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRecordCount As Label
    Friend WithEvents lbkSetAsUnPaid As LinkLabel
    Friend WithEvents lbkSetPaidDate As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboTimeFrame As ComboBox
    Friend WithEvents cboBookYear As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents cboObject As ComboBox
    Friend WithEvents lbkReset As LinkLabel
    Friend WithEvents cboShortName As ComboBox
    Friend WithEvents dgrIncentives As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents cboUnit As ComboBox
    Friend WithEvents cboQuarter As ComboBox
    Friend WithEvents txtReason As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lbkSearch As LinkLabel
End Class
