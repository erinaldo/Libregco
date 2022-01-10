<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_mant_medidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mant_medidas))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMedida = New System.Windows.Forms.TextBox()
        Me.txtIDMedida = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkDesactivar = New System.Windows.Forms.CheckBox()
        Me.txtAbreviatura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblMensajeFraccionamiento = New System.Windows.Forms.Label()
        Me.chkFraccionamiento = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbDinamica = New System.Windows.Forms.RadioButton()
        Me.rdbConstante = New System.Windows.Forms.RadioButton()
        Me.GridArticulos = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.txtPrecioA = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxMedida = New System.Windows.Forms.ComboBox()
        Me.Groupbox3 = New System.Windows.Forms.GroupBox()
        Me.chkRedondearPrecios = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPrecioD = New DevExpress.XtraEditors.TextEdit()
        Me.txtPrecioC = New DevExpress.XtraEditors.TextEdit()
        Me.txtPrecioB = New DevExpress.XtraEditors.TextEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCosto = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecioA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Groupbox3.SuspendLayout()
        CType(Me.txtPrecioD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecioC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecioB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(617, 24)
        Me.MenuStrip1.TabIndex = 115
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(209, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(209, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(209, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar medida"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(206, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(209, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
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
        Me.AyudaLibregcoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(192, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(70, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Medida"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMedida
        '
        Me.txtMedida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMedida.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtMedida.Location = New System.Drawing.Point(73, 129)
        Me.txtMedida.Name = "txtMedida"
        Me.txtMedida.Size = New System.Drawing.Size(289, 20)
        Me.txtMedida.TabIndex = 0
        '
        'txtIDMedida
        '
        Me.txtIDMedida.Enabled = False
        Me.txtIDMedida.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDMedida.Location = New System.Drawing.Point(12, 129)
        Me.txtIDMedida.Name = "txtIDMedida"
        Me.txtIDMedida.ReadOnly = True
        Me.txtIDMedida.Size = New System.Drawing.Size(55, 20)
        Me.txtIDMedida.TabIndex = 116
        Me.txtIDMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Código"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkDesactivar
        '
        Me.chkDesactivar.AutoSize = True
        Me.chkDesactivar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkDesactivar.Location = New System.Drawing.Point(375, 459)
        Me.chkDesactivar.Name = "chkDesactivar"
        Me.chkDesactivar.Size = New System.Drawing.Size(77, 17)
        Me.chkDesactivar.TabIndex = 120
        Me.chkDesactivar.Text = "Desactivar"
        Me.chkDesactivar.UseVisualStyleBackColor = True
        Me.chkDesactivar.Visible = False
        '
        'txtAbreviatura
        '
        Me.txtAbreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbreviatura.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtAbreviatura.Location = New System.Drawing.Point(368, 129)
        Me.txtAbreviatura.Name = "txtAbreviatura"
        Me.txtAbreviatura.Size = New System.Drawing.Size(133, 20)
        Me.txtAbreviatura.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(365, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Abreviatura"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IconPanel
        '
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(361, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(256, 79)
        Me.IconPanel.TabIndex = 236
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnEliminar})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(256, 79)
        Me.MenuStrip2.TabIndex = 9
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x48
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 75)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x48
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(61, 75)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 75)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Libregco.My.Resources.Resources.Delete_x48
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 75)
        Me.btnEliminar.Text = "Anular"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(4, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(203, 80)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 237
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 536)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(617, 25)
        Me.BarraEstado.TabIndex = 331
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMensajeFraccionamiento)
        Me.GroupBox1.Controls.Add(Me.chkFraccionamiento)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 318)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(593, 49)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fraccionamiento"
        '
        'lblMensajeFraccionamiento
        '
        Me.lblMensajeFraccionamiento.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblMensajeFraccionamiento.Location = New System.Drawing.Point(152, 14)
        Me.lblMensajeFraccionamiento.Name = "lblMensajeFraccionamiento"
        Me.lblMensajeFraccionamiento.Size = New System.Drawing.Size(435, 31)
        Me.lblMensajeFraccionamiento.TabIndex = 1
        Me.lblMensajeFraccionamiento.Text = "Los artículos que utilicen esta medida sólo podrán ser manipulados a través de nú" &
    "meros enteros"
        '
        'chkFraccionamiento
        '
        Me.chkFraccionamiento.AutoSize = True
        Me.chkFraccionamiento.Location = New System.Drawing.Point(11, 21)
        Me.chkFraccionamiento.Name = "chkFraccionamiento"
        Me.chkFraccionamiento.Size = New System.Drawing.Size(139, 17)
        Me.chkFraccionamiento.TabIndex = 11
        Me.chkFraccionamiento.Text = "Activar fraccionamiento"
        Me.chkFraccionamiento.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 334
        Me.Label4.Text = "Precio A"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbDinamica)
        Me.GroupBox2.Controls.Add(Me.rdbConstante)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(507, 123)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(98, 70)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de medida"
        '
        'rdbDinamica
        '
        Me.rdbDinamica.AutoSize = True
        Me.rdbDinamica.Location = New System.Drawing.Point(8, 40)
        Me.rdbDinamica.Name = "rdbDinamica"
        Me.rdbDinamica.Size = New System.Drawing.Size(67, 17)
        Me.rdbDinamica.TabIndex = 5
        Me.rdbDinamica.Text = "Dinámica"
        Me.rdbDinamica.UseVisualStyleBackColor = True
        '
        'rdbConstante
        '
        Me.rdbConstante.AutoSize = True
        Me.rdbConstante.Checked = True
        Me.rdbConstante.Location = New System.Drawing.Point(8, 18)
        Me.rdbConstante.Name = "rdbConstante"
        Me.rdbConstante.Size = New System.Drawing.Size(75, 17)
        Me.rdbConstante.TabIndex = 4
        Me.rdbConstante.TabStop = True
        Me.rdbConstante.Text = "Constante"
        Me.rdbConstante.UseVisualStyleBackColor = True
        '
        'GridArticulos
        '
        Me.GridArticulos.Location = New System.Drawing.Point(12, 376)
        Me.GridArticulos.MainView = Me.GridView1
        Me.GridArticulos.Name = "GridArticulos"
        Me.GridArticulos.Size = New System.Drawing.Size(593, 157)
        Me.GridArticulos.TabIndex = 12
        Me.GridArticulos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridArticulos
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 338
        Me.Label5.Text = "Moneda"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbxMoneda
        '
        Me.cbxMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxMoneda.Location = New System.Drawing.Point(12, 173)
        Me.cbxMoneda.Name = "cbxMoneda"
        Me.cbxMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxMoneda.Properties.DropDownRows = 6
        Me.cbxMoneda.Properties.SmallImages = Me.imgFlags
        Me.cbxMoneda.Size = New System.Drawing.Size(343, 20)
        Me.cbxMoneda.TabIndex = 2
        Me.cbxMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'txtPrecioA
        '
        Me.txtPrecioA.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecioA.Location = New System.Drawing.Point(11, 80)
        Me.txtPrecioA.Name = "txtPrecioA"
        Me.txtPrecioA.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioA.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPrecioA.Properties.Appearance.Options.UseBackColor = True
        Me.txtPrecioA.Properties.Appearance.Options.UseFont = True
        Me.txtPrecioA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioA.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioA.Properties.Mask.EditMask = "c"
        Me.txtPrecioA.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecioA.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPrecioA.Properties.NullText = "0"
        Me.txtPrecioA.Properties.NullValuePrompt = "0"
        Me.txtPrecioA.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioA.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(154, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 339
        Me.Label6.Text = "vale por c/u"
        '
        'cbxMedida
        '
        Me.cbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMedida.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxMedida.FormattingEnabled = True
        Me.cbxMedida.Location = New System.Drawing.Point(8, 34)
        Me.cbxMedida.Name = "cbxMedida"
        Me.cbxMedida.Size = New System.Drawing.Size(140, 21)
        Me.cbxMedida.TabIndex = 7
        '
        'Groupbox3
        '
        Me.Groupbox3.Controls.Add(Me.chkRedondearPrecios)
        Me.Groupbox3.Controls.Add(Me.Label11)
        Me.Groupbox3.Controls.Add(Me.Label10)
        Me.Groupbox3.Controls.Add(Me.Label9)
        Me.Groupbox3.Controls.Add(Me.txtPrecioD)
        Me.Groupbox3.Controls.Add(Me.txtPrecioC)
        Me.Groupbox3.Controls.Add(Me.txtPrecioB)
        Me.Groupbox3.Controls.Add(Me.Label8)
        Me.Groupbox3.Controls.Add(Me.txtCosto)
        Me.Groupbox3.Controls.Add(Me.Label6)
        Me.Groupbox3.Controls.Add(Me.cbxMedida)
        Me.Groupbox3.Controls.Add(Me.Label7)
        Me.Groupbox3.Controls.Add(Me.txtPrecioA)
        Me.Groupbox3.Controls.Add(Me.Label4)
        Me.Groupbox3.Enabled = False
        Me.Groupbox3.Location = New System.Drawing.Point(12, 199)
        Me.Groupbox3.Name = "Groupbox3"
        Me.Groupbox3.Size = New System.Drawing.Size(593, 113)
        Me.Groupbox3.TabIndex = 6
        Me.Groupbox3.TabStop = False
        Me.Groupbox3.Text = "Valores"
        '
        'chkRedondearPrecios
        '
        Me.chkRedondearPrecios.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkRedondearPrecios.Location = New System.Drawing.Point(399, 9)
        Me.chkRedondearPrecios.Name = "chkRedondearPrecios"
        Me.chkRedondearPrecios.Size = New System.Drawing.Size(192, 37)
        Me.chkRedondearPrecios.TabIndex = 348
        Me.chkRedondearPrecios.Text = "Redondear al entero más cercano durante precios y costos"
        Me.chkRedondearPrecios.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(326, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 347
        Me.Label11.Text = "Precio D"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(223, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 346
        Me.Label10.Text = "Precio C"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label9.Location = New System.Drawing.Point(117, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 345
        Me.Label9.Text = "Precio B"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecioD
        '
        Me.txtPrecioD.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecioD.Location = New System.Drawing.Point(329, 80)
        Me.txtPrecioD.Name = "txtPrecioD"
        Me.txtPrecioD.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPrecioD.Properties.Appearance.Options.UseBackColor = True
        Me.txtPrecioD.Properties.Appearance.Options.UseFont = True
        Me.txtPrecioD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioD.Properties.Mask.EditMask = "c"
        Me.txtPrecioD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecioD.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPrecioD.Properties.NullText = "0"
        Me.txtPrecioD.Properties.NullValuePrompt = "0"
        Me.txtPrecioD.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioD.TabIndex = 12
        '
        'txtPrecioC
        '
        Me.txtPrecioC.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecioC.Location = New System.Drawing.Point(223, 80)
        Me.txtPrecioC.Name = "txtPrecioC"
        Me.txtPrecioC.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioC.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPrecioC.Properties.Appearance.Options.UseBackColor = True
        Me.txtPrecioC.Properties.Appearance.Options.UseFont = True
        Me.txtPrecioC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioC.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioC.Properties.Mask.EditMask = "c"
        Me.txtPrecioC.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecioC.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPrecioC.Properties.NullText = "0"
        Me.txtPrecioC.Properties.NullValuePrompt = "0"
        Me.txtPrecioC.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioC.TabIndex = 11
        '
        'txtPrecioB
        '
        Me.txtPrecioB.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecioB.Location = New System.Drawing.Point(117, 80)
        Me.txtPrecioB.Name = "txtPrecioB"
        Me.txtPrecioB.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecioB.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPrecioB.Properties.Appearance.Options.UseBackColor = True
        Me.txtPrecioB.Properties.Appearance.Options.UseFont = True
        Me.txtPrecioB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioB.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioB.Properties.Mask.EditMask = "c"
        Me.txtPrecioB.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecioB.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPrecioB.Properties.NullText = "0"
        Me.txtPrecioB.Properties.NullValuePrompt = "0"
        Me.txtPrecioB.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioB.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.Location = New System.Drawing.Point(8, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 341
        Me.Label8.Text = "La medida"
        '
        'txtCosto
        '
        Me.txtCosto.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCosto.Location = New System.Drawing.Point(224, 35)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCosto.Properties.Appearance.Options.UseFont = True
        Me.txtCosto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCosto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCosto.Properties.Mask.EditMask = "c"
        Me.txtCosto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCosto.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCosto.Properties.NullText = "0"
        Me.txtCosto.Properties.NullValuePrompt = "0"
        Me.txtCosto.Size = New System.Drawing.Size(100, 20)
        Me.txtCosto.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(226, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 336
        Me.Label7.Text = "Costo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_mant_medidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 561)
        Me.Controls.Add(Me.Groupbox3)
        Me.Controls.Add(Me.cbxMoneda)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GridArticulos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAbreviatura)
        Me.Controls.Add(Me.chkDesactivar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMedida)
        Me.Controls.Add(Me.txtIDMedida)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mant_medidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "8"
        Me.Text = "Medidas"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GridArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecioA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Groupbox3.ResumeLayout(False)
        Me.Groupbox3.PerformLayout()
        CType(Me.txtPrecioD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecioC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecioB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMedida As System.Windows.Forms.TextBox
    Friend WithEvents txtIDMedida As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkDesactivar As System.Windows.Forms.CheckBox
    Friend WithEvents txtAbreviatura As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblMensajeFraccionamiento As Label
    Friend WithEvents chkFraccionamiento As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdbDinamica As RadioButton
    Friend WithEvents rdbConstante As RadioButton
    Friend WithEvents GridArticulos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label5 As Label
    Friend WithEvents cbxMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents txtPrecioA As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxMedida As ComboBox
    Friend WithEvents Groupbox3 As GroupBox
    Friend WithEvents txtCosto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPrecioD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPrecioC As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPrecioB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkRedondearPrecios As CheckBox
End Class
