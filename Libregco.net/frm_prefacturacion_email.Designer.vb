<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_prefacturacion_email
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_prefacturacion_email))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkEnviarCopiaDigital = New System.Windows.Forms.CheckBox()
        Me.edtTo = New DevExpress.XtraEditors.TokenEdit()
        Me.btnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        CType(Me.edtTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Image = CType(resources.GetObject("LabelControl1.Appearance.Image"), System.Drawing.Image)
        Me.LabelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControl1.Appearance.Options.UseImage = True
        Me.LabelControl1.Appearance.Options.UseImageAlign = True
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 10)
        Me.LabelControl1.TabIndex = 26
        Me.LabelControl1.Text = "Enviar correo electrónico"
        Me.LabelControl1.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(8, 9)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(121, 24)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "Destinatarios"
        '
        'chkEnviarCopiaDigital
        '
        Me.chkEnviarCopiaDigital.AutoSize = True
        Me.chkEnviarCopiaDigital.Location = New System.Drawing.Point(11, 71)
        Me.chkEnviarCopiaDigital.Name = "chkEnviarCopiaDigital"
        Me.chkEnviarCopiaDigital.Size = New System.Drawing.Size(115, 17)
        Me.chkEnviarCopiaDigital.TabIndex = 24
        Me.chkEnviarCopiaDigital.Text = "Enviar copia digital"
        Me.chkEnviarCopiaDigital.UseVisualStyleBackColor = True
        '
        'edtTo
        '
        Me.edtTo.Location = New System.Drawing.Point(12, 45)
        Me.edtTo.Name = "edtTo"
        Me.edtTo.Properties.DropDownRowCount = 6
        Me.edtTo.Properties.EditMode = DevExpress.XtraEditors.TokenEditMode.Manual
        Me.edtTo.Properties.EditValueType = DevExpress.XtraEditors.TokenEditValueType.List
        Me.edtTo.Properties.Separators.AddRange(New String() {";"})
        Me.edtTo.Size = New System.Drawing.Size(616, 20)
        Me.edtTo.TabIndex = 22
        '
        'btnSend
        '
        Me.btnSend.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Mailx48
        Me.btnSend.Location = New System.Drawing.Point(417, 83)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(212, 61)
        Me.btnSend.TabIndex = 23
        Me.btnSend.Text = "Enviar"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(-1, 24)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(645, 23)
        Me.SeparatorControl1.TabIndex = 25
        '
        'frm_prefacturacion_email
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 166)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.chkEnviarCopiaDigital)
        Me.Controls.Add(Me.edtTo)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_prefacturacion_email"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Enviar Correo"
        CType(Me.edtTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As XtraEditors.LabelControl
    Friend WithEvents Label26 As Label
    Friend WithEvents chkEnviarCopiaDigital As CheckBox
    Friend WithEvents edtTo As XtraEditors.TokenEdit
    Friend WithEvents btnSend As XtraEditors.SimpleButton
    Friend WithEvents SeparatorControl1 As XtraEditors.SeparatorControl
End Class
