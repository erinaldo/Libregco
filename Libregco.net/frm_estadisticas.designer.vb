<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_estadisticas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_estadisticas))
        Dim ColumnDefinition1 As DevExpress.XtraLayout.ColumnDefinition = New DevExpress.XtraLayout.ColumnDefinition()
        Dim ColumnDefinition2 As DevExpress.XtraLayout.ColumnDefinition = New DevExpress.XtraLayout.ColumnDefinition()
        Dim RowDefinition1 As DevExpress.XtraLayout.RowDefinition = New DevExpress.XtraLayout.RowDefinition()
        Dim RowDefinition2 As DevExpress.XtraLayout.RowDefinition = New DevExpress.XtraLayout.RowDefinition()
        Dim RowDefinition3 As DevExpress.XtraLayout.RowDefinition = New DevExpress.XtraLayout.RowDefinition()
        Dim RowDefinition4 As DevExpress.XtraLayout.RowDefinition = New DevExpress.XtraLayout.RowDefinition()
        Me.XtraTabControl4 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage8 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl5 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage10 = New DevExpress.XtraTab.XtraTabPage()
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavGraficoArticulosVentas = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroupControlContainer1 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.GraficoArticulosMasVendidos = New DevExpress.XtraCharts.ChartControl()
        Me.CMenuGraficos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IrAArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavBarGroupControlContainer2 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.NupCantArticulos = New System.Windows.Forms.NumericUpDown()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NavDatosArticulosMsVendidos = New DevExpress.XtraNavBar.NavBarGroup()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.cbxUsuarios = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.btnActualizar = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.chkTodos = New DevExpress.XtraEditors.CheckEdit()
        Me.PicFoto = New DevExpress.XtraEditors.PictureEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpInicial = New DevExpress.XtraEditors.DateEdit()
        Me.DtpFinal = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.NavBarControl2 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavFacturas = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroupControlContainer3 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.GridVentasBeneficios = New DevExpress.XtraGrid.GridControl()
        Me.GridBeneficios = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NavBarGroupControlContainer4 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.GcArticulosBeneficios = New DevExpress.XtraGrid.GridControl()
        Me.GvArticulosBeneficios = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NavArticulos = New DevExpress.XtraNavBar.NavBarGroup()
        Me.lblAVGRendimiento = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblAVGventas = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblBeneficioPromedioGeneral = New DevExpress.XtraEditors.LabelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCantidadVentas = New System.Windows.Forms.Label()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.XtraTabControl3 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage6 = New DevExpress.XtraTab.XtraTabPage()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.GraficoParticipacionVentas = New DevExpress.XtraCharts.ChartControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.lblLugarCantidadVentas = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.lblLugarVenta = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.XtraTabPage7 = New DevExpress.XtraTab.XtraTabPage()
        Me.GcParticipacionVentas = New DevExpress.XtraGrid.GridControl()
        Me.GvParticipacionVentas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTabVentas = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl2 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.cbxTiempo = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GraficoVentasEmpleados = New DevExpress.XtraCharts.ChartControl()
        Me.XtraTabPage5 = New DevExpress.XtraTab.XtraTabPage()
        Me.GcVentasEmpleados = New DevExpress.XtraGrid.GridControl()
        Me.GvVentasEmpleados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage9 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GraficoComparacionPeriodos = New DevExpress.XtraCharts.ChartControl()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.ChkDeposito = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCheque = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTarjeta = New DevExpress.XtraEditors.CheckEdit()
        Me.chkEfectivo = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cbxAgrupacionVentasPeriodos = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GcVentasPeriodos = New DevExpress.XtraGrid.GridControl()
        Me.GvVentasPeriodos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage11 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl6 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage12 = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GraficoIngresovsGastos = New DevExpress.XtraCharts.ChartControl()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBoxEdit2 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.XtraTabPage13 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl7 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage14 = New DevExpress.XtraTab.XtraTabPage()
        Me.GcIngresosVsGastos = New DevExpress.XtraGrid.GridControl()
        Me.GvIngresosVsGastos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage15 = New DevExpress.XtraTab.XtraTabPage()
        Me.GDGastos = New DevExpress.XtraGrid.GridControl()
        Me.GVGastos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.XtraTabControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl4.SuspendLayout()
        Me.XtraTabPage8.SuspendLayout()
        CType(Me.XtraTabControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl5.SuspendLayout()
        Me.XtraTabPage10.SuspendLayout()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarControl1.SuspendLayout()
        Me.NavBarGroupControlContainer1.SuspendLayout()
        CType(Me.GraficoArticulosMasVendidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuGraficos.SuspendLayout()
        Me.NavBarGroupControlContainer2.SuspendLayout()
        CType(Me.NupCantArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.cbxUsuarios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTodos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFoto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.NavBarControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarControl2.SuspendLayout()
        Me.NavBarGroupControlContainer3.SuspendLayout()
        CType(Me.GridVentasBeneficios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridBeneficios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarGroupControlContainer4.SuspendLayout()
        CType(Me.GcArticulosBeneficios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvArticulosBeneficios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl3.SuspendLayout()
        Me.XtraTabPage6.SuspendLayout()
        CType(Me.GraficoParticipacionVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage7.SuspendLayout()
        CType(Me.GcParticipacionVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvParticipacionVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTabVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTabVentas.SuspendLayout()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl2.SuspendLayout()
        Me.XtraTabPage4.SuspendLayout()
        CType(Me.cbxTiempo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GraficoVentasEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage5.SuspendLayout()
        CType(Me.GcVentasEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvVentasEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage9.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GraficoComparacionPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkDeposito.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCheque.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTarjeta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEfectivo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxAgrupacionVentasPeriodos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GcVentasPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvVentasPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage11.SuspendLayout()
        CType(Me.XtraTabControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl6.SuspendLayout()
        Me.XtraTabPage12.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.GraficoIngresovsGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage13.SuspendLayout()
        CType(Me.XtraTabControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl7.SuspendLayout()
        Me.XtraTabPage14.SuspendLayout()
        CType(Me.GcIngresosVsGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvIngresosVsGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage15.SuspendLayout()
        CType(Me.GDGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl4
        '
        Me.XtraTabControl4.Location = New System.Drawing.Point(12, 582)
        Me.XtraTabControl4.Name = "XtraTabControl4"
        Me.XtraTabControl4.SelectedTabPage = Me.XtraTabPage8
        Me.XtraTabControl4.Size = New System.Drawing.Size(730, 496)
        Me.XtraTabControl4.TabIndex = 12
        Me.XtraTabControl4.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage8})
        '
        'XtraTabPage8
        '
        Me.XtraTabPage8.Controls.Add(Me.XtraTabControl5)
        Me.XtraTabPage8.Name = "XtraTabPage8"
        Me.XtraTabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.XtraTabPage8.Size = New System.Drawing.Size(724, 468)
        Me.XtraTabPage8.Text = "Artículos"
        '
        'XtraTabControl5
        '
        Me.XtraTabControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl5.Location = New System.Drawing.Point(3, 3)
        Me.XtraTabControl5.Name = "XtraTabControl5"
        Me.XtraTabControl5.SelectedTabPage = Me.XtraTabPage10
        Me.XtraTabControl5.Size = New System.Drawing.Size(718, 462)
        Me.XtraTabControl5.TabIndex = 0
        Me.XtraTabControl5.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage10})
        '
        'XtraTabPage10
        '
        Me.XtraTabPage10.Controls.Add(Me.NavBarControl1)
        Me.XtraTabPage10.Name = "XtraTabPage10"
        Me.XtraTabPage10.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.XtraTabPage10.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.XtraTabPage10.Size = New System.Drawing.Size(712, 434)
        Me.XtraTabPage10.Text = "Más vendidos"
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.NavGraficoArticulosVentas
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer1)
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer2)
        Me.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavGraficoArticulosVentas, Me.NavDatosArticulosMsVendidos})
        Me.NavBarControl1.Location = New System.Drawing.Point(0, 5)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = 712
        Me.NavBarControl1.OptionsNavPane.ShowExpandButton = False
        Me.NavBarControl1.OptionsNavPane.ShowOverflowPanel = False
        Me.NavBarControl1.OptionsNavPane.ShowSplitter = False
        Me.NavBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
        Me.NavBarControl1.Size = New System.Drawing.Size(712, 424)
        Me.NavBarControl1.TabIndex = 0
        Me.NavBarControl1.Text = "NavBarControl1"
        '
        'NavGraficoArticulosVentas
        '
        Me.NavGraficoArticulosVentas.Caption = "Gráfico"
        Me.NavGraficoArticulosVentas.ControlContainer = Me.NavBarGroupControlContainer1
        Me.NavGraficoArticulosVentas.Expanded = True
        Me.NavGraficoArticulosVentas.GroupClientHeight = 333
        Me.NavGraficoArticulosVentas.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavGraficoArticulosVentas.Name = "NavGraficoArticulosVentas"
        '
        'NavBarGroupControlContainer1
        '
        Me.NavBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer1.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer1.Controls.Add(Me.SimpleButton3)
        Me.NavBarGroupControlContainer1.Controls.Add(Me.GraficoArticulosMasVendidos)
        Me.NavBarGroupControlContainer1.Name = "NavBarGroupControlContainer1"
        Me.NavBarGroupControlContainer1.Size = New System.Drawing.Size(712, 335)
        Me.NavBarGroupControlContainer1.TabIndex = 0
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(669, 293)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(38, 38)
        Me.SimpleButton3.TabIndex = 7
        '
        'GraficoArticulosMasVendidos
        '
        Me.GraficoArticulosMasVendidos.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.GraficoArticulosMasVendidos.ContextMenuStrip = Me.CMenuGraficos
        Me.GraficoArticulosMasVendidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GraficoArticulosMasVendidos.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.GraficoArticulosMasVendidos.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.GraficoArticulosMasVendidos.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
        Me.GraficoArticulosMasVendidos.Legend.Name = "Default Legend"
        Me.GraficoArticulosMasVendidos.Location = New System.Drawing.Point(0, 0)
        Me.GraficoArticulosMasVendidos.Name = "GraficoArticulosMasVendidos"
        Me.GraficoArticulosMasVendidos.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.GraficoArticulosMasVendidos.SeriesTemplate.ToolTipSeriesPattern = ""
        Me.GraficoArticulosMasVendidos.Size = New System.Drawing.Size(712, 335)
        Me.GraficoArticulosMasVendidos.TabIndex = 0
        '
        'CMenuGraficos
        '
        Me.CMenuGraficos.BackColor = System.Drawing.Color.White
        Me.CMenuGraficos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IrAArtículosToolStripMenuItem, Me.ToolStripSeparator5, Me.QuitarToolStripMenuItem1, Me.ModificarToolStripMenuItem1})
        Me.CMenuGraficos.Name = "ContextMenuStrip1"
        Me.CMenuGraficos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CMenuGraficos.Size = New System.Drawing.Size(140, 76)
        Me.CMenuGraficos.Text = "Opciones"
        '
        'IrAArtículosToolStripMenuItem
        '
        Me.IrAArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.IrAArtículosToolStripMenuItem.Name = "IrAArtículosToolStripMenuItem"
        Me.IrAArtículosToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.IrAArtículosToolStripMenuItem.Text = "Previsualizar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(136, 6)
        '
        'QuitarToolStripMenuItem1
        '
        Me.QuitarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarToolStripMenuItem1.Name = "QuitarToolStripMenuItem1"
        Me.QuitarToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.QuitarToolStripMenuItem1.Text = "Imprimir"
        '
        'ModificarToolStripMenuItem1
        '
        Me.ModificarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarToolStripMenuItem1.Name = "ModificarToolStripMenuItem1"
        Me.ModificarToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.ModificarToolStripMenuItem1.Text = "Actualizar"
        '
        'NavBarGroupControlContainer2
        '
        Me.NavBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer2.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer2.Controls.Add(Me.NupCantArticulos)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.GridControl3)
        Me.NavBarGroupControlContainer2.Name = "NavBarGroupControlContainer2"
        Me.NavBarGroupControlContainer2.Padding = New System.Windows.Forms.Padding(2)
        Me.NavBarGroupControlContainer2.Size = New System.Drawing.Size(628, 206)
        Me.NavBarGroupControlContainer2.TabIndex = 1
        '
        'NupCantArticulos
        '
        Me.NupCantArticulos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NupCantArticulos.Location = New System.Drawing.Point(571, 9)
        Me.NupCantArticulos.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NupCantArticulos.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NupCantArticulos.Name = "NupCantArticulos"
        Me.NupCantArticulos.Size = New System.Drawing.Size(52, 21)
        Me.NupCantArticulos.TabIndex = 4
        Me.NupCantArticulos.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.Location = New System.Drawing.Point(2, 2)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Padding = New System.Windows.Forms.Padding(2)
        Me.GridControl3.Size = New System.Drawing.Size(624, 202)
        Me.GridControl3.TabIndex = 1
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsBehavior.ReadOnly = True
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'NavDatosArticulosMsVendidos
        '
        Me.NavDatosArticulosMsVendidos.Caption = "Datos"
        Me.NavDatosArticulosMsVendidos.ControlContainer = Me.NavBarGroupControlContainer2
        Me.NavDatosArticulosMsVendidos.GroupClientHeight = 171
        Me.NavDatosArticulosMsVendidos.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavDatosArticulosMsVendidos.Name = "NavDatosArticulosMsVendidos"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl2.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl2.Controls.Add(Me.cbxUsuarios)
        Me.GroupControl2.Controls.Add(Me.btnActualizar)
        Me.GroupControl2.Controls.Add(Me.lblPuesto)
        Me.GroupControl2.Controls.Add(Me.chkTodos)
        Me.GroupControl2.Controls.Add(Me.PicFoto)
        Me.GroupControl2.Controls.Add(Me.Label4)
        Me.GroupControl2.Controls.Add(Me.Label3)
        Me.GroupControl2.Controls.Add(Me.dtpInicial)
        Me.GroupControl2.Controls.Add(Me.DtpFinal)
        Me.GroupControl2.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1126, 116)
        Me.GroupControl2.TabIndex = 10
        Me.GroupControl2.Text = "     Controles de Usuario"
        '
        'cbxUsuarios
        '
        Me.cbxUsuarios.Location = New System.Drawing.Point(104, 26)
        Me.cbxUsuarios.Name = "cbxUsuarios"
        Me.cbxUsuarios.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.cbxUsuarios.Properties.Appearance.Options.UseBackColor = True
        Me.cbxUsuarios.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbxUsuarios.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxUsuarios.Size = New System.Drawing.Size(343, 18)
        Me.cbxUsuarios.TabIndex = 14
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Location = New System.Drawing.Point(856, 78)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(167, 23)
        Me.btnActualizar.TabIndex = 11
        Me.btnActualizar.Text = "Actualizar"
        '
        'lblPuesto
        '
        Me.lblPuesto.Font = New System.Drawing.Font("Segoe UI Semilight", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto.Location = New System.Drawing.Point(104, 46)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(341, 20)
        Me.lblPuesto.TabIndex = 12
        Me.lblPuesto.Text = "Puesto"
        Me.lblPuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkTodos
        '
        Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTodos.Location = New System.Drawing.Point(1068, 36)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Properties.Caption = "Todos"
        Me.chkTodos.Size = New System.Drawing.Size(53, 19)
        Me.chkTodos.TabIndex = 3
        '
        'PicFoto
        '
        Me.PicFoto.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicFoto.EditValue = Global.Libregco.My.Resources.Resources.no_photo
        Me.PicFoto.Location = New System.Drawing.Point(5, 22)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PicFoto.Properties.Appearance.Options.UseBackColor = True
        Me.PicFoto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PicFoto.Properties.OptionsMask.MaskLayoutMode = DevExpress.XtraEditors.Controls.PictureEditMaskLayoutMode.ZoomInside
        Me.PicFoto.Properties.OptionsMask.MaskType = DevExpress.XtraEditors.Controls.PictureEditMaskType.Circle
        Me.PicFoto.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PicFoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PicFoto.ShowToolTips = False
        Me.PicFoto.Size = New System.Drawing.Size(90, 90)
        Me.PicFoto.TabIndex = 3
        Me.PicFoto.Tag = "1"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(936, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(856, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Del"
        '
        'dtpInicial
        '
        Me.dtpInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpInicial.EditValue = New Date(2021, 1, 1, 16, 33, 0, 0)
        Me.dtpInicial.Location = New System.Drawing.Point(856, 52)
        Me.dtpInicial.Name = "dtpInicial"
        Me.dtpInicial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpInicial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpInicial.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.dtpInicial.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtpInicial.Size = New System.Drawing.Size(81, 20)
        Me.dtpInicial.TabIndex = 3
        '
        'DtpFinal
        '
        Me.DtpFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpFinal.EditValue = New Date(2021, 3, 6, 16, 33, 2, 692)
        Me.DtpFinal.Location = New System.Drawing.Point(939, 52)
        Me.DtpFinal.Name = "DtpFinal"
        Me.DtpFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtpFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtpFinal.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DtpFinal.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DtpFinal.Size = New System.Drawing.Size(84, 20)
        Me.DtpFinal.TabIndex = 5
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.NavBarControl2)
        Me.GroupControl1.Controls.Add(Me.lblAVGRendimiento)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.lblAVGventas)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.lblBeneficioPromedioGeneral)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.lblCantidadVentas)
        Me.GroupControl1.Controls.Add(Me.SeparatorControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(746, 582)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(392, 496)
        Me.GroupControl1.TabIndex = 13
        Me.GroupControl1.Text = "% Beneficios en ventas"
        '
        'NavBarControl2
        '
        Me.NavBarControl2.ActiveGroup = Me.NavFacturas
        Me.NavBarControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NavBarControl2.Controls.Add(Me.NavBarGroupControlContainer3)
        Me.NavBarControl2.Controls.Add(Me.NavBarGroupControlContainer4)
        Me.NavBarControl2.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavFacturas, Me.NavArticulos})
        Me.NavBarControl2.Location = New System.Drawing.Point(5, 108)
        Me.NavBarControl2.Name = "NavBarControl2"
        Me.NavBarControl2.OptionsNavPane.ExpandedWidth = 382
        Me.NavBarControl2.OptionsNavPane.ShowExpandButton = False
        Me.NavBarControl2.OptionsNavPane.ShowOverflowButton = False
        Me.NavBarControl2.OptionsNavPane.ShowOverflowPanel = False
        Me.NavBarControl2.OptionsNavPane.ShowSplitter = False
        Me.NavBarControl2.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
        Me.NavBarControl2.Size = New System.Drawing.Size(382, 384)
        Me.NavBarControl2.TabIndex = 10
        Me.NavBarControl2.Text = "NavBarControl2"
        '
        'NavFacturas
        '
        Me.NavFacturas.Caption = "Facturación"
        Me.NavFacturas.ControlContainer = Me.NavBarGroupControlContainer3
        Me.NavFacturas.Expanded = True
        Me.NavFacturas.GroupClientHeight = 284
        Me.NavFacturas.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavFacturas.Name = "NavFacturas"
        '
        'NavBarGroupControlContainer3
        '
        Me.NavBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer3.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer3.Controls.Add(Me.GridVentasBeneficios)
        Me.NavBarGroupControlContainer3.Name = "NavBarGroupControlContainer3"
        Me.NavBarGroupControlContainer3.Size = New System.Drawing.Size(382, 295)
        Me.NavBarGroupControlContainer3.TabIndex = 0
        '
        'GridVentasBeneficios
        '
        Me.GridVentasBeneficios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridVentasBeneficios.Location = New System.Drawing.Point(0, 0)
        Me.GridVentasBeneficios.MainView = Me.GridBeneficios
        Me.GridVentasBeneficios.Name = "GridVentasBeneficios"
        Me.GridVentasBeneficios.Size = New System.Drawing.Size(382, 295)
        Me.GridVentasBeneficios.TabIndex = 4
        Me.GridVentasBeneficios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridBeneficios})
        '
        'GridBeneficios
        '
        Me.GridBeneficios.GridControl = Me.GridVentasBeneficios
        Me.GridBeneficios.Name = "GridBeneficios"
        Me.GridBeneficios.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridBeneficios.OptionsBehavior.Editable = False
        Me.GridBeneficios.OptionsBehavior.ReadOnly = True
        Me.GridBeneficios.OptionsPrint.AutoWidth = False
        Me.GridBeneficios.OptionsView.ColumnAutoWidth = False
        Me.GridBeneficios.OptionsView.ShowFooter = True
        Me.GridBeneficios.OptionsView.ShowGroupPanel = False
        Me.GridBeneficios.OptionsView.ShowIndicator = False
        '
        'NavBarGroupControlContainer4
        '
        Me.NavBarGroupControlContainer4.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer4.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer4.Controls.Add(Me.GcArticulosBeneficios)
        Me.NavBarGroupControlContainer4.Name = "NavBarGroupControlContainer4"
        Me.NavBarGroupControlContainer4.Size = New System.Drawing.Size(363, 293)
        Me.NavBarGroupControlContainer4.TabIndex = 1
        '
        'GcArticulosBeneficios
        '
        Me.GcArticulosBeneficios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GcArticulosBeneficios.Location = New System.Drawing.Point(0, 0)
        Me.GcArticulosBeneficios.MainView = Me.GvArticulosBeneficios
        Me.GcArticulosBeneficios.Name = "GcArticulosBeneficios"
        Me.GcArticulosBeneficios.Size = New System.Drawing.Size(363, 293)
        Me.GcArticulosBeneficios.TabIndex = 0
        Me.GcArticulosBeneficios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvArticulosBeneficios})
        '
        'GvArticulosBeneficios
        '
        Me.GvArticulosBeneficios.GridControl = Me.GcArticulosBeneficios
        Me.GvArticulosBeneficios.Name = "GvArticulosBeneficios"
        Me.GvArticulosBeneficios.OptionsView.ColumnAutoWidth = False
        Me.GvArticulosBeneficios.OptionsView.ShowFooter = True
        Me.GvArticulosBeneficios.OptionsView.ShowGroupPanel = False
        '
        'NavArticulos
        '
        Me.NavArticulos.Caption = "Artículos"
        Me.NavArticulos.ControlContainer = Me.NavBarGroupControlContainer4
        Me.NavArticulos.GroupClientHeight = 184
        Me.NavArticulos.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavArticulos.Name = "NavArticulos"
        '
        'lblAVGRendimiento
        '
        Me.lblAVGRendimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAVGRendimiento.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAVGRendimiento.Location = New System.Drawing.Point(94, 90)
        Me.lblAVGRendimiento.Name = "lblAVGRendimiento"
        Me.lblAVGRendimiento.Size = New System.Drawing.Size(125, 19)
        Me.lblAVGRendimiento.TabIndex = 9
        Me.lblAVGRendimiento.Text = "0"
        Me.lblAVGRendimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(94, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "AVG. de rendimiento"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAVGventas
        '
        Me.lblAVGventas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAVGventas.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAVGventas.Location = New System.Drawing.Point(237, 90)
        Me.lblAVGventas.Name = "lblAVGventas"
        Me.lblAVGventas.Size = New System.Drawing.Size(125, 19)
        Me.lblAVGventas.TabIndex = 7
        Me.lblAVGventas.Text = "0"
        Me.lblAVGventas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(237, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "AVG. de ventas"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBeneficioPromedioGeneral
        '
        Me.lblBeneficioPromedioGeneral.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeneficioPromedioGeneral.Appearance.Options.UseFont = True
        Me.lblBeneficioPromedioGeneral.Location = New System.Drawing.Point(21, 22)
        Me.lblBeneficioPromedioGeneral.Name = "lblBeneficioPromedioGeneral"
        Me.lblBeneficioPromedioGeneral.Size = New System.Drawing.Size(53, 42)
        Me.lblBeneficioPromedioGeneral.TabIndex = 0
        Me.lblBeneficioPromedioGeneral.Text = "0%"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(268, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cantidad de ventas"
        '
        'lblCantidadVentas
        '
        Me.lblCantidadVentas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCantidadVentas.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantidadVentas.Location = New System.Drawing.Point(228, 41)
        Me.lblCantidadVentas.Name = "lblCantidadVentas"
        Me.lblCantidadVentas.Size = New System.Drawing.Size(141, 15)
        Me.lblCantidadVentas.TabIndex = 3
        Me.lblCantidadVentas.Text = "0"
        Me.lblCantidadVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.Location = New System.Drawing.Point(2, 51)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(385, 37)
        Me.SeparatorControl1.TabIndex = 1
        '
        'XtraTabControl3
        '
        Me.XtraTabControl3.Location = New System.Drawing.Point(746, 132)
        Me.XtraTabControl3.Name = "XtraTabControl3"
        Me.XtraTabControl3.SelectedTabPage = Me.XtraTabPage6
        Me.XtraTabControl3.Size = New System.Drawing.Size(392, 446)
        Me.XtraTabControl3.TabIndex = 11
        Me.XtraTabControl3.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage6, Me.XtraTabPage7})
        '
        'XtraTabPage6
        '
        Me.XtraTabPage6.Controls.Add(Me.SimpleButton2)
        Me.XtraTabPage6.Controls.Add(Me.GraficoParticipacionVentas)
        Me.XtraTabPage6.Controls.Add(Me.GroupControl3)
        Me.XtraTabPage6.Name = "XtraTabPage6"
        Me.XtraTabPage6.Padding = New System.Windows.Forms.Padding(2)
        Me.XtraTabPage6.Size = New System.Drawing.Size(386, 418)
        Me.XtraTabPage6.Text = "Gráficos"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(338, 10)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(38, 38)
        Me.SimpleButton2.TabIndex = 9
        '
        'GraficoParticipacionVentas
        '
        Me.GraficoParticipacionVentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GraficoParticipacionVentas.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.GraficoParticipacionVentas.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.GraficoParticipacionVentas.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.GraficoParticipacionVentas.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.GraficoParticipacionVentas.Legend.Direction = DevExpress.XtraCharts.LegendDirection.RightToLeft
        Me.GraficoParticipacionVentas.Legend.Name = "Default Legend"
        Me.GraficoParticipacionVentas.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.GraficoParticipacionVentas.Location = New System.Drawing.Point(2, 6)
        Me.GraficoParticipacionVentas.Name = "GraficoParticipacionVentas"
        Me.GraficoParticipacionVentas.PaletteName = "Apex"
        Me.GraficoParticipacionVentas.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.GraficoParticipacionVentas.Size = New System.Drawing.Size(379, 336)
        Me.GraficoParticipacionVentas.TabIndex = 4
        '
        'GroupControl3
        '
        Me.GroupControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl3.Controls.Add(Me.lblLugarCantidadVentas)
        Me.GroupControl3.Controls.Add(Me.LabelControl8)
        Me.GroupControl3.Controls.Add(Me.lblLugarVenta)
        Me.GroupControl3.Controls.Add(Me.LabelControl1)
        Me.GroupControl3.Controls.Add(Me.SeparatorControl2)
        Me.GroupControl3.Location = New System.Drawing.Point(2, 345)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(379, 70)
        Me.GroupControl3.TabIndex = 8
        Me.GroupControl3.Text = "Posiciones en ventas"
        '
        'lblLugarCantidadVentas
        '
        Me.lblLugarCantidadVentas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLugarCantidadVentas.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblLugarCantidadVentas.Appearance.Options.UseFont = True
        Me.lblLugarCantidadVentas.Location = New System.Drawing.Point(268, 38)
        Me.lblLugarCantidadVentas.Name = "lblLugarCantidadVentas"
        Me.lblLugarCantidadVentas.Size = New System.Drawing.Size(15, 29)
        Me.lblLugarCantidadVentas.TabIndex = 13
        Me.lblLugarCantidadVentas.Text = "0"
        '
        'LabelControl8
        '
        Me.LabelControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Location = New System.Drawing.Point(255, 21)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl8.TabIndex = 12
        Me.LabelControl8.Text = "Cantidad de ventas"
        '
        'lblLugarVenta
        '
        Me.lblLugarVenta.AllowHtmlString = True
        Me.lblLugarVenta.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblLugarVenta.Appearance.Options.UseFont = True
        Me.lblLugarVenta.Location = New System.Drawing.Point(33, 38)
        Me.lblLugarVenta.Name = "lblLugarVenta"
        Me.lblLugarVenta.Size = New System.Drawing.Size(15, 29)
        Me.lblLugarVenta.TabIndex = 9
        Me.lblLugarVenta.Text = "0"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(27, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl1.TabIndex = 8
        Me.LabelControl1.Text = "Montos de ventas"
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(4, 28)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(370, 20)
        Me.SeparatorControl2.TabIndex = 16
        '
        'XtraTabPage7
        '
        Me.XtraTabPage7.Controls.Add(Me.GcParticipacionVentas)
        Me.XtraTabPage7.Name = "XtraTabPage7"
        Me.XtraTabPage7.Padding = New System.Windows.Forms.Padding(5)
        Me.XtraTabPage7.Size = New System.Drawing.Size(386, 418)
        Me.XtraTabPage7.Text = "Datos"
        '
        'GcParticipacionVentas
        '
        Me.GcParticipacionVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GcParticipacionVentas.Location = New System.Drawing.Point(5, 5)
        Me.GcParticipacionVentas.MainView = Me.GvParticipacionVentas
        Me.GcParticipacionVentas.Name = "GcParticipacionVentas"
        Me.GcParticipacionVentas.Size = New System.Drawing.Size(376, 408)
        Me.GcParticipacionVentas.TabIndex = 9
        Me.GcParticipacionVentas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvParticipacionVentas})
        '
        'GvParticipacionVentas
        '
        Me.GvParticipacionVentas.GridControl = Me.GcParticipacionVentas
        Me.GvParticipacionVentas.Name = "GvParticipacionVentas"
        Me.GvParticipacionVentas.OptionsBehavior.AutoExpandAllGroups = True
        Me.GvParticipacionVentas.OptionsBehavior.Editable = False
        Me.GvParticipacionVentas.OptionsBehavior.ReadOnly = True
        Me.GvParticipacionVentas.OptionsPrint.AutoWidth = False
        Me.GvParticipacionVentas.OptionsView.ColumnAutoWidth = False
        Me.GvParticipacionVentas.OptionsView.ShowFooter = True
        Me.GvParticipacionVentas.OptionsView.ShowGroupPanel = False
        Me.GvParticipacionVentas.OptionsView.ShowIndicator = False
        '
        'XTabVentas
        '
        Me.XTabVentas.Location = New System.Drawing.Point(12, 132)
        Me.XTabVentas.Name = "XTabVentas"
        Me.XTabVentas.SelectedTabPage = Me.XtraTabPage3
        Me.XTabVentas.Size = New System.Drawing.Size(730, 446)
        Me.XTabVentas.TabIndex = 14
        Me.XTabVentas.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage3, Me.XtraTabPage9, Me.XtraTabPage11})
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.XtraTabControl2)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Padding = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.XtraTabPage3.Size = New System.Drawing.Size(724, 418)
        Me.XtraTabPage3.Text = "Histórico de ventas por empleados"
        '
        'XtraTabControl2
        '
        Me.XtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl2.Location = New System.Drawing.Point(3, 3)
        Me.XtraTabControl2.Name = "XtraTabControl2"
        Me.XtraTabControl2.SelectedTabPage = Me.XtraTabPage4
        Me.XtraTabControl2.Size = New System.Drawing.Size(720, 412)
        Me.XtraTabControl2.TabIndex = 7
        Me.XtraTabControl2.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage4, Me.XtraTabPage5})
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.Controls.Add(Me.SimpleButton1)
        Me.XtraTabPage4.Controls.Add(Me.cbxTiempo)
        Me.XtraTabPage4.Controls.Add(Me.GraficoVentasEmpleados)
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(714, 384)
        Me.XtraTabPage4.Text = "Gráfico"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(673, 343)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(38, 38)
        Me.SimpleButton1.TabIndex = 6
        '
        'cbxTiempo
        '
        Me.cbxTiempo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxTiempo.Location = New System.Drawing.Point(892, 11)
        Me.cbxTiempo.Name = "cbxTiempo"
        Me.cbxTiempo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxTiempo.Properties.Items.AddRange(New Object() {"Días", "Semanas", "Meses", "Cuartos", "Años"})
        Me.cbxTiempo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbxTiempo.Size = New System.Drawing.Size(100, 20)
        Me.cbxTiempo.TabIndex = 5
        Me.cbxTiempo.TabStop = False
        '
        'GraficoVentasEmpleados
        '
        Me.GraficoVentasEmpleados.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.GraficoVentasEmpleados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GraficoVentasEmpleados.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.GraficoVentasEmpleados.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.GraficoVentasEmpleados.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker
        Me.GraficoVentasEmpleados.Legend.Name = "Default Legend"
        Me.GraficoVentasEmpleados.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.GraficoVentasEmpleados.Location = New System.Drawing.Point(0, 0)
        Me.GraficoVentasEmpleados.Name = "GraficoVentasEmpleados"
        Me.GraficoVentasEmpleados.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.GraficoVentasEmpleados.Size = New System.Drawing.Size(714, 384)
        Me.GraficoVentasEmpleados.TabIndex = 0
        '
        'XtraTabPage5
        '
        Me.XtraTabPage5.Controls.Add(Me.GcVentasEmpleados)
        Me.XtraTabPage5.Name = "XtraTabPage5"
        Me.XtraTabPage5.Padding = New System.Windows.Forms.Padding(2)
        Me.XtraTabPage5.Size = New System.Drawing.Size(714, 384)
        Me.XtraTabPage5.Text = "Datos"
        '
        'GcVentasEmpleados
        '
        Me.GcVentasEmpleados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GcVentasEmpleados.Location = New System.Drawing.Point(2, 2)
        Me.GcVentasEmpleados.MainView = Me.GvVentasEmpleados
        Me.GcVentasEmpleados.Name = "GcVentasEmpleados"
        Me.GcVentasEmpleados.Size = New System.Drawing.Size(710, 380)
        Me.GcVentasEmpleados.TabIndex = 1
        Me.GcVentasEmpleados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvVentasEmpleados})
        '
        'GvVentasEmpleados
        '
        Me.GvVentasEmpleados.GridControl = Me.GcVentasEmpleados
        Me.GvVentasEmpleados.Name = "GvVentasEmpleados"
        Me.GvVentasEmpleados.OptionsBehavior.Editable = False
        '
        'XtraTabPage9
        '
        Me.XtraTabPage9.Controls.Add(Me.XtraTabControl1)
        Me.XtraTabPage9.Name = "XtraTabPage9"
        Me.XtraTabPage9.Padding = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.XtraTabPage9.Size = New System.Drawing.Size(724, 418)
        Me.XtraTabPage9.Text = "Comparación de ventas por períodos"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(3, 3)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(720, 412)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.SplitContainer1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(714, 384)
        Me.XtraTabPage1.Text = "Gráfico"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GraficoComparacionPeriodos)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SimpleButton4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ChkDeposito)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkCheque)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkTarjeta)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkEfectivo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LabelControl2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cbxAgrupacionVentasPeriodos)
        Me.SplitContainer1.Size = New System.Drawing.Size(714, 384)
        Me.SplitContainer1.SplitterDistance = 330
        Me.SplitContainer1.TabIndex = 8
        '
        'GraficoComparacionPeriodos
        '
        Me.GraficoComparacionPeriodos.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.GraficoComparacionPeriodos.ContextMenuStrip = Me.CMenuGraficos
        Me.GraficoComparacionPeriodos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GraficoComparacionPeriodos.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.GraficoComparacionPeriodos.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.GraficoComparacionPeriodos.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker
        Me.GraficoComparacionPeriodos.Legend.Name = "Default Legend"
        Me.GraficoComparacionPeriodos.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.GraficoComparacionPeriodos.Location = New System.Drawing.Point(0, 0)
        Me.GraficoComparacionPeriodos.Name = "GraficoComparacionPeriodos"
        Me.GraficoComparacionPeriodos.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.GraficoComparacionPeriodos.Size = New System.Drawing.Size(714, 330)
        Me.GraficoComparacionPeriodos.TabIndex = 6
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(672, 7)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(38, 38)
        Me.SimpleButton4.TabIndex = 7
        '
        'ChkDeposito
        '
        Me.ChkDeposito.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ChkDeposito.Location = New System.Drawing.Point(507, 16)
        Me.ChkDeposito.Name = "ChkDeposito"
        Me.ChkDeposito.Properties.Caption = "Depósitos y Transferencias"
        Me.ChkDeposito.Size = New System.Drawing.Size(159, 19)
        Me.ChkDeposito.TabIndex = 12
        '
        'chkCheque
        '
        Me.chkCheque.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.chkCheque.Location = New System.Drawing.Point(432, 16)
        Me.chkCheque.Name = "chkCheque"
        Me.chkCheque.Properties.Caption = "Cheque"
        Me.chkCheque.Size = New System.Drawing.Size(75, 19)
        Me.chkCheque.TabIndex = 11
        '
        'chkTarjeta
        '
        Me.chkTarjeta.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.chkTarjeta.Location = New System.Drawing.Point(358, 16)
        Me.chkTarjeta.Name = "chkTarjeta"
        Me.chkTarjeta.Properties.Caption = "Tarjeta"
        Me.chkTarjeta.Size = New System.Drawing.Size(75, 19)
        Me.chkTarjeta.TabIndex = 10
        '
        'chkEfectivo
        '
        Me.chkEfectivo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.chkEfectivo.Location = New System.Drawing.Point(284, 16)
        Me.chkEfectivo.Name = "chkEfectivo"
        Me.chkEfectivo.Properties.Caption = "Efectivo"
        Me.chkEfectivo.Size = New System.Drawing.Size(75, 19)
        Me.chkEfectivo.TabIndex = 9
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(6, 5)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "Agrupación"
        '
        'cbxAgrupacionVentasPeriodos
        '
        Me.cbxAgrupacionVentasPeriodos.Location = New System.Drawing.Point(6, 21)
        Me.cbxAgrupacionVentasPeriodos.Name = "cbxAgrupacionVentasPeriodos"
        Me.cbxAgrupacionVentasPeriodos.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxAgrupacionVentasPeriodos.Properties.Items.AddRange(New Object() {"Días", "Semanas", "Meses", "Cuartos", "Años"})
        Me.cbxAgrupacionVentasPeriodos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbxAgrupacionVentasPeriodos.Size = New System.Drawing.Size(100, 20)
        Me.cbxAgrupacionVentasPeriodos.TabIndex = 7
        Me.cbxAgrupacionVentasPeriodos.TabStop = False
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GcVentasPeriodos)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.XtraTabPage2.Size = New System.Drawing.Size(714, 384)
        Me.XtraTabPage2.Text = "Datos"
        '
        'GcVentasPeriodos
        '
        Me.GcVentasPeriodos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GcVentasPeriodos.Location = New System.Drawing.Point(2, 2)
        Me.GcVentasPeriodos.MainView = Me.GvVentasPeriodos
        Me.GcVentasPeriodos.Name = "GcVentasPeriodos"
        Me.GcVentasPeriodos.Size = New System.Drawing.Size(710, 380)
        Me.GcVentasPeriodos.TabIndex = 2
        Me.GcVentasPeriodos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvVentasPeriodos})
        '
        'GvVentasPeriodos
        '
        Me.GvVentasPeriodos.GridControl = Me.GcVentasPeriodos
        Me.GvVentasPeriodos.Name = "GvVentasPeriodos"
        Me.GvVentasPeriodos.OptionsBehavior.Editable = False
        Me.GvVentasPeriodos.OptionsView.ShowFooter = True
        '
        'XtraTabPage11
        '
        Me.XtraTabPage11.Controls.Add(Me.XtraTabControl6)
        Me.XtraTabPage11.Name = "XtraTabPage11"
        Me.XtraTabPage11.Padding = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.XtraTabPage11.Size = New System.Drawing.Size(724, 418)
        Me.XtraTabPage11.Text = "Ingresos y gastos"
        '
        'XtraTabControl6
        '
        Me.XtraTabControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl6.Location = New System.Drawing.Point(3, 3)
        Me.XtraTabControl6.Name = "XtraTabControl6"
        Me.XtraTabControl6.SelectedTabPage = Me.XtraTabPage12
        Me.XtraTabControl6.Size = New System.Drawing.Size(720, 412)
        Me.XtraTabControl6.TabIndex = 0
        Me.XtraTabControl6.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage12, Me.XtraTabPage13})
        '
        'XtraTabPage12
        '
        Me.XtraTabPage12.Controls.Add(Me.SplitContainer2)
        Me.XtraTabPage12.Name = "XtraTabPage12"
        Me.XtraTabPage12.Size = New System.Drawing.Size(714, 384)
        Me.XtraTabPage12.Text = "Gráfico"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GraficoIngresovsGastos)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SimpleButton5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.LabelControl3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ComboBoxEdit2)
        Me.SplitContainer2.Size = New System.Drawing.Size(714, 384)
        Me.SplitContainer2.SplitterDistance = 330
        Me.SplitContainer2.TabIndex = 1
        '
        'GraficoIngresovsGastos
        '
        Me.GraficoIngresovsGastos.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.GraficoIngresovsGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GraficoIngresovsGastos.Legend.Name = "Default Legend"
        Me.GraficoIngresovsGastos.Location = New System.Drawing.Point(0, 0)
        Me.GraficoIngresovsGastos.Name = "GraficoIngresovsGastos"
        Me.GraficoIngresovsGastos.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.GraficoIngresovsGastos.Size = New System.Drawing.Size(714, 330)
        Me.GraficoIngresovsGastos.TabIndex = 0
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton5.ImageOptions.Image = CType(resources.GetObject("SimpleButton5.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton5.Location = New System.Drawing.Point(672, 7)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(38, 38)
        Me.SimpleButton5.TabIndex = 11
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(6, 5)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "Agrupación"
        '
        'ComboBoxEdit2
        '
        Me.ComboBoxEdit2.Location = New System.Drawing.Point(6, 21)
        Me.ComboBoxEdit2.Name = "ComboBoxEdit2"
        Me.ComboBoxEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit2.Properties.Items.AddRange(New Object() {"Días", "Semanas", "Meses", "Cuartos", "Años"})
        Me.ComboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit2.Size = New System.Drawing.Size(100, 20)
        Me.ComboBoxEdit2.TabIndex = 9
        Me.ComboBoxEdit2.TabStop = False
        '
        'XtraTabPage13
        '
        Me.XtraTabPage13.Controls.Add(Me.XtraTabControl7)
        Me.XtraTabPage13.Name = "XtraTabPage13"
        Me.XtraTabPage13.Padding = New System.Windows.Forms.Padding(2)
        Me.XtraTabPage13.Size = New System.Drawing.Size(714, 384)
        Me.XtraTabPage13.Text = "Datos"
        '
        'XtraTabControl7
        '
        Me.XtraTabControl7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl7.Location = New System.Drawing.Point(2, 2)
        Me.XtraTabControl7.Name = "XtraTabControl7"
        Me.XtraTabControl7.SelectedTabPage = Me.XtraTabPage14
        Me.XtraTabControl7.Size = New System.Drawing.Size(710, 380)
        Me.XtraTabControl7.TabIndex = 3
        Me.XtraTabControl7.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage14, Me.XtraTabPage15})
        '
        'XtraTabPage14
        '
        Me.XtraTabPage14.Controls.Add(Me.GcIngresosVsGastos)
        Me.XtraTabPage14.Name = "XtraTabPage14"
        Me.XtraTabPage14.Padding = New System.Windows.Forms.Padding(2)
        Me.XtraTabPage14.Size = New System.Drawing.Size(704, 352)
        Me.XtraTabPage14.Text = "Ingresos"
        '
        'GcIngresosVsGastos
        '
        Me.GcIngresosVsGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GcIngresosVsGastos.Location = New System.Drawing.Point(2, 2)
        Me.GcIngresosVsGastos.MainView = Me.GvIngresosVsGastos
        Me.GcIngresosVsGastos.Name = "GcIngresosVsGastos"
        Me.GcIngresosVsGastos.Size = New System.Drawing.Size(700, 348)
        Me.GcIngresosVsGastos.TabIndex = 2
        Me.GcIngresosVsGastos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvIngresosVsGastos})
        '
        'GvIngresosVsGastos
        '
        Me.GvIngresosVsGastos.GridControl = Me.GcIngresosVsGastos
        Me.GvIngresosVsGastos.Name = "GvIngresosVsGastos"
        Me.GvIngresosVsGastos.OptionsBehavior.Editable = False
        Me.GvIngresosVsGastos.OptionsView.ShowFooter = True
        '
        'XtraTabPage15
        '
        Me.XtraTabPage15.Controls.Add(Me.GDGastos)
        Me.XtraTabPage15.Name = "XtraTabPage15"
        Me.XtraTabPage15.Padding = New System.Windows.Forms.Padding(2)
        Me.XtraTabPage15.Size = New System.Drawing.Size(704, 352)
        Me.XtraTabPage15.Text = "Gastos"
        '
        'GDGastos
        '
        Me.GDGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GDGastos.Location = New System.Drawing.Point(2, 2)
        Me.GDGastos.MainView = Me.GVGastos
        Me.GDGastos.Name = "GDGastos"
        Me.GDGastos.Size = New System.Drawing.Size(700, 348)
        Me.GDGastos.TabIndex = 3
        Me.GDGastos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVGastos})
        '
        'GVGastos
        '
        Me.GVGastos.GridControl = Me.GDGastos
        Me.GVGastos.Name = "GVGastos"
        Me.GVGastos.OptionsBehavior.Editable = False
        Me.GVGastos.OptionsView.ShowFooter = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GroupControl1)
        Me.LayoutControl1.Controls.Add(Me.XtraTabControl3)
        Me.LayoutControl1.Controls.Add(Me.XtraTabControl4)
        Me.LayoutControl1.Controls.Add(Me.XTabVentas)
        Me.LayoutControl1.Controls.Add(Me.GroupControl2)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1059, 437, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1167, 744)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table
        Me.LayoutControlGroup1.Name = "Root"
        ColumnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent
        ColumnDefinition1.Width = 65.0R
        ColumnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent
        ColumnDefinition2.Width = 35.0R
        Me.LayoutControlGroup1.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(New DevExpress.XtraLayout.ColumnDefinition() {ColumnDefinition1, ColumnDefinition2})
        RowDefinition1.Height = 120.0R
        RowDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute
        RowDefinition2.Height = 450.0R
        RowDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute
        RowDefinition3.Height = 500.0R
        RowDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute
        RowDefinition4.Height = 250.0R
        RowDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute
        Me.LayoutControlGroup1.OptionsTableLayoutGroup.RowDefinitions.AddRange(New DevExpress.XtraLayout.RowDefinition() {RowDefinition1, RowDefinition2, RowDefinition3, RowDefinition4})
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1150, 1340)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GroupControl2
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 2
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1130, 120)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.XTabVentas
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.OptionsTableLayoutItem.RowIndex = 1
        Me.LayoutControlItem2.Size = New System.Drawing.Size(734, 450)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.XtraTabControl4
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 570)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.OptionsTableLayoutItem.RowIndex = 2
        Me.LayoutControlItem3.Size = New System.Drawing.Size(734, 500)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.XtraTabControl3
        Me.LayoutControlItem4.Location = New System.Drawing.Point(734, 120)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 1
        Me.LayoutControlItem4.OptionsTableLayoutItem.RowIndex = 1
        Me.LayoutControlItem4.Size = New System.Drawing.Size(396, 450)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GroupControl1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(734, 570)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 1
        Me.LayoutControlItem5.OptionsTableLayoutItem.RowIndex = 2
        Me.LayoutControlItem5.Size = New System.Drawing.Size(396, 500)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'frm_estadisticas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 744)
        Me.ControlBox = False
        Me.Controls.Add(Me.LayoutControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "frm_estadisticas"
        Me.Text = "Estadísticas"
        CType(Me.XtraTabControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl4.ResumeLayout(False)
        Me.XtraTabPage8.ResumeLayout(False)
        CType(Me.XtraTabControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl5.ResumeLayout(False)
        Me.XtraTabPage10.ResumeLayout(False)
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarControl1.ResumeLayout(False)
        Me.NavBarGroupControlContainer1.ResumeLayout(False)
        CType(Me.GraficoArticulosMasVendidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuGraficos.ResumeLayout(False)
        Me.NavBarGroupControlContainer2.ResumeLayout(False)
        CType(Me.NupCantArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.cbxUsuarios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTodos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFoto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.NavBarControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarControl2.ResumeLayout(False)
        Me.NavBarGroupControlContainer3.ResumeLayout(False)
        CType(Me.GridVentasBeneficios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridBeneficios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarGroupControlContainer4.ResumeLayout(False)
        CType(Me.GcArticulosBeneficios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvArticulosBeneficios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl3.ResumeLayout(False)
        Me.XtraTabPage6.ResumeLayout(False)
        CType(Me.GraficoParticipacionVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage7.ResumeLayout(False)
        CType(Me.GcParticipacionVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvParticipacionVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTabVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTabVentas.ResumeLayout(False)
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl2.ResumeLayout(False)
        Me.XtraTabPage4.ResumeLayout(False)
        CType(Me.cbxTiempo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GraficoVentasEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage5.ResumeLayout(False)
        CType(Me.GcVentasEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvVentasEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage9.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GraficoComparacionPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkDeposito.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCheque.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTarjeta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEfectivo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxAgrupacionVentasPeriodos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GcVentasPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvVentasPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage11.ResumeLayout(False)
        CType(Me.XtraTabControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl6.ResumeLayout(False)
        Me.XtraTabPage12.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.GraficoIngresovsGastos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage13.ResumeLayout(False)
        CType(Me.XtraTabControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl7.ResumeLayout(False)
        Me.XtraTabPage14.ResumeLayout(False)
        CType(Me.GcIngresosVsGastos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvIngresosVsGastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage15.ResumeLayout(False)
        CType(Me.GDGastos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVGastos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XtraTabControl2 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents cbxTiempo As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents GraficoVentasEmpleados As XtraCharts.ChartControl
    Friend WithEvents XtraTabPage5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GcVentasEmpleados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GvVentasEmpleados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabControl3 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage6 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GraficoParticipacionVentas As DevExpress.XtraCharts.ChartControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblLugarCantidadVentas As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLugarVenta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents XtraTabPage7 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GcParticipacionVentas As DevExpress.XtraGrid.GridControl
    Friend WithEvents GvParticipacionVentas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabControl4 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage8 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabControl5 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage10 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GcArticulosBeneficios As DevExpress.XtraGrid.GridControl
    Friend WithEvents GvArticulosBeneficios As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridVentasBeneficios As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridBeneficios As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblAVGRendimiento As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblAVGventas As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblBeneficioPromedioGeneral As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCantidadVentas As Label
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkTodos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnActualizar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PicFoto As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpInicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DtpFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavGraficoArticulosVentas As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroupControlContainer1 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents GraficoArticulosMasVendidos As DevExpress.XtraCharts.ChartControl
    Friend WithEvents NavBarGroupControlContainer2 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NavDatosArticulosMsVendidos As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarControl2 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavFacturas As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroupControlContainer3 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents NavBarGroupControlContainer4 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents NavArticulos As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NupCantArticulos As NumericUpDown
    Friend WithEvents XTabVentas As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage9 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblPuesto As Label
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents cbxAgrupacionVentasPeriodos As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents GraficoComparacionPeriodos As DevExpress.XtraCharts.ChartControl
    Friend WithEvents GcVentasPeriodos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GvVentasPeriodos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ChkDeposito As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCheque As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTarjeta As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkEfectivo As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents XtraTabPage11 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabControl6 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage12 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GraficoIngresovsGastos As DevExpress.XtraCharts.ChartControl
    Friend WithEvents XtraTabPage13 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GcIngresosVsGastos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GvIngresosVsGastos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ComboBoxEdit2 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents CMenuGraficos As ContextMenuStrip
    Friend WithEvents IrAArtículosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents QuitarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cbxUsuarios As XtraEditors.ImageComboBoxEdit
    Friend WithEvents XtraTabControl7 As XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage14 As XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage15 As XtraTab.XtraTabPage
    Friend WithEvents GDGastos As XtraGrid.GridControl
    Friend WithEvents GVGastos As XtraGrid.Views.Grid.GridView
End Class
