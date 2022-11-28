Public Class frmGetRewardsUser

    Private mobjUser As DataGridViewRow
    Private mstrShortName As String

    Private Sub frmGetRewardsUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Search()
    End Sub

    Public Sub New(strCustShortName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mstrShortName = strCustShortName
    End Sub
    Public Function Search() As Boolean
        Dim strQuerry As String = "Select u.*, sicode,office from amadeusvn.dbo.[tblUser] u " _
                                  & " left join amadeusvn.dbo.[UserMapping] m on u.Recid=m.UserId" _
                                  & " where u.status='OK' and m.status='OK' " _
                                  & " and office in (select OffcId from [DATA1A_OIDs] where status='OK' AND GDS='1A' and ShortName='" & mstrShortName & "')" _
                                  & " and SiName not in (select FullNameGB from [DATA1A_Contacts] where status='OK' and CustShortName='" & mstrShortName & "')"
        pobjSql.LoadDataGridView(DataGridView1, strQuerry)
        Return True
    End Function

    Public Property User As DataGridViewRow
        Get
            Return mobjUser
        End Get
        Set(value As DataGridViewRow)
            mobjUser = value
        End Set
    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        mobjUser = DataGridView1.CurrentRow
        DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class