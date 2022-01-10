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

Public Class frm_consulta_pagos_cxp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, lblIDCondicion, IDReport, NameReport, PathReport As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim SelectCommand As String = "SELECT IDPagoCompra,SecondID,Fecha,PagoCompra.IDSuplidor,Suplidor.Suplidor,Neto,Nulo FROM" & SysName.Text & "pagocompra INNER JOIN Libregco.Suplidor on PagoCompra.IDSuplidor=Suplidor.IDSuplidor"
    Dim FullCommand, FechaValue, IDSuplidorValue, IDUsuarioValue, NuloValue As String
    Dim A1, A2, A3, A4 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_pagos_cxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDPagoCompra,SecondID,Fecha,PagoCompra.IDSuplidor,Suplidor.Suplidor,Neto,Nulo FROM" & SysName.Text & "pagocompra INNER JOIN Libregco.Suplidor on PagoCompra.IDSuplidor=Suplidor.IDSuplidor Where Fecha BETWEEN '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and PagoCompra.Nulo=0", ConMixta)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ReciboPagoCompra' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Pagos CXP' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDUsuario.Clear()
        txtUsuario.Clear()
        chkNulos.Checked = False
        lblNulo.Text = 0
        txtIDSuplidor.Focus()
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Value = Today
        txtFechaInicial.Value = Today
    End Sub

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Compras")
            DgvPagos.DataSource = Ds
            DgvPagos.DataMember = "Compras"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvPagos.ClearSelection()
        Catch ex As Exception
            ConMixta.Close()
        End Try
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvPagos.Rows
                If CInt(Row.Cells(6).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvPagos
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "No. Pago"
            .Columns(1).Width = 110
            .Columns(2).Width = 90
            .Columns(3).HeaderText = "ID"
            .Columns(3).Width = 60
            .Columns(4).HeaderText = "Suplidor"
            .Columns(4).Width = 345
            .Columns(5).HeaderText = "Importe"
            .Columns(5).Width = 140
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim Counter As Integer = DgvPagos.Rows.Count
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = Counter Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvPagos.Rows(x).Cells(5).Value)

        x = x + 1
        GoTo Inicio
