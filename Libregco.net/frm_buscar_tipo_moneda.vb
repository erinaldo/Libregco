Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_moneda

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_buscar_tipo_moneda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
     PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub PropiedadColumnsDgv()
        DgvMonedas.Columns(0).HeaderText = "Código"
        DgvMonedas.Columns(0).Width = 120

        DgvMonedas.Columns(1).Width = 210
        DgvMonedas.Columns(1).HeaderText = "Denominación Moneda"

        DgvMonedas.Columns(2).Width = 155
        DgvMonedas.Columns(2).HeaderText = "Símbolo"
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("Select IDTipoMoneda,Moneda,Signo from TipoMoneda where IDTipoMoneda like '%" + txtBuscar.Text + "%'", ConLibregco)
            ElseIf rdbMoneda.Checked = True Then
                cmd = New MySqlCommand("Select IDTipoMoneda,Moneda,Signo from TipoMoneda where Moneda like '%" + txtBuscar.Text + "%'", ConLibregco)
            ElseIf rdbSimbolo.Checked = True Then
                cmd = New MySqlCommand("Select IDTipoMoneda,Moneda,Signo from TipoMoneda where Signo like '%" + txtBuscar.Text + "%'", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoMoneda")

            Bs.DataMember = "TipoMoneda"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvMonedas.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbSimbolo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSimbolo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbMoneda_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMoneda.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvMonedas.Focus()
    End Sub

    Private Sub DgvMonedas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvMonedas.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvMonedas.ColumnCount
                Dim NumRows As Integer = DgvMonedas.RowCount
                Dim CurCell As DataGridViewCell = DgvMonedas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvMonedas.CurrentCell = DgvMonedas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvMonedas.CurrentCell = DgvMonedas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvMonedas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMonedas.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim lblIDMoneda As New Label
        lblIDMoneda.Text = DgvMonedas.CurrentRow.Cells(0).Value

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select * from TipoMoneda where IDTipoMoneda='" + lblIDMoneda.Text + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoMoneda")
        ConLibregco.Close()

        Dim Tabla As DataTable= Ds.Tables("TipoMoneda")

        If Me.Owner.Name = frm_mant_tipo_moneda.Name Then
            frm_mant_tipo_moneda.Hora.Enabled = False
            frm_mant_tipo_moneda.txtIDMoneda.Text = (Tabla.Rows(0).Item("IDTipoMoneda"))
            frm_mant_tipo_moneda.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_mant_tipo_moneda.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_mant_tipo_moneda.txtNombreMoneda.Text = (Tabla.Rows(0).Item("Moneda"))
            frm_mant_tipo_moneda.txtSignoMonetario.Text = (Tabla.Rows(0).Item("Signo"))
            frm_mant_tipo_moneda.txtTexto.Text = (Tabla.Rows(0).Item("Texto"))
            frm_mant_tipo_moneda.txtTasaCompra.Text = (Tabla.Rows(0).Item("TasaCompra"))
            frm_mant_tipo_moneda.txtTasaVenta.Text = (Tabla.Rows(0).Item("TasaVenta"))
            frm_mant_tipo_moneda.lblChkAnimacion.Text = (Tabla.Rows(0).Item("MostrarAnimacion"))

            If Tabla.Rows(0).Item("MonedaImagen") <> "" Then
                Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("MonedaImagen"))
                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(Tabla.Rows(0).Item("MonedaImagen"), FileMode.Open, FileAccess.Read)
                    frm_mant_tipo_moneda.PicFoto.Image = System.Drawing.Image.FromStream(wFile)
                    frm_mant_tipo_moneda.PicFoto.Tag = Tabla.Rows(0).Item("MonedaImagen")
                    wFile.Close()
                End If
            End If


            If (Tabla.Rows(0).Item("MostrarAnimacion")) = 0 Then
                frm_mant_tipo_moneda.chkAnimacion.Checked = False
            Else
                frm_mant_tipo_moneda.chkAnimacion.Checked = True
            End If
            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_mant_tipo_moneda.chkNulo.Checked = False
            Else
                frm_mant_tipo_moneda.chkNulo.Checked = True
            End If

        ElseIf Me.Owner.Name = frm_registro_cuentasbancarias.Name Then
            frm_registro_cuentasbancarias.txtIDMoneda.Text = (Tabla.Rows(0).Item("IDTipoMoneda"))
            frm_registro_cuentasbancarias.txtMoneda.Text = (Tabla.Rows(0).Item("Moneda"))
        End If

        Close()
        Exit Sub
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub
End Class