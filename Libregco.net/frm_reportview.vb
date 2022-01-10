Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_reportView
    Friend ObjRpt As New ReportDocument
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Friend IDReport, ReportName, ReportPath As String

    Private Sub frm_reportView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        HideReportTab(CrystalViewer)

        If Me.Owner.Name = frm_ajustes_tecnicos.Name Then
            Me.Size = New Size(755, 1016)
            Me.CenterToScreen()
        Else
            Me.CenterToParent()
        End If


    End Sub

    Private Sub frm_reportView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.Owner.Name = frm_ajustes_tecnicos.Name Then
            frm_ajustes_tecnicos.Activate()
        End If
        ObjRpt.Close()
        ObjRpt.Dispose()
    End Sub

    Private Sub frm_reportView_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

    Sub HideReportTab(ByVal crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer)
        Dim control As Control
        Dim controlInPage As Control
        Dim tabs As TabControl

        For Each control In crViewer.Controls
            If TypeOf control Is CrystalDecisions.Windows.Forms.PageView Then
                For Each controlInPage In control.Controls
                    If TypeOf controlInPage Is TabControl Then
                        tabs = CType(controlInPage, TabControl)
                        tabs.ItemSize = New Size(0, 1)
                        tabs.SizeMode = TabSizeMode.Fixed
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Contador.Tick
        Dim UNCVirtualUNC As String = TakeReportViewImage(CrystalViewer, IDReport, ReportName)

        If System.IO.File.Exists(UNCVirtualUNC) Then

            If Me.Owner.Name = frm_ajustes_tecnicos.Name Then
                Dim wFile As System.IO.FileStream
                wFile = New FileStream(UNCVirtualUNC, FileMode.Open, FileAccess.Read)
                frm_ajustes_tecnicos.DgvReportes.CurrentRow.Cells(0).Value = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
            End If

            Contador.Enabled = False

            Dim NotifyUsers As New NotifyIcon

            NotifyUsers.Visible = False
            NotifyUsers.Icon = My.Resources.Libregco_Icon
            NotifyUsers.BalloonTipIcon = ToolTipIcon.Info

            With NotifyUsers
                .Visible = True
                .Text = "Captura de visualización"
                .BalloonTipTitle = "Se ha tomado una captura del reporte " & ReportName
                .BalloonTipText = ReportPath
                .ShowBalloonTip(3)
                .Visible = False
            End With

            NotifyUsers.Dispose()

        End If

    End Sub

End Class