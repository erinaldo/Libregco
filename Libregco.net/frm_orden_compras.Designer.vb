<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_orden_compras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_orden_compras))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuscarCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtIDOrdenCompra = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GbArticulos = New System.Windows.Forms.GroupBox()
        Me.PnItbis = New System.Windows.Forms.Panel()
        Me.rdbNoItbis = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.rdbIncluido = New System.Windows.Forms.RadioButton()
        Me.rdbNoIncluido = New System.Windows.Forms.RadioButton()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnBlanquearListado = New System.Windows.Forms.ToolStripButton()
        Me.btnQuitarArticulo = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.CbxMedida = New System.Windows.Forms.ComboBox()
        Me.txtCantidadArticulo = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtDescripcionArticulo = New System.Windows.Forms.TextBox()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.btnBuscarArticulo = New System.Windows.Forms.Button()
        Me.txtIDArticulo = New System.Windows.Forms.TextBox()
        Me.DgvArticulos = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.label18 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbSuplidor = New System.Windows.Forms.GroupBox()
        Me.txtUltimoMonto = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscarSup = New System.Windows.Forms.Button()
        Me.txtNombreSuplidor = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label15 = New System.Windows.Forms.Label()
        Me.txtBalanceSup = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.cbxStatusOrder = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.CbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.label14 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtItbis = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.GbArticulos.SuspendLayout()
        Me.PnItbis.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GbSuplidor.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(950, 24)
        Me.MenuStrip1.TabIndex = 234
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarArtículosToolStripMenuItem, Me.ToolStripSeparator1, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Suplidor"
        '
        'BuscarArtículosToolStripMenuItem
        '
        Me.BuscarArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarArtículosToolStripMenuItem.Name = "BuscarArtículosToolStripMenuItem"
        Me.BuscarArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BuscarArtículosToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.BuscarArtículosToolStripMenuItem.Text = "Buscar Artículos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(210, 6)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarToolStripMenuItem, Me.QuitarToolStripMenuItem, Me.ModificarToolStripMenuItem, Me.ToolStripSeparator2, Me.BuscarCompraToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'LimpiarToolStripMenuItem
        '
        Me.LimpiarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.LimpiarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LimpiarToolStripMenuItem.Name = "LimpiarToolStripMenuItem"
        Me.LimpiarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.LimpiarToolStripMenuItem.Size = New System.Drawing.Size(264, 38)
        Me.LimpiarToolStripMenuItem.Text = "Limpiar"
        '
        'QuitarToolStripMenuItem
        '
        Me.QuitarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarToolStripMenuItem.Name = "QuitarToolStripMenuItem"
        Me.QuitarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.QuitarToolStripMenuItem.Size = New System.Drawing.Size(264, 38)
        Me.QuitarToolStripMenuItem.Text = "Quitar"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.ModificarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(264, 38)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(261, 6)
        '
        'BuscarCompraToolStripMenuItem
        '
        Me.BuscarCompraToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarCompraToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarCompraToolStripMenuItem.Name = "BuscarCompraToolStripMenuItem"
        Me.BuscarCompraToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarCompraToolStripMenuItem.Size = New System.Drawing.Size(264, 38)
        Me.BuscarCompraToolStripMenuItem.Text = "Buscar Orden de Compra"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(264, 38)
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
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.txtIDOrdenCompra)
        Me.GbxUserInfo.Controls.Add(Me.Label7)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label3)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(599, 126)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(345, 78)
        Me.GbxUserInfo.TabIndex = 277
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(178, 19)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(157, 23)
        Me.txtSecondID.TabIndex = 254
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(63, 48)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 253
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDOrdenCompra
        '
        Me.txtIDOrdenCompra.Enabled = False
        Me.txtIDOrdenCompra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDOrdenCompra.Location = New System.Drawing.Point(63, 19)
        Me.txtIDOrdenCompra.Name = "txtIDOrdenCompra"
        Me.txtIDOrdenCompra.ReadOnly = True
        Me.txtIDOrdenCompra.Size = New System.Drawing.Size(109, 23)
        Me.txtIDOrdenCompra.TabIndex = 248
        Me.txtIDOrdenCompra.TabStop = False
        Me.txtIDOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(5, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Código"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(217, 46)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(118, 23)
        Me.txtHora.TabIndex = 251
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(178, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 252
        Me.Label3.Text = "Hora"
        '
        'GbArticulos
        '
        Me.GbArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbArticulos.Controls.Add(Me.PnItbis)
        Me.GbArticulos.Controls.Add(Me.BarraOpciones)
        Me.GbArticulos.Controls.Add(Me.CbxMedida)
        Me.GbArticulos.Controls.Add(Me.txtCantidadArticulo)
        Me.GbArticulos.Controls.Add(Me.txtPrecio)
        Me.GbArticulos.Controls.Add(Me.txtDescripcionArticulo)
        Me.GbArticulos.Controls.Add(Me.btnAplicar)
        Me.GbArticulos.Controls.Add(Me.btnBuscarArticulo)
        Me.GbArticulos.Controls.Add(Me.txtIDArticulo)
        Me.GbArticulos.Controls.Add(Me.DgvArticulos)
        Me.GbArticulos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GbArticulos.Location = New System.Drawing.Point(5, 204)
        Me.GbArticulos.Name = "GbArticulos"
        Me.GbArticulos.Size = New System.Drawing.Size(939, 325)
        Me.GbArticulos.TabIndex = 3
        Me.GbArticulos.TabStop = False
        Me.GbArticulos.Text = "Artículos"
        '
        'PnItbis
        '
        Me.PnItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnItbis.BackColor = System.Drawing.Color.Transparent
        Me.PnItbis.Controls.Add(Me.rdbNoItbis)
        Me.PnItbis.Controls.Add(Me.Label13)
        Me.PnItbis.Controls.Add(Me.rdbIncluido)
        Me.PnItbis.Controls.Add(Me.rdbNoIncluido)
        Me.PnItbis.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.PnItbis.Location = New System.Drawing.Point(635, 296)
        Me.PnItbis.Name = "PnItbis"
        Me.PnItbis.Size = New System.Drawing.Size(300, 23)
        Me.PnItbis.TabIndex = 252
        '
        'rdbNoItbis
        '
        Me.rdbNoItbis.AutoSize = True
        Me.rdbNoItbis.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbNoItbis.Location = New System.Drawing.Point(225, 3)
        Me.rdbNoItbis.Name = "rdbNoItbis"
        Me.rdbNoItbis.Size = New System.Drawing.Size(68, 17)
        Me.rdbNoItbis.TabIndex = 255
        Me.rdbNoItbis.Text = "No. Itbis"
        Me.rdbNoItbis.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 15)
        Me.Label13.TabIndex = 254
        Me.Label13.Text = "I.T.B.I.S"
        '
        'rdbIncluido
        '
        Me.rdbIncluido.AutoSize = True
        Me.rdbIncluido.Checked = True
        Me.rdbIncluido.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbIncluido.Location = New System.Drawing.Point(57, 3)
        Me.rdbIncluido.Name = "rdbIncluido"
        Me.rdbIncluido.Size = New System.Drawing.Size(65, 17)
        Me.rdbIncluido.TabIndex = 251
        Me.rdbIncluido.TabStop = True
        Me.rdbIncluido.Text = "Incluido"
        Me.rdbIncluido.UseVisualStyleBackColor = True
        '
        'rdbNoIncluido
        '
        Me.rdbNoIncluido.AutoSize = True
        Me.rdbNoIncluido.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbNoIncluido.Location = New System.Drawing.Point(132, 3)
        Me.rdbNoIncluido.Name = "rdbNoIncluido"
        Me.rdbNoIncluido.Size = New System.Drawing.Size(83, 17)
        Me.rdbNoIncluido.TabIndex = 253
        Me.rdbNoIncluido.Text = "No Incluido"
        Me.rdbNoIncluido.UseVisualStyleBackColor = True
        '
        'BarraOpciones
        '
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBlanquearListado, Me.btnQuitarArticulo, Me.btnModificar})
        Me.BarraOpciones.Location = New System.Drawing.Point(3, 297)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.BarraOpciones.Size = New System.Drawing.Size(933, 25)
        Me.BarraOpciones.TabIndex = 251
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'btnBlanquearListado
        '
        Me.btnBlanquearListado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBlanquearListado.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.btnBlanquearListado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlanquearListado.Name = "btnBlanquearListado"
        Me.btnBlanquearListado.Size = New System.Drawing.Size(134, 22)
        Me.btnBlanquearListado.Text = "F1 - Blanquear Listado"
        '
        'btnQuitarArticulo
        '
        Me.btnQuitarArticulo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnQuitarArticulo.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnQuitarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitarArticulo.Name = "btnQuitarArticulo"
        Me.btnQuitarArticulo.Size = New System.Drawing.Size(118, 22)
        Me.btnQuitarArticulo.Text = "F2 - Quitar Artículo"
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.TextEdit_x24
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(131, 22)
        Me.btnModificar.Text = "F3 - Modificar Artículo"
        '
        'CbxMedida
        '
        Me.CbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxMedida.FormattingEnabled = True
        Me.CbxMedida.Location = New System.Drawing.Point(130, 16)
        Me.CbxMedida.Name = "CbxMedida"
        Me.CbxMedida.Size = New System.Drawing.Size(91, 23)
        Me.CbxMedida.TabIndex = 5
        '
        'txtCantidadArticulo
        '
        Me.txtCantidadArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadArticulo.Location = New System.Drawing.Point(223, 17)
        Me.txtCantidadArticulo.Name = "txtCantidadArticulo"
        Me.txtCantidadArticulo.Size = New System.Drawing.Size(73, 23)
        Me.txtCantidadArticulo.TabIndex = 6
        Me.txtCantidadArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecio
        '
        Me.txtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrecio.Location = New System.Drawing.Point(750, 17)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(158, 23)
        Me.txtPrecio.TabIndex = 8
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcionArticulo
        '
        Me.txtDescripcionArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcionArticulo.Enabled = False
        Me.txtDescripcionArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcionArticulo.Location = New System.Drawing.Point(297, 17)
        Me.txtDescripcionArticulo.Name = "txtDescripcionArticulo"
        Me.txtDescripcionArticulo.ReadOnly = True
        Me.txtDescripcionArticulo.Size = New System.Drawing.Size(452, 23)
        Me.txtDescripcionArticulo.TabIndex = 7
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAplicar.Image = Global.Libregco.My.Resources.Resources.Tag_x32
        Me.btnAplicar.Location = New System.Drawing.Point(905, 17)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(26, 23)
        Me.btnAplicar.TabIndex = 9
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'btnBuscarArticulo
        '
        Me.btnBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarArticulo.Image = CType(resources.GetObject("btnBuscarArticulo.Image"), System.Drawing.Image)
        Me.btnBuscarArticulo.Location = New System.Drawing.Point(105, 16)
        Me.btnBuscarArticulo.Name = "btnBuscarArticulo"
        Me.btnBuscarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarArticulo.TabIndex = 4
        Me.btnBuscarArticulo.TabStop = False
        Me.btnBuscarArticulo.UseVisualStyleBackColor = True
        '
        'txtIDArticulo
        '
        Me.txtIDArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDArticulo.Location = New System.Drawing.Point(9, 16)
        Me.txtIDArticulo.Name = "txtIDArticulo"
        Me.txtIDArticulo.Size = New System.Drawing.Size(97, 23)
        Me.txtIDArticulo.TabIndex = 3
        Me.txtIDArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DgvArticulos
        '
        Me.DgvArticulos.AllowUserToAddRows = False
        Me.DgvArticulos.AllowUserToDeleteRows = False
        Me.DgvArticulos.AllowUserToResizeColumns = False
        Me.DgvArticulos.AllowUserToResizeRows = False
        Me.DgvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvArticulos.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvArticulos.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.DgvArticulos.Location = New System.Drawing.Point(6, 45)
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.ReadOnly = True
        Me.DgvArticulos.RowHeadersWidth = 30
        Me.DgvArticulos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(927, 249)
        Me.DgvArticulos.TabIndex = 10
        Me.DgvArticulos.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(8, 566)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 282
        Me.Label8.Text = "Notas"
        '
        'txtComentario
        '
        Me.txtComentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtComentario.Location = New System.Drawing.Point(94, 561)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentario.Size = New System.Drawing.Size(477, 38)
        Me.txtComentario.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label9.Location = New System.Drawing.Point(8, 538)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 280
        Me.Label9.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtReferencia.Location = New System.Drawing.Point(94, 535)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(477, 20)
        Me.txtReferencia.TabIndex = 11
        '
        'label18
        '
        Me.label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.label18.Location = New System.Drawing.Point(708, 613)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(65, 13)
        Me.label18.TabIndex = 285
        Me.label18.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtNeto.ForeColor = System.Drawing.Color.Black
        Me.txtNeto.Location = New System.Drawing.Point(777, 606)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(163, 23)
        Me.txtNeto.TabIndex = 284
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Location = New System.Drawing.Point(91, 107)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 287
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Location = New System.Drawing.Point(413, 96)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(48, 17)
        Me.ChkNulo.TabIndex = 288
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(516, 22)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 327
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnEliminar, Me.btnImprimir})
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
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.btnGuardar.Size = New System.Drawing.Size(242, 54)
        Me.btnGuardar.Text = "Solo Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnGuardaryLimpiar
        '
        Me.btnGuardaryLimpiar.Image = CType(resources.GetObject("btnGuardaryLimpiar.Image"), System.Drawing.Image)
        Me.btnGuardaryLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardaryLimpiar.Name = "btnGuardaryLimpiar"
        Me.btnGuardaryLimpiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.btnGuardaryLimpiar.Size = New System.Drawing.Size(242, 54)
        Me.btnGuardaryLimpiar.Text = "Guardar y Limpiar"
        Me.btnGuardaryLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
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
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(84, 95)
        Me.btnEliminar.Text = "Anular"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'GbSuplidor
        '
        Me.GbSuplidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbSuplidor.Controls.Add(Me.txtUltimoMonto)
        Me.GbSuplidor.Controls.Add(Me.Label28)
        Me.GbSuplidor.Controls.Add(Me.txtUltimoPago)
        Me.GbSuplidor.Controls.Add(Me.Label2)
        Me.GbSuplidor.Controls.Add(Me.btnBuscarSup)
        Me.GbSuplidor.Controls.Add(Me.txtNombreSuplidor)
        Me.GbSuplidor.Controls.Add(Me.label1)
        Me.GbSuplidor.Controls.Add(Me.label15)
        Me.GbSuplidor.Controls.Add(Me.txtBalanceSup)
        Me.GbSuplidor.Controls.Add(Me.label5)
        Me.GbSuplidor.Controls.Add(Me.txtIDSuplidor)
        Me.GbSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbSuplidor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GbSuplidor.Location = New System.Drawing.Point(7, 126)
        Me.GbSuplidor.Name = "GbSuplidor"
        Me.GbSuplidor.Size = New System.Drawing.Size(587, 78)
        Me.GbSuplidor.TabIndex = 290
        Me.GbSuplidor.TabStop = False
        Me.GbSuplidor.Text = "Suplidor"
        '
        'txtUltimoMonto
        '
        Me.txtUltimoMonto.Enabled = False
        Me.txtUltimoMonto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoMonto.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoMonto.Location = New System.Drawing.Point(445, 46)
        Me.txtUltimoMonto.Name = "txtUltimoMonto"
        Me.txtUltimoMonto.ReadOnly = True
        Me.txtUltimoMonto.Size = New System.Drawing.Size(137, 23)
        Me.txtUltimoMonto.TabIndex = 233
        Me.txtUltimoMonto.TabStop = False
        Me.txtUltimoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(393, 49)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(43, 15)
        Me.Label28.TabIndex = 232
        Me.Label28.Text = "Monto"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(267, 46)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(120, 23)
        Me.txtUltimoPago.TabIndex = 231
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(191, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "Último Pago"
        '
        'btnBuscarSup
        '
        Me.btnBuscarSup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarSup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarSup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarSup.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarSup.Image = CType(resources.GetObject("btnBuscarSup.Image"), System.Drawing.Image)
        Me.btnBuscarSup.Location = New System.Drawing.Point(162, 17)
        Me.btnBuscarSup.Name = "btnBuscarSup"
        Me.btnBuscarSup.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarSup.TabIndex = 1
        Me.btnBuscarSup.UseVisualStyleBackColor = True
        '
        'txtNombreSuplidor
        '
        Me.txtNombreSuplidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreSuplidor.Enabled = False
        Me.txtNombreSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombreSuplidor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombreSuplidor.Location = New System.Drawing.Point(248, 18)
        Me.txtNombreSuplidor.Name = "txtNombreSuplidor"
        Me.txtNombreSuplidor.ReadOnly = True
        Me.txtNombreSuplidor.Size = New System.Drawing.Size(334, 23)
        Me.txtNombreSuplidor.TabIndex = 183
        Me.txtNombreSuplidor.TabStop = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label1.Location = New System.Drawing.Point(191, 20)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 15)
        Me.label1.TabIndex = 184
        Me.label1.Text = "Suplidor"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label15.Location = New System.Drawing.Point(8, 20)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(46, 15)
        Me.label15.TabIndex = 131
        Me.label15.Text = "Código"
        '
        'txtBalanceSup
        '
        Me.txtBalanceSup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBalanceSup.Enabled = False
        Me.txtBalanceSup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceSup.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceSup.Location = New System.Drawing.Point(66, 46)
        Me.txtBalanceSup.Name = "txtBalanceSup"
        Me.txtBalanceSup.ReadOnly = True
        Me.txtBalanceSup.Size = New System.Drawing.Size(119, 23)
        Me.txtBalanceSup.TabIndex = 227
        Me.txtBalanceSup.TabStop = False
        Me.txtBalanceSup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label5.Location = New System.Drawing.Point(5, 49)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(48, 15)
        Me.label5.TabIndex = 228
        Me.label5.Text = "Balance"
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Enabled = False
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDSuplidor.Location = New System.Drawing.Point(66, 17)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.ReadOnly = True
        Me.txtIDSuplidor.Size = New System.Drawing.Size(97, 23)
        Me.txtIDSuplidor.TabIndex = 130
        Me.txtIDSuplidor.TabStop = False
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxStatusOrder
        '
        Me.cbxStatusOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxStatusOrder.Enabled = False
        Me.cbxStatusOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxStatusOrder.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxStatusOrder.FormattingEnabled = True
        Me.cbxStatusOrder.Location = New System.Drawing.Point(94, 606)
        Me.cbxStatusOrder.Name = "cbxStatusOrder"
        Me.cbxStatusOrder.Size = New System.Drawing.Size(171, 21)
        Me.cbxStatusOrder.TabIndex = 328
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 609)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 329
        Me.Label4.Text = "Status"
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 330
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 644)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(950, 25)
        Me.BarraEstado.TabIndex = 411
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'lblDate
        '
        Me.lblDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(31, 22)
        Me.lblDate.Text = "Date"
        '
        'PicLoading
        '
        Me.PicLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLoading.Image = Global.Libregco.My.Resources.Resources.Loading
        Me.PicLoading.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLoading.Name = "PicLoading"
        Me.PicLoading.Size = New System.Drawing.Size(23, 22)
        Me.PicLoading.Text = "ToolStripButton1"
        Me.PicLoading.Visible = False
        '
        'ToolSeparator
        '
        Me.ToolSeparator.Name = "ToolSeparator"
        Me.ToolSeparator.Size = New System.Drawing.Size(6, 25)
        Me.ToolSeparator.Visible = False
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
        'CbxAlmacen
        '
        Me.CbxAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxAlmacen.FormattingEnabled = True
        Me.CbxAlmacen.Location = New System.Drawing.Point(331, 606)
        Me.CbxAlmacen.Name = "CbxAlmacen"
        Me.CbxAlmacen.Size = New System.Drawing.Size(240, 21)
        Me.CbxAlmacen.TabIndex = 412
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label16.Location = New System.Drawing.Point(271, 609)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 413
        Me.Label16.Text = "Almacén"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(740, 582)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 417
        Me.Label10.Text = "ITBIS"
        '
        'label14
        '
        Me.label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label14.AutoSize = True
        Me.label14.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label14.Location = New System.Drawing.Point(715, 552)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(56, 13)
        Me.label14.TabIndex = 415
        Me.label14.Text = "Sub. Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubTotal.Location = New System.Drawing.Point(777, 548)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(163, 23)
        Me.txtSubTotal.TabIndex = 414
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtItbis
        '
        Me.txtItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItbis.BackColor = System.Drawing.SystemColors.Control
        Me.txtItbis.Enabled = False
        Me.txtItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtItbis.ForeColor = System.Drawing.Color.Black
        Me.txtItbis.Location = New System.Drawing.Point(777, 577)
        Me.txtItbis.Name = "txtItbis"
        Me.txtItbis.Size = New System.Drawing.Size(163, 23)
        Me.txtItbis.TabIndex = 416
        Me.txtItbis.TabStop = False
        Me.txtItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_orden_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 669)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.label14)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.txtItbis)
        Me.Controls.Add(Me.CbxAlmacen)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbxStatusOrder)
        Me.Controls.Add(Me.GbSuplidor)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.label18)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtComentario)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.GbArticulos)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_orden_compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "23"
        Me.Text = "Orden de compras"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.GbArticulos.ResumeLayout(False)
        Me.GbArticulos.PerformLayout()
        Me.PnItbis.ResumeLayout(False)
        Me.PnItbis.PerformLayout()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GbSuplidor.ResumeLayout(False)
        Me.GbSuplidor.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LimpiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BuscarCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtIDOrdenCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GbArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents CbxMedida As System.Windows.Forms.ComboBox
    Friend WithEvents txtCantidadArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionArticulo As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Private WithEvents btnBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents txtIDArticulo As System.Windows.Forms.TextBox
    Friend WithEvents DgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents BarraOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBlanquearListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnQuitarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As TextBox
    Friend WithEvents GbSuplidor As GroupBox
    Friend WithEvents txtUltimoMonto As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtUltimoPago As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuscarSup As Button
    Friend WithEvents txtNombreSuplidor As TextBox
    Friend WithEvents label1 As Label
    Private WithEvents label15 As Label
    Friend WithEvents txtBalanceSup As TextBox
    Private WithEvents label5 As Label
    Friend WithEvents txtIDSuplidor As TextBox
    Friend WithEvents cbxStatusOrder As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BuscarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PnItbis As Panel
    Friend WithEvents rdbNoItbis As RadioButton
    Friend WithEvents Label13 As Label
    Friend WithEvents rdbIncluido As RadioButton
    Friend WithEvents rdbNoIncluido As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents label14 As Label
    Friend WithEvents txtSubTotal As TextBox
    Friend WithEvents txtItbis As TextBox
End Class
