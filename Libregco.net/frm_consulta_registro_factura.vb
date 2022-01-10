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
Public Class frm_consulta_registro_factura

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDCondicion, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDFacturaDatos,FacturaDatos.SecondID,Fecha,FacturaDatos.IDCondicion,Condicion,IDVendedor,facturadatos.IDCliente,NombreFactura,TotalNeto,FacturaDatos.Nulo FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.condicion ON FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Clientes ON FacturaDatos.IDCliente=Clientes.IDCliente"
    Dim FullCommand, FechaValue, IDClienteValue, IDVendedorValue, NuloValue, CondicionValue As String
    Dim A1, A2, A3, A4, A5 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_registro_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("Select IDFacturaDatos,FacturaDatos.SecondID,Fecha,FacturaDatos.IDCondicion,Condicion,IDVendedor,Facturadatos.IDCliente,NombreFactura,TotalNeto,FacturaDatos.Nulo From" & SysName.Text & "facturadatos INNER JOIN Libregco.condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente WHERE Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and IDTipoDocumento=12 and FacturaDatos.Nulo=0 ORDER BY IDFacturaDatos DESC", ConMixta)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
        CheckForms()
    End Sub

    Private Sub CheckForms()
        If Me.Owner.Name = frm_registro_recibos_cobro_secuencial.Name Then
            btnBuscarCliente.PerformClick()
        End If

    End Sub
    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Registros Facturas' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Registros de facturas' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        FillCondicion()
        lblIDCondicion.Text = 0
        cbxCondicion.Text = "Todas"
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
    End Sub

    Private Sub FillCondicion()
        Ds1.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Condicion FROM Condicion ORDER BY Condicion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Condicion")
        cbxCondicion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds1.Tables("Condicion")

        For Each Fila As DataRow In Tabla.Rows
            cbxCondicion.Items.Add(Fila.Item("Condicion"))
        Next

        cbxCondicion.Items.Add("Todas")

    End Sub

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            Con.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FacturaDatos")
            DgvVentas.DataSource = Ds
            DgvVentas.DataMember = "FacturaDatos"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvVentas.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        Try
            Dim DatagridWith As Double = (DgvVentas.Width - DgvVentas.RowHeadersWidth) / 100
            With DgvVentas
                .Columns(0).Visible = False
                '.Columns(0).HeaderText = "Clave Primaria"
                '.Columns(0).Width = 100
                '.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(1).HeaderText = "Código"
                .Columns(1).Width = DatagridWith * 14

                .Columns(2).HeaderText = "Fecha"
                .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
                .Columns(2).Width = DatagridWith * 12

                .Columns(3).Visible = False

                .Columns(4).Width = DatagridWith * 16
                .Columns(4).HeaderText = "Condición"

                .Columns(5).Width = DatagridWith * 6
                .Columns(5).HeaderText = "Vend"

                .Columns(6).Width = DatagridWith * 10
                .Columns(6).HeaderText = "Código"

                .Columns(7).Width = DatagridWith * 28
                .Columns(7).HeaderText = "Cliente"

                .Columns(8).Width = DatagridWith * 14
                .Columns(8).HeaderText = "Monto"
                .Columns(8).DefaultCellStyle.Format = ("C")

                .Columns(9).Visible = False
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvVentas.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvVentas.Rows(x).Cells(8).Value)
        x = x + 1
        GoTo Inicio
