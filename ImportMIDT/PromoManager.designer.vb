<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PromoManager
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
        Me.txtFrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtThru = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ChkAL = New System.Windows.Forms.CheckBox
        Me.LstAL = New System.Windows.Forms.CheckedListBox
        Me.ChkMember = New System.Windows.Forms.CheckBox
        Me.LstMember = New System.Windows.Forms.CheckedListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblUpdate = New System.Windows.Forms.LinkLabel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtCampaign = New System.Windows.Forms.TextBox
        Me.txtCoef = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.LblDelete = New System.Windows.Forms.LinkLabel
        Me.GridCurrentPromo = New System.Windows.Forms.DataGridView
        Me.GridPromoD = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.GridCurrentPromo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPromoD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFrom
        '
        Me.txtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFrom.Location = New System.Drawing.Point(4, 33)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(91, 20)
        Me.txtFrom.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Book date Between"
        '
        'txtThru
        '
        Me.txtThru.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtThru.Location = New System.Drawing.Point(101, 33)
        Me.txtThru.Name = "txtThru"
        Me.txtThru.Size = New System.Drawing.Size(91, 20)
        Me.txtThru.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "And"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Airline"
        '
        'ChkAL
        '
        Me.ChkAL.AutoSize = True
        Me.ChkAL.Checked = True
        Me.ChkAL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAL.Location = New System.Drawing.Point(42, 55)
        Me.ChkAL.Name = "ChkAL"
        Me.ChkAL.Size = New System.Drawing.Size(45, 17)
        Me.ChkAL.TabIndex = 3
        Me.ChkAL.Text = "ALL"
        Me.ChkAL.UseVisualStyleBackColor = True
        '
        'LstAL
        '
        Me.LstAL.CheckOnClick = True
        Me.LstAL.ColumnWidth = 56
        Me.LstAL.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstAL.FormattingEnabled = True
        Me.LstAL.Location = New System.Drawing.Point(4, 72)
        Me.LstAL.MultiColumn = True
        Me.LstAL.Name = "LstAL"
        Me.LstAL.Size = New System.Drawing.Size(188, 372)
        Me.LstAL.TabIndex = 4
        Me.LstAL.Visible = False
        '
        'ChkMember
        '
        Me.ChkMember.AutoSize = True
        Me.ChkMember.Checked = True
        Me.ChkMember.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMember.Location = New System.Drawing.Point(251, 55)
        Me.ChkMember.Name = "ChkMember"
        Me.ChkMember.Size = New System.Drawing.Size(45, 17)
        Me.ChkMember.TabIndex = 3
        Me.ChkMember.Text = "ALL"
        Me.ChkMember.UseVisualStyleBackColor = True
        '
        'LstMember
        '
        Me.LstMember.CheckOnClick = True
        Me.LstMember.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstMember.FormattingEnabled = True
        Me.LstMember.Location = New System.Drawing.Point(203, 72)
        Me.LstMember.Name = "LstMember"
        Me.LstMember.Size = New System.Drawing.Size(564, 372)
        Me.LstMember.TabIndex = 4
        Me.LstMember.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Member"
        '
        'lblUpdate
        '
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.Location = New System.Drawing.Point(525, 36)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(42, 13)
        Me.lblUpdate.TabIndex = 5
        Me.lblUpdate.TabStop = True
        Me.lblUpdate.Text = "Update"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(778, 492)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtCampaign)
        Me.TabPage1.Controls.Add(Me.txtCoef)
        Me.TabPage1.Controls.Add(Me.txtThru)
        Me.TabPage1.Controls.Add(Me.lblUpdate)
        Me.TabPage1.Controls.Add(Me.txtFrom)
        Me.TabPage1.Controls.Add(Me.LstMember)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.LstAL)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.ChkMember)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.ChkAL)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(770, 466)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "New Prome"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtCampaign
        '
        Me.txtCampaign.Location = New System.Drawing.Point(251, 33)
        Me.txtCampaign.MaxLength = 56
        Me.txtCampaign.Name = "txtCampaign"
        Me.txtCampaign.Size = New System.Drawing.Size(268, 20)
        Me.txtCampaign.TabIndex = 7
        '
        'txtCoef
        '
        Me.txtCoef.Location = New System.Drawing.Point(196, 33)
        Me.txtCoef.Name = "txtCoef"
        Me.txtCoef.Size = New System.Drawing.Size(49, 20)
        Me.txtCoef.TabIndex = 6
        Me.txtCoef.Text = "2"
        Me.txtCoef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(248, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Campaign Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(193, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Coef"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridPromoD)
        Me.TabPage2.Controls.Add(Me.LblDelete)
        Me.TabPage2.Controls.Add(Me.GridCurrentPromo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(770, 466)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "CurrentPromo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'LblDelete
        '
        Me.LblDelete.AutoSize = True
        Me.LblDelete.Location = New System.Drawing.Point(6, 450)
        Me.LblDelete.Name = "LblDelete"
        Me.LblDelete.Size = New System.Drawing.Size(38, 13)
        Me.LblDelete.TabIndex = 1
        Me.LblDelete.TabStop = True
        Me.LblDelete.Text = "Delete"
        '
        'GridCurrentPromo
        '
        Me.GridCurrentPromo.AllowUserToAddRows = False
        Me.GridCurrentPromo.AllowUserToDeleteRows = False
        Me.GridCurrentPromo.BackgroundColor = System.Drawing.Color.Azure
        Me.GridCurrentPromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCurrentPromo.Location = New System.Drawing.Point(3, 6)
        Me.GridCurrentPromo.Name = "GridCurrentPromo"
        Me.GridCurrentPromo.ReadOnly = True
        Me.GridCurrentPromo.RowHeadersVisible = False
        Me.GridCurrentPromo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridCurrentPromo.Size = New System.Drawing.Size(508, 441)
        Me.GridCurrentPromo.TabIndex = 0
        '
        'GridPromoD
        '
        Me.GridPromoD.AllowUserToAddRows = False
        Me.GridPromoD.AllowUserToDeleteRows = False
        Me.GridPromoD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPromoD.Location = New System.Drawing.Point(517, 6)
        Me.GridPromoD.Name = "GridPromoD"
        Me.GridPromoD.ReadOnly = True
        Me.GridPromoD.RowHeadersVisible = False
        Me.GridPromoD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridPromoD.Size = New System.Drawing.Size(247, 440)
        Me.GridPromoD.TabIndex = 2
        '
        'PromoManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 496)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PromoManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Reward :. Promo Manager"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GridCurrentPromo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPromoD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtThru As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkAL As System.Windows.Forms.CheckBox
    Friend WithEvents LstAL As System.Windows.Forms.CheckedListBox
    Friend WithEvents ChkMember As System.Windows.Forms.CheckBox
    Friend WithEvents LstMember As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblUpdate As System.Windows.Forms.LinkLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents LblDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents GridCurrentPromo As System.Windows.Forms.DataGridView
    Friend WithEvents txtCoef As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCampaign As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GridPromoD As System.Windows.Forms.DataGridView
End Class
