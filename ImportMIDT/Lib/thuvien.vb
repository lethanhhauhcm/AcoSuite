Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports ExcelDataReader


Public Class thuvien

#Region "[Khai bao bien]"

    Public Chuoi_CSDL As String = ""
    Private mKet_noi As SqlConnection

#End Region

#Region "[Ham va phuong thuc]"

    Public Sub New()
        Me.Chuoi_CSDL = "Data Source=172.16.2.6;Initial Catalog=Mktg_MIDT;UID=midtusers;Pwd=sresutdim;"   '"Data Source=sqlserver;Initial Catalog=SCM;UID=THC;Pwd=THC4321;"
        ' If (Chuoi_CSDL.IndexOf("@") >= 0) Then
        'Me.Connect()
        ' End If
    End Sub

    Private Sub Connect()
        Chuoi_CSDL = "Server=@Server; Database=@Database; uid=@uid; Password=@Password;"
        Dim strFile As String = System.Windows.Forms.Application.StartupPath + "\login.xml"
        If (System.IO.File.Exists(strFile)) Then
            Dim dsLogin As DataSet = New DataSet()
            dsLogin.ReadXml(strFile)
            Chuoi_CSDL = Chuoi_CSDL.Replace("@Server", dsLogin.Tables(0).Rows(0)("Server") + "")
            Chuoi_CSDL = Chuoi_CSDL.Replace("@Database", dsLogin.Tables(0).Rows(0)("Database") + "")
            Dim user As String = dsLogin.Tables(0).Rows(0)("uid") + ""
            Chuoi_CSDL = Chuoi_CSDL.Replace("@uid", user)
            Dim pass As String = New cpublic().f_GiaiMa(user, dsLogin.Tables(0).Rows(0)("Password") + "")
            Chuoi_CSDL = Chuoi_CSDL.Replace("@Password", pass)
        End If
    End Sub

    Public Function f_SelectDataTable(ByVal sp_name As String, ByVal parames As String(), ByVal values As Object()) As DataTable
        If (Me.mKet_noi Is Nothing) Then
            Me.mKet_noi = New SqlConnection()
            Me.mKet_noi.ConnectionString = Me.Chuoi_CSDL
        End If
        If (Me.mKet_noi.State <> ConnectionState.Open) Then
            Me.mKet_noi.Open()
        End If
        Dim dt As System.Data.DataTable = New System.Data.DataTable()
        Try
            Dim command As SqlCommand = New SqlCommand(sp_name, Me.mKet_noi)
            command.CommandTimeout = 999990000
            command.CommandType = CommandType.StoredProcedure
            If (parames IsNot Nothing) Then
                Dim len = parames.Length
                For i As Integer = 0 To len - 1
                    If (parames(i) + "" <> "") Then
                        command.Parameters.Add(New SqlParameter(parames(i), values(i)))
                    End If
                Next
            End If
            Dim dap As SqlDataAdapter = New SqlDataAdapter(command)
            dap.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Kết nối dữ liệu " + ex.ToString(), "Lưu ý")
            dt = Nothing
        Finally
            Me.mKet_noi.Close()
        End Try
        Return dt
    End Function

    Public Function f_SelectDataSet(ByVal sp_name As String, ByVal parames As String(), ByVal values As Object()) As DataSet
        If (Me.mKet_noi Is Nothing) Then
            Me.mKet_noi = New SqlConnection()
            Me.mKet_noi.ConnectionString = Me.Chuoi_CSDL
        End If
        If (Me.mKet_noi.State = ConnectionState.Open) Then
            Me.mKet_noi.Open()
        End If
        Dim ds As DataSet = New DataSet()
        Try
            Dim command As SqlCommand = New SqlCommand(sp_name, Me.mKet_noi)
            command.CommandType = CommandType.StoredProcedure
            command.CommandTimeout = 999990000
            If (parames IsNot Nothing) Then
                Dim len As Integer = parames.Length

                For i As Integer = 0 To len - 1
                    If (parames(i) <> "") Then
                        command.Parameters.Add(New SqlParameter(parames(i), values(i)))
                    End If
                Next

            End If
            Dim dap As SqlDataAdapter = New SqlDataAdapter(command)
            dap.SelectCommand = command
            dap.Fill(ds)
            dap.Dispose()

        Catch ex As Exception
            MessageBox.Show("Kết nối dữ liệu " + ex.ToString(), "Lưu ý")
            ds = Nothing
        Finally
            Me.mKet_noi.Close()
        End Try
        Return ds


    End Function

    Public Function f_Update(ByVal sp_name As String, ByVal parames As String(), ByVal values As Object()) As Integer
        Dim result As Integer = 0
        If (Me.mKet_noi Is Nothing) Then
            Me.mKet_noi = New SqlConnection()
            Me.mKet_noi.ConnectionString = Me.Chuoi_CSDL
        End If
        If (Me.mKet_noi.State <> ConnectionState.Open) Then
            Me.mKet_noi.Open()
        End If
        Dim command As SqlCommand = New SqlCommand(sp_name, Me.mKet_noi)
        command.CommandType = CommandType.StoredProcedure
        command.CommandTimeout = 999990000
        Dim MyTrans As SqlTransaction = Me.mKet_noi.BeginTransaction()
        command.Transaction = MyTrans
        Try
            If (parames IsNot Nothing) Then
                Dim len As Integer = parames.Length

                For i As Integer = 0 To len - 1
                    command.Parameters.Add(New SqlParameter(parames(i), values(i)))
                Next

            End If
            command.Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.Int, 0))
            command.Parameters("@RETURN_VALUE").Direction = ParameterDirection.ReturnValue
            Dim irt As Integer = command.ExecuteNonQuery()
            MyTrans.Commit()
            result = command.Parameters("@RETURN_VALUE").Value
        Catch ex As Exception
            Return -1
        Finally
            command.Dispose()
            MyTrans.Dispose()
            command.Dispose()
            Me.mKet_noi.Close()
        End Try
        Return result
    End Function

    Public Function f_UpdateAllTable(ByVal sp_name As String, ByVal ColumnName As String(), ByVal TableName As DataTable, ByVal flag As String) As Integer
        If (Me.mKet_noi Is Nothing) Then
            Me.mKet_noi = New SqlConnection()
            Me.mKet_noi.ConnectionString = Me.Chuoi_CSDL
        End If
        If (Me.mKet_noi.State <> ConnectionState.Open) Then
            Me.mKet_noi.Open()
        End If
        Dim command As SqlCommand = New SqlCommand(sp_name, Me.mKet_noi)
        command.CommandType = CommandType.StoredProcedure
        command.CommandTimeout = 999999990
        Dim MyTrans As SqlTransaction = Me.mKet_noi.BeginTransaction()
        command.Transaction = MyTrans
        Try
            If (ColumnName IsNot Nothing) Then
                If (TableName IsNot Nothing) Then
                    If (Not TableName.Columns.Contains("flag")) Then
                        Dim col As DataColumn = New DataColumn()
                        With col
                            .ColumnName = "flag"
                            .DataType = System.Type.GetType("System.String")
                            .DefaultValue = flag
                        End With
                        TableName.Columns.Add(col)
                    End If

                    Dim x As Integer = 0
                    For Each dr As DataRow In TableName.Rows
                        'dr = Me.f_FixData(dr)

                        Dim len As Integer = ColumnName.Length

                        For i As Integer = 0 To len - 1
                            Dim key As String = ColumnName(i) + ""

                            Dim int_temp As Integer
                            Dim value As String = ""
                            If (Integer.TryParse(dr(ColumnName(i).ToString().Remove(0, 1) & "") & "", int_temp)) Then
                                value = CInt(dr(ColumnName(i).ToString().Remove(0, 1) + "")) & ""
                            Else
                                value = dr(ColumnName(i).ToString().Remove(0, 1) + "") & ""
                            End If

                            command.Parameters.Add(New SqlParameter(ColumnName(i), value.Trim()))
                        Next
                        Dim irt = command.ExecuteNonQuery()
                        command.Parameters.Clear()
                    Next
                    MyTrans.Commit()


                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return -1
        Finally
            command.Dispose()
            MyTrans.Dispose()
            command.Dispose()
            Me.mKet_noi.Close()
        End Try

        Return 1
    End Function

    Public Function f_FilterData(ByVal tb As DataTable, ByVal Conditional As String) As DataTable
        Dim tb_result As DataTable
        tb.DefaultView.RowFilter = Conditional
        tb_result = tb.DefaultView.ToTable()
        Return tb_result
    End Function

    Private Function f_CheckCityFromExcel(ByRef pCityName As String, ByRef pTbCity As DataTable) As String
        Dim cityCode As String = ""
        Dim strCode As String = ""
        If (pTbCity Is Nothing) Then
            Return cityCode
        End If
        For Each dtr As DataRow In pTbCity.Rows
            cityCode = "UNK"
            If pCityName = dtr("City") Then
                strCode = IIf(IsDBNull(dtr("Code")) = True, "", dtr("Code"))
                If strCode <> "" Then
                    cityCode = dtr("Code")
                    Exit For
                End If
            End If
        Next
        Return cityCode
    End Function

    Private Function f_FixData(ByRef dr As DataRow) As DataRow

        Dim month_b As String = (dr("month_b") & "").ToString().Trim()
        Dim year_b As String = (dr("year_b") & "").ToString().Trim()
        Dim NetBkg As String = (dr("NetBkg") & "").ToString().Trim().Replace(",", "").Replace(".", "")
        Dim gds As String = dr("GDS") & ""
        Dim city As String = dr("City") & ""
        Dim crsCode As String = dr("CRSCode") & ""

        If gds = "Galileo International" Then   '3
            dr("GDS") = "1G"
        ElseIf gds = "Amadeus" Then
            dr("GDS") = "1A"
            city = Mid(crsCode, 1, 3)
        ElseIf gds = "Abacus" Then
            dr("GDS") = "1B"
        ElseIf gds = "Sabre" Then
            dr("GDS") = "1S"
        Else
            dr("GDS") = ""
        End If ' End check GDS
        If city <> "" Then
            If gds = "Amadeus" Then
                city = Mid(crsCode, 1, 3)
                dr("City") = city                               '6
            Else
                dr("City") = f_CheckCityFromExcel(city, BienPublic.tb)
            End If
        Else
            dr("City") = "UNK"
        End If
        dr("Class") = Mid(dr("Class"), 1, 1)                    '7
        dr("date_b") = Convert.ToDateTime("01/" & month_b & "/" & year_b).ToShortDateString           '15
        Return dr

    End Function

    Public Function f_ConvertExcelToTable(ByVal pFileName As String, ByVal pSQL As String) As Data.DataTable
        Dim tb As Data.DataTable = New Data.DataTable()
        Dim i As Integer = 0
        Dim Stream As FileStream
        Dim excelReader As IExcelDataReader
        Stream = File.Open(pFileName, FileMode.Open, FileAccess.Read)
        If Path.GetExtension(pFileName).ToLower() = ".xlsx" Then
            excelReader = ExcelReaderFactory.CreateOpenXmlReader(Stream)
        Else excelReader = ExcelReaderFactory.CreateBinaryReader(Stream)
        End If
        Dim Result As DataSet
        Result = excelReader.AsDataSet()
        If Result IsNot Nothing And Result.Tables.Count > 0 Then
            tb = Result.Tables(0)
            Do While tb.Rows(i)(2).ToString = ""
                tb.Rows.RemoveAt(i)
                i += 1
            Loop
        End If
        Stream.Close()
        Return tb
    End Function

    Public Function f_ConvertCSVToTable(ByVal pFileName As String, ByVal pSQL As String) As DataTable
        Dim tb As DataTable = Nothing
        Try
            Dim strConn As String = "provider=Microsoft.Jet.OLEDB.4.0; data source=" & pFileName & "; Extended Properties=""" & "text;HDR=Yes;FMT=Delimited" & """" & ";"
            'Dim SheetName As String = conn.GetSchema("Tables").Rows(0)("TABLE_NAME")
            'SheetName = Replace(Replace(SheetName, "#", "."), "'", "")
            ' pSQL = pSQL.Replace("#SheetName", SheetName)
            ' Dim adp As OleDbDataAdapter = New OleDbDataAdapter(pSQL, strConn)
            ' adp.Fill(tb)
        Catch ex As Exception
            Return Nothing
        End Try

        Return tb
    End Function


#End Region

End Class