Fin:
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
        lblCantidad.Text = "Registros Encontrados: " & Counter
    End Sub

    Private Sub SelectSuplidor()
        Try
            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Suplidor FROM Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Suplidor")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("Suplidor")
            txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

        Catch ex As Exception
            txtSuplidor.Text = ""
        End Try
    End Sub

    Private Sub SelectUsuario()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Empleados")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Empleados")
            txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        Catch ex As Exception
            txtSuplidor.Text = ""
        End Try
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
        VerificarCondicionNulo()
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        SelectSuplidor()
        VerificarCondicionSuplidor()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog(Me)
    End Sub

    Private Sub txtIDUsuario_Leave(sender As Object, e As EventArgs) Handles txtIDUsuario.Leave
        SelectUsuario()
        VerificarCondicionUsuario()
    End Sub

    Sub VerificarCondicionUsuario()
        If txtIDUsuario.Text = "" Then
            IDUsuarioValue = ""
        Else
            IDUsuarioValue = " PagoCompra.IDUsuario=" & txtIDUsuario.Text
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionSuplidor()
        If txtIDSuplidor.Text = "" Then
            IDSuplidorValue = ""
        Else
            IDSuplidorValue = " PagoCompra.IDSuplidor=" & txtIDSuplidor.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " PagoCompra.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " PagoCompra.Nulo=0 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionSuplidor()
        VerificarCondicionUsuario()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDSuplidorValue <> "" Or IDUsuarioValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDSuplidorValue & IDUsuarioValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDSuplidorValue <> "" And IDUsuarioValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDUsuarioValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDSuplidorValue & A2 & IDUsuarioValue & A3 & NuloValue
    End Sub

    Private Sub btnBuscarSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
        VerificarCondicionSuplidor()
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
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

    Private Sub btnUsuario_Click(sender As Object, e As EventArgs) Handles btnUsuario.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
        VerificarCondicionUsuario()
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

            If TypeConnection.Text = 1 Then
                frm_reportView.ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text)
            Else
                frm_reportView.ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            End If

            If DgvPagos.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
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

                '@IDSuplidor
                If txtIDSuplidor.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSuplidor.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSuplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                If txtIDUsuario.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDUsuario.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                '@TipoSuplidor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoSuplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoDocumento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoIdentificacion")
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

                '@IDSucursal
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDAlmacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDAlmacen")
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

                '@TipoEfectivo
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoEfectivo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoCheque
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoCheque")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoTransfernecia
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoTransferencia")
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
                frm_reportView.ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Compra")
                'RangoFechas()
                frm_reportView.ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                frm_reportView.ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ''Almacenes
                frm_reportView.ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvPagos.SelectedRows.Count > 0 Then
                    Dim IDPago As New Label
                    IDPago.Text = DgvPagos.SelectedRows(0).Cells(0).Value

                    If DgvPagos.SelectedRows(0).Cells(6).Value = 1 Then
                        MessageBox.Show("El documento de pago de compras " & DgvPagos.SelectedRows(0).Cells(1).Value & " de fecha " & DgvPagos.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim cmdSP As New MySqlCommand
                    Dim AdaptadorSP As MySqlDataAdapter

                    'Consulta de los datos de la factura   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AdaptadorSP = New MySqlDataAdapter("SELECT PagoCompra.IDPagoCompra,PagoCompra.SecondID as SecondIDPago,PagoCompra.IDTipoDocumento,TipoDocumento.Documento,PagoCompra.Fecha,PagoCompra.Hora,PagoCompra.IDSucursal,Sucursal.Sucursal,Sucursal.Direccion as DireccionSucursal,Sucursal.Municipio as MunicipioSucursal,Sucursal.Provincia AS ProvinciaSucursal,Sucursal.Telefono as TelefonoSucursal,Sucursal.Telefono1 as Telefono1Sucursal,Sucursal.Telefono2 as SucursalTelefono2,Sucursal.Fax as FaxSucursal,Sucursal.Email as EmailSucursal,PagoCompra.IDAlmacen,Almacen.Almacen,PagoCompra.IDUsuario,Usuarios.Nombre as NombreUsuario,PagoCompra.IDSuplidor,Suplidor.Suplidor,Suplidor.IDTipoIdentificacion,TipoIdentificacion.Descripcion as TipoRNC,Suplidor.IDTipoSuplidor,TipoSuplidor.Descripcion as TipoSuplidor,Suplidor.Rnc,Suplidor.IDProvincia,Provincias.Provincia,Suplidor.IDMunicipio,Municipios.Municipio,Suplidor.Direccion,Suplidor.Telefono,Suplidor.FAx,Suplidor.TelefonoRepresentante,PagoCompra.BceAnterior as BceAnteriorSup,PagoCompra.MontoAplicado,Cheque,Efectivo,Transferencia,Importe,Retencion,Neto,Concepto,Comentario,TransferenciaReferencia,TransferenciaCuenta,TransferenciaBanco,ChequeNumero,ChequeFecha,ChequeBanco,ChequeCuenta,PagoCompra.Nulo,IDPagoComprasDetalle,PagoComprasDetalle.IDCompra,Compras.NoFactura,Compras.SecondID as SecondIDCompra,Compras.NCF,Compras.FechaFactura,Compras.FechaVencimiento,PagoComprasDetalle.BceAnterior as BceAnteriorFactura,PagoComprasDetalle.RetISR AS RetISRDetalle,PagoComprasDetalle.RetITBIS AS RetITBISDetalle,PagoCOmprasDetalle.Descuento as DescuentoDetalle,PagoComprasDetalle.Aplicado as AplicadoDetalle FROM" & SysName.Text & "Pagocompra INNER JOIN" & SysName.Text & "TipoDocumento on PagoCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as Usuarios on PagoCompra.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Sucursal on PagoCompra.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on PagoCompra.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Suplidor on PagoCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.TipoIdentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoSuplidor on Suplidor.IDTipoSuplidor=TipoSuplidor.IDTipoSuplidor INNER JOIN Libregco.Provincias on Suplidor.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Suplidor.IDMunicipio=Municipios.IDMunicipio INNER JOIN" & SysName.Text & "PagoComprasDetalle on PagoCompra.IDPagoCompra=PagoComprasDetalle.IDPagoCompra INNER JOIN" & SysName.Text & "Compras on PagoComprasDetalle.IDCompra=Compras.IDCompra Where PagoCompra.IDPagoCompra='" + DgvPagos.CurrentRow.Cells(0).Value.ToString + "'", ConMixta)
                    AdaptadorSP.Fill(DsSP, "PagoComprasView")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Llenado EmpresaView
                    AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                    AdaptadorSP.Fill(DsSP, "EmpresaView")

                    cmdSP.Dispose()
                    AdaptadorSP.Dispose()

                    frm_reportView.ObjRpt.Database.Tables("pagocomprasview1").SetDataSource(DsSP.Tables("PagoComprasView"))
                    frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))

                    'crParameterDiscreteValue.Value = IDPago.Text
                    'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    'crParameterValues.Add(crParameterDiscreteValue)
                    'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
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

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim DsTemp As New DataSet
            If DgvPagos.SelectedRows.Count > 0 Then
                Dim IDPago As New Label
                IDPago.Text = DgvPagos.SelectedRows(0).Cells(0).Value

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT PagoCompra.IDSuplidor,Suplidor.Suplidor,Suplidor.Balance,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto FROM" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero,IDPagoCompra,SecondID,Fecha,Hora,PagoCompra.IDSucursal,Sucursal.Sucursal,PagoCompra.IDAlmacen,Almacen.Almacen,PagoCompra.IDUsuario,Usuarios.Nombre as NombreUsuario,PagoCompra.IDSuplidor,Suplidor.Suplidor,BceAnterior,MontoAplicado,Cheque,Efectivo,Transferencia,Importe,Retencion,Neto,Concepto,Comentario,PagoCompra.Nulo FROM" & SysName.Text & "pagocompra INNER JOIN Libregco.Suplidor on PagoCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "Sucursal on PagoCompra.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on PagoCompra.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Empleados as Usuarios on PagoCompra.IDUsuario=Usuarios.IDEmpleado Where IDPagoCompra='" + IDPago.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Pagocompras")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds.Tables("Pagocompras")

                If frm_pago_compras.Visible = True Then
                    frm_pago_compras.Close()
                End If

                frm_pago_compras.Show(Me)
                frm_superclave.IDAccion.Text = 24
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    frm_pago_compras.Close()
                    Exit Sub
                End If
                frm_pago_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_pago_compras.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_pago_compras.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                frm_pago_compras.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_pago_compras.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_pago_compras.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If
                frm_pago_compras.txtIDPago.Text = (Tabla.Rows(0).Item("IDPagoCompra"))
                frm_pago_compras.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_pago_compras.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_pago_compras.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_pago_compras.txtMontoAplicar.Text = CDbl(Tabla.Rows(0).Item("MontoAplicado")).ToString("C")
                frm_pago_compras.txtCheque.Text = CDbl(Tabla.Rows(0).Item("Cheque")).ToString("C")
                frm_pago_compras.txtEfectivo.Text = CDbl(Tabla.Rows(0).Item("Efectivo")).ToString("C")
                frm_pago_compras.txtTransferencia.Text = CDbl(Tabla.Rows(0).Item("Transferencia")).ToString("C")
                frm_pago_compras.txtImporte.Text = CDbl(Tabla.Rows(0).Item("Importe")).ToString("C")
                frm_pago_compras.txtDescRet.Text = CDbl(Tabla.Rows(0).Item("Retencion")).ToString("C")
                frm_pago_compras.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                frm_pago_compras.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_pago_compras.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_registro_compras.ChkNulo.Checked = False
                Else
                    frm_registro_compras.ChkNulo.Checked = True
                End If

                Con.Open()
                Dim Da As New MySqlCommand("SELECT IDPagoComprasDetalle,IDPagoCompra,PagoComprasDetalle.IDCompra,Compras.NoFactura,Compras.FechaFactura,Compras.FechaVencimiento,Compras.TotalNeto,PagoComprasDetalle.BceAnterior,RetISR,RetItbis,PagoComprasDetalle.Descuento,Aplicado,NCF,Compras.SecondID FROM pagocomprasdetalle INNER JOIN Compras on PagoComprasDetalle.IDCompra=Compras.IDCompra where IDPagoCompra='" + IDPago.Text + "'", Con)
                Dim LectorPago As MySqlDataReader = Da.ExecuteReader

                While LectorPago.Read
                    frm_pago_compras.DgvCompras.Rows.Add(LectorPago.GetValue(0), LectorPago.GetValue(1), LectorPago.GetValue(2), LectorPago.GetValue(3), CDate(LectorPago.GetValue(4)).ToString("dd/MM/yyyy"), CDate(LectorPago.GetValue(5)).ToString("dd/MM/yyyy"), LectorPago.GetValue(6), LectorPago.GetValue(7), LectorPago.GetValue(8), LectorPago.GetValue(9), LectorPago.GetValue(10), LectorPago.GetValue(11), False, CDbl(CDbl(LectorPago.GetValue(7)) - CDbl(LectorPago.GetValue(11))).ToString("C"), LectorPago.GetValue(12), LectorPago.GetValue(13))
                End While
                LectorPago.Close()
                Con.Close()
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class