Public Class clsUser
    Dim mstrUserName As String
    Dim mstrRole As String
    Dim mstrFullName As String
    Dim mstrStatus As String
    Private mstrEmail As String
    Private mstrCity As String
    Private mstrRegion As String
    Private mstrPassword As String
    Private mtblRights As DataTable
    Private mintRemote As Integer
    Private mintStaffId As Integer
    Private _CurrObj As String, _URights As String, _CnStr As String  '^_^20221109 add by 7643

    Public Function HasRight(strObject As String, strCategory As String, strRight As String) As Boolean
        Dim strFilterExp As String = "Cat = '" & strCategory & "' and Object = '" & strObject _
                                     & "' and SubObject='" & strRight & "'"
        Dim arrResults As DataRow() = mtblRights.Select(strFilterExp, "SubObject", DataViewRowState.CurrentRows)

        If arrResults.Length = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Property UserName() As String
        Get
            UserName = mstrUserName
        End Get
        Set(ByVal value As String)
            mstrUserName = value
        End Set
    End Property
    Public Property Role() As String
        Get
            Role = mstrRole
        End Get
        Set(ByVal value As String)
            mstrRole = value
        End Set
    End Property
    Public Property FullName() As String
        Get
            FullName = mstrFullName
        End Get
        Set(ByVal value As String)
            mstrFullName = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Status = mstrStatus
        End Get
        Set(ByVal value As String)
            mstrStatus = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Email = mstrEmail
        End Get
        Set(ByVal value As String)
            mstrEmail = value
        End Set
    End Property
    Public Property Region() As String
        Get
            Region = mstrRegion
        End Get
        Set(ByVal value As String)
            mstrRegion = value
        End Set
    End Property
    Public Property City() As String
        Get
            City = mstrCity
        End Get
        Set(ByVal value As String)
            mstrCity = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Password = mstrPassword
        End Get
        Set(ByVal value As String)
            mstrPassword = value
        End Set
    End Property
    Public Property Rights As DataTable
        Get
            Return mtblRights

        End Get
        Set(value As DataTable)
            mtblRights = value
        End Set
    End Property
    Public Property Remote As Integer
        Get
            Return mintRemote
        End Get
        Set(value As Integer)
            mintRemote = value
        End Set
    End Property
    Public Property StaffId As Integer
        Get
            Return mintStaffId
        End Get
        Set(value As Integer)
            mintStaffId = value
        End Set
    End Property

    '^_^20221109 add by 7643 -b-
    Property CurrObj() As String
        Get
            Return _CurrObj
        End Get
        Set(ByVal sCurrObj As String)
            _CurrObj = sCurrObj
            _URights = ""
            Dim dTable As DataTable
            dTable = GetDataTable(String.Format("select SubObject from tblRight where status='OK' and " &
                " SICode='{0}' and upper(object)='{1}'", SICode, UCase(_CurrObj)))
            For i As Int16 = 0 To dTable.Rows.Count - 1
                _URights = _URights & "|" & dTable.Rows(i)("SubObject")
            Next
            If _URights.Length > 2 Then _URights = _URights.Substring(1)
        End Set
    End Property
    ReadOnly Property URights() As String
        Get
            Return _URights
        End Get
    End Property
    '^_^20221109 add by 7643 -e-
End Class
