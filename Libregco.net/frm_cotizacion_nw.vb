Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors

Public Class frm_cotizacion_nw
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend ShowInfoArticle, FactDebajoCosto, DefaultIDNCF, DefaultNcf, FacturarSinExist, DefaultIDCondicion, DefaultCondicion, DefaultCondicionDias, SolicitarNombreCliente, LimiteSolNombre, ModificacionArticuloBase, FacturacionSinInventarioArticuloBase, ControlTipoPago, BloqueoTarjeta, RNCInteligente, PictureHeight, PermitirDuplicado, ControlarNivelesPrecios, MostrarNoOrden, ExistenciaSimilares, ExistenciaRelacionados, DefaultCurrency As String
    Friend ChangedCodeEmployee, ModifyingProduct, TipoPagoMostrado, CheckDuplicates As Boolean
    Friend RNCliente, DireccionCliente, TelefonoCliente, Cotizacion As String

    Friend Permisos, ListadoProbVendidos, Precios As New ArrayList
    Friend CantidadCaracteresRNC As New List(Of Integer)
    Friend TablaArticulos As DataTable

    Dim RepositoryIDArticulo As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryDescrip As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}
    Dim RepositoryCantidadFraccionables As New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit() With {.MinValue = "0.01", .MaxValue = "9999999", .EditMask = "n2", .NullValuePrompt = 1, .NullValuePromptShowForEmptyValue = 1, .AllowNullInput = DevExpress.Utils.DefaultBoolean.False}
    Dim RepositoryCantidadNoFraccionables As New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit() With {.MinValue = "1", .MaxValue = "9999999", .EditMask = "n0", .NullValuePrompt = 1, .NullValuePromptShowForEmptyValue = 1, .AllowNullInput = DevExpress.Utils.DefaultBoolean.False}

    Dim RepositoryMedida As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.ShowFooter = False, .BestFitMode = BestFitMode.BestFit}
    Dim RepositoryAlmacen As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.ShowFooter = False, .BestFitMode = BestFitMode.BestFit}

    Dim RepositoryImagen As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom}
    Dim RepositoryChkVerificado As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryNivelPrecio As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox() With {.NullValuePrompt = "A", .TextEditStyle = TextEditStyles.DisableTextEditor}

    Dim RepositoryPrecio As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryPrecioSinItbis As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()

    Private Sub BuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarArtículosToolStripMenuItem.Click
        If GridView1.FocusedColumn.FieldName = GridView1.Columns("IDArticulo").FieldName Then

            btn_buscar_articulos.PerformClick()
        Else

            GridView1.Focus()
            GridView1.FocusedRowHandle = GridControl1.NewItemRowHandle
            GridView1.FocusedColumn = GridView1.Columns("IDArticulo")
            GridView1.ShowEditor()
        End If

    End Sub

    Private Sub ConsultaDeCotizaciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeCotizaciToolStripMenuItem.Click

    End Sub

    Private Sub frm_cotizacion_nw_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        GridView1.BestFitColumns()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDCotizacion.Text = "" Then
            If TablaArticulos.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de cotización?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
        End If
    End Sub

    Dim RepositorySubtotalBruto As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryDescuento As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositorySubtotal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbis As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisTotal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryImporte As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim CbxPrecioHeader As New Windows.Forms.ComboBox

    Private clone As DataView
    Private flag As Boolean = False

    Private Sub frm_cotizacion_nw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SetArticulosTable()
        SetConfiguracion()
        LimpiarDatos()
        FillPrecios()
        ActualizarTodo()
    End Sub

    Private Sub RepositoryMedida_EditValueChanged(sender As Object, ByVal e As EventArgs)
        If CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue.ToString <> "" Then
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("IDMedida"), CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue.ToString)

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPrecios FROM Libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + GridView1.GetFocusedRowCellValue("IDArticulo").ToString + "' AND PrecioArticulo.IDMedida='" + GridView1.GetFocusedRowCellValue("IDMedida").ToString + "' and PrecioArticulo.Nulo=0", ConMixta)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("IDPrecios"), Convert.ToString(cmd.ExecuteScalar()))
            ConMixta.Close()

            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("PrecioTotal"), GetPrices(GridView1.GetFocusedRowCellValue("NivelPrecio"), GridView1.GetFocusedRowCellValue("IDArticulo"), CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue.ToString, cbxMoneda.EditValue))

            If IsNumeric(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad"))) And IsNumeric(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) Then
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
            End If
        End If
    End Sub

    Private Sub GridView1_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEdit
        If e.Column.FieldName = "Cantidad" Then
            Dim obj As Object = GridView1.GetFocusedRowCellValue(GridView1.Columns("Fraccionamiento"))

            If obj Is Nothing Then
            Else
                If obj.ToString = "1" Then
                    e.RepositoryItem = RepositoryCantidadFraccionables
                Else
                    e.RepositoryItem = RepositoryCantidadNoFraccionables
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs) Handles GridView1.ShownEditor
        Dim view As GridView = TryCast(sender, GridView)
        Dim obj As Object = GridView1.GetFocusedRowCellValue(GridView1.Columns("IDPrecios"))

        If obj Is Nothing Then

        Else

            view.ActiveEditor.Properties.ReadOnly = view.FocusedColumn.FieldName = "IDArticulo" AndAlso view.FocusedRowHandle Mod 2 = 0

            If view.FocusedColumn.FieldName = "IDMedida" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.LookUpEdit Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit
                Dim table As DataTable
                Dim row As DataRow
                edit = CType(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                table = CType(edit.Properties.DataSource, DataTable)
                clone = New DataView(table)
                row = view.GetDataRow(view.FocusedRowHandle)
                clone.RowFilter = "IDArticulo = " + row("IDArticulo").ToString()
                edit.Properties.DataSource = clone

            ElseIf view.FocusedColumn.FieldName = "IDAlmacen" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.LookUpEdit Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit
                Dim table As DataTable
                Dim row As DataRow
                edit = CType(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                table = CType(edit.Properties.DataSource, DataTable)
                clone = New DataView(table)
                row = view.GetDataRow(view.FocusedRowHandle)
                clone.RowFilter = "IDArticulo = " + row("IDArticulo").ToString()
                edit.Properties.DataSource = clone


            End If
        End If


    End Sub

    Private Sub GridControl1_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControl1.ProcessGridKey
        Dim view As GridView = TryCast((TryCast(sender, GridControl)).FocusedView, GridView)

        If e.KeyData = Keys.Down OrElse e.KeyData = Keys.Up Then
            If view.ActiveEditor IsNot Nothing AndAlso view.ActiveEditor.[GetType]() = GetType(SpinEdit) Then
                Dim edit As SpinEdit = (TryCast(view.ActiveEditor, SpinEdit))
                If e.KeyData = Keys.Down Then
                    If edit.Value > 1 Then
                        edit.EditValue = Convert.ToInt32(edit.EditValue) - edit.Properties.Increment
                    End If
                End If
                If e.KeyData = Keys.Up Then
                    edit.EditValue = Convert.ToInt32(edit.EditValue) + edit.Properties.Increment
                End If
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub ActualizarTodo()
        Me.CenterToParent()
        Precios = GetRangePrices()
        ControlSuperClave = 1
        txtNombre.Enabled = False
        txtFecha.Value = Today.ToString("dd/MM/yyyy")
        lblStatusBar.Text = "Listo."
        'HabilitarControles()
        txtNombre.Enabled = True
        txtNombre.ReadOnly = False
        cbxMoneda.Enabled = True
        NewNCFValue.Text = ""
        Cotizacion = ""
        ModifyingProduct = False
        GPExistencia.Visible = False
        ModifyingProduct = False
        txtIDCliente.Text = 1
        txtNombre.Text = "CONTADO"
        txtNivelPrecio.Text = "A"
        txtIDCondicion.Text = DefaultIDCondicion
        txtIDCondicion.Tag = DefaultCondicionDias
        txtCondicion.Text = DefaultCondicion
        TipoPagoMostrado = False
        btnControlTipoPago.Tag = 3
        btnControlTipoPago.Image = My.Resources.Facturacion_x90
        btnControlTipoPago.Text = "Pago Mixto / Otros"
        btnModificar.Enabled = True
        cbxMoneda.EditValue = CInt(DefaultCurrency)
        'Me.Size = New Size(1000, 730)
        ListadoProbVendidos.Clear()

        If ControlTipoPago = 1 Then
            btnControlTipoPago.Visible = True
            btnControlTipoPago.Image = My.Resources.Facturacion_x90
            btnControlTipoPago.Text = "Pago Mixto / Otros"
        Else
            btnControlTipoPago.Visible = False
        End If
    End Sub

    Private Sub SetConfiguracion()
        Try
            'Mostrar el panel de informacion de los articulos
            Con.Open()
            ConMixta.Open()

            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=15", Con)
            ShowInfoArticle = Convert.ToString(cmd.ExecuteScalar())

            'Permitir facturar debajo del costo
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=16", Con)
            FactDebajoCosto = Convert.ToString(cmd.ExecuteScalar())

            'Comprobante Fiscal Predeterminado
            cmd = New MySqlCommand("SELECT TipoComprobante FROM configuracion INNER JOIN comprobantefiscal on Configuracion.Value2Int=ComprobanteFiscal.IDComprobanteFiscal Where IDConfiguracion=13", Con)
            DefaultNcf = Convert.ToString(cmd.ExecuteScalar())

            'Condicion Predeterminada
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=59", Con)
            DefaultIDCondicion = Convert.ToString(cmd.ExecuteScalar())

            'Condicion Predeterminada
            cmd = New MySqlCommand("Select Condicion from" & SysName.Text & "Configuracion INNER JOIN Libregco.Condicion on Configuracion.Value2Int=Condicion.IDCondicion Where IDConfiguracion=59", ConMixta)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

            'Facturar sin Existencia
            cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=21", Con)
            FacturarSinExist = Convert.ToString(cmd.ExecuteScalar())

            'Permitir facturación sin inventario de artículo base No.01
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=129", Con)
            FacturacionSinInventarioArticuloBase = Convert.ToDouble(cmd.ExecuteScalar())

            'Facturación con límite de crédito agotado
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=195", Con)
            ControlarNivelesPrecios = Convert.ToDouble(cmd.ExecuteScalar())

            Dim ds As New DataSet
            cbxMoneda.Properties.Items.Clear()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM Libregco.tipomoneda order by IDTipoMoneda ASC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "tipomoneda")

            Dim Tabla As DataTable = ds.Tables("tipomoneda")

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

            cbxMoneda.SelectedIndex = 0
            ds.Dispose()

            'Moneda predeterminada
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=209", Con)
            DefaultCurrency = CInt(Convert.ToString(cmd.ExecuteScalar()))

            'Llenado medidas 
            cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Medida.Abreviatura as Medida,IDPrecios,IDArticulo FROM libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida where PrecioArticulo.Nulo=0", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "precioarticulo")

            Dim TablaMedida As DataTable = ds.Tables("precioarticulo")

            RepositoryMedida.DataSource = TablaMedida
            RepositoryMedida.ValueMember = "IDMedida"
            RepositoryMedida.DisplayMember = "Medida"

            RepositoryMedida.PopulateColumns()
            RepositoryMedida.Columns(RepositoryMedida.ValueMember).Visible = False
            RepositoryMedida.Columns(2).Visible = False
            RepositoryMedida.Columns(3).Visible = False
            RepositoryMedida.ShowHeader = False

            'Llenando almacenes
            cmd = New MySqlCommand("SELECT Existencia.IDAlmacen,Almacen.Almacen,Existencia,Medida.Medida,IDArticulo FROM libregco.existencia INNER JOIN Libregco.Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida where Medida.Desactivar=0", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Existencia")

            Dim TablaExistencias As DataTable = ds.Tables("Existencia")
            RepositoryAlmacen.DataSource = TablaExistencias
            RepositoryAlmacen.ValueMember = "IDAlmacen"
            RepositoryAlmacen.DisplayMember = "Almacen"

            RepositoryAlmacen.PopulateColumns()
            RepositoryAlmacen.Columns(RepositoryAlmacen.ValueMember).Visible = False
            RepositoryAlmacen.Columns(4).Visible = False
            RepositoryAlmacen.ShowHeader = True

            Con.Close()
            ConMixta.Close()

            RepositoryPrecio.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryPrecio.Mask.EditMask = "c"
            RepositoryPrecio.Mask.UseMaskAsDisplayFormat = True
            RepositoryPrecio.NullText = CDbl(0).ToString("C")
            RepositoryPrecio.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositoryPrecioSinItbis.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryPrecioSinItbis.Mask.EditMask = "c"
            RepositoryPrecioSinItbis.Mask.UseMaskAsDisplayFormat = True
            RepositoryPrecioSinItbis.NullText = CDbl(0).ToString("C")
            RepositoryPrecioSinItbis.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositorySubtotalBruto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositorySubtotalBruto.Mask.EditMask = "c"
            RepositorySubtotalBruto.Mask.UseMaskAsDisplayFormat = True
            RepositorySubtotalBruto.NullText = CDbl(0).ToString("C")
            RepositorySubtotalBruto.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositoryDescuento.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryDescuento.Mask.EditMask = "c"
            RepositoryDescuento.Mask.UseMaskAsDisplayFormat = True
            RepositoryDescuento.NullText = CDbl(0).ToString("C")
            RepositoryDescuento.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositorySubtotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositorySubtotal.Mask.EditMask = "c"
            RepositorySubtotal.Mask.UseMaskAsDisplayFormat = True
            RepositorySubtotal.NullText = CDbl(0).ToString("C")
            RepositorySubtotal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositoryItbis.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryItbis.Mask.EditMask = "c"
            RepositoryItbis.Mask.UseMaskAsDisplayFormat = True
            RepositoryItbis.NullText = CDbl(0).ToString("C")
            RepositoryItbis.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositoryItbisTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryItbisTotal.Mask.EditMask = "c"
            RepositoryItbisTotal.Mask.UseMaskAsDisplayFormat = True
            RepositoryItbisTotal.NullText = CDbl(0).ToString("C")
            RepositoryItbisTotal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositoryImporte.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryImporte.Mask.EditMask = "c"
            RepositoryImporte.Mask.UseMaskAsDisplayFormat = True
            RepositoryImporte.NullText = CDbl(0).ToString("C")
            RepositoryImporte.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            AddHandler RepositoryMedida.EditValueChanged, AddressOf RepositoryMedida_EditValueChanged

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Desde SetConfiguracion")
        End Try
    End Sub

    Private Sub SetArticulosTable()
        TablaArticulos = New DataTable("CotizacionDetalle")
        TablaArticulos.Columns.Add("IDCotizacionDetalle", System.Type.GetType("System.String"))     '0
        TablaArticulos.Columns.Add("IDArticulo", System.Type.GetType("System.String"))       '1
        TablaArticulos.Columns.Add("Descripcion", System.Type.GetType("System.String"))  '2
        TablaArticulos.Columns.Add("Referencia", System.Type.GetType("System.String"))      '3
        TablaArticulos.Columns.Add("IDPrecios", System.Type.GetType("System.String")) '5
        TablaArticulos.Columns.Add("IDMedida", System.Type.GetType("System.String"))     '6
        TablaArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Double"))    '4
        TablaArticulos.Columns.Add("PrecioTotal", System.Type.GetType("System.Double"))          '7
        TablaArticulos.Columns.Add("PrecioSinIt", System.Type.GetType("System.Double"))         '8
        TablaArticulos.Columns.Add("SubtotalBruto", System.Type.GetType("System.Double"))         '9
        TablaArticulos.Columns.Add("Descuento", System.Type.GetType("System.Double"))      '10
        TablaArticulos.Columns.Add("Subtotal", System.Type.GetType("System.Double"))      '11
        TablaArticulos.Columns.Add("Itbis", System.Type.GetType("System.Double"))      '12
        TablaArticulos.Columns.Add("ItbisTotal", System.Type.GetType("System.Double"))      '13
        TablaArticulos.Columns.Add("Importe", System.Type.GetType("System.Double"))     '14
        TablaArticulos.Columns.Add("IDAlmacen", System.Type.GetType("System.String"))    '15
        TablaArticulos.Columns.Add("NivelPrecio", System.Type.GetType("System.Object"))      '16
        TablaArticulos.Columns.Add("Hijo", System.Type.GetType("System.String"))   '17
        TablaArticulos.Columns.Add("Fraccionamiento", System.Type.GetType("System.String"))  '18
        TablaArticulos.Columns.Add("Existencia", System.Type.GetType("System.Double"))                   '19
        TablaArticulos.Columns.Add("Imagen", System.Type.GetType("System.Object"))   '20
        TablaArticulos.Columns.Add("Verificado", System.Type.GetType("System.String"))        '21
        TablaArticulos.Columns.Add("TipoProducto", System.Type.GetType("System.String"))   '22
        TablaArticulos.Columns.Add("ItbisPorc", System.Type.GetType("System.Double"))   '23
        GridControl1.DataSource = TablaArticulos

        GridView1.Columns("Imagen").ColumnEdit = RepositoryImagen
        'GridView1.Columns("IDArticulo").ColumnEdit = RepositoryIDArticulo
        GridView1.Columns("Descripcion").ColumnEdit = RepositoryDescrip
        GridView1.Columns("PrecioTotal").ColumnEdit = RepositoryPrecio
        GridView1.Columns("PrecioSinIt").ColumnEdit = RepositoryPrecioSinItbis
        GridView1.Columns("SubtotalBruto").ColumnEdit = RepositorySubtotalBruto
        GridView1.Columns("Descuento").ColumnEdit = RepositoryDescuento
        GridView1.Columns("Subtotal").ColumnEdit = RepositorySubtotal
        GridView1.Columns("Itbis").ColumnEdit = RepositoryItbis
        GridView1.Columns("ItbisTotal").ColumnEdit = RepositoryItbisTotal
        GridView1.Columns("Importe").ColumnEdit = RepositoryImporte
        GridView1.Columns("IDMedida").ColumnEdit = RepositoryMedida
        GridView1.Columns("IDAlmacen").ColumnEdit = RepositoryAlmacen
        GridView1.Columns("NivelPrecio").ColumnEdit = RepositoryNivelPrecio
        GridView1.Columns("Verificado").ColumnEdit = RepositoryChkVerificado

        '''Estilos
        GridView1.Columns("Imagen").Width = 80
        GridView1.Columns("IDCotizacionDetalle").Visible = False
        GridView1.Columns("IDArticulo").Caption = "Código"
        GridView1.Columns("IDArticulo").Width = 65
        GridView1.Columns("IDMedida").Caption = "Medida"
        GridView1.Columns("IDPrecios").Visible = False
        GridView1.Columns("IDMedida").OptionsColumn.ReadOnly = True
        GridView1.Columns("Descripcion").Caption = "Descripción"
        GridView1.Columns("Descripcion").Width = 260
        GridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
        GridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
        GridView1.Columns("Referencia").OptionsColumn.AllowEdit = False
        GridView1.Columns("Referencia").OptionsColumn.ReadOnly = True
        GridView1.Columns("Referencia").Width = 100
        GridView1.Columns("Cantidad").Width = 60
        GridView1.Columns("PrecioTotal").Caption = "Precio"
        GridView1.Columns("PrecioTotal").Width = 100
        GridView1.Columns("PrecioTotal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("PrecioTotal").DisplayFormat.FormatString = "C2"
        GridView1.Columns("PrecioSinIt").Visible = False
        GridView1.Columns("PrecioSinIt").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("PrecioSinIt").DisplayFormat.FormatString = "C2"
        GridView1.Columns("PrecioSinIt").OptionsColumn.AllowEdit = False
        GridView1.Columns("PrecioSinIt").OptionsColumn.ReadOnly = True

        GridView1.Columns("SubtotalBruto").Visible = False
        GridView1.Columns("SubtotalBruto").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("SubtotalBruto").DisplayFormat.FormatString = "C2"
        GridView1.Columns("SubtotalBruto").OptionsColumn.AllowEdit = False
        GridView1.Columns("SubtotalBruto").OptionsColumn.ReadOnly = True
        GridView1.Columns("SubtotalBruto").Caption = "Subtotal Bruto"
        GridView1.Columns("SubtotalBruto").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SubtotalBruto", "{0:c2}")


        GridView1.Columns("Descuento").Visible = False
        GridView1.Columns("Descuento").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Descuento").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Descuento").OptionsColumn.AllowEdit = False
        GridView1.Columns("Descuento").OptionsColumn.ReadOnly = True

        GridView1.Columns("Subtotal").Visible = False
        GridView1.Columns("Subtotal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Subtotal").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Subtotal").OptionsColumn.AllowEdit = False
        GridView1.Columns("Subtotal").OptionsColumn.ReadOnly = True
        GridView1.Columns("Subtotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Subtotal", "{0:c2}")

        GridView1.Columns("Itbis").Visible = False
        GridView1.Columns("Itbis").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Itbis").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Itbis").OptionsColumn.AllowEdit = False
        GridView1.Columns("Itbis").OptionsColumn.ReadOnly = True

        GridView1.Columns("ItbisTotal").Visible = False
        GridView1.Columns("ItbisTotal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisTotal").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisTotal").OptionsColumn.AllowEdit = False
        GridView1.Columns("ItbisTotal").OptionsColumn.ReadOnly = True
        GridView1.Columns("ItbisTotal").Caption = "Itbis Total"
        GridView1.Columns("ItbisTotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Itbis", "{0:c2}")

        GridView1.Columns("Importe").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Importe").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Importe").OptionsColumn.AllowEdit = False
        GridView1.Columns("Importe").OptionsColumn.ReadOnly = True
        GridView1.Columns("Importe").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:c2}")

        GridView1.Columns("IDAlmacen").Visible = True
        GridView1.Columns("IDAlmacen").Caption = "Almacen"
        GridView1.Columns("NivelPrecio").Caption = "Nivel"
        GridView1.Columns("NivelPrecio").Width = 40
        GridView1.Columns("Hijo").Visible = False
        GridView1.Columns("Hijo").OptionsColumn.AllowEdit = False
        GridView1.Columns("Hijo").OptionsColumn.ReadOnly = True
        GridView1.Columns("Fraccionamiento").Visible = False
        GridView1.Columns("Fraccionamiento").OptionsColumn.AllowEdit = False
        GridView1.Columns("Fraccionamiento").OptionsColumn.ReadOnly = True
        GridView1.Columns("Existencia").Visible = False
        GridView1.Columns("Existencia").OptionsColumn.AllowEdit = False
        GridView1.Columns("Existencia").OptionsColumn.ReadOnly = True
        GridView1.Columns("Verificado").Caption = " "
        GridView1.Columns("Verificado").Width = 20
        GridView1.Columns("TipoProducto").Visible = False
        GridView1.Columns("TipoProducto").OptionsColumn.AllowEdit = False
        GridView1.Columns("TipoProducto").OptionsColumn.ReadOnly = True
        GridView1.Columns("ItbisPorc").Visible = False
        GridView1.Columns("ItbisPorc").OptionsColumn.AllowEdit = False
        GridView1.Columns("ItbisPorc").OptionsColumn.ReadOnly = True
    End Sub

    Private Sub btn_buscar_articulos_Click(sender As Object, e As EventArgs) Handles btn_buscar_articulos.Click
        VerificacionTipoPago()
        frm_buscar_mant_articulos.ShowDialog(Me)
        GridView1.Focus()
        GridView1.FocusedRowHandle = GridControl1.NewItemRowHandle
        GridView1.FocusedColumn = GridView1.Columns("IDArticulo")
        GridView1.ShowEditor()
    End Sub

    Private Sub GridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        If (e.KeyCode = Keys.Delete And e.Modifiers = Keys.Control) Then
            If (MessageBox.Show("Está seguro que desea eliminar el artículo" & GridView1.GetFocusedRowCellValue(GridView1.Columns("Descripcion")) & "?", "Eliminar artículo de la cotización", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
            Dim view As GridView = CType(sender, GridView)
            view.DeleteRow(view.FocusedRowHandle)
        End If
    End Sub

    Private Sub GridView1_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
        Dim view As GridView = TryCast(sender, GridView)
        If view.IsNewItemRow(e.RowHandle) Then
            Dim val As Object = view.GetRowCellValue(e.RowHandle, GridView1.Columns("IDPrecios"))
            If val Is Nothing OrElse val.ToString() = String.Empty Then
                e.Valid = False
            Else
                GridView1.FocusedRowHandle = GridControl1.NewItemRowHandle
            End If
        End If

        GridView1.FocusedRowHandle = GridControl1.NewItemRowHandle
    End Sub

    Private Sub VerificacionTipoPago()
        If frm_especificar_tipopagos.Visible = False Then
            If ControlTipoPago = 1 Then
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

    Private Sub FillPrecios()
        RepositoryNivelPrecio.Items.Clear()

        If btnControlTipoPago.Tag = 1 Then
            For Each item As String In Precios
                RepositoryNivelPrecio.Items.Add(item)
                CbxPrecioHeader.Items.Add(item)
            Next

        ElseIf btnControlTipoPago.Tag = 2 Then

            For Each item As String In Precios
                If item = "C" Or item = "D" Then
                Else
                    RepositoryNivelPrecio.Items.Add(item)
                    CbxPrecioHeader.Items.Add(item)
                End If
            Next

        ElseIf btnControlTipoPago.Tag = 3 Then
            For Each item As String In Precios
                RepositoryNivelPrecio.Items.Add(item)
                CbxPrecioHeader.Items.Add(item)
            Next
        End If

        If CbxPrecioHeader.Items.Count > 0 Then
            CbxPrecioHeader.SelectedIndex = 0
        End If

    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try

            If e.Column.FieldName = "IDArticulo" AndAlso Not flag Then
                If GridView1.GetRowCellValue(e.RowHandle, e.Column) <> "" Then
                    Dim Ds As New DataSet

                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,Articulos.Referencia,ExistenciaTotal,Articulos.RutaFoto,NoPermitirCambiarPrecio,NoPagoTarjeta,IDTipoProducto,IDParentesco,Itbis FROM Libregco.Articulos INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE Referencia='" + GridView1.GetRowCellValue(e.RowHandle, e.Column).ToString + "' and Articulos.Desactivar=0 UNION ALL SELECT IDArticulo,Descripcion,Articulos.Referencia,ExistenciaTotal,RutaFoto,NoPermitirCambiarPrecio,NoPagoTarjeta,IDTipoProducto,IDParentesco,Itbis FROM Libregco.Articulos INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo='" + GridView1.GetRowCellValue(e.RowHandle, e.Column).ToString + "' and Articulos.Desactivar=0 UNION ALL SELECT IDArticulo,Descripcion,Articulos.Referencia,ExistenciaTotal,RutaFoto,NoPermitirCambiarPrecio,NoPagoTarjeta,IDTipoProducto,IDParentesco,Itbis FROM Libregco.Articulos INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE CodigoBarra='" + GridView1.GetRowCellValue(e.RowHandle, e.Column).ToString + "' and Articulos.Desactivar=0 GROUP BY IDArticulo", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Articulos")
                    Dim Tabla As DataTable = Ds.Tables("Articulos")

                    If Tabla.Rows.Count = 0 Then
                        MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        GridView1.CancelUpdateCurrentRow()

                        ConMixta.Close()
                    Else

                        If btnControlTipoPago.Tag = 2 Then
                            If (Tabla.Rows(0).Item("NoPagoTarjeta")) = 1 Then
                                MessageBox.Show("El artículo seleccionado: " & (Tabla.Rows(0).Item("Descripcion")) & " posee un bloqueo de facturación con tarjeta de crédito por lo que en estos momentos la operación no puede completarse.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                GridView1.FocusedRowHandle = 0
                                GridView1.FocusedColumn = GridView1.VisibleColumns(1)
                                GridView1.ShowEditor()
                                Exit Sub
                            End If
                        End If

                        Dim img As Image
                        If Tabla.Rows(0).Item("RutaFoto") <> "" Then
                            If System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto")) = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                img = ResizeImage(System.Drawing.Image.FromStream(wFile), 45)
                                wFile.Close()
                            Else
                                img = ResizeImage(My.Resources.No_Image, 45)
                            End If
                        Else
                            img = ResizeImage(My.Resources.No_Image, 45)
                        End If

                        flag = True
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("IDArticulo"), Tabla.Rows(0).Item("IDArticulo"))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Descripcion"), Tabla.Rows(0).Item("Descripcion"))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Referencia"), Tabla.Rows(0).Item("Referencia"))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Cantidad"), 1)
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Hijo"), Tabla.Rows(0).Item("IDParentesco"))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Existencia"), Tabla.Rows(0).Item("ExistenciaTotal"))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Imagen"), img)
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Verificado"), 0)
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("TipoProducto"), Tabla.Rows(0).Item("IDTipoProducto"))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisPorc"), Tabla.Rows(0).Item("Itbis"))

                        'Llenado medidas 
                        cmd = New MySqlCommand("SELECT OrdenPrecios From Libregco.Articulos where IDArticulo='" + GridView1.GetFocusedRowCellValue(GridView1.Columns(1)).ToString + "'", ConMixta)
                        If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
                            cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura,IDPrecios,Fraccionamiento FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + GridView1.GetFocusedRowCellValue(GridView1.Columns(1)).ToString + "' and PrecioArticulo.Nulo=0 order by contenido desc", ConMixta)
                        Else
                            cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura,IDPrecios,Fraccionamiento FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + GridView1.GetFocusedRowCellValue(GridView1.Columns(1)).ToString + "' and PrecioArticulo.Nulo=0 order by contenido asc", ConMixta)
                        End If
                        Adaptador = New MySqlDataAdapter(cmd)
                        Adaptador.Fill(Ds, "PrecioArticulo")

                        Dim TablaPrecios As DataTable = Ds.Tables("PrecioArticulo")

                        If TablaPrecios.Rows.Count = 0 Then
                            MessageBox.Show("El artículo no tiene registros de precios incluídos, por lo que no se puede incluír en el procedimiento.", "Precios no encontrados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ConMixta.Close()
                            Dim view As GridView = CType(sender, GridView)
                            view.DeleteRow(view.FocusedRowHandle)
                            Exit Sub
                        End If

                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("IDMedida"), TablaPrecios.Rows(0).Item("IDMedida"))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("IDPrecios"), TablaPrecios.Rows(0).Item("IDPrecios"))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Fraccionamiento"), TablaPrecios.Rows(0).Item("Fraccionamiento"))

                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Descuento"), 0)
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioTotal"), GetPricesWithIDPrecio(txtNivelPrecio.Text, TablaPrecios.Rows(0).Item("IDPrecios"), cbxMoneda.EditValue))

                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))

                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))

                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("NivelPrecio"), txtNivelPrecio.Text)

                        ConMixta.Close()

                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("IDAlmacen"), DtEmpleado.Rows(0).item("IDAlmacen").ToString())


                        flag = False

                        GridView1.FocusedColumn = GridView1.Columns("Referencia")
                        GridView1.ShowEditor()
                    End If

                Else
                    DeleteSelectedRows(GridView1)
                End If

            ElseIf e.Column.FieldName = "Cantidad" Then
                If IsNumeric(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad"))) And IsNumeric(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) Then
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))

                End If

            ElseIf e.Column.FieldName = "PrecioTotal" Then
                If IsNumeric(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad"))) And IsNumeric(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) Then
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                End If

            ElseIf e.Column.FieldName = "NivelPrecio" Then

                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioTotal"), GetPricesWithIDPrecio(GridView1.GetFocusedRowCellValue("NivelPrecio"), GridView1.GetFocusedRowCellValue("IDPrecios"), cbxMoneda.EditValue))

                If IsNumeric(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad"))) And IsNumeric(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) Then
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                End If

            ElseIf e.Column.FieldName = "PrecioTotal" Then

                If ControlarNivelesPrecios = 1 Then
                    If FactDebajoCosto = 0 Then
                        If CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) < GetPricesWithIDPrecio("D", GridView1.GetFocusedRowCellValue(GridView1.Columns("IDPrecios")), cbxMoneda.EditValue) Then
                            MessageBox.Show("El precio colocado excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioTotal"), CDbl(GetPricesWithIDPrecio("A", GridView1.GetFocusedRowCellValue(GridView1.Columns("IDPrecios")), cbxMoneda.EditValue)).ToString("C"))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("NivelPrecio"), "A")

                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))

                        Else
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))

                        End If

                    Else
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))

                    End If

                Else
                    If FactDebajoCosto = 0 Then

                        If CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) < GetPricesWithIDPrecio("D", GridView1.GetFocusedRowCellValue(GridView1.Columns("IDPrecios")), cbxMoneda.EditValue) Then
                            MessageBox.Show("El precio colocado excede al costo del producto.", "Costo excede al precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)


                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioTotal"), CDbl(GetPricesWithIDPrecio("A", GridView1.GetFocusedRowCellValue(GridView1.Columns("IDPrecios")), cbxMoneda.EditValue)).ToString("C"))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("NivelPrecio"), "A")

                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))

                        Else
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))

                        End If

                    Else

                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("PrecioSinIt"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) / (1 + CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Itbis"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("ItbisPorc")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioTotal"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("SubtotalBruto"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("PrecioSinIt"))) - CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Descuento")))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))
                        GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Itbis"))) * (CDbl(GridView1.GetFocusedRowCellValue(GridView1.Columns("Cantidad")))))


                    End If

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Desde CellValueChanged")
        End Try
    End Sub

    Private Sub DeleteSelectedRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Row As DataRow
        Dim Rows() As DataRow
        Dim I As Integer
        ReDim Rows(View.SelectedRowsCount - 1)
        For I = 0 To View.SelectedRowsCount - 1
            Rows(I) = View.GetDataRow(View.GetSelectedRows(I))
        Next
        View.BeginSort()
        Try
            For Each Row In Rows
                Row.Delete()
            Next
        Finally
            View.EndSort()
        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        TablaArticulos.Rows.Clear()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtIDCotizacion.Clear()
        txtSecondID.Clear()
        'LimpiarDatosArticulos()
        ChkNulo.Checked = False

    End Sub

    Private Sub GridView1_HiddenEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.HiddenEditor
        If Not clone Is Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
    End Sub

    Private Sub gridView1_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        Try
            If e.FocusedColumn.FieldName <> "IDArticulo" Then
                If GridView1.GetFocusedRowCellValue("Descripcion") = "" Then
                    GridView1.FocusedColumn = GridView1.Columns("IDArticulo")
                    GridView1.ShowEditor()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class