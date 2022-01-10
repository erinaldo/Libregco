Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_sucursal

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet
    Friend Control As String

    Private Sub frm_buscar_sucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT Sucursal.IDSucursal,Sucursal FROM Sucursal where Sucursal.IDSucursal like '%" + txtBuscar.Text + "%' Order by IDSucursal DESC", Con)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT Sucursal.IDSucursal,Sucursal FROM Sucursal  where Sucursal.Sucursal like '%" + txtBuscar.Text + "%' Order by Sucursal ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Sucursal")

            Bs.DataMember = "Sucursal"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvSucursal.DataSource = Bs

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
        With DgvSucursal
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Sucursal"
            .Columns(1).Width = 500

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

    Private Sub DgvSucursal_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSucursal.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvSucursal.Focus()
    End Sub

    Private Sub DgvSucursal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvSucursal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvSucursal.Focus()
        End If
    End Sub

    Private Sub DgvSucursal_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvSucursal.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvSucursal.ColumnCount
                Dim NumRows As Integer = DgvSucursal.RowCount
                Dim CurCell As DataGridViewCell = DgvSucursal.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvSucursal.CurrentCell = DgvSucursal.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvSucursal.CurrentCell = DgvSucursal.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim IDSucursal As New Label
            IDSucursal.Text = DgvSucursal.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * from Sucursal Where IDSucursal='" + IDSucursal.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Sucursal")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Sucursal")

            If Me.Owner.Name = frm_mant_almacen.Name Then
                frm_mant_almacen.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_mant_almacen.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_mant_sucursal.Name Then
                frm_mant_sucursal.txtCodigo.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_mant_sucursal.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))
                frm_mant_sucursal.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
                frm_mant_sucursal.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))
                frm_mant_sucursal.txtProvincia.Text = (Tabla.Rows(0).Item("Provincia"))
                frm_mant_sucursal.txtTelefono0.Text = (Tabla.Rows(0).Item("Telefono"))
                frm_mant_sucursal.txtTelefono1.Text = (Tabla.Rows(0).Item("Telefono1"))
                frm_mant_sucursal.txtTelefono2.Text = (Tabla.Rows(0).Item("Telefono2"))
                frm_mant_sucursal.txtFax.Text = (Tabla.Rows(0).Item("Fax"))
                frm_mant_sucursal.txtEmail.Text = (Tabla.Rows(0).Item("Email"))
                frm_mant_sucursal.txtDivisiondeNegocios.Text = CStr(Tabla.Rows(0).Item("DivisionNegocio")).PadLeft(2, "0")

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_mant_sucursal.chkDesactivar.Checked = False
                Else
                    frm_mant_sucursal.chkDesactivar.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_mant_empleados.Name Then
                frm_mant_empleados.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_mant_empleados.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
                frm_reporte_registro_facturas.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_registro_facturas.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_vacaciones.Name Then
                frm_reporte_vacaciones.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_vacaciones.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
                frm_reporte_nota_debito_credito_cxc.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_nota_debito_credito_cxc.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
                frm_reporte_cobros_facturas.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cobros_facturas.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                frm_reporte_cuentas_por_cobrar.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cuentas_por_cobrar.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_pagares.Name Then
                frm_reporte_pagares.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_pagares.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_series_garantias.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_solicitudes_clientes.Name Then
                frm_reporte_solicitudes_clientes.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_solicitudes_clientes.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_otros_ingresos.Name Then
                frm_reporte_otros_ingresos.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_otros_ingresos.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cobros_adelantados.Name Then
                frm_reporte_cobros_adelantados.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cobros_adelantados.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cheques_devueltos.Name Then
                frm_reporte_cheques_devueltos.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cheques_devueltos.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cheques_futuros.Name Then
                frm_reporte_cheques_futuros.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cheques_futuros.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_consulta_recibos_ingresos.Name Then
                frm_consulta_recibos_ingresos.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_consulta_recibos_ingresos.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_consulta_otros_ingresos.Name Then
                frm_consulta_otros_ingresos.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_consulta_otros_ingresos.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_consulta_acuerdo_pago.Name Then
                frm_consulta_acuerdo_pago.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_consulta_acuerdo_pago.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_acuerdos_pago.Name Then
                frm_reporte_acuerdos_pago.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_acuerdos_pago.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_registro_facturas_cxp.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cuentas_por_pagar.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))


            ElseIf Me.Owner.Name = frm_reporte_pagos_facturas.Name Then
                frm_reporte_pagos_facturas.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_pagos_facturas.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))


            ElseIf Me.Owner.Name = frm_reporte_notas_debito_credito_cxp.Name Then
                frm_reporte_notas_debito_credito_cxp.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_notas_debito_credito_cxp.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_egresos.Name Then
                frm_reporte_egresos.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_egresos.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_consulta_egresos_cxp.Name Then
                frm_consulta_egresos_cxp.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_consulta_egresos_cxp.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_consulta_nota_debito_credito.Name Then
                frm_consulta_nota_debito_credito.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_consulta_nota_debito_credito.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_empleados.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_nomina.Name Then
                frm_reporte_nomina.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_nomina.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_deducciones.Name Then
                frm_reporte_deducciones.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_deducciones.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_prestamos_empleados.Name Then
                frm_reporte_prestamos_empleados.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_prestamos_empleados.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cobros_prestamos.Name Then
                frm_reporte_cobros_prestamos.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cobros_prestamos.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_movimientos_bancarios.Name Then
                frm_reporte_movimientos_bancarios.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_movimientos_bancarios.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cheques.Name Then
                frm_reporte_cheques.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cheques.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_solicitud_cheques.Name Then
                frm_reporte_solicitud_cheques.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_solicitud_cheques.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_entrega_cobros.Name Then
                frm_reporte_entrega_cobros.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_entrega_cobros.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_titulaciones.Name Then
                frm_reporte_titulaciones.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_titulaciones.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            ElseIf Me.Owner.Name = frm_reporte_cuadre_de_caja.Name Then
                frm_reporte_cuadre_de_caja.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
                frm_reporte_cuadre_de_caja.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class