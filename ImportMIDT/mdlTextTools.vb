Imports System.Security.Cryptography
Imports System.Text
Module mdlTextTools
    Public pstrPrg As String
    Public pstrPrgShortName As String
    Public pstrGds As String
    Public pstrOffcId As String
    Public pstrLocation As String
    Public pcolCompanies As New Collection
    Public pcolShortNames As New Collection
    Public pstrCustShortName As String = ""
    Public pstrCmc As String = ""
    Public pstrProfileName1A As String = ""
    Public pdecROE As Decimal
    Public pintTvcsCusId As Integer
    Public pblnUnattended As Boolean
    Public pdecUsdRoeRas As Decimal

    Public pblnPtUsed As Boolean

    Public pobjSqlWeb As New clsTvcs
    Public pstrRlocList As String
    Public pstrConditionsList As String
    Public pstrFlow1S As String
    Public pstrFlow1A As String
    Public pstrDisplayedPNR As String
    Public pblnFirstLoad As Boolean
    Public pstrLogFiile As String
    Public pstrOffcIds As String
    Public pblnReplaceOffcId As Boolean
    Public pstrRasUserName As String
    Public pstrIncentiveFormulas As String
    Public pstrSelectedIds As String
    Public pblnRemoteAccess As Boolean

    Public Function ConvertMonth2Quarter(intmonth As Integer) As Integer
        Select Case intmonth
            Case Is <= 3
                Return 1
            Case Is <= 6
                Return 2
            Case Is <= 9
                Return 3
            Case Is <= 12
                Return 4
            Case Else
                Throw New System.Exception("Invalid month " & intmonth)
        End Select

    End Function
    Public Function IsEndOfPeriod(dteInput As Date, intTimeFrame As TimeFrame) As Boolean
        If dteInput.Month = dteInput.AddDays(1).Month Then
            Return False
        End If
        Select Case intTimeFrame
            Case TimeFrame.Month
                'bo qua
            Case TimeFrame.Quarter
                If dteInput.Month Mod 3 <> 0 Then
                    Return False
                End If
            Case TimeFrame.HalfYear
                If dteInput.Month Mod 6 <> 0 Then
                    Return False
                End If
            Case TimeFrame.Year
                If dteInput.Month <> 12 Then
                    Return False
                End If
        End Select
        Return True
    End Function
    Public Function ConvertTimeFrame2Int(strTimeFrame As String) As TimeFrame
        Select Case strTimeFrame
            Case "Month"
                Return TimeFrame.Month
            Case "Quarter"
                Return TimeFrame.Quarter
            Case "HalfYear"
                Return TimeFrame.HalfYear
            Case "Year"
                Return TimeFrame.Year
            Case Else
                Throw New System.Exception("Invalid input TimeFrame" & strTimeFrame)
        End Select
    End Function
    Public Function RemoveLastChr(ByVal strToBeCut As String, Optional ByVal BytNbrOfChar As Byte = 1) As String
        If Len(strToBeCut) = 0 Then
            RemoveLastChr = ""
            Exit Function
        End If
        RemoveLastChr = Left(strToBeCut, Len(strToBeCut) - BytNbrOfChar)
    End Function
    Public Function RemoveCrLf(ByVal strText As String) As String
        If Len(strText) = 0 Then
            RemoveCrLf = ""
            Exit Function
        End If

        Do While InStr(strText, vbCrLf & vbCrLf) > 0
            strText = Replace(strText, vbCrLf & vbCrLf, vbCrLf)
        Loop
        RemoveCrLf = strText
    End Function

    Public Function ConvertSqlBln(ByVal mblnValue As Boolean) As Integer
        If mblnValue Then
            ConvertSqlBln = 1
        Else : ConvertSqlBln = 0
        End If
    End Function
    Public Function Remove2Spaces(ByVal strInput As String) As String
        ' bo khoang trong chuoi nhung van giu 1 ky tu trang giua cac phan
        While InStr(1, strInput, "  ") > 0
            strInput = Replace(strInput, "  ", " ")
        End While
        Remove2Spaces = strInput
    End Function

    Public Function CountSlash(ByVal strText) As Byte
        Dim arrBreakBySlash() As String
        If InStr(strText, "/") = 0 Then
            Return 0
        End If

        arrBreakBySlash = Split(strText, "/")
        Return UBound(arrBreakBySlash)
    End Function
    Public Function GetFbAdl(ByVal mstrFb) As String
        'Purpose: Find corresponding fare basis for adult
        'Input: Fare basis from FQQ or TST
        'Output: Fare basis for Adult

        Dim bytSlash As Byte

        bytSlash = InStr(mstrFb, "/")
        Select Case bytSlash
            Case 0
                If Len(mstrFb) > 4 Then
                    Select Case Right(mstrFb, 4)
                        Case "IN90", "CH25", "CH33"
                            GetFbAdl = Left(mstrFb, Len(mstrFb) - 4)
                            Exit Function

                    End Select
                    Select Case Right(mstrFb, 2)
                        Case "IN", "CH"
                            GetFbAdl = Left(mstrFb, Len(mstrFb) - 2)
                            Exit Function
                    End Select
                    GetFbAdl = mstrFb
                ElseIf Len(mstrFb) > 2 Then
                    Select Case Right(mstrFb, 2)
                        Case "IN", "CH"
                            GetFbAdl = Left(mstrFb, Len(mstrFb) - 2)
                            Exit Function
                    End Select
                    GetFbAdl = mstrFb
                Else
                    GetFbAdl = mstrFb
                End If
            Case Else
                GetFbAdl = Left(mstrFb, bytSlash - 1)
        End Select
    End Function
    Public Function IsInList(ByVal mstrValue As String, ByVal mstrList As String) As Boolean
        'Purpose: Check if a value is in the list
        'Input: Value and list of values seperated by comma
        'Output: Y/N
        Dim arrValues() As String
        Dim i As Integer

        arrValues = Split(mstrList, ",")
        For i = LBound(arrValues) To UBound(arrValues)
            If mstrValue = arrValues(i) Then
                IsInList = True
                Return False
            End If
        Next
        Return True
    End Function


    Public Function GetFrLine(ByVal arrText() As String, ByVal intFromLine As Integer, _
                            Optional ByVal intToLine As Integer = 0) As String
        'Purpose: Get a part of page from specified line
        'Input: Page to take a part. Line to get from
        'Output: a part of page from specified line

        Dim i As Integer
        GetFrLine = ""
        If intToLine = 0 Then intToLine = UBound(arrText)

        For i = intFromLine To intToLine
            GetFrLine = GetFrLine & arrText(i) & vbCrLf
        Next
        GetFrLine = RemoveLastChr(GetFrLine)
    End Function
    Public Function CheckValidDate(ByVal strDate) As Boolean
        'Purpose: Check if a date in DDMMMYY format is a valid date
        'Input: date in DDMMMYY format
        'Output: Y/N
        If IsDate(Left(strDate, 2) & " " & Mid(strDate, 3, 3) & " " & Right(strDate, 2)) Then
            CheckValidDate = True
        Else
            CheckValidDate = False
        End If
    End Function

    Public Function FormatSegList(ByVal strSegList As String) As String
        'Purpose: Convert a list of segment containing dash (-) into list with comma only
        'Input: data in dash format
        'Output: data in comma format
        Dim i As Integer
        Dim arrComma() As String
        Dim arrDash() As String
        Dim strResult As String = ""
        Dim bytDash As Byte
        Dim bytComma As Byte
        bytDash = InStr(strSegList, "-")
        bytComma = InStr(strSegList, ",")
        If bytDash = 0 Then
            FormatSegList = strSegList
        ElseIf bytComma = 0 Then
            arrDash = Split(strSegList, "-")
            For i = arrDash(0) To arrDash(1)
                strResult = strResult & i & ","
            Next
            FormatSegList = RemoveLastChr(strResult)
        Else
            arrComma = Split(strSegList, ",")
            For i = LBound(arrComma) To UBound(arrComma)
                If InStr(arrComma(i), "-") Then
                    arrComma(i) = Dash2Comma(arrComma(i))
                End If
            Next
            FormatSegList = Join(arrComma, ",")
        End If
    End Function

    Public Function Dash2Comma(ByVal strDash As String) As String
        'Purpose: Convert a series of number from dash format to comma.
        '           e.g: 3-5 => 3,4,5
        'Input: data in dash format
        'Output: data in comma format
        Dim i As Integer
        Dim arrDash() As String
        Dim strResult As String = ""

        arrDash = Split(strDash, "-")
        For i = arrDash(0) To arrDash(1)
            strResult = strResult & i & ","
        Next
        Dash2Comma = RemoveLastChr(strResult)
    End Function
    Public Function LocateDot(ByVal strText As String) As Object
        'Purpose: Locate position of all dots (.) in a string
        'Input: string
        'Output: array
        Dim i As Integer, j As Integer
        Dim arrDotBreak() As String
        Dim arrDotPos() As Byte
        arrDotPos = Nothing
        arrDotBreak = Split(strText, ".")
        For i = 0 To UBound(arrDotBreak) - 1

            ReDim Preserve arrDotPos(j)
            If j = 0 Then
                arrDotPos(j) = Len(arrDotBreak(i)) + 1
            Else
                arrDotPos(j) = arrDotPos(j - 1) + Len(arrDotBreak(i)) + 1
            End If
            j = i + 1
        Next
        LocateDot = arrDotPos
    End Function

    Public Function Ptc2PaxType(ByVal strPTC As String) As String
        'Purpose: Convert PTC to Pax type
        'Input: PTC
        'Output: Pax type
        Ptc2PaxType = ""
        Select Case strPTC
            Case "CNN"
                Ptc2PaxType = "CHD"
            Case "INF"
                Ptc2PaxType = "INF"
            Case "ADT"
                Ptc2PaxType = "ADL"
        End Select
    End Function


    Public Function PaxTypeByFb(ByVal strFb As String) As String
        'Purpose: find RAS pax type based on Fare basis
        'Input: fare basis
        'Output: pax type

        PaxTypeByFb = "ADL"
        Select Case Len(strFb)
            Case Is < 3
            Case Is < 5
                If Right(strFb, 2) = "CH" Then
                    PaxTypeByFb = "CHD"
                ElseIf Right(strFb, 2) = "IN" Then
                    PaxTypeByFb = "INF"
                End If
            Case Else
                If Right(strFb, 2) = "CH" Then
                    PaxTypeByFb = "CHD"
                ElseIf Right(strFb, 2) = "IN" Then
                    PaxTypeByFb = "INF"
                Else
                    Select Case Right(strFb, 4)
                        Case "CH33", "CH25"
                            PaxTypeByFb = "CHD"
                        Case "IN90", "IN00"
                            PaxTypeByFb = "INF"
                    End Select
                End If
        End Select

    End Function

    Public Function GetRtgTypeVC(ByVal strValCar As String, _
                    ByVal arrCountry() As String, ByVal arrCar() As String) As String
        'Tim Routing type tren Validating carrier
        Dim i As Integer
        Dim strExCountryVC As String = ""

        GetRtgTypeVC = "XXX"

        For i = 1 To UBound(arrCar)
            If arrCar(i) = strValCar Then
                If strExCountryVC = "" Then strExCountryVC = arrCountry(i)
                If arrCountry(i + 1) = strExCountryVC Then
                    GetRtgTypeVC = strExCountryVC & "DOMVC"
                    Exit For
                Else
                    GetRtgTypeVC = "INTLVC"
                    Exit For
                End If
            End If
        Next

    End Function
    Public Function RoundVndTax(ByVal curTax As Decimal) As Decimal
        'Purpose: Lay gia tri tax den het phan nguyen va lam tron next higher 10 VND
        'Input: Unrounded Tax amount
        'Output: Rounded Tax amount
        Dim strTax As String
        Dim bytDot As Byte

        bytDot = InStr(curTax, ".")
        If bytDot = 0 Then
            strTax = CStr(curTax)
        Else
            strTax = Left(curTax, bytDot - 1)
        End If

        Select Case Right(strTax, 1)
            Case 0
                RoundVndTax = strTax
            Case Else
                RoundVndTax = (Left(strTax, Len(strTax) - 1) * 10) + 10
        End Select
    End Function
    Public Function RoundVndFare(ByVal curFare As Decimal) As Decimal
        'Purpose: Lay gia tri Fare den het phan nguyen va lam tron next higher 10 VND
        'Input: Unrounded Fare amount
        'Output: Rounded Fare amount
        Dim strFare As String
        Dim bytDot As Byte

        bytDot = InStr(curFare, ".")
        If bytDot = 0 Then
            strFare = CStr(curFare)
        Else
            strFare = Left(curFare, bytDot - 1)
        End If

        Select Case Right(strFare, 3)
            Case Is >= 500
                RoundVndFare = (Left(strFare, Len(strFare) - 3) * 1000) + 1000
            Case Else
                RoundVndFare = Left(strFare, Len(strFare) - 3) * 1000
        End Select
    End Function

    Public Function RoundUsdTax(ByVal curTax As Decimal) As Decimal
        'Purpose: Lay gia tri tax den 2 so thap phan va lam tron next higher 0.1 USD
        'Input: Unrounded Tax amount
        'Output: Rounded Tax amount
        Dim arrDotBreak() As String
        Dim bytDot As Byte

        bytDot = InStr(curTax, ".")
        If bytDot = 0 Then
            RoundUsdTax = curTax
        Else
            arrDotBreak = Split(curTax, ".")
            If Mid(arrDotBreak(1), 2) = 0 Then
                RoundUsdTax = Left(curTax, bytDot + 2)
            Else
                RoundUsdTax = Left(curTax, bytDot + 1) + 0.1
            End If
        End If
    End Function
    Public Function ValidPaxType(ByVal strPaxType As String) As Boolean
        'Purpose: Check if pax type is valid
        'Input: Pax type
        'Output: Y/N
        Select Case strPaxType
            Case "ADL", "CHD", "INF"
                Return True
            Case Else
                Return False
        End Select
    End Function
    Public Function FormatTimeH(ByVal dteTime As Date) As String
        'Purpose: Add "H" into time
        'Input: time without  "H"
        'Output: time with  "H"
        FormatTimeH = Format(dteTime, "HH") & "H" & Format(dteTime, "NN")
    End Function
    Public Function Bln2Nbr(ByVal mblnValue As Boolean) As Byte
        If mblnValue Then
            Bln2Nbr = 1
        Else
            Bln2Nbr = 0
        End If
    End Function

    Public Function ChangeSpecialChr(ByVal strText As String) As String
        'Purpose: Replace special character like (') by (*) to update into SQL
        'Input: Text before the change
        'Output: Text after the change
        ChangeSpecialChr = Replace(strText, "'", "*")
    End Function

    Public Function GetPaxType(ByVal strPaxType) As String
        If strPaxType = "ADT" Then
            GetPaxType = "ADL"
        Else
            GetPaxType = strPaxType
        End If
    End Function

    Public Function GetNumString(ByVal strText As String) As String
        'Purpose: Get the numeric string at the beginning of the text
        'Input: Text
        'Output: numeric value
        Dim i As Integer
        GetNumString = ""

        For i = 1 To Len(strText)
            If IsNumeric(Mid(strText, i, 1)) Then
                GetNumString = GetNumString & Mid(strText, i, 1)
            ElseIf Mid(strText, i, 1) = "." Then
                If i = 1 Then
                    Exit Function
                Else
                    GetNumString = GetNumString & Mid(strText, i, 1)
                End If
            Else
                Exit Function
            End If
        Next
    End Function
    Public Function FormatRasTkno(ByVal strTktNbr As String) As String
        If Len(strTktNbr) = 15 Then
            FormatRasTkno = strTktNbr
            Exit Function
        End If
        strTktNbr = Replace(strTktNbr, "-", "")
        FormatRasTkno = Left(strTktNbr, 3) & " " & Mid(strTktNbr, 4, 4) & " " & Mid(strTktNbr, 8)
    End Function
    Public Function AdjustFb(ByVal FareBasis As String) As String
        FareBasis = Remove2Spaces(FareBasis)
        FareBasis = Replace(FareBasis, " ", "/")
        AdjustFb = FareBasis
    End Function
    Public Function AdjustTstPaxName(ByVal strName As String) As String
        'Purpose: Remove space before/after slash in TST name

        AdjustTstPaxName = Replace(strName, " /", "/")
        AdjustTstPaxName = Replace(AdjustTstPaxName, " /", "/")
    End Function
    Public Function CheckFormatPnr1S(ByVal strPnr As String) As Boolean
        'Purpose: Check if the input content is 1S PNR
        'Input: Pnr text
        'Output: Y/N
        Dim i As Integer
        Dim arrLines() As String
        Dim bytRlocPos As Byte
        Dim bytNamePos As Byte

        'strPnr = Replace(strPnr, vbCrLf, vbLf)
        If Len(strPnr) < 160 Then
            Return False
        End If
        arrLines = Split(strPnr, vbCrLf)
        If UBound(arrLines) < 2 Then Return False
        For i = 0 To 2
            If Len(Trim(arrLines(i))) = 6 Then
                bytRlocPos = i
            End If
            If InStr(arrLines(i), ".") > 0 Then
                bytNamePos = i
            End If
        Next
        If bytNamePos - bytRlocPos < 3 Then
            Return True
        End If
        Return True
    End Function

    Public Function AdjLinePnr1A(ByVal strLine As String, ByVal intEle As Integer) As String
        'Purpose: Adjust 1A PNR line
        'Input: Pnr line
        'Output: PNR line after adjustment
        Select Case intEle
            Case Is < 10
                AdjLinePnr1A = "  " & strLine
            Case Is < 100
                AdjLinePnr1A = " " & strLine
            Case Else
                AdjLinePnr1A = strLine
        End Select
    End Function

    Public Function GetCur(ByVal strText As String) As String
        'Purpose: Get currency code in text format xxxyyyy
        GetCur = Left(Trim(strText), 3)
    End Function
    Public Function GetAmt(ByVal strText As String) As Decimal
        'Purpose: Get currency code in text format xxxyyyy
        GetAmt = Mid(Trim(strText), 4)
    End Function
    Public Function Fb2PaxType(ByVal strFB As String) As String
        'Purpose: Find corresponding Pax Type from fare basis 
        'Input: Fare basis  
        'Output: Pax type

        Fb2PaxType = "ADL"
        If Len(strFB) > 4 Then
            Select Case Right(strFB, 4)
                Case "IN90"
                    Fb2PaxType = "INF"
                Case "CH25", "CH33"
                    Fb2PaxType = "CHD"
                    Exit Function
            End Select
            Select Case Right(strFB, 2)
                Case "IN"
                    Fb2PaxType = "INF"
                Case "CH"
                    Fb2PaxType = "CHD"
                    Exit Function
            End Select
        ElseIf Len(strFB) > 2 Then
            Select Case Right(strFB, 2)
                Case "IN"
                    Fb2PaxType = "INF"
                Case "CH"
                    Fb2PaxType = "CHD"
                    Exit Function
            End Select
        End If
    End Function
    Public Function TktNbrs2Tkno(ByVal strFirstTkt As String, ByVal strLastTkt As String) As Array
        Dim arrTkno() As String
        Dim i As Integer

        If strLastTkt = "" Then
            ReDim arrTkno(0 To 0)
            arrTkno(0) = FormatRasTkno(strFirstTkt)
        Else
            Dim intArrUbound As Integer
            intArrUbound = strLastTkt - Right(strFirstTkt, 2)
            If intArrUbound < 0 Then
                intArrUbound = intArrUbound + 100
            End If
            ReDim arrTkno(0 To intArrUbound)
            For i = 0 To intArrUbound
                arrTkno(i) = FormatRasTkno(strFirstTkt + i)
            Next
        End If
        TktNbrs2Tkno = arrTkno
    End Function
    Public Function TktNbrs2Ftkt(ByVal strFirstTkt As String, ByVal strLastTkt As String) As Array
        Dim arrFtkt() As String
        Dim i As Integer

        If strLastTkt = "" Then
            ReDim arrFtkt(0 To 0)
            arrFtkt(0) = ""
        Else
            Dim intArrUbound As Integer
            intArrUbound = strLastTkt - Right(strFirstTkt, 2)
            If intArrUbound < 0 Then
                intArrUbound = intArrUbound + 100
            End If
            ReDim arrFtkt(0 To intArrUbound)
            For i = 0 To intArrUbound
                Select Case i
                    Case 0
                        arrFtkt(i) = "___/" & Right(strFirstTkt + 1, 3)
                    Case intArrUbound
                        arrFtkt(i) = Right(strFirstTkt + i - 1, 3) & "/"
                    Case Else
                        arrFtkt(i) = Right(strFirstTkt + i - 1, 3) & "/" _
                            & Right(strFirstTkt + i + 1, 3)
                End Select
            Next
        End If
        TktNbrs2Ftkt = arrFtkt
    End Function
    Public Function Sectors2RasBkgs(ByVal colSectors As Collection) As Array
        'Purpose: create array of bkg classes in RAS format
        'Input: Collection of Sectors
        'Output: Bkg class array
        Dim intArrUbound As Integer
        Dim arrBkgs() As String
        Dim i As Integer, j As Integer
        Dim strBkgs As String

        Select Case colSectors.Count
            Case Is < 5
                intArrUbound = 0
            Case Is < 9
                intArrUbound = 1
            Case Is < 13
                intArrUbound = 2
            Case Else
                intArrUbound = 3
        End Select
        ReDim arrBkgs(0 To intArrUbound)
        For i = 0 To intArrUbound
            strBkgs = ""
            If i = intArrUbound Then
                For j = i * 4 + 1 To colSectors.Count
                    strBkgs = strBkgs & colSectors(j).Cls
                Next
            Else
                For j = i * 4 + 1 To i * 4 + 4
                    strBkgs = strBkgs & colSectors(j).Cls
                Next
            End If
            arrBkgs(i) = strBkgs
        Next
        Sectors2RasBkgs = arrBkgs
    End Function
    Public Function Rtg2RasRtgs(ByVal strFullRtg As String) As Array
        'Purpose: create array of bkg classes in RAS format
        'Input: Collection of Sectors
        'Output: Bkg class array
        Dim intArrUbound As Integer
        Dim bytStart As Byte
        Dim arrRtgs() As String
        Dim i As Integer
        Dim strRtgs As String

        Select Case Len(strFullRtg)
            Case Is < 24
                intArrUbound = 1
            Case Is < 44
                intArrUbound = 2
            Case Is < 64
                intArrUbound = 3
            Case Else
                intArrUbound = 4
        End Select
        ReDim arrRtgs(0 To intArrUbound)

        For i = 0 To intArrUbound
            strRtgs = ""
            Select Case i
                Case intArrUbound
                    bytStart = i * 20 + 1
                    strRtgs = Mid(strFullRtg, bytStart)
                Case Else
                    bytStart = i * 20 + 1
                    strRtgs = Mid(strFullRtg, bytStart, 23)
            End Select
            arrRtgs(i) = strRtgs
        Next
        Rtg2RasRtgs = arrRtgs
    End Function
    Public Function Sectors2RasFbs(ByVal colSectors As Collection) As Array
        'Purpose: create array of Fb classes in RAS format
        'Input: Collection of Sectors
        'Output: Fb class array
        Dim intArrUbound As Integer
        Dim arrFbs() As String
        Dim i As Integer, j As Integer
        Dim strFbs As String

        Select Case colSectors.Count
            Case Is < 5
                intArrUbound = 0
            Case Is < 9
                intArrUbound = 1
            Case Is < 13
                intArrUbound = 2
            Case Else
                intArrUbound = 3
        End Select
        ReDim arrFbs(0 To intArrUbound)

        For i = 0 To intArrUbound
            strFbs = ""
            If i = intArrUbound Then
                For j = i * 4 + 1 To colSectors.Count
                    strFbs = strFbs & colSectors(j).FB & "+"
                Next
            Else
                For j = i * 4 + 1 To i * 4 + 4
                    strFbs = strFbs & colSectors(j).FB & "+"
                Next
            End If
            arrFbs(i) = RemoveLastChr(strFbs)
        Next
        Sectors2RasFbs = arrFbs
    End Function
    Public Function Sectors2RasFltNbrs(ByVal colSectors As Collection) As Array
        'Purpose: create array of FltNbr classes in RAS format
        'Input: Collection of Sectors
        'Output: FltNbr class array
        Dim intArrUbound As Integer
        Dim arrFltNbrs() As String
        Dim i As Integer, j As Integer
        Dim strFltNbrs As String

        Select Case colSectors.Count
            Case Is < 5
                intArrUbound = 0
            Case Is < 9
                intArrUbound = 1
            Case Is < 13
                intArrUbound = 2
            Case Else
                intArrUbound = 3
        End Select
        ReDim arrFltNbrs(0 To intArrUbound)

        For i = 0 To intArrUbound
            strFltNbrs = ""
            If i = intArrUbound Then
                For j = i * 4 + 1 To colSectors.Count
                    strFltNbrs = strFltNbrs & colSectors(j).Carrier & _
                                colSectors(j).FltNbr & ";"
                Next
            Else
                For j = i * 4 + 1 To i * 4 + 4
                    strFltNbrs = strFltNbrs & colSectors(j).Carrier & _
                                colSectors(j).FltNbr & ";"
                Next
            End If

            arrFltNbrs(i) = RemoveLastChr(strFltNbrs)
        Next
        Sectors2RasFltNbrs = arrFltNbrs
    End Function
    Public Function Sectors2RasFltDates(ByVal colSectors As Collection) As Object
        'Purpose: create array of FltDate classes in RAS format
        'Input: Collection of Sectors
        'Output: FltDate class array
        Dim intArrUbound As Integer
        Dim arrFltDates() As String
        Dim i As Integer, j As Integer
        Dim strFltDates As String
        Dim strFltDate As String

        Select Case colSectors.Count
            Case Is < 5
                intArrUbound = 0
            Case Is < 9
                intArrUbound = 1
            Case Is < 13
                intArrUbound = 2
            Case Else
                intArrUbound = 3
        End Select
        ReDim arrFltDates(0 To intArrUbound)

        For i = 0 To intArrUbound
            strFltDates = ""
            Select Case i
                Case intArrUbound
                    For j = i * 4 + 1 To colSectors.Count
                        strFltDate = ToGdsDate(colSectors(j).FltDate)
                        strFltDates = strFltDates & strFltDate & ";"
                    Next

                Case Else
                    For j = i * 4 + 1 To i * 4 + 4
                        strFltDate = ToGdsDate(colSectors(j).FltDate)
                        strFltDates = strFltDates & strFltDate & ";"
                    Next
            End Select
            arrFltDates(i) = RemoveLastChr(strFltDates)
        Next
        Sectors2RasFltDates = arrFltDates
    End Function
    Public Function RemoveMdLine1B(ByVal strText As String) As String
        'purpose: Remove MD line in Abacus response
        'Input: Response with MD line
        'Output: Response without MD line
        Dim arrLines() As String
        Dim i As Integer
        Dim arrResult(0 To 0) As String

        If InStr(strText, "«") = 0 Then
            RemoveMdLine1B = strText
            Exit Function
        End If
        arrLines = Split(strText, vbCrLf)
        For i = 0 To UBound(arrLines)
            
            If Trim(arrLines(i)) = "MD«" Or Trim(arrLines(i)) = "md«" Then
                arrResult(UBound(arrResult)) = RemoveLastChr(RTrim(arrResult(UBound(arrResult))))
                arrLines(i + 1) = RemoveLastChr(RTrim(arrLines(i + 1)))
            Else
                ReDim Preserve arrResult(0 To UBound(arrResult) + 1)
                arrResult(UBound(arrResult)) = arrLines(i)
            End If
        Next
        RemoveMdLine1B = Join(arrResult, vbCrLf)
    End Function
    Public Function ReplaceAll(ByVal InputText As String, ByVal FindText As String, ByVal ReplaceText As String)
        'Thay the tuyet doi 1 chuoi, manh hon chuc nang replace
        While InStr(InputText, FindText) > 0
            InputText = Replace(InputText, FindText, ReplaceText)
        End While
        ReplaceAll = InputText
    End Function
    Public Function GetText(ByVal InputText As String, Optional ByVal FromText As String = "", _
    Optional ByVal ExclFrom As Boolean = True, _
    Optional ByVal ToText As String = "", _
    Optional ByVal ExclTo As Boolean = True)
        Dim sglFrom As Single
        Dim sglTo As Single

        sglFrom = InStr(InputText, FromText)
        If sglFrom = 0 Then
            sglFrom = 1
            FromText = ""
        End If
        InputText = Mid(InputText, sglFrom)
        If ExclFrom Then
            InputText = Mid(InputText, Len(FromText) + 1)
        End If

        sglTo = InStr(InputText, ToText)
        If sglTo > 0 Then
            InputText = Mid(InputText, 1, sglTo + Len(ToText) - 1)
            If ExclTo Then InputText = Left(InputText, Len(InputText) - Len(ToText))
        End If
        GetText = InputText
    End Function
    Public Function Text2Date(ByVal InputDate As String) As Date
        ' Dung de chuyen ngay dang YYMMDD hoac DDMMMYY sang dang cua Visual basic
        ' Chi dung voi date tu nam 2000 tro len
        Dim dteResult As Date
        Select Case Len(InputDate)
            Case 6
                dteResult = DateSerial("20" & Mid(InputDate, 1, 2), Mid(InputDate, 3, 2), Mid(InputDate, 5, 2))
            Case 7
                dteResult = Mid(InputDate, 1, 2) & " " & Mid(InputDate, 3, 3) & " " & Mid(InputDate, 6, 2)
        End Select
        Return dteResult
    End Function
    Public Function FixTextLength(ByVal strText As String, ByVal intLength As Integer) As String
        ' Dung de tao fixed-length text
        Dim intDiff As Integer
        Dim i As Integer
        Dim strSpaces As String = ""

        FixTextLength = strText
        intDiff = intLength - strText.Length
        Select Case intDiff
            Case Is > 0
                For i = 1 To intDiff
                    strSpaces = strSpaces & " "
                Next
                FixTextLength = strSpaces & strText.ToString

            Case Is < 0
                FixTextLength = Right(strText, intLength)
        End Select
    End Function
    Public Function FormatResponse1S(ByVal strResponse As String) As String
        Dim arrResponseLines() As String
        arrResponseLines = Split(strResponse.ToString, Chr(10))
        If Mid(arrResponseLines(0), 64, 1) = "‡" Then
            arrResponseLines(0) = Left(arrResponseLines(0), 63) & Chr(10) & Mid(arrResponseLines(0), 65)
        End If
        FormatResponse1S = Join(arrResponseLines, Chr(10))
        FormatResponse1S = Replace(FormatResponse1S, Chr(10), vbCrLf)
    End Function
    Public Function GetSsrInfName1S(ByVal strSsrText As String) As String
        'Purpose: Get infant name from 1S SSR Text
        'Input: SSR INFT Text
        'Output: Infant name
        Dim arrSlash() As String
        arrSlash = Split(strSsrText, "/")
        GetSsrInfName1S = arrSlash(1) & "/" & arrSlash(2)
    End Function
    Public Function GetSsrPaxName1S(ByVal strSsrText As String) As String
        'Purpose: Get Pax name from 1S SSR Text
        'Input: SSR DOCS Text
        'Output: Pax name
        Dim arrSlash() As String
        arrSlash = Split(strSsrText, "/")
        GetSsrPaxName1S = arrSlash(UBound(arrSlash) - 1) & "/" & arrSlash(UBound(arrSlash))
    End Function
    Public Function GetEleAssociations(ByVal colAssociations As Object) As String
        'Purpose: get Pax or seg associations in Amadeus PNR
        'Input: Association object
        'Output: List of PNR element, seperated by comma

        Dim strResult As String = ""
        Dim objAssociation As Object

        For Each objAssociation In colAssociations
            strResult = strResult & objAssociation.ElementNo & ","
        Next
        GetEleAssociations = RemoveLastChr(strResult)
    End Function
    Public Function GetFullName(ByVal strLastName As String, ByVal strInitial As String) As String

        If strInitial = "" Then
            GetFullName = strLastName
        Else
            GetFullName = strLastName & "/" & strInitial
        End If
    End Function
    Public Function GetLastName(ByVal strFullName As String) As String
        Dim arrSlash() As String
        arrSlash = Split(strFullName, "/")
        GetLastName = arrSlash(0)
    End Function
    Public Function GetInitialName(ByVal strFullName As String) As String
        Dim arrSlash() As String
        arrSlash = Split(strFullName, "/")
        If UBound(arrSlash) > 0 Then
            GetInitialName = arrSlash(UBound(arrSlash))
        Else
            GetInitialName = ""
        End If
    End Function
    Public Function GetStatusOKRQ(ByVal strStatus As String) As String

        Select Case strStatus
            Case "DN", "DW", "GL", "GL", "HN", "HL", "LL", "NN", "PL", "TL", "TN", "US", "UU"
                strStatus = "RQ"
            Case ""
                strStatus = ""
            Case Else
                strStatus = "OK"
        End Select
        GetStatusOKRQ = strStatus
    End Function
    Public Function GetSsrInfName(ByVal strSsrText As String) As String
        'Purpose: Get infant name from 1S SSR Text
        'Input: SSR INFT Text
        'Output: Infant name
        Dim arrSlash() As String
        arrSlash = Split(strSsrText, "/")
        GetSsrInfName = arrSlash(1) & "/" & arrSlash(2)
    End Function
    Public Function GetSsrPaxName(ByVal strSsrText As String) As String
        'Purpose: Get Pax name from 1S SSR Text
        'Input: SSR DOCS Text
        'Output: Pax name
        Dim arrSlash() As String
        arrSlash = Split(strSsrText, "/")
        GetSsrPaxName = arrSlash(UBound(arrSlash) - 1) & "/" & arrSlash(UBound(arrSlash))
    End Function
    Public Function CheckFormatErp1S(ByVal strErp As String) As Boolean
        'Purpose: check format of Sabre ERP

        CheckFormatErp1S = True
        strErp = Trim(strErp)
        'If Len(strErp) <> 6 Then
        '    CheckFormatErp1S = False
        'End If
        If Not IsNumeric(strErp) Then
            CheckFormatErp1S = False
        End If
    End Function
    Public Function CheckFormatRloc1S(ByVal strRloc As String) As Boolean
        'Purpose: check format of Sabre Rloc

        CheckFormatRloc1S = True
        strRloc = Trim(strRloc)
        If Len(strRloc) <> 6 Then
            CheckFormatRloc1S = False
        End If

    End Function
    Public Function TimeText2Date(ByVal strTimeHHMM As String) As Date
        TimeText2Date = Left(strTimeHHMM, 2) & ":" & Right(strTimeHHMM, 2)
    End Function
    Public Function CheckOpenCoupon(ByVal strStatus As String) As Boolean

        Select Case strStatus
            Case "O", "OPEN"
                Return True
            Case Else
                Return False
        End Select
    End Function
    Public Function GetQinFC(ByVal strFareCalc As String) As Decimal
        'Purpose: Phan tich Fare Calc trong FQQ, lay Q
        'Input: FQQ Fare Calc
        'Output: Total of all Q
        Dim i As Integer
        Dim arrFareCalc() As String
        Dim curQ As Double

        arrFareCalc = Split(strFareCalc, " ")
        For i = 0 To UBound(arrFareCalc)
            If Left(arrFareCalc(i), 1) = "Q" And Len(arrFareCalc(i)) > 3 Then
                If IsNumeric(Mid(arrFareCalc(i), 2)) Then
                    curQ = curQ + Mid(arrFareCalc(i), 2)
                ElseIf IsNumeric(Mid(arrFareCalc(i), 2, Len(arrFareCalc(i)) - 3)) Then
                    curQ = curQ + Mid(arrFareCalc(i), 2, Len(arrFareCalc(i)) - 3)
                End If
            End If
        Next i
        GetQinFC = curQ
    End Function
    Public Function GetSinFC(ByVal strFareCalc As String) As Decimal
        'Purpose: Phan tich Fare Calc trong FQQ, lay Stopover charge
        'Input: FQQ Fare Calc
        'Output: Total of all Stopover charge
        Dim i As Integer
        Dim arrFareCalc() As String
        Dim curS As Double
        Dim bytNucPos As Integer
        Dim strStopoverText As String

        arrFareCalc = Split(strFareCalc, " ")
        For i = 0 To UBound(arrFareCalc)
            If Len(arrFareCalc(i)) > 4 Then
                If Left(arrFareCalc(i), 1) = "S" Or Left(arrFareCalc(i), 2) = "1S" _
                    Or Left(arrFareCalc(i), 2) = "2S" _
                    Or Left(arrFareCalc(i), 2) = "3S" Then
                    If IsNumeric(Mid(arrFareCalc(i), 2)) Then
                        curS = curS + Mid(arrFareCalc(i), 2)
                    ElseIf IsNumeric(Mid(arrFareCalc(i), 2, Len(arrFareCalc(i)) - 3)) Then
                        curS = curS + Mid(arrFareCalc(i), 2, Len(arrFareCalc(i)) - 3)
                    Else
                        bytNucPos = InStr(arrFareCalc(i), "NUC")
                        If bytNucPos > 0 Then
                            strStopoverText = Left(arrFareCalc(i), bytNucPos - 1)
                            If IsNumeric(Mid(strStopoverText, 3)) Then
                                curS = curS + Mid(strStopoverText, 3)
                            End If
                        End If
                    End If
                End If
            End If
        Next i
        GetSinFC = curS
    End Function
    Public Function GetPaxTypeFromFb(ByVal strFb As String) As String
        'Purpose: Find corresponding Pax Type for fare basis
        'Input: Fare basis
        'Output: Pax type

        'Dim bytSlash As Integer

        GetPaxTypeFromFb = "ADL"
        If Len(strFb) > 4 Then
            Select Case Right(strFb, 4)
                Case "IN90"
                    GetPaxTypeFromFb = "INF"
                    Exit Function
                Case "CH25", "CH33"
                    GetPaxTypeFromFb = "CHD"
                    Exit Function
            End Select
        End If

        If Len(strFb) > 2 Then
            Select Case Right(strFb, 2)
                Case "IN"
                    GetPaxTypeFromFb = "INF"
                    Exit Function
                Case "CH"
                    GetPaxTypeFromFb = "CHD"
                    Exit Function
            End Select
        End If
    End Function
    Public Function Date2YYMMDD(ByVal dteDate) As String
        Date2YYMMDD = Format(dteDate, "yyMMdd")
    End Function
    Public Function RasTkts(ByVal strFirstTkt As String, ByVal strLastTkt As String) As Array
        'Purpose: create array of tickets in RAS format
        'Input: First Ticket number, Last Ticket number
        'Output: Pax type
        Dim bytTktCount As Integer

        Dim arrTkts(0 To 0) As String
        Dim i As Integer

        If strLastTkt = "" Then
            arrTkts(0) = Format(strFirstTkt + i, "000 0000 000000")
            RasTkts = arrTkts
            Exit Function
        End If
        bytTktCount = strLastTkt - Right(strFirstTkt, 2)
        If bytTktCount < 0 Then
            bytTktCount = bytTktCount + 100
        End If
        bytTktCount = bytTktCount + 1

        ReDim arrTkts(0 To bytTktCount - 1)
        For i = 0 To bytTktCount - 1
            arrTkts(i) = Format(strFirstTkt + i, "000 0000 000000")
        Next
        RasTkts = arrTkts
    End Function
    Public Function RasFltNbrs(ByVal colSectors As Collection) As Array
        'Purpose: create array of FltNbr classes in RAS format
        'Input: Collection of Sectors
        'Output: FltNbr class array
        Dim bytTktCount As Integer
        Dim arrFltNbrs(0 To 0) As String
        Dim i As Integer, j As Integer
        Dim strFltNbrs As String

        Select Case colSectors.Count
            Case Is < 5
                bytTktCount = 1
            Case Is < 9
                bytTktCount = 2
            Case Is < 13
                bytTktCount = 3
            Case Else
                bytTktCount = 4
        End Select
        ReDim arrFltNbrs(0 To bytTktCount - 1)

        For i = 0 To bytTktCount - 1
            strFltNbrs = ""
            If i = bytTktCount - 1 Then
                For j = i * 4 + 1 To colSectors.Count
                    strFltNbrs = strFltNbrs & colSectors(j).Carrier & _
                                colSectors(j).FltNbr & ";"
                Next
            Else
                For j = i * 4 + 1 To i * 4
                    strFltNbrs = strFltNbrs & colSectors(j).Carrier & _
                                colSectors(j).FltNbr & ";"
                Next
            End If
            arrFltNbrs(i) = RemoveLastChr(strFltNbrs)
        Next
        RasFltNbrs = arrFltNbrs
    End Function
    Public Function RasFbs(ByVal colSectors As Collection) As Array
        'Purpose: create array of Fb classes in RAS format
        'Input: Collection of Sectors
        'Output: Fb class array
        Dim bytTktCount As Integer
        Dim arrFbs() As String
        Dim i As Integer, j As Integer
        Dim strFBs As String

        Select Case colSectors.Count
            Case Is < 5
                bytTktCount = 1
            Case Is < 9
                bytTktCount = 2
            Case Is < 13
                bytTktCount = 3
            Case Else
                bytTktCount = 4
        End Select
        ReDim arrFbs(0 To bytTktCount - 1)

        For i = 0 To bytTktCount - 1
            strFBs = ""
            If i = bytTktCount - 1 Then
                For j = i * 4 + 1 To colSectors.Count
                    strFBs = strFBs & colSectors(j).Fb & "+"
                Next
            Else
                For j = i * 4 + 1 To i * 4
                    strFBs = strFBs & colSectors(j).Fb & "+"
                Next
            End If
            arrFbs(i) = RemoveLastChr(strFBs)
        Next
        RasFbs = arrFbs
    End Function
    Public Function RasRtgs(ByVal strFullRtg As String) As Array
        'Purpose: create array of bkg classes in RAS format
        'Input: Collection of Sectors
        'Output: Bkg class array
        Dim bytTktCount As Integer
        Dim bytStart As Integer
        'Dim bytLength As Integer
        Dim arrRtgs() As String
        Dim i As Integer
        Dim strRtgs As String

        Select Case Len(strFullRtg)
            Case Is < 24
                bytTktCount = 1
            Case Is < 44
                bytTktCount = 2
            Case Is < 64
                bytTktCount = 3
            Case Else
                bytTktCount = 4
        End Select
        ReDim arrRtgs(0 To bytTktCount - 1)

        For i = 0 To bytTktCount - 1
            strRtgs = ""
            Select Case i
                Case bytTktCount - 1
                    bytStart = i * 20 + 1
                    strRtgs = Mid(strFullRtg, bytStart)
                Case Else
                    bytStart = i * 20 + 1
                    strRtgs = Mid(strFullRtg, bytStart, 23)
            End Select
            arrRtgs(i) = strRtgs
        Next
        RasRtgs = arrRtgs
    End Function
    Public Function RasFltDates(ByVal colSectors As Collection) As Array
        'Purpose: create array of FltDate classes in RAS format
        'Input: Collection of Sectors
        'Output: FltDate class array
        Dim bytTktCount As Integer
        Dim arrFltDates() As String
        Dim i As Integer, j As Integer
        Dim strFltDates As String
        Dim strFltDate As String

        Select Case colSectors.Count
            Case Is < 5
                bytTktCount = 1
            Case Is < 9
                bytTktCount = 2
            Case Is < 13
                bytTktCount = 3
            Case Else
                bytTktCount = 4
        End Select
        ReDim arrFltDates(0 To bytTktCount - 1)
        'xxx
        For i = 0 To bytTktCount - 1
            strFltDates = ""
            Select Case i
                Case bytTktCount - 1
                    For j = i * 4 + 1 To colSectors.Count
                        strFltDate = ToGdsDate(colSectors(j).depDate)
                        strFltDates = strFltDates & strFltDate & ";"
                    Next

                Case Else
                    For j = i * 4 + 1 To i * 4
                        strFltDate = ToGdsDate(colSectors(j).FltDate)
                        strFltDates = strFltDates & strFltDate & ";"
                    Next
            End Select
            arrFltDates(i) = RemoveLastChr(strFltDates)
        Next
        RasFltDates = arrFltDates
    End Function
    Public Function RasConjTkts(ByVal strFirstTkt As String, ByVal strLastTkt As String) As Array
        'Purpose: create array of conjunction tickets in RAS format
        'Input: First Ticket number, Last Ticket number
        'Output: Pax type
        Dim bytTktCount As Integer
        Dim arrConj(0 To 0) As String
        Dim i As Integer

        If strLastTkt = "" Then
            arrConj(0) = ""
            RasConjTkts = arrConj
            Exit Function
        End If
        bytTktCount = strLastTkt - Right(strFirstTkt, 2)
        If bytTktCount < 0 Then
            bytTktCount = bytTktCount + 100
        End If
        bytTktCount = bytTktCount + 1
        ReDim arrConj(0 To bytTktCount - 1)

        For i = 1 To bytTktCount - 1
            Select Case i
                Case 0
                    arrConj(i) = "___/" & Right(strFirstTkt + 1, 3)
                Case bytTktCount - 1
                    arrConj(i) = Right(strFirstTkt + i - 2, 3) & "/"
                Case Else
                    arrConj(i) = Right(strFirstTkt + i - 2, 3) & "/" _
                                & Right(strFirstTkt + i, 3)
            End Select
        Next
        RasConjTkts = arrConj
    End Function
    Public Function RasBkgs(ByVal colSectors As Collection) As Array
        'Purpose: create array of bkg classes in RAS format
        'Input: Collection of Sectors
        'Output: Bkg class array
        Dim bytTktCount As Integer
        Dim arrBkgs() As String
        Dim i As Integer, j As Integer
        Dim strBkgs As String

        Select Case colSectors.Count
            Case Is < 5
                bytTktCount = 1
            Case Is < 9
                bytTktCount = 2
            Case Is < 13
                bytTktCount = 3
            Case Else
                bytTktCount = 4
        End Select
        ReDim arrBkgs(0 To bytTktCount - 1)

        For i = 0 To bytTktCount - 1
            strBkgs = ""
            If i = bytTktCount - 1 Then
                For j = i * 4 + 1 To colSectors.Count
                    If colSectors(j).Cls = "" Then
                        strBkgs = strBkgs & " "
                    Else
                        strBkgs = strBkgs & colSectors(j).Cls
                    End If
                Next
                arrBkgs(i) = strBkgs
                Exit For
            Else
                For j = i * 4 + 1 To i * 4 + 4
                    strBkgs = strBkgs & colSectors(j).Cls
                Next
                arrBkgs(i) = strBkgs
            End If
        Next
        RasBkgs = arrBkgs
    End Function
    Public Function Append2TextFile(ByVal strText As String) As Boolean
        Dim strLogFile As String = System.AppDomain.CurrentDomain.BaseDirectory() & "\" & Format(Today, "yyMMdd") & pstrPrg & ".txt"

        Dim objLogFile As New System.IO.StreamWriter(strLogFile, True)
        objLogFile.Write(strText)
        objLogFile.Close()
        objLogFile = Nothing
        Append2TextFile = True
    End Function
    Public Function DateTime2Text(ByVal dteInputDate As Date) As String
        'Purpose: chuyen dang date time  thanh DD-MMM-YYYY HH:NN:SS trong VB
        DateTime2Text = Format(dteInputDate, "dd-MMM-yyyy HH:mm:ss")
    End Function
    Public Function ToGdsDate(ByVal dteInputDate As Date) As String
        If dteInputDate = #12:00:00 AM# Then
            ToGdsDate = ""
        Else
            ToGdsDate = UCase(Format(dteInputDate, "ddMMMyy"))
        End If
    End Function
    Public Function AddEqualConditionCombo(ByRef strQuerry As String, ByRef cboCondition As ComboBox _
                            , Optional ByVal strColumnName As String = "") As Boolean
        If cboCondition.Text = "" Then
            Return False
        End If
        If strColumnName = "" Then
            strQuerry = strQuerry & " and " & Mid(cboCondition.Name, 4) & "='" & cboCondition.Text & "'"
        Else
            strQuerry = strQuerry & " and " & strColumnName & "='" & cboCondition.Text & "'"
        End If

        Return True
    End Function
    Public Function AddEqualConditionText(ByRef strQuerry As String _
                                        , ByRef txtCondition As System.Windows.Forms.TextBox) As Boolean
        If txtCondition.Text = "" Then
            Return False
        End If
        strQuerry = strQuerry & " and " & Mid(txtCondition.Name, 4) & "='" & txtCondition.Text & "'"
        Return True
    End Function
    Public Function AddEqualConditionCheck(ByRef strQuerry As String _
                                        , ByRef chkCondition As System.Windows.Forms.CheckBox) As Boolean
        If chkCondition.CheckState <> CheckState.Indeterminate Then
            strQuerry = strQuerry & " and " & Mid(chkCondition.Name, 4) & "='" & chkCondition.CheckState & "'"
        End If
        Return True
    End Function
    Public Function AddLikeConditionText(ByRef strQuerry As String _
                                        , ByRef txtCondition As System.Windows.Forms.TextBox _
                                        , Optional strColumnName As String = "") As Boolean
        If txtCondition.Text <> "" Then
            If strColumnName <> "" Then
                strQuerry = strQuerry & " and " & strColumnName & " like '%" & txtCondition.Text & "%'"
            Else
                strQuerry = strQuerry & " and " & Mid(txtCondition.Name, 4) & " like '%" & txtCondition.Text & "%'"
            End If

        End If
        Return True
    End Function

    Public Function GetFromDate(ByVal dteInputDate As Date) As String
        GetFromDate = Format(dteInputDate, "dd-MMM-yyyy") & " 00:00:00"
    End Function
    Public Function GetToDate(ByVal dteInputDate As Date) As String
        GetToDate = Format(dteInputDate, "dd-MMM-yyyy") & " 23:59:00"
    End Function
    Public Function EmptyTextBox(ByRef txtTextBox As System.Windows.Forms.TextBox) As Boolean
        If Trim(txtTextBox.Text) = "" Then
            MsgBox(Mid(txtTextBox.Name, 4) & " must not be empty!")
            EmptyTextBox = True
        Else
            EmptyTextBox = False
        End If
    End Function
    Public Function EmptyControlText(ByRef objControl As Control, Optional ByVal strCtrlName As String = "") As Boolean

        If strCtrlName = "" Then
            strCtrlName = Mid(objControl.Name, 4)
        End If
        If Trim(objControl.Text) = "" Then
            MsgBox(strCtrlName & " must not be empty!")
            EmptyControlText = True
        Else
            EmptyControlText = False
        End If
    End Function
    Public Function ClearAllControlTexts(ByRef frmInput As Form) As Boolean
        Dim objControl As New Control
        For Each objControl In frmInput.Controls
            Select Case Mid(objControl.Name, 1, 3)
                Case "txt", "cbo"
                    objControl.Text = ""
            End Select
        Next
        ClearAllControlTexts = True
    End Function
    Public Function CheckFormatDaysInMonth(ByVal strDaysInMonth As String) As Boolean
        Dim arrValues() As String
        Dim i As Integer
        arrValues = Split(strDaysInMonth, ",")
        For i = 0 To UBound(arrValues)
            If Not IsNumeric(arrValues(i)) Then
                Return False
            ElseIf arrValues(i) > 31 Then
                Return False
            End If
        Next
        CheckFormatDaysInMonth = True
    End Function
    Public Function CheckFormatPaxType(ByVal strPaxType As String) As Boolean
        Dim arrBreak() As String
        Dim i As Integer

        If strPaxType = "" Then
            CheckFormatPaxType = True
            Exit Function
        End If
        arrBreak = Split(strPaxType, ",")
        For i = 0 To UBound(arrBreak)
            Select Case arrBreak(i)
                Case "CHD", "ADL", "INF"
                Case Else
                    CheckFormatPaxType = False
                    Exit Function
            End Select
        Next
        CheckFormatPaxType = True
    End Function
    Public Function CheckFormatMR(ByVal strMR As String) As Boolean
        Select Case strMR
            Case "", "M", "R"
                CheckFormatMR = True
            Case Else
                CheckFormatMR = False

        End Select
    End Function
    Public Sub PromtInputError(ByRef objControl As Control, ByVal strErrMsg As String)
        objControl.Focus()
        MsgBox(strErrMsg)
    End Sub
    Public Function ConvertValueHotFile(strInputAmt As String) As Double
        Dim strLastChar As String

        strInputAmt = Trim(strInputAmt)
        strLastChar = Right(strInputAmt, 1)
        Select Case strLastChar
            Case "{"
                strInputAmt = Replace(strInputAmt, "{", 0)
            Case "A"
                strInputAmt = Replace(strInputAmt, "A", 1)
            Case "B"
                strInputAmt = Replace(strInputAmt, "B", 2)
            Case "C"
                strInputAmt = Replace(strInputAmt, "C", 3)
            Case "D"
                strInputAmt = Replace(strInputAmt, "D", 4)
            Case "E"
                strInputAmt = Replace(strInputAmt, "E", 5)
            Case "F"
                strInputAmt = Replace(strInputAmt, "F", 6)
            Case "G"
                strInputAmt = Replace(strInputAmt, "G", 7)
            Case "H"
                strInputAmt = Replace(strInputAmt, "H", 8)
            Case "I"
                strInputAmt = Replace(strInputAmt, "I", 9)
            Case "}"
                strInputAmt = Replace(strInputAmt, "}", 0)
                strInputAmt = 0 - strInputAmt
            Case "J"
                strInputAmt = Replace(strInputAmt, "J", 1)
                strInputAmt = 0 - strInputAmt
            Case "K"
                strInputAmt = Replace(strInputAmt, "K", 2)
                strInputAmt = 0 - strInputAmt
            Case "L"
                strInputAmt = Replace(strInputAmt, "L", 3)
                strInputAmt = 0 - strInputAmt
            Case "M"
                strInputAmt = Replace(strInputAmt, "M", 4)
                strInputAmt = 0 - strInputAmt
            Case "N"
                strInputAmt = Replace(strInputAmt, "N", 5)
                strInputAmt = 0 - strInputAmt
            Case "O"
                strInputAmt = Replace(strInputAmt, "O", 6)
                strInputAmt = 0 - strInputAmt
            Case "P"
                strInputAmt = Replace(strInputAmt, "P", 7)
                strInputAmt = 0 - strInputAmt
            Case "Q"
                strInputAmt = Replace(strInputAmt, "Q", 8)
                strInputAmt = 0 - strInputAmt
            Case "R"
                strInputAmt = Replace(strInputAmt, "R", 9)
                strInputAmt = 0 - strInputAmt
        End Select
        Return strInputAmt

    End Function
    Public Function GetPaxTypefromFB(strFB) As String
        Dim strPaxType As String = "ADL"
        Select Case Len(strFB)
            Case Is < 3
            Case Is < 5
                If Right(strFB, 2) = "CH" Then strPaxType = "CHD"
                If Right(strFB, 2) = "IN" Then strPaxType = "INF"
            Case Else
                If Right(strFB, 2) = "CH" Then strPaxType = "CHD"
                If Right(strFB, 2) = "IN" Then strPaxType = "INF"
                If IsNumeric(Right(strFB, 2)) Then
                    If Mid(strFB, Len(strFB) - 4, 2) = "CH" Then
                        strPaxType = "CHD"
                    ElseIf Mid(strFB, Len(strFB) - 4, 2) = "IN" Then
                        strPaxType = "INF"
                    End If
                End If
        End Select
        Return strPaxType
    End Function
    Public Function SurfaceBreakHotFile(bytSegment As Byte, strInput As String) As String
        ' chua xu ly xong
        Dim i As Byte
        Dim strTempInput As String
        Dim bytSurPos As Byte 'vi tri ngat cua fare basis tuong ung chang surface
        Dim bytAddPos As Byte


        bytSurPos = 0
        bytAddPos = 0
        strTempInput = strInput

        For i = 1 To bytSegment - 1
            If InStr(strTempInput, "+") > 0 Then
                bytSurPos = InStr(strTempInput, "+")
                bytAddPos = bytAddPos + bytSurPos
                strTempInput = Mid(strTempInput, bytSurPos + 1)
            End If
        Next
        Return Mid(strInput, 1, bytAddPos) & "+" & Mid(strInput, bytAddPos + 1)
    End Function
    Public Function ParseIataRloc(strIataRloc As String, ByRef strGds As String, ByRef strRloc As String) As Boolean
        Dim arrBreak() As String = strIataRloc.Split("/")
        If arrBreak(0).Length = 2 Then
            strGds = arrBreak(0)
            strRloc = arrBreak(1)
        Else
            strGds = arrBreak(1)
            strRloc = arrBreak(0)
        End If
        Return True
    End Function
    Public Function AddPastYear(ByVal FromDate As Date, ByVal strCheckedDate As String) _
                    As Date
        ' them nam cho ngay dang DDMMM bang cach so sanh voi ngay chuan
        ' ngay moi trong khoang truoc ngay chuan hoac bang ngay chuan

        Dim strCheckedMonth As String = ""
        Dim bytCheckedDay As Byte
        Dim dteResult As Date

        If Not CheckGdsShortDate(UCase(strCheckedDate)) Then
            Throw New Exception("Invalid date:" & strCheckedDate)
        End If

        bytCheckedDay = Left(strCheckedDate, 2)
        Select Case UCase(Right(strCheckedDate, 3))
            Case "JAN"
                strCheckedMonth = 1
            Case "FEB"
                strCheckedMonth = 2
            Case "MAR"
                strCheckedMonth = 3
            Case "APR"
                strCheckedMonth = 4
            Case "MAY"
                strCheckedMonth = 5
            Case "JUN"
                strCheckedMonth = 6
            Case "JUL"
                strCheckedMonth = 7
            Case "AUG"
                strCheckedMonth = 8
            Case "SEP"
                strCheckedMonth = 9
            Case "OCT"
                strCheckedMonth = 10
            Case "NOV"
                strCheckedMonth = 11
            Case "DEC"
                strCheckedMonth = 12
        End Select
        If Month(FromDate) > strCheckedMonth Then
            dteResult = DateSerial(Year(FromDate), strCheckedMonth, bytCheckedDay)
        End If
        If Month(FromDate) < strCheckedMonth Then
            dteResult = DateSerial(Year(FromDate) - 1, strCheckedMonth, bytCheckedDay)

        End If
        If Month(FromDate) = strCheckedMonth Then
            Select Case bytCheckedDay - DatePart(DateInterval.Day, FromDate)
                Case Is <= 0
                    dteResult = DateSerial(Year(FromDate), strCheckedMonth, bytCheckedDay)
                Case Else
                    dteResult = DateSerial(Year(FromDate) - 1, strCheckedMonth, bytCheckedDay)
            End Select
        End If

        Return dteResult
    End Function
    Public Function CheckGdsShortDate(strCheckedDate As String) As Boolean

        If strCheckedDate.Length <> 5 Or Not IsNumeric(Mid(strCheckedDate, 1, 2)) _
            Or CInt(Mid(strCheckedDate, 1, 2)) > 31 _
            Or InStr("JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC" _
                     , Mid(strCheckedDate, strCheckedDate.Length - 2)) = 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Public Function FormatIataNbr(strIataNbr As String) As String
        Return Replace(Replace(strIataNbr, "-", ""), " ", "")
    End Function
    Public Function ConvertMidtGdsCode(strMidtGdsCode As String) As String
        Select Case strMidtGdsCode
            Case 2, "Sabre"
                Return "1S"
            Case 3, "Galileo International"
                Return "1G"
            Case 4, "Amadeus"
                Return "1A"
            Case 8, "Abacus"
                Return "1B"
            Case 7, "Worldspan"
                Return "1P"
            Case Else
                MsgBox("new GDS code found !" & strMidtGdsCode)
                Return strMidtGdsCode
        End Select
    End Function
    Public Function ConvertMidtDateText2String(intYear As Integer, intMonth As Integer) As String
        Return DateTime2Text(DateSerial(intYear, intMonth, 1))
    End Function
    Public Function Md5Encrypt(sPassword As String) As String
        Dim x As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bs As Byte() = System.Text.Encoding.UTF8.GetBytes(sPassword)
        bs = x.ComputeHash(bs)
        Dim s As New System.Text.StringBuilder()
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower())
        Next
        Return s.ToString()
    End Function
    Public Function CreateFromDate(ByVal dteInputDate As Date) As String
        Return Format(dteInputDate, "dd MMM yy 00:00:00")
    End Function
    Public Function CreateToDate(ByVal dteInputDate As Date) As String
        Return Format(dteInputDate, "dd MMM yy 23:59:00")
    End Function
    Public Function CheckFormatTextBoxEmail(ByRef txtInput As System.Windows.Forms.TextBox _
                                            , Optional blnAllowBlank As Boolean = True) As Boolean
        Dim strName As String = IIf(txtInput.Tag <> "", txtInput.Tag, Mid(txtInput.Name, 4))

        If blnAllowBlank AndAlso txtInput.Text = "" Then
            Return True
        End If
        If Not txtInput.Text.Contains("@") Then
            GoTo Quit
        End If
        Return True
