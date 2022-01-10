<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_movimiento_facturas_cxp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_movimiento_facturas_cxp))
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbOpciones = New System.Windows.Forms.GroupBox()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicSalida = New System.Windows.Forms.PictureBox()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.DgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acumulado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNoFactura = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRNC = New System.Windows.Forms.TextBox()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkNoEspecificar = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.BarraEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 616)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1090, 25)
        Me.BarraEstado.TabIndex = 259
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'lblDate
        '
        Me.lblDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(31, 22)
        Me.lblDate.Text = "Date"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 505)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1090, 109)
        Me.Panel1.TabIndex = 258
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnActualizar, Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(749, 4)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(344, 95)
        Me.MenuStrip1.TabIndex = 44
        Me.MenuStrip1.Text = "MenuStrip2"
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = Global.Libregco.My.Resources.Resources.Refresh_x72
        Me.btnActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(84, 91)
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 91)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(84, 91)
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Libregco.My.Resources.Resources.Home_x72
        Me.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(84, 91)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GbOpciones
        '
        Me.GbOpciones.Controls.Add(Me.chkResumir)
        Me.GbOpciones.Controls.Add(Me.CbxFormato)
        Me.GbOpciones.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbOpciones.Location = New System.Drawing.Point(200, 3)
        Me.GbOpciones.Name = "GbOpciones"
        Me.GbOpciones.Size = New System.Drawing.Size(305, 96)
        Me.GbOpciones.TabIndex = 35
        Me.GbOpciones.TabStop = False
        Me.GbOpciones.Text = "Formato"
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(178, 25)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 357
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'CbxFormato
        '
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(6, 50)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(291, 23)
        Me.CbxFormato.TabIndex = 36
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PicSalida)
        Me.GroupBox1.Controls.Add(Me.rdbExcel)
        Me.GroupBox1.Controls.Add(Me.rdbPDF)
        Me.GroupBox1.Controls.Add(Me.rdbImpresora)
        Me.GroupBox1.Controls.Add(Me.rdbPresentacion)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 97)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione el Tipo de Salida"
        '
        'PicSalida
        '
        Me.PicSalida.Location = New System.Drawing.Point(107, 20)
        Me.PicSalida.Name = "PicSalida"
        Me.PicSalida.Size = New System.Drawing.Size(75, 71)
        Me.PicSalida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSalida.TabIndex = 4
        Me.PicSalida.TabStop = False
        '
        'rdbExcel
        '
        Me.rdbExcel.AutoSize = True
        Me.rdbExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbExcel.Location = New System.Drawing.Point(11, 75)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(51, 19)
        Me.rdbExcel.TabIndex = 43
        Me.rdbExcel.Text = "Excel"
        Me.rdbExcel.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPDF.Location = New System.Drawing.Point(11, 55)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 19)
        Me.rdbPDF.TabIndex = 42
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'rdbImpresora
        '
        Me.rdbImpresora.AutoSize = True
        Me.rdbImpresora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbImpresora.Location = New System.Drawing.Point(11, 35)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(78, 19)
        Me.rdbImpresora.TabIndex = 41
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.UseVisualStyleBackColor = True
        '
        'rdbPresentacion
        '
        Me.rdbPresentacion.AutoSize = True
        Me.rdbPresentacion.Checked = True
        Me.rdbPresentacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPresentacion.Location = New System.Drawing.Point(11, 15)
        Me.rdbPresentacion.Name = "rdbPresentacion"
        Me.rdbPresentacion.Size = New System.Drawing.Size(93, 19)
        Me.rdbPresentacion.TabIndex = 40
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'DgvMovimientos
        '
        Me.DgvMovimientos.AllowUserToAddRows = False
        Me.DgvMovimientos.AllowUserToDeleteRows = False
        Me.DgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMovimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Documento, Me.Fecha, Me.Tipo, Me.Credito, Me.Debito, Me.Balance, Me.Acumulado})
        Me.DgvMovimientos.Location = New System.Drawing.Point(0, 123)
        Me.DgvMovimientos.Name = "DgvMovimientos"
        Me.DgvMovimientos.ReadOnly = True
        Me.DgvMovimientos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMovimientos.Size = New System.Drawing.Size(1090, 348)
        Me.DgvMovimientos.TabIndex = 260
        '
        'Documento
        '
        Me.Documento.HeaderText = "Documento"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        Me.Documento.Width = 180
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 160
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 220
        '
        'Credito
        '
        Me.Credito.HeaderText = "Crédito"
        Me.Credito.Name = "Credito"
        Me.Credito.ReadOnly = True
        Me.Credito.Width = 120
        '
        'Debito
        '
        Me.Debito.HeaderText = "Débito"
        Me.Debito.Name = "Debito"
        Me.Debito.ReadOnly = True
        Me.Debito.Width = 120
        '
        'Balance
        '
        Me.Balance.HeaderText = "Bce. Pend."
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        Me.Balance.Width = 120
        '
        'Acumulado
        '
        Me.Acumulado.HeaderText = "Acumulado"
        Me.Acumulado.Name = "Acumulado"
        Me.Acumulado.ReadOnly = True
        Me.Acumulado.Width = 130
        '
        'txtNoFactura
        '
        Me.txtNoFactura.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoFactura.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNoFactura.Location = New System.Drawing.Point(122, 19)
        Me.txtNoFactura.Name = "txtNoFactura"
        Me.txtNoFactura.Size = New System.Drawing.Size(199, 33)
        Me.txtNoFactura.TabIndex = 261
        Me.txtNoFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "No. de Factura"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 263
        Me.Label2.Text = "Suplidor"
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Enabled = False
        Me.txtSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSuplidor.Location = New System.Drawing.Point(213, 19)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.Size = New System.Drawing.Size(497, 23)
        Me.txtSuplidor.TabIndex = 264
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtTelefono)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtRNC)
        Me.GroupBox2.Controls.Add(Me.txtIDSuplidor)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtDireccion)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtSuplidor)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(716, 112)
        Me.GroupBox2.TabIndex = 265
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Suplidor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(241, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 270
        Me.Label5.Text = "Teléfonos"
        '
        'txtTelefono
        '
        Me.txtTelefono.Enabled = False
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelefono.Location = New System.Drawing.Point(305, 77)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(305, 23)
        Me.txtTelefono.TabIndex = 271
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(6, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 268
        Me.Label4.Text = "RNC"
        '
        'txtRNC
        '
        Me.txtRNC.Enabled = False
        Me.txtRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRNC.Location = New System.Drawing.Point(73, 77)
        Me.txtRNC.Name = "txtRNC"
        Me.txtRNC.Size = New System.Drawing.Size(163, 23)
        Me.txtRNC.TabIndex = 269
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Enabled = False
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.Location = New System.Drawing.Point(73, 19)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.Size = New System.Drawing.Size(134, 23)
        Me.txtIDSuplidor.TabIndex = 267
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 265
        Me.Label3.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.Enabled = False
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(73, 48)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(637, 23)
        Me.txtDireccion.TabIndex = 266
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(0, 479)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 272
        Me.Label6.Text = "Comentarios:"
        '
        'txtComentarios
        '
        Me.txtComentarios.Enabled = False
        Me.txtComentarios.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtComentarios.Location = New System.Drawing.Point(81, 476)
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(1000, 23)
        Me.txtComentarios.TabIndex = 273
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(14, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 15)
        Me.Label7.TabIndex = 274
        Me.Label7.Text = "Código de factura"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkNoEspecificar)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtNoFactura)
        Me.GroupBox3.Location = New System.Drawing.Point(730, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(351, 112)
        Me.GroupBox3.TabIndex = 275
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Escriba aquí"
        '
        'chkNoEspecificar
        '
        Me.chkNoEspecificar.AutoSize = True
        Me.chkNoEspecificar.Checked = True
        Me.chkNoEspecificar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoEspecificar.Location = New System.Drawing.Point(243, 54)
        Me.chkNoEspecificar.Name = "chkNoEspecificar"
        Me.chkNoEspecificar.Size = New System.Drawing.Size(101, 19)
        Me.chkNoEspecificar.TabIndex = 261
        Me.chkNoEspecificar.Text = "No especificar"
        Me.chkNoEspecificar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox4.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 56)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(339, 50)
        Me.GroupBox4.TabIndex = 275
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Entre fechas"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(170, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 15)
        Me.Label8.TabIndex = 260
        Me.Label8.Text = "Hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 15)
        Me.Label9.TabIndex = 259
        Me.Label9.Text = "Desde"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(213, 18)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(99, 23)
        Me.dtpFechaFinal.TabIndex = 259
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicial.Location = New System.Drawing.Point(65, 18)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(99, 23)
        Me.dtpFechaInicial.TabIndex = 258
        '
        'frm_movimiento_facturas_cxp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 641)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtComentarios)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DgvMovimientos)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_movimiento_facturas_cxp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "145"
        Me.Text = "Movimiento por facturas"
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GbOpciones.ResumeLayout(False)
        Me.GbOpciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents CbxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PicSalida As System.Windows.Forms.PictureBox
    Friend WithEvents rdbExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPresentacion As System.Windows.Forms.RadioButton
    Friend WithEvents DgvMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents txtNoFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRNC As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acumulado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkNoEspecificar As System.Windows.Forms.CheckBox
End Class
