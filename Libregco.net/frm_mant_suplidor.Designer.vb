<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mant_suplidor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mant_suplidor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.cbxProvincia = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.cbxMunicipio = New System.Windows.Forms.ComboBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.MaskedTextBox()
        Me.txtFax = New System.Windows.Forms.MaskedTextBox()
        Me.txtTelRep = New System.Windows.Forms.MaskedTextBox()
        Me.txtRepresentante = New System.Windows.Forms.TextBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.txtWeb = New System.Windows.Forms.TextBox()
        Me.txtBeneficiario = New System.Windows.Forms.TextBox()
        Me.txtFechaRegistro = New System.Windows.Forms.MaskedTextBox()
        Me.ChkDesactivar = New System.Windows.Forms.CheckBox()
        Me.txtLimite = New System.Windows.Forms.TextBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TbSuplidor = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.btnBuscarCondicion = New System.Windows.Forms.Button()
        Me.txtIDCondicion = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtTipoSuplidor = New System.Windows.Forms.TextBox()
        Me.btnBuscarTipoSuplidor = New System.Windows.Forms.Button()
        Me.txtIDTipoSuplidor = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnBuscarTipoGasto = New System.Windows.Forms.Button()
        Me.txtIDTipoGasto = New System.Windows.Forms.TextBox()
        Me.txtNCF = New System.Windows.Forms.TextBox()
        Me.btnBuscarNCF = New System.Windows.Forms.Button()
        Me.txtIDNcf = New System.Windows.Forms.TextBox()
        Me.txtTipoGasto = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxTipoIdentificacion = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txtRnc = New System.Windows.Forms.MaskedTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DgvArchivos = New System.Windows.Forms.DataGridView()
        Me.Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Visual = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarRNCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.TbSuplidor.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DgvArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Enabled = False
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.Location = New System.Drawing.Point(6, 140)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.ReadOnly = True
        Me.txtIDSuplidor.Size = New System.Drawing.Size(151, 23)
        Me.txtIDSuplidor.TabIndex = 0
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxProvincia
        '
        Me.cbxProvincia.DropDownHeight = 110
        Me.cbxProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxProvincia.FormattingEnabled = True
        Me.cbxProvincia.IntegralHeight = False
        Me.cbxProvincia.Location = New System.Drawing.Point(11, 35)
        Me.cbxProvincia.Name = "cbxProvincia"
        Me.cbxProvincia.Size = New System.Drawing.Size(318, 23)
        Me.cbxProvincia.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Código"
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSuplidor.Location = New System.Drawing.Point(163, 140)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.Size = New System.Drawing.Size(759, 23)
        Me.txtSuplidor.TabIndex = 0
        '
        'cbxMunicipio
        '
        Me.cbxMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxMunicipio.FormattingEnabled = True
        Me.cbxMunicipio.Location = New System.Drawing.Point(11, 79)
        Me.cbxMunicipio.Name = "cbxMunicipio"
        Me.cbxMunicipio.Size = New System.Drawing.Size(318, 23)
        Me.cbxMunicipio.TabIndex = 12
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(335, 35)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccion.Size = New System.Drawing.Size(559, 67)
        Me.txtDireccion.TabIndex = 13
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelefono.Location = New System.Drawing.Point(8, 34)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(121, 23)
        Me.txtTelefono.TabIndex = 15
        Me.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFax
        '
        Me.txtFax.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFax.Location = New System.Drawing.Point(135, 34)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(121, 23)
        Me.txtFax.TabIndex = 16
        Me.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTelRep
        '
        Me.txtTelRep.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelRep.Location = New System.Drawing.Point(693, 34)
        Me.txtTelRep.Name = "txtTelRep"
        Me.txtTelRep.Size = New System.Drawing.Size(121, 23)
        Me.txtTelRep.TabIndex = 20
        Me.txtTelRep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRepresentante
        '
        Me.txtRepresentante.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRepresentante.Location = New System.Drawing.Point(262, 34)
        Me.txtRepresentante.Name = "txtRepresentante"
        Me.txtRepresentante.Size = New System.Drawing.Size(425, 23)
        Me.txtRepresentante.TabIndex = 19
        '
        'txtCorreo
        '
        Me.txtCorreo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCorreo.Location = New System.Drawing.Point(8, 78)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(245, 23)
        Me.txtCorreo.TabIndex = 17
        '
        'txtWeb
        '
        Me.txtWeb.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtWeb.Location = New System.Drawing.Point(259, 78)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Size = New System.Drawing.Size(278, 23)
        Me.txtWeb.TabIndex = 18
        '
        'txtBeneficiario
        '
        Me.txtBeneficiario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBeneficiario.Location = New System.Drawing.Point(424, 35)
        Me.txtBeneficiario.Name = "txtBeneficiario"
        Me.txtBeneficiario.Size = New System.Drawing.Size(469, 23)
        Me.txtBeneficiario.TabIndex = 5
        '
        'txtFechaRegistro
        '
        Me.txtFechaRegistro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaRegistro.Location = New System.Drawing.Point(110, 80)
        Me.txtFechaRegistro.Name = "txtFechaRegistro"
        Me.txtFechaRegistro.ReadOnly = True
        Me.txtFechaRegistro.Size = New System.Drawing.Size(147, 23)
        Me.txtFechaRegistro.TabIndex = 77
        Me.txtFechaRegistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaRegistro.ValidatingType = GetType(Date)
        '
        'ChkDesactivar
        '
        Me.ChkDesactivar.AutoSize = True
        Me.ChkDesactivar.Enabled = False
        Me.ChkDesactivar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkDesactivar.Location = New System.Drawing.Point(544, 78)
        Me.ChkDesactivar.Name = "ChkDesactivar"
        Me.ChkDesactivar.Size = New System.Drawing.Size(80, 19)
        Me.ChkDesactivar.TabIndex = 18
        Me.ChkDesactivar.Text = "Desactivar"
        Me.ChkDesactivar.UseVisualStyleBackColor = True
        Me.ChkDesactivar.Visible = False
        '
        'txtLimite
        '
        Me.txtLimite.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtLimite.Location = New System.Drawing.Point(110, 22)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(147, 23)
        Me.txtLimite.TabIndex = 27
        Me.txtLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBalance
        '
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalance.Location = New System.Drawing.Point(110, 51)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(147, 23)
        Me.txtBalance.TabIndex = 80
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(160, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Suplidor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(232, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "RNC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Provincia"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(11, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Municipio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(259, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Representante"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(258, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 15)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Web"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(132, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 15)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Fax"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(5, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "Teléfono"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(332, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 15)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Dirección"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(690, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 15)
        Me.Label12.TabIndex = 91
        Me.Label12.Text = "Teléfono"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(5, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 15)
        Me.Label13.TabIndex = 92
        Me.Label13.Text = "Tipo de Gasto"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(5, 78)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 15)
        Me.Label14.TabIndex = 93
        Me.Label14.Text = "Tipo de NCF"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(421, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 15)
        Me.Label15.TabIndex = 94
        Me.Label15.Text = "Beneficiario"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(5, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 15)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Condición"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(6, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 15)
        Me.Label18.TabIndex = 97
        Me.Label18.Text = "Fecha de Ingreso"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(6, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 15)
        Me.Label19.TabIndex = 98
        Me.Label19.Text = "Límite de Crédito"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(6, 54)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 15)
        Me.Label20.TabIndex = 99
        Me.Label20.Text = "Balance Total"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TbSuplidor
        '
        Me.TbSuplidor.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TbSuplidor.Controls.Add(Me.TabPage1)
        Me.TbSuplidor.Controls.Add(Me.TabPage2)
        Me.TbSuplidor.Controls.Add(Me.TabPage3)
        Me.TbSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TbSuplidor.Location = New System.Drawing.Point(5, 169)
        Me.TbSuplidor.Name = "TbSuplidor"
        Me.TbSuplidor.SelectedIndex = 0
        Me.TbSuplidor.Size = New System.Drawing.Size(921, 464)
        Me.TbSuplidor.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(913, 433)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Suplidor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtCondicion)
        Me.GroupBox4.Controls.Add(Me.btnBuscarCondicion)
        Me.GroupBox4.Controls.Add(Me.txtIDCondicion)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.txtTipoSuplidor)
        Me.GroupBox4.Controls.Add(Me.btnBuscarTipoSuplidor)
        Me.GroupBox4.Controls.Add(Me.txtIDTipoSuplidor)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.btnBuscarTipoGasto)
        Me.GroupBox4.Controls.Add(Me.txtIDTipoGasto)
        Me.GroupBox4.Controls.Add(Me.txtNCF)
        Me.GroupBox4.Controls.Add(Me.btnBuscarNCF)
        Me.GroupBox4.Controls.Add(Me.txtIDNcf)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.txtTipoGasto)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 296)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(901, 134)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Contabilidad"
        '
        'txtCondicion
        '
        Me.txtCondicion.Enabled = False
        Me.txtCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicion.Location = New System.Drawing.Point(202, 46)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.ReadOnly = True
        Me.txtCondicion.Size = New System.Drawing.Size(422, 23)
        Me.txtCondicion.TabIndex = 107
        '
        'btnBuscarCondicion
        '
        Me.btnBuscarCondicion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCondicion.Image = CType(resources.GetObject("btnBuscarCondicion.Image"), System.Drawing.Image)
        Me.btnBuscarCondicion.Location = New System.Drawing.Point(180, 46)
        Me.btnBuscarCondicion.Name = "btnBuscarCondicion"
        Me.btnBuscarCondicion.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCondicion.TabIndex = 23
        Me.btnBuscarCondicion.UseVisualStyleBackColor = True
        '
        'txtIDCondicion
        '
        Me.txtIDCondicion.Enabled = False
        Me.txtIDCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCondicion.Location = New System.Drawing.Point(89, 46)
        Me.txtIDCondicion.Name = "txtIDCondicion"
        Me.txtIDCondicion.ReadOnly = True
        Me.txtIDCondicion.Size = New System.Drawing.Size(92, 23)
        Me.txtIDCondicion.TabIndex = 105
        Me.txtIDCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtBalance)
        Me.GroupBox5.Controls.Add(Me.txtLimite)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.txtFechaRegistro)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Location = New System.Drawing.Point(631, 10)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(262, 112)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        '
        'txtTipoSuplidor
        '
        Me.txtTipoSuplidor.Enabled = False
        Me.txtTipoSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoSuplidor.Location = New System.Drawing.Point(202, 17)
        Me.txtTipoSuplidor.Name = "txtTipoSuplidor"
        Me.txtTipoSuplidor.ReadOnly = True
        Me.txtTipoSuplidor.Size = New System.Drawing.Size(422, 23)
        Me.txtTipoSuplidor.TabIndex = 112
        '
        'btnBuscarTipoSuplidor
        '
        Me.btnBuscarTipoSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarTipoSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoSuplidor.Image = CType(resources.GetObject("btnBuscarTipoSuplidor.Image"), System.Drawing.Image)
        Me.btnBuscarTipoSuplidor.Location = New System.Drawing.Point(180, 17)
        Me.btnBuscarTipoSuplidor.Name = "btnBuscarTipoSuplidor"
        Me.btnBuscarTipoSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoSuplidor.TabIndex = 22
        Me.btnBuscarTipoSuplidor.UseVisualStyleBackColor = True
        '
        'txtIDTipoSuplidor
        '
        Me.txtIDTipoSuplidor.Enabled = False
        Me.txtIDTipoSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoSuplidor.Location = New System.Drawing.Point(89, 17)
        Me.txtIDTipoSuplidor.Name = "txtIDTipoSuplidor"
        Me.txtIDTipoSuplidor.ReadOnly = True
        Me.txtIDTipoSuplidor.Size = New System.Drawing.Size(92, 23)
        Me.txtIDTipoSuplidor.TabIndex = 110
        Me.txtIDTipoSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(5, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 15)
        Me.Label21.TabIndex = 109
        Me.Label21.Text = "Tipo Suplidor"
        '
        'btnBuscarTipoGasto
        '
        Me.btnBuscarTipoGasto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarTipoGasto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoGasto.Image = CType(resources.GetObject("btnBuscarTipoGasto.Image"), System.Drawing.Image)
        Me.btnBuscarTipoGasto.Location = New System.Drawing.Point(180, 104)
        Me.btnBuscarTipoGasto.Name = "btnBuscarTipoGasto"
        Me.btnBuscarTipoGasto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoGasto.TabIndex = 25
        Me.btnBuscarTipoGasto.UseVisualStyleBackColor = True
        '
        'txtIDTipoGasto
        '
        Me.txtIDTipoGasto.Enabled = False
        Me.txtIDTipoGasto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoGasto.Location = New System.Drawing.Point(89, 104)
        Me.txtIDTipoGasto.Name = "txtIDTipoGasto"
        Me.txtIDTipoGasto.ReadOnly = True
        Me.txtIDTipoGasto.Size = New System.Drawing.Size(92, 23)
        Me.txtIDTipoGasto.TabIndex = 102
        Me.txtIDTipoGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNCF
        '
        Me.txtNCF.Enabled = False
        Me.txtNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNCF.Location = New System.Drawing.Point(202, 75)
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.ReadOnly = True
        Me.txtNCF.Size = New System.Drawing.Size(422, 23)
        Me.txtNCF.TabIndex = 101
        '
        'btnBuscarNCF
        '
        Me.btnBuscarNCF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarNCF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarNCF.Image = CType(resources.GetObject("btnBuscarNCF.Image"), System.Drawing.Image)
        Me.btnBuscarNCF.Location = New System.Drawing.Point(180, 75)
        Me.btnBuscarNCF.Name = "btnBuscarNCF"
        Me.btnBuscarNCF.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarNCF.TabIndex = 24
        Me.btnBuscarNCF.UseVisualStyleBackColor = True
        '
        'txtIDNcf
        '
        Me.txtIDNcf.Enabled = False
        Me.txtIDNcf.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNcf.Location = New System.Drawing.Point(89, 75)
        Me.txtIDNcf.Name = "txtIDNcf"
        Me.txtIDNcf.ReadOnly = True
        Me.txtIDNcf.Size = New System.Drawing.Size(92, 23)
        Me.txtIDNcf.TabIndex = 99
        Me.txtIDNcf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTipoGasto
        '
        Me.txtTipoGasto.Enabled = False
        Me.txtTipoGasto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoGasto.Location = New System.Drawing.Point(202, 104)
        Me.txtTipoGasto.Name = "txtTipoGasto"
        Me.txtTipoGasto.ReadOnly = True
        Me.txtTipoGasto.Size = New System.Drawing.Size(422, 23)
        Me.txtTipoGasto.TabIndex = 104
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtTelefono)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtFax)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtCorreo)
        Me.GroupBox3.Controls.Add(Me.txtRepresentante)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtWeb)
        Me.GroupBox3.Controls.Add(Me.ChkDesactivar)
        Me.GroupBox3.Controls.Add(Me.txtTelRep)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 184)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(901, 111)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Contactos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(9, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 15)
        Me.Label17.TabIndex = 92
        Me.Label17.Text = "Correo Electrónico"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbxProvincia)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtDireccion)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbxMunicipio)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(904, 112)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Domicilio"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxTipoIdentificacion)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.txtRnc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtBeneficiario)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(902, 68)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Descripción"
        '
        'cbxTipoIdentificacion
        '
        Me.cbxTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoIdentificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoIdentificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoIdentificacion.FormattingEnabled = True
        Me.cbxTipoIdentificacion.Location = New System.Drawing.Point(9, 35)
        Me.cbxTipoIdentificacion.Name = "cbxTipoIdentificacion"
        Me.cbxTipoIdentificacion.Size = New System.Drawing.Size(220, 23)
        Me.cbxTipoIdentificacion.TabIndex = 3
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label60.Location = New System.Drawing.Point(9, 17)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(112, 15)
        Me.Label60.TabIndex = 226
        Me.Label60.Text = "Tipo de Documento"
        '
        'txtRnc
        '
        Me.txtRnc.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRnc.Location = New System.Drawing.Point(235, 35)
        Me.txtRnc.Name = "txtRnc"
        Me.txtRnc.Size = New System.Drawing.Size(183, 23)
        Me.txtRnc.TabIndex = 4
        Me.txtRnc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(913, 433)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Estadísticas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.DgvArchivos)
        Me.TabPage3.Location = New System.Drawing.Point(4, 27)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(913, 433)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Archivos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DgvArchivos
        '
        Me.DgvArchivos.AllowUserToAddRows = False
        Me.DgvArchivos.AllowUserToDeleteRows = False
        Me.DgvArchivos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvArchivos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Path, Me.Fecha, Me.Size, Me.Visual})
        Me.DgvArchivos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DgvArchivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvArchivos.Location = New System.Drawing.Point(3, 3)
        Me.DgvArchivos.MultiSelect = False
        Me.DgvArchivos.Name = "DgvArchivos"
        Me.DgvArchivos.ReadOnly = True
        Me.DgvArchivos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvArchivos.RowTemplate.Height = 70
        Me.DgvArchivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArchivos.Size = New System.Drawing.Size(907, 427)
        Me.DgvArchivos.TabIndex = 0
        '
        'Path
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Path.DefaultCellStyle = DataGridViewCellStyle1
        Me.Path.HeaderText = "Ruta"
        Me.Path.Name = "Path"
        Me.Path.ReadOnly = True
        Me.Path.Width = 400
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 160
        '
        'Size
        '
        Me.Size.HeaderText = "Tamaño en KB"
        Me.Size.Name = "Size"
        Me.Size.ReadOnly = True
        Me.Size.Width = 110
        '
        'Visual
        '
        Me.Visual.HeaderText = "Visualización"
        Me.Visual.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Visual.Name = "Visual"
        Me.Visual.ReadOnly = True
        Me.Visual.Width = 200
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(929, 24)
        Me.MenuStrip1.TabIndex = 100
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarRNCToolStripMenuItem, Me.ToolStripSeparator1, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Suplidor"
        '
        'BuscarRNCToolStripMenuItem
        '
        Me.BuscarRNCToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarRNCToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarRNCToolStripMenuItem.Name = "BuscarRNCToolStripMenuItem"
        Me.BuscarRNCToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarRNCToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.BuscarRNCToolStripMenuItem.Text = "Consultar RNC"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(210, 6)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(213, 38)
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
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(498, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 227
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
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 24)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 228
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.LabelStatus})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 637)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(929, 25)
        Me.BarraEstado.TabIndex = 414
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
        'LabelStatus
        '
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(32, 22)
        Me.LabelStatus.Text = "Listo"
        '
        'frm_mant_suplidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 662)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtIDSuplidor)
        Me.Controls.Add(Me.TbSuplidor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSuplidor)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mant_suplidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "125"
        Me.Text = "Mantenimiento de suplidores"
        Me.TbSuplidor.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DgvArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents cbxProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents cbxMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFax As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTelRep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtRepresentante As System.Windows.Forms.TextBox
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents txtWeb As System.Windows.Forms.TextBox
    Friend WithEvents txtBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaRegistro As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ChkDesactivar As System.Windows.Forms.CheckBox
    Friend WithEvents txtLimite As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TbSuplidor As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtRnc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarRNCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoIdentificacion As System.Windows.Forms.ComboBox
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtIDNcf As TextBox
    Friend WithEvents txtNCF As TextBox
    Friend WithEvents btnBuscarNCF As Button
    Friend WithEvents txtCondicion As TextBox
    Friend WithEvents btnBuscarCondicion As Button
    Friend WithEvents txtIDCondicion As TextBox
    Friend WithEvents txtTipoGasto As TextBox
    Friend WithEvents btnBuscarTipoGasto As Button
    Friend WithEvents txtIDTipoGasto As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtTipoSuplidor As TextBox
    Friend WithEvents btnBuscarTipoSuplidor As Button
    Friend WithEvents txtIDTipoSuplidor As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LabelStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents DgvArchivos As System.Windows.Forms.DataGridView
    Friend WithEvents Path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Visual As System.Windows.Forms.DataGridViewImageColumn
End Class
