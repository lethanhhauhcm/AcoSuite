Public Class frmGiftInOutItemEdit
    Private mstrInOut As String
    Private mstrRequester As String
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strQuerry As String 

        If Not CheckInputValues() Then '
            Exit Sub
        End If
        If txtRecId.Text = 0 Then
            Dim strStatus As String = IIf(mstrInOut = "IN", "OK", "QQ")
            strQuerry = "Insert into Data1a_GiftInOut (InOut,GiftId,Quantity,Reason,Status,FstUser,Region) Values ('" _
                        & mstrInOut & "'," & cboGiftName.SelectedValue & "," & txtQuantity.Text _
                        & ",'" & txtReason.Text & "','" & strStatus & "','" & mstrRequester _
                        & "','" & pobjUser.Region  & "')"
        Else
            strQuerry = "Update  Data1a_GiftInOut set LstUpdate=Getdate(), LstUser='" & pobjUser.UserName _
                        & "', GiftId=" & cboGiftName.SelectedValue & ", Quantity=" & txtQuantity.Text _
                        & ",Reason='" & txtReason.Text & "' where Recid=" & txtRecId.Text
        End If
        If pobjSql.ExecuteNonQuerry(strQuerry) Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        Else
            MsgBox("Unable to Update")
        End If
    End Sub
    Private Function CheckInputValues() As Boolean
        Dim intAvailStock As Integer

        If Not IsNumeric(txtQuantity.Text) Then
            MsgBox("Invalid Quantity")
            Return False
        End If
        If mstrInOut = "OUT" Then
            intAvailStock = pobjSql.GetScalarAsString("Select isnull(Sum (Quantity * (case InOut When 'In' then 1 else -1 end)),0)" _
                                            & " from Data1a_GiftInOut" _
                                            & " where Region='" & pobjUser.Region & "' and Status<>'XX' and GiftId=" _
                                            & cboGiftName.SelectedValue)
            If txtQuantity.Text > intAvailStock Then
                MsgBox("Max Available Stock:" & intAvailStock)
                Return False
            End If
        End If
        
        Return True
    End Function

    Public Sub New(strInOut As String, Optional dgrGift As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        pobjSql.LoadComboVal(cboGiftName, "Select RecId as Value, Val as Display from Data1a_Misc where Cat='GiftDefinition" _
                             & pobjUser.City & "' order by Display")

        mstrInOut = strInOut
        If strInOut = "IN" Then
            lblReason.Text = "PO"
        Else
            lblReason.Text = "Reason"
        End If

        If dgrGift Is Nothing Then
            mstrRequester = pobjUser.UserName
            cboGiftName.SelectedIndex = 0
        Else
            cboGiftName.SelectedIndex = cboGiftName.FindStringExact(dgrGift.Cells("GiftName").Value)
            txtRecId.Text = dgrGift.Cells("RecId").Value
            mstrRequester = dgrGift.Cells("Requester").Value
            txtQuantity.Text = dgrGift.Cells("Quantity").Value
            txtReason.Text = dgrGift.Cells("Reason").Value
        End If

        

    End Sub
End Class