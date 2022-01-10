Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_acuerdos_pagos
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_acuerdos_pagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDAcuerdoPago,SecondID,Fecha,Nombre,FechaPago,Monto FROM acuerdospago INNER JOIN Clientes on AcuerdosPago.IDCliente=Clientes.IDCliente where IDAcuerdoPago like '%" + txtBuscar.Text + "%' and AcuerdosPago.Nulo=0 ORDER BY IDAcuerdoPago DESC", Con)
            ElseIf rdbNota.Checked = True Then
                cmd = New MySqlCommand("SELECT IDAcuerdoPago,SecondID,Fecha,Nombre,FechaPago,Monto FROM acuerdospago INNER JOIN Clientes on AcuerdosPago.IDCliente=Clientes.IDCliente where Nota like '%" + txtBuscar.Text + "%' and AcuerdosPago.Nulo=0 ORDER BY IDAcuerdoPago DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Acuerdos")

            Bs.DataMember = "Acuerdos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvAcuerdos.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvAcuerdos
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 90
            .Columns(2).Width = 90
            .Columns(2).HeaderText = "Emisión"
            .Columns(3).Width = 245
            .Columns(3).HeaderText = "Nombre Cliente"
            .Columns(4).Width = 95
            .Columns(4).HeaderText = "Fecha Pago"
            .Columns(5).Width = 110
            .Columns(5).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbNota_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNota.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvAcuerdos.Focus()
    End Sub

    Private Sub DgvOrdenCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvAcuerdos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvAcuerdos.Focus()
        End If
    End Sub

    Private Sub DgvOrdenCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvAcuerdos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvAcuerdos.ColumnCount
                Dim NumRows As Integer = DgvAcuerdos.RowCount
                Dim CurCell As DataGridViewCell = DgvAcuerdos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvAcuerdos.CurrentCell = DgvAcuerdos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvAcuerdos.CurrentCell = DgvAcuerdos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvOrdenCompra_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAcuerdos.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDAcuerdo, Nulo As New Label
        IDAcuerdo.Text = DgvAcuerdos.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAcuerdoPago,SecondID,IDUsuario,Usuarios.Nombre as NombreUsuario,AcuerdosPago.IDSucursal,Sucursal.Sucursal,AcuerdosPago.IDAlmacen,Almacen.Almacen,Fecha,Hora,AcuerdosPago.IDCliente,Clientes.Nombre AS NombreCliente,Clientes.BalanceGeneral,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,IDGeneroDeudor,GeneroDeudor.Genero as GeneroDeudor,TratamientoDeudor,Deudor,DomicilioDeudor,IDIdentificacionDeudor,TipoIdentificacionDeudor.Descripcion as TipoIdentificacionDeudor,IdentificacionDEudor,NacionalidadDeudor,EstadoCivilDeudor,ProfesionDeudor,MunicipioDeudor,ProvinciaDeudor,IDGeneroAcreedor,GeneroAcreedor.Genero as GeneroAcreedor,TratamientoAcreedor,Acreedor,DomicilioAcreedor,IDTipoIdentificacionAcreedor,TipoIdentificacionAcreedor.Descripcion as TipoIdentificacionAcreedor,IdentificacionAcreedor,NacionalidadAcreedor,EstadoCivilAcreedor,ProfesionAcreedor,MunicipioAcreedor,ProvinciaAcreedor,FechaPago,Vencimiento,CiudadAcuerdo,IDGeneroNotario,GeneroNotario.Genero as GeneroNotario,Notario,NoRegistroNotario,DomicilioNotario,IDTipoIdentificacionNotario,TipoIdentificacionNotario.Descripcion as TipoIdentificacionNotario,IdentificacionNotario,NacionalidadNOtario,MunicipioNotario,ProvinciaNotario,Monto,CantidadCuotas,MontoCuotas,DiasPago,Interes,Testigo1,TipoIdentificacionTestigo1.Descripcion AS TipoIdentificacionTestigo1,IdentificacionTestigo1,DomicilioTestigo1,NacionalidadTestigo1,Testigo2,TipoIdentificacionTestigo2.Descripcion as TipoIdentificacionTestigo2,IdentificacionTestigo2,DomicilioTestigo2,NacionalidadTestigo2,AcuerdosPago.Nota,AcuerdosPago.Status,AcuerdosPago.Impreso,AcuerdosPago.Nulo FROM acuerdospago INNER JOIN Genero as GeneroDeudor on AcuerdosPago.IDGeneroDeudor=GeneroDeudor.IDGenero INNER JOIN Genero as GeneroAcreedor on AcuerdosPago.IDGeneroAcreedor=GeneroAcreedor.IDGenero INNER JOIN Genero as GeneroNotario on AcuerdosPago.IDGeneroNotario=GeneroNotario.IDGenero INNER JOIN TipoIdentificacion as TipoIdentificacionDeudor on AcuerdosPago.IDIdentificacionDeudor=TipoIdentificacionDeudor.IDTipoIdentificacion INNER JOIN TipoIdentificacion as TipoIdentificacionAcreedor on AcuerdosPago.IDTipoIdentificacionAcreedor=TipoIdentificacionAcreedor.IDTipoIdentificacion INNER JOIN TipoIdentificacion as TipoIdentificacionNotario on AcuerdosPago.IDTipoIdentificacionNotario=TipoIdentificacionNotario.IDTipoIdentificacion INNER JOIN TipoIdentificacion as TipoIdentificacionTestigo1 on AcuerdosPago.IDTipoIdentificacionTestigo1=TipoIdentificacionTestigo1.IDTipoIdentificacion INNER JOIN TipoIdentificacion as TipoIdentificacionTestigo2 on AcuerdosPago.IDTipoIdentificacionTestigo2=TipoIdentificacionTestigo2.IDTipoIdentificacion INNER JOIN Empleados as Usuarios on AcuerdosPago.IDUsuario=Usuarios.IDEmpleado INNER JOIN Sucursal on AcuerdosPago.IDSucursal=Sucursal.IDSucursal INNER JOIN Almacen on AcuerdosPago.IDAlmacen=Almacen.IDAlmacen INNER JOIN Clientes on AcuerdosPago.IDCliente=Clientes.IDCliente INNER JOIN Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion Where IDAcuerdoPago = '" + IDAcuerdo.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "AcuerdoPago")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("AcuerdoPago")

        If Me.Owner.Name = frm_acuerdos_pago.Name Then
            frm_acuerdos_pago.txtIDAcuerdo.Text = (Tabla.Rows(0).Item("IDAcuerdoPago"))
            frm_acuerdos_pago.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_acuerdos_pago.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_acuerdos_pago.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_acuerdos_pago.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_acuerdos_pago.txtNombre.Text = (Tabla.Rows(0).Item("NombreCliente"))
            frm_acuerdos_pago.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            frm_acuerdos_pago.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_acuerdos_pago.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

            frm_acuerdos_pago.cbxGeneroDeudor.Text = (Tabla.Rows(0).Item("GeneroDeudor"))
            frm_acuerdos_pago.txtTratamientoDeudor.Text = (Tabla.Rows(0).Item("TratamientoDeudor"))
            frm_acuerdos_pago.txtDeudor.Text = (Tabla.Rows(0).Item("Deudor"))
            frm_acuerdos_pago.txtDomicilioDeudor.Text = (Tabla.Rows(0).Item("DomicilioDeudor"))
            frm_acuerdos_pago.cbxIdentificacionDeudor.Text = (Tabla.Rows(0).Item("TipoIdentificacionDeudor"))
            frm_acuerdos_pago.txtIdentificacionDeudor.Text = (Tabla.Rows(0).Item("IdentificacionDeudor"))
            frm_acuerdos_pago.txtNacionalidadDeudor.Text = (Tabla.Rows(0).Item("NacionalidadDeudor"))
            frm_acuerdos_pago.txtOcupacionDeudor.Text = (Tabla.Rows(0).Item("ProfesionDeudor"))
            frm_acuerdos_pago.txtMunicipioDeudor.Text = (Tabla.Rows(0).Item("MunicipioDeudor"))
            frm_acuerdos_pago.txtEstadoCivilDeudor.Text = (Tabla.Rows(0).Item("EstadoCivilDeudor"))
            frm_acuerdos_pago.txtProvinciaDeudor.Text = (Tabla.Rows(0).Item("ProvinciaDeudor"))

            frm_acuerdos_pago.cbxGeneroAcreedor.Text = (Tabla.Rows(0).Item("GeneroAcreedor"))
            frm_acuerdos_pago.txtTratamientoAcreedor.Text = (Tabla.Rows(0).Item("TratamientoAcreedor"))
            frm_acuerdos_pago.txtAcreedor.Text = (Tabla.Rows(0).Item("Acreedor"))
            frm_acuerdos_pago.txtDomicilioAcreedor.Text = (Tabla.Rows(0).Item("DomicilioAcreedor"))
            frm_acuerdos_pago.cbxIdentificacionAcreedor.Text = (Tabla.Rows(0).Item("TipoIdentificacionAcreedor"))
            frm_acuerdos_pago.txtIdentificacionAcreedor.Text = (Tabla.Rows(0).Item("IdentificacionAcreedor"))
            frm_acuerdos_pago.txtNacionalidadAcreedor.Text = (Tabla.Rows(0).Item("NacionalidadAcreedor"))
            frm_acuerdos_pago.txtOcupacionAcreedor.Text = (Tabla.Rows(0).Item("ProfesionAcreedor"))
            frm_acuerdos_pago.txtMunicipioAcreedor.Text = (Tabla.Rows(0).Item("MunicipioAcreedor"))
            frm_acuerdos_pago.txtProvinciaAcreedor.Text = (Tabla.Rows(0).Item("ProvinciaAcreedor"))
            frm_acuerdos_pago.txtEstadoCivilAcreedor.Text = (Tabla.Rows(0).Item("EstadoCivilAcreedor"))

            frm_acuerdos_pago.DtpFecha.Text = CDate(Tabla.Rows(0).Item("FechaPago")).ToString("yyyy-MM-dd")
            frm_acuerdos_pago.dtpVencimiento.Text = CDate(Tabla.Rows(0).Item("Vencimiento")).ToString("yyyy-MM-dd")
            frm_acuerdos_pago.txtCiudadAcuerdo.Text = (Tabla.Rows(0).Item("CiudadAcuerdo"))
            frm_acuerdos_pago.cbxGeneroNotario.Text = (Tabla.Rows(0).Item("GeneroNotario"))
            frm_acuerdos_pago.txtNotario.Text = (Tabla.Rows(0).Item("Notario"))
            frm_acuerdos_pago.txtNoRegistroNotario.Text = (Tabla.Rows(0).Item("NoRegistroNotario"))
            frm_acuerdos_pago.txtDomicilioNotario.Text = (Tabla.Rows(0).Item("DomicilioNotario"))
            frm_acuerdos_pago.cbxTipoIdentNotario.Text = (Tabla.Rows(0).Item("TipoIdentificacionNotario"))
            frm_acuerdos_pago.txtIdentificacionNotario.Text = (Tabla.Rows(0).Item("IdentificacionNotario"))
            frm_acuerdos_pago.txtNacionalidadNotario.Text = (Tabla.Rows(0).Item("NacionalidadNotario"))
            frm_acuerdos_pago.txtMunicipioAcuerdo.Text = (Tabla.Rows(0).Item("MunicipioNotario"))
            frm_acuerdos_pago.txtProvinciaAcuerdo.Text = (Tabla.Rows(0).Item("ProvinciaNotario"))

            frm_acuerdos_pago.txtDeuda.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
            frm_acuerdos_pago.txtCantidadCuotas.Text = (Tabla.Rows(0).Item("CantidadCuotas"))
            frm_acuerdos_pago.txtMontoCuotas.Text = CDbl(Tabla.Rows(0).Item("MontoCuotas")).ToString("C")
            frm_acuerdos_pago.txtDiasPago.Value = (Tabla.Rows(0).Item("DiasPago"))
            frm_acuerdos_pago.txtInteres.Text = CDbl(Tabla.Rows(0).Item("Interes")).ToString("P2")

            frm_acuerdos_pago.txtTestigo1.Text = (Tabla.Rows(0).Item("Testigo1"))
            frm_acuerdos_pago.cbxIdentificacionTestigo1.Text = (Tabla.Rows(0).Item("TipoIdentificacionTestigo1"))
            frm_acuerdos_pago.txtIdentificacionTestigo1.Text = (Tabla.Rows(0).Item("IdentificacionTestigo1"))
            frm_acuerdos_pago.txtDomicilioTestigo1.Text = (Tabla.Rows(0).Item("DomicilioTestigo1"))
            frm_acuerdos_pago.txtNacionalidadTestigo1.Text = (Tabla.Rows(0).Item("NacionalidadTestigo1"))

            frm_acuerdos_pago.txtTestigo2.Text = (Tabla.Rows(0).Item("Testigo2"))
            frm_acuerdos_pago.cbxIdentificacionTestigo2.Text = (Tabla.Rows(0).Item("TipoIdentificacionTestigo2"))
            frm_acuerdos_pago.txtIdentificacionTestigo2.Text = (Tabla.Rows(0).Item("IdentificacionTestigo2"))
            frm_acuerdos_pago.txtDomicilioTestigo2.Text = (Tabla.Rows(0).Item("DomicilioTestigo2"))
            frm_acuerdos_pago.txtNacionalidadTestigo2.Text = (Tabla.Rows(0).Item("NacionalidadTestigo2"))

            frm_acuerdos_pago.txtNotaAcuerdo.Text = (Tabla.Rows(0).Item("Nota"))
            frm_acuerdos_pago.lblStatus.Text = (Tabla.Rows(0).Item("Status"))
            frm_acuerdos_pago.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_acuerdos_pago.ChkNulo.Checked = False
            Else
                frm_acuerdos_pago.ChkNulo.Checked = True
            End If
            If (Tabla.Rows(0).Item("Status")) = 0 Then
                frm_acuerdos_pago.rdbAbierto.Checked = True
            Else
                frm_acuerdos_pago.rdbCerrado.Checked = True
            End If
            frm_acuerdos_pago.DtpFecha.Text = CDate(Tabla.Rows(0).Item("FechaPago")).ToString("yyyy-MM-dd")

            Close()
            Exit Sub
        End If
    End Sub


End Class