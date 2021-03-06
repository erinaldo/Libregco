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

Public Class frm_consulta_facturas_cxp
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Friend IDReport, NameReport, PathReport, VerificarSubTotales As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim SelectCommand As String = "Select IDCompra,Compras.SecondID,Compras.Fecha,Compras.FechaFactura,FechaVencimiento,Compras.IDSuplidor,Suplidor,Compras.IDCondicion,Condicion.Condicion,NoFactura,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,NCF,Subtotal,Descuento,Descuento2,Itbis,Flete,TotalNeto,Compras.RutaDocumento,SubtotalLlenado,Compras.Nulo,TipoMoneda.Texto,Compras.IDMoneda FROM" & SysName.Text & "Compras INNER JOIN Libregco.Suplidor On Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "Comprobantefiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda"

    Dim Permisos As New ArrayList
    Friend LookingForIDCompra As String
    Friend TableCompras As DataTable
    Dim RepositoryPicture As New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit With {.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray, .PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder, .PictureAlignment = ContentAlignment.MiddleCenter, .ShowIcon = True, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom, .NullText = "", .ShowMenu = True}
    Dim RepositorySubtotales As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .ValueGrayed = "", .Caption = "Subtotales", .ReadOnly = False}
    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryCurrency As New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()


    Private Sub frm_consulta_facturas_cxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        SetComprasTable()
        LimpiarDatos()
        Actualizar()
        RefrescarTabla()
        FillReportes()
    End Sub

    Private Sub CargarConfiguracion()
        ConMixta.Open()
        'Hacer revisión de subtotales durante el registro de compras
        cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=164", ConMixta)
        VerificarSubTotales.Text = Convert.ToString(cmd.ExecuteScalar())
        ConMixta.Close()
    End Sub

    Private Sub SetComprasTable()
        RepositoryCurrency.SmallImages = imgFlags
        RepositoryCurrency.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near
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

        TableCompras = New DataTable("Compras")

        ' Create DataColumn objects of data types.
        TableCompras.Columns.Add("ID", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TableCompras.Columns.Add("FechaFactura", System.Type.GetType("System.DateTime"))
        TableCompras.Columns.Add("Vencimiento", System.Type.GetType("System.DateTime"))
        TableCompras.Columns.Add("IDSuplidor", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("Suplidor", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("IDCondicion", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("Condicion", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("NoFactura", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("IDComprobanteFiscal", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("NCF", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("Subtotal", System.Type.GetType("System.Double"))
        TableCompras.Columns.Add("Descuento", System.Type.GetType("System.Double"))
        TableCompras.Columns.Add("Descuento2", System.Type.GetType("System.Double"))
        TableCompras.Columns.Add("Itbis", System.Type.GetType("System.Double"))
        TableCompras.Columns.Add("Flete", System.Type.GetType("System.Double"))
        TableCompras.Columns.Add("TotalNeto", System.Type.GetType("System.Double"))
        TableCompras.Columns.Add("RutaFoto", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("Imagen", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("SubTotalVerificadoValue", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("Nulo", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("Moneda", System.Type.GetType("System.String"))
        TableCompras.Columns.Add("MonedaImagen", System.Type.GetType("System.Object"))

        GridControl1.DataSource = TableCompras
        GridView1.Columns(1).ColumnEdit = RepositorySecondID
        GridView1.Columns(20).ColumnEdit = RepositoryPicture
        GridView1.Columns(21).ColumnEdit = RepositorySubtotales
        GridView1.Columns(24).ColumnEdit = RepositoryCurrency

        'Propiedades
        GridView1.Columns("ID").Visible = False
        GridView1.Columns("SecondID").Caption = "Código de compra"
        GridView1.Columns("SecondID").Caption = "Documento"
        GridView1.Columns("Fecha").Visible = False
        GridView1.Columns("Fecha").Caption = "Fecha de registro"
        GridView1.Columns("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GridView1.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy"
        GridView1.Columns("FechaFactura").Caption = "Fecha"
        GridView1.Columns("FechaFactura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GridView1.Columns("FechaFactura").DisplayFormat.FormatString = "dd/MM/yyyy"
        GridView1.Columns("Vencimiento").Visible = False
        GridView1.Columns("Vencimiento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GridView1.Columns("Vencimiento").DisplayFormat.FormatString = "dd/MM/yyyy"
        GridView1.Columns("IDSuplidor").Visible = False
        GridView1.Columns("IDSuplidor").Caption = "Código del suplidor"
        GridView1.Columns("Suplidor").Visible = True
        GridView1.Columns("IDCondicion").Caption = "Código de la condición"
        GridView1.Columns("IDCondicion").Visible = False
        GridView1.Columns("Condicion").Caption = "Condición"
        GridView1.Columns("Condicion").Visible = False
        GridView1.Columns("IDComprobanteFiscal").Visible = False
        GridView1.Columns("IDComprobanteFiscal").Caption = "Código del comprobante"
        GridView1.Columns("TipoComprobante").Visible = False
        GridView1.Columns("Subtotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Subtotal").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Descuento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Descuento").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Descuento2").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Descuento2").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Itbis").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Itbis").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Flete").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Flete").DisplayFormat.FormatString = "C2"
        GridView1.Columns("TotalNeto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("TotalNeto").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Descuento").Visible = False
        GridView1.Columns("Descuento2").Visible = False
        GridView1.Columns("RutaFoto").Visible = False
        GridView1.Columns("SubTotalVerificadoValue").Caption = "Subtotales"
        GridView1.Columns("Nulo").Visible = False
        GridView1.Columns(23).OptionsColumn.ReadOnly = True
        GridView1.Columns(23).OptionsColumn.AllowEdit = False
        GridView1.Columns(24).OptionsColumn.ReadOnly = True
        GridView1.Columns(24).OptionsColumn.AllowEdit = False

        If VerificarSubTotales.Text = 1 Then
            GridView1.Columns("SubTotalVerificadoValue").Visible = True
        Else
            GridView1.Columns("SubTotalVerificadoValue").Visible = False
        End If

        For i = 0 To GridView1.Columns.Count - 1
            GridView1.Columns(i).OptionsColumn.ReadOnly = True
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next
        For i = 21 To 22
            GridView1.Columns(i).OptionsColumn.ReadOnly = True
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next

        GridView1.Columns("Moneda").GroupIndex = 0

        Dim item As New DevExpress.XtraGrid.GridGroupSummaryItem
        item.FieldName = "TotalNeto"
        item.ShowInGroupColumnFooter = GridView1.Columns("TotalNeto")
        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item.DisplayFormat = "{0:c2}"
        item.ShowInGroupColumnFooter = Nothing
        GridView1.GroupSummary.Add(item)

        GridView1.ExpandAllGroups()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Dim ds As New DataSet
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='RegistroFacturaCXP' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Registro de facturas cxp' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            For Each Fila As DataRow In ds.Tables("Reportes").Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If ds.Tables("Reportes").Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

            ds.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDTipoComprobante.Clear()
        txtComprobanteFiscal.Clear()
        chkNulos.Checked = False
        FillCondicion()
        cbxCondicion.Text = "Todas"
        txtIDSuplidor.Focus()
    End Sub

    Private Sub Actualizar()
        cbxOrden.SelectedIndex = 0
        CbxTipoOrden.SelectedIndex = 0
        txtFechaFinal.Value = Today
        txtFechaInicial.Value = Today
    End Sub

    Private Sub FillCondicion()
        Dim ds As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Condicion FROM Condicion ORDER BY Dias", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "Condicion")
        cbxCondicion.Items.Clear()
        ConLibregco.Close()

        For Each Fila As DataRow In ds.Tables("Condicion").Rows
            cbxCondicion.Items.Add(Fila.Item("Condicion"))
        Next

        cbxCondicion.Items.Add("Todas")
    End Sub

    Sub RefrescarTabla()
        Try
            Dim ConditionalQuery As String = ConstructorQuery()
            'Dim img As Image
            Dim ds As New DataSet

            TableCompras.Rows.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand(SelectCommand & ConditionalQuery, ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Compras")
            ConMixta.Close()

            Dim TablaPaper As DataTable = ds.Tables("Compras")

            For Each itm As DataRow In TablaPaper.Rows
                'If System.IO.File.Exists(itm.Item("RutaDocumento")) = True Then
                '    img = Image.FromFile(itm.Item("RutaDocumento"))
                'Else
                '    img = Nothing
                'End If

                TableCompras.Rows.Add(itm.Item("IDCompra"), itm.Item("SecondID"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy hh: mm:ss tt"), CDate(itm.Item("FechaFactura")).ToString("dd/MM/yyyy"), CDate(itm.Item("FechaVencimiento")).ToString("dd/MM/yyyy"), itm.Item("IDSuplidor"), itm.Item("Suplidor"), itm.Item("IDCondicion"), itm.Item("Condicion"), itm.Item("NoFactura"), itm.Item("IDComprobanteFiscal"), itm.Item("TipoComprobante"), itm.Item("NCF"), itm.Item("Subtotal"), itm.Item("Descuento"), itm.Item("Descuento2"), itm.Item("Itbis"), itm.Item("Flete"), itm.Item("TotalNeto"), itm.Item("RutaDocumento"), If(itm.Item("RutaDocumento") = "", Nothing, itm.Item("RutaDocumento")), itm.Item("SubtotalLlenado"), itm.Item("Nulo"), itm.Item("Texto"), itm.Item("IDMoneda"))
            Next

            SumarRows()
            GridView1.BestFitColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SumarRows()
        Dim Flete As Double = 0
        For Each rw As DataRow In TableCompras.Rows
            Flete = Flete + CDbl(rw.Item("Flete"))
        Next

        If Flete = 0 Then
            GridView1.Columns(17).Visible = False
        Else
            GridView1.Columns(17).Visible = True
        End If
    End Sub

    Private Function ConstructorQuery() As String
        Dim Paremeter As Integer = 0
        Dim Str As String = ""
        Dim Orderby As String

        If IsDate(txtFechaInicial.Value) Or txtIDSuplidor.Text <> "" Or txtIDTipoComprobante.Text <> "" Or cbxCondicion.Text <> "Todas" Or chkNulos.CheckState = CheckState.Unchecked Then
            Str = Str & " WHERE "

            If IsDate(txtFechaInicial.Value) Then
                If Paremeter > 0 Then
                    Str = Str & " AND Compras.FechaFactura BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "' "
                    Paremeter += 1
                Else
                    Str = Str & " Compras.FechaFactura BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "' "
                    Paremeter += 1
                End If
            End If

            If txtIDSuplidor.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Compras.IDSuplidor=" & txtIDSuplidor.Text & " "
                    Paremeter += 1
                Else
                    Str = Str & " Compras.IDSuplidor=" & txtIDSuplidor.Text & " "
                    Paremeter += 1
                End If
            End If

            If txtIDTipoComprobante.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Compras.IDComprobanteFiscal=" & txtIDTipoComprobante.Text & " "
                    Paremeter += 1
                Else
                    Str = Str & " Compras.IDComprobanteFiscal=" & txtIDTipoComprobante.Text & " "
                    Paremeter += 1
                End If
            End If

            If cbxCondicion.Text <> "Todas" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Compras.IDCondicion=" & cbxCondicion.Tag.ToString & " "
                    Paremeter += 1
                Else
                    Str = Str & " Compras.IDCondicion=" & cbxCondicion.Tag.ToString & " "
                    Paremeter += 1
                End If
            End If

            If chkNulos.CheckState = CheckState.Unchecked Then
                If Paremeter > 0 Then
                    Str = Str & " AND Compras.Nulo=0 "
                    Paremeter += 1
                Else
                    Str = Str & " Compras.Nulo=0 "
                    Paremeter += 1
                End If
            End If
        End If

        If cbxOrden.Text = "Documento" Then
            Orderby = " ORDER BY IDCompra " & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Fecha" Then
            Orderby = " ORDER BY FechaFactura " & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Suplidor" Then
            Orderby = " ORDER BY Suplidor " & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Total" Then
            Orderby = " ORDER BY TotalNeto " & CbxTipoOrden.Text
        End If

        Return Str & " And Compras.IDTipoDocumento=19" & Orderby

    End Function

    Private Sub SelectSuplidor()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Suplidor FROM Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
        txtSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If txtSuplidor.Text = "" Then txtIDSuplidor.Clear()
    End Sub

    Private Sub SelectTipoNCF()
        Con.Open()
        cmd = New MySqlCommand("SELECT TipoComprobante FROM ComprobanteFiscal Where IDComprobanteFiscal='" + txtIDTipoComprobante.Text + "'", Con)
        txtComprobanteFiscal.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If txtComprobanteFiscal.Text = "" Then txtIDTipoComprobante.Clear()
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        SelectSuplidor()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        RefrescarTabla()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnImagen.Click
        If TypeConnection.Text = 1 Then
            Dim ExistFile As Boolean = System.IO.File.Exists(GridView1.GetFocusedRowCellValue("RutaFoto").ToString)
            If ExistFile = True Then

                System.Diagnostics.Process.Start(GridView1.GetFocusedRowCellValue("RutaFoto").ToString)
            Else
                MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una copia de la factura. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & GridView1.GetFocusedRowCellValue("RutaFoto").ToString & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub txtIDTipoComprobante_Leave(sender As Object, e As EventArgs) Handles txtIDTipoComprobante.Leave
        SelectTipoNCF()
    End Sub

    Private Sub btnBuscarSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoComprobante_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoComprobante.Click
        frm_buscar_tipo_comprobantes.ShowDialog(Me)
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        If cbxCondicion.Text <> "Todas" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
            cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If

    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
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


            If GridView1.RowCount = 0 Then
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

                '@Suplidor
                If txtIDSuplidor.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSuplidor.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Suplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoSuplidor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoSuplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoDocumento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoDocumento")
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

                '@Condicion
                If cbxCondicion.Text = "Todas" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = cbxCondicion.Tag.ToString
                End If

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoNCF
                If txtIDTipoComprobante.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDTipoComprobante.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNCF")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Gasto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Gasto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoCompra
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoCompra")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = 19
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

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
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

                'Setting Info 
                'Resumir Reporte
                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Compra")
                'RangoFechas()
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ''Almacenes
                ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If GridView1.SelectedRowsCount > 0 Then
                    Dim IDCompra As New Label
                    IDCompra.Text = GridView1.GetFocusedRowCellValue("ID").ToString

                    If GridView1.GetFocusedRowCellValue("Nulo").ToString = 1 Then
                        MessageBox.Show("El documento de registro de compras " & GridView1.GetFocusedRowCellValue("SecondID").ToString & " de fecha " & GridView1.GetFocusedRowCellValue("Fecha").ToString & " está nulo, por lo que no se puede visualizar la factura.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDCompra.Text
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
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Dim dstemp As New DataSet

        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Reportes")
        Con.Close()

        IDReport.Text = (dstemp.Tables("Reportes").Rows(0).Item("IDReportes"))
        NameReport.Text = (dstemp.Tables("Reportes").Rows(0).Item("Reporte"))
        PathReport.Text = (dstemp.Tables("Reportes").Rows(0).Item("Path"))

        If (dstemp.Tables("Reportes").Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Visible = False
        Else
            chkResumir.Visible = True
        End If

        dstemp.Dispose()

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

    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 459
            frm_subir_documento.PicDocumento.Height = 530
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaFoto"))

            If GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaFoto")) <> "" Then
                If System.IO.File.Exists(GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaFoto"))) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaFoto")), FileMode.Open, FileAccess.Read)
                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                    frm_subir_documento.btnDownload.Visible = True
                Else
                    frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                    frm_subir_documento.btnBuscar.PerformClick()
                    frm_subir_documento.btnDownload.Visible = False
                End If
            Else
                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                frm_subir_documento.btnBuscar.PerformClick()
                frm_subir_documento.btnDownload.Visible = False
            End If



        End If
    End Sub

    Private Sub ControlDeSubtotalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeSubtotalesToolStripMenuItem.Click
        frm_subtotales_compras.ShowDialog(Me)
    End Sub

    Private Sub frm_consulta_compras_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            GridView1.BestFitColumns()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        Try
            If GridView1.FocusedRowHandle >= 0 Then

                If Me.Owner.Name = frm_devolucion_compras.Name Then
                    frm_devolucion_compras.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString
                    Close()

                Else

                    If GridView1.FocusedColumn.FieldName = "SecondID" Then
                        btnModificar.PerformClick()

                    ElseIf GridView1.FocusedColumn.FieldName = "Imagen" Then
                        If TypeConnection.Text = 1 Then

                            If frm_subir_documento.Visible = True Then
                                frm_subir_documento.Close()
                            End If

                            frm_subir_documento.Show(Me)
                            frm_subir_documento.PicDocumento.Width = 539
                            frm_subir_documento.PicDocumento.Height = 607
                            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

                            frm_subir_documento.RutaDocumento.Text = GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaFoto"))

                            If GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaFoto")) <> "" Then
                                If System.IO.File.Exists(GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaFoto"))) = True Then
                                    Dim wFile As System.IO.FileStream
                                    wFile = New FileStream(GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaFoto")), FileMode.Open, FileAccess.Read)
                                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                                    wFile.Close()
                                    frm_subir_documento.btnDownload.Visible = True
                                Else
                                    frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                                    frm_subir_documento.btnBuscar.PerformClick()
                                    frm_subir_documento.btnDownload.Visible = False
                                End If
                            Else
                                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                                frm_subir_documento.btnBuscar.PerformClick()
                                frm_subir_documento.btnDownload.Visible = False
                            End If
                        End If

                    ElseIf GridView1.FocusedColumn.FieldName = "SubTotalVerificadoValue" Then

                        frm_subtotales_compras.ShowDialog(Me)
                    End If
                End If


            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView1_EndGrouping(sender As Object, e As EventArgs) Handles GridView1.EndGrouping
        GridView1.BestFitColumns()
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Nulo"))
                If category = "1" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.SeaShell
                    e.HighPriority = True
                End If
            End If

            If Me.Owner.Name = frm_envio_606.Name Then
                Dim View1 As GridView = sender
                If (e.RowHandle >= 0) Then
                    Dim category As String = View1.GetRowCellDisplayText(e.RowHandle, View1.Columns("ID"))
                    If category = LookingForIDCompra Then
                        e.Appearance.BackColor = Color.LightBlue
                        e.Appearance.BackColor2 = SystemColors.HighlightText
                        e.HighPriority = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

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

    Private Sub ImprimirGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirGridToolStripMenuItem.Click
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

    Private Sub PrevisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrevisualizarToolStripMenuItem.Click
        ' Check whether the GridControl can be previewed. 
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
        Else
            GridView1.ShowPrintPreview()
        End If
    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If GridView1.FocusedRowHandle >= 0 Then
                Dim DsTemp As New DataSet

                If GridView1.SelectedRowsCount > 0 Then
                    frm_superclave.IDAccion.Text = 19
                    frm_superclave.ShowDialog(Me)

                    If ControlSuperClave = 1 Then
                        frm_factura_cxp.Close()
                        Exit Sub
                    End If

                    Dim IDCompra As New Label
                    IDCompra.Text = GridView1.GetFocusedRowCellValue("ID").ToString

                    DsTemp.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDCompra,Compras.SecondID,Compras.IDSuplidor,Suplidor,IDUsuario,Empleados.Nombre,Fecha,Hora,Compras.IDCondicion,Condicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,Compras.IDComprobanteFiscal,TipoComprobante,NCF,Compras.IDAlmacen,Almacen,SubTotal,Descuento,Descuento2,Itbis,Flete,TotalNeto,IDEmpleadoRec,EmpleadoRecep.Nombre as EmpleadoRecibe,DiaRecepcion,Nota,RutaDocumento,Suplidor.Balance,Compras.Nulo,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "Empleados on Compras.IDUsuario=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados as EmpleadoRecep on Compras.IDEmpleadoRec=EmpleadoRecep.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Almacen on Compras.IDAlmacen=Almacen.IDAlmacen where IDCompra='" + IDCompra.Text + "' LIMIT 1", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Compras")
                    ConMixta.Close()

                    Dim Tabla As DataTable = DsTemp.Tables("Compras")

                    If frm_factura_cxp.Visible = True Then
                        frm_factura_cxp.Close()
                    End If

                    frm_factura_cxp.Show(Me)
                    frm_factura_cxp.txtIDCompra.Text = (Tabla.Rows(0).Item("IDCompra"))
                    frm_factura_cxp.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                    frm_factura_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                    frm_factura_cxp.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                    frm_factura_cxp.txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")
                    frm_factura_cxp.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                    frm_factura_cxp.cbxCondicion.Tag = (Tabla.Rows(0).Item("IDCondicion"))
                    frm_factura_cxp.DtpFechaFact.Value = (Tabla.Rows(0).Item("FechaFactura"))
                    frm_factura_cxp.DtpVencimiento.Value = (Tabla.Rows(0).Item("FechaVencimiento"))
                    frm_factura_cxp.txtNoFact.Text = (Tabla.Rows(0).Item("NoFactura"))
                    frm_factura_cxp.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                    frm_factura_cxp.CbxTipoComprobante.Tag = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                    frm_factura_cxp.txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
                    frm_factura_cxp.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                    frm_factura_cxp.CbxEmpleadoRec.Text = (Tabla.Rows(0).Item("EmpleadoRecibe"))
                    frm_factura_cxp.CbxEmpleadoRec.Tag = (Tabla.Rows(0).Item("IDEmpleadoRec"))
                    frm_factura_cxp.DtpDiaRecibido.Value = (Tabla.Rows(0).Item("DiaRecepcion"))
                    frm_factura_cxp.CbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))
                    frm_factura_cxp.CbxAlmacen.Tag = (Tabla.Rows(0).Item("IDAlmacen"))
                    frm_factura_cxp.txtNotaCompra.Text = (Tabla.Rows(0).Item("Nota"))
                    frm_factura_cxp.txtSubTotal.Text = CDbl((Tabla.Rows(0).Item("SubTotal"))).ToString("C")
                    frm_factura_cxp.txtDescuento.Text = CDbl((Tabla.Rows(0).Item("Descuento"))).ToString("C")
                    frm_factura_cxp.txtItbis.Text = CDbl((Tabla.Rows(0).Item("Itbis"))).ToString("C")
                    frm_factura_cxp.txtFlete.Text = CDbl((Tabla.Rows(0).Item("Flete"))).ToString("C")
                    frm_factura_cxp.txtNeto.Text = CDbl((Tabla.Rows(0).Item("TotalNeto"))).ToString("C")
                    frm_factura_cxp.RutaDocumento.Text = (Tabla.Rows(0).Item("RutaDocumento"))
                    frm_factura_cxp.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

                    If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                        frm_factura_cxp.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                    Else
                        frm_factura_cxp.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                    End If

                    If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                        frm_factura_cxp.chkNulo.Checked = False
                    Else
                        frm_factura_cxp.chkNulo.Checked = True
                    End If

                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                End If
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.FocusedRowHandle >= 0 Then
            If TypeConnection.Text = 1 Then
                If TableCompras.Rows.Count = 0 Then
                    btnImagen.Visible = False
                    btnSubir.Visible = False
                    ControlDeSubtotalesToolStripMenuItem.Visible = False
                Else
                    If GridView1.SelectedRowsCount > 0 Then

                        If GridView1.GetFocusedRowCellValue("RutaFoto").ToString <> "" Then
                            btnImagen.Visible = True
                            btnSubir.Visible = False
                        Else
                            btnImagen.Visible = False
                            btnSubir.Visible = True
                        End If

                        If GridView1.GetFocusedRowCellValue("Nulo").ToString = "0" Then
                            ControlDeSubtotalesToolStripMenuItem.Image = OverlayImages(My.Resources.Duplicatex48, My.Resources.Checkedx32, New Point(5, 5))
                        Else
                            ControlDeSubtotalesToolStripMenuItem.Image = OverlayImages(My.Resources.Duplicatex48, My.Resources.uncheckedx32, New Point(5, 5))
                        End If

                        ControlDeSubtotalesToolStripMenuItem.Visible = True

                    Else
                        ControlDeSubtotalesToolStripMenuItem.Visible = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub PicLogo_Click(sender As Object, e As EventArgs) Handles PicLogo.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & SelectCommand
        frm_query_structure.ShowDialog(Me)
    End Sub
End Class