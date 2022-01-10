Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_conduce_entrada

    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_conduce_entrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDEntradaReparacion,EntradaReparacion.SecondID,EntradaReparacion.Fecha,Reparacion.IDSuplidor,Suplidor.Suplidor,Observaciones FROM entradareparacion INNER JOIN Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor where IDEntradaReparacion like '%" + txtBuscar.Text + "%' AND EntradaReparacion.Nulo=0 ORDER BY IDEntradaReparacion DESC", Con)
            ElseIf rdbSuplidor.Checked = True Then
                cmd = New MySqlCommand("SELECT IDEntradaReparacion,EntradaReparacion.SecondID,EntradaReparacion.Fecha,Reparacion.IDSuplidor,Suplidor.Suplidor,Observaciones FROM entradareparacion INNER JOIN Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor where Suplidor.Suplidor like '%" + txtBuscar.Text + "%' AND EntradaReparacion.Nulo=0 ORDER BY IDEntradaReparacion DESC", Con)
            ElseIf rdbObservacion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDEntradaReparacion,EntradaReparacion.SecondID,EntradaReparacion.Fecha,Reparacion.IDSuplidor,Suplidor.Suplidor,Observaciones FROM entradareparacion INNER JOIN Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor where Observaciones like '%" + txtBuscar.Text + "%' AND EntradaReparacion.Nulo=0 ORDER BY IDEntradaReparacion DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "EntradaReparacion")

            Bs.DataMember = "EntradaReparacion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvEntradas.DataSource = Bs

            PropiedadColumnsDvg()

            Dim IDEntrada As New Label
            IDEntrada.Text = DgvEntradas.Rows(0).Cells(0).Value

            Ds1.Clear()
            cmd1 = New MySqlCommand("SELECT IDEntradaReparacionDetalle,IDArticulo,Descripcion,Medida,CantidadRecibida FROM entradareparaciondetalle Where IDEntradaReparacion='" + IDEntrada.Text + "' ORDER BY IDEntradaReparacion DESC", Con)
            Adaptador = New MySqlDataAdapter(cmd1)
            Adaptador.Fill(Ds1, "EntradaDetalle")
            DgvEntradasDetalle.DataSource = Ds1
            DgvEntradasDetalle.DataMember = "EntradaDetalle"
            PropiedadDgvDetalles()

        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvEntradas
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "No. Entrada"
            .Columns(1).Width = 100
            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = 70

            .Columns(3).HeaderText = "ID Sup."
            .Columns(3).Width = 80
            .Columns(4).Width = 200
            .Columns(4).HeaderText = "Suplidor"
            .Columns(5).HeaderText = "Observaciones"
            .Columns(5).Width = 268
        End With
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvEntradas_SelectionChanged(sender As Object, e As EventArgs) Handles DgvEntradas.SelectionChanged
        RefrescarEntradasDetalle()
    End Sub

    Private Sub RefrescarEntradasDetalle()
        Try
            Dim IDEntrada As New Label
            IDEntrada.Text = DgvEntradas.CurrentRow.Cells(0).Value

            Ds1.Clear()
            cmd1 = New MySqlCommand("SELECT IDEntradaReparacionDetalle,IDArticulo,Descripcion,Medida,CantidadRecibida FROM entradareparaciondetalle Where IDEntradaReparacion='" + IDEntrada.Text + "' ORDER BY IDEntradaReparacion DESC", Con)
            Adaptador = New MySqlDataAdapter(cmd1)
            Adaptador.Fill(Ds1, "Entradasdetalle")
            DgvEntradasDetalle.DataSource = Ds1
            DgvEntradasDetalle.DataMember = "EntradasDetalle"
            PropiedadDgvDetalles()

        Catch ex As Exception
            DgvEntradasDetalle.DataSource = Nothing
            DgvEntradasDetalle.Rows.Clear()
        End Try
    End Sub

    Private Sub PropiedadDgvDetalles()
        With DgvEntradasDetalle
            .Columns(0).Visible = False
            .Columns(1).Width = 100
            .Columns(1).HeaderText = "ID Art."
            .Columns(2).Width = 400
            .Columns(2).HeaderText = "Descripción"
            .Columns(3).Width = 140
            .Columns(4).HeaderText = "Cant. Recibida"
            .Columns(4).Width = 120
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        RefrescarEntradasDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbSuplidor_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSuplidor.CheckedChanged
        RefrescarTabla()
        RefrescarEntradasDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbObservacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbObservacion.CheckedChanged
        RefrescarTabla()
        RefrescarEntradasDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
        RefrescarEntradasDetalle()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvEntradas.Focus()
    End Sub

    Private Sub DgvDevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvEntradas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvEntradas.Focus()
        End If
    End Sub

    Private Sub DgvEntradas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvEntradas.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvEntradas.ColumnCount
                Dim NumRows As Integer = DgvEntradas.RowCount
                Dim CurCell As DataGridViewCell = DgvEntradas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvEntradas.CurrentCell = DgvEntradas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvEntradas.CurrentCell = DgvEntradas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvEntradas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEntradas.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                LlenarFormularios()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim DsFiller As New DataSet
            Dim IDEntrada As New Label
            IDEntrada.Text = DgvEntradas.CurrentRow.Cells(0).Value

            DsFiller.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT EntradaReparacion.IDEntradaReparacion,EntradaReparacion.SecondID as SecondIDEntradaReparacion,EntradaReparacion.IDTipoDocumento,TipoDocumento.Documento,EntradaReparacion.Fecha,EntradaReparacion.Hora,EntradaReparacion.IDUsuario,Usuarios.Nombre as NombreEmpleado,EntradaReparacion.IDReparacion,Reparacion.SecondID AS SecondIDReparacion,Reparacion.Fecha as FechaReparacion,Reparacion.Hora as HoraReparacion,Reparacion.IDUsuario as IDUsuarioReparacion,UsuariosReparacion.Nombre as NombreUsuarioReparacion,Reparacion.IDSuplidor,Suplidor.Suplidor as NombreSuplidor,Suplidor.Balance,Reparacion.IDTipoOrden,TipoOrdenReparacion.Descripcion as TipoOrdenReparacion,Reparacion.IDStatusReparacion,StatusReparacion.Descripcion as StatusReparacion,Reparacion.FechaPrometida,Reparacion.Comentario,Reparacion.Motivo,EntradaReparacion.SecondID,EntradaReparacion.IDSucursal,Sucursal.Sucursal,EntradaReparacion.IDAlmacen,Almacen.Almacen,Observaciones,EntradaReparacion.Impreso,EntradaReparacion.Nulo FROM" & SysName.Text & "entradareparacion INNER JOIN" & SysName.Text & "Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN" & SysName.Text & "Empleados as Usuarios on EntradaReparacion.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Sucursal on EntradaReparacion.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on EntradaReparacion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "TipoDocumento on EntradaReparacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as UsuariosReparacion on Reparacion.IDUsuario=UsuariosReparacion.IDEmpleado INNER JOIN Libregco.StatusReparacion on Reparacion.IDStatusReparacion=StatusReparacion.IDStatusReparacion INNER JOIN Libregco.TipoOrdenReparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor Where IDEntradaReparacion='" + IDEntrada.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsFiller, "EntradaReparacion")
            ConMixta.Close()

            Dim Tabla As DataTable = DsFiller.Tables("EntradaReparacion")

            If Me.Owner.Name = frm_conduce_reparacion_entrada.Name Then
                frm_conduce_reparacion_entrada.txtIDEntrada.Text = (Tabla.Rows(0).Item("IDEntradaReparacion"))
                frm_conduce_reparacion_entrada.txtSecondID.Text = (Tabla.Rows(0).Item("SecondIDEntradaReparacion"))
                frm_conduce_reparacion_entrada.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_conduce_reparacion_entrada.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_conduce_reparacion_entrada.txtReparacion.Text = (Tabla.Rows(0).Item("SecondIDReparacion"))
                frm_conduce_reparacion_entrada.lblIDReparacion.Text = (Tabla.Rows(0).Item("IDReparacion"))
                frm_conduce_reparacion_entrada.txtTipoOrden.Text = (Tabla.Rows(0).Item("TipoOrdenReparacion"))
                frm_conduce_reparacion_entrada.txtStatusOrden.Text = (Tabla.Rows(0).Item("StatusReparacion"))
                frm_conduce_reparacion_entrada.txtMotivoGeneral.Text = (Tabla.Rows(0).Item("Motivo"))
                frm_conduce_reparacion_entrada.txtObservaciones.Text = (Tabla.Rows(0).Item("Observaciones"))
                frm_conduce_reparacion_entrada.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_conduce_reparacion_entrada.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("NombreSuplidor"))
                frm_conduce_reparacion_entrada.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                frm_conduce_reparacion_entrada.RefrescarDgvArticulos()
                frm_conduce_reparacion_entrada.FactStatus()

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_conduce_reparacion_entrada.chkNulo.Checked = True
                Else
                    frm_conduce_reparacion_entrada.chkNulo.Checked = False
                End If

                frm_conduce_reparacion_entrada.btnBuscarReparacion.Enabled = False
                Close()
                Exit Sub
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class