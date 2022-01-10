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
Public Class frm_consulta_ingresos_deducciones

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, lblIDCondicion, IDReport, NameReport, PathReport As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim SelectCommand As String = "SELECT IDeduccionesProcesadas,SecondID,Fecha,DeduccionesProcesadas.IDSucursal,Sucursal.Sucursal,DeduccionesProcesadas.IDAlmacen,Almacen.Almacen,deduccionesprocesadas.Nulo FROM deduccionesprocesadas INNER JOIN Sucursal on DeduccionesProcesadas.IDSucursal=Sucursal.IDSucursal INNER JOIN Almacen on DeduccionesProcesadas.IDAlmacen=Almacen.IDAlmacen"
    Dim FullCommand, FechaValue, IDSucursalValue, IDAlmacenValue, NuloValue As String
    Dim A1, A2, A3, A4 As String

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub frm_consulta_ingresos_deducciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDeduccionesProcesadas,SecondID,Fecha,DeduccionesProcesadas.IDSucursal,Sucursal.Sucursal,DeduccionesProcesadas.IDAlmacen,Almacen.Almacen,deduccionesprocesadas.Nulo FROM deduccionesprocesadas INNER JOIN Sucursal on DeduccionesProcesadas.IDSucursal=Sucursal.IDSucursal INNER JOIN Almacen on DeduccionesProcesadas.IDAlmacen=Almacen.IDAlmacen Where DeduccionesProcesadas.Fecha BETWEEN '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and DeduccionesProcesadas.Nulo=0", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='DeduccionesEmp' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Deducciones e Ingresos' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDAlmacen.Clear()
        txtAlmacen.Clear()
        cbxEstado.Text = "Todos"
        lblNulo.Text = 0
        lblIDCondicion.Text = 0
        txtIDSucursal.Focus()
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
            Adaptador.Fill(Ds, "DgvDeducciones")
            DgvDeducciones.DataSource = Ds
            DgvDeducciones.DataMember = "DgvDeducciones"
            Con.Close()
            PropiedadColumnsDgv()
            MarcarCanceladas()
            DgvDeducciones.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvDeducciones.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvDeducciones
            .Columns(0).Visible = False

            .Columns(1).HeaderText = "Registro"
            .Columns(1).Width = 120

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = 90

            .Columns(3).Width = 80
            .Columns(3).HeaderText = "ID Suc."

            .Columns(4).HeaderText = "Sucursal"
            .Columns(4).Width = 190

            .Columns(5).HeaderText = "ID Alm."
            .Columns(5).Width = 80

            .Columns(6).HeaderText = "Almacén"
            .Columns(6).Width = 190

            .Columns(7).Visible = False
        End With
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

    Sub VerificarCondicionSucursal()
        If txtIDSucursal.Text = "" Then
            IDSucursalValue = ""
        Else
            IDSucursalValue = " DeduccionesProcesadas.IDSucursal=" & txtIDSucursal.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionAlmacen()
        If txtIDAlmacen.Text = "" Then
            IDAlmacenValue = ""
        Else
            IDAlmacenValue = " DeduccionesProcesadas.IDAlmacen=" & txtIDAlmacen.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " DeduccionesProcesadas.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If cbxEstado.Text = "Todos" Then
            NuloValue = ""

        ElseIf cbxEstado.Text = "Sólo Activos" Then
            NuloValue = " DeduccionesProcesadas.Nulo=0 "

        ElseIf cbxEstado.Text = "Nulos" Then
            NuloValue = " DeduccionesProcesadas.Nulo=1 "

        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionSucursal()
        VerificarCondicionAlmacen()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDSucursalValue <> "" Or IDAlmacenValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDSucursalValue & IDAlmacenValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDSucursalValue <> "" And IDAlmacenValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDAlmacenValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDSucursalValue & A2 & IDAlmacenValue & A3 & NuloValue
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

    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If DgvDeducciones.Rows.Count = 0 Then
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

                '@IDDocumento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
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
                If txtIDAlmacen.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDAlmacen.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Deduccion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Deduccion")
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
                If DgvDeducciones.SelectedRows.Count > 0 Then
                    Dim IDDeduccion As New Label
                    IDDeduccion.Text = DgvDeducciones.SelectedRows(0).Cells(0).Value

                    If DgvDeducciones.SelectedRows(0).Cells(7).Value = 1 Then
                        MessageBox.Show("El documento de registro de deducciones e ingresos " & DgvDeducciones.SelectedRows(0).Cells(1).Value & " de fecha " & DgvDeducciones.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar el registro.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDDeduccion.Text
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
            Dim DsTemp As New DataSet
            If DgvDeducciones.SelectedRows.Count > 0 Then
                Dim IDDeduccion As New Label
                IDDeduccion.Text = DgvDeducciones.SelectedRows(0).Cells(0).Value

                DsTemp.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDeduccionesProcesadas,SecondID,Fecha,Hora,Nulo,Impreso FROM deduccionesprocesadas Where deduccionesprocesadas.IDeduccionesProcesadas='" + IDDeduccion.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "DeduccionesProcesadas")
                Con.Close()

                Dim Tabla As DataTable = DsTemp.Tables("DeduccionesProcesadas")

                frm_registro_ingresos_deducciones.Show(Me)

                frm_registro_ingresos_deducciones.txtIDDeduccionProc.Text = (Tabla.Rows(0).Item("IDeduccionesProcesadas"))
                frm_registro_ingresos_deducciones.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_registro_ingresos_deducciones.txtFechaPago.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                'frm_registro_ingresos_deducciones.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora")).ToString("HH:mm:ss")

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_registro_ingresos_deducciones.chkNulo.Checked = False
                Else
                    frm_registro_ingresos_deducciones.chkNulo.Checked = True
                End If

                frm_registro_ingresos_deducciones.RefrescarDeducciones()

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class