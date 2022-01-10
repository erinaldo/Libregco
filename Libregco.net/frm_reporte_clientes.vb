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

Public Class frm_reporte_clientes

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula, lblIDCalificacion As New Label
    Dim Permisos As New ArrayList

    Private Sub txtIDTipoDocumento_Leave(sender As Object, e As EventArgs) Handles txtIDTipoDocumento.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from TipoIdentificacion Where IDTipoIdentificacion='" + txtIDTipoDocumento.Text + "'", ConLibregco)
        txtTipoDocumento.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoDocumento.Text = "" Then txtIDTipoDocumento.Clear()
    End Sub

    Private Sub txtIDGenero_Leave(sender As Object, e As EventArgs) Handles txtIDGenero.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Genero from Genero Where IDGenero='" + txtIDGenero.Text + "'", ConLibregco)
        txtGenero.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtGenero.Text = "" Then txtIDGenero.Clear()
    End Sub

    Private Sub txtIDNacionalidad_Leave(sender As Object, e As EventArgs) Handles txtIDNacionalidad.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Nacionalidad from Nacionalidad Where IDNacionalidad='" + txtIDNacionalidad.Text + "'", ConLibregco)
        txtNacionalidad.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtNacionalidad.Text = "" Then txtIDNacionalidad.Clear()
    End Sub

    Private Sub btnNacionalidad_Click(sender As Object, e As EventArgs) Handles btnNacionalidad.Click
        frm_buscar_nacionalidad.ShowDialog(Me)
    End Sub

    Private Sub txtIDProvincia_Leave(sender As Object, e As EventArgs) Handles txtIDProvincia.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Provincia from Provincias Where IDProvincia='" + txtIDProvincia.Text + "'", ConLibregco)
        txtProvincia.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtProvincia.Text = "" Then txtIDProvincia.Clear()
    End Sub

    Private Sub txtIDMunicipio_Leave(sender As Object, e As EventArgs) Handles txtIDMunicipio.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Municipio from Municipios Where IDMunicipio='" + txtIDMunicipio.Text + "'", ConLibregco)
        txtMunicipio.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMunicipio.Text = "" Then txtIDMunicipio.Clear()
    End Sub

    Private Sub txtIDOcupacion_Leave(sender As Object, e As EventArgs) Handles txtIDOcupacion.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Ocupacion from Ocupacion Where IDOcupacion='" + txtIDOcupacion.Text + "'", ConLibregco)
        txtOcupacion.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtOcupacion.Text = "" Then txtIDOcupacion.Clear()
    End Sub

    Private Sub txtIDEstadoCivil_Leave(sender As Object, e As EventArgs) Handles txtIDEstadoCivil.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select EstadoCivil from EstadoCivil Where IDCivil='" + txtIDEstadoCivil.Text + "'", ConLibregco)
        txtEstadoCivil.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtEstadoCivil.Text = "" Then txtIDEstadoCivil.Clear()
    End Sub

    Private Sub txtIDGrupo_Leave(sender As Object, e As EventArgs) Handles txtIDGrupo.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from Grupocxc Where IDGrupocxc='" + txtIDGrupo.Text + "'", ConLibregco)
        txtGrupo.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtGrupo.Text = "" Then txtIDGrupo.Clear()
    End Sub

    Private Sub txtIDTipoCliente_Leave(sender As Object, e As EventArgs) Handles txtIDTipoCliente.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from TipoCredito Where IDTipoCredito='" + txtIDTipoCliente.Text + "'", ConLibregco)
        txtTipoCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoCliente.Text = "" Then txtIDTipoCliente.Clear()
    End Sub

    Private Sub txtIDCobrador_Leave(sender As Object, e As EventArgs) Handles txtIDCobrador.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDCobrador.Text + "'", Con)
        txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtCobrador.Text = "" Then txtIDCobrador.Clear()
    End Sub

    Private Sub txtIDNcf_Leave(sender As Object, e As EventArgs) Handles txtIDNcf.Leave
        Con.Open()
        cmd = New MySqlCommand("Select TipoComprobante from ComprobanteFiscal Where IDComprobanteFiscal='" + txtIDNcf.Text + "'", Con)
        txtNCF.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtNCF.Text = "" Then txtIDNcf.Clear()
    End Sub

    Private Sub frm_reporte_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        txtCodigoInicial.Clear()
        txtCodigoFinal.Clear()
        txtIDTipoDocumento.Clear()
        txtTipoDocumento.Clear()
        txtIDGenero.Clear()
        txtGenero.Clear()
        txtIDNacionalidad.Clear()
        txtNacionalidad.Clear()
        txtIDProvincia.Clear()
        txtProvincia.Clear()
        txtIDMunicipio.Clear()
        txtMunicipio.Clear()
        txtIDOcupacion.Clear()
        txtOcupacion.Clear()
        txtEstadoCivil.Clear()
        txtIDEstadoCivil.Clear()
        txtIDGrupo.Clear()
        txtGrupo.Clear()
        txtIDTipoCliente.Clear()
        txtTipoCliente.Clear()
        txtIDCobrador.Clear()
        txtCobrador.Clear()
        txtIDNcf.Clear()
        txtNCF.Clear()
    End Sub

    Private Sub ActualizarTodo()
        FillReportes()
        FillCalificacion()
        chkResumir.Checked = False
        ChkEspCodigo.Checked = True
        chkEspecificarIngreso.Checked = True
        dtpIngresoInicial.Value = Today
        dtpIngresoFinal.Value = Today
        cbxCalificacion.Text = "Todas"
        cbxGeneracionCargo.Text = "Todos"
        cbxRecepCheques.Text = "Todos"
        CbxCtaIncobrable.Text = "Todos"
        cbxStatusCredito.Text = "Todos"
        cbxEstado.Text = "Todos"
        cbxTipoOrden.SelectedIndex = 0
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

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub ChkEspCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEspCodigo.CheckedChanged
        If ChkEspCodigo.Checked = True Then
            txtCodigoInicial.Enabled = False
            txtCodigoInicial.Clear()
            txtCodigoFinal.Enabled = False
            txtCodigoFinal.Clear()
            Label4.Enabled = False
            Label3.Enabled = False
        Else
            txtCodigoInicial.Enabled = True
            txtCodigoFinal.Enabled = True
            Label4.Enabled = True
            Label3.Enabled = True
        End If
    End Sub

    Private Sub chkEspecificarIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles chkEspecificarIngreso.CheckedChanged
        If chkEspecificarIngreso.Checked = True Then
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

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Clientes' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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

    Private Sub btnTipoNCF_Click(sender As Object, e As EventArgs) Handles btnTipoNCF.Click
        frm_buscar_tipo_comprobantes.ShowDialog(Me)
    End Sub


    Private Sub btnCobrador_Click(sender As Object, e As EventArgs) Handles btnCobrador.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnProvincia_Click(sender As Object, e As EventArgs) Handles btnProvincia.Click
        frm_buscar_provincias.ShowDialog(Me)
    End Sub

    Private Sub btnMunicipio_Click(sender As Object, e As EventArgs) Handles btnMunicipio.Click
        frm_buscar_municipios.ShowDialog(Me)
    End Sub

    Private Sub btnOcupacion_Click(sender As Object, e As EventArgs) Handles btnOcupacion.Click
        frm_buscar_ocupacion.ShowDialog(Me)
    End Sub

    Private Sub btnEstadoCivil_Click(sender As Object, e As EventArgs) Handles btnEstadoCivil.Click
        frm_buscar_estado_civil.ShowDialog(Me)
    End Sub

    Private Sub btnGrupo_Click(sender As Object, e As EventArgs) Handles btnGrupo.Click
        frm_buscar_grupo_cxc.ShowDialog(Me)
    End Sub

    Private Sub btnTipoCliente_Click(sender As Object, e As EventArgs) Handles btnTipoCliente.Click
        frm_buscar_tipo_credito.ShowDialog(Me)
    End Sub

    Private Sub btnGenero_Click(sender As Object, e As EventArgs) Handles btnGenero.Click
        frm_buscar_genero.ShowDialog(Me)
    End Sub

    Private Sub btnTipoDocumento_Click(sender As Object, e As EventArgs) Handles btnTipoDocumento.Click
        frm_buscar_tipo_identificacion.ShowDialog(Me)
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


            If ChkEspCodigo.Checked = True Then
                If txtCodigoFinal.Text < txtCodigoInicial.Text Then
                    MessageBox.Show("El código inicial es mayor al código final" & vbNewLine & vbNewLine & "Por favor revisar los códigos para procesar el reporte.", "Rangos de Códigos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            ElseIf chkEspecificarIngreso.Checked = False Then
                If CDate(dtpIngresoInicial.Value) > CDate(dtpIngresoFinal.Value) Then
                    MessageBox.Show("La fecha de ingreso inicial es mayor a la fecha de ingreso final" & vbNewLine & vbNewLine & "Por favor revisar la fecha de ingreso para procesar el reporte.", "Rango de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@CodigoCliente
            Dim Minimo, Maximo As Integer
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDCliente from Clientes where IDCliente= (Select Max(IDCliente) from Clientes)", ConLibregco)
            Maximo = Convert.ToInt16(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select IDCliente from Clientes where IDCliente= (Select Min(IDCliente) from Clientes)", ConLibregco)
            Minimo = Convert.ToInt16(cmd.ExecuteScalar())
            ConLibregco.Close()


            If ChkEspCodigo.Checked = False Then
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CodigoCliente")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                If txtCodigoInicial.Text = "" Then
                    txtCodigoInicial.Text = Minimo
                End If
                If txtCodigoFinal.Text = "" Then
                    txtCodigoFinal.Text = Maximo
                End If

                With crParameterRangeValue
                    .EndValue = txtCodigoFinal.Text
                    .LowerBoundType = RangeBoundType.BoundInclusive
                    .StartValue = txtCodigoInicial.Text
                    .UpperBoundType = RangeBoundType.BoundInclusive
                End With
            Else
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CodigoCliente")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .EndValue = Maximo
                    .LowerBoundType = RangeBoundType.BoundInclusive
                    .StartValue = Minimo
                    .UpperBoundType = RangeBoundType.BoundInclusive
                End With
            End If

            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@TipoDocumento
            If txtIDTipoDocumento.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDTipoDocumento.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoDocumento")
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

            '@Ocupacion
            If txtIDOcupacion.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDOcupacion.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Ocupacion")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@EstadoCivil
            If txtIDEstadoCivil.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDEstadoCivil.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@EstadoCivil")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Grupo
            If txtIDGrupo.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDGrupo.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Grupo")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@TipoCredito
            If txtIDTipoCliente.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDTipoCliente.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoCredito")
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

            '@NCF
            If txtIDNcf.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDNcf.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NCF")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@FechaIngreso
            If chkEspecificarIngreso.Checked = True Then
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@FechaIngreso")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .StartValue = dtpIngresoInicial.MinDate.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpIngresoFinal.MaxDate.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            Else
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@FechaIngreso")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .StartValue = dtpIngresoInicial.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpIngresoFinal.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            End If
            crParameterValues.Add(crParameterRangeValue)
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

            '@GenerarCargos
            If cbxGeneracionCargo.Text = "Todos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxGeneracionCargo.Text = "Aplica" Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxGeneracionCargo.Text = "No Aplican" Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@GenerarCargos")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@RecepcionCheques
            If cbxRecepCheques.Text = "Todos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxRecepCheques.Text = "Permitidos" Then
                crParameterDiscreteValue.Value = 0
            ElseIf cbxRecepCheques.Text = "No Permitidos" Then
                crParameterDiscreteValue.Value = 1
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@RecepcionCheques")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@CuentaIncobrable
            If CbxCtaIncobrable.Text = "Todos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf CbxCtaIncobrable.Text = "Sólo las cobrables" Then
                crParameterDiscreteValue.Value = 0
            ElseIf CbxCtaIncobrable.Text = "Sólo las incobrables" Then
                crParameterDiscreteValue.Value = 1
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CuentaIncobrable")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@EstadoCredito
            If cbxStatusCredito.Text = "Todos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxStatusCredito.Text = "Sólo Abiertos" Then
                crParameterDiscreteValue.Value = 0
            ElseIf cbxStatusCredito.Text = "Sólo Cerrados" Then
                crParameterDiscreteValue.Value = 1
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@EstadoCredito")
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

    Private Sub cbxCalificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCalificacion.SelectedIndexChanged
          If cbxCalificacion.Text <> "Todas" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCalificacion FROM Calificacion WHERE Calificacion= '" + cbxCalificacion.SelectedItem + "'", ConLibregco)
            lblIDCalificacion.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub
End Class