Imports Microsoft.Office.Interop
Public Class frmIncentiveReport

    Private Sub frmIncentiveReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim strQuerry As String
        Dim strQuerry4Contact As String
        Dim strQuerry4Customer As String
        Dim strQuerry4Adhoc As String

        Dim tblIncentive As System.Data.DataTable
        strQuerry4Customer = "select i.Unit,i.ShortName, i.ContactId,'' as FullNameGB4Contact, IncType" _
                    & ", i.Object, Bkg, i.VND" _
                    & ", i.OfferID, FormulaID, CalcYear, CalcQuarter, BookYear, i.TimeFrame, Period,ManualCheckRequired " _
                    & " FROM Data1A_IncentiveCalc i" _
                    & " Left join Data1A_IncentiveFormula f on i.FormulaId=f.RecId" _
                    & " Left join Data1A_IncentiveOffer o on i.OfferId=o.OfferId" _
                    & " where i.Status='OK' and i.object='Customer'"

        strQuerry4Contact = "select i.Unit,i.ShortName, i.ContactId,c.FullNameGB as FullNameGB4Contact, IncType" _
                    & ", i.Object, Bkg, i.VND" _
                    & ", i.OfferID, FormulaID,CalcYear,CalcQuarter, BookYear, i.TimeFrame, Period,ManualCheckRequired " _
                    & " FROM Data1A_IncentiveCalc i" _
                    & " Left join Data1A_Contacts c on i.ContactId=c.ContactId" _
                    & " Left join Data1A_IncentiveOffer o on i.OfferId=o.OfferId" _
                    & " Left join Data1A_IncentiveFormula f on i.FormulaId=f.RecId" _
                    & " where i.Status='OK' and i.object='Contact' and c.Status<>'XX'"

        If cboBookYear.Text <> "" Then
            strQuerry4Customer = strQuerry4Customer & " and BookYear=" & cboBookYear.Text
            strQuerry4Contact = strQuerry4Contact & " and BookYear=" & cboBookYear.Text
        End If
        If cboCalcQuarter.Text <> "" Then
            strQuerry4Customer = strQuerry4Customer & " and CalcQuarter=" & cboCalcQuarter.Text
            strQuerry4Contact = strQuerry4Contact & " and CalcQuarter=" & cboCalcQuarter.Text
        End If

        Select Case cboUnit.Text
            Case "Segment"
                strQuerry4Customer = strQuerry4Customer & " and Unit<>'Ticket'"
                strQuerry4Contact = strQuerry4Contact & " and Unit<>'Ticket'"
            Case "Ticket"
                strQuerry4Customer = strQuerry4Customer & " and Unit='Ticket'"
                strQuerry4Contact = strQuerry4Contact & " and Unit='Ticket'"
        End Select

        Select Case cboObject.Text
            Case "Customer"
                strQuerry = strQuerry4Customer
            Case "Contact"
                strQuerry = strQuerry4Contact
            Case Else
                strQuerry = strQuerry4Customer & " union " & strQuerry4Contact
        End Select

        If cboUnit.Text <> "Ticket" Then
            strQuerry4Adhoc = "select 'Segment',i.ShortName, i.ContactId,isnull(c.FullNameGB,'') as FullNameGB4Contact, 'Adhoc'" _
                    & ", i.Object, 0, i.VND" _
                    & ", i.RecID, 0,BookYear,CalcQuarter, BookYear, i.TimeFrame, Period,'False'" _
                    & " FROM Data1A_IncentiveAdhoc i" _
                    & " Left join Data1A_Contacts c on i.ContactId=c.ContactId and c.Status<>'XX'" _
                    & " where i.Status='OK' "
            strQuerry = strQuerry & " UNION " & strQuerry4Adhoc
        End If

        strQuerry = strQuerry & " order by ShortName,CalcYear,CalcQuarter,BookYear,TimeFrame,Period,FullNameGB4Contact,Unit"

        tblIncentive = pobjSql.GetDataTable(strQuerry)
        If tblIncentive.Rows.Count > 0 Then
            Dim objExcel As New Microsoft.Office.Interop.Excel.Application
            Dim objWsh As Excel.Worksheet
            Dim objWbk As Excel._Workbook
            Dim lstQuerries As New List(Of String)

            objExcel.Visible = True
            objWbk = objExcel.Workbooks.Add
            objWsh = objWbk.ActiveSheet
            With objWsh
                For i = 0 To tblIncentive.Columns.Count - 1
                    .Cells(1, i + 1) = tblIncentive.Columns(i).ColumnName
                Next

                For i = 0 To tblIncentive.Rows.Count - 1
                    objWsh.Range("A" & i + 2 & ":O" & i + 2).Value = tblIncentive.Rows(i).ItemArray
                Next
                .Columns("A:O").AUTOFIT()
            End With
            Me.Dispose()
        End If
        LogReport("AcoSuite", "IncentiveReport", pobjUser.UserName, pobjUser.City)
    End Sub
End Class