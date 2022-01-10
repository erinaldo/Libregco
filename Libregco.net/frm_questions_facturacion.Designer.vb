<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_questions_facturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_questions_facturacion))
        Me.GCTitulo = New DevExpress.XtraEditors.GroupControl()
        Me.Descripcion = New DevExpress.XtraEditors.LabelControl()
        Me.NavTipos = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavPersonalizado = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroupControlContainer1 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NavBarGroupControlContainer2 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.btnNo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSi = New DevExpress.XtraEditors.SimpleButton()
        Me.NavBarGroupControlContainer3 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.btnFinalizarAbierta = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRepuestaAbierta = New DevExpress.XtraEditors.MemoEdit()
        Me.NavAbierta = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavCerrada = New DevExpress.XtraNavBar.NavBarGroup()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        CType(Me.GCTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCTitulo.SuspendLayout()
        CType(Me.NavTipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavTipos.SuspendLayout()
        Me.NavBarGroupControlContainer1.SuspendLayout()
        Me.NavBarGroupControlContainer2.SuspendLayout()
        Me.NavBarGroupControlContainer3.SuspendLayout()
        CType(Me.txtRepuestaAbierta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCTitulo
        '
        Me.GCTitulo.Controls.Add(Me.Descripcion)
        Me.GCTitulo.Location = New System.Drawing.Point(12, 87)
        Me.GCTitulo.Name = "GCTitulo"
        Me.GCTitulo.Padding = New System.Windows.Forms.Padding(5)
        Me.GCTitulo.Size = New System.Drawing.Size(426, 88)
        Me.GCTitulo.TabIndex = 0
        '
        'Descripcion
        '
        Me.Descripcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Descripcion.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Appearance.Options.UseFont = True
        Me.Descripcion.Appearance.Options.UseTextOptions = True
        Me.Descripcion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Descripcion.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.Descripcion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.Descripcion.Location = New System.Drawing.Point(10, 28)
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Size = New System.Drawing.Size(406, 50)
        Me.Descripcion.TabIndex = 0
        '
        'NavTipos
        '
        Me.NavTipos.ActiveGroup = Me.NavPersonalizado
        Me.NavTipos.Controls.Add(Me.NavBarGroupControlContainer1)
        Me.NavTipos.Controls.Add(Me.NavBarGroupControlContainer2)
        Me.NavTipos.Controls.Add(Me.NavBarGroupControlContainer3)
        Me.NavTipos.ExplorerBarShowGroupButtons = False
        Me.NavTipos.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavAbierta, Me.NavCerrada, Me.NavPersonalizado})
        Me.NavTipos.Location = New System.Drawing.Point(12, 176)
        Me.NavTipos.Name = "NavTipos"
        Me.NavTipos.OptionsNavPane.ExpandedWidth = 426
        Me.NavTipos.OptionsNavPane.ShowExpandButton = False
        Me.NavTipos.OptionsNavPane.ShowOverflowPanel = False
        Me.NavTipos.OptionsNavPane.ShowSplitter = False
        Me.NavTipos.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
        Me.NavTipos.Size = New System.Drawing.Size(426, 322)
        Me.NavTipos.TabIndex = 1
        Me.NavTipos.TabStop = True
        Me.NavTipos.Text = "NavBarControl1"
        '
        'NavPersonalizado
        '
        Me.NavPersonalizado.Caption = "Personalizadas"
        Me.NavPersonalizado.ControlContainer = Me.NavBarGroupControlContainer1
        Me.NavPersonalizado.Expanded = True
        Me.NavPersonalizado.GroupClientHeight = 80
        Me.NavPersonalizado.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavPersonalizado.Name = "NavPersonalizado"
        '
        'NavBarGroupControlContainer1
        '
        Me.NavBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer1.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer1.Controls.Add(Me.FlowLayoutPanel1)
        Me.NavBarGroupControlContainer1.Name = "NavBarGroupControlContainer1"
        Me.NavBarGroupControlContainer1.Size = New System.Drawing.Size(426, 205)
        Me.NavBarGroupControlContainer1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(426, 205)
        Me.FlowLayoutPanel1.TabIndex = 0
        Me.FlowLayoutPanel1.TabStop = True
        '
        'NavBarGroupControlContainer2
        '
        Me.NavBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer2.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer2.Controls.Add(Me.btnNo)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.btnSi)
        Me.NavBarGroupControlContainer2.Name = "NavBarGroupControlContainer2"
        Me.NavBarGroupControlContainer2.Size = New System.Drawing.Size(426, 205)
        Me.NavBarGroupControlContainer2.TabIndex = 1
        Me.NavBarGroupControlContainer2.TabStop = True
        '
        'btnNo
        '
        Me.btnNo.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Dislike_x48
        Me.btnNo.Location = New System.Drawing.Point(214, 3)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(202, 64)
        Me.btnNo.TabIndex = 1
        Me.btnNo.Text = "No"
        '
        'btnSi
        '
        Me.btnSi.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Like_x48
        Me.btnSi.Location = New System.Drawing.Point(10, 3)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(202, 64)
        Me.btnSi.TabIndex = 0
        Me.btnSi.Text = "Sí"
        '
        'NavBarGroupControlContainer3
        '
        Me.NavBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer3.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer3.Controls.Add(Me.btnFinalizarAbierta)
        Me.NavBarGroupControlContainer3.Controls.Add(Me.Label1)
        Me.NavBarGroupControlContainer3.Controls.Add(Me.txtRepuestaAbierta)
        Me.NavBarGroupControlContainer3.Name = "NavBarGroupControlContainer3"
        Me.NavBarGroupControlContainer3.Size = New System.Drawing.Size(426, 212)
        Me.NavBarGroupControlContainer3.TabIndex = 2
        Me.NavBarGroupControlContainer3.TabStop = True
        '
        'btnFinalizarAbierta
        '
        Me.btnFinalizarAbierta.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnFinalizarAbierta.Appearance.Options.UseFont = True
        Me.btnFinalizarAbierta.Location = New System.Drawing.Point(271, 183)
        Me.btnFinalizarAbierta.Name = "btnFinalizarAbierta"
        Me.btnFinalizarAbierta.Size = New System.Drawing.Size(152, 29)
        Me.btnFinalizarAbierta.TabIndex = 2
        Me.btnFinalizarAbierta.Text = "Finalizar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Respuesta"
        '
        'txtRepuestaAbierta
        '
        Me.txtRepuestaAbierta.Location = New System.Drawing.Point(3, 21)
        Me.txtRepuestaAbierta.Name = "txtRepuestaAbierta"
        Me.txtRepuestaAbierta.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtRepuestaAbierta.Properties.Appearance.Options.UseFont = True
        Me.txtRepuestaAbierta.Size = New System.Drawing.Size(420, 156)
        Me.txtRepuestaAbierta.TabIndex = 0
        '
        'NavAbierta
        '
        Me.NavAbierta.Caption = "Abiertas"
        Me.NavAbierta.ControlContainer = Me.NavBarGroupControlContainer3
        Me.NavAbierta.GroupClientHeight = 154
        Me.NavAbierta.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavAbierta.Name = "NavAbierta"
        '
        'NavCerrada
        '
        Me.NavCerrada.Caption = "Cerradas"
        Me.NavCerrada.ControlContainer = Me.NavBarGroupControlContainer2
        Me.NavCerrada.GroupClientHeight = 80
        Me.NavCerrada.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavCerrada.Name = "NavCerrada"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Questionx128
        Me.PictureBox1.Location = New System.Drawing.Point(12, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(97, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(111, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Preguntas establecidas"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Appearance.Options.UseTextOptions = True
        Me.LabelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(97, 31)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(331, 29)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Esta pregunta ha sido establecida para dar un mejor servicio durante el despacho " &
    "de las mercancías compradas"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(79, 19)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(374, 23)
        Me.SeparatorControl1.TabIndex = 5
        '
        'frm_questions_facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 498)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GCTitulo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.NavTipos)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_questions_facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preguntas del artículo"
        CType(Me.GCTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCTitulo.ResumeLayout(False)
        CType(Me.NavTipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavTipos.ResumeLayout(False)
        Me.NavBarGroupControlContainer1.ResumeLayout(False)
        Me.NavBarGroupControlContainer2.ResumeLayout(False)
        Me.NavBarGroupControlContainer3.ResumeLayout(False)
        Me.NavBarGroupControlContainer3.PerformLayout()
        CType(Me.txtRepuestaAbierta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GCTitulo As XtraEditors.GroupControl
    Friend WithEvents Descripcion As XtraEditors.LabelControl
    Friend WithEvents NavTipos As XtraNavBar.NavBarControl
    Friend WithEvents NavAbierta As XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroupControlContainer3 As XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents btnFinalizarAbierta As XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRepuestaAbierta As XtraEditors.MemoEdit
    Friend WithEvents NavBarGroupControlContainer1 As XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents NavBarGroupControlContainer2 As XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents btnNo As XtraEditors.SimpleButton
    Friend WithEvents btnSi As XtraEditors.SimpleButton
    Friend WithEvents NavPersonalizado As XtraNavBar.NavBarGroup
    Friend WithEvents NavCerrada As XtraNavBar.NavBarGroup
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LabelControl1 As XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As XtraEditors.LabelControl
    Friend WithEvents SeparatorControl1 As XtraEditors.SeparatorControl
End Class
