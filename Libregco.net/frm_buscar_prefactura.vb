Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_prefactura
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_prefactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDPreFactura,SecondID,Fecha,Hora,IDVendedor,IDCliente,NombreFactura,TotalNeto,Prefactura.Nulo,ClasificacionAnulacion,MotivoAnulacion,IDUsuarioAnulador,Empleados.Nombre,FechaAnulacion FROM" & SysName.Text & "prefactura LEFT JOIN" & SysName.Text & "Empleados on Prefactura.IDUsuarioAnulador=Empleados.IDEmpleado where SecondID like '%" + txtBuscar.Text + "%' and Cierre=0 and Prefactura.Nulo=0 and SecondID<>'' ORDER BY IDPreFactura DESC", ConMixta)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDPreFactura,SecondID,Fecha,Hora,IDVendedor,IDCliente,NombreFactura,TotalNeto,Prefactura.Nulo,ClasificacionAnulacion,MotivoAnulacion,IDUsuarioAnulador,Empleados.Nombre,FechaAnulacion FROM" & SysName.Text & "prefactura LEFT JOIN" & SysName.Text & "Empleados on Prefactura.IDUsuarioAnulador=Empleados.IDEmpleado where NombreFactura like '%" + txtBuscar.Text + "%' and Cierre=0 and Prefactura.Nulo=0 and SecondID<>''ORDER BY IDPreFactura DESC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PreFactura")

            Bs.DataMember = "PreFactura"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvPreFacturas.DataSource = Bs

            PropiedadColumnsDvg()

            'MarcarCanceladas()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvPreFacturas
            DgvPreFacturas.Columns(0).Visible = False
            DgvPreFacturas.Columns(1).HeaderText = "Prefactura"
            DgvPreFacturas.Columns(1).Width = 90
            DgvPreFacturas.Columns(2).Width = 90
            DgvPreFacturas.Columns(3).HeaderText = "Fecha"
            DgvPreFacturas.Columns(3).Width = 100
            DgvPreFacturas.Columns(4).HeaderText = "Vend."
            DgvPreFacturas.Columns(4).Width = 40
            DgvPreFacturas.Columns(5).Width = 40
            DgvPreFacturas.Columns(5).HeaderText = "ID"
            DgvPreFacturas.Columns(6).HeaderText = "Nombre"
            DgvPreFacturas.Columns(6).Width = 250
            DgvPreFacturas.Columns(7).HeaderText = "Neto"
            DgvPreFacturas.Columns(7).Width = 100
            DgvPreFacturas.Columns(7).DefaultCellStyle.Format = "C"

            DgvPreFacturas.Columns(8).Visible = False
            DgvPreFacturas.Columns(9).Visible = False
            DgvPreFacturas.Columns(10).Visible = False
            DgvPreFacturas.Columns(11).Visible = False
            DgvPreFacturas.Columns(12).Visible = False
            DgvPreFacturas.Columns(13).Visible = False
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

    Private Sub LlenarFormularios()
        'Try
        Dim IDPreFactura As New Label
            IDPreFactura.Text = DgvPreFacturas.CurrentRow.Cells(0).Value

            If ConMixta.State = ConnectionState.Open Then
                ConMixta.Close()
            End If

            Dim DsTemp As New DataSet
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPreFactura,SecondID,IDEquipo,IDTipoDocumento,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,Prefactura.IDCondicion,Condicion.Condicion,Prefactura.IDSucursal,Prefactura.IDAlmacen,Prefactura.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,IDVendedor,Vendedor.Nombre,IDUsuario,Prefactura.Fecha,Prefactura.Hora,TotalNeto,Observacion,Cierre,Usando,TipoPago,Prefactura.NoOrden,Prefactura.Nulo,Prefactura.IDMoneda,TipoMoneda.Texto FROM" & SysName.Text & "prefactura INNER JOIN Libregco.Condicion on Prefactura.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Prefactura.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Prefactura.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.TipoMoneda on Prefactura.IDMoneda=TipoMoneda.IDTipoMoneda Where IDPrefactura= '" + IDPreFactura.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "PreFactura")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("PreFactura")

            If Me.Owner.Name = frm_prefacturacion.Name Then
                If (Tabla.Rows(0).Item("Usando")) = 1 Then
                    MessageBox.Show("La prefactura seleccionada " & Tabla.Rows(0).Item("SecondID") & " está siendo utilizada en este momento.", "Prefactura en uso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    sqlQ = "UPDATE PreFactura SET Usando=1 WHERE IDPrefactura= (" + Tabla.Rows(0).Item("IDPreFactura").ToString + ")"
                    Con.Open()
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    Con.Close()
                End If

                frm_prefacturacion.txtIDFactura.Text = Tabla.Rows(0).Item("IDPreFactura")
                frm_prefacturacion.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                frm_prefacturacion.txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
                frm_prefacturacion.txtNombre.Text = Tabla.Rows(0).Item("NombreFactura")
                frm_prefacturacion.RNCliente = Tabla.Rows(0).Item("IdentificacionFactura")
                frm_prefacturacion.DireccionCliente = Tabla.Rows(0).Item("DireccionFactura")
                frm_prefacturacion.TelefonoCliente = Tabla.Rows(0).Item("TelefonosFactura")
                frm_prefacturacion_detalles.txtDireccion.Text = Tabla.Rows(0).Item("DireccionFactura")
                frm_prefacturacion_detalles.txtTelefono.Text = Tabla.Rows(0).Item("TelefonosFactura")
                frm_prefacturacion_detalles.txtRNC.Text = Tabla.Rows(0).Item("IdentificacionFactura")
                frm_prefacturacion.txtIDCondicion.Text = Tabla.Rows(0).Item("IDCondicion")
                frm_prefacturacion.txtCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper
                frm_prefacturacion_detalles.txtIDNcf.Text = Tabla.Rows(0).Item("IDComprobanteFiscal")
                frm_prefacturacion_detalles.txtTipoNcf.Text = Tabla.Rows(0).Item("TipoComprobante")
                frm_prefacturacion.lblIDTipoNCF.Text = Tabla.Rows(0).Item("IDComprobanteFiscal")
                frm_prefacturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))
                frm_prefacturacion_detalles.txtOrden.Text = Tabla.Rows(0).Item("NoOrden")
                frm_prefacturacion.TipoNCF.Text = Tabla.Rows(0).Item("TipoComprobante")
                frm_prefacturacion_detalles.txtIDVendedor.Text = Tabla.Rows(0).Item("IDVendedor")
                frm_prefacturacion_detalles.txtVendedor.Text = Tabla.Rows(0).Item("Nombre")
                frm_prefacturacion.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                frm_prefacturacion_detalles.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                frm_prefacturacion_detalles.txtObservacion.Text = Tabla.Rows(0).Item("Observacion")
                frm_prefacturacion.lblCierre.Text = Tabla.Rows(0).Item("Cierre")
                frm_prefacturacion.ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))
                frm_prefacturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

                If (Tabla.Rows(0).Item("TipoPago")) = 1 Then
                    frm_prefacturacion.btnControlTipoPago.Tag = 1
                    frm_prefacturacion.btnControlTipoPago.Image = My.Resources.dollar_iconx90
                    frm_prefacturacion.btnControlTipoPago.Text = "Pago Efectivo"

                ElseIf (Tabla.Rows(0).Item("TipoPago")) = 2 Then
                    frm_prefacturacion.btnControlTipoPago.Tag = 2
                    frm_prefacturacion.btnControlTipoPago.Image = My.Resources.creditcardx90
                    frm_prefacturacion.btnControlTipoPago.Text = "Pago Tarjeta"

                ElseIf (Tabla.Rows(0).Item("TipoPago")) = 3 Then
                    frm_prefacturacion.btnControlTipoPago.Tag = 3
                    frm_prefacturacion.btnControlTipoPago.Image = My.Resources.Facturacion_x90
                    frm_prefacturacion.btnControlTipoPago.Text = "Pago Mixto / Otros"
                End If
                frm_prefacturacion.TipoPagoMostrado = True


                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_prefacturacion.ChkNulo.Checked = False
                Else
                    frm_prefacturacion.ChkNulo.Checked = True
                End If

                frm_prefacturacion.RefrescarTablaConsulta()

                frm_prefacturacion.SumTotales()

                If frm_prefacturacion.dgvArticulosFactura.Rows.Count > 0 Then
                    frm_prefacturacion.cbxMoneda.Enabled = False
                End If

                Close()

            ElseIf Me.Owner.Name = frm_mdi_prefacturacion.name Then
            If (Tabla.Rows(0).Item("Usando")) = 1 Then
                MessageBox.Show("La prefactura seleccionada " & Tabla.Rows(0).Item("SecondID") & " está siendo utilizada en este momento.", "Prefactura en uso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                sqlQ = "UPDATE PreFactura SET Usando=1 WHERE IDPrefactura= (" + Tabla.Rows(0).Item("IDPreFactura").ToString + ")"
                    Con.Open()
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    Con.Close()
                End If

                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDFactura.Text = Tabla.Rows(0).Item("IDPreFactura")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtNombre.Text = Tabla.Rows(0).Item("NombreFactura")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).RNCliente = Tabla.Rows(0).Item("IdentificacionFactura")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).DireccionCliente = Tabla.Rows(0).Item("DireccionFactura")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TelefonoCliente = Tabla.Rows(0).Item("TelefonosFactura")


                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDCondicion.Text = Tabla.Rows(0).Item("IDCondicion")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).lblIDTipoNCF.Text = Tabla.Rows(0).Item("IDComprobanteFiscal")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TipoNCF = Tabla.Rows(0).Item("TipoComprobante")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtOrden.Text = Tabla.Rows(0).Item("NoOrden")
                'DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDVendedor.Text = Tabla.Rows(0).Item("IDVendedor")
                'DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtVendedor.Text = Tabla.Rows(0).Item("Nombre")
                'DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtObservacion.Text = Tabla.Rows(0).Item("Observacion")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).lblCierre.Text = Tabla.Rows(0).Item("Cierre")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).SplitContainer1.Panel1Collapsed = False

            If (Tabla.Rows(0).Item("TipoPago")) = 1 Then
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Tag = 1
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.ImageOptions.LargeImage = My.Resources.dollar_iconx90
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Caption = "Pago Efectivo"

            ElseIf (Tabla.Rows(0).Item("TipoPago")) = 2 Then
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Tag = 2
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.ImageOptions.LargeImage = My.Resources.creditcardx90
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Caption = "Pago Tarjeta"

            ElseIf (Tabla.Rows(0).Item("TipoPago")) = 3 Then
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Tag = 3
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.ImageOptions.LargeImage = My.Resources.Facturacion_x90
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Caption = "Pago Mixto / Otros"
            End If
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TipoPagoMostrado = True


            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).ChkNulo.Checked = False
            Else
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).ChkNulo.Checked = True
            End If

            If DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaArticulos.Rows.Count > 0 Then
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).cbxMoneda.Enabled = False
            End If

            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).FillTablaRowsPrecios(Tabla.Rows(0).Item("IDPreFactura"))
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).FillTablaRowsExistencias(Tabla.Rows(0).Item("IDPreFactura"))
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).RefrescarTabla(Tabla.Rows(0).Item("IDPreFactura"))
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).SumTotales()


            Close()
            End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

    End Sub

    Private Sub DgvPreFacturas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvPreFacturas.KeyPress
        If DgvPreFacturas.Rows.Count > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                LlenarFormularios()
            End If
        End If

    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvPreFacturas.Focus()
        End If
    End Sub

    Private Sub DgvPreFacturas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPreFacturas.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvPreFacturas.ColumnCount
                Dim NumRows As Integer = DgvPreFacturas.RowCount
                Dim CurCell As DataGridViewCell = DgvPreFacturas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvPreFacturas.CurrentCell = DgvPreFacturas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvPreFacturas.CurrentCell = DgvPreFacturas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvPreFacturas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPreFacturas.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
        'MarcarCanceladas()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvPreFacturas.Focus()
    End Sub

    'Private Sub MarcarCanceladas()
    '    Try
    '        For Each Row As DataGridViewRow In DgvPreFacturas.Rows

    '            If CInt(Row.Cells(8).Value) = 1 Then
    '                Row.DefaultCellStyle.BackColor = Color.LightGray
    '            Else
    '                Row.DefaultCellStyle.BackColor = Color.White
    '            End If
    '        Next
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub DgvPreFacturas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvPreFacturas.CellFormatting
        Try
            If DgvPreFacturas.Rows.Count > 0 Then
                If e.ColumnIndex = Me.DgvPreFacturas.Columns(1).Index AndAlso (e.Value IsNot Nothing) Then

                    If DgvPreFacturas.Rows(e.RowIndex).Cells(8).Value = 1 Then

                        With Me.DgvPreFacturas.Rows(e.RowIndex).Cells(e.ColumnIndex)

                            .ToolTipText = "Clasificacion: " & DgvPreFacturas.Rows(e.RowIndex).Cells(9).Value & vbNewLine & "Motivo: " & DgvPreFacturas.Rows(e.RowIndex).Cells(10).Value & vbNewLine & "Fecha: " & DgvPreFacturas.Rows(e.RowIndex).Cells(13).Value & vbNewLine & vbNewLine & "Anulador: " & DgvPreFacturas.Rows(e.RowIndex).Cells(12).Value

                        End With
                    End If



                End If
            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class