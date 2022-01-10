<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_eventos_boleteria
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_eventos_boleteria))
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIDEvento = New System.Windows.Forms.TextBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.txtMontoAplicable = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTermino = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEvento = New System.Windows.Forms.TextBox()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLimiteSecuencia = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUltimaSecuencia = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblEjemploNumeracion = New System.Windows.Forms.Label()
        Me.txtCantCaracteres = New System.Windows.Forms.TextBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicMinLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.chkAplicarFactura = New System.Windows.Forms.CheckBox()
        Me.chkAplicarPagos = New System.Windows.Forms.CheckBox()
        Me.txtPoliticas = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CbxInstalledPrinters = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(636, 1)
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicBoxLogo.ImageLocation = ""
        Me.PicBoxLogo.Location = New System.Drawing.Point(6, 6)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 328
        Me.PicBoxLogo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtIDEvento)
        Me.GroupBox1.Controls.Add(Me.lblPeriodo)
        Me.GroupBox1.Controls.Add(Me.txtMontoAplicable)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpTermino)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpInicio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtBase)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtEvento)
        Me.GroupBox1.Controls.Add(Me.PicLogo)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1050, 234)
        Me.GroupBox1.TabIndex = 329
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generales"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(333, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "ID"
        '
        'txtIDEvento
        '
        Me.txtIDEvento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEvento.Location = New System.Drawing.Point(336, 40)
        Me.txtIDEvento.Name = "txtIDEvento"
        Me.txtIDEvento.ReadOnly = True
        Me.txtIDEvento.Size = New System.Drawing.Size(62, 23)
        Me.txtIDEvento.TabIndex = 11
        Me.txtIDEvento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPeriodo.Location = New System.Drawing.Point(336, 211)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(360, 15)
        Me.lblPeriodo.TabIndex = 7
        Me.lblPeriodo.Text = "Período del evento: "
        '
        'txtMontoAplicable
        '
        Me.txtMontoAplicable.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.txtMontoAplicable.Location = New System.Drawing.Point(844, 188)
        Me.txtMontoAplicable.Name = "txtMontoAplicable"
        Me.txtMontoAplicable.Size = New System.Drawing.Size(198, 32)
        Me.txtMontoAplicable.TabIndex = 10
        Me.txtMontoAplicable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(726, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 30)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Aplicable un boleto por cada RD$"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(504, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha de termino"
        '
        'dtpTermino
        '
        Me.dtpTermino.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.dtpTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTermino.Location = New System.Drawing.Point(507, 183)
        Me.dtpTermino.Name = "dtpTermino"
        Me.dtpTermino.Size = New System.Drawing.Size(165, 23)
        Me.dtpTermino.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(333, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha de inicio"
        '
        'dtpInicio
        '
        Me.dtpInicio.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicio.Location = New System.Drawing.Point(336, 183)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(165, 23)
        Me.dtpInicio.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(336, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Base"
        '
        'txtBase
        '
        Me.txtBase.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBase.Location = New System.Drawing.Point(336, 87)
        Me.txtBase.Multiline = True
        Me.txtBase.Name = "txtBase"
        Me.txtBase.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBase.Size = New System.Drawing.Size(707, 75)
        Me.txtBase.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(401, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Evento"
        '
        'txtEvento
        '
        Me.txtEvento.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEvento.Location = New System.Drawing.Point(404, 37)
        Me.txtEvento.Name = "txtEvento"
        Me.txtEvento.Size = New System.Drawing.Size(639, 29)
        Me.txtEvento.TabIndex = 1
        '
        'PicLogo
        '
        Me.PicLogo.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PicLogo.Location = New System.Drawing.Point(6, 18)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(324, 210)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 0
        Me.PicLogo.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 342)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1050, 136)
        Me.GroupBox2.TabIndex = 330
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Especificaciones"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtLimiteSecuencia)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtUltimaSecuencia)
        Me.GroupBox4.Location = New System.Drawing.Point(341, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(701, 105)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Secuencias"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(367, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 15)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Límite de la secuencia"
        '
        'txtLimiteSecuencia
        '
        Me.txtLimiteSecuencia.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimiteSecuencia.Location = New System.Drawing.Point(369, 37)
        Me.txtLimiteSecuencia.Name = "txtLimiteSecuencia"
        Me.txtLimiteSecuencia.Size = New System.Drawing.Size(294, 50)
        Me.txtLimiteSecuencia.TabIndex = 5
        Me.txtLimiteSecuencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(36, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 15)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Última secuencia generada"
        '
        'txtUltimaSecuencia
        '
        Me.txtUltimaSecuencia.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimaSecuencia.Location = New System.Drawing.Point(38, 37)
        Me.txtUltimaSecuencia.Name = "txtUltimaSecuencia"
        Me.txtUltimaSecuencia.Size = New System.Drawing.Size(294, 50)
        Me.txtUltimaSecuencia.TabIndex = 3
        Me.txtUltimaSecuencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.lblEjemploNumeracion)
        Me.GroupBox3.Controls.Add(Me.txtCantCaracteres)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(324, 105)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Formato"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(167, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 15)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Cant. Carácteres"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label7.Location = New System.Drawing.Point(5, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Ejemplo"
        '
        'lblEjemploNumeracion
        '
        Me.lblEjemploNumeracion.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblEjemploNumeracion.Font = New System.Drawing.Font("Segoe UI Semilight", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEjemploNumeracion.Location = New System.Drawing.Point(1, 16)
        Me.lblEjemploNumeracion.Name = "lblEjemploNumeracion"
        Me.lblEjemploNumeracion.Size = New System.Drawing.Size(322, 40)
        Me.lblEjemploNumeracion.TabIndex = 0
        Me.lblEjemploNumeracion.Text = "1"
        Me.lblEjemploNumeracion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCantCaracteres
        '
        Me.txtCantCaracteres.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantCaracteres.Location = New System.Drawing.Point(266, 67)
        Me.txtCantCaracteres.Name = "txtCantCaracteres"
        Me.txtCantCaracteres.Size = New System.Drawing.Size(52, 23)
        Me.txtCantCaracteres.TabIndex = 12
        Me.txtCantCaracteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicMinLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 624)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1068, 25)
        Me.BarraEstado.TabIndex = 331
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicMinLogo
        '
        Me.PicMinLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicMinLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicMinLogo.Name = "PicMinLogo"
        Me.PicMinLogo.Size = New System.Drawing.Size(23, 22)
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
        'chkAplicarFactura
        '
        Me.chkAplicarFactura.AutoSize = True
        Me.chkAplicarFactura.Location = New System.Drawing.Point(11, 22)
        Me.chkAplicarFactura.Name = "chkAplicarFactura"
        Me.chkAplicarFactura.Size = New System.Drawing.Size(142, 19)
        Me.chkAplicarFactura.TabIndex = 332
        Me.chkAplicarFactura.Text = "Aplicar en facturación"
        Me.chkAplicarFactura.UseVisualStyleBackColor = True
        '
        'chkAplicarPagos
        '
        Me.chkAplicarPagos.AutoSize = True
        Me.chkAplicarPagos.Location = New System.Drawing.Point(159, 22)
        Me.chkAplicarPagos.Name = "chkAplicarPagos"
        Me.chkAplicarPagos.Size = New System.Drawing.Size(114, 19)
        Me.chkAplicarPagos.TabIndex = 333
        Me.chkAplicarPagos.Text = "Aplicar en pagos"
        Me.chkAplicarPagos.UseVisualStyleBackColor = True
        '
        'txtPoliticas
        '
        Me.txtPoliticas.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPoliticas.Location = New System.Drawing.Point(352, 503)
        Me.txtPoliticas.Multiline = True
        Me.txtPoliticas.Name = "txtPoliticas"
        Me.txtPoliticas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPoliticas.Size = New System.Drawing.Size(707, 110)
        Me.txtPoliticas.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(349, 485)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 15)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Políticas del concurso"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkAplicarPagos)
        Me.GroupBox5.Controls.Add(Me.chkAplicarFactura)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 480)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(334, 56)
        Me.GroupBox5.TabIndex = 334
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Aplicación"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.PictureBox1.Location = New System.Drawing.Point(122, 580)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 354
        Me.PictureBox1.TabStop = False
        '
        'CbxInstalledPrinters
        '
        Me.CbxInstalledPrinters.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CbxInstalledPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxInstalledPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxInstalledPrinters.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxInstalledPrinters.FormattingEnabled = True
        Me.CbxInstalledPrinters.Location = New System.Drawing.Point(149, 583)
        Me.CbxInstalledPrinters.Name = "CbxInstalledPrinters"
        Me.CbxInstalledPrinters.Size = New System.Drawing.Size(194, 23)
        Me.CbxInstalledPrinters.TabIndex = 353
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label12.Location = New System.Drawing.Point(10, 587)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 13)
        Me.Label12.TabIndex = 352
        Me.Label12.Text = "Punto de impresión"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.PictureBox2.Location = New System.Drawing.Point(122, 548)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 357
        Me.PictureBox2.TabStop = False
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(149, 551)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(194, 23)
        Me.CbxFormato.TabIndex = 356
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(10, 555)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 13)
        Me.Label13.TabIndex = 355
        Me.Label13.Text = "Formato de Boleta"
        '
        'frm_eventos_boleteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 649)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CbxFormato)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CbxInstalledPrinters)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtPoliticas)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_eventos_boleteria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "262"
        Me.Text = "Eventos de boletería"
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnAnular As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents PicBoxLogo As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtMontoAplicable As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTermino As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBase As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEvento As TextBox
    Friend WithEvents PicLogo As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtLimiteSecuencia As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtUltimaSecuencia As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblEjemploNumeracion As Label
    Friend WithEvents txtCantCaracteres As TextBox
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicMinLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents chkAplicarFactura As CheckBox
    Friend WithEvents chkAplicarPagos As CheckBox
    Friend WithEvents txtPoliticas As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtIDEvento As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CbxInstalledPrinters As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents CbxFormato As ComboBox
    Friend WithEvents Label13 As Label
End Class
