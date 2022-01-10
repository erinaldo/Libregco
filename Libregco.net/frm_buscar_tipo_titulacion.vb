Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_titulacion
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_titulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDTipoCargadoPagare,Descripcion,Nulo FROM tipocargadopagare where IDTipoCargadoPagare like '%" + txtBuscar.Text + "%' ORDER BY IDTipoCargadoPagare DESC", Con)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDTipoCargadoPagare,Descripcion,Nulo FROM tipocargadopagare where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoCargadoPagare")

            Bs.DataMember = "TipoCargadoPagare"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoTitulacion.DataSource = Bs

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
        With DgvTipoTitulacion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 150
            .Columns(1).HeaderText = "Descripción"
            .Columns(1).Width = 400
            .Columns(2).Visible = False
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

    Private Sub DgvTipoTitulacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoTitulacion.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoTitulacion.Focus()
    End Sub

    Private Sub DgvTipoTitulacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoTitulacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoTitulacion.Focus()
        End If
    End Sub

    Private Sub DgvTipoTitulacion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoTitulacion.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoTitulacion.ColumnCount
                Dim NumRows As Integer = DgvTipoTitulacion.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoTitulacion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoTitulacion.CurrentCell = DgvTipoTitulacion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoTitulacion.CurrentCell = DgvTipoTitulacion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_reporte_titulaciones.Name Then
                frm_reporte_titulaciones.txtIDTipoCargado.Text = DgvTipoTitulacion.CurrentRow.Cells(0).Value
                frm_reporte_titulaciones.txtTipoCargado.Text = DgvTipoTitulacion.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_consulta_titulaciones_cobros.Name Then
                frm_consulta_titulaciones_cobros.txtIDTipoCargado.Text = DgvTipoTitulacion.CurrentRow.Cells(0).Value
                frm_consulta_titulaciones_cobros.txtTipoCargado.Text = DgvTipoTitulacion.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class