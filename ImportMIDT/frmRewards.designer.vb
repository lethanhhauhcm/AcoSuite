<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRewards
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.pacRewards = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarUserManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarNewsUpdater = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarGiftManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPointManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReportManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPromoManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAdhPointUpdater = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarOrderHandler = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAgentOIDMapping = New System.Windows.Forms.ToolStripMenuItem()
        Me.PadReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarQuickView = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDetailedReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrpUserManager = New System.Windows.Forms.GroupBox()
        Me.LblOwner = New System.Windows.Forms.LinkLabel()
        Me.LblVeriry = New System.Windows.Forms.LinkLabel()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.PnlBkrInfor = New System.Windows.Forms.Panel()
        Me.lblChangeMail = New System.Windows.Forms.LinkLabel()
        Me.TxtDOB = New System.Windows.Forms.DateTimePicker()
        Me.CmbTitle = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtMobile = New System.Windows.Forms.TextBox()
        Me.LblSave = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtAddr = New System.Windows.Forms.TextBox()
        Me.CmbSex = New System.Windows.Forms.ComboBox()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.LblUserMapping = New System.Windows.Forms.LinkLabel()
        Me.CmdDeleteUser = New System.Windows.Forms.Button()
        Me.CmdCreateUser = New System.Windows.Forms.Button()
        Me.TxtSIName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtSICode = New System.Windows.Forms.TextBox()
        Me.LblUserName = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbUserType = New System.Windows.Forms.ComboBox()
        Me.GrpVerify = New System.Windows.Forms.GroupBox()
        Me.GridNewMember = New System.Windows.Forms.DataGridView()
        Me.LblRejectNewMember = New System.Windows.Forms.LinkLabel()
        Me.LblCloseMemberVerify = New System.Windows.Forms.LinkLabel()
        Me.LblAccept = New System.Windows.Forms.LinkLabel()
        Me.lbkEdit = New System.Windows.Forms.LinkLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.GrpUserManager.SuspendLayout()
        Me.PnlBkrInfor.SuspendLayout()
        Me.GrpVerify.SuspendLayout()
        CType(Me.GridNewMember, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pacRewards, Me.PadReport})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(781, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'pacRewards
        '
        Me.pacRewards.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarUserManager, Me.BarNewsUpdater, Me.BarGiftManager, Me.BarPointManager, Me.BarReportManager, Me.BarPromoManager, Me.BarAdhPointUpdater, Me.BarOrderHandler, Me.BarAgentOIDMapping})
        Me.pacRewards.Name = "pacRewards"
        Me.pacRewards.Size = New System.Drawing.Size(49, 20)
        Me.pacRewards.Text = "Action"
        '
        'BarUserManager
        '
        Me.BarUserManager.Name = "BarUserManager"
        Me.BarUserManager.Size = New System.Drawing.Size(168, 22)
        Me.BarUserManager.Text = "User Manager"
        '
        'BarNewsUpdater
        '
        Me.BarNewsUpdater.Name = "BarNewsUpdater"
        Me.BarNewsUpdater.Size = New System.Drawing.Size(168, 22)
        Me.BarNewsUpdater.Text = "News Updater"
        '
        'BarGiftManager
        '
        Me.BarGiftManager.Name = "BarGiftManager"
        Me.BarGiftManager.Size = New System.Drawing.Size(168, 22)
        Me.BarGiftManager.Text = "Gift Manager"
        '
        'BarPointManager
        '
        Me.BarPointManager.Name = "BarPointManager"
        Me.BarPointManager.Size = New System.Drawing.Size(168, 22)
        Me.BarPointManager.Text = "Point Manager"
        '
        'BarReportManager
        '
        Me.BarReportManager.Name = "BarReportManager"
        Me.BarReportManager.Size = New System.Drawing.Size(168, 22)
        Me.BarReportManager.Text = "Report Manager"
        '
        'BarPromoManager
        '
        Me.BarPromoManager.Name = "BarPromoManager"
        Me.BarPromoManager.Size = New System.Drawing.Size(168, 22)
        Me.BarPromoManager.Text = "Promo Manager"
        '
        'BarAdhPointUpdater
        '
        Me.BarAdhPointUpdater.Name = "BarAdhPointUpdater"
        Me.BarAdhPointUpdater.Size = New System.Drawing.Size(168, 22)
        Me.BarAdhPointUpdater.Text = "Adh Point Updater"
        '
        'BarOrderHandler
        '
        Me.BarOrderHandler.Name = "BarOrderHandler"
        Me.BarOrderHandler.Size = New System.Drawing.Size(168, 22)
        Me.BarOrderHandler.Text = "Order Handler"
        '
        'BarAgentOIDMapping
        '
        Me.BarAgentOIDMapping.Name = "BarAgentOIDMapping"
        Me.BarAgentOIDMapping.Size = New System.Drawing.Size(168, 22)
        Me.BarAgentOIDMapping.Text = "Agent OID Mapping"
        '
        'PadReport
        '
        Me.PadReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarQuickView, Me.BarDetailedReport})
        Me.PadReport.Name = "PadReport"
        Me.PadReport.Size = New System.Drawing.Size(52, 20)
        Me.PadReport.Text = "Report"
        '
        'BarQuickView
        '
        Me.BarQuickView.Name = "BarQuickView"
        Me.BarQuickView.Size = New System.Drawing.Size(149, 22)
        Me.BarQuickView.Text = "Quick View"
        '
        'BarDetailedReport
        '
        Me.BarDetailedReport.Name = "BarDetailedReport"
        Me.BarDetailedReport.Size = New System.Drawing.Size(149, 22)
        Me.BarDetailedReport.Text = "Detailed Report"
        '
        'GrpUserManager
        '
        Me.GrpUserManager.Controls.Add(Me.LblOwner)
        Me.GrpUserManager.Controls.Add(Me.LblVeriry)
        Me.GrpUserManager.Controls.Add(Me.txtUserID)
        Me.GrpUserManager.Controls.Add(Me.PnlBkrInfor)
        Me.GrpUserManager.Controls.Add(Me.CmdClose)
        Me.GrpUserManager.Controls.Add(Me.LblUserMapping)
        Me.GrpUserManager.Controls.Add(Me.CmdDeleteUser)
        Me.GrpUserManager.Controls.Add(Me.CmdCreateUser)
        Me.GrpUserManager.Controls.Add(Me.TxtSIName)
        Me.GrpUserManager.Controls.Add(Me.Label8)
        Me.GrpUserManager.Controls.Add(Me.TxtSICode)
        Me.GrpUserManager.Controls.Add(Me.LblUserName)
        Me.GrpUserManager.Controls.Add(Me.Label6)
        Me.GrpUserManager.Controls.Add(Me.CmbUserType)
        Me.GrpUserManager.Location = New System.Drawing.Point(273, 27)
        Me.GrpUserManager.Name = "GrpUserManager"
        Me.GrpUserManager.Size = New System.Drawing.Size(503, 451)
        Me.GrpUserManager.TabIndex = 13
        Me.GrpUserManager.TabStop = False
        Me.GrpUserManager.Visible = False
        '
        'LblOwner
        '
        Me.LblOwner.AutoSize = True
        Me.LblOwner.Location = New System.Drawing.Point(427, 404)
        Me.LblOwner.Name = "LblOwner"
        Me.LblOwner.Size = New System.Drawing.Size(54, 13)
        Me.LblOwner.TabIndex = 35
        Me.LblOwner.TabStop = True
        Me.LblOwner.Text = "AgtOwner"
        '
        'LblVeriry
        '
        Me.LblVeriry.AutoSize = True
        Me.LblVeriry.Location = New System.Drawing.Point(350, 426)
        Me.LblVeriry.Name = "LblVeriry"
        Me.LblVeriry.Size = New System.Drawing.Size(71, 13)
        Me.LblVeriry.TabIndex = 34
        Me.LblVeriry.TabStop = True
        Me.LblVeriry.Text = "VerifyMember"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(459, 9)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(39, 20)
        Me.txtUserID.TabIndex = 33
        Me.txtUserID.Text = "0"
        Me.txtUserID.Visible = False
        '
        'PnlBkrInfor
        '
        Me.PnlBkrInfor.Controls.Add(Me.lblChangeMail)
        Me.PnlBkrInfor.Controls.Add(Me.TxtDOB)
        Me.PnlBkrInfor.Controls.Add(Me.CmbTitle)
        Me.PnlBkrInfor.Controls.Add(Me.Label9)
        Me.PnlBkrInfor.Controls.Add(Me.Label13)
        Me.PnlBkrInfor.Controls.Add(Me.TxtMobile)
        Me.PnlBkrInfor.Controls.Add(Me.LblSave)
        Me.PnlBkrInfor.Controls.Add(Me.Label11)
        Me.PnlBkrInfor.Controls.Add(Me.Label12)
        Me.PnlBkrInfor.Controls.Add(Me.TxtAddr)
        Me.PnlBkrInfor.Controls.Add(Me.CmbSex)
        Me.PnlBkrInfor.Location = New System.Drawing.Point(-1, 62)
        Me.PnlBkrInfor.Name = "PnlBkrInfor"
        Me.PnlBkrInfor.Size = New System.Drawing.Size(498, 76)
        Me.PnlBkrInfor.TabIndex = 32
        '
        'lblChangeMail
        '
        Me.lblChangeMail.AutoSize = True
        Me.lblChangeMail.Location = New System.Drawing.Point(64, 50)
        Me.lblChangeMail.Name = "lblChangeMail"
        Me.lblChangeMail.Size = New System.Drawing.Size(63, 13)
        Me.lblChangeMail.TabIndex = 31
        Me.lblChangeMail.TabStop = True
        Me.lblChangeMail.Text = "ChangeMail"
        Me.lblChangeMail.Visible = False
        '
        'TxtDOB
        '
        Me.TxtDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtDOB.Location = New System.Drawing.Point(207, 4)
        Me.TxtDOB.Name = "TxtDOB"
        Me.TxtDOB.Size = New System.Drawing.Size(79, 20)
        Me.TxtDOB.TabIndex = 5
        '
        'CmbTitle
        '
        Me.CmbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTitle.FormattingEnabled = True
        Me.CmbTitle.Location = New System.Drawing.Point(326, 4)
        Me.CmbTitle.Name = "CmbTitle"
        Me.CmbTitle.Size = New System.Drawing.Size(169, 21)
        Me.CmbTitle.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Mobile"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(290, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Title"
        '
        'TxtMobile
        '
        Me.TxtMobile.Location = New System.Drawing.Point(67, 4)
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(100, 20)
        Me.TxtMobile.TabIndex = 3
        '
        'LblSave
        '
        Me.LblSave.AutoSize = True
        Me.LblSave.Location = New System.Drawing.Point(453, 50)
        Me.LblSave.Name = "LblSave"
        Me.LblSave.Size = New System.Drawing.Size(32, 13)
        Me.LblSave.TabIndex = 27
        Me.LblSave.TabStop = True
        Me.LblSave.Text = "Save"
        Me.LblSave.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(173, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "DOB"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Home Addr."
        '
        'TxtAddr
        '
        Me.TxtAddr.Location = New System.Drawing.Point(67, 26)
        Me.TxtAddr.Name = "TxtAddr"
        Me.TxtAddr.Size = New System.Drawing.Size(383, 20)
        Me.TxtAddr.TabIndex = 3
        '
        'CmbSex
        '
        Me.CmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSex.FormattingEnabled = True
        Me.CmbSex.Items.AddRange(New Object() {"Nam", "Nữ"})
        Me.CmbSex.Location = New System.Drawing.Point(453, 26)
        Me.CmbSex.Name = "CmbSex"
        Me.CmbSex.Size = New System.Drawing.Size(41, 21)
        Me.CmbSex.TabIndex = 28
        '
        'CmdClose
        '
        Me.CmdClose.Location = New System.Drawing.Point(281, 419)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(69, 26)
        Me.CmdClose.TabIndex = 31
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = True
        '
        'LblUserMapping
        '
        Me.LblUserMapping.AutoSize = True
        Me.LblUserMapping.Location = New System.Drawing.Point(427, 426)
        Me.LblUserMapping.Name = "LblUserMapping"
        Me.LblUserMapping.Size = New System.Drawing.Size(70, 13)
        Me.LblUserMapping.TabIndex = 26
        Me.LblUserMapping.TabStop = True
        Me.LblUserMapping.Text = "UserMapping"
        '
        'CmdDeleteUser
        '
        Me.CmdDeleteUser.Enabled = False
        Me.CmdDeleteUser.Location = New System.Drawing.Point(176, 419)
        Me.CmdDeleteUser.Name = "CmdDeleteUser"
        Me.CmdDeleteUser.Size = New System.Drawing.Size(46, 26)
        Me.CmdDeleteUser.TabIndex = 22
        Me.CmdDeleteUser.Text = "Delete"
        Me.CmdDeleteUser.UseVisualStyleBackColor = True
        '
        'CmdCreateUser
        '
        Me.CmdCreateUser.Enabled = False
        Me.CmdCreateUser.Location = New System.Drawing.Point(225, 419)
        Me.CmdCreateUser.Name = "CmdCreateUser"
        Me.CmdCreateUser.Size = New System.Drawing.Size(50, 26)
        Me.CmdCreateUser.TabIndex = 23
        Me.CmdCreateUser.Text = "Create"
        Me.CmdCreateUser.UseVisualStyleBackColor = True
        '
        'TxtSIName
        '
        Me.TxtSIName.Location = New System.Drawing.Point(318, 36)
        Me.TxtSIName.Name = "TxtSIName"
        Me.TxtSIName.Size = New System.Drawing.Size(176, 20)
        Me.TxtSIName.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(265, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "FullName"
        '
        'TxtSICode
        '
        Me.TxtSICode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSICode.Location = New System.Drawing.Point(66, 36)
        Me.TxtSICode.Name = "TxtSICode"
        Me.TxtSICode.Size = New System.Drawing.Size(61, 20)
        Me.TxtSICode.TabIndex = 3
        '
        'LblUserName
        '
        Me.LblUserName.AutoSize = True
        Me.LblUserName.Location = New System.Drawing.Point(6, 39)
        Me.LblUserName.Name = "LblUserName"
        Me.LblUserName.Size = New System.Drawing.Size(57, 13)
        Me.LblUserName.TabIndex = 2
        Me.LblUserName.Text = "UserName"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Type"
        '
        'CmbUserType
        '
        Me.CmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUserType.FormattingEnabled = True
        Me.CmbUserType.Items.AddRange(New Object() {"AGT", "BKR"})
        Me.CmbUserType.Location = New System.Drawing.Point(66, 12)
        Me.CmbUserType.Name = "CmbUserType"
        Me.CmbUserType.Size = New System.Drawing.Size(61, 21)
        Me.CmbUserType.TabIndex = 0
        '
        'GrpVerify
        '
        Me.GrpVerify.Controls.Add(Me.lbkEdit)
        Me.GrpVerify.Controls.Add(Me.GridNewMember)
        Me.GrpVerify.Controls.Add(Me.LblRejectNewMember)
        Me.GrpVerify.Controls.Add(Me.LblCloseMemberVerify)
        Me.GrpVerify.Controls.Add(Me.LblAccept)
        Me.GrpVerify.Location = New System.Drawing.Point(6, 209)
        Me.GrpVerify.Name = "GrpVerify"
        Me.GrpVerify.Size = New System.Drawing.Size(266, 127)
        Me.GrpVerify.TabIndex = 35
        Me.GrpVerify.TabStop = False
        Me.GrpVerify.Visible = False
        '
        'GridNewMember
        '
        Me.GridNewMember.AllowUserToAddRows = False
        Me.GridNewMember.AllowUserToDeleteRows = False
        Me.GridNewMember.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridNewMember.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.GridNewMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridNewMember.Location = New System.Drawing.Point(6, 12)
        Me.GridNewMember.Name = "GridNewMember"
        Me.GridNewMember.ReadOnly = True
        Me.GridNewMember.RowHeadersVisible = False
        Me.GridNewMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridNewMember.Size = New System.Drawing.Size(255, 89)
        Me.GridNewMember.TabIndex = 0
        '
        'LblRejectNewMember
        '
        Me.LblRejectNewMember.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblRejectNewMember.AutoSize = True
        Me.LblRejectNewMember.Location = New System.Drawing.Point(6, 105)
        Me.LblRejectNewMember.Name = "LblRejectNewMember"
        Me.LblRejectNewMember.Size = New System.Drawing.Size(38, 13)
        Me.LblRejectNewMember.TabIndex = 34
        Me.LblRejectNewMember.TabStop = True
        Me.LblRejectNewMember.Text = "Reject"
        Me.LblRejectNewMember.Visible = False
        '
        'LblCloseMemberVerify
        '
        Me.LblCloseMemberVerify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCloseMemberVerify.AutoSize = True
        Me.LblCloseMemberVerify.Location = New System.Drawing.Point(226, 105)
        Me.LblCloseMemberVerify.Name = "LblCloseMemberVerify"
        Me.LblCloseMemberVerify.Size = New System.Drawing.Size(33, 13)
        Me.LblCloseMemberVerify.TabIndex = 34
        Me.LblCloseMemberVerify.TabStop = True
        Me.LblCloseMemberVerify.Text = "Close"
        '
        'LblAccept
        '
        Me.LblAccept.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblAccept.AutoSize = True
        Me.LblAccept.Location = New System.Drawing.Point(77, 105)
        Me.LblAccept.Name = "LblAccept"
        Me.LblAccept.Size = New System.Drawing.Size(41, 13)
        Me.LblAccept.TabIndex = 34
        Me.LblAccept.TabStop = True
        Me.LblAccept.Text = "Accept"
        Me.LblAccept.Visible = False
        '
        'lbkEdit
        '
        Me.lbkEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbkEdit.AutoSize = True
        Me.lbkEdit.Location = New System.Drawing.Point(135, 105)
        Me.lbkEdit.Name = "lbkEdit"
        Me.lbkEdit.Size = New System.Drawing.Size(25, 13)
        Me.lbkEdit.TabIndex = 35
        Me.lbkEdit.TabStop = True
        Me.lbkEdit.Text = "Edit"
        Me.lbkEdit.Visible = False
        '
        'frmRewards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 496)
        Me.Controls.Add(Me.GrpVerify)
        Me.Controls.Add(Me.GrpUserManager)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRewards"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Reward "
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GrpUserManager.ResumeLayout(False)
        Me.GrpUserManager.PerformLayout()
        Me.PnlBkrInfor.ResumeLayout(False)
        Me.PnlBkrInfor.PerformLayout()
        Me.GrpVerify.ResumeLayout(False)
        Me.GrpVerify.PerformLayout()
        CType(Me.GridNewMember, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents pacRewards As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarUserManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarNewsUpdater As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarGiftManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarPointManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarReportManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrpUserManager As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtSIName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtSICode As System.Windows.Forms.TextBox
    Friend WithEvents LblUserName As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbUserType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmdDeleteUser As System.Windows.Forms.Button
    Friend WithEvents CmdCreateUser As System.Windows.Forms.Button
    Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BarPromoManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarAdhPointUpdater As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblSave As System.Windows.Forms.LinkLabel
    Friend WithEvents LblUserMapping As System.Windows.Forms.LinkLabel
    Friend WithEvents CmbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmbSex As System.Windows.Forms.ComboBox
    Friend WithEvents CmdClose As System.Windows.Forms.Button
    Friend WithEvents PnlBkrInfor As System.Windows.Forms.Panel
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents PadReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarQuickView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarDetailedReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblVeriry As System.Windows.Forms.LinkLabel
    Friend WithEvents GrpVerify As System.Windows.Forms.GroupBox
    Friend WithEvents GridNewMember As System.Windows.Forms.DataGridView
    Friend WithEvents LblAccept As System.Windows.Forms.LinkLabel
    Friend WithEvents LblRejectNewMember As System.Windows.Forms.LinkLabel
    Friend WithEvents LblCloseMemberVerify As System.Windows.Forms.LinkLabel
    Friend WithEvents BarOrderHandler As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblChangeMail As System.Windows.Forms.LinkLabel
    Friend WithEvents BarAgentOIDMapping As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblOwner As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkEdit As System.Windows.Forms.LinkLabel

End Class
