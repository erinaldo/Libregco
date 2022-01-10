<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DinamicMenu
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DinamicMenu))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Picture = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgvCategorias = New System.Windows.Forms.DataGridView()
        Me.IDCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Categoria = New System.Windows.Forms.DataGridViewLinkColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvCategorias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Picture)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgvCategorias)
        Me.SplitContainer1.Panel2Collapsed = True
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblName.Name = "lblName"
        '
        'Picture
        '
        resources.ApplyResources(Me.Picture, "Picture")
        Me.Picture.BackColor = System.Drawing.Color.White
        Me.Picture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Picture.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.Picture.Name = "Picture"
        Me.Picture.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.Name = "Label2"
        '
        'DgvCategorias
        '
        Me.DgvCategorias.AllowUserToAddRows = False
        Me.DgvCategorias.AllowUserToDeleteRows = False
        Me.DgvCategorias.AllowUserToResizeColumns = False
        Me.DgvCategorias.AllowUserToResizeRows = False
        resources.ApplyResources(Me.DgvCategorias, "DgvCategorias")
        Me.DgvCategorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DgvCategorias.BackgroundColor = System.Drawing.Color.White
        Me.DgvCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCategorias.ColumnHeadersVisible = False
        Me.DgvCategorias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCategoria, Me.Categoria})
        Me.DgvCategorias.GridColor = System.Drawing.Color.White
        Me.DgvCategorias.MultiSelect = False
        Me.DgvCategorias.Name = "DgvCategorias"
        Me.DgvCategorias.ReadOnly = True
        Me.DgvCategorias.RowHeadersVisible = False
        Me.DgvCategorias.RowTemplate.Height = 28
        Me.DgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'IDCategoria
        '
        resources.ApplyResources(Me.IDCategoria, "IDCategoria")
        Me.IDCategoria.Name = "IDCategoria"
        Me.IDCategoria.ReadOnly = True
        '
        'Categoria
        '
        Me.Categoria.ActiveLinkColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Categoria.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.Categoria, "Categoria")
        Me.Categoria.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.Categoria.LinkColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Categoria.Name = "Categoria"
        Me.Categoria.ReadOnly = True
        Me.Categoria.VisitedLinkColor = System.Drawing.Color.Black
        '
        'DinamicMenu
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "DinamicMenu"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvCategorias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Picture As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents DgvCategorias As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents IDCategoria As DataGridViewTextBoxColumn
    Friend WithEvents Categoria As DataGridViewLinkColumn
End Class
