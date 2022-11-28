Module MdlScalar
    Public Function ScalarToInt(ByVal pTbl As String, ByVal pField As String, ByVal pDK_Order As String, ByVal pConn As SqlClient.SqlConnection) As Integer
        Dim KQ As Integer
        Dim Cmd As SqlClient.SqlCommand = pConn.CreateCommand
        Cmd.CommandText = "SELECT " & pField & " from " & pTbl & " where " & Finetune_pDK(pDK_Order)
        KQ = Cmd.ExecuteScalar
        Return KQ
    End Function
    Public Function ScalarToDec(ByVal pTbl As String, ByVal pField As String, ByVal pDK_Order As String, ByVal pConn As SqlClient.SqlConnection) As Decimal
        Dim KQ As Decimal
        Dim Cmd As SqlClient.SqlCommand = pConn.CreateCommand
        Cmd.CommandText = "SELECT " & pField & " from " & pTbl & " where " & Finetune_pDK(pDK_Order)
        KQ = Cmd.ExecuteScalar
        Return KQ
    End Function

    Public Function ScalarToString(ByVal pTbl As String, ByVal pField As String, ByVal pDK_Order As String, ByVal pConn As SqlClient.SqlConnection) As String
        Dim KQ As String
        Dim Cmd As SqlClient.SqlCommand = pConn.CreateCommand
        Cmd.CommandText = "SELECT " & pField & " from " & pTbl & " where " & Finetune_pDK(pDK_Order)
        KQ = Cmd.ExecuteScalar
        Return KQ
    End Function

    Public Function ScalarToDate(ByVal pTbl As String, ByVal pField As String, ByVal pDK_Order As String, ByVal pConn As SqlClient.SqlConnection) As Date
        Dim KQ As Date
        Dim Cmd As SqlClient.SqlCommand = pConn.CreateCommand
        Cmd.CommandText = "SELECT " & pField & " from " & pTbl & " where " & Finetune_pDK(pDK_Order)
        KQ = Cmd.ExecuteScalar
        Return KQ
    End Function
    Public Function ChangeStatus_ByID(ByVal pTable As String, ByVal pStatus As String, ByVal PID As Integer, Optional ByVal pALStatus As String = "") As String
        Dim KQ As String
        KQ = "update " & pTable & " set LstUser='" & pobjUser.UserName & "', Lstupdate=getdate(), status='" & pStatus & "'"
        If pALStatus <> "" Then
            KQ = KQ & ", StatusAL='" & pALStatus & "'"
        End If
        KQ = KQ & " where recID = " & PID
        Return KQ
    End Function
    Public Function ChangeStatus_ByDK(ByVal pTable As String, ByVal pStatus As String, ByVal pDK As String, Optional ByVal pALStatus As String = "") As String
        Dim KQ As String
        KQ = "update " & pTable & " set LstUser='" & pobjUser.UserName & "', Lstupdate=getdate(), status='" & pStatus & "'"
        If pALStatus <> "" Then
            KQ = KQ & ", StatusAL='" & pALStatus & "'"
        End If
        KQ = KQ & " where " & Finetune_pDK(pDK)
        Return KQ
    End Function
    Private Function Finetune_pDK(ByVal pDK As String) As String
        If pDK.Trim.Substring(0, 5).ToUpper = "WHERE" Then
            Return pDK.Trim.Substring(5)
        End If
        Return pDK
    End Function
End Module
