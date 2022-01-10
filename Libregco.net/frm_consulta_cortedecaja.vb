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

Public Class frm_consulta_cortedecaja
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim SelectCommand As String = "SELECT IDCorteCaja,SecondID,Fecha,IDCreadorUsuario,Empleados.Nombre,ContadoTotal,RetiroTotal,CorteCaja.Nulo FROM" & SysName.Text & "cortecaja INNER JOIN" & SysName.Text & "Empleados on CorteCaja.IDCreadorUsuario=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "AreaImpresion on CorteCaja.IDAreaImpresionCreador=AreaImpresion.IDEquipo"
    Dim FullCommand, FechaValue, IDUsuarioValue, IDAlmacenValue, NuloValue As String
    Dim A1, A2, A3 As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim lblNulo, lblIDCondicion, IDReport, NameReport, PathReport, Duplicidad As New Label
    Dim Permisos As New ArrayList
    Private Sub frm_consulta_cortedecaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDCorteCaja,SecondID,Fecha,IDCreadorUsuario,Empleados.Nombre,ContadoTotal,RetiroTotal,CorteCaja.Nulo FROM" & SysName.Text & "cortecaja INNER JOIN" & SysName.Text & "Empleados on CorteCaja.IDCreadorUsuario=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "AreaImpresion on CorteCaja.IDAreaImpresionCreador=AreaImpresion.IDEquipo WHERE DATE(Fecha) Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and CorteCaja.Nulo=0 ORDER BY IDCorteCaja DESC", ConMixta)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='CortedeCaja' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoCortedeCaja' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDUsuario.Clear()
        txtUsuario.Clear()
        txtIDAlmacen.Clear()
        txtAlmacen.Clear()
        txtFechaInicial.Value = Today
        txtFechaFinal.Value = Today
        txtIDUsuario.Focus()
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
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CortesCaja")
            DgvCortes.DataSource = Ds
            DgvCortes.DataMember = "CortesCaja"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvCortes.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        Try
            Dim DatagridWith As Double = (DgvCortes.Width - DgvCortes.RowHeadersWidth) / 100
            With DgvCortes
                .Columns(0).Visible = False
                '.Columns(0).HeaderText = "Clave Primaria"
                '.Columns(0).Width = 100
                '.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(1).HeaderText = "Código"
                .Columns(1).Width = DatagridWith * 14

                .Columns(2).HeaderText = "Fecha"
                .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy hh:mm:ss tt")
                .Columns(2).Width = DatagridWith * 18

                .Columns(3).Width = DatagridWith * 10
                .Columns(3).HeaderText = "ID Usu."

                .Columns(4).Width = DatagridWith * 30
                .Columns(4).HeaderText = "Usuario"

                .Columns(5).Width = DatagridWith * 14
                .Columns(5).HeaderText = "Contado"
                .Columns(5).DefaultCellStyle.Format = ("C")

                .Columns(6).Width = DatagridWith * 14
                .Columns(6).HeaderText = "Retirado"
                .Columns(6).DefaultCellStyle.Format = ("C")

                .Columns(7).Visible = False
            End With
        Catch ex As Exception

        End Try


    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvCortes.Rows.Count Then
            GoTo Fin
        End If

        Monto = Monto + CDbl(DgvCortes.Rows(x).Cells(6).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvCortes.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectUsuario()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDUsuario.Text + "'", ConLibregco)
            txtUsuario.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
            If txtUsuario.Text = "" Then txtIDUsuario.Clear()
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectCliente")
            txtUsuario.Text = ""
        End Try
    End Sub

    Private Sub SelectAlmacen()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Almacen FROM Almacen Where IDAlmacen='" + txtIDAlmacen.Text + "'", ConLibregco)
            txtAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
            If txtAlmacen.Text = "" Then txtIDAlmacen.Clear()
        Catch ex As Exception
            txtAlmacen.Text = ""
            'MessageBox.Show(ex.Message.ToString & " Desde SelectVendedor")
        End Try
    End Sub

    Private Sub txtIDUsuario_Leave(sender As Object, e As EventArgs) Handles txtIDUsuario.Leave
        SelectUsuario()
        VerificarCondicionUsuario
    End Sub

    Private Sub txtIDAlmacen_Leave(sender As Object, e As EventArgs) Handles txtIDAlmacen.Leave
        SelectAlmacen
        VerificarCondicionAlmacen
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub txtIDUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtIDUsuario.TextChanged
        VerificarCondicionUsuario
    End Sub

    Private Sub VerificarCondicionUsuario()
        If txtIDUsuario.Text = "" Then
            IDUsuarioValue = ""
        Else
            IDUsuarioValue = " CorteCaja.IDCreadorUsuario=" & txtIDUsuario.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionAlmacen()
        If txtIDAlmacen.Text = "" Then
            IDAlmacenValue = ""
        Else
            IDAlmacenValue = " AreaImpresion.IDAlmacen=" & txtIDAlmacen.Text & " "
        End If

        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " DATE(Fecha) BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " CorteCaja.Nulo=0 "
        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionUsuario()
        VerificarCondicionAlmacen()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDUsuarioValue <> "" Or IDAlmacenValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDUsuarioValue & IDAlmacenValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDUsuarioValue <> "" And IDAlmacenValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDAlmacenValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If


        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDUsuarioValue & A2 & IDAlmacenValue & A3 & NuloValue

    End Sub


    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvCortes.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
        VerificarCondicionUsuario()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub btnSucursal_Click(sender As Object, e As EventArgs) Handles btnAlmacen.Click
        frm_buscar_almacen_mant.ShowDialog(Me)
        VerificarCondicionAlmacen()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
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
        'Try
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim ObjRpt As New ReportDocument


        If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))

        If DgvCortes.Rows.Count = 0 Then
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

            '@IDSucursal
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDAlmacen
            If txtIDAlmacen.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDAlmacen.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDAlmacen")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            '@IDEquipo
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEquipo")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Estado
            If chkNulos.Checked = False Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = 2
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
            ObjRpt.SetParameterValue("@SortedField", "")
            ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "IDCorteCaja")
            'RangoFechas()
            ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        ElseIf rdbEspecifico.Checked = True Then
            If DgvCortes.SelectedRows.Count > 0 Then
                Dim IDCorteCaja As New Label
                IDCorteCaja.Text = DgvCortes.SelectedRows(0).Cells(0).Value

                If DgvCortes.SelectedRows(0).Cells(7).Value = 1 Then
                    MessageBox.Show("El documento de corte de caja " & DgvCortes.SelectedRows(0).Cells(1).Value & " de fecha " & DgvCortes.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                crParameterDiscreteValue.Value = IDCorteCaja.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If

                If Duplicidad.Text = 1 Then
                    ObjRpt.SetParameterValue("Duplicidad", "DUPLICADO")
                End If
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
        'ObjRpt.Dispose()

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))
        Duplicidad.Text = (Tabla.Rows(0).Item("ModoDuplicado"))

        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Visible = False
        Else
            chkResumir.Visible = True
        End If
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvCortes.SelectedRows.Count > 0 Then
                frm_superclave.IDAccion.Text = 129
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                Dim IDCorteCaja As New Label
                IDCorteCaja.Text = DgvCortes.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDCorteCaja,CorteCaja.IDTipoDocumento,TipoDocumento.Documento,CorteCaja.SecondID,CorteCaja.Fecha,IDCreadorUsuario,CreadorUsuario.Nombre as NombreCreadorUsuario,TodosUsuarios,CorteCaja.IDUsuario,Usuarios.Nombre as UsuarioCerrador,TodasCajas,CorteCaja.IDAreaImpresion,AreaImpresion.ComputerName,TodoRango,DesdeFecha,HastaFecha,ContadoEfectivo,ContadoCheque,ContadoTarjeta,ContadoTrans,ContadoVales,ContadoTotal,CalculadoEfectivo,CalculadoCheque,CalculadoTarjeta,CalculadoTrans,CalculadoVales,CalculadoTotal,DiferenciaEfectivo,DiferenciaCheque,DiferenciaTarjeta,DiferenciaTrans,DiferenciaVales,DiferenciaTotal,RetiroEfectivo,RetiroCheque,RetiroTarjeta,RetiroTrans,RetiroVales,RetiroTotal,CantidadTransacciones,CorteCaja.Nulo FROM" & SysName.Text & "cortecaja INNER JOIN" & SysName.Text & "AreaImpresion on CorteCaja.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Empleados as CreadorUsuario on CorteCaja.IDCreadorUsuario=CreadorUsuario.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuarios on CorteCaja.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "TipoDocumento on CorteCaja.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where CorteCaja.IDCorteCaja= '" + IDCorteCaja.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "CorteCaja")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds1.Tables("CorteCaja")
                If frm_corte_caja.Visible = True Then
                    frm_corte_caja.Close()
                End If

                frm_corte_caja.Hora.Enabled = False

                frm_corte_caja.txtIDCorte.Text = Tabla.Rows(0).Item("IDCorteCaja")
                frm_corte_caja.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                frm_corte_caja.txtFecha.Value = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                frm_corte_caja.txtHora.Value = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss tt")

                frm_corte_caja.cbxEmpleado.Text = If(Tabla.Rows(0).Item("TodosUsuarios") = 1, "Todos", Tabla.Rows(0).Item("UsuarioCerrador"))
                frm_corte_caja.cbxAreaImpresion.Text = If(Tabla.Rows(0).Item("TodasCajas") = 1, "Todos", Tabla.Rows(0).Item("ComputerName"))

                frm_corte_caja.chkTodoRango.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("TodoRango"))
                frm_corte_caja.dtpDesde.Value = CDate(Tabla.Rows(0).Item("DesdeFecha")).ToString("dd/MM/yyyy hh:mm:ss tt")
                frm_corte_caja.dtpHasta.Value = CDate(Tabla.Rows(0).Item("HastaFecha")).ToString("dd/MM/yyyy hh:mm:ss tt")

                frm_corte_caja.txtEfectivoContado.Text = CDbl(Tabla.Rows(0).Item("ContadoEfectivo")).ToString("C")
                frm_corte_caja.txtChequeContado.Text = CDbl(Tabla.Rows(0).Item("ContadoCheque")).ToString("C")
                frm_corte_caja.txtTarjetaContado.Text = CDbl(Tabla.Rows(0).Item("ContadoTarjeta")).ToString("C")
                frm_corte_caja.txtTransferenciaContado.Text = CDbl(Tabla.Rows(0).Item("ContadoTrans")).ToString("C")
                frm_corte_caja.txtEgresosContado.Text = CDbl(Tabla.Rows(0).Item("ContadoVales")).ToString("C")
                frm_corte_caja.txtTotalContado.Text = CDbl(Tabla.Rows(0).Item("ContadoTotal")).ToString("C")

                frm_corte_caja.txtEfectivoCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoEfectivo")).ToString("C")
                frm_corte_caja.txtChequeCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoCheque")).ToString("C")
                frm_corte_caja.txtTarjetaCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoTarjeta")).ToString("C")
                frm_corte_caja.txtTransferenciaCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoTrans")).ToString("C")
                frm_corte_caja.txtEgresosCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoVales")).ToString("C")
                frm_corte_caja.txtTotalCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoTotal")).ToString("C")

                frm_corte_caja.txtEfectivoDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaEfectivo")).ToString("C")
                frm_corte_caja.txtChequeDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaCheque")).ToString("C")
                frm_corte_caja.txtTarjetaDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaTarjeta")).ToString("C")
                frm_corte_caja.txtTransferenciaDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaTrans")).ToString("C")
                frm_corte_caja.txtEgresosDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaVales")).ToString("C")
                frm_corte_caja.txtTotalDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaTotal")).ToString("C")

                frm_corte_caja.txtEfectivoRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroEfectivo")).ToString("C")
                frm_corte_caja.txtChequeRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroCheque")).ToString("C")
                frm_corte_caja.txtTarjetaRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroTarjeta")).ToString("C")
                frm_corte_caja.txtTransferenciaRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroTrans")).ToString("C")
                frm_corte_caja.txtEgresosRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroVales")).ToString("C")
                frm_corte_caja.txtTotalRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroTotal")).ToString("C")
                frm_corte_caja.ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                Dim SQLSetence As String = "Select * from" & SysName.Text & "cortecajadetalleview where IDCorteCaja='" + Tabla.Rows(0).Item("IDCorteCaja").ToString + "'"
                Dim Bs As New BindingSource
                Dim BN As New BindingNavigator
                Dim DsTemp As New DataSet

                ConMixta.Open()
                cmd = New MySqlCommand(SQLSetence, ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "cortecajadetalleview")
                ConMixta.Close()

                Bs.DataMember = "cortecajadetalleview"
                Bs.DataSource = DsTemp
                BN.BindingSource = Bs
                frm_corte_caja.DgvTransacciones.DataSource = Bs
                frm_corte_caja.DgvTransacciones.ClearSelection()
                frm_corte_caja.PropiedadColumnsDvg()

                frm_corte_caja.dtpDesde.Enabled = False
                frm_corte_caja.dtpHasta.Enabled = False

                frm_corte_caja.cbxAreaImpresion.Enabled = False
                frm_corte_caja.cbxEmpleado.Enabled = False
                frm_corte_caja.chkTodoRango.Enabled = False

                frm_corte_caja.SumarTransacciones()

                frm_corte_caja.txtEfectivoContado.Focus()
                frm_corte_caja.txtEfectivoContado.SelectAll()

                DsTemp.Dispose()
                Tabla.Dispose()
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_consulta_cortedecaja_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDgv()
    End Sub

End Class