<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_impresion_eventos_especiales
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
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PicImagen = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCantBoletos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CbxInstalledPrinters = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.chkImpresionAutomatica = New System.Windows.Forms.CheckBox()
        Me.lblEvento = New System.Windows.Forms.Label()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEncabezado
        '
        Me.lblEncabezado.BackColor = System.Drawing.Color.DodgerBlue
        Me.lblEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEncabezado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblEncabezado.ForeColor = System.Drawing.Color.White
        Me.lblEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(418, 34)
        Me.lblEncabezado.TabIndex = 0
        Me.lblEncabezado.Text = "Eventos Especiales"
        Me.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Evento"
        '
        'PicImagen
        '
        Me.PicImagen.Location = New System.Drawing.Point(83, 41)
        Me.PicImagen.Name = "PicImagen"
        Me.PicImagen.Size = New System.Drawing.Size(250, 143)
        Me.PicImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImagen.TabIndex = 2
        Me.PicImagen.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(66, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Se ha(n) generado"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantBoletos
        '
        Me.lblCantBoletos.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantBoletos.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblCantBoletos.Location = New System.Drawing.Point(203, 198)
        Me.lblCantBoletos.Name = "lblCantBoletos"
        Me.lblCantBoletos.Size = New System.Drawing.Size(52, 25)
        Me.lblCantBoletos.TabIndex = 4
        Me.lblCantBoletos.Text = "0"
        Me.lblCantBoletos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(261, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 25)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "boleto(s)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label6.Location = New System.Drawing.Point(1, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(417, 2)
        Me.Label6.TabIndex = 6
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.PictureBox2.Location = New System.Drawing.Point(13, 262)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 354
        Me.PictureBox2.TabStop = False
        '
        'CbxInstalledPrinters
        '
        Me.CbxInstalledPrinters.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CbxInstalledPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxInstalledPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxInstalledPrinters.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxInstalledPrinters.FormattingEnabled = True
        Me.CbxInstalledPrinters.Location = New System.Drawing.Point(40, 265)
        Me.CbxInstalledPrinters.Name = "CbxInstalledPrinters"
        Me.CbxInstalledPrinters.Size = New System.Drawing.Size(193, 23)
        Me.CbxInstalledPrinters.TabIndex = 353
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(10, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 352
        Me.Label7.Text = "Punto de impresión"
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(250, 252)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(152, 53)
        Me.btnImprimir.TabIndex = 355
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Red
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Location = New System.Drawing.Point(390, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(23, 23)
        Me.btnClose.TabIndex = 422
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'chkImpresionAutomatica
        '
        Me.chkImpresionAutomatica.AutoSize = True
        Me.chkImpresionAutomatica.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chkImpresionAutomatica.Location = New System.Drawing.Point(13, 292)
        Me.chkImpresionAutomatica.Name = "chkImpresionAutomatica"
        Me.chkImpresionAutomatica.Size = New System.Drawing.Size(160, 17)
        Me.chkImpresionAutomatica.TabIndex = 423
        Me.chkImpresionAutomatica.Text = "Imprimir automáticamente"
        Me.chkImpresionAutomatica.UseVisualStyleBackColor = True
        '
        'lblEvento
        '
        Me.lblEvento.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvento.Location = New System.Drawing.Point(-2, 187)
        Me.lblEvento.Name = "lblEvento"
        Me.lblEvento.Size = New System.Drawing.Size(420, 15)
        Me.lblEvento.TabIndex = 424
        Me.lblEvento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_impresion_eventos_especiales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 317)
        Me.Controls.Add(Me.lblEvento)
        Me.Controls.Add(Me.chkImpresionAutomatica)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CbxInstalledPrinters)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCantBoletos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PicImagen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblEncabezado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frm_impresion_eventos_especiales"
        Me.Text = "Eventos Especiales"
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblEncabezado As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PicImagen As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblCantBoletos As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents CbxInstalledPrinters As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents chkImpresionAutomatica As CheckBox
    Friend WithEvents lblEvento As Label
End Class
