<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_informacion_empleado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_informacion_empleado))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdentificacion = New System.Windows.Forms.Label()
        Me.lblAlias = New System.Windows.Forms.Label()
        Me.lblFechaIngreso = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.lblNacionalidad = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblGenero = New System.Windows.Forms.Label()
        Me.lblTelefonoHogar = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTelefonoPersonal = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblNacimiento = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblCumpleanos = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PicEmpleado = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DgvAccesos = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PicEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DgvAccesos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(828, 531)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.PicEmpleado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(820, 503)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Información"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblIdentificacion)
        Me.Panel1.Controls.Add(Me.lblAlias)
        Me.Panel1.Controls.Add(Me.lblFechaIngreso)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.lblNombre)
        Me.Panel1.Controls.Add(Me.lblCargo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblCorreo)
        Me.Panel1.Controls.Add(Me.lblNacionalidad)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.lblGenero)
        Me.Panel1.Controls.Add(Me.lblTelefonoHogar)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblTelefonoPersonal)
        Me.Panel1.Controls.Add(Me.lblEdad)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.lblNacimiento)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.lblDomicilio)
        Me.Panel1.Controls.Add(Me.lblCumpleanos)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Location = New System.Drawing.Point(423, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 489)
        Me.Panel1.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.Location = New System.Drawing.Point(232, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Sexo:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIdentificacion
        '
        Me.lblIdentificacion.AutoSize = True
        Me.lblIdentificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIdentificacion.Location = New System.Drawing.Point(101, 59)
        Me.lblIdentificacion.Name = "lblIdentificacion"
        Me.lblIdentificacion.Size = New System.Drawing.Size(0, 15)
        Me.lblIdentificacion.TabIndex = 27
        '
        'lblAlias
        '
        Me.lblAlias.AutoSize = True
        Me.lblAlias.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlias.Location = New System.Drawing.Point(59, 33)
        Me.lblAlias.Name = "lblAlias"
        Me.lblAlias.Size = New System.Drawing.Size(0, 25)
        Me.lblAlias.TabIndex = 26
        '
        'lblFechaIngreso
        '
        Me.lblFechaIngreso.AutoSize = True
        Me.lblFechaIngreso.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic)
        Me.lblFechaIngreso.Location = New System.Drawing.Point(123, 460)
        Me.lblFechaIngreso.Name = "lblFechaIngreso"
        Me.lblFechaIngreso.Size = New System.Drawing.Size(0, 19)
        Me.lblFechaIngreso.TabIndex = 25
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic)
        Me.Label24.Location = New System.Drawing.Point(4, 460)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(117, 19)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Fecha de Ingreso:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombre.Location = New System.Drawing.Point(3, 3)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(0, 30)
        Me.lblNombre.TabIndex = 1
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCargo.Location = New System.Drawing.Point(59, 74)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(0, 25)
        Me.lblCargo.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Alias:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label23.Location = New System.Drawing.Point(3, 74)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 21)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "Cargo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label3.Location = New System.Drawing.Point(3, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 21)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nacionalidad:"
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorreo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblCorreo.Location = New System.Drawing.Point(102, 416)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(0, 21)
        Me.lblCorreo.TabIndex = 21
        '
        'lblNacionalidad
        '
        Me.lblNacionalidad.AutoSize = True
        Me.lblNacionalidad.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNacionalidad.Location = New System.Drawing.Point(3, 121)
        Me.lblNacionalidad.Name = "lblNacionalidad"
        Me.lblNacionalidad.Size = New System.Drawing.Size(0, 25)
        Me.lblNacionalidad.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label20.Location = New System.Drawing.Point(28, 416)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 21)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Correo:"
        '
        'lblGenero
        '
        Me.lblGenero.AutoSize = True
        Me.lblGenero.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.lblGenero.Location = New System.Drawing.Point(279, 33)
        Me.lblGenero.Name = "lblGenero"
        Me.lblGenero.Size = New System.Drawing.Size(0, 20)
        Me.lblGenero.TabIndex = 5
        Me.lblGenero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTelefonoHogar
        '
        Me.lblTelefonoHogar.AutoSize = True
        Me.lblTelefonoHogar.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonoHogar.Location = New System.Drawing.Point(102, 391)
        Me.lblTelefonoHogar.Name = "lblTelefonoHogar"
        Me.lblTelefonoHogar.Size = New System.Drawing.Size(0, 25)
        Me.lblTelefonoHogar.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label7.Location = New System.Drawing.Point(3, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 21)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Edad:"
        '
        'lblTelefonoPersonal
        '
        Me.lblTelefonoPersonal.AutoSize = True
        Me.lblTelefonoPersonal.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonoPersonal.Location = New System.Drawing.Point(102, 367)
        Me.lblTelefonoPersonal.Name = "lblTelefonoPersonal"
        Me.lblTelefonoPersonal.Size = New System.Drawing.Size(0, 25)
        Me.lblTelefonoPersonal.TabIndex = 18
        '
        'lblEdad
        '
        Me.lblEdad.AutoSize = True
        Me.lblEdad.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.Location = New System.Drawing.Point(59, 181)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(0, 25)
        Me.lblEdad.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label17.Location = New System.Drawing.Point(28, 394)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 21)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Hogar:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label8.Location = New System.Drawing.Point(3, 162)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 21)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Nacimiento:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label16.Location = New System.Drawing.Point(28, 370)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 21)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Personal:"
        '
        'lblNacimiento
        '
        Me.lblNacimiento.AutoSize = True
        Me.lblNacimiento.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNacimiento.Location = New System.Drawing.Point(106, 159)
        Me.lblNacimiento.Name = "lblNacimiento"
        Me.lblNacimiento.Size = New System.Drawing.Size(0, 25)
        Me.lblNacimiento.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label15.Location = New System.Drawing.Point(3, 349)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 21)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Contactos:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label10.Location = New System.Drawing.Point(3, 203)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 21)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Cumpleaños en:"
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDomicilio.Location = New System.Drawing.Point(3, 264)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(385, 87)
        Me.lblDomicilio.TabIndex = 14
        '
        'lblCumpleanos
        '
        Me.lblCumpleanos.AutoSize = True
        Me.lblCumpleanos.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblCumpleanos.Location = New System.Drawing.Point(130, 203)
        Me.lblCumpleanos.Name = "lblCumpleanos"
        Me.lblCumpleanos.Size = New System.Drawing.Size(0, 25)
        Me.lblCumpleanos.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label13.Location = New System.Drawing.Point(3, 243)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 21)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Domicilio:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(3, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 15)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "No. de Identidad:"
        '
        'PicEmpleado
        '
        Me.PicEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.PicEmpleado.Location = New System.Drawing.Point(0, 0)
        Me.PicEmpleado.Name = "PicEmpleado"
        Me.PicEmpleado.Size = New System.Drawing.Size(417, 503)
        Me.PicEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicEmpleado.TabIndex = 0
        Me.PicEmpleado.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DgvAccesos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(820, 503)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Historial de Accesos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DgvAccesos
        '
        Me.DgvAccesos.AllowUserToAddRows = False
        Me.DgvAccesos.AllowUserToDeleteRows = False
        Me.DgvAccesos.BackgroundColor = System.Drawing.Color.White
        Me.DgvAccesos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAccesos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAccesos.Location = New System.Drawing.Point(3, 3)
        Me.DgvAccesos.MultiSelect = False
        Me.DgvAccesos.Name = "DgvAccesos"
        Me.DgvAccesos.ReadOnly = True
        Me.DgvAccesos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvAccesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAccesos.Size = New System.Drawing.Size(814, 497)
        Me.DgvAccesos.TabIndex = 0
        '
        'frm_informacion_empleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 531)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_informacion_empleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Información de Empleados"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PicEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DgvAccesos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PicEmpleado As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblNacionalidad As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblCumpleanos As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNacimiento As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblGenero As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCargo As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblCorreo As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblTelefonoHogar As System.Windows.Forms.Label
    Friend WithEvents lblTelefonoPersonal As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblDomicilio As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFechaIngreso As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblAlias As System.Windows.Forms.Label
    Friend WithEvents lblIdentificacion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvAccesos As System.Windows.Forms.DataGridView
End Class
