Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cambiar_estado_factura

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_cambiar_estado_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        RefrescarTabla()
        PropiedadColumnsDvg()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        DgvFacturasAgregadas.Rows.Clear()
        txtIDEstado.Clear()
        txtEstado.Clear()
        lblColor.BackColor = SystemColors.Control
        txtBuscar.Clear()
    End Sub

    Private Sub txtIDEstado_Leave(sender As Object, e As EventArgs) Handles txtIDEstado.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select EstadoFactura from EstadoFactura Where IDEstadoFactura='" + txtIDEstado.Text + "'", ConLibregco)
        txtEstado.Text = Convert.ToString(cmd.ExecuteScalar())

        If txtEstado.Text <> "" Then
            cmd = New MySqlCommand("Select Color from EstadoFactura Where IDEstadoFactura='" + txtIDEstado.Text + "'", ConLibregco)
            lblColor.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))
        End If

        ConLibregco.Close()

        If txtEstado.Text = "" Then
            txtIDEstado.Clear()
            txtEstado.Clear()
            lblColor.BackColor = SystemColors.Control
        End If

    End Sub

    Private Sub btnBuscarEstado_Click(sender As Object, e As EventArgs) Handles btnBuscarEstado.Click
        frm_buscar_estado_factura.ShowDialog(Me)
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT FacturaDatos.IDEstadoFactura,EstadoFactura.EstadoFactura,IDFacturaDatos,SecondID,FacturaDatos.Fecha,FacturaDatos.FechaVencimiento,IDCliente,NombreFactura,(FacturaDatos.Balance+FacturaDatos.Cargos) as Balance,EstadoFactura.Color FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.EstadoFactura on FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura Where FacturaDatos.Balance>0 and SecondID like '%" + txtBuscar.Text + "%' Order By IDFacturaDatos DESC Limit 50", ConMixta)
            ElseIf rdbCliente.Checked = True Then
                cmd = New MySqlCommand("SELECT FacturaDatos.IDEstadoFactura,EstadoFactura.EstadoFactura,IDFacturaDatos,SecondID,FacturaDatos.Fecha,FacturaDatos.FechaVencimiento,IDCliente,NombreFactura,(FacturaDatos.Balance+FacturaDatos.Cargos) as Balance,EstadoFactura.Color FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.EstadoFactura on FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura Where FacturaDatos.Balance>0 and NombreFactura like '%" + txtBuscar.Text + "%' Order By IDFacturaDatos DESC Limit 50", ConMixta)
            ElseIf rdbFecha.Checked = True Then
                cmd = New MySqlCommand("SELECT FacturaDatos.IDEstadoFactura,EstadoFactura.EstadoFactura,IDFacturaDatos,SecondID,FacturaDatos.Fecha,FacturaDatos.FechaVencimiento,IDCliente,NombreFactura,(FacturaDatos.Balance+FacturaDatos.Cargos) as Balance,EstadoFactura.Color FROM" & SysName.Text & " facturadatos INNER JOIN Libregco.EstadoFactura on FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura Where FacturaDatos.Balance>0 and FacturaDatos.Fecha like '%" + txtBuscar.Text + "%' Order By Fecha DESC Limit 50", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Facturas")

            Bs.DataMember = "Facturas"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvFacturas.DataSource = Bs
            DgvFacturas.ClearSelection()

            For Each row As DataGridViewRow In DgvFacturas.Rows
                row.Cells(1).Style.ForeColor = Color.FromArgb(row.Cells(9).Value)
            Next
        Catch ex As Exception

        End Try
    End Sub



    Private Sub PropiedadColumnsDvg()
        Try
            Dim DatagridWidth As Double = (DgvFacturas.Width - DgvFacturas.RowHeadersWidth) / 100

            DgvFacturas.Columns(0).Visible = False

            DgvFacturas.Columns(1).Width = DatagridWidth * 12
            DgvFacturas.Columns(1).HeaderText = "Status"

            DgvFacturas.Columns(2).Visible = False

            DgvFacturas.Columns(3).Width = DatagridWidth * 15
            DgvFacturas.Columns(3).HeaderText = "No. Factura"

            DgvFacturas.Columns(4).HeaderText = "Fecha"
            DgvFacturas.Columns(4).Width = DatagridWidth * 11

            DgvFacturas.Columns(5).HeaderText = "Venc."
            DgvFacturas.Columns(5).Width = DatagridWidth * 11


            DgvFacturas.Columns(6).HeaderText = "ID"
            DgvFacturas.Columns(6).Width = DatagridWidth * 9

            DgvFacturas.Columns(7).HeaderText = "Cliente"
            DgvFacturas.Columns(7).Width = DatagridWidth * 27

            DgvFacturas.Columns(8).Width = DatagridWidth * 15
            DgvFacturas.Columns(8).DefaultCellStyle.Format = "C"

            DgvFacturas.Columns(9).Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAnexar_Click(sender As Object, e As EventArgs) Handles btnAnexar.Click
        Try
            If DgvFacturas.SelectedRows.Count > 0 Then
                Dim IDStatusSelected As New Label
                IDStatusSelected.Text = DgvFacturas.CurrentRow.Cells(0).Value

                If txtIDEstado.Text = "" Then
                    MessageBox.Show("Estableza un estado de factura para anexar el registro.", "Seleccione un status", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    btnBuscarEstado.PerformClick()
                    Exit Sub
                ElseIf IDStatusSelected.Text = txtIDEstado.Text Then
                    MessageBox.Show("La factura selecciona [" & DgvFacturas.CurrentRow.Cells(3).Value & "] del cliente [" & DgvFacturas.CurrentRow.Cells(6).Value & "] " & DgvFacturas.CurrentRow.Cells(7).Value & " tiene el mismo estado a establecer.", "Se encontró el mismo estado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                DgvFacturasAgregadas.Rows.Add(DgvFacturas.CurrentRow.Cells(2).Value, txtIDEstado.Text, txtEstado.Text, lblColor.BackColor.ToArgb.ToString, DgvFacturas.CurrentRow.Cells(3).Value, DgvFacturas.CurrentRow.Cells(8).Value)

                For Each Row As DataGridViewRow In DgvFacturasAgregadas.Rows
                    Row.Cells(2).Style.ForeColor = Color.FromArgb(Row.Cells(3).Value)
                Next

                DgvFacturasAgregadas.ClearSelection()
                DgvFacturas.ClearSelection()

            Else
                MessageBox.Show("No hay una fila seleccionada.")

            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSacar_Click(sender As Object, e As EventArgs) Handles btnSacar.Click
        Try
            If DgvFacturasAgregadas.SelectedRows.Count > 0 Then
                DgvFacturasAgregadas.Rows.Remove(DgvFacturasAgregadas.CurrentRow)
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCliente.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFecha.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim IDFactura, IDEstadotoChanged As New Label

            Con.Open()

            For Each row As DataGridViewRow In DgvFacturasAgregadas.Rows

                IDFactura.Text = row.Cells(0).Value
                IDEstadotoChanged.Text = row.Cells(1).Value

                sqlQ = "UPDATE FacturaDatos SET IDEstadoFactura='" + IDEstadotoChanged.Text + "' WHERE IDFacturaDatos= (" + IDFactura.Text + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

            Next

            Con.Close()
            RefrescarTabla()
            MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim IDFactura, IDEstadotoChanged As New Label

            Con.Open()

            For Each row As DataGridViewRow In DgvFacturasAgregadas.Rows

                IDFactura.Text = row.Cells(0).Value
                IDEstadotoChanged.Text = row.Cells(1).Value

                sqlQ = "UPDATE FacturaDatos SET IDEstadoFactura='" + IDEstadotoChanged.Text + "' WHERE IDFacturaDatos= (" + IDFactura.Text + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

            Next

            Con.Close()
            RefrescarTabla()
            LimpiarDatos()
            MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


        Catch ex As Exception

        End Try
    End Sub
End Class