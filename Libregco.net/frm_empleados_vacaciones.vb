Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_empleados_vacaciones
    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador, Adaptador1 As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim arrTiempoCalculo(2) As Integer
    Dim Permisos As New ArrayList
    Friend RutaDocumento As String = ""

    Private Sub frm_empleados_vacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        CargarEmpresa()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIDEmpleado.Text <> "" Then
            If txtIDVacaciones.Text = "" Then

                For Each rw As DataGridViewRow In DgvVacaciones.Rows
                    If CDate(rw.Cells(1).Value).Year = Today.Year Then
                        Dim Result As MsgBoxResult = MessageBox.Show("Ya se han generado vacaciones durante el período actual." & vbNewLine & vbNewLine & "Está seguro que desea programar otras vacaciones para el mismo empleado?", "Establecer período de vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If Result = MsgBoxResult.Yes Then
                            Exit For
                        Else
                            Exit Sub
                        End If
                    End If
                Next

                dtpVacacionTermina.Value = CalcDiasVacaciones(dtpVacacionInicia.Value)
                txtConcepto.Text = "Vacaciones correspondientes al período " & Now.Year & "."
                calcDifFechas(CDate(lblFechaIngreso.Text), Today, arrTiempoCalculo)

                'Vacaciones
                Dim diasvacaciones As Integer = 0

                ' Calcular Preaviso
                Dim mesesPreaviso As Integer = ((arrTiempoCalculo(0) * 12) + arrTiempoCalculo(1))
                Dim diaspreaviso As Integer = 0
                Select Case (True)
                    Case (mesesPreaviso >= 12)
                        diaspreaviso = 28
                    Case (mesesPreaviso >= 6)
                        diaspreaviso = 14
                    Case (mesesPreaviso >= 3)
                        diaspreaviso = 7
                End Select



                If txtIDVacaciones.Text = "" Then
                    Select Case (True)
                        Case (mesesPreaviso >= 60)
                            diasvacaciones = 18
                            Exit Select
                        Case (mesesPreaviso >= 12)
                            diasvacaciones = 14
                            Exit Select
                        Case (mesesPreaviso >= 5)
                            diasvacaciones = mesesPreaviso + 1
                            Exit Select
                    End Select

                Else

                    Select Case (True)
                        Case (arrTiempoCalculo(1) > 11)
                            diasvacaciones = 12
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 10)
                            diasvacaciones = 11
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 9)
                            diasvacaciones = 10
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 8)
                            diasvacaciones = 9
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 7)
                            diasvacaciones = 8
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 6)
                            diasvacaciones = 7
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 5)
                            diasvacaciones = 6
                            Exit Select
                    End Select

                End If

                Dim salarioVacaciones As Double = 0
                Dim valorDiaVacaciones As Double = 0

                If (arrTiempoCalculo(0) > 0) Then
                    'Tomamos el valor para el dia de vacaciones cuando tenga el ano acumulado
                    valorDiaVacaciones = CDbl(lblSalario.Text) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones

                ElseIf (arrTiempoCalculo(1) > 0) Then
                    'Tomamos el valor para el dia de vacaciones con el ultimo salario
                    valorDiaVacaciones = CDbl(lblSalario.Text) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones
                Else
                    valorDiaVacaciones = CDbl(lblSalario.Text) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones
                End If

                If (diasvacaciones > 0) Then
                    txtDiasVacaciones.Text = diasvacaciones
                    txtTotalVacaciones.Text = CDbl(salarioVacaciones).ToString("C")
                    lblMontoLetras.Text = ConvertNumbertoString(salarioVacaciones)
                Else
                    txtDiasVacaciones.Text = ""
                    txtTotalVacaciones.Text = ""
                End If

            End If
        End If
    End Sub

    Private Sub PicCliente_Click(sender As Object, e As EventArgs) Handles PicCliente.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub SimilarFindButton_Click(sender As Object, e As EventArgs) Handles SimilarFindButton.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDVacaciones.Text = "" Then
            If txtConcepto.Text <> "" Or dtpVacacionInicia.Value <> Today Or txtIDEmpleado.Text <> "" Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de registro de vacaciones?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
        End If
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs)
        btnGuardar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub LimpiarDatos()
        txtIDVacaciones.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtIDEmpleado.Clear()
        txtEmpleado.Clear()
        lblFechaIngreso.Text = ""
        lblSalario.Text = ""
        lblMensaje.Text = ""
        RutaDocumento = ""
        lblMontoLetras.Text = ""
        txtDiasVacaciones.Clear()
        txtTotalVacaciones.Clear()
        txtConcepto.Clear()
        DgvVacaciones.Rows.Clear()
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd1 = New MySqlCommand(sqlQ, Con)
            cmd1.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub
    Private Sub GuardarDatosDoble()
        Try
            ConLibregco.Open()
            cmd1 = New MySqlCommand(sqlQ, ConLibregco)
            cmd1.ExecuteNonQuery()
            ConLibregco.Close()

            ConLibregcoMain.Open()
            cmd1 = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd1.ExecuteNonQuery()
            ConLibregcoMain.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ConvertDouble()
        txtTotalVacaciones.Text = CDbl(txtTotalVacaciones.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtTotalVacaciones.Text = CDbl(txtTotalVacaciones.Text).ToString("C")
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet
            Dim UltSecuencia As New Label

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=56", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")

            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))

            sqlQ = "UPDATE Empleados_vacaciones SET SecondID='" + txtSecondID.Text + "' WHERE IDVacaciones='" + txtIDVacaciones.Text + "'"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()


            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=56"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()

            Con.Close()

        Catch ex As Exception

        End Try

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtDiasVacaciones.Text = "" Then
            MessageBox.Show("No se ha cálculado la cantidad de días hábiles en la programación de las vacaciones.")
            Exit Sub

        ElseIf txtDiasVacaciones.Text = "0" Then
            MessageBox.Show("No se ha cálculado la cantidad de días hábiles en la programación de las vacaciones.")
            Exit Sub

        ElseIf txtTotalVacaciones.Text = "" Then
            MessageBox.Show("No se ha cálculado el monto total de las vacaciones en la programación de las vacaciones.")
            Exit Sub

        ElseIf txtTotalVacaciones.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("No se ha cálculado el monto total de las vacaciones en la programación de las vacaciones.")
            Exit Sub

        ElseIf dtpVacacionInicia.Value = dtpVacacionTermina.Value Then
            MessageBox.Show("La fecha de inicio de las vacaciones debe ser menor a la fecha de entrada.")
            Exit Sub

        End If

        If txtIDVacaciones.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea programar las vacaciones anuales de " & txtEmpleado.Text & " del " & dtpVacacionInicia.Value & " al " & dtpVacacionTermina.Value & "?", "Establecer período de vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Empleados_Vacaciones (IDEmpleado,Fecha,IDEquipo,IDUsuario,FechaSalida,FechaEntrada,DiasPagados,ConceptoVacaciones,MontoVacaciones,SumaLetra,Adjunto,Nulo) VALUES ('" + txtIDEmpleado.Text + "','" + txtFecha.Text + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "', '" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "','" + txtDiasVacaciones.Text + "', '" + txtConcepto.Text + "' , '" + CDbl(txtTotalVacaciones.Text).ToString + "','" + lblMontoLetras.Text + "','" + RutaDocumento + "','" + chkNulo.Tag.ToString + "')"
                GuardarDatos()

                sqlQ = "UPDATE Empleados SET VacacionInicia='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',VacacionTermina='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
                GuardarDatosDoble()

                Con.Open()
                cmd = New MySqlCommand("Select IDVacaciones from Empleados_Vacaciones where IDVacaciones= (Select Max(IDVacaciones) from Empleados_Vacaciones)", Con)
                txtIDVacaciones.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()

                SetSecondID()
                Hora.Enabled = False

                MoverFichero()
                FillVacaciones()
                MessageBox.Show("Las vacaciones han sido programadas satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en la programación de las vacaciones seleccionada?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Empleados_Vacaciones SET IDEmpleado='" + txtIDEmpleado.Text + "',Fecha='" + txtFecha.Text + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',FechaSalida='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',FechaEntrada='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "',DiasPagados='" + txtDiasVacaciones.Text + "',ConceptoVacaciones='" + txtConcepto.Text + "',MontoVacaciones='" + CDbl(txtTotalVacaciones.Text).ToString + "',SumaLetra='" + lblMontoLetras.Text + "',Adjunto='" + RutaDocumento + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDVacaciones= '" + txtIDVacaciones.Text + "'"
                GuardarDatos()

                sqlQ = "UPDATE Empleados SET VacacionInicia='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',VacacionTermina='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
                GuardarDatosDoble()

                ConvertCurrent()
                MoverFichero()
                FillVacaciones()

                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If txtDiasVacaciones.Text = "" Then
                MessageBox.Show("No se ha cálculado la cantidad de días hábiles en la programación de las vacaciones.")
                Exit Sub

            ElseIf txtDiasVacaciones.Text = "0" Then
                MessageBox.Show("No se ha cálculado la cantidad de días hábiles en la programación de las vacaciones.")
                Exit Sub

            ElseIf txtTotalVacaciones.Text = "" Then
                MessageBox.Show("No se ha cálculado el monto total de las vacaciones en la programación de las vacaciones.")
                Exit Sub

            ElseIf txtTotalVacaciones.Text = CDbl(0).ToString("C") Then
                MessageBox.Show("No se ha cálculado el monto total de las vacaciones en la programación de las vacaciones.")
                Exit Sub

            ElseIf dtpVacacionInicia.Value = dtpVacacionTermina.Value Then
                MessageBox.Show("La fecha de inicio de las vacaciones debe ser menor a la fecha de entrada.")
                Exit Sub

            End If

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If chkNulo.Checked = True Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de vacaciones de " & txtEmpleado.Text & "  ya está desactivado del sistema. Desea volver a activarlo.", "Activar vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    ConvertDouble()
                    chkNulo.Checked = False
                    sqlQ = "UPDATE Empleados_Vacaciones SET IDEmpleado='" + txtIDEmpleado.Text + "',Fecha='" + txtFecha.Text + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',FechaSalida='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',FechaEntrada='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "',DiasPagados='" + txtDiasVacaciones.Text + "',ConceptoVacaciones='" + txtConcepto.Text + "',MontoVacaciones='" + CDbl(txtTotalVacaciones.Text).ToString + "',SumaLetra='" + lblMontoLetras.Text + "',Adjunto='" + RutaDocumento + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDVacaciones= '" + txtIDVacaciones.Text + "'"
                    GuardarDatos()
                    MoverFichero()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            ElseIf txtIDEmpleado.Text = "" Then
                MessageBox.Show("No hay un registro de empleado abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el período de vacaciones del empleado " & txtEmpleado.Text & " del sistema?", "Desactivar vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    chkNulo.Checked = True
                    sqlQ = "UPDATE Empleados_Vacaciones SET IDEmpleado='" + txtIDEmpleado.Text + "',Fecha='" + txtFecha.Text + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',FechaSalida='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',FechaEntrada='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "',DiasPagados='" + txtDiasVacaciones.Text + "',ConceptoVacaciones='" + txtConcepto.Text + "',MontoVacaciones='" + CDbl(txtTotalVacaciones.Text).ToString + "',SumaLetra='" + lblMontoLetras.Text + "',Adjunto='" + RutaDocumento + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDVacaciones= '" + txtIDVacaciones.Text + "'"
                    GuardarDatos()
                    MoverFichero()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Text = Now.ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_vacaciones.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 539
            frm_subir_documento.PicDocumento.Height = 607
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = RutaDocumento

            If RutaDocumento <> "" Then
                If System.IO.File.Exists(RutaDocumento) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(RutaDocumento, FileMode.Open, FileAccess.Read)
                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                    frm_subir_documento.btnDownload.Visible = True
                Else
                    frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                    frm_subir_documento.btnBuscar.PerformClick()
                    frm_subir_documento.btnDownload.Visible = False
                End If
            Else
                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                frm_subir_documento.btnBuscar.PerformClick()
                frm_subir_documento.btnDownload.Visible = False
            End If
        End If
    End Sub

    Private Sub CreateFolder()
        Try

            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Vacaciones")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Vacaciones")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub
    Private Sub MoverFichero()
        Try

            If TypeConnection.Text = 1 Then
                Dim Exists As Boolean
                Dim RutaDestino As String

                CreateFolder()

                'Modificando ruta de foto

                If RutaDocumento <> "" Then
                    Exists = System.IO.File.Exists(RutaDocumento)

                    If Exists = True Then
                        RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Vacaciones\" & txtIDVacaciones.Text & ".png"

                        If RutaDestino <> RutaDocumento Then
                            My.Computer.FileSystem.MoveFile(RutaDocumento, RutaDestino, FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
                            RutaDocumento = RutaDestino

                            sqlQ = "UPDATE Empleados_vacaciones SET adjunto='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDvacaciones= '" + txtIDVacaciones.Text + "'"

                            ConLibregco.Open()
                            cmd1 = New MySqlCommand(sqlQ, ConLibregco)
                            cmd1.ExecuteNonQuery()
                            ConLibregco.Close()

                            ConLibregcoMain.Open()
                            cmd1 = New MySqlCommand(sqlQ, ConLibregcoMain)
                            cmd1.ExecuteNonQuery()
                            ConLibregcoMain.Close()
                        End If

                    Else
                        MessageBox.Show("El archivo " & RutaDocumento & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If txtIDVacaciones.Text <> "" Then
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                Dim ObjRpt As New ReportDocument

                Con.Open()
                cmd = New MySqlCommand("Select Path from Reportes where IDReportes=252", Con)
                Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()


                ObjRpt.Load("\\" & PathServidor.Text & Path)

                crParameterValues.Clear()
                frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

                '@IDDocumento
                crParameterDiscreteValue.Value = txtIDVacaciones.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")

                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lblStatusBar.Text = "Visualizando el reporte..."

                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)

                TmpForm.CrystalViewer.ReportSource = ObjRpt
                TmpForm.CrystalViewer.Refresh()

                TmpForm.CrystalViewer.Cursor = Cursors.Default
                lblStatusBar.Text = "Listo"

            Else
                MessageBox.Show("No se encuentra un registro disponible en el formulario para imprimir. Por favor seleccione o guarde un registro para imprimir.", "No hay registro abierto", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtTotalVacaciones_Leave(sender As Object, e As EventArgs) Handles txtTotalVacaciones.Leave
        If txtTotalVacaciones.Text = "" Then
            txtTotalVacaciones.Text = CDbl(0).ToString("C")
        Else
            txtTotalVacaciones.Text = CDbl(txtTotalVacaciones.Text).ToString("C")

            lblMontoLetras.Text = ConvertNumbertoString(CDbl(txtTotalVacaciones.Text))

        End If
    End Sub

    Private Sub txtTotalVacaciones_Enter(sender As Object, e As EventArgs) Handles txtTotalVacaciones.Enter
        If txtTotalVacaciones.Text = "" Then
        Else
            txtTotalVacaciones.Text = CDbl(txtTotalVacaciones.Text)
        End If
    End Sub

    Private Sub txtTotalVacaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalVacaciones.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub ActualizarTodo()
        MakeRoundedImageToPanel(My.Resources.no_photo, PicCliente)
        dtpVacacionInicia.Value = Today
        dtpVacacionTermina.Value = Today
        chkNulo.Checked = False
        chkNulo.Tag = 0
        Hora.Enabled = True
    End Sub

    Sub FillVacaciones()
        Try
            DgvVacaciones.Rows.Clear()
            ConMixta.Open()
            Dim AnexoSql As New MySqlCommand("SELECT idvacaciones,FechaSalida,FechaEntrada,DiasPagados,ConceptoVacaciones,MontoVacaciones FROM" & SysName.Text & "Empleados_vacaciones where IDEmpleado='" + txtIDEmpleado.Text + "'", ConMixta)

            Dim LectorVacaciones As MySqlDataReader = AnexoSql.ExecuteReader
            While LectorVacaciones.Read
                DgvVacaciones.Rows.Add(LectorVacaciones.GetValue(0), CDate(Convert.ToString(LectorVacaciones.GetValue(1))).ToString("dd/MM/yyyy"), CDate(Convert.ToString(LectorVacaciones.GetValue(2))).ToString("dd/MM/yyyy"), LectorVacaciones.GetValue(3), LectorVacaciones.GetValue(4), CDbl(LectorVacaciones.GetValue(5)).ToString("C"))
            End While

            LectorVacaciones.Close()
            ConMixta.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class