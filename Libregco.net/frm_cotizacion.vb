Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cotizacion

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDArticulo, lblItbisArticulo, lblIDCondicion, lblDiasCondicion, lblIDAlmacen, lblIDAlmacenArticulo, lblIDUsuario, lblIDPrecio, lblDescMaxArt, lblIDMedida, lblNulo, lblDescuento, Fraccionamiento, lblIDCotizacionArt, lblExistencia As New Label
    Dim ShowInfoArticle, FactDebajoCosto, DefaultNcf, FacturarSinExist, DefaultIDCondicion, DefaultCondicion, FacturacionSinInventarioArticuloBase, ControlarNivelesPrecios As String
    Friend ChangedCodeEmployee, ModifyingProduct As Boolean
    Friend Permisos, Precios As New ArrayList
    Dim CbxPrecioHeader As New ComboBox

    Private Sub frm_cotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SetConfiguracion()
        ColumnasDgvArticulos()
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub FillTipoMoneda()
        ConLibregco.Open()
        Ds.Clear()
        cbxMoneda.Properties.Items.Clear()
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "tipomoneda")
        ConLibregco.Close()

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

        cbxMoneda.SelectedIndex = 0
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtTelefonos.Clear()
        txtIDCotizacion.Clear()
        txtSecondID.Clear()
        txtHoraCotizacion.Clear()
        txtFechaCotizacion.Clear()
        LimpiarTextInsert()
        btnBuscarCliente.Focus()
        txtVendedor.Tag = ""
        txtVendedor.Text = ""
        txtComentario.Clear()
        dgvArticulos.Rows.Clear()
        lblIDCotizacionArt.Text = ""
        cbxPrecio.Items.Clear()
    End Sub

    Private Sub ColumnasDgvArticulos()
        dgvArticulos.Columns.Clear()
        With dgvArticulos
            .Columns.Add("IDCotizacionDetalle", "IDCotDetalle")    '0
            .Columns.Add("IDCotizacion", "IDCotizacion")  '1
            .Columns.Add("IDPrecios", "IDPrecio") '2

            .Columns.Add("IDMedida", "ID Medida")   '3
            .Columns.Add("IDArticulo", "Código")    '4
            .Columns.Add("Cantidad", "Cant.")       '5
            .Columns.Add("Medida", "Medida")        '6

            .Columns.Add("Descripcion", "Descripción")  '7
            .Columns.Add("PrecioTotal", "Precio") '8
            .Columns.Add("Precio", "PreciosinIt") '9

            .Columns.Add("Descuento", "Descuento")  '10
            .Columns.Add("Itbis", "Itbis")  '11
            .Columns.Add("Importe", "Importe")      '12
            .Columns.Add("IDAlmacen", "Almacén")      '13
            .Columns.Add("NivelPrecio", "Nivel") '  14
            .Columns.Add("Fraccionamiento", "Fraccionamiento") '  15
        End With
        PropiedadesDgvArticulos()

        'CbxHeaderPrecios
        CbxPrecioHeader.DropDownStyle = ComboBoxStyle.DropDownList
        CbxPrecioHeader.Visible = False

        dgvArticulos.Controls.Add(CbxPrecioHeader)
        CbxPrecioHeader.Name = "CbxPreciosHeader"
        CbxPrecioHeader.Location = dgvArticulos.GetCellDisplayRectangle(3, -1, False).Location
        CbxPrecioHeader.Size = dgvArticulos.Columns(14).HeaderCell.Size
        CbxPrecioHeader.Text = "Precios"

        AddHandler CbxPrecioHeader.SelectionChangeCommitted, AddressOf CbxPrecioHeader_SelectionChanged

    End Sub

    Private Sub CbxPrecioHeader_SelectionChanged(sender As Object, e As EventArgs)
        ConMixta.Open()

        For Each rw As DataGridViewRow In dgvArticulos.Rows
            If CbxPrecioHeader.Text = "A" Then
                cmd = New MySqlCommand("SELECT PrecioCredito FROM Libregco.precioarticulo where IDPrecios='" + rw.Cells(2).Value.ToString + "'", ConMixta)
                rw.Cells(8).Value = CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C4")

            ElseIf CbxPrecioHeader.Text = "B" Then
                cmd = New MySqlCommand("SELECT PrecioContado FROM Libregco.precioarticulo where IDPrecios='" + rw.Cells(2).Value.ToString + "'", ConMixta)
                rw.Cells(8).Value = CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C4")

            ElseIf CbxPrecioHeader.Text = "C" Then
                cmd = New MySqlCommand("SELECT Precio3 FROM Libregco.precioarticulo where IDPrecios='" + rw.Cells(2).Value.ToString + "'", ConMixta)
                rw.Cells(8).Value = CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C4")

            ElseIf CbxPrecioHeader.Text = "D" Then
                cmd = New MySqlCommand("SELECT Precio4 FROM Libregco.precioarticulo where IDPrecios='" + rw.Cells(2).Value.ToString + "'", ConMixta)
                rw.Cells(8).Value = CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C4")
            End If

            cmd = New MySqlCommand("Select TipoItbis.Itbis from Libregco.Articulos INNER JOIN Libregco.TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + rw.Cells(4).Value.ToString + "'", ConMixta)
            lblItbisArticulo.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar()))

            rw.Cells(9).Value = CDbl(CDbl(rw.Cells(8).Value) / (1 + CDbl(lblItbisArticulo.Text))).ToString("C4")
            rw.Cells(10).Value = CDbl(0).ToString("C")
            rw.Cells(11).Value = CDbl(CDbl(rw.Cells(9).Value) * CDbl(lblItbisArticulo.Text)).ToString("C4")
            rw.Cells(12).Value = CDbl(CDbl(rw.Cells(8).Value) * CDbl(rw.Cells(5).Value)).ToString("C4")
            rw.Cells(14).Value = CbxPrecioHeader.Text
        Next

        ConMixta.Close()

        SumTotales()
    End Sub

    Sub PropiedadesDgvArticulos()
        Try
            Dim Condicion As String = False
            Dim DatagridWith As Double = (dgvArticulos.Width - dgvArticulos.RowHeadersWidth) / 100

            With dgvArticulos
                .Columns("IDCotizacionDetalle").Visible = Condicion
                .Columns("IDCotizacionDetalle").ReadOnly = True

                .Columns("IDCotizacion").Visible = Condicion
                .Columns("IDCotizacion").ReadOnly = True

                .Columns("IDMedida").Visible = Condicion
                .Columns("IDMedida").ReadOnly = True

                .Columns("IDPrecios").Visible = Condicion
                .Columns("IDPrecios").ReadOnly = True

                .Columns("Medida").Width = DatagridWith * 7
                .Columns("Medida").ReadOnly = True

                .Columns("Cantidad").HeaderText = "Cant."
                .Columns("Cantidad").Width = DatagridWith * 6
                .Columns("Cantidad").ReadOnly = False

                .Columns("IDArticulo").Width = DatagridWith * 11
                .Columns("IDArticulo").HeaderText = "Código"
                .Columns("IDArticulo").ReadOnly = True

                .Columns("Descripcion").Width = DatagridWith * 39
                .Columns("Descripcion").HeaderText = "Descripción"
                .Columns("Descripcion").ReadOnly = True

                .Columns("Precio").Visible = False
                .Columns("Precio").ReadOnly = True

                .Columns("PrecioTotal").DefaultCellStyle.Format = ("C4")
                .Columns("PrecioTotal").HeaderText = "Precio"
                .Columns("PrecioTotal").Width = DatagridWith * 10
                .Columns("PrecioTotal").ReadOnly = False

                .Columns("Descuento").Visible = False
                .Columns("Descuento").ReadOnly = True

                .Columns("Itbis").Visible = False
                .Columns("Itbis").ReadOnly = True

                .Columns("Importe").DefaultCellStyle.Format = ("C4")
                .Columns("Importe").Width = DatagridWith * 14
                .Columns("Importe").ReadOnly = True

                .Columns("IDAlmacen").Width = DatagridWith * 8
                .Columns("IDAlmacen").ReadOnly = True

                .Columns("NivelPrecio").Width = DatagridWith * 5
                .Columns("NivelPrecio").ReadOnly = True
                .Columns("NivelPrecio").ReadOnly = True

                .Columns("Fraccionamiento").Visible = False
                .Columns("Fraccionamiento").ReadOnly = True

                .ScrollBars = ScrollBars.Vertical
            End With

        Catch ex As Exception

        End Try

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
        lblIDAlmacenArticulo.Text = ""
        IDArticulo.Text = ""
        lblExistencia.Text = ""
        GPExistencia.Visible = False
        txtCodigoArticulo.Focus()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
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

            Con.Close()
            ConMixta.Close()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        LimpiarDatosArticulos()
        HabilitarControles()
        txtIDCliente.Text = 1
        txtNombre.Text = "CONTADO"
        cbxCondicion.Text = DefaultCondicion
        txtFlete.Text = CDbl(0).ToString("C")
        txtSubTotal.Text = CDbl(0).ToString("C")
        txtITBIS.Text = CDbl(0).ToString("C")
        TxtDescuento.Text = CDbl(0).ToString("C")
        txtFlete.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        cbxMoneda.Enabled = True
        chkNulo.Checked = False
        lblItbisArticulo.Text = 0
        lblDescuento.Text = 0
        ControlSuperClave = 1
        lblNulo.Text = 0
        txtFlete.Text = CDbl(0.0).ToString("C")
        txtFechaCotizacion.Text = Today.ToString("yyyy-MM-dd")
        lblIDAlmacenArticulo.Text = ""
        lblExistencia.Text = ""
        txtNombre.Enabled = False
        txtNombre.ReadOnly = True
        ChangedCodeEmployee = False
        FillAlmacen()
        FillCondicion()
        lblStatusBar.Text = "Listo"
        ModifyingProduct = False
        GPExistencia.Visible = False
        btnModificar.Enabled = True
        Precios = GetRangePrices()
        FillTipoMoneda()

        cbxPrecio.Items.Clear()
        CbxPrecioHeader.Items.Clear()

        For Each item As String In Precios
            cbxPrecio.Items.Add(item)
            CbxPrecioHeader.Items.Add(item)
        Next

        If cbxPrecio.Items.Count > 0 Then
            cbxPrecio.SelectedIndex = 0
        End If

        If CbxPrecioHeader.Items.Count > 0 Then
            CbxPrecioHeader.SelectedIndex = 0
        End If
    End Sub

    Private Sub dgvArticulosFactura_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellMouseEnter
        If dgvArticulos.Columns.Count > 0 Then
            If e.RowIndex = -1 Then
                If e.ColumnIndex = 14 Then
                    CbxPrecioHeader.Visible = True
                    CbxPrecioHeader.Location = dgvArticulos.GetCellDisplayRectangle(e.ColumnIndex, -1, False).Location
                End If
            End If
        End If
    End Sub

    Private Sub dgvArticulosFactura_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellMouseLeave
        If e.RowIndex <> -1 Then
            CbxPrecioHeader.Visible = False
        End If
    End Sub

    Private Sub dgvArticulosFactura_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvArticulos.Scroll
        CbxPrecioHeader.Visible = False
    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        SumarTotalArticulo()
    End Sub

    Private Sub txtCantidadArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadArticulo.TextChanged

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


        SumarTotalArticulo()
    End Sub

    Sub SumarTotalArticulo()
        Try
            txtTotalArt.Text = (CDbl(txtCantidadArticulo.Text) * CDbl(txtPrecio.Text)).ToString("C")
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
        Try
            Ds.Clear()
            ConLibregco.Open()

            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,RutaFoto FROM Articulos WHERE IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")

            If Tabla.Rows.Count = 0 Then
                ConLibregco.Open()
                Ds.Clear()
                cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,RutaFoto FROM Articulos WHERE Referencia='" + txtCodigoArticulo.Text + "'", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Articulos")
                ConLibregco.Close()

                Tabla = Ds.Tables("Articulos")

                If Tabla.Rows.Count = 0 Then
                    ConLibregco.Open()
                    Ds.Clear()
                    cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,RutaFoto FROM Articulos WHERE CodigoBarra='" + txtCodigoArticulo.Text + "'", ConLibregco)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Articulos")
                    ConLibregco.Close()

                    Tabla = Ds.Tables("Articulos")

                    If Tabla.Rows.Count = 0 Then
                        MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtCodigoArticulo.Focus()

                    Else
                        txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                        lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))

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
                    txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                    lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))

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

                txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))

                If ModifyingProduct = False Then
                    If txtCantidadArticulo.Text = "" Then
                        txtCantidadArticulo.Text = 1
                    End If
                End If

                lblDescuento.Text = 0
                FillMedida()
                CargarExistenciasTreeView()


            End If

            If txtDescripcionArticulo.Text.Contains("TOLA PERSONALIZABLE") Or txtDescripcionArticulo.Text.Contains("Tola Personalizable") Or txtDescripcionArticulo.Text.Contains("TOLA PERSONALIZADA") Or txtDescripcionArticulo.Text.Contains("Tola Personalizada") Then
                frm_calculo_tolas.ShowDialog(Me)
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub CargarExistenciasTreeView()
        Try
            Dim ds0, ds1, ds2 As New DataSet
            Dim MyNode() As TreeNode

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
    Private Sub txtCodigoArticulo_Leave(sender As Object, e As EventArgs) Handles txtCodigoArticulo.Leave
        Try
            If txtCodigoArticulo.Text = "" Then
                LimpiarDatosArticulo2()

            Else
                If txtCodigoArticulo.Text.Substring(0, 1) = "-" Then
                    Dim Index As Integer = txtCodigoArticulo.Text.Remove(0, 1)
                    If Index > 0 Then
                        If dgvArticulos.Rows.Count >= Index - 1 Then
                            dgvArticulos.Rows.Remove(dgvArticulos.Rows(Index - 1))
                            LimpiarDatosArticulos()
                            SumTotales()
                        Else
                            LimpiarDatosArticulos()
                        End If
                    Else
                        LimpiarDatosArticulos()
                    End If

                ElseIf txtCodigoArticulo.Text.Substring(0, 1) = "*" Then
                    Dim Index As Integer = txtCodigoArticulo.Text.Remove(0, 1)
                    If Index > 0 Then
                        If dgvArticulos.Rows.Count >= Index - 1 Then
                            LimpiarDatosArticulo2()
                            dgvArticulos.Focus()
                            dgvArticulos.Rows(Index - 1).Selected = True
                            dgvArticulos.FirstDisplayedScrollingRowIndex = Index - 1
                            dgvArticulos.CurrentCell = Me.dgvArticulos.Rows(Index - 1).Cells(0)
                        Else
                            LimpiarDatosArticulo2()
                        End If
                        LimpiarDatosArticulo2()
                    Else
                        LimpiarDatosArticulo2()
                    End If

                    LimpiarDatosArticulo2()

                Else
                    lblIDAlmacenArticulo.Text = lblIDAlmacen.Text
                    SetInformacionArticulo()
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillAlmacen()

        Ds.clear()
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

    Private Sub FillCondicion()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Condicion FROM Condicion where Nulo=0 ORDER BY Orden ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")
            cbxCondicion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Condicion")
            For Each Fila As DataRow In Tabla.Rows
                cbxCondicion.Items.Add(Fila.Item("Condicion").ToString.ToUpper)
            Next

            If Tabla.Rows.Count > 0 Then
                cbxCondicion.Text = DefaultCondicion
            Else
                MessageBox.Show("No se pudo cargar ninguna condición para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree condiciones de ventas." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem1.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub QuitarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem1.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub IrAArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrAArtículosToolStripMenuItem.Click
        If frm_mant_articulos.Visible = True Then
            frm_mant_articulos.Close()
        End If

        frm_mant_articulos.Show(Me)
        frm_mant_articulos.txtIDProducto.Text = dgvArticulos.CurrentRow.Cells(4).Value
        frm_mant_articulos.FillAllDatafromID()
    End Sub

    Private Sub dgvArticulosFactura_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvArticulos.CellMouseUp
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                dgvArticulos.Rows(e.RowIndex).Selected = True
                dgvArticulos.CurrentCell = dgvArticulos.Rows(e.RowIndex).Cells(6)
                CMenuProducts.Show(dgvArticulos, e.Location)
                CMenuProducts.Show(Cursor.Position)
            End If


        End If
    End Sub


    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub EliminacionPorModificacion()
        Dim IDCotizacionDetalle As New Label
        IDCotizacionDetalle.Text = dgvArticulos.CurrentRow.Cells(0).Value

        If IDCotizacionDetalle.Text = "" Or txtIDCotizacion.Text = "" Then
            Exit Sub
        Else
            sqlQ = "Delete from CotizacionDetalle Where IDCotizacionDetalle = (" + IDCotizacionDetalle.Text + ")"
            GuardarDatos()
        End If

    End Sub
    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        Dim DsPrecios As New DataSet
        Dim CostoFinal, VenderCosto, DescuentoMaximo, PrecioMinimoA, PrecioMinimoB As New Label

        Try
            If txtCodigoArticulo.Text <> "" And cbxPrecio.Text <> "" Then
                If txtPrecio.Text <> "" Then
                    If IsNumeric(CDbl(txtPrecio.Text)) Then
                        If txtCodigoArticulo.Text <> "" And lblIDMedida.Text <> "" Then
                            ConLibregco.Open()                      'Busco los precios predeterminados
                            cmd = New MySqlCommand("SELECT Costo,CostoFinal,DescuentoMaximo,PrecioContado,PrecioCredito,Precio3,Precio4 FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
                            Adaptador = New MySqlDataAdapter(cmd)
                            Adaptador.Fill(DsPrecios, "Precios")
                            ConLibregco.Close()

                            Dim Tabla As DataTable = DsPrecios.Tables("Precios")

                            DescuentoMaximo.Text = Tabla.Rows(0).Item("DescuentoMaximo")
                            PrecioMinimoA.Text = CDbl(Tabla.Rows(0).Item("PrecioCredito")) - (CDbl(Tabla.Rows(0).Item("PrecioCredito")) * CDbl(Tabla.Rows(0).Item("DescuentoMaximo")))
                            PrecioMinimoB.Text = CDbl(Tabla.Rows(0).Item("PrecioContado")) - (CDbl(Tabla.Rows(0).Item("PrecioContado")) * CDbl(Tabla.Rows(0).Item("DescuentoMaximo")))

                            If IsNumeric(txtPrecio.Text) Then
                                If FactDebajoCosto = 1 Then         'Si puedo facturar por debajo del costo 
                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                    If cbxPrecio.Text = "A" Then
                                        If CDbl(txtPrecio.Text) > CDbl(Tabla.Rows(0).Item("PrecioCredito")) Then
                                            lblDescuento.Text = CDbl(0).ToString("C")
                                        Else
                                            lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioCredito")) - CDbl(txtPrecio.Text)).ToString("C")
                                        End If
                                    ElseIf cbxPrecio.Text = "B" Then
                                        If CDbl(txtPrecio.Text) > CDbl(Tabla.Rows(0).Item("PrecioContado")) Then
                                            lblDescuento.Text = CDbl(0).ToString("C")
                                        Else
                                            lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioContado")) - CDbl(txtPrecio.Text)).ToString("C")
                                        End If
                                    End If
                                Else
                                    'Verifico si el articulo se puede vender al costo
                                    ConLibregco.Open()
                                    cmd = New MySqlCommand("SELECT VenderCosto FROM Articulos Where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)
                                    VenderCosto.Text = Convert.ToDouble(cmd.ExecuteScalar())
                                    ConLibregco.Close()

                                    If VenderCosto.Text = 1 Then    'Si se puede vender al costo
                                        If CDbl(txtPrecio.Text) >= CDbl(Tabla.Rows(0).Item("CostoFinal")) Then
                                            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        Else
                                            MessageBox.Show("El precio establecido excede el costo del producto." & vbNewLine & vbNewLine & "El artículo está autorizado y disponible para venderse al costo, por un monto de: " & CDbl(Tabla.Rows(0).Item("CostoFinal")).ToString("C") & ".", "Exceso del precio introducido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            txtPrecio.Text = CDbl(Tabla.Rows(0).Item("CostoFinal")).ToString("C")
                                            If cbxPrecio.Text = "A" Then
                                                If CDbl(txtPrecio.Text) > CDbl(Tabla.Rows(0).Item("PrecioCredito")) Then
                                                    lblDescuento.Text = 0
                                                Else
                                                    lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioCredito")) - CDbl(txtPrecio.Text)).ToString("C")
                                                End If

                                            ElseIf cbxPrecio.Text = "B" Then
                                                If CDbl(txtPrecio.Text) > CDbl(Tabla.Rows(0).Item("PrecioContado")) Then
                                                    lblDescuento.Text = 0
                                                Else
                                                    lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioContado")) - CDbl(txtPrecio.Text)).ToString("C")
                                                End If

                                            End If
                                        End If

                                    Else

                                        If ControlarNivelesPrecios = "1" Then
                                            'Si el precio se puede vender al costo no hago nada, aún cuando no se puede facturar al costo.
                                            If cbxPrecio.Text = "A" Then
                                                If CDbl(txtPrecio.Text) < CDbl(PrecioMinimoA.Text) Then
                                                    MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido.", "El precio dado ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                    txtPrecio.Text = CDbl(Tabla.Rows(0).Item("PrecioCredito")).ToString("C")
                                                    txtPrecio.Focus()
                                                Else
                                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    If txtPrecio.Text < (Tabla.Rows(0).Item("PrecioCredito")) Then
                                                        lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioCredito")) - CDbl(txtPrecio.Text)).ToString("C")
                                                    Else
                                                        lblDescuento.Text = CDbl(0).ToString("C")
                                                    End If

                                                End If
                                            ElseIf cbxPrecio.Text = "B" Then
                                                If CDbl(txtPrecio.Text) < CDbl(PrecioMinimoB.Text) Then
                                                    MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido.", "El precio dado ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                    txtPrecio.Text = CDbl(Tabla.Rows(0).Item("PrecioContado")).ToString("C")
                                                    txtPrecio.Focus()
                                                Else
                                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    If txtPrecio.Text < (Tabla.Rows(0).Item("PrecioContado")) Then
                                                        lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioContado")) - CDbl(txtPrecio.Text)).ToString("C")
                                                    Else
                                                        lblDescuento.Text = CDbl(0).ToString("C")
                                                    End If
                                                End If
                                            Else
                                                If cbxPrecio.Text = "C" Then
                                                    If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("Precio3")) Then
                                                        MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                        txtPrecio.Text = CDbl(Tabla.Rows(0).Item("Precio3")).ToString("C")
                                                    Else
                                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    End If
                                                    lblDescuento.Text = CDbl(0).ToString("C")
                                                ElseIf cbxPrecio.Text = "D" Then
                                                    If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("Precio4")) Then
                                                        MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                        txtPrecio.Text = CDbl(Tabla.Rows(0).Item("Precio4")).ToString("C")
                                                    Else
                                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    End If
                                                    lblDescuento.Text = CDbl(0).ToString("C")
                                                ElseIf cbxPrecio.Text = "E" Then
                                                    If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("Costo")) Then
                                                        MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                        txtPrecio.Text = CDbl(Tabla.Rows(0).Item("Costo")).ToString("C")
                                                    Else
                                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    End If
                                                    lblDescuento.Text = CDbl(0).ToString("C")
                                                ElseIf cbxPrecio.Text = "F" Then
                                                    If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("CostoFinal")) Then
                                                        MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                        txtPrecio.Text = CDbl(Tabla.Rows(0).Item("CostoFinal")).ToString("C")
                                                    Else
                                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                                    End If
                                                    lblDescuento.Text = CDbl(0).ToString("C")
                                                End If
                                            End If

                                        Else
                                            If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("Costo")) Then
                                                MessageBox.Show("No es posible hacer establecer el precio ya que excede el costo del producto.", "Ha excedido el costo del producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                txtPrecio.Text = CDbl(Tabla.Rows(0).Item("PrecioCredito")).ToString("C")
                                            Else
                                                txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")

                                            End If

                                        End If

                                    End If
                                End If


                            End If

                            Tabla.Dispose()
                        Else
                            txtPrecio.Text = CDbl(0).ToString("C")
                        End If

                        lblDescuento.Text = CDbl(lblDescuento.Text).ToString("C")

                    Else
                        ConLibregco.Open()                      'Busco los precios predeterminados
                        cmd = New MySqlCommand("SELECT Costo,CostoFinal,DescuentoMaximo,PrecioContado,PrecioCredito,Precio3,Precio4 FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
                        Adaptador = New MySqlDataAdapter(cmd)
                        Adaptador.Fill(DsPrecios, "Precios")
                        ConLibregco.Close()

                        Dim Tabla As DataTable = DsPrecios.Tables("Precios")

                        txtPrecio.Text = CDbl(Tabla.Rows(0).Item("PrecioCredito")).ToString("C")

                        Tabla.Dispose()
                    End If

                    SumarTotalArticulo()

                Else
                    txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C")
                End If

            End If


        Catch ex As Exception

            Try
                ConLibregco.Open()                      'Busco los precios predeterminados
                cmd = New MySqlCommand("SELECT Costo,CostoFinal,DescuentoMaximo,PrecioContado,PrecioCredito,Precio3,Precio4 FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsPrecios, "Precios")
                ConLibregco.Close()

                Dim Tabla As DataTable = DsPrecios.Tables("Precios")

                txtPrecio.Text = CDbl(Tabla.Rows(0).Item("PrecioCredito")).ToString("C")

                SumarTotalArticulo()

                Tabla.Dispose()
            Catch exs As Exception
                InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
                LimpiarDatosArticulos()
            End Try

        End Try

    End Sub

    Private Sub DeterminarDescuentoAplicado()

    End Sub

    Private Sub LimpiarTextInsert()
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtPrecio.Clear()
        txtTotalArt.Clear()
        txtCodigoArticulo.Clear()
        txtCodigoArticulo.Focus()
        lblDescMaxArt.Text = ""
        lblIDMedida.Text = ""
        lblIDPrecio.Text = ""
        GPExistencia.Visible = False
        lblIDCotizacionArt.Text = ""
    End Sub

    Private Sub txtCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArticulo.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "-*0123456789abcdefghijklmnñopqrstuvwxyz"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtCodigoArticulo.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
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


        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillMedida()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + IDArticulo.Text + "' and PrecioArticulo.Nulo=0 order by contenido desc", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PrecioArticulo")
            CbxMedida.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")
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

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDMedida.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Fraccionamiento FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        Fraccionamiento.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDPrecio.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C")

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
        IDArticulo.Text = ""
        GPExistencia.Visible = False
    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0

Inicio:
        If x = dgvArticulos.Rows.Count Or dgvArticulos.Rows.Count = 0 Then
            ControlSuperClave = 0
            Exit Sub
        End If

        If CInt(dgvArticulos.Rows(x).Cells(2).Value) = CInt(lblIDPrecio.Text) Then
            MessageBox.Show("Este artículo ya se encuentra en la cotización." & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtCodigoArticulo.Focus()
            ControlSuperClave = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub BuscarItebis()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select TipoItbis.Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtCodigoArticulo.Text + "'", ConLibregco)
        lblItbisArticulo.Text = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub FijarDescMaxArt()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT DescuentoMaximo FROM PrecioArticulo WHERE IDArticulo= '" + txtCodigoArticulo.Text + "'", ConLibregco)
            lblDescMaxArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
            ConLibregco.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnInsertarArticulo_Click(sender As Object, e As EventArgs) Handles btnInsertarArticulo.Click
        Try

            If txtCodigoArticulo.Text = "" Then
                MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtCodigoArticulo.Focus()
            Else

                If cbxPrecio.Text = "" Then
                    MessageBox.Show("Seleccione un nivel de precio del producto para insertar a la cotización.", "Seleccione un nivel de precio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    cbxPrecio.Focus()
                    cbxPrecio.DroppedDown = True
                    Exit Sub
                End If
                If CbxMedida.Items.Count = 0 Then
                    MessageBox.Show("El artículo " & txtDescripcionArticulo.Text & " no tiene unidades de medidas válidas para registrar. Por favor verifique el artículo e inserte unidades de ventas.", "Medidas no encontradas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    CbxMedida.Focus()
                    Exit Sub
                End If

                If FacturarSinExist = 0 Then
                    If txtCodigoArticulo.Text = 1 Then
                        If FacturacionSinInventarioArticuloBase = 0 Then
                            If txtIDCotizacion.Text = "" Then
                                If CDbl(lblExistencia.Text) < CDbl(txtCantidadArticulo.Text) Then
                                    lblStatusBar.Text = "El artículo [" & txtCodigoArticulo.Text & "] " & txtDescripcionArticulo.Text & " no tiene las existencias"
                                    lblStatusBar.ForeColor = Color.Red
                                Else
                                    lblStatusBar.Text = "Listo"
                                    lblStatusBar.ForeColor = Color.Black
                                End If
                            End If
                        End If

                    Else
                        If txtIDCotizacion.Text = "" Then
                            If CDbl(lblExistencia.Text) < CDbl(txtCantidadArticulo.Text) Then
                                lblStatusBar.Text = "El artículo [" & txtCodigoArticulo.Text & "] " & txtDescripcionArticulo.Text & " no tiene las existencias"
                                lblStatusBar.ForeColor = Color.Red
                            Else
                                lblStatusBar.Text = "Listo"
                                lblStatusBar.ForeColor = Color.Black
                            End If
                        End If

                    End If
                End If


                If Fraccionamiento.Text = 0 Then
                    txtCantidadArticulo.Text = TruncateDecimal(txtCantidadArticulo.Text)
                End If
                SumarTotalArticulo()

                VerificarDuplicados()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarItebis()
                DeterminarDescuentoAplicado()

                With dgvArticulos
                    .Rows.Add(lblIDCotizacionArt.Text, txtIDCotizacion.Text, lblIDPrecio.Text, lblIDMedida.Text, IDArticulo.Text, txtCantidadArticulo.Text, CbxMedida.Text, txtDescripcionArticulo.Text, CDbl(txtPrecio.Text).ToString("C4"), (CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArticulo.Text))).ToString("C4"), CDbl(lblDescuento.Text).ToString("C4"), ((CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArticulo.Text))) * CDbl(lblItbisArticulo.Text)).ToString("C4"), (CDbl(txtPrecio.Text) * CDbl(txtCantidadArticulo.Text)).ToString("C4"), lblIDAlmacenArticulo.Text, cbxPrecio.Text, Fraccionamiento.Text)
                End With

                SumTotales()
                LimpiarTextInsert()
                dgvArticulos.ClearSelection()
                ModifyingProduct = False
                btnModificar.Enabled = True
                btnQuitarArticulo.Enabled = True
                btnBlanquear.Enabled = True
                cbxPrecio.Text = "A"
                txtCodigoArticulo.Focus()

                If dgvArticulos.Rows.Count > 0 Then
                    cbxMoneda.Enabled = False
                End If

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub SumTotales()

        Dim SubTotal As Double = 0
        Dim Descuentos As Double = 0
        Dim Itbis As Double = 0
        Dim Importe As Double = 0

        For Each Rows As DataGridViewRow In dgvArticulos.Rows
            SubTotal = SubTotal + (CDbl(Rows.Cells(9).Value) * (CDbl(Rows.Cells(5).Value)))
            Descuentos = Descuentos + (CDbl(Rows.Cells(10).Value))
            Itbis = Itbis + (CDbl(Rows.Cells(11).Value)) * (CDbl(Rows.Cells(5).Value))
            Importe = Importe + (CDbl(Rows.Cells(12).Value))
        Next

        txtSubTotal.Text = SubTotal.ToString("C")
        TxtDescuento.Text = Descuentos.ToString("C")
        txtITBIS.Text = Itbis.ToString("C")
        txtNeto.Text = (CDbl(txtFlete.Text) + Importe).ToString("C")

    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=4", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Cotizacion SET SecondID='" + lblSecondID.Text + "' WHERE IDCotizacion='" + txtIDCotizacion.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=4"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub UltCotizacion()
        If txtIDCotizacion.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDCotizacion from Cotizacion where IDCotizacion= (Select Max(IDCotizacion) from Cotizacion)", Con)
            txtIDCotizacion.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHoraCotizacion.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub InsertarArticulos()
        Dim IDCotizacionDetalle As New Label
        Con.Open()

        For Each Rw As DataGridViewRow In dgvArticulos.Rows
            IDCotizacionDetalle.Text = Rw.Cells(0).Value

            If IDCotizacionDetalle.Text = "" Then
                sqlQ = "INSERT INTO CotizacionDetalle (IDCotizacion,IDPrecio,IDArticulo,Descripcion,IDMedida,Medida,Cantidad,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,Nivel) VALUES ('" + txtIDCotizacion.Text + "','" + Rw.Cells(2).Value.ToString + "','" + Rw.Cells(4).Value.ToString + "','" + Rw.Cells(7).Value.ToString + "','" + Rw.Cells(3).Value.ToString + "','" + Rw.Cells(6).Value.ToString + "','" + Rw.Cells(5).Value.ToString + "','" + CDbl(Rw.Cells(9).Value).ToString + "','" + CDbl(Rw.Cells(10).Value).ToString + "','" + CDbl(CDbl(Rw.Cells(11).Value) * CDbl(Rw.Cells(5).Value)).ToString + "','" + CDbl(Rw.Cells(12).Value).ToString + "','" + Rw.Cells(13).Value.ToString + "','" + Rw.Cells(14).Value.ToString + "')"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("SELECT IDCotizacionDetalles FROM cotizaciondetalle where IDCotizacionDetalles=(Select Max(IDCotizacionDetalles) from cotizaciondetalle)", Con)
                Rw.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                Rw.Cells(1).Value = txtIDCotizacion.Text

            Else

                sqlQ = "UPDATE CotizacionDetalle SET IDCotizacion='" + txtIDCotizacion.Text + "',IDPrecio='" + Rw.Cells(2).Value.ToString + "',IDArticulo='" + Rw.Cells(4).Value.ToString + "',Descripcion='" + Rw.Cells(7).Value.ToString + "',IDMedida='" + Rw.Cells(3).Value.ToString + "',Medida='" + Rw.Cells(6).Value.ToString + "',Cantidad='" + Rw.Cells(5).Value.ToString + "',PrecioUnitario='" + CDbl(Rw.Cells(9).Value).ToString + "',Descuento='" + CDbl(Rw.Cells(10).Value).ToString + "',Itbis='" + CDbl(CDbl(Rw.Cells(11).Value) * CDbl(Rw.Cells(5).Value)).ToString + "',Importe='" + CDbl(Rw.Cells(12).Value).ToString + "',IDAlmacen='" + Rw.Cells(13).Value.ToString + "',Nivel='" + Rw.Cells(14).Value.ToString + "' Where IDCotizacionDetalles='" + IDCotizacionDetalle.Text + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If
        Next

        Con.Close()

    End Sub

    Sub RefrescarTablaArticulos()
        Try
            If txtIDCotizacion.Text = "" Then
            Else
                dgvArticulos.Rows.Clear()
                ConMixta.Open()

                Dim Consulta As New MySqlCommand("Select IDCotizacionDetalles,IDCotizacion,IDPrecio,CotizacionDetalle.IDMedida,IDArticulo,Cantidad,CotizacionDetalle.Medida,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,Nivel,Fraccionamiento FROM" & SysName.Text & "CotizacionDetalle INNER JOIN Libregco.Medida on CotizacionDetalle.IDMedida=Medida.IDMedida Where IDCotizacion='" + txtIDCotizacion.Text + "'", ConMixta)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    dgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), CDbl(LectorArticulos.GetValue(8)) + (CDbl(LectorArticulos.GetValue(10)) / CDbl(LectorArticulos.GetValue(5))), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), CDbl(LectorArticulos.GetValue(10)) / CDbl(LectorArticulos.GetValue(5)), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), LectorArticulos.GetValue(14))
                End While
                LectorArticulos.Close()
                ConMixta.Close()

                PropiedadesDgvArticulos()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtFlete_Leave(sender As Object, e As EventArgs) Handles txtFlete.Leave
        If txtFlete.Text = "" Then
            txtFlete.Text = CDbl(0).ToString("C")
        Else
            txtFlete.Text = CDbl(txtFlete.Text).ToString("C")
        End If
        SumTotales()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
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

    Private Sub BuscarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarFacturaToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDCotizacion.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la cotización?", "Imprimir Cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub HabilitarControles()
        txtComentario.Enabled = True
        txtFlete.Enabled = True
        GbArticulos.Enabled = True
        GbClientes.Enabled = True
        txtVendedor.Enabled = True
        cbxAlmacen.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        txtComentario.Enabled = False
        txtFlete.Enabled = False
        GbArticulos.Enabled = False
        GbClientes.Enabled = False
        txtVendedor.Enabled = False
        cbxAlmacen.Enabled = False
    End Sub

    Private Sub txtFlete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFlete.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtFlete_Enter(sender As Object, e As EventArgs) Handles txtFlete.Enter
        If txtFlete.Text = "" Then
        Else
            txtFlete.Text = CDbl(txtFlete.Text)
        End If
    End Sub


    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If dgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDCotizacion.Text = "" And dgvArticulos.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    dgvArticulos.Rows.Clear()
                    SumTotales()
                    txtCodigoArticulo.Focus()
                    Exit Sub
                End If
            End If

            If txtIDCotizacion.Text > 0 And dgvArticulos.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya procesados en un cotización.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If dgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub

            Else

                If txtIDCotizacion.Text = "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & dgvArticulos.CurrentRow.Cells(7).Value & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        dgvArticulos.Rows.Remove(dgvArticulos.CurrentRow)
                        SumTotales()
                    End If

                Else
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo?", "Eliminar artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        If dgvArticulos.Rows.Count = 1 Then
                            MessageBox.Show("No es posible eliminar el artículo ya que es único en la factura. Para realizar esta operación primero agregue el artículo que desea a la factura y posteriormente proceda a eliminar el artículo correspondiente.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        Con.Open()
                        sqlQ = "Delete from" & SysName.Text & "Cotizaciondetalle Where IDCotizacionDetalles= '" + dgvArticulos.CurrentRow.Cells(0).Value.ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                        Con.Close()

                        dgvArticulos.Rows.Remove(dgvArticulos.CurrentRow)
                        SumTotales()

                        sqlQ = "UPDATE Cotizacion SET IDCliente='" + txtIDCliente.Text + "',NombreCotizacion='" + txtNombre.Text + "',DireccionCotizacion='" + txtDireccion.Text + "',TelefonoCotizacion='" + txtTelefonos.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDCondicion='" + lblIDCondicion.Text + "',IDVendedor='" + txtVendedor.Tag.ToString + "',Comentario='" + txtComentario.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuento.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',Nulo='" + lblNulo.Text + "' WHERE IDCotizacion= (" + txtIDCotizacion.Text + ")"
                        GuardarDatos()

                        MessageBox.Show("El artículo ha sido eliminado satisfactoriamente.", "Artículo eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    End If

                End If
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If dgvArticulos.Rows.Count = 0 And txtIDCotizacion.Text = "" Then
                MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If dgvArticulos.Rows.Count > 0 Then
                lblIDCotizacionArt.Text = dgvArticulos.CurrentRow.Cells(0).Value
                txtCodigoArticulo.Text = dgvArticulos.CurrentRow.Cells(4).Value
                IDArticulo.Text = dgvArticulos.CurrentRow.Cells(4).Value
                FillMedida()
                txtDescripcionArticulo.Text = dgvArticulos.CurrentRow.Cells(7).Value
                CbxMedida.Text = dgvArticulos.CurrentRow.Cells(6).Value
                lblIDMedida.Text = dgvArticulos.CurrentRow.Cells(3).Value
                cbxPrecio.Text = dgvArticulos.CurrentRow.Cells(14).Value
                ModifyingProduct = True
                txtCantidadArticulo.Text = dgvArticulos.CurrentRow.Cells(5).Value
                BuscarItebis()
                lblIDPrecio.Text = dgvArticulos.CurrentRow.Cells(2).Value
                txtPrecio.Text = CDbl(dgvArticulos.CurrentRow.Cells(8).Value).ToString("C")
                txtTotalArt.Text = CDbl(dgvArticulos.CurrentRow.Cells(12).Value).ToString("C")
                lblDescuento.Text = CDbl(dgvArticulos.CurrentRow.Cells(10).Value).ToString("C")
                lblIDAlmacenArticulo.Text = dgvArticulos.CurrentRow.Cells(13).Value
                dgvArticulos.Rows.Remove(dgvArticulos.CurrentRow)
                SumTotales()
                btnModificar.Enabled = False
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDCotizacion.Text = "" Then
            If dgvArticulos.Rows.Count > 0 Then
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_cotizacion.ShowDialog(Me)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la cotización.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtNombre.Text = "" Then
            MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombre.Enabled = True
            txtNombre.Focus()
            Exit Sub
        ElseIf txtVendedor.Text = "" Then
            MessageBox.Show("Seleccione un vendedor para procesar la cotización.", "Seleccionar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtVendedor.Focus()
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Or txtNeto.Text = "" Then
            MessageBox.Show("No se han encontrado artículos para procesar la cotización.", "No hay artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La cotización No. " & txtIDCotizacion.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 34
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                sqlQ = "UPDATE Cotizacion SET IDCliente='" + txtIDCliente.Text + "',NombreCotizacion='" + txtNombre.Text + "',DireccionCotizacion='" + txtDireccion.Text + "',TelefonoCotizacion='" + txtTelefonos.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDCondicion='" + lblIDCondicion.Text + "',IDVendedor='" + txtVendedor.Tag.ToString + "',Comentario='" + txtComentario.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuento.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',Nulo='" + lblNulo.Text + "' WHERE IDCotizacion= (" + txtIDCotizacion.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDCotizacion.Text = "" Then
            MessageBox.Show("No hay  registro de cotización abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la cotización no. " & txtIDCotizacion.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 33
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                sqlQ = "UPDATE Cotizacion SET IDCliente='" + txtIDCliente.Text + "',NombreCotizacion='" + txtNombre.Text + "',DireccionCotizacion='" + txtDireccion.Text + "',TelefonoCotizacion='" + txtTelefonos.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDCondicion='" + lblIDCondicion.Text + "',IDVendedor='" + txtVendedor.Tag.ToString + "',Comentario='" + txtComentario.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuento.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',Nulo='" + lblNulo.Text + "' WHERE IDCotizacion= (" + txtIDCotizacion.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub GetTriedModifiedIDFactArt()
        Try
            If lblIDCotizacionArt.Text <> "" Then
                Dim Contmp As New MySqlConnection(CnGeneral)

                Contmp.Open()
                Dim Consulta As New MySqlCommand("Select IDCotizacionDetalles,IDCotizacion,IDPrecio,IDMedida,IDArticulo,Cantidad,Medida,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,Nivel FROM" & SysName.Text & "CotizacionDetalle Where IDCotizacionDetalles='" + lblIDCotizacionArt.Text + "'", Contmp)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    dgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), (CDbl(LectorArticulos.GetValue(8)) + CDbl(LectorArticulos.GetValue(10))).ToString("C4"), CDbl(LectorArticulos.GetValue(8)).ToString("C4"), CDbl(LectorArticulos.GetValue(9)).ToString("C4"), CDbl(LectorArticulos.GetValue(10)).ToString("C4"), CDbl(LectorArticulos.GetValue(11)).ToString("C4"), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), 0)
                End While

                LectorArticulos.Close()
                Contmp.Close()

                SumTotales()
                LimpiarDatosArticulos()
                btnModificar.Enabled = True
                txtDescripcionArticulo.ReadOnly = True
                txtDescripcionArticulo.Enabled = False
                dgvArticulos.FirstDisplayedScrollingRowIndex = dgvArticulos.Rows.Count - 1
                txtCodigoArticulo.Focus()
                Contmp.Dispose()
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtDescuentoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub frm_cotizacion_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulos()
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "' ORDER BY Orden ASC", ConLibregco)
        lblIDCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Dias FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblDiasCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        ConLibregco.Close()
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

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789 "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvArticulos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvArticulos.RowPostPaint
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

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
            DeshabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub cbxCondicion_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCondicion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            btnBuscarCliente.Focus()

        End If
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub


    Private Sub txtDescripcionArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcionArticulo.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "-*0123456789abcdefghijklmnñopqrstuvwxyz"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMoneda.SelectedIndexChanged
        If CbxMedida.Text <> "" Then
            txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C")
        End If
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la cotización.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtNombre.Text = "" Then
            MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombre.Enabled = True
            txtNombre.Focus()
            Exit Sub
        ElseIf txtVendedor.Text = "" Then
            MessageBox.Show("Seleccione un vendedor para procesar la cotización.", "Seleccionar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtVendedor.Focus()
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Or txtNeto.Text = "" Then
            MessageBox.Show("No se han encontrado artículos para procesar la cotización.", "No hay artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDCotizacion.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la cotización al cliente: " & txtNombre.Text & " [ " & txtIDCliente.Text & " ] en la base de datos?", "Guardar Nueva Cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Cotizacion (IDTipoDocumento,IDCliente,NombreCotizacion,DireccionCotizacion,TelefonoCotizacion,IDUsuario,IDSucursal,IDAlmacen,IDCondicion,IDVendedor,Fecha,Hora,Comentario,SubTotal,Descuento,Itbis,Flete,TotalNeto,Impreso,EstadoCotizacion,IDMoneda,Nulo) VALUES (4,'" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtDireccion.Text + "','" + txtTelefonos.Text + "','" + lblIDUsuario.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + lblIDCondicion.Text + "','" + txtVendedor.Tag.ToString + "',CURDATE(),CURRENT_TIME(), '" + txtComentario.Text + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(TxtDescuento.Text).ToString + "','" + CDbl(txtITBIS.Text).ToString + "','" + CDbl(txtFlete.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "',0,0,'" + cbxMoneda.EditValue.ToString + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltCotizacion()
                SetSecondID()
                InsertarArticulos()

                ToastNotificationsManager1.Notifications(0).Body = "La cotización " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                ImprimirDocumento()
                DeshabilitarControles()
            End If
        Else

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la cotización?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                GetTriedModifiedIDFactArt()
                sqlQ = "UPDATE Cotizacion SET IDCliente='" + txtIDCliente.Text + "',NombreCotizacion='" + txtNombre.Text + "',DireccionCotizacion='" + txtDireccion.Text + "',TelefonoCotizacion='" + txtTelefonos.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDCondicion='" + lblIDCondicion.Text + "',IDVendedor='" + txtVendedor.Tag.ToString + "',Comentario='" + txtComentario.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuento.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',Nulo='" + lblNulo.Text + "' WHERE IDCotizacion= (" + txtIDCotizacion.Text + ")"
                GuardarDatos()
                InsertarArticulos()

                ToastNotificationsManager1.Notifications(1).Body = "La cotización " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

                ImprimirDocumento()
            End If
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
            End If

            SumarTotalArticulo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvArticulos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellValueChanged
        Try
            If e.ColumnIndex = 5 Then
                If IsNumeric(CDbl(dgvArticulos.CurrentRow.Cells(5).Value)) Then
                    If CDbl(dgvArticulos.CurrentRow.Cells(5).Value) = 0 Then
                        dgvArticulos.CurrentRow.Cells(5).Value = 1
                    Else
                        dgvArticulos.CurrentRow.Cells(12).Value = (CDbl(dgvArticulos.CurrentRow.Cells(5).Value) * CDbl(dgvArticulos.CurrentRow.Cells(8).Value)).ToString("C4")
                    End If
                Else
                    dgvArticulos.CurrentRow.Cells(5).Value = 1
                End If

                SumTotales()
            End If


        Catch ex As Exception
            dgvArticulos.CurrentRow.Cells(5).Value = 1
            SumTotales()
        End Try

        Try
            If e.ColumnIndex = 8 Then
                If IsNumeric(CDbl(dgvArticulos.CurrentRow.Cells(8).Value)) Then

                    ConLibregco.Open()
                    cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + dgvArticulos.CurrentRow.Cells(4).Value.ToString + "'", ConLibregco)
                    Dim lblItbis As String = Convert.ToDouble(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    dgvArticulos.CurrentRow.Cells(9).Value = CDbl(CDbl(dgvArticulos.CurrentRow.Cells(8).Value) / (1 + CDbl(lblItbis))).ToString("C4")
                    dgvArticulos.CurrentRow.Cells(11).Value = CDbl(CDbl(CDbl(dgvArticulos.CurrentRow.Cells(8).Value) / (1 + CDbl(lblItbis))) * CDbl(lblItbis)).ToString("C4")
                    dgvArticulos.CurrentRow.Cells(12).Value = (CDbl(dgvArticulos.CurrentRow.Cells(5).Value) * CDbl(dgvArticulos.CurrentRow.Cells(8).Value)).ToString("C4")
                    dgvArticulos.CurrentRow.Cells(14).Value = GetPriceLevel(CDbl(dgvArticulos.CurrentRow.Cells(8).Value), dgvArticulos.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue.ToString)

                Else
                    Con.Open()
                    If dgvArticulos.CurrentRow.Cells(14).Value = "A" Then
                        cmd = New MySqlCommand("Select PrecioCredito from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                        dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                    ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "B" Then
                        cmd = New MySqlCommand("Select PrecioContado from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                        dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                    ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "C" Then
                        cmd = New MySqlCommand("Select Precio3 from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                        dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                    ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "D" Then
                        cmd = New MySqlCommand("Select Precio4 from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                        dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                    End If
                    Con.Close()

                    dgvArticulos.CurrentRow.Cells(14).Value = GetPriceLevel(CDbl(dgvArticulos.CurrentRow.Cells(8).Value), dgvArticulos.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue.ToString)
                End If

                SumTotales()
            End If

        Catch ex As Exception
            Con.Open()
            cmd = New MySqlCommand("Select PrecioCredito from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
            dgvArticulos.CurrentRow.Cells(14).Value = "A"
            Con.Close()

            SumTotales()
        End Try



        dgvArticulos.Invalidate()
    End Sub

    Private Sub txtVendedor_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtVendedor.ButtonClick
        frm_contraseña_empleado.txtUsuario.Tag = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        frm_contraseña_empleado.Show(Me)
    End Sub

    Private Sub dgvArticulos_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellLeave
        If e.ColumnIndex = 8 Then
            If FactDebajoCosto = 0 Then
                Dim dstemp As New DataSet
                ConLibregco.Open()                      'Busco los precios predeterminados
                cmd = New MySqlCommand("SELECT IDPrecios,Costo,CostoFinal,DescuentoMaximo,PrecioContado,PrecioCredito,Precio3,Precio4 FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE PrecioArticulo.IDPrecios= '" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "' and PrecioArticulo.Nulo=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstemp, "Precios")
                ConLibregco.Close()

                Dim Tabla As DataTable = dstemp.Tables("Precios")

                If ControlarNivelesPrecios = 1 Then
                    If CDbl(dgvArticulos.CurrentRow.Cells(8).Value) < CDbl(Tabla.Rows(0).Item("Precio4")) Then
                        MessageBox.Show("El precio colocado excede al precio mínimo en el último renglón de precios.", "Precio mínimo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                        Con.Open()
                        If dgvArticulos.CurrentRow.Cells(14).Value = "A" Then
                            cmd = New MySqlCommand("Select PrecioCredito from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "B" Then
                            cmd = New MySqlCommand("Select PrecioContado from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "C" Then
                            cmd = New MySqlCommand("Select Precio3 from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "D" Then
                            cmd = New MySqlCommand("Select Precio4 from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        Else
                            cmd = New MySqlCommand("Select PrecioCredito from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        End If
                        Con.Close()

                        Tabla.Dispose()

                    Else
                        dgvArticulos.CurrentRow.Cells(8).Value = CDbl(dgvArticulos.CurrentRow.Cells(8).Value).ToString("C4")
                        dgvArticulos.CurrentRow.Cells(12).Value = (CDbl(dgvArticulos.CurrentRow.Cells(5).Value) * CDbl(dgvArticulos.CurrentRow.Cells(8).Value)).ToString("C4")

                    End If

                Else
                    If CDbl(dgvArticulos.CurrentRow.Cells(8).Value) < CDbl(Tabla.Rows(0).Item("Costo")) Then
                        MessageBox.Show("El precio colocado excede al costo del producto.", "Costo excedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                        Con.Open()
                        If dgvArticulos.CurrentRow.Cells(14).Value = "A" Then
                            cmd = New MySqlCommand("Select PrecioCredito from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "B" Then
                            cmd = New MySqlCommand("Select PrecioContado from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "C" Then
                            cmd = New MySqlCommand("Select Precio3 from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        ElseIf dgvArticulos.CurrentRow.Cells(14).Value = "D" Then
                            cmd = New MySqlCommand("Select Precio4 from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        Else
                            cmd = New MySqlCommand("Select PrecioCredito from Libregco.PrecioArticulo where IDPrecios='" + dgvArticulos.CurrentRow.Cells(2).Value.ToString() + "'", Con)
                            dgvArticulos.CurrentRow.Cells(8).Value = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C4")
                        End If
                        Con.Close()

                        Tabla.Dispose()

                    Else
                        dgvArticulos.CurrentRow.Cells(8).Value = CDbl(dgvArticulos.CurrentRow.Cells(8).Value).ToString("C4")
                        dgvArticulos.CurrentRow.Cells(12).Value = (CDbl(dgvArticulos.CurrentRow.Cells(5).Value) * CDbl(dgvArticulos.CurrentRow.Cells(8).Value)).ToString("C4")

                    End If
                End If

                dgvArticulos.CurrentRow.Cells(14).Value = GetPriceLevel(CDbl(dgvArticulos.CurrentRow.Cells(8).Value), dgvArticulos.CurrentRow.Cells(2).Value.ToString, cbxMoneda.EditValue.ToString)

                Tabla.Dispose()
            Else
                dgvArticulos.CurrentRow.Cells(8).Value = CDbl(dgvArticulos.CurrentRow.Cells(8).Value).ToString("C4")
                dgvArticulos.CurrentRow.Cells(12).Value = (CDbl(dgvArticulos.CurrentRow.Cells(5).Value) * CDbl(dgvArticulos.CurrentRow.Cells(8).Value)).ToString("C4")
            End If

        End If
    End Sub


    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        lblIDAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
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

    Private Sub lblModificar_Click(sender As Object, e As EventArgs) Handles lblModificar.Click
        If txtDireccion.Visible = False Then
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height + 78)
            txtNombre.Enabled = True
            txtNombre.ReadOnly = False
            lblDireccion.Visible = True
            lblTelefonos.Visible = True
            txtDireccion.Visible = True
            txtTelefonos.Visible = True
            txtNombre.Focus()
        Else
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height - 78)
            txtNombre.Enabled = False
            txtNombre.ReadOnly = True
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
        End If
    End Sub

    Private Sub lblAjustarGbClientes_Click(sender As Object, e As EventArgs) Handles lblAjustarGbClientes.Click
        If txtDireccion.Visible = True Then
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height - 78)
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
        Else
            lblDireccion.Visible = True
            lblTelefonos.Visible = True
            txtDireccion.Visible = True
            txtTelefonos.Visible = True
        End If
    End Sub

    Private Sub GbClientes_Leave(sender As Object, e As EventArgs) Handles GbClientes.Leave
        If txtDireccion.Visible = True Then
            GbClientes.Size = New Size(GbClientes.Size.Width, 78)
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
        End If
    End Sub

    Private Sub DgvArticulos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvArticulos.CellFormatting
        If e.ColumnIndex = Me.dgvArticulos.Columns(12).Index AndAlso (e.Value IsNot Nothing) Then

            With Me.dgvArticulos.Rows(e.RowIndex).Cells(e.ColumnIndex)
                Dim IDAlmacen As String = dgvArticulos.CurrentRow.Cells(12).Value
                Con.Open()
                cmd = New MySqlCommand("Select Almacen from Almacen where IDAlmacen='" + IDAlmacen + "'", Con)
                Dim Almacen As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                .ToolTipText = Almacen
            End With
        End If
    End Sub

    Private Sub DgvArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 5 Or e.ColumnIndex = 8 Then
                dgvArticulos.EditMode = DataGridViewEditMode.EditOnEnter
            ElseIf e.ColumnIndex = 13 Then
                frm_cambiar_almacenes_fact.IDPrecios.Text = dgvArticulos.CurrentRow.Cells(2).Value
                frm_cambiar_almacenes_fact.Show(Me)
            End If
        End If
    End Sub

    Private Sub txtIDVendedor_TextChanged(sender As Object, e As EventArgs)
        ChangedCodeEmployee = True
    End Sub


    Private Sub BuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarArtículosToolStripMenuItem.Click
        If txtCodigoArticulo.Focused = False Then
            txtCodigoArticulo.Focus()
        Else
            txtCodigoArticulo.Focus()
            frm_buscar_mant_articulos.ShowDialog(Me)
        End If

    End Sub

    Private Sub txtCodigoArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCodigoArticulo.Text <> "" Then
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

    Private Sub frm_cotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            btnGuardarC.PerformClick()

        ElseIf e.KeyCode = Keys.F12 Then
            txtNombre.Focus()
            txtNombre.SelectAll()

        End If
    End Sub

    Private Sub dgvArticulosFactura_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellEndEdit
        dgvArticulos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvArticulosFactura_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvArticulos.CurrentCellDirtyStateChanged
        If dgvArticulos.IsCurrentCellDirty Then
            dgvArticulos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvArticulosFactura_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvArticulos.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = dgvArticulos.CurrentCell.ColumnIndex


        If Columna = 5 Then

            If dgvArticulos.CurrentRow.Cells(15).Value = 1 Then
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

End Class