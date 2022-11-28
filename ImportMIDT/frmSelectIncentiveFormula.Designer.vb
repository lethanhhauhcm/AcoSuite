<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectIncentiveFormula
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
        Me.dgFormula = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboApplyTo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBlockOf = New System.Windows.Forms.ComboBox()
        Me.lbkShowAll = New System.Windows.Forms.LinkLabel()
        CType(Me.dgFormula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgFormula
        '
        Me.dgFormula.AllowUserToAddRows = False
        Me.dgFormula.AllowUserToDeleteRows = False
        Me.dgFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFormula.Location = New System.Drawing.Point(2, 52)
        Me.dgFormula.Name = "dgFormula"
        Me.dgFormula.Size = New System.Drawing.Size(691, 582)
        Me.dgFormula.TabIndex = 18
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(411, 640)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(216, 640)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-1, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Unit"
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Segment", "Ticket"})
        Me.cboUnit.Location = New System.Drawing.Point(2, 25)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(98, 21)
        Me.cboUnit.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(103, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "ApplyTo"
        '
        'cboApplyTo
        '
        Me.cboApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboApplyTo.FormattingEnabled = True
        Me.cboApplyTo.Items.AddRange(New Object() {"Unit", "TimeFrame"})
        Me.cboApplyTo.Location = New System.Drawing.Point(106, 25)
        Me.cboApplyTo.Name = "cboApplyTo"
        Me.cboApplyTo.Size = New System.Drawing.Size(98, 21)
        Me.cboApplyTo.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "BlockOf"
        '
        'cboBlockOf
        '
        Me.cboBlockOf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBlockOf.FormattingEnabled = True
        Me.cboBlockOf.Items.AddRange(New Object() {"1", "50"})
        Me.cboBlockOf.Location = New System.Drawing.Point(211, 25)
        Me.cboBlockOf.Name = "cboBlockOf"
        Me.cboBlockOf.Size = New System.Drawing.Size(98, 21)
        Me.cboBlockOf.TabIndex = 23
        '
        'lbkShowAll
        '
        Me.lbkShowAll.AutoSize = True
        Me.lbkShowAll.Location = New System.Drawing.Point(431, 28)
        Me.lbkShowAll.Name = "lbkShowAll"
        Me.lbkShowAll.Size = New System.Drawing.Size(45, 13)
        Me.lbkShowAll.TabIndex = 25
        Me.lbkShowAll.TabStop = True
        Me.lbkShowAll.Text = "ShowAll"
        '
        'frmSelectIncentiveFormula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 673)
        Me.Controls.Add(Me.lbkShowAll)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboBlockOf)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboApplyTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboUnit)
        Me.Controls.Add(Me.dgFormula)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmSelectIncentiveFormula"
        Me.Text = "SelectIncentiveFormula"
        CType(Me.dgFormula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgFormula As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboApplyTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBlockOf As System.Windows.Forms.ComboBox
    Friend WithEvents lbkShowAll As System.Windows.Forms.LinkLabel
End Class
