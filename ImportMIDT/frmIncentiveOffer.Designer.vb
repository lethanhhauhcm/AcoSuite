<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentiveOffer
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
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboShortName = New System.Windows.Forms.ComboBox()
        Me.dgFormula = New System.Windows.Forms.DataGridView()
        Me.dgOffer = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPIC = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboValidFrom = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboValidTo = New System.Windows.Forms.ComboBox()
        Me.lbkNew = New System.Windows.Forms.LinkLabel()
        Me.lbkCopy2Others = New System.Windows.Forms.LinkLabel()
        Me.lbkEdit = New System.Windows.Forms.LinkLabel()
        Me.lbkDelete = New System.Windows.Forms.LinkLabel()
        Me.lbkApprove = New System.Windows.Forms.LinkLabel()
        Me.lbkReject = New System.Windows.Forms.LinkLabel()
        Me.chkManualCheckRequired = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbkCloneWzNewValidity = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboObject = New System.Windows.Forms.ComboBox()
        CType(Me.dgFormula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgOffer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(925, 23)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 19
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(828, 23)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 17
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-1, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Customer"
        '
        'cboShortName
        '
        Me.cboShortName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboShortName.FormattingEnabled = True
        Me.cboShortName.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboShortName.Location = New System.Drawing.Point(2, 25)
        Me.cboShortName.Name = "cboShortName"
        Me.cboShortName.Size = New System.Drawing.Size(121, 21)
        Me.cboShortName.TabIndex = 14
        '
        'dgFormula
        '
        Me.dgFormula.AllowUserToAddRows = False
        Me.dgFormula.AllowUserToDeleteRows = False
        Me.dgFormula.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFormula.Location = New System.Drawing.Point(2, 336)
        Me.dgFormula.Name = "dgFormula"
        Me.dgFormula.ReadOnly = True
        Me.dgFormula.Size = New System.Drawing.Size(1012, 300)
        Me.dgFormula.TabIndex = 18
        '
        'dgOffer
        '
        Me.dgOffer.AllowUserToAddRows = False
        Me.dgOffer.AllowUserToDeleteRows = False
        Me.dgOffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOffer.Location = New System.Drawing.Point(2, 52)
        Me.dgOffer.Name = "dgOffer"
        Me.dgOffer.ReadOnly = True
        Me.dgOffer.Size = New System.Drawing.Size(1012, 278)
        Me.dgOffer.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(126, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "PIC"
        '
        'cboPIC
        '
        Me.cboPIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPIC.FormattingEnabled = True
        Me.cboPIC.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboPIC.Location = New System.Drawing.Point(129, 25)
        Me.cboPIC.Name = "cboPIC"
        Me.cboPIC.Size = New System.Drawing.Size(121, 21)
        Me.cboPIC.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(253, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OK", "--", "RJ"})
        Me.cboStatus.Location = New System.Drawing.Point(256, 23)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(50, 21)
        Me.cboStatus.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(430, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "ValidFrom"
        '
        'cboValidFrom
        '
        Me.cboValidFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidFrom.FormattingEnabled = True
        Me.cboValidFrom.Location = New System.Drawing.Point(433, 25)
        Me.cboValidFrom.Name = "cboValidFrom"
        Me.cboValidFrom.Size = New System.Drawing.Size(121, 21)
        Me.cboValidFrom.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(557, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "ValidTo"
        '
        'cboValidTo
        '
        Me.cboValidTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidTo.FormattingEnabled = True
        Me.cboValidTo.Location = New System.Drawing.Point(560, 25)
        Me.cboValidTo.Name = "cboValidTo"
        Me.cboValidTo.Size = New System.Drawing.Size(121, 21)
        Me.cboValidTo.TabIndex = 30
        '
        'lbkNew
        '
        Me.lbkNew.AutoSize = True
        Me.lbkNew.Location = New System.Drawing.Point(-1, 651)
        Me.lbkNew.Name = "lbkNew"
        Me.lbkNew.Size = New System.Drawing.Size(29, 13)
        Me.lbkNew.TabIndex = 32
        Me.lbkNew.TabStop = True
        Me.lbkNew.Text = "New"
        '
        'lbkCopy2Others
        '
        Me.lbkCopy2Others.AutoSize = True
        Me.lbkCopy2Others.Location = New System.Drawing.Point(34, 651)
        Me.lbkCopy2Others.Name = "lbkCopy2Others"
        Me.lbkCopy2Others.Size = New System.Drawing.Size(68, 13)
        Me.lbkCopy2Others.TabIndex = 33
        Me.lbkCopy2Others.TabStop = True
        Me.lbkCopy2Others.Text = "Copy2Others"
        Me.lbkCopy2Others.Visible = False
        '
        'lbkEdit
        '
        Me.lbkEdit.AutoSize = True
        Me.lbkEdit.Location = New System.Drawing.Point(108, 651)
        Me.lbkEdit.Name = "lbkEdit"
        Me.lbkEdit.Size = New System.Drawing.Size(25, 13)
        Me.lbkEdit.TabIndex = 34
        Me.lbkEdit.TabStop = True
        Me.lbkEdit.Text = "Edit"
        '
        'lbkDelete
        '
        Me.lbkDelete.AutoSize = True
        Me.lbkDelete.Location = New System.Drawing.Point(139, 651)
        Me.lbkDelete.Name = "lbkDelete"
        Me.lbkDelete.Size = New System.Drawing.Size(38, 13)
        Me.lbkDelete.TabIndex = 35
        Me.lbkDelete.TabStop = True
        Me.lbkDelete.Text = "Delete"
        Me.lbkDelete.Visible = False
        '
        'lbkApprove
        '
        Me.lbkApprove.AutoSize = True
        Me.lbkApprove.Location = New System.Drawing.Point(799, 651)
        Me.lbkApprove.Name = "lbkApprove"
        Me.lbkApprove.Size = New System.Drawing.Size(47, 13)
        Me.lbkApprove.TabIndex = 36
        Me.lbkApprove.TabStop = True
        Me.lbkApprove.Text = "Approve"
        '
        'lbkReject
        '
        Me.lbkReject.AutoSize = True
        Me.lbkReject.Location = New System.Drawing.Point(852, 651)
        Me.lbkReject.Name = "lbkReject"
        Me.lbkReject.Size = New System.Drawing.Size(38, 13)
        Me.lbkReject.TabIndex = 37
        Me.lbkReject.TabStop = True
        Me.lbkReject.Text = "Reject"
        '
        'chkManualCheckRequired
        '
        Me.chkManualCheckRequired.AutoSize = True
        Me.chkManualCheckRequired.Location = New System.Drawing.Point(687, 25)
        Me.chkManualCheckRequired.Name = "chkManualCheckRequired"
        Me.chkManualCheckRequired.Size = New System.Drawing.Size(135, 17)
        Me.chkManualCheckRequired.TabIndex = 38
        Me.chkManualCheckRequired.Text = "ManualCheckRequired"
        Me.chkManualCheckRequired.ThreeState = True
        Me.chkManualCheckRequired.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(564, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 39
        '
        'lbkCloneWzNewValidity
        '
        Me.lbkCloneWzNewValidity.AutoSize = True
        Me.lbkCloneWzNewValidity.Location = New System.Drawing.Point(182, 651)
        Me.lbkCloneWzNewValidity.Name = "lbkCloneWzNewValidity"
        Me.lbkCloneWzNewValidity.Size = New System.Drawing.Size(105, 13)
        Me.lbkCloneWzNewValidity.TabIndex = 40
        Me.lbkCloneWzNewValidity.TabStop = True
        Me.lbkCloneWzNewValidity.Text = "CloneWzNewValidity"
        Me.lbkCloneWzNewValidity.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(311, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Object"
        '
        'cboObject
        '
        Me.cboObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObject.FormattingEnabled = True
        Me.cboObject.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboObject.Location = New System.Drawing.Point(314, 23)
        Me.cboObject.Name = "cboObject"
        Me.cboObject.Size = New System.Drawing.Size(113, 21)
        Me.cboObject.TabIndex = 41
        '
        'frmIncentiveOffer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 673)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboObject)
        Me.Controls.Add(Me.lbkCloneWzNewValidity)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkManualCheckRequired)
        Me.Controls.Add(Me.lbkReject)
        Me.Controls.Add(Me.lbkApprove)
        Me.Controls.Add(Me.lbkDelete)
        Me.Controls.Add(Me.lbkEdit)
        Me.Controls.Add(Me.lbkCopy2Others)
        Me.Controls.Add(Me.lbkNew)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboValidTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboValidFrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPIC)
        Me.Controls.Add(Me.dgOffer)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboShortName)
        Me.Controls.Add(Me.dgFormula)
        Me.Name = "frmIncentiveOffer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IncentiveOffer"
        CType(Me.dgFormula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgOffer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboShortName As System.Windows.Forms.ComboBox
    Friend WithEvents dgFormula As System.Windows.Forms.DataGridView
    Friend WithEvents dgOffer As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPIC As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboValidFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboValidTo As System.Windows.Forms.ComboBox
    Friend WithEvents lbkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkCopy2Others As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkEdit As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkApprove As System.Windows.Forms.LinkLabel
    Friend WithEvents lbkReject As System.Windows.Forms.LinkLabel
    Friend WithEvents chkManualCheckRequired As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbkCloneWzNewValidity As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents cboObject As ComboBox
End Class
