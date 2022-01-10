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
Public Class frm_consulta_financiamientos
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim SelectCommand As String = "SELECT idFinanciamientos,Financiamientos.SecondID,Fecha,Financiamientos.IDCliente,Clientes.Nombre,Financiamientos.Descripcion,TipoFinanciamiento.Descripcion as TipoFinanciamiento,MontoPrestamo,Financiamientos.Nulo FROM" & SysName.Text & "financiamientos INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TipoFinanciamiento on Financiamientos.IDTipoFinanciamiento=TipoFinanciamiento.IDTipoFinanciamiento"
    Dim FullCommand, FechaValue, IDClienteValue, IDVendedorValue, NuloValue, MetodoValue As String
    Dim A1, A2, A3, A4 As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim lblNulo, IDReport, NameReport, PathReport As New Label
    Dim Permisos As New ArrayList
    Private Sub frm_consulta_financiamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT idFinanciamientos,Financiamientos.SecondID,Fecha,Financiamientos.IDCliente,Clientes.Nombre,Financiamientos.Descripcion,TipoFinanciamiento.Descripcion as TipoFinanciamiento,MontoPrestamo,Financiamientos.Nulo FROM" & SysName.Text & "financiamientos INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TipoFinanciamiento on Financiamientos.IDTipoFinanciamiento=TipoFinanciamiento.IDTipoFinanciamiento" & " WHERE Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Financiamientos.Nulo=0 ORDER BY idFinanciamientos DESC", ConMixta)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Financiamientos' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoFinanciamientos' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDVendedor.Clear()
        txtVendedor.Clear()
        txtFechaInicial.Value = Today
        txtFechaFinal.Value = Today
        txtIDCliente.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
        FillMetodosFinanciamientos
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
        cbxMetodo.Text = "Todos"
        cbxMetodo.Tag = 0
    End Sub

    Private Sub FillMetodosFinanciamientos()
        Ds1.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idTipoFinanciamiento,Descripcion FROM libregco.tipofinanciamiento order by Descripcion asc", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "tipofinanciamiento")
        cbxMetodo.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds1.Tables("tipofinanciamiento")
        For Each Fila As DataRow In Tabla.Rows
            cbxMetodo.Items.Add(Fila.Item("Descripcion"))
        Next

        cbxMetodo.Items.Add("Todos")

    End Sub

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tipofinanciamiento")
            DgvFinanciamientos.DataSource = Ds
            DgvFinanciamientos.DataMember = "tipofinanciamiento"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvFinanciamientos.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        Try
            Dim DatagridWith As Double = (DgvFinanciamientos.Width - DgvFinanciamientos.RowHeadersWidth) / 100
            With DgvFinanciamientos
                .Columns(0).Visible = False
                '.Columns(0).HeaderText = "Clave Primaria"
                '.Columns(0).Width = 100
                '.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(1).HeaderText = "Código"
                .Columns(1).Width = DatagridWith * 12

                .Columns(2).HeaderText = "Fecha"
                .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
                .Columns(2).Width = DatagridWith * 12

                .Columns(3).Visible = False

                .Columns(4).Width = DatagridWith * 28
                .Columns(4).HeaderText = "Nombre"

                .Columns(5).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns(5).Width = DatagridWith * 24
                .Columns(5).HeaderText = "Descripción"

                .Columns(6).Width = DatagridWith * 10
                .Columns(6).HeaderText = "Tipo Financ."

                .Columns(7).Width = DatagridWith * 14
                .Columns(7).HeaderText = "Monto"
                .Columns(7).DefaultCellStyle.Format = ("C")

                .Columns(8).Visible = False

            End With
        Catch ex As Exception

        End Try


    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvFinanciamientos.Rows.Count Then
            GoTo Fin
        End If

        Monto = Monto + CDbl(DgvFinanciamientos.Rows(x).Cells(7).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvFinanciamientos.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectCliente()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
            txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
            If txtCliente.Text = "" Then txtIDCliente.Clear()
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectCliente")
            txtCliente.Text = ""
        End Try
    End Sub

    Private Sub SelectVendedor()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDVendedor.Text + "'", ConLibregco)
            txtVendedor.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
            If txtVendedor.Text = "" Then txtIDVendedor.Clear()
        Catch ex As Exception
            txtVendedor.Text = ""
            'MessageBox.Show(ex.Message.ToString & " Desde SelectVendedor")
        End Try
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        SelectCliente()
        VerificarCondicionCliente()
    End Sub

    Private Sub txtIDVendedor_Leave(sender As Object, e As EventArgs) Handles txtIDVendedor.Leave
        SelectVendedor()
        VerificarCondicionVendedor()
    End Sub

    Private Sub btnBuscarTipoMemo_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoMemo.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMetodo.SelectedIndexChanged
        If cbxMetodo.Text <> "Todos" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT idTipoFinanciamiento FROM tipofinanciamiento WHERE idTipoFinanciamiento= '" + cbxMetodo.SelectedItem + "'", ConLibregco)
            cbxMetodo.Tag = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        Else
            cbxMetodo.Tag = 0
        End If

        VerificarMetodoValue()
    End Sub

    Private Sub txtIDVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtIDVendedor.TextChanged
        VerificarCondicionVendedor()
    End Sub

    Private Sub VerificarCondicionVendedor()
        If txtIDVendedor.Text = "" Then
            IDVendedorValue = ""
        Else
            IDVendedorValue = " Financiamientos.IDVendedor=" & txtIDVendedor.Text & " "
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
            FechaValue = " Financiamientos.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarMetodoValue()
        If cbxMetodo.Text = "Todos" Then
            MetodoValue = ""
        Else
            MetodoValue = " Financiamientos.IDTipoFinanciamiento=" & cbxMetodo.Tag.ToString & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " Financiamientos.Nulo=0 "
        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionVendedor()
        VerificarCondicionCliente()
        VerificarCondicionFecha()
        VerificarMetodoValue()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDVendedorValue <> "" Or MetodoValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDVendedorValue & MetodoValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDVendedorValue & MetodoValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDVendedorValue <> "" And MetodoValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If MetodoValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDVendedorValue & A3 & MetodoValue & A4 & NuloValue

    End Sub


    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvFinanciamientos.Rows
                If CInt(Row.Cells(8).Value) = 1 Then
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


    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
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
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument


            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))

            If DgvFinanciamientos.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

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

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                '@IDVendedor
                If txtIDVendedor.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDVendedor.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDVendedor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                '@IDTipoFinanciamiento
                If cbxMetodo.Text = "Todos" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = cbxMetodo.Tag.ToString
                End If
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

                '@IDNCF
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDNCF")
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

                '@IDCobrador
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCobrador")
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

                'Balance
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Balance")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@FechaVencimiento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@FechaVencimiento")
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
            ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Financiamiento")
            'RangoFechas()
            ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ElseIf rdbEspecifico.Checked = True Then
                If DgvFinanciamientos.SelectedRows.Count > 0 Then
                Dim IDFinanciamiento As New Label
                IDFinanciamiento.Text = DgvFinanciamientos.SelectedRows(0).Cells(0).Value

                If DgvFinanciamientos.SelectedRows(0).Cells(8).Value = 1 Then
                    MessageBox.Show("El documento de financiamiento" & DgvFinanciamientos.SelectedRows(0).Cells(1).Value & " de fecha " & DgvFinanciamientos.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                crParameterDiscreteValue.Value = IDFinanciamiento.Text
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
            ObjRpt.Dispose()

        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
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

            If DgvFinanciamientos.SelectedRows.Count > 0 Then
                frm_superclave.IDAccion.Text = 126
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                Dim IDFinanciamiento As New Label
                IDFinanciamiento.Text = DgvFinanciamientos.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT idfinanciamientos,financiamientos.idtipodocumento,tipodocumento.documento,financiamientos.SecondID,financiamientos.Fecha,financiamientos.IDAreaImpresion,AreaImpresion.ComputerName,financiamientos.IDUsuario,Usuarios.Nombre as NombreUsuario,financiamientos.IDVendedor,Vendedor.Nombre as NombreVendedor,financiamientos.IDCliente,Clientes.Nombre,Clientes.Direccion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.Identificacion,financiamientos.Descripcion,financiamientos.IDTipoFinanciamiento,TipoFinanciamiento.Descripcion as TipoFinanciamiento,financiamientos.IDFormaPago,PeriodoPago.Descripcion as PeriodoPago,FechaInicio,FechaFinal,CantidadCuotas,InteresMensual,EvitSabado,EvitDomingo,PoseeGarantias,Valor,Financiamientos.Inicial,Financiamiento,Tramites,MontoPrestamo,TotalAPagar,MesesAplicables,Financiamientos.MontoPagos,Subtotal,ItbisPorcentaje,Itbis,TotalNeto,Clientes.BalanceGeneral,Calificacion.Calificacion,Transaccion.IDTransaccion,RedondearCuotas,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Financiamientos.IDTipoNCF,ComprobanteFiscal.TipoComprobante,financiamientos.Nulo,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto FROM" & SysName.Text & "financiamientos INNER JOIN" & SysName.Text & "TipoDocumento on Financiamientos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Transaccion on Financiamientos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Financiamientos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuarios on Financiamientos.IDUsuario=Usuarios.IDEmpleado INNER JOIN Libregco.TipoFinanciamiento on Financiamientos.IDTipoFinanciamiento=TipoFinanciamiento.idTipoFinanciamiento INNER JOIN Libregco.PeriodoPago on Financiamientos.IDFormaPago=PeriodoPago.IDPeriodoPago INNER JOIN" & SysName.Text & "AreaImpresion on Financiamientos.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Financiamientos.IDTipoNCF=ComprobanteFiscal.IDComprobanteFiscal Where Financiamientos.IDFinanciamientos= '" + IDFinanciamiento.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "financiamientos")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds1.Tables("financiamientos")

                If frm_financiamiento.Visible = True Then
                    frm_financiamiento.Close()
                End If

                frm_financiamiento.show(Me)
                frm_financiamiento.IsSaved = True
                frm_financiamiento.Hora.Enabled = False
                frm_financiamiento.lblIDTransaccion.Text = Tabla.Rows(0).Item("IDTransaccion")
                frm_financiamiento.txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
                frm_financiamiento.txtNombre.Text = Tabla.Rows(0).Item("Nombre")
                frm_financiamiento.txtDireccion.Text = Tabla.Rows(0).Item("Direccion")
                frm_financiamiento.txtTelefonos.Text = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
                frm_financiamiento.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_financiamiento.txtUltimoPago.Text = Tabla.Rows(0).Item("UltimoPago")
                frm_financiamiento.txtCalificacion.Text = Tabla.Rows(0).Item("Calificacion")

                frm_financiamiento.txtIDFinanciamiento.Text = Tabla.Rows(0).Item("IDFinanciamientos")
                frm_financiamiento.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                frm_financiamiento.txtFecha.Value = CDate(Tabla.Rows(0).Item("Fecha"))
                frm_financiamiento.txtHora.Text = Convert.ToString(CDate(Tabla.Rows(0).Item("Fecha")).ToString("hh:mm:ss"))
                frm_financiamiento.txtDescripcion.Text = Tabla.Rows(0).Item("Descripcion")
                frm_financiamiento.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Valor")).ToString("C")
                frm_financiamiento.txtInicial.Text = CDbl(Tabla.Rows(0).Item("Inicial")).ToString("C")
                frm_financiamiento.txtGranTotal.Text = CDbl(Tabla.Rows(0).Item("Financiamiento")).ToString("C")
                frm_financiamiento.txtCostoTramite.Text = CDbl(Tabla.Rows(0).Item("Tramites")).ToString("C")
                frm_financiamiento.txtMontoPrestamo.Text = CDbl(Tabla.Rows(0).Item("MontoPrestamo")).ToString("C")
                frm_financiamiento.txtMeses.Text = Tabla.Rows(0).Item("MesesAplicables")
                frm_financiamiento.txtMontoPagos.Text = CDbl(Tabla.Rows(0).Item("MontoPagos")).ToString("C")
                frm_financiamiento.txtTotalAPagar.Text = CDbl(Tabla.Rows(0).Item("TotalAPagar")).ToString("C")
                frm_financiamiento.cbxMetodo.Text = Tabla.Rows(0).Item("TipoFinanciamiento")
                frm_financiamiento.cbxMetodo.Tag = Tabla.Rows(0).Item("IDTipoFinanciamiento")
                frm_financiamiento.cbxFormaPago.Text = Tabla.Rows(0).Item("PeriodoPago")
                frm_financiamiento.cbxFormaPago.Tag = Tabla.Rows(0).Item("IDFormaPago")
                frm_financiamiento.txtPorcInteres.Text = CDbl(Tabla.Rows(0).Item("InteresMensual")).ToString("P")
                frm_financiamiento.dtpFechaInicio.Value = Tabla.Rows(0).Item("FechaInicio")
                frm_financiamiento.txtCantidadCuotas.Text = Tabla.Rows(0).Item("CantidadCuotas")
                frm_financiamiento.dtpFechaFinal.Value = Tabla.Rows(0).Item("FechaFinal")
                frm_financiamiento.ChkEvitSaturday.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("EvitSabado"))
                frm_financiamiento.ChkEvitSunday.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("EvitDomingo"))
                frm_financiamiento.chkRedondearCuotas.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("RedondearCuotas"))
                frm_financiamiento.chkPoseeGarantia.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("PoseeGarantias"))
                frm_financiamiento.CbxTipoComprobante.Text = Tabla.Rows(0).Item("TipoComprobante")
                frm_financiamiento.CbxTipoComprobante.Tag = Tabla.Rows(0).Item("IDTipoNCF")
                frm_financiamiento.cbxVendedor.Text = Tabla.Rows(0).Item("NombreVendedor")
                frm_financiamiento.cbxVendedor.Tag = Tabla.Rows(0).Item("IDVendedor")
                frm_financiamiento.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("Subtotal")).ToString("C")
                frm_financiamiento.txtITBIS.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
                frm_financiamiento.txtTasaItbis.Text = CDbl(Tabla.Rows(0).Item("ItbisPorcentaje")).ToString("P")
                frm_financiamiento.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                frm_financiamiento.chkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                ConMixta.Open()
                frm_financiamiento.DgvCuotas.Rows.Clear()
                Dim Consulta As New MySqlCommand("SELECT IdFinanciamientos_cuotas,NoCuota,Monto,FechaVencimiento,Capital,Interes FROM" & SysName.Text & "Financiamientos_cuotas Where IDFinanciamiento='" + Tabla.Rows(0).Item("IDFinanciamientos").ToString + "' Order by NoCuota ASC", ConMixta)
                Dim LectorCuotas As MySqlDataReader = Consulta.ExecuteReader

                While LectorCuotas.Read
                    frm_financiamiento.DgvCuotas.Rows.Add(LectorCuotas.GetValue(0), LectorCuotas.GetValue(1), CDbl(LectorCuotas.GetValue(2)).ToString("C"), CDate(LectorCuotas.GetValue(3)).ToString("dd/MM/yyyy"), CDbl(LectorCuotas.GetValue(4)).ToString("C"), CDbl(LectorCuotas.GetValue(5)).ToString("C"))
                End While
                LectorCuotas.Close()
                ConMixta.Close()

                Dim BceAPagar As Double = frm_financiamiento.txtTotalAPagar.Text
                For Each rw As DataGridViewRow In frm_financiamiento.DgvCuotas.Rows
                    rw.Cells(6).Value = BceAPagar.ToString("C")

                    BceAPagar = BceAPagar - CDbl(frm_financiamiento.txtMontoPagos.Text)
                Next

                frm_financiamiento.IsSaved = False

                frm_financiamiento.txtTiempoPeriodos.Text = CalcularFecha(Tabla.Rows(0).Item("FechaInicio"), Tabla.Rows(0).Item("FechaFinal"))
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_consulta_financiamientos_ventas_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDgv()
    End Sub
End Class