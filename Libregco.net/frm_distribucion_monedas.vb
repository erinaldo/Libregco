Public Class frm_distribucion_monedas
    Dim ChkCerrar As New DataGridViewCheckBoxColumn
    Dim HeaderCheckBox As New CheckBox
    Dim ListBoxValues As Double
    Dim sqlQ As String=""

    Private Sub frm_distribucion_monedas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDgvConfiguration()
        AddHeaderCheckBox()
        SetMoneyValues()
        HeaderCheckBox.Checked = True
    End Sub

    Private Sub SetDgvConfiguration()
        With DataGridView1
            .Columns(0).DefaultCellStyle.Format = ("C")
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Add(ChkCerrar)
            .Columns(4).DisplayIndex = 0
        End With

        With ChkCerrar
            .HeaderText = ""
            .Width = 40
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .FlatStyle = FlatStyle.Standard
        End With

    End Sub

    Private Sub AddHeaderCheckBox()
        HeaderCheckBox = New CheckBox()
        HeaderCheckBox.Name = "HeaderCheckBox"
        HeaderCheckBox.Size = New Size(14, 14)
        HeaderCheckBox.ThreeState = False
        HeaderCheckBox.FlatStyle = FlatStyle.Standard
        DataGridView1.Controls.Add(HeaderCheckBox)

        AddHandler HeaderCheckBox.CheckedChanged, AddressOf HeaderCheckBox_CheckedChanged
    End Sub

    Private Sub HeaderCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim x As Integer = 0
        Dim CheckStatus As Boolean = DataGridView1.Rows(x).Cells(4).Value = True

        Dim HeaderBox As CheckBox = DirectCast(DataGridView1.Controls.Find("HeaderCheckBox", True)(0), CheckBox)
        For Each Rows As DataGridViewRow In DataGridView1.Rows
            Rows.Cells(4).Value = HeaderBox.Checked
        Next
        DataGridView1.EndEdit()
    End Sub

    Private Sub ResetHeaderCheckBoxLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        Dim Rect As Rectangle = DataGridView1.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)
        Dim Pt As New Point()
        Pt.X = Rect.Location.X + (Rect.Width - HeaderCheckBox.Width) \ 2 + 1
        Pt.Y = Rect.Location.Y + (Rect.Height - HeaderCheckBox.Height) \ 2 + 1
        HeaderCheckBox.Location = Pt
    End Sub

    Private Sub SetMoneyValues()
        With DataGridView1
            .Rows.Add(2000, "x", "0", "", 1)
            .Rows.Add(1000, "x", "0", "", 1)
            .Rows.Add(500, "x", "0", "", 1)
            .Rows.Add(200, "x", "0", "", 1)
            .Rows.Add(100, "x", "0", "", 1)
            .Rows.Add(50, "x", "0", "", 1)
            .Rows.Add(25, "x", "0", "", 1)
            .Rows.Add(10, "x", "0", "", 1)
            .Rows.Add(5, "x", "0", "", 1)
            .Rows.Add(1, "x", "0", "", 1)
            .Rows.Add(0.5, "x", "0", "", 1)
            .Rows.Add(0.25, "x", "0", "", 1)
            .Rows.Add(0.1, "x", "0", "", 1)
            .Rows.Add(0.05, "x", "0", "", 1)
            .Rows.Add(0.01, "x", "0", "", 1)
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim RealValue, RemainingValue As Decimal
            Dim EntereValue, RemainingMoney, ResidualValue As Double
            Dim IsTicked As Boolean

            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Cells(2).Value = 0
                row.Cells(3).Value = ""
            Next

            For Each Item As String In ListBox1.Items

                For Each Row As DataGridViewRow In DataGridView1.Rows
                    IsTicked = CBool(Row.Cells(4).Value)
                    Item = (Math.Round(CDbl(Item), 3)) - ResidualValue
                    ResidualValue = 0

                    If IsTicked Then
                        If CDbl(Item) >= CDbl(Row.Cells(0).Value) Then
                            RealValue = CDbl(Item) / CDbl(Row.Cells(0).Value)
                            RemainingValue = RealValue - Int(RealValue)
                            EntereValue = RealValue - RemainingValue
                            RemainingMoney = CDbl(Row.Cells(0).Value) * RemainingValue
                            ResidualValue = CDbl(Item) - RemainingMoney
                            Row.Cells(2).Value = CDbl(Row.Cells(2).Value) + CDbl(EntereValue)
                            Row.Cells(3).Value = (CDbl(Row.Cells(0).Value) * CDbl(Row.Cells(2).Value)).ToString("C")
                        End If
                    End If

                Next
            Next

            Dim CalculatedValues As Double = 0

            For Each Row As DataGridViewRow In DataGridView1.Rows
                If Row.Cells(3).Value <> "" Then
                    CalculatedValues = CalculatedValues + CDbl(Row.Cells(3).Value)
                End If
            Next
            TextBox2.Text = CalculatedValues.ToString("C")

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            ListBox1.Items.Add(CDbl(TextBox1.Text).ToString("C"))
            TextBox1.Clear()
            TextBox1.Focus()
            SumValues()
        End If
    End Sub

    Private Sub SumValues()
        Dim SumsValue As Double = 0
        For Each Item As String In ListBox1.Items
            SumsValue = SumsValue + CDbl(Item)
        Next

        Label1.Text = CDbl(SumsValue).ToString("C")
        ListBoxValues = SumsValue

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Label1.Text = ""
        ListBoxValues = 0
        Button3.Enabled = True
        TextBox2.Clear()
        TextBox1.Focus()

        For Each row As DataGridViewRow In DataGridView1.Rows
            row.Cells(2).Value = 0
            row.Cells(3).Value = ""
        Next
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 4 Then
            ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If IsNumeric(TextBox1.Text) Then
            TextBox1.Text = CDbl(TextBox1.Text).ToString("C")
        Else
            TextBox1.Clear()
        End If
    End Sub
End Class