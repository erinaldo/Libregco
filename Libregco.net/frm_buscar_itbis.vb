Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_itbis

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_itbis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDTipoItbis,Itbis,Tipo,Signo,Desactivar FROM TipoItbis where IDTipoItbis like '%" + txtBuscar.Text + "%' ORDER BY IDTipoItbis DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDTipoItbis,Itbis,Tipo,Signo,Desactivar FROM TipoItbis where Tipo like '%" + txtBuscar.Text + "%' ORDER BY Tipo ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoItbis")

            Bs.DataMember = "TipoItbis"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvItbis.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbDescripcion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvItbis
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).Width = 80
            .Columns(1).DefaultCellStyle.Format = "P"
            .Columns(2).Width = 245
            .Columns(2).HeaderText = "Descripción"
            .Columns(3).Visible = False
            .Columns(4).Visible = False
        End With
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
        txtBuscar.Clear()
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Clear()
            RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvItbis_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvItbis.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvItbis.Focus()
    End Sub

    Private Sub DgvItbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvItbis.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvItbis.Focus()
        End If
    End Sub

    Private Sub DgvItbis_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvItbis.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvItbis.ColumnCount
                Dim NumRows As Integer = DgvItbis.RowCount
                Dim CurCell As DataGridViewCell = DgvItbis.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvItbis.CurrentCell = DgvItbis.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvItbis.CurrentCell = DgvItbis.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_mant_itbis.Name Then
                frm_mant_itbis.txtIDItbis.Text = DgvItbis.CurrentRow.Cells(0).Value
                frm_mant_itbis.txtPorcentaje.Text = CDbl(DgvItbis.CurrentRow.Cells(1).Value).ToString("P")
                frm_mant_itbis.txtTipoItbis.Text = DgvItbis.CurrentRow.Cells(2).Value
                frm_mant_itbis.txtSigno.Text = DgvItbis.CurrentRow.Cells(3).Value
                If DgvItbis.CurrentRow.Cells(4).Value = 0 Then
                    frm_mant_itbis.chkDesactivar.Checked = False
                Else
                    frm_mant_itbis.chkDesactivar.Checked = True
                End If
            ElseIf Me.Owner.Name = frm_mant_articulos.Name Then
                frm_mant_articulos.txtIDItbis.Text = DgvItbis.CurrentRow.Cells(0).Value
                frm_mant_articulos.txtItbis.Text = DgvItbis.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDTipoItbis.Text = DgvItbis.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtTipoItbis.Text = DgvItbis.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.name Then
                frm_actualizar_precios_costos.txtIDTipoItbis.Text = DgvItbis.CurrentRow.Cells(0).Value
                frm_actualizar_precios_costos.txtTipoItbis.Text = DgvItbis.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.name Then
                frm_actualizar_propiedades_articulos.txtIDTipoItbis.Text = DgvItbis.CurrentRow.Cells(0).Value
                frm_actualizar_propiedades_articulos.txtTipoItbis.Text = DgvItbis.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_ajuste_inventario.name Then
                frm_ajuste_inventario.txtIDTipoItbis.Text = DgvItbis.CurrentRow.Cells(0).Value
                frm_ajuste_inventario.txtTipoItbis.Text = DgvItbis.CurrentRow.Cells(2).Value

            End If

            Close()
            Exit Sub


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_buscar_itbis_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub
End Class