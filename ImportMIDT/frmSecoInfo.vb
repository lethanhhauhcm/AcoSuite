Public Class frmSecoInfo

    Private mintContactId As Integer
    Private mstrShortName As String
    Private mstrSecoInfo As String
    Private mintRecId As Integer
    Private mstrAccessRole As String

    Public Sub New(dgrContactInfo As DataGridViewRow, strAccessRole As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrAccessRole = strAccessRole
        mintContactId = dgrContactInfo.Cells("ContactId").Value
        mintRecId = dgrContactInfo.Cells("RecId").Value
        mstrShortName = dgrContactInfo.Cells("CustShortName").Value
        mstrSecoInfo = dgrContactInfo.Cells("SecoID").Value

        pobjSql.LoadCombo(cboProduct, "Select distinct ProductName AS VALUE from Data1a_ProductOffer where Status='OK'" _
                          & " and substring (ProductName,1,4)='SECO' order by ProductName")
        cboEmail.Items.Add(dgrContactInfo.Cells("PersonalEmail").Value)
        cboEmail.Items.Add(dgrContactInfo.Cells("BusinessEmail").Value)
        txtMobile.Text = dgrContactInfo.Cells("Mobile").Value
        txtDOB.Text = dgrContactInfo.Cells("DOB").Value


        pobjSql.LoadDataGridView(dgSignIn1A, "Select OffcId,SignIn from Data1a_SignIn1As where Status='OK' and ContactId=" & mintContactId)
    End Sub

    Private Sub frmSecoInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim arrSecoInfo As String() = mstrSecoInfo.Split("|")
        If mstrSecoInfo <> "" Then
            cboProduct.SelectedIndex = cboProduct.FindStringExact(arrSecoInfo(0))
            cboEmail.SelectedIndex = cboEmail.FindStringExact(arrSecoInfo(1))
            'cboEmail.Enabled = Not (mstrAccessRole = "SECO")
            If arrSecoInfo.Length = 3 AndAlso arrSecoInfo(2) = "Y" Then
                chkAdmin.Checked = True
            Else
                chkAdmin.Checked = False
            End If
        End If

    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        pobjSql.ExecuteNonQuerry("Update Data1a_Contacts set SecoId='' where RecId=" & mintRecId)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub lbkSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSave.LinkClicked

        If Not CheckFormatComboBox(cboProduct, , 1) Then
            Exit Sub
        ElseIf Not CheckFormatComboBox(cboEmail, , 1) Then
            Exit Sub
        End If

        pobjSql.ExecuteNonQuerry("Update Data1a_Contacts set SecoId='" & cboProduct.Text _
                                 & "|" & cboEmail.Text & "|" & IIf(chkAdmin.Checked, "Y", "N") _
                                 & "'  where RecId=" & mintRecId)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub lbkUpdateSecoID_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkUpdateSecoID.LinkClicked
        Dim lstQuerries As New List(Of String)
        Dim tblSecoRecord As DataTable
        tblSecoRecord = pobjSql.GetDataTable("Select top 1 * from Data1a_ProductRights r" _
                                             & " left join Data1a_contacts c on r.ContactId=c.ContactId and c.Status='OK'" _
                                            & " where r.status='OK'" _
                                            & " and Getdate() between ValidFrom and ValidTo and ProductId='" & txtSecoId.Text & "'")
        If tblSecoRecord.Rows.Count > 0 Then
            MsgBox("This SecoId had been updated in the past for " & tblSecoRecord.Rows(0)("ShortName") _
                   & "/" & tblSecoRecord.Rows(0)("FullNameVN"))
            Exit Sub
        End If
        lstQuerries.Add("Update Data1a_Contacts set SecoId='" & txtSecoId.Text & "' where RecId=" & mintRecId)
        lstQuerries.Add("Insert into  [Data1A_ProductRights] (Region,[ShortName],[ContactId],[Product],[ProductId],Status,FstUser)" _
                        & " values ('" & pobjUser.Region & "','" & mstrShortName & "'," & mintContactId & ",'" & cboProduct.Text _
                        & "','" & txtSecoId.Text & "','OK','" & pobjUser.UserName & "')")

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        End If
        
    End Sub

    Private Sub lbkCopy_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkCopy.LinkClicked
        Clipboard.SetText(cboEmail.Text)
    End Sub
End Class