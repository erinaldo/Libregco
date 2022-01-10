Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_solicitudes_autorizacion_pendientes
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_solicitudes_autorizacion_pendientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        RefrescarSolicitudes()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub RefrescarSolicitudes()
        Try
            ConMixta.Open()

            DgvSolicitudes.Rows.Clear()
            Dim CmdDocumentos As New MySqlCommand("SELECT IDSolicitudAutorizacion,IDUsuarioSolicitud,Empleados.Nombre,Sucursal.Sucursal,Almacen.Almacen,ComputerName,SolicitudAutorizacion.Fecha,AccionesModulos.Descripcion FROM" & SysName.Text & "solicitudautorizacion INNER JOIN" & SysName.Text & "AccionesModulos on SolicitudAutorizacion.IDAccion=AccionesModulos.idAccionesSuperClave INNER JOIN" & SysName.Text & "Empleados on solicitudautorizacion.IDUsuarioSolicitud=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Areaimpresion areaimpresion on solicitudautorizacion.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal WHERE Aprobado=0 ORDER BY solicitudautorizacion.Fecha DESC", ConMixta)
            Dim LectorDocs As MySqlDataReader = CmdDocumentos.ExecuteReader

            While LectorDocs.Read
                DgvSolicitudes.Rows.Add(LectorDocs.GetValue(0), "[" & LectorDocs.GetValue(1) & "] " & LectorDocs.GetValue(2), LectorDocs.GetValue(3) & "/" & LectorDocs.GetValue(4) & "/" & LectorDocs.GetValue(5), LectorDocs.GetValue(6), LectorDocs.GetValue(7))
            End While
            LectorDocs.Close()
            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RefrescarSolicitudes()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DgvSolicitudes.SelectedRows.Count > 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_solicitud_autorizacion_ventas.Name Then
                frm_solicitud_autorizacion_ventas.txtIDSolicitud.Text = DgvSolicitudes.CurrentRow.Cells(0).Value
                frm_solicitud_autorizacion_ventas.btnBuscar.PerformClick()
            End If

            Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DgvSolicitudes.SelectedRows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la solicitud de autorización No." & DgvSolicitudes.CurrentRow.Cells(0).Value & " de la base de datos?", "Eliminar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                Con.Open()
                sqlQ = "Delete from SolicitudAutorizacion Where IDSolicitudAutorizacion= '" + DgvSolicitudes.CurrentRow.Cells(0).Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()
                Button3.PerformClick()
                MessageBox.Show("La solicitud de autorización ha sido eliminada satisfactoriamente.", "Eliminado completado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            
        End If
    End Sub
End Class