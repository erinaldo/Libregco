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

Public Class frm_reporte_clientes_referecias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_reporte_clientes_referecias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarLibregco()
        'Me.WindowState = CheckWindowState()
        LimpiarTodo()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarTodo()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtIDRelacion.Clear()
        txtRelacion.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
    End Sub

    Private Sub ActualizarTodo()
        FillReportes()
        chkResumir.Checked = False
        cbxTipoOrden.SelectedIndex = 0
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick

    End Sub

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Referencias' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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

    Private Sub btnRelacion_Click(sender As Object, e As EventArgs) Handles btnRelacion.Click
        frm_buscar_relacion_familiar.ShowDialog(Me)
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Nombre from Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtCliente.Text = "" Then txtIDCliente.Clear()
    End Sub

    Private Sub txtIDRelacion_Leave(sender As Object, e As EventArgs) Handles txtIDRelacion.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Relacion from RelacionFamiliar Where IDRelacionFamiliar='" + txtIDRelacion.Text + "'", ConLibregco)
        txtRelacion.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtRelacion.Text = "" Then txtIDRelacion.Clear()
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'Try
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim ObjRpt As New ReportDocument

        If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


        '@IDCliente
        If txtIDCliente.Text = "" Then
            crParameterDiscreteValue.Value = 0
        Else
            crParameterDiscreteValue.Value = txtIDCliente.Text
        End If
        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCliente")
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        '@IDRelacion
        If txtIDRelacion.Text = "" Then
            crParameterDiscreteValue.Value = 0
        Else
            crParameterDiscreteValue.Value = txtIDRelacion.Text
        End If
        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDRelacion")
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        'Nombre
        If txtNombre.Text = "" Then
            crParameterDiscreteValue.Value = "0"
        Else
            crParameterDiscreteValue.Value = txtNombre.Text
        End If
        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Nombre")
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        'Direccion
        If txtDireccion.Text = "" Then
            crParameterDiscreteValue.Value = "0"
        Else
            crParameterDiscreteValue.Value = txtDireccion.Text
        End If
        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Direccion")
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
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub
End Class