Fin:
        'lblCantidad.Text = "Registros Encontrados: " & DgvVentas.Rows.Count
        'lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
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
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDVendedor.Text + "'", Con)
            txtVendedor.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
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

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        If cbxCondicion.Text <> "Todas" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
            lblIDCondicion.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If

        VerificarCondicionValue()
    End Sub

    Private Sub txtIDVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtIDVendedor.TextChanged
        VerificarCondicionVendedor()
    End Sub

    Friend Sub VerificarCondicionVendedor()
        If txtIDVendedor.Text = "" Then
            IDVendedorValue = ""
        Else
            IDVendedorValue = " FacturaDatos.IDVendedor=" & txtIDVendedor.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Friend Sub VerificarCondicionCliente()
        If txtIDCliente.Text = "" Then
            IDClienteValue = ""
        Else
            IDClienteValue = " FacturaDatos.IDCliente=" & txtIDCliente.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionValue()
        If cbxCondicion.Text = "Todas" Then
            CondicionValue = " IDTipoDocumento=12"
        ElseIf lblIDCondicion.Text = 1 Then
            CondicionValue = lblIDCondicion.Text & " AND IDTipoDocumento=12 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 Then
            NuloValue = ""
        Else
            NuloValue = " FacturaDatos.Nulo=0 "
        End If
        ConstructorSQL()

    End Sub

    Private Sub SummaCond()
        VerificarCondicionVendedor()
        VerificarCondicionCliente()
        VerificarCondicionFecha()
        VerificarCondicionValue()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDVendedorValue <> "" Or CondicionValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDVendedorValue & CondicionValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDVendedorValue & CondicionValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDVendedorValue <> "" And CondicionValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If CondicionValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDVendedorValue & A3 & CondicionValue & A4 & NuloValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvVentas.Rows
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

    Private Sub btnBuscarTipoMemo_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoMemo.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
        VerificarCondicionVendedor()
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


            If DgvVentas.Rows.Count = 0 Then
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

                '@TipoDocumento
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoDocumento")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = 12
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@CodigoCliente
                If txtIDCliente.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDCliente.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CodigoCliente")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@DGrupoCXC
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Grupocxc")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoCliente
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoCliente")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Vendedor
                If txtIDVendedor.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDVendedor.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Vendedor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NombreUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NombreUsuario")
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

                '@TipoNCF
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNCF")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Sucursal
                crParameterDiscreteValue.Value = 0
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

                '@Condicion
                If cbxCondicion.Text = "Todas" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = lblIDCondicion.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@GenerarCargo
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@GenerarCargo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@CuentaIncobrable
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CuentaIncobrable")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                crParameterDiscreteValue.Value = 2
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
                ObjRpt.SetParameterValue("@SortedField", "No. Factura")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Factura")
                'RangoFechas()
                If txtFechaInicial.Value = txtFechaFinal.Value Then
                    ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaInicial.Value.ToString("dd/MM/yyyy"))
                Else
                    ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                End If

                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ''Almacenes
                ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvVentas.SelectedRows.Count > 0 Then
                    Dim IDFactura As New Label
                    IDFactura.Text = DgvVentas.SelectedRows(0).Cells(0).Value

                    If DgvVentas.SelectedRows(0).Cells(9).Value = 1 Then
                        MessageBox.Show("El documento de ventas " & DgvVentas.SelectedRows(0).Cells(1).Value & " de fecha " & DgvVentas.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar la factura.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDFactura.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                Else
                    MessageBox.Show("No hay una fila seleccionada.")
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

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If DgvVentas.SelectedRows.Count > 0 Then
                Dim IDFactura As New Label
                IDFactura.Text = DgvVentas.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.IDCliente,Clientes.Nombre,IDFacturaDatos,FacturaDatos.SecondID,IDTipoDocumento,IDTransaccion,Fecha,Hora,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,FacturaDatos.Balance,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Observacion,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=FacturaDatos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.BalanceGeneral,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDVehiculo,Vehiculo.DatoVehiculo,FacturaDatos.IDVendedor,Vendedor.Nombre as Vendedor,FacturaDatos.IDChofer,Chofer.Nombre as Chofer,FacturaDatos.IDAlmacen,Almacen.Almacen,HabilitarFicha,NotaContado,FacturaDatos.Nulo from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Vehiculo on FacturaDatos.IDVehiculo=Vehiculo.IDVehiculo INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Chofer on FacturaDatos.IDChofer=Chofer.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where IDFacturaDatos='" + IDFactura.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "FacturaDatos")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds1.Tables("FacturaDatos")

                If frm_registro_factura_sd.Visible = True Then
                    frm_registro_factura_sd.Close()
                End If

                frm_registro_factura_sd.Show(Me)
                frm_superclave.IDAccion.Text = 30
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    frm_registro_factura_sd.Close()
                    Exit Sub
                End If

                frm_registro_factura_sd.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_registro_factura_sd.txtIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
                frm_registro_factura_sd.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_registro_factura_sd.lblIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                frm_registro_factura_sd.lblIDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                frm_registro_factura_sd.txtFechaFactura.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_registro_factura_sd.txtHoraFactura.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_registro_factura_sd.txtInicial.Text = (Tabla.Rows(0).Item("Inicial"))
                frm_registro_factura_sd.txtCantidadPagos.Text = (Tabla.Rows(0).Item("CantidadPagos"))
                frm_registro_factura_sd.txtMontoPagos.Text = (Tabla.Rows(0).Item("MontoPagos"))
                frm_registro_factura_sd.txtAdicional.Text = (Tabla.Rows(0).Item("PagoAdicional"))
                frm_registro_factura_sd.txtFechaAdicional.Text = (Tabla.Rows(0).Item("FechaAdicional"))
                frm_registro_factura_sd.txtBalance.Text = (Tabla.Rows(0).Item("Balance"))
                frm_registro_factura_sd.txtFechaVencimiento.Text = CDate(Tabla.Rows(0).Item("FechaVencimiento")).ToString("yyyy-MM-dd")
                frm_registro_factura_sd.txtCondicionContado.Text = (Tabla.Rows(0).Item("CondicionContado"))
                frm_registro_factura_sd.txtSubTotal.Text = (Tabla.Rows(0).Item("SubTotal"))
                frm_registro_factura_sd.TxtDescuentoSuma.Text = (Tabla.Rows(0).Item("Descuento"))
                frm_registro_factura_sd.txtITBIS.Text = (Tabla.Rows(0).Item("Itbis"))
                frm_registro_factura_sd.txtFlete.Text = (Tabla.Rows(0).Item("Flete"))
                frm_registro_factura_sd.txtNeto.Text = (Tabla.Rows(0).Item("TotalNeto"))
                frm_registro_factura_sd.txtObservacion.Text = (Tabla.Rows(0).Item("Observacion"))
                frm_registro_factura_sd.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_registro_factura_sd.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
                frm_registro_factura_sd.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_registro_factura_sd.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                frm_registro_factura_sd.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_registro_factura_sd.txtCobrador.Text = (Tabla.Rows(0).Item("Cobrador"))
                frm_registro_factura_sd.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_registro_factura_sd.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDVendedor"))
                frm_registro_factura_sd.txtVendedor.Text = (Tabla.Rows(0).Item("Vendedor"))
                frm_registro_factura_sd.cbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

                If (Tabla.Rows(0).Item("HabilitarFicha")) = 0 Then
                    frm_registro_factura_sd.chkFichaDatos.Checked = False
                Else
                    frm_registro_factura_sd.chkFichaDatos.Checked = True
                End If
                If (Tabla.Rows(0).Item("NotaContado")) = 0 Then
                    frm_registro_factura_sd.chkHabilitarNota.Checked = False
                Else
                    frm_registro_factura_sd.chkHabilitarNota.Checked = True
                End If
                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_registro_factura_sd.ChkNulo.Checked = False
                Else
                    frm_registro_factura_sd.ChkNulo.Checked = True
                End If

                frm_registro_factura_sd.RefrescarTablaPagares()
                frm_registro_factura_sd.CalcNeto()
                frm_registro_factura_sd.ConvertCurrent()
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_consulta_registro_factura_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDgv()
    End Sub

    Private Sub DgvVentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvVentas.CellClick
        If e.RowIndex >= 0 Then
            If Me.Owner.Name = frm_pagares.Name Then
                Dim IDCondicion As New Label
                IDCondicion.Text = DgvVentas.CurrentRow.Cells(3).Value

                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Dias FROM Condicion Where IDCondicion='" + IDCondicion.Text + "'", ConLibregco)
                Dim Dias As String = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                If Dias > 0 Then
                    frm_pagares.lblIDFactura.Text = DgvVentas.CurrentRow.Cells(0).Value
                    frm_pagares.txtFactura.Text = DgvVentas.CurrentRow.Cells(1).Value
                Else
                    MessageBox.Show("La factura seleccionada no tiene pagarés procesados.", "No se encontraron pagarés", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            ElseIf Me.Owner.Name = frm_registro_recibos_cobro_secuencial.Name Then
                frm_registro_recibos_cobro_secuencial.txtFactura.Text = DgvVentas.CurrentRow.Cells(1).Value
            ElseIf Me.Owner.Name = frm_inicio.Name Then
                Exit Sub
            End If

            Close()
        Else

        End If
    End Sub
End Class