Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class TagListView
    Dim ToolTipExp As New ToolTip()

    Dim Image As Image = My.Resources.No_Image
    Dim ImageSizeMode As Integer = 4

    Dim IDArticle As String = ""
    Dim Description As String = ""
    Dim DescriptionForeColor As Color = SystemColors.MenuHighlight
    Dim DescriptionFontSize As Single = 9.75

    Dim TagPrice As String = ""
    Dim TagPriceForeColor As Color = Color.Black

    Dim TagShowLastPrice As Boolean = False
    Dim TagLastPrice As String = ""
    Dim TagLastPriceForeColor As Color = Color.Black


    Dim TagBrand As String = ""
    Dim TagModel As String = ""
    Dim TagShipping As String = ""
    Dim TagCurrencySymbol As String = "$"
    Dim TagStockMessage As String = ""

    Dim Selected As Boolean = False
    Dim Offer As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AddMouseEvents()

        Me.isSelected = Selected
        PicImage.Image = ResizeImage(My.Resources.No_Image, 172, 140)
        ListSymbol.Text = TagCurrencySymbol
        ListDescription.TabStop = False
        PanelOferta.Visible = False
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub AddMouseEvents()
        AddHandler Me.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler ListDescription.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler PicImage.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler ListMarca.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler ListPrice.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler ListLastPrice.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler ListEnvio.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler ListExistencia.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler ListModel.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler Me.Enter, AddressOf ChangeOn_MouseEnter
        AddHandler PanelOferta.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler PictureBox1.MouseEnter, AddressOf ChangeOn_MouseEnter
        AddHandler Label1.MouseEnter, AddressOf ChangeOn_MouseEnter

        AddHandler Me.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler ListDescription.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler PicImage.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler ListMarca.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler ListPrice.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler ListLastPrice.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler ListEnvio.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler ListExistencia.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler ListModel.MouseLeave, AddressOf ChangeOn_MouseLeave
        AddHandler Me.Leave, AddressOf ChangeOn_MouseLeave
        AddHandler PanelOferta.Leave, AddressOf ChangeOn_MouseLeave
        AddHandler PictureBox1.Leave, AddressOf ChangeOn_MouseLeave
        AddHandler Label1.Leave, AddressOf ChangeOn_MouseLeave

        AddHandler Me.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler ListDescription.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler PicImage.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler ListMarca.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler ListPrice.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler ListLastPrice.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler ListEnvio.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler ListExistencia.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler ListModel.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler PanelOferta.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler PictureBox1.MouseClick, AddressOf ChangeOn_mouseClick
        AddHandler Label1.MouseClick, AddressOf ChangeOn_mouseClick
    End Sub

    Private Sub ChangeOn_mouseClick(sender As Object, e As EventArgs) Handles Me.MouseClick
        Try


            For Each Tag As Control In DirectCast(Me.Parent, FlowLayoutPanel).Controls
                If (TypeOf Tag Is TagListView) Then
                    DirectCast(Tag, TagListView).isSelected = False
                End If

            Next

        Catch ex As Exception

        End Try


        If Me.isSelected = False Then
            Me.isSelected = True

        Else
            Me.isSelected = False
        End If

        If ListLastPrice.Text = "Califica para aumento" Then
            Me.Height = ListExistencia.Location.Y + ListExistencia.Height + 5
        End If

    End Sub

    Private Sub ChangeOn_MouseEnter(sender As Object, e As EventArgs)
        If Me.isSelected = False Then
            Me.BackColor = Color.WhiteSmoke
            ListDescription.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub ChangeOn_MouseLeave(sender As Object, e As EventArgs)

        If Me.isSelected = False Then
            Me.BackColor = Color.White
            ListDescription.BackColor = Color.White
        End If

    End Sub


    <Category("TagImageProperties"), Description(""), Browsable(True)>
    Property TagImage As Image
        Get
            Return Image
        End Get

        Set(value As Image)
            PicImage.Image = value
            Image = value
        End Set

    End Property

    <Category("TagImageProperties"), Description(""), Browsable(True)>
    Property TagImageSizeMode As PictureBoxSizeMode
        Get
            Return ImageSizeMode
        End Get

        Set(value As PictureBoxSizeMode)
            PicImage.SizeMode = value
            ImageSizeMode = value
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property ArticleID() As String
        Get
            Return IDArticle

        End Get
        Set(value As String)
            IDArticle = value

        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property IsOffer() As Boolean
        Get
            Return Offer

        End Get
        Set(value As Boolean)
            Offer = value

            If value = True Then
                PanelOferta.Visible = True
            Else
                PanelOferta.Visible = False
            End If
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property ArticleDescription() As String
        Get
            Return Description

        End Get
        Set(value As String)
            ListDescription.Text = value
            Description = value
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property ArticleDescriptionForeColor() As Color
        Get
            Return DescriptionForeColor

        End Get
        Set(value As Color)
            ListDescription.ForeColor = value
            DescriptionForeColor = value
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property ArticleDescriptionFontSize() As Single
        Get
            Return DescriptionFontSize

        End Get
        Set(value As Single)
            ListDescription.Font = New Font("Segoe UI Semibold", value, FontStyle.Bold)
            DescriptionFontSize = value
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property Brand() As String
        Get
            Return TagBrand
        End Get

        Set(value As String)
            ListMarca.Text = value
            TagBrand = value
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property Model() As String
        Get
            Return TagModel
        End Get

        Set(value As String)
            ListModel.Text = value
            TagModel = value
        End Set

    End Property

    <Category("PriceProperties"), Description(""), Browsable(True)>
    Property CurrencySymbol() As String
        Get
            Return TagCurrencySymbol
        End Get
        Set(value As String)
            ListSymbol.Text = value
            TagCurrencySymbol = value
        End Set
    End Property

    <Category("PriceProperties"), Description(""), Browsable(True)>
    Property Price() As String
        Get
            Return TagPrice

        End Get

        Set(value As String)
            ListPrice.Text = value
            TagPrice = value
        End Set
    End Property

    <Category("PriceProperties"), Description(""), Browsable(True)>
    Property PriceForeColor As Color
        Get
            Return TagPriceForeColor

        End Get
        Set(value As Color)
            ListPrice.ForeColor = value
            TagPriceForeColor = value
        End Set
    End Property


    <Category("PriceProperties"), Description(""), Browsable(True)>
    Property LastPrice As String
        Get
            Return TagLastPrice
        End Get
        Set(value As String)
            ListLastPrice.Text = value
            TagLastPrice = value

        End Set
    End Property

    <Category("PriceProperties"), Description(""), Browsable(True)>
    Property LastPriceForeColor As Color
        Get
            Return TagPriceForeColor
        End Get
        Set(value As Color)
            ListLastPrice.ForeColor = value
            TagPriceForeColor = value
        End Set
    End Property

    <Category("PriceProperties"), Description(""), Browsable(True)>
    Property LastPriceVisible As Boolean
        Get
            Return TagShowLastPrice

        End Get
        Set(value As Boolean)
            ListLastPrice.Visible = value
            TagShowLastPrice = value
        End Set
    End Property


    <Category("Article"), Description(""), Browsable(True)>
    Property Shipping() As String
        Get
            Return TagShipping
        End Get
        Set(value As String)
            ListEnvio.Text = value
            TagShipping = value
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property StockMessage() As String
        Get
            Return TagStockMessage
        End Get
        Set(value As String)
            ListExistencia.Text = value
            TagStockMessage = value
        End Set
    End Property

    <Category("TagCustom"), Description(""), Browsable(True)>
    Property isSelected() As Boolean
        Get
            Return Selected
        End Get

        Set(value As Boolean)
            Selected = value

            If value = True Then
                Me.BackColor = Color.LightGray
                ListDescription.BackColor = Color.LightGray
                DirectCast(Me.Parent.Parent.Parent, ListControl).SelectedTagName = Me.ArticleDescription
                DirectCast(Me.Parent.Parent.Parent, ListControl).Tag = Me.IDArticle

            Else
                Me.BackColor = Color.White
                ListDescription.BackColor = Color.White

            End If


        End Set
    End Property

    Private Sub ListLastPrice_VisibleChanged(sender As Object, e As EventArgs) Handles ListLastPrice.VisibleChanged
        ListLastPrice.Location = New Point(ListPrice.Location.X + ListPrice.Size.Width + 3, ListPrice.Location.Y)
    End Sub

    Private Sub ListPrice_Resize(sender As Object, e As EventArgs) Handles ListPrice.Resize
        ListLastPrice.Location = New Point(ListPrice.Location.X + ListPrice.Size.Width + 3, ListPrice.Location.Y)
    End Sub

    Private Sub ListSymbol_Resize(sender As Object, e As EventArgs) Handles ListSymbol.Resize
        If ListSymbol.Text = "" Then
            ListPrice.Location = New Point(198, 62)
        Else
            ListPrice.Location = New Point(ListSymbol.Location.X + ListSymbol.Size.Width + 5, ListPrice.Location.Y)
        End If

        ListLastPrice.Location = New Point(ListPrice.Location.X + ListPrice.Size.Width + 3, ListPrice.Location.Y)
    End Sub

    Private Sub ListDescription_MouseLeave(sender As Object, e As EventArgs) Handles ListDescription.MouseLeave
        ListDescription.Font = New Font("Segoe UI SemiBold", 9.75D, FontStyle.Bold)
    End Sub

    Private Sub ListDescription_MouseEnter(sender As Object, e As EventArgs) Handles ListDescription.MouseEnter
        ListDescription.Font = New Font("Segoe UI SemiBold", 9.75D, FontStyle.Underline)
    End Sub

    Private Sub ListDescription_MouseHover(sender As Object, e As EventArgs) Handles ListDescription.MouseHover
        ToolTipExp.SetToolTip(ListDescription, ListDescription.Text)
    End Sub

    Private Sub ListDescription_TextChanged(sender As Object, e As EventArgs) Handles ListDescription.TextChanged
        Try
            SetBrandStandardLocation()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TagListView_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            SetBrandStandardLocation()

            If DirectCast(Me.Parent.Parent.Parent, ListControl).TypeOfView = 0 Then
                Me.Width = DirectCast(Me.Parent.Parent.Parent, ListControl).Width - 23
            End If

        Catch ex As Exception

        End Try

    End Sub

    Sub SetBrandStandardLocation()
        Try
            Dim LinesText As Integer

            If DirectCast(Me.Parent.Parent.Parent, ListControl).TypeOfView = 0 Then
                LinesText = (ListDescription.GetLineFromCharIndex(ListDescription.Text.Length - 1)) + 1
            Else
                LinesText = 1
            End If

            ListDescription.Height = ((ListDescription.GetLineFromCharIndex(ListDescription.Text.Length - 1)) + 1 * 17)
            ListMarca.Location = New Point(ListDescription.Location.X, ListDescription.Location.Y + ListDescription.Size.Height + 2)
            ListModel.Location = New Point(ListModel.Location.X, ListDescription.Location.Y + ListDescription.Height + 3)
            ListSymbol.Location = New Point(ListSymbol.Location.X, ListMarca.Location.Y + ListMarca.Size.Height + (ListPrice.Size.Height / 2))
            ListPrice.Location = New Point(ListPrice.Location.X, ListMarca.Location.Y + ListMarca.Size.Height + 10)
            ListLastPrice.Location = New Point(ListPrice.Location.X + ListPrice.Width + 4, ListPrice.Location.Y - 4)
            ListEnvio.Location = New Point(ListEnvio.Location.X, ListPrice.Location.Y + ListPrice.Size.Height + 4)
            ListExistencia.Location = New Point(ListExistencia.Location.X, ListEnvio.Location.Y + ListEnvio.Size.Height + 2)
            PanelOferta.Location = New Point(Me.Width - PanelOferta.Width, Me.Height - PanelOferta.Height)


        Catch ex As Exception

        End Try


    End Sub

    Public Function ResizeImage(ByVal image As Bitmap, width As Integer, height As Integer) As Bitmap
        Dim destRect = New Rectangle(0, 0, width, height)
        Dim destImage = New Bitmap(width, height)

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution)

        Using graphics__1 = Graphics.FromImage(destImage)
            graphics__1.CompositingMode = CompositingMode.SourceCopy
            graphics__1.CompositingQuality = CompositingQuality.HighQuality
            graphics__1.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphics__1.SmoothingMode = SmoothingMode.HighQuality
            graphics__1.PixelOffsetMode = PixelOffsetMode.HighQuality

            Using wrapMode__2 = New ImageAttributes()
                wrapMode__2.SetWrapMode(WrapMode.TileFlipXY)
                graphics__1.DrawImage(image, destRect, 0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel, wrapMode__2)
            End Using
        End Using

        Return destImage
    End Function


    Private Sub ListDescription_Enter(sender As Object, e As EventArgs) Handles ListDescription.Enter
        Me.Select()
    End Sub

    Private Sub TagListView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then

                If Me.isSelected = True Then


                Else

                    For Each Tag As Control In DirectCast(Me.Parent, FlowLayoutPanel).Controls
                        If (TypeOf Tag Is TagListView) Then
                            DirectCast(Tag, TagListView).isSelected = False
                        End If
                    Next

                    Me.isSelected = True

                End If

            End If

        Catch ex As Exception

        End Try



    End Sub



    'Private Sub ListExistencia_LocationChanged(sender As Object, e As EventArgs) Handles ListExistencia.LocationChanged
    '    Try
    '        If DirectCast(Me.Parent.Parent.Parent, ListControl).TypeOfView = 0 Then
    '            'If ListExistencia.Location.Y + ListExistencia.Height >= Me.Height Then
    '            '    'ListLastPrice.Text = "Califica para aumento"
    '            '    Me.Height = ListExistencia.Location.Y + ListExistencia.Height + 5
    '            'Else
    '            '    '    'ListLastPrice.Text = "Normal"
    '            '    Me.Height = 140

    '            'End If
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Sub CheckViewMode()
        For Each ct As Control In DirectCast(Me.Parent, FlowLayoutPanel).Controls
            If (TypeOf ct Is ListControl) Then
                MessageBox.Show(DirectCast(ct, ListControl).Name)
            End If
        Next
    End Sub

    Private Sub TagListView_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ListMarca.Location = New Point(ListDescription.Location.X, ListDescription.Location.Y + ListDescription.Size.Height + 2)
    End Sub


End Class
