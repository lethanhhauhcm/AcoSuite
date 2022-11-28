<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCloneWzNewValidity
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
        Me.dgOffer = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCustomers = New System.Windows.Forms.ComboBox()
        Me.cboValidTo = New System.Windows.Forms.ComboBox()
        Me.cboValidFrom = New System.Windows.Forms.ComboBox()
        Me.lbkCopy = New System.Windows.Forms.LinkLabel()
        CType(Me.dgOffer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgOffer
        '
        Me.dgOffer.AllowUserToAddRows = False
        Me.dgOffer.AllowUserToDeleteRows = False
        Me.dgOffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOffer.Location = New System.Drawing.Point(1, 43)
        Me.dgOffer.Name = "dgOffer"
        Me.dgOffer.Size = New System.Drawing.Size(1012, 278)
        Me.dgOffer.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "NewCustomer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(309, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "NewValidity"
        '
        'cboCustomers
        '
        Me.cboCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomers.FormattingEnabled = True
        Me.cboCustomers.Location = New System.Drawing.Point(77, 1)
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.Size = New System.Drawing.Size(168, 21)
        Me.cboCustomers.TabIndex = 27
        '
        'cboValidTo
        '
        Me.cboValidTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidTo.FormattingEnabled = True
        Me.cboValidTo.Location = New System.Drawing.Point(504, 1)
        Me.cboValidTo.Name = "cboValidTo"
        Me.cboValidTo.Size = New System.Drawing.Size(121, 21)
        Me.cboValidTo.TabIndex = 32
        '
        'cboValidFrom
        '
        Me.cboValidFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidFrom.FormattingEnabled = True
        Me.cboValidFrom.Location = New System.Drawing.Point(377, 1)
        Me.cboValidFrom.Name = "cboValidFrom"
        Me.cboValidFrom.Size = New System.Drawing.Size(121, 21)
        Me.cboValidFrom.TabIndex = 31
        '
        'lbkCopy
        '
        Me.lbkCopy.AutoSize = True
        Me.lbkCopy.Location = New System.Drawing.Point(631, 9)
        Me.lbkCopy.Name = "lbkCopy"
        Me.lbkCopy.Size = New System.Drawing.Size(31, 13)
        Me.lbkCopy.TabIndex = 33
        Me.lbkCopy.TabStop = True
        Me.lbkCopy.Text = "Copy"
        '
        'frmCloneWzNewValidity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 673)
        Me.Controls.Add(Me.lbkCopy)
        Me.Controls.Add(Me.cboValidTo)
        Me.Controls.Add(Me.cboValidFrom)
        Me.Controls.Add(Me.cboCustomers)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgOffer)
        Me.Name = "frmCloneWzNewValidity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CloneWzNewValidity"
        CType(Me.dgOffer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgOffer As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCustomers As System.Windows.Forms.ComboBox
    Friend WithEvents cboValidTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboValidFrom As System.Windows.Forms.ComboBox
    Friend WithEvents lbkCopy As System.Windows.Forms.LinkLabel
End Class
