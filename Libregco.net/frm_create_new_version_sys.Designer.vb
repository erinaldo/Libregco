<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_create_new_version_sys
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_create_new_version_sys))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtIDBuild = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMayor = New System.Windows.Forms.TextBox()
        Me.txtMenor = New System.Windows.Forms.TextBox()
        Me.txtCompilacion = New System.Windows.Forms.TextBox()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpLaunched = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSizeExe = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.btnAdjuntarEspecificacion = New System.Windows.Forms.Button()
        Me.txtEspecificacion = New System.Windows.Forms.TextBox()
        Me.DgvNotas = New System.Windows.Forms.DataGridView()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.IcoMenu = New System.Windows.Forms.MenuStrip()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NUPRatio = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDirectory = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSizeDirectory = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEliminarLogo = New System.Windows.Forms.Button()
        Me.btnCargarLogo = New System.Windows.Forms.Button()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.PicImagenLogo = New System.Windows.Forms.PictureBox()
        Me.txtRutaLogo = New System.Windows.Forms.TextBox()
        Me.lblIDNotificacion = New System.Windows.Forms.Label()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureNotification = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ratio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modificar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.DgvNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.IcoMenu.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.NUPRatio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PicImagenLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIDBuild
        '
        Me.txtIDBuild.Enabled = False
        Me.txtIDBuild.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDBuild.Location = New System.Drawing.Point(97, 9)
        Me.txtIDBuild.Name = "txtIDBuild"
        Me.txtIDBuild.ReadOnly = True
        Me.txtIDBuild.Size = New System.Drawing.Size(114, 20)
        Me.txtIDBuild.TabIndex = 0
        Me.txtIDBuild.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID Build"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Version"
        '
        'txtMayor
        '
        Me.txtMayor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtMayor.Location = New System.Drawing.Point(97, 35)
        Me.txtMayor.Name = "txtMayor"
        Me.txtMayor.Size = New System.Drawing.Size(54, 20)
        Me.txtMayor.TabIndex = 0
        Me.txtMayor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMenor
        '
        Me.txtMenor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtMenor.Location = New System.Drawing.Point(157, 35)
        Me.txtMenor.Name = "txtMenor"
        Me.txtMenor.Size = New System.Drawing.Size(54, 20)
        Me.txtMenor.TabIndex = 1
        Me.txtMenor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCompilacion
        '
        Me.txtCompilacion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCompilacion.Location = New System.Drawing.Point(217, 35)
        Me.txtCompilacion.Name = "txtCompilacion"
        Me.txtCompilacion.Size = New System.Drawing.Size(54, 20)
        Me.txtCompilacion.TabIndex = 2
        Me.txtCompilacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtVersion
        '
        Me.txtVersion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtVersion.Location = New System.Drawing.Point(277, 35)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(54, 20)
        Me.txtVersion.TabIndex = 3
        Me.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Launched in"
        '
        'dtpLaunched
        '
        Me.dtpLaunched.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpLaunched.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLaunched.Location = New System.Drawing.Point(97, 61)
        Me.dtpLaunched.Name = "dtpLaunched"
        Me.dtpLaunched.Size = New System.Drawing.Size(98, 20)
        Me.dtpLaunched.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Exe Size"
        '
        'txtSizeExe
        '
        Me.txtSizeExe.Enabled = False
        Me.txtSizeExe.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSizeExe.Location = New System.Drawing.Point(97, 113)
        Me.txtSizeExe.Name = "txtSizeExe"
        Me.txtSizeExe.ReadOnly = True
        Me.txtSizeExe.Size = New System.Drawing.Size(54, 20)
        Me.txtSizeExe.TabIndex = 6
        Me.txtSizeExe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Location Exe"
        '
        'txtLocation
        '
        Me.txtLocation.Enabled = False
        Me.txtLocation.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtLocation.Location = New System.Drawing.Point(97, 87)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(625, 20)
        Me.txtLocation.TabIndex = 5
        '
        'btnLocation
        '
        Me.btnLocation.Location = New System.Drawing.Point(728, 86)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(28, 22)
        Me.btnLocation.TabIndex = 13
        Me.btnLocation.Text = "..."
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'btnAdjuntarEspecificacion
        '
        Me.btnAdjuntarEspecificacion.Location = New System.Drawing.Point(804, 24)
        Me.btnAdjuntarEspecificacion.Name = "btnAdjuntarEspecificacion"
        Me.btnAdjuntarEspecificacion.Size = New System.Drawing.Size(157, 66)
        Me.btnAdjuntarEspecificacion.TabIndex = 2
        Me.btnAdjuntarEspecificacion.Text = "Adjuntar"
        Me.btnAdjuntarEspecificacion.UseVisualStyleBackColor = True
        '
        'txtEspecificacion
        '
        Me.txtEspecificacion.Location = New System.Drawing.Point(125, 22)
        Me.txtEspecificacion.Multiline = True
        Me.txtEspecificacion.Name = "txtEspecificacion"
        Me.txtEspecificacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEspecificacion.Size = New System.Drawing.Size(612, 66)
        Me.txtEspecificacion.TabIndex = 0
        '
        'DgvNotas
        '
        Me.DgvNotas.AllowUserToAddRows = False
        Me.DgvNotas.AllowUserToDeleteRows = False
        Me.DgvNotas.AllowUserToResizeColumns = False
        Me.DgvNotas.AllowUserToResizeRows = False
        Me.DgvNotas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DgvNotas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DgvNotas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvNotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.PictureNotification, Me.DataGridViewTextBoxColumn2, Me.Ratio, Me.Ruta, Me.Modificar, Me.Eliminar})
        Me.DgvNotas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvNotas.Location = New System.Drawing.Point(2, 107)
        Me.DgvNotas.MultiSelect = False
        Me.DgvNotas.Name = "DgvNotas"
        Me.DgvNotas.ReadOnly = True
        Me.DgvNotas.RowHeadersVisible = False
        Me.DgvNotas.RowHeadersWidth = 120
        Me.DgvNotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvNotas.RowTemplate.Height = 26
        Me.DgvNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvNotas.Size = New System.Drawing.Size(962, 294)
        Me.DgvNotas.TabIndex = 14
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.IcoMenu)
        Me.IconPanel.Location = New System.Drawing.Point(0, 632)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(986, 99)
        Me.IconPanel.TabIndex = 236
        '
        'IcoMenu
        '
        Me.IcoMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IcoMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnGuardar, Me.btnNuevo})
        Me.IcoMenu.Location = New System.Drawing.Point(0, 0)
        Me.IcoMenu.Name = "IcoMenu"
        Me.IcoMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.IcoMenu.Size = New System.Drawing.Size(986, 99)
        Me.IcoMenu.TabIndex = 192
        Me.IcoMenu.Text = "MenuStrip2"
        '
        'btnBuscar
        '
        Me.btnBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnNuevo
        '
        Me.btnNuevo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar, Me.ToolStripButton1})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 729)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(986, 25)
        Me.BarraEstado.TabIndex = 347
        Me.BarraEstado.Text = "ToolStrip1"
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(107, 22)
        Me.ToolStripButton1.Text = "Ir al último parche"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label7.Location = New System.Drawing.Point(153, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 348
        Me.Label7.Text = "megabytes"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(741, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 349
        Me.Label8.Text = "Ratio"
        '
        'NUPRatio
        '
        Me.NUPRatio.Location = New System.Drawing.Point(744, 24)
        Me.NUPRatio.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUPRatio.Name = "NUPRatio"
        Me.NUPRatio.Size = New System.Drawing.Size(54, 21)
        Me.NUPRatio.TabIndex = 1
        Me.NUPRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NUPRatio.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label9.Location = New System.Drawing.Point(153, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 355
        Me.Label9.Text = "megabytes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(12, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 354
        Me.Label10.Text = "Directory"
        '
        'txtDirectory
        '
        Me.txtDirectory.Enabled = False
        Me.txtDirectory.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDirectory.Location = New System.Drawing.Point(97, 139)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.ReadOnly = True
        Me.txtDirectory.Size = New System.Drawing.Size(659, 20)
        Me.txtDirectory.TabIndex = 351
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(12, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 353
        Me.Label11.Text = "Directory Size"
        '
        'txtSizeDirectory
        '
        Me.txtSizeDirectory.Enabled = False
        Me.txtSizeDirectory.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSizeDirectory.Location = New System.Drawing.Point(97, 165)
        Me.txtSizeDirectory.Name = "txtSizeDirectory"
        Me.txtSizeDirectory.ReadOnly = True
        Me.txtSizeDirectory.Size = New System.Drawing.Size(54, 20)
        Me.txtSizeDirectory.TabIndex = 352
        Me.txtSizeDirectory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(Me.btnEliminarLogo)
        Me.Panel1.Controls.Add(Me.btnCargarLogo)
        Me.Panel1.Controls.Add(Me.btnAbrir)
        Me.Panel1.Controls.Add(Me.PicImagenLogo)
        Me.Panel1.Location = New System.Drawing.Point(767, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(210, 204)
        Me.Panel1.TabIndex = 358
        '
        'btnEliminarLogo
        '
        Me.btnEliminarLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarLogo.BackgroundImage = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnEliminarLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarLogo.Location = New System.Drawing.Point(173, 167)
        Me.btnEliminarLogo.Name = "btnEliminarLogo"
        Me.btnEliminarLogo.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarLogo.TabIndex = 34
        Me.btnEliminarLogo.UseVisualStyleBackColor = True
        '
        'btnCargarLogo
        '
        Me.btnCargarLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCargarLogo.BackgroundImage = Global.Libregco.My.Resources.Resources.Image_Capture_x32
        Me.btnCargarLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCargarLogo.Location = New System.Drawing.Point(111, 167)
        Me.btnCargarLogo.Name = "btnCargarLogo"
        Me.btnCargarLogo.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarLogo.TabIndex = 32
        Me.btnCargarLogo.UseVisualStyleBackColor = True
        '
        'btnAbrir
        '
        Me.btnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbrir.BackgroundImage = Global.Libregco.My.Resources.Resources.Preview_x32
        Me.btnAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbrir.Location = New System.Drawing.Point(142, 167)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(32, 32)
        Me.btnAbrir.TabIndex = 33
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'PicImagenLogo
        '
        Me.PicImagenLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.PicImagenLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicImagenLogo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicImagenLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicImagenLogo.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PicImagenLogo.Location = New System.Drawing.Point(0, 0)
        Me.PicImagenLogo.Name = "PicImagenLogo"
        Me.PicImagenLogo.Size = New System.Drawing.Size(210, 204)
        Me.PicImagenLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImagenLogo.TabIndex = 178
        Me.PicImagenLogo.TabStop = False
        '
        'txtRutaLogo
        '
        Me.txtRutaLogo.Enabled = False
        Me.txtRutaLogo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtRutaLogo.Location = New System.Drawing.Point(755, 253)
        Me.txtRutaLogo.Multiline = True
        Me.txtRutaLogo.Name = "txtRutaLogo"
        Me.txtRutaLogo.ReadOnly = True
        Me.txtRutaLogo.Size = New System.Drawing.Size(212, 22)
        Me.txtRutaLogo.TabIndex = 359
        Me.txtRutaLogo.Visible = False
        '
        'lblIDNotificacion
        '
        Me.lblIDNotificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblIDNotificacion.Location = New System.Drawing.Point(239, 373)
        Me.lblIDNotificacion.Name = "lblIDNotificacion"
        Me.lblIDNotificacion.Size = New System.Drawing.Size(78, 15)
        Me.lblIDNotificacion.TabIndex = 360
        Me.lblIDNotificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, 206)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(986, 23)
        Me.SeparatorControl1.TabIndex = 361
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.PictureBox1)
        Me.GroupControl1.Controls.Add(Me.txtEspecificacion)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.NUPRatio)
        Me.GroupControl1.Controls.Add(Me.btnAdjuntarEspecificacion)
        Me.GroupControl1.Controls.Add(Me.DgvNotas)
        Me.GroupControl1.Location = New System.Drawing.Point(11, 226)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(966, 403)
        Me.GroupControl1.TabIndex = 362
        Me.GroupControl1.Text = "Notas de la versión"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(123, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 351
        Me.Label6.Text = "Descripción"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PictureBox1.Location = New System.Drawing.Point(3, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(117, 82)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ratio"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ruta"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 40
        '
        'PictureNotification
        '
        Me.PictureNotification.HeaderText = ""
        Me.PictureNotification.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.PictureNotification.Name = "PictureNotification"
        Me.PictureNotification.ReadOnly = True
        Me.PictureNotification.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn2.HeaderText = "Notificaciones"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 620
        '
        'Ratio
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Ratio.DefaultCellStyle = DataGridViewCellStyle2
        Me.Ratio.HeaderText = "Ratio"
        Me.Ratio.Name = "Ratio"
        Me.Ratio.ReadOnly = True
        Me.Ratio.Width = 60
        '
        'Ruta
        '
        Me.Ruta.HeaderText = "Ruta"
        Me.Ruta.Name = "Ruta"
        Me.Ruta.ReadOnly = True
        Me.Ruta.Visible = False
        '
        'Modificar
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(0, 35, 0, 35)
        Me.Modificar.DefaultCellStyle = DataGridViewCellStyle3
        Me.Modificar.HeaderText = "Modificar"
        Me.Modificar.Name = "Modificar"
        Me.Modificar.ReadOnly = True
        Me.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Modificar.Text = "Modificar"
        Me.Modificar.UseColumnTextForButtonValue = True
        Me.Modificar.Width = 70
        '
        'Eliminar
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(0, 35, 0, 35)
        Me.Eliminar.DefaultCellStyle = DataGridViewCellStyle4
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.ReadOnly = True
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseColumnTextForButtonValue = True
        Me.Eliminar.Width = 70
        '
        'frm_create_new_version_sys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(986, 754)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.btnLocation)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.lblIDNotificacion)
        Me.Controls.Add(Me.txtRutaLogo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDirectory)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSizeDirectory)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSizeExe)
        Me.Controls.Add(Me.dtpLaunched)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.txtCompilacion)
        Me.Controls.Add(Me.txtMenor)
        Me.Controls.Add(Me.txtMayor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIDBuild)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_create_new_version_sys"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nueva versión del sistema"
        CType(Me.DgvNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.IcoMenu.ResumeLayout(False)
        Me.IcoMenu.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.NUPRatio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PicImagenLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIDBuild As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMayor As System.Windows.Forms.TextBox
    Friend WithEvents txtMenor As System.Windows.Forms.TextBox
    Friend WithEvents txtCompilacion As System.Windows.Forms.TextBox
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpLaunched As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSizeExe As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents btnAdjuntarEspecificacion As System.Windows.Forms.Button
    Friend WithEvents txtEspecificacion As System.Windows.Forms.TextBox
    Friend WithEvents DgvNotas As System.Windows.Forms.DataGridView
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents IcoMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NUPRatio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSizeDirectory As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents btnEliminarLogo As System.Windows.Forms.Button
    Private WithEvents btnCargarLogo As System.Windows.Forms.Button
    Private WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents PicImagenLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtRutaLogo As System.Windows.Forms.TextBox
    Friend WithEvents lblIDNotificacion As System.Windows.Forms.Label
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PictureNotification As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Ratio As DataGridViewTextBoxColumn
    Friend WithEvents Ruta As DataGridViewTextBoxColumn
    Friend WithEvents Modificar As DataGridViewButtonColumn
    Friend WithEvents Eliminar As DataGridViewButtonColumn
End Class
