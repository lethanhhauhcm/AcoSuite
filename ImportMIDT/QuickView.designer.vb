<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuickView
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
        Me.GridRPT = New System.Windows.Forms.DataGridView()
        Me.LblUserList = New System.Windows.Forms.LinkLabel()
        Me.LblThisMonthBD = New System.Windows.Forms.LinkLabel()
        Me.LblPendingOrder = New System.Windows.Forms.LinkLabel()
        Me.LblGiftList = New System.Windows.Forms.LinkLabel()
        Me.LblPendingUser = New System.Windows.Forms.LinkLabel()
        Me.LblPointByMember = New System.Windows.Forms.LinkLabel()
        CType(Me.GridRPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridRPT
        '
        Me.GridRPT.AllowUserToAddRows = False
        Me.GridRPT.AllowUserToDeleteRows = False
        Me.GridRPT.BackgroundColor = System.Drawing.Color.DodgerBlue
        Me.GridRPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridRPT.Location = New System.Drawing.Point(3, 0)
        Me.GridRPT.Name = "GridRPT"
        Me.GridRPT.RowHeadersVisible = False
        Me.GridRPT.Size = New System.Drawing.Size(700, 493)
        Me.GridRPT.TabIndex = 0
        '
        'LblUserList
        '
        Me.LblUserList.AutoSize = True
        Me.LblUserList.Location = New System.Drawing.Point(703, 101)
        Me.LblUserList.Name = "LblUserList"
        Me.LblUserList.Size = New System.Drawing.Size(45, 13)
        Me.LblUserList.TabIndex = 1
        Me.LblUserList.TabStop = True
        Me.LblUserList.Text = "UserList"
        '
        'LblThisMonthBD
        '
        Me.LblThisMonthBD.AutoSize = True
        Me.LblThisMonthBD.Location = New System.Drawing.Point(701, 33)
        Me.LblThisMonthBD.Name = "LblThisMonthBD"
        Me.LblThisMonthBD.Size = New System.Drawing.Size(83, 13)
        Me.LblThisMonthBD.TabIndex = 1
        Me.LblThisMonthBD.TabStop = True
        Me.LblThisMonthBD.Text = "BDayThisMonth"
        '
        'LblPendingOrder
        '
        Me.LblPendingOrder.AutoSize = True
        Me.LblPendingOrder.Location = New System.Drawing.Point(703, 79)
        Me.LblPendingOrder.Name = "LblPendingOrder"
        Me.LblPendingOrder.Size = New System.Drawing.Size(72, 13)
        Me.LblPendingOrder.TabIndex = 1
        Me.LblPendingOrder.TabStop = True
        Me.LblPendingOrder.Text = "PendingOrder"
        '
        'LblGiftList
        '
        Me.LblGiftList.AutoSize = True
        Me.LblGiftList.Location = New System.Drawing.Point(703, 124)
        Me.LblGiftList.Name = "LblGiftList"
        Me.LblGiftList.Size = New System.Drawing.Size(39, 13)
        Me.LblGiftList.TabIndex = 1
        Me.LblGiftList.TabStop = True
        Me.LblGiftList.Text = "GiftList"
        '
        'LblPendingUser
        '
        Me.LblPendingUser.AutoSize = True
        Me.LblPendingUser.Location = New System.Drawing.Point(701, 9)
        Me.LblPendingUser.Name = "LblPendingUser"
        Me.LblPendingUser.Size = New System.Drawing.Size(68, 13)
        Me.LblPendingUser.TabIndex = 1
        Me.LblPendingUser.TabStop = True
        Me.LblPendingUser.Text = "PendingUser"
        '
        'LblPointByMember
        '
        Me.LblPointByMember.AutoSize = True
        Me.LblPointByMember.Location = New System.Drawing.Point(703, 56)
        Me.LblPointByMember.Name = "LblPointByMember"
        Me.LblPointByMember.Size = New System.Drawing.Size(81, 13)
        Me.LblPointByMember.TabIndex = 1
        Me.LblPointByMember.TabStop = True
        Me.LblPointByMember.Text = "PointByMember"
        '
        'QuickView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 496)
        Me.Controls.Add(Me.LblPointByMember)
        Me.Controls.Add(Me.GridRPT)
        Me.Controls.Add(Me.LblPendingUser)
        Me.Controls.Add(Me.LblUserList)
        Me.Controls.Add(Me.LblThisMonthBD)
        Me.Controls.Add(Me.LblGiftList)
        Me.Controls.Add(Me.LblPendingOrder)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "QuickView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Vietnam :: Reward :. Quick View"
        CType(Me.GridRPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridRPT As System.Windows.Forms.DataGridView
    Friend WithEvents LblUserList As System.Windows.Forms.LinkLabel
    Friend WithEvents LblThisMonthBD As System.Windows.Forms.LinkLabel
    Friend WithEvents LblPendingOrder As System.Windows.Forms.LinkLabel
    Friend WithEvents LblGiftList As System.Windows.Forms.LinkLabel
    Friend WithEvents LblPendingUser As System.Windows.Forms.LinkLabel
    Friend WithEvents LblPointByMember As System.Windows.Forms.LinkLabel
End Class
