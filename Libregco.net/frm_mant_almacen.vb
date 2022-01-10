Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_almacen

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkDesactivar As New Label
    Dim Permisos As New ArrayList
    Dim TypeofMetode As String
    Private Sub frm_mant_almacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        SetConfiguracion()
        LimpiarDatos()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub SetConfiguracion()

        Con.Open()
        'Verificar tipo de NCF
        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=75", Con)
        TypeofMetode = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If TypeofMetode = 3 Then
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            lblchkDesactivar.Text = 1
            InhabilitarAlmacen()
        Else
            lblchkDesactivar.Text = 0
            HabilitarAlmacen()
        End If
    End Sub

    Private Sub HabilitarAlmacen()
        txtCodigo.Enabled = True
        txtAlmacen.Enabled = True
        txtPuntoEmision.Enabled = True
    End Sub

    Private Sub InhabilitarAlmacen()
        txtCodigo.Enabled = False
        txtAlmacen.Enabled = False
        txtPuntoEmision.Enabled = False
    End Sub

    Private Sub LimpiarDatos()
        txtCodigo.Clear()
        txtAlmacen.Clear()
        txtIDSucursal.Clear()
        txtSucursal.Clear()
        txtPuntoEmision.Clear()
        lblchkDesactivar.Text = 0
        chkDesactivar.Checked = False
        txtAlmacen.Focus()
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            ConLibregcoMain.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd.ExecuteNonQuery()
            ConLibregcoMain.Close()

        Catch ex As Exception
            ConLibregco.Close()
            ConLibregcoMain.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub UltAlmacen()
        If txtCodigo.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDAlmacen from Almacen where IDAlmacen= (Select Max(IDAlmacen) from Almacen)", Con)
            txtCodigo.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtAlmacen.Text = "" Then
            MessageBox.Show("Escriba el nombre del nuevo almacén para procesarlo.", "Nombre de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtAlmacen.Focus()
            Exit Sub
        ElseIf txtIDSucursal.Text = "" Then
            MessageBox.Show("Seleccione la sucursal a la que le pertenece el almacén.", "Nombre de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSucursal.PerformClick()
            Exit Sub
        ElseIf TypeofMetode <> 3 Then
            If Len(Replace(txtPuntoEmision.Text, "_", "")) < 3 Then
                MessageBox.Show("Escriba el número punto de emisión del almacén que desea procesar.", "Escriba el punto de emisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPuntoEmision.Focus()
                Exit Sub
            End If
        End If
        If txtCodigo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el almacén " & txtAlmacen.Text & " en la base de datos?", "Guardar Nuevo Almacén", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Almacen (Almacen,Desactivar,IDSucursal,PuntoEmision) VALUES ('" + txtAlmacen.Text + "','" + lblchkDesactivar.Text + "','" + txtIDSucursal.Text + "','" + txtPuntoEmision.Text + "')"
                GuardarDatos()
                UltAlmacen()
                ProcesarExistencias()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Almacen SET Almacen='" + txtAlmacen.Text + "',Desactivar='" + lblchkDesactivar.Text + "',IDSucursal='" + txtIDSucursal.Text + "',PuntoEmision='" + txtPuntoEmision.Text + "' WHERE IDAlmacen= (" + txtCodigo.Text + ")"
                GuardarDatos()
                ProcesarExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub ProcesarExistencias()
        Try

            Dim IDPrecioArticulo, IDExistencia As New Label

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDExistencia,IDPrecioArticulo,IDAlmacen,Existencia FROM Existencia", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Existencia")

            Dim TablaExistencia As DataTable = Ds.Tables("Existencia")

            For Each FilaExistencia As DataRow In TablaExistencia.Rows
                IDPrecioArticulo.Text = FilaExistencia.Item("IDPrecioArticulo")

                cmd = New MySqlCommand("SELECT IDExistencia FROM Existencia Where IDPrecioArticulo= '" + IDPrecioArticulo.Text + "' and IDAlmacen='" + txtCodigo.Text + "'", ConLibregco)
                IDExistencia.Text = Convert.ToString(cmd.ExecuteScalar())

                If IDExistencia.Text = "" Then
                    sqlQ = "INSERT INTO Existencia (IDPrecioArticulo,IDAlmacen,Existencia) VALUES ('" + IDPrecioArticulo.Text + "','" + txtCodigo.Text + "',0)"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                End If
            Next

            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtAlmacen.Text = "" Then
            MessageBox.Show("Escriba el nombre del nuevo almacén para procesarlo.", "Nombre de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtAlmacen.Focus()
            Exit Sub
        ElseIf txtIDSucursal.Text = "" Then
            MessageBox.Show("Seleccione la sucursal a la que le pertenece el almacén.", "Nombre de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSucursal.PerformClick()
            Exit Sub
        ElseIf TypeofMetode <> 3 Then
            If Len(Replace(txtPuntoEmision.Text, "_", "")) < 3 Then
                MessageBox.Show("Escriba el número punto de emisión del almacén que desea procesar.", "Escriba el punto de emisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPuntoEmision.Focus()
                Exit Sub
            End If
        End If

        If txtCodigo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el almacén " & txtAlmacen.Text & " en la base de datos?", "Guardar Nuevo Almacén", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Almacen (Almacen,Desactivar,IDSucursal,PuntoEmision) VALUES ('" + txtAlmacen.Text + "','" + lblchkDesactivar.Text + "','" + txtIDSucursal.Text + "','" + txtPuntoEmision.Text + "')"
                GuardarDatos()
                UltAlmacen()
                ProcesarExistencias()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Almacen SET Almacen='" + txtAlmacen.Text + "',Desactivar='" + lblchkDesactivar.Text + "',IDSucursal='" + txtIDSucursal.Text + "',PuntoEmision='" + txtPuntoEmision.Text + "' WHERE IDAlmacen= (" + txtCodigo.Text + ")"
                GuardarDatos()
                ProcesarExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_almacen_mant.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El almacén " & txtAlmacen.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Almacén", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                chkDesactivar.Checked = False
                sqlQ = "UPDATE Almacen SET Almacen='" + txtAlmacen.Text + "',Desactivar='" + lblchkDesactivar.Text + "',IDSucursal='" + txtIDSucursal.Text + "',PuntoEmision='" + txtPuntoEmision.Text + "' WHERE IDAlmacen= (" + txtCodigo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtCodigo.Text = "" Then
            MessageBox.Show("No hay un registro de almacén abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            frm_buscar_almacen_mant.ShowDialog(Me)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro del almacén " & txtAlmacen.Text & " del sistema?", "Desactivar Almacén", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                chkDesactivar.Checked = True
                sqlQ = "UPDATE Almacen SET Almacen='" + txtAlmacen.Text + "',Desactivar='" + lblchkDesactivar.Text + "',IDSucursal='" + txtIDSucursal.Text + "',PuntoEmision='" + txtPuntoEmision.Text + "' WHERE IDAlmacen= (" + txtCodigo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub btnBuscarSucursal_Click(sender As Object, e As EventArgs) Handles btnBuscarSucursal.Click
        frm_buscar_sucursal.ShowDialog(Me)
    End Sub
End Class