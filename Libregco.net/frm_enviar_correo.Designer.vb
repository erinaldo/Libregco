<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_enviar_correo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_enviar_correo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.RtMensaje = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GbValidacion = New System.Windows.Forms.GroupBox()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.cboExtension = New System.Windows.Forms.ComboBox()
        Me.VerPasswordbtn = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BarraStatus = New System.Windows.Forms.ToolStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripLabel()
        Me.GbMensaje = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.TsBForeColor = New System.Windows.Forms.ToolStripButton()
        Me.TsLTextoColor = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsBBold = New System.Windows.Forms.ToolStripButton()
        Me.TsBItalic = New System.Windows.Forms.ToolStripButton()
        Me.TsBUnderLine = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbAlinearIzquierda = New System.Windows.Forms.ToolStripButton()
        Me.TsbAlinearCentrar = New System.Windows.Forms.ToolStripButton()
        Me.TsbAlinearDerecha = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.btnSendEmail = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminarEnlace = New System.Windows.Forms.Button()
        Me.LbAdjuntos = New System.Windows.Forms.ListBox()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.btnCerrarSesion = New System.Windows.Forms.Button()
        Me.GbValidacion.SuspendLayout()
        Me.BarraStatus.SuspendLayout()
        Me.GbMensaje.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(14, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Para:"
        '
        'txtDestino
        '
        Me.txtDestino.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDestino.Location = New System.Drawing.Point(72, 15)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(858, 23)
        Me.txtDestino.TabIndex = 6
        '
        'RtMensaje
        '
        Me.RtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RtMensaje.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RtMensaje.Location = New System.Drawing.Point(17, 147)
        Me.RtMensaje.Name = "RtMensaje"
        Me.RtMensaje.Size = New System.Drawing.Size(915, 298)
        Me.RtMensaje.TabIndex = 10
        Me.RtMensaje.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(14, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Adjunto:"
        '
        'txtAsunto
        '
        Me.txtAsunto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAsunto.Location = New System.Drawing.Point(72, 44)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(858, 23)
        Me.txtAsunto.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(14, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Asunto:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(14, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Mensaje"
        '
        'GbValidacion
        '
        Me.GbValidacion.Controls.Add(Me.btnIngresar)
        Me.GbValidacion.Controls.Add(Me.cboExtension)
        Me.GbValidacion.Controls.Add(Me.VerPasswordbtn)
        Me.GbValidacion.Controls.Add(Me.txtPassword)
        Me.GbValidacion.Controls.Add(Me.Label6)
        Me.GbValidacion.Controls.Add(Me.txtEmail)
        Me.GbValidacion.Controls.Add(Me.Label5)
        Me.GbValidacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbValidacion.Location = New System.Drawing.Point(12, 8)
        Me.GbValidacion.Name = "GbValidacion"
        Me.GbValidacion.Size = New System.Drawing.Size(825, 66)
        Me.GbValidacion.TabIndex = 9
        Me.GbValidacion.TabStop = False
        Me.GbValidacion.Text = "Correo Electrónico"
        '
        'btnIngresar
        '
        Me.btnIngresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIngresar.Enabled = False
        Me.btnIngresar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.Location = New System.Drawing.Point(696, 22)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(110, 25)
        Me.btnIngresar.TabIndex = 4
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'cboExtension
        '
        Me.cboExtension.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExtension.Enabled = False
        Me.cboExtension.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboExtension.FormattingEnabled = True
        Me.cboExtension.Items.AddRange(New Object() {"[ Seleccione una extensión ]", "@gmail.com", "@hotmail.com", "@yahoo.com" & Global.Microsoft.VisualBasic.ChrW(9)})
        Me.cboExtension.Location = New System.Drawing.Point(222, 22)
        Me.cboExtension.Name = "cboExtension"
        Me.cboExtension.Size = New System.Drawing.Size(173, 23)
        Me.cboExtension.TabIndex = 1
        '
        'VerPasswordbtn
        '
        Me.VerPasswordbtn.Enabled = False
        Me.VerPasswordbtn.Location = New System.Drawing.Point(638, 22)
        Me.VerPasswordbtn.Name = "VerPasswordbtn"
        Me.VerPasswordbtn.Size = New System.Drawing.Size(39, 24)
        Me.VerPasswordbtn.TabIndex = 3
        Me.VerPasswordbtn.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPassword.Location = New System.Drawing.Point(467, 22)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(165, 23)
        Me.txtPassword.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(401, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Password:"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmail.Location = New System.Drawing.Point(59, 23)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(157, 23)
        Me.txtEmail.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(14, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Email:"
        '
        'BarraStatus
        '
        Me.BarraStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.BarraStatus.Location = New System.Drawing.Point(0, 578)
        Me.BarraStatus.Name = "BarraStatus"
        Me.BarraStatus.Size = New System.Drawing.Size(967, 25)
        Me.BarraStatus.TabIndex = 11
        Me.BarraStatus.Text = "ToolStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(32, 22)
        Me.StatusLabel.Text = "Listo"
        '
        'GbMensaje
        '
        Me.GbMensaje.Controls.Add(Me.Panel1)
        Me.GbMensaje.Controls.Add(Me.btnEliminarEnlace)
        Me.GbMensaje.Controls.Add(Me.LbAdjuntos)
        Me.GbMensaje.Controls.Add(Me.RtMensaje)
        Me.GbMensaje.Controls.Add(Me.Label1)
        Me.GbMensaje.Controls.Add(Me.txtDestino)
        Me.GbMensaje.Controls.Add(Me.Label2)
        Me.GbMensaje.Controls.Add(Me.Label4)
        Me.GbMensaje.Controls.Add(Me.btnAdjuntar)
        Me.GbMensaje.Controls.Add(Me.Label3)
        Me.GbMensaje.Controls.Add(Me.txtAsunto)
        Me.GbMensaje.Enabled = False
        Me.GbMensaje.Location = New System.Drawing.Point(12, 80)
        Me.GbMensaje.Name = "GbMensaje"
        Me.GbMensaje.Size = New System.Drawing.Size(945, 487)
        Me.GbMensaje.TabIndex = 5
        Me.GbMensaje.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(17, 444)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(915, 25)
        Me.Panel1.TabIndex = 16
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton1, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.TsBForeColor, Me.TsLTextoColor, Me.ToolStripSeparator3, Me.TsBBold, Me.TsBItalic, Me.TsBUnderLine, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.TsbAlinearIzquierda, Me.TsbAlinearCentrar, Me.TsbAlinearDerecha, Me.ToolStripSeparator5, Me.TsbLimpiar, Me.btnSendEmail})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(915, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Libregco.My.Resources.Resources.Undo_16x
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Undo"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Libregco.My.Resources.Resources.Redo_16x
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Redo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Libregco.My.Resources.Resources.Font_6007
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'TsBForeColor
        '
        Me.TsBForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBForeColor.Image = Global.Libregco.My.Resources.Resources.FontColor_11146
        Me.TsBForeColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBForeColor.Name = "TsBForeColor"
        Me.TsBForeColor.Size = New System.Drawing.Size(23, 22)
        Me.TsBForeColor.Text = "ToolStripButton4"
        '
        'TsLTextoColor
        '
        Me.TsLTextoColor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsLTextoColor.Name = "TsLTextoColor"
        Me.TsLTextoColor.Size = New System.Drawing.Size(34, 22)
        Me.TsLTextoColor.Text = "Texto"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TsBBold
        '
        Me.TsBBold.BackColor = System.Drawing.SystemColors.Control
        Me.TsBBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBBold.Image = Global.Libregco.My.Resources.Resources.Bold_11689
        Me.TsBBold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBBold.Name = "TsBBold"
        Me.TsBBold.Size = New System.Drawing.Size(23, 22)
        Me.TsBBold.Text = "Negrita"
        '
        'TsBItalic
        '
        Me.TsBItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBItalic.Image = Global.Libregco.My.Resources.Resources.Italic_11693
        Me.TsBItalic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBItalic.Name = "TsBItalic"
        Me.TsBItalic.Size = New System.Drawing.Size(23, 22)
        Me.TsBItalic.Text = "Cursiva"
        '
        'TsBUnderLine
        '
        Me.TsBUnderLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBUnderLine.Image = Global.Libregco.My.Resources.Resources.Underline_11700
        Me.TsBUnderLine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBUnderLine.Name = "TsBUnderLine"
        Me.TsBUnderLine.Size = New System.Drawing.Size(23, 22)
        Me.TsBUnderLine.Text = "Subrayado"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TsbAlinearIzquierda
        '
        Me.TsbAlinearIzquierda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbAlinearIzquierda.Image = Global.Libregco.My.Resources.Resources.LeftJustify_11695
        Me.TsbAlinearIzquierda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbAlinearIzquierda.Name = "TsbAlinearIzquierda"
        Me.TsbAlinearIzquierda.Size = New System.Drawing.Size(23, 22)
        Me.TsbAlinearIzquierda.Text = "ToolStripButton7"
        '
        'TsbAlinearCentrar
        '
        Me.TsbAlinearCentrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbAlinearCentrar.Image = Global.Libregco.My.Resources.Resources.Centered_11691
        Me.TsbAlinearCentrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbAlinearCentrar.Name = "TsbAlinearCentrar"
        Me.TsbAlinearCentrar.Size = New System.Drawing.Size(23, 22)
        Me.TsbAlinearCentrar.Text = "ToolStripButton6"
        '
        'TsbAlinearDerecha
        '
        Me.TsbAlinearDerecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbAlinearDerecha.Image = Global.Libregco.My.Resources.Resources.RightJustify_11699
        Me.TsbAlinearDerecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbAlinearDerecha.Name = "TsbAlinearDerecha"
        Me.TsbAlinearDerecha.Size = New System.Drawing.Size(23, 22)
        Me.TsbAlinearDerecha.Text = "ToolStripButton8"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'TsbLimpiar
        '
        Me.TsbLimpiar.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.TsbLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbLimpiar.Name = "TsbLimpiar"
        Me.TsbLimpiar.Size = New System.Drawing.Size(114, 22)
        Me.TsbLimpiar.Text = "Limpiar Mensaje"
        '
        'btnSendEmail
        '
        Me.btnSendEmail.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSendEmail.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSendEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSendEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendEmail.ForeColor = System.Drawing.Color.White
        Me.btnSendEmail.Image = CType(resources.GetObject("btnSendEmail.Image"), System.Drawing.Image)
        Me.btnSendEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSendEmail.Name = "btnSendEmail"
        Me.btnSendEmail.Size = New System.Drawing.Size(117, 22)
        Me.btnSendEmail.Text = "            Enviar            "
        '
        'btnEliminarEnlace
        '
        Me.btnEliminarEnlace.BackgroundImage = Global.Libregco.My.Resources.Resources.detachprocess_6535
        Me.btnEliminarEnlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarEnlace.Location = New System.Drawing.Point(891, 97)
        Me.btnEliminarEnlace.Name = "btnEliminarEnlace"
        Me.btnEliminarEnlace.Size = New System.Drawing.Size(26, 23)
        Me.btnEliminarEnlace.TabIndex = 14
        Me.btnEliminarEnlace.UseVisualStyleBackColor = True
        '
        'LbAdjuntos
        '
        Me.LbAdjuntos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbAdjuntos.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAdjuntos.ForeColor = System.Drawing.Color.Blue
        Me.LbAdjuntos.FormattingEnabled = True
        Me.LbAdjuntos.ItemHeight = 15
        Me.LbAdjuntos.Location = New System.Drawing.Point(72, 73)
        Me.LbAdjuntos.Name = "LbAdjuntos"
        Me.LbAdjuntos.Size = New System.Drawing.Size(813, 47)
        Me.LbAdjuntos.TabIndex = 13
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.Location = New System.Drawing.Point(891, 73)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(26, 23)
        Me.btnAdjuntar.TabIndex = 9
        Me.btnAdjuntar.Text = "..."
        Me.btnAdjuntar.UseVisualStyleBackColor = True
        '
        'btnCerrarSesion
        '
        Me.btnCerrarSesion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrarSesion.Enabled = False
        Me.btnCerrarSesion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarSesion.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrarSesion.Location = New System.Drawing.Point(845, 12)
        Me.btnCerrarSesion.Name = "btnCerrarSesion"
        Me.btnCerrarSesion.Size = New System.Drawing.Size(110, 62)
        Me.btnCerrarSesion.TabIndex = 12
        Me.btnCerrarSesion.Text = "Cerrar Sesión"
        Me.btnCerrarSesion.UseVisualStyleBackColor = True
        '
        'frm_enviar_correo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 603)
        Me.Controls.Add(Me.btnCerrarSesion)
        Me.Controls.Add(Me.GbMensaje)
        Me.Controls.Add(Me.BarraStatus)
        Me.Controls.Add(Me.GbValidacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_enviar_correo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Envíos de Correos Electrónicos"
        Me.GbValidacion.ResumeLayout(False)
        Me.GbValidacion.PerformLayout()
        Me.BarraStatus.ResumeLayout(False)
        Me.BarraStatus.PerformLayout()
        Me.GbMensaje.ResumeLayout(False)
        Me.GbMensaje.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents RtMensaje As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAdjuntar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GbValidacion As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents VerPasswordbtn As System.Windows.Forms.Button
    Friend WithEvents BarraStatus As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GbMensaje As System.Windows.Forms.GroupBox
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents cboExtension As System.Windows.Forms.ComboBox
    Friend WithEvents btnCerrarSesion As System.Windows.Forms.Button
    Friend WithEvents LbAdjuntos As System.Windows.Forms.ListBox
    Friend WithEvents btnEliminarEnlace As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsBForeColor As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsbAlinearCentrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsbAlinearIzquierda As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsbAlinearDerecha As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsBUnderLine As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsBBold As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsBItalic As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsLTextoColor As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSendEmail As System.Windows.Forms.ToolStripButton
End Class
