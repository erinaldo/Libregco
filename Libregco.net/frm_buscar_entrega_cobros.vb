Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_entrega_cobros

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_entrega_cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDEntregaCobro,SecondID,Descripcion,FechaEntrega,Nombre,Cantidad,NoInicial,NoFinal FROM entregacobro INNER JOIN Empleados on EntregaCobro.IDCobrador=Empleados.IDEmpleado Where IDEntregaCobro like '%" + txtBuscar.Text + "%' and EntregaCobro.Nulo=0 ORDER BY IDEntregaCobro DESC", Con)
            ElseIf rdbNoEntrega.Checked = True Then
                cmd = New MySqlCommand("SELECT IDEntregaCobro,SecondID,Descripcion,FechaEntrega,Nombre,Cantidad,NoInicial,NoFinal FROM entregacobro INNER JOIN Empleados on EntregaCobro.IDCobrador=Empleados.IDEmpleado Where NoEntrega like '%" + txtBuscar.Text + "%' and EntregaCobro.Nulo=0 ORDER BY IDEntregaCobro DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "EntregaCobro")

            Bs.DataMember = "EntregaCobro"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvEntregas.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvEntregas
            .Columns(0).Visible = False
            .Columns(1).Width = 100
            .Columns(1).HeaderText = "Código"
            .Columns(2).Width = 105
            .Columns(2).HeaderText = "Descripción"
            .Columns(3).HeaderText = "Fecha"
            .Columns(3).Width = 70
            .Columns(4).HeaderText = "Cobrador"
            .Columns(4).Width = 185
            .Columns(5).Width = 40
            .Columns(5).HeaderText = "Cant."
            .Columns(6).HeaderText = "Desde"
            .Columns(6).Width = 50
            .Columns(7).HeaderText = "Hasta"
            .Columns(7).Width = 50
        End With
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub
    Private Sub rdbNoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoEntrega.CheckedChanged
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

    Private Sub DgvEntregas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEntregas.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvEntregas.Focus()
    End Sub

    Private Sub DgvEntregas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvEntregas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvEntregas.Focus()
        End If
    End Sub

    Private Sub DgvEntregas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvEntregas.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvEntregas.ColumnCount
                Dim NumRows As Integer = DgvEntregas.RowCount
                Dim CurCell As DataGridViewCell = DgvEntregas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvEntregas.CurrentCell = DgvEntregas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvEntregas.CurrentCell = DgvEntregas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDEntrega As New Label
            lblIDEntrega.Text = DgvEntregas.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDEntregaCobro,EntregaCobro.SecondID,NoEntrega,Descripcion,FechaEntrega,IDCobrador,Nombre,Cantidad,NoInicial,NoFinal,Monto,Comision,Cierre,EntregaCobro.Nulo,SumaEfectivos,SumaCambios FROM entregacobro INNER JOIN Empleados on EntregaCobro.IDCobrador=Empleados.IDEmpleado where IDEntregaCobro='" + lblIDEntrega.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Entregacobro")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Entregacobro")

            If Me.Owner.Name = frm_entrega_cobro.Name Then
                frm_entrega_cobro.txtIDEntrega.Text = (Tabla.Rows(0).Item("IDEntregaCobro"))
                frm_entrega_cobro.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_entrega_cobro.txtNoEntrega.Text = (Tabla.Rows(0).Item("NoEntrega"))
                frm_entrega_cobro.txtNota.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_entrega_cobro.DtpFechaEntrega.Value = (Tabla.Rows(0).Item("FechaEntrega"))
                frm_entrega_cobro.lblIDCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))
                frm_entrega_cobro.CbxCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_entrega_cobro.txtCantidad.Text = (Tabla.Rows(0).Item("Cantidad"))
                frm_entrega_cobro.txtNoInicial.Text = (Tabla.Rows(0).Item("NoInicial"))
                frm_entrega_cobro.txtNoFinal.Text = (Tabla.Rows(0).Item("NoFinal"))
                frm_entrega_cobro.txtMontoEntrega.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_entrega_cobro.txtComision.Text = CDbl(Tabla.Rows(0).Item("Comision")).ToString("C")
                frm_entrega_cobro.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
                frm_entrega_cobro.lblCierreEntrega.Text = (Tabla.Rows(0).Item("Cierre"))
                frm_entrega_cobro.txtEfectivo.EditValue = (Tabla.Rows(0).Item("SumaEfectivos"))
                frm_entrega_cobro.txtCambios.EditValue = (Tabla.Rows(0).Item("SumaCambios"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_entrega_cobro.chkNulo.Checked = False
                Else
                    frm_entrega_cobro.chkNulo.Checked = True
                End If
                If (Tabla.Rows(0).Item("Cierre")) = 0 Then
                    frm_entrega_cobro.chkCerrarEntrega.Checked = False
                Else
                    frm_entrega_cobro.chkCerrarEntrega.Checked = True
                End If
                frm_entrega_cobro.RefrescarTablaRecibos()

            ElseIf Me.Owner.Name = frm_reporte_recibos_cobros.Name Then
                frm_reporte_recibos_cobros.txtIDEntrega.Text = (Tabla.Rows(0).Item("IDEntregaCobro"))
                frm_reporte_recibos_cobros.txtEntrega.Text = (Tabla.Rows(0).Item("SecondID"))

            ElseIf Me.Owner.Name = frm_consulta_recibos_cobros.Name Then
                frm_consulta_recibos_cobros.txtIDEntrega.Text = (Tabla.Rows(0).Item("IDEntregaCobro"))
                frm_consulta_recibos_cobros.txtEntrega.Text = (Tabla.Rows(0).Item("SecondID"))

            End If



            Close()
            Exit Sub
        Catch ex As Exception
        End Try

    End Sub

   
End Class