Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_recibos_egresos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_recibos_egresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDEgresos,SecondID,Fecha,Beneficiario,Referencia,Monto FROM Egresos where IDEgresos like '%" + txtBuscar.Text + "%' AND Nulo=0 ORDER By IDEgresos DESC LIMIT 50", Con)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT IDEgresos,SecondID,Fecha,Beneficiario,Referencia,Monto FROM Egresos where Referencia like '%" + txtBuscar.Text + "%' AND Nulo=0 ORDER By Referencia ASC LIMIT 50", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Egresos")

            Bs.DataMember = "Egresos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvEgresos.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvEgresos
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 80
            .Columns(2).Width = 80
            .Columns(3).Width = 220
            .Columns(4).Width = 140
            .Columns(5).Width = 120
            .Columns(5).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbReferencia.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvEgresos.Focus()
    End Sub

    Private Sub DgvEgresos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvEgresos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvEgresos.Focus()
        End If
    End Sub

    Private Sub DgvEgresos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvEgresos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvEgresos.ColumnCount
                Dim NumRows As Integer = DgvEgresos.RowCount
                Dim CurCell As DataGridViewCell = DgvEgresos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvEgresos.CurrentCell = DgvEgresos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvEgresos.CurrentCell = DgvEgresos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvEgresos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEgresos.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDEgreso, Nulo As New Label
        IDEgreso.Text = DgvEgresos.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Egresos Where IDEgresos= '" + IDEgreso.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Egresos")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Egresos")

        If Me.Owner.Name = frm_recibos_egresos.Name Then
            frm_recibos_egresos.txtIDEgreso.Text = (Tabla.Rows(0).Item("IDEgresos"))
            frm_recibos_egresos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_recibos_egresos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_recibos_egresos.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_recibos_egresos.txtBeneficiario.Text = (Tabla.Rows(0).Item("Beneficiario"))
            frm_recibos_egresos.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            frm_recibos_egresos.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_recibos_egresos.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
            frm_recibos_egresos.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
            frm_recibos_egresos.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_recibos_egresos.ChkNulo.Checked = False
            Else
                frm_recibos_egresos.ChkNulo.Checked = True
            End If
        End If

        Close()
        Exit Sub
    End Sub


End Class