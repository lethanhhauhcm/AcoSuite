Public Class frmUserRights
    Private mstrUserName As String

    Private Function Search() As Boolean
        Dim daConditions As SqlClient.SqlDataAdapter
        Dim dsConditions As New DataSet

        Dim strQuerryTrue As String = "select RecId,CAT,Object,SubObject,'Yes' as Selected from tblRight" _
                                    & " where status='ok' and   SIcode='" & mstrUserName & "'"
        Dim strQuerryFalse As String = "select 0,CAT,Object,SubObject,'No' as Selected from tblRight" _
                                    & " where status='ok' and   SIcode='template'" _
                                    & " and Cat+SubObject not in (select Cat+SubObject as Selected from tblRight" _
                                    & " where status='ok' and   SIcode='" & mstrUserName & "')"

        If cboCatergory.Text <> "" Then
            strQuerryTrue = strQuerryTrue & " and Cat='" & cboCatergory.Text & "'"
            strQuerryFalse = strQuerryFalse & " and Cat='" & cboCatergory.Text & "'"
        End If
        Dim strQuerry As String = strQuerryTrue & " union " & strQuerryFalse & " order by Cat,Subobject"

        daConditions = New SqlClient.SqlDataAdapter(strQuerry, pobjSql.ConnectionString)
        daConditions.Fill(dsConditions, "tblRight")
        DataGridView1.DataSource = dsConditions.Tables("tblRight")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        DataGridView1.Refresh()
        dsConditions.Dispose()
        daConditions.Dispose()
        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSwitch_Click(sender As Object, e As EventArgs) Handles btnSwitchValue.Click
        Dim strQuerry As String
        With DataGridView1.CurrentRow
            If .Cells("RecId").Value = 0 Then
                strQuerry = "Insert into tblRight(SIcode, CAT, Object, SubObject, Status, Fstuser) values ('" _
                            & mstrUserName & "','" & .Cells("CAT").Value & "','" & .Cells("Object").Value _
                            & "','" & .Cells("SubObject").Value & "','OK','" & pobjUser.UserName & "')"
            Else
                strQuerry = "Update tblRight set Status='XX',LstUpDate=Getdate(), Lstuser='" & pobjUser.UserName _
                    & "' where Recid=" & .Cells("RecId").Value
            End If
            If Not pobjSql.ExecuteNonQuerry(strQuerry) Then
                MsgBox("unable to update")
                Exit Sub
            End If
        End With
        Search()
    End Sub

    Public Sub New(strUserName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrUserName = strUserName
    End Sub

    Private Sub frmUserRights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pobjSql.LoadCombo(cboCatergory, "Select distinct Cat as Value from tblRight" _
                          & " where Status='OK' order by Cat")
        Search()

    End Sub

    Private Sub cboCatergory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCatergory.SelectedIndexChanged
        If cboCatergory.Items.Count > 0 Then
            Search()
        End If
    End Sub
End Class