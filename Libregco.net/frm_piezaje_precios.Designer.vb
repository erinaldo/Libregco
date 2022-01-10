<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_piezaje_precios
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_piezaje_precios))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblMedidaPadre = New System.Windows.Forms.Label()
        Me.txtPiezaje = New DevExpress.XtraEditors.TextEdit()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkRedondear = New System.Windows.Forms.CheckBox()
        Me.chkGuardarCalculos = New System.Windows.Forms.CheckBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPrecioD = New DevExpress.XtraEditors.TextEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPrecioC = New DevExpress.XtraEditors.TextEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPrecioB = New DevExpress.XtraEditors.TextEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrecioA = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCosto = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPrecio = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        'Me.BarCodeDataSet1 = New Libregco.BarCodeDataSet()
        Me.btnPietaje = New DevExpress.XtraEditors.SimpleButton()
        Me.chkGuardarAutPietaje = New System.Windows.Forms.CheckBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lblPrecio = New DevExpress.XtraEditors.LabelControl()
        Me.lblCosto = New DevExpress.XtraEditors.LabelControl()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.PA = New System.Windows.Forms.Label()
        Me.PB = New System.Windows.Forms.Label()
        Me.PC = New System.Windows.Forms.Label()
        Me.PD = New System.Windows.Forms.Label()
        CType(Me.txtPiezaje.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtPrecioD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecioC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecioB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecioA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.BarCodeDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(306, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Se ha determinado precios dinámico para la medida del artículo"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 46)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(406, 54)
        Me.lblDescripcion.TabIndex = 1
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMedidaPadre
        '
        Me.lblMedidaPadre.AutoSize = True
        Me.lblMedidaPadre.ForeColor = System.Drawing.Color.Firebrick
        Me.lblMedidaPadre.Location = New System.Drawing.Point(12, 24)
        Me.lblMedidaPadre.Name = "lblMedidaPadre"
        Me.lblMedidaPadre.Size = New System.Drawing.Size(0, 13)
        Me.lblMedidaPadre.TabIndex = 2
        '
        'txtPiezaje
        '
        Me.txtPiezaje.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPiezaje.Location = New System.Drawing.Point(22, 32)
        Me.txtPiezaje.Name = "txtPiezaje"
        Me.txtPiezaje.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPiezaje.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 20.0!)
        Me.txtPiezaje.Properties.Appearance.Options.UseBackColor = True
        Me.txtPiezaje.Properties.Appearance.Options.UseFont = True
        Me.txtPiezaje.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPiezaje.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPiezaje.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPiezaje.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPiezaje.Properties.Mask.EditMask = "n"
        Me.txtPiezaje.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPiezaje.Properties.NullText = "0"
        Me.txtPiezaje.Properties.NullValuePrompt = "0"
        Me.txtPiezaje.Size = New System.Drawing.Size(127, 40)
        Me.txtPiezaje.TabIndex = 9
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(-6, 31)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(438, 23)
        Me.SeparatorControl1.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PD)
        Me.GroupBox2.Controls.Add(Me.txtPrecio)
        Me.GroupBox2.Controls.Add(Me.PC)
        Me.GroupBox2.Controls.Add(Me.PB)
        Me.GroupBox2.Controls.Add(Me.chkRedondear)
        Me.GroupBox2.Controls.Add(Me.chkGuardarCalculos)
        Me.GroupBox2.Controls.Add(Me.SimpleButton1)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtPrecioD)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtPrecioC)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtPrecioB)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtPrecioA)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtCosto)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.PA)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 252)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 237)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cálculos"
        '
        'chkRedondear
        '
        Me.chkRedondear.AutoSize = True
        Me.chkRedondear.Location = New System.Drawing.Point(281, 1)
        Me.chkRedondear.Name = "chkRedondear"
        Me.chkRedondear.Size = New System.Drawing.Size(119, 17)
        Me.chkRedondear.TabIndex = 356
        Me.chkRedondear.Text = "Redondear cálculos"
        Me.chkRedondear.UseVisualStyleBackColor = True
        '
        'chkGuardarCalculos
        '
        Me.chkGuardarCalculos.AutoSize = True
        Me.chkGuardarCalculos.Location = New System.Drawing.Point(63, 208)
        Me.chkGuardarCalculos.Name = "chkGuardarCalculos"
        Me.chkGuardarCalculos.Size = New System.Drawing.Size(281, 17)
        Me.chkGuardarCalculos.TabIndex = 355
        Me.chkGuardarCalculos.Text = "Guardar automáticamente cálculo de costos y precios"
        Me.chkGuardarCalculos.UseVisualStyleBackColor = True
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(11, 179)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(385, 23)
        Me.SimpleButton1.TabIndex = 352
        Me.SimpleButton1.Text = "Establecer cálculo de costos y precios"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(220, 158)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 1)
        Me.Label15.TabIndex = 351
        Me.Label15.Text = "Label15"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(220, 133)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 1)
        Me.Label14.TabIndex = 350
        Me.Label14.Text = "Label14"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(220, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 1)
        Me.Label13.TabIndex = 349
        Me.Label13.Text = "Label13"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(220, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 1)
        Me.Label12.TabIndex = 348
        Me.Label12.Text = "Label12"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(219, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(1, 95)
        Me.Label11.TabIndex = 347
        '
        'txtPrecioD
        '
        Me.txtPrecioD.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecioD.Location = New System.Drawing.Point(285, 149)
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
        Me.txtPrecioD.Size = New System.Drawing.Size(87, 20)
        Me.txtPrecioD.TabIndex = 345
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(265, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 13)
        Me.Label10.TabIndex = 346
        Me.Label10.Text = "D"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecioC
        '
        Me.txtPrecioC.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecioC.Location = New System.Drawing.Point(285, 123)
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
        Me.txtPrecioC.Size = New System.Drawing.Size(87, 20)
        Me.txtPrecioC.TabIndex = 343
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label9.Location = New System.Drawing.Point(265, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 13)
        Me.Label9.TabIndex = 344
        Me.Label9.Text = "C"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecioB
        '
        Me.txtPrecioB.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecioB.Location = New System.Drawing.Point(285, 97)
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
        Me.txtPrecioB.Size = New System.Drawing.Size(87, 20)
        Me.txtPrecioB.TabIndex = 341
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(265, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 342
        Me.Label8.Text = "B"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecioA
        '
        Me.txtPrecioA.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecioA.Location = New System.Drawing.Point(285, 71)
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
        Me.txtPrecioA.Size = New System.Drawing.Size(87, 20)
        Me.txtPrecioA.TabIndex = 339
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(265, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 340
        Me.Label7.Text = "A"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCosto
        '
        Me.txtCosto.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCosto.Location = New System.Drawing.Point(36, 35)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCosto.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtCosto.Properties.Appearance.Options.UseBackColor = True
        Me.txtCosto.Properties.Appearance.Options.UseFont = True
        Me.txtCosto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCosto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCosto.Properties.Mask.EditMask = "c"
        Me.txtCosto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCosto.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCosto.Properties.NullText = "0"
        Me.txtCosto.Properties.NullValuePrompt = "0"
        Me.txtCosto.Size = New System.Drawing.Size(158, 30)
        Me.txtCosto.TabIndex = 337
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(33, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 338
        Me.Label6.Text = "Costo"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio
        '
        Me.txtPrecio.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrecio.Location = New System.Drawing.Point(214, 35)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPrecio.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtPrecio.Properties.Appearance.Options.UseBackColor = True
        Me.txtPrecio.Properties.Appearance.Options.UseFont = True
        Me.txtPrecio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecio.Properties.Mask.EditMask = "c"
        Me.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecio.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPrecio.Properties.NullText = "0"
        Me.txtPrecio.Properties.NullValuePrompt = "0"
        Me.txtPrecio.Size = New System.Drawing.Size(158, 30)
        Me.txtPrecio.TabIndex = 335
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(211, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 336
        Me.Label5.Text = "Precio Base"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        ''BarCodeDataSet1
        ''
        'Me.BarCodeDataSet1.DataSetName = "BarCodeDataSet"
        'Me.BarCodeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        ''
        'btnPietaje
        '
        Me.btnPietaje.Location = New System.Drawing.Point(5, 82)
        Me.btnPietaje.Name = "btnPietaje"
        Me.btnPietaje.Size = New System.Drawing.Size(385, 23)
        Me.btnPietaje.TabIndex = 353
        Me.btnPietaje.Text = "Establecer pietaje"
        '
        'chkGuardarAutPietaje
        '
        Me.chkGuardarAutPietaje.AutoSize = True
        Me.chkGuardarAutPietaje.Location = New System.Drawing.Point(98, 111)
        Me.chkGuardarAutPietaje.Name = "chkGuardarAutPietaje"
        Me.chkGuardarAutPietaje.Size = New System.Drawing.Size(198, 17)
        Me.chkGuardarAutPietaje.TabIndex = 354
        Me.chkGuardarAutPietaje.Text = "Guardar automáticamente el pietaje"
        Me.chkGuardarAutPietaje.UseVisualStyleBackColor = True
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 501)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(430, 25)
        Me.BarraEstado.TabIndex = 332
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
        'GroupControl1
        '
        Me.GroupControl1.AllowHtmlText = True
        Me.GroupControl1.Controls.Add(Me.lblPrecio)
        Me.GroupControl1.Controls.Add(Me.lblCosto)
        Me.GroupControl1.Controls.Add(Me.chkGuardarAutPietaje)
        Me.GroupControl1.Controls.Add(Me.txtPiezaje)
        Me.GroupControl1.Controls.Add(Me.btnPietaje)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 103)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(406, 144)
        Me.GroupControl1.TabIndex = 356
        Me.GroupControl1.Text = "Escriba la cantidad de que contiene la medida"
        '
        'lblPrecio
        '
        Me.lblPrecio.AllowHtmlString = True
        Me.lblPrecio.Location = New System.Drawing.Point(159, 54)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(33, 13)
        Me.lblPrecio.TabIndex = 356
        Me.lblPrecio.Text = "Precio:"
        '
        'lblCosto
        '
        Me.lblCosto.AllowHtmlString = True
        Me.lblCosto.Location = New System.Drawing.Point(159, 31)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(32, 13)
        Me.lblCosto.TabIndex = 355
        Me.lblCosto.Text = "Costo:"
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.Products_x48, "Pietaje guardado", "Se ha establecido el piezaje satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("ab2d2ce9-aad7-4127-b45c-480398674533", Global.Libregco.My.Resources.Resources.Products_x48, "Costos y precios establecidos", "Se han establecido los costos y precios satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'PA
        '
        Me.PA.AutoSize = True
        Me.PA.Location = New System.Drawing.Point(222, 68)
        Me.PA.Name = "PA"
        Me.PA.Size = New System.Drawing.Size(0, 13)
        Me.PA.TabIndex = 357
        '
        'PB
        '
        Me.PB.AutoSize = True
        Me.PB.Location = New System.Drawing.Point(222, 90)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(0, 13)
        Me.PB.TabIndex = 358
        '
        'PC
        '
        Me.PC.AutoSize = True
        Me.PC.Location = New System.Drawing.Point(222, 116)
        Me.PC.Name = "PC"
        Me.PC.Size = New System.Drawing.Size(0, 13)
        Me.PC.TabIndex = 359
        '
        'PD
        '
        Me.PD.AutoSize = True
        Me.PD.Location = New System.Drawing.Point(222, 142)
        Me.PD.Name = "PD"
        Me.PD.Size = New System.Drawing.Size(0, 13)
        Me.PD.TabIndex = 360
        '
        'frm_piezaje_precios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 526)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblMedidaPadre)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_piezaje_precios"
        Me.Text = "Piezaje"
        CType(Me.txtPiezaje.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtPrecioD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecioC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecioB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecioA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.BarCodeDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents lblMedidaPadre As Label
    Friend WithEvents txtPiezaje As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtCosto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPrecio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents chkGuardarAutPietaje As CheckBox
    Friend WithEvents btnPietaje As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkGuardarCalculos As CheckBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPrecioD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPrecioC As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPrecioB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPrecioA As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblPrecio As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCosto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkRedondear As CheckBox
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents PD As Label
    Friend WithEvents PC As Label
    Friend WithEvents PB As Label
    Friend WithEvents PA As Label
End Class
