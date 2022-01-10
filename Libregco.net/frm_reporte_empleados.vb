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
Public Class frm_reporte_empleados

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula, lblIDPeriodo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_reporte_empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarTodo()
        txtIDEmpleadoDesde.Clear()
        txtIDEmpleadoHasta.Clear()
        txtIDNacionalidad.Clear()
        txtNacionalidad.Clear()
        txtIDGenero.Clear()
        txtGenero.Clear()
        txtIDProvincia.Clear()
        txtProvincia.Clear()
        txtIDMunicipio.Clear()
        txtMunicipio.Clear()
        txtIDSucursal.Clear()
        txtSucursal.Clear()
        txtIDAlmacen.Clear()
        txtAlmacen.Clear()
        txtIDNomina.Clear()
        txtNomina.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        txtIDCargo.Clear()
        txtCargo.Clear()
        txtIDTanda.Clear()
        txtTanda.Clear()
        txtIDARS.Clear()
        txtARS.Clear()
        txtIDAfp.Clear()
        txtAFP.Clear()
    End Sub

    Private Sub FillPeriodoPago()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM periodopago ORDER BY Descripcion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Periodopago")
            CbxPeriodo.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Periodopago")
            For Each Fila As DataRow In Tabla.Rows
                CbxPeriodo.Items.Add(Fila.Item("Descripcion"))
            Next

            CbxPeriodo.Items.Add("Todos")

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se encontraron períodos de pagos disponibles. Inserte períodos de pagos hábiles para procesar los registros.", "No se encontraron períodos de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " FillPeriodoPago")
        End Try

    End Sub

    Private Sub ActualizarTodo()
        FillReportes()
        FillPeriodoPago()
        chkResumir.Checked = False
        chkEspecificarVenc.Checked = True
        dtpIngresoInicial.Value = Today
        dtpIngresoFinal.Value = Today
        cbxTipoOrden.SelectedIndex = 0
        CbxPeriodo.Text = "Todos"
        cbxAlertas.Text = "Todos"
        cbxHabilitadoNomina.Text = "Todos"
        cbxEstado.Text = "Todos"
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub chkEspecificarVenc_CheckedChanged(sender As Object, e As EventArgs) Handles chkEspecificarVenc.CheckedChanged
        If chkEspecificarVenc.Checked = True Then
            dtpIngresoInicial.Enabled = False
            dtpIngresoFinal.Enabled = False
            Label11.Enabled = False
            Label8.Enabled = False
        Else
            dtpIngresoInicial.Enabled = True
            dtpIngresoFinal.Enabled = True
            Label11.Enabled = True
            Label8.Enabled = True
        End If
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Empleados' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
            cmd = New MySqlCommand("SELECT Descripcion FROM ReportesOrden where IDReporte='" + IDReport.text + "'", Con)
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

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
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

    Private Sub txtIDNacionalidad_Leave(sender As Object, e As EventArgs) Handles txtIDNacionalidad.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Nacionalidad from Nacionalidad Where IDNacionalidad='" + txtIDNacionalidad.Text + "'", ConLibregco)
        txtNacionalidad.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtNacionalidad.Text = "" Then txtIDNacionalidad.Clear()
    End Sub

    Private Sub txtIDGenero_Leave(sender As Object, e As EventArgs) Handles txtIDGenero.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Genero from Genero Where IDGenero='" + txtIDGenero.Text + "'", ConLibregco)
        txtGenero.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtGenero.Text = "" Then txtIDGenero.Clear()
    End Sub

    Private Sub txtIDProvincia_Leave(sender As Object, e As EventArgs) Handles txtIDProvincia.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Provincia from Provincias Where IDProvincia='" + txtIDProvincia.Text + "'", ConLibregco)
        txtProvincia.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtProvincia.Text = "" Then txtIDProvincia.Clear()
    End Sub

    Private Sub txtIDSucursal_Leave(sender As Object, e As EventArgs) Handles txtIDSucursal.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Sucursal from Sucursal Where IDSucursal='" + txtIDSucursal.Text + "'", Con)
        txtSucursal.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtSucursal.Text = "" Then txtIDSucursal.Clear()
    End Sub

    Private Sub txtIDMunicipio_Leave(sender As Object, e As EventArgs) Handles txtIDMunicipio.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Municipio from Municipios Where IDMunicipio='" + txtIDMunicipio.Text + "'", ConLibregco)
        txtMunicipio.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMunicipio.Text = "" Then txtIDMunicipio.Clear()
    End Sub

    Private Sub txtIDAlmacen_Leave(sender As Object, e As EventArgs) Handles txtIDAlmacen.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Almacen from Almacen Where IDAlmacen='" + txtIDAlmacen.Text + "'", Con)
        txtAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtAlmacen.Text = "" Then txtIDAlmacen.Clear()
    End Sub

    Private Sub txtIDNomina_Leave(sender As Object, e As EventArgs) Handles txtIDNomina.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from TipoNomina Where IDTipoNomina='" + txtIDNomina.Text + "'", ConLibregco)
        txtNomina.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtNomina.Text = "" Then txtIDNomina.Clear()
    End Sub

    Private Sub txtIDCargo_Leave(sender As Object, e As EventArgs) Handles txtIDCargo.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Cargo FROM cargosemp where IDCargo='" + txtIDCargo.Text + "'", ConLibregco)
        txtCargo.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtCargo.Text = "" Then txtIDCargo.Clear()
    End Sub

    Private Sub txtIDTanda_Leave(sender As Object, e As EventArgs) Handles txtIDTanda.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from Tandas Where IDTanda='" + txtIDTanda.Text + "'", ConLibregco)
        txtTanda.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTanda.Text = "" Then txtIDTanda.Clear()
    End Sub

    Private Sub txtIDARS_Leave(sender As Object, e As EventArgs) Handles txtIDARS.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from Ars Where IDARS='" + txtIDARS.Text + "'", ConLibregco)
        txtARS.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtARS.Text = "" Then txtIDARS.Clear()
    End Sub

    Private Sub txtIDAfp_Leave(sender As Object, e As EventArgs) Handles txtIDAfp.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from AFP Where IDAFP='" + txtIDAfp.Text + "'", ConLibregco)
        txtAFP.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtAFP.Text = "" Then txtIDAfp.Clear()
    End Sub

    Private Sub btnNacionalidad_Click(sender As Object, e As EventArgs) Handles btnNacionalidad.Click
        frm_buscar_nacionalidad.ShowDialog(Me)
    End Sub

    Private Sub btnGenero_Click(sender As Object, e As EventArgs) Handles btnGenero.Click
        frm_buscar_genero.ShowDialog(Me)
    End Sub

    Private Sub btnProvincia_Click(sender As Object, e As EventArgs) Handles btnProvincia.Click
        frm_buscar_provincias.ShowDialog(Me)
    End Sub

    Private Sub btnMunicipio_Click(sender As Object, e As EventArgs) Handles btnMunicipio.Click
        frm_buscar_municipios.ShowDialog(Me)
    End Sub

    Private Sub btnSucursal_Click(sender As Object, e As EventArgs) Handles btnSucursal.Click
        frm_buscar_sucursal.ShowDialog(Me)
    End Sub

    Private Sub btnAlmacen_Click(sender As Object, e As EventArgs) Handles btnAlmacen.Click
        frm_buscar_almacen_mant.ShowDialog(Me)
    End Sub

    Private Sub btnNomina_Click(sender As Object, e As EventArgs) Handles btnNomina.Click
        frm_buscar_tipo_nomina.ShowDialog(Me)
    End Sub

    Private Sub btnCargo_Click(sender As Object, e As EventArgs) Handles btnCargo.Click
        frm_buscar_cargos_emp.ShowDialog(Me)
    End Sub

    Private Sub btnTanda_Click(sender As Object, e As EventArgs) Handles btnTanda.Click
        frm_buscar_tandas.ShowDialog(Me)
    End Sub

    Private Sub btnARS_Click(sender As Object, e As EventArgs) Handles btnARS.Click
        frm_buscar_ars.ShowDialog(Me)
    End Sub

    Private Sub btnAFP_Click(sender As Object, e As EventArgs) Handles btnAFP.Click
        frm_buscar_afp.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarArtDesde_Click(sender As Object, e As EventArgs) Handles btnBuscarArtDesde.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub chkSinEspecNacimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chkSinEspecNacimiento.CheckedChanged
        If chkSinEspecNacimiento.Checked = True Then
            DtpFechaInicialNacimiento.Enabled = False
            dtpFechaFinalNacimiento.Enabled = False
            Label25.Enabled = False
            Label26.Enabled = False
        Else
            DtpFechaInicialNacimiento.Enabled = True
            dtpFechaFinalNacimiento.Enabled = True
            Label25.Enabled = True
            Label26.Enabled = True
        End If
    End Sub

    Private Sub txtIDDepartamento_Leave(sender As Object, e As EventArgs) Handles txtIDDepartamento.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM departamentoemp where IDDepartamentoEmp='" + txtIDCargo.Text + "'", ConLibregco)
        txtDepartamento.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtDepartamento.Text = "" Then txtIDDepartamento.Clear()
    End Sub

    Private Sub btnDepartamento_Click(sender As Object, e As EventArgs) Handles btnDepartamento.Click
        frm_buscar_departamentos_emp.ShowDialog(Me)
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


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            If IsNumeric(txtIDEmpleadoDesde.Text) And IsNumeric(txtIDEmpleadoHasta.Text) Then
                If CDbl(txtIDEmpleadoDesde.Text) > CDbl(txtIDEmpleadoHasta.Text) Then
                    MessageBox.Show("El código inicial del empleado siempre debe ser mayor al código final. Por favor revise los datos suministrados para procesar el reporte.", "Rango de valores no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            If chkEspecificarVenc.Checked = False Then
                If CDate(dtpIngresoInicial.Value) > CDate(dtpIngresoFinal.Value) Then
                    MessageBox.Show("La fecha de ingreso inicial es mayor a la fecha de ingreso final" & vbNewLine & vbNewLine & "Por favor revisar la fecha de ingreso para procesar el reporte.", "Rango de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            If chkSinEspecNacimiento.Checked = False Then
                If CDate(DtpFechaInicialNacimiento.Value) > CDate(dtpFechaFinalNacimiento.Value) Then
                    MessageBox.Show("La fecha de nacimiento inicial es mayor a la fecha de nacimiento final" & vbNewLine & vbNewLine & "Por favor revisar la fecha de nacimiento para procesar el reporte.", "Rango de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            '@CodigoEmpleado
            Dim Minimo, Maximo As Integer
            Con.Open()
            cmd = New MySqlCommand("Select IDEmpleado from Empleados where IDEmpleado= (Select Max(IDEmpleado) from Empleados)", Con)
            Maximo = Convert.ToInt16(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select IDEmpleado from Empleados where IDEmpleado= (Select Min(IDEmpleado) from Empleados)", Con)
            Minimo = Convert.ToInt16(cmd.ExecuteScalar())
            Con.Close()

            If txtIDEmpleadoDesde.Text = "" Then
                txtIDEmpleadoDesde.Text = Minimo
            End If
            If txtIDEmpleadoHasta.Text = "" Then
                txtIDEmpleadoHasta.Text = Maximo
            End If

            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CodigoEmpleado")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            With crParameterRangeValue
                .EndValue = txtIDEmpleadoHasta.Text
                .LowerBoundType = RangeBoundType.BoundInclusive
                .StartValue = txtIDEmpleadoDesde.Text
                .UpperBoundType = RangeBoundType.BoundInclusive
            End With

            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@FechaIngreso
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@FechaIngreso")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            If chkEspecificarVenc.Checked = True Then
                With crParameterRangeValue
                    .StartValue = dtpIngresoInicial.MinDate.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpIngresoFinal.MaxDate.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            Else
                With crParameterRangeValue
                    .StartValue = dtpIngresoInicial.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpIngresoFinal.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            End If
            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@FechaNacimiento
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@FechaNacimiento")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            If chkSinEspecNacimiento.Checked = True Then
                With crParameterRangeValue
                    .StartValue = DtpFechaInicialNacimiento.MinDate.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpFechaFinalNacimiento.MaxDate.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            Else
                With crParameterRangeValue
                    .StartValue = DtpFechaInicialNacimiento.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpFechaFinalNacimiento.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            End If
            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Nacionalidad
            If txtIDNacionalidad.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDNacionalidad.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Nacionalidad")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Genero
            If txtIDGenero.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDGenero.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Genero")
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

            '@Sucursal
            If txtIDSucursal.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDSucursal.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Sucursal")
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

            '@Nomina
            If txtIDNomina.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDNomina.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Nomina")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Cargo
            If txtIDCargo.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDCargo.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cargo")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Departamento
            If txtIDDepartamento.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDDepartamento.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Departamento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Tanda
            If txtIDTanda.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDTanda.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Tanda")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@ARS
            If txtIDARS.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDARS.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@ARS")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@AFP
            If txtIDAfp.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDAfp.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@AFP")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Periodo
            If CbxPeriodo.Text = "Todos" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = lblIDPeriodo.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Periodo")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Alertas
            If cbxAlertas.Text = "Todos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxAlertas.Text = "Sí" Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxAlertas.Text = "No" Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Alertas")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@enNomina
            If cbxHabilitadoNomina.Text = "Todos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxHabilitadoNomina.Text = "Sí" Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxHabilitadoNomina.Text = "No" Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@enNomina")
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
            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
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

                If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
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

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
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

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
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

    Private Sub CbxPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxPeriodo.SelectedIndexChanged
        If CbxPeriodo.Text <> "Todos" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPeriodoPago FROM periodopago where Descripcion= '" + CbxPeriodo.SelectedItem + "'", ConLibregco)
            lblIDPeriodo.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub
End Class