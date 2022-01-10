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
Public Class frm_consulta_movimientos_bancarios

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, IDReport, NameReport, PathReport As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim SelectCommand As String = "SELECT MovimientosBanco.IDMovimiento,MovimientosBanco.SecondID,MovimientosBanco.FechaMovimiento,MovimientosBanco.NoTransaccion,MovimientosBanco.IDTipoMovimientoBanc,CuentasBancarias.NoCuenta,Concepto,Total,MovimientosBanco.Nulo FROM movimientosbanco INNER JOIN CuentasBancarias on MovimientosBanco.IDCuentaBancaria=CuentasBancarias.IDCuenta INNER JOIN tipomovbancario on MovimientosBanco.IDTIpoMovimientoBanc=TipoMovBancario.IDTipoMovBancario"
    Dim FullCommand, FechaValue, IDCuentaBancariaValue, IDTipoMovimientoValue, TipoValorValue, NuloValue As String
    Dim A1, A2, A3, A4 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_movimientos_bancarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT MovimientosBanco.IDMovimiento,MovimientosBanco.SecondID,MovimientosBanco.FechaMovimiento,MovimientosBanco.NoTransaccion,MovimientosBanco.IDTipoMovimientoBanc,CuentasBancarias.NoCuenta,Concepto,Total,MovimientosBanco.Nulo FROM movimientosbanco INNER JOIN CuentasBancarias on MovimientosBanco.IDCuentaBancaria=CuentasBancarias.IDCuenta INNER JOIN tipomovbancario on MovimientosBanco.IDTIpoMovimientoBanc=TipoMovBancario.IDTipoMovBancario Where movimientosbanco.FechaMovimiento BETWEEN '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and movimientosbanco.Nulo=0", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='MovimientosBancarios' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoMovimientosBancarios' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDTipoMovimiento.Clear()
        txtTipoMovimiento.Clear()
        txtIDCuentaBancaria.Clear()
        txtCuentaBancaria.Clear()
        chkNulos.Checked = False
        lblNulo.Text = 0
        txtIDCuentaBancaria.Focus()
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
            Adaptador.Fill(Ds, "Movimiento")
            DgvCheques.DataSource = Ds
            DgvCheques.DataMember = "Movimiento"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvCheques.ClearSelection()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            Con.Close()
        End Try
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvCheques.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvCheques
            .Columns(0).Visible = False

            .Columns(1).HeaderText = "No. Registro"
            .Columns(1).Width = 100

            .Columns(2).Width = 80
            .Columns(2).HeaderText = "Fecha"

            .Columns(3).HeaderText = "CK / Trans."
            .Columns(3).Width = 90

            .Columns(4).Width = 60
            .Columns(4).HeaderText = "ID"

            .Columns(5).HeaderText = "No. de cuenta"
            .Columns(5).Width = 120

            .Columns(6).HeaderText = "Concepto"
            .Columns(6).Width = 180

            .Columns(7).Width = 125
            .Columns(7).HeaderText = "Neto"
            .Columns(7).DefaultCellStyle.Format = ("C")

            .Columns(8).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim Counter As Integer = DgvCheques.Rows.Count
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = Counter Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvCheques.Rows(x).Cells(7).Value)

        x = x + 1
        GoTo Inicio
