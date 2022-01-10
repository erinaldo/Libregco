<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_formadepago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_formadepago))
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.txtMontoCobrar = New DevExpress.XtraEditors.TextEdit()
        Me.cbxMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.IDTransaccion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipoDocumento = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarEfectivo = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroupControlContainer1 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.ListadeDevolucion = New DevExpress.XtraEditors.ImageListBoxControl()
        Me.FlowBotones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDevolucionEfectivo = New DevExpress.XtraEditors.TextEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEfectivo = New DevExpress.XtraEditors.TextEdit()
        Me.SeparatorControl3 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl4 = New DevExpress.XtraEditors.SeparatorControl()
        Me.NavBarGroupControlContainer2 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.txtCheque = New DevExpress.XtraEditors.TextEdit()
        Me.cbxBancoCheque = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgBancos = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNoCheque = New DevExpress.XtraEditors.TextEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.NavBarGroupControlContainer3 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.Panel1 = New DevExpress.XtraEditors.GroupControl()
        Me.SeparatorControl5 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtBalanceCredito = New System.Windows.Forms.Label()
        Me.txtBalanceUtilizado = New System.Windows.Forms.Label()
        Me.txtBalanceGenerado = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtMontoCredito = New DevExpress.XtraEditors.TextEdit()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.SeparatorControl6 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtIDCredito = New DevExpress.XtraEditors.TextEdit()
        Me.btnBuscarCreditos = New DevExpress.XtraEditors.SimpleButton()
        Me.NavBarGroupControlContainer4 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.lblClaseTarjeta = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.gcAprobacion = New DevExpress.XtraEditors.GroupControl()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ImageEdit1 = New DevExpress.XtraEditors.ImageEdit()
        Me.txtNoAprobacion = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtTarjeta = New DevExpress.XtraEditors.TextEdit()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtNoTarjeta = New DevExpress.XtraEditors.TextEdit()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbxAño = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbxMes = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbxBancoTarjeta = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.rdbTipoTarjeta = New System.Windows.Forms.Panel()
        Me.rdbMasterCard = New System.Windows.Forms.RadioButton()
        Me.rdbOtra = New System.Windows.Forms.RadioButton()
        Me.rdbAmericanExpress = New System.Windows.Forms.RadioButton()
        Me.rdbVisa = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NavBarGroupControlContainer5 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.IDCobrosAdelantados_hijo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDCobrosAdelantados = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SecondID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TransaccionChild = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TransaccionID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Transaccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Fecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Disponible = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Utilizar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Eliminar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtCobrosAdelantados = New DevExpress.XtraEditors.TextEdit()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtPermuta = New DevExpress.XtraEditors.TextEdit()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtBonos = New DevExpress.XtraEditors.TextEdit()
        Me.NavBarGroupControlContainer6 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbxBancoDeposito = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDeposito = New DevExpress.XtraEditors.TextEdit()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtInformacionDeposito = New DevExpress.XtraEditors.TextEdit()
        Me.NavBarTarjeta = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarCheque = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarDeposito = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarBonos = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarCreditos = New DevExpress.XtraNavBar.NavBarGroup()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnContinuar = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtDevuelta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEfectivoCobrar = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BarraEstado.SuspendLayout()
        CType(Me.txtMontoCobrar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarControl1.SuspendLayout()
        Me.NavBarGroupControlContainer1.SuspendLayout()
        CType(Me.ListadeDevolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDevolucionEfectivo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEfectivo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarGroupControlContainer2.SuspendLayout()
        CType(Me.txtCheque.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxBancoCheque.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoCheque.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarGroupControlContainer3.SuspendLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoCredito.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.txtIDCredito.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarGroupControlContainer4.SuspendLayout()
        CType(Me.lblClaseTarjeta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcAprobacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcAprobacion.SuspendLayout()
        CType(Me.ImageEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarjeta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoTarjeta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxAño.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxMes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxBancoTarjeta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdbTipoTarjeta.SuspendLayout()
        Me.NavBarGroupControlContainer5.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCobrosAdelantados.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPermuta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBonos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarGroupControlContainer6.SuspendLayout()
        CType(Me.cbxBancoDeposito.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeposito.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInformacionDeposito.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 689)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(654, 25)
        Me.BarraEstado.TabIndex = 270
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
        Me.lblStatusBar.Size = New System.Drawing.Size(29, 22)
        Me.lblStatusBar.Text = "Listo"
        '
        'txtMontoCobrar
        '
        Me.txtMontoCobrar.EditValue = "0"
        Me.txtMontoCobrar.Enabled = False
        Me.txtMontoCobrar.Location = New System.Drawing.Point(111, 27)
        Me.txtMontoCobrar.Name = "txtMontoCobrar"
        Me.txtMontoCobrar.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtMontoCobrar.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoCobrar.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.txtMontoCobrar.Properties.Appearance.Options.UseBackColor = True
        Me.txtMontoCobrar.Properties.Appearance.Options.UseFont = True
        Me.txtMontoCobrar.Properties.Appearance.Options.UseForeColor = True
        Me.txtMontoCobrar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtMontoCobrar.Properties.Mask.EditMask = "c"
        Me.txtMontoCobrar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMontoCobrar.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtMontoCobrar.Properties.NullText = "0"
        Me.txtMontoCobrar.Properties.NullValuePrompt = "0"
        Me.txtMontoCobrar.Properties.ReadOnly = True
        Me.txtMontoCobrar.Size = New System.Drawing.Size(169, 34)
        Me.txtMontoCobrar.TabIndex = 295
        Me.txtMontoCobrar.TabStop = False
        '
        'cbxMoneda
        '
        Me.cbxMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxMoneda.Location = New System.Drawing.Point(420, 34)
        Me.cbxMoneda.Name = "cbxMoneda"
        Me.cbxMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxMoneda.Properties.DropDownRows = 6
        Me.cbxMoneda.Properties.ReadOnly = True
        Me.cbxMoneda.Properties.SmallImages = Me.imgFlags
        Me.cbxMoneda.Size = New System.Drawing.Size(227, 20)
        Me.cbxMoneda.TabIndex = 294
        Me.cbxMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(369, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 293
        Me.Label8.Text = "Moneda"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(46, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 292
        Me.Label7.Text = "IMPORTE >"
        '
        'IDTransaccion
        '
        Me.IDTransaccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IDTransaccion.ForeColor = System.Drawing.Color.Red
        Me.IDTransaccion.Location = New System.Drawing.Point(553, 6)
        Me.IDTransaccion.Name = "IDTransaccion"
        Me.IDTransaccion.Size = New System.Drawing.Size(83, 13)
        Me.IDTransaccion.TabIndex = 291
        Me.IDTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(462, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 290
        Me.Label3.Text = "Transacción No.:"
        '
        'txtTipoDocumento
        '
        Me.txtTipoDocumento.AutoSize = True
        Me.txtTipoDocumento.ForeColor = System.Drawing.Color.DodgerBlue
        Me.txtTipoDocumento.Location = New System.Drawing.Point(116, 6)
        Me.txtTipoDocumento.Name = "txtTipoDocumento"
        Me.txtTipoDocumento.Size = New System.Drawing.Size(0, 13)
        Me.txtTipoDocumento.TabIndex = 289
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Tipo de documento"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.SeparatorControl1.Enabled = False
        Me.SeparatorControl1.Location = New System.Drawing.Point(2, 12)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(652, 27)
        Me.SeparatorControl1.TabIndex = 287
        Me.SeparatorControl1.TabStop = False
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.NavBarEfectivo
        Me.NavBarControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer1)
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer2)
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer3)
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer4)
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer5)
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer6)
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarEfectivo, Me.NavBarTarjeta, Me.NavBarCheque, Me.NavBarDeposito, Me.NavBarBonos, Me.NavBarCreditos})
        Me.NavBarControl1.Location = New System.Drawing.Point(1, 65)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = 652
        Me.NavBarControl1.Size = New System.Drawing.Size(652, 502)
        Me.NavBarControl1.TabIndex = 0
        Me.NavBarControl1.Text = "NavBarControl1"
        '
        'NavBarEfectivo
        '
        Me.NavBarEfectivo.AllowHtmlString = DevExpress.Utils.DefaultBoolean.[True]
        Me.NavBarEfectivo.Caption = "<u><color=30,144,255><B>[F1]</B></color></u>  Efectivo"
        Me.NavBarEfectivo.ControlContainer = Me.NavBarGroupControlContainer1
        Me.NavBarEfectivo.Expanded = True
        Me.NavBarEfectivo.GroupClientHeight = 122
        Me.NavBarEfectivo.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarEfectivo.ImageOptions.LargeImage = CType(resources.GetObject("NavBarEfectivo.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarEfectivo.ImageOptions.SmallImage = CType(resources.GetObject("NavBarEfectivo.ImageOptions.SmallImage"), System.Drawing.Image)
        Me.NavBarEfectivo.Name = "NavBarEfectivo"
        Me.NavBarEfectivo.Tag = "0"
        '
        'NavBarGroupControlContainer1
        '
        Me.NavBarGroupControlContainer1.Controls.Add(Me.ListadeDevolucion)
        Me.NavBarGroupControlContainer1.Controls.Add(Me.FlowBotones)
        Me.NavBarGroupControlContainer1.Controls.Add(Me.Label11)
        Me.NavBarGroupControlContainer1.Controls.Add(Me.txtDevolucionEfectivo)
        Me.NavBarGroupControlContainer1.Controls.Add(Me.Label10)
        Me.NavBarGroupControlContainer1.Controls.Add(Me.txtEfectivo)
        Me.NavBarGroupControlContainer1.Controls.Add(Me.SeparatorControl3)
        Me.NavBarGroupControlContainer1.Controls.Add(Me.SeparatorControl4)
        Me.NavBarGroupControlContainer1.Name = "NavBarGroupControlContainer1"
        Me.NavBarGroupControlContainer1.Size = New System.Drawing.Size(644, 118)
        Me.NavBarGroupControlContainer1.TabIndex = 0
        '
        'ListadeDevolucion
        '
        Me.ListadeDevolucion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListadeDevolucion.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ListadeDevolucion.Appearance.Options.UseBackColor = True
        Me.ListadeDevolucion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ListadeDevolucion.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListadeDevolucion.Location = New System.Drawing.Point(224, 56)
        Me.ListadeDevolucion.Name = "ListadeDevolucion"
        Me.ListadeDevolucion.Size = New System.Drawing.Size(404, 59)
        Me.ListadeDevolucion.TabIndex = 279
        Me.ListadeDevolucion.TabStop = False
        '
        'FlowBotones
        '
        Me.FlowBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowBotones.Location = New System.Drawing.Point(4, 0)
        Me.FlowBotones.Name = "FlowBotones"
        Me.FlowBotones.Size = New System.Drawing.Size(637, 50)
        Me.FlowBotones.TabIndex = 280
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(42, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 277
        Me.Label11.Text = "Devuelta"
        '
        'txtDevolucionEfectivo
        '
        Me.txtDevolucionEfectivo.EditValue = "0"
        Me.txtDevolucionEfectivo.Enabled = False
        Me.txtDevolucionEfectivo.Location = New System.Drawing.Point(104, 93)
        Me.txtDevolucionEfectivo.Name = "txtDevolucionEfectivo"
        Me.txtDevolucionEfectivo.Properties.Appearance.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtDevolucionEfectivo.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtDevolucionEfectivo.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.txtDevolucionEfectivo.Properties.Appearance.Options.UseBackColor = True
        Me.txtDevolucionEfectivo.Properties.Appearance.Options.UseFont = True
        Me.txtDevolucionEfectivo.Properties.Appearance.Options.UseForeColor = True
        Me.txtDevolucionEfectivo.Properties.DisplayFormat.FormatString = "$0.00;($0.00)"
        Me.txtDevolucionEfectivo.Properties.Mask.EditMask = "c"
        Me.txtDevolucionEfectivo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDevolucionEfectivo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDevolucionEfectivo.Properties.NullText = "0"
        Me.txtDevolucionEfectivo.Size = New System.Drawing.Size(122, 22)
        Me.txtDevolucionEfectivo.TabIndex = 276
        Me.txtDevolucionEfectivo.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(19, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 274
        Me.Label10.Text = "A aplicar RD$"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEfectivo.Location = New System.Drawing.Point(104, 59)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtEfectivo.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtEfectivo.Properties.Appearance.Options.UseBackColor = True
        Me.txtEfectivo.Properties.Appearance.Options.UseFont = True
        Me.txtEfectivo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtEfectivo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtEfectivo.Properties.Mask.EditMask = "c"
        Me.txtEfectivo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtEfectivo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtEfectivo.Properties.NullText = "0"
        Me.txtEfectivo.Properties.NullValuePrompt = "0"
        Me.txtEfectivo.Size = New System.Drawing.Size(122, 22)
        Me.txtEfectivo.TabIndex = 0
        '
        'SeparatorControl3
        '
        Me.SeparatorControl3.Enabled = False
        Me.SeparatorControl3.Location = New System.Drawing.Point(-12, 76)
        Me.SeparatorControl3.Name = "SeparatorControl3"
        Me.SeparatorControl3.Size = New System.Drawing.Size(238, 20)
        Me.SeparatorControl3.TabIndex = 275
        Me.SeparatorControl3.TabStop = False
        '
        'SeparatorControl4
        '
        Me.SeparatorControl4.Enabled = False
        Me.SeparatorControl4.Location = New System.Drawing.Point(-10, 43)
        Me.SeparatorControl4.Name = "SeparatorControl4"
        Me.SeparatorControl4.Size = New System.Drawing.Size(633, 20)
        Me.SeparatorControl4.TabIndex = 281
        Me.SeparatorControl4.TabStop = False
        '
        'NavBarGroupControlContainer2
        '
        Me.NavBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer2.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtCheque)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.cbxBancoCheque)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label19)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label18)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtNoCheque)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label17)
        Me.NavBarGroupControlContainer2.Name = "NavBarGroupControlContainer2"
        Me.NavBarGroupControlContainer2.Size = New System.Drawing.Size(644, 22)
        Me.NavBarGroupControlContainer2.TabIndex = 1
        '
        'txtCheque
        '
        Me.txtCheque.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCheque.Location = New System.Drawing.Point(106, 0)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtCheque.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtCheque.Properties.Appearance.Options.UseBackColor = True
        Me.txtCheque.Properties.Appearance.Options.UseFont = True
        Me.txtCheque.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCheque.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCheque.Properties.Mask.EditMask = "c"
        Me.txtCheque.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCheque.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCheque.Properties.NullText = "0"
        Me.txtCheque.Properties.NullValuePrompt = "0"
        Me.txtCheque.Size = New System.Drawing.Size(122, 22)
        Me.txtCheque.TabIndex = 284
        '
        'cbxBancoCheque
        '
        Me.cbxBancoCheque.Location = New System.Drawing.Point(274, 0)
        Me.cbxBancoCheque.Name = "cbxBancoCheque"
        Me.cbxBancoCheque.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxBancoCheque.Properties.DropDownRows = 6
        Me.cbxBancoCheque.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("N/A", "1", 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Popular Dominicano", "2", 1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco de Reservas", "3", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco BHD León", "4", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Ademi", "5", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Caribe", "6", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco del Progreso", "7", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Santa Cruz", "8", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ScotiaBank" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10), "9", 8)})
        Me.cbxBancoCheque.Properties.SmallImages = Me.imgBancos
        Me.cbxBancoCheque.Size = New System.Drawing.Size(205, 20)
        Me.cbxBancoCheque.TabIndex = 12
        '
        'imgBancos
        '
        Me.imgBancos.ImageStream = CType(resources.GetObject("imgBancos.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgBancos.Images.SetKeyName(0, "bankX32.png")
        Me.imgBancos.Images.SetKeyName(1, "popularx32.png")
        Me.imgBancos.Images.SetKeyName(2, "reservax32.png")
        Me.imgBancos.Images.SetKeyName(3, "bhdx32.png")
        Me.imgBancos.Images.SetKeyName(4, "ademix32.png")
        Me.imgBancos.Images.SetKeyName(5, "caribex32.png")
        Me.imgBancos.Images.SetKeyName(6, "elprogresox32.png")
        Me.imgBancos.Images.SetKeyName(7, "stantacruzx32.png")
        Me.imgBancos.Images.SetKeyName(8, "scotiax32.png")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(232, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 13)
        Me.Label19.TabIndex = 283
        Me.Label19.Text = "Banco"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label18.Location = New System.Drawing.Point(485, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 281
        Me.Label18.Text = "# Cheque"
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Location = New System.Drawing.Point(546, 0)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNoCheque.Properties.Appearance.Options.UseFont = True
        Me.txtNoCheque.Size = New System.Drawing.Size(95, 20)
        Me.txtNoCheque.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label17.Location = New System.Drawing.Point(27, 4)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 13)
        Me.Label17.TabIndex = 275
        Me.Label17.Text = "A aplicar RD$"
        '
        'NavBarGroupControlContainer3
        '
        Me.NavBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer3.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer3.Controls.Add(Me.Panel1)
        Me.NavBarGroupControlContainer3.Controls.Add(Me.GroupControl3)
        Me.NavBarGroupControlContainer3.Name = "NavBarGroupControlContainer3"
        Me.NavBarGroupControlContainer3.Size = New System.Drawing.Size(644, 115)
        Me.NavBarGroupControlContainer3.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SeparatorControl5)
        Me.Panel1.Controls.Add(Me.txtBalanceCredito)
        Me.Panel1.Controls.Add(Me.txtBalanceUtilizado)
        Me.Panel1.Controls.Add(Me.txtBalanceGenerado)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.txtMontoCredito)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.SeparatorControl6)
        Me.Panel1.Location = New System.Drawing.Point(243, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(401, 104)
        Me.Panel1.TabIndex = 22
        Me.Panel1.Text = "Resolución de crédito"
        Me.Panel1.Visible = False
        '
        'SeparatorControl5
        '
        Me.SeparatorControl5.BackColor = System.Drawing.Color.Transparent
        Me.SeparatorControl5.Enabled = False
        Me.SeparatorControl5.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.SeparatorControl5.Location = New System.Drawing.Point(131, -60)
        Me.SeparatorControl5.Name = "SeparatorControl5"
        Me.SeparatorControl5.Size = New System.Drawing.Size(19, 194)
        Me.SeparatorControl5.TabIndex = 281
        Me.SeparatorControl5.TabStop = False
        '
        'txtBalanceCredito
        '
        Me.txtBalanceCredito.AutoSize = True
        Me.txtBalanceCredito.BackColor = System.Drawing.Color.Transparent
        Me.txtBalanceCredito.ForeColor = System.Drawing.Color.Green
        Me.txtBalanceCredito.Location = New System.Drawing.Point(258, 3)
        Me.txtBalanceCredito.Name = "txtBalanceCredito"
        Me.txtBalanceCredito.Size = New System.Drawing.Size(13, 13)
        Me.txtBalanceCredito.TabIndex = 280
        Me.txtBalanceCredito.Text = "0"
        '
        'txtBalanceUtilizado
        '
        Me.txtBalanceUtilizado.AutoSize = True
        Me.txtBalanceUtilizado.ForeColor = System.Drawing.Color.Red
        Me.txtBalanceUtilizado.Location = New System.Drawing.Point(11, 82)
        Me.txtBalanceUtilizado.Name = "txtBalanceUtilizado"
        Me.txtBalanceUtilizado.Size = New System.Drawing.Size(13, 13)
        Me.txtBalanceUtilizado.TabIndex = 279
        Me.txtBalanceUtilizado.Text = "0"
        '
        'txtBalanceGenerado
        '
        Me.txtBalanceGenerado.AutoSize = True
        Me.txtBalanceGenerado.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtBalanceGenerado.Location = New System.Drawing.Point(11, 42)
        Me.txtBalanceGenerado.Name = "txtBalanceGenerado"
        Me.txtBalanceGenerado.Size = New System.Drawing.Size(13, 13)
        Me.txtBalanceGenerado.TabIndex = 278
        Me.txtBalanceGenerado.Text = "0"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label28.Location = New System.Drawing.Point(150, 31)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 13)
        Me.Label28.TabIndex = 277
        Me.Label28.Text = "Monto a utilizar"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(150, 65)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(244, 33)
        Me.Label27.TabIndex = 4
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(150, 2)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 13)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "Total disponible:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(11, 65)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 13)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Total utilizado"
        '
        'txtMontoCredito
        '
        Me.txtMontoCredito.EditValue = 0R
        Me.txtMontoCredito.Location = New System.Drawing.Point(236, 28)
        Me.txtMontoCredito.Name = "txtMontoCredito"
        Me.txtMontoCredito.Properties.Mask.EditMask = "c"
        Me.txtMontoCredito.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMontoCredito.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtMontoCredito.Properties.NullText = "0"
        Me.txtMontoCredito.Size = New System.Drawing.Size(127, 20)
        Me.txtMontoCredito.TabIndex = 22
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(11, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 13)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Total generado"
        '
        'SeparatorControl6
        '
        Me.SeparatorControl6.Enabled = False
        Me.SeparatorControl6.Location = New System.Drawing.Point(130, 47)
        Me.SeparatorControl6.Name = "SeparatorControl6"
        Me.SeparatorControl6.Size = New System.Drawing.Size(246, 23)
        Me.SeparatorControl6.TabIndex = 282
        Me.SeparatorControl6.TabStop = False
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.Label23)
        Me.GroupControl3.Controls.Add(Me.txtIDCredito)
        Me.GroupControl3.Controls.Add(Me.btnBuscarCreditos)
        Me.GroupControl3.Location = New System.Drawing.Point(3, 4)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(234, 104)
        Me.GroupControl3.TabIndex = 19
        Me.GroupControl3.Text = "Buscar créditos hábiles"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label23.Location = New System.Drawing.Point(8, 38)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(28, 13)
        Me.Label23.TabIndex = 275
        Me.Label23.Text = "No.:"
        '
        'txtIDCredito
        '
        Me.txtIDCredito.Location = New System.Drawing.Point(40, 35)
        Me.txtIDCredito.Name = "txtIDCredito"
        Me.txtIDCredito.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtIDCredito.Properties.Appearance.Options.UseBackColor = True
        Me.txtIDCredito.Properties.Appearance.Options.UseTextOptions = True
        Me.txtIDCredito.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtIDCredito.Size = New System.Drawing.Size(183, 20)
        Me.txtIDCredito.TabIndex = 20
        '
        'btnBuscarCreditos
        '
        Me.btnBuscarCreditos.Location = New System.Drawing.Point(8, 70)
        Me.btnBuscarCreditos.Name = "btnBuscarCreditos"
        Me.btnBuscarCreditos.Size = New System.Drawing.Size(215, 25)
        Me.btnBuscarCreditos.TabIndex = 21
        Me.btnBuscarCreditos.Text = "Buscar"
        '
        'NavBarGroupControlContainer4
        '
        Me.NavBarGroupControlContainer4.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer4.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer4.Controls.Add(Me.lblClaseTarjeta)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.Label33)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.gcAprobacion)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.Label32)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.txtTarjeta)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.PictureBox3)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.txtNoTarjeta)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.PictureBox2)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.Label15)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.cbxAño)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.PictureBox1)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.Label14)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.Label13)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.Label12)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.cbxMes)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.cbxBancoTarjeta)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.rdbTipoTarjeta)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.Label9)
        Me.NavBarGroupControlContainer4.Name = "NavBarGroupControlContainer4"
        Me.NavBarGroupControlContainer4.Size = New System.Drawing.Size(644, 106)
        Me.NavBarGroupControlContainer4.TabIndex = 3
        '
        'lblClaseTarjeta
        '
        Me.lblClaseTarjeta.EditValue = " "
        Me.lblClaseTarjeta.Enabled = False
        Me.lblClaseTarjeta.Location = New System.Drawing.Point(233, 1)
        Me.lblClaseTarjeta.Name = "lblClaseTarjeta"
        Me.lblClaseTarjeta.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblClaseTarjeta.Properties.Appearance.Options.UseFont = True
        Me.lblClaseTarjeta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lblClaseTarjeta.Properties.Items.AddRange(New Object() {"CRÉDITO", "DÉBITO"})
        Me.lblClaseTarjeta.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.lblClaseTarjeta.Size = New System.Drawing.Size(102, 22)
        Me.lblClaseTarjeta.TabIndex = 2
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label33.Location = New System.Drawing.Point(338, 8)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(30, 13)
        Me.Label33.TabIndex = 289
        Me.Label33.Text = "Tipo"
        '
        'gcAprobacion
        '
        Me.gcAprobacion.Controls.Add(Me.Label16)
        Me.gcAprobacion.Controls.Add(Me.ImageEdit1)
        Me.gcAprobacion.Controls.Add(Me.txtNoAprobacion)
        Me.gcAprobacion.Enabled = False
        Me.gcAprobacion.Location = New System.Drawing.Point(341, 39)
        Me.gcAprobacion.Name = "gcAprobacion"
        Me.gcAprobacion.Size = New System.Drawing.Size(281, 65)
        Me.gcAprobacion.TabIndex = 8
        Me.gcAprobacion.Text = "Aprobación No."
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(218, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 289
        Me.Label16.Text = "Boucher"
        '
        'ImageEdit1
        '
        Me.ImageEdit1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ImageEdit1.Location = New System.Drawing.Point(221, 37)
        Me.ImageEdit1.Name = "ImageEdit1"
        Me.ImageEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageEdit1.Size = New System.Drawing.Size(48, 20)
        Me.ImageEdit1.TabIndex = 10
        '
        'txtNoAprobacion
        '
        Me.txtNoAprobacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoAprobacion.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtNoAprobacion.Location = New System.Drawing.Point(11, 25)
        Me.txtNoAprobacion.Name = "txtNoAprobacion"
        Me.txtNoAprobacion.Size = New System.Drawing.Size(201, 32)
        Me.txtNoAprobacion.TabIndex = 8
        Me.txtNoAprobacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label32.Location = New System.Drawing.Point(19, 5)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(71, 13)
        Me.Label32.TabIndex = 287
        Me.Label32.Text = "A aplicar RD$"
        '
        'txtTarjeta
        '
        Me.txtTarjeta.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtTarjeta.Location = New System.Drawing.Point(104, 1)
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtTarjeta.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjeta.Properties.Appearance.Options.UseBackColor = True
        Me.txtTarjeta.Properties.Appearance.Options.UseFont = True
        Me.txtTarjeta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTarjeta.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTarjeta.Properties.Mask.EditMask = "c"
        Me.txtTarjeta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTarjeta.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtTarjeta.Properties.NullText = "0"
        Me.txtTarjeta.Size = New System.Drawing.Size(122, 22)
        Me.txtTarjeta.TabIndex = 1
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(5, 80)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 285
        Me.PictureBox3.TabStop = False
        '
        'txtNoTarjeta
        '
        Me.txtNoTarjeta.Enabled = False
        Me.txtNoTarjeta.Location = New System.Drawing.Point(104, 27)
        Me.txtNoTarjeta.Name = "txtNoTarjeta"
        Me.txtNoTarjeta.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtNoTarjeta.Properties.Appearance.Options.UseFont = True
        Me.txtNoTarjeta.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNoTarjeta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtNoTarjeta.Properties.Mask.EditMask = "0000-0000-0000-0000"
        Me.txtNoTarjeta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.txtNoTarjeta.Size = New System.Drawing.Size(230, 22)
        Me.txtNoTarjeta.TabIndex = 3
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(4, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 283
        Me.PictureBox2.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label15.Location = New System.Drawing.Point(35, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 282
        Me.Label15.Text = "Tarjeta #:"
        '
        'cbxAño
        '
        Me.cbxAño.Enabled = False
        Me.cbxAño.Location = New System.Drawing.Point(233, 55)
        Me.cbxAño.Name = "cbxAño"
        Me.cbxAño.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbxAño.Properties.Appearance.Options.UseFont = True
        Me.cbxAño.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxAño.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbxAño.Size = New System.Drawing.Size(102, 22)
        Me.cbxAño.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 280
        Me.PictureBox1.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label14.Location = New System.Drawing.Point(36, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 279
        Me.Label14.Text = "Caducidad:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label13.Location = New System.Drawing.Point(204, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 278
        Me.Label13.Text = "Año"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label12.Location = New System.Drawing.Point(106, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 13)
        Me.Label12.TabIndex = 277
        Me.Label12.Text = "Mes"
        '
        'cbxMes
        '
        Me.cbxMes.Enabled = False
        Me.cbxMes.Location = New System.Drawing.Point(138, 55)
        Me.cbxMes.Name = "cbxMes"
        Me.cbxMes.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbxMes.Properties.Appearance.Options.UseFont = True
        Me.cbxMes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxMes.Properties.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbxMes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbxMes.Size = New System.Drawing.Size(63, 22)
        Me.cbxMes.TabIndex = 4
        '
        'cbxBancoTarjeta
        '
        Me.cbxBancoTarjeta.Enabled = False
        Me.cbxBancoTarjeta.Location = New System.Drawing.Point(105, 83)
        Me.cbxBancoTarjeta.Name = "cbxBancoTarjeta"
        Me.cbxBancoTarjeta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxBancoTarjeta.Properties.DropDownRows = 6
        Me.cbxBancoTarjeta.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("N/A", "1", 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Popular Dominicano", "2", 1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco de Reservas", "3", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco BHD León", "4", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Ademi", "5", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Caribe", "6", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco del Progreso", "7", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Santa Cruz", "8", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ScotiaBank" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10), "9", 8)})
        Me.cbxBancoTarjeta.Properties.LargeImages = Me.imgBancos
        Me.cbxBancoTarjeta.Size = New System.Drawing.Size(230, 20)
        Me.cbxBancoTarjeta.TabIndex = 6
        '
        'rdbTipoTarjeta
        '
        Me.rdbTipoTarjeta.Controls.Add(Me.rdbMasterCard)
        Me.rdbTipoTarjeta.Controls.Add(Me.rdbOtra)
        Me.rdbTipoTarjeta.Controls.Add(Me.rdbAmericanExpress)
        Me.rdbTipoTarjeta.Controls.Add(Me.rdbVisa)
        Me.rdbTipoTarjeta.Enabled = False
        Me.rdbTipoTarjeta.Location = New System.Drawing.Point(371, -8)
        Me.rdbTipoTarjeta.Name = "rdbTipoTarjeta"
        Me.rdbTipoTarjeta.Size = New System.Drawing.Size(251, 42)
        Me.rdbTipoTarjeta.TabIndex = 7
        '
        'rdbMasterCard
        '
        Me.rdbMasterCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.rdbMasterCard.Image = CType(resources.GetObject("rdbMasterCard.Image"), System.Drawing.Image)
        Me.rdbMasterCard.Location = New System.Drawing.Point(66, 3)
        Me.rdbMasterCard.Name = "rdbMasterCard"
        Me.rdbMasterCard.Size = New System.Drawing.Size(57, 38)
        Me.rdbMasterCard.TabIndex = 1
        Me.rdbMasterCard.Tag = "MasterCard"
        Me.rdbMasterCard.UseVisualStyleBackColor = True
        '
        'rdbOtra
        '
        Me.rdbOtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.rdbOtra.Location = New System.Drawing.Point(191, 3)
        Me.rdbOtra.Name = "rdbOtra"
        Me.rdbOtra.Size = New System.Drawing.Size(55, 38)
        Me.rdbOtra.TabIndex = 3
        Me.rdbOtra.Tag = "Otra"
        Me.rdbOtra.Text = "Otra"
        Me.rdbOtra.UseVisualStyleBackColor = True
        '
        'rdbAmericanExpress
        '
        Me.rdbAmericanExpress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.rdbAmericanExpress.Image = CType(resources.GetObject("rdbAmericanExpress.Image"), System.Drawing.Image)
        Me.rdbAmericanExpress.Location = New System.Drawing.Point(129, 3)
        Me.rdbAmericanExpress.Name = "rdbAmericanExpress"
        Me.rdbAmericanExpress.Size = New System.Drawing.Size(57, 38)
        Me.rdbAmericanExpress.TabIndex = 2
        Me.rdbAmericanExpress.Tag = "AmericanExpress"
        Me.rdbAmericanExpress.UseVisualStyleBackColor = True
        '
        'rdbVisa
        '
        Me.rdbVisa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.rdbVisa.Checked = True
        Me.rdbVisa.Image = CType(resources.GetObject("rdbVisa.Image"), System.Drawing.Image)
        Me.rdbVisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbVisa.Location = New System.Drawing.Point(3, 3)
        Me.rdbVisa.Name = "rdbVisa"
        Me.rdbVisa.Size = New System.Drawing.Size(57, 38)
        Me.rdbVisa.TabIndex = 0
        Me.rdbVisa.TabStop = True
        Me.rdbVisa.Tag = "Visa"
        Me.rdbVisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbVisa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.rdbVisa.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label9.Location = New System.Drawing.Point(36, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 274
        Me.Label9.Text = "Banco:"
        '
        'NavBarGroupControlContainer5
        '
        Me.NavBarGroupControlContainer5.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer5.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer5.Controls.Add(Me.GridControl1)
        Me.NavBarGroupControlContainer5.Controls.Add(Me.Label36)
        Me.NavBarGroupControlContainer5.Controls.Add(Me.txtCobrosAdelantados)
        Me.NavBarGroupControlContainer5.Controls.Add(Me.Label35)
        Me.NavBarGroupControlContainer5.Controls.Add(Me.txtPermuta)
        Me.NavBarGroupControlContainer5.Controls.Add(Me.Label34)
        Me.NavBarGroupControlContainer5.Controls.Add(Me.txtBonos)
        Me.NavBarGroupControlContainer5.Name = "NavBarGroupControlContainer5"
        Me.NavBarGroupControlContainer5.Size = New System.Drawing.Size(644, 252)
        Me.NavBarGroupControlContainer5.TabIndex = 4
        '
        'GridControl1
        '
        Me.GridControl1.Enabled = False
        Me.GridControl1.Location = New System.Drawing.Point(0, 59)
        Me.GridControl1.MainView = Me.AdvBandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(643, 190)
        Me.GridControl1.TabIndex = 281
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView1, Me.GridView1})
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.IDCobrosAdelantados_hijo, Me.IDCobrosAdelantados, Me.SecondID, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7})
        Me.AdvBandedGridView1.GridControl = Me.GridControl1
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
        Me.AdvBandedGridView1.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.AdvBandedGridView1.OptionsView.ShowFooter = True
        Me.AdvBandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Cobros adelantados"
        Me.GridBand1.Columns.Add(Me.IDCobrosAdelantados_hijo)
        Me.GridBand1.Columns.Add(Me.IDCobrosAdelantados)
        Me.GridBand1.Columns.Add(Me.SecondID)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 625
        '
        'IDCobrosAdelantados_hijo
        '
        Me.IDCobrosAdelantados_hijo.Caption = "IDCobrosAdelantados_hijo"
        Me.IDCobrosAdelantados_hijo.FieldName = "IDCobrosAdelantados_hijo"
        Me.IDCobrosAdelantados_hijo.Name = "IDCobrosAdelantados_hijo"
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowEdit = False
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowFocus = False
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowIncrementalSearch = False
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowMove = False
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowShowHide = False
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowSize = False
        Me.IDCobrosAdelantados_hijo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDCobrosAdelantados_hijo.OptionsColumn.ReadOnly = True
        Me.IDCobrosAdelantados_hijo.OptionsColumn.ShowInCustomizationForm = False
        Me.IDCobrosAdelantados_hijo.OptionsColumn.ShowInExpressionEditor = False
        Me.IDCobrosAdelantados_hijo.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'IDCobrosAdelantados
        '
        Me.IDCobrosAdelantados.Caption = "IDCobrosAdelantados"
        Me.IDCobrosAdelantados.FieldName = "IDCobrosAdelantados"
        Me.IDCobrosAdelantados.Name = "IDCobrosAdelantados"
        Me.IDCobrosAdelantados.OptionsColumn.AllowEdit = False
        Me.IDCobrosAdelantados.OptionsColumn.AllowFocus = False
        Me.IDCobrosAdelantados.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDCobrosAdelantados.OptionsColumn.AllowIncrementalSearch = False
        Me.IDCobrosAdelantados.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDCobrosAdelantados.OptionsColumn.AllowMove = False
        Me.IDCobrosAdelantados.OptionsColumn.AllowShowHide = False
        Me.IDCobrosAdelantados.OptionsColumn.AllowSize = False
        Me.IDCobrosAdelantados.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDCobrosAdelantados.OptionsColumn.ReadOnly = True
        Me.IDCobrosAdelantados.OptionsColumn.ShowInCustomizationForm = False
        Me.IDCobrosAdelantados.OptionsColumn.ShowInExpressionEditor = False
        Me.IDCobrosAdelantados.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'SecondID
        '
        Me.SecondID.Caption = "Transaccion"
        Me.SecondID.FieldName = "SecondID"
        Me.SecondID.Name = "SecondID"
        Me.SecondID.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.SecondID.Visible = True
        Me.SecondID.Width = 110
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Fecha"
        Me.BandedGridColumn4.DisplayFormat.FormatString = "f"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn4.FieldName = "Fecha"
        Me.BandedGridColumn4.GroupFormat.FormatString = "f"
        Me.BandedGridColumn4.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn4.OptionsColumn.AllowIncrementalSearch = False
        Me.BandedGridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn4.OptionsColumn.AllowMove = False
        Me.BandedGridColumn4.OptionsColumn.AllowShowHide = False
        Me.BandedGridColumn4.OptionsColumn.AllowSize = False
        Me.BandedGridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn4.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn4.OptionsColumn.ShowInCustomizationForm = False
        Me.BandedGridColumn4.OptionsColumn.ShowInExpressionEditor = False
        Me.BandedGridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 237
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Disponible"
        Me.BandedGridColumn5.DisplayFormat.FormatString = "c"
        Me.BandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn5.FieldName = "Disponible"
        Me.BandedGridColumn5.GroupFormat.FormatString = "c"
        Me.BandedGridColumn5.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn5.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn5.OptionsColumn.AllowIncrementalSearch = False
        Me.BandedGridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn5.OptionsColumn.AllowMove = False
        Me.BandedGridColumn5.OptionsColumn.AllowShowHide = False
        Me.BandedGridColumn5.OptionsColumn.AllowSize = False
        Me.BandedGridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn5.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn5.OptionsColumn.ShowInCustomizationForm = False
        Me.BandedGridColumn5.OptionsColumn.ShowInExpressionEditor = False
        Me.BandedGridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Disponible", "{0:c2}")})
        Me.BandedGridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 112
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Utilizar"
        Me.BandedGridColumn6.DisplayFormat.FormatString = "c"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.FieldName = "Utilizar"
        Me.BandedGridColumn6.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn6.OptionsColumn.AllowIncrementalSearch = False
        Me.BandedGridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn6.OptionsColumn.AllowMove = False
        Me.BandedGridColumn6.OptionsColumn.AllowShowHide = False
        Me.BandedGridColumn6.OptionsColumn.AllowSize = False
        Me.BandedGridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn6.OptionsColumn.ShowInCustomizationForm = False
        Me.BandedGridColumn6.OptionsColumn.ShowInExpressionEditor = False
        Me.BandedGridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Utilizar", "{0:c2}")})
        Me.BandedGridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 137
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridColumn7.Caption = "Eliminar"
        Me.BandedGridColumn7.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.BandedGridColumn7.FieldName = "Eliminar"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn7.OptionsColumn.AllowIncrementalSearch = False
        Me.BandedGridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn7.OptionsColumn.AllowMove = False
        Me.BandedGridColumn7.OptionsColumn.AllowShowHide = False
        Me.BandedGridColumn7.OptionsColumn.AllowSize = False
        Me.BandedGridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn7.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn7.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn7.OptionsColumn.ShowCaption = False
        Me.BandedGridColumn7.OptionsColumn.ShowInCustomizationForm = False
        Me.BandedGridColumn7.OptionsColumn.ShowInExpressionEditor = False
        Me.BandedGridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 29
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TransaccionChild, Me.TransaccionID, Me.Transaccion, Me.Fecha, Me.Disponible, Me.Utilizar, Me.Eliminar})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'TransaccionChild
        '
        Me.TransaccionChild.Caption = "TransaccionChild"
        Me.TransaccionChild.FieldName = "TransaccionChild"
        Me.TransaccionChild.Name = "TransaccionChild"
        Me.TransaccionChild.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'TransaccionID
        '
        Me.TransaccionID.Caption = "TransaccionID"
        Me.TransaccionID.FieldName = "TransaccionID"
        Me.TransaccionID.Name = "TransaccionID"
        Me.TransaccionID.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'Transaccion
        '
        Me.Transaccion.Caption = "Transaccion"
        Me.Transaccion.FieldName = "Transaccion"
        Me.Transaccion.Name = "Transaccion"
        Me.Transaccion.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Transaccion.Visible = True
        Me.Transaccion.VisibleIndex = 0
        Me.Transaccion.Width = 110
        '
        'Fecha
        '
        Me.Fecha.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.Fecha.AppearanceCell.Options.UseBackColor = True
        Me.Fecha.Caption = "Fecha"
        Me.Fecha.DisplayFormat.FormatString = "f"
        Me.Fecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Fecha.FieldName = "Fecha"
        Me.Fecha.GroupFormat.FormatString = "f"
        Me.Fecha.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Fecha.Name = "Fecha"
        Me.Fecha.OptionsColumn.AllowEdit = False
        Me.Fecha.OptionsColumn.AllowFocus = False
        Me.Fecha.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Fecha.OptionsColumn.AllowIncrementalSearch = False
        Me.Fecha.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Fecha.OptionsColumn.AllowMove = False
        Me.Fecha.OptionsColumn.AllowShowHide = False
        Me.Fecha.OptionsColumn.AllowSize = False
        Me.Fecha.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Fecha.OptionsColumn.ReadOnly = True
        Me.Fecha.OptionsColumn.ShowInCustomizationForm = False
        Me.Fecha.OptionsColumn.ShowInExpressionEditor = False
        Me.Fecha.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.Fecha.Visible = True
        Me.Fecha.VisibleIndex = 1
        Me.Fecha.Width = 236
        '
        'Disponible
        '
        Me.Disponible.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.Disponible.AppearanceCell.Options.UseBackColor = True
        Me.Disponible.Caption = "Disponible"
        Me.Disponible.DisplayFormat.FormatString = "c"
        Me.Disponible.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Disponible.FieldName = "Disponible"
        Me.Disponible.GroupFormat.FormatString = "c"
        Me.Disponible.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Disponible.Name = "Disponible"
        Me.Disponible.OptionsColumn.AllowEdit = False
        Me.Disponible.OptionsColumn.AllowFocus = False
        Me.Disponible.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Disponible.OptionsColumn.AllowIncrementalSearch = False
        Me.Disponible.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Disponible.OptionsColumn.AllowMove = False
        Me.Disponible.OptionsColumn.AllowShowHide = False
        Me.Disponible.OptionsColumn.AllowSize = False
        Me.Disponible.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Disponible.OptionsColumn.ReadOnly = True
        Me.Disponible.OptionsColumn.ShowInCustomizationForm = False
        Me.Disponible.OptionsColumn.ShowInExpressionEditor = False
        Me.Disponible.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Disponible", "{0:c2}")})
        Me.Disponible.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Disponible.Visible = True
        Me.Disponible.VisibleIndex = 2
        Me.Disponible.Width = 112
        '
        'Utilizar
        '
        Me.Utilizar.Caption = "Utilizar"
        Me.Utilizar.DisplayFormat.FormatString = "c"
        Me.Utilizar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Utilizar.FieldName = "Utilizar"
        Me.Utilizar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Utilizar.Name = "Utilizar"
        Me.Utilizar.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Utilizar.OptionsColumn.AllowIncrementalSearch = False
        Me.Utilizar.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Utilizar.OptionsColumn.AllowMove = False
        Me.Utilizar.OptionsColumn.AllowShowHide = False
        Me.Utilizar.OptionsColumn.AllowSize = False
        Me.Utilizar.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Utilizar.OptionsColumn.ShowInCustomizationForm = False
        Me.Utilizar.OptionsColumn.ShowInExpressionEditor = False
        Me.Utilizar.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Utilizar", "{0:c2}")})
        Me.Utilizar.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Utilizar.Visible = True
        Me.Utilizar.VisibleIndex = 3
        Me.Utilizar.Width = 136
        '
        'Eliminar
        '
        Me.Eliminar.AppearanceCell.Options.UseTextOptions = True
        Me.Eliminar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Eliminar.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Eliminar.AppearanceHeader.Options.UseTextOptions = True
        Me.Eliminar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Eliminar.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Eliminar.Caption = "Buscar"
        Me.Eliminar.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.Eliminar.FieldName = "Eliminar"
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.OptionsColumn.AllowEdit = False
        Me.Eliminar.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Eliminar.OptionsColumn.AllowIncrementalSearch = False
        Me.Eliminar.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Eliminar.OptionsColumn.AllowMove = False
        Me.Eliminar.OptionsColumn.AllowShowHide = False
        Me.Eliminar.OptionsColumn.AllowSize = False
        Me.Eliminar.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Eliminar.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.[False]
        Me.Eliminar.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.Eliminar.OptionsColumn.ShowCaption = False
        Me.Eliminar.OptionsColumn.ShowInCustomizationForm = False
        Me.Eliminar.OptionsColumn.ShowInExpressionEditor = False
        Me.Eliminar.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.Eliminar.Visible = True
        Me.Eliminar.VisibleIndex = 4
        Me.Eliminar.Width = 26
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label36.Location = New System.Drawing.Point(8, 34)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(103, 13)
        Me.Label36.TabIndex = 280
        Me.Label36.Text = "Cobros adelantados"
        '
        'txtCobrosAdelantados
        '
        Me.txtCobrosAdelantados.EditValue = 0R
        Me.txtCobrosAdelantados.Location = New System.Drawing.Point(114, 31)
        Me.txtCobrosAdelantados.Name = "txtCobrosAdelantados"
        Me.txtCobrosAdelantados.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtCobrosAdelantados.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtCobrosAdelantados.Properties.Appearance.Options.UseBackColor = True
        Me.txtCobrosAdelantados.Properties.Appearance.Options.UseFont = True
        Me.txtCobrosAdelantados.Properties.Mask.EditMask = "c"
        Me.txtCobrosAdelantados.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCobrosAdelantados.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCobrosAdelantados.Properties.NullText = "0"
        Me.txtCobrosAdelantados.Size = New System.Drawing.Size(122, 22)
        Me.txtCobrosAdelantados.TabIndex = 19
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label35.Location = New System.Drawing.Point(260, 7)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(52, 13)
        Me.Label35.TabIndex = 278
        Me.Label35.Text = "Permutas"
        '
        'txtPermuta
        '
        Me.txtPermuta.EditValue = 0R
        Me.txtPermuta.Location = New System.Drawing.Point(366, 4)
        Me.txtPermuta.Name = "txtPermuta"
        Me.txtPermuta.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPermuta.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtPermuta.Properties.Appearance.Options.UseBackColor = True
        Me.txtPermuta.Properties.Appearance.Options.UseFont = True
        Me.txtPermuta.Properties.Mask.EditMask = "c"
        Me.txtPermuta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPermuta.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPermuta.Properties.NullText = "0"
        Me.txtPermuta.Size = New System.Drawing.Size(122, 22)
        Me.txtPermuta.TabIndex = 18
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label34.Location = New System.Drawing.Point(8, 6)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 276
        Me.Label34.Text = "Bonos"
        '
        'txtBonos
        '
        Me.txtBonos.EditValue = "0"
        Me.txtBonos.Location = New System.Drawing.Point(114, 3)
        Me.txtBonos.Name = "txtBonos"
        Me.txtBonos.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtBonos.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtBonos.Properties.Appearance.Options.UseBackColor = True
        Me.txtBonos.Properties.Appearance.Options.UseFont = True
        Me.txtBonos.Properties.Mask.EditMask = "c"
        Me.txtBonos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtBonos.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtBonos.Properties.NullText = "0"
        Me.txtBonos.Size = New System.Drawing.Size(122, 22)
        Me.txtBonos.TabIndex = 17
        '
        'NavBarGroupControlContainer6
        '
        Me.NavBarGroupControlContainer6.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer6.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer6.Controls.Add(Me.Label22)
        Me.NavBarGroupControlContainer6.Controls.Add(Me.cbxBancoDeposito)
        Me.NavBarGroupControlContainer6.Controls.Add(Me.Label20)
        Me.NavBarGroupControlContainer6.Controls.Add(Me.txtDeposito)
        Me.NavBarGroupControlContainer6.Controls.Add(Me.Label21)
        Me.NavBarGroupControlContainer6.Controls.Add(Me.txtInformacionDeposito)
        Me.NavBarGroupControlContainer6.Name = "NavBarGroupControlContainer6"
        Me.NavBarGroupControlContainer6.Size = New System.Drawing.Size(644, 25)
        Me.NavBarGroupControlContainer6.TabIndex = 5
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label22.Location = New System.Drawing.Point(27, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 292
        Me.Label22.Text = "A aplicar RD$"
        '
        'cbxBancoDeposito
        '
        Me.cbxBancoDeposito.Location = New System.Drawing.Point(271, 1)
        Me.cbxBancoDeposito.Name = "cbxBancoDeposito"
        Me.cbxBancoDeposito.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxBancoDeposito.Properties.DropDownRows = 6
        Me.cbxBancoDeposito.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("N/A", "1", 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Popular Dominicano", "2", 1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco de Reservas", "3", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco BHD León", "4", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Ademi", "5", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Caribe", "6", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco del Progreso", "7", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Banco Santa Cruz", "8", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ScotiaBank" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10), "9", 8)})
        Me.cbxBancoDeposito.Properties.SmallImages = Me.imgBancos
        Me.cbxBancoDeposito.Size = New System.Drawing.Size(194, 20)
        Me.cbxBancoDeposito.TabIndex = 15
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(232, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 13)
        Me.Label20.TabIndex = 290
        Me.Label20.Text = "Banco"
        '
        'txtDeposito
        '
        Me.txtDeposito.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDeposito.Location = New System.Drawing.Point(104, 1)
        Me.txtDeposito.Name = "txtDeposito"
        Me.txtDeposito.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtDeposito.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtDeposito.Properties.Appearance.Options.UseBackColor = True
        Me.txtDeposito.Properties.Appearance.Options.UseFont = True
        Me.txtDeposito.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDeposito.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDeposito.Properties.Mask.EditMask = "c"
        Me.txtDeposito.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDeposito.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDeposito.Properties.NullText = "0"
        Me.txtDeposito.Size = New System.Drawing.Size(122, 22)
        Me.txtDeposito.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label21.Location = New System.Drawing.Point(471, 4)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(28, 13)
        Me.Label21.TabIndex = 288
        Me.Label21.Text = "Ref:"
        '
        'txtInformacionDeposito
        '
        Me.txtInformacionDeposito.Location = New System.Drawing.Point(498, 1)
        Me.txtInformacionDeposito.Name = "txtInformacionDeposito"
        Me.txtInformacionDeposito.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtInformacionDeposito.Properties.Appearance.Options.UseFont = True
        Me.txtInformacionDeposito.Size = New System.Drawing.Size(141, 20)
        Me.txtInformacionDeposito.TabIndex = 16
        '
        'NavBarTarjeta
        '
        Me.NavBarTarjeta.AllowHtmlString = DevExpress.Utils.DefaultBoolean.[True]
        Me.NavBarTarjeta.Caption = "<u><color=30,144,255><B>[F2]</B></color></u>  Tarjetas de crédito y débito "
        Me.NavBarTarjeta.ControlContainer = Me.NavBarGroupControlContainer4
        Me.NavBarTarjeta.GroupClientHeight = 110
        Me.NavBarTarjeta.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarTarjeta.ImageOptions.LargeImage = CType(resources.GetObject("NavBarTarjeta.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarTarjeta.Name = "NavBarTarjeta"
        Me.NavBarTarjeta.Tag = "0"
        '
        'NavBarCheque
        '
        Me.NavBarCheque.AllowHtmlString = DevExpress.Utils.DefaultBoolean.[True]
        Me.NavBarCheque.Caption = "<u><color=30,144,255><B>[F3]</B></color></u>  Cheques"
        Me.NavBarCheque.ControlContainer = Me.NavBarGroupControlContainer2
        Me.NavBarCheque.GroupClientHeight = 26
        Me.NavBarCheque.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarCheque.ImageOptions.LargeImage = CType(resources.GetObject("NavBarCheque.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarCheque.Name = "NavBarCheque"
        Me.NavBarCheque.Tag = "0"
        '
        'NavBarDeposito
        '
        Me.NavBarDeposito.AllowHtmlString = DevExpress.Utils.DefaultBoolean.[True]
        Me.NavBarDeposito.Caption = "<u><color=30,144,255><B>[F4]</B></color></u>  Depósitos"
        Me.NavBarDeposito.ControlContainer = Me.NavBarGroupControlContainer6
        Me.NavBarDeposito.GroupClientHeight = 29
        Me.NavBarDeposito.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarDeposito.ImageOptions.LargeImage = CType(resources.GetObject("NavBarDeposito.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarDeposito.Name = "NavBarDeposito"
        Me.NavBarDeposito.Tag = "0"
        '
        'NavBarBonos
        '
        Me.NavBarBonos.AllowHtmlString = DevExpress.Utils.DefaultBoolean.[True]
        Me.NavBarBonos.Caption = "<u><color=30,144,255><B>[F5]</B></color></u>  Bonos, Permutas y cobros adelantado" &
    "s"
        Me.NavBarBonos.ControlContainer = Me.NavBarGroupControlContainer5
        Me.NavBarBonos.GroupClientHeight = 256
        Me.NavBarBonos.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarBonos.ImageOptions.LargeImage = CType(resources.GetObject("NavBarBonos.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarBonos.Name = "NavBarBonos"
        Me.NavBarBonos.Tag = "0"
        '
        'NavBarCreditos
        '
        Me.NavBarCreditos.AllowHtmlString = DevExpress.Utils.DefaultBoolean.[True]
        Me.NavBarCreditos.Caption = "<u><color=30,144,255><B>[F6]</B></color></u>  Créditos y devoluciones"
        Me.NavBarCreditos.ControlContainer = Me.NavBarGroupControlContainer3
        Me.NavBarCreditos.GroupClientHeight = 119
        Me.NavBarCreditos.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarCreditos.ImageOptions.LargeImage = CType(resources.GetObject("NavBarCreditos.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarCreditos.Name = "NavBarCreditos"
        Me.NavBarCreditos.Tag = "0"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.ImageOptions.Image = CType(resources.GetObject("btnCancelar.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(573, 573)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(76, 107)
        Me.btnCancelar.TabIndex = 24
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnContinuar
        '
        Me.btnContinuar.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnContinuar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnContinuar.ImageOptions.Image = CType(resources.GetObject("btnContinuar.ImageOptions.Image"), System.Drawing.Image)
        Me.btnContinuar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnContinuar.Location = New System.Drawing.Point(376, 573)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(191, 107)
        Me.btnContinuar.TabIndex = 23
        Me.btnContinuar.Text = "<color=30,144,255><B>[END]/[F10]</B> </color> Pagar ahora"
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.GroupControl1.Controls.Add(Me.txtDevuelta)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.txtEfectivoCobrar)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Location = New System.Drawing.Point(7, 573)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(362, 107)
        Me.GroupControl1.TabIndex = 297
        Me.GroupControl1.Text = "Cambios "
        '
        'txtDevuelta
        '
        Me.txtDevuelta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtDevuelta.BackColor = System.Drawing.SystemColors.Info
        Me.txtDevuelta.Font = New System.Drawing.Font("Segoe UI", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.txtDevuelta.Location = New System.Drawing.Point(101, 62)
        Me.txtDevuelta.Name = "txtDevuelta"
        Me.txtDevuelta.ReadOnly = True
        Me.txtDevuelta.Size = New System.Drawing.Size(241, 36)
        Me.txtDevuelta.TabIndex = 31
        Me.txtDevuelta.TabStop = False
        Me.txtDevuelta.Text = "0"
        Me.txtDevuelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(21, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Devuelta.....:"
        '
        'txtEfectivoCobrar
        '
        Me.txtEfectivoCobrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtEfectivoCobrar.BackColor = System.Drawing.SystemColors.Info
        Me.txtEfectivoCobrar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivoCobrar.Location = New System.Drawing.Point(101, 27)
        Me.txtEfectivoCobrar.Name = "txtEfectivoCobrar"
        Me.txtEfectivoCobrar.ReadOnly = True
        Me.txtEfectivoCobrar.Size = New System.Drawing.Size(241, 29)
        Me.txtEfectivoCobrar.TabIndex = 29
        Me.txtEfectivoCobrar.TabStop = False
        Me.txtEfectivoCobrar.Text = "0"
        Me.txtEfectivoCobrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Valor de entrada"
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.SeparatorControl2.Enabled = False
        Me.SeparatorControl2.Location = New System.Drawing.Point(1, 49)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(652, 27)
        Me.SeparatorControl2.TabIndex = 298
        Me.SeparatorControl2.TabStop = False
        '
        'Timer1
        '
        '
        'frm_formadepago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(654, 714)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.cbxMoneda)
        Me.Controls.Add(Me.txtMontoCobrar)
        Me.Controls.Add(Me.NavBarControl1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.IDTransaccion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTipoDocumento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.SeparatorControl2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(670, 730)
        Me.Name = "frm_formadepago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Forma de Pago"
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.txtMontoCobrar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarControl1.ResumeLayout(False)
        Me.NavBarGroupControlContainer1.ResumeLayout(False)
        Me.NavBarGroupControlContainer1.PerformLayout()
        CType(Me.ListadeDevolucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDevolucionEfectivo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEfectivo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarGroupControlContainer2.ResumeLayout(False)
        Me.NavBarGroupControlContainer2.PerformLayout()
        CType(Me.txtCheque.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxBancoCheque.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgBancos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoCheque.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarGroupControlContainer3.ResumeLayout(False)
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoCredito.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.txtIDCredito.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarGroupControlContainer4.ResumeLayout(False)
        Me.NavBarGroupControlContainer4.PerformLayout()
        CType(Me.lblClaseTarjeta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcAprobacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcAprobacion.ResumeLayout(False)
        Me.gcAprobacion.PerformLayout()
        CType(Me.ImageEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarjeta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoTarjeta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxAño.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxMes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxBancoTarjeta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdbTipoTarjeta.ResumeLayout(False)
        Me.NavBarGroupControlContainer5.ResumeLayout(False)
        Me.NavBarGroupControlContainer5.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCobrosAdelantados.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPermuta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBonos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarGroupControlContainer6.ResumeLayout(False)
        Me.NavBarGroupControlContainer6.PerformLayout()
        CType(Me.cbxBancoDeposito.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeposito.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInformacionDeposito.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtMontoCobrar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbxMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents IDTransaccion As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTipoDocumento As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarEfectivo As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroupControlContainer1 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents ListadeDevolucion As DevExpress.XtraEditors.ImageListBoxControl
    Friend WithEvents FlowBotones As FlowLayoutPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDevolucionEfectivo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents txtEfectivo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SeparatorControl3 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl4 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents NavBarGroupControlContainer2 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents cbxBancoCheque As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNoCheque As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label17 As Label
    Friend WithEvents NavBarGroupControlContainer3 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents Panel1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SeparatorControl5 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents txtBalanceCredito As Label
    Friend WithEvents txtBalanceUtilizado As Label
    Friend WithEvents txtBalanceGenerado As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtMontoCredito As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label24 As Label
    Friend WithEvents SeparatorControl6 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label23 As Label
    Friend WithEvents txtIDCredito As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnBuscarCreditos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NavBarGroupControlContainer4 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents Label33 As Label
    Friend WithEvents gcAprobacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label16 As Label
    Friend WithEvents ImageEdit1 As DevExpress.XtraEditors.ImageEdit
    Friend WithEvents txtNoAprobacion As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtTarjeta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents txtNoTarjeta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cbxAño As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cbxMes As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbxBancoTarjeta As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents rdbTipoTarjeta As Panel
    Friend WithEvents rdbMasterCard As RadioButton
    Friend WithEvents rdbOtra As RadioButton
    Friend WithEvents rdbAmericanExpress As RadioButton
    Friend WithEvents rdbVisa As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents NavBarGroupControlContainer5 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents Label36 As Label
    Friend WithEvents txtCobrosAdelantados As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label35 As Label
    Friend WithEvents txtPermuta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label34 As Label
    Friend WithEvents txtBonos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NavBarGroupControlContainer6 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents Label22 As Label
    Friend WithEvents cbxBancoDeposito As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents Label20 As Label
    Friend WithEvents txtDeposito As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label21 As Label
    Friend WithEvents txtInformacionDeposito As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NavBarTarjeta As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarCheque As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarDeposito As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarBonos As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarCreditos As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnContinuar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtDevuelta As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEfectivoCobrar As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblClaseTarjeta As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents imgBancos As DevExpress.Utils.ImageCollection
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtCheque As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridControl1 As XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView1 As XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents IDCobrosAdelantados_hijo As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDCobrosAdelantados As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SecondID As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridView1 As XtraGrid.Views.Grid.GridView
    Friend WithEvents TransaccionChild As XtraGrid.Columns.GridColumn
    Friend WithEvents TransaccionID As XtraGrid.Columns.GridColumn
    Friend WithEvents Transaccion As XtraGrid.Columns.GridColumn
    Friend WithEvents Fecha As XtraGrid.Columns.GridColumn
    Friend WithEvents Disponible As XtraGrid.Columns.GridColumn
    Friend WithEvents Utilizar As XtraGrid.Columns.GridColumn
    Friend WithEvents Eliminar As XtraGrid.Columns.GridColumn
End Class
