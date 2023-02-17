Public Class AllstatUpload
    Dim cmd As SqlClient.SqlCommand = pobjSql.Connection.CreateCommand
    Dim cmd_Web As SqlClient.SqlCommand = Conn_Web.CreateCommand
    Private Sub PrepareData(ByVal pDKDate As String)
        Dim tblUserMap As DataTable, RecNO As Integer
        'Dim strExcludeLcc As String = " and AL not in (select Val from Mktg_MIDT.dbo.DATA1A_MISC where Cat='NoIncentiveCar')"

        tblUserMap = GetDataTable("select UserID, Office, SiCode from UserMapping where status='OK'", Conn_Web)
        On Error Resume Next
        cmd.CommandText = "delete from User_OID_SI; drop table tmpAllstat_HX; drop table tmpPoint"
        cmd.ExecuteNonQuery()
        On Error GoTo 0
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@UserID", SqlDbType.Int)
        cmd.Parameters.Add("@Office", SqlDbType.VarChar)
        cmd.Parameters.Add("@Sicode", SqlDbType.VarChar)
        For i As Int32 = 0 To tblUserMap.Rows.Count - 1
            cmd.CommandText = "insert User_OID_SI (UserID, Office, Sicode) values (@UserID, @Office, @Sicode)"
            cmd.Parameters("@UserID").Value = tblUserMap.Rows(i)("UserID")
            cmd.Parameters("@Office").Value = tblUserMap.Rows(i)("Office")
            cmd.Parameters("@Sicode").Value = tblUserMap.Rows(i)("SICode")
            cmd.ExecuteNonQuery()
        Next
        tblUserMap.Dispose()
        cmd_Web.CommandText = "select top 1 RecID from point_D where Cat in ('Allstat','StarBonus','DOBBonus','Promo') and " & pDKDate
        RecNO = cmd.ExecuteScalar
        If RecNO > 0 Then
            RecNO = MsgBox("Data Have Been Uploaded for Selected Dates. Wanna Quit?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, msgTitle)
            If RecNO = vbYes Then Exit Sub
        End If
        cmd_Web.CommandText = "delete from Point_D where Cat in ('Allstat','StarBonus','DOBBonus','Promo') and " & pDKDate
        cmd_Web.ExecuteNonQuery()
        cmd.CommandTimeout = 256

        cmd.CommandText = "select bookdate, sum(add1-can1) as point,office, left(sicode,6) as SICode into tmpAllstat_HX from allstatssi where " &
            pDKDate & " and NoIncentive='N'" _
            & " group by Bookdate, office, left(sicode,6) "
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Insert tmpAllstat_HX (bookdate, point, office, SICode) select bookdate, sum(can1*-1), office, SicodeSix" _
                            & " from Data1a_DeductBkgRuleResult where " &
                            pDKDate & " group by Bookdate, office, SicodeSix "
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Insert tmpAllstat_HX (bookdate, point, office, SICode) select bookdate, sum(can1*-1), office, left(sicode,6)" _
            & " from HX where " &
            pDKDate & " and Incentified='True' " & " group by Bookdate, office, left(sicode,6) "
        cmd.ExecuteNonQuery()

        'Xu ly manual bkg deduction o day
        '

        'Lay Net Bkg cuoi cung
        cmd.CommandText = "select bookdate, sum(point) as point, office, SICode into tmpPoint from tmpAllstat_HX " & _
            " group by Bookdate, office, sicode"
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub cmdManualUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdManualUpload.Click
        Dim tblPoint As DataTable
        Dim frm As String, tto As String, strDKDate As String
        frm = CreateFromDate(dgrBookDate.CurrentRow.Cells("BkgDate").Value)
        tto = CreateToDate(dgrBookDate.CurrentRow.Cells("BkgDate").Value)
        strDKDate = "(bookdate between '" & frm & "' and '" & tto & "')"

        PrepareData(strDKDate)
        tblPoint = GetDataTable("select Bookdate, point, UserID from tmpPoint p inner join User_OID_SI u on p.office=u.office and p.sicode=u.sicode", pobjSql.Connection)
        cmd_Web.Parameters.Clear()
        cmd_Web.Parameters.Add("@BookDate", SqlDbType.DateTime)
        cmd_Web.Parameters.Add("@UserID", SqlDbType.Int)
        cmd_Web.Parameters.Add("@Point", SqlDbType.Int)
        cmd_Web.Parameters.Add("@fstUser", SqlDbType.VarChar)
        cmd_Web.Parameters.Add("@ExpDate", SqlDbType.Date)  '^_^20221129 add by 7643
        For i As Int32 = 0 To tblPoint.Rows.Count - 1
            'cmd_Web.CommandText = "insert Point_D (BookDate, userID, Point, fstUser) values (@BookDate, @UserID, @Point, @fstUser)"  '^_^20221129 mark by 7643
            cmd_Web.CommandText = "insert Point_D (BookDate, userID, Point, fstUser,ExpDate) values (@BookDate, @UserID, @Point, @fstUser,@ExpDate)"  '^_^20221129 modi by 7643
            cmd_Web.Parameters("@BookDate").Value = tblPoint.Rows(i)("Bookdate")
            cmd_Web.Parameters("@UserID").Value = tblPoint.Rows(i)("UserID")
            cmd_Web.Parameters("@Point").Value = tblPoint.Rows(i)("Point")
            cmd_Web.Parameters("@fstUser").Value = pobjUser.UserName
            cmd_Web.Parameters("@ExpDate").Value = IIf(cmd_Web.Parameters("@Point").Value > 0, DateAdd("yyyy", 2, cmd_Web.Parameters("@BookDate").Value), DBNull.Value)  '^_^20221129 add by 7643 

            cmd_Web.ExecuteNonQuery()
        Next
        tblPoint.Dispose()

        AddStarBonus(strDKDate)
        AddPromo(frm, tto)

        LoadMissingDates()
        'AddBDayBonus(Me.TxtFrm.Value, Me.TxtTTo.Value, 1)
    End Sub
    Private Sub AddPromo(ByVal pFrm As Date, ByVal pTo As Date)
        Exit Sub
        Dim DKBookDate As String, HeSo As Decimal
        Dim tblPromo As DataTable

        tblPromo = GetDataTable("select RecID from Promo where status='OK' and (('" & Format(pFrm, "dd-MMM-yy") & _
            "' between frm and thru) or ('" & Format(pTo, "dd-MMM-yy") & "' between frm and thru))", pobjSql.Connection)

        If tblPromo.Rows.Count = 0 Then Exit Sub
        Dim DkPromoID As String
        DkPromoID = " and PromoID=" & tblPromo.Rows(0)("RecID") & ")"
        Dim strDK As String = ""

        If tblPromo.Rows(0)("ALL_AL") = 0 Then strDK = strDK & " and AL in (select val from promo_d where cat='AL' " & DkPromoID
        If tblPromo.Rows(0)("ALL_Member") = 0 Then strDK = strDK & " and UserID in (select val from promo_d cat='MEMBER' " & DkPromoID
        HeSo = tblPromo.Rows(0)("HeSo")

        Dim d As Date
        d = pFrm

        Do While Not d > pTo
            If Not d < tblPromo.Rows(0)("Frm") And Not d > tblPromo.Rows(0)("Thru") Then
                DKBookDate = "and BookDate='" & Format(d, "dd-MMM-yy") & "'" & strDK
                '^_^20221129 mark by 7643 -b-
                'cmd_Web.CommandText = "Insert Point_D (BookDate, userID, Cat, Point, FstUser, RMK) select BookDate, UserID, 'Promo'," &
                '    "sum(Point)*" & HeSo & ", fstUser,'" & tblPromo.Rows(0)("Campaign") & "'  from Point_D" &
                '    " where point >0 and " & DKBookDate & " group by UserID, BookDate, FstUser"
                '^_^20221129 mark by 7643 -e-
                '^_^20221129 modi by 7643 -b-
                cmd_Web.CommandText = "Insert Point_D (BookDate, userID, Cat, Point, FstUser, RMK,ExpDate) select BookDate, UserID, 'Promo'," &
                    "sum(Point)*" & HeSo & ", fstUser,'" & tblPromo.Rows(0)("Campaign") & "'," &
                    "case when sum(Point)*" & HeSo & ">0 then dateadd(yy,2,BookDate) else null end ExpDate  from Point_D" &
                    " where point >0 And " & DKBookDate & " group by UserID, BookDate, FstUser"
                '^_^20221129 modi by 7643 -e-
                cmd_Web.ExecuteNonQuery()
            End If
            d = DateAdd(DateInterval.Day, 1, d)
        Loop
    End Sub
    Private Sub AddBDayBonus(ByVal pFrm As Date, ByVal pTo As Date, ByVal pHeSo As Int16)
        Dim tblBDay As DataTable, tmpDate As Date, strSQL As String
        tmpDate = pFrm
        cmd_Web.Parameters.Clear()
        cmd_Web.Parameters.Add("@UserID", SqlDbType.Int)
        cmd_Web.Parameters.Add("@HeSo", SqlDbType.Int)
        cmd_Web.Parameters.Add("@BookDate", SqlDbType.DateTime)
        cmd_Web.Parameters.Add("@HeSo2", SqlDbType.Int) '^_^20221129 add by 7643
        Do While Not tmpDate > pTo
            strSQL = String.Format("select RecID as UserID from tblUser where status='OK' and month(Birthday)={0} and day(birthday)={1}", _
                tmpDate.Month, tmpDate.Day)
            tblBDay = GetDataTable(strSQL, Conn_Web)
            For i As Int16 = 0 To tblBDay.Rows.Count - 1
                cmd_Web.Parameters("@UserID").Value = tblBDay.Rows(i)("UserID")
                cmd_Web.Parameters("@HeSo").Value = pHeSo
                cmd_Web.Parameters("@BookDate").Value = tmpDate
                '^_^20221129 mark by 7643 -b-
                'cmd_Web.CommandText = "Insert Point_D (BookDate, userID, Cat, Point) select BookDate, UserID, 'BDayBonus', Point*@HeSo " &
                '    " from Point_D where UserID=@UserID and BookDate=@BookDate"
                '^_^20221129 mark by 7643 -e-
                '^_^20221129 modi by 7643 -b-
                cmd_Web.Parameters("@HeSo2").Value = cmd_Web.Parameters("@HeSo").Value
                cmd_Web.CommandText = "Insert Point_D (BookDate, userID, Cat, Point,ExpDate) select BookDate, UserID, 'BDayBonus', Point*@HeSo," &
                    "case when Point*@HeSo2>0 then dateadd(yy,2,BookDate) else null end ExpDate " &
                    " from Point_D where UserID=@UserID And BookDate=@BookDate"
                '^_^20221129 modi by 7643 -e-
                cmd_Web.ExecuteNonQuery()
            Next
            tmpDate = DateAdd(DateInterval.Day, 1, tmpDate)
        Loop
    End Sub

    Private Sub AddStarBonus(ByVal pDKDate As String)
        Dim tblSao As DataTable
        tblSao = GetDataTable("select RecID as UserID, CurrentStar from tblUser where status='OK' and CurrentStar>0", Conn_Web)
        cmd_Web.Parameters.Clear()
        cmd_Web.Parameters.Add("@UserID", SqlDbType.Int)
        cmd_Web.Parameters.Add("@HeSo", SqlDbType.Int)
        cmd_Web.Parameters.Add("@HeSo2", SqlDbType.Int)  '^_^20221129 add by 7643
        For i As Int16 = 0 To tblSao.Rows.Count - 1
            cmd_Web.Parameters("@UserID").Value = tblSao.Rows(i)("UserID")
            cmd_Web.Parameters("@HeSo").Value = tblSao.Rows(i)("CurrentStar")
            '^_^20221129 mark by 7643 -b-
            'cmd_Web.CommandText = "Insert Point_D (BookDate, userID, Cat, Point, FstUser) select BookDate, UserID, 'StarBonus', sum(Point)*@HeSo, fstUser from Point_D" &
            '    " where UserID=@UserID and point >0 and " & pDKDate & " group by UserID,BookDate, FstUser"
            '^_^20221129 mark by 7643 -e-
            '^_^20221129 modi by 7643 -b-
            cmd_Web.Parameters("@HeSo2").Value = cmd_Web.Parameters("@HeSo").Value
            cmd_Web.CommandText = "Insert Point_D (BookDate, userID, Cat, Point, FstUser,ExpDate) select BookDate, UserID, 'StarBonus', sum(Point)*@HeSo, fstUser," &
                "case when sum(Point)*@HeSo2>0 then dateadd(yy,2,BookDate) else null end ExpDate from Point_D" &
                " where UserID=@UserID And point >0 And " & pDKDate & " group by UserID,BookDate, FstUser"
            '^_^20221129 modi by 7643 -e-
            cmd_Web.ExecuteNonQuery()
        Next
        tblSao.Dispose()
    End Sub

    Private Sub AllstatUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = pubVarBackColor
        LoadMissingDates()
    End Sub

    Private Function LoadMissingDates()
        pobjSql.LoadDataGridView(dgrBookDate, "select distinct convert(varchar,bookdate,106) as BkgDate, BookDate " _
                                 & " from amadeusvn.dbo.AllStatsSI" _
                                & " where bookdate>='01 Dec 17'" _
                                & " and datediff(d,bookdate,getdate())<460" _
                                & " and bookdate not in (select distinct bookdate from amadeusvn.dbo.point_d" _
                                & " where Cat='AllStat') order by BookDate")
        dgrBookDate.Columns("Bookdate").Visible = False
        Return True
    End Function
End Class