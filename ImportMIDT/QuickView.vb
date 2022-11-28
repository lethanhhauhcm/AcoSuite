Public Class QuickView
    Private CityStatusOK As String = "Status='OK' and City='" & pobjUser.City & "'"
    Private CityStatusQQ As String = "Status='QQ' and City='" & pobjUser.City & "'"
    Private StatusOKCityALL As String = "Status='OK' and City in ('All','" & pobjUser.City & "')"
    Private strSQLUser As String = "Select u.RecID as MemberID, SIname, Mobile, Email, BirthDay, CurrentStar, office, SICode from tblUser u inner join UserMapping m on u.recid=m.userid where u."
    Private strSQL As String
    Private Sub QuickView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = pubVarBackColor
    End Sub
    Private Sub LblUserList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblUserList.LinkClicked
        Me.GridRPT.DataSource = GetDataTable(strSQLUser & CityStatusOK & " and m.status='OK' order by MemberID", Conn_Web)
        Dim tblOID As DataTable = GetDataTable("select UserID, count(userID) as SL from UserMapping where status='OK' group by Userid having count(UserID)>1", Conn_Web)
        For i As Int16 = 0 To tblOID.Rows.Count - 1
            For j As Int16 = 0 To GridRPT.RowCount - 1
                If Me.GridRPT.Item(0, j).Value = tblOID.Rows(i)("UserID") Then
                    Me.GridRPT.Rows(j).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        Next
    End Sub
    Private Sub LblThisMonthBD_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblThisMonthBD.LinkClicked
        Me.GridRPT.DataSource = GetDataTable(strSQLUser & CityStatusOK & " and month(Birthday)=month(getdate())", Conn_Web)
    End Sub
    Private Sub LblGiftList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblGiftList.LinkClicked
        Me.GridRPT.DataSource = GetDataTable("Select Ten, Mota, PointRQ, Stock, Price, RMK from GiftList where " & StatusOKCityALL, Conn_Web)
    End Sub
    Private Sub LblPendingUser_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPendingUser.LinkClicked
        Me.GridRPT.DataSource = GetDataTable(strSQLUser & CityStatusQQ, Conn_Web)
    End Sub
    Private Sub LblPointByMember_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPointByMember.LinkClicked
        Dim charUserID As String, IntUserID As Integer, StrSQL As String, PointBlc As Decimal
        charUserID = InputBox("Enter MemberID", msgTitle, "2")
        Try
            IntUserID = CInt(charUserID)
        Catch ex As Exception
            Exit Sub
        End Try
        StrSQL = "select FstUpdate as Ngay, 'Burn' as PointType, totalPoint as Point, Giftname as RMK from [amadeusvn].dbo.[OrderDetail]" &
                " where OrderID in (select RecID from [amadeusvn].dbo.[OrderGift] where status<>'XX' and UserID=" & IntUserID & ")"
        StrSQL = StrSQL & " Union ALL Select BookDate as Ngay, Cat as PointType, Point, RMK from Point_D where status='OK' and UserID=" & IntUserID
        Me.GridRPT.DataSource = GetDataTable(StrSQL, Conn_Web)
        For i As Int16 = 0 To Me.GridRPT.RowCount - 1
            If Me.GridRPT.Item("PointType", i).Value = "Burn" Then
                PointBlc = PointBlc - Me.GridRPT.Item("Point", i).Value
            Else
                PointBlc = PointBlc + Me.GridRPT.Item("Point", i).Value
            End If
        Next
        Me.Text = "Point Remains: " & PointBlc.ToString
    End Sub
    Private Sub LblPendingOrder_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPendingOrder.LinkClicked
        strSQL = "select OrderID, GiftName, SL, PointRQ, TotalPoint, Note," _
            & "(select top 1 Office from UserMapping u where u.UserID=userid) as OffcId" _
            & "  from OrderDetail " _
            & " where OrderID in (select RecID from OrderGift where status='QQ')"
        Me.GridRPT.DataSource = GetDataTable(strSQL, Conn_Web)
        Me.GridRPT.Columns("GiftName").Width = 128
        Me.GridRPT.Columns("SL").Width = 32
        Me.GridRPT.Columns("PointRQ").Width = 64
        Me.GridRPT.Columns("TotalPoint").Width = 64
        Me.GridRPT.Columns("TotalPoint").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridRPT.Columns("TotalPoint").DefaultCellStyle.Format = "#,##0"
        Me.GridRPT.Columns("PointRQ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridRPT.Columns("PointRQ").DefaultCellStyle.Format = "#,##0"
    End Sub
End Class