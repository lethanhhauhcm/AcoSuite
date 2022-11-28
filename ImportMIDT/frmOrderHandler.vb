Imports Microsoft.Office.Interop
Public Class frmOrderHandler
    Dim cmd As SqlClient.SqlCommand = Conn_Web.CreateCommand
    Dim cmd_loc As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
    Private Sub OrderHandler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPendingOrder()
        Try
            cmd_loc.CommandText = "drop table AGT_OID"
            cmd_loc.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        cmd_loc.CommandText = "select * into agt_OID from midt_misc where cat='AGT_OID' "
        cmd_loc.ExecuteNonQuery()
    End Sub
    Private Sub LoadPendingOrder()
        Dim strSQL As String, Agt As String
        strSQL = "select UserID" _
            & ",CONVERT(VARCHAR,o.LstUpdate,6) as OrderDate" _
            & ", OrderID, GiftName, SL, PointRQ, TotalPoint, Note, SiName, Email, '' as Agent" &
            " from OrderDetail o " _
            & " inner join tblUser u on o.userid=u.recid and OrderID in " _
            & "(select RecID from amadeusvn.dbo.OrderGift where status='QQ')" &
            " and u.city='" & pobjUser.City & "' order by OrderId,GiftName"
        pobjSql1A.LoadDataGridView(GridRPT, strSQL)
        'Me.GridRPT.DataSource = GetDataTable(strSQL, Conn_Web)
        Me.GridRPT.Columns("UserId").Width = 50
        Me.GridRPT.Columns("OrderDate").Width = 80
        Me.GridRPT.Columns("GiftName").Width = 128
        Me.GridRPT.Columns("SL").Width = 32
        Me.GridRPT.Columns("PointRQ").Width = 64
        Me.GridRPT.Columns("TotalPoint").Width = 64
        Me.GridRPT.Columns("TotalPoint").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridRPT.Columns("TotalPoint").DefaultCellStyle.Format = "#,##0"
        Me.GridRPT.Columns("PointRQ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridRPT.Columns("PointRQ").DefaultCellStyle.Format = "#,##0"
        Me.LblAccept.Visible = False
        Me.LblReject.Visible = False
        For i As Int16 = 0 To Me.GridRPT.RowCount - 1
            Agt = pobjSql.GetScalarAsString("select shortname from DATA1A_OIDs where Status='OK' " _
                                            & " and OffcId=(select top 1 office from [User_OID_SI] where userid=" _
                                            & Me.GridRPT.Item("UserID", i).Value & ")")
            If String.IsNullOrEmpty(Agt) Then Agt = ""
            Me.GridRPT.Item("Agent", i).Value = Agt
        Next
    End Sub

    Private Sub LblReject_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblReject.LinkClicked
        If Me.TxtNote.Text = "" Then Exit Sub
        cmd.CommandText = ChangeStatus_ByID("OrderGift", "XX", Me.GridRPT.CurrentRow.Cells("OrderID").Value)
        cmd.ExecuteNonQuery()
        LoadPendingOrder()
    End Sub

    Private Sub LblAccept_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblAccept.LinkClicked
        Dim MyAns As Int16, vPath As String = Application.StartupPath
        Dim lstQuerries As New List(Of String)
        Dim strUpdateStatus As String

        strUpdateStatus = "Update amadeusvn.dbo.OrderGift set Status='OK' where Recid=" _
                            & Me.GridRPT.CurrentRow.Cells("OrderID").Value

        If Not pobjSql.ExecuteNonQuerry(strUpdateStatus) Then
            MsgBox("Unable to approve Gift Order")
            Exit Sub
        End If

        If pobjUser.City = "HAN" Then
            Dim i As Integer
            Dim strShortName = pobjSql.GetScalarAsString("SELECT Shortname from Data1a_OIDS where Status='OK' and OFFCID=" _
                                         & "(select top 1 Office FROM  amadeusvn.dbo.USERMAPPING M " _
                                        & " Where M.STATUS='OK' AND M.USERID=" & GridRPT.CurrentRow.Cells("UserId").Value & ")")
            Dim objExcel As New Excel.Application
            Dim objWbk As Excel.Workbook = objExcel.Workbooks.Open(My.Application.Info.DirectoryPath _
                                                                   & "\RewardsGiftApprovalForm.xltx")
            Dim objWsh As Excel.Worksheet = objWbk.ActiveSheet
            objExcel.Visible = True

            Dim decEarnedPoint As Decimal = pobjSql.GetScalarAsString("Select sum (Point) from  amadeusvn.dbo.Point_D" _
                                                        & " where Status='ok' and UserId=" & GridRPT.CurrentRow.Cells("UserId").Value)
            Dim decBurnedPoint As Decimal = pobjSql.GetScalarAsString("Select sum (TotalPoint) from  amadeusvn.dbo.OrderDetail" _
                                                        & " where UserId=" & GridRPT.CurrentRow.Cells("UserId").Value _
                                                        & " and OrderId in (Select RecId from amadeusvn.dbo.OrderGift" _
                                                        & " where Status='OK' and UserId=" & GridRPT.CurrentRow.Cells("UserId").Value & ")")
            Dim tblGift As System.Data.DataTable
            tblGift = pobjSql.GetDataTable("Select o.GiftName,'',o.SL,o.TotalPoint" _
                                           & ",CONVERT(VARCHAR,o.LstUpdate,6) as OrderDate,g.Price*o.SL as Total" _
                                            & " from amadeusvn.dbo.[OrderDetail] o" _
                                            & " left join amadeusvn.dbo.[GiftList] g" _
                                            & " on o.GiftId=g.RecId" _
                                            & " where o.OrderId=" & GridRPT.CurrentRow.Cells("OrderId").Value)

            With objWsh
                .Range("A12").Value = strShortName
                .Range("C12").Value = GridRPT.CurrentRow.Cells("SiName").Value
                .Range("E12").Value = GridRPT.CurrentRow.Cells("UserId").Value
                .Range("F12").Value = decEarnedPoint - decBurnedPoint

                For i = 0 To tblGift.Rows.Count - 1
                    .Range("A" & 16 + i).Value = i + 1
                    .Range("B" & 16 + i).Value = tblGift.Rows(i)("GiftName")
                    .Range("D" & 16 + i).Value = tblGift.Rows(i)("SL")
                    .Range("E" & 16 + i).Value = tblGift.Rows(i)("TotalPoint")
                    .Range("F" & 16 + i).Value = tblGift.Rows(i)("Total")
                    .Range("G" & 16 + i).Value = tblGift.Rows(i)("OrderDate")
                Next
                
            End With

            objExcel.Visible = True
        End If
        LoadPendingOrder()

        MyAns = MsgBox("Order Has Been Accepted. Email Has Been Sent to Member. Wanna Print this Order?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, msgTitle)
        If MyAns = vbNo Then Exit Sub
        InHoaDon(vPath, "OrderPrintOut.xlt", "V", "", Now.Date, Now.Date, Me.GridRPT.CurrentRow.Cells("OrderID").Value, "", "", "")
    End Sub

    Private Sub GridRPT_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridRPT.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        Me.LblReject.Visible = True
        Me.LblAccept.Visible = True
    End Sub
End Class