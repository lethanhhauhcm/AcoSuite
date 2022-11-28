Public Class clsCustomer
    Private mintRecId As Integer
    Private mstrShortName As String
    Private mstrFullNameGB As String
    Private mstrFullNameVN As String
    Private mstrRegion As String
    Private mstrPIC As String

    '^_^20221109 add by 7643 -b-
    Property CustID() As Integer
        Get
            Return mintRecId
        End Get
        Set(ByVal iCustID As Integer)
            mintRecId = iCustID
            mstrFullNameVN = ""
            mstrShortName = ""
            If mintRecId = 0 Then Exit Property
            Dim dTable As DataTable

            dTable = GetDataTable("select ShortName,AccountNameVN FullNameVN from DATA1A_Customers " &
                                  "where status<>'XX' and recID=" & mintRecId)
            For i As Int16 = 0 To dTable.Rows.Count - 1
                mstrShortName = dTable.Rows(i)("ShortName")
                mstrFullNameVN = dTable.Rows(i)("FullNameVN")
                mstrFullNameVN = mstrFullNameVN.Replace("'", "")
            Next
        End Set
    End Property
    '^_^20221109 add by 7643 -e-

    Public Property Recid As Integer
        Get
            Return mintRecId
        End Get
        Set(value As Integer)
            mintRecId = value
        End Set
    End Property
    Public Property ShortName As String
        Get
            Return mstrShortName
        End Get
        Set(value As String)
            mstrShortName = value
        End Set
    End Property
    Public Property FullNameGB As String
        Get
            Return mstrFullNameGB
        End Get
        Set(value As String)
            mstrFullNameGB = value
        End Set
    End Property
    Public Property FullNameVN As String
        Get
            Return mstrFullNameVN
        End Get
        Set(value As String)
            mstrFullNameVN = value
        End Set
    End Property
    Public Property Region As String
        Get
            Return mstrRegion
        End Get
        Set(value As String)
            mstrRegion = value
        End Set
    End Property
    Public Property PIC As String
        Get
            Return mstrPIC
        End Get
        Set(value As String)
            mstrPIC = value
        End Set
    End Property
End Class
