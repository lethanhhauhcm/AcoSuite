<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBalance
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.dgrBalance = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lbkNew = New System.Windows.Forms.LinkLabel()
        Me.lbkEdit = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.lbkSearch = New System.Windows.Forms.LinkLabel()
        Me.lbkReset = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboView = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboFOP = New System.Windows.Forms.ComboBox()
        Me.lbkListCustomerNoBalance = New System.Windows.Forms.LinkLabel()
        CType(Me.dgrBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Customer"
        '
        'cboShortName
        '
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Location = New System.Drawing.Point(15, 27)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(168, 21)
        Me.cboShortName.TabIndex = 7
        '
        'dgrBalance
        '
        Me.dgrBalance.AllowUserToAddRows = False
        Me.dgrBalance.AllowUserToDeleteRows = False
        Me.dgrBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgrBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrBalance.Location = New System.Drawing.Point(15, 54)
        Me.dgrBalance.Name = "dgrBalance"
        Me.dgrBalance.ReadOnly = True
        Me.dgrBalance.Size = New System.Drawing.Size(981, 482)
        Me.dgrBalance.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OK", "RR"})
        Me.cboStatus.Location = New System.Drawing.Point(191, 27)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(46, 21)
        Me.cboStatus.TabIndex = 10
        '
        'lbkNew
        '
        Me.lbkNew.AutoSize = True
        Me.lbkNew.Location = New System.Drawing.Point(19, 539)
        Me.lbkNew.Name = "lbkNew"
        Me.lbkNew.Size = New System.Drawing.Size(29, 13)
        Me.lbkNew.TabIndex = 12
        Me.lbkNew.TabStop = True
        Me.lbkNew.Text = "New"
        '
        'lbkEdit
        '
        Me.lbkEdit.AutoSize = True
        Me.lbkEdit.Location = New System.Drawing.Point(65, 539)
        Me.lbkEdit.Name = "lbkEdit"
        Me.lbkEdit.Size = New System.Drawing.Size(25, 13)
        Me.lbkEdit.TabIndex = 13
        Me.lbkEdit.TabStop = True
        Me.lbkEdit.Text = "Edit"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(106, 539)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 14
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'lbkSearch
        '
        Me.lbkSearch.AutoSize = True
        Me.lbkSearch.Location = New System.Drawing.Point(559, 30)
        Me.lbkSearch.Name = "lbkSearch"
        Me.lbkSearch.Size = New System.Drawing.Size(41, 13)
        Me.lbkSearch.TabIndex = 15
        Me.lbkSearch.TabStop = True
        Me.lbkSearch.Text = "Search"
        '
        'lbkReset
        '
        Me.lbkReset.AutoSize = True
        Me.lbkReset.Location = New System.Drawing.Point(634, 30)
        Me.lbkReset.Name = "lbkReset"
        Me.lbkReset.Size = New System.Drawing.Size(35, 13)
        Me.lbkReset.TabIndex = 16
        Me.lbkReset.TabStop = True
        Me.lbkReset.Text = "Reset"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(295, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "View"
        '
        'cboView
        '
        Me.cboView.FormattingEnabled = True
        Me.cboView.Items.AddRange(New Object() {"LastBalance", "Transactions"})
        Me.cboView.Location = New System.Drawing.Point(298, 27)
        Me.cboView.Name = "cboView"
        Me.cboView.Size = New System.Drawing.Size(107, 21)
        Me.cboView.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "FOP"
        '
        'cboFOP
        '
        Me.cboFOP.FormattingEnabled = True
        Me.cboFOP.Items.AddRange(New Object() {"BTF", "CSH", "COF", "---"})
        Me.cboFOP.Location = New System.Drawing.Point(246, 27)
        Me.cboFOP.Name = "cboFOP"
        Me.cboFOP.Size = New System.Drawing.Size(46, 21)
        Me.cboFOP.TabIndex = 19
        '
        'lbkListCustomerNoBalance
        '
        Me.lbkListCustomerNoBalance.AutoSize = True
        Me.lbkListCustomerNoBalance.Location = New System.Drawing.Point(809, 539)
        Me.lbkListCustomerNoBalance.Name = "lbkListCustomerNoBalance"
        Me.lbkListCustomerNoBalance.Size = New System.Drawing.Size(120, 13)
        Me.lbkListCustomerNoBalance.TabIndex = 21
        Me.lbkListCustomerNoBalance.TabStop = True
        Me.lbkListCustomerNoBalance.Text = "ListCustomerNoBalance"
        '
        'frmBalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.lbkListCustomerNoBalance)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboFOP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboView)
        Me.Controls.Add(Me.lbkReset)
        Me.Controls.Add(Me.lbkSearch)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkEdit)
        Me.Controls.Add(Me.lbkNew)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.dgrBalance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboShortName)
        Me.Name = "frmBalance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Balance"
        CType(Me.dgrBalance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboShortName As ComboBox
    Friend WithEvents dgrBalance As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lbkNew As LinkLabel
    Friend WithEvents lbkEdit As LinkLabel
    Friend WithEvents lbkDelete As LinkLabel
    Friend WithEvents lbkSearch As LinkLabel
    Friend WithEvents lbkReset As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents cboView As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboFOP As ComboBox
    Friend WithEvents lbkListCustomerNoBalance As LinkLabel
End Class
