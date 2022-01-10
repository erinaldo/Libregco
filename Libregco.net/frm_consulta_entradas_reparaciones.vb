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

Public Class frm_consulta_entradas_reparaciones

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDEntradaReparacion,EntradaReparacion.SecondID as SecondIDEntrada,EntradaReparacion.Fecha,Reparacion.IDSuplidor,Suplidor.Suplidor,Observaciones,EntradaReparacion.Nulo FROM" & SysName.Text & "EntradaReparacion INNER JOIN" & SysName.Text & "Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor"
    Dim FullCommand, FechaValue, IDSuplidorValue, IDStatusReparacionValue, IDEntradaValue, NuloValue As String
    Dim A1, A2, A3, A4 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_entradas_reparaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDEntradaReparacion,EntradaReparacion.SecondID as SecondIDEntrada,EntradaReparacion.Fecha,Reparacion.IDSuplidor,Suplidor.Suplidor,Observaciones,EntradaReparacion.Nulo FROM" & SysName.Text & "EntradaReparacion INNER JOIN" & SysName.Text & "Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor WHERE EntradaReparacion.Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and EntradaReparacion.Nulo=0 ORDER BY IDEntradaReparacion DESC", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='EntregasConduces' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoEntregasConduces' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDStatusReparacion.Clear()
        txtStatusReparacion.Clear()
        txtIDSuplidor.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
        txtIDEntrada.Clear()
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
    End Sub


    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Entregas")
            DgvEntregas.DataSource = Ds
            DgvEntregas.DataMember = "Entregas"
            ConMixta.Close()
            PropiedadColumnsDgv()
            MarcarCanceladas()
            DgvEntregas.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvEntregas
            .Columns(0).Visible = False

            .Columns(1).HeaderText = "No. Entrega"
            .Columns(1).Width = 110

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns(2).Width = 80

            .Columns(3).Width = 80
            .Columns(3).HeaderText = "Código"

            .Columns(4).Width = 300
            .Columns(4).HeaderText = "Suplidor"

            .Columns(5).Width = 180
            .Columns(5).HeaderText = "Observación"

            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub SelectSuplidor()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Suplidor FROM Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
            txtSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

            If txtSuplidor.Text = "" Then txtIDSuplidor.Clear()

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectCliente")
        End Try
    End Sub

    Private Sub SelectStatusReparacion()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM StatusReparacion Where IDStatusReparacion='" + txtIDStatusReparacion.Text + "'", ConLibregco)
            txtStatusReparacion.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

            If txtStatusReparacion.Text = "" Then txtIDStatusReparacion.Clear()

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectVendedor")
        End Try
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        SelectSuplidor()
        VerificarCondicionSuplidor()
    End Sub

    Private Sub txtIDStatusReparacion_Leave(sender As Object, e As EventArgs) Handles txtIDStatusReparacion.Leave
        SelectStatusReparacion()
        VerificarCondicionStatusReparacion()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
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

    Private Sub txtIDStatusReparacion_TextChanged(sender As Object, e As EventArgs) Handles txtIDStatusReparacion.TextChanged
        VerificarCondicionStatusReparacion()
    End Sub

    Private Sub VerificarCondicionStatusReparacion()
        If txtIDStatusReparacion.Text = "" Then
            IDStatusReparacionValue = ""
        Else
            IDStatusReparacionValue = " Reparacion.IDStatusReparacion=" & txtIDStatusReparacion.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionSuplidor()
        If txtIDSuplidor.Text = "" Then
            IDSuplidorValue = ""
        Else
            IDSuplidorValue = " Reparacion.IDSuplidor=" & txtIDSuplidor.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionIDReparacion()
        If txtIDEntrada.Text = "" Then
            IDEntradaValue = ""
        Else
            IDEntradaValue = " EntradaReparacion.SecondID='" & txtIDEntrada.Text & "' "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " EntradaReparacion.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 Then
            NuloValue = ""
        Else
            NuloValue = " EntradaReparacion.Nulo=0 "
        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionStatusReparacion()
        VerificarCondicionSuplidor()
        VerificarCondicionFecha()
        VerificarCondicionIDReparacion()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDSuplidorValue <> "" Or IDStatusReparacionValue <> "" Or IDEntradaValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDSuplidorValue & IDStatusReparacionValue & IDEntradaValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDSuplidorValue <> "" And IDStatusReparacionValue & IDEntradaValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDStatusReparacionValue <> "" And IDEntradaValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If IDEntradaValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDSuplidorValue & A2 & IDStatusReparacionValue & A3 & IDEntradaValue & A4 & NuloValue
    End Sub


    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvEntregas.Rows
                If CInt(Row.Cells(6).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception
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


            If DgvEntregas.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

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

                '@IDUsuario
                If txtIDStatusReparacion.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDStatusReparacion.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Producto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Producto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Medida
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Medida")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                If chkNulos.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                Else
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipOrden
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoOrden")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@StatusReparacion
                If txtIDStatusReparacion.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDStatusReparacion.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@StatusReparacion")
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
                ObjRpt.SetParameterValue("@SortedField", "")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Reparación")
                'RangoFechas()
                If CDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) = CDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) Then
                    ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaInicial.Value.ToString("dd/MM/yyyy"))
                Else
                    ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                End If 'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvEntregas.SelectedRows.Count > 0 Then
                    Dim IDEntrega As New Label
                    IDEntrega.Text = DgvEntregas.SelectedRows(0).Cells(0).Value

                    If DgvEntregas.SelectedRows(0).Cells(6).Value = 1 Then
                        MessageBox.Show("La entrega de reparación " & DgvEntregas.SelectedRows(0).Cells(1).Value & " de fecha " & DgvEntregas.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDEntrega.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                    Exit Sub
                End If
            End If

            LoadAnimation()

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
            lblStatusBar.Text = "Listo"

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
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

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub btnBuscarSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarStatus_Click(sender As Object, e As EventArgs) Handles btnBuscarStatus.Click
        frm_buscar_status_reparacion.ShowDialog(Me)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim DsFiller As New DataSet
            If DgvEntregas.SelectedRows.Count > 0 Then
                Dim IDEntrada, Nulo As New Label
                IDEntrada.Text = DgvEntregas.CurrentRow.Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT EntradaReparacion.IDEntradaReparacion,EntradaReparacion.SecondID as SecondIDEntradaReparacion,EntradaReparacion.IDTipoDocumento,TipoDocumento.Documento,EntradaReparacion.Fecha,EntradaReparacion.Hora,EntradaReparacion.IDUsuario,Usuarios.Nombre as NombreEmpleado,EntradaReparacion.IDReparacion,Reparacion.SecondID AS SecondIDReparacion,Reparacion.Fecha as FechaReparacion,Reparacion.Hora as HoraReparacion,Reparacion.IDUsuario as IDUsuarioReparacion,UsuariosReparacion.Nombre as NombreUsuarioReparacion,Reparacion.IDSuplidor,Suplidor.Suplidor as NombreSuplidor,Suplidor.Balance,Reparacion.IDTipoOrden,TipoOrdenReparacion.Descripcion as TipoOrdenReparacion,Reparacion.IDStatusReparacion,StatusReparacion.Descripcion as StatusReparacion,Reparacion.FechaPrometida,Reparacion.Comentario,Reparacion.Motivo,EntradaReparacion.SecondID,EntradaReparacion.IDSucursal,Sucursal.Sucursal,EntradaReparacion.IDAlmacen,Almacen.Almacen,Observaciones,EntradaReparacion.Impreso,EntradaReparacion.Nulo FROM" & SysName.Text & "entradareparacion INNER JOIN" & SysName.Text & "Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN" & SysName.Text & "Empleados as Usuarios on EntradaReparacion.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Sucursal on EntradaReparacion.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on EntradaReparacion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "TipoDocumento on EntradaReparacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as UsuariosReparacion on Reparacion.IDUsuario=UsuariosReparacion.IDEmpleado INNER JOIN" & SysName.Text & "StatusReparacion on Reparacion.IDStatusReparacion=StatusReparacion.IDStatusReparacion INNER JOIN Libregco.TipoOrdenReparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor Where IDEntradaReparacion='" + IDEntrada.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsFiller, "EntradaReparacion")
                ConMixta.Close()

                Dim Tabla As DataTable = DsFiller.Tables("EntradaReparacion")

                If frm_conduce_reparacion_entrada.Visible = True Then
                    frm_conduce_reparacion_entrada.Close()
                Else
                    frm_conduce_reparacion_entrada.Show(Me)
                End If

                frm_conduce_reparacion_entrada.txtIDEntrada.Text = (Tabla.Rows(0).Item("IDEntradaReparacion"))
                frm_conduce_reparacion_entrada.txtSecondID.Text = (Tabla.Rows(0).Item("SecondIDEntradaReparacion"))
                frm_conduce_reparacion_entrada.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_conduce_reparacion_entrada.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_conduce_reparacion_entrada.txtReparacion.Text = (Tabla.Rows(0).Item("SecondIDReparacion"))
                frm_conduce_reparacion_entrada.lblIDReparacion.Text = (Tabla.Rows(0).Item("IDReparacion"))
                frm_conduce_reparacion_entrada.txtTipoOrden.Text = (Tabla.Rows(0).Item("TipoOrdenReparacion"))
                frm_conduce_reparacion_entrada.txtStatusOrden.Text = (Tabla.Rows(0).Item("StatusReparacion"))
                frm_conduce_reparacion_entrada.txtMotivoGeneral.Text = (Tabla.Rows(0).Item("Motivo"))
                frm_conduce_reparacion_entrada.txtObservaciones.Text = (Tabla.Rows(0).Item("Observaciones"))
                frm_conduce_reparacion_entrada.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_conduce_reparacion_entrada.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("NombreSuplidor"))
                frm_conduce_reparacion_entrada.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                frm_conduce_reparacion_entrada.RefrescarDgvArticulos()
                frm_conduce_reparacion_entrada.FactStatus()

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_conduce_reparacion_entrada.chkNulo.Checked = True
                Else
                    frm_conduce_reparacion_entrada.chkNulo.Checked = False
                End If

                frm_conduce_reparacion_entrada.btnBuscarReparacion.Enabled = False
                Exit Sub

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtIDConduce_TextChanged(sender As Object, e As EventArgs) Handles txtIDEntrada.TextChanged
        VerificarCondicionIDReparacion()
    End Sub

End Class