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
Public Class frm_consulta_entrega_cobros
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDEntregaCobro,SecondID,FechaEntrega,NoEntrega,IDCobrador,Cobrador.Nombre as Cobrador,Cantidad,NoInicial,NoFinal,Monto,EntregaCobro.Nulo,Comision FROM libregco.entregacobro INNER JOIN Libregco.Empleados as Cobrador on EntregaCobro.IDCobrador=Cobrador.IDEmpleado"
    Dim FullCommand, FechaValue, IDCobradorValue, IDUsuarioValue, NuloValue As String
    Dim A1, A2, A3, A4, A5 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_entrega_cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDEntregaCobro,SecondID,FechaEntrega,NoEntrega,IDCobrador,Cobrador.Nombre as Cobrador,Cantidad,NoInicial,NoFinal,Monto,EntregaCobro.Nulo,Comision FROM libregco.entregacobro INNER JOIN Libregco.Empleados as Cobrador on EntregaCobro.IDCobrador=Cobrador.IDEmpleado WHERE EntregaCobro.FechaEntrega Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and EntregaCobro.Nulo=0 ORDER BY IDEntregaCobro DESC", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='EntregaCobros' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoEntregasCobros' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDCobrador.Clear()
        txtCobrador.Clear()
        txtIDUsuario.Clear()
        txtUsuario.Clear()
        txtFechaInicial.Value = Today
        txtFechaFinal.Value = Today
        txtIDCobrador.Focus()
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
            Adaptador.Fill(Ds, "EntregasCobros")
            DgvEntregas.DataSource = Ds
            DgvEntregas.DataMember = "EntregasCobros"
            Con.Close()
            PropiedadColumnsDgv()
            MarcarCanceladas()
            DgvEntregas.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        Try
            Dim DatagridWith As Double = (DgvEntregas.Width - DgvEntregas.RowHeadersWidth) / 100
            With DgvEntregas
                .Columns(0).Visible = False
                '.Columns(0).HeaderText = "Clave Primaria"
                '.Columns(0).Width = 100
                '.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(1).HeaderText = "Código"
                .Columns(1).Width = DatagridWith * 12

                .Columns(2).HeaderText = "Fecha"
                .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
                .Columns(2).Width = DatagridWith * 10

                .Columns(3).HeaderText = "Entrega"
                .Columns(3).Width = DatagridWith * 12

                .Columns(4).HeaderText = "ID"
                .Columns(4).Width = DatagridWith * 8

                .Columns(5).Width = DatagridWith * 22
                .Columns(5).HeaderText = "Cobrador"

                .Columns(6).Width = DatagridWith * 8
                .Columns(6).HeaderText = "Cant."

                .Columns(7).Width = DatagridWith * 8
                .Columns(7).HeaderText = "Inicial"

                .Columns(8).Width = DatagridWith * 8
                .Columns(8).HeaderText = "Final"

                .Columns(9).Width = DatagridWith * 12
                .Columns(9).HeaderText = "Total"
                .Columns(9).DefaultCellStyle.Format = ("C")

                .Columns(10).Visible = False
                .Columns(11).Visible = False
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SelectCobrador()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDCobrador.Text + "'", Con)
        txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtCobrador.Text = "" Then txtIDCobrador.Clear()
    End Sub

    Private Sub SelectUsuario()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
        txtUsuario.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtUsuario.Text = "" Then txtIDUsuario.Clear()
    End Sub

    Private Sub txtIDCobrador_Leave(sender As Object, e As EventArgs) Handles txtIDCobrador.Leave, txtIDCobrador.Leave
        SelectCobrador()
        VerificarCondicionCobrador()
    End Sub

    Private Sub txtIDUsuario_Leave(sender As Object, e As EventArgs) Handles txtIDUsuario.Leave
        SelectUsuario()
        VerificarCondicionUsuario()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub VerificarCondicionUsuario()
        If txtIDUsuario.Text = "" Then
            IDUsuarioValue = ""
        Else
            IDUsuarioValue = " EntregaCobro.IDUsuario=" & txtIDUsuario.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCobrador()
        If txtIDCobrador.Text = "" Then
            IDCobradorValue = ""
        Else
            IDCobradorValue = " EntregaCobro.IDCobrador=" & txtIDCobrador.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " EntregaCobro.FechaEntrega BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 Then
            NuloValue = ""
        Else
            NuloValue = " EntregaCobro.Nulo=0 "
        End If
        ConstructorSQL()

    End Sub

    Private Sub SummaCond()
        VerificarCondicionUsuario()
        VerificarCondicionCobrador()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDCobradorValue <> "" Or IDUsuarioValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDCobradorValue & IDUsuarioValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDCobradorValue <> "" And IDUsuarioValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDUsuarioValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDCobradorValue & A2 & IDUsuarioValue & A3 & NuloValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvEntregas.Rows
                If CInt(Row.Cells(10).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCobrador_Click(sender As Object, e As EventArgs) Handles btnCobrador.Click
        frm_buscar_mant_empleados.Control.Text = 0
        frm_buscar_mant_empleados.ShowDialog(Me)
        VerificarCondicionCobrador()
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


            If DgvEntregas.Rows.Count = 0 Then
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

                '@Recepcion
                If txtIDUsuario.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDUsuario.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Recepcion")
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

                '@Sucursal
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Sucursal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
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

                '@Estado
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Setting Info 
                'Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "No. Entrega")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Entrega")
                'RangoFechas()
                If txtFechaInicial.Value = txtFechaFinal.Value Then
                    ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                Else
                    ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                End If
                '@Resumir
                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvEntregas.SelectedRows.Count > 0 Then
                    Dim IDEntrega As New Label
                    IDEntrega.Text = DgvEntregas.SelectedRows(0).Cells(0).Value

                    If DgvEntregas.SelectedRows(0).Cells(10).Value = 1 Then
                        MessageBox.Show("El documento de registro de entrega de cobros " & DgvEntregas.SelectedRows(0).Cells(1).Value & " de fecha " & DgvEntregas.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDEntrega.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Resumir
                    If chkResumir.Checked = True Then
                        ObjRpt.SetParameterValue("@Resumir", 1)
                    Else
                        ObjRpt.SetParameterValue("@Resumir", 0)
                    End If
                Else
                    MessageBox.Show("No hay una fila seleccionada.")
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

            If DgvEntregas.SelectedRows.Count > 0 Then
                Dim IDEntrega As New Label
                IDEntrega.Text = DgvEntregas.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDEntregaCobro,EntregaCobro.SecondID,NoEntrega,Descripcion,FechaEntrega,IDCobrador,Nombre,Cantidad,NoInicial,NoFinal,Monto,Comision,Cierre,EntregaCobro.Nulo FROM entregacobro INNER JOIN Empleados on EntregaCobro.IDCobrador=Empleados.IDEmpleado where IDEntregaCobro='" + IDEntrega.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "EntregaCobro")
                Con.Close()

                Dim Tabla As DataTable = Ds1.Tables("EntregaCobro")

                If frm_entrega_cobro.Visible = True Then
                    frm_entrega_cobro.Close()
                End If

                frm_entrega_cobro.Show(Me)

                frm_entrega_cobro.txtIDEntrega.Text = (Tabla.Rows(0).Item("IDEntregaCobro"))
                frm_entrega_cobro.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_entrega_cobro.txtNoEntrega.Text = (Tabla.Rows(0).Item("NoEntrega"))
                frm_entrega_cobro.txtNota.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_entrega_cobro.DtpFechaEntrega.Value = (Tabla.Rows(0).Item("FechaEntrega"))
                frm_entrega_cobro.lblIDCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))
                frm_entrega_cobro.CbxCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_entrega_cobro.txtCantidad.Text = (Tabla.Rows(0).Item("Cantidad"))
                frm_entrega_cobro.txtNoInicial.Text = (Tabla.Rows(0).Item("NoInicial"))
                frm_entrega_cobro.txtNoFinal.Text = (Tabla.Rows(0).Item("NoFinal"))
                frm_entrega_cobro.txtMontoEntrega.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_entrega_cobro.txtComision.Text = CDbl(Tabla.Rows(0).Item("Comision")).ToString("C")
                frm_entrega_cobro.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
                frm_entrega_cobro.lblCierreEntrega.Text = (Tabla.Rows(0).Item("Cierre"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_entrega_cobro.chkNulo.Checked = False
                Else
                    frm_entrega_cobro.chkNulo.Checked = True
                End If

                If (Tabla.Rows(0).Item("Cierre")) = 0 Then
                    frm_entrega_cobro.chkCerrarEntrega.Checked = False
                Else
                    frm_entrega_cobro.chkCerrarEntrega.Checked = True
                End If

                frm_entrega_cobro.RefrescarTablaRecibos()

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnUsuario_Click(sender As Object, e As EventArgs) Handles btnUsuario.Click
        frm_buscar_mant_empleados.Control.Text = 1
        frm_buscar_mant_empleados.ShowDialog(Me)
        VerificarCondicionUsuario()
    End Sub

    Private Sub DgvEntregas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvEntregas.KeyPress
        Try
            If Me.Owner.Name = frm_registro_ingresos_deducciones.Name Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    For Each Row As DataGridViewRow In DgvEntregas.SelectedRows
                        frm_registro_ingresos_deducciones.DgvDeducciones.Rows.Add("", Row.Cells(4).Value, Row.Cells(5).Value, CDate(Row.Cells(2).Value).ToString("dd/MM/yyyy"), frm_registro_ingresos_deducciones.lblIDDeduccion.Text, frm_registro_ingresos_deducciones.cbxDeducciones.Text, "Comisión de cobros del " & CDate(Row.Cells(2).Value).ToLongDateString & " " & Row.Cells(7).Value & "-" & Row.Cells(8).Value & ".", CDbl(Row.Cells(11).Value).ToString("C"), frm_registro_ingresos_deducciones.TypeFunction.Text)
                    Next

                    Close()
                End If
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
       

    End Sub
End Class