Public Class clsJgd1A
    Private mstrSign As String
    Private mstrOffcId As String
    Private mstrAttributeID As String
    Private mstrAttributeName As String
    Private mstrAttributeValue As String

    Public Function GetJgd(ByVal strAttributeId As String, strJgd As String) As Boolean
        
        If InStr(strJgd, "INVALID ATTRIBUTE IDENTIFIER") > 0 Then
            Return False
        End If
        If Parse(strJgd) Then
            mstrAttributeID = strAttributeId
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Parse(ByVal strJgd As String) As Boolean
        Dim arrLines() As String
        
        arrLines = Split(strJgd, vbCrLf)
        mstrSign = Mid(arrLines(4), 38, 6)
        mstrOffcId = Mid(arrLines(3), 38, 9)
        mstrAttributeName = Mid(arrLines(7), 9, 30)
        mstrAttributeValue = Trim(Mid(arrLines(7), 43))
        If mstrAttributeValue = "NONE" Then
            mstrAttributeValue = ""
        End If
        Parse = True
    End Function
    Public Property Sign() As String
        Get
            Sign = mstrSign
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property OffcId() As String
        Get
            OffcId = mstrOffcId
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property AttributeID() As String
        Get
            AttributeID = mstrAttributeID
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property AttributeName() As String
        Get
            AttributeName = mstrAttributeName
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property AttributeValue() As String
        Get
            AttributeValue = mstrAttributeValue
        End Get
        Set(ByVal value As String)

        End Set
    End Property
End Class
