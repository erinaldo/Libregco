Module DataGridViewExtensions

    <System.Diagnostics.DebuggerStepThrough()> <Runtime.CompilerServices.Extension()> _
    Public Function GetChecked(ByVal GridView As DataGridView, ByVal ColumnName As String) As List(Of DataGridViewRow)
        Return (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() Where CBool(Rows.Cells(ColumnName).Value) = True).ToList
    End Function

    <Runtime.CompilerServices.Extension()> _
    Public Function CheckBoxCount(ByVal GridView As DataGridView, ByVal ColumnIndex As Integer, ByVal Checked As Boolean) As Integer
        Return (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() Where CBool(Rows.Cells(ColumnIndex).Value) = Checked).Count
    End Function

    <Runtime.CompilerServices.Extension()> _
    Public Function CheckBoxCount(ByVal GridView As DataGridView, ByVal ColumnName As String, ByVal Checked As Boolean) As Integer
        Return (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() Where CBool(Rows.Cells(ColumnName).Value) = Checked).Count
    End Function

    <Runtime.CompilerServices.Extension()> _
    Function CurrentRowCellValue(ByVal GridView As DataGridView, ByVal ColumnName As String) As String
        Return GridView.Rows(GridView.CurrentRow.Index).Cells(ColumnName).Value.ToString
    End Function

   
End Module
