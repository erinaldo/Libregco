Public Structure DGVMultiHeader
    Public ReadOnly Text As String
    Public BackColor As Color
    Public ReadOnly FirstColumnIndex As Integer
    Public ReadOnly LastColumnIndex As Integer
    Sub New(ByVal text As String, ByVal firstColIndex As Integer, ByVal lastColIndex As Integer)
        Me.Text = text
        Me.FirstColumnIndex = firstColIndex
        Me.LastColumnIndex = lastColIndex
        Me.BackColor = Color.Empty
    End Sub
End Structure

Public Class DGVMultiHeaderManager

    Public ReadOnly Parent As DataGridView
    Public ReadOnly MultiHeaders As New List(Of DGVMultiHeader)(0)

    Sub New(ByVal dgv As DataGridView, ByVal multiheaders As IEnumerable(Of DGVMultiHeader))

        Me.Parent = dgv
        Me.MultiHeaders.AddRange(multiheaders)

        Init()

    End Sub

    Sub Init()

        Me.Parent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        Me.Parent.ColumnHeadersHeight = Me.Parent.ColumnHeadersHeight * 2

        Me.Parent.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        Me.Parent.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False

        'AddHandler Me.Parent.CellPainting, AddressOf DataGridView1_CellPainting

        AddHandler Me.Parent.Paint, AddressOf DataGridView1_Paint

        AddHandler Me.Parent.Scroll, AddressOf DataGridView1_Scroll

        AddHandler Me.Parent.ColumnWidthChanged, AddressOf DataGridView1_ColumnWidthChanged
    End Sub


    Private Sub DataGridView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)

        Dim rtHeader As Rectangle = Me.Parent.DisplayRectangle

        rtHeader.Height = CInt(Me.Parent.ColumnHeadersHeight / 2)

        Me.Parent.Invalidate(rtHeader)

    End Sub

    Private Sub DataGridView1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)

        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then

            Dim rtHeader As Rectangle = Me.Parent.DisplayRectangle

            rtHeader.Height = CInt(Me.Parent.ColumnHeadersHeight / 2)

            Me.Parent.Invalidate(rtHeader)

        End If

    End Sub

    Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim dgv = DirectCast(sender, DataGridView)

        For Each grp In MultiHeaders

            Dim lastDivWidth = dgv.Columns(grp.LastColumnIndex).DividerWidth

            Dim multiWidth = 0I
            For Index = grp.FirstColumnIndex To grp.LastColumnIndex

                multiWidth += Me.Parent.Columns(Index).Width
            Next

            Dim firstRect = Me.Parent.GetCellDisplayRectangle(grp.FirstColumnIndex, -1, True)
            '  Dim firstHeaderCell = Me.Parent.Columns(grp.FirstIndex).HeaderCell

            If firstRect.IsEmpty Then Continue For

            Dim headerRect = New Rectangle(firstRect.Left + 1,
                          firstRect.Y + 1,
                          multiWidth - 2 - lastDivWidth,
                          CInt(Me.Parent.ColumnHeadersHeight / 2) - 2)


            'Dim backcolor As Color = If(grp.BackColor.IsEmpty, dgv.ColumnHeadersDefaultCellStyle.BackColor, grp.BackColor)
            Dim backcolor As Color = Color.White

            e.Graphics.FillRectangle(New SolidBrush(backcolor), headerRect)
            Dim format As New StringFormat()

            format.Alignment = StringAlignment.Center

            format.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(grp.Text, dgv.ColumnHeadersDefaultCellStyle.Font,
                     New SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor), headerRect, format)

        Next

    End Sub

End Class
