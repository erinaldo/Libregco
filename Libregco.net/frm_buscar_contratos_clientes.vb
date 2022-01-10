Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_contratos_clientes

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_contratos_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDContrato,SecondID,NoContrato,Fecha,FechaVencimiento FROM contratos where SecondID like '%" + txtBuscar.Text + "%' ORDER BY IDContrato DESC LIMIT 50", Con)
            ElseIf rdbNoContrato.Checked = True Then
                cmd = New MySqlCommand("SELECT IDContrato,SecondID,NoContrato,Fecha,FechaVencimiento FROM contratos where NoContrato like '%" + txtBuscar.Text + "%' ORDER BY NoContrato ASC LIMIT 50", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Contrato")

            Bs.DataMember = "Contrato"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvContratos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbNoContrato.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvContratos
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).HeaderText = "No. Contrato"
            .Columns(2).Width = 200
            .Columns(3).Width = 220
            .Columns(4).HeaderText = "Vencimiento"
            .Columns(4).Width = 220
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

    Private Sub DgvContratos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvContratos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvContratos.Focus()
    End Sub

    Private Sub DgvContratos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvContratos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvContratos.Focus()
        End If
    End Sub

    Private Sub DgvContratos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvContratos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvContratos.ColumnCount
                Dim NumRows As Integer = DgvContratos.RowCount
                Dim CurCell As DataGridViewCell = DgvContratos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvContratos.CurrentCell = DgvContratos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvContratos.CurrentCell = DgvContratos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            Dim IDContrato As New Label
            IDContrato.Text = DgvContratos.CurrentRow.Cells(0).Value
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDContrato,Contratos.SecondID,Contratos.IDTipoDocumento,TipoDocumento.Documento,Contratos.IDAlmacen,Almacen.Almacen,Contratos.IDUsuario,Usuarios.Nombre,Contratos.IDCliente,Clientes.Nombre as NombreCliente,NoContrato,Folio,Contratos.Fecha,Contratos.IDPlazoVencimiento,PlazoContrato.Plazo,PlazoContrato.Meses,FechaVencimiento,Observaciones,Contratos.Nulo FROM contratos INNER JOIN TipoDocumento on Contratos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Almacen on Contratos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Empleados as Usuarios on Contratos.IDUsuario=Usuarios.IDEmpleado INNER JOIN PlazoContrato on Contratos.IDPlazoVencimiento=PlazoContrato.IDPlazoContrato INNER JOIN Clientes on Contratos.IDCliente=Clientes.IDCliente Where Contratos.IDContrato='" + IDContrato.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Contratos")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Contratos")

            If Me.Owner.Name = frm_contratos_clientes.Name Then
                frm_contratos_clientes.Hora.Enabled = False
                frm_contratos_clientes.txtIDContrato.Text = (Tabla.Rows(0).Item("IDContrato"))
                frm_contratos_clientes.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_contratos_clientes.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss")
                frm_contratos_clientes.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_contratos_clientes.txtCliente.Text = (Tabla.Rows(0).Item("NombreCliente"))
                frm_contratos_clientes.txtNoContrato.Text = (Tabla.Rows(0).Item("NoContrato"))
                frm_contratos_clientes.txtFolio.Text = (Tabla.Rows(0).Item("Folio"))
                frm_contratos_clientes.txtIDPlazo.Text = (Tabla.Rows(0).Item("IDPlazoVencimiento"))
                frm_contratos_clientes.txtPlazo.Text = (Tabla.Rows(0).Item("Plazo"))
                frm_contratos_clientes.txtObservacion.Text = (Tabla.Rows(0).Item("Observaciones"))
                frm_contratos_clientes.dtpVencimiento.Value = (Tabla.Rows(0).Item("FechaVencimiento"))
                frm_contratos_clientes.dtpVencimiento.Text = (Tabla.Rows(0).Item("FechaVencimiento"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_contratos_clientes.lblNulo.Text = 0
                    frm_contratos_clientes.ChkNulo.Checked = False
                Else
                    frm_contratos_clientes.ChkNulo.Checked = True
                    frm_contratos_clientes.lblNulo.Text = 1
                End If

                Con.Open()
                cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=81", Con)
                Dim PermitirCambiarPlazo As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If PermitirCambiarPlazo = 1 Then
                    frm_contratos_clientes.btn_buscar_plazo.Enabled = True
                Else
                    frm_contratos_clientes.btn_buscar_plazo.Enabled = False
                End If

            End If

            Close()
            Exit Sub


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class