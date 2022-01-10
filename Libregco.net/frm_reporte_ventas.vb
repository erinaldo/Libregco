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
Public Class frm_reporte_ventas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula, lblIDCalificacion, lblIDNCF, lblIDCondicion As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_reporte_ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToParent()
            'Me.WindowState = CheckWindowState()
            CargarLibregco()
            LimpiarTodo()
            ActualizarTodo()
            Permisos = PasarPermisos(Me.Tag)
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarTodo()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtVendedor.Clear()
        txtIDVendedor.Clear()
        txtChofer.Clear()
        txtIDChofer.Clear()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDMarca.Clear()
        txtMarca.Clear()
        txtIDAlmacen.Clear()
        txtAlmacen.Clear()
        txtIDProvincia.Clear()
        txtProvincia.Clear()
        txtIDMunicipio.Clear()
        txtMunicipio.Clear()
        txtIDUsuario.Clear()
        txtUsuario.Clear()
        txtIDCobrador.Clear()
        txtCobrador.Clear()
        chkNotaDescuento.Checked = False
        chkFichas.Checked = False
        chkFacturasCerradas.Checked = False
        dtpFechaInicial.Value = Today
        dtpFechaInicial.Value = Today
    End Sub

    Private Sub ActualizarTodo()
        FillReportes()
        chkResumir.Checked = False
        chkNotaDescuento.Checked = False
        chkFichas.Checked = False
        chkFacturasCerradas.Checked = False
        FillCalificacion()
        FillComprobante()
        FillCondicion()
        cbxTipoOrden.SelectedIndex = 0
        cbxCalificacion.Text = "Todas"
        cbxCondicion.Text = "Todas"
        cbxNCF.Text = "Todas"
        cbxEstado.Text = "Todos"
    End Sub

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub FillCondicion()

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Condicion FROM Condicion ORDER BY Condicion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Condicion")
        cbxCondicion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Condicion")
        For Each Fila As DataRow In Tabla.Rows
            cbxCondicion.Items.Add(Fila.Item("Condicion"))
        Next

        cbxCondicion.Items.Add("Todas")

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron condiciones. Inserte condiciones de ventas hábiles para procesar los registros de los clientes.", "No se encontraron calificaciones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillCalificacion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Calificacion FROM Calificacion ORDER BY IDCalificacion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Calificacion")
        cbxCalificacion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Calificacion")
        For Each Fila As DataRow In Tabla.Rows
            cbxCalificacion.Items.Add(Fila.Item("Calificacion"))
        Next

        cbxCalificacion.Items.Add("Todas")

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron calificaciones. Inserte calificaciones hábiles para procesar los registros de los clientes.", "No se encontraron calificaciones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillComprobante()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT TipoComprobante FROM ComprobanteFiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            cbxNCF.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                cbxNCF.Items.Add(Fila.Item("TipoComprobante"))
            Next

            cbxNCF.Items.Add("Todas")

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se pudo cargar ningún tipo de comprobante fiscal para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree los tipos de comprobantes fiscales." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Ventas' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Reportes")

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

    Private Sub FillOrdenamiento()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM ReportesOrden where IDReporte='" + IDReport.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "OrdenReportes")
            CbxOrden.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("OrdenReportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxOrden.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxOrden.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron orden de reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "FillOrdenamiento()")
        End Try

    End Sub

    Private Sub ChangePictureRdb()
        If rdbPresentacion.Checked = True Then
            PicSalida.Image = My.Resources.Preview_x72
        ElseIf rdbImpresora.Checked = True Then
            PicSalida.Image = My.Resources.Printer_x72
        ElseIf rdbPDF.Checked = True Then
            PicSalida.Image = My.Resources.AdobeReader_x72
        ElseIf rdbExcel.Checked = True Then
            PicSalida.Image = My.Resources.Ms_Excel_x72
        End If
    End Sub

    Private Sub rdbImpresora_CheckedChanged(sender As Object, e As EventArgs) Handles rdbImpresora.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbPDF_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPDF.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdbExcel.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Nombre from Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtCliente.Text = "" Then txtIDCliente.Clear()
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds.Clear()
        chkResumir.Checked = False
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))


        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Enabled = False
        Else
            chkResumir.Enabled = True
        End If

        FillOrdenamiento()
    End Sub

    Private Sub cbxTipoOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoOrden.SelectedIndexChanged
        If CbxOrden.Text = "Ascendente" Then
            OrdenFormula.Text = "crAscendingOrder"
        ElseIf CbxOrden.Text = "Descendiente" Then
            OrdenFormula.Text = "crDescendingOrder"
        End If
    End Sub

    Private Sub CbxOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxOrden.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("Select Campo from ReportesOrden where IDReporte='" + IDReport.Text + "' and Descripcion='" + CbxOrden.Text + "'", Con)
        OrdenCampo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Suplidor from Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
        txtSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtSuplidor.Text = "" Then txtIDSuplidor.Clear()
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        frm_buscar_marcas.ShowDialog(Me)
    End Sub

    Private Sub txtIDMarca_Leave(sender As Object, e As EventArgs) Handles txtIDMarca.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Marca from Marca Where IDMarca='" + txtIDMarca.Text + "'", ConLibregco)
        txtMarca.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMarca.Text = "" Then txtIDMarca.Clear()
    End Sub

    Private Sub btnAlmacen_Click(sender As Object, e As EventArgs) Handles btnAlmacen.Click
        frm_buscar_almacen_mant.ShowDialog(Me)
    End Sub

    Private Sub txtIDAlmacen_Leave(sender As Object, e As EventArgs) Handles txtIDAlmacen.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Almacen from Almacen Where IDAlmacen='" + txtIDAlmacen.Text + "'", Con)
        txtAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtAlmacen.Text = "" Then txtIDAlmacen.Clear()
    End Sub

    Private Sub btnProvincia_Click(sender As Object, e As EventArgs) Handles btnProvincia.Click
        frm_buscar_provincias.ShowDialog(Me)
    End Sub

    Private Sub txtIDProvincia_Leave(sender As Object, e As EventArgs) Handles txtIDProvincia.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Provincia from Provincias Where IDProvincia='" + txtIDProvincia.Text + "'", ConLibregco)
        txtProvincia.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtProvincia.Text = "" Then txtIDProvincia.Clear()
    End Sub

    Private Sub btnMunicipio_Click(sender As Object, e As EventArgs) Handles btnMunicipio.Click
        frm_buscar_municipios.ShowDialog(Me)
    End Sub

    Private Sub btnVendedor_Click(sender As Object, e As EventArgs) Handles btnVendedor.Click
        frm_buscar_mant_empleados.Control.Text = 1
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnChofer_Click(sender As Object, e As EventArgs) Handles btnChofer.Click
        frm_buscar_mant_empleados.Control.Text = 2
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnCobrador_Click(sender As Object, e As EventArgs) Handles btnCobrador.Click
        frm_buscar_mant_empleados.Control.Text = 3
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnUsuario_Click(sender As Object, e As EventArgs) Handles btnUsuario.Click
        frm_buscar_mant_empleados.Control.Text = 4
        frm_buscar_mant_empleados.ShowDialog(Me)

    End Sub

    Private Sub txtIDUsuario_Leave(sender As Object, e As EventArgs) Handles txtIDUsuario.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
        txtUsuario.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtUsuario.Text = "" Then txtIDUsuario.Clear()
    End Sub

    Private Sub txtIDVendedor_Leave(sender As Object, e As EventArgs) Handles txtIDVendedor.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDVendedor.Text + "'", Con)
        txtVendedor.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtVendedor.Text = "" Then txtIDVendedor.Clear()
    End Sub

    Private Sub txtIDChofer_Leave(sender As Object, e As EventArgs) Handles txtIDChofer.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDChofer.Text + "'", Con)
        txtChofer.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtChofer.Text = "" Then txtIDChofer.Clear()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If CDate(dtpFechaFinal.Value) < CDate(dtpFechaInicial.Value) Then
                MessageBox.Show("La fecha inicial es mayor a la fecha inicial" & vbNewLine & vbNewLine & "Por favor revisar las fechas para procesar el reporte.", "Rangos de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@Fecha
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Fecha")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            With crParameterRangeValue
              .StartValue = dtpFechaInicial.Value.ToString("yyyy-MM-dd")
                .UpperBoundType = RangeBoundType.BoundInclusive
                .EndValue = dtpFechaFinal.Value.ToString("yyyy-MM-dd")
                .LowerBoundType = RangeBoundType.BoundInclusive
            End With

            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Cliente
            If txtIDCliente.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDCliente.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cliente")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDUsuario
            If txtIDUsuario.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDUsuario.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Vendedor
            If txtIDVendedor.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDVendedor.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Vendedor")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Chofer
            If txtIDChofer.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDChofer.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Chofer")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Cobrador
            If txtIDCobrador.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDCobrador.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cobrador")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Suplidor
            If txtIDSuplidor.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDSuplidor.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Suplidor")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Marca
            If txtIDMarca.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDMarca.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Marca")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Provincia
            If txtIDProvincia.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDProvincia.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Provincia")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Municipio
            If txtIDMunicipio.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDMunicipio.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Municipio")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Almacen
            If txtIDAlmacen.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDAlmacen.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            '@NotaDescuento
            If chkNotaDescuento.Checked = True Then
                crParameterDiscreteValue.Value = 1
            Else
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NotaDescuento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Condicion
            If cbxCondicion.Text = "Todas" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = lblIDCondicion.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Calificacion
            If cbxCalificacion.Text = "Todas" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = lblIDCalificacion.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Calificacion")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@NCF
            If cbxNCF.Text = "Todas" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = lblIDNCF.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NCF")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Estado
            If cbxEstado.Text = "Todos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxEstado.Text = "Sólo Activos" Then
                crParameterDiscreteValue.Value = 0
            ElseIf cbxEstado.Text = "Nulos" Then
                crParameterDiscreteValue.Value = 1
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Cierre
            If chkFacturasCerradas.Checked = True Then
                crParameterDiscreteValue.Value = 1
            Else
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cierre")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@HabilitarFicha
            If chkFichas.Checked = True Then
                crParameterDiscreteValue.Value = 1
            Else
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@HabilitarFicha")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            'Setting Info 
            'Resumir Reporte
            If chkResumir.Checked = True Then
                ObjRpt.SetParameterValue("@Resumir", 1)
            Else
                ObjRpt.SetParameterValue("@Resumir", 0)
            End If
            'Ordenamiento de Reporte
            ObjRpt.SetParameterValue("@SortedField", OrdenCampo.Text)
            ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & CbxOrden.Text)
            'RangoFechas()
            ObjRpt.SetParameterValue("@RangoFechas", "Desde " & dtpFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & dtpFechaFinal.Value.ToString("dd/MM/yyyy"))
            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
            ''Almacenes
            If txtIDAlmacen.Text = "" Then
                ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
            Else
                ObjRpt.SetParameterValue("Almacenes", txtAlmacen.Text)
            End If
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ReportSource = ObjRpt
                TmpForm.CrystalViewer.Refresh()
                TmpForm.CrystalViewer.Cursor = Cursors.Default

            ElseIf rdbImpresora.Checked = True Then
                lblStatusBar.Text = "Reporte en impresión..."
                Dim PrintDialog As New PrintDialog
                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                End With

                If (PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    Me.Cursor = Cursors.WaitCursor
                    ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                    ObjRpt.SummaryInfo.ReportAuthor = frm_inicio.lblNombre.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] "
                    ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    Dim Settings As New PrinterSettings
                    Dim PrinterDefault As String = Settings.PrinterName
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrintDialog.PrinterSettings.PrinterName))
                    ObjRpt.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrinterDefault))
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

                If GetFileName.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
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

                If GetFileName.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If

            End If

            lblStatusBar.Text = "Listo"
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarTodo()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
    Private Sub txtIDCobrador_Leave(sender As Object, e As EventArgs) Handles txtIDCobrador.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDCobrador.Text + "'", Con)
        txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtCobrador.Text = "" Then txtIDCobrador.Clear()
    End Sub

    Private Sub txtIDMunicipio_Leave(sender As Object, e As EventArgs) Handles txtIDMunicipio.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Municipio FROM municipios Where IDMunicipio='" + txtIDMunicipio.Text + "'", ConLibregco)
        txtMunicipio.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMunicipio.Text = "" Then txtIDMunicipio.Clear()
    End Sub

    Private Sub btnSuplidor_Click(sender As Object, e As EventArgs) Handles btnSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
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

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub cbxCalificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCalificacion.SelectedIndexChanged
        If cbxCalificacion.Text <> "Todas" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCalificacion FROM Calificacion WHERE Calificacion= '" + cbxCalificacion.SelectedItem + "'", ConLibregco)
            lblIDCalificacion.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub cbxNCF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNCF.SelectedIndexChanged
        If cbxNCF.Text <> "Todas" Then
            Con.Open()
            cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + cbxNCF.SelectedItem + "'", Con)
            lblIDNCF.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub


    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        If cbxCondicion.Text <> "Todas" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
            lblIDCondicion.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub
End Class