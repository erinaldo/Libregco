<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_notas_debito_credito
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_notas_debito_credito))
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuscarNotaDeDébitoCréditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.GbTipoTrans = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkGenerarNCF = New System.Windows.Forms.CheckBox()
        Me.rdbNotaCredito = New System.Windows.Forms.RadioButton()
        Me.rdbNotaDebito = New System.Windows.Forms.RadioButton()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvFacturas = New System.Windows.Forms.DataGridView()
        Me.label18 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.txtItbis = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GPCliente = New DevExpress.XtraEditors.GroupControl()
        Me.txtBalanceGeneralCargos = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtMontoUltimoPago = New System.Windows.Forms.TextBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtBalanceGral = New System.Windows.Forms.TextBox()
        Me.lblCalificacion = New DevExpress.XtraEditors.LabelControl()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ILbcBalances = New DevExpress.XtraEditors.ImageListBoxControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.PicImagen = New System.Windows.Forms.PictureBox()
        Me.cbxMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.label2 = New System.Windows.Forms.Label()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GPDocumento = New DevExpress.XtraEditors.GroupControl()
        Me.lblUsuario = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtHora = New System.Windows.Forms.DateTimePicker()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtIDNota = New System.Windows.Forms.TextBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.MenuBar.SuspendLayout()
        Me.GbTipoTrans.SuspendLayout()
        CType(Me.DgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPCliente.SuspendLayout()
        CType(Me.ILbcBalances, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPDocumento.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(1041, 24)
        Me.MenuBar.TabIndex = 318
        Me.MenuBar.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Cliente"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(203, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.BuscarNotaDeDébitoCréditoToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(222, 6)
        '
        'BuscarNotaDeDébitoCréditoToolStripMenuItem
        '
        Me.BuscarNotaDeDébitoCréditoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarNotaDeDébitoCréditoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarNotaDeDébitoCréditoToolStripMenuItem.Name = "BuscarNotaDeDébitoCréditoToolStripMenuItem"
        Me.BuscarNotaDeDébitoCréditoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarNotaDeDébitoCréditoToolStripMenuItem.Size = New System.Drawing.Size(225, 38)
        Me.BuscarNotaDeDébitoCréditoToolStripMenuItem.Text = "Buscar Nota D/C  "
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(225, 38)
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
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.ForeColor = System.Drawing.Color.Black
        Me.ChkNulo.Location = New System.Drawing.Point(367, 27)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(48, 17)
        Me.ChkNulo.TabIndex = 330
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'GbTipoTrans
        '
        Me.GbTipoTrans.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbTipoTrans.Controls.Add(Me.Label5)
        Me.GbTipoTrans.Controls.Add(Me.ChkGenerarNCF)
        Me.GbTipoTrans.Controls.Add(Me.rdbNotaCredito)
        Me.GbTipoTrans.Controls.Add(Me.rdbNotaDebito)
        Me.GbTipoTrans.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GbTipoTrans.ForeColor = System.Drawing.Color.DarkRed
        Me.GbTipoTrans.Location = New System.Drawing.Point(692, 216)
        Me.GbTipoTrans.Name = "GbTipoTrans"
        Me.GbTipoTrans.Size = New System.Drawing.Size(344, 37)
        Me.GbTipoTrans.TabIndex = 2
        Me.GbTipoTrans.TabStop = False
        Me.GbTipoTrans.Text = "Tipo de Transacción"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(242, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(2, 20)
        Me.Label5.TabIndex = 6
        '
        'ChkGenerarNCF
        '
        Me.ChkGenerarNCF.AutoSize = True
        Me.ChkGenerarNCF.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ChkGenerarNCF.ForeColor = System.Drawing.Color.Black
        Me.ChkGenerarNCF.Location = New System.Drawing.Point(250, 14)
        Me.ChkGenerarNCF.Name = "ChkGenerarNCF"
        Me.ChkGenerarNCF.Size = New System.Drawing.Size(88, 17)
        Me.ChkGenerarNCF.TabIndex = 5
        Me.ChkGenerarNCF.Text = "Generar NCF"
        Me.ChkGenerarNCF.UseVisualStyleBackColor = True
        '
        'rdbNotaCredito
        '
        Me.rdbNotaCredito.AutoSize = True
        Me.rdbNotaCredito.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbNotaCredito.ForeColor = System.Drawing.Color.MediumBlue
        Me.rdbNotaCredito.Location = New System.Drawing.Point(122, 15)
        Me.rdbNotaCredito.Name = "rdbNotaCredito"
        Me.rdbNotaCredito.Size = New System.Drawing.Size(116, 17)
        Me.rdbNotaCredito.TabIndex = 4
        Me.rdbNotaCredito.Text = "Nota de Crédito (-)"
        Me.rdbNotaCredito.UseVisualStyleBackColor = True
        '
        'rdbNotaDebito
        '
        Me.rdbNotaDebito.AutoSize = True
        Me.rdbNotaDebito.Checked = True
        Me.rdbNotaDebito.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbNotaDebito.Location = New System.Drawing.Point(6, 15)
        Me.rdbNotaDebito.Name = "rdbNotaDebito"
        Me.rdbNotaDebito.Size = New System.Drawing.Size(116, 17)
        Me.rdbNotaDebito.TabIndex = 3
        Me.rdbNotaDebito.TabStop = True
        Me.rdbNotaDebito.Text = "Nota de Débito (+)"
        Me.rdbNotaDebito.UseVisualStyleBackColor = True
        '
        'txtConcepto
        '
        Me.txtConcepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConcepto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtConcepto.Location = New System.Drawing.Point(75, 222)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(611, 31)
        Me.txtConcepto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 334
        Me.Label1.Text = "Concepto"
        '
        'DgvFacturas
        '
        Me.DgvFacturas.AllowUserToAddRows = False
        Me.DgvFacturas.AllowUserToDeleteRows = False
        Me.DgvFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvFacturas.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvFacturas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvFacturas.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvFacturas.Location = New System.Drawing.Point(4, 259)
        Me.DgvFacturas.MultiSelect = False
        Me.DgvFacturas.Name = "DgvFacturas"
        Me.DgvFacturas.RowHeadersWidth = 30
        Me.DgvFacturas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DgvFacturas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DgvFacturas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvFacturas.Size = New System.Drawing.Size(1032, 271)
        Me.DgvFacturas.TabIndex = 6
        '
        'label18
        '
        Me.label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label18.Location = New System.Drawing.Point(788, 598)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(68, 15)
        Me.label18.TabIndex = 341
        Me.label18.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNeto.ForeColor = System.Drawing.Color.Black
        Me.txtNeto.Location = New System.Drawing.Point(860, 594)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(175, 23)
        Me.txtNeto.TabIndex = 340
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label16
        '
        Me.label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label16.Location = New System.Drawing.Point(821, 570)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(32, 15)
        Me.label16.TabIndex = 339
        Me.label16.Text = "ITBIS"
        '
        'txtItbis
        '
        Me.txtItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItbis.Enabled = False
        Me.txtItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtItbis.ForeColor = System.Drawing.Color.Black
        Me.txtItbis.Location = New System.Drawing.Point(860, 565)
        Me.txtItbis.Name = "txtItbis"
        Me.txtItbis.ReadOnly = True
        Me.txtItbis.Size = New System.Drawing.Size(175, 23)
        Me.txtItbis.TabIndex = 338
        Me.txtItbis.TabStop = False
        Me.txtItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label14
        '
        Me.label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label14.AutoSize = True
        Me.label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label14.Location = New System.Drawing.Point(794, 539)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(59, 15)
        Me.label14.TabIndex = 337
        Me.label14.Text = "Sub. Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubTotal.Location = New System.Drawing.Point(860, 536)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(175, 23)
        Me.txtSubTotal.TabIndex = 336
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(607, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 343
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
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(6, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 344
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 623)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1041, 25)
        Me.BarraEstado.TabIndex = 345
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
        Me.GPCliente.Location = New System.Drawing.Point(4, 125)
        Me.GPCliente.Name = "GPCliente"
        Me.GPCliente.Size = New System.Drawing.Size(744, 89)
        Me.GPCliente.TabIndex = 416
        Me.GPCliente.Text = " Información general  "
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
        'LabelControl5
        '
        Me.LabelControl5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LabelControl5.Location = New System.Drawing.Point(656, 58)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl5.TabIndex = 420
        Me.LabelControl5.Text = "Monto"
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
        'lblCalificacion
        '
        Me.lblCalificacion.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCalificacion.Location = New System.Drawing.Point(652, 22)
        Me.lblCalificacion.Name = "lblCalificacion"
        Me.lblCalificacion.Size = New System.Drawing.Size(0, 13)
        Me.lblCalificacion.TabIndex = 418
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
        Me.GPDocumento.CaptionImageOptions.Image = CType(resources.GetObject("GPDocumento.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GPDocumento.Controls.Add(Me.lblUsuario)
        Me.GPDocumento.Controls.Add(Me.LabelControl12)
        Me.GPDocumento.Controls.Add(Me.txtHora)
        Me.GPDocumento.Controls.Add(Me.LabelControl2)
        Me.GPDocumento.Controls.Add(Me.txtFecha)
        Me.GPDocumento.Controls.Add(Me.txtIDNota)
        Me.GPDocumento.Controls.Add(Me.txtSecondID)
        Me.GPDocumento.Location = New System.Drawing.Point(751, 125)
        Me.GPDocumento.Name = "GPDocumento"
        Me.GPDocumento.Size = New System.Drawing.Size(285, 89)
        Me.GPDocumento.TabIndex = 417
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
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(9, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl2.TabIndex = 169
        Me.LabelControl2.Text = "Fecha"
        '
        'txtFecha
        '
        Me.txtFecha.CustomFormat = "dd/MM/yyyy"
        Me.txtFecha.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(55, 28)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(98, 21)
        Me.txtFecha.TabIndex = 414
        '
        'txtIDNota
        '
        Me.txtIDNota.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.txtIDNota.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDNota.Enabled = False
        Me.txtIDNota.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtIDNota.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtIDNota.Location = New System.Drawing.Point(100, 4)
        Me.txtIDNota.Name = "txtIDNota"
        Me.txtIDNota.ReadOnly = True
        Me.txtIDNota.Size = New System.Drawing.Size(63, 14)
        Me.txtIDNota.TabIndex = 139
        Me.txtIDNota.TabStop = False
        Me.txtIDNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'frm_notas_debito_credito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 648)
        Me.Controls.Add(Me.GPDocumento)
        Me.Controls.Add(Me.GPCliente)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.label18)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.label16)
        Me.Controls.Add(Me.txtItbis)
        Me.Controls.Add(Me.label14)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.DgvFacturas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.GbTipoTrans)
        Me.Controls.Add(Me.MenuBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_notas_debito_credito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "95"
        Me.Text = "Notas de Débito / Crédito [CXC]"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.GbTipoTrans.ResumeLayout(False)
        Me.GbTipoTrans.PerformLayout()
        CType(Me.DgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPCliente.ResumeLayout(False)
        Me.GPCliente.PerformLayout()
        CType(Me.ILbcBalances, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPDocumento.ResumeLayout(False)
        Me.GPDocumento.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents GbTipoTrans As System.Windows.Forms.GroupBox
    Friend WithEvents ChkGenerarNCF As System.Windows.Forms.CheckBox
    Friend WithEvents rdbNotaCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNotaDebito As System.Windows.Forms.RadioButton
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents txtItbis As System.Windows.Forms.TextBox
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BuscarNotaDeDébitoCréditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents GPCliente As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtBalanceGeneralCargos As TextBox
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents txtMontoUltimoPago As TextBox
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtIDCliente As TextBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtBalanceGral As TextBox
    Friend WithEvents lblCalificacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUltimoPago As TextBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ILbcBalances As DevExpress.XtraEditors.ImageListBoxControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PicImagen As PictureBox
    Friend WithEvents cbxMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Private WithEvents label2 As Label
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents GPDocumento As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblUsuario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHora As DateTimePicker
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFecha As DateTimePicker
    Friend WithEvents txtIDNota As TextBox
    Friend WithEvents txtSecondID As TextBox
End Class
