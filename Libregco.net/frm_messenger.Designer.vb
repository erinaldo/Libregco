<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_messenger
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_messenger))
        Me.PicClient = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnlineToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AwayToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBusy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAppearOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveConversationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtmessage = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStat = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.AttachfilesPath = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DgvMessages = New System.Windows.Forms.DataGridView()
        Me.IDFormat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDMessageDgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDConversationUsersDgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataReadDgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateReadDgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsReadChk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Conversations = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DgvConversations = New System.Windows.Forms.DataGridView()
        Me.IDConversationDgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageConversation = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Subject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateConversation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileImagePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoReadMessageCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsInvididual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDConversacionA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lblShowing = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.DgvUsers = New System.Windows.Forms.DataGridView()
        Me.IDUserDgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Picture = New System.Windows.Forms.DataGridViewImageColumn()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDUserStatusDgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ARGBsers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilePathUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBuscarUsuarios = New Libregco.Watermark()
        Me.lblType = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CurrentConversationPicture = New System.Windows.Forms.PictureBox()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.Updater = New System.Windows.Forms.Timer(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.lblName = New System.Windows.Forms.Label()
        Me.NTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        CType(Me.PicClient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DgvMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Conversations.SuspendLayout()
        CType(Me.DgvConversations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CurrentConversationPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicClient
        '
        Me.PicClient.Location = New System.Drawing.Point(5, 27)
        Me.PicClient.Name = "PicClient"
        Me.PicClient.Size = New System.Drawing.Size(101, 95)
        Me.PicClient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicClient.TabIndex = 1
        Me.PicClient.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(616, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusToolStripMenuItem2, Me.ToolStripSeparator9, Me.SendFileToolStripMenuItem, Me.ToolStripSeparator6, Me.SaveConversationToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ToolStripSeparator7, Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(60, 20)
        Me.FileToolStripMenuItem1.Text = "Archivo"
        '
        'StatusToolStripMenuItem2
        '
        Me.StatusToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnlineToolStripMenuItem2, Me.AwayToolStripMenuItem2, Me.mnuBusy, Me.mnuAppearOff})
        Me.StatusToolStripMenuItem2.Name = "StatusToolStripMenuItem2"
        Me.StatusToolStripMenuItem2.Size = New System.Drawing.Size(159, 22)
        Me.StatusToolStripMenuItem2.Text = "Estado"
        '
        'OnlineToolStripMenuItem2
        '
        Me.OnlineToolStripMenuItem2.Name = "OnlineToolStripMenuItem2"
        Me.OnlineToolStripMenuItem2.Size = New System.Drawing.Size(226, 22)
        Me.OnlineToolStripMenuItem2.Tag = "1"
        Me.OnlineToolStripMenuItem2.Text = "Activo"
        '
        'AwayToolStripMenuItem2
        '
        Me.AwayToolStripMenuItem2.Name = "AwayToolStripMenuItem2"
        Me.AwayToolStripMenuItem2.Size = New System.Drawing.Size(226, 22)
        Me.AwayToolStripMenuItem2.Tag = "2"
        Me.AwayToolStripMenuItem2.Text = "Lejos"
        '
        'mnuBusy
        '
        Me.mnuBusy.Name = "mnuBusy"
        Me.mnuBusy.Size = New System.Drawing.Size(226, 22)
        Me.mnuBusy.Tag = "3"
        Me.mnuBusy.Text = "Ocupado"
        '
        'mnuAppearOff
        '
        Me.mnuAppearOff.Name = "mnuAppearOff"
        Me.mnuAppearOff.Size = New System.Drawing.Size(226, 22)
        Me.mnuAppearOff.Tag = "4"
        Me.mnuAppearOff.Text = "Mostrar como desconectado"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(156, 6)
        '
        'SendFileToolStripMenuItem
        '
        Me.SendFileToolStripMenuItem.Name = "SendFileToolStripMenuItem"
        Me.SendFileToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SendFileToolStripMenuItem.Text = "&Enviar arhivos"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(156, 6)
        '
        'SaveConversationToolStripMenuItem
        '
        Me.SaveConversationToolStripMenuItem.Name = "SaveConversationToolStripMenuItem"
        Me.SaveConversationToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SaveConversationToolStripMenuItem.Text = "&Guardar como..."
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PrintToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(156, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.ExitToolStripMenuItem1.Text = "Salir"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopy, Me.ToolStripSeparator5, Me.mnuSelectAll})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.EditToolStripMenuItem.Text = "Editar"
        '
        'mnuCopy
        '
        Me.mnuCopy.Name = "mnuCopy"
        Me.mnuCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuCopy.Size = New System.Drawing.Size(171, 22)
        Me.mnuCopy.Text = "&Copiar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(168, 6)
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(171, 22)
        Me.mnuSelectAll.Text = "S&eleccionar todo..."
        '
        'txtmessage
        '
        Me.txtmessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtmessage.Location = New System.Drawing.Point(10, 445)
        Me.txtmessage.MaxLength = 250
        Me.txtmessage.Multiline = True
        Me.txtmessage.Name = "txtmessage"
        Me.txtmessage.Size = New System.Drawing.Size(584, 51)
        Me.txtmessage.TabIndex = 8
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStat})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 713)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.Size = New System.Drawing.Size(616, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStat
        '
        Me.lblStat.ForeColor = System.Drawing.Color.Black
        Me.lblStat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStat.Name = "lblStat"
        Me.lblStat.Size = New System.Drawing.Size(601, 17)
        Me.lblStat.Spring = True
        Me.lblStat.Text = "Último mensaje recibido en fecha:"
        Me.lblStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSend
        '
        Me.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSend.Enabled = False
        Me.btnSend.Location = New System.Drawing.Point(441, 499)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(154, 38)
        Me.btnSend.TabIndex = 9
        Me.btnSend.Text = "Envíar"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(155, 50)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 15)
        Me.lblStatus.TabIndex = 15
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.Conversations)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 136)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(612, 574)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.txtmessage)
        Me.TabPage1.Controls.Add(Me.btnSend)
        Me.TabPage1.Controls.Add(Me.AttachfilesPath)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.DgvMessages)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(604, 543)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Chat"
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.Location = New System.Drawing.Point(528, 416)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(67, 23)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "Eliminar"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'AttachfilesPath
        '
        Me.AttachfilesPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.AttachfilesPath.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.AttachfilesPath.Location = New System.Drawing.Point(135, 416)
        Me.AttachfilesPath.Name = "AttachfilesPath"
        Me.AttachfilesPath.Size = New System.Drawing.Size(387, 23)
        Me.AttachfilesPath.TabIndex = 22
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.Location = New System.Drawing.Point(10, 416)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Adjuntar achivo(s)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DgvMessages
        '
        Me.DgvMessages.AllowUserToAddRows = False
        Me.DgvMessages.AllowUserToDeleteRows = False
        Me.DgvMessages.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgvMessages.BackgroundColor = System.Drawing.Color.White
        Me.DgvMessages.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvMessages.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMessages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDFormat, Me.IDMessageDgv, Me.IDConversationUsersDgv, Me.Message, Me.DataReadDgv, Me.DateReadDgv, Me.IsReadChk})
        Me.DgvMessages.Dock = System.Windows.Forms.DockStyle.Top
        Me.DgvMessages.GridColor = System.Drawing.Color.White
        Me.DgvMessages.Location = New System.Drawing.Point(3, 3)
        Me.DgvMessages.Name = "DgvMessages"
        Me.DgvMessages.ReadOnly = True
        Me.DgvMessages.RowHeadersVisible = False
        Me.DgvMessages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMessages.Size = New System.Drawing.Size(598, 407)
        Me.DgvMessages.TabIndex = 0
        '
        'IDFormat
        '
        Me.IDFormat.HeaderText = "IDFormat"
        Me.IDFormat.Name = "IDFormat"
        Me.IDFormat.ReadOnly = True
        Me.IDFormat.Visible = False
        '
        'IDMessageDgv
        '
        Me.IDMessageDgv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.IDMessageDgv.HeaderText = "IDMessageDgv"
        Me.IDMessageDgv.Name = "IDMessageDgv"
        Me.IDMessageDgv.ReadOnly = True
        Me.IDMessageDgv.Visible = False
        '
        'IDConversationUsersDgv
        '
        Me.IDConversationUsersDgv.HeaderText = "IDConversationUsers"
        Me.IDConversationUsersDgv.Name = "IDConversationUsersDgv"
        Me.IDConversationUsersDgv.ReadOnly = True
        Me.IDConversationUsersDgv.Visible = False
        '
        'Message
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Message.DefaultCellStyle = DataGridViewCellStyle1
        Me.Message.HeaderText = "Mensajes"
        Me.Message.Name = "Message"
        Me.Message.ReadOnly = True
        Me.Message.Width = 570
        '
        'DataReadDgv
        '
        Me.DataReadDgv.HeaderText = "Fecha envío"
        Me.DataReadDgv.Name = "DataReadDgv"
        Me.DataReadDgv.ReadOnly = True
        Me.DataReadDgv.Visible = False
        Me.DataReadDgv.Width = 150
        '
        'DateReadDgv
        '
        Me.DateReadDgv.HeaderText = "Leído"
        Me.DateReadDgv.Name = "DateReadDgv"
        Me.DateReadDgv.ReadOnly = True
        Me.DateReadDgv.Visible = False
        Me.DateReadDgv.Width = 135
        '
        'IsReadChk
        '
        Me.IsReadChk.HeaderText = "IsRead"
        Me.IsReadChk.Name = "IsReadChk"
        Me.IsReadChk.ReadOnly = True
        Me.IsReadChk.Visible = False
        Me.IsReadChk.Width = 50
        '
        'Conversations
        '
        Me.Conversations.Controls.Add(Me.Button5)
        Me.Conversations.Controls.Add(Me.Button2)
        Me.Conversations.Controls.Add(Me.DgvConversations)
        Me.Conversations.Controls.Add(Me.Button4)
        Me.Conversations.Controls.Add(Me.lblShowing)
        Me.Conversations.Location = New System.Drawing.Point(4, 27)
        Me.Conversations.Name = "Conversations"
        Me.Conversations.Padding = New System.Windows.Forms.Padding(3)
        Me.Conversations.Size = New System.Drawing.Size(604, 543)
        Me.Conversations.TabIndex = 1
        Me.Conversations.Text = "Conversaciones"
        Me.Conversations.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(181, 485)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(68, 27)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Modificar"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 485)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(172, 27)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "+Nueva conversación grupal"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DgvConversations
        '
        Me.DgvConversations.AllowUserToAddRows = False
        Me.DgvConversations.AllowUserToDeleteRows = False
        Me.DgvConversations.AllowUserToResizeColumns = False
        Me.DgvConversations.AllowUserToResizeRows = False
        Me.DgvConversations.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvConversations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvConversations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvConversations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvConversations.ColumnHeadersVisible = False
        Me.DgvConversations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDConversationDgv, Me.ImageConversation, Me.Subject, Me.DateConversation, Me.FileImagePath, Me.NoReadMessageCount, Me.IsInvididual, Me.IDConversacionA})
        Me.DgvConversations.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvConversations.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvConversations.Dock = System.Windows.Forms.DockStyle.Top
        Me.DgvConversations.GridColor = System.Drawing.Color.White
        Me.DgvConversations.Location = New System.Drawing.Point(3, 3)
        Me.DgvConversations.MultiSelect = False
        Me.DgvConversations.Name = "DgvConversations"
        Me.DgvConversations.ReadOnly = True
        Me.DgvConversations.RowHeadersVisible = False
        Me.DgvConversations.RowTemplate.Height = 65
        Me.DgvConversations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvConversations.Size = New System.Drawing.Size(598, 476)
        Me.DgvConversations.TabIndex = 0
        '
        'IDConversationDgv
        '
        Me.IDConversationDgv.HeaderText = "IDConversationDgv"
        Me.IDConversationDgv.Name = "IDConversationDgv"
        Me.IDConversationDgv.ReadOnly = True
        Me.IDConversationDgv.Visible = False
        '
        'ImageConversation
        '
        Me.ImageConversation.HeaderText = ""
        Me.ImageConversation.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ImageConversation.Name = "ImageConversation"
        Me.ImageConversation.ReadOnly = True
        Me.ImageConversation.Width = 90
        '
        'Subject
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Subject.DefaultCellStyle = DataGridViewCellStyle2
        Me.Subject.HeaderText = "Título"
        Me.Subject.Name = "Subject"
        Me.Subject.ReadOnly = True
        Me.Subject.Width = 275
        '
        'DateConversation
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateConversation.DefaultCellStyle = DataGridViewCellStyle3
        Me.DateConversation.HeaderText = "Fecha creación"
        Me.DateConversation.Name = "DateConversation"
        Me.DateConversation.ReadOnly = True
        Me.DateConversation.Width = 140
        '
        'FileImagePath
        '
        Me.FileImagePath.HeaderText = "FileImagePath"
        Me.FileImagePath.Name = "FileImagePath"
        Me.FileImagePath.ReadOnly = True
        Me.FileImagePath.Visible = False
        '
        'NoReadMessageCount
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NoReadMessageCount.DefaultCellStyle = DataGridViewCellStyle4
        Me.NoReadMessageCount.HeaderText = "No leídos"
        Me.NoReadMessageCount.Name = "NoReadMessageCount"
        Me.NoReadMessageCount.ReadOnly = True
        Me.NoReadMessageCount.Width = 80
        '
        'IsInvididual
        '
        Me.IsInvididual.HeaderText = "IndividualChat"
        Me.IsInvididual.Name = "IsInvididual"
        Me.IsInvididual.ReadOnly = True
        Me.IsInvididual.Visible = False
        '
        'IDConversacionA
        '
        Me.IDConversacionA.HeaderText = "IDConversacion"
        Me.IDConversacionA.Name = "IDConversacionA"
        Me.IDConversacionA.ReadOnly = True
        Me.IDConversacionA.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(495, 485)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(93, 27)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Mostrar todo"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lblShowing
        '
        Me.lblShowing.AutoSize = True
        Me.lblShowing.Location = New System.Drawing.Point(5, 3)
        Me.lblShowing.Name = "lblShowing"
        Me.lblShowing.Size = New System.Drawing.Size(0, 15)
        Me.lblShowing.TabIndex = 12
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button6)
        Me.TabPage2.Controls.Add(Me.DgvUsers)
        Me.TabPage2.Controls.Add(Me.txtBuscarUsuarios)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(604, 543)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Usuarios"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button6.Location = New System.Drawing.Point(561, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(23, 23)
        Me.Button6.TabIndex = 26
        Me.Button6.Text = "X"
        Me.Button6.UseVisualStyleBackColor = False
        Me.Button6.Visible = False
        '
        'DgvUsers
        '
        Me.DgvUsers.AllowUserToAddRows = False
        Me.DgvUsers.AllowUserToDeleteRows = False
        Me.DgvUsers.AllowUserToResizeColumns = False
        Me.DgvUsers.AllowUserToResizeRows = False
        Me.DgvUsers.BackgroundColor = System.Drawing.Color.White
        Me.DgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDUserDgv, Me.Picture, Me.User, Me.IDUserStatusDgv, Me.UserStatus, Me.ARGBsers, Me.FilePathUser})
        Me.DgvUsers.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvUsers.GridColor = System.Drawing.Color.White
        Me.DgvUsers.Location = New System.Drawing.Point(3, 35)
        Me.DgvUsers.MultiSelect = False
        Me.DgvUsers.Name = "DgvUsers"
        Me.DgvUsers.ReadOnly = True
        Me.DgvUsers.RowHeadersVisible = False
        Me.DgvUsers.RowTemplate.Height = 65
        Me.DgvUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvUsers.Size = New System.Drawing.Size(598, 505)
        Me.DgvUsers.TabIndex = 1
        '
        'IDUserDgv
        '
        Me.IDUserDgv.HeaderText = "IDUser"
        Me.IDUserDgv.Name = "IDUserDgv"
        Me.IDUserDgv.ReadOnly = True
        Me.IDUserDgv.Visible = False
        '
        'Picture
        '
        Me.Picture.HeaderText = ""
        Me.Picture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.Picture.Name = "Picture"
        Me.Picture.ReadOnly = True
        Me.Picture.Width = 90
        '
        'User
        '
        Me.User.HeaderText = "Usuarios"
        Me.User.Name = "User"
        Me.User.ReadOnly = True
        Me.User.Width = 345
        '
        'IDUserStatusDgv
        '
        Me.IDUserStatusDgv.HeaderText = "IDUserStatus"
        Me.IDUserStatusDgv.Name = "IDUserStatusDgv"
        Me.IDUserStatusDgv.ReadOnly = True
        Me.IDUserStatusDgv.Visible = False
        '
        'UserStatus
        '
        Me.UserStatus.HeaderText = "Estado"
        Me.UserStatus.Name = "UserStatus"
        Me.UserStatus.ReadOnly = True
        Me.UserStatus.Width = 150
        '
        'ARGBsers
        '
        Me.ARGBsers.HeaderText = "ARGBUsers"
        Me.ARGBsers.Name = "ARGBsers"
        Me.ARGBsers.ReadOnly = True
        Me.ARGBsers.Visible = False
        '
        'FilePathUser
        '
        Me.FilePathUser.HeaderText = "FilePath"
        Me.FilePathUser.Name = "FilePathUser"
        Me.FilePathUser.ReadOnly = True
        Me.FilePathUser.Visible = False
        '
        'txtBuscarUsuarios
        '
        Me.txtBuscarUsuarios.Location = New System.Drawing.Point(6, 6)
        Me.txtBuscarUsuarios.Name = "txtBuscarUsuarios"
        Me.txtBuscarUsuarios.Size = New System.Drawing.Size(577, 23)
        Me.txtBuscarUsuarios.TabIndex = 2
        Me.txtBuscarUsuarios.WatermarkColor = System.Drawing.Color.Gray
        Me.txtBuscarUsuarios.WatermarkText = "Buscar usuarios"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblType.Location = New System.Drawing.Point(6, 22)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(0, 15)
        Me.lblType.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Estado:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblType)
        Me.GroupBox1.Controls.Add(Me.CurrentConversationPicture)
        Me.GroupBox1.Controls.Add(Me.lblSubject)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(322, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 101)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conversación Actual"
        '
        'CurrentConversationPicture
        '
        Me.CurrentConversationPicture.Location = New System.Drawing.Point(195, 11)
        Me.CurrentConversationPicture.Name = "CurrentConversationPicture"
        Me.CurrentConversationPicture.Size = New System.Drawing.Size(84, 84)
        Me.CurrentConversationPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CurrentConversationPicture.TabIndex = 21
        Me.CurrentConversationPicture.TabStop = False
        '
        'lblSubject
        '
        Me.lblSubject.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubject.Location = New System.Drawing.Point(6, 44)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(185, 43)
        Me.lblSubject.TabIndex = 20
        '
        'Updater
        '
        Me.Updater.Interval = 1
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(112, 29)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(51, 15)
        Me.lblName.TabIndex = 23
        Me.lblName.Text = "Nombre"
        '
        'NTimer
        '
        Me.NTimer.Interval = 2000
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'frm_messenger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(616, 735)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PicClient)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_messenger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Libregco Messenger"
        CType(Me.PicClient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DgvMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Conversations.ResumeLayout(False)
        Me.Conversations.PerformLayout()
        CType(Me.DgvConversations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CurrentConversationPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicClient As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnlineToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AwayToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBusy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAppearOff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SendFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveConversationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtmessage As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStat As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Conversations As System.Windows.Forms.TabPage
    Friend WithEvents DgvConversations As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DgvUsers As System.Windows.Forms.DataGridView
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CurrentConversationPicture As System.Windows.Forms.PictureBox
    Friend WithEvents lblShowing As System.Windows.Forms.Label
    Friend WithEvents DgvMessages As System.Windows.Forms.DataGridView
    Friend WithEvents Updater As System.Windows.Forms.Timer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents AttachfilesPath As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents IDUserDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Picture As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDUserStatusDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARGBsers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilePathUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents NTimer As System.Windows.Forms.Timer
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtBuscarUsuarios As Libregco.Watermark
    Friend WithEvents IDConversationDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageConversation As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Subject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateConversation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileImagePath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoReadMessageCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsInvididual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDConversacionA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDFormat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMessageDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDConversationUsersDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Message As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataReadDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateReadDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsReadChk As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
