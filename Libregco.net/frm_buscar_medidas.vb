Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_medidas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_medidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
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
                cmd = New MySqlCommand("SELECT IDMedida,Medida,Abreviatura,Desactivar,Fraccionamiento,TipoMedida,PrecioAMedida,PrecioBMedida,PrecioCMedida,PrecioDMedida,IDMoneda,MedidaDinamica,CostoMedida FROM Medida where IDMedida like '%" + txtBuscar.Text + "%'", ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDMedida,Medida,Abreviatura,Desactivar,Fraccionamiento,TipoMedida,PrecioAMedida,PrecioBMedida,PrecioCMedida,PrecioDMedida,IDMoneda,MedidaDinamica,CostoMedida FROM Medida where Medida like '%" + txtBuscar.Text + "%'", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Medida")

            Bs.DataMember = "Medida"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvMedida.DataSource = Bs

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
        With DgvMedida
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 90
            .Columns(1).Width = 100
            .Columns(2).Width = 215
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
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

    Private Sub DgvMedida_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMedida.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvMedida.Focus()
    End Sub

    Private Sub DgvMedida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvMedida.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvMedida.Focus()
        End If
    End Sub

    Private Sub DgvMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvMedida.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvMedida.ColumnCount
                Dim NumRows As Integer = DgvMedida.RowCount
                Dim CurCell As DataGridViewCell = DgvMedida.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvMedida.CurrentCell = DgvMedida.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvMedida.CurrentCell = DgvMedida.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_medidas.Name Then
                frm_mant_medidas.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_mant_medidas.FillMedidas()
                frm_mant_medidas.txtMedida.Text = DgvMedida.CurrentRow.Cells(1).Value
                frm_mant_medidas.txtAbreviatura.Text = DgvMedida.CurrentRow.Cells(2).Value
                frm_mant_medidas.chkDesactivar.Checked = Convert.ToBoolean(DgvMedida.CurrentRow.Cells(3).Value)
                frm_mant_medidas.chkFraccionamiento.Checked = Convert.ToBoolean(DgvMedida.CurrentRow.Cells(4).Value)

                If CInt(DgvMedida.CurrentRow.Cells(5).Value) = 0 Then
                    frm_mant_medidas.rdbConstante.Checked = True
                Else
                    frm_mant_medidas.rdbDinamica.Checked = True
                End If

                frm_mant_medidas.txtPrecioA.EditValue = CDbl(DgvMedida.CurrentRow.Cells(6).Value).ToString("C")
                frm_mant_medidas.txtPrecioB.EditValue = CDbl(DgvMedida.CurrentRow.Cells(7).Value).ToString("C")
                frm_mant_medidas.txtPrecioC.EditValue = CDbl(DgvMedida.CurrentRow.Cells(8).Value).ToString("C")
                frm_mant_medidas.txtPrecioD.EditValue = CDbl(DgvMedida.CurrentRow.Cells(9).Value).ToString("C")

                frm_mant_medidas.cbxMoneda.EditValue = DgvMedida.CurrentRow.Cells(10).Value
                frm_mant_medidas.cbxMedida.Text = DgvMedida.CurrentRow.Cells(11).Value
                frm_mant_medidas.txtCosto.EditValue = CDbl(DgvMedida.CurrentRow.Cells(12).Value).ToString("C")
                frm_mant_medidas.RefrescarTabla()

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtMedida.Text = DgvMedida.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
                frm_reporte_orden_compra.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_orden_compra.txtMedida.Text = DgvMedida.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_ajustes_inventario.Name Then
                frm_reporte_ajustes_inventario.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_ajustes_inventario.txtMedida.Text = DgvMedida.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_transferencias_inventario.Name Then
                frm_reporte_transferencias_inventario.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_transferencias_inventario.txtMedida.Text = DgvMedida.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_conduces.Name Then
                frm_reporte_conduces.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_conduces.txtMedida.Text = DgvMedida.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_notas_pedidos.Name Then
                frm_reporte_notas_pedidos.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_notas_pedidos.txtMedida.Text = DgvMedida.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_conduce_reparacion.Name Then
                frm_reporte_conduce_reparacion.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_conduce_reparacion.txtMedida.Text = DgvMedida.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_listado_articulos.Name Then
                frm_reporte_listado_articulos.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_listado_articulos.txtMedida.Text = DgvMedida.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_entradas_reparacion.Name Then
                frm_reporte_entradas_reparacion.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_reporte_entradas_reparacion.txtMedida.Text = DgvMedida.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.name Then
                frm_actualizar_precios_costos.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_actualizar_precios_costos.txtMedida.Text = DgvMedida.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.name Then
                frm_actualizar_propiedades_articulos.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_actualizar_propiedades_articulos.txtMedida.Text = DgvMedida.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_ajuste_inventario.name Then
                frm_ajuste_inventario.txtIDMedida.Text = DgvMedida.CurrentRow.Cells(0).Value
                frm_ajuste_inventario.txtMedida.Text = DgvMedida.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


End Class