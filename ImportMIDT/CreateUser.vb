Imports System.Data.SqlClient
Imports SharedFunctions.MySharedFunctions
Public Class CreateUser
    Private cn As String = "Data Source=172.16.2.6;Initial Catalog=Mktg_MIDT;User ID=midtusers; password=sresutdim"
    Private con As SqlConnection

    Function BuildTable(ByVal cmd As String) As System.Data.DataTable
        Dim dtl As New System.Data.DataTable
        Dim adt As New SqlDataAdapter(cmd, con)
        adt.Fill(dtl)
        Return dtl
    End Function

    Private Sub BuildDgvView()
        Dim cmd As String
        cmd = "Select RecID,SICode,SIName,Admin from tblUser where Status<>'XX' and City='SGN'" & _
                " and SICode not in ('SSG','ADM','PBL')"
        bdsView.DataSource = BuildTable(cmd)
        dgvView.DataSource = bdsView
        dgvView.Columns("Admin").Visible = False
    End Sub

    Private Sub CreateUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection(cn)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        BuildDgvView()
    End Sub

    Private Sub TaoUser(SICode As String, SIName As String, PSW As String, FstUser As String, City As String)
        Dim cmd As New SqlCommand
        Dim strQuery As String
        strQuery = "Insert TblUser(SICode,SIName,PSW,FstUser,City) values (@SICode,@SIName,@PSW,@FstUser,@City)"
        cmd = New SqlCommand(strQuery)
        cmd.Connection = con
        cmd.Parameters.Add("@SICode", SqlDbType.VarChar).Value = SICode
        cmd.Parameters.Add("@SIName", SqlDbType.VarChar).Value = SIName
        cmd.Parameters.Add("@PSW", SqlDbType.NText).Value = PSW
        cmd.Parameters.Add("@FstUser", SqlDbType.VarChar).Value = FstUser
        cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = City
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub UpdateUser(PSW As String, LstUser As String, LstUpdate As Date, Admin As Integer, RecID As Integer)
        Dim cmd As New SqlCommand
        Dim strQuery As String
        strQuery = "Update TblUser set LstUser=@LstUser, LstUpdate=@LstUpdate, Admin=@Admin where RecID=@RecID"
        cmd = New SqlCommand(strQuery)
        cmd.Connection = con
        cmd.Parameters.Add("@Admin", SqlDbType.Int).Value = Admin
        cmd.Parameters.Add("@LstUser", SqlDbType.VarChar).Value = LstUser
        cmd.Parameters.Add("@LstUpdate", SqlDbType.SmallDateTime).Value = LstUpdate
        cmd.Parameters.Add("@RecID", SqlDbType.Int).Value = RecID
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        TaoUser(txtSI.Text, txtFullName.Text, HashToFixedLen(""), SignIn, "SGN")
        BuildDgvView()
    End Sub

    Private Sub btmResetPass_Click(sender As Object, e As EventArgs) Handles btnResetPass.Click
        Dim adm As Integer
        If chkAdmin.Checked = True Then
            adm = 1
        Else
            adm = 0
        End If
        UpdateUser(HashToFixedLen(""), "SYS", Date.Now, adm, dgvView.CurrentRow.Cells("RecID").Value)
        BuildDgvView()
    End Sub

    Private Sub bdsView_CurrentChanged(sender As Object, e As EventArgs) Handles bdsView.CurrentChanged
        If bdsView.Count > 0 Then
            Dim dtr As DataRowView = bdsView.Current
            txtFullName.Text = dtr("SIName")
            If dtr("Admin") = 0 Then
                chkAdmin.Checked = False
            Else
                chkAdmin.Checked = True
            End If
            txtSI.Text = dtr("SICode")
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim dtr As DataRowView = bdsView.Current
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = "Update TblUser set SICode='" & txtSI.Text & "', SIName='" & txtFullName.Text & "' where RecID=" & dtr("RecID")
        cmd.ExecuteNonQuery()
        BuildDgvView()
    End Sub

    Private Sub chkClickToAddNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkClickToAddNew.CheckedChanged
        If chkClickToAddNew.Checked = True Then
            txtFullName.Text = ""
            txtSI.Text = ""
            chkAdmin.Checked = False
            btnUpdate.Enabled = False
            btnResetPass.Enabled = False
            btnCreate.Enabled = True
        Else
            bdsView_CurrentChanged(sender, e)
            btnUpdate.Enabled = True
            btnResetPass.Enabled = True
            btnCreate.Enabled = False
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dtr As DataRowView = bdsView.Current
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = "Update TblUser set Status='XX' where recID =" & dtr("RecID")
        cmd.ExecuteNonQuery()
        BuildDgvView()
    End Sub

    Private Sub dgvView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellClick
        btnDelete.Enabled = True
    End Sub
End Class