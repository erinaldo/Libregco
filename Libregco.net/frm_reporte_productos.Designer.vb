<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_productos))
        Me.txtCodigoArtDesde = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicSalida = New System.Windows.Forms.PictureBox()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIDTipoProducto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigoArtHasta = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarArtDesde = New System.Windows.Forms.Button()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox()
        Me.txtMedida = New System.Windows.Forms.TextBox()
        Me.txtIDMedida = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtIDMarca = New System.Windows.Forms.TextBox()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtIDAlmacen = New System.Windows.Forms.TextBox()
        Me.txtTipoItbis = New System.Windows.Forms.TextBox()
        Me.txtIDTipoItbis = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbOpciones = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbxTipoOrden = New System.Windows.Forms.ComboBox()
        Me.CbxOrden = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.txtSubCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDSubCategoria = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDCategoria = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.chkBloqueoCredito = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkRevisado = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.chkPreAlertar = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbxHabSeries = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbxDescontinuado = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbxVenderCosto = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbxDevolucion = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbxPromocion = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtInventarioCant = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.cbxInventario = New System.Windows.Forms.ComboBox()
        Me.CbxExistencia = New System.Windows.Forms.ComboBox()
        Me.txtGarantia = New System.Windows.Forms.TextBox()
        Me.txtIDGarantia = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.btnGarantia = New System.Windows.Forms.Button()
        Me.btnCategoria = New System.Windows.Forms.Button()
        Me.btnSubCategoria = New System.Windows.Forms.Button()
        Me.btnTipoItbis = New System.Windows.Forms.Button()
        Me.btnAlmacen = New System.Windows.Forms.Button()
        Me.btnSuplidor = New System.Windows.Forms.Button()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.btnMedida = New System.Windows.Forms.Button()
        Me.btnDepartamento = New System.Windows.Forms.Button()
        Me.btnBuscarTipoProducto = New System.Windows.Forms.Button()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.btnparentezo = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtParentezco = New System.Windows.Forms.TextBox()
        Me.txtIDParental = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GbCondiciones.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodigoArtDesde
        '
        Me.txtCodigoArtDesde.Location = New System.Drawing.Point(72, 19)
        Me.txtCodigoArtDesde.Name = "txtCodigoArtDesde"
        Me.txtCodigoArtDesde.Size = New System.Drawing.Size(115, 23)
        Me.txtCodigoArtDesde.TabIndex = 0
        Me.txtCodigoArtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Marca"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Medida"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 15)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Departamento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Suplidor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Almacén"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 296)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Tipo de Itbis"
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
        Me.GroupBox1.TabIndex = 44
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
        Me.rdbExcel.TabIndex = 3
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
        Me.rdbPDF.TabIndex = 2
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
        Me.rdbImpresora.TabIndex = 1
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
        Me.rdbPresentacion.TabIndex = 0
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.Enabled = False
        Me.txtTipoProducto.Location = New System.Drawing.Point(236, 60)
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.ReadOnly = True
        Me.txtTipoProducto.Size = New System.Drawing.Size(287, 23)
        Me.txtTipoProducto.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 15)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Tipo de Producto"
        '
        'txtIDTipoProducto
        '
        Me.txtIDTipoProducto.Location = New System.Drawing.Point(113, 60)
        Me.txtIDTipoProducto.Name = "txtIDTipoProducto"
        Me.txtIDTipoProducto.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoProducto.TabIndex = 45
        Me.txtIDTipoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 15)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Desde"
        '
        'txtCodigoArtHasta
        '
        Me.txtCodigoArtHasta.Location = New System.Drawing.Point(235, 19)
        Me.txtCodigoArtHasta.Name = "txtCodigoArtHasta"
        Me.txtCodigoArtHasta.Size = New System.Drawing.Size(115, 23)
        Me.txtCodigoArtHasta.TabIndex = 50
        Me.txtCodigoArtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(192, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 15)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Hasta"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoArtDesde)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btnBuscarArtDesde)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCodigoArtHasta)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 49)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Código"
        '
        'btnBuscarArtDesde
        '
        Me.btnBuscarArtDesde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarArtDesde.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarArtDesde.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarArtDesde.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarArtDesde.Location = New System.Drawing.Point(50, 19)
        Me.btnBuscarArtDesde.Name = "btnBuscarArtDesde"
        Me.btnBuscarArtDesde.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarArtDesde.TabIndex = 19
        Me.btnBuscarArtDesde.UseVisualStyleBackColor = True
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Location = New System.Drawing.Point(236, 89)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(287, 23)
        Me.txtDepartamento.TabIndex = 56
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.Location = New System.Drawing.Point(113, 89)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.Size = New System.Drawing.Size(102, 23)
        Me.txtIDDepartamento.TabIndex = 54
        Me.txtIDDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMedida
        '
        Me.txtMedida.Enabled = False
        Me.txtMedida.Location = New System.Drawing.Point(236, 176)
        Me.txtMedida.Name = "txtMedida"
        Me.txtMedida.ReadOnly = True
        Me.txtMedida.Size = New System.Drawing.Size(287, 23)
        Me.txtMedida.TabIndex = 60
        '
        'txtIDMedida
        '
        Me.txtIDMedida.Location = New System.Drawing.Point(113, 176)
        Me.txtIDMedida.Name = "txtIDMedida"
        Me.txtIDMedida.Size = New System.Drawing.Size(102, 23)
        Me.txtIDMedida.TabIndex = 58
        Me.txtIDMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMarca
        '
        Me.txtMarca.Enabled = False
        Me.txtMarca.Location = New System.Drawing.Point(236, 205)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(287, 23)
        Me.txtMarca.TabIndex = 64
        '
        'txtIDMarca
        '
        Me.txtIDMarca.Location = New System.Drawing.Point(113, 205)
        Me.txtIDMarca.Name = "txtIDMarca"
        Me.txtIDMarca.Size = New System.Drawing.Size(102, 23)
        Me.txtIDMarca.TabIndex = 62
        Me.txtIDMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Enabled = False
        Me.txtSuplidor.Location = New System.Drawing.Point(236, 234)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.ReadOnly = True
        Me.txtSuplidor.Size = New System.Drawing.Size(287, 23)
        Me.txtSuplidor.TabIndex = 68
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Location = New System.Drawing.Point(113, 234)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSuplidor.TabIndex = 66
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Location = New System.Drawing.Point(236, 263)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(287, 23)
        Me.txtAlmacen.TabIndex = 72
        '
        'txtIDAlmacen
        '
        Me.txtIDAlmacen.Location = New System.Drawing.Point(113, 263)
        Me.txtIDAlmacen.Name = "txtIDAlmacen"
        Me.txtIDAlmacen.Size = New System.Drawing.Size(102, 23)
        Me.txtIDAlmacen.TabIndex = 70
        Me.txtIDAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTipoItbis
        '
        Me.txtTipoItbis.Enabled = False
        Me.txtTipoItbis.Location = New System.Drawing.Point(236, 292)
        Me.txtTipoItbis.Name = "txtTipoItbis"
        Me.txtTipoItbis.ReadOnly = True
        Me.txtTipoItbis.Size = New System.Drawing.Size(287, 23)
        Me.txtTipoItbis.TabIndex = 75
        '
        'txtIDTipoItbis
        '
        Me.txtIDTipoItbis.Location = New System.Drawing.Point(113, 292)
        Me.txtIDTipoItbis.Name = "txtIDTipoItbis"
        Me.txtIDTipoItbis.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoItbis.TabIndex = 73
        Me.txtIDTipoItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip2)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 458)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 76
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip2.Location = New System.Drawing.Point(467, 5)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(260, 95)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
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
        Me.GbOpciones.Controls.Add(Me.Label23)
        Me.GbOpciones.Controls.Add(Me.cbxTipoOrden)
        Me.GbOpciones.Controls.Add(Me.CbxOrden)
        Me.GbOpciones.Controls.Add(Me.Label13)
        Me.GbOpciones.Controls.Add(Me.CbxFormato)
        Me.GbOpciones.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbOpciones.Location = New System.Drawing.Point(200, 3)
        Me.GbOpciones.Name = "GbOpciones"
        Me.GbOpciones.Size = New System.Drawing.Size(264, 96)
        Me.GbOpciones.TabIndex = 85
        Me.GbOpciones.TabStop = False
        Me.GbOpciones.Text = "Formato"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(130, 47)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 15)
        Me.Label23.TabIndex = 50
        Me.Label23.Text = "Orden"
        '
        'cbxTipoOrden
        '
        Me.cbxTipoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoOrden.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoOrden.FormattingEnabled = True
        Me.cbxTipoOrden.Items.AddRange(New Object() {"Ascendente", "Descendente"})
        Me.cbxTipoOrden.Location = New System.Drawing.Point(133, 65)
        Me.cbxTipoOrden.Name = "cbxTipoOrden"
        Me.cbxTipoOrden.Size = New System.Drawing.Size(120, 23)
        Me.cbxTipoOrden.TabIndex = 49
        '
        'CbxOrden
        '
        Me.CbxOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxOrden.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxOrden.FormattingEnabled = True
        Me.CbxOrden.Location = New System.Drawing.Point(6, 65)
        Me.CbxOrden.Name = "CbxOrden"
        Me.CbxOrden.Size = New System.Drawing.Size(121, 23)
        Me.CbxOrden.TabIndex = 46
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 15)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Campo"
        '
        'CbxFormato
        '
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(6, 19)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(247, 23)
        Me.CbxFormato.TabIndex = 45
        '
        'txtSubCategoria
        '
        Me.txtSubCategoria.Enabled = False
        Me.txtSubCategoria.Location = New System.Drawing.Point(236, 147)
        Me.txtSubCategoria.Name = "txtSubCategoria"
        Me.txtSubCategoria.ReadOnly = True
        Me.txtSubCategoria.Size = New System.Drawing.Size(287, 23)
        Me.txtSubCategoria.TabIndex = 80
        '
        'txtIDSubCategoria
        '
        Me.txtIDSubCategoria.Location = New System.Drawing.Point(113, 147)
        Me.txtIDSubCategoria.Name = "txtIDSubCategoria"
        Me.txtIDSubCategoria.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSubCategoria.TabIndex = 78
        Me.txtIDSubCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Sub-Categoría"
        '
        'txtCategoria
        '
        Me.txtCategoria.Enabled = False
        Me.txtCategoria.Location = New System.Drawing.Point(236, 118)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(287, 23)
        Me.txtCategoria.TabIndex = 84
        '
        'txtIDCategoria
        '
        Me.txtIDCategoria.Location = New System.Drawing.Point(113, 118)
        Me.txtIDCategoria.Name = "txtIDCategoria"
        Me.txtIDCategoria.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCategoria.TabIndex = 82
        Me.txtIDCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "Categoría"
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Controls.Add(Me.Label27)
        Me.GbCondiciones.Controls.Add(Me.chkBloqueoCredito)
        Me.GbCondiciones.Controls.Add(Me.Label26)
        Me.GbCondiciones.Controls.Add(Me.chkRevisado)
        Me.GbCondiciones.Controls.Add(Me.Label25)
        Me.GbCondiciones.Controls.Add(Me.chkPreAlertar)
        Me.GbCondiciones.Controls.Add(Me.Label24)
        Me.GbCondiciones.Controls.Add(Me.cbxHabSeries)
        Me.GbCondiciones.Controls.Add(Me.Label22)
        Me.GbCondiciones.Controls.Add(Me.cbxDescontinuado)
        Me.GbCondiciones.Controls.Add(Me.Label21)
        Me.GbCondiciones.Controls.Add(Me.cbxVenderCosto)
        Me.GbCondiciones.Controls.Add(Me.Label20)
        Me.GbCondiciones.Controls.Add(Me.cbxDevolucion)
        Me.GbCondiciones.Controls.Add(Me.Label17)
        Me.GbCondiciones.Controls.Add(Me.cbxPromocion)
        Me.GbCondiciones.Controls.Add(Me.Label12)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Controls.Add(Me.Label19)
        Me.GbCondiciones.Controls.Add(Me.txtInventarioCant)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.Label15)
        Me.GbCondiciones.Controls.Add(Me.Label18)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Controls.Add(Me.cbxInventario)
        Me.GbCondiciones.Controls.Add(Me.CbxExistencia)
        Me.GbCondiciones.Location = New System.Drawing.Point(530, 5)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(189, 447)
        Me.GbCondiciones.TabIndex = 85
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(7, 251)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(90, 32)
        Me.Label27.TabIndex = 114
        Me.Label27.Text = "Bloqueo a crédito"
        '
        'chkBloqueoCredito
        '
        Me.chkBloqueoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chkBloqueoCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBloqueoCredito.FormattingEnabled = True
        Me.chkBloqueoCredito.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.chkBloqueoCredito.Location = New System.Drawing.Point(103, 255)
        Me.chkBloqueoCredito.Name = "chkBloqueoCredito"
        Me.chkBloqueoCredito.Size = New System.Drawing.Size(79, 23)
        Me.chkBloqueoCredito.TabIndex = 113
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(7, 229)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(54, 15)
        Me.Label26.TabIndex = 112
        Me.Label26.Text = "Revisado"
        '
        'chkRevisado
        '
        Me.chkRevisado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chkRevisado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRevisado.FormattingEnabled = True
        Me.chkRevisado.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.chkRevisado.Location = New System.Drawing.Point(103, 226)
        Me.chkRevisado.Name = "chkRevisado"
        Me.chkRevisado.Size = New System.Drawing.Size(79, 23)
        Me.chkRevisado.TabIndex = 111
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 200)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 15)
        Me.Label25.TabIndex = 110
        Me.Label25.Text = "Prealertas"
        '
        'chkPreAlertar
        '
        Me.chkPreAlertar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chkPreAlertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPreAlertar.FormattingEnabled = True
        Me.chkPreAlertar.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.chkPreAlertar.Location = New System.Drawing.Point(103, 197)
        Me.chkPreAlertar.Name = "chkPreAlertar"
        Me.chkPreAlertar.Size = New System.Drawing.Size(79, 23)
        Me.chkPreAlertar.TabIndex = 109
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 171)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 15)
        Me.Label24.TabIndex = 108
        Me.Label24.Text = "Series"
        '
        'cbxHabSeries
        '
        Me.cbxHabSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxHabSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxHabSeries.FormattingEnabled = True
        Me.cbxHabSeries.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxHabSeries.Location = New System.Drawing.Point(103, 168)
        Me.cbxHabSeries.Name = "cbxHabSeries"
        Me.cbxHabSeries.Size = New System.Drawing.Size(79, 23)
        Me.cbxHabSeries.TabIndex = 107
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 142)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 15)
        Me.Label22.TabIndex = 106
        Me.Label22.Text = "Descontinuado"
        '
        'cbxDescontinuado
        '
        Me.cbxDescontinuado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDescontinuado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDescontinuado.FormattingEnabled = True
        Me.cbxDescontinuado.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxDescontinuado.Location = New System.Drawing.Point(103, 139)
        Me.cbxDescontinuado.Name = "cbxDescontinuado"
        Me.cbxDescontinuado.Size = New System.Drawing.Size(79, 23)
        Me.cbxDescontinuado.TabIndex = 105
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 113)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(87, 15)
        Me.Label21.TabIndex = 104
        Me.Label21.Text = "Vender al costo"
        '
        'cbxVenderCosto
        '
        Me.cbxVenderCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVenderCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxVenderCosto.FormattingEnabled = True
        Me.cbxVenderCosto.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxVenderCosto.Location = New System.Drawing.Point(103, 110)
        Me.cbxVenderCosto.Name = "cbxVenderCosto"
        Me.cbxVenderCosto.Size = New System.Drawing.Size(79, 23)
        Me.cbxVenderCosto.TabIndex = 103
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(7, 77)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 32)
        Me.Label20.TabIndex = 102
        Me.Label20.Text = "Devolucion permitida"
        '
        'cbxDevolucion
        '
        Me.cbxDevolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDevolucion.FormattingEnabled = True
        Me.cbxDevolucion.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxDevolucion.Location = New System.Drawing.Point(103, 81)
        Me.cbxDevolucion.Name = "cbxDevolucion"
        Me.cbxDevolucion.Size = New System.Drawing.Size(79, 23)
        Me.cbxDevolucion.TabIndex = 101
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 15)
        Me.Label17.TabIndex = 100
        Me.Label17.Text = "En promoción"
        '
        'cbxPromocion
        '
        Me.cbxPromocion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPromocion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPromocion.FormattingEnabled = True
        Me.cbxPromocion.Items.AddRange(New Object() {"Ambos", "Sí", "No"})
        Me.cbxPromocion.Location = New System.Drawing.Point(103, 52)
        Me.cbxPromocion.Name = "cbxPromocion"
        Me.cbxPromocion.Size = New System.Drawing.Size(79, 23)
        Me.cbxPromocion.TabIndex = 99
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.Location = New System.Drawing.Point(3, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(184, 2)
        Me.Label12.TabIndex = 98
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(10, 15)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(119, 19)
        Me.chkResumir.TabIndex = 97
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(81, 421)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 15)
        Me.Label19.TabIndex = 96
        Me.Label19.Text = "que"
        '
        'txtInventarioCant
        '
        Me.txtInventarioCant.Enabled = False
        Me.txtInventarioCant.Location = New System.Drawing.Point(110, 418)
        Me.txtInventarioCant.Name = "txtInventarioCant"
        Me.txtInventarioCant.Size = New System.Drawing.Size(72, 23)
        Me.txtInventarioCant.TabIndex = 95
        Me.txtInventarioCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 285)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 15)
        Me.Label16.TabIndex = 92
        Me.Label16.Text = "Estado"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 329)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 15)
        Me.Label15.TabIndex = 90
        Me.Label15.Text = "Existencia"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 373)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 15)
        Me.Label18.TabIndex = 94
        Me.Label18.Text = "Inventario"
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Todos", "Sólo Activos", "Nulos"})
        Me.cbxEstado.Location = New System.Drawing.Point(10, 303)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(172, 23)
        Me.cbxEstado.TabIndex = 91
        '
        'cbxInventario
        '
        Me.cbxInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxInventario.FormattingEnabled = True
        Me.cbxInventario.Items.AddRange(New Object() {"Todos", "Menor o Igual", "Menor", "Mayor", "Mayor o Igual", "Diferente", "Igual"})
        Me.cbxInventario.Location = New System.Drawing.Point(10, 391)
        Me.cbxInventario.Name = "cbxInventario"
        Me.cbxInventario.Size = New System.Drawing.Size(172, 23)
        Me.cbxInventario.TabIndex = 93
        '
        'CbxExistencia
        '
        Me.CbxExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxExistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxExistencia.FormattingEnabled = True
        Me.CbxExistencia.Items.AddRange(New Object() {"Todas", "Por debajo del mínimo", "Por encima del máximo"})
        Me.CbxExistencia.Location = New System.Drawing.Point(10, 347)
        Me.CbxExistencia.Name = "CbxExistencia"
        Me.CbxExistencia.Size = New System.Drawing.Size(172, 23)
        Me.CbxExistencia.TabIndex = 6
        '
        'txtGarantia
        '
        Me.txtGarantia.Enabled = False
        Me.txtGarantia.Location = New System.Drawing.Point(236, 321)
        Me.txtGarantia.Name = "txtGarantia"
        Me.txtGarantia.ReadOnly = True
        Me.txtGarantia.Size = New System.Drawing.Size(287, 23)
        Me.txtGarantia.TabIndex = 89
        '
        'txtIDGarantia
        '
        Me.txtIDGarantia.Location = New System.Drawing.Point(113, 321)
        Me.txtIDGarantia.Name = "txtIDGarantia"
        Me.txtIDGarantia.Size = New System.Drawing.Size(102, 23)
        Me.txtIDGarantia.TabIndex = 87
        Me.txtIDGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 324)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 15)
        Me.Label14.TabIndex = 86
        Me.Label14.Text = "Garantía"
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'btnGarantia
        '
        Me.btnGarantia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGarantia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGarantia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGarantia.Image = CType(resources.GetObject("btnGarantia.Image"), System.Drawing.Image)
        Me.btnGarantia.Location = New System.Drawing.Point(214, 321)
        Me.btnGarantia.Name = "btnGarantia"
        Me.btnGarantia.Size = New System.Drawing.Size(23, 23)
        Me.btnGarantia.TabIndex = 88
        Me.btnGarantia.UseVisualStyleBackColor = True
        '
        'btnCategoria
        '
        Me.btnCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCategoria.Image = CType(resources.GetObject("btnCategoria.Image"), System.Drawing.Image)
        Me.btnCategoria.Location = New System.Drawing.Point(214, 118)
        Me.btnCategoria.Name = "btnCategoria"
        Me.btnCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnCategoria.TabIndex = 83
        Me.btnCategoria.UseVisualStyleBackColor = True
        '
        'btnSubCategoria
        '
        Me.btnSubCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSubCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSubCategoria.Image = CType(resources.GetObject("btnSubCategoria.Image"), System.Drawing.Image)
        Me.btnSubCategoria.Location = New System.Drawing.Point(214, 147)
        Me.btnSubCategoria.Name = "btnSubCategoria"
        Me.btnSubCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnSubCategoria.TabIndex = 79
        Me.btnSubCategoria.UseVisualStyleBackColor = True
        '
        'btnTipoItbis
        '
        Me.btnTipoItbis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoItbis.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoItbis.Image = CType(resources.GetObject("btnTipoItbis.Image"), System.Drawing.Image)
        Me.btnTipoItbis.Location = New System.Drawing.Point(214, 292)
        Me.btnTipoItbis.Name = "btnTipoItbis"
        Me.btnTipoItbis.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoItbis.TabIndex = 74
        Me.btnTipoItbis.UseVisualStyleBackColor = True
        '
        'btnAlmacen
        '
        Me.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAlmacen.Image = CType(resources.GetObject("btnAlmacen.Image"), System.Drawing.Image)
        Me.btnAlmacen.Location = New System.Drawing.Point(214, 263)
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Size = New System.Drawing.Size(23, 23)
        Me.btnAlmacen.TabIndex = 71
        Me.btnAlmacen.UseVisualStyleBackColor = True
        '
        'btnSuplidor
        '
        Me.btnSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSuplidor.Image = CType(resources.GetObject("btnSuplidor.Image"), System.Drawing.Image)
        Me.btnSuplidor.Location = New System.Drawing.Point(214, 234)
        Me.btnSuplidor.Name = "btnSuplidor"
        Me.btnSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnSuplidor.TabIndex = 67
        Me.btnSuplidor.UseVisualStyleBackColor = True
        '
        'btnMarca
        '
        Me.btnMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMarca.Image = CType(resources.GetObject("btnMarca.Image"), System.Drawing.Image)
        Me.btnMarca.Location = New System.Drawing.Point(214, 205)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(23, 23)
        Me.btnMarca.TabIndex = 63
        Me.btnMarca.UseVisualStyleBackColor = True
        '
        'btnMedida
        '
        Me.btnMedida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMedida.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMedida.Image = CType(resources.GetObject("btnMedida.Image"), System.Drawing.Image)
        Me.btnMedida.Location = New System.Drawing.Point(214, 176)
        Me.btnMedida.Name = "btnMedida"
        Me.btnMedida.Size = New System.Drawing.Size(23, 23)
        Me.btnMedida.TabIndex = 59
        Me.btnMedida.UseVisualStyleBackColor = True
        '
        'btnDepartamento
        '
        Me.btnDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDepartamento.Image = CType(resources.GetObject("btnDepartamento.Image"), System.Drawing.Image)
        Me.btnDepartamento.Location = New System.Drawing.Point(214, 89)
        Me.btnDepartamento.Name = "btnDepartamento"
        Me.btnDepartamento.Size = New System.Drawing.Size(23, 23)
        Me.btnDepartamento.TabIndex = 55
        Me.btnDepartamento.UseVisualStyleBackColor = True
        '
        'btnBuscarTipoProducto
        '
        Me.btnBuscarTipoProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTipoProducto.Image = CType(resources.GetObject("btnBuscarTipoProducto.Image"), System.Drawing.Image)
        Me.btnBuscarTipoProducto.Location = New System.Drawing.Point(214, 60)
        Me.btnBuscarTipoProducto.Name = "btnBuscarTipoProducto"
        Me.btnBuscarTipoProducto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoProducto.TabIndex = 47
        Me.btnBuscarTipoProducto.UseVisualStyleBackColor = True
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 566)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(725, 25)
        Me.BarraEstado.TabIndex = 253
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
        'btnparentezo
        '
        Me.btnparentezo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnparentezo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnparentezo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnparentezo.Image = CType(resources.GetObject("btnparentezo.Image"), System.Drawing.Image)
        Me.btnparentezo.Location = New System.Drawing.Point(214, 350)
        Me.btnparentezo.Name = "btnparentezo"
        Me.btnparentezo.Size = New System.Drawing.Size(23, 23)
        Me.btnparentezo.TabIndex = 256
        Me.btnparentezo.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(10, 353)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(50, 15)
        Me.Label28.TabIndex = 254
        Me.Label28.Text = "Parental"
        '
        'txtParentezco
        '
        Me.txtParentezco.Enabled = False
        Me.txtParentezco.Location = New System.Drawing.Point(236, 350)
        Me.txtParentezco.Name = "txtParentezco"
        Me.txtParentezco.ReadOnly = True
        Me.txtParentezco.Size = New System.Drawing.Size(287, 23)
        Me.txtParentezco.TabIndex = 257
        '
        'txtIDParental
        '
        Me.txtIDParental.Location = New System.Drawing.Point(113, 350)
        Me.txtIDParental.Name = "txtIDParental"
        Me.txtIDParental.Size = New System.Drawing.Size(102, 23)
        Me.txtIDParental.TabIndex = 255
        Me.txtIDParental.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_reporte_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 591)
        Me.Controls.Add(Me.btnparentezo)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtParentezco)
        Me.Controls.Add(Me.txtIDParental)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.btnGarantia)
        Me.Controls.Add(Me.btnCategoria)
        Me.Controls.Add(Me.btnSubCategoria)
        Me.Controls.Add(Me.btnTipoItbis)
        Me.Controls.Add(Me.btnAlmacen)
        Me.Controls.Add(Me.btnSuplidor)
        Me.Controls.Add(Me.btnMarca)
        Me.Controls.Add(Me.btnMedida)
        Me.Controls.Add(Me.btnDepartamento)
        Me.Controls.Add(Me.btnBuscarTipoProducto)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGarantia)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtSubCategoria)
        Me.Controls.Add(Me.txtTipoItbis)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.txtSuplidor)
        Me.Controls.Add(Me.txtMarca)
        Me.Controls.Add(Me.txtMedida)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.txtTipoProducto)
        Me.Controls.Add(Me.txtIDGarantia)
        Me.Controls.Add(Me.txtIDCategoria)
        Me.Controls.Add(Me.txtIDSubCategoria)
        Me.Controls.Add(Me.txtIDTipoItbis)
        Me.Controls.Add(Me.txtIDAlmacen)
        Me.Controls.Add(Me.txtIDSuplidor)
        Me.Controls.Add(Me.txtIDMarca)
        Me.Controls.Add(Me.txtIDMedida)
        Me.Controls.Add(Me.txtIDDepartamento)
        Me.Controls.Add(Me.txtIDTipoProducto)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "28"
        Me.Text = "Reportes de productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GbOpciones.ResumeLayout(False)
        Me.GbOpciones.PerformLayout()
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCodigoArtDesde As System.Windows.Forms.TextBox
    Private WithEvents btnBuscarArtDesde As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PicSalida As System.Windows.Forms.PictureBox
    Friend WithEvents rdbExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPresentacion As System.Windows.Forms.RadioButton
    Friend WithEvents txtTipoProducto As System.Windows.Forms.TextBox
    Private WithEvents btnBuscarTipoProducto As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIDTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoArtHasta As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Private WithEvents btnDepartamento As System.Windows.Forms.Button
    Friend WithEvents txtIDDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtMedida As System.Windows.Forms.TextBox
    Private WithEvents btnMedida As System.Windows.Forms.Button
    Friend WithEvents txtIDMedida As System.Windows.Forms.TextBox
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Private WithEvents btnMarca As System.Windows.Forms.Button
    Friend WithEvents txtIDMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtSuplidor As System.Windows.Forms.TextBox
    Private WithEvents btnSuplidor As System.Windows.Forms.Button
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Private WithEvents btnAlmacen As System.Windows.Forms.Button
    Friend WithEvents txtIDAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoItbis As System.Windows.Forms.TextBox
    Private WithEvents btnTipoItbis As System.Windows.Forms.Button
    Friend WithEvents txtIDTipoItbis As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents CbxOrden As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CbxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents txtSubCategoria As System.Windows.Forms.TextBox
    Private WithEvents btnSubCategoria As System.Windows.Forms.Button
    Friend WithEvents txtIDSubCategoria As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCategoria As System.Windows.Forms.TextBox
    Private WithEvents btnCategoria As System.Windows.Forms.Button
    Friend WithEvents txtIDCategoria As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GbCondiciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtGarantia As System.Windows.Forms.TextBox
    Private WithEvents btnGarantia As System.Windows.Forms.Button
    Friend WithEvents txtIDGarantia As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CbxExistencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbxInventario As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtInventarioCant As System.Windows.Forms.TextBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoOrden As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents lblDate As ToolStripLabel
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbxHabSeries As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbxDescontinuado As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbxVenderCosto As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbxDevolucion As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbxPromocion As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chkBloqueoCredito As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkRevisado As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents chkPreAlertar As System.Windows.Forms.ComboBox
    Private WithEvents btnparentezo As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtParentezco As System.Windows.Forms.TextBox
    Friend WithEvents txtIDParental As System.Windows.Forms.TextBox
End Class
