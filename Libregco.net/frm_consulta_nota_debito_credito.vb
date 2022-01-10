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
Public Class frm_consulta_nota_debito_credito

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDNotaDebCred,NotaDebitoCredito.SecondID,Fecha,NotaDebitoCredito.IDCliente,Nombre,Concepto,Neto,notadebitocredito.Nulo FROM notadebitocredito INNER JOIN Clientes on NotaDebitoCredito.IDCliente=Clientes.IDCliente INNER JOIN TipoNotaFactura on NotaDebitoCredito.IDTipoNota=TipoNotaFactura.IDTipoNotaFactura"
    Dim FullCommand, FechaValue, IDClienteValue, IDSucursalValue, IDTipoNotaValue, NuloValue As String
    Dim A1, A2, A3, A4 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_nota_debito_credito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDNotaDebCred,NotaDebitoCredito.SecondID,Fecha,NotaDebitoCredito.IDCliente,Nombre,Concepto,Neto,notadebitocredito.Nulo FROM notadebitocredito INNER JOIN Clientes on NotaDebitoCredito.IDCliente=Clientes.IDCliente INNER JOIN TipoNotaFactura on NotaDebitoCredito.IDTipoNota=TipoNotaFactura.IDTipoNotaFactura WHERE NotaDebitoCredito.Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and NotaDebitoCredito.Nulo=0 ORDER BY NotaDebitoCredito.IDNotaDebCred DESC", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='NotaDebitoCreditocxc' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Notas DebCredcxc' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDCliente.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
        CbxTipoNota.Text = "Todas"
    End Sub

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            Con.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Notas")
            DgvNotas.DataSource = Ds
            DgvNotas.DataMember = "Notas"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvNotas.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvNotas

            .Columns(0).Visible = False

            .Columns(1).HeaderText = "No. Nota"
            .Columns(1).Width = 100

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns(2).Width = 80

            .Columns(3).Width = 80
            .Columns(3).HeaderText = "ID"

            .Columns(4).Width = 220
            .Columns(4).HeaderText = "Cliente"

            .Columns(5).Width = 150
            .Columns(5).HeaderText = "Descripción"

            .Columns(6).Width = 110
            .Columns(6).HeaderText = "Monto"
            .Columns(6).DefaultCellStyle.Format = ("C")

            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvNotas.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvNotas.Rows(x).Cells(6).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvNotas.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectCliente()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
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
            IDSucursalValue = " NotaDebitoCredito.IDSucursal=" & txtIDSucursal.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionFecha()
        VerificarCondicionCliente()
        VerificarCondicionSucursal()
        VerificarCondicionNulo()
        VerificarCondicionTipoNota()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub VerificarCondicionTipoNota()
        If CbxTipoNota.Text = "Todas" Then
            IDTipoNotaValue = ""
        ElseIf CbxTipoNota.Text = "Notas de crédito" Then
            IDTipoNotaValue = " NotaDebitoCredito.IDTipoNota=2 "
        ElseIf CbxTipoNota.Text = "Notas de débito" Then
            IDTipoNotaValue = " NotaDebitoCredito.IDTipoNota=1 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCliente()
        If txtIDCliente.Text = "" Then
            IDClienteValue = ""
        Else
            IDClienteValue = " NotaDebitoCredito.IDCliente=" & txtIDCliente.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " NotaDebitoCredito.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " NotaDebitoCredito.Nulo=0 "
        End If

        ConstructorSQL()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDSucursalValue <> "" Or IDTipoNotaValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDSucursalValue & IDTipoNotaValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDSucursalValue & IDTipoNotaValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDSucursalValue <> "" And IDTipoNotaValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If IDTipoNotaValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDSucursalValue & A3 & IDTipoNotaValue & A4 & NuloValue

    End Sub


    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvNotas.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
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

                '@TipoNota
                If CbxTipoNota.Text = "Todas" Then
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNota")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                    crParameterDiscreteValue.Value = 1
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNota")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                    crParameterDiscreteValue.Value = 2
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                ElseIf CbxTipoNota.Text = "Notas de crédito" Then
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNota")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                    crParameterDiscreteValue.Value = 2
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                ElseIf CbxTipoNota.Text = "Notas de débito" Then
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNota")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                    crParameterDiscreteValue.Value = 1
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                End If

                '@Cliente
                If txtIDCliente.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDCliente.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cliente")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Vendedor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Vendedor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
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
                ElseIf chkNulos.Checked = False Then
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@DGrupoCXC
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Grupocxc")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoCredito
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoCredito")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Provincia
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Provincia")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Municipio
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Municipio")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoSalidaNota
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoSalidaNota")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@CtaIncobrable
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CtaIncobrable")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@GenerarCargos
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@GenerarCargos")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@GenerarNCF
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@GenerarNCF")
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
                ObjRpt.SetParameterValue("@SortedField", "No. Nota")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Nota")
                'RangoFechas()
                If txtFechaInicial.Value = txtFechaFinal.Value Then
                    ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                Else
                    ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                End If
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvNotas.SelectedRows.Count > 0 Then
                    Dim IDNota As New Label
                    IDNota.Text = DgvNotas.SelectedRows(0).Cells(0).Value
                    If DgvNotas.SelectedRows(0).Cells(7).Value = 1 Then
                        MessageBox.Show("El documento de nota " & DgvNotas.SelectedRows(0).Cells(1).Value & " de fecha " & DgvNotas.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDNota.Text
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
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

    Private Sub btnSucursal_Click(sender As Object, e As EventArgs) Handles btnSucursal.Click
        frm_buscar_sucursal.ShowDialog(Me)
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

    Private Sub CbxTipoNota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoNota.SelectedIndexChanged
        VerificarCondicionTipoNota()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvNotas.SelectedRows.Count > 0 Then
                Dim IDNota As New Label
                IDNota.Text = DgvNotas.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDNotaDebCred,NotaDebitoCredito.SecondID,Fecha,Hora,NotaDebitoCredito.IDCliente,Nombre,IDTipoNota,Descripcion,Concepto,GenerarNCF,NCF,SubTotal,Itbis,Neto,NotaDebitoCredito.Nulo,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from Abonos where IDCliente=NotaDebitoCredito.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.BalanceGeneral FROM notadebitocredito INNER JOIN Clientes on NotaDebitoCredito.IDCliente=Clientes.IDCliente INNER JOIN TipoNotaFactura on NotaDebitoCredito.IDTipoNota=TipoNotaFactura.IDTipoNotaFactura INNER JOIN Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion Where IDNotaDebCred= '" + IDNota.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Nota")
                Con.Close()

                Dim Tabla As DataTable = Ds1.Tables("Nota")

                If frm_notas_debito_credito.Visible = True Then
                    frm_notas_debito_credito.Close()
                End If

                frm_notas_debito_credito.Show(Me)
                frm_superclave.IDAccion.Text = 21
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    frm_notas_debito_credito.Close()
                    Exit Sub
                End If

                frm_notas_debito_credito.txtIDNota.Text = (Tabla.Rows(0).Item("IDNotaDebCred"))
                frm_notas_debito_credito.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_notas_debito_credito.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_notas_debito_credito.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_notas_debito_credito.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_notas_debito_credito.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_notas_debito_credito.TipoNota.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_notas_debito_credito.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_notas_debito_credito.lblNoNCF.Text = (Tabla.Rows(0).Item("NCF"))
                frm_buscar_nota_debitocredito.RefrescarTablaFact()
                frm_notas_debito_credito.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
                frm_notas_debito_credito.txtItbis.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
                frm_notas_debito_credito.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                frm_notas_debito_credito.ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))
                frm_notas_debito_credito.lblCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                frm_notas_debito_credito.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_notas_debito_credito.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")

                If (Tabla.Rows(0).Item("IDTipoNota")) = "2" Then
                    frm_notas_debito_credito.rdbNotaCredito.Checked = True
                ElseIf (Tabla.Rows(0).Item("IDTipoNota")) = "1" Then
                    frm_notas_debito_credito.rdbNotaDebito.Checked = True
                End If
                If (Tabla.Rows(0).Item("GenerarNCF")) = 1 Then
                    frm_notas_debito_credito.ChkGenerarNCF.Checked = True
                Else
                    frm_notas_debito_credito.ChkGenerarNCF.Checked = False
                End If
                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_notas_debito_credito.ChkNulo.Checked = False
                Else
                    frm_notas_debito_credito.ChkNulo.Checked = True
                End If
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

  
End Class