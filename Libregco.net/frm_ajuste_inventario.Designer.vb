<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ajuste_inventario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ajuste_inventario))
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarAjusteInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIDAjuste = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.AccordionContentContainer1 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.txtBuscar = New DevExpress.XtraEditors.ButtonEdit()
        Me.btnparentezo = New System.Windows.Forms.Button()
        Me.btnGarantia = New System.Windows.Forms.Button()
        Me.btnTipoItbis = New System.Windows.Forms.Button()
        Me.btnMedida = New System.Windows.Forms.Button()
        Me.btnCategoria = New System.Windows.Forms.Button()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.btnDepartamento = New System.Windows.Forms.Button()
        Me.btnSubCategoria = New System.Windows.Forms.Button()
        Me.btnSuplidor = New System.Windows.Forms.Button()
        Me.btnBuscarTipoProducto = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtParentezco = New System.Windows.Forms.TextBox()
        Me.txtIDParental = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtGarantia = New System.Windows.Forms.TextBox()
        Me.txtTipoItbis = New System.Windows.Forms.TextBox()
        Me.txtIDGarantia = New System.Windows.Forms.TextBox()
        Me.txtIDTipoItbis = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMedida = New System.Windows.Forms.TextBox()
        Me.txtIDMedida = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtSubCategoria = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtIDSubCategoria = New System.Windows.Forms.TextBox()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox()
        Me.txtIDTipoProducto = New System.Windows.Forms.TextBox()
        Me.txtIDMarca = New System.Windows.Forms.TextBox()
        Me.txtIDCategoria = New System.Windows.Forms.TextBox()
        Me.AccordionContentContainer4 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtInventarioCant = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbxInventario = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.CbxExistencia = New System.Windows.Forms.ComboBox()
        Me.AccordionContentContainer2 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.AccordionContentContainer5 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.chkPrecios = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbxTipoFiltro = New System.Windows.Forms.ComboBox()
        Me.cbxPrecio1 = New System.Windows.Forms.ComboBox()
        Me.cbxPrecio2 = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.AccordionContentContainer3 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbxComision = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.cbxNoPagoTarjeta = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.cbxQrcode = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cbxImagen = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cbxCodigoBarra = New System.Windows.Forms.ComboBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.chkBloqueoCredito = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.chkRevisado = New System.Windows.Forms.ComboBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.chkPreAlertar = New System.Windows.Forms.ComboBox()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.cbxHabSeries = New System.Windows.Forms.ComboBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.cbxDescontinuado = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cbxVenderCosto = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.cbxDevolucion = New System.Windows.Forms.ComboBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cbxPromocion = New System.Windows.Forms.ComboBox()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement5 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement6 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SpinEdit1 = New DevExpress.XtraEditors.SpinEdit()
        Me.NavigationPane2 = New DevExpress.XtraBars.Navigation.NavigationPane()
        Me.NavigationPage1 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.NavigationPage2 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.AccordionControl2 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.AccordionContentContainer6 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.AccordionContentContainer7 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.AccordionControlElement7 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement8 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement9 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.MenuBarra.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccordionControl1.SuspendLayout()
        Me.AccordionContentContainer1.SuspendLayout()
        CType(Me.txtBuscar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccordionContentContainer4.SuspendLayout()
        Me.AccordionContentContainer2.SuspendLayout()
        Me.AccordionContentContainer5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.AccordionContentContainer3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.SpinEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavigationPane2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationPane2.SuspendLayout()
        Me.NavigationPage1.SuspendLayout()
        Me.NavigationPage2.SuspendLayout()
        CType(Me.AccordionControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccordionControl2.SuspendLayout()
        Me.AccordionContentContainer6.SuspendLayout()
        Me.AccordionContentContainer7.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(1125, 24)
        Me.MenuBarra.TabIndex = 246
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'NuevoRegistroToolStripMenuItem
        '
        Me.NuevoRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.NuevoRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoRegistroToolStripMenuItem.Name = "NuevoRegistroToolStripMenuItem"
        Me.NuevoRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(211, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(211, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(211, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Artículo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(208, 6)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(211, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(211, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarAjusteInventarioToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'BuscarAjusteInventarioToolStripMenuItem
        '
        Me.BuscarAjusteInventarioToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarAjusteInventarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarAjusteInventarioToolStripMenuItem.Name = "BuscarAjusteInventarioToolStripMenuItem"
        Me.BuscarAjusteInventarioToolStripMenuItem.Size = New System.Drawing.Size(217, 38)
        Me.BuscarAjusteInventarioToolStripMenuItem.Text = "Buscar Ajuste Inventario"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(217, 38)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaLibregcoToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AyudaLibregcoToolStripMenuItem
        '
        Me.AyudaLibregcoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.LibregcoCircle_x32
        Me.AyudaLibregcoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(173, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(86, 624)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Motivos del ajuste"
        '
        'txtReferencia
        '
        Me.txtReferencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReferencia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtReferencia.Location = New System.Drawing.Point(186, 621)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReferencia.Size = New System.Drawing.Size(759, 20)
        Me.txtReferencia.TabIndex = 2
        '
        'txtComentario
        '
        Me.txtComentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComentario.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtComentario.Location = New System.Drawing.Point(186, 647)
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(934, 20)
        Me.txtComentario.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(86, 650)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 260
        Me.Label4.Text = "Observaciones"
        '
        'txtFecha
        '
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFecha.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFecha.Location = New System.Drawing.Point(144, 86)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(61, 13)
        Me.txtFecha.TabIndex = 247
        Me.txtFecha.Visible = False
        '
        'txtHora
        '
        Me.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtHora.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHora.Location = New System.Drawing.Point(204, 86)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(68, 13)
        Me.txtHora.TabIndex = 245
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHora.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(86, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 244
        Me.Label6.Text = "Fecha"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(86, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 243
        Me.Label7.Text = "# Ajuste"
        '
        'txtIDAjuste
        '
        Me.txtIDAjuste.Enabled = False
        Me.txtIDAjuste.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDAjuste.Location = New System.Drawing.Point(148, 33)
        Me.txtIDAjuste.Name = "txtIDAjuste"
        Me.txtIDAjuste.ReadOnly = True
        Me.txtIDAjuste.Size = New System.Drawing.Size(50, 20)
        Me.txtIDAjuste.TabIndex = 242
        Me.txtIDAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIDAjuste.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(951, 624)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "Almacén"
        '
        'CbxAlmacen
        '
        Me.CbxAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxAlmacen.FormattingEnabled = True
        Me.CbxAlmacen.Location = New System.Drawing.Point(1000, 620)
        Me.CbxAlmacen.Name = "CbxAlmacen"
        Me.CbxAlmacen.Size = New System.Drawing.Size(120, 21)
        Me.CbxAlmacen.TabIndex = 1
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Location = New System.Drawing.Point(1065, 132)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(48, 17)
        Me.ChkNulo.TabIndex = 266
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'txtSecondID
        '
        Me.txtSecondID.BackColor = System.Drawing.SystemColors.Control
        Me.txtSecondID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecondID.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtSecondID.Location = New System.Drawing.Point(89, 54)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.Size = New System.Drawing.Size(199, 29)
        Me.txtSecondID.TabIndex = 248
        Me.txtSecondID.TabStop = False
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(690, 25)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 327
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnAnular, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(434, 99)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAnular
        '
        Me.btnAnular.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(84, 95)
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnImprimir
        '
        Me.btnImprimir.Checked = True
        Me.btnImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x72
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 95)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 675)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1125, 25)
        Me.BarraEstado.TabIndex = 328
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLogo
        '
        Me.PicLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(23, 22)
        '
        'NameSys
        '
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.NameSys.Name = "NameSys"
        Me.NameSys.Size = New System.Drawing.Size(63, 22)
        Me.NameSys.Text = "Libregco"
        '
        'ToolSeparator2
        '
        Me.ToolSeparator2.Name = "ToolSeparator2"
        Me.ToolSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(32, 22)
        Me.lblStatusBar.Text = "Listo"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(89, 132)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1031, 481)
        Me.GridControl1.TabIndex = 332
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer1)
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer4)
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer2)
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer5)
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer3)
        Me.AccordionControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1})
        Me.AccordionControl1.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ShowGroupExpandButtons = False
        Me.AccordionControl1.ShowItemExpandButtons = False
        Me.AccordionControl1.Size = New System.Drawing.Size(429, 605)
        Me.AccordionControl1.TabIndex = 111
        Me.AccordionControl1.Text = "AccordionControl1"
        '
        'AccordionContentContainer1
        '
        Me.AccordionContentContainer1.Controls.Add(Me.txtBuscar)
        Me.AccordionContentContainer1.Controls.Add(Me.btnparentezo)
        Me.AccordionContentContainer1.Controls.Add(Me.btnGarantia)
        Me.AccordionContentContainer1.Controls.Add(Me.btnTipoItbis)
        Me.AccordionContentContainer1.Controls.Add(Me.btnMedida)
        Me.AccordionContentContainer1.Controls.Add(Me.btnCategoria)
        Me.AccordionContentContainer1.Controls.Add(Me.btnMarca)
        Me.AccordionContentContainer1.Controls.Add(Me.btnDepartamento)
        Me.AccordionContentContainer1.Controls.Add(Me.btnSubCategoria)
        Me.AccordionContentContainer1.Controls.Add(Me.btnSuplidor)
        Me.AccordionContentContainer1.Controls.Add(Me.btnBuscarTipoProducto)
        Me.AccordionContentContainer1.Controls.Add(Me.Label28)
        Me.AccordionContentContainer1.Controls.Add(Me.txtParentezco)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDParental)
        Me.AccordionContentContainer1.Controls.Add(Me.Label14)
        Me.AccordionContentContainer1.Controls.Add(Me.Label12)
        Me.AccordionContentContainer1.Controls.Add(Me.txtGarantia)
        Me.AccordionContentContainer1.Controls.Add(Me.txtTipoItbis)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDGarantia)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDTipoItbis)
        Me.AccordionContentContainer1.Controls.Add(Me.Label13)
        Me.AccordionContentContainer1.Controls.Add(Me.txtMedida)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDMedida)
        Me.AccordionContentContainer1.Controls.Add(Me.Label15)
        Me.AccordionContentContainer1.Controls.Add(Me.Label16)
        Me.AccordionContentContainer1.Controls.Add(Me.txtSuplidor)
        Me.AccordionContentContainer1.Controls.Add(Me.txtCategoria)
        Me.AccordionContentContainer1.Controls.Add(Me.txtDepartamento)
        Me.AccordionContentContainer1.Controls.Add(Me.txtSubCategoria)
        Me.AccordionContentContainer1.Controls.Add(Me.txtMarca)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDSubCategoria)
        Me.AccordionContentContainer1.Controls.Add(Me.txtTipoProducto)
        Me.AccordionContentContainer1.Controls.Add(Me.Label17)
        Me.AccordionContentContainer1.Controls.Add(Me.Label19)
        Me.AccordionContentContainer1.Controls.Add(Me.Label21)
        Me.AccordionContentContainer1.Controls.Add(Me.Label22)
        Me.AccordionContentContainer1.Controls.Add(Me.Label23)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDSuplidor)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDDepartamento)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDTipoProducto)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDMarca)
        Me.AccordionContentContainer1.Controls.Add(Me.txtIDCategoria)
        Me.AccordionContentContainer1.Name = "AccordionContentContainer1"
        Me.AccordionContentContainer1.Size = New System.Drawing.Size(412, 322)
        Me.AccordionContentContainer1.TabIndex = 1
        '
        'txtBuscar
        '
        Me.txtBuscar.EditValue = ""
        Me.txtBuscar.Location = New System.Drawing.Point(15, 16)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtBuscar.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBuscar.Properties.Appearance.Options.UseFont = True
        Me.txtBuscar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", 30, True, True, True, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", "Search", Nothing, DevExpress.Utils.ToolTipAnchor.[Default]), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "Limpiar", 30, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", "Clear", Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtBuscar.Properties.LookAndFeel.SkinName = "Office 2013 Light Gray"
        Me.txtBuscar.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtBuscar.Properties.NullText = "Escriba el/los artículos a buscar"
        Me.txtBuscar.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtBuscar.Properties.ShowNullValuePromptWhenFocused = True
        Me.txtBuscar.Size = New System.Drawing.Size(392, 22)
        Me.txtBuscar.TabIndex = 270
        '
        'btnparentezo
        '
        Me.btnparentezo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnparentezo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnparentezo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnparentezo.Image = CType(resources.GetObject("btnparentezo.Image"), System.Drawing.Image)
        Me.btnparentezo.Location = New System.Drawing.Point(180, 294)
        Me.btnparentezo.Name = "btnparentezo"
        Me.btnparentezo.Size = New System.Drawing.Size(23, 23)
        Me.btnparentezo.TabIndex = 268
        Me.btnparentezo.UseVisualStyleBackColor = True
        '
        'btnGarantia
        '
        Me.btnGarantia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGarantia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGarantia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGarantia.Image = CType(resources.GetObject("btnGarantia.Image"), System.Drawing.Image)
        Me.btnGarantia.Location = New System.Drawing.Point(180, 265)
        Me.btnGarantia.Name = "btnGarantia"
        Me.btnGarantia.Size = New System.Drawing.Size(23, 23)
        Me.btnGarantia.TabIndex = 264
        Me.btnGarantia.UseVisualStyleBackColor = True
        '
        'btnTipoItbis
        '
        Me.btnTipoItbis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoItbis.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoItbis.Image = CType(resources.GetObject("btnTipoItbis.Image"), System.Drawing.Image)
        Me.btnTipoItbis.Location = New System.Drawing.Point(180, 236)
        Me.btnTipoItbis.Name = "btnTipoItbis"
        Me.btnTipoItbis.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoItbis.TabIndex = 260
        Me.btnTipoItbis.UseVisualStyleBackColor = True
        '
        'btnMedida
        '
        Me.btnMedida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMedida.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMedida.Image = CType(resources.GetObject("btnMedida.Image"), System.Drawing.Image)
        Me.btnMedida.Location = New System.Drawing.Point(180, 207)
        Me.btnMedida.Name = "btnMedida"
        Me.btnMedida.Size = New System.Drawing.Size(23, 23)
        Me.btnMedida.TabIndex = 114
        Me.btnMedida.UseVisualStyleBackColor = True
        '
        'btnCategoria
        '
        Me.btnCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCategoria.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCategoria.Image = CType(resources.GetObject("btnCategoria.Image"), System.Drawing.Image)
        Me.btnCategoria.Location = New System.Drawing.Point(180, 98)
        Me.btnCategoria.Name = "btnCategoria"
        Me.btnCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnCategoria.TabIndex = 5
        Me.btnCategoria.UseVisualStyleBackColor = True
        '
        'btnMarca
        '
        Me.btnMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMarca.Image = CType(resources.GetObject("btnMarca.Image"), System.Drawing.Image)
        Me.btnMarca.Location = New System.Drawing.Point(180, 179)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(23, 23)
        Me.btnMarca.TabIndex = 11
        Me.btnMarca.UseVisualStyleBackColor = True
        '
        'btnDepartamento
        '
        Me.btnDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDepartamento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDepartamento.Image = CType(resources.GetObject("btnDepartamento.Image"), System.Drawing.Image)
        Me.btnDepartamento.Location = New System.Drawing.Point(180, 71)
        Me.btnDepartamento.Name = "btnDepartamento"
        Me.btnDepartamento.Size = New System.Drawing.Size(23, 23)
        Me.btnDepartamento.TabIndex = 3
        Me.btnDepartamento.UseVisualStyleBackColor = True
        '
        'btnSubCategoria
        '
        Me.btnSubCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSubCategoria.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnSubCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSubCategoria.Image = CType(resources.GetObject("btnSubCategoria.Image"), System.Drawing.Image)
        Me.btnSubCategoria.Location = New System.Drawing.Point(180, 125)
        Me.btnSubCategoria.Name = "btnSubCategoria"
        Me.btnSubCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnSubCategoria.TabIndex = 7
        Me.btnSubCategoria.UseVisualStyleBackColor = True
        '
        'btnSuplidor
        '
        Me.btnSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSuplidor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSuplidor.Image = CType(resources.GetObject("btnSuplidor.Image"), System.Drawing.Image)
        Me.btnSuplidor.Location = New System.Drawing.Point(180, 152)
        Me.btnSuplidor.Name = "btnSuplidor"
        Me.btnSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnSuplidor.TabIndex = 9
        Me.btnSuplidor.UseVisualStyleBackColor = True
        '
        'btnBuscarTipoProducto
        '
        Me.btnBuscarTipoProducto.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscarTipoProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarTipoProducto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTipoProducto.Image = CType(resources.GetObject("btnBuscarTipoProducto.Image"), System.Drawing.Image)
        Me.btnBuscarTipoProducto.Location = New System.Drawing.Point(180, 44)
        Me.btnBuscarTipoProducto.Name = "btnBuscarTipoProducto"
        Me.btnBuscarTipoProducto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoProducto.TabIndex = 1
        Me.btnBuscarTipoProducto.UseVisualStyleBackColor = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.Location = New System.Drawing.Point(12, 296)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(50, 15)
        Me.Label28.TabIndex = 266
        Me.Label28.Text = "Parental"
        '
        'txtParentezco
        '
        Me.txtParentezco.Enabled = False
        Me.txtParentezco.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtParentezco.Location = New System.Drawing.Point(202, 294)
        Me.txtParentezco.Name = "txtParentezco"
        Me.txtParentezco.ReadOnly = True
        Me.txtParentezco.Size = New System.Drawing.Size(205, 23)
        Me.txtParentezco.TabIndex = 269
        '
        'txtIDParental
        '
        Me.txtIDParental.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDParental.Location = New System.Drawing.Point(115, 294)
        Me.txtIDParental.Name = "txtIDParental"
        Me.txtIDParental.Size = New System.Drawing.Size(66, 23)
        Me.txtIDParental.TabIndex = 267
        Me.txtIDParental.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(12, 269)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 15)
        Me.Label14.TabIndex = 262
        Me.Label14.Text = "Garantía"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(12, 240)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 15)
        Me.Label12.TabIndex = 258
        Me.Label12.Text = "Tipo de Itbis"
        '
        'txtGarantia
        '
        Me.txtGarantia.Enabled = False
        Me.txtGarantia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGarantia.Location = New System.Drawing.Point(202, 265)
        Me.txtGarantia.Name = "txtGarantia"
        Me.txtGarantia.ReadOnly = True
        Me.txtGarantia.Size = New System.Drawing.Size(205, 23)
        Me.txtGarantia.TabIndex = 265
        '
        'txtTipoItbis
        '
        Me.txtTipoItbis.Enabled = False
        Me.txtTipoItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoItbis.Location = New System.Drawing.Point(202, 236)
        Me.txtTipoItbis.Name = "txtTipoItbis"
        Me.txtTipoItbis.ReadOnly = True
        Me.txtTipoItbis.Size = New System.Drawing.Size(205, 23)
        Me.txtTipoItbis.TabIndex = 261
        '
        'txtIDGarantia
        '
        Me.txtIDGarantia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDGarantia.Location = New System.Drawing.Point(115, 265)
        Me.txtIDGarantia.Name = "txtIDGarantia"
        Me.txtIDGarantia.Size = New System.Drawing.Size(66, 23)
        Me.txtIDGarantia.TabIndex = 263
        Me.txtIDGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDTipoItbis
        '
        Me.txtIDTipoItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoItbis.Location = New System.Drawing.Point(115, 236)
        Me.txtIDTipoItbis.Name = "txtIDTipoItbis"
        Me.txtIDTipoItbis.Size = New System.Drawing.Size(66, 23)
        Me.txtIDTipoItbis.TabIndex = 259
        Me.txtIDTipoItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(12, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 15)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "Medida"
        '
        'txtMedida
        '
        Me.txtMedida.Enabled = False
        Me.txtMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMedida.Location = New System.Drawing.Point(202, 207)
        Me.txtMedida.Name = "txtMedida"
        Me.txtMedida.ReadOnly = True
        Me.txtMedida.Size = New System.Drawing.Size(205, 23)
        Me.txtMedida.TabIndex = 115
        '
        'txtIDMedida
        '
        Me.txtIDMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMedida.Location = New System.Drawing.Point(115, 207)
        Me.txtIDMedida.Name = "txtIDMedida"
        Me.txtIDMedida.Size = New System.Drawing.Size(66, 23)
        Me.txtIDMedida.TabIndex = 113
        Me.txtIDMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(12, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(178, 13)
        Me.Label15.TabIndex = 111
        Me.Label15.Text = "Escriba el artículo que desea buscar"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(12, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 15)
        Me.Label16.TabIndex = 87
        Me.Label16.Text = "Tipo de Producto"
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Enabled = False
        Me.txtSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSuplidor.Location = New System.Drawing.Point(202, 152)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.ReadOnly = True
        Me.txtSuplidor.Size = New System.Drawing.Size(205, 23)
        Me.txtSuplidor.TabIndex = 104
        '
        'txtCategoria
        '
        Me.txtCategoria.Enabled = False
        Me.txtCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCategoria.Location = New System.Drawing.Point(202, 98)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(205, 23)
        Me.txtCategoria.TabIndex = 100
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDepartamento.Location = New System.Drawing.Point(202, 71)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(205, 23)
        Me.txtDepartamento.TabIndex = 92
        '
        'txtSubCategoria
        '
        Me.txtSubCategoria.Enabled = False
        Me.txtSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubCategoria.Location = New System.Drawing.Point(202, 125)
        Me.txtSubCategoria.Name = "txtSubCategoria"
        Me.txtSubCategoria.ReadOnly = True
        Me.txtSubCategoria.Size = New System.Drawing.Size(205, 23)
        Me.txtSubCategoria.TabIndex = 96
        '
        'txtMarca
        '
        Me.txtMarca.Enabled = False
        Me.txtMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMarca.Location = New System.Drawing.Point(202, 179)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(205, 23)
        Me.txtMarca.TabIndex = 108
        '
        'txtIDSubCategoria
        '
        Me.txtIDSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSubCategoria.Location = New System.Drawing.Point(115, 125)
        Me.txtIDSubCategoria.Name = "txtIDSubCategoria"
        Me.txtIDSubCategoria.Size = New System.Drawing.Size(66, 23)
        Me.txtIDSubCategoria.TabIndex = 6
        Me.txtIDSubCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.Enabled = False
        Me.txtTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoProducto.Location = New System.Drawing.Point(202, 44)
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.ReadOnly = True
        Me.txtTipoProducto.Size = New System.Drawing.Size(205, 23)
        Me.txtTipoProducto.TabIndex = 89
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(12, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 15)
        Me.Label17.TabIndex = 85
        Me.Label17.Text = "Departamento"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(12, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 15)
        Me.Label19.TabIndex = 93
        Me.Label19.Text = "Sub-Categoría"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(12, 183)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 15)
        Me.Label21.TabIndex = 105
        Me.Label21.Text = "Marca"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(12, 155)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 15)
        Me.Label22.TabIndex = 101
        Me.Label22.Text = "Suplidor"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(12, 101)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 15)
        Me.Label23.TabIndex = 97
        Me.Label23.Text = "Categoría"
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.Location = New System.Drawing.Point(115, 152)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.Size = New System.Drawing.Size(66, 23)
        Me.txtIDSuplidor.TabIndex = 8
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDDepartamento.Location = New System.Drawing.Point(115, 71)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.Size = New System.Drawing.Size(66, 23)
        Me.txtIDDepartamento.TabIndex = 2
        Me.txtIDDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDTipoProducto
        '
        Me.txtIDTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoProducto.Location = New System.Drawing.Point(115, 44)
        Me.txtIDTipoProducto.Name = "txtIDTipoProducto"
        Me.txtIDTipoProducto.Size = New System.Drawing.Size(66, 23)
        Me.txtIDTipoProducto.TabIndex = 0
        Me.txtIDTipoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDMarca
        '
        Me.txtIDMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMarca.Location = New System.Drawing.Point(115, 179)
        Me.txtIDMarca.Name = "txtIDMarca"
        Me.txtIDMarca.Size = New System.Drawing.Size(66, 23)
        Me.txtIDMarca.TabIndex = 10
        Me.txtIDMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDCategoria
        '
        Me.txtIDCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCategoria.Location = New System.Drawing.Point(115, 98)
        Me.txtIDCategoria.Name = "txtIDCategoria"
        Me.txtIDCategoria.Size = New System.Drawing.Size(66, 23)
        Me.txtIDCategoria.TabIndex = 4
        Me.txtIDCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccordionContentContainer4
        '
        Me.AccordionContentContainer4.Controls.Add(Me.Label24)
        Me.AccordionContentContainer4.Controls.Add(Me.txtInventarioCant)
        Me.AccordionContentContainer4.Controls.Add(Me.Label25)
        Me.AccordionContentContainer4.Controls.Add(Me.cbxInventario)
        Me.AccordionContentContainer4.Controls.Add(Me.Label26)
        Me.AccordionContentContainer4.Controls.Add(Me.CbxExistencia)
        Me.AccordionContentContainer4.Name = "AccordionContentContainer4"
        Me.AccordionContentContainer4.Size = New System.Drawing.Size(412, 75)
        Me.AccordionContentContainer4.TabIndex = 5
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(256, 40)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(25, 13)
        Me.Label24.TabIndex = 100
        Me.Label24.Text = "que"
        '
        'txtInventarioCant
        '
        Me.txtInventarioCant.Location = New System.Drawing.Point(287, 37)
        Me.txtInventarioCant.Name = "txtInventarioCant"
        Me.txtInventarioCant.Size = New System.Drawing.Size(72, 20)
        Me.txtInventarioCant.TabIndex = 99
        Me.txtInventarioCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(14, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 13)
        Me.Label25.TabIndex = 98
        Me.Label25.Text = "Inventario"
        '
        'cbxInventario
        '
        Me.cbxInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxInventario.FormattingEnabled = True
        Me.cbxInventario.Items.AddRange(New Object() {"Todos", "Menor o Igual", "Menor", "Mayor", "Mayor o Igual", "Diferente", "Igual"})
        Me.cbxInventario.Location = New System.Drawing.Point(87, 37)
        Me.cbxInventario.Name = "cbxInventario"
        Me.cbxInventario.Size = New System.Drawing.Size(163, 21)
        Me.cbxInventario.TabIndex = 97
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(14, 11)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(55, 13)
        Me.Label26.TabIndex = 94
        Me.Label26.Text = "Existencia"
        '
        'CbxExistencia
        '
        Me.CbxExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxExistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxExistencia.FormattingEnabled = True
        Me.CbxExistencia.Items.AddRange(New Object() {"Todas", "Por debajo del mínimo", "Por encima del máximo"})
        Me.CbxExistencia.Location = New System.Drawing.Point(87, 8)
        Me.CbxExistencia.Name = "CbxExistencia"
        Me.CbxExistencia.Size = New System.Drawing.Size(163, 21)
        Me.CbxExistencia.TabIndex = 93
        '
        'AccordionContentContainer2
        '
        Me.AccordionContentContainer2.Controls.Add(Me.SimpleButton2)
        Me.AccordionContentContainer2.Controls.Add(Me.SimpleButton1)
        Me.AccordionContentContainer2.Name = "AccordionContentContainer2"
        Me.AccordionContentContainer2.Size = New System.Drawing.Size(412, 28)
        Me.AccordionContentContainer2.TabIndex = 3
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(151, 1)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(94, 23)
        Me.SimpleButton2.TabIndex = 2
        Me.SimpleButton2.Text = "+ Incluír"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(15, 1)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(130, 23)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "- Excluir"
        '
        'AccordionContentContainer5
        '
        Me.AccordionContentContainer5.Controls.Add(Me.chkPrecios)
        Me.AccordionContentContainer5.Controls.Add(Me.GroupBox2)
        Me.AccordionContentContainer5.Name = "AccordionContentContainer5"
        Me.AccordionContentContainer5.Size = New System.Drawing.Size(412, 85)
        Me.AccordionContentContainer5.TabIndex = 7
        '
        'chkPrecios
        '
        Me.chkPrecios.AutoSize = True
        Me.chkPrecios.Checked = True
        Me.chkPrecios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrecios.Location = New System.Drawing.Point(14, 35)
        Me.chkPrecios.Name = "chkPrecios"
        Me.chkPrecios.Size = New System.Drawing.Size(55, 17)
        Me.chkPrecios.TabIndex = 137
        Me.chkPrecios.Text = "Todos"
        Me.chkPrecios.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxTipoFiltro)
        Me.GroupBox2.Controls.Add(Me.cbxPrecio1)
        Me.GroupBox2.Controls.Add(Me.cbxPrecio2)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(43, -4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(362, 83)
        Me.GroupBox2.TabIndex = 136
        Me.GroupBox2.TabStop = False
        '
        'cbxTipoFiltro
        '
        Me.cbxTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoFiltro.FormattingEnabled = True
        Me.cbxTipoFiltro.Items.AddRange(New Object() {"Menor o Igual", "Menor", "Mayor", "Mayor o Igual", "Diferente", "Igual"})
        Me.cbxTipoFiltro.Location = New System.Drawing.Point(32, 20)
        Me.cbxTipoFiltro.Name = "cbxTipoFiltro"
        Me.cbxTipoFiltro.Size = New System.Drawing.Size(134, 21)
        Me.cbxTipoFiltro.TabIndex = 134
        '
        'cbxPrecio1
        '
        Me.cbxPrecio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPrecio1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPrecio1.FormattingEnabled = True
        Me.cbxPrecio1.Items.AddRange(New Object() {"Costo", "Costo Final", "Precio A", "Precio B", "Precio C", "Precio D", "Precio E"})
        Me.cbxPrecio1.Location = New System.Drawing.Point(32, 49)
        Me.cbxPrecio1.Name = "cbxPrecio1"
        Me.cbxPrecio1.Size = New System.Drawing.Size(134, 21)
        Me.cbxPrecio1.TabIndex = 135
        '
        'cbxPrecio2
        '
        Me.cbxPrecio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPrecio2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPrecio2.FormattingEnabled = True
        Me.cbxPrecio2.Items.AddRange(New Object() {"Costo", "Costo Final", "Precio A", "Precio B", "Precio C", "Precio D", "Precio E"})
        Me.cbxPrecio2.Location = New System.Drawing.Point(207, 49)
        Me.cbxPrecio2.Name = "cbxPrecio2"
        Me.cbxPrecio2.Size = New System.Drawing.Size(134, 21)
        Me.cbxPrecio2.TabIndex = 96
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(167, 49)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(40, 23)
        Me.Label29.TabIndex = 136
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AccordionContentContainer3
        '
        Me.AccordionContentContainer3.Controls.Add(Me.Label27)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxComision)
        Me.AccordionContentContainer3.Controls.Add(Me.Label40)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxNoPagoTarjeta)
        Me.AccordionContentContainer3.Controls.Add(Me.Label41)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxQrcode)
        Me.AccordionContentContainer3.Controls.Add(Me.Label42)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxImagen)
        Me.AccordionContentContainer3.Controls.Add(Me.Label43)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxCodigoBarra)
        Me.AccordionContentContainer3.Controls.Add(Me.Label44)
        Me.AccordionContentContainer3.Controls.Add(Me.chkBloqueoCredito)
        Me.AccordionContentContainer3.Controls.Add(Me.Label45)
        Me.AccordionContentContainer3.Controls.Add(Me.chkRevisado)
        Me.AccordionContentContainer3.Controls.Add(Me.Label46)
        Me.AccordionContentContainer3.Controls.Add(Me.Label47)
        Me.AccordionContentContainer3.Controls.Add(Me.chkPreAlertar)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxEstado)
        Me.AccordionContentContainer3.Controls.Add(Me.Label48)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxHabSeries)
        Me.AccordionContentContainer3.Controls.Add(Me.Label49)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxDescontinuado)
        Me.AccordionContentContainer3.Controls.Add(Me.Label50)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxVenderCosto)
        Me.AccordionContentContainer3.Controls.Add(Me.Label51)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxDevolucion)
        Me.AccordionContentContainer3.Controls.Add(Me.Label52)
        Me.AccordionContentContainer3.Controls.Add(Me.cbxPromocion)
        Me.AccordionContentContainer3.Name = "AccordionContentContainer3"
        Me.AccordionContentContainer3.Size = New System.Drawing.Size(412, 218)
        Me.AccordionContentContainer3.TabIndex = 4
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(8, 125)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(49, 13)
        Me.Label27.TabIndex = 132
        Me.Label27.Text = "Comisión"
        '
        'cbxComision
        '
        Me.cbxComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxComision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxComision.FormattingEnabled = True
        Me.cbxComision.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxComision.Location = New System.Drawing.Point(115, 122)
        Me.cbxComision.Name = "cbxComision"
        Me.cbxComision.Size = New System.Drawing.Size(92, 21)
        Me.cbxComision.TabIndex = 131
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(218, 154)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(83, 13)
        Me.Label40.TabIndex = 130
        Me.Label40.Text = "No pago tarjeta"
        '
        'cbxNoPagoTarjeta
        '
        Me.cbxNoPagoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNoPagoTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNoPagoTarjeta.FormattingEnabled = True
        Me.cbxNoPagoTarjeta.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxNoPagoTarjeta.Location = New System.Drawing.Point(312, 151)
        Me.cbxNoPagoTarjeta.Name = "cbxNoPagoTarjeta"
        Me.cbxNoPagoTarjeta.Size = New System.Drawing.Size(93, 21)
        Me.cbxNoPagoTarjeta.TabIndex = 129
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(8, 154)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(50, 13)
        Me.Label41.TabIndex = 128
        Me.Label41.Text = "QR Code"
        '
        'cbxQrcode
        '
        Me.cbxQrcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxQrcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxQrcode.FormattingEnabled = True
        Me.cbxQrcode.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxQrcode.Location = New System.Drawing.Point(114, 151)
        Me.cbxQrcode.Name = "cbxQrcode"
        Me.cbxQrcode.Size = New System.Drawing.Size(93, 21)
        Me.cbxQrcode.TabIndex = 127
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(8, 183)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(62, 13)
        Me.Label42.TabIndex = 126
        Me.Label42.Text = "Imágen(es)"
        '
        'cbxImagen
        '
        Me.cbxImagen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxImagen.FormattingEnabled = True
        Me.cbxImagen.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxImagen.Location = New System.Drawing.Point(114, 180)
        Me.cbxImagen.Name = "cbxImagen"
        Me.cbxImagen.Size = New System.Drawing.Size(93, 21)
        Me.cbxImagen.TabIndex = 125
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(218, 126)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(69, 13)
        Me.Label43.TabIndex = 124
        Me.Label43.Text = "Código barra"
        '
        'cbxCodigoBarra
        '
        Me.cbxCodigoBarra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCodigoBarra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCodigoBarra.FormattingEnabled = True
        Me.cbxCodigoBarra.Items.AddRange(New Object() {"Todos", "Con códigos", "Sin códigos"})
        Me.cbxCodigoBarra.Location = New System.Drawing.Point(312, 122)
        Me.cbxCodigoBarra.Name = "cbxCodigoBarra"
        Me.cbxCodigoBarra.Size = New System.Drawing.Size(93, 21)
        Me.cbxCodigoBarra.TabIndex = 123
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(218, 96)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(90, 13)
        Me.Label44.TabIndex = 122
        Me.Label44.Text = "Bloqueo a crédito"
        '
        'chkBloqueoCredito
        '
        Me.chkBloqueoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chkBloqueoCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBloqueoCredito.FormattingEnabled = True
        Me.chkBloqueoCredito.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.chkBloqueoCredito.Location = New System.Drawing.Point(312, 93)
        Me.chkBloqueoCredito.Name = "chkBloqueoCredito"
        Me.chkBloqueoCredito.Size = New System.Drawing.Size(93, 21)
        Me.chkBloqueoCredito.TabIndex = 121
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(218, 67)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(51, 13)
        Me.Label45.TabIndex = 120
        Me.Label45.Text = "Revisado"
        '
        'chkRevisado
        '
        Me.chkRevisado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chkRevisado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRevisado.FormattingEnabled = True
        Me.chkRevisado.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.chkRevisado.Location = New System.Drawing.Point(312, 64)
        Me.chkRevisado.Name = "chkRevisado"
        Me.chkRevisado.Size = New System.Drawing.Size(93, 21)
        Me.chkRevisado.TabIndex = 119
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(218, 183)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(40, 13)
        Me.Label46.TabIndex = 96
        Me.Label46.Text = "Estado"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(218, 38)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(56, 13)
        Me.Label47.TabIndex = 118
        Me.Label47.Text = "Prealertas"
        '
        'chkPreAlertar
        '
        Me.chkPreAlertar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chkPreAlertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPreAlertar.FormattingEnabled = True
        Me.chkPreAlertar.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.chkPreAlertar.Location = New System.Drawing.Point(312, 35)
        Me.chkPreAlertar.Name = "chkPreAlertar"
        Me.chkPreAlertar.Size = New System.Drawing.Size(93, 21)
        Me.chkPreAlertar.TabIndex = 117
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Todos", "Sólo Activos", "Nulos"})
        Me.cbxEstado.Location = New System.Drawing.Point(312, 180)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(93, 21)
        Me.cbxEstado.TabIndex = 95
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(218, 9)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(36, 13)
        Me.Label48.TabIndex = 116
        Me.Label48.Text = "Series"
        '
        'cbxHabSeries
        '
        Me.cbxHabSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxHabSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxHabSeries.FormattingEnabled = True
        Me.cbxHabSeries.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxHabSeries.Location = New System.Drawing.Point(312, 6)
        Me.cbxHabSeries.Name = "cbxHabSeries"
        Me.cbxHabSeries.Size = New System.Drawing.Size(93, 21)
        Me.cbxHabSeries.TabIndex = 115
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(8, 96)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(78, 13)
        Me.Label49.TabIndex = 114
        Me.Label49.Text = "Descontinuado"
        '
        'cbxDescontinuado
        '
        Me.cbxDescontinuado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDescontinuado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDescontinuado.FormattingEnabled = True
        Me.cbxDescontinuado.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxDescontinuado.Location = New System.Drawing.Point(115, 93)
        Me.cbxDescontinuado.Name = "cbxDescontinuado"
        Me.cbxDescontinuado.Size = New System.Drawing.Size(92, 21)
        Me.cbxDescontinuado.TabIndex = 113
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(8, 67)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(81, 13)
        Me.Label50.TabIndex = 112
        Me.Label50.Text = "Vender al costo"
        '
        'cbxVenderCosto
        '
        Me.cbxVenderCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVenderCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxVenderCosto.FormattingEnabled = True
        Me.cbxVenderCosto.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxVenderCosto.Location = New System.Drawing.Point(115, 64)
        Me.cbxVenderCosto.Name = "cbxVenderCosto"
        Me.cbxVenderCosto.Size = New System.Drawing.Size(92, 21)
        Me.cbxVenderCosto.TabIndex = 111
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(8, 38)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(106, 13)
        Me.Label51.TabIndex = 110
        Me.Label51.Text = "Devolucion permitida"
        '
        'cbxDevolucion
        '
        Me.cbxDevolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDevolucion.FormattingEnabled = True
        Me.cbxDevolucion.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxDevolucion.Location = New System.Drawing.Point(115, 35)
        Me.cbxDevolucion.Name = "cbxDevolucion"
        Me.cbxDevolucion.Size = New System.Drawing.Size(92, 21)
        Me.cbxDevolucion.TabIndex = 109
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(8, 9)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(71, 13)
        Me.Label52.TabIndex = 108
        Me.Label52.Text = "En promoción"
        '
        'cbxPromocion
        '
        Me.cbxPromocion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPromocion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPromocion.FormattingEnabled = True
        Me.cbxPromocion.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxPromocion.Location = New System.Drawing.Point(115, 6)
        Me.cbxPromocion.Name = "cbxPromocion"
        Me.cbxPromocion.Size = New System.Drawing.Size(92, 21)
        Me.cbxPromocion.TabIndex = 107
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement2, Me.AccordionControlElement4, Me.AccordionControlElement5, Me.AccordionControlElement3, Me.AccordionControlElement6})
        Me.AccordionControlElement1.Expanded = True
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Text = "Criterios de búsqueda"
        '
        'AccordionControlElement2
        '
        Me.AccordionControlElement2.ContentContainer = Me.AccordionContentContainer1
        Me.AccordionControlElement2.Expanded = True
        Me.AccordionControlElement2.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Editor_24
        Me.AccordionControlElement2.Name = "AccordionControlElement2"
        Me.AccordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement2.Text = "Clasificación"
        '
        'AccordionControlElement4
        '
        Me.AccordionControlElement4.ContentContainer = Me.AccordionContentContainer3
        Me.AccordionControlElement4.Expanded = True
        Me.AccordionControlElement4.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Message_Edit_24
        Me.AccordionControlElement4.Name = "AccordionControlElement4"
        Me.AccordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement4.Text = "Condicionales"
        '
        'AccordionControlElement5
        '
        Me.AccordionControlElement5.ContentContainer = Me.AccordionContentContainer4
        Me.AccordionControlElement5.Expanded = True
        Me.AccordionControlElement5.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Inventory_24
        Me.AccordionControlElement5.Name = "AccordionControlElement5"
        Me.AccordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement5.Text = "Inventario"
        '
        'AccordionControlElement3
        '
        Me.AccordionControlElement3.ContentContainer = Me.AccordionContentContainer2
        Me.AccordionControlElement3.Expanded = True
        Me.AccordionControlElement3.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Filter_Edit_24
        Me.AccordionControlElement3.Name = "AccordionControlElement3"
        Me.AccordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement3.Text = "Filtración"
        '
        'AccordionControlElement6
        '
        Me.AccordionControlElement6.ContentContainer = Me.AccordionContentContainer5
        Me.AccordionControlElement6.Expanded = True
        Me.AccordionControlElement6.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Pricex24
        Me.AccordionControlElement6.Name = "AccordionControlElement6"
        Me.AccordionControlElement6.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement6.Text = "Precios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSeleccionarTodo)
        Me.GroupBox1.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(412, 98)
        Me.GroupBox1.TabIndex = 267
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Propiedades"
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Checked = True
        Me.chkSeleccionarTodo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSeleccionarTodo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(9, -69)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(120, 17)
        Me.chkSeleccionarTodo.TabIndex = 268
        Me.chkSeleccionarTodo.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.CheckedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.ColumnWidth = 130
        Me.CheckedListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.HorizontalScrollbar = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"ID Ajuste", "ID Precios", "Código", "Descripción", "Referencia", "Medida", "Existencia", "Cantidad", "Resultado", "Tipo de ajuste", "Fraccionamiento", "Costo Unit.", "Importe"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(5, 18)
        Me.CheckedListBox1.MultiColumn = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(402, 75)
        Me.CheckedListBox1.TabIndex = 0
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.CheckedListBox2)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupControl3.Size = New System.Drawing.Size(412, 107)
        Me.GroupControl3.TabIndex = 0
        Me.GroupControl3.Text = "Esta opción congelará la posición de las columnas"
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.CheckedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.ColumnWidth = 130
        Me.CheckedListBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.HorizontalScrollbar = True
        Me.CheckedListBox2.Items.AddRange(New Object() {"ID Ajuste", "ID Precios", "Código", "Descripción", "Referencia", "Medida", "Existencia", "Cantidad", "Resultado", "Tipo de ajuste", "Fraccionamiento", "Costo Unit.", "Importe"})
        Me.CheckedListBox2.Location = New System.Drawing.Point(7, 25)
        Me.CheckedListBox2.MultiColumn = True
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(398, 75)
        Me.CheckedListBox2.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(95, 590)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 334
        Me.Label11.Text = "Límite de consulta"
        '
        'SpinEdit1
        '
        Me.SpinEdit1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SpinEdit1.EditValue = New Decimal(New Integer() {500, 0, 0, 0})
        Me.SpinEdit1.Location = New System.Drawing.Point(186, 588)
        Me.SpinEdit1.Name = "SpinEdit1"
        Me.SpinEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.SpinEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SpinEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SpinEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SpinEdit1.Properties.IsFloatValue = False
        Me.SpinEdit1.Properties.Mask.EditMask = "N00"
        Me.SpinEdit1.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.SpinEdit1.Properties.NullText = "0"
        Me.SpinEdit1.Properties.NullValuePrompt = "0"
        Me.SpinEdit1.Size = New System.Drawing.Size(69, 20)
        Me.SpinEdit1.TabIndex = 335
        '
        'NavigationPane2
        '
        Me.NavigationPane2.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.[False]
        Me.NavigationPane2.Appearance.BackColor = System.Drawing.Color.White
        Me.NavigationPane2.Appearance.Options.UseBackColor = True
        Me.NavigationPane2.Appearance.Options.UseTextOptions = True
        Me.NavigationPane2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.NavigationPane2.Controls.Add(Me.NavigationPage1)
        Me.NavigationPane2.Controls.Add(Me.NavigationPage2)
        Me.NavigationPane2.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavigationPane2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NavigationPane2.Location = New System.Drawing.Point(0, 24)
        Me.NavigationPane2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.NavigationPane2.Name = "NavigationPane2"
        Me.NavigationPane2.PageProperties.AllowHtmlDraw = False
        Me.NavigationPane2.PageProperties.AppearanceCaption.Options.UseTextOptions = True
        Me.NavigationPane2.PageProperties.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.NavigationPane2.PageProperties.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.NavigationPane2.PageProperties.ShowCollapseButton = False
        Me.NavigationPane2.PageProperties.ShowExpandButton = False
        Me.NavigationPane2.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Image
        Me.NavigationPane2.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NavigationPage1, Me.NavigationPage2})
        Me.NavigationPane2.RegularSize = New System.Drawing.Size(527, 651)
        Me.NavigationPane2.SelectedPage = Me.NavigationPage1
        Me.NavigationPane2.Size = New System.Drawing.Size(527, 651)
        Me.NavigationPane2.TabIndex = 336
        Me.NavigationPane2.TransitionType = DevExpress.Utils.Animation.Transitions.Clock
        '
        'NavigationPage1
        '
        Me.NavigationPage1.Caption = "Filtrado"
        Me.NavigationPage1.Controls.Add(Me.AccordionControl1)
        Me.NavigationPage1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NavigationPage1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NavigationPage1.ImageOptions.Image = Global.Libregco.My.Resources.Resources.fil2x64
        Me.NavigationPage1.Name = "NavigationPage1"
        Me.NavigationPage1.Size = New System.Drawing.Size(429, 605)
        '
        'NavigationPage2
        '
        Me.NavigationPage2.Caption = "Formato"
        Me.NavigationPage2.Controls.Add(Me.AccordionControl2)
        Me.NavigationPage2.ImageOptions.Image = Global.Libregco.My.Resources.Resources.tablex64
        Me.NavigationPage2.Name = "NavigationPage2"
        Me.NavigationPage2.Size = New System.Drawing.Size(429, 605)
        '
        'AccordionControl2
        '
        Me.AccordionControl2.Controls.Add(Me.AccordionContentContainer6)
        Me.AccordionControl2.Controls.Add(Me.AccordionContentContainer7)
        Me.AccordionControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.AccordionControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccordionControl2.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement7})
        Me.AccordionControl2.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl2.Name = "AccordionControl2"
        Me.AccordionControl2.Size = New System.Drawing.Size(429, 605)
        Me.AccordionControl2.TabIndex = 0
        Me.AccordionControl2.Text = "AccordionControl2"
        '
        'AccordionContentContainer6
        '
        Me.AccordionContentContainer6.Controls.Add(Me.GroupBox1)
        Me.AccordionContentContainer6.Name = "AccordionContentContainer6"
        Me.AccordionContentContainer6.Size = New System.Drawing.Size(412, 98)
        Me.AccordionContentContainer6.TabIndex = 1
        '
        'AccordionContentContainer7
        '
        Me.AccordionContentContainer7.Controls.Add(Me.GroupControl3)
        Me.AccordionContentContainer7.Name = "AccordionContentContainer7"
        Me.AccordionContentContainer7.Size = New System.Drawing.Size(412, 107)
        Me.AccordionContentContainer7.TabIndex = 2
        '
        'AccordionControlElement7
        '
        Me.AccordionControlElement7.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement8, Me.AccordionControlElement9})
        Me.AccordionControlElement7.Expanded = True
        Me.AccordionControlElement7.Name = "AccordionControlElement7"
        Me.AccordionControlElement7.Text = "Formato"
        '
        'AccordionControlElement8
        '
        Me.AccordionControlElement8.ContentContainer = Me.AccordionContentContainer6
        Me.AccordionControlElement8.Expanded = True
        Me.AccordionControlElement8.ImageOptions.Image = Global.Libregco.My.Resources.Resources.columnsx24
        Me.AccordionControlElement8.Name = "AccordionControlElement8"
        Me.AccordionControlElement8.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement8.Text = "Visual"
        '
        'AccordionControlElement9
        '
        Me.AccordionControlElement9.ContentContainer = Me.AccordionContentContainer7
        Me.AccordionControlElement9.Expanded = True
        Me.AccordionControlElement9.ImageOptions.Image = Global.Libregco.My.Resources.Resources.blockx24
        Me.AccordionControlElement9.Name = "AccordionControlElement9"
        Me.AccordionControlElement9.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement9.Text = "Freeze"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.SeparatorControl1.Location = New System.Drawing.Point(74, 24)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(19, 651)
        Me.SeparatorControl1.TabIndex = 337
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.WareHouse_x48, "Ajuste de inventario realizado", "El ajuste ha sido guardada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("33dfd5d7-dece-4a75-8aac-7f9c16ba326c", Global.Libregco.My.Resources.Resources.WareHouse_x48, "Ajuste modificada", "El ajuste ha sido modificada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'frm_ajuste_inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 700)
        Me.Controls.Add(Me.NavigationPane2)
        Me.Controls.Add(Me.SpinEdit1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CbxAlmacen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.txtSecondID)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.txtIDAjuste)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MenuBarra)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.txtComentario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_ajuste_inventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "17"
        Me.Text = "Ajuste de Inventario"
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccordionControl1.ResumeLayout(False)
        Me.AccordionContentContainer1.ResumeLayout(False)
        Me.AccordionContentContainer1.PerformLayout()
        CType(Me.txtBuscar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccordionContentContainer4.ResumeLayout(False)
        Me.AccordionContentContainer4.PerformLayout()
        Me.AccordionContentContainer2.ResumeLayout(False)
        Me.AccordionContentContainer5.ResumeLayout(False)
        Me.AccordionContentContainer5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.AccordionContentContainer3.ResumeLayout(False)
        Me.AccordionContentContainer3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.SpinEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavigationPane2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationPane2.ResumeLayout(False)
        Me.NavigationPage1.ResumeLayout(False)
        Me.NavigationPage2.ResumeLayout(False)
        CType(Me.AccordionControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccordionControl2.ResumeLayout(False)
        Me.AccordionContentContainer6.ResumeLayout(False)
        Me.AccordionContentContainer7.ResumeLayout(False)
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBarra As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIDAjuste As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents BuscarAjusteInventarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SpinEdit1 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label11 As Label
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents AccordionContentContainer1 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Private WithEvents btnparentezo As Button
    Private WithEvents btnGarantia As Button
    Private WithEvents btnTipoItbis As Button
    Private WithEvents btnMedida As Button
    Private WithEvents btnCategoria As Button
    Private WithEvents btnMarca As Button
    Private WithEvents btnDepartamento As Button
    Private WithEvents btnSubCategoria As Button
    Private WithEvents btnSuplidor As Button
    Private WithEvents btnBuscarTipoProducto As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents txtParentezco As TextBox
    Friend WithEvents txtIDParental As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtGarantia As TextBox
    Friend WithEvents txtTipoItbis As TextBox
    Friend WithEvents txtIDGarantia As TextBox
    Friend WithEvents txtIDTipoItbis As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMedida As TextBox
    Friend WithEvents txtIDMedida As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtSuplidor As TextBox
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents txtDepartamento As TextBox
    Friend WithEvents txtSubCategoria As TextBox
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents txtIDSubCategoria As TextBox
    Friend WithEvents txtTipoProducto As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtIDSuplidor As TextBox
    Friend WithEvents txtIDDepartamento As TextBox
    Friend WithEvents txtIDTipoProducto As TextBox
    Friend WithEvents txtIDMarca As TextBox
    Friend WithEvents txtIDCategoria As TextBox
    Friend WithEvents AccordionContentContainer4 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents Label24 As Label
    Friend WithEvents txtInventarioCant As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cbxInventario As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents CbxExistencia As ComboBox
    Friend WithEvents AccordionContentContainer2 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AccordionContentContainer5 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents chkPrecios As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbxTipoFiltro As ComboBox
    Friend WithEvents cbxPrecio1 As ComboBox
    Friend WithEvents cbxPrecio2 As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkSeleccionarTodo As CheckBox
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckedListBox2 As CheckedListBox
    Friend WithEvents AccordionContentContainer3 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents Label27 As Label
    Friend WithEvents cbxComision As ComboBox
    Friend WithEvents Label40 As Label
    Friend WithEvents cbxNoPagoTarjeta As ComboBox
    Friend WithEvents Label41 As Label
    Friend WithEvents cbxQrcode As ComboBox
    Friend WithEvents Label42 As Label
    Friend WithEvents cbxImagen As ComboBox
    Friend WithEvents Label43 As Label
    Friend WithEvents cbxCodigoBarra As ComboBox
    Friend WithEvents Label44 As Label
    Friend WithEvents chkBloqueoCredito As ComboBox
    Friend WithEvents Label45 As Label
    Friend WithEvents chkRevisado As ComboBox
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents chkPreAlertar As ComboBox
    Friend WithEvents cbxEstado As ComboBox
    Friend WithEvents Label48 As Label
    Friend WithEvents cbxHabSeries As ComboBox
    Friend WithEvents Label49 As Label
    Friend WithEvents cbxDescontinuado As ComboBox
    Friend WithEvents Label50 As Label
    Friend WithEvents cbxVenderCosto As ComboBox
    Friend WithEvents Label51 As Label
    Friend WithEvents cbxDevolucion As ComboBox
    Friend WithEvents Label52 As Label
    Friend WithEvents cbxPromocion As ComboBox
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement5 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement6 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtBuscar As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents NavigationPane2 As DevExpress.XtraBars.Navigation.NavigationPane
    Friend WithEvents NavigationPage1 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NavigationPage2 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents AccordionControl2 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents AccordionControlElement7 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionContentContainer6 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionContentContainer7 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionControlElement8 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement9 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
End Class
