Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_tipo_identificacion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_identificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM TipoIdentificacion where IDTipoIdentificacion like '%" + txtBuscar.Text + "%' ORDER BY IDTipoIdentificacion ASC", ConLibregco)
            ElseIf rdbTipoIdentificacion.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM TipoIdentificacion where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoIdentificacion")

            Bs.DataMember = "TipoIdentificacion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoIdentificacion.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
  PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()
        rdbTipoIdentificacion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTipoIdentificacion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).Width = 220
            .Columns(1).HeaderText = "Tipo de Identificación"
            .Columns(2).Width = 180
            .Columns(2).HeaderText = "Máscara"
            .Columns(3).Visible = False
        End With
    End Sub

    Private Sub rdbTipoIdentificacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTipoIdentificacion.CheckedChanged
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

    Private Sub DgvTipoIdentificacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoIdentificacion.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoIdentificacion.Focus()
    End Sub

    Private Sub DgvTipoIdentificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoIdentificacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoIdentificacion.Focus()
        End If
    End Sub

    Private Sub DgvTipoIdentificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoIdentificacion.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoIdentificacion.ColumnCount
                Dim NumRows As Integer = DgvTipoIdentificacion.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoIdentificacion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoIdentificacion.CurrentCell = DgvTipoIdentificacion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoIdentificacion.CurrentCell = DgvTipoIdentificacion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()

        If Me.Owner.Name = frm_mant_tipo_identificacion.Name Then
            frm_mant_tipo_identificacion.txtIDTipoIdentificacion.Text = DgvTipoIdentificacion.CurrentRow.Cells(0).Value
            frm_mant_tipo_identificacion.txtTipoIdentificacion.Text = DgvTipoIdentificacion.CurrentRow.Cells(1).Value
            frm_mant_tipo_identificacion.txtMascara.Text = DgvTipoIdentificacion.CurrentRow.Cells(2).Value

            If DgvTipoIdentificacion.CurrentRow.Cells(4).Value = 0 Then
                frm_mant_tipo_identificacion.chkNulo.Checked = False
            Else
                frm_mant_tipo_identificacion.chkNulo.Checked = True
            End If

        ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
            frm_reporte_clientes.txtIDTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(0).Value
            frm_reporte_clientes.txtTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(1).Value

        ElseIf Me.Owner.Name = frm_reporte_suplidor.Name Then
            frm_reporte_suplidor.txtIDTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(0).Value
            frm_reporte_suplidor.txtTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(1).Value

        ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
            frm_reporte_registro_facturas_cxp.txtIDTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(0).Value
            frm_reporte_registro_facturas_cxp.txtTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(1).Value

        ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
            frm_reporte_cuentas_por_pagar.txtIDTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(0).Value
            frm_reporte_cuentas_por_pagar.txtTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(1).Value

        ElseIf Me.Owner.Name = frm_reporte_pagos_facturas.Name Then
            frm_reporte_pagos_facturas.txtIDTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(0).Value
            frm_reporte_pagos_facturas.txtTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(1).Value

        ElseIf Me.Owner.Name = frm_reporte_notas_debito_credito_cxp.Name Then
            frm_reporte_notas_debito_credito_cxp.txtIDTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(0).Value
            frm_reporte_notas_debito_credito_cxp.txtTipoDocumento.Text = DgvTipoIdentificacion.CurrentRow.Cells(1).Value


        End If

        Close()
        Exit Sub

    End Sub
End Class