Imports System.Text.RegularExpressions
Public Class clsFqd
    Dim mstrText As String
    Dim mcolFareLines As New Collection
    Dim mstrDepDate As String
    Dim mstrOrigin As String
    Dim mstrDestination As String
    Dim mstrCur As String
    Dim mstrFareSource As String = "PUB"
    Dim mstrRequestedCar As String
    Public Function Parse(ByVal strFqd As String) As Boolean
        Dim arrLines() As String
        Dim arrSlashBreak() As String
        Dim arrSemiColonBreak() As String
        Dim i As Int16
        Dim intStartLine As Int16
        Dim rgHeader As New Regex("\d{2}(A-Z){3}\d{2}")
        Dim rgFareLine As New Regex("\d{2}\s")
        Dim strOwnerCar As String = ""
        Dim strFareType As String
        Dim strGI As String

        mstrText = strFqd
        arrLines = Split(mstrText, vbCrLf)
        arrSlashBreak = Split(arrLines(0), "/")
        Select Case arrSlashBreak(1).Length
            Case 9
                strOwnerCar = Mid(arrSlashBreak(0), 1, 2)
                mstrOrigin = Mid(arrSlashBreak(0), 4, 3)
                mstrDestination = Mid(arrSlashBreak(0), 7, 3)
            Case 6
                mstrOrigin = Mid(arrSlashBreak(0), 1, 3)
                mstrDestination = Mid(arrSlashBreak(0), 4, 3)
        End Select
        
        For i = 1 To arrSlashBreak.Length - 1
            If arrSlashBreak(i).StartsWith("R,U") Then
                mstrFareSource = "NEG"
            ElseIf arrSlashBreak(i).StartsWith("D") Then
                mstrDepDate = Mid(arrSlashBreak(i), 2)
            ElseIf arrSlashBreak(i).StartsWith("A") Then
                mstrRequestedCar = Mid(arrSlashBreak(i), 2)
            End If
        Next
        If arrLines.Length < 3 Then
            Return False
        End If
        For i = 1 To arrLines.Length - 1
            If arrLines(i).StartsWith("ROE") Then
                intStartLine = i + 1
                Exit For
            End If
        Next
        For i = intStartLine To arrLines.Length - 1
            If rgHeader.IsMatch(arrLines(i)) Then
                arrSlashBreak = Split(arrLines(i), "/")
                strOwnerCar = Mid(arrSlashBreak(1), 1, 2)
                arrSemiColonBreak = Split(arrSlashBreak(2), ";")
                strFareType = arrSemiColonBreak(0)
                strGI = arrSemiColonBreak(1)
            ElseIf rgFareLine.IsMatch(arrLines(i)) Then
                Dim objFareLine As New clsFareLine
                If objFareLine.Parse(arrLines(i), mstrFareSource, strOwnerCar) Then
                    mcolFareLines.Add(objFareLine)
                Else
                    MsgBox("Unable to parse fare line " & arrLines(i))
                    Return False
                End If
            End If
        Next

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
    Public Property FareSource() As String
        Get
            FareSource = mstrFareSource
        End Get
        Set(ByVal value As String)
            mstrFareSource = value
        End Set
    End Property
    Public Property Origin() As String
        Get
            Origin = mstrOrigin
        End Get
        Set(ByVal value As String)
            mstrOrigin = value
        End Set
    End Property
    Public Property Destination() As String
        Get
            Destination = mstrDestination
        End Get
        Set(ByVal value As String)
            mstrDestination = value
        End Set
    End Property
    Public Property DepDate() As String
        Get
            DepDate = mstrDepDate
        End Get
        Set(ByVal value As String)
            mstrDepDate = value
        End Set
    End Property
    Public Property Fares() As Collection
        Get
            Fares = mcolFareLines
        End Get
        Set(ByVal value As Collection)
            mcolFareLines = value
        End Set
    End Property
End Class
