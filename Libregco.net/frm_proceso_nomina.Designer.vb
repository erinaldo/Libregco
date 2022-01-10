<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_proceso_nomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_proceso_nomina))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarTipoNominaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalarioDeNavidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIDTipoNomina = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipoNomina = New System.Windows.Forms.TextBox()
        Me.Gb2 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkMensual = New System.Windows.Forms.CheckBox()
        Me.chkQuincenal = New System.Windows.Forms.CheckBox()
        Me.chkSemanal = New System.Windows.Forms.CheckBox()
        Me.chkDiario = New System.Windows.Forms.CheckBox()
        Me.GbDatos = New System.Windows.Forms.GroupBox()
        Me.btnBuscarEmpleados = New System.Windows.Forms.Button()
        Me.btnBuscarNomina = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtIDNomina = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DgvEmpleados = New System.Windows.Forms.DataGridView()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.txtCantidadEmpleados = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalBruto = New System.Windows.Forms.TextBox()
        Me.txtTotalDeducciones = New System.Windows.Forms.TextBox()
        Me.txtTotalNeto = New System.Windows.Forms.TextBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicMinLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.txtDeduccionesCorrientes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.Gb2.SuspendLayout()
        Me.GbDatos.SuspendLayout()
        CType(Me.DgvEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(281, 27)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 289
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1210, 24)
        Me.MenuStrip1.TabIndex = 288
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarTipoNominaToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.SalarioDeNavidadToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(249, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(249, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarTipoNominaToolStripMenuItem
        '
        Me.BuscarTipoNominaToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarTipoNominaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarTipoNominaToolStripMenuItem.Name = "BuscarTipoNominaToolStripMenuItem"
        Me.BuscarTipoNominaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.BuscarTipoNominaToolStripMenuItem.Size = New System.Drawing.Size(249, 38)
        Me.BuscarTipoNominaToolStripMenuItem.Text = "Buscar tipo de nómina"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(249, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar empleados"
        '
        'SalarioDeNavidadToolStripMenuItem
        '
        Me.SalarioDeNavidadToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Christmasx32
        Me.SalarioDeNavidadToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalarioDeNavidadToolStripMenuItem.Name = "SalarioDeNavidadToolStripMenuItem"
        Me.SalarioDeNavidadToolStripMenuItem.Size = New System.Drawing.Size(249, 38)
        Me.SalarioDeNavidadToolStripMenuItem.Text = "Salario de navidad"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(246, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(249, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarCompraToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'BuscarCompraToolStripMenuItem
        '
        Me.BuscarCompraToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarCompraToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarCompraToolStripMenuItem.Name = "BuscarCompraToolStripMenuItem"
        Me.BuscarCompraToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarCompraToolStripMenuItem.Size = New System.Drawing.Size(175, 38)
        Me.BuscarCompraToolStripMenuItem.Text = "Historial"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(175, 38)
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
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(173, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'DtpFechaInicial
        '
        Me.DtpFechaInicial.CustomFormat = ""
        Me.DtpFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaInicial.Location = New System.Drawing.Point(84, 15)
        Me.DtpFechaInicial.Name = "DtpFechaInicial"
        Me.DtpFechaInicial.Size = New System.Drawing.Size(100, 23)
        Me.DtpFechaInicial.TabIndex = 0
        '
        'DtpFechaFinal
        '
        Me.DtpFechaFinal.CustomFormat = ""
        Me.DtpFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFinal.Location = New System.Drawing.Point(262, 15)
        Me.DtpFechaFinal.Name = "DtpFechaFinal"
        Me.DtpFechaFinal.Size = New System.Drawing.Size(100, 23)
        Me.DtpFechaFinal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 293
        Me.Label1.Text = "Fecha Inicial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(190, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 294
        Me.Label2.Text = "Fecha Final"
        '
        'txtIDTipoNomina
        '
        Me.txtIDTipoNomina.Enabled = False
        Me.txtIDTipoNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoNomina.Location = New System.Drawing.Point(84, 44)
        Me.txtIDTipoNomina.Name = "txtIDTipoNomina"
        Me.txtIDTipoNomina.ReadOnly = True
        Me.txtIDTipoNomina.Size = New System.Drawing.Size(73, 23)
        Me.txtIDTipoNomina.TabIndex = 295
        Me.txtIDTipoNomina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 296
        Me.Label3.Text = "Nómina"
        '
        'txtTipoNomina
        '
        Me.txtTipoNomina.Enabled = False
        Me.txtTipoNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoNomina.Location = New System.Drawing.Point(178, 44)
        Me.txtTipoNomina.Name = "txtTipoNomina"
        Me.txtTipoNomina.ReadOnly = True
        Me.txtTipoNomina.Size = New System.Drawing.Size(315, 23)
        Me.txtTipoNomina.TabIndex = 298
        '
        'Gb2
        '
        Me.Gb2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gb2.Controls.Add(Me.CheckBox1)
        Me.Gb2.Controls.Add(Me.chkMensual)
        Me.Gb2.Controls.Add(Me.chkQuincenal)
        Me.Gb2.Controls.Add(Me.chkSemanal)
        Me.Gb2.Controls.Add(Me.chkDiario)
        Me.Gb2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gb2.Location = New System.Drawing.Point(508, 122)
        Me.Gb2.Name = "Gb2"
        Me.Gb2.Size = New System.Drawing.Size(328, 74)
        Me.Gb2.TabIndex = 3
        Me.Gb2.TabStop = False
        Me.Gb2.Text = "Frecuencia de Pago"
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CheckBox1.Location = New System.Drawing.Point(213, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(119, 19)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Seleccionar todos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkMensual
        '
        Me.chkMensual.AutoSize = True
        Me.chkMensual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkMensual.Location = New System.Drawing.Point(243, 31)
        Me.chkMensual.Name = "chkMensual"
        Me.chkMensual.Size = New System.Drawing.Size(71, 19)
        Me.chkMensual.TabIndex = 6
        Me.chkMensual.Text = "Mensual"
        Me.chkMensual.UseVisualStyleBackColor = True
        '
        'chkQuincenal
        '
        Me.chkQuincenal.AutoSize = True
        Me.chkQuincenal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkQuincenal.Location = New System.Drawing.Point(157, 31)
        Me.chkQuincenal.Name = "chkQuincenal"
        Me.chkQuincenal.Size = New System.Drawing.Size(80, 19)
        Me.chkQuincenal.TabIndex = 5
        Me.chkQuincenal.Text = "Quincenal"
        Me.chkQuincenal.UseVisualStyleBackColor = True
        '
        'chkSemanal
        '
        Me.chkSemanal.AutoSize = True
        Me.chkSemanal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkSemanal.Location = New System.Drawing.Point(80, 31)
        Me.chkSemanal.Name = "chkSemanal"
        Me.chkSemanal.Size = New System.Drawing.Size(71, 19)
        Me.chkSemanal.TabIndex = 4
        Me.chkSemanal.Text = "Semanal"
        Me.chkSemanal.UseVisualStyleBackColor = True
        '
        'chkDiario
        '
        Me.chkDiario.AutoSize = True
        Me.chkDiario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkDiario.Location = New System.Drawing.Point(17, 31)
        Me.chkDiario.Name = "chkDiario"
        Me.chkDiario.Size = New System.Drawing.Size(57, 19)
        Me.chkDiario.TabIndex = 3
        Me.chkDiario.Text = "Diario"
        Me.chkDiario.UseVisualStyleBackColor = True
        '
        'GbDatos
        '
        Me.GbDatos.Controls.Add(Me.btnBuscarEmpleados)
        Me.GbDatos.Controls.Add(Me.btnBuscarNomina)
        Me.GbDatos.Controls.Add(Me.Label1)
        Me.GbDatos.Controls.Add(Me.DtpFechaInicial)
        Me.GbDatos.Controls.Add(Me.txtTipoNomina)
        Me.GbDatos.Controls.Add(Me.DtpFechaFinal)
        Me.GbDatos.Controls.Add(Me.Label2)
        Me.GbDatos.Controls.Add(Me.Label3)
        Me.GbDatos.Controls.Add(Me.txtIDTipoNomina)
        Me.GbDatos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbDatos.Location = New System.Drawing.Point(3, 122)
        Me.GbDatos.Name = "GbDatos"
        Me.GbDatos.Size = New System.Drawing.Size(499, 74)
        Me.GbDatos.TabIndex = 0
        Me.GbDatos.TabStop = False
        Me.GbDatos.Text = "Datos Nómina"
        '
        'btnBuscarEmpleados
        '
        Me.btnBuscarEmpleados.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscarEmpleados.Location = New System.Drawing.Point(368, 14)
        Me.btnBuscarEmpleados.Name = "btnBuscarEmpleados"
        Me.btnBuscarEmpleados.Size = New System.Drawing.Size(125, 24)
        Me.btnBuscarEmpleados.TabIndex = 333
        Me.btnBuscarEmpleados.Text = "Buscar empleados"
        Me.btnBuscarEmpleados.UseVisualStyleBackColor = True
        '
        'btnBuscarNomina
        '
        Me.btnBuscarNomina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarNomina.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarNomina.Image = CType(resources.GetObject("btnBuscarNomina.Image"), System.Drawing.Image)
        Me.btnBuscarNomina.Location = New System.Drawing.Point(156, 44)
        Me.btnBuscarNomina.Name = "btnBuscarNomina"
        Me.btnBuscarNomina.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarNomina.TabIndex = 324
        Me.btnBuscarNomina.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(63, 44)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(113, 23)
        Me.txtFecha.TabIndex = 253
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDNomina
        '
        Me.txtIDNomina.Enabled = False
        Me.txtIDNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNomina.Location = New System.Drawing.Point(63, 15)
        Me.txtIDNomina.Name = "txtIDNomina"
        Me.txtIDNomina.ReadOnly = True
        Me.txtIDNomina.Size = New System.Drawing.Size(113, 23)
        Me.txtIDNomina.TabIndex = 248
        Me.txtIDNomina.TabStop = False
        Me.txtIDNomina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(7, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Nómina"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(7, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(221, 44)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(139, 23)
        Me.txtHora.TabIndex = 251
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(182, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 15)
        Me.Label4.TabIndex = 252
        Me.Label4.Text = "Hora"
        '
        'DgvEmpleados
        '
        Me.DgvEmpleados.AllowUserToAddRows = False
        Me.DgvEmpleados.AllowUserToDeleteRows = False
        Me.DgvEmpleados.AllowUserToResizeColumns = False
        Me.DgvEmpleados.AllowUserToResizeRows = False
        Me.DgvEmpleados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvEmpleados.BackgroundColor = System.Drawing.Color.MintCream
        Me.DgvEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvEmpleados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvEmpleados.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvEmpleados.Location = New System.Drawing.Point(3, 202)
        Me.DgvEmpleados.MultiSelect = False
        Me.DgvEmpleados.Name = "DgvEmpleados"
        Me.DgvEmpleados.RowHeadersWidth = 50
        Me.DgvEmpleados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvEmpleados.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.DgvEmpleados.RowTemplate.Height = 25
        Me.DgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvEmpleados.Size = New System.Drawing.Size(1203, 395)
        Me.DgvEmpleados.TabIndex = 302
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Location = New System.Drawing.Point(108, 102)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 305
        '
        'txtCantidadEmpleados
        '
        Me.txtCantidadEmpleados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCantidadEmpleados.BackColor = System.Drawing.SystemColors.Info
        Me.txtCantidadEmpleados.Enabled = False
        Me.txtCantidadEmpleados.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadEmpleados.Location = New System.Drawing.Point(111, 603)
        Me.txtCantidadEmpleados.Name = "txtCantidadEmpleados"
        Me.txtCantidadEmpleados.Size = New System.Drawing.Size(68, 23)
        Me.txtCantidadEmpleados.TabIndex = 316
        Me.txtCantidadEmpleados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(9, 607)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 15)
        Me.Label8.TabIndex = 299
        Me.Label8.Text = "Cant. Empleados"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(451, 619)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 15)
        Me.Label9.TabIndex = 317
        Me.Label9.Text = "Sueldos brutos totales"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(825, 619)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 15)
        Me.Label10.TabIndex = 318
        Me.Label10.Text = "Ingresos y deducciones totales"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(1012, 619)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 15)
        Me.Label11.TabIndex = 319
        Me.Label11.Text = "Total neto de nómina"
        '
        'txtTotalBruto
        '
        Me.txtTotalBruto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalBruto.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalBruto.Enabled = False
        Me.txtTotalBruto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalBruto.Location = New System.Drawing.Point(454, 637)
        Me.txtTotalBruto.Name = "txtTotalBruto"
        Me.txtTotalBruto.Size = New System.Drawing.Size(181, 23)
        Me.txtTotalBruto.TabIndex = 321
        Me.txtTotalBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalDeducciones
        '
        Me.txtTotalDeducciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDeducciones.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalDeducciones.Enabled = False
        Me.txtTotalDeducciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalDeducciones.Location = New System.Drawing.Point(828, 637)
        Me.txtTotalDeducciones.Name = "txtTotalDeducciones"
        Me.txtTotalDeducciones.Size = New System.Drawing.Size(181, 23)
        Me.txtTotalDeducciones.TabIndex = 322
        Me.txtTotalDeducciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalNeto.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalNeto.Enabled = False
        Me.txtTotalNeto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalNeto.Location = New System.Drawing.Point(1015, 637)
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.Size = New System.Drawing.Size(181, 23)
        Me.txtTotalNeto.TabIndex = 323
        Me.txtTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(778, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 324
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.GuardarToolStripMenuItem, Me.btnBuscar, Me.btnAnular, Me.btnImprimir})
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
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.GuardarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.GuardarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(84, 95)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        Me.GuardarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.btnImprimir.Checked = True
        Me.btnImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x72
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 95)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(182, 14)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(178, 23)
        Me.txtSecondID.TabIndex = 254
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtIDNomina)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.Label4)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.Label7)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(842, 122)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(366, 74)
        Me.GbxUserInfo.TabIndex = 325
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicMinLogo, Me.NameSys, Me.ToolSeparator2, Me.LabelStatus})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 677)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1210, 25)
        Me.BarraEstado.TabIndex = 330
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicMinLogo
        '
        Me.PicMinLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicMinLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicMinLogo.Name = "PicMinLogo"
        Me.PicMinLogo.Size = New System.Drawing.Size(23, 22)
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
        'txtDeduccionesCorrientes
        '
        Me.txtDeduccionesCorrientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeduccionesCorrientes.BackColor = System.Drawing.SystemColors.Info
        Me.txtDeduccionesCorrientes.Enabled = False
        Me.txtDeduccionesCorrientes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDeduccionesCorrientes.Location = New System.Drawing.Point(641, 637)
        Me.txtDeduccionesCorrientes.Name = "txtDeduccionesCorrientes"
        Me.txtDeduccionesCorrientes.Size = New System.Drawing.Size(181, 23)
        Me.txtDeduccionesCorrientes.TabIndex = 332
        Me.txtDeduccionesCorrientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(638, 619)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 15)
        Me.Label5.TabIndex = 331
        Me.Label5.Text = "Deducciones corrientes"
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(4, 29)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 327
        Me.PicBoxLogo.TabStop = False
        '
        'frm_proceso_nomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 702)
        Me.Controls.Add(Me.txtDeduccionesCorrientes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.txtTotalNeto)
        Me.Controls.Add(Me.txtTotalDeducciones)
        Me.Controls.Add(Me.txtTotalBruto)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCantidadEmpleados)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.DgvEmpleados)
        Me.Controls.Add(Me.GbDatos)
        Me.Controls.Add(Me.Gb2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frm_proceso_nomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "156"
        Me.Text = "Nóminas"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Gb2.ResumeLayout(False)
        Me.Gb2.PerformLayout()
        Me.GbDatos.ResumeLayout(False)
        Me.GbDatos.PerformLayout()
        CType(Me.DgvEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIDTipoNomina As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTipoNomina As System.Windows.Forms.TextBox
    Friend WithEvents Gb2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkMensual As System.Windows.Forms.CheckBox
    Friend WithEvents chkQuincenal As System.Windows.Forms.CheckBox
    Friend WithEvents chkSemanal As System.Windows.Forms.CheckBox
    Friend WithEvents chkDiario As System.Windows.Forms.CheckBox
    Friend WithEvents GbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNomina As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DgvEmpleados As System.Windows.Forms.DataGridView
    Private WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents txtCantidadEmpleados As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalBruto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDeducciones As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents BuscarTipoNominaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarNomina As Button
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnAnular As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents txtSecondID As TextBox
    Friend WithEvents GbxUserInfo As GroupBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicMinLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LabelStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtDeduccionesCorrientes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SalarioDeNavidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnBuscarEmpleados As Button
End Class
