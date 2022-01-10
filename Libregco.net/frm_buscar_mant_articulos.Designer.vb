<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_buscar_mant_articulos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_buscar_mant_articulos))
        Me.DgvPrecioArticulo = New System.Windows.Forms.DataGridView()
        Me.IDPrecios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCredito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioContado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDMoneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvExistencia = New System.Windows.Forms.DataGridView()
        Me.IDAlmacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Almacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Existencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvArticulos = New System.Windows.Forms.DataGridView()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.BindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImagenes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEspecificaciones = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.btnFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.VistaDinamica = New System.Windows.Forms.ToolStripButton()
        Me.VistaTabla = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblNotaImagen = New System.Windows.Forms.Label()
        Me.PicImagen = New System.Windows.Forms.PictureBox()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabClasico = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TKPropiedades = New DevExpress.XtraEditors.TokenEdit()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.txtIDMarca = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSubcategoria = New System.Windows.Forms.TextBox()
        Me.btnSubcategoria = New System.Windows.Forms.Button()
        Me.txtIDSubCategoria = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.btnCategoria = New System.Windows.Forms.Button()
        Me.txtIDCategoria = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.btnDepartamento = New System.Windows.Forms.Button()
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.btnTipo = New System.Windows.Forms.Button()
        Me.txtIDTipo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.btn_Suplidor = New System.Windows.Forms.Button()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbDirecto = New System.Windows.Forms.RadioButton()
        Me.rdbPredictivo = New System.Windows.Forms.RadioButton()
        Me.TabMenus = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabDinamica = New System.Windows.Forms.TabPage()
        Me.TabArticulos = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.FlowDepartamentos = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.FlowCategorias = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.FlowSubCategoria = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.ListControl1 = New Libregco.ListControl()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvPrecioArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator.SuspendLayout()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClasico.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.TKPropiedades.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabMenus.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabDinamica.SuspendLayout()
        Me.TabArticulos.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvPrecioArticulo
        '
        Me.DgvPrecioArticulo.AllowUserToAddRows = False
        Me.DgvPrecioArticulo.AllowUserToDeleteRows = False
        Me.DgvPrecioArticulo.AllowUserToResizeColumns = False
        Me.DgvPrecioArticulo.AllowUserToResizeRows = False
        Me.DgvPrecioArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgvPrecioArticulo.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvPrecioArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvPrecioArticulo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvPrecioArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPrecioArticulo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDPrecios, Me.Medida, Me.Contenido, Me.PrecioCredito, Me.PrecioContado, Me.Precio3, Me.Precio4, Me.Costo, Me.CostoFinal, Me.IDMoneda})
        Me.DgvPrecioArticulo.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvPrecioArticulo.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvPrecioArticulo.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvPrecioArticulo.Location = New System.Drawing.Point(1, 20)
        Me.DgvPrecioArticulo.MultiSelect = False
        Me.DgvPrecioArticulo.Name = "DgvPrecioArticulo"
        Me.DgvPrecioArticulo.ReadOnly = True
        Me.DgvPrecioArticulo.RowHeadersWidth = 30
        Me.DgvPrecioArticulo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvPrecioArticulo.RowTemplate.Height = 20
        Me.DgvPrecioArticulo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvPrecioArticulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvPrecioArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPrecioArticulo.Size = New System.Drawing.Size(487, 128)
        Me.DgvPrecioArticulo.TabIndex = 2
        '
        'IDPrecios
        '
        Me.IDPrecios.HeaderText = "IDPrecios"
        Me.IDPrecios.Name = "IDPrecios"
        Me.IDPrecios.ReadOnly = True
        Me.IDPrecios.Visible = False
        '
        'Medida
        '
        Me.Medida.HeaderText = "Medida"
        Me.Medida.Name = "Medida"
        Me.Medida.ReadOnly = True
        '
        'Contenido
        '
        Me.Contenido.HeaderText = "Contenido"
        Me.Contenido.Name = "Contenido"
        Me.Contenido.ReadOnly = True
        '
        'PrecioCredito
        '
        Me.PrecioCredito.HeaderText = "Precio crédito"
        Me.PrecioCredito.Name = "PrecioCredito"
        Me.PrecioCredito.ReadOnly = True
        Me.PrecioCredito.Width = 130
        '
        'PrecioContado
        '
        Me.PrecioContado.HeaderText = "Precio contado "
        Me.PrecioContado.Name = "PrecioContado"
        Me.PrecioContado.ReadOnly = True
        Me.PrecioContado.Width = 130
        '
        'Precio3
        '
        Me.Precio3.HeaderText = "Precio3"
        Me.Precio3.Name = "Precio3"
        Me.Precio3.ReadOnly = True
        Me.Precio3.Visible = False
        '
        'Precio4
        '
        Me.Precio4.HeaderText = "Precio4"
        Me.Precio4.Name = "Precio4"
        Me.Precio4.ReadOnly = True
        Me.Precio4.Visible = False
        '
        'Costo
        '
        Me.Costo.HeaderText = "Costo"
        Me.Costo.Name = "Costo"
        Me.Costo.ReadOnly = True
        Me.Costo.Visible = False
        '
        'CostoFinal
        '
        Me.CostoFinal.HeaderText = "CostoFinal"
        Me.CostoFinal.Name = "CostoFinal"
        Me.CostoFinal.ReadOnly = True
        Me.CostoFinal.Visible = False
        '
        'IDMoneda
        '
        Me.IDMoneda.HeaderText = "IDMoneda"
        Me.IDMoneda.Name = "IDMoneda"
        Me.IDMoneda.ReadOnly = True
        Me.IDMoneda.Visible = False
        '
        'DgvExistencia
        '
        Me.DgvExistencia.AllowUserToAddRows = False
        Me.DgvExistencia.AllowUserToDeleteRows = False
        Me.DgvExistencia.AllowUserToResizeColumns = False
        Me.DgvExistencia.AllowUserToResizeRows = False
        Me.DgvExistencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvExistencia.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvExistencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvExistencia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvExistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvExistencia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDAlmacen, Me.Almacen, Me.Existencia})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvExistencia.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvExistencia.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvExistencia.Location = New System.Drawing.Point(486, 20)
        Me.DgvExistencia.MultiSelect = False
        Me.DgvExistencia.Name = "DgvExistencia"
        Me.DgvExistencia.ReadOnly = True
        Me.DgvExistencia.RowHeadersWidth = 20
        Me.DgvExistencia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvExistencia.RowTemplate.Height = 20
        Me.DgvExistencia.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvExistencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvExistencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvExistencia.Size = New System.Drawing.Size(254, 128)
        Me.DgvExistencia.TabIndex = 3
        '
        'IDAlmacen
        '
        Me.IDAlmacen.HeaderText = "IDAlmacen"
        Me.IDAlmacen.Name = "IDAlmacen"
        Me.IDAlmacen.ReadOnly = True
        Me.IDAlmacen.Visible = False
        '
        'Almacen
        '
        Me.Almacen.HeaderText = "Almacén"
        Me.Almacen.Name = "Almacen"
        Me.Almacen.ReadOnly = True
        Me.Almacen.Width = 150
        '
        'Existencia
        '
        Me.Existencia.HeaderText = "Existencia"
        Me.Existencia.Name = "Existencia"
        Me.Existencia.ReadOnly = True
        Me.Existencia.Width = 85
        '
        'DgvArticulos
        '
        Me.DgvArticulos.AllowUserToAddRows = False
        Me.DgvArticulos.AllowUserToDeleteRows = False
        Me.DgvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DgvArticulos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvArticulos.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgvArticulos.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvArticulos.Location = New System.Drawing.Point(1, 64)
        Me.DgvArticulos.MultiSelect = False
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.ReadOnly = True
        Me.DgvArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvArticulos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvArticulos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(1010, 410)
        Me.DgvArticulos.TabIndex = 1
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label7.Location = New System.Drawing.Point(301, 9)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(39, 13)
        Me.label7.TabIndex = 241
        Me.label7.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtBuscar.Location = New System.Drawing.Point(304, 25)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBuscar.Size = New System.Drawing.Size(502, 20)
        Me.txtBuscar.TabIndex = 0
        Me.txtBuscar.WordWrap = False
        '
        'BindingNavigator
        '
        Me.BindingNavigator.AddNewItem = Nothing
        Me.BindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator.DeleteItem = Nothing
        Me.BindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.ToolStripSeparator1, Me.btnImagenes, Me.ToolStripSeparator2, Me.btnEspecificaciones, Me.BindingNavigatorSeparator2, Me.lblStatus, Me.btnFiltrar, Me.ToolStripSeparator3, Me.VistaDinamica, Me.VistaTabla, Me.ToolStripSeparator4, Me.ToolStripLabel1})
        Me.BindingNavigator.Location = New System.Drawing.Point(0, 636)
        Me.BindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator.Name = "BindingNavigator"
        Me.BindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BindingNavigator.Size = New System.Drawing.Size(1011, 25)
        Me.BindingNavigator.TabIndex = 242
        Me.BindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 20)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnImagenes
        '
        Me.btnImagenes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnImagenes.Image = Global.Libregco.My.Resources.Resources.Picture_x32
        Me.btnImagenes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImagenes.Name = "btnImagenes"
        Me.btnImagenes.Size = New System.Drawing.Size(78, 22)
        Me.btnImagenes.Text = "Imágenes"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnEspecificaciones
        '
        Me.btnEspecificaciones.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnEspecificaciones.Image = Global.Libregco.My.Resources.Resources.TextEdit_x32
        Me.btnEspecificaciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEspecificaciones.Name = "btnEspecificaciones"
        Me.btnEspecificaciones.Size = New System.Drawing.Size(113, 22)
        Me.btnEspecificaciones.Text = "Especificaciones"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(29, 22)
        Me.lblStatus.Text = "Listo"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnFiltrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.Image = Global.Libregco.My.Resources.Resources.Filterx16
        Me.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(58, 22)
        Me.btnFiltrar.Text = "Filtrar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'VistaDinamica
        '
        Me.VistaDinamica.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.VistaDinamica.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.VistaDinamica.Image = Global.Libregco.My.Resources.Resources.imageviewgray
        Me.VistaDinamica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.VistaDinamica.Name = "VistaDinamica"
        Me.VistaDinamica.Size = New System.Drawing.Size(97, 22)
        Me.VistaDinamica.Text = " Vista dinámica"
        Me.VistaDinamica.ToolTipText = "Muestra los artículos en listados formatos de tabla"
        '
        'VistaTabla
        '
        Me.VistaTabla.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.VistaTabla.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.VistaTabla.Image = Global.Libregco.My.Resources.Resources.listvieworange
        Me.VistaTabla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.VistaTabla.Name = "VistaTabla"
        Me.VistaTabla.Size = New System.Drawing.Size(95, 22)
        Me.VistaTabla.Text = " Vista de tabla"
        Me.VistaTabla.ToolTipText = "Muestra los artículos en listados formatos de tabla"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripLabel1.Text = "Visualización"
        '
        'lblNotaImagen
        '
        Me.lblNotaImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotaImagen.BackColor = System.Drawing.SystemColors.Control
        Me.lblNotaImagen.Location = New System.Drawing.Point(742, 76)
        Me.lblNotaImagen.Name = "lblNotaImagen"
        Me.lblNotaImagen.Size = New System.Drawing.Size(267, 37)
        Me.lblNotaImagen.TabIndex = 245
        Me.lblNotaImagen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PicImagen
        '
        Me.PicImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicImagen.BackColor = System.Drawing.SystemColors.Control
        Me.PicImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicImagen.Location = New System.Drawing.Point(740, 20)
        Me.PicImagen.Name = "PicImagen"
        Me.PicImagen.Size = New System.Drawing.Size(271, 152)
        Me.PicImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImagen.TabIndex = 244
        Me.PicImagen.TabStop = False
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(3, 3)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(163, 55)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 243
        Me.PicBoxLogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(338, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 246
        Me.Label1.Text = "[F2]"
        '
        'TabClasico
        '
        Me.TabClasico.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabClasico.Controls.Add(Me.TabPage1)
        Me.TabClasico.Controls.Add(Me.TabPage2)
        Me.TabClasico.Location = New System.Drawing.Point(-5, 435)
        Me.TabClasico.Name = "TabClasico"
        Me.TabClasico.SelectedIndex = 0
        Me.TabClasico.Size = New System.Drawing.Size(1028, 203)
        Me.TabClasico.TabIndex = 247
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.TKPropiedades)
        Me.TabPage1.Controls.Add(Me.DgvExistencia)
        Me.TabPage1.Controls.Add(Me.DgvPrecioArticulo)
        Me.TabPage1.Controls.Add(Me.lblNotaImagen)
        Me.TabPage1.Controls.Add(Me.PicImagen)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1020, 174)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'TKPropiedades
        '
        Me.TKPropiedades.Enabled = False
        Me.TKPropiedades.Location = New System.Drawing.Point(1, 149)
        Me.TKPropiedades.Name = "TKPropiedades"
        Me.TKPropiedades.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.TKPropiedades.Properties.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.TKPropiedades.Properties.Appearance.Options.UseBackColor = True
        Me.TKPropiedades.Properties.Appearance.Options.UseForeColor = True
        Me.TKPropiedades.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.DodgerBlue
        Me.TKPropiedades.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TKPropiedades.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.DodgerBlue
        Me.TKPropiedades.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TKPropiedades.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.TKPropiedades.Properties.DeleteTokenOnGlyphClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.TKPropiedades.Properties.Separators.AddRange(New String() {","})
        Me.TKPropiedades.Size = New System.Drawing.Size(739, 18)
        Me.TKPropiedades.TabIndex = 246
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.txtMarca)
        Me.TabPage2.Controls.Add(Me.btnMarca)
        Me.TabPage2.Controls.Add(Me.txtIDMarca)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtSubcategoria)
        Me.TabPage2.Controls.Add(Me.btnSubcategoria)
        Me.TabPage2.Controls.Add(Me.txtIDSubCategoria)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txtCategoria)
        Me.TabPage2.Controls.Add(Me.btnCategoria)
        Me.TabPage2.Controls.Add(Me.txtIDCategoria)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtDepartamento)
        Me.TabPage2.Controls.Add(Me.btnDepartamento)
        Me.TabPage2.Controls.Add(Me.txtIDDepartamento)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtTipo)
        Me.TabPage2.Controls.Add(Me.btnTipo)
        Me.TabPage2.Controls.Add(Me.txtIDTipo)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtSuplidor)
        Me.TabPage2.Controls.Add(Me.btn_Suplidor)
        Me.TabPage2.Controls.Add(Me.txtIDSuplidor)
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Controls.Add(Me.btnClose)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1020, 174)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.PictureBox2.Location = New System.Drawing.Point(970, 134)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(34, 34)
        Me.PictureBox2.TabIndex = 477
        Me.PictureBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(507, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 476
        Me.Label8.Text = "Marca"
        '
        'txtMarca
        '
        Me.txtMarca.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.Location = New System.Drawing.Point(673, 121)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(282, 22)
        Me.txtMarca.TabIndex = 475
        '
        'btnMarca
        '
        Me.btnMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMarca.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMarca.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnMarca.Image = CType(resources.GetObject("btnMarca.Image"), System.Drawing.Image)
        Me.btnMarca.Location = New System.Drawing.Point(647, 121)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(27, 22)
        Me.btnMarca.TabIndex = 16
        Me.btnMarca.UseVisualStyleBackColor = True
        '
        'txtIDMarca
        '
        Me.txtIDMarca.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtIDMarca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtIDMarca.Location = New System.Drawing.Point(585, 121)
        Me.txtIDMarca.Name = "txtIDMarca"
        Me.txtIDMarca.Size = New System.Drawing.Size(63, 22)
        Me.txtIDMarca.TabIndex = 15
        Me.txtIDMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(507, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 474
        Me.Label9.Text = "Subcategoría"
        '
        'txtSubcategoria
        '
        Me.txtSubcategoria.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubcategoria.Location = New System.Drawing.Point(673, 93)
        Me.txtSubcategoria.Name = "txtSubcategoria"
        Me.txtSubcategoria.ReadOnly = True
        Me.txtSubcategoria.Size = New System.Drawing.Size(282, 22)
        Me.txtSubcategoria.TabIndex = 473
        '
        'btnSubcategoria
        '
        Me.btnSubcategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSubcategoria.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnSubcategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSubcategoria.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnSubcategoria.Image = CType(resources.GetObject("btnSubcategoria.Image"), System.Drawing.Image)
        Me.btnSubcategoria.Location = New System.Drawing.Point(647, 93)
        Me.btnSubcategoria.Name = "btnSubcategoria"
        Me.btnSubcategoria.Size = New System.Drawing.Size(27, 22)
        Me.btnSubcategoria.TabIndex = 14
        Me.btnSubcategoria.UseVisualStyleBackColor = True
        '
        'txtIDSubCategoria
        '
        Me.txtIDSubCategoria.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtIDSubCategoria.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtIDSubCategoria.Location = New System.Drawing.Point(585, 93)
        Me.txtIDSubCategoria.Name = "txtIDSubCategoria"
        Me.txtIDSubCategoria.Size = New System.Drawing.Size(63, 22)
        Me.txtIDSubCategoria.TabIndex = 13
        Me.txtIDSubCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(507, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 468
        Me.Label6.Text = "Categoría"
        '
        'txtCategoria
        '
        Me.txtCategoria.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoria.Location = New System.Drawing.Point(673, 65)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(282, 22)
        Me.txtCategoria.TabIndex = 467
        '
        'btnCategoria
        '
        Me.btnCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCategoria.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCategoria.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnCategoria.Image = CType(resources.GetObject("btnCategoria.Image"), System.Drawing.Image)
        Me.btnCategoria.Location = New System.Drawing.Point(647, 65)
        Me.btnCategoria.Name = "btnCategoria"
        Me.btnCategoria.Size = New System.Drawing.Size(27, 22)
        Me.btnCategoria.TabIndex = 12
        Me.btnCategoria.UseVisualStyleBackColor = True
        '
        'txtIDCategoria
        '
        Me.txtIDCategoria.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtIDCategoria.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtIDCategoria.Location = New System.Drawing.Point(585, 65)
        Me.txtIDCategoria.Name = "txtIDCategoria"
        Me.txtIDCategoria.Size = New System.Drawing.Size(63, 22)
        Me.txtIDCategoria.TabIndex = 11
        Me.txtIDCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 464
        Me.Label4.Text = "Departamento"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartamento.Location = New System.Drawing.Point(190, 121)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(282, 22)
        Me.txtDepartamento.TabIndex = 463
        '
        'btnDepartamento
        '
        Me.btnDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDepartamento.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnDepartamento.Image = CType(resources.GetObject("btnDepartamento.Image"), System.Drawing.Image)
        Me.btnDepartamento.Location = New System.Drawing.Point(164, 121)
        Me.btnDepartamento.Name = "btnDepartamento"
        Me.btnDepartamento.Size = New System.Drawing.Size(27, 22)
        Me.btnDepartamento.TabIndex = 10
        Me.btnDepartamento.UseVisualStyleBackColor = True
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtIDDepartamento.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtIDDepartamento.Location = New System.Drawing.Point(102, 121)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.Size = New System.Drawing.Size(63, 22)
        Me.txtIDDepartamento.TabIndex = 9
        Me.txtIDDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 462
        Me.Label3.Text = "Tipo"
        '
        'txtTipo
        '
        Me.txtTipo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.Location = New System.Drawing.Point(190, 93)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(282, 22)
        Me.txtTipo.TabIndex = 461
        '
        'btnTipo
        '
        Me.btnTipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnTipo.Image = CType(resources.GetObject("btnTipo.Image"), System.Drawing.Image)
        Me.btnTipo.Location = New System.Drawing.Point(164, 93)
        Me.btnTipo.Name = "btnTipo"
        Me.btnTipo.Size = New System.Drawing.Size(27, 22)
        Me.btnTipo.TabIndex = 8
        Me.btnTipo.UseVisualStyleBackColor = True
        '
        'txtIDTipo
        '
        Me.txtIDTipo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtIDTipo.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtIDTipo.Location = New System.Drawing.Point(102, 93)
        Me.txtIDTipo.Name = "txtIDTipo"
        Me.txtIDTipo.Size = New System.Drawing.Size(63, 22)
        Me.txtIDTipo.TabIndex = 7
        Me.txtIDTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 460
        Me.Label5.Text = "Suplidor"
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuplidor.Location = New System.Drawing.Point(190, 65)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.ReadOnly = True
        Me.txtSuplidor.Size = New System.Drawing.Size(282, 22)
        Me.txtSuplidor.TabIndex = 459
        '
        'btn_Suplidor
        '
        Me.btn_Suplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Suplidor.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_Suplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Suplidor.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btn_Suplidor.Image = CType(resources.GetObject("btn_Suplidor.Image"), System.Drawing.Image)
        Me.btn_Suplidor.Location = New System.Drawing.Point(164, 65)
        Me.btn_Suplidor.Name = "btn_Suplidor"
        Me.btn_Suplidor.Size = New System.Drawing.Size(27, 22)
        Me.btn_Suplidor.TabIndex = 6
        Me.btn_Suplidor.UseVisualStyleBackColor = True
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtIDSuplidor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtIDSuplidor.Location = New System.Drawing.Point(102, 65)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.Size = New System.Drawing.Size(63, 22)
        Me.txtIDSuplidor.TabIndex = 5
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gray
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Filterx16
        Me.PictureBox1.Location = New System.Drawing.Point(29, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox1.TabIndex = 452
        Me.PictureBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Red
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Location = New System.Drawing.Point(970, 24)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gray
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(22, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(972, 27)
        Me.Label2.TabIndex = 450
        Me.Label2.Text = "         Filtrar consulta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.PicBoxLogo)
        Me.Panel1.Controls.Add(Me.DgvArticulos)
        Me.Panel1.Controls.Add(Me.txtBuscar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.label7)
        Me.Panel1.Controls.Add(Me.TabClasico)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 632)
        Me.Panel1.TabIndex = 0
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Firebrick
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 7.25!, System.Drawing.FontStyle.Bold)
        Me.Button6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button6.Location = New System.Drawing.Point(740, 25)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(66, 20)
        Me.Button6.TabIndex = 249
        Me.Button6.Text = "[ESCAPE] X"
        Me.Button6.UseVisualStyleBackColor = False
        Me.Button6.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbDirecto)
        Me.GroupBox1.Controls.Add(Me.rdbPredictivo)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(851, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 47)
        Me.GroupBox1.TabIndex = 248
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Métodos"
        '
        'rdbDirecto
        '
        Me.rdbDirecto.AutoSize = True
        Me.rdbDirecto.Location = New System.Drawing.Point(84, 18)
        Me.rdbDirecto.Name = "rdbDirecto"
        Me.rdbDirecto.Size = New System.Drawing.Size(59, 17)
        Me.rdbDirecto.TabIndex = 1
        Me.rdbDirecto.Text = "Directo"
        Me.rdbDirecto.UseVisualStyleBackColor = True
        '
        'rdbPredictivo
        '
        Me.rdbPredictivo.AutoSize = True
        Me.rdbPredictivo.Checked = True
        Me.rdbPredictivo.Location = New System.Drawing.Point(6, 18)
        Me.rdbPredictivo.Name = "rdbPredictivo"
        Me.rdbPredictivo.Size = New System.Drawing.Size(72, 17)
        Me.rdbPredictivo.TabIndex = 0
        Me.rdbPredictivo.TabStop = True
        Me.rdbPredictivo.Text = "Predictivo"
        Me.rdbPredictivo.UseVisualStyleBackColor = True
        '
        'TabMenus
        '
        Me.TabMenus.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabMenus.Controls.Add(Me.TabPage3)
        Me.TabMenus.Controls.Add(Me.TabDinamica)
        Me.TabMenus.Location = New System.Drawing.Point(-8, -26)
        Me.TabMenus.Name = "TabMenus"
        Me.TabMenus.SelectedIndex = 0
        Me.TabMenus.Size = New System.Drawing.Size(1026, 667)
        Me.TabMenus.TabIndex = 249
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1018, 638)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Vista clásica"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabDinamica
        '
        Me.TabDinamica.Controls.Add(Me.TabArticulos)
        Me.TabDinamica.Location = New System.Drawing.Point(4, 25)
        Me.TabDinamica.Name = "TabDinamica"
        Me.TabDinamica.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDinamica.Size = New System.Drawing.Size(1018, 638)
        Me.TabDinamica.TabIndex = 1
        Me.TabDinamica.Text = "Vista dinámica"
        Me.TabDinamica.UseVisualStyleBackColor = True
        '
        'TabArticulos
        '
        Me.TabArticulos.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabArticulos.Controls.Add(Me.TabPage7)
        Me.TabArticulos.Controls.Add(Me.TabPage4)
        Me.TabArticulos.Controls.Add(Me.TabPage5)
        Me.TabArticulos.Controls.Add(Me.TabPage6)
        Me.TabArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabArticulos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TabArticulos.Location = New System.Drawing.Point(3, 3)
        Me.TabArticulos.Name = "TabArticulos"
        Me.TabArticulos.SelectedIndex = 0
        Me.TabArticulos.Size = New System.Drawing.Size(1012, 632)
        Me.TabArticulos.TabIndex = 1
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.FlowDepartamentos)
        Me.TabPage7.Location = New System.Drawing.Point(4, 25)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1004, 603)
        Me.TabPage7.TabIndex = 3
        Me.TabPage7.Text = "Departamentos"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'FlowDepartamentos
        '
        Me.FlowDepartamentos.AutoScroll = True
        Me.FlowDepartamentos.BackColor = System.Drawing.Color.White
        Me.FlowDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowDepartamentos.Location = New System.Drawing.Point(0, 0)
        Me.FlowDepartamentos.Name = "FlowDepartamentos"
        Me.FlowDepartamentos.Size = New System.Drawing.Size(1004, 603)
        Me.FlowDepartamentos.TabIndex = 0
        Me.FlowDepartamentos.WrapContents = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.LinkLabel2)
        Me.TabPage4.Controls.Add(Me.FlowCategorias)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1004, 603)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "Categorías"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel2.Location = New System.Drawing.Point(4, 4)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "↵ Volver atrás"
        '
        'FlowCategorias
        '
        Me.FlowCategorias.AutoScroll = True
        Me.FlowCategorias.BackColor = System.Drawing.Color.White
        Me.FlowCategorias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowCategorias.Location = New System.Drawing.Point(3, 3)
        Me.FlowCategorias.Name = "FlowCategorias"
        Me.FlowCategorias.Size = New System.Drawing.Size(998, 597)
        Me.FlowCategorias.TabIndex = 1
        Me.FlowCategorias.WrapContents = False
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.LinkLabel1)
        Me.TabPage5.Controls.Add(Me.FlowSubCategoria)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1004, 603)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Subcategorías"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 4)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "↵ Volver atrás"
        '
        'FlowSubCategoria
        '
        Me.FlowSubCategoria.AutoScroll = True
        Me.FlowSubCategoria.BackColor = System.Drawing.Color.White
        Me.FlowSubCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowSubCategoria.Location = New System.Drawing.Point(3, 3)
        Me.FlowSubCategoria.Name = "FlowSubCategoria"
        Me.FlowSubCategoria.Size = New System.Drawing.Size(998, 597)
        Me.FlowSubCategoria.TabIndex = 2
        Me.FlowSubCategoria.WrapContents = False
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.LinkLabel3)
        Me.TabPage6.Controls.Add(Me.ListControl1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1004, 603)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Productos"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.BackColor = System.Drawing.Color.White
        Me.LinkLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel3.Location = New System.Drawing.Point(863, 9)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel3.TabIndex = 1
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "↵ Volver atrás"
        '
        'ListControl1
        '
        Me.ListControl1.AutoScroll = True
        Me.ListControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListControl1.HeaderName = "Listado de Control"
        Me.ListControl1.ImageListDefaultSize = New System.Drawing.Size(450, 140)
        Me.ListControl1.Location = New System.Drawing.Point(3, 3)
        Me.ListControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.ListControl1.MultiSelect = False
        Me.ListControl1.Name = "ListControl1"
        Me.ListControl1.SelectedTagName = ""
        Me.ListControl1.ShowSeparator = False
        Me.ListControl1.Size = New System.Drawing.Size(998, 597)
        Me.ListControl1.TabIndex = 0
        Me.ListControl1.TypeOfView = 0
        Me.ListControl1.WideViewMode = True
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.WareHouse_x48, "Unión de grupos", "Se ha agregado el artículo a un grupo. ", "Recuerde guardar el grupo para finalizar el proceso de la creación de grupos.", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDPrecios"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Medida"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Contenido"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 85
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Precio crédito"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 130
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Precio contado "
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 130
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "IDAlmacen"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Almacén"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 150
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Existencia"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 85
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Precio3"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Precio4"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Costo"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "CostoFinal"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "IDMoneda"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'frm_buscar_mant_articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 661)
        Me.Controls.Add(Me.BindingNavigator)
        Me.Controls.Add(Me.TabMenus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_buscar_mant_articulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Buscar artículos"
        CType(Me.DgvPrecioArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator.ResumeLayout(False)
        Me.BindingNavigator.PerformLayout()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabClasico.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.TKPropiedades.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabMenus.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabDinamica.ResumeLayout(False)
        Me.TabArticulos.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvPrecioArticulo As System.Windows.Forms.DataGridView
    Friend WithEvents DgvExistencia As System.Windows.Forms.DataGridView
    Friend WithEvents DgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents BindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents PicImagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblNotaImagen As System.Windows.Forms.Label
    Friend WithEvents IDAlmacen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Almacen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Existencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEspecificaciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImagenes As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnFiltrar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabClasico As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnClose As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDepartamento As TextBox
    Friend WithEvents btnDepartamento As Button
    Friend WithEvents txtIDDepartamento As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTipo As TextBox
    Friend WithEvents btnTipo As Button
    Friend WithEvents txtIDTipo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSuplidor As TextBox
    Friend WithEvents btn_Suplidor As Button
    Friend WithEvents txtIDSuplidor As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents btnCategoria As Button
    Friend WithEvents txtIDCategoria As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents btnMarca As Button
    Friend WithEvents txtIDMarca As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSubcategoria As TextBox
    Friend WithEvents btnSubcategoria As Button
    Friend WithEvents txtIDSubCategoria As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabMenus As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabDinamica As TabPage
    Friend WithEvents TabArticulos As TabControl
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents FlowDepartamentos As FlowLayoutPanel
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents FlowCategorias As FlowLayoutPanel
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents FlowSubCategoria As FlowLayoutPanel
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents ListControl1 As ListControl
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents VistaTabla As ToolStripButton
    Friend WithEvents VistaDinamica As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents TKPropiedades As DevExpress.XtraEditors.TokenEdit
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdbDirecto As RadioButton
    Friend WithEvents rdbPredictivo As RadioButton
    Friend WithEvents Button6 As Button
    Friend WithEvents IDPrecios As DataGridViewTextBoxColumn
    Friend WithEvents Medida As DataGridViewTextBoxColumn
    Friend WithEvents Contenido As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCredito As DataGridViewTextBoxColumn
    Friend WithEvents PrecioContado As DataGridViewTextBoxColumn
    Friend WithEvents Precio3 As DataGridViewTextBoxColumn
    Friend WithEvents Precio4 As DataGridViewTextBoxColumn
    Friend WithEvents Costo As DataGridViewTextBoxColumn
    Friend WithEvents CostoFinal As DataGridViewTextBoxColumn
    Friend WithEvents IDMoneda As DataGridViewTextBoxColumn
    Friend WithEvents ToastNotificationsManager1 As XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
End Class
