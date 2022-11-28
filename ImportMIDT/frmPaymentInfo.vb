Public Class frmPaymentInfo
    Private mstrShortName As String
    Public Sub New(strShortName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim tblBillingInfo As DataTable = pobjSql.GetDataTable("Select * from Data1a_PaymentInfo where Status='OK'" _
                                                               & " and CustShortName='" & strShortName & "'")
        mstrShortName = strShortName
        With tblBillingInfo
            If .Rows.Count > 0 Then
                txtRecId.Text = .Rows(0)("RecId")
                txtCustShortName.Text = .Rows(0)("CustShortName")
                txtEmail.Text = .Rows(0)("Email")
                txtBankAccountNbr.Text = .Rows(0)("BankAccountNbr")
                txtBankName.Text = .Rows(0)("BankName")
                txtBranchName.Text = .Rows(0)("BankBranch")
                txtAccountOwner.Text = .Rows(0)("AccountOwner")
            End If
        End With

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerries As New List(Of String)
        txtBankAccountNbr.Text = Replace(txtBankAccountNbr.Text, " ", "")
        If Not CheckInputValues() Then
            Exit Sub
        End If

        Dim lstQuerry As New List(Of String)

        lstQuerry.Add("Insert into [DATA1A_PaymentInfo] (CustShortName, Email" _
                      & ", BankAccountNbr, BankName, BankBranch, AccountOwner" _
                      & ", Status, FstUser) values('" _
                      & mstrShortName & "','" & txtEmail.Text & "','" & txtBankAccountNbr.Text _
                      & "','" & txtBankName.Text & "','" & txtBranchName.Text _
                      & "','" & txtAccountOwner.Text & "','OK','" & pobjUser.UserName & "')")
        If txtRecId.Text <> "" Then
            lstQuerry.Add("Update DATA1A_PaymentInfo Set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                          & "' where RecId=" & txtRecId.Text)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerry) Then
            Me.Dispose()
        Else
            MsgBox("Unable to add Payment Info")
        End If
    End Sub
    Private Function CheckInputValues() As Boolean

        If Not CheckFormatTextBoxEmail(txtEmail, True) Then
            Return False
        End If
        If Not CheckFormatTextBox(txtBankName, , , 3) _
            Or Not CheckFormatTextBox(txtBankAccountNbr, , True, 6) _
            Or Not CheckFormatTextBox(txtAccountOwner, , , 6) Then
            Return False
        End If
        Return True
    End Function

    
End Class