Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_gestiones_clientes
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet
    Private Sub frm_buscar_gestiones_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT idgestion_clientes,fecha,clientes.nombre,infoadicional FROM libregco.gestion_clientes inner join libregco.clientes on gestion_clientes.idcliente=clientes.idcliente where idgestion_clientes like '%" + txtBuscar.Text + "%' and Gestion_clientes.Nulo=0 ORDER BY idgestion_clientes DESC", Con)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT idgestion_clientes,fecha,clientes.nombre,infoadicional FROM libregco.gestion_clientes inner join libregco.clientes on gestion_clientes.idcliente=clientes.idcliente where infoadicional like '%" + txtBuscar.Text + "%' and Gestion_clientes.Nulo=0 ORDER BY InfoAdicional DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "gestion")

            Bs.DataMember = "gestion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvGestion.DataSource = Bs

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
        With DgvGestion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 90
            .Columns(1).Width = 80
            .Columns(1).HeaderText = "Fecha"
            .Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .Columns(2).Width = 250
            .Columns(2).HeaderText = "Nombre"
            .Columns(3).HeaderText = "Información"
            .Columns(3).Width = 205
            .Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbReferencia.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvGestion.Focus()
    End Sub

    Private Sub DgvGestion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvGestion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvGestion.Focus()
        End If
    End Sub

    Private Sub DgvGestion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvGestion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvGestion.ColumnCount
                Dim NumRows As Integer = DgvGestion.RowCount
                Dim CurCell As DataGridViewCell = DgvGestion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvGestion.CurrentCell = DgvGestion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvGestion.CurrentCell = DgvGestion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvGestion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvGestion.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Try

            Dim IDGestion, Nulo As New Label
            IDGestion.Text = DgvGestion.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IdGestion_Clientes,Gestion_Clientes.IDCliente,Clientes.Nombre,Gestion_Clientes.Fecha,Gestion,Gestion_Clientes.InfoAdicional,Gestion_Clientes.Nulo,Clientes.IDCalificacion,calificacion.Calificacion,Clientes.BalanceGeneral,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto FROM libregco.gestion_clientes INNER JOIN Libregco.Clientes on Gestion_Clientes.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Calificacion.IDCalificacion=Clientes.IDCalificacion INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado Where IDGestion_Clientes= '" + IDGestion.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Gestion")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("Gestion")

            If Me.Owner.Name = frm_gestiones_clientes.Name Then
                frm_gestiones_clientes.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_gestiones_clientes.txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Tabla.Rows(0).Item("Nombre").ToString.ToLower)
                frm_gestiones_clientes.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                frm_gestiones_clientes.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")

                If CDbl(Tabla.Rows(0).Item("BalanceGeneral")) = 0 Then
                    frm_gestiones_clientes.txtBalanceGral.ForeColor = Color.Black
                Else
                    frm_gestiones_clientes.txtBalanceGral.ForeColor = Color.Red
                End If

                frm_gestiones_clientes.txtIDCobradorC.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_gestiones_clientes.txtCobradorC.Text = (Tabla.Rows(0).Item("NombreEmpleado"))

                If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                    frm_gestiones_clientes.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                Else
                    frm_gestiones_clientes.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                End If

                If TypeConnection.Text = 1 Then
                    If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                        MakeRoundedImageToPanel(My.Resources.no_photo, frm_gestiones_clientes.PicCliente)
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                            MakeRoundedImageToPanel(System.Drawing.Image.FromStream(wFile), frm_gestiones_clientes.PicCliente)
                            wFile.Close()

                        Else
                            MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If

                frm_gestiones_clientes.txtIDGestion.Text = Tabla.Rows(0).Item("IDGestion_Clientes")
                frm_gestiones_clientes.Label3.Text = Tabla.Rows(0).Item("Gestion")
                frm_gestiones_clientes.txtInfoAdicional.Text = Tabla.Rows(0).Item("InfoAdicional")

            End If

            Close()
            Exit Sub


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

End Class