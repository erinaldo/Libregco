Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_accesos_rapidos_clientes
    Friend IDCliente As New Label
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim DsNew As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub frm_accesos_rapidos_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(100, Me.Size.Height)
        If Me.Owner.Name = frm_mant_clientes.Name Then
            btnClientes.Enabled = False
            btnFacturacion.Enabled = True
            btnIngresos.Enabled = True
        ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then
            btnClientes.Enabled = True
            btnFacturacion.Enabled = True
            btnIngresos.Enabled = False
        ElseIf Me.Owner.Name = frm_facturacion.Name Then
            btnClientes.Enabled = True
            btnFacturacion.Enabled = False
            btnIngresos.Enabled = True
        End If

        '0 Acceso
        'Mantenimiento de clientes
        Permisos = PasarPermisos(87)
        If Permisos(0) = 0 Then
            btnClientes.Enabled = False
        End If
        Permisos.Clear()

        'Recibos
        Permisos = PasarPermisos(94)
        If Permisos(0) = 0 Then
            btnIngresos.Enabled = False
        End If
        Permisos.Clear()

        'Facturacion
        Permisos = PasarPermisos(15)
        If Permisos(0) = 0 Then
            btnFacturacion.Enabled = False
        End If
        Permisos.Clear()

        CType(Me.Owner, Form).Activate()
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Try
            If Me.Owner.Name = frm_recibo_pagos.Name Then
                If frm_recibo_pagos.txtIDCliente.Text = "" Then
                    MessageBox.Show("No se ha seleccionado un cliente para realizar un acceso rápido en el sistema.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    IDCliente.Text = frm_recibo_pagos.txtIDCliente.Text
                    SearchingFast = True

                    If frm_mant_clientes.Visible = True Then
                        frm_mant_clientes.Close()

                        If frm_mant_clientes.Visible = False Then
                            frm_mant_clientes.Show(frm_inicio)
                        End If

                    Else
                        frm_mant_clientes.Show(frm_inicio)
                    End If
                End If


            ElseIf Me.Owner.Name = frm_facturacion.Name Then
                If frm_facturacion.txtIDCliente.Text = "" Then
                MessageBox.Show("No se ha seleccionado un cliente para realizar un acceso rápido en el sistema.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                IDCliente.Text = frm_facturacion.txtIDCliente.Text
                SearchingFast = True

                If frm_mant_clientes.Visible = True Then
                    frm_mant_clientes.Close()
                        If frm_mant_clientes.Visible = False Then
                            frm_mant_clientes.Show(frm_inicio)
                        End If
                    Else
                    frm_mant_clientes.Show(frm_inicio)
                End If
            End If
        End If

        Dim DsTemp As New DataSet

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDCliente,Clientes.IDTratamiento,Tratamiento.TratamientoAbreviado,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Gentilicio,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.Sueldo,Vivienda,Vehiculo,TrabajoActivo,SeguroMedico,CuentasBancaria,Tarjeta,Clientes.CorreoElectronico,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,UbicacionTrabajo,TelefonoTrabajo,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,ColorCalificacion,CalificacionAutonoma,DiasCondicion,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.IDEmpleadoSub,SubCobrador.Nombre as SubCobrador,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Clientes.IDCondicionCliente,Condicion.Condicion,Precio,InformacionAdc,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,BloqueoCobrador,EntregarPorConduce,BalanceGeneral,NumeroTiempoAlquilado,TiempoAlquilado,TipoVIvienda,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,EntidadBancariaCuenta,EntidadBancariaTarjeta,DedicacionAutoEmpleado,OrigenPagos,xCore,Locacion,CreditoAnterior,ReferenciaComercial1,ReferenciaComercial2,Garante,GaranteNombre,TipoIdentificacionGarante,IdentificacionGarante,DireccionGarante,TelefonoGarante,IDRegistrador,IDUsuarioModificador,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Desactivar,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,ContactoCompras,TelContactoCompras,ExtCompras,ContactoCXC,TelContactoCXC,ExtCXC,Clientes.IDVendedorCliente,Vendedor.Nombre as NombreVendedor FROM Libregco.clientes INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Libregco.Condicion on Clientes.IDCondicionCliente=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as SubCobrador on Clientes.IDEmpleadoSub=SubCobrador.IDEmpleado INNER JOIN Libregco.Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN Libregco.estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Libregco.Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN Libregco.GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN" & SysName.Text & "Empleados as Vendedor on Clientes.IDVendedorCliente=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Tratamiento on Clientes.IDTratamiento=Tratamiento.IDTratamiento Where IDCliente='" + IDCliente.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Clientes")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Clientes")

            frm_mant_clientes.tbcClientes.SelectedIndex = 0
            frm_mant_clientes.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_mant_clientes.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_mant_clientes.txtApodo.Text = (Tabla.Rows(0).Item("Apodo"))
            frm_mant_clientes.cbxTipoIdentificacion.Text = (Tabla.Rows(0).Item("TipoIdentificacion"))
            frm_mant_clientes.cbxTipoIdentificacion.Tag = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
            frm_mant_clientes.txtIdentificacion.Text = (Tabla.Rows(0).Item("Identificacion"))
            frm_mant_clientes.TxtFechaNacimiento.Text = (Tabla.Rows(0).Item("FechaNacimiento"))
            frm_mant_clientes.CalcEdad()
            frm_mant_clientes.txtLugarNacimiento.Text = (Tabla.Rows(0).Item("LugarNacimiento"))
            frm_mant_clientes.cbxGenero.Text = (Tabla.Rows(0).Item("Genero"))
            frm_mant_clientes.CbxTratamiento.Text = (Tabla.Rows(0).Item("TratamientoAbreviado"))
            frm_mant_clientes.cbxNacionalidad.Text = (Tabla.Rows(0).Item("Nacionalidad"))


            frm_mant_clientes.cbxProvincia.Text = (Tabla.Rows(0).Item("Provincia"))
            frm_mant_clientes.cbxMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))
            frm_mant_clientes.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
            frm_mant_clientes.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            frm_mant_clientes.txtTelefonoPer.Text = (Tabla.Rows(0).Item("TelefonoPersonal"))
            frm_mant_clientes.txtTelefonoHog.Text = (Tabla.Rows(0).Item("TelefonoHogar"))
            frm_mant_clientes.txtCorreoElec.Text = (Tabla.Rows(0).Item("CorreoElectronico"))

            If (Tabla.Rows(0).Item("Vehiculo")) = 0 Then
                frm_mant_clientes.rdbVehiculosNo.Checked = True
            ElseIf (Tabla.Rows(0).Item("Vehiculo")) = 1 Then
                frm_mant_clientes.rdbVehiculosSi.Checked = True
            ElseIf (Tabla.Rows(0).Item("Vehiculo")) = 2 Then
                frm_mant_clientes.rdbVehiculoNoINFO.Checked = True
            End If

            If (Tabla.Rows(0).Item("TipoVivienda")) = 0 Then
                frm_mant_clientes.rdbCasa.Checked = True
            ElseIf (Tabla.Rows(0).Item("TipoVivienda")) = 1 Then
                frm_mant_clientes.rdbApartamento.Checked = True
            ElseIf (Tabla.Rows(0).Item("TipoVivienda")) = 2 Then
                frm_mant_clientes.rdbPension.Checked = True
            ElseIf (Tabla.Rows(0).Item("TipoVivienda")) = 3 Then
                frm_mant_clientes.rdbViviendaNoEspecificada.Checked = True
            End If

            If (Tabla.Rows(0).Item("Vivienda")) = 0 Then
                frm_mant_clientes.rdbCasaAlquilada.Checked = True
                frm_mant_clientes.txtTiempoAlquiler.Text = Tabla.Rows(0).Item("NumeroTiempoAlquilado")
                frm_mant_clientes.cbxTiempoAlquier.Text = Tabla.Rows(0).Item("TiempoAlquilado")

            ElseIf (Tabla.Rows(0).Item("Vivienda")) = 1 Then
                frm_mant_clientes.rdbCasaPropia.Checked = True

            ElseIf (Tabla.Rows(0).Item("Vivienda")) = 2 Then
                frm_mant_clientes.rdbCasaNoInfo.Checked = True
            End If

            If (Tabla.Rows(0).Item("CuentasBancaria")) = 0 Then
                frm_mant_clientes.ckhCuentasBancarias.Checked = False
            Else
                frm_mant_clientes.ckhCuentasBancarias.Checked = True
                frm_mant_clientes.txtEntidadCuentaBancaria.Text = Tabla.Rows(0).Item("EntidadBancariaCuenta")
            End If

            If (Tabla.Rows(0).Item("Tarjeta")) = 0 Then
                frm_mant_clientes.chkTarjetasCredito.Checked = False
            Else
                frm_mant_clientes.chkTarjetasCredito.Checked = True
                frm_mant_clientes.txtEntidadTarjeta.Text = Tabla.Rows(0).Item("EntidadBancariaTarjeta")
            End If


            If (Tabla.Rows(0).Item("TrabajoActivo")) = 0 Then
                frm_mant_clientes.rdbNoTrabajo.Checked = True
            ElseIf (Tabla.Rows(0).Item("TrabajoActivo")) = 1 Then
                frm_mant_clientes.rdbSiTrabajoEstablecimiento.Checked = True
            ElseIf (Tabla.Rows(0).Item("TrabajoActivo")) = 2 Then
                frm_mant_clientes.rdbSiTrabajoAuto.Checked = True
            ElseIf (Tabla.Rows(0).Item("TrabajoActivo")) = 3 Then
                frm_mant_clientes.rdbTrabajoNoSuministrado.Checked = True
            End If

            frm_mant_clientes.cbxOcupacion.Text = (Tabla.Rows(0).Item("OcupacionCliente"))
            frm_mant_clientes.txtLugarTrabajo.Text = (Tabla.Rows(0).Item("LugarTrabajo"))
            frm_mant_clientes.txtCantNumLaborando.Text = (Tabla.Rows(0).Item("TrabajoCantTiempoLaborando"))
            frm_mant_clientes.cbxTiempoLaborando.Text = (Tabla.Rows(0).Item("TrabajoTiempoLaborando"))
            frm_mant_clientes.txtUbicacionTrabajo.Text = (Tabla.Rows(0).Item("UbicacionTrabajo"))
            frm_mant_clientes.txtTelefonoTrab.Text = (Tabla.Rows(0).Item("TelefonoTrabajo"))
            frm_mant_clientes.txtOcupacionAutoEmpleado.Text = (Tabla.Rows(0).Item("DedicacionAutoempleado"))
            frm_mant_clientes.txtSueldo.Text = CDbl(Tabla.Rows(0).Item("Sueldo")).ToString("C")
            frm_mant_clientes.txtOrigenPagos.Text = (Tabla.Rows(0).Item("OrigenPagos"))
            If (Tabla.Rows(0).Item("SeguroMedico")) = 0 Then
                frm_mant_clientes.rdbSeguroNo.Checked = True
            Else
                frm_mant_clientes.rdbSeguroSi.Checked = True
            End If

            frm_mant_clientes.txtPadre.Text = (Tabla.Rows(0).Item("PadreCliente"))
            frm_mant_clientes.txtMadre.Text = (Tabla.Rows(0).Item("MadreCliente"))
            frm_mant_clientes.txtDomicilioPat.Text = (Tabla.Rows(0).Item("DomicilioPaternos"))
            frm_mant_clientes.txtTelefonoPat.Text = (Tabla.Rows(0).Item("TelefonoPaternos"))
            frm_mant_clientes.cbxEstadoCivil.Text = (Tabla.Rows(0).Item("EstadoCivil"))
            frm_mant_clientes.txtNombreConyuge.Text = (Tabla.Rows(0).Item("Conyuge"))
            frm_mant_clientes.cbxOcupacionConyuge.Text = (Tabla.Rows(0).Item("OcupacionConyuge"))
            frm_mant_clientes.txtTelefonoConyuge.Text = (Tabla.Rows(0).Item("TelefonoConyuge"))
            frm_mant_clientes.txtLugarTrabajoCony.Text = (Tabla.Rows(0).Item("LugarTrabajoConyuge"))
            frm_mant_clientes.txtPadreConyuge.Text = (Tabla.Rows(0).Item("PadreConyuge"))
            frm_mant_clientes.txtMadreConyuge.Text = (Tabla.Rows(0).Item("MadreConyuge"))
            frm_mant_clientes.txtDomicilioPatCony.Text = (Tabla.Rows(0).Item("DomicilioPatConyuge"))
            frm_mant_clientes.txtTelefonoPatCony.Text = (Tabla.Rows(0).Item("TelefonoPatConyuge"))

            If (Tabla.Rows(0).Item("CreditoAnterior")) = 0 Then
                frm_mant_clientes.rdbCreditoComercialNo.Checked = True
            Else
                frm_mant_clientes.rdbCreditoComercialesSi.Checked = True
            End If
            frm_mant_clientes.txtReferenciaComercial1.Text = (Tabla.Rows(0).Item("ReferenciaComercial1"))
            frm_mant_clientes.txtReferenciaComercial2.Text = (Tabla.Rows(0).Item("ReferenciaComercial2"))

            If (Tabla.Rows(0).Item("Garante")) = 0 Then
                frm_mant_clientes.rdbGaranteNo.Checked = True
            Else
                frm_mant_clientes.rdbGaranteSi.Checked = True
            End If
            frm_mant_clientes.txtNombreGarante.Text = (Tabla.Rows(0).Item("GaranteNombre"))
            frm_mant_clientes.cbxTipoIdentificacionGarante.Text = (Tabla.Rows(0).Item("TipoIdentificacionGarante"))
            frm_mant_clientes.txtIdentificacionGarante.Text = (Tabla.Rows(0).Item("IdentificacionGarante"))
            frm_mant_clientes.txtDireccionGarante.Text = (Tabla.Rows(0).Item("DireccionGarante"))
            frm_mant_clientes.txtTelefonoGarante.Text = (Tabla.Rows(0).Item("TelefonoGarante"))

            frm_mant_clientes.txtIDGrupoCxc.Text = (Tabla.Rows(0).Item("IDGrupoCxc"))
            frm_mant_clientes.txtGrupoCxc.Text = (Tabla.Rows(0).Item("GrupoCxc"))
            frm_mant_clientes.txtIDTipoCredito.Text = (Tabla.Rows(0).Item("IDTipoCredito"))
            frm_mant_clientes.txtTipoCredito.Text = (Tabla.Rows(0).Item("TipoCredito"))
            frm_mant_clientes.txtCondicionDias.Text = (Tabla.Rows(0).Item("DiasCondicion"))
            frm_mant_clientes.cbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
            frm_mant_clientes.cbxCondicion.Tag = Tabla.Rows(0).Item("IDCondicionCliente")
            frm_mant_clientes.cbxCondicion.Text = Tabla.Rows(0).Item("Condicion")
            frm_mant_clientes.txtFechaIngreso.Text = CDate(Tabla.Rows(0).Item("FechaIngreso")).ToString("yyyy-MM-dd")
            frm_mant_clientes.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            frm_mant_clientes.txtAlerta.Text = (Tabla.Rows(0).Item("Alertas"))
            frm_mant_clientes.txtInfoAdicional.Text = (Tabla.Rows(0).Item("InformacionAdc"))

            If frm_mant_clientes.cbxCobrador.Items.Contains(Tabla.Rows(0).Item("NombreEmpleado")) Then
                frm_mant_clientes.cbxCobrador.Text = (Tabla.Rows(0).Item("NombreEmpleado"))
            Else
                frm_mant_clientes.cbxCobrador.Items.Add(Tabla.Rows(0).Item("NombreEmpleado"))
                frm_mant_clientes.cbxCobrador.Text = Tabla.Rows(0).Item("NombreEmpleado")
            End If

            If frm_mant_clientes.cbxSubCobrador.Items.Contains(Tabla.Rows(0).Item("SubCobrador")) Then
                frm_mant_clientes.cbxSubCobrador.Text = (Tabla.Rows(0).Item("SubCobrador"))
            Else
                frm_mant_clientes.cbxSubCobrador.Items.Add(Tabla.Rows(0).Item("SubCobrador"))
                frm_mant_clientes.cbxSubCobrador.Text = Tabla.Rows(0).Item("SubCobrador")
            End If

            If frm_mant_clientes.cbxVendedor.Items.Contains(Tabla.Rows(0).Item("NombreVendedor")) Then
                frm_mant_clientes.cbxVendedor.Text = (Tabla.Rows(0).Item("NombreVendedor"))
            Else
                frm_mant_clientes.cbxVendedor.Items.Add(Tabla.Rows(0).Item("NombreVendedor"))
                frm_mant_clientes.cbxVendedor.Text = Tabla.Rows(0).Item("NombreVendedor")
            End If

            frm_mant_clientes.cbxCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_mant_clientes.ColorCalificacion.BackColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
            frm_mant_clientes.txtCalificacionAutonoma.Text = (Tabla.Rows(0).Item("CalificacionAutonoma"))
            frm_mant_clientes.txtXCore.Text = (Tabla.Rows(0).Item("XCore"))
            frm_mant_clientes.txtEncargadoCompras.Text = Tabla.Rows(0).Item("ContactoCompras")
            frm_mant_clientes.txtContactoTelCompras.Text = Tabla.Rows(0).Item("TelContactoCompras")
            frm_mant_clientes.txtContactoTelComprasExt.Text = Tabla.Rows(0).Item("ExtCompras")
            frm_mant_clientes.txtEncargadoCXC.Text = Tabla.Rows(0).Item("ContactoCXC")
            frm_mant_clientes.txtContactoTelCXC.Text = Tabla.Rows(0).Item("TelContactoCXC")
            frm_mant_clientes.txtExtEncargadoCXC.Text = Tabla.Rows(0).Item("ExtCXC")

            If (Tabla.Rows(0).Item("NoRecibirCheques")) = 0 Then
                frm_mant_clientes.chkNoRecibirCheques.Checked = False
            Else
                frm_mant_clientes.chkNoRecibirCheques.Checked = True
            End If

            If (Tabla.Rows(0).Item("CuentaIncobrable")) = 0 Then
                frm_mant_clientes.chkCuentaIncobrable.Checked = False
            Else
                frm_mant_clientes.chkCuentaIncobrable.Checked = True
            End If

            If (Tabla.Rows(0).Item("GenerarCargo")) = 0 Then
                frm_mant_clientes.chkGenerarCargos.Checked = False
            Else
                frm_mant_clientes.chkGenerarCargos.Checked = True
            End If

            If (Tabla.Rows(0).Item("CerrarCredito")) = 0 Then
                frm_mant_clientes.chkCerrarCredito.Checked = False
            Else
                frm_mant_clientes.chkCerrarCredito.Checked = True
            End If

            If (Tabla.Rows(0).Item("EntregarPorConduce")) = 0 Then
                frm_mant_clientes.chkEntregarporConduce.Checked = False
            Else
                frm_mant_clientes.chkEntregarporConduce.Checked = True
            End If

            If (Tabla.Rows(0).Item("Desactivar")) = 0 Then
                frm_mant_clientes.chkDesactivarCliente.Checked = False
            Else
                frm_mant_clientes.chkDesactivarCliente.Checked = True
            End If

            If (Tabla.Rows(0).Item("BloqueoCobrador")) = 0 Then
                frm_mant_clientes.chkBloqueoCobrador.Checked = False
            Else
                frm_mant_clientes.chkBloqueoCobrador.Checked = True
            End If

            If TypeConnection.Text = 1 Then
                If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                    MakeRoundedImage(My.Resources.no_photo, frm_mant_clientes.PicInmediata)
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        MakeRoundedImage(System.Drawing.Image.FromStream(wFile), frm_mant_clientes.PicInmediata)
                        wFile.Close()
                    Else
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If


            Dim Founded As Boolean = False
            For Each itm As String In frm_mant_clientes.txtPrecio.Items
                If itm = (Tabla.Rows(0).Item("Precio")) Then
                    frm_mant_clientes.txtPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    Founded = True
                    Exit For
                End If
            Next
            If Founded = False Then
                frm_mant_clientes.txtPrecio.Items.Add(Tabla.Rows(0).Item("Precio"))
                frm_mant_clientes.txtPrecio.Text = (Tabla.Rows(0).Item("Precio"))
            End If

            frm_mant_clientes.RefrescarTablaReferencias()
            frm_mant_clientes.RefrescarTablaContratos()
            frm_mant_clientes.RefrescarTablaRutas()
            frm_mant_clientes.RefrescarTablaGestion()
            frm_mant_clientes.RefrescarBalances()
            frm_mant_clientes.RefrescarCarnets()

            SearchingFast = False
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnFacturacion_Click(sender As Object, e As EventArgs) Handles btnFacturacion.Click
        Try
            If Me.Owner.Name = frm_recibo_pagos.Name Then
                If frm_recibo_pagos.txtIDCliente.Text = "" Then
                    MessageBox.Show("No se ha seleccionado un cliente para realizar un acceso rápido en el sistema.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    IDCliente.Text = frm_recibo_pagos.txtIDCliente.Text
                    SearchingFast = True

                    If frm_facturacion.Visible = True Then
                        frm_facturacion.Close()

                        If frm_facturacion.Visible = False Then
                            frm_facturacion.Show(frm_inicio)
                        End If

                    Else
                        frm_facturacion.Show(frm_inicio)
                    End If

                End If


            ElseIf Me.Owner.Name = frm_mant_clientes.Name Then
                If frm_mant_clientes.txtIDCliente.Text = "" Then
                    MessageBox.Show("No se ha seleccionado un cliente para realizar un acceso rápido en el sistema.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    IDCliente.Text = frm_mant_clientes.txtIDCliente.Text
                    SearchingFast = True

                    If frm_facturacion.Visible = True Then
                        frm_facturacion.Close()

                        If frm_facturacion.Visible = False Then
                            frm_facturacion.Show(frm_inicio)
                        End If
                    Else
                        frm_facturacion.Show(frm_inicio)
                    End If
                End If
            End If

            Dim DsTemp As New DataSet

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDCliente,Clientes.IDTratamiento,Tratamiento.TratamientoAbreviado,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Gentilicio,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.Sueldo,Vivienda,Vehiculo,TrabajoActivo,SeguroMedico,CuentasBancaria,Tarjeta,Clientes.CorreoElectronico,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,UbicacionTrabajo,TelefonoTrabajo,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,ColorCalificacion,CalificacionAutonoma,DiasCondicion,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.IDEmpleadoSub,SubCobrador.Nombre as SubCobrador,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Clientes.IDCondicionCliente,Condicion.Condicion,Precio,InformacionAdc,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,BloqueoCobrador,EntregarPorConduce,BalanceGeneral,NumeroTiempoAlquilado,TiempoAlquilado,TipoVIvienda,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,EntidadBancariaCuenta,EntidadBancariaTarjeta,DedicacionAutoEmpleado,OrigenPagos,xCore,Locacion,CreditoAnterior,ReferenciaComercial1,ReferenciaComercial2,Garante,GaranteNombre,TipoIdentificacionGarante,IdentificacionGarante,DireccionGarante,TelefonoGarante,IDRegistrador,IDUsuarioModificador,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Desactivar,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,ContactoCompras,TelContactoCompras,ExtCompras,ContactoCXC,TelContactoCXC,ExtCXC,Clientes.IDVendedorCliente,Vendedor.Nombre as NombreVendedor FROM Libregco.clientes INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Libregco.Condicion on Clientes.IDCondicionCliente=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as SubCobrador on Clientes.IDEmpleadoSub=SubCobrador.IDEmpleado INNER JOIN Libregco.Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN Libregco.estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Libregco.Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN Libregco.GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN" & SysName.Text & "Empleados as Vendedor on Clientes.IDVendedorCliente=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Tratamiento on Clientes.IDTratamiento=Tratamiento.IDTratamiento Where IDCliente='" + IDCliente.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Clientes")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Clientes")


            frm_facturacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_facturacion.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            If (Tabla.Rows(0).Item("IDCliente")) = 1 Then
                frm_facturacion.txtDireccion.Text = ""
                frm_facturacion.txtRNC.Text = ""
            Else
                frm_facturacion.txtDireccion.Text = CStr((Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia")) & ".").ToString.ToUpper
                frm_facturacion.txtRNC.Text = (Tabla.Rows(0).Item("Identificacion"))
            End If

            frm_facturacion.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonoPersonal"))
            If Tabla.Rows(0).Item("TelefonoHogar") <> "" Then
                frm_facturacion.txtTelefonos.Text = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
            End If

            frm_facturacion.txtDiasCondicion.Text = (Tabla.Rows(0).Item("DiasCondicion"))
            frm_facturacion.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
            frm_facturacion.cbxCondicion.Text = Tabla.Rows(0).Item("Condicion")
            frm_facturacion.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_facturacion.txtCobrador.Text = (Tabla.Rows(0).Item("NombreEmpleado"))
            frm_facturacion.txtCobrador.Tag = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_facturacion.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
            frm_facturacion.lblCalificacionColor.BackColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
            frm_facturacion.IDGrupoCXC = Tabla.Rows(0).Item("IDGrupocxc")
            frm_facturacion.GbClientes.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"

            If IsNumeric(Tabla.Rows(0).Item("UltimoMontoPago")) Then
                frm_facturacion.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
            Else
                frm_facturacion.txtUltimoMonto.Text = Tabla.Rows(0).Item("UltimoMontoPago")
            End If
            If TypeConnection.Text = 1 Then
                If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                    frm_facturacion.PicImagen.Image = My.Resources.no_photo
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        frm_facturacion.PicImagen.Image = Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If

            If CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 3 Then
                frm_facturacion.lblStatusBar.Text = "El cliente está excento de los ajustes y controles de facturación de grupos personales."
            End If

            If CInt(Tabla.Rows(0).Item("IDCalificacion")) > 6 Then
                frm_facturacion.lblMensajeCalificacion.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                frm_facturacion.lblMensajeCalificacion.Visible = True
            Else
                frm_facturacion.lblMensajeCalificacion.Visible = False
            End If

            If CInt(DTConfiguracion.Rows(181 - 1).Item("Value2Int")) = 1 Then
                If frm_facturacion.txtIDCliente.Text = "" Or frm_facturacion.txtIDCliente.Text = 1 Then
                Else
                    frm_facturacion.txtVendedor.Tag = Tabla.Rows(0).Item("IDVendedorCliente")
                    frm_facturacion.txtVendedor.Text = Tabla.Rows(0).Item("NombreVendedor")
                End If
            Else
                frm_facturacion.txtVendedor.Tag = Tabla.Rows(0).Item("IDVendedorCliente")
                frm_facturacion.txtVendedor.Text = Tabla.Rows(0).Item("NombreVendedor")
            End If

            Dim Founded As Boolean = False
            For Each itm As String In frm_facturacion.cbxPrecio.Items
                If itm = (Tabla.Rows(0).Item("Precio")) Then
                    frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    Founded = True
                    Exit For
                End If
            Next
            If Founded = False Then
                frm_facturacion.cbxPrecio.Items.Add(Tabla.Rows(0).Item("Precio"))
                frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                frm_facturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
            Else
                frm_facturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
            End If

            If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                frm_facturacion.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
            Else
                frm_facturacion.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            End If

            If (Tabla.Rows(0).Item("EntregarPorConduce")) = 1 Then
                frm_facturacion.chkEntregarporConduce.Checked = True
            Else
                frm_facturacion.chkEntregarporConduce.Checked = False
            End If

            If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                frm_facturacion.DeshabilitarControles()
            End If

            frm_facturacion.RefrescarBalances()

            SearchingFast = False

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnIngresos_Click(sender As Object, e As EventArgs) Handles btnIngresos.Click
        Try
            If Me.Owner.Name = frm_facturacion.Name Then
                If frm_facturacion.txtIDCliente.Text = "" Then
                    MessageBox.Show("No se ha seleccionado un cliente para realizar un acceso rápido en el sistema.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    IDCliente.Text = frm_facturacion.txtIDCliente.Text
                    SearchingFast = True

                    If frm_recibo_pagos.Visible = True Then
                        frm_recibo_pagos.Close()

                        If frm_recibo_pagos.Visible = False Then
                            frm_recibo_pagos.Show(frm_inicio)
                        End If

                    Else
                        frm_recibo_pagos.Show(frm_inicio)
                    End If
                End If

            ElseIf Me.Owner.Name = frm_mant_clientes.Name Then
                If frm_mant_clientes.txtIDCliente.Text = "" Then
                    MessageBox.Show("No se ha seleccionado un cliente para realizar un acceso rápido en el sistema.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    IDCliente.Text = frm_mant_clientes.txtIDCliente.Text
                    SearchingFast = True

                    If frm_recibo_pagos.Visible = True Then
                        frm_recibo_pagos.Close()

                        If frm_recibo_pagos.Visible = False Then
                            frm_recibo_pagos.Show(frm_inicio)
                        End If
                    Else
                        frm_recibo_pagos.Show(frm_inicio)
                    End If
                End If
            End If

            Dim DsTemp As New DataSet

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDCliente,Clientes.IDTratamiento,Tratamiento.TratamientoAbreviado,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Gentilicio,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.Sueldo,Vivienda,Vehiculo,TrabajoActivo,SeguroMedico,CuentasBancaria,Tarjeta,Clientes.CorreoElectronico,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,UbicacionTrabajo,TelefonoTrabajo,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,ColorCalificacion,CalificacionAutonoma,DiasCondicion,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.IDEmpleadoSub,SubCobrador.Nombre as SubCobrador,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Clientes.IDCondicionCliente,Condicion.Condicion,Precio,InformacionAdc,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,BloqueoCobrador,EntregarPorConduce,BalanceGeneral,NumeroTiempoAlquilado,TiempoAlquilado,TipoVIvienda,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,EntidadBancariaCuenta,EntidadBancariaTarjeta,DedicacionAutoEmpleado,OrigenPagos,xCore,Locacion,CreditoAnterior,ReferenciaComercial1,ReferenciaComercial2,Garante,GaranteNombre,TipoIdentificacionGarante,IdentificacionGarante,DireccionGarante,TelefonoGarante,IDRegistrador,IDUsuarioModificador,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Desactivar,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,ContactoCompras,TelContactoCompras,ExtCompras,ContactoCXC,TelContactoCXC,ExtCXC,Clientes.IDVendedorCliente,Vendedor.Nombre as NombreVendedor,LiberarControles FROM Libregco.clientes INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Libregco.Condicion on Clientes.IDCondicionCliente=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as SubCobrador on Clientes.IDEmpleadoSub=SubCobrador.IDEmpleado INNER JOIN Libregco.Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN Libregco.estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Libregco.Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN Libregco.GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN" & SysName.Text & "Empleados as Vendedor on Clientes.IDVendedorCliente=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Tratamiento on Clientes.IDTratamiento=Tratamiento.IDTratamiento Where IDCliente='" + IDCliente.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Clientes")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Clientes")

            frm_recibo_pagos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_recibo_pagos.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_recibo_pagos.GPCliente.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"
            frm_recibo_pagos.lblDireccion.Text = (Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia")) & "."
            frm_recibo_pagos.lblTelefono.Text = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
            frm_recibo_pagos.lblIdentificacion.Text = (Tabla.Rows(0).Item("Identificacion"))
            frm_recibo_pagos.lblCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_recibo_pagos.txtCobrador.Text = (Tabla.Rows(0).Item("NombreEmpleado"))
            frm_recibo_pagos.LiberarControles.Text = Tabla.Rows(0).Item("LiberarControles")

            If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                frm_recibo_pagos.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
            Else
                frm_recibo_pagos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            End If

            If IsNumeric(Tabla.Rows(0).Item("UltimoMontoPago")) Then
                frm_recibo_pagos.txtMontoUltimoPago.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
            Else
                frm_recibo_pagos.txtMontoUltimoPago.Text = Tabla.Rows(0).Item("UltimoMontoPago")
            End If

            If TypeConnection.Text = 1 Then
                If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                    frm_recibo_pagos.PicImagen.Image = My.Resources.no_photo
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        frm_recibo_pagos.PicImagen.Image = Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If


            frm_recibo_pagos.RefrescarBalances()
            frm_recibo_pagos.RefrescarTablaFacturas()
            frm_recibo_pagos.VerifyBalances()
            frm_recibo_pagos.BuscarNotasDescuentos()

            frm_recibo_pagos.txtMontoAplicar.Focus()

            If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                frm_recibo_pagos.DeshabilitarControles()
            End If

            If frm_recibo_pagos.DTFacturas.Rows.Count = 0 Then
                MessageBox.Show("El cliente: [" & frm_recibo_pagos.txtIDCliente.Text & "] " & frm_recibo_pagos.txtNombre.Text & ", no tiene facturas pendientes.", "No se encontraron facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            If CheckDoubleBilling(Tabla.Rows(0).Item("IDCliente")) = True Then
                frm_bloqueo_facturacion_simultanea.ShowDialog(Me)
            End If

            'Liberando controles
            If DTConfiguracion.Rows(83 - 1).Item("Value2Int") = 1 Then
                If Tabla.Rows(0).Item("IDCliente") = DTConfiguracion.Rows(84 - 1).Item("Value2Int") Then
                    frm_recibo_pagos.LiberarControles.Text = 1
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").OwnerBand = frm_recibo_pagos.GridBand1
                    frm_recibo_pagos.AdvBandedGridView1.SetColumnPosition(frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura"), 0, 0)
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").Visible = True
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").VisibleIndex = 0
                Else
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").Visible = False
                    frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").OwnerBand = Nothing
                    'frm_recibo_pagos.AdvBandedGridView1.column
                End If
            End If



            SearchingFast = False
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class