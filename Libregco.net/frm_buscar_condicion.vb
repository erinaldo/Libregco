Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_condicion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_condicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * from Condicion Where IDCondicion like '%" + txtBuscar.Text + "%' ORDER BY IDCondicion DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT * from Condicion Where Condicion like '%" + txtBuscar.Text + "%' ORDER BY Condicion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")

            Bs.DataMember = "Condicion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCondicion.DataSource = Bs

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
        With DgvCondicion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 120
            .Columns(1).HeaderText = "Condición"
            .Columns(1).Width = 350
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

    Private Sub rdbCategoria_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub DgvCondicion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCondicion.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCondicion.Focus()
    End Sub

    Private Sub DgvCondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCondicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvCondicion.Focus()
        End If
    End Sub

    Private Sub DgvCondicion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCondicion.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCondicion.ColumnCount
                Dim NumRows As Integer = DgvCondicion.RowCount
                Dim CurCell As DataGridViewCell = DgvCondicion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCondicion.CurrentCell = DgvCondicion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCondicion.CurrentCell = DgvCondicion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim IDCondicion As New Label
            IDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value

            Ds.Clear()
            cmd = New MySqlCommand("SELECT * FROM Condicion Where IDCondicion='" + IDCondicion.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")

            Dim Tabla As DataTable = Ds.Tables("Condicion")

            If Me.Owner.Name = frm_mant_condicion.Name Then
                frm_mant_condicion.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_mant_condicion.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value
                frm_mant_condicion.txtDias.Text = (Tabla.Rows(0).Item("Dias"))
                frm_mant_condicion.txtOrden.Text = (Tabla.Rows(0).Item("Orden"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_mant_condicion.chkNulo.Checked = False
                Else
                    frm_mant_condicion.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_mant_suplidor.Name Then
                frm_mant_suplidor.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_mant_suplidor.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_prefacturacion_detalles.Name Then
                frm_prefacturacion_detalles.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_prefacturacion_detalles.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value
                frm_prefacturacion.txtIDCondicion.Tag = DgvCondicion.CurrentRow.Cells(2).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                frm_reporte_cuentas_por_cobrar.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_cobrar.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_pagares.Name Then
                frm_reporte_pagares.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_reporte_pagares.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_suplidor.Name Then
                frm_reporte_suplidor.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_reporte_suplidor.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_reporte_registro_facturas_cxp.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_pagar.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_notas_debito_credito_cxp.Name Then
                frm_reporte_notas_debito_credito_cxp.txtIDCondicion.Text = DgvCondicion.CurrentRow.Cells(0).Value
                frm_reporte_notas_debito_credito_cxp.txtCondicion.Text = DgvCondicion.CurrentRow.Cells(1).Value


            End If


            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class