<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReissueTicketPriceDetail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvReissueTicketPriceDetail = New System.Windows.Forms.DataGridView()
        Me.NumberOfTicket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PricePerTicket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvReissueTicketPriceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvReissueTicketPriceDetail
        '
        Me.dgvReissueTicketPriceDetail.AllowUserToAddRows = False
        Me.dgvReissueTicketPriceDetail.AllowUserToDeleteRows = False
        Me.dgvReissueTicketPriceDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReissueTicketPriceDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvReissueTicketPriceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReissueTicketPriceDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumberOfTicket, Me.PricePerTicket, Me.Amount})
        Me.dgvReissueTicketPriceDetail.Location = New System.Drawing.Point(12, 12)
        Me.dgvReissueTicketPriceDetail.Name = "dgvReissueTicketPriceDetail"
        Me.dgvReissueTicketPriceDetail.ReadOnly = True
        Me.dgvReissueTicketPriceDetail.Size = New System.Drawing.Size(364, 426)
        Me.dgvReissueTicketPriceDetail.TabIndex = 0
        '
        'NumberOfTicket
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.NumberOfTicket.DefaultCellStyle = DataGridViewCellStyle1
        Me.NumberOfTicket.HeaderText = "NumberOfTicket"
        Me.NumberOfTicket.Name = "NumberOfTicket"
        Me.NumberOfTicket.ReadOnly = True
        Me.NumberOfTicket.Width = 110
        '
        'PricePerTicket
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PricePerTicket.DefaultCellStyle = DataGridViewCellStyle2
        Me.PricePerTicket.HeaderText = "PricePerTicket"
        Me.PricePerTicket.Name = "PricePerTicket"
        Me.PricePerTicket.ReadOnly = True
        Me.PricePerTicket.Width = 102
        '
        'Amount
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle3
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        Me.Amount.Width = 68
        '
        'frmReissueTicketPriceDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 450)
        Me.Controls.Add(Me.dgvReissueTicketPriceDetail)
        Me.Name = "frmReissueTicketPriceDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReissueTicketPriceDetail"
        CType(Me.dgvReissueTicketPriceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvReissueTicketPriceDetail As DataGridView
    Friend WithEvents NumberOfTicket As DataGridViewTextBoxColumn
    Friend WithEvents PricePerTicket As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
End Class
