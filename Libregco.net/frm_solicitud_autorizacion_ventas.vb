Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_solicitud_autorizacion_ventas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDModulo As New Label
    Dim Permisos As New ArrayList

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If txtIDSolicitud.Text = "" Then
                MessageBox.Show("Escriba el No. de solicitud de autorización para realizar la consulta.", "Escriba el No. de solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                frm_solicitudes_autorizacion_pendientes.ShowDialog(Me)
            End If

            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDSolicitudAutorizacion,solicitudautorizacion.IDEquipo,ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,IDUsuarioSolicitud,Solicitante.Nombre as Solicitante,SolicitudAutorizacion.Fecha,IDPermisos,Permisos.Descripcion,Modulos.IDModulo,Modulo,Proceso,AccionesModulos.IDAccionesSuperClave,AccionesModulos.Descripcion as Acciones,SolicitudAutorizacion.Descripcion as DescripcionSolicitud FROM" & SysName.Text & "Solicitudautorizacion INNER JOIN Libregco.AreaImpresion on SolicitudAutorizacion.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Empleados as Solicitante on SolicitudAutorizacion.IDUsuarioSolicitud=Solicitante.IDEmpleado INNER JOIN" & SysName.Text & "Permisos on SolicitudAutorizacion.IDPermiso=Permisos.IDPermisos INNER JOIN Libregco.Modulos on Permisos.IDModulo=Modulos.IDModulo INNER JOIN" & SysName.Text & "ProcesosModulo on Permisos.IDProceso=ProcesosModulo.IDProcesosModulo INNER JOIN" & SysName.Text & "AccionesModulos on SolicitudAutorizacion.IDAccion=AccionesModulos.IDAccionesSuperClave where IDSolicitudAutorizacion='" + txtIDSolicitud.Text + "' and Aprobado=0", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "SolicitudAutorizacion")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("SolicitudAutorizacion")
            If Tabla.Rows.Count = 0 Then
                'MessageBox.Show("No se encontraron resultados.", "No se encontró", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                lblIDModulo.Text = (Tabla.Rows(0).Item("IDModulo"))
                lblFechaSolicitud.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss tt")
                lblEquipo.Text = "[" & (Tabla.Rows(0).Item("IDEquipo")) & "] " & (Tabla.Rows(0).Item("ComputerName"))
                lblAlmacen.Text = "[" & (Tabla.Rows(0).Item("IDAlmacen")) & "] " & (Tabla.Rows(0).Item("Almacen"))
                lblSucursal.Text = "[" & (Tabla.Rows(0).Item("IDSucursal")) & "] " & (Tabla.Rows(0).Item("Sucursal"))
                lblUsuario.Text = "[" & (Tabla.Rows(0).Item("IDUsuarioSolicitud")) & "] " & (Tabla.Rows(0).Item("Solicitante"))
                lblAutorizador.Text = "[" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] " & frm_inicio.lblNombre.Text
                IDModulo.Text = "[" & Tabla.Rows(0).Item("IDPermisos") & "] " & Tabla.Rows(0).Item("Modulo") & "/" & Tabla.Rows(0).Item("Proceso") & "/" & Tabla.Rows(0).Item("Descripcion")
                IDAccion.Text = "[" & Tabla.Rows(0).Item("Modulo") & "] " & (Tabla.Rows(0).Item("Acciones"))
                Descripcion.Text = Tabla.Rows(0).Item("DescripcionSolicitud")
                lblEstado.Text = "No autorizado"
                lblEstado.ForeColor = Color.Red
                txtIDSolicitud.Enabled = False
                btnBuscar.Enabled = False
                Timer1.Enabled = True

            End If



        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub frm_solicitud_autorizacion_ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        txtIDSolicitud.Clear()
        lblEquipo.Text = ""
        lblAlmacen.Text = ""
        lblSucursal.Text = ""
        lblUsuario.Text = ""
        IDAccion.Text = ""
        IDModulo.Text = ""
        lblAutorizador.Text = ""
        lblEstado.Text = ""
        txtSuperClave.Clear()
        lblFechaSolicitud.Text = ""
        Descripcion.Text = ""
        txtIDSolicitud.Enabled = True
        btnBuscar.Enabled = True
        btnAutorizar.Enabled = True
    End Sub

    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        CLOSE()
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Try
            If txtSuperClave.Text = "" Then
                MessageBox.Show("Escriba la superclave de configuración para continuar la autorización de la solicitud.", "Super clave de autorización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtSuperClave.Focus()
                Exit Sub
            End If

            Dim SuperClave As String
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Clave FROM" & SysName.Text & "modulos where IDModulo='" + lblIDModulo.Text + "'", ConMixta)
            SuperClave = Convert.ToString(cmd.ExecuteScalar())
            ConMixta.Close()

            If txtSuperClave.Text <> SuperClave Then
                MessageBox.Show("La super clave es incorrecta." & vbNewLine & vbNewLine & "Por favor verifique la contraseña y vuelta a intentarlo. De lo contrario, comuníquese con el soporte técnico del sistema.", "SuperClave Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                sqlQ = "UPDATE" & SysName.Text & "SolicitudAutorizacion SET Aprobado=1,IDUsuarioAprobado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "' WHERE IDSolicitudAutorizacion= (" + txtIDSolicitud.Text + ")"
                ConMixta.Open()
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
                ConMixta.Close()
                MessageBox.Show("La solicitud de autorización ha sido aprobada satisfactoriamente.", "Se ha aprobado la solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                lblEstado.Text = "Aprobado"
                lblEstado.ForeColor = Color.Blue

                btnAutorizar.Enabled = False
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        LimpiarDatos()
    End Sub
End Class