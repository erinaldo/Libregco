<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_recibo_pagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_recibo_pagos))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions3 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.txtBalanceGeneralCargos = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.txtBalanceGral = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtIDPago = New System.Windows.Forms.TextBox()
        Me.txtConceptoPago = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.VerPagarésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecibosEmitidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtHora = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDesactivar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.IDDetalleAbono = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDFacturaDatos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SecondID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.DiasVencidos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Fecha = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FechaVencimiento = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDTipoDocumento = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.EstadoFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Arts = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Monto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Balance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CargosFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Cargos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Aplicar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Descuento = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.IncluirX = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CargosExcento = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Final = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Info = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ColorColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DiasVencidosLargos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.NombreFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cbxMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GPCliente = New DevExpress.XtraEditors.GroupControl()
        Me.txtMontoUltimoPago = New System.Windows.Forms.TextBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCalificacion = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ILbcBalances = New DevExpress.XtraEditors.ImageListBoxControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.PicImagen = New System.Windows.Forms.PictureBox()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GPDocumento = New DevExpress.XtraEditors.GroupControl()
        Me.lblUsuario = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GbAplicado = New DevExpress.XtraEditors.PanelControl()
        Me.btnAplicarMonto = New DevExpress.XtraEditors.SimpleButton()
        Me.txtMontoAplicar = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.MenuBar.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPCliente.SuspendLayout()
        CType(Me.ILbcBalances, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPDocumento.SuspendLayout()
        CType(Me.GbAplicado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbAplicado.SuspendLayout()
        CType(Me.txtMontoAplicar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBalanceGeneralCargos
        '
        Me.txtBalanceGeneralCargos.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtBalanceGeneralCargos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBalanceGeneralCargos.Enabled = False
        Me.txtBalanceGeneralCargos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGeneralCargos.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGeneralCargos.Location = New System.Drawing.Point(299, 41)
        Me.txtBalanceGeneralCargos.Name = "txtBalanceGeneralCargos"
        Me.txtBalanceGeneralCargos.ReadOnly = True
        Me.txtBalanceGeneralCargos.Size = New System.Drawing.Size(116, 16)
        Me.txtBalanceGeneralCargos.TabIndex = 132
        Me.txtBalanceGeneralCargos.TabStop = False
        Me.txtBalanceGeneralCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBalanceGeneralCargos.Visible = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(38, 62)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(586, 23)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(60, 13)
        Me.label2.TabIndex = 129
        Me.label2.Text = "Calificación"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtUltimoPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtUltimoPago.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(589, 73)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(68, 13)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        '
        'txtBalanceGral
        '
        Me.txtBalanceGral.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtBalanceGral.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBalanceGral.Enabled = False
        Me.txtBalanceGral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGral.Location = New System.Drawing.Point(167, 41)
        Me.txtBalanceGral.Name = "txtBalanceGral"
        Me.txtBalanceGral.ReadOnly = True
        Me.txtBalanceGral.Size = New System.Drawing.Size(128, 16)
        Me.txtBalanceGral.TabIndex = 124
        Me.txtBalanceGral.TabStop = False
        Me.txtBalanceGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBalanceGral.Visible = False
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.txtIDCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(679, 3)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(60, 13)
        Me.txtIDCliente.TabIndex = 93
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIDCliente.Visible = False
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(729, 25)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(10, 23)
        Me.txtNombre.TabIndex = 94
        Me.txtNombre.TabStop = False
        Me.txtNombre.Visible = False
        '
        'txtIDPago
        '
        Me.txtIDPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.txtIDPago.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDPago.Enabled = False
        Me.txtIDPago.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtIDPago.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtIDPago.Location = New System.Drawing.Point(100, 4)
        Me.txtIDPago.Name = "txtIDPago"
        Me.txtIDPago.ReadOnly = True
        Me.txtIDPago.Size = New System.Drawing.Size(63, 14)
        Me.txtIDPago.TabIndex = 139
        Me.txtIDPago.TabStop = False
        Me.txtIDPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConceptoPago
        '
        Me.txtConceptoPago.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConceptoPago.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtConceptoPago.Location = New System.Drawing.Point(6, 24)
        Me.txtConceptoPago.MaxLength = 255
        Me.txtConceptoPago.Multiline = True
        Me.txtConceptoPago.Name = "txtConceptoPago"
        Me.txtConceptoPago.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConceptoPago.Size = New System.Drawing.Size(836, 37)
        Me.txtConceptoPago.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 159
        Me.Label6.Text = "APLICAR"
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "Ctrl-A"
        '
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkNulo.Location = New System.Drawing.Point(277, 28)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(52, 19)
        Me.ChkNulo.TabIndex = 173
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(1042, 24)
        Me.MenuBar.TabIndex = 178
        Me.MenuBar.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator2, Me.VerPagarésToolStripMenuItem, Me.EstadoDeCuentaToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(222, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(222, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(222, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(222, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(219, 6)
        '
        'VerPagarésToolStripMenuItem
        '
        Me.VerPagarésToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.VerPagarésToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.VerPagarésToolStripMenuItem.Name = "VerPagarésToolStripMenuItem"
        Me.VerPagarésToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.VerPagarésToolStripMenuItem.Size = New System.Drawing.Size(222, 38)
        Me.VerPagarésToolStripMenuItem.Text = "Pagarés"
        '
        'EstadoDeCuentaToolStripMenuItem
        '
        Me.EstadoDeCuentaToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.EstadoDeCuentaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EstadoDeCuentaToolStripMenuItem.Name = "EstadoDeCuentaToolStripMenuItem"
        Me.EstadoDeCuentaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.EstadoDeCuentaToolStripMenuItem.Size = New System.Drawing.Size(222, 38)
        Me.EstadoDeCuentaToolStripMenuItem.Text = "Estado de Cuenta"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(219, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(222, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularToolStripMenuItem, Me.RecibosEmitidoToolStripMenuItem})
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
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(210, 38)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'RecibosEmitidoToolStripMenuItem
        '
        Me.RecibosEmitidoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.RecibosEmitidoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RecibosEmitidoToolStripMenuItem.Name = "RecibosEmitidoToolStripMenuItem"
        Me.RecibosEmitidoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.RecibosEmitidoToolStripMenuItem.Size = New System.Drawing.Size(210, 38)
        Me.RecibosEmitidoToolStripMenuItem.Text = "Buscar Recibos"
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
        'txtHora
        '
        Me.txtHora.CustomFormat = "hh:mm:ss tt"
        Me.txtHora.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtHora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtHora.Location = New System.Drawing.Point(159, 28)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ShowUpDown = True
        Me.txtHora.Size = New System.Drawing.Size(119, 21)
        Me.txtHora.TabIndex = 415
        Me.txtHora.Value = New Date(2016, 10, 18, 12, 56, 0, 0)
        '
        'txtFechaPago
        '
        Me.txtFechaPago.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaPago.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaPago.Location = New System.Drawing.Point(55, 28)
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.Size = New System.Drawing.Size(98, 21)
        Me.txtFechaPago.TabIndex = 414
        '
        'txtSecondID
        '
        Me.txtSecondID.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.txtSecondID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtSecondID.Location = New System.Drawing.Point(164, 4)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(118, 14)
        Me.txtSecondID.TabIndex = 168
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label27.Location = New System.Drawing.Point(770, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 13)
        Me.Label27.TabIndex = 194
        Me.Label27.Text = "Cobrador"
        '
        'txtCobrador
        '
        Me.txtCobrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCobrador.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.txtCobrador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(828, 3)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(202, 13)
        Me.txtCobrador.TabIndex = 193
        Me.txtCobrador.TabStop = False
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(608, 23)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 327
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnDesactivar, Me.btnImprimir})
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
        'btnDesactivar
        '
        Me.btnDesactivar.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnDesactivar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDesactivar.Name = "btnDesactivar"
        Me.btnDesactivar.Size = New System.Drawing.Size(84, 95)
        Me.btnDesactivar.Text = "Anular"
        Me.btnDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 667)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1042, 25)
        Me.BarraEstado.TabIndex = 412
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(6, 28)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(201, 66)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 328
        Me.PicBoxLogo.TabStop = False
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(4, 215)
        Me.GridControl1.MainView = Me.AdvBandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1, Me.RepositoryItemCheckEdit1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemTextEdit3, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemButtonEdit1, Me.RepositoryItemButtonEdit2})
        Me.GridControl1.Size = New System.Drawing.Size(1035, 380)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView1})
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.IDDetalleAbono, Me.IDFacturaDatos, Me.SecondID, Me.IDTipoDocumento, Me.Fecha, Me.FechaVencimiento, Me.DiasVencidos, Me.Monto, Me.Balance, Me.Cargos, Me.Aplicar, Me.Descuento, Me.IncluirX, Me.Final, Me.CargosFactura, Me.CargosExcento, Me.EstadoFactura, Me.ColorColumn, Me.DiasVencidosLargos, Me.NombreFactura, Me.Info, Me.Arts})
        Me.AdvBandedGridView1.GridControl = Me.GridControl1
        Me.AdvBandedGridView1.IndicatorWidth = 6
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown
        Me.AdvBandedGridView1.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None
        Me.AdvBandedGridView1.OptionsPrint.AllowMultilineHeaders = True
        Me.AdvBandedGridView1.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView1.OptionsView.ShowGroupPanel = False
        Me.AdvBandedGridView1.RowSeparatorHeight = 2
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Options.UseImage = True
        Me.GridBand1.Caption = "Información de factura"
        Me.GridBand1.Columns.Add(Me.IDDetalleAbono)
        Me.GridBand1.Columns.Add(Me.IDFacturaDatos)
        Me.GridBand1.Columns.Add(Me.SecondID)
        Me.GridBand1.Columns.Add(Me.DiasVencidos)
        Me.GridBand1.Columns.Add(Me.Fecha)
        Me.GridBand1.Columns.Add(Me.FechaVencimiento)
        Me.GridBand1.Columns.Add(Me.IDTipoDocumento)
        Me.GridBand1.Columns.Add(Me.EstadoFactura)
        Me.GridBand1.Columns.Add(Me.Arts)
        Me.GridBand1.ImageOptions.Image = CType(resources.GetObject("GridBand1.ImageOptions.Image"), System.Drawing.Image)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 322
        '
        'IDDetalleAbono
        '
        Me.IDDetalleAbono.Caption = "IDDetalleAbono"
        Me.IDDetalleAbono.FieldName = "IDDetalleAbono"
        Me.IDDetalleAbono.Name = "IDDetalleAbono"
        Me.IDDetalleAbono.OptionsColumn.AllowEdit = False
        Me.IDDetalleAbono.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDDetalleAbono.OptionsColumn.AllowIncrementalSearch = False
        Me.IDDetalleAbono.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDDetalleAbono.OptionsColumn.AllowMove = False
        Me.IDDetalleAbono.OptionsColumn.AllowShowHide = False
        Me.IDDetalleAbono.OptionsColumn.ReadOnly = True
        Me.IDDetalleAbono.OptionsFilter.AllowFilter = False
        Me.IDDetalleAbono.Tag = ""
        Me.IDDetalleAbono.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'IDFacturaDatos
        '
        Me.IDFacturaDatos.Caption = "Factura"
        Me.IDFacturaDatos.FieldName = "IDFacturaDatos"
        Me.IDFacturaDatos.Name = "IDFacturaDatos"
        Me.IDFacturaDatos.OptionsColumn.AllowEdit = False
        Me.IDFacturaDatos.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDFacturaDatos.OptionsColumn.AllowIncrementalSearch = False
        Me.IDFacturaDatos.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDFacturaDatos.OptionsColumn.AllowMove = False
        Me.IDFacturaDatos.OptionsColumn.AllowShowHide = False
        Me.IDFacturaDatos.OptionsColumn.ReadOnly = True
        Me.IDFacturaDatos.OptionsFilter.AllowFilter = False
        Me.IDFacturaDatos.Tag = ""
        Me.IDFacturaDatos.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'SecondID
        '
        Me.SecondID.Caption = "Documento"
        Me.SecondID.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.SecondID.FieldName = "SecondID"
        Me.SecondID.Name = "SecondID"
        Me.SecondID.OptionsColumn.AllowEdit = False
        Me.SecondID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.SecondID.OptionsColumn.AllowIncrementalSearch = False
        Me.SecondID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.SecondID.OptionsColumn.AllowMove = False
        Me.SecondID.OptionsColumn.AllowShowHide = False
        Me.SecondID.OptionsColumn.ReadOnly = True
        Me.SecondID.OptionsFilter.AllowFilter = False
        Me.SecondID.Tag = ""
        Me.SecondID.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.SecondID.Visible = True
        Me.SecondID.Width = 95
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'DiasVencidos
        '
        Me.DiasVencidos.AppearanceCell.Options.UseTextOptions = True
        Me.DiasVencidos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DiasVencidos.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DiasVencidos.Caption = "Días"
        Me.DiasVencidos.DisplayFormat.FormatString = "n0"
        Me.DiasVencidos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.DiasVencidos.FieldName = "DiasVencidos"
        Me.DiasVencidos.Name = "DiasVencidos"
        Me.DiasVencidos.OptionsColumn.AllowEdit = False
        Me.DiasVencidos.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.DiasVencidos.OptionsColumn.AllowIncrementalSearch = False
        Me.DiasVencidos.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.DiasVencidos.OptionsColumn.AllowMove = False
        Me.DiasVencidos.OptionsColumn.AllowShowHide = False
        Me.DiasVencidos.OptionsColumn.ReadOnly = True
        Me.DiasVencidos.OptionsFilter.AllowFilter = False
        Me.DiasVencidos.Tag = ""
        Me.DiasVencidos.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.DiasVencidos.Visible = True
        Me.DiasVencidos.Width = 43
        '
        'Fecha
        '
        Me.Fecha.AppearanceCell.Options.UseTextOptions = True
        Me.Fecha.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Fecha.Caption = "Fecha"
        Me.Fecha.FieldName = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.OptionsColumn.AllowEdit = False
        Me.Fecha.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Fecha.OptionsColumn.AllowIncrementalSearch = False
        Me.Fecha.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Fecha.OptionsColumn.AllowMove = False
        Me.Fecha.OptionsColumn.AllowShowHide = False
        Me.Fecha.OptionsColumn.ReadOnly = True
        Me.Fecha.OptionsFilter.AllowFilter = False
        Me.Fecha.Tag = ""
        Me.Fecha.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Fecha.Visible = True
        Me.Fecha.Width = 85
        '
        'FechaVencimiento
        '
        Me.FechaVencimiento.AppearanceCell.Options.UseTextOptions = True
        Me.FechaVencimiento.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FechaVencimiento.Caption = "Vencimiento"
        Me.FechaVencimiento.FieldName = "FechaVencimiento"
        Me.FechaVencimiento.Name = "FechaVencimiento"
        Me.FechaVencimiento.OptionsColumn.AllowEdit = False
        Me.FechaVencimiento.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.FechaVencimiento.OptionsColumn.AllowIncrementalSearch = False
        Me.FechaVencimiento.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.FechaVencimiento.OptionsColumn.AllowMove = False
        Me.FechaVencimiento.OptionsColumn.AllowShowHide = False
        Me.FechaVencimiento.OptionsColumn.ReadOnly = True
        Me.FechaVencimiento.OptionsFilter.AllowFilter = False
        Me.FechaVencimiento.Tag = ""
        Me.FechaVencimiento.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.FechaVencimiento.Visible = True
        Me.FechaVencimiento.Width = 99
        '
        'IDTipoDocumento
        '
        Me.IDTipoDocumento.AppearanceCell.BackColor = System.Drawing.SystemColors.Info
        Me.IDTipoDocumento.AppearanceCell.ForeColor = System.Drawing.Color.Black
        Me.IDTipoDocumento.AppearanceCell.Options.UseBackColor = True
        Me.IDTipoDocumento.AppearanceCell.Options.UseForeColor = True
        Me.IDTipoDocumento.Caption = "T/Documento"
        Me.IDTipoDocumento.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.IDTipoDocumento.FieldName = "IDTipoDocumento"
        Me.IDTipoDocumento.Name = "IDTipoDocumento"
        Me.IDTipoDocumento.OptionsColumn.AllowEdit = False
        Me.IDTipoDocumento.OptionsColumn.AllowFocus = False
        Me.IDTipoDocumento.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDTipoDocumento.OptionsColumn.AllowIncrementalSearch = False
        Me.IDTipoDocumento.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDTipoDocumento.OptionsColumn.AllowMove = False
        Me.IDTipoDocumento.OptionsColumn.AllowShowHide = False
        Me.IDTipoDocumento.OptionsColumn.ReadOnly = True
        Me.IDTipoDocumento.OptionsFilter.AllowFilter = False
        Me.IDTipoDocumento.RowIndex = 1
        Me.IDTipoDocumento.Tag = ""
        Me.IDTipoDocumento.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDTipoDocumento.Visible = True
        Me.IDTipoDocumento.Width = 166
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.ReadOnly = True
        '
        'EstadoFactura
        '
        Me.EstadoFactura.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.EstadoFactura.AppearanceCell.Options.UseBackColor = True
        Me.EstadoFactura.Caption = "Status"
        Me.EstadoFactura.FieldName = "EstadoFactura"
        Me.EstadoFactura.Name = "EstadoFactura"
        Me.EstadoFactura.OptionsColumn.AllowEdit = False
        Me.EstadoFactura.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.EstadoFactura.OptionsColumn.AllowIncrementalSearch = False
        Me.EstadoFactura.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.EstadoFactura.OptionsColumn.AllowMove = False
        Me.EstadoFactura.OptionsColumn.AllowShowHide = False
        Me.EstadoFactura.OptionsColumn.ReadOnly = True
        Me.EstadoFactura.OptionsFilter.AllowFilter = False
        Me.EstadoFactura.RowIndex = 1
        Me.EstadoFactura.Tag = ""
        Me.EstadoFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.EstadoFactura.Visible = True
        Me.EstadoFactura.Width = 108
        '
        'Arts
        '
        Me.Arts.Caption = " "
        Me.Arts.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me.Arts.FieldName = "Arts"
        Me.Arts.Name = "Arts"
        Me.Arts.OptionsColumn.ReadOnly = True
        Me.Arts.OptionsFilter.AllowFilter = False
        Me.Arts.RowIndex = 1
        Me.Arts.Tag = ""
        Me.Arts.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Arts.Visible = True
        Me.Arts.Width = 48
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        EditorButtonImageOptions2.Image = CType(resources.GetObject("EditorButtonImageOptions2.Image"), System.Drawing.Image)
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Articulos", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default]), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Conduces", -1, True, False, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        Me.RepositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.RepositoryItemButtonEdit2.UseReadOnlyAppearance = False
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Balance"
        Me.gridBand2.Columns.Add(Me.Monto)
        Me.gridBand2.Columns.Add(Me.Balance)
        Me.gridBand2.Columns.Add(Me.CargosFactura)
        Me.gridBand2.ImageOptions.Image = CType(resources.GetObject("gridBand2.ImageOptions.Image"), System.Drawing.Image)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 267
        '
        'Monto
        '
        Me.Monto.AppearanceCell.Options.UseTextOptions = True
        Me.Monto.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Monto.AutoFillDown = True
        Me.Monto.Caption = "Total Neto"
        Me.Monto.DisplayFormat.FormatString = "c"
        Me.Monto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Monto.FieldName = "TotalNeto"
        Me.Monto.Name = "Monto"
        Me.Monto.OptionsColumn.AllowEdit = False
        Me.Monto.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Monto.OptionsColumn.AllowIncrementalSearch = False
        Me.Monto.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Monto.OptionsColumn.AllowMove = False
        Me.Monto.OptionsColumn.AllowShowHide = False
        Me.Monto.OptionsColumn.ReadOnly = True
        Me.Monto.OptionsFilter.AllowFilter = False
        Me.Monto.Tag = ""
        Me.Monto.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Monto.Visible = True
        Me.Monto.Width = 82
        '
        'Balance
        '
        Me.Balance.AppearanceCell.BackColor = System.Drawing.SystemColors.Info
        Me.Balance.AppearanceCell.Options.UseBackColor = True
        Me.Balance.AppearanceCell.Options.UseTextOptions = True
        Me.Balance.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Balance.AutoFillDown = True
        Me.Balance.Caption = "Balance"
        Me.Balance.DisplayFormat.FormatString = "c"
        Me.Balance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Balance.FieldName = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.OptionsColumn.AllowEdit = False
        Me.Balance.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Balance.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Balance.OptionsColumn.AllowMove = False
        Me.Balance.OptionsColumn.AllowShowHide = False
        Me.Balance.OptionsColumn.ReadOnly = True
        Me.Balance.OptionsFilter.AllowFilter = False
        Me.Balance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0:c}")})
        Me.Balance.Tag = ""
        Me.Balance.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Balance.Visible = True
        Me.Balance.Width = 89
        '
        'CargosFactura
        '
        Me.CargosFactura.AppearanceCell.BackColor = System.Drawing.SystemColors.Info
        Me.CargosFactura.AppearanceCell.Options.UseBackColor = True
        Me.CargosFactura.AutoFillDown = True
        Me.CargosFactura.Caption = "Cargos Acum."
        Me.CargosFactura.DisplayFormat.FormatString = "c"
        Me.CargosFactura.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CargosFactura.FieldName = "CargosFactura"
        Me.CargosFactura.Name = "CargosFactura"
        Me.CargosFactura.OptionsColumn.AllowEdit = False
        Me.CargosFactura.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.CargosFactura.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.CargosFactura.OptionsColumn.AllowMove = False
        Me.CargosFactura.OptionsColumn.AllowShowHide = False
        Me.CargosFactura.OptionsColumn.ReadOnly = True
        Me.CargosFactura.OptionsFilter.AllowFilter = False
        Me.CargosFactura.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CargosFactura", "{0:c}")})
        Me.CargosFactura.Tag = ""
        Me.CargosFactura.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.CargosFactura.Visible = True
        Me.CargosFactura.Width = 96
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Aplicación"
        Me.gridBand3.Columns.Add(Me.Cargos)
        Me.gridBand3.Columns.Add(Me.Aplicar)
        Me.gridBand3.Columns.Add(Me.Descuento)
        Me.gridBand3.Columns.Add(Me.IncluirX)
        Me.gridBand3.Columns.Add(Me.CargosExcento)
        Me.gridBand3.Columns.Add(Me.Final)
        Me.gridBand3.ImageOptions.Image = CType(resources.GetObject("gridBand3.ImageOptions.Image"), System.Drawing.Image)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 386
        '
        'Cargos
        '
        Me.Cargos.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cargos.AppearanceCell.Options.UseBackColor = True
        Me.Cargos.AppearanceCell.Options.UseTextOptions = True
        Me.Cargos.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Cargos.AutoFillDown = True
        Me.Cargos.Caption = "Cargos"
        Me.Cargos.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.Cargos.DisplayFormat.FormatString = "c"
        Me.Cargos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Cargos.FieldName = "Cargos"
        Me.Cargos.Name = "Cargos"
        Me.Cargos.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cargos", "{0:c}")})
        Me.Cargos.Tag = ""
        Me.Cargos.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Cargos.Visible = True
        Me.Cargos.Width = 91
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Mask.EditMask = "c2"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "0"
        Me.RepositoryItemTextEdit1.ValidateOnEnterKey = True
        '
        'Aplicar
        '
        Me.Aplicar.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Aplicar.AppearanceCell.Options.UseBackColor = True
        Me.Aplicar.AutoFillDown = True
        Me.Aplicar.Caption = "Aplicar"
        Me.Aplicar.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.Aplicar.FieldName = "Aplicar"
        Me.Aplicar.Name = "Aplicar"
        Me.Aplicar.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Aplicar", "{0:c}")})
        Me.Aplicar.Tag = ""
        Me.Aplicar.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Aplicar.Visible = True
        Me.Aplicar.Width = 96
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Mask.EditMask = "c2"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.NullText = "0"
        '
        'Descuento
        '
        Me.Descuento.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Descuento.AppearanceCell.Options.UseBackColor = True
        Me.Descuento.AutoFillDown = True
        Me.Descuento.Caption = "Descuento"
        Me.Descuento.ColumnEdit = Me.RepositoryItemTextEdit3
        Me.Descuento.DisplayFormat.FormatString = "c"
        Me.Descuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Descuento.FieldName = "Descuento"
        Me.Descuento.Name = "Descuento"
        Me.Descuento.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Descuento", "{0:c}")})
        Me.Descuento.Tag = ""
        Me.Descuento.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Descuento.Visible = True
        Me.Descuento.Width = 80
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.Mask.EditMask = "c2"
        Me.RepositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit3.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.NullText = "0"
        '
        'IncluirX
        '
        Me.IncluirX.AutoFillDown = True
        Me.IncluirX.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.IncluirX.FieldName = "Incluir"
        Me.IncluirX.Name = "IncluirX"
        Me.IncluirX.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.IncluirX.OptionsColumn.AllowIncrementalSearch = False
        Me.IncluirX.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.IncluirX.OptionsColumn.FixedWidth = True
        Me.IncluirX.OptionsColumn.ShowCaption = False
        Me.IncluirX.OptionsFilter.AllowFilter = False
        Me.IncluirX.Tag = ""
        Me.IncluirX.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IncluirX.Visible = True
        Me.IncluirX.Width = 23
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoWidth = True
        Me.RepositoryItemCheckEdit1.Caption = ""
        Me.RepositoryItemCheckEdit1.DisplayValueChecked = "True"
        Me.RepositoryItemCheckEdit1.DisplayValueGrayed = "-1"
        Me.RepositoryItemCheckEdit1.DisplayValueUnchecked = "False"
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.RepositoryItemCheckEdit1.NullText = "0"
        Me.RepositoryItemCheckEdit1.ValueChecked = "1"
        Me.RepositoryItemCheckEdit1.ValueGrayed = "0"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "0"
        '
        'CargosExcento
        '
        Me.CargosExcento.AutoFillDown = True
        Me.CargosExcento.Caption = "Cargos excentos"
        Me.CargosExcento.DisplayFormat.FormatString = "c"
        Me.CargosExcento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CargosExcento.FieldName = "CargosExcento"
        Me.CargosExcento.Name = "CargosExcento"
        Me.CargosExcento.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.CargosExcento.OptionsColumn.AllowIncrementalSearch = False
        Me.CargosExcento.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.CargosExcento.OptionsColumn.AllowMove = False
        Me.CargosExcento.OptionsFilter.AllowFilter = False
        Me.CargosExcento.Tag = ""
        Me.CargosExcento.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        '
        'Final
        '
        Me.Final.AppearanceCell.BackColor = System.Drawing.Color.Silver
        Me.Final.AppearanceCell.BackColor2 = System.Drawing.Color.Silver
        Me.Final.AppearanceCell.ForeColor = System.Drawing.Color.White
        Me.Final.AppearanceCell.Options.UseBackColor = True
        Me.Final.AppearanceCell.Options.UseForeColor = True
        Me.Final.AutoFillDown = True
        Me.Final.Caption = "Bal. Final"
        Me.Final.DisplayFormat.FormatString = "c"
        Me.Final.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Final.FieldName = "Final"
        Me.Final.Name = "Final"
        Me.Final.OptionsColumn.AllowEdit = False
        Me.Final.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Final.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Final.OptionsColumn.AllowMove = False
        Me.Final.OptionsColumn.AllowShowHide = False
        Me.Final.OptionsColumn.ReadOnly = True
        Me.Final.OptionsFilter.AllowFilter = False
        Me.Final.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Final", "{0:c}")})
        Me.Final.Tag = ""
        Me.Final.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Final.Visible = True
        Me.Final.Width = 96
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "Acciones"
        Me.gridBand4.Columns.Add(Me.Info)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 42
        '
        'Info
        '
        Me.Info.AutoFillDown = True
        Me.Info.Caption = "Info"
        Me.Info.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.Info.FieldName = "Info"
        Me.Info.Name = "Info"
        Me.Info.OptionsColumn.AllowEdit = False
        Me.Info.OptionsColumn.ReadOnly = True
        Me.Info.OptionsFilter.AllowFilter = False
        Me.Info.Tag = ""
        Me.Info.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Info.Visible = True
        Me.Info.Width = 42
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        EditorButtonImageOptions3.Image = CType(resources.GetObject("EditorButtonImageOptions3.Image"), System.Drawing.Image)
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions3, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, SerializableAppearanceObject10, SerializableAppearanceObject11, SerializableAppearanceObject12, "", "Info", Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.RepositoryItemButtonEdit1.UseReadOnlyAppearance = False
        '
        'ColorColumn
        '
        Me.ColorColumn.Caption = "Color"
        Me.ColorColumn.FieldName = "ColorColumn"
        Me.ColorColumn.Name = "ColorColumn"
        Me.ColorColumn.OptionsColumn.AllowEdit = False
        Me.ColorColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColorColumn.OptionsColumn.AllowIncrementalSearch = False
        Me.ColorColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColorColumn.OptionsColumn.AllowMove = False
        Me.ColorColumn.OptionsColumn.AllowShowHide = False
        Me.ColorColumn.OptionsColumn.ReadOnly = True
        Me.ColorColumn.OptionsFilter.AllowFilter = False
        Me.ColorColumn.Tag = ""
        Me.ColorColumn.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'DiasVencidosLargos
        '
        Me.DiasVencidosLargos.AppearanceCell.Options.UseTextOptions = True
        Me.DiasVencidosLargos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DiasVencidosLargos.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DiasVencidosLargos.Caption = "Días"
        Me.DiasVencidosLargos.FieldName = "DiasVencidosLargos"
        Me.DiasVencidosLargos.Name = "DiasVencidosLargos"
        Me.DiasVencidosLargos.OptionsColumn.AllowEdit = False
        Me.DiasVencidosLargos.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.DiasVencidosLargos.OptionsColumn.AllowIncrementalSearch = False
        Me.DiasVencidosLargos.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.DiasVencidosLargos.OptionsColumn.AllowMove = False
        Me.DiasVencidosLargos.OptionsColumn.AllowShowHide = False
        Me.DiasVencidosLargos.OptionsColumn.ReadOnly = True
        Me.DiasVencidosLargos.OptionsFilter.AllowFilter = False
        Me.DiasVencidosLargos.Tag = ""
        Me.DiasVencidosLargos.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.DiasVencidosLargos.Visible = True
        '
        'NombreFactura
        '
        Me.NombreFactura.Caption = "Nombre"
        Me.NombreFactura.FieldName = "NombreFactura"
        Me.NombreFactura.Name = "NombreFactura"
        Me.NombreFactura.OptionsColumn.AllowEdit = False
        Me.NombreFactura.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.NombreFactura.OptionsColumn.AllowIncrementalSearch = False
        Me.NombreFactura.OptionsColumn.AllowMove = False
        Me.NombreFactura.OptionsColumn.ReadOnly = True
        Me.NombreFactura.OptionsFilter.AllowFilter = False
        Me.NombreFactura.Tag = ""
        Me.NombreFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.NombreFactura.Visible = True
        Me.NombreFactura.Width = 200
        '
        'cbxMoneda
        '
        Me.cbxMoneda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxMoneda.Location = New System.Drawing.Point(71, 39)
        Me.cbxMoneda.Name = "cbxMoneda"
        Me.cbxMoneda.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.cbxMoneda.Properties.Appearance.Options.UseBackColor = True
        Me.cbxMoneda.Properties.Appearance.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbxMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxMoneda.Properties.DropDownRows = 6
        Me.cbxMoneda.Properties.SmallImages = Me.imgFlags
        Me.cbxMoneda.Size = New System.Drawing.Size(502, 18)
        Me.cbxMoneda.TabIndex = 414
        Me.cbxMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'GPCliente
        '
        Me.GPCliente.AllowHtmlText = True
        Me.GPCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GPCliente.CaptionImageOptions.Image = CType(resources.GetObject("GPCliente.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GPCliente.Controls.Add(Me.txtBalanceGeneralCargos)
        Me.GPCliente.Controls.Add(Me.btnBuscarCliente)
        Me.GPCliente.Controls.Add(Me.txtMontoUltimoPago)
        Me.GPCliente.Controls.Add(Me.LabelControl7)
        Me.GPCliente.Controls.Add(Me.LabelControl6)
        Me.GPCliente.Controls.Add(Me.txtNombre)
        Me.GPCliente.Controls.Add(Me.txtIDCliente)
        Me.GPCliente.Controls.Add(Me.LabelControl5)
        Me.GPCliente.Controls.Add(Me.txtBalanceGral)
        Me.GPCliente.Controls.Add(Me.lblCalificacion)
        Me.GPCliente.Controls.Add(Me.txtUltimoPago)
        Me.GPCliente.Controls.Add(Me.LabelControl3)
        Me.GPCliente.Controls.Add(Me.ILbcBalances)
        Me.GPCliente.Controls.Add(Me.LabelControl11)
        Me.GPCliente.Controls.Add(Me.PicImagen)
        Me.GPCliente.Controls.Add(Me.cbxMoneda)
        Me.GPCliente.Controls.Add(Me.label2)
        Me.GPCliente.Controls.Add(Me.SeparatorControl1)
        Me.GPCliente.Location = New System.Drawing.Point(4, 122)
        Me.GPCliente.Name = "GPCliente"
        Me.GPCliente.Size = New System.Drawing.Size(744, 89)
        Me.GPCliente.TabIndex = 0
        Me.GPCliente.Text = " Información general  "
        '
        'txtMontoUltimoPago
        '
        Me.txtMontoUltimoPago.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtMontoUltimoPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtMontoUltimoPago.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMontoUltimoPago.Enabled = False
        Me.txtMontoUltimoPago.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtMontoUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtMontoUltimoPago.Location = New System.Drawing.Point(656, 73)
        Me.txtMontoUltimoPago.Name = "txtMontoUltimoPago"
        Me.txtMontoUltimoPago.ReadOnly = True
        Me.txtMontoUltimoPago.Size = New System.Drawing.Size(83, 13)
        Me.txtMontoUltimoPago.TabIndex = 423
        Me.txtMontoUltimoPago.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Location = New System.Drawing.Point(589, 44)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl7.TabIndex = 422
        Me.LabelControl7.Text = "Último pago"
        '
        'LabelControl6
        '
        Me.LabelControl6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LabelControl6.Location = New System.Drawing.Point(589, 58)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl6.TabIndex = 421
        Me.LabelControl6.Text = "Fecha"
        '
        'LabelControl5
        '
        Me.LabelControl5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LabelControl5.Location = New System.Drawing.Point(656, 58)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl5.TabIndex = 420
        Me.LabelControl5.Text = "Monto"
        '
        'lblCalificacion
        '
        Me.lblCalificacion.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCalificacion.Location = New System.Drawing.Point(652, 22)
        Me.lblCalificacion.Name = "lblCalificacion"
        Me.lblCalificacion.Size = New System.Drawing.Size(0, 13)
        Me.lblCalificacion.TabIndex = 418
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(589, 5)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl3.TabIndex = 417
        Me.LabelControl3.Text = "Resumen"
        '
        'ILbcBalances
        '
        Me.ILbcBalances.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ILbcBalances.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ILbcBalances.Appearance.Options.UseBackColor = True
        Me.ILbcBalances.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ILbcBalances.ColumnWidth = 130
        Me.ILbcBalances.Cursor = System.Windows.Forms.Cursors.Default
        Me.ILbcBalances.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned
        Me.ILbcBalances.HorzScrollStep = 8
        Me.ILbcBalances.Location = New System.Drawing.Point(71, 60)
        Me.ILbcBalances.Margin = New System.Windows.Forms.Padding(0)
        Me.ILbcBalances.MultiColumn = True
        Me.ILbcBalances.Name = "ILbcBalances"
        Me.ILbcBalances.Size = New System.Drawing.Size(512, 24)
        Me.ILbcBalances.TabIndex = 416
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Appearance.Options.UseFont = True
        Me.LabelControl11.Location = New System.Drawing.Point(69, 25)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl11.TabIndex = 415
        Me.LabelControl11.Text = "Balance General"
        '
        'PicImagen
        '
        Me.PicImagen.BackColor = System.Drawing.Color.White
        Me.PicImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicImagen.Image = Global.Libregco.My.Resources.Resources.no_photo
        Me.PicImagen.Location = New System.Drawing.Point(5, 26)
        Me.PicImagen.Name = "PicImagen"
        Me.PicImagen.Size = New System.Drawing.Size(56, 59)
        Me.PicImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicImagen.TabIndex = 1
        Me.PicImagen.TabStop = False
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.SeparatorControl1.Location = New System.Drawing.Point(579, 29)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(162, 23)
        Me.SeparatorControl1.TabIndex = 419
        '
        'GPDocumento
        '
        Me.GPDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GPDocumento.CaptionImageOptions.Image = CType(resources.GetObject("GPDocumento.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GPDocumento.Controls.Add(Me.lblUsuario)
        Me.GPDocumento.Controls.Add(Me.LabelControl12)
        Me.GPDocumento.Controls.Add(Me.txtHora)
        Me.GPDocumento.Controls.Add(Me.LabelControl2)
        Me.GPDocumento.Controls.Add(Me.txtFechaPago)
        Me.GPDocumento.Controls.Add(Me.txtIDPago)
        Me.GPDocumento.Controls.Add(Me.txtSecondID)
        Me.GPDocumento.Location = New System.Drawing.Point(754, 122)
        Me.GPDocumento.Name = "GPDocumento"
        Me.GPDocumento.Size = New System.Drawing.Size(285, 89)
        Me.GPDocumento.TabIndex = 416
        Me.GPDocumento.Text = "# Documento"
        '
        'lblUsuario
        '
        Me.lblUsuario.Location = New System.Drawing.Point(55, 64)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(0, 13)
        Me.lblUsuario.TabIndex = 421
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(9, 63)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl12.TabIndex = 420
        Me.LabelControl12.Text = "Usuario"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(9, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl2.TabIndex = 169
        Me.LabelControl2.Text = "Fecha"
        '
        'GbAplicado
        '
        Me.GbAplicado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbAplicado.Controls.Add(Me.btnAplicarMonto)
        Me.GbAplicado.Controls.Add(Me.txtMontoAplicar)
        Me.GbAplicado.Controls.Add(Me.Label5)
        Me.GbAplicado.Controls.Add(Me.Label6)
        Me.GbAplicado.Location = New System.Drawing.Point(745, 215)
        Me.GbAplicado.LookAndFeel.SkinName = "Seven Classic"
        Me.GbAplicado.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GbAplicado.Name = "GbAplicado"
        Me.GbAplicado.Size = New System.Drawing.Size(293, 27)
        Me.GbAplicado.TabIndex = 417
        '
        'btnAplicarMonto
        '
        Me.btnAplicarMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicarMonto.ImageOptions.Image = CType(resources.GetObject("btnAplicarMonto.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAplicarMonto.Location = New System.Drawing.Point(203, 2)
        Me.btnAplicarMonto.Name = "btnAplicarMonto"
        Me.btnAplicarMonto.Size = New System.Drawing.Size(83, 21)
        Me.btnAplicarMonto.TabIndex = 2
        Me.btnAplicarMonto.Text = "Aplicar"
        '
        'txtMontoAplicar
        '
        Me.txtMontoAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoAplicar.Location = New System.Drawing.Point(96, 3)
        Me.txtMontoAplicar.Name = "txtMontoAplicar"
        Me.txtMontoAplicar.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtMontoAplicar.Properties.Appearance.Options.UseFont = True
        Me.txtMontoAplicar.Properties.Mask.EditMask = "c"
        Me.txtMontoAplicar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMontoAplicar.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtMontoAplicar.Properties.NullText = "0"
        Me.txtMontoAplicar.Size = New System.Drawing.Size(104, 20)
        Me.txtMontoAplicar.TabIndex = 1
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.txtCobrador)
        Me.GroupControl1.Controls.Add(Me.txtConceptoPago)
        Me.GroupControl1.Controls.Add(Me.Label27)
        Me.GroupControl1.Location = New System.Drawing.Point(4, 599)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1035, 66)
        Me.GroupControl1.TabIndex = 418
        Me.GroupControl1.Text = "Concepto"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.SimpleButton1.Location = New System.Drawing.Point(892, 38)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(138, 23)
        Me.SimpleButton1.TabIndex = 196
        Me.SimpleButton1.Text = "Estado de cuenta"
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.creditcard_flatx48, "Recibo de Ingreso guardado", "El recibo de ingreso ha sido guardado satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("33dfd5d7-dece-4a75-8aac-7f9c16ba326c", Global.Libregco.My.Resources.Resources.creditcard_flatx48, "Recibo de Ingreso modificado", "La recibo de ingreso ha sido modificado satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'frm_recibo_pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 692)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GbAplicado)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GPDocumento)
        Me.Controls.Add(Me.GPCliente)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.MenuBar)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frm_recibo_pagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "94"
        Me.Text = "Recibos de Ingreso"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPCliente.ResumeLayout(False)
        Me.GPCliente.PerformLayout()
        CType(Me.ILbcBalances, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPDocumento.ResumeLayout(False)
        Me.GPDocumento.PerformLayout()
        CType(Me.GbAplicado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbAplicado.ResumeLayout(False)
        Me.GbAplicado.PerformLayout()
        CType(Me.txtMontoAplicar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Friend WithEvents txtBalanceGral As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtIDPago As System.Windows.Forms.TextBox
    Friend WithEvents txtConceptoPago As System.Windows.Forms.TextBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
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
    Friend WithEvents RecibosEmitidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadoDeCuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnDesactivar As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents VerPagarésToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBalanceGeneralCargos As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents cbxMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents GPCliente As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PicImagen As PictureBox
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ILbcBalances As DevExpress.XtraEditors.ImageListBoxControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCalificacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents txtMontoUltimoPago As TextBox
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GPDocumento As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUsuario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView1 As XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents IDDetalleAbono As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents EstadoFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDFacturaDatos As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SecondID As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDTipoDocumento As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Fecha As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FechaVencimiento As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DiasVencidos As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Monto As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Balance As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CargosFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IncluirX As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Aplicar As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Descuento As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Cargos As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CargosExcento As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Final As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColorColumn As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DiasVencidosLargos As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepositoryItemTextEdit1 As XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit3 As XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCheckEdit1 As XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemLookUpEdit1 As XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents NombreFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GbAplicado As XtraEditors.PanelControl
    Friend WithEvents txtMontoAplicar As XtraEditors.TextEdit
    Friend WithEvents btnAplicarMonto As XtraEditors.SimpleButton
    Friend WithEvents GridBand1 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Info As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GroupControl1 As XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As XtraEditors.SimpleButton
    Friend WithEvents Arts As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ToastNotificationsManager1 As XtraBars.ToastNotifications.ToastNotificationsManager
End Class
