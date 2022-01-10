Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D


Public Class NewTextbox
    Dim ImageDefault As Image
    Dim ImageonFocus As Image

    Dim BackColorDefault As Color
    Dim BackColorFocus As Color

    Dim ShowColoronMouseEnter As Boolean = False
    Dim BackColoronMouseEnter As Color

    Dim WaterMarkText As String = "Write a watermark"
    Dim WaterMarkForeColorText As Color = Color.Gray

    Dim WritedValueText As String
    Dim WritedForeColor As Color = Color.Black
    Dim IsPasswordValue As Boolean = False

    Dim TextMessageValue As String = ""
    Dim TextMessageColorValue As Color = Color.Red

    Private ignoreKeys As New List(Of Keys) From {Keys.Left, Keys.Up, Keys.PageUp, Keys.Home, Keys.Space}
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Height = 52
        Me.SetWaterMarkText = WaterMarkText
        Me.TextMessage = ""
    End Sub



    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    Public Overrides Property Text() As String
        Get
            Return WritedValueText
        End Get
        Set(ByVal value As String)
            WritedValueText = value
            Watermark1.Text = WritedValueText
        End Set
    End Property

    <Category("Appariences"), Description(""), Browsable(True)>
    Property TextMessage As String
        Get
            Return TextMessageValue
        End Get

        Set(value As String)
            TextMessageValue = value
            lblMessage.Text = value

            If value = "" Then
                lblMessage.ForeColor = TextMessageColorValue
                PanelMessage.BackColor = TextMessageColorValue
                lblMessage.Visible = False
                PanelMessage.Visible = False
            Else
                lblMessage.Visible = True
                PanelMessage.Visible = True
            End If
        End Set
    End Property

    <Category("Appariences"), Description(""), Browsable(True)>
    Property TextMessageColor As Color
        Get
            Return TextMessageColorValue
        End Get

        Set(value As Color)
            TextMessageColorValue = value
            lblMessage.ForeColor = value
            PanelMessage.BackColor = value
        End Set
    End Property

    <Category("Image Properties"), Description(""), Browsable(True)>
    Property SetDefaultImage As Image
        Get
            Return ImageDefault
        End Get

        Set(value As Image)
            PicImage.Image = value
            ImageDefault = value
        End Set
    End Property

    <Category("Image Properties"), Description(""), Browsable(True)>
    Property SetImageOnFocus As Image
        Get
            Return ImageonFocus
        End Get

        Set(value As Image)
            ImageonFocus = value
        End Set
    End Property

    <Category("Appariences"), Description(""), Browsable(True)>
    Property SetDefaultBackColor As Color
        Get
            Return BackColorDefault
        End Get

        Set(value As Color)
            BackColorDefault = value
            ShapedPanel1.BackColor = value
        End Set
    End Property

    <Category("Appariences"), Description(""), Browsable(True)>
    Property SetBackColorOnFocus As Color
        Get
            Return BackColorFocus
        End Get

        Set(value As Color)
            BackColorFocus = value
        End Set
    End Property

    <Category("Appariences"), Description(""), Browsable(True)>
    Property SetBackColorOnMouseEnter As Color
        Get
            Return BackColoronMouseEnter
        End Get

        Set(value As Color)
            BackColoronMouseEnter = value
        End Set
    End Property

    <Category("Appariences"), Description(""), Browsable(True)>
    Property ChangeColorOnMouseEnter As Boolean
        Get
            Return ShowColoronMouseEnter
        End Get

        Set(value As Boolean)
            ShowColoronMouseEnter = value
        End Set
    End Property

    <Category("PasswordSettings"), Description(""), Browsable(True)>
    Property IsPassword As Boolean
        Get
            Return IsPasswordValue
        End Get

        Set(value As Boolean)
            IsPasswordValue = value

            If value = True Then
                Watermark1.PasswordChar = "*"
                btnClear.Image = My.Resources.Eye_24
            Else
                Watermark1.PasswordChar = ""
                btnClear.Image = My.Resources.icons8_cancel_24
            End If
        End Set

    End Property

    <Category("Watermark Properties"), Description(""), Browsable(True)>
    Property SetForeColorText As Color
        Get
            Return WritedForeColor
        End Get

        Set(value As Color)
            WritedForeColor = value
            Watermark1.ForeColor = WritedForeColor
        End Set
    End Property


    <Category("Watermark Properties"), Description(""), Browsable(True)>
    Property SetWaterMarkText As String
        Get
            Return WaterMarkText
        End Get

        Set(value As String)
            WaterMarkText = value
            Watermark1.WatermarkText = WaterMarkText
        End Set
    End Property

    <Category("Watermark Properties"), Description(""), Browsable(True)>
    Property SetWaterMarkColor As Color
        Get
            Return WaterMarkForeColorText
        End Get

        Set(value As Color)
            WaterMarkForeColorText = value
            Watermark1.WatermarkColor = WaterMarkForeColorText
        End Set
    End Property

    Private Sub Watermark1_Enter(sender As Object, e As EventArgs) Handles Watermark1.Enter
        ShapedPanel1.BackColor = BackColorFocus
        PicImage.Image = ImageonFocus

        If Watermark1.Text <> "" Then
            btnClear.Visible = True
        End If
    End Sub

    Private Sub Watermark1_Leave(sender As Object, e As EventArgs) Handles Watermark1.Leave
        ShapedPanel1.BackColor = BackColorDefault
        PicImage.Image = ImageDefault
    End Sub

    'Controles del Hover Color
    Private Sub PicImage_MouseEnter(sender As Object, e As EventArgs) Handles PicImage.MouseEnter
        If ShowColoronMouseEnter = True Then
            If Watermark1.Focused = False Then
                ShapedPanel1.BackColor = BackColoronMouseEnter
            End If
        End If
    End Sub

    Private Sub PicImage_MouseLeave(sender As Object, e As EventArgs) Handles PicImage.MouseLeave
        If Watermark1.Focused = False Then
            ShapedPanel1.BackColor = BackColorDefault
        End If

    End Sub

    Private Sub Watermark1_MouseEnter(sender As Object, e As EventArgs) Handles Watermark1.MouseEnter
        If ShowColoronMouseEnter = True Then
            If Watermark1.Focused = False Then
                ShapedPanel1.BackColor = BackColoronMouseEnter
            End If
        End If
    End Sub

    Private Sub Watermark1_MouseLeave(sender As Object, e As EventArgs) Handles Watermark1.MouseLeave
        If Watermark1.Focused = False Then
            ShapedPanel1.BackColor = BackColorDefault
        End If

    End Sub

    Private Sub ShapedPanel2_MouseEnter(sender As Object, e As EventArgs) Handles ShapedPanel2.MouseEnter
        If ShowColoronMouseEnter = True Then
            If Watermark1.Focused = False Then
                ShapedPanel1.BackColor = BackColoronMouseEnter
            End If
        End If
    End Sub

    Private Sub ShapedPanel2_MouseLeave(sender As Object, e As EventArgs) Handles ShapedPanel2.MouseLeave
        If Watermark1.Focused = False Then
            ShapedPanel1.BackColor = BackColorDefault
        End If

    End Sub

    Private Sub NewTextbox_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        ShapedPanel1.BackColor = BackColorDefault
        PicImage.Image = ImageDefault
        btnClear.Visible = False
    End Sub

    Private Sub ShapedPanel1_MouseLeave(sender As Object, e As EventArgs) Handles ShapedPanel1.MouseLeave
        If Watermark1.Focused = False Then
            ShapedPanel1.BackColor = BackColorDefault
        End If

    End Sub

    Private Sub ShapedPanel1_MouseEnter(sender As Object, e As EventArgs) Handles ShapedPanel1.MouseEnter
        If ShowColoronMouseEnter = True Then
            If Watermark1.Focused = False Then
                ShapedPanel1.BackColor = BackColoronMouseEnter
            End If
        End If
    End Sub

    Private Sub Watermark1_TextChanged(sender As Object, e As EventArgs) Handles Watermark1.TextChanged
        Me.WritedValueText = Watermark1.Text
        Me.Text = Watermark1.Text

        If Watermark1.Text.Length = 0 Then
            If Watermark1.Focused = True Then
                btnClear.Visible = False
            End If

        Else
            If Watermark1.Focused = True Then
                btnClear.Visible = True
            End If

        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If Me.IsPassword = True Then
            If Watermark1.PasswordChar = "*" Then
                Watermark1.PasswordChar = ""
                btnClear.Image = My.Resources.Eyeno_24
            Else
                Watermark1.PasswordChar = "*"
                btnClear.Image = My.Resources.Eye_24
            End If
        Else
            Watermark1.Text = ""
            Me.TextMessage = ""
            Watermark1.Focus()
        End If

    End Sub

    Private Sub btnClear_MouseEnter(sender As Object, e As EventArgs) Handles btnClear.MouseEnter
        If Me.IsPassword = False Then
            If ShowColoronMouseEnter = True Then
                If Watermark1.Focused = False Then
                    ShapedPanel1.BackColor = BackColoronMouseEnter
                End If
            End If

            btnClear.Image = My.Resources.icons8_cancel_24__1_
        End If

    End Sub

    Private Sub btnClear_MouseLeave(sender As Object, e As EventArgs) Handles btnClear.MouseLeave
        If Me.IsPassword = False Then
            If Watermark1.Focused = False Then
                ShapedPanel1.BackColor = BackColorDefault
            End If

            btnClear.Image = My.Resources.icons8_cancel_24
        End If

    End Sub

    Private Sub NewTextbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If lblMessage.Text = "" Then
            lblMessage.Visible = False
            PanelMessage.Visible = False
        End If
    End Sub

    Private Sub Watermark1_KeyDown(sender As Object, e As KeyEventArgs) Handles Watermark1.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Watermark1.Text = ""

        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class
