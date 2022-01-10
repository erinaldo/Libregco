Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_consulta_cotizacion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDCondicion, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDCotizacion,Cotizacion.SecondID,Fecha,Cotizacion.IDCondicion,Condicion,IDVendedor,Cotizacion.IDCliente,NombreCotizacion,TotalNeto,Cotizacion.Nulo,if(EstadoCotizacion=0,'Abierta',IF(EstadoCotizacion=1,'En proceso',if(EstadoCotizacion=2,'Cerrada',''))) as Estado FROM" & SysName.Text & "Cotizacion INNER JOIN Libregco.condicion ON Cotizacion.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Clientes ON Cotizacion.IDCliente=Clientes.IDCliente"
    Dim FullCommand, FechaValue, IDClienteValue, IDVendedorValue, NuloValue, CondicionValue As String
    Dim A1, A2, A3, A4 As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_cotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDCotizacion,Cotizacion.SecondID,Fecha,Cotizacion.IDCondicion,Condicion,IDVendedor,Cotizacion.IDCliente,NombreCotizacion,TotalNeto,Cotizacion.Nulo,if(EstadoCotizacion=0,'Abierta',IF(EstadoCotizacion=1,'En proceso',if(EstadoCotizacion=2,'Cerrada',''))) as Estado FROM" & SysName.Text & "Cotizacion INNER JOIN Libregco.condicion ON Cotizacion.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Clientes ON Cotizacion.IDCliente=Clientes.IDCliente WHERE Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Cotizacion.Nulo=0 ORDER BY IDCotizacion DESC", Con)
        RefrescarTabla()
        ConstructorSQL()
    End Sub

    Private Sub CargarLibregco()
      PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Cotización' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Cotizaciones' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtIDVendedor.Clear()
        txtVendedor.Clear()
        txtIDCliente.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
        cbxCondicion.Items.Clear()
        FillCondicion()
        lblIDCondicion.Text = 0
        cbxCondicion.Text = "Todas"
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
        cbxCondicion.Text = "Todas"
    End Sub

    Private Sub FillCondicion()
        Ds1.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Condicion FROM Condicion ORDER BY Condicion", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Condicion")
        cbxCondicion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds1.Tables("Condicion")
        Dim Fila As DataRow

        For Each Fila In Tabla.Rows
            cbxCondicion.Items.Add(Fila.Item("Condicion"))
        Next

        cbxCondicion.Items.Add("Todas")

    End Sub


    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            Con.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Cotizacion")
            DgvCotizaciones.DataSource = Ds
            DgvCotizaciones.DataMember = "Cotizacion"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            ColorearEstados()
            DgvCotizaciones.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvCotizaciones
            '.Columns(0).HeaderText = "Clave Primaria"
            '.Columns(0).Width = 100
            '.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Visible = False

            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 90

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns(2).Width = 80

            .Columns(3).Visible = False

            .Columns(4).Width = 110
            .Columns(4).HeaderText = "Condición"

            .Columns(5).Width = 45
            .Columns(5).HeaderText = "Vend"

            .Columns(6).Visible = False

            .Columns(7).Width = 240
            .Columns(7).HeaderText = "Cliente"

            .Columns(8).Width = 100
            .Columns(8).HeaderText = "Monto"
            .Columns(8).DefaultCellStyle.Format = ("C")

            .Columns(9).Visible = False

            .Columns(10).Width = 90
            .Columns(10).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvCotizaciones.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvCotizaciones.Rows(x).Cells(8).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvCotizaciones.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectCliente()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If txtCliente.Text = "" Then txtIDCliente.Clear()
    End Sub

    Private Sub SelectVendedor()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDVendedor.Text + "' and IDCargo=4", Con)
        txtVendedor.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If txtVendedor.Text = "" Then txtIDVendedor.Clear()
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        SelectCliente()
        VerificarCondicionCliente()
    End Sub

    Private Sub txtIDVendedor_Leave(sender As Object, e As EventArgs) Handles txtIDVendedor.Leave
        SelectVendedor()
        VerificarCondicionVendedor()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        If cbxCondicion.Text <> "Todas" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
            lblIDCondicion.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If

        VerificarCondicionValue()
    End Sub

    Private Sub VerificarCondicionVendedor()
        If txtIDVendedor.Text = "" Then
            IDVendedorValue = ""
        Else
            IDVendedorValue = " Cotizacion.IDVendedor=" & txtIDVendedor.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCliente()
        If txtIDCliente.Text = "" Then
            IDClienteValue = ""
        Else
            IDClienteValue = " Cotizacion.IDCliente=" & txtIDCliente.Text & " "
        End If

        If txtCliente.Text <> "" Then
            If txtIDCliente.Text <> "" Then
                IDClienteValue = IDClienteValue & " and Cotizacion.NombreCotizacion Like '%" & txtCliente.Text & "%'"
            Else
                IDClienteValue = " Cotizacion.NombreCotizacion Like '%" & txtCliente.Text & "%'"
            End If
        End If

        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionValue()
        If lblIDCondicion.Text = 0 Then
            CondicionValue = ""
        ElseIf lblIDCondicion.Text = 1 Then
            CondicionValue = " Cotizacion.IDCondicion=1 "
        ElseIf lblIDCondicion.Text = 2 Then
            CondicionValue = " Cotizacion.IDCondicion=2 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " Cotizacion.Nulo=0 "
        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionVendedor()
        VerificarCondicionCliente()
        VerificarCondicionFecha()
        VerificarCondicionValue()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDVendedorValue <> "" Or CondicionValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDVendedorValue & CondicionValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDVendedorValue & CondicionValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDVendedorValue <> "" And CondicionValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If CondicionValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDVendedorValue & A3 & CondicionValue & A4 & NuloValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvCotizaciones.Rows
                If CInt(Row.Cells(9).Value) = 1 Then
                    Row.DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoMemo_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoMemo.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub txtIDCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIDCliente.TextChanged
        VerificarCondicionCliente()
    End Sub

    Private Sub txtIDVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtIDVendedor.TextChanged
        VerificarCondicionVendedor()
    End Sub

    Private Sub DgvCotizaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCotizaciones.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDCotizacion,Cotizacion.IDCliente,NombreCotizacion,DireccionCotizacion,TelefonoCotizacion,Clientes.Nombre as NombreCliente,Clientes.Identificacion,IDUsuario,Cotizacion.Fecha,Cotizacion.Hora,Cotizacion.IDCondicion,Condicion.Condicion,IDVendedor,Vendedor.Nombre as Vendedor,Comentario,Cotizacion.SubTotal,Cotizacion.Descuento,Cotizacion.Itbis,Cotizacion.Flete,Cotizacion.TotalNeto,Cotizacion.IDMoneda,TipoMoneda.Moneda,Cotizacion.Nulo,Clientes.IDCalificacion,Calificacion.Calificacion,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,IFNULL((Select Fecha from" & SysName.Text & "Abonos where Cotizacion.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Sum(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.BalanceGeneral,Clientes.Precio FROM" & SysName.Text & "cotizacion INNER JOIN Libregco.Clientes on Cotizacion.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Empleados as Vendedor on Cotizacion.IDVendedor=Vendedor.IDEmpleado INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.Condicion on Cotizacion.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.TipoMoneda on Cotizacion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal Where IDCotizacion='" + DgvCotizaciones.CurrentRow.Cells(0).Value.ToString + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Cotizacion")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds1.Tables("Cotizacion")

                If Me.Owner.Name = frm_facturacion.Name Then
                    frm_facturacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_facturacion.txtNombre.Text = (Tabla.Rows(0).Item("NombreCotizacion"))
                    frm_facturacion.txtDireccion.Text = (Tabla.Rows(0).Item("DireccionCotizacion"))
                    frm_facturacion.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonoCotizacion"))
                    frm_facturacion.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                    frm_facturacion.txtVendedor.Tag = (Tabla.Rows(0).Item("IDVendedor"))
                    frm_facturacion.txtVendedor.Text = (Tabla.Rows(0).Item("Vendedor"))
                    frm_facturacion.txtFlete.Text = CDbl(Tabla.Rows(0).Item("Flete")).ToString("C")
                    frm_facturacion.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_facturacion.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
                    frm_facturacion.txtCobrador.Text = (Tabla.Rows(0).Item("Cobrador"))
                    frm_facturacion.txtCobrador.Tag = (Tabla.Rows(0).Item("IDCobrador"))
                    frm_facturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    frm_facturacion.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")

                    frm_facturacion.RefrescarBalances()

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_facturacion.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago"))
                    Else
                        frm_facturacion.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    frm_facturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))
                    frm_facturacion.NombreMoneda = Tabla.Rows(0).Item("Moneda")

                    PasarArticulos()

                    Close()

                ElseIf Me.Owner.Name = frm_prefacturacion.name Then
                    frm_prefacturacion.Cotizacion = DgvCotizaciones.CurrentRow.Cells(0).Value
                    frm_prefacturacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_prefacturacion.txtNombre.Text = (Tabla.Rows(0).Item("NombreCotizacion"))
                    frm_prefacturacion.DireccionCliente = (Tabla.Rows(0).Item("DireccionCotizacion"))
                    frm_prefacturacion.TelefonoCliente = (Tabla.Rows(0).Item("TelefonoCotizacion"))
                    frm_prefacturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    frm_prefacturacion.txtIDCondicion.Text = (Tabla.Rows(0).Item("IDCondicion"))
                    frm_prefacturacion.txtCondicion.Text = (Tabla.Rows(0).Item("Condicion")).ToString.ToUpper
                    frm_prefacturacion.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                    frm_prefacturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

                    If Tabla.Rows(0).Item("IDCliente") <> "1" Then
                        frm_prefacturacion.RNCliente = (Tabla.Rows(0).Item("Identificacion"))
                        frm_prefacturacion.lblIDTipoNCF.Text = Tabla.Rows(0).Item("IDComprobanteFiscal")
                        frm_prefacturacion.TipoNCF.Text = Tabla.Rows(0).Item("TipoComprobante")
                    End If

                    PasarArticulos()

                    Close()


                ElseIf Me.Owner.Name = frm_mdi_prefacturacion.name Then
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).Cotizacion = DgvCotizaciones.CurrentRow.Cells(0).Value
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtNombre.Text = (Tabla.Rows(0).Item("NombreCotizacion"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).DireccionCliente = (Tabla.Rows(0).Item("DireccionCotizacion"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TelefonoCliente = (Tabla.Rows(0).Item("TelefonoCotizacion"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDCondicion.Text = (Tabla.Rows(0).Item("IDCondicion"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtCondicion.Text = (Tabla.Rows(0).Item("Condicion")).ToString.ToUpper
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

                    If Tabla.Rows(0).Item("IDCliente") <> "1" Then
                        DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).RNCliente = (Tabla.Rows(0).Item("Identificacion"))
                        DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).lblIDTipoNCF.Text = Tabla.Rows(0).Item("IDComprobanteFiscal")
                        DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TipoNCF = Tabla.Rows(0).Item("TipoComprobante")
                    End If

                    'FillTablaPrecios
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaPrecio.Clear()
                    Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("SELECT CotizacionDetalle.IDPrecio as IDPrecios,Medida.Abreviatura,PrecioArticulo.IDMedida,Medida.Medida,Medida.Fraccionamiento,CotizacionDetalle.IDArticulo,PrecioArticulo.DescuentoMaximo,PrecioArticulo.Contenido from" & SysName.Text & "CotizacionDetalle LEFT JOIN Libregco.PrecioArticulo on CotizacionDetalle.IDArticulo=PrecioArticulo.IDArticulo LEFT JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida  Where CotizacionDetalle.IDCotizacion='" + Tabla.Rows(0).Item("IDCotizacion").ToString + "'", ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaPrecio.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaPrecio.EndLoadData()


                    'FillTablaExistencias
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaExistencia.Clear()
                    Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("SELECT Existencia.IDAlmacen,Sucursal.Sucursal,Almacen.Almacen,Existencia.Existencia,Medida.Medida,Existencia.IDPrecioArticulo,PrecioArticulo.IDArticulo,Existencia.IDExistencia FROM" & SysName.Text & "CotizacionDetalle LEFT JOIN Libregco.PrecioArticulo on CotizacionDetalle.IDArticulo=PrecioArticulo.IDArticulo LEFT JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida LEFT JOIN Libregco.Existencia on PrecioArticulo.IDPrecios=Existencia.IDPrecioArticulo LEFT JOIN Libregco.Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen LEFT JOIN Libregco.Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal WHERE CotizacionDetalle.IDCotizacion='" + Tabla.Rows(0).Item("IDCotizacion").ToString + "'", ConMixta)
                            ConMixta.Open()

                            Using myReader As MySqlDataReader = myCommand.ExecuteReader

                                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaExistencia.Load(myReader, LoadOption.Upsert)

                                ConMixta.Close()

                            End Using
                        End Using
                    End Using
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaExistencia.EndLoadData()


                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaArticulos.Clear()

                    Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select CotizacionDetalle.IDArticulo AS Busqueda,'' as IDFactArt,CotizacionDetalle.IDArticulo,IDPrecio,CotizacionDetalle.IDMedida,Cantidad,CotizacionDetalle.Descripcion,Articulos.Referencia,Round(CotizacionDetalle.PrecioUnitario+CotizacionDetalle.Descuento+(CotizacionDetalle.Itbis/CotizacionDetalle.Cantidad),8) as Precio,PrecioUnitario as PrecioSinItbis,(CotizacionDetalle.Descuento/Round(CotizacionDetalle.PrecioUnitario+CotizacionDetalle.Descuento+(CotizacionDetalle.Itbis/CotizacionDetalle.Cantidad),4)) as DescuentoPorc,CotizacionDetalle.Descuento,(CotizacionDetalle.Itbis/CotizacionDetalle.Cantidad) as Itbis,CotizacionDetalle.Importe,CotizacionDetalle.IDAlmacen,Nivel as Nivel,0 as Hijo,Fraccionamiento,(Select Existencia from Libregco.Existencia Where Existencia.IDPrecioArticulo=CotizacionDetalle.IDPrecio and Existencia.IDAlmacen=CotizacionDetalle.IDAlmacen) as Existencia,NoPermitirCambiarPrecio,NoPagoTarjeta,IDTipoProducto,TipoItbis.Itbis as PorcItbis,PrecioArticulo.DescuentoMaximo,Articulos.IDDepartamento,Articulos.IDCategoria,Articulos.IDSubCategoria,Articulos.IDMarca,CobrarComision,PorcentajeComision,VenderCosto,'' as Orden  from" & SysName.Text & "CotizacionDetalle INNER JOIN Libregco.Articulos on CotizacionDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Libregco.PrecioArticulo on CotizacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on CotizacionDetalle.IDMedida=Medida.IDMedida WHERE IDCotizacion='" + Tabla.Rows(0).Item("IDCotizacion").ToString + "'", ConMixta)
                            ConMixta.Open()

                            Using myReader As MySqlDataReader = myCommand.ExecuteReader

                                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaArticulos.Load(myReader, LoadOption.Upsert)

                                ConMixta.Close()

                            End Using
                        End Using
                    End Using

                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaArticulos.EndLoadData()

                    'Visualizando imagenes
                    If TypeConnection.Text = 1 Then
                        If DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).chkPreviewImages.Checked = True Then
                            ConLibregco.Open()

                            For Each rw As DataRow In DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TablaArticulos.Rows
                                cmd = New MySqlCommand("SELECT RutaFoto FROM libregco.Articulos Where IDArticulo='" + rw.Item("IDArticulo").ToString + "'", ConLibregco)
                                Dim Ruta As String = Convert.ToString(cmd.ExecuteScalar())

                                If Ruta <> "" Then
                                    Dim ExistFile As Boolean = System.IO.File.Exists(Ruta)
                                    If ExistFile = True Then
                                        Dim wFile As System.IO.FileStream
                                        wFile = New FileStream(Ruta, FileMode.Open, FileAccess.Read)
                                        rw.Item("Imagen") = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(178 - 1).Item("Value2Int"))
                                        wFile.Close()
                                    End If
                                End If
                            Next
                        End If

                        ConLibregco.Close()
                    End If


                    Close()


                End If


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " DgvCotizaciones_CellDoubleClick")
        End Try
    End Sub


    Private Sub PasarArticulos()
        Try
            Dim TmpConn As New MySqlConnection(CnGeneral)


            If Me.Owner.Name = frm_facturacion.Name Then
                frm_facturacion.dgvArticulosFactura.Rows.Clear()

                TmpConn.Open()
                Dim Consulta As New MySqlCommand("Select IDCotizacion,IDCotizacionDetalles,IDPrecio,CotizacionDetalle.IDMedida,Cantidad,CotizacionDetalle.Medida,CotizacionDetalle.IDArticulo,CotizacionDetalle.Descripcion,PrecioUnitario,Descuento,(Itbis/Cantidad) as Itbis,Importe,IDAlmacen,Nivel,Fraccionamiento,RutaFoto from" & SysName.Text & "CotizacionDetalle Inner join Libregco.PrecioArticulo on CotizacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where IDCotizacion='" + DgvCotizaciones.CurrentRow.Cells(0).Value.ToString + "'", TmpConn)
                Dim LectorArt As MySqlDataReader = Consulta.ExecuteReader
                While LectorArt.Read

                    Dim ProductImage As Image
                    If TypeConnection.Text = 1 Then
                        If LectorArt.GetValue(15) = "" Then
                            ProductImage = My.Resources.No_Image
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(LectorArt.GetValue(15))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(LectorArt.GetValue(15), FileMode.Open, FileAccess.Read)
                                ProductImage = System.Drawing.Image.FromStream(wFile)
                                wFile.Close()
                            Else
                                ProductImage = My.Resources.No_Image
                            End If
                        End If
                    Else
                        ProductImage = My.Resources.No_Image
                    End If

                    frm_facturacion.dgvArticulosFactura.Rows.Add("", "", LectorArt.GetValue(2), LectorArt.GetValue(3), LectorArt.GetValue(4), LectorArt.GetValue(5), LectorArt.GetValue(6), LectorArt.GetValue(7), LectorArt.GetValue(8), LectorArt.GetValue(9), LectorArt.GetValue(10), LectorArt.GetValue(11), LectorArt.GetValue(12), LectorArt.GetValue(13), 0, LectorArt.GetValue(14), ProductImage)

                End While
                LectorArt.Close()
                TmpConn.Close()

                frm_facturacion.SumTotales()
                frm_facturacion.CreatePagares()
                frm_facturacion.HabilitarEscCredito()

            ElseIf Me.Owner.name = frm_prefacturacion.name Then

                frm_prefacturacion.dgvArticulosFactura.Rows.Clear()

                TmpConn.Open()
                Dim Consulta As New MySqlCommand("Select IDCotizacion,IDCotizacionDetalles,IDPrecio,CotizacionDetalle.IDMedida,CotizacionDetalle.IDArticulo,Cantidad,CotizacionDetalle.Medida,CotizacionDetalle.Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,Nivel,Fraccionamiento,RutaFoto from" & SysName.Text & "CotizacionDetalle Inner join Libregco.PrecioArticulo on CotizacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where IDCotizacion='" + DgvCotizaciones.CurrentRow.Cells(0).Value.ToString + "'", TmpConn)
                Dim LectorArt As MySqlDataReader = Consulta.ExecuteReader
                While LectorArt.Read

                    'Dim ProductImage As Image
                    'If TypeConnection.Text = 1 Then
                    '    If LectorArt.GetValue(15) = "" Then
                    '        ProductImage = My.Resources.No_Image
                    '    Else
                    '        Dim ExistFile As Boolean = System.IO.File.Exists(LectorArt.GetValue(15))
                    '        If ExistFile = True Then
                    '            Dim wFile As System.IO.FileStream
                    '            wFile = New FileStream(LectorArt.GetValue(15), FileMode.Open, FileAccess.Read)
                    '            ProductImage = System.Drawing.Image.FromStream(wFile)
                    '            wFile.Close()
                    '        Else
                    '            ProductImage = My.Resources.No_Image
                    '        End If
                    '    End If
                    'Else
                    '    ProductImage = My.Resources.No_Image
                    'End If

                    frm_prefacturacion.dgvArticulosFactura.Rows.Add("", "", LectorArt.GetValue(2), LectorArt.GetValue(3), LectorArt.GetValue(4), LectorArt.GetValue(5), LectorArt.GetValue(6), LectorArt.GetValue(7), CDbl(CDbl(LectorArt.GetValue(8)) + (CDbl(LectorArt.GetValue(10)) / CDbl(LectorArt.GetValue(5)))), CDbl(LectorArt.GetValue(8)).ToString, CDbl(0), CDbl(CDbl(LectorArt.GetValue(10)) / CDbl(LectorArt.GetValue(5))), CDbl(LectorArt.GetValue(11)), LectorArt.GetValue(12), LectorArt.GetValue(13), 0, LectorArt.GetValue(14))

                End While
                LectorArt.Close()
                TmpConn.Close()

                frm_prefacturacion.SumTotales()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        SummaCond()
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))

        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Visible = False
        Else
            chkResumir.Visible = True
        End If
    End Sub


    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            Dim DsSP As New DataSet

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            'Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then
                frm_reportView.ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text)
            Else
                frm_reportView.ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            End If



            If DgvCotizaciones.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
                '@Cliente
                If txtIDCliente.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDCliente.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cliente")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Vendedor
                If txtIDVendedor.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDVendedor.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Vendedor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Calificacion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Calificacion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Condicion
                If cbxCondicion.Text = "Todas" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = lblIDCondicion.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                If chkNulos.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                Else
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Fecha
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Fecha")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .StartValue = txtFechaInicial.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = txtFechaFinal.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With

                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Cobrador
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cobrador")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Provincia
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Provincia")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Municipio
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Municipio")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoCredito
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoCredito")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@GrupoCxc
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@GrupoCxc")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Setting Info 
                'Resumir Reporte
                If chkResumir.Checked = True Then
                    frm_reportView.ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    frm_reportView.ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Ordenamiento de Reporte
                frm_reportView.ObjRpt.SetParameterValue("@SortedField", "")
                frm_reportView.ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Cotización")
                'RangoFechas()
                frm_reportView.ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                frm_reportView.ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvCotizaciones.SelectedRows.Count > 0 Then

                    If CStr(DgvCotizaciones.CurrentRow.Cells(0).Value).ToString = "" Then
                        MessageBox.Show("Vuelva a elegir la cotización que desea imprimir.")
                        Exit Sub
                    ElseIf DgvCotizaciones.SelectedRows(0).Cells(9).Value = 1 Then
                        MessageBox.Show("La cotización No. " & DgvCotizaciones.SelectedRows(0).Cells(1).Value & " de fecha " & DgvCotizaciones.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim cmdSP As New MySqlCommand
                    Dim AdaptadorSP As MySqlDataAdapter

                    'Consulta de los datos de la cotizacion   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AdaptadorSP = New MySqlDataAdapter("SELECT Cotizacion.IDCotizacion,Cotizacion.SecondID,Cotizacion.IDTipoDocumento,TipoDocumento.Documento,Cotizacion.IDCliente,Clientes.Nombre as NombreCliente,Clientes.Direccion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.IDMunicipio,Municipios.Municipio,Clientes.IDProvincia,Provincias.Provincia,NombreCotizacion,DireccionCotizacion,TelefonoCotizacion,Clientes.BalanceGeneral,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,Clientes.IDCalificacion,Calificacion,Fecha,Hora,Cotizacion.IDCondicion,Condicion.Condicion,Cotizacion.IDUsuario,Usuarios.Nombre as NombreUsuario,IDVendedor,Vendedor.Nombre as NombreVendedor,Comentario,SubTotal,Cotizacion.Descuento AS DescuentoCotizacion,Cotizacion.Itbis as ItbisCotizacion,Flete,TotalNeto,Cotizacion.Impreso,Cotizacion.Nulo,CotizacionDetalle.Cantidad,CotizacionDetalle.IDMedida,Medida.Medida,Medida.Abreviatura,CotizacionDetalle.IDArticulo,Articulos.Descripcion,Articulos.Referencia,CotizacionDetalle.PrecioUnitario,CotizacionDetalle.Descuento as DescuentoArticulo,CotizacionDetalle.Itbis as ItbisArticulo,CotizacionDetalle.Importe,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Cotizacion.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(Select Value1Var from" & SysName.Text & "Configuracion Where IDConfiguracion=53) as EncabezadodeCotizacion,(Select Value1Var from" & SysName.Text & "Configuracion Where IDConfiguracion=54) as PiedeCotizacion FROM" & SysName.Text & "Cotizacion INNER JOIN" & SysName.Text & "TipoDocumento on Cotizacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Clientes on Cotizacion.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Provincias ON Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios ON Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Cotizacion.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuarios on Cotizacion.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.Condicion on Cotizacion.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "CotizacionDetalle on Cotizacion.IDCotizacion=CotizacionDetalle.IDCotizacion INNER JOIN Libregco.Medida on CotizacionDetalle.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on CotizacionDetalle.IDArticulo=Articulos.IDArticulo WHERE Cotizacion.IDCotizacion='" + DgvCotizaciones.CurrentRow.Cells(0).Value.ToString + "'", Con)
                    AdaptadorSP.Fill(DsSP, "CotizacionView")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Llenado EmpresaView
                    AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                    AdaptadorSP.Fill(DsSP, "EmpresaView")

                    cmdSP.Dispose()
                    AdaptadorSP.Dispose()

                    frm_reportView.ObjRpt.Database.Tables("cotizacionview1").SetDataSource(DsSP.Tables("CotizacionView"))
                    frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))

                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                    Exit Sub
                End If
            End If

            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."

                Dim TmpForm = New frm_reportView
                TmpForm.Text = "Visualizacion de reportes /" & Me.Text & " / " & CbxFormato.Text
                TmpForm.Show(Me)

                TmpForm.CrystalViewer.ReportSource = Nothing
                TmpForm.CrystalViewer.ReportSource = frm_reportView.ObjRpt
                TmpForm.CrystalViewer.Refresh()
                TmpForm.CrystalViewer.Cursor = Cursors.Default

                lblStatusBar.Text = "Listo"

            ElseIf rdbImpresora.Checked = True Then
                lblStatusBar.Text = "Reporte en impresión..."
                Dim PrintDialog As New PrintDialog

                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                End With

                If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim PrinterSettings1 As New Printing.PrinterSettings
                    Dim PageSettings1 As New Printing.PageSettings

                    PrinterSettings1.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    PrinterSettings1.Collate = PrintDialog.PrinterSettings.Collate
                    PrinterSettings1.Copies = PrintDialog.PrinterSettings.Copies
                    PrinterSettings1.FromPage = PrintDialog.PrinterSettings.FromPage
                    PrinterSettings1.ToPage = PrintDialog.PrinterSettings.ToPage
                    PageSettings1.PrinterResolution.Kind = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind

                    frm_reportView.ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                    frm_reportView.ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName

                    frm_reportView.ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)

                    Me.Cursor = Cursors.Default
                End If

            ElseIf rdbPDF.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en PDF..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

                With GetFileName
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    .Title = ("Especifique Ubicación")
                    .Filter = "Portable Documento Format (*.pdf)|*.pdf"
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = frm_reportView.ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    frm_reportView.ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If

            ElseIf rdbExcel.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en archivo de Excel..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New ExcelFormatOptions

                With GetFileName
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    .Title = ("Especifique Ubicación")
                    .Filter = "Excel (*.xls)|*.xls"
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = frm_reportView.ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    frm_reportView.ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If
            End If
            LoadAnimation()
            lblStatusBar.Text = "Listo"
            DsSP.Dispose()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LoadAnimation()
        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            lblStatusBar.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            lblStatusBar.Text = "Listo"
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DgvCotizaciones.SelectedRows.Count > 0 Then
                Dim IDCotizacion As New Label
                IDCotizacion.Text = DgvCotizaciones.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT Cotizacion.IDCotizacion,Cotizacion.SecondID,Cotizacion.IDCliente,Cotizacion.NombreCotizacion,DireccionCotizacion,TelefonoCotizacion,Clientes.BalanceGeneral,Clientes.IDCalificacion,Calificacion,Fecha,Hora,Cotizacion.IDCondicion,Condicion.Condicion,IDVendedor,Empleados.Nombre as NombreVendedor,Comentario,SubTotal,Descuento,Itbis,Flete,TotalNeto,Cotizacion.IDMoneda,Cotizacion.Nulo,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Cotizacion.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible FROM" & SysName.Text & "cotizacion INNER JOIN Libregco.Clientes on Cotizacion.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados on Cotizacion.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on Cotizacion.IDCondicion=Condicion.IDCondicion Where IDCotizacion='" + IDCotizacion.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Cotizacion")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds1.Tables("Cotizacion")

                If frm_cotizacion.Visible = True Then
                    frm_cotizacion.Close()
                End If

                frm_cotizacion.Show(Me)

                frm_cotizacion.txtIDCotizacion.Text = (Tabla.Rows(0).Item("IDCotizacion"))
                frm_cotizacion.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_cotizacion.txtFechaCotizacion.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_cotizacion.txtHoraCotizacion.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_cotizacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_cotizacion.txtNombre.Text = (Tabla.Rows(0).Item("NombreCotizacion"))
                frm_cotizacion.txtDireccion.Text = (Tabla.Rows(0).Item("DireccionCotizacion"))
                frm_cotizacion.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonoCotizacion"))
                frm_cotizacion.txtVendedor.Tag = (Tabla.Rows(0).Item("IDVendedor"))
                frm_cotizacion.txtVendedor.Text = (Tabla.Rows(0).Item("NombreVendedor"))
                frm_cotizacion.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_cotizacion.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
                frm_cotizacion.TxtDescuento.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
                frm_cotizacion.txtITBIS.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
                frm_cotizacion.txtFlete.Text = CDbl(Tabla.Rows(0).Item("Flete")).ToString("C")
                frm_cotizacion.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                frm_cotizacion.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                frm_cotizacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_cotizacion.chkNulo.Checked = False
                Else
                    frm_cotizacion.chkNulo.Checked = True
                End If

                frm_cotizacion.RefrescarTablaArticulos()

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub ColorearEstados()
        For Each rw As DataGridViewRow In DgvCotizaciones.Rows
            If rw.Cells(10).Value = "Cerrada" Then
                rw.Cells(10).Style.BackColor = SystemColors.Highlight
                rw.Cells(10).Style.ForeColor = Color.White
            ElseIf rw.Cells(10).Value = "Abierta" Then
                rw.Cells(10).Style.BackColor = Color.Red
                rw.Cells(10).Style.ForeColor = Color.White
            ElseIf rw.Cells(10).Value = "En proceso" Then
                rw.Cells(10).Style.BackColor = Color.Green
                rw.Cells(10).Style.ForeColor = Color.White
            End If
        Next

    End Sub

End Class