Public Class frmIncentiveAdhocEdit

    Private mstrStatus As String

    Public Sub New(Optional dgrAdhoc As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim strRegion As String = pobjUser.Region

        
        If dgrAdhoc Is Nothing Then
            pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' and PIC='" & pobjUser.UserName & "' order by ShortName")
            txtRecId.Text = 0
            cboShortName.SelectedIndex = 0
            cboTimeFrame.SelectedIndex = 0
            cboIncType.SelectedIndex = 0
            cboUnit.SelectedIndex = 0
            txtOldIncentiveId.Text = 0
            txtStatus.Text = "--"
        Else
            With dgrAdhoc
                pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' and PIC='" & .Cells("PIC").Value & "' order by ShortName")

                cboShortName.SelectedIndex = cboShortName.FindStringExact(.Cells("ShortName").Value)
                cboTimeFrame.SelectedIndex = cboTimeFrame.FindStringExact(.Cells("TimeFrame").Value)
                cboIncType.SelectedIndex = cboIncType.FindStringExact(.Cells("IncType").Value)
                cboYear.SelectedIndex = cboYear.FindStringExact(.Cells("BookYear").Value)
                cboPeriod.SelectedIndex = cboPeriod.FindStringExact(.Cells("Period").Value)
                cboQuarter.SelectedIndex = cboPeriod.FindStringExact(.Cells("CalcQuarter").Value)
                cboContact.SelectedIndex = cboPeriod.FindStringExact(.Cells("ContactName").Value)
                cboUnit.SelectedIndex = cboUnit.FindStringExact(.Cells("Unit").Value)
                txtRecId.Text = .Cells("RecId").Value
                txtVND.Text = .Cells("VND").Value
                txtReason.Text = .Cells("Reason").Value
                mstrStatus = .Cells("Status").Value
                txtOldIncentiveId.Text = .Cells("OldIncentiveId").Value
                txtStatus.Text = .Cells("Status").Value
            End With

        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerries As New List(Of String)
        Dim intContactId As Integer
        Dim strObject As String
        Dim intOldIncentiveId As Integer

        If Not CheckInputValues() Then
            Exit Sub
        End If

        If cboContact.SelectedValue Is Nothing Then
            intContactId = 0
            strObject = "Customer"
        Else
            intContactId = cboContact.SelectedValue
            strObject = "Contact"
        End If

        If txtStatus.Text = "OK" Then
            intOldIncentiveId = txtRecId.Text
        Else
            intOldIncentiveId = txtOldIncentiveId.Text
            lstQuerries.Add("Delete Data1A_IncentiveAdhoc where RecId=" & txtRecId.Text)
        End If
        lstQuerries.Add("Insert into Data1A_IncentiveAdhoc (OldIncentiveId,ShortName,Object,ContactId,IncType" _
                        & " , TimeFrame, Status, BookYear,CalcQuarter, Period" _
                        & ",VND,Reason, FstUser,Unit)" _
                        & " values (" & intOldIncentiveId & ",'" & cboShortName.Text & "','" & strObject & "'," & intContactId _
                        & ",'" & cboIncType.Text & "','" & cboTimeFrame.Text _
                        & "','--'," & cboYear.Text & "," & cboQuarter.Text & "," & cboPeriod.Text _
                        & "," & txtVND.Text & ",'" & txtReason.Text _
                        & "','" & pobjUser.UserName & "','" & cboUnit.Text & "')")



        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        Else
            MsgBox("Unable to Add/Edit Offer")
        End If

    End Sub
    Private Function CheckInputValues() As Boolean

        If cboShortName.Text = "" Then
            MsgBox("Invalid ShortName")
            Return False
        ElseIf cboTimeFrame.Text = "" Then
            MsgBox("Invalid TimeFrame")
            Return False
        ElseIf cboIncType.Text = "" Then
            MsgBox("Invalid IncType")
            Return False
        ElseIf cboYear.Text = "" Then
            MsgBox("Invalid Year")
            Return False
        ElseIf cboQuarter.Text = "" Then
            MsgBox("Invalid Quarter")
            Return False
        ElseIf cboPeriod.Text = "" Then
            MsgBox("Invalid Period!")
            Return False
        ElseIf cboUnit.Text = "" Then
            MsgBox("Invalid Unit!")
            Return False
        ElseIf Not CheckFormatTextBox(txtVND, , True, 1) Then
            Return False
        ElseIf txtReason.Text = "" Then
            MsgBox("Invalid Reason")
            Return False
        End If

        If txtRecId.Text <> 0 _
            AndAlso pobjSql.GetScalarAsString("Select count(OldIncentiveId) from Data1a_IncentiveAdhoc" _
                                            & " where Status='--' and OldIncentiveId=" & txtRecId.Text) > 0 Then
            MsgBox("Pending Edited Record exist!")
            Return False
        End If

        Return True
    End Function

    Private Sub cboTimeFrame_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTimeFrame.SelectedIndexChanged
        GenerateComboPeriod()
    End Sub

    Private Sub GenerateComboPeriod()
        Dim i As Integer
        Dim intNbrOfPeriod As Integer
        Select Case cboTimeFrame.Text
            Case "Month"
                intNbrOfPeriod = 12
            Case "Quarter"
                intNbrOfPeriod = 4
            Case "HalfYear"
                intNbrOfPeriod = 2
            Case "Year"
                intNbrOfPeriod = 1
        End Select
        With cboPeriod.Items
            .Clear()
            For i = 1 To intNbrOfPeriod
                .Add(i)
            Next
        End With
    End Sub


    Private Sub cboShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged
        If txtRecId.Text <> "0" Then
            txtRecId.Text = 0
        End If

        pobjSql.LoadComboVal(cboContact, "Select FullNameGB as Display, ContactId as Value from DATA1A_Contacts" _
                          & " where Status='OK' and CustShortName='" & cboShortName.Text & "'")
        cboContact.SelectedIndex = -1
    End Sub

    Private Sub frmIncentiveAdhocEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class