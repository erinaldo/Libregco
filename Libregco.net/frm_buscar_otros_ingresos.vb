Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_otros_ingresos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_otros_ingresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
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
                cmd = New MySqlCommand("SELECT IDOtrosIngresos,OtrosIngresos.SecondID,Fecha,OtrosIngresos.IDCliente,Clientes.Nombre,OtrosIngresos.Referencia,Monto FROM OtrosIngresos INNER JOIN Clientes on OtrosIngresos.IDCliente=Clientes.IDCliente where IDOtrosIngresos like '%" + txtBuscar.Text + "%' AND OtrosIngresos.Nulo=0 ORDER By IDOtrosIngresos DESC LIMIT 50", Con)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDOtrosIngresos,OtrosIngresos.SecondID,Fecha,OtrosIngresos.IDCliente,Clientes.Nombre,OtrosIngresos.Referencia,Monto FROM OtrosIngresos INNER JOIN Clientes on OtrosIngresos.IDCliente=Clientes.IDCliente where Nombre like '%" + txtBuscar.Text + "%' AND OtrosIngresos.Nulo=0 ORDER By Nombre ASC LIMIT 50", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "OtrosIngresos")

            Bs.DataMember = "OtrosIngresos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvIngresos.DataSource = Bs

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
        With DgvIngresos
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 90
            .Columns(2).Width = 80
            .Columns(3).Width = 70
            .Columns(4).Width = 200
            .Columns(5).Width = 100
            .Columns(6).Width = 110
            .Columns(6).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvIngresos.Focus()
    End Sub

    Private Sub DgvIngresos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvIngresos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvIngresos.Focus()
        End If
    End Sub

    Private Sub DgvIngresos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvIngresos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvIngresos.ColumnCount
                Dim NumRows As Integer = DgvIngresos.RowCount
                Dim CurCell As DataGridViewCell = DgvIngresos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvIngresos.CurrentCell = DgvIngresos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvIngresos.CurrentCell = DgvIngresos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvIngresos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvIngresos.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDIngreso, Nulo As New Label
        IDIngreso.Text = DgvIngresos.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDOtrosIngresos,IDTipoDocumento,IDTransaccion,OtrosIngresos.SecondID,IDUsuario,Fecha,Hora,OtrosIngresos.IDCliente,Clientes.Nombre,Monto,OtrosIngresos.Referencia,OtrosIngresos.Concepto,OtrosIngresos.Nulo,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from Abonos where IDCliente=OtrosIngresos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,Clientes.BalanceGeneral,(LimiteCredito-BalanceGeneral) as CreditoDisponible,OtrosIngresos.Nulo FROM OtrosIngresos INNER JOIN Clientes on OtrosIngresos.IDCliente=Clientes.IDCliente INNER JOIN Calificacion on Clientes.IDCalificacion=CAlificacion.IDCalificacion  Where IDOtrosIngresos= '" + IDIngreso.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Ingreso")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Ingreso")
        If Me.Owner.Name = frm_otros_ingresos.Name Then
            frm_otros_ingresos.txtIDIngreso.Text = (Tabla.Rows(0).Item("IDOtrosIngresos"))
            frm_otros_ingresos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_otros_ingresos.lblIDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
            frm_otros_ingresos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_otros_ingresos.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_otros_ingresos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_otros_ingresos.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_otros_ingresos.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            frm_otros_ingresos.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_otros_ingresos.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
            frm_otros_ingresos.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            frm_otros_ingresos.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
            frm_otros_ingresos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            frm_otros_ingresos.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_otros_ingresos.ChkNulo.Checked = False
            Else
                frm_otros_ingresos.ChkNulo.Checked = True
            End If

        End If

        Close()
        Exit Sub
    End Sub


   
End Class