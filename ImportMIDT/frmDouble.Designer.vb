<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDouble
    Inherits AcoSuite.frmSingle

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
    <System.Diagnostics.DebuggerStepThrough()>
    Protected Sub InitializeComponent()
        Me.pnBody = New System.Windows.Forms.Panel()
        Me.dgvBody = New System.Windows.Forms.DataGridView()
        Me.pnFoot = New System.Windows.Forms.Panel()
        Me.pnMain.SuspendLayout()
        Me.tcMain.SuspendLayout()
        Me.tpList.SuspendLayout()
        Me.tpInput.SuspendLayout()
        Me.tpSearch.SuspendLayout()
        Me.pnMenu.SuspendLayout()
        CType(Me.FDsMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBody.SuspendLayout()
        CType(Me.dgvBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnMain
        '
        Me.pnMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnMain.Size = New System.Drawing.Size(800, 238)
        '
        'tcMain
        '
        Me.tcMain.Size = New System.Drawing.Size(800, 238)
        '
        'tpList
        '
        Me.tpList.Size = New System.Drawing.Size(792, 212)
        '
        'tpInput
        '
        Me.tpInput.Size = New System.Drawing.Size(792, 212)
        '
        'tpSearch
        '
        Me.tpSearch.Size = New System.Drawing.Size(792, 212)
        '
        'llbCancel_2
        '
        '
        'llbSearch_2
        '
        '
        'llbSearch
        '
        '
        'pnGrid
        '
        Me.pnGrid.Size = New System.Drawing.Size(786, 182)
        '
        'pnBody
        '
        Me.pnBody.Controls.Add(Me.dgvBody)
        Me.pnBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBody.Location = New System.Drawing.Point(0, 238)
        Me.pnBody.Name = "pnBody"
        Me.pnBody.Size = New System.Drawing.Size(800, 175)
        Me.pnBody.TabIndex = 1
        '
        'dgvBody
        '
        Me.dgvBody.AllowUserToAddRows = False
        Me.dgvBody.AllowUserToDeleteRows = False
        Me.dgvBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBody.Location = New System.Drawing.Point(0, 0)
        Me.dgvBody.Name = "dgvBody"
        Me.dgvBody.ReadOnly = True
        Me.dgvBody.Size = New System.Drawing.Size(800, 175)
        Me.dgvBody.TabIndex = 0
        '
        'pnFoot
        '
        Me.pnFoot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnFoot.Location = New System.Drawing.Point(0, 413)
        Me.pnFoot.Name = "pnFoot"
        Me.pnFoot.Size = New System.Drawing.Size(800, 37)
        Me.pnFoot.TabIndex = 2
        '
        'frmDouble
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnBody)
        Me.Controls.Add(Me.pnFoot)
        Me.Name = "frmDouble"
        Me.Text = "frmDouble"
        Me.Controls.SetChildIndex(Me.pnFoot, 0)
        Me.Controls.SetChildIndex(Me.pnMain, 0)
        Me.Controls.SetChildIndex(Me.pnBody, 0)
        Me.pnMain.ResumeLayout(False)
        Me.tcMain.ResumeLayout(False)
        Me.tpList.ResumeLayout(False)
        Me.tpInput.ResumeLayout(False)
        Me.tpInput.PerformLayout()
        Me.tpSearch.ResumeLayout(False)
        Me.tpSearch.PerformLayout()
        Me.pnMenu.ResumeLayout(False)
        Me.pnMenu.PerformLayout()
        CType(Me.FDsMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBody.ResumeLayout(False)
        CType(Me.dgvBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents pnFoot As Panel
    Protected WithEvents pnBody As Panel
    Protected WithEvents dgvBody As DataGridView
End Class
