Public Class clsMiscField
    Private mstrFieldName As String
    Private mstrColumnName As String
    Private mstrPossibleValues As String    'Cac gia tri phan tach boi |
    Private mintMinLength As Integer
    Private mintMaxLength As Integer
    Private mblnNumeric As Boolean

    Public Property FieldName As String
        Get
            Return mstrFieldName
        End Get
        Set(value As String)
            mstrFieldName = value
        End Set
    End Property
    Public Property ColumnName As String
        Get
            Return mstrColumnName
        End Get
        Set(value As String)
            mstrColumnName = value
        End Set
    End Property
    Public Property PossibleValues As String
        Get
            Return mstrPossibleValues
        End Get
        Set(value As String)
            mstrPossibleValues = value
        End Set
    End Property
    Public Property MinLength As Integer
        Get
            Return mintMinLength
        End Get
        Set(value As Integer)
            mintMinLength = value
        End Set
    End Property
    Public Property MaxLength As Integer
        Get
            Return mintMaxLength
        End Get
        Set(value As Integer)
            mintMaxLength = value
        End Set
    End Property
    Public Property Numeric As Boolean
        Get
            Return mblnNumeric
        End Get
        Set(value As Boolean)
            mblnNumeric = value
        End Set
    End Property

    Public Sub New(strColumnName As String, strFieldName As String, Optional strPossibleValues As String = "" _
                , Optional intMinLength As Integer = 0, Optional intMaxLength As Integer = 0 _
                                                  , Optional blnNumeric As Boolean = False)
        mstrColumnName = strColumnName
        mstrFieldName = strFieldName
        mstrPossibleValues = strPossibleValues
        mintMaxLength = intMaxLength
        mintMinLength = intMinLength
        mblnNumeric = blnNumeric
    End Sub
End Class
