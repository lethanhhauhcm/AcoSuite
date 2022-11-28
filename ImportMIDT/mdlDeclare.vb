Module mdlDeclare
    'Public conn As New SqlClient.SqlConnection
    'Public dAdapter As New SqlClient.SqlDataAdapter
    'Public dSet As New Data.DataSet
    'Public dSet1 As New Data.DataSet
    'Public cmd As New SqlClient.SqlCommand
    'Public dReader As SqlClient.SqlDataReader
    'Public pubVarSerieName As String
    'Public pubVarStrDK As String
    'Public SICode As String, MyRole As String
    Public Enum TimeFrame
        Month
        Quarter
        HalfYear
        Year
    End Enum
    Public Enum AcoRegion As Integer
        All = 0
        South = 1
        North = 2
    End Enum
    Public Enum Status As Integer
        QQ = 0
        OK = 1
        XX = 2
    End Enum
    Public Enum DataSource As Integer
        All = 0
        AllStat = 1
        HX = 2
    End Enum
    Public Enum CustomerType As Integer
        Customer = 1
        Contact = 2
    End Enum
    Public Enum EditMode As Integer
        NewRecord = 1
        EditRecord = 2
    End Enum
End Module
