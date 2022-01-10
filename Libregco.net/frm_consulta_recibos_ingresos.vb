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
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils

Public Class frm_consulta_recibos_ingresos
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Friend IDReport, NameReport, PathReport As New Label

    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue

    Friend TablaIngresos As DataTable
    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryCurrency As New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()

    Dim SelectCommand As String = "SELECT IDAbono,Abonos.SecondID,TIMESTAMP(Abonos.Fecha,Abonos.Hora) as Fecha,Abonos.IDEquipo,AreaImpresion.ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,Abonos.IDEmpleado as IDUsuario,Empleados.Nombre as NombreUsuario,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,Abonos.IDCliente,Clientes.Nombre,Abonos.Concepto,Abonos.Total,Abonos.BalanceAnterior,Abonos.Nulo,Transaccion.IDMoneda,TipoMoneda.Texto FROM" & SysName.Text & "Abonos INNER JOIN Libregco.Clientes on Abonos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "AreaImpresion on Abonos.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Empleados on Abonos.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "Transaccion on Abonos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda"

    Private Sub frm_consulta_recibos_ingresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        SetIngresosTable()
        LimpiarDatos()
        Actualizar()
        RefrescarTabla()
        FillReportes()
        CheckNameOnCXC()
    End Sub

    Private Sub SetIngresosTable()
        RepositoryCurrency.SmallImages = imgFlags
        RepositoryCurrency.GlyphAlignment = HorzAlignment.Near
        RepositoryCurrency.Name = "RepCurrency"

        Dim dstemp As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM Libregco.tipomoneda order by IDTipoMoneda ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipomoneda")
        ConLibregco.Close()

        Dim Tabla As DataTable = dstemp.Tables("tipomoneda")

        For Each Fila As DataRow In Tabla.Rows
            Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
            'nvmoneda.Description = Fila.Item("Texto")
            nvmoneda.Value = Fila.Item("IDTipoMoneda")
            If Fila.Item("IDTipoMoneda") = 1 Then
                nvmoneda.ImageIndex = 0
            ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                nvmoneda.ImageIndex = 1
            ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                nvmoneda.ImageIndex = 2
            End If

            nvmoneda.Description = Fila.Item("Texto")

            RepositoryCurrency.Properties.Items.Add(nvmoneda)
        Next
        Tabla.Dispose()
        dstemp.Dispose()

        TablaIngresos = New DataTable("Ingresos")

        TablaIngresos.Columns.Add("ID", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Fecha", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("IDEquipo", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Equipo", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("IDAlmacen", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Almacen", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("IDSucursal", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Sucursal", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("IDUsuario", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Usuario", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("IDCobrador", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Cobrador", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("IDCliente", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Nombre", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Concepto", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Total", System.Type.GetType("System.Double"))
        TablaIngresos.Columns.Add("BalanceAnterior", System.Type.GetType("System.Double"))
        TablaIngresos.Columns.Add("Nulo", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("Moneda", System.Type.GetType("System.String"))
        TablaIngresos.Columns.Add("MonedaImagen", System.Type.GetType("System.Object"))

        GridControl1.DataSource = TablaIngresos
        GridView1.Columns("SecondID").ColumnEdit = RepositorySecondID
        GridView1.Columns("MonedaImagen").ColumnEdit = RepositoryCurrency
        'Propiedades
        GridView1.Columns("ID").Visible = False
        GridView1.Columns("ID").Caption = "ID del recibo"
        GridView1.Columns("SecondID").Caption = "Documento"
        GridView1.Columns("IDEquipo").Visible = False
        GridView1.Columns("IDEquipo").Caption = "Código del equipo"
        GridView1.Columns("Equipo").Visible = False
        GridView1.Columns("Equipo").Caption = "Equipo"
        GridView1.Columns("IDAlmacen").Visible = False
        GridView1.Columns("IDAlmacen").Caption = "Código del almacén"
        GridView1.Columns("Almacen").Visible = False
        GridView1.Columns("Almacen").Caption = "Almacén"
        GridView1.Columns("IDSucursal").Visible = False
        GridView1.Columns("IDSucursal").Caption = "Código de la sucursal"
        GridView1.Columns("Sucursal").Visible = False
        GridView1.Columns("Sucursal").Caption = "Sucursal"
        GridView1.Columns("IDUsuario").Visible = False
        GridView1.Columns("IDUsuario").Caption = "Código del usuario"
        GridView1.Columns("Usuario").Visible = False
        GridView1.Columns("Usuario").Caption = "Usuario"
        GridView1.Columns("IDCobrador").Visible = False
        GridView1.Columns("IDCobrador").Caption = "Código del cobrador"
        GridView1.Columns("Cobrador").Visible = False
        GridView1.Columns("Cobrador").Caption = "Cobrador"
        GridView1.Columns("IDCliente").Visible = True
        GridView1.Columns("IDCliente").Caption = "ID Cl."
        GridView1.Columns("Nombre").Visible = True
        GridView1.Columns("Nombre").Caption = "Nombre"
        GridView1.Columns("Concepto").Visible = False
        GridView1.Columns("Concepto").Caption = "Concepto"
        GridView1.Columns("Total").Visible = True
        GridView1.Columns("Total").Caption = "Total"
        GridView1.Columns("Total").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Total").DisplayFormat.FormatString = "C2"
        GridView1.Columns("BalanceAnterior").Visible = False
        GridView1.Columns("BalanceAnterior").Caption = "Bce. Ant."
        GridView1.Columns("BalanceAnterior").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("BalanceAnterior").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Nulo").Visible = False
        GridView1.Columns("Nulo").Caption = "Nulo"

        For i = 0 To GridView1.Columns.Count - 1
            GridView1.Columns(i).OptionsColumn.ReadOnly = True
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next

        GridView1.Columns("Moneda").GroupIndex = 0

        Dim item As New DevExpress.XtraGrid.GridGroupSummaryItem
        item.FieldName = "Total"
        item.ShowInGroupColumnFooter = GridView1.Columns("Total")
        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item.DisplayFormat = "{0:c2}"
        item.ShowInGroupColumnFooter = Nothing
        GridView1.GroupSummary.Add(item)

        GridView1.ExpandAllGroups()
    End Sub

    Private Sub CheckNameOnCXC()
        If Me.Owner.Name = frm_recibos_cobro_entrega_casa.Name Then
            txtIDCliente.Text = frm_recibos_cobro_entrega_casa.IDCli
            txtCliente.Text = frm_recibos_cobro_entrega_casa.Nomb
        End If
    End Sub

    Private Function ConstructorQuery() As String
        Dim Paremeter As Integer = 0
        Dim Str As String = ""
        Dim Orderby As String

        If IsDate(txtFechaInicial.Value) Or txtIDCliente.Text <> "" Or txtSucursal.Text <> "" Or chkNulos.CheckState = CheckState.Unchecked Then
            Str = Str & " WHERE "

            If IsDate(txtFechaInicial.Value) Then
                If Paremeter > 0 Then
                    Str = Str & " AND Abonos.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "' "
                    Paremeter += 1
                Else
                    Str = Str & " Abonos.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "' "
                    Paremeter += 1
                End If
            End If

            If txtIDCliente.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Abonos.IDCliente=" & txtIDCliente.Text & " "
                    Paremeter += 1
                Else
                    Str = Str & " Abonos.IDCliente=" & txtIDCliente.Text & " "
                    Paremeter += 1
                End If
            End If

            If txtIDSucursal.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Abonos.IDSucursal=" & txtIDSucursal.Text & " "
                    Paremeter += 1
                Else
                    Str = Str & " Abonos.IDSucursal=" & txtIDSucursal.Text & " "
                    Paremeter += 1
                End If
            End If

            If chkNulos.CheckState = CheckState.Unchecked Then
                If Paremeter > 0 Then
                    Str = Str & " AND Abonos.Nulo=0 "
                    Paremeter += 1
                Else
                    Str = Str & " Abonos.Nulo=0 "
                    Paremeter += 1
                End If
            End If
        End If

        If cbxOrden.Text = "Documento" Then
            Orderby = " ORDER BY Abonos.IDAbono " & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Fecha" Then
            Orderby = " ORDER BY TIMESTAMP(Abonos.Fecha,Abonos.Hora) " & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Cliente" Then
            Orderby = " ORDER BY Clientes.Nombre" & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Total" Then
            Orderby = " ORDER BY Abonos.Total " & CbxTipoOrden.Text
        End If

        Return Str & Orderby

    End Function

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Dim dstemp As New DataSet

            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ReciboAbono' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Cobros' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = dstemp.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
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
    End Sub

    Private Sub Actualizar()
        cbxOrden.SelectedIndex = 0
        CbxTipoOrden.SelectedIndex = 0
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim ConditionalQuery As String = ConstructorQuery()
            Dim ds As New DataSet

            TablaIngresos.Rows.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand(SelectCommand & ConditionalQuery, ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Ingresos")
            ConMixta.Close()

            Dim TB As DataTable = ds.Tables("Ingresos")

            For Each itm As DataRow In TB.Rows
                TablaIngresos.Rows.Add(itm.Item("IDAbono"), itm.Item("SecondID"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss tt"), itm.Item("IDEquipo"), itm.Item("ComputerName"), itm.Item("IDAlmacen"), itm.Item("Almacen"), itm.Item("IDSucursal"), itm.Item("Sucursal"), itm.Item("IDUsuario"), itm.Item("NombreUsuario"), itm.Item("IDCobrador"), itm.Item("NombreCobrador"), itm.Item("IDCliente"), itm.Item("Nombre"), itm.Item("Concepto"), itm.Item("Total"), itm.Item("BalanceAnterior"), itm.Item("Nulo"), itm.Item("Texto"), itm.Item("IDMoneda"))
            Next

            GridView1.BestFitColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub


    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Nulo"))
            If category = "1" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
                e.HighPriority = True
            End If
        End If
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

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave, txtIDCliente.Leave
        SelectCliente()
    End Sub

    Private Sub txtIDSucursal_Leave(sender As Object, e As EventArgs) Handles txtIDSucursal.Leave
        SelectSucursal()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & SelectCommand & ConstructorQuery()
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

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Dim dstemp As New DataSet

        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = dstemp.Tables("Reportes")
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
            Dim DsSP As New DataSet

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then
                frm_reportView.ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text)
            Else
                frm_reportView.ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            End If

            If GridView1.RowCount = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If GridView1.FocusedRowHandle >= 0 Then
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

                    '@IDGrupoCXC
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDGrupocxc")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@TipoCliente
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDTipoCliente")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@IDVendedor
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDVendedor")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@IDUsuario
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@IDProvincia
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDProvincia")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@IDMunicipio
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDMunicipio")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@IDTipoNCF
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDTipoNCF")
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

                    '@Condicion
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCondicion")
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

                    '@GeneracionCargos
                    crParameterDiscreteValue.Value = 2
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@GeneracionCargos")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@CuentaIncobrable
                    crParameterDiscreteValue.Value = 2
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CuentaIncobrable")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@SoloPagos
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Efectivo")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cheque")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Deposito")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Credito")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Tarjeta")
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
                    ObjRpt.SetParameterValue("@SortedField", "No. Recibo")
                    ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Recibo")
                    'RangoFechas()
                    If txtFechaInicial.Value = txtFechaFinal.Value Then
                        ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaInicial.Value.ToString("dd/MM/yyyy"))
                    Else
                        ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                    End If

                    'Usuario Info
                    ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")

                    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf rdbEspecifico.Checked = True Then
                    If GridView1.SelectedRowsCount > 0 Then
                        Dim IDRecibo As New Label
                        IDRecibo.Text = GridView1.GetFocusedRowCellValue("ID").ToString

                        If GridView1.GetFocusedRowCellValue("Nulo").ToString = 1 Then
                            MessageBox.Show("El documento de recibo de ingreso " & GridView1.GetFocusedRowCellValue("SecondID").ToString & " de fecha " & GridView1.GetFocusedRowCellValue("Fecha").ToString & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        Dim cmdSP As New MySqlCommand
                        Dim AdaptadorSP As MySqlDataAdapter

                        'Consulta de los datos del abono   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        AdaptadorSP = New MySqlDataAdapter("SELECT Abonos.IDAbono,Abonos.IDSucursal,Sucursal.Sucursal,Sucursal.Direccion as DireccionSucursal,Sucursal.Provincia,Sucursal.Municipio,Sucursal.Telefono,Sucursal.Telefono1,Sucursal.Telefono2,Sucursal.Fax,Sucursal.Email,Abonos.IDAlmacen,Almacen.Almacen,Abonos.SecondID as SecondIDAbono,Abonos.IDTipoDocumento,TipoDocumento.Documento,Abonos.IDCliente,Clientes.Nombre,Clientes.Direccion,Clientes.Identificacion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.BalanceGeneral,(SELECT Coalesce(Sum(Cargos),0) from Libregco.FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Abonos.IDTransaccion,Transaccion.IDMoneda,TipoMoneda.Texto,TipoMoneda.MonedaImagen,Transaccion.Efectivo,Transaccion.Cheque,Transaccion.Deposito,Transaccion.Informacion,IDCredito,Transaccion.Credito,ClaseTarjeta,Transaccion.Tarjeta,TipoTarjeta,NoAprobacion,Recibido,MontoCobrar,Devuelta,Abonos.IDEmpleado,Usuarios.Nombre as NombreUsuario,Usuarios.Login,Abonos.Fecha,Abonos.Hora,Abonos.BalanceAnterior as BalanceAnteriorGeneral,DetalleAbonos.CargosAnterior,Abonos.Concepto,Abonos.Debito,Abonos.Descuento,Abonos.Total as TotalAbono,SumaLetra,Abonos.Impreso,Abonos.Nulo,IDDetalleAbono,IDFactura,FacturaDatos.SecondID as SecondIDFactura,FacturaDatos.Fecha as FechaFactura,FacturaDatos.Hora as HoraFactura,FacturaDatos.Balance,DetalleAbonos.BalanceAnterior as BalanceAnteriorFactura,DetalleAbonos.DiasVencidos as DiasVencidosenPago,DetalleAbonos.Debito as DebitoDetalle,DetalleAbonos.Cargos as CargosDetalle,DetalleAbonos.CargosExcento,DetalleAbonos.Descuento as DescuentoDetalle,DetalleAbonos.Total as TotalDetalleAbono,FacturaDatos.IDVendedor,Vendedor.Nombre as NombreVendedor,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,(Select Value1Var from Configuracion Where IDConfiguracion=6) as EncabezadodeCobro,(Select Value1Var from Configuracion Where IDConfiguracion=7) as PiedeCobro FROM" & SysName.Text & "Abonos INNER JOIN" & SysName.Text & "Sucursal on Abonos.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on Abonos.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "TipoDocumento on Abonos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Transaccion on Abonos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Clientes on Abonos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Empleados as Usuarios on Abonos.IDEmpleado=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Detalleabonos on Abonos.IDAbono=DetalleAbonos.IDAbono INNER JOIN" & SysName.Text & "FacturaDatos on DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda Where Abonos.IDAbono='" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", Con)
                        AdaptadorSP.Fill(DsSP, "AbonosView")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        'Llenado EmpresaView
                        AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                        AdaptadorSP.Fill(DsSP, "EmpresaView")

                        'Lleando balances_clientes_view
                        AdaptadorSP = New MySqlDataAdapter("call libregco.balances_clientes(" + GridView1.GetFocusedRowCellValue("IDCliente").ToString + ");", Con)
                        AdaptadorSP.Fill(DsSP, "balances_clientes")

                        cmdSP.Dispose()
                        AdaptadorSP.Dispose()

                        frm_reportView.ObjRpt.Database.Tables("abonosview1").SetDataSource(DsSP.Tables("AbonosView"))
                        frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))
                        frm_reportView.ObjRpt.Subreports("balances_clientes_formato.rpt").SetDataSource(DsSP.Tables("balances_clientes"))


                        'crParameterDiscreteValue.Value = IDRecibo.Text
                        'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                        'crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                        'crParameterValues.Add(crParameterDiscreteValue)
                        'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    Else
                        MessageBox.Show("No hay una fila seleccionada.")
                        LoadAnimation()
                        Exit Sub
                    End If
                End If


                If rdbPresentacion.Checked = True Then
                    lblStatusBar.Text = "Visualizando el reporte..."

                    Dim TmpForm = New frm_reportView
                    TmpForm.Text = "Visualizacion de reportes /" & Me.Text & " / " & CbxFormato.Text
                    TmpForm.Show(Me)

                    TmpForm.CrystalViewer.ReportSource = Nothing
                    TmpForm.CrystalViewer.ReportSource = frm_reportView.ObjRpt
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

                        Dim PrinterSettings1 As New Printing.PrinterSettings
                        Dim PageSettings1 As New Printing.PageSettings

                        PrinterSettings1.PrinterName = PrintDialog.PrinterSettings.PrinterName
                        PrinterSettings1.Collate = PrintDialog.PrinterSettings.Collate
                        PrinterSettings1.Copies = PrintDialog.PrinterSettings.Copies
                        PrinterSettings1.FromPage = PrintDialog.PrinterSettings.FromPage
                        PrinterSettings1.ToPage = PrintDialog.PrinterSettings.ToPage
                        PageSettings1.PrinterResolution.Kind = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind

                        frm_reportView.ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                        frm_reportView.ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName

                        frm_reportView.ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)

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
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        Try

            If GridView1.FocusedRowHandle >= 0 Then

                If GridView1.FocusedColumn.FieldName = "SecondID" Then
                    btnModificar.PerformClick()
                    Exit Sub
                End If

                If Me.Owner.Name = frm_recibos_cobro_entrega_casa.Name Then
                    frm_recibos_cobro_entrega_casa.lblIDRecibo.Text = GridView1.GetFocusedRowCellValue("ID").ToString
                    frm_recibos_cobro_entrega_casa.txtNoRecibo.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString
                    Me.Close()

                ElseIf Me.Owner.Name = frm_registro_recibos_cobro.Name Then

                    If txtIDCliente.Text <> frm_registro_recibos_cobro.txtIDCliente.Text Then
                        MessageBox.Show("No es posible agregar recibos que no le correspondan al mismo cliente." & vbNewLine & vbNewLine & "Por favor revise los clientes seleccionados para continuar con el procedimiento.", "Se han seleccionado clientes diferentes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                        Exit Sub
                    End If

                    Dim DsTemp As New DataSet
                    DsTemp.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDAbono,SecondID,Fecha,Hora,Total,Concepto,SumaLetra FROM" & SysName.Text & "abonos where IDAbono='" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Abono")
                    ConMixta.Close()

                    Dim Tabla As DataTable = DsTemp.Tables("Abono")

                    For Each Rw As DataGridViewRow In frm_registro_recibos_cobro.DgvAuditoria.Rows
                        If Rw.Cells(1).Value = Tabla.Rows(0).Item(0) Then
                            MessageBox.Show("El recibo de ingreso " & Tabla.Rows(0).Item(1) & " ya se encuentra ingresado en la tabla del registro de recibos auditados.", "El registro ya se ha introducido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Next

                    Dim MontoRecibo, MontoUsado, MontoDisponible As Double

                    MontoRecibo = CDbl(GridView1.GetFocusedRowCellValue("Total").ToString)


                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT Coalesce(Sum(Monto),0) FROM" & SysName.Text & "RecibosCobroAuditoria Where IDAbono='" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConMixta)
                    MontoUsado = Convert.ToDouble(cmd.ExecuteScalar())
                    ConMixta.Close()

                    MontoDisponible = MontoRecibo - MontoUsado

                    If MontoDisponible > 0 Then
                        If MontoDisponible <= CDbl(frm_registro_recibos_cobro.txtMontoTotal.Text) Then
                            frm_registro_recibos_cobro.DgvAuditoria.Rows.Add("", Tabla.Rows(0).Item(0), Tabla.Rows(0).Item(1), Tabla.Rows(0).Item(2) & " " & CDate(Convert.ToString(Tabla.Rows(0).Item(3))).ToString("hh:mm:ss"), CDbl(MontoDisponible).ToString("C"), Tabla.Rows(0).Item(5))
                        Else
                            frm_registro_recibos_cobro.DgvAuditoria.Rows.Add("", Tabla.Rows(0).Item(0), Tabla.Rows(0).Item(1), Tabla.Rows(0).Item(2) & " " & CDate(Convert.ToString(Tabla.Rows(0).Item(3))).ToString("hh:mm:ss"), frm_registro_recibos_cobro.txtMontoTotal.Text, Tabla.Rows(0).Item(5))
                        End If
                    Else
                        MessageBox.Show("El recibo de ingreso no tiene montos disponibles para auditarlo.", "Recibo de ingreso ya utilizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If


                    Tabla.Dispose()
                    frm_registro_recibos_cobro.SumRCenAuditoria()
                    Me.Close()

                End If



            End If



        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        'Try
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If GridView1.SelectedRowsCount > 0 Then
            frm_superclave.IDAccion.Text = 29
            frm_superclave.ShowDialog(Me)
            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            Dim IDRecibo As New Label
            IDRecibo.Text = GridView1.GetFocusedRowCellValue("ID").ToString

            Dim Dstemp As New DataSet

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDAbono,Abonos.IDSucursal,Abonos.IDAlmacen,Abonos.SecondID,IDTipoDocumento,Abonos.IDCliente,Clientes.Nombre,Calificacion.Calificacion,Clientes.BalanceGeneral,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,IDTransaccion,Abonos.IDEmpleado as IDUsuario,Fecha,Hora,BalanceAnterior,Concepto,Debito,Descuento,Total,SumaLetra,Impreso,Abonos.Nulo,Clientes.Direccion,Municipios.Municipio,Provincias.Provincia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.LiberarControles,Clientes.Identificacion,Clientes.Alertas,Clientes.BloqueoCobrador FROM" & SysName.Text & "Abonos INNER JOIN Libregco.Clientes on Abonos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Provincias on Municipios.IDProvincia=Provincias.IDProvincia INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado Where IDAbono='" + IDRecibo.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Abonos")
            ConMixta.Close()

            Dim Tabla As DataTable = Dstemp.Tables("Abonos")

            If frm_recibo_pagos.Visible = True Then
                frm_recibo_pagos.Close()
            End If

            frm_recibo_pagos.Show(Me)
            frm_recibo_pagos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_recibo_pagos.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_recibo_pagos.GPCliente.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"
            frm_recibo_pagos.lblDireccion.Text = (Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia")) & "."
            frm_recibo_pagos.lblTelefono.Text = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
            frm_recibo_pagos.lblIdentificacion.Text = (Tabla.Rows(0).Item("Identificacion"))
            frm_recibo_pagos.lblCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_recibo_pagos.txtCobrador.Text = (Tabla.Rows(0).Item("NombreEmpleado"))
            frm_recibo_pagos.LiberarControles.Text = Tabla.Rows(0).Item("LiberarControles")

            If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                frm_recibo_pagos.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
            Else
                frm_recibo_pagos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            End If

            If IsNumeric(Tabla.Rows(0).Item("UltimoMontoPago")) Then
                frm_recibo_pagos.txtMontoUltimoPago.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
            Else
                frm_recibo_pagos.txtMontoUltimoPago.Text = Tabla.Rows(0).Item("UltimoMontoPago")
            End If

            frm_recibo_pagos.txtFechaPago.Value = CDate(Tabla.Rows(0).Item("Fecha"))
            frm_recibo_pagos.txtIDPago.Text = Tabla.Rows(0).Item("IDAbono")
            frm_recibo_pagos.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
            frm_recibo_pagos.lblTransaccion.Text = Tabla.Rows(0).Item("IDTransaccion")
            frm_recibo_pagos.txtMontoAplicar.EditValue = CDbl(Tabla.Rows(0).Item("Debito"))
            frm_recibo_pagos.txtConceptoPago.Text = Tabla.Rows(0).Item("Concepto")
            frm_recibo_pagos.lblDescuento.Text = Tabla.Rows(0).Item("Descuento")
            frm_recibo_pagos.lbltotalAbono.Text = Tabla.Rows(0).Item("Total")

            If TypeConnection.Text = 1 Then
                If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                    frm_recibo_pagos.PicImagen.Image = My.Resources.no_photo
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        frm_recibo_pagos.PicImagen.Image = Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If


            frm_recibo_pagos.RefrescarBalances()
            RefrescarTablaFacturas()
            frm_recibo_pagos.VerifyBalances()
            frm_recibo_pagos.BuscarNotasDescuentos()

            frm_recibo_pagos.txtMontoAplicar.Focus()

            If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                frm_recibo_pagos.DeshabilitarControles()
            End If

            If frm_recibo_pagos.DTFacturas.Rows.Count = 0 Then
                MessageBox.Show("El cliente: [" & frm_recibo_pagos.txtIDCliente.Text & "] " & frm_recibo_pagos.txtNombre.Text & ", no tiene facturas pendientes.", "No se encontraron facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            If CheckDoubleBilling(Tabla.Rows(0).Item("IDCliente")) = True Then
                frm_bloqueo_facturacion_simultanea.ShowDialog(Me)
            End If

            If CInt(Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_recibo_pagos.ChkNulo.Checked = True
            Else
                frm_recibo_pagos.ChkNulo.Checked = False
            End If
            'Liberando controles
            If DTConfiguracion.Rows(83 - 1).Item("Value2Int") = 1 Then
                If Tabla.Rows(0).Item("IDCliente") = DTConfiguracion.Rows(84 - 1).Item("Value2Int") Then
                    frm_recibo_pagos.LiberarControles.Text = 1
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").OwnerBand = frm_recibo_pagos.GridBand1
                    frm_recibo_pagos.AdvBandedGridView1.SetColumnPosition(frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura"), 0, 0)
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").Visible = True
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").VisibleIndex = 0
                Else
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").Visible = False
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").OwnerBand = Nothing
                    'frm_recibo_pagos.AdvBandedGridView1.column
                End If
            End If




            frm_recibo_pagos.btnBuscarCliente.Enabled = False
        Else
            MessageBox.Show("No hay una fila seleccionada.")
        End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub RemoveSavedRows(ByVal IDFactura As Integer)
        Try
            Dim iterateIndex As Integer = 0
            Dim newDataTable As DataTable = frm_recibo_pagos.DTFacturas.Copy
            For Each RT As DataRow In newDataTable.Rows
                If IDFactura = RT.Item("IDFacturaDatos") Then
                    frm_recibo_pagos.DTFacturas.Rows.RemoveAt(iterateIndex)
                Else
                    iterateIndex += 1
                End If
            Next
            newDataTable.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Sub RefrescarTablaFacturas()
        'Try
        If frm_recibo_pagos.Visible = True Then

            frm_recibo_pagos.DTFacturas.Rows.Clear()
            frm_recibo_pagos.DTPagares.Rows.Clear()
            frm_recibo_pagos.RefrescarTablaFacturas()

            ConMixta.Open()

            Dim CmdFacts As New MySqlCommand("Select IDDetalleAbono,FacturaDatos.NombreFactura,IDFactura as IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,FacturaDatos.Fecha,FechaVencimiento,DATEDIFF(Abonos.Fecha,FacturaDatos.Fecha) as DiasVencidos,FacturaDatos.TotalNeto,DetalleAbonos.BalanceAnterior as Balance,DetalleAbonos.CargosAnterior as CargosFactura,EstadoFactura,EstadoFactura.Color as ColorColumn,(DetalleAbonos.BalanceAnterior-DetalleAbonos.Debito-DetalleAbonos.Descuento) as Balance ,DetalleAbonos.CargosExcento,'0' as Incluir,DetalleAbonos.Cargos,DetalleAbonos.Debito as Aplicar,DetalleAbonos.Descuento,1 as Info FROM" & SysName.Text & "detalleabonos INNER JOIN" & SysName.Text & "FacturaDatos on DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono INNER JOIN Libregco.EstadoFactura ON FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura WHERE DetalleAbonos.IDAbono='" + frm_recibo_pagos.txtIDPago.Text + "'", ConMixta)
            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorFacturas.Read                       'IDDETALLEABONO              'IDFACTURA '                '''''''''SECONDID            IDTIPODOCUMENTO                              FECHA                                                         VENCIMIENTO                             DIAS VENCIDOS                        NETO                  BALANCE ANTERIOR               CARGOS                      DEBITO                      DESCUENTO            CHECKBOX                                              BALANCE FINAL                                                   CARGOS ACUMULADOS             CARGOS EXCENTOS           ESTADO                           COLOR                                     
                RemoveSavedRows(LectorFacturas.GetValue(2))

                frm_recibo_pagos.DTFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), LectorFacturas.GetValue(2), LectorFacturas.GetValue(3), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5), LectorFacturas.GetValue(6), (LectorFacturas.GetValue(7)), LectorFacturas.GetValue(8), LectorFacturas.GetValue(9), LectorFacturas.GetValue(10), LectorFacturas.GetValue(11), LectorFacturas.GetValue(12), LectorFacturas.GetValue(13), LectorFacturas.GetValue(14), LectorFacturas.GetValue(15), LectorFacturas.GetValue(16), LectorFacturas.GetValue(17), LectorFacturas.GetValue(18), LectorFacturas.GetValue(19))
            End While

            LectorFacturas.Close()
            ConMixta.Close()

            frm_recibo_pagos.CheckCargos()
            frm_recibo_pagos.ResetHeaderCheckBoxLocation(frm_recibo_pagos.AdvBandedGridView1.Columns("Incluir").ColIndex, -1)


        End If


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub frm_consulta_recibos_ingresos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        GridView1.BestFitColumns()
    End Sub

    Private Sub GridView1_EndGrouping(sender As Object, e As EventArgs) Handles GridView1.EndGrouping
        GridView1.BestFitColumns()
    End Sub


    Private Sub btnSucursal_Click(sender As Object, e As EventArgs) Handles btnSucursal.Click
        frm_buscar_sucursal.ShowDialog(Me)
    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Archivos de Excel (*.xls)|*.xls"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            GridView1.ExportToXls(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub PrevisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrevisualizarToolStripMenuItem.Click
        ' Check whether the GridControl can be previewed. 
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
        Else
            GridView1.ShowPrintPreview()
        End If
    End Sub

    Private Sub ImpresiónDirectaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresiónDirectaToolStripMenuItem.Click
        Try
            ' Check whether the GridControl can be printed. 
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Else
                GridView1.Print()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Portable Documento Format (*.pdf)|*.pdf"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            GridView1.ExportToPdf(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Clipboard.SetText(GridView1.GetFocusedDisplayText())
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.Columns.Count - 1
            If GridView1.Columns(i).Visible = True Then
                str = str & " ׀ " & GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, GridView1.Columns(i))
            End If
        Next

        Clipboard.SetText(str)

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.RowCount - 1
            str = str & vbNewLine & GridView1.GetRowCellValue(i, GridView1.FocusedColumn)
        Next

        Clipboard.SetText(str)
    End Sub

End Class