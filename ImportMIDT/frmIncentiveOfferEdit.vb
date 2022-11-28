Public Class frmIncentiveOfferEdit
    Private mstrStatus As String
    Private mintRecId As Integer
    Private mdteCalcUpTo As Date
    Private mdteCalcUpTo4Tkt As Date
    Private mblnFirstLoadCompleted As Boolean
    Public Sub New(Optional dgrOfferRow As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim strRegion As String = IIf(pobjUser.City = "SGN", "South", "North")
        AddFromDatesMonthly(cboValidFrom, 12, 1)
        AddToDatesQuartely(cboValidTo)


        If dgrOfferRow Is Nothing Then
            txtOfferId.Text = 0
            If My.Computer.Name = "5-247" Then
                pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' and ShortName in (Select distinct ShortName from Data1a_OIDS where Status='OK' and GDS='1A')" _
                        & " order by ShortName")
            Else
                pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' and PIC='" & pobjUser.UserName _
                        & "' and ShortName in (Select distinct ShortName from Data1a_OIDS where Status='OK' and GDS='1A')" _
                        & " order by ShortName")
            End If
            cboShortName.SelectedIndex = 0
            'AddFromDatesMonthly(cboValidFrom, 12, 1)
            'AddToDatesQuartely(cboValidTo)
            cboTimeFrame.SelectedIndex = 0
            cboObject.SelectedIndex = 0
        Else
            With dgrOfferRow
                pobjSql.LoadDataGridView(dgFormula, "Select * from Data1A_IncentiveFormula where RecId in" _
                                         & " (select VAL1 from DATA1A_MISC where CAT='OfferFormula' and VAL=" _
                                         & .Cells("OfferId").Value & ") order by VND,Unit,ObjectTarget")
                txtOfferId.Text = .Cells("OfferId").Value
                mstrStatus = .Cells("Status").Value
                mintRecId = .Cells("RecId").Value
                Try
                    mdteCalcUpTo = .Cells("CalcUpTo").Value
                    mdteCalcUpTo4Tkt = .Cells("CalcUpTo4Tkt").Value
                Catch ex As Exception

                End Try


                'Offer cho phe duyet sau khi tao ra ko duoc phep doi 
                If txtOfferId.Text > 0 Then
                    If .Cells("Status").Value = "EX" Then
                        dgFormula.Enabled = False
                        btnSelect.Visible = False
                        btnSave.Enabled = False
                        chkManualCheckRequired.Enabled = False
                    ElseIf .Cells("Status").Value = "OK" Then
                        cboShortName.Items.Insert(0, .Cells("ShortName").Value)
                        cboShortName.SelectedIndex = 0
                        cboValidFrom.Items.Insert(0, .Cells("ValidFrom").Value)
                        cboValidFrom.SelectedIndex = 0
                        cboValidTo.Items.Insert(0, .Cells("ValidTo").Value)
                        cboValidTo.SelectedIndex = 0
                    Else
                        cboValidFrom.SelectedIndex = cboValidFrom.FindStringExact(Format(.Cells("ValidFrom").Value, "dd MMM yy"))
                        cboValidTo.SelectedIndex = cboValidTo.FindStringExact(Format(.Cells("ValidTo").Value, "dd MMM yy"))
                    End If

                    cboObject.SelectedIndex = cboObject.FindStringExact(.Cells("Object").Value)
                    cboTimeFrame.SelectedIndex = cboTimeFrame.FindStringExact(.Cells("TimeFrame").Value)
                    cboShortName.Enabled = False
                    cboObject.Enabled = False
                    cboTimeFrame.Enabled = False

                    If pobjSql.IsIncentiveCalculated(dgrOfferRow.Cells("ValidFrom").Value, dgrOfferRow.Cells("ValidTo").Value) Then
                        cboValidFrom.Enabled = False
                    End If
                End If

                'Offer da duoc phe duyet 1 lan trong qua khu khong duoc phep doi
                'If .Cells("Status").Value = "OK" Then
                '    dgFormula.Enabled = False
                '    btnSelect.Visible = False
                '    chkManualCheckRequired.Enabled = False
                'Else


            End With

        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmIncentiveFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mblnFirstLoadCompleted = True

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim i As Integer
        Dim lstQuerries As New List(Of String)
        Dim intNewOfferId As Integer
        Dim strNewStatus As String = String.Empty

        If dgFormula.RowCount = 0 Then
            Exit Sub
        End If

        If Not CheckInputValues() Then
            Exit Sub
        End If

        If pobjUser.Region = "North" Then
            strNewStatus = "OK"
        ElseIf mstrStatus = "" Or mstrStatus = "OK" Then
            strNewStatus = "--"
        End If

        Select Case mstrStatus
            Case ""
                lstQuerries.Add("Insert into Data1A_IncentiveOffer (OfferId,ShortName,Object, TimeFrame, Status" _
                                & ", ValidFrom, ValidTo, OriRecID,ManualCheckRequired, FstUser)" _
                                & " values ((Select isnull(Max(OfferId),0)+1 from Data1A_IncentiveOffer),'" _
                                & cboShortName.Text & "','" & cboObject.Text & "','" & cboTimeFrame.Text _
                                & "','" & strNewStatus & "','" & cboValidFrom.Text & "','" & cboValidTo.Text _
                                & "',0,'" & chkManualCheckRequired.Checked & "','" & pobjUser.UserName & "')")
                pobjSql.UpdateListOfQuerries(lstQuerries, True)
                lstQuerries.Clear()
                intNewOfferId = pobjSql.GetScalarAsString("Select OfferId from Data1A_IncentiveOffer where RecId=" _
                                                          & pobjSql.LastInsertedId)
                With dgFormula
                    For i = 0 To dgFormula.RowCount - 1
                        lstQuerries.Add("Insert into DATA1A_MISC (CAT,VAL,VAL1) values ('OfferFormula','" _
                                        & intNewOfferId & "','" & .Rows(i).Cells("RecId").Value & "')")
                    Next
                End With

            Case "OK"
                lstQuerries.Add("Insert into Data1A_IncentiveOffer (OfferId,ShortName,Object, TimeFrame, Status" _
                                & ", ValidFrom, ValidTo, OriRecID,ManualCheckRequired, FstUser)" _
                                & " values (" & txtOfferId.Text & ",'" & cboShortName.Text & "','" & cboObject.Text & "','" & cboTimeFrame.Text _
                                & "','" & strNewStatus & "','" & cboValidFrom.Text & "','" & cboValidTo.Text _
                                & "'," & mintRecId & ",'" & chkManualCheckRequired.Checked & "','" & pobjUser.UserName & "')")

            Case "--", "RJ"
                lstQuerries.Add("update Data1A_IncentiveOffer set Status='--',ShortName='" & cboShortName.Text _
                                & "',Object='" & cboObject.Text & "',TimeFrame='" & cboTimeFrame.Text _
                                & "',ValidFrom='" & cboValidFrom.Text & "',ValidTo='" & cboValidTo.Text _
                                & "',ManualCheckRequired='" & chkManualCheckRequired.Checked _
                                & "',LstUser='" & pobjUser.UserName & "',LstUpdate=getdate() where Status in ('--','RJ')" _
                                & " and RecId=" & mintRecId)

                'xoa cac formula cu
                lstQuerries.Add("delete DATA1A_MISC where CAT='OfferFormula' and VAL='" & txtOfferId.Text & "'")

                'them cac formula moi
                With dgFormula
                    For i = 0 To dgFormula.RowCount - 1
                        lstQuerries.Add("Insert into DATA1A_MISC (CAT,VAL,VAL1) values ('OfferFormula','" _
                                        & txtOfferId.Text & "','" & .Rows(i).Cells("RecId").Value & "')")
                    Next
                End With

            Case Else

        End Select

        
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
        ElseIf cboObject.Text = "" Then
            MsgBox("Invalid Object")
            Return False
        ElseIf Not IsEndOfPeriod(cboValidTo.Text, ConvertTimeFrame2Int(cboTimeFrame.Text)) Then
            MsgBox("ValidTo is NOT End of TimeFrame")
            Return False
        ElseIf DateDiff(DateInterval.Day, CDate(cboValidFrom.Text), CDate(cboValidTo.Text)) <= 0 Then
            MsgBox("ValidFrom must before ValidTo")
            Return False
            'ElseIf pobjSql.IsIncentiveCalculatedByDate(cboValidFrom.Text, cboTimeFrame.Text, cboShortName.Text) Then
            '    MsgBox("Invalid ValidFrom. Incentives had been calculated!")
            '    Return False
            'ElseIf pobjSql.IsIncentiveCalculatedByDate(cboValidTo.Text, cboTimeFrame.Text, cboShortName.Text) Then
            '    MsgBox("Invalid ValidTo. Incentives had been calculated!")
            '    Return False
        ElseIf Not IsDBNull(mdteCalcUpTo) AndAlso mdteCalcUpTo > CDate(cboValidTo.Text) Then
            MsgBox("Invalid ValidTo. Incentives had been calculated!")
            Return False
        End If

        With dgFormula
            For i = 0 To dgFormula.RowCount - 1
                Dim strDupCheck As String = "Select top 1 RecId from Data1a_IncentiveOffer where Status='--' and Object='" _
                                             & cboObject.Text & "' and ShortName='" & cboShortName.Text _
                                             & "' and TimeFrame='" & cboTimeFrame.Text _
                                             & "' and RecId<>" & mintRecId _
                                             & " and ('" & cboValidFrom.Text & "' between ValidFrom and ValidTo" _
                                             & " or '" & cboValidTo.Text & "' between ValidFrom and ValidTo)"

                Dim intDupOfferId As Integer = pobjSql.GetScalarAsString(strDupCheck)
                If intDupOfferId > 0 Then
                    MsgBox("Duplicate/Overlap with RecId " & intDupOfferId)
                    Return False
                End If
            Next
        End With
        Return True
    End Function

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim frmSelect As New frmSelectIncentiveFormula(cboTimeFrame.Text, cboObject.Text)
        If frmSelect.ShowDialog = Windows.Forms.DialogResult.OK Then

            pobjSql.LoadDataGridView(dgFormula, "Select * from Data1a_IncentiveFormula where Recid in (" _
                                     & pstrIncentiveFormulas & ") order by VND ")
            With dgFormula

            End With
        End If
    End Sub

    Private Sub cboObject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboObject.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            dgFormula.Rows.Clear()
        End If

    End Sub

    Private Sub cboTimeFrame_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTimeFrame.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            dgFormula.Rows.Clear()
        End If

    End Sub
End Class