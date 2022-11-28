<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentiveAdhocEdit
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
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.lblRecId = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboIncType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTimeFrame = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboPeriod = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtVND = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboQuarter = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboContact = New System.Windows.Forms.ComboBox()
        Me.txtOldIncentiveId = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtRecId
        '
        Me.txtRecId.Enabled = False
        Me.txtRecId.Location = New System.Drawing.Point(12, 19)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.Size = New System.Drawing.Size(100, 20)
        Me.txtRecId.TabIndex = 59
        '
        'lblRecId
        '
        Me.lblRecId.AutoSize = True
        Me.lblRecId.Location = New System.Drawing.Point(15, 2)
        Me.lblRecId.Name = "lblRecId"
        Me.lblRecId.Size = New System.Drawing.Size(36, 13)
        Me.lblRecId.TabIndex = 58
        Me.lblRecId.Text = "RecId"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(115, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "IncType"
        '
        'cboIncType
        '
        Me.cboIncType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIncType.FormattingEnabled = True
        Me.cboIncType.Items.AddRange(New Object() {"Adhoc", "Correction"})
        Me.cboIncType.Location = New System.Drawing.Point(118, 58)
        Me.cboIncType.Name = "cboIncType"
        Me.cboIncType.Size = New System.Drawing.Size(100, 21)
        Me.cboIncType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "TimeFrame"
        '
        'cboTimeFrame
        '
        Me.cboTimeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimeFrame.FormattingEnabled = True
        Me.cboTimeFrame.Items.AddRange(New Object() {"Month", "Quarter", "HalfYear", "Year"})
        Me.cboTimeFrame.Location = New System.Drawing.Point(224, 109)
        Me.cboTimeFrame.Name = "cboTimeFrame"
        Me.cboTimeFrame.Size = New System.Drawing.Size(100, 21)
        Me.cboTimeFrame.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(327, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Period"
        '
        'cboPeriod
        '
        Me.cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriod.FormattingEnabled = True
        Me.cboPeriod.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboPeriod.Location = New System.Drawing.Point(330, 109)
        Me.cboPeriod.Name = "cboPeriod"
        Me.cboPeriod.Size = New System.Drawing.Size(100, 21)
        Me.cboPeriod.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Year"
        '
        'cboYear
        '
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"2020", "2021", "2022", "2023", "2024", "2025"})
        Me.cboYear.Location = New System.Drawing.Point(12, 109)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(100, 21)
        Me.cboYear.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Customer"
        '
        'cboShortName
        '
        Me.cboShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboShortName.Location = New System.Drawing.Point(16, 58)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(96, 21)
        Me.cboShortName.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(295, 238)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(166, 238)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtVND
        '
        Me.txtVND.Location = New System.Drawing.Point(17, 153)
        Me.txtVND.Name = "txtVND"
        Me.txtVND.Size = New System.Drawing.Size(95, 20)
        Me.txtVND.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "VND"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(116, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Reason"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(118, 153)
        Me.txtReason.MaxLength = 64
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(364, 20)
        Me.txtReason.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(115, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Add in Quarter"
        '
        'cboQuarter
        '
        Me.cboQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQuarter.FormattingEnabled = True
        Me.cboQuarter.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboQuarter.Location = New System.Drawing.Point(118, 109)
        Me.cboQuarter.Name = "cboQuarter"
        Me.cboQuarter.Size = New System.Drawing.Size(100, 21)
        Me.cboQuarter.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(221, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Contact"
        '
        'cboContact
        '
        Me.cboContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContact.FormattingEnabled = True
        Me.cboContact.Location = New System.Drawing.Point(224, 58)
        Me.cboContact.Name = "cboContact"
        Me.cboContact.Size = New System.Drawing.Size(206, 21)
        Me.cboContact.TabIndex = 2
        '
        'txtOldIncentiveId
        '
        Me.txtOldIncentiveId.Enabled = False
        Me.txtOldIncentiveId.Location = New System.Drawing.Point(119, 19)
        Me.txtOldIncentiveId.Name = "txtOldIncentiveId"
        Me.txtOldIncentiveId.Size = New System.Drawing.Size(100, 20)
        Me.txtOldIncentiveId.TabIndex = 69
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(116, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "OldIncentiveId"
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(224, 19)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtStatus.TabIndex = 71
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(221, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "Status"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(327, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 13)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "Unit"
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Segment", "Ticket", "Bonus", "Support", "Rewards2Cash"})
        Me.cboUnit.Location = New System.Drawing.Point(330, 18)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(100, 21)
        Me.cboUnit.TabIndex = 72
        '
        'frmIncentiveAdhocEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboUnit)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtOldIncentiveId)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboContact)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboQuarter)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtVND)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.lblRecId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboIncType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTimeFrame)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboPeriod)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmIncentiveAdhocEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IncentiveAdhocAdjustmentEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecId As System.Windows.Forms.TextBox
    Friend WithEvents lblRecId As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboIncType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTimeFrame As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboShortName As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtVND As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboQuarter As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboContact As System.Windows.Forms.ComboBox
    Friend WithEvents txtOldIncentiveId As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cboUnit As ComboBox
End Class
