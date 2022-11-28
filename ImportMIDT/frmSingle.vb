Imports System.Data.SqlClient
Public Class frmSingle
    Protected FValid As Boolean = True
    Protected FDsMain As New DataSet
    Protected FSdaMain As New SqlDataAdapter
    Protected FSQLMain, FSQLOrderMain As String
    Protected FclsTvcs As clsTvcs

#Region "Custom Method"
    Protected Overridable Sub Env()
        FclsTvcs = pobjSql
        llbEdit.Enabled = False
        llbDelete.Enabled = False
        Loadmain(True)
        LoadCombo()
        DefaultControl(tpSearch)
    End Sub

    Protected Overridable Sub FormatDgvMain()
        '
    End Sub

    Protected Overridable Sub Loadmain(Optional xIni As Boolean = False)
        Dim mSQL As String
        If FSQLMain = "" Then
            Exit Sub
        End If

        mSQL = FSQLMain
        If xIni Then
            mSQL &= IIf(FSQLMain.ToUpper.Contains("WHERE"), "and ", "where ") & "1=2 "
        End If

        FDsMain = New DataSet
        FillDatagridview(FDsMain, FSdaMain, mSQL & FSQLOrderMain, dgvMain, FclsTvcs.Connection)
        FormatDgvMain()
    End Sub

    Protected Overridable Sub DefaultValue(Optional xDgv As DataGridView = Nothing)
        If xDgv Is Nothing Then
            DefaultControl(tpInput)
        Else
            DefaultControl(tpInput, xDgv)
        End If
    End Sub

    Protected Overridable Function CheckValue() As Boolean
        '
        Return True
    End Function

    Protected Overridable Sub UpdateMain()
        '
    End Sub

    Protected Overridable Sub DeleteMain()
        '
    End Sub

    Protected Sub ChangeMainTab(xTabpage As TabPage)
        tcMain.TabPages.Clear()
        tcMain.TabPages.Add(xTabpage)
    End Sub

    Protected Overridable Sub DoMyCancel()
        ChangeMainTab(tpList)
        FDsMain.RejectChanges()
    End Sub

    Protected Overridable Sub DoMyOK()
        ChangeMainTab(tpList)
        UpdateMain()
        Loadmain()
    End Sub

    Protected Overridable Sub DoMySelect()
        llbEdit.Enabled = True
        llbDelete.Enabled = True
    End Sub

    Protected Overridable Sub DoMyDelete()
        DeleteMain()
        Loadmain()
    End Sub

    Protected Overridable Sub LoadCombo()
        '
    End Sub
#End Region

    Private Sub frmSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Env()
    End Sub

    Private Sub llbOK_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbOK.LinkClicked
        If Not CheckValue() Then
            Exit Sub
        End If

        DoMyOK()
    End Sub

    Private Sub llbEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbEdit.LinkClicked
        ChangeMainTab(tpInput)
        DefaultValue(dgvMain)
    End Sub

    Private Sub llbDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbDelete.LinkClicked
        If MsgBox("Delete this row?", vbYesNo) = vbNo Then
            Exit Sub
        End If
        DoMyDelete()
    End Sub

    Private Sub dgvMain_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMain.SelectionChanged
        DoMySelect()
    End Sub

    Private Sub llbSearch_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSearch.LinkClicked
        ChangeMainTab(tpSearch)
    End Sub

    Private Sub llbReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbReset.LinkClicked
        DefaultControl(tpSearch)
    End Sub

    Private Sub llbCancel_2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCancel_2.LinkClicked
        DoMyCancel()
    End Sub

    Private Sub llbSearch_2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbSearch_2.LinkClicked
        ChangeMainTab(tpList)
        Loadmain()
    End Sub

    Private Sub llbAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbAdd.LinkClicked
        ChangeMainTab(tpInput)
        DefaultValue()
    End Sub

    Private Sub llbCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCancel.LinkClicked
        DoMyCancel()
    End Sub
End Class