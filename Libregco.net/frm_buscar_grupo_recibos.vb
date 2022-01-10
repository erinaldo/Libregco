Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_grupo_recibos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_grupo_recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
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
                cmd = New MySqlCommand("SELECT IDGrupoRecibos,SecondID,Fecha,Descripcion,Cantidad,NoInicial,NoFinal FROM gruporecibos INNER JOIN NaturalezaRecibo on GrupoRecibos.IDNaturaleza=NaturalezaRecibo.IDNaturaleza where IDGrupoRecibos like '%" + txtBuscar.Text + "%' AND GrupoRecibos.Nulo=0 ORDER BY IDGrupoRecibos DESC", Con)
            ElseIf rdbFabricante.Checked = True Then
                cmd = New MySqlCommand("SELECT IDGrupoRecibos,SecondID,Fecha,Descripcion,Cantidad,NoInicial,NoFinal FROM gruporecibos INNER JOIN NaturalezaRecibo on GrupoRecibos.IDNaturaleza=NaturalezaRecibo.IDNaturaleza where Fabricante like '%" + txtBuscar.Text + "%' AND GrupoRecibos.Nulo=0 ORDER BY IDGrupoRecibos DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "GrupoRecibo")

            Bs.DataMember = "GrupoRecibo"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvRecibos.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvRecibos
            .Columns(0).Visible = False
            .Columns(1).Width = 100
            .Columns(1).HeaderText = "No. Grupo"
            .Columns(2).Width = 80
            .Columns(3).Width = 175
            .Columns(3).HeaderText = "Descripción"
            .Columns(4).Width = 80
            .Columns(4).HeaderText = "Cant."
            .Columns(5).Width = 100
            .Columns(5).HeaderText = "No. Inicial"
            .Columns(6).Width = 100
            .Columns(6).HeaderText = "No. Final"
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbFabricante_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFabricante.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvRecibos.Focus()
    End Sub

    Private Sub DgvRecibos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvRecibos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvRecibos.Focus()
        End If
    End Sub

    Private Sub DgvRecibos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvRecibos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvRecibos.ColumnCount
                Dim NumRows As Integer = DgvRecibos.RowCount
                Dim CurCell As DataGridViewCell = DgvRecibos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvRecibos.CurrentCell = DgvRecibos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvRecibos.CurrentCell = DgvRecibos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvRecibos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecibos.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDGrupo, Nulo As New Label
        IDGrupo.Text = DgvRecibos.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDGrupoRecibos,GrupoRecibos.SecondID,Fecha,GrupoRecibos.IDNaturaleza,Descripcion,Cantidad,NoInicial,NoFinal,Fabricante,FechaEmision,Observaciones,GrupoRecibos.Nulo FROM gruporecibos INNER JOIN NaturalezaRecibo on GrupoRecibos.IDNaturaleza=NaturalezaRecibo.IDNaturaleza Where IDGrupoRecibos= '" + IDGrupo.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Recibos")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Recibos")

        If Me.Owner.Name = frm_generacion_nuevos_recibos.Name Then
            frm_generacion_nuevos_recibos.txtIDGRecibo.Text = (Tabla.Rows(0).Item("IDGrupoRecibos"))
            frm_generacion_nuevos_recibos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_generacion_nuevos_recibos.lblIDNaturaleza.Text = (Tabla.Rows(0).Item("IDNaturaleza"))
            frm_generacion_nuevos_recibos.cbxNaturaleza.Text = (Tabla.Rows(0).Item("Descripcion"))
            frm_generacion_nuevos_recibos.txtCantidad.Text = (Tabla.Rows(0).Item("Cantidad"))
            frm_generacion_nuevos_recibos.txtInicial.Text = (Tabla.Rows(0).Item("NoInicial"))
            frm_generacion_nuevos_recibos.txtFinal.Text = (Tabla.Rows(0).Item("NoFinal"))
            frm_generacion_nuevos_recibos.txtFabricante.Text = (Tabla.Rows(0).Item("Fabricante"))
            frm_generacion_nuevos_recibos.dtpFechaEmision.Value = (Tabla.Rows(0).Item("FechaEmision"))
            frm_generacion_nuevos_recibos.txtObservaciones.Text = (Tabla.Rows(0).Item("Observaciones"))
            frm_generacion_nuevos_recibos.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
            frm_generacion_nuevos_recibos.GbDatosTal.Enabled = False
            frm_generacion_nuevos_recibos.RefrescarTablaRecibos()

        ElseIf Me.Owner.Name = frm_reporte_recibos_cobros.Name Then
            frm_reporte_recibos_cobros.txtIDGrupo.Text = (Tabla.Rows(0).Item("IDGrupoRecibos"))
            frm_reporte_recibos_cobros.txtGrupoRecibo.Text = (Tabla.Rows(0).Item("SecondID"))
        End If

        Close()
        Exit Sub
    End Sub


End Class