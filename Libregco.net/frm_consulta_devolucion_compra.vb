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
Public Class frm_consulta_devolucion_compra

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDDevolucionCompra,DevolucionCompra.SecondID,DevolucionCompra.Fecha,Compras.NoFactura,Compras.IDSuplidor,Suplidor.Suplidor,Devolver,DevolucionCompra.Nulo FROM" & SysName.Text & "devolucionCompra INNER JOIN" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor"
    Dim FullCommand, FechaValue, IDSuplidorValue, IDMotivoDevolucionValue, NuloValue, IDCompraValue As String
    Dim A1, A2, A3, A4 As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_devolucion_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDDevolucionCompra,DevolucionCompra.SecondID,DevolucionCompra.Fecha,Compras.NoFactura,Compras.IDSuplidor,Suplidor.Suplidor,Devolver,DevolucionCompra.Nulo FROM" & SysName.Text & "devolucionCompra INNER JOIN" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor WHERE DevolucionCompra.Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and DevolucionCompra.Nulo=0 ORDER BY IDDevolucionCompra DESC", ConMixta)
        RefrescarTabla()
        ConstructorSQL()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDMotivoDevolucion.Clear()
        txtMotivoDevolucion.Clear()
        txtIDFactura.Clear()
        txtIDSuplidor.Focus()
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
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Devolucion")
            DgvDevolucionCompra.DataSource = Ds
            DgvDevolucionCompra.DataMember = "Devolucion"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvDevolucionCompra.ClearSelection()
        Catch ex As Exception
            ConMixta.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvDevolucionCompra

            .Columns(0).Visible = False

            .Columns(1).HeaderText = "No. Devolución"
            .Columns(1).Width = 120

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns(2).Width = 70

            .Columns(3).Width = 100
            .Columns(3).HeaderText = "No. Factura"

            .Columns(4).Width = 40
            .Columns(4).HeaderText = "ID"

            .Columns(5).Width = 290
            .Columns(5).HeaderText = "Suplidor"

            .Columns(6).Width = 130
            .Columns(6).HeaderText = "Monto"
            .Columns(6).DefaultCellStyle.Format = ("C")

            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvDevolucionCompra.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvDevolucionCompra.Rows(x).Cells(6).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvDevolucionCompra.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub SelectSuplidor()
        Try
            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Suplidor FROM Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Suplidor")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("Suplidor")
            txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectCliente")
            txtSuplidor.Text = ""
        End Try
    End Sub

    Private Sub SelectMotivoDevolucion()
        Try

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM motivodevolucion Where IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "motivodevolucion")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("motivodevolucion")
            txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))

        Catch ex As Exception
            txtMotivoDevolucion.Text = ""
            'MessageBox.Show(ex.Message.ToString & " Desde SelectIDMotivoDevolucion()")
        End Try
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        SelectSuplidor()
        VerificarCondicionSuplidor()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
        VerificarCondicionNulo()
    End Sub

    Private Sub txtIDMotivoDevolucion_TextChanged(sender As Object, e As EventArgs) Handles txtIDMotivoDevolucion.TextChanged
        VerificarCondicionMotivoDevolucion()
    End Sub

    Private Sub VerificarCondicionMotivoDevolucion()
        If txtIDMotivoDevolucion.Text = "" Then
            IDMotivoDevolucionValue = ""
        Else
            IDMotivoDevolucionValue = " DevolucionCompra.IDMotivoDevolucion=" & txtIDMotivoDevolucion.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionSuplidor()
        If txtIDSuplidor.Text = "" Then
            IDSuplidorValue = ""
        Else
            IDSuplidorValue = " Compras.IDSuplidor=" & txtIDSuplidor.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " DevolucionCompra.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
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

    Private Sub VerificarCondicionFacturaValue()
        If txtIDFactura.Text = "" Then
            IDCompraValue = ""
        Else
            IDCompraValue = " Compras.NoFactura='" & txtIDFactura.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " DevolucionCompra.Nulo=0 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionMotivoDevolucion()
        VerificarCondicionSuplidor()
        VerificarCondicionFecha()
        VerificarCondicionFacturaValue()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDSuplidorValue <> "" Or IDMotivoDevolucionValue <> "" Or IDCompraValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDSuplidorValue & IDMotivoDevolucionValue & IDCompraValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDSuplidorValue <> "" And IDMotivoDevolucionValue & IDCompraValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDMotivoDevolucionValue <> "" And IDCompraValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If IDCompraValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDSuplidorValue & A2 & IDMotivoDevolucionValue & A3 & IDCompraValue & A4 & NuloValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvDevolucionCompra.Rows
                If CInt(Row.Cells(9).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub txtIDMotivoDevolucion_Leave(sender As Object, e As EventArgs) Handles txtIDMotivoDevolucion.Leave
        SelectMotivoDevolucion()
    End Sub

    Private Sub btnBuscarMotivoDevolucion_Click(sender As Object, e As EventArgs) Handles btnBuscarMotivoDevolucion.Click
        frm_buscar_mot_devolucion.ShowDialog(Me)
    End Sub

    Private Sub txtIDSuplidor_TextChanged(sender As Object, e As EventArgs) Handles txtIDSuplidor.TextChanged
        VerificarCondicionSuplidor()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub txtIDFactura_TextChanged(sender As Object, e As EventArgs) Handles txtIDFactura.TextChanged
        VerificarCondicionFacturaValue()
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

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='DevCompra' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Devolución Compras' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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

    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            Dim DsSP As New DataSet

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            If TypeConnection.Text = 1 Then
                frm_reportView.ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text)
            Else
                frm_reportView.ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            End If

            If DgvDevolucionCompra.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
                '@Fecha
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
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

                '@Suplidor
                If txtIDSuplidor.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSuplidor.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Suplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoSuplidor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoSuplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDRecepcion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDRecepcion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Motivo
                If txtIDMotivoDevolucion.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDMotivoDevolucion.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Motivo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Producto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Producto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Marca
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Marca")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NCF
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NCF")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Condicion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                If chkNulos.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                Else
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NoDocumento
                If txtIDFactura.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDFactura.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NoDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                ''Setting Info
                ''Resumir Reporte
                If chkResumir.Checked = True Then
                    frm_reportView.ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    frm_reportView.ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Ordenamiento de Reporte
                frm_reportView.ObjRpt.SetParameterValue("@SortedField", "")
                frm_reportView.ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Devolución")
                'RangoFechas()
                frm_reportView.ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                frm_reportView.ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ''Almacenes
                frm_reportView.ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvDevolucionCompra.SelectedRows.Count > 0 Then
                    Dim IDDevolucion As New Label
                    IDDevolucion.Text = DgvDevolucionCompra.SelectedRows(0).Cells(0).Value

                    If DgvDevolucionCompra.SelectedRows(0).Cells(7).Value = 1 Then
                        MessageBox.Show("El documento de devolución de compras No. " & DgvDevolucionCompra.SelectedRows(0).Cells(1).Value & " de fecha " & DgvDevolucionCompra.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim cmdSP As New MySqlCommand
                    Dim AdaptadorSP As MySqlDataAdapter

                    'Consulta de los datos de la devolucion compra   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AdaptadorSP = New MySqlDataAdapter("SELECT devolucioncompra.IDDevolucionCompra,devolucioncompra.IDTipoDocumento,TipoDocumento.Documento,devolucioncompra.SecondID AS SecondIDDevCompra,devolucioncompra.IDUsuario,Usuarios.Nombre as NombreUsuario,Devolucioncompra.Fecha,Devolucioncompra.Hora,DevolucionCompra.IDSucursal,DevolucionCompra.IDAlmacen,Almacen.Almacen,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.RNC,Suplidor.Direccion,Suplidor.Telefono,Suplidor.Fax,Suplidor.Representante,Suplidor.TelefonoRepresentante,devolucioncompra.IDFactura,Compras.SecondID AS SecondIDFact,Compras.FechaFactura,Compras.NoFactura,Compras.IDComprobanteFiscal as IDNCFCompra,Compras.NCF as NCFFact,DevolucionCompra.NCF AS NCFDevolucionCompra,DevolucionCompra.IDMotivoDevolucion,MotivoDevolucion.Descripcion as MotivoDevolucion,DevolucionCompra.DevolverItbis,DevolucionCompra.Devolver,DevolucionCompra.Itbis,DevolucionCompra.Neto,DevolucionCompra.DiasTransaccion,DevolucionCompra.Impreso,DevolucionCompra.Nulo,devolucioncompradetalle.IDArticulo,Articulos.Descripcion,Articulos.Referencia as ReferenciaArt,devolucioncompradetalle.IDMedida,Medida.Medida,CantDevuelta,PrecioDevuelto,DevolucionCompraDetalle.IDAlmacen as IDAlmacenArticulo,AlmacenArticulo.Almacen as AlmacenArticulo FROM" & SysName.Text & "devolucioncompra INNER JOIN" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN" & SysName.Text & "Empleados as Usuarios on DevolucionCompra.IDUsuario=Usuarios.IDEmpleado INNER JOIN Libregco.MotivoDevolucion on DevolucionCompra.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion INNER JOIN" & SysName.Text & "DevolucionCompraDetalle on DevolucionCompra.IDDevolucionCompra=DevolucionCompraDetalle.IDDevolucionCompra INNER JOIN Libregco.Articulos on DevolucionCompraDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on DevolucionCompraDetalle.IDMedida=Medida.IDMedida INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "TipoDocumento on DevolucionCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Almacen on DevolucionCompra.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Almacen as AlmacenArticulo on DevolucionCompraDetalle.IDAlmacen=AlmacenArticulo.IDAlmacen Where devolucioncompra.IDDevolucionCompra='" + DgvDevolucionCompra.SelectedRows(0).Cells(0).Value.ToString + "'", ConMixta)
                    AdaptadorSP.Fill(DsSP, "DevolucionCompraView")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Llenado EmpresaView
                    AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                    AdaptadorSP.Fill(DsSP, "EmpresaView")

                    cmdSP.Dispose()
                    AdaptadorSP.Dispose()

                    frm_reportView.ObjRpt.Database.Tables("devolucioncompraview1").SetDataSource(DsSP.Tables("DevolucionCompraView"))
                    frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))


                    ''@IDDocumento
                    'crParameterDiscreteValue.Value = IDDevolucion.Text
                    'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    'crParameterValues.Add(crParameterDiscreteValue)
                    'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                    Exit Sub
                End If
            End If

            LoadAnimation()

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
                    CrExportOptions = frm_reportView.ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    frm_reportView.ObjRpt.Export()
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
                    CrExportOptions = frm_reportView.ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    frm_reportView.ObjRpt.Export()
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

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvDevolucionCompra.SelectedRows.Count > 0 Then
                Dim IDDevolucionCompra As New Label
                IDDevolucionCompra.Text = DgvDevolucionCompra.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDDevolucionCompra,DevolucionCompra.SecondID,IDUsuario,Fecha,Hora,IDFactura,NCF,DevolverItbis,Devolver,DiasTransaccion,DevolucionCompra.IDMotivoDevolucion,MotivoDevolucion.Descripcion,DevolucionCompra.Nulo from" & SysName.Text & "DevolucionCompra INNER JOIN Libregco.motivodevolucion on DevolucionCompra.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion Where IDDevolucionCompra='" + IDDevolucionCompra.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "DevolucionCompra")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds.Tables("DevolucionCompra")

                If frm_devolucion_compras.Visible = True Then
                    frm_devolucion_compras.Close()
                End If

                frm_devolucion_compras.Show(Me)

                frm_devolucion_compras.txtFactura.Text = (Tabla.Rows(0).Item("IDFactura"))
                frm_devolucion_compras.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_devolucion_compras.txtIDDevolucion.Text = (Tabla.Rows(0).Item("IDDevolucionCompra"))
                frm_devolucion_compras.txtIDMotivoDevolucion.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_devolucion_compras.txtMontoDevolver.Text = CDbl(Tabla.Rows(0).Item("Devolver")).ToString("C")
                frm_devolucion_compras.txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_devolucion_compras.txtNCFDev.Text = (Tabla.Rows(0).Item("NCF"))
                frm_devolucion_compras.BuscarDevolucionProcesada()
                frm_devolucion_compras.FillChkDevolucion()
                frm_devolucion_compras.FactStatus()

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class