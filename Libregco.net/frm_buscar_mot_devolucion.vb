Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_mot_devolucion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_mot_devolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM MotivoDevolucion where IDMotivoDevolucion like '%" + txtBuscar.Text + "%' ORDER BY IDMotivoDevolucion DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM MotivoDevolucion where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "MotivosDevolucion")

            Bs.DataMember = "MotivosDevolucion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvMotivosDevolucion.DataSource = Bs

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
        With dgvmotivosdevolucion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 115
            .Columns(1).Width = 350
            .Columns(1).HeaderText = "Descripción"
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbdescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
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

    Private Sub dgvmotivosdevolucion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMotivosDevolucion.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        dgvmotivosdevolucion.Focus()
    End Sub

    Private Sub dgvmotivosdevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvMotivosDevolucion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            dgvmotivosdevolucion.Focus()
        End If
    End Sub

    Private Sub dgvmotivosdevolucion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvMotivosDevolucion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvMotivosDevolucion.ColumnCount
                Dim NumRows As Integer = DgvMotivosDevolucion.RowCount
                Dim CurCell As DataGridViewCell = DgvMotivosDevolucion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvMotivosDevolucion.CurrentCell = DgvMotivosDevolucion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvMotivosDevolucion.CurrentCell = DgvMotivosDevolucion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDMotivoDevolucion As New Label
            lblIDMotivoDevolucion.Text = DgvMotivosDevolucion.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select * from MotivoDevolucion where IDMotivoDevolucion='" + lblIDMotivoDevolucion.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Bancos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("Bancos")

            If Me.Owner.Name = frm_devolucion_fact.Name Then
                frm_devolucion_fact.txtIDMotivoDevolucion.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_devolucion_fact.txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))
           
            ElseIf Me.Owner.Name = frm_mant_mot_devolucion.Name Then
                frm_mant_mot_devolucion.txtIDMotivoDevolucion.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_mant_mot_devolucion.txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_mant_mot_devolucion.chkNulo.Checked = False
                Else
                    frm_mant_mot_devolucion.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_consulta_devolucion_venta.Name Then
                frm_consulta_devolucion_venta.txtIDMotivoDevolucion.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_consulta_devolucion_venta.txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_devolucion_compras.Name Then
                frm_devolucion_compras.txtIDMotivoDevolucion.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_devolucion_compras.txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))
           
            ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
                frm_reporte_devolucion_ventas.txtIDMotivo.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_reporte_devolucion_ventas.txtMotivo.Text = (Tabla.Rows(0).Item("Descripcion"))
                
            ElseIf Me.Owner.Name = frm_reporte_devolucion_compras.Name Then
                frm_reporte_devolucion_compras.txtIDMotivo.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_reporte_devolucion_compras.txtMotivo.Text = (Tabla.Rows(0).Item("Descripcion"))
            End If

            Close()
            Exit Sub


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class