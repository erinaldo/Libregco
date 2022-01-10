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
Public Class frm_reporte_recibos_cobros

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_reporte_recibos_cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub txtIDCobrador_Leave(sender As Object, e As EventArgs) Handles txtIDCobrador.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDCobrador.Text + "'", Con)
        txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtCobrador.Text = "" Then txtIDCobrador.Clear()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub txtIDRecepcion_Leave(sender As Object, e As EventArgs) Handles txtIDRecepcion.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDRecepcion.Text + "'", Con)
        txtRecepcion.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtRecepcion.Text = "" Then txtIDRecepcion.Clear()
    End Sub

    Private Sub txtIDTipoRecibo_Leave(sender As Object, e As EventArgs) Handles txtIDTipoRecibo.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM tiporecibos where IDTipoRecibo='" + txtIDTipoRecibo.Text + "'", ConLibregco)
        txtTipoRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoRecibo.Text = "" Then txtIDTipoRecibo.Clear()
    End Sub

    Private Sub txtIDEntrega_Leave(sender As Object, e As EventArgs) Handles txtIDEntrega.Leave
        Con.Open()
        cmd = New MySqlCommand("SELECT SecondID FROM entregacobro Where IDEntregaCobro='" + txtIDEntrega.Text + "'", Con)
        txtEntrega.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtEntrega.Text = "" Then txtIDEntrega.Clear()
    End Sub

    Private Sub txtIDGrupo_Leave(sender As Object, e As EventArgs) Handles txtIDGrupo.Leave
        Con.Open()
        cmd = New MySqlCommand("SELECT SecondID FROM gruporecibos Where IDGrupoRecibos='" + txtIDGrupo.Text + "'", Con)
        txtGrupoRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtGrupoRecibo.Text = "" Then txtIDGrupo.Clear()
    End Sub

    Private Sub txtIDTalonario_Leave(sender As Object, e As EventArgs) Handles txtIDTalonario.Leave
        Con.Open()
        cmd = New MySqlCommand("SELECT SecondID FROM talonariorecibo Where IDTalonarioRecibo='" + txtIDTalonario.Text + "'", Con)
        txtTalonario.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtTalonario.Text = "" Then txtIDTalonario.Clear()
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Clientes where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtCliente.Text = "" Then txtIDCliente.Clear()
    End Sub

    Private Sub txtIDFactura_Leave(sender As Object, e As EventArgs) Handles txtIDFactura.Leave
        Con.Open()
        cmd = New MySqlCommand("SELECT SecondID FROM FacturaDatos where IDFacturaDatos='" + txtIDFactura.Text + "'", Con)
        txtFactura.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtFactura.Text = "" Then txtIDFactura.Clear()
    End Sub

    Private Sub LimpiarTodo()
        txtIDCobrador.Clear()
        txtCobrador.Clear()
        txtIDRecepcion.Clear()
        txtRecepcion.Clear()
        txtIDTipoRecibo.Clear()
        txtTipoRecibo.Clear()
        txtIDEntrega.Clear()
        txtEntrega.Clear()
        txtIDGrupo.Clear()
        txtGrupoRecibo.Clear()
        txtIDTalonario.Clear()
        txtTalonario.Clear()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtIDFactura.Clear()
        txtFactura.Clear()
    End Sub

    Private Sub ActualizarTodo()
        FillReportes()
        chkResumir.Checked = False
        chkSinEspecificar.Checked = True
        dtpFechaInicial.Value = Today
        dtpFechaFinal.Value = Today
        cbxTipoOrden.SelectedIndex = 0
        CbxCerrado.Text = "Todos"
        cbxNaturaleza.Text = "Todos"
        cbxEstado.Text = "Todos"
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoRecibosCobro'", Con)
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

   
    Private Sub btnCobrador_Click(sender As Object, e As EventArgs) Handles btnCobrador.Click
        frm_buscar_mant_empleados.Control.Text = 0
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        frm_buscar_mant_empleados.Control.Text = 1
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnTipoRecibo_Click(sender As Object, e As EventArgs) Handles btnTipoRecibo.Click
        frm_buscar_tipo_recibos.ShowDialog(Me)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnEntrega.Click
        frm_buscar_entrega_cobros.ShowDialog(Me)
    End Sub

    Private Sub btnGrupoRecibos_Click(sender As Object, e As EventArgs) Handles btnGrupoRecibos.Click
        frm_buscar_grupo_recibos.ShowDialog(Me)
    End Sub

    Private Sub btnTalonario_Click(sender As Object, e As EventArgs) Handles btnTalonario.Click
        frm_buscar_talonario_cobro.ShowDialog(Me)
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btnFactura_Click(sender As Object, e As EventArgs) Handles btnFactura.Click
        frm_consulta_ventas.ShowDialog(Me)
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


            If chkSinEspecificar.Checked = False Then
                If CDate(dtpFechaInicial.Value) < CDate(dtpFechaInicial.Value) Then
                    MessageBox.Show("La fecha inicial es mayor a la fecha inicial" & vbNewLine & vbNewLine & "Por favor revisar las fechas para procesar el reporte.", "Rangos de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@Fecha
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Fecha")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            If chkSinEspecificar.Checked = True Then
                With crParameterRangeValue
                    .StartValue = dtpFechaInicial.MinDate
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpFechaFinal.MaxDate
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            Else
                With crParameterRangeValue
                    .StartValue = dtpFechaInicial.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpFechaFinal.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            End If
            crParameterValues.Add(crParameterRangeValue)
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

            '@Recepcion
            If txtIDRecepcion.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDRecepcion.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Recepcion")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Tipo
            If txtIDTipoRecibo.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDTipoRecibo.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Tipo")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Entrega
            If txtIDEntrega.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDEntrega.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Entrega")
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

            '@Talonario
            If txtIDTalonario.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDTalonario.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Talonario")
            crParameterValues.Add(crParameterDiscreteValue)
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

            '@Factura
            If txtIDFactura.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDFactura.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Factura")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Naturaleza
            If cbxNaturaleza.Text = "Todos" Then
                crParameterDiscreteValue.Value = 0
            ElseIf cbxNaturaleza.Text = "Recibos de cobros" Then
                crParameterDiscreteValue.Value = 0
            ElseIf cbxNaturaleza.Text = "Recibos de ingresos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxNaturaleza.Text = "Ajustes" Then
                crParameterDiscreteValue.Value = 3
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Naturaleza")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
          
            '@Cerrado
            If CbxCerrado.Text = "Todos" Then
                crParameterDiscreteValue.Value = 0
            ElseIf CbxCerrado.Text = "Sólo cerrados" Then
                crParameterDiscreteValue.Value = 1
            ElseIf CbxCerrado.Text = "Sólo abiertos" Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cerrado")
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
            If dtpFechaInicial.Value = dtpFechaFinal.Value Then
                ObjRpt.SetParameterValue("@RangoFechas", "Del " & dtpFechaFinal.Value.ToString("dd/MM/yyyy"))
            Else
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & dtpFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & dtpFechaFinal.Value.ToString("dd/MM/yyyy"))
            End If

            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

    Private Sub chkSinEspecificar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSinEspecificar.CheckedChanged
        If chkSinEspecificar.Checked = True Then
            dtpFechaInicial.Enabled = False
            dtpFechaFinal.Enabled = False
        Else
            dtpFechaInicial.Enabled = True
            dtpFechaFinal.Enabled = True
        End If
    End Sub
End Class