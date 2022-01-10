<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_prestaciones_laborales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_prestaciones_laborales))
        Me.DgvSalarios = New System.Windows.Forms.DataGridView()
        Me.NumeroMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salarios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comisiones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Totales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IncluirTotales = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdbSemanal = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rdbDiario = New System.Windows.Forms.RadioButton()
        Me.rdbMensual = New System.Windows.Forms.RadioButton()
        Me.rdbQuincenal = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSalarioPromedioDiario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSalarioPromedioMensual = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSumaSalarios = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SeparatorControl7 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TSNavidad = New DevExpress.XtraEditors.ToggleSwitch()
        Me.TSVacaciones = New DevExpress.XtraEditors.ToggleSwitch()
        Me.TSCesantia = New DevExpress.XtraEditors.ToggleSwitch()
        Me.TsPreaviso = New DevExpress.XtraEditors.ToggleSwitch()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalRecibir = New System.Windows.Forms.TextBox()
        Me.SeparatorControl6 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl5 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtPreaviso = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCensantiaAntes = New System.Windows.Forms.TextBox()
        Me.txtTiempoLaborado = New System.Windows.Forms.TextBox()
        Me.txtCesantiaNuevo = New System.Windows.Forms.TextBox()
        Me.SeparatorControl3 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNavidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVacaciones = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnCalcular = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.PicImagen = New DevExpress.XtraEditors.PictureEdit()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.btnBuscarEmpleado = New System.Windows.Forms.Button()
        Me.lblFechaIngreso = New System.Windows.Forms.Label()
        Me.btnCleanEmpleado = New System.Windows.Forms.PictureBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvSalarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SeparatorControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.TSNavidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSVacaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSCesantia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TsPreaviso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.SeparatorControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImagen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCleanEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvSalarios
        '
        Me.DgvSalarios.AllowUserToAddRows = False
        Me.DgvSalarios.AllowUserToDeleteRows = False
        Me.DgvSalarios.AllowUserToResizeColumns = False
        Me.DgvSalarios.AllowUserToResizeRows = False
        Me.DgvSalarios.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvSalarios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvSalarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSalarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSalarios.ColumnHeadersHeight = 30
        Me.DgvSalarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvSalarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumeroMes, Me.Salarios, Me.Comisiones, Me.Totales, Me.IncluirTotales})
        Me.DgvSalarios.EnableHeadersVisualStyles = False
        Me.DgvSalarios.Location = New System.Drawing.Point(9, 105)
        Me.DgvSalarios.MultiSelect = False
        Me.DgvSalarios.Name = "DgvSalarios"
        Me.DgvSalarios.RowHeadersVisible = False
        Me.DgvSalarios.RowHeadersWidth = 54
        Me.DgvSalarios.RowTemplate.Height = 41
        Me.DgvSalarios.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DgvSalarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSalarios.Size = New System.Drawing.Size(417, 520)
        Me.DgvSalarios.TabIndex = 18
        '
        'NumeroMes
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NumeroMes.DefaultCellStyle = DataGridViewCellStyle2
        Me.NumeroMes.Frozen = True
        Me.NumeroMes.HeaderText = "No."
        Me.NumeroMes.Name = "NumeroMes"
        Me.NumeroMes.ReadOnly = True
        Me.NumeroMes.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NumeroMes.Width = 40
        '
        'Salarios
        '
        Me.Salarios.Frozen = True
        Me.Salarios.HeaderText = "Salarios"
        Me.Salarios.Name = "Salarios"
        Me.Salarios.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Comisiones
        '
        Me.Comisiones.Frozen = True
        Me.Comisiones.HeaderText = "Comisiones"
        Me.Comisiones.Name = "Comisiones"
        Me.Comisiones.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Totales
        '
        Me.Totales.Frozen = True
        Me.Totales.HeaderText = "Totales"
        Me.Totales.Name = "Totales"
        Me.Totales.ReadOnly = True
        Me.Totales.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Totales.Width = 110
        '
        'IncluirTotales
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GrayText
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.IncluirTotales.DefaultCellStyle = DataGridViewCellStyle3
        Me.IncluirTotales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IncluirTotales.HeaderText = "Completar"
        Me.IncluirTotales.Name = "IncluirTotales"
        Me.IncluirTotales.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IncluirTotales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IncluirTotales.UseColumnTextForButtonValue = True
        Me.IncluirTotales.Width = 65
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.SeparatorControl1.Location = New System.Drawing.Point(420, 55)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(22, 579)
        Me.SeparatorControl1.TabIndex = 23
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.rdbSemanal)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.rdbDiario)
        Me.Panel3.Controls.Add(Me.rdbMensual)
        Me.Panel3.Controls.Add(Me.rdbQuincenal)
        Me.Panel3.Location = New System.Drawing.Point(443, 69)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(553, 29)
        Me.Panel3.TabIndex = 22
        '
        'rdbSemanal
        '
        Me.rdbSemanal.AutoSize = True
        Me.rdbSemanal.Location = New System.Drawing.Point(296, 6)
        Me.rdbSemanal.Name = "rdbSemanal"
        Me.rdbSemanal.Size = New System.Drawing.Size(65, 17)
        Me.rdbSemanal.TabIndex = 2
        Me.rdbSemanal.Text = "Semanal"
        Me.rdbSemanal.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label11.Location = New System.Drawing.Point(33, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Seleccione el período"
        '
        'rdbDiario
        '
        Me.rdbDiario.AutoSize = True
        Me.rdbDiario.Location = New System.Drawing.Point(367, 6)
        Me.rdbDiario.Name = "rdbDiario"
        Me.rdbDiario.Size = New System.Drawing.Size(52, 17)
        Me.rdbDiario.TabIndex = 2
        Me.rdbDiario.Text = "Diario"
        Me.rdbDiario.UseVisualStyleBackColor = True
        '
        'rdbMensual
        '
        Me.rdbMensual.AutoSize = True
        Me.rdbMensual.Checked = True
        Me.rdbMensual.Location = New System.Drawing.Point(148, 6)
        Me.rdbMensual.Name = "rdbMensual"
        Me.rdbMensual.Size = New System.Drawing.Size(64, 17)
        Me.rdbMensual.TabIndex = 0
        Me.rdbMensual.TabStop = True
        Me.rdbMensual.Text = "Mensual"
        Me.rdbMensual.UseVisualStyleBackColor = True
        '
        'rdbQuincenal
        '
        Me.rdbQuincenal.AutoSize = True
        Me.rdbQuincenal.Location = New System.Drawing.Point(218, 6)
        Me.rdbQuincenal.Name = "rdbQuincenal"
        Me.rdbQuincenal.Size = New System.Drawing.Size(72, 17)
        Me.rdbQuincenal.TabIndex = 1
        Me.rdbQuincenal.Text = "Quincenal"
        Me.rdbQuincenal.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txtSalarioPromedioDiario)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtSalarioPromedioMensual)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtSumaSalarios)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.SeparatorControl7)
        Me.Panel2.Location = New System.Drawing.Point(443, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(553, 52)
        Me.Panel2.TabIndex = 21
        '
        'txtSalarioPromedioDiario
        '
        Me.txtSalarioPromedioDiario.BackColor = System.Drawing.Color.White
        Me.txtSalarioPromedioDiario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSalarioPromedioDiario.Location = New System.Drawing.Point(364, 30)
        Me.txtSalarioPromedioDiario.Name = "txtSalarioPromedioDiario"
        Me.txtSalarioPromedioDiario.ReadOnly = True
        Me.txtSalarioPromedioDiario.Size = New System.Drawing.Size(157, 13)
        Me.txtSalarioPromedioDiario.TabIndex = 2
        Me.txtSalarioPromedioDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(361, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Salario promedio diario"
        '
        'txtSalarioPromedioMensual
        '
        Me.txtSalarioPromedioMensual.BackColor = System.Drawing.Color.White
        Me.txtSalarioPromedioMensual.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSalarioPromedioMensual.Location = New System.Drawing.Point(201, 30)
        Me.txtSalarioPromedioMensual.Name = "txtSalarioPromedioMensual"
        Me.txtSalarioPromedioMensual.ReadOnly = True
        Me.txtSalarioPromedioMensual.Size = New System.Drawing.Size(157, 13)
        Me.txtSalarioPromedioMensual.TabIndex = 1
        Me.txtSalarioPromedioMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(35, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sumatoria de los salarios"
        '
        'txtSumaSalarios
        '
        Me.txtSumaSalarios.BackColor = System.Drawing.Color.White
        Me.txtSumaSalarios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSumaSalarios.Location = New System.Drawing.Point(38, 30)
        Me.txtSumaSalarios.Name = "txtSumaSalarios"
        Me.txtSumaSalarios.ReadOnly = True
        Me.txtSumaSalarios.Size = New System.Drawing.Size(157, 13)
        Me.txtSumaSalarios.TabIndex = 0
        Me.txtSumaSalarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(198, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Salario promedio mensual"
        '
        'SeparatorControl7
        '
        Me.SeparatorControl7.Location = New System.Drawing.Point(2, 11)
        Me.SeparatorControl7.Name = "SeparatorControl7"
        Me.SeparatorControl7.Size = New System.Drawing.Size(547, 23)
        Me.SeparatorControl7.TabIndex = 27
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.TSNavidad)
        Me.Panel1.Controls.Add(Me.TSVacaciones)
        Me.Panel1.Controls.Add(Me.TSCesantia)
        Me.Panel1.Controls.Add(Me.TsPreaviso)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.SeparatorControl6)
        Me.Panel1.Controls.Add(Me.SeparatorControl5)
        Me.Panel1.Controls.Add(Me.txtPreaviso)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtCensantiaAntes)
        Me.Panel1.Controls.Add(Me.txtTiempoLaborado)
        Me.Panel1.Controls.Add(Me.txtCesantiaNuevo)
        Me.Panel1.Controls.Add(Me.SeparatorControl3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtNavidad)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtVacaciones)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Location = New System.Drawing.Point(443, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 385)
        Me.Panel1.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label15.Location = New System.Drawing.Point(35, 260)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(131, 13)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Incluir salario de navidad?"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label13.Location = New System.Drawing.Point(35, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Desea incluir censantía?"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.Location = New System.Drawing.Point(35, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Ha sido usted pre-avisado?"
        '
        'TSNavidad
        '
        Me.TSNavidad.EditValue = True
        Me.TSNavidad.Location = New System.Drawing.Point(201, 255)
        Me.TSNavidad.Name = "TSNavidad"
        Me.TSNavidad.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TSNavidad.Properties.OffText = "No"
        Me.TSNavidad.Properties.OnText = "Sí"
        Me.TSNavidad.Size = New System.Drawing.Size(95, 24)
        Me.TSNavidad.TabIndex = 30
        '
        'TSVacaciones
        '
        Me.TSVacaciones.EditValue = True
        Me.TSVacaciones.Location = New System.Drawing.Point(201, 170)
        Me.TSVacaciones.Name = "TSVacaciones"
        Me.TSVacaciones.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TSVacaciones.Properties.OffText = "No"
        Me.TSVacaciones.Properties.OnText = "Sí"
        Me.TSVacaciones.Size = New System.Drawing.Size(95, 24)
        Me.TSVacaciones.TabIndex = 29
        '
        'TSCesantia
        '
        Me.TSCesantia.EditValue = True
        Me.TSCesantia.Location = New System.Drawing.Point(201, 52)
        Me.TSCesantia.Name = "TSCesantia"
        Me.TSCesantia.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TSCesantia.Properties.OffText = "No"
        Me.TSCesantia.Properties.OnText = "Sí"
        Me.TSCesantia.Size = New System.Drawing.Size(95, 24)
        Me.TSCesantia.TabIndex = 28
        '
        'TsPreaviso
        '
        Me.TsPreaviso.Location = New System.Drawing.Point(201, 7)
        Me.TsPreaviso.Name = "TsPreaviso"
        Me.TsPreaviso.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TsPreaviso.Properties.OffText = "No"
        Me.TsPreaviso.Properties.OnText = "Sí"
        Me.TsPreaviso.Size = New System.Drawing.Size(95, 24)
        Me.TsPreaviso.TabIndex = 13
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.txtSubtotal)
        Me.Panel5.Location = New System.Drawing.Point(0, 210)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(553, 35)
        Me.Panel5.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(145, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Sub-Total.:"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.BackColor = System.Drawing.Color.LightSeaGreen
        Me.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubtotal.ForeColor = System.Drawing.Color.White
        Me.txtSubtotal.Location = New System.Drawing.Point(266, 10)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(141, 13)
        Me.txtSubtotal.TabIndex = 17
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.txtTotalRecibir)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 339)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(553, 46)
        Me.Panel4.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(251, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Total a recibir.:"
        '
        'txtTotalRecibir
        '
        Me.txtTotalRecibir.BackColor = System.Drawing.Color.LightSeaGreen
        Me.txtTotalRecibir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalRecibir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRecibir.ForeColor = System.Drawing.Color.White
        Me.txtTotalRecibir.Location = New System.Drawing.Point(346, 14)
        Me.txtTotalRecibir.Name = "txtTotalRecibir"
        Me.txtTotalRecibir.ReadOnly = True
        Me.txtTotalRecibir.Size = New System.Drawing.Size(141, 14)
        Me.txtTotalRecibir.TabIndex = 24
        Me.txtTotalRecibir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SeparatorControl6
        '
        Me.SeparatorControl6.Location = New System.Drawing.Point(3, 145)
        Me.SeparatorControl6.Name = "SeparatorControl6"
        Me.SeparatorControl6.Size = New System.Drawing.Size(547, 23)
        Me.SeparatorControl6.TabIndex = 27
        '
        'SeparatorControl5
        '
        Me.SeparatorControl5.Location = New System.Drawing.Point(3, 28)
        Me.SeparatorControl5.Name = "SeparatorControl5"
        Me.SeparatorControl5.Size = New System.Drawing.Size(547, 23)
        Me.SeparatorControl5.TabIndex = 26
        '
        'txtPreaviso
        '
        Me.txtPreaviso.BackColor = System.Drawing.Color.White
        Me.txtPreaviso.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPreaviso.Location = New System.Drawing.Point(307, 13)
        Me.txtPreaviso.Name = "txtPreaviso"
        Me.txtPreaviso.ReadOnly = True
        Me.txtPreaviso.Size = New System.Drawing.Size(141, 13)
        Me.txtPreaviso.TabIndex = 9
        Me.txtPreaviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(260, 309)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Tiempo laborado"
        '
        'txtCensantiaAntes
        '
        Me.txtCensantiaAntes.BackColor = System.Drawing.Color.White
        Me.txtCensantiaAntes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCensantiaAntes.Location = New System.Drawing.Point(307, 88)
        Me.txtCensantiaAntes.Name = "txtCensantiaAntes"
        Me.txtCensantiaAntes.ReadOnly = True
        Me.txtCensantiaAntes.Size = New System.Drawing.Size(141, 13)
        Me.txtCensantiaAntes.TabIndex = 10
        Me.txtCensantiaAntes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTiempoLaborado
        '
        Me.txtTiempoLaborado.BackColor = System.Drawing.Color.White
        Me.txtTiempoLaborado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTiempoLaborado.Location = New System.Drawing.Point(352, 309)
        Me.txtTiempoLaborado.Name = "txtTiempoLaborado"
        Me.txtTiempoLaborado.ReadOnly = True
        Me.txtTiempoLaborado.Size = New System.Drawing.Size(141, 13)
        Me.txtTiempoLaborado.TabIndex = 21
        Me.txtTiempoLaborado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCesantiaNuevo
        '
        Me.txtCesantiaNuevo.BackColor = System.Drawing.Color.White
        Me.txtCesantiaNuevo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCesantiaNuevo.Location = New System.Drawing.Point(307, 126)
        Me.txtCesantiaNuevo.Name = "txtCesantiaNuevo"
        Me.txtCesantiaNuevo.ReadOnly = True
        Me.txtCesantiaNuevo.Size = New System.Drawing.Size(141, 13)
        Me.txtCesantiaNuevo.TabIndex = 11
        Me.txtCesantiaNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SeparatorControl3
        '
        Me.SeparatorControl3.Location = New System.Drawing.Point(3, 280)
        Me.SeparatorControl3.Name = "SeparatorControl3"
        Me.SeparatorControl3.Size = New System.Drawing.Size(547, 23)
        Me.SeparatorControl3.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label6.Location = New System.Drawing.Point(137, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Art. 80 C.T antes de 1992.:"
        '
        'txtNavidad
        '
        Me.txtNavidad.BackColor = System.Drawing.Color.White
        Me.txtNavidad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNavidad.Location = New System.Drawing.Point(307, 259)
        Me.txtNavidad.Name = "txtNavidad"
        Me.txtNavidad.ReadOnly = True
        Me.txtNavidad.Size = New System.Drawing.Size(141, 13)
        Me.txtNavidad.TabIndex = 19
        Me.txtNavidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label7.Location = New System.Drawing.Point(124, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(154, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Art. 80 C.T despues de 1992.:"
        '
        'txtVacaciones
        '
        Me.txtVacaciones.BackColor = System.Drawing.Color.White
        Me.txtVacaciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVacaciones.Location = New System.Drawing.Point(307, 175)
        Me.txtVacaciones.Name = "txtVacaciones"
        Me.txtVacaciones.ReadOnly = True
        Me.txtVacaciones.Size = New System.Drawing.Size(141, 13)
        Me.txtVacaciones.TabIndex = 14
        Me.txtVacaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label14.Location = New System.Drawing.Point(35, 171)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(173, 31)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Ha tomado las vacaciones correspondientes al último año?"
        '
        'BtnCalcular
        '
        Me.BtnCalcular.BackColor = System.Drawing.Color.Peru
        Me.BtnCalcular.FlatAppearance.BorderColor = System.Drawing.Color.Peru
        Me.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCalcular.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCalcular.ForeColor = System.Drawing.Color.White
        Me.BtnCalcular.Image = Global.Libregco.My.Resources.Resources.Calculatorx72
        Me.BtnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCalcular.Location = New System.Drawing.Point(443, 558)
        Me.BtnCalcular.Name = "BtnCalcular"
        Me.BtnCalcular.Size = New System.Drawing.Size(187, 64)
        Me.BtnCalcular.TabIndex = 19
        Me.BtnCalcular.Text = "CALCULAR"
        Me.BtnCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCalcular.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Fecha de salida"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Fecha de ingreso"
        '
        'dtpFechaSalida
        '
        Me.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaSalida.Location = New System.Drawing.Point(116, 78)
        Me.dtpFechaSalida.Name = "dtpFechaSalida"
        Me.dtpFechaSalida.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaSalida.TabIndex = 15
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(9, 78)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaIngreso.TabIndex = 14
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 638)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1002, 25)
        Me.BarraEstado.TabIndex = 271
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
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(0, 42)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(1002, 23)
        Me.SeparatorControl2.TabIndex = 272
        '
        'PicImagen
        '
        Me.PicImagen.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicImagen.Location = New System.Drawing.Point(9, 3)
        Me.PicImagen.Name = "PicImagen"
        Me.PicImagen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PicImagen.Properties.Appearance.Options.UseBackColor = True
        Me.PicImagen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PicImagen.Properties.OptionsMask.MaskType = DevExpress.XtraEditors.Controls.PictureEditMaskType.Circle
        Me.PicImagen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PicImagen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PicImagen.Size = New System.Drawing.Size(45, 45)
        Me.PicImagen.TabIndex = 273
        Me.PicImagen.Visible = False
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(64, 12)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(0, 13)
        Me.lblNombre.TabIndex = 274
        Me.lblNombre.Visible = False
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblCedula.Location = New System.Drawing.Point(64, 29)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(0, 13)
        Me.lblCedula.TabIndex = 275
        Me.lblCedula.Visible = False
        '
        'btnBuscarEmpleado
        '
        Me.btnBuscarEmpleado.Location = New System.Drawing.Point(5, 3)
        Me.btnBuscarEmpleado.Name = "btnBuscarEmpleado"
        Me.btnBuscarEmpleado.Size = New System.Drawing.Size(136, 45)
        Me.btnBuscarEmpleado.TabIndex = 276
        Me.btnBuscarEmpleado.Text = "Buscar empleados"
        Me.btnBuscarEmpleado.UseVisualStyleBackColor = True
        '
        'lblFechaIngreso
        '
        Me.lblFechaIngreso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaIngreso.Location = New System.Drawing.Point(520, 9)
        Me.lblFechaIngreso.Name = "lblFechaIngreso"
        Me.lblFechaIngreso.Size = New System.Drawing.Size(470, 18)
        Me.lblFechaIngreso.TabIndex = 277
        Me.lblFechaIngreso.Text = "Laborando desde el:"
        Me.lblFechaIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFechaIngreso.Visible = False
        '
        'btnCleanEmpleado
        '
        Me.btnCleanEmpleado.BackColor = System.Drawing.Color.White
        Me.btnCleanEmpleado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCleanEmpleado.Image = Global.Libregco.My.Resources.Resources.close_black
        Me.btnCleanEmpleado.Location = New System.Drawing.Point(218, 16)
        Me.btnCleanEmpleado.Name = "btnCleanEmpleado"
        Me.btnCleanEmpleado.Size = New System.Drawing.Size(15, 15)
        Me.btnCleanEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnCleanEmpleado.TabIndex = 278
        Me.btnCleanEmpleado.TabStop = False
        Me.btnCleanEmpleado.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.Clean_x72
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(819, 558)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(177, 64)
        Me.btnLimpiar.TabIndex = 279
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.Gray
        Me.Button1.Image = Global.Libregco.My.Resources.Resources.Printer_x72
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(636, 558)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(177, 64)
        Me.Button1.TabIndex = 280
        Me.Button1.Text = "IMPRIMIR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.Width = 40
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "Salarios"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "Comisiones"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "Totales"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.Width = 110
        '
        'frm_prestaciones_laborales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 663)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnBuscarEmpleado)
        Me.Controls.Add(Me.btnCleanEmpleado)
        Me.Controls.Add(Me.lblFechaIngreso)
        Me.Controls.Add(Me.lblCedula)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.PicImagen)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.DgvSalarios)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnCalcular)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFechaSalida)
        Me.Controls.Add(Me.dtpFechaIngreso)
        Me.Controls.Add(Me.SeparatorControl2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_prestaciones_laborales"
        Me.Tag = "82"
        Me.Text = "Prestaciones laborales"
        CType(Me.DgvSalarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.SeparatorControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TSNavidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSVacaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSCesantia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TsPreaviso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.SeparatorControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImagen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCleanEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DgvSalarios As DataGridView
    Friend WithEvents NumeroMes As DataGridViewTextBoxColumn
    Friend WithEvents Salarios As DataGridViewTextBoxColumn
    Friend WithEvents Comisiones As DataGridViewTextBoxColumn
    Friend WithEvents Totales As DataGridViewTextBoxColumn
    Friend WithEvents IncluirTotales As DataGridViewButtonColumn
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rdbSemanal As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents rdbDiario As RadioButton
    Friend WithEvents rdbMensual As RadioButton
    Friend WithEvents rdbQuincenal As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSalarioPromedioDiario As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSalarioPromedioMensual As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSumaSalarios As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents SeparatorControl7 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TSNavidad As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents TSVacaciones As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents TSCesantia As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents TsPreaviso As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTotalRecibir As TextBox
    Friend WithEvents SeparatorControl6 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl5 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents txtPreaviso As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCensantiaAntes As TextBox
    Friend WithEvents txtTiempoLaborado As TextBox
    Friend WithEvents txtCesantiaNuevo As TextBox
    Friend WithEvents SeparatorControl3 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNavidad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtVacaciones As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BtnCalcular As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaSalida As DateTimePicker
    Friend WithEvents dtpFechaIngreso As DateTimePicker
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents PicImagen As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblCedula As Label
    Friend WithEvents btnBuscarEmpleado As Button
    Friend WithEvents lblFechaIngreso As Label
    Friend WithEvents btnCleanEmpleado As PictureBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Button1 As Button
End Class
