Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_abono_prestamo
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_abono_prestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDAbonoPrestamosEmp,AbPrestEmp.SecondID,AbPrestEmp.Fecha,AbPrestEmp.IDEmpleado,Empleados.Nombre,AbPrestEmp.Total FROM abprestemp INNER JOIN Empleados on AbPrestEmp.IDEmpleado=Empleados.IDEmpleado where SecondID like '%" + txtBuscar.Text + "%' ORDER BY IDAbonoPrestamosEmp Desc", Con)
            ElseIf rdbConcepto.Checked = True Then
                cmd = New MySqlCommand("SELECT IDAbonoPrestamosEmp,AbPrestEmp.SecondID,AbPrestEmp.Fecha,AbPrestEmp.IDEmpleado,Empleados.Nombre,AbPrestEmp.Total FROM abprestemp INNER JOIN Empleados on AbPrestEmp.IDEmpleado=Empleados.IDEmpleado where Concepto like '%" + txtBuscar.Text + "%' ORDER BY IDAbonoPrestamosEmp Desc", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "AbonosPrestamos")

            Bs.DataMember = "AbonosPrestamos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvPrestamos.DataSource = Bs

            PropiedadColumnsDvg()
        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbConcepto.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvPrestamos
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).Width = 80
            .Columns(3).Width = 60
            .Columns(3).HeaderText = "ID"
            .Columns(4).HeaderText = "Empleado"
            .Columns(4).Width = 200
            .Columns(5).HeaderText = "Monto"
            .Columns(5).Width = 120
            .Columns(5).DefaultCellStyle.Format = "C"
        End With
    End Sub

    Private Sub rdbConcepto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbConcepto.CheckedChanged
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

    Private Sub DgvPrestamos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrestamos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvPrestamos.Focus()
    End Sub

    Private Sub DgvPrestamos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvPrestamos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvPrestamos.Focus()
        End If
    End Sub

    Private Sub DgvPrestamos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPrestamos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvPrestamos.ColumnCount
                Dim NumRows As Integer = DgvPrestamos.RowCount
                Dim CurCell As DataGridViewCell = DgvPrestamos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvPrestamos.CurrentCell = DgvPrestamos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvPrestamos.CurrentCell = DgvPrestamos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDAbonoPrestamo As New Label
            lblIDAbonoPrestamo.Text = DgvPrestamos.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDAbonoPrestamosEmp,abprestemp.SecondID,abprestemp.IDTipoDocumento,TipoDocumento.Documento,abprestemp.Fecha,abprestemp.Hora,abprestemp.IDUsuario,Usuarios.Nombre as NombreUsuario,abprestemp.IDEmpleado,Empleados.Nombre,Empleados.Cedula,Empleados.Direccion,Empleados.TelefonoPersonal,abprestemp.IDSucursal,Sucursal.Sucursal,abprestemp.IDAlmacen,Almacen.Almacen,abprestemp.IDEquipo,AreaImpresion.ComputerName,Total,abprestemp.BalanceAnterior,abprestemp.Concepto,Referencia,abprestemp.Impreso,abprestemp.Nulo,ifnull((Select Fecha from abprestemp where AbPrestEmp.IDEmpleado=Empleados.IDEmpleado and abprestemp.Nulo=0 ORDER BY IDAbonoPrestamosEmp DESC LIMIT 1),'No Encontrado') AS UltimoFechaPago,ifnull((Select Total from abprestemp where AbPrestEmp.IDEmpleado=Empleados.IDEmpleado and abprestemp.Nulo=0 ORDER BY IDAbonoPrestamosEmp DESC LIMIT 1),0) AS UltimoMontoPago FROM abprestemp INNER JOIN TipoDocumento on abprestemp.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Empleados as Usuarios on abprestemp.IDUsuario=Usuarios.IDEmpleado INNER JOIN Empleados on abprestemp.IDEmpleado=Empleados.IDEmpleado INNER JOIN Sucursal on abprestemp.IDSucursal=Sucursal.IDSucursal INNER JOIN Almacen on abprestemp.IDAlmacen=Almacen.IDAlmacen INNER JOIN AreaImpresion on abprestemp.IDEquipo=AreaImpresion.IDEquipo where IDAbonoPrestamosEmp='" + lblIDAbonoPrestamo.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "AbonoPrestamo")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("AbonoPrestamo")

            If Me.Owner.Name = frm_descontar_prestamos.Name = True Then
                frm_descontar_prestamos.txtIDAbonoPrestamo.Text = (Tabla.Rows(0).Item("IDAbonoPrestamosEmp"))
                frm_descontar_prestamos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_descontar_prestamos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_descontar_prestamos.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_descontar_prestamos.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_descontar_prestamos.txtBalanceEmp.Text = CDbl(Tabla.Rows(0).Item("BalanceAnterior")).ToString("C")
                frm_descontar_prestamos.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
                frm_descontar_prestamos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoFechaPago"))
                frm_descontar_prestamos.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_descontar_prestamos.txtComentario.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_descontar_prestamos.txtMontoAplicar.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_descontar_prestamos.chkNulo.Checked = False
                Else
                    frm_descontar_prestamos.chkNulo.Checked = True
                End If

                frm_descontar_prestamos.FillPagosDetalle()
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class