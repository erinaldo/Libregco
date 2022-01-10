Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class DinamicMenu
    Dim ParentIDValue As Integer
    Dim TypeParentValue As Integer = 0
    Dim ToolTipExp As New ToolTip()
    Dim ImageValue As Image = My.Resources.No_Image
    Dim DescriptionValue As String = ""
    Dim DgvRowsNeeded As DataTable
    Dim IsCollapsableValue As Boolean = True


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ControlesCollapsadores()

        Picture.Image = My.Resources.No_Image
        lblName.Text = ""
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Property IsCollapsable() As Boolean
        Get
            Return IsCollapsableValue

        End Get
        Set(value As Boolean)
            IsCollapsableValue = value

        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property Description() As String
        Get
            Return DescriptionValue

        End Get
        Set(value As String)
            lblName.Text = value
            DescriptionValue = value
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property ParentID() As Integer
        Get
            Return ParentIDValue

        End Get
        Set(value As Integer)
            ParentIDValue = value
        End Set
    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property TypeParent() As Integer
        Get
            Return TypeParentValue

        End Get
        Set(value As Integer)
            TypeParentValue = value
        End Set
    End Property


    <Category("Article"), Description(""), Browsable(True)>
    Property PutImage As Image
        Get
            Return ImageValue
        End Get

        Set(value As Image)
            ImageValue = value
            Picture.Image = value
        End Set

    End Property

    <Category("Article"), Description(""), Browsable(True)>
    Property RowsIndeed As DataTable
        Get
            Return DgvRowsNeeded
        End Get

        Set(value As DataTable)
            DgvRowsNeeded = value

            For Each dt As DataRow In value.Rows
                DgvCategorias.Rows.Add(dt.Item(0), dt.Item(1))
            Next

        End Set

    End Property

    Private Sub ControlesCollapsadores()
        AddHandler Picture.MouseEnter, AddressOf NoColapsarPanel2
        AddHandler lblName.MouseEnter, AddressOf NoColapsarPanel2

        AddHandler DgvCategorias.MouseLeave, AddressOf ColapsarPanel2
        AddHandler Picture.MouseLeave, AddressOf ColapsarPanel2
        AddHandler lblName.MouseLeave, AddressOf ColapsarPanel2
        AddHandler SplitContainer1.Panel1.MouseLeave, AddressOf ColapsarPanel2
    End Sub


    Private Sub NoColapsarPanel2(sender As Object, e As EventArgs)
        If IsCollapsableValue = True Then
            If SplitContainer1.Panel2Collapsed = True Then
                SplitContainer1.Panel2Collapsed = False
            End If

        End If

    End Sub


    Private Sub ColapsarPanel2(sender As Object, e As EventArgs)
        If IsCollapsableValue = True Then
            If Not MouseIsOverControl(Me) Then
                If SplitContainer1.Panel2Collapsed = False Then
                    SplitContainer1.Panel2Collapsed = True
                End If
            End If
        End If


    End Sub

    Private Sub DepartamentosSource_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        If IsCollapsableValue = True Then
            If SplitContainer1.Panel2Collapsed = True Then
                SplitContainer1.Panel2Collapsed = False
            End If
        End If

    End Sub

    Public Function MouseIsOverControl(ByVal c As Control) As Boolean
        Return c.ClientRectangle.Contains(c.PointToClient(Control.MousePosition))
    End Function

    Private Sub DgvCategorias_MouseHover(sender As Object, e As EventArgs) Handles DgvCategorias.MouseHover
        DgvCategorias.ScrollBars = ScrollBars.Vertical
    End Sub

    Private Sub DgvCategorias_MouseLeave(sender As Object, e As EventArgs) Handles DgvCategorias.MouseLeave
        DgvCategorias.ScrollBars = ScrollBars.None
    End Sub

    Private Sub DinamicMenu_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If IsCollapsableValue = True Then
            SplitContainer1.SplitterDistance = CInt(Me.Height * 0.3)
        Else
            SplitContainer1.SplitterDistance = 0
        End If

    End Sub

End Class
