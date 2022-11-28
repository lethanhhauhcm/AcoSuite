<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportMIDT
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.barImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.padImportMonthly = New System.Windows.Forms.ToolStripMenuItem()
        Me.padImportDaily = New System.Windows.Forms.ToolStripMenuItem()
        Me.barUpdateAgt = New System.Windows.Forms.ToolStripMenuItem()
        Me.barDataNoShortNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSumByMonth = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.barNoShortNameMidtMontly = New System.Windows.Forms.ToolStripMenuItem()
        Me.barNoShortNameMidtDaily = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateCustMidtMontly = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateCustMidtDaily = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barImport, Me.barUpdateAgt, Me.barDataNoShortNameToolStripMenuItem, Me.barSumByMonth, Me.TestToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(992, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'barImport
        '
        Me.barImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.padImportMonthly, Me.padImportDaily})
        Me.barImport.Name = "barImport"
        Me.barImport.Size = New System.Drawing.Size(55, 20)
        Me.barImport.Text = "Import"
        '
        'padImportMonthly
        '
        Me.padImportMonthly.Name = "padImportMonthly"
        Me.padImportMonthly.Size = New System.Drawing.Size(155, 22)
        Me.padImportMonthly.Text = "ImportMonthly"
        '
        'padImportDaily
        '
        Me.padImportDaily.Name = "padImportDaily"
        Me.padImportDaily.Size = New System.Drawing.Size(155, 22)
        Me.padImportDaily.Text = "ImportDaily"
        '
        'barUpdateAgt
        '
        Me.barUpdateAgt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateCustMidtMontly, Me.UpdateCustMidtDaily})
        Me.barUpdateAgt.Name = "barUpdateAgt"
        Me.barUpdateAgt.Size = New System.Drawing.Size(76, 20)
        Me.barUpdateAgt.Text = "UpdateAgt"
        '
        'barDataNoShortNameToolStripMenuItem
        '
        Me.barDataNoShortNameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNoShortNameMidtMontly, Me.barNoShortNameMidtDaily})
        Me.barDataNoShortNameToolStripMenuItem.Name = "barDataNoShortNameToolStripMenuItem"
        Me.barDataNoShortNameToolStripMenuItem.Size = New System.Drawing.Size(137, 20)
        Me.barDataNoShortNameToolStripMenuItem.Text = "ListDataNoShortName"
        '
        'barSumByMonth
        '
        Me.barSumByMonth.Name = "barSumByMonth"
        Me.barSumByMonth.Size = New System.Drawing.Size(92, 20)
        Me.barSumByMonth.Text = "SumByMonth"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(534, 9)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'barNoShortNameMidtMontly
        '
        Me.barNoShortNameMidtMontly.Name = "barNoShortNameMidtMontly"
        Me.barNoShortNameMidtMontly.Size = New System.Drawing.Size(180, 22)
        Me.barNoShortNameMidtMontly.Text = "MidtMontly"
        '
        'barNoShortNameMidtDaily
        '
        Me.barNoShortNameMidtDaily.Name = "barNoShortNameMidtDaily"
        Me.barNoShortNameMidtDaily.Size = New System.Drawing.Size(180, 22)
        Me.barNoShortNameMidtDaily.Text = "MidtDaily"
        '
        'UpdateCustMidtMontly
        '
        Me.UpdateCustMidtMontly.Name = "UpdateCustMidtMontly"
        Me.UpdateCustMidtMontly.Size = New System.Drawing.Size(180, 22)
        Me.UpdateCustMidtMontly.Text = "MidtMontly"
        '
        'UpdateCustMidtDaily
        '
        Me.UpdateCustMidtDaily.Name = "UpdateCustMidtDaily"
        Me.UpdateCustMidtDaily.Size = New System.Drawing.Size(180, 22)
        Me.UpdateCustMidtDaily.Text = "MidtDaily"
        '
        'frmImportMIDT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 623)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmImportMIDT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ImportMIDT"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents barImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barUpdateAgt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents barDataNoShortNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barSumByMonth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents padImportMonthly As ToolStripMenuItem
    Friend WithEvents padImportDaily As ToolStripMenuItem
    Friend WithEvents barNoShortNameMidtMontly As ToolStripMenuItem
    Friend WithEvents barNoShortNameMidtDaily As ToolStripMenuItem
    Friend WithEvents UpdateCustMidtMontly As ToolStripMenuItem
    Friend WithEvents UpdateCustMidtDaily As ToolStripMenuItem
End Class
