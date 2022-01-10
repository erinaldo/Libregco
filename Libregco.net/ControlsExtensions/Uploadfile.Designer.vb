<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Uploadfile
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Acciones = New System.Windows.Forms.ToolStrip()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEscanear = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.PicDocumento = New System.Windows.Forms.PictureBox()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.Acciones.SuspendLayout()
        CType(Me.PicDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Acciones
        '
        Me.Acciones.AutoSize = False
        Me.Acciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.Acciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Acciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLimpiar, Me.ToolStripSeparator3, Me.btnEscanear, Me.btnBuscar, Me.btnAbrir, Me.btnImprimir})
        Me.Acciones.Location = New System.Drawing.Point(423, 0)
        Me.Acciones.Name = "Acciones"
        Me.Acciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Acciones.Size = New System.Drawing.Size(42, 207)
        Me.Acciones.TabIndex = 4
        Me.Acciones.Text = "ToolStrip2"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(40, 36)
        Me.btnLimpiar.Text = "F5 - Limpiar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(40, 6)
        '
        'btnEscanear
        '
        Me.btnEscanear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEscanear.Image = Global.Libregco.My.Resources.Resources.Scanner_x32
        Me.btnEscanear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEscanear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEscanear.Name = "btnEscanear"
        Me.btnEscanear.Size = New System.Drawing.Size(40, 36)
        Me.btnEscanear.Text = "F1 - Escanear"
        '
        'btnBuscar
        '
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Image_Capture_x32
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(40, 36)
        Me.btnBuscar.Text = "F2 - Buscar"
        '
        'btnAbrir
        '
        Me.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAbrir.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnAbrir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(40, 36)
        Me.btnAbrir.Text = "F3 - Abrir"
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(40, 36)
        Me.btnImprimir.Text = "F4 - Imprimir"
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
        Me.PicDocumento.Size = New System.Drawing.Size(423, 295)
        Me.PicDocumento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicDocumento.TabIndex = 6
        Me.PicDocumento.TabStop = False
        '
        'Uploadfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PicDocumento)
        Me.Controls.Add(Me.Acciones)
        Me.MinimumSize = New System.Drawing.Size(250, 207)
        Me.Name = "Uploadfile"
        Me.Size = New System.Drawing.Size(465, 295)
        Me.Acciones.ResumeLayout(False)
        Me.Acciones.PerformLayout()
        CType(Me.PicDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Acciones As ToolStrip
    Friend WithEvents btnLimpiar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnEscanear As ToolStripButton
    Friend WithEvents btnBuscar As ToolStripButton
    Friend WithEvents btnAbrir As ToolStripButton
    Friend WithEvents btnImprimir As ToolStripButton
    Friend WithEvents PicDocumento As PictureBox
    Friend WithEvents PrintDoc As Printing.PrintDocument
End Class
