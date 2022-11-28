Public Class frmDeleteCustomer

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim lstQuerries As New List(Of String)

        If Not CheckInputValue() Then
            Exit Sub
        ElseIf MsgBox("Deleted Data can NOT be restored. Continue?") <> MsgBoxResult.Ok Then
            Exit Sub
        End If

        If txtCountShortName.Text > 1 Then
            Dim frmCustSelection As New frmSelectCustomer("Select * from data1a_Customers where Status<>'XX'" _
                                                          & " and ShortName='" & txt2BeDeleted.Text & "'")

            If frmCustSelection.ShowDialog() = Windows.Forms.DialogResult.OK Then
                lstQuerries.Add("Update DATA1A_Customers Set Status='XX', LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                                & "' where Status<>'XX' and RecId=" & frmCustSelection.Customer.Recid)
            End If
        Else
            If txtMIDT.Text > 0 Then
                lstQuerries.Add("update [MIDT_Raw] set AgentName='" & cboCustomer.Text _
                                & "' where AgentName='" & txt2BeDeleted.Text & "'")
            End If
            If txtGdsSkills.Text > 0 Then
                lstQuerries.Add("Update [DATA1A_GdsSkills] Set Status='XX', LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                                & "' where Status<>'XX' and ContactId in (Select ContactId from DATA1A_Contacts" _
                                & " where Status<>'XX' and CustShortName='" & txt2BeDeleted.Text & "')")
            End If
            If txtSignIn1A.Text > 0 Then
                lstQuerries.Add("Update [DATA1A_SignIn1As] Set Status='XX', LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                                & "' where Status<>'XX' and " _
                                & "ContactId in (Select ContactId from DATA1A_Contacts where Status<>'XX' and CustShortName='" _
                                & txt2BeDeleted.Text & "')")
            End If

            If txtOffcIds.Text > 0 Then
                lstQuerries.Add("Update [DATA1A_OIDs] Set Status='XX', LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                                & "' where Status<>'XX' and ShortName='" & txt2BeDeleted.Text & "'")
            End If

            If txtIataCodes.Text > 0 Then
                lstQuerries.Add("Update [DATA1A_IataCodes] Set Status='XX', LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                                & "' where Status<>'XX' and ShortName='" & txt2BeDeleted.Text & "'")
            End If

            If txtLocations.Text > 0 Then
                lstQuerries.Add("Update [DATA1A_Locations] Set Status='XX', LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                                & "' where Status<>'XX' and ShortName='" & txt2BeDeleted.Text & "'")
            End If
            If txtContact.Text > 0 Then
                lstQuerries.Add("Update [DATA1A_Contacts] Set Status='XX', LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                                & "' where Status<>'XX' and CustShortName='" & txt2BeDeleted.Text & "'")
            End If
            If txtCountShortName.Text = 1 Then
                lstQuerries.Add("Update [DATA1A_Customers] Set Status='XX', LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                                & "' where Status<>'XX' and ShortName='" & txt2BeDeleted.Text & "'")
            End If
        End If

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            MsgBox("Deletion completed")
            cboCustomer.SelectedIndex = -1
        Else
            MsgBox("Deletion NOT completed")
        End If

    End Sub
    Private Function CheckInputValue() As Boolean
        If txtMIDT.Text > 0 AndAlso cboCustomer.Text = "" Then
            MsgBox("You must select New Customer to link Booking data to")
            Return False
        End If
        Return True
    End Function

    Private Sub txt2BeDeleted_Leave(sender As Object, e As EventArgs) Handles txt2BeDeleted.Leave

        txtCountShortName.Text = pobjSql.GetScalarAsString("Select Count (*) from [DATA1A_Customers] where  Status<>'XX'" _
                                                           & " and  ShortName='" & txt2BeDeleted.Text & "'")
        txtMIDT.Text = pobjSql.GetScalarAsString("Select Count (*) from [MIDT_Raw] where AgentName='" _
                                                 & txt2BeDeleted.Text & "'")
        txtOffcIds.Text = pobjSql.GetScalarAsString("Select Count (*) from [DATA1A_OIDs] where Status<>'XX' and ShortName='" _
                                                 & txt2BeDeleted.Text & "'")
        txtIataCodes.Text = pobjSql.GetScalarAsString("Select Count (*) from [DATA1A_IataCodes] where Status<>'XX' and ShortName='" _
                                                 & txt2BeDeleted.Text & "'")
        txtLocations.Text = pobjSql.GetScalarAsString("Select Count (*) from [DATA1A_Locations] where Status<>'XX' and ShortName='" _
                                                 & txt2BeDeleted.Text & "'")
        txtContact.Text = pobjSql.GetScalarAsString("Select Count (*) from [DATA1A_Contacts] where Status<>'XX' and CustShortName='" _
                                                 & txt2BeDeleted.Text & "'")
        txtSignIn1A.Text = pobjSql.GetScalarAsString("Select Count (*) from [DATA1A_SignIn1As] where Status<>'XX' and " _
                                                     & "ContactId in (Select ContactId from DATA1A_Contacts where Status<>'XX' and CustShortName='" _
                                                    & txt2BeDeleted.Text & "')")
        txtGdsSkills.Text = pobjSql.GetScalarAsString("Select Count (*) from [DATA1A_GdsSkills] where Status<>'XX' and " _
                                                     & "ContactId in (Select ContactId from DATA1A_Contacts where Status<>'XX' and CustShortName='" _
                                                    & txt2BeDeleted.Text & "')")


    End Sub

    Private Sub DeleteCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadCombo(cboCustomer, "Select ShortName as Value from Data1a_Customers where Status='OK' order by ShortName")
        cboCustomer.SelectedIndex = -1
    End Sub
End Class