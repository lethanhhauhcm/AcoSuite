Public Class frmProductEdit

    Private Sub frmProductEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub New(Optional dgrUser As DataGridViewRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If dgrUser Is Nothing Then
            txtProductName.ReadOnly = False
        Else
            txtRecId.Text = dgrUser.Cells("Recid").Value
            txtProductName.Text = dgrUser.Cells("ProductName").Value
            cboType.Text = dgrUser.Cells("ProductType").Value
            txtDescription.Text = dgrUser.Cells("Description").Value
            txtProductName.ReadOnly = True
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lstQuerries As New List(Of String)
        'Dim strPassword As String

        If Not CheckInputValue() Then
            Exit Sub
        End If

        lstQuerries.Add("Insert into DATA1A_Products (ProductName,ProductType,Description,Status,FstUser,LstUser) values ('" _
                        & txtProductName.Text & "','" & cboType.Text & "','" & txtDescription.Text _
                        & "','OK','" & pobjUser.UserName & "','" & pobjUser.UserName & "')")
        If txtRecId.Text <> "" Then
            lstQuerries.Add("update DATA1A_Products set Status='XX', LstUpdate=getdate(),LstUser='" & pobjUser.UserName _
                & "' where Recid=" & txtRecId.Text)
        End If
        If pobjSql.UpdateListOfQuerries(lstQuerries) Then
            Me.Dispose()
        Else
            MsgBox(pobjSql.UpdtErr)
        End If

    End Sub
    Private Function CheckInputValue() As Boolean

        If txtProductName.Text.Length < 3 Then
            MsgBox("Invalid ProductName")
            Return False
        End If

        If cboType.Text.Length < 3 Then
            MsgBox("Invalid ProductType")
            Return False
        End If

        If txtRecId.Text = "" AndAlso pobjSql.GetScalarAsString("Select top 1 RecId from DATA1A_Products where status<>'XX'" _
                                                                & " and ProductName='" & txtProductName.Text & "'") <> "" Then
            MsgBox("Duplicate ProductName")
            Return False
        End If

        If txtDescription.Text.Length < 8 Then
            MsgBox("Invalid Description")
            Return False
        End If
        Return True
    End Function

    
End Class