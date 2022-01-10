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
Public Class frm_consulta_recibos_cobros
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT reciboscobro.IDReciboCobro,reciboscobro.Fecha,EntregaCobro.SecondID as Entrega,PreRecibo,NoRecibo,reciboscobro.IDTipoRecibo,TipoRecibos.Descripcion,reciboscobro.Monto,RecibosCobro.Nulo FROM libregco.reciboscobro INNER JOIN Libregco.EntregaCobro on RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro INNER JOIN Libregco.TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo"
    Dim FullCommand, FechaValue, IDEntregaValue, IDTipoReciboValue, NuloValue As String
    Dim A1, A2, A3, A4, A5 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_recibos_cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT reciboscobro.IDReciboCobro,reciboscobro.Fecha,EntregaCobro.SecondID as Entrega,PreRecibo,NoRecibo,reciboscobro.IDTipoRecibo,TipoRecibos.Descripcion,reciboscobro.Monto,RecibosCobro.Nulo FROM libregco.reciboscobro INNER JOIN Libregco.EntregaCobro on RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro INNER JOIN Libregco.TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo WHERE RecibosCobro.Fecha Between '" + txtFechaInicial.Text + "' and '" + txtFechaFinal.Text + "' and RecibosCobro.Nulo=0 ORDER BY IDReciboCobro DESC", Con)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub CargarLibregco()
      PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ReciboCobroIndividual' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoRecibosCobro' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDEntrega.Clear()
        txtEntrega.Clear()
        txtIDTipoRecibo.Clear()
        txtTipoRecibo.Clear()
        txtFechaInicial.Value = Today
        txtFechaFinal.Value = Today
        txtIDEntrega.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
    End Sub

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            Con.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Recibos")
            DgvRecibos.DataSource = Ds
            DgvRecibos.DataMember = "Recibos"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvRecibos.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        Try
            Dim DatagridWith As Double = (DgvRecibos.Width - DgvRecibos.RowHeadersWidth) / 100
            With DgvRecibos
                .Columns(0).HeaderText = "ID"
                .Columns(0).Width = DatagridWith * 10
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(1).HeaderText = "Fecha"
                .Columns(1).DefaultCellStyle.Format = ("dd/MM/yyyy")
                .Columns(1).Width = DatagridWith * 10

                .Columns(2).HeaderText = "Entrega"
                .Columns(2).Width = DatagridWith * 15

                .Columns(3).HeaderText = "PRE"
                .Columns(3).Width = DatagridWith * 8

                .Columns(4).HeaderText = "#"
                .Columns(4).Width = DatagridWith * 10

                .Columns(5).Width = DatagridWith * 8
                .Columns(5).HeaderText = "ID/T"

                .Columns(6).Width = DatagridWith * 25
                .Columns(6).HeaderText = "Tipo"

                .Columns(7).Width = DatagridWith * 14
                .Columns(7).HeaderText = "Monto"
                .Columns(7).DefaultCellStyle.Format = ("C")

                .Columns(8).Visible = False
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvRecibos.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvRecibos.Rows(x).Cells(7).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvRecibos.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectEntrega()
        Con.Open()
        cmd = New MySqlCommand("SELECT SecondID FROM EntregaCobro Where IDEntregaCobro='" + txtIDEntrega.Text + "'", Con)
        txtEntrega.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtEntrega.Text = "" Then txtIDEntrega.Clear()
    End Sub

    Private Sub SelectTipoRecibo()
        Con.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoRecibos Where IDTipoRecibo='" + txtIDTipoRecibo.Text + "'", Con)
        txtTipoRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtTipoRecibo.Text = "" Then txtIDTipoRecibo.Clear()
    End Sub

    Private Sub txtIDEntrega_Leave(sender As Object, e As EventArgs) Handles txtIDEntrega.Leave, txtIDEntrega.Leave
        SelectEntrega()
        VerificarCondicionEntrega()
    End Sub

    Private Sub txtIDTipoRecibo_Leave(sender As Object, e As EventArgs) Handles txtIDTipoRecibo.Leave
        SelectTipoRecibo()
        VerificarCondicionTipoRecibo()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub VerificarCondicionEntrega()
        If txtIDEntrega.Text = "" Then
            IDEntregaValue = ""
        Else
            IDEntregaValue = " RecibosCobro.IDEntregaCobro=" & txtIDEntrega.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionTipoRecibo()
        If txtIDTipoRecibo.Text = "" Then
            IDTipoReciboValue = ""
        Else
            IDTipoReciboValue = " RecibosCobro.IDTipoRecibo=" & txtIDTipoRecibo.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " RecibosCobro.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 Then
            NuloValue = ""
        Else
            NuloValue = " RecibosCobro.Nulo=0 "
        End If
        ConstructorSQL()

    End Sub

    Private Sub SummaCond()
        VerificarCondicionEntrega()
        VerificarCondicionTipoRecibo()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDTipoReciboValue <> "" Or IDEntregaValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDTipoReciboValue & IDEntregaValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDTipoReciboValue <> "" And IDEntregaValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDEntregaValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDTipoReciboValue & A2 & IDEntregaValue & A3 & NuloValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvRecibos.Rows
                If CInt(Row.Cells(8).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarEntrega_Click(sender As Object, e As EventArgs) Handles btnEntrega.Click
        frm_buscar_entrega_cobros.ShowDialog(Me)
        VerificarCondicionEntrega()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
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
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If DgvRecibos.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            If rdbGeneral.Checked = True Then
                '@Fecha
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
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
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cobrador")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Recepcion
                crParameterDiscreteValue.Value = 0
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
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Grupo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Talonario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Talonario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Cliente
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cliente")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Factura
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Factura")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Naturaleza
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Naturaleza")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Cerrado
                crParameterDiscreteValue.Value = 2
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
                ObjRpt.SetParameterValue("@SortedField", "No. Recibo")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Recibo")
                'RangoFechas()
                If txtFechaInicial.Value = txtFechaFinal.Value Then
                    ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                Else
                    ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                End If

                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf rdbEspecifico.Checked = True Then
                If DgvRecibos.SelectedRows.Count > 0 Then
                    Dim IDRecibo As New Label
                    IDRecibo.Text = DgvRecibos.SelectedRows(0).Cells(0).Value

                    If DgvRecibos.SelectedRows(0).Cells(8).Value = 1 Then
                        MessageBox.Show("El documento de recibo de cobro " & DgvRecibos.SelectedRows(0).Cells(0).Value & " de fecha " & DgvRecibos.SelectedRows(0).Cells(1).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDRecibo.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                    LoadAnimation()
                    Exit Sub
                End If
            End If

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ReportSource = ObjRpt
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
            LoadAnimation()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub frm_consulta_recibos_ingresos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDgv()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvRecibos.SelectedRows.Count > 0 Then
                Dim IDRecibo As New Label
                IDRecibo.Text = DgvRecibos.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID as SecondIDFactura,Documento,IDTransaccion,FacturaDatos.Fecha as FechaFactura,FacturaDatos.Hora as HoraFactura,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.IDAlmacen,Almacen,Almacen.IDSucursal,Sucursal.Sucursal,TipoComprobante,NCF,FacturaDatos.IDVendedor,Vendedor.Nombre as Vendedor,FActuraDatos.IDUsuario,Usuarios.Nombre as Usuario,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FacturaDatos.FechaVencimiento as VencimientoFactura,CondicionContado,SubTotal,FacturaDatos.Descuento as DescuentoFactura,Itbis,Flete,TotalNeto,FacturaDatos.Balance as BceFactura,Pagares.IDPagare,Pagares.NoPagare,Pagares.Cantidad,Clientes.IDCliente,FacturaDatos.NombreFactura,Clientes.Nombre as NombreCliente,FacturaDatos.DireccionFactura,Clientes.IDProvincia,Provincias.Provincia,Clientes.IDMunicipio,Municipios.Municipio,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.IDCalificacion,Calificacion.Calificacion,Clientes.IDEmpleado AS IDCobrador,Cobrador.Nombre as Cobrador,Clientes.BalanceGeneral,Clientes.Identificacion,RecibosCobro.IDReciboCobro,PreRecibo,NoRecibo,RecibosCobro.Fecha,RecibosCobro.Monto as MontoRecibo,RecibosCobro.Comentario,RecibosDetalle.Debito,RecibosDetalle.Descuento,RecibosDetalle.Debito+RecibosDetalle.Descuento AS Total,RecibosCobro.IDTipoRecibo,TipoRecibos.Descripcion as TipoRecibo,reciboscobro.Cierre,RecibosCobro.IDTalonario,TalonarioRecibo.SecondID as SecondIDTalonario,EntregaCobro.IDEntregaCobro,EntregaCobro.SecondID AS SecondIDEntrega,EntregaCobro.FechaEntrega,NoEntrega,EntregaCobro.IDCobrador as IDCobradorEntrega,CobradorEntrega.Nombre as CobradorEntrega,EntregaCobro.IDUsuario as IDRecepcion,Recepcion.Nombre as NombreRecepcion,GrupoRecibos.IDGrupoRecibos,GrupoRecibos.SecondID,GrupoRecibos.FechaEmision,GrupoRecibos.IDNaturaleza,NaturalezaRecibo.Descripcion as Naturaleza,naturalezarecibo.Abreviacion FROM Libregco.recibosdetalle INNER JOIN Libregco.RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro INNER JOIN Libregco.EntregaCobro on RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro INNER JOIN Libregco.TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo INNER JOIN Libregco.GrupoRecibos on RecibosCobro.IDGrupoRecibo=gruporecibos.IDGrupoRecibos INNER JOIN Libregco.NaturalezaRecibo on GrupoRecibos.IDNaturaleza=NaturalezaRecibo.IDNaturaleza INNER JOIN Libregco.Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Libregco.Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.Empleados as CobradorEntrega on EntregaCobro.IDCobrador=CobradorEntrega.IDEmpleado INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN Libregco.Empleados as Usuarios on FacturaDatos.IDUsuario=Usuarios.IDEmpleado INNER JOIN Libregco.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.TalonarioRecibo on RecibosCobro.IDTalonario=TalonarioRecibo.IDTalonarioRecibo INNER JOIN Libregco.Empleados as Recepcion on EntregaCobro.IDUsuario=Recepcion.IDEmpleado Where RecibosCobro.IDReciboCobro='" + IDRecibo.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Recibo")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("Recibo")

                If frm_registro_recibos_cobro.Visible = True Then
                    frm_registro_recibos_cobro.Close()
                End If

                frm_registro_recibos_cobro.Show(Me)
                frm_superclave.IDAccion.Text = 28
                frm_superclave.ShowDialog(Me)

                frm_registro_recibos_cobro.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_registro_recibos_cobro.txtNombre.Text = (Tabla.Rows(0).Item("NombreCliente"))
                frm_registro_recibos_cobro.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_registro_recibos_cobro.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                frm_registro_recibos_cobro.txtIDCobradorC.Text = (Tabla.Rows(0).Item("IDCobrador"))
                frm_registro_recibos_cobro.txtCobradorC.Text = (Tabla.Rows(0).Item("Cobrador"))
                frm_registro_recibos_cobro.FillCbxFacturas()
                frm_registro_recibos_cobro.VerificarCobrador()

                'Seleccionando numero de entrega
                Dim Founded As Boolean = False

                For Each itm As String In frm_registro_recibos_cobro.cbxNoEntrega.Items
                    If itm = (Tabla.Rows(0).Item("NoEntrega")) Then
                        Founded = True
                        Exit For
                    End If
                Next
                If Founded = False Then
                    frm_registro_recibos_cobro.cbxNoEntrega.Items.Add(Tabla.Rows(0).Item("NoEntrega"))
                    frm_registro_recibos_cobro.cbxNoEntrega.Text = (Tabla.Rows(0).Item("NoEntrega"))
                Else
                    frm_registro_recibos_cobro.cbxNoEntrega.Text = (Tabla.Rows(0).Item("NoEntrega"))
                End If

                frm_registro_recibos_cobro.cbxNoRecibo.Text = (Tabla.Rows(0).Item("PreRecibo")) & "-" & (Tabla.Rows(0).Item("NoRecibo"))

                If ControlSuperClave = 1 Then
                    frm_registro_recibos_cobro.Close()
                    Exit Sub
                End If

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnSucursal_Click(sender As Object, e As EventArgs) Handles btnTipoRecibo.Click
        frm_buscar_tipo_recibos.ShowDialog(Me)
        VerificarCondicionTipoRecibo()
    End Sub

   
End Class