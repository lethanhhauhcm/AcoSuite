Imports System.Text
Imports Microsoft.Win32
Imports System.IO

Public Class cpublic

#Region "[Ma hoa va giai ma]"

    Public Function f_MaHoa(ByVal sKhoa As String, ByVal sMatKhau As String) As String
        Dim result As String = ""
        Try
            Dim utf16 As Byte() = Encoding.Unicode.GetBytes(sKhoa + "2010" + sMatKhau)
            result = Convert.ToBase64String(utf16)
        Catch ex As Exception
            MessageBox.Show("Không thể mã hóa", "Lưu ý")
        End Try
        Return result
    End Function

    Public Function f_GiaiMa(ByVal sKhoa As String, ByVal sMatKhau As String) As String
        Dim result As String = ""
        Try
            If (sKhoa = "") Then
                Dim utf As Byte() = Convert.FromBase64String(sMatKhau)
                result = Encoding.Unicode.GetString(utf)
            Else
                Dim utf As Byte() = Convert.FromBase64String(sMatKhau)
                result = Encoding.Unicode.GetString(utf).Replace(sKhoa + "2010", "")
            End If

        Catch ex As Exception
            Return ""

        End Try
        Return result

    End Function

#End Region

#Region "[Registry]"

    Public Function f_RegistrySet(ByVal pKeyName As String, ByVal pValue As Object) As Boolean
        Try
            Dim sk1 As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Tcpip\COMP")
            sk1.SetValue(pKeyName.ToUpper(), pValue)
            Return True

        Catch ex As Exception
            MessageBox.Show("Không thể lưu vào Registry " + ex.ToString(), "Lưu ý")
            Return False
        End Try
    End Function

    Public Function f_RegistryGet(ByVal pKeyName As String) As String
        Try
            Dim sk1 As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Tcpip\COMP")
            If (sk1 IsNot Nothing) Then
                Return sk1.GetValue(pKeyName.ToUpper()) + ""
            End If
        Catch ex As Exception
            MessageBox.Show("Không thể lấy value Registry " + ex.ToString(), "Lứu ý")
        End Try
        Return Nothing
    End Function

#End Region

#Region "[chuyen so thanh chu]"

    Public Function f_ChuyenSo_ThanhChu(ByVal pstrNum As String) As String
        Dim tempgfReadNumVie As String = Nothing
        Dim bytX As Integer = 0
        Dim bytsolan As Integer = 0
        Dim intcount As Integer = 0

        Dim strcum As String = Nothing
        Dim ArrStrdolon As String() = {"", "", " ngàn", " triệu", " tỷ", " ngàn", " triệu", " tỷ tỷ", " ngàn", " triệu", " tỷ tỷ tỷ"}

        Dim blntri As Boolean = False
        Dim blndoclai As Boolean = False

        tempgfReadNumVie = ""

        Try
            pstrNum = System.Convert.ToInt64(pstrNum).ToString("####").Trim(" "c)
            bytX = pstrNum.Length Mod 3
            pstrNum = Convert.ToString((If((bytX > 0), New [String](" "c, 3 - bytX), ""))) & pstrNum
            bytsolan = pstrNum.Length / 3

            If bytsolan > 10 Then
                Return tempgfReadNumVie
            End If

            For intcount = 1 To pstrNum.Length - 2 Step 3
                strcum = pstrNum.Substring(intcount - 1, 3)
                If Convert.ToInt32(strcum) > 0 Then
                    tempgfReadNumVie = (tempgfReadNumVie & f_Doc3so(strcum, blntri)) + ArrStrdolon(bytsolan)
                    blntri = True
                Else
                    If (bytsolan - 1) Mod 3 = 0 Then
                        'INSTANT C# NOTE: The following VB 'Select Case' included range-type or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
                        '                      Select Case intcount
                        'ORIGINAL LINE: Case Is > 9
                        If intcount > 9 Then
                            blndoclai = Convert.ToInt32(pstrNum.Substring(intcount - 6 - 1, 9)) > 0
                        Else
                            'ORIGINAL LINE: Case Else
                            blndoclai = Convert.ToInt32(pstrNum.Substring(0, intcount + 2)) > 0
                        End If
                        If blndoclai Then
                            tempgfReadNumVie = tempgfReadNumVie + ArrStrdolon(bytsolan)
                        End If
                    End If
                End If
                bytsolan = bytsolan - 1
            Next

            tempgfReadNumVie = tempgfReadNumVie.TrimStart(" "c)
            tempgfReadNumVie = tempgfReadNumVie.Substring(0, 1).ToUpper() + tempgfReadNumVie.Substring(1)
            'MessageBox.Show(mArrStrFrmMess(2) + System.Environment.NewLine + " mdlReport - gfReadNumVie " + System.Environment.NewLine + ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
        Catch generatedExceptionName As Exception

        Finally
        End Try
        Return tempgfReadNumVie
    End Function

    Private Function f_Doc3so(ByVal pstrNum As String, ByVal pblnle As Boolean) As String
        Dim tempfDoc3so As String = Nothing
        Dim bytNum1 As Byte = 0
        Dim bytNum2 As Byte = 0
        Dim bytNum3 As Byte = 0
        Dim ArrStrchu As String() = {"", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín"}

        tempfDoc3so = ""

        Try
            pstrNum = System.Convert.ToInt64(pstrNum).ToString("000")
            bytNum1 = Convert.ToByte(pstrNum.Substring(0, 1))
            bytNum2 = Convert.ToByte(pstrNum.Substring(1, 1))
            bytNum3 = Convert.ToByte(pstrNum.Substring(pstrNum.Length - 1))
            tempfDoc3so = (If((bytNum1 > 0), ArrStrchu(bytNum1) + " trăm", (If(pblnle, " không trăm", ""))))
            pblnle = (If((bytNum2 > 0), False, (If((bytNum3 > 0), (bytNum1 > 0) Or (bytNum1 = 0 AndAlso pblnle), False))))
            tempfDoc3so = tempfDoc3so & Convert.ToString((If((bytNum2 > 1), ArrStrchu(bytNum2) + " mươi", (If((bytNum2 = 1), " mười", (If(pblnle, " lẻ", "")))))))
            tempfDoc3so = tempfDoc3so & Convert.ToString((If((bytNum2 > 1 AndAlso bytNum3 = 1), " mốt", (If((bytNum2 > 0 AndAlso bytNum3 = 5), " lăm", ArrStrchu(bytNum3))))))

        Catch generatedExceptionName As Exception
        Finally
        End Try
        Return tempfDoc3so
    End Function

#End Region

    Public Sub f_ExitProcess(ByVal pProcessName)
        Dim prs As Process() = Process.GetProcesses()
        For Each pr As Process In prs
            If (pr.ProcessName = pProcessName) Then
                pr.Kill()
            End If
        Next
    End Sub


End Class
