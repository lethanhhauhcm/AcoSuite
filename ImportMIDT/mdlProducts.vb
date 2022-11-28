Module mdlProducts
    Public Function GetProductOffers(strFromDate As String, strToDate As String _
                                     , Optional strProductName As String = "" _
                                    , Optional strShortName As String = "") As DataTable
        Dim tblOffers As DataTable
        Dim strQuerry As String

        strQuerry = "Select o.*,c.RecId as Priceid,Cur,Amount,Formula,NbrOfUnit" _
                    & ",Unit,Conditions,MinAmount,Occurrence,GetInvoice " _
                    & " from data1a_ProductOffer o" _
                    & " left join Data1a_Misc m on m.Val=o.OfferId " _
                    & " left join Data1a_ProductCosts c on c.RecId=m.Val1 " _
                    & " where m.CAT='ProductOfferPrice' and o.Status<>'xx'" _
                    & " and o.Region='" & pobjUser.Region _
                    & "' and o.ValidTo >='" & strFromDate _
                    & "' and o.ValidFrom <='" & strToDate _
                    & "' and c.Status<>'XX'" _
                    & " and ChargedUpTo<='" & strFromDate & "'"

        If strProductName <> "" Then
            strQuerry = strQuerry & " and o.ProductName='" & strProductName & "'"
        End If
        If strShortName <> "" Then
            strQuerry = strQuerry & " and ShortName='" & strShortName & "'"
        End If
        strQuerry = strQuerry & " ORDER BY o.ShortName,c.NbrOfUnit desc"
        tblOffers = pobjSql.GetDataTable(strQuerry)

        Return tblOffers
    End Function
End Module
