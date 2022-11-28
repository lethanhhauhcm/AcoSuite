<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMiscDate4OffcId
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
        Me.txtOffcId = New System.Windows.Forms.TextBox()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dgrOffcId = New System.Windows.Forms.DataGridView()
        Me.lbkAdd = New System.Windows.Forms.LinkLabel()
        Me.blkChangeDate = New System.Windows.Forms.LinkLabel()
        CType(Me.dgrOffcId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OffcId"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(114, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "FromDate"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(198, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ToDate"
        '
        'txtOffcId
        '
        Me.txtOffcId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOffcId.Location = New System.Drawing.Point(3, 16)
        Me.txtOffcId.MaxLength = 9
        Me.txtOffcId.Name = "txtOffcId"
        Me.txtOffcId.Size = New System.Drawing.Size(100, 20)
        Me.txtOffcId.TabIndex = 3
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd MMM yy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(117, 16)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(78, 20)
        Me.dtpFromDate.TabIndex = 4
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd MMM yy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(201, 16)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(78, 20)
        Me.dtpToDate.TabIndex = 5
        '
        'dgrOffcId
        '
        Me.dgrOffcId.AllowUserToAddRows = False
        Me.dgrOffcId.AllowUserToDeleteRows = False
        Me.dgrOffcId.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrOffcId.Location = New System.Drawing.Point(3, 42)
        Me.dgrOffcId.Name = "dgrOffcId"
        Me.dgrOffcId.ReadOnly = True
        Me.dgrOffcId.Size = New System.Drawing.Size(577, 496)
        Me.dgrOffcId.TabIndex = 6
        '
        'lbkAdd
        '
        Me.lbkAdd.AutoSize = True
        Me.lbkAdd.Location = New System.Drawing.Point(301, 19)
        Me.lbkAdd.Name = "lbkAdd"
        Me.lbkAdd.Size = New System.Drawing.Size(26, 13)
        Me.lbkAdd.TabIndex = 7
        Me.lbkAdd.TabStop = True
        Me.lbkAdd.Text = "Add"
        '
        'blkChangeDate
        '
        Me.blkChangeDate.AutoSize = True
        Me.blkChangeDate.Location = New System.Drawing.Point(333, 19)
        Me.blkChangeDate.Name = "blkChangeDate"
        Me.blkChangeDate.Size = New System.Drawing.Size(103, 13)
        Me.blkChangeDate.TabIndex = 12
        Me.blkChangeDate.TabStop = True
        Me.blkChangeDate.Text = "ChangeFromToDate"
        '
        'frmMiscDate4OffcId
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 573)
        Me.Controls.Add(Me.blkChangeDate)
        Me.Controls.Add(Me.lbkAdd)
        Me.Controls.Add(Me.dgrOffcId)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.txtOffcId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMiscDate4OffcId"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stop Incentive for OffcId"
        CType(Me.dgrOffcId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOffcId As System.Windows.Forms.TextBox
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgrOffcId As System.Windows.Forms.DataGridView
    Friend WithEvents lbkAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents blkChangeDate As System.Windows.Forms.LinkLabel
End Class
