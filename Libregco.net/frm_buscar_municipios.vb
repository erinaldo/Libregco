Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_municipios

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_municipios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM Municipios where IDMunicipio like '%" + txtBuscar.Text + "%' ORDER BY IDMunicipio DESC", ConLibregco)
            ElseIf rdbMunicipio.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Municipios where Municipio like '%" + txtBuscar.Text + "%' ORDER BY Municipio ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Municipios")

            Bs.DataMember = "Municipios"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvMunicipios.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbMunicipio.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvMunicipios
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Visible = False
            .Columns(2).Width = 370
            .Columns(3).Visible = False
        End With
    End Sub

    Private Sub rdbMunicipio_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMunicipio.CheckedChanged
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

    Private Sub DgvMunicipios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMunicipios.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvMunicipios.Focus()
    End Sub

    Private Sub DgvMunicipios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvMunicipios.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvMunicipios.Focus()
        End If
    End Sub

    Private Sub DgvMunicipios_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvMunicipios.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvMunicipios.ColumnCount
                Dim NumRows As Integer = DgvMunicipios.RowCount
                Dim CurCell As DataGridViewCell = DgvMunicipios.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvMunicipios.CurrentCell = DgvMunicipios.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvMunicipios.CurrentCell = DgvMunicipios.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Dim IDMunicipio As New Label
        IDMunicipio.Text = DgvMunicipios.CurrentRow.Cells(0).Value
        Try

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDMunicipio,Municipios.IDProvincia,Municipio,Provincias.Provincia,Municipios.Nulo from Municipios INNER JOIN Provincias ON Municipios.IDProvincia=Provincias.IDProvincia Where IDMunicipio='" + IDMunicipio.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Municipios")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("Municipios")

            If Me.Owner.Name = frm_mant_municipios.Name Then
                frm_mant_municipios.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_mant_municipios.txtIDProvincia.Text = (Tabla.Rows(0).Item("IDProvincia"))
                frm_mant_municipios.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))
                frm_mant_municipios.txtProvincia.Text = (Tabla.Rows(0).Item("Provincia"))
                FillChkBox()

            ElseIf Me.Owner.Name = frm_reporte_ventas.Name Then
                frm_reporte_ventas.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_ventas.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                frm_reporte_detalle_ventas.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_detalle_ventas.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
                frm_reporte_devolucion_ventas.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_devolucion_ventas.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_clientes.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_cotizacion.Name Then
                frm_reporte_cotizacion.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_cotizacion.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
                frm_reporte_registro_facturas.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_registro_facturas.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
                frm_reporte_nota_debito_credito_cxc.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_nota_debito_credito_cxc.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
                frm_reporte_cobros_facturas.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_cobros_facturas.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                frm_reporte_cuentas_por_cobrar.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_cuentas_por_cobrar.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_suplidor.Name Then
                frm_reporte_suplidor.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_suplidor.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_registro_facturas_cxp.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_cuentas_por_pagar.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_pagos_facturas.Name Then
                frm_reporte_pagos_facturas.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_pagos_facturas.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_reporte_empleados.txtMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        Dim Nulo As New Label
        Nulo.Text = DgvMunicipios.CurrentRow.Cells(3).Value

        If frm_mant_municipios.Visible = True Then
            If Nulo.Text = 0 Then
                frm_mant_municipios.chkNulo.Checked = False
            Else
                frm_mant_municipios.chkNulo.Checked = True
            End If
        End If
    End Sub
End Class