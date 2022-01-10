<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_agenda_cheques
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
        Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler3 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_agenda_cheques))
        Me.chkEspecificarVenc = New System.Windows.Forms.CheckBox()
        Me.dtpIngresoFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpIngresoInicial = New System.Windows.Forms.DateTimePicker()
        Me.DgvCheques = New System.Windows.Forms.DataGridView()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Beneficiario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.txtTransHoy = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SchedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.AccordionContentContainer2 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.lblLimiteReserva = New System.Windows.Forms.Label()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.lblTitular = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxCuenta = New System.Windows.Forms.ComboBox()
        Me.AccordionContentContainer3 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.AccordionContentContainer4 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTransMes = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTransSemana = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTransManana = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement5 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement6 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionContentContainer1 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.SchedulerControl2 = New DevExpress.XtraScheduler.SchedulerControl()
        Me.SchedulerStorage2 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.DgvCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccordionControl1.SuspendLayout()
        Me.AccordionContentContainer2.SuspendLayout()
        Me.AccordionContentContainer3.SuspendLayout()
        Me.AccordionContentContainer4.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.SchedulerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerStorage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkEspecificarVenc
        '
        Me.chkEspecificarVenc.AutoSize = True
        Me.chkEspecificarVenc.Checked = True
        Me.chkEspecificarVenc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEspecificarVenc.Location = New System.Drawing.Point(10, 3)
        Me.chkEspecificarVenc.Name = "chkEspecificarVenc"
        Me.chkEspecificarVenc.Size = New System.Drawing.Size(94, 17)
        Me.chkEspecificarVenc.TabIndex = 16
        Me.chkEspecificarVenc.Text = "Sin Especificar"
        Me.chkEspecificarVenc.UseVisualStyleBackColor = True
        '
        'dtpIngresoFinal
        '
        Me.dtpIngresoFinal.CustomFormat = ""
        Me.dtpIngresoFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpIngresoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIngresoFinal.Location = New System.Drawing.Point(53, 47)
        Me.dtpIngresoFinal.Name = "dtpIngresoFinal"
        Me.dtpIngresoFinal.Size = New System.Drawing.Size(99, 23)
        Me.dtpIngresoFinal.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(8, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 15)
        Me.Label11.TabIndex = 280
        Me.Label11.Text = "Del"
        '
        'dtpIngresoInicial
        '
        Me.dtpIngresoInicial.CustomFormat = ""
        Me.dtpIngresoInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpIngresoInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIngresoInicial.Location = New System.Drawing.Point(53, 22)
        Me.dtpIngresoInicial.Name = "dtpIngresoInicial"
        Me.dtpIngresoInicial.Size = New System.Drawing.Size(99, 23)
        Me.dtpIngresoInicial.TabIndex = 17
        '
        'DgvCheques
        '
        Me.DgvCheques.AllowUserToAddRows = False
        Me.DgvCheques.AllowUserToDeleteRows = False
        Me.DgvCheques.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DgvCheques.BackgroundColor = System.Drawing.Color.White
        Me.DgvCheques.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCheques.ColumnHeadersHeight = 40
        Me.DgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.NoCheque, Me.Beneficiario, Me.Monto})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvCheques.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvCheques.Location = New System.Drawing.Point(3, 3)
        Me.DgvCheques.Name = "DgvCheques"
        Me.DgvCheques.ReadOnly = True
        Me.DgvCheques.RowHeadersVisible = False
        Me.DgvCheques.RowTemplate.Height = 36
        Me.DgvCheques.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCheques.Size = New System.Drawing.Size(871, 512)
        Me.DgvCheques.TabIndex = 264
        '
        'Cuenta
        '
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.Width = 220
        '
        'NoCheque
        '
        Me.NoCheque.HeaderText = "No."
        Me.NoCheque.Name = "NoCheque"
        Me.NoCheque.ReadOnly = True
        Me.NoCheque.Width = 140
        '
        'Beneficiario
        '
        Me.Beneficiario.HeaderText = "Beneficiario"
        Me.Beneficiario.Name = "Beneficiario"
        Me.Beneficiario.ReadOnly = True
        Me.Beneficiario.Width = 378
        '
        'Monto
        '
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        Me.Monto.Width = 130
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 598)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1158, 25)
        Me.BarraEstado.TabIndex = 450
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
        'txtTransHoy
        '
        Me.txtTransHoy.Location = New System.Drawing.Point(84, 24)
        Me.txtTransHoy.Name = "txtTransHoy"
        Me.txtTransHoy.ReadOnly = True
        Me.txtTransHoy.Size = New System.Drawing.Size(144, 20)
        Me.txtTransHoy.TabIndex = 451
        Me.txtTransHoy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 452
        Me.Label1.Text = "Cheques restantes para"
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer2)
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer3)
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer4)
        Me.AccordionControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1})
        Me.AccordionControl1.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple
        Me.AccordionControl1.ExpandGroupOnHeaderClick = False
        Me.AccordionControl1.ExpandItemOnHeaderClick = False
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ShowGroupExpandButtons = False
        Me.AccordionControl1.Size = New System.Drawing.Size(257, 598)
        Me.AccordionControl1.TabIndex = 460
        Me.AccordionControl1.Text = "AccordionControl1"
        '
        'AccordionContentContainer2
        '
        Me.AccordionContentContainer2.Controls.Add(Me.lblLimiteReserva)
        Me.AccordionContentContainer2.Controls.Add(Me.lblBalance)
        Me.AccordionContentContainer2.Controls.Add(Me.lblTitular)
        Me.AccordionContentContainer2.Controls.Add(Me.Label9)
        Me.AccordionContentContainer2.Controls.Add(Me.Label8)
        Me.AccordionContentContainer2.Controls.Add(Me.Label7)
        Me.AccordionContentContainer2.Controls.Add(Me.cbxCuenta)
        Me.AccordionContentContainer2.Name = "AccordionContentContainer2"
        Me.AccordionContentContainer2.Size = New System.Drawing.Size(240, 149)
        Me.AccordionContentContainer2.TabIndex = 1
        '
        'lblLimiteReserva
        '
        Me.lblLimiteReserva.AutoSize = True
        Me.lblLimiteReserva.Location = New System.Drawing.Point(15, 125)
        Me.lblLimiteReserva.Name = "lblLimiteReserva"
        Me.lblLimiteReserva.Size = New System.Drawing.Size(0, 13)
        Me.lblLimiteReserva.TabIndex = 6
        '
        'lblBalance
        '
        Me.lblBalance.AutoSize = True
        Me.lblBalance.Location = New System.Drawing.Point(15, 90)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(0, 13)
        Me.lblBalance.TabIndex = 5
        '
        'lblTitular
        '
        Me.lblTitular.AutoSize = True
        Me.lblTitular.Location = New System.Drawing.Point(15, 54)
        Me.lblTitular.Name = "lblTitular"
        Me.lblTitular.Size = New System.Drawing.Size(0, 13)
        Me.lblTitular.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(15, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Límite de reserva"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(15, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Balance"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(15, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Titular"
        '
        'cbxCuenta
        '
        Me.cbxCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCuenta.FormattingEnabled = True
        Me.cbxCuenta.Location = New System.Drawing.Point(10, 7)
        Me.cbxCuenta.Name = "cbxCuenta"
        Me.cbxCuenta.Size = New System.Drawing.Size(218, 21)
        Me.cbxCuenta.TabIndex = 0
        '
        'AccordionContentContainer3
        '
        Me.AccordionContentContainer3.Controls.Add(Me.Label6)
        Me.AccordionContentContainer3.Controls.Add(Me.chkEspecificarVenc)
        Me.AccordionContentContainer3.Controls.Add(Me.dtpIngresoFinal)
        Me.AccordionContentContainer3.Controls.Add(Me.dtpIngresoInicial)
        Me.AccordionContentContainer3.Controls.Add(Me.Label11)
        Me.AccordionContentContainer3.Name = "AccordionContentContainer3"
        Me.AccordionContentContainer3.Size = New System.Drawing.Size(240, 75)
        Me.AccordionContentContainer3.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 15)
        Me.Label6.TabIndex = 281
        Me.Label6.Text = "Hasta"
        '
        'AccordionContentContainer4
        '
        Me.AccordionContentContainer4.Controls.Add(Me.Label5)
        Me.AccordionContentContainer4.Controls.Add(Me.txtTransMes)
        Me.AccordionContentContainer4.Controls.Add(Me.Label4)
        Me.AccordionContentContainer4.Controls.Add(Me.txtTransSemana)
        Me.AccordionContentContainer4.Controls.Add(Me.Label3)
        Me.AccordionContentContainer4.Controls.Add(Me.txtTransManana)
        Me.AccordionContentContainer4.Controls.Add(Me.Label2)
        Me.AccordionContentContainer4.Controls.Add(Me.Label1)
        Me.AccordionContentContainer4.Controls.Add(Me.txtTransHoy)
        Me.AccordionContentContainer4.Name = "AccordionContentContainer4"
        Me.AccordionContentContainer4.Size = New System.Drawing.Size(240, 139)
        Me.AccordionContentContainer4.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 459
        Me.Label5.Text = "- Mes"
        '
        'txtTransMes
        '
        Me.txtTransMes.Location = New System.Drawing.Point(84, 102)
        Me.txtTransMes.Name = "txtTransMes"
        Me.txtTransMes.ReadOnly = True
        Me.txtTransMes.Size = New System.Drawing.Size(144, 20)
        Me.txtTransMes.TabIndex = 458
        Me.txtTransMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 457
        Me.Label4.Text = "- Semana"
        '
        'txtTransSemana
        '
        Me.txtTransSemana.Location = New System.Drawing.Point(84, 76)
        Me.txtTransSemana.Name = "txtTransSemana"
        Me.txtTransSemana.ReadOnly = True
        Me.txtTransSemana.Size = New System.Drawing.Size(144, 20)
        Me.txtTransSemana.TabIndex = 456
        Me.txtTransSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 455
        Me.Label3.Text = "- Mañana"
        '
        'txtTransManana
        '
        Me.txtTransManana.Location = New System.Drawing.Point(84, 50)
        Me.txtTransManana.Name = "txtTransManana"
        Me.txtTransManana.ReadOnly = True
        Me.txtTransManana.Size = New System.Drawing.Size(144, 20)
        Me.txtTransManana.TabIndex = 454
        Me.txtTransManana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 453
        Me.Label2.Text = "- Hoy"
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement4, Me.AccordionControlElement5, Me.AccordionControlElement6})
        Me.AccordionControlElement1.Expanded = True
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Text = "Cuenta Bancaria"
        '
        'AccordionControlElement4
        '
        Me.AccordionControlElement4.ContentContainer = Me.AccordionContentContainer2
        Me.AccordionControlElement4.Expanded = True
        Me.AccordionControlElement4.Name = "AccordionControlElement4"
        Me.AccordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement4.Text = "No. de Cuenta"
        '
        'AccordionControlElement5
        '
        Me.AccordionControlElement5.ContentContainer = Me.AccordionContentContainer3
        Me.AccordionControlElement5.Expanded = True
        Me.AccordionControlElement5.Name = "AccordionControlElement5"
        Me.AccordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement5.Text = "Rango de fechas"
        '
        'AccordionControlElement6
        '
        Me.AccordionControlElement6.ContentContainer = Me.AccordionContentContainer4
        Me.AccordionControlElement6.Expanded = True
        Me.AccordionControlElement6.Name = "AccordionControlElement6"
        Me.AccordionControlElement6.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement6.Text = "Resultados del período"
        '
        'AccordionControlElement2
        '
        Me.AccordionControlElement2.Expanded = True
        Me.AccordionControlElement2.Name = "AccordionControlElement2"
        Me.AccordionControlElement2.Text = "No. de Cuenta"
        '
        'AccordionControlElement3
        '
        Me.AccordionControlElement3.Expanded = True
        Me.AccordionControlElement3.Name = "AccordionControlElement3"
        Me.AccordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement3.Text = "Element3"
        '
        'AccordionContentContainer1
        '
        Me.AccordionContentContainer1.Name = "AccordionContentContainer1"
        Me.AccordionContentContainer1.Size = New System.Drawing.Size(230, 76)
        Me.AccordionContentContainer1.TabIndex = 1
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(263, 4)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(883, 591)
        Me.XtraTabControl1.TabIndex = 461
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.SchedulerControl2)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(877, 563)
        Me.XtraTabPage1.Text = "Agenda"
        '
        'SchedulerControl2
        '
        Me.SchedulerControl2.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month
        Me.SchedulerControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SchedulerControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.SchedulerControl2.DataStorage = Me.SchedulerStorage2
        Me.SchedulerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SchedulerControl2.Name = "SchedulerControl2"
        Me.SchedulerControl2.Size = New System.Drawing.Size(877, 563)
        Me.SchedulerControl2.Start = New Date(2019, 5, 12, 0, 0, 0, 0)
        Me.SchedulerControl2.TabIndex = 460
        Me.SchedulerControl2.Text = "SchedulerControl2"
        Me.SchedulerControl2.Views.DayView.TimeRulers.Add(TimeRuler1)
        Me.SchedulerControl2.Views.FullWeekView.Enabled = True
        Me.SchedulerControl2.Views.FullWeekView.TimeRulers.Add(TimeRuler2)
        Me.SchedulerControl2.Views.WorkWeekView.TimeRulers.Add(TimeRuler3)
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.DgvCheques)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(877, 563)
        Me.XtraTabPage2.Text = "Tabla de transacciones"
        '
        'frm_agenda_cheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1158, 623)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_agenda_cheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agenda de cheques"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DgvCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccordionControl1.ResumeLayout(False)
        Me.AccordionContentContainer2.ResumeLayout(False)
        Me.AccordionContentContainer2.PerformLayout()
        Me.AccordionContentContainer3.ResumeLayout(False)
        Me.AccordionContentContainer3.PerformLayout()
        Me.AccordionContentContainer4.ResumeLayout(False)
        Me.AccordionContentContainer4.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.SchedulerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerStorage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkEspecificarVenc As System.Windows.Forms.CheckBox
    Friend WithEvents dtpIngresoFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpIngresoInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents DgvCheques As System.Windows.Forms.DataGridView
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtTransHoy As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SchedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents AccordionContentContainer2 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionContentContainer3 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement5 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionContentContainer1 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cbxCuenta As ComboBox
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents NoCheque As DataGridViewTextBoxColumn
    Friend WithEvents Beneficiario As DataGridViewTextBoxColumn
    Friend WithEvents Monto As DataGridViewTextBoxColumn
    Friend WithEvents lblLimiteReserva As Label
    Friend WithEvents lblBalance As Label
    Friend WithEvents lblTitular As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents AccordionControlElement6 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents AccordionContentContainer4 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTransMes As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTransSemana As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTransManana As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SchedulerControl2 As DevExpress.XtraScheduler.SchedulerControl
    Friend WithEvents SchedulerStorage2 As DevExpress.XtraScheduler.SchedulerStorage
End Class
