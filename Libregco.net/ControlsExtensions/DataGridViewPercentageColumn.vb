Public Class DataGridViewPercentageColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New DataGridViewPercentageCell)
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If Not (value Is Nothing) AndAlso
                Not value.GetType().IsAssignableFrom(GetType(DataGridViewPercentageCell)) _
                Then
                Throw New InvalidCastException("Must be a DataGridViewPercentageCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property
End Class

Public Class DataGridViewPercentageCell
    Inherits DataGridViewTextBoxCell

    Dim brushPercent As Brush

    Public Sub New()
        Me.Style.Format = "0%"
    End Sub

    Public Overrides ReadOnly Property EditType() As System.Type
        Get
            Return Nothing
        End Get
    End Property

    Protected Overrides Sub Paint(ByVal graphics As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
        Dim p As Double = 0
        If value IsNot Nothing AndAlso
           Not IsDBNull(value) AndAlso
           IsNumeric(value) Then
            p = CDbl(value)
        End If

        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.Background Or DataGridViewPaintParts.Border Or DataGridViewPaintParts.ErrorIcon Or DataGridViewPaintParts.Focus Or DataGridViewPaintParts.SelectionBackground)

        If p > 0 Then
            Dim r As Drawing.Rectangle

            r.X = cellBounds.X + 5
            r.Y = cellBounds.Y + 5
            r.Width = (cellBounds.Width - 10) * p
            r.Height = cellBounds.Height - 10

            If r.Width > 0 Then
                If Me.brushPercent IsNot Nothing Then
                    Me.brushPercent.Dispose()
                    Me.brushPercent = Nothing
                End If

                Me.brushPercent = New Drawing.Drawing2D.LinearGradientBrush(r, Drawing.Color.White, Drawing.Color.DarkGray, Drawing.Drawing2D.LinearGradientMode.Vertical)
                graphics.FillRectangle(Me.brushPercent, r)
                graphics.DrawRectangle(Drawing.Pens.DimGray, r)
            End If
        End If

        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.None Or DataGridViewPaintParts.ContentForeground)
    End Sub
End Class
