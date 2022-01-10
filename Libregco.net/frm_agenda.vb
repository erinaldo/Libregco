Imports System.IO
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.iCalendar

Public Class frm_agenda

    Private Sub SchedulerControl1_EditAppointmentFormShowing_1(sender As Object, e As AppointmentFormEventArgs)
        Dim scheduler As DevExpress.XtraScheduler.SchedulerControl = CType(sender, DevExpress.XtraScheduler.SchedulerControl)
        Dim form As Libregco.CustomAppointmentForm = New Libregco.CustomAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm)
        Try
            e.DialogResult = form.ShowDialog
            e.Handled = True
        Finally
            form.Dispose()
        End Try

    End Sub

    Private Sub frm_agenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToScreen()

            Dim ExistFile As Boolean = System.IO.File.Exists(DTEmpleado.Rows(0).Item("AgendaFilePath"))
            If ExistFile = True Then
                Using stream As FileStream = File.OpenRead(DTEmpleado.Rows(0).Item("AgendaFilePath"))
                    ImportAppointments(stream)
                End Using
            End If

            SchedulerControl1.GoToToday()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ImportAppointments(ByVal stream As Stream)
        Try
            If stream Is Nothing Then
                Return
            End If
            SchedulerStorage1.Appointments.Clear()
            Dim importer As New iCalendarImporter(SchedulerStorage1)
            importer.Import(stream)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ExportAppointments(ByVal stream As Stream)
        Try
            If stream Is Nothing Then
                Return
            End If
            Dim exporter As New iCalendarExporter(SchedulerStorage1)
            exporter.ProductIdentifier = "-//Developer Express Inc.//DXScheduler iCalendarExchange Example//EN"
            exporter.Export(stream)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Using stream As Stream = File.OpenWrite(DTEmpleado.Rows(0).Item("AgendaFilePath"))
            ExportAppointments(stream)
        End Using

        ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
    End Sub

    Private Sub frm_agenda_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frm_inicio.SchedulerStorage1.Appointments.Clear()
        ''sdigsdgsdgsgd
        Dim ExistFile As Boolean = System.IO.File.Exists(DTEmpleado.Rows(0).Item("AgendaFilePath"))
        If ExistFile = True Then
            Using stream As FileStream = File.OpenRead(DTEmpleado.Rows(0).Item("AgendaFilePath"))
                frm_inicio.ImportAppointments(stream)
            End Using
        End If
    End Sub
End Class