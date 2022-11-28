Public Class frmFinalizeAllStats

    Private Sub frmFinalizeAllStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dteLastDate As Date = pobjSql.GetScalarAsString("Select top 1 Date1 from DATA1A_MiscWzDate" _
                                                            & " where Cat='FinalizeAllStats' order by Recid desc")
        Dim i As Integer

        For i = 1 To DateDiff(DateInterval.Day, dteLastDate, Now) - 1
            pobjSql.ExecuteNonQuerry("Insert into DATA1A_MiscWzDate (CAT,VAL,Date1) values ('FinalizeAllStats','--','" _
                                     & Format(DateAdd(DateInterval.Day, i, dteLastDate), "dd-MMM-yy") & "')")
        Next
        Search()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        pobjSql.ExecuteNonQuerry("Update DATA1A_MiscWzDate Set VAL='OK',LstUpdate=getdate(),LstUser='" _
                                 & pobjUser.UserName & "' where Recid=" & dgFinalizeAllStats.CurrentRow.Cells("RecId").Value)
        Search()
    End Sub
    Private Function Search() As Boolean
        pobjSql.LoadDataGridView(dgFinalizeAllStats, "Select RecId,Date1 as BkgDate,Val as Status,LstUpdate,LstUser" _
                                 & " from DATA1A_MiscWzDate where Cat='FinalizeAllStats' and Val='--' order by Recid ")
        Return True
    End Function
End Class