<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_entrega_cobro
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_entrega_cobro))
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtIDEntrega = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.CbxCobrador = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.GbDatosEntrega = New System.Windows.Forms.GroupBox()
        Me.txtNoEntrega = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GbNumeracion = New System.Windows.Forms.GroupBox()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.txtNoFinal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNoInicial = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DgvRecibos = New System.Windows.Forms.DataGridView()
        Me.txtMontoEntrega = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GbComision = New System.Windows.Forms.GroupBox()
        Me.txtComision = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GbDgv = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtFechaUltEntrega = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCantRestante = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkCerrarEntrega = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtGranTotal = New DevExpress.XtraEditors.CalcEdit()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCambios = New DevExpress.XtraEditors.CalcEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEfectivo = New DevExpress.XtraEditors.CalcEdit()
        Me.MenuBar.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.GbDatosEntrega.SuspendLayout()
        Me.GbNumeracion.SuspendLayout()
        CType(Me.DgvRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbComision.SuspendLayout()
        Me.GbDgv.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtGranTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCambios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEfectivo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(724, 24)
        Me.MenuBar.TabIndex = 199
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(177, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(177, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(177, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(177, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(177, 38)
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
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Location = New System.Drawing.Point(74, 114)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 198
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Enabled = False
        Me.chkNulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkNulo.Location = New System.Drawing.Point(276, 27)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 188
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtIDEntrega)
        Me.GbxUserInfo.Controls.Add(Me.label8)
        Me.GbxUserInfo.Controls.Add(Me.Label1)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label3)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(377, 124)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(338, 76)
        Me.GbxUserInfo.TabIndex = 200
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(174, 17)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(157, 23)
        Me.txtSecondID.TabIndex = 168
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDEntrega
        '
        Me.txtIDEntrega.Enabled = False
        Me.txtIDEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEntrega.Location = New System.Drawing.Point(59, 17)
        Me.txtIDEntrega.Name = "txtIDEntrega"
        Me.txtIDEntrega.ReadOnly = True
        Me.txtIDEntrega.Size = New System.Drawing.Size(109, 23)
        Me.txtIDEntrega.TabIndex = 139
        Me.txtIDEntrega.TabStop = False
        Me.txtIDEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label8.Location = New System.Drawing.Point(6, 20)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(46, 15)
        Me.label8.TabIndex = 140
        Me.label8.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(213, 46)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(118, 23)
        Me.txtHora.TabIndex = 163
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(174, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Hora"
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(59, 46)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 167
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CbxCobrador
        '
        Me.CbxCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxCobrador.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxCobrador.FormattingEnabled = True
        Me.CbxCobrador.Location = New System.Drawing.Point(69, 17)
        Me.CbxCobrador.Name = "CbxCobrador"
        Me.CbxCobrador.Size = New System.Drawing.Size(284, 21)
        Me.CbxCobrador.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = "Cobrador"
        '
        'DtpFechaEntrega
        '
        Me.DtpFechaEntrega.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaEntrega.Location = New System.Drawing.Point(69, 44)
        Me.DtpFechaEntrega.Name = "DtpFechaEntrega"
        Me.DtpFechaEntrega.Size = New System.Drawing.Size(100, 20)
        Me.DtpFechaEntrega.TabIndex = 2
        '
        'GbDatosEntrega
        '
        Me.GbDatosEntrega.Controls.Add(Me.txtNoEntrega)
        Me.GbDatosEntrega.Controls.Add(Me.Label6)
        Me.GbDatosEntrega.Controls.Add(Me.Label2)
        Me.GbDatosEntrega.Controls.Add(Me.CbxCobrador)
        Me.GbDatosEntrega.Controls.Add(Me.DtpFechaEntrega)
        Me.GbDatosEntrega.Controls.Add(Me.Label5)
        Me.GbDatosEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbDatosEntrega.Location = New System.Drawing.Point(8, 124)
        Me.GbDatosEntrega.Name = "GbDatosEntrega"
        Me.GbDatosEntrega.Size = New System.Drawing.Size(363, 76)
        Me.GbDatosEntrega.TabIndex = 0
        Me.GbDatosEntrega.TabStop = False
        Me.GbDatosEntrega.Text = "Datos de la Entrega"
        '
        'txtNoEntrega
        '
        Me.txtNoEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoEntrega.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNoEntrega.Location = New System.Drawing.Point(250, 46)
        Me.txtNoEntrega.Name = "txtNoEntrega"
        Me.txtNoEntrega.Size = New System.Drawing.Size(103, 20)
        Me.txtNoEntrega.TabIndex = 3
        Me.txtNoEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNoEntrega.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(175, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "No. Entrega"
        Me.Label6.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 214
        Me.Label2.Text = "Fecha"
        '
        'GbNumeracion
        '
        Me.GbNumeracion.Controls.Add(Me.btnProcesar)
        Me.GbNumeracion.Controls.Add(Me.txtNoFinal)
        Me.GbNumeracion.Controls.Add(Me.Label11)
        Me.GbNumeracion.Controls.Add(Me.txtNoInicial)
        Me.GbNumeracion.Controls.Add(Me.Label10)
        Me.GbNumeracion.Controls.Add(Me.txtCantidad)
        Me.GbNumeracion.Controls.Add(Me.Label7)
        Me.GbNumeracion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbNumeracion.Location = New System.Drawing.Point(8, 206)
        Me.GbNumeracion.Name = "GbNumeracion"
        Me.GbNumeracion.Size = New System.Drawing.Size(415, 66)
        Me.GbNumeracion.TabIndex = 4
        Me.GbNumeracion.TabStop = False
        Me.GbNumeracion.Text = "Numeración"
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnProcesar.Location = New System.Drawing.Point(315, 31)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(94, 25)
        Me.btnProcesar.TabIndex = 6
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'txtNoFinal
        '
        Me.txtNoFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoFinal.Enabled = False
        Me.txtNoFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNoFinal.Location = New System.Drawing.Point(209, 33)
        Me.txtNoFinal.Name = "txtNoFinal"
        Me.txtNoFinal.ReadOnly = True
        Me.txtNoFinal.Size = New System.Drawing.Size(100, 20)
        Me.txtNoFinal.TabIndex = 235
        Me.txtNoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(206, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 236
        Me.Label11.Text = "No. Final"
        '
        'txtNoInicial
        '
        Me.txtNoInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoInicial.Enabled = False
        Me.txtNoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNoInicial.Location = New System.Drawing.Point(103, 33)
        Me.txtNoInicial.Name = "txtNoInicial"
        Me.txtNoInicial.ReadOnly = True
        Me.txtNoInicial.Size = New System.Drawing.Size(100, 20)
        Me.txtNoInicial.TabIndex = 233
        Me.txtNoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(99, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 234
        Me.Label10.Text = "No. Inicial"
        '
        'txtCantidad
        '
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCantidad.Location = New System.Drawing.Point(6, 33)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(91, 20)
        Me.txtCantidad.TabIndex = 5
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(6, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 230
        Me.Label7.Text = "Cantidad"
        '
        'DgvRecibos
        '
        Me.DgvRecibos.AllowUserToAddRows = False
        Me.DgvRecibos.AllowUserToDeleteRows = False
        Me.DgvRecibos.AllowUserToResizeColumns = False
        Me.DgvRecibos.AllowUserToResizeRows = False
        Me.DgvRecibos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DgvRecibos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvRecibos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvRecibos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvRecibos.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvRecibos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvRecibos.Location = New System.Drawing.Point(3, 16)
        Me.DgvRecibos.MultiSelect = False
        Me.DgvRecibos.Name = "DgvRecibos"
        Me.DgvRecibos.ReadOnly = True
        Me.DgvRecibos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRecibos.Size = New System.Drawing.Size(701, 180)
        Me.DgvRecibos.TabIndex = 216
        '
        'txtMontoEntrega
        '
        Me.txtMontoEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMontoEntrega.Enabled = False
        Me.txtMontoEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMontoEntrega.Location = New System.Drawing.Point(127, 16)
        Me.txtMontoEntrega.Name = "txtMontoEntrega"
        Me.txtMontoEntrega.ReadOnly = True
        Me.txtMontoEntrega.Size = New System.Drawing.Size(157, 23)
        Me.txtMontoEntrega.TabIndex = 229
        Me.txtMontoEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(7, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 15)
        Me.Label12.TabIndex = 230
        Me.Label12.Text = "Monto de la Entrega"
        '
        'GbComision
        '
        Me.GbComision.Controls.Add(Me.txtComision)
        Me.GbComision.Controls.Add(Me.Label13)
        Me.GbComision.Controls.Add(Me.txtMontoEntrega)
        Me.GbComision.Controls.Add(Me.Label12)
        Me.GbComision.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbComision.Location = New System.Drawing.Point(7, 570)
        Me.GbComision.Name = "GbComision"
        Me.GbComision.Size = New System.Drawing.Size(573, 45)
        Me.GbComision.TabIndex = 231
        Me.GbComision.TabStop = False
        Me.GbComision.Text = "Comisiones"
        '
        'txtComision
        '
        Me.txtComision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComision.Enabled = False
        Me.txtComision.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtComision.Location = New System.Drawing.Point(407, 16)
        Me.txtComision.Name = "txtComision"
        Me.txtComision.ReadOnly = True
        Me.txtComision.Size = New System.Drawing.Size(157, 23)
        Me.txtComision.TabIndex = 231
        Me.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(290, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 15)
        Me.Label13.TabIndex = 232
        Me.Label13.Text = "Comisión Generada"
        '
        'GbDgv
        '
        Me.GbDgv.Controls.Add(Me.DgvRecibos)
        Me.GbDgv.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GbDgv.Location = New System.Drawing.Point(7, 338)
        Me.GbDgv.Name = "GbDgv"
        Me.GbDgv.Size = New System.Drawing.Size(707, 199)
        Me.GbDgv.TabIndex = 232
        Me.GbDgv.TabStop = False
        Me.GbDgv.Text = "Recibos"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtFechaUltEntrega)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.txtCantRestante)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox6.Location = New System.Drawing.Point(429, 201)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(286, 71)
        Me.GroupBox6.TabIndex = 266
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Información del Cobrador"
        '
        'txtFechaUltEntrega
        '
        Me.txtFechaUltEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaUltEntrega.Enabled = False
        Me.txtFechaUltEntrega.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFechaUltEntrega.Location = New System.Drawing.Point(109, 39)
        Me.txtFechaUltEntrega.Name = "txtFechaUltEntrega"
        Me.txtFechaUltEntrega.ReadOnly = True
        Me.txtFechaUltEntrega.Size = New System.Drawing.Size(140, 20)
        Me.txtFechaUltEntrega.TabIndex = 263
        Me.txtFechaUltEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label14.Location = New System.Drawing.Point(106, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 264
        Me.Label14.Text = "Ultima Entrega"
        '
        'txtCantRestante
        '
        Me.txtCantRestante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantRestante.Enabled = False
        Me.txtCantRestante.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCantRestante.Location = New System.Drawing.Point(9, 39)
        Me.txtCantRestante.Name = "txtCantRestante"
        Me.txtCantRestante.ReadOnly = True
        Me.txtCantRestante.Size = New System.Drawing.Size(94, 20)
        Me.txtCantRestante.TabIndex = 261
        Me.txtCantRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label15.Location = New System.Drawing.Point(7, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 262
        Me.Label15.Text = "Cant. Rest."
        '
        'txtNota
        '
        Me.txtNota.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNota.Location = New System.Drawing.Point(52, 543)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(528, 23)
        Me.txtNota.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(10, 546)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 15)
        Me.Label9.TabIndex = 268
        Me.Label9.Text = "Nota"
        '
        'chkCerrarEntrega
        '
        Me.chkCerrarEntrega.AutoSize = True
        Me.chkCerrarEntrega.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkCerrarEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkCerrarEntrega.Location = New System.Drawing.Point(15, 19)
        Me.chkCerrarEntrega.Name = "chkCerrarEntrega"
        Me.chkCerrarEntrega.Size = New System.Drawing.Size(107, 20)
        Me.chkCerrarEntrega.TabIndex = 12
        Me.chkCerrarEntrega.Text = "Cerrar Entrega"
        Me.chkCerrarEntrega.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkResumir)
        Me.GroupBox1.Controls.Add(Me.chkCerrarEntrega)
        Me.GroupBox1.Location = New System.Drawing.Point(586, 536)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(129, 79)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.Location = New System.Drawing.Point(15, 45)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(75, 20)
        Me.chkResumir.TabIndex = 13
        Me.chkResumir.Text = "Resumir"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(7, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 271
        Me.PicBoxLogo.TabStop = False
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(290, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 330
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
        Me.BarraEstado.Location = New System.Drawing.Point(0, 622)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(724, 25)
        Me.BarraEstado.TabIndex = 415
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtGranTotal)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtCambios)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtEfectivo)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 274)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(707, 60)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Totales"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label19.Location = New System.Drawing.Point(380, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 245
        Me.Label19.Text = "Gran total"
        '
        'txtGranTotal
        '
        Me.txtGranTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGranTotal.EnterMoveNextControl = True
        Me.txtGranTotal.Location = New System.Drawing.Point(383, 33)
        Me.txtGranTotal.Name = "txtGranTotal"
        Me.txtGranTotal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtGranTotal.Properties.Appearance.Options.UseFont = True
        Me.txtGranTotal.Properties.Appearance.Options.UseTextOptions = True
        Me.txtGranTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtGranTotal.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.txtGranTotal.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtGranTotal.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.txtGranTotal.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtGranTotal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtGranTotal.Properties.DisplayFormat.FormatString = "c"
        Me.txtGranTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtGranTotal.Properties.EditFormat.FormatString = "c"
        Me.txtGranTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtGranTotal.Properties.Mask.EditMask = "c"
        Me.txtGranTotal.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtGranTotal.Properties.NullText = "0"
        Me.txtGranTotal.Properties.NullValuePrompt = "0"
        Me.txtGranTotal.Properties.Precision = 2
        Me.txtGranTotal.Properties.ReadOnly = True
        Me.txtGranTotal.Properties.ValidateOnEnterKey = True
        Me.txtGranTotal.Size = New System.Drawing.Size(150, 20)
        Me.txtGranTotal.TabIndex = 244
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label18.Location = New System.Drawing.Point(362, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(15, 13)
        Me.Label18.TabIndex = 243
        Me.Label18.Text = "="
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label17.Location = New System.Drawing.Point(178, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(15, 13)
        Me.Label17.TabIndex = 242
        Me.Label17.Text = "+"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label16.Location = New System.Drawing.Point(203, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 241
        Me.Label16.Text = "Cambios"
        '
        'txtCambios
        '
        Me.txtCambios.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCambios.EnterMoveNextControl = True
        Me.txtCambios.Location = New System.Drawing.Point(206, 33)
        Me.txtCambios.Name = "txtCambios"
        Me.txtCambios.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCambios.Properties.Appearance.Options.UseFont = True
        Me.txtCambios.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCambios.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCambios.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.txtCambios.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCambios.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.txtCambios.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCambios.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCambios.Properties.DisplayFormat.FormatString = "c"
        Me.txtCambios.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCambios.Properties.EditFormat.FormatString = "c"
        Me.txtCambios.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCambios.Properties.Mask.EditMask = "c"
        Me.txtCambios.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCambios.Properties.NullText = "0"
        Me.txtCambios.Properties.NullValuePrompt = "0"
        Me.txtCambios.Properties.Precision = 2
        Me.txtCambios.Properties.ValidateOnEnterKey = True
        Me.txtCambios.Size = New System.Drawing.Size(150, 20)
        Me.txtCambios.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(9, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Efectivo"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEfectivo.EnterMoveNextControl = True
        Me.txtEfectivo.Location = New System.Drawing.Point(12, 33)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtEfectivo.Properties.Appearance.Options.UseFont = True
        Me.txtEfectivo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtEfectivo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtEfectivo.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.txtEfectivo.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtEfectivo.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.txtEfectivo.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtEfectivo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtEfectivo.Properties.DisplayFormat.FormatString = "c"
        Me.txtEfectivo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtEfectivo.Properties.EditFormat.FormatString = "c"
        Me.txtEfectivo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtEfectivo.Properties.Mask.EditMask = "c"
        Me.txtEfectivo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtEfectivo.Properties.NullText = "0"
        Me.txtEfectivo.Properties.NullValuePrompt = "0"
        Me.txtEfectivo.Properties.Precision = 2
        Me.txtEfectivo.Properties.ValidateOnEnterKey = True
        Me.txtEfectivo.Size = New System.Drawing.Size(150, 20)
        Me.txtEfectivo.TabIndex = 8
        '
        'frm_entrega_cobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 647)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNota)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GbDgv)
        Me.Controls.Add(Me.GbComision)
        Me.Controls.Add(Me.GbNumeracion)
        Me.Controls.Add(Me.GbDatosEntrega)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.MenuBar)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.chkNulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_entrega_cobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "204"
        Me.Text = "Entrega de cobros"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.GbDatosEntrega.ResumeLayout(False)
        Me.GbDatosEntrega.PerformLayout()
        Me.GbNumeracion.ResumeLayout(False)
        Me.GbNumeracion.PerformLayout()
        CType(Me.DgvRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbComision.ResumeLayout(False)
        Me.GbComision.PerformLayout()
        Me.GbDgv.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtGranTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCambios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEfectivo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDEntrega As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents CbxCobrador As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents GbDatosEntrega As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNoEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GbNumeracion As System.Windows.Forms.GroupBox
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents txtNoFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNoInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DgvRecibos As System.Windows.Forms.DataGridView
    Friend WithEvents txtMontoEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GbComision As System.Windows.Forms.GroupBox
    Friend WithEvents txtComision As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GbDgv As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaUltEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCantRestante As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkCerrarEntrega As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtGranTotal As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCambios As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEfectivo As DevExpress.XtraEditors.CalcEdit
End Class
