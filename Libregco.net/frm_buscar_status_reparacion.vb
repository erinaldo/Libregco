Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_status_reparacion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_status_reparacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDStatusReparacion,Descripcion from StatusReparacion where IDStatusReparacion like '%" + txtBuscar.Text + "%' ORDER BY IDStatusReparacion DESC", ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDStatusReparacion,Descripcion from StatusReparacion where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Status")

            Bs.DataMember = "Status"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvStatus.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvStatus
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 115
            .Columns(1).HeaderText = "Descripción"
            .Columns(1).Width = 350
        End With
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvStatus_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvStatus.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvStatus.Focus()
    End Sub

    Private Sub DgvStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvStatus.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvStatus.Focus()
        End If
    End Sub

    Private Sub DgvStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvStatus.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvStatus.ColumnCount
                Dim NumRows As Integer = DgvStatus.RowCount
                Dim CurCell As DataGridViewCell = DgvStatus.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvStatus.CurrentCell = DgvStatus.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvStatus.CurrentCell = DgvStatus.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDStatusReparacion As New Label
            lblIDStatusReparacion.Text = DgvStatus.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select * from StatusReparacion where IDStatusReparacion='" + lblIDStatusReparacion.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "StatusReparacion")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("StatusReparacion")

            If Me.Owner.Name = frm_consulta_conduce_reparacion.Name Then
                frm_consulta_conduce_reparacion.txtIDStatusReparacion.Text = (Tabla.Rows(0).Item("IDStatusReparacion"))
                frm_consulta_conduce_reparacion.txtStatusReparacion.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_conduce_reparacion.Name Then
                frm_reporte_conduce_reparacion.txtIDStatus.Text = (Tabla.Rows(0).Item("IDStatusReparacion"))
                frm_reporte_conduce_reparacion.txtStatusReparacion.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_entradas_reparacion.Name Then
                frm_reporte_entradas_reparacion.txtIDStatus.Text = (Tabla.Rows(0).Item("IDStatusReparacion"))
                frm_reporte_entradas_reparacion.txtStatusReparacion.Text = (Tabla.Rows(0).Item("Descripcion"))
            End If

            Close()
            Exit Sub

        Catch ex As Exception
        End Try
    End Sub

End Class