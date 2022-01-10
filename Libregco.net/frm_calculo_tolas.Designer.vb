<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_calculo_tolas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_calculo_tolas))
        Me.txtAncho = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtImporte = New DevExpress.XtraEditors.TextEdit()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPrecio = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCantidadLibras = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LUEGrosor = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtValor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtLargo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SeparatorControl3 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.cbxMedida = New System.Windows.Forms.ComboBox()
        CType(Me.txtAncho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidadLibras.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUEGrosor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLargo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAncho
        '
        Me.txtAncho.Location = New System.Drawing.Point(14, 34)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAncho.Properties.Appearance.Options.UseFont = True
        Me.txtAncho.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAncho.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtAncho.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtAncho.Properties.Mask.EditMask = "n2"
        Me.txtAncho.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAncho.Properties.Mask.ShowPlaceHolders = False
        Me.txtAncho.Properties.NullText = "0"
        Me.txtAncho.Size = New System.Drawing.Size(84, 36)
        Me.txtAncho.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.cbxMedida)
        Me.PanelControl1.Controls.Add(Me.CheckEdit1)
        Me.PanelControl1.Controls.Add(Me.LabelControl12)
        Me.PanelControl1.Controls.Add(Me.txtImporte)
        Me.PanelControl1.Controls.Add(Me.txtCantidad)
        Me.PanelControl1.Controls.Add(Me.LabelControl11)
        Me.PanelControl1.Controls.Add(Me.LabelControl10)
        Me.PanelControl1.Controls.Add(Me.txtPrecio)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.txtCantidadLibras)
        Me.PanelControl1.Controls.Add(Me.LabelControl8)
        Me.PanelControl1.Controls.Add(Me.LUEGrosor)
        Me.PanelControl1.Controls.Add(Me.txtValor)
        Me.PanelControl1.Controls.Add(Me.LabelControl7)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.SeparatorControl2)
        Me.PanelControl1.Controls.Add(Me.txtLargo)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.txtAncho)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SeparatorControl3)
        Me.PanelControl1.Location = New System.Drawing.Point(12, 46)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(509, 355)
        Me.PanelControl1.TabIndex = 1
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(5, 331)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Redondear cálculos"
        Me.CheckEdit1.Size = New System.Drawing.Size(175, 19)
        Me.CheckEdit1.TabIndex = 20
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Appearance.Options.UseFont = True
        Me.LabelControl12.Location = New System.Drawing.Point(300, 194)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(98, 21)
        Me.LabelControl12.TabIndex = 19
        Me.LabelControl12.Text = "Importe total"
        '
        'txtImporte
        '
        Me.txtImporte.Enabled = False
        Me.txtImporte.Location = New System.Drawing.Point(300, 217)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtImporte.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 24.0!)
        Me.txtImporte.Properties.Appearance.Options.UseBackColor = True
        Me.txtImporte.Properties.Appearance.Options.UseFont = True
        Me.txtImporte.Properties.Appearance.Options.UseTextOptions = True
        Me.txtImporte.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtImporte.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtImporte.Properties.DisplayFormat.FormatString = "c2"
        Me.txtImporte.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtImporte.Properties.EditFormat.FormatString = "c2"
        Me.txtImporte.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtImporte.Properties.Mask.EditMask = "c"
        Me.txtImporte.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtImporte.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtImporte.Properties.NullText = "0"
        Me.txtImporte.Size = New System.Drawing.Size(197, 46)
        Me.txtImporte.TabIndex = 18
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(217, 217)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtCantidad.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCantidad.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCantidad.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtCantidad.Properties.Mask.EditMask = "n2"
        Me.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCantidad.Properties.Mask.ShowPlaceHolders = False
        Me.txtCantidad.Properties.NullText = "1"
        Me.txtCantidad.Size = New System.Drawing.Size(84, 36)
        Me.txtCantidad.TabIndex = 4
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Appearance.Options.UseFont = True
        Me.LabelControl11.Location = New System.Drawing.Point(217, 194)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(65, 21)
        Me.LabelControl11.TabIndex = 17
        Me.LabelControl11.Text = "Cantidad"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Appearance.Options.UseFont = True
        Me.LabelControl10.Location = New System.Drawing.Point(354, 11)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(81, 17)
        Me.LabelControl10.TabIndex = 15
        Me.LabelControl10.Text = "Precio x Libra"
        '
        'txtPrecio
        '
        Me.txtPrecio.EditValue = "50"
        Me.txtPrecio.Location = New System.Drawing.Point(354, 31)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecio.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 20.0!)
        Me.txtPrecio.Properties.Appearance.Options.UseBackColor = True
        Me.txtPrecio.Properties.Appearance.Options.UseFont = True
        Me.txtPrecio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecio.Properties.Mask.EditMask = "c"
        Me.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecio.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPrecio.Properties.NullText = "0"
        Me.txtPrecio.Size = New System.Drawing.Size(143, 40)
        Me.txtPrecio.TabIndex = 3
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(11, 120)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(94, 13)
        Me.LabelControl9.TabIndex = 12
        Me.LabelControl9.Text = "Cantidad de libras.:"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(258, 278)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(239, 51)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "Insertar cálculos"
        '
        'txtCantidadLibras
        '
        Me.txtCantidadLibras.AllowDrop = True
        Me.txtCantidadLibras.Enabled = False
        Me.txtCantidadLibras.Location = New System.Drawing.Point(114, 115)
        Me.txtCantidadLibras.Name = "txtCantidadLibras"
        Me.txtCantidadLibras.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtCantidadLibras.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtCantidadLibras.Properties.Appearance.Options.UseBackColor = True
        Me.txtCantidadLibras.Properties.Appearance.Options.UseFont = True
        Me.txtCantidadLibras.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCantidadLibras.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCantidadLibras.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtCantidadLibras.Properties.DisplayFormat.FormatString = "n2"
        Me.txtCantidadLibras.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCantidadLibras.Properties.EditFormat.FormatString = "n2"
        Me.txtCantidadLibras.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCantidadLibras.Properties.Mask.EditMask = "n"
        Me.txtCantidadLibras.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCantidadLibras.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCantidadLibras.Properties.NullText = "0"
        Me.txtCantidadLibras.Size = New System.Drawing.Size(66, 22)
        Me.txtCantidadLibras.TabIndex = 13
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Location = New System.Drawing.Point(220, 135)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl8.TabIndex = 12
        Me.LabelControl8.Text = "Valor unitario"
        '
        'LUEGrosor
        '
        Me.LUEGrosor.Location = New System.Drawing.Point(232, 34)
        Me.LUEGrosor.Name = "LUEGrosor"
        Me.LUEGrosor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.LUEGrosor.Properties.Appearance.Options.UseFont = True
        Me.LUEGrosor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUEGrosor.Size = New System.Drawing.Size(100, 36)
        Me.LUEGrosor.TabIndex = 2
        '
        'txtValor
        '
        Me.txtValor.Enabled = False
        Me.txtValor.Location = New System.Drawing.Point(300, 123)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtValor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Properties.Appearance.Options.UseBackColor = True
        Me.txtValor.Properties.Appearance.Options.UseFont = True
        Me.txtValor.Properties.Appearance.Options.UseTextOptions = True
        Me.txtValor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtValor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtValor.Properties.DisplayFormat.FormatString = "c2"
        Me.txtValor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtValor.Properties.EditFormat.FormatString = "c2"
        Me.txtValor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtValor.Properties.Mask.EditMask = "c"
        Me.txtValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtValor.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtValor.Properties.NullText = "0"
        Me.txtValor.Size = New System.Drawing.Size(197, 36)
        Me.txtValor.TabIndex = 10
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Location = New System.Drawing.Point(232, 11)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(50, 21)
        Me.LabelControl7.TabIndex = 8
        Me.LabelControl7.Text = "Grosor"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Location = New System.Drawing.Point(215, 31)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(11, 37)
        Me.LabelControl6.TabIndex = 7
        Me.LabelControl6.Text = "-"
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(5, 157)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(499, 42)
        Me.SeparatorControl2.TabIndex = 12
        '
        'txtLargo
        '
        Me.txtLargo.Location = New System.Drawing.Point(125, 34)
        Me.txtLargo.Name = "txtLargo"
        Me.txtLargo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLargo.Properties.Appearance.Options.UseFont = True
        Me.txtLargo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtLargo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtLargo.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtLargo.Properties.Mask.EditMask = "n2"
        Me.txtLargo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtLargo.Properties.Mask.ShowPlaceHolders = False
        Me.txtLargo.Properties.NullText = "0"
        Me.txtLargo.Size = New System.Drawing.Size(84, 36)
        Me.txtLargo.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(104, 31)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(12, 37)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "x"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(125, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 21)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Largo"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(14, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(47, 21)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Ancho"
        '
        'SeparatorControl3
        '
        Me.SeparatorControl3.Location = New System.Drawing.Point(10, 81)
        Me.SeparatorControl3.Name = "SeparatorControl3"
        Me.SeparatorControl3.Size = New System.Drawing.Size(494, 42)
        Me.SeparatorControl3.TabIndex = 14
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Location = New System.Drawing.Point(12, 9)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Properties.Appearance.Options.UseFont = True
        Me.txtDescripcion.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDescripcion.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.txtDescripcion.Size = New System.Drawing.Size(509, 30)
        Me.txtDescripcion.TabIndex = 4
        '
        'cbxMedida
        '
        Me.cbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMedida.FormattingEnabled = True
        Me.cbxMedida.Items.AddRange(New Object() {"Pulgadas", "Pies"})
        Me.cbxMedida.Location = New System.Drawing.Point(14, 74)
        Me.cbxMedida.Name = "cbxMedida"
        Me.cbxMedida.Size = New System.Drawing.Size(195, 21)
        Me.cbxMedida.TabIndex = 21
        '
        'frm_calculo_tolas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 413)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_calculo_tolas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cálculo de tolas"
        CType(Me.txtAncho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidadLibras.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUEGrosor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLargo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtAncho As XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As XtraEditors.PanelControl
    Friend WithEvents LabelControl7 As XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As XtraEditors.LabelControl
    Friend WithEvents txtLargo As XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As XtraEditors.LabelControl
    Friend WithEvents LUEGrosor As XtraEditors.LookUpEdit
    Friend WithEvents txtDescripcion As XtraEditors.TextEdit
    Friend WithEvents txtValor As XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As XtraEditors.LabelControl
    Friend WithEvents SeparatorControl2 As XtraEditors.SeparatorControl
    Friend WithEvents txtCantidadLibras As XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As XtraEditors.SimpleButton
    Friend WithEvents SeparatorControl3 As XtraEditors.SeparatorControl
    Friend WithEvents LabelControl10 As XtraEditors.LabelControl
    Friend WithEvents txtPrecio As XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As XtraEditors.LabelControl
    Friend WithEvents txtImporte As XtraEditors.TextEdit
    Friend WithEvents txtCantidad As XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As XtraEditors.LabelControl
    Friend WithEvents CheckEdit1 As XtraEditors.CheckEdit
    Friend WithEvents cbxMedida As ComboBox
End Class
