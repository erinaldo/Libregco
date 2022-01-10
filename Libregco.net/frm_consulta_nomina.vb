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
Public Class frm_consulta_nomina

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim SelectCommand As String = "SELECT IDNomina,SecondID,Fecha,Nomina.IDTipoNomina,TipoNomina.Descripcion,Neto,Nomina.Nulo FROM nomina INNER JOIN TipoNomina on Nomina.IDTipoNomina=TipoNomina.IDTipoNomina"
    Dim FullCommand, FechaValue, IDSucursalValue, IDTipoNomina, NuloValue As String
    Dim A1, A2, A3, A4 As String

    Private Sub frm_consulta_nomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDNomina,SecondID,Fecha,Nomina.IDTipoNomina,TipoNomina.Descripcion,Neto,Nomina.Nulo FROM nomina INNER JOIN TipoNomina on Nomina.IDTipoNomina=TipoNomina.IDTipoNomina Where Nomina.Fecha BETWEEN '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nomina.Nulo=0", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Nomina' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Listado Nomina' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDSucursal.Clear()
        txtSucursal.Clear()
        txtIDTipoNomina.Clear()
        txtTipoNomina.Clear()
        cbxEstado.Text = "Todos"
        lblNulo.Text = 0
        txtIDTipoNomina.Focus()
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Value = Today
        txtFechaInicial.Value = Today
    End Sub

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            Con.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Nominas")
            DgvNominas.DataSource = Ds
            DgvNominas.DataMember = "Nominas"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvNominas.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvNominas.Rows
                If CInt(Row.Cells(8).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvNominas
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Nómina"
            .Columns(1).Width = 120
            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = 90

            .Columns(3).Width = 100
            .Columns(3).HeaderText = "ID Tipo"

            .Columns(4).HeaderText = "Tipo Nómina"
            .Columns(4).Width = 300

            .Columns(5).HeaderText = "Neto"
            .Columns(5).Width = 135
            .Columns(5).DefaultCellStyle.Format = "C"

            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim Counter As Integer = DgvNominas.Rows.Count
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = Counter Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvNominas.Rows(x).Cells(5).Value)

        x = x + 1
        GoTo Inicio
