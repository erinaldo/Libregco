Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_tipo_ajuste_inventario

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_tipo_ajuste_inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDAjusteInventario,TipodeAjuste FROM tipodeajuste where IDAjusteInventario like '%" + txtBuscar.Text + "%' ORDER BY IDAjusteInventario ASC", Con)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDAjusteInventario,TipodeAjuste FROM tipodeajuste where TipodeAjuste like '%" + txtBuscar.Text + "%' ORDER BY TipodeAjuste DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Tipodeajuste")

            Bs.DataMember = "Tipodeajuste"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipodeAjuste.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
    PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbDescripcion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTipodeAjuste
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 120
            .Columns(1).Width = 380
            .Columns(1).HeaderText = "Tipo de Ajuste"
        End With
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvTipodeAjustees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipodeAjuste.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipodeAjuste.Focus()
    End Sub

    Private Sub DgvTipodeAjustees_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipodeAjuste.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipodeAjuste.Focus()
        End If
    End Sub

    Private Sub DgvTipodeAjustees_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipodeAjuste.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipodeAjuste.ColumnCount
                Dim NumRows As Integer = DgvTipodeAjuste.RowCount
                Dim CurCell As DataGridViewCell = DgvTipodeAjuste.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipodeAjuste.CurrentCell = DgvTipodeAjuste.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipodeAjuste.CurrentCell = DgvTipodeAjuste.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim IDAjusteInventario As New Label
            IDAjusteInventario.Text = DgvTipodeAjuste.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDAjusteInventario,TipodeAjuste,TipodeAjuste.Nulo,TipodeAjuste.IDTipoFuncion,TipoFuncion.Descripcion FROM tipodeajuste INNER JOIN TipoFuncion on TipodeAjuste.IDTipoFuncion=TipoFuncion.IDTipoFuncion Where IDAjusteInventario='" + IDAjusteInventario.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Ajuste")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Ajuste")

            If Me.Owner.Name = frm_consulta_ajuste_inventario.Name Then
                frm_consulta_ajuste_inventario.txtIDUsuario.Text = DgvTipodeAjuste.CurrentRow.Cells(0).Value
                frm_consulta_ajuste_inventario.txtUsuario.Text = DgvTipodeAjuste.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_mant_ajustes_inventario.Name Then
                frm_mant_ajustes_inventario.txtIDTipoAjuste.Text = DgvTipodeAjuste.CurrentRow.Cells(0).Value
                frm_mant_ajustes_inventario.txtDescripcion.Text = DgvTipodeAjuste.CurrentRow.Cells(1).Value
                frm_mant_ajustes_inventario.CbxFuncion.Text = (Tabla.Rows(0).Item("Descripcion"))
                GetMessageDP()

            ElseIf Me.Owner.Name = frm_reporte_ajustes_inventario.Name Then
                frm_reporte_ajustes_inventario.txtIDTipoAjuste.Text = DgvTipodeAjuste.CurrentRow.Cells(0).Value
                frm_reporte_ajustes_inventario.txtTipoAjuste.Text = DgvTipodeAjuste.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub GetMessageDP()
        If Me.Owner.Name = frm_mant_ajustes_inventario.Name Then
            With frm_mant_ajustes_inventario
                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDAjusteInventario FROM movimientoinventario Where IDTipodeAjuste='" + frm_mant_ajustes_inventario.txtIDTipoAjuste.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Movimientoinventario")
                Con.Close()

                Dim Tabla As DataTable = Ds1.Tables("Movimientoinventario")

                If Tabla.Rows.Count = 0 Then
                    .lblStatusBar.Text = "No se encontraron registros que utilicen este tipo de ajuste de inventario." & vbNewLine & "Es posible cambiar su función sin futuros riesgos."
                ElseIf Tabla.Rows.Count = 1 Then
                    .lblStatusBar.Text = "Se encontró " & Tabla.Rows.Count & " registro de movimiento con este tipo de ajuste de inventario." & vbNewLine & "Recomendamos no modificar su función."
                ElseIf Tabla.Rows.Count > 1 Then
                    .lblStatusBar.Text = "Se encontraron " & Tabla.Rows.Count & " registros de movimientos con este tipo de ajuste de inventario." & vbNewLine & "Recomendamos no modificar su función."
                End If

            End With
        End If
    End Sub
End Class