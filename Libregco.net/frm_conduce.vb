Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_conduce

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDConduceDetalle, lblIDFactura, lblIDUsuario As New Label

    Friend lblIDArticulo, lblIDFactArt, lblPrecioArticulo, lblItbisArticulo, Fraccionamiento, CantidadMaximaAplicable, ContenidoArticulo, ContenidoConversion As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_conduce_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        ActualizarTodo()
        LimpiarTodo()
        SelectUsuario()
    End Sub

    Private Sub LimpiarDatosArticulos()
        lblIDConduceDetalle.Text = ""
        lblIDArticulo.Text = ""
        lblIDFactArt.Text = ""
        lblPrecioArticulo.Text = ""
        lblItbisArticulo.Text = ""
        Fraccionamiento.Text = ""
        CantidadMaximaAplicable.Text = ""
        ContenidoConversion.Text = ""
        txtCantidad.Text = 1
        cbxMedida.DataSource = Nothing
        cbxMedida.DataBindings.Clear()
        cbxMedida.Items.Clear()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Sub FillMedidaAplicables()
        'Try
        Dim DsTemp As New DataSet

        cbxMedida.DataSource = Nothing
        cbxMedida.DataBindings.Clear()
        cbxMedida.Items.Clear()

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDPrecios,Medida.Medida FROM libregco.precioarticulo inner join Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDArticulo= '" + lblIDArticulo.Text + "' and PrecioArticulo.Nulo=0 order by contenido desc", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "precioarticulo")
        cbxMedida.ValueMember = "IDPrecios"
        cbxMedida.DisplayMember = "Medida"
        cbxMedida.DataSource = DsTemp.Tables("precioarticulo")
        ConLibregco.Close()

        If txtCantidad.Text = "" Then
            txtCantidad.Text = 1
        End If

        If cbxMedida.Items.Count = 0 Then
            MessageBox.Show("No se encontraron registros de medidas del artículo consultado.", "No hay registros de precios para el artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ElseIf cbxMedida.Items.Count > 0 Then
            cbxMedida.Text = lblMedida.Text

            If txtCantidad.Text = "" Then
                txtCantidad.Text = 1
            End If

            Con.Open()

            cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + cbxMedida.SelectedValue.ToString + "' and PrecioArticulo.Nulo=0", Con)
            cbxMedida.Tag = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Fraccionamiento FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + cbxMedida.SelectedValue.ToString + "' and PrecioArticulo.Nulo=0", Con)
            Fraccionamiento.Text = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Contenido FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + cbxMedida.SelectedValue.ToString + "' and PrecioArticulo.Nulo=0", Con)
            ContenidoConversion.Text = Convert.ToString(cmd.ExecuteScalar())

            Con.Close()

            If Fraccionamiento.Text = 1 Then
                Label23.Text = Math.Round(CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text), 6)
                Label22.Text = "por cada " & lblMedida.Text & " / Máx. " & (CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text)) * CDbl(lblCantidad.Text) & " " & cbxMedida.Text.ToLower
                Label22.Location = New Point(Label23.Location.X + Label23.Size.Width + 1, Label23.Location.Y)

                CantidadMaximaAplicable.Text = (CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text)) * CDbl(lblCantidad.Text)
                lblMensajeFraccionable.Text = "Fraccionable"
                lblMensajeFraccionable.ForeColor = SystemColors.Highlight
                lblMensajeFraccionable.Visible = True
            Else
                Label23.Text = TruncateDecimal(CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text))
                Label22.Text = "por cada " & lblMedida.Text & " / Máx. " & TruncateDecimal((CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text)) * CDbl(lblCantidad.Text)) & " " & cbxMedida.Text.ToLower
                Label22.Location = New Point(Label23.Location.X + Label23.Size.Width + 1, Label23.Location.Y)

                CantidadMaximaAplicable.Text = TruncateDecimal((CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text)) * CDbl(lblCantidad.Text))
                lblMensajeFraccionable.Text = "No fraccionable"
                lblMensajeFraccionable.ForeColor = Color.Red
                lblMensajeFraccionable.Visible = True
            End If

            txtTotal.Text = CDbl(CDbl(lblPrecioArticulo.Text) / (Math.Round(CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text), 6))).ToString("C4")

            txtImporteTotal.Text = CDbl(CDbl(CDbl(lblPrecioArticulo.Text) / (CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text))) * CDbl(txtCantidad.Text)).ToString("C4")

            Try
                If CDbl(txtCantidad.Text) > CDbl(CantidadMaximaAplicable.Text) Then
                    txtCantidad.Text = CDbl(CantidadMaximaAplicable.Text)
                End If

            Catch ex As Exception
                InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            End Try

        End If
    End Sub
    Private Sub FillAlmacen()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen INNER JOIN Empleados on Almacen.IDAlmacen=Empleados.IDAlmacen Where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "' ORDER BY Almacen.Almacen ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Almacen")
        cbxAlmacen.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Almacen")

        For Each Fila As DataRow In Tabla.Rows
            cbxAlmacen.Items.Add(Fila.Item("Almacen"))
        Next

        If Tabla.Rows.Count > 0 Then
            cbxAlmacen.SelectedIndex = 0
        Else
            MessageBox.Show("No se detectaron almacenes disponibles. Esto se puede deber a que no se encuentra un usuario definido en el formulario o porque no se encontraron almacenes en la base de datos." & vbNewLine & vbNewLine & "Por favor revise las condiciones o el sistema generará errores en la facturación.", "Sé detectó un fallo crítico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub ActualizarTodo()
        Hora.Enabled = True
        HabilitarControles()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtObservacion.Clear()
        txtEntregadoPor.Clear()
        txtIDConduce.Clear()
        chkNulo.Tag = 0
        ControlSuperClave = 1
        lblIDFactura.Text = ""
        lblStatusBar.Text = "Listo"
        lblStatusBar.ForeColor = Color.Black
        FillAlmacen()
        txtSubTotal.Text = CDbl(0).ToString("C")
        txtITBIS.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        dtpFechaPrometida.Value = Today
        chkMostrarPrecios.Checked = False
        chkMostrarPrecios.Tag = 0
        LimpiarDatosArticulos()
        OcultarDetalleArticulos()
        GroupControl4.Size = New Size(957, 352)
        GroupControl4.Location = New Point(6, 196)
        btnBuscarArticulos.Enabled = False
        txtIDFactura.Focus()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            chkNulo.Tag = 1
            DeshabilitarControles()
        Else
            chkNulo.Tag = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub dgvArticulosFactura_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < dgvArticulos.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If dgvArticulos.RowHeadersWidth < CInt(size.Width + 20) Then
                dgvArticulos.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=8", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Conduce SET SecondID='" + lblSecondID.Text + "' WHERE IDConduce='" + txtIDConduce.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=8"
            GuardarDatos()

        Catch ex As Exception

        End Try

    End Sub

    Sub SelectDatosCliente()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDFacturaDatos,FacturaDatos.IDCliente,Fecha,Hora,Condicion.Condicion,FacturaDatos.TotalNeto,NombreFactura,DireccionFactura,TelefonosFactura from" & SysName.Text & "facturadatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.SecondID='" + txtIDFactura.Text + "' and FacturaDatos.Nulo=0 and IDTipoDocumento<3", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FacturaDatos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron resultados en el número de factura.", "No existe el No. de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                lblIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
                txtFechaFactura.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                txtHoraFactura.Text = CDate(Convert.ToString(Tabla.Rows(0).Item("Hora"))).ToString("HH:mm:ss tt")
                txtCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                txtTotalNetoFactura.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                txtIDClienteNombre.Text = "[" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("NombreFactura"))
                txtDireccion.Text = (Tabla.Rows(0).Item("DireccionFactura"))
                txtTelefono.Text = (Tabla.Rows(0).Item("TelefonosFactura"))

                txtIDFactura.Enabled = False
                btnBuscarFactura.Enabled = False

                BuscarDevoluciones()
                btnBuscarArticulos.Enabled = True
                btnBuscarArticulos.Focus()
                Label40.Visible = True

                If chkAgregarTodo.Checked = False Then
                    GroupControl4.Size = New Size(957, 273)
                    GroupControl4.Location = New Point(6, 275)
                End If

            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarTodo()
        txtIDConduce.Clear()
        txtSecondID.Clear()
        txtIDFactura.Clear()
        txtFechaFactura.Clear()
        txtHoraFactura.Clear()
        txtCondicion.Clear()
        txtTotalNetoFactura.Clear()
        txtIDClienteNombre.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()
        txtEntregadoPor.Clear()
        txtObservacion.Clear()
        txtSubTotal.Clear()
        txtITBIS.Clear()
        txtNeto.Clear()
        dgvArticulos.Rows.Clear()
    End Sub

    Sub RefrescarControles()
        SelectDatosCliente()

        If chkAgregarTodo.Checked = True Then
            btnBuscarArticulos.Enabled = False

            Dim DsTemp As New DataSet

            ConMixta.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("Select IDFactArt,FacturaArticulos.IDArticulo,FacturaArticulos.IDPrecio,PrecioArticulo.IDMedida,Descripcion,Cantidad,round(((Cantidad*contenido)-(select coalesce(Sum(Entregar*PrecioArticuloConduce.Contenido),0) from" & SysName.Text & "ConduceDetalle inner join Libregco.PrecioArticulo as PrecioArticuloConduce on ConduceDetalle.IDPrecio=PrecioArticuloConduce.IDPrecios INNER JOIN" & SysName.Text & "Conduce on ConduceDetalle.IDConduce=Conduce.IDConduce Where FacturaArticulos.IDFactArt=ConduceDetalle.IDFactArt and Conduce.Nulo=0))/PrecioArticulo.Contenido,4) as Disponible,Medida.Medida,Importe/Cantidad,Itbis,Importe,PrecioArticulo.Contenido,FacturaArticulos.Itbis,(Select coalesce(sum(cantDevuelta),0) from" & SysName.Text & "DevolucionVentadetalle inner join" & SysName.Text & "DevolucionVenta on DevolucionVentaDetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta where FacturaArticulos.IDFactArt=DevolucionVentaDetalle.IDFactArt and DevolucionVenta.Nulo=0) as Devoluciones from" & SysName.Text & "FacturaArticulos INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where IDFactura='" + lblIDFactura.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "ArticulosFactura")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("ArticulosFactura")


            For Each dt As DataRow In Tabla.Rows
                If (CDbl(dt.Item(6)) - CDbl(dt.Item(13))) > 0 Then
                    dgvArticulos.Rows.Add("", "", dt.Item(0), dt.Item(1), dt.Item(2), dt.Item(3), dt.Item(4), (CDbl(dt.Item(6)) - CDbl(dt.Item(13))), dt.Item(7), CDbl(dt.Item(8)).ToString("C"), CDbl(dt.Item(9)).ToString("C"), CDbl(dt.Item(10)).ToString("C"), dt.Item(11))
                End If
            Next

            DsTemp.Dispose()

            SumTotal()

        Else
            btnBuscarArticulos.Enabled = True
            btnBuscarArticulos.PerformClick()
        End If
    End Sub

    Sub BuscarDevoluciones()
        Con.Open()
        cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta),0) as CantidadDevuelta from DevolucionVentaDetalle INNER JOIN DevolucionVenta on DevolucionVentaDetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta Where IDFactura='" + lblIDFactura.Text + "'", Con)
        Dim CantDevuelta As Double = Convert.ToDouble(cmd.ExecuteScalar())
        Con.Close()

        If CantDevuelta = 0 Then
        Else
            lblStatusBar.Text = "IMPORTANTE: Esta factura tiene devoluciones procesadas."
            lblStatusBar.ForeColor = Color.Red
        End If

    End Sub

    Private Sub UltConduce()
        Try
            If txtIDConduce.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDConduce from Conduce where IDConduce= (Select Max(IDConduce) from Conduce)", Con)
                txtIDConduce.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDConduce.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el conduce generado?", "Imprimir Conduce", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If

    End Sub

    Sub RefrescarTablaArticulos()

        Try
            If txtIDConduce.Text = "" Then
            Else
                dgvArticulos.Rows.Clear()
                ConMixta.Open()
                Dim Consulta As New MySqlCommand("SELECT ConduceDetalle.IDConduceDetalle,ConduceDetalle.IDConduce,ConduceDetalle.IDFactArt,FacturaArticulos.IDArticulo,ConduceDetalle.IDPrecio,PrecioArticulo.IDMedida,FacturaArticulos.Descripcion,ConduceDetalle.Entregar,Medida.Medida,ConduceDetalle.Precio,ConduceDetalle.Itbis,ConduceDetalle.Importe,PrecioArticulo.Contenido FROM" & SysName.Text & "conducedetalle INNER JOIN" & SysName.Text & "FacturaArticulos on ConduceDetalle.IDFactArt=FacturaArticulos.IDFactArt INNER JOIN Libregco.PrecioArticulo on ConduceDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.PrecioArticulo as PrecioArticuloVendido on FacturaArticulos.IDPrecio=PrecioArticuloVendido.IDPrecios Where ConduceDetalle.IDConduce='" + txtIDConduce.Text + "'", ConMixta)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    dgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), CDbl(LectorArticulos.GetValue(9)).ToString("C4"), CDbl(LectorArticulos.GetValue(10)).ToString("C4"), CDbl(LectorArticulos.GetValue(11)).ToString("C4"), LectorArticulos.GetValue(12))
                End While

                LectorArticulos.Close()
                ConMixta.Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DeshabilitarControles()
        dgvArticulos.Enabled = False
        txtEntregadoPor.Enabled = False
        txtObservacion.Enabled = False
        cbxAlmacen.Enabled = False
        dtpFechaPrometida.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        btnBuscarFactura.Enabled = True
        txtIDFactura.Enabled = True
        dgvArticulos.Enabled = True
        txtEntregadoPor.Enabled = True
        txtObservacion.Enabled = True
        cbxAlmacen.Enabled = True
        dtpFechaPrometida.Enabled = True
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
            Con.Close()
        End Try
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Sub ConvertDouble()
        txtSubTotal.Text = CDbl(txtSubTotal.Text)
        txtITBIS.Text = CDbl(txtITBIS.Text)
        txtNeto.Text = CDbl(txtNeto.Text)
    End Sub

    Sub ConvertCurrent()
        txtSubTotal.Text = CDbl(txtSubTotal.Text).ToString("C4")
        txtITBIS.Text = CDbl(txtITBIS.Text).ToString("C4")
        txtNeto.Text = CDbl(txtNeto.Text).ToString("C4")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_conduces.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarFactura_Click(sender As Object, e As EventArgs) Handles btnBuscarFactura.Click
        lblIDFactura.Text = ""

        If txtIDFactura.Text = "" Then
            If frm_consulta_ventas.Visible = True Then
                frm_consulta_ventas.Close()
            End If

            frm_consulta_ventas.ShowDialog(Me)
        Else
            RefrescarControles()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de conduce de factura ya está anulado en el sistema. Desea activarla?", "Recuperar Registro de Conduce de Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 11
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Conduce SET IDUsuario='" + lblIDUsuario.Text + "',Entregado='" + txtEntregadoPor.Text + "',Observacion='" + txtObservacion.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtITBIS.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + chkNulo.Tag.ToString + "',MostrarPrecios='" + chkMostrarPrecios.Tag.ToString + "' WHERE IDConduce= (" + txtIDConduce.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDConduce.Text = "" Then
            MessageBox.Show("No hay un registro de conduce de factura abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro conduce de factura No. " & txtIDConduce.Text & " del sistema?", "Anular Conduce de Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 10
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Conduce SET IDUsuario='" + lblIDUsuario.Text + "',Entregado='" + txtEntregadoPor.Text + "',Observacion='" + txtObservacion.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtITBIS.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + chkNulo.Tag.ToString + "',MostrarPrecios='" + chkMostrarPrecios.Tag.ToString + "' WHERE IDConduce= (" + txtIDConduce.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click
        EventoDisplayFacturaDatos()
    End Sub

    Sub EventoDisplayFacturaDatos()
        If chkAgregarTodo.Checked = False Then
            If GroupControl1.Size.Height = 131 Then
                SeparatorControl1.Visible = False
                GroupControl1.Size = New Size(605, 65)
                Label40.Image = My.Resources.ExpandArrowBlackx26
            Else
                If txtIDFactura.Text <> "" Then
                    SeparatorControl1.Visible = True
                    GroupControl1.Size = New Size(605, 131)
                    Label40.Image = My.Resources.UpBlackx26
                End If
            End If
        End If

    End Sub

    Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidad.Enter
        If txtCantidad.Text = "" Then
        Else
            txtCantidad.Text = CDbl(txtCantidad.Text)
            txtCantidad.SelectAll()
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        Try
            If Fraccionamiento.Text = 1 Then
                Dim Car% = Asc(e.KeyChar)
                Select Case Car
                    Case 8
                    Case 46
                    Case 48 To 57
                    Case Else
                        e.KeyChar = Nothing
                End Select

                If (txtCantidad.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
                    e.Handled = True
                End If
            Else

                Dim Car% = Asc(e.KeyChar)
                Select Case Car
                    Case 8
                    'Case 46
                    Case 48 To 57
                    Case Else
                        e.KeyChar = Nothing
                End Select
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbxMedida_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbxMedida.SelectionChangeCommitted
        If txtCantidad.Text = "" Then
            txtCantidad.Text = 1
        End If

        Con.Open()

        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + cbxMedida.SelectedValue.ToString + "' and PrecioArticulo.Nulo=0", Con)
        cbxMedida.Tag = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Fraccionamiento FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + cbxMedida.SelectedValue.ToString + "' and PrecioArticulo.Nulo=0", Con)
        Fraccionamiento.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Contenido FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + cbxMedida.SelectedValue.ToString + "' and PrecioArticulo.Nulo=0", Con)
        ContenidoConversion.Text = Convert.ToString(cmd.ExecuteScalar())

        Con.Close()

        If Fraccionamiento.Text = 1 Then
            Label23.Text = Math.Round(CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text), 6)
            Label22.Text = "por cada " & lblMedida.Text & " / Máx. " & Math.Round(CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text), 6) * CDbl(lblCantidad.Text) & " " & cbxMedida.Text.ToLower
            Label22.Location = New Point(Label23.Location.X + Label23.Size.Width + 1, Label23.Location.Y)

            CantidadMaximaAplicable.Text = (CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text)) * CDbl(lblCantidad.Text)
            lblMensajeFraccionable.Text = "Fraccionable"
            lblMensajeFraccionable.ForeColor = SystemColors.Highlight
            lblMensajeFraccionable.Visible = True
        Else
            If txtCantidad.Text <> "" Then
                txtCantidad.Text = Math.Round(CDbl(txtCantidad.Text), 0)
            End If

            Label23.Text = TruncateDecimal(CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text))
            Label22.Text = "por cada " & lblMedida.Text & " / Máx. " & TruncateDecimal((CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text)) * CDbl(lblCantidad.Text)) & " " & cbxMedida.Text.ToLower
            Label22.Location = New Point(Label23.Location.X + Label23.Size.Width + 1, Label23.Location.Y)

            CantidadMaximaAplicable.Text = TruncateDecimal((CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text)) * CDbl(lblCantidad.Text))
            lblMensajeFraccionable.Text = "No fraccionable"
            lblMensajeFraccionable.ForeColor = Color.Red
            lblMensajeFraccionable.Visible = True
        End If

        txtTotal.Text = CDbl(CDbl(lblPrecioArticulo.Text) / (Math.Round(CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text), 6))).ToString("C4")
        txtImporteTotal.Text = CDbl(CDbl(CDbl(lblPrecioArticulo.Text) / (CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text))) * CDbl(txtCantidad.Text)).ToString("C4")

        Try
            If CDbl(txtCantidad.Text) > CDbl(CantidadMaximaAplicable.Text) Then
                txtCantidad.Text = CDbl(CantidadMaximaAplicable.Text)
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If lblIDFactura.Text = "" Then
            MessageBox.Show("Escriba o seleccione un número de factura válido para realizar los conduces a factura.", "Seleccione o escriba el número de factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtIDFactura.Focus()
            Exit Sub
        ElseIf dgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en el detalle del conduce para registrar.", "No hay registros de artículos para guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDConduce.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el conduce de la factura No." & txtIDFactura.Text & " en la base de datos?", "Guardar Conduce de Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Conduce (IDTipoDocumento,IDUsuario,IDFacturaDatos,IDSucursal,IDAlmacen,Fecha,Hora,FechaPrometida,Entregado,Observacion,Subtotal,Itbis,Neto,Impreso,Nulo,MostrarPrecios) VALUES (8,'" + lblIDUsuario.Text + "','" + lblIDFactura.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + cbxAlmacen.Tag.ToString + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + dtpFechaPrometida.Value.ToString("yyyy-MM-dd") + "','" + txtEntregadoPor.Text + "','" + txtObservacion.Text + "','" + txtSubTotal.Text + "','" + txtITBIS.Text + "','" + txtNeto.Text + "',0,'" + chkNulo.Tag.ToString + "','" + chkMostrarPrecios.Tag.ToString + "')"
                GuardarDatos()
                UltConduce()
                SetSecondID()
                InsertArticulos()
                ConvertCurrent()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el conduce?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Conduce SET IDUsuario='" + lblIDUsuario.Text + "',IDFacturaDatos='" + lblIDFactura.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',FechaPrometida='" + dtpFechaPrometida.Value.ToString("yyyy-MM-dd") + "',Entregado='" + txtEntregadoPor.Text + "',Observacion='" + txtObservacion.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtITBIS.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + chkNulo.Tag.ToString + "',MostrarPrecios='" + chkMostrarPrecios.Tag.ToString + "' WHERE IDConduce= (" + txtIDConduce.Text + ")"
                GuardarDatos()
                InsertArticulos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub InsertArticulos()
        For Each Row As DataGridViewRow In dgvArticulos.Rows
            If (CStr(Row.Cells(0).Value).ToString) = "" Then
                sqlQ = "INSERT INTO ConduceDetalle (IDConduce,IDFactArt,IDPrecio,Entregar,Precio,Itbis,Importe) VALUES ('" + txtIDConduce.Text + "','" + Row.Cells(2).Value.ToString + "','" + Row.Cells(4).Value.ToString + "','" + Row.Cells(7).Value.ToString + "','" + CDbl(Row.Cells(9).Value).ToString + "','" + CDbl(Row.Cells(10).Value).ToString + "','" + CDbl(Row.Cells(11).Value).ToString + "')"
                GuardarDatos()

                Con.Open()
                cmd = New MySqlCommand("Select IDConduceDetalle from ConduceDetalle where IDConduceDetalle= (Select Max(IDConduceDetalle) from ConduceDetalle)", Con)
                Row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                Row.Cells(1).Value = txtIDConduce.Text

                Con.Close()
            Else

                sqlQ = "UPDATE ConduceDetalle SET IDConduce='" + txtIDConduce.Text + "',IDFactArt='" + Row.Cells(2).Value.ToString + "',IDPrecio='" + Row.Cells(4).Value.ToString + "',Entregar='" + Row.Cells(7).Value.ToString + "',Precio='" + CDbl(Row.Cells(9).Value).ToString + "',Itbis='" + CDbl(Row.Cells(10).Value).ToString + "',Importe='" + CDbl(Row.Cells(11).Value).ToString + "' WHERE IDConduceDetalle='" + Row.Cells(0).Value.ToString + "'"
                GuardarDatos()

            End If
        Next
    End Sub

    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If dgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDConduce.Text = "" And dgvArticulos.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    dgvArticulos.Rows.Clear()
                    LimpiarDatosArticulos()
                    OcultarDetalleArticulos()
                    SumTotal()
                    Exit Sub
                End If
            End If

            If txtIDConduce.Text > 0 And dgvArticulos.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya procesados.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If dgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            ElseIf dgvArticulos.Rows.Count > 0 Then

                If txtIDConduce.Text <> "" Then
                    If dgvArticulos.Rows.Count = 1 Then
                        MessageBox.Show("No es posible eliminar el artículo ya que es único en el conduce. Para realizar esta operación primero agregue el artículo que desea a la factura y posteriormente proceda a eliminar el artículo correspondiente.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub

                    Else

                        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo?", "Eliminar artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If Result = MsgBoxResult.Yes Then

                            Con.Open()
                            sqlQ = "Delete from" & SysName.Text & "ConduceDetalle Where IDConduceDetalle= '" + dgvArticulos.CurrentRow.Cells(0).Value.ToString + "'"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()
                            Con.Close()

                            dgvArticulos.Rows.Remove(dgvArticulos.CurrentRow)
                            SumTotal()

                            MessageBox.Show("El artículo ha sido eliminado satisfactoriamente.", "Artículo eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If

                    End If

                Else
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & dgvArticulos.CurrentRow.Cells(6).Value & "] del conduce?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        dgvArticulos.Rows.Remove(dgvArticulos.CurrentRow)
                        SumTotal()
                        Exit Sub
                    End If

                End If

            End If



        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMedida.KeyDown
        If e.KeyCode = 13 Then
            If cbxMedida.DroppedDown = True Then
                cbxMedida.DroppedDown = False
            End If
        End If
    End Sub

    Private Sub txtIDFactura_Leave(sender As Object, e As EventArgs) Handles txtIDFactura.Leave
        btnBuscarFactura.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        'Buscar si existe duplicidad
        For Each Row As DataGridViewRow In dgvArticulos.Rows
            If Row.Cells(4).Value = cbxMedida.SelectedValue.ToString Then
                MessageBox.Show("Este artículo ya se encuentra en el conduce con la misma medida." & vbNewLine & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Next

        'Calculo de contenido de unidad
        '5 atados x 296 =    1,480 unidades
        Dim CantidadaInsertada As Double = 0
        For Each Rw As DataGridViewRow In dgvArticulos.Rows
            If Rw.Cells(2).Value = lblIDFactArt.Text Then
                CantidadaInsertada = CantidadaInsertada + (CDbl(Rw.Cells(7).Value) * CDbl(Rw.Cells(12).Value))
            End If
        Next

        Dim CantidadDisponibleUnidades As Double = CDbl((lblCantidad.Text) * CDbl(ContenidoArticulo.Text)) - CDbl(CantidadaInsertada)
        Dim CantidadaIntegrar As Double = Math.Round(CDbl(txtCantidad.Text) * CDbl(ContenidoConversion.Text), 6)

        If CantidadDisponibleUnidades >= CantidadaIntegrar Then
            dgvArticulos.Rows.Add(lblIDConduceDetalle.Text, txtIDConduce.Text, lblIDFactArt.Text, lblIDArticulo.Text, cbxMedida.SelectedValue.ToString, cbxMedida.Tag.ToString, lblDescripcion.Text, txtCantidad.Text, cbxMedida.Text, txtTotal.Text, (CDbl(lblItbisArticulo.Text) / (Math.Round(CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text), 6))).ToString("C4"), txtImporteTotal.Text, ContenidoConversion.Text)

            dgvArticulos.ClearSelection()
            LimpiarDatosArticulos()
            OcultarDetalleArticulos()
            SumTotal()
        Else
            MessageBox.Show("La cantidad que desea insertar excede la cantidad disponible.", "Ha excedido la cantidad facturada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulos.Click
        If lblIDFactura.Text <> "" Then
            frm_conduce_articuloscomprados.ShowDialog(Me)
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        Try


            If txtCantidad.Text = "" Then
                txtCantidad.Text = 1
            Else
                If CantidadMaximaAplicable.Text = "" Then
                    txtCantidad.Text = 1
                Else
                    If CDbl(txtCantidad.Text) > CDbl(CantidadMaximaAplicable.Text) Then
                        txtCantidad.Text = CantidadMaximaAplicable.Text
                    End If
                End If

                txtImporteTotal.Text = CDbl(CDbl(CDbl(lblPrecioArticulo.Text) / (CDbl(ContenidoArticulo.Text) / CDbl(ContenidoConversion.Text))) * CDbl(txtCantidad.Text)).ToString("C4")

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkMostrarPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarPrecios.CheckedChanged
        If chkMostrarPrecios.Checked = True Then
            chkMostrarPrecios.Tag = 1
        Else
            chkMostrarPrecios.Tag = 0
        End If
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        cbxAlmacen.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Sub OcultarDetalleArticulos()
        lblDescripcion.Visible = False
        Label4.Visible = False
        lblMedida.Visible = False
        lblCantidad.Visible = False
        Label24.Visible = False
        Label25.Visible = False
        Label1.Visible = False
        cbxMedida.Visible = False
        txtCantidad.Visible = False
        txtTotal.Visible = False
        txtImporteTotal.Visible = False
        Label23.Visible = False
        Label22.Visible = False
        lblMensajeFraccionable.Visible = False
        btnInsertar.Visible = False
        Label40.Visible = False
    End Sub

    Sub MostrarDetalleArticulos()
        lblDescripcion.Visible = True
        Label4.Visible = True
        lblMedida.Visible = True
        lblCantidad.Visible = True
        Label24.Visible = True
        Label25.Visible = True
        Label1.Visible = True
        cbxMedida.Visible = True
        txtCantidad.Visible = True
        txtTotal.Visible = True
        txtImporteTotal.Visible = True
        Label23.Visible = True
        Label22.Visible = True
        btnInsertar.Visible = True
    End Sub

    Sub SumTotal()
        Dim Itbis As Double = 0
        Dim Subtotal As Double = 0

        For Each Row As DataGridViewRow In dgvArticulos.Rows
            Subtotal = Subtotal + ((CDbl(Row.Cells(9).Value) - CDbl(Row.Cells(10).Value)) * (CDbl(Row.Cells(7).Value)))
            Itbis = Itbis + (CDbl(Row.Cells(10).Value) * (CDbl(Row.Cells(7).Value)))
        Next

        txtSubTotal.Text = Subtotal.ToString("C4")
        txtITBIS.Text = Itbis.ToString("C4")
        txtNeto.Text = Math.Round((Itbis + Subtotal), 2).ToString("C4")
    End Sub
End Class