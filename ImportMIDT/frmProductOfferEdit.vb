Public Class frmProductOfferEdit
    Private mstrStatus As String
    Private mintRecId As Integer
    Private mstrChargedUpTo As String
    Public Sub New(Optional dgrOfferRow As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Dim strRegion As String = IIf(pobjUser.City = "SGN", "South", "North")
        AddFromDatesMonthly(cboValidFrom, 15, 1)
        AddToDatesQuartely(cboValidTo)
        RemoveHandler cboShortName.SelectedIndexChanged, AddressOf cboShortName_SelectedIndexChanged
        If My.Computer.Name = "5-074" Or pobjUser.UserName = "vandeptrai" Or pobjUser.UserName = "batx" Or pobjUser.UserName = "quangnt" Then
            pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' and ShortName in (Select distinct ShortName from Data1a_OIDS where Status='OK' and GDS='1A')" _
                        & " order by ShortName")
        Else
            pobjSql.LoadCombo(cboShortName, "Select ShortName as Value from DATA1A_Customers where Status='OK' and Region='" _
                          & strRegion & "' and PIC='" & pobjUser.UserName _
                        & "' and ShortName in (Select distinct ShortName from Data1a_OIDS where Status='OK' and GDS='1A')" _
                        & " order by ShortName")
        End If
        pobjSql.LoadCombo(cboProductName, "Select distinct ProductName as value from Data1a_ProductCosts where Status<>'XX' and CostPrice='PRICE'" _
                          & " order by ProductName")
        If dgrOfferRow Is Nothing Then
            txtOfferId.Text = 0
            cboShortName.SelectedIndex = 0
            cboObject.SelectedIndex = 0
            cboProductName.SelectedIndex = 0
        Else
            With dgrOfferRow
                cboShortName.SelectedIndex = cboShortName.FindStringExact(.Cells("ShortName").Value)
                cboObject.SelectedIndex = cboObject.FindStringExact(.Cells("Object").Value)
                cboValidFrom.SelectedIndex = cboValidFrom.FindStringExact(Format(.Cells("ValidFrom").Value, "dd MMM yy"))
                cboValidTo.SelectedIndex = cboValidTo.FindStringExact(Format(.Cells("ValidTo").Value, "dd MMM yy"))
                cboProductName.SelectedIndex = cboProductName.FindStringExact(.Cells("ProductName").Value)
                pobjSql.LoadDataGridView(dgFormula, "Select * from Data1A_ProductCosts where RecId in" _
                                         & " (select VAL1 from DATA1A_MISC where CAT='ProductOfferPrice' and VAL=" _
                                         & .Cells("OfferId").Value & ") order by Amount")
                txtOfferId.Text = .Cells("OfferId").Value
                mstrStatus = .Cells("Status").Value
                mintRecId = .Cells("RecId").Value
                mstrChargedUpTo = CreateFromDate(.Cells("ChargedUpTo").Value)
                'Offer cho phe duyet sau khi tao ra ko duoc phep doi 
                If txtOfferId.Text > 0 Then
                    cboShortName.Enabled = False
                    cboObject.Enabled = False
                    cboProductName.Enabled = False
                    'If pobjSql.IsProductCalculated(cboValidFrom.Text, cboValidTo.Text) Then
                    '    cboValidFrom.Enabled = False
                    'End If
                End If

                'Offer da duoc phe duyet 1 lan trong qua khu khong duoc phep doi
                'If .Cells("Status").Value = "OK" Then
                '    dgFormula.Enabled = False
                '    btnSelect.Visible = False
                '    chkManualCheckRequired.Enabled = False
                'Else
                If .Cells("Status").Value = "EX" Then
                    dgFormula.Enabled = False
                    btnSelect.Visible = False
                    btnSave.Enabled = False
                    chkManualCheckRequired.Enabled = False
                End If

            End With

        End If
        LoaddgvOffcID()
        'AddHandler cboShortName.SelectedIndexChanged, AddressOf cboShortName_SelectedIndexChanged
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim i As Integer
        Dim lstQuerries As New List(Of String)
        Dim intNewOfferId As Integer

        If dgFormula.RowCount = 0 Then
            Exit Sub
        End If

        If Not CheckInputValues() Then
            Exit Sub
        End If

        Select Case mstrStatus
            Case ""
                lstQuerries.Add("Insert into Data1A_ProductOffer (Region,OfferId,ShortName" _
                                & ",Object,ProductName,GetInvoice,Status" _
                                & ", ValidFrom, ValidTo,ChargedUpTo, OriRecID" _
                                & ",ManualCheckRequired, FstUser)" _
                                & " values ('" & pobjUser.Region & "',(Select isnull(Max(OfferId),0)+1 from Data1A_ProductOffer),'" _
                                & cboShortName.Text & "','" & cboObject.Text & "','" & cboProductName.Text _
                                & "','" & IIf(chkGetInvoice.Checked, True, False) _
                                & "','--','" & cboValidFrom.Text & "','" & cboValidTo.Text _
                                & "','" & CreateFromDate(CDate(cboValidFrom.Text).AddDays(-1)) _
                                & "',0,'" & chkManualCheckRequired.Checked & "','" & pobjUser.UserName & "')")
                pobjSql.UpdateListOfQuerries(lstQuerries, True)
                lstQuerries.Clear()
                mintRecId = pobjSql.LastInsertedId
                intNewOfferId = pobjSql.GetScalarAsString("Select OfferId from Data1A_ProductOffer where RecId=" _
                                                          & pobjSql.LastInsertedId)
                With dgFormula
                    For i = 0 To dgFormula.RowCount - 1
                        lstQuerries.Add("Insert into DATA1A_MISC (CAT,VAL,VAL1) values ('ProductOfferPrice','" _
                                        & intNewOfferId & "','" & .Rows(i).Cells("RecId").Value & "')")
                    Next
                End With
                lstQuerries.Add("update Data1A_ProductOffer set Status='OK' where RecId=" & mintRecId)

            Case "OK"

                lstQuerries.Add("Insert into Data1A_ProductOffer (Region,OfferId,ShortName" _
                                & ",Object,ProductName,GetInvoice, Status" _
                                & ", ValidFrom, ValidTo,ChargedUpTo" _
                                & ", OriRecID,ManualCheckRequired, FstUser)" _
                                & " values ('" & pobjUser.Region & "'," & txtOfferId.Text & ",'" & cboShortName.Text & "','" & cboObject.Text _
                                & "','" & cboProductName.Text _
                                & "','" & IIf(chkGetInvoice.Checked, True, False) _
                                & "','OK','" & cboValidFrom.Text & "','" & cboValidTo.Text _
                                & "','" & mstrChargedUpTo _
                                & "'," & mintRecId & ",'" & chkManualCheckRequired.Checked _
                                & "','" & pobjUser.UserName & "')")

                lstQuerries.Add("update Data1A_ProductOffer set Status='XX',LstUpdate=getdate(),lstUser='" _
                                & pobjUser.UserName & "' where RecId=" & mintRecId)

                'Case "--", "RJ"
                '    lstQuerries.Add("update Data1A_ProductOffer set Status='--',ShortName='" & cboShortName.Text _
                '                    & "',Object='" & cboObject.Text _
                '                    & "',ValidFrom='" & cboValidFrom.Text & "',ValidTo='" & cboValidTo.Text _
                '                    & "',ManualCheckRequired='" & chkManualCheckRequired.Checked _
                '                    & "',LstUser='" & pobjUser.UserName & "',LstUpdate=getdate() where Status in ('--','RJ')" _
                '                    & " and RecId=" & mintRecId)

                '    'xoa cac formula cu
                '    lstQuerries.Add("delete DATA1A_MISC where CAT='ProductOfferPrice' and VAL='" & txtOfferId.Text & "'")

                '    'them cac formula moi
                '    With dgFormula
                '        For i = 0 To dgFormula.RowCount - 1
                '            lstQuerries.Add("Insert into DATA1A_MISC (CAT,VAL,VAL1) values ('ProductOfferPrice','" _
                '                            & txtOfferId.Text & "','" & .Rows(i).Cells("RecId").Value & "')")
                '        Next
                '    End With

            Case Else

        End Select

        AddOfficToExcept()

        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        Else
            MsgBox("Unable to Add/Edit Offer")
        End If


    End Sub
    Private Function CheckInputValues() As Boolean

        If Not CheckFormatComboBox(cboValidFrom, , 1) Then
            Return False
        ElseIf Not CheckFormatComboBox(cboValidTo, , 1) Then
            Return False
        ElseIf cboProductName.Text = "" Then
            MsgBox("Invalid ProductName")
            Return False
        ElseIf cboShortName.Text = "" Then
            MsgBox("Invalid ShortName")
            Return False
        ElseIf cboObject.Text = "" Then
            MsgBox("Invalid Object")
            Return False
        ElseIf DateDiff(DateInterval.Day, CDate(cboValidFrom.Text), CDate(cboValidTo.Text)) <= 0 Then
            MsgBox("ValidFrom must before ValidTo")
            Return False
        ElseIf dgFormula.RowCount = 0 Then
            MsgBox("You must select ProductPrice")
            Return False
        ElseIf pobjSql.GetScalarAsDecimal("Select top 1 RecId from DATA1A_CustDetails" _
                            & " where Cat='SecoFOP' and Status='OK'" _
                            & " and FromDate<='" & CreateFromDate(cboValidFrom.Text) & "'") = 0 Then
            MsgBox("You must create SECO FOP first")
            Return False
        End If

        If mstrStatus = "OK" Then
            If IsProductPricesCalculated(cboValidFrom.Text, cboShortName.Text) Then
                MsgBox("Invalid ValidFrom. Product prices had been calculated!")
                Return False
            ElseIf IsProductPricesCalculated(cboValidTo.Text, cboShortName.Text) Then
                MsgBox("Invalid ValidTo. Product prices had been calculated!")
                Return False
            End If
        End If

        'With dgFormula
        '    For i = 0 To dgFormula.RowCount - 1
        '        Dim strDupCheck As String = "Select top 1 RecId from Data1a_ProductOffer where Status='--' and Object='" _
        '                                     & cboObject.Text & "' and ShortName='" & cboShortName.Text _
        '                                     & "' and RecId<>" & mintRecId _
        '                                     & " and ('" & cboValidFrom.Text & "' between ValidFrom and ValidTo" _
        '                                     & " or '" & cboValidTo.Text & "' between ValidFrom and ValidTo)"

        '        Dim intDupOfferId As Integer = pobjSql.GetScalarAsString(strDupCheck)
        '        If intDupOfferId > 0 Then
        '            MsgBox("Duplicate/Overlap with RecId " & intDupOfferId)
        '            Return False
        '        End If
        '    Next
        'End With
        Return True
    End Function
    Private Function IsProductPricesCalculated(dteCheckDate As Date, strShortname As String) As Boolean
        Return True
    End Function

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If cboProductName.Text = "" Then
            MsgBox("You must select ProductName first!")
        Else
            Dim frmSelect As New frmSelectProductPrice(cboProductName.Text)
            If frmSelect.ShowDialog = Windows.Forms.DialogResult.OK Then
                pobjSql.LoadDataGridView(dgFormula, "Select * from Data1a_ProductCosts where Recid in (" _
                                         & pstrSelectedIds & ") ")
            End If
        End If
    End Sub

    Private Sub cboObject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboObject.SelectedIndexChanged
        dgFormula.Rows.Clear()
    End Sub

    Private Sub cboShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShortName.SelectedIndexChanged
        LoaddgvOffcID()
    End Sub

    Sub LoaddgvOffcID()
        If dgvOffcID.Columns.Count > 0 Then
            dgvOffcID.Columns.Clear()
        End If
        pobjSql.LoadDataGridView(dgvOffcID, "select distinct d.ShortName, d.OffcId, e.OffcId as OffcId2 " &
                                            "from DATA1A_OIDs d left join ExceptForReportNonSECO e on d.ShortName = e.ShortName and d.OffcId = e.OffcID " &
                                            "where d.Status = 'OK' and d.ShortName = '" & cboShortName.SelectedValue.ToString() & "' and (left(d.OffcId,3) = 'SGN' or left(d.OffcId,3) = 'HAN') ")
        Dim dgcSelected As New DataGridViewCheckBoxColumn()
        dgcSelected.Name = "Selected"
        dgvOffcID.Columns.Insert(0, dgcSelected)
        dgvOffcID.Columns("OffcId2").Visible = False
        dgvOffcID.Columns("ShortName").Visible = False
        dgvOffcID.Columns("OffcId").Width = 120
        dgvOffcID.Columns("Selected").Width = 55
        dgvOffcID.Columns("OffcId").ReadOnly = True
    End Sub

    Sub AddOfficToExcept()
        Dim cmdSql As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
        Dim query As String = ""
        query = "delete ExceptForReportNonSECO where ShortName = '" & cboShortName.SelectedValue.ToString() & "'"
        cmdSql.CommandText = query
        cmdSql.ExecuteNonQuery()

        For i = 0 To dgvOffcID.Rows.Count - 1
            If dgvOffcID.Rows(i).Cells("Selected").Value = 0 Then
                query = "insert into ExceptForReportNonSECO(ShortName, OffcID, DateAccess) select '" & dgvOffcID.Rows(i).Cells("ShortName").Value & "', '" & dgvOffcID.Rows(i).Cells("OffcID").Value & "' ,getdate()"
                cmdSql.CommandText = query
                cmdSql.ExecuteNonQuery()
            End If
        Next

    End Sub

    Private Sub dgvOffcID_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvOffcID.ColumnAdded
        For i = 0 To dgvOffcID.Rows.Count - 1
            If dgvOffcID.Rows(i).Cells("OffcId2").Value.ToString() <> "" Or IsNothing(dgvOffcID.Rows(i).Cells("OffcId2").Value.ToString()) = 1 Then
                dgvOffcID.Rows(i).Cells("Selected").Value = 0
            Else dgvOffcID.Rows(i).Cells("Selected").Value = 1
            End If
        Next
    End Sub

    Private Sub frmProductOfferEdit_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        For i = 0 To dgvOffcID.Rows.Count - 1
            If dgvOffcID.Rows(i).Cells("OffcId2").Value.ToString() <> "" Then
                dgvOffcID.Rows(i).Cells("Selected").Value = 0
            Else dgvOffcID.Rows(i).Cells("Selected").Value = 1
            End If
        Next
    End Sub
End Class
