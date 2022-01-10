Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_tipo_moneda

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblChkAnimacion, lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_tipo_moneda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub CargarLibregco()
    PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
    PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub LimpiarDatos()
        lblNulo.Text = 0
        txtNombreMoneda.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtIDMoneda.Clear()
        txtSignoMonetario.Clear()
        txtTexto.Clear()
        txtTasaCompra.Clear()
        txtTasaVenta.Clear()
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        chkNulo.Checked = False
        ResetPicImage()
        lblChkAnimacion.Text = 0
        HabilitarControles()
        txtNombreMoneda.Focus()
        Hora.Enabled = True
        chkAnimacion.Checked = False
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub HabilitarControles()
        txtNombreMoneda.Enabled = True
        txtSignoMonetario.Enabled = True
        txtTexto.Enabled = True
        chkNulo.Enabled = True
        txtTasaCompra.Enabled = True
    End Sub

    Private Sub DesHabilitarControles()
        txtNombreMoneda.Enabled = False
        txtSignoMonetario.Enabled = False
        txtTexto.Enabled = False
        chkNulo.Enabled = False
        txtTasaCompra.Enabled = False
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            txtUsuario.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Desde SelectUsuario")
        End Try
    End Sub

    Private Sub UltMoneda()
        Try
            If txtIDMoneda.Text = "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDTipoMoneda from TipoMoneda where IDTipoMoneda= (Select Max(IDTipoMoneda) from TipoMoneda)", ConLibregco)
                txtIDMoneda.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltMoneda")
        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

        Catch ex As Exception
            ConLibregco.Close()
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub txtNombreMoneda_TextChanged(sender As Object, e As EventArgs) Handles txtNombreMoneda.TextChanged
        ExpMonetaria()
    End Sub

    Private Sub txtSignoMonetario_TextChanged(sender As Object, e As EventArgs) Handles txtSignoMonetario.TextChanged
        ExpMonetaria()
    End Sub

    Private Sub ExpMonetaria()
        txtTexto.Text = "En " & txtNombreMoneda.Text & " " & txtSignoMonetario.Text
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_moneda.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de la moneda código No. " & txtIDMoneda.Text & ", signo " & txtSignoMonetario.Text & ",  ya está anulada en el sistema. Desea activarla?", "Recuperar Cuenta Bancaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 73
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                sqlQ = "UPDATE Libregco.TipoMoneda SET Fecha='" + Today.ToString("yyyy-MM-dd") + "',Hora='" + TimeOfDay.ToString("hh:mm:ss") + "',Moneda='" + txtNombreMoneda.Text + "',Signo='" + txtSignoMonetario.Text + "',Texto='" + txtTexto.Text + "',TasaCompra='" + txtTasaCompra.Text + "',TasaVenta='" + txtTasaVenta.Text + "',MostrarAnimacion='" + lblChkAnimacion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoMoneda= (" + txtIDMoneda.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDMoneda.Text = "" Then
            MessageBox.Show("No hay un registro de tipo moneda abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el tipo de moneda código no. " & txtIDMoneda.Text & ", signo " & txtSignoMonetario.Text & ", del sistema?", "Anular Tipo de Moneda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 74
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                sqlQ = "UPDATE Libregco.TipoMoneda SET Fecha='" + Today.ToString("yyyy-MM-dd") + "',Hora='" + TimeOfDay.ToString("hh:mm:ss") + "',Moneda='" + txtNombreMoneda.Text + "',Signo='" + txtSignoMonetario.Text + "',Texto='" + txtTexto.Text + "',TasaCompra='" + txtTasaCompra.Text + "',TasaVenta='" + txtTasaVenta.Text + "',MostrarAnimacion='" + lblChkAnimacion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoMoneda= (" + txtIDMoneda.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub txtTasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasaCompra.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtTasaVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasaVenta.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Sub ResetPicImage()
        Try
            PicFoto.Width = 50
            PicFoto.Height = 50
            PicFoto.Image = My.Resources.No_Image
            PicFoto.SizeMode = PictureBoxSizeMode.Zoom
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim OfdRutaDocumento As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        OfdRutaDocumento.Title = ("Buscar Imagen")
        OfdRutaDocumento.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
        OfdRutaDocumento.FileName = ""
        OfdRutaDocumento.RestoreDirectory = True

        If OfdRutaDocumento.ShowDialog = Windows.Forms.DialogResult.OK Then
            PicFoto.SizeMode = PictureBoxSizeMode.Zoom
            PicFoto.Tag = OfdRutaDocumento.FileName
            wFile = New FileStream(OfdRutaDocumento.FileName, FileMode.Open, FileAccess.Read)
            PicFoto.Image = System.Drawing.Image.FromStream(wFile)
            wFile.Close()
        Else
            ResetPicImage()
        End If

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If PicFoto.Tag.ToString = "" Then
            MessageBox.Show("No existe imagen anexa al registro.", "No existe imagen adjunta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar el archivo adjunto al registro?", "Eliminar imagen adjunto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                PicFoto.Tag = ""
                ResetPicImage()
            End If
        End If
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If txtNombreMoneda.Text = "" Then
            MessageBox.Show("Escriba el nombre de la moneda.", "Nombre de Moneda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombreMoneda.Focus()
            Exit Sub
        ElseIf txtSignoMonetario.Text = "" Then
            MessageBox.Show("Especifique el símbolo de la moneda.", "Símbolo de la moneda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSignoMonetario.Focus()
            Exit Sub
        ElseIf txtTexto.Text = "" Then
            MessageBox.Show("Defina la expresión de la moneda a utilizar.", "Expresión de moneda.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTexto.Focus()
            Exit Sub
        ElseIf txtTasaCompra.Text = "" Then
            MessageBox.Show("Establezca la tasa de la moneda.", "Tasa de moneda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTasaCompra.Focus()
            Exit Sub
        End If

        If txtIDMoneda.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva moneda, símbolo " & txtSignoMonetario.Text & ",  en la base de datos?", "Guardar Nueva Moneda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Libregco.TipoMoneda (Fecha,Hora,Moneda,Signo,Texto,TasaCompra,TasaVenta,MostrarAnimacion,Nulo) VALUES ('" + txtFecha.Text + "','" + txtHora.Text + "', '" + txtNombreMoneda.Text + "','" + txtSignoMonetario.Text + "','" + txtTexto.Text + "','" + txtTasaCompra.Text + "','" + txtTasaVenta.Text + "','" + lblChkAnimacion.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltMoneda()
                GenerarClienteBalance()
                MoverFichero()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DesHabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de moneda?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Libregco.TipoMoneda SET Fecha='" + Today.ToString("yyyy-MM-dd") + "',Hora='" + TimeOfDay.ToString("hh:mm:ss") + "',Moneda='" + txtNombreMoneda.Text + "',Signo='" + txtSignoMonetario.Text + "',Texto='" + txtTexto.Text + "',TasaCompra='" + txtTasaCompra.Text + "',TasaVenta='" + txtTasaVenta.Text + "',MostrarAnimacion='" + lblChkAnimacion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoMoneda= (" + txtIDMoneda.Text + ")"
                GuardarDatos()
                MoverFichero
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub GenerarClienteBalance()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCliente FROM Libregco.Clientes", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")

            For Each row As DataRow In Ds.Tables("Clientes").Rows
                sqlQ = "INSERT INTO Libregco.clientes_balances (IDCliente,IDMoneda,Balance,BalanceLetras,LimiteCredito,CargosGeneral) VALUES ('" + row.Item("IDCliente").ToString + "','" + txtIDMoneda.Text + "',0,'',0,0)"
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            ConLibregco.Close()
            Ds.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub


    Private Sub CreateFolder()
        Try
            If TypeConnection.Text = 1 Then
                Dim Exists As Boolean
                Exists = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Moneda")

                If Exists = True Then
                Else
                    System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Moneda")
                End If

            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub MoverFichero()
        Try
            If TypeConnection.Text = 1 Then
                CreateFolder()   'Verificamos si existe el folder del suplidor

                If PicFoto.Tag.ToString = "" Then
                    sqlQ = "UPDATE tipomoneda SET MonedaImagen='' WHERE IDTipoMoneda= '" + txtIDMoneda.Text + "'"
                    GuardarDatos()
                Else
                    'Verifico si existe la carpeta del suplidor
                    Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Moneda\" & txtIDMoneda.Text)
                    If Exists = False Then
                        System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Moneda\" & txtIDMoneda.Text)
                    End If


                    'Verifico si existe el archivo de por anexar
                    Dim ExistsFile As Boolean = System.IO.File.Exists(PicFoto.Tag.ToString)

                    If ExistsFile = True Then
                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Moneda\" & txtIDMoneda.Text & ".png"

                        If RutaDestino <> PicFoto.Tag.ToString Then
                            My.Computer.FileSystem.MoveFile(PicFoto.Tag.ToString, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If

                        sqlQ = "UPDATE tipomoneda SET MonedaImagen='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDTipoMoneda= '" + txtIDMoneda.Text + "'"
                        GuardarDatos()

                        'Devolver Nueva Ruta al los controles
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                        PicFoto.Image = System.Drawing.Image.FromStream(wFile)
                        PicFoto.Tag = RutaDestino
                        wFile.Close()
                    End If

                End If

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkAnimacion_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkAnimacion.CheckedChanged
        If chkAnimacion.Checked = True Then
            lblChkAnimacion.Text = 1
        Else
            lblChkAnimacion.Text = 0
        End If
    End Sub
End Class
