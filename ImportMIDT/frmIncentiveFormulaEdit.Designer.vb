<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentiveFormulaEdit
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.lblCustomerTarget = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVND = New System.Windows.Forms.TextBox()
        Me.txtObjectTarget = New System.Windows.Forms.TextBox()
        Me.txtCustomerTarget = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCustomerTimeFrame = New System.Windows.Forms.ComboBox()
        Me.lblBkgOffcId = New System.Windows.Forms.Label()
        Me.cboBkgOffcId = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboApplyTo = New System.Windows.Forms.ComboBox()
        Me.BlockOf = New System.Windows.Forms.Label()
        Me.cboBlockOf = New System.Windows.Forms.ComboBox()
        Me.lblTktOffcId = New System.Windows.Forms.Label()
        Me.cboTktOffcId = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(253, 188)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(99, 188)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Unit"
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Segment", "Ticket"})
        Me.cboUnit.Location = New System.Drawing.Point(5, 63)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(121, 21)
        Me.cboUnit.TabIndex = 1
        '
        'lblCustomerTarget
        '
        Me.lblCustomerTarget.AutoSize = True
        Me.lblCustomerTarget.Location = New System.Drawing.Point(7, 87)
        Me.lblCustomerTarget.Name = "lblCustomerTarget"
        Me.lblCustomerTarget.Size = New System.Drawing.Size(82, 13)
        Me.lblCustomerTarget.TabIndex = 20
        Me.lblCustomerTarget.Text = "CustomerTarget"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(259, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "ObjectTarget"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(134, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "VND"
        '
        'txtVND
        '
        Me.txtVND.Location = New System.Drawing.Point(135, 63)
        Me.txtVND.Name = "txtVND"
        Me.txtVND.Size = New System.Drawing.Size(118, 20)
        Me.txtVND.TabIndex = 2
        '
        'txtObjectTarget
        '
        Me.txtObjectTarget.Location = New System.Drawing.Point(262, 63)
        Me.txtObjectTarget.Name = "txtObjectTarget"
        Me.txtObjectTarget.Size = New System.Drawing.Size(118, 20)
        Me.txtObjectTarget.TabIndex = 3
        Me.txtObjectTarget.Text = "0"
        '
        'txtCustomerTarget
        '
        Me.txtCustomerTarget.Location = New System.Drawing.Point(10, 103)
        Me.txtCustomerTarget.Name = "txtCustomerTarget"
        Me.txtCustomerTarget.Size = New System.Drawing.Size(118, 20)
        Me.txtCustomerTarget.TabIndex = 4
        Me.txtCustomerTarget.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(134, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "CustomeTimeFrame"
        '
        'cboCustomerTimeFrame
        '
        Me.cboCustomerTimeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomerTimeFrame.FormattingEnabled = True
        Me.cboCustomerTimeFrame.Items.AddRange(New Object() {"Month", "Quarter", "HalfYear", "Year"})
        Me.cboCustomerTimeFrame.Location = New System.Drawing.Point(137, 103)
        Me.cboCustomerTimeFrame.Name = "cboCustomerTimeFrame"
        Me.cboCustomerTimeFrame.Size = New System.Drawing.Size(116, 21)
        Me.cboCustomerTimeFrame.TabIndex = 5
        '
        'lblBkgOffcId
        '
        Me.lblBkgOffcId.AutoSize = True
        Me.lblBkgOffcId.Location = New System.Drawing.Point(7, 129)
        Me.lblBkgOffcId.Name = "lblBkgOffcId"
        Me.lblBkgOffcId.Size = New System.Drawing.Size(55, 13)
        Me.lblBkgOffcId.TabIndex = 27
        Me.lblBkgOffcId.Text = "BkgOffcId"
        '
        'cboBkgOffcId
        '
        Me.cboBkgOffcId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBkgOffcId.FormattingEnabled = True
        Me.cboBkgOffcId.Items.AddRange(New Object() {"All", "Own", "NonOwn"})
        Me.cboBkgOffcId.Location = New System.Drawing.Point(10, 145)
        Me.cboBkgOffcId.Name = "cboBkgOffcId"
        Me.cboBkgOffcId.Size = New System.Drawing.Size(121, 21)
        Me.cboBkgOffcId.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "ApplyTo"
        '
        'cboApplyTo
        '
        Me.cboApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboApplyTo.FormattingEnabled = True
        Me.cboApplyTo.Items.AddRange(New Object() {"Unit", "TimeFrame"})
        Me.cboApplyTo.Location = New System.Drawing.Point(7, 23)
        Me.cboApplyTo.Name = "cboApplyTo"
        Me.cboApplyTo.Size = New System.Drawing.Size(121, 21)
        Me.cboApplyTo.TabIndex = 0
        '
        'BlockOf
        '
        Me.BlockOf.AutoSize = True
        Me.BlockOf.Location = New System.Drawing.Point(134, 7)
        Me.BlockOf.Name = "BlockOf"
        Me.BlockOf.Size = New System.Drawing.Size(45, 13)
        Me.BlockOf.TabIndex = 31
        Me.BlockOf.Text = "BlockOf"
        '
        'cboBlockOf
        '
        Me.cboBlockOf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBlockOf.FormattingEnabled = True
        Me.cboBlockOf.Items.AddRange(New Object() {"1", "50"})
        Me.cboBlockOf.Location = New System.Drawing.Point(137, 23)
        Me.cboBlockOf.Name = "cboBlockOf"
        Me.cboBlockOf.Size = New System.Drawing.Size(121, 21)
        Me.cboBlockOf.TabIndex = 30
        '
        'lblTktOffcId
        '
        Me.lblTktOffcId.AutoSize = True
        Me.lblTktOffcId.Location = New System.Drawing.Point(134, 129)
        Me.lblTktOffcId.Name = "lblTktOffcId"
        Me.lblTktOffcId.Size = New System.Drawing.Size(52, 13)
        Me.lblTktOffcId.TabIndex = 33
        Me.lblTktOffcId.Text = "TktOffcId"
        '
        'cboTktOffcId
        '
        Me.cboTktOffcId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTktOffcId.FormattingEnabled = True
        Me.cboTktOffcId.Items.AddRange(New Object() {"All", "Own", "NonOwn"})
        Me.cboTktOffcId.Location = New System.Drawing.Point(137, 145)
        Me.cboTktOffcId.Name = "cboTktOffcId"
        Me.cboTktOffcId.Size = New System.Drawing.Size(121, 21)
        Me.cboTktOffcId.TabIndex = 32
        '
        'frmIncentiveFormulaEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 223)
        Me.Controls.Add(Me.lblTktOffcId)
        Me.Controls.Add(Me.cboTktOffcId)
        Me.Controls.Add(Me.BlockOf)
        Me.Controls.Add(Me.cboBlockOf)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboApplyTo)
        Me.Controls.Add(Me.lblBkgOffcId)
        Me.Controls.Add(Me.cboBkgOffcId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCustomerTimeFrame)
        Me.Controls.Add(Me.txtCustomerTarget)
        Me.Controls.Add(Me.txtObjectTarget)
        Me.Controls.Add(Me.txtVND)
        Me.Controls.Add(Me.lblCustomerTarget)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboUnit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmIncentiveFormulaEdit"
        Me.Text = "frmIncentiveFormulaEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents lblCustomerTarget As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVND As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectTarget As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerTarget As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerTimeFrame As System.Windows.Forms.ComboBox
    Friend WithEvents lblBkgOffcId As System.Windows.Forms.Label
    Friend WithEvents cboBkgOffcId As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboApplyTo As System.Windows.Forms.ComboBox
    Friend WithEvents BlockOf As System.Windows.Forms.Label
    Friend WithEvents cboBlockOf As System.Windows.Forms.ComboBox
    Friend WithEvents lblTktOffcId As System.Windows.Forms.Label
    Friend WithEvents cboTktOffcId As System.Windows.Forms.ComboBox
End Class
