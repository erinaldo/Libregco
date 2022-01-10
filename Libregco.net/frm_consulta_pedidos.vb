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
Public Class frm_consulta_pedidos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDPedido,Pedidos.SecondID,Fecha,Pedidos.Referencia,Nombre,Total,Pedidos.Nulo,Cierre FROM" & SysName.Text & "pedidos INNER JOIN Libregco.Clientes on Pedidos.IDCliente=Clientes.IDCliente"
    Dim FullCommand, FechaValue, IDClienteValue, IDUsuarioValue, IDPedidoValue, CerrarValue, NuloValue As String
    Dim A1, A2, A3, A4, A5 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDPedido,Pedidos.SecondID,Fecha,Pedidos.Referencia,Nombre,Total,Pedidos.Nulo,Cierre FROM" & SysName.Text & "pedidos INNER JOIN Libregco.Clientes on Pedidos.IDCliente=Clientes.IDCliente WHERE Pedidos.Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Pedidos.Cierre=0 and Pedidos.Nulo=0 ORDER BY IDPedido DESC", Con)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtIDUsuario.Clear()
        txtUsuario.Clear()
        txtIDCliente.Focus()
        chkNulos.Checked = False
        chkCerrados.Checked = False
        txtIDPedido.Clear()
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Pedido' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Pedidos' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Pedidos")
            DgvPedidos.DataSource = Ds
            DgvPedidos.DataMember = "Pedidos"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            MarcarCerradas()
            DgvPedidos.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvPedidos
            .Columns(0).Visible = False

            .Columns(1).HeaderText = "No. Pedido"
            .Columns(1).Width = 110

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns(2).Width = 80

            .Columns(3).Width = 120

            .Columns(4).Width = 310
            .Columns(4).HeaderText = "Cliente"

            .Columns(5).Width = 140
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(5).HeaderText = "Total"

            .Columns(6).Visible = False

            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvPedidos.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvPedidos.Rows(x).Cells(5).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvPedidos.Rows.Count
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
            'MessageBox.Show(ex.Message.ToString & " Desde SelectSuplidor")
            txtCliente.Text = ""
        End Try
    End Sub

    Private Sub SelectUsuario()
        Try
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
            txtUsuario.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        Catch ex As Exception
            txtUsuario.Text = ""
            'MessageBox.Show(ex.Message.ToString & " Desde SelectVendedor")
        End Try
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        SelectCliente()
        VerificarCondicionCliente()
    End Sub

    Private Sub txtIDUsuario_Leave(sender As Object, e As EventArgs) Handles txtIDUsuario.Leave
        SelectUsuario()
        VerificarCondicionUsuario()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        VerificarCondicionNulo()
    End Sub

    Private Sub VerificarCondicionUsuario()
        If txtIDUsuario.Text = "" Then
            IDUsuarioValue = ""
        Else
            IDUsuarioValue = " Pedidos.IDUsuario=" & txtIDUsuario.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCliente()
        If txtIDCliente.Text = "" Then
            IDClienteValue = ""
        Else
            IDClienteValue = " Pedidos.IDCliente=" & txtIDCliente.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionIDPedido()
        If txtIDPedido.Text = "" Then
            IDPedidoValue = ""
        Else
            IDPedidoValue = " Pedidos.IDPedido=" & txtIDPedido.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCierre()
        If chkCerrados.Checked = False Then
            CerrarValue = " Pedidos.Cierre=0 "
        Else
            CerrarValue = " Pedidos.Cierre=1 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If chkNulos.Checked = True Then
            NuloValue = ""
        Else
            NuloValue = " Pedidos.Nulo=0 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " Pedidos.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionUsuario()
        VerificarCondicionCliente()
        VerificarCondicionFecha()
        VerificarCondicionIDPedido()
        VerificarCondicionCierre()
        VerificarCondicionNulo()
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
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDUsuarioValue <> "" Or IDPedidoValue <> "" Or CerrarValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDUsuarioValue & IDPedidoValue & CerrarValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDUsuarioValue & IDPedidoValue & CerrarValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDUsuarioValue <> "" And IDPedidoValue & CerrarValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If IDPedidoValue <> "" And CerrarValue & NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        If CerrarValue <> "" And NuloValue <> "" Then
            A5 = " AND"
        Else
            A5 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDUsuarioValue & A3 & IDPedidoValue & A4 & CerrarValue & A5 & NuloValue
    End Sub


    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvPedidos.Rows
                If CInt(Row.Cells(6).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MarcarCerradas()
        Try
            For Each Row As DataGridViewRow In DgvPedidos.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtIDPedido_Leave(sender As Object, e As EventArgs) Handles txtIDPedido.Leave
        VerificarCondicionIDPedido()
    End Sub

    Private Sub chkCerrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkCerrados.CheckedChanged
        VerificarCondicionCierre()
    End Sub

    Private Sub btnBuscarSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoMemo_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoMemo.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub txtIDCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIDCliente.TextChanged
        VerificarCondicionCliente()
    End Sub

    Private Sub txtIDUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtIDUsuario.TextChanged
        VerificarCondicionUsuario()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
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


            If DgvPedidos.Rows.Count = 0 Then
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

                '@Vendedor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Vendedor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Producto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Producto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Medida
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Medida")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Condicion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Cierre
                If chkCerrados.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                Else
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cierre")
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
                ObjRpt.SetParameterValue("@SortedField", "")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Factura")
                'RangoFechas()
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvPedidos.SelectedRows.Count > 0 Then
                    Dim IDPedido As New Label
                    IDPedido.Text = DgvPedidos.SelectedRows(0).Cells(0).Value

                    If DgvPedidos.SelectedRows(0).Cells(7).Value = 1 Then
                        MessageBox.Show("La nota de pedidos No. " & DgvPedidos.SelectedRows(0).Cells(1).Value & " de fecha " & DgvPedidos.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDPedido.Text
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

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvPedidos.SelectedRows.Count > 0 Then
                Dim IDPedido As New Label
                IDPedido.Text = DgvPedidos.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDPedido,Fecha,Hora,IDUsuario,Pedidos.SecondID,Pedidos.IDCliente,Clientes.Nombre as NombreCliente,BalanceGeneral,Pedidos.Referencia,Comentario,SubTotal,Descuento,Itbis,Total,Pedidos.IDCondicion,Condicion.Condicion,Pedidos.IDVendedor,Empleados.Nombre as NombreVendedor,Pedidos.Nulo,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Pedidos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible from" & SysName.Text & "Pedidos INNER JOIN Libregco.Clientes on Pedidos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCAlificacion INNER JOIN Libregco.Condicion on Pedidos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados on Pedidos.IDVendedor=Empleados.IDEmpleado Where IDPedido = '" + IDPedido.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Pedidos")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds1.Tables("Pedidos")

                frm_pedidos.Show(Me)
                frm_superclave.IDAccion.Text = 26
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    frm_pedidos.Close()
                    Exit Sub
                End If

                frm_pedidos.txtIDPedido.Text = (Tabla.Rows(0).Item("IDPedido"))
                frm_pedidos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_pedidos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_pedidos.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_pedidos.lblIDUsuario.Text = (Tabla.Rows(0).Item("IDUsuario"))
                frm_pedidos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_pedidos.txtNombre.Text = (Tabla.Rows(0).Item("NombreCliente"))
                frm_pedidos.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_pedidos.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_pedidos.lblIDCondicion.Text = (Tabla.Rows(0).Item("IDCondicion"))
                frm_pedidos.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_pedidos.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
                frm_pedidos.txtDescuento.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
                frm_pedidos.txtItbis.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
                frm_pedidos.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
                frm_pedidos.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDVendedor"))
                frm_pedidos.txtVendedor.Text = (Tabla.Rows(0).Item("NombreVendedor"))
                frm_pedidos.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
                frm_pedidos.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                frm_pedidos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_pedidos.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_pedidos.ChkNulo.Checked = False
                Else
                    frm_pedidos.ChkNulo.Checked = True
                End If


                frm_pedidos.RefrescarTablaArticulos()
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class