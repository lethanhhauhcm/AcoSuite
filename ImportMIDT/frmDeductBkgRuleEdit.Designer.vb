<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDeductBkgRuleEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    Private Sub InitializeComponent()
        Me.txtSignIn = New System.Windows.Forms.TextBox()
        Me.txtOffcId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRecId = New System.Windows.Forms.TextBox()
        Me.dgrOffcSignIn = New System.Windows.Forms.DataGridView()
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.lbkRemove = New System.Windows.Forms.LinkLabel()
        Me.lbkSave = New System.Windows.Forms.LinkLabel()
        Me.txtPct = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSegment = New System.Windows.Forms.TextBox()
        Me.lblSegment = New System.Windows.Forms.Label()
        Me.txtTimeFrame = New System.Windows.Forms.Label()
        Me.cboTimeFrame = New System.Windows.Forms.ComboBox()
        CType(Me.dgrOffcSignIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSignIn
        '
        Me.txtSignIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSignIn.Location = New System.Drawing.Point(109, 139)
        Me.txtSignIn.Name = "txtSignIn"
        Me.txtSignIn.Size = New System.Drawing.Size(77, 20)
        Me.txtSignIn.TabIndex = 4
        '
        'txtOffcId
        '
        Me.txtOffcId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOffcId.Location = New System.Drawing.Point(9, 139)
        Me.txtOffcId.Name = "txtOffcId"
        Me.txtOffcId.Size = New System.Drawing.Size(77, 20)
        Me.txtOffcId.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "SignIn"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "OffciId"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(106, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "ToDate"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "FromDate"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd MMM yy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(9, 55)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpFromDate.TabIndex = 0
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd MMM yy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(109, 53)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpToDate.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(150, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "RecId"
        '
        'txtRecId
        '
        Me.txtRecId.Location = New System.Drawing.Point(209, 2)
        Me.txtRecId.Name = "txtRecId"
        Me.txtRecId.ReadOnly = True
        Me.txtRecId.Size = New System.Drawing.Size(77, 20)
        Me.txtRecId.TabIndex = 56
        Me.txtRecId.Text = "0"
        '
        'dgrOffcSignIn
        '
        Me.dgrOffcSignIn.AllowUserToAddRows = False
        Me.dgrOffcSignIn.AllowUserToDeleteRows = False
        Me.dgrOffcSignIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrOffcSignIn.Location = New System.Drawing.Point(9, 165)
        Me.dgrOffcSignIn.Name = "dgrOffcSignIn"
        Me.dgrOffcSignIn.ReadOnly = True
        Me.dgrOffcSignIn.Size = New System.Drawing.Size(280, 171)
        Me.dgrOffcSignIn.TabIndex = 57
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(206, 146)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 5
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'lbkRemove
        '
        Me.lbkRemove.AutoSize = True
        Me.lbkRemove.Location = New System.Drawing.Point(16, 339)
        Me.lbkRemove.Name = "lbkRemove"
        Me.lbkRemove.Size = New System.Drawing.Size(47, 13)
        Me.lbkRemove.TabIndex = 6
        Me.lbkRemove.TabStop = True
        Me.lbkRemove.Text = "Remove"
        '
        'lbkSave
        '
        Me.lbkSave.AutoSize = True
        Me.lbkSave.Location = New System.Drawing.Point(106, 339)
        Me.lbkSave.Name = "lbkSave"
        Me.lbkSave.Size = New System.Drawing.Size(32, 13)
        Me.lbkSave.TabIndex = 7
        Me.lbkSave.TabStop = True
        Me.lbkSave.Text = "Save"
        '
        'txtPct
        '
        Me.txtPct.Location = New System.Drawing.Point(9, 100)
        Me.txtPct.Name = "txtPct"
        Me.txtPct.Size = New System.Drawing.Size(77, 20)
        Me.txtPct.TabIndex = 2
        Me.txtPct.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Percent"
        '
        'txtSegment
        '
        Me.txtSegment.Location = New System.Drawing.Point(109, 100)
        Me.txtSegment.Name = "txtSegment"
        Me.txtSegment.Size = New System.Drawing.Size(77, 20)
        Me.txtSegment.TabIndex = 62
        Me.txtSegment.Text = "0"
        '
        'lblSegment
        '
        Me.lblSegment.AutoSize = True
        Me.lblSegment.Location = New System.Drawing.Point(106, 84)
        Me.lblSegment.Name = "lblSegment"
        Me.lblSegment.Size = New System.Drawing.Size(49, 13)
        Me.lblSegment.TabIndex = 63
        Me.lblSegment.Text = "Segment"
        '
        'txtTimeFrame
        '
        Me.txtTimeFrame.AutoSize = True
        Me.txtTimeFrame.Location = New System.Drawing.Point(206, 84)
        Me.txtTimeFrame.Name = "txtTimeFrame"
        Me.txtTimeFrame.Size = New System.Drawing.Size(59, 13)
        Me.txtTimeFrame.TabIndex = 64
        Me.txtTimeFrame.Text = "TimeFrame"
        '
        'cboTimeFrame
        '
        Me.cboTimeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimeFrame.FormattingEnabled = True
        Me.cboTimeFrame.Items.AddRange(New Object() {"Month", "Quarter", "HalfYear", "Year"})
        Me.cboTimeFrame.Location = New System.Drawing.Point(209, 100)
        Me.cboTimeFrame.Name = "cboTimeFrame"
        Me.cboTimeFrame.Size = New System.Drawing.Size(80, 21)
        Me.cboTimeFrame.TabIndex = 65
        '
        'frmDeductBkgRuleEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 361)
        Me.Controls.Add(Me.cboTimeFrame)
        Me.Controls.Add(Me.txtTimeFrame)
        Me.Controls.Add(Me.txtSegment)
        Me.Controls.Add(Me.lblSegment)
        Me.Controls.Add(Me.txtPct)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbkSave)
        Me.Controls.Add(Me.lbkRemove)
        Me.Controls.Add(Me.lbkAdd)
        Me.Controls.Add(Me.dgrOffcSignIn)
        Me.Controls.Add(Me.txtRecId)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSignIn)
        Me.Controls.Add(Me.txtOffcId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmDeductBkgRuleEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DeductBkgRuleEdit"
        CType(Me.dgrOffcSignIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSignIn As TextBox
    Friend WithEvents txtOffcId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRecId As TextBox
    Friend WithEvents dgrOffcSignIn As DataGridView
    Friend WithEvents lbkAdd As LinkLabel
    Friend WithEvents lbkRemove As LinkLabel
    Friend WithEvents lbkSave As LinkLabel
    Friend WithEvents txtPct As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSegment As TextBox
    Friend WithEvents lblSegment As Label
    Friend WithEvents txtTimeFrame As Label
    Friend WithEvents cboTimeFrame As ComboBox
End Class
