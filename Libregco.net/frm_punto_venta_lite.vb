Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_punto_venta_lite

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend ShowInfoArticle, FactDebajoCosto, DefaultNcf, FacturarSinExist, DefaultCondicion, DefaultAlmacen, DefaultDiasCondicion, EvitSabado, EvitDomingo, IdentObligCred, PerVentasSContrato, SolicitarAutCredito, lblGenerarPagares, DefaultIDCobrador As String
    Friend lblchkEntregaConduce, IDArticulo, lblItbisArt, lblIDUsuario, lblIDComprobante, lblIDChofer, lblIDAlmacen, lblIDAlmacenArticulo, lblIDVehiculo, lblCondicion, lblDiasCondicion, lblIDMedida, lblIDPrecio, lblFichaDatos, lblNotaContado, lblDesactivar, lblIDTipoDocumento, lblExistencia, lblIDFactArt As New Label
    Friend ChangedCodeEmployee As Boolean
    Dim Permisos, PagaresCreados, Precios As New ArrayList
  
    Private Sub frm_punto_venta_lite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        SetConfiguracion()
        ColumnasDgvArticulos()
        ColumnasDgvPagares()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub ColumnasDgvArticulos()
        DgvArticulos.Columns.Clear()
        With DgvArticulos
            .Columns.Add("IDArtFac", "ID ArtFac")   '0
            .Columns.Add("IDFactura", "ID Factura") '1
            .Columns.Add("IDPrecios", "ID Precio") '2
            .Columns.Add("IDMedida", "ID Medida")   '3
            .Columns.Add("IDArticulo", "Código")    '4
            .Columns.Add("Descripcion", "Descripción")  '5
            .Columns.Add("Cantidad", "Cant.")       '6
            .Columns.Add("Medida", "Medida")        '7
            .Columns.Add("Precio", "Precio") '8
            .Columns.Add("Descuento", "Descuento")  '9
            .Columns.Add("Itbis", "Itbis")  '10
            .Columns.Add("Importe", "Importe")      '11
            .Columns.Add("IDAlmacen", "Alm") '12
            .Columns.Add("NivelPrecio", "Precio") '13
        End With
        PropiedadesDgvArticulos()
    End Sub

    Sub PropiedadesDgvArticulos()
        Try
            Dim Condicion As String = False
            Dim DatagridWith As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth) / 100
            With DgvArticulos
                .Columns("IDArtFac").Visible = Condicion
                .Columns("IDFactura").Visible = Condicion
                .Columns("IDMedida").Visible = Condicion
                .Columns("IDPrecios").Visible = Condicion
                .Columns("Medida").Width = DatagridWith * 8
                .Columns("Cantidad").HeaderText = "Cant."
                .Columns("Cantidad").Width = DatagridWith * 6
                .Columns("IDArticulo").Width = DatagridWith * 8
                .Columns("IDArticulo").HeaderText = "Código"
                .Columns("Descripcion").Width = DatagridWith * 26
                .Columns("Descripcion").HeaderText = "Descripción"
                .Columns("Precio").DefaultCellStyle.Format = ("C")
                .Columns("Precio").HeaderText = "Precio"
                .Columns("Precio").Width = DatagridWith * 10
                .Columns("Descuento").DefaultCellStyle.Format = ("C")
                .Columns("Descuento").Width = DatagridWith * 10
                .Columns("Itbis").DefaultCellStyle.Format = ("C")
                .Columns("Itbis").Width = DatagridWith * 10
                .Columns("Importe").DefaultCellStyle.Format = ("C")
                .Columns("Importe").Width = DatagridWith * 12
                .Columns("Importe").DefaultCellStyle.BackColor = Color.Yellow
                .Columns("IDAlmacen").Width = DatagridWith * 5
                .Columns("IDAlmacen").DefaultCellStyle.BackColor = Color.LightGray
                .Columns("NivelPrecio").Width = DatagridWith * 5
                .ScrollBars = ScrollBars.Vertical
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColumnasDgvPagares()
        DgvPagares.Columns.Clear()
        With DgvPagares
            .Columns.Add("IDPagare", "IDPagare") '0
            .Columns.Add("IDFactura", "ID Factura") '1
            .Columns.Add("NoPagare", "No Pagaré.") '2
            .Columns.Add("Cantidad", "Cant.") '3
            .Columns.Add("FechaVencimiento", "Vencimiento") '4
            .Columns.Add("Concepto", "Concepto") '5
            .Columns.Add("Monto", "Monto") '6
            .Columns.Add("Balance", "Balance") '7
            PropiedadesDgvPagares()
        End With
    End Sub

    Private Sub PropiedadesDgvPagares()
        Try
            Dim Condicion As String = False
            With DgvPagares
                .Columns("IDPagare").Visible = Condicion
                .Columns("IDFactura").Visible = Condicion
                .Columns("FechaVencimiento").Width = 80
                .Columns("NoPagare").Width = 60
                .Columns("Cantidad").Visible = Condicion
                .Columns("Concepto").Width = 300
                .Columns("Monto").Width = 100
                .Columns("Monto").DefaultCellStyle.Format = ("C")
                .Columns("Balance").DefaultCellStyle.Format = ("C")
                .Columns("Balance").Visible = Condicion
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckCondicion()
        If lblDiasCondicion.Text = 0 Then
            txtDiasCondicion.Enabled = False
            txtInicial.Enabled = False
            txtCantidadPagos.Enabled = False
            txtAdicional.Enabled = False
            txtFechaAdicional.Enabled = False
            chkHabilitarNota.Enabled = False
            chkFichaDatos.Enabled = False
            DgvPagares.Enabled = False
            txtCondicionContado.Enabled = False
            lblIDTipoDocumento.Text = 1
            txtMontoPagos.Text = CDbl(0).ToString("C")
            txtBalance.Text = CDbl(0).ToString("C")
        Else
            txtDiasCondicion.Enabled = True
            txtInicial.Enabled = True
            txtCantidadPagos.Enabled = True
            txtAdicional.Enabled = True
            txtFechaAdicional.Enabled = True
            chkHabilitarNota.Enabled = True
            chkFichaDatos.Enabled = True
            DgvPagares.Enabled = True
            txtCondicionContado.Enabled = True
            lblIDTipoDocumento.Text = 2
        End If
    End Sub

    Private Sub ActualizarTodo()
        TabInfoFactura.SelectedIndex = 0
        lblItbisArt.Text = 0
        lblDiasCondicion.Text = 0
        lblIDTransaccion.Text = ""
        lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        lblIDAlmacenArticulo.Text = ""
        ControlSuperClave = 1
        lblchkEntregaConduce.Text = 0
        lblDesactivar.Text = 0
        lblNotaContado.Text = 0
        lblFichaDatos.Text = 0
        txtDiasCondicion.Text = DefaultDiasCondicion
        txtInicial.Text = CDbl(0).ToString("C")
        txtBalance.Text = CDbl(0).ToString("C")
        txtCantidadPagos.Text = 1
        txtMontoPagos.Text = lblTotalFactura.Text
        txtAdicional.Text = CDbl(0).ToString("C")
        txtFechaAdicional.Text = ""
        txtCondicionContado.Enabled = False
        txtCondicionContado.Text = ""
        chkFichaDatos.Checked = False
        chkHabilitarNota.Checked = False
        chkEntregarporConduce.Checked = False
        ChangedCodeEmployee = False
        lblSubTotal.Text = CDbl(0).ToString("C")
        lblItbis.Text = CDbl(0).ToString("C")
        lblDescuento.Text = CDbl(0).ToString("C")
        lblFlete.Text = CDbl(0).ToString("C")
        lblTotalFactura.Text = CDbl(0).ToString("C")
        lblTotalNeto.Text = CDbl(0).ToString("C")
        lblTotalNeto2.Text = CDbl(0).ToString("C")
        lblPrecioArticulo.Text = CDbl(0).ToString("C")
        lblFecha.Text = Today.ToString("yyyy-MM-dd")
        txtFechaVencimiento.Text = Today.ToString("yyyy-MM-dd")
        PicImage.Image = Nothing
        lblTipoProducto.Text = "Tipo Producto: "
        lblDepartamento.Text = "Departamento: "
        lblCategoria.Text = "Categoría: "
        lblSubCategoria.Text = "SubCategoría: "
        lblTipoItbis.Text = "Tipo de Itbis: "
        lblMarca.Text = "Marca: "
        NewNCFValue.Text = ""

        Precios = GetRangePrices()

        For Each item As String In Precios
            cbxPrecio.Items.Add(item)
        Next

        If cbxPrecio.Items.Count > 0 Then
            cbxPrecio.SelectedIndex = 0
        End If

        SetIDTipoDocumento()
        FillComprobante()
        FillChofer()
        FillAlmacen()
        FillVehiculo()
        Fillcondicion()
        HabilitarControles()
        CheckCondicion()
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
                cbxCondicion.Items.Add(Fila.Item("Condicion"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxCondicion.Text = DefaultCondicion
            Else
                MessageBox.Show("No se pudo cargar ninguna condición para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree condiciones de ventas." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub SetIDTipoDocumento()
        If lblDiasCondicion.Text = 0 Then
            lblIDTipoDocumento.Text = 1
        Else
            lblIDTipoDocumento.Text = 2
        End If
    End Sub

    Private Sub FillComprobante()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT TipoComprobante FROM ComprobanteFiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            CbxTipoComprobante.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                CbxTipoComprobante.Items.Add(Fila.Item("TipoComprobante"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxTipoComprobante.Text = DefaultNcf
            Else
                MessageBox.Show("No se pudo cargar ningún tipo de comprobante fiscal para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree los tipos de comprobantes fiscales." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillChofer()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados WHERE Nulo=0 ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            CbxChofer.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")
            For Each Fila As DataRow In Tabla.Rows
                CbxChofer.Items.Add(Fila.Item("Nombre"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxChofer.SelectedIndex = 0
            Else
                MessageBox.Show("No se pudo cargar un chofer para definirla en la factura ya que no se encontraron resultados de empleados bajo esa condición." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillAlmacen()
        Try
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
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillVehiculo()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT DatoVehiculo FROM" & SysName.Text & "Vehiculo ORDER BY Marca ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Vehiculo")
        cbxVehiculo.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Vehiculo")
        For Each Fila As DataRow In Tabla.Rows
            cbxVehiculo.Items.Add(Fila.Item("DatoVehiculo"))
        Next
        If Tabla.Rows.Count > 0 Then
            cbxVehiculo.SelectedIndex = 0
        Else
            MessageBox.Show("No se pudo cargar un vehículo para definirlo en la factura ya que no se encontraron resultados de vehículos activos. Por favor cree un registros de vehículos." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub

    Private Sub LimpiarDatos()
        DgvArticulos.Rows.Clear()
        DgvPagares.Rows.Clear()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()
        txtBalanceGeneral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtCreditoDisponible.Clear()
        txtCobrador.Clear()
        lblIDFactura.Text = ""
        lblHora.Text = ""
        lblFecha.Text = ""
        lblSecondID.Text = ""
        lblDescripcion.Text = ""
        lblPrecioArticulo.Text = ""
        lblTotalFactura.Text = ""
        txtNIF.Clear()
        txtNCF.Clear()
        txtObservacion.Clear()
        LimpiarDatosArticulos()
        CbxTipoComprobante.Items.Clear()
        txtIDVendedor.Clear()
        txtVendedor.Clear()
        cbxAlmacen.Items.Clear()
        CbxChofer.Items.Clear()
        cbxVehiculo.Items.Clear()
        chkDesactivar.Checked = False
    End Sub

    Private Sub CargarEmpresa()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select * from razonsocial where IDRazon= (Select Max(IDRazon) from razonsocial)", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "razonsocial")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("razonsocial")


            If Tabla.Rows.Count > 0 Then
                lblRazon.Text = (Tabla.Rows(0).Item("NombreEmpresa")) & " - " & frm_inicio.lblSucursal.Text
                lblSlogan.Text = (Tabla.Rows(0).Item("Eslogan"))
                lblDireccion.Text = (Tabla.Rows(0).Item("Direccion") & ", Tels.: " & (Tabla.Rows(0).Item("Telefono")))
                If (Tabla.Rows(0).Item("Telefono1")) <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", " & (Tabla.Rows(0).Item("Telefono1"))
                End If
                If (Tabla.Rows(0).Item("Telefono2")) <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", " & (Tabla.Rows(0).Item("Telefono2"))
                End If
                If (Tabla.Rows(0).Item("Fax")) <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", Fax: " & (Tabla.Rows(0).Item("Fax"))
                End If
                lblRNC.Text = "RNC " & (Tabla.Rows(0).Item("RNC"))

                PicBoxLogo.Image = ConseguirLogoEmpresa()

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            lblUsuario.Text = "[" & lblIDUsuario.Text & "] " & Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetConfiguracion()
        Try
            'Mostrar el panel de informacion de los articulos
            Con.Open()
            ConLibregco.Open()

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
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select Condicion from Condicion Where IDCondicion='" + DefaultCondicion + "'", ConLibregco)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

            'Facturar sin Existencia
            cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=21", Con)
            FacturarSinExist = Convert.ToString(cmd.ExecuteScalar())

            'Evitar Sabados en pagares
            cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=50", Con)
            EvitSabado = Convert.ToString(cmd.ExecuteScalar())

            'Evitar Domingos en pagares
            cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=51", Con)
            EvitDomingo = Convert.ToString(cmd.ExecuteScalar())

            'Dias en condicion de pagares
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=52", Con)
            DefaultDiasCondicion = Convert.ToString(cmd.ExecuteScalar())

            'Obligación de cédulas en créditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=55", Con)
            IdentObligCred = Convert.ToString(cmd.ExecuteScalar())

            'Permitir créditos sin contrato
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=79", Con)
            PerVentasSContrato = Convert.ToString(cmd.ExecuteScalar())

            'Solicitar autorizacion para créditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=82", Con)
            SolicitarAutCredito = Convert.ToString(cmd.ExecuteScalar())

            'Generar pagares automaticamente
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=96", Con)
            lblGenerarPagares = Convert.ToString(cmd.ExecuteScalar())

            'Cobrador Predeterminado
            cmd = New MySqlCommand("Select Empleados.IDEmpleado from Configuracion INNER JOIN Empleados on Configuracion.Value2Int=Empleados.IDEmpleado Where IDConfiguracion=25", Con)
            DefaultIDCobrador = Convert.ToString(cmd.ExecuteScalar())

            Con.Close()
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        lblFecha.Text = Today.ToString("yyyy-MM-dd")
        lblFechaLarga.Text = Today.ToLongDateString
        lblHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub DgvArticulos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvArticulos.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvArticulos.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvArticulos.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvArticulos.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub SetInformacionArticulo()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,RutaFoto FROM Articulos WHERE IDArticulo='" + txtIDArticulo.Text + "' or CodigoBarra='" + txtIDArticulo.Text + "' or Articulos.Referencia='" + txtIDArticulo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")

            If (Tabla.Rows.Count) = 0 Then
                MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                cbxMedida.Items.Clear()
                txtIDArticulo.Clear()
                txtIDArticulo.Focus()
            Else
                IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                lblDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
                lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))

                If My.Computer.FileSystem.FileExists(Tabla.Rows(0).Item("RutaFoto")) Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                    PicImage.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                    TabInfoFactura.SelectedIndex = 0
                Else
                    PicImage.Image = My.Resources.No_Image
                End If

                FillMedida()
                SetPreliminarInfo()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetPreliminarInfo()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Articulos.IDTipoProducto,TipoArticulo.TipoArticulo,Articulos.IDDepartamento,Departamentos.Departamento,Articulos.IDItbis,TipoItbis.Tipo,Articulos.IDCategoria,Categoria.Categoria,Articulos.IDSubCategoria,SubCategoria.SubCategoria,Articulos.IDMarca,Marca.Marca FROM articulos INNER JOIN TipoArticulo on Articulos.IDTipoProducto=TipoArticulo.IDTipoArticulo INNER JOIN Departamentos on Articulos.IDDepartamento=Departamentos.IDDepartamento INNER JOIN TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Categoria on Articulos.IDCategoria=Categoria.IDCategoria INNER JOIN SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubCategoria INNER JOIN Marca on Articulos.IDMarca=Marca.IDMarca WHERE IDArticulo='" + txtIDArticulo.Text + "' or CodigoBarra='" + txtIDArticulo.Text + "' or Articulos.Referencia='" + txtIDArticulo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "InfoPreliminar")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("InfoPreliminar")

            lblTipoProducto.Text = "Tipo Producto: " & (Tabla.Rows(0).Item("TipoArticulo"))
            lblDepartamento.Text = "Departamento: " & (Tabla.Rows(0).Item("Departamento"))
            lblCategoria.Text = "Categoría: " & (Tabla.Rows(0).Item("Categoria"))
            lblSubCategoria.Text = "SubCategoría: " & (Tabla.Rows(0).Item("SubCategoria"))
            lblTipoItbis.Text = "Tipo de Itbis: " & (Tabla.Rows(0).Item("Tipo"))
            lblMarca.Text = "Marca: " & (Tabla.Rows(0).Item("Marca"))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtIDArticulo_Leave(sender As Object, e As EventArgs) Handles txtIDArticulo.Leave
        Try
            If txtIDArticulo.Text = "" Then
                LimpiarDatosArticulo2()
                cbxMedida.Focus()
            Else
                lblIDAlmacenArticulo.Text = lblIDAlmacen.Text
                SetInformacionArticulo()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Sub LimpiarDatosArticulo2() 'Para limpiar si crear error al salir del txtIDCodigoArticulo en el evento Leave
        cbxMedida.Items.Clear()
        txtIDArticulo.Text = ""
        lblIDMedida.Text = ""
        lblIDPrecio.Text = ""
        lblExistencia.Text = ""
        lblIDAlmacenArticulo.Text = ""
    End Sub

    Private Sub FillMedida()
        'Try
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + IDArticulo.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "PrecioArticulo")
        cbxMedida.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")
        For Each Fila As DataRow In Tabla.Rows
            cbxMedida.Items.Add(Fila.Item("Abreviatura"))
        Next

        If cbxPrecio.Items.Count > 0 Then
            cbxPrecio.Text = txtNivelPrecio.Text
        End If

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron registros de medidas del artículo consultado.", "No hay registros de precios para el artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ElseIf Tabla.Rows.Count > 0 Then
            cbxMedida.SelectedIndex = 0
            If cbxMedida.Items.Count = 1 Then
                btnInsertarArticulo.PerformClick()
                txtIDArticulo.Focus()
            Else
                If txtIDArticulo.Text = "" Then
                    cbxMedida.Items.Clear()
                    txtIDArticulo.Focus()
                Else
                    cbxMedida.Focus()
                    cbxMedida.DroppedDown = True
                End If
            End If
        End If
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

    End Sub

    Private Sub cbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMedida.SelectedIndexChanged
        SetIDMedida()
    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + cbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDMedida.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtIDArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDPrecio.Text = Convert.ToString(cmd.ExecuteScalar())

        ConLibregco.Close()

        lblPrecioArticulo.Text = CDbl(GetPrices(cbxPrecio.Text, txtIDArticulo.Text, lblIDMedida.Text, 1)).ToString("C")

    End Sub

    Sub LimpiarDatosArticulos()
        cbxMedida.Items.Clear()
        txtIDArticulo.Text = ""
        lblIDMedida.Text = ""
        lblIDPrecio.Text = ""
        lblExistencia.Text = ""
        IDArticulo.Text = ""
        lblIDAlmacenArticulo.Text = ""
        DgvArticulos.ClearSelection()
        txtIDArticulo.Focus()
    End Sub

    Private Sub ActualizarCondicion()
        If lblDiasCondicion.Text = 0 Then
            txtCantidadPagos.Text = 0
            txtMontoPagos.Text = CDbl(0).ToString("C")
            DgvPagares.Rows.Clear()
        Else
            TabInfoFactura.SelectedIndex = 2
            txtCantidadPagos.Text = 1
            CalcularMontoPago()
            CreatePagares()
        End If
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        If lblIDFactura.Text = "" Then
            DgvArticulos.Rows.Clear()
        End If

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Dias FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblDiasCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        ConLibregco.Close()

        If lblDiasCondicion.Text = 0 Then
            SetIDTipoDocumento()
        Else
            SetIDTipoDocumento()
            CalcVencientoFactura()
            SumTotales()
        End If

        ActualizarCondicion()
        CheckCondicion()
    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        lblIDAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            lblDesactivar.Text = 1
            DeshabilitarControles()
        Else
            lblDesactivar.Text = 0
            HabilitarControles()
        End If
    End Sub

    Friend Sub DeshabilitarControles()
        cbxCondicion.Enabled = False
        CbxTipoComprobante.Enabled = False
        cbxAlmacen.Enabled = False
        btnBuscarArticulo.Enabled = False
        btnModificarPrecio.Enabled = False
        btnReducirCantidad.Enabled = False
        btnQuitarArticulo.Enabled = False
        Button2.Enabled = False
        btnCambiarCondicion.Enabled = False
        btnCambiarNCF.Enabled = False
        btnInsertarArticulo.Enabled = False
        txtDiasCondicion.Enabled = False
        txtInicial.Enabled = False
        txtCantidadPagos.Enabled = False
        txtAdicional.Enabled = False
        txtFechaAdicional.Enabled = False
        chkHabilitarNota.Enabled = False
        chkHabilitarNota.Enabled = False
        txtCondicionContado.Enabled = False
        DgvPagares.Enabled = False
        txtVendedor.Enabled = False
        CbxChofer.Enabled = False
        cbxVehiculo.Enabled = False
        txtObservacion.Enabled = False
        cbxMedida.Enabled = False
        Hora.Enabled = False
        txtNombre.Enabled = False
        txtDireccion.Enabled = False
        txtTelefono.Enabled = False
        txtNombre.Enabled = False
        txtDireccion.Enabled = False
        txtTelefono.Enabled = False
        btnModificarCliente.Enabled = False
        btnBuscarCliente.Enabled = False
        btnCrearCliente.Enabled = False
        btnConsultaRNC.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        cbxCondicion.Enabled = True
        CbxTipoComprobante.Enabled = True
        cbxAlmacen.Enabled = True
        btnBuscarArticulo.Enabled = True
        btnModificarPrecio.Enabled = True
        btnReducirCantidad.Enabled = True
        btnQuitarArticulo.Enabled = True
        Button2.Enabled = True
        btnCambiarCondicion.Enabled = True
        btnCambiarNCF.Enabled = True
        btnInsertarArticulo.Enabled = True
        txtDiasCondicion.Enabled = True
        txtInicial.Enabled = True
        txtCantidadPagos.Enabled = True
        txtAdicional.Enabled = True
        txtFechaAdicional.Enabled = True
        chkHabilitarNota.Enabled = True
        chkHabilitarNota.Enabled = True
        txtCondicionContado.Enabled = True
        DgvPagares.Enabled = True
        txtVendedor.Enabled = True
        CbxChofer.Enabled = True
        cbxVehiculo.Enabled = True
        txtObservacion.Enabled = True
        cbxMedida.Enabled = True
        txtNombre.Enabled = True
        txtDireccion.Enabled = True
        txtTelefono.Enabled = True
        Hora.Enabled = True
        txtNombre.Enabled = False
        txtDireccion.Enabled = False
        txtTelefono.Enabled = False
        btnModificarCliente.Enabled = True
        btnBuscarCliente.Enabled = True
        btnCrearCliente.Enabled = True
        btnConsultaRNC.Enabled = True
    End Sub

    Private Sub CbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoComprobante.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + CbxTipoComprobante.SelectedItem + "'", Con)
        lblIDComprobante.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If lblIDFactura.Text = "" Then
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select IDComprobanteFiscal,Inicial,Hasta,Ultimo from ComprobanteFiscal where IDComprobanteFiscal= '" + lblIDComprobante.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")

            If lblIDComprobante.Text = 1 Then
                lblVisualNCF.Text = ""
            Else
                lblVisualNCF.Text = (Tabla.Rows(0).Item("Inicial")) & (Tabla.Rows(0).Item("Ultimo")).PadLeft(8, "0")
            End If
        End If
    End Sub

    Private Sub CbxChofer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxChofer.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + CbxChofer.SelectedItem + "'", Con)
        lblIDChofer.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub cbxVehiculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVehiculo.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDVehiculo FROM Vehiculo WHERE DatoVehiculo= '" + cbxVehiculo.SelectedItem + "'", Con)
        lblIDVehiculo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub BuscarItebis()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtIDArticulo.Text + "' or Referencia='" + txtIDArticulo.Text + "' or CodigoBarra='" + txtIDArticulo.Text + "'", ConLibregco)
        lblItbisArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub BuscarCedulaenCredito()
        If IdentObligCred = 1 Then
            If lblDiasCondicion.Text > 0 Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select Clientes.Identificacion from Clientes where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
                Dim IdentInserted As String = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                If IdentInserted.Length > 0 Then
                    IdentInserted = Replace(IdentInserted, "_", "")
                    IdentInserted = Replace(IdentInserted, "-", "")
                End If

                If IdentInserted.Trim = "" Then
                    MessageBox.Show("El cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & " no tiene un número de identificación/cédula válido para procesar facturas a crédito." & vbNewLine & vbNewLine & "Por favor inserte el número de identificación del cliente para procesar la factura.", "No tiene No. de Identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ControlSuperClave = 1
                Else
                    ControlSuperClave = 0
                End If
            End If
        Else
            ControlSuperClave = 0
        End If
    End Sub

    Private Sub btnInsertarArticulo_Click(sender As Object, e As EventArgs) Handles btnInsertarArticulo.Click
        'Try
        If txtIDArticulo.Text = "" Then
            MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()

        Else
            If FacturarSinExist = 0 Then
                If CDbl(lblExistencia.Text) <= CDbl(0) Then
                    MessageBox.Show("No se puede facturar el artículo [" & IDArticulo.Text & "] " & lblDescripcion.Text & ", ya que no tiene existencias en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            For Each Row As DataGridViewRow In DgvArticulos.Rows
                If lblIDPrecio.Text = Row.Cells(2).Value Then

                    If cbxPrecio.Text <> Row.Cells(13).Value Then
                        cbxPrecio.Text = Row.Cells(13).Value
                    End If

                    Dim ItbisUnitario As Double = (CDbl(Row.Cells(10).Value) / (CDbl(Row.Cells(6).Value)))
                    Dim DescuentoUnitario As Double = (CDbl(Row.Cells(9).Value) / (CDbl(Row.Cells(6).Value)))

                    'Aumento la cantidad a mas uno
                    Row.Cells(6).Value = CDbl(Row.Cells(6).Value) + 1

                    'Multiplico el descuento
                    Row.Cells(9).Value = (DescuentoUnitario * CDbl(Row.Cells(6).Value)).ToString("C")

                    'Multiplico el Itbis
                    Row.Cells(10).Value = (ItbisUnitario * CDbl(Row.Cells(6).Value)).ToString("C")

                    'Multiplico el importe
                    Row.Cells(11).Value = ((CDbl(Row.Cells(8).Value) * CDbl(Row.Cells(6).Value)) + (CDbl(Row.Cells(10).Value))).ToString("C")
                    GoTo Sumatoria
                End If
            Next

            BuscarItebis()

            With DgvArticulos
                .Rows.Add("", "", lblIDPrecio.Text, lblIDMedida.Text, IDArticulo.Text, lblDescripcion.Text, 1, cbxMedida.Text, (CDbl(lblPrecioArticulo.Text) / (CDbl(1) + CDbl(lblItbisArt.Text))).ToString("C"), CDbl(0).ToString("C"), (CDbl(lblPrecioArticulo.Text) - (CDbl(lblPrecioArticulo.Text) / (CDbl(1) + CDbl(lblItbisArt.Text)))).ToString("C"), (CDbl(lblPrecioArticulo.Text)).ToString("C"), lblIDAlmacenArticulo.Text, cbxPrecio.Text)
            End With

Sumatoria:
            SumTotales()
            CreatePagares()
            'BuscarHijos()
            LimpiarDatosArticulos()
            cbxPrecio.Text = txtNivelPrecio.Text
            txtIDArticulo.Focus()

        End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString & " btnInsertarArticulo")
        'End Try
    End Sub

    Private Sub BuscarHijos()
        'Try
        Dim dsTemp As New DataSet
        Dim lblItb As New Label

        If lblIDFactura.Text = "" Then

            dsTemp.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDProductosHijos,IDProductoHijo,Articulos.Descripcion,Articulos.Referencia,ValorIncluidoPrecio,Articulos_Hijos.Nulo FROM libregco.articulos_hijos inner join libregco.articulos on articulos_hijos.idproductohijo=Articulos.idArticulo Where IDProductoPadre='" + txtIDArticulo.Text + "' and HastaFecha>=curdate() and articulos_hijos.Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dsTemp, "Articulos")
            Con.Close()

            Dim Tabla As DataTable = dsTemp.Tables("Articulos")

            If Tabla.Rows.Count > 0 Then
                For Each row As DataRow In Tabla.Rows
                    txtIDArticulo.Text = row.Item(1)

                    Dim Dstp As New DataSet

                    Dstp.Clear()
                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,RutaFoto FROM Articulos WHERE IDArticulo='" + txtIDArticulo.Text + "' or CodigoBarra='" + txtIDArticulo.Text + "' or Articulos.Referencia='" + txtIDArticulo.Text + "'", ConLibregco)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Dstp, "Articulos")
                    ConLibregco.Close()

                    Dim Tabla1 As DataTable = Dstp.Tables("Articulos")

                    If (Tabla1.Rows.Count) = 0 Then
                        MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        cbxMedida.Items.Clear()
                        txtIDArticulo.Clear()
                        txtIDArticulo.Focus()
                    Else
                        IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        lblDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
                        lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))
                        SetPreliminarInfo()

                        If My.Computer.FileSystem.FileExists(Tabla.Rows(0).Item("RutaFoto")) Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                            PicImage.Image = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                            TabInfoFactura.SelectedIndex = 0
                        Else
                            PicImage.Image = My.Resources.No_Image
                        End If

                    End If

                    Tabla1.Dispose()
                Next
                SumTotales()

                dsTemp.Dispose()
                lblItb.Dispose()
            End If

        End If
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Sub SumTotales()

        Dim SubTotal As Double = 0
        Dim Descuentos As Double = 0
        Dim Itbis As Double = 0
        Dim Importe As Double = 0

        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            SubTotal = SubTotal + (CDbl(Rows.Cells(8).Value) * (CDbl(Rows.Cells(6).Value)))
            Descuentos = Descuentos + (CDbl(Rows.Cells(9).Value))
            Itbis = Itbis + (CDbl(Rows.Cells(10).Value))
            Importe = Importe + (CDbl(Rows.Cells(11).Value))
        Next

        lblSubTotal.Text = SubTotal.ToString("C")
        lblDescuento.Text = Descuentos.ToString("C")
        lblItbis.Text = Itbis.ToString("C")

        lblTotalFactura.Text = (CDbl(lblFlete.Text) + Importe).ToString("C")
        lblTotalNeto.Text = (CDbl(lblFlete.Text) + Importe).ToString("C")
        lblTotalNeto2.Text = (CDbl(lblFlete.Text) + Importe).ToString("C")

        If lblDiasCondicion.Text > 0 Then
            txtBalance.Text = (CDbl(lblTotalFactura.Text) - CDbl(txtInicial.Text)).ToString("C")
            txtMontoPagos.Text = ((CDbl(lblTotalFactura.Text) - CDbl(txtInicial.Text)) / CDbl(txtCantidadPagos.Text)).ToString("C")
        Else
            txtBalance.Text = CDbl(0).ToString("C")
            txtMontoPagos.Text = CDbl(0).ToString("C")
        End If

    End Sub

    Friend Sub CreatePagares()
        Try

            Dim txtFechaVencimiento, CvtLetra, Concepto As New Label
            Dim MontoDecimal As Decimal = CDbl(txtMontoPagos.Text)
            Dim DecimalResult As Decimal = MontoDecimal - Int(MontoDecimal)
            Dim DecimalResulttoString As String
            Dim Monto As Integer = MontoDecimal - DecimalResult
            Dim Valor As Integer = txtCantidadPagos.Text
            Dim Dias As Integer = txtDiasCondicion.Text
            Dim DateTake As Date = CDate(lblFecha.Text)


            If lblIDFactura.Text = "" Then
                If lblGenerarPagares = 1 Then
                    If lblDiasCondicion.Text > 0 Then
                        DgvPagares.Rows.Clear()

                        If CDbl(txtAdicional.Text) > 0 Then
                            Valor = Valor - 1
                        End If

                        If DecimalResult > 0 Then
                            DecimalResulttoString = "CON " & CInt(DecimalResult * 100) & "/100"
                        Else
                            DecimalResulttoString = ""
                        End If

                        If CDbl(txtMontoPagos.Text) > 0 Then
                            CvtLetra.Text = Num2Text(CInt(Monto))
                            Concepto.Text = "BUENO Y VÁLIDO POR " & CvtLetra.Text & " PESOS" & DecimalResulttoString

Start:
                            DateTake = DateTake.AddDays(txtDiasCondicion.Text)

                            If EvitSabado = 1 Then
                                If DateTake.DayOfWeek = DayOfWeek.Saturday Then
                                    DateTake = DateTake.AddDays(1)
                                Else
                                End If
                            End If
                            If EvitDomingo = 1 Then
                                If DateTake.DayOfWeek = DayOfWeek.Sunday Then
                                    DateTake = DateTake.AddDays(1)
                                End If
                            End If

                            If Valor = DgvPagares.Rows.Count Then
                                GoTo Final
                            Else
                                DgvPagares.Rows.Add("", "", "", txtCantidadPagos.Text, DateTake.ToString("yyyy-MM-dd"), Concepto.Text, txtMontoPagos.Text, txtMontoPagos.Text, 1)

                                'lblNoPagare no esta habilitado en la inserción

                                GoTo Start
                            End If
                        End If
Final:
                        CreateAdicional()

                        DgvPagares.Sort(DgvPagares.Columns(4), System.ComponentModel.ListSortDirection.Ascending)

                        For Each row As DataGridViewRow In DgvPagares.Rows
                            row.Cells(2).Value = CInt(row.Index) + 1
                        Next
                    End If
                End If
            Else
                Dim CheckifCreate As Boolean = False
                For Each row As DataGridViewRow In DgvPagares.Rows
                    If CDbl(row.Cells(6).Value) <> CDbl(txtMontoPagos.Text) And CDbl(row.Cells(6).Value) <> CDbl(txtAdicional.Text) Then
                        CheckifCreate = True
                        Exit For
                    Else
                        CheckifCreate = False
                        Exit Sub
                    End If
                Next

                For Each row As DataGridViewRow In DgvPagares.Rows
                    If IsNumeric(row.Cells(0).Value) Then
                        PagaresCreados.Add(row.Cells(0).Value)
                    End If
                Next
                If lblGenerarPagares = 1 Then
                    If lblDiasCondicion.Text > 0 Then
                        DgvPagares.Rows.Clear()

                        If DecimalResult > 0 Then
                            DecimalResulttoString = "CON " & CInt(DecimalResult * 100) & "/100"
                        Else
                            DecimalResulttoString = ""
                        End If

                        If CDbl(txtMontoPagos.Text) > 0 Then

                            CvtLetra.Text = Num2Text(CInt(Monto))
                            Concepto.Text = "BUENO Y VÁLIDO POR " & CvtLetra.Text & " PESOS" & DecimalResulttoString

Start1:
                            DateTake = DateTake.AddDays(txtDiasCondicion.Text)

                            If EvitSabado = 1 Then
                                If DateTake.DayOfWeek = DayOfWeek.Saturday Then
                                    DateTake = DateTake.AddDays(1)
                                Else
                                End If
                            End If
                            If EvitDomingo = 1 Then
                                If DateTake.DayOfWeek = DayOfWeek.Sunday Then
                                    DateTake = DateTake.AddDays(1)
                                End If
                            End If

                            If Valor = DgvPagares.Rows.Count Then
                                GoTo Final1
                            Else
                                DgvPagares.Rows.Add("", "", "", txtCantidadPagos.Text, DateTake.ToString("yyyy-MM-dd"), Concepto.Text, txtMontoPagos.Text, txtMontoPagos.Text)


                                GoTo Start1
                            End If
                        End If
Final1:
                        CreateAdicional()

                        DgvPagares.Sort(DgvPagares.Columns(4), System.ComponentModel.ListSortDirection.Ascending)

                        For Each row As DataGridViewRow In DgvPagares.Rows
                            row.Cells(2).Value = CInt(row.Index) + 1
                        Next
                    End If
                End If
            End If


            CalcVencientoFactura()
        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CreateAdicional()
        Dim MontoAdicional As Integer = txtAdicional.Text
        Dim Concepto, CvtLetra As New Label

        CvtLetra.Text = Num2Text(CInt(MontoAdicional))
        Concepto.Text = "BUENO Y VÁLIDO POR " & CvtLetra.Text & " PESOS"

        If MontoAdicional = 0 Then
        Else
            DgvPagares.Rows.Add("", "", "", txtCantidadPagos.Text, txtFechaAdicional.Text, Concepto.Text, txtAdicional.Text, txtAdicional.Text, 2)

        End If
    End Sub

    Private Sub CalcVencientoFactura()
        Dim MayorDate As Date
        Try
            MayorDate = Today

            For Each Row As DataGridViewRow In DgvPagares.Rows
                If CDate(Row.Cells(4).Value) > MayorDate Then
                    MayorDate = CDate(Row.Cells(4).Value)
                End If
            Next
            txtFechaVencimiento.Text = MayorDate.ToString("yyyy-MM-dd")

        Catch ex As Exception
            'txtCantidadPagos.Text = 1
            'MessageBox.Show(ex.Message.ToString & " CalcVencimientoFactura")
        End Try
    End Sub

    Private Sub txtDiasCondicion_Leave(sender As Object, e As EventArgs) Handles txtDiasCondicion.Leave
        If txtDiasCondicion.Text = "" Then
            txtDiasCondicion.Text = DefaultDiasCondicion
        End If

        If (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
        End If

        CreatePagares()
    End Sub

    Private Sub txtDiasCondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasCondicion.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantidadPagos_Leave(sender As Object, e As EventArgs) Handles txtCantidadPagos.Leave
        If txtCantidadPagos.Text = "" Or txtCantidadPagos.Text = 0 Then
            txtCantidadPagos.Text = 1
        End If

        If (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
        End If

        CreatePagares()
    End Sub

    Private Sub txtInicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInicial.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantidadPagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadPagos.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtAdicional_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAdicional.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Friend Sub CalcularMontoPago()
        Try
            If lblDiasCondicion.Text > 0 Then
                txtBalance.Text = (CDbl(lblTotalNeto.Text) - CDbl(txtInicial.Text)).ToString("C")

                If CDbl(txtAdicional.Text) = 0 Then
                    txtMontoPagos.Text = (CDbl(txtBalance.Text) / CInt(txtCantidadPagos.Text)).ToString("C")

                Else
                    txtMontoPagos.Text = ((CDbl(txtBalance.Text) - CDbl(txtAdicional.Text)) / (CInt(txtCantidadPagos.Text) - 1)).ToString("C")
                End If

            End If


        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " CalcularMontoPago")
        End Try
    End Sub

    Private Sub txtCantidadPagos_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadPagos.TextChanged
        CalcularMontoPago()
    End Sub

    Private Sub ValidacionEnInicial()
        Dim Neto, Inicial As Double
        Neto = lblTotalNeto.Text
        Inicial = txtInicial.Text

        If Inicial > Neto Then
            MessageBox.Show("El inicial introducido en la factura es mayor al balance a pagar. Verifique los datos y/o la condición de la factura.", "Error en el inicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtInicial.Text = CDbl(0).ToString("C")
            txtInicial.Focus()
        End If

        CalcularMontoPago()

    End Sub

    Private Sub txtInicial_Leave(sender As Object, e As EventArgs) Handles txtInicial.Leave
        If txtInicial.Text = "" Then
            txtInicial.Text = (0).ToString("C")
            txtBalance.Text = lblTotalNeto.Text
        Else
            If CDbl(txtInicial.Text) > 0 And CDbl(txtInicial.Text) >= CDbl(lblTotalNeto.Text) Then
                MessageBox.Show("El inicial es igual al monto neto de la factura." & vbNewLine & vbNewLine & "Por favor cambie la condición de la factura a {CONTADO}.", "Error en Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtInicial.Text = CDbl(0).ToString("C")
                Exit Sub
            Else
                txtInicial.Text = CDbl(txtInicial.Text).ToString("C")
            End If
        End If

        ValidacionEnInicial()
        CreatePagares()
    End Sub

    Private Sub txtInicial_Enter(sender As Object, e As EventArgs) Handles txtInicial.Enter
        If txtInicial.Text = "" Then
        Else
            txtInicial.Text = CDbl(txtInicial.Text)
        End If
    End Sub

    Private Sub txtAdicional_Enter(sender As Object, e As EventArgs) Handles txtAdicional.Enter
        If txtAdicional.Text = "" Then
        Else
            txtAdicional.Text = CDbl(txtAdicional.Text)
        End If
    End Sub

    Private Sub txtFechaAdicional_TextChanged(sender As Object, e As EventArgs) Handles txtFechaAdicional.TextChanged
        If txtFechaAdicional.Text = "" Then
        Else
            txtFechaAdicional.Mask = "0000-00-00"
            txtFechaAdicional.SelectionStart = 1
        End If
    End Sub

    Private Sub txtAdicional_TextChanged(sender As Object, e As EventArgs) Handles txtAdicional.TextChanged
        CalcularMontoPago()
    End Sub

    Private Sub txtFechaAdicional_Leave(sender As Object, e As EventArgs) Handles txtFechaAdicional.Leave
        ValidarFechaAdicional()
        CalcVencientoFactura()
        CreatePagares()
    End Sub

    Private Sub ValidarFechaAdicional()
        Try
            If CDbl(txtAdicional.Text) > 0 Then
                If IsDate(txtFechaAdicional.Text) Then
                    If CDate(txtFechaAdicional.Text) < CDate(lblFecha.Text) Then
                        MessageBox.Show("La fecha del adicional introducida en la factura es menor a la fecha de la factura." & vbNewLine & vbNewLine & "Verifique los datos y/o la condición de la factura.", "Error en el adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtFechaAdicional.Clear()
                        txtFechaAdicional.Focus()
                    End If
                Else
                    MessageBox.Show("El dato introducido no es una fecha válida.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFechaAdicional.Clear()
                    txtFechaAdicional.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " ValidarFechaAdicional")
        End Try
    End Sub

    Private Sub chkHabilitarNota_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabilitarNota.CheckedChanged
        If chkHabilitarNota.Checked = True Then
            If lblIDFactura.Text = "" Then
                lblNotaContado.Text = 1
                frm_int_notacontado.ShowDialog()
            End If
        Else
            lblNotaContado.Text = 0
            txtCondicionContado.Clear()
        End If
    End Sub

    Private Sub chkFichaDatos_CheckedChanged(sender As Object, e As EventArgs) Handles chkFichaDatos.CheckedChanged
        If chkFichaDatos.Checked = True Then
            lblFichaDatos.Text = 0
        Else
            lblFichaDatos.Text = 1
        End If
    End Sub

    Private Sub frm_punto_venta_lite_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulos()
    End Sub

    Private Sub btnCambiarCondicion_Click(sender As Object, e As EventArgs) Handles btnCambiarCondicion.Click
        TabInfoFactura.SelectedIndex = 1
        cbxCondicion.Focus()
        cbxCondicion.DroppedDown = True
    End Sub

    Private Sub CambiarCondiciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarCondiciónToolStripMenuItem.Click
        btnCambiarCondicion.PerformClick()
    End Sub


    Private Sub btnCambiarNCF_Click(sender As Object, e As EventArgs) Handles btnCambiarNCF.Click
        TabInfoFactura.SelectedIndex = 1
        CbxTipoComprobante.Focus()
        CbxTipoComprobante.DroppedDown = True
    End Sub

    Private Sub CambiarNCFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarNCFToolStripMenuItem.Click
        btnCambiarNCF.PerformClick()
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If DgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If DgvArticulos.Rows.Count > 0 And lblIDFactura.Text = "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & DgvArticulos.CurrentRow.Cells(4).Value & "] " & DgvArticulos.CurrentRow.Cells(5).Value & " , [Medida:" & DgvArticulos.CurrentRow.Cells(7).Value & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
                    SumTotales()
                End If
            End If

            If lblIDFactura.Text <> "" Then
                MessageBox.Show("La función está deshabilitada para facturas procesadas.", "Función no válida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub QuitarProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarProductoToolStripMenuItem.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub btnReducirCantidad_Click(sender As Object, e As EventArgs) Handles btnReducirCantidad.Click
        Try
            If DgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay articulos para modificar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If DgvArticulos.Rows.Count > 0 And lblIDFactura.Text = "" Then
                MessageBox.Show("Artículo a reducir: [" & DgvArticulos.CurrentRow.Cells(4).Value & "] " & DgvArticulos.CurrentRow.Cells(5).Value & vbNewLine & "Cantidad Actual: " & DgvArticulos.CurrentRow.Cells(6).Value & "   (-1)" & vbNewLine & "Cantidad Resultante: " & CDbl(DgvArticulos.CurrentRow.Cells(6).Value) - 1, "Reduciendo cantidad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If DgvArticulos.CurrentRow.Cells(6).Value = 1 Then
                    DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
                Else
                    DgvArticulos.CurrentRow.Cells(6).Value = CDbl(DgvArticulos.CurrentRow.Cells(6).Value) - 1
                End If
            End If

            For Each Row As DataGridViewRow In DgvArticulos.Rows

                'Determino el itbis unitario
                Dim ItbisUnitario As Double = (CDbl(Row.Cells(10).Value) / (CDbl(Row.Cells(6).Value) + 1))

                'Multiplico el Itbis
                Row.Cells(10).Value = (ItbisUnitario * CDbl(Row.Cells(6).Value)).ToString("C")

                'Multiplico el importe
                Row.Cells(11).Value = (CDbl(lblPrecioArticulo.Text) * CDbl(Row.Cells(6).Value)).ToString("C")
            Next
            SumTotales()

            If lblIDFactura.Text <> "" Then
                MessageBox.Show("La función está deshabilitada para facturas procesadas.", "Función no válida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReducirCantidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReducirCantidadToolStripMenuItem.Click
        btnReducirCantidad.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If lblIDFactura.Text = "" And DgvArticulos.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("La actual factura tiene datos sin procesar." & vbNewLine & vbNewLine & "Esta seguro que desea limpiar el formulario?", "Hay información sin proceasr", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
        End If
    End Sub

    Private Sub VerificarCreacionPagare()
        If lblDiasCondicion.Text > 0 Then
            CreatePagares()
        End If
    End Sub

    Private Sub StatusCliente()
        Try
            Dim NoRecibirCheques, CuentaIncobrable, CreditoCerrado As New Label

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select CuentaIncobrable,CerrarCredito from Clientes where IDCliente= '" + txtIDCliente.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Clientes")

            CuentaIncobrable.Text = (Tabla.Rows(0).Item("CuentaIncobrable"))
            CreditoCerrado.Text = (Tabla.Rows(0).Item("CerrarCredito"))

            If CreditoCerrado.Text = 1 And lblDiasCondicion.Text > 0 Then
                MessageBox.Show("El cliente tiene el crédito cerrado." & vbNewLine & "Por favor verifique su historial para verificar su status crediticio.", "CREDITO CERRADO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ControlSuperClave = 1
                Exit Sub
            Else
                ControlSuperClave = 0
            End If

            If CuentaIncobrable.Text = 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("El cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] " & "posee cuentas incobrables." & vbNewLine & "Es recomendable consultar el status con " & txtCobrador.Text & ", cobrador asignado actualmente." & vbNewLine & vbNewLine & "Está seguro que desea continuar con la factura?", "Posee cuentas incobrables", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Exit Sub
                Else
                    ControlSuperClave = 1
                    Exit Sub
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarLimiteCredito()
        Try
            Dim LimiteCredito, SumBceFacts As New Label

            If lblDiasCondicion.Text > 0 Then

                ConLibregco.Open()
                cmd = New MySqlCommand("Select LimiteCredito from Clientes where IDCliente= '" + txtIDCliente.Text + "'", ConLibregco)
                LimiteCredito.Text = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From FacturaDatos where IDCliente= '" + txtIDCliente.Text + "' and Nulo=0", ConLibregco)
                SumBceFacts.Text = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If CDbl(SumBceFacts.Text) + CDbl(txtBalance.Text) > CDbl(LimiteCredito.Text) Then
                    MessageBox.Show("La factura excede el límite de crédito [" & CDbl(LimiteCredito.Text).ToString("C") & "] aprobado al cliente. La factura no se generará.", "Excede crédito otorgado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ControlSuperClave = 1
                Else
                    ControlSuperClave = 0
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarFactVencidas()
        If lblDiasCondicion.Text > 0 Then
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select FechaVencimiento from FacturaDatos where IDCliente= '" + txtIDCliente.Text + "' and Balance>0 and FechaVencimiento<'" + Today.ToString("yyyy-MM-dd") + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FacturaDatos")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

            If Tabla.Rows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("El cliente: " & txtNombre.Text & " [" & txtIDCliente.Text & "] tiene factura vencidas." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Exiten Facturas Vencidas", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    frm_superclave.IDAccion.Text = 49
                    frm_superclave.ShowDialog(Me)
                Else
                    ControlSuperClave = 1
                End If
            End If
            BuscarLimiteCredito()
        End If
    End Sub


    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento='" + lblIDTipoDocumento.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecond, UltSecuencia As New Label

            lblSecond.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            lblSecondID.Text = lblSecond.Text

            sqlQ = "UPDATE FacturaDatos SET SecondID='" + lblSecond.Text + "' WHERE IDFacturaDatos='" + lblIDFactura.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento='" + lblIDTipoDocumento.Text + "'"
            GuardarDatos()


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarSeriales()
        Dim Counter As Integer = DgvArticulos.Rows.Count
        Dim x As Integer = 0
        Dim IDArticulo, SerialValue, Control As New Label
        Control.Text = 0

        Try
Inicio:
            If x = Counter Then
                GoTo Fin
            End If

            IDArticulo.Text = DgvArticulos.Rows(x).Cells(4).Value

            ConLibregco.Open()
            cmd = New MySqlCommand("Select Serial from Articulos Where IDArticulo='" + IDArticulo.Text + "'", ConLibregco)
            SerialValue.Text = Convert.ToDouble(cmd.ExecuteScalar())
            ConLibregco.Close()

            If CDbl(SerialValue.Text) = CDbl(1) Then
                Control.Text = 1
            Else
                x = x + 1
                GoTo inicio
            End If

            x = x + 1
            GoTo Inicio
Fin:
            If Control.Text = 1 Then
                frm_introducir_seriales.ShowDialog(Me)
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub ConvertDouble()
        txtInicial.Text = CDbl(txtInicial.Text)
        txtAdicional.Text = CDbl(txtAdicional.Text)
        lblSubTotal.Text = CDbl(lblSubTotal.Text)
        lblItbis.Text = CDbl(lblItbis.Text)
        lblDescuento.Text = CDbl(lblDescuento.Text)
        lblFlete.Text = CDbl(lblFlete.Text)
        lblTotalNeto.Text = CDbl(lblTotalNeto.Text)
        txtBalance.Text = CDbl(txtBalance.Text)
        txtMontoPagos.Text = CDbl(txtMontoPagos.Text)
    End Sub

    Sub ConvertCurrent()
        txtInicial.Text = CDbl(txtInicial.Text).ToString("C")
        txtAdicional.Text = CDbl(txtAdicional.Text).ToString("C")
        lblSubTotal.Text = CDbl(lblSubTotal.Text).ToString("C")
        lblItbis.Text = CDbl(lblItbis.Text).ToString("C")
        lblDescuento.Text = CDbl(lblDescuento.Text).ToString("C")
        lblFlete.Text = CDbl(lblFlete.Text).ToString("C")
        lblTotalNeto.Text = CDbl(lblTotalNeto.Text).ToString("C")
        txtBalance.Text = CDbl(txtBalance.Text).ToString("C")
        txtMontoPagos.Text = CDbl(txtMontoPagos.Text).ToString("C")
    End Sub

    Private Sub UltFactura()
        If lblIDFactura.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos where IDFacturaDatos= (Select Max(IDFacturaDatos) from FacturaDatos)", Con)
            lblIDFactura.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub InsertPagares()
        Try
            Dim lblIDPagare, IDFactura, lblNoPagare, lblCantidad, lblFechaVencimiento, lblDiasVencidos, lblConcepto, lblMonto, lblCargos, lblBalance, lblIDEmpleado, lblIDStatus, lblNota, lblNulo As New Label
            Dim x As Integer = 0
            Dim Counter As Integer = DgvPagares.RowCount

            If lblDiasCondicion.Text > 0 Then
Inicio:
                If x = Counter Then
                    GoTo Fin
                End If

                lblIDPagare.Text = DgvPagares.Rows(x).Cells(0).Value
                IDFactura.Text = lblIDFactura.Text
                lblNoPagare.Text = DgvPagares.Rows(x).Cells(2).Value
                lblCantidad.Text = DgvPagares.Rows(x).Cells(3).Value
                lblFechaVencimiento.Text = DgvPagares.Rows(x).Cells(4).Value()
                lblDiasVencidos.Text = 0
                lblConcepto.Text = DgvPagares.Rows(x).Cells(5).Value
                lblMonto.Text = CDbl(DgvPagares.Rows(x).Cells(6).Value)
                lblBalance.Text = CDbl(DgvPagares.Rows(x).Cells(7).Value)
                lblIDEmpleado.Text = DefaultIDCobrador
                lblIDStatus.Text = 1
                lblNota.Text = ""
                lblNulo.Text = 0

                If lblIDPagare.Text = "" Then
                    sqlQ = "INSERT INTO Pagares (IDTipoPagare,IDFactura,NoPagare,Cantidad,FechaVencimiento,DiasVencidos,Concepto,Monto,Balance,IDEmpleado,IDStatusPagare,Nota,Cargado,Nulo) VALUES (1,'" + lblIDFactura.Text + "','" + lblNoPagare.Text + "','" + lblCantidad.Text + "','" + lblFechaVencimiento.Text + "','" + lblDiasVencidos.Text + "','" + lblConcepto.Text + "','" + lblMonto.Text + "','" + lblBalance.Text + "','" + lblIDEmpleado.Text + "','" + lblIDStatus.Text + "','" + lblNota.Text + "',0,'" + lblNulo.Text + "')"
                    GuardarDatos()

                    Con.Open()
                    cmd = New MySqlCommand("Select IDPagare from Pagares where IDPagare= (Select Max(IDPagare) from Pagares)", Con)
                    DgvPagares.Rows(x).Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                Else
                    sqlQ = "UPDATE Pagares SET FechaVencimiento='" + lblFechaVencimiento.Text + "',Concepto='" + lblConcepto.Text + "',Monto='" + lblMonto.Text + "' WHERE IDPagare=(" + lblIDPagare.Text + ")"
                    GuardarDatos()
                End If

                x = x + 1
                GoTo Inicio

            End If
Fin:

            'Eliminar pagares modificados
            Dim IDPagareas As New Label
            If PagaresCreados.Count > 0 Then
                For Each PC As Integer In PagaresCreados
                    IDPagareas.Text = PC
                    sqlQ = "Delete from Pagares Where IDPagare = (" + IDPagareas.Text + ")"
                    GuardarDatos()
                Next
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarTablaPagares()
        Try
            DgvPagares.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("Select IDPagare,IDFactura,NoPagare,Cantidad,FechaVencimiento,Concepto,Monto,Balance from Pagares where IDFactura='" + lblIDFactura.Text + "'", Con)
            Dim LectorPagares As MySqlDataReader = Consulta.ExecuteReader

            While LectorPagares.Read
                DgvPagares.Rows.Add(LectorPagares.GetValue(0), LectorPagares.GetValue(1), LectorPagares.GetValue(2), LectorPagares.GetValue(3), LectorPagares.GetValue(4), LectorPagares.GetValue(5), LectorPagares.GetValue(6), LectorPagares.GetValue(7))
            End While
            LectorPagares.Close()
            Con.Close()
            PropiedadesDgvPagares()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Sub RefrescarTablaConsulta()
        Try
            DgvArticulos.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("Select IDFactArt,IDFactura,IDPrecio,IDMedida,FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,Cantidad,Medida,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo from facturaarticulos WHERE IDFactura='" + lblIDFactura.Text + "'", Con)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read
                DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13))
            End While

            LectorArticulos.Close()
            Con.Close()
            PropiedadesDgvArticulos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la factura.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            TabInfoFactura.SelectedIndex = 1
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtNombre.Text = "" Then
            MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombre.Enabled = True
            txtNombre.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarArticulo.Focus()
            Exit Sub
        ElseIf CDbl(lblDiasCondicion.Text) > 0 And (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
            Exit Sub
        ElseIf txtVendedor.Text = "" Then
            MessageBox.Show("Escriba el código del vendedor para registrar la venta.", "Código del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDVendedor.Focus()
            Exit Sub
        ElseIf DtEmpleado.Rows(0).item("IDSucursal").ToString() = "" Then
            MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf PerVentasSContrato = 0 And lblDiasCondicion.Text > 0 Then
            'BuscarCantidad de contratos a nombre del cliente
            cmd = New MySqlCommand("SELECT count(IDContrato) FROM contratos where IDCliente='" + txtIDCliente.Text + "' and FechaVencimiento>'" + Today + "'", Con)
            Dim CantContratos As String = Convert.ToString(cmd.ExecuteScalar())

            If CantContratos = 0 Then
                MessageBox.Show("No se han encontrado contratos de solicitud de crédito váalidos para procesar el crédito a procesar." & vbNewLine & vbNewLine & "Por favor realice un nuevo contrato para realizar créditos a nombre del cliente [" & txtIDCliente.Text & "] " & txtNombre.Text & ".", "No se encontraron contratos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        VerificarCreacionPagare()

        If lblIDFactura.Text = "" Then 'Si no hay factura
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                StatusCliente()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarCedulaenCredito()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarFactVencidas()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                If SolicitarAutCredito = 1 And lblDiasCondicion.Text > 0 Then
                    frm_autorizacion_acciones.ShowDialog(Me)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If

                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                GetNCFsNumbers(lblIDComprobante.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO Facturadatos (IDTipoDocumento,IDEquipo,IDEstadoFactura,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDTransaccion,NCF,NIF,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDChofer,IDVehiculo,IDVendedor,IDUsuario,Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Cargos,Balance,HabilitarFicha,DiasVencidos,Status,EntregarPorConduce,Observacion,Cierre,Impreso,Nulo) VALUES ('" + lblIDTipoDocumento.Text + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',1,'" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtRNC.Text + "','" + txtDireccion.Text + "','" + txtTelefono.Text + "', '" + lblIDTransaccion.Text + "','" + NewNCFValue.Text + "','" + txtNIF.Text + "','" + lblCondicion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + lblIDComprobante.Text + "','" + lblIDChofer.Text + "','" + lblIDVehiculo.Text + "','" + txtIDVendedor.Text + "','" + lblIDUsuario.Text + "','" + lblFecha.Text + "','" + lblHora.Text + "','" + txtInicial.Text + "','" + txtCantidadPagos.Text + "','" + txtMontoPagos.Text + "','" + txtAdicional.Text + "','" + txtFechaAdicional.Text + "','" + txtBalance.Text + "','" + txtFechaVencimiento.Text + "','" + lblNotaContado.Text + "','" + txtCondicionContado.Text + "','" + lblSubTotal.Text + "','" + lblDescuento.Text + "','" + lblItbis.Text + "','" + lblFlete.Text + "','" + lblTotalNeto.Text + "',0,'" + txtBalance.Text + "','" + lblFichaDatos.Text + "',0,'ACTIVA','" + lblchkEntregaConduce.Text + "','" + txtObservacion.Text + "',0,0,'" + lblDesactivar.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltFactura()
                SetSecondID()
                InsertArticulos()
                InsertPagares()
                CalcInventario()
                CalcularBalances()
                BuscarSeriales()
                lblDescripcion.Text = "Gracias por su compra"
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If IsModifiable(lblIDFactura.Text) = 0 Then
                MessageBox.Show("Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad.", "La factura no se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "UPDATE FacturaDatos SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text + "',TelefonosFactura='" + txtTelefono.Text + "',IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + lblCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDComprobanteFiscal='" + lblIDComprobante.Text + "',IDChofer='" + lblIDChofer.Text + "',IDVehiculo='" + lblIDVehiculo.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + lblFecha.Text + "',Hora='" + lblHora.Text + "',DiasCondicion='" + txtDiasCondicion.Text + "',Inicial='" + txtInicial.Text + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + txtMontoPagos.Text + "',PagoAdicional='" + txtAdicional.Text + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + txtBalance.Text + "',FechaVencimiento='" + txtFechaVencimiento.Text + "',NotaContado='" + lblNotaContado.Text + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + lblSubTotal.Text + "',Descuento='" + lblDescuento.Text + "',Itbis='" + lblItbis.Text + "',Flete='" + lblFlete.Text + "',TotalNeto='" + lblTotalNeto.Text + "',HabilitarFicha='" + lblFichaDatos.Text + "',EntregarPorConduce='" + lblchkEntregaConduce.Text + "',Observacion='" + txtObservacion.Text + "',Nulo='" + lblDesactivar.Text + "' WHERE IDFacturaDatos= (" + lblIDFactura.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcInventario()
                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub CalcInventario()
        CalcExistencia()
        CalcExistenciaAlm()
    End Sub

    Private Sub CalcularBalances()
        FunctCalcBcesFact(txtIDCliente.Text)
        FunctCalcBceGral(txtIDCliente.Text)
    End Sub

    Private Sub CalcExistenciaAlm()
        Dim IDArticulo, IDPrecio As String

        For Each Row As DataGridViewRow In DgvArticulos.Rows
            IDArticulo = Row.Cells(4).Value
            IDPrecio = Row.Cells(2).Value
            FunctCalcInvAlmacenes(IDArticulo, IDPrecio)
        Next

    End Sub

    Private Sub CalcExistencia()
        Dim IDArticulo As String

        For Each Row As DataGridViewRow In DgvArticulos.Rows
            IDArticulo = Row.Cells(4).Value
            FunctCalcInventarioGral(IDArticulo)
        Next

    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If lblIDFactura.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea imprimir la factura?", "Imprimir Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            Else
                Exit Sub
            End If
        End If

        If DgvPagares.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir los pagarés de la factura?", "Impresión de pagarés", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                If frm_pagares.Visible = True Then
                    If frm_pagares.WindowState = FormWindowState.Minimized Then
                        frm_pagares.WindowState = FormWindowState.Normal
                    Else
                        frm_pagares.Activate()
                    End If
                    frm_pagares.lblIDFactura.Text = lblIDFactura.Text
                    frm_pagares.txtFactura.Text = lblSecondID.Text
                    frm_pagares.rdbPresentacion.Checked = True
                    frm_pagares.btnBuscar.PerformClick()
                Else
                    frm_pagares.Show(Me)
                    frm_pagares.lblIDFactura.Text = lblIDFactura.Text
                    frm_pagares.txtFactura.Text = lblSecondID.Text
                    frm_pagares.rdbPresentacion.Checked = True
                    frm_pagares.btnBuscar.PerformClick()

                End If
            End If
        End If
    End Sub

    Private Sub InsertArticulos()
        Dim IDFactArt, IDFactura, IDPrecio, IDMedida, CantidadArticulos, Medida, IDArticulo, Descripcion, Precio, Descuento, Itbis, Importe, IDAlmacen, NivelPrecioArticulo As New Label

        Dim x As Integer = 0
        Dim Counter As Integer = DgvArticulos.RowCount

Inicio:

        If x = Counter Then
            GoTo Fin
        End If

        IDFactArt.Text = DgvArticulos.Rows(x).Cells(0).Value
        IDFactura.Text = DgvArticulos.Rows(x).Cells(1).Value
        IDPrecio.Text = DgvArticulos.Rows(x).Cells(2).Value
        IDMedida.Text = DgvArticulos.Rows(x).Cells(3).Value
        IDArticulo.Text = DgvArticulos.Rows(x).Cells(4).Value
        Descripcion.Text = DgvArticulos.Rows(x).Cells(5).Value
        CantidadArticulos.Text = DgvArticulos.Rows(x).Cells(6).Value
        Medida.Text = DgvArticulos.Rows(x).Cells(7).Value
        Precio.Text = CDbl(DgvArticulos.Rows(x).Cells(8).Value)
        Descuento.Text = CDbl(DgvArticulos.Rows(x).Cells(9).Value)
        Itbis.Text = CDbl(DgvArticulos.Rows(x).Cells(10).Value)
        Importe.Text = CDbl(DgvArticulos.Rows(x).Cells(11).Value)
        IDAlmacen.Text = DgvArticulos.Rows(x).Cells(12).Value
        NivelPrecioArticulo.Text = DgvArticulos.Rows(x).Cells(13).Value()

        If IDFactura.Text = "" Then
            sqlQ = "INSERT INTO FacturaArticulos (IDFactura,IDPrecio,IDArticulo,IDMedida,Medida,Cantidad,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo) VALUES ('" + lblIDFactura.Text + "', '" + IDPrecio.Text + "','" + IDArticulo.Text + "','" + IDMedida.Text + "','" + Medida.Text + "','" + CantidadArticulos.Text + "','" + Descripcion.Text + "','" + Precio.Text + "','" + Descuento.Text + "','" + Itbis.Text + "','" + Importe.Text + "','" + IDAlmacen.Text + "','" + NivelPrecioArticulo.Text + "')"
            GuardarDatos()
        Else
            sqlQ = "UPDATE FacturaArticulos SET IDFactura='" + IDFactura.Text + "',IDPrecio='" + IDPrecio.Text + "'IDMedida='" + IDMedida.Text + "',Medida='" + Medida.Text + "',Cantidad='" + CantidadArticulos.Text + "',Descripcion='" + Descripcion.Text + "',PrecioUnitario='" + Precio.Text + "',Descuento='" + Descuento.Text + "',Itbis='" + Itbis.Text + "',Importe='" + Importe.Text + "',IDAlmacen='" + IDAlmacen.Text + "',NivelPrecioArticulo='" + NivelPrecioArticulo.Text + "' Where IDFactArt='" + IDFactArt.Text + "'"
            GuardarDatos()
        End If

        x = x + 1
        GoTo Inicio
Fin:
        RefrescarTablaConsulta()

    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La factura No. " & lblIDFactura.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 45
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkDesactivar.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE FacturaDatos SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text + "',TelefonosFactura='" + txtTelefono.Text + "',IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + lblCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDComprobanteFiscal='" + lblIDComprobante.Text + "',IDChofer='" + lblIDChofer.Text + "',IDVehiculo='" + lblIDVehiculo.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + lblFecha.Text + "',Hora='" + lblHora.Text + "',DiasCondicion='" + txtDiasCondicion.Text + "',Inicial='" + txtInicial.Text + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + txtMontoPagos.Text + "',PagoAdicional='" + txtAdicional.Text + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + txtBalance.Text + "',FechaVencimiento='" + txtFechaVencimiento.Text + "',NotaContado='" + lblNotaContado.Text + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + lblSubTotal.Text + "',Descuento='" + lblDescuento.Text + "',Itbis='" + lblItbis.Text + "',Flete='" + lblFlete.Text + "',TotalNeto='" + lblTotalNeto.Text + "',HabilitarFicha='" + lblFichaDatos.Text + "',EntregarPorConduce='" + lblchkEntregaConduce.Text + "',Observacion='" + txtObservacion.Text + "',Nulo='" + lblDesactivar.Text + "' WHERE IDFacturaDatos= (" + lblIDFactura.Text + ")"
                GuardarDatos()
                CalcularBalances()
                ConvertCurrent()
                CalcExistencia()
                CalcExistenciaAlm()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf lblIDFactura.Text = "" Then
            MessageBox.Show("No hay un registro de factura abierto para anular.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la factura No. " & lblIDFactura.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 44
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkDesactivar.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE FacturaDatos SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text + "',TelefonosFactura='" + txtTelefono.Text + "',IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + lblCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDComprobanteFiscal='" + lblIDComprobante.Text + "',IDChofer='" + lblIDChofer.Text + "',IDVehiculo='" + lblIDVehiculo.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + lblFecha.Text + "',Hora='" + lblHora.Text + "',DiasCondicion='" + txtDiasCondicion.Text + "',Inicial='" + txtInicial.Text + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + txtMontoPagos.Text + "',PagoAdicional='" + txtAdicional.Text + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + txtBalance.Text + "',FechaVencimiento='" + txtFechaVencimiento.Text + "',NotaContado='" + lblNotaContado.Text + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + lblSubTotal.Text + "',Descuento='" + lblDescuento.Text + "',Itbis='" + lblItbis.Text + "',Flete='" + lblFlete.Text + "',TotalNeto='" + lblTotalNeto.Text + "',HabilitarFicha='" + lblFichaDatos.Text + "',EntregarPorConduce='" + lblchkEntregaConduce.Text + "',Observacion='" + txtObservacion.Text + "',Nulo='" + lblDesactivar.Text + "' WHERE IDFacturaDatos= (" + lblIDFactura.Text + ")"
                GuardarDatos()
                CalcularBalances()
                ConvertCurrent()
                CalcExistencia()
                CalcExistenciaAlm()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub


    Private Sub txtInicial_TextChanged(sender As Object, e As EventArgs) Handles txtInicial.TextChanged
        CalcularMontoPago()
    End Sub

    Private Sub txtAdicional_Leave(sender As Object, e As EventArgs) Handles txtAdicional.Leave
        If txtAdicional.Text = "" Then
            txtAdicional.Text = CDbl(0).ToString("C")
            txtFechaAdicional.Clear()

        Else
            txtAdicional.Text = CDbl(txtAdicional.Text).ToString("C")
        End If
        ValidacionEnAdicional()
    End Sub

    Private Sub ValidacionEnAdicional()
        Dim Balance, Adicional As Double
        Balance = txtBalance.Text
        Adicional = txtAdicional.Text

        If Adicional > 0 And Adicional >= Balance Then
            MessageBox.Show("El adicional introducido en la factura es mayor o igual al balance a pagar. Verifique los datos y/o la condición de la factura.", "Error en el adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtAdicional.Text = CDbl(0).ToString("C")
            txtAdicional.Focus()
            Exit Sub
        End If

        If CDbl(txtAdicional.Text) > 0 Then
            txtFechaAdicional.Enabled = True
            txtFechaAdicional.Focus()
        Else
            txtFechaAdicional.Enabled = False
        End If
    End Sub

    Private Sub IrAOtrasInformacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrAOtrasInformacionesToolStripMenuItem.Click
        TabInfoFactura.SelectedIndex = 0
    End Sub

    Private Sub IrAOpcionesDeCréditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrAOpcionesDeCréditoToolStripMenuItem.Click
        TabInfoFactura.SelectedIndex = 1
    End Sub

    Private Sub IrADatosDelClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrADatosDelClienteToolStripMenuItem.Click
        TabInfoFactura.SelectedIndex = 2
    End Sub

    Private Sub IrADatosDeLaFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrADatosDeLaFacturaToolStripMenuItem.Click
        TabInfoFactura.SelectedIndex = 3
    End Sub

    Private Sub BuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarArtículosToolStripMenuItem.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub EnfocarBuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnfocarBuscarArtículosToolStripMenuItem.Click
        txtIDArticulo.Focus()
    End Sub


    Private Sub btnModificarPrecio_Click(sender As Object, e As EventArgs) Handles btnModificarPrecio.Click
        Try
            If DgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay articulos para modificar su precio.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If DgvArticulos.Rows.Count > 0 And lblIDFactura.Text = "" Then
                frm_cambiar_precio_lite.lblIDPrecio.Text = DgvArticulos.CurrentRow.Cells(2).Value
                frm_cambiar_precio_lite.txtIDArticulo.Text = DgvArticulos.CurrentRow.Cells(4).Value
                frm_cambiar_precio_lite.lblIDMedida.Text = DgvArticulos.CurrentRow.Cells(3).Value
                frm_cambiar_precio_lite.txtDescripcion.Text = DgvArticulos.CurrentRow.Cells(5).Value
                frm_cambiar_precio_lite.txtMedida.Text = DgvArticulos.CurrentRow.Cells(7).Value
                frm_cambiar_precio_lite.txtPrecioActual.Text = (CDbl(DgvArticulos.CurrentRow.Cells(11).Value) / CDbl(DgvArticulos.CurrentRow.Cells(6).Value)).ToString("C")
                frm_cambiar_precio_lite.txtPrecio.Clear()
                frm_cambiar_precio_lite.txtNivelPrecio.Text = DgvArticulos.CurrentRow.Cells(13).Value
                frm_cambiar_precio_lite.txtPrecio.Focus()
                frm_cambiar_precio_lite.ShowDialog(Me)
            End If

            If CInt(lblIDFactura.Text) <> "" Then
                MessageBox.Show("La función está deshabilitada para facturas procesadas.", "Función no válida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ModificarPreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarPreciosToolStripMenuItem.Click
        btnModificarPrecio.PerformClick()
    End Sub

    Private Sub txtIDArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDArticulo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cbxMedida.Focus()
        End If
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click

    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub btnConsultaRNC_Click(sender As Object, e As EventArgs) Handles btnConsultaRNC.Click
        frm_consulta_rnc.ShowDialog(Me)
    End Sub

    Private Sub btnCrearCliente_Click(sender As Object, e As EventArgs) Handles btnCrearCliente.Click
        frm_mant_clientes.ShowDialog(Me)
    End Sub

    Private Sub lblFlete_Click(sender As Object, e As EventArgs) Handles lblFlete.Click
        Dim Mensaje, Titulo, DefaultValue As String
        Dim MyValue As Object

        Mensaje = "Está ingresando un valor por concepto de flete en la factura." & vbNewLine & vbNewLine & "Ingrese el monto a aplicar."
        Titulo = "Flete de factura"
        DefaultValue = ""

        MyValue = InputBox(Mensaje, Titulo, DefaultValue)

        If MyValue Is "" Then
            MyValue = DefaultValue
        Else
            If IsNumeric(MyValue) Then
                lblFlete.Text = CDbl(MyValue).ToString("C")
            End If
        End If

        SumTotales()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la factura.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            TabInfoFactura.SelectedIndex = 1
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtNombre.Text = "" Then
            MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombre.Enabled = True
            txtNombre.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarArticulo.Focus()
            Exit Sub
        ElseIf CDbl(lblDiasCondicion.Text) > 0 And (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
            Exit Sub
        ElseIf txtVendedor.Text = "" Then
            MessageBox.Show("Escriba el código del vendedor para registrar la venta.", "Código del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDVendedor.Focus()
            Exit Sub
        ElseIf DtEmpleado.Rows(0).item("IDSucursal").ToString() = "" Then
            MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf PerVentasSContrato = 0 And lblDiasCondicion.Text > 0 Then
            'BuscarCantidad de contratos a nombre del cliente
            cmd = New MySqlCommand("SELECT count(IDContrato) FROM contratos where IDCliente='" + txtIDCliente.Text + "' and FechaVencimiento>'" + Today + "'", Con)
            Dim CantContratos As String = Convert.ToString(cmd.ExecuteScalar())

            If CantContratos = 0 Then
                MessageBox.Show("No se han encontrado contratos de solicitud de crédito váalidos para procesar el crédito a procesar." & vbNewLine & vbNewLine & "Por favor realice un nuevo contrato para realizar créditos a nombre del cliente [" & txtIDCliente.Text & "] " & txtNombre.Text & ".", "No se encontraron contratos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        VerificarCreacionPagare()

        If lblIDFactura.Text = "" Then 'Si no hay factura
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                StatusCliente()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarCedulaenCredito()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarFactVencidas()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                If SolicitarAutCredito = 1 And lblDiasCondicion.Text > 0 Then
                    frm_autorizacion_acciones.ShowDialog(Me)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If

                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                GetNCFsNumbers(lblIDComprobante.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO Facturadatos (IDTipoDocumento,IDEquipo,IDEstadoFactura,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDTransaccion,NCF,NIF,IDCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDChofer,IDVehiculo,IDVendedor,IDUsuario,Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Cargos,Balance,HabilitarFicha,DiasVencidos,Status,EntregarPorConduce,Observacion,Cierre,Impreso,Nulo) VALUES ('" + lblIDTipoDocumento.Text + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',1,'" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtRNC.Text + "','" + txtDireccion.Text + "','" + txtTelefono.Text + "', '" + lblIDTransaccion.Text + "','" + NewNCFValue.Text + "','" + txtNIF.Text + "','" + lblCondicion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + lblIDComprobante.Text + "','" + lblIDChofer.Text + "','" + lblIDVehiculo.Text + "','" + txtIDVendedor.Text + "','" + lblIDUsuario.Text + "','" + lblFecha.Text + "','" + lblHora.Text + "','" + txtInicial.Text + "','" + txtCantidadPagos.Text + "','" + txtMontoPagos.Text + "','" + txtAdicional.Text + "','" + txtFechaAdicional.Text + "','" + txtBalance.Text + "','" + txtFechaVencimiento.Text + "','" + lblNotaContado.Text + "','" + txtCondicionContado.Text + "','" + lblSubTotal.Text + "','" + lblDescuento.Text + "','" + lblItbis.Text + "','" + lblFlete.Text + "','" + lblTotalNeto.Text + "',0,'" + txtBalance.Text + "','" + lblFichaDatos.Text + "',0,'ACTIVA','" + lblchkEntregaConduce.Text + "','" + txtObservacion.Text + "',0,0,'" + lblDesactivar.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltFactura()
                SetSecondID()
                InsertArticulos()
                InsertPagares()
                CalcInventario()
                CalcularBalances()
                BuscarSeriales()
                lblDescripcion.Text = "Gracias por su compra"
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()

            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If IsModifiable(lblIDFactura.Text) = 0 Then
                MessageBox.Show("Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad.", "La factura no se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "UPDATE FacturaDatos SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text + "',TelefonosFactura='" + txtTelefono.Text + "',IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + lblCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDComprobanteFiscal='" + lblIDComprobante.Text + "',IDChofer='" + lblIDChofer.Text + "',IDVehiculo='" + lblIDVehiculo.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + lblFecha.Text + "',Hora='" + lblHora.Text + "',DiasCondicion='" + txtDiasCondicion.Text + "',Inicial='" + txtInicial.Text + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + txtMontoPagos.Text + "',PagoAdicional='" + txtAdicional.Text + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + txtBalance.Text + "',FechaVencimiento='" + txtFechaVencimiento.Text + "',NotaContado='" + lblNotaContado.Text + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + lblSubTotal.Text + "',Descuento='" + lblDescuento.Text + "',Itbis='" + lblItbis.Text + "',Flete='" + lblFlete.Text + "',TotalNeto='" + lblTotalNeto.Text + "',HabilitarFicha='" + lblFichaDatos.Text + "',EntregarPorConduce='" + lblchkEntregaConduce.Text + "',Observacion='" + txtObservacion.Text + "',Nulo='" + lblDesactivar.Text + "' WHERE IDFacturaDatos= (" + lblIDFactura.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcInventario()
                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnModificarCliente_Click(sender As Object, e As EventArgs) Handles btnModificarCliente.Click
        If txtDireccion.Enabled = False Then
            txtDireccion.ReadOnly = False
            txtDireccion.Enabled = True
            txtTelefono.ReadOnly = False
            txtTelefono.Enabled = True
            txtNombre.ReadOnly = False
            txtNombre.Enabled = True
            txtRNC.ReadOnly = False
            txtRNC.Enabled = True
            txtNombre.Focus()
        Else
            txtDireccion.ReadOnly = True
            txtDireccion.Enabled = False
            txtTelefono.ReadOnly = True
            txtTelefono.Enabled = False
            txtNombre.ReadOnly = True
            txtNombre.Enabled = False
            txtRNC.ReadOnly = True
            txtRNC.Enabled = False
        End If
    End Sub

    Private Sub DgvArticulos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvArticulos.CellFormatting
        If e.ColumnIndex = Me.DgvArticulos.Columns(12).Index AndAlso (e.Value IsNot Nothing) Then

            With Me.DgvArticulos.Rows(e.RowIndex).Cells(e.ColumnIndex)
                Dim IDAlmacen As String = DgvArticulos.CurrentRow.Cells(12).Value
                Con.Open()
                cmd = New MySqlCommand("Select Almacen from Almacen where IDAlmacen='" + IDAlmacen + "'", Con)
                Dim Almacen As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                .ToolTipText = Almacen
            End With
        End If
    End Sub

    Private Sub DgvArticulos_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvArticulos.CellMouseMove
        If e.ColumnIndex = 12 Then
            If DgvArticulos.Rows.Count = 0 Then
            Else
                Cursor.Current = Cursors.Hand
            End If
        End If
    End Sub

    Private Sub DgvArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 12 Then
                frm_cambiar_almacenes_fact.IDPrecios.Text = DgvArticulos.CurrentRow.Cells(2).Value
                frm_cambiar_almacenes_fact.Show(Me)
            End If
        End If
    End Sub

    Private Sub txtIDVendedor_Leave(sender As Object, e As EventArgs) Handles txtIDVendedor.Leave
        If ChangedCodeEmployee = True And txtIDVendedor.Text <> "" Then
            frm_contraseña_empleado.txtUsuario.Tag = txtIDVendedor.Text
            frm_contraseña_empleado.ShowDialog(Me)
        Else
            If txtIDVendedor.Text <> "" Then
                If txtVendedor.Text = "" Then
                    frm_contraseña_empleado.txtUsuario.Tag = txtIDVendedor.Text
                    frm_contraseña_empleado.ShowDialog(Me)
                End If
            Else
                txtIDVendedor.Clear()
                txtVendedor.Clear()
            End If
        End If
    End Sub

    Private Sub chkEntregarporConduce_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntregarporConduce.CheckedChanged
        If chkEntregarporConduce.Checked = True Then
            lblchkEntregaConduce.Text = 1
        Else
            lblchkEntregaConduce.Text = 0
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_cliente_factura.ShowDialog(Me)
    End Sub

    Private Sub txtIDVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtIDVendedor.TextChanged
        ChangedCodeEmployee = True
    End Sub

    Private Sub cbxPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPrecio.SelectedIndexChanged
        Try
            If txtIDArticulo.Text <> "" And cbxMedida.Text <> "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtIDArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
                lblIDPrecio.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                lblPrecioArticulo.Text = CDbl(GetPrices(cbxPrecio.Text, txtIDArticulo.Text, lblIDMedida.Text, 1)).ToString("C")

            End If


        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.IDCondicion,Condicion.Condicion,Condicion.Dias,FacturaDatos.IDCliente,NombreFactura,DireccionFactura,TelefonosFactura,Clientes.Nombre,IDFacturaDatos,FacturaDatos.SecondID,IDTipoDocumento,IDTransaccion,Fecha,Hora,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FacturaDatos.Balance,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Observacion,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=FacturaDatos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.BalanceGeneral,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDVehiculo,Vehiculo.DatoVehiculo,FacturaDatos.IDVendedor,Vendedor.Nombre as Vendedor,FacturaDatos.IDChofer,Chofer.Nombre as Chofer,FacturaDatos.IDAlmacen,Almacen.Almacen,HabilitarFicha,NotaContado,FacturaDatos.EntregarPorConduce,FacturaDatos.Nulo from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Vehiculo on FacturaDatos.IDVehiculo=Vehiculo.IDVehiculo INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Chofer on FacturaDatos.IDChofer=Chofer.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where IDFacturaDatos= (Select Max(IDFacturaDatos) from" & SysName.Text & "FacturaDatos)", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "FacturaDatos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("FacturaDatos")
            frm_superclave.IDAccion.Text = 32
            frm_superclave.ShowDialog(Me)
            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            txtNombre.Text = (Tabla.Rows(0).Item("NombreFactura"))
            txtDireccion.Text = (Tabla.Rows(0).Item("DireccionFactura"))
            txtTelefono.Text = (Tabla.Rows(0).Item("TelefonosFactura"))
            lblIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
            lblSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
            txtDiasCondicion.Text = (Tabla.Rows(0).Item("Dias"))
            lblIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
            lblIDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
            lblFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            lblHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            txtInicial.Text = (Tabla.Rows(0).Item("Inicial"))
            txtCantidadPagos.Text = (Tabla.Rows(0).Item("CantidadPagos"))
            txtMontoPagos.Text = (Tabla.Rows(0).Item("MontoPagos"))
            txtAdicional.Text = (Tabla.Rows(0).Item("PagoAdicional"))
            txtFechaAdicional.Text = (Tabla.Rows(0).Item("FechaAdicional"))
            txtBalance.Text = (Tabla.Rows(0).Item("NetoFactura"))
            txtFechaVencimiento.Text = CDate(Tabla.Rows(0).Item("FechaVencimiento")).ToString("yyyy-MM-dd")
            txtCondicionContado.Text = (Tabla.Rows(0).Item("CondicionContado"))
            lblSubTotal.Text = (Tabla.Rows(0).Item("SubTotal"))
            lblDescuento.Text = (Tabla.Rows(0).Item("Descuento"))
            lblItbis.Text = (Tabla.Rows(0).Item("Itbis"))
            lblFlete.Text = (Tabla.Rows(0).Item("Flete"))
            lblTotalNeto.Text = (Tabla.Rows(0).Item("TotalNeto"))
            lblTotalNeto2.Text = (Tabla.Rows(0).Item("TotalNeto"))
            txtObservacion.Text = (Tabla.Rows(0).Item("Observacion"))
            txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
            txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            txtCobrador.Text = (Tabla.Rows(0).Item("Cobrador"))
            CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
            txtIDVendedor.Text = (Tabla.Rows(0).Item("IDVendedor"))
            cbxVehiculo.Text = (Tabla.Rows(0).Item("Datovehiculo"))
            txtVendedor.Text = (Tabla.Rows(0).Item("Vendedor"))
            CbxChofer.Text = (Tabla.Rows(0).Item("Chofer"))
            cbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

            If (Tabla.Rows(0).Item("HabilitarFicha")) = 0 Then
                chkFichaDatos.Checked = False
            Else
                chkFichaDatos.Checked = True
            End If
            If (Tabla.Rows(0).Item("NotaContado")) = 0 Then
                chkHabilitarNota.Checked = False
            Else
                chkHabilitarNota.Checked = True
            End If
            If (Tabla.Rows(0).Item("EntregarPorConduce")) = 0 Then
                chkEntregarporConduce.Checked = False
            Else
                chkEntregarporConduce.Checked = True
            End If
            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                chkDesactivar.Checked = False
            Else
                chkDesactivar.Checked = True
            End If

            RefrescarTablaConsulta()
            RefrescarTablaPagares()
            SumTotales()
            ConvertCurrent()
            'DeshabilitarControles()

            If IsModifiable(Tabla.Rows(0).Item("IDFacturaDatos")) = 0 Then
                lblStatusBar.Text = "Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad."
            Else
                lblStatusBar.Text = "Listo"
            End If

            PicImage.Image = Nothing
            lblTipoProducto.Text = "Tipo Producto: "
            lblDepartamento.Text = "Departamento: "
            lblCategoria.Text = "Categoría: "
            lblSubCategoria.Text = "SubCategoría: "
            lblTipoItbis.Text = "Tipo de Itbis: "
            lblMarca.Text = "Marca: "

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class