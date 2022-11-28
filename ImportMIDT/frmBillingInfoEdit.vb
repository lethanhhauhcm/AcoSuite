Public Class frmBillingInfoEdit
    Private mstrShortName As String
    Private Sub frmBillingInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(strShortName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim tblBillingInfo As DataTable = pobjSql.GetDataTable("Select * from Data1a_BillingInfo where Status='OK'" _
                                                               & " and ShortName='" & strShortName & "'")
        mstrShortName = strShortName
        With tblBillingInfo
            If .Rows.Count > 0 Then
                txtCustomerName.Text = .Rows(0)("CustomerName")
                txtAddress.Text = .Rows(0)("Address")
                txtTaxCode.Text = .Rows(0)("TaxCode")
                txtRecId.Text = .Rows(0)("RecId")
            End If
        End With

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerry As New List(Of String)

        lstQuerry.Add("Insert into [DATA1A_BillingInfo] ([ShortName],[CustomerName],[Address],[TaxCode],FstUser) values('" _
                      & mstrShortName & "',N'" & txtCustomerName.Text & "',N'" & txtAddress.Text _
                      & "','" & txtTaxCode.Text & "','" & pobjUser.UserName & "')")
        If txtRecId.Text <> "" Then
            lstQuerry.Add("Update DATA1A_BillingInfo Set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                          & "' where RecId=" & txtRecId.Text)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerry) Then
            Me.Dispose()
        Else
            MsgBox("Unable to add Billing Info")
        End If
    End Sub
    Private Function CheckInputValues() As Boolean
        If txtAddress.Text.Length < 10 Then
            MsgBox("Invalid Adress")
            Return False
        End If
        If Not CheckFormatTextBox(txtTaxCode, 10, True, 8) Then
            Return False
        End If
        Return True
    End Function
End Class