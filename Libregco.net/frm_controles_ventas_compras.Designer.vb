<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_controles_ventas_compras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_controles_ventas_compras))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtVNotDeb = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtVNotaCred = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtVItbis = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVNotaCredNCF = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVNotDebNCF = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtVTotal = New System.Windows.Forms.TextBox()
        Me.txtVOperacionEspecial = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVGubernamental = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVSinValorFiscal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVCreditoFiscal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVConsumidorFinal = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCNotaCred = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtCNotDeb = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCItbis = New System.Windows.Forms.TextBox()
        Me.txtCNotaCredNCF = New System.Windows.Forms.TextBox()
        Me.txtCNotDebNCF = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCTotalGeneral = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCOperacionesEsp = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCGubernamental = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCSinValorFiscal = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtCCreditoFiscal = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCConsumidorFinal = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPresentar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbOpciones = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxTipoOrden = New System.Windows.Forms.ComboBox()
        Me.CbxOrden = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.PicSalida = New System.Windows.Forms.PictureBox()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.txtTamañoLetra = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.txtTamañoLetra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaFinal)
        Me.GroupBox1.Controls.Add(Me.txtFechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(199, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criterios de Búsqueda"
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.CustomFormat = ""
        Me.txtFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaFinal.Location = New System.Drawing.Point(91, 48)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(100, 23)
        Me.txtFechaFinal.TabIndex = 351
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.CustomFormat = ""
        Me.txtFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicial.Location = New System.Drawing.Point(91, 22)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Size = New System.Drawing.Size(100, 23)
        Me.txtFechaInicial.TabIndex = 350
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Fecha Final:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(10, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fecha Inicial:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.txtVNotDeb)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtVNotaCred)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtVItbis)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtVNotaCredNCF)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtVNotDebNCF)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtVTotal)
        Me.GroupBox3.Controls.Add(Me.txtVOperacionEspecial)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtVGubernamental)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtVSinValorFiscal)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtVCreditoFiscal)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtVConsumidorFinal)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(346, 373)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ventas"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label23.Location = New System.Drawing.Point(11, 243)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(131, 20)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "Notas Débito ..........:"
        '
        'txtVNotDeb
        '
        Me.txtVNotDeb.BackColor = System.Drawing.SystemColors.Info
        Me.txtVNotDeb.Enabled = False
        Me.txtVNotDeb.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVNotDeb.Location = New System.Drawing.Point(148, 240)
        Me.txtVNotDeb.Name = "txtVNotDeb"
        Me.txtVNotDeb.Size = New System.Drawing.Size(190, 26)
        Me.txtVNotDeb.TabIndex = 21
        Me.txtVNotDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label24.Location = New System.Drawing.Point(11, 307)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(135, 20)
        Me.Label24.TabIndex = 20
        Me.Label24.Text = "Notas Crédito ..........:"
        '
        'txtVNotaCred
        '
        Me.txtVNotaCred.BackColor = System.Drawing.SystemColors.Info
        Me.txtVNotaCred.Enabled = False
        Me.txtVNotaCred.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVNotaCred.Location = New System.Drawing.Point(150, 304)
        Me.txtVNotaCred.Name = "txtVNotaCred"
        Me.txtVNotaCred.Size = New System.Drawing.Size(190, 26)
        Me.txtVNotaCred.TabIndex = 19
        Me.txtVNotaCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 21)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Operac. Especiales:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(86, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 21)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "I.T.B.I.S:"
        '
        'txtVItbis
        '
        Me.txtVItbis.BackColor = System.Drawing.Color.PapayaWhip
        Me.txtVItbis.Enabled = False
        Me.txtVItbis.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVItbis.Location = New System.Drawing.Point(150, 208)
        Me.txtVItbis.Name = "txtVItbis"
        Me.txtVItbis.Size = New System.Drawing.Size(190, 26)
        Me.txtVItbis.TabIndex = 16
        Me.txtVItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label10.Location = New System.Drawing.Point(11, 339)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 20)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Notas Crédito NCF:"
        '
        'txtVNotaCredNCF
        '
        Me.txtVNotaCredNCF.BackColor = System.Drawing.SystemColors.Info
        Me.txtVNotaCredNCF.Enabled = False
        Me.txtVNotaCredNCF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVNotaCredNCF.Location = New System.Drawing.Point(150, 336)
        Me.txtVNotaCredNCF.Name = "txtVNotaCredNCF"
        Me.txtVNotaCredNCF.Size = New System.Drawing.Size(190, 26)
        Me.txtVNotaCredNCF.TabIndex = 14
        Me.txtVNotaCredNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label11.Location = New System.Drawing.Point(10, 272)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Notas Débito NCF.:"
        '
        'txtVNotDebNCF
        '
        Me.txtVNotDebNCF.BackColor = System.Drawing.SystemColors.Info
        Me.txtVNotDebNCF.Enabled = False
        Me.txtVNotDebNCF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVNotDebNCF.Location = New System.Drawing.Point(148, 272)
        Me.txtVNotDebNCF.Name = "txtVNotDebNCF"
        Me.txtVNotDebNCF.Size = New System.Drawing.Size(190, 26)
        Me.txtVNotDebNCF.TabIndex = 12
        Me.txtVNotDebNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(37, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 21)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Total General:"
        '
        'txtVTotal
        '
        Me.txtVTotal.BackColor = System.Drawing.Color.PeachPuff
        Me.txtVTotal.Enabled = False
        Me.txtVTotal.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVTotal.Location = New System.Drawing.Point(150, 177)
        Me.txtVTotal.Name = "txtVTotal"
        Me.txtVTotal.Size = New System.Drawing.Size(190, 26)
        Me.txtVTotal.TabIndex = 10
        Me.txtVTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtVOperacionEspecial
        '
        Me.txtVOperacionEspecial.BackColor = System.Drawing.SystemColors.Info
        Me.txtVOperacionEspecial.Enabled = False
        Me.txtVOperacionEspecial.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVOperacionEspecial.Location = New System.Drawing.Point(150, 146)
        Me.txtVOperacionEspecial.Name = "txtVOperacionEspecial"
        Me.txtVOperacionEspecial.Size = New System.Drawing.Size(190, 26)
        Me.txtVOperacionEspecial.TabIndex = 8
        Me.txtVOperacionEspecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 21)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Gubernamental ....:"
        '
        'txtVGubernamental
        '
        Me.txtVGubernamental.BackColor = System.Drawing.SystemColors.Info
        Me.txtVGubernamental.Enabled = False
        Me.txtVGubernamental.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVGubernamental.Location = New System.Drawing.Point(150, 115)
        Me.txtVGubernamental.Name = "txtVGubernamental"
        Me.txtVGubernamental.Size = New System.Drawing.Size(190, 26)
        Me.txtVGubernamental.TabIndex = 6
        Me.txtVGubernamental.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 21)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Sin Valor Fiscal ......:"
        '
        'txtVSinValorFiscal
        '
        Me.txtVSinValorFiscal.BackColor = System.Drawing.SystemColors.Info
        Me.txtVSinValorFiscal.Enabled = False
        Me.txtVSinValorFiscal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVSinValorFiscal.Location = New System.Drawing.Point(150, 22)
        Me.txtVSinValorFiscal.Name = "txtVSinValorFiscal"
        Me.txtVSinValorFiscal.Size = New System.Drawing.Size(190, 26)
        Me.txtVSinValorFiscal.TabIndex = 4
        Me.txtVSinValorFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 21)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Crédito Fiscal ..........:"
        '
        'txtVCreditoFiscal
        '
        Me.txtVCreditoFiscal.BackColor = System.Drawing.SystemColors.Info
        Me.txtVCreditoFiscal.Enabled = False
        Me.txtVCreditoFiscal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVCreditoFiscal.Location = New System.Drawing.Point(150, 84)
        Me.txtVCreditoFiscal.Name = "txtVCreditoFiscal"
        Me.txtVCreditoFiscal.Size = New System.Drawing.Size(190, 26)
        Me.txtVCreditoFiscal.TabIndex = 2
        Me.txtVCreditoFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Consumidor Final.:"
        '
        'txtVConsumidorFinal
        '
        Me.txtVConsumidorFinal.BackColor = System.Drawing.SystemColors.Info
        Me.txtVConsumidorFinal.Enabled = False
        Me.txtVConsumidorFinal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVConsumidorFinal.Location = New System.Drawing.Point(150, 53)
        Me.txtVConsumidorFinal.Name = "txtVConsumidorFinal"
        Me.txtVConsumidorFinal.Size = New System.Drawing.Size(190, 26)
        Me.txtVConsumidorFinal.TabIndex = 0
        Me.txtVConsumidorFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.txtCNotaCred)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtCNotDeb)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtCItbis)
        Me.GroupBox2.Controls.Add(Me.txtCNotaCredNCF)
        Me.GroupBox2.Controls.Add(Me.txtCNotDebNCF)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtCTotalGeneral)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtCOperacionesEsp)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtCGubernamental)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtCSinValorFiscal)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtCCreditoFiscal)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtCConsumidorFinal)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(355, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(346, 373)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Compras"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label25.Location = New System.Drawing.Point(13, 248)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(131, 20)
        Me.Label25.TabIndex = 24
        Me.Label25.Text = "Notas Débito ..........:"
        '
        'txtCNotaCred
        '
        Me.txtCNotaCred.BackColor = System.Drawing.SystemColors.Info
        Me.txtCNotaCred.Enabled = False
        Me.txtCNotaCred.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCNotaCred.Location = New System.Drawing.Point(150, 306)
        Me.txtCNotaCred.Name = "txtCNotaCred"
        Me.txtCNotaCred.Size = New System.Drawing.Size(190, 26)
        Me.txtCNotaCred.TabIndex = 23
        Me.txtCNotaCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label26.Location = New System.Drawing.Point(9, 312)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(135, 20)
        Me.Label26.TabIndex = 23
        Me.Label26.Text = "Notas Crédito ..........:"
        '
        'txtCNotDeb
        '
        Me.txtCNotDeb.BackColor = System.Drawing.SystemColors.Info
        Me.txtCNotDeb.Enabled = False
        Me.txtCNotDeb.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCNotDeb.Location = New System.Drawing.Point(150, 242)
        Me.txtCNotDeb.Name = "txtCNotDeb"
        Me.txtCNotDeb.Size = New System.Drawing.Size(190, 26)
        Me.txtCNotDeb.TabIndex = 22
        Me.txtCNotDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label14.Location = New System.Drawing.Point(11, 344)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 20)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Notas Crédito NCF:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label15.Location = New System.Drawing.Point(11, 277)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(132, 20)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Notas Débito NCF.:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(86, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 21)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "I.T.B.I.S:"
        '
        'txtCItbis
        '
        Me.txtCItbis.BackColor = System.Drawing.Color.PapayaWhip
        Me.txtCItbis.Enabled = False
        Me.txtCItbis.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCItbis.Location = New System.Drawing.Point(150, 210)
        Me.txtCItbis.Name = "txtCItbis"
        Me.txtCItbis.Size = New System.Drawing.Size(190, 26)
        Me.txtCItbis.TabIndex = 18
        Me.txtCItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCNotaCredNCF
        '
        Me.txtCNotaCredNCF.BackColor = System.Drawing.SystemColors.Info
        Me.txtCNotaCredNCF.Enabled = False
        Me.txtCNotaCredNCF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCNotaCredNCF.Location = New System.Drawing.Point(150, 338)
        Me.txtCNotaCredNCF.Name = "txtCNotaCredNCF"
        Me.txtCNotaCredNCF.Size = New System.Drawing.Size(190, 26)
        Me.txtCNotaCredNCF.TabIndex = 14
        Me.txtCNotaCredNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCNotDebNCF
        '
        Me.txtCNotDebNCF.BackColor = System.Drawing.SystemColors.Info
        Me.txtCNotDebNCF.Enabled = False
        Me.txtCNotDebNCF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCNotDebNCF.Location = New System.Drawing.Point(150, 274)
        Me.txtCNotDebNCF.Name = "txtCNotDebNCF"
        Me.txtCNotDebNCF.Size = New System.Drawing.Size(190, 26)
        Me.txtCNotDebNCF.TabIndex = 12
        Me.txtCNotDebNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(37, 183)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 21)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Total General:"
        '
        'txtCTotalGeneral
        '
        Me.txtCTotalGeneral.BackColor = System.Drawing.Color.PeachPuff
        Me.txtCTotalGeneral.Enabled = False
        Me.txtCTotalGeneral.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCTotalGeneral.Location = New System.Drawing.Point(150, 179)
        Me.txtCTotalGeneral.Name = "txtCTotalGeneral"
        Me.txtCTotalGeneral.Size = New System.Drawing.Size(190, 26)
        Me.txtCTotalGeneral.TabIndex = 10
        Me.txtCTotalGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(8, 152)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(140, 21)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Operac. Especiales:"
        '
        'txtCOperacionesEsp
        '
        Me.txtCOperacionesEsp.BackColor = System.Drawing.SystemColors.Info
        Me.txtCOperacionesEsp.Enabled = False
        Me.txtCOperacionesEsp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOperacionesEsp.Location = New System.Drawing.Point(150, 148)
        Me.txtCOperacionesEsp.Name = "txtCOperacionesEsp"
        Me.txtCOperacionesEsp.Size = New System.Drawing.Size(190, 26)
        Me.txtCOperacionesEsp.TabIndex = 8
        Me.txtCOperacionesEsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 121)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(139, 21)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Gubernamental ....:"
        '
        'txtCGubernamental
        '
        Me.txtCGubernamental.BackColor = System.Drawing.SystemColors.Info
        Me.txtCGubernamental.Enabled = False
        Me.txtCGubernamental.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCGubernamental.Location = New System.Drawing.Point(150, 117)
        Me.txtCGubernamental.Name = "txtCGubernamental"
        Me.txtCGubernamental.Size = New System.Drawing.Size(190, 26)
        Me.txtCGubernamental.TabIndex = 6
        Me.txtCGubernamental.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(140, 21)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Sin Valor Fiscal ......:"
        '
        'txtCSinValorFiscal
        '
        Me.txtCSinValorFiscal.BackColor = System.Drawing.SystemColors.Info
        Me.txtCSinValorFiscal.Enabled = False
        Me.txtCSinValorFiscal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCSinValorFiscal.Location = New System.Drawing.Point(150, 24)
        Me.txtCSinValorFiscal.Name = "txtCSinValorFiscal"
        Me.txtCSinValorFiscal.Size = New System.Drawing.Size(190, 26)
        Me.txtCSinValorFiscal.TabIndex = 4
        Me.txtCSinValorFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 90)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(140, 21)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Crédito Fiscal ..........:"
        '
        'txtCCreditoFiscal
        '
        Me.txtCCreditoFiscal.BackColor = System.Drawing.SystemColors.Info
        Me.txtCCreditoFiscal.Enabled = False
        Me.txtCCreditoFiscal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCCreditoFiscal.Location = New System.Drawing.Point(150, 86)
        Me.txtCCreditoFiscal.Name = "txtCCreditoFiscal"
        Me.txtCCreditoFiscal.Size = New System.Drawing.Size(190, 26)
        Me.txtCCreditoFiscal.TabIndex = 2
        Me.txtCCreditoFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(8, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(139, 21)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Consumidor Final.:"
        '
        'txtCConsumidorFinal
        '
        Me.txtCConsumidorFinal.BackColor = System.Drawing.SystemColors.Info
        Me.txtCConsumidorFinal.Enabled = False
        Me.txtCConsumidorFinal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCConsumidorFinal.Location = New System.Drawing.Point(150, 55)
        Me.txtCConsumidorFinal.Name = "txtCConsumidorFinal"
        Me.txtCConsumidorFinal.Size = New System.Drawing.Size(190, 26)
        Me.txtCConsumidorFinal.TabIndex = 0
        Me.txtCConsumidorFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 87)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(718, 417)
        Me.TabControl1.TabIndex = 350
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(710, 389)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TreeView1)
        Me.TabPage2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(710, 389)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Específico"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TreeView1.Location = New System.Drawing.Point(6, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(698, 380)
        Me.TreeView1.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.FontSize_5701
        Me.PictureBox1.Location = New System.Drawing.Point(651, 79)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(18, 20)
        Me.PictureBox1.TabIndex = 353
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Location = New System.Drawing.Point(0, 508)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 109)
        Me.Panel1.TabIndex = 355
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Location = New System.Drawing.Point(468, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(258, 73)
        Me.Panel2.TabIndex = 359
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnPresentar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(258, 73)
        Me.MenuStrip1.TabIndex = 44
        Me.MenuStrip1.Text = "MenuStrip2"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 69)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnPresentar
        '
        Me.btnPresentar.Image = Global.Libregco.My.Resources.Resources.Preview_x48
        Me.btnPresentar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPresentar.Name = "btnPresentar"
        Me.btnPresentar.Size = New System.Drawing.Size(68, 69)
        Me.btnPresentar.Text = "Presentar"
        Me.btnPresentar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.New_x48
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 69)
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Libregco.My.Resources.Resources.Home_x48
        Me.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(60, 69)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GbOpciones
        '
        Me.GbOpciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbOpciones.Controls.Add(Me.Label9)
        Me.GbOpciones.Controls.Add(Me.cbxTipoOrden)
        Me.GbOpciones.Controls.Add(Me.CbxOrden)
        Me.GbOpciones.Controls.Add(Me.Label27)
        Me.GbOpciones.Controls.Add(Me.CbxFormato)
        Me.GbOpciones.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbOpciones.Location = New System.Drawing.Point(200, 3)
        Me.GbOpciones.Name = "GbOpciones"
        Me.GbOpciones.Size = New System.Drawing.Size(267, 96)
        Me.GbOpciones.TabIndex = 35
        Me.GbOpciones.TabStop = False
        Me.GbOpciones.Text = "Formato"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(130, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 15)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Orden"
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
        Me.cbxTipoOrden.TabIndex = 38
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
        Me.CbxOrden.TabIndex = 37
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(3, 47)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(45, 15)
        Me.Label27.TabIndex = 48
        Me.Label27.Text = "Campo"
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(6, 19)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(252, 23)
        Me.CbxFormato.TabIndex = 36
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.PicSalida)
        Me.GroupBox4.Controls.Add(Me.rdbExcel)
        Me.GroupBox4.Controls.Add(Me.rdbPDF)
        Me.GroupBox4.Controls.Add(Me.rdbImpresora)
        Me.GroupBox4.Controls.Add(Me.rdbPresentacion)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(188, 97)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Seleccione el Tipo de Salida"
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
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 619)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(730, 25)
        Me.BarraEstado.TabIndex = 356
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
        'txtTamañoLetra
        '
        Me.txtTamañoLetra.Location = New System.Drawing.Point(674, 77)
        Me.txtTamañoLetra.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.txtTamañoLetra.Minimum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.txtTamañoLetra.Name = "txtTamañoLetra"
        Me.txtTamañoLetra.Size = New System.Drawing.Size(51, 23)
        Me.txtTamañoLetra.TabIndex = 357
        Me.txtTamañoLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTamañoLetra.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.chkResumir)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(535, 5)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(190, 44)
        Me.GroupBox5.TabIndex = 358
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Condiciones para el reporte"
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(6, 19)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 29
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'frm_controles_ventas_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 644)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.txtTamañoLetra)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_controles_ventas_compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "85"
        Me.Text = "Controles Fiscales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GbOpciones.ResumeLayout(False)
        Me.GbOpciones.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.txtTamañoLetra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVNotaCredNCF As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVNotDebNCF As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtVTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtVOperacionEspecial As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVGubernamental As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVSinValorFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVCreditoFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVConsumidorFinal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCNotaCredNCF As System.Windows.Forms.TextBox
    Friend WithEvents txtCNotDebNCF As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCTotalGeneral As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCOperacionesEsp As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCGubernamental As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCSinValorFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtCCreditoFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCConsumidorFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtVItbis As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCItbis As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtVNotDeb As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtVNotaCred As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtCNotaCred As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCNotDeb As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoOrden As System.Windows.Forms.ComboBox
    Friend WithEvents CbxOrden As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents CbxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PicSalida As System.Windows.Forms.PictureBox
    Friend WithEvents rdbExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPresentacion As System.Windows.Forms.RadioButton
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtTamañoLetra As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnPresentar As System.Windows.Forms.ToolStripMenuItem
End Class
