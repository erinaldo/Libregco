Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_mant_empleados
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet
    Friend Control As New Label

    Private Sub frm_buscar_mant_empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If chkMostrarInactivos.CheckState = False Then
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,TelefonoPersonal FROM Empleados where IDEmpleado like '%" + txtBuscar.Text + "%' and Empleados.Nulo=0 ORDER BY IDEmpleado ASC", Con)
                ElseIf rdbNombre.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,TelefonoPersonal FROM Empleados where Nombre like '%" + txtBuscar.Text + "%' and Empleados.Nulo=0 ORDER BY Nombre ASC", Con)
                ElseIf rdbCedula.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,TelefonoPersonal FROM Empleados where Cedula like '%" + txtBuscar.Text + "%' and Empleados.Nulo=0 ORDER BY Cedula ASC", Con)
                ElseIf rdbTelefono.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,TelefonoPersonal FROM Empleados where TelefonoPersonal like '%" + txtBuscar.Text + "%' and Empleados.Nulo=0 ORDER BY TelefonoPersonal ASC", Con)
                End If
            Else
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,TelefonoPersonal FROM Empleados where IDEmpleado like '%" + txtBuscar.Text + "%' ORDER BY IDEmpleado ASC", Con)
                ElseIf rdbNombre.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,TelefonoPersonal FROM Empleados where Nombre like '%" + txtBuscar.Text + "%' ORDER BY Nombre ASC", Con)
                ElseIf rdbCedula.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,TelefonoPersonal FROM Empleados where Cedula like '%" + txtBuscar.Text + "%' ORDER BY Cedula ASC", Con)
                ElseIf rdbTelefono.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Cedula,TelefonoPersonal FROM Empleados where TelefonoPersonal like '%" + txtBuscar.Text + "%' ORDER BY TelefonoPersonal ASC", Con)
                End If
            End If


            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")

            Bs.DataMember = "Empleados"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvEmpleados.DataSource = Bs

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

        DgvEmpleados.Columns(0).HeaderText = "Código"
        DgvEmpleados.Columns(0).Width = 80
        DgvEmpleados.Columns(1).Width = 340
        DgvEmpleados.Columns(2).HeaderText = "Cédula"
        DgvEmpleados.Columns(2).Width = 110
        DgvEmpleados.Columns(3).HeaderText = "Teléfono"
        DgvEmpleados.Columns(3).Width = 110
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCedula_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCedula.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbTelefono_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTelefono.CheckedChanged
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

    Private Sub DgvEmpleados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEmpleados.CellClick
        If e.RowIndex >= 0 Then
            If DgvEmpleados.Rows.Count > 0 Then
                LlenarFormularios()
            End If
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvEmpleados.Focus()
    End Sub


    Private Sub LlenarFormularios()
        'Try
        Dim IDEmpleado As New Label
            IDEmpleado.Text = DgvEmpleados.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConMixta.Open()
        cmd = New MySqlCommand("Select IDEmpleado,Nombre,Apodo,Empleados.IDNacionalidad,Nacionalidad.Nacionalidad,Cedula,Empleados.IDGenero,Genero.Genero,FechaNacimiento,Empleados.IDProvincia,Provincias.Provincia,Empleados.IDMunicipio,Municipios.Municipio,Empleados.Direccion,TelefonoPersonal,TelefonoHogar,CorreoElectronico,RutaFoto,Empleados.IDSucursal,Sucursal.Sucursal,Almacen.IDAlmacen,Almacen.Almacen,Empleados.IDTipoNomina,TipoNomina.Descripcion as TipoNomina,Salario,Empleados.IDCargo,CargosEmp.Cargo,Puesto,Empleados.IDPeriodoPago,PeriodoPago.Descripcion as PeriodoPago,Empleados.IDTanda,Tandas.Descripcion as Tandas,Empleados.IDArs,Ars.Descripcion as ARS,Empleados.IDAfp,AFP.Descripcion as Afp,FechaIngreso,Carnet,Cotizable,CuentaBancaria,CuotaPrestamo,CuotaCuenta,ConsumoFlota,IDPrivilegios,Privilegios.Privilegios,RutaCedula,Login,Password,FechaPassword,Empleados.Status,Balance,Alertas,Conectado,HabilitarNomina,CobrarTss,SeguroComplementario,CobrarIsr,Empleados.IDChatStatus,EstatusConversacion.Status as StatusChat,Empleados.ImagenChat,Empleados.Nulo,FactorNumerico,ifnull((Select Fecha from" & SysName.Text & "abprestemp where AbPrestEmp.IDEmpleado=Empleados.IDEmpleado and abprestemp.Nulo=0 ORDER BY IDAbonoPrestamosEmp DESC LIMIT 1),'No Encontrado') AS UltimoFechaPago,ifnull((Select Total from" & SysName.Text & "abprestemp where AbPrestEmp.IDEmpleado=Empleados.IDEmpleado and abprestemp.Nulo=0 ORDER BY IDAbonoPrestamosEmp DESC LIMIT 1),0) AS UltimoMontoPago,VacacionInicia,VacacionTermina,GrayPictureFile,EsVendedor,EsCobrador from" & SysName.Text & "Empleados INNER JOIN Libregco.privilegios on Empleados.IDPrivilegios=Privilegios.IDPrivilegio INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo INNER JOIN Libregco.Provincias on Empleados.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Empleados.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.nacionalidad on Empleados.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.Genero on Empleados.IDGenero=Genero.IDGenero INNER JOIN" & SysName.Text & "Sucursal on Empleados.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on Empleados.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.tiponomina on Empleados.IDTipoNomina=TipoNomina.IDTipoNomina INNER JOIN Libregco.tandas on Empleados.IDTanda=Tandas.IDTanda INNER JOIN Libregco.periodopago on Empleados.IDPeriodoPago=PeriodoPago.IDPeriodoPago INNER JOIN Libregco.Ars on Empleados.IDArs=Ars.IDArs INNER JOIN Libregco.Afp on Empleados.IDAfp=Afp.IDAfp INNER JOIN Libregco.EstatusConversacion on Empleados.IDChatStatus=EstatusConversacion.IDEstatusConversacion Where Empleados.IDEmpleado='" + IDEmpleado.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Empleados")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("Empleados")

        If Me.Owner.Name = frm_mant_empleados.Name Then
            frm_mant_empleados.LimpiarDatosClientes()
            frm_mant_empleados.ActualizarDatos()
            frm_mant_empleados.TabCEmpleados.SelectedIndex = 0
            frm_mant_empleados.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_mant_empleados.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_mant_empleados.txtApodo.Text = (Tabla.Rows(0).Item("Apodo"))
            frm_mant_empleados.txtCedula.Text = (Tabla.Rows(0).Item("Cedula"))
            frm_mant_empleados.txtFechaNacimiento.Text = (Tabla.Rows(0).Item("FechaNacimiento"))
            frm_mant_empleados.dtpFechaIngreso.Value = (Tabla.Rows(0).Item("FechaIngreso"))
            frm_mant_empleados.dtpFechaIngreso.Text = (Tabla.Rows(0).Item("FechaIngreso"))
            frm_mant_empleados.CalcEdad()
            frm_mant_empleados.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
            frm_mant_empleados.txtTelefonoPersonal.Text = (Tabla.Rows(0).Item("TelefonoPersonal"))
            frm_mant_empleados.txtTelefonoHogar.Text = (Tabla.Rows(0).Item("TelefonoHogar"))
            frm_mant_empleados.txtCorreo.Text = (Tabla.Rows(0).Item("CorreoElectronico"))
            frm_mant_empleados.lblRutaFoto.Text = (Tabla.Rows(0).Item("RutaFoto"))
            frm_mant_empleados.CalcTiempoLaboral()
            frm_mant_empleados.txtSalario.Text = CDbl((Tabla.Rows(0).Item("Salario"))).ToString("C")
            frm_mant_empleados.CalcSalarioDiario()
            frm_mant_empleados.txtCuentaBancaria.Text = (Tabla.Rows(0).Item("CuentaBancaria"))
            frm_mant_empleados.txtCuotaPrestamo.Text = CDbl((Tabla.Rows(0).Item("CuotaPrestamo"))).ToString("C")
            frm_mant_empleados.txtConsFlota.Text = CDbl((Tabla.Rows(0).Item("ConsumoFlota"))).ToString("C")
            frm_mant_empleados.txtCuotaCuenta.Text = CDbl((Tabla.Rows(0).Item("CuotaCuenta"))).ToString("C")
            frm_mant_empleados.lblRutaCedula.Text = (Tabla.Rows(0).Item("RutaCedula"))
            frm_mant_empleados.lblChatFoto.Text = (Tabla.Rows(0).Item("ImagenChat"))
            frm_mant_empleados.txtCarnet.Text = (Tabla.Rows(0).Item("Carnet"))
            frm_mant_empleados.txtLogin.Text = (Tabla.Rows(0).Item("Login"))
            frm_mant_empleados.txtPassword.Text = (Tabla.Rows(0).Item("Password"))
            frm_mant_empleados.txtConfirmacionPassword.Text = (Tabla.Rows(0).Item("Password"))
            frm_mant_empleados.lblFechaPassword.Text = (Tabla.Rows(0).Item("FechaPassword"))
            frm_mant_empleados.txtPuesto.Text = (Tabla.Rows(0).Item("Puesto"))
            frm_mant_empleados.lblPrivilegio.Text = (Tabla.Rows(0).Item("IDPrivilegios"))
            frm_mant_empleados.txtIDDepartamento.Text = (Tabla.Rows(0).Item("IDCargo"))
            frm_mant_empleados.txtIDSucursal.Text = (Tabla.Rows(0).Item("IDSucursal"))
            frm_mant_empleados.txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))
            frm_mant_empleados.lblIDAlmacen.Text = (Tabla.Rows(0).Item("IDAlmacen"))
            frm_mant_empleados.lblChkCobrarTss.Text = (Tabla.Rows(0).Item("CobrarTSS"))
            frm_mant_empleados.lblPeriodoPago.Text = (Tabla.Rows(0).Item("IDPeriodoPago"))
            frm_mant_empleados.cbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))
            frm_mant_empleados.txtIDNomina.Text = (Tabla.Rows(0).Item("IDTipoNomina"))
            frm_mant_empleados.txtIDTanda.Text = (Tabla.Rows(0).Item("IDTanda"))
            frm_mant_empleados.lblIDProvincia.Text = (Tabla.Rows(0).Item("IDProvincia"))
            frm_mant_empleados.lblIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
            frm_mant_empleados.lblGenero.Text = (Tabla.Rows(0).Item("IDGenero"))
            frm_mant_empleados.lblNacionalidad.Text = (Tabla.Rows(0).Item("IDNacionalidad"))
            frm_mant_empleados.txtIDArs.Text = (Tabla.Rows(0).Item("IDArs"))
            frm_mant_empleados.txtIDAfp.Text = (Tabla.Rows(0).Item("IDAfp"))
            frm_mant_empleados.CbxGenero.Text = (Tabla.Rows(0).Item("Genero"))
            frm_mant_empleados.cbxNacionalidad.Text = (Tabla.Rows(0).Item("Nacionalidad"))
            frm_mant_empleados.CbxProvincia.Text = (Tabla.Rows(0).Item("Provincia"))
            frm_mant_empleados.cbxMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))
            frm_mant_empleados.CbxPrivilegios.Text = (Tabla.Rows(0).Item("Privilegios"))
            frm_mant_empleados.txtDepartamento.Text = (Tabla.Rows(0).Item("Cargo"))
            frm_mant_empleados.txtTipoNomina.Text = (Tabla.Rows(0).Item("TipoNomina"))
            frm_mant_empleados.txtTanda.Text = (Tabla.Rows(0).Item("Tandas"))
            frm_mant_empleados.CbxPeriodoPago.Text = (Tabla.Rows(0).Item("PeriodoPago"))
            frm_mant_empleados.txtArs.Text = (Tabla.Rows(0).Item("Ars"))
            frm_mant_empleados.txtAfp.Text = (Tabla.Rows(0).Item("Afp"))
            frm_mant_empleados.txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
            frm_mant_empleados.cbxEstadoChat.Text = (Tabla.Rows(0).Item("StatusChat"))
            frm_mant_empleados.lblIDStatusChat.Text = (Tabla.Rows(0).Item("IDChatStatus"))
            frm_mant_empleados.txtCotizable.Text = CDbl(Tabla.Rows(0).Item("Cotizable")).ToString("C")
            frm_mant_empleados.dtpVacacionInicia.Value = CDate(Convert.ToString((Tabla.Rows(0).Item("VacacionInicia"))))
            frm_mant_empleados.dtpVacacionTermina.Value = CDate(Convert.ToString((Tabla.Rows(0).Item("VacacionTermina"))))
            frm_mant_empleados.txtPasswordFactor.Text = Tabla.Rows(0).Item("FactorNumerico")
            frm_mant_empleados.txtPasswordFactorRep.Text = Tabla.Rows(0).Item("FactorNumerico")
            frm_mant_empleados.txtSeguroComplementario.Text = CDbl(Tabla.Rows(0).Item("SeguroComplementario")).ToString("C")
            frm_mant_empleados.lblGrayChatFoto.Text = Tabla.Rows(0).Item("GrayPictureFile")

            If (Tabla.Rows(0).Item("RutaFoto")) <> "" Then
                If TypeConnection.Text = 1 Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream((Tabla.Rows(0).Item("RutaFoto")), FileMode.Open, FileAccess.Read)
                        frm_mant_empleados.PicFoto.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        frm_mant_empleados.ResetPicFoto()
                    End If
                Else
                    frm_mant_empleados.ResetPicFoto()
                End If
            Else
                frm_mant_empleados.ResetPicFoto()
            End If

            If (Tabla.Rows(0).Item("RutaCedula")) <> "" Then
                If TypeConnection.Text = 1 Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaCedula"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream((Tabla.Rows(0).Item("RutaCedula")), FileMode.Open, FileAccess.Read)
                        frm_mant_empleados.PicBCedula.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        frm_mant_empleados.ResetPicCedula()
                    End If
                Else
                    frm_mant_empleados.ResetPicCedula()
                End If
            Else
                frm_mant_empleados.ResetPicCedula()

            End If

            If (Tabla.Rows(0).Item("ImagenChat")) <> "" Then
                If TypeConnection.Text = 1 Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("ImagenChat"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream((Tabla.Rows(0).Item("ImagenChat")), FileMode.Open, FileAccess.Read)
                        frm_mant_empleados.PicChat.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        frm_mant_empleados.PicChat.Image = Nothing
                    End If
                Else
                    frm_mant_empleados.PicChat.Image = Nothing
                End If
            Else
                frm_mant_empleados.PicChat.Image = Nothing
            End If

            If CInt(Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_mant_empleados.chkNulo.Checked = False
            Else
                frm_mant_empleados.chkNulo.Checked = True
            End If

            If CInt(Tabla.Rows(0).Item("Alertas")) = 0 Then
                frm_mant_empleados.ChkAlertas.Checked = False
            Else
                frm_mant_empleados.ChkAlertas.Checked = True
            End If

            If (Tabla.Rows(0).Item("HabilitarNomina")) = 0 Then
                frm_mant_empleados.chkHabNomina.Checked = False
            Else
                frm_mant_empleados.chkHabNomina.Checked = True
            End If

            If (Tabla.Rows(0).Item("CobrarTss")) = 1 Then
                frm_mant_empleados.chkTesoreria.Checked = True
            Else
                frm_mant_empleados.chkTesoreria.Checked = False
            End If

            If (Tabla.Rows(0).Item("CobrarISR")) = 1 Then
                frm_mant_empleados.chkISR.Checked = True
            Else
                frm_mant_empleados.chkISR.Checked = False
            End If

            If (Tabla.Rows(0).Item("EsVendedor")) = 1 Then
                frm_mant_empleados.chkVendedor.Checked = True
            Else
                frm_mant_empleados.chkVendedor.Checked = False
            End If

            If (Tabla.Rows(0).Item("EsCobrador")) = 1 Then
                frm_mant_empleados.chkCobrador.Checked = True
            Else
                frm_mant_empleados.chkCobrador.Checked = False
            End If

            frm_mant_empleados.SelectDeducciones()
            frm_mant_empleados.FillVacaciones()
            frm_mant_empleados.CalcPrest()

        ElseIf Me.Owner.Name = frm_facturacion.name Then
            frm_facturacion.txtCobrador.Tag = Tabla.Rows(0).Item("IDEmpleado")
            frm_facturacion.txtCobrador.Text = Tabla.Rows(0).Item("Nombre")

        ElseIf Me.Owner.Name = frm_reporte_ventas.Name Then
            If Control.Text = 1 Then
                frm_reporte_ventas.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_ventas.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_ventas.txtIDChofer.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_ventas.txtChofer.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_ventas.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_ventas.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 4 Then
                frm_reporte_ventas.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_ventas.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
            If Control.Text = 1 Then
                frm_reporte_devolucion_ventas.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_devolucion_ventas.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_devolucion_ventas.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_devolucion_ventas.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_cargo_pagareses.Name Then
            frm_cargo_pagareses.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_cargo_pagareses.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_registro_factura.Name Then
            frm_consulta_registro_factura.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_registro_factura.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_consulta_registro_factura.VerificarCondicionVendedor()

        ElseIf Me.Owner.Name = frm_consulta_ajuste_inventario.Name Then
            frm_consulta_ajuste_inventario.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_ajuste_inventario.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_cargar_pagare_individual.Name Then
            frm_cargar_pagare_individual.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_cargar_pagare_individual.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_cargar_pagare_individual.HabilitarIntroduccion()

        ElseIf Me.Owner.Name = frm_consulta_conduces.Name Then
            frm_consulta_conduces.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_conduces.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_conteo_cuadre_de_caja.Name Then
            frm_conteo_cuadre_de_caja.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_conteo_cuadre_de_caja.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_conduce_reparacion.Name Then
            frm_reporte_conduce_reparacion.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_conduce_reparacion.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_mant_prestamos_emp.Name Then

            If (Tabla.Rows(0).Item("HabilitarNomina")) = 0 Then
                MessageBox.Show("El empleado [" & (Tabla.Rows(0).Item("IDEmpleado")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " no está habilitado en nómina por lo que no es posible realizar registros de préstamos.", "Empleado no habilitado en nómina", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Close()
                Exit Sub
            ElseIf (Tabla.Rows(0).Item("Nulo")) = 1 Then
                MessageBox.Show("El empleado [" & (Tabla.Rows(0).Item("IDEmpleado")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " está desactivado por lo que no es posible realizar registros de préstamos.", "Empleado desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            frm_mant_prestamos_emp.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_mant_prestamos_emp.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_mant_prestamos_emp.txtCedula.Text = (Tabla.Rows(0).Item("Cedula"))
            frm_mant_prestamos_emp.txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")

        ElseIf Me.Owner.Name = frm_prefacturacion_detalles.Name Then


        ElseIf Me.Owner.Name = frm_descontar_prestamos.Name Then
            frm_descontar_prestamos.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_descontar_prestamos.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_descontar_prestamos.txtBalanceEmp.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
            frm_descontar_prestamos.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
            frm_descontar_prestamos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoFechaPago"))
            frm_descontar_prestamos.RefrescarPrestamosActivos()

        ElseIf Me.Owner.Name = frm_permisos_usuarios.Name Then
            frm_permisos_usuarios.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_permisos_usuarios.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_prestamos_emp.Name Then
            frm_consulta_prestamos_emp.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_prestamos_emp.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_ventas.Name Then
            frm_consulta_ventas.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_ventas.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_pedidos.Name Then
            frm_consulta_pedidos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_pedidos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
            frm_reporte_detalle_ventas.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_detalle_ventas.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_cuadre_de_caja.Name Then
            If Control.Text = 1 Then
                frm_reporte_cuadre_de_caja.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cuadre_de_caja.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_cuadre_de_caja.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cuadre_de_caja.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_consulta_cotizacion.Name Then
            frm_consulta_cotizacion.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_cotizacion.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_cotizacion.Name Then
            If Control.Text = 1 Then
                frm_reporte_cotizacion.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cotizacion.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_cotizacion.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cotizacion.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_cotizacion.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cotizacion.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_compras.Name Then
            If Control.Text = 1 Then
                frm_reporte_compras.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_compras.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_compras.txtIDRecepcion.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_compras.txtRecepcion.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
            If Control.Text = 1 Then
                frm_reporte_detalle_compras.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_detalle_compras.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_detalle_compras.txtIDRecepcion.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_detalle_compras.txtRecepcion.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_devolucion_compras.Name Then
            If Control.Text = 1 Then
                frm_reporte_devolucion_compras.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_devolucion_compras.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_devolucion_compras.txtIDRecepcion.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_devolucion_compras.txtRecepcion.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
            frm_reporte_orden_compra.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_orden_compra.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
            frm_reporte_clientes.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_clientes.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_ajustes_inventario.Name Then
            frm_reporte_ajustes_inventario.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_ajustes_inventario.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_transferencias_inventario.Name Then
            frm_reporte_transferencias_inventario.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_transferencias_inventario.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_conduces.Name Then
            frm_reporte_conduces.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_conduces.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_pedidos.Name Then
            frm_pedidos.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_pedidos.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_notas_pedidos.Name Then
            If Control.Text = 1 Then
                frm_reporte_notas_pedidos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_notas_pedidos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_notas_pedidos.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_notas_pedidos.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_listado_articulos.Name Then
            frm_reporte_listado_articulos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_listado_articulos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
            If Control.Text = 1 Then
                frm_reporte_registro_facturas.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_registro_facturas.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_registro_facturas.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_registro_facturas.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_registro_facturas.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_registro_facturas.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
            If Control.Text = 1 Then
                frm_reporte_nota_debito_credito_cxc.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_nota_debito_credito_cxc.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_nota_debito_credito_cxc.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_nota_debito_credito_cxc.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
            If Control.Text = 1 Then
                frm_reporte_cobros_facturas.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cobros_facturas.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_cobros_facturas.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cobros_facturas.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
            If Control.Text = 1 Then
                frm_reporte_cuentas_por_cobrar.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cuentas_por_cobrar.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_cuentas_por_cobrar.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cuentas_por_cobrar.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_cuentas_por_cobrar.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cuentas_por_cobrar.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_pagares.Name Then
            If Control.Text = 1 Then
                frm_reporte_pagares.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_pagares.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_pagares.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_pagares.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_pagares.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_pagares.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_entradas_reparacion.Name Then
            frm_reporte_entradas_reparacion.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_entradas_reparacion.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_solicitudes_clientes.Name Then
            frm_reporte_solicitudes_clientes.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_solicitudes_clientes.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_otros_ingresos.Name Then
            If Control.Text = 1 Then
                frm_reporte_otros_ingresos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_otros_ingresos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_otros_ingresos.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_otros_ingresos.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_cobros_adelantados.Name Then
            If Control.Text = 1 Then
                frm_reporte_cobros_adelantados.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cobros_adelantados.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_cobros_adelantados.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cobros_adelantados.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_cheques_devueltos.Name Then
            If Control.Text = 1 Then
                frm_reporte_cheques_devueltos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cheques_devueltos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_cheques_devueltos.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cheques_devueltos.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_cheques_futuros.Name Then
            If Control.Text = 1 Then
                frm_reporte_cheques_futuros.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cheques_futuros.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 3 Then
                frm_reporte_cheques_futuros.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cheques_futuros.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_acuerdos_pago.Name Then
            If Control.Text = 1 Then
                frm_reporte_acuerdos_pago.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_acuerdos_pago.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_acuerdos_pago.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_acuerdos_pago.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
            frm_reporte_registro_facturas_cxp.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_registro_facturas_cxp.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
            frm_reporte_cuentas_por_pagar.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_cuentas_por_pagar.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_pagos_facturas.Name Then
            frm_reporte_pagos_facturas.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_pagos_facturas.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_egresos.Name Then
            frm_reporte_egresos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_egresos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_pagos_cxp.Name Then
            frm_consulta_pagos_cxp.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_pagos_cxp.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_pagos_financiamientos.Name Then
            frm_consulta_pagos_financiamientos.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_pagos_financiamientos.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_egresos_cxp.Name Then
            frm_consulta_egresos_cxp.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_egresos_cxp.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
            If frm_reporte_empleados.txtIDEmpleadoDesde.Text = "" Then
                frm_reporte_empleados.txtIDEmpleadoDesde.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            Else
                frm_reporte_empleados.txtIDEmpleadoHasta.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            End If

        ElseIf Me.Owner.Name = frm_registro_ingresos_deducciones.Name Then
            frm_registro_ingresos_deducciones.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_registro_ingresos_deducciones.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_registro_ingresos_deducciones.FillDeducciones()

        ElseIf Me.Owner.Name = frm_reporte_nomina.Name Then
            If Control.Text = 0 Then
                frm_reporte_nomina.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_nomina.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_nomina.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_nomina.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_vacaciones.name Then
            If Control.Text = 0 Then
                frm_reporte_vacaciones.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_vacaciones.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_vacaciones.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_vacaciones.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_financiamientos.name Then
            If Control.Text = 0 Then
                frm_reporte_financiamientos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_financiamientos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_financiamientos.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_financiamientos.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_financiamientos.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_financiamientos.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_cuotas_financiamientos.name Then
            If Control.Text = 0 Then
                frm_reporte_cuotas_financiamientos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cuotas_financiamientos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 2 Then
                frm_reporte_cuotas_financiamientos.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cuotas_financiamientos.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_deducciones.Name Then
            If Control.Text = 0 Then
                frm_reporte_deducciones.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_deducciones.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_deducciones.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_deducciones.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_prestamos_empleados.Name Then
            If Control.Text = 0 Then
                frm_reporte_prestamos_empleados.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_prestamos_empleados.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_prestamos_empleados.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_prestamos_empleados.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_cobros_prestamos.Name Then
            If Control.Text = 0 Then
                frm_reporte_cobros_prestamos.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cobros_prestamos.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_cobros_prestamos.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_cobros_prestamos.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_consulta_prestamos_emp.Name Then
            frm_consulta_prestamos_emp.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_prestamos_emp.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_financiamientos.name Then
            frm_consulta_financiamientos.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_financiamientos.txtVendedor.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_empleados_vacaciones.Name Then

            If TypeConnection.Text = 1 Then
                If IsDBNull(Tabla.Rows(0).Item("RutaFoto")) Then
                    MakeRoundedImageToPanel(My.Resources.no_photo, frm_empleados_vacaciones.PicCliente)
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        MakeRoundedImageToPanel(System.Drawing.Image.FromStream(wFile), frm_empleados_vacaciones.PicCliente)
                        wFile.Close()
                    Else

                        MakeRoundedImageToPanel(My.Resources.no_photo, frm_empleados_vacaciones.PicCliente)
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("RutaFoto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If


            frm_empleados_vacaciones.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_empleados_vacaciones.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_empleados_vacaciones.lblFechaIngreso.Text = CDate(Tabla.Rows(0).Item("FechaIngreso"))
            frm_empleados_vacaciones.lblSalario.Text = CDbl(Tabla.Rows(0).Item("Salario")).ToString("C")
            frm_empleados_vacaciones.FillVacaciones()
            frm_empleados_vacaciones.Button1.PerformClick()

        ElseIf Me.Owner.Name = frm_reporte_movimientos_bancarios.Name Then
            frm_reporte_movimientos_bancarios.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_movimientos_bancarios.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_cheques.Name Then
            frm_reporte_cheques.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_cheques.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_solicitud_cheques.Name Then
            frm_reporte_solicitud_cheques.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_reporte_solicitud_cheques.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_traspasar_pagare.Name Then
            If Control.Text = 1 Then
                frm_traspasar_pagare.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_traspasar_pagare.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_traspasar_pagare.LeerPagares()
                frm_traspasar_pagare.HabilitarIntroduccion()
            Else
                frm_traspasar_pagare.txtIDCobradorTransferir.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_traspasar_pagare.txtCobradorTransferir.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_restablecer_pagare.Name Then
            frm_restablecer_pagare.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_restablecer_pagare.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_restablecer_pagare.HabilitarIntroduccion()

        ElseIf Me.Owner.Name = frm_grupo_cierre_recibos.Name Then
            frm_grupo_cierre_recibos.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_grupo_cierre_recibos.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_reporte_recibos_cobros.Name Then
            If Control.Text = 0 Then
                frm_reporte_recibos_cobros.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_recibos_cobros.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_recibos_cobros.txtIDRecepcion.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_recibos_cobros.txtRecepcion.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_talonarios.Name Then
            If Control.Text = 0 Then
                frm_reporte_talonarios.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_talonarios.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_talonarios.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_talonarios.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_entrega_cobros.Name Then
            If Control.Text = 0 Then
                frm_reporte_entrega_cobros.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_entrega_cobros.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_entrega_cobros.txtIDRecepcion.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_entrega_cobros.txtRecepcion.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_titulaciones.Name Then
            If Control.Text = 0 Then
                frm_reporte_titulaciones.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_titulaciones.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_reporte_titulaciones.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_titulaciones.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_reporte_listado_cobros.Name Then
            If Control.Text = 0 Then
                frm_reporte_listado_cobros.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_listado_cobros.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            Else
                frm_reporte_listado_cobros.txtIDSubCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_reporte_listado_cobros.txtSubCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            End If


        ElseIf Me.Owner.Name = frm_consulta_talonarios_cobros.Name Then
            If Control.Text = 0 Then
                frm_consulta_talonarios_cobros.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_consulta_talonarios_cobros.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_consulta_talonarios_cobros.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_consulta_talonarios_cobros.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_contraseña_empleado.name Then
            frm_contraseña_empleado.txtUsuario.Tag = Tabla.Rows(0).Item("IDEmpleado")
            frm_contraseña_empleado.txtUsuario.Text = Tabla.Rows(0).Item("Nombre")



            If Tabla.Rows(0).Item("RutaFoto") <> "" Then
                If System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto")) Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                    frm_contraseña_empleado.PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                Else
                    If Tabla.Rows(0).Item("ImagenChat") <> "" Then
                        If System.IO.File.Exists(Tabla.Rows(0).Item("ImagenChat")) Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("ImagenChat"), FileMode.Open, FileAccess.Read)
                            frm_contraseña_empleado.PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                        End If
                    Else
                        frm_contraseña_empleado.PictureBox1.Image = My.Resources.no_photo
                    End If
                End If
            Else
                If Tabla.Rows(0).Item("ImagenChat") <> "" Then
                    If System.IO.File.Exists(Tabla.Rows(0).Item("ImagenChat")) Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("ImagenChat"), FileMode.Open, FileAccess.Read)
                        frm_contraseña_empleado.PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                    End If
                Else
                    frm_contraseña_empleado.PictureBox1.Image = My.Resources.no_photo
                End If
            End If


        ElseIf Me.Owner.Name = frm_consulta_entrega_cobros.Name Then
            If Control.Text = 0 Then
                frm_consulta_entrega_cobros.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_consulta_entrega_cobros.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_consulta_entrega_cobros.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_consulta_entrega_cobros.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_consulta_titulaciones_cobros.Name Then
            frm_consulta_titulaciones_cobros.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_titulaciones_cobros.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))

        ElseIf Me.Owner.Name = frm_consulta_grupos_cierre.Name Then
            If Control.Text = 0 Then
                frm_consulta_grupos_cierre.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_consulta_grupos_cierre.txtCobrador.Text = (Tabla.Rows(0).Item("Nombre"))
            ElseIf Control.Text = 1 Then
                frm_consulta_grupos_cierre.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_consulta_grupos_cierre.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
            End If

        ElseIf Me.Owner.Name = frm_prestaciones_laborales.Name Then
            frm_prestaciones_laborales.lblNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_prestaciones_laborales.lblCedula.Text = (Tabla.Rows(0).Item("Cedula"))
            frm_prestaciones_laborales.lblFechaIngreso.Text = "Laborando desde el: " & (Tabla.Rows(0).Item("FechaIngreso"))
            frm_prestaciones_laborales.dtpFechaIngreso.Value = CDate(Tabla.Rows(0).Item("FechaIngreso"))
            frm_prestaciones_laborales.dtpFechaIngreso.Enabled = False

            If (Tabla.Rows(0).Item("ImagenChat")) <> "" Then
                If TypeConnection.Text = 1 Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("ImagenChat"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream((Tabla.Rows(0).Item("ImagenChat")), FileMode.Open, FileAccess.Read)
                        frm_prestaciones_laborales.PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        frm_prestaciones_laborales.PicImagen.Image = My.Resources.no_photo
                    End If
                Else
                    frm_prestaciones_laborales.PicImagen.Image = My.Resources.no_photo
                End If
            Else
                If (Tabla.Rows(0).Item("RutaFoto")) <> "" Then
                    If TypeConnection.Text = 1 Then
                        Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream((Tabla.Rows(0).Item("RutaFoto")), FileMode.Open, FileAccess.Read)
                            frm_prestaciones_laborales.PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            frm_prestaciones_laborales.PicImagen.Image = My.Resources.no_photo
                        End If
                    Else
                        frm_prestaciones_laborales.PicImagen.Image = My.Resources.no_photo
                    End If
                Else
                    frm_prestaciones_laborales.PicImagen.Image = My.Resources.no_photo
                End If
            End If





            frm_prestaciones_laborales.btnCleanEmpleado.Location = New Point(frm_prestaciones_laborales.lblNombre.Location.X + frm_prestaciones_laborales.lblNombre.Size.Width + frm_prestaciones_laborales.btnCleanEmpleado.Width + 3, frm_prestaciones_laborales.btnCleanEmpleado.Location.Y)
            frm_prestaciones_laborales.btnCleanEmpleado.Visible = True
            frm_prestaciones_laborales.lblNombre.Visible = True
            frm_prestaciones_laborales.lblCedula.Visible = True
            frm_prestaciones_laborales.lblFechaIngreso.Visible = True
            frm_prestaciones_laborales.PicImagen.Visible = True
            frm_prestaciones_laborales.btnBuscarEmpleado.Visible = False

        ElseIf Me.Owner.Name = frm_consulta_cortedecaja.Name Then
            frm_consulta_cortedecaja.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_consulta_cortedecaja.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
        End If

            Close()
            Exit Sub


        'Catch ex As Exception
        '    'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

    End Sub

    Private Sub DgvEmpleados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvEmpleados.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If DgvEmpleados.Rows.Count > 0 Then
                LlenarFormularios()
            End If
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvEmpleados.Focus()
        End If
    End Sub

    Private Sub frm_buscar_clientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LimpiartxtBuscar()
    End Sub

    Private Sub DgvEmpleados_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvEmpleados.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim NumCols As Integer = DgvEmpleados.ColumnCount
            Dim NumRows As Integer = DgvEmpleados.RowCount
            Dim CurCell As DataGridViewCell = DgvEmpleados.CurrentCell
            If CurCell.ColumnIndex = NumCols - 1 Then
                If CurCell.RowIndex < NumRows - 1 Then
                    DgvEmpleados.CurrentCell = DgvEmpleados.Item(0, CurCell.RowIndex + 1)
                End If
            Else
                DgvEmpleados.CurrentCell = DgvEmpleados.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
            End If
            e.Handled = True
        End If

    End Sub

    Private Sub frm_buscar_mant_empleados_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub

    Private Sub chkMostrarInactivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarInactivos.CheckedChanged
        RefrescarTabla()
    End Sub

    Private Sub frm_buscar_mant_empleados_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.F2 Then
            e.Handled = True
            txtBuscar.Focus()
        End If
    End Sub
End Class