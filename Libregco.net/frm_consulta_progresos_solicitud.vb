Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_consulta_progresos_solicitud
    Dim Con As New MySqlConnection(CnString)
    Dim sqlQ As String
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, lblFormatoImpresion As New Label
    Dim SelectCommand As String = "Select IDMovimiento,FechaMovimiento,IDCuentaBancaria,NoCuenta,IDTipoMovimientoBanc,TipoMovimiento,Monto,MovimientosBanco.Nulo from libregco.MovimientosBanco INNER JOIN Libregco.cuentasbancarias on movimientosbanco.IDCuentaBancaria=CuentasBancarias.IDCuenta INNER JOIN Libregco.tipomovbancario on movimientosbanco.IDTipoMovimientoBanc=Tipomovbancario.IDTipoMovBancario"
    Dim FullCommand, FechaValue, MontoValue, IDCuentaBancariaValue, IDTipoMovValue, NuloValue As String
    Dim A1, A2, A3, A4 As String
    Dim Permisos As New ArrayList


    Private Sub frm_buscar_mov_bancarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarDatos()
        Actualizar()
        Permisos = PasarPermisos(Me.Tag)
        cmd = New MySqlCommand("Select IDMovimiento,FechaMovimiento,IDCuentaBancaria,NoCuenta,IDTipoMovimientoBanc,TipoMovimiento,Monto,MovimientosBanco.Nulo from libregco.MovimientosBanco INNER JOIN Libregco.cuentasbancarias on movimientosbanco.IDCuentaBancaria=CuentasBancarias.IDCuenta INNER JOIN Libregco.tipomovbancario on movimientosbanco.IDTipoMovimientoBanc=Tipomovbancario.IDTipoMovBancario WHERE FechaMovimiento BETWEEN '" + txtFechaInicial.Text + "' AND '" + txtFechaFinal.Text + "' AND MovimientosBanco.Nulo=0 ", Con)
        RefrescarTabla()
        ConstructorSQL()
    End Sub

    Private Sub LimpiarDatos()
        txtIDCuentaBancaria.Clear()
        txtIDTipoMovimiento.Clear()
        txtCuentaBancaria.Clear()
        txtTipoMovimiento.Clear()
        txtFechaInicial.Clear()
        txtFechaFinal.Clear()
        txtMontoInicial.Clear()
        txtMontoFinal.Clear()
        txtIDTipoMovimiento.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
        FillFormatoImpresion()
    End Sub

    Private Sub txtMontoFinal_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub FillFormatoImpresion()
        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Formato FROM FormatoImpresion ORDER BY IDFormatoImpresion", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "FormatoImpresion")
        cbxFormatoImp.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable
        Dim Fila As DataRow

        Tabla = Ds1.Tables("FormatoImpresion")
        For Each Fila In Tabla.Rows
            cbxFormatoImp.Items.Add(Fila.Item("Formato"))
        Next
        cbxFormatoImp.SelectedIndex = 0
    End Sub

    Private Sub RefrescarTabla()
        Ds.Clear()
        Con.Open()
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "MovimientosBancarios")
        DgvMovimientosBanc.DataSource = Ds
        DgvMovimientosBanc.DataMember = "MovimientosBancarios"
        Con.Close()
        PropiedadColumnsDgv()
        SumarRows()
        MarcarCanceladas()
        DgvMovimientosBanc.ClearSelection()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvMovimientosBanc
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 120
            .Columns(1).Width = 100
            .Columns(1).HeaderText = "Fecha"
            .Columns(2).Visible = False
            .Columns(3).HeaderText = "Cta. Bancaria"
            .Columns(3).Width = 120
            .Columns(4).Visible = False
            .Columns(5).HeaderText = "Mov.Bancario"
            .Columns(5).Width = 180
            .Columns(6).HeaderText = "Total Transacción"
            .Columns(6).Width = 130
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim Counter As Integer = DgvMovimientosBanc.Rows.Count
        Dim x As Integer = 0

        lblCantidad.Text = "Registros Encontrados: " & Counter
    End Sub

    Private Sub SelectTipoMovimiento()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT TipoMovimiento FROM tipomovbancario Where IDTipoMovBancario='" + txtIDTipoMovimiento.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "tipomovbancario")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("tipomovbancario")
            txtTipoMovimiento.Text = (Tabla.Rows(0).Item("TipoMovimiento"))

        Catch ex As Exception
            txtTipoMovimiento.Text = ""
        End Try
    End Sub

    Private Sub SelectCuentaBancaria()
        Try

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT NoCuenta FROM CuentasBancarias Where IDCuenta='" + txtIDCuentaBancaria.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "CuentasBancarias")
            Con.Close()

            Dim Tabla As DataTable
            Tabla = Ds1.Tables("CuentasBancarias")

            txtCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))

        Catch ex As Exception
            txtCuentaBancaria.Text = ""
        End Try
    End Sub

    Private Sub SelectFormato()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDFormatoImpresion FROM FormatoImpresion Where Formato='" + cbxFormatoImp.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "FormatoImpresion")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("FormatoImpresion")
            lblFormatoImpresion.Text = (Tabla.Rows(0).Item("IDFormatoImpresion"))

        Catch ex As Exception
            lblFormatoImpresion.Text = ""
        End Try
    End Sub

    Private Sub txtIDTipoMovimiento_Leave(sender As Object, e As EventArgs) Handles txtIDTipoMovimiento.Leave
        SelectTipoMovimiento()
    End Sub

    Private Sub txtIDCuentaBancaria_Leave(sender As Object, e As EventArgs) Handles txtIDCuentaBancaria.Leave
        SelectCuentaBancaria()
    End Sub


    Private Sub txtMontoInicial_Leave(sender As Object, e As EventArgs) Handles txtMontoInicial.Leave
        If txtMontoInicial.Text = "" Then
        Else
            txtMontoInicial.Text = CDbl(txtMontoInicial.Text).ToString("C")
        End If
        VerificarCondicionMontos()
    End Sub

    Private Sub txtMontoFinal_Leave(sender As Object, e As EventArgs) Handles txtMontoFinal.Leave
        If txtMontoFinal.Text = "" Then
        Else
            txtMontoFinal.Text = CDbl(txtMontoFinal.Text).ToString("C")
        End If
        VerificarCondicionMontos()
    End Sub

    Private Sub txtMontoInicial_Enter(sender As Object, e As EventArgs) Handles txtMontoInicial.Enter
        If txtMontoInicial.Text = "" Then
        Else
            txtMontoInicial.Text = CDbl(txtMontoInicial.Text)
        End If
    End Sub

    Private Sub txtMontoFinal_Enter(sender As Object, e As EventArgs) Handles txtMontoFinal.Enter
        If txtMontoFinal.Text = "" Then
        Else
            txtMontoFinal.Text = CDbl(txtMontoFinal.Text)
        End If
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
        VerificarCondicionNulo()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub txtFechaFinal_Leave(sender As Object, e As EventArgs) Handles txtFechaFinal.Leave
        If IsDate(txtFechaFinal.Text) Then
        Else
            txtFechaFinal.Text = ""
        End If
    End Sub

    Private Sub txtFechaInicial_Leave(sender As Object, e As EventArgs) Handles txtFechaInicial.Leave
        If IsDate(txtFechaInicial.Text) Then
        Else
            txtFechaInicial.Text = ""
        End If
    End Sub

    Private Sub txtFechaFinal_TextChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.TextChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaInicial_TextChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.TextChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtIDTipoMovimiento_TextChanged(sender As Object, e As EventArgs) Handles txtIDTipoMovimiento.TextChanged
        VerificarCondicionTipoMovimiento()
    End Sub

    Private Sub txtIDCuentaBancaria_TextChanged(sender As Object, e As EventArgs) Handles txtIDCuentaBancaria.TextChanged
        VerificarCondicionCuentaBancaria()
    End Sub

    Private Sub VerificarCondicionTipoMovimiento()
        If txtIDTipoMovimiento.Text = "" Then
            IDTipoMovValue = ""
        Else
            IDTipoMovValue = " MovimientosBanco.IDTipoMovimientoBanc=" & txtIDTipoMovimiento.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCuentaBancaria()
        If txtIDCuentaBancaria.Text = "" Then
            IDCuentaBancariaValue = ""
        Else
            IDCuentaBancariaValue = " MovimientosBanco.IDCuentaBancaria=" & txtIDCuentaBancaria.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " FechaMovimiento BETWEEN '" & txtFechaInicial.Text & "' AND '" & txtFechaFinal.Text & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionMontos()
        Try
            If CDbl(txtMontoInicial.Text) <= CDbl(txtMontoFinal.Text) Then
                MontoValue = " Monto BETWEEN '" & CDbl(txtMontoInicial.Text) & "' AND '" & CDbl(txtMontoFinal.Text) & "'"
            Else
                MontoValue = ""
            End If
            ConstructorSQL()
        Catch ex As Exception
            MontoValue = ""
        End Try
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " MovimientosBanco.Nulo=0 "
        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionTipoMovimiento()
        VerificarCondicionCuentaBancaria()
        VerificarCondicionFecha()
        VerificarCondicionMontos()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDCuentaBancariaValue <> "" Or IDTipoMovValue <> "" Or MontoValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDCuentaBancariaValue & IDTipoMovValue & MontoValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDCuentaBancariaValue <> "" And IDTipoMovValue & MontoValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDTipoMovValue <> "" And MontoValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If MontoValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDCuentaBancariaValue & A2 & IDTipoMovValue & A3 & MontoValue & A4 & NuloValue

        txtQuery.Text = "SQL Query: " & FullCommand
    End Sub

    Private Sub cbxFormatoImp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFormatoImp.SelectedIndexChanged
        SelectFormato()
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvMovimientosBanc.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgvMovimientosBanc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMovimientosBanc.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDMovimientoBanc As New Label
            lblIDMovimientoBanc.Text = DgvMovimientosBanc.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select * from libregco.movimientosbanco where IDMovimiento='" + lblIDMovimientoBanc.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "movimientosbanco")
            Con.Close()

            Dim Tabla As DataTable
            Tabla = Ds1.Tables("movimientosbanco")

            While frm_movimientos_bancarios.Visible = True
                frm_movimientos_bancarios.txtIDMovimientoBanc.Text = (Tabla.Rows(0).Item("IDMovimiento"))
                frm_movimientos_bancarios.lblIDCuentaBancaria.Text = (Tabla.Rows(0).Item("IDCuentaBancaria"))
                frm_movimientos_bancarios.lblIDTipoMovimiento.Text = (Tabla.Rows(0).Item("IDTipoMovimientoBanc"))
                frm_movimientos_bancarios.dtpFecha.Value = (Tabla.Rows(0).Item("FechaMovimiento"))
                frm_movimientos_bancarios.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_movimientos_bancarios.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_movimientos_bancarios.lblchkNulo.Text = (Tabla.Rows(0).Item("Nulo"))
                FillChkBox()
                SelectTipoMovimientoenPadre()
                SelectCuentaBancarianPadre()
                Close()

                Exit Sub

            End While

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillChkBox()
        Dim IDMovimiento, Nulo As New Label
        IDMovimiento.Text = DgvMovimientosBanc.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select Nulo from libregco.movimientosbanco where IDMovimiento='" + IDMovimiento.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "movimientosbanco")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("movimientosbanco")
        Nulo.Text = (Tabla.Rows(0).Item("Nulo"))

        If Nulo.Text = 0 Then
            frm_movimientos_bancarios.chkNulo.Checked = False
        Else
            frm_movimientos_bancarios.chkNulo.Checked = True
        End If
    End Sub

    Private Sub SelectTipoMovimientoenPadre()

        Dim lblIDTipoMovimiento As New Label

        If frm_movimientos_bancarios.Visible = True Then
            lblIDTipoMovimiento.Text = frm_movimientos_bancarios.lblIDTipoMovimiento.Text
        End If

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select TipoMovimiento From libregco.tipomovbancario where IDTipoMovBancario = '" + lblIDTipoMovimiento.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "tipomovbancario")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("tipomovbancario")
        Dim Fila As DataRow

        For Each Fila In Tabla.Rows
            If frm_movimientos_bancarios.Visible = True Then
                frm_movimientos_bancarios.cbxTipoMovimiento.Text = Fila.Item("TipoMovimiento")
            End If
        Next

    End Sub

    Private Sub SelectCuentaBancarianPadre()

        Dim lblIDCuentaBancaria As New Label

        If frm_movimientos_bancarios.Visible = True Then
            lblIDCuentaBancaria.Text = frm_movimientos_bancarios.lblIDCuentaBancaria.Text
        End If

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select NoCuenta From libregco.CuentasBancarias where IDCuenta = '" + lblIDCuentaBancaria.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "CuentasBancarias")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")
        Dim Fila As DataRow

        For Each Fila In Tabla.Rows
            If frm_movimientos_bancarios.Visible = True Then
                frm_movimientos_bancarios.cbxCuentaBancaria.Text = Fila.Item("NoCuenta")
            End If
        Next

    End Sub

    Private Sub btnBuscarCuentaBancaria_Click(sender As Object, e As EventArgs) Handles btnBuscarCuentaBancaria.Click
        frm_buscar_cuenta_bancaria.ShowDialog()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_tipo_movimiento_bancario.ShowDialog()
    End Sub
End Class