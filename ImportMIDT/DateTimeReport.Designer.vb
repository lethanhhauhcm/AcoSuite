<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateTimeReport
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
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbbWhere = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupOfficeID = New System.Windows.Forms.GroupBox()
        Me.Hide = New System.Windows.Forms.RadioButton()
        Me.Show = New System.Windows.Forms.RadioButton()
        Me.Confirm = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupOfficeID.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Từ tháng: "
        '
        'FromDate
        '
        Me.FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FromDate.Location = New System.Drawing.Point(143, 48)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(200, 22)
        Me.FromDate.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(139, 255)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 55)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbbWhere
        '
        Me.cbbWhere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbWhere.FormattingEnabled = True
        Me.cbbWhere.Items.AddRange(New Object() {"All", "SGN", "HAN", "DAD"})
        Me.cbbWhere.Location = New System.Drawing.Point(139, 134)
        Me.cbbWhere.Name = "cbbWhere"
        Me.cbbWhere.Size = New System.Drawing.Size(121, 21)
        Me.cbbWhere.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(70, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Khu vực:"
        '
        'GroupOfficeID
        '
        Me.GroupOfficeID.Controls.Add(Me.Hide)
        Me.GroupOfficeID.Controls.Add(Me.Show)
        Me.GroupOfficeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupOfficeID.Location = New System.Drawing.Point(73, 179)
        Me.GroupOfficeID.Name = "GroupOfficeID"
        Me.GroupOfficeID.Size = New System.Drawing.Size(271, 47)
        Me.GroupOfficeID.TabIndex = 7
        Me.GroupOfficeID.TabStop = False
        Me.GroupOfficeID.Text = "OfficeID"
        '
        'Hide
        '
        Me.Hide.AutoSize = True
        Me.Hide.Location = New System.Drawing.Point(159, 21)
        Me.Hide.Name = "Hide"
        Me.Hide.Size = New System.Drawing.Size(44, 20)
        Me.Hide.TabIndex = 1
        Me.Hide.TabStop = True
        Me.Hide.Text = "Ẩn"
        Me.Hide.UseVisualStyleBackColor = True
        '
        'Show
        '
        Me.Show.AutoSize = True
        Me.Show.Location = New System.Drawing.Point(71, 21)
        Me.Show.Name = "Show"
        Me.Show.Size = New System.Drawing.Size(58, 20)
        Me.Show.TabIndex = 0
        Me.Show.TabStop = True
        Me.Show.Text = "Hiện"
        Me.Show.UseVisualStyleBackColor = True
        '
        'Confirm
        '
        Me.Confirm.AutoSize = True
        Me.Confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Confirm.Location = New System.Drawing.Point(283, 134)
        Me.Confirm.Name = "Confirm"
        Me.Confirm.Size = New System.Drawing.Size(58, 20)
        Me.Confirm.TabIndex = 8
        Me.Confirm.Text = "Chốt"
        Me.Confirm.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(61, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Đến tháng: "
        '
        'ToDate
        '
        Me.ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ToDate.Location = New System.Drawing.Point(141, 93)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(200, 22)
        Me.ToDate.TabIndex = 11
        '
        'DateTimeReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 322)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Confirm)
        Me.Controls.Add(Me.GroupOfficeID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbbWhere)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DateTimeReport"
        Me.Text = "DateTimeReport"
        Me.GroupOfficeID.ResumeLayout(False)
        Me.GroupOfficeID.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents FromDate As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents cbbWhere As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupOfficeID As GroupBox
    Friend WithEvents Hide As RadioButton
    Friend WithEvents Show As RadioButton
    Friend WithEvents Confirm As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToDate As DateTimePicker
End Class
