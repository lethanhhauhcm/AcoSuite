Public Class frmSelectMonthYear
    Private mintBookMonth As Integer
    Private mintBookYear As Integer
    Private mstrStartDate As String
    Private mstrEndDate As String
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        mintBookMonth = cboBookMonth.Text
        mintBookYear = cboBookYear.Text
        mstrStartDate = CreateFromDate(DateSerial(mintBookYear, mintBookMonth, 1))
        mstrStartDate = CreateToDate(DateSerial(mintBookYear, mintBookMonth, 1).AddMonths(1).AddDays(-1))
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Public Property BookMonth As Integer
        Get
            Return mintBookMonth
        End Get
        Set(value As Integer)
            mintBookMonth = value
        End Set
    End Property
    Public Property BookYear As Integer
        Get
            Return mintBookYear
        End Get
        Set(value As Integer)
            mintBookYear = value
        End Set
    End Property
    Public Property StartDate As String
        Get
            Return mstrStartDate
        End Get
        Set(value As String)
            mstrStartDate = value
        End Set
    End Property
    Public Property EndDate As String
        Get
            Return mstrEndDate
        End Get
        Set(value As String)
            mstrEndDate = value
        End Set
    End Property
    Private Sub frmSelectMonthYear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If Now.Month = 1 Then
        '    cboBookMonth.Text = 12
        '    cboBookYear.Text = Now.Year - 1
        'Else
        cboBookMonth.Text = Now.Month
        cboBookYear.Text = Now.Year
        'End If
    End Sub
End Class