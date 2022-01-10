Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_lista_cobros

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_lista_cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If Me.Owner.Name = frm_cargo_pagareses.Name Then

                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Nombre,Descripcion FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where IDControlPagares like '%" + txtBuscar.Text + "%' and IDTipoDocumento=32 and ListaPagares.Nulo=0 ORDER BY IDControlPagares DESC LIMIT 100", Con)
                ElseIf rdbDescripcion.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Nombre,Descripcion FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where Descripcion like '%" + txtBuscar.Text + "%' and IDTipoDocumento=32 and ListaPagares.Nulo=0 ORDER BY Descripcion ASC LIMIT 100", Con)
                End If

            ElseIf Me.Owner.Name = frm_cargar_pagare_individual.Name Then
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Nombre,Descripcion FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where IDControlPagares like '%" + txtBuscar.Text + "%' and IDTipoDocumento=33 and ListaPagares.Nulo=0 ORDER BY IDControlPagares DESC LIMIT 100", Con)
                ElseIf rdbDescripcion.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Nombre,Descripcion FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where Descripcion like '%" + txtBuscar.Text + "%' and IDTipoDocumento=33 and ListaPagares.Nulo=0 ORDER BY Descripcion ASC LIMIT 100", Con)
                End If

            ElseIf Me.Owner.Name = frm_traspasar_pagare.Name Then
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Nombre,Descripcion FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where IDControlPagares like '%" + txtBuscar.Text + "%' and IDTipoDocumento=34 and ListaPagares.Nulo=0 ORDER BY IDControlPagares DESC", Con)
                ElseIf rdbDescripcion.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Nombre,Descripcion FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where Descripcion like '%" + txtBuscar.Text + "%' and IDTipoDocumento=34 and ListaPagares.Nulo=0 ORDER BY Descripcion ASC", Con)
                End If

            ElseIf Me.Owner.Name = frm_restablecer_pagare.Name Then
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Nombre,Descripcion FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where IDControlPagares like '%" + txtBuscar.Text + "%' and IDTipoDocumento=48 and ListaPagares.Nulo=0 ORDER BY IDControlPagares DESC", Con)
                ElseIf rdbDescripcion.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Nombre,Descripcion FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where Descripcion like '%" + txtBuscar.Text + "%' and IDTipoDocumento=48 and ListaPagares.Nulo=0 ORDER BY Descripcion ASC", Con)
                End If
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Listas")

            Bs.DataMember = "Listas"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvListaPagare.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvListaPagare
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).Width = 90
            .Columns(3).Width = 220
            .Columns(4).Width = 240
            .Columns(4).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvListaPagare.Focus()
    End Sub

    Private Sub DgvListaPagare_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvListaPagare.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvListaPagare.Focus()
        End If
    End Sub

    Private Sub DgvListaPagare_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvListaPagare.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvListaPagare.ColumnCount
                Dim NumRows As Integer = DgvListaPagare.RowCount
                Dim CurCell As DataGridViewCell = DgvListaPagare.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvListaPagare.CurrentCell = DgvListaPagare.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvListaPagare.CurrentCell = DgvListaPagare.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvListaPagare_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListaPagare.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDListaPagare, Nulo As New Label
        IDListaPagare.Text = DgvListaPagare.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDControlPagares,SecondID,Fecha,Hora,Empleados.IDEmpleado,Nombre,Descripcion,FechaVencimiento,ListaPagares.Nulo FROM listapagares INNER JOIN Empleados on ListaPagares.IDCobrador=Empleados.IDEmpleado Where IDControlPagares='" + IDListaPagare.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "ListaPagares")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("ListaPagares")

        If Me.Owner.Name = frm_cargo_pagareses.Name Then
            frm_cargo_pagareses.txtIDListaPagare.Text = (Tabla.Rows(0).Item("IDControlPagares"))
            frm_cargo_pagareses.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_cargo_pagareses.txtFecha.Text = (Tabla.Rows(0).Item("Fecha"))
            frm_cargo_pagareses.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_cargo_pagareses.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_cargo_pagareses.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_cargo_pagareses.txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
            frm_cargo_pagareses.DtpFechaVencimiento.Value = (Tabla.Rows(0).Item("FechaVencimiento"))

            If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_cargo_pagareses.ChkNulo.Checked = True
            Else
                frm_cargo_pagareses.ChkNulo.Checked = False
            End If

            frm_cargo_pagareses.RefrescarTablaPagares()


        ElseIf Me.Owner.Name = frm_cargar_pagare_individual.Name Then

            frm_cargar_pagare_individual.txtIDListaPagare.Text = (Tabla.Rows(0).Item("IDControlPagares"))
            frm_cargar_pagare_individual.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_cargar_pagare_individual.txtFecha.Text = (Tabla.Rows(0).Item("Fecha"))
            frm_cargar_pagare_individual.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_cargar_pagare_individual.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_cargar_pagare_individual.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_cargar_pagare_individual.txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
            frm_cargar_pagare_individual.RefrescarTablaPagares()
            frm_cargar_pagare_individual.HabilitarIntroduccion()

            If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_cargar_pagare_individual.ChkNulo.Checked = True
            Else
                frm_cargar_pagare_individual.ChkNulo.Checked = False
            End If

        ElseIf Me.Owner.Name = frm_traspasar_pagare.Name Then

            frm_traspasar_pagare.txtIDListaPagare.Text = (Tabla.Rows(0).Item("IDControlPagares"))
            frm_traspasar_pagare.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_traspasar_pagare.txtFecha.Text = (Tabla.Rows(0).Item("Fecha"))
            frm_traspasar_pagare.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_traspasar_pagare.txtIDCobradorTransferir.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_traspasar_pagare.txtCobradorTransferir.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_traspasar_pagare.txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
            frm_traspasar_pagare.RefrescarTablaPagares()

            If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_traspasar_pagare.ChkNulo.Checked = True
            Else
                frm_traspasar_pagare.ChkNulo.Checked = False
            End If

            frm_traspasar_pagare.btnDevolverTodo.Enabled = False
        ElseIf Me.Owner.Name = frm_restablecer_pagare.Name Then
            frm_restablecer_pagare.txtIDListaPagare.Text = (Tabla.Rows(0).Item("IDControlPagares"))
            frm_restablecer_pagare.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_restablecer_pagare.txtFecha.Text = (Tabla.Rows(0).Item("Fecha"))
            frm_restablecer_pagare.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_restablecer_pagare.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_restablecer_pagare.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_restablecer_pagare.RefrescarTablaPagares()

            If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_restablecer_pagare.ChkNulo.Checked = True
            Else
                frm_restablecer_pagare.ChkNulo.Checked = False
            End If
            frm_restablecer_pagare.RefrescarTablaPagares()
        End If

        Close()
        Exit Sub
    End Sub

   


  

End Class