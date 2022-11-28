Public Class frmDeductBkgRuleEdit
    Private mblnNew As Boolean
    Public Sub New(blnNew As Boolean, Optional objRow As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If blnNew Then
            mblnNew = True

            dtpFromDate.MinDate = CDate(pobjSql.GetScalarAsString("select top 1 convert" _
                                    & "(varchar,bookdate,106) from AllStatsSI" _
                                    & " order by BookDate desc")).AddDays(1)
            dtpFromDate.Value = dtpFromDate.MinDate
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1)
            cboTimeFrame.SelectedIndex = 0  '^_^20221031 add by 7643
        Else
            lbkAdd.Visible = False
            lbkRemove.Visible = False
            dtpFromDate.Enabled = False
        End If
        If objRow IsNot Nothing Then
            If Not blnNew Then
                txtRecId.Text = objRow.Cells("RecId").Value
            End If
            txtPct.Text = objRow.Cells("Pct").Value
            dtpFromDate.Value = objRow.Cells("FromDate").Value
            dtpToDate.Value = objRow.Cells("ToDate").Value
            pobjSql.LoadDataGridView(dgrOffcSignIn, "Select OffcId,SignIn" _
                    & " from Data1a_DeductBkgRule_D where DeductionId=" _
                    & objRow.Cells("Recid").Value)

            '^_^20221031 add by 7643 -b-
            txtSegment.Text = objRow.Cells("Segment").Value
            cboTimeFrame.SelectedItem = objRow.Cells("TimeFrame").Value
            '^_^20221031 add by 7643 -e-
        End If

        '^_^20221031 add by 7643 -b-
        txtPct.Enabled = txtSegment.Text = "0"
        txtSegment.Enabled = txtPct.Text = "0"
        cboTimeFrame.Enabled = txtSegment.Enabled
        '^_^20221031 add by 7643 -e-
    End Sub

    Private Function CheckInputValues() As Boolean
        If Not CheckFormatTextBox(txtPct, 2,, 1) Then
            Return False
        End If
        If dgrOffcSignIn.RowCount = 0 Then
            Return False
        End If
        If dtpFromDate.Value.Date > dtpToDate.Value.Date Then
            MsgBox("Invalid FromDate/ToDate")
            Return False
        End If
        If mblnNew AndAlso dtpFromDate.Value.Date <= pobjSql.GetScalarAsString("select top 1 convert" _
                                    & "(varchar,bookdate,106) from AllStatsSI" _
                                    & " order by BookDate desc") Then
            MsgBox("FromDate must after last date of uploaded Allstats Data")
            Return False
        ElseIf Not mblnNew AndAlso dtpToDate.Value.Date < pobjSql.GetScalarAsString("select top 1 convert" _
                                    & "(varchar,bookdate,106) from AllStatsSI" _
                                    & " order by BookDate desc") Then
            MsgBox("ToDate must be on/after last date of uploaded Allstats Data")
            Return False
        End If

        For Each objRow As DataGridViewRow In dgrOffcSignIn.Rows
            Dim intOldRecord As Integer
            intOldRecord = pobjSql.GetScalarAsDecimal("Select TOP 1 r.Recid from Data1a_DeductBkgRule r" _
                                & " left join Data1a_DeductBkgRule_D d on r.RecId=d.DeductionId" _
                                & " where Status='OK'  and '" & dtpFromDate.Value _
                                & "' between FromDate and ToDate" _
                                & " And OffcId='" & objRow.Cells("OffcId").Value _
                                & "' and SignIn='" & objRow.Cells("SignIn").Value _
                                & "' and r.RecId<>" & txtRecId.Text)
            If intOldRecord > 0 Then
                MsgBox("Duplicate with DeductionId " & intOldRecord)
                Return False
            End If
        Next

        '^_^20221031 add by 7643 -b-
        If txtPct.Text <> "0" And txtSegment.Text <> "0" Then
            MsgBox("Pct and Segment only apply one!")
            Return False
        End If
        '^_^20221031 add by 7643 -e-

        Return True
    End Function
    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked

        With dgrOffcSignIn
            If Not CheckFormatTextBox(txtOffcId, 9,, 9) Then
                Exit Sub
            End If
            If Not CheckFormatTextBox(txtSignIn, 6,, 6) Then
                Exit Sub
            End If
            For Each objRow As DataGridViewRow In dgrOffcSignIn.Rows
                With objRow
                    If .Cells("Offcid").Value = txtOffcId.Text _
                        AndAlso .Cells("SignIn").Value = txtSignIn.Text Then
                        MsgBox("Duplicate values")
                        Exit Sub
                    End If
                End With
            Next
            If dgrOffcSignIn.ColumnCount = 0 Then
                dgrOffcSignIn.Columns.Add("OffcId", "OffcId")
                dgrOffcSignIn.Columns.Add("SignIn", "SignIn")
            End If
            dgrOffcSignIn.Rows.Add(txtOffcId.Text, txtSignIn.Text)

        End With
    End Sub

    Private Sub lbkRemove_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkRemove.LinkClicked
        dgrOffcSignIn.Rows.Remove(dgrOffcSignIn.CurrentRow)
    End Sub

    Private Sub lbkSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSave.LinkClicked
        Dim lstQuerries As New List(Of String)
        Dim intNewDeductId As Integer = 0
        If Not CheckInputValues() Then
            Exit Sub
        End If

        If Not mblnNew Then
            If pobjSql.ExecuteNonQuerry("Update Data1a_DeductBkgRule set LstUpdate=getdate()" _
                                     & ",ToDate='" & CreateToDate(dtpToDate.Value) _
                                     & "' where Recid=" & txtRecId.Text) Then
                Me.DialogResult = DialogResult.OK
            Else
                MsgBox("Unable to update")
            End If
        Else
            '^_^20221031 mark by 7643 -b-
            'lstQuerries.Add("insert into Data1a_DeductBkgRule (Region, FromDate, ToDate" _
            '                & ", Pct, Status, Fstuser) values ('" & pobjUser.Region _
            '                & "','" & CreateFromDate(dtpFromDate.Value) _
            '                & "','" & CreateToDate(dtpToDate.Value) _
            '                & "'," & txtPct.Text & ",'QQ','" & pobjUser.UserName & "')")
            '^_^20221031 mark by 7643 -e-
            '^_^20221031 modi by 7643 -b-
            lstQuerries.Add("insert into Data1a_DeductBkgRule (Region, FromDate, ToDate" _
                            & ", Pct, Status, Fstuser, Segment, TimeFrame) values ('" & pobjUser.Region _
                            & "','" & CreateFromDate(dtpFromDate.Value) _
                            & "','" & CreateToDate(dtpToDate.Value) _
                            & "'," & txtPct.Text & ",'QQ','" & pobjUser.UserName & "'," & txtSegment.Text & ",'" & cboTimeFrame.SelectedItem & "')")
            '^_^20221031 modi by 7643 -e-

            If Not pobjSql.UpdateListOfQuerries(lstQuerries, True) Then
                MsgBox("Unable to update")
                Exit Sub
            End If

            intNewDeductId = pobjSql.LastInsertedId
            lstQuerries.Clear()
            For Each objRow As DataGridViewRow In dgrOffcSignIn.Rows
                With objRow
                    lstQuerries.Add("insert into Data1a_DeductBkgRule_D (DeductionId, OffcId, SignIn)" _
                                    & " values (" & intNewDeductId & ",'" _
                                    & .Cells("Offcid").Value _
                                    & "','" & .Cells("SignIn").Value & "')")
                End With
            Next
            lstQuerries.Add("Update Data1a_DeductBkgRule set Status='OK' where Recid=" & intNewDeductId)
            If pobjSql.UpdateListOfQuerries(lstQuerries) Then
                Me.DialogResult = DialogResult.OK
            Else
                MsgBox("Unable to update")
            End If
        End If

    End Sub

    Private Sub txtPct_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPct.Validating
        IntegerValidating(sender, e)  '^_^20221031 add by 7643
    End Sub

    Private Sub txtSegment_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSegment.Validating
        IntegerValidating(sender, e)  '^_^20221031 add by 7643
    End Sub
End Class