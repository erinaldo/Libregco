Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_progreso_solicitud

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_progreso_solicitud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDProgreso,ProgresoSolicitud.SecondID as SecondIDProg,ProgresoSolicitud.Fecha,MemosClientes.SecondID as SecondIDMemo,MemosClientes.IDCliente,Clientes.Nombre FROM progresosolicitud INNER JOIN MemosClientes on ProgresoSolicitud.IDSolicitud=MemosClientes.IDMemoC INNER JOIN Clientes on MemosClientes.IDCliente=Clientes.IDCliente where ProgresoSolicitud.SecondID like '%" + txtBuscar.Text + "%' Order by ProgresoSolicitud.SecondID DESC", Con)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDProgreso,ProgresoSolicitud.SecondID as SecondIDProg,ProgresoSolicitud.Fecha,MemosClientes.SecondID as SecondIDMemo,MemosClientes.IDCliente,Clientes.Nombre FROM progresosolicitud INNER JOIN MemosClientes on ProgresoSolicitud.IDSolicitud=MemosClientes.IDMemoC INNER JOIN Clientes on MemosClientes.IDCliente=Clientes.IDCliente where ProgresoSolicitud.Descripcion like '%" + txtBuscar.Text + "%' Order by ProgresoSolicitud.SecondID DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Progreso")

            Bs.DataMember = "Progreso"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvProgresos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvProgresos
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = 80
            .Columns(3).Width = 100
            .Columns(3).HeaderText = "Solicitud"
            .Columns(4).Width = 70
            .Columns(4).HeaderText = "ID"
            .Columns(5).Width = 270
            .Columns(5).HeaderText = "Cliente"
        End With
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvProgresos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvProgresos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvProgresos.Focus()
    End Sub

    Private Sub DgvProgresos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvProgresos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvProgresos.Focus()
        End If
    End Sub

    Private Sub DgvProgresos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvProgresos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvProgresos.ColumnCount
                Dim NumRows As Integer = DgvProgresos.RowCount
                Dim CurCell As DataGridViewCell = DgvProgresos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvProgresos.CurrentCell = DgvProgresos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvProgresos.CurrentCell = DgvProgresos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDProgreso As New Label
            lblIDProgreso.Text = DgvProgresos.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDProgreso,ProgresoSolicitud.SecondID AS SecondIDProgreso,ProgresoSolicitud.Fecha as FechaProgreso,ProgresoSolicitud.Hora as HoraProgreso,Descripcion,ProgresoSolicitud.Adjunto,IDMemoC,MemosClientes.SecondID as SecondIDSolicitud,MemosClientes.Fecha as FechaSolicitud,Clientes.IDCliente,Clientes.Nombre as NombreCliente,Clientes.Direccion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,MemosClientes.IDTipoMemo,TiposMemos.Clase,MemosClientes.IDPrioridad,Prioridad.Prioridad,Comentario,FechaLimite,ProgresoSolicitud.Nulo FROM ProgresoSolicitud INNER JOIN MemosClientes on ProgresoSolicitud.IDSolicitud=MemosClientes.IDMemoC INNER JOIN Clientes on MemosClientes.IDCliente=Clientes.IDCliente INNER JOIN Prioridad on MemosClientes.IDPrioridad=Prioridad.IDPrioridad INNER JOIN TiposMemos on MemosClientes.IDTipoMemo=TiposMemos.IDTiposMemos Where IDProgreso='" + lblIDProgreso.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Progresos")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Progresos")

            If Me.Owner.Name = frm_progreso_solicitudes.Name Then
                frm_progreso_solicitudes.txtIDProgreso.Text = (Tabla.Rows(0).Item("IDProgreso"))
                frm_progreso_solicitudes.txtSecondID.Text = (Tabla.Rows(0).Item("SecondIDProgreso"))
                frm_progreso_solicitudes.txtFecha.Text = CDate(Tabla.Rows(0).Item("FechaProgreso")).ToString("yyyy-MM-dd")
                frm_progreso_solicitudes.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("HoraProgreso"))
                frm_progreso_solicitudes.txtDescripcionProgreso.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_progreso_solicitudes.RutaDocumento.Text = (Tabla.Rows(0).Item("Adjunto"))
                frm_progreso_solicitudes.lblIDSolicitud.Text = (Tabla.Rows(0).Item("IDMemoC"))
                frm_progreso_solicitudes.txtSolicitud.Text = (Tabla.Rows(0).Item("SecondIDSolicitud"))
                frm_progreso_solicitudes.lblNombre.Text = "[" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("NombreCliente"))
                frm_progreso_solicitudes.lblDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
                frm_progreso_solicitudes.lblTelefono.Text = (Tabla.Rows(0).Item("TelefonoPersonal"))

                If (Tabla.Rows(0).Item("TelefonoHogar")) = "" Then
                Else
                    frm_progreso_solicitudes.lblTelefono.Text = frm_progreso_solicitudes.lblTelefono.Text & ", " & (Tabla.Rows(0).Item("TelefonoHogar"))
                End If

                frm_progreso_solicitudes.lblTipoSolicitud.Text = "[" & (Tabla.Rows(0).Item("IDTipoMemo")) & "] " & (Tabla.Rows(0).Item("Clase"))
                frm_progreso_solicitudes.lblFechaSolicitud.Text = (Tabla.Rows(0).Item("FechaSolicitud"))
                frm_progreso_solicitudes.lblVencimiento.Text = (Tabla.Rows(0).Item("FechaLimite"))
                frm_progreso_solicitudes.lblPrioridad.Text = (Tabla.Rows(0).Item("Prioridad"))
                frm_progreso_solicitudes.txtDescripcionSolicitud.Text = (Tabla.Rows(0).Item("Comentario"))

                frm_progreso_solicitudes.btn_BuscarSolicitud.Enabled = False
                frm_progreso_solicitudes.txtSolicitud.Enabled = False

                If (Tabla.Rows(0).Item("Adjunto")) = "" Then
                Else
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream((Tabla.Rows(0).Item("Adjunto")), FileMode.Open, FileAccess.Read)
                    frm_progreso_solicitudes.RutaDocumento.Text = (Tabla.Rows(0).Item("Adjunto"))
                    frm_progreso_solicitudes.PicDoc.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_progreso_solicitudes.chkNulo.Checked = True
                Else
                    frm_progreso_solicitudes.chkNulo.Checked = False
                End If
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class