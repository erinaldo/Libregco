Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_tipo_suplidor

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_tipo_suplidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM TipoSuplidor where IDTipoSuplidor like '%" + txtBuscar.Text + "%' ORDER BY IDTipoSuplidor DESC", ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM TipoSuplidor where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoSuplidor")

            Bs.DataMember = "TipoSuplidor"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoSuplidor.DataSource = Bs

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
        With DgvTipoSuplidor
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 115
            .Columns(1).Width = 350
            .Columns(2).Visible = False
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

    Private Sub DgvTipoSuplidor_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoSuplidor.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoSuplidor.Focus()
    End Sub

    Private Sub DgvTipoSuplidor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoSuplidor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoSuplidor.Focus()
        End If
    End Sub

    Private Sub DgvTipoSuplidor_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoSuplidor.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoSuplidor.ColumnCount
                Dim NumRows As Integer = DgvTipoSuplidor.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoSuplidor.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoSuplidor.CurrentCell = DgvTipoSuplidor.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoSuplidor.CurrentCell = DgvTipoSuplidor.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDTipoSuplidor As New Label
            lblIDTipoSuplidor.Text = DgvTipoSuplidor.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select * from TipoSuplidor where IDTipoSuplidor='" + lblIDTipoSuplidor.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "TipoSuplidor")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("TipoSuplidor")

            If Me.Owner.Name = frm_mant_tipo_suplidor.Name Then
                frm_mant_tipo_suplidor.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_mant_tipo_suplidor.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_mant_tipo_suplidor.chkNulo.Checked = False
                Else
                    frm_mant_tipo_suplidor.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_reporte_compras.Name Then
                frm_reporte_compras.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_compras.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_mant_suplidor.Name Then
                frm_mant_suplidor.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_mant_suplidor.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                frm_reporte_detalle_compras.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_detalle_compras.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_devolucion_compras.Name Then
                frm_reporte_devolucion_compras.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_devolucion_compras.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
                frm_reporte_orden_compra.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_orden_compra.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_suplidor.Name Then
                frm_reporte_suplidor.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_suplidor.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_registro_facturas_cxp.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_cuentas_por_pagar.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_pagos_facturas.Name Then
                frm_reporte_pagos_facturas.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_pagos_facturas.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_notas_debito_credito_cxp.Name Then
                frm_reporte_notas_debito_credito_cxp.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_reporte_notas_debito_credito_cxp.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("Descripcion"))

            End If


            Close()
            Exit Sub

        Catch ex As Exception
            ConLibregco.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


End Class