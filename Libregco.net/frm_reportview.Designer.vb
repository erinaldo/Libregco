<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_reportView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reportView))
        Me.CrystalViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Contador = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'CrystalViewer
        '
        Me.CrystalViewer.ActiveViewIndex = -1
        Me.CrystalViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalViewer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CrystalViewer.Location = New System.Drawing.Point(0, 0)
        Me.CrystalViewer.Name = "CrystalViewer"
        Me.CrystalViewer.ReuseParameterValuesOnRefresh = True
        Me.CrystalViewer.ShowCloseButton = False
        Me.CrystalViewer.ShowLogo = False
        Me.CrystalViewer.ShowParameterPanelButton = False
        Me.CrystalViewer.ShowRefreshButton = False
        Me.CrystalViewer.Size = New System.Drawing.Size(984, 662)
        Me.CrystalViewer.TabIndex = 0
        Me.CrystalViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalViewer.ToolPanelWidth = 220
        '
        'Contador
        '
        Me.Contador.Interval = 1000
        '
        'frm_reportView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.CrystalViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frm_reportView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Visualización de reportes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Public WithEvents Contador As Timer
End Class
