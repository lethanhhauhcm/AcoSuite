Public Class IncentiveCalc
    Private Sub IncentiveCalc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        cmd.CommandText = "drop table ztmpIncentive"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "drop table ztmpIncentive1"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "drop table AGT_OID"
        cmd.ExecuteNonQuery()
        On Error GoTo 0
    End Sub
    Private Structure CSTM
        Public CommOffer As String
        Public VND As Decimal
    End Structure
    Private Sub IncentiveCalc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtFrm.Value = "01-Apr-13"
        Me.TxtThru.Value = "30-Jun-13"
    End Sub
    Private Function ValidInput() As Boolean
        If InStr("01JAN_01APR_01JUL_01OCT", Format(Me.txtFrm.Value.Date, "ddMMM").ToUpper) = 0 Then Return False
        If InStr("31MAR_30JUN_30SEP_31DEC", Format(Me.TxtThru.Value.Date, "ddMMM").ToUpper) = 0 Then Return False
        If DateDiff(DateInterval.Day, Me.txtFrm.Value, Me.TxtThru.Value) > 100 Then Return False
        Return True
    End Function
    Private Sub LblCalculate_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblCalculate.LinkClicked
        If Not ValidInput Then Exit Sub
        Dim strSQL As String, myCSTM As New CSTM, dTable As DataTable, DH As Date, DY As Date, SM_perf As Integer, Bkg_Q As Integer

        On Error Resume Next
        cmd.CommandText = "drop table ztmpMotNam; drop table ztmpIncentive;drop table ztmpBonThang; drop table AGT_OID"
        cmd.ExecuteNonQuery()
        On Error GoTo 0

        DH = DateAdd(DateInterval.Day, +1, Me.TxtThru.Value.Date)
        DY = DateAdd(DateInterval.Year, -1, DH)
        DH = DateAdd(DateInterval.Month, -6, DH)

        cmd.CommandText = "select * into agt_OID from midt_misc where cat='AGT_OID' and left(Val,3)='SGN'"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "select office, BookDate, sum(add1-can1) as Perf,0 as CustID, space(16) as ShortName into  ztmpIncentive from" & _
            " allstatssi where bookdate between '" & Format(DY, "dd-MMM-yy") & "' and '" & Format(Me.TxtThru.Value.Date, "dd-MMM-yy") & "'" & _
            " and left(office,3)='SGN' group by office, bookdate"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "insert into ztmpIncentive (Office, Bookdate, Perf, CustID, ShortName) select office, BookDate, sum(-1*can1) ,0 ,'' from" & _
            " HX where bookdate between '" & Format(DY, "dd-MMM-yy") & "' and '" & Format(Me.TxtThru.Value.Date, "dd-MMM-yy") & "'" & _
            " and left(office,3)='SGN' group by office, bookdate"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "select office, BookDate, sum(Perf) as Perf, CustID, ShortName into  ztmpMOtNam from" & _
            " ztmpIncentive  group by office, bookdate, custID, ShortName"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "update ztmpMotNam set custid=(select top 1 VAL1 from Agt_OID where val=ztmpMotNam.office)" & _
            " where office in (select val from agt_OID)"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "update ztmpMotNam set ShortName=(select top 1 ShortName from Agent where agent.recid=ztmpMotNam.CustID)" & _
            " where custID in (Select recid from agent where status<>'XX')"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "delete from ztmpMotNam where custid=0 "
        cmd.ExecuteNonQuery()

        cmd.CommandText = "select office, month(BookDate) as BookMOnth, sum(perf) as Perf into  ztmpBonThang from" & _
            " ztmpMotNam where bookdate between '" & Format(Me.txtFrm.Value.Date, "dd-MMM-yy") & "' and '" & Format(Me.TxtThru.Value.Date, "dd-MMM-yy") & "'" & _
            " group by office, month(BookDate)"
        cmd.ExecuteNonQuery()

        Me.GridIncentive.DataSource = GetDataTable("select CustID, ShortName, 0 as B1, 0 as B2, 0 as B3, 0.0 as M1, 0.0 as M2, 0.0 as M3," & _
            "0.0 as QR, 0.0 as HY, 0.0 as YR, 0.0 as TTL, space(128) as CSTM from ztmpMotNam where bookDate between '" & Format(Me.txtFrm.Value.Date, "dd-MMM-yy") & _
            "' and '" & Format(Me.TxtThru.Value.Date, "dd-MMM-yy") & "' group by CustID, shortname ")

        For i As Int16 = 0 To Me.GridIncentive.RowCount - 1

            dTable = GetDataTable("select * from GetPerformance('" & Me.GridIncentive.Item("ShortName", i).Value & "')")
            For j As Int16 = 0 To dTable.Rows.Count - 1
                myCSTM = DefineCSTM(Me.GridIncentive.Item("CustID", i).Value, dTable.Rows(0)("Perf"), "M")
                Me.GridIncentive.Item(j + 2, i).Value = dTable.Rows(j)("Perf")
                Me.GridIncentive.Item(j + 5, i).Value = dTable.Rows(j)("Perf") * myCSTM.VND
                If InStr(Me.GridIncentive.Item("CSTM", i).Value, myCSTM.CommOffer) = 0 Then Me.GridIncentive.Item("CSTM", i).Value = Me.GridIncentive.Item("CSTM", i).Value.ToString.Trim & "_" & myCSTM.CommOffer

            Next
            Bkg_Q = Me.GridIncentive.Item("b1", i).Value + Me.GridIncentive.Item("b2", i).Value + Me.GridIncentive.Item("B3", i).Value
            myCSTM = DefineCSTM(Me.GridIncentive.Item("CustID", i).Value, Bkg_Q, "Q")
            Me.GridIncentive.Item("QR", i).Value = myCSTM.VND
            Me.GridIncentive.Item("CSTM", i).Value = Me.GridIncentive.Item("CSTM", i).Value.ToString.Trim & "_" & myCSTM.CommOffer

            If isFstSixM(Me.GridIncentive.Item("CustID", i).Value, DH) Or isSndSixM(Me.GridIncentive.Item("CustID", i).Value, DY) Then
                cmd.CommandText = "Select sum(perf) from  ztmpMotNam where custid=" & Me.GridIncentive.Item("CustID", i).Value & _
                    " and BookDate between '" & Format(DH, "dd-MMM-yy") & "' and '" & Format(Me.TxtThru.Value.Date, "dd-MMM-yy") & "'"
                SM_perf = cmd.ExecuteScalar
                myCSTM = DefineCSTM(Me.GridIncentive.Item("CustID", i).Value, SM_perf, "H")
                Me.GridIncentive.Item("HY", i).Value = myCSTM.VND
                Me.GridIncentive.Item("CSTM", i).Value = Me.GridIncentive.Item("CSTM", i).Value.ToString.Trim & "_" & myCSTM.CommOffer
            End If
            If isSndSixM(Me.GridIncentive.Item("CustID", i).Value, DY) Then
                cmd.CommandText = "Select sum(perf) from  ztmpMotNam where custid=" & Me.GridIncentive.Item("CustID", i).Value
                SM_perf = cmd.ExecuteScalar
                myCSTM = DefineCSTM(Me.GridIncentive.Item("CustID", i).Value, SM_perf, "Y")
                Me.GridIncentive.Item("YR", i).Value = myCSTM.VND
                Me.GridIncentive.Item("CSTM", i).Value = Me.GridIncentive.Item("CSTM", i).Value.ToString.Trim & "_" & myCSTM.CommOffer
            End If
            Me.GridIncentive.Item("TTL", i).Value = Me.GridIncentive.Item("M1", i).Value + Me.GridIncentive.Item("M2", i).Value + Me.GridIncentive.Item("M3", i).Value + _
                Me.GridIncentive.Item("QR", i).Value + Me.GridIncentive.Item("HY", i).Value + Me.GridIncentive.Item("YR", i).Value
        Next
        Me.GridIncentive.Columns("CustID").Visible = False
        For i As Int16 = 2 To 9
            Me.GridIncentive.Columns(i).Width = 75
            Me.GridIncentive.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.GridIncentive.Columns(i).DefaultCellStyle.Format = "#,##0"
        Next
        On Error Resume Next
        cmd.CommandText = "drop table ztmpMotNam; drop table ztmpBonThang; drop table ztmpIncentive"
        cmd.ExecuteNonQuery()
        On Error GoTo 0
    End Sub
    Private Function isFstSixM(ByVal pCustId As Integer, ByVal pFrm As Date) As Boolean
        Dim KQ As Integer
        cmd.CommandText = "select top 1 recID from cstm1 where status='OK' and recID in (select CSTMID from cstmn where status='OK' and custid=" & pCustId & _
            ") and validfrom='" & Format(pFrm, "dd-MMM-yy") & "' and validthru>'" & Format(Me.TxtThru.Value.Date, "dd-MMM-yy") & "'"
        KQ = cmd.ExecuteScalar
        Return IIf(KQ > 0, True, False)
    End Function
    Private Function isSndSixM(ByVal pCustId As Integer, ByVal pFrm As Date) As Boolean
        Dim KQ As Integer
        cmd.CommandText = "select top 1 recID from cstm1 where status='OK' and recID in (select CSTMID from cstmn where status='OK' and custid=" & pCustId & _
            ") and validfrom='" & Format(pFrm, "dd-MMM-yy") & "' and validthru='" & Format(Me.TxtThru.Value.Date, "dd-MMM-yy") & "'"
        KQ = cmd.ExecuteScalar
        Return IIf(KQ > 0, True, False)
    End Function

    Private Function DefineCSTM(ByVal pCustID As Integer, ByVal pPerf As Integer, ByVal pType As String) As CSTM
        Dim KQ As New CSTM, strSQL As String, dTable As DataTable, DKValid As String = DefineDKValidity()
        KQ.CommOffer = ""
        KQ.VND = 0
        strSQL = "select RecID, commOffer, Target, VND from cstm1 where status='OK' and " & DKValid & _
            " and recID in (select CSTMID from cstmn where status='OK' and CustID=" & pCustID & ")" & _
            " and left(CommOffer,1)='" & pType & "' order by target desc"
        dTable = GetDataTable(strSQL)
        For i As Int16 = 0 To dTable.Rows.Count - 1
            If pPerf >= dTable.Rows(i)("target") Then
                KQ.CommOffer = dTable.Rows(i)("CommOffer")
                KQ.VND = dTable.Rows(i)("VND")
                Return KQ
            End If
        Next
        Return KQ
    End Function
    Private Function DefineDKValidity() As String
        Return " validfrom <='" & Me.TxtThru.Value.Date & "' and validThru >='" & Me.TxtThru.Value.Date & "'"
    End Function
End Class