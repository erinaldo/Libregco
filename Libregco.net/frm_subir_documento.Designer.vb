<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_subir_documento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_subir_documento))
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EscanearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarDocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescargarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirUbicaciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdiciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraZoom = New System.Windows.Forms.ToolStrip()
        Me.btnAumentarZoom = New System.Windows.Forms.ToolStripButton()
        Me.btnReducirZoom = New System.Windows.Forms.ToolStripButton()
        Me.btnVerRuta = New System.Windows.Forms.ToolStripButton()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.Acciones = New System.Windows.Forms.ToolStrip()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEscanear = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnDownload = New System.Windows.Forms.ToolStripButton()
        Me.btnRotar = New System.Windows.Forms.ToolStripButton()
        Me.PanelPic = New System.Windows.Forms.Panel()
        Me.PicDocumento = New System.Windows.Forms.PictureBox()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.AcepOrCancelTS = New System.Windows.Forms.ToolStrip()
        Me.btnAceptar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.MenuBar.SuspendLayout()
        Me.BarraZoom.SuspendLayout()
        Me.Acciones.SuspendLayout()
        Me.PanelPic.SuspendLayout()
        CType(Me.PicDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AcepOrCancelTS.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuBar
        '
        Me.MenuBar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.EdiciónToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(541, 24)
        Me.MenuBar.TabIndex = 0
        Me.MenuBar.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarToolStripMenuItem, Me.ToolStripSeparator2, Me.EscanearToolStripMenuItem, Me.AbrirToolStripMenuItem, Me.BuscarDocumentoToolStripMenuItem, Me.DescargarToolStripMenuItem, Me.AbrirUbicaciToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator1, Me.CerrarToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'LimpiarToolStripMenuItem
        '
        Me.LimpiarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.LimpiarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LimpiarToolStripMenuItem.Name = "LimpiarToolStripMenuItem"
        Me.LimpiarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.LimpiarToolStripMenuItem.Size = New System.Drawing.Size(161, 38)
        Me.LimpiarToolStripMenuItem.Text = "Limpiar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(158, 6)
        '
        'EscanearToolStripMenuItem
        '
        Me.EscanearToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Scanner_x32
        Me.EscanearToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EscanearToolStripMenuItem.Name = "EscanearToolStripMenuItem"
        Me.EscanearToolStripMenuItem.ShortcutKeyDisplayString = "F2"
        Me.EscanearToolStripMenuItem.Size = New System.Drawing.Size(161, 38)
        Me.EscanearToolStripMenuItem.Text = "Escanear"
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Image_Capture_x32
        Me.AbrirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(161, 38)
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'BuscarDocumentoToolStripMenuItem
        '
        Me.BuscarDocumentoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarDocumentoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarDocumentoToolStripMenuItem.Name = "BuscarDocumentoToolStripMenuItem"
        Me.BuscarDocumentoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BuscarDocumentoToolStripMenuItem.Size = New System.Drawing.Size(161, 38)
        Me.BuscarDocumentoToolStripMenuItem.Text = "Buscar"
        '
        'DescargarToolStripMenuItem
        '
        Me.DescargarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Download_x32
        Me.DescargarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DescargarToolStripMenuItem.Name = "DescargarToolStripMenuItem"
        Me.DescargarToolStripMenuItem.Size = New System.Drawing.Size(161, 38)
        Me.DescargarToolStripMenuItem.Text = "Descargar"
        '
        'AbrirUbicaciToolStripMenuItem
        '
        Me.AbrirUbicaciToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.AbrirUbicaciToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AbrirUbicaciToolStripMenuItem.Name = "AbrirUbicaciToolStripMenuItem"
        Me.AbrirUbicaciToolStripMenuItem.Size = New System.Drawing.Size(161, 38)
        Me.AbrirUbicaciToolStripMenuItem.Text = "Abrir ubicación"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(161, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(158, 6)
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.CerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(161, 38)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'EdiciónToolStripMenuItem
        '
        Me.EdiciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZoomToolStripMenuItem, Me.ZoomToolStripMenuItem1})
        Me.EdiciónToolStripMenuItem.Name = "EdiciónToolStripMenuItem"
        Me.EdiciónToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.EdiciónToolStripMenuItem.Text = "Edición"
        '
        'ZoomToolStripMenuItem
        '
        Me.ZoomToolStripMenuItem.Name = "ZoomToolStripMenuItem"
        Me.ZoomToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)
        Me.ZoomToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ZoomToolStripMenuItem.Text = "+ Zoom"
        '
        'ZoomToolStripMenuItem1
        '
        Me.ZoomToolStripMenuItem1.Name = "ZoomToolStripMenuItem1"
        Me.ZoomToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)
        Me.ZoomToolStripMenuItem1.Size = New System.Drawing.Size(169, 22)
        Me.ZoomToolStripMenuItem1.Text = "-  Zoom"
        '
        'BarraZoom
        '
        Me.BarraZoom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraZoom.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.BarraZoom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraZoom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAumentarZoom, Me.btnReducirZoom, Me.btnVerRuta, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatus})
        Me.BarraZoom.Location = New System.Drawing.Point(0, 662)
        Me.BarraZoom.Name = "BarraZoom"
        Me.BarraZoom.Size = New System.Drawing.Size(584, 39)
        Me.BarraZoom.TabIndex = 2
        Me.BarraZoom.Text = "ToolStrip1"
        '
        'btnAumentarZoom
        '
        Me.btnAumentarZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnAumentarZoom.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnAumentarZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAumentarZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAumentarZoom.Name = "btnAumentarZoom"
        Me.btnAumentarZoom.Size = New System.Drawing.Size(80, 36)
        Me.btnAumentarZoom.Text = "+ Zoom"
        '
        'btnReducirZoom
        '
        Me.btnReducirZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnReducirZoom.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnReducirZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnReducirZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReducirZoom.Name = "btnReducirZoom"
        Me.btnReducirZoom.Size = New System.Drawing.Size(76, 36)
        Me.btnReducirZoom.Text = "- Zoom"
        '
        'btnVerRuta
        '
        Me.btnVerRuta.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnVerRuta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnVerRuta.Image = CType(resources.GetObject("btnVerRuta.Image"), System.Drawing.Image)
        Me.btnVerRuta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVerRuta.Name = "btnVerRuta"
        Me.btnVerRuta.Size = New System.Drawing.Size(34, 36)
        Me.btnVerRuta.Text = "Ruta"
        '
        'PicLogo
        '
        Me.PicLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(23, 36)
        '
        'NameSys
        '
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.NameSys.Name = "NameSys"
        Me.NameSys.Size = New System.Drawing.Size(63, 36)
        Me.NameSys.Text = "Libregco"
        '
        'ToolSeparator2
        '
        Me.ToolSeparator2.Name = "ToolSeparator2"
        Me.ToolSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(29, 36)
        Me.lblStatus.Text = "Listo"
        '
        'Acciones
        '
        Me.Acciones.AutoSize = False
        Me.Acciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.Acciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Acciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLimpiar, Me.ToolStripSeparator3, Me.btnEscanear, Me.btnBuscar, Me.btnAbrir, Me.btnImprimir, Me.btnDownload, Me.btnRotar})
        Me.Acciones.Location = New System.Drawing.Point(0, 0)
        Me.Acciones.Name = "Acciones"
        Me.Acciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Acciones.Size = New System.Drawing.Size(43, 637)
        Me.Acciones.TabIndex = 3
        Me.Acciones.Text = "ToolStrip2"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(41, 36)
        Me.btnLimpiar.Text = "F5 - Limpiar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(41, 6)
        '
        'btnEscanear
        '
        Me.btnEscanear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEscanear.Image = Global.Libregco.My.Resources.Resources.Scanner_x32
        Me.btnEscanear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEscanear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEscanear.Name = "btnEscanear"
        Me.btnEscanear.Size = New System.Drawing.Size(41, 36)
        Me.btnEscanear.Text = "F1 - Escanear"
        '
        'btnBuscar
        '
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Image_Capture_x32
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(41, 36)
        Me.btnBuscar.Text = "F2 - Buscar"
        '
        'btnAbrir
        '
        Me.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAbrir.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnAbrir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(41, 36)
        Me.btnAbrir.Text = "F3 - Abrir"
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(41, 36)
        Me.btnImprimir.Text = "F4 - Imprimir"
        '
        'btnDownload
        '
        Me.btnDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDownload.Image = Global.Libregco.My.Resources.Resources.Download_x32
        Me.btnDownload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDownload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(41, 36)
        Me.btnDownload.Text = "F4 - Imprimir"
        Me.btnDownload.Visible = False
        '
        'btnRotar
        '
        Me.btnRotar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRotar.Image = Global.Libregco.My.Resources.Resources.rotate90x32
        Me.btnRotar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnRotar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRotar.Name = "btnRotar"
        Me.btnRotar.Size = New System.Drawing.Size(41, 36)
        Me.btnRotar.Text = "Rotar Imagen 90 grados"
        Me.btnRotar.Visible = False
        '
        'PanelPic
        '
        Me.PanelPic.AllowDrop = True
        Me.PanelPic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelPic.AutoScroll = True
        Me.PanelPic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelPic.BackColor = System.Drawing.SystemColors.Control
        Me.PanelPic.Controls.Add(Me.PicDocumento)
        Me.PanelPic.Location = New System.Drawing.Point(2, 27)
        Me.PanelPic.Name = "PanelPic"
        Me.PanelPic.Size = New System.Drawing.Size(539, 607)
        Me.PanelPic.TabIndex = 4
        '
        'PicDocumento
        '
        Me.PicDocumento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicDocumento.BackColor = System.Drawing.Color.White
        Me.PicDocumento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicDocumento.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PicDocumento.Location = New System.Drawing.Point(0, 0)
        Me.PicDocumento.Name = "PicDocumento"
        Me.PicDocumento.Size = New System.Drawing.Size(539, 607)
        Me.PicDocumento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicDocumento.TabIndex = 2
        Me.PicDocumento.TabStop = False
        '
        'AcepOrCancelTS
        '
        Me.AcepOrCancelTS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.AcepOrCancelTS.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AcepOrCancelTS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.AcepOrCancelTS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAceptar, Me.btnCancelar})
        Me.AcepOrCancelTS.Location = New System.Drawing.Point(0, 637)
        Me.AcepOrCancelTS.Name = "AcepOrCancelTS"
        Me.AcepOrCancelTS.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.AcepOrCancelTS.Size = New System.Drawing.Size(584, 25)
        Me.AcepOrCancelTS.TabIndex = 5
        Me.AcepOrCancelTS.Text = "ToolStrip1"
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.Green
        Me.btnAceptar.Image = Global.Libregco.My.Resources.Resources.Like_x48
        Me.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(65, 22)
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.Red
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(53, 22)
        Me.btnCancelar.Text = "Cancelar"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Acciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(541, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(43, 637)
        Me.Panel2.TabIndex = 424
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.PanelPic)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(541, 637)
        Me.Panel3.TabIndex = 425
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.MenuBar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(541, 26)
        Me.Panel4.TabIndex = 5
        '
        'frm_subir_documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 701)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.AcepOrCancelTS)
        Me.Controls.Add(Me.BarraZoom)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuBar
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_subir_documento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subir documento"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.BarraZoom.ResumeLayout(False)
        Me.BarraZoom.PerformLayout()
        Me.Acciones.ResumeLayout(False)
        Me.Acciones.PerformLayout()
        Me.PanelPic.ResumeLayout(False)
        CType(Me.PicDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AcepOrCancelTS.ResumeLayout(False)
        Me.AcepOrCancelTS.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdiciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraZoom As System.Windows.Forms.ToolStrip
    Friend WithEvents Acciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAumentarZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReducirZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelPic As System.Windows.Forms.Panel
    Friend WithEvents PicDocumento As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarDocumentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LimpiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents EscanearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEscanear As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents btnVerRuta As System.Windows.Forms.ToolStripButton
    Friend WithEvents AcepOrCancelTS As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAceptar As System.Windows.Forms.ToolStripButton
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AbrirUbicaciToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnDownload As ToolStripButton
    Friend WithEvents DescargarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnRotar As ToolStripButton
End Class
