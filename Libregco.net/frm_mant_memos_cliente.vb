Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_memos_cliente

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblFinalizar, lblIDPrioridad As New Label
    Friend RutaDocumento As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_memos_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        DgvProgresos.Rows.Clear()
        txtIDMemoC.Clear()
        txtIDTipoMemo.Clear()
        txtSecondID.Clear()
        txtTipoMemo.Clear()
        txtComentario.Clear()
        txtConclusion.Clear()
        txtFecha.Clear()
        RutaDocumento.Text = ""
        txtCliente.Clear()
        txtIDCliente.Clear()
        CbxPrioridad.Items.Clear()
    End Sub

    Private Sub FillPrioridad()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Prioridad FROM Prioridad ORDER BY IDPrioridad ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Prioridad")
        CbxPrioridad.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Prioridad")

        For Each Fila As DataRow In Tabla.Rows
            CbxPrioridad.Items.Add(Fila.Item("Prioridad"))
        Next

        CbxPrioridad.SelectedIndex = 1

    End Sub

    Private Sub SetIDPrioridad()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDPrioridad FROM Prioridad WHERE Prioridad = '" + CbxPrioridad.SelectedItem + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Prioridad ")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Prioridad ")

        lblIDPrioridad.Text = (Tabla.Rows(0).Item("IDPrioridad"))

    End Sub

    Private Sub ActualizarTodo()
        dtpFechaLimite.Value = Today
        FillPrioridad()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        chkFinalizado.Checked = False
        lblFinalizar.Text = 0
        ResetPicImage()
        lblStatusBar.Text = "Listo"
        TabControl1.Size = New Size(315, 358)
        TabControl1.Location = New Point(670, 196)
        lblOcultarProgresos.Visible = False
        btnBuscarCliente.Focus()
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

    Private Sub chkFinalizado_CheckedChanged(sender As Object, e As EventArgs) Handles chkFinalizado.CheckedChanged
        If chkFinalizado.Checked = True Then
            lblFinalizar.Text = 1
            txtConclusion.Enabled = True
            txtConclusion.Focus()
        Else
            lblFinalizar.Text = 0
        End If
    End Sub

    Sub FillChk()
        Dim Finalizado As New Label
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select Finalizado from MemosClientes Where IDMemoC='" + txtIDMemoC.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "MemosClientes")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("MemosClientes")
        Finalizado.Text = (Tabla.Rows(0).Item("Nulo"))

        If Finalizado.Text = 0 Then
            chkFinalizado.Checked = False
        Else
            chkFinalizado.Checked = True
        End If
    End Sub

    Private Sub UltMemoC()
        Try

            If txtIDMemoC.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDMemoC from MemosClientes where IDMemoC= (Select Max(IDMemoC) from MemosClientes)", Con)
                txtIDMemoC.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltMemoC")
        End Try
    End Sub

    Private Sub CreateFolder()
        Try
            Dim Exists As Boolean
            Exists = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Solicitudes")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Solicitudes")
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

                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Solicitudes\" & "SOC-" & txtIDMemoC.Text & ".png"

                    If RutaDestino <> RutaDocumento.Text Then

                        'Liberar uso del recurso
                        PicDoc.Image.Dispose()
                        PicDoc.Image = Nothing

                        My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        sqlQ = "UPDATE MemosClientes SET Adjunto='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDMemoC= (" + txtIDMemoC.Text + ")"
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
        btnBuscarCliente.Enabled = True
        btn_BuscarTipoMemo.Enabled = True
        txtComentario.Enabled = True
        dtpFechaLimite.Enabled = True
        chkFinalizado.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        btnBuscarCliente.Enabled = False
        btn_BuscarTipoMemo.Enabled = False
        txtComentario.Enabled = False
        dtpFechaLimite.Enabled = False
        chkFinalizado.Enabled = False
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDMemoC.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la solicitud?", "Imprimir Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btn_BuscarTipoMemo_Click(sender As Object, e As EventArgs) Handles btn_BuscarTipoMemo.Click
        frm_buscar_tipo_memo.ShowDialog(Me)
    End Sub

    Private Sub PrintDocAdjunto_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        e.Graphics.DrawImage(PicDoc.Image, 10, 20, 900, 920)
    End Sub

    Sub ResetPicImage()
        RutaDocumento.Text = ""
        PicDoc.Width = 307
        PicDoc.Height = 314
        PicDoc.Image = Nothing
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub BuscarTipoDeMemoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarTipoDeMemoToolStripMenuItem.Click
        btn_BuscarTipoMemo.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCompraToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub txtConclusion_Leave(sender As Object, e As EventArgs) Handles txtConclusion.Leave
        If txtConclusion.Text = "" Then
            MessageBox.Show("Es obligatorio introducir los resultados finales de la solicitud.", "Falta explicaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtConclusion.Clear()
            txtConclusion.Enabled = False
            chkFinalizado.Checked = False
            Exit Sub
        End If
        If Len(txtConclusion.Text) < 20 Then
            MessageBox.Show("No hay los suficientes argumentos para concluir la solicitud.", "Faltan Detalles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtConclusion.Clear()
            txtConclusion.Enabled = False
            chkFinalizado.Checked = False
            Exit Sub
        End If
    End Sub

    Private Sub chkFinalizado_Click(sender As Object, e As EventArgs) Handles chkFinalizado.Click
        If chkFinalizado.Checked = False And txtIDMemoC.Text <> "" Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea finalizar el registro de solicitud de cliente " & txtCliente.Text & "?" & vbNewLine & vbNewLine & "Para finalizar la solicitud debe tener disponible la conclusión detallada de la solicitud.", "Requisitos para Conclusión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkFinalizado.Checked = True
                lblFinalizar.Text = 1
            End If
        Else
            chkFinalizado.Checked = False
            lblFinalizar.Text = 0
        End If
    End Sub

    Private Sub CbxPrioridad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxPrioridad.SelectedIndexChanged
        SetIDPrioridad()
    End Sub

    Private Sub btnBuscarFoto_Click(sender As Object, e As EventArgs) Handles btnBuscarFoto.Click
        Dim OfdRutaFoto As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        OfdRutaFoto.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        OfdRutaFoto.Title = ("Seleccionar Foto para Solicitud")
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_solicitud_cliente.ShowDialog(Me)
    End Sub

    Sub RefrescarAvances()
        Try
            DgvProgresos.Rows.Clear()
            Con.Open()
            Dim CmdAvance As New MySqlCommand("SELECT IDProgreso,Fecha,Hora,Descripcion FROM progresosolicitud Where IDSolicitud='" + txtIDMemoC.Text + "' AND ProgresoSolicitud.Nulo=0", Con)
            Dim LectorAvance As MySqlDataReader = CmdAvance.ExecuteReader

            While LectorAvance.Read
                DgvProgresos.Rows.Add(LectorAvance.GetValue(0), CDate(LectorAvance.GetValue(1)).ToString("dd/MM/yyyy"), Convert.ToString(LectorAvance.GetValue(2)), LectorAvance.GetValue(3))
            End While
            LectorAvance.Close()
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " RefrescarAvances")
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la solicitud.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtIDTipoMemo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de solicitud.", "Tipo de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_BuscarTipoMemo.PerformClick()
            Exit Sub
        ElseIf txtComentario.Text = "" Then
            MessageBox.Show("Escriba la descripción o detalles de la nota o solicitud del cliente.", "Descripción de la Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtComentario.Focus()
            Exit Sub
        End If

        If txtIDMemoC.Text = "" Then 'Si no hay memoc
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva nota del tipo [" & txtTipoMemo.Text & "] en la base de datos?", "Guardar Nueva Nota", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO MemosClientes (IDTipoDocumento,Fecha,Hora,IDSucursal,IDAlmacen,IDUsuario,IDCliente,IDTipoMemo,IDPrioridad,Adjunto,Comentario,Conclusion,FechaLimite,Finalizado,Impreso,Nulo) VALUES (25,'" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "','" + txtIDCliente.Text + "','" + txtIDTipoMemo.Text + "','" + lblIDPrioridad.Text + "','" + (Replace(RutaDocumento.Text, "\", "\\")) + "','" + txtComentario.Text + "','" + txtConclusion.Text + "','" + dtpFechaLimite.Text + "','" + lblFinalizar.Text + "',0,0)"
                GuardarDatos()
                UltMemoC()
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
                sqlQ = "UPDATE MemosClientes SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',IDTipoMemo='" + txtIDTipoMemo.Text + "',IDPrioridad='" + lblIDPrioridad.Text + "',Adjunto='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',Comentario='" + txtComentario.Text + "',Conclusion='" + txtConclusion.Text + "',FechaLimite='" + dtpFechaLimite.Text + "',Finalizado='" + lblFinalizar.Text + "' WHERE IDMemoC= (" + txtIDMemoC.Text + ")"
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
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=25", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE MemosClientes SET SecondID='" + lblSecondID.Text + "' WHERE IDMemoC='" + txtIDMemoC.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=25"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la solicitud.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtIDTipoMemo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de solicitud.", "Tipo de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_BuscarTipoMemo.PerformClick()
            Exit Sub
        ElseIf txtComentario.Text = "" Then
            MessageBox.Show("Escriba la descripción o detalles de la nota o solicitud del cliente.", "Descripción de la Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtComentario.Focus()
            Exit Sub
        End If

        If txtIDMemoC.Text = "" Then 'Si no hay memoc
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva nota del tipo [" & txtTipoMemo.Text & "] en la base de datos?", "Guardar Nueva Nota", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO MemosClientes (IDTipoDocumento,Fecha,Hora,IDSucursal,IDAlmacen,IDUsuario,IDCliente,IDTipoMemo,IDPrioridad,Adjunto,Comentario,Conclusion,FechaLimite,Finalizado,Impreso,Nulo) VALUES (25,'" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "','" + txtIDCliente.Text + "','" + txtIDTipoMemo.Text + "','" + lblIDPrioridad.Text + "','" + (Replace(RutaDocumento.Text, "\", "\\")) + "','" + txtComentario.Text + "','" + txtConclusion.Text + "','" + dtpFechaLimite.Text + "','" + lblFinalizar.Text + "',0,0)"
                GuardarDatos()
                UltMemoC()
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
                sqlQ = "UPDATE MemosClientes SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',IDTipoMemo='" + txtIDTipoMemo.Text + "',IDPrioridad='" + lblIDPrioridad.Text + "',Adjunto='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',Comentario='" + txtComentario.Text + "',Conclusion='" + txtConclusion.Text + "',FechaLimite='" + dtpFechaLimite.Text + "',Finalizado='" + lblFinalizar.Text + "' WHERE IDMemoC= (" + txtIDMemoC.Text + ")"
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
        If txtIDMemoC.Text = "" Then 'Si no hay un referente seleccionado
            MessageBox.Show("No hay registro seleccionado", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el registro de la base de datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "Delete from MemosCliente Where IDMemoC = (" + txtIDMemoC.Text + ")"
                GuardarDatos()
                MessageBox.Show("Registro eliminado satisfactoriamente.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            Else
                MessageBox.Show("Se ha cancelado la eliminación del registro.", "Eliminado Abortado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            TabControl1.Size = New Size(973, 358)
            TabControl1.Location = New Point(12, 196)
            lblOcultarProgresos.Visible = True
        Else
            TabControl1.Size = New Size(315, 358)
            TabControl1.Location = New Point(670, 196)
            lblOcultarProgresos.Visible = False
        End If
    End Sub

    Private Sub TabControl1_Leave(sender As Object, e As EventArgs) Handles TabControl1.Leave
        TabControl1.Size = New Size(315, 358)
        TabControl1.Location = New Point(670, 196)
        TabControl1.SelectedIndex = 0
        lblOcultarProgresos.Visible = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblOcultarProgresos.LinkClicked
        TabControl1.Size = New Size(315, 358)
        TabControl1.Location = New Point(670, 196)
        TabControl1.SelectedIndex = 0
        lblOcultarProgresos.Visible = False
    End Sub
End Class