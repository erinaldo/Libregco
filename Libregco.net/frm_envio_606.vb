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
Imports DevExpress.XtraGrid
Imports DevExpress.Utils

Public Class frm_envio_606
    Dim ID606 As String
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim sqlQ As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend TablaCompras As DataTable
    Dim RepositoryTipoGasto As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard, .BestFitWidth = True}
    Dim RepositoryTipoRetencion As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard, .BestFitWidth = True}
    Dim RepositoryTipoPago As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard, .BestFitWidth = True}

    Dim RepositorySubtotalBienes As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositorySubtotalServicios As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositorySubtotalTotal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisFacturado As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisRetenido As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisProporcionalidad As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisalCosto As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisAdelantar As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisPercibido As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryISRMontoRetencion As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryISRPercibido As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryISCTotal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryOtrosImpuestos As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryPropinalLegal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryCurrency As New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
    Dim RepositoryTasa As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()

    Dim RepositoryActualizar As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit() With {.Name = "update_button"}


    Private Sub frm_envio_606_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        SetTablaComprasTable()
        LimpiarDatos()
        Actualizar()
        RefrescarTabla()

        RepositorySubtotalBienes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositorySubtotalBienes.Mask.EditMask = "c"
        RepositorySubtotalBienes.Mask.UseMaskAsDisplayFormat = True
        RepositorySubtotalBienes.NullText = CDbl(0).ToString("C")
        RepositorySubtotalBienes.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositorySubtotalServicios.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositorySubtotalServicios.Mask.EditMask = "c"
        RepositorySubtotalServicios.Mask.UseMaskAsDisplayFormat = True
        RepositorySubtotalServicios.NullText = CDbl(0).ToString("C")
        RepositorySubtotalServicios.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositorySubtotalTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositorySubtotalTotal.Mask.EditMask = "c"
        RepositorySubtotalTotal.Mask.UseMaskAsDisplayFormat = True
        RepositorySubtotalTotal.NullText = CDbl(0).ToString("C")
        RepositorySubtotalTotal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbisFacturado.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisFacturado.Mask.EditMask = "c"
        RepositoryItbisFacturado.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbisFacturado.NullText = CDbl(0).ToString("C")
        RepositoryItbisFacturado.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbisRetenido.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisRetenido.Mask.EditMask = "c"
        RepositoryItbisRetenido.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbisRetenido.NullText = CDbl(0).ToString("C")
        RepositoryItbisRetenido.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbisProporcionalidad.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisProporcionalidad.Mask.EditMask = "c"
        RepositoryItbisProporcionalidad.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbisProporcionalidad.NullText = CDbl(0).ToString("C")
        RepositoryItbisProporcionalidad.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbisalCosto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisalCosto.Mask.EditMask = "c"
        RepositoryItbisalCosto.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbisalCosto.NullText = CDbl(0).ToString("C")
        RepositoryItbisalCosto.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbisAdelantar.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisAdelantar.Mask.EditMask = "c"
        RepositoryItbisAdelantar.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbisAdelantar.NullText = CDbl(0).ToString("C")
        RepositoryItbisAdelantar.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbisPercibido.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisPercibido.Mask.EditMask = "c"
        RepositoryItbisPercibido.NullText = CDbl(0).ToString("C")
        RepositoryItbisPercibido.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryISRMontoRetencion.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryISRMontoRetencion.Mask.EditMask = "c"
        RepositoryISRMontoRetencion.Mask.UseMaskAsDisplayFormat = True
        RepositoryISRMontoRetencion.NullText = CDbl(0).ToString("C")
        RepositoryISRMontoRetencion.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryISRPercibido.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryISRPercibido.Mask.EditMask = "c"
        RepositoryISRPercibido.Mask.UseMaskAsDisplayFormat = True
        RepositoryISRPercibido.NullText = CDbl(0).ToString("C")
        RepositoryISRPercibido.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryISCTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryISCTotal.Mask.EditMask = "c"
        RepositoryISCTotal.Mask.UseMaskAsDisplayFormat = True
        RepositoryISCTotal.NullText = CDbl(0).ToString("C")
        RepositoryISCTotal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryOtrosImpuestos.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryOtrosImpuestos.Mask.EditMask = "c"
        RepositoryOtrosImpuestos.Mask.UseMaskAsDisplayFormat = True
        RepositoryOtrosImpuestos.NullText = CDbl(0).ToString("C")
        RepositoryOtrosImpuestos.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryPropinalLegal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryPropinalLegal.Mask.EditMask = "c"
        RepositoryPropinalLegal.Mask.UseMaskAsDisplayFormat = True
        RepositoryPropinalLegal.NullText = CDbl(0).ToString("C")
        RepositoryPropinalLegal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryTasa.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryTasa.Mask.EditMask = "c"
        RepositoryTasa.Mask.UseMaskAsDisplayFormat = True
        RepositoryTasa.NullText = CDbl(0).ToString("C")
        RepositoryTasa.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryActualizar.Buttons(0).Caption = "Actualizar"
        RepositoryActualizar.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        RepositoryActualizar.Buttons(0).Image = My.Resources.Editor_24
        RepositoryActualizar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        RepositoryActualizar.LookAndFeel.UseDefaultLookAndFeel = False
        RepositoryActualizar.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Office2010Silver)
    End Sub

    Private Sub SetTablaComprasTable()
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

        FillTipoGasto()
        FillTipoRetencion()
        FillTipoPago()

        TablaCompras = New DataTable("Compras")
        TablaCompras.Columns.Add("ID606Detalle", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("IDCompra", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("IDTipoDocumento", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("TipoDocumento", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("IDSuplidor", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Suplidor", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("RNC", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("TipoID", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("TipoBienes", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("IDTipoComprobanteFiscal", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("TipoComprobanteFiscal", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("NCF", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("NCFModificado", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Fecha", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("AnoMes", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("FechaDia", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("MontoFacturaBienes", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("MontoFacturaServicios", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("MontoFacturadoTotal", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ItbisFacturado", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ItbisRetenido", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ItbisProporcionalidad", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ItbisalCosto", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ItbisporAdelantar", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ItbisPercibidoenCompras", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("TipodeISR", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("MontoRetencion", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ISRPercibido", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ImpuestoSelectivoC", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("OtrosImpuestos", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("MontoPropinaLegal", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("FormaPago", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Estatus", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Actualizar", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Moneda", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("MonedaImagen", System.Type.GetType("System.Object"))
        TablaCompras.Columns.Add("Tasa", System.Type.GetType("System.String"))

        GridControl1.DataSource = TablaCompras

        GridView1.Columns("TipoBienes").ColumnEdit = RepositoryTipoGasto
        GridView1.Columns("FormaPago").ColumnEdit = RepositoryTipoPago
        GridView1.Columns("TipodeISR").ColumnEdit = RepositoryTipoRetencion
        GridView1.Columns("MontoFacturaBienes").ColumnEdit = RepositorySubtotalBienes
        GridView1.Columns("MontoFacturaServicios").ColumnEdit = RepositorySubtotalServicios
        GridView1.Columns("MontoFacturadoTotal").ColumnEdit = RepositorySubtotalTotal
        GridView1.Columns("ItbisFacturado").ColumnEdit = RepositoryItbisFacturado
        GridView1.Columns("ItbisRetenido").ColumnEdit = RepositoryItbisRetenido
        GridView1.Columns("ItbisProporcionalidad").ColumnEdit = RepositoryItbisProporcionalidad
        GridView1.Columns("ItbisalCosto").ColumnEdit = RepositoryItbisalCosto
        GridView1.Columns("ItbisporAdelantar").ColumnEdit = RepositoryItbisAdelantar
        GridView1.Columns("ItbisPercibidoenCompras").ColumnEdit = RepositoryItbisPercibido
        GridView1.Columns("MontoRetencion").ColumnEdit = RepositoryISRMontoRetencion
        GridView1.Columns("ISRPercibido").ColumnEdit = RepositoryISRPercibido
        GridView1.Columns("ImpuestoSelectivoC").ColumnEdit = RepositoryISCTotal
        GridView1.Columns("OtrosImpuestos").ColumnEdit = RepositoryOtrosImpuestos
        GridView1.Columns("MontoPropinaLegal").ColumnEdit = RepositoryPropinalLegal
        GridView1.Columns("Actualizar").ColumnEdit = RepositoryActualizar
        GridView1.Columns("MonedaImagen").ColumnEdit = RepositoryCurrency
        GridView1.Columns("Tasa").ColumnEdit = RepositoryTasa

        'Propiedades
        GridView1.Columns("ID606Detalle").Visible = False
        GridView1.Columns("ID606Detalle").OptionsColumn.AllowEdit = False
        GridView1.Columns("ID606Detalle").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDCompra").Visible = False
        GridView1.Columns("IDCompra").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDCompra").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDCompra").Caption = "Código del documento"
        GridView1.Columns("IDCompra").Width = 100
        GridView1.Columns("SecondID").Visible = False
        GridView1.Columns("SecondID").OptionsColumn.AllowEdit = False
        GridView1.Columns("SecondID").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDTipoDocumento").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDTipoDocumento").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDTipoDocumento").Caption = "ID del tipo de documento"
        GridView1.Columns("IDTipoDocumento").Visible = False
        GridView1.Columns("IDTipoDocumento").Width = 100
        GridView1.Columns("TipoDocumento").Caption = "Tipo del documento"
        GridView1.Columns("TipoDocumento").Visible = False
        GridView1.Columns("TipoDocumento").OptionsColumn.AllowEdit = False
        GridView1.Columns("TipoDocumento").OptionsColumn.ReadOnly = True
        GridView1.Columns("TipoDocumento").Width = 160
        GridView1.Columns("IDSuplidor").Visible = False
        GridView1.Columns("IDSuplidor").Caption = "Código del suplidor"
        GridView1.Columns("IDSuplidor").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDSuplidor").OptionsColumn.ReadOnly = True
        GridView1.Columns("Suplidor").Visible = False
        GridView1.Columns("Suplidor").OptionsColumn.AllowEdit = False
        GridView1.Columns("Suplidor").OptionsColumn.ReadOnly = True
        GridView1.Columns("RNC").Width = 100
        GridView1.Columns("RNC").OptionsColumn.AllowEdit = False
        GridView1.Columns("RNC").OptionsColumn.ReadOnly = True
        GridView1.Columns("TipoID").Caption = "Tipo RNC"
        GridView1.Columns("TipoID").Width = 60
        GridView1.Columns("TipoID").OptionsColumn.AllowEdit = False
        GridView1.Columns("TipoID").OptionsColumn.ReadOnly = True
        GridView1.Columns("TipoBienes").Caption = "Tipo bienes y servicios comprados"
        GridView1.Columns("TipoBienes").Width = 400
        GridView1.Columns("IDTipoComprobanteFiscal").Caption = "Código del comprobante fiscal"
        GridView1.Columns("IDTipoComprobanteFiscal").Visible = False
        GridView1.Columns("IDTipoComprobanteFiscal").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDTipoComprobanteFiscal").OptionsColumn.ReadOnly = True
        GridView1.Columns("TipoComprobanteFiscal").Visible = False
        GridView1.Columns("TipoComprobanteFiscal").Caption = "Tipo de Comprobante"
        GridView1.Columns("TipoComprobanteFiscal").OptionsColumn.AllowEdit = False
        GridView1.Columns("TipoComprobanteFiscal").OptionsColumn.ReadOnly = True
        GridView1.Columns("NCF").Width = 130
        GridView1.Columns("NCF").OptionsColumn.AllowEdit = False
        GridView1.Columns("NCF").OptionsColumn.ReadOnly = True
        GridView1.Columns("NCFModificado").Caption = "NCF ó documento modificado"
        GridView1.Columns("NCFModificado").Width = 130
        GridView1.Columns("NCFModificado").OptionsColumn.AllowEdit = False
        GridView1.Columns("NCFModificado").OptionsColumn.ReadOnly = True
        GridView1.Columns("Moneda").OptionsColumn.AllowEdit = False
        GridView1.Columns("Moneda").OptionsColumn.ReadOnly = True
        GridView1.Columns("MonedaImagen").OptionsColumn.AllowEdit = False
        GridView1.Columns("MonedaImagen").OptionsColumn.ReadOnly = True
        GridView1.Columns("MonedaImagen").Width = 220
        GridView1.Columns("MonedaImagen").Caption = "Moneda en registro"
        GridView1.Columns("Tasa").OptionsColumn.AllowEdit = False
        GridView1.Columns("Tasa").OptionsColumn.ReadOnly = True

        GridView1.Columns("Fecha").Visible = False
        GridView1.Columns("Fecha").OptionsColumn.AllowEdit = False
        GridView1.Columns("Fecha").OptionsColumn.ReadOnly = True
        GridView1.Columns("AnoMes").Caption = "Año/Mes"
        GridView1.Columns("AnoMes").OptionsColumn.AllowEdit = False
        GridView1.Columns("AnoMes").OptionsColumn.ReadOnly = True
        GridView1.Columns("AnoMes").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridView1.Columns("AnoMes").Width = 70
        GridView1.Columns("FechaDia").Caption = "Día"
        GridView1.Columns("FechaDia").Width = 35
        GridView1.Columns("FechaDia").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridView1.Columns("FechaDia").OptionsColumn.AllowEdit = False
        GridView1.Columns("FechaDia").OptionsColumn.ReadOnly = True

        GridView1.Columns("MontoFacturaServicios").Caption = "Monto facturado en servicios"
        GridView1.Columns("MontoFacturaServicios").Width = 120
        GridView1.Columns("MontoFacturaServicios").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("MontoFacturaServicios").DisplayFormat.FormatString = "C2"
        GridView1.Columns("MontoFacturaServicios").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoFacturaServicios", "{0:c2}")
        GridView1.Columns("MontoFacturaBienes").Caption = "Monto facturado en bienes"
        GridView1.Columns("MontoFacturaBienes").Width = 120
        GridView1.Columns("MontoFacturaBienes").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("MontoFacturaBienes").DisplayFormat.FormatString = "C2"
        GridView1.Columns("MontoFacturaBienes").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoFacturaBienes", "{0:c2}")
        GridView1.Columns("MontoFacturadoTotal").Caption = "Total monto facturado"
        GridView1.Columns("MontoFacturadoTotal").Width = 120
        GridView1.Columns("MontoFacturadoTotal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("MontoFacturadoTotal").DisplayFormat.FormatString = "C2"
        GridView1.Columns("MontoFacturadoTotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoFacturadoTotal", "{0:c2}")
        GridView1.Columns("ItbisFacturado").Caption = "ITBIS Facturado"
        GridView1.Columns("ItbisFacturado").Width = 120
        GridView1.Columns("ItbisFacturado").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisFacturado").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisFacturado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisFacturado", "{0:c2}")

        GridView1.Columns("ItbisRetenido").Caption = "ITBIS Retenido"
        GridView1.Columns("ItbisRetenido").Width = 120
        GridView1.Columns("ItbisRetenido").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisRetenido").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisRetenido").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisRetenido", "{0:c2}")

        GridView1.Columns("ItbisProporcionalidad").Caption = "ITBIS sujeto a Proporcionalidad"
        GridView1.Columns("ItbisProporcionalidad").Width = 120
        GridView1.Columns("ItbisProporcionalidad").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisProporcionalidad").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisProporcionalidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisProporcionalidad", "{0:c2}")

        GridView1.Columns("ItbisalCosto").Caption = "ITBIS llevado al costo"
        GridView1.Columns("ItbisalCosto").Width = 120
        GridView1.Columns("ItbisalCosto").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisalCosto").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisalCosto").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisalCosto", "{0:c2}")

        GridView1.Columns("ItbisporAdelantar").Caption = "ITBIS por adelantar"
        GridView1.Columns("ItbisporAdelantar").Width = 120
        GridView1.Columns("ItbisporAdelantar").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisporAdelantar").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisporAdelantar").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisporAdelantar", "{0:c2}")

        GridView1.Columns("ItbisPercibidoenCompras").Caption = "ITBIS percibido en compras"
        GridView1.Columns("ItbisPercibidoenCompras").Width = 120
        GridView1.Columns("ItbisPercibidoenCompras").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisPercibidoenCompras").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisPercibidoenCompras").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisPercibidoenCompras", "{0:c2}")

        GridView1.Columns("TipodeISR").Caption = "Tipo de retención en ISR"
        GridView1.Columns("TipodeISR").Width = 160


        GridView1.Columns("MontoRetencion").Caption = "Monto retención renta"
        GridView1.Columns("MontoRetencion").Width = 120
        GridView1.Columns("MontoRetencion").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("MontoRetencion").DisplayFormat.FormatString = "C2"
        GridView1.Columns("MontoRetencion").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoRetencion", "{0:c2}")


        GridView1.Columns("ISRPercibido").Caption = "ISR Percibido en compras"
        GridView1.Columns("ISRPercibido").Width = 120
        GridView1.Columns("ISRPercibido").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ISRPercibido").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ISRPercibido").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ISRPercibido", "{0:c2}")

        GridView1.Columns("ImpuestoSelectivoC").Caption = "Impuesto selectivo al consumo"
        GridView1.Columns("ImpuestoSelectivoC").Width = 120
        GridView1.Columns("ImpuestoSelectivoC").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ImpuestoSelectivoC").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ImpuestoSelectivoC").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ImpuestoSelectivoC", "{0:c2}")

        GridView1.Columns("OtrosImpuestos").Caption = "Otros impuestos / Tasas"
        GridView1.Columns("OtrosImpuestos").Width = 120
        GridView1.Columns("OtrosImpuestos").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("OtrosImpuestos").DisplayFormat.FormatString = "C2"
        GridView1.Columns("OtrosImpuestos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "OtrosImpuestos", "{0:c2}")

        GridView1.Columns("MontoPropinaLegal").Caption = "Monto propinal legal"
        GridView1.Columns("MontoPropinaLegal").Width = 120
        GridView1.Columns("MontoPropinaLegal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("MontoPropinaLegal").DisplayFormat.FormatString = "C2"
        GridView1.Columns("MontoPropinaLegal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoPropinaLegal", "{0:c2}")

        GridView1.Columns("FormaPago").Caption = "Forma de pago"
        GridView1.Columns("FormaPago").Width = 200

        GridView1.Columns("Estatus").Caption = "Estado del registro"
        GridView1.Columns("Estatus").Width = 300
        GridView1.Columns("Estatus").OptionsColumn.ReadOnly = True
        GridView1.Columns("Estatus").OptionsColumn.AllowEdit = False

        GridView1.Columns("Tasa").Width = 60
        GridView1.Columns("Tasa").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Tasa").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Tasa").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoPropinaLegal", "{0:c2}")

        GridView1.Columns("Moneda").Visible = False
    End Sub

    Private Sub LimpiarDatos()
        ID606 = ""
        txtCantidadRegistros.Clear()
        cbxPeriodo.Items.Clear()
        TablaCompras.Rows.Clear()
        txtSecondID.Text = ""
        txtSecondID.Tag = ""
        lblStatus.Text = "SIN PROCESAR"
        lblStatus.ForeColor = Color.Firebrick
        TileBarItem5.Visible = False
    End Sub

    Private Sub Actualizar()
        FillPeriodos()
        cbxPeriodo.Enabled = True
    End Sub

    Private Sub FillTipoGasto()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDGasto,TipoGasto FROM libregco.tipogasto", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipogasto")
        ConLibregco.Close()

        Dim TablaGastos As DataTable = dstemp.Tables("tipogasto")
        RepositoryTipoGasto.DataSource = TablaGastos
        RepositoryTipoGasto.ValueMember = "IDGasto"
        RepositoryTipoGasto.DisplayMember = "TipoGasto"
        RepositoryTipoGasto.PopulateColumns()
        RepositoryTipoGasto.Columns(RepositoryTipoGasto.ValueMember).Visible = False
    End Sub

    Private Sub FillTipoRetencion()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idRetencionISR,TipoRetencion FROM libregco.RetencionISR where Nulo=0 order by idRetencionISR ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "RetencionISR")
        ConLibregco.Close()

        Dim tablaRetencion As DataTable = dstemp.Tables("RetencionISR")
        RepositoryTipoRetencion.DataSource = tablaRetencion
        RepositoryTipoRetencion.ValueMember = "idRetencionISR"
        RepositoryTipoRetencion.DisplayMember = "TipoRetencion"
        RepositoryTipoRetencion.PopulateColumns()
        RepositoryTipoRetencion.Columns(RepositoryTipoRetencion.ValueMember).Visible = False
    End Sub

    Private Sub FillTipoPago()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idTipoPago606,TipoPago FROM libregco.TipoPago606 where Nulo=0 order by idTipoPago606 ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "TipoPago606")
        ConLibregco.Close()

        Dim tablaTipoPago As DataTable = dstemp.Tables("TipoPago606")

        RepositoryTipoPago.DataSource = tablaTipoPago
        RepositoryTipoPago.ValueMember = "idTipoPago606"
        RepositoryTipoPago.DisplayMember = "TipoPago"
        RepositoryTipoPago.PopulateColumns()
        RepositoryTipoPago.Columns(RepositoryTipoPago.ValueMember).Visible = False
    End Sub

    Private Sub RefrescarTabla()
        Try
            If cbxPeriodo.Text <> "" Then
                Dim ds As New DataSet

                TablaCompras.Rows.Clear()

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDCompra,Compras.SecondID,Compras.IDTipoDocumento,TipoDocumento.Documento,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.RNC,Suplidor.IDTipoIdentificacion,Compras.IDTipoGasto,TipoGasto.TipoGasto,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Compras.NCF,Compras.NCFModificado,Compras.FechaFactura,DATE_FORMAT(Compras.FechaFactura,'%Y%m') as AnoMes,DATE_FORMAT(Compras.FechaFactura,'%d') as Dia,SubtotalBienes,SubtotalServicios,(Subtotalbienes+SubtotalServicios) as MontoFacturadoTotal,ItbisFacturado,ItbisRetenido,ItbisProporcionalidad,ItbisalCosto,ItbisAdelantar,ItbisPercibidoenCompras,IDISRTipoRetencion,RetencionISR.TipoRetencion,ISRMontoRetencion,ISRPercibido,ISCTotal,OtrosImpuestos,PropinaLegal,Compras.IDTipoPago,TipoPago606.TipoPago,Compras.IDMoneda,TipoMoneda.Texto,TipoMoneda.MonedaImagen,Compras.Tasa from" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER Join Libregco.TipoIdentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER Join" & SysName.Text & "TipoDocumento on Compras.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER Join Libregco.TipoGasto on Compras.IDTipoGasto=TipoGasto.IDGasto INNER JOIN Libregco.TipoPago606 on Compras.IDTipoPago=TipoPago606.idTipoPago606 INNER JOIN Libregco.TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.RetencionISR on Compras.IDISRTipoRetencion=RetencionISR.idRetencionISR Where DATE_FORMAT(Compras.FechaFactura,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and Compras.Nulo=0 UNION ALL SELECT IDDevolucionCompra,DevolucionCompra.SecondID,DevolucionCompra.IDTipoDocumento,TipoDocumento.Documento,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.RNC,Suplidor.IDTipoIdentificacion,9 as IDTipoGasto,'09-COMPRAS Y GASTOS QUE FORMARAN PARTE DEL COSTO DE VENTA' as TipoGasto,4 as IDComprobanteFiscal,'Notas de Crédito' as TipoComprobante,DevolucionCompra.NCF,Compras.NCF as NCFModificado,DevolucionCompra.Fecha,DATE_FORMAT(DevolucionCompra.Fecha,'%Y%m'),DATE_FORMAT(DevolucionCompra.Fecha,'%d'),DevolucionCompra.Neto,0,DevolucionCompra.Neto,DevolucionCompra.Itbis,0,0,0,0,0,1,'',0,0,0,0,0,7,'06 - NOTA DE CRÉDITO',Compras.IDMoneda,TipoMoneda.Texto,TipoMoneda.MonedaImagen,Compras.Tasa from" & SysName.Text & "DevolucionCompra INNER JOIN" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN" & SysName.Text & "TipoDocumento on DevolucionCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor Where DATE_FORMAT(DevolucionCompra.Fecha,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and DevolucionCompra.Nulo=0", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "Compras")
                ConMixta.Close()

                Dim TB As DataTable = ds.Tables("Compras")

                For Each itm As DataRow In TB.Rows
                    TablaCompras.Rows.Add("", itm.Item("IDCompra"), itm.Item("SecondID"), itm.Item("IDTipoDocumento"), itm.Item("Documento"), itm.Item("IDSuplidor"), itm.Item("Suplidor"), itm.Item("RNC").ToString.Replace("-", ""), itm.Item("IDTipoIdentificacion"), itm.Item("IDTipoGasto"), itm.Item("IDComprobanteFiscal"), itm.Item("TipoComprobante"), itm.Item("NCF"), itm.Item("NCFModificado"), CDate(itm.Item("FechaFactura")).ToString("dd/MM/yyyy"), itm.Item("AnoMes"), itm.Item("Dia"), CDbl(itm.Item("SubtotalBienes")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("SubtotalServicios")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("MontoFacturadoTotal")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ItbisFacturado")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ItbisRetenido")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ItbisProporcionalidad")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ItbisalCosto")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ItbisAdelantar")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ItbisPercibidoenCompras")) * CDbl(itm.Item("Tasa")), itm.Item("IDISRTipoRetencion"), CDbl(itm.Item("ISRMontoRetencion")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ISRPercibido")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ISCTotal")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("OtrosImpuestos")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("PropinaLegal")) * CDbl(itm.Item("Tasa")), itm.Item("IDTipoPago"), "", "", itm.Item("Texto"), itm.Item("IDMoneda"), itm.Item("Tasa"))
                Next

                SumarRows()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SumarRows()
        txtCantidadRegistros.Text = TablaCompras.Rows.Count
    End Sub

    Private Sub FillPeriodos()
        Try
            Dim dstemp As New DataSet

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT DATE_FORMAT(FechaFactura,'%Y%m') as Fecha FROM" & SysName.Text & "compras GROUP BY DATE_FORMAT(FechaFactura,'%Y%m') ORDER BY DATE_FORMAT(FechaFactura,'%Y%m') DESC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "compras")
            cbxPeriodo.Items.Clear()
            ConMixta.Close()

            Dim Tabla As DataTable = dstemp.Tables("compras")
            For Each Fila As DataRow In Tabla.Rows
                cbxPeriodo.Items.Add(Fila.Item("Fecha"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se encontraron períodos hábiles en la base de datos. Inserte registros de compras para procesar el formato 606.", "No se encontraron registros de compras 606", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub


    Private Sub cbxPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPeriodo.SelectedIndexChanged
        TablaCompras.Rows.Clear()

        If cbxPeriodo.Text <> "" Then
            Dim dstemp As New DataSet

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT id606,Envio606.IDTipoDocumento,TipoDocumento.Documento,envio606.SecondID,envio606.IDEquipo,AreaImpresion.ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,envio606.IDUsuario,Usuarios.Nombre as NombreUsuario,envio606.Fecha,envio606.Modificacion,envio606.Periodo,envio606.CantRegistros FROM" & SysName.Text & "envio606 INNER JOIN" & SysName.Text & "TipoDocumento on envio606.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "AreaImpresion on envio606.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Empleados as Usuarios on envio606.IDUsuario=Usuarios.IDEmpleado where envio606.Periodo='" + cbxPeriodo.Text.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "envio606")
            ConMixta.Close()

            Dim TB As DataTable = dstemp.Tables("envio606")

            If TB.Rows.Count = 0 Then
                RefrescarTabla()
                TileBarItem5.Visible = False
            Else
                cbxPeriodo.Enabled = False

                txtSecondID.Text = TB.Rows(0).Item("SecondID")
                txtSecondID.Tag = TB.Rows(0).Item("id606")
                lblStatus.Text = "PROCESADA"
                lblStatus.ForeColor = Color.Green
                txtCantidadRegistros.Text = TB.Rows(0).Item("CantRegistros")

                Dim ds As New DataSet

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT id606_Detalles,envio606_detalles.IDCompra,Compras.SecondID,Compras.IDTipoDocumento,TipoDocumento.Documento,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.RNC,Suplidor.IDTipoIdentificacion,Compras.IDTipoGasto,TipoGasto.TipoGasto,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Compras.NCF,Compras.NCFModificado,Compras.FechaFactura,DATE_FORMAT(Compras.FechaFactura,'%Y%m') as AnoMes,DATE_FORMAT(Compras.FechaFactura,'%d') as Dia,SubtotalBienes,SubtotalServicios,(Subtotalbienes+SubtotalServicios) as MontoFacturadoTotal,ItbisFacturado,ItbisRetenido,ItbisProporcionalidad,ItbisalCosto,ItbisAdelantar,ItbisPercibidoenCompras,IDISRTipoRetencion,RetencionISR.TipoRetencion,ISRMontoRetencion,ISRPercibido,ISCTotal,OtrosImpuestos,PropinaLegal,Compras.IDTipoPago,TipoPago606.TipoPago,Estatus,Compras.IDMoneda,TipoMoneda.Texto,TipoMoneda.MonedaImagen,Compras.Tasa from" & SysName.Text & "envio606_detalles INNER JOIN" & SysName.Text & "Envio606 on envio606_detalles.ID606=Envio606.id606 INNER JOIN" & SysName.Text & "Compras on Envio606_detalles.IDCompra=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER Join Libregco.TipoIdentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER Join" & SysName.Text & "TipoDocumento on Compras.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER Join Libregco.TipoGasto on Compras.IDTipoGasto=TipoGasto.IDGasto INNER JOIN Libregco.TipoPago606 on Compras.IDTipoPago=TipoPago606.idTipoPago606 INNER JOIN Libregco.RetencionISR on Compras.IDISRTipoRetencion=RetencionISR.idRetencionISR INNER JOIN" & SysName.Text & "TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda Where envio606.Periodo='" + cbxPeriodo.Text.ToString + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "envio606_detalles")
                ConMixta.Close()

                Dim TBa As DataTable = ds.Tables("envio606_detalles")

                For Each itm As DataRow In TBa.Rows
                    TablaCompras.Rows.Add(itm.Item("id606_Detalles"), itm.Item("IDCompra"), itm.Item("SecondID"), itm.Item("IDTipoDocumento"), itm.Item("Documento"), itm.Item("IDSuplidor"), itm.Item("Suplidor"), itm.Item("RNC").ToString.Replace("-", ""), itm.Item("IDTipoIdentificacion"), itm.Item("IDTipoGasto"), itm.Item("IDComprobanteFiscal"), itm.Item("TipoComprobante"), itm.Item("NCF"), itm.Item("NCFModificado"), CDate(itm.Item("FechaFactura")).ToString("dd/MM/yyyy"), itm.Item("AnoMes"), itm.Item("Dia"), itm.Item("SubtotalBienes"), itm.Item("SubtotalServicios"), itm.Item("MontoFacturadoTotal"), itm.Item("ItbisFacturado"), itm.Item("ItbisRetenido"), itm.Item("ItbisProporcionalidad"), itm.Item("ItbisalCosto"), itm.Item("ItbisAdelantar"), itm.Item("ItbisPercibidoenCompras"), itm.Item("IDISRTipoRetencion"), itm.Item("ISRMontoRetencion"), itm.Item("ISRPercibido"), itm.Item("ISCTotal"), itm.Item("OtrosImpuestos"), itm.Item("PropinaLegal"), itm.Item("IDTipoPago"), itm.Item("Estatus"), "", itm.Item("Texto"), itm.Item("IDMoneda"), itm.Item("Tasa"))
                Next

                SumarRows()

                TileBarItem5.Visible = True
            End If

        End If

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

    Private Sub TileBarItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem3.ItemClick
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

    Private Sub TileBarItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem2.ItemClick
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la línea " & CInt(GridView1.FocusedRowHandle.ToString) + 1 & " de la tabla?", "Eliminar la fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            If GridView1.GetFocusedRowCellValue("ID606Detalle").ToString = "" Then
                Dim iterateIndex1 As Integer = 0
                Dim newDataTable1 As DataTable = TablaCompras.Copy
                For Each itm As DataRow In newDataTable1.Rows
                    If itm.Item("IDCompra") = GridView1.GetFocusedRowCellValue("IDCompra").ToString Then
                        TablaCompras.Rows.RemoveAt(iterateIndex1)
                        Exit For
                    Else
                        iterateIndex1 += 1
                    End If
                Next
                newDataTable1.Dispose()
            Else

                Con.Open()
                cmd = New MySqlCommand("Delete from envio606_detalles Where id606_Detalles='" + GridView1.GetFocusedRowCellValue("ID606Detalle").ToString + "'", Con)
                cmd.ExecuteNonQuery()
                Con.Close()

                Dim iterateIndex1 As Integer = 0
                Dim newDataTable1 As DataTable = TablaCompras.Copy
                For Each itm As DataRow In newDataTable1.Rows
                    If itm.Item("IDCompra") = GridView1.GetFocusedRowCellValue("IDCompra").ToString Then
                        TablaCompras.Rows.RemoveAt(iterateIndex1)
                        Exit For
                    Else
                        iterateIndex1 += 1
                    End If
                Next
                newDataTable1.Dispose()
            End If



            SumarRows()
        End If

    End Sub

    Private Sub TileBarItem6_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem6.ItemClick
        If txtSecondID.Text = "" Then
            If TablaCompras.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    Actualizar()
                End If
            Else
                LimpiarDatos()
                Actualizar()
            End If
        Else
            LimpiarDatos()
            Actualizar()
        End If


    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.RowHandle >= 0 Then
            If GridView1.FocusedColumn.FieldName = "Actualizar" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea actualizar el registro seleccionado {Ubicación: " & CInt(GridView1.FocusedRowHandle.ToString) + 1 & "} de la tabla en el registro de compras?", "Actualizar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConMixta.Open()
                    cmd = New MySqlCommand("UPDATE" & SysName.Text & "Compras SET IDTipoGasto='" + GridView1.GetFocusedRowCellValue("TipoBienes").ToString + "',SubtotalLlenado=1,SubtotalBienes='" + CDbl(GridView1.GetFocusedRowCellValue("MontoFacturaBienes")).ToString + "',SubtotalServicios='" + CDbl(GridView1.GetFocusedRowCellValue("MontoFacturaServicios")).ToString + "',ItbisFacturado='" + CDbl(GridView1.GetFocusedRowCellValue("ItbisFacturado")).ToString + "',ItbisRetenido='" + CDbl(GridView1.GetFocusedRowCellValue("ItbisRetenido")).ToString + "',ItbisProporcionalidad='" + CDbl(GridView1.GetFocusedRowCellValue("ItbisProporcionalidad")).ToString + "',ItbisalCosto='" + CDbl(GridView1.GetFocusedRowCellValue("ItbisalCosto")).ToString + "',ItbisAdelantar='" + CDbl(GridView1.GetFocusedRowCellValue("ItbisporAdelantar")).ToString + "',ItbisPercibidoenCompras='" + CDbl(GridView1.GetFocusedRowCellValue("ItbisPercibidoenCompras")).ToString + "',IDISRTipoRetencion='" + GridView1.GetFocusedRowCellValue("TipodeISR").ToString + "',OtrosImpuestos='" + CDbl(GridView1.GetFocusedRowCellValue("OtrosImpuesto")).ToString + "',ISRPercibido='" + CDbl(GridView1.GetFocusedRowCellValue("ISRPercibido")).ToString + "',ISRMontoRetencion='" + CDbl(GridView1.GetFocusedRowCellValue("MontoRetencion")).ToString + "',PropinaLegal='" + CDbl(GridView1.GetFocusedRowCellValue("MontoPropinaLegal")).ToString + "',IDTipoPago='" + GridView1.GetFocusedRowCellValue("FormaPago").ToString + "' WHERE IDCompra= (" + GridView1.GetFocusedRowCellValue("IDCompra").ToString + ")", ConMixta)
                    cmd.ExecuteNonQuery()
                    ConMixta.Close()

                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
                End If
            End If
        End If
    End Sub


    Private Sub GuardarDatos()
        Try
            ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            ConMixta.Close()
        End Try
    End Sub

    Private Sub TileBarItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem1.ItemClick
        If GridView1.RowCount > 0 Then
            If txtSecondID.Tag.ToString = "" Then

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea procesar el formulario de envío de compras de bienes y servicios 606 correspondiente al período " & cbxPeriodo.Text & "?", "Generar formulario 606", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then

                    ActualizarCompras
                    sqlQ = "INSERT INTO" & SysName.Text & "Envio606 (SecondID,IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Modificacion,Periodo,CantRegistros) VALUES ('" + GetSecondID(60).ToString + "','60', '" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',NOW(),NOW(),'" + cbxPeriodo.Text + "','" + txtCantidadRegistros.Text + "')"
                    GuardarDatos()
                    Ult606()
                    InsertDetalles()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))



                End If

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea actualizar el formulario de envío de compras de bienes y servicios 606 correspondiente al período " & cbxPeriodo.Text & "?", "Actualizar formulario 606", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ActualizarCompras
                    sqlQ = "UPDATE" & SysName.Text & "Envio606 SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Modificacion=CURDATE(),CantRegistros='" + txtCantidadRegistros.Text + "' WHERE id606='" + txtSecondID.Tag.ToString + "')"
                    GuardarDatos()
                    InsertDetalles()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(2))
                End If
            End If
        End If

    End Sub

    Private Sub ActualizarCompras()
        ConMixta.Open()

        For Each rw As DataRow In TablaCompras.Rows
            cmd = New MySqlCommand("UPDATE" & SysName.Text & "Compras SET IDTipoGasto='" + rw.Item("TipoBienes").ToString + "',SubtotalLlenado=1,SubtotalBienes='" + CDbl(rw.Item("MontoFacturaBienes")).ToString + "',SubtotalServicios='" + CDbl(rw.Item("MontoFacturaServicios")).ToString + "',ItbisFacturado='" + CDbl(rw.Item("ItbisFacturado")).ToString + "',ItbisRetenido='" + CDbl(rw.Item("ItbisRetenido")).ToString + "',ItbisProporcionalidad='" + CDbl(rw.Item("ItbisProporcionalidad")).ToString + "',ItbisalCosto='" + CDbl(rw.Item("ItbisalCosto")).ToString + "',ItbisAdelantar='" + CDbl(rw.Item("ItbisporAdelantar")).ToString + "',ItbisPercibidoenCompras='" + CDbl(rw.Item("ItbisPercibidoenCompras")).ToString + "',IDISRTipoRetencion='" + rw.Item("TipodeISR").ToString + "',OtrosImpuestos='" + CDbl(rw.Item("OtrosImpuestos")).ToString + "',ISRPercibido='" + CDbl(rw.Item("ISRPercibido")).ToString + "',ISRMontoRetencion='" + CDbl(rw.Item("MontoRetencion")).ToString + "',PropinaLegal='" + CDbl(rw.Item("MontoPropinaLegal")).ToString + "',IDTipoPago='" + rw.Item("FormaPago").ToString + "' WHERE IDCompra= (" + rw.Item("IDCompra").ToString + ")", ConMixta)
            cmd.ExecuteNonQuery()
        Next
        ConMixta.Close()
    End Sub

    Private Sub InsertDetalles()
        Con.Open()

        For Each Row As DataRow In TablaCompras.Rows
            If Row.Item("ID606Detalle").ToString = "" Then

                cmd = New MySqlCommand("INSERT INTO" & SysName.Text & "envio606_detalles (ID606,IDCompra,Estatus) VALUES ('" + txtSecondID.Tag.ToString + "','" + Row.Item("IDCompra").ToString + "','" + Row.Item("Estatus").ToString + "')", Con)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select id606_Detalles from envio606_detalles where id606_Detalles=(Select Max(id606_Detalles) from envio606_detalles)", Con)
                Row.Item(0) = Convert.ToString(cmd.ExecuteScalar())

            Else

                cmd = New MySqlCommand("UPDATE" & SysName.Text & "envio606_detalles SET ID606='" + txtSecondID.Tag.ToString + "',IDCompra='" + Row.Item("IDCompra").ToString + "',Estatus='" + Row.Item("Estatus").ToString + "' Where id606_Detalles='" + Row.Item("ID606Detalle").ToString + "'", Con)
                cmd.ExecuteNonQuery()

            End If
        Next

        Con.Close()
    End Sub

    Private Sub Ult606()
        Try

            If txtSecondID.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select id606 from" & SysName.Text & "Envio606 where id606= (Select Max(id606) from Envio606)", Con)
                txtSecondID.Tag = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select SecondID from" & SysName.Text & "Envio606 where id606= (Select Max(id606) from Envio606)", Con)
                txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())

                lblStatus.Text = "PROCESADO"
                lblStatus.ForeColor = Color.DarkSeaGreen
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Private Sub TileBarItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem4.ItemClick
        If GridView1.FocusedRowHandle >= 0 Then
            If GridView1.GetFocusedRowCellValue("IDTipoDocumento") = 6 Then
                Dim PermisosConsultaCompras As New ArrayList
                PermisosConsultaCompras = PasarPermisos(53)

                If PermisosConsultaCompras(0) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para acceder al formulario de consulta de compras.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    If frm_consulta_compras.Visible = True Then
                        frm_consulta_compras.Close()
                    End If

                    frm_consulta_compras.Show(Me)

                    frm_consulta_compras.txtFechaInicial.Value = CDate(GridView1.GetFocusedRowCellValue("Fecha"))
                    frm_consulta_compras.txtFechaFinal.Value = CDate(GridView1.GetFocusedRowCellValue("Fecha"))
                    frm_consulta_compras.txtIDSuplidor.Text = GridView1.GetFocusedRowCellValue("IDSuplidor")
                    frm_consulta_compras.txtSuplidor.Text = GridView1.GetFocusedRowCellValue("Suplidor")
                    frm_consulta_compras.txtIDTipoComprobante.Text = GridView1.GetFocusedRowCellValue("IDTipoComprobanteFiscal")
                    frm_consulta_compras.txtComprobanteFiscal.Text = GridView1.GetFocusedRowCellValue("TipoComprobanteFiscal")
                    frm_consulta_compras.LookingForIDCompra = GridView1.GetFocusedRowCellValue("IDCompra")

                    frm_consulta_compras.btnBuscarCons.PerformClick()
                End If
            End If
        End If
    End Sub


    Private Sub TileBarItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem5.ItemClick
        Dim RegistrosActualizados = 0
        Dim ds As New DataSet

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDCompra,Compras.SecondID,Compras.IDTipoDocumento,TipoDocumento.Documento,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.RNC,Suplidor.IDTipoIdentificacion,Compras.IDTipoGasto,TipoGasto.TipoGasto,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Compras.NCF,Compras.NCFModificado,Compras.FechaFactura,DATE_FORMAT(Compras.FechaFactura,'%Y%m') as AnoMes,DATE_FORMAT(Compras.FechaFactura,'%d') as Dia,SubtotalBienes,SubtotalServicios,(Subtotalbienes+SubtotalServicios) as MontoFacturadoTotal,ItbisFacturado,ItbisRetenido,ItbisProporcionalidad,ItbisalCosto,ItbisAdelantar,ItbisPercibidoenCompras,IDISRTipoRetencion,RetencionISR.TipoRetencion,ISRMontoRetencion,ISRPercibido,ISCTotal,OtrosImpuestos,PropinaLegal,Compras.IDTipoPago,TipoPago606.TipoPago from" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER Join Libregco.TipoIdentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER Join" & SysName.Text & "TipoDocumento on Compras.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER Join Libregco.TipoGasto on Compras.IDTipoGasto=TipoGasto.IDGasto INNER JOIN Libregco.TipoPago606 on Compras.IDTipoPago=TipoPago606.idTipoPago606 INNER JOIN Libregco.RetencionISR on Compras.IDISRTipoRetencion=RetencionISR.idRetencionISR Where DATE_FORMAT(Compras.FechaFactura,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and Compras.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "Compras")
        ConMixta.Close()

        Dim TB As DataTable = ds.Tables("Compras")

        For Each row As DataRow In TB.Rows
            Dim Founded As Boolean = False
            For Each itm As DataRow In TablaCompras.Rows
                If row.Item("IDCompra") = itm.Item("IDCompra") Then
                    itm.Item("RNC") = row.Item("RNC").ToString.Replace("-", "")
                    itm.Item("TipoBienes") = row.Item("IDTipoGasto")
                    itm.Item("IDTipoComprobanteFiscal") = row.Item("IDComprobanteFiscal")
                    itm.Item("TipoComprobanteFiscal") = row.Item("TipoComprobante")
                    itm.Item("NCF") = row.Item("NCF")
                    itm.Item("NCFModificado") = row.Item("NCFModificado")
                    itm.Item("Fecha") = CDate(row.Item("FechaFactura")).ToString("dd/MM/yyyy")
                    itm.Item("AnoMes") = row.Item("AnoMes")
                    itm.Item("FechaDia") = row.Item("Dia")
                    itm.Item("MontoFacturaBienes") = row.Item("SubtotalBienes")
                    itm.Item("MontoFacturaServicios") = row.Item("SubtotalServicios")
                    itm.Item("MontoFacturadoTotal") = row.Item("MontoFacturadoTotal")
                    itm.Item("ItbisFacturado") = row.Item("ItbisFacturado")
                    itm.Item("ItbisRetenido") = row.Item("ItbisRetenido")
                    itm.Item("ItbisProporcionalidad") = row.Item("ItbisProporcionalidad")
                    itm.Item("ItbisalCosto") = row.Item("ItbisalCosto")
                    itm.Item("ItbisporAdelantar") = row.Item("ItbisAdelantar")
                    itm.Item("ItbisPercibidoenCompras") = row.Item("ItbisPercibidoenCompras")
                    itm.Item("TipodeISR") = row.Item("IDISRTipoRetencion")
                    itm.Item("MontoRetencion") = row.Item("ISRMontoRetencion")
                    itm.Item("ISRPercibido") = row.Item("ISRPercibido")
                    itm.Item("ImpuestoSelectivoC") = row.Item("ISCTotal")
                    itm.Item("OtrosImpuestos") = row.Item("OtrosImpuestos")
                    itm.Item("MontoPropinaLegal") = row.Item("PropinaLegal")
                    itm.Item("FormaPago") = row.Item("IDTipoPago")
                    Founded = True
                    Exit For
                End If
            Next

            If Founded = False Then
                RegistrosActualizados += 1
                TablaCompras.Rows.Add("", row.Item("IDCompra"), row.Item("SecondID"), row.Item("IDTipoDocumento"), row.Item("Documento"), row.Item("IDSuplidor"), row.Item("Suplidor"), row.Item("RNC").ToString.Replace("-", ""), row.Item("IDTipoIdentificacion"), row.Item("IDTipoGasto"), row.Item("IDComprobanteFiscal"), row.Item("TipoComprobante"), row.Item("NCF"), row.Item("NCFModificado"), CDate(row.Item("FechaFactura")).ToString("dd/MM/yyyy"), row.Item("AnoMes"), row.Item("Dia"), row.Item("SubtotalBienes"), row.Item("SubtotalServicios"), row.Item("MontoFacturadoTotal"), row.Item("ItbisFacturado"), row.Item("ItbisRetenido"), row.Item("ItbisProporcionalidad"), row.Item("ItbisalCosto"), row.Item("ItbisAdelantar"), row.Item("ItbisPercibidoenCompras"), row.Item("IDISRTipoRetencion"), row.Item("ISRMontoRetencion"), row.Item("ISRPercibido"), row.Item("ISCTotal"), row.Item("OtrosImpuestos"), row.Item("PropinaLegal"), row.Item("IDTipoPago"), "Nuevo resultado")
            End If

        Next

        If RegistrosActualizados > 0 Then
            If RegistrosActualizados = 1 Then
                ToastNotificationsManager1.Notifications(3).Body2 = "Se encontró un nuevo registro"
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(3))
            ElseIf RegistrosActualizados > 1 Then
                ToastNotificationsManager1.Notifications(3).Body2 = "Se encontraron " & RegistrosActualizados & " nuevos registros"
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(3))
            End If
        End If

        SumarRows()
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        If txtSecondID.Text <> "" Then
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                If CStr(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID606Detalle"))).ToString = "" Then
                    e.Appearance.BackColor = Color.LightGreen
                    e.Appearance.BackColor2 = Color.LightSkyBlue
                    e.HighPriority = True
                End If
            End If
        End If

    End Sub

    Private Sub frm_envio_606_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If txtSecondID.Text = "" Then
            If TablaCompras.Rows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea cerrar el formulario?", "Cerrar formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
End Class