Quit:
        MsgBox("Invalid " & strName)
        txtInput.Focus()
        Return False
    End Function
    Public Function CheckFormatTextBox(ByRef txtInput As System.Windows.Forms.TextBox _
                                        , Optional ByVal intMaxLength As Int16 = 0 _
                                        , Optional ByVal blnNumeric As Boolean = False _
                                         , Optional ByVal intMinLength As Int16 = 0) As Boolean
        Dim strName As String
        If txtInput.Tag = "" Then
            strName = Mid(txtInput.Name, 4)
        Else
            strName = txtInput.Tag
        End If
        If txtInput.Text = "" Then
            MsgBox("Invalid value for " & strName)
            txtInput.Focus()
            Return False
        End If
        If intMaxLength > 0 AndAlso txtInput.Text.Length > intMaxLength Then
            MsgBox("Invalid value for " & strName)
            txtInput.Focus()
            Return False
        End If
        If intMinLength > 0 AndAlso txtInput.Text.Length < intMinLength Then
            MsgBox("Invalid value for " & strName)
            txtInput.Focus()
            Return False
        End If
        If blnNumeric AndAlso Not IsNumeric(txtInput.Text) Then
            MsgBox("Invalid value for " & strName)
            txtInput.Focus()
            Return False
        End If
        Return True
    End Function
    Public Function CheckFormatComboBox(ByRef cboInput As System.Windows.Forms.ComboBox _
                                        , Optional ByVal blnNumeric As Boolean = False _
                                        , Optional ByVal intMinLength As Int16 = 0 _
                                        , Optional ByVal intMaxLength As Int16 = 0) As Boolean
        Dim strName As String
        If cboInput.Tag = "" Then
            strName = Mid(cboInput.Name, 4)
        Else
            strName = cboInput.Tag
        End If

        If (intMaxLength > 0 AndAlso cboInput.Text.Length > intMaxLength) _
            Or (intMinLength > 0 AndAlso cboInput.Text.Length < intMinLength) _
            Or (blnNumeric AndAlso Not IsNumeric(cboInput.Text)) Then
            GoTo Quit
        End If
        Return True
