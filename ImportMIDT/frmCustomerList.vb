Public Class frmCustomerList
    'Private mstrPIC As String

#Region "Ham va thu tuc"
    Public Sub New(strPIC As String)

        ' This call is required by the designer.
        InitializeComponent()
        cboPIC.SelectedIndex = -1
        'cboPIC.Text = strPIC
        If pobjUser.City = "SGN" Then
            cboRegion.Text = "South"
        ElseIf pobjUser.City = "HAN" Then
            cboRegion.Text = "North"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet
        Dim strMsQuerry As String

        strMsQuerry = "Select *,isnull((Select top 1 FullNameGb from DATA1A_Contacts where Status<>'XX'" _
                                  & " and CustomerMainContact='True' and CustShortName=DATA1A_Customers.ShortName),'') as Manager" _
                                  & " from DATA1A_Customers where Status<>'XX' "

        AddLikeConditionText(strMsQuerry, txtAccountNameGB)
        AddEqualConditionCombo(strMsQuerry, cboRegion)
        AddEqualConditionCombo(strMsQuerry, cboPIC)
        AddLikeConditionText(strMsQuerry, txtShortName)
        AddEqualConditionCombo(strMsQuerry, cboAccountStatus)
        AddEqualConditionCombo(strMsQuerry, cboMarketSize)
        AddEqualConditionCombo(strMsQuerry, cboAmadeusSize)
        If txtOffcId.Text <> "" Then
            strMsQuerry = strMsQuerry & " and ShortName in (Select ShortName from DATA1A_OIDs where Status='OK'" _
                & " and OffcId like '%" & txtOffcId.Text & "%')"
        End If
        strMsQuerry = strMsQuerry & " order by ShortName"

        pobjSql.LoadDataGridView(dgCustomers, strMsQuerry)
        dgCustomers.Columns("Comments").Visible = False
        dgCustomers.AutoResizeColumns()

        Me.Text = "CustomerList -" & dgCustomers.RowCount & " Customers"
        Return True
    End Function
    Private Function Clear() As Boolean
        cboRegion.SelectedIndex = cboRegion.FindStringExact(pobjUser.Region)
        cboPIC.SelectedIndex = -1
        txtShortName.Text = ""
        txtAccountNameGB.Text = ""
        txtOffcId.Text = ""
        cboAccountStatus.SelectedIndex = -1
        cboAmadeusSize.SelectedIndex = -1
        cboMarketSize.SelectedIndex = -1
        Return True
    End Function
#End Region
#Region "Su kien"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub



    Private Sub frmCustomerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.Name = "5-074" Then
            btnDelete.Visible = True
        Else
            btnDelete.Visible = False
        End If
        Search()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) 
        cboPIC.SelectedIndex = -1
        Select Case pobjUser.City
            Case "SGN"
                cboRegion.Text = "South"
            Case Else
                cboRegion.Text = "North"
        End Select

        txtShortName.Text = ""
        cboAccountStatus.Text = ""
        cboAmadeusSize.Text = ""
        cboMarketSize.Text = ""
        txtAccountNameGB.Text = ""
        txtOffcId.Text = ""
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomers.CellClick
        txtComments.Text = dgCustomers.CurrentRow.Cells("Comments").Value
        Dim strAccountTypes As String = dgCustomers.CurrentRow.Cells("AccountTypes").Value
        ConvertStr2Groupbox(dgCustomers.CurrentRow.Cells("AccountTypes").Value, grbAccountTypes)

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmEdit As New frmCustomerEdit
        frmEdit.ShowDialog()
        Search()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim frmEdit As New frmCustomerEdit(dgCustomers.CurrentRow)
        frmEdit.ShowDialog()
        Search()
    End Sub
    Private Sub lbkLocations_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkLocations.LinkClicked
        Dim frmLocation As New frmLocations(dgCustomers.CurrentRow.Cells("ShortName").Value)
        frmLocation.ShowDialog()
    End Sub

    Private Sub lblContacts_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblContacts.LinkClicked
        Dim frmContacts As New frmContacts(dgCustomers.CurrentRow.Cells("ShortName").Value, "")
        frmContacts.ShowDialog()
    End Sub

    Private Sub lbkOfficeIDs_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkOfficeIDs.LinkClicked
        'If pobjSql.GetScalarAsString("Select Count (*) from DATA1A_Customers where status<>'XX' and PIC='" & pobjUser.UserName & "'") = 0 Then
        '    MsgBox("You can not edit OffcIDs because you are not PIC for any Customer")
        '    Exit Sub
        'End If
        Dim frmOffcId As New frmOfficeIDs(dgCustomers.CurrentRow.Cells("ShortName").Value)
        frmOffcId.ShowDialog()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) 
        Search()
    End Sub

    Private Sub lbkIataCodes_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkIataCodes.LinkClicked
        Dim frmIataCode As New frmIataCodes(dgCustomers.CurrentRow.Cells("ShortName").Value)
        frmIataCode.ShowDialog()
    End Sub

    Private Sub cboRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRegion.SelectedIndexChanged
        Dim strQuerry As String = "Select UserName as Value from DATA1A_User WHERE Status='OK' "
        Select Case cboRegion.Text
            Case "North"
                strQuerry = strQuerry & "and City='HAN'"
            Case "South"
                strQuerry = strQuerry & " and City='SGN'"
        End Select
        strQuerry = strQuerry & " order by UserName"
        pobjSql.LoadCombo(cboPIC, strQuerry)
        cboPIC.SelectedIndex = -1
    End Sub

#End Region

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim lstQuerry As New List(Of String)
        lstQuerry.Add("Update DATA1A_Customers set Status='XX' ,LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                      & "'where Status<>'XX' and RecId=" & dgCustomers.CurrentRow.Cells("Recid").Value)
        lstQuerry.Add("Update DATA1A_Locations set Status='XX',LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                      & "' where  Status<>'XX' and ShortName='" & dgCustomers.CurrentRow.Cells("ShortName").Value & "'")
        lstQuerry.Add("Update DATA1A_OIDs set Status='XX',LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                      & "' where  Status<>'XX' and ShortName='" & dgCustomers.CurrentRow.Cells("ShortName").Value & "'")
        lstQuerry.Add("Update DATA1A_IataCodes set Status='XX',LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                      & "' where  Status<>'XX' and ShortName='" & dgCustomers.CurrentRow.Cells("ShortName").Value & "'")
        If pobjSql.UpdateListOfQuerries(lstQuerry) Then
            Search()
        Else
            MsgBox("Unable to Delete Customer")
        End If
    End Sub

    
    Private Sub lbkBillingInfo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkBillingInfo.LinkClicked
        Dim frmBillInfo As New frmBillingInfoEdit(dgCustomers.CurrentRow.Cells("ShortName").Value)
        frmBillInfo.ShowDialog()
    End Sub

    Private Sub lbkPaymentInfo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkPaymentInfo.LinkClicked
        Dim frmPaymentInfo As New frmPaymentInfo(dgCustomers.CurrentRow.Cells("ShortName").Value)
        frmPaymentInfo.ShowDialog()
    End Sub

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub
End Class