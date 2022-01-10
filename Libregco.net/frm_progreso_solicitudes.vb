Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_progreso_solicitudes

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblChKNulo, lblIDSolicitud As New Label
    Friend RutaDocumento As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_progreso_solicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
      PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub LimpiarDatos()
        txtSolicitud.Clear()
        txtDescripcionProgreso.Clear()
        txtDescripcionSolicitud.Clear()
        txtDescripcionProgreso.Clear()
        txtSecondID.Clear()
        txtIDProgreso.Clear()
        txtFecha.Clear()
        RutaDocumento.Text = ""
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        chkNulo.Checked = False
        lblChKNulo.Text = 0
        lblIDSolicitud.Text = ""
        ResetPicImage()
        lblStatusBar.Text = "Listo"
        lblNombre.Text = "Nombre del cliente"
        lblDireccion.Text = "Dirección del cliente"
        lblTelefono.Text = "Teléfonos del cliente"
        lblFechaSolicitud.Text = "Fecha de solicitud"
        lblVencimiento.Text = "Vencimiento de solicitud"
        lblPrioridad.Text = "Nivel de prioridad"
        lblTipoSolicitud.Text = "Tipo de solicitud"
        HabilitarControles()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub UltProgreso()
        Try

            If txtIDProgreso.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDProgreso from ProgresoSolicitud where IDProgreso= (Select Max(IDProgreso) from ProgresoSolicitud)", Con)
                txtIDProgreso.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltProgreso")
        End Try
    End Sub

    Private Sub CreateFolder()
        Try
            Dim Exists As Boolean
            Exists = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Progresos")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Progresos")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub MoverFichero()
        Try

            CreateFolder()   'Verificamos si existe el folder del suplidor

            If RutaDocumento.Text = "" Then
            Else

                Dim Exists As Boolean = System.IO.File.Exists(RutaDocumento.Text)
                If Exists = True Then

                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Progresos\" & "POG-" & txtIDProgreso.Text & ".png"

                    If RutaDestino <> RutaDocumento.Text Then

                        'Liberar uso del recurso
                        PicDoc.Image.Dispose()
                        PicDoc.Image = Nothing

                        My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        sqlQ = "UPDATE ProgresoSolicitud SET Adjunto='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDProgreso= (" + txtIDProgreso.Text + ")"
                        GuardarDatos()

                        'Devolver Nueva Ruta al los controles
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                        PicDoc.Image = System.Drawing.Image.FromStream(wFile)
                        RutaDocumento.Text = RutaDestino
                        lblStatusBar.Text = "Imagen Cargada desde: " & RutaDestino
                        wFile.Close()
                    End If

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub HabilitarControles()
        txtSolicitud.Enabled = True
        btn_BuscarSolicitud.Enabled = True
        TbProgreso.Enabled = True
        chkNulo.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtSolicitud.Enabled = False
        btn_BuscarSolicitud.Enabled = False
        TbProgreso.Enabled = False
        chkNulo.Enabled = False
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDProgreso.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la solicitud?", "Imprimir Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub PrintDocAdjunto_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        e.Graphics.DrawImage(PicDoc.Image, 10, 20, 900, 920)
    End Sub

    Sub ResetPicImage()
        RutaDocumento.Text = ""
        PicDoc.Width = 405
        PicDoc.Height = 362
        PicDoc.Image = Nothing
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub btnBuscarFoto_Click(sender As Object, e As EventArgs) Handles btnBuscarFoto.Click
        Dim OfdRutaFoto As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        OfdRutaFoto.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        OfdRutaFoto.Title = ("Seleccionar Imagen")
        OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
        OfdRutaFoto.FileName = ""

        If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
            RutaDocumento.Text = OfdRutaFoto.FileName
            lblStatusBar.Text = "Anexo desde: " & OfdRutaFoto.FileName
            wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
            PicDoc.Image = System.Drawing.Image.FromStream(wFile)
            wFile.Close()
        Else
        End If
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If RutaDocumento.Text = "" Then
            MessageBox.Show("No se ha encontrado una imagen anexa para poder abrirla.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la foto vinculada al registro?", "Abrir Identificacion Anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(RutaDocumento.Text)
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If RutaDocumento.Text = "" Then
            MessageBox.Show("No existe imagen del artículo anexa al registro.", "No existe foto del producto", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar la imagen anexa al registro?", "Eliminar Fotografía", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                RutaDocumento.Text = ""
                lblStatusBar.Text = "Listo"
                ResetPicImage()
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim PDoc As New Printing.PrintDocument
        Dim PrintShow As New PrintDialog
        If RutaDocumento.Text = "" Then
            MessageBox.Show("No se pudo imprimir debido a que no existe documentación anexa al registro.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            If PrintShow.ShowDialog = Windows.Forms.DialogResult.OK Then
                PDoc.PrinterSettings = PrintShow.PrinterSettings
                PDoc.Print()
            End If
        End If
    End Sub

    Private Sub PicDoc_Click(sender As Object, e As EventArgs) Handles PicDoc.Click
        If RutaDocumento.Text = "" Then
            btnBuscarFoto.PerformClick()
        Else
            btnAbrir.PerformClick()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtSolicitud.Text = "" Then
            MessageBox.Show("Escriba el número de solicitud de cliente.", "Seleccionar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_BuscarSolicitud.PerformClick()
            Exit Sub
        ElseIf txtDescripcionProgreso.Text = "" Then
            MessageBox.Show("Escriba los comentarios y/o observaciones del avance de la solicitud.", "No se encontraron observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcionProgreso.Focus()
            Exit Sub
        ElseIf Len(txtDescripcionProgreso.Text) < 15 Then
            MessageBox.Show("Los comentarios y/o observaciones del avance de la solicitud no son suficientes para procesar el progreso. Por favor detalle el progreso de la solicitud.", "Descripción de avance de solicitud insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcionProgreso.Focus()
            Exit Sub
        End If

        If txtIDProgreso.Text = "" Then 'Si no hay memoc
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el avance de solicitud No. [" & txtSolicitud.Text & "] en la base de datos?", "Guardar Progreso de Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO ProgresoSolicitud (Fecha,Hora,IDSucursal,IDAlmacen,IDUsuario,IDSolicitud,Descripcion,Impreso,Nulo) VALUES ('" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "','" + lblIDSolicitud.Text + "','" + txtDescripcionProgreso.Text + "',0,'" + lblChKNulo.Text + "')"
                GuardarDatos()
                UltProgreso()
                SetSecondID()
                MoverFichero()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la nota y/o solicitud?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE ProgresoSolicitud SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Descripcion='" + txtDescripcionProgreso.Text + "',Nulo='" + lblChKNulo.Text + "' WHERE IDProgreso= (" + txtIDProgreso.Text + ")"
                GuardarDatos()
                MoverFichero()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=41", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE ProgresoSolicitud SET SecondID='" + lblSecondID.Text + "' WHERE IDProgreso='" + txtIDProgreso.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=41"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtSolicitud.Text = "" Then
            MessageBox.Show("Escriba el número de solicitud de cliente.", "Seleccionar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_BuscarSolicitud.PerformClick()
            Exit Sub
        ElseIf txtDescripcionProgreso.Text = "" Then
            MessageBox.Show("Escriba los comentarios y/o observaciones del avance de la solicitud.", "No se encontraron observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcionProgreso.Focus()
            Exit Sub
        ElseIf Len(txtDescripcionProgreso.Text) < 15 Then
            MessageBox.Show("Los comentarios y/o observaciones del avance de la solicitud no son suficientes para procesar el progreso. Por favor detalle el progreso de la solicitud.", "Descripción de avance de solicitud insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcionProgreso.Focus()
            Exit Sub
        End If

        If txtIDProgreso.Text = "" Then 'Si no hay memoc
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el avance de solicitud No. [" & txtSolicitud.Text & "] en la base de datos?", "Guardar Progreso de Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO ProgresoSolicitud (Fecha,Hora,IDSucursal,IDAlmacen,IDUsuario,IDSolicitud,Descripcion,Impreso,Nulo) VALUES ('" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "','" + lblIDSolicitud.Text + "','" + txtDescripcionProgreso.Text + "',0,'" + lblChKNulo.Text + "')"
                GuardarDatos()
                UltProgreso()
                SetSecondID()
                MoverFichero()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la nota y/o solicitud?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE ProgresoSolicitud SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Descripcion='" + txtDescripcionProgreso.Text + "',Nulo='" + lblChKNulo.Text + "' WHERE IDProgreso= (" + txtIDProgreso.Text + ")"
                GuardarDatos()
                MoverFichero()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El avance de solicitud código. " & txtSecondID.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Avance de Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE ProgresoSolicitud SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Descripcion='" + txtDescripcionProgreso.Text + "',Nulo='" + lblChKNulo.Text + "' WHERE IDProgreso= (" + txtIDProgreso.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDProgreso.Text = "" Then
            MessageBox.Show("No hay un registro de avance de solicitud abierta para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el avande de solicitud código. " & txtSolicitud.Text & " del sistema?", "Anular Avance de solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE ProgresoSolicitud SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Descripcion='" + txtDescripcionProgreso.Text + "',Nulo='" + lblChKNulo.Text + "' WHERE IDProgreso= (" + txtIDProgreso.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub


    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btn_BuscarSolicitud.PerformClick()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_progreso_solicitud.ShowDialog(Me)
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub btn_BuscarSolicitud_Click(sender As Object, e As EventArgs) Handles btn_BuscarSolicitud.Click
        Try
            If txtSolicitud.Text = "" Then
                MessageBox.Show("Escriba el número de solicitud a la cual se procesará el progreso.", "Número de reporte vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtSolicitud.Focus()
                Exit Sub

            Else

                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDMemoC,MemosClientes.SecondID,Fecha,Clientes.IDCliente,Clientes.Nombre as NombreCliente,Clientes.Direccion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,MemosClientes.IDTipoMemo,TiposMemos.Clase,MemosClientes.IDPrioridad,Prioridad.Prioridad,Comentario,FechaLimite FROM memosclientes INNER JOIN Clientes on MemosClientes.IDCliente=Clientes.IDCliente INNER JOIN Prioridad on MemosClientes.IDPrioridad=Prioridad.IDPrioridad INNER JOIN TiposMemos on MemosClientes.IDTipoMemo=TiposMemos.IDTiposMemos Where MemosClientes.SecondID='" + txtSolicitud.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Solicitudes")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("Solicitudes")

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron resultados.", "No se encontró", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    lblIDSolicitud.Text = (Tabla.Rows(0).Item("IDMemoC"))
                    lblNombre.Text = "[" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("NombreCliente"))
                    lblDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
                    lblTelefono.Text = (Tabla.Rows(0).Item("TelefonoPersonal"))

                    If (Tabla.Rows(0).Item("TelefonoHogar")) = "" Then
                    Else
                        lblTelefono.Text = lblTelefono.Text & ", " & (Tabla.Rows(0).Item("TelefonoHogar"))
                    End If

                    lblTipoSolicitud.Text = "[" & (Tabla.Rows(0).Item("IDTipoMemo")) & "] " & (Tabla.Rows(0).Item("Clase"))
                    lblFechaSolicitud.Text = (Tabla.Rows(0).Item("Fecha"))
                    lblVencimiento.Text = (Tabla.Rows(0).Item("FechaLimite"))
                    lblPrioridad.Text = (Tabla.Rows(0).Item("Prioridad"))
                    txtDescripcionSolicitud.Text = (Tabla.Rows(0).Item("Comentario"))

                    btn_BuscarSolicitud.Enabled = False
                    txtSolicitud.Enabled = False
                End If


            End If
        Catch ex As Exception

        End Try

    End Sub

  
End Class