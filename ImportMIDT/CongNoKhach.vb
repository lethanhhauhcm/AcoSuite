'^_^20221109 add by 7643
Imports Excel = Microsoft.Office.Interop.Excel
Imports AcoSuite.Crd_Ctrl
Imports Microsoft  '^_^20221126 add by 7643
Public Class frmDC_Pax
    Private MyCust As New clsCustomer
    Private CharEntered As Boolean = False
    Private TiGiaGi As String = "INVOICE"
    Private varAction As String
    Private Const MaxWriteOffValueVND As Decimal = 5000
    Private Const MaxWriteOffValueUSD As Decimal = 1
    Private QryCust As String
    Private cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
    Private iCounter As Int16 = 0
    Private FExcel As New Excel.Application
    Private FPurchaseSource As String
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal parAction As String)
        InitializeComponent()
        varAction = parAction
    End Sub
    Private Sub frmDC_Pax_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MyCust.CustID = 0
        Me.Dispose()
    End Sub

    Private Sub frmBO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = pubVarBackColor
        If InStr(varAction.ToUpper, "INVOIC") > 0 Then
            Me.PadAction.Enabled = False
        ElseIf InStr(varAction.ToUpper, "PAYMENT") > 0 Then
            Me.Timer1.Enabled = False
        ElseIf InStr(varAction.ToUpper, "FOLLOWUP") > 0 Then
            Me.GrpPmtFollowUp.Left = 0
            Me.GrpPmtFollowUp.Width = 780
        End If

        InitSetting()
        GenComboValue()
        Me.CmbCustomer.Focus()
        If InStr(varAction, "Invoicing") > 0 Then
            Me.PadFilter.Enabled = False
            Me.PnlInvoicing.Enabled = True
            Me.BarPaymentDate.Enabled = False
            Me.BarIncludeFullyUsed.Enabled = False
            Me.BarDeleteThisPayment.Enabled = False
            Me.ChotNo.Text = "Invoicing"
            Me.BarPurchaseDate.Checked = True
            If InStr(varAction, "Quick") > 0 Then
                Me.CmdQuickInvUSD.Enabled = True
                Me.CmdQuickInvVND.Enabled = True
            Else
                Me.CmdQuickInvUSD.Enabled = False
                Me.CmdQuickInvVND.Enabled = False
            End If
        ElseIf varAction = "ApplyPayments" Then
            Me.BarPaymentDate.Checked = True
            Me.PnlApplyPayments.Enabled = True
            Me.BarInvoiceDate.Enabled = False
            Me.BarPurchaseDate.Enabled = False
            Me.ThanhToan.Text = "Apply Payments"
            Me.TabControl1.SelectTab("ThanhToan")
            Me.CmbPmtType.Text = "PSP"
        ElseIf InStr(varAction.ToUpper, "FOLLOWUP") > 0 Then
            Me.GrpPmtFollowUp.Visible = True
            Me.TabControl1.SelectTab("TabROE")
        End If
        Me.CmbCNCurr.Text = "VND"
        CheckRightForALLForm(Me)
    End Sub
    Private Sub InitSetting()
        Me.ChotNo.BackColor = pubVarBackColor
        Me.ThanhToan.BackColor = pubVarBackColor
        Me.TabROE.BackColor = pubVarBackColor

        Me.ChotNo.Text = ""
        Me.ThanhToan.Text = ""
        Me.GridDungTienNao.Width = 788
    End Sub
    Private Sub GenComboValue()
        Dim StrSQL As String
        CmbInvoiceAL.Items.Add("SC")
        Me.CmbInvoiceAL.Items.Add("ALL")
        Me.CmbInvoiceAL.Text = "ALL"

        LoadCmb_MSC(Me.CmbCNFOP, "select VAL from DATA1A_MISC where CAT='FOP' and  VAL2 like '%CC%' order by VAL")

        Me.CmbReceivedBy.Items.Clear()
        Me.CmbReceivedBy.Items.Add("BO-BackOFC")
        Me.CmbReceivedBy.Text = Me.CmbReceivedBy.Items(0).ToString
        StrSQL = "select VAL from DATA1A_MISC where CAT='CURR' order by VAL"
        LoadCmb_MSC(Me.CmbInvoiceCurr, StrSQL)
        LoadCmb_MSC(Me.CmbCNCurr, StrSQL)
        LoadCmb_MSC(Me.Cmb1Curr, StrSQL)
        LoadCmb_MSC(Me.CmbEQnCurr, StrSQL)
        Me.CmbCNCurr.Text = "VND"
        Me.CmbInvoiceCurr.Text = "VND"

        RemoveHandler CmbCustomer.SelectedIndexChanged, AddressOf CmbCustomer_SelectedIndexChanged
        LoadCmb_VAL(Me.CmbCustomer, "select RecID Val,ShortName Dis from DATA1A_Customers where Status='OK' order by ShortName")
        AddHandler CmbCustomer.SelectedIndexChanged, AddressOf CmbCustomer_SelectedIndexChanged
        Call CmbCustomer_SelectedIndexChanged(CmbCustomer, System.EventArgs.Empty)
    End Sub
    Private Sub GetPurchases()
        Dim strSQL As String, InvoiceUpto As Date
        Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
        Dim strSQLACR As String

        strSQL = PurchaseSource("PSP", CmbCustomer.SelectedValue)
        strSQLACR = PurchaseSource("ACR", CmbCustomer.SelectedValue)
        FPurchaseSource = PurchaseSource("PSP") & " union " & PurchaseSource("ACR") & " order by ShortName,Nguon,OrgDocs,RecID"
        Me.GridNo.DataSource = GetDataTable(strSQL & " union " & strSQLACR & " order by ShortName,Nguon,OrgDocs,RecID")
        Me.GridNo.EditMode = DataGridViewEditMode.EditOnEnter
        ResizeGridNo()
        InvoiceUpto = Format(Me.txtUpto.Value, "dd-MMM-yy") & " 23:59"
        For i As Int16 = 0 To Me.GridNo.RowCount - 1
            If Me.GridNo.Item("OrgDate", i).Value < InvoiceUpto Then
                Me.GridNo.Item("S", i).Value = True
            End If
        Next
    End Sub

    Private Function PurchaseSource(xFOP As String, Optional xCustID As Integer = 0) As String
        Return String.Format("select f.RCPNo as OrgDocs, 'S' SRV, f.FstUpdate as OrgDate, f.Currency as OrgCurr, f.AMount as OrgTTLAmt, " &
            " f.Currency as InvCurr, f.Amount as InvAmt, 1.00 As InvROE, '{0}' as InvDate, '{1}' as DueDate, cust.RecID CustID, f.RecID, f.Source Nguon," &
            "format(cp.CPMonth,'MM/yyyy') Period,cust.ShortName,f.RMK" &  '^_^20221126 add f.RMK by 7643
            " from DATA1A_FOP f INNER JOIN DATA1A_CalcPriceDetail cpd ON f.RMK = cpd.RecID And cpd.Status='OK' and City='" & pobjUser.City & "' " &
                "left join DATA1A_Customers cust on cpd.Customer=cust.ShortName and cust.Status='OK' and cust.Region='" & pobjUser.Region & "' " &
                "left join DATA1A_CalcPrice cp on cpd.CPID=cp.CPID and cp.Status='OK' and cpd.City=cp.City " &
            "where (cust.RecID={2} or {2}=0) and f.Status='OK' and f.FstUpdate>'" & CutOverDatePSP & "' and f.FOP='" & xFOP & "' and f.profid=0 " &
                "And f.fstupdate >'{3}' and f.Source in ('SECO','ATC')", Format(Me.txtInvoiceDate.Value, "dd-MMM-yy"),
            Format(Me.txtInvoiceDate.Value, "dd-MMM-yy"), xCustID, CutOverDatePSP)
    End Function

    Private Sub InsertIntoGhiNoKhach(ByVal parInvStatus As String)
        Dim invAmt As Decimal, strSQL As String = "", InvID As Integer, DocNo As String
        Try
            For i As Int16 = 0 To Me.GridNo.Rows.Count - 1
                If Me.GridNo.Item("S", i).Value = True Then
                    invAmt = invAmt + CDec(Me.GridNo.Item("InvAmt", i).Value)
                End If
            Next
            InvID = Insert_GhiNoKhach("ID", Me.CmbInvoiceCurr.Text, Me.txtInvoiceDate.Value,
                invAmt, parInvStatus, "", Me.txtDueDate.Value.Date, 1, MyCust.CustID)

            For i As Int16 = 0 To Me.GridNo.Rows.Count - 1
                If Me.GridNo.Item("S", i).Value Then
                    DocNo = Me.GridNo.Item("OrgDOcs", i).Value.ToString.Substring(0, 2)
                    strSQL = "update DATA1A_fop "
                    cmd.CommandText = String.Format("{0} set profID={1} where RecID={2}", strSQL, InvID, Me.GridNo.Item("RECID", i).Value)
                    cmd.ExecuteNonQuery()
                End If
            Next
            Me.GridNo.DataSource = Nothing
            Dim c As DataGridViewColumn = Me.GridNo.Columns("S").Clone
            Me.GridNo.Columns.Clear()
            Me.GridNo.Columns.Add(c)
            LoadGridNo()
        Catch ex As Exception
            MsgBox("Error Writing to DataBase", MsgBoxStyle.Critical, msgTitle)
        End Try
    End Sub
    Private Sub LoadGridNo()
        Dim strSQL As String
        strSQL = String.Format("Select RecID, invCurr, InvAmt, invDate, Paid, Note, CustID, CustShortName, DueDate " &
            " from DATA1A_GhiNoKhach where custID={0}", Me.CmbCustomer.SelectedValue)
        If Me.BarDueOnly.Checked Then
            strSQL = String.Format("{0}  and ConNo<>0 ", strSQL)
        End If
        strSQL &= " order by RecID"
        Me.GridNo.DataSource = GetDataTable(strSQL)
        Me.GridNo.EditMode = DataGridViewEditMode.EditProgrammatically
        ResizeGridNo()
        Me.GridNo.Columns(1).Visible = False
        Me.BarMarkSelectedAsUnpaid.Enabled = False
    End Sub
    Private Sub ResizeGridNo()

        For i As Int16 = 0 To Me.GridNo.Columns.Count - 1
            If Me.GridNo.Columns(i).Name.ToUpper <> "S" Then
                Me.GridNo.Columns(i).ReadOnly = True
            End If
            If Me.GridNo.Columns(i).Name.ToUpper = "S" Or Me.GridNo.Columns(i).Name.ToUpper = "SRV" Then
                Me.GridNo.Columns(i).Width = 25
            ElseIf Me.GridNo.Columns(i).Name.ToUpper = "ORGDOCS" Then
                Me.GridNo.Columns(i).Width = 95
            ElseIf InStr(Me.GridNo.Columns(i).Name.ToUpper, "DATE") > 0 Then
                Me.GridNo.Columns(i).Width = 60
                Me.GridNo.Columns(i).DefaultCellStyle.Format = "dd-MMM-yy"
            ElseIf InStr(Me.GridNo.Columns(i).Name.ToUpper, "CURR") > 0 Then
                Me.GridNo.Columns(i).Width = 45
            ElseIf Me.GridNo.Columns(i).Name.ToUpper = "NOTE" Then
                Me.GridNo.Columns(i).Width = 100
            Else
                Me.GridNo.Columns(i).Width = 85
            End If
        Next
        For i As Int16 = 3 To Me.GridNo.Columns.Count - 1
            If InStr(Me.GridNo.Columns(i).Name.ToUpper, "AMT") > 0 Or
                InStr(Me.GridNo.Columns(i).Name.ToUpper, "PAID") > 0 Then
                Me.GridNo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.GridNo.Columns(i).DefaultCellStyle.Format = "#,##0.00"
            ElseIf InStr(Me.GridNo.Columns(i).Name.ToUpper, "ROE") > 0 Then
                Me.GridNo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.GridNo.Columns(i).DefaultCellStyle.Format = "#,##0.000000"
            Else
                Me.GridNo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If InStr(Me.GridNo.Columns(i).Name.ToUpper, "ORG") > 0 Then
                Me.GridNo.Columns(i).DefaultCellStyle.BackColor = Color.Azure
            End If
        Next
    End Sub

    Private Sub CmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCustomer.SelectedIndexChanged
        MyCust.CustID = Me.CmbCustomer.SelectedValue
        If MyCust.CustID = 0 Then Exit Sub
        Me.txtCustFullName.Text = MyCust.FullNameVN
        iCounter = 0
        Me.GridDungTienNao.Visible = True
        Me.GridTraChoKhoanNao.SelectionMode = DataGridViewSelectionMode.CellSelect
        If InStr(varAction.ToUpper, "INVOIC") > 0 Then
            Me.CmdQuickInvUSD.Enabled = True
            Me.CmdQuickInvVND.Enabled = True
            GetPurchases()
        ElseIf InStr(varAction.ToUpper, "PAYMENT") > 0 Then
            LoadNo()
            LoadPayment(Me.CmbPmtType.Text)
        ElseIf InStr(varAction.ToUpper, "FOLLOWUP") > 0 Then
            LoadGridPendingPmt()
        End If
    End Sub
    Private Sub LoadPayment(ByVal ParPmtType As String)
        Dim strSQL As String
        Me.LckLblWriteOffTra.Visible = False
        Me.txtWriteOffTra.Visible = False
        If Me.CmbCustomer.SelectedValue Is Nothing Then
            Exit Sub
        End If
        strSQL = String.Format("Select RecID, OrgDocs, OrgDate, OrgCurr, OrgAmt, Used, Note, ReceiveBy" _
                               & ", FOP, PmtType, ConLai as Balance, linkID,CustShortName,FstUser" _
                               & " from DATA1A_KhachTra where status='OK' and custID={0}", Me.CmbCustomer.SelectedValue)
        If Not Me.BarIncludeFullyUsed.Checked Then
            strSQL = String.Format("{0} and ConLai>0 ", strSQL)
        End If
        If ParPmtType <> "" And Not Me.BarAllPaymentType.Checked Then
            strSQL = String.Format("{0} and pmtType='{1}'", strSQL, Me.CmbPmtType.Text.Trim)
        End If
        strSQL &= " order by RecID"
        Me.GridDungTienNao.DataSource = GetDataTable(strSQL)
        Me.GridDungTienNao.Columns("LinkID").Visible = False

        GridDungTienNao.AutoResizeColumns()
        Me.LbLSplitPmt.Visible = False
        Me.LckLblWriteOffTra.Visible = False
        Me.txtWriteOffTra.Visible = False
        Me.txtAvailable.Text = 0
        Me.BarDeleteThisPayment.Enabled = False
    End Sub
    Private Sub txtCNAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCNAmount.GotFocus

        Me.CmdApply.Visible = False
        If Me.CmbPmtType.Text = "PSP" Then
            For r As Int16 = 0 To Me.GridTraChoKhoanNao.RowCount - 1
                Me.GridTraChoKhoanNao.Item("S", r).Value = False
            Next
        End If
    End Sub

    Public Shared Function checkCharEntered(ByVal varKeyVAL As Int16) As Boolean
        checkCharEntered = False

        If varKeyVAL < 48 OrElse varKeyVAL > 57 Then ' khac 0-9
            If varKeyVAL < 96 OrElse varKeyVAL > 105 Then ' khac numpad  0-9 
                If varKeyVAL < 109 OrElse varKeyVAL > 110 Then ' khac . -
                    If varKeyVAL < 189 OrElse varKeyVAL > 190 Then 'khac . -
                        If varKeyVAL <> 8 Then
                            checkCharEntered = True
                        End If
                    End If
                End If
            End If
        End If
    End Function

    Private Sub txtCNAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
        txtCNAmount.KeyDown, txtAvailable.KeyDown, txtWriteOffTra.KeyDown, TxtWriteOffNo.KeyDown, TxtNegoROE.KeyDown
        CharEntered = checkCharEntered(e.KeyValue)
    End Sub

    Private Sub txtCNAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtCNAmount.KeyPress, txtAvailable.KeyPress, txtWriteOffTra.KeyPress, TxtWriteOffNo.KeyPress, TxtNegoROE.KeyPress
        If CharEntered Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCNAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCNAmount.LostFocus
        Dim aa As Double, txt As TextBox = CType(sender, TextBox)

        aa = CDbl(txt.Text)
        txt.Text = Format(aa, "#,##0.00")

        If aa <> 0 Then
            Me.CmdAddPayment.Enabled = True
        Else
            Me.CmdAddPayment.Enabled = False
        End If
        If txt.Name = "txtCNAmount" And Me.CmbPmtType.Text = "PSP" Then
            Me.GridDungTienNao.Visible = True
            Me.GridTraChoKhoanNao.Columns("S").Visible = True
            Me.GridTraChoKhoanNao.SelectionMode = DataGridViewSelectionMode.CellSelect
            Me.txtAvailable.Text = Me.txtCNAmount.Text
        End If
    End Sub
    Private Sub LoadNo()
        Dim LoaiCongNo As String = "", strSQL As String
        If MyCust.CustID = 0 Then Exit Sub
        LoaiCongNo = Me.CmbPmtType.Text
        Me.GridTraChoKhoanNao.Columns.Clear()
        strSQL = String.Format("Select RecID, SelectMe as S, invCurr, InvAmt, invDate, DebType, DueDate, Paid, InvAmt-paid as AmtPayThisTime, " &
            "Note, bsr from DATA1A_GhiNoKhach where custID={0} and debType='PSP' and status='IV' ", MyCust.CustID)
        If Me.BarDueOnly.Checked Then
            strSQL = String.Format("{0} and conno<>0", strSQL)
        Else
            strSQL = String.Format("{0} and conno=0", strSQL)
        End If
        strSQL &= " order by RecID"
        Me.GridTraChoKhoanNao.DataSource = GetDataTable(strSQL)
        Me.GridTraChoKhoanNao.EditMode = DataGridViewEditMode.EditProgrammatically
        resizeGridTraChoKhoanNao()
        resizeGridDungTienNao()
        Me.LckLblWriteOffNo.Visible = False
        Me.TxtWriteOffNo.Visible = False
    End Sub
    Private Sub resizeGridDungTienNao()

        If Me.GridDungTienNao.Columns.Count = 0 Then Exit Sub
        Me.GridDungTienNao.Columns(0).Visible = False
        For c As Int16 = 1 To Me.GridDungTienNao.Columns.Count - 1
            If Me.GridDungTienNao.Columns(c).Name.ToUpper = "S" Then
                Me.GridDungTienNao.Columns(c).Width = 25
            ElseIf InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "AMT") > 0 Or
                Me.GridDungTienNao.Columns(c).Name.ToUpper = "BALANCE" Or
                Me.GridDungTienNao.Columns(c).Name.ToUpper = "USED" Then
                Me.GridDungTienNao.Columns(c).Width = 85
            ElseIf InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "DOCS") > 0 Then
                Me.GridDungTienNao.Columns(c).Width = 95
            ElseIf InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "DATE") > 0 Or
                InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "STATUS") > 0 Or
                Me.GridDungTienNao.Columns(c).Name.ToUpper = "RECEIVEBY" Or
                Me.GridDungTienNao.Columns(c).Name.ToUpper = "PMTTYPE" Then
                Me.GridDungTienNao.Columns(c).Width = 60
                Me.GridDungTienNao.Columns(c).DefaultCellStyle.Format = "dd-MMM-yy"
            ElseIf InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "CURR") > 0 Or
                Me.GridDungTienNao.Columns(c).Name.ToUpper = "FOP" Then
                Me.GridDungTienNao.Columns(c).Width = 45
            ElseIf Me.GridDungTienNao.Columns(c).Name.ToUpper = "NOTE" Then
                Me.GridDungTienNao.Columns(c).Width = 100
            End If
        Next
        For c As Int16 = 2 To Me.GridDungTienNao.Columns.Count - 1
            If InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "AMT") > 0 Or
                InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "ROE") > 0 Or
                InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "USED") > 0 Or
                Me.GridDungTienNao.Columns(c).Name.ToUpper = "BALANCE" Or
                InStr(Me.GridDungTienNao.Columns(c).Name.ToUpper, "PAID") > 0 Then
                Me.GridDungTienNao.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.GridDungTienNao.Columns(c).DefaultCellStyle.Format = "#,##0.00"
            Else
                Me.GridDungTienNao.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next
    End Sub
    Private Sub resizeGridTraChoKhoanNao()
        Me.GridTraChoKhoanNao.Columns(0).Visible = False
        For c As Int16 = 1 To Me.GridTraChoKhoanNao.Columns.Count - 1
            If Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper = "S" Then
                Me.GridTraChoKhoanNao.Columns(c).Width = 25
            ElseIf InStr(Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper, "AMT") > 0 Then
                Me.GridTraChoKhoanNao.Columns(c).Width = 85
            ElseIf InStr(Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper, "DOCS") > 0 Then
                Me.GridTraChoKhoanNao.Columns(c).Width = 95
            ElseIf InStr(Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper, "DATE") > 0 Or
            InStr(Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper, "STATUS") > 0 Then
                Me.GridTraChoKhoanNao.Columns(c).Width = 60
                Me.GridTraChoKhoanNao.Columns(c).DefaultCellStyle.Format = "dd-MMM-yy"
            ElseIf InStr(Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper, "CURR") > 0 Or
                Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper = "DEBTYPE" Then
                Me.GridTraChoKhoanNao.Columns(c).Width = 45
            ElseIf Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper = "NOTE" Then
                Me.GridTraChoKhoanNao.Columns(c).Width = 100
            End If
        Next
        For c As Int16 = 2 To Me.GridTraChoKhoanNao.Columns.Count - 1
            If InStr(Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper, "AMT") > 0 Or
                InStr(Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper, "PAID") > 0 Then
                Me.GridTraChoKhoanNao.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.GridTraChoKhoanNao.Columns(c).DefaultCellStyle.Format = "#,##0.00"
            ElseIf InStr(Me.GridTraChoKhoanNao.Columns(c).Name.ToUpper, "ROE") > 0 Then
                Me.GridTraChoKhoanNao.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.GridTraChoKhoanNao.Columns(c).DefaultCellStyle.Format = "#,##0.000000000000"
            Else
                Me.GridTraChoKhoanNao.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next
    End Sub
    Private Sub GridTraChoKhoanNao_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridTraChoKhoanNao.CellContentClick
        Dim Svalue As Boolean, thisAmt As Decimal, BankRate As Decimal, NgayNao As Date
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = 1 Then
            Me.GridTraChoKhoanNao.Item(1, e.RowIndex).Value = Not Me.GridTraChoKhoanNao.Item(1, e.RowIndex).Value
            If Me.BarPaymentDate.Checked Then
                NgayNao = Me.txtPmtDate.Value
            Else
                NgayNao = Me.GridTraChoKhoanNao.Item("InvDate", e.RowIndex).Value
            End If
            thisAmt = Me.GridTraChoKhoanNao.Item("AmtPayThisTime", e.RowIndex).Value
            Me.GridTraChoKhoanNao.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Svalue = Me.GridTraChoKhoanNao.Item(1, e.RowIndex).Value
            If Svalue = False Then
                thisAmt = -thisAmt
                Me.GridTraChoKhoanNao.Item("AmtPayThisTime", e.RowIndex).Value = Me.GridTraChoKhoanNao.Item("InvAmt", e.RowIndex).Value - Me.GridTraChoKhoanNao.Item("Paid", e.RowIndex).Value
            End If
            BankRate = XDTiGia1(TiGiaGi, Me.GridTraChoKhoanNao.Item("InvCurr", e.RowIndex).Value, Me.CmbCNCurr.Text, NgayNao)
            Me.GridTraChoKhoanNao.Item("bsr", e.RowIndex).Value = BankRate
            If CDec(Me.txtAvailable.Text) - thisAmt * BankRate < 0 Then
                Me.GridTraChoKhoanNao.Item("AmtPayThisTime", e.RowIndex).Value = CDec(Me.txtAvailable.Text) / BankRate
                Me.txtAvailable.Text = "0.00"
            Else
                Me.txtAvailable.Text = Format(CDec(Me.txtAvailable.Text) - thisAmt * BankRate, "#,##0.00")
            End If
        ElseIf e.ColumnIndex = 8 Then
            Me.GridTraChoKhoanNao.BeginEdit(True)
        End If
        Me.BarMarkSelectedAsUnpaid.Enabled = True
        Me.LblListDetail.Visible = True
    End Sub
    Private Sub CmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdApply.Click
        If Me.GridDungTienNao.CurrentRow.Cells("pmtType").Value <> "PSP" Then Exit Sub
        Dim RecNo As Integer = Me.GridDungTienNao.CurrentRow.Cells("RecID").Value
        Dim CNCurr As String = Me.GridDungTienNao.CurrentRow.Cells("OrgCurr").Value
        Dim CNDocNo As String = Me.GridDungTienNao.CurrentRow.Cells("OrgDocs").Value
        Me.CmdApply.Visible = False
        ApplyPayment(RecNo, CNCurr, CNDocNo)

        CheckOverDue(Me.CmbCustomer.SelectedValue, pobjSql.Connection)
    End Sub
    Private Sub CalcAmt()
        Dim BankRate As Decimal, NgayNao As Date, HS As Decimal
        For r As Int16 = 0 To Me.GridNo.Rows.Count - 1
            HS = IIf(Me.GridNo.Item("SRV", r).Value = "R", -1, 1)
            If Me.BarInvoiceDate.Checked = True Then
                NgayNao = Me.txtUpto.Value
                BankRate = XDTiGia1(TiGiaGi, Me.GridNo.Item("OrgCurr", r).Value, Me.CmbInvoiceCurr.Text, NgayNao)
            ElseIf Me.BarPurchaseDate.Checked Then
                If Me.GridNo.Item("OrgCurr", r).Value <> "VND" And Me.CmbInvoiceCurr.Text = "VND" Then
                    BankRate = GetROEatPurchase(Me.GridNo.Item("OrgDocs", r).Value, Me.GridNo.Item("Nguon", r).Value, CmbCustomer.Text)
                Else
                    NgayNao = Me.GridNo.Item("OrgDate", r).Value
                    BankRate = XDTiGia1(TiGiaGi, Me.GridNo.Item("OrgCurr", r).Value, Me.CmbInvoiceCurr.Text, NgayNao)
                End If
            End If
            Me.GridNo.Item("InvCurr", r).Value = Me.CmbInvoiceCurr.Text
            Me.GridNo.Item("InvROE", r).Value = BankRate
            Me.GridNo.Item("InvAmt", r).Value = BankRate * Me.GridNo.Item("OrgTTLAmt", r).Value * HS
            Me.GridNo.Item("InvDate", r).Value = Format(Me.txtUpto.Value, "dd-MMM-yy")
            Me.GridNo.Item("DueDate", r).Value = Format(Me.txtDueDate.Value, "dd-MMM-yy")
        Next
    End Sub
    Private Function GetROEatPurchase(ByVal TRX As String, ByVal pNguon As String, ByVal xCust As String) As Decimal
        Dim KQ As Decimal
        If pNguon = "SECO" OrElse pNguon = "ATC" Then KQ = ScalarToDec("DATA1A_CalcPriceDetail", "ROE", "CPID='" & TRX & "' and Customer='" & xCust & "' and status <>'XX'", pobjSql.Connection)
        Return KQ
    End Function
    Private Function XDTiGiaNego(ByVal parFrm1 As String, ByVal ParTo1 As String) As Decimal
        Dim KQ As Decimal = 1
        If Me.Cmb1Curr.Text = parFrm1 And Me.CmbEQnCurr.Text = ParTo1 Then
            Return CDec(Me.TxtNegoROE.Text)
        End If
        If Me.Cmb1Curr.Text = ParTo1 And Me.CmbEQnCurr.Text = parFrm1 And
            CDec(Me.TxtNegoROE.Text) > 1 Then
            Return 1 / CDec(Me.TxtNegoROE.Text)
        End If
    End Function
    Private Function XDTiGia1(ByVal parTiGiaGi As String, ByVal parFrm As String, ByVal parTo As String, ByVal ParNgayNao As Date) As Decimal
        Dim BankRate2 As Decimal, BankRate1 As Decimal, tmpRate As Decimal, KQ As String
        If parFrm = parTo Then
            Return 1
        End If
        parTiGiaGi = parTiGiaGi.ToUpper
        If InStr(parTiGiaGi, "NEGO") > 0 Then
            tmpRate = XDTiGiaNego(parFrm, parTo)
            Return tmpRate
        Else
            If parFrm <> "VND" And parTo <> "VND" Then
                BankRate1 = ForEX_12(pobjUser.City, ParNgayNao, parFrm, "BSR", "YY").Amount
                BankRate2 = ForEX_12(pobjUser.City, ParNgayNao, parTo, "BBR", "YY").Amount
                If BankRate1 = 0 Or BankRate2 = 0 Then
                    KQ = 0
                Else
                    KQ = BankRate1 / BankRate2
                End If
            Else
                KQ = ForEX_12(pobjUser.City, ParNgayNao, parTo, "BBR", "YY").Amount
                If KQ <> 0 And parTo <> "VND" Then
                    KQ = 1 / KQ
                End If
            End If
        End If
        If KQ = 0 Then
            MsgBox("No ROE Available to Convert " & parFrm & " to " & parTo & ". Please Update or Use Nego Rate", MsgBoxStyle.Critical, msgTitle)
        End If
        Return KQ
    End Function

    Private Sub CmbPmtType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPmtType.SelectedIndexChanged
        If Me.CmbPmtType.Text = "PSP" Then
            Me.GridTraChoKhoanNao.Enabled = True
            Me.CmdApply.Visible = False
            Me.CmdAddPayment.Enabled = False
        Else
            Me.GridTraChoKhoanNao.Enabled = False
            Me.GridTraChoKhoanNao.Columns.Clear()
        End If
        LoadNo()
        LoadPayment(Me.CmbPmtType.Text)
        Me.BarDeleteThisPayment.Enabled = False
    End Sub

    Private Sub GridNo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridNo.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.GridNo.BeginEdit(True)
        End If
    End Sub
    Private Sub txtCNDocNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCNDocNo.LostFocus
        Me.txtCNAmount.Text = 0
        Me.txtAvailable.Text = 0
    End Sub
    Private Sub BarInvoiceDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        BarInvoiceDate.Click, BarNego.Click, BarPaymentDate.Click, BarPurchaseDate.Click
        Dim MnuBar As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        ResetPadForEx()
        Me.GrpNegoCurr.Visible = True
        MnuBar.Checked = True
        TiGiaGi = MnuBar.Name
        If MnuBar.Name = "BarNego" Then
            Me.TabControl1.SelectTab("TabROE")
        End If
        If MnuBar.Name = "BarNego" Then
            Me.TabControl1.SelectTab("TabROE")
            Me.TabROE.Text = "ROE"
            Me.GrpNegoCurr.Visible = True
        Else
            Me.GrpNegoCurr.Visible = False
            Me.TabROE.Text = "MISC"
        End If
    End Sub
    Private Sub ResetPadForEx()
        Me.BarInvoiceDate.Checked = False
        Me.BarPurchaseDate.Checked = False
        Me.BarPaymentDate.Checked = False
        Me.BarNego.Checked = False
    End Sub
    Private Sub BarUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarUnlock.Click
        Dim strSQL As String = "", tmpRecID As Integer
        Try
            For r As Int16 = 0 To Me.GridTraChoKhoanNao.Rows.Count - 1
                If Me.GridTraChoKhoanNao.Item("S", r).Value = True Then
                    tmpRecID = ScalarToInt("DATA1A_GhiNoKhach", "RecID", " recid=" & Me.GridTraChoKhoanNao.Item("recID", r).Value & " and InvAMt=ConNo", pobjSql.Connection)
                    If tmpRecID = 0 Then
                        MsgBox("This Inv Has Been (Partially) Paid. Mark It As Unpaid First, Before Unlock", MsgBoxStyle.Critical, msgTitle)
                        Exit Sub
                    End If
                    strSQL = strSQL & "; " & ChangeStatus_ByID("DATA1A_GhiNoKhach", "XX", Me.GridTraChoKhoanNao.Item("recID", r).Value)
                    strSQL = strSQL & "; update DATA1A_fop set profid=0 where profid=" & Me.GridTraChoKhoanNao.Item("recID", r).Value
                    cmd.CommandText = strSQL.Substring(1)
                    cmd.ExecuteNonQuery()
                    Exit For ' chi chap nhan unlock tung cai 1
                End If
            Next
            MsgBox("Selected Records Have Been UnLocked", MsgBoxStyle.Critical, msgTitle)
        Catch ex As Exception
            MsgBox(Err.Description & "Error Writing To DataBase", MsgBoxStyle.Critical, msgTitle)
        End Try
    End Sub

    Private Sub BarDueOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarDueOnly.Click
        Me.BarDueOnly.Checked = Not Me.BarDueOnly.Checked
        LoadGridNo()
    End Sub

    Private Sub BarIncludeFullyUsed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarIncludeFullyUsed.Click
        Me.BarIncludeFullyUsed.Checked = Not Me.BarIncludeFullyUsed.Checked
        LoadPayment(Me.CmbPmtType.Text)
    End Sub

    Private Sub GridDungTienNao_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles _
        GridDungTienNao.CellContentClick, GridDungTienNao.CellClick
        If e.RowIndex < 0 Then Exit Sub
        LoadNo()
        Me.txtAvailable.Text = Format(Me.GridDungTienNao.Item("Balance", e.RowIndex).Value, "#,##0.00")
        Me.LckLblWriteOffTra.Visible = True
        Me.txtWriteOffTra.Visible = True
        Me.CmbCNCurr.Text = Me.GridDungTienNao.Item("OrgCurr", e.RowIndex).Value
        Me.CmdApply.Visible = True
        Me.LbLSplitPmt.Visible = True
        Me.BarDeleteThisPayment.Enabled = True
    End Sub

    Private Sub GridDungTienNao_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridDungTienNao.CellContentDoubleClick
        If Me.GridDungTienNao.RowCount = 0 Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        Me.BarDeleteThisPayment.Enabled = True
        Dim strSQL As String
        strSQL = String.Format("select RecID, DebDocs as OrgDocs, ApplyDate as PmtDate, AmtInDebCurr, Currency as PmtCurr," &
            "ROE as PmtROE, AmtInPmtCurr, Note from DATA1A_applypayment where KhachTraID={0} order by RecID", Me.GridDungTienNao.Item("recID", e.RowIndex).Value)
        Me.GridTraChoKhoanNao.Columns.Clear()
        Me.GridTraChoKhoanNao.DataSource = GetDataTable(strSQL)
        resizeGridTraChoKhoanNao()
    End Sub
    Private Sub BarAllPaymentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarAllPaymentType.Click
        LoadPayment("")
    End Sub

    Private Sub CmdAddPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAddPayment.Click
        Dim RecNo As Integer, AutoDocNo As String, BSR As Decimal
        'Me.LblPrint.Visible = True
        Me.txtAvailable.Text = CDec(Me.txtCNAmount.Text)
        If Me.CmbReceivedBy.Text.Substring(0, 2) = "BO" Then
            AutoDocNo = "BO" & Format(Now, "ddMMyyHHmmss")
        Else
            AutoDocNo = Me.CmbInvoiceAL.Text & Format(Now, "ddMMyyHHmmss")
        End If
        Me.CmdAddPayment.Enabled = False
        If Not (Me.txtCNAmount.Text <> 0 And Me.txtCNDescription.Text <> "" And Me.CmbCNCurr.Text <> "" And Me.CmbCNFOP.Text <> "") Then
            MsgBox("Invalid Input", MsgBoxStyle.Critical, msgTitle)
            Exit Sub
        End If

        If Me.CmbCNCurr.Text = "VND" Then
            BSR = 1
        Else
            BSR = ForEX_12(pobjUser.City, Now, Me.CmbCNCurr.Text, "BBR", Me.CmbInvoiceAL.Text).Amount
        End If
        Try
            RecNo = Insert_KhachTra("E", Me.txtPmtDate.Value, Me.CmbCNCurr.Text, Me.CmbCNFOP.Text _
                                    , AutoDocNo, CDec(Me.txtCNAmount.Text), Me.txtCNDescription.Text _
                                    , "", BSR, Me.txtCNDocNo.Text, Me.CmbPmtType.Text _
                                    , MyCust.CustID)

            If Me.CmbCNCurr.Text <> "VND" Then
                cmd.CommandText = "Update DATA1A_KhachTra set ROE =" & ForEX_12(pobjUser.City, Me.txtPmtDate.Value, Me.CmbCNCurr.Text, "BBR", Me.CmbInvoiceAL.Text).Amount _
                    & " Where  RecID =" & RecNo
                cmd.ExecuteNonQuery()
            End If
            LoadPayment(Me.CmbPmtType.Text)
            Me.txtCNDocNo.Text = ""
            Me.txtCNAmount.Text = 0
        Catch ex As Exception
            MsgBox("Error Writing to Dbase", MsgBoxStyle.Critical, msgTitle)
        End Try
    End Sub
    Private Sub ApplyPayment(ByVal parRecNo As Integer, ByVal ParCurr As String, ByVal parDocNo As String)
        Dim Amt As Decimal, strSQL As String = ""
        For r As Int16 = 0 To Me.GridTraChoKhoanNao.Rows.Count - 1
            If Me.GridTraChoKhoanNao.Item("S", r).Value = True Then
                Amt = Amt + Me.GridTraChoKhoanNao.Item("AmtPayThisTime", r).Value * Me.GridTraChoKhoanNao.Item("bsr", r).Value
                strSQL = strSQL & ";" & Insert_ApplyPayment("S", Me.GridTraChoKhoanNao.Item("RecID", r).Value, parRecNo,
                    Me.GridTraChoKhoanNao.Item("AmtPayThisTime", r).Value, ParCurr,
                    Me.GridTraChoKhoanNao.Item("bsr", r).Value, "", "")
                strSQL = strSQL & "; Update DATA1A_GhiNoKhach set Paid=paid+" & Me.GridTraChoKhoanNao.Item("AmtPayThisTime", r).Value &
                    " where RecID=" & Me.GridTraChoKhoanNao.Item("recID", r).Value
            End If
        Next
        strSQL = strSQL & "; Update DATA1A_KhachTra set Used=Used+" & Amt & " where recid=" & parRecNo
        Try
            cmd.CommandText = strSQL.Substring(1)
            cmd.ExecuteNonQuery()
            MsgBox("Payment Has Been Applied.", MsgBoxStyle.Information, msgTitle)
            LoadNo()
            LoadPayment(Me.CmbPmtType.Text)
        Catch ex As Exception
            MsgBox("Error Writing to Dbase", MsgBoxStyle.Critical, msgTitle)
        End Try
    End Sub

    Private Sub LblWriteOffTra_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _
        LckLblWriteOffTra.LinkClicked
        Dim lnk As LinkLabel = CType(sender, LinkLabel)
        Dim RecNo As Int16 = Me.GridDungTienNao.CurrentRow.Cells("RecID").Value
        Dim Curr As String = Me.GridDungTienNao.CurrentRow.Cells("OrgCurr").Value
        Dim tmpMaxWriteOffValue As Decimal
        tmpMaxWriteOffValue = IIf(Curr = "VND", MaxWriteOffValueVND, MaxWriteOffValueUSD)
        If CDec(Me.txtWriteOffTra.Text) > tmpMaxWriteOffValue Then
            If pobjUser.Role <> "Admin" Then
                MsgBox("Not Enough Right To Write Off Such an Amount", MsgBoxStyle.Information, msgTitle)
                Exit Sub
            End If
        End If
        cmd.CommandText = String.Format("Update DATA1A_KhachTra set used=used + {0} where recid={1}", CDec(Me.txtWriteOffTra.Text), RecNo)
        cmd.ExecuteNonQuery()
        cmd.CommandText = Insert_ApplyPayment("S", 0, RecNo, 0, Curr, 1, "", "WRITEOFF")
        cmd.ExecuteNonQuery()
        LoadPayment("PSP")
    End Sub

    Private Sub LblWriteOffNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _
        LckLblWriteOffNo.LinkClicked
        Dim lnk As LinkLabel = CType(sender, LinkLabel)
        Dim RecNo As Integer = Me.GridTraChoKhoanNao.CurrentRow.Cells("RecID").Value
        Dim Curr As String = Me.GridTraChoKhoanNao.CurrentRow.Cells("InvCurr").Value
        Dim tmpMaxWriteOffValue As Decimal
        tmpMaxWriteOffValue = IIf(Curr = "VND", MaxWriteOffValueVND, MaxWriteOffValueUSD)
        If CDec(Me.TxtWriteOffNo.Text) > tmpMaxWriteOffValue Then
            If pobjUser.Role <> "Admin" Then
                MsgBox("Not Enough Right To Write Off Such an Amount", MsgBoxStyle.Information, msgTitle)
                Exit Sub
            End If
        End If

        cmd.CommandText = String.Format("Update DATA1A_GhiNoKhach set Paid=Paid+{0} where recid={1}", CDec(Me.TxtWriteOffNo.Text), RecNo)
        cmd.ExecuteNonQuery()
        cmd.CommandText = Insert_ApplyPayment("S", RecNo, 0, CDec(Me.TxtWriteOffNo.Text), Curr, 1, "", "WRITEOFF")
        cmd.ExecuteNonQuery()
        CheckOverDue(Me.CmbCustomer.SelectedValue, pobjSql.Connection)
        LoadNo()
    End Sub
    Private Sub CmdQuickInvUSD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdQuickInvUSD.Click, CmdQuickInvVND.Click
        Dim btn As Button = CType(sender, Button)
        Dim MyAns As Int16
        '^_^20221126 add by 7643 -b-
        Dim i, mUserNum As Integer
        Dim mIsSeco As Boolean
        Dim mUsers, mPeriods, mTo, mTable As String
        Dim mAmt As Double
        '^_^20221126 add by 7643 -e-
        Me.CmdQuickInvUSD.Enabled = False
        Me.CmdQuickInvVND.Enabled = False
        Me.BarPurchaseDate.PerformClick()
        Me.CmbInvoiceCurr.Text = btn.Tag
        iCounter = 0
        CalcAmt()
        InsertIntoGhiNoKhach("IV")

        '^_^20221126 add by 7643 -b-
        mIsSeco = False
        For i = 0 To GridNo.Rows.Count - 1
            If GridNo.Item("S", i).Value And GridNo.Item("Nguon", i).Value = "SECO" Then
                If Not mIsSeco Then mIsSeco = True
                mUserNum = ScalarToInt("DATA1A_CalcPriceDetail", "UserNum-FreeUser UserNum", "RecID=" & GridNo.Item("RMK", i).Value, pobjSql.Connection)
                mUsers &= IIf(mUsers <> "", ", ", "") & GridNo.Item("Period", i).Value & ":" & mUserNum & " user"
                mPeriods &= IIf(mPeriods <> "", ", ", "") & GridNo.Item("Period", i).Value
                mAmt += GridNo.Item("InvAmt", i).Value
            End If
        Next

        mTable = "(select distinct trim(BusinessEmail) BusinessEmail from DATA1A_Contacts " &
                  "where Status='OK' and CustShortName='" & CmbCustomer.Text & "' and ReceiveINV=1)x"
        mTo = ScalarToString(mTable, "isnull(STRING_AGG(BusinessEmail,'; '),'') BusinessEmail", "where 1=1", pobjSql.Connection)

        If mIsSeco And mTo <> "" Then SendSecoINV(mUsers, mPeriods, mAmt, mTo)
        '^_^20221126 add by 7643 -e-

        LoadGridNo()
    End Sub

    Private Sub SendSecoINV(xUsers As String, xPeriods As String, xAmt As Double, xTo As String)
        '^_^20221126 add by 7643 -b-
        Dim mOL As New Microsoft.Office.Interop.Outlook.Application
        Dim mItem As Microsoft.Office.Interop.Outlook.MailItem

        mItem = mOL.CreateItemFromTemplate(Application.StartupPath & "\SecoINV.oft")

        mItem.Recipients.Add(xTo)
        mItem.Recipients.ResolveAll()

        mItem.HTMLBody = Replace(mItem.HTMLBody, "xCustomer", txtCustFullName.Text)
        mItem.HTMLBody = Replace(mItem.HTMLBody, "xUsers", xUsers)
        mItem.HTMLBody = Replace(mItem.HTMLBody, "xPeriods", xPeriods)
        mItem.HTMLBody = Replace(mItem.HTMLBody, "xAmountNoVat", Format(xAmt, "##,##0.##"))
        mItem.HTMLBody = Replace(mItem.HTMLBody, "xAmount", Format(xAmt * 1.08, "##,##0.##"))
        mItem.HTMLBody = Replace(mItem.HTMLBody, "xExpDate", Format(DateAdd(DateInterval.Day, 7, Now), "dd/MM/yyyy"))  '^_^20221207 add by 7643

        mItem.Display()
        '^_^20221126 add by 7643 -e-
    End Sub

    Private Sub txtUpto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpto.ValueChanged
        Dim InvUpto As Date = Format(Me.txtUpto.Value, "dd-MMM-yy") & " 23:59"
        Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
        For i As Int16 = 0 To Me.GridNo.RowCount - 1
            If Me.GridNo.Item("OrgDate", i).Value < InvUpto Then
                Me.GridNo.Item("S", i).Value = True
            Else
                Me.GridNo.Item("S", i).Value = False
            End If
        Next
        If Me.CmbCustomer.SelectedValue Is Nothing Then Exit Sub
        On Error GoTo 0
        Exit Sub
