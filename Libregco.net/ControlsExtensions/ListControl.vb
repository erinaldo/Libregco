Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class ListControl
    Dim MultiSelected As Boolean = False
    Dim SelectedArticleName As String = ""
    Dim TypeOfViewList As Integer = 0
    Dim ShowSeparatatores As Boolean = False
    Dim ImageListViewSize As Size = New Size(450, 140)
    Dim WideView As Boolean = True

    Public Event CurrentTag(ByVal TagValue As String)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        MultiSelect = MultiSelected
        Me.HorizontalScroll.Visible = False
        Me.TypeOfView = 0
        Me.ShowSeparator = False
        Me.WideView = True
        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Public Sub Add(ByVal IDArticleID As String, ByVal ArticleDescription As String, ByVal Brand As String, ByVal Model As String, ByVal Price As String,
            ByVal ShowLastPrice As Boolean, ByVal LastPrice As String, ByVal Shipping As String, ByVal StockMessage As String, ByVal TagImage As Image, Optional ByVal HaveOffer As Boolean = False)

        Dim NewTag As New TagListView

        With NewTag
            .ArticleID = IDArticleID
            .ArticleDescription = ArticleDescription
            .Brand = Brand
            .Model = Model
            .Price = Price


            If CDbl(LastPrice) > CDbl(Price) Then
                .LastPriceVisible = False
            Else
                .LastPriceVisible = ShowLastPrice
                .LastPrice = LastPrice
            End If

            .Shipping = Shipping
            .StockMessage = StockMessage
            .TagImage = ResizeImage(TagImage, 172, 140)

            If Me.TypeOfView = 0 Then
                .Width = flpListBox.Width - 23
                .Height = 140
            Else
                If WideViewMode = True Then
                    .Width = (Me.Width - 50) / GetEntereValue(flpListBox.Width / ImageListViewSize.Width)
                    .Height = ImageListViewSize.Height

                Else

                    'Aqui va el nuevo modo

                    DirectCast(NewTag, TagListView).Size = New Size(257, 314)
                    DirectCast(NewTag, TagListView).PicImage.Size = New Size(257, 169)
                    DirectCast(NewTag, TagListView).PicImage.Location = New Point(0, 0)
                    DirectCast(NewTag, TagListView).PicImage.Dock = DockStyle.Top
                    DirectCast(NewTag, TagListView).PicImage.SizeMode = PictureBoxSizeMode.StretchImage

                    DirectCast(NewTag, TagListView).ListDescription.Location = New Point(5, 172)
                    DirectCast(NewTag, TagListView).ListDescription.Size = New Size(251, 34)
                    DirectCast(NewTag, TagListView).ListMarca.Location = New Point(5, 210)
                    DirectCast(NewTag, TagListView).ListMarca.Size = New Size(56, 15)

                    DirectCast(NewTag, TagListView).ListModel.Location = New Point(104, 214)
                    DirectCast(NewTag, TagListView).ListModel.Size = New Size(150, 15)

                    DirectCast(NewTag, TagListView).PanelOferta.Location = New Point(172, 289)

                    DirectCast(NewTag, TagListView).ListSymbol.Location = New Point(7, 239)
                    DirectCast(NewTag, TagListView).ListSymbol.Size = New Size(0, 17)

                    DirectCast(NewTag, TagListView).ListPrice.Location = New Point(23, 231)
                    DirectCast(NewTag, TagListView).ListPrice.Size = New Size(0, 30)

                    DirectCast(NewTag, TagListView).ListLastPrice.Location = New Point(122, 231)
                    DirectCast(NewTag, TagListView).ListLastPrice.Size = New Size(0, 25)

                    DirectCast(NewTag, TagListView).ListEnvio.Location = New Point(7, 270)
                    DirectCast(NewTag, TagListView).ListEnvio.Size = New Size(0, 15)

                    DirectCast(NewTag, TagListView).ListExistencia.Location = New Point(7, 289)
                    DirectCast(NewTag, TagListView).ListExistencia.Size = New Size(0, 13)

                End If

            End If

            If HaveOffer = True Then
                .IsOffer = True
            Else
                .IsOffer = False
            End If


        End With

        AddHandler NewTag.DoubleClick, AddressOf GetID
        AddHandler NewTag.PicImage.DoubleClick, AddressOf GetID
        AddHandler NewTag.PictureBox1.DoubleClick, AddressOf GetID
        AddHandler NewTag.Label1.DoubleClick, AddressOf GetID
        AddHandler NewTag.ListDescription.DoubleClick, AddressOf GetID
        AddHandler NewTag.ListEnvio.DoubleClick, AddressOf GetID
        AddHandler NewTag.ListExistencia.DoubleClick, AddressOf GetID
        AddHandler NewTag.ListPrice.DoubleClick, AddressOf GetID
        AddHandler NewTag.ListModel.DoubleClick, AddressOf GetID
        AddHandler NewTag.ListSymbol.DoubleClick, AddressOf GetID
        AddHandler NewTag.ListMarca.DoubleClick, AddressOf GetID
        AddHandler NewTag.LISTLastPrice.DoubleClick, AddressOf GetID

        flpListBox.Controls.Add(NewTag)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.ShowSeparator = True Then
            Dim Line As New Label
            If TypeOfView = 0 Then

                Line.AutoSize = False
                Line.BorderStyle = BorderStyle.FixedSingle
                Line.Height = 1
                Line.Width = Me.Width - 23
                Line.Enabled = False
                Line.BackColor = Color.Black
                flpListBox.Controls.Add(Line)
            Else
                Line.AutoSize = False
                Line.BorderStyle = BorderStyle.FixedSingle
                Line.Height = 0
                Line.Width = 0
                Line.Enabled = False
                Line.BackColor = Color.Black
                flpListBox.Controls.Add(Line)
            End If
        End If


    End Sub

    Private Sub GetID(Sender As Object, e As EventArgs)
        If (TypeOf DirectCast(Sender, Control) Is TagListView) Then
            Me.Tag = DirectCast(Sender, TagListView).ArticleID
        Else
            Me.Tag = DirectCast(DirectCast(Sender, Control).Parent, TagListView).ArticleID
        End If

        RaiseEvent CurrentTag(Me.Tag)
    End Sub
    Property SelectedTagName As String
        Get
            Return SelectedArticleName
        End Get

        Set(value As String)

            lblSelectedValue.Text = value

        End Set

    End Property


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Up
                SendKeys.Send("+{TAB}")
            Case Keys.Down
                SendKeys.Send("{TAB}")

        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub ListControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            For Each ct As Control In flpListBox.Controls

                If Me.TypeOfView = 0 Then
                    If (TypeOf ct Is TagListView) Then
                        ct.Width = Me.Width - 23

                        DirectCast(ct, TagListView).PicImage.Anchor = AnchorStyles.Top And AnchorStyles.Bottom And AnchorStyles.Left
                        DirectCast(ct, TagListView).PicImage.Size = New Size(172, 140)
                        DirectCast(ct, TagListView).PicImage.Location = New Point(0, 0)
                        DirectCast(ct, TagListView).PicImage.Dock = DockStyle.Left
                        DirectCast(ct, TagListView).PicImage.SizeMode = PictureBoxSizeMode.Zoom

                        DirectCast(ct, TagListView).ListDescription.Location = New Point(177, 3)
                        DirectCast(ct, TagListView).ListDescription.Size = New Size(533, 34)
                        DirectCast(ct, TagListView).ListMarca.Location = New Point(177, 41)
                        DirectCast(ct, TagListView).ListMarca.Size = New Size(0, 15)

                        DirectCast(ct, TagListView).ListModel.Location = New Point(flpListBox.Size.Width - 23 - DirectCast(ct, TagListView).ListModel.Width, 47)
                        DirectCast(ct, TagListView).ListModel.Size = New Size(150, 15)

                        DirectCast(ct, TagListView).PanelOferta.Location = New Point(flpListBox.Size.Width - 23 - DirectCast(ct, TagListView).PanelOferta.Width, 113)

                        DirectCast(ct, TagListView).ListSymbol.Location = New Point(177, 70)
                        DirectCast(ct, TagListView).ListSymbol.Size = New Size(0, 17)

                        DirectCast(ct, TagListView).ListPrice.Location = New Point(193, 62)
                        DirectCast(ct, TagListView).ListPrice.Size = New Size(0, 30)

                        DirectCast(ct, TagListView).ListLastPrice.Location = New Point(358, 55)
                        DirectCast(ct, TagListView).ListLastPrice.Size = New Size(0, 25)

                        DirectCast(ct, TagListView).ListEnvio.Location = New Point(177, 94)
                        DirectCast(ct, TagListView).ListEnvio.Size = New Size(0, 15)

                        DirectCast(ct, TagListView).ListExistencia.Location = New Point(177, 113)
                        DirectCast(ct, TagListView).ListExistencia.Size = New Size(0, 13)
                        DirectCast(ct, TagListView).SetBrandStandardLocation()

                    ElseIf (TypeOf ct Is Label) Then
                        ct.Width = flpListBox.Width - 23
                        ct.Height = 1
                    End If

                Else
                    If WideViewMode = True Then
                        If (TypeOf ct Is TagListView) Then
                            ct.Width = (Me.Width - 50) / GetEntereValue(flpListBox.Width / ImageListViewSize.Width)
                            ct.Height = ImageListViewSize.Height

                            DirectCast(ct, TagListView).PicImage.Anchor = AnchorStyles.Top And AnchorStyles.Bottom And AnchorStyles.Left
                            DirectCast(ct, TagListView).PicImage.Size = New Size(172, 140)
                            DirectCast(ct, TagListView).PicImage.Location = New Point(0, 0)
                            DirectCast(ct, TagListView).PicImage.Dock = DockStyle.Left
                            DirectCast(ct, TagListView).PicImage.SizeMode = PictureBoxSizeMode.Zoom

                            DirectCast(ct, TagListView).ListDescription.Location = New Point(177, 3)
                            DirectCast(ct, TagListView).ListDescription.Size = New Size(533, 34)
                            DirectCast(ct, TagListView).ListMarca.Location = New Point(177, 41)
                            DirectCast(ct, TagListView).ListMarca.Size = New Size(0, 15)

                            DirectCast(ct, TagListView).ListModel.Location = New Point(flpListBox.Size.Width - 23 - DirectCast(ct, TagListView).ListModel.Width, 47)
                            DirectCast(ct, TagListView).ListModel.Size = New Size(150, 15)

                            DirectCast(ct, TagListView).PanelOferta.Location = New Point(flpListBox.Size.Width - 23 - DirectCast(ct, TagListView).PanelOferta.Width, 113)

                            DirectCast(ct, TagListView).ListSymbol.Location = New Point(177, 70)
                            DirectCast(ct, TagListView).ListSymbol.Size = New Size(0, 17)

                            DirectCast(ct, TagListView).ListPrice.Location = New Point(193, 62)
                            DirectCast(ct, TagListView).ListPrice.Size = New Size(0, 30)

                            DirectCast(ct, TagListView).ListLastPrice.Location = New Point(358, 55)
                            DirectCast(ct, TagListView).ListLastPrice.Size = New Size(0, 25)

                            DirectCast(ct, TagListView).ListEnvio.Location = New Point(177, 94)
                            DirectCast(ct, TagListView).ListEnvio.Size = New Size(0, 15)

                            DirectCast(ct, TagListView).ListExistencia.Location = New Point(177, 113)
                            DirectCast(ct, TagListView).ListExistencia.Size = New Size(0, 13)
                            DirectCast(ct, TagListView).SetBrandStandardLocation()

                        ElseIf (TypeOf ct Is Label) Then
                            ct.Width = 0
                            ct.Height = 0
                        End If

                    Else


                        'Aqui va el resize en el nuevo modo

                        If (TypeOf ct Is TagListView) Then

                            DirectCast(ct, TagListView).Size = New Size(257, 314)
                            DirectCast(ct, TagListView).PicImage.Size = New Size(257, 169)
                            DirectCast(ct, TagListView).PicImage.Location = New Point(0, 0)
                            DirectCast(ct, TagListView).PicImage.Dock = DockStyle.Top
                            DirectCast(ct, TagListView).PicImage.SizeMode = PictureBoxSizeMode.StretchImage

                            DirectCast(ct, TagListView).ListDescription.Location = New Point(5, 172)
                            DirectCast(ct, TagListView).ListDescription.Size = New Size(251, 34)
                            DirectCast(ct, TagListView).ListMarca.Location = New Point(5, 210)
                            DirectCast(ct, TagListView).ListMarca.Size = New Size(56, 15)

                            DirectCast(ct, TagListView).ListModel.Location = New Point(104, 214)
                            DirectCast(ct, TagListView).ListModel.Size = New Size(150, 15)

                            DirectCast(ct, TagListView).PanelOferta.Location = New Point(172, 289)

                            DirectCast(ct, TagListView).ListSymbol.Location = New Point(7, 239)
                            DirectCast(ct, TagListView).ListSymbol.Size = New Size(0, 17)

                            DirectCast(ct, TagListView).ListPrice.Location = New Point(23, 231)
                            DirectCast(ct, TagListView).ListPrice.Size = New Size(0, 30)

                            DirectCast(ct, TagListView).ListLastPrice.Location = New Point(122, 231)
                            DirectCast(ct, TagListView).ListLastPrice.Size = New Size(0, 25)

                            DirectCast(ct, TagListView).ListEnvio.Location = New Point(7, 270)
                            DirectCast(ct, TagListView).ListEnvio.Size = New Size(0, 15)

                            DirectCast(ct, TagListView).ListExistencia.Location = New Point(7, 289)
                            DirectCast(ct, TagListView).ListExistencia.Size = New Size(0, 13)
                            DirectCast(ct, TagListView).SetBrandStandardLocation()
                        End If

                    End If


                End If

            Next
        Catch ex As Exception

        End Try

    End Sub

    Property TypeOfView As Integer
        Get
            Return TypeOfViewList
        End Get

        Set(value As Integer)
            TypeOfViewList = value

            If value = 0 Then
                ListViewIco.Image = My.Resources.listvieworange
                ImageViewIco.Image = My.Resources.imageviewgray

                flpListBox.MaximumSize = New Size(0, 0)
                flpListBox.FlowDirection = FlowDirection.TopDown
                flpListBox.WrapContents = False

                flpListBox.AutoScroll = True

                For Each ct As Control In flpListBox.Controls
                    If (TypeOf ct Is TagListView) Then
                        ct.Width = flpListBox.Width - 23
                        ct.Height = 140

                        DirectCast(ct, TagListView).PicImage.Anchor = AnchorStyles.Top And AnchorStyles.Bottom And AnchorStyles.Left
                        DirectCast(ct, TagListView).PicImage.Size = New Size(172, 140)
                        DirectCast(ct, TagListView).PicImage.Location = New Point(0, 0)
                        DirectCast(ct, TagListView).PicImage.Dock = DockStyle.Left
                        DirectCast(ct, TagListView).PicImage.SizeMode = PictureBoxSizeMode.Zoom


                        ''''''''''''''''''''''
                        'DirectCast(ct, TagListView).ListDescription.Location = New Point(177, 3)
                        'DirectCast(ct, TagListView).ListDescription.Size = New Size(533, 34)

                        'DirectCast(ct, TagListView).ListMarca.Location = New Point(DirectCast(ct, TagListView).ListDescription.Location.X, DirectCast(ct, TagListView).ListDescription.Location.Y + DirectCast(ct, TagListView).ListDescription.Size.Height + 2)
                        'DirectCast(ct, TagListView).ListMarca.Size = New Size(0, 15)

                        'DirectCast(ct, TagListView).ListModel.Size = New Size(150, 15)
                        'DirectCast(ct, TagListView).ListModel.Location = New Point(DirectCast(ct, TagListView).Size.Width - DirectCast(ct, TagListView).ListModel.Size.Width, DirectCast(ct, TagListView).ListDescription.Location.Y + DirectCast(ct, TagListView).ListDescription.Height + 3)


                        'DirectCast(ct, TagListView).PanelOferta.Location = New Point(flpListBox.Size.Width - 23 - DirectCast(ct, TagListView).PanelOferta.Width, 113)

                        'DirectCast(ct, TagListView).ListSymbol.Location = New Point(177, 70)
                        'DirectCast(ct, TagListView).ListSymbol.Size = New Size(0, 17)

                        'DirectCast(ct, TagListView).ListLastPrice.Location = New Point(DirectCast(ct, TagListView).ListLastPrice.Location.X, DirectCast(ct, TagListView).ListMarca.Location.Y + DirectCast(ct, TagListView).ListMarca.Size.Height + 8)

                        'DirectCast(ct, TagListView).ListPrice.Size = New Size(0, 30)

                        'DirectCast(ct, TagListView).ListLastPrice.Location = New Point(358, 55)
                        'DirectCast(ct, TagListView).ListLastPrice.Size = New Size(0, 25)

                        'DirectCast(ct, TagListView).ListEnvio.Location = New Point(177, 94)
                        'DirectCast(ct, TagListView).ListEnvio.Size = New Size(0, 15)

                        'DirectCast(ct, TagListView).ListExistencia.Location = New Point(177, 113)
                        'DirectCast(ct, TagListView).ListExistencia.Size = New Size(0, 13)
                        '''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf (TypeOf ct Is Label) Then
                        ct.Width = flpListBox.Width - 23
                        ct.Height = 1
                    End If

                Next

            ElseIf value = 1 Then
                flpListBox.WrapContents = True
                flpListBox.AutoScroll = True
                ListViewIco.Image = My.Resources.listviewgray
                ImageViewIco.Image = My.Resources.imagevieworange

                flpListBox.MaximumSize = New Size(0, 0)
                flpListBox.FlowDirection = FlowDirection.LeftToRight

                If WideViewMode = True Then

                    For Each ct As Control In flpListBox.Controls
                        If (TypeOf ct Is TagListView) Then
                            If (GetEntereValue(flpListBox.Width / ImageListViewSize.Width)) > 0 Then
                                ct.Width = (Me.Width - 50) / GetEntereValue(flpListBox.Width / ImageListViewSize.Width)
                                ct.Height = ImageListViewSize.Height
                            End If

                            DirectCast(ct, TagListView).PicImage.Anchor = AnchorStyles.Top And AnchorStyles.Bottom And AnchorStyles.Left
                            DirectCast(ct, TagListView).PicImage.Size = New Size(172, 140)
                            DirectCast(ct, TagListView).PicImage.Location = New Point(0, 0)
                            DirectCast(ct, TagListView).PicImage.Dock = DockStyle.None
                            DirectCast(ct, TagListView).PicImage.SizeMode = PictureBoxSizeMode.Zoom


                            DirectCast(ct, TagListView).ListDescription.Location = New Point(DirectCast(ct, TagListView).PicImage.Width + 4, 3)
                            DirectCast(ct, TagListView).ListDescription.Size = New Size(DirectCast(ct, TagListView).Size.Width - DirectCast(ct, TagListView).PicImage.Width, 2 * 17)

                            Dim LinesText As Integer


                            LinesText = (DirectCast(ct, TagListView).ListDescription.GetLineFromCharIndex(DirectCast(ct, TagListView).ListDescription.Text.Length - 1)) + 1
                            If LinesText = 1 Then
                                DirectCast(ct, TagListView).ListMarca.Location = New Point(DirectCast(ct, TagListView).PicImage.Width + 4, 2 + (1 * 17))
                                DirectCast(ct, TagListView).ListModel.Location = New Point(DirectCast(ct, TagListView).Size.Width - DirectCast(ct, TagListView).ListModel.Size.Width, 4 + (1 * 17))

                            Else
                                DirectCast(ct, TagListView).ListMarca.Location = New Point(DirectCast(ct, TagListView).PicImage.Width + 4, 2 + (2 * 17))
                                DirectCast(ct, TagListView).ListModel.Location = New Point(DirectCast(ct, TagListView).Size.Width - DirectCast(ct, TagListView).ListModel.Size.Width, 4 + (2 * 17))
                            End If


                            DirectCast(ct, TagListView).ListSymbol.Location = New Point(DirectCast(ct, TagListView).PicImage.Width + 4, DirectCast(ct, TagListView).ListMarca.Location.Y + 32)


                            'DirectCast(ct, TagListView).ListPrice.Location = New Point(193, 62)
                            'DirectCast(ct, TagListView).ListPrice.Size = New Size(0, 30)

                            'DirectCast(ct, TagListView).ListLastPrice.Location = New Point(DirectCast(ct, TagListView).ListPrice.Location.X + DirectCast(ct, TagListView).ListPrice.Width + 4, DirectCast(ct, TagListView).ListPrice.Location.Y - 4)
                            'DirectCast(ct, TagListView).ListLastPrice.Size = New Size(0, 25)

                            'DirectCast(ct, TagListView).ListEnvio.Location = New Point(177, 94)
                            'DirectCast(ct, TagListView).ListEnvio.Size = New Size(0, 15)

                            'DirectCast(ct, TagListView).ListExistencia.Location = New Point(177, 113)
                            'DirectCast(ct, TagListView).ListExistencia.Size = New Size(0, 13)

                            'DirectCast(ct, TagListView).PanelOferta.Location = New Point(DirectCast(ct, TagListView).Size.Width - DirectCast(ct, TagListView).PanelOferta.Width, DirectCast(ct, TagListView).Size.Height - DirectCast(ct, TagListView).PanelOferta.Height)


                        ElseIf (TypeOf ct Is Label) Then
                            ct.Width = 0
                            ct.Height = 0
                        End If
                    Next


                Else

                    For Each ct As Control In flpListBox.Controls
                        If (TypeOf ct Is TagListView) Then

                            DirectCast(ct, TagListView).Size = New Size(257, 314)
                            DirectCast(ct, TagListView).PicImage.Size = New Size(257, 169)
                            DirectCast(ct, TagListView).PicImage.Location = New Point(0, 0)
                            DirectCast(ct, TagListView).PicImage.Dock = DockStyle.Top
                            DirectCast(ct, TagListView).PicImage.SizeMode = PictureBoxSizeMode.StretchImage

                            DirectCast(ct, TagListView).ListDescription.Location = New Point(5, 172)
                            DirectCast(ct, TagListView).ListDescription.Size = New Size(251, 34)
                            DirectCast(ct, TagListView).ListMarca.Location = New Point(5, 210)
                            DirectCast(ct, TagListView).ListMarca.Size = New Size(56, 15)


                            DirectCast(ct, TagListView).ListModel.Size = New Size(150, 15)
                            DirectCast(ct, TagListView).ListModel.Location = New Point(DirectCast(ct, TagListView).Size.Width - DirectCast(ct, TagListView).ListModel.Size.Width, DirectCast(ct, TagListView).ListDescription.Location.Y + DirectCast(ct, TagListView).ListDescription.Height + 3)


                            DirectCast(ct, TagListView).PanelOferta.Location = New Point(Me.Width - DirectCast(ct, TagListView).PanelOferta.Width, Me.Height - DirectCast(ct, TagListView).PanelOferta.Height)

                            DirectCast(ct, TagListView).ListSymbol.Location = New Point(7, 239)
                            DirectCast(ct, TagListView).ListSymbol.Size = New Size(0, 17)

                            DirectCast(ct, TagListView).ListPrice.Location = New Point(23, 231)
                            DirectCast(ct, TagListView).ListPrice.Size = New Size(0, 30)

                            DirectCast(ct, TagListView).ListLastPrice.Location = New Point(122, 231)
                            DirectCast(ct, TagListView).ListLastPrice.Size = New Size(0, 25)

                            DirectCast(ct, TagListView).ListEnvio.Location = New Point(7, 270)
                            DirectCast(ct, TagListView).ListEnvio.Size = New Size(0, 15)

                            DirectCast(ct, TagListView).ListExistencia.Location = New Point(7, 289)
                            DirectCast(ct, TagListView).ListExistencia.Size = New Size(0, 13)


                        End If
                    Next
                End If
            End If

        End Set
    End Property

    <Category("ListControlCustom"), Description(""), Browsable(True)>
    Property ImageListDefaultSize() As Size
        Get
            Return ImageListViewSize
        End Get
        Set(value As Size)
            ImageListViewSize = value

            If Me.TypeOfView = 1 Then
                If WideViewMode = True Then
                    For Each ctr As Control In flpListBox.Controls
                        If (TypeOf ctr Is TagListView) Then
                            ctr.Size = value
                        End If
                    Next
                End If
            End If
        End Set
    End Property

    <Category("ListControlCustom"), Description(""), Browsable(True)>
    Property WideViewMode() As Boolean
        Get
            Return WideView
        End Get
        Set(value As Boolean)
            WideView = value
            If TypeOfView = 1 Then

                If value = True Then

                    flpListBox.WrapContents = True
                    flpListBox.AutoScroll = True
                    ListViewIco.Image = My.Resources.listviewgray
                    ImageViewIco.Image = My.Resources.imagevieworange

                    flpListBox.MaximumSize = New Size(0, 0)
                    flpListBox.FlowDirection = FlowDirection.LeftToRight

                    For Each ct As Control In flpListBox.Controls
                        If (TypeOf ct Is TagListView) Then
                            If (GetEntereValue(flpListBox.Width / ImageListViewSize.Width)) > 0 Then
                                ct.Width = (Me.Width - 50) / GetEntereValue(flpListBox.Width / ImageListViewSize.Width)
                                ct.Height = ImageListViewSize.Height
                            End If

                            DirectCast(ct, TagListView).PicImage.Anchor = AnchorStyles.Top And AnchorStyles.Bottom And AnchorStyles.Left
                            DirectCast(ct, TagListView).PicImage.Size = New Size(172, 140)
                            DirectCast(ct, TagListView).PicImage.Location = New Point(0, 0)
                            DirectCast(ct, TagListView).PicImage.Dock = DockStyle.None
                            DirectCast(ct, TagListView).PicImage.SizeMode = PictureBoxSizeMode.Zoom

                            DirectCast(ct, TagListView).SetBrandStandardLocation()

                            'DirectCast(ct, TagListView).ListDescription.Location = New Point(177, 3)
                            'DirectCast(ct, TagListView).ListDescription.Size = New Size(533, 34)
                            'DirectCast(ct, TagListView).ListMarca.Location = New Point(177, 41)
                            'DirectCast(ct, TagListView).ListMarca.Size = New Size(0, 15)

                            'DirectCast(ct, TagListView).ListModel.Location = New Point(563, 47)
                            'DirectCast(ct, TagListView).ListModel.Size = New Size(150, 15)

                            'DirectCast(ct, TagListView).PanelOferta.Location = New Point(630, 113)

                            'DirectCast(ct, TagListView).ListSymbol.Location = New Point(177, 70)
                            'DirectCast(ct, TagListView).ListSymbol.Size = New Size(0, 17)

                            'DirectCast(ct, TagListView).ListPrice.Location = New Point(193, 62)
                            'DirectCast(ct, TagListView).ListPrice.Size = New Size(0, 30)

                            'DirectCast(ct, TagListView).ListLastPrice.Location = New Point(358, 55)
                            'DirectCast(ct, TagListView).ListLastPrice.Size = New Size(0, 25)

                            'DirectCast(ct, TagListView).ListEnvio.Location = New Point(177, 94)
                            'DirectCast(ct, TagListView).ListEnvio.Size = New Size(0, 15)

                            'DirectCast(ct, TagListView).ListExistencia.Location = New Point(177, 113)
                            'DirectCast(ct, TagListView).ListExistencia.Size = New Size(0, 13)

                        ElseIf (TypeOf ct Is Label) Then
                            ct.Width = 0
                            ct.Height = 0
                        End If
                    Next

                Else

                    For Each ct As Control In flpListBox.Controls
                        If (TypeOf ct Is TagListView) Then

                            DirectCast(ct, TagListView).Size = New Size(257, 314)
                            DirectCast(ct, TagListView).PicImage.Size = New Size(257, 169)
                            DirectCast(ct, TagListView).PicImage.Location = New Point(0, 0)
                            DirectCast(ct, TagListView).PicImage.Dock = DockStyle.Top
                            DirectCast(ct, TagListView).PicImage.SizeMode = PictureBoxSizeMode.StretchImage

                            DirectCast(ct, TagListView).ListDescription.Location = New Point(5, 172)
                            DirectCast(ct, TagListView).ListDescription.Size = New Size(251, 34)
                            DirectCast(ct, TagListView).ListMarca.Location = New Point(5, 210)
                            DirectCast(ct, TagListView).ListMarca.Size = New Size(56, 15)

                            DirectCast(ct, TagListView).ListModel.Location = New Point(104, 214)
                            DirectCast(ct, TagListView).ListModel.Size = New Size(150, 15)

                            DirectCast(ct, TagListView).PanelOferta.Location = New Point(172, 289)

                            DirectCast(ct, TagListView).ListSymbol.Location = New Point(7, 239)
                            DirectCast(ct, TagListView).ListSymbol.Size = New Size(0, 17)

                            DirectCast(ct, TagListView).ListPrice.Location = New Point(23, 231)
                            DirectCast(ct, TagListView).ListPrice.Size = New Size(0, 30)

                            DirectCast(ct, TagListView).ListLastPrice.Location = New Point(122, 231)
                            DirectCast(ct, TagListView).ListLastPrice.Size = New Size(0, 25)

                            DirectCast(ct, TagListView).ListEnvio.Location = New Point(7, 270)
                            DirectCast(ct, TagListView).ListEnvio.Size = New Size(0, 15)

                            DirectCast(ct, TagListView).ListExistencia.Location = New Point(7, 289)
                            DirectCast(ct, TagListView).ListExistencia.Size = New Size(0, 13)


                        End If
                    Next

                End If


            End If
        End Set
    End Property

    <Category("ListControlCustom"), Description(""), Browsable(True)>
    Property HeaderName() As String
        Get
            Return ListHeader.Text
        End Get
        Set(value As String)
            ListHeader.Text = value
        End Set
    End Property


    <Category("ListControlCustom"), Description(""), Browsable(True)>
    Property ShowSeparator() As Boolean
        Get
            Return ShowSeparatatores
        End Get
        Set(value As Boolean)
            ShowSeparatatores = value
        End Set
    End Property

    <Category("ListControlCustom"), Description(""), Browsable(True)>
    Property MultiSelect() As Boolean
        Get
            Return MultiSelected
        End Get
        Set(value As Boolean)
            MultiSelected = value
        End Set
    End Property

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


    Private Function GetEntereValue(ByVal Num As Double) As Decimal
        Dim RealValue, RemainingValue As Decimal
        Dim EntereValue As Double


        RealValue = Num
        RemainingValue = RealValue - Int(RealValue)
        EntereValue = RealValue - RemainingValue

        Return EntereValue
    End Function

    Private Function GetDecimalValue(ByVal num As Double) As Decimal
        Dim RealValue, RemainingValue As Decimal
        Dim EntereValue As Double


        RealValue = num
        RemainingValue = RealValue - Int(RealValue)
        EntereValue = RealValue - RemainingValue

        Return RemainingValue
    End Function

    Public Sub Remove(name As String)
        Dim c As Control = flpListBox.Controls(name)
        flpListBox.Controls.Remove(c)
        c.Dispose()
    End Sub

    Public Sub Clear()
        Do
            If flpListBox.Controls.Count = 0 Then Exit Do
            Dim c As Control = flpListBox.Controls(0)
            flpListBox.Controls.Remove(c)
            c.Dispose()
        Loop
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return flpListBox.Controls.Count
        End Get
    End Property

    Private Sub flpListBox_ControlAdded(sender As Object, e As ControlEventArgs) Handles flpListBox.ControlAdded
        Dim CountofTag As Integer = 0
        For Each ct As Control In flpListBox.Controls
            If (TypeOf ct Is TagListView) Then
                CountofTag = CountofTag + 1
            End If
        Next
        lblItemsCount.Text = "Items: " & CountofTag
    End Sub


    Public Shared Function TruncateString(ByVal value As String, ByVal maxChars As Integer) As String
        Return If(value.Length <= maxChars, value, value.Substring(0, maxChars) & "...")
    End Function

    Private Sub ListViewIco_Click(sender As Object, e As EventArgs) Handles ListViewIco.Click
        Me.TypeOfView = 0
    End Sub

    Private Sub ImageViewIco_Click(sender As Object, e As EventArgs) Handles ImageViewIco.Click
        Me.TypeOfView = 1
    End Sub


    'Me.Size = New Size(257, 314)
    '            PicImage.Anchor = AnchorStyles.Top And AnchorStyles.Left
    '            PicImage.Size = New Size(257, 169)
    '            PicImage.Location = New Point(0, 0)
    '            PicImage.Dock = DockStyle.Top
    '            DirectCast(c, TagListView).PicImage.SizeMode = PictureBoxSizeMode.StretchImage

    '            ListDescription.Location = New Point(5, 172)
    '            ListDescription.Size = New Size(251, 34)
    '            ListMarca.Location = New Point(5, 210)
    '            ListMarca.Size = New Size(56, 15)

    '            ListModel.Location = New Point(104, 214)
    '            ListModel.Size = New Size(150, 15)

    '            PanelOferta.Location = New Point(172, 289)

    '            ListSymbol.Location = New Point(7, 239)
    '            ListSymbol.Size = New Size(0, 17)

    '            ListPrice.Location = New Point(23, 231)
    '            ListPrice.Size = New Size(0, 30)

    '            ListLastPrice.Location = New Point(122, 231)
    '            ListLastPrice.Size = New Size(0, 25)

    '            ListEnvio.Location = New Point(7, 270)
    '            ListEnvio.Size = New Size(0, 15)

    '            ListExistencia.Location = New Point(7, 289)
    '            ListExistencia.Size = New Size(0, 13)

    '        Else

    'Me.Size = New Size(716, 140)
    '            PicImage.Anchor = AnchorStyles.Top And AnchorStyles.Bottom And AnchorStyles.Left
    '            PicImage.Size = New Size(172, 140)
    '            PicImage.Location = New Point(0, 0)
    '            PicImage.Dock = DockStyle.None
    '            DirectCast(c, TagListView).PicImage.SizeMode = PictureBoxSizeMode.zoom

    '            ListDescription.Location = New Point(177, 3)
    '            ListDescription.Size = New Size(533, 34)
    '            ListMarca.Location = New Point(177, 41)
    '            ListMarca.Size = New Size(0, 15)

    '            ListModel.Location = New Point(563, 47)
    '            ListModel.Size = New Size(150, 15)

    '            PanelOferta.Location = New Point(630, 113)

    '            ListSymbol.Location = New Point(177, 70)
    '            ListSymbol.Size = New Size(0, 17)

    '            ListPrice.Location = New Point(193, 62)
    '            ListPrice.Size = New Size(0, 30)

    '            ListLastPrice.Location = New Point(358, 55)
    '            ListLastPrice.Size = New Size(0, 25)

    '            ListEnvio.Location = New Point(177, 94)
    '            ListEnvio.Size = New Size(0, 15)

    '            ListExistencia.Location = New Point(177, 113)
    '            ListExistencia.Size = New Size(0, 13)
    '        End If
End Class
