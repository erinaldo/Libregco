Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_talonario_cobro

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_talonario_cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDTalonarioRecibo,SecondID,Fecha,NoTalonario,Nombre,Inicial,Final FROM talonariorecibo INNER JOIN Empleados on TalonarioRecibo.IDCobrador=Empleados.IDEmpleado where IDTalonarioRecibo like '%" + txtBuscar.Text + "%' AND TalonarioRecibo.Nulo=0 ORDER BY IDTalonarioRecibo DESC", Con)
            ElseIf rdbNoTalonario.Checked = True Then
                cmd = New MySqlCommand("SELECT IDTalonarioRecibo,SecondID,Fecha,NoTalonario,Nombre,Inicial,Final FROM talonariorecibo INNER JOIN Empleados on TalonarioRecibo.IDCobrador=Empleados.IDEmpleado where NoTalonario like '%" + txtBuscar.Text + "%' AND TalonarioRecibo.Nulo=0 ORDER BY IDTalonarioRecibo DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Talonarios")

            Bs.DataMember = "Talonarios"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTalonarios.DataSource = Bs

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
        With DgvTalonarios
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).Width = 80
            .Columns(3).Width = 75
            .Columns(3).HeaderText = "No. Tal."
            .Columns(4).Width = 220
            .Columns(4).HeaderText = "Cobrador"
            .Columns(5).Width = 80
            .Columns(6).Width = 80
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbNoTalonario_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoTalonario.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTalonarios.Focus()
    End Sub

    Private Sub DgvTalonarios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTalonarios.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvTalonarios.Focus()
        End If
    End Sub

    Private Sub DgvTalonarios_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTalonarios.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTalonarios.ColumnCount
                Dim NumRows As Integer = DgvTalonarios.RowCount
                Dim CurCell As DataGridViewCell = DgvTalonarios.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTalonarios.CurrentCell = DgvTalonarios.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTalonarios.CurrentCell = DgvTalonarios.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvTalonarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTalonarios.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDTalonario, Nulo As New Label
        IDTalonario.Text = DgvTalonarios.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDTalonarioRecibo,SecondID,IDUsuario,IDCobrador,Nombre as Cobrador,Fecha,Hora,NoTalonario,Cantidad,Inicial,Final,talonariorecibo.Nulo,TalonarioRecibo.IDNaturaleza,Descripcion FROM talonariorecibo INNER JOIN Empleados on TalonarioRecibo.IDCobrador=Empleados.IDEmpleado INNER JOIN NaturalezaRecibo on TalonarioRecibo.IDNaturaleza=NaturalezaRecibo.IDNaturaleza Where IDTalonarioRecibo= '" + IDTalonario.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "TalonarioRecibo")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("TalonarioRecibo")

        If Me.Owner.Name = frm_talonarios_cobro.Name Then
            frm_talonarios_cobro.txtIDTalonario.Text = (Tabla.Rows(0).Item("IDTalonarioRecibo"))
            frm_talonarios_cobro.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_talonarios_cobro.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
            frm_talonarios_cobro.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_talonarios_cobro.txtNoTalonario.Text = (Tabla.Rows(0).Item("NoTalonario"))
            frm_talonarios_cobro.txtCantidad.Text = (Tabla.Rows(0).Item("Cantidad"))
            frm_talonarios_cobro.txtInicial.Text = (Tabla.Rows(0).Item("Inicial"))
            frm_talonarios_cobro.txtFinal.Text = (Tabla.Rows(0).Item("Final"))
            frm_talonarios_cobro.lblIDCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))
            frm_talonarios_cobro.CbxCobrador.Text = (Tabla.Rows(0).Item("Cobrador"))
            frm_talonarios_cobro.lblIDNaturaleza.Text = (Tabla.Rows(0).Item("IDNaturaleza"))
            frm_talonarios_cobro.cbxNaturaleza.Text = (Tabla.Rows(0).Item("Descripcion"))
            frm_talonarios_cobro.GbDatosTal.Enabled = False
            frm_talonarios_cobro.RefrescarTablaRecibos()

        ElseIf Me.Owner.Name = frm_reporte_recibos_cobros.Name Then
            frm_reporte_recibos_cobros.txtIDTalonario.Text = (Tabla.Rows(0).Item("IDTalonarioRecibo"))
            frm_reporte_recibos_cobros.txtTalonario.Text = (Tabla.Rows(0).Item("SecondID"))
        End If

        Close()
        Exit Sub
    End Sub
End Class