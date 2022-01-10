Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_clientes

    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet
    Dim ImageColumn As New DataGridViewImageColumn


    Private Sub frm_buscar_mant_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
        PropiedadColumnsDvg()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,TelefonoPersonal,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,Clientes.BalanceGeneral,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago FROM Libregco.Clientes where IDCliente like '%" + txtBuscar.Text + "%' Order By IDCliente DESC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int"), ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,TelefonoPersonal,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,Clientes.BalanceGeneral,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago FROM Libregco.Clientes where Nombre like '%" + txtBuscar.Text + "%' Order By IDCliente=1 Desc,Nombre ASC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int"), ConLibregco)
            ElseIf rdbCedula.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,TelefonoPersonal,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,Clientes.BalanceGeneral,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago FROM Libregco.Clientes where Identificacion like '%" + txtBuscar.Text + "%' Order By identificacion ASC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int"), ConLibregco)
            ElseIf rdbTelefono.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,TelefonoPersonal,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,Clientes.BalanceGeneral,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago FROM Libregco.Clientes where TelefonoPersonal like '%" + txtBuscar.Text + "%' or TelefonoHogar like '%" + txtBuscar.Text + "' Order By TelefonoPersonal ASC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int"), ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")

            Bs.DataMember = "Clientes"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvClientes.DataSource = Bs

            DgvClientes.Columns.Add(ImageColumn)
            ImageColumn.Image = My.Resources.ResourceManager.GetObject("no_photo")
            ImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom

            PropiedadColumnsDvg()

            txtBuscar.Focus()
        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbNombre.Checked = True
        txtBuscar.Clear()
        cbxShowPicture.Text = "No"
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        Try
            Dim DatagridWidth As Double = (DgvClientes.Width - DgvClientes.RowHeadersWidth) / 100

            If cbxShowPicture.Text = "No" Then
                DgvClientes.Columns(0).Visible = False
                DgvClientes.Columns(1).Width = DatagridWidth * 15
                DgvClientes.Columns(1).HeaderText = "Código"
                DgvClientes.Columns(2).HeaderText = "Nombre"
                DgvClientes.Columns(2).Width = DatagridWidth * 45
                DgvClientes.Columns(3).HeaderText = "Identificación"
                DgvClientes.Columns(3).Width = DatagridWidth * 20
                DgvClientes.Columns(4).HeaderText = "Teléfono"
                DgvClientes.Columns(4).Width = DatagridWidth * 20
                DgvClientes.Columns(5).Visible = False
                DgvClientes.Columns(6).Visible = False
                DgvClientes.Columns(7).Visible = False

            ElseIf cbxShowPicture.Text = "Sí" Then
                DgvClientes.Columns(0).Visible = True
                DgvClientes.Columns(0).Width = DatagridWidth * 10
                DgvClientes.Columns(1).Width = DatagridWidth * 15
                DgvClientes.Columns(1).HeaderText = "Código"
                DgvClientes.Columns(2).HeaderText = "Nombre"
                DgvClientes.Columns(2).Width = DatagridWidth * 45
                DgvClientes.Columns(3).HeaderText = "Identificación"
                DgvClientes.Columns(3).Width = DatagridWidth * 15
                DgvClientes.Columns(4).HeaderText = "Teléfono"
                DgvClientes.Columns(4).Width = DatagridWidth * 15
                DgvClientes.Columns(5).Visible = False
                DgvClientes.Columns(6).Visible = False
                DgvClientes.Columns(7).Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        RefrescarTabla()
        'BuscarBalance()
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
        Try
            RefrescarTabla()
            RefrescarFotos()

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvClientes.Focus()
    End Sub


    Private Sub LlenarFormularios()
        Try
            Dim IDCliente As New Label
            Dim DsTemp As New DataSet

            If DgvClientes.Rows.Count > 0 Then
                IDCliente.Text = DgvClientes.CurrentRow.Cells(1).Value

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDCliente,Clientes.IDTratamiento,Tratamiento.TratamientoAbreviado,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Gentilicio,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.Sueldo,Vivienda,Vehiculo,TrabajoActivo,SeguroMedico,CuentasBancaria,Tarjeta,Clientes.CorreoElectronico,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,UbicacionTrabajo,TelefonoTrabajo,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,ColorCalificacion,CalificacionAutonoma,DiasCondicion,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.IDEmpleadoSub,SubCobrador.Nombre as SubCobrador,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Clientes.IDCondicionCliente,Condicion.Condicion,Precio,InformacionAdc,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,BloqueoCobrador,EntregarPorConduce,BalanceGeneral,NumeroTiempoAlquilado,TiempoAlquilado,TipoVIvienda,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,EntidadBancariaCuenta,EntidadBancariaTarjeta,DedicacionAutoEmpleado,OrigenPagos,xCore,Locacion,CreditoAnterior,ReferenciaComercial1,ReferenciaComercial2,Garante,GaranteNombre,TipoIdentificacionGarante,IdentificacionGarante,DireccionGarante,TelefonoGarante,IDRegistrador,IDUsuarioModificador,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Desactivar,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,ContactoCompras,TelContactoCompras,ExtCompras,ContactoCXC,TelContactoCXC,ExtCXC,Clientes.IDVendedorCliente,Vendedor.Nombre as NombreVendedor,LiberarControles FROM Libregco.clientes INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Libregco.Condicion on Clientes.IDCondicionCliente=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as SubCobrador on Clientes.IDEmpleadoSub=SubCobrador.IDEmpleado INNER JOIN Libregco.Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN Libregco.estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Libregco.Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN Libregco.GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN" & SysName.Text & "Empleados as Vendedor on Clientes.IDVendedorCliente=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Tratamiento on Clientes.IDTratamiento=Tratamiento.IDTratamiento Where IDCliente='" + IDCliente.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Clientes")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Clientes")

                If Me.Owner.Name = frm_facturacion.Name Then
                    Dim IDMoneda As String = frm_facturacion.cbxMoneda.EditValue

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
                    frm_facturacion.txtCobrador.Tag = Tabla.Rows(0).Item("IDEmpleado")
                    frm_facturacion.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
                    frm_facturacion.lblCalificacionColor.BackColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                    frm_facturacion.IDGrupoCXC = Tabla.Rows(0).Item("IDGrupocxc")
                    frm_facturacion.GbClientes.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"
                    frm_facturacion.LiberarControles.Text = Tabla.Rows(0).Item("LiberarControles")

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

                    ElseIf CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 4 Then
                        frm_facturacion.lblStatusBar.Text = "Cuenta interna.!! Está excenta de los ajustes y controles de facturación."
                    End If

                    If CInt(Tabla.Rows(0).Item("IDCalificacion")) > 6 Then
                        frm_facturacion.lblMensajeCalificacion.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                        frm_facturacion.lblMensajeCalificacion.Visible = True
                    Else
                        frm_facturacion.lblMensajeCalificacion.Visible = False
                    End If

                    If CInt(DTConfiguracion.Rows(181 - 1).Item("Value2Int")) = 1 Then
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

                    'Liberando controles
                    If DTConfiguracion.Rows(83 - 1).Item("Value2Int") = 1 Then
                        If Tabla.Rows(0).Item("IDCliente") = DTConfiguracion.Rows(84 - 1).Item("Value2Int") Then
                            frm_facturacion.LiberarControles.Text = 1
                        End If
                    End If

                    frm_facturacion.RefrescarBalances()

                    If IDMoneda <> "" Then
                        frm_facturacion.cbxMoneda.EditValue = CInt(IDMoneda)
                    End If

                    If CInt(Tabla.Rows(0).Item("IDComprobanteFiscal")) = 8 Then
                        frm_facturacion.DeterminarCambiadoItbis()
                    End If



                ElseIf Me.Owner.Name = frm_mant_clientes.Name Then
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
                    frm_mant_clientes.chkNoRecibirCheques.Checked = Convert.ToBoolean(CInt(Tabla.Rows(0).Item("NoRecibirCheques")))
                    frm_mant_clientes.chkCuentaIncobrable.Checked = Convert.ToBoolean(CInt(Tabla.Rows(0).Item("CuentaIncobrable")))
                    frm_mant_clientes.chkGenerarCargos.Checked = Convert.ToBoolean(CInt(Tabla.Rows(0).Item("GenerarCargo")))
                    frm_mant_clientes.chkCerrarCredito.Checked = Convert.ToBoolean(CInt(Tabla.Rows(0).Item("CerrarCredito")))
                    frm_mant_clientes.chkEntregarporConduce.Checked = Convert.ToBoolean(CInt(Tabla.Rows(0).Item("EntregarPorConduce")))
                    frm_mant_clientes.chkDesactivarCliente.Checked = Convert.ToBoolean(CInt(Tabla.Rows(0).Item("Desactivar")))
                    frm_mant_clientes.chkBloqueoCobrador.Checked = Convert.ToBoolean(CInt(Tabla.Rows(0).Item("BloqueoCobrador")))
                    frm_mant_clientes.chkLiberarControles.Checked = Convert.ToBoolean(CInt(Tabla.Rows(0).Item("LiberarControles")))

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
                    frm_mant_clientes.RefrescarCarnets

                    If CInt(DTConfiguracion.Rows(85 - 1).Item("Value2Int")) = 1 Then
                        If CInt(Tabla.Rows(0).Item("IDCliente")) = 1 Then
                            frm_mant_clientes.DeshabilitarCliente()
                        End If
                    End If
                ElseIf Me.Owner.Name = frm_financiamiento.Name Then
                    frm_financiamiento.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_financiamiento.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_financiamiento.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_financiamiento.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_financiamiento.txtBalanceGeneralCargos.Text = CDbl(CDbl(Tabla.Rows(0).Item("BalanceGeneral")) + CDbl(Tabla.Rows(0).Item("CargosCliente"))).ToString("C")

                    If CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 3 Then
                        frm_financiamiento.lblStatusBar.Text = "El cliente está excento de los ajustes y controles de facturación de grupos personales."
                    End If

                    If CInt(Tabla.Rows(0).Item("IDCalificacion")) > 6 Then
                        frm_financiamiento.lblMensajeCalificacion.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                        frm_financiamiento.lblMensajeCalificacion.Visible = True
                    Else
                        frm_financiamiento.lblMensajeCalificacion.Visible = False
                    End If

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_financiamiento.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_financiamiento.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                        MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                        MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        'frm_financiamiento.DeshabilitarControles()
                    End If

                ElseIf Me.Owner.Name = frm_cuotas_financiamientos.Name Then

                    frm_cuotas_financiamientos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_cuotas_financiamientos.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_cuotas_financiamientos.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_cuotas_financiamientos.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_cuotas_financiamientos.txtBalanceGeneralCargos.Text = CDbl(CDbl(Tabla.Rows(0).Item("BalanceGeneral")) + CDbl(Tabla.Rows(0).Item("CargosCliente"))).ToString("C")

                    If CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 3 Then
                        frm_cuotas_financiamientos.lblStatusBar.Text = "El cliente está excento de los ajustes y controles de facturación de grupos personales."
                    End If

                    If CInt(Tabla.Rows(0).Item("IDCalificacion")) > 6 Then
                        frm_cuotas_financiamientos.lblMensajeCalificacion.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                        frm_cuotas_financiamientos.lblMensajeCalificacion.Visible = True
                    Else
                        frm_cuotas_financiamientos.lblMensajeCalificacion.Visible = False
                    End If

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_cuotas_financiamientos.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_cuotas_financiamientos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                        MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                        MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        'frm_financiamiento.DeshabilitarControles()
                    End If
                    frm_cuotas_financiamientos.FillFinanciamientos()

                ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
                    frm_punto_venta_lite.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_punto_venta_lite.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    If (Tabla.Rows(0).Item("IDCliente")) = 1 Then
                        frm_punto_venta_lite.txtDireccion.Text = ""
                        frm_punto_venta_lite.txtRNC.Text = ""
                    Else
                        frm_punto_venta_lite.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia")) & "."
                        frm_punto_venta_lite.txtRNC.Text = (Tabla.Rows(0).Item("Identificacion"))
                    End If
                    frm_punto_venta_lite.txtTelefono.Text = (Tabla.Rows(0).Item("TelefonoPersonal")) & " " & (Tabla.Rows(0).Item("TelefonoHogar"))
                    frm_punto_venta_lite.txtDiasCondicion.Text = (Tabla.Rows(0).Item("DiasCondicion"))
                    frm_punto_venta_lite.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_punto_venta_lite.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_punto_venta_lite.txtCobrador.Text = (Tabla.Rows(0).Item("NombreEmpleado"))
                    frm_punto_venta_lite.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                    frm_punto_venta_lite.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")

                    Dim Founded As Boolean = False
                    For Each itm As String In frm_punto_venta_lite.cbxPrecio.Items
                        If itm = (Tabla.Rows(0).Item("Precio")) Then
                            frm_punto_venta_lite.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                            Founded = True
                            Exit For
                        End If
                    Next
                    If Founded = False Then
                        frm_punto_venta_lite.cbxPrecio.Items.Add(Tabla.Rows(0).Item("Precio"))
                        frm_punto_venta_lite.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                        frm_punto_venta_lite.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    Else
                        frm_punto_venta_lite.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                        frm_punto_venta_lite.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    End If

                    If (Tabla.Rows(0).Item("EntregarPorConduce")) = 1 Then
                        frm_punto_venta_lite.chkEntregarporConduce.Checked = True
                    Else
                        frm_punto_venta_lite.chkEntregarporConduce.Checked = False
                    End If

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_punto_venta_lite.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_punto_venta_lite.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                        MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                        MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_punto_venta_lite.DeshabilitarControles()
                    End If

                ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
                    frm_registro_factura_sd.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_registro_factura_sd.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    If (Tabla.Rows(0).Item("IDCliente")) = 1 Then
                        frm_registro_factura_sd.txtDireccion.Text = ""
                        frm_registro_factura_sd.txtRNC.Text = ""
                    Else
                        frm_registro_factura_sd.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia")) & "."
                        frm_registro_factura_sd.txtRNC.Text = (Tabla.Rows(0).Item("Identificacion"))
                    End If
                    frm_registro_factura_sd.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonoPersonal")) & " " & (Tabla.Rows(0).Item("TelefonoHogar"))
                    frm_registro_factura_sd.txtDiasCondicion.Text = (Tabla.Rows(0).Item("DiasCondicion"))
                    frm_registro_factura_sd.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_registro_factura_sd.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_registro_factura_sd.txtCobrador.Text = (Tabla.Rows(0).Item("NombreEmpleado"))
                    frm_registro_factura_sd.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
                    frm_registro_factura_sd.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_registro_factura_sd.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_registro_factura_sd.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_registro_factura_sd.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_registro_factura_sd.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                        MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                        MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_registro_factura_sd.DeshabilitarControles()
                    End If

                ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then
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
                            frm_recibo_pagos.GbAplicado.Visible = False
                        Else
                            frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").Visible = False
                            frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").OwnerBand = Nothing
                            frm_recibo_pagos.GbAplicado.Visible = True
                            'frm_recibo_pagos.AdvBandedGridView1.column
                        End If
                    Else
                        frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").Visible = False
                        frm_recibo_pagos.AdvBandedGridView1.Columns("NombreFactura").OwnerBand = Nothing
                        frm_recibo_pagos.GbAplicado.Visible = True
                    End If



                ElseIf Me.Owner.Name = frm_consulta_conduces.Name Then
                    frm_consulta_conduces.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_conduces.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_deposito_factura.Name Then
                    frm_deposito_factura.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_deposito_factura.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_deposito_factura.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_deposito_factura.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_deposito_factura.txtBalanceGeneralCargos.Text = CDbl(CDbl(Tabla.Rows(0).Item("BalanceGeneral")) + CDbl(Tabla.Rows(0).Item("CargosCliente"))).ToString("C")

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_deposito_factura.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_deposito_factura.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    frm_deposito_factura.RefrescarTablaFacturas()

                    frm_deposito_factura.btnBuscarCliente.Enabled = False

                    If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                        MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                        MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_deposito_factura.DeshabilitarControles()
                    End If

                    If frm_deposito_factura.DgvFacturasPendientes.Rows.Count = 0 Then
                        MessageBox.Show("El cliente: [" & frm_deposito_factura.txtIDCliente.Text & "] " & frm_deposito_factura.txtNombre.Text & ", no tiene facturas pendientes.", "No se encontraron facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If


                ElseIf Me.Owner.Name = frm_mant_referencias.Name Then
                    frm_mant_referencias.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_mant_referencias.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_mant_referencias.txtCedula.Text = (Tabla.Rows(0).Item("Identificacion"))

                ElseIf Me.Owner.Name = frm_cargar_pagare_individual.Name Then

                    If frm_cargar_pagare_individual.txtIDCobrador.Text = (Tabla.Rows(0).Item("IDEmpleado")) Then
                        frm_cargar_pagare_individual.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                        frm_cargar_pagare_individual.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                        frm_cargar_pagare_individual.RefrescarFacturas()
                    Else
                        MessageBox.Show("[" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " esta asignado para el cobrador [" & (Tabla.Rows(0).Item("IDEmpleado")) & "] " & (Tabla.Rows(0).Item("NombreEmpleado")) & "." & vbNewLine & vbNewLine & "Por tal motivo no es elegible para una titulación para el cobrador [" & frm_cargar_pagare_individual.txtIDCobrador.Text & "] " & frm_cargar_pagare_individual.txtCobrador.Text & ".", "Cobrador no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                ElseIf Me.Owner.Name = frm_contratos_clientes.Name Then
                    frm_contratos_clientes.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_contratos_clientes.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_contratos_clientes.CodeNumContraro()


                ElseIf Me.Owner.Name = frm_reporte_movimientos_clientes.Name Then
                    frm_reporte_movimientos_clientes.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_movimientos_clientes.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                    If frm_reporte_movimientos_clientes.txtCliente.Text = "" Then
                        frm_reporte_movimientos_clientes.txtIDCliente.Clear()
                    Else
                        frm_reporte_movimientos_clientes.FillEstadoCuenta()
                    End If


                ElseIf Me.Owner.Name = frm_prefacturacion.Name Then
                    frm_prefacturacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_prefacturacion.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_prefacturacion.lblIDTipoNCF.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                    frm_prefacturacion.TipoNCF.Text = Tabla.Rows(0).Item("TipoComprobante")
                    frm_prefacturacion.DireccionCliente = (Tabla.Rows(0).Item("Direccion") & ", " & Tabla.Rows(0).Item("Municipio") & " " & Tabla.Rows(0).Item("Provincia")).ToString.ToUpper
                    frm_prefacturacion.TelefonoCliente = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
                    frm_prefacturacion.RNCliente = (Tabla.Rows(0).Item("Identificacion"))
                    frm_prefacturacion.txtIDCondicion.Text = Tabla.Rows(0).Item("IDCondicionCliente")
                    frm_prefacturacion.txtCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper
                    frm_prefacturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    frm_prefacturacion.IDGrupo_Cliente = Tabla.Rows(0).Item("IDGrupocxc")

                    If CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 3 Then
                        frm_prefacturacion.lblStatusBar.Text = "El cliente está excento de los ajustes y controles de facturación de grupos personales."

                    ElseIf CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 4 Then
                        frm_prefacturacion.lblStatusBar.Text = "Cuenta interna.!! Está excenta de los ajustes y controles de facturación."
                    End If

                    frm_prefacturacion.FillPrecios()

                ElseIf Me.Owner.Name = frm_mdi_prefacturacion.name Then


                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).lblIDTipoNCF.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TipoNCF = Tabla.Rows(0).Item("TipoComprobante")
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).DireccionCliente = (Tabla.Rows(0).Item("Direccion") & ", " & Tabla.Rows(0).Item("Municipio") & " " & Tabla.Rows(0).Item("Provincia")).ToString.ToUpper
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TelefonoCliente = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).RNCliente = (Tabla.Rows(0).Item("Identificacion"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDCondicion.Text = Tabla.Rows(0).Item("IDCondicionCliente")
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).IDGrupo_Cliente = Tabla.Rows(0).Item("IDGrupocxc")

                    If CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 3 Then
                        DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).lblStatusBar.Text = "El cliente está excento de los ajustes y controles de facturación de grupos personales."

                    ElseIf CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 4 Then
                        DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).lblStatusBar.Text = "Cuenta interna.!! Está excenta de los ajustes y controles de facturación."
                    End If

                    DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).FillPrecios()

                ElseIf Me.Owner.Name = frm_prefacturacion_detalles.Name Then

                    If Me.Owner.Owner.Name = frm_prefacturacion.Name Then
                        frm_prefacturacion_detalles.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                        frm_prefacturacion_detalles.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                        frm_prefacturacion_detalles.txtRNC.Text = (Tabla.Rows(0).Item("Identificacion"))
                        frm_prefacturacion_detalles.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion") & ", " & Tabla.Rows(0).Item("Municipio") & " " & Tabla.Rows(0).Item("Provincia")).ToString.ToUpper
                        frm_prefacturacion_detalles.txtTelefono.Text = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
                        frm_prefacturacion_detalles.txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                        frm_prefacturacion_detalles.txtTipoNcf.Text = Tabla.Rows(0).Item("TipoComprobante")
                        frm_prefacturacion_detalles.txtIDCondicion.Text = Tabla.Rows(0).Item("IDCondicionCliente")
                        frm_prefacturacion_detalles.txtCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper
                        frm_prefacturacion.txtIDCondicion.Text = Tabla.Rows(0).Item("IDCondicionCliente")
                        frm_prefacturacion.txtCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper
                        frm_prefacturacion.IDGrupo_Cliente = Tabla.Rows(0).Item("IDTipoCredito")

                        If Tabla.Rows(0).Item("IDComprobanteFiscal") = 1 Then
                            frm_prefacturacion_detalles.rdbCreditoFiscal.Checked = True
                        ElseIf Tabla.Rows(0).Item("IDComprobanteFiscal") = 2 Then
                            frm_prefacturacion_detalles.rdbConsumidorFin.Checked = True
                        ElseIf Tabla.Rows(0).Item("IDComprobanteFiscal") = 8 Then
                            frm_prefacturacion_detalles.rdbRegimenEsp.Checked = True
                        ElseIf Tabla.Rows(0).Item("IDComprobanteFiscal") = 9 Then
                            frm_prefacturacion_detalles.rdbGubernamental.Checked = True
                        End If

                        frm_prefacturacion_detalles.txtNombre.Focus()
                        frm_prefacturacion_detalles.txtNombre.SelectAll()

                        Dim TRN As String = frm_prefacturacion_detalles.txtRNC.Text.Replace("-", "").Trim
                        If TRN.Length = 0 Then
                            frm_prefacturacion_detalles.txtRNC.Text = ""
                        End If

                    ElseIf Me.Owner.Owner.Name = frm_mdi_prefacturacion.name Then
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtRNC.Text = (Tabla.Rows(0).Item("Identificacion"))
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtDireccion.Text = (Tabla.Rows(0).Item("Direccion") & ", " & Tabla.Rows(0).Item("Municipio") & " " & Tabla.Rows(0).Item("Provincia")).ToString.ToUpper
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtTelefono.Text = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtTipoNcf.Text = Tabla.Rows(0).Item("TipoComprobante")
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtIDCondicion.Text = Tabla.Rows(0).Item("IDCondicionCliente")
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtIDCondicion.Text = Tabla.Rows(0).Item("IDCondicionCliente")
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper
                        DirectCast(Me.Owner.Owner.ActiveMdiChild, frm_prefacturacion_new).IDGrupo_Cliente = Tabla.Rows(0).Item("IDTipoCredito")

                        If Tabla.Rows(0).Item("IDComprobanteFiscal") = 1 Then
                            DirectCast(Me.Owner, frm_prefacturacion_detalles).rdbCreditoFiscal.Checked = True
                        ElseIf Tabla.Rows(0).Item("IDComprobanteFiscal") = 2 Then
                            DirectCast(Me.Owner, frm_prefacturacion_detalles).rdbConsumidorFin.Checked = True
                        ElseIf Tabla.Rows(0).Item("IDComprobanteFiscal") = 8 Then
                            DirectCast(Me.Owner, frm_prefacturacion_detalles).rdbRegimenEsp.Checked = True
                        ElseIf Tabla.Rows(0).Item("IDComprobanteFiscal") = 9 Then
                            DirectCast(Me.Owner, frm_prefacturacion_detalles).rdbGubernamental.Checked = True
                        End If

                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtNombre.Focus()
                        DirectCast(Me.Owner, frm_prefacturacion_detalles).txtNombre.SelectAll()

                        Dim TRN As String = DirectCast(Me.Owner, frm_prefacturacion_detalles).txtRNC.Text.Replace("-", "").Trim
                        If TRN.Length = 0 Then
                            DirectCast(Me.Owner, frm_prefacturacion_detalles).txtRNC.Text = ""
                        End If
                    End If


                ElseIf Me.Owner.Name = frm_historialpagos.Name Then
                    frm_historialpagos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_historialpagos.txtNombreCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_ventas.Name Then
                    frm_reporte_ventas.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_ventas.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_memosclientes.Name Then
                    frm_consulta_memosclientes.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_memosclientes.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_nota_debito_credito.Name Then
                    frm_consulta_nota_debito_credito.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_nota_debito_credito.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_mant_memos_cliente.Name Then
                    frm_mant_memos_cliente.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_mant_memos_cliente.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_cotizacion.Name Then
                    If (Tabla.Rows(0).Item("IDCliente")) = 1 Then
                        frm_cotizacion.txtDireccion.Text = ""
                        frm_cotizacion.txtTelefonos.Text = ""
                    Else
                        frm_cotizacion.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia")) & "."
                        frm_cotizacion.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonoPersonal")) & " " & (Tabla.Rows(0).Item("TelefonoHogar"))
                    End If

                    frm_cotizacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_cotizacion.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_cotizacion.lblIDCondicion.Text = Tabla.Rows(0).Item("IDCondicionCliente")
                    frm_cotizacion.cbxCondicion.Text = Tabla.Rows(0).Item("Condicion").ToString.ToUpper

                    If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                        MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el matenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_cotizacion.DeshabilitarControles()
                    End If

                ElseIf Me.Owner.Name = frm_registro_recibos_cobro.Name Then
                    frm_registro_recibos_cobro.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_registro_recibos_cobro.txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Tabla.Rows(0).Item("Nombre").ToString.ToLower)
                    frm_registro_recibos_cobro.TextBox1.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Tabla.Rows(0).Item("Nombre").ToString.ToLower)
                    frm_registro_recibos_cobro.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_registro_recibos_cobro.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")

                    If CDbl(Tabla.Rows(0).Item("BalanceGeneral")) = 0 Then
                        frm_registro_recibos_cobro.txtBalanceGral.ForeColor = Color.Black
                    Else
                        frm_registro_recibos_cobro.txtBalanceGral.ForeColor = Color.Red
                    End If

                    frm_registro_recibos_cobro.txtIDCobradorC.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                    frm_registro_recibos_cobro.txtCobradorC.Text = (Tabla.Rows(0).Item("NombreEmpleado"))

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_registro_recibos_cobro.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_registro_recibos_cobro.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    If TypeConnection.Text = 1 Then
                        If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                            MakeRoundedImageToPanel(My.Resources.no_photo, frm_registro_recibos_cobro.PicCliente)
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                                MakeRoundedImageToPanel(System.Drawing.Image.FromStream(wFile), frm_registro_recibos_cobro.PicCliente)
                                wFile.Close()

                            Else
                                MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        End If
                    End If

                    frm_registro_recibos_cobro.GetInformation()
                    frm_registro_recibos_cobro.FillCbxFacturas()
                    frm_registro_recibos_cobro.VerificarCobrador()


                ElseIf Me.Owner.Name = frm_gestiones_clientes.Name Then
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
                ElseIf Me.Owner.Name = frm_pedidos.Name Then
                    frm_pedidos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_pedidos.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_pedidos.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia")) & "."
                    frm_pedidos.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonoPersonal")) & " " & (Tabla.Rows(0).Item("TelefonoHogar"))
                    frm_pedidos.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_pedidos.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_pedidos.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_pedidos.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_pedidos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                ElseIf Me.Owner.Name = frm_cheques_futuristas.Name Then
                    frm_cheques_futuristas.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_cheques_futuristas.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_cheques_futuristas.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_cheques_futuristas.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_cheques_futuristas.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_cheques_futuristas.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    frm_cheques_futuristas.RefrescarTablaFacturas()

                ElseIf Me.Owner.Name = frm_historial_recibos_cliente.Name Then
                    frm_historial_recibos_cliente.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_historial_recibos_cliente.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_historial_recibos_cliente.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_historial_recibos_cliente.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_historial_recibos_cliente.txtCobrador.Text = (Tabla.Rows(0).Item("NombreEmpleado"))
                    frm_historial_recibos_cliente.txtLimiteCredito.Text = CDbl(Tabla.Rows(0).Item("LimiteCredito")).ToString("C") & " | " & "Disp: " & (CDbl(Tabla.Rows(0).Item("LimiteCredito")) - CDbl(Tabla.Rows(0).Item("BalanceGeneral"))).ToString("C")

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_historial_recibos_cliente.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_historial_recibos_cliente.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    frm_historial_recibos_cliente.FillCbxFacturas()

                ElseIf Me.Owner.Name = frm_consulta_ventas.Name Then
                    frm_consulta_ventas.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_ventas.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_devolucion_venta.Name Then
                    frm_consulta_devolucion_venta.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_devolucion_venta.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_acuerdos_pago.Name Then
                    frm_acuerdos_pago.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_acuerdos_pago.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_acuerdos_pago.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_acuerdos_pago.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_acuerdos_pago.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

                    frm_acuerdos_pago.cbxGeneroDeudor.Text = (Tabla.Rows(0).Item("Genero"))
                    frm_acuerdos_pago.txtDeudor.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_acuerdos_pago.txtDomicilioDeudor.Text = (Tabla.Rows(0).Item("Direccion"))
                    frm_acuerdos_pago.cbxIdentificacionDeudor.Text = (Tabla.Rows(0).Item("TipoIdentificacion"))
                    frm_acuerdos_pago.txtIdentificacionDeudor.Text = (Tabla.Rows(0).Item("Identificacion"))
                    frm_acuerdos_pago.txtNacionalidadDeudor.Text = (Tabla.Rows(0).Item("Gentilicio"))
                    frm_acuerdos_pago.txtEstadoCivilDeudor.Text = (Tabla.Rows(0).Item("EstadoCivil"))
                    frm_acuerdos_pago.txtOcupacionDeudor.Text = (Tabla.Rows(0).Item("OcupacionCliente"))
                    frm_acuerdos_pago.txtMunicipioDeudor.Text = (Tabla.Rows(0).Item("Municipio"))
                    frm_acuerdos_pago.txtProvinciaDeudor.Text = (Tabla.Rows(0).Item("Provincia"))
                    frm_acuerdos_pago.txtDeuda.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")

                ElseIf Me.Owner.Name = frm_notas_debito_credito.Name Then
                    frm_notas_debito_credito.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_notas_debito_credito.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_notas_debito_credito.GPCliente.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"
                    frm_notas_debito_credito.lblCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_notas_debito_credito.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_notas_debito_credito.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    If IsNumeric(Tabla.Rows(0).Item("UltimoMontoPago")) Then
                        frm_notas_debito_credito.txtMontoUltimoPago.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
                    Else
                        frm_notas_debito_credito.txtMontoUltimoPago.Text = Tabla.Rows(0).Item("UltimoMontoPago")
                    End If

                    If TypeConnection.Text = 1 Then
                        If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                            frm_notas_debito_credito.PicImagen.Image = My.Resources.no_photo
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                                frm_notas_debito_credito.PicImagen.Image = Image.FromStream(wFile)
                                wFile.Close()
                            Else
                                MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        End If
                    End If


                    frm_notas_debito_credito.RefrescarBalances()
                    frm_notas_debito_credito.RefrescarTablaFacturas()
                    frm_notas_debito_credito.VerifyBalances()

                    frm_notas_debito_credito.DgvFacturas.Focus()

                    If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                        MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                        MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_notas_debito_credito.DeshabilitarControles()
                    End If

                    If frm_notas_debito_credito.DgvFacturas.Rows.Count = 0 Then
                        MessageBox.Show("El cliente: [" & frm_notas_debito_credito.txtIDCliente.Text & "] " & frm_notas_debito_credito.txtNombre.Text & ", no tiene facturas pendientes.", "No se encontraron facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                    If CheckDoubleBilling(Tabla.Rows(0).Item("IDCliente")) = True Then
                        frm_bloqueo_facturacion_simultanea.ShowDialog(Me)
                    End If


                ElseIf Me.Owner.Name = frm_otros_ingresos.Name Then
                    frm_otros_ingresos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_otros_ingresos.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_otros_ingresos.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_otros_ingresos.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_otros_ingresos.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_otros_ingresos.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_otros_ingresos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                ElseIf Me.Owner.Name = frm_cobros_adelantados.Name Then
                    frm_cobros_adelantados.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_cobros_adelantados.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_cobros_adelantados.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_cobros_adelantados.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_cobros_adelantados.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_cobros_adelantados.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_cobros_adelantados.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                ElseIf Me.Owner.Name = frm_consulta_otros_ingresos.Name Then
                    frm_consulta_otros_ingresos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_otros_ingresos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_consulta_otros_ingresos.VerificarCondicionCliente()

                ElseIf Me.Owner.Name = frm_consulta_cotizacion.Name Then
                    frm_consulta_cotizacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_cotizacion.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_cheques_devueltos.Name Then
                    frm_cheques_devueltos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_cheques_devueltos.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_cheques_devueltos.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_cheques_devueltos.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_cheques_devueltos.lblIdentificacion.Text = (Tabla.Rows(0).Item("Identificacion"))
                    frm_cheques_devueltos.lblDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
                    frm_cheques_devueltos.lblTelefono.Text = (Tabla.Rows(0).Item("TelefonoPersonal"))
                    frm_cheques_devueltos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

                ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                    frm_reporte_detalle_ventas.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_detalle_ventas.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_registro_factura.Name Then
                    frm_consulta_registro_factura.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_registro_factura.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_consulta_registro_factura.VerificarCondicionCliente()

                    frm_reporte_detalle_ventas.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
                    frm_reporte_devolucion_ventas.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_devolucion_ventas.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_cotizacion.Name Then
                    frm_reporte_cotizacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_cotizacion.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_conduces.Name Then
                    frm_reporte_conduces.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_conduces.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_notas_pedidos.Name Then
                    frm_reporte_notas_pedidos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_notas_pedidos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_financiamientos.Name Then
                    frm_consulta_financiamientos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_financiamientos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
                    frm_reporte_registro_facturas.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_registro_facturas.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
                    frm_reporte_nota_debito_credito_cxc.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_nota_debito_credito_cxc.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
                    frm_reporte_cobros_facturas.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_cobros_facturas.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                    frm_reporte_cuentas_por_cobrar.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_cuentas_por_cobrar.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                ElseIf Me.Owner.Name = frm_reporte_pagares.Name Then
                    frm_reporte_pagares.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_pagares.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                    frm_reporte_series_garantias.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_series_garantias.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_solicitudes_clientes.Name Then
                    frm_reporte_solicitudes_clientes.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_solicitudes_clientes.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_otros_ingresos.Name Then
                    frm_reporte_otros_ingresos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_otros_ingresos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_cobros_adelantados.Name Then
                    frm_reporte_cobros_adelantados.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_cobros_adelantados.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_cheques_devueltos.Name Then
                    frm_reporte_cheques_devueltos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_cheques_devueltos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_cheques_futuros.Name Then
                    frm_reporte_cheques_futuros.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_cheques_futuros.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_recibos_ingresos.Name Then
                    frm_consulta_recibos_ingresos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_recibos_ingresos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_otros_ingresos.Name Then
                    frm_consulta_otros_ingresos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_otros_ingresos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_cheques_futuros.Name Then
                    frm_consulta_cheques_futuros.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_cheques_futuros.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_cheques_devueltos.Name Then
                    frm_consulta_cheques_devueltos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_cheques_devueltos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_acuerdo_pago.Name Then
                    frm_consulta_acuerdo_pago.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_acuerdo_pago.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_acuerdos_pago.Name Then
                    frm_reporte_acuerdos_pago.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_acuerdos_pago.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_financiamientos.Name Then
                    frm_reporte_financiamientos.txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
                    frm_reporte_financiamientos.txtCliente.Text = Tabla.Rows(0).Item("Nombre")

                ElseIf Me.Owner.Name = frm_consulta_progreso_solicitud.Name Then
                    frm_consulta_progreso_solicitud.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_progreso_solicitud.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_consulta_pagos_financiamientos.Name Then
                    frm_consulta_pagos_financiamientos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_consulta_pagos_financiamientos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_traspasar_pagare.Name Then
                    frm_traspasar_pagare.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_traspasar_pagare.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_traspasar_pagare.LeerPagares()

                    MessageBox.Show("Al realizar un traspaso de pagarés, recuerde actualizar el nuevo cobrador asignado al cliente.", "Recordatorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                ElseIf Me.Owner.Name = frm_restablecer_pagare.Name Then
                    frm_restablecer_pagare.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_restablecer_pagare.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_restablecer_pagare.LeerPagares()

                ElseIf Me.Owner.Name = frm_reporte_recibos_cobros.Name Then
                    frm_reporte_recibos_cobros.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_recibos_cobros.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_entrega_cobros.Name Then
                    frm_reporte_entrega_cobros.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_entrega_cobros.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_reporte_titulaciones.Name Then
                    frm_reporte_titulaciones.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_titulaciones.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_cartas_modelos_clientes.Name Then
                    frm_cartas_modelos_clientes.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_cartas_modelos_clientes.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_cartas_modelos_clientes.FillInfoClientes()

                ElseIf Me.Owner.Name = frm_reporte_cuotas_financiamientos.Name Then
                    frm_reporte_cuotas_financiamientos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_reporte_cuotas_financiamientos.txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

                ElseIf Me.Owner.Name = frm_ajustes.Name Then
                    frm_ajustes.txtIDClienteContraEntrega.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_ajustes.txtNombreContraEntrega.Text = (Tabla.Rows(0).Item("Nombre"))
                End If

                Tabla.Dispose()
                DsTemp.Dispose()

                Close()

            End If


        Catch ex As Exception
        MessageBox.Show(ex.Message.ToString)
        '        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub DgvClientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvClientes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If DgvClientes.Rows.Count > 0 Then
                LlenarFormularios()
            Else
                txtBuscar.Focus()
            End If
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvClientes.Focus()
        End If
    End Sub

    Private Sub DgvClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvClientes.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvClientes.ColumnCount
                Dim NumRows As Integer = DgvClientes.RowCount
                Dim CurCell As DataGridViewCell = DgvClientes.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvClientes.CurrentCell = DgvClientes.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvClientes.CurrentCell = DgvClientes.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True


            ElseIf Control.ModifierKeys = Keys.F2 Then
                e.Handled = True
                txtBuscar.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvClientes.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                LlenarFormularios()
            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvClientes_SelectionChanged(sender As Object, e As EventArgs) Handles DgvClientes.SelectionChanged
        If DgvClientes.Rows.Count > 0 Then
            If DgvClientes.Focused = True Then
                txtBalance.Text = CDbl(DgvClientes.CurrentRow.Cells(6).Value).ToString("C")

                If IsNumeric(DgvClientes.CurrentRow.Cells(7).Value) Then
                    txtUltimoPago.Text = CDate(DgvClientes.CurrentRow.Cells(7).Value).ToString("dd/MM/yyyy")
                Else
                    txtUltimoPago.Text = DgvClientes.CurrentRow.Cells(7).Value
                End If
            End If
        End If
    End Sub

    Private Sub txtTamañoLetra_Leave(sender As Object, e As EventArgs) Handles txtTamañoLetra.Leave
        If IsNumeric(txtTamañoLetra.Text) Then
            If CDbl(txtTamañoLetra.Text) < 7 Then
                txtTamañoLetra.Text = 7
            End If
            If CDbl(txtTamañoLetra.Text) > 30 Then
                txtTamañoLetra.Text = 30
            End If
        Else
            txtTamañoLetra.Text = 9
        End If

        Dim FontSize As Single = txtTamañoLetra.Text

        With DgvClientes
            .AlternatingRowsDefaultCellStyle.Font = New Font("Segoe UI", FontSize, FontStyle.Regular)
            .DefaultCellStyle.Font = New Font("Segoe UI", FontSize, FontStyle.Regular)
        End With
    End Sub

    Private Sub txtTamañoLetra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTamañoLetra.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub frm_buscar_clientes_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDvg()
    End Sub

    Private Sub cbxShowPicture_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxShowPicture.SelectedIndexChanged
        If TypeConnection.Text = 1 Then
            PropiedadColumnsDvg()

            If cbxShowPicture.Text = "Sí" Then
                Me.Size = New Size(Width, 561 + 150)
                Me.CenterToScreen()
                Dim wFile As System.IO.FileStream
                For Each Row As DataGridViewRow In DgvClientes.Rows
                    If IsDBNull(Row.Cells(5).Value) Then
                    Else
                        Dim Content As String = Row.Cells(5).Value
                        Dim ExistFile As Boolean = System.IO.File.Exists(Content)
                        If ExistFile = True Then
                            wFile = New FileStream(Content, FileMode.Open, FileAccess.Read)
                            Row.Cells(0).Value = System.Drawing.Image.FromStream(wFile)
                        End If
                    End If
                Next
            Else
                Me.Size = New Size(Width, 561)
                Me.CenterToParent()
            End If
        End If


        txtBuscar.Focus()
    End Sub

    Private Sub RefrescarFotos()
        If cbxShowPicture.Text = "Sí" Then
            If TypeConnection.Text = 1 Then
                Dim wFile As System.IO.FileStream
                For Each Row As DataGridViewRow In DgvClientes.Rows
                    If IsDBNull(Row.Cells(5).Value) Then
                    Else
                        Dim Content As String = Row.Cells(5).Value
                        Dim ExistFile As Boolean = System.IO.File.Exists(Content)
                        If ExistFile = True Then
                            wFile = New FileStream(Content, FileMode.Open, FileAccess.Read)
                            Row.Cells(0).Value = System.Drawing.Image.FromStream(wFile)
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub frm_buscar_clientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub

    Private Sub frm_buscar_clientes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.F2 Then
            e.Handled = True
            txtBuscar.Focus()

        ElseIf e.KeyCode = Keys.Down Then
            If DgvClientes.Focused = False Then
                BindingNavigatorMoveNextItem.PerformClick()

            End If

        ElseIf e.KeyCode = Keys.Up Then
            If DgvClientes.Focused = False Then
                BindingNavigatorMovePreviousItem.PerformClick()
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        frm_consulta_rapida_no_factura.ShowDialog(Me)
    End Sub

End Class