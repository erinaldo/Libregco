Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_solicitud_cliente

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet
    Friend Control As String

    Private Sub frm_buscar_solicitud_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDMemoC,memosclientes.SecondID,Fecha,MemosClientes.IDCliente,Clientes.Nombre,TiposMemos.Clase,Prioridad.Prioridad FROM" & SysName.Text & "memosclientes INNER JOIN" & SysName.Text & "Sucursal on MemosClientes.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on MemosClientes.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Clientes on MemosClientes.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TiposMemos on MemosClientes.IDTipoMemo=TiposMemos.IDTiposMemos INNER JOIN Libregco.Prioridad on MemosClientes.IDPrioridad=Prioridad.IDPrioridad INNER JOIN" & SysName.Text & "Empleados as Usuarios on MemosClientes.IDUsuario=Usuarios.IDEmpleado where MemosClientes.SecondID like '%" + txtBuscar.Text + "%' Order by IDMemoC DESC", ConMixta)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDMemoC,memosclientes.SecondID,Fecha,MemosClientes.IDCliente,Clientes.Nombre,TiposMemos.Clase,Prioridad.Prioridad FROM" & SysName.Text & "memosclientes INNER JOIN" & SysName.Text & "Sucursal on MemosClientes.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on MemosClientes.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Clientes on MemosClientes.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TiposMemos on MemosClientes.IDTipoMemo=TiposMemos.IDTiposMemos INNER JOIN Libregco.Prioridad on MemosClientes.IDPrioridad=Prioridad.IDPrioridad INNER JOIN" & SysName.Text & "Empleados as Usuarios on MemosClientes.IDUsuario=Usuarios.IDEmpleado where Clientes.Nombre like '%" + txtBuscar.Text + "%' Order by IDMemoC DESC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Solicitudes")

            Bs.DataMember = "Solicitudes"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvSolicitudes.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvSolicitudes
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = 80
            .Columns(3).Width = 70
            .Columns(3).HeaderText = "Cód. Cl"
            .Columns(4).Width = 200
            .Columns(5).Width = 170
            .Columns(6).Width = 100
        End With
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvSolicitudes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSolicitudes.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvSolicitudes.Focus()
    End Sub

    Private Sub DgvSolicitudes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvSolicitudes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvSolicitudes.Focus()
        End If
    End Sub

    Private Sub DgvSolicitudes_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvSolicitudes.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvSolicitudes.ColumnCount
                Dim NumRows As Integer = DgvSolicitudes.RowCount
                Dim CurCell As DataGridViewCell = DgvSolicitudes.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvSolicitudes.CurrentCell = DgvSolicitudes.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvSolicitudes.CurrentCell = DgvSolicitudes.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDMemoC As New Label
            lblIDMemoC.Text = DgvSolicitudes.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDMemoC,MemosClientes.SecondID,Fecha,Hora,MemosClientes.IDSucursal,Sucursal.Sucursal,MemosClientes.IDAlmacen,Almacen.Almacen,Usuarios.Nombre as NombreUsuario,IDUsuario,MemosClientes.IDCliente,Clientes.Nombre,Identificacion,BalanceGeneral,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,MemosClientes.IDTipoMemo,TiposMemos.Clase,MemosClientes.IDPrioridad,Prioridad.Prioridad,Adjunto,Comentario,Conclusion,FechaLimite,Finalizado FROM" & SysName.Text & "memosclientes INNER JOIN" & SysName.Text & "Sucursal on MemosClientes.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on MemosClientes.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Clientes on MemosClientes.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TiposMemos on MemosClientes.IDTipoMemo=TiposMemos.IDTiposMemos INNER JOIN Libregco.Prioridad on MemosClientes.IDPrioridad=Prioridad.IDPrioridad INNER JOIN" & SysName.Text & "Empleados as Usuarios on MemosClientes.IDUsuario=Usuarios.IDEmpleado Where IDMemoC='" + lblIDMemoC.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "MemosClientes")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("MemosClientes")

            If Me.Owner.Name = frm_mant_memos_cliente.Name Then
                frm_mant_memos_cliente.txtIDMemoC.Text = (Tabla.Rows(0).Item("IDMemoc"))
                frm_mant_memos_cliente.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_mant_memos_cliente.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_mant_memos_cliente.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_mant_memos_cliente.txtIDTipoMemo.Text = (Tabla.Rows(0).Item("IDTipoMemo"))
                frm_mant_memos_cliente.txtTipoMemo.Text = (Tabla.Rows(0).Item("Clase"))
                frm_mant_memos_cliente.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_mant_memos_cliente.txtConclusion.Text = (Tabla.Rows(0).Item("Conclusion"))
                frm_mant_memos_cliente.dtpFechaLimite.Value = (Tabla.Rows(0).Item("FechaLimite"))
                frm_mant_memos_cliente.lblFinalizar.Text = (Tabla.Rows(0).Item("Finalizado"))
                frm_mant_memos_cliente.lblIDUsuario.Text = (Tabla.Rows(0).Item("IDUsuario"))
                frm_mant_memos_cliente.lblIDPrioridad.Text = (Tabla.Rows(0).Item("IDPrioridad"))
                frm_mant_memos_cliente.CbxPrioridad.Text = (Tabla.Rows(0).Item("Prioridad"))

                If (Tabla.Rows(0).Item("Adjunto")) = "" Then
                Else
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream((Tabla.Rows(0).Item("Adjunto")), FileMode.Open, FileAccess.Read)
                    frm_mant_memos_cliente.RutaDocumento.Text = (Tabla.Rows(0).Item("Adjunto"))
                    frm_mant_memos_cliente.PicDoc.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                End If

                If (Tabla.Rows(0).Item("Finalizado")) = 1 Then
                    frm_mant_memos_cliente.chkFinalizado.Checked = True
                Else
                    frm_mant_memos_cliente.chkFinalizado.Checked = False
                End If

                frm_mant_memos_cliente.RefrescarAvances()

            ElseIf Me.Owner.Name = frm_reporte_progreso_solicitud.Name Then
                frm_reporte_progreso_solicitud.txtIDSolicitud.Text = (Tabla.Rows(0).Item("IDMemoc"))
                frm_reporte_progreso_solicitud.txtSolicitud.Text = (Tabla.Rows(0).Item("SecondID"))

            ElseIf Me.Owner.Name = frm_consulta_progreso_solicitud.Name Then
                frm_consulta_progreso_solicitud.txtIDSolicitud.Text = (Tabla.Rows(0).Item("IDMemoc"))
                frm_consulta_progreso_solicitud.txtSolicitud.Text = (Tabla.Rows(0).Item("SecondID"))
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class