Fin:
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
        lblCantidad.Text = "Registros Encontrados: " & Counter
    End Sub

    Private Sub SelectCuentaBancaria()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT NoCuenta FROM CuentasBancarias Where IDCuenta='" + txtIDCuentaBancaria.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "CuentasBancarias")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")
            txtCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))

        Catch ex As Exception
            txtIDCuentaBancaria.Clear()
            txtCuentaBancaria.Clear()
        End Try
    End Sub

    Private Sub SelectTipoMovimiento()
        Try

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT TipoMovimiento FROM tipomovbancario where IDTipoMovBancario='" + txtIDTipoMovimiento.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "tipomovbancario")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("tipomovbancario")
            txtTipoMovimiento.Text = (Tabla.Rows(0).Item("TipoMovimiento"))

        Catch ex As Exception
            txtIDTipoMovimiento.Clear()
            txtTipoMovimiento.Clear()
        End Try
    End Sub


    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
        VerificarCondicionNulo()
    End Sub

    Private Sub txtIDCuentaBancaria_Leave(sender As Object, e As EventArgs) Handles txtIDCuentaBancaria.Leave
        SelectCuentaBancaria()
        VerificarCondicionCuentaBancaria()
    End Sub

    Private Sub VerificarCondicionTipoTransaccion()
        If rdbTodos.Checked = True Then
            TipoValorValue = 0
            IDCuentaBancariaValue = ""
        Else
            IDCuentaBancariaValue = " movimientosbanco.IDCuentaBancaria=" & txtIDCuentaBancaria.Text & " "
        End If
        ConstructorSQL()
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

    Private Sub txtIDTipoMovimiento_Leave(sender As Object, e As EventArgs) Handles txtIDTipoMovimiento.Leave
        SelectTipoMovimiento()
        VerificarCondicionTipoMovimiento()
    End Sub

    Sub VerificarCondicionTipoValor()
        If rdbTodos.Checked = True Then
            TipoValorValue = ""
        ElseIf rdbdebitos.Checked = True Then
            TipoValorValue = " tipomovbancario.IDTipoFuncion=2"
        ElseIf rdbCreditos.Checked = True Then
            TipoValorValue = " tipomovbancario.IDTipoFuncion=1"
        End If

        ConstructorSQL()
    End Sub
    Sub VerificarCondicionCuentaBancaria()
        If txtIDCuentaBancaria.Text = "" Then
            IDCuentaBancariaValue = ""
        Else
            IDCuentaBancariaValue = " movimientosbanco.IDCuentaBancaria=" & txtIDCuentaBancaria.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionTipoMovimiento()
        If txtIDCuentaBancaria.Text = "" Then
            IDTipoMovimientoValue = ""
        Else
            IDTipoMovimientoValue = " movimientosbanco.IDTipoMovimientoBanc=" & txtIDTipoMovimiento.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " movimientosbanco.FechaMovimiento BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " movimientosbanco.Nulo=0 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionCuentaBancaria()
        VerificarCondicionTipoMovimiento()
        VerificarCondicionFecha()
        VerificarCondicionTipoValor()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDCuentaBancariaValue <> "" Or IDTipoMovimientoValue <> "" Or TipoValorValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDCuentaBancariaValue & IDTipoMovimientoValue & TipoValorValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDCuentaBancariaValue <> "" And IDTipoMovimientoValue & TipoValorValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDTipoMovimientoValue <> "" And TipoValorValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If TipoValorValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If


        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDCuentaBancariaValue & A2 & IDTipoMovimientoValue & A3 & TipoValorValue & A4 & NuloValue
    End Sub

    Private Sub btnBuscarTipoMovimiento_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoMovimiento.Click
        frm_buscar_tipo_movimiento_bancario.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarCuentaBancaria_Click(sender As Object, e As EventArgs) Handles btnBuscarCuentaBancaria.Click
        frm_buscar_tipo_movimiento_bancario.ShowDialog(Me)
    End Sub


    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
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


            If DgvCheques.Rows.Count = 0 Then
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

                '@IDCuentaBancaria
                If txtIDCuentaBancaria.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDCuentaBancaria.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCuentaBancaria")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDTipoMovimiento
                If txtIDTipoMovimiento.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDTipoMovimiento.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDTipoMovimiento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Sucursal
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDAlmacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDTipoFuncion
                If rdbTodos.Checked = True Then
                    crParameterDiscreteValue.Value = 0
                ElseIf rdbdebitos.Checked = True Then
                    crParameterDiscreteValue.Value = 1
                ElseIf rdbCreditos.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDTipoFuncion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NCF
                crParameterDiscreteValue.Value = 0

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NCF")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NCFComo
                crParameterDiscreteValue.Value = ""
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NCFComo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                If chkNulos.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                ElseIf chkNulos.Checked = False Then
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



                '' ''Setting Info
                '' ''Resumir Reporte
                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                '' ''Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "No. Movimiento")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Movimiento")
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
                If DgvCheques.SelectedRows.Count > 0 Then
                    Dim IDMovimiento As New Label
                    IDMovimiento.Text = DgvCheques.SelectedRows(0).Cells(0).Value

                    If DgvCheques.SelectedRows(0).Cells(8).Value = 1 Then
                        MessageBox.Show("El documento de registro de movimiento bancario No. " & DgvCheques.SelectedRows(0).Cells(1).Value & " de fecha " & DgvCheques.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar la factura.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDMovimiento.Text
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

    Private Sub rdbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTodos.CheckedChanged
        VerificarCondicionTipoValor()
    End Sub

    Private Sub rdbdebitos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbdebitos.CheckedChanged
        VerificarCondicionTipoValor()
    End Sub

    Private Sub rdbCreditos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCreditos.CheckedChanged
        VerificarCondicionTipoValor()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim DsTemp As New DataSet
            If DgvCheques.SelectedRows.Count > 0 Then
                Dim IDCheque As New Label
                IDCheque.Text = DgvCheques.SelectedRows(0).Cells(0).Value

                DsTemp.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDMovimiento,MovimientosBanco.SecondID,MovimientosBanco.Fecha,MovimientosBanco.Hora,MovimientosBanco.IDCuentaBancaria,CuentasBancarias.NoCuenta,Bancos.Identidad,cuentasbancarias.Titular,CuentasBancarias.Balance,MovimientosBanco.IDTipoMovimientoBanc,TipoMovBancario.TipoMovimiento,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,CuentasBancarias.Balance,MontoLetras,NCF,Concepto,RutaDocumento,MovimientosBanco.Nulo FROM movimientosbanco INNER JOIN TipoMovBancario ON MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN CuentasBancarias on MovimientosBanco.IDCuentaBancaria=CuentasBancarias.IDCuenta INNER JOIN Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco Where IDMovimiento= '" + IDCheque.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Cheque")
                Con.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Cheque")

                If frm_movimientos_bancarios.Visible = True Then
                    frm_movimientos_bancarios.Close()
                End If

                frm_movimientos_bancarios.Show(Me)
                frm_movimientos_bancarios.Hora.Enabled = False
                frm_movimientos_bancarios.txtIDMovimientoBanc.Text = (Tabla.Rows(0).Item("IDMovimiento"))
                frm_movimientos_bancarios.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_movimientos_bancarios.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_movimientos_bancarios.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_movimientos_bancarios.cbxTipoMovimiento.Text = (Tabla.Rows(0).Item("TipoMovimiento"))
                frm_movimientos_bancarios.lblIDTipoMovimiento.Text = (Tabla.Rows(0).Item("IDTipoMovimientoBanc"))
                frm_movimientos_bancarios.SetIDTipoMovimiento()
                frm_movimientos_bancarios.cbxCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))
                frm_movimientos_bancarios.SetIDCuentaBanc()
                frm_movimientos_bancarios.dtpFecha.Value = CDate(Tabla.Rows(0).Item("FechaMovimiento")).ToString("dd/MM/yyyy")
                frm_movimientos_bancarios.dtpFecha.Text = CDate(Tabla.Rows(0).Item("FechaMovimiento")).ToString("dd/MM/yyyy")
                frm_movimientos_bancarios.txtReferencia.Text = (Tabla.Rows(0).Item("NoTransaccion"))
                frm_movimientos_bancarios.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_movimientos_bancarios.txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
                frm_movimientos_bancarios.txtCapital.Text = CDbl(Tabla.Rows(0).Item("Capital")).ToString("C")
                frm_movimientos_bancarios.txtInteres.Text = CDbl(Tabla.Rows(0).Item("Interes")).ToString("C")
                frm_movimientos_bancarios.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_movimientos_bancarios.lblRutaDocumento.Text = (Tabla.Rows(0).Item("RutaDocumento"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_movimientos_bancarios.chkNulo.Checked = False
                    frm_movimientos_bancarios.lblchkNulo.Text = 0
                Else
                    frm_movimientos_bancarios.chkNulo.Checked = True
                    frm_movimientos_bancarios.lblchkNulo.Text = 1
                End If

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class
