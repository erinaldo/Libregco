<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_listado_articulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listado_articulos))
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtIDListado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GbArticulos = New System.Windows.Forms.GroupBox()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnBlanquear = New System.Windows.Forms.ToolStripButton()
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
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.CMenuProducts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IrAArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.MarcarComoRecibidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarcarNoRecibidoNoCompradoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GbxUserInfo.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbArticulos.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.CMenuProducts.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.txtIDListado)
        Me.GbxUserInfo.Controls.Add(Me.Label7)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label3)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(701, 120)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(344, 78)
        Me.GbxUserInfo.TabIndex = 305
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(178, 17)
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
        Me.txtFecha.Location = New System.Drawing.Point(63, 46)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 253
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDListado
        '
        Me.txtIDListado.Enabled = False
        Me.txtIDListado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDListado.Location = New System.Drawing.Point(63, 17)
        Me.txtIDListado.Name = "txtIDListado"
        Me.txtIDListado.ReadOnly = True
        Me.txtIDListado.Size = New System.Drawing.Size(109, 23)
        Me.txtIDListado.TabIndex = 248
        Me.txtIDListado.TabStop = False
        Me.txtIDListado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(5, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Código"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 47)
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1052, 24)
        Me.MenuStrip1.TabIndex = 306
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripMenuItem1, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(195, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(195, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(195, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar listas"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(195, 38)
        Me.ToolStripMenuItem1.Text = "Buscar artículos"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(195, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(192, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(195, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarToolStripMenuItem, Me.QuitarToolStripMenuItem, Me.ModificarToolStripMenuItem, Me.ToolStripSeparator2, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'LimpiarToolStripMenuItem
        '
        Me.LimpiarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.LimpiarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LimpiarToolStripMenuItem.Name = "LimpiarToolStripMenuItem"
        Me.LimpiarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.LimpiarToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.LimpiarToolStripMenuItem.Text = "Limpiar"
        '
        'QuitarToolStripMenuItem
        '
        Me.QuitarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarToolStripMenuItem.Name = "QuitarToolStripMenuItem"
        Me.QuitarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.QuitarToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.QuitarToolStripMenuItem.Text = "Quitar"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.ModificarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(162, 6)
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
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
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(8, 137)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(687, 61)
        Me.txtDescripcion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label1.Location = New System.Drawing.Point(8, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 319
        Me.Label1.Text = "Descripción de la Lista"
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
        Me.GbArticulos.Controls.Add(Me.btnAplicar)
        Me.GbArticulos.Controls.Add(Me.btnBuscarArticulo)
        Me.GbArticulos.Controls.Add(Me.txtIDArticulo)
        Me.GbArticulos.Controls.Add(Me.DgvArticulos)
        Me.GbArticulos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbArticulos.Location = New System.Drawing.Point(3, 199)
        Me.GbArticulos.Name = "GbArticulos"
        Me.GbArticulos.Size = New System.Drawing.Size(1047, 452)
        Me.GbArticulos.TabIndex = 1
        Me.GbArticulos.TabStop = False
        Me.GbArticulos.Text = "Artículos"
        '
        'BarraOpciones
        '
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBlanquear, Me.btnQuitarArticulo, Me.btnModificar})
        Me.BarraOpciones.Location = New System.Drawing.Point(3, 424)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.BarraOpciones.Size = New System.Drawing.Size(1041, 25)
        Me.BarraOpciones.TabIndex = 252
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'btnBlanquear
        '
        Me.btnBlanquear.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.btnBlanquear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlanquear.Name = "btnBlanquear"
        Me.btnBlanquear.Size = New System.Drawing.Size(97, 22)
        Me.btnBlanquear.Text = "F1 - Blanquear"
        '
        'btnQuitarArticulo
        '
        Me.btnQuitarArticulo.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnQuitarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitarArticulo.Name = "btnQuitarArticulo"
        Me.btnQuitarArticulo.Size = New System.Drawing.Size(79, 22)
        Me.btnQuitarArticulo.Text = "F2 - Quitar"
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(92, 22)
        Me.btnModificar.Text = "F3 - Modificar"
        '
        'CbxMedida
        '
        Me.CbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxMedida.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxMedida.FormattingEnabled = True
        Me.CbxMedida.Location = New System.Drawing.Point(204, 16)
        Me.CbxMedida.Name = "CbxMedida"
        Me.CbxMedida.Size = New System.Drawing.Size(91, 23)
        Me.CbxMedida.TabIndex = 5
        '
        'txtCantidadArticulo
        '
        Me.txtCantidadArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadArticulo.Location = New System.Drawing.Point(140, 16)
        Me.txtCantidadArticulo.Name = "txtCantidadArticulo"
        Me.txtCantidadArticulo.Size = New System.Drawing.Size(58, 23)
        Me.txtCantidadArticulo.TabIndex = 4
        Me.txtCantidadArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecio
        '
        Me.txtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrecio.Location = New System.Drawing.Point(886, 15)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(130, 23)
        Me.txtPrecio.TabIndex = 6
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcionArticulo
        '
        Me.txtDescripcionArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcionArticulo.Enabled = False
        Me.txtDescripcionArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcionArticulo.Location = New System.Drawing.Point(301, 15)
        Me.txtDescripcionArticulo.Name = "txtDescripcionArticulo"
        Me.txtDescripcionArticulo.ReadOnly = True
        Me.txtDescripcionArticulo.Size = New System.Drawing.Size(579, 23)
        Me.txtDescripcionArticulo.TabIndex = 7
        Me.txtDescripcionArticulo.TabStop = False
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAplicar.Image = Global.Libregco.My.Resources.Resources.Tag_x32
        Me.btnAplicar.Location = New System.Drawing.Point(1015, 15)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(23, 23)
        Me.btnAplicar.TabIndex = 7
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'btnBuscarArticulo
        '
        Me.btnBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarArticulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnBuscarArticulo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarArticulo.Location = New System.Drawing.Point(111, 16)
        Me.btnBuscarArticulo.Name = "btnBuscarArticulo"
        Me.btnBuscarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarArticulo.TabIndex = 3
        Me.btnBuscarArticulo.TabStop = False
        Me.btnBuscarArticulo.UseVisualStyleBackColor = True
        '
        'txtIDArticulo
        '
        Me.txtIDArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDArticulo.Location = New System.Drawing.Point(9, 16)
        Me.txtIDArticulo.Name = "txtIDArticulo"
        Me.txtIDArticulo.Size = New System.Drawing.Size(103, 23)
        Me.txtIDArticulo.TabIndex = 2
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
        Me.DgvArticulos.Location = New System.Drawing.Point(5, 45)
        Me.DgvArticulos.MultiSelect = False
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.ReadOnly = True
        Me.DgvArticulos.RowHeadersWidth = 30
        Me.DgvArticulos.RowTemplate.Height = 38
        Me.DgvArticulos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(1036, 376)
        Me.DgvArticulos.TabIndex = 8
        Me.DgvArticulos.TabStop = False
        '
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Location = New System.Drawing.Point(277, 27)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(48, 17)
        Me.ChkNulo.TabIndex = 322
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(782, 661)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 20)
        Me.Label2.TabIndex = 324
        Me.Label2.Text = "TOTAL"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotal.Location = New System.Drawing.Point(838, 657)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(205, 27)
        Me.txtTotal.TabIndex = 323
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(618, 21)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 325
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.GuardarToolStripMenuItem, Me.btnBuscar, Me.btnEliminar, Me.btnImprimir})
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
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.GuardarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.GuardarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(84, 95)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        Me.GuardarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicBoxLogo.ImageLocation = ""
        Me.PicBoxLogo.Location = New System.Drawing.Point(8, 27)
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
        Me.BarraEstado.Location = New System.Drawing.Point(0, 691)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1052, 25)
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
        'CMenuProducts
        '
        Me.CMenuProducts.BackColor = System.Drawing.Color.White
        Me.CMenuProducts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IrAArtículosToolStripMenuItem, Me.ToolStripSeparator5, Me.QuitarToolStripMenuItem1, Me.ModificarToolStripMenuItem1, Me.ToolStripSeparator3, Me.ToolStripTextBox1, Me.MarcarComoRecibidoToolStripMenuItem, Me.MarcarNoRecibidoNoCompradoToolStripMenuItem, Me.PedidoToolStripMenuItem})
        Me.CMenuProducts.Name = "ContextMenuStrip1"
        Me.CMenuProducts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CMenuProducts.Size = New System.Drawing.Size(177, 266)
        Me.CMenuProducts.Text = "Opciones"
        '
        'IrAArtículosToolStripMenuItem
        '
        Me.IrAArtículosToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.IrAArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Products_x24
        Me.IrAArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.IrAArtículosToolStripMenuItem.Name = "IrAArtículosToolStripMenuItem"
        Me.IrAArtículosToolStripMenuItem.Size = New System.Drawing.Size(176, 38)
        Me.IrAArtículosToolStripMenuItem.Text = "Ir a artículos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(173, 6)
        '
        'QuitarToolStripMenuItem1
        '
        Me.QuitarToolStripMenuItem1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.QuitarToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.Delete_x24
        Me.QuitarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarToolStripMenuItem1.Name = "QuitarToolStripMenuItem1"
        Me.QuitarToolStripMenuItem1.Size = New System.Drawing.Size(176, 38)
        Me.QuitarToolStripMenuItem1.Text = "Quitar"
        '
        'ModificarToolStripMenuItem1
        '
        Me.ModificarToolStripMenuItem1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ModificarToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.TextEdit_x24
        Me.ModificarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarToolStripMenuItem1.Name = "ModificarToolStripMenuItem1"
        Me.ModificarToolStripMenuItem1.Size = New System.Drawing.Size(176, 38)
        Me.ModificarToolStripMenuItem1.Text = "Modificar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(173, 6)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripTextBox1.ShortcutsEnabled = False
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.ToolStripTextBox1.Text = "Marcar Producto"
        Me.ToolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MarcarComoRecibidoToolStripMenuItem
        '
        Me.MarcarComoRecibidoToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.MarcarComoRecibidoToolStripMenuItem.ForeColor = System.Drawing.Color.Green
        Me.MarcarComoRecibidoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Checkedx32
        Me.MarcarComoRecibidoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MarcarComoRecibidoToolStripMenuItem.Name = "MarcarComoRecibidoToolStripMenuItem"
        Me.MarcarComoRecibidoToolStripMenuItem.Size = New System.Drawing.Size(176, 38)
        Me.MarcarComoRecibidoToolStripMenuItem.Text = "Recibido"
        '
        'MarcarNoRecibidoNoCompradoToolStripMenuItem
        '
        Me.MarcarNoRecibidoNoCompradoToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.MarcarNoRecibidoNoCompradoToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.MarcarNoRecibidoNoCompradoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.uncheckedx32
        Me.MarcarNoRecibidoNoCompradoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MarcarNoRecibidoNoCompradoToolStripMenuItem.Name = "MarcarNoRecibidoNoCompradoToolStripMenuItem"
        Me.MarcarNoRecibidoNoCompradoToolStripMenuItem.Size = New System.Drawing.Size(176, 38)
        Me.MarcarNoRecibidoNoCompradoToolStripMenuItem.Text = "No recibido"
        '
        'PedidoToolStripMenuItem
        '
        Me.PedidoToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PedidoToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue
        Me.PedidoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Stocks_x32
        Me.PedidoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PedidoToolStripMenuItem.Name = "PedidoToolStripMenuItem"
        Me.PedidoToolStripMenuItem.Size = New System.Drawing.Size(176, 38)
        Me.PedidoToolStripMenuItem.Text = "Pedido"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 657)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 26)
        Me.Button1.TabIndex = 338
        Me.Button1.Text = "+ Ver artículos no recibidos / no comprados"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_listado_articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 716)
        Me.Controls.Add(Me.GbArticulos)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_listado_articulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "14"
        Me.Text = "Listado de artículos"
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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
        Me.CMenuProducts.ResumeLayout(False)
        Me.CMenuProducts.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtIDListado As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
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
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GbArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents BarraOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBlanquear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnQuitarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents CbxMedida As System.Windows.Forms.ComboBox
    Friend WithEvents txtCantidadArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionArticulo As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Private WithEvents btnBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents txtIDArticulo As System.Windows.Forms.TextBox
    Friend WithEvents DgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CMenuProducts As ContextMenuStrip
    Friend WithEvents IrAArtículosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents QuitarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents MarcarNoRecibidoNoCompradoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarcarComoRecibidoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PedidoToolStripMenuItem As ToolStripMenuItem
End Class
