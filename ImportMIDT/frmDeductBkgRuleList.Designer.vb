<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeductBkgRuleList
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.dtpValidDate = New System.Windows.Forms.DateTimePicker()
        Me.lbkClear = New System.Windows.Forms.LinkLabel()
        Me.lbkSearch = New System.Windows.Forms.LinkLabel()
        Me.dgDeductionRule = New System.Windows.Forms.DataGridView()
        Me.lbkEdit = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.lbkClone = New System.Windows.Forms.LinkLabel()
        Me.lbkNew = New System.Windows.Forms.LinkLabel()
        Me.txtOffcId = New System.Windows.Forms.TextBox()
        Me.txtSignIn = New System.Windows.Forms.TextBox()
        Me.cboDateType = New System.Windows.Forms.ComboBox()
        Me.dgrOffcSignIn = New System.Windows.Forms.DataGridView()
        CType(Me.dgDeductionRule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgrOffcSignIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OffciId"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SignIn"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(203, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OK", "EX", "XX"})
        Me.cboStatus.Location = New System.Drawing.Point(206, 25)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(52, 21)
        Me.cboStatus.TabIndex = 27
        '
        'dtpValidDate
        '
        Me.dtpValidDate.CustomFormat = "dd MMM yy"
        Me.dtpValidDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpValidDate.Location = New System.Drawing.Point(370, 25)
        Me.dtpValidDate.Name = "dtpValidDate"
        Me.dtpValidDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpValidDate.TabIndex = 31
        '
        'lbkClear
        '
        Me.lbkClear.AutoSize = True
        Me.lbkClear.Location = New System.Drawing.Point(554, 33)
        Me.lbkClear.Name = "lbkClear"
        Me.lbkClear.Size = New System.Drawing.Size(31, 13)
        Me.lbkClear.TabIndex = 39
        Me.lbkClear.TabStop = True
        Me.lbkClear.Text = "Clear"
        '
        'lbkSearch
        '
        Me.lbkSearch.AutoSize = True
        Me.lbkSearch.Location = New System.Drawing.Point(507, 33)
        Me.lbkSearch.Name = "lbkSearch"
        Me.lbkSearch.Size = New System.Drawing.Size(41, 13)
        Me.lbkSearch.TabIndex = 38
        Me.lbkSearch.TabStop = True
        Me.lbkSearch.Text = "Search"
        '
        'dgDeductionRule
        '
        Me.dgDeductionRule.AllowUserToAddRows = False
        Me.dgDeductionRule.AllowUserToDeleteRows = False
        Me.dgDeductionRule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgDeductionRule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDeductionRule.Location = New System.Drawing.Point(-4, 52)
        Me.dgDeductionRule.Name = "dgDeductionRule"
        Me.dgDeductionRule.ReadOnly = True
        Me.dgDeductionRule.Size = New System.Drawing.Size(707, 480)
        Me.dgDeductionRule.TabIndex = 40
        '
        'lbkEdit
        '
        Me.lbkEdit.AutoSize = True
        Me.lbkEdit.Location = New System.Drawing.Point(124, 539)
        Me.lbkEdit.Name = "lbkEdit"
        Me.lbkEdit.Size = New System.Drawing.Size(25, 13)
        Me.lbkEdit.TabIndex = 42
        Me.lbkEdit.TabStop = True
        Me.lbkEdit.Text = "Edit"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(77, 539)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 41
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        '
        'lbkClone
        '
        Me.lbkClone.AutoSize = True
        Me.lbkClone.Location = New System.Drawing.Point(35, 539)
        Me.lbkClone.Name = "lbkClone"
        Me.lbkClone.Size = New System.Drawing.Size(34, 13)
        Me.lbkClone.TabIndex = 44
        Me.lbkClone.TabStop = True
        Me.lbkClone.Text = "Clone"
        '
        'lbkNew
        '
        Me.lbkNew.AutoSize = True
        Me.lbkNew.Location = New System.Drawing.Point(0, 539)
        Me.lbkNew.Name = "lbkNew"
        Me.lbkNew.Size = New System.Drawing.Size(29, 13)
        Me.lbkNew.TabIndex = 43
        Me.lbkNew.TabStop = True
        Me.lbkNew.Text = "New"
        '
        'txtOffcId
        '
        Me.txtOffcId.Location = New System.Drawing.Point(3, 25)
        Me.txtOffcId.Name = "txtOffcId"
        Me.txtOffcId.Size = New System.Drawing.Size(77, 20)
        Me.txtOffcId.TabIndex = 45
        '
        'txtSignIn
        '
        Me.txtSignIn.Location = New System.Drawing.Point(103, 25)
        Me.txtSignIn.Name = "txtSignIn"
        Me.txtSignIn.Size = New System.Drawing.Size(77, 20)
        Me.txtSignIn.TabIndex = 46
        '
        'cboDateType
        '
        Me.cboDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDateType.FormattingEnabled = True
        Me.cboDateType.Items.AddRange(New Object() {"ValidOn", "ValidFrom", "ValidTo"})
        Me.cboDateType.Location = New System.Drawing.Point(274, 24)
        Me.cboDateType.Name = "cboDateType"
        Me.cboDateType.Size = New System.Drawing.Size(78, 21)
        Me.cboDateType.TabIndex = 47
        '
        'dgrOffcSignIn
        '
        Me.dgrOffcSignIn.AllowUserToAddRows = False
        Me.dgrOffcSignIn.AllowUserToDeleteRows = False
        Me.dgrOffcSignIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrOffcSignIn.Location = New System.Drawing.Point(709, 52)
        Me.dgrOffcSignIn.Name = "dgrOffcSignIn"
        Me.dgrOffcSignIn.ReadOnly = True
        Me.dgrOffcSignIn.Size = New System.Drawing.Size(263, 480)
        Me.dgrOffcSignIn.TabIndex = 58
        '
        'frmDeductBkgRuleList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.dgrOffcSignIn)
        Me.Controls.Add(Me.cboDateType)
        Me.Controls.Add(Me.txtSignIn)
        Me.Controls.Add(Me.txtOffcId)
        Me.Controls.Add(Me.lbkClone)
        Me.Controls.Add(Me.lbkNew)
        Me.Controls.Add(Me.lbkEdit)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.dgDeductionRule)
        Me.Controls.Add(Me.lbkClear)
        Me.Controls.Add(Me.lbkSearch)
        Me.Controls.Add(Me.dtpValidDate)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmDeductBkgRuleList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DeductBkgRuleList"
        CType(Me.dgDeductionRule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgrOffcSignIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents dtpValidDate As DateTimePicker
    Friend WithEvents lbkClear As LinkLabel
    Friend WithEvents lbkSearch As LinkLabel
    Friend WithEvents dgDeductionRule As DataGridView
    Friend WithEvents lbkEdit As LinkLabel
    Friend WithEvents lbkDelete As LinkLabel
    Friend WithEvents lbkClone As LinkLabel
    Friend WithEvents lbkNew As LinkLabel
    Friend WithEvents txtOffcId As TextBox
    Friend WithEvents txtSignIn As TextBox
    Friend WithEvents cboDateType As ComboBox
    Friend WithEvents dgrOffcSignIn As DataGridView
End Class
