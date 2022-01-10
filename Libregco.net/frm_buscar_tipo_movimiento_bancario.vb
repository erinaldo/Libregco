Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_movimiento_bancario

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_buscar_tipo_movimiento_bancario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
   PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub PropiedadColumnsDgv()
        DgvTipoMovimientosBancarios.Columns(0).HeaderText = "Código"
        DgvTipoMovimientosBancarios.Columns(0).Width = 100

        DgvTipoMovimientosBancarios.Columns(1).Width = 290
        DgvTipoMovimientosBancarios.Columns(1).HeaderText = "No. Cuenta"

        DgvTipoMovimientosBancarios.Columns(2).Width = 80
        DgvTipoMovimientosBancarios.Columns(2).HeaderText = "Abreviatura"

    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDTipoMovBancario,TipoMovimiento,Abreviatura FROM tipomovbancario where IDTipoMovBancario like '%" + txtBuscar.Text + "%' ORDER BY IDTipoMovBancario DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDTipoMovBancario,TipoMovimiento,Abreviatura FROM tipomovbancario where TipoMovimiento like '%" + txtBuscar.Text + "%' ORDER BY TipoMovimiento ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoMovimientosBancarios")

            Bs.DataMember = "TipoMovimientosBancarios"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoMovimientosBancarios.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbDescripcion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoMovimientosBancarios.Focus()
    End Sub

    Private Sub DgvTipoMovimientosBancarios_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoMovimientosBancarios.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoMovimientosBancarios.ColumnCount
                Dim NumRows As Integer = DgvTipoMovimientosBancarios.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoMovimientosBancarios.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoMovimientosBancarios.CurrentCell = DgvTipoMovimientosBancarios.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoMovimientosBancarios.CurrentCell = DgvTipoMovimientosBancarios.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvTipoMovimientosBancarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoMovimientosBancarios.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim lblIDTipoMovimientoBanc As New Label
        lblIDTipoMovimientoBanc.Text = DgvTipoMovimientosBancarios.CurrentRow.Cells(0).Value

        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDTipoMovBancario,TipoMovimiento,Abreviatura,TipoMovBancario.IDTipoFuncion,Descripcion,IDCtaContable,NombreCuenta,PedirNCF,PedirCapInt,TipoMovBancario.Nulo FROM Libregco.tipomovbancario INNER JOIN Libregco.TipoFuncion on TipoMovBancario.IDTipoFUncion=TipoFuncion.IDTipoFuncion INNER JOIN" & SysName.Text & "ctacontable on TipoMovBancario.IDCtaContable=CtaContable.IDCtaCont where IDTipoMovBancario='" + lblIDTipoMovimientoBanc.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoMovBancario")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoMovBancario")

        If Me.Owner.Name = frm_mant_tipo_mov_bancario.Name Then
            frm_mant_tipo_mov_bancario.txtIDTipoMov.Text = (Tabla.Rows(0).Item("IDTipoMovBancario"))
            frm_mant_tipo_mov_bancario.txtDescripcion.Text = (Tabla.Rows(0).Item("TipoMovimiento"))
            frm_mant_tipo_mov_bancario.txtAbreviatura.Text = (Tabla.Rows(0).Item("Abreviatura"))
            frm_mant_tipo_mov_bancario.cbxFuncion.Text = (Tabla.Rows(0).Item("Descripcion"))
            frm_mant_tipo_mov_bancario.lblIDTipoFuncion.Text = (Tabla.Rows(0).Item("IDTipoFuncion"))
            frm_mant_tipo_mov_bancario.txtIDCtaContable.Text = (Tabla.Rows(0).Item("IDCtaContable"))
            frm_mant_tipo_mov_bancario.txtCtaContable.Text = (Tabla.Rows(0).Item("NombreCuenta"))
            frm_mant_tipo_mov_bancario.lblChkPedirNcf.Text = (Tabla.Rows(0).Item("PedirNCF"))
            frm_mant_tipo_mov_bancario.lblChkPedirCApInt.Text = (Tabla.Rows(0).Item("PedirCapInt"))
            frm_mant_tipo_mov_bancario.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
            If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_mant_tipo_mov_bancario.chkNulo.Checked = True
            Else
                frm_mant_tipo_mov_bancario.chkNulo.Checked = False
            End If

            If (Tabla.Rows(0).Item("PedirNCF")) = 1 Then
                frm_mant_tipo_mov_bancario.chkPedirNCF.Checked = True
            Else
                frm_mant_tipo_mov_bancario.chkPedirNCF.Checked = False
            End If

            If (Tabla.Rows(0).Item("PedirCapInt")) = 1 Then
                frm_mant_tipo_mov_bancario.ChkPedirCapInt.Checked = True
            Else
                frm_mant_tipo_mov_bancario.ChkPedirCapInt.Checked = False
            End If

        ElseIf Me.Owner.Name = frm_reporte_movimientos_bancarios.Name Then
            frm_reporte_movimientos_bancarios.txtIDTipoMovimiento.Text = (Tabla.Rows(0).Item("IDTipoMovBancario"))
            frm_reporte_movimientos_bancarios.txtTipoMovimiento.Text = (Tabla.Rows(0).Item("TipoMovimiento"))

        End If

        Close()
        Exit Sub

    End Sub
End Class