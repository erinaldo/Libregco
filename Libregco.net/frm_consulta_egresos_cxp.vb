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

Public Class frm_consulta_egresos_cxp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDEgresos,SecondID,Fecha,Egresos.IDUsuario,Usuarios.Nombre,Monto,Concepto,Egresos.Nulo FROM egresos INNER JOIN Empleados as Usuarios on Egresos.IDUsuario=Usuarios.IDEmpleado"
    Dim FullCommand, FechaValue, IDUsuarioValue, IDSucursalValue, NuloValue As String
    Dim A1, A2, A3, A4, A5 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_egresos_cxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Permisos = PasarPermisos(Me.Tag)
        Actualizar()
        cmd = New MySqlCommand("SELECT IDEgresos,SecondID,Fecha,Egresos.IDUsuario,Usuarios.Nombre,Monto,Concepto,Egresos.Nulo FROM egresos INNER JOIN Empleados as Usuarios on Egresos.IDUsuario=Usuarios.IDEmpleado WHERE Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Egresos.Nulo=0 ORDER BY IDEgresos DESC", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='RecibosEgresosCXP' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoEgresos' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDSucursal.Clear()
        txtSucursal.Clear()
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
            Con.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Egresos")
            DgvEgresos.DataSource = Ds
            DgvEgresos.DataMember = "Egresos"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvEgresos.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub


    Private Sub PropiedadColumnsDgv()
        Try

            With DgvEgresos
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Código"
                .Columns(1).Width = 90

                .Columns(2).HeaderText = "Fecha"
                .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
                .Columns(2).Width = 80

                .Columns(3).HeaderText = "ID"
                .Columns(3).Width = 60

                .Columns(4).Width = 180
                .Columns(4).HeaderText = "Usuario"

                .Columns(5).Width = 120
                .Columns(5).HeaderText = "Monto"
                .Columns(5).DefaultCellStyle.Format = "C"

                .Columns(6).Width = 220
                .Columns(6).HeaderText = "Concepto"


                .Columns(7).Visible = False
            End With

        Catch ex As Exception

        End Try
    End Sub


    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvEgresos.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvEgresos.Rows(x).Cells(5).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvEgresos.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectUsuario()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
        txtUsuario.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtUsuario.Text = "" Then txtIDUsuario.Clear()
    End Sub

    Private Sub SelectSucursal()
        Con.Open()
        cmd = New MySqlCommand("SELECT Sucursal FROM Sucursal Where IDSucursal='" + txtIDSucursal.Text + "'", Con)
        txtSucursal.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtSucursal.Text = "" Then txtIDSucursal.Clear()
    End Sub

    Private Sub txtIDUsuario_Leave(sender As Object, e As EventArgs) Handles txtIDUsuario.Leave
        SelectUsuario()
        VerificarCondicionUsuario()
    End Sub

    Private Sub txtIDSucursal_Leave(sender As Object, e As EventArgs) Handles txtIDSucursal.Leave
        SelectSucursal()
        VerificarCondicionSucursal()
    End Sub

    Private Sub VerificarCondicionSucursal()
        If txtIDSucursal.Text = "" Then
            IDSucursalValue = ""
        Else
            IDSucursalValue = " Egresos.IDSucursal=" & txtIDSucursal.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionUsuario()
        If txtIDUsuario.Text = "" Then
            IDUsuarioValue = ""
        Else
            IDUsuarioValue = " Egresos.IDUsuario=" & txtIDUsuario.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 Then
            NuloValue = ""
        Else
            NuloValue = " Egresos.Nulo=0 "
        End If
        ConstructorSQL()

    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionFecha()
        VerificarCondicionUsuario()
        VerificarCondicionSucursal()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDUsuarioValue <> "" Or IDSucursalValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDUsuarioValue & IDSucursalValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDUsuarioValue <> "" And IDSucursalValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDSucursalValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDUsuarioValue & A2 & IDSucursalValue & A3 & NuloValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvEgresos.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnSucursal_Click(sender As Object, e As EventArgs) Handles btnSucursal.Click
        frm_buscar_sucursal.ShowDialog(Me)
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

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog()
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


            If DgvEgresos.Rows.Count = 0 Then
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

                '@Sucursal
                If txtIDSucursal.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSucursal.Text
                End If
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

                'Setting Info 
                'Resumir Reporte
                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "No. Egresos")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: No. de Egresos")
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
                If DgvEgresos.SelectedRows.Count > 0 Then
                    Dim IDEgresos As New Label
                    IDEgresos.Text = DgvEgresos.SelectedRows(0).Cells(0).Value

                    If DgvEgresos.SelectedRows(0).Cells(7).Value = 1 Then
                        MessageBox.Show("El documento de egresos " & DgvEgresos.SelectedRows(0).Cells(1).Value & " de fecha " & DgvEgresos.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDEgresos.Text
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

    Private Sub frm_consulta_otros_ingresos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDgv()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvEgresos.SelectedRows.Count > 0 Then
                Dim IDEgreso As New Label
                IDEgreso.Text = DgvEgresos.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT * FROM Egresos Where IDEgresos= '" + IDEgreso.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Egresos")
                Con.Close()

                Dim Tabla As DataTable = Ds1.Tables("Egresos")

                If frm_recibos_egresos.Visible = True Then
                    frm_recibos_egresos.Close()
                End If

                frm_recibos_egresos.Show(Me)
                frm_superclave.IDAccion.Text = 16
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    frm_recibos_egresos.Close()
                    Exit Sub
                End If
                frm_recibos_egresos.txtIDEgreso.Text = (Tabla.Rows(0).Item("IDEgresos"))
                frm_recibos_egresos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_recibos_egresos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_recibos_egresos.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_recibos_egresos.txtBeneficiario.Text = (Tabla.Rows(0).Item("Beneficiario"))
                frm_recibos_egresos.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_recibos_egresos.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_recibos_egresos.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_recibos_egresos.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_recibos_egresos.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_recibos_egresos.ChkNulo.Checked = False
                Else
                    frm_recibos_egresos.ChkNulo.Checked = True
                End If
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class