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

Public Class frm_consulta_pagos_financiamientos
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT pagosfinanciamientos.IDPagosFinanciamientos,pagosfinanciamientos.SecondID,pagosfinanciamientos.Fecha,Clientes.Nombre,TotalAplicado,pagosfinanciamientos.Nulo FROM" & SysName.Text & "pagosfinanciamientos INNER JOIN" & SysName.Text & "Financiamientos on PagosFinanciamientos.IDFinanciamiento=Financiamientos.IDFinanciamientos INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "AreaImpresion on PagosFinanciamientos.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal"
    Dim FullCommand, FechaValue, IDClienteValue, IDCobradorValue, NuloValue As String
    Dim A1, A2, A3, A4, A5 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_pagos_financiamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT pagosfinanciamientos.IDPagosFinanciamientos,pagosfinanciamientos.SecondID,pagosfinanciamientos.Fecha,Clientes.Nombre,TotalAplicado,pagosfinanciamientos.Nulo FROM" & SysName.Text & "pagosfinanciamientos INNER JOIN" & SysName.Text & "Financiamientos on PagosFinanciamientos.IDFinanciamiento=Financiamientos.IDFinanciamientos INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "AreaImpresion on PagosFinanciamientos.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal WHERE PagosFinanciamientos.Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and PagosFinanciamientos.Nulo=0 ORDER BY IDPagosFinanciamientos DESC", ConMixta)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='PagosFinanciamientos' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoPagosFinanciamientos' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtIDCobrador.Clear()
        txtCobrador.Clear()
        txtFechaInicial.Value = Today
        txtFechaFinal.Value = Today
        txtIDCliente.Focus()
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
            Adaptador.Fill(Ds, "Ingresos")
            DgvRecibos.DataSource = Ds
            DgvRecibos.DataMember = "Ingresos"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvRecibos.ClearSelection()
        Catch ex As Exception
            ConMixta.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        Try
            Dim DatagridWith As Double = (DgvRecibos.Width - DgvRecibos.RowHeadersWidth) / 100
            With DgvRecibos
                .Columns(0).Visible = False
                '.Columns(0).HeaderText = "Clave Primaria"
                '.Columns(0).Width = 100
                '.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(1).HeaderText = "Código"
                .Columns(1).Width = DatagridWith * 16

                .Columns(2).HeaderText = "Fecha"
                .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
                .Columns(2).Width = DatagridWith * 12

                .Columns(3).HeaderText = "Nombre"
                .Columns(3).Width = DatagridWith * 52

                .Columns(4).Width = DatagridWith * 20
                .Columns(4).HeaderText = "Total"
                .Columns(4).DefaultCellStyle.Format = ("C")

                .Columns(5).Visible = False
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvRecibos.Rows.Count Then
            GoTo Fin
        End If

        Monto = Monto + CDbl(DgvRecibos.Rows(x).Cells(4).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvRecibos.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectCliente()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtCliente.Text = "" Then txtIDCliente.Clear()
    End Sub

    Private Sub SelectCobrador()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDCobrador.Text + "'", Con)
        txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtCobrador.Text = "" Then txtIDCobrador.Clear()
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave, txtIDCliente.Leave
        SelectCliente()
        VerificarCondicionCliente()
    End Sub

    Private Sub txtIDSucursal_Leave(sender As Object, e As EventArgs) Handles txtIDCobrador.Leave
        SelectCobrador()
        VerificarCondicionCobrador()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub VerificarCondicionCobrador()
        If txtIDCobrador.Text = "" Then
            IDCobradorValue = ""
        Else
            IDCobradorValue = " Clientes.IDEmpleado=" & txtIDCobrador.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCliente()
        If txtIDCliente.Text = "" Then
            IDClienteValue = ""
        Else
            IDClienteValue = " Financiamientos.IDCliente=" & txtIDCliente.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " pagosfinanciamientos.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 Then
            NuloValue = ""
        Else
            NuloValue = " pagosfinanciamientos.Nulo=0 "
        End If
        ConstructorSQL()

    End Sub

    Private Sub SummaCond()
        VerificarCondicionCobrador()
        VerificarCondicionCliente()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDCobradorValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDCobradorValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDCobradorValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDCobradorValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDCobradorValue & A3 & NuloValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvRecibos.Rows
                If CInt(Row.Cells(5).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
        VerificarCondicionCliente()
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

            If DgvRecibos.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            If rdbGeneral.Checked = True Then
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

                '@IDFinanciamiento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDFinanciamiento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDCobrador
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCobrador")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDTipoFinanciamiento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDTipoFinanciamiento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDFormaPago
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDFormaPago")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDEquipo
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEquipo")
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

                'Setting Info 
                'Resumir Reporte
                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "Financiamientos")
                'RangoFechas()
                If txtFechaInicial.Value = txtFechaFinal.Value Then
                    ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaInicial.Value.ToString("dd/MM/yyyy"))
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

                    If DgvRecibos.SelectedRows(0).Cells(5).Value = 1 Then
                        MessageBox.Show("El documento de recibo de ingreso de financiamiento" & DgvRecibos.SelectedRows(0).Cells(1).Value & " de fecha " & DgvRecibos.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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
                frm_superclave.IDAccion.Text = 125
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                Dim IDRecibo As New Label
                IDRecibo.Text = DgvRecibos.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT pagosfinanciamientos.idpagosfinanciamientos,pagosfinanciamientos.idtipodocumento,tipodocumento.documento,pagosfinanciamientos.SecondID,pagosfinanciamientos.Fecha,pagosfinanciamientos.IDAreaImpresion,AreaImpresion.ComputerName,Almacen.Almacen,Sucursal.Sucursal,pagosfinanciamientos.IDUSuario,Usuarios.Nombre as NombreUsuario,pagosfinanciamientos.IDTransaccion,Transaccion.Efectivo,Transaccion.Cheque,Transaccion.Deposito,Transaccion.Informacion,Transaccion.Tarjeta,Transaccion.NoAprobacion,Recibido,Devuelta,pagosfinanciamientos.IDFinanciamiento,Financiamientos.SecondID as SecondIDFinanciamiento,Financiamientos.Fecha as FechaFinanciamiento,Financiamientos.Descripcion as DescripcionFinanciamiento,Financiamientos.IDTipoFinanciamiento,TipoFinanciamiento.Descripcion as TipoFinanciamiento,Financiamientos.IDCliente,Clientes.Nombre,Clientes.Direccion,Municipios.Municipio,Provincias.Provincia,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Calificacion.Calificacion,ClaseAnexa.Descripcion as ClaseAnexa,Clientes.Identificacion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.BalanceGeneral,Financiamientos.InteresMensual,Financiamientos.Balance as BalanceFinanciamiento,Financiamientos.BalanceLetra,PagosFinanciamientos.BalanceAnterior,PagosFinanciamientos.Concepto,PagosFinanciamientos.Debitos,pagosfinanciamientos.Descuentos,pagosfinanciamientos.TotalAplicado,pagosfinanciamientos.SumaLetra,pagosfinanciamientos.Impreso,pagosfinanciamientos.Nulo,idPagosFinanciamientos_Detalles,Financiamientos_cuotas.IDFinanciamientos_cuotas,Financiamientos_cuotas.NoCuota,Financiamientos_cuotas.FechaVencimiento,Financiamientos_cuotas.DiasVencidos,Financiamientos_cuotas.Monto,Financiamientos_cuotas.Capital,Financiamientos_cuotas.Interes,Cargo,Financiamientos_cuotas.Balance as BalanceCuota,BceCapitalAnterior,BceInteresAnterior,BceCargosAnterior,CapitalAplicado,InteresAplicado,CargosAplicados,DescuentosAplicado,InteresExonerado,CargosExonerado FROM" & SysName.Text & " pagosfinanciamientos INNER JOIN" & SysName.Text & "TipoDocumento on PagosFinanciamientos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as Usuarios on PagosFinanciamientos.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Financiamientos on PagosFinanciamientos.IDFinanciamiento=Financiamientos.IDFinanciamientos INNER JOIN Libregco.TipoFinanciamiento on Financiamientos.IDTipoFinanciamiento=TipoFinanciamiento.IDTipoFinanciamiento INNER JOIN" & SysName.Text & "AreaImpresion on PagosFinanciamientos.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Provincias on Municipios.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.ClaseAnexa on Clientes.IDTipoIdentificacion=ClaseAnexa.IDClaseAnexa INNER JOIN" & SysName.Text & "Transaccion on Financiamientos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN" & SysName.Text & "PagosFinanciamientos_detalles on PagosFinanciamientos.IDPagosFinanciamientos=PagosFinanciamientos_detalles.idPagosFinanciamientos INNER JOIN" & SysName.Text & "financiamientos_cuotas on PagosFinanciamientos_detalles.IDFinanciamientoCuota=Financiamientos_cuotas.idFinanciamientos_cuotas INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion Where pagosfinanciamientos.IDPagosFinanciamientos='" + IDRecibo.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "pagosfinanciamientos")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds.Tables("pagosfinanciamientos")

                If frm_cuotas_financiamientos.Visible = True Then
                    frm_cuotas_financiamientos.Close()
                End If

                frm_cuotas_financiamientos.txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
                frm_cuotas_financiamientos.txtNombre.Text = Tabla.Rows(0).Item("Nombre")
                frm_cuotas_financiamientos.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_cuotas_financiamientos.txtBalanceGeneralCargos.Text = (CDbl(Tabla.Rows(0).Item("BalanceGeneral")) + CDbl(Tabla.Rows(0).Item("CargosCliente"))).ToString("C")
                frm_cuotas_financiamientos.txtUltimoPago.Text = Tabla.Rows(0).Item("UltimoPago")
                frm_cuotas_financiamientos.txtCalificacion.Text = Tabla.Rows(0).Item("Calificacion")


                frm_cuotas_financiamientos.cbxFinanciamientos.Text = Tabla.Rows(0).Item("SecondIDFinanciamiento")
                frm_cuotas_financiamientos.txtConceptoPago.Text = Tabla.Rows(0).Item("Concepto")
                frm_cuotas_financiamientos.txtIDPagoFinanciamiento.Text = Tabla.Rows(0).Item("idpagosfinanciamientos")
                frm_cuotas_financiamientos.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                frm_cuotas_financiamientos.txtMontoAplicar.Text = CDbl(Tabla.Rows(0).Item("Debitos")).ToString("C")
                frm_cuotas_financiamientos.lblDescuento.Text = Tabla.Rows(0).Item("Descuentos")
                frm_cuotas_financiamientos.lblTotalAbono.Text = CDbl(Tabla.Rows(0).Item("Debitos")) + CDbl(Tabla.Rows(0).Item("Descuentos"))
                frm_cuotas_financiamientos.lblIDTransaccion.Text = Tabla.Rows(0).Item("IDTransaccion")
                frm_cuotas_financiamientos.txtFecha.Value = CDate(Tabla.Rows(0).Item("Fecha"))

                For Each dt As DataRow In Tabla.Rows
                    RemoveSavedRows(dt.Item("IDFinanciamientos_cuotas"))
                    frm_cuotas_financiamientos.DgvCuotas.Rows.Add(dt.Item("idPagosFinanciamientos_Detalles"), dt.Item("IDFinanciamientos_cuotas"), dt.Item("NoCuota"), CDate(dt.Item("FechaVencimiento")).ToString("dd/MM/yyyy"), CDbl(dt.Item("Monto")).ToString("C"), CDbl(dt.Item("BceCapitalAnterior")).ToString("C"), CDbl(dt.Item("BceInteresAnterior")).ToString("C"), CDbl(dt.Item("BceCargosAnterior")).ToString("C"), CDbl(dt.Item("BalanceCuota")).ToString("C"), CDbl(dt.Item("CapitalAplicado")).ToString("C4"), CDbl(dt.Item("InteresAplicado")).ToString("C4"), CDbl(dt.Item("CargosAplicados")).ToString("C4"), CDbl(dt.Item("DescuentosAplicado")).ToString("C4"), CDbl(dt.Item("InteresExonerado")).ToString("C4"), CDbl(dt.Item("CargosExonerado")).ToString("C4"), False, CDbl(CDbl(dt.Item("BceCapitalAnterior")) + CDbl(dt.Item("BceInteresAnterior")) + CDbl(dt.Item("BceCargosAnterior")) - CDbl(dt.Item("CapitalAplicado")) - CDbl(dt.Item("InteresAplicado")) - CDbl(dt.Item("CargosAplicados")) - CDbl(dt.Item("DescuentosAplicado")) - CDbl(dt.Item("InteresExonerado")) - CDbl(dt.Item("CargosExonerado"))).ToString("C4"))
                Next

                frm_cuotas_financiamientos.chkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                frm_cuotas_financiamientos.DgvCuotas.Sort(frm_cuotas_financiamientos.DgvCuotas.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnSucursal_Click(sender As Object, e As EventArgs) Handles btnCobrador.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
        VerificarCondicionCobrador()
    End Sub

    Private Sub RemoveSavedRows(ByVal IDCuota As Integer)
        Try
            For Each rw As DataGridViewRow In frm_cuotas_financiamientos.DgvCuotas.Rows
                If IDCuota = rw.Cells(1).Value Then
                    frm_cuotas_financiamientos.DgvCuotas.Rows.Remove(rw)
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub
End Class