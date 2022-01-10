Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_show_montodevuelta
    Dim Billetes() As String


    Private Sub frm_show_montodevuelta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)

        If frm_formadepago.cbxMoneda.EditValue = 1 Then
            Billetes = {"2000", "1000", "500", "200", "100", "50", "25", "10", "5", "1"}
        ElseIf frm_formadepago.cbxMoneda.EditValue = 2 Then
            Billetes = {"100", "50", "20", "10", "5", "1", "0.50", "0.10", "0.01"}
        End If

        txtMontoDevolver.Text = frm_formadepago.txtDevuelta.Text
        CalcularMejorDevolucion(CDbl(txtMontoDevolver.Text))
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Me.Close()
    End Sub

    Public Function CalcularMejorDevolucion(ByVal Devuelta As Double)
        Dim RealValue, RemainingValue As Decimal
        Dim EntereValue, RemainingMoney, ResidualValue As Double
        Dim Sobrante As Double = CDbl(txtMontoDevolver.Text)
      
        For Each Billete As String In Billetes

            Sobrante = (Math.Round(CDbl(Sobrante), 3))
            ResidualValue = 0

            If Sobrante >= CDbl(Billete) Then
                RealValue = CDbl(Sobrante) / CDbl(Billete)
                RemainingValue = RealValue - Int(RealValue)
                EntereValue = RealValue - RemainingValue
                RemainingMoney = CDbl(CDbl(Billete) * EntereValue)
                ResidualValue = Sobrante - RemainingMoney
                Sobrante = ResidualValue
             
                DataGridView1.Rows.Add(EntereValue & " [" & Num2Text(EntereValue).ToLower & "] " & "de " & CDbl(Billete).ToString("C"), Billete)

            End If

        Next
        DataGridView1.ClearSelection()

    End Function

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded

        If frm_formadepago.cbxMoneda.EditValue = 1 Then

            If DataGridView1.Rows(e.RowIndex).Cells(1).Value = 2000 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 1000 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 500 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 200 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkRed

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 100 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.OrangeRed

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 50 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Purple

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 25 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 10 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 5 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black

            ElseIf DataGridView1.Rows(e.RowIndex).Cells(1).Value = 1 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

        ElseIf frm_formadepago.cbxMoneda.EditValue = 2 Then


        End If

    End Sub
End Class