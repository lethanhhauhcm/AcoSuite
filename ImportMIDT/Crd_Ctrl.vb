'^_^20221109 add by 7643
Public Class Crd_Ctrl
    Public Shared Function CheckOverDue(ByVal pCustID As Integer, ByVal pConn As SqlClient.SqlConnection) As String
        Dim cmd As SqlClient.SqlCommand = pConn.CreateCommand
        Dim vConNo As Decimal = 0, NewOverDue As Int16, CurrOverDue As Int16
        Dim KyBCID As Integer, BLCMonitor As String
        If KyBCID = 0 Then Return ""
        Return IIf(vConNo > 0, "Err. OverDue Amount " & vConNo.ToString, "")
    End Function

    Public Shared Function GetCutOverDate(ByVal pDelay As String, ByVal pConn As SqlClient.SqlConnection) As Date
        Dim KQ As String
        Dim cmd As SqlClient.SqlCommand = pConn.CreateCommand
        cmd.CommandText = String.Format("select VAL1 from DATA1A_MISC where cat='CUTOVER' and VAL='{0}' ", pDelay)
        KQ = cmd.ExecuteScalar
        Return CDate(KQ)
    End Function
End Class
