Module CommonVariable
    Public SignIn As String
    Public Permission As String
    Public Dept As String
    Public Ext As String
    Public pstrCity As String
    Public pobjUser As New clsUser
    Public pobjSql As New clsTvcs
    Public pobjSql1A As New clsTvcs

    Public dAdapter As New SqlClient.SqlDataAdapter
    Public dSet As New Data.DataSet
    Public dSet1 As New Data.DataSet
    Public cmd As New SqlClient.SqlCommand
    Public dReader As SqlClient.SqlDataReader
    Public pubVarSerieName As String
    Public pubVarStrDK As String
    Public SICode As String, MyRole As String
    Public pstrDefaultPassword As String = "Amadeus1"
    Public Conn_Web As New SqlClient.SqlConnection
    'Public Const CnStr_HAN As String = "server=117.6.133.24;uid=sa;pwd=2357642sc;database=RAS2k7"
    Public Const CnStr_TVW As String = "server=118.69.81.103;uid=user_amadeusvn;pwd=VietHealthy@170172#;database=Amadeusvn"
    'Public Const CnStr_AOP As String = "server=42.117.5.70;uid=user_RAS;pwd=VietHealthy@170172#;database=AOP"
    'Public pobjUser As New objStaff
    Public Const msgTitle As String = "Amadeus Vietnam :: Reward"
    Public pubVarBackColor As Color
End Module
