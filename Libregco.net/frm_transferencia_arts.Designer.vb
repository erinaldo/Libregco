<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_transferencia_arts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_transferencia_arts))
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlanquearListadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuscarAjusteInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtIDTransferenciaArt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CbxAlmacenSalida = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxAlmacenEntrada = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GbArticulos = New System.Windows.Forms.GroupBox()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnBlanquear = New System.Windows.Forms.ToolStripButton()
        Me.btnQuitarArticulo = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.CbxMedida = New System.Windows.Forms.ComboBox()
        Me.txtCantidadArticulo = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtDescripcionArticulo = New System.Windows.Forms.TextBox()
        Me.btnAplicarMonto = New System.Windows.Forms.Button()
        Me.btnBuscarArticulo = New System.Windows.Forms.Button()
        Me.txtIDArticulo = New System.Windows.Forms.TextBox()
        Me.DgvArticulos = New System.Windows.Forms.DataGridView()
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.label18 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.cbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.MenuBarra.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.GbArticulos.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(853, 24)
        Me.MenuBarra.TabIndex = 247
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarArtículosToolStripMenuItem, Me.ToolStripSeparator1, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(194, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(194, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarArtículosToolStripMenuItem
        '
        Me.BuscarArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarArtículosToolStripMenuItem.Name = "BuscarArtículosToolStripMenuItem"
        Me.BuscarArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BuscarArtículosToolStripMenuItem.Size = New System.Drawing.Size(194, 38)
        Me.BuscarArtículosToolStripMenuItem.Text = "Buscar Artículos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(191, 6)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(194, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(194, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlanquearListadoToolStripMenuItem, Me.QuitarArtículoToolStripMenuItem, Me.ModificarArtículoToolStripMenuItem, Me.ToolStripSeparator2, Me.BuscarAjusteInventarioToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'BlanquearListadoToolStripMenuItem
        '
        Me.BlanquearListadoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.BlanquearListadoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BlanquearListadoToolStripMenuItem.Name = "BlanquearListadoToolStripMenuItem"
        Me.BlanquearListadoToolStripMenuItem.Size = New System.Drawing.Size(198, 38)
        Me.BlanquearListadoToolStripMenuItem.Text = "Blanquear Listado"
        '
        'QuitarArtículoToolStripMenuItem
        '
        Me.QuitarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarArtículoToolStripMenuItem.Name = "QuitarArtículoToolStripMenuItem"
        Me.QuitarArtículoToolStripMenuItem.Size = New System.Drawing.Size(198, 38)
        Me.QuitarArtículoToolStripMenuItem.Text = "Quitar Artículo"
        '
        'ModificarArtículoToolStripMenuItem
        '
        Me.ModificarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.ModificarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarArtículoToolStripMenuItem.Name = "ModificarArtículoToolStripMenuItem"
        Me.ModificarArtículoToolStripMenuItem.Size = New System.Drawing.Size(198, 38)
        Me.ModificarArtículoToolStripMenuItem.Text = "Modificar Artículo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(195, 6)
        '
        'BuscarAjusteInventarioToolStripMenuItem
        '
        Me.BuscarAjusteInventarioToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarAjusteInventarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarAjusteInventarioToolStripMenuItem.Name = "BuscarAjusteInventarioToolStripMenuItem"
        Me.BuscarAjusteInventarioToolStripMenuItem.Size = New System.Drawing.Size(198, 38)
        Me.BuscarAjusteInventarioToolStripMenuItem.Text = "Buscar Transferencia"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(198, 38)
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
        Me.AyudaLibregcoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(192, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.Label12)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label13)
        Me.GbxUserInfo.Controls.Add(Me.Label14)
        Me.GbxUserInfo.Controls.Add(Me.txtIDTransferenciaArt)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(469, 127)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(378, 70)
        Me.GbxUserInfo.TabIndex = 265
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(193, 16)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(178, 23)
        Me.txtSecondID.TabIndex = 270
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(237, 42)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(135, 23)
        Me.txtFecha.TabIndex = 269
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(7, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 15)
        Me.Label12.TabIndex = 268
        Me.Label12.Text = "Hora"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(59, 42)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(128, 23)
        Me.txtHora.TabIndex = 267
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(193, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 15)
        Me.Label13.TabIndex = 266
        Me.Label13.Text = "Fecha"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(7, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 15)
        Me.Label14.TabIndex = 265
        Me.Label14.Text = "Código"
        '
        'txtIDTransferenciaArt
        '
        Me.txtIDTransferenciaArt.Enabled = False
        Me.txtIDTransferenciaArt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTransferenciaArt.Location = New System.Drawing.Point(59, 16)
        Me.txtIDTransferenciaArt.Name = "txtIDTransferenciaArt"
        Me.txtIDTransferenciaArt.ReadOnly = True
        Me.txtIDTransferenciaArt.Size = New System.Drawing.Size(128, 23)
        Me.txtIDTransferenciaArt.TabIndex = 264
        Me.txtIDTransferenciaArt.TabStop = False
        Me.txtIDTransferenciaArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(13, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 267
        Me.Label5.Text = "Almacenes"
        '
        'CbxAlmacenSalida
        '
        Me.CbxAlmacenSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxAlmacenSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxAlmacenSalida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxAlmacenSalida.FormattingEnabled = True
        Me.CbxAlmacenSalida.Location = New System.Drawing.Point(88, 140)
        Me.CbxAlmacenSalida.Name = "CbxAlmacenSalida"
        Me.CbxAlmacenSalida.Size = New System.Drawing.Size(185, 23)
        Me.CbxAlmacenSalida.TabIndex = 266
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(279, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 269
        Me.Label1.Text = "Entrada a:"
        '
        'cbxAlmacenEntrada
        '
        Me.cbxAlmacenEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacenEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAlmacenEntrada.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxAlmacenEntrada.FormattingEnabled = True
        Me.cbxAlmacenEntrada.Location = New System.Drawing.Point(279, 141)
        Me.cbxAlmacenEntrada.Name = "cbxAlmacenEntrada"
        Me.cbxAlmacenEntrada.Size = New System.Drawing.Size(185, 23)
        Me.cbxAlmacenEntrada.TabIndex = 268
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 271
        Me.Label3.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtReferencia.Location = New System.Drawing.Point(88, 171)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(375, 23)
        Me.txtReferencia.TabIndex = 270
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 505)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 273
        Me.Label4.Text = "Comentarios"
        '
        'txtComentario
        '
        Me.txtComentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtComentario.Location = New System.Drawing.Point(86, 502)
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(423, 23)
        Me.txtComentario.TabIndex = 272
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(85, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 274
        Me.Label2.Text = "Salida en:"
        '
        'GbArticulos
        '
        Me.GbArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbArticulos.Controls.Add(Me.BarraOpciones)
        Me.GbArticulos.Controls.Add(Me.CbxMedida)
        Me.GbArticulos.Controls.Add(Me.txtCantidadArticulo)
        Me.GbArticulos.Controls.Add(Me.txtPrecio)
        Me.GbArticulos.Controls.Add(Me.txtDescripcionArticulo)
        Me.GbArticulos.Controls.Add(Me.btnAplicarMonto)
        Me.GbArticulos.Controls.Add(Me.btnBuscarArticulo)
        Me.GbArticulos.Controls.Add(Me.txtIDArticulo)
        Me.GbArticulos.Controls.Add(Me.DgvArticulos)
        Me.GbArticulos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbArticulos.Location = New System.Drawing.Point(7, 199)
        Me.GbArticulos.Name = "GbArticulos"
        Me.GbArticulos.Size = New System.Drawing.Size(840, 297)
        Me.GbArticulos.TabIndex = 275
        Me.GbArticulos.TabStop = False
        Me.GbArticulos.Text = "Artículos"
        '
        'BarraOpciones
        '
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBlanquear, Me.btnQuitarArticulo, Me.btnModificar})
        Me.BarraOpciones.Location = New System.Drawing.Point(3, 269)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraOpciones.Size = New System.Drawing.Size(834, 25)
        Me.BarraOpciones.TabIndex = 252
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'btnBlanquear
        '
        Me.btnBlanquear.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.btnBlanquear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlanquear.Name = "btnBlanquear"
        Me.btnBlanquear.Size = New System.Drawing.Size(144, 22)
        Me.btnBlanquear.Text = "F1 - Blanquear Listado"
        '
        'btnQuitarArticulo
        '
        Me.btnQuitarArticulo.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnQuitarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitarArticulo.Name = "btnQuitarArticulo"
        Me.btnQuitarArticulo.Size = New System.Drawing.Size(128, 22)
        Me.btnQuitarArticulo.Text = "F2 - Quitar Artículo"
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(146, 22)
        Me.btnModificar.Text = "F3 - Modificar Artículo"
        '
        'CbxMedida
        '
        Me.CbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxMedida.FormattingEnabled = True
        Me.CbxMedida.Location = New System.Drawing.Point(152, 17)
        Me.CbxMedida.Name = "CbxMedida"
        Me.CbxMedida.Size = New System.Drawing.Size(61, 23)
        Me.CbxMedida.TabIndex = 12
        '
        'txtCantidadArticulo
        '
        Me.txtCantidadArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadArticulo.Location = New System.Drawing.Point(219, 17)
        Me.txtCantidadArticulo.Name = "txtCantidadArticulo"
        Me.txtCantidadArticulo.Size = New System.Drawing.Size(73, 23)
        Me.txtCantidadArticulo.TabIndex = 13
        Me.txtCantidadArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecio
        '
        Me.txtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrecio.Location = New System.Drawing.Point(658, 17)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(154, 23)
        Me.txtPrecio.TabIndex = 15
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcionArticulo
        '
        Me.txtDescripcionArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcionArticulo.Enabled = False
        Me.txtDescripcionArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcionArticulo.Location = New System.Drawing.Point(298, 17)
        Me.txtDescripcionArticulo.Name = "txtDescripcionArticulo"
        Me.txtDescripcionArticulo.Size = New System.Drawing.Size(354, 23)
        Me.txtDescripcionArticulo.TabIndex = 14
        '
        'btnAplicarMonto
        '
        Me.btnAplicarMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicarMonto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAplicarMonto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAplicarMonto.Image = Global.Libregco.My.Resources.Resources.Tag_x32
        Me.btnAplicarMonto.Location = New System.Drawing.Point(811, 17)
        Me.btnAplicarMonto.Name = "btnAplicarMonto"
        Me.btnAplicarMonto.Size = New System.Drawing.Size(23, 23)
        Me.btnAplicarMonto.TabIndex = 17
        Me.btnAplicarMonto.UseVisualStyleBackColor = True
        '
        'btnBuscarArticulo
        '
        Me.btnBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarArticulo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarArticulo.Location = New System.Drawing.Point(122, 17)
        Me.btnBuscarArticulo.Name = "btnBuscarArticulo"
        Me.btnBuscarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarArticulo.TabIndex = 11
        Me.btnBuscarArticulo.UseVisualStyleBackColor = True
        '
        'txtIDArticulo
        '
        Me.txtIDArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDArticulo.Location = New System.Drawing.Point(9, 17)
        Me.txtIDArticulo.Name = "txtIDArticulo"
        Me.txtIDArticulo.Size = New System.Drawing.Size(114, 23)
        Me.txtIDArticulo.TabIndex = 10
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
        Me.DgvArticulos.Location = New System.Drawing.Point(7, 46)
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.ReadOnly = True
        Me.DgvArticulos.RowHeadersWidth = 30
        Me.DgvArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvArticulos.RowTemplate.Height = 20
        Me.DgvArticulos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(826, 220)
        Me.DgvArticulos.TabIndex = 162
        '
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Location = New System.Drawing.Point(367, 27)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(48, 17)
        Me.ChkNulo.TabIndex = 278
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'label18
        '
        Me.label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label18.Location = New System.Drawing.Point(516, 546)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(88, 21)
        Me.label18.TabIndex = 277
        Me.label18.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtNeto.ForeColor = System.Drawing.Color.Black
        Me.txtNeto.Location = New System.Drawing.Point(610, 543)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(237, 29)
        Me.txtNeto.TabIndex = 276
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(418, 24)
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
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(7, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 328
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 578)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(853, 25)
        Me.BarraEstado.TabIndex = 337
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
        'cbxAlmacen
        '
        Me.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxAlmacen.FormattingEnabled = True
        Me.cbxAlmacen.Location = New System.Drawing.Point(88, 531)
        Me.cbxAlmacen.Name = "cbxAlmacen"
        Me.cbxAlmacen.Size = New System.Drawing.Size(263, 23)
        Me.cbxAlmacen.TabIndex = 338
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label7.Location = New System.Drawing.Point(8, 535)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(54, 15)
        Me.label7.TabIndex = 339
        Me.label7.Text = "Almacén"
        '
        'frm_transferencia_arts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 603)
        Me.Controls.Add(Me.cbxAlmacen)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.label18)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.GbArticulos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtComentario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxAlmacenEntrada)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CbxAlmacenSalida)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.MenuBarra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_transferencia_arts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "19"
        Me.Text = "Transferencia de Inventario"
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.GbArticulos.ResumeLayout(False)
        Me.GbArticulos.PerformLayout()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBarra As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarAjusteInventarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtIDTransferenciaArt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CbxAlmacenSalida As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxAlmacenEntrada As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GbArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents CbxMedida As System.Windows.Forms.ComboBox
    Friend WithEvents txtCantidadArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionArticulo As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicarMonto As System.Windows.Forms.Button
    Private WithEvents btnBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents txtIDArticulo As System.Windows.Forms.TextBox
    Private WithEvents DgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents BarraOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBlanquear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnQuitarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BuscarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlanquearListadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents label7 As System.Windows.Forms.Label
End Class
