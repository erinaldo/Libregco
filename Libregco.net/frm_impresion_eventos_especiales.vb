Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_impresion_eventos_especiales
    Friend ReportPath, IDTransaccion, IDEvento As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim ObjRpt As New ReportDocument

    Private Sub frm_impresion_eventos_especiales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frm_inicio.chkAutomaticPrintEventsTickets.Checked = True Then
            chkImpresionAutomatica.Checked = True
        End If

        Dim OpenedEvents As Integer = 0
        For Each frm As Form In My.Application.OpenForms
            If frm.Name.Contains("eventos_especiales") Then
                OpenedEvents = OpenedEvents + 1
            End If
        Next

        If OpenedEvents = 1 Then
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        ElseIf OpenedEvents > 1 Then
            Dim HeightLocation As Integer = Screen.PrimaryScreen.WorkingArea.Height
            For Each frm As Form In My.Application.OpenForms
                If frm.Name.Contains("eventos_especiales") Then
                    HeightLocation = HeightLocation - frm.Height - 3
                End If
            Next
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, HeightLocation)
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frm_impresion_eventos_especiales_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnClose.PerformClick()
        End If
    End Sub

    Sub FillInstaledPrinters()
        For Each pkInstalledPrinters As String In PrinterSettings.InstalledPrinters
            CbxInstalledPrinters.Items.Add(pkInstalledPrinters)
        Next

        If CbxInstalledPrinters.Items.Count > 0 Then
            CbxInstalledPrinters.SelectedIndex = 0
        End If
    End Sub

    Private Sub frm_impresion_eventos_especiales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim HeightLocation As Integer = Screen.PrimaryScreen.WorkingArea.Height
        For Each frm As Form In My.Application.openforms
            If frm.Name.Contains("eventos_especiales") Then
                HeightLocation = HeightLocation - frm.Height - 3
                frm.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - frm.Width, HeightLocation)
            End If
        Next
    End Sub

    Private Sub chkImpresionAutomatica_CheckedChanged(sender As Object, e As EventArgs) Handles chkImpresionAutomatica.CheckedChanged
        frm_inicio.chkAutomaticPrintEventsTickets.Checked = chkImpresionAutomatica.Checked
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            ObjRpt.Close()
            ObjRpt.Dispose()
            ObjRpt = New ReportDocument

            If TypeConnection.Text = 1 Then
                ObjRpt.Load("\\" & PathServidor.Text & ReportPath)
            Else
                ObjRpt.Load("C:" & ReportPath.Replace("\Libregco\Libregco.net", ""))
            End If

            Me.Cursor = Cursors.WaitCursor

            crParameterDiscreteValue.Value = IDTransaccion
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = IDEvento
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEvento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim Settings As New PrinterSettings
            Dim PrinterDefault As String = Settings.PrinterName

            ObjRpt.SummaryInfo.ReportTitle = "Boletas" & " " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            ObjRpt.SummaryInfo.ReportAuthor = frm_inicio.lblNombre.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] "
            ObjRpt.PrintOptions.PrinterName = CbxInstalledPrinters.Text

            'Definir como la nueva impresora preestablecida
            Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", CbxInstalledPrinters.Text))

            'Pasar preferencias de la impresion en la nueva impresora
            Dim SettingsNewPrinter As New PrinterSettings
            Dim NewPrinter As String = SettingsNewPrinter.PrinterName
            SettingsNewPrinter.DefaultPageSettings.PrinterResolution.Kind = Printing.PrinterResolutionKind.High

            ObjRpt.PrintToPrinter(1, False, 0, 0)

            'Retorno de default printer
            Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrinterDefault))

            ObjRpt.Close()
            ObjRpt.Dispose()

            Me.Cursor = Cursors.Default
            Me.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class