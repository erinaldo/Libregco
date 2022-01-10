<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_gestiones_clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_gestiones_clientes))
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.PicCliente = New System.Windows.Forms.Panel()
        Me.SimilarFindButton = New System.Windows.Forms.Panel()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.label20 = New System.Windows.Forms.Label()
        Me.label21 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCobradorC = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtIDCobradorC = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtBalanceGral = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.label42 = New System.Windows.Forms.Label()
        Me.txtInfoAdicional = New System.Windows.Forms.TextBox()
        Me.txtIDGestion = New System.Windows.Forms.TextBox()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PicCliente.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip1)
        Me.IconPanel.Location = New System.Drawing.Point(470, 1)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 194
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.GuardarToolStripMenuItem, Me.btnBuscar, Me.btnEliminar, Me.btnImprimir})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(434, 99)
        Me.MenuStrip1.TabIndex = 192
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.GuardarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.GuardarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(84, 95)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        Me.GuardarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 4)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 329
        Me.PicBoxLogo.TabStop = False
        '
        'PicCliente
        '
        Me.PicCliente.BackgroundImage = Global.Libregco.My.Resources.Resources.no_photo
        Me.PicCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicCliente.Controls.Add(Me.SimilarFindButton)
        Me.PicCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicCliente.Location = New System.Drawing.Point(108, 127)
        Me.PicCliente.Name = "PicCliente"
        Me.PicCliente.Size = New System.Drawing.Size(125, 125)
        Me.PicCliente.TabIndex = 432
        '
        'SimilarFindButton
        '
        Me.SimilarFindButton.BackColor = System.Drawing.Color.Transparent
        Me.SimilarFindButton.BackgroundImage = Global.Libregco.My.Resources.Resources.Search_x32
        Me.SimilarFindButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimilarFindButton.Location = New System.Drawing.Point(93, 92)
        Me.SimilarFindButton.Name = "SimilarFindButton"
        Me.SimilarFindButton.Size = New System.Drawing.Size(32, 32)
        Me.SimilarFindButton.TabIndex = 10
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Control
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(244, 135)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(461, 29)
        Me.txtNombre.TabIndex = 421
        Me.txtNombre.TabStop = False
        Me.txtNombre.Text = "No hay un cliente seleccionado"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.SystemColors.Control
        Me.txtIDCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtIDCliente.Location = New System.Drawing.Point(244, 164)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(65, 16)
        Me.txtIDCliente.TabIndex = 420
        Me.txtIDCliente.TabStop = False
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(244, 119)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(45, 13)
        Me.nombre_label.TabIndex = 422
        Me.nombre_label.Text = "Nombre"
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label20.Location = New System.Drawing.Point(244, 183)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(84, 13)
        Me.label20.TabIndex = 423
        Me.label20.Text = "Balance General"
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label21.Location = New System.Drawing.Point(244, 213)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(67, 13)
        Me.label21.TabIndex = 424
        Me.label21.Text = "Último Pago"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.BackColor = System.Drawing.SystemColors.Control
        Me.txtUltimoPago.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(331, 209)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(147, 20)
        Me.txtUltimoPago.TabIndex = 425
        Me.txtUltimoPago.TabStop = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Location = New System.Drawing.Point(700, 148)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(0, 0)
        Me.btnBuscarCliente.TabIndex = 433
        Me.btnBuscarCliente.Text = "Button1"
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label22.Location = New System.Drawing.Point(510, 172)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(1, 60)
        Me.Label22.TabIndex = 430
        '
        'txtCobradorC
        '
        Me.txtCobradorC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCobradorC.BackColor = System.Drawing.SystemColors.Control
        Me.txtCobradorC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCobradorC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobradorC.Location = New System.Drawing.Point(521, 200)
        Me.txtCobradorC.Name = "txtCobradorC"
        Me.txtCobradorC.ReadOnly = True
        Me.txtCobradorC.Size = New System.Drawing.Size(329, 16)
        Me.txtCobradorC.TabIndex = 428
        Me.txtCobradorC.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label19.Location = New System.Drawing.Point(518, 181)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 427
        Me.Label19.Text = "Cobrador"
        '
        'txtIDCobradorC
        '
        Me.txtIDCobradorC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIDCobradorC.BackColor = System.Drawing.SystemColors.Control
        Me.txtIDCobradorC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDCobradorC.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDCobradorC.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtIDCobradorC.Location = New System.Drawing.Point(731, 214)
        Me.txtIDCobradorC.Name = "txtIDCobradorC"
        Me.txtIDCobradorC.ReadOnly = True
        Me.txtIDCobradorC.Size = New System.Drawing.Size(49, 16)
        Me.txtIDCobradorC.TabIndex = 429
        Me.txtIDCobradorC.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label31.Location = New System.Drawing.Point(93, 104)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(86, 13)
        Me.Label31.TabIndex = 434
        Me.Label31.Text = "Datos del cliente"
        '
        'txtCalificacion
        '
        Me.txtCalificacion.BackColor = System.Drawing.SystemColors.Control
        Me.txtCalificacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(715, 147)
        Me.txtCalificacion.Multiline = True
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(71, 47)
        Me.txtCalificacion.TabIndex = 426
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label29.Location = New System.Drawing.Point(712, 129)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(63, 13)
        Me.Label29.TabIndex = 431
        Me.Label29.Text = "Calificación"
        '
        'txtBalanceGral
        '
        Me.txtBalanceGral.BackColor = System.Drawing.SystemColors.Control
        Me.txtBalanceGral.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBalanceGral.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.txtBalanceGral.ForeColor = System.Drawing.Color.Red
        Me.txtBalanceGral.Location = New System.Drawing.Point(331, 175)
        Me.txtBalanceGral.Name = "txtBalanceGral"
        Me.txtBalanceGral.ReadOnly = True
        Me.txtBalanceGral.Size = New System.Drawing.Size(173, 28)
        Me.txtBalanceGral.TabIndex = 435
        Me.txtBalanceGral.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Location = New System.Drawing.Point(19, 262)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(873, 1)
        Me.Label1.TabIndex = 436
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label2.Location = New System.Drawing.Point(-2, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(910, 1)
        Me.Label2.TabIndex = 437
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(22, 276)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 77)
        Me.Button1.TabIndex = 438
        Me.Button1.Text = "Intento de comunicación fallida"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(715, 359)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(166, 77)
        Me.Button2.TabIndex = 439
        Me.Button2.Text = "Visita de cobro"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(194, 276)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(166, 77)
        Me.Button3.TabIndex = 440
        Me.Button3.Text = "Acuerdo de pago físico"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(366, 276)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(166, 77)
        Me.Button4.TabIndex = 441
        Me.Button4.Text = "Emisión de notificación de deuda"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(366, 359)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(166, 77)
        Me.Button5.TabIndex = 442
        Me.Button5.Text = "Emisión de notificación de encauto"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(194, 359)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(166, 77)
        Me.Button6.TabIndex = 443
        Me.Button6.Text = "Notificación telefónica de cuenta atrasada"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(715, 276)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(166, 77)
        Me.Button7.TabIndex = 444
        Me.Button7.Text = "Pago a cuenta"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(22, 442)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(166, 77)
        Me.Button8.TabIndex = 445
        Me.Button8.Text = "Llamada del cliente para acuerdo"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(22, 359)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(166, 77)
        Me.Button9.TabIndex = 446
        Me.Button9.Text = "Acuerdo de pago teléfonico"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(366, 442)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(166, 77)
        Me.Button10.TabIndex = 447
        Me.Button10.Text = "Conflicto del cliente con familias"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(194, 442)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(166, 77)
        Me.Button11.TabIndex = 448
        Me.Button11.Text = "Irregularidad en contabilidad de pagos"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(-2, 532)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(910, 27)
        Me.Label3.TabIndex = 449
        Me.Label3.Text = "Intento de comunicación fallida"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 715)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(907, 25)
        Me.BarraEstado.TabIndex = 450
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
        'label42
        '
        Me.label42.AutoSize = True
        Me.label42.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label42.Location = New System.Drawing.Point(9, 571)
        Me.label42.Name = "label42"
        Me.label42.Size = New System.Drawing.Size(125, 15)
        Me.label42.TabIndex = 452
        Me.label42.Text = "Información Adicional"
        '
        'txtInfoAdicional
        '
        Me.txtInfoAdicional.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInfoAdicional.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtInfoAdicional.Location = New System.Drawing.Point(12, 589)
        Me.txtInfoAdicional.MaxLength = 255
        Me.txtInfoAdicional.Multiline = True
        Me.txtInfoAdicional.Name = "txtInfoAdicional"
        Me.txtInfoAdicional.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInfoAdicional.Size = New System.Drawing.Size(548, 112)
        Me.txtInfoAdicional.TabIndex = 451
        '
        'txtIDGestion
        '
        Me.txtIDGestion.Location = New System.Drawing.Point(829, 109)
        Me.txtIDGestion.Name = "txtIDGestion"
        Me.txtIDGestion.ReadOnly = True
        Me.txtIDGestion.Size = New System.Drawing.Size(66, 23)
        Me.txtIDGestion.TabIndex = 453
        Me.txtIDGestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(276, 12)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(52, 19)
        Me.chkNulo.TabIndex = 454
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'frm_gestiones_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 740)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.txtIDGestion)
        Me.Controls.Add(Me.label42)
        Me.Controls.Add(Me.txtInfoAdicional)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicCliente)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.nombre_label)
        Me.Controls.Add(Me.label20)
        Me.Controls.Add(Me.label21)
        Me.Controls.Add(Me.txtUltimoPago)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtCobradorC)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtIDCobradorC)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtCalificacion)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtBalanceGral)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_gestiones_clientes"
        Me.Tag = "263"
        Me.Text = "Gestiones sobre clientes"
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PicCliente.ResumeLayout(False)
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents PicBoxLogo As PictureBox
    Friend WithEvents PicCliente As Panel
    Friend WithEvents SimilarFindButton As Panel
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtIDCliente As TextBox
    Private WithEvents nombre_label As Label
    Private WithEvents label20 As Label
    Private WithEvents label21 As Label
    Friend WithEvents txtUltimoPago As TextBox
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents txtCobradorC As TextBox
    Private WithEvents Label19 As Label
    Friend WithEvents txtIDCobradorC As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtCalificacion As TextBox
    Private WithEvents Label29 As Label
    Friend WithEvents txtBalanceGral As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Private WithEvents label42 As Label
    Friend WithEvents txtInfoAdicional As TextBox
    Friend WithEvents txtIDGestion As TextBox
    Friend WithEvents chkNulo As CheckBox
End Class