Fin:
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
        lblCantidad.Text = "Registros Encontrados: " & Counter
    End Sub

    Private Sub SelectSucursal()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Sucursal FROM Sucursal Where IDSucursal='" + txtIDSucursal.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Sucursal")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Sucursal")
            txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

        Catch ex As Exception
            txtSucursal.Text = ""
        End Try
    End Sub

    Private Sub SelectTipoNomina()
        Try

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM TipoNomina Where IDTipoNomina='" + txtIDTipoNomina.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "TipoNomina")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("TipoNomina")
            txtTipoNomina.Text = (Tabla.Rows(0).Item("Descripcion"))

        Catch ex As Exception
            txtTipoNomina.Text = ""
        End Try
    End Sub

    Private Sub txtIDSucursal_Leave(sender As Object, e As EventArgs) Handles txtIDSucursal.Leave
        SelectSucursal()
        VerificarCondicionSucursal()
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

    Private Sub txtIDTipoNomina_Leave(sender As Object, e As EventArgs) Handles txtIDTipoNomina.Leave
        SelectTipoNomina()
        VerificarCondicionTipoNomina()
    End Sub

    Sub VerificarCondicionTipoNomina()
        If txtIDTipoNomina.Text = "" Then
            IDTipoNomina = ""
        Else
            IDTipoNomina = " Nomina.IDTipoNomina=" & txtIDTipoNomina.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionSucursal()
        If txtIDSucursal.Text = "" Then
            IDSucursalValue = ""
        Else
            IDSucursalValue = " Nomina.IDSucursal=" & txtIDSucursal.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " Nomina.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If cbxEstado.Text = "Todos" Then
            NuloValue = ""

        ElseIf cbxEstado.Text = "Sólo Activos" Then
            NuloValue = " Nomina.Nulo=0 "

        ElseIf cbxEstado.Text = "Nulos" Then
            NuloValue = " Nomina.Nulo=1 "

        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionSucursal()
        VerificarCondicionTipoNomina()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDSucursalValue <> "" Or IDTipoNomina <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDSucursalValue & IDTipoNomina & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDSucursalValue <> "" And IDTipoNomina & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDTipoNomina <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDSucursalValue & A2 & IDTipoNomina & A3 & NuloValue
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay

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
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If DgvNominas.Rows.Count = 0 Then
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

                '@IDNomina
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDNomina")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                '@TipoNomina
                If txtIDTipoNomina.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDTipoNomina.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNomina")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDEmpleado
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEmpleado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDAlmacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Sucursal
                If txtIDSucursal.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSucursal.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
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
                ObjRpt.SetParameterValue("@SortedField", "No. Nómina")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Nómina")
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvNominas.SelectedRows.Count > 0 Then
                    Dim IDNomina As New Label
                    IDNomina.Text = DgvNominas.SelectedRows(0).Cells(0).Value

                    If DgvNominas.SelectedRows(0).Cells(6).Value = 1 Then
                        MessageBox.Show("El documento de registro de nómina " & DgvNominas.SelectedRows(0).Cells(1).Value & " de fecha " & DgvNominas.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar la nómina.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

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

                    '@IDNomina
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDNomina")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                    '@TipoNomina
                    If txtIDTipoNomina.Text = "" Then
                        crParameterDiscreteValue.Value = 0
                    Else
                        crParameterDiscreteValue.Value = txtIDTipoNomina.Text
                    End If
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNomina")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@IDUsuario
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@IDEmpleado
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEmpleado")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@IDAlmacen
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Sucursal
                    If txtIDSucursal.Text = "" Then
                        crParameterDiscreteValue.Value = 0
                    Else
                        crParameterDiscreteValue.Value = txtIDSucursal.Text
                    End If
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
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
                    ObjRpt.SetParameterValue("@SortedField", "No. Nómina")
                    ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Nómina")
                    'Usuario Info
                    ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                    ' '''''
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

    Private Sub cbxEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEstado.SelectedIndexChanged
        VerificarCondicionNulo()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If DgvNominas.SelectedRows.Count > 0 Then
                Dim IDNomina As New Label
                IDNomina.Text = DgvNominas.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDNomina,SecondID,Fecha,Hora,IDUsuario,Nomina.IDTipoNomina,Descripcion,FechaInicial,FechaFinal,Diario,Semanal,Quincenal,Mensual,TotalBruto,Corrientes,Deducciones,Neto,CantEmp,Nomina.Nulo FROM nomina INNER JOIN tiponomina on Nomina.IDTipoNomina=TipoNomina.IDTipoNomina Where IDNomina='" + IDNomina.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Nomina")
                Con.Close()

                Dim Tabla As DataTable = Ds1.Tables("Nomina")

                If frm_proceso_nomina.Visible = True Then
                    frm_proceso_nomina.Close()
                End If

                frm_proceso_nomina.Show(Me)
                frm_superclave.IDAccion.Text = 20
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    frm_proceso_nomina.Close()
                    Exit Sub
                End If

                frm_proceso_nomina.txtIDNomina.Text = (Tabla.Rows(0).Item("IDNomina"))
                frm_proceso_nomina.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_proceso_nomina.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_proceso_nomina.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_proceso_nomina.lblIDUsuario.Text = (Tabla.Rows(0).Item("IDUsuario"))
                frm_proceso_nomina.txtIDTipoNomina.Text = (Tabla.Rows(0).Item("IDTipoNomina"))
                frm_proceso_nomina.txtTipoNomina.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_proceso_nomina.DtpFechaInicial.Value = (Tabla.Rows(0).Item("FechaInicial"))
                frm_proceso_nomina.DtpFechaFinal.Value = (Tabla.Rows(0).Item("FechaFinal"))
                frm_proceso_nomina.chkDiario.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Diario"))
                frm_proceso_nomina.chkSemanal.Text = Convert.ToBoolean(Tabla.Rows(0).Item("Semanal"))
                frm_proceso_nomina.chkQuincenal.Text = Convert.ToBoolean(Tabla.Rows(0).Item("Quincenal"))
                frm_proceso_nomina.chkMensual.Text = Convert.ToBoolean(Tabla.Rows(0).Item("Mensual"))
                frm_proceso_nomina.txtTotalBruto.Text = CDbl(Tabla.Rows(0).Item("TotalBruto")).ToString("C")
                frm_proceso_nomina.txtDeduccionesCorrientes.Text = CDbl(Tabla.Rows(0).Item("Corrientes")).ToString("C")
                frm_proceso_nomina.txtTotalDeducciones.Text = CDbl(Tabla.Rows(0).Item("Deducciones")).ToString("C")
                frm_proceso_nomina.txtTotalNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                frm_proceso_nomina.txtCantidadEmpleados.Text = (Tabla.Rows(0).Item("CantEmp"))
                frm_proceso_nomina.chkNulo.Text = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                If (Tabla.Rows(0).Item("Diario")) = 1 Then
                    frm_proceso_nomina.chkDiario.Checked = True
                Else
                    frm_proceso_nomina.chkDiario.Checked = False
                End If

                If (Tabla.Rows(0).Item("Semanal")) = 1 Then
                    frm_proceso_nomina.chkSemanal.Checked = True
                Else
                    frm_proceso_nomina.chkSemanal.Checked = False
                End If

                If (Tabla.Rows(0).Item("Quincenal")) = 1 Then
                    frm_proceso_nomina.chkQuincenal.Checked = True
                Else
                    frm_proceso_nomina.chkQuincenal.Checked = False
                End If

                If (Tabla.Rows(0).Item("Mensual")) = 1 Then
                    frm_proceso_nomina.chkMensual.Checked = True
                Else
                    frm_proceso_nomina.chkMensual.Checked = False
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_proceso_nomina.chkNulo.Checked = True
                Else
                    frm_proceso_nomina.chkNulo.Checked = False
                End If

                RefrescarEmpleados()
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub RefrescarEmpleados()
        Try
            With frm_proceso_nomina
                .DgvEmpleados.Rows.Clear()
                Con.Open()

                Dim CmdEmpleados As New MySqlCommand("Select IDNominaDetalle,NominaDetalle.IDEmpleado,Empleados.Nombre,CargosEmp.Cargo,Bruto,Prestamos,CXC,Flota,TSS,ISR,Deducciones,Neto FROM NominaDetalle INNER JOIN Empleados on NominaDetalle.IDEmpleado=Empleados.IDEmpleado INNER JOIN CargosEmp on Empleados.IDCargo=CargosEmp.IDCargo WHERE IDNomina='" + frm_proceso_nomina.txtIDNomina.Text + "'", Con)
                Dim LectorEmpleados As MySqlDataReader = CmdEmpleados.ExecuteReader

                While LectorEmpleados.Read
                    .DgvEmpleados.Rows.Add(LectorEmpleados.GetValue(0), LectorEmpleados.GetValue(1), LectorEmpleados.GetValue(2), LectorEmpleados.GetValue(3), CDbl(LectorEmpleados.GetValue(4)).ToString("C"), CDbl(LectorEmpleados.GetValue(5)).ToString("C"), CDbl(LectorEmpleados.GetValue(6)).ToString("C"), CDbl(LectorEmpleados.GetValue(7)).ToString("C"), CDbl(LectorEmpleados.GetValue(8)).ToString("C"), CDbl(LectorEmpleados.GetValue(9)).ToString("C"), CDbl(LectorEmpleados.GetValue(10)).ToString("C"), CDbl(LectorEmpleados.GetValue(11)).ToString("C"))
                End While
                LectorEmpleados.Close()
                Con.Close()
            End With

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class