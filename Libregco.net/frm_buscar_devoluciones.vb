Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_devoluciones

    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds0, Ds1 As New DataSet

    Private Sub frm_buscar_devoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
        RefrescarDevolucionDetalle()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT DevolucionVenta.IDDevolucionVenta,DevolucionVenta.SecondID,FacturaDatos.SecondID,DevolucionVenta.Fecha,Tipo,Neto,DiasTransaccion FROM" & SysName.Text & "devolucionventa INNER JOIN Libregco.tipodevolucion on Devolucionventa.IDTipoDevolucion=TipoDevolucion.IDTipoDevolucion INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos where IDDevolucionVenta like '%" + txtBuscar.Text + "%' AND DevolucionVenta.Nulo=0 ORDER BY IDDevolucionVenta DESC", ConMixta)
            ElseIf rdbFactura.Checked = True Then
                cmd = New MySqlCommand("SELECT DevolucionVenta.IDDevolucionVenta,DevolucionVenta.SecondID,FacturaDatos.SecondID,DevolucionVenta.Fecha,Tipo,Neto,DiasTransaccion FROM" & SysName.Text & " devolucionventa INNER JOIN Libregco.tipodevolucion on Devolucionventa.IDTipoDevolucion=TipoDevolucion.IDTipoDevolucion INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos where IDFactura like '%" + txtBuscar.Text + "%' AND DevolucionVenta.Nulo=0 ORDER BY IDFactura DESC", ConMixta)
            ElseIf rdbFecha.Checked = True Then
                cmd = New MySqlCommand("SELECT DevolucionVenta.IDDevolucionVenta,DevolucionVenta.SecondID,FacturaDatos.SecondID,DevolucionVenta.Fecha,Tipo,Neto,DiasTransaccion FROM" & SysName.Text & " devolucionventa INNER JOIN Libregco.tipodevolucion on Devolucionventa.IDTipoDevolucion=TipoDevolucion.IDTipoDevolucion INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos where Fecha like '%" + txtBuscar.Text + "%' AND DevolucionVenta.Nulo=0 ORDER BY Fecha DESC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Devolucionventa")

            Bs.DataMember = "Devolucionventa"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvDevoluciones.DataSource = Bs

            PropiedadColumnsDvg()

            Dim IDDevolucion As New Label
            IDDevolucion.Text = DgvDevoluciones.Rows(0).Cells(0).Value

            Ds1.Clear()
            cmd1 = New MySqlCommand("SELECT IDDevolucionVentaDetalle,IDArticulo,Descripcion,Medida,CantDevuelta,PrecioDevuelto FROM" & SysName.Text & "devolucionventadetalle Where IDDevolucionVenta='" + IDDevolucion.Text + "' ORDER BY IDDevolucionVentaDetalle DESC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd1)
            Adaptador.Fill(Ds1, "devolucionventadetalle")
            DgvDevDetalle.DataSource = Ds1
            DgvDevDetalle.DataMember = "devolucionventadetalle"
            PropiedadDgvDetalles()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvDevoluciones
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "No. Devolución"
            .Columns(1).Width = 115
            .Columns(2).HeaderText = "No. Factura"
            .Columns(2).Width = 100
            .Columns(3).HeaderText = "Fecha"
            .Columns(3).Width = 80
            .Columns(4).HeaderText = "Tipo de Devolución"
            .Columns(4).Width = 200
            .Columns(5).Width = 120
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(6).HeaderText = "Días Trans."
            .Columns(6).Width = 110
        End With
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvDevoluciones_SelectionChanged(sender As Object, e As EventArgs) Handles DgvDevoluciones.SelectionChanged
        RefrescarDevolucionDetalle()
    End Sub

    Private Sub RefrescarDevolucionDetalle()
        Try
            Dim IDDevolucion As New Label
            IDDevolucion.Text = DgvDevoluciones.CurrentRow.Cells(0).Value

            Ds1.Clear()
            cmd1 = New MySqlCommand("SELECT IDDevolucionVentaDetalle,IDArticulo,Descripcion,Medida,CantDevuelta,PrecioDevuelto FROM" & SysName.Text & "devolucionventadetalle Where IDDevolucionVenta='" + IDDevolucion.Text + "' ORDER BY IDDevolucionVentaDetalle DESC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd1)
            Adaptador.Fill(Ds1, "devolucionventadetalle")
            DgvDevDetalle.DataSource = Ds1
            DgvDevDetalle.DataMember = "devolucionventadetalle"
            PropiedadDgvDetalles()

        Catch ex As Exception
            DgvDevDetalle.DataSource = Nothing
            DgvDevDetalle.Rows.Clear()
        End Try
    End Sub

    Private Sub PropiedadDgvDetalles()
        With DgvDevDetalle
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 90
            .Columns(1).HeaderText = "Cód. Art."
            .Columns(1).Width = 85
            .Columns(2).Width = 250
            .Columns(2).HeaderText = "Descripción"
            .Columns(3).Width = 80
            .Columns(4).HeaderText = "Cant. Dev."
            .Columns(4).Width = 100
            .Columns(5).HeaderText = "Precio Dev."
            .Columns(5).Width = 140
            .Columns(5).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        RefrescarDevolucionDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFactura.CheckedChanged
        RefrescarTabla()
        RefrescarDevolucionDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFecha.CheckedChanged
        RefrescarTabla()
        RefrescarDevolucionDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
        RefrescarDevolucionDetalle()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvDevoluciones.Focus()
    End Sub

    Private Sub DgvDevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvDevoluciones.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvDevoluciones.Focus()
        End If
    End Sub

    Private Sub DgvDevoluciones_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvDevoluciones.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvDevoluciones.ColumnCount
                Dim NumRows As Integer = DgvDevoluciones.RowCount
                Dim CurCell As DataGridViewCell = DgvDevoluciones.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvDevoluciones.CurrentCell = DgvDevoluciones.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvDevoluciones.CurrentCell = DgvDevoluciones.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvDevoluciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDevoluciones.CellDoubleClick
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

            Dim IDDevolucion As New Label
            IDDevolucion.Text = DgvDevoluciones.CurrentRow.Cells(0).Value

            Ds0.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDDevolucionVenta,DevolucionVenta.SecondID,DevolucionVenta.IDUsuario,DevolucionVenta.Fecha,DevolucionVenta.Hora,IDFactura,FacturaDatos.SecondID AS SecondIDFact,GenerarNCF,DevolucionVenta.NCF,DevolucionVenta.IDTipoDevolucion,TipoDevolucion.Tipo as Tipo,DevolverItbis,Devolver,DiasTransaccion,DevolucionVenta.IDMotivoDevolucion as IDMotivoDevolucion,MotivoDevolucion.Descripcion as Descripcion,DevolucionVenta.Itbis as ItbisDev,DevolucionVenta.Neto,DevolucionVenta.Nulo from" & SysName.Text & "DevolucionVenta INNER JOIN Libregco.motivodevolucion on DevolucionVenta.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion INNER JOIN Libregco.TipoDevolucion on DevolucionVenta.IDTipoDevolucion=TipoDevolucion.IDTipoDevolucion INNER JOIN" & SysName.Text & "FacturaDatos ON DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos Where IDDevolucionVenta='" + IDDevolucion.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds0, "DevolucionVenta")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds0.Tables("DevolucionVenta")

            If Me.Owner.Name = frm_devolucion_fact.Name Then
                frm_devolucion_fact.txtIDDevolucion.Text = (Tabla.Rows(0).Item("IDDevolucionVenta"))
                frm_devolucion_fact.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_devolucion_fact.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_devolucion_fact.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_devolucion_fact.txtFactura.Text = (Tabla.Rows(0).Item("SecondIDFact"))
                frm_devolucion_fact.lblIDFactura.Text = (Tabla.Rows(0).Item("IDFactura"))
                frm_devolucion_fact.lblNoNCF.Text = (Tabla.Rows(0).Item("NCF"))
                frm_devolucion_fact.txtIDMotivoDevolucion.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_devolucion_fact.txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_devolucion_fact.txtSubtotal.Text = CDbl(Tabla.Rows(0).Item("Devolver")).ToString("C")
                frm_devolucion_fact.txtItbis.Text = CDbl(Tabla.Rows(0).Item("ItbisDev")).ToString("C")
                frm_devolucion_fact.txtTotal.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                frm_devolucion_fact.txtSubtotal.Text = CDbl(Tabla.Rows(0).Item("Devolver")).ToString("C")
                frm_devolucion_fact.FillDgvArticulos()
                frm_devolucion_fact.BuscarDatosdeFactura()
                frm_devolucion_fact.FactStatus()

                If (Tabla.Rows(0).Item("IDTipoDevolucion")) = 1 Then
                    frm_devolucion_fact.rdbVoucher.Checked = True
                ElseIf (Tabla.Rows(0).Item("IDTipoDevolucion")) = 2 Then
                    frm_devolucion_fact.rdbDevCredito.Visible = True
                    frm_devolucion_fact.rdbDevCredito.Checked = True
                ElseIf (Tabla.Rows(0).Item("IDTipoDevolucion")) = 3 Then
                    frm_devolucion_fact.rdbDevEfectivo.Checked = True
                End If

                If (Tabla.Rows(0).Item("DevolverItbis")) = 1 Then
                    frm_devolucion_fact.ChkDevolverItbis.Checked = True
                Else
                    frm_devolucion_fact.ChkDevolverItbis.Checked = False
                End If

                If (Tabla.Rows(0).Item("GenerarNCF")) = 1 Then
                    frm_devolucion_fact.ChkGenerarNCF.Checked = True
                Else
                    frm_devolucion_fact.ChkGenerarNCF.Checked = False
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_devolucion_fact.chkNulo.Checked = True
                Else
                    frm_devolucion_fact.chkNulo.Checked = False
                End If

                frm_devolucion_fact.btnBuscarFactura.Enabled = False
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class