Quit:
        MsgBox("Invalid value for " & strName)
        cboInput.Focus()
        Return False
    End Function
    Public Function CheckFormatIataCode(strIataCode As String) As Boolean
        If strIataCode.Length <> 8 Or Not IsNumeric(strIataCode) Then
            Return False
        ElseIf Mid(strIataCode, 1, 7) Mod 7 <> Mid(strIataCode, 8) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ConvertStr2Groupbox(strValue As String, ByRef grbValues As GroupBox)
        For Each objControl As CheckBox In grbValues.Controls
            If objControl.Name.StartsWith("chk") AndAlso strValue.Contains(Mid(objControl.Name, 4)) Then
                CType(objControl, CheckBox).Checked = True
            Else
                objControl.Checked = False
            End If

            'If objControl.Name.StartsWith("chk") AndAlso strValue.Contains(Mid(objControl.Name, 4)) Then
            '    CType(objControl, CheckBox).Checked = True
            'End If
        Next
    End Sub
    Public Function ConvertGroupbox2Str(grbValues As GroupBox) As String
        Dim lstResults As New List(Of String)
        For Each objControl As Control In grbValues.Controls
            If CType(objControl, CheckBox).Checked Then
                lstResults.Add(Mid(objControl.Name, 4))
            End If
        Next
        Return Join(lstResults.ToArray, "_")
    End Function
    Public Function ConvertSecoDate(strSecoDate As String) As String
        If strSecoDate = "" Then
            Return ""
        Else
            Return Format(DateSerial(Mid(strSecoDate, 16, 2), Mid(strSecoDate, 10, 2), Mid(strSecoDate, 13, 2)), "dd-MMM-yy ") _
                & Mid(strSecoDate, 1, 5)
        End If
    End Function
    Public Function AddFromDatesMonthly(ByRef cboDate As ComboBox, intBackwardMonth As Integer, intForwardMonth As Integer) As Boolean
        Dim i As Integer
        Dim dteFrom As Date

        For i = intForwardMonth To 1 Step -1
            dteFrom = DateAdd(DateInterval.Month, i, Now)
            dteFrom = DateSerial(Year(dteFrom), Month(dteFrom), 1)
            cboDate.Items.Add(Format(dteFrom, "dd MMM yy"))
        Next

        For i = 0 To intBackwardMonth
            dteFrom = DateAdd(DateInterval.Month, -i, Now)
            dteFrom = DateSerial(Year(dteFrom), Month(dteFrom), 1)
            cboDate.Items.Add(Format(dteFrom, "dd MMM yy"))
        Next

        
        Return True
    End Function
    Public Function AddToDatesQuartely(ByRef cboDate As ComboBox) As Boolean
        Dim i As Integer

        For i = Year(Now) - 1 To Year(Now) + 5
            cboDate.Items.Add(Format(DateSerial(i, 3, 31), "dd MMM yy"))
            cboDate.Items.Add(Format(DateSerial(i, 6, 30), "dd MMM yy"))
            cboDate.Items.Add(Format(DateSerial(i, 9, 30), "dd MMM yy"))
            cboDate.Items.Add(Format(DateSerial(i, 12, 31), "dd MMM yy"))
        Next

        Return True
    End Function
    Public Function AddToDatesMonthly(ByRef cboDate As ComboBox) As Boolean
        Dim i As Integer

        For i = -3 To 12
            cboDate.Items.Add(Format(DateSerial(Now.Year, Now.Month, 1).AddMonths(i).AddDays(-1), "dd MMM yy"))

        Next

        Return True
    End Function
    Public Function AdjustDatagridviewColumnSize(ByRef dgView As DataGridView, intIncrease As Integer) As Boolean
        With dgView
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AutoResizeColumns()
            '.Refresh()
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            For Each objColumn As DataGridViewColumn In .Columns
                objColumn.Width = objColumn.Width + intIncrease
            Next
        End With
        Return True
    End Function
    Public Function GetValidDate4Incentive(intYear As String, strTimeFrame As String, intPeriod As String) As String
        
        Dim strValidDate As String = ""
        Select Case strTimeFrame
            Case "Month"
                strValidDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
            Case "Quarter"
                strValidDate = CreateFromDate(DateSerial(intYear, intPeriod * 3 - 2, 1))
            Case "HalfYear"
                strValidDate = CreateFromDate(DateSerial(intYear, intPeriod * 6 - 2, 1))
            Case "Year"
                strValidDate = CreateFromDate(DateSerial(intYear, intPeriod * 12 - 2, 1))

        End Select

        Return strValidDate
    End Function
    Public Function CreateFromDate4Period(intYear As String, strTimeFrame As String, intPeriod As String) As String

        Dim strValidDate As String = ""
        Select Case strTimeFrame
            Case "Month"
                strValidDate = CreateFromDate(DateSerial(intYear, intPeriod, 1))
            Case "Quarter"
                strValidDate = CreateFromDate(DateSerial(intYear, intPeriod * 3 - 2, 1))
            Case "HalfYear"
                strValidDate = CreateFromDate(DateSerial(intYear, intPeriod * 6 - 5, 1))
            Case "Year"
                strValidDate = CreateFromDate(DateSerial(intYear, 1, 1))
        End Select

        Return strValidDate
    End Function
    Public Function CreateToDate4Period(intYear As String, strTimeFrame As String, intPeriod As String) As String

        Dim strValidDate As String = ""
        Select Case strTimeFrame
            Case "Month"
                strValidDate = CreateToDate(DateSerial(intYear, intPeriod, 1))
                strValidDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(strValidDate)))
            Case "Quarter"
                strValidDate = CreateToDate(DateSerial(intYear, intPeriod * 3 - 2, 1))
                strValidDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 3, CDate(strValidDate)))
            Case "HalfYear"
                strValidDate = CreateToDate(DateSerial(intYear, intPeriod * 6 - 5, 1))
                strValidDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 6, CDate(strValidDate)))
            Case "Year"
                strValidDate = CreateToDate(DateSerial(intYear, 1, 1))
                strValidDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 12, CDate(strValidDate)))
        End Select

        Return strValidDate
    End Function
    Public Function AutoCorrectInteger(ByRef strNumber As String) As Boolean
        strNumber = strNumber.Replace(" ", "")
        strNumber = strNumber.Replace(",", "")
        Select Case UCase(Mid(strNumber, strNumber.Length))
            Case "K"
                strNumber = strNumber & "000"
            Case "M"
                strNumber = strNumber & "000000"
        End Select
        Return True
    End Function
    Public Function HideGridColumns(ByRef objDg As DataGridView, strColumns As String) As Boolean
        Dim arrColumnNames As String() = strColumns.Split("|")
        Dim strColumnName As String = String.Empty
        Try
            For Each strColumnName In arrColumnNames
                objDg.Columns(strColumnName).Visible = False
            Next
            Return True
        Catch ex As Exception
            MsgBox("Unable to find " & strColumnName & " in datagridview " & objDg.Name)
            Return False
        End Try

    End Function
    Public Function Table2Excel(tblInput As DataTable, Optional strSheetName As String = "") As Boolean
        If tblInput.Rows.Count > 0 Then
            Dim objExcel As New Microsoft.Office.Interop.Excel.Application
            Dim objWsh As Microsoft.Office.Interop.Excel.Worksheet
            Dim objWbk As Microsoft.Office.Interop.Excel._Workbook
            Dim lstQuerries As New List(Of String)
            Dim strLastColumn As String = ConvertExcelColumnNbr2Letter(tblInput.Columns.Count)

            objExcel.Visible = False
            objWbk = objExcel.Workbooks.Add
            objWsh = objWbk.ActiveSheet
            With objWsh
                For i = 0 To tblInput.Columns.Count - 1
                    .Cells(1, i + 1) = tblInput.Columns(i).ColumnName
                Next

                For i = 0 To tblInput.Rows.Count - 1
                    objWsh.Range("A" & i + 2 & ":" & strLastColumn & i + 2).Value = tblInput.Rows(i).ItemArray
                Next
                .Columns("A:" & strLastColumn).AUTOFIT()
            End With
            If strSheetName <> "" Then
                objWsh.Name = strSheetName
            End If
            objExcel.Visible = True
        End If

        Return True
    End Function
    Function ConvertExcelColumnNbr2Letter(iCol As Integer) As String
        Dim iAlpha As Integer
        Dim iRemainder As Integer
        Dim strColumn As String = String.Empty
        iAlpha = Int(iCol / 27)
        iRemainder = iCol - (iAlpha * 26)
        If iAlpha > 0 Then
            strColumn = Chr(iAlpha + 64)
        End If
        If iRemainder > 0 Then
            strColumn = strColumn & Chr(iRemainder + 64)
        End If
        Return strColumn
    End Function
    Public Function CalcVat(blnGetInvoice As Boolean, decVnd As Decimal) As Integer
        If blnGetInvoice Then
            Return Math.Round(decVnd / 9, 0)
        Else
            Return 0
        End If
    End Function

    Public Function ResizeDataGridViewColumns(ByRef dgInput As DataGridView, intIncrease As Integer) As Boolean

        With dgInput
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            For Each objColumn As DataGridViewColumn In dgInput.Columns
                objColumn.Width = objColumn.Width + intIncrease
            Next
        End With
        Return True
    End Function
    Public Function GetPeriod4Customer(strContactTimeFrame As String _
                        , intContactPeriod As Integer _
                        , strCustomerTimeFrame As String) As Integer
        If strContactTimeFrame = strCustomerTimeFrame Then
            Return intContactPeriod
        End If
        Select Case strCustomerTimeFrame
            Case "Quarter"
                If strContactTimeFrame = "Month" Then
                    Return (intContactPeriod + 2) \ 3
                Else
                    Return 0
                End If
            Case "HalfYear"
                If strContactTimeFrame = "Month" Then
                    Return (intContactPeriod + 5) \ 6
                ElseIf strContactTimeFrame = "Quarter" Then
                    Return (intContactPeriod + 1) \ 2
                End If
            Case "Year"
                Return 1
            Case Else
                Return 0
        End Select

    End Function
End Module
