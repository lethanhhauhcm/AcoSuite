Public Class frmPayment
    Private mdecOldVND As Decimal
    Public Sub New(Optional objPayment As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        pobjSql.LoadComboVal(cboShortName, "Select distinct ShortName as value" _
                & ",AccountNameGB as Display from Data1a_Customers where Status<>'XX'" _
                & " and Region='" & pobjUser.Region & "' order by AccountNameGB")

        ' Add any initialization after the InitializeComponent() call.
        If objPayment Is Nothing Then

            cboFOP.SelectedIndex = 0
        Else
            With objPayment
                txtRecId.Text = .Cells("RecId").Value
                cboShortName.SelectedIndex = cboShortName.FindStringExact(.Cells("AccountNameGB").Value)
                cboShortName.Enabled = False
                txtVND.Text = .Cells("VND").Value
                mdecOldVND = .Cells("VND").Value
                txtDescription.Text = .Cells("Description").Value
                cboFOP.SelectedIndex = cboFOP.FindStringExact(.Cells("FOP").Value)
                dtpTrxDate.Value = .Cells("TrxDate").Value
            End With

        End If
    End Sub

    Private Sub frmPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lbkCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkCancel.LinkClicked
        Me.Dispose()
    End Sub

    Private Sub lbkSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSave.LinkClicked
        Dim lstQuerries As New List(Of String)

        If Not CheckInputValue() Then
            Exit Sub
        End If
        'txtVND.Text = CDec(txtVND.Text)
        'If cboFOP.Text = "COF" AndAlso txtRecId.Text > 0 Then
        '    lstQuerries.Add("Update DATA1A_Balance set Status='RR',LstUpdate=getdate(),LstUser='" _
        '                    & pobjUser.UserName & "' where Status='OK' and ShortName='" _
        '                    & cboShortName.Text & "'")
        'End If
        lstQuerries.Add("insert into DATA1A_Balance (ShortName, VND, FOP, TrxDate" _
                        & ", Description, Status, FstUser) values ('" & cboShortName.SelectedValue _
                        & "'," & txtVND.Text & ",'" & cboFOP.Text _
                        & "','" & CreateFromDate(dtpTrxDate.Value) _
                        & "','" & txtDescription.Text & "','OK','" & pobjUser.UserName & "')")
        If txtRecId.Text > 0 Then
            lstQuerries.Add("Update DATA1A_Balance set Status='XX',LstUpdate=getdate(),LstUser='" _
                            & pobjUser.UserName & "' where Recid=" & txtRecId.Text)
        End If

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then

            'clear pending invoices
            Dim tblPendingInv As DataTable
            tblPendingInv = pobjSql.GetDataTable("Select * from Data1A_ProductCharges" _
                                    & " where Status='OK' and ShortName='" _
                                    & cboShortName.SelectedValue _
                                    & "' order by BookYear,BookMonth")
            For Each objRow As DataRow In tblPendingInv.Rows
                Dim lstAutoQuerries As New List(Of String)
                lstAutoQuerries = pobjSql.CreateBalanceQuerries(objRow("RecId") _
                                        , objRow("Amount") + objRow("VAT"), cboShortName.SelectedValue)
                If lstAutoQuerries.Count = 0 Then
                    Exit For
                Else
                    pobjSql.UpdateListOfQuerries(lstAutoQuerries)
                End If
            Next

            Me.Dispose()
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("Unable to update")
        End If
    End Sub
    Private Function CheckInputValue() As Boolean

        If Not IsNumeric(txtVND.Text) Then
            MsgBox("Invalid VND")
            Return False
        ElseIf txtVND.Text <= 0 AndAlso cboFOP.Text <> "COF" Then
            MsgBox("Invalid VND")
            Return False
        ElseIf cboFOP.Text = "COF" Then
            If pobjSql.GetScalarAsDecimal("select count (*) from DATA1A_Balance _
            where status='OK' and ShortName='" & cboShortName.SelectedValue & "'") > 0 Then
                MsgBox("Invalid FOP")
                Return False
            Else
                Return True
            End If

        ElseIf pobjSql.GetScalarAsDecimal("select count (*) from DATA1A_Balance" _
            & " where status='OK' and FOP='COF' and ShortName='" & cboShortName.SelectedValue & "'") = 0 Then
            MsgBox("CUT OFF must be Created first!")
            Return False
        End If

        Return True
    End Function
End Class