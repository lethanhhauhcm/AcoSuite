Public Class frmFareBatchEdit
    Public Sub New(Optional objRow As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If objRow Is Nothing Then
            txtRecId.Text = 0
            cboFareType.SelectedIndex = 0
        Else
            cboFareType.SelectedIndex = cboFareType.FindStringExact(objRow.Cells("FareType").Value)
            txtRecId.Text = objRow.Cells("RecId").Value
            txtBatchName.Text = objRow.Cells("BatchName").Value
            txtCar.Text = objRow.Cells("Car").Value
            dtpDepDate.Value = objRow.Cells("DepDate").Value
            txtOri.Text = objRow.Cells("Ori").Value
            txtDes.Text = objRow.Cells("Des").Value
            txtFareBasis.Text = objRow.Cells("FareBasis").Value
        End If
    End Sub

    Private Sub lbkCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkCancel.LinkClicked
        Me.Dispose()
    End Sub

    Private Sub lbkSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSave.LinkClicked
        Dim lstQuerries As New List(Of String)
        If Not CheckInputValue() Then
            Exit Sub
        End If
        lstQuerries.Add("insert into DATA1A_FareBatch (BatchName, Ori, Des, Car,DepDate" _
                        & ", FareBasis, FareType, Status, FstUser" _
                        & ") values ('" & txtBatchName.Text & "','" & txtOri.Text _
                        & "','" & txtDes.Text & "','" & txtCar.Text & "','" & dtpDepDate.Value _
                        & "','" & txtFareBasis.Text _
                        & "','" & cboFareType.Text & "','OK','" & pobjUser.UserName & "')")
        If txtRecId.Text > 0 Then
            lstQuerries.Add("Update DATA1A_FareBatch set Status='XX',LstUpdate=getdate" _
                            & ",LstUser='" & pobjUser.UserName & "' where RecId=" & txtRecId.Text)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        End If

    End Sub

    Private Function CheckInputValue() As Boolean
        txtCar.Text = txtCar.Text.Replace(" ", "")
        txtOri.Text = txtOri.Text.Replace(" ", "")
        txtDes.Text = txtDes.Text.Replace(" ", "")
        txtFareBasis.Text = txtFareBasis.Text.Replace(" ", "")
        Select Case txtCar.Text.Length
            Case 0, 2
            Case Else
                MsgBox("Invalid Carrier!")
                Return False
        End Select

        If dtpDepDate.Value.Date < Now.Date Then
            MsgBox("Invalid Departure Date")
            Return False
        End If

        If Not CheckFormatTextBox(txtOri, 16, , 3) _
            Or Not CheckFormatTextBox(txtDes, 16, , 3) _
            Or Not CheckFormatTextBox(txtFareBasis, 16, , 3) _
            Or Not CheckFormatComboBox(cboFareType, , 3, 3) Then
            Return False
        End If

        If pobjSql.GetScalarAsString("") <> "" Then
            Return False
        End If
        Return True
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class