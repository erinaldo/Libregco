<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_forma_pago_cxp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_forma_pago_cxp))
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.txtCheque = New System.Windows.Forms.TextBox()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.txtTransferencia = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblBancoCheque = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBeneficiario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxCuenta = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNoCheque = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblBancoTransferencia = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReferenciaTransferencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxCuentaTransferencia = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.lblNombreSuplidor = New System.Windows.Forms.Label()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 549)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(665, 25)
        Me.BarraEstado.TabIndex = 357
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
        'txtCheque
        '
        Me.txtCheque.Enabled = False
        Me.txtCheque.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheque.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtCheque.Location = New System.Drawing.Point(89, 19)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(241, 33)
        Me.txtCheque.TabIndex = 358
        Me.txtCheque.Text = "RD$ 0.00"
        Me.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEfectivo.Location = New System.Drawing.Point(19, 65)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(49, 15)
        Me.lblEfectivo.TabIndex = 362
        Me.lblEfectivo.Text = "Efectivo"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Enabled = False
        Me.txtEfectivo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtEfectivo.Location = New System.Drawing.Point(101, 59)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(241, 33)
        Me.txtEfectivo.TabIndex = 359
        Me.txtEfectivo.Text = "RD$ 0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTransferencia
        '
        Me.txtTransferencia.Enabled = False
        Me.txtTransferencia.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransferencia.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtTransferencia.Location = New System.Drawing.Point(89, 22)
        Me.txtTransferencia.Name = "txtTransferencia"
        Me.txtTransferencia.Size = New System.Drawing.Size(241, 33)
        Me.txtTransferencia.TabIndex = 360
        Me.txtTransferencia.Text = "RD$ 0.00"
        Me.txtTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblBancoCheque)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtBeneficiario)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpFechaPago)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbxCuenta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCheque)
        Me.GroupBox1.Controls.Add(Me.txtNoCheque)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(641, 188)
        Me.GroupBox1.TabIndex = 364
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cheque"
        '
        'lblBancoCheque
        '
        Me.lblBancoCheque.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBancoCheque.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblBancoCheque.Location = New System.Drawing.Point(280, 84)
        Me.lblBancoCheque.Name = "lblBancoCheque"
        Me.lblBancoCheque.Size = New System.Drawing.Size(339, 13)
        Me.lblBancoCheque.TabIndex = 446
        Me.lblBancoCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Location = New System.Drawing.Point(8, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 15)
        Me.Label9.TabIndex = 445
        Me.Label9.Text = "Beneficiario"
        '
        'txtBeneficiario
        '
        Me.txtBeneficiario.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtBeneficiario.Location = New System.Drawing.Point(88, 145)
        Me.txtBeneficiario.Name = "txtBeneficiario"
        Me.txtBeneficiario.Size = New System.Drawing.Size(531, 30)
        Me.txtBeneficiario.TabIndex = 443
        Me.txtBeneficiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(6, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 15)
        Me.Label4.TabIndex = 442
        Me.Label4.Text = "Fecha"
        '
        'dtpFechaPago
        '
        Me.dtpFechaPago.CustomFormat = ""
        Me.dtpFechaPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaPago.Location = New System.Drawing.Point(89, 116)
        Me.dtpFechaPago.Name = "dtpFechaPago"
        Me.dtpFechaPago.Size = New System.Drawing.Size(115, 23)
        Me.dtpFechaPago.TabIndex = 441
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(6, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 440
        Me.Label3.Text = "Monto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(6, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 439
        Me.Label2.Text = "Cuenta"
        '
        'cbxCuenta
        '
        Me.cbxCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCuenta.FormattingEnabled = True
        Me.cbxCuenta.Location = New System.Drawing.Point(89, 58)
        Me.cbxCuenta.Name = "cbxCuenta"
        Me.cbxCuenta.Size = New System.Drawing.Size(530, 23)
        Me.cbxCuenta.TabIndex = 359
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(6, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 438
        Me.Label1.Text = "No. Cheque"
        '
        'txtNoCheque
        '
        Me.txtNoCheque.BackColor = System.Drawing.Color.White
        Me.txtNoCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNoCheque.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtNoCheque.Location = New System.Drawing.Point(89, 87)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.ReadOnly = True
        Me.txtNoCheque.Size = New System.Drawing.Size(182, 23)
        Me.txtNoCheque.TabIndex = 437
        Me.txtNoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = ""
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(-185, 187)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(115, 23)
        Me.DateTimePicker1.TabIndex = 428
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblBancoTransferencia)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtReferenciaTransferencia)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbxCuentaTransferencia)
        Me.GroupBox2.Controls.Add(Me.txtTransferencia)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 291)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(641, 130)
        Me.GroupBox2.TabIndex = 365
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transferencia"
        '
        'lblBancoTransferencia
        '
        Me.lblBancoTransferencia.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBancoTransferencia.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblBancoTransferencia.Location = New System.Drawing.Point(277, 87)
        Me.lblBancoTransferencia.Name = "lblBancoTransferencia"
        Me.lblBancoTransferencia.Size = New System.Drawing.Size(342, 15)
        Me.lblBancoTransferencia.TabIndex = 447
        Me.lblBancoTransferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(6, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 15)
        Me.Label8.TabIndex = 446
        Me.Label8.Text = "Referencia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(6, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 446
        Me.Label7.Text = "Cuenta"
        '
        'txtReferenciaTransferencia
        '
        Me.txtReferenciaTransferencia.BackColor = System.Drawing.Color.White
        Me.txtReferenciaTransferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtReferenciaTransferencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtReferenciaTransferencia.Location = New System.Drawing.Point(89, 90)
        Me.txtReferenciaTransferencia.Name = "txtReferenciaTransferencia"
        Me.txtReferenciaTransferencia.ReadOnly = True
        Me.txtReferenciaTransferencia.Size = New System.Drawing.Size(182, 23)
        Me.txtReferenciaTransferencia.TabIndex = 445
        Me.txtReferenciaTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(8, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 15)
        Me.Label6.TabIndex = 445
        Me.Label6.Text = "Monto"
        '
        'cbxCuentaTransferencia
        '
        Me.cbxCuentaTransferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCuentaTransferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCuentaTransferencia.FormattingEnabled = True
        Me.cbxCuentaTransferencia.Location = New System.Drawing.Point(89, 61)
        Me.cbxCuentaTransferencia.Name = "cbxCuentaTransferencia"
        Me.cbxCuentaTransferencia.Size = New System.Drawing.Size(530, 23)
        Me.cbxCuentaTransferencia.TabIndex = 445
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancelar.Image = Global.Libregco.My.Resources.Resources.Dislike_x48
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(503, 454)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 74)
        Me.btnCancelar.TabIndex = 367
        Me.btnCancelar.Text = "  Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnContinuar
        '
        Me.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContinuar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnContinuar.Image = Global.Libregco.My.Resources.Resources.Like_x48
        Me.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnContinuar.Location = New System.Drawing.Point(312, 454)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(185, 74)
        Me.btnContinuar.TabIndex = 366
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'lblNombreSuplidor
        '
        Me.lblNombreSuplidor.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreSuplidor.Font = New System.Drawing.Font("Arial", 13.0!)
        Me.lblNombreSuplidor.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNombreSuplidor.Location = New System.Drawing.Point(-5, 17)
        Me.lblNombreSuplidor.Name = "lblNombreSuplidor"
        Me.lblNombreSuplidor.Size = New System.Drawing.Size(670, 23)
        Me.lblNombreSuplidor.TabIndex = 368
        Me.lblNombreSuplidor.Text = "NOMBRE DEL SUPLIDOR"
        Me.lblNombreSuplidor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_forma_pago_cxp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 574)
        Me.Controls.Add(Me.lblNombreSuplidor)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.txtEfectivo)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_forma_pago_cxp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pagos múltiples"
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents txtEfectivo As System.Windows.Forms.TextBox
    Friend WithEvents txtTransferencia As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNoCheque As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReferenciaTransferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxCuentaTransferencia As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblNombreSuplidor As System.Windows.Forms.Label
    Friend WithEvents lblBancoCheque As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblBancoTransferencia As System.Windows.Forms.Label
End Class
