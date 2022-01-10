Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports MySql.Data.MySqlClient
Public Class frm_prefacturacion_new

    Friend TablaArticulos As DataTable = New DataTable("TablaArticulos")
    Friend TablaPrecio As DataTable = New DataTable("Precios")
    Friend TablaExistencia As DataTable = New DataTable("Existencias")

    Private TablaSimilares As New DataTable
    Private TablaProbabilidades As DataTable = New DataTable("Probabilidades")

    Private clonePrecios As DataView
    Private cloneExistencias As DataView

    Dim sqlQ As String
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Friend RNCliente, DireccionCliente, TelefonoCliente, Cotizacion, IDGrupo_Cliente, TipoNCF As String

    Private ConProbabilidades As New MySqlConnection(CnGeneral)
    Private ConSimilares As New MySqlConnection(CnGeneral)

    Friend Permisos, Precios, ListadoProbVendidos As New ArrayList
    Friend CantidadCaracteresRNC As New List(Of Integer)

    Friend lblIDUsuario, lblIDAlmacen, lblIDTipoNCF, lblCierre As New Label
    Friend DefaultNcf, DefaultIDCondicion, DefaultCondicion, DefaultCondicionDias, ExistenciaSimilares, ExistenciaRelacionados As String
    Friend ChangedCodeEmployee, TipoPagoMostrado As Boolean

    Private Sub frm_prefacturacion_new_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.CenterToParent()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        SetConfiguracion()
        SetTablaArticulos()
        SetTablaPrecios()
        SetTablaExistencia()
        LimpiarDatos()
        ActualizarTodo()

        'frm_Test.Show(Me)
        'frm_Test.GridControl1.DataSource = TablaArticulos
        'frm_Test.GridControl2.DataSource = TablaPrecio
        'frm_Test.GridControl3.DataSource = TablaExistencia
    End Sub

    Private Sub SplitContainerProperties()
        If chkMostrarRelacionados.Checked = True Then
            If AdvBandedGridView1.RowCount > 0 Then
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

            Else
                SplitProbabilidades.Panel2Collapsed = True
            End If
        End If
    End Sub

    Private Sub AñadirCardBoardSimilares(Sender As Object, e As EventArgs)
        AdvBandedGridView1.Focus()
        AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
        AdvBandedGridView1.ShowEditor()
        AdvBandedGridView1.AddNewRow()
        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Busqueda"), DirectCast(Sender, Button).Tag.ToString)


    End Sub
    Private Sub AñadirCardBoard(Sender As Object, e As EventArgs)
        AdvBandedGridView1.Focus()
        AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
        AdvBandedGridView1.ShowEditor()
        AdvBandedGridView1.AddNewRow()
        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Busqueda"), DirectCast(Sender, Button).Tag.ToString)

        FlowProbabilidades.Controls.Remove(DirectCast(DirectCast(Sender, Control).Parent, CardBoard))
    End Sub

    Private Sub LimpiarDatos()
        'Verificar si se esta usando
        If txtIDFactura.Text <> "" Then
            sqlQ = "UPDATE PreFactura SET Usando=0 WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        End If

        TablaArticulos.Rows.Clear()
        TablaExistencia.Rows.Clear()
        TablaPrecio.Rows.Clear()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtIDFactura.Clear()
        txtSecondID.Clear()
        lblPrecioHistorico.Text = ""
        lblPrecioHistorico.Tag = ""
        lblDescripcionPrecioHistorico.Text = ""
        lblDescripcionPrecioHistorico.Tag = ""
        PictureBox1.Image = My.Resources.No_Image
        ChkNulo.Checked = False
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


    Private Sub ActualizarTodo()
        Me.CenterToParent()
        lblIDUsuario.Text = DTEmpleado.Rows(0).Item("IDEmpleado").ToString()
        ControlSuperClave = 1
        txtNombre.Enabled = False
        txtFecha.Value = Today.ToString("dd/MM/yyyy")
        lblStatusBar.ForeColor = Color.Black
        lblStatusBar.Text = "Listo."
        HabilitarControles()
        AdvBandedGridView1.OptionsView.ShowFooter = False
        SplitContainer1.Panel1Collapsed = False
        SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1
        txtNombre.Enabled = True
        txtNombre.ReadOnly = False
        cbxMoneda.Enabled = True
        NewNCFValue.Text = ""
        Cotizacion = ""
        Hora.Enabled = True
        chkAplicarAutomaticamente.Checked = False
        txtIDCliente.Text = 1
        IDGrupo_Cliente = "1"
        txtNombre.Text = "CONTADO"
        txtNivelPrecio.Text = "A"
        lblIDTipoNCF.Text = DTConfiguracion.Rows(13 - 1).Item("Value2Int").ToString
        TipoNCF = DefaultNcf
        lblIDAlmacen.Text = DTEmpleado.Rows(0).Item("IDAlmacen").ToString()
        txtIDCondicion.Text = DefaultIDCondicion
        txtIDCondicion.Tag = DefaultCondicionDias
        txtCondicion.Text = DefaultCondicion
        TipoPagoMostrado = False
        btnControlTipoPago.Tag = 3
        btnControlTipoPago.ImageOptions.LargeImage = My.Resources.Facturacion_x90
        btnControlTipoPago.Caption = "Pago Mixto / Otros"
        FlowProbabilidades.Controls.Clear()
        SplitSimilares.Panel2Collapsed = True
        SplitProbabilidades.Panel2Collapsed = True
        SplitContainer1.Panel1Collapsed = True
        cbxMoneda.EditValue = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))
        FlowSimilares.Controls.Clear()
        ListadoProbVendidos.Clear()
        Precios = GetRangePrices()
        FillPrecios()

        If cbxPreciosHeader.Properties.Items.Count > 0 Then
            cbxPreciosHeader.SelectedIndex = 0
        End If

        If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
            btnControlTipoPago.Visibility = True
            btnControlTipoPago.ImageOptions.LargeImage = My.Resources.Facturacion_x90
            btnControlTipoPago.Caption = "Pago Mixto / Otros"
        Else
            btnControlTipoPago.Visibility = False
        End If

        AdvBandedGridView1.Focus()
        AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
        AdvBandedGridView1.ShowEditor()

    End Sub

    Private Sub CargarEmpresa()
        'PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SelectUsuario()
        'Try

        lblIDUsuario.Text = DTEmpleado.Rows(0).Item("IDEmpleado").ToString()
        lblUsuario.Text = frm_inicio.lblNombre.Text

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub SetConfiguracion()
        Try
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

            'Verificando cantidad de almacenes
            cmd = New MySqlCommand("select count(*) from Libregco.Almacen Where Desactivar=0", ConLibregco)
            If Convert.ToInt16(cmd.ExecuteScalar()) = 1 Then
                IDAlmacen.Visible = False
            End If

            'Mostrar numero de orden
            Label2.Visible = Convert.ToBoolean(CInt(DTConfiguracion.Rows(197 - 1).Item("Value2Int")))
            txtOrden.Visible = Convert.ToBoolean(CInt(DTConfiguracion.Rows(197 - 1).Item("Value2Int")))

            'Bloquear toda facturación de artículo con precio CERO RD$ 0
            'BloqueoPrecioCero = DTConfiguracion.Rows(211 - 1).Item("Value2Int")

            'Mostrar artículos similares durante la prefacturación
            chkMostrarSimilares.Visibility = Convert.ToBoolean(CInt(DTConfiguracion.Rows(198 - 1).Item("Value2Int")))
            chkMostrarSimilares.Enabled = Convert.ToBoolean(CInt(DTConfiguracion.Rows(198 - 1).Item("Value2Int")))
            chkMostrarSimilares.Checked = Convert.ToBoolean(CInt(DTConfiguracion.Rows(198 - 1).Item("Value2Int")))


            'Mostrar artículos relacionados durante la prefacturación
            chkMostrarRelacionados.Visibility = Convert.ToBoolean(CInt(DTConfiguracion.Rows(199 - 1).Item("Value2Int")))
            chkMostrarRelacionados.Enabled = Convert.ToBoolean(CInt(DTConfiguracion.Rows(199 - 1).Item("Value2Int")))
            chkMostrarRelacionados.Checked = Convert.ToBoolean(CInt(DTConfiguracion.Rows(199 - 1).Item("Value2Int")))

            'Mostrar sólo artículos con existencia al mostrar los similares durante prefacturación
            If CInt(DTConfiguracion.Rows(200 - 1).Item("Value2Int")) = 1 Then
                ExistenciaSimilares = " and Articulos.ExistenciaTotal>0 "
            Else
                ExistenciaSimilares = " "
            End If

            Dim ds As New DataSet
            cbxMoneda.Properties.Items.Clear()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
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
                MantenimientoDeArtículosToolStripMenuItem.Visibility = False
            Else
                MantenimientoDeArtículosToolStripMenuItem.Visibility = True
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
                DuplicarPrefacturaciónToolStripMenuItem.Visibility = True
            Else
                DuplicarPrefacturaciónToolStripMenuItem.Visibility = False
            End If
            ConUtilitarios.Close()
            ''''''''''''''''''''''''''''''''

            chkPreviewImages.Checked = frm_inicio.chkPreviewMode.CheckState

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetTablaArticulos()
        TablaArticulos.Columns.Add("Busqueda", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaArticulos.Columns.Add("IDFactArt", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDPrecio", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDMedida", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Precio", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("PrecioSinItbis", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("DescuentoPorc", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Descuento", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Itbis", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Importe", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("IDAlmacen", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Nivel", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Hijo", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Fraccionamiento", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Existencia", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("NoPermitirCambiarPrecio", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("PorcItbis", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("DescuentoMaximo", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("IDDepartamento", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDCategoria", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDSubCategoria", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDMarca", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDTipoProducto", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("CobrarComision", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("PorcentajeComision", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("VenderCosto", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Orden", System.Type.GetType("System.String"))
        GridControl1.DataSource = TablaArticulos
        SetUpGrid(GridControl1, TablaArticulos)
    End Sub
    Private Sub CargarConfiguracion()
        Dim DsTemp As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("Select * from Configuracion", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "Configuracion")
        ConLibregco.Close()

        DTConfiguracion = DsTemp.Tables("Configuracion")
    End Sub

    Sub FillPrecios()
        cbxPreciosHeader.Properties.Items.Clear()

        If IDGrupo_Cliente <> "4" Then
            If btnControlTipoPago.Tag = 1 Then
                For Each item As String In Precios
                    cbxPreciosHeader.Properties.Items.Add(item)
                Next

            ElseIf btnControlTipoPago.Tag = 2 Then

                For Each item As String In Precios
                    If item = "C" Or item = "D" Then
                    Else
                        cbxPreciosHeader.Properties.Items.Add(item)
                    End If
                Next

            ElseIf btnControlTipoPago.Tag = 3 Then
                For Each item As String In Precios
                    cbxPreciosHeader.Properties.Items.Add(item)
                Next
            End If

            If cbxPreciosHeader.Properties.Items.Count > 0 Then
                cbxPreciosHeader.SelectedIndex = 0
            End If

        Else
            cbxPreciosHeader.Properties.Items.Add("F")


            If cbxPreciosHeader.Properties.Items.Count > 0 Then
                cbxPreciosHeader.SelectedIndex = 0
            End If
        End If
    End Sub

    Sub FillTablaRowsPrecios(ByVal IDPrefactura As String)
        TablaPrecio.Clear()

        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
            Using myCommand As MySqlCommand = New MySqlCommand("SELECT IDPrefactArt,prefacturaarticulos.IDPrecio as IDPrecios,Medida.Abreviatura,PrecioArticulo.IDMedida,Medida.Medida,Medida.Fraccionamiento,PrefacturaArticulos.IDArticulo,PrecioArticulo.DescuentoMaximo,PrecioArticulo.Contenido from" & SysName.Text & "prefacturaarticulos LEFT JOIN Libregco.PrecioArticulo on PrefacturaArticulos.IDArticulo=PrecioArticulo.IDArticulo LEFT JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrefacturaArticulos.IDPrefactura='" + IDPrefactura + "'", ConMixta)
                ConMixta.Open()

                Using myReader As MySqlDataReader = myCommand.ExecuteReader

                    TablaPrecio.Load(myReader, LoadOption.Upsert)

                    ConMixta.Close()

                End Using
            End Using
        End Using

        TablaPrecio.EndLoadData()
    End Sub


    Sub FillTablaRowsExistencias(ByVal IDPrefactura As String)
        TablaExistencia.Clear()

        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
            Using myCommand As MySqlCommand = New MySqlCommand("SELECT IDPrefactArt,Existencia.IDAlmacen,Sucursal.Sucursal,Almacen.Almacen,Existencia.Existencia,Medida.Medida,Existencia.IDPrecioArticulo,PrecioArticulo.IDArticulo,Existencia.IDExistencia FROM" & SysName.Text & "PrefacturaArticulos LEFT JOIN Libregco.PrecioArticulo on PrefacturaArticulos.IDArticulo=PrecioArticulo.IDArticulo LEFT JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida LEFT JOIN Libregco.Existencia on PrecioArticulo.IDPrecios=Existencia.IDPrecioArticulo LEFT JOIN Libregco.Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen LEFT JOIN Libregco.Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal WHERE PrefacturaArticulos.IDPrefactura='" + IDPrefactura + "'", ConMixta)
                ConMixta.Open()

                Using myReader As MySqlDataReader = myCommand.ExecuteReader

                    TablaExistencia.Load(myReader, LoadOption.Upsert)

                    ConMixta.Close()

                End Using
            End Using
        End Using

        TablaExistencia.EndLoadData()
    End Sub



    Private Sub VerificacionTipoPago()
        If frm_especificar_tipopagos.Visible = False Then
            If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
                If TipoPagoMostrado = False Then
                    btnControlTipoPago.Visibility = True
                    btnControlTipoPago.ImageOptions.LargeImage = My.Resources.Facturacion_x90
                    btnControlTipoPago.Caption = "Pago Mixto / Otros"

                    Dim f As New frm_especificar_tipopagos
                    f.Show(Me)
                    f.Focus()
                    f.Activate()
                    'frm_especificar_tipopagos.Show(Me)
                    'frm_especificar_tipopagos.Focus()
                    'frm_especificar_tipopagos.Activate()
                End If

            Else
                btnControlTipoPago.Visibility = False
                btnControlTipoPago.Tag = 3
                btnControlTipoPago.ImageOptions.LargeImage = My.Resources.Facturacion_x90
                btnControlTipoPago.Caption = "Pago Mixto / Otros"
            End If
        End If


    End Sub



    Private Sub AdvBandedGridView1_ColumnWidthChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles AdvBandedGridView1.ColumnWidthChanged
        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    End Sub

    Private Sub SetTablaPrecios()
        TablaPrecio.Columns.Add("IDPrecios", System.Type.GetType("System.String"))
        TablaPrecio.Columns.Add("Abreviatura", System.Type.GetType("System.String"))
        TablaPrecio.Columns.Add("IDMedida", System.Type.GetType("System.String"))
        TablaPrecio.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaPrecio.Columns.Add("Fraccionamiento", System.Type.GetType("System.String"))
        TablaPrecio.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaPrecio.Columns.Add("DescuentoMaximo", System.Type.GetType("System.Double"))
        TablaPrecio.Columns.Add("Contenido", System.Type.GetType("System.Double"))

        RepositoryItemLookUpEdit1Medida.DataSource = TablaPrecio

        RepositoryItemLookUpEdit1Medida.ValueMember = "IDMedida"
        RepositoryItemLookUpEdit1Medida.DisplayMember = "Abreviatura"

        RepositoryItemLookUpEdit1Medida.PopulateColumns()
        RepositoryItemLookUpEdit1Medida.Columns(0).Visible = False
        RepositoryItemLookUpEdit1Medida.Columns(2).Visible = False
        RepositoryItemLookUpEdit1Medida.Columns(3).Visible = False
        RepositoryItemLookUpEdit1Medida.Columns(4).Visible = False
        RepositoryItemLookUpEdit1Medida.Columns(5).Visible = False
        RepositoryItemLookUpEdit1Medida.Columns(6).Visible = False
        RepositoryItemLookUpEdit1Medida.Columns(7).Visible = False
        RepositoryItemLookUpEdit1Medida.ShowHeader = False

    End Sub

    Private Sub AddHeaderComboBoxEdit()
        cbxPreciosHeader.Properties.Items.Clear()
        GridControl1.Controls.Add(cbxPreciosHeader)

        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    End Sub

    Sub ResetHeaderComboBoxEditLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        Dim Rect As Rectangle = GetColumnBounds(AdvBandedGridView1.Columns("Nivel"))
        Dim Pt As New Point()
        Pt.X = (Rect.Location.X + (Rect.Width - cbxPreciosHeader.Width) \ 2) - 1
        Pt.Y = (Rect.Location.Y + (Rect.Height - cbxPreciosHeader.Height) \ 2) - 1

        cbxPreciosHeader.Location = Pt
    End Sub

    Private Sub SetTablaExistencia()
        TablaExistencia.Columns.Add("IDAlmacen", System.Type.GetType("System.String"))
        TablaExistencia.Columns.Add("Sucursal", System.Type.GetType("System.String"))
        TablaExistencia.Columns.Add("Almacen", System.Type.GetType("System.String"))
        TablaExistencia.Columns.Add("Existencia", System.Type.GetType("System.String"))
        TablaExistencia.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaExistencia.Columns.Add("IDPrecioArticulo", System.Type.GetType("System.String"))
        TablaExistencia.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaExistencia.Columns.Add("IDExistencia", System.Type.GetType("System.String"))


        RepositoryItemLookUpEditAlmacen.DataSource = TablaExistencia

        RepositoryItemLookUpEditAlmacen.ValueMember = "IDAlmacen"
        RepositoryItemLookUpEditAlmacen.DisplayMember = "Almacen"

        RepositoryItemLookUpEditAlmacen.PopulateColumns()
        RepositoryItemLookUpEditAlmacen.Columns(0).Visible = False
        RepositoryItemLookUpEditAlmacen.Columns(4).Visible = False
        RepositoryItemLookUpEditAlmacen.Columns(5).Visible = False
        RepositoryItemLookUpEditAlmacen.Columns(6).Visible = False
        RepositoryItemLookUpEditAlmacen.Columns(7).Visible = False
        'RepositoryItemLookUpEditAlmacen.ShowHeader = False


    End Sub

    Private Sub BuscarVentas()
        If AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") <> "" Then
                If AdvBandedGridView1.GetFocusedRowCellValue("IDMedida") <> "" Then
                    If AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") <> "" Then
                        If txtIDCliente.Text <> "1" Then
                            Dim dstemp As New DataSet
                            ConMixta.Open()
                            cmd = New MySqlCommand("SELECT (FacturaArticulos.Importe/FacturaArticulos.Cantidad) as UltimoPrecio,timestamp(facturadatos.fecha,facturadatos.hora) AS Fecha,if(Precio4=0,if(Precio3=0,if(PrecioContado=0,PrecioCredito,PrecioContado),Precio3),Precio4) as PrecioMinimoDisponible,if(Precio4=0,if(Precio3=0,if(PrecioContado=0,'A','B'),'C'),'D') as Nivel FROM" & SysName.Text & "facturaarticulos inner join" & SysName.Text & "facturadatos on facturaarticulos.idfactura=facturadatos.idfacturadatos INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios where facturadatos.IDCliente='" + txtIDCliente.Text + "' and FacturaArticulos.IDPrecio='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio").ToString + "' order by timestamp(facturadatos.fecha,facturadatos.hora) DESC LIMIT 1", ConMixta)
                            Adaptador = New MySqlDataAdapter(cmd)
                            Adaptador.Fill(dstemp, "Precios")
                            ConMixta.Close()

                            Dim Tabla As DataTable = dstemp.Tables("Precios")

                            If Tabla.Rows.Count > 0 Then
                                If CDbl(Tabla.Rows(0).Item("UltimoPrecio")) >= CDbl(Tabla.Rows(0).Item("PrecioMinimoDisponible")) Then
                                    lblPrecioHistorico.ForeColor = SystemColors.Highlight
                                    lblDescripcionPrecioHistorico.Text = AdvBandedGridView1.GetFocusedRowCellValue("Descripcion")
                                    lblDescripcionPrecioHistorico.Tag = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
                                    lblPrecioHistorico.Text = "El último precio utilizado para " & txtNombre.Text & " fue " & CDbl(Tabla.Rows(0).Item("UltimoPrecio")).ToString("C") & " en fecha " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                                    lblPrecioHistorico.Tag = AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio")
                                    btnAplicarAutomatico.Tag = CDbl(Tabla.Rows(0).Item("UltimoPrecio"))

                                    If chkAplicarAutomaticamente.Checked = True Then
                                        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Nivel"), GetPriceLevel(CDbl(btnAplicarAutomatico.Tag), lblPrecioHistorico.Tag.ToString, cbxMoneda.EditValue.ToString))
                                        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Precio"), CDbl(btnAplicarAutomatico.Tag))

                                        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Importe"), CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Cantidad")))
                                        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("PrecioSinItbis"), CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "PorcItbis"))))
                                        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Descuento"), CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))
                                        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Itbis"), (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "PorcItbis")))))
                                        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Cantidad")



                                        lblPrecioHistorico.Text = ""
                                        lblPrecioHistorico.Tag = ""
                                        lblDescripcionPrecioHistorico.Text = ""
                                        lblDescripcionPrecioHistorico.Tag = ""
                                        PictureBox1.Image = My.Resources.No_Image
                                        SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1

                                    End If

                                Else
                                    lblPrecioHistorico.ForeColor = Color.Red
                                    lblDescripcionPrecioHistorico.Text = AdvBandedGridView1.GetFocusedRowCellValue("Descripcion")
                                    lblDescripcionPrecioHistorico.Tag = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
                                    lblPrecioHistorico.Text = "El último precio dado a  " & txtNombre.Text & " (" & CDbl(Tabla.Rows(0).Item("UltimoPrecio")).ToString("C") & ") ofrecido en fecha " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & " ya excede el precio mínimo autorizado."
                                    lblPrecioHistorico.Tag = AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio")
                                    btnAplicarAutomatico.Tag = CDbl(Tabla.Rows(0).Item("PrecioMinimoDisponible"))

                                End If

                                SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Both

                            Else
                                SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1
                            End If

                            Tabla.Dispose()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RemovePreciosConsulted()
        Dim Ds As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDPrecios FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "' and PrecioArticulo.Nulo=0 order by contenido desc", ConLibregco)

        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "PrecioArticulo")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")


        For Each dt As DataRow In Tabla.Rows

            Dim iterateIndex As Integer = 0
            Dim newDataTable As DataTable = TablaPrecio.Copy

            For Each RT As DataRow In newDataTable.Rows
                If dt.Item("IDPrecios").ToString = RT.Item("IDPrecios").ToString Then
                    TablaPrecio.Rows.RemoveAt(iterateIndex)
                Else
                    iterateIndex += 1
                End If
            Next

            newDataTable.Dispose()

        Next

    End Sub


    Private Sub RemoveExistenciasConsulted()
        Dim Ds As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Existencia.IDExistencia FROM libregco.Existencia INNER JOIN Libregco.Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios Where PrecioArticulo.Nulo=0 and IDArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Existencia")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Existencia")


        For Each dt As DataRow In Tabla.Rows

            Dim iterateIndex As Integer = 0
            Dim newDataTable As DataTable = TablaExistencia.Copy

            For Each RT As DataRow In newDataTable.Rows
                If dt.Item("IDExistencia").ToString = RT.Item("IDExistencia").ToString Then
                    TablaExistencia.Rows.RemoveAt(iterateIndex)
                Else
                    iterateIndex += 1
                End If
            Next

            newDataTable.Dispose()

        Next

    End Sub



    Private Sub AgregarPrecios()
        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            RemovePreciosConsulted()

            Using myCommand As MySqlCommand = New MySqlCommand("SELECT PrecioArticulo.IDPrecios,Abreviatura,Medida.IDMedida,Medida.Medida,Medida.Fraccionamiento,PrecioArticulo.IDArticulo,PrecioArticulo.DescuentoMaximo,PrecioArticulo.Contenido FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "' and PrecioArticulo.Nulo=0 order by contenido desc", ConMixta)
                ConMixta.Open()

                Using myReader As MySqlDataReader = myCommand.ExecuteReader

                    TablaPrecio.Load(myReader, LoadOption.Upsert)

                    ConMixta.Close()

                End Using
            End Using
        End Using
        TablaPrecio.EndLoadData()

    End Sub


    Private Sub AgregarExistencias()
        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            RemoveExistenciasConsulted()

            Using myCommand As MySqlCommand = New MySqlCommand("SELECT Existencia.IDAlmacen,Sucursal.Sucursal,Almacen.Almacen,Existencia.Existencia,Medida.Medida,Existencia.IDPrecioArticulo,PrecioArticulo.IDArticulo,Existencia.IDExistencia FROM libregco.existencia INNER JOIN Libregco.Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal Where PrecioArticulo.Nulo=0 and IDArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "'", ConMixta)
                ConMixta.Open()

                Using myReader As MySqlDataReader = myCommand.ExecuteReader

                    TablaExistencia.Load(myReader, LoadOption.Upsert)

                    ConMixta.Close()

                End Using
            End Using
        End Using

        TablaExistencia.EndLoadData()
    End Sub

    Private Sub RepositoryItemTextEdit1Precio_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit1Precio.EditValueChanged
        Dim editor As DevExpress.XtraEditors.TextEdit = TryCast(sender, DevExpress.XtraEditors.TextEdit)

        If DTConfiguracion.Rows(211 - 1).Item("Value2Int") = 1 Then
            If CDbl(editor.EditValue) = 0 Then
                If GetPricesWithIDPrecio(cbxPreciosHeader.Properties.Items.Item(cbxPreciosHeader.Properties.Items.Count - 1), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")) = 0 Then
                    editor.EditValue = GetPricesWithIDPrecio("A", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision"))
                Else
                    editor.EditValue = GetPricesWithIDPrecio(cbxPreciosHeader.Properties.Items.Item(cbxPreciosHeader.Properties.Items.Count - 1), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision"))
                End If

                ToastNotificationsManager3.ShowNotification(ToastNotificationsManager3.Notifications(0))
                'MessageBox.Show("En estos momentos todo precio 0 está bloqueado a nivel de facturación.", "Precio no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
        End If

    End Sub

    Private Sub RepositoryItemLookUpEdit1Medida_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit1Medida.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        AdvBandedGridView1.SetFocusedRowCellValue("Fraccionamiento", CStr(editor.GetColumnValue("Fraccionamiento")))
        AdvBandedGridView1.SetFocusedRowCellValue("IDPrecio", CStr(editor.GetColumnValue("IDPrecios")))
        AdvBandedGridView1.SetFocusedRowCellValue("IDMedida", CStr(editor.GetColumnValue("IDMedida")))
        AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio(AdvBandedGridView1.GetFocusedRowCellValue("Nivel"), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
        AdvBandedGridView1.SetFocusedRowCellValue("IDMedida", CStr(editor.GetColumnValue("IDMedida")))

        'If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) <= 0 Then
        '    AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", 0)
        'Else
        '    AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", 1)
        'End If

        AdvBandedGridView1.SetFocusedRowCellValue("DescuentoMaximo", CStr(editor.GetColumnValue("DescuentoMaximo")))
        AdvBandedGridView1.SetFocusedRowCellValue("DescuentoPorc", 0)


        AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio(AdvBandedGridView1.GetFocusedRowCellValue("Nivel"), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
        AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
        AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
        AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
        AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

        If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
        Else
            AdvBandedGridView1.PostEditor()
            AdvBandedGridView1.UpdateCurrentRow()
        End If
    End Sub


    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try
            If e.Button.Tag = "Delete" Then
                If CStr(AdvBandedGridView1.GetFocusedRowCellValue("IDFactArt")).ToString = "" Then
                    AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                    AdvBandedGridView1.Focus()
                    AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
                    AdvBandedGridView1.ShowEditor()

                Else
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el producto de la transacción." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        'sqlQ = "Delete from cobrosadelantados_hijos Where IDCobrosAdelantados_hijo=(" + AdvBandedGridView1.GetFocusedRowCellValue("IDCobrosAdelantados_hijo").ToString + ")"
                        'GuardarDatos()
                        AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                    End If
                End If

                If TablaArticulos.Rows.Count = 0 Then
                    TablaPrecio.Rows.Clear()
                    TablaExistencia.Rows.Clear()
                End If

            End If


        Catch ex As Exception
            'AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
            'AdvBandedGridView1.Focus()
            'AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
            'AdvBandedGridView1.ShowEditor()
        End Try
    End Sub

    Private Sub RepositoryItemComboBox1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemComboBox1.EditValueChanged
        If CStr(CType(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue) = "A" Or CStr(CType(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue) = "B" Then
        Else
            AdvBandedGridView1.SetFocusedRowCellValue("DescuentoPorc", 0)
        End If

        AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio(CStr(CType(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))

        If DTConfiguracion.Rows(211 - 1).Item("Value2Int") = 1 Then
            If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) = 0 Then
                If GetPricesWithIDPrecio(cbxPreciosHeader.Properties.Items.Item(cbxPreciosHeader.Properties.Items.Count - 1), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")) = 0 Then
                    AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio("A", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                Else
                    AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio(cbxPreciosHeader.Properties.Items.Item(cbxPreciosHeader.Properties.Items.Count - 1), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                End If
                ToastNotificationsManager3.ShowNotification(ToastNotificationsManager3.Notifications(0))

                'MessageBox.Show("En estos momentos todo precio 0 está bloqueado a nivel de facturación.", "Precio no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If


        AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
        AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
        AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
        AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

        If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
        Else
            AdvBandedGridView1.PostEditor()
            AdvBandedGridView1.UpdateCurrentRow()
        End If

    End Sub

    Private Sub RepositoryItemSpinEdit2Descuento_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSpinEdit2Descuento.EditValueChanged
        AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
        AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue)) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
        AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue))
        AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
        If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
        Else
            AdvBandedGridView1.PostEditor()
            AdvBandedGridView1.UpdateCurrentRow()
        End If
    End Sub

    Private Sub RepositoryItemSpinEdit1Cant_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSpinEdit1Cant.EditValueChanged

    End Sub


    Private Sub AdvBandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanged
        'Try
        If e.Column.FieldName = "Busqueda" Then
            FlowSimilares.Controls.Clear()

            If AdvBandedGridView1.GetFocusedRowCellValue("Busqueda") = "" Then
                AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                SplitSimilares.Panel2Collapsed = True
            Else


                If CStr(e.Value).Substring(0, 1) = "-" Then
                    Dim newval As String = Replace(e.Value.ToString, CStr(e.Value).Substring(0, 1), "")
                    If IsNumeric(newval) Then
                        If AdvBandedGridView1.RowCount >= CDbl(newval) Then
                            AdvBandedGridView1.DeleteRow(CInt(newval) - 1)
                            SplitSimilares.Panel2Collapsed = True
                        End If
                    End If
                End If


                Dim Ds As New DataSet
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDArticulo,Descripcion,Referencia,ExistenciaTotal,Articulos.RutaFoto,NoPermitirCambiarPrecio,CobrarComision,PorcentajeComision,NoPagoTarjeta,IDTipoProducto,VecesVendido,VecesComprado,ExistenciaTotal,Itbis As PorcItbis,Articulos.IDDepartamento,Articulos.IDCategoria,Articulos.IDSubCategoria,Articulos.IDTipoProducto,Articulos.IDMarca,VenderCosto FROM Articulos INNER JOIN Libregco.TipoItbis On Articulos.IDItbis= TipoItbis.IDTipoItbis WHERE IDArticulo='" + e.Value.ToString + "' or Referencia='" + e.Value.ToString + "' or CodigoBarra='" + e.Value.ToString + "' and Articulos.Desactivar=0 ORDER BY Articulos.IDArticulo,Articulos.Referencia,Articulos.CodigoBarra", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Articulos")
                ConLibregco.Close()

                Dim Tabla As DataTable = Ds.Tables("Articulos")

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SplitSimilares.Panel2Collapsed = True
                    AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                    'GPExistencia.Visible = False
                    AdvBandedGridView1.Focus()
                    AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
                    AdvBandedGridView1.ShowEditor()
                Else
                    AdvBandedGridView1.SetFocusedRowCellValue("IDFactArt", "")
                    AdvBandedGridView1.SetFocusedRowCellValue("IDArticulo", Tabla.Rows(0).Item("IDArticulo"))
                    AdvBandedGridView1.SetFocusedRowCellValue("Descripcion", Tabla.Rows(0).Item("Descripcion"))
                    AdvBandedGridView1.SetFocusedRowCellValue("Referencia", Tabla.Rows(0).Item("Referencia"))
                    AdvBandedGridView1.SetFocusedRowCellValue("Existencia", Tabla.Rows(0).Item("ExistenciaTotal"))
                    AdvBandedGridView1.SetFocusedRowCellValue("PorcItbis", CDbl(Tabla.Rows(0).Item("PorcItbis")))
                    AdvBandedGridView1.SetFocusedRowCellValue("VenderCosto", CDbl(Tabla.Rows(0).Item("VenderCosto")))
                    AdvBandedGridView1.SetFocusedRowCellValue("Orden", TablaArticulos.Rows.Count)

                    If CInt(Tabla.Rows(0).Item("IDTipoProducto")) <> 2 Then
                        'Facturar sin inventario
                        If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
                            If Tabla.Rows(0).Item("IDArticulo") = 1 Then
                                'Permitir facturación sin inventario de artículo base No.01
                                If CInt(DTConfiguracion.Rows(129 - 1).Item("Value2Int")) = 0 Then
                                    AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", 0)
                                Else
                                    AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", 1)
                                End If

                            Else
                                If CDbl(Tabla.Rows(0).Item("ExistenciaTotal")) = 0 Then
                                    AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", 0)
                                Else
                                    If CDbl(Tabla.Rows(0).Item("ExistenciaTotal")) > 1 Then
                                        AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", 1)
                                    Else
                                        AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", CDbl(Tabla.Rows(0).Item("ExistenciaTotal")))
                                    End If
                                End If
                            End If
                        Else
                            AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", 1)
                        End If
                    Else
                        AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", 1)
                    End If

                    If cbxPreciosHeader.Properties.Items.Count > 0 Then
                        If cbxPreciosHeader.Properties.Items.Contains(txtNivelPrecio.Text) Then
                            cbxPreciosHeader.Text = txtNivelPrecio.Text
                        End If
                    End If


                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", cbxPreciosHeader.Text)
                    AdvBandedGridView1.SetFocusedRowCellValue("NoPermitirCambiarPrecio", Tabla.Rows(0).Item("NoPermitirCambiarPrecio"))
                    AdvBandedGridView1.SetFocusedRowCellValue("CobrarComision", Tabla.Rows(0).Item("CobrarComision"))
                    AdvBandedGridView1.SetFocusedRowCellValue("PorcentajeComision", Tabla.Rows(0).Item("PorcentajeComision"))
                    AdvBandedGridView1.SetFocusedRowCellValue("Hijo", 0)
                    AdvBandedGridView1.SetFocusedRowCellValue("IDAlmacen", lblIDAlmacen.Text)
                    AdvBandedGridView1.SetFocusedRowCellValue("DescuentoPorc", 0)
                    AdvBandedGridView1.SetFocusedRowCellValue("IDDepartamento", Tabla.Rows(0).Item("IDDepartamento"))
                    AdvBandedGridView1.SetFocusedRowCellValue("IDCategoria", Tabla.Rows(0).Item("IDCategoria"))
                    AdvBandedGridView1.SetFocusedRowCellValue("IDSubCategoria", Tabla.Rows(0).Item("IDSubCategoria"))
                    AdvBandedGridView1.SetFocusedRowCellValue("IDMarca", Tabla.Rows(0).Item("IDMarca"))
                    AdvBandedGridView1.SetFocusedRowCellValue("IDTipoProducto", Tabla.Rows(0).Item("IDTipoProducto"))

                    If TypeConnection.Text = 1 Then
                        If Tabla.Rows(0).Item("RutaFoto") = "" Then
                            AdvBandedGridView1.SetFocusedRowCellValue("Imagen", My.Resources.No_Image)
                            PictureBox1.Image = My.Resources.No_Image
                        Else
                            If chkPreviewImages.Checked Then
                                Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                                If ExistFile = True Then
                                    Dim wFile As System.IO.FileStream
                                    wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                    AdvBandedGridView1.SetFocusedRowCellValue("Imagen", ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(179 - 1).Item("Value2Int")))
                                    PictureBox1.Image = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(179 - 1).Item("Value2Int"))
                                    wFile.Close()
                                Else
                                    AdvBandedGridView1.SetFocusedRowCellValue("Imagen", My.Resources.No_Image)
                                    PictureBox1.Image = My.Resources.No_Image
                                End If
                            Else
                                AdvBandedGridView1.SetFocusedRowCellValue("Imagen", My.Resources.No_Image)
                                PictureBox1.Image = My.Resources.No_Image
                            End If

                        End If
                    Else
                        AdvBandedGridView1.SetFocusedRowCellValue("Imagen", My.Resources.No_Image)
                        PictureBox1.Image = My.Resources.No_Image
                    End If

                    AgregarPrecios()
                    AgregarExistencias()


                    Dim rows() As DataRow = TablaPrecio.Select("IDArticulo = '" + Tabla.Rows(0).Item("IDArticulo").ToString + "'")

                    If rows.Count = 0 Then
                        MessageBox.Show("El artículo no tiene precios ni medidas establecidas para realizar operaciones.")
                    Else
                        AdvBandedGridView1.SetFocusedRowCellValue("IDMedida", CInt(rows(0).Item("IDMedida")))
                        AdvBandedGridView1.SetFocusedRowCellValue("IDPrecio", rows(0).Item("IDPrecios"))
                        AdvBandedGridView1.SetFocusedRowCellValue("Fraccionamiento", rows(0).Item("Fraccionamiento"))
                        AdvBandedGridView1.SetFocusedRowCellValue("DescuentoMaximo", rows(0).Item("DescuentoMaximo"))
                        AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio(AdvBandedGridView1.GetFocusedRowCellValue("Nivel"), rows(0).Item("IDPrecios"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                        AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                        AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                        AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                        AdvBandedGridView1.SetFocusedRowCellValue("Itbis", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - CDbl(CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

                    End If

                    If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) > 0 Then
                        Dim rowsExistencia() As DataRow = TablaExistencia.Select("IDPrecioArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") + "' AND IDAlmacen='" + AdvBandedGridView1.GetFocusedRowCellValue("IDAlmacen") + "'")

                        If rowsExistencia.Count = 0 Then
                            MessageBox.Show("El artículo no tiene existencia establecidas en el almacén para realizar operaciones.")
                        Else
                            If CDbl(rowsExistencia(0).Item("Existencia")) = 0 Then
                                ToastNotificationsManager3.ShowNotification(ToastNotificationsManager3.Notifications(1))
                                Dim rowsBuscandoExistencia() As DataRow = TablaExistencia.Select("IDPrecioArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") + "' AND Existencia>'0'")

                                If rowsBuscandoExistencia.Count = 0 Then
                                Else
                                    AdvBandedGridView1.SetFocusedRowCellValue("IDAlmacen", rowsBuscandoExistencia(0).Item("IDAlmacen"))
                                End If
                            End If
                        End If

                    Else
                        'Facturar sin inventario
                        If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
                            ToastNotificationsManager3.ShowNotification(ToastNotificationsManager3.Notifications(2))
                        End If
                    End If

                    If CInt(DTConfiguracion.Rows(128 - 1).Item("Value2Int")) = 1 Then
                        If AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") = 1 Then
                            RepositoryItemMemoEdit1.ReadOnly = False
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = False
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = True
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = True
                            AdvBandedGridView1.ShowEditor()
                        Else
                            RepositoryItemMemoEdit1.ReadOnly = True
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = False
                        End If
                    Else
                        RepositoryItemMemoEdit1.ReadOnly = True
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = False
                    End If

                    If AdvBandedGridView1.GetFocusedRowCellValue("Descripcion").ToString.Contains("TOLA PERSONALIZABLE") Or AdvBandedGridView1.GetFocusedRowCellValue("Descripcion").ToString.Contains("Tola Personalizable") Or AdvBandedGridView1.GetFocusedRowCellValue("Descripcion").ToString.Contains("TOLA PERSONALIZADA") Or AdvBandedGridView1.GetFocusedRowCellValue("Descripcion").ToString.Contains("Tola Personalizada") Then
                        frm_calculo_tolas.ShowDialog(Me)
                    End If

                    BuscarVentas()

                    If DoSimilarities.IsBusy = True Then
                        DoSimilarities.CancelAsync()
                    Else
                        DoSimilarities.RunWorkerAsync()
                    End If
                End If


            End If

        ElseIf e.Column.FieldName = "Precio" Then
            If AdvBandedGridView1.FocusedColumn.FieldName = "Precio" Then
                'AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"),CbxMoneda))
                'AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                'AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - CDbl(CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                'AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                'AdvBandedGridView1.SetFocusedRowCellValue("Itbis", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))


                If AdvBandedGridView1.GetFocusedRowCellValue("VenderCosto") = 0 Then
                    'Controlar precios de venta por niveles 
                    If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                        'Facturar por debajo del costo
                        If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then

                            If CDbl(e.Value) < GetPricesWithIDPrecio(cbxPreciosHeader.Properties.Items.Item(cbxPreciosHeader.Properties.Items.Count - 1), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")) Then
                                MessageBox.Show("El precio colocado excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio("A", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                                AdvBandedGridView1.SetFocusedRowCellValue("Nivel", "A")
                                AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

                                If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                Else
                                    AdvBandedGridView1.PostEditor()
                                    AdvBandedGridView1.UpdateCurrentRow()
                                End If
                            Else
                                AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue))
                                AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

                                If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                Else
                                    AdvBandedGridView1.PostEditor()
                                    AdvBandedGridView1.UpdateCurrentRow()
                                End If
                            End If
                        End If

                    Else
                        'Facturar por debajo del costo
                        If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then
                            '  Controlar precios de venta por niveles 
                            If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                                If CDbl(e.Value) < GetPricesWithIDPrecio("D", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")) Then
                                    MessageBox.Show("El precio colocado excede al costo del producto.", "Costo excede al precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                    AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio("A", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", "A")
                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))


                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

                                    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                    Else
                                        AdvBandedGridView1.PostEditor()
                                        AdvBandedGridView1.UpdateCurrentRow()
                                    End If

                                Else
                                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

                                    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                    Else
                                        AdvBandedGridView1.PostEditor()
                                        AdvBandedGridView1.UpdateCurrentRow()
                                    End If
                                End If
                            Else
                                If CDbl(e.Value) < GetPricesWithIDPrecio("E", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")) Then
                                    MessageBox.Show("El precio colocado excede al costo del producto.", "Costo excede al precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                    AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio("A", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", "A")
                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

                                    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                    Else
                                        AdvBandedGridView1.PostEditor()
                                        AdvBandedGridView1.UpdateCurrentRow()
                                    End If
                                Else
                                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

                                    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                    Else
                                        AdvBandedGridView1.PostEditor()
                                        AdvBandedGridView1.UpdateCurrentRow()
                                    End If
                                End If
                            End If


                        Else
                            AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue))
                            AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                            AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                            AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                            AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                            If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                            Else
                                AdvBandedGridView1.PostEditor()
                                AdvBandedGridView1.UpdateCurrentRow()
                            End If
                        End If

                    End If

                Else







                    ''''''''''''''''''''''''''''Si se puede vender al costo


                    'Controlar precios de venta por niveles 
                    If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                        'Facturar por debajo del costo
                        If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then
                            If CDbl(e.Value) < GetPricesWithIDPrecio("F", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")) Then
                                MessageBox.Show("El precio colocado excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio("A", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                                AdvBandedGridView1.SetFocusedRowCellValue("Nivel", "A")
                                AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                                If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                Else
                                    AdvBandedGridView1.PostEditor()
                                    AdvBandedGridView1.UpdateCurrentRow()
                                End If
                            Else
                                AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue))
                                AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                                If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                Else
                                    AdvBandedGridView1.PostEditor()
                                    AdvBandedGridView1.UpdateCurrentRow()
                                End If
                            End If
                        End If

                    Else
                        'Facturar por debajo del costo
                        If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then
                            '  Controlar precios de venta por niveles 
                            If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                                If CDbl(e.Value) < GetPricesWithIDPrecio("D", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")) Then
                                    MessageBox.Show("El precio colocado excede al costo del producto.", "Costo excede al precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                    AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio("A", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", "A")
                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                                    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                    Else
                                        AdvBandedGridView1.PostEditor()
                                        AdvBandedGridView1.UpdateCurrentRow()
                                    End If
                                Else
                                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                                    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                    Else
                                        AdvBandedGridView1.PostEditor()
                                        AdvBandedGridView1.UpdateCurrentRow()
                                    End If
                                End If
                            Else
                                If CDbl(e.Value) < GetPricesWithIDPrecio("E", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")) Then
                                    MessageBox.Show("El precio colocado excede al costo del producto.", "Costo excede al precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                    AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio("A", AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", "A")
                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))

                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                                    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                    Else
                                        AdvBandedGridView1.PostEditor()
                                        AdvBandedGridView1.UpdateCurrentRow()
                                    End If
                                Else
                                    AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                                    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                                    Else
                                        AdvBandedGridView1.PostEditor()
                                        AdvBandedGridView1.UpdateCurrentRow()
                                    End If
                                End If
                            End If


                        Else
                            AdvBandedGridView1.SetFocusedRowCellValue("Nivel", GetPriceLevel(e.Value, AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue))
                            AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                            AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(e.Value) - (CDbl(e.Value) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                            AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                            AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                            If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                            Else
                                AdvBandedGridView1.PostEditor()
                                AdvBandedGridView1.UpdateCurrentRow()
                            End If
                        End If

                    End If
                End If

            End If


        ElseIf e.Column.FieldName = "DescuentoPorc" Then
            If AdvBandedGridView1.FocusedColumn.FieldName = "DescuentoPorc" Then
                AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

            End If



        ElseIf e.Column.FieldName = "Cantidad" Then
            If AdvBandedGridView1.FocusedColumn.FieldName = "Cantidad" Then

                Dim rows() As DataRow = TablaPrecio.Select("IDPrecios = '" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") + "'")
                'Si no es un servicio
                If CInt(AdvBandedGridView1.GetFocusedRowCellValue("IDTipoProducto")) <> 2 Then
                    'Facturar sin inventario
                    If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
                        'Permitir facturación sin inventario de artículo base No.01
                        If AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") = 1 Then
                            If CInt(DTConfiguracion.Rows(129 - 1).Item("Value2Int")) = 0 Then
                                If txtIDFactura.Text = "" Then
                                    If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) < CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")) * CDbl(rows(0).Item("Contenido"))) Then

                                        'MessageBox.Show("No se puede facturar el artículo [" & AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") & "] " & AdvBandedGridView1.GetFocusedRowCellValue("Descripcion") & ", ya que no tiene las existencias requeridas en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        ToastNotificationsManager3.ShowNotification(ToastNotificationsManager3.Notifications(2))

                                        If AdvBandedGridView1.GetFocusedRowCellValue("Fraccionamiento") = 1 Then
                                            AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) / CDbl(rows(0).Item("Contenido")))
                                        Else
                                            AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", TruncateDecimal(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) / CDbl(rows(0).Item("Contenido"))))
                                        End If
                                    End If
                                End If
                            End If

                        Else
                            If txtIDFactura.Text = "" Then
                                If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) < CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")) * CDbl(rows(0).Item("Contenido"))) Then
                                    'MessageBox.Show("No se puede facturar el artículo [" & AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") & "] " & AdvBandedGridView1.GetFocusedRowCellValue("Descripcion") & ", ya que no tiene las existencias requeridas en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                    ToastNotificationsManager3.ShowNotification(ToastNotificationsManager3.Notifications(2))


                                    If AdvBandedGridView1.GetFocusedRowCellValue("Fraccionamiento") = 1 Then
                                        AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) / CDbl(rows(0).Item("Contenido")))
                                    Else
                                        AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", TruncateDecimal(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) / CDbl(rows(0).Item("Contenido"))))
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"))))
                AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

            End If


        End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        'End Try
    End Sub

    Private Sub AdvBandedGridView1_ShownEditor(sender As Object, e As EventArgs) Handles AdvBandedGridView1.ShownEditor
        If AdvBandedGridView1.FocusedColumn.FieldName = "Busqueda" Then
            If AdvBandedGridView1.FocusedRowHandle >= 0 Then
                AdvBandedGridView1.HideEditor()
            End If

        ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "Descripcion" Then
            Dim obj As Object = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
            If obj Is Nothing Then
                AdvBandedGridView1.HideEditor()
            Else
                If CInt(DTConfiguracion.Rows(128 - 1).Item("Value2Int")) = 1 Then
                    If AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") = 1 Then
                        RepositoryItemMemoEdit1.ReadOnly = False
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = False
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = True
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = True
                        AdvBandedGridView1.ShowEditor()
                    Else
                        RepositoryItemMemoEdit1.ReadOnly = True
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = False
                    End If
                Else
                    RepositoryItemMemoEdit1.ReadOnly = True
                    AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
                    AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
                    AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = False
                End If
            End If

        ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "IDMedida" Then

            Try
                If TypeOf AdvBandedGridView1.ActiveEditor Is DevExpress.XtraEditors.LookUpEdit Then
                    Dim view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = TryCast(sender, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)

                    Dim obj As Object = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
                    If obj Is Nothing Then
                        AdvBandedGridView1.HideEditor()
                    Else
                        Dim edit As DevExpress.XtraEditors.LookUpEdit
                        Dim table As DataTable
                        Dim row As DataRow
                        edit = CType(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                        table = CType(edit.Properties.DataSource, DataTable)
                        clonePrecios = New DataView(table)
                        row = view.GetDataRow(view.FocusedRowHandle)
                        clonePrecios.RowFilter = "IDArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "'"
                        edit.Properties.DataSource = clonePrecios
                        AdvBandedGridView1.ShowEditor()


                    End If

                End If
            Catch ex As Exception

            End Try

        ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "IDAlmacen" Then
            Try
                If TypeOf AdvBandedGridView1.ActiveEditor Is DevExpress.XtraEditors.LookUpEdit Then
                    Dim view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = TryCast(sender, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)

                    Dim obj As Object = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
                    If obj Is Nothing Then
                        AdvBandedGridView1.HideEditor()
                    Else
                        Dim edit As DevExpress.XtraEditors.LookUpEdit
                        Dim table As DataTable
                        Dim row As DataRow
                        edit = CType(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                        table = CType(edit.Properties.DataSource, DataTable)
                        cloneExistencias = New DataView(table)
                        row = view.GetDataRow(view.FocusedRowHandle)
                        cloneExistencias.RowFilter = "IDPrecioArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio").ToString + "'"
                        edit.Properties.DataSource = cloneExistencias
                        AdvBandedGridView1.ShowEditor()


                    End If

                End If
            Catch ex As Exception

            End Try



        ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "Cantidad" Then
            Dim obj As Object = AdvBandedGridView1.GetFocusedRowCellValue("Fraccionamiento")
            If obj Is Nothing Then
            Else
                If obj.ToString = "1" Then
                    RepositoryItemSpinEdit1Cant.MinValue = 0.01

                    RepositoryItemSpinEdit1Cant.EditMask = "n2"
                    RepositoryItemSpinEdit1Cant.NullValuePrompt = 1
                    RepositoryItemSpinEdit1Cant.NullValuePromptShowForEmptyValue = 1
                    RepositoryItemSpinEdit1Cant.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                Else
                    RepositoryItemSpinEdit1Cant.MinValue = 1
                    'RepositoryItemSpinEdit1Cant.MaxValue = 999999
                    RepositoryItemSpinEdit1Cant.EditMask = "n0"
                    RepositoryItemSpinEdit1Cant.NullValuePrompt = 1
                    RepositoryItemSpinEdit1Cant.NullValuePromptShowForEmptyValue = 1
                    RepositoryItemSpinEdit1Cant.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                End If

                Dim rows() As DataRow = TablaPrecio.Select("IDPrecios='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") + "'")


                'Si no es un servicio
                If CInt(AdvBandedGridView1.GetFocusedRowCellValue("IDTipoProducto")) <> 2 Then
                    'Facturar sin inventario
                    If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
                        If AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") = 1 Then
                            'Permitir facturación sin inventario de artículo base No.01
                            If CInt(DTConfiguracion.Rows(129 - 1).Item("Value2Int")) = 0 Then
                                If txtIDFactura.Text = "" Then
                                    If AdvBandedGridView1.GetFocusedRowCellValue("Existencia") > 0 Then
                                        RepositoryItemSpinEdit1Cant.MaxValue = CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) / CDbl(rows(0).Item("Contenido"))
                                    Else
                                        RepositoryItemSpinEdit1Cant.MaxValue = 0
                                    End If
                                Else
                                    RepositoryItemSpinEdit1Cant.MaxValue = 999999
                                End If
                            Else
                                RepositoryItemSpinEdit1Cant.MaxValue = 999999
                            End If

                        Else
                            If txtIDFactura.Text = "" Then
                                If AdvBandedGridView1.GetFocusedRowCellValue("Existencia") > 0 Then
                                    RepositoryItemSpinEdit1Cant.MaxValue = CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) / CDbl(rows(0).Item("Contenido"))
                                Else
                                    RepositoryItemSpinEdit1Cant.MaxValue = 0
                                End If
                            Else
                                RepositoryItemSpinEdit1Cant.MaxValue = 999999
                            End If

                        End If
                    Else
                        RepositoryItemSpinEdit1Cant.MaxValue = 999999
                    End If
                Else
                    RepositoryItemSpinEdit1Cant.MaxValue = 999999
                End If


            End If

        ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "DescuentoPorc" Then
            Dim obj As Object = AdvBandedGridView1.GetFocusedRowCellValue("DescuentoMaximo")
            If obj Is Nothing Or IsDBNull(obj) Then
            Else
                If CDbl(obj) = 0 Then
                    RepositoryItemSpinEdit2Descuento.MaxValue = 0
                    RepositoryItemSpinEdit2Descuento.MinValue = 0
                    RepositoryItemSpinEdit2Descuento.Increment = 1
                    'AdvBandedGridView1.HideEditor()
                    RepositoryItemSpinEdit2Descuento.ReadOnly = True
                Else
                    If AdvBandedGridView1.GetFocusedRowCellValue("Nivel") = "A" Or AdvBandedGridView1.GetFocusedRowCellValue("Nivel") = "B" Then
                        RepositoryItemSpinEdit2Descuento.MaxValue = CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoMaximo"))
                        RepositoryItemSpinEdit2Descuento.MinValue = 0
                        RepositoryItemSpinEdit2Descuento.Increment = 1 / 100
                        RepositoryItemSpinEdit2Descuento.AllowMouseWheel = True
                        RepositoryItemSpinEdit2Descuento.ReadOnly = False
                        AdvBandedGridView1.ShowEditor()

                    Else
                        RepositoryItemSpinEdit2Descuento.MaxValue = 0
                        RepositoryItemSpinEdit2Descuento.MinValue = 0
                        RepositoryItemSpinEdit2Descuento.Increment = 1
                        RepositoryItemSpinEdit2Descuento.ReadOnly = False
                        'AdvBandedGridView1.HideEditor()
                    End If

                End If

            End If

        ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "Precio" Then
            Dim obj As Object = AdvBandedGridView1.GetFocusedRowCellValue("NoPermitirCambiarPrecio")
            If obj Is Nothing Or IsDBNull(obj) Then
            Else
                If AdvBandedGridView1.GetFocusedRowCellValue("NoPermitirCambiarPrecio") = 1 Then
                    RepositoryItemTextEdit1Precio.ReadOnly = True
                    Precio.OptionsColumn.AllowEdit = False
                    Precio.OptionsColumn.ReadOnly = True
                Else
                    RepositoryItemTextEdit1Precio.ReadOnly = False
                    Precio.OptionsColumn.AllowEdit = True
                    Precio.OptionsColumn.ReadOnly = False
                    AdvBandedGridView1.ShowEditor()
                End If
            End If
            'Si se puede modificar los precios directamente
            'Debug los contrairo bloquedo todo

            'Controlar Precios de venta por niveles 


        ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "Nivel" Then
            CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.ComboBoxEdit).Properties.Items.Clear()
            For Each st As String In cbxPreciosHeader.Properties.Items
                CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.ComboBoxEdit).Properties.Items.Add(st)
            Next
            AdvBandedGridView1.ShowEditor()
        End If
    End Sub



    Private Sub AdvBandedGridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles AdvBandedGridView1.FocusedColumnChanged
        Try
            Dim obj As Object = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
            If obj Is Nothing Then
                AdvBandedGridView1.Focus()
                AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
                AdvBandedGridView1.ShowEditor()
            Else
                If e.FocusedColumn.FieldName = "IDMedida" Then
                    Dim rows() As DataRow = TablaPrecio.Select("IDArticulo = '" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "'")

                    If rows.Count > 0 Then
                        If rows.Count = 1 Then
                            CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.LookUpEdit).ItemIndex = 0
                        Else
                            AdvBandedGridView1.ShowEditor()
                            CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.LookUpEdit).ShowPopup()
                        End If
                    End If


                ElseIf e.FocusedColumn.FieldName = "Nivel" Then
                    If cbxPreciosHeader.Properties.Items.Count = 1 Then
                        CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.ComboBoxEdit).Properties.Items.Item(cbxPreciosHeader.Properties.Items.Count - 1).ToString()
                    Else
                        AdvBandedGridView1.ShowEditor()
                        CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.ComboBoxEdit).ShowPopup()
                    End If

                ElseIf e.FocusedColumn.FieldName = "IDAlmacen" Then
                    Dim rows() As DataRow = TablaExistencia.Select("IDPrecioArticulo = '" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio").ToString + "'")

                    If rows.Count > 0 Then
                        If rows.Count = 1 Then
                            CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.LookUpEdit).ItemIndex = 0
                        Else
                            AdvBandedGridView1.ShowEditor()
                            CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.LookUpEdit).ShowPopup()
                        End If
                    End If

                ElseIf e.FocusedColumn.FieldName = "Descripcion" Then
                    Dim obja As Object = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
                    If obja Is Nothing Then
                        AdvBandedGridView1.HideEditor()
                    Else
                        If CInt(DTConfiguracion.Rows(128 - 1).Item("Value2Int")) = 1 Then
                            If AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") = 1 Then
                                RepositoryItemMemoEdit1.ReadOnly = False
                                AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = False
                                AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = True
                                AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = True
                                AdvBandedGridView1.ShowEditor()
                            Else
                                RepositoryItemMemoEdit1.ReadOnly = True
                                AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
                                AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
                                AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = False
                            End If
                        Else
                            RepositoryItemMemoEdit1.ReadOnly = True
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
                            AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = False
                        End If
                    End If

                    'ElseIf e.FocusedColumn.FieldName = "Botones" Then

                    '    If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                    '        AdvBandedGridView1.ShowEditor()
                    '        CType(AdvBandedGridView1.ActiveEditor, DevExpress.XtraEditors.ButtonEdit).Focus()
                    '    End If
                End If
            End If


        Catch ex As Exception

        End Try

    End Sub
    Private Function HasDuplicates(ByVal IDPrecio As String) As Boolean
        HasDuplicates = False

        For i As Integer = 0 To TablaArticulos.Rows.Count - 1
            If TablaArticulos.Rows(i).Item("IDPrecio") = IDPrecio Then
                Return True
            End If
        Next
    End Function
    Private Sub AdvBandedGridView1_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles AdvBandedGridView1.ValidateRow
        If AdvBandedGridView1.IsFocusedView = True Then
            If AdvBandedGridView1.IsNewItemRow(e.RowHandle) Then
                Dim obj As DataRowView = AdvBandedGridView1.GetRow(e.RowHandle)
                If IsDBNull(obj.Item("IDArticulo")) Then
                    e.ErrorText = "No se ha encontrado una producto válido para anexar al registro."
                    e.Valid = False
                Else
                    If IsNumeric(obj.Item("Cantidad")) Then
                        If CDbl(obj.Item("Cantidad")) > 0 Then
                            If IsDBNull(obj.Item("Precio")) Then
                                e.Valid = False
                            Else
                                If IsNumeric(obj.Item("Precio")) Then

                                    'Permitir duplicidad de articulos en facturación
                                    If CInt(DTConfiguracion.Rows(170 - 1).Item("Value2Int")) = 0 Then
                                        If HasDuplicates(AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio")) = True Then
                                            ToastNotificationsManager3.ShowNotification(ToastNotificationsManager3.Notifications(3))
                                            e.ErrorText = "Configuración: Duplicar productos en faturación" & vbNewLine & vbNewLine & "El artículo no se puede agregar más de una vez."
                                            e.Valid = False
                                            Exit Sub
                                        End If
                                    End If

                                    e.Valid = True

                                    'Facturar Sin Existencia en Inventario
                                    If DTConfiguracion.Rows(21 - 1).Item("Value2Int") = 0 Then

                                        Dim rows() As DataRow = TablaExistencia.Select("IDPrecioArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") + "' AND IDAlmacen='" + AdvBandedGridView1.GetFocusedRowCellValue("IDAlmacen") + "'")
                                        Dim CantidadPendiente As Double = AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")

                                        Dim RowContenido() As DataRow = TablaPrecio.Select("IDPrecios='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio").ToString + "'")

                                        If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")) <= CDbl(CDbl(rows(0).Item("Existencia")) / CDbl(RowContenido(0).Item("Contenido"))) Then
                                        Else
                                            If CDbl(rows(0).Item("Existencia")) = 0 Then
                                                Dim rowsAlmacenesconExist() As DataRow = TablaExistencia.Select("Existencia>'0' AND IDPrecioArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") + "' AND IDAlmacen<>'" + AdvBandedGridView1.GetFocusedRowCellValue("IDAlmacen") + "'")

                                                For Each rw As DataRow In rowsAlmacenesconExist
                                                    If CDbl(CDbl(rw.Item("Existencia")) / CDbl(RowContenido(0).Item("Contenido"))) >= CantidadPendiente Then
                                                        TablaArticulos.Rows.Add(AdvBandedGridView1.GetFocusedRowCellValue("Busqueda"), AdvBandedGridView1.GetFocusedRowCellValue("Imagen"), AdvBandedGridView1.GetFocusedRowCellValue("IDFactArt"), AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo"), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), AdvBandedGridView1.GetFocusedRowCellValue("IDMedida"), CantidadPendiente, AdvBandedGridView1.GetFocusedRowCellValue("Descripcion"), AdvBandedGridView1.GetFocusedRowCellValue("Referencia"), AdvBandedGridView1.GetFocusedRowCellValue("Precio"), AdvBandedGridView1.GetFocusedRowCellValue("PrecioSinItbis"), AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"), AdvBandedGridView1.GetFocusedRowCellValue("Descuento"), AdvBandedGridView1.GetFocusedRowCellValue("Itbis"), CantidadPendiente * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")), rowsAlmacenesconExist(0).Item("IDAlmacen").ToString, AdvBandedGridView1.GetFocusedRowCellValue("Nivel"), AdvBandedGridView1.GetFocusedRowCellValue("Hijo"), AdvBandedGridView1.GetFocusedRowCellValue("Fraccionamiento"), AdvBandedGridView1.GetFocusedRowCellValue("Existencia"), AdvBandedGridView1.GetFocusedRowCellValue("NoPermitirCambiarPrecio"), AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"), AdvBandedGridView1.GetFocusedRowCellValue("DescuentoMaximo"), AdvBandedGridView1.GetFocusedRowCellValue("IDDepartamento"), AdvBandedGridView1.GetFocusedRowCellValue("IDCategoria"), AdvBandedGridView1.GetFocusedRowCellValue("IDSubCategoria"), AdvBandedGridView1.GetFocusedRowCellValue("IDMarca"), AdvBandedGridView1.GetFocusedRowCellValue("IDTipoProducto"), AdvBandedGridView1.GetFocusedRowCellValue("VenderCosto"), TablaArticulos.Rows.Count)
                                                        Exit For

                                                    Else
                                                        TablaArticulos.Rows.Add(AdvBandedGridView1.GetFocusedRowCellValue("Busqueda"), AdvBandedGridView1.GetFocusedRowCellValue("Imagen"), AdvBandedGridView1.GetFocusedRowCellValue("IDFactArt"), AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo"), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), AdvBandedGridView1.GetFocusedRowCellValue("IDMedida"), CDbl(CDbl(rows(0).Item("Existencia")) / CDbl(RowContenido(0).Item("Contenido"))), AdvBandedGridView1.GetFocusedRowCellValue("Descripcion"), AdvBandedGridView1.GetFocusedRowCellValue("Referencia"), AdvBandedGridView1.GetFocusedRowCellValue("Precio"), AdvBandedGridView1.GetFocusedRowCellValue("PrecioSinItbis"), AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"), AdvBandedGridView1.GetFocusedRowCellValue("Descuento"), AdvBandedGridView1.GetFocusedRowCellValue("Itbis"), CDbl(rw.Item("Existencia")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")), rowsAlmacenesconExist(0).Item("IDAlmacen").ToString, AdvBandedGridView1.GetFocusedRowCellValue("Nivel"), AdvBandedGridView1.GetFocusedRowCellValue("Hijo"), AdvBandedGridView1.GetFocusedRowCellValue("Fraccionamiento"), AdvBandedGridView1.GetFocusedRowCellValue("Existencia"), AdvBandedGridView1.GetFocusedRowCellValue("NoPermitirCambiarPrecio"), AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"), AdvBandedGridView1.GetFocusedRowCellValue("DescuentoMaximo"), AdvBandedGridView1.GetFocusedRowCellValue("IDDepartamento"), AdvBandedGridView1.GetFocusedRowCellValue("IDCategoria"), AdvBandedGridView1.GetFocusedRowCellValue("IDSubCategoria"), AdvBandedGridView1.GetFocusedRowCellValue("IDMarca"), AdvBandedGridView1.GetFocusedRowCellValue("IDTipoProducto"), AdvBandedGridView1.GetFocusedRowCellValue("VenderCosto"), TablaArticulos.Rows.Count)
                                                        CantidadPendiente = CantidadPendiente - CDbl(CDbl(rows(0).Item("Existencia")) / CDbl(RowContenido(0).Item("Contenido")))

                                                        If CantidadPendiente = 0 Then
                                                            Exit For
                                                        End If
                                                    End If
                                                Next

                                            Else

                                                If CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Existencia")) / CDbl(RowContenido(0).Item("Contenido"))) >= CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")) Then
                                                    AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", CDbl(rows(0).Item("Existencia")))
                                                    AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(rows(0).Item("Existencia")))
                                                    AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                                                    AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                                                    AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))

                                                    CantidadPendiente = CantidadPendiente - CDbl(rows(0).Item("Existencia"))

                                                    Dim rowsAlmacenesconExist() As DataRow = TablaExistencia.Select("Existencia>'0' AND IDPrecioArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") + "' AND IDAlmacen<>'" + AdvBandedGridView1.GetFocusedRowCellValue("IDAlmacen") + "'")
                                                    For Each rw As DataRow In rowsAlmacenesconExist
                                                        If CDbl(rw.Item("Existencia")) >= CantidadPendiente Then
                                                            TablaArticulos.Rows.Add(AdvBandedGridView1.GetFocusedRowCellValue("Busqueda"), AdvBandedGridView1.GetFocusedRowCellValue("Imagen"), AdvBandedGridView1.GetFocusedRowCellValue("IDFactArt"), AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo"), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), AdvBandedGridView1.GetFocusedRowCellValue("IDMedida"), CantidadPendiente, AdvBandedGridView1.GetFocusedRowCellValue("Descripcion"), AdvBandedGridView1.GetFocusedRowCellValue("Referencia"), AdvBandedGridView1.GetFocusedRowCellValue("Precio"), AdvBandedGridView1.GetFocusedRowCellValue("PrecioSinItbis"), AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"), AdvBandedGridView1.GetFocusedRowCellValue("Descuento"), AdvBandedGridView1.GetFocusedRowCellValue("Itbis"), CantidadPendiente * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")), rowsAlmacenesconExist(0).Item("IDAlmacen").ToString, AdvBandedGridView1.GetFocusedRowCellValue("Nivel"), AdvBandedGridView1.GetFocusedRowCellValue("Hijo"), AdvBandedGridView1.GetFocusedRowCellValue("Fraccionamiento"), AdvBandedGridView1.GetFocusedRowCellValue("Existencia"), AdvBandedGridView1.GetFocusedRowCellValue("NoPermitirCambiarPrecio"), AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"), AdvBandedGridView1.GetFocusedRowCellValue("DescuentoMaximo"), AdvBandedGridView1.GetFocusedRowCellValue("IDDepartamento"), AdvBandedGridView1.GetFocusedRowCellValue("IDCategoria"), AdvBandedGridView1.GetFocusedRowCellValue("IDSubCategoria"), AdvBandedGridView1.GetFocusedRowCellValue("IDMarca"), AdvBandedGridView1.GetFocusedRowCellValue("IDTipoProducto"), AdvBandedGridView1.GetFocusedRowCellValue("VenderCosto"), TablaArticulos.Rows.Count)
                                                            Exit For

                                                        Else
                                                            TablaArticulos.Rows.Add(AdvBandedGridView1.GetFocusedRowCellValue("Busqueda"), AdvBandedGridView1.GetFocusedRowCellValue("Imagen"), AdvBandedGridView1.GetFocusedRowCellValue("IDFactArt"), AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo"), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), AdvBandedGridView1.GetFocusedRowCellValue("IDMedida"), CDbl(rw.Item("Existencia")), AdvBandedGridView1.GetFocusedRowCellValue("Descripcion"), AdvBandedGridView1.GetFocusedRowCellValue("Referencia"), AdvBandedGridView1.GetFocusedRowCellValue("Precio"), AdvBandedGridView1.GetFocusedRowCellValue("PrecioSinItbis"), AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"), AdvBandedGridView1.GetFocusedRowCellValue("Descuento"), AdvBandedGridView1.GetFocusedRowCellValue("Itbis"), CDbl(rw.Item("Existencia")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")), rowsAlmacenesconExist(0).Item("IDAlmacen").ToString, AdvBandedGridView1.GetFocusedRowCellValue("Nivel"), AdvBandedGridView1.GetFocusedRowCellValue("Hijo"), AdvBandedGridView1.GetFocusedRowCellValue("Fraccionamiento"), AdvBandedGridView1.GetFocusedRowCellValue("Existencia"), AdvBandedGridView1.GetFocusedRowCellValue("NoPermitirCambiarPrecio"), AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis"), AdvBandedGridView1.GetFocusedRowCellValue("DescuentoMaximo"), AdvBandedGridView1.GetFocusedRowCellValue("IDDepartamento"), AdvBandedGridView1.GetFocusedRowCellValue("IDCategoria"), AdvBandedGridView1.GetFocusedRowCellValue("IDSubCategoria"), AdvBandedGridView1.GetFocusedRowCellValue("IDMarca"), AdvBandedGridView1.GetFocusedRowCellValue("IDTipoProducto"), AdvBandedGridView1.GetFocusedRowCellValue("VenderCosto"), TablaArticulos.Rows.Count)
                                                            CantidadPendiente = CantidadPendiente - CDbl(rw.Item("Existencia"))

                                                            If CantidadPendiente = 0 Then
                                                                Exit For
                                                            End If
                                                        End If
                                                    Next
                                                End If

                                            End If


                                        End If
                                    End If

                                    SplitSimilares.Panel2Collapsed = True

                                    If DoProbabilidades.IsBusy Then
                                        DoProbabilidades.CancelAsync()
                                    Else
                                        DoProbabilidades.RunWorkerAsync(AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo"))
                                    End If

                                    SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1
                                    lblPrecioHistorico.Text = ""
                                    lblPrecioHistorico.Tag = ""
                                    lblDescripcionPrecioHistorico.Text = ""
                                    lblDescripcionPrecioHistorico.Tag = ""
                                    PictureBox1.Image = My.Resources.No_Image


                                    'GPExistencia.Visible = False
                                Else
                                    e.Valid = False
                                End If
                            End If



                        Else
                            e.ErrorText = "No se ha específicado una cantidad válida para anexar el registro."
                            e.Valid = False
                        End If
                    End If
                End If
            End If
        Else
            e.Valid = False
            e.ErrorText = "Se encuentra un artículo preseleccionado."
        End If

    End Sub
    Private Sub GridControl1_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControl1.ProcessGridKey
        Dim view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = TryCast((TryCast(sender, DevExpress.XtraGrid.GridControl)).FocusedView, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)

        If e.KeyData = Keys.Down OrElse e.KeyData = Keys.Up Then
            If view.ActiveEditor IsNot Nothing AndAlso view.ActiveEditor.[GetType]() = GetType(DevExpress.XtraEditors.SpinEdit) Then
                Dim edit As DevExpress.XtraEditors.SpinEdit = (TryCast(view.ActiveEditor, DevExpress.XtraEditors.SpinEdit))
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

    Private Sub AdvBandedGridView1_RowCountChanged(sender As Object, e As EventArgs) Handles AdvBandedGridView1.RowCountChanged
        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)

        If AdvBandedGridView1.RowCount > 0 Then
            cbxMoneda.Enabled = False

            If AdvBandedGridView1.RowCount > 1 Then
                AdvBandedGridView1.OptionsView.ShowFooter = True
            Else
                AdvBandedGridView1.OptionsView.ShowFooter = False
            End If
        Else
            cbxMoneda.Enabled = True

            TablaProbabilidades.Rows.Clear()
            FlowProbabilidades.Controls.Clear()
            SplitProbabilidades.Panel2Collapsed = True
        End If

        Me.Text = txtNombre.Text & " (" & CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C") & ")"
    End Sub

    Private Sub AdvBandedGridView1_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles AdvBandedGridView1.RowDeleted
        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    End Sub


    Private Sub AdvBandedGridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AdvBandedGridView1.RowCellStyle
        Try
            If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Else

                Dim obj As DataRowView = AdvBandedGridView1.GetRow(e.RowHandle)
                If IsDBNull(obj.Item("IDArticulo")) Then
                Else
                    'Marcar facturas vencidas
                    Dim currentView As GridView = TryCast(sender, GridView)

                    If e.Column.FieldName = "Existencia" Then
                        If CDbl(currentView.GetRowCellValue(e.RowHandle, "Existencia")) <= 0 Then
                            e.Appearance.ForeColor = Color.Red
                            e.Appearance.Font = New Font("Tahoma", 8, FontStyle.Regular Or FontStyle.Underline)
                        Else
                            e.Appearance.ForeColor = Color.Black
                            e.Appearance.Font = New Font("Tahoma", 8, FontStyle.Regular)
                        End If

                    ElseIf e.Column.FieldName = "Precio" Then
                        If CInt(currentView.GetRowCellValue(e.RowHandle, "NoPermitirCambiarPrecio")) = 1 Then
                            e.Appearance.ForeColor = Color.DarkGray
                            e.Appearance.BackColor = Color.LightGray
                        End If

                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ActualizarFontSize()
        For i = 0 To AdvBandedGridView1.Columns.Count - 1
            AdvBandedGridView1.Columns(i).AppearanceCell.Font = New Font("Tahoma", DTConfiguracion.Rows(87 - 1).Item("Value2Int"))
        Next

    End Sub


    Private Sub AdvBandedGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AdvBandedGridView1.KeyPress
        Dim view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        Dim s As String = "'[]\/*+=:;.,{}¡!¿?><_~!@#$%^&()"
        If view.FocusedColumn.FieldName = "Busqueda" And s.IndexOf(e.KeyChar) >= 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub GridControl1_EditorKeyPress(sender As Object, e As KeyPressEventArgs) Handles GridControl1.EditorKeyPress
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        AdvBandedGridView1_KeyPress(grid.FocusedView, e)
    End Sub

    Private Sub RepositoryItemLookUpEditAlmacen_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEditAlmacen.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If CDbl(editor.GetColumnValue("Existencia")) > 0 Then
        Else
            ToastNotificationsManager3.ShowNotification(ToastNotificationsManager3.Notifications(1))


            'MessageBox.Show("El artículo no tiene existencia establecidas en el almacén para realizar operaciones.")

            Dim rowsBuscandoExistencia() As DataRow = TablaExistencia.Select("IDPrecioArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio") + "' AND Existencia>'0'")

            If rowsBuscandoExistencia.Count = 0 Then
            Else
                AdvBandedGridView1.SetFocusedRowCellValue("IDAlmacen", rowsBuscandoExistencia(0).Item("IDAlmacen"))
            End If
        End If
        If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
        Else
            AdvBandedGridView1.PostEditor()
            AdvBandedGridView1.UpdateCurrentRow()
        End If
    End Sub

    Public Sub SetUpGrid(ByVal grid As DevExpress.XtraGrid.GridControl, ByVal table As DataTable)
        Dim view As GridView = TryCast(grid.MainView, GridView)
        grid.DataSource = table
        'view.OptionsBehavior.Editable = False

        HandleBehaviorDragDropEvents()
    End Sub

    Public Sub HandleBehaviorDragDropEvents()
        Dim gridControlBehavior As DragDrop.DragDropBehavior = BehaviorManager1.GetBehavior(Of DragDrop.DragDropBehavior)(Me.AdvBandedGridView1)
        AddHandler gridControlBehavior.DragDrop, AddressOf Behavior_DragDrop
        AddHandler gridControlBehavior.DragOver, AddressOf Behavior_DragOver
    End Sub
    Private Sub Behavior_DragOver(ByVal sender As Object, ByVal e As DragDrop.DragOverEventArgs)
        Dim args As DragOverGridEventArgs = DragOverGridEventArgs.GetDragOverGridEventArgs(e)
        e.InsertType = args.InsertType
        e.InsertIndicatorLocation = args.InsertIndicatorLocation
        e.Action = args.Action
        Cursor.Current = args.Cursor
        args.Handled = True
    End Sub

    Private Sub Behavior_DragDrop(ByVal sender As Object, ByVal e As DevExpress.Utils.DragDrop.DragDropEventArgs)
        Dim targetGrid As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = TryCast(e.Target, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        Dim sourceGrid As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = TryCast(e.Source, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        If e.Action = DevExpress.Utils.DragDrop.DragDropActions.None OrElse targetGrid IsNot sourceGrid Then
            Return
        End If
        Dim sourceTable As DataTable = TryCast(sourceGrid.GridControl.DataSource, DataTable)

        Dim hitPoint As Point = targetGrid.GridControl.PointToClient(Cursor.Position)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = targetGrid.CalcHitInfo(hitPoint)

        Dim sourceHandles() As Integer = e.GetData(Of Integer())()

        Dim targetRowHandle As Integer = hitInfo.RowHandle
        Dim targetRowIndex As Integer = targetGrid.GetDataSourceRowIndex(targetRowHandle)

        Dim draggedRows As New List(Of DataRow)()
        For Each sourceHandle As Integer In sourceHandles
            Dim oldRowIndex As Integer = sourceGrid.GetDataSourceRowIndex(sourceHandle)
            Dim oldRow As DataRow = sourceTable.Rows(oldRowIndex)
            draggedRows.Add(oldRow)
        Next sourceHandle

        Dim newRowIndex As Integer

        Select Case e.InsertType
            Case DevExpress.Utils.DragDrop.InsertType.Before
                newRowIndex = If(targetRowIndex > sourceHandles(sourceHandles.Length - 1), targetRowIndex - 1, targetRowIndex)
                For i As Integer = draggedRows.Count - 1 To 0 Step -1
                    Dim oldRow As DataRow = draggedRows(i)
                    Dim newRow As DataRow = sourceTable.NewRow()
                    newRow.ItemArray = oldRow.ItemArray
                    sourceTable.Rows.Remove(oldRow)
                    sourceTable.Rows.InsertAt(newRow, newRowIndex)
                Next i
            Case InsertType.After
                newRowIndex = If(targetRowIndex < sourceHandles(0), targetRowIndex + 1, targetRowIndex)
                For i As Integer = 0 To draggedRows.Count - 1
                    Dim oldRow As DataRow = draggedRows(i)
                    Dim newRow As DataRow = sourceTable.NewRow()
                    newRow.ItemArray = oldRow.ItemArray
                    sourceTable.Rows.Remove(oldRow)
                    sourceTable.Rows.InsertAt(newRow, newRowIndex)
                Next i
            Case Else
                newRowIndex = -1
        End Select
        Dim insertedIndex As Integer = targetGrid.GetRowHandle(newRowIndex)
        targetGrid.FocusedRowHandle = insertedIndex
        targetGrid.SelectRow(targetGrid.FocusedRowHandle)
    End Sub

    Private Sub AdvBandedGridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles AdvBandedGridView1.RowCellClick
        If AdvBandedGridView1.FocusedColumn.FieldName = "Descripcion" Then
            Dim obj As Object = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
            If obj Is Nothing Then
                AdvBandedGridView1.HideEditor()
            Else
                If CInt(DTConfiguracion.Rows(128 - 1).Item("Value2Int")) = 1 Then
                    If AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") = 1 Then
                        RepositoryItemMemoEdit1.ReadOnly = False
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = False
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = True
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = True
                        AdvBandedGridView1.ShowEditor()
                    Else
                        RepositoryItemMemoEdit1.ReadOnly = True
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
                        AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = False
                    End If
                Else
                    RepositoryItemMemoEdit1.ReadOnly = True
                    AdvBandedGridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
                    AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
                    AdvBandedGridView1.Columns("Descripcion").OptionsColumn.AllowFocus = False
                End If
            End If

        ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "IDArticulo" Then

            If frm_mant_articulos.Visible = True Then
                frm_mant_articulos.Close()
            End If

            frm_mant_articulos.Show(Me)
            frm_mant_articulos.txtIDProducto.Text = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString
            frm_mant_articulos.FillAllDatafromID()

        End If
    End Sub

    Private Sub RepositoryItemButtonEdit2Busqued_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit2Busqued.ButtonClick
        If AdvBandedGridView1.FocusedColumn.FieldName = "Busqueda" And AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            AdvBandedGridView1.Focus()
            AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
            AdvBandedGridView1.ShowEditor()

            VerificacionTipoPago()
            'frm_buscar_mant_articulos.ShowDialog(Me)

            Dim F As New frm_buscar_mant_articulos
            F.ShowDialog(Me)


            AdvBandedGridView1.Focus()
            AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Cantidad")
            AdvBandedGridView1.ShowEditor()
        Else
            AdvBandedGridView1.Focus()
            AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
            AdvBandedGridView1.ShowEditor()
        End If
    End Sub

    Private Sub frm_prefacturacion_new_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    End Sub

    Private Sub frm_prefacturacion_new_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    End Sub

    Private Sub HabilitarControles()
        GridControl1.Enabled = True
        btnBuscarCliente.Enabled = True
        Hora.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        GridControl1.Enabled = False
        btnBuscarCliente.Enabled = False
        Hora.Enabled = False
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

    Sub RefrescarTabla(ByVal IDPrefactura As String)
        Try
            TablaArticulos.Clear()

            Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                Using myCommand As MySqlCommand = New MySqlCommand("Select prefacturaarticulos.IDArticulo AS Busqueda,IDPreFactArt as IDFactArt,PrefacturaArticulos.IDArticulo,IDPrecio,PrefacturaArticulos.IDMedida,Cantidad,prefacturaarticulos.Descripcion,Articulos.Referencia,Round(PrefacturaArticulos.PrecioUnitario+PrefacturaArticulos.Descuento+PrefacturaArticulos.Itbis,4) as Precio,PrecioUnitario as PrecioSinItbis,(PrefacturaArticulos.Descuento/Round(PrefacturaArticulos.PrecioUnitario+PrefacturaArticulos.Descuento+PrefacturaArticulos.Itbis,4)) as DescuentoPorc,PrefacturaArticulos.Descuento,PrefacturaArticulos.Itbis,PrefacturaArticulos.Importe,PrefacturaArticulos.IDAlmacen,NivelPrecioArticulo as Nivel,PrefacturaArticulos.Hijo,Fraccionamiento,(Select Existencia from Libregco.Existencia Where Existencia.IDPrecioArticulo=PrefacturaArticulos.IDPrecio and Existencia.IDAlmacen=PrefacturaArticulos.IDAlmacen) as Existencia,NoPermitirCambiarPrecio,NoPagoTarjeta,IDTipoProducto,TipoItbis.Itbis as PorcItbis,PrecioArticulo.DescuentoMaximo,Articulos.IDDepartamento,Articulos.IDCategoria,Articulos.IDSubCategoria,Articulos.IDMarca,CobrarComision,PorcentajeComision,VenderCosto,PrefacturaArticulos.Orden from Libregco.prefacturaarticulos INNER JOIN Libregco.Articulos on PreFacturaArticulos.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Libregco.PrecioArticulo on PrefacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrefacturaArticulos.IDMedida=Medida.IDMedida WHERE IDPreFactura='" + IDPrefactura + "' ORDER BY PrefacturaArticulos.Orden ASC", ConMixta)
                    ConMixta.Open()

                    Using myReader As MySqlDataReader = myCommand.ExecuteReader

                        TablaArticulos.Load(myReader, LoadOption.Upsert)

                        ConMixta.Close()

                    End Using
                End Using
            End Using

            TablaArticulos.EndLoadData()


            'Visualizando imagenes
            If TypeConnection.Text = 1 Then
                If chkPreviewImages.Checked = True Then
                    ConLibregco.Open()

                    For Each rw As DataRow In TablaArticulos.Rows
                        cmd = New MySqlCommand("SELECT RutaFoto FROM libregco.Articulos Where IDArticulo='" + rw.Item("IDArticulo").ToString + "'", ConLibregco)
                        Dim Ruta As String = Convert.ToString(cmd.ExecuteScalar())

                        If Ruta <> "" Then
                            Dim ExistFile As Boolean = System.IO.File.Exists(Ruta)
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Ruta, FileMode.Open, FileAccess.Read)
                                rw.Item("Imagen") = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(179 - 1).Item("Value2Int"))
                                wFile.Close()
                            End If
                        End If
                    Next
                End If

                ConLibregco.Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

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

                If AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                    If AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo") <> "" Then
                        Dim Ds As New DataSet
                        ConSimilares.Open()
                        cmd = New MySqlCommand("Select IDSubCategoria from Libregco.Articulos where IDArticulo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "'", ConSimilares)
                        Dim IDSubCategoria As String = Convert.ToString(cmd.ExecuteScalar())

                        cmd = New MySqlCommand("SELECT Articulos.IDArticulo,Articulos.Descripcion,Articulos.Referencia,Articulos.Promocion,PrecioArticulo.PrecioContado,Precio3,ExistenciaTotal,Marca.Marca,Articulos.RutaFoto,CategoriaFilePath,SubCategoriaFilePath,(select count(FacturaArticulos.Cantidad) from" & SysName.Text & "FacturaArticulos where Articulos.IDArticulo=FacturaArticulos.IDArticulo) AS Cantidad FROM Libregco.Articulos INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Libregco.SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubcategoria INNER JOIN Libregco.Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo WHERE Articulos.IDSubCategoria='" + IDSubCategoria + "' and Articulos.IDArticulo<>'" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "'" & ExistenciaSimilares & " Order by Cantidad desc LIMIT 5", ConSimilares)
                        Adaptador = New MySqlDataAdapter(cmd)
                        Adaptador.Fill(Ds, "Articulos")
                        ConSimilares.Close()

                        TablaSimilares = Ds.Tables("Articulos")
                    End If
                End If

            Else
                TablaSimilares.Rows.Clear()
                FlowSimilares.Controls.Clear()
                SplitSimilares.Panel2Collapsed = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DoSimilarities_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles DoSimilarities.RunWorkerCompleted
        Try
            If chkMostrarSimilares.Checked Then
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


                Else
                    SplitSimilares.Panel2Collapsed = True
                End If

            Else
                TablaSimilares.Rows.Clear()
                FlowSimilares.Controls.Clear()
                SplitSimilares.Panel2Collapsed = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DoProbabilidades_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles DoProbabilidades.DoWork
        Try
            If chkMostrarRelacionados.Checked = True Then
                ListadoProbVendidos.Clear()
                Dim Ds As New DataSet
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
            Else
                TablaProbabilidades.Rows.Clear()
                FlowProbabilidades.Controls.Clear()
                SplitProbabilidades.Panel2Collapsed = True
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

    Private Function ProductinDgv(ByVal IDProduct As Integer) As Boolean
        Dim ValueAcquired As Boolean = False
        For Each rw As DataRow In TablaArticulos.Rows
            If CInt(rw.Item("IDArticulo")) = IDProduct Then
                ValueAcquired = True
                Exit For
            Else
                ValueAcquired = False
            End If
        Next


        Return ValueAcquired
    End Function

    Private Sub DoProbabilidades_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles DoProbabilidades.RunWorkerCompleted
        Try
            If TablaProbabilidades.Rows.Count > 0 Then
                TabControl1.SelectedIndex = 0
                Dim ImagePic As Image
                For Each dt As DataRow In TablaProbabilidades.Rows
                    If Not ListadoProbVendidos.Contains(dt.Item("IDArticulo")) Then
                        ListadoProbVendidos.Add(dt.Item("IDArticulo"))
                        If ProductinDgv(dt.Item("IDArticulo").ToString) = False Then
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

        Catch ex As Exception

        End Try

    End Sub



    Private Sub frm_prefacturacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
            If frm_inicio.SplashScreenManager1.IsSplashFormVisible Then
                frm_inicio.SplashScreenManager1.CloseWaitForm()
            End If


            btnControlTipoPago.PerformClick()
        End If

    End Sub


    Private Sub ConsultaDeCotizaciToolStripMenuItem_Click(sender As Object, e As EventArgs)
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

    Private Sub txtNombre_Enter(sender As Object, e As EventArgs) Handles txtNombre.Enter
        txtNombre.SelectAll()
    End Sub


    'Private Sub AdvBandedGridView1_LostFocus(sender As Object, e As EventArgs) Handles AdvBandedGridView1.LostFocus
    '    AdvBandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None
    '    gridBand4.Visible = False
    '    ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    'End Sub

    'Private Sub AdvBandedGridView1_GotFocus(sender As Object, e As EventArgs) Handles AdvBandedGridView1.GotFocus
    '    AdvBandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
    '    gridBand4.Visible = True

    '    If AdvBandedGridView1.Columns.Count > 0 Then
    '        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    '    End If

    'End Sub

    'Private Sub AdvBandedGridView1_MouseEnter(sender As Object, e As EventArgs) Handles AdvBandedGridView1.MouseEnter
    '    If AdvBandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None Then
    '        AdvBandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
    '        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    '    End If

    '    If gridBand4.Visible = False Then
    '        gridBand4.Visible = True
    '        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    '    End If

    'End Sub

    Private Sub AdvBandedGridView1_InvalidRowException(sender As Object, e As XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles AdvBandedGridView1.InvalidRowException
        If AdvBandedGridView1.IsFocusedView = False Then
            e.ExceptionMode = XtraEditors.Controls.ExceptionMode.Ignore
            'TablaSimilares.Rows.Clear()
            'SplitSimilares.Panel2Collapsed = True
        End If
        'Suppress displaying the error message box
    End Sub

    Private Sub AdvBandedGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles AdvBandedGridView1.KeyDown
        If AdvBandedGridView1.RowCount > 0 Then
            If e.KeyCode = Keys.Delete Then
                If CStr(AdvBandedGridView1.GetFocusedRowCellValue("IDFactArt")).ToString = "" Then
                    AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                    AdvBandedGridView1.Focus()
                    AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
                    AdvBandedGridView1.ShowEditor()

                Else
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el producto de la transacción." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        'sqlQ = "Delete from cobrosadelantados_hijos Where IDCobrosAdelantados_hijo=(" + AdvBandedGridView1.GetFocusedRowCellValue("IDCobrosAdelantados_hijo").ToString + ")"
                        'GuardarDatos()
                        AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Me.Text = txtNombre.Text & " (" & CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C") & ")"
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDFactura.Text <> "" Then
            Dim F As New frm_impresiones_directas
            F.Show(Me)
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnBuscarCliente.ItemClick
        SplitContainer1.Panel1Collapsed = False
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

    Private Sub GridControl1_Resize(sender As Object, e As EventArgs) Handles GridControl1.Resize
        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    End Sub

    Private Sub chkPreviewImages_CheckedChanged(sender As Object, e As XtraBars.ItemClickEventArgs) Handles chkPreviewImages.CheckedChanged
        gridBand3.Visible = chkPreviewImages.Checked
        If chkPreviewImages.Checked Then
            Descripcion.RowCount = 2
        Else
            Descripcion.RowCount = 1
        End If

        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    End Sub


    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs) Handles ConvertirACotizaciónToolStripMenuItem.ItemClick
        If frm_cotizacion.Visible = True Then
            frm_cotizacion.Close()
        End If


        Dim f As New frm_cotizacion

        f.Show(Me)

        For i = 0 To AdvBandedGridView1.RowCount - 1
            f.dgvArticulos.Rows.Add("", "", AdvBandedGridView1.GetRowCellValue(i, "IDPrecio").ToString, AdvBandedGridView1.GetRowCellValue(i, "IDMedida").ToString, AdvBandedGridView1.GetRowCellValue(i, "IDArticulo").ToString, AdvBandedGridView1.GetRowCellValue(i, "Cantidad").ToString, AdvBandedGridView1.GetRowCellDisplayText(i, "IDMedida").ToString, AdvBandedGridView1.GetRowCellValue(i, "Descripcion").ToString, CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")).ToString("C"), CDbl(AdvBandedGridView1.GetRowCellValue(i, "PrecioSinItbis")).ToString("C"), CDbl(AdvBandedGridView1.GetRowCellValue(i, "Descuento")).ToString("C"), CDbl(AdvBandedGridView1.GetRowCellValue(i, "Itbis")).ToString("C"), CDbl(AdvBandedGridView1.GetRowCellValue(i, "Importe")).ToString("C"), AdvBandedGridView1.GetRowCellValue(i, "IDAlmacen").ToString, AdvBandedGridView1.GetRowCellValue(i, "Nivel").ToString, AdvBandedGridView1.GetRowCellValue(i, "Fraccionamiento").ToString)

        Next

        f.SumTotales()
    End Sub

    Private Sub txtSecondID_TextChanged(sender As Object, e As EventArgs) Handles txtSecondID.TextChanged
        If txtSecondID.Text <> "" Then
            txtSecondID.BackColor = Color.DodgerBlue
            txtSecondID.ForeColor = Color.White
        Else
            txtSecondID.BackColor = Color.FromArgb(227, 228, 232)
            txtSecondID.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BarEditItem3_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem3.EditValueChanged
        For i = 0 To AdvBandedGridView1.Columns.Count - 1
            AdvBandedGridView1.Columns(i).AppearanceCell.Font = New Font("Tahoma", BarEditItem3.EditValue)
        Next

    End Sub

    Private Sub DuplicarPrefacturaciónToolStripMenuItem_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles DuplicarPrefacturaciónToolStripMenuItem.ItemClick
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
        ElseIf AdvBandedGridView1.RowCount = 0 Then
            MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            'btnBuscarArticulo.Focus()
            Exit Sub
        ElseIf DTEmpleado.Rows(0).Item("IDSucursal").ToString() = "" Then
            MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Permisos(1) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea duplicar la prefactura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Duplicar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            Dim Frm_prefacturadetalles As New frm_prefacturacion_detalles
            'Pasando parametros a detalles
            SumTotales()
            Frm_prefacturadetalles.txtIDCliente.Text = txtIDCliente.Text
            Frm_prefacturadetalles.txtNombre.Text = txtNombre.Text
            Frm_prefacturadetalles.txtIDCondicion.Text = txtIDCondicion.Text
            Frm_prefacturadetalles.txtCondicion.Text = txtCondicion.Text
            Frm_prefacturadetalles.txtIDCondicion.Tag = txtCondicion.Tag
            Frm_prefacturadetalles.txtIDNcf.Text = lblIDTipoNCF.Text
            Frm_prefacturadetalles.txtTipoNcf.Text = TipoNCF
            Frm_prefacturadetalles.txtOrden.Text = txtOrden.Text

            Frm_prefacturadetalles.txtDireccion.Text = DireccionCliente
            Frm_prefacturadetalles.txtTelefono.Text = TelefonoCliente
            Frm_prefacturadetalles.txtRNC.Text = RNCliente

            If lblIDTipoNCF.Text = 1 Then
                Frm_prefacturadetalles.rdbCreditoFiscal.Checked = True
            ElseIf lblIDTipoNCF.Text = 2 Then
                Frm_prefacturadetalles.rdbConsumidorFin.Checked = True
            ElseIf lblIDTipoNCF.Text = 8 Then
                Frm_prefacturadetalles.rdbRegimenEsp.Checked = True
            ElseIf lblIDTipoNCF.Text = 9 Then
                Frm_prefacturadetalles.rdbGubernamental.Checked = True
            End If

            Frm_prefacturadetalles.txtNeto.Text = CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C")
            Frm_prefacturadetalles.txtNombre.Focus()
            Frm_prefacturadetalles.txtNombre.SelectAll()

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
                cmd = New MySqlCommand("INSERT INTO Libregco_Main.Prefactura (IDEquipo,IDTipoDocumento,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDVendedor,IDUsuario,Fecha,Hora,TotalNeto,Observacion,NoOrden,Cierre,Usando,TipoPago,Nulo,IDMoneda) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',53,'" + frm_prefacturacion_detalles.txtIDCliente.Text + "','" + frm_prefacturacion_detalles.txtNombre.Text + "','" + frm_prefacturacion_detalles.txtRNC.Text + "','" + frm_prefacturacion_detalles.txtDireccion.Text + "','" + frm_prefacturacion_detalles.txtTelefono.Text + "','" + frm_prefacturacion_detalles.txtIDCondicion.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + frm_prefacturacion_detalles.txtIDNcf.Text + "','" + frm_prefacturacion_detalles.txtIDVendedor.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',CURDATE(),CURRENT_TIME(),'" + CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString + "','" + frm_prefacturacion_detalles.txtObservacion.Text + "','" + frm_prefacturacion_detalles.txtOrden.Text + "',0,0,'" + btnControlTipoPago.Tag.ToString + "',0,'" + cbxMoneda.EditValue.ToString + "')", ConMixta)
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

                For i = 0 To AdvBandedGridView1.RowCount - 1
                    cmd = New MySqlCommand("INSERT INTO Libregco_Main.PrefacturaArticulos (IDPreFactura,IDPrecio,IDArticulo,IDMedida,Medida,Cantidad,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo) VALUES ('" + txtIDFactura.Text + "', '" + AdvBandedGridView1.GetRowCellValue(i, "IDPrecio").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDArticulo").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDMedida").ToString + "','" + AdvBandedGridView1.GetRowCellDisplayText(i, "IDMedida").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Cantidad").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Descripcion").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "PrecioSinItbis").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Descuento").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Itbis").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Importe").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDAlmacen").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Nivel").ToString + "')", ConMixta)
                    cmd.ExecuteNonQuery()
                Next

                ConMixta.Close()

                ToastNotificationsManager2.ShowNotification(ToastNotificationsManager2.Notifications(2))
            Else
                ConMixta.Open()
                cmd = New MySqlCommand("INSERT INTO Libregco.Prefactura (IDEquipo,IDTipoDocumento,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDVendedor,IDUsuario,Fecha,Hora,TotalNeto,Observacion,NoOrden,Cierre,Usando,TipoPago,Nulo,IDMoneda) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',53,'" + frm_prefacturacion_detalles.txtIDCliente.Text + "','" + frm_prefacturacion_detalles.txtNombre.Text + "','" + frm_prefacturacion_detalles.txtRNC.Text + "','" + frm_prefacturacion_detalles.txtDireccion.Text + "','" + frm_prefacturacion_detalles.txtTelefono.Text + "','" + frm_prefacturacion_detalles.txtIDCondicion.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + frm_prefacturacion_detalles.txtIDNcf.Text + "','" + frm_prefacturacion_detalles.txtIDVendedor.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',CURDATE(),CURRENT_TIME(),'" + CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString + "','" + frm_prefacturacion_detalles.txtObservacion.Text + "','" + frm_prefacturacion_detalles.txtOrden.Text + "',0,0,'" + btnControlTipoPago.Tag.ToString + "',0,'" + cbxMoneda.EditValue.ToString + "')", ConMixta)
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

                For i = 0 To AdvBandedGridView1.RowCount - 1
                    cmd = New MySqlCommand("INSERT INTO Libregco.PrefacturaArticulos (IDPreFactura,IDPrecio,IDArticulo,IDMedida,Medida,Cantidad,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo) VALUES ('" + txtIDFactura.Text + "', '" + AdvBandedGridView1.GetRowCellValue(i, "IDPrecio").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDArticulo").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDMedida").ToString + "','" + AdvBandedGridView1.GetRowCellDisplayText(i, "IDMedida").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Cantidad").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Descripcion").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "PrecioSinItbis").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Descuento").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Itbis").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Importe").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDAlmacen").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Nivel").ToString + "')", ConMixta)
                    cmd.ExecuteNonQuery()
                Next

                ConMixta.Close()

                ToastNotificationsManager2.ShowNotification(ToastNotificationsManager2.Notifications(2))
            End If



        End If
    End Sub

    Private Sub ConsultaDeCotizaciToolStripMenuItem_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles ConsultaDeCotizaciToolStripMenuItem.ItemClick
        Dim f As New frm_consulta_cotizacion

        f.ShowDialog(Me)
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        ' Check whether the GridControl can be previewed. 
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
        Else
            gridBand4.Visible = False
            gridBand5.Visible = False
            AdvBandedGridView1.ShowPrintPreview()
            gridBand4.Visible = True
            gridBand5.Visible = True
        End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Portable Documento Format (*.pdf)|*.pdf"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            AdvBandedGridView1.ExportToPdf(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Archivos de Excel (*.xls)|*.xls"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            AdvBandedGridView1.ExportToXls(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub FlowProbabilidades_ControlRemoved(sender As Object, e As ControlEventArgs) Handles FlowProbabilidades.ControlRemoved
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
    End Sub

    Private Sub SplitContainer1_VisibleChanged(sender As Object, e As EventArgs) Handles SplitContainer1.VisibleChanged
        ResetHeaderComboBoxEditLocation(AdvBandedGridView1.Columns("Nivel").ColIndex, -1)
    End Sub

    Private Sub RibbonControl1_MouseEnter(sender As Object, e As EventArgs) Handles RibbonControl1.MouseEnter
        SplitContainer1.Panel1Collapsed = False
    End Sub

    Private Sub chkMostrarRelacionados_CheckedChanged(sender As Object, e As XtraBars.ItemClickEventArgs) Handles chkMostrarRelacionados.CheckedChanged
        If chkMostrarRelacionados.Checked = False Then
            TablaProbabilidades.Rows.Clear()
            FlowProbabilidades.Controls.Clear()
            SplitProbabilidades.Panel2Collapsed = True
        End If
    End Sub

    Private Sub chkMostrarSimilares_CheckedChanged(sender As Object, e As XtraBars.ItemClickEventArgs) Handles chkMostrarSimilares.CheckedChanged
        If chkMostrarSimilares.Checked = False Then
            TablaSimilares.Rows.Clear()
            FlowSimilares.Controls.Clear()
            SplitSimilares.Panel2Collapsed = True
        End If

    End Sub
    Private Sub RepositoryItemSpinEdit1Cant_ValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSpinEdit1Cant.ValueChanged
        AdvBandedGridView1.SetFocusedRowCellValue("Precio", GetPricesWithIDPrecio(AdvBandedGridView1.GetFocusedRowCellValue("Nivel"), AdvBandedGridView1.GetFocusedRowCellValue("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetFocusedRowCellValue("CobrarComision"), AdvBandedGridView1.GetFocusedRowCellValue("PorcentajeComision")))
        AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(CType(sender, DevExpress.XtraEditors.SpinEdit).Value))
        AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"))) / (1 + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
        AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
        AdvBandedGridView1.SetFocusedRowCellValue("Itbis", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))
        If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
        Else
            AdvBandedGridView1.PostEditor()
            AdvBandedGridView1.UpdateCurrentRow()
        End If
    End Sub

    Private Sub cbxPreciosHeader_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPreciosHeader.SelectedIndexChanged
        For Each dt As DataRow In TablaArticulos.Rows
            dt.Item("Nivel") = cbxPreciosHeader.EditValue
            If cbxPreciosHeader.EditValue = "A" Or cbxPreciosHeader.EditValue = "B" Then
            Else
                dt.Item("DescuentoPorc") = 0
            End If
            dt.Item("Precio") = GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))
            dt.Item("PrecioSinItbis") = CDbl(CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) - (CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) * CDbl(dt.Item("DescuentoPorc")))) / (1 + CDbl(dt.Item("PorcItbis")))
            dt.Item("Importe") = CDbl(CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) - (CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) * CDbl(dt.Item("DescuentoPorc")))) * CDbl(dt.Item("Cantidad"))
            dt.Item("Descuento") = CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) * CDbl(dt.Item("DescuentoPorc"))
            dt.Item("Itbis") = (CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) - (CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) * CDbl(dt.Item("DescuentoPorc")))) - ((CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) - (CDbl(GetPricesWithIDPrecio(cbxPreciosHeader.EditValue, dt.Item("IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, dt.Item("CobrarComision"), dt.Item("PorcentajeComision"))) * CDbl(dt.Item("DescuentoPorc")))) / (1 + CDbl(dt.Item("PorcItbis"))))

        Next
    End Sub

    Private Sub AdvBandedGridView1_GotFocus(sender As Object, e As EventArgs) Handles AdvBandedGridView1.GotFocus
        If txtIDCliente.Text = "1" Then
            If txtNombre.Text = "CONTADO" Then
                SplitContainer1.Panel1Collapsed = True
            End If
        End If
    End Sub

    Private Sub btnAplicarAutomatico_Click(sender As Object, e As EventArgs) Handles btnAplicarAutomatico.Click
        AdvBandedGridView1.Focus()
        AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
        AdvBandedGridView1.ShowEditor()
        AdvBandedGridView1.AddNewRow()
        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Busqueda"), lblDescripcionPrecioHistorico.Tag.ToString)


        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Nivel"), GetPriceLevel(CDbl(btnAplicarAutomatico.Tag), lblPrecioHistorico .Tag.ToString, cbxMoneda.EditValue.ToString))
        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Precio"), CDbl(btnAplicarAutomatico.Tag))

        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Importe"), CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Cantidad")))
        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("PrecioSinItbis"), CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "PorcItbis"))))
        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Descuento"), CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))
        AdvBandedGridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, AdvBandedGridView1.Columns("Itbis"), (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "PorcItbis")))))
        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Cantidad")



        lblPrecioHistorico.Text = ""
        lblPrecioHistorico.Tag = ""
        lblDescripcionPrecioHistorico.Text = ""
        lblDescripcionPrecioHistorico.Tag = ""
        PictureBox1.Image = My.Resources.No_Image
        SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1

    End Sub

    Private Sub RibbonControl1_Click(sender As Object, e As EventArgs) Handles RibbonControl1.Click

    End Sub

    Private Sub MantenimientoDeArtículosToolStripMenuItem_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles MantenimientoDeArtículosToolStripMenuItem.ItemClick
        If frm_mant_articulos.Visible = True Then
            frm_mant_articulos.Close()
        End If

        frm_mant_articulos.Show(Me)

        If txtIDCliente.Text <> "" Then
            If txtIDCliente.Text <> 1 Then
                frm_mant_articulos.SplitContainer1.Panel1Collapsed = False
                frm_mant_articulos.lblHistorialCliente.Text = "  " & txtNombre.Text.ToUpper
            End If
        End If

    End Sub

    Private Sub btnControlTipoPago_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnControlTipoPago.ItemClick
        AdvBandedGridView1.Focus()
        AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
        AdvBandedGridView1.ShowEditor()

        Dim f As New frm_especificar_tipopagos
        f.ShowDialog(Me)


        If AdvBandedGridView1.RowCount > 0 Then
            If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
                If btnControlTipoPago.Tag = 2 Then
                    For i = 0 To AdvBandedGridView1.RowCount - 1
                        If AdvBandedGridView1.GetRowCellValue(i, "Nivel") = "C" Or AdvBandedGridView1.GetRowCellValue(i, "Nivel") = "D" Then
                            MessageBox.Show("Se ha específicado algunos descuentos en precios no válidos para el tipo de pago seleccionado." & vbNewLine & vbNewLine & "Se ha ajustado el precio para el artículo: " & vbNewLine & vbNewLine & AdvBandedGridView1.GetRowCellValue(i, "Descripcion") & ".", "Descuento ajustado a método de pago", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            AdvBandedGridView1.SetRowCellValue(i, "Nivel", "A")
                            AdvBandedGridView1.SetRowCellValue(i, "Precio", GetPricesWithIDPrecio("A", AdvBandedGridView1.GetRowCellValue(i, "IDPrecio"), cbxMoneda.EditValue, btnControlTipoPago.Tag, AdvBandedGridView1.GetRowCellValue(i, "CobrarComision"), AdvBandedGridView1.GetRowCellValue(i, "PorcentajeComision")))

                            AdvBandedGridView1.SetRowCellValue(i, "Importe", CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(i, "DescuentoPorc")))) * CDbl(AdvBandedGridView1.GetRowCellValue(i, "Cantidad")))
                            AdvBandedGridView1.SetRowCellValue(i, "PrecioSinItbis", CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(i, "DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetRowCellValue(i, "PorcItbis"))))
                            AdvBandedGridView1.SetRowCellValue(i, "Descuento", CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(i, "DescuentoPorc")))
                            AdvBandedGridView1.SetRowCellValue(i, "Itbis", (CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(i, "DescuentoPorc")))) - ((CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) - (CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) * CDbl(AdvBandedGridView1.GetRowCellValue(i, "DescuentoPorc")))) / (1 + CDbl(AdvBandedGridView1.GetRowCellValue(i, "PorcItbis")))))

                            SumTotales()
                        End If
                    Next
                End If
            End If
        End If

    End Sub


    Private Sub BarButtonItem6_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        If AdvBandedGridView1.FocusedColumn.FieldName = "Busqueda" And AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            AdvBandedGridView1.Focus()
            AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
            AdvBandedGridView1.ShowEditor()

            VerificacionTipoPago()

            Dim F As New frm_buscar_mant_articulos
            F.ShowDialog(Me)

            'frm_buscar_mant_articulos.ShowDialog(Me)
        Else
            AdvBandedGridView1.Focus()
            AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Busqueda")
            AdvBandedGridView1.ShowEditor()
        End If
    End Sub


    Private Sub BarButtonItem5_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnBuscar.ItemClick
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim F As New frm_buscar_prefactura

        F.ShowDialog(Me)

    End Sub

    Private Sub InsertArticulos()

        Con.Open()

        For i = 0 To AdvBandedGridView1.RowCount - 1
            If CStr(AdvBandedGridView1.GetRowCellValue(i, "IDFactArt")).ToString = "" Then
                sqlQ = "INSERT INTO PrefacturaArticulos (IDPreFactura,IDPrecio,IDArticulo,IDMedida,Medida,Cantidad,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo) VALUES ('" + txtIDFactura.Text + "', '" + AdvBandedGridView1.GetRowCellValue(i, "IDPrecio").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDArticulo").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDMedida").ToString + "','" + AdvBandedGridView1.GetRowCellDisplayText(i, "IDMedida").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Cantidad").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Descripcion").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "PrecioSinItbis").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Descuento").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Itbis").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Importe").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDAlmacen").ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "Nivel").ToString + "')"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select IDPrefactArt from PrefacturaArticulos where IDPrefactArt=(Select Max(IDPrefactArt) from PrefacturaArticulos)", Con)
                AdvBandedGridView1.SetRowCellValue(i, "IDFactArt", Convert.ToString(cmd.ExecuteScalar()))

            Else
                sqlQ = "UPDATE PreFacturaArticulos SET IDPreFactura='" + txtIDFactura.Text + "',IDPrecio='" + AdvBandedGridView1.GetRowCellValue(i, "IDPrecio").ToString + "',IDArticulo='" + AdvBandedGridView1.GetRowCellValue(i, "IDArticulo").ToString + "',IDMedida='" + AdvBandedGridView1.GetRowCellValue(i, "IDMedida").ToString + "',Medida='" + AdvBandedGridView1.GetRowCellDisplayText(i, "IDMedida").ToString + "',Cantidad='" + AdvBandedGridView1.GetRowCellValue(i, "Cantidad").ToString + "',Descripcion='" + AdvBandedGridView1.GetRowCellValue(i, "Descripcion").ToString + "',PrecioUnitario='" + AdvBandedGridView1.GetRowCellValue(i, "PrecioSinItbis").ToString + "',Descuento='" + AdvBandedGridView1.GetRowCellValue(i, "Descuento").ToString + "',Itbis='" + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Itbis").ToString).ToString + "',Importe='" + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Importe").ToString).ToString + "',IDAlmacen='" + AdvBandedGridView1.GetRowCellValue(i, "IDAlmacen").ToString + "',NivelPrecioArticulo='" + AdvBandedGridView1.GetRowCellValue(i, "Nivel").ToString + "' Where IDPreFactArt='" + AdvBandedGridView1.GetRowCellValue(i, "IDFactArt").ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If
        Next


        Con.Close()

    End Sub

    Private Sub btnGuardarC_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnGuardarC.ItemClick
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
        ElseIf TablaArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf DTEmpleado.Rows(0).Item("IDSucursal").ToString() = "" Then
            MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If


        For Each Rw As DataRow In TablaArticulos.Rows
            'Verificando almacenes vacios
            If CStr(Rw.Item("IDAlmacen")) = "" Then
                MessageBox.Show("Se ha detectado que no hay un almacén establecido en artículo " & Rw.Item("Descripcion").ToString & "de la prefactura.", "Almacén no definido", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CInt(Rw.Item("Fraccionamiento")) = 0 Then
                If CDbl(Rw.Item("Cantidad")) <> TruncateDecimal(CDbl(Rw.Item("Cantidad"))) Then
                    Rw.Item("Cantidad") = 1
                    Rw.Item("Importe") = CDbl(CDbl(Rw.Item("Cantidad")) * CDbl(Rw.Item("Precio"))).ToString("C4")

                    MessageBox.Show("Se encontró un error en la cantidad del artículo " & Rw.Item("Descripcion") & " y se ha modificado." & vbNewLine & vbNewLine & "Favor verificar la cantidad incluída del artículo.", "Cantidad modificada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If
        Next

        '''        'Verificando niveles de precios
        If IDGrupo_Cliente <> "4" Then
            If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                ConLibregco.Open()
                For i = 0 To AdvBandedGridView1.RowCount - 1
                    If CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) < GetPricesWithIDPrecio("D", AdvBandedGridView1.GetRowCellValue(i, "IDPrecio").ToString, cbxMoneda.EditValue.ToString) Then
                        ConLibregco.Close()
                        MessageBox.Show("El precio colocado en el artículo " & AdvBandedGridView1.GetRowCellValue(i, "Descripcion").ToString & " excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AdvBandedGridView1.Focus()
                        AdvBandedGridView1.FocusedRowHandle = i
                        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Precio")
                        Exit Sub
                    End If
                Next
                ConLibregco.Close()
            Else
                ConLibregco.Open()
                For i = 0 To AdvBandedGridView1.RowCount - 1
                    If CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) < GetPricesWithIDPrecio("E", AdvBandedGridView1.GetRowCellValue(i, "IDPrecio").ToString, cbxMoneda.EditValue.ToString) Then
                        ConLibregco.Close()
                        MessageBox.Show("El precio colocado en el artículo " & AdvBandedGridView1.GetRowCellValue(i, "Descripcion").ToString & " excede al costo del producto.", "Costo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AdvBandedGridView1.Focus()
                        AdvBandedGridView1.FocusedRowHandle = i
                        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Precio")
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
                For i = 0 To AdvBandedGridView1.RowCount - 1
                    If CDbl(AdvBandedGridView1.GetRowCellValue(i, "Precio")) < GetPricesWithIDPrecio("E", AdvBandedGridView1.GetRowCellValue(i, "IDPrecio").ToString, cbxMoneda.EditValue.ToString) Then
                        ConLibregco.Close()
                        MessageBox.Show("El precio colocado en el artículo " & AdvBandedGridView1.GetRowCellValue(i, "Descripcion").ToString & " excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AdvBandedGridView1.Focus()
                        AdvBandedGridView1.FocusedRowHandle = i
                        AdvBandedGridView1.FocusedColumn = AdvBandedGridView1.Columns("Precio")
                        Exit Sub
                    End If
                Next
                ConLibregco.Close()
            End If
        End If

        'Verificando existencias
        If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")) = 0 Then
            ConLibregco.Open()
            For Each row As DataRow In TablaArticulos.Rows
                cmd = New MySqlCommand("SELECT IDTipoProducto FROM Articulos WHERE Articulos.IDArticulo= '" + row.Item("IDArticulo").ToString() + "'", ConLibregco)
                If Convert.ToDouble(cmd.ExecuteScalar()) <> 2 Then
                    cmd = New MySqlCommand("SELECT ExistenciaTotal FROM Articulos WHERE Articulos.IDArticulo= '" + row.Item("IDArticulo").ToString() + "'", ConLibregco)
                    Dim Existencia As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    If CDbl(Existencia) < CDbl(row.Item("Existencia")) Then
                        ConLibregco.Close()
                        MessageBox.Show("No se puede facturar el artículo [" & row.Item("IDArticulo").ToString() & "] " & row.Item("Descripcion").ToString() & ", ya que no tiene las existencias requeridas en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            SumTotales()

            Dim Frm_prefacturadetalles As New frm_prefacturacion_detalles

            Frm_prefacturadetalles.txtIDCliente.Text = txtIDCliente.Text
            Frm_prefacturadetalles.txtNombre.Text = txtNombre.Text
            Frm_prefacturadetalles.txtIDCondicion.Text = txtIDCondicion.Text
            Frm_prefacturadetalles.txtCondicion.Text = txtCondicion.Text
            Frm_prefacturadetalles.txtIDCondicion.Tag = txtCondicion.Tag
            Frm_prefacturadetalles.txtIDNcf.Text = lblIDTipoNCF.Text
            Frm_prefacturadetalles.txtTipoNcf.Text = TipoNCF
            Frm_prefacturadetalles.txtOrden.Text = txtOrden.Text
            Frm_prefacturadetalles.txtDireccion.Text = DireccionCliente
            Frm_prefacturadetalles.txtTelefono.Text = TelefonoCliente
            Frm_prefacturadetalles.txtRNC.Text = RNCliente

            If lblIDTipoNCF.Text = 1 Then
                Frm_prefacturadetalles.rdbCreditoFiscal.Checked = True
            ElseIf lblIDTipoNCF.Text = 2 Then
                Frm_prefacturadetalles.rdbConsumidorFin.Checked = True
            ElseIf lblIDTipoNCF.Text = 8 Then
                Frm_prefacturadetalles.rdbRegimenEsp.Checked = True
            ElseIf lblIDTipoNCF.Text = 9 Then
                Frm_prefacturadetalles.rdbGubernamental.Checked = True
            End If

            Frm_prefacturadetalles.txtNeto.Text = CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C")
            Frm_prefacturadetalles.txtNombre.Focus()
            Frm_prefacturadetalles.txtNombre.SelectAll()

            If Frm_prefacturadetalles.Visible = True Then
                Frm_prefacturadetalles.Close()
            End If

            Frm_prefacturadetalles.ShowDialog(Me)

            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            If txtIDCondicion.Text <> 1 Then
                If CheckRequiredFieldsofCustomers(txtIDCliente.Text) = False Then
                    Exit Sub
                End If
            End If

            sqlQ = "INSERT INTO Prefactura (IDEquipo,IDTipoDocumento,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDVendedor,IDUsuario,Fecha,Hora,TotalNeto,Observacion,NoOrden,Cierre,Usando,TipoPago,Nulo,IDMoneda) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',53,'" + Frm_prefacturadetalles.txtIDCliente.Text + "','" + Frm_prefacturadetalles.txtNombre.Text + "','" + Frm_prefacturadetalles.txtRNC.Text + "','" + Frm_prefacturadetalles.txtDireccion.Text + "','" + Frm_prefacturadetalles.txtTelefono.Text + "','" + Frm_prefacturadetalles.txtIDCondicion.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + Frm_prefacturadetalles.txtIDNcf.Text + "','" + Frm_prefacturadetalles.txtIDVendedor.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',CURDATE(),CURRENT_TIME(),'" + CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString + "','" + Frm_prefacturadetalles.txtObservacion.Text + "','" + Frm_prefacturadetalles.txtOrden.Text + "',0,0,'" + btnControlTipoPago.Tag.ToString + "',0,'" + cbxMoneda.EditValue.ToString + "')"
            lblCierre.Text = 0
            GuardarDatos()
            UltPreFactura()
            InsertArticulos()
            SetSecondID()

            ToastNotificationsManager2.Notifications(0).Body = "La prefactura " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
            ToastNotificationsManager2.ShowNotification(ToastNotificationsManager2.Notifications(0))

            'DeshabilitarControles()
            Hora.Enabled = False
        Else

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la prefactura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If Result = MsgBoxResult.Yes Then
            SumTotales()

            'Pasando parametros a detalles
            Dim Frm_prefacturadetalles As New frm_prefacturacion_detalles

            Frm_prefacturadetalles.txtIDCliente.Text = txtIDCliente.Text
            Frm_prefacturadetalles.txtNombre.Text = txtNombre.Text
            Frm_prefacturadetalles.txtIDCondicion.Text = txtIDCondicion.Text
            Frm_prefacturadetalles.txtCondicion.Text = txtCondicion.Text
            Frm_prefacturadetalles.txtIDNcf.Text = lblIDTipoNCF.Text
            Frm_prefacturadetalles.txtTipoNcf.Text = TipoNCF
            Frm_prefacturadetalles.txtNeto.Text = CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C")
            Frm_prefacturadetalles.txtOrden.Text = txtOrden.Text

            Frm_prefacturadetalles.txtDireccion.Text = DireccionCliente
            Frm_prefacturadetalles.txtTelefono.Text = TelefonoCliente
            Frm_prefacturadetalles.txtRNC.Text = RNCliente

            If lblIDTipoNCF.Text = 1 Then
                Frm_prefacturadetalles.rdbCreditoFiscal.Checked = True
            ElseIf lblIDTipoNCF.Text = 2 Then
                Frm_prefacturadetalles.rdbConsumidorFin.Checked = True
            ElseIf lblIDTipoNCF.Text = 8 Then
                Frm_prefacturadetalles.rdbRegimenEsp.Checked = True
            ElseIf lblIDTipoNCF.Text = 9 Then
                Frm_prefacturadetalles.rdbGubernamental.Checked = True
            End If

            Frm_prefacturadetalles.txtNeto.Text = CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C")
            Frm_prefacturadetalles.txtNombre.Focus()
            Frm_prefacturadetalles.txtNombre.SelectAll()

            Frm_prefacturadetalles.ShowDialog(Me)

            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            sqlQ = "UPDATE PreFactura SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDTipoDocumento=53,IDCliente='" + Frm_prefacturadetalles.txtIDCliente.Text + "',NombreFactura='" + Frm_prefacturadetalles.txtNombre.Text + "',IdentificacionFactura='" + Frm_prefacturadetalles.txtRNC.Text + "',DireccionFactura='" + Frm_prefacturadetalles.txtDireccion.Text + "',TelefonosFactura='" + Frm_prefacturadetalles.txtTelefono.Text + "',IDCondicion='" + Frm_prefacturadetalles.txtIDCondicion.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "',IDComprobanteFiscal='" + Frm_prefacturadetalles.txtIDNcf.Text + "',IDVendedor='" + Frm_prefacturadetalles.txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha=CURDATE(),Hora=CURRENT_TIME(),TotalNeto='" + CDbl(AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString + "',Observacion='" + Frm_prefacturadetalles.txtObservacion.Text + "',NoOrden='" + Frm_prefacturadetalles.txtOrden.Text + "',Cierre='" + lblCierre.Text + "',TipoPago='" + btnControlTipoPago.Tag.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "' WHERE IDPrefactura= (" + txtIDFactura.Text + ")"
            GuardarDatos()
            InsertArticulos()

            ToastNotificationsManager2.Notifications(1).Body = "La prefactura " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
            ToastNotificationsManager2.ShowNotification(ToastNotificationsManager2.Notifications(1))

            Hora.Enabled = False
        End If

    End Sub

    Private Sub btnNuevo_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnNuevo.ItemClick

        If txtIDFactura.Text = "" Then
            If AdvBandedGridView1.RowCount > 0 Then
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

    Sub SumTotales()
        'Try
        Dim SubTotal As Double = 0
        Dim Descuentos As Double = 0
        Dim Itbis As Double = 0
        Dim Importe As Double = 0

        For Each Rows As DataRow In TablaArticulos.Rows
            SubTotal = SubTotal + (CDbl(Rows.Item("PrecioSinItbis")) * (CDbl(Rows.Item("Cantidad"))))
            Descuentos = Descuentos + (CDbl(Rows.Item("Descuento")))
            Itbis = Itbis + ((CDbl(Rows.Item("Cantidad"))) * (CDbl(Rows.Item("Itbis"))))
            Importe = Importe + (CDbl(Rows.Item("Importe")))
        Next


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub
    Private Sub Gridview1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1)
        End If
    End Sub


    Private Sub frm_facturacion_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SplitContainerProperties()
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


    Private Sub frm_prefacturacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            btnGuardarC.PerformClick()

        ElseIf e.KeyCode = Keys.F1 Then
            SplitContainer1.Panel1Collapsed = False
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
                btnAplicarAutomatico.PerformClick()
            End If

        ElseIf e.KeyCode = (Keys.T Or Keys.Control) Then
            btnControlTipoPago.PerformClick()
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

    Private Sub frm_prefacturacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If txtIDFactura.Text = "" Then
            If AdvBandedGridView1.RowCount > 0 Then
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


End Class