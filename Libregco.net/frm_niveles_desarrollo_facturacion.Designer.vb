<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_niveles_desarrollo_facturacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_niveles_desarrollo_facturacion))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridCotizacion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.AccordionContentContainer1 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.AccordionContentContainer2 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.AccordionContentContainer4 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridPrefacturas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AccordionContentContainer3 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridFacturacion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccordionControl1.SuspendLayout()
        Me.AccordionContentContainer1.SuspendLayout()
        Me.AccordionContentContainer2.SuspendLayout()
        Me.AccordionContentContainer4.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPrefacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccordionContentContainer3.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridCotizacion
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(843, 122)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridCotizacion})
        '
        'GridCotizacion
        '
        Me.GridCotizacion.GridControl = Me.GridControl1
        Me.GridCotizacion.Name = "GridCotizacion"
        Me.GridCotizacion.OptionsView.ShowGroupPanel = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar, Me.ToolStripSeparator1})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 500)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(860, 25)
        Me.BarraEstado.TabIndex = 347
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer1)
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer2)
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer3)
        Me.AccordionControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1})
        Me.AccordionControl1.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ShowGroupExpandButtons = False
        Me.AccordionControl1.Size = New System.Drawing.Size(860, 500)
        Me.AccordionControl1.TabIndex = 348
        Me.AccordionControl1.Text = "AccordionControl1"
        '
        'AccordionContentContainer1
        '
        Me.AccordionContentContainer1.Controls.Add(Me.GridControl1)
        Me.AccordionContentContainer1.Name = "AccordionContentContainer1"
        Me.AccordionContentContainer1.Size = New System.Drawing.Size(843, 122)
        Me.AccordionContentContainer1.TabIndex = 1
        '
        'AccordionContentContainer2
        '
        Me.AccordionContentContainer2.Controls.Add(Me.AccordionContentContainer4)
        Me.AccordionContentContainer2.Name = "AccordionContentContainer2"
        Me.AccordionContentContainer2.Size = New System.Drawing.Size(843, 136)
        Me.AccordionContentContainer2.TabIndex = 2
        '
        'AccordionContentContainer4
        '
        Me.AccordionContentContainer4.Controls.Add(Me.GridControl2)
        Me.AccordionContentContainer4.Name = "AccordionContentContainer4"
        Me.AccordionContentContainer4.Size = New System.Drawing.Size(843, 132)
        Me.AccordionContentContainer4.TabIndex = 2
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridPrefacturas
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(843, 132)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridPrefacturas})
        '
        'GridPrefacturas
        '
        Me.GridPrefacturas.GridControl = Me.GridControl2
        Me.GridPrefacturas.Name = "GridPrefacturas"
        Me.GridPrefacturas.OptionsView.ShowGroupPanel = False
        '
        'AccordionContentContainer3
        '
        Me.AccordionContentContainer3.Controls.Add(Me.GridControl3)
        Me.AccordionContentContainer3.Name = "AccordionContentContainer3"
        Me.AccordionContentContainer3.Size = New System.Drawing.Size(843, 112)
        Me.AccordionContentContainer3.TabIndex = 3
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridFacturacion
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(843, 112)
        Me.GridControl3.TabIndex = 1
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridFacturacion})
        '
        'GridFacturacion
        '
        Me.GridFacturacion.GridControl = Me.GridControl3
        Me.GridFacturacion.Name = "GridFacturacion"
        Me.GridFacturacion.OptionsView.ShowGroupPanel = False
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement2, Me.AccordionControlElement3, Me.AccordionControlElement4})
        Me.AccordionControlElement1.Expanded = True
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Text = "Histórico de desarrollo"
        '
        'AccordionControlElement2
        '
        Me.AccordionControlElement2.ContentContainer = Me.AccordionContentContainer1
        Me.AccordionControlElement2.Expanded = True
        Me.AccordionControlElement2.Name = "AccordionControlElement2"
        Me.AccordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement2.Text = "Cotización"
        '
        'AccordionControlElement3
        '
        Me.AccordionControlElement3.ContentContainer = Me.AccordionContentContainer2
        Me.AccordionControlElement3.Expanded = True
        Me.AccordionControlElement3.Name = "AccordionControlElement3"
        Me.AccordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement3.Text = "Prefactura(s)"
        '
        'AccordionControlElement4
        '
        Me.AccordionControlElement4.ContentContainer = Me.AccordionContentContainer3
        Me.AccordionControlElement4.Expanded = True
        Me.AccordionControlElement4.Name = "AccordionControlElement4"
        Me.AccordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement4.Text = "Facturación"
        '
        'frm_niveles_desarrollo_facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 525)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_niveles_desarrollo_facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Desarrollo de la facturación"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccordionControl1.ResumeLayout(False)
        Me.AccordionContentContainer1.ResumeLayout(False)
        Me.AccordionContentContainer2.ResumeLayout(False)
        Me.AccordionContentContainer4.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPrefacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccordionContentContainer3.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridCotizacion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents AccordionContentContainer1 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionContentContainer2 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionContentContainer3 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionContentContainer4 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridPrefacturas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridFacturacion As DevExpress.XtraGrid.Views.Grid.GridView
End Class
