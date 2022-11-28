<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSingle
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
    <System.Diagnostics.DebuggerStepThrough()>
    Protected Sub InitializeComponent()
        Me.pnMain = New System.Windows.Forms.Panel()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpList = New System.Windows.Forms.TabPage()
        Me.pnGrid = New System.Windows.Forms.Panel()
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        Me.pnMenu = New System.Windows.Forms.Panel()
        Me.llbEdit = New System.Windows.Forms.LinkLabel()
        Me.llbDelete = New System.Windows.Forms.LinkLabel()
        Me.llbSearch = New System.Windows.Forms.LinkLabel()
        Me.llbAdd = New System.Windows.Forms.LinkLabel()
        Me.tpInput = New System.Windows.Forms.TabPage()
        Me.llbCancel = New System.Windows.Forms.LinkLabel()
        Me.llbOK = New System.Windows.Forms.LinkLabel()
        Me.tpSearch = New System.Windows.Forms.TabPage()
        Me.llbReset = New System.Windows.Forms.LinkLabel()
        Me.llbCancel_2 = New System.Windows.Forms.LinkLabel()
        Me.llbSearch_2 = New System.Windows.Forms.LinkLabel()
        Me.pnMain.SuspendLayout()
        Me.tcMain.SuspendLayout()
        Me.tpList.SuspendLayout()
        Me.pnGrid.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnMenu.SuspendLayout()
        Me.tpInput.SuspendLayout()
        Me.tpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnMain
        '
        Me.pnMain.Controls.Add(Me.tcMain)
        Me.pnMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnMain.Location = New System.Drawing.Point(0, 0)
        Me.pnMain.Name = "pnMain"
        Me.pnMain.Size = New System.Drawing.Size(800, 450)
        Me.pnMain.TabIndex = 0
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tpList)
        Me.tcMain.Controls.Add(Me.tpInput)
        Me.tcMain.Controls.Add(Me.tpSearch)
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(800, 450)
        Me.tcMain.TabIndex = 0
        '
        'tpList
        '
        Me.tpList.BackColor = System.Drawing.SystemColors.Control
        Me.tpList.Controls.Add(Me.pnGrid)
        Me.tpList.Controls.Add(Me.pnMenu)
        Me.tpList.Location = New System.Drawing.Point(4, 22)
        Me.tpList.Name = "tpList"
        Me.tpList.Padding = New System.Windows.Forms.Padding(3)
        Me.tpList.Size = New System.Drawing.Size(792, 424)
        Me.tpList.TabIndex = 0
        Me.tpList.Text = "List"
        '
        'pnGrid
        '
        Me.pnGrid.Controls.Add(Me.dgvMain)
        Me.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnGrid.Location = New System.Drawing.Point(3, 27)
        Me.pnGrid.Name = "pnGrid"
        Me.pnGrid.Size = New System.Drawing.Size(786, 394)
        Me.pnGrid.TabIndex = 6
        '
        'dgvMain
        '
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMain.Location = New System.Drawing.Point(0, 0)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.ReadOnly = True
        Me.dgvMain.Size = New System.Drawing.Size(786, 394)
        Me.dgvMain.TabIndex = 5
        Me.dgvMain.TabStop = False
        '
        'pnMenu
        '
        Me.pnMenu.Controls.Add(Me.llbEdit)
        Me.pnMenu.Controls.Add(Me.llbDelete)
        Me.pnMenu.Controls.Add(Me.llbSearch)
        Me.pnMenu.Controls.Add(Me.llbAdd)
        Me.pnMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnMenu.Location = New System.Drawing.Point(3, 3)
        Me.pnMenu.Name = "pnMenu"
        Me.pnMenu.Size = New System.Drawing.Size(786, 24)
        Me.pnMenu.TabIndex = 5
        '
        'llbEdit
        '
        Me.llbEdit.AutoSize = True
        Me.llbEdit.Enabled = False
        Me.llbEdit.Location = New System.Drawing.Point(37, 5)
        Me.llbEdit.Name = "llbEdit"
        Me.llbEdit.Size = New System.Drawing.Size(25, 13)
        Me.llbEdit.TabIndex = 5
        Me.llbEdit.TabStop = True
        Me.llbEdit.Text = "Edit"
        '
        'llbDelete
        '
        Me.llbDelete.AutoSize = True
        Me.llbDelete.Enabled = False
        Me.llbDelete.Location = New System.Drawing.Point(68, 5)
        Me.llbDelete.Name = "llbDelete"
        Me.llbDelete.Size = New System.Drawing.Size(38, 13)
        Me.llbDelete.TabIndex = 6
        Me.llbDelete.TabStop = True
        Me.llbDelete.Text = "Delete"
        '
        'llbSearch
        '
        Me.llbSearch.AutoSize = True
        Me.llbSearch.Location = New System.Drawing.Point(145, 5)
        Me.llbSearch.Name = "llbSearch"
        Me.llbSearch.Size = New System.Drawing.Size(41, 13)
        Me.llbSearch.TabIndex = 7
        Me.llbSearch.TabStop = True
        Me.llbSearch.Text = "Search"
        '
        'llbAdd
        '
        Me.llbAdd.AutoSize = True
        Me.llbAdd.Location = New System.Drawing.Point(5, 5)
        Me.llbAdd.Name = "llbAdd"
        Me.llbAdd.Size = New System.Drawing.Size(26, 13)
        Me.llbAdd.TabIndex = 4
        Me.llbAdd.TabStop = True
        Me.llbAdd.Text = "Add"
        '
        'tpInput
        '
        Me.tpInput.BackColor = System.Drawing.SystemColors.Control
        Me.tpInput.Controls.Add(Me.llbCancel)
        Me.tpInput.Controls.Add(Me.llbOK)
        Me.tpInput.Location = New System.Drawing.Point(4, 22)
        Me.tpInput.Name = "tpInput"
        Me.tpInput.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInput.Size = New System.Drawing.Size(792, 424)
        Me.tpInput.TabIndex = 1
        Me.tpInput.Text = "Input"
        '
        'llbCancel
        '
        Me.llbCancel.AutoSize = True
        Me.llbCancel.Location = New System.Drawing.Point(36, 3)
        Me.llbCancel.Name = "llbCancel"
        Me.llbCancel.Size = New System.Drawing.Size(40, 13)
        Me.llbCancel.TabIndex = 1
        Me.llbCancel.TabStop = True
        Me.llbCancel.Text = "Cancel"
        '
        'llbOK
        '
        Me.llbOK.AutoSize = True
        Me.llbOK.Location = New System.Drawing.Point(8, 3)
        Me.llbOK.Name = "llbOK"
        Me.llbOK.Size = New System.Drawing.Size(22, 13)
        Me.llbOK.TabIndex = 0
        Me.llbOK.TabStop = True
        Me.llbOK.Text = "OK"
        '
        'tpSearch
        '
        Me.tpSearch.BackColor = System.Drawing.SystemColors.Control
        Me.tpSearch.Controls.Add(Me.llbReset)
        Me.tpSearch.Controls.Add(Me.llbCancel_2)
        Me.tpSearch.Controls.Add(Me.llbSearch_2)
        Me.tpSearch.Location = New System.Drawing.Point(4, 22)
        Me.tpSearch.Name = "tpSearch"
        Me.tpSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearch.Size = New System.Drawing.Size(792, 424)
        Me.tpSearch.TabIndex = 2
        Me.tpSearch.Text = "Search"
        '
        'llbReset
        '
        Me.llbReset.AutoSize = True
        Me.llbReset.Location = New System.Drawing.Point(153, 3)
        Me.llbReset.Name = "llbReset"
        Me.llbReset.Size = New System.Drawing.Size(35, 13)
        Me.llbReset.TabIndex = 2
        Me.llbReset.TabStop = True
        Me.llbReset.Text = "Reset"
        '
        'llbCancel_2
        '
        Me.llbCancel_2.AutoSize = True
        Me.llbCancel_2.Location = New System.Drawing.Point(53, 3)
        Me.llbCancel_2.Name = "llbCancel_2"
        Me.llbCancel_2.Size = New System.Drawing.Size(40, 13)
        Me.llbCancel_2.TabIndex = 1
        Me.llbCancel_2.TabStop = True
        Me.llbCancel_2.Text = "Cancel"
        '
        'llbSearch_2
        '
        Me.llbSearch_2.AutoSize = True
        Me.llbSearch_2.Location = New System.Drawing.Point(6, 3)
        Me.llbSearch_2.Name = "llbSearch_2"
        Me.llbSearch_2.Size = New System.Drawing.Size(41, 13)
        Me.llbSearch_2.TabIndex = 0
        Me.llbSearch_2.TabStop = True
        Me.llbSearch_2.Text = "Search"
        '
        'frmSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnMain)
        Me.Name = "frmSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSingle"
        Me.pnMain.ResumeLayout(False)
        Me.tcMain.ResumeLayout(False)
        Me.tpList.ResumeLayout(False)
        Me.pnGrid.ResumeLayout(False)
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnMenu.ResumeLayout(False)
        Me.pnMenu.PerformLayout()
        Me.tpInput.ResumeLayout(False)
        Me.tpInput.PerformLayout()
        Me.tpSearch.ResumeLayout(False)
        Me.tpSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Protected WithEvents pnMain As Panel
    Protected WithEvents tcMain As TabControl
    Protected WithEvents tpList As TabPage
    Protected WithEvents tpInput As TabPage
    Protected WithEvents llbCancel As LinkLabel
    Protected WithEvents llbOK As LinkLabel
    Protected WithEvents tpSearch As TabPage
    Protected WithEvents llbReset As LinkLabel
    Protected WithEvents llbCancel_2 As LinkLabel
    Protected WithEvents llbSearch_2 As LinkLabel
    Protected WithEvents pnMenu As Panel
    Protected WithEvents llbEdit As LinkLabel
    Protected WithEvents llbDelete As LinkLabel
    Protected WithEvents llbSearch As LinkLabel
    Protected WithEvents llbAdd As LinkLabel
    Protected WithEvents pnGrid As Panel
    Protected WithEvents dgvMain As DataGridView
End Class
