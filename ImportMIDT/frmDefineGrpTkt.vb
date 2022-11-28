Public Class frmDefineGrpTkt
    Private mblnFirstLoadCompleted As Boolean
    Private Sub frmDefineGrpTkt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboStatus.SelectedIndex = 0
        Search()
        mblnFirstLoadCompleted = True
    End Sub

    Private Function Search() As Boolean
        Dim strQuerry As String = "Select * from DATA1A_GrpTktDefinition" _
                                & " Where RecId>0"

        AddEqualConditionCombo(strQuerry, cboStatus)
        pobjSql.LoadDataGridView(dgrGrpDefinition, strQuerry)

        Return True
    End Function
    Private Function CheckInputValues() As Boolean
        If Not CheckFormatTextBox(txtAL, 2,, 2) Then
            Return False
        End If
        If Not CheckFormatTextBox(txtRBD, 1,, 1) Then
            Return False
        End If
        Return True
    End Function
    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        Dim strQuerry As String = "Insert into DATA1A_GrpTktDefinition" _
            & " (AL, Rbd, Status, FstUser, AllSecRequired) " _
             & " values ('" & txtAL.Text & "','" & txtRBD.Text & "','OK','" _
             & pobjUser.UserName & "','" & chkAllSecRequired.Checked & "')"
        If pobjSql.ExecuteNonQuerry(strQuerry) Then
            Search()
        Else
            MsgBox("Unable to update")
        End If
    End Sub

    Private Sub lbkUpdate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkUpdate.LinkClicked
        Dim lstQuerries As New List(Of String)
        lstQuerries.Add("Insert into DATA1A_GrpTktDefinition" _
                & " (AL, Rbd, Status, FstUser, AllSecRequired)" _
                & " values ('" & txtAL.Text & "','" & txtRBD.Text & "','OK','" _
                & pobjUser.UserName & "','" & chkAllSecRequired.Checked & "')")
        lstQuerries.Add("update DATA1A_GrpTktDefinition set Status='XX', LstUpdate=getdate()" _
                        & ",lstUser='" & pobjUser.UserName & "' where RecId=" _
                        & dgrGrpDefinition.CurrentRow.Cells("RecId").Value)
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unable to update")
        End If
    End Sub

    Private Sub lbkDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkDelete.LinkClicked
        Dim lstQuerries As New List(Of String)
        If dgrGrpDefinition.CurrentRow.Cells("Status").Value = "XX" Then
            Exit Sub
        End If
        lstQuerries.Add("update DATA1A_GrpTktDefinition set Status='XX', LstUpdate=getdate()" _
                        & ",lstUser='" & pobjUser.UserName & "' where RecId=" _
                        & dgrGrpDefinition.CurrentRow.Cells("RecId").Value)
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        Else
            MsgBox("Unable to delete")
        End If
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            Search()
        End If
    End Sub

    Private Sub dgrGrpDefinition_SelectionChanged(sender As Object, e As EventArgs) Handles dgrGrpDefinition.SelectionChanged
        With dgrGrpDefinition
            If .CurrentRow Is Nothing Then
                Exit Sub
            End If
            txtAL.Text = .CurrentRow.Cells("AL").Value
            txtRBD.Text = .CurrentRow.Cells("RBD").Value
            chkAllSecRequired.Checked = .CurrentRow.Cells("AllSecRequired").Value
        End With
    End Sub

    Private Sub lbkApply_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkApply.LinkClicked
        Dim strQuerries As String
        Dim strCar3D As String
        Dim strFilterOffc As String = "(select offcid from DATA1A_OIDs o" _
                                    & " Left join DATA1A_Customers c on o.ShortName=c.ShortName and c.Status='ok'" _
                                    & " where o.Status='ok' and o.GDS='1A' and c.Region='South') OID"
        Dim strFilterEtk As String = "(select Tjqid,NbrOfSeg from TVCS.DBO.BSP_ETK" _
                                    & " where DOI between '01 Jan 18 00:00:00' and '21 May 18 23:59:00'"

        With dgrGrpDefinition.CurrentRow
            Dim frmSelectDateRange As New frmSelectDateRange()
            If Not frmSelectDateRange.ShowDialog = DialogResult.OK Then
                Exit Sub
            End If
            strCar3D = pobjSql.GetScalarAsString("Select DocCode from Airline where AlCode='" _
                                                 & .Cells("AL").Value & "'")
            strFilterEtk = "(select Tjqid,NbrOfSeg from TVCS.DBO.BSP_ETK" _
                             & " where DOI between '" & CreateFromDate(frmSelectDateRange.dtpFrom.Value) _
                            & "' and '" & CreateToDate(frmSelectDateRange.dtpTo.Value) _
                            & "') E"

            strQuerries = "update TVCS.DBO.BSP_TJQ set Grp='true' where recId in" _
                & "(Select RecId from TVCS.DBO.BSP_TJQ t" _
                & " left join " & strFilterEtk & "  on t.RecId=e.TjqId" _
                & " left join " & strFilterOffc & "  on t.offc=oid.OffcId" _
                & " where substring(tkno,1,3)='" _
                & strCar3D & "' and TransDate between '" & CreateFromDate(frmSelectDateRange.dtpFrom.Value) _
                & "' and '" & CreateToDate(frmSelectDateRange.dtpTo.Value) & "'"

            If .Cells("AllSecRequired").Value Then
                strQuerries = strQuerries & " and e.NbrOfSeg=(select count (*)" _
                & " from TVCS.DBO.BSP_SEG S WHERE S.TJQID=T.RecID And S.RBD='" _
                & .Cells("RBD").Value & "'))"
            Else
                strQuerries = strQuerries & " and 0<(select count (*)" _
                    & " from TVCS.DBO.BSP_SEG S WHERE S.TJQID=T.RecID And S.RBD='" _
                    & .Cells("RBD").Value & "'))"
            End If
        End With
        If pobjSql.ExecuteNonQuerry(strQuerries) Then
            MsgBox("Update is completed")
        Else
            MsgBox("Update is NOT completed")
        End If
    End Sub
End Class