ErrHandler:
        On Error GoTo 0
        Me.txtDueDate.Value = Now.Date
        MsgBox("Invalid [UpTo] value. Due Date Has Been Set = TODAY", MsgBoxStyle.Critical, msgTitle)
    End Sub

    Private Sub CheckUnCheckALL(ByVal parVal As Boolean)
        For i As Int16 = 0 To Me.GridNo.RowCount - 1
            Me.GridNo.Item("S", i).Value = parVal
        Next
    End Sub

    Private Sub LblUnCheckALL_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblUnCheckALL.LinkClicked
        If Me.LblUnCheckALL.Text = "UnCheckALL" Then
            CheckUnCheckALL(False)
            Me.LblUnCheckALL.Text = "CheckALL"
        Else
            Me.LblUnCheckALL.Text = "UnCheckALL"
            CheckUnCheckALL(True)
        End If
    End Sub

    Private Sub BarDeleteThisPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarDeleteThisPayment.Click
        Dim pmtID As Integer = MsgBox("Are You Sure To Delete This Payment? This Will Set All Related Invoices to UnPaid", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, msgTitle)
        Dim DaTra As Decimal, RollBackAmt As Decimal, GhiNoID As Int16, StrSQL As String
        Dim dTable As DataTable
        If pmtID = vbNo Then Exit Sub
        pmtID = Me.GridDungTienNao.CurrentRow.Cells("RecID").Value
        StrSQL = ChangeStatus_ByID("DATA1A_KhachTra", "XX", pmtID) &
            ";" & ChangeStatus_ByDK("DATA1A_ApplyPayment", "XX", "KhachTraID=" & pmtID)
        dTable = GetDataTable("select GhiNoID, AmtInDebCurr from DATA1A_applypayment where KhachTraID=" & pmtID & " And status='OK' order by GhiNoID")
        For i As Int16 = 0 To dTable.Rows.Count - 1
            GhiNoID = dTable.Rows(i)("GhiNoID")
            RollBackAmt = dTable.Rows(i)("AmtInDebCurr")
            DaTra = ScalarToDec("DATA1A_GhiNoKhach", "Paid", "RecID=" & GhiNoID, pobjSql.Connection)
            StrSQL = String.Format("{0} ; Update DATA1A_GhiNoKhach set Paid={1} where RecID={2}", StrSQL, DaTra - RollBackAmt, GhiNoID)
        Next
        Try
            cmd.CommandText = StrSQL
            cmd.ExecuteNonQuery()
            MsgBox("Payment Deleted.", MsgBoxStyle.Information, msgTitle)
        Catch ex As Exception
            MsgBox(Err.Description & vbCrLf & "Error Deleting Payment. Action Aborted" & vbCrLf, MsgBoxStyle.Critical, msgTitle)
        End Try
    End Sub

    Private Sub BarMarkSelectedAsUnpaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarMarkSelectedAsUnpaid.Click
        Dim strSQL As String, RollBackAmt As Decimal, AmtUsed As Decimal, KhachTraID As Integer
        Dim InvID As Integer = MsgBox("Are You Sure To Mark This As UnPaid? This Will Revert Amount of Related Payment", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, msgTitle)
        Dim dTable As DataTable
        If InvID = vbNo Then Exit Sub
        InvID = Me.GridTraChoKhoanNao.CurrentRow.Cells("RecID").Value

        strSQL = ChangeStatus_ByDK("DATA1A_ApplyPayment", "XX", "GhiNoID=" & InvID) &
             String.Format("; Update DATA1A_GhiNoKhach set lstUser='{0}', LstUpdate=getdate(), Note=Note +'{0} |RVRTPMT', paid=0 where recid={1}",
             pobjUser.UserName, InvID)
        dTable = GetDataTable("select KhachTraID, AmtInPmtCurr from DATA1A_applypayment where ghiNoID=" & InvID & " and status='OK' order by KhachTraID")
        For i As Int16 = 0 To dTable.Rows.Count - 1
            KhachTraID = dTable.Rows(i)("KhachTraID")
            RollBackAmt = dTable.Rows(i)("AmtInPmtCurr")
            AmtUsed = ScalarToDec("DATA1A_KhachTra", "Used", "RecID=" & KhachTraID, pobjSql.Connection)
            strSQL = String.Format("{0} ; update DATA1A_KhachTra set Used={1} where recid={2}", strSQL, AmtUsed - RollBackAmt, KhachTraID)
        Next
        Try
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
            MsgBox("Invoice Has Been Marked as UnPaid.", MsgBoxStyle.Information, msgTitle)
        Catch ex As Exception
            MsgBox(Err.Description & vbCrLf & strSQL & vbCrLf & "Error Reverting Payment. Action Aborted", MsgBoxStyle.Critical, msgTitle)
        End Try
    End Sub

    Private Sub GridTraChoKhoanNao_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridTraChoKhoanNao.CellContentDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Me.LckLblWriteOffNo.Visible = True
        Me.TxtWriteOffNo.Visible = True
        If e.ColumnIndex = 2 Then
            Exit Sub
            Me.GridDungTienNao.Visible = False
            Me.GridTraChoKhoanNao.Columns("S").Visible = False
            Me.GridTraChoKhoanNao.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            LoadPayment(Me.GridTraChoKhoanNao.Item("DebType", e.RowIndex).Value)
        End If
    End Sub

    Private Sub txtCNDocNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCNDocNo.TextChanged
        Me.LblPrint.Visible = False
    End Sub

    Private Sub LbLSplitPmt_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LbLSplitPmt.LinkClicked
        Dim LinkID As Integer
        LinkID = MsgBox("Are You Sure to Split UnUsed Amount?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, msgTitle)
        If LinkID = vbNo OrElse Me.GridDungTienNao.CurrentRow.Cells("Used").Value = 0 OrElse
            Me.GridDungTienNao.CurrentRow.Cells("Balance").Value = 0 Then Exit Sub
        LinkID = Me.GridDungTienNao.CurrentRow.Cells("LinkID").Value
        If LinkID = 0 Then LinkID = Me.GridDungTienNao.CurrentRow.Cells("RecID").Value

        cmd.CommandText = String.Format("insert DATA1A_KhachTra (OrgDocs, OrgCurr, OrgAmt, OrgDate, CustID, CustShortName, CustName, FOP, " &
            "ReceiveBy, FstUser, Description, Note, PmtType, POS, ROE, LstPmt, LinkID) select OrgDocs, OrgCurr, {0}, OrgDate, " &
            "CustID, CustShortName, CustName, FOP, ReceiveBy, '{1}', Description, Note, PmtType, POS, ROE, LstPmt,{2} from DATA1A_Khachtra " &
            "where recid={3}; Update DATA1A_KhachTra set OrgAmt=Used, LinkID={2} where recid={3}", Me.GridDungTienNao.CurrentRow.Cells("Balance").Value,
            pobjUser.UserName, LinkID, Me.GridDungTienNao.CurrentRow.Cells("RecID").Value)
        Try
            cmd.ExecuteNonQuery()
            LoadPayment(Me.CmbPmtType.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtDueDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDueDate.ValueChanged
        Me.txtDueDate.Enabled = False
    End Sub
    Private Sub LblListDetail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblListDetail.LinkClicked
        InHoaDon(Application.StartupPath, "TRXDetailByProfINV.xltm", "F", "YY", Now, Now _
                 , Me.GridTraChoKhoanNao.CurrentRow.Cells("RecID").Value, "YY", "" _
                 , CmbCustomer.SelectedValue)
    End Sub
    Private Sub LoadGridPendingPmt()
        Me.LblUpdateCFM_VAT.Visible = False
        Try
            Dim StrSQL As String = "select RecID, InvCurr as Curr, InvAmt, ConNo, InvDate, DueDate, CfmDate, VATDate, CustShortName, CustID, FstUpdate " &
                "from DATA1A_GhiNoKhach where status<>'XX' and ConNo<>0"
            If Me.ChkSelectCustOnly.Checked Then StrSQL = StrSQL & " and CustID=" & Me.CmbCustomer.SelectedValue
            StrSQL &= " order by RecID"
            Me.GridPendingINV.DataSource = GetDataTable(StrSQL)
        Catch ex As Exception
            Exit Sub
        End Try

        For r As Int16 = 0 To Me.GridPendingINV.RowCount - 1
            If Me.GridPendingINV.Item("DueDate", r).Value < Now.Date Then
                Me.GridPendingINV.Rows(r).DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
        If GridPendingINV.Columns.Count > 0 Then
            Me.GridPendingINV.Columns("RecId").Width = 50
            Me.GridPendingINV.Columns("FstUpdate").Visible = False
            Me.GridPendingINV.Columns("Curr").Width = 36
            Me.GridPendingINV.Columns("InvDate").Width = 77
            Me.GridPendingINV.Columns("DueDate").Width = 77
            Me.GridPendingINV.Columns("CfmDate").Width = 77
            Me.GridPendingINV.Columns("VATDate").Width = 77
            Me.GridPendingINV.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.GridPendingINV.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.GridPendingINV.Columns(2).DefaultCellStyle.Format = "#,##0.00"
            Me.GridPendingINV.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        End If

    End Sub

    Private Sub GridPendingINV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridPendingINV.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        If Me.ChkSelectCustOnly.Checked Then
            If Me.GridPendingINV.CurrentRow.Cells("CFMDate").Value = Me.GridPendingINV.CurrentRow.Cells("VATDate").Value Then
                Me.Label9.Text = "Cfm Date"
                Me.LblUpdateCFM_VAT.Visible = True
            ElseIf Me.GridPendingINV.CurrentRow.Cells("VATDate").Value < Me.GridPendingINV.CurrentRow.Cells("CFMDate").Value Then
                Me.Label9.Text = "VAT Date"
                Me.LblUpdateCFM_VAT.Visible = True
            End If
        End If
    End Sub
    Private Sub LblUpdateCFM_VAT_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblUpdateCFM_VAT.LinkClicked
        Dim LeadTime As Int16
        If Me.Label9.Text.Substring(0, 3) = "Cfm" Then
            cmd.CommandText = "update DATA1A_GhiNoKhach set CfmDate=@Date where RecID=@RecID"
        Else
            cmd.CommandText = "update DATA1A_GhiNoKhach set VATDate=@Date, DueDate=@DueDate where RecID=@RecID"
        End If
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Me.TxtCFM_VAT.Value
        cmd.Parameters.Add("@recID", SqlDbType.Int).Value = Me.GridPendingINV.CurrentRow.Cells(0).Value
        If Me.Label9.Text.Substring(0, 3) = "VAT" Then
            cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = Me.TxtCFM_VAT.Value.AddDays(LeadTime)
        End If
        cmd.ExecuteNonQuery()
        LoadGridPendingPmt()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        iCounter = iCounter + 1
        If iCounter = 8 Then Me.Close()
    End Sub

    Private Sub ChkSelectCustOnly_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSelectCustOnly.CheckedChanged
        LoadGridPendingPmt()
    End Sub

    Private Sub GridPendingINV_DataSourceChanged(sender As Object, e As EventArgs) Handles GridPendingINV.DataSourceChanged
        llbExportExcel.Enabled = GridPendingINV.Rows.Count > 0
    End Sub

    Private Sub llbExportExcel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbExportExcel.LinkClicked
        ExportExcel(GridPendingINV.DataSource)
    End Sub

    Private Sub ExportExcel(xDt As DataTable)
        Dim mFileName As String

        Try
            FExcel = New Excel.Application
            FExcel.Workbooks.Add()
            For i = 0 To xDt.Columns.Count - 1
                FExcel.ActiveSheet.cells(1, i + 1).value = xDt.Columns(i).Caption
            Next

            IniProgress("Exporting!", xDt.Rows.Count)
            For i = 0 To xDt.Rows.Count - 1
                For j = 0 To xDt.Columns.Count - 1
                    FExcel.ActiveSheet.cells(i + 2, j + 1).value = xDt.Rows(i)(j)
                Next
                RunProgress()
            Next

            FExcel.ActiveSheet.usedrange.EntireColumn.AutoFit
            mFileName = "D:\" & varAction.ToUpper & "_" & Now.ToString("yyyyMMddhhmmss") & ".xlsx"
            FExcel.ActiveSheet.saveas(mFileName)
            MsgBox("Export " & mFileName & " complete!")
        Finally
            FExcel.Workbooks.Close()
            FExcel.Quit()
        End Try
    End Sub

    Private Sub llbInvoicingList_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbInvoicingList.LinkClicked
        Dim mReturn As New DataTable

        mReturn = GetDataTable(FPurchaseSource, pobjSql.Connection)
        ExportExcel(mReturn)
    End Sub
End Class