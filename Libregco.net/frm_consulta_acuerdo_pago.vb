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

Public Class frm_consulta_acuerdo_pago

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "Select IDAcuerdoPago,SecondID,Fecha,AcuerdosPago.IDCliente,Deudor,Monto,CantidadCuotas,MontoCuotas,concat(DiasPago,' de c/mes') as DiasPago,Nulo FROM" & SysName.Text & "acuerdospago INNER JOIN Libregco.Clientes on AcuerdosPago.IDCliente=Clientes.IDCliente"
    Dim FullCommand, FechaValue, IDClienteValue, IDSucursalValue, NuloValue, BalanceValue, DiaValue As String
    Dim A1, A2, A3, A4, A5 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_acuerdo_pago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("Select IDAcuerdoPago,SecondID,Fecha,AcuerdosPago.IDCliente,Deudor,Monto,CantidadCuotas,MontoCuotas,concat(DiasPago,' de c/mes') as DiasPago,Nulo FROM" & SysName.Text & "acuerdospago INNER JOIN Libregco.Clientes on AcuerdosPago.IDCliente=Clientes.IDCliente WHERE Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0 ORDER BY IDAcuerdoPago DESC", ConMixta)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='AcuerdodePago' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Listados de acuerdos de pago' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDSucursal.Clear()
        txtSucursal.Clear()
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
        cbxBalance.Text = "Balances activos"
        chkEspecificarDia.Checked = False
        txtDia.Enabled = False
    End Sub

    Private Sub RefrescarTabla()
        Try
            Con.Open()
            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Acuerdos")
            DgvAcuerdos.DataSource = Ds
            DgvAcuerdos.DataMember = "Acuerdos"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvAcuerdos.ClearSelection()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            Con.Close()
        End Try
    End Sub


    Private Sub PropiedadColumnsDgv()
        Try
            With DgvAcuerdos
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Código"
                .Columns(1).Width = 90

                .Columns(2).HeaderText = "Fecha"
                .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
                .Columns(2).Width = 75

                .Columns(3).HeaderText = "ID"
                .Columns(3).Width = 60

                .Columns(4).Width = 220
                .Columns(4).HeaderText = "Deudor"

                .Columns(5).Width = 90
                .Columns(5).HeaderText = "Monto"
                .Columns(5).DefaultCellStyle.Format = "C"

                .Columns(6).Width = 40
                .Columns(6).HeaderText = "Cant."

                .Columns(7).Width = 90
                .Columns(7).HeaderText = "Monto C."
                .Columns(7).DefaultCellStyle.Format = "C"

                .Columns(8).Width = 120
                .Columns(8).HeaderText = "Días de pago"

                .Columns(9).Visible = False
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvAcuerdos.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvAcuerdos.Rows(x).Cells(5).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvAcuerdos.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectCliente()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Nombre from Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtCliente.Text = "" Then txtIDCliente.Clear()
    End Sub

    Private Sub SelectSucursal()
        Con.Open()
        cmd = New MySqlCommand("SELECT Sucursal FROM Sucursal Where IDSucursal='" + txtIDSucursal.Text + "'", Con)
        txtSucursal.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtSucursal.Text = "" Then txtIDSucursal.Clear()
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        SelectCliente()
        VerificarCondicionCliente()
    End Sub

    Private Sub txtIDSucursal_Leave(sender As Object, e As EventArgs) Handles txtIDSucursal.Leave
        SelectSucursal()
        VerificarCondicionSucursal()
    End Sub

    Private Sub VerificarCondicionSucursal()
        If txtIDSucursal.Text = "" Then
            IDSucursalValue = ""
        Else
            IDSucursalValue = " AcuerdosPago.IDSucursal=" & txtIDSucursal.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionCliente()
        If txtIDCliente.Text = "" Then
            IDClienteValue = ""
        Else
            IDClienteValue = " AcuerdosPago.IDCliente=" & txtIDCliente.Text & " "
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
            NuloValue = " AcuerdosPago.Nulo=0 "
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
        VerificarCondicionCliente()
        VerificarCondicionSucursal()
        VerificarCondicionNulo()
        VerificarCondicionBalance()
        VerificarCondicionDia()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDSucursalValue <> "" Or NuloValue <> "" Or BalanceValue <> "" Or DiaValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDSucursalValue & NuloValue & BalanceValue & DiaValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDSucursalValue & NuloValue & BalanceValue & DiaValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDSucursalValue <> "" And NuloValue & BalanceValue & DiaValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If NuloValue <> "" And BalanceValue & DiaValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        If BalanceValue <> "" And DiaValue <> "" Then
            A5 = " AND"
        Else
            A5 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDSucursalValue & A3 & NuloValue & A4 & BalanceValue & A5 & DiaValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvAcuerdos.Rows
                If CInt(Row.Cells(9).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
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

    Private Sub cbxBalance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBalance.SelectedIndexChanged
        VerificarCondicionBalance()
    End Sub

    Private Sub VerificarCondicionBalance()
        If cbxBalance.Text = "Balances activos" Then
            BalanceValue = "  Clientes.BalanceGeneral>0 "
        ElseIf cbxBalance.Text = "No balances" Then
            BalanceValue = " Clientes.BalanceGeneral=0 "
        ElseIf cbxBalance.Text = "Todos" Then
            BalanceValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionDia()
        If chkEspecificarDia.Checked = True Then
            DiaValue = " AcuerdosPago.DiasPago=" & txtDia.Value & " "
        Else
            DiaValue = ""
        End If
        ConstructorSQL()
    End Sub
    Private Sub chkEspecificarDia_CheckedChanged(sender As Object, e As EventArgs) Handles chkEspecificarDia.CheckedChanged
        If chkEspecificarDia.Checked = False Then
            txtDia.Enabled = False
        Else
            txtDia.Enabled = True
        End If
        VerificarCondicionDia()
    End Sub

    Private Sub txtDia_ValueChanged(sender As Object, e As EventArgs) Handles txtDia.ValueChanged
        VerificarCondicionDia()
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

            If TypeConnection.Text = 1 Then
                If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            Else
                ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net\", ""))
            End If
          
            If CDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) < CDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
                MessageBox.Show("La fecha inicial es mayor a la fecha inicial" & vbNewLine & vbNewLine & "Por favor revisar las fechas para procesar el reporte.", "Rangos de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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

                '@IDSucursal
                If txtIDSucursal.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSucursal.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDAlmacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDAlmacen")
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

                '@Balance
                If cbxBalance.Text = "Balances activos" Then
                    crParameterDiscreteValue.Value = 2
                ElseIf cbxBalance.Text = "No balances" Then
                    crParameterDiscreteValue.Value = 1
                ElseIf cbxBalance.Text = "Todos" Then
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Balance")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@DiasPago
                If chkEspecificarDia.Checked = False Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtDia.Value
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@DiasPago")
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
                ObjRpt.SetParameterValue("@SortedField", "No. Acuerdo")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Acuerdo")
                'RangoFechas()
                If txtFechaInicial.Value = txtFechaFinal.Value Then
                    ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                Else
                    ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                End If
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvAcuerdos.SelectedRows.Count > 0 Then
                    Dim IDAcuerdo As New Label
                    IDAcuerdo.Text = DgvAcuerdos.SelectedRows(0).Cells(0).Value
                    If DgvAcuerdos.SelectedRows(0).Cells(9).Value = 1 Then
                        MessageBox.Show("El documento de acuerdo de pago" & DgvAcuerdos.SelectedRows(0).Cells(1).Value & " de fecha " & DgvAcuerdos.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDAcuerdo.Text
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

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvAcuerdos.SelectedRows.Count > 0 Then
                Dim IDAcuerdo As New Label
                IDAcuerdo.Text = DgvAcuerdos.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDAcuerdoPago,SecondID,IDUsuario,Usuarios.Nombre as NombreUsuario,AcuerdosPago.IDSucursal,Sucursal.Sucursal,AcuerdosPago.IDAlmacen,Almacen.Almacen,Fecha,Hora,AcuerdosPago.IDCliente,Clientes.Nombre AS NombreCliente,Clientes.BalanceGeneral,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,IDGeneroDeudor,GeneroDeudor.Genero as GeneroDeudor,TratamientoDeudor,Deudor,DomicilioDeudor,IDIdentificacionDeudor,TipoIdentificacionDeudor.Descripcion as TipoIdentificacionDeudor,IdentificacionDEudor,NacionalidadDeudor,EstadoCivilDeudor,ProfesionDeudor,MunicipioDeudor,ProvinciaDeudor,IDGeneroAcreedor,GeneroAcreedor.Genero as GeneroAcreedor,TratamientoAcreedor,Acreedor,DomicilioAcreedor,IDTipoIdentificacionAcreedor,TipoIdentificacionAcreedor.Descripcion as TipoIdentificacionAcreedor,IdentificacionAcreedor,NacionalidadAcreedor,EstadoCivilAcreedor,ProfesionAcreedor,MunicipioAcreedor,ProvinciaAcreedor,FechaPago,Vencimiento,CiudadAcuerdo,IDGeneroNotario,GeneroNotario.Genero as GeneroNotario,Notario,NoRegistroNotario,DomicilioNotario,IDTipoIdentificacionNotario,TipoIdentificacionNotario.Descripcion as TipoIdentificacionNotario,IdentificacionNotario,NacionalidadNOtario,MunicipioNotario,ProvinciaNotario,Monto,CantidadCuotas,MontoCuotas,DiasPago,Interes,Testigo1,TipoIdentificacionTestigo1.Descripcion AS TipoIdentificacionTestigo1,IdentificacionTestigo1,DomicilioTestigo1,NacionalidadTestigo1,Testigo2,TipoIdentificacionTestigo2.Descripcion as TipoIdentificacionTestigo2,IdentificacionTestigo2,DomicilioTestigo2,NacionalidadTestigo2,AcuerdosPago.Nota,AcuerdosPago.Status,AcuerdosPago.Impreso,AcuerdosPago.Nulo FROM acuerdospago INNER JOIN Genero as GeneroDeudor on AcuerdosPago.IDGeneroDeudor=GeneroDeudor.IDGenero INNER JOIN Genero as GeneroAcreedor on AcuerdosPago.IDGeneroAcreedor=GeneroAcreedor.IDGenero INNER JOIN Genero as GeneroNotario on AcuerdosPago.IDGeneroNotario=GeneroNotario.IDGenero INNER JOIN TipoIdentificacion as TipoIdentificacionDeudor on AcuerdosPago.IDIdentificacionDeudor=TipoIdentificacionDeudor.IDTipoIdentificacion INNER JOIN TipoIdentificacion as TipoIdentificacionAcreedor on AcuerdosPago.IDTipoIdentificacionAcreedor=TipoIdentificacionAcreedor.IDTipoIdentificacion INNER JOIN TipoIdentificacion as TipoIdentificacionNotario on AcuerdosPago.IDTipoIdentificacionNotario=TipoIdentificacionNotario.IDTipoIdentificacion INNER JOIN TipoIdentificacion as TipoIdentificacionTestigo1 on AcuerdosPago.IDTipoIdentificacionTestigo1=TipoIdentificacionTestigo1.IDTipoIdentificacion INNER JOIN TipoIdentificacion as TipoIdentificacionTestigo2 on AcuerdosPago.IDTipoIdentificacionTestigo2=TipoIdentificacionTestigo2.IDTipoIdentificacion INNER JOIN Empleados as Usuarios on AcuerdosPago.IDUsuario=Usuarios.IDEmpleado INNER JOIN Sucursal on AcuerdosPago.IDSucursal=Sucursal.IDSucursal INNER JOIN Almacen on AcuerdosPago.IDAlmacen=Almacen.IDAlmacen INNER JOIN Clientes on AcuerdosPago.IDCliente=Clientes.IDCliente INNER JOIN Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion Where IDAcuerdoPago = '" + IDAcuerdo.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Acuerdo")
                Con.Close()

                Dim Tabla As DataTable = Ds1.Tables("Acuerdo")

                If frm_acuerdos_pago.Visible = True Then
                    frm_acuerdos_pago.Close()
                End If

                frm_acuerdos_pago.Show(Me)
                frm_superclave.IDAccion.Text = 12
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    frm_acuerdos_pago.Close()
                    Exit Sub
                End If

                frm_acuerdos_pago.txtIDAcuerdo.Text = (Tabla.Rows(0).Item("IDAcuerdoPago"))
                frm_acuerdos_pago.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_acuerdos_pago.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_acuerdos_pago.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_acuerdos_pago.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_acuerdos_pago.txtNombre.Text = (Tabla.Rows(0).Item("NombreCliente"))
                frm_acuerdos_pago.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_acuerdos_pago.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                frm_acuerdos_pago.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

                frm_acuerdos_pago.cbxGeneroDeudor.Text = (Tabla.Rows(0).Item("GeneroDeudor"))
                frm_acuerdos_pago.txtTratamientoDeudor.Text = (Tabla.Rows(0).Item("TratamientoDeudor"))
                frm_acuerdos_pago.txtDeudor.Text = (Tabla.Rows(0).Item("Deudor"))
                frm_acuerdos_pago.txtDomicilioDeudor.Text = (Tabla.Rows(0).Item("DomicilioDeudor"))
                frm_acuerdos_pago.cbxIdentificacionDeudor.Text = (Tabla.Rows(0).Item("TipoIdentificacionDeudor"))
                frm_acuerdos_pago.txtIdentificacionDeudor.Text = (Tabla.Rows(0).Item("IdentificacionDeudor"))
                frm_acuerdos_pago.txtNacionalidadDeudor.Text = (Tabla.Rows(0).Item("NacionalidadDeudor"))
                frm_acuerdos_pago.txtOcupacionDeudor.Text = (Tabla.Rows(0).Item("ProfesionDeudor"))
                frm_acuerdos_pago.txtMunicipioDeudor.Text = (Tabla.Rows(0).Item("MunicipioDeudor"))
                frm_acuerdos_pago.txtEstadoCivilDeudor.Text = (Tabla.Rows(0).Item("EstadoCivilDeudor"))
                frm_acuerdos_pago.txtProvinciaDeudor.Text = (Tabla.Rows(0).Item("ProvinciaDeudor"))

                frm_acuerdos_pago.cbxGeneroAcreedor.Text = (Tabla.Rows(0).Item("GeneroAcreedor"))
                frm_acuerdos_pago.txtTratamientoAcreedor.Text = (Tabla.Rows(0).Item("TratamientoAcreedor"))
                frm_acuerdos_pago.txtAcreedor.Text = (Tabla.Rows(0).Item("Acreedor"))
                frm_acuerdos_pago.txtDomicilioAcreedor.Text = (Tabla.Rows(0).Item("DomicilioAcreedor"))
                frm_acuerdos_pago.cbxIdentificacionAcreedor.Text = (Tabla.Rows(0).Item("TipoIdentificacionAcreedor"))
                frm_acuerdos_pago.txtIdentificacionAcreedor.Text = (Tabla.Rows(0).Item("IdentificacionAcreedor"))
                frm_acuerdos_pago.txtNacionalidadAcreedor.Text = (Tabla.Rows(0).Item("NacionalidadAcreedor"))
                frm_acuerdos_pago.txtOcupacionAcreedor.Text = (Tabla.Rows(0).Item("ProfesionAcreedor"))
                frm_acuerdos_pago.txtMunicipioAcreedor.Text = (Tabla.Rows(0).Item("MunicipioAcreedor"))
                frm_acuerdos_pago.txtProvinciaAcreedor.Text = (Tabla.Rows(0).Item("ProvinciaAcreedor"))
                frm_acuerdos_pago.txtEstadoCivilAcreedor.Text = (Tabla.Rows(0).Item("EstadoCivilAcreedor"))

                frm_acuerdos_pago.DtpFecha.Text = CDate(Tabla.Rows(0).Item("FechaPago")).ToString("yyyy-MM-dd")
                frm_acuerdos_pago.dtpVencimiento.Text = CDate(Tabla.Rows(0).Item("Vencimiento")).ToString("yyyy-MM-dd")
                frm_acuerdos_pago.txtCiudadAcuerdo.Text = (Tabla.Rows(0).Item("CiudadAcuerdo"))
                frm_acuerdos_pago.cbxGeneroNotario.Text = (Tabla.Rows(0).Item("GeneroNotario"))
                frm_acuerdos_pago.txtNotario.Text = (Tabla.Rows(0).Item("Notario"))
                frm_acuerdos_pago.txtNoRegistroNotario.Text = (Tabla.Rows(0).Item("NoRegistroNotario"))
                frm_acuerdos_pago.txtDomicilioNotario.Text = (Tabla.Rows(0).Item("DomicilioNotario"))
                frm_acuerdos_pago.cbxTipoIdentNotario.Text = (Tabla.Rows(0).Item("TipoIdentificacionNotario"))
                frm_acuerdos_pago.txtIdentificacionNotario.Text = (Tabla.Rows(0).Item("IdentificacionNotario"))
                frm_acuerdos_pago.txtNacionalidadNotario.Text = (Tabla.Rows(0).Item("NacionalidadNotario"))
                frm_acuerdos_pago.txtMunicipioAcuerdo.Text = (Tabla.Rows(0).Item("MunicipioNotario"))
                frm_acuerdos_pago.txtProvinciaAcuerdo.Text = (Tabla.Rows(0).Item("ProvinciaNotario"))

                frm_acuerdos_pago.txtDeuda.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_acuerdos_pago.txtCantidadCuotas.Text = (Tabla.Rows(0).Item("CantidadCuotas"))
                frm_acuerdos_pago.txtMontoCuotas.Text = CDbl(Tabla.Rows(0).Item("MontoCuotas")).ToString("C")
                frm_acuerdos_pago.txtDiasPago.Value = (Tabla.Rows(0).Item("DiasPago"))
                frm_acuerdos_pago.txtInteres.Text = CDbl(Tabla.Rows(0).Item("Interes")).ToString("P2")

                frm_acuerdos_pago.txtTestigo1.Text = (Tabla.Rows(0).Item("Testigo1"))
                frm_acuerdos_pago.cbxIdentificacionTestigo1.Text = (Tabla.Rows(0).Item("TipoIdentificacionTestigo1"))
                frm_acuerdos_pago.txtIdentificacionTestigo1.Text = (Tabla.Rows(0).Item("IdentificacionTestigo1"))
                frm_acuerdos_pago.txtDomicilioTestigo1.Text = (Tabla.Rows(0).Item("DomicilioTestigo1"))
                frm_acuerdos_pago.txtNacionalidadTestigo1.Text = (Tabla.Rows(0).Item("NacionalidadTestigo1"))

                frm_acuerdos_pago.txtTestigo2.Text = (Tabla.Rows(0).Item("Testigo2"))
                frm_acuerdos_pago.cbxIdentificacionTestigo2.Text = (Tabla.Rows(0).Item("TipoIdentificacionTestigo2"))
                frm_acuerdos_pago.txtIdentificacionTestigo2.Text = (Tabla.Rows(0).Item("IdentificacionTestigo2"))
                frm_acuerdos_pago.txtDomicilioTestigo2.Text = (Tabla.Rows(0).Item("DomicilioTestigo2"))
                frm_acuerdos_pago.txtNacionalidadTestigo2.Text = (Tabla.Rows(0).Item("NacionalidadTestigo2"))

                frm_acuerdos_pago.txtNotaAcuerdo.Text = (Tabla.Rows(0).Item("Nota"))
                frm_acuerdos_pago.lblStatus.Text = (Tabla.Rows(0).Item("Status"))
                frm_acuerdos_pago.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_acuerdos_pago.ChkNulo.Checked = False
                Else
                    frm_acuerdos_pago.ChkNulo.Checked = True
                End If
                If (Tabla.Rows(0).Item("Status")) = 0 Then
                    frm_acuerdos_pago.rdbAbierto.Checked = True
                Else
                    frm_acuerdos_pago.rdbCerrado.Checked = True
                End If
                frm_acuerdos_pago.DtpFecha.Text = CDate(Tabla.Rows(0).Item("FechaPago")).ToString("yyyy-MM-dd")

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class