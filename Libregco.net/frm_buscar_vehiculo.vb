Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_vehiculo

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_vehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
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
                cmd = New MySqlCommand("SELECT IDVehiculo,DatoVehiculo,Placa,Matricula FROM Vehiculo where IDVehiculo like '%" + txtBuscar.Text + "%'", Con)
            ElseIf rdbMarca.Checked = True Then
                cmd = New MySqlCommand("SELECT IDVehiculo,DatoVehiculo,Placa,Matricula FROM Vehiculo where Marca like '%" + txtBuscar.Text + "%'", Con)
            ElseIf rdbPlaca.Checked = True Then
                cmd = New MySqlCommand("SELECT IDVehiculo,DatoVehiculo,Placa,Matricula FROM Vehiculo where Placa like '%" + txtBuscar.Text + "%'", Con)
            ElseIf rdbMatricula.Checked = True Then
                cmd = New MySqlCommand("SELECT IDVehiculo,DatoVehiculo,Placa,Matricula FROM Vehiculo where Matricula like '%" + txtBuscar.Text + "%'", Con)
            End If


            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Vehiculos")

            Bs.DataMember = "Vehiculos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvVehiculo.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbMarca.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvVehiculo
            .Columns(0).HeaderText = "Código"
            .Columns(1).Width = 380
            .Columns(1).HeaderText = "Vehículo"
            .Columns(2).Width = 150
            .Columns(3).Visible = False
        End With
    End Sub


    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
      RefrescarTabla()
        txtBuscar.Focus()
    End Sub


    Private Sub rdbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMarca.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbPlaca_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPlaca.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbMatricula_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMatricula.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvVehiculo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvVehiculo.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvVehiculo.Focus()
    End Sub

    Private Sub DgvVehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvVehiculo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvVehiculo.Focus()
        End If
    End Sub

    Private Sub frm_buscar_vehiculo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LimpiartxtBuscar()
    End Sub


    Private Sub DgvVehiculo_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvVehiculo.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvVehiculo.ColumnCount
                Dim NumRows As Integer = DgvVehiculo.RowCount
                Dim CurCell As DataGridViewCell = DgvVehiculo.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvVehiculo.CurrentCell = DgvVehiculo.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvVehiculo.CurrentCell = DgvVehiculo.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblVehiculo As New Label
            lblVehiculo.Text = DgvVehiculo.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDVehiculo,Vehiculo.IDColor,Color.Color,Marca,Vehiculo.IDTipoVehiculo,TipoVehiculo.tipoVehiculo,Modelo,Año,DatoVehiculo,Placa,Matricula,RutaMatricula,Desactivar from" & SysName.Text & "Vehiculo INNER JOIN Libregco.TipoVehiculo on Vehiculo.IDTipoVehiculo=TipoVehiculo.IDTipoVehiculo INNER JOIN Libregco.Color on Vehiculo.IDColor=Color.IDColor where IDVehiculo='" + lblVehiculo.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Vehiculo")
            ConMixta.Close()

            Dim Tabla As DataTable= Ds1.Tables("Vehiculo")

            If Me.Owner.Name = frm_mant_vehiculos.Name Then
                frm_mant_vehiculos.txtIDVehiculo.Text = (Tabla.Rows(0).Item("IDVehiculo"))
                frm_mant_vehiculos.txtMarca.Text = (Tabla.Rows(0).Item("Marca"))
                frm_mant_vehiculos.txtPlaca.Text = (Tabla.Rows(0).Item("Placa"))
                frm_mant_vehiculos.txtMatricula.Text = (Tabla.Rows(0).Item("Matricula"))
                frm_mant_vehiculos.txtRuta.Text = (Tabla.Rows(0).Item("RutaMatricula"))
                frm_mant_vehiculos.lblIDColor.Text = (Tabla.Rows(0).Item("IDColor"))
                frm_mant_vehiculos.lblIDTipoVehiculo.Text = (Tabla.Rows(0).Item("IDTipoVehiculo"))
                frm_mant_vehiculos.txtModelo.Text = (Tabla.Rows(0).Item("Modelo"))
                frm_mant_vehiculos.NupAño.Text = (Tabla.Rows(0).Item("Año"))
                frm_mant_vehiculos.cbxColor.Text = (Tabla.Rows(0).Item("Color"))
                frm_mant_vehiculos.cbxTipoVehiculo.Text = (Tabla.Rows(0).Item("TipoVehiculo"))

                If (Tabla.Rows(0).Item("Desactivar")) = 0 Then
                    frm_mant_vehiculos.chkDesactivar.Checked = False
                Else
                    frm_mant_vehiculos.chkDesactivar.Checked = True
                End If

                If frm_mant_vehiculos.txtRuta.Text <> "" Then
                    Dim ExistFile As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & frm_mant_vehiculos.txtRuta.Text)
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(frm_mant_vehiculos.txtRuta.Text, FileMode.Open, FileAccess.Read)
                        frm_mant_vehiculos.PicMatricula.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        frm_mant_vehiculos.txtRuta.Text = ""
                    End If
                End If

            End If
            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

End Class