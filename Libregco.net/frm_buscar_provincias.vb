Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_provincias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_provincias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Provincias where IDProvincia like '%" + txtBuscar.Text + "%' ORDER BY IDProvincia DESC", ConLibregco)
            ElseIf rdbProvincia.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Provincias where Provincia like '%" + txtBuscar.Text + "%' ORDER BY Provincia ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Provincias")

            Bs.DataMember = "Provincias"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvProvincias.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
   PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbProvincia.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvProvincias
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Width = 370
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbProvincia.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvProvincias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvProvincias.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvProvincias.Focus()
    End Sub

    Private Sub DgvProvincias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvProvincias.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvProvincias.Focus()
        End If
    End Sub

    Private Sub DgvProvincias_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvProvincias.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvProvincias.ColumnCount
                Dim NumRows As Integer = DgvProvincias.RowCount
                Dim CurCell As DataGridViewCell = DgvProvincias.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvProvincias.CurrentCell = DgvProvincias.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvProvincias.CurrentCell = DgvProvincias.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_provincias.Name Then
                frm_mant_provincias.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_mant_provincias.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value
                FillChkBox()

            ElseIf Me.Owner.Name = frm_mant_municipios.Name Then
                frm_mant_municipios.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_mant_municipios.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_ventas.Name Then
                frm_reporte_ventas.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_ventas.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                frm_reporte_detalle_ventas.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_detalle_ventas.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_clientes.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
                frm_reporte_devolucion_ventas.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_devolucion_ventas.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cotizacion.Name Then
                frm_reporte_cotizacion.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_cotizacion.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
                frm_reporte_registro_facturas.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_registro_facturas.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
                frm_reporte_nota_debito_credito_cxc.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_nota_debito_credito_cxc.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
                frm_reporte_cobros_facturas.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_cobros_facturas.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                frm_reporte_cuentas_por_cobrar.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_cobrar.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_suplidor.Name Then
                frm_reporte_suplidor.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_suplidor.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_registro_facturas_cxp.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_pagar.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_pagos_facturas.Name Then
                frm_reporte_pagos_facturas.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_pagos_facturas.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDProvincia.Text = DgvProvincias.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtProvincia.Text = DgvProvincias.CurrentRow.Cells(1).Value


            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        Dim Nulo As New Label
        Nulo.Text = DgvProvincias.CurrentRow.Cells(2).Value

        If frm_mant_provincias.Visible = True Then
            If Nulo.Text = 0 Then
                frm_mant_provincias.chkNulo.Checked = False
            Else
                frm_mant_provincias.chkNulo.Checked = True
            End If
        End If
    End Sub

End Class