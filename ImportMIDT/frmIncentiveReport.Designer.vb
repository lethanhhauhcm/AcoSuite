<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentiveReport
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
        Me.cboBookYear = New System.Windows.Forms.ComboBox()
        Me.cboCalcQuarter = New System.Windows.Forms.ComboBox()
        Me.cboObject = New System.Windows.Forms.ComboBox()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboBookYear
        '
        Me.cboBookYear.FormattingEnabled = True
        Me.cboBookYear.Items.AddRange(New Object() {"2016", "2017"})
        Me.cboBookYear.Location = New System.Drawing.Point(9, 25)
        Me.cboBookYear.Name = "cboBookYear"
        Me.cboBookYear.Size = New System.Drawing.Size(121, 21)
        Me.cboBookYear.TabIndex = 0
        '
        'cboCalcQuarter
        '
        Me.cboCalcQuarter.FormattingEnabled = True
        Me.cboCalcQuarter.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboCalcQuarter.Location = New System.Drawing.Point(150, 25)
        Me.cboCalcQuarter.Name = "cboCalcQuarter"
        Me.cboCalcQuarter.Size = New System.Drawing.Size(121, 21)
        Me.cboCalcQuarter.TabIndex = 1
        '
        'cboObject
        '
        Me.cboObject.FormattingEnabled = True
        Me.cboObject.Items.AddRange(New Object() {"Customer", "Contact"})
        Me.cboObject.Location = New System.Drawing.Point(9, 79)
        Me.cboObject.Name = "cboObject"
        Me.cboObject.Size = New System.Drawing.Size(121, 21)
        Me.cboObject.TabIndex = 2
        '
        'cboUnit
        '
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Segment", "Ticket"})
        Me.cboUnit.Location = New System.Drawing.Point(150, 79)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(121, 21)
        Me.cboUnit.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(100, 120)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(147, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "CalcQuarter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Object"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(147, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Unit"
        '
        'frmIncentiveReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cboUnit)
        Me.Controls.Add(Me.cboObject)
        Me.Controls.Add(Me.cboCalcQuarter)
        Me.Controls.Add(Me.cboBookYear)
        Me.Name = "frmIncentiveReport"
        Me.Text = "IncentiveReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboBookYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboCalcQuarter As System.Windows.Forms.ComboBox
    Friend WithEvents cboObject As System.Windows.Forms.ComboBox
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
