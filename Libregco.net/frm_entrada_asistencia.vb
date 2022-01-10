Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Printing

Public Class frm_entrada_asistencia
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Private Sub frm_entrada_asistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        ActualizarTodo()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPassword.CheckedChanged
        MetodoEntrada()
    End Sub

    Private Sub Watermark1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim DsTemp As New DataSet

            If rdbPassword.Checked = True Then
                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,CorreoElectronico,RutaFoto,ImagenChat FROM" & SysName.Text & "Empleados where Password='" + txtPassword.Text + "' and Empleados.Nulo=0", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Empleados")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Empleados")

                If Tabla.Rows.Count = 0 Then

                    DsTemp.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,CorreoElectronico,RutaFoto,ImagenChat FROM" & SysName.Text & "Empleados where FactorNumerico='" + txtPassword.Text + "' and Empleados.Nulo=0", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Empleados")
                    ConMixta.Close()

                    Tabla = DsTemp.Tables("Empleados")

                    If Tabla.Rows.Count = 0 Then
                        MessageBox.Show("No se encontró el empleado con el tipo de entrada seleccionada.", "Empleado no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Else

                        lblNombre.Tag = Tabla.Rows(0).Item("IDEmpleado")
                        lblNombre.Text = Tabla.Rows(0).Item("Nombre")

                        If System.IO.File.Exists(Tabla.Rows(0).Item("ImagenChat")) Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("ImagenChat"), FileMode.Open, FileAccess.Read)
                            PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            If System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto")) Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                                wFile.Close()
                            End If
                        End If

                        CathAssistanceEntry(Tabla.Rows(0).Item("IDEmpleado"))
                        FillAsistencias(Tabla.Rows(0).Item("IDEmpleado"))

                        ToastNotificationsManager1.Notifications(0).Body = "Se ha registrado la " & lblIndicador.Text.ToString.ToLower & " de " & lblNombre.Text & " satisfactoriamente."
                        ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                        Timer1.Enabled = True
                        XtraTabPage2.PageVisible = True
                        XtraTabControl1.SelectedTabPageIndex = 1
                    End If

                Else

                    lblNombre.Tag = Tabla.Rows(0).Item("IDEmpleado")
                    lblNombre.Text = Tabla.Rows(0).Item("Nombre")

                    If System.IO.File.Exists(Tabla.Rows(0).Item("ImagenChat")) Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("ImagenChat"), FileMode.Open, FileAccess.Read)
                        PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        If System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto")) Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                            PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        End If
                    End If

                    CathAssistanceEntry(Tabla.Rows(0).Item("IDEmpleado"))
                    FillAsistencias(Tabla.Rows(0).Item("IDEmpleado"))

                    ToastNotificationsManager1.Notifications(0).Body = "Se ha registrado la " & lblIndicador.Text.ToString.ToLower & " de " & lblNombre.Text & " satisfactoriamente."
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                    Timer1.Enabled = True
                    XtraTabPage2.PageVisible = True
                    XtraTabControl1.SelectedTabPageIndex = 1
                End If
            End If
        End If
    End Sub

    Function FillAsistencias(ByVal EmployeeID As String)
        DgvAsistencias.Rows.Clear()
        ConMixta.Open()
        Dim Consulta As New MySqlCommand("SELECT IDAsistencias_detalles,FechaRegistro,if(Tipo=1,'Entrada','Salida') as Tipo,Tiempo FROM libregco.asistencias_detalles inner join Libregco.Asistencias on Asistencias_detalles.IDAsistencia=Asistencias.IDAsistencia where Asistencias.IDEmpleado='" + EmployeeID + "' and Asistencias.DiaHabil=Curdate();", ConMixta)
        Dim LectorAsistencias As MySqlDataReader = Consulta.ExecuteReader

        While LectorAsistencias.Read
            DgvAsistencias.Rows.Add(LectorAsistencias.GetValue(0), LectorAsistencias.GetValue(1), LectorAsistencias.GetValue(2), LectorAsistencias.GetValue(3), ConvertTimeSpantoLetter(LectorAsistencias.GetValue(3)))
        End While
        LectorAsistencias.Close()
        ConMixta.Close()

        If DgvAsistencias.Rows.Count > 0 Then
            DgvAsistencias.FirstDisplayedScrollingRowIndex = DgvAsistencias.Rows.Count - 1
        End If
        DgvAsistencias.ClearSelection()
    End Function

    Private Sub rdbCarnet_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCarnet.CheckedChanged
        MetodoEntrada()
    End Sub

    Function CathAssistanceEntry(ByVal EmployeeID As String) As String
        Try
            Dim DsTempTabla As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDAsistencia,Asistencias.IDEmpleado,Empleados.Nombre,Empleados.IDTanda,Empleados.Disponible,ifnull((Select FechaRegistro from Libregco.Asistencias_detalles where Asistencias_detalles.IDAsistencia=Asistencias.IDAsistencia ORDER BY idAsistencias_detalles DESC LIMIT 1),now()) as UltimaEntrada FROM libregco.asistencias inner join libregco.empleados on asistencias.idempleado=empleados.idempleado Where Empleados.IDEmpleado='" + EmployeeID + "' and Asistencias.DiaHabil=Curdate() and Empleados.Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTempTabla, "Empleado")
            ConLibregco.Close()

            Dim Tabla As DataTable = DsTempTabla.Tables("Empleado")

            If Tabla.Rows.Count > 0 Then
                Dim CatchedTime As String = Now.ToString("HH:mm:ss")

                ConLibregco.Open()
                If CInt(Tabla.Rows(0).Item("Disponible")) = 0 Then
                    Dim start As DateTime = Convert.ToString(Tabla.Rows(0).Item("UltimaEntrada"))
                    Dim span As TimeSpan = Now.Subtract(start)

                    sqlQ = "INSERT INTO Libregco.asistencias_detalles (IDAsistencia,FechaRegistro,Tipo,DuracionHoras,Tiempo) VALUES ('" + CStr(Tabla.Rows(0).Item("IDAsistencia")).ToString + "',Now(),1,'" + span.TotalHours.ToString() + "','" + span.ToString + "')"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()

                    sqlQ = "UPDATE Empleados Set Disponible=1 WHERE IDEmpleado='" + EmployeeID + "'"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()

                    lblIndicador.Text = "Entrada"
                    lblIndicador.BackColor = Color.Green

                Else
                    Dim start As DateTime = Convert.ToString(Tabla.Rows(0).Item("UltimaEntrada"))
                    Dim span As TimeSpan = Now.Subtract(start)

                    Label3.Text = ConvertTimeSpantoLetter(span)

                    sqlQ = "INSERT INTO Libregco.asistencias_detalles (IDAsistencia,FechaRegistro,Tipo,DuracionHoras,Tiempo) VALUES ('" + CStr(Tabla.Rows(0).Item("IDAsistencia")).ToString + "',Now(),0,'" + span.TotalHours.ToString() + "','" + span.ToString + "')"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()

                    sqlQ = "UPDATE Empleados Set Disponible=0 WHERE IDEmpleado='" + EmployeeID + "'"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()

                    lblIndicador.Text = "Salida"
                    lblIndicador.BackColor = Color.Red

                End If
                ConLibregco.Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        ActualizarTodo()
    End Sub

    Private Sub ActualizarTodo()
        rdbPassword.Checked = True
        txtPassword.Text = ""
        DgvAsistencias.Rows.Clear()
        Timer1.Enabled = False
        XtraTabPage2.PageVisible = False
        XtraTabControl1.SelectedTabPageIndex = 0
        txtPassword.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ActualizarTodo()
    End Sub

    Private Sub DgvAsistencias_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvAsistencias.RowsAdded
        If DgvAsistencias.Rows(e.RowIndex).Cells(2).Value = "Entrada" Then
            DgvAsistencias.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.Green
        Else
            DgvAsistencias.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.Red
        End If
    End Sub

    Private Sub rdbReconocimiento_CheckedChanged(sender As Object, e As EventArgs) Handles rdbReconocimiento.CheckedChanged
        MetodoEntrada()

        If rdbReconocimiento.Checked = False Then
            CameraControl1.Stop()
        Else
            CameraControl1.Start()
        End If
    End Sub

    Private Sub rdbDactilar_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDactilar.CheckedChanged
        MetodoEntrada()
    End Sub

    Private Sub MetodoEntrada()
        If rdbPassword.Checked = True Then
            XtraTabControl2.SelectedTabPageIndex = 0

            txtPassword.Focus()

        ElseIf rdbCarnet.Checked = True Then
            XtraTabControl2.SelectedTabPageIndex = 1
            txtCarnet.Focus()

        ElseIf rdbDactilar.Checked = True Then
            XtraTabControl2.SelectedTabPageIndex = 2

        ElseIf rdbReconocimiento.Checked = True Then
            XtraTabControl2.SelectedTabPageIndex = 3

        End If
    End Sub

End Class