Public Class frmIncentiveFOP
    Private Sub lbkClear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkClear.LinkClicked
        Clear()
    End Sub

    Private Sub lbkSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSearch.LinkClicked
        Search()
    End Sub
    Private Function Search() As Boolean
        Dim strFromDate As String = CreateFromDate(dtpValidity.Value)
        Dim strQuerry As String = "Select c.RecId,c.ShortName,c.VAL as FOP,c.Status" _
            & ",convert(varchar,c.FromDate,106) as FromDate" _
            & " from DATA1A_CustDetails c" _
            & " left join Data1a_Contact b on c.ShortName=b.CustShortName" _
            & " where c.Cat='IncentiveFOP' And c.Status='OK'"
        AddEqualConditionCombo(strQuerry, cboRegion, "c.Region")
        AddEqualConditionCombo(strQuerry, cboFOP, "c.VAL")
        AddEqualConditionCombo(strQuerry, cboShortName, "c.ShortName")

        If cboPIC.Text <> "" Then
            strQuerry = strQuerry & " and c.ShortName in (Select ShortName from data1a_Customers" _
                        & " where Status<>'XX' and PIC='" & cboPIC.Text & "')"
        End If
        Select Case cboDateType.Text
            Case "FromDate"
                strQuerry = strQuerry & " and c.RecId>=(select top 1 c2.RecId" _
                    & " from DATA1A_CustDetails c2 where c2.status='ok'" _
                    & " and c2.shortname=c.shortname and c2.FromDate <='" & strFromDate _
                    & "' order by c2.recid desc) "

            Case "OnDate"
                strQuerry = strQuerry & " and c.RecId=(select top 1 c2.RecId" _
                    & " from DATA1A_CustDetails c2 where c2.status='ok'" _
                    & " and c2.shortname=c.shortname and c2.FromDate <='" & strFromDate _
                    & "' order by c2.recid desc) "

            Case "ToDate"
                strQuerry = strQuerry & " and c.RecId<=(select top 1 c2.RecId" _
                    & " from DATA1A_CustDetails c2 where c2.status='ok'" _
                    & " and c2.shortname=c.shortname and c2.FromDate <='" & strFromDate _
                    & "' order by c2.recid desc) "
        End Select

        strQuerry = strQuerry & " order by c.ShortName"
        pobjSql.LoadDataGridView(dgCustomers, strQuerry)
        Return True
    End Function
    Private Function Clear() As Boolean

        cboRegion.SelectedIndex = cboRegion.FindStringExact(pobjUser.Region)
        cboPIC.SelectedIndex = cboPIC.FindStringExact(pobjUser.UserName)
        cboShortName.Text = ""
        cboDateType.Text = ""
        cboFOP.SelectedIndex = -1
        cboShortName.SelectedIndex = -1

        Return True
    End Function

    Private Sub frmSecoFOP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pobjSql.LoadCombo(cboPIC, "Select UserName AS value from [DATA1A_User] where Status<>'XX'" _
                          & " order by UserName")
        pobjSql.LoadCombo(cboShortName, "Select distinct ShortName AS value from [DATA1A_CustDetails]" _
                        & " where Status<>'XX' and Cat='SecoFOP' order by ShortName")
        pobjSql.LoadCombo(cboNewShortName, "Select ShortName AS value from [DATA1A_Customers]" _
                        & " where Status<>'XX' and PIC='" & pobjUser.UserName & "' order by ShortName")
        cboNewFOP.SelectedIndex = 0
        dtpNewFromDate.Value = DateSerial(Now.Year, Now.Month, 1)
        Clear()
        Search()
    End Sub

    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        Dim intOldRecId As Integer
        Dim strFromDate As String = CreateFromDate(dtpNewFromDate.Value)
        If dtpNewFromDate.Value.Day <> 1 Then
            MsgBox("FromDate must be first day of month")
            Exit Sub
        End If
        intOldRecId = pobjSql.GetScalarAsDecimal("Select top 1 RecId from  [DATA1A_CustDetails]" _
                        & " where Status<>'XX' and Cat='SecoFOP'" _
                        & " and ShortName='" & cboNewShortName.Text _
                        & "' and FromDate>='" & strFromDate _
                        & "' order by RecId")
        If intOldRecId > 0 Then
            MsgBox("Overlapped Validity with RecId " & intOldRecId)
            Exit Sub
        End If
        If pobjSql.ExecuteNonQuerry("insert DATA1A_CustDetails (Cat, Region, ShortName, VAL" _
                & ", Status, FromDate, FstUser) values ('SecoFOP','" & pobjUser.Region _
                & "','" & cboNewShortName.Text & "','" & cboNewFOP.Text _
                & "','OK','" & strFromDate & "','" & pobjUser.UserName & "')") Then
            Search()
        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        With dgCustomers.CurrentRow

            If pobjSql.DeleteGridViewRow(dgCustomers, "Update [DATA1A_CustDetails] " _
                    & " set Status='XX', LstUpdate=getdate(),LstUser='" _
                    & pobjUser.UserName & "' where RecId=" & .Cells("RecId").Value) Then
                Search()
            Else
                MsgBox("Unable to delete FOP")
            End If
        End With
    End Sub
End Class