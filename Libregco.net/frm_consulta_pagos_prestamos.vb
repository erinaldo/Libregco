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
Public Class frm_consulta_pagos_prestamos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, lblIDCondicion, IDReport, NameReport, PathReport As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim SelectCommand As String = "SELECT IDAbonoPrestamosEmp,SecondID,Fecha,AbPrestEmp.IDEmpleado,Empleados.Nombre,Total,AbPrestEmp.Nulo FROM abprestemp INNER JOIN Empleados on abprestemp.IDEmpleado=Empleados.IDEmpleado"
    Dim FullCommand, FechaValue, IDAlmacenValue, IDEmpleadoValue, NuloValue As String
    Dim A1, A2, A3, A4 As String

    Private Sub frm_consulta_prestamos_empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDAbonoPrestamosEmp,SecondID,Fecha,AbPrestEmp.IDEmpleado,Empleados.Nombre,Total,AbPrestEmp.Nulo FROM abprestemp INNER JOIN Empleados on abprestemp.IDEmpleado=Empleados.IDEmpleado Where abprestemp.Fecha BETWEEN '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and abprestemp.Nulo=0", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='AbonoPrestamo' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoAbonoPrestamos' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDAlmacen.Clear()
        txtAlmacen.Clear()
        txtIDEmpleado.Clear()
        txtEmpleado.Clear()
        cbxEstado.Text = "Todos"
        lblNulo.Text = 0
        lblIDCondicion.Text = 0
        txtIDAlmacen.Focus()
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
            Adaptador.Fill(Ds, "Prestamos")
            DgvPrestamos.DataSource = Ds
            DgvPrestamos.DataMember = "Prestamos"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvPrestamos.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvPrestamos.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvPrestamos.Rows(x).Cells(5).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvPrestamos.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvPrestamos.Rows
                If CInt(Row.Cells(6).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvPrestamos
            .Columns(0).Visible = False

            .Columns(1).HeaderText = "Pago Prest."
            .Columns(1).Width = 120

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = 90

            .Columns(3).Width = 100
            .Columns(3).HeaderText = "ID Emp."

            .Columns(4).HeaderText = "Empleado"
            .Columns(4).Width = 320

            .Columns(5).HeaderText = "Total"
            .Columns(5).Width = 120
            .Columns(5).DefaultCellStyle.Format = "C"

            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub SelectEmpleado()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDEmpleado.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Empleados")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Empleados")
            txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))

        Catch ex As Exception
            txtEmpleado.Text = ""
        End Try
    End Sub

    Private Sub SelectAlmacen()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Almacen FROM Almacen Where IDAlmacen='" + txtIDAlmacen.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Almacen")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Almacen")
            txtAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

        Catch ex As Exception
            txtAlmacen.Text = ""
        End Try
    End Sub

    Private Sub txtIDEmpleado_Leave(sender As Object, e As EventArgs) Handles txtIDEmpleado.Leave
        SelectEmpleado()
        VerificarCondicionEmpleado()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtIDAlmacen_Leave(sender As Object, e As EventArgs) Handles txtIDAlmacen.Leave
        SelectAlmacen()
        VerificarCondicionAlmacen()
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

    Sub VerificarCondicionEmpleado()
        If txtIDEmpleado.Text = "" Then
            IDEmpleadoValue = ""
        Else
            IDEmpleadoValue = " AbPrestEmp.IDEmpleado=" & txtIDEmpleado.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionAlmacen()
        If txtIDAlmacen.Text = "" Then
            IDAlmacenValue = ""
        Else
            IDAlmacenValue = " Almacen.IDAlmacen=" & txtIDAlmacen.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " AbPrestEmp.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If cbxEstado.Text = "Todos" Then
            NuloValue = ""

        ElseIf cbxEstado.Text = "Sólo Activos" Then
            NuloValue = " AbPrestEmp.Nulo=0 "

        ElseIf cbxEstado.Text = "Nulos" Then
            NuloValue = " AbPrestEmp.Nulo=1 "

        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionEmpleado()
        VerificarCondicionAlmacen()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDEmpleadoValue <> "" Or IDAlmacenValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDEmpleadoValue & IDAlmacenValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDEmpleadoValue <> "" And IDAlmacenValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDAlmacenValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDEmpleadoValue & A2 & IDAlmacenValue & A3 & NuloValue
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
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

    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If DgvPrestamos.Rows.Count = 0 Then
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
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDEmpleado
                If txtIDEmpleado.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDEmpleado.Text
                End If

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEmpleado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                If txtIDAlmacen.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDAlmacen.Text
                End If

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDAlmacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDSucursal
                crParameterDiscreteValue.Value = 0
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
                'RangoFechas()
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "No. Nómina")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Nómina")
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvPrestamos.SelectedRows.Count > 0 Then
                    Dim IDPrestamos As New Label
                    IDPrestamos.Text = DgvPrestamos.SelectedRows(0).Cells(0).Value

                    If DgvPrestamos.SelectedRows(0).Cells(6).Value = 1 Then
                        MessageBox.Show("El documento de registro de pagos a préstamo " & DgvPrestamos.SelectedRows(0).Cells(1).Value & " de fecha " & DgvPrestamos.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar el registro.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDPrestamos.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
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

    Private Sub btnAlmacen_Click(sender As Object, e As EventArgs) Handles btnAlmacen.Click
        frm_buscar_almacen_mant.ShowDialog(Me)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If DgvPrestamos.SelectedRows.Count > 0 Then
                Dim IDAbonoPrestamo As New Label
                IDAbonoPrestamo.Text = DgvPrestamos.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDAbonoPrestamosEmp,abprestemp.SecondID,abprestemp.IDTipoDocumento,TipoDocumento.Documento,abprestemp.Fecha,abprestemp.Hora,abprestemp.IDUsuario,Usuarios.Nombre as NombreUsuario,abprestemp.IDEmpleado,Empleados.Nombre,Empleados.Cedula,Empleados.Direccion,Empleados.TelefonoPersonal,abprestemp.IDSucursal,Sucursal.Sucursal,abprestemp.IDAlmacen,Almacen.Almacen,abprestemp.IDEquipo,AreaImpresion.ComputerName,Total,abprestemp.BalanceAnterior,abprestemp.Concepto,Referencia,abprestemp.Impreso,abprestemp.Nulo,ifnull((Select Fecha from abprestemp where AbPrestEmp.IDEmpleado=Empleados.IDEmpleado and abprestemp.Nulo=0 ORDER BY IDAbonoPrestamosEmp DESC LIMIT 1),'No Encontrado') AS UltimoFechaPago,ifnull((Select Total from abprestemp where AbPrestEmp.IDEmpleado=Empleados.IDEmpleado and abprestemp.Nulo=0 ORDER BY IDAbonoPrestamosEmp DESC LIMIT 1),0) AS UltimoMontoPago FROM abprestemp INNER JOIN TipoDocumento on abprestemp.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Empleados as Usuarios on abprestemp.IDUsuario=Usuarios.IDEmpleado INNER JOIN Empleados on abprestemp.IDEmpleado=Empleados.IDEmpleado INNER JOIN Sucursal on abprestemp.IDSucursal=Sucursal.IDSucursal INNER JOIN Almacen on abprestemp.IDAlmacen=Almacen.IDAlmacen INNER JOIN AreaImpresion on abprestemp.IDEquipo=AreaImpresion.IDEquipo where IDAbonoPrestamosEmp='" + IDAbonoPrestamo.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "AbonoPrestamo")
                Con.Close()

                Dim Tabla As DataTable = Ds1.Tables("AbonoPrestamo")

                If frm_descontar_prestamos.Visible = True Then
                    frm_descontar_prestamos.Close()
                End If

                frm_descontar_prestamos.Show(Me)
                frm_superclave.IDAccion.Text = 25
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    frm_descontar_prestamos.Close()
                    Exit Sub
                End If

                frm_descontar_prestamos.txtIDAbonoPrestamo.Text = (Tabla.Rows(0).Item("IDAbonoPrestamosEmp"))
                frm_descontar_prestamos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_descontar_prestamos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_descontar_prestamos.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_descontar_prestamos.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_descontar_prestamos.txtBalanceEmp.Text = CDbl(Tabla.Rows(0).Item("BalanceAnterior")).ToString("C")
                frm_descontar_prestamos.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
                frm_descontar_prestamos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoFechaPago"))
                frm_descontar_prestamos.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_descontar_prestamos.txtComentario.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_descontar_prestamos.txtMontoAplicar.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_descontar_prestamos.chkNulo.Checked = False
                Else
                    frm_descontar_prestamos.chkNulo.Checked = True
                End If

                frm_descontar_prestamos.FillPagosDetalle()
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class