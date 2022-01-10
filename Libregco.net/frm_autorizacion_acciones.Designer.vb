<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_autorizacion_acciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_autorizacion_acciones))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.lblTiempoenEspera = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblUsuarioSolicitante = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIDAutorizacion = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.lblAccion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BarraEstado.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'btnContinuar
        '
        Me.btnContinuar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnContinuar.Enabled = False
        Me.btnContinuar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnContinuar.Location = New System.Drawing.Point(12, 390)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(442, 54)
        Me.btnContinuar.TabIndex = 0
        Me.btnContinuar.Text = "Esperando aprobación..."
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 483)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(466, 25)
        Me.BarraEstado.TabIndex = 270
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
        'lblTiempoenEspera
        '
        Me.lblTiempoenEspera.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTiempoenEspera.AutoSize = True
        Me.lblTiempoenEspera.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTiempoenEspera.Location = New System.Drawing.Point(393, 447)
        Me.lblTiempoenEspera.Name = "lblTiempoenEspera"
        Me.lblTiempoenEspera.Size = New System.Drawing.Size(0, 15)
        Me.lblTiempoenEspera.TabIndex = 271
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(290, 447)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 15)
        Me.Label1.TabIndex = 272
        Me.Label1.Text = "Tiempo en espera:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(13, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 273
        Me.Label2.Text = "Usuario:"
        '
        'lblUsuarioSolicitante
        '
        Me.lblUsuarioSolicitante.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblUsuarioSolicitante.AutoSize = True
        Me.lblUsuarioSolicitante.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUsuarioSolicitante.Location = New System.Drawing.Point(71, 73)
        Me.lblUsuarioSolicitante.Name = "lblUsuarioSolicitante"
        Me.lblUsuarioSolicitante.Size = New System.Drawing.Size(0, 15)
        Me.lblUsuarioSolicitante.TabIndex = 276
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(13, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 15)
        Me.Label5.TabIndex = 279
        Me.Label5.Text = "Solicitud de autorización No."
        '
        'lblIDAutorizacion
        '
        Me.lblIDAutorizacion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblIDAutorizacion.AutoSize = True
        Me.lblIDAutorizacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIDAutorizacion.Location = New System.Drawing.Point(178, 13)
        Me.lblIDAutorizacion.Name = "lblIDAutorizacion"
        Me.lblIDAutorizacion.Size = New System.Drawing.Size(0, 15)
        Me.lblIDAutorizacion.TabIndex = 280
        '
        'Timer2
        '
        Me.Timer2.Interval = 300
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Square_Loading
        Me.PictureBox1.InitialImage = Global.Libregco.My.Resources.Resources.Check_Gif
        Me.PictureBox1.Location = New System.Drawing.Point(87, 96)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(287, 261)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 288
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(13, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 15)
        Me.Label9.TabIndex = 289
        Me.Label9.Text = "Módulo:"
        '
        'lblModulo
        '
        Me.lblModulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblModulo.AutoSize = True
        Me.lblModulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModulo.Location = New System.Drawing.Point(71, 33)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(0, 15)
        Me.lblModulo.TabIndex = 290
        '
        'lblAccion
        '
        Me.lblAccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAccion.AutoSize = True
        Me.lblAccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAccion.Location = New System.Drawing.Point(71, 53)
        Me.lblAccion.Name = "lblAccion"
        Me.lblAccion.Size = New System.Drawing.Size(0, 15)
        Me.lblAccion.TabIndex = 292
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(13, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 291
        Me.Label4.Text = "Acción:"
        '
        'frm_autorizacion_acciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(466, 508)
        Me.Controls.Add(Me.lblAccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblModulo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblIDAutorizacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblUsuarioSolicitante)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTiempoenEspera)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.btnContinuar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_autorizacion_acciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTiempoenEspera As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioSolicitante As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIDAutorizacion As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents lblAccion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
