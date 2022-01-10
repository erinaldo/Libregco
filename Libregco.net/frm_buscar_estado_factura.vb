Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_estado_factura

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_estado_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDEstadoFactura,EstadoFactura FROM estadofactura Where IDEstadoFactura like '%" + txtBuscar.Text + "%' ORDER BY IDEstadoFactura DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDEstadoFactura,EstadoFactura FROM estadofactura Where EstadoFactura like '%" + txtBuscar.Text + "%' ORDER BY EstadoFactura ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "EstadoFactura")

            Bs.DataMember = "EstadoFactura"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvEstado.DataSource = Bs

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
        With DgvEstado
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 140
            .Columns(1).HeaderText = "Estado"
            .Columns(1).Width = 380
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

    Private Sub DgvEstado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEstado.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvEstado.Focus()
    End Sub

    Private Sub DgvEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvEstado.Focus()
        End If
    End Sub

    Private Sub DgvEstado_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvEstado.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvEstado.ColumnCount
                Dim NumRows As Integer = DgvEstado.RowCount
                Dim CurCell As DataGridViewCell = DgvEstado.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvEstado.CurrentCell = DgvEstado.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvEstado.CurrentCell = DgvEstado.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim DsTemp As New DataSet

            Dim IDEstado As New Label
            IDEstado.Text = DgvEstado.CurrentRow.Cells(0).Value

            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM EstadoFactura Where IDEstadoFactura='" + IDEstado.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "EstadoFactura")

            Dim Tabla As DataTable = DsTemp.Tables("EstadoFactura")

            If Me.Owner.Name = frm_mant_estados_facturas.Name Then
                frm_mant_estados_facturas.txtIDEstado.Text = (Tabla.Rows(0).Item("IDEstadoFactura"))
                frm_mant_estados_facturas.txtEstado.Text = (Tabla.Rows(0).Item("EstadoFactura"))
                frm_mant_estados_facturas.txtDescripcion.Text = (Tabla.Rows(0).Item("DescripcionEstado"))
                frm_mant_estados_facturas.lblColor.BackColor = Color.FromArgb(Tabla.Rows(0).Item("Color"))

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_mant_estados_facturas.chkNulo.Checked = True
                Else
                    frm_mant_estados_facturas.chkNulo.Checked = False
                End If

            ElseIf Me.Owner.Name = frm_cambiar_estado_factura.Name Then
                frm_cambiar_estado_factura.txtIDEstado.Text = (Tabla.Rows(0).Item("IDEstadoFactura"))
                frm_cambiar_estado_factura.txtEstado.Text = (Tabla.Rows(0).Item("EstadoFactura"))
                frm_cambiar_estado_factura.lblColor.BackColor = Color.FromArgb(Tabla.Rows(0).Item("Color"))
            End If



            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class