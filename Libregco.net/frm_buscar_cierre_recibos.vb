Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_cierre_recibos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_cierre_recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDRecibosCobroCierre,SecondID,Fecha,CierreRecibos.IDCobrador,Empleados.Nombre FROM cierrerecibos INNER JOIN Empleados on CierreRecibos.IDCobrador=Empleados.IDEmpleado where cierrerecibos.SecondID like '%" + txtBuscar.Text + "%' ORDER BY IDRecibosCobroCierre ASC LIMIT 100", Con)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDRecibosCobroCierre,SecondID,Fecha,CierreRecibos.IDCobrador,Empleados.Nombre FROM cierrerecibos INNER JOIN Empleados on CierreRecibos.IDCobrador=Empleados.IDEmpleado where cierrerecibos.Descripcion like '%" + txtBuscar.Text + "%' ORDER BY SecondID DESC LIMIT 100", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "cierrerecibos")

            Bs.DataMember = "cierrerecibos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvGrupos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
        DgvGrupos.Enabled = True
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvGrupos
            .Columns(0).Visible = False
            .Columns(1).Width = 100
            .Columns(1).HeaderText = "No. Cierre"
            .Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(2).Width = 80
            .Columns(3).Width = 90
            .Columns(3).HeaderText = "ID"
            .Columns(4).Width = 230
            .Columns(4).HeaderText = "Nombre"
        End With
    End Sub

    Private Sub rdbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
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

    Private Sub DgvGruposes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvGrupos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvGrupos.Focus()
    End Sub

    Private Sub DgvGruposes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvGrupos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvGrupos.Focus()
        End If
    End Sub

    Private Sub DgvGruposes_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvGrupos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvGrupos.ColumnCount
                Dim NumRows As Integer = DgvGrupos.RowCount
                Dim CurCell As DataGridViewCell = DgvGrupos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvGrupos.CurrentCell = DgvGrupos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvGrupos.CurrentCell = DgvGrupos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim IDGrupo As New Label
            Dim DsTmp As New DataSet
            IDGrupo.Text = DgvGrupos.CurrentRow.Cells(0).Value

            DsTmp.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDRecibosCobroCierre,SecondID,Fecha,IDUsuario,Usuarios.Nombre as NombreUsuario,CierreRecibos.IDTipoDocumento,TipoDocumento.Documento,CierreRecibos.IDCobrador,Empleados.Nombre as NombreCobrador,CierreRecibos.Descripcion,CierreRecibos.Nulo FROM cierrerecibos INNER JOIN Empleados on CierreRecibos.IDCobrador=Empleados.IDEmpleado INNER JOIN Empleados as Usuarios on CierreRecibos.IDUsuario=Usuarios.IDEmpleado INNER JOIN TipoDocumento on CierreRecibos.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where IDRecibosCobroCierre= '" + IDGrupo.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTmp, "CierreGrupo")
            Con.Close()

            Dim Tabla As DataTable = DsTmp.Tables("CierreGrupo")


            If Me.Owner.Name = frm_grupo_cierre_recibos.Name Then
                frm_grupo_cierre_recibos.txtIDGrupo.Text = (Tabla.Rows(0).Item("IDRecibosCobroCierre"))
                frm_grupo_cierre_recibos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_grupo_cierre_recibos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss")
                frm_grupo_cierre_recibos.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))
                frm_grupo_cierre_recibos.txtCobrador.Text = (Tabla.Rows(0).Item("NombreCobrador"))
                frm_grupo_cierre_recibos.txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_grupo_cierre_recibos.chkDesactivar.Checked = False
                Else
                    frm_grupo_cierre_recibos.chkDesactivar.Checked = True
                End If
                frm_grupo_cierre_recibos.Hora.Enabled = False

            ElseIf Me.Owner.Name = frm_consulta_numero_recibo.Name Then
                frm_consulta_numero_recibo.txtIDGrupo.Text = (Tabla.Rows(0).Item("IDRecibosCobroCierre"))
                frm_consulta_numero_recibo.txtGrupo.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_consulta_numero_recibo.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))
                frm_consulta_numero_recibo.txtCobrador.Text = (Tabla.Rows(0).Item("NombreCobrador"))
                frm_consulta_numero_recibo.txtFechaGrupo.Text = CDate(Tabla.Rows(0).Item("Fecha"))
                frm_consulta_numero_recibo.txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_consulta_numero_recibo.HabilitarDgv()
                frm_consulta_numero_recibo.RefrescarTabla()
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try

    End Sub
End Class