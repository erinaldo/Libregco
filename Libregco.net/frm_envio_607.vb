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

Public Class frm_envio_607
    Dim ID607 As String
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim sqlQ As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend TablaVentas As DataTable
    Dim RepositoryTipoIngreso As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard, .BestFitWidth = True}

    Dim RepositoryMontoFacturado As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisFacturado As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisRetenido As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisPercibido As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryRetencionRenta As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryISRPercibido As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryImpuestoSelectivo As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryOtrosImpuestos As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryPropinaLegal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryEfectivo As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryCheque As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryTarjeta As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryVentaCredito As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryBonos As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryPermuta As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryOtrasFomras As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryCurrency As New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
    Dim RepositoryTasa As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()

    'Dim RepositoryActualizar As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit() With {.Name = "update_button"}


    Private Sub frm_envio_607_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        SetTablaVentassTable()
        LimpiarDatos()
        Actualizar()
        RefrescarTabla()

        RepositoryMontoFacturado.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryMontoFacturado.Mask.EditMask = "c"
        RepositoryMontoFacturado.Mask.UseMaskAsDisplayFormat = True
        RepositoryMontoFacturado.NullText = CDbl(0).ToString("C")
        RepositoryMontoFacturado.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

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

        RepositoryItbisPercibido.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisPercibido.Mask.EditMask = "c"
        RepositoryItbisPercibido.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbisPercibido.NullText = CDbl(0).ToString("C")
        RepositoryItbisPercibido.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryRetencionRenta.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryRetencionRenta.Mask.EditMask = "c"
        RepositoryRetencionRenta.Mask.UseMaskAsDisplayFormat = True
        RepositoryRetencionRenta.NullText = CDbl(0).ToString("C")
        RepositoryRetencionRenta.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryISRPercibido.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryISRPercibido.Mask.EditMask = "c"
        RepositoryISRPercibido.Mask.UseMaskAsDisplayFormat = True
        RepositoryISRPercibido.NullText = CDbl(0).ToString("C")
        RepositoryISRPercibido.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryImpuestoSelectivo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryImpuestoSelectivo.Mask.EditMask = "c"
        RepositoryImpuestoSelectivo.Mask.UseMaskAsDisplayFormat = True
        RepositoryImpuestoSelectivo.NullText = CDbl(0).ToString("C")
        RepositoryImpuestoSelectivo.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryOtrosImpuestos.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryOtrosImpuestos.Mask.EditMask = "c"
        RepositoryOtrosImpuestos.Mask.UseMaskAsDisplayFormat = True
        RepositoryOtrosImpuestos.NullText = CDbl(0).ToString("C")
        RepositoryOtrosImpuestos.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbisPercibido.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisPercibido.Mask.EditMask = "c"
        RepositoryItbisPercibido.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbisPercibido.NullText = CDbl(0).ToString("C")
        RepositoryItbisPercibido.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryPropinaLegal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryPropinaLegal.Mask.EditMask = "c"
        RepositoryPropinaLegal.Mask.UseMaskAsDisplayFormat = True
        RepositoryPropinaLegal.NullText = CDbl(0).ToString("C")
        RepositoryPropinaLegal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryISRPercibido.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryISRPercibido.Mask.EditMask = "c"
        RepositoryISRPercibido.Mask.UseMaskAsDisplayFormat = True
        RepositoryISRPercibido.NullText = CDbl(0).ToString("C")
        RepositoryISRPercibido.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryEfectivo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryEfectivo.Mask.EditMask = "c"
        RepositoryEfectivo.Mask.UseMaskAsDisplayFormat = True
        RepositoryEfectivo.NullText = CDbl(0).ToString("C")
        RepositoryEfectivo.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryCheque.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryCheque.Mask.EditMask = "c"
        RepositoryCheque.Mask.UseMaskAsDisplayFormat = True
        RepositoryCheque.NullText = CDbl(0).ToString("C")
        RepositoryCheque.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryTarjeta.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryTarjeta.Mask.EditMask = "c"
        RepositoryTarjeta.Mask.UseMaskAsDisplayFormat = True
        RepositoryTarjeta.NullText = CDbl(0).ToString("C")
        RepositoryTarjeta.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryVentaCredito.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryVentaCredito.Mask.EditMask = "c"
        RepositoryVentaCredito.Mask.UseMaskAsDisplayFormat = True
        RepositoryVentaCredito.NullText = CDbl(0).ToString("C")
        RepositoryVentaCredito.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryBonos.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryBonos.Mask.EditMask = "c"
        RepositoryBonos.Mask.UseMaskAsDisplayFormat = True
        RepositoryBonos.NullText = CDbl(0).ToString("C")
        RepositoryBonos.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryPermuta.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryPermuta.Mask.EditMask = "c"
        RepositoryPermuta.Mask.UseMaskAsDisplayFormat = True
        RepositoryPermuta.NullText = CDbl(0).ToString("C")
        RepositoryPermuta.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryOtrasFomras.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryOtrasFomras.Mask.EditMask = "c"
        RepositoryOtrasFomras.Mask.UseMaskAsDisplayFormat = True
        RepositoryOtrasFomras.NullText = CDbl(0).ToString("C")
        RepositoryOtrasFomras.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryTasa.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryTasa.Mask.EditMask = "c"
        RepositoryTasa.Mask.UseMaskAsDisplayFormat = True
        RepositoryTasa.NullText = CDbl(0).ToString("C")
        RepositoryTasa.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")
        'RepositoryActualizar.Buttons(0).Caption = "Actualizar"
        'RepositoryActualizar.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        'RepositoryActualizar.Buttons(0).Image = My.Resources.Editor_24
        'RepositoryActualizar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        'RepositoryActualizar.LookAndFeel.UseDefaultLookAndFeel = False
        'RepositoryActualizar.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Office2010Silver)

    End Sub

    Private Sub SetTablaVentassTable()
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

        FillTipoIngreso()


        TablaVentas = New DataTable("Ventas")
        TablaVentas.Columns.Add("ID607Detalle", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDFacturaDatos", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDTipoDocumento", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("TipoDocumento", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDCliente", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Cliente", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("RNC", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDTipoComprobanteFiscal", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("TipoComprobanteFiscal", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("NCF", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("NCFModificado", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("TipoIngreso", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Fecha", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("FechaFormato", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("FechaRetencion", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("MontoFacturado", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("ItbisFacturado", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("ItbisRetenidoTercero", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("ItbisPercibido", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("RetencionRentaTerceros", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("ISRPercibido", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("ImpuestoSelectivo", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("OtrosImpuestos", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("MontoPropinalLegal", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Efectivo", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Cheque", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Tarjeta", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("VentaCredito", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Bonos", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Permuta", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("OtrasFormas", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Estatus", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Moneda", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("MonedaImagen", System.Type.GetType("System.Object"))
        TablaVentas.Columns.Add("Tasa", System.Type.GetType("System.String"))
        'TablaVentas.Columns.Add("Actualizar", System.Type.GetType("System.String"))
        GridControl1.DataSource = TablaVentas

        GridView1.Columns("MontoFacturado").ColumnEdit = RepositoryMontoFacturado
        GridView1.Columns("ItbisFacturado").ColumnEdit = RepositoryItbisFacturado
        GridView1.Columns("ItbisRetenidoTercero").ColumnEdit = RepositoryItbisRetenido
        GridView1.Columns("ItbisPercibido").ColumnEdit = RepositoryItbisPercibido
        GridView1.Columns("RetencionRentaTerceros").ColumnEdit = RepositoryRetencionRenta
        GridView1.Columns("ISRPercibido").ColumnEdit = RepositoryISRPercibido
        GridView1.Columns("ImpuestoSelectivo").ColumnEdit = RepositoryImpuestoSelectivo

        GridView1.Columns("TipoIngreso").ColumnEdit = RepositoryTipoIngreso
        GridView1.Columns("OtrosImpuestos").ColumnEdit = RepositoryOtrosImpuestos
        GridView1.Columns("MontoPropinalLegal").ColumnEdit = RepositoryPropinaLegal
        GridView1.Columns("Efectivo").ColumnEdit = RepositoryEfectivo
        GridView1.Columns("Cheque").ColumnEdit = RepositoryCheque
        GridView1.Columns("Tarjeta").ColumnEdit = RepositoryTarjeta
        GridView1.Columns("VentaCredito").ColumnEdit = RepositoryVentaCredito
        GridView1.Columns("Bonos").ColumnEdit = RepositoryBonos
        GridView1.Columns("Permuta").ColumnEdit = RepositoryPermuta
        GridView1.Columns("OtrasFormas").ColumnEdit = RepositoryOtrasFomras
        'GridView1.Columns("Actualizar").ColumnEdit = RepositoryActualizar
        GridView1.Columns("MonedaImagen").ColumnEdit = RepositoryCurrency
        GridView1.Columns("Tasa").ColumnEdit = RepositoryTasa

        'Propiedades
        GridView1.Columns("ID607Detalle").Visible = False
        GridView1.Columns("ID607Detalle").OptionsColumn.AllowEdit = False
        GridView1.Columns("ID607Detalle").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDFacturaDatos").Visible = False
        GridView1.Columns("IDFacturaDatos").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDFacturaDatos").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDFacturaDatos").Caption = "Código del documento"
        GridView1.Columns("IDFacturaDatos").Width = 120
        GridView1.Columns("SecondID").Visible = False
        GridView1.Columns("SecondID").OptionsColumn.AllowEdit = False
        GridView1.Columns("SecondID").OptionsColumn.ReadOnly = True
        GridView1.Columns("SecondID").Caption = "No. de factura"
        GridView1.Columns("SecondID").Width = 120
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
        GridView1.Columns("IDCliente").Visible = False
        GridView1.Columns("IDCliente").Caption = "Código del cliente"
        GridView1.Columns("IDCliente").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDCliente").OptionsColumn.ReadOnly = True
        GridView1.Columns("Cliente").Visible = False
        GridView1.Columns("Cliente").OptionsColumn.AllowEdit = False
        GridView1.Columns("Cliente").OptionsColumn.ReadOnly = True
        GridView1.Columns("RNC").Width = 100
        GridView1.Columns("RNC").OptionsColumn.AllowEdit = False
        GridView1.Columns("RNC").OptionsColumn.ReadOnly = True
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
        GridView1.Columns("TipoIngreso").Caption = "Tipo de ingreso"
        GridView1.Columns("TipoIngreso").Width = 260
        GridView1.Columns("Fecha").Visible = False
        GridView1.Columns("Fecha").OptionsColumn.AllowEdit = False
        GridView1.Columns("Fecha").OptionsColumn.ReadOnly = True
        GridView1.Columns("FechaFormato").Caption = "Fecha"
        GridView1.Columns("FechaFormato").Width = 80
        GridView1.Columns("FechaFormato").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridView1.Columns("FechaFormato").OptionsColumn.AllowEdit = False
        GridView1.Columns("FechaFormato").OptionsColumn.ReadOnly = True
        GridView1.Columns("FechaRetencion").Caption = "Fecha de retención"
        GridView1.Columns("FechaRetencion").Width = 120
        GridView1.Columns("MontoFacturado").Caption = "Monto Facturado"
        GridView1.Columns("MontoFacturado").Width = 120
        GridView1.Columns("MontoFacturado").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("MontoFacturado").DisplayFormat.FormatString = "C2"
        GridView1.Columns("MontoFacturado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoFacturado", "{0:c2}")
        GridView1.Columns("ItbisFacturado").Caption = "ITBIS Facturado"
        GridView1.Columns("ItbisFacturado").Width = 120
        GridView1.Columns("ItbisFacturado").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisFacturado").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisFacturado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisFacturado", "{0:c2}")
        GridView1.Columns("ItbisRetenidoTercero").Caption = "ITBIS Retenido por terceros"
        GridView1.Columns("ItbisRetenidoTercero").Width = 120
        GridView1.Columns("ItbisRetenidoTercero").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisRetenidoTercero").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisRetenidoTercero").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisRetenidoTercero", "{0:c2}")
        GridView1.Columns("ItbisPercibido").Caption = "ITBIS Percibido"
        GridView1.Columns("ItbisPercibido").Width = 120
        GridView1.Columns("ItbisPercibido").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ItbisPercibido").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ItbisPercibido").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisPercibido", "{0:c2}")
        GridView1.Columns("RetencionRentaTerceros").Caption = "Retención de renta por terceros"
        GridView1.Columns("RetencionRentaTerceros").Width = 120
        GridView1.Columns("RetencionRentaTerceros").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("RetencionRentaTerceros").DisplayFormat.FormatString = "C2"
        GridView1.Columns("RetencionRentaTerceros").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "RetencionRentaTerceros", "{0:c2}")
        GridView1.Columns("ISRPercibido").Caption = "ISR Percibido"
        GridView1.Columns("ISRPercibido").Width = 120
        GridView1.Columns("ISRPercibido").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ISRPercibido").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ISRPercibido").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ISRPercibido", "{0:c2}")
        GridView1.Columns("ImpuestoSelectivo").Caption = "Impuesto Selectivo al Consumo"
        GridView1.Columns("ImpuestoSelectivo").Width = 120
        GridView1.Columns("ImpuestoSelectivo").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("ImpuestoSelectivo").DisplayFormat.FormatString = "C2"
        GridView1.Columns("ImpuestoSelectivo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ImpuestoSelectivo", "{0:c2}")
        GridView1.Columns("OtrosImpuestos").Caption = "Otros Impuestos"
        GridView1.Columns("OtrosImpuestos").Width = 120
        GridView1.Columns("OtrosImpuestos").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("OtrosImpuestos").DisplayFormat.FormatString = "C2"
        GridView1.Columns("OtrosImpuestos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "OtrosImpuestos", "{0:c2}")
        GridView1.Columns("MontoPropinalLegal").Caption = "Monto de propina legal"
        GridView1.Columns("MontoPropinalLegal").Width = 120
        GridView1.Columns("MontoPropinalLegal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("MontoPropinalLegal").DisplayFormat.FormatString = "C2"
        GridView1.Columns("MontoPropinalLegal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoPropinalLegal", "{0:c2}")
        GridView1.Columns("Efectivo").Width = 120
        GridView1.Columns("Efectivo").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Efectivo").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Efectivo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Efectivo", "{0:c2}")
        GridView1.Columns("Cheque").Width = 120
        GridView1.Columns("Cheque").Caption = "Cheque / Transferencia / Depósito"
        GridView1.Columns("Cheque").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Cheque").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Cheque").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cheque", "{0:c2}")
        GridView1.Columns("Tarjeta").Caption = "Tarjeta Débito/Crédito"
        GridView1.Columns("Tarjeta").Width = 120
        GridView1.Columns("Tarjeta").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Tarjeta").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Tarjeta").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Tarjeta", "{0:c2}")
        GridView1.Columns("VentaCredito").Width = 120
        GridView1.Columns("VentaCredito").Caption = "Venta a crédito"
        GridView1.Columns("VentaCredito").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("VentaCredito").DisplayFormat.FormatString = "C2"
        GridView1.Columns("VentaCredito").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "VentaCredito", "{0:c2}")
        GridView1.Columns("Bonos").Caption = "Bonos o certificados de regalo"
        GridView1.Columns("Bonos").Width = 120
        GridView1.Columns("Bonos").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Bonos").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Bonos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Bonos", "{0:c2}")
        GridView1.Columns("Permuta").Caption = "Permuta"
        GridView1.Columns("Permuta").Width = 120
        GridView1.Columns("Permuta").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Permuta").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Permuta").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Permuta", "{0:c2}")
        GridView1.Columns("OtrasFormas").Caption = "Otras formas de ventas"
        GridView1.Columns("OtrasFormas").Width = 120
        GridView1.Columns("OtrasFormas").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("OtrasFormas").DisplayFormat.FormatString = "C2"
        GridView1.Columns("OtrasFormas").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "OtrasFormas", "{0:c2}")
        GridView1.Columns("Estatus").Caption = "Estado del registro"
        GridView1.Columns("Estatus").Width = 300
        GridView1.Columns("Estatus").OptionsColumn.ReadOnly = True
        GridView1.Columns("Estatus").OptionsColumn.AllowEdit = False
        GridView1.Columns("Moneda").OptionsColumn.AllowEdit = False
        GridView1.Columns("Moneda").OptionsColumn.ReadOnly = True
        GridView1.Columns("MonedaImagen").OptionsColumn.AllowEdit = False
        GridView1.Columns("MonedaImagen").OptionsColumn.ReadOnly = True
        GridView1.Columns("MonedaImagen").Width = 220
        GridView1.Columns("MonedaImagen").Caption = "Moneda en registro"
        GridView1.Columns("Tasa").OptionsColumn.AllowEdit = False
        GridView1.Columns("Tasa").OptionsColumn.ReadOnly = True
        GridView1.Columns("Moneda").Visible = False

        GridView1.Columns("Tasa").Width = 60
        GridView1.Columns("Tasa").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Tasa").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Tasa").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoPropinaLegal", "{0:c2}")
    End Sub


    Private Sub LimpiarDatos()
        ID607 = ""
        txtCantidadRegistros.Clear()
        cbxPeriodo.Items.Clear()
        TablaVentas.Rows.Clear()
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

    Private Sub FillTipoIngreso()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoIngreso,TiposIngreso FROM libregco.tipoingresosventas", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipoingresosventas")
        ConLibregco.Close()

        Dim TablaIngresos As DataTable = dstemp.Tables("tipoingresosventas")
        RepositoryTipoIngreso.DataSource = TablaIngresos
        RepositoryTipoIngreso.ValueMember = "IDTipoIngreso"
        RepositoryTipoIngreso.DisplayMember = "TiposIngreso"


    End Sub

    Private Sub FillPeriodos()
        Try
            Dim dstemp As New DataSet

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT DATE_FORMAT(Fecha,'%Y%m') as Fecha FROM" & SysName.Text & "FacturaDatos GROUP BY DATE_FORMAT(Fecha,'%Y%m') ORDER BY DATE_FORMAT(Fecha,'%Y%m') DESC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "FacturaDatos")
            cbxPeriodo.Items.Clear()
            ConMixta.Close()

            Dim Tabla As DataTable = dstemp.Tables("FacturaDatos")
            For Each Fila As DataRow In Tabla.Rows
                cbxPeriodo.Items.Add(Fila.Item("Fecha"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se encontraron períodos hábiles en la base de datos. Inserte registros de ventas para procesar el formato 607.", "No se encontraron registros de ventas 607", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub RefrescarTabla()
        Try
            If cbxPeriodo.Text <> "" Then
                Dim ds As New DataSet

                TablaVentas.Rows.Clear()

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,TipoDocumento.Documento,FacturaDatos.IDCliente,FacturaDatos.NombreFactura,FacturaDatos.IdentificacionFactura,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.NCF,FacturaDatos.NCFModificado,FacturaDatos.IDTipoIngreso,TipoIngresosVentas.TiposIngreso,FacturaDatos.Fecha,FacturaDatos.FechaRetencion,FacturaDatos.Subtotal,FacturaDatos.Itbis,FacturaDatos.ItbisRetenido,FacturaDatos.ItbisPercibido,FacturaDatos.RetencionRenta,FacturaDatos.ISRPercibido,FacturaDatos.ISC,FacturaDatos.OtrosImpuestos,FacturaDatos.PropinaLegal,(Transaccion.Efectivo-Transaccion.Devuelta) as Efectivo,(Transaccion.Cheque+Transaccion.Deposito) as Cheque,Transaccion.Tarjeta,(if(Condicion.Dias=0,0,FacturaDatos.TotalNeto-FacturaDatos.Inicial)) as VentaCredito,Transaccion.Bonos,Transaccion.Permuta,Transaccion.Otras,Transaccion.MontoCobrar,Transaccion.IDMoneda,TipoMoneda.Texto,FacturaDatos.Tasa from" & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.tipoingresosventas on FacturaDatos.IDTipoIngreso=TipoIngresosVentas.idTipoIngreso INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where DATE_FORMAT(FacturaDatos.Fecha,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and FacturaDatos.Nulo=0 UNION ALL SELECT DevolucionVenta.IDDevolucionVenta,DevolucionVenta.SecondID,DevolucionVenta.IDTipoDocumento,TipoDocumento.Documento,FacturaDatos.IDCliente,FacturaDatos.NombreFactura,FacturaDatos.IdentificacionFactura,4 AS IDComprobanteFiscal,'Notas de Crédito' as TipoComprobante,DevolucionVenta.NCF,FacturaDatos.NCF as NCFModificado,1 as IDTiposIngreso,'1 = Ingresos por Operaciones (No Financieros)' as TipoIngreso, DevolucionVenta.Fecha,'' as FechaRetencion,-DevolucionVenta.Subtotal,-DevolucionVenta.Itbis,0 as ItbisRetenido,0 as ItbisPercibido,0 as RetencionRenta,0 as ISRPercibido,0 as ISC,0 AS OtrosImpuestos,0 as PropinaLegal,if(DevolucionVenta.IDTipoDevolucion=3,DevolucionVenta.Devolver,0) as Efectivo,0 as Cheque,0 as Tarjeta,if(DevolucionVenta.IDTipoDevolucion=1,DevolucionVenta.Devolver,0) as VentaCredito,0 as Bonos,0 as Permuta,0 as Otras,0 as MontoCobrar,Transaccion.IDMoneda,TipoMoneda.Texto,FacturaDatos.Tasa from" & SysName.Text & "DevolucionVenta INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN" & SysName.Text & "TipoDocumento on DevolucionVenta.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where DATE_FORMAT(DevolucionVenta.Fecha,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and DevolucionVenta.Nulo=0 UNION ALL SELECT NotaDebitoCredito.IDNotaDebCred,NotaDebitoCredito.SecondID,NotaDebitoCredito.IDTipoDocumento,TipoDocumento.Documento,FacturaDatos.IDCliente,FacturaDatos.NombreFactura,FacturaDatos.IdentificacionFactura,if(IDTipoNota=2,4,3) AS IDComprobanteFiscal,if(IDTipoNota=2,'Notas de Crédito','Notas de Débito') as TipoComprobante,NotaDebitoCredito.NCF,FacturaDatos.NCF as NCFModificado,1 as IDTiposIngreso,'1 = Ingresos por Operaciones (No Financieros)' as TipoIngreso, NotaDebitoCredito.Fecha,'' as FechaRetencion,IF(IDTipoNota=2,-(notadebitocreditodetalle.Aplicado-notadebitocreditodetalle.Itbis),notadebitocreditodetalle.Aplicado-notadebitocreditodetalle.Itbis),IF(IDTipoNota=2,-notadebitocreditodetalle.Itbis,notadebitocreditodetalle.Itbis),0 as ItbisRetenido,0 as ItbisPercibido,0 as RetencionRenta,0 as ISRPercibido,0 as ISC,0 AS OtrosImpuestos,0 as PropinaLegal,0 as Efectivo,0 as Cheque,0 as Tarjeta,if(IDTipoNota=2,-NotaDebitoCreditoDetalle.Aplicado,NotaDebitoCreditoDetalle.Aplicado) as VentaCredito,0 as Bonos,0 as Permuta,0 as Otras,0 as MontoCobrar,Transaccion.IDMoneda,TipoMoneda.Texto,FacturaDatos.Tasa from" & SysName.Text & "NotaDebitoCreditoDetalle INNER JOIN" & SysName.Text & "NotaDebitoCredito on NotaDebitoCreditoDetalle.IDNotaDebitoCredito=NotaDebitoCredito.IDNotaDebCred INNER JOIN" & SysName.Text & "FacturaDatos on NotaDebitoCreditoDetalle.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "TipoDocumento on NotaDebitoCredito.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda WHERE DATE_FORMAT(NotaDebitoCredito.Fecha,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and NotaDebitoCredito.Nulo=0", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "FacturaDatos")
                ConMixta.Close()

                Dim TB As DataTable = ds.Tables("FacturaDatos")
                For Each itm As DataRow In TB.Rows
                    TablaVentas.Rows.Add("", itm.Item("IDFacturaDatos"), itm.Item("SecondID"), itm.Item("IDTipoDocumento"), itm.Item("Documento"), itm.Item("IDCliente"), itm.Item("NombreFactura"), itm.Item("IdentificacionFactura").ToString.Replace("-", ""), itm.Item("IDComprobanteFiscal"), itm.Item("TipoComprobante"), itm.Item("NCF"), itm.Item("NCFModificado"), itm.Item("IDTipoIngreso"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy"), CDate(itm.Item("Fecha")).ToString("yyyyMMdd"), itm.Item("FechaRetencion"), CDbl(itm.Item("Subtotal")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("Itbis")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ItbisRetenido")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ItbisPercibido")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("RetencionRenta")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ISRPercibido")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("ISC")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("OtrosImpuestos")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("PropinaLegal")) * CDbl(itm.Item("Tasa")), If(CDbl(itm.Item("Efectivo")) > CDbl(itm.Item("MontoCobrar")), CDbl(itm.Item("MontoCobrar")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("Efectivo")) * CDbl(itm.Item("Tasa"))), CDbl(itm.Item("Cheque")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("Tarjeta")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("VentaCredito")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("Bonos")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("Permuta")) * CDbl(itm.Item("Tasa")), CDbl(itm.Item("Otras")) * CDbl(itm.Item("Tasa")), "", itm.Item("Texto"), itm.Item("IDMoneda"), itm.Item("Tasa"))
                Next

                SumarRows()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SumarRows()
        txtCantidadRegistros.Text = TablaVentas.Rows.Count
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


    Private Sub cbxPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPeriodo.SelectedIndexChanged
        TablaVentas.Rows.Clear()

        If cbxPeriodo.Text <> "" Then
            Dim dstemp As New DataSet

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT idEnvio607,Envio607.IDTipoDocumento,TipoDocumento.Documento,envio607.SecondID,envio607.IDEquipo,AreaImpresion.ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,envio607.IDUsuario,Usuarios.Nombre as NombreUsuario,envio607.Fecha,envio607.Modificacion,envio607.Periodo,envio607.CantRegistros FROM" & SysName.Text & "envio607 INNER JOIN" & SysName.Text & "TipoDocumento on envio607.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "AreaImpresion on envio607.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Empleados as Usuarios on envio607.IDUsuario=Usuarios.IDEmpleado where envio607.Periodo='" + cbxPeriodo.Text.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "Envio607")
            ConMixta.Close()

            Dim TB As DataTable = dstemp.Tables("Envio607")

            If TB.Rows.Count = 0 Then
                RefrescarTabla()
                TileBarItem5.Visible = False
            Else
                cbxPeriodo.Enabled = False

                txtSecondID.Text = TB.Rows(0).Item("SecondID")
                txtSecondID.Tag = TB.Rows(0).Item("idEnvio607")
                lblStatus.Text = "PROCESADA"
                lblStatus.ForeColor = Color.Green
                txtCantidadRegistros.Text = TB.Rows(0).Item("CantRegistros")

                Dim ds As New DataSet

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT idEnvio607_Detalles,FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,TipoDocumento.Documento,FacturaDatos.IDCliente,FacturaDatos.NombreFactura,FacturaDatos.IdentificacionFactura,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.NCF,FacturaDatos.NCFModificado,FacturaDatos.IDTipoIngreso,TipoIngresosVentas.TiposIngreso,FacturaDatos.Fecha,FacturaDatos.FechaRetencion,FacturaDatos.Subtotal,FacturaDatos.Itbis,FacturaDatos.ItbisRetenido,FacturaDatos.ItbisPercibido,FacturaDatos.RetencionRenta,FacturaDatos.ISRPercibido,FacturaDatos.ISC,FacturaDatos.OtrosImpuestos,FacturaDatos.PropinaLegal,Transaccion.Efectivo,(Transaccion.Cheque+Transaccion.Deposito) as Cheque,Transaccion.Tarjeta,(if(Condicion.Dias=0,0,FacturaDatos.TotalNeto)) as VentaCredito,Transaccion.Bonos,Transaccion.Permuta,Transaccion.Otras,Estatus,Transaccion.IDMoneda,TipoMoneda.Texto,FacturaDatos.Tasa from" & SysName.Text & "Envio607_detalles INNER JOIN" & SysName.Text & "FacturaDatos on Envio607_Detalles.IDFacturaDatos=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Librego.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.tipoingresosventas on FacturaDatos.IDTipoIngreso=TipoIngresosVentas.idTipoIngreso INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where DATE_FORMAT(FacturaDatos.Fecha,'%Y%m')='" + cbxPeriodo.SelectedItem.ToString + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "envio607_detalles")
                ConMixta.Close()

                Dim TBa As DataTable = ds.Tables("envio607_detalles")

                For Each itm As DataRow In TBa.Rows
                    TablaVentas.Rows.Add(itm.Item("idEnvio607_Detalles"), itm.Item("IDFacturaDatos"), itm.Item("SecondID"), itm.Item("IDTipoDocumento"), itm.Item("Documento"), itm.Item("IDCliente"), itm.Item("NombreFactura"), itm.Item("IdentificacionFactura").ToString.Replace("-", ""), itm.Item("IDComprobanteFiscal"), itm.Item("TipoComprobante"), itm.Item("NCF"), itm.Item("NCFModificado"), itm.Item("IDTipoIngreso"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy"), CDate(itm.Item("Fecha")).ToString("yyyyMMdd"), itm.Item("FechaRetencion"), itm.Item("Subtotal"), itm.Item("Itbis"), itm.Item("ItbisRetenido"), itm.Item("ItbisPercibido"), itm.Item("RetencionRenta"), itm.Item("ISRPercibido"), itm.Item("ISC"), itm.Item("OtrosImpuestos"), itm.Item("PropinaLegal"), itm.Item("Efectivo"), itm.Item("Cheque"), itm.Item("Tarjeta"), itm.Item("VentaCredito"), itm.Item("Bonos"), itm.Item("Permuta"), itm.Item("Otras"), itm.Item("Estatus"), itm.Item("Texto"), itm.Item("IDMoneda"), itm.Item("Tasa"))
                Next

                SumarRows()

                TileBarItem5.Visible = True
            End If

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
    Private Sub ActualizarFacturas()
        ConMixta.Open()

        For Each rw As DataRow In TablaVentas.Rows
            cmd = New MySqlCommand("UPDATE" & SysName.Text & "FacturaDatos SET IDTipoIngreso='" + rw.Item("TipoIngreso").ToString + "' WHERE IDFacturaDatos= (" + rw.Item("IDFacturaDatos").ToString + ")", ConMixta)
            cmd.ExecuteNonQuery()
        Next
        ConMixta.Close()
    End Sub

    Private Sub TileBarItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem2.ItemClick
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la línea " & CInt(GridView1.FocusedRowHandle.ToString) + 1 & " de la tabla?", "Eliminar la fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            If GridView1.GetFocusedRowCellValue("ID607Detalle").ToString = "" Then
                Dim iterateIndex1 As Integer = 0
                Dim newDataTable1 As DataTable = TablaVentas.Copy
                For Each itm As DataRow In newDataTable1.Rows
                    If itm.Item("IDFacturaDatos") = GridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString Then
                        TablaVentas.Rows.RemoveAt(iterateIndex1)
                        Exit For
                    Else
                        iterateIndex1 += 1
                    End If
                Next
                newDataTable1.Dispose()
            Else

                Con.Open()
                cmd = New MySqlCommand("Delete from envio607_detalles Where idEnvio607_Detalles='" + GridView1.GetFocusedRowCellValue("ID607Detalle").ToString + "'", Con)
                cmd.ExecuteNonQuery()
                Con.Close()

                Dim iterateIndex1 As Integer = 0
                Dim newDataTable1 As DataTable = TablaVentas.Copy
                For Each itm As DataRow In newDataTable1.Rows
                    If itm.Item("IDFacturaDatos") = GridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString Then
                        TablaVentas.Rows.RemoveAt(iterateIndex1)
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
            If TablaVentas.Rows.Count > 0 Then
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

    'Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
    '    If e.RowHandle >= 0 Then
    '        If GridView1.FocusedColumn.FieldName = "Actualizar" Then
    '            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea actualizar el registro seleccionado {Ubicación: " & CInt(GridView1.FocusedRowHandle.ToString) + 1 & "} de la tabla en el registro de compras?", "Actualizar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '            If Result = MsgBoxResult.Yes Then
    '                ConMixta.Open()
    '                cmd = New MySqlCommand("UPDATE" & SysName.Text & "FacturaDatos SET Subtotal='" + GridView1.GetFocusedRowCellValue("MontoFacturado").ToString + "',Itbis='" + GridView1.GetFocusedRowCellValue("ItbisFacturado").ToString + "',FechaRetencion='" + GridView1.GetFocusedRowCellValue("FechaRetencion").ToString + "',ItbisRetenido='" + GridView1.GetFocusedRowCellValue("ItbisRetenidoTercero").ToString + "',ItbisPercibido='" + GridView1.GetFocusedRowCellValue("ItbisPercibido").ToString + "',RetencionRenta='" + GridView1.GetFocusedRowCellValue("RetencionRentaTerceros").ToString + "',ISRPercibido='" + GridView1.GetFocusedRowCellValue("ISRPercibido").ToString + "',ISC='" + GridView1.GetFocusedRowCellValue("ImpuestoSelectivo").ToString + "',OtrosImpuestos='" + GridView1.GetFocusedRowCellValue("OtrosImpuestos").ToString + "',PropinalLegal='" + GridView1.GetFocusedRowCellValue("MontoPropinaLegal").ToString + "' WHERE IDFacturaDatos= (" + GridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + ")", ConMixta)
    '                cmd.ExecuteNonQuery()
    '                ConMixta.Close()

    '                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
    '            End If
    '        End If
    '    End If
    'End Sub



    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        If txtSecondID.Text <> "" Then
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                If CStr(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID607Detalle"))).ToString = "" Then
                    e.Appearance.BackColor = Color.LightGreen
                    e.Appearance.BackColor2 = Color.LightSkyBlue
                    e.HighPriority = True
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

    Private Sub Ult607()
        Try

            If txtSecondID.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select idEnvio607 from" & SysName.Text & "Envio607 where idEnvio607= (Select Max(idEnvio607) from Envio607)", Con)
                txtSecondID.Tag = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select SecondID from" & SysName.Text & "Envio607 where idEnvio607= (Select Max(idEnvio607) from Envio607)", Con)
                txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())

                lblStatus.Text = "PROCESADO"
                lblStatus.ForeColor = Color.DarkSeaGreen
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Private Sub InsertDetalles()
        Con.Open()

        For Each Row As DataRow In TablaVentas.Rows
            If Row.Item("ID607Detalle").ToString = "" Then

                cmd = New MySqlCommand("INSERT INTO" & SysName.Text & "envio607_detalles (ID607,IDFacturaDatos,Estatus) VALUES ('" + txtSecondID.Tag.ToString + "','" + Row.Item("IDFacturaDatos").ToString + "','" + Row.Item("Estatus").ToString + "')", Con)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select idEnvio607_Detalles from envio607_detalles where idEnvio607_Detalles=(Select Max(idEnvio607_Detalles) from envio607_detalles)", Con)
                Row.Item(0) = Convert.ToString(cmd.ExecuteScalar())

            Else

                cmd = New MySqlCommand("UPDATE" & SysName.Text & "envio607_detalles SET ID607='" + txtSecondID.Tag.ToString + "',IDFacturaDatos='" + Row.Item("IDFacturaDatos").ToString + "',Estatus='" + Row.Item("Estatus").ToString + "' Where idEnvio607_Detalles='" + Row.Item("ID607Detalle").ToString + "'", Con)
                cmd.ExecuteNonQuery()

            End If
        Next

        Con.Close()
    End Sub

    Private Sub TileBarItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem1.ItemClick
        If GridView1.RowCount > 0 Then
            If txtSecondID.Tag.ToString = "" Then

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea procesar el formulario de envío de ventas de productos  y servicios 607 correspondiente al período " & cbxPeriodo.Text & "?", "Generar formulario 607", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ActualizarFacturas()
                    sqlQ = "INSERT INTO" & SysName.Text & "Envio607 (SecondID,IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Modificacion,Periodo,CantRegistros) VALUES ('" + GetSecondID(61).ToString + "','61', '" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',NOW(),NOW(),'" + cbxPeriodo.Text + "','" + txtCantidadRegistros.Text + "')"
                    GuardarDatos()
                    Ult607()
                    InsertDetalles()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))


                End If

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea actualizar el formulario de envío de venta de productos y servicios 607 correspondiente al período " & cbxPeriodo.Text & "?", "Actualizar formulario 607", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ActualizarFacturas()
                    sqlQ = "UPDATE" & SysName.Text & "Envio607 SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Modificacion=CURDATE(),CantRegistros='" + txtCantidadRegistros.Text + "' WHERE id607='" + txtSecondID.Tag.ToString + "')"
                    GuardarDatos()
                    InsertDetalles()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(2))
                End If
            End If
        End If

    End Sub

    Private Sub TileBarItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem4.ItemClick
        If GridView1.FocusedRowHandle >= 0 Then
            If GridView1.GetFocusedRowCellValue("IDTipoDocumento") = 1 Or GridView1.GetFocusedRowCellValue("IDTipoDocumento") = 2 Then
                Dim PermisosConsultaVentas As New ArrayList
                PermisosConsultaVentas = PasarPermisos(46)

                If PermisosConsultaVentas(0) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para acceder al formulario de consulta de ventas.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    If frm_consulta_ventas.Visible = True Then
                        frm_consulta_ventas.Close()
                    End If

                    frm_consulta_ventas.Show(Me)

                    frm_consulta_ventas.txtFechaInicial.Value = CDate(GridView1.GetFocusedRowCellValue("Fecha"))
                    frm_consulta_ventas.txtFechaFinal.Value = CDate(GridView1.GetFocusedRowCellValue("Fecha"))
                    frm_consulta_ventas.txtIDCliente.Text = GridView1.GetFocusedRowCellValue("IDCliente")
                    frm_consulta_ventas.txtCliente.Text = GridView1.GetFocusedRowCellValue("Cliente")
                    frm_consulta_ventas.LookingForIDFactura = GridView1.GetFocusedRowCellValue("IDFacturaDatos")

                    frm_consulta_ventas.btnBuscarCons.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub TileBarItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem5.ItemClick
        Dim RegistrosActualizados = 0
        Dim ds As New DataSet

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,TipoDocumento.Documento,FacturaDatos.IDCliente,FacturaDatos.NombreFactura,FacturaDatos.IdentificacionFactura,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.NCF,FacturaDatos.NCFModificado,FacturaDatos.IDTipoIngreso,TipoIngresosVentas.TiposIngreso,FacturaDatos.Fecha,FacturaDatos.FechaRetencion,FacturaDatos.Subtotal,FacturaDatos.Itbis,FacturaDatos.ItbisRetenido,FacturaDatos.ItbisPercibido,FacturaDatos.RetencionRenta,FacturaDatos.ISRPercibido,FacturaDatos.ISC,FacturaDatos.OtrosImpuestos,FacturaDatos.PropinaLegal,Transaccion.Efectivo,(Transaccion.Cheque+Transaccion.Deposito) as Cheque,Transaccion.Tarjeta,(if(Condicion.Dias=0,0,FacturaDatos.TotalNeto)) as VentaCredito,Transaccion.Bonos,Transaccion.Permuta,Transaccion.Otras from " & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.tipoingresosventas on FacturaDatos.IDTipoIngreso=TipoIngresosVentas.idTipoIngreso INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where DATE_FORMAT(FacturaDatos.Fecha,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and FacturaDatos.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "FacturaDatos")
        ConMixta.Close()

        Dim TB As DataTable = ds.Tables("FacturaDatos")

        For Each row As DataRow In TB.Rows
            Dim Founded As Boolean = False
            For Each itm As DataRow In TablaVentas.Rows
                If row.Item("IDFacturaDatos") = itm.Item("IDFacturaDatos") Then
                    Founded = True
                    Exit For
                End If
            Next

            If Founded = False Then
                RegistrosActualizados += 1
                TablaVentas.Rows.Add("", row.Item("IDFacturaDatos"), row.Item("SecondID"), row.Item("IDTipoDocumento"), row.Item("Documento"), row.Item("IDCliente"), row.Item("NombreFactura"), row.Item("IdentificacionFactura").ToString.Replace("-", ""), row.Item("IDComprobanteFiscal"), row.Item("TipoComprobante"), row.Item("NCF"), row.Item("NCFModificado"), row.Item("IDTipoIngreso"), CDate(row.Item("Fecha")).ToString("dd/MM/yyyy"), CDate(row.Item("Fecha")).ToString("yyyyMMdd"), row.Item("FechaRetencion"), row.Item("Subtotal"), row.Item("Itbis"), row.Item("ItbisRetenido"), row.Item("ItbisPercibido"), row.Item("RetencionRenta"), row.Item("ISRPercibido"), row.Item("ISC"), row.Item("OtrosImpuestos"), row.Item("PropinaLegal"), row.Item("Efectivo"), row.Item("Cheque"), row.Item("Tarjeta"), row.Item("VentaCredito"), row.Item("Bonos"), row.Item("Permuta"), row.Item("Otras"), "Nuevo registro")
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

    Private Sub frm_envio_607_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If txtSecondID.Text = "" Then
            If TablaVentas.Rows.Count > 0 Then
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