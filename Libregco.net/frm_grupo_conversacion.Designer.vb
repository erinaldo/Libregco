<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_grupo_conversacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_grupo_conversacion))
        Me.PicClient = New System.Windows.Forms.PictureBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.txtNombreGrupo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObjetivos = New System.Windows.Forms.TextBox()
        Me.DgvUsers = New System.Windows.Forms.DataGridView()
        Me.IDUserDgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Picture = New System.Windows.Forms.DataGridViewImageColumn()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilePathUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvInvitados = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDConversationUsers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnGuardarConversacion = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveConversationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblUserStatus = New System.Windows.Forms.Label()
        CType(Me.PicClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvInvitados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicClient
        '
        Me.PicClient.ErrorImage = CType(resources.GetObject("PicClient.ErrorImage"), System.Drawing.Image)
        Me.PicClient.Image = CType(resources.GetObject("PicClient.Image"), System.Drawing.Image)
        Me.PicClient.Location = New System.Drawing.Point(9, 52)
        Me.PicClient.Name = "PicClient"
        Me.PicClient.Size = New System.Drawing.Size(118, 110)
        Me.PicClient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicClient.TabIndex = 2
        Me.PicClient.TabStop = False
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblType.Location = New System.Drawing.Point(9, 31)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(101, 15)
        Me.lblType.TabIndex = 17
        Me.lblType.Text = "Imagen del grupo"
        '
        'txtNombreGrupo
        '
        Me.txtNombreGrupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreGrupo.Location = New System.Drawing.Point(132, 49)
        Me.txtNombreGrupo.Name = "txtNombreGrupo"
        Me.txtNombreGrupo.Size = New System.Drawing.Size(276, 23)
        Me.txtNombreGrupo.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(129, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Nombre del grupo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(129, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Objetivos"
        '
        'txtObjetivos
        '
        Me.txtObjetivos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObjetivos.Location = New System.Drawing.Point(133, 93)
        Me.txtObjetivos.Multiline = True
        Me.txtObjetivos.Name = "txtObjetivos"
        Me.txtObjetivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObjetivos.Size = New System.Drawing.Size(276, 53)
        Me.txtObjetivos.TabIndex = 20
        '
        'DgvUsers
        '
        Me.DgvUsers.AllowUserToAddRows = False
        Me.DgvUsers.AllowUserToDeleteRows = False
        Me.DgvUsers.BackgroundColor = System.Drawing.Color.White
        Me.DgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDUserDgv, Me.Picture, Me.User, Me.FilePathUser})
        Me.DgvUsers.Location = New System.Drawing.Point(9, 168)
        Me.DgvUsers.MultiSelect = False
        Me.DgvUsers.Name = "DgvUsers"
        Me.DgvUsers.ReadOnly = True
        Me.DgvUsers.RowHeadersVisible = False
        Me.DgvUsers.RowTemplate.Height = 45
        Me.DgvUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvUsers.Size = New System.Drawing.Size(400, 194)
        Me.DgvUsers.TabIndex = 22
        '
        'IDUserDgv
        '
        Me.IDUserDgv.HeaderText = "IDUser"
        Me.IDUserDgv.Name = "IDUserDgv"
        Me.IDUserDgv.ReadOnly = True
        Me.IDUserDgv.Visible = False
        Me.IDUserDgv.Width = 130
        '
        'Picture
        '
        Me.Picture.HeaderText = ""
        Me.Picture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Picture.Name = "Picture"
        Me.Picture.ReadOnly = True
        Me.Picture.Width = 60
        '
        'User
        '
        Me.User.HeaderText = "Usuarios conectados"
        Me.User.Name = "User"
        Me.User.ReadOnly = True
        Me.User.Width = 335
        '
        'FilePathUser
        '
        Me.FilePathUser.HeaderText = "FilePath"
        Me.FilePathUser.Name = "FilePathUser"
        Me.FilePathUser.ReadOnly = True
        Me.FilePathUser.Visible = False
        '
        'DgvInvitados
        '
        Me.DgvInvitados.AllowUserToAddRows = False
        Me.DgvInvitados.AllowUserToDeleteRows = False
        Me.DgvInvitados.BackgroundColor = System.Drawing.Color.White
        Me.DgvInvitados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvInvitados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvInvitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvInvitados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.IDConversationUsers, Me.Nulo})
        Me.DgvInvitados.Location = New System.Drawing.Point(9, 384)
        Me.DgvInvitados.MultiSelect = False
        Me.DgvInvitados.Name = "DgvInvitados"
        Me.DgvInvitados.ReadOnly = True
        Me.DgvInvitados.RowHeadersVisible = False
        Me.DgvInvitados.RowTemplate.Height = 45
        Me.DgvInvitados.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvInvitados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvInvitados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvInvitados.Size = New System.Drawing.Size(400, 180)
        Me.DgvInvitados.TabIndex = 23
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDUser"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Usuarios invitados"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 335
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "FilePath"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'IDConversationUsers
        '
        Me.IDConversationUsers.HeaderText = "IDConversationUsers"
        Me.IDConversationUsers.Name = "IDConversationUsers"
        Me.IDConversationUsers.ReadOnly = True
        Me.IDConversationUsers.Visible = False
        '
        'Nulo
        '
        Me.Nulo.HeaderText = "Nulo"
        Me.Nulo.Name = "Nulo"
        Me.Nulo.ReadOnly = True
        Me.Nulo.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 600)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(419, 22)
        Me.StatusStrip1.TabIndex = 24
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'btnGuardarConversacion
        '
        Me.btnGuardarConversacion.Location = New System.Drawing.Point(241, 570)
        Me.btnGuardarConversacion.Name = "btnGuardarConversacion"
        Me.btnGuardarConversacion.Size = New System.Drawing.Size(168, 27)
        Me.btnGuardarConversacion.TabIndex = 25
        Me.btnGuardarConversacion.Text = "Guardar nueva conversación"
        Me.btnGuardarConversacion.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 570)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 27)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Eliminar invitado"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 365)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 15)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Haz click sobre el usuario para invitar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(419, 24)
        Me.MenuStrip1.TabIndex = 28
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendFileToolStripMenuItem, Me.ToolStripSeparator6, Me.SaveConversationToolStripMenuItem, Me.ToolStripSeparator7, Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(60, 20)
        Me.FileToolStripMenuItem1.Text = "Archivo"
        '
        'SendFileToolStripMenuItem
        '
        Me.SendFileToolStripMenuItem.Name = "SendFileToolStripMenuItem"
        Me.SendFileToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SendFileToolStripMenuItem.Text = "&Nueva Conversación"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(180, 6)
        '
        'SaveConversationToolStripMenuItem
        '
        Me.SaveConversationToolStripMenuItem.Name = "SaveConversationToolStripMenuItem"
        Me.SaveConversationToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SaveConversationToolStripMenuItem.Text = "&Guardar "
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(180, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(183, 22)
        Me.ExitToolStripMenuItem1.Text = "Salir"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.HelpToolStripMenuItem.Text = "Ayuda"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Image = CType(resources.GetObject("HelpToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.HelpToolStripMenuItem1.Text = "Ayuda"
        '
        'lblUserStatus
        '
        Me.lblUserStatus.AutoSize = True
        Me.lblUserStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUserStatus.Location = New System.Drawing.Point(154, 149)
        Me.lblUserStatus.Name = "lblUserStatus"
        Me.lblUserStatus.Size = New System.Drawing.Size(0, 15)
        Me.lblUserStatus.TabIndex = 29
        '
        'frm_grupo_conversacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 622)
        Me.Controls.Add(Me.lblUserStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnGuardarConversacion)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DgvInvitados)
        Me.Controls.Add(Me.DgvUsers)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtObjetivos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombreGrupo)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.PicClient)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_grupo_conversacion"
        Me.Text = "Conversación grupal"
        CType(Me.PicClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvInvitados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicClient As System.Windows.Forms.PictureBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObjetivos As System.Windows.Forms.TextBox
    Friend WithEvents DgvUsers As System.Windows.Forms.DataGridView
    Friend WithEvents DgvInvitados As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btnGuardarConversacion As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveConversationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblUserStatus As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents IDUserDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Picture As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilePathUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDConversationUsers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nulo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
