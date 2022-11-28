Public Class frmCloneWzNewValidity
    Private mblnFirstSearchCompleted As Boolean

    Private Sub frmCloneWzNewValidity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim strRegion As String = IIf(pobjUser.City = "SGN", "South", "North")
        AddFromDatesMonthly(cboValidFrom, 12, 1)
        AddToDatesQuartely(cboValidTo)
        cboValidFrom.SelectedIndex = 4
        cboValidTo.SelectedIndex = 7
        Search()
        mblnFirstSearchCompleted = True
    End Sub

    Public Sub New(strCustShortName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pobjSql.LoadCombo(cboCustomers, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & pobjUser.Region & "' and PIC='" & pobjUser.UserName & "' order by ShortName")
        cboCustomers.SelectedIndex = cboCustomers.FindStringExact(strCustShortName)
        
    End Sub
    Private Function Search() As Boolean
        Dim strQuerry As String
        Dim i As Integer
        strQuerry = "Select cast('true' as bit) as Selected, * " _
                    & " from data1a_IncentiveOffer where Status<>'XX' and Shortname='" _
                    & cboCustomers.Text & "'"
        pobjSql.LoadDataGridView(dgOffer, strQuerry)

        If dgOffer.Columns.Count > 0 Then
            For i = 1 To dgOffer.Columns.Count - 1
                dgOffer.Columns(i).ReadOnly = True
            Next
        End If

        Return True
    End Function

    Private Sub lbkCopy_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkCopy.LinkClicked

        Dim lstQuerries As New List(Of String)
        Dim intNewOfferId As Integer
        Dim strShortName As String = cboCustomers.Text

        If cboValidFrom.Text = "" Then
            MsgBox("Invalid ValidFrom")
            Exit Sub
        ElseIf cboValidTo.Text = "" Then
            MsgBox("Invalid ValidTo")
            Exit Sub
        ElseIf CDate(cboValidFrom.Text) > CDate(cboValidTo.Text) Then
            MsgBox("Valid From must be before ValidTo")
            Exit Sub
        End If

        For Each objRow As DataGridViewRow In dgOffer.Rows
            With objRow
                If Not .Cells("Selected").Value Then
                    Continue For
                End If
                lstQuerries.Clear()
                If pobjSql.IsIncentiveCalculatedByDate(cboValidFrom.Text, cboValidTo.Text _
                                                       , strShortName) Then
                    MsgBox("Invalid ValidFrom. Incentives had been calculated for customer" & strShortName)

                ElseIf pobjSql.IsIncentiveCalculatedByDate(cboValidFrom.Text, cboValidTo.Text _
                               , strShortName) Then
                    MsgBox("Invalid ValidTo. Incentives had been calculated for customer" & strShortName)
                End If


                Dim strDupCheck As String = "Select top 1 RecId from Data1a_IncentiveOffer " _
                                            & " where Status='--' and Object='" _
                                     & .Cells("Object").Value _
                                     & "' and ShortName='" & strShortName _
                                     & "' and TimeFrame='" & .Cells("TimeFrame").Value _
                                     & "' and ('" & CreateFromDate(cboValidFrom.Text) _
                                     & "' between ValidFrom and ValidTo" _
                                     & " or '" & CreateFromDate(cboValidTo.Text) _
                                     & "' between ValidFrom and ValidTo)"

                Dim strDupOfferId As String = pobjSql.GetScalarAsString(strDupCheck)

                If strDupOfferId <> "" Then
                    MsgBox("Duplicate/Overlap with RecId " & strDupOfferId _
                           & " for customer " & strShortName)
                Else
                    lstQuerries.Add("Insert into Data1A_IncentiveOffer (OfferId,ShortName,Object, TimeFrame, Status" _
                            & ", ValidFrom, ValidTo, OriRecID,ManualCheckRequired, FstUser)" _
                            & " values ((Select isnull(Max(OfferId),0)+1 from Data1A_IncentiveOffer),'" _
                            & strShortName & "','" & .Cells("Object").Value _
                            & "','" & .Cells("TimeFrame").Value _
                            & "','--','" & CreateFromDate(cboValidFrom.Text) _
                            & "','" & CreateFromDate(cboValidTo.Text) _
                            & "',0,'" & .Cells("ManualCheckRequired").Value _
                            & "','" & pobjUser.UserName & "')")
                    If Not pobjSql.UpdateListOfQuerries(lstQuerries, True) Then
                        MsgBox("Unable to copy to Customer " & strShortName)
                        Continue For
                    End If
                    intNewOfferId = pobjSql.GetScalarAsString("Select Offerid from Data1A_IncentiveOffer where RecId=" _
                                                              & pobjSql.LastInsertedId.ToString)
                    lstQuerries.Clear()

                    lstQuerries.Add("Insert DATA1A_MISC (CAT,VAL,VAL1) " _
                                    & "Select 'OfferFormula','" & intNewOfferId _
                                    & "',VAL1 from DATA1A_MISC where Cat='OfferFormula' and  Val='" _
                                    & .Cells("OfferId").Value & "'")

                    If Not pobjSql.UpdateListOfQuerries(lstQuerries, True) Then
                        MsgBox("Unable to copy Formula to Customer " & strShortName)
                        Continue For
                    End If

                End If
            End With
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    'Private Sub cboCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomers.SelectedIndexChanged
    '    If mblnFirstSearchCompleted Then
    '        Search()
    '    End If

    'End Sub
End Class