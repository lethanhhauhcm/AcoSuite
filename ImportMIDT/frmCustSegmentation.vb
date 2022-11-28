Public Class frmCustSegmentation
    Private mblnFirstLoadCompleted As Boolean
    Private Sub frmCustSegmentation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strExistingCust = "(Select ShortName from Data1A_CustSegments where Status='OK'" _
                                & " and BookYear=" & Now.Year & ")"
        Dim strCreateRecords As String = " insert Data1A_CustSegments " _
            & "(BookYear,ShortName,Segment,FstUser)" _
            & " select " & Now.Year & ",ShortName,'',''" _
            & " from Data1a_Customers" _
            & " where Status='OK' and ShortName not in " & strExistingCust

        pobjSql.ExecuteNonQuerry(strCreateRecords)

        pobjSql.LoadCombo(cboPIC, "Select UserName as Value from [DATA1A_User] where Status='OK'" _
                          & " order by City desc,UserName")

        pobjSql.LoadCombo(cboCurrentCombineSegment, "Select Val2 as value from Data1a_Misc" _
                          & " where Cat='CustSegment' order by Val2")
        Clear()
        'Search()
        mblnFirstLoadCompleted = True
    End Sub

    Private Sub lbkClear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkClear.LinkClicked
        Clear()
    End Sub

    Private Sub lbkSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkSearch.LinkClicked
        Search()
    End Sub
    Private Function Clear() As Boolean
        txtBookYear.Text = Now.Year
        cboRegion.Text = pobjUser.Region
        cboPIC.Text = pobjUser.UserName
        cboRegion.SelectedIndex = 0
        cboKeySegment.SelectedIndex = -1
        cboSubSegment.SelectedIndex = -1
        cboCombineSegment.SelectedIndex = -1
        cboStatus.SelectedIndex = 0
        Return True
    End Function
    Private Function Search() As Boolean
        Dim strQuerry As String = "Select c.Region,c.PIC,s.*" _
            & " from Data1A_CustSegments s " _
            & " left join Data1A_Customers c on s.ShortName=c.ShortName and c.Status='OK'" _
            & " left join Data1A_Misc m on s.Segment=m.Val2 and m.Cat='CustSegment'" _
            & " where s.RecId>0"
        AddEqualConditionCombo(strQuerry, cboStatus, "s.Status")
        AddEqualConditionText(strQuerry, txtBookYear)
        AddEqualConditionCombo(strQuerry, cboRegion, "c.region")
        AddEqualConditionCombo(strQuerry, cboPIC, "c.Pic")
        AddLikeConditionText(strQuerry, txtShortName, "c.ShortName")
        AddEqualConditionCombo(strQuerry, cboKeySegment, "m.VAL")
        AddEqualConditionCombo(strQuerry, cboSubSegment, "m.VAL1")
        AddEqualConditionCombo(strQuerry, cboCombineSegment, "m.VAL2")
        strQuerry = strQuerry & " order by c.Region,s.ShortName"

        pobjSql.LoadDataGridView(dgCustomers, strQuerry)
        For Each objColumn As DataGridViewColumn In dgCustomers.Columns
            If objColumn.Name <> "MultiSelect" Then
                objColumn.ReadOnly = True
            Else
                objColumn.ReadOnly = False
            End If
        Next
        Return True
    End Function

    Private Sub cboCoreBusiness_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKeySegment.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            cboSubSegment.DataSource = Nothing
            pobjSql.LoadCombo(cboSubSegment, "Select distinct Val1 as value from Data1a_Misc where Cat='CustSegment'" _
                              & " and Val='" & cboKeySegment.Text & "'")
            cboSubSegment.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboValueChain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubSegment.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            cboCombineSegment.DataSource = Nothing
            pobjSql.LoadCombo(cboCombineSegment, "Select distinct Val2 as value from Data1a_Misc where Cat='CustSegment'" _
                              & " and Val='" & cboKeySegment.Text _
                              & "' and Val1='" & cboSubSegment.Text & "'")
            cboCombineSegment.SelectedIndex = -1
        End If
    End Sub



    Private Sub lbkUpdate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkUpdate.LinkClicked
        Dim lstQuerries As New List(Of String)
        With dgCustomers.CurrentRow
            lstQuerries.Add("Update Data1a_CustSegments set Status='XX',LstUpdate=Getdate()" _
                            & ",LstUser='" & pobjUser.UserName & "' where RecId=" _
                            & .Cells("RecId").Value)
            lstQuerries.Add("Insert Data1a_CustSegments (BookYear,ShortName,Segment,FstUser)" _
                            & " values (" & .Cells("BookYear").Value _
                            & ",'" & .Cells("ShortName").Value & "','" _
                            & cboCurrentCombineSegment.Text & "','" _
                            & pobjUser.UserName & "')")

            If pobjSql.UpdateListOfQuerries(lstQuerries) Then
                Search()
            End If
        End With
    End Sub

    Private Sub dgCustomers_SelectionChanged(sender As Object, e As EventArgs) Handles dgCustomers.SelectionChanged
        With dgCustomers.CurrentRow
            cboCurrentCombineSegment.Text = .Cells("Segment").Value
        End With
    End Sub

    Private Sub cboRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRegion.SelectedIndexChanged
        If mblnFirstLoadCompleted Then
            Dim strQuerry As String = "Select UserName as Value from [DATA1A_User] where Status='OK'"

            If cboRegion.Text = "South" Then
                strQuerry = strQuerry & " and City='SGN'"
            Else
                strQuerry = strQuerry & " and City='HAN'"
            End If

            strQuerry = strQuerry & " order by City desc,UserName"
            pobjSql.LoadCombo(cboPIC, strQuerry)

        End If
    End Sub

    Private Sub lbkMultiUpdate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkMultiUpdate.LinkClicked
        Dim lstQuerries As New List(Of String)
        For Each objRow As DataGridViewRow In dgCustomers.Rows
            If objRow.Cells("MultiSelect").Value Then
                With objRow
                    lstQuerries.Add("Update Data1a_CustSegments set Status='XX',LstUpdate=Getdate()" _
                                    & ",LstUser='" & pobjUser.UserName & "' where RecId=" _
                                    & .Cells("RecId").Value)
                    lstQuerries.Add("Insert Data1a_CustSegments (BookYear,ShortName,Segment,FstUser)" _
                                    & " values (" & .Cells("BookYear").Value _
                                    & ",'" & .Cells("ShortName").Value & "','" _
                                    & cboCurrentCombineSegment.Text & "','" _
                                    & pobjUser.UserName & "')")

                End With
            End If

        Next
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Search()
        End If
    End Sub
End Class