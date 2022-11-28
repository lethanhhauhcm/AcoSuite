Public Class clsFareLine
    Dim mstrText As String
    'Dim mstrDepDate As String
    'Dim mstrOrigin As String
    'Dim mstrDestination As String
    Dim mintSeq As Int16
    Dim mstrFb As String
    Dim mintOwAmt As Integer
    Dim mintRtAmt As Integer
    Dim mstrCls As String
    Dim mstrPenalty As String
    Dim mstrDatesDays As String
    Dim mstrAdvancePurchase As String
    Dim mstrMinStay As String
    Dim mstrMaxStay As String
    Dim mstrOwnerCar As String
    Dim mstrMR As String

    Public Function Parse(ByVal strFareLine As String, ByVal strFareSource As String _
                        , ByVal strOwnerCar As String) As Boolean
        Dim intPenaltyPos As Int16
        Dim intAdvancePurchasePos As Int16
        Dim intDaysPos As Int16
        Dim intMinStayPos As Int16
        Dim intMaxStayPos As Int16

        mstrText = strFareLine
        mintSeq = Mid(strFareLine, 1, 2)
        mstrFb = Mid(strFareLine, 4, 12).Trim
        If IsNumeric(Mid(strFareLine, 14, 9).Trim) Then
            mintOwAmt = Mid(strFareLine, 14, 9)
        End If
        If IsNumeric(Mid(strFareLine, 23, 9).Trim) Then
            mintRtAmt = Mid(strFareLine, 23, 9)
        End If
        If strFareSource = "NEG" AndAlso strOwnerCar = "" Then
            intPenaltyPos = 33
            intDaysPos = 37
            intAdvancePurchasePos = 50
            intMinStayPos = 53
            intMaxStayPos = 57
            mstrOwnerCar = Mid(strFareLine, 61, 2)
        Else
            mstrCls = Mid(strFareLine, 33, 1)
            intPenaltyPos = 35
            intDaysPos = 39
            intAdvancePurchasePos = 53
            intMinStayPos = 56
            intMaxStayPos = 60
        End If

        mstrPenalty = Mid(strFareLine, intPenaltyPos, 3).Trim
        mstrDatesDays = Mid(strFareLine, intDaysPos, 13).Trim
        mstrAdvancePurchase = Mid(strFareLine, intAdvancePurchasePos, 2).Trim
        mstrMinStay = Mid(strFareLine, intMinStayPos, 3).Trim
        mstrMaxStay = Mid(strFareLine, intMaxStayPos, 3).Trim
        mstrMR = Mid(strFareLine, 64, 1).Trim
        Return True
    End Function
    Public Property Text() As String
        Get
            Text = mstrText
        End Get
        Set(ByVal value As String)
            mstrText = value
        End Set
    End Property
    Public Property Fb() As String
        Get
            Fb = mstrFb
        End Get
        Set(ByVal value As String)
            mstrFb = value
        End Set
    End Property
    Public Property Cls() As String
        Get
            Cls = mstrCls
        End Get
        Set(ByVal value As String)
            mstrCls = value
        End Set
    End Property
    Public Property Penalty() As String
        Get
            Penalty = mstrPenalty
        End Get
        Set(ByVal value As String)
            mstrPenalty = value
        End Set
    End Property
    Public Property DatesDays() As String
        Get
            DatesDays = mstrDatesDays
        End Get
        Set(ByVal value As String)
            mstrDatesDays = value
        End Set
    End Property
    Public Property AdvancePurchase() As String
        Get
            AdvancePurchase = mstrAdvancePurchase
        End Get
        Set(ByVal value As String)
            mstrAdvancePurchase = value
        End Set
    End Property
    Public Property MinStay() As String
        Get
            MinStay = mstrMinStay
        End Get
        Set(ByVal value As String)
            mstrMinStay = value
        End Set
    End Property
    Public Property MaxStay() As String
        Get
            MaxStay = mstrMaxStay
        End Get
        Set(ByVal value As String)
            mstrMaxStay = value
        End Set
    End Property
    Public Property OwnerCar() As String
        Get
            OwnerCar = mstrOwnerCar
        End Get
        Set(ByVal value As String)
            mstrOwnerCar = value
        End Set
    End Property
    Public Property MR() As String
        Get
            MR = mstrMR
        End Get
        Set(ByVal value As String)
            mstrMR = value
        End Set
    End Property
    Public Property Seq() As Int16
        Get
            Seq = mintSeq
        End Get
        Set(ByVal value As Int16)
            mintSeq = value
        End Set
    End Property
End Class
