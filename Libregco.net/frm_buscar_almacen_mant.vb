Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_almacen_mant
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Friend Control As String

    Private Sub frm_buscar_almacen_mant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
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
                cmd = New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,Almacen.Desactivar,Sucursal.IDSucursal,Sucursal,Almacen.PuntoEmision FROM Almacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal where Almacen.IDAlmacen like '%" + txtBuscar.Text + "%' Order by IDAlmacen DESC", Con)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,Almacen.Desactivar,Sucursal.IDSucursal,Sucursal,Almacen.PuntoEmision FROM Almacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal where Almacen like '%" + txtBuscar.Text + "%' Order by Almacen ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Almacen")

            Bs.DataMember = "Almacen"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvAlmacen.DataSource = Bs

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
        With DgvAlmacen
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).HeaderText = "Almacén"
            .Columns(1).Width = 322
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
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

    Private Sub DgvAlmacen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAlmacen.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvAlmacen.Focus()
    End Sub

    Private Sub DgvAlmacen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvAlmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvAlmacen.Focus()
        End If
    End Sub

    Private Sub DgvAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvAlmacen.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvAlmacen.ColumnCount
                Dim NumRows As Integer = DgvAlmacen.RowCount
                Dim CurCell As DataGridViewCell = DgvAlmacen.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvAlmacen.CurrentCell = DgvAlmacen.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvAlmacen.CurrentCell = DgvAlmacen.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_almacen.Name Then
                frm_mant_almacen.txtCodigo.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_mant_almacen.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value
                frm_mant_almacen.txtIDSucursal.Text = DgvAlmacen.CurrentRow.Cells(3).Value
                frm_mant_almacen.txtSucursal.Text = DgvAlmacen.CurrentRow.Cells(4).Value
                frm_mant_almacen.txtPuntoEmision.Text = CStr(DgvAlmacen.CurrentRow.Cells(5).Value).PadLeft(3, "0")
                If DgvAlmacen.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_almacen.chkDesactivar.Checked = False
                Else
                    frm_mant_almacen.chkDesactivar.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_consulta_ajuste_inventario.Name Then
                frm_consulta_ajuste_inventario.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_consulta_ajuste_inventario.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_consulta_transferencias.Name Then
                If frm_consulta_transferencias.AlmControl = 0 Then
                    frm_consulta_transferencias.txtIDAlmacenEnt.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                    frm_consulta_transferencias.txtAlmacenEnt.Text = DgvAlmacen.CurrentRow.Cells(1).Value
                End If
                If frm_consulta_transferencias.AlmControl = 1 Then
                    frm_consulta_transferencias.txtIDAlmacenSal.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                    frm_consulta_transferencias.txtAlmacenSal.Text = DgvAlmacen.CurrentRow.Cells(1).Value
                End If

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_ventas.Name Then
                frm_reporte_ventas.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_ventas.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                frm_reporte_detalle_ventas.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_detalle_ventas.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
                frm_reporte_devolucion_ventas.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_devolucion_ventas.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_compras.Name Then
                frm_reporte_compras.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_compras.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                frm_reporte_detalle_compras.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_detalle_compras.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_devolucion_compras.Name Then
                frm_reporte_devolucion_compras.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_devolucion_compras.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_inventario_fecha.Name Then
                frm_reporte_inventario_fecha.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_inventario_fecha.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_movimientos_inventario.Name Then
                frm_reporte_movimientos_inventario.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_movimientos_inventario.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_ajustes_inventario.Name Then
                frm_reporte_ajustes_inventario.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_ajustes_inventario.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_conduce_reparacion.Name Then
                frm_reporte_conduce_reparacion.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_conduce_reparacion.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_transferencias_inventario.Name Then
                If Control = 1 Then
                    frm_reporte_transferencias_inventario.txtIDAlmacenEnt.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                    frm_reporte_transferencias_inventario.txtAlmacenEnt.Text = DgvAlmacen.CurrentRow.Cells(1).Value
                ElseIf Control = 2 Then
                    frm_reporte_transferencias_inventario.txtIDAlmacenSal.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                    frm_reporte_transferencias_inventario.txtAlmacenSal.Text = DgvAlmacen.CurrentRow.Cells(1).Value
                End If

            ElseIf Me.Owner.Name = frm_reporte_conduces.Name Then
                frm_reporte_conduces.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_conduces.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
                frm_reporte_registro_facturas.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_registro_facturas.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
                frm_reporte_nota_debito_credito_cxc.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_nota_debito_credito_cxc.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
                frm_reporte_cobros_facturas.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cobros_facturas.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                frm_reporte_cuentas_por_cobrar.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_cobrar.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_pagares.Name Then
                frm_reporte_pagares.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_pagares.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_series_garantias.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_entradas_reparacion.Name Then
                frm_reporte_entradas_reparacion.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_entradas_reparacion.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_solicitudes_clientes.Name Then
                frm_reporte_solicitudes_clientes.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_solicitudes_clientes.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_otros_ingresos.Name Then
                frm_reporte_otros_ingresos.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_otros_ingresos.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cobros_adelantados.Name Then
                frm_reporte_cobros_adelantados.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cobros_adelantados.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cheques_devueltos.Name Then
                frm_reporte_cheques_devueltos.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cheques_devueltos.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cheques_futuros.Name Then
                frm_reporte_cheques_futuros.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cheques_futuros.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_acuerdos_pago.Name Then
                frm_reporte_acuerdos_pago.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_acuerdos_pago.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_registro_facturas_cxp.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_pagar.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_autorizacion_equipos.Name Then
                frm_autorizacion_equipos.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_autorizacion_equipos.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value
                frm_autorizacion_equipos.lblSucursal.Text = DgvAlmacen.CurrentRow.Cells(4).Value

            ElseIf Me.Owner.Name = frm_reporte_pagos_facturas.Name Then
                frm_reporte_pagos_facturas.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_pagos_facturas.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_notas_debito_credito_cxp.Name Then
                frm_reporte_notas_debito_credito_cxp.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_notas_debito_credito_cxp.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_egresos.Name Then
                frm_reporte_egresos.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_egresos.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_nomina.Name Then
                frm_reporte_nomina.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_nomina.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_vacaciones.Name Then
                frm_reporte_vacaciones.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_vacaciones.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_deducciones.Name Then
                frm_reporte_deducciones.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_deducciones.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_prestamos_empleados.Name Then
                frm_reporte_prestamos_empleados.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_prestamos_empleados.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cobros_prestamos.Name Then
                frm_reporte_cobros_prestamos.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cobros_prestamos.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cobros_prestamos.Name Then
                frm_reporte_cobros_prestamos.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cobros_prestamos.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_movimientos_bancarios.Name Then
                frm_reporte_movimientos_bancarios.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_movimientos_bancarios.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cheques.Name Then
                frm_reporte_cheques.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cheques.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_solicitud_cheques.Name Then
                frm_reporte_solicitud_cheques.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_solicitud_cheques.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_entrega_cobros.Name Then
                frm_reporte_entrega_cobros.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_entrega_cobros.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_titulaciones.Name Then
                frm_reporte_titulaciones.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_titulaciones.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuadre_de_caja.Name Then
                frm_reporte_cuadre_de_caja.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_reporte_cuadre_de_caja.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_consulta_cortedecaja.Name Then
                frm_consulta_cortedecaja.txtIDAlmacen.Text = DgvAlmacen.CurrentRow.Cells(0).Value
                frm_consulta_cortedecaja.txtAlmacen.Text = DgvAlmacen.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    
End Class