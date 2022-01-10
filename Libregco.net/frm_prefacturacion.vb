Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_prefacturacion
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend DefaultNcf, DefaultIDCondicion, DefaultCondicion, DefaultCondicionDias, ExistenciaSimilares, ExistenciaRelacionados, BloqueoPrecioCero As String
    Friend ChangedCodeEmployee, ModifyingProduct, TipoPagoMostrado As Boolean
    Friend RNCliente, DireccionCliente, TelefonoCliente, Cotizacion, IDGrupo_Cliente As String
    Friend lblIDUsuario, lblCheckDuplicates, lblIDAlmacenArticulo, lblIDAlmacen, lblIDFactArt, IDArticulo, lblItbisArt, lblIDMedida, lblExistencia, lblIDTipoProducto, lblIDPrecio, lblDescuento, lblCierre, lblIDTipoNCF, TipoNCF, Fraccionamiento As New Label
    Friend Permisos, Precios, ListadoProbVendidos As New ArrayList
    Friend CantidadCaracteresRNC As New List(Of Integer)
    Dim CbxPrecioHeader As New ComboBox
    Private ConProbabilidades As New MySqlConnection(CnGeneral)
    Private ConSimilares As New MySqlConnection(CnGeneral)

    Private TablaSimilares As New DataTable
    Private TablaProbabilidades As DataTable = New DataTable("Probabilidades")


    Private Sub frm_prefacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.CenterToParent()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        SetConfiguracion()
        ColumnasDgvArticulos()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub SplitContainerProperties()
        If dgvArticulosFactura.Rows.Count > 0 Then
            If chkMostrarRelacionados.Checked = True Then
                If dgvArticulosFactura.Rows.Count > 0 Then
                    Dim CardsonFlow As Integer = 0

                    For Each cd As CardBoard In FlowProbabilidades.Controls
                        If cd.Button1.Tag.ToString <> "" Then
                            CardsonFlow += 1
                        End If
                    Next

                    If CardsonFlow > 0 Then
                        SplitProbabilidades.Panel2Collapsed = False
                    Else
                        SplitProbabilidades.Panel2Collapsed = True
                    End If

                    'If Me.Width > 1200 Then
                    '    SplitProbabilidades.Panel2Collapsed = False
                    'Else
                    '    SplitProbabilidades.Panel2Collapsed = True
                    'End If
                Else
                    SplitProbabilidades.Panel2Collapsed = True
                End If
            End If

        End If

    End Sub


    Private Sub AñadirCardBoardSimilares(Sender As Object, e As EventArgs)
        txtCodigoArticulo.Text = DirectCast(Sender, Button).Tag.ToString
        SetInformacionArticulo()
    End Sub
    Private Sub AñadirCardBoard(Sender As Object, e As EventArgs)
        txtCodigoArticulo.Text = DirectCast(Sender, Button).Tag
        SetInformacionArticulo()

        FlowProbabilidades.Controls.Remove(DirectCast(DirectCast(Sender, Control).Parent, CardBoard))
    End Sub

    Private Function ProductinDgv(ByVal IDProduct As Integer) As Boolean
        Dim ValueAcquired As Boolean = False
        For Each rw As DataGridViewRow In dgvArticulosFactura.Rows
            If rw.Cells(4).Value = IDProduct Then
                ValueAcquired = True
                Exit For
            Else
                ValueAcquired = False
            End If
        Next

        Return ValueAcquired
    End Function

    Private Sub LimpiarDatos()
        'Verificar si se esta usando
        If txtIDFactura.Text <> "" Then
            sqlQ = "UPDATE PreFactura SET Usando=0 WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        End If

        dgvArticulosFactura.Rows.Clear()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtIDFactura.Clear()
        txtSecondID.Clear()
        LimpiarDatosArticulos()
        txtNeto.Text = CDbl(0).ToString("C")
        ChkNulo.Checked = False
        cbxPrecio.Items.Clear()
        frm_prefacturacion_detalles.txtIDCliente.Clear()
        frm_prefacturacion_detalles.txtNombre.Clear()
        frm_prefacturacion_detalles.txtRNC.Clear()
        frm_prefacturacion_detalles.txtIDVendedor.Clear()
        frm_prefacturacion_detalles.txtVendedor.Clear()
        frm_prefacturacion_detalles.txtIDCondicion.Text = 1
        frm_prefacturacion_detalles.txtIDCondicion.Tag = 0
        frm_prefacturacion_detalles.txtCondicion.Clear()
        frm_prefacturacion_detalles.txtIDNcf.Clear()
        frm_prefacturacion_detalles.txtTipoNcf.Clear()
        frm_prefacturacion_detalles.txtObservacion.Clear()
        frm_prefacturacion_detalles.txtNeto.Clear()
        frm_prefacturacion_detalles.txtDireccion.Clear()
        frm_prefacturacion_detalles.txtTelefono.Clear()
        frm_prefacturacion_detalles.txtOrden.Clear()
        TablaSimilares.Clear()
        TablaProbabilidades.Rows.Clear()
    End Sub

    Private Sub ColumnasDgvArticulos()
        dgvArticulosFactura.Columns.Clear()
        With dgvArticulosFactura
            .Columns.Add("IDArtFac", "ID ArtFac")   '0
            .Columns.Add("IDFactura", "ID Factura") '1
            .Columns.Add("IDPrecios", "ID Precio") '2

            .Columns.Add("IDMedida", "ID Medida")   '3
            .Columns.Add("IDArticulo", "Código")    '4
            .Columns.Add("Cantidad", "Cant.")       '5
            .Columns.Add("Medida", "Medida")        '6

            .Columns.Add("Descripcion", "Descripción")  '7
            .Columns.Add("PrecioTotal", "Precio") '8
            .Columns.Add("PrecioSinIt", "PrecioSinIt") '9

            .Columns.Add("Descuento", "Descuento")  '10
            .Columns.Add("Itbis", "Itbis")  '11
            .Columns.Add("Importe", "Importe")      '12
            .Columns.Add("IDAlmacen", "Alm") '13
            .Columns.Add("NivelPrecio", "Precio") '14
            .Columns.Add("Hijo", "Hijo") '15
            .Columns.Add("Fraccionamiento", "Fraccionamiento") '16
        End With
        PropiedadesDgvArticulos()

        'CbxHeaderPrecios
        CbxPrecioHeader.DropDownStyle = ComboBoxStyle.DropDownList
        CbxPrecioHeader.Visible = False

        dgvArticulosFactura.Controls.Add(CbxPrecioHeader)
        CbxPrecioHeader.Name = "CbxPreciosHeader"
        CbxPrecioHeader.Location = dgvArticulosFactura.GetCellDisplayRectangle(3, -1, False).Location
        CbxPrecioHeader.Size = dgvArticulosFactura.Columns(14).HeaderCell.Size
        CbxPrecioHeader.Text = "Precios"

        AddHandler CbxPrecioHeader.SelectionChangeCommitted, AddressOf CbxPrecioHeader_SelectionChanged
    End Sub

    Sub PropiedadesDgvArticulos()
        Try
            Dim Condicion As String = False
            Dim DatagridWidth As Double = (TbSelectProductos.Width - dgvArticulosFactura.RowHeadersWidth) / 100
            With dgvArticulosFactura
                .Columns("IDArtFac").Visible = Condicion
                .Columns("IDFactura").Visible = Condicion
                .Columns("IDPrecios").Visible = Condicion
                .Columns("IDMedida").Visible = Condicion

                .Columns("IDArticulo").Width = DatagridWidth * 10
                .Columns("IDArticulo").HeaderText = "Código"
                .Columns("IDArticulo").DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                .Columns("IDArticulo").ReadOnly = True
                .Columns("IDArticulo").DefaultCellStyle.BackColor = Color.DarkGray
                .Columns("IDArticulo").DefaultCellStyle.ForeColor = Color.White

                .Columns("Cantidad").HeaderText = "Cant."
                .Columns("Cantidad").Width = DatagridWidth * 5
                .Columns("Cantidad").ReadOnly = False

                .Columns("Medida").Width = DatagridWidth * 8
                .Columns("Medida").ReadOnly = True

                .Columns("Descripcion").Width = DatagridWidth * 40
                .Columns("Descripcion").DefaultCellStyle.ForeColor = SystemColors.WindowFrame
                .Columns("Descripcion").HeaderText = "Descripción"
                .Columns("Descripcion").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns("Descripcion").ReadOnly = True

                .Columns("PrecioTotal").DefaultCellStyle.Format = ("C4")
                .Columns("PrecioTotal").HeaderText = "Precio"
                .Columns("PrecioTotal").Width = DatagridWidth * 12
                .Columns("PrecioTotal").ReadOnly = False

                .Columns("PrecioSinIt").Visible = Condicion
                .Columns("PrecioSinIt").ReadOnly = True

                .Columns("Descuento").Visible = Condicion
                .Columns("Descuento").DefaultCellStyle.Format = ("C4")
                .Columns("Itbis").Visible = Condicion
                .Columns("Itbis").DefaultCellStyle.Format = ("C4")

                .Columns("Importe").DefaultCellStyle.Format = ("C4")
                .Columns("Importe").Width = DatagridWidth * 14
                .Columns("Importe").ReadOnly = True

                .Columns("IDAlmacen").Width = DatagridWidth * 5
                .Columns("IDAlmacen").ReadOnly = True

                .Columns("NivelPrecio").Width = DatagridWidth * 5
                .Columns("NivelPrecio").ReadOnly = True

                .Columns("Hijo").Visible = False

                .Columns("Fraccionamiento").Visible = False

                .ScrollBars = ScrollBars.Vertical
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiarDatosArticulo2() 'Para limpiar si crear error al salir del txtIDCodigoArticulo en el evento Leave
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtCodigoArticulo.Clear()
        txtDescripcionArticulo.Clear()
        lblDescuento.Text = 0
        txtPrecio.Clear()
        txtTotalArt.Clear()
        lblIDMedida.Text = ""
        lblIDPrecio.Text = ""
        lblExistencia.Text = ""
        IDArticulo.Text = ""
    End Sub

    Sub LimpiarDatosArticulos()
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtCodigoArticulo.Clear()
        txtDescripcionArticulo.Clear()
        lblDescuento.Text = 0
        txtPrecio.Clear()
        txtTotalArt.Clear()
        txtCantidadArticulo.Clear()
        lblIDMedida.Text = ""
        lblIDPrecio.Text = ""
        lblExistencia.Text = ""
        lblIDAlmacenArticulo.Text = ""
        IDArticulo.Text = ""
        lblIDFactArt.Text = ""
        SimpleButton1.Tag = ""
        Label5.Text = ""
        GPExistencia.Visible = False
        PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SelectUsuario()
        Try

            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]"
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetConfiguracion()
        Try
            '           ShowInfoArticle = DTConfiguracion.Rows(15 - 1).Item("Value2Int")
            '           FactDebajoCosto = DTConfiguracion.Rows(16 - 1).Item("Value2Int")
            '           DefaultIDNCF = DTConfiguracion.Rows(13 - 1).Item("Value2Int")
            '           DefaultIDCondicion = DTConfiguracion.Rows(59 - 1).Item("Value2Int")
            '           FacturarSinExist = DTConfiguracion.Rows(21 - 1).Item("Value2Int")
            '           SolicitarNombreCliente = DTConfiguracion.Rows(97 - 1).Item("Value2Int")
            '           LimiteSolNombre = DTConfiguracion.Rows(98 - 1).Item("Value3Double")
            '           ModificacionArticuloBase = DTConfiguracion.Rows(128 - 1).Item("Value2Int")
            '           FacturacionSinInventarioArticuloBase = DTConfiguracion.Rows(129 - 1).Item("Value2Int")
            '           ControlTipoPago = DTConfiguracion.Rows(146 - 1).Item("Value2Int")
            '           BloqueoTarjeta = DTConfiguracion.Rows(150 - 1).Item("Value2Int")
            '           PermitirDuplicado = DTConfiguracion.Rows(170 - 1).Item("Value2Int")
            '           RNCInteligente = DTConfiguracion.Rows(176 - 1).Item("Value2Int")
            '           PictureHeight = DTConfiguracion.Rows(179 - 1).Item("Value2Int")
            '           ControlarNivelesPrecios = DTConfiguracion.Rows(195 - 1).Item("Value2Int")
            '           MostrarNoOrden = DTConfiguracion.Rows(197 - 1).Item("Value2Int")
            '           BloqueoPrecioCero = DTConfiguracion.Rows(211 - 1).Item("Value2Int")
            '           'Mostrar artículos similares durante la prefacturación CInt(DTConfiguracion.Rows(198 - 1).Item("Value2Int"))
            '           Mostrar artículos relacionados durante la prefacturación CInt(DTConfiguracion.Rows(199 - 1).Item("Value2Int"))
            ''Mostrar sólo artículos con existencia al mostrar los similares durante prefacturación  CInt(DTConfiguracion.Rows(200 - 1).Item("Value2Int"))
            'DefaultCurrency = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))
            '           'Mostrar sólo artículos con existencia al mostrar los relacionados durante prefacturación CInt(DTConfiguracion.Rows(201 - 1).Item("Value2Int"))


            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            If ConLibregco.State = ConnectionState.Open Then
                ConLibregco.Close()
            End If

            'Mostrar el panel de informacion de los articulos
            Con.Open()
            ConLibregco.Open()

            'Comprobante Fiscal Predeterminado
            cmd = New MySqlCommand("SELECT TipoComprobante FROM Comprobantefiscal Where IDComprobanteFiscal='" + DTConfiguracion.Rows(13 - 1).Item("Value2Int").ToString + "'", Con)
            DefaultNcf = Convert.ToString(cmd.ExecuteScalar())

            'Condicion Predeterminada
            DefaultIDCondicion = DTConfiguracion.Rows(59 - 1).Item("Value2Int")
            cmd = New MySqlCommand("Select Condicion from Condicion Where IDCondicion='" + DefaultIDCondicion + "'", ConLibregco)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar()).ToUpper

            cmd = New MySqlCommand("Select Dias from Condicion Where IDCondicion='" + DefaultIDCondicion + "'", ConLibregco)
            DefaultCondicionDias = Convert.ToString(cmd.ExecuteScalar()).ToUpper

            'Mostrar numero de orden
            Label2.Visible = Convert.ToBoolean(CInt(DTConfiguracion.Rows(197 - 1).Item("Value2Int")))
            txtOrden.Visible = Convert.ToBoolean(CInt(DTConfiguracion.Rows(197 - 1).Item("Value2Int")))

            'Bloquear toda facturación de artículo con precio CERO RD$ 0
            BloqueoPrecioCero = DTConfiguracion.Rows(211 - 1).Item("Value2Int")

            'Mostrar artículos similares durante la prefacturación
            chkMostrarSimilares.Visible = Convert.ToBoolean(CInt(DTConfiguracion.Rows(198 - 1).Item("Value2Int")))
            chkMostrarSimilares.Enabled = Convert.ToBoolean(CInt(DTConfiguracion.Rows(198 - 1).Item("Value2Int")))
            chkMostrarSimilares.Checked = Convert.ToBoolean(CInt(DTConfiguracion.Rows(198 - 1).Item("Value2Int")))


            'Mostrar artículos relacionados durante la prefacturación
            chkMostrarRelacionados.Visible = Convert.ToBoolean(CInt(DTConfiguracion.Rows(199 - 1).Item("Value2Int")))
            chkMostrarRelacionados.Enabled = Convert.ToBoolean(CInt(DTConfiguracion.Rows(199 - 1).Item("Value2Int")))
            chkMostrarRelacionados.Checked = Convert.ToBoolean(CInt(DTConfiguracion.Rows(199 - 1).Item("Value2Int")))

            'Mostrar sólo artículos con existencia al mostrar los similares durante prefacturación
            If CInt(DTConfiguracion.Rows(200 - 1).Item("Value2Int")) = 1 Then
                ExistenciaSimilares = " and Articulos.ExistenciaTotal>0 "
            Else
                ExistenciaSimilares = " "
            End If

            Ds.Clear()
            cbxMoneda.Properties.Items.Clear()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tipomoneda")
            Dim Tabla As DataTable = Ds.Tables("tipomoneda")

            For Each Fila As DataRow In Tabla.Rows
                Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
                nvmoneda.Description = Fila.Item("Texto")
                nvmoneda.Value = Fila.Item("IDTipoMoneda")

                If Fila.Item("IDTipoMoneda") = 1 Then
                    nvmoneda.ImageIndex = 0
                ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                    nvmoneda.ImageIndex = 1
                ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                    nvmoneda.ImageIndex = 2
                End If

                cbxMoneda.Properties.Items.Add(nvmoneda)
            Next
            Tabla.Dispose()

            'Mostrar sólo artículos con existencia al mostrar los relacionados durante prefacturación
            If CInt(DTConfiguracion.Rows(201 - 1).Item("Value2Int")) = 1 Then
                ExistenciaRelacionados = " and Articulos.ExistenciaTotal>0 "
            Else
                ExistenciaRelacionados = " "
            End If

            CantidadCaracteresRNC.Add(9)
            CantidadCaracteresRNC.Add(11)

            Con.Close()
            ConLibregco.Close()

            With TablaProbabilidades
                .Columns.Add("IDArticulo", Type.GetType("System.String"))
                .Columns.Add("Descripcion", Type.GetType("System.String"))
                .Columns.Add("Referencia", Type.GetType("System.String"))
                .Columns.Add("Promocion", Type.GetType("System.String"))
                .Columns.Add("PrecioContado", Type.GetType("System.String"))
                .Columns.Add("Precio3", Type.GetType("System.String"))
                .Columns.Add("ExistenciaTotal", Type.GetType("System.String"))
                .Columns.Add("Marca", Type.GetType("System.String"))
                .Columns.Add("RutaFoto", Type.GetType("System.String"))
                .Columns.Add("CategoriaFilePath", Type.GetType("System.String"))
                .Columns.Add("SubCategoriaFilePath", Type.GetType("System.String"))
                .Columns.Add("RepeticionesenVentas", Type.GetType("System.String"))
            End With

            Dim PermisosA As New ArrayList
            PermisosA = PasarPermisos(3)

            If PermisosA(0) = 0 Then
                IrAArtículosToolStripMenuItem.Enabled = False
                ToolStripButton1.Visible = False
                ToolStripSeparator2.Visible = False
                MantenimientoDeArtículosToolStripMenuItem.Visible = False
            Else
                IrAArtículosToolStripMenuItem.Enabled = True
                ToolStripButton1.Visible = True
                ToolStripSeparator2.Visible = True
                MantenimientoDeArtículosToolStripMenuItem.Visible = True
            End If

            Dim PermisosConsultaCotizacion As New ArrayList
            PermisosConsultaCotizacion = PasarPermisos(81)

            If PermisosConsultaCotizacion(0) = 0 Then
                ConsultaDeCotizaciToolStripMenuItem.Enabled = False
                ConvertirACotizaciónToolStripMenuItem.Enabled = False

            Else
                ConsultaDeCotizaciToolStripMenuItem.Enabled = True
                ConvertirACotizaciónToolStripMenuItem.Enabled = True
            End If


            '''''''''''''''''''''''''''''''''''''''
            ConUtilitarios.Open()
            cmd = New MySqlCommand("SELECT Value FROM libregco_utilitarios.ajustes where IDAjuste=6", ConUtilitarios)
            If CInt(Convert.ToString(cmd.ExecuteScalar())) = 1 Then
                DuplicarPrefacturaciónToolStripMenuItem.Visible = True
            Else
                DuplicarPrefacturaciónToolStripMenuItem.Visible = False
            End If
            ConUtilitarios.Close()
            ''''''''''''''''''''''''''''''''

        Catch ex As Exception
        InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CbxPrecioHeader_SelectionChanged(sender As Object, e As EventArgs)
        Try
            ConMixta.Open()

            For Each rw As DataGridViewRow In dgvArticulosFactura.Rows
                rw.Cells(8).Value = CDbl(GetPricesWithIDPrecio(CbxPrecioHeader.Text, rw.Cells(2).Value.ToString, cbxMoneda.EditValue.ToString)).ToString("C4")
                cmd = New MySqlCommand("Select Itbis from Libregco.Articulos INNER JOIN Libregco.TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + rw.Cells(4).Value.ToString + "'", ConMixta)
                Dim itb As Double = Convert.ToDouble(cmd.ExecuteScalar())

                rw.Cells(9).Value = CDbl(CDbl(rw.Cells(8).Value) / (1 + itb)).ToString("C4")
                rw.Cells(11).Value = CDbl(CDbl(rw.Cells(9).Value) * itb).ToString("C4")
                rw.Cells(12).Value = CDbl(CDbl(rw.Cells(8).Value) * CDbl(rw.Cells(5).Value)).ToString("C4")
                rw.Cells(14).Value = CbxPrecioHeader.Text
            Next

            ConMixta.Close()

            SumTotales()

            If txtIDFactura.Text <> "" Then
                lblStatusBar.ForeColor = Color.Red
                lblStatusBar.Text = "Ya la prefactura se ha guardado. Para guardar la modificación de los precios vuelva a guardar la prefactura."
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ActualizarTodo()
        Me.CenterToParent()
        lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        ControlSuperClave = 1
        txtNombre.Enabled = False
        txtFecha.Value = Today.ToString("dd/MM/yyyy")
        lblStatusBar.ForeColor = Color.Black
        lblStatusBar.Text = "Listo."
        HabilitarControles()
        txtNombre.Enabled = True
        txtNombre.ReadOnly = False
        txtPrecio.ReadOnly = False
        cbxMoneda.Enabled = True
        NewNCFValue.Text = ""
        Cotizacion = ""
        Hora.Enabled = True
        ModifyingProduct = False
        txtDescripcionArticulo.ReadOnly = True
        txtDescripcionArticulo.Enabled = False
        chkAplicarAutomaticamente.Checked = False
        GPExistencia.Visible = False
        ModifyingProduct = False
        txtIDCliente.Text = 1
        IDGrupo_Cliente = "1"
        txtNombre.Text = "CONTADO"
        txtNivelPrecio.Text = "A"
        lblIDTipoNCF.Text = DTConfiguracion.Rows(13 - 1).Item("Value2Int").ToString
        PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
        TipoNCF.Text = DefaultNcf
        lblIDAlmacen.Text = DtEmpleado.Rows(0).item("IDAlmacen").ToString()
        txtIDCondicion.Text = DefaultIDCondicion
        txtIDCondicion.Tag = DefaultCondicionDias
        txtCondicion.Text = DefaultCondicion
        TipoPagoMostrado = False
        btnControlTipoPago.Tag = 3
        btnControlTipoPago.Image = My.Resources.Facturacion_x90
        btnControlTipoPago.Text = "Pago Mixto / Otros"
        FlowProbabilidades.Controls.Clear()
        SplitSimilares.Panel2Collapsed = True
        SplitProbabilidades.Panel2Collapsed = True
        SplitContainer1.Panel1Collapsed = True
        btnModificar.Enabled = True
        cbxMoneda.EditValue = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))
        FlowSimilares.Controls.Clear()
        'Me.Size = New Size(1000, 730)
        ListadoProbVendidos.Clear()
        PropiedadesDgvArticulos()
        Precios = GetRangePrices()
        FillPrecios()

        If CbxPrecioHeader.Items.Count > 0 Then
            CbxPrecioHeader.SelectedIndex = 0
        End If

        If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
            btnControlTipoPago.Visible = True
            btnControlTipoPago.Image = My.Resources.Facturacion_x90
            btnControlTipoPago.Text = "Pago Mixto / Otros"
        Else
            btnControlTipoPago.Visible = False
        End If

        txtCodigoArticulo.Focus()

    End Sub

    Sub FillPrecios()
        cbxPrecio.Items.Clear()
        CbxPrecioHeader.Items.Clear()

        If IDGrupo_Cliente <> "4" Then
            If btnControlTipoPago.Tag = 1 Then
                For Each item As String In Precios
                    cbxPrecio.Items.Add(item)
                    CbxPrecioHeader.Items.Add(item)
                Next

            ElseIf btnControlTipoPago.Tag = 2 Then

                For Each item As String In Precios
                    If item = "C" Or item = "D" Then
                    Else
                        cbxPrecio.Items.Add(item)
                        CbxPrecioHeader.Items.Add(item)
                    End If
                Next

            ElseIf btnControlTipoPago.Tag = 3 Then
                For Each item As String In Precios
                    cbxPrecio.Items.Add(item)
                    CbxPrecioHeader.Items.Add(item)
                Next
            End If

            If cbxPrecio.Items.Count > 0 Then
                cbxPrecio.SelectedIndex = 0
            End If

            If CbxPrecioHeader.Items.Count > 0 Then
                CbxPrecioHeader.SelectedIndex = 0
            End If

        Else
            cbxPrecio.Items.Add("F")
            CbxPrecioHeader.Items.Add("F")

            If cbxPrecio.Items.Count > 0 Then
                cbxPrecio.SelectedIndex = 0
            End If

            If CbxPrecioHeader.Items.Count > 0 Then
                CbxPrecioHeader.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub VerificacionTipoPago()
        If frm_especificar_tipopagos.Visible = False Then
            If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
                If TipoPagoMostrado = False Then
                    btnControlTipoPago.Visible = True
                    btnControlTipoPago.Image = My.Resources.Facturacion_x90
                    btnControlTipoPago.Text = "Pago Mixto / Otros"
                    frm_especificar_tipopagos.Show(Me)
                    frm_especificar_tipopagos.Focus()
                    frm_especificar_tipopagos.Activate()
                End If

            Else
                btnControlTipoPago.Visible = False
                btnControlTipoPago.Tag = 3
                btnControlTipoPago.Image = My.Resources.Facturacion_x90
                btnControlTipoPago.Text = "Pago Mixto / Otros"
            End If
        End If


    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        VerificacionTipoPago()
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        SumarTotalArticulo()
    End Sub

    Private Sub txtCantidadArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadArticulo.TextChanged
        Try
            If Fraccionamiento.Text = "0" Then
                If txtCodigoArticulo.Text <> "" Then
                    If txtCantidadArticulo.Text = "" Then
                        txtCantidadArticulo.Text = 1
                        txtCantidadArticulo.SelectAll()

                    ElseIf txtCantidadArticulo.Text = "0" Then
                        txtCantidadArticulo.Text = 1
                        txtCantidadArticulo.SelectAll()
                    End If
                End If

            ElseIf Fraccionamiento.Text = "1" Then
                If Len(txtCantidadArticulo.Text) = 1 Then
                    If txtCantidadArticulo.Text = "." Then
                        txtCantidadArticulo.Text = "0."
                        txtCantidadArticulo.SelectionStart = txtCantidadArticulo.TextLength
                    End If
                End If

                If txtCodigoArticulo.Text <> "" Then
                    If txtCantidadArticulo.Text = "0" Then
                        txtCantidadArticulo.Text = 1
                        txtCantidadArticulo.SelectAll()
                    End If
                End If
            End If



            SumarTotalArticulo()
        Catch ex As Exception

        End Try

    End Sub

    Sub SumarTotalArticulo()
        Try
            txtTotalArt.Text = (CDbl(txtCantidadArticulo.Text) * (CDbl(txtPrecio.Text))).ToString("C")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCantidadArticulo_Leave(sender As Object, e As EventArgs) Handles txtCantidadArticulo.Leave
        Try
            If txtCantidadArticulo.Text = CStr("") And txtCodigoArticulo.Text <> "" Then
                txtCantidadArticulo.Text = 1
            End If
            If txtCantidadArticulo.Text = 0 Then
                txtCantidadArticulo.Text = 1
            End If
            If IsNumeric(txtCantidadArticulo.Text) Then
            Else
                txtCantidadArticulo.Text = 1
            End If

        Catch ex As Exception
            txtCantidadArticulo.Text = 1
        End Try
    End Sub

    Sub SetInformacionArticulo()
        'Try

        Dim Ds As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,Articulos.RutaFoto,NoPermitirCambiarPrecio,NoPagoTarjeta,IDTipoProducto,VecesVendido,VecesComprado,ServicioPersonalizable FROM Articulos WHERE IDArticulo='" + txtCodigoArticulo.Text + "' and Articulos.Desactivar=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Articulos")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Articulos")

        If Tabla.Rows.Count = 0 Then
            ConLibregco.Open()
            Ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,Articulos.RutaFoto,NoPermitirCambiarPrecio,NoPagoTarjeta,IDTipoProducto,VecesVendido,VecesComprado,ServicioPersonalizable FROM Articulos WHERE Referencia='" + txtCodigoArticulo.Text + "' and Articulos.Desactivar=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Tabla = Ds.Tables("Articulos")

            If Tabla.Rows.Count = 0 Then
                ConLibregco.Open()
                Ds.Clear()
                cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,Articulos.RutaFoto,NoPermitirCambiarPrecio,NoPagoTarjeta,IDTipoProducto,VecesVendido,VecesComprado,ServicioPersonalizable FROM Articulos WHERE CodigoBarra='" + txtCodigoArticulo.Text + "' and Articulos.Desactivar=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Articulos")
                ConLibregco.Close()

                Tabla = Ds.Tables("Articulos")

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                Else
                    If btnControlTipoPago.Tag = 2 Then
                        If (Tabla.Rows(0).Item("NoPagoTarjeta")) = 1 Then
                            MessageBox.Show("El artículo seleccionado: " & (Tabla.Rows(0).Item("Descripcion")) & " posee un bloqueo de facturación con tarjeta de crédito por lo que en estos momentos la operación no puede completarse.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            txtCodigoArticulo.Clear()
                            Exit Sub
                        End If
                    End If

                    If CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1 Then
                        If CDbl(Tabla.Rows(0).Item("VecesVendido")) = 0 And CDbl(Tabla.Rows(0).Item("VecesComprado")) = 0 Then
                            MessageBox.Show("La facturación de artículos sin transacciones de ventas o compras está bloqueada del sistema. Para arreglar esta opción por favor visite el apartado de Ajustes de Empresa en el encabezado de facturación.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If

                    txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                    lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))
                    lblIDTipoProducto.Text = Tabla.Rows(0).Item("IDTipoProducto")

                    If TypeConnection.Text = 1 Then
                        If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                            PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                PicFoto.Image = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                                wFile.Close()
                            Else
                                PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                            End If
                        End If
                    Else
                        PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                    End If


                    If CInt(Tabla.Rows(0).Item("NoPermitirCambiarPrecio")) = 1 Then
                        txtPrecio.ReadOnly = True
                    Else
                        txtPrecio.ReadOnly = False
                    End If

                    If ModifyingProduct = False Then
                        If txtCantidadArticulo.Text = "" Then
                            txtCantidadArticulo.Text = 1
                        End If
                    End If

                    lblDescuento.Text = 0
                    FillMedida()
                    CargarExistenciasTreeView()

                End If
            Else

                If btnControlTipoPago.Tag = 2 Then
                    If (Tabla.Rows(0).Item("NoPagoTarjeta")) = 1 Then
                        MessageBox.Show("El artículo seleccionado: " & (Tabla.Rows(0).Item("Descripcion")) & " posee un bloqueo de facturación con tarjeta de crédito por lo que en estos momentos la operación no puede completarse.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtCodigoArticulo.Clear()
                        Exit Sub
                    End If
                End If

                If CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1 Then
                    If CDbl(Tabla.Rows(0).Item("VecesVendido")) = 0 And CDbl(Tabla.Rows(0).Item("VecesComprado")) = 0 Then
                        MessageBox.Show("La facturación de artículos sin transacciones de ventas o compras está bloqueada del sistema. Para arreglar esta opción por favor visite el apartado de Ajustes de Empresa en el encabezado de facturación.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If

                txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))
                lblIDTipoProducto.Text = Tabla.Rows(0).Item("IDTipoProducto")

                If TypeConnection.Text = 1 Then
                    If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                        PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                            PicFoto.Image = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                            wFile.Close()
                        Else
                            PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                        End If
                    End If
                Else
                    PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                End If

                If CInt(Tabla.Rows(0).Item("NoPermitirCambiarPrecio")) = 1 Then
                    txtPrecio.ReadOnly = True
                Else
                    txtPrecio.ReadOnly = False
                End If

                If ModifyingProduct = False Then
                    If txtCantidadArticulo.Text = "" Then
                        txtCantidadArticulo.Text = 1
                    End If
                End If

                lblDescuento.Text = 0
                FillMedida()
                CargarExistenciasTreeView()

            End If
        Else

            If btnControlTipoPago.Tag = 2 Then
                If (Tabla.Rows(0).Item("NoPagoTarjeta")) = 1 Then
                    MessageBox.Show("El artículo seleccionado: " & (Tabla.Rows(0).Item("Descripcion")) & " posee un bloqueo de facturación con tarjeta de crédito por lo que en estos momentos la operación no puede completarse.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtCodigoArticulo.Clear()
                    Exit Sub
                End If
            End If

            If CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1 Then
                If CDbl(Tabla.Rows(0).Item("VecesVendido")) = 0 And CDbl(Tabla.Rows(0).Item("VecesComprado")) = 0 Then
                    MessageBox.Show("La facturación de artículos sin transacciones de ventas o compras está bloqueada del sistema. Para arreglar esta opción por favor visite el apartado de Ajustes de Empresa en el encabezado de facturación.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
            IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
            txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
            lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))
            lblIDTipoProducto.Text = Tabla.Rows(0).Item("IDTipoProducto")

            If TypeConnection.Text = 1 Then
                If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                    PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        PicFoto.Image = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                        wFile.Close()
                    Else
                        PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                    End If
                End If
            Else
                PicFoto.Image = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
            End If

            If CInt(Tabla.Rows(0).Item("NoPermitirCambiarPrecio")) = 1 Then
                txtPrecio.ReadOnly = True
            Else
                txtPrecio.ReadOnly = False
            End If

            If ModifyingProduct = False Then
                If txtCantidadArticulo.Text = "" Then
                    txtCantidadArticulo.Text = 1
                End If
            End If

            lblDescuento.Text = 0

            FillMedida()

            CargarExistenciasTreeView()

        End If

        If txtCodigoArticulo.Text = "1" Then
            If CInt(DTConfiguracion.Rows(128 - 1).Item("Value2Int")) = 1 Then
                txtDescripcionArticulo.ReadOnly = False
                txtDescripcionArticulo.Enabled = True
                txtDescripcionArticulo.Focus()
            Else
                txtDescripcionArticulo.ReadOnly = True
                txtDescripcionArticulo.Enabled = False
            End If
        Else
            If Tabla.Rows(0).Item("ServicioPersonalizable") = "1" Then
                txtDescripcionArticulo.ReadOnly = False
                txtDescripcionArticulo.Enabled = True
                txtDescripcionArticulo.Focus()
            Else
                txtDescripcionArticulo.ReadOnly = True
                txtDescripcionArticulo.Enabled = False
            End If
        End If

        If txtDescripcionArticulo.Text.Contains("TOLA PERSONALIZABLE") Or txtDescripcionArticulo.Text.Contains("Tola Personalizable") Or txtDescripcionArticulo.Text.Contains("TOLA PERSONALIZADA") Or txtDescripcionArticulo.Text.Contains("Tola Personalizada") Then
            frm_calculo_tolas.ShowDialog(Me)
        End If

        'Catch ex As Exception
        '    'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub txtCodigoArticulo_Leave(sender As Object, e As EventArgs) Handles txtCodigoArticulo.Leave
        Try
            If txtCodigoArticulo.Text = "" Then
                LimpiarDatosArticulo2()
                FlowSimilares.Controls.Clear()
                SplitSimilares.Panel2Collapsed = True
                SplitContainer1.Panel1Collapsed = True
            Else

                If Len(txtCodigoArticulo.Text) = 1 Then
                    If IsNumeric(txtCodigoArticulo.Text) = False Then
                        txtCodigoArticulo.Clear()
                        SplitContainer1.Panel1Collapsed = True
                        Exit Sub
                    End If
                End If


                If txtCodigoArticulo.Text.Substring(0, 1) = "-" Then
                    If dgvArticulosFactura.Rows.Count > 0 Then
                        Dim Index As Integer = txtCodigoArticulo.Text.Remove(0, 1)
                        If Index > 0 Then
                            If dgvArticulosFactura.Rows.Count >= Index - 1 Then
                                If CStr(dgvArticulosFactura.Rows(Index - 1).Cells(0).Value) = "" Then
                                    dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.Rows(Index - 1))
                                    LimpiarDatosArticulos()
                                    FlowSimilares.Controls.Clear()
                                    SplitSimilares.Panel2Collapsed = True
                                    SumTotales()

                                Else
                                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo?", "Eliminar artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    If Result = MsgBoxResult.Yes Then
                                        Dim Modifiable, IDFacturaArticulos As New Label
                                        Con.Open()
                                        cmd = New MySqlCommand("SELECT Cierre FROM" & SysName.Text & "prefactura where IDPreFactura='" + txtIDFactura.Text + "'", Con)
                                        Modifiable.Text = Convert.ToString(cmd.ExecuteScalar())
                                        Con.Close()

                                        IDFacturaArticulos.Text = dgvArticulosFactura.Rows(Index - 1).Cells(0).Value

                                        If CDbl(Modifiable.Text) = 0 Then
                                            Con.Open()
                                            sqlQ = "Delete from" & SysName.Text & "PreFacturaArticulos Where IDPreFactArt= '" + IDFacturaArticulos.Text + "'"
                                            cmd = New MySqlCommand(sqlQ, Con)
                                            cmd.ExecuteNonQuery()
                                            Con.Close()

                                            Dim dsTemp As New DataSet
                                            Con.Open()
                                            cmd = New MySqlCommand("SELECT IDProductosHijos,IDPrecioPadre,CantidadParaOferta,MedidaPadre.Medida,PrecioArticuloHijo.IDArticulo, ArticulosHijo.Descripcion, ArticulosHijo.Referencia, CantidadEnOferta, IDPrecioHijo, MedidaHijo.Medida, LimitarHastaFecha, HastaFecha, ValorIncluidoPrecio, Nivel, Precio, Articulos_hijos.Nulo FROM Libregco.articulos_hijos INNER JOIN Libregco.PrecioArticulo as PrecioArticuloPadre on articulos_hijos.IDPrecioPadre=PrecioarticuloPadre.IDPrecios INNER JOIN Libregco.Medida as MedidaPadre on PrecioArticuloPadre.IDMedida=MedidaPadre.IDMedida INNER JOIN Libregco.Articulos as ArticulosPadre on PrecioArticuloPadre.IDArticulo=ArticulosPadre.IDArticulo INNER JOIN Libregco.PrecioArticulo as PrecioArticuloHijo on articulos_hijos.IDPrecioHijo=PrecioarticuloHijo.IDPrecios INNER JOIN Libregco.Articulos as ArticulosHijo on PrecioArticuloHijo.IDArticulo=ArticulosHijo.IDArticulo INNER JOIN Libregco.Medida as MedidaHijo on PrecioArticuloHijo.IDMedida=MedidaHijo.IDMedida Where PrecioArticuloPadre.IDArticulo ='" + dgvArticulosFactura.Rows(Index - 1).Cells(4).Value.ToString + "' and articulos_hijos.Nulo=0", Con)
                                            Adaptador = New MySqlDataAdapter(cmd)
                                            Adaptador.Fill(dsTemp, "Articulos")
                                            Con.Close()

                                            Dim Tabla As DataTable = dsTemp.Tables("Articulos")

                                            For Each rw As DataGridViewRow In dgvArticulosFactura.Rows
                                                If rw.Cells(15).Value = 1 Then

                                                    For Each dt As DataRow In Tabla.Rows

                                                        If dt.Item("IDPrecioHijo") = rw.Cells(2).Value Then
                                                            dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.Rows(rw.Index))
                                                        End If
                                                    Next
                                                End If
                                            Next

                                            Tabla.Dispose()

                                            dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.Rows(Index - 1))
                                            SumTotales()

                                            sqlQ = "UPDATE" & SysName.Text & "PreFactura SET TotalNeto='" + CDbl(txtNeto.Text).ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
                                            GuardarDatos()

                                            LimpiarDatosArticulos()
                                            FlowSimilares.Controls.Clear()
                                            SplitSimilares.Panel2Collapsed = True

                                            MessageBox.Show("El artículo ha sido eliminado satisfactoriamente.", "Artículo eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        Else

                                            MessageBox.Show("No es posible eliminar el artículo ya que hay registro(s) de seriales en la base de datos.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        End If

                                    Else
                                        MessageBox.Show("Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad.", "La factura no se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    End If

                                End If

                            Else
                                LimpiarDatosArticulos()
                                FlowSimilares.Controls.Clear()
                                SplitSimilares.Panel2Collapsed = True

                            End If
                        Else
                            LimpiarDatosArticulos()
                            FlowSimilares.Controls.Clear()
                            SplitSimilares.Panel2Collapsed = True
                        End If

                    Else
                        LimpiarDatosArticulos()
                    End If
                ElseIf txtCodigoArticulo.Text.Substring(0, 1) = "*" Then
                    Dim Index As Integer = txtCodigoArticulo.Text.Remove(0, 1)
                    If Index > 0 Then
                        If dgvArticulosFactura.Rows.Count >= Index - 1 Then
                            LimpiarDatosArticulo2()
                            FlowSimilares.Controls.Clear()
                            SplitSimilares.Panel2Collapsed = True
                            dgvArticulosFactura.Focus()
                            dgvArticulosFactura.Rows(Index - 1).Selected = True
                            dgvArticulosFactura.FirstDisplayedScrollingRowIndex = Index - 1
                            dgvArticulosFactura.CurrentCell = Me.dgvArticulosFactura.Rows(Index - 1).Cells(0)
                        Else
                            LimpiarDatosArticulo2()
                            FlowSimilares.Controls.Clear()
                            SplitSimilares.Panel2Collapsed = True
                        End If
                        LimpiarDatosArticulo2()
                        FlowSimilares.Controls.Clear()
                        SplitSimilares.Panel2Collapsed = True
                    Else
                        LimpiarDatosArticulo2()
                    End If

                    LimpiarDatosArticulo2()
                    FlowSimilares.Controls.Clear()
                    SplitSimilares.Panel2Collapsed = True

                Else
                    lblIDAlmacenArticulo.Text = lblIDAlmacen.Text
                    SetInformacionArticulo()

                    FlowSimilares.Controls.Clear()

                    If DoSimilarities.IsBusy = True Then
                        DoSimilarities.CancelAsync()
                    Else
                        DoSimilarities.RunWorkerAsync()
                    End If


                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArticulo.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "-*0123456789abcdefghijklmnñopqrstuvwxyz"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        'If (txtCodigoArticulo.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub txtCantidadArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadArticulo.KeyPress
        Try
            If Fraccionamiento.Text = 1 Then
                If Not (Asc(e.KeyChar) = 8) Then
                    Dim allowedChars As String = ".0123456789"
                    If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                        e.KeyChar = ChrW(0)
                        e.Handled = True
                    End If
                End If

                If (txtCantidadArticulo.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
                    e.Handled = True
                End If

            ElseIf Fraccionamiento.Text = 0 Then
                If Not (Asc(e.KeyChar) = 8) Then
                    Dim allowedChars As String = "0123456789"
                    If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                        e.KeyChar = ChrW(0)
                        e.Handled = True
                    End If
                End If
            End If

            'If Fraccionamiento.Text = 1 Then
            '    Dim Car% = Asc(e.KeyChar)
            '    Select Case Car
            '        Case 8
            '        Case 46
            '        Case 48 To 57
            '        Case Else
            '            e.KeyChar = Nothing
            '    End Select

            '    If (txtCantidadArticulo.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            '        e.Handled = True
            '    End If
            'Else

            '    Dim Car% = Asc(e.KeyChar)
            '    Select Case Car
            '        Case 8
            '        'Case 46
            '        Case 48 To 57
            '        Case Else
            '            e.KeyChar = Nothing
            '    End Select
            'End If


        Catch ex As Exception

        End Try


    End Sub

    Private Sub FillMedida()
        'Try
        Dim ds As New DataSet
        ConLibregco.Open()

        cmd = New MySqlCommand("SELECT OrdenPrecios From Articulos where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)

        If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
            cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + IDArticulo.Text + "' and PrecioArticulo.Nulo=0 order by contenido desc", ConLibregco)
        Else
            cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + IDArticulo.Text + "' and PrecioArticulo.Nulo=0 order by contenido asc", ConLibregco)
        End If

        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "PrecioArticulo")
        CbxMedida.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = ds.Tables("PrecioArticulo")

        For Each Fila As DataRow In Tabla.Rows
            CbxMedida.Items.Add(Fila.Item("Abreviatura"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron registros de medidas del artículo consultado.", "No hay registros de precios para el artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ElseIf Tabla.Rows.Count > 0 Then
            CbxMedida.SelectedIndex = 0
        End If

        If cbxPrecio.Items.Count > 0 Then
            cbxPrecio.Text = txtNivelPrecio.Text
        End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
        BuscarVentas()
    End Sub

    Private Sub BuscarVentas()
        If CStr(lblIDMedida.Text) <> "" Then
            If lblIDPrecio.Text <> "" Then
                If txtIDCliente.Text <> "1" Then
                    Dim dstemp As New DataSet

                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT (FacturaArticulos.Importe/FacturaArticulos.Cantidad) as UltimoPrecio,timestamp(facturadatos.fecha,facturadatos.hora) AS Fecha,if(Precio4=0,if(Precio3=0,if(PrecioContado=0,PrecioCredito,PrecioContado),Precio3),Precio4) as PrecioMinimoDisponible,if(Precio4=0,if(Precio3=0,if(PrecioContado=0,'A','B'),'C'),'D') as Nivel FROM" & SysName.Text & "facturaarticulos inner join" & SysName.Text & "facturadatos on facturaarticulos.idfactura=facturadatos.idfacturadatos INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios where facturadatos.IDCliente='" + txtIDCliente.Text + "' and FacturaArticulos.IDPrecio='" + lblIDPrecio.Text + "' order by timestamp(facturadatos.fecha,facturadatos.hora) DESC LIMIT 1", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(dstemp, "Precios")
                    ConMixta.Close()

                    Dim Tabla As DataTable = dstemp.Tables("Precios")

                    If Tabla.Rows.Count > 0 Then
                        If CDbl(Tabla.Rows(0).Item("UltimoPrecio")) >= CDbl(Tabla.Rows(0).Item("PrecioMinimoDisponible")) Then
                            Label5.ForeColor = SystemColors.Highlight
                            Label5.Text = "El último precio utilizado para " & txtNombre.Text & " fue " & CDbl(Tabla.Rows(0).Item("UltimoPrecio")).ToString("C") & " en fecha " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                            SimpleButton1.Tag = CDbl(Tabla.Rows(0).Item("UltimoPrecio"))

                            If chkAplicarAutomaticamente.Checked = True Then
                                cbxPrecio.Text = GetPriceLevel(CDbl(SimpleButton1.Tag), lblIDPrecio.Text, cbxMoneda.EditValue.ToString)
                                txtPrecio.Text = CDbl(SimpleButton1.Tag).ToString("C")
                            End If

                        Else
                            Label5.ForeColor = Color.Red
                            Label5.Text = "El último precio dado a  " & txtNombre.Text & " (" & CDbl(Tabla.Rows(0).Item("UltimoPrecio")).ToString("C") & ") ofrecido en fecha " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & " ya excede el precio mínimo autorizado."
                            SimpleButton1.Tag = CDbl(Tabla.Rows(0).Item("PrecioMinimoDisponible"))
                        End If

                        SplitContainer1.Panel1Collapsed = False

                        chkAplicarAutomaticamente.Location = New Point(Label5.Location.X + Label5.Size.Width + 5, chkAplicarAutomaticamente.Location.Y)

                    Else
                        SplitContainer1.Panel1Collapsed = True
                    End If

                    Ds.Clear()
                    Tabla.Dispose()
                End If
            End If
        End If
    End Sub
    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select PrecioArticulo.IDMedida FROM precioarticulo INNER JOIN Medida On PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDMedida.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Fraccionamiento FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        Fraccionamiento.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDPrecio.Text = Convert.ToString(cmd.ExecuteScalar())

        ConLibregco.Close()

        txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C")

        If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
            If btnControlTipoPago.Tag = 2 Then

                ConLibregco.Open()

                cmd = New MySqlCommand("SELECT CobrarComision From Articulos where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)

                If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
                    cmd = New MySqlCommand("SELECT PorcentajeComision From Articulos where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)
                    txtPrecio.Text = (CDbl(txtPrecio.Text) * (1 + (CDbl(Convert.ToDouble(cmd.ExecuteScalar())) / 100))).ToString("C")
                End If

                ConLibregco.Close()

            End If
        End If
    End Sub

    Private Sub BuscarItebis()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtCodigoArticulo.Text + "'", ConLibregco)
        lblItbisArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0

Inicio:
        If x = dgvArticulosFactura.Rows.Count Or dgvArticulosFactura.Rows.Count = 0 Then
            lblCheckDuplicates.Text = 0
            Exit Sub
        End If

        If dgvArticulosFactura.Rows(x).Cells(2).Value = lblIDPrecio.Text Then
            MessageBox.Show("Este artículo ya se encuentra en la factura con la misma medida." & vbNewLine & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtCodigoArticulo.Focus()
            txtCodigoArticulo.SelectAll()
            lblCheckDuplicates.Text = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub BuscarHijos()
        Try
            Dim dsTemp As New DataSet

            If txtIDFactura.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("SELECT IDProductosHijos,IDPrecioPadre,CantidadParaOferta,MedidaPadre.Medida,PrecioArticuloHijo.IDArticulo,ArticulosHijo.Descripcion,ArticulosHijo.Referencia,CantidadEnOferta,IDPrecioHijo,MedidaHijo.Medida,LimitarHastaFecha,HastaFecha,ValorIncluidoPrecio,Nivel,Precio,Articulos_hijos.Nulo,ArticulosHijo.RutaFoto FROM Libregco.articulos_hijos INNER JOIN Libregco.PrecioArticulo as PrecioArticuloPadre on articulos_hijos.IDPrecioPadre=PrecioarticuloPadre.IDPrecios INNER JOIN Libregco.Medida as MedidaPadre on PrecioArticuloPadre.IDMedida=MedidaPadre.IDMedida INNER JOIN Libregco.Articulos as ArticulosPadre on PrecioArticuloPadre.IDArticulo=ArticulosPadre.IDArticulo INNER JOIN Libregco.PrecioArticulo as PrecioArticuloHijo on articulos_hijos.IDPrecioHijo=PrecioarticuloHijo.IDPrecios INNER JOIN Libregco.Articulos as ArticulosHijo on PrecioArticuloHijo.IDArticulo=ArticulosHijo.IDArticulo INNER JOIN Libregco.Medida as MedidaHijo on PrecioArticuloHijo.IDMedida=MedidaHijo.IDMedida Where PrecioArticuloPadre.IDArticulo='" + txtCodigoArticulo.Text + "' and articulos_hijos.Nulo=0", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dsTemp, "Articulos")
                Con.Close()

                If dsTemp.Tables("Articulos").Rows.Count > 0 Then

                    For Each row As DataRow In dsTemp.Tables("Articulos").Rows

                        'Si la fecha es valida
                        If row.Item(10) = 1 Or CDate(row.Item(11)) >= Today Then

                            'Si la cantidad aplica
                            If CDbl(txtCantidadArticulo.Text) >= row.Item(2) Then

                                'Busco en los articulos de la factura
                                If lblIDPrecio.Text = row.Item(1) Then

                                    Dim CantidadOfertaGenerada As Integer = CInt(txtCantidadArticulo.Text) * CInt(row.Item(7))
                                    txtCodigoArticulo.Text = row.Item(4)
                                    SetInformacionArticulo()

                                    ConLibregco.Open()
                                    cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtCodigoArticulo.Text + "'", ConLibregco)
                                    lblItbisArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
                                    ConLibregco.Close()

                                    If row.Item(12) = 1 Then
                                        dgvArticulosFactura.Rows.Add(lblIDFactArt.Text, txtIDFactura.Text, lblIDPrecio.Text, lblIDMedida.Text, IDArticulo.Text, CantidadOfertaGenerada, CbxMedida.Text, "+ " & txtDescripcionArticulo.Text, CDbl(txtPrecio.Text).ToString("C"), (CDbl(txtPrecio.Text) / (1 + CDbl(lblItbisArt.Text))), (CDbl(txtPrecio.Text) / (1 + CDbl(lblItbisArt.Text))), (0).ToString("C"), (0).ToString("C"), lblIDAlmacenArticulo.Text, cbxPrecio.Text, 1)
                                    Else
                                        dgvArticulosFactura.Rows.Add(lblIDFactArt.Text, txtIDFactura.Text, lblIDPrecio.Text, lblIDMedida.Text, IDArticulo.Text, CantidadOfertaGenerada, CbxMedida.Text, txtDescripcionArticulo.Text, CDbl(txtPrecio.Text).ToString("C"), (CDbl(txtPrecio.Text) / (1 + CDbl(lblItbisArt.Text))), CDbl(lblDescuento.Text).ToString("C"), ((CDbl(txtPrecio.Text) / (CantidadOfertaGenerada + CDbl(lblItbisArt.Text))) * CDbl(lblItbisArt.Text)).ToString("C"), CDbl(txtPrecio.Text) * CantidadOfertaGenerada, lblIDAlmacenArticulo.Text, cbxPrecio.Text, 1)
                                    End If

                                End If
                            End If
                        End If
                    Next

                    SumTotales()
                End If

                dgvArticulosFactura.ClearSelection()
                dsTemp.Dispose()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnInsertarArticulo_Click(sender As Object, e As EventArgs) Handles btnInsertarArticulo.Click
        'Try

        If txtCodigoArticulo.Text = "" Then
                MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtCodigoArticulo.Focus()

            Else

                If CbxMedida.Items.Count > 0 Then
                    'Si no es un  servicio
                    If lblIDTipoProducto.Text <> 2 Then
                    If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
                        If IDArticulo.Text = 1 Then
                            If CInt(DTConfiguracion.Rows(129 - 1).Item("Value2Int")) = 0 Then
                                If txtIDFactura.Text = "" Then
                                    If CDbl(lblExistencia.Text) < CDbl(txtCantidadArticulo.Text) Then
                                        MessageBox.Show("No se puede facturar el artículo [" & txtCodigoArticulo.Text & "] " & txtDescripcionArticulo.Text & ", ya que no tiene las existencias requeridas en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        Exit Sub
                                    End If
                                End If
                            End If

                        Else
                            If txtIDFactura.Text = "" Then
                                If CDbl(lblExistencia.Text) < CDbl(txtCantidadArticulo.Text) Then
                                    MessageBox.Show("No se puede facturar el artículo [" & txtCodigoArticulo.Text & "] " & txtDescripcionArticulo.Text & ", ya que no tiene las existencias requeridas en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    Exit Sub
                                End If
                            End If

                        End If
                    End If
                End If

                If Fraccionamiento.Text = 0 Then
                    txtCantidadArticulo.Text = TruncateDecimal(txtCantidadArticulo.Text)
                End If

                SumarTotalArticulo()

                If cbxPrecio.Text = "" Then
                    MessageBox.Show("Seleccione un nivel de precio del producto para insertar a la prefactura.", "Seleccione un nivel de precio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    cbxPrecio.Focus()
                    cbxPrecio.DroppedDown = True
                    Exit Sub
                End If

                If CInt(BloqueoPrecioCero) = 1 Then
                    If CDbl(txtPrecio.Text) = 0 Then
                        MessageBox.Show("En estos momentos todo precio 0 está bloqueado a nivel de facturación.", "Precio no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If

                If CInt(DTConfiguracion.Rows(170 - 1).Item("Value2Int")) = 0 Then
                    VerificarDuplicados()
                    If lblCheckDuplicates.Text = 1 Then
                        Exit Sub
                    End If
                End If


                BuscarItebis()
                'FlowProbabilidades.Controls.Clear()
                SplitSimilares.Panel2Collapsed = True

                    With dgvArticulosFactura
                        .Rows.Add(lblIDFactArt.Text, txtIDFactura.Text, lblIDPrecio.Text, lblIDMedida.Text, IDArticulo.Text, txtCantidadArticulo.Text, CbxMedida.Text, txtDescripcionArticulo.Text, CDbl(txtPrecio.Text).ToString("C4"), (CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArt.Text))).ToString("C4"), CDbl(lblDescuento.Text).ToString("C4"), ((CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArt.Text))) * CDbl(lblItbisArt.Text)).ToString("C4"), (CDbl(txtPrecio.Text) * CDbl(txtCantidadArticulo.Text)).ToString("C4"), lblIDAlmacenArticulo.Text, GetPriceLevel(CDbl(txtPrecio.Text), lblIDPrecio.Text, cbxMoneda.EditValue.ToString), 0, Fraccionamiento.Text)
                    End With

                    BuscarHijos()
                    SumTotales()

                    dgvArticulosFactura.FirstDisplayedScrollingRowIndex = dgvArticulosFactura.Rows.Count - 1

                    LimpiarDatosArticulos()
                    dgvArticulosFactura.ClearSelection()
                    ModifyingProduct = False
                    btnModificar.Enabled = True
                    btnQuitarArticulo.Enabled = True
                    btnBlanquear.Enabled = True
                    txtDescripcionArticulo.ReadOnly = True
                    txtDescripcionArticulo.Enabled = False
                    txtPrecio.ReadOnly = False
                    cbxPrecio.Text = txtNivelPrecio.Text
                    SplitContainer1.Panel1Collapsed = True
                    txtCodigoArticulo.Focus()

                    If dgvArticulosFactura.Rows.Count > 0 Then
                        cbxMoneda.Enabled = False
                    End If
                End If
            End If

        'Catch ex As Exception
        '    'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Sub SumTotales()
        Try
            Dim SubTotal As Double = 0
            Dim Descuentos As Double = 0
            Dim Itbis As Double = 0
            Dim Importe As Double = 0

            For Each Rows As DataGridViewRow In dgvArticulosFactura.Rows
                SubTotal = SubTotal + (CDbl(Rows.Cells(9).Value) * (CDbl(Rows.Cells(4).Value)))
                Descuentos = Descuentos + (CDbl(Rows.Cells(10).Value))
                Itbis = Itbis + ((CDbl(Rows.Cells(11).Value)) * (CDbl(Rows.Cells(4).Value)))
                Importe = Importe + (CDbl(Rows.Cells(12).Value))
            Next

            txtNeto.Text = (Importe).ToString("C")

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub HabilitarControles()
        txtCodigoArticulo.Enabled = True
        txtPrecio.Enabled = True
        btnBuscarArticulo.Enabled = True
        txtCantidadArticulo.Enabled = True
        txtDescripcionArticulo.Enabled = True
        dgvArticulosFactura.Enabled = True
        CbxMedida.Enabled = True
        btnInsertarArticulo.Enabled = True
        btnBuscarCliente.Enabled = True
        cbxPrecio.Enabled = True
        Hora.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        txtCodigoArticulo.Enabled = False
        btnBuscarArticulo.Enabled = False
        txtCantidadArticulo.Enabled = False
        txtDescripcionArticulo.Enabled = False
        dgvArticulosFactura.Enabled = False
        CbxMedida.Enabled = False
        btnInsertarArticulo.Enabled = False
        btnBuscarCliente.Enabled = False
        txtPrecio.Enabled = False
        cbxPrecio.Enabled = False
        Hora.Enabled = False
    End Sub

    Private Sub dgvArticulosFactura_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvArticulosFactura.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < dgvArticulosFactura.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If dgvArticulosFactura.RowHeadersWidth < CInt(size.Width + 20) Then
                dgvArticulosFactura.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=53", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE PreFactura SET SecondID='" + lblSecondID.Text + "' WHERE IDPreFactura='" + txtIDFactura.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=53"
            GuardarDatos()

            DsTemp.Dispose()
            Tabla.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GuardarDatos()
        Try

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
            If ConLibregco.State = ConnectionState.Open Then
                ConLibregco.Close()
            End If
            '--------------------------------------------------------

            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            Con.Close()
            ConLibregco.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltPreFactura()
        If txtIDFactura.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDPreFactura from Prefactura where IDPrefactura= (Select Max(IDPrefactura) from Prefactura)", Con)
            txtIDFactura.Text = Convert.ToDouble(cmd.ExecuteScalar())

            If IsNumeric(Cotizacion) Then
                sqlQ = "UPDATE" & SysName.Text & "Prefactura SET IDCotizacion='" + Cotizacion + "' WHERE IDPrefactura=(" + txtIDFactura.Text + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

                sqlQ = "UPDATE" & SysName.Text & "Cotizacion SET EstadoCotizacion=1 WHERE IDCotizacion=(" + Cotizacion + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If

            Con.Close()
        End If
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Value = Today.ToString("dd/MM/yyyy")
        txtHora.Value = DateTime.Now
    End Sub

    Private Sub InsertArticulos()
        For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
            If CStr(Row.Cells(0).Value).ToString = "" Then
                sqlQ = "INSERT INTO PrefacturaArticulos (IDPreFactura,IDPrecio,IDArticulo,IDMedida,Medida,Cantidad,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo) VALUES ('" + txtIDFactura.Text + "', '" + Row.Cells(2).Value.ToString + "','" + Row.Cells(4).Value.ToString + "','" + Row.Cells(3).Value.ToString + "','" + Row.Cells(6).Value.ToString + "','" + Row.Cells(5).Value.ToString + "','" + Row.Cells(7).Value.ToString + "','" + CDbl(Row.Cells(9).Value).ToString + "','" + CDbl(Row.Cells(10).Value).ToString + "','" + CDbl(Row.Cells(11).Value).ToString + "','" + CDbl(Row.Cells(12).Value).ToString + "','" + Row.Cells(13).Value.ToString + "','" + Row.Cells(14).Value.ToString + "') "
                GuardarDatos()
            Else
                sqlQ = "UPDATE PreFacturaArticulos SET IDPreFactura='" + Row.Cells(1).Value.ToString + "',IDPrecio='" + Row.Cells(2).Value.ToString + "',IDArticulo='" + Row.Cells(4).Value.ToString + "',IDMedida='" + Row.Cells(3).Value.ToString + "',Medida='" + Row.Cells(6).Value.ToString + "',Cantidad='" + Row.Cells(5).Value.ToString + "',Descripcion='" + Row.Cells(7).Value.ToString + "',PrecioUnitario='" + CDbl(Row.Cells(9).Value).ToString + "',Descuento='" + CDbl(Row.Cells(10).Value).ToString + "',Itbis='" + CDbl(Row.Cells(11).Value).ToString + "',Importe='" + CDbl(Row.Cells(12).Value).ToString + "',IDAlmacen='" + Row.Cells(13).Value.ToString + "',NivelPrecioArticulo='" + Row.Cells(14).Value.ToString + "' Where IDPreFactArt='" + Row.Cells(0).Value.ToString + "'"
                GuardarDatos()
            End If
        Next

        RefrescarTablaConsulta()
    End Sub

    Sub RefrescarTablaConsulta()
        Try
            Dim Contmp As New MySqlConnection(CnGeneral)

            dgvArticulosFactura.Rows.Clear()
            Contmp.Open()
            Dim Consulta As New MySqlCommand("Select IDPreFactArt,IDPreFactura,IDPrecio,PrefacturaArticulos.IDMedida,prefacturaarticulos.IDArticulo,Cantidad,PrefacturaArticulos.Medida,prefacturaarticulos.Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo,Fraccionamiento from" & SysName.Text & "prefacturaarticulos INNER JOIN Libregco.Medida on PrefacturaArticulos.IDMedida=Medida.IDMedida WHERE IDPreFactura='" + txtIDFactura.Text + "'", Contmp)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read
                dgvArticulosFactura.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), (CDbl(LectorArticulos.GetValue(8)) + CDbl(LectorArticulos.GetValue(10))).ToString("C4"), CDbl(LectorArticulos.GetValue(8)).ToString("C4"), CDbl(LectorArticulos.GetValue(9)).ToString("C4"), CDbl(LectorArticulos.GetValue(10)).ToString("C4"), CDbl(LectorArticulos.GetValue(11)).ToString("C4"), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), 0, LectorArticulos.GetValue(14))
            End While

            LectorArticulos.Close()
            Contmp.Close()
            Contmp.Dispose()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDFactura.Text = "" Then
            If dgvArticulosFactura.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de prefacturación?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                    VerificacionTipoPago()
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
                VerificacionTipoPago()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
            VerificacionTipoPago()
        End If
    End Sub

    Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
        If txtPrecio.Text = "" Then
        Else
            txtPrecio.Text = CDbl(txtPrecio.Text)
            txtPrecio.SelectAll()
        End If
    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        Dim DsPrecios As New DataSet
        Dim CostoFinal, VenderCosto, DescuentoMaximo, PrecioMinimoA, PrecioMinimoB As New Label

        Try

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT TasaCompra FROM TipoMoneda WHERE IDTipoMoneda= '" + cbxMoneda.EditValue.ToString + "'", ConLibregco)
            Dim Tasa As Double = Convert.ToDouble(cmd.ExecuteScalar())
            ConLibregco.Close()


            If txtCodigoArticulo.Text <> "" And cbxPrecio.Text <> "" Then
                If txtPrecio.Text <> "" Then
                    If IsNumeric(CDbl(txtPrecio.Text)) Then
                        If txtCodigoArticulo.Text <> "" And lblIDMedida.Text <> "" Then
                            PrecioMinimoA.Text = GetMinimoPrecio("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)
                            PrecioMinimoB.Text = GetMinimoPrecio("B", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)

                            If IsNumeric(txtPrecio.Text) Then
                                If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 1 Then         'Si puedo facturar por debajo del costo 
                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                    If cbxPrecio.Text = "A" Then
                                        If CDbl(txtPrecio.Text) > CDbl(GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) Then
                                            lblDescuento.Text = CDbl(0).ToString("C")
                                        Else
                                            lblDescuento.Text = CDbl(CDbl(GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) - CDbl(txtPrecio.Text)).ToString("C")
                                        End If
                                    ElseIf cbxPrecio.Text = "B" Then
                                        If CDbl(txtPrecio.Text) > CDbl(GetPrices("B", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) Then
                                            lblDescuento.Text = CDbl(0).ToString("C")
                                        Else
                                            lblDescuento.Text = CDbl(CDbl(GetPrices("B", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) - CDbl(txtPrecio.Text)).ToString("C")
                                        End If
                                    End If
                                Else
                                    'Verifico si el articulo se puede vender al costo
                                    ConLibregco.Open()
                                    cmd = New MySqlCommand("SELECT VenderCosto FROM Articulos Where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)
                                    VenderCosto.Text = Convert.ToDouble(cmd.ExecuteScalar())
                                    ConLibregco.Close()

                                    If VenderCosto.Text = 1 Then    'Si se puede vender al costo
                                        If CDbl(txtPrecio.Text) >= CDbl(GetPrices("E", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) Then
                                            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        Else
                                            MessageBox.Show("El precio establecido excede el costo del producto." & vbNewLine & vbNewLine & "El artículo está autorizado y disponible para venderse al costo, por un monto de: " & CDbl(GetPrices("E", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)).ToString("C") & ".", "Exceso del precio introducido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            txtPrecio.Text = CDbl(GetPrices("E", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)).ToString("C")
                                            If cbxPrecio.Text = "A" Then
                                                If CDbl(txtPrecio.Text) > CDbl(GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) Then
                                                    lblDescuento.Text = 0
                                                Else
                                                    lblDescuento.Text = (CDbl(GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) - CDbl(txtPrecio.Text)).ToString("C")
                                                End If

                                            ElseIf cbxPrecio.Text = "B" Then
                                                If CDbl(txtPrecio.Text) > CDbl(GetPrices("B", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) Then
                                                    lblDescuento.Text = 0
                                                Else
                                                    lblDescuento.Text = (CDbl(GetPrices("B", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) - CDbl(txtPrecio.Text)).ToString("C")
                                                End If

                                            End If
                                        End If

                                    Else

                                        If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                                            'Si el precio se puede vender al costo no hago nada, aún cuando no se puede facturar al costo.
                                            If cbxPrecio.Text = "A" Then
                                                If CDbl(txtPrecio.Text) < CDbl(PrecioMinimoA.Text) Then
                                                    MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido.", "El precio dado ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                    txtPrecio.Text = CDbl(GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)).ToString("C")
                                                    txtPrecio.Focus()
                                                Else
                                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    If CDbl(txtPrecio.Text) < GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString) Then
                                                        lblDescuento.Text = CDbl(GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString) - CDbl(txtPrecio.Text)).ToString("C")
                                                    Else
                                                        lblDescuento.Text = CDbl(0).ToString("C")
                                                    End If

                                                End If
                                            ElseIf cbxPrecio.Text = "B" Then
                                                If CDbl(txtPrecio.Text) < CDbl(PrecioMinimoB.Text) Then
                                                    MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido.", "El precio dado ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                    txtPrecio.Text = GetPrices("B", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString).ToString("C")
                                                    txtPrecio.Focus()
                                                Else
                                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    If CDbl(txtPrecio.Text) < GetPrices("B", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString) Then
                                                        lblDescuento.Text = (CDbl(GetPrices("B", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)) - CDbl(txtPrecio.Text)).ToString("C")
                                                    Else
                                                        lblDescuento.Text = CDbl(0).ToString("C")
                                                    End If
                                                End If
                                            Else
                                                If cbxPrecio.Text = "C" Then
                                                    If CDbl(txtPrecio.Text) < GetPrices("C", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString) Then
                                                        MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                        txtPrecio.Text = GetPrices("C", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString).ToString("C")
                                                    Else
                                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    End If
                                                    lblDescuento.Text = CDbl(0).ToString("C")
                                                ElseIf cbxPrecio.Text = "D" Then
                                                    If CDbl(txtPrecio.Text) < GetPrices("D", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString) Then
                                                        MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                        txtPrecio.Text = GetPrices("D", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString).ToString("C")
                                                    Else
                                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    End If
                                                    lblDescuento.Text = CDbl(0).ToString("C")

                                                ElseIf cbxPrecio.Text = "E" Then
                                                    If CDbl(txtPrecio.Text) < GetPrices("E", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString) Then
                                                        MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                        txtPrecio.Text = GetPrices("E", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString).ToString("C")
                                                    Else
                                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    End If
                                                    lblDescuento.Text = CDbl(0).ToString("C")
                                                ElseIf cbxPrecio.Text = "F" Then
                                                    If CDbl(txtPrecio.Text) < GetPrices("F", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString) Then
                                                        MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                        txtPrecio.Text = GetPrices("F", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString).ToString("C")
                                                    Else
                                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    End If
                                                    lblDescuento.Text = CDbl(0).ToString("C")
                                                End If
                                            End If

                                        Else

                                            If CDbl(txtPrecio.Text) < GetPrices("E", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString) Then
                                                MessageBox.Show("No es posible hacer establecer el precio ya que excede el costo del producto.", "Ha excedido el costo del producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                txtPrecio.Text = GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString).ToString("C")
                                            Else
                                                txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                            End If

                                        End If

                                    End If
                                End If


                            End If

                        Else
                            txtPrecio.Text = CDbl(0).ToString("C")
                        End If

                        lblDescuento.Text = CDbl(lblDescuento.Text).ToString("C")

                    Else

                        txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C4")

                    End If

                    SumarTotalArticulo()

                Else
                    txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C4")
                End If

            End If


        Catch ex As Exception

            Try

                txtPrecio.Text = GetPrices("A", txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue.ToString)

                SumarTotalArticulo()


            Catch exs As Exception
                InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
                LimpiarDatosArticulos()
            End Try

        End Try

    End Sub

    Private Sub LimpiarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarArtículosToolStripMenuItem.Click
        btnBlanquear.PerformClick()
    End Sub

    Private Sub QuitarArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarArtículoToolStripMenuItem.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub ModificarArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarArtículoToolStripMenuItem.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtPrecio.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If dgvArticulosFactura.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDFactura.Text = "" And dgvArticulosFactura.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    dgvArticulosFactura.Rows.Clear()
                    SumTotales()
                    txtCodigoArticulo.Focus()
                    Exit Sub
                End If
            End If

            If txtIDFactura.Text <> "" And dgvArticulosFactura.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya procesados en una factura.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If dgvArticulosFactura.Rows.Count = 0 Then
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If dgvArticulosFactura.Rows.Count > 0 Then
                If txtIDFactura.Text = "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & dgvArticulosFactura.CurrentRow.Cells(7).Value & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        RemoveHijos()
                        dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                        SumTotales()
                    End If

                Else
                    If dgvArticulosFactura.Rows.Count = 1 Then
                        MessageBox.Show("No es posible eliminar el artículo ya que es único en la factura. Para realizar esta operación primero agregue el artículo que desea a la factura y posteriormente proceda a eliminar el artículo correspondiente.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo?", "Eliminar artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        Dim Modifiable, IDFacturaArticulos As New Label
                        Con.Open()
                        cmd = New MySqlCommand("SELECT Cierre FROM" & SysName.Text & "prefactura where IDPreFactura='" + txtIDFactura.Text + "'", Con)
                        Modifiable.Text = Convert.ToString(cmd.ExecuteScalar())
                        Con.Close()

                        IDFacturaArticulos.Text = dgvArticulosFactura.CurrentRow.Cells(0).Value

                        If CDbl(Modifiable.Text) = 0 Then
                            Con.Open()
                            sqlQ = "Delete from" & SysName.Text & "PreFacturaArticulos Where IDPreFactArt= '" + IDFacturaArticulos.Text + "'"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()
                            Con.Close()

                            RemoveHijos()
                            dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                            SumTotales()

                            sqlQ = "UPDATE" & SysName.Text & "PreFactura SET TotalNeto='" + CDbl(txtNeto.Text).ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
                            GuardarDatos()

                            MessageBox.Show("El artículo ha sido eliminado satisfactoriamente.", "Artículo eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Else
                            MessageBox.Show("No es posible eliminar el artículo ya que hay registro(s) de seriales en la base de datos.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If

                    Else
                        MessageBox.Show("Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad.", "La factura no se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub IrAArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrAArtículosToolStripMenuItem.Click
        If frm_mant_articulos.Visible = True Then
            frm_mant_articulos.Close()
        End If

        frm_mant_articulos.Show(Me)
        frm_mant_articulos.txtIDProducto.Text = dgvArticulosFactura.CurrentRow.Cells(4).Value
        frm_mant_articulos.FillAllDatafromID()

        If txtIDCliente.Text <> "" Then
            If txtIDCliente.Text <> 1 Then
                frm_mant_articulos.SplitContainer1.Panel1Collapsed = False
                frm_mant_articulos.lblHistorialCliente.Text = "  " & txtNombre.Text.ToUpper
            End If
        End If

    End Sub

    Private Sub dgvArticulosFactura_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvArticulosFactura.CellMouseUp
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                dgvArticulosFactura.Rows(e.RowIndex).Selected = True
                dgvArticulosFactura.CurrentCell = dgvArticulosFactura.Rows(e.RowIndex).Cells(6)
                CMenuProducts.Show(dgvArticulosFactura, e.Location)
                CMenuProducts.Show(Cursor.Position)
            End If


        End If
    End Sub

    Private Sub QuitarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem1.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub txtCantidadArticulo_Enter(sender As Object, e As EventArgs) Handles txtCantidadArticulo.Enter
        txtCantidadArticulo.SelectAll()
    End Sub

    Private Sub txtCodigoArticulo_Enter(sender As Object, e As EventArgs) Handles txtCodigoArticulo.Enter
        txtCodigoArticulo.SelectAll()
    End Sub

    Private Sub txtIDCondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDCondicion.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DoSimilarities_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles DoSimilarities.DoWork
        Try
            If chkMostrarSimilares.Checked = True Then

                If txtCodigoArticulo.Text <> "" And txtDescripcionArticulo.Text <> "" Then

                    Ds.Clear()
                    ConSimilares.Open()
                    cmd = New MySqlCommand("Select IDSubCategoria from Libregco.Articulos where IDArticulo='" + txtCodigoArticulo.Text + "'", ConSimilares)
                    Dim IDSubCategoria As String = Convert.ToString(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("SELECT Articulos.IDArticulo,Articulos.Descripcion,Articulos.Referencia,Articulos.Promocion,PrecioArticulo.PrecioContado,Precio3,ExistenciaTotal,Marca.Marca,Articulos.RutaFoto,CategoriaFilePath,SubCategoriaFilePath,(select count(FacturaArticulos.Cantidad) from" & SysName.Text & "FacturaArticulos where Articulos.IDArticulo=FacturaArticulos.IDArticulo) AS Cantidad FROM Libregco.Articulos INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Libregco.SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubcategoria INNER JOIN Libregco.Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo WHERE Articulos.IDSubCategoria='" + IDSubCategoria + "' and Articulos.IDArticulo<>'" + txtCodigoArticulo.Text + "'" & ExistenciaSimilares & " Order by Cantidad desc LIMIT 5", ConSimilares)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Articulos")
                    ConSimilares.Close()

                    TablaSimilares = Ds.Tables("Articulos")
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DoSimilarities_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles DoSimilarities.RunWorkerCompleted
        Try
            If TablaSimilares.Rows.Count > 0 Then
                SplitSimilares.Panel2Collapsed = False
                Dim ImagePic As Image

                For Each dt As DataRow In TablaSimilares.Rows
                    If System.IO.File.Exists(dt.Item("RutaFoto")) Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(dt.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        ImagePic = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    ElseIf System.IO.File.Exists(dt.Item("SubCategoriaFilePath")) Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(dt.Item("SubCategoriaFilePath"), FileMode.Open, FileAccess.Read)
                        ImagePic = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    ElseIf System.IO.File.Exists(dt.Item("CategoriaFilePath")) Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(dt.Item("CategoriaFilePath"), FileMode.Open, FileAccess.Read)
                        ImagePic = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        ImagePic = My.Resources.No_Image
                    End If

                    Dim CardB As New CardBoard

                    CardB.CardBackColor = Color.White
                    CardB.ArticleDescription = dt.Item("Descripcion")
                    CardB.Button1.Tag = dt.Item("IDArticulo")
                    CardB.IsOffer = If(dt.Item("Promocion") = 1, True, False)
                    CardB.TagImage = ImagePic
                    CardB.Brand = dt.Item("Marca")
                    CardB.Model = dt.Item("Referencia")
                    CardB.Price = CDbl(dt.Item("PrecioContado")).ToString("C")
                    CardB.Size = New Size(265, 84)

                    AddHandler CardB.Button1.Click, AddressOf AñadirCardBoardSimilares

                    FlowSimilares.Controls.Add(CardB)
                Next


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DoProbabilidades_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles DoProbabilidades.DoWork
        Try
            If chkMostrarRelacionados.Checked = True Then
                ListadoProbVendidos.Clear()
                Ds.Clear()

                ConProbabilidades.Open()
                cmd = New MySqlCommand("SELECT FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,Articulos.Referencia,Articulos.Promocion,PrecioArticulo.PrecioContado,Precio3,ExistenciaTotal,Marca.Marca,Articulos.RutaFoto,CategoriaFilePath,SubCategoriaFilePath,count(facturaarticulos.idarticulo) AS RepeticionesenVentas FROM" & SysName.Text & "facturadatos inner join" & SysName.Text & "facturaarticulos on facturadatos.idfacturadatos=facturaarticulos.idfactura INNER JOIN Libregco.Articulos on FacturaArticulos.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Libregco.SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubcategoria INNER JOIN Libregco.Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios where (select count(idfactura) from" & SysName.Text & "FacturaArticulos Where FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura)>1 and (select idarticulo from" & SysName.Text & "FacturaArticulos where FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura group by idfactura)='" + e.Argument.ToString + "' and facturaarticulos.idarticulo<>'" + e.Argument.ToString + "' and facturaarticulos.idarticulo<>1 " & ExistenciaSimilares & " GROUP BY idarticulo having count(facturaarticulos.idarticulo)>'" + CInt(DTConfiguracion.Rows(91 - 1).Item("Value2Int")).ToString + "' order by count(facturaarticulos.idarticulo) desc LIMIT 5", ConProbabilidades)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Articulos")
                ConProbabilidades.Close()

                Dim Tabla As DataTable = Ds.Tables("Articulos")

                For Each dt As DataRow In Tabla.Rows
                    If ProductinFlowProbabilidades(dt.Item("IDArticulo")) = False Then
                        TablaProbabilidades.ImportRow(dt)
                    End If
                Next
            End If

        Catch ex As Exception
            ConProbabilidades.Close()
        End Try
    End Sub

    Function ProductinFlowProbabilidades(ByVal IDProduct As Integer) As Boolean
        For Each cd As CardBoard In FlowProbabilidades.Controls
            If cd.Button1.Tag = IDProduct Then
                FlowProbabilidades.Controls.Remove(DirectCast(DirectCast(cd, Control).Parent, CardBoard))
                'Return True
                Exit For
            Else
                Return False
            End If
        Next
    End Function

    Private Sub DoProbabilidades_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles DoProbabilidades.RunWorkerCompleted
        Try
            If TablaProbabilidades.Rows.Count > 0 Then
                TabControl1.SelectedIndex = 0
                Dim ImagePic As Image

                For Each dt As DataRow In TablaProbabilidades.Rows
                    If Not ListadoProbVendidos.Contains(dt.Item("IDArticulo")) Then
                        ListadoProbVendidos.Add(dt.Item("IDArticulo"))

                        If ProductinDgv(dt.Item("IDArticulo")) = False Then

                            If System.IO.File.Exists(dt.Item("RutaFoto")) Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(dt.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                ImagePic = System.Drawing.Image.FromStream(wFile)
                                wFile.Close()
                            ElseIf System.IO.File.Exists(dt.Item("SubCategoriaFilePath")) Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(dt.Item("SubCategoriaFilePath"), FileMode.Open, FileAccess.Read)
                                ImagePic = System.Drawing.Image.FromStream(wFile)
                                wFile.Close()
                            ElseIf System.IO.File.Exists(dt.Item("CategoriaFilePath")) Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(dt.Item("CategoriaFilePath"), FileMode.Open, FileAccess.Read)
                                ImagePic = System.Drawing.Image.FromStream(wFile)
                                wFile.Close()
                            Else
                                ImagePic = My.Resources.No_Image
                            End If

                            Dim CardB As New CardBoard

                            CardB.ArticleID = dt.Item("IDArticulo")
                            CardB.CardBackColor = Color.White
                            CardB.ArticleDescription = dt.Item("Descripcion")
                            CardB.Button1.Tag = dt.Item("IDArticulo")
                            CardB.IsOffer = If(dt.Item("Promocion") = 1, True, False)
                            CardB.TagImage = ImagePic
                            CardB.Brand = dt.Item("Marca")
                            CardB.Model = dt.Item("Referencia")
                            CardB.Price = CDbl(dt.Item("PrecioContado")).ToString("C")
                            CardB.Width = 270
                            CardB.BackColor = Color.White

                            AddHandler CardB.Button1.Click, AddressOf AñadirCardBoard
                            FlowProbabilidades.Controls.Add(CardB)


                        End If
                    End If
                Next

                TablaProbabilidades.Rows.Clear()

            End If

            SplitContainerProperties()
            PropiedadesDgvArticulos()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvArticulosFactura_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellMouseEnter
        If dgvArticulosFactura.Columns.Count > 0 Then
            If e.RowIndex = -1 Then
                If e.ColumnIndex = 14 Then
                    CbxPrecioHeader.Visible = True
                    CbxPrecioHeader.Location = dgvArticulosFactura.GetCellDisplayRectangle(e.ColumnIndex, -1, False).Location
                End If
            End If
        End If
    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMoneda.SelectedIndexChanged
        If CbxMedida.Text <> "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
            lblIDPrecio.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

            txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C")

            If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
                If btnControlTipoPago.Tag = 2 Then

                    ConLibregco.Open()

                    cmd = New MySqlCommand("SELECT CobrarComision From Articulos where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)

                    If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
                        cmd = New MySqlCommand("SELECT PorcentajeComision From Articulos where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)
                        txtPrecio.Text = (CDbl(txtPrecio.Text) * (1 + (CDbl(Convert.ToDouble(cmd.ExecuteScalar())) / 100))).ToString("C")
                    End If

                    ConLibregco.Close()

                End If
            End If

        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        cbxPrecio.Text = GetPriceLevel(CDbl(SimpleButton1.Tag), lblIDPrecio.Text, cbxMoneda.EditValue.ToString)
        txtPrecio.Text = CDbl(SimpleButton1.Tag).ToString("C")

        btnInsertarArticulo.PerformClick()

    End Sub


    Private Sub dgvArticulosFactura_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellMouseLeave
        If e.RowIndex <> -1 Then
            CbxPrecioHeader.Visible = False
        End If
    End Sub

    Private Sub frm_prefacturacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
            If frm_inicio.SplashScreenManager1.IsSplashFormVisible Then
                frm_inicio.SplashScreenManager1.CloseWaitForm()
            End If


            btnControlTipoPago.PerformClick()
        End If

    End Sub

    Private Sub dgvArticulosFactura_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvArticulosFactura.Scroll
        CbxPrecioHeader.Visible = False
    End Sub

    Private Sub ConsultaDeCotizaciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeCotizaciToolStripMenuItem.Click
        If frm_consulta_cotizacion.Visible = True Then
            frm_consulta_cotizacion.Close()
        End If

        frm_consulta_cotizacion.ShowDialog(Me)
    End Sub

    Private Sub txtOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrden.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789., "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvArticulosFactura_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvArticulosFactura.RowsRemoved
        If dgvArticulosFactura.Rows.Count = 0 Then
            SplitProbabilidades.Panel2Collapsed = True
        End If


        If dgvArticulosFactura.Rows.Count > 0 Then
            cbxMoneda.Enabled = False
        Else
            cbxMoneda.Enabled = True
        End If

        PropiedadesDgvArticulos()
    End Sub

    Private Sub btnControlTipoPago_TextChanged(sender As Object, e As EventArgs) Handles btnControlTipoPago.TextChanged
        FillPrecios()
    End Sub

    Private Sub txtNombre_Enter(sender As Object, e As EventArgs) Handles txtNombre.Enter
        txtNombre.SelectAll()
    End Sub

    Private Sub btnControlTipoPago_Click(sender As Object, e As EventArgs) Handles btnControlTipoPago.Click
        txtCodigoArticulo.Focus()
        txtCodigoArticulo.SelectAll()

        frm_especificar_tipopagos.ShowDialog(Me)

        If dgvArticulosFactura.Rows.Count > 0 Then
            If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
                If btnControlTipoPago.Tag = 2 Then
                    For Each Rw As DataGridViewRow In dgvArticulosFactura.Rows
                        If Rw.Cells(14).Value = "C" Or Rw.Cells(14).Value = "D" Then
                            MessageBox.Show("Se ha específicado algunos descuentos en precios no válidos para el tipo de pago seleccionado." & vbNewLine & vbNewLine & "Se ha ajustado el precio para el artículo: " & vbNewLine & vbNewLine & Rw.Cells(7).Value & ".", "Descuento ajustado a método de pago", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Rw.Cells(14).Value = "A"
                            Rw.Cells(8).Value = CDbl(GetPrices("A", Rw.Cells(4).Value, Rw.Cells(3).Value, cbxMoneda.EditValue)).ToString("C")

                            ConLibregco.Open()
                            cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo='" + Rw.Cells(4).Value.ToString + "'", ConLibregco)
                            lblItbisArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
                            ConLibregco.Close()

                            Rw.Cells(9).Value = (CDbl(GetPrices("A", Rw.Cells(4).Value, Rw.Cells(3).Value, cbxMoneda.EditValue)) / (CDbl(1) + CDbl(lblItbisArt.Text))).ToString("C4")
                            Rw.Cells(10).Value = CDbl(0).ToString("C4")
                            Rw.Cells(11).Value = ((CDbl(GetPrices("A", Rw.Cells(4).Value, Rw.Cells(3).Value, cbxMoneda.EditValue)) / (CDbl(1) + CDbl(lblItbisArt.Text))) * CDbl(lblItbisArt.Text)).ToString("C4")
                            Rw.Cells(12).Value = (CDbl(GetPrices("A", Rw.Cells(4).Value, Rw.Cells(3).Value, cbxMoneda.EditValue)) * CDbl(Rw.Cells(5).Value)).ToString("C4")

                            SumTotales()
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem1.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If dgvArticulosFactura.Rows.Count = 0 And txtIDFactura.Text = "" Then
                MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If dgvArticulosFactura.Rows.Count > 0 Then
                lblIDFactArt.Text = dgvArticulosFactura.CurrentRow.Cells(0).Value
                txtCodigoArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(4).Value
                IDArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(4).Value
                FillMedida()
                txtDescripcionArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(7).Value
                CbxMedida.Text = dgvArticulosFactura.CurrentRow.Cells(6).Value
                lblIDMedida.Text = dgvArticulosFactura.CurrentRow.Cells(3).Value
                cbxPrecio.Text = dgvArticulosFactura.CurrentRow.Cells(14).Value
                ModifyingProduct = True

                txtCantidadArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(5).Value
                BuscarItebis()
                lblIDPrecio.Text = dgvArticulosFactura.CurrentRow.Cells(2).Value
                cbxPrecio.Text = dgvArticulosFactura.CurrentRow.Cells(14).Value
                txtPrecio.Text = (CDbl(dgvArticulosFactura.CurrentRow.Cells(9).Value) * (CDbl(1) + CDbl(lblItbisArt.Text))).ToString("C")
                txtTotalArt.Text = CDbl(dgvArticulosFactura.CurrentRow.Cells(12).Value).ToString("C")
                lblDescuento.Text = CDbl(dgvArticulosFactura.CurrentRow.Cells(10).Value).ToString("C")
                lblIDAlmacenArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(13).Value

                Con.Open()
                cmd = New MySqlCommand("Select ExistenciaTotal from Libregco.Articulos Where IDArticulo='" + txtCodigoArticulo.Text + "'", Con)
                lblExistencia.Text = Convert.ToString(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select IDTipoProducto from Libregco.Articulos Where IDArticulo='" + txtCodigoArticulo.Text + "'", Con)
                lblIDTipoProducto.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                RemoveHijos()
                dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                SumTotales()
                btnModificar.Enabled = False
                Exit Sub
            End If

            PropiedadesDgvArticulos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub VerificarFechaSistema()
        Dim CurrentDate As New Date
        Con.Open()
        cmd = New MySqlCommand("SELECT CURDATE()", Con)
        CurrentDate = Convert.ToDateTime(cmd.ExecuteScalar())
        Con.Close()

        If Today <> CurrentDate Then
            MessageBox.Show("Existe un conflicto entre la fecha actual del equipo y la fecha del servidor." & vbNewLine & vbNewLine & "Por favor verifique la fecha del equipo o la del servidor para acceder al sistema.", "Diferencias en fechas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Application.Exit()
        End If

    End Sub

    Sub CargarExistenciasTreeView()
        Try
            Dim ds0, ds1, ds2 As New DataSet
            Dim MyNode() As TreeNode

            If ConMixta.State = ConnectionState.Open Then
                ConMixta.Close()
            End If

            TreeViewExistencia.Nodes.Clear()

            'Primero cargo todos los sucursales
            ds0.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Sucursal.IDSucursal,Sucursal,SUM(Existencia) as Existencia FROM Libregco.Existencia INNER JOIN" & SysName.Text & "Almacen ON Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo='" + txtCodigoArticulo.Text + "' AND Sucursal.Nulo=0 GROUP BY Sucursal.IDSucursal", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds0, "Sucursal")
            ConMixta.Close()

            Dim TablaSucursales As DataTable = ds0.Tables("Sucursal")
            Dim IDSucursal, IDAlmacen, Medida As New Label

            For Each FilaSucursal As DataRow In TablaSucursales.Rows
                IDSucursal.Text = FilaSucursal.Item("IDSucursal")
                If CDbl(FilaSucursal.Item("Existencia")) = 0 Then
                    Medida.Text = ": [No hay unidades en stock]"
                ElseIf CDbl(FilaSucursal.Item("Existencia")) = 1 Then
                    Medida.Text = ": Sólo " & FilaSucursal.Item("Existencia") & " unidad encontrada."
                Else
                    Medida.Text = ": " & FilaSucursal.Item("Existencia") & " unidades encontradas."
                End If

                TreeViewExistencia.Nodes.Add(FilaSucursal.Item("IDSucursal") & FilaSucursal.Item("Sucursal"), "Sucursal: " & FilaSucursal.Item("Sucursal") & Medida.Text)

                ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,SUM(Existencia) as Existencia FROM Libregco.Existencia INNER JOIN" & SysName.Text & " Almacen ON Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & " Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo='" + txtCodigoArticulo.Text + "' AND Sucursal.IDSucursal='" + IDSucursal.Text + "' AND Almacen.Desactivar=0 GROUP BY Almacen.IDAlmacen", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds1, "Almacenes")
                ConMixta.Close()

                Dim TablaAlmacenes As DataTable = ds1.Tables("Almacenes")

                For Each FilaAlmacen As DataRow In TablaAlmacenes.Rows
                    IDAlmacen.Text = FilaAlmacen.Item("IDAlmacen")
                    If CDbl(FilaAlmacen.Item("Existencia")) = 0 Then
                        Medida.Text = ": [No hay unidades]"
                    ElseIf CDbl(FilaAlmacen.Item("Existencia")) = 1 Then
                        Medida.Text = ": " & FilaAlmacen.Item("Existencia") & " unidad"
                    Else
                        Medida.Text = ": " & FilaAlmacen.Item("Existencia") & " unidades"
                    End If

                    MyNode = TreeViewExistencia.Nodes.Find(FilaSucursal.Item("IDSucursal") & FilaSucursal.Item("Sucursal"), True)
                    MyNode(0).Nodes.Add(FilaAlmacen.Item("IDAlmacen") & FilaAlmacen.Item("Almacen"), "[" & FilaAlmacen.Item("IDAlmacen") & "] " & FilaAlmacen.Item("Almacen") & Medida.Text)

                    ds2.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT Existencia.IDAlmacen,Medida.IDMedida,Medida.Medida,Existencia FROM Libregco.existencia INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where IDArticulo='" + txtCodigoArticulo.Text + "' and IDAlmacen='" + IDAlmacen.Text + "' and PrecioArticulo.Nulo=0", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(ds2, "Medidas")
                    ConMixta.Close()

                    Dim TablaMedidas As DataTable = ds2.Tables("Medidas")

                    For Each FilaMedida As DataRow In TablaMedidas.Rows
                        MyNode = TreeViewExistencia.Nodes.Find(FilaAlmacen.Item("IDAlmacen") & FilaAlmacen.Item("Almacen"), True)
                        MyNode(0).Nodes.Add(FilaMedida.Item("IDMedida") & FilaMedida.Item("Medida"), FilaMedida.Item("Existencia") & " " & (FilaMedida.Item("Medida").ToString.ToLower))
                    Next
                Next
            Next

            TreeViewExistencia.ExpandAll()

            GPExistencia.Visible = True

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ConvertirACotizaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertirACotizaciónToolStripMenuItem.Click
        If frm_cotizacion.Visible = True Then
            frm_cotizacion.Close()
        End If

        frm_cotizacion.Show(Me)


        For Each rw As DataGridViewRow In dgvArticulosFactura.Rows
            frm_cotizacion.dgvArticulos.Rows.Add("", "", rw.Cells("IDPrecios").Value, rw.Cells("IDMedida").Value, rw.Cells("IDArticulo").Value, rw.Cells("Cantidad").Value, rw.Cells("Medida").Value, rw.Cells("Descripcion").Value, rw.Cells("PrecioTotal").Value, rw.Cells("PrecioSinIt").Value, rw.Cells("Descuento").Value, rw.Cells("Itbis").Value, rw.Cells("Importe").Value, rw.Cells("IDAlmacen").Value, rw.Cells("NivelPrecio").Value, rw.Cells("Fraccionamiento").Value)
        Next

        frm_cotizacion.SumTotales()

    End Sub

    Private Sub MantenimientoDeArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeArtículosToolStripMenuItem.Click
        If frm_mant_articulos.Visible = True Then
            frm_mant_articulos.Close()
        End If

        frm_mant_articulos.Show(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        MantenimientoDeArtículosToolStripMenuItem.PerformClick()
    End Sub

    Private Sub PickingListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickingListToolStripMenuItem.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDFactura.Text <> "" Then
            frm_impresiones_directas.ShowDialog(Me)
        End If
    End Sub

    Private Sub DuplicarPrefacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicarPrefacturaciónToolStripMenuItem.Click
        VerificarFechaSistema()

        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la factura.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtNombre.Text = "" Then
            MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombre.Enabled = True
            txtNombre.Focus()
            Exit Sub
        ElseIf dgvArticulosFactura.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarArticulo.Focus()
            Exit Sub
        ElseIf DTEmpleado.Rows(0).Item("IDSucursal").ToString() = "" Then
            MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        For Each Rw As DataGridViewRow In dgvArticulosFactura.Rows
            If CStr(Rw.Cells(13).Value) = "" Then
                MessageBox.Show("Se ha detectado que no hay un almacén establecido en artículo de la fila #" & (Rw.Index + 1) & "de la prefactura.", "Almacén no definido", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Next

        'Verificando de precios por costo
        If IDGrupo_Cliente <> "4" Then
            If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then
                ConLibregco.Open()
                For Each row As DataGridViewRow In dgvArticulosFactura.Rows
                    If CDbl(row.Cells(8).Value) < GetPricesWithIDPrecio("E", row.Cells("IDPrecios").Value, cbxMoneda.EditValue.ToString) Then
                        ConLibregco.Close()
                        MessageBox.Show("El precio colocado en el artículo " & row.Cells(7).Value & " excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        dgvArticulosFactura.Focus()
                        dgvArticulosFactura.Rows(row.Index).Selected = True
                        dgvArticulosFactura.FirstDisplayedScrollingRowIndex = row.Index
                        dgvArticulosFactura.CurrentCell = Me.dgvArticulosFactura.Rows(row.Index).Cells(8)
                        Exit Sub
                    End If
                Next
                ConLibregco.Close()
            End If
        End If

        'Verificando existencias
        If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
            ConLibregco.Open()
            For Each row As DataGridViewRow In dgvArticulosFactura.Rows
                cmd = New MySqlCommand("SELECT IDTipoProducto FROM Articulos WHERE Articulos.IDArticulo= '" + row.Cells(4).Value.ToString() + "'", ConLibregco)
                If Convert.ToDouble(cmd.ExecuteScalar()) <> 2 Then
                    cmd = New MySqlCommand("SELECT ExistenciaTotal FROM Articulos WHERE Articulos.IDArticulo= '" + row.Cells(4).Value.ToString() + "'", ConLibregco)
                    Dim Existencia As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    If CDbl(Existencia) < CDbl(row.Cells(5).Value) Then
                        ConLibregco.Close()
                        MessageBox.Show("No se puede facturar el artículo [" & row.Cells(4).Value & "] " & row.Cells(7).Value & ", ya que no tiene las existencias requeridas en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Next
            ConLibregco.Close()
        End If

        If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
            ConLibregco.Open()
            For Each row As DataGridViewRow In dgvArticulosFactura.Rows
                cmd = New MySqlCommand("SELECT IDTipoProducto FROM Articulos WHERE Articulos.IDArticulo= '" + row.Cells(4).Value.ToString() + "'", ConLibregco)
                If Convert.ToDouble(cmd.ExecuteScalar()) <> 2 Then
                    cmd = New MySqlCommand("SELECT ExistenciaTotal FROM Articulos WHERE Articulos.IDArticulo= '" + row.Cells(4).Value.ToString() + "'", ConLibregco)
                    Dim Existencia As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    If CDbl(Existencia) < CDbl(row.Cells(5).Value) Then
                        ConLibregco.Close()
                        MessageBox.Show("No se puede facturar el artículo [" & row.Cells(4).Value & "] " & row.Cells(7).Value & ", ya que no tiene las existencias requeridas en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Next
            ConLibregco.Close()
        End If

        If Permisos(1) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea duplicar la prefactura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Duplicar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then

            'Pasando parametros a detalles
            SumTotales()
            frm_prefacturacion_detalles.txtIDCliente.Text = txtIDCliente.Text
            frm_prefacturacion_detalles.txtNombre.Text = txtNombre.Text
            frm_prefacturacion_detalles.txtIDCondicion.Text = txtIDCondicion.Text
            frm_prefacturacion_detalles.txtCondicion.Text = txtCondicion.Text
            frm_prefacturacion_detalles.txtIDCondicion.Tag = txtCondicion.Tag
            frm_prefacturacion_detalles.txtIDNcf.Text = lblIDTipoNCF.Text
            frm_prefacturacion_detalles.txtTipoNcf.Text = TipoNCF.Text
            frm_prefacturacion_detalles.txtOrden.Text = txtOrden.Text

            If txtIDCliente.Text <> 1 Then
                frm_prefacturacion_detalles.txtDireccion.Text = DireccionCliente
                frm_prefacturacion_detalles.txtTelefono.Text = TelefonoCliente
                frm_prefacturacion_detalles.txtRNC.Text = RNCliente
            End If

            If lblIDTipoNCF.Text = 1 Then
                frm_prefacturacion_detalles.rdbCreditoFiscal.Checked = True
            ElseIf lblIDTipoNCF.Text = 2 Then
                frm_prefacturacion_detalles.rdbConsumidorFin.Checked = True
            ElseIf lblIDTipoNCF.Text = 8 Then
                frm_prefacturacion_detalles.rdbRegimenEsp.Checked = True
            ElseIf lblIDTipoNCF.Text = 9 Then
                frm_prefacturacion_detalles.rdbGubernamental.Checked = True
            End If

            frm_prefacturacion_detalles.txtNeto.Text = txtNeto.Text
            frm_prefacturacion_detalles.txtNombre.Focus()
            frm_prefacturacion_detalles.txtNombre.SelectAll()

            frm_prefacturacion_detalles.ShowDialog(Me)

            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            If txtIDCondicion.Text <> 1 Then
                If CheckRequiredFieldsofCustomers(txtIDCliente.Text) = False Then
                    Exit Sub
                End If
            End If

            lblCierre.Text = 0

            Dim IDPrefactura, SecondID As String

            If SysName.Text.Trim = "Libregco." Then
                ConMixta.Open()
                cmd = New MySqlCommand("INSERT INTO Libregco_Main.Prefactura (IDEquipo,IDTipoDocumento,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDVendedor,IDUsuario,Fecha,Hora,TotalNeto,Observacion,NoOrden,Cierre,Usando,TipoPago,Nulo,IDMoneda) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',53,'" + frm_prefacturacion_detalles.txtIDCliente.Text + "','" + frm_prefacturacion_detalles.txtNombre.Text + "','" + frm_prefacturacion_detalles.txtRNC.Text + "','" + frm_prefacturacion_detalles.txtDireccion.Text + "','" + frm_prefacturacion_detalles.txtTelefono.Text + "','" + frm_prefacturacion_detalles.txtIDCondicion.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + frm_prefacturacion_detalles.txtIDNcf.Text + "','" + frm_prefacturacion_detalles.txtIDVendedor.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',CURDATE(),CURRENT_TIME(),'" + CDbl(txtNeto.Text).ToString + "','" + frm_prefacturacion_detalles.txtObservacion.Text + "','" + frm_prefacturacion_detalles.txtOrden.Text + "',0,0,'" + btnControlTipoPago.Tag.ToString + "',0,'" + cbxMoneda.EditValue.ToString + "')", ConMixta)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select IDPreFactura from Libregco_Main.Prefactura where IDPrefactura= (Select Max(IDPrefactura) from Libregco_Main.Prefactura)", ConMixta)
                IDPrefactura = Convert.ToDouble(cmd.ExecuteScalar())

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim DsTemp As New DataSet
                cmd = New MySqlCommand("SELECT * FROM Libregco_Main.TipoDocumento WHERE IDTipoDocumento=53", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "TipoDocumento")
                Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
                Dim lblSecondID, UltSecuencia As New Label

                lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
                UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
                txtSecondID.Text = lblSecondID.Text

                cmd = New MySqlCommand("UPDATE Libregco_Main.PreFactura SET SecondID='" + lblSecondID.Text + "' WHERE IDPreFactura='" + IDPrefactura + "'", ConMixta)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("UPDATE Libregco_Main.TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=53", ConMixta)
                cmd.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
                    cmd = New MySqlCommand("INSERT INTO Libregco_Main.PrefacturaArticulos (IDPreFactura,IDPrecio,IDArticulo,IDMedida,Medida,Cantidad,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo) VALUES ('" + IDPrefactura + "', '" + Row.Cells(2).Value.ToString + "','" + Row.Cells(4).Value.ToString + "','" + Row.Cells(3).Value.ToString + "','" + Row.Cells(6).Value.ToString + "','" + Row.Cells(5).Value.ToString + "','" + Row.Cells(7).Value.ToString + "','" + CDbl(Row.Cells(9).Value).ToString + "','" + CDbl(Row.Cells(10).Value).ToString + "','" + CDbl(Row.Cells(11).Value).ToString + "','" + CDbl(Row.Cells(12).Value).ToString + "','" + Row.Cells(13).Value.ToString + "','" + Row.Cells(14).Value.ToString + "')", ConMixta)
                    cmd.ExecuteNonQuery()
                Next

                ConMixta.Close()

                ToastNotificationsManager2.ShowNotification(ToastNotificationsManager2.Notifications(2))
            Else
                ConMixta.Open()
                cmd = New MySqlCommand("INSERT INTO Libregco.Prefactura (IDEquipo,IDTipoDocumento,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDVendedor,IDUsuario,Fecha,Hora,TotalNeto,Observacion,NoOrden,Cierre,Usando,TipoPago,Nulo,IDMoneda) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',53,'" + frm_prefacturacion_detalles.txtIDCliente.Text + "','" + frm_prefacturacion_detalles.txtNombre.Text + "','" + frm_prefacturacion_detalles.txtRNC.Text + "','" + frm_prefacturacion_detalles.txtDireccion.Text + "','" + frm_prefacturacion_detalles.txtTelefono.Text + "','" + frm_prefacturacion_detalles.txtIDCondicion.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + frm_prefacturacion_detalles.txtIDNcf.Text + "','" + frm_prefacturacion_detalles.txtIDVendedor.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',CURDATE(),CURRENT_TIME(),'" + CDbl(txtNeto.Text).ToString + "','" + frm_prefacturacion_detalles.txtObservacion.Text + "','" + frm_prefacturacion_detalles.txtOrden.Text + "',0,0,'" + btnControlTipoPago.Tag.ToString + "',0,'" + cbxMoneda.EditValue.ToString + "')", ConMixta)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select IDPreFactura from Libregco.Prefactura where IDPrefactura= (Select Max(IDPrefactura) from Libregco.Prefactura)", ConMixta)
                IDPrefactura = Convert.ToDouble(cmd.ExecuteScalar())

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim DsTemp As New DataSet
                cmd = New MySqlCommand("SELECT * FROM Libregco.TipoDocumento WHERE IDTipoDocumento=53", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "TipoDocumento")
                Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
                Dim lblSecondID, UltSecuencia As New Label

                lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
                UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)

                cmd = New MySqlCommand("UPDATE Libregco.PreFactura SET SecondID='" + lblSecondID.Text + "' WHERE IDPreFactura='" + IDPrefactura + "'", ConMixta)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("UPDATE Libregco.TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=53", ConMixta)
                cmd.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
                    cmd = New MySqlCommand("INSERT INTO Libregco.PrefacturaArticulos (IDPreFactura,IDPrecio,IDArticulo,IDMedida,Medida,Cantidad,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo) VALUES ('" + IDPrefactura + "', '" + Row.Cells(2).Value.ToString + "','" + Row.Cells(4).Value.ToString + "','" + Row.Cells(3).Value.ToString + "','" + Row.Cells(6).Value.ToString + "','" + Row.Cells(5).Value.ToString + "','" + Row.Cells(7).Value.ToString + "','" + CDbl(Row.Cells(9).Value).ToString + "','" + CDbl(Row.Cells(10).Value).ToString + "','" + CDbl(Row.Cells(11).Value).ToString + "','" + CDbl(Row.Cells(12).Value).ToString + "','" + Row.Cells(13).Value.ToString + "','" + Row.Cells(14).Value.ToString + "')", ConMixta)
                    cmd.ExecuteNonQuery()
                Next

                ConMixta.Close()

                ToastNotificationsManager2.ShowNotification(ToastNotificationsManager2.Notifications(2))
            End If



        End If
    End Sub

    Private Sub GetTriedModifiedIDFactArt()
        Try
            If lblIDFactArt.Text <> "" Then
                Dim Contmp As New MySqlConnection(CnGeneral)

                Contmp.Open()
                Dim Consulta As New MySqlCommand("Select IDPreFactArt,IDPreFactura,IDPrecio,IDMedida,prefacturaarticulos.IDArticulo,Cantidad,Medida,prefacturaarticulos.Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo from" & SysName.Text & "prefacturaarticulos WHERE IDPreFactArt='" + lblIDFactArt.Text + "'", Contmp)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    dgvArticulosFactura.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), (CDbl(LectorArticulos.GetValue(8)) + CDbl(LectorArticulos.GetValue(10))).ToString("C4"), CDbl(LectorArticulos.GetValue(8)).ToString("C4"), CDbl(LectorArticulos.GetValue(9)).ToString("C4"), CDbl(LectorArticulos.GetValue(10)).ToString("C4"), CDbl(LectorArticulos.GetValue(11)).ToString("C4"), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), 0)
                End While

                LectorArticulos.Close()
                Contmp.Close()

                SumTotales()
                LimpiarDatosArticulos()
                btnModificar.Enabled = True
                txtDescripcionArticulo.ReadOnly = True
                txtDescripcionArticulo.Enabled = False
                dgvArticulosFactura.FirstDisplayedScrollingRowIndex = dgvArticulosFactura.Rows.Count - 1
                txtCodigoArticulo.Focus()
                Contmp.Dispose()

            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        VerificarFechaSistema()

        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la factura.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtNombre.Text = "" Then
            MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombre.Enabled = True
            txtNombre.Focus()
            Exit Sub
        ElseIf dgvArticulosFactura.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarArticulo.Focus()
            Exit Sub
        ElseIf DTEmpleado.Rows(0).Item("IDSucursal").ToString() = "" Then
            MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If


        For Each Rw As DataGridViewRow In dgvArticulosFactura.Rows
            'Verificando almacenes vacios
            If CStr(Rw.Cells(13).Value) = "" Then
                MessageBox.Show("Se ha detectado que no hay un almacén establecido en artículo de la fila #" & (Rw.Index + 1) & "de la prefactura.", "Almacén no definido", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CInt(Rw.Cells(16).Value) = 0 Then
                If CDbl(Rw.Cells(5).Value) <> TruncateDecimal(CDbl(Rw.Cells(5).Value)) Then
                    Rw.Cells(5).Value = 1
                    Rw.Cells(12).Value = (CDbl(Rw.Cells(5).Value) * CDbl(Rw.Cells(8).Value)).ToString("C4")

                    MessageBox.Show("Se encontró un error en la cantidad del artículo " & Rw.Cells(7).Value & " y se ha modificado." & vbNewLine & vbNewLine & "Favor verificar la cantidad incluída del artículo.", "Cantidad modificada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If
        Next

        'Verificando niveles de precios
        If IDGrupo_Cliente <> "4" Then
            If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                ConLibregco.Open()
                For Each row As DataGridViewRow In dgvArticulosFactura.Rows
                    If CDbl(row.Cells(8).Value) < GetPricesWithIDPrecio("D", row.Cells("IDPrecios").Value, cbxMoneda.EditValue.ToString) Then
                        ConLibregco.Close()
                        MessageBox.Show("El precio colocado en el artículo " & row.Cells(7).Value & " excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        dgvArticulosFactura.Focus()
                        dgvArticulosFactura.Rows(row.Index).Selected = True
                        dgvArticulosFactura.FirstDisplayedScrollingRowIndex = row.Index
                        dgvArticulosFactura.CurrentCell = Me.dgvArticulosFactura.Rows(row.Index).Cells(8)
                        Exit Sub
                    End If
                Next
                ConLibregco.Close()
            Else
                ConLibregco.Open()
                For Each row As DataGridViewRow In dgvArticulosFactura.Rows
                    If CDbl(row.Cells(8).Value) < GetPricesWithIDPrecio("E", row.Cells("IDPrecios").Value, cbxMoneda.EditValue.ToString) Then
                        ConLibregco.Close()
                        MessageBox.Show("El precio colocado en el artículo " & row.Cells(7).Value & " excede al costo del producto.", "Costo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        dgvArticulosFactura.Focus()
                        dgvArticulosFactura.Rows(row.Index).Selected = True
                        dgvArticulosFactura.FirstDisplayedScrollingRowIndex = row.Index
                        dgvArticulosFactura.CurrentCell = Me.dgvArticulosFactura.Rows(row.Index).Cells(8)
                        Exit Sub
                    End If
                Next
                ConLibregco.Close()
            End If
        End If


        'Verificando de precios por costo
        If IDGrupo_Cliente <> "4" Then
            If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then
                ConLibregco.Open()
                For Each row As DataGridViewRow In dgvArticulosFactura.Rows
                    If CDbl(row.Cells(8).Value) < GetPricesWithIDPrecio("E", row.Cells("IDPrecios").Value, cbxMoneda.EditValue.ToString) Then
                        ConLibregco.Close()
                        MessageBox.Show("El precio colocado en el artículo " & row.Cells(7).Value & " excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        dgvArticulosFactura.Focus()
                        dgvArticulosFactura.Rows(row.Index).Selected = True
                        dgvArticulosFactura.FirstDisplayedScrollingRowIndex = row.Index
                        dgvArticulosFactura.CurrentCell = Me.dgvArticulosFactura.Rows(row.Index).Cells(8)
                        Exit Sub
                    End If
                Next
                ConLibregco.Close()
            End If
        End If

        'Verificando existencias
        If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
            ConLibregco.Open()
            For Each row As DataGridViewRow In dgvArticulosFactura.Rows
                cmd = New MySqlCommand("SELECT IDTipoProducto FROM Articulos WHERE Articulos.IDArticulo= '" + row.Cells(4).Value.ToString() + "'", ConLibregco)
                If Convert.ToDouble(cmd.ExecuteScalar()) <> 2 Then
                    cmd = New MySqlCommand("SELECT ExistenciaTotal FROM Articulos WHERE Articulos.IDArticulo= '" + row.Cells(4).Value.ToString() + "'", ConLibregco)
                    Dim Existencia As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    If CDbl(Existencia) < CDbl(row.Cells(5).Value) Then
                        ConLibregco.Close()
                        MessageBox.Show("No se puede facturar el artículo [" & row.Cells(4).Value & "] " & row.Cells(7).Value & ", ya que no tiene las existencias requeridas en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Next
            ConLibregco.Close()
        End If

        If txtIDFactura.Text = "" Then 'Si no hay factura
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If Result = MsgBoxResult.Yes Then

            'Pasando parametros a detalles
            SumTotales()
            frm_prefacturacion_detalles.txtIDCliente.Text = txtIDCliente.Text
            frm_prefacturacion_detalles.txtNombre.Text = txtNombre.Text
            frm_prefacturacion_detalles.txtIDCondicion.Text = txtIDCondicion.Text
            frm_prefacturacion_detalles.txtCondicion.Text = txtCondicion.Text
            frm_prefacturacion_detalles.txtIDCondicion.Tag = txtCondicion.Tag
            frm_prefacturacion_detalles.txtIDNcf.Text = lblIDTipoNCF.Text
            frm_prefacturacion_detalles.txtTipoNcf.Text = TipoNCF.Text
            frm_prefacturacion_detalles.txtOrden.Text = txtOrden.Text

            If txtIDCliente.Text <> 1 Then
                frm_prefacturacion_detalles.txtDireccion.Text = DireccionCliente
                frm_prefacturacion_detalles.txtTelefono.Text = TelefonoCliente
                frm_prefacturacion_detalles.txtRNC.Text = RNCliente
            End If

            If lblIDTipoNCF.Text = 1 Then
                frm_prefacturacion_detalles.rdbCreditoFiscal.Checked = True
            ElseIf lblIDTipoNCF.Text = 2 Then
                frm_prefacturacion_detalles.rdbConsumidorFin.Checked = True
            ElseIf lblIDTipoNCF.Text = 8 Then
                frm_prefacturacion_detalles.rdbRegimenEsp.Checked = True
            ElseIf lblIDTipoNCF.Text = 9 Then
                frm_prefacturacion_detalles.rdbGubernamental.Checked = True
            End If

            frm_prefacturacion_detalles.txtNeto.Text = txtNeto.Text
            frm_prefacturacion_detalles.txtNombre.Focus()
            frm_prefacturacion_detalles.txtNombre.SelectAll()

            frm_prefacturacion_detalles.ShowDialog(Me)

            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            If txtIDCondicion.Text <> 1 Then
                If CheckRequiredFieldsofCustomers(txtIDCliente.Text) = False Then
                    Exit Sub
                End If
            End If

            sqlQ = "INSERT INTO Prefactura (IDEquipo,IDTipoDocumento,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDVendedor,IDUsuario,Fecha,Hora,TotalNeto,Observacion,NoOrden,Cierre,Usando,TipoPago,Nulo,IDMoneda) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',53,'" + frm_prefacturacion_detalles.txtIDCliente.Text + "','" + frm_prefacturacion_detalles.txtNombre.Text + "','" + frm_prefacturacion_detalles.txtRNC.Text + "','" + frm_prefacturacion_detalles.txtDireccion.Text + "','" + frm_prefacturacion_detalles.txtTelefono.Text + "','" + frm_prefacturacion_detalles.txtIDCondicion.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + frm_prefacturacion_detalles.txtIDNcf.Text + "','" + frm_prefacturacion_detalles.txtIDVendedor.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',CURDATE(),CURRENT_TIME(),'" + CDbl(txtNeto.Text).ToString + "','" + frm_prefacturacion_detalles.txtObservacion.Text + "','" + frm_prefacturacion_detalles.txtOrden.Text + "',0,0,'" + btnControlTipoPago.Tag.ToString + "',0,'" + cbxMoneda.EditValue.ToString + "')"
            lblCierre.Text = 0
            GuardarDatos()
            UltPreFactura()
            InsertArticulos()
            SetSecondID()

            ToastNotificationsManager2.Notifications(0).Body = "La prefactura " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
            ToastNotificationsManager2.ShowNotification(ToastNotificationsManager2.Notifications(0))

            DeshabilitarControles()
            Hora.Enabled = False
            'End If
        Else

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la prefactura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If Result = MsgBoxResult.Yes Then
            GetTriedModifiedIDFactArt()
            SumTotales()

            'Pasando parametros a detalles
            frm_prefacturacion_detalles.txtIDCliente.Text = txtIDCliente.Text
            frm_prefacturacion_detalles.txtNombre.Text = txtNombre.Text
            frm_prefacturacion_detalles.txtIDCondicion.Text = txtIDCondicion.Text
            frm_prefacturacion_detalles.txtCondicion.Text = txtCondicion.Text
            frm_prefacturacion_detalles.txtIDNcf.Text = lblIDTipoNCF.Text
            frm_prefacturacion_detalles.txtTipoNcf.Text = TipoNCF.Text
            frm_prefacturacion_detalles.txtNeto.Text = txtNeto.Text
            frm_prefacturacion_detalles.txtOrden.Text = txtOrden.Text

            If txtIDCliente.Text <> 1 Then
                frm_prefacturacion_detalles.txtDireccion.Text = DireccionCliente
                frm_prefacturacion_detalles.txtTelefono.Text = TelefonoCliente
                frm_prefacturacion_detalles.txtRNC.Text = RNCliente
                'Else
                '    frm_prefacturacion_detalles.txtDireccion.Text = ""
                '    frm_prefacturacion_detalles.txtTelefono.Text = ""
                '    frm_prefacturacion_detalles.txtRNC.Text = ""
            End If

            If lblIDTipoNCF.Text = 1 Then
                frm_prefacturacion_detalles.rdbCreditoFiscal.Checked = True
            ElseIf lblIDTipoNCF.Text = 2 Then
                frm_prefacturacion_detalles.rdbConsumidorFin.Checked = True
            ElseIf lblIDTipoNCF.Text = 8 Then
                frm_prefacturacion_detalles.rdbRegimenEsp.Checked = True
            ElseIf lblIDTipoNCF.Text = 9 Then
                frm_prefacturacion_detalles.rdbGubernamental.Checked = True
            End If

            frm_prefacturacion_detalles.txtNeto.Text = txtNeto.Text
            frm_prefacturacion_detalles.txtNombre.Focus()
            frm_prefacturacion_detalles.txtNombre.SelectAll()

            frm_prefacturacion_detalles.ShowDialog(Me)

            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            sqlQ = "UPDATE PreFactura SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDTipoDocumento=53,IDCliente='" + frm_prefacturacion_detalles.txtIDCliente.Text + "',NombreFactura='" + frm_prefacturacion_detalles.txtNombre.Text + "',IdentificacionFactura='" + frm_prefacturacion_detalles.txtRNC.Text + "',DireccionFactura='" + frm_prefacturacion_detalles.txtDireccion.Text + "',TelefonosFactura='" + frm_prefacturacion_detalles.txtTelefono.Text + "',IDCondicion='" + frm_prefacturacion_detalles.txtIDCondicion.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "',IDComprobanteFiscal='" + frm_prefacturacion_detalles.txtIDNcf.Text + "',IDVendedor='" + frm_prefacturacion_detalles.txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',Observacion='" + frm_prefacturacion_detalles.txtObservacion.Text + "',NoOrden='" + frm_prefacturacion_detalles.txtOrden.Text + "',Cierre='" + lblCierre.Text + "',TipoPago='" + btnControlTipoPago.Tag.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "' WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
            GuardarDatos()
            InsertArticulos()

            ToastNotificationsManager2.Notifications(1).Body = "La prefactura " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
            ToastNotificationsManager2.ShowNotification(ToastNotificationsManager2.Notifications(1))

            DeshabilitarControles()
                Hora.Enabled = False
            'End If
        End If

    End Sub

    'Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
    '    VerificarFechaSistema()

    '    If txtIDCliente.Text = "" Then
    '        MessageBox.Show("Seleccione el cliente para procesar la factura.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        btnBuscarCliente.PerformClick()
    '        Exit Sub
    '    ElseIf txtNombre.Text = "" Then
    '        MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        txtNombre.Enabled = True
    '        txtNombre.Focus()
    '        Exit Sub
    '    ElseIf dgvArticulosFactura.Rows.Count = 0 Then
    '        MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        btnBuscarArticulo.Focus()
    '        Exit Sub
    '    ElseIf DtEmpleado.Rows(0).item("IDSucursal").ToString() = "" Then
    '        MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        Exit Sub
    '    End If

    '    For Each Rw As DataGridViewRow In dgvArticulosFactura.Rows
    '        If CStr(Rw.Cells(13).Value) = "" Then
    '            MessageBox.Show("Se ha detectado que no hay un almacén establecido en artículo de la fila #" & (Rw.Index + 1) & "de la prefactura.", "Almacén no definido", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            Exit Sub
    '        End If
    '    Next

    '    If IDGrupo_Cliente <> "4" Then
    '        If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
    '            If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then
    '                ConLibregco.Open()
    '                For Each row As DataGridViewRow In dgvArticulosFactura.Rows
    '                    If CDbl(row.Cells(8).Value) < GetPricesWithIDPrecio("D", row.Cells("IDPrecios").Value, cbxMoneda.EditValue.ToString) Then
    '                        ConLibregco.Close()
    '                        MessageBox.Show("El precio colocado en el artículo " & row.Cells(7).Value & " excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                        dgvArticulosFactura.Focus()
    '                        dgvArticulosFactura.Rows(row.Index).Selected = True
    '                        dgvArticulosFactura.FirstDisplayedScrollingRowIndex = row.Index
    '                        dgvArticulosFactura.CurrentCell = Me.dgvArticulosFactura.Rows(row.Index).Cells(8)
    '                        Exit Sub
    '                    End If
    '                Next
    '                ConLibregco.Close()
    '            End If
    '        Else
    '            If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then
    '                ConLibregco.Open()
    '                For Each row As DataGridViewRow In dgvArticulosFactura.Rows
    '                    If CDbl(row.Cells(8).Value) < GetPricesWithIDPrecio("E", row.Cells("IDPrecios").Value, cbxMoneda.EditValue.ToString) Then
    '                        ConLibregco.Close()
    '                        MessageBox.Show("El precio colocado en el artículo " & row.Cells(7).Value & " excede al costo del producto.", "Costo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                        dgvArticulosFactura.Focus()
    '                        dgvArticulosFactura.Rows(row.Index).Selected = True
    '                        dgvArticulosFactura.FirstDisplayedScrollingRowIndex = row.Index
    '                        dgvArticulosFactura.CurrentCell = Me.dgvArticulosFactura.Rows(row.Index).Cells(8)
    '                        Exit Sub
    '                    End If
    '                Next
    '                ConLibregco.Close()
    '            End If
    '        End If
    '    End If

    '    If txtIDFactura.Text = "" Then 'Si no hay factura
    '        If Permisos(1) = 0 Then
    '            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If
    '        Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '        If Result = MsgBoxResult.Yes Then
    '            SumTotales()

    '            'Pasando parametros a detalles
    '            frm_prefacturacion_detalles.txtIDCliente.Text = txtIDCliente.Text
    '            frm_prefacturacion_detalles.txtNombre.Text = txtNombre.Text
    '            frm_prefacturacion_detalles.txtIDCondicion.Text = txtIDCondicion.Text
    '            frm_prefacturacion_detalles.txtIDCondicion.Tag = txtIDCondicion.Tag
    '            frm_prefacturacion_detalles.txtCondicion.Text = txtCondicion.Text
    '            frm_prefacturacion_detalles.txtIDNcf.Text = lblIDTipoNCF.Text
    '            frm_prefacturacion_detalles.txtTipoNcf.Text = TipoNCF.Text
    '            frm_prefacturacion_detalles.txtOrden.Text = txtOrden.Text

    '            If txtIDCliente.Text <> 1 Then
    '                frm_prefacturacion_detalles.txtDireccion.Text = DireccionCliente
    '                frm_prefacturacion_detalles.txtTelefono.Text = TelefonoCliente
    '                frm_prefacturacion_detalles.txtRNC.Text = RNCliente

    '            End If

    '            If lblIDTipoNCF.Text = 1 Then
    '                frm_prefacturacion_detalles.rdbCreditoFiscal.Checked = True
    '            ElseIf lblIDTipoNCF.Text = 2 Then
    '                frm_prefacturacion_detalles.rdbConsumidorFin.Checked = True
    '            ElseIf lblIDTipoNCF.Text = 8 Then
    '                frm_prefacturacion_detalles.rdbRegimenEsp.Checked = True
    '            ElseIf lblIDTipoNCF.Text = 9 Then
    '                frm_prefacturacion_detalles.rdbGubernamental.Checked = True
    '            End If

    '            frm_prefacturacion_detalles.txtNeto.Text = txtNeto.Text
    '            frm_prefacturacion_detalles.txtNombre.Focus()
    '            frm_prefacturacion_detalles.txtNombre.SelectAll()

    '            frm_prefacturacion_detalles.ShowDialog(Me)

    '            If ControlSuperClave = 1 Then
    '                Exit Sub
    '            End If

    '            If txtIDCondicion.Text <> 1 Then
    '                If CheckRequiredFieldsofCustomers(txtIDCliente.Text) = False Then
    '                    Exit Sub
    '                End If
    '            End If

    '            sqlQ = "INSERT INTO Prefactura (IDEquipo,IDTipoDocumento,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDVendedor,IDUsuario,Fecha,Hora,TotalNeto,Observacion,NoOrden,Cierre,Usando,TipoPago,Nulo,IDMoneda) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',53,'" + frm_prefacturacion_detalles.txtIDCliente.Text + "','" + frm_prefacturacion_detalles.txtNombre.Text + "','" + frm_prefacturacion_detalles.txtRNC.Text + "','" + frm_prefacturacion_detalles.txtDireccion.Text + "','" + frm_prefacturacion_detalles.txtTelefono.Text + "','" + frm_prefacturacion_detalles.txtIDCondicion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + frm_prefacturacion_detalles.txtIDNcf.Text + "','" + frm_prefacturacion_detalles.txtIDVendedor.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',CURDATE(),CURRENT_TIME(),'" + CDbl(txtNeto.Text).ToString + "','" + frm_prefacturacion_detalles.txtObservacion.Text + "','" + frm_prefacturacion_detalles.txtOrden.Text + "',0,0,'" + btnControlTipoPago.Tag.ToString + "',0,'" + cbxMoneda.EditValue.ToString + "')"
    '            lblCierre.Text = 0
    '            GuardarDatos()
    '            UltPreFactura()
    '            InsertArticulos()
    '            SetSecondID()

    '            ToastNotificationsManager1.Notifications(0).Body = "La prefactura " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
    '            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

    '            LimpiarDatos()
    '            ActualizarTodo()
    '            VerificacionTipoPago()
    '        End If
    '    Else

    '        If Permisos(2) = 0 Then
    '            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If

    '        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la prefactura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '        If Result = MsgBoxResult.Yes Then
    '            GetTriedModifiedIDFactArt()
    '            SumTotales()

    '            'Pasando parametros a detalles
    '            frm_prefacturacion_detalles.txtIDCliente.Text = txtIDCliente.Text
    '            frm_prefacturacion_detalles.txtNombre.Text = txtNombre.Text
    '            frm_prefacturacion_detalles.txtIDCondicion.Text = txtIDCondicion.Text
    '            frm_prefacturacion_detalles.txtIDCondicion.Tag = txtIDCondicion.Tag
    '            frm_prefacturacion_detalles.txtCondicion.Text = txtCondicion.Text
    '            frm_prefacturacion_detalles.txtIDNcf.Text = lblIDTipoNCF.Text
    '            frm_prefacturacion_detalles.txtTipoNcf.Text = TipoNCF.Text
    '            frm_prefacturacion_detalles.txtNeto.Text = txtNeto.Text
    '            frm_prefacturacion_detalles.txtOrden.Text = txtOrden.Text

    '            If txtIDCliente.Text <> 1 Then
    '                frm_prefacturacion_detalles.txtDireccion.Text = DireccionCliente
    '                frm_prefacturacion_detalles.txtTelefono.Text = TelefonoCliente
    '                frm_prefacturacion_detalles.txtRNC.Text = RNCliente
    '                'Else
    '                '    frm_prefacturacion_detalles.txtDireccion.Text = ""
    '                '    frm_prefacturacion_detalles.txtTelefono.Text = ""
    '                '    frm_prefacturacion_detalles.txtRNC.Text = ""
    '            End If
    '            frm_prefacturacion_detalles.txtNeto.Text = txtNeto.Text
    '            frm_prefacturacion_detalles.txtNombre.Focus()
    '            frm_prefacturacion_detalles.txtNombre.SelectAll()

    '            frm_prefacturacion_detalles.ShowDialog(Me)

    '            If ControlSuperClave = 1 Then
    '                Exit Sub
    '            End If

    '            sqlQ = "UPDATE PreFactura SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDTipoDocumento=53,IDCliente='" + frm_prefacturacion_detalles.txtIDCliente.Text + "',NombreFactura='" + frm_prefacturacion_detalles.txtNombre.Text + "',IdentificacionFactura='" + frm_prefacturacion_detalles.txtRNC.Text + "',DireccionFactura='" + frm_prefacturacion_detalles.txtDireccion.Text + "',TelefonosFactura='" + frm_prefacturacion_detalles.txtTelefono.Text + "',IDCondicion='" + frm_prefacturacion_detalles.txtIDCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDComprobanteFiscal='" + frm_prefacturacion_detalles.txtIDNcf.Text + "',IDVendedor='" + frm_prefacturacion_detalles.txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") + "',Hora='" + txtHora.Value.ToString("HH:mm:ss") + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',Observacion='" + frm_prefacturacion_detalles.txtObservacion.Text + "',NoOrden='" + frm_prefacturacion_detalles.txtOrden.Text + "',Cierre='" + lblCierre.Text + "',TipoPago='" + btnControlTipoPago.Tag.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "' WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
    '            GuardarDatos()
    '            InsertArticulos()

    '            ToastNotificationsManager1.Notifications(1).Body = "La prefactura " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
    '            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

    '            LimpiarDatos()
    '            ActualizarTodo()
    '            VerificacionTipoPago()
    '        End If
    '    End If

    'End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        frm_buscar_prefactura.ShowDialog(Me)
    End Sub

    Private Sub frm_facturacion_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SplitContainerProperties()
        PropiedadesDgvArticulos()
    End Sub

    Private Sub txtIDCondicion_Leave(sender As Object, e As EventArgs) Handles txtIDCondicion.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Condicion FROM Condicion Where IDCondicion= '" + txtIDCondicion.Text + "'", ConLibregco)
        txtCondicion.Text = Convert.ToString(cmd.ExecuteScalar()).ToUpper

        cmd = New MySqlCommand("SELECT Dias FROM Condicion Where IDCondicion= '" + txtIDCondicion.Text + "'", ConLibregco)
        txtCondicion.Tag = Convert.ToString(cmd.ExecuteScalar()).ToUpper
        ConLibregco.Close()

        If txtCondicion.Text = "" Then
            txtIDCondicion.Text = 1

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Condicion FROM Condicion Where IDCondicion= '" + txtIDCondicion.Text + "'", ConLibregco)
            txtCondicion.Text = Convert.ToString(cmd.ExecuteScalar()).ToUpper

            cmd = New MySqlCommand("SELECT Dias FROM Condicion Where IDCondicion= '" + txtIDCondicion.Text + "'", ConLibregco)
            txtCondicion.Tag = Convert.ToString(cmd.ExecuteScalar()).ToUpper

            ConLibregco.Close()
        End If
    End Sub

    Private Sub dgvArticulosFactura_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvArticulosFactura.CellFormatting
        Try

            If e.ColumnIndex = Me.dgvArticulosFactura.Columns(12).Index AndAlso (e.Value IsNot Nothing) Then

                With Me.dgvArticulosFactura.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    Dim IDAlmacen As String = dgvArticulosFactura.CurrentRow.Cells(12).Value

                    If Con.State = ConnectionState.Open Then
                        Con.Close()
                    End If

                    Con.Open()
                    cmd = New MySqlCommand("Select Almacen from Almacen where IDAlmacen='" + IDAlmacen + "'", Con)
                    Dim Almacen As String = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    .ToolTipText = Almacen
                End With
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvArticulosFactura_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvArticulosFactura.CellMouseMove
        If e.ColumnIndex = 13 Then
            If dgvArticulosFactura.Rows.Count = 0 Then
            Else
                Cursor.Current = Cursors.Hand
            End If
        End If
    End Sub

    Private Sub dgvArticulosFactura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellClick
        If e.RowIndex >= 0 Then

            If e.ColumnIndex = 8 Then
                dgvArticulosFactura.EditMode = DataGridViewEditMode.EditOnEnter
            ElseIf e.ColumnIndex = 13 Then
                frm_cambiar_almacenes_fact.IDPrecios.Text = dgvArticulosFactura.CurrentRow.Cells(2).Value
                frm_cambiar_almacenes_fact.ShowDialog(Me)
            End If

        End If

    End Sub

    Private Sub BuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarArtículosToolStripMenuItem.Click
        If txtCodigoArticulo.Focused = False Then
            txtCodigoArticulo.Focus()
        Else
            txtCodigoArticulo.Focus()

            btnBuscarArticulo.PerformClick()
        End If

    End Sub

    Private Sub cbxPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPrecio.SelectedIndexChanged
        Try
            If CbxMedida.Text <> "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
                lblIDPrecio.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C")

                BuscarVentas()

                If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
                    If btnControlTipoPago.Tag = 2 Then

                        ConLibregco.Open()

                        cmd = New MySqlCommand("SELECT CobrarComision From Articulos where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)

                        If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
                            cmd = New MySqlCommand("SELECT PorcentajeComision From Articulos where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)
                            txtPrecio.Text = (CDbl(txtPrecio.Text) * (1 + (CDbl(Convert.ToDouble(cmd.ExecuteScalar())) / 100))).ToString("C")
                        End If

                        ConLibregco.Close()

                    End If
                End If

            End If


            SumarTotalArticulo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)

        If txtIDCliente.Text = 1 Then
            txtNombre.Enabled = True
            txtNombre.ReadOnly = False
        Else

            If CInt(DTConfiguracion.Rows(83 - 1).Item("Value2Int")) = 1 Then
                If CInt(DTConfiguracion.Rows(84 - 1).Item("Value2Int")) = txtIDCliente.Text Then
                    txtNombre.Enabled = True
                    txtNombre.ReadOnly = False
                Else
                    txtNombre.Enabled = False
                    txtNombre.ReadOnly = True
                End If
            Else
                txtNombre.Enabled = False
                txtNombre.ReadOnly = True
            End If

        End If

    End Sub

    Private Sub txtCodigoArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCodigoArticulo.Text <> ""  Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtCodigoArticulo.Text <> "" Then
                If txtCodigoArticulo.SelectionStart = txtCodigoArticulo.TextLength Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub

    Private Sub CbxMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            txtCantidadArticulo.Focus()
            txtCantidadArticulo.SelectAll()

        End If
    End Sub

    Private Sub txtCantidadArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            If txtCantidadArticulo.SelectionStart = 0 Then
                txtCodigoArticulo.Focus()
                txtCodigoArticulo.SelectAll()
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtCantidadArticulo.SelectionStart = txtCantidadArticulo.TextLength Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Up Then
            If txtCantidadArticulo.Text <> "" Then
                If IsNumeric(txtCantidadArticulo.Text) Then
                    If CDbl(txtCantidadArticulo.Text) > 1 Then
                        txtCantidadArticulo.Text = CDbl(txtCantidadArticulo.Text) + 1
                        txtCantidadArticulo.SelectAll()
                    End If
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If txtCantidadArticulo.Text <> "" Then
                If IsNumeric(txtCantidadArticulo.Text) Then
                    If CDbl(txtCantidadArticulo.Text) > 1 Then
                        txtCantidadArticulo.Text = CDbl(txtCantidadArticulo.Text) - 1
                        txtCantidadArticulo.SelectAll()
                    End If
                End If
            End If


        End If
    End Sub

    Private Sub cbxPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            CbxMedida.Focus()

        End If
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")


        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecio.SelectionStart = 0 Then
                cbxPrecio.Focus()
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecio.SelectionStart = txtPrecio.TextLength Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub frm_prefacturacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            btnGuardarC.PerformClick()

            If txtIDFactura.Text <> "" Then
                LimpiarDatos()
                ActualizarTodo()
            End If

        ElseIf e.KeyCode = Keys.F12 Then
            txtNombre.Focus()
            txtNombre.SelectAll()

        ElseIf e.KeyCode = Keys.F9 Then
            If SplitContainer1.Panel1Collapsed = False Then
                If chkAplicarAutomaticamente.Checked = True Then
                    chkAplicarAutomaticamente.Checked = False
                Else
                    chkAplicarAutomaticamente.Checked = True
                End If
            End If


        ElseIf e.KeyCode = Keys.F10 Then
            If SplitContainer1.Panel1Collapsed = False Then
                SimpleButton1.PerformClick()
            End If
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtIDCondicion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDCondicion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDescripcionArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcionArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            CbxMedida.Focus()
        End If
    End Sub

    Private Sub dgvArticulosFactura_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellEndEdit
        dgvArticulosFactura.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvArticulosFactura_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvArticulosFactura.CurrentCellDirtyStateChanged
        If dgvArticulosFactura.IsCurrentCellDirty Then
            dgvArticulosFactura.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvArticulosFactura_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvArticulosFactura.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = dgvArticulosFactura.CurrentCell.ColumnIndex


        If Columna = 5 Then

            If dgvArticulosFactura.CurrentRow.Cells(16).Value = 1 Then
                Dim Caracter As Char = e.KeyChar
                Dim Txt As TextBox = CType(sender, TextBox)

                If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            Else

                Dim Caracter As Char = e.KeyChar
                Dim Txt As TextBox = CType(sender, TextBox)

                If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            End If

        ElseIf Columna = 8 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub dgvArticulosFactura_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellValueChanged
        Try
            If e.ColumnIndex = 5 Then
                If IsNumeric(CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value)) Then
                    If CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value) = 0 Then
                        dgvArticulosFactura.CurrentRow.Cells(5).Value = 1
                    Else
                        dgvArticulosFactura.CurrentRow.Cells(12).Value = (CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value) * CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value)).ToString("C4")
                    End If
                Else
                    dgvArticulosFactura.CurrentRow.Cells(5).Value = 1
                End If

                SumTotales()
            End If


        Catch ex As Exception
            dgvArticulosFactura.CurrentRow.Cells(5).Value = 1
            SumTotales()
        End Try

        Try
            If e.ColumnIndex = 8 Then
                If IsNumeric(CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value)) Then

                    ConLibregco.Open()
                    cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + dgvArticulosFactura.CurrentRow.Cells(4).Value.ToString + "'", ConLibregco)
                    Dim lblItbis As String = Convert.ToDouble(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    dgvArticulosFactura.CurrentRow.Cells(9).Value = CDbl(CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value) / (1 + CDbl(lblItbis))).ToString("C4")
                    dgvArticulosFactura.CurrentRow.Cells(11).Value = CDbl(CDbl(CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value) / (1 + CDbl(lblItbis))) * CDbl(lblItbis)).ToString("C4")
                    dgvArticulosFactura.CurrentRow.Cells(12).Value = (CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value) * CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value)).ToString("C4")


                    Dim PriceLevel As String = GetPriceLevel(CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value), dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue.ToString)

                    If cbxPrecio.Items.Contains(PriceLevel) Then
                        dgvArticulosFactura.CurrentRow.Cells(14).Value = PriceLevel
                    Else
                        dgvArticulosFactura.CurrentRow.Cells(14).Value = "N/A"
                    End If

                Else
                    dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(GetPricesWithIDPrecio(dgvArticulosFactura.CurrentRow.Cells(14).Value, dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue)).ToString("C")
                    dgvArticulosFactura.CurrentRow.Cells(14).Value = GetPriceLevel(CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value), dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue.ToString)
                End If

                SumTotales()
            End If

        Catch ex As Exception
            dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(GetPricesWithIDPrecio("A", dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue)).ToString("C4")
            dgvArticulosFactura.CurrentRow.Cells(14).Value = "A"

            SumTotales()

        End Try

        dgvArticulosFactura.Invalidate()
    End Sub

    Private Sub dgvArticulosFactura_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellLeave
        If e.ColumnIndex = 8 Then
            If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then

                    If CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value) < GetPricesWithIDPrecio(cbxPrecio.GetItemText(cbxPrecio.Items(cbxPrecio.Items.Count - 1)), dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue) Then
                        MessageBox.Show("El precio colocado excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                        dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(GetPricesWithIDPrecio("A", dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue)).ToString("C")
                        dgvArticulosFactura.CurrentRow.Cells(14).Value = "A"
                    Else
                        dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value).ToString("C4")
                        dgvArticulosFactura.CurrentRow.Cells(12).Value = (CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value) * CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value)).ToString("C4")

                    End If

                Else
                    dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value).ToString("C4")
                    dgvArticulosFactura.CurrentRow.Cells(12).Value = (CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value) * CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value)).ToString("C4")
                End If

            Else
                If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then

                    If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                        If CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value) < GetPricesWithIDPrecio("D", dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue) Then
                            MessageBox.Show("El precio colocado excede al costo del producto.", "Costo excede al precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(GetPricesWithIDPrecio("A", dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue)).ToString("C")
                            dgvArticulosFactura.CurrentRow.Cells(14).Value = "A"

                        Else
                            dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value).ToString("C4")
                            dgvArticulosFactura.CurrentRow.Cells(12).Value = (CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value) * CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value)).ToString("C4")

                        End If
                    Else
                        If CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value) < GetPricesWithIDPrecio("E", dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue) Then
                            MessageBox.Show("El precio colocado excede al costo del producto.", "Costo excede al precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(GetPricesWithIDPrecio("A", dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue)).ToString("C")
                            dgvArticulosFactura.CurrentRow.Cells(14).Value = "A"

                        Else
                            dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value).ToString("C4")
                            dgvArticulosFactura.CurrentRow.Cells(12).Value = (CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value) * CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value)).ToString("C4")

                        End If
                    End If


                Else
                    dgvArticulosFactura.CurrentRow.Cells(8).Value = CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value).ToString("C4")
                    dgvArticulosFactura.CurrentRow.Cells(12).Value = (CDbl(dgvArticulosFactura.CurrentRow.Cells(5).Value) * CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value)).ToString("C4")
                End If

            End If
        End If
    End Sub


    Private Sub frm_prefacturacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If txtIDFactura.Text = "" Then
            If dgvArticulosFactura.Rows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea cerrar el formulario de prefacturación?", "Cerrar formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If Result = MsgBoxResult.Yes Then
                    'Verificar si se esta usando
                    If txtIDFactura.Text <> "" Then
                        sqlQ = "UPDATE PreFactura SET Usando=0 WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
                        Con.Open()
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                        Con.Close()
                    End If
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        Else
            If txtIDFactura.Text <> "" Then
                sqlQ = "UPDATE PreFactura SET Usando=0 WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
                Con.Open()
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()
            End If
        End If
    End Sub

    Private Sub dgvArticulosFactura_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvArticulosFactura.RowsAdded
        If dgvArticulosFactura.Rows(e.RowIndex).Cells(15).Value = 1 Then
            dgvArticulosFactura.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            dgvArticulosFactura.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkSalmon
            dgvArticulosFactura.Rows(e.RowIndex).Cells(7).Style.Font = New Font("Segoe UI", 7, FontStyle.Regular)
        End If

        If DoProbabilidades.IsBusy Then
            DoProbabilidades.CancelAsync()
        Else
            DoProbabilidades.RunWorkerAsync(dgvArticulosFactura.Rows(e.RowIndex).Cells(4).Value)
        End If


        If dgvArticulosFactura.Rows.Count > 0 Then
            cbxMoneda.Enabled = False
        Else
            cbxMoneda.Enabled = True
        End If
    End Sub


    Private Sub RemoveHijos()
        Dim dsTemp As New DataSet

        Con.Open()
        cmd = New MySqlCommand("SELECT IDProductosHijos,IDPrecioPadre,CantidadParaOferta,MedidaPadre.Medida,PrecioArticuloHijo.IDArticulo, ArticulosHijo.Descripcion, ArticulosHijo.Referencia, CantidadEnOferta, IDPrecioHijo, MedidaHijo.Medida, LimitarHastaFecha, HastaFecha, ValorIncluidoPrecio, Nivel, Precio, Articulos_hijos.Nulo FROM Libregco.articulos_hijos INNER JOIN Libregco.PrecioArticulo as PrecioArticuloPadre on articulos_hijos.IDPrecioPadre=PrecioarticuloPadre.IDPrecios INNER JOIN Libregco.Medida as MedidaPadre on PrecioArticuloPadre.IDMedida=MedidaPadre.IDMedida INNER JOIN Libregco.Articulos as ArticulosPadre on PrecioArticuloPadre.IDArticulo=ArticulosPadre.IDArticulo INNER JOIN Libregco.PrecioArticulo as PrecioArticuloHijo on articulos_hijos.IDPrecioHijo=PrecioarticuloHijo.IDPrecios INNER JOIN Libregco.Articulos as ArticulosHijo on PrecioArticuloHijo.IDArticulo=ArticulosHijo.IDArticulo INNER JOIN Libregco.Medida as MedidaHijo on PrecioArticuloHijo.IDMedida=MedidaHijo.IDMedida Where PrecioArticuloPadre.IDArticulo ='" + dgvArticulosFactura.CurrentRow.Cells(4).Value.ToString + "' and articulos_hijos.Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dsTemp, "Articulos")
        Con.Close()

        Dim Tabla As DataTable = dsTemp.Tables("Articulos")


        For Each rw As DataGridViewRow In dgvArticulosFactura.Rows
            If rw.Cells(15).Value = 1 Then

                For Each dt As DataRow In Tabla.Rows

                    If dt.Item("IDPrecioHijo") = rw.Cells(2).Value Then
                        dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.Rows(rw.Index))
                    End If
                Next
            End If
        Next

        Tabla.Dispose()
    End Sub

End Class