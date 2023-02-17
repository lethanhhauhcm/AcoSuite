'^_^20221021 add CustAddress,CustTaxCode,Email by 7643
Public Class frmCustomerEdit
    Private mstrOldPIC As String

    Private Sub frmCustomerEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(Optional drCustomer As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '        pobjSql.LoadCombo(cboPIC, "Select UserName as Value from DATA1A_User where status<>'XX' order by UserName")


        If drCustomer IsNot Nothing Then
            txtRecId.Text = drCustomer.Cells("RecId").Value
            txtShortName.Text = drCustomer.Cells("ShortName").Value
            txtAccountNameGB.Text = drCustomer.Cells("AccountNameGB").Value
            txtAccountNameVN.Text = drCustomer.Cells("AccountNameVN").Value
            cboRegion.Text = drCustomer.Cells("Region").Value
            cboProvince.Text = drCustomer.Cells("Province").Value
            cboAccountStatus.Text = drCustomer.Cells("AccountStatus").Value
            cboPIC.Text = drCustomer.Cells("PIC").Value
            cboMarketSize.Text = drCustomer.Cells("MarketSize").Value
            cboAmadeusSize.Text = drCustomer.Cells("AmadeusSize").Value
            txtWeb.Text = drCustomer.Cells("Web").Value
            txtComments.Text = drCustomer.Cells("Comments").Value
            ConvertStr2Groupbox(drCustomer.Cells("AccountTypes").Value, grbAccountTypes)
            txtShortName.Enabled = False
            'txtFullNameGb.Enabled = False
            'txtFullNameVN.Enabled = False
            mstrOldPIC = cboPIC.Text
            txtDataApiToken.Text = drCustomer.Cells("DataApiToken").Value
            chkPPD.Checked = drCustomer.Cells("PPD").Value  '^_^20230112 add by 7643
        Else

            Select Case pobjUser.City
                Case "SGN"
                    cboRegion.Text = "South"
                Case Else
                    cboRegion.Text = "North"
            End Select

        End If
    End Sub

    Private Function CheckInputValues() As Boolean
        Dim blnAccountTypeExist As Boolean
        If txtShortName.Text.Contains(" ") Or txtShortName.Text.Trim.Length = 0 Then
            MsgBox("Invalid ShortName")
            Return False
        End If
        If txtRecId.Text = "" _
            AndAlso pobjSql.GetScalarAsString("Select RecId from DATA1A_Customers where ShortName='" & txtShortName.Text & "'") <> "" Then
            MsgBox("Duplicate ShortName")
            Return False
        End If
        If Not CheckFormatTextBox(txtAccountNameGB, , , 3) Or Not CheckFormatTextBox(txtAccountNameVN, , , 3) Then
            Return False
        End If

        If Not CheckFormatComboBox(cboRegion, , 1) Or Not CheckFormatComboBox(cboProvince, , 1) _
            Or Not CheckFormatComboBox(cboAccountStatus, , 1) Or Not CheckFormatComboBox(cboRegion, , 1) _
            Or Not CheckFormatComboBox(cboPIC, , 1) Or Not CheckFormatComboBox(cboMarketSize, , 1) _
            Or Not CheckFormatComboBox(cboAmadeusSize, , 1) Then
            Return False
        End If
        For Each objAccountType As CheckBox In grbAccountTypes.Controls
            If objAccountType.Checked Then
                blnAccountTypeExist = True
                Exit For
            End If
        Next
        If Not blnAccountTypeExist Then
            MsgBox("You must select AccountType")
            Return False
        End If



        If mstrOldPIC <> "" AndAlso mstrOldPIC <> cboPIC.Text _
            AndAlso Not pobjUser.HasRight("action", "CustomerManagerment", "ChangePIC") Then
            MsgBox("You DO NOT have right to change PIC")
            Return False
        End If
        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerries As New List(Of String)
        Dim mPPD As Integer  '^_^20230112 add by 7643
        If Not CheckInputValues() Then
            Exit Sub
        End If
        '^_^20221021 mark by 7643 -b-
        'lstQuerries.Add("insert into DATA1A_Customers ( AccountNameGB, AccountNameVN, ShortName, Province, Region" _
        '                & ", PIC, Web, AccountStatus,AccountTypes, MarketSize, AmadeusSize, Comments" _
        '                & ", Status, FstUser,DataApiToken) values ('" _
        '                & txtAccountNameGB.Text & "',N'" & txtAccountNameVN.Text & "','" & txtShortName.Text _
        '                & "','" & cboProvince.Text & "','" & cboRegion.Text & "','" & cboPIC.Text _
        '                & "','" & txtWeb.Text & "','" & cboAccountStatus.Text & "','" & ConvertGroupbox2Str(grbAccountTypes) _
        '                & "','" & cboMarketSize.Text _
        '                & "','" & cboAmadeusSize.Text & "',N'" & txtComments.Text _
        '                & "','OK','" & pobjUser.UserName _
        '                & "','" & txtDataApiToken.Text & "')")
        '^_^20221021 mark by 7643 -e-
        '^_^20221021 modi by 7643 -b-
        '^_^20230112 mark by 7643 -b-
        'lstQuerries.Add("insert into DATA1A_Customers ( AccountNameGB, AccountNameVN, ShortName, Province, Region" _
        '                & ", PIC, Web, AccountStatus,AccountTypes, MarketSize, AmadeusSize, Comments" _
        '                & ", Status, FstUser,DataApiToken, CustAddress, CustTaxCode, Email) values ('" _
        '                & txtAccountNameGB.Text & "',N'" & txtAccountNameVN.Text & "','" & txtShortName.Text _
        '                & "','" & cboProvince.Text & "','" & cboRegion.Text & "','" & cboPIC.Text _
        '                & "','" & txtWeb.Text & "','" & cboAccountStatus.Text & "','" & ConvertGroupbox2Str(grbAccountTypes) _
        '                & "','" & cboMarketSize.Text _
        '                & "','" & cboAmadeusSize.Text & "',N'" & txtComments.Text _
        '                & "','OK','" & pobjUser.UserName _
        '                & "','" & txtDataApiToken.Text & "', '" & txtCustAddress.Text & "', '" & txtCustTaxCode.Text & "', '" & txtEmail.Text & "')")
        '^_^20230112 mark by 7643 -e-
        '^_^20230112 modi by 7643 -b-
        mPPD = IIf(chkPPD.Checked, 1, 0)
        lstQuerries.Add("insert into DATA1A_Customers ( AccountNameGB, AccountNameVN, ShortName, Province, Region" _
                        & ", PIC, Web, AccountStatus,AccountTypes, MarketSize, AmadeusSize, Comments" _
                        & ", Status, FstUser,DataApiToken, CustAddress, CustTaxCode, Email,PPD) values ('" _
                        & txtAccountNameGB.Text & "',N'" & txtAccountNameVN.Text & "','" & txtShortName.Text _
                        & "','" & cboProvince.Text & "','" & cboRegion.Text & "','" & cboPIC.Text _
                        & "','" & txtWeb.Text & "','" & cboAccountStatus.Text & "','" & ConvertGroupbox2Str(grbAccountTypes) _
                        & "','" & cboMarketSize.Text _
                        & "','" & cboAmadeusSize.Text & "',N'" & txtComments.Text _
                        & "','OK','" & pobjUser.UserName _
                        & "','" & txtDataApiToken.Text & "', '" & txtCustAddress.Text & "', '" & txtCustTaxCode.Text & "', '" & txtEmail.Text & "'," & mPPD & ")")
        '^_^20230112 modi by 7643 -e-
        '^_^20221021 modi by 7643 -e-
        If txtRecId.Text <> "" Then
            lstQuerries.Add("Update DATA1A_Customers set Status='XX', LstUpdate=getdate() where RecId=" & txtRecId.Text)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Me.Dispose()
        Else
            MsgBox("Unable to update Customer")
            Exit Sub
        End If
    End Sub

    Private Sub cboRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRegion.SelectedIndexChanged
        Dim strPicQuerry As String = "Select UserName as Value from DATA1A_User where Status<>'XX'"
        Dim strCitiesQuerry As String = "Select VAL as Value from DATA1A_MISC where cat='VNCITIES' order by VAL"

        pobjSql.LoadCombo(cboProvince, strCitiesQuerry)
        Select Case cboRegion.Text
            Case "North"
                strPicQuerry = strPicQuerry & " and City='HAN'"
                cboProvince.Text = "Ha Noi"
            Case "South"
                strPicQuerry = strPicQuerry & " and City='SGN'"
                cboProvince.Text = "TP Ho Chi Minh"
        End Select
        strPicQuerry = strPicQuerry & " order by UserName"
        pobjSql.LoadCombo(cboPIC, strPicQuerry)

    End Sub
End Class