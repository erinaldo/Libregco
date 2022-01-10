Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_tipo_garantia

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_tipo_garantia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarEmpresa()
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
                cmd = New MySqlCommand("SELECT IDGarantiaArticulos,TiempoGarantia,Dias,Nulo FROM garantiaarticulos where IDGarantiaArticulos like '%" + txtBuscar.Text + "%' ORDER BY IDGarantiaArticulos DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDGarantiaArticulos,TiempoGarantia,Dias,Nulo FROM garantiaarticulos where TiempoGarantia like '%" + txtBuscar.Text + "%' ORDER BY TiempoGarantia ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Garantias")

            Bs.DataMember = "Garantias"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvGarantias.DataSource = Bs

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
        With DgvGarantias
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 120
            .Columns(1).HeaderText = "Descripción"
            .Columns(1).Width = 398
            .Columns(2).Visible = False
            .Columns(3).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub DgvGarantias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvGarantias.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvGarantias.Focus()
    End Sub

    Private Sub DgvGarantias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvGarantias.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvGarantias.Focus()
        End If
    End Sub

    Private Sub DgvGarantias_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvGarantias.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvGarantias.ColumnCount
                Dim NumRows As Integer = DgvGarantias.RowCount
                Dim CurCell As DataGridViewCell = DgvGarantias.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvGarantias.CurrentCell = DgvGarantias.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvGarantias.CurrentCell = DgvGarantias.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_garantias.Name Then
                frm_mant_garantias.txtIDGarantia.Text = DgvGarantias.CurrentRow.Cells(0).Value
                frm_mant_garantias.txtGarantia.Text = DgvGarantias.CurrentRow.Cells(1).Value
                frm_mant_garantias.txtDias.Text = DgvGarantias.CurrentRow.Cells(2).Value

                If DgvGarantias.CurrentRow.Cells(3).Value = 1 Then
                    frm_mant_garantias.chkDesactivar.Checked = True
                Else
                    frm_mant_garantias.chkDesactivar.Checked = False
                End If

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDGarantia.Text = DgvGarantias.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtGarantia.Text = DgvGarantias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_mant_articulos.Name Then
                frm_mant_articulos.txtIDGarantia.Text = DgvGarantias.CurrentRow.Cells(0).Value
                frm_mant_articulos.txtTipoGarantia.Text = DgvGarantias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDGarantia.Text = DgvGarantias.CurrentRow.Cells(0).Value
                frm_reporte_series_garantias.txtGarantia.Text = DgvGarantias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_introducir_seriales.Name Then
                frm_introducir_seriales.txtIDGarantia.Text = DgvGarantias.CurrentRow.Cells(0).Value
                frm_introducir_seriales.txtGarantia.Text = DgvGarantias.CurrentRow.Cells(1).Value
                Dim Dias As Integer = DgvGarantias.CurrentRow.Cells(2).Value

                If frm_introducir_seriales.txtFecha.Text <> "" Then
                    frm_introducir_seriales.txtVencimiento.Text = CDate(DateAdd(DateInterval.Day, Dias, CDate(frm_introducir_seriales.txtFecha.Text))).ToString("yyyy-MM-dd")
                End If

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.name Then
                frm_actualizar_precios_costos.txtIDGarantia.Text = DgvGarantias.CurrentRow.Cells(0).Value
                frm_actualizar_precios_costos.txtGarantia.Text = DgvGarantias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.name Then
                frm_actualizar_propiedades_articulos.txtIDGarantia.Text = DgvGarantias.CurrentRow.Cells(0).Value
                frm_actualizar_propiedades_articulos.txtGarantia.Text = DgvGarantias.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_ajuste_inventario.name Then
                frm_ajuste_inventario.txtIDGarantia.Text = DgvGarantias.CurrentRow.Cells(0).Value
                frm_ajuste_inventario.txtGarantia.Text = DgvGarantias.CurrentRow.Cells(1).Value


            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_buscar_tipo_garantia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub
End Class