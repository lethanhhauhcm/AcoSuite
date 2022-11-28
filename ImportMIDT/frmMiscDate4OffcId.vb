Public Class frmMiscDate4OffcId
    Private mstrCat As String

    Private Sub frmMiscDate4OffcId_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Private Function Search() As Boolean
        Dim strQuerry As String
        strQuerry = "Select RecId,Val as OffcId,FromDate,Todate, FstUser,FstUpdate" _
            & ",LstUser,LstUpdate from MISC_WzDate" _
            & " where Status='OK' and Cat='" & mstrCat & "' and City ='" & pobjUser.City & "'" _
            & " order by Todate"  '^_^20220722 add by 7643
        pobjSql.LoadDataGridView(dgrOffcId, strQuerry)
        dgrOffcId.AutoResizeColumns()
        Return True
    End Function
    Private Function CheckInputValue(strFromDate As String, strToDate As String _
                                     , blnAdd As Boolean) As Boolean
        Dim intDupRecId As Integer
        'Dim strFromDate As String = CreateFromDate()
        If txtOffcId.TextLength <> 9 Then
            MsgBox("Invalid Offc Id")
            Return False
        End If

        intDupRecId = pobjSql.GetScalarAsDecimal("Selected RecId from MISC_WzDate " _
                                     & " where Status='OK' and Cat='" & mstrCat & "' and City ='" _
                                     & pobjUser.City & "' and Val='" & txtOffcId.Text _
                                     & "' and RecId<>0" _
                                     & " and ('" & strFromDate & "between FromDate and ToDate or '" _
                                     & strToDate & "' between FromDate and ToDate)")

        If intDupRecId > 0 Then
            MsgBox("Duplicate with RecId " & intDupRecId)
            Return False
        End If
        Dim intCalculatedRecord As Integer
        Select Case mstrCat
            Case "NoIncentiveOID"
                If blnAdd Then
                    intCalculatedRecord = pobjSql.GetScalarAsDecimal("Select top 1 RecId from AllStatsSI" _
                                            & " where BookDate between '" & strFromDate _
                                            & "' and '" & strToDate & "'")
                    If intCalculatedRecord > 0 Then
                        MsgBox("Unable to add. Bookings have been marked as eligible for incentive in selected period")
                        Return False
                    End If
                Else
                    intCalculatedRecord = pobjSql.GetScalarAsDecimal("Select top 1 RecId from AllStatsSI" _
                                        & " where BookDate > '" & strFromDate _
                                        & "' or BookDate>='" & strToDate & "'")
                    If intCalculatedRecord > 0 Then
                        MsgBox("Unable to Change Validity. Bookings have been marked as eligible for incentive in selected period")
                        Return False
                    End If
                End If
            Case "NoCost4OffcId"
        End Select

        Return True
    End Function
    Private Sub lbkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbkAdd.LinkClicked
        Dim strFromDate As String = CreateFromDate(dtpFromDate.Value)
        Dim strToDate As String = CreateToDate(dtpToDate.Value)
        Dim strQuerry As String

        If Not CheckInputValue(strFromDate, strToDate, True) Then
            Exit Sub
        End If

        strQuerry = " insert MISC_WzDate (Cat,Val,FromDate,ToDate,Status,City,FstUser) " _
            & " values ('" & mstrCat & "','" & txtOffcId.Text & "','" & strFromDate _
            & "','" & strToDate & "','OK','" & pobjUser.City & "','" & pobjUser.UserName & "')"

        If pobjSql.ExecuteNonQuerry(strQuerry) Then
            Search()
        End If
    End Sub


    Private Sub blkChangeDate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles blkChangeDate.LinkClicked
        Dim strFromDate As String = CreateFromDate(dtpFromDate.Value)
        Dim strToDate As String = CreateToDate(dtpToDate.Value)
        Dim strQuerry As String
        If Not CheckInputValue(strFromDate, strToDate, False) Then
            Exit Sub
        End If
        strQuerry = "update MISC_WzDate  set FromDate='" & strFromDate _
           & "',Todate='" & strToDate & "',LstUser='" & pobjUser.UserName _
           & "',LstUpdate=getdate() where Recid=" & dgrOffcId.CurrentRow.Cells("RecId").Value

        If pobjSql.ExecuteNonQuerry(strQuerry) Then
            Search()
        End If
    End Sub

    Public Sub New(strFormTitle As String, strCat As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrCat = strCat
        Me.Text = strFormTitle
    End Sub

    Private Sub dgrOffcId_SelectionChanged(sender As Object, e As EventArgs) Handles dgrOffcId.SelectionChanged
        txtOffcId.Text = dgrOffcId.CurrentRow.Cells("OffcId").Value  '^_^20220722 add by 7643
    End Sub
End Class