Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class CardBoard
    Dim Image As Image = My.Resources.No_Image
    Dim IDArticle As String = ""
    Dim Description As String = ""
    Dim TagPrice As String = ""
    Dim TagBrand As String = ""
    Dim TagModel As String = ""
    Dim Offer As Boolean = False
    Dim CardColorValue As Color = Color.White
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        PanelOferta.Visible = False
    End Sub

    <Category("Article"), Description(""), Browsable(True)>
    Property TagImage As Image
        Get
            Return Image
        End Get

        Set(value As Image)
            PicImage.Image = value
            Image = value
        End Set

    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property CardBackColor As Color
        Get
            Return CardColorValue

        End Get
        Set(value As Color)
            Me.BackColor = value
            PictureBox1.BackColor = value
            PicImage.BackColor = value
            ListDescription.BackColor = value
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
    Property Brand() As String
        Get
            Return TagBrand
        End Get

        Set(value As String)
            ListMarca.Text = "by " & value
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
    Property Price() As String
        Get
            Return TagPrice

        End Get

        Set(value As String)
            ListPrice.Text = value
            TagPrice = value
        End Set
    End Property

    Private Sub CardBoard_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ListDescription.Size = New Size(ListDescription.Size.Width, 17 * If(CInt((ListDescription.GetLineFromCharIndex(ListDescription.Text.Length - 1)) + 1) = 1, 1, 2))
        ListMarca.Location = New Point(ListDescription.Location.X, ListDescription.Location.Y + ListDescription.Size.Height + 2)
        ListPrice.Location = New Point(ListDescription.Location.X, ListMarca.Location.Y + ListMarca.Size.Height)

    End Sub

    Private Sub CardBoard_BackColorChanged(sender As Object, e As EventArgs) Handles MyBase.BackColorChanged
        ListDescription.BackColor = Me.CardBackColor
        PicImage.BackColor = Me.CardBackColor
    End Sub

    Private Sub CardBoard_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Me.Width > 200 Then
            ListDescription.Location = New Point(68, 2)
            PicImage.Visible = True
        Else
            ListDescription.Location = New Point(4, 2)
            PicImage.Visible = False
        End If
    End Sub
End Class
