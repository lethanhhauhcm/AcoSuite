Imports System.Data.SqlClient
Public Class frmDouble
    Protected FDsBody As New DataSet
    Protected FSdaBody As New SqlDataAdapter
    Protected FID, FSQLBody, FSQLOrderBody As String
#Region "Custom method"
    Protected Overridable Sub FormatDgvBody()
        '
    End Sub

    Protected Overridable Sub LoadBody(xID As Integer)
        If FSQLBody = "" Then
            Exit Sub
        End If

        FDsBody = New DataSet
        FillDatagridview(FDsBody, FSdaBody, FSQLBody & FSQLOrderBody, dgvBody, FclsTvcs.Connection)
        FormatDgvBody()
    End Sub

    Protected Overrides Sub Env()
        MyBase.Env()
        LoadBody(0)
        DefaultControl(pnFoot, Nothing, True)
        'ChangeMainTab(tpList)
    End Sub

    Protected Overrides Sub DefaultValue(Optional xDgv As DataGridView = Nothing)
        MyBase.DefaultValue(xDgv)
        If xDgv Is Nothing Then
            LoadBody(0)
            DefaultControl(pnFoot, Nothing, True)
        End If
    End Sub

    Protected Overrides Sub DoMyCancel()
        FDsBody.RejectChanges()
        MyBase.DoMyCancel()
        DefaultFoot()
    End Sub

    Protected Overridable Sub UpdateBody()
        '
    End Sub

    Protected Overrides Sub DoMyOK()
        UpdateBody()
        MyBase.DoMyOK()
        DefaultBody()
        DefaultFoot()
    End Sub

    Protected Overridable Sub DefaultBody()
        If dgvMain.CurrentRow IsNot Nothing Then
            LoadBody(FID)
        Else
            LoadBody(0)
        End If
    End Sub

    Private Sub DefaultFoot()
        If dgvMain.CurrentRow IsNot Nothing Then
            DefaultControl(pnFoot, dgvMain)
        Else
            DefaultControl(pnFoot, Nothing, True)
        End If
    End Sub

    Protected Overrides Sub DoMySelect()
        MyBase.DoMySelect()
        LoadBody(FID)
        DefaultControl(pnFoot, dgvMain)
    End Sub

    Protected Overridable Sub DeleteBody()
        '
    End Sub

    Protected Overrides Sub DoMyDelete()
        DeleteBody()
        MyBase.DoMyDelete()
        DefaultBody()
        DefaultFoot()
    End Sub

    Private Sub PanelVisible(xVisible As Boolean)
        pnBody.Visible = xVisible
        pnFoot.Visible = xVisible
        If Not xVisible Then
            pnMain.Dock = DockStyle.Fill
        Else
            pnMain.Dock = DockStyle.Top
        End If
    End Sub

    Protected Overridable Sub DoMyBodySelect()
        '
    End Sub

#End Region

    Private Sub llbSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSearch.LinkClicked
        PanelVisible(False)
    End Sub

    Private Sub dgvBody_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBody.SelectionChanged
        DoMyBodySelect()
    End Sub

    Private Sub llbSearch_2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSearch_2.LinkClicked
        DefaultBody()
        DefaultFoot()
        PanelVisible(True)
    End Sub

    Private Sub llbCancel_2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCancel_2.LinkClicked
        PanelVisible(True)
    End Sub